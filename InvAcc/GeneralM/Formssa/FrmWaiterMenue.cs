using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar.Ribbon;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using Framework.Data;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Library.RepShow;
using Microsoft.Win32;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmWaiterMenue : Form
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
                    if (textBox_ID.Text != "" && State == FormState.Saved)
                    {

                        buttonItem_Print_Click(null, null);
                        VarGeneral.Print_set_Gen_Stat = false;
                    }
                    else
                    {

                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "InvSalWtr";
                        frm.RepCashier = "InvoiceCachierWaiter";

                        frm.Repvalue = "InvSalWtr";
                        frm.RepCashier = "InvoiceCachierWaiter";
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
        private CheckBoxX checkBox_NetWork;
        internal GroupBox groupBox1;
        private CheckBoxX checkBox_Chash;
        internal Label Label26;
        private DoubleInput txtDueAmount;
        private GroupBox groupBox2;
        internal Label label8;
        private DoubleInput txtTotalAm;
        private DoubleInput txtDiscountVal;
        private DoubleInput txtDiscountP;
        internal Label label3;
        private DoubleInput txtDiscountValLoc;
        private DoubleInput txtTotalAmLoc;
        private DoubleInput txtDueAmountLoc;
        internal Label label9;
        internal Label label17;
        protected ButtonItem Button_Add;
        protected ButtonItem buttonItem_Print;
        protected ButtonItem Button_Save;
        protected ButtonItem Button_Search;
        protected ButtonItem Button_Delete;
        protected ButtonItem Button_Close;
        private ButtonItem buttonItem11;
        private SuperTabControl superTabControl_Main1;
        private ButtonItem buttonItem6;
        private DoubleInput txtTotalQ;
        private MetroTileItem metroTileItem1;
        private ItemContainer itemContainer_Cat;
        private PictureBox pictureBox_Cash;
        private MetroTilePanel metroTilePanel_Cat;
        private PictureBox pictureBox_NetWord;
        protected LabelItem labelItem6;
        private PictureBox pictureBox_Credit;
        private LabelItem lable_Records;
        private RibbonBar ribbonBar_Tasks;
        private SuperTabControl superTabControl_Main2;
        protected LabelItem labelItem4;
        protected ButtonItem Button_First;
        protected ButtonItem Button_Prev;
        protected TextBoxItem TextBox_Index;
        protected LabelItem labelItem5;
        protected ButtonItem Button_Next;
        protected ButtonItem Button_Last;
        private ButtonX button_0;
        private ButtonX button_2;
        private ButtonX button_1;
        private ButtonX button_6;
        private ButtonX button_5;
        private ButtonX button_8;
        private ButtonX button_7;
        private ButtonX button_Bac;
        private ButtonX button_3;
        private ButtonX button_4;
        private MetroTilePanel metroTilePanel_Items;
        private RibbonBar ribbonBar_Items;
        private SuperTabControl superTabControl_ItemsGrids;
        protected LabelItem labelItem2;
        protected ButtonItem btnPrevPage;
        protected ButtonItem btnNxtPage;
        protected LabelItem Label_Count;
        private GroupPanel groupPanel_BoardNo;
        private ButtonX button_9;
        private TextBox txtCustNo;
        private ButtonX button_SrchCustNo;
        internal TextBox txtCustName;
        internal Label label10;
        internal Label label4;
        private DoubleInput doubleInput_Rate;
        private DoubleInput txtInvCost;
        private GroupBox groupBox5;
        internal Label label12;
        private TextBox txtAddress;
        private C1FlexGrid FlxInv;
        private ComboBoxEx CmbInvPrice;
        private ComboBoxEx CmbCostC;
        private ComboBoxEx CmbCurr;
        private ComboBoxEx CmbLegate;
        internal TextBox textBox_ID;
        internal Label label5;
        internal Label label15;
        internal Label label13;
        internal Label label19;
        internal Label label18;
        internal Label label7;
        internal Label Label2;
        internal Label Label1;
        protected SuperGridControl DGV_Main;
        private PanelEx panelEx3;
        private RibbonBar ribbonBar_DGV;
        private SuperTabControl superTabControl_DGV;
        protected TextBoxItem textBox_search;
        protected ButtonItem Button_ExportTable2;
        protected ButtonItem Button_PrintTable;
        protected LabelItem labelItem3;
        private Panel panel1;
        private ExpandableSplitter expandableSplitter1;
        private PanelEx panelEx2;
        private RibbonBar ribbonBar1;
        private RibbonClientPanel ribbonClientPanel1;
        private SuperTabControl superTabControl_Info;
        private SuperTabControlPanel superTabControlPanel1;
        private DoubleInput doubleInput_NetWorkLoc;
        private DoubleInput txtPaymentLoc;
        internal Label label14;
        internal Label label6;
        private SuperTabItem superTabItem_Pay;
        private SuperTabControlPanel superTabControlPanel4;
        private TextBoxX txtRemark;
        private SuperTabItem superTabItem_Note;
        private SaveFileDialog saveFileDialog1;
        private ImageList imageList1;
        internal PrintPreviewDialog prnt_prev;
        private PrintDocument prnt_doc;
        private OpenFileDialog openFileDialog1;
        protected ContextMenuStrip contextMenuStrip1;
        protected ContextMenuStrip contextMenuStrip2;
        protected ToolStripMenuItem ToolStripMenuItem_Det;
        protected ToolStripMenuItem ToolStripMenuItem_Rep;
        private Timer timerInfoBallon;
        private DoubleInput textBox1;
        private DoubleInput textBox2;
        private C1FlexGrid FlxDat;
        private DoubleInput txtCustRep;
        private TextBox txtItemName;
        private DoubleInput txtCustNet;
        private TextBoxX txtTele;
        private TextBoxX txtRef;
        private MaskedTextBox txtTime;
        private MaskedTextBox txtGDate;
        private MaskedTextBox txtHDate;
        private ButtonX button_Space;
        private SuperTabStrip superTabStripORDER;
        private SuperTabItem superTabItem_OrderType;
        private Panel panel_Table;
        private IntegerInput txtTable;
        private Label label31;
        private IntegerInput txtPersons;
        private ButtonX button_SrchTable;
        private ButtonX button_DeleteLine;
        internal Label label11;
        private DoubleInput doubleInput_CreditLoc;
        private CheckBoxItem checkBoxItem_BarCode;
        private GalleryContainer galleryContainer1;
        private SuperGridControl superGridControl1;
        protected ButtonItem buttonItem_BestSeller;
        private ButtonX button_SrchCenterCost;
        private ButtonX button_SrchMnd;
        private ButtonX button_SrchCurr;
        private ButtonX button_SrchPriceDefault;
        private ButtonX button_SrchCustADD;
        private C1FlexGrid dataGridView_ItemDet;
        private C1FlexGrid FlxStkQty;
        private LabelItem labelTableTyp;
        private LabelItem labelItem_Space;
        private Label label_Waiter;
        private TextBox textBox_WaiterName;
        private SwitchButton switchButton_Lock;
        private ButtonX button_AddToTable;
        private SuperTabControlPanel superTabControlPanel5;
        private SuperTabControl superTabControl_CostSts;
        private SuperTabControlPanel superTabControlPanel6;
        private SwitchButton switchButton_Tax;
        internal Label label34;
        internal Label label37;
        private DoubleInput txtTotTax;
        private DoubleInput txtTotTaxLoc;
        private SuperTabItem superTabItem_Tax;
        private SuperTabControlPanel superTabControlPanel8;
        internal Label label42;
        private TextBoxX txtCredit7;
        private CheckBoxX checkBox_GaidBankComm;
        private SwitchButton switchButton_BankComm;
        internal Label label48;
        internal Label label49;
        private DoubleInput txtTotBankComm;
        private DoubleInput txtTotBankCommLoc;
        private SuperTabControlPanel superTabControlPanel7;
        internal Label label39;
        internal Label label40;
        private TextBoxX txtCredit6;
        private TextBoxX txtDebit6;
        private CheckBoxX checkBox_GaidDis;
        internal Label label38;
        internal Label label41;
        private DoubleInput txtTotDis;
        private DoubleInput txtTotDisLoc;
        private SwitchButtonItem switchButton_TaxLines;
        private SwitchButtonItem switchButton_TaxByTotal;
        private SwitchButtonItem switchButton_TaxByNet;
        private TextBoxItem textBoxItem_TaxByNetValue;
        private LabelItem labelItem_TaxByNetPer;
        private SuperTabItem superTabItem_Gaids;
        private CheckBoxX checkBox_CostGaidTax;
        private bool vQtyGraid = false;
        private bool vPriceGraid = false;
        private bool vDisGraid = false;
        private bool vTotGraid = false;
        private bool vTax = false;
        private BindingManagerBase _Bm;
        private bool vChk = false;
        private int orderNo_activate = 0;
        private int ControlNo = 0;
        private int PageSize = 10;
        private int PageSizeDet = 10;
        private int CurrentPageIndex = 1;
        private int CurrentPageIndexItmDet = 1;
        private int TotalPage = 0;
        private int TotalPageDet = 0;
        private int col = 0;
        private int colW = 0;
        private int row = 0;
        private int rowH = 0;
        private DataTable vUnitA = new DataTable();
        private DataTable vUnitE = new DataTable();
        private int RowSel = 0;
        private string oldUnit = "";
        private string oldItemName = "";
        private double RateValue = 1.0;
        private int DefPack = 0;
        private double Pack = 0.0;
        private double PriceLoc = 0.0;
        private ScriptNumber ScriptNumber1 = new ScriptNumber();
        private List<int> ItemDetRemoved = new List<int>();
        public Dictionary<string, string> columns_Nams_Sums = new Dictionary<string, string>();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private string UnitAOld = "";
        private string UnitEOld = "";
        private double PriceOld = 0.0;
        public static int LangArEn = 0;
        public string DocType = "";
        private T_SYSSETTING _SysSetting = new T_SYSSETTING();
        private List<T_SYSSETTING> listSysSetting = new List<T_SYSSETTING>();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
        private T_STKSQTY _StksQty = new T_STKSQTY();
        private List<T_STKSQTY> listStkQty = new List<T_STKSQTY>();
        private List<T_QTYEXP> listQtyExp = new List<T_QTYEXP>();
        private T_QTYEXP _QtyExp = new T_QTYEXP();
        private T_Unit _Unit = new T_Unit();
        private List<T_Unit> listUnit = new List<T_Unit>();
        private T_Item _Items = new T_Item();
        private List<T_Item> listItems = new List<T_Item>();
        private T_Store _Store = new T_Store();
        private List<T_Store> listStore = new List<T_Store>();
        private List<T_Curency> listCurency = new List<T_Curency>();
        private T_Curency _Curency = new T_Curency();
        private T_INVDET _InvDetRet = new T_INVDET();
        private T_INVDET _InvDet = new T_INVDET();
        private T_INVHED data_this;
        private T_STKSQTY data_this_stkQ;
        private List<T_INVDET> LData_This;
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
        private int iiRntP = 0;
        private int _page = 1;
        private bool ifAutoOrderColumn = true;
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private Stock_DataDataContext dbInstanceReturn;
        private T_User permission = new T_User();
        private bool isPrintSts = false;
        public Dictionary<int, List<T_SINVDET>> vSINVDIT = new Dictionary<int, List<T_SINVDET>>();
        public string ItmMainParameter = "";
        private int _RowIndex = 0;
        private Dictionary<string, ColumnDictinary> Dir_ButSearch = new Dictionary<string, ColumnDictinary>();
        private int _stsClick = 0;
        public T_INVHED DataThis
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
        public List<T_INVDET> LDataThis
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
                if (value != 0)
                {
                    switchButton_Lock.IsReadOnly = true;
                }
                else
                {
                    switchButton_Lock.IsReadOnly = false;
                }
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
                if (State == FormState.New)
                {
                    switchButton_Lock.Visible = false;
                    button_AddToTable.Visible = !value;
                }
                else
                {
                    switchButton_Lock.Visible = true;
                    button_AddToTable.Visible = value;
                }
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
                    if (!VarGeneral.TString.ChkStatShow(value.InvStr, 1))
                    {
                        IfAdd = false;
                    }
                    else
                    {
                        IfAdd = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.InvStr, 2))
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.InvStr, 3))
                    {
                        IfDelete = false;
                    }
                    else
                    {
                        IfDelete = true;
                    }
                    if (State != FormState.New)
                    {
                        switchButton_Lock.Visible = true;
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
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWaiterMenue));
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background3 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor1 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor2 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle1 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle2 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.Background background4 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            this.checkBox_NetWork = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_Chash = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.Label26 = new System.Windows.Forms.Label();
            this.txtDueAmount = new DevComponents.Editors.DoubleInput();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDiscountVal = new DevComponents.Editors.DoubleInput();
            this.txtDiscountP = new DevComponents.Editors.DoubleInput();
            this.txtTotalAmLoc = new DevComponents.Editors.DoubleInput();
            this.txtDueAmountLoc = new DevComponents.Editors.DoubleInput();
            this.label9 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtTotalAm = new DevComponents.Editors.DoubleInput();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiscountValLoc = new DevComponents.Editors.DoubleInput();
            this.buttonItem11 = new DevComponents.DotNetBar.ButtonItem();
            this.superTabControl_Main1 = new DevComponents.DotNetBar.SuperTabControl();
            this.Button_Close = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem_Print = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Search = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Delete = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Save = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Add = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem_Space = new DevComponents.DotNetBar.LabelItem();
            this.labelTableTyp = new DevComponents.DotNetBar.LabelItem();
            this.buttonItem6 = new DevComponents.DotNetBar.ButtonItem();
            this.txtTotalQ = new DevComponents.Editors.DoubleInput();
            this.metroTileItem1 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.itemContainer_Cat = new DevComponents.DotNetBar.ItemContainer();
            this.metroTilePanel_Cat = new DevComponents.DotNetBar.Metro.MetroTilePanel();
            this.labelItem6 = new DevComponents.DotNetBar.LabelItem();
            this.lable_Records = new DevComponents.DotNetBar.LabelItem();
            this.ribbonBar_Tasks = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl_Main2 = new DevComponents.DotNetBar.SuperTabControl();
            this.labelItem4 = new DevComponents.DotNetBar.LabelItem();
            this.Button_First = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Prev = new DevComponents.DotNetBar.ButtonItem();
            this.TextBox_Index = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem5 = new DevComponents.DotNetBar.LabelItem();
            this.Button_Next = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Last = new DevComponents.DotNetBar.ButtonItem();
            this.button_0 = new DevComponents.DotNetBar.ButtonX();
            this.button_2 = new DevComponents.DotNetBar.ButtonX();
            this.button_1 = new DevComponents.DotNetBar.ButtonX();
            this.button_6 = new DevComponents.DotNetBar.ButtonX();
            this.button_5 = new DevComponents.DotNetBar.ButtonX();
            this.button_8 = new DevComponents.DotNetBar.ButtonX();
            this.button_7 = new DevComponents.DotNetBar.ButtonX();
            this.button_Bac = new DevComponents.DotNetBar.ButtonX();
            this.button_3 = new DevComponents.DotNetBar.ButtonX();
            this.button_4 = new DevComponents.DotNetBar.ButtonX();
            this.metroTilePanel_Items = new DevComponents.DotNetBar.Metro.MetroTilePanel();
            this.superGridControl1 = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.ribbonBar_Items = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl_ItemsGrids = new DevComponents.DotNetBar.SuperTabControl();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            this.btnPrevPage = new DevComponents.DotNetBar.ButtonItem();
            this.btnNxtPage = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem_BestSeller = new DevComponents.DotNetBar.ButtonItem();
            this.Label_Count = new DevComponents.DotNetBar.LabelItem();
            this.groupPanel_BoardNo = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.button_DeleteLine = new DevComponents.DotNetBar.ButtonX();
            this.button_Space = new DevComponents.DotNetBar.ButtonX();
            this.button_9 = new DevComponents.DotNetBar.ButtonX();
            this.txtCustNo = new System.Windows.Forms.TextBox();
            this.button_SrchCustNo = new DevComponents.DotNetBar.ButtonX();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.doubleInput_Rate = new DevComponents.Editors.DoubleInput();
            this.txtInvCost = new DevComponents.Editors.DoubleInput();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label_Waiter = new System.Windows.Forms.Label();
            this.textBox_WaiterName = new System.Windows.Forms.TextBox();
            this.switchButton_Lock = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.FlxStkQty = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.button_SrchPriceDefault = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchCurr = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchMnd = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchCenterCost = new DevComponents.DotNetBar.ButtonX();
            this.txtTime = new System.Windows.Forms.MaskedTextBox();
            this.txtGDate = new System.Windows.Forms.MaskedTextBox();
            this.txtHDate = new System.Windows.Forms.MaskedTextBox();
            this.CmbInvPrice = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.FlxDat = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.FlxInv = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.CmbCostC = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox_Cash = new System.Windows.Forms.PictureBox();
            this.pictureBox_NetWord = new System.Windows.Forms.PictureBox();
            this.pictureBox_Credit = new System.Windows.Forms.PictureBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.CmbLegate = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.CmbCurr = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.superTabControl_Info = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel4 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.txtRemark = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.superTabItem_Note = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel5 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.superTabControl_CostSts = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel6 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.checkBox_CostGaidTax = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.switchButton_Tax = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.label34 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.txtTotTax = new DevComponents.Editors.DoubleInput();
            this.txtTotTaxLoc = new DevComponents.Editors.DoubleInput();
            this.superTabItem_Tax = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel8 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.label42 = new System.Windows.Forms.Label();
            this.txtCredit7 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.checkBox_GaidBankComm = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.switchButton_BankComm = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.txtTotBankComm = new DevComponents.Editors.DoubleInput();
            this.txtTotBankCommLoc = new DevComponents.Editors.DoubleInput();
            this.superTabControlPanel7 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.txtCredit6 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtDebit6 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.checkBox_GaidDis = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label38 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.txtTotDis = new DevComponents.Editors.DoubleInput();
            this.txtTotDisLoc = new DevComponents.Editors.DoubleInput();
            this.switchButton_TaxLines = new DevComponents.DotNetBar.SwitchButtonItem();
            this.switchButton_TaxByTotal = new DevComponents.DotNetBar.SwitchButtonItem();
            this.switchButton_TaxByNet = new DevComponents.DotNetBar.SwitchButtonItem();
            this.textBoxItem_TaxByNetValue = new DevComponents.DotNetBar.TextBoxItem();
            this.labelItem_TaxByNetPer = new DevComponents.DotNetBar.LabelItem();
            this.superTabItem_Gaids = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.dataGridView_ItemDet = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label11 = new System.Windows.Forms.Label();
            this.doubleInput_CreditLoc = new DevComponents.Editors.DoubleInput();
            this.txtPaymentLoc = new DevComponents.Editors.DoubleInput();
            this.label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.doubleInput_NetWorkLoc = new DevComponents.Editors.DoubleInput();
            this.superTabItem_Pay = new DevComponents.DotNetBar.SuperTabItem();
            this.checkBoxItem_BarCode = new DevComponents.DotNetBar.CheckBoxItem();
            this.txtTele = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtRef = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.button_SrchCustADD = new DevComponents.DotNetBar.ButtonX();
            this.DGV_Main = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.ribbonBar_DGV = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl_DGV = new DevComponents.DotNetBar.SuperTabControl();
            this.textBox_search = new DevComponents.DotNetBar.TextBoxItem();
            this.Button_ExportTable2 = new DevComponents.DotNetBar.ButtonItem();
            this.Button_PrintTable = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem3 = new DevComponents.DotNetBar.LabelItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.ribbonClientPanel1 = new DevComponents.DotNetBar.Ribbon.RibbonClientPanel();
            this.superTabStripORDER = new DevComponents.DotNetBar.SuperTabStrip();
            this.panel_Table = new System.Windows.Forms.Panel();
            this.txtPersons = new DevComponents.Editors.IntegerInput();
            this.label31 = new System.Windows.Forms.Label();
            this.button_SrchTable = new DevComponents.DotNetBar.ButtonX();
            this.txtTable = new DevComponents.Editors.IntegerInput();
            this.button_AddToTable = new DevComponents.DotNetBar.ButtonX();
            this.superTabItem_OrderType = new DevComponents.DotNetBar.SuperTabItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.prnt_prev = new System.Windows.Forms.PrintPreviewDialog();
            this.prnt_doc = new System.Drawing.Printing.PrintDocument();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_Det = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Rep = new System.Windows.Forms.ToolStripMenuItem();
            this.timerInfoBallon = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new DevComponents.Editors.DoubleInput();
            this.textBox2 = new DevComponents.Editors.DoubleInput();
            this.txtCustRep = new DevComponents.Editors.DoubleInput();
            this.txtCustNet = new DevComponents.Editors.DoubleInput();
            this.galleryContainer1 = new DevComponents.DotNetBar.GalleryContainer();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDueAmount)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalAmLoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDueAmountLoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalAm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountValLoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalQ)).BeginInit();
            this.ribbonBar_Tasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main2)).BeginInit();
            this.metroTilePanel_Items.SuspendLayout();
            this.ribbonBar_Items.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_ItemsGrids)).BeginInit();
            this.groupPanel_BoardNo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_Rate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvCost)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlxStkQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlxDat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlxInv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Cash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_NetWord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Credit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Info)).BeginInit();
            this.superTabControl_Info.SuspendLayout();
            this.superTabControlPanel4.SuspendLayout();
            this.superTabControlPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_CostSts)).BeginInit();
            this.superTabControl_CostSts.SuspendLayout();
            this.superTabControlPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotTaxLoc)).BeginInit();
            this.superTabControlPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotBankComm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotBankCommLoc)).BeginInit();
            this.superTabControlPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotDis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotDisLoc)).BeginInit();
            this.superTabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ItemDet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_CreditLoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaymentLoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_NetWorkLoc)).BeginInit();
            this.panelEx3.SuspendLayout();
            this.ribbonBar_DGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_DGV)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            this.ribbonClientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabStripORDER)).BeginInit();
            this.superTabStripORDER.SuspendLayout();
            this.panel_Table.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTable)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustRep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustNet)).BeginInit();
            this.PanelSpecialContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSpecialContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelSpecialContainer.Name = "PanelSpecialContainer";
            this.PanelSpecialContainer.Size = new System.Drawing.Size(1278, 514);
            this.PanelSpecialContainer.TabIndex = 1220;
            this.Controls.Add(this.PanelSpecialContainer);
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
            this.checkBox_NetWork.Location = new System.Drawing.Point(172, 54);
            this.checkBox_NetWork.Name = "checkBox_NetWork";
            this.checkBox_NetWork.Size = new System.Drawing.Size(63, 16);
            this.checkBox_NetWork.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_NetWork.TabIndex = 1022;
            this.checkBox_NetWork.Text = "شبكـــة";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.checkBox_NetWork);
            this.groupBox1.Controls.Add(this.checkBox_Chash);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(179, 243);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(260, 52);
            this.groupBox1.TabIndex = 1108;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // checkBox_Chash
            // 
            this.checkBox_Chash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_Chash.AutoSize = true;
            this.checkBox_Chash.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBox_Chash.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_Chash.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            this.checkBox_Chash.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            this.checkBox_Chash.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBox_Chash.CheckSignSize = new System.Drawing.Size(14, 14);
            this.checkBox_Chash.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.checkBox_Chash.Location = new System.Drawing.Point(-12, 42);
            this.checkBox_Chash.Name = "checkBox_Chash";
            this.checkBox_Chash.Size = new System.Drawing.Size(73, 21);
            this.checkBox_Chash.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_Chash.TabIndex = 15;
            this.checkBox_Chash.Text = "نقـــدي";
            // 
            // Label26
            // 
            this.Label26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label26.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.Label26.ForeColor = System.Drawing.Color.White;
            this.Label26.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label26.Location = new System.Drawing.Point(151, 16);
            this.Label26.Name = "Label26";
            this.Label26.Size = new System.Drawing.Size(84, 25);
            this.Label26.TabIndex = 1113;
            this.Label26.Text = "قيمة الخصم";
            this.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDueAmount
            // 
            this.txtDueAmount.AllowEmptyState = false;
            this.txtDueAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtDueAmount.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.txtDueAmount.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDueAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDueAmount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtDueAmount.DisplayFormat = "0.00";
            this.txtDueAmount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtDueAmount.Increment = 0D;
            this.txtDueAmount.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtDueAmount.IsInputReadOnly = true;
            this.txtDueAmount.Location = new System.Drawing.Point(4, 108);
            this.txtDueAmount.Name = "txtDueAmount";
            this.txtDueAmount.Size = new System.Drawing.Size(61, 23);
            this.txtDueAmount.TabIndex = 1081;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.Label26);
            this.groupBox2.Controls.Add(this.txtDiscountVal);
            this.groupBox2.Controls.Add(this.txtDiscountP);
            this.groupBox2.Controls.Add(this.txtTotalAmLoc);
            this.groupBox2.Controls.Add(this.txtDueAmountLoc);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txtDueAmount);
            this.groupBox2.Controls.Add(this.txtTotalAm);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtDiscountValLoc);
            this.groupBox2.Location = new System.Drawing.Point(-262, 437);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(241, 135);
            this.groupBox2.TabIndex = 1115;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(66, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 25);
            this.label8.TabIndex = 1114;
            this.label8.Text = "نسبة الخصم";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDiscountVal
            // 
            this.txtDiscountVal.AllowEmptyState = false;
            this.txtDiscountVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtDiscountVal.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDiscountVal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDiscountVal.ButtonCustom.Text = ".";
            this.txtDiscountVal.ButtonCustom.Visible = true;
            this.txtDiscountVal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtDiscountVal.DisplayFormat = "0.00";
            this.txtDiscountVal.FocusHighlightEnabled = true;
            this.txtDiscountVal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtDiscountVal.Increment = 0D;
            this.txtDiscountVal.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtDiscountVal.Location = new System.Drawing.Point(151, 46);
            this.txtDiscountVal.Name = "txtDiscountVal";
            this.txtDiscountVal.Size = new System.Drawing.Size(84, 23);
            this.txtDiscountVal.TabIndex = 1079;
            this.txtDiscountVal.ButtonCustomClick += new System.EventHandler(this.txtDiscountVal_ButtonCustomClick);
            this.txtDiscountVal.Enter += new System.EventHandler(this.txtDiscountVal_Enter);
            // 
            // txtDiscountP
            // 
            this.txtDiscountP.AllowEmptyState = false;
            this.txtDiscountP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtDiscountP.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDiscountP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDiscountP.ButtonCustom.Text = ".";
            this.txtDiscountP.ButtonCustom.Visible = true;
            this.txtDiscountP.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtDiscountP.DisplayFormat = "0.00";
            this.txtDiscountP.FocusHighlightEnabled = true;
            this.txtDiscountP.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtDiscountP.Increment = 0D;
            this.txtDiscountP.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtDiscountP.Location = new System.Drawing.Point(66, 46);
            this.txtDiscountP.Name = "txtDiscountP";
            this.txtDiscountP.Size = new System.Drawing.Size(84, 23);
            this.txtDiscountP.TabIndex = 1078;
            this.txtDiscountP.ButtonCustomClick += new System.EventHandler(this.txtDiscountP_ButtonCustomClick);
            this.txtDiscountP.Enter += new System.EventHandler(this.txtDiscountP_Enter);
            // 
            // txtTotalAmLoc
            // 
            this.txtTotalAmLoc.AllowEmptyState = false;
            this.txtTotalAmLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTotalAmLoc.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotalAmLoc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotalAmLoc.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotalAmLoc.DisplayFormat = "0.00";
            this.txtTotalAmLoc.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtTotalAmLoc.Increment = 0D;
            this.txtTotalAmLoc.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTotalAmLoc.IsInputReadOnly = true;
            this.txtTotalAmLoc.Location = new System.Drawing.Point(66, 77);
            this.txtTotalAmLoc.Name = "txtTotalAmLoc";
            this.txtTotalAmLoc.Size = new System.Drawing.Size(84, 23);
            this.txtTotalAmLoc.TabIndex = 1088;
            // 
            // txtDueAmountLoc
            // 
            this.txtDueAmountLoc.AllowEmptyState = false;
            this.txtDueAmountLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtDueAmountLoc.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.txtDueAmountLoc.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDueAmountLoc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDueAmountLoc.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtDueAmountLoc.DisplayFormat = "0.00";
            this.txtDueAmountLoc.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtDueAmountLoc.Increment = 0D;
            this.txtDueAmountLoc.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtDueAmountLoc.IsInputReadOnly = true;
            this.txtDueAmountLoc.Location = new System.Drawing.Point(66, 108);
            this.txtDueAmountLoc.Name = "txtDueAmountLoc";
            this.txtDueAmountLoc.Size = new System.Drawing.Size(84, 23);
            this.txtDueAmountLoc.TabIndex = 1089;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(149, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 16);
            this.label9.TabIndex = 1092;
            this.label9.Text = "صافي الفاتورة :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label17.ForeColor = System.Drawing.Color.Navy;
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(149, 80);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(91, 16);
            this.label17.TabIndex = 1082;
            this.label17.Text = "قيمة الفاتــورة :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotalAm
            // 
            this.txtTotalAm.AllowEmptyState = false;
            this.txtTotalAm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTotalAm.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.txtTotalAm.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotalAm.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotalAm.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotalAm.DisplayFormat = "0.00";
            this.txtTotalAm.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtTotalAm.Increment = 0D;
            this.txtTotalAm.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTotalAm.IsInputReadOnly = true;
            this.txtTotalAm.Location = new System.Drawing.Point(4, 77);
            this.txtTotalAm.Name = "txtTotalAm";
            this.txtTotalAm.Size = new System.Drawing.Size(61, 23);
            this.txtTotalAm.TabIndex = 1080;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(4, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 23);
            this.label3.TabIndex = 1091;
            this.label3.Text = "بالريــال";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDiscountValLoc
            // 
            this.txtDiscountValLoc.AllowEmptyState = false;
            this.txtDiscountValLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtDiscountValLoc.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.txtDiscountValLoc.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDiscountValLoc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDiscountValLoc.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtDiscountValLoc.DisplayFormat = "0.00";
            this.txtDiscountValLoc.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtDiscountValLoc.Increment = 0D;
            this.txtDiscountValLoc.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtDiscountValLoc.IsInputReadOnly = true;
            this.txtDiscountValLoc.Location = new System.Drawing.Point(4, 46);
            this.txtDiscountValLoc.Name = "txtDiscountValLoc";
            this.txtDiscountValLoc.Size = new System.Drawing.Size(61, 23);
            this.txtDiscountValLoc.TabIndex = 1090;
            // 
            // buttonItem11
            // 
            this.buttonItem11.GlobalItem = false;
            this.buttonItem11.Name = "buttonItem11";
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
            this.superTabControl_Main1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
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
            this.superTabControl_Main1.Size = new System.Drawing.Size(973, 51);
            this.superTabControl_Main1.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_Main1.TabIndex = 10;
            this.superTabControl_Main1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.Button_Close,
            this.buttonItem_Print,
            this.Button_Search,
            this.Button_Delete,
            this.Button_Save,
            this.Button_Add,
            this.labelItem_Space,
            this.labelTableTyp});
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
            // buttonItem_Print
            // 
            this.buttonItem_Print.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem_Print.FontBold = true;
            this.buttonItem_Print.FontItalic = true;
            this.buttonItem_Print.ForeColor = System.Drawing.Color.DimGray;
            this.buttonItem_Print.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem_Print.Image")));
            this.buttonItem_Print.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.buttonItem_Print.ImagePaddingHorizontal = 15;
            this.buttonItem_Print.ImagePaddingVertical = 11;
            this.buttonItem_Print.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem_Print.Name = "buttonItem_Print";
            this.buttonItem_Print.Stretch = true;
            this.buttonItem_Print.SubItemsExpandWidth = 14;
            this.buttonItem_Print.Symbol = "";
            this.buttonItem_Print.SymbolSize = 15F;
            this.buttonItem_Print.Text = "طباعة";
            this.buttonItem_Print.Tooltip = "طباعة السجل الحالي";
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
            // labelItem_Space
            // 
            this.labelItem_Space.Name = "labelItem_Space";
            // 
            // labelTableTyp
            // 
            this.labelTableTyp.BackColor = System.Drawing.Color.LightSteelBlue;
            this.labelTableTyp.ForeColor = System.Drawing.Color.Maroon;
            this.labelTableTyp.ImageTextSpacing = 16;
            this.labelTableTyp.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.labelTableTyp.Name = "labelTableTyp";
            this.labelTableTyp.ShowSubItems = false;
            this.labelTableTyp.Symbol = "";
            this.labelTableTyp.SymbolColor = System.Drawing.Color.Maroon;
            // 
            // buttonItem6
            // 
            this.buttonItem6.Name = "buttonItem6";
            this.buttonItem6.Symbol = "";
            this.buttonItem6.Text = "العمــــــلاء";
            // 
            // txtTotalQ
            // 
            this.txtTotalQ.AllowEmptyState = false;
            this.txtTotalQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTotalQ.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotalQ.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotalQ.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotalQ.DisplayFormat = "0.00";
            this.txtTotalQ.Font = new System.Drawing.Font("Tahoma", 6.75F);
            this.txtTotalQ.Increment = 0D;
            this.txtTotalQ.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTotalQ.IsInputReadOnly = true;
            this.txtTotalQ.Location = new System.Drawing.Point(277, 636);
            this.txtTotalQ.Name = "txtTotalQ";
            this.txtTotalQ.Size = new System.Drawing.Size(53, 18);
            this.txtTotalQ.TabIndex = 1136;
            this.txtTotalQ.Visible = false;
            // 
            // metroTileItem1
            // 
            this.metroTileItem1.Checked = true;
            this.metroTileItem1.GlobalItem = false;
            this.metroTileItem1.Name = "metroTileItem1";
            this.metroTileItem1.SymbolColor = System.Drawing.Color.Empty;
            this.metroTileItem1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            // 
            // 
            // 
            this.metroTileItem1.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // itemContainer_Cat
            // 
            this.itemContainer_Cat.AccessibleRole = System.Windows.Forms.AccessibleRole.ListItem;
            // 
            // 
            // 
            this.itemContainer_Cat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer_Cat.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.itemContainer_Cat.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer_Cat.Name = "itemContainer_Cat";
            // 
            // 
            // 
            this.itemContainer_Cat.TitleStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.itemContainer_Cat.TitleStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemContainer_Cat.TitleStyle.BorderBottomWidth = 1;
            this.itemContainer_Cat.TitleStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.itemContainer_Cat.TitleStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemContainer_Cat.TitleStyle.BorderLeftWidth = 1;
            this.itemContainer_Cat.TitleStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemContainer_Cat.TitleStyle.BorderRightWidth = 1;
            this.itemContainer_Cat.TitleStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemContainer_Cat.TitleStyle.BorderTopWidth = 1;
            this.itemContainer_Cat.TitleStyle.Class = "MetroTileGroupTitle";
            this.itemContainer_Cat.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer_Cat.TitleStyle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.itemContainer_Cat.TitleStyle.MarginBottom = 5;
            this.itemContainer_Cat.TitleStyle.MarginLeft = 5;
            this.itemContainer_Cat.TitleStyle.MarginRight = 5;
            this.itemContainer_Cat.TitleStyle.MarginTop = 5;
            this.itemContainer_Cat.TitleStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.itemContainer_Cat.TitleStyle.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.itemContainer_Cat.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // metroTilePanel_Cat
            // 
            this.metroTilePanel_Cat.BackColor = System.Drawing.Color.Gainsboro;
            // 
            // 
            // 
            this.metroTilePanel_Cat.BackgroundStyle.Class = "RibbonFileMenuTwoColumnContainer";
            this.metroTilePanel_Cat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTilePanel_Cat.ContainerControlProcessDialogKey = true;
            this.metroTilePanel_Cat.Dock = System.Windows.Forms.DockStyle.Left;
            this.metroTilePanel_Cat.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.metroTilePanel_Cat.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer_Cat});
            this.metroTilePanel_Cat.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.metroTilePanel_Cat.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.metroTilePanel_Cat.Location = new System.Drawing.Point(0, 0);
            this.metroTilePanel_Cat.Name = "metroTilePanel_Cat";
            this.metroTilePanel_Cat.Size = new System.Drawing.Size(146, 578);
            this.metroTilePanel_Cat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.metroTilePanel_Cat.TabIndex = 1149;
            this.metroTilePanel_Cat.ItemClick += new System.EventHandler(this.metroTilePanel_Cat_ItemClick);
            // 
            // labelItem6
            // 
            this.labelItem6.Name = "labelItem6";
            this.labelItem6.Width = 40;
            // 
            // lable_Records
            // 
            this.lable_Records.BackColor = System.Drawing.Color.SteelBlue;
            this.lable_Records.ForeColor = System.Drawing.Color.White;
            this.lable_Records.Name = "lable_Records";
            this.lable_Records.Text = "---";
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
            this.ribbonBar_Tasks.Controls.Add(this.superTabControl_Main2);
            this.ribbonBar_Tasks.Controls.Add(this.superTabControl_Main1);
            this.ribbonBar_Tasks.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ribbonBar_Tasks.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar_Tasks.Location = new System.Drawing.Point(0, 618);
            this.ribbonBar_Tasks.Name = "ribbonBar_Tasks";
            this.ribbonBar_Tasks.Size = new System.Drawing.Size(973, 51);
            this.ribbonBar_Tasks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar_Tasks.TabIndex = 1136;
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
            this.superTabControl_Main2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.superTabControl_Main2.ForeColor = System.Drawing.Color.Black;
            this.superTabControl_Main2.ItemPadding.Bottom = 4;
            this.superTabControl_Main2.ItemPadding.Left = 4;
            this.superTabControl_Main2.ItemPadding.Right = 4;
            this.superTabControl_Main2.ItemPadding.Top = 4;
            this.superTabControl_Main2.Location = new System.Drawing.Point(570, 0);
            this.superTabControl_Main2.Name = "superTabControl_Main2";
            this.superTabControl_Main2.ReorderTabsEnabled = true;
            this.superTabControl_Main2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.superTabControl_Main2.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_Main2.SelectedTabIndex = -1;
            this.superTabControl_Main2.Size = new System.Drawing.Size(403, 51);
            this.superTabControl_Main2.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_Main2.TabIndex = 12;
            this.superTabControl_Main2.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem4,
            this.Button_First,
            this.Button_Prev,
            this.TextBox_Index,
            this.labelItem5,
            this.lable_Records,
            this.Button_Next,
            this.Button_Last});
            this.superTabControl_Main2.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.superTabControl_Main2.Text = "superTabControl1";
            this.superTabControl_Main2.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            // 
            // labelItem4
            // 
            this.labelItem4.Name = "labelItem4";
            this.labelItem4.Width = 2;
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
            this.TextBox_Index.TextBoxWidth = 40;
            this.TextBox_Index.Visible = false;
            this.TextBox_Index.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // labelItem5
            // 
            this.labelItem5.Name = "labelItem5";
            this.labelItem5.Visible = false;
            this.labelItem5.Width = 30;
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
            // button_0
            // 
            this.button_0.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_0.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.button_0.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_0.Location = new System.Drawing.Point(0, 168);
            this.button_0.Name = "button_0";
            this.button_0.Size = new System.Drawing.Size(44, 41);
            this.button_0.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_0.TabIndex = 12;
            this.button_0.Text = "0";
            this.button_0.Click += new System.EventHandler(this.button_0_Click);
            // 
            // button_2
            // 
            this.button_2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_2.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.button_2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_2.Location = new System.Drawing.Point(0, 0);
            this.button_2.Name = "button_2";
            this.button_2.Size = new System.Drawing.Size(44, 41);
            this.button_2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_2.TabIndex = 10;
            this.button_2.Text = "2";
            this.button_2.Click += new System.EventHandler(this.button_2_Click);
            // 
            // button_1
            // 
            this.button_1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_1.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.button_1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_1.Location = new System.Drawing.Point(44, 0);
            this.button_1.Name = "button_1";
            this.button_1.Size = new System.Drawing.Size(44, 41);
            this.button_1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_1.TabIndex = 9;
            this.button_1.Text = "1";
            this.button_1.Click += new System.EventHandler(this.button_1_Click);
            // 
            // button_6
            // 
            this.button_6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_6.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.button_6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_6.Location = new System.Drawing.Point(0, 84);
            this.button_6.Name = "button_6";
            this.button_6.Size = new System.Drawing.Size(44, 41);
            this.button_6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_6.TabIndex = 8;
            this.button_6.Text = "6";
            this.button_6.Click += new System.EventHandler(this.button_6_Click);
            // 
            // button_5
            // 
            this.button_5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_5.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.button_5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_5.Location = new System.Drawing.Point(44, 84);
            this.button_5.Name = "button_5";
            this.button_5.Size = new System.Drawing.Size(44, 41);
            this.button_5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_5.TabIndex = 7;
            this.button_5.Text = "5";
            this.button_5.Click += new System.EventHandler(this.button_5_Click);
            // 
            // button_8
            // 
            this.button_8.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_8.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.button_8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_8.Location = new System.Drawing.Point(0, 126);
            this.button_8.Name = "button_8";
            this.button_8.Size = new System.Drawing.Size(44, 41);
            this.button_8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_8.TabIndex = 4;
            this.button_8.Text = "8";
            this.button_8.Click += new System.EventHandler(this.button_8_Click);
            // 
            // button_7
            // 
            this.button_7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_7.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.button_7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_7.Location = new System.Drawing.Point(44, 126);
            this.button_7.Name = "button_7";
            this.button_7.Size = new System.Drawing.Size(44, 41);
            this.button_7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_7.TabIndex = 3;
            this.button_7.Text = "7";
            this.button_7.Click += new System.EventHandler(this.button_7_Click);
            // 
            // button_Bac
            // 
            this.button_Bac.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_Bac.Checked = true;
            this.button_Bac.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.button_Bac.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button_Bac.Location = new System.Drawing.Point(44, 211);
            this.button_Bac.Name = "button_Bac";
            this.button_Bac.Size = new System.Drawing.Size(44, 41);
            this.button_Bac.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_Bac.TabIndex = 0;
            this.button_Bac.Text = "مسج";
            this.button_Bac.Tooltip = "مسح";
            this.button_Bac.Click += new System.EventHandler(this.button_Bac_Click);
            // 
            // button_3
            // 
            this.button_3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_3.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.button_3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_3.Location = new System.Drawing.Point(44, 42);
            this.button_3.Name = "button_3";
            this.button_3.Size = new System.Drawing.Size(44, 41);
            this.button_3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_3.TabIndex = 11;
            this.button_3.Text = "3";
            this.button_3.Click += new System.EventHandler(this.button_3_Click);
            // 
            // button_4
            // 
            this.button_4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_4.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.button_4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_4.Location = new System.Drawing.Point(0, 42);
            this.button_4.Name = "button_4";
            this.button_4.Size = new System.Drawing.Size(44, 41);
            this.button_4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_4.TabIndex = 6;
            this.button_4.Text = "4";
            this.button_4.Click += new System.EventHandler(this.button_4_Click);
            // 
            // metroTilePanel_Items
            // 
            this.metroTilePanel_Items.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.metroTilePanel_Items.BackgroundStyle.Class = "RibbonFileMenuTwoColumnContainer";
            this.metroTilePanel_Items.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTilePanel_Items.ContainerControlProcessDialogKey = true;
            this.metroTilePanel_Items.Controls.Add(this.superGridControl1);
            this.metroTilePanel_Items.Controls.Add(this.ribbonBar_Items);
            this.metroTilePanel_Items.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTilePanel_Items.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Right;
            this.metroTilePanel_Items.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.Label_Count});
            this.metroTilePanel_Items.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.metroTilePanel_Items.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.metroTilePanel_Items.Location = new System.Drawing.Point(146, 0);
            this.metroTilePanel_Items.MultiLine = true;
            this.metroTilePanel_Items.Name = "metroTilePanel_Items";
            this.metroTilePanel_Items.Size = new System.Drawing.Size(160, 578);
            this.metroTilePanel_Items.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.metroTilePanel_Items.TabIndex = 1130;
            // 
            // superGridControl1
            // 
            this.superGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superGridControl1.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.superGridControl1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.superGridControl1.Location = new System.Drawing.Point(0, 0);
            this.superGridControl1.Name = "superGridControl1";
            this.superGridControl1.PrimaryGrid.AllowEdit = false;
            this.superGridControl1.PrimaryGrid.ColumnHeader.Visible = false;
            this.superGridControl1.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.TopLeft;
            this.superGridControl1.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superGridControl1.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.TextColor = System.Drawing.Color.White;
            this.superGridControl1.PrimaryGrid.InitialActiveRow = DevComponents.DotNetBar.SuperGrid.RelativeRow.None;
            this.superGridControl1.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.None;
            this.superGridControl1.PrimaryGrid.MultiSelect = false;
            this.superGridControl1.PrimaryGrid.ShowColumnHeader = false;
            this.superGridControl1.PrimaryGrid.ShowRowHeaders = false;
            this.superGridControl1.Size = new System.Drawing.Size(160, 527);
            this.superGridControl1.TabIndex = 1196;
            this.superGridControl1.Text = "superGridControl1";
            this.superGridControl1.CellClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellClickEventArgs>(this.superGridControl1_CellClick);
            // 
            // ribbonBar_Items
            // 
            this.ribbonBar_Items.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar_Items.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar_Items.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar_Items.ContainerControlProcessDialogKey = true;
            this.ribbonBar_Items.Controls.Add(this.superTabControl_ItemsGrids);
            this.ribbonBar_Items.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ribbonBar_Items.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar_Items.Location = new System.Drawing.Point(0, 527);
            this.ribbonBar_Items.Name = "ribbonBar_Items";
            this.ribbonBar_Items.Size = new System.Drawing.Size(160, 51);
            this.ribbonBar_Items.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2000;
            this.ribbonBar_Items.TabIndex = 872;
            // 
            // 
            // 
            this.ribbonBar_Items.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar_Items.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar_Items.TitleVisible = false;
            // 
            // superTabControl_ItemsGrids
            // 
            this.superTabControl_ItemsGrids.BackColor = System.Drawing.Color.White;
            this.superTabControl_ItemsGrids.CausesValidation = false;
            // 
            // 
            // 
            this.superTabControl_ItemsGrids.ControlBox.Category = null;
            // 
            // 
            // 
            this.superTabControl_ItemsGrids.ControlBox.CloseBox.Category = null;
            this.superTabControl_ItemsGrids.ControlBox.CloseBox.Description = null;
            this.superTabControl_ItemsGrids.ControlBox.CloseBox.Name = "";
            this.superTabControl_ItemsGrids.ControlBox.CloseBox.Tag = null;
            this.superTabControl_ItemsGrids.ControlBox.Description = null;
            // 
            // 
            // 
            this.superTabControl_ItemsGrids.ControlBox.MenuBox.Category = null;
            this.superTabControl_ItemsGrids.ControlBox.MenuBox.Description = null;
            this.superTabControl_ItemsGrids.ControlBox.MenuBox.Name = "";
            this.superTabControl_ItemsGrids.ControlBox.MenuBox.Tag = null;
            this.superTabControl_ItemsGrids.ControlBox.Name = "";
            this.superTabControl_ItemsGrids.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl_ItemsGrids.ControlBox.MenuBox,
            this.superTabControl_ItemsGrids.ControlBox.CloseBox});
            this.superTabControl_ItemsGrids.ControlBox.Tag = null;
            this.superTabControl_ItemsGrids.ControlBox.Visible = false;
            this.superTabControl_ItemsGrids.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl_ItemsGrids.ForeColor = System.Drawing.Color.Black;
            this.superTabControl_ItemsGrids.ItemPadding.Bottom = 4;
            this.superTabControl_ItemsGrids.ItemPadding.Left = 4;
            this.superTabControl_ItemsGrids.ItemPadding.Right = 4;
            this.superTabControl_ItemsGrids.ItemPadding.Top = 4;
            this.superTabControl_ItemsGrids.Location = new System.Drawing.Point(0, 0);
            this.superTabControl_ItemsGrids.Name = "superTabControl_ItemsGrids";
            this.superTabControl_ItemsGrids.ReorderTabsEnabled = true;
            this.superTabControl_ItemsGrids.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.superTabControl_ItemsGrids.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_ItemsGrids.SelectedTabIndex = -1;
            this.superTabControl_ItemsGrids.Size = new System.Drawing.Size(160, 51);
            this.superTabControl_ItemsGrids.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_ItemsGrids.TabIndex = 11;
            this.superTabControl_ItemsGrids.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem2,
            this.btnPrevPage,
            this.btnNxtPage,
            this.buttonItem_BestSeller});
            this.superTabControl_ItemsGrids.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.superTabControl_ItemsGrids.Text = "superTabControl1";
            this.superTabControl_ItemsGrids.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            // 
            // labelItem2
            // 
            this.labelItem2.Name = "labelItem2";
            this.labelItem2.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelItem2.Width = 2;
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnPrevPage.Checked = true;
            this.btnPrevPage.FontBold = true;
            this.btnPrevPage.FontItalic = true;
            this.btnPrevPage.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnPrevPage.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevPage.Image")));
            this.btnPrevPage.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.btnPrevPage.ImagePaddingHorizontal = 10;
            this.btnPrevPage.ImagePaddingVertical = 11;
            this.btnPrevPage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Stretch = true;
            this.btnPrevPage.SubItemsExpandWidth = 14;
            this.btnPrevPage.Symbol = "";
            this.btnPrevPage.SymbolSize = 15F;
            this.btnPrevPage.Text = "السابق";
            this.btnPrevPage.Tooltip = "السجل السابق";
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);
            // 
            // btnNxtPage
            // 
            this.btnNxtPage.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnNxtPage.Checked = true;
            this.btnNxtPage.FontBold = true;
            this.btnNxtPage.FontItalic = true;
            this.btnNxtPage.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnNxtPage.Image = ((System.Drawing.Image)(resources.GetObject("btnNxtPage.Image")));
            this.btnNxtPage.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.btnNxtPage.ImagePaddingHorizontal = 10;
            this.btnNxtPage.ImagePaddingVertical = 11;
            this.btnNxtPage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnNxtPage.Name = "btnNxtPage";
            this.btnNxtPage.Stretch = true;
            this.btnNxtPage.SubItemsExpandWidth = 14;
            this.btnNxtPage.Symbol = "";
            this.btnNxtPage.SymbolSize = 15F;
            this.btnNxtPage.Text = "التالي";
            this.btnNxtPage.Tooltip = " السجل التالي";
            this.btnNxtPage.Click += new System.EventHandler(this.btnNxtPage_Click);
            // 
            // buttonItem_BestSeller
            // 
            this.buttonItem_BestSeller.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem_BestSeller.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonItem_BestSeller.FontBold = true;
            this.buttonItem_BestSeller.FontItalic = true;
            this.buttonItem_BestSeller.ForeColor = System.Drawing.Color.SaddleBrown;
            this.buttonItem_BestSeller.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem_BestSeller.Image")));
            this.buttonItem_BestSeller.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.buttonItem_BestSeller.ImagePaddingHorizontal = 12;
            this.buttonItem_BestSeller.ImagePaddingVertical = 11;
            this.buttonItem_BestSeller.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem_BestSeller.Name = "buttonItem_BestSeller";
            this.buttonItem_BestSeller.Stretch = true;
            this.buttonItem_BestSeller.SubItemsExpandWidth = 14;
            this.buttonItem_BestSeller.Symbol = "";
            this.buttonItem_BestSeller.SymbolSize = 15F;
            this.buttonItem_BestSeller.Click += new System.EventHandler(this.buttonItem_BestSeller_Click);
            // 
            // Label_Count
            // 
            this.Label_Count.Name = "Label_Count";
            this.Label_Count.Visible = false;
            this.Label_Count.Width = 40;
            // 
            // groupPanel_BoardNo
            // 
            this.groupPanel_BoardNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupPanel_BoardNo.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel_BoardNo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel_BoardNo.Controls.Add(this.button_DeleteLine);
            this.groupPanel_BoardNo.Controls.Add(this.button_Space);
            this.groupPanel_BoardNo.Controls.Add(this.button_0);
            this.groupPanel_BoardNo.Controls.Add(this.button_2);
            this.groupPanel_BoardNo.Controls.Add(this.button_1);
            this.groupPanel_BoardNo.Controls.Add(this.button_6);
            this.groupPanel_BoardNo.Controls.Add(this.button_5);
            this.groupPanel_BoardNo.Controls.Add(this.button_8);
            this.groupPanel_BoardNo.Controls.Add(this.button_7);
            this.groupPanel_BoardNo.Controls.Add(this.button_Bac);
            this.groupPanel_BoardNo.Controls.Add(this.button_3);
            this.groupPanel_BoardNo.Controls.Add(this.button_4);
            this.groupPanel_BoardNo.Controls.Add(this.button_9);
            this.groupPanel_BoardNo.Location = new System.Drawing.Point(1, 97);
            this.groupPanel_BoardNo.Name = "groupPanel_BoardNo";
            this.groupPanel_BoardNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupPanel_BoardNo.Size = new System.Drawing.Size(94, 343);
            // 
            // 
            // 
            this.groupPanel_BoardNo.Style.BackColorGradientAngle = 90;
            this.groupPanel_BoardNo.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_BoardNo.Style.BorderBottomWidth = 1;
            this.groupPanel_BoardNo.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel_BoardNo.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_BoardNo.Style.BorderLeftWidth = 1;
            this.groupPanel_BoardNo.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_BoardNo.Style.BorderRightWidth = 1;
            this.groupPanel_BoardNo.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_BoardNo.Style.BorderTopWidth = 1;
            this.groupPanel_BoardNo.Style.CornerDiameter = 4;
            this.groupPanel_BoardNo.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel_BoardNo.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel_BoardNo.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel_BoardNo.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel_BoardNo.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel_BoardNo.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel_BoardNo.TabIndex = 1180;
            // 
            // button_DeleteLine
            // 
            this.button_DeleteLine.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_DeleteLine.Checked = true;
            this.button_DeleteLine.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.button_DeleteLine.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button_DeleteLine.Location = new System.Drawing.Point(0, 253);
            this.button_DeleteLine.Name = "button_DeleteLine";
            this.button_DeleteLine.Size = new System.Drawing.Size(88, 79);
            this.button_DeleteLine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_DeleteLine.TabIndex = 14;
            this.button_DeleteLine.Text = "حذف السطر";
            this.button_DeleteLine.Visible = false;
            this.button_DeleteLine.Click += new System.EventHandler(this.button_DeleteLine_Click);
            // 
            // button_Space
            // 
            this.button_Space.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_Space.Checked = true;
            this.button_Space.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.button_Space.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button_Space.Location = new System.Drawing.Point(0, 211);
            this.button_Space.Name = "button_Space";
            this.button_Space.Size = new System.Drawing.Size(44, 41);
            this.button_Space.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_Space.TabIndex = 13;
            this.button_Space.Text = "Space";
            this.button_Space.Click += new System.EventHandler(this.button_Space_Click);
            // 
            // button_9
            // 
            this.button_9.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_9.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.button_9.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_9.Location = new System.Drawing.Point(44, 168);
            this.button_9.Name = "button_9";
            this.button_9.Size = new System.Drawing.Size(44, 41);
            this.button_9.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_9.TabIndex = 5;
            this.button_9.Text = "9";
            this.button_9.Click += new System.EventHandler(this.button_9_Click);
            // 
            // txtCustNo
            // 
            this.txtCustNo.BackColor = System.Drawing.Color.White;
            this.txtCustNo.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.txtCustNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtCustNo.Location = new System.Drawing.Point(113, 19);
            this.txtCustNo.MaxLength = 30;
            this.txtCustNo.Name = "txtCustNo";
            this.netResize1.SetResizeTextBoxMultiline(this.txtCustNo, false);
            this.txtCustNo.ReadOnly = true;
            this.txtCustNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCustNo.Size = new System.Drawing.Size(110, 23);
            this.txtCustNo.TabIndex = 1119;
            this.txtCustNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCustNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustNo_KeyPress);
            this.txtCustNo.Leave += new System.EventHandler(this.txtCustNo_Leave);
            // 
            // button_SrchCustNo
            // 
            this.button_SrchCustNo.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.button_SrchCustNo.Checked = true;
            this.button_SrchCustNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCustNo.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.button_SrchCustNo.Location = new System.Drawing.Point(4, 19);
            this.button_SrchCustNo.Name = "button_SrchCustNo";
            this.button_SrchCustNo.Size = new System.Drawing.Size(108, 23);
            this.button_SrchCustNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCustNo.Symbol = "";
            this.button_SrchCustNo.SymbolSize = 12F;
            this.button_SrchCustNo.TabIndex = 1120;
            this.button_SrchCustNo.TextColor = System.Drawing.Color.SteelBlue;
            // 
            // txtCustName
            // 
            this.txtCustName.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.txtCustName.Location = new System.Drawing.Point(3, 43);
            this.txtCustName.Name = "txtCustName";
            this.netResize1.SetResizeTextBoxMultiline(this.txtCustName, false);
            this.txtCustName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCustName.Size = new System.Drawing.Size(220, 23);
            this.txtCustName.TabIndex = 1121;
            this.txtCustName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(223, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 16);
            this.label10.TabIndex = 1123;
            this.label10.Text = "اسم العميـــــل :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(223, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 1122;
            this.label4.Text = "حساب العميــل :";
            // 
            // doubleInput_Rate
            // 
            this.doubleInput_Rate.AllowEmptyState = false;
            // 
            // 
            // 
            this.doubleInput_Rate.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.doubleInput_Rate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.doubleInput_Rate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doubleInput_Rate.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.doubleInput_Rate.DisplayFormat = "0.00";
            this.doubleInput_Rate.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.doubleInput_Rate.Increment = 0D;
            this.doubleInput_Rate.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.doubleInput_Rate.IsInputReadOnly = true;
            this.doubleInput_Rate.Location = new System.Drawing.Point(409, 70);
            this.doubleInput_Rate.Name = "doubleInput_Rate";
            this.doubleInput_Rate.Size = new System.Drawing.Size(45, 23);
            this.doubleInput_Rate.TabIndex = 1116;
            // 
            // txtInvCost
            // 
            this.txtInvCost.AllowEmptyState = false;
            this.txtInvCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.txtInvCost.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtInvCost.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtInvCost.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtInvCost.DisplayFormat = "0.00";
            this.txtInvCost.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtInvCost.Increment = 0D;
            this.txtInvCost.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtInvCost.IsInputReadOnly = true;
            this.txtInvCost.Location = new System.Drawing.Point(508, 642);
            this.txtInvCost.Name = "txtInvCost";
            this.txtInvCost.Size = new System.Drawing.Size(109, 21);
            this.txtInvCost.TabIndex = 1127;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox5.Controls.Add(this.label_Waiter);
            this.groupBox5.Controls.Add(this.textBox_WaiterName);
            this.groupBox5.Controls.Add(this.switchButton_Lock);
            this.groupBox5.Controls.Add(this.FlxStkQty);
            this.groupBox5.Controls.Add(this.button_SrchPriceDefault);
            this.groupBox5.Controls.Add(this.button_SrchCurr);
            this.groupBox5.Controls.Add(this.button_SrchMnd);
            this.groupBox5.Controls.Add(this.button_SrchCenterCost);
            this.groupBox5.Controls.Add(this.txtTime);
            this.groupBox5.Controls.Add(this.txtGDate);
            this.groupBox5.Controls.Add(this.txtHDate);
            this.groupBox5.Controls.Add(this.CmbInvPrice);
            this.groupBox5.Controls.Add(this.FlxDat);
            this.groupBox5.Controls.Add(this.groupPanel_BoardNo);
            this.groupBox5.Controls.Add(this.button_SrchCustNo);
            this.groupBox5.Controls.Add(this.txtCustNo);
            this.groupBox5.Controls.Add(this.txtCustName);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.txtAddress);
            this.groupBox5.Controls.Add(this.FlxInv);
            this.groupBox5.Controls.Add(this.CmbCostC);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.pictureBox_Cash);
            this.groupBox5.Controls.Add(this.pictureBox_NetWord);
            this.groupBox5.Controls.Add(this.pictureBox_Credit);
            this.groupBox5.Controls.Add(this.txtItemName);
            this.groupBox5.Controls.Add(this.groupBox2);
            this.groupBox5.Controls.Add(this.groupBox1);
            this.groupBox5.Controls.Add(this.CmbLegate);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.Label2);
            this.groupBox5.Controls.Add(this.Label1);
            this.groupBox5.Controls.Add(this.doubleInput_Rate);
            this.groupBox5.Controls.Add(this.CmbCurr);
            this.groupBox5.Controls.Add(this.textBox_ID);
            this.groupBox5.Controls.Add(this.superTabControl_Info);
            this.groupBox5.Controls.Add(this.txtTele);
            this.groupBox5.Controls.Add(this.txtRef);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.button_SrchCustADD);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox5.Location = new System.Drawing.Point(306, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(667, 578);
            this.groupBox5.TabIndex = 1148;
            this.groupBox5.TabStop = false;
            // 
            // label_Waiter
            // 
            this.label_Waiter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Waiter.BackColor = System.Drawing.Color.Transparent;
            this.label_Waiter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_Waiter.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label_Waiter.ForeColor = System.Drawing.Color.Navy;
            this.label_Waiter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_Waiter.Location = new System.Drawing.Point(4, 513);
            this.label_Waiter.Name = "label_Waiter";
            this.label_Waiter.Size = new System.Drawing.Size(235, 32);
            this.label_Waiter.TabIndex = 1220;
            this.label_Waiter.Text = "إســــم النــــادل";
            this.label_Waiter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_WaiterName
            // 
            this.textBox_WaiterName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_WaiterName.BackColor = System.Drawing.Color.Yellow;
            this.textBox_WaiterName.Font = new System.Drawing.Font("Tahoma", 11F);
            this.textBox_WaiterName.ForeColor = System.Drawing.Color.Maroon;
            this.textBox_WaiterName.Location = new System.Drawing.Point(4, 547);
            this.textBox_WaiterName.MaxLength = 30;
            this.textBox_WaiterName.Name = "textBox_WaiterName";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_WaiterName, false);
            this.textBox_WaiterName.ReadOnly = true;
            this.textBox_WaiterName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_WaiterName.Size = new System.Drawing.Size(235, 25);
            this.textBox_WaiterName.TabIndex = 1219;
            this.textBox_WaiterName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // switchButton_Lock
            // 
            this.switchButton_Lock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.switchButton_Lock.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_Lock.Font = new System.Drawing.Font("Tahoma", 11F);
            this.switchButton_Lock.Location = new System.Drawing.Point(5, 448);
            this.switchButton_Lock.Name = "switchButton_Lock";
            this.switchButton_Lock.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.switchButton_Lock.OffText = "لم يتم إعتماد الطلب";
            this.switchButton_Lock.OffTextColor = System.Drawing.Color.White;
            this.switchButton_Lock.OnText = "تم إعتماد الطلب";
            this.switchButton_Lock.Size = new System.Drawing.Size(235, 62);
            this.switchButton_Lock.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_Lock.SwitchWidth = 45;
            this.switchButton_Lock.TabIndex = 1218;
            this.switchButton_Lock.ValueChanged += new System.EventHandler(this.switchButton_Lock_ValueChanged);
            this.switchButton_Lock.Click += new System.EventHandler(this.switchButton_Lock_Click);
            // 
            // FlxStkQty
            // 
            this.FlxStkQty.AllowEditing = false;
            this.FlxStkQty.BackColor = System.Drawing.Color.Transparent;
            this.FlxStkQty.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.FlxStkQty.ColumnInfo = resources.GetString("FlxStkQty.ColumnInfo");
            this.FlxStkQty.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.FlxStkQty.Location = new System.Drawing.Point(230, 242);
            this.FlxStkQty.Name = "FlxStkQty";
            this.FlxStkQty.Rows.DefaultSize = 20;
            this.FlxStkQty.Size = new System.Drawing.Size(207, 93);
            this.FlxStkQty.StyleInfo = resources.GetString("FlxStkQty.StyleInfo");
            this.FlxStkQty.TabIndex = 1216;
            this.FlxStkQty.Visible = false;
            this.FlxStkQty.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Black;
            // 
            // button_SrchPriceDefault
            // 
            this.button_SrchPriceDefault.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.button_SrchPriceDefault.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchPriceDefault.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.button_SrchPriceDefault.Location = new System.Drawing.Point(808, 115);
            this.button_SrchPriceDefault.Name = "button_SrchPriceDefault";
            this.button_SrchPriceDefault.Size = new System.Drawing.Size(102, 23);
            this.button_SrchPriceDefault.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchPriceDefault.Symbol = "";
            this.button_SrchPriceDefault.SymbolSize = 12F;
            this.button_SrchPriceDefault.TabIndex = 1201;
            this.button_SrchPriceDefault.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchPriceDefault.Visible = false;
            this.button_SrchPriceDefault.Click += new System.EventHandler(this.button_SrchPriceDefault_Click);
            // 
            // button_SrchCurr
            // 
            this.button_SrchCurr.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.button_SrchCurr.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCurr.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.button_SrchCurr.Location = new System.Drawing.Point(326, 70);
            this.button_SrchCurr.Name = "button_SrchCurr";
            this.button_SrchCurr.Size = new System.Drawing.Size(81, 23);
            this.button_SrchCurr.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCurr.Symbol = "";
            this.button_SrchCurr.SymbolSize = 12F;
            this.button_SrchCurr.TabIndex = 1200;
            this.button_SrchCurr.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCurr.Click += new System.EventHandler(this.button_SrchCurr_Click);
            // 
            // button_SrchMnd
            // 
            this.button_SrchMnd.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.button_SrchMnd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchMnd.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.button_SrchMnd.Location = new System.Drawing.Point(680, 119);
            this.button_SrchMnd.Name = "button_SrchMnd";
            this.button_SrchMnd.Size = new System.Drawing.Size(81, 23);
            this.button_SrchMnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchMnd.Symbol = "";
            this.button_SrchMnd.SymbolSize = 12F;
            this.button_SrchMnd.TabIndex = 1199;
            this.button_SrchMnd.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchMnd.Visible = false;
            this.button_SrchMnd.Click += new System.EventHandler(this.button_SrchMnd_Click);
            // 
            // button_SrchCenterCost
            // 
            this.button_SrchCenterCost.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.button_SrchCenterCost.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCenterCost.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.button_SrchCenterCost.Location = new System.Drawing.Point(731, 94);
            this.button_SrchCenterCost.Name = "button_SrchCenterCost";
            this.button_SrchCenterCost.Size = new System.Drawing.Size(102, 23);
            this.button_SrchCenterCost.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCenterCost.Symbol = "";
            this.button_SrchCenterCost.SymbolSize = 12F;
            this.button_SrchCenterCost.TabIndex = 1198;
            this.button_SrchCenterCost.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCenterCost.Visible = false;
            this.button_SrchCenterCost.Click += new System.EventHandler(this.button_SrchCenterCost_Click);
            // 
            // txtTime
            // 
            this.txtTime.BackColor = System.Drawing.Color.White;
            this.txtTime.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtTime.Location = new System.Drawing.Point(326, 46);
            this.txtTime.Mask = "##:##";
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(69, 21);
            this.txtTime.TabIndex = 1191;
            this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTime.Click += new System.EventHandler(this.txtTime_Click);
            this.txtTime.Enter += new System.EventHandler(this.txtTime_Enter);
            // 
            // txtGDate
            // 
            this.txtGDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtGDate.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtGDate.Location = new System.Drawing.Point(492, 46);
            this.txtGDate.Mask = "0000/00/00";
            this.txtGDate.Name = "txtGDate";
            this.txtGDate.Size = new System.Drawing.Size(94, 21);
            this.txtGDate.TabIndex = 1189;
            this.txtGDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGDate.Click += new System.EventHandler(this.txtGDate_Click);
            this.txtGDate.Enter += new System.EventHandler(this.txtGDate_Enter);
            // 
            // txtHDate
            // 
            this.txtHDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtHDate.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtHDate.Location = new System.Drawing.Point(397, 46);
            this.txtHDate.Mask = "0000/00/00";
            this.txtHDate.Name = "txtHDate";
            this.txtHDate.Size = new System.Drawing.Size(94, 21);
            this.txtHDate.TabIndex = 1190;
            this.txtHDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHDate.Click += new System.EventHandler(this.txtHDate_Click);
            this.txtHDate.Enter += new System.EventHandler(this.txtHDate_Enter);
            // 
            // CmbInvPrice
            // 
            this.CmbInvPrice.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbInvPrice.DisplayMember = "Text";
            this.CmbInvPrice.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbInvPrice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbInvPrice.Enabled = false;
            this.CmbInvPrice.FocusHighlightEnabled = true;
            this.CmbInvPrice.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.CmbInvPrice.FormattingEnabled = true;
            this.CmbInvPrice.ItemHeight = 17;
            this.CmbInvPrice.Location = new System.Drawing.Point(912, 115);
            this.CmbInvPrice.Name = "CmbInvPrice";
            this.CmbInvPrice.Size = new System.Drawing.Size(116, 23);
            this.CmbInvPrice.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbInvPrice.TabIndex = 1102;
            this.CmbInvPrice.Visible = false;
            // 
            // FlxDat
            // 
            this.FlxDat.AllowEditing = false;
            this.FlxDat.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
            this.FlxDat.ColumnInfo = resources.GetString("FlxDat.ColumnInfo");
            this.FlxDat.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FlxDat.Location = new System.Drawing.Point(178, 263);
            this.FlxDat.Name = "FlxDat";
            this.FlxDat.Rows.DefaultSize = 19;
            this.FlxDat.Size = new System.Drawing.Size(229, 113);
            this.FlxDat.StyleInfo = resources.GetString("FlxDat.StyleInfo");
            this.FlxDat.TabIndex = 1182;
            this.FlxDat.Visible = false;
            this.FlxDat.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Black;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(92, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 16);
            this.label12.TabIndex = 1112;
            this.label12.Text = "هاتف :";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.txtAddress.Location = new System.Drawing.Point(141, 69);
            this.txtAddress.MaxLength = 100;
            this.txtAddress.Name = "txtAddress";
            this.netResize1.SetResizeTextBoxMultiline(this.txtAddress, false);
            this.txtAddress.Size = new System.Drawing.Size(82, 23);
            this.txtAddress.TabIndex = 1099;
            // 
            // FlxInv
            // 
            this.FlxInv.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.FlxInv.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            this.FlxInv.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.FlxInv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FlxInv.BackColor = System.Drawing.Color.White;
            this.FlxInv.ColumnInfo = resources.GetString("FlxInv.ColumnInfo");
            this.FlxInv.ExtendLastCol = true;
            this.FlxInv.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FlxInv.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.FlxInv.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.FlxInv.Location = new System.Drawing.Point(97, 97);
            this.FlxInv.Name = "FlxInv";
            this.FlxInv.Rows.Count = 1;
            this.FlxInv.Rows.DefaultSize = 19;
            this.FlxInv.Rows.MinSize = 36;
            this.FlxInv.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
            this.FlxInv.Size = new System.Drawing.Size(565, 343);
            this.FlxInv.StyleInfo = resources.GetString("FlxInv.StyleInfo");
            this.FlxInv.TabIndex = 1103;
            this.FlxInv.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System;
            this.FlxInv.AfterSelChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.FlxInv_AfterSelChange);
            this.FlxInv.LeaveCell += new System.EventHandler(this.FlxInv_LeaveCell);
            this.FlxInv.Leave += new System.EventHandler(this.FlxInv_Leave);
            // 
            // CmbCostC
            // 
            this.CmbCostC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbCostC.DisplayMember = "Text";
            this.CmbCostC.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CmbCostC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCostC.Enabled = false;
            this.CmbCostC.FocusHighlightEnabled = true;
            this.CmbCostC.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.CmbCostC.FormattingEnabled = true;
            this.CmbCostC.ItemHeight = 17;
            this.CmbCostC.Location = new System.Drawing.Point(835, 94);
            this.CmbCostC.Name = "CmbCostC";
            this.CmbCostC.Size = new System.Drawing.Size(116, 23);
            this.CmbCostC.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbCostC.TabIndex = 1101;
            this.CmbCostC.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(1028, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 16);
            this.label5.TabIndex = 1113;
            this.label5.Text = "السعر المعتمــد :";
            this.label5.Visible = false;
            // 
            // pictureBox_Cash
            // 
            this.pictureBox_Cash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox_Cash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Cash.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Cash.Image")));
            this.pictureBox_Cash.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox_Cash.Location = new System.Drawing.Point(744, 491);
            this.pictureBox_Cash.Name = "pictureBox_Cash";
            this.pictureBox_Cash.Size = new System.Drawing.Size(258, 81);
            this.pictureBox_Cash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Cash.TabIndex = 1178;
            this.pictureBox_Cash.TabStop = false;
            // 
            // pictureBox_NetWord
            // 
            this.pictureBox_NetWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox_NetWord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_NetWord.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_NetWord.Image")));
            this.pictureBox_NetWord.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox_NetWord.Location = new System.Drawing.Point(744, 491);
            this.pictureBox_NetWord.Name = "pictureBox_NetWord";
            this.pictureBox_NetWord.Size = new System.Drawing.Size(258, 81);
            this.pictureBox_NetWord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_NetWord.TabIndex = 1179;
            this.pictureBox_NetWord.TabStop = false;
            this.pictureBox_NetWord.Visible = false;
            // 
            // pictureBox_Credit
            // 
            this.pictureBox_Credit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox_Credit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Credit.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Credit.Image")));
            this.pictureBox_Credit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox_Credit.Location = new System.Drawing.Point(744, 491);
            this.pictureBox_Credit.Name = "pictureBox_Credit";
            this.pictureBox_Credit.Size = new System.Drawing.Size(258, 81);
            this.pictureBox_Credit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Credit.TabIndex = 1114;
            this.pictureBox_Credit.TabStop = false;
            this.pictureBox_Credit.Visible = false;
            // 
            // txtItemName
            // 
            this.txtItemName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(217)))), ((int)(((byte)(243)))));
            this.txtItemName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtItemName.Location = new System.Drawing.Point(130, 305);
            this.txtItemName.Name = "txtItemName";
            this.netResize1.SetResizeTextBoxMultiline(this.txtItemName, false);
            this.txtItemName.ReadOnly = true;
            this.txtItemName.Size = new System.Drawing.Size(374, 13);
            this.txtItemName.TabIndex = 1183;
            this.txtItemName.Visible = false;
            // 
            // CmbLegate
            // 
            this.CmbLegate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbLegate.DisplayMember = "Text";
            this.CmbLegate.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbLegate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbLegate.Enabled = false;
            this.CmbLegate.FocusHighlightEnabled = true;
            this.CmbLegate.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.CmbLegate.FormattingEnabled = true;
            this.CmbLegate.ItemHeight = 17;
            this.CmbLegate.Location = new System.Drawing.Point(763, 119);
            this.CmbLegate.Name = "CmbLegate";
            this.CmbLegate.Size = new System.Drawing.Size(177, 23);
            this.CmbLegate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbLegate.TabIndex = 1098;
            this.CmbLegate.Visible = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label19.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label19.Location = new System.Drawing.Point(588, 73);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 16);
            this.label19.TabIndex = 1110;
            this.label19.Text = "العملــــــــة :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label18.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(942, 123);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(75, 16);
            this.label18.TabIndex = 1109;
            this.label18.Text = "المنـــــدوب :";
            this.label18.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(955, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 16);
            this.label7.TabIndex = 1106;
            this.label7.Text = "رقم المرجع :";
            this.label7.Visible = false;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Label2.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label2.Location = new System.Drawing.Point(588, 49);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(75, 16);
            this.Label2.TabIndex = 1105;
            this.Label2.Text = "التاريــــــــخ :";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Label1.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label1.Location = new System.Drawing.Point(588, 25);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(73, 16);
            this.Label1.TabIndex = 1104;
            this.Label1.Text = "رقم الطلب :";
            // 
            // CmbCurr
            // 
            this.CmbCurr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbCurr.DisplayMember = "Text";
            this.CmbCurr.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbCurr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCurr.Enabled = false;
            this.CmbCurr.FocusHighlightEnabled = true;
            this.CmbCurr.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.CmbCurr.FormattingEnabled = true;
            this.CmbCurr.ItemHeight = 17;
            this.CmbCurr.Location = new System.Drawing.Point(456, 70);
            this.CmbCurr.Name = "CmbCurr";
            this.CmbCurr.Size = new System.Drawing.Size(130, 23);
            this.CmbCurr.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbCurr.TabIndex = 1097;
            // 
            // textBox_ID
            // 
            this.textBox_ID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.textBox_ID.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.textBox_ID.Location = new System.Drawing.Point(502, 21);
            this.textBox_ID.Name = "textBox_ID";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_ID, false);
            this.textBox_ID.ReadOnly = true;
            this.textBox_ID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_ID.Size = new System.Drawing.Size(84, 23);
            this.textBox_ID.TabIndex = 1093;
            // 
            // superTabControl_Info
            // 
            this.superTabControl_Info.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.superTabControl_Info.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.superTabControl_Info.ControlBox.Category = null;
            // 
            // 
            // 
            this.superTabControl_Info.ControlBox.CloseBox.Category = null;
            this.superTabControl_Info.ControlBox.CloseBox.Description = null;
            this.superTabControl_Info.ControlBox.CloseBox.Name = "";
            this.superTabControl_Info.ControlBox.CloseBox.Tag = null;
            this.superTabControl_Info.ControlBox.Description = null;
            // 
            // 
            // 
            this.superTabControl_Info.ControlBox.MenuBox.Category = null;
            this.superTabControl_Info.ControlBox.MenuBox.Description = null;
            this.superTabControl_Info.ControlBox.MenuBox.Name = "";
            this.superTabControl_Info.ControlBox.MenuBox.Tag = null;
            this.superTabControl_Info.ControlBox.Name = "";
            this.superTabControl_Info.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl_Info.ControlBox.MenuBox,
            this.superTabControl_Info.ControlBox.CloseBox});
            this.superTabControl_Info.ControlBox.Tag = null;
            this.superTabControl_Info.ControlBox.Visible = false;
            this.superTabControl_Info.Controls.Add(this.superTabControlPanel4);
            this.superTabControl_Info.Controls.Add(this.superTabControlPanel5);
            this.superTabControl_Info.Controls.Add(this.superTabControlPanel1);
            this.superTabControl_Info.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.superTabControl_Info.ForeColor = System.Drawing.Color.Black;
            this.superTabControl_Info.Location = new System.Drawing.Point(246, 446);
            this.superTabControl_Info.Name = "superTabControl_Info";
            this.superTabControl_Info.ReorderTabsEnabled = true;
            this.superTabControl_Info.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.superTabControl_Info.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_Info.SelectedTabIndex = 0;
            this.superTabControl_Info.Size = new System.Drawing.Size(416, 126);
            this.superTabControl_Info.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Bottom;
            this.superTabControl_Info.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_Info.TabHorizontalSpacing = 11;
            this.superTabControl_Info.TabIndex = 1181;
            this.superTabControl_Info.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.SingleLineFit;
            this.superTabControl_Info.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem_Note,
            this.superTabItem_Pay,
            this.superTabItem_Gaids,
            this.checkBoxItem_BarCode});
            this.superTabControl_Info.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.VisualStudio2008Document;
            this.superTabControl_Info.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            // 
            // superTabControlPanel4
            // 
            this.superTabControlPanel4.Controls.Add(this.txtRemark);
            this.superTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel4.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel4.Name = "superTabControlPanel4";
            this.superTabControlPanel4.Size = new System.Drawing.Size(416, 101);
            this.superTabControlPanel4.TabIndex = 2;
            this.superTabControlPanel4.TabItem = this.superTabItem_Note;
            // 
            // txtRemark
            // 
            this.txtRemark.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtRemark.Border.Class = "TextBoxBorder";
            this.txtRemark.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRemark.ButtonCustom.Visible = true;
            this.txtRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemark.ForeColor = System.Drawing.Color.Black;
            this.txtRemark.Location = new System.Drawing.Point(0, 0);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(416, 101);
            this.txtRemark.TabIndex = 480;
            this.txtRemark.WatermarkText = "ملاحظات الفاتورة";
            this.txtRemark.Enter += new System.EventHandler(this.txtRemark_Enter);
            // 
            // superTabItem_Note
            // 
            this.superTabItem_Note.AttachedControl = this.superTabControlPanel4;
            this.superTabItem_Note.GlobalItem = false;
            this.superTabItem_Note.Name = "superTabItem_Note";
            this.superTabItem_Note.Text = "ملاحظة";
            // 
            // superTabControlPanel5
            // 
            this.superTabControlPanel5.Controls.Add(this.superTabControl_CostSts);
            this.superTabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel5.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel5.Name = "superTabControlPanel5";
            this.superTabControlPanel5.Size = new System.Drawing.Size(416, 101);
            this.superTabControlPanel5.TabIndex = 7;
            this.superTabControlPanel5.TabItem = this.superTabItem_Gaids;
            // 
            // superTabControl_CostSts
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl_CostSts.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl_CostSts.ControlBox.MenuBox.Name = "";
            this.superTabControl_CostSts.ControlBox.Name = "";
            this.superTabControl_CostSts.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl_CostSts.ControlBox.MenuBox,
            this.superTabControl_CostSts.ControlBox.CloseBox});
            this.superTabControl_CostSts.ControlBox.Visible = false;
            this.superTabControl_CostSts.Controls.Add(this.superTabControlPanel6);
            this.superTabControl_CostSts.Controls.Add(this.superTabControlPanel8);
            this.superTabControl_CostSts.Controls.Add(this.superTabControlPanel7);
            this.superTabControl_CostSts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl_CostSts.Location = new System.Drawing.Point(0, 0);
            this.superTabControl_CostSts.Name = "superTabControl_CostSts";
            this.superTabControl_CostSts.ReorderTabsEnabled = true;
            this.superTabControl_CostSts.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_CostSts.SelectedTabIndex = 0;
            this.superTabControl_CostSts.Size = new System.Drawing.Size(416, 101);
            this.superTabControl_CostSts.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_CostSts.TabIndex = 1024;
            this.superTabControl_CostSts.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem_Tax,
            this.switchButton_TaxLines,
            this.switchButton_TaxByTotal,
            this.switchButton_TaxByNet,
            this.textBoxItem_TaxByNetValue,
            this.labelItem_TaxByNetPer});
            this.superTabControl_CostSts.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.superTabControl_CostSts.Text = "superTabControl3";
            // 
            // superTabControlPanel6
            // 
            this.superTabControlPanel6.Controls.Add(this.checkBox_CostGaidTax);
            this.superTabControlPanel6.Controls.Add(this.switchButton_Tax);
            this.superTabControlPanel6.Controls.Add(this.label34);
            this.superTabControlPanel6.Controls.Add(this.label37);
            this.superTabControlPanel6.Controls.Add(this.txtTotTax);
            this.superTabControlPanel6.Controls.Add(this.txtTotTaxLoc);
            this.superTabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel6.Location = new System.Drawing.Point(0, 24);
            this.superTabControlPanel6.Name = "superTabControlPanel6";
            this.superTabControlPanel6.Size = new System.Drawing.Size(416, 77);
            this.superTabControlPanel6.TabIndex = 1;
            this.superTabControlPanel6.TabItem = this.superTabItem_Tax;
            // 
            // checkBox_CostGaidTax
            // 
            this.checkBox_CostGaidTax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_CostGaidTax.AutoSize = true;
            this.checkBox_CostGaidTax.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBox_CostGaidTax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_CostGaidTax.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            this.checkBox_CostGaidTax.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            this.checkBox_CostGaidTax.CheckSignSize = new System.Drawing.Size(14, 14);
            this.checkBox_CostGaidTax.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.checkBox_CostGaidTax.Location = new System.Drawing.Point(49, 43);
            this.checkBox_CostGaidTax.Name = "checkBox_CostGaidTax";
            this.checkBox_CostGaidTax.Size = new System.Drawing.Size(97, 16);
            this.checkBox_CostGaidTax.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_CostGaidTax.TabIndex = 1153;
            this.checkBox_CostGaidTax.Text = "سند محاسبي";
            this.checkBox_CostGaidTax.CheckedChanged += new System.EventHandler(this.checkBox_CostGaidTax_CheckedChanged);
            // 
            // switchButton_Tax
            // 
            this.switchButton_Tax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.switchButton_Tax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_Tax.Font = new System.Drawing.Font("Tahoma", 7F);
            this.switchButton_Tax.Location = new System.Drawing.Point(5, 19);
            this.switchButton_Tax.Name = "switchButton_Tax";
            this.switchButton_Tax.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.switchButton_Tax.OffText = "غير معتمد";
            this.switchButton_Tax.OffTextColor = System.Drawing.Color.White;
            this.switchButton_Tax.OnText = "معتمد";
            this.switchButton_Tax.Size = new System.Drawing.Size(147, 21);
            this.switchButton_Tax.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_Tax.TabIndex = 1152;
            this.switchButton_Tax.Value = true;
            this.switchButton_Tax.ValueObject = "Y";
            this.switchButton_Tax.ValueChanged += new System.EventHandler(this.switchButton_Tax_ValueChanged);
            // 
            // label34
            // 
            this.label34.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.label34.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label34.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label34.ForeColor = System.Drawing.Color.Navy;
            this.label34.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label34.Location = new System.Drawing.Point(284, 19);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(127, 21);
            this.label34.TabIndex = 1151;
            this.label34.Text = "الإجمالي";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label37
            // 
            this.label37.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label37.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label37.ForeColor = System.Drawing.Color.White;
            this.label37.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label37.Location = new System.Drawing.Point(155, 19);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(127, 21);
            this.label37.TabIndex = 1143;
            this.label37.Text = "بالريــــال";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotTax
            // 
            this.txtTotTax.AllowEmptyState = false;
            this.txtTotTax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTotTax.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotTax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotTax.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotTax.DisplayFormat = "0.00";
            this.txtTotTax.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotTax.Increment = 0D;
            this.txtTotTax.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTotTax.IsInputReadOnly = true;
            this.txtTotTax.Location = new System.Drawing.Point(284, 42);
            this.txtTotTax.MinValue = 0D;
            this.txtTotTax.Name = "txtTotTax";
            this.txtTotTax.Size = new System.Drawing.Size(127, 21);
            this.txtTotTax.TabIndex = 1141;
            // 
            // txtTotTaxLoc
            // 
            this.txtTotTaxLoc.AllowEmptyState = false;
            this.txtTotTaxLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTotTaxLoc.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.txtTotTaxLoc.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotTaxLoc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotTaxLoc.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotTaxLoc.DisplayFormat = "0.00";
            this.txtTotTaxLoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotTaxLoc.Increment = 0D;
            this.txtTotTaxLoc.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTotTaxLoc.IsInputReadOnly = true;
            this.txtTotTaxLoc.Location = new System.Drawing.Point(155, 42);
            this.txtTotTaxLoc.MinValue = 0D;
            this.txtTotTaxLoc.Name = "txtTotTaxLoc";
            this.txtTotTaxLoc.Size = new System.Drawing.Size(127, 21);
            this.txtTotTaxLoc.TabIndex = 1142;
            // 
            // superTabItem_Tax
            // 
            this.superTabItem_Tax.AttachedControl = this.superTabControlPanel6;
            this.superTabItem_Tax.GlobalItem = false;
            this.superTabItem_Tax.Name = "superTabItem_Tax";
            this.superTabItem_Tax.Text = "ضريبة";
            // 
            // superTabControlPanel8
            // 
            this.superTabControlPanel8.Controls.Add(this.label42);
            this.superTabControlPanel8.Controls.Add(this.txtCredit7);
            this.superTabControlPanel8.Controls.Add(this.checkBox_GaidBankComm);
            this.superTabControlPanel8.Controls.Add(this.switchButton_BankComm);
            this.superTabControlPanel8.Controls.Add(this.label48);
            this.superTabControlPanel8.Controls.Add(this.label49);
            this.superTabControlPanel8.Controls.Add(this.txtTotBankComm);
            this.superTabControlPanel8.Controls.Add(this.txtTotBankCommLoc);
            this.superTabControlPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel8.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel8.Name = "superTabControlPanel8";
            this.superTabControlPanel8.Size = new System.Drawing.Size(416, 101);
            this.superTabControlPanel8.TabIndex = 3;
            // 
            // label42
            // 
            this.label42.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label42.AutoSize = true;
            this.label42.BackColor = System.Drawing.Color.Transparent;
            this.label42.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label42.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label42.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label42.Location = new System.Drawing.Point(244, 45);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(40, 13);
            this.label42.TabIndex = 1162;
            this.label42.Text = "الدائن :";
            // 
            // txtCredit7
            // 
            this.txtCredit7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCredit7.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtCredit7.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCredit7.ButtonCustom.Visible = true;
            this.txtCredit7.Enabled = false;
            this.txtCredit7.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtCredit7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCredit7.Location = new System.Drawing.Point(130, 44);
            this.txtCredit7.Name = "txtCredit7";
            this.txtCredit7.ReadOnly = true;
            this.txtCredit7.Size = new System.Drawing.Size(113, 14);
            this.txtCredit7.TabIndex = 1159;
            this.txtCredit7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkBox_GaidBankComm
            // 
            this.checkBox_GaidBankComm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_GaidBankComm.AutoSize = true;
            this.checkBox_GaidBankComm.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBox_GaidBankComm.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_GaidBankComm.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            this.checkBox_GaidBankComm.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            this.checkBox_GaidBankComm.CheckSignSize = new System.Drawing.Size(14, 14);
            this.checkBox_GaidBankComm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.checkBox_GaidBankComm.Location = new System.Drawing.Point(-93, 43);
            this.checkBox_GaidBankComm.Name = "checkBox_GaidBankComm";
            this.checkBox_GaidBankComm.Size = new System.Drawing.Size(97, 16);
            this.checkBox_GaidBankComm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_GaidBankComm.TabIndex = 1156;
            this.checkBox_GaidBankComm.Text = "سند محاسبي";
            // 
            // switchButton_BankComm
            // 
            this.switchButton_BankComm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.switchButton_BankComm.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_BankComm.Font = new System.Drawing.Font("Tahoma", 8F);
            this.switchButton_BankComm.Location = new System.Drawing.Point(6, 18);
            this.switchButton_BankComm.Name = "switchButton_BankComm";
            this.switchButton_BankComm.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.switchButton_BankComm.OffText = "عدم احتساب";
            this.switchButton_BankComm.OffTextColor = System.Drawing.Color.White;
            this.switchButton_BankComm.OnText = "احتساب";
            this.switchButton_BankComm.Size = new System.Drawing.Size(104, 21);
            this.switchButton_BankComm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_BankComm.SwitchWidth = 20;
            this.switchButton_BankComm.TabIndex = 1165;
            // 
            // label48
            // 
            this.label48.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label48.BackColor = System.Drawing.Color.Transparent;
            this.label48.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label48.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label48.ForeColor = System.Drawing.Color.Navy;
            this.label48.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label48.Location = new System.Drawing.Point(351, 18);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(60, 21);
            this.label48.TabIndex = 1163;
            this.label48.Text = "إجمالي القيمة";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label49
            // 
            this.label49.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label49.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label49.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label49.ForeColor = System.Drawing.Color.White;
            this.label49.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label49.Location = new System.Drawing.Point(288, 18);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(60, 21);
            this.label49.TabIndex = 1155;
            this.label49.Text = "بالريــــال";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotBankComm
            // 
            this.txtTotBankComm.AllowEmptyState = false;
            this.txtTotBankComm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTotBankComm.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotBankComm.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotBankComm.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotBankComm.DisplayFormat = "0.00";
            this.txtTotBankComm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotBankComm.Increment = 0D;
            this.txtTotBankComm.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTotBankComm.IsInputReadOnly = true;
            this.txtTotBankComm.Location = new System.Drawing.Point(351, 41);
            this.txtTotBankComm.MinValue = 0D;
            this.txtTotBankComm.Name = "txtTotBankComm";
            this.txtTotBankComm.Size = new System.Drawing.Size(60, 21);
            this.txtTotBankComm.TabIndex = 1153;
            // 
            // txtTotBankCommLoc
            // 
            this.txtTotBankCommLoc.AllowEmptyState = false;
            this.txtTotBankCommLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTotBankCommLoc.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.txtTotBankCommLoc.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotBankCommLoc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotBankCommLoc.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotBankCommLoc.DisplayFormat = "0.00";
            this.txtTotBankCommLoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotBankCommLoc.Increment = 0D;
            this.txtTotBankCommLoc.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTotBankCommLoc.IsInputReadOnly = true;
            this.txtTotBankCommLoc.Location = new System.Drawing.Point(288, 41);
            this.txtTotBankCommLoc.MinValue = 0D;
            this.txtTotBankCommLoc.Name = "txtTotBankCommLoc";
            this.txtTotBankCommLoc.Size = new System.Drawing.Size(60, 21);
            this.txtTotBankCommLoc.TabIndex = 1154;
            // 
            // superTabControlPanel7
            // 
            this.superTabControlPanel7.Controls.Add(this.label39);
            this.superTabControlPanel7.Controls.Add(this.label40);
            this.superTabControlPanel7.Controls.Add(this.txtCredit6);
            this.superTabControlPanel7.Controls.Add(this.txtDebit6);
            this.superTabControlPanel7.Controls.Add(this.checkBox_GaidDis);
            this.superTabControlPanel7.Controls.Add(this.label38);
            this.superTabControlPanel7.Controls.Add(this.label41);
            this.superTabControlPanel7.Controls.Add(this.txtTotDis);
            this.superTabControlPanel7.Controls.Add(this.txtTotDisLoc);
            this.superTabControlPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel7.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel7.Name = "superTabControlPanel7";
            this.superTabControlPanel7.Size = new System.Drawing.Size(416, 101);
            this.superTabControlPanel7.TabIndex = 0;
            // 
            // label39
            // 
            this.label39.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label39.AutoSize = true;
            this.label39.BackColor = System.Drawing.Color.Transparent;
            this.label39.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label39.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label39.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label39.Location = new System.Drawing.Point(230, 44);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(55, 13);
            this.label39.TabIndex = 1162;
            this.label39.Text = "الدائـــــن :";
            // 
            // label40
            // 
            this.label40.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label40.AutoSize = true;
            this.label40.BackColor = System.Drawing.Color.Transparent;
            this.label40.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label40.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label40.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label40.Location = new System.Drawing.Point(230, 21);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(53, 13);
            this.label40.TabIndex = 1161;
            this.label40.Text = "المـــدين :";
            // 
            // txtCredit6
            // 
            this.txtCredit6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCredit6.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtCredit6.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCredit6.ButtonCustom.Visible = true;
            this.txtCredit6.Enabled = false;
            this.txtCredit6.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtCredit6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCredit6.Location = new System.Drawing.Point(116, 43);
            this.txtCredit6.Name = "txtCredit6";
            this.txtCredit6.ReadOnly = true;
            this.txtCredit6.Size = new System.Drawing.Size(113, 14);
            this.txtCredit6.TabIndex = 1159;
            this.txtCredit6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDebit6
            // 
            this.txtDebit6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDebit6.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtDebit6.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDebit6.ButtonCustom.Visible = true;
            this.txtDebit6.Enabled = false;
            this.txtDebit6.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtDebit6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDebit6.Location = new System.Drawing.Point(116, 20);
            this.txtDebit6.Name = "txtDebit6";
            this.txtDebit6.ReadOnly = true;
            this.txtDebit6.Size = new System.Drawing.Size(113, 14);
            this.txtDebit6.TabIndex = 1157;
            this.txtDebit6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkBox_GaidDis
            // 
            this.checkBox_GaidDis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_GaidDis.AutoSize = true;
            this.checkBox_GaidDis.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBox_GaidDis.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_GaidDis.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            this.checkBox_GaidDis.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            this.checkBox_GaidDis.CheckSignSize = new System.Drawing.Size(14, 14);
            this.checkBox_GaidDis.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.checkBox_GaidDis.Location = new System.Drawing.Point(-92, 42);
            this.checkBox_GaidDis.Name = "checkBox_GaidDis";
            this.checkBox_GaidDis.Size = new System.Drawing.Size(97, 16);
            this.checkBox_GaidDis.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_GaidDis.TabIndex = 1156;
            this.checkBox_GaidDis.Text = "سند محاسبي";
            // 
            // label38
            // 
            this.label38.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label38.BackColor = System.Drawing.Color.Transparent;
            this.label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label38.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label38.ForeColor = System.Drawing.Color.Navy;
            this.label38.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label38.Location = new System.Drawing.Point(352, 17);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(60, 21);
            this.label38.TabIndex = 1163;
            this.label38.Text = "إجمالي القيمة";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label41
            // 
            this.label41.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label41.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label41.ForeColor = System.Drawing.Color.White;
            this.label41.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label41.Location = new System.Drawing.Point(290, 17);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(60, 21);
            this.label41.TabIndex = 1155;
            this.label41.Text = "بالريــــال";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotDis
            // 
            this.txtTotDis.AllowEmptyState = false;
            this.txtTotDis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTotDis.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotDis.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotDis.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotDis.DisplayFormat = "0.00";
            this.txtTotDis.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotDis.Increment = 0D;
            this.txtTotDis.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTotDis.IsInputReadOnly = true;
            this.txtTotDis.Location = new System.Drawing.Point(352, 40);
            this.txtTotDis.MinValue = 0D;
            this.txtTotDis.Name = "txtTotDis";
            this.txtTotDis.Size = new System.Drawing.Size(60, 21);
            this.txtTotDis.TabIndex = 1153;
            // 
            // txtTotDisLoc
            // 
            this.txtTotDisLoc.AllowEmptyState = false;
            this.txtTotDisLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTotDisLoc.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.txtTotDisLoc.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotDisLoc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotDisLoc.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotDisLoc.DisplayFormat = "0.00";
            this.txtTotDisLoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotDisLoc.Increment = 0D;
            this.txtTotDisLoc.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTotDisLoc.IsInputReadOnly = true;
            this.txtTotDisLoc.Location = new System.Drawing.Point(290, 40);
            this.txtTotDisLoc.MinValue = 0D;
            this.txtTotDisLoc.Name = "txtTotDisLoc";
            this.txtTotDisLoc.Size = new System.Drawing.Size(60, 21);
            this.txtTotDisLoc.TabIndex = 1154;
            // 
            // switchButton_TaxLines
            // 
            this.switchButton_TaxLines.ButtonWidth = 29;
            this.switchButton_TaxLines.Name = "switchButton_TaxLines";
            this.switchButton_TaxLines.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.switchButton_TaxLines.OffText = "سطور الضريبة";
            this.switchButton_TaxLines.OffTextColor = System.Drawing.Color.White;
            this.switchButton_TaxLines.OnText = "سطور الضريبة";
            this.switchButton_TaxLines.SwitchWidth = 15;
            this.switchButton_TaxLines.Value = true;
            // 
            // switchButton_TaxByTotal
            // 
            this.switchButton_TaxByTotal.ButtonWidth = 100;
            this.switchButton_TaxByTotal.Name = "switchButton_TaxByTotal";
            this.switchButton_TaxByTotal.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.switchButton_TaxByTotal.OffText = "إجمالي سطر";
            this.switchButton_TaxByTotal.OffTextColor = System.Drawing.Color.White;
            this.switchButton_TaxByTotal.OnText = "إجمالي سطر";
            this.switchButton_TaxByTotal.SwitchWidth = 15;
            // 
            // switchButton_TaxByNet
            // 
            this.switchButton_TaxByNet.ButtonWidth = 60;
            this.switchButton_TaxByNet.Name = "switchButton_TaxByNet";
            this.switchButton_TaxByNet.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.switchButton_TaxByNet.OffText = "صافي";
            this.switchButton_TaxByNet.OffTextColor = System.Drawing.Color.White;
            this.switchButton_TaxByNet.OnText = "صافي";
            this.switchButton_TaxByNet.SwitchWidth = 15;
            // 
            // textBoxItem_TaxByNetValue
            // 
            this.textBoxItem_TaxByNetValue.Name = "textBoxItem_TaxByNetValue";
            this.textBoxItem_TaxByNetValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxItem_TaxByNetValue.TextBoxWidth = 45;
            this.textBoxItem_TaxByNetValue.Visible = false;
            this.textBoxItem_TaxByNetValue.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.textBoxItem_TaxByNetValue.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelItem_TaxByNetPer
            // 
            this.labelItem_TaxByNetPer.Name = "labelItem_TaxByNetPer";
            this.labelItem_TaxByNetPer.Text = "%";
            this.labelItem_TaxByNetPer.Visible = false;
            // 
            // superTabItem_Gaids
            // 
            this.superTabItem_Gaids.AttachedControl = this.superTabControlPanel5;
            this.superTabItem_Gaids.GlobalItem = false;
            this.superTabItem_Gaids.Name = "superTabItem_Gaids";
            this.superTabItem_Gaids.Text = "سندات";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.dataGridView_ItemDet);
            this.superTabControlPanel1.Controls.Add(this.label11);
            this.superTabControlPanel1.Controls.Add(this.doubleInput_CreditLoc);
            this.superTabControlPanel1.Controls.Add(this.txtPaymentLoc);
            this.superTabControlPanel1.Controls.Add(this.label6);
            this.superTabControlPanel1.Controls.Add(this.label14);
            this.superTabControlPanel1.Controls.Add(this.doubleInput_NetWorkLoc);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(416, 101);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.superTabItem_Pay;
            // 
            // dataGridView_ItemDet
            // 
            this.dataGridView_ItemDet.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.dataGridView_ItemDet.AllowEditing = false;
            this.dataGridView_ItemDet.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes;
            this.dataGridView_ItemDet.ColumnInfo = resources.GetString("dataGridView_ItemDet.ColumnInfo");
            this.dataGridView_ItemDet.ExtendLastCol = true;
            this.dataGridView_ItemDet.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.dataGridView_ItemDet.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.dataGridView_ItemDet.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.dataGridView_ItemDet.Location = new System.Drawing.Point(-140, 11);
            this.dataGridView_ItemDet.Name = "dataGridView_ItemDet";
            this.dataGridView_ItemDet.Rows.Count = 13;
            this.dataGridView_ItemDet.Rows.DefaultSize = 20;
            this.dataGridView_ItemDet.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
            this.dataGridView_ItemDet.Size = new System.Drawing.Size(124, 76);
            this.dataGridView_ItemDet.StyleInfo = resources.GetString("dataGridView_ItemDet.StyleInfo");
            this.dataGridView_ItemDet.TabIndex = 1126;
            this.dataGridView_ItemDet.Visible = false;
            this.dataGridView_ItemDet.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System;
            this.dataGridView_ItemDet.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView_ItemDet_MouseDown);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(148, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 27);
            this.label11.TabIndex = 1124;
            this.label11.Text = "آجــــل :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // doubleInput_CreditLoc
            // 
            this.doubleInput_CreditLoc.AllowEmptyState = false;
            // 
            // 
            // 
            this.doubleInput_CreditLoc.BackgroundStyle.Class = "DateTimeInputBackground";
            this.doubleInput_CreditLoc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doubleInput_CreditLoc.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.doubleInput_CreditLoc.DisplayFormat = "0.00";
            this.doubleInput_CreditLoc.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.doubleInput_CreditLoc.Increment = 0D;
            this.doubleInput_CreditLoc.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.doubleInput_CreditLoc.IsInputReadOnly = true;
            this.doubleInput_CreditLoc.Location = new System.Drawing.Point(148, 53);
            this.doubleInput_CreditLoc.MinValue = 0D;
            this.doubleInput_CreditLoc.Name = "doubleInput_CreditLoc";
            this.doubleInput_CreditLoc.Size = new System.Drawing.Size(109, 27);
            this.doubleInput_CreditLoc.TabIndex = 1125;
            // 
            // txtPaymentLoc
            // 
            this.txtPaymentLoc.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtPaymentLoc.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtPaymentLoc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPaymentLoc.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtPaymentLoc.DisplayFormat = "0.00";
            this.txtPaymentLoc.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txtPaymentLoc.Increment = 0D;
            this.txtPaymentLoc.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtPaymentLoc.IsInputReadOnly = true;
            this.txtPaymentLoc.Location = new System.Drawing.Point(259, 53);
            this.txtPaymentLoc.MinValue = 0D;
            this.txtPaymentLoc.Name = "txtPaymentLoc";
            this.txtPaymentLoc.Size = new System.Drawing.Size(109, 27);
            this.txtPaymentLoc.TabIndex = 1089;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(259, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 27);
            this.label6.TabIndex = 1042;
            this.label6.Text = "نقــــداّ :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(37, 25);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 27);
            this.label14.TabIndex = 1046;
            this.label14.Text = "شبكـة :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // doubleInput_NetWorkLoc
            // 
            this.doubleInput_NetWorkLoc.AllowEmptyState = false;
            // 
            // 
            // 
            this.doubleInput_NetWorkLoc.BackgroundStyle.Class = "DateTimeInputBackground";
            this.doubleInput_NetWorkLoc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doubleInput_NetWorkLoc.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.doubleInput_NetWorkLoc.DisplayFormat = "0.00";
            this.doubleInput_NetWorkLoc.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.doubleInput_NetWorkLoc.Increment = 0D;
            this.doubleInput_NetWorkLoc.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.doubleInput_NetWorkLoc.IsInputReadOnly = true;
            this.doubleInput_NetWorkLoc.Location = new System.Drawing.Point(37, 53);
            this.doubleInput_NetWorkLoc.MinValue = 0D;
            this.doubleInput_NetWorkLoc.Name = "doubleInput_NetWorkLoc";
            this.doubleInput_NetWorkLoc.Size = new System.Drawing.Size(109, 27);
            this.doubleInput_NetWorkLoc.TabIndex = 1091;
            // 
            // superTabItem_Pay
            // 
            this.superTabItem_Pay.AttachedControl = this.superTabControlPanel1;
            this.superTabItem_Pay.GlobalItem = false;
            this.superTabItem_Pay.Name = "superTabItem_Pay";
            this.superTabItem_Pay.Text = "الدفع";
            this.superTabItem_Pay.Visible = false;
            // 
            // checkBoxItem_BarCode
            // 
            this.checkBoxItem_BarCode.Name = "checkBoxItem_BarCode";
            this.checkBoxItem_BarCode.Text = "إضافة تلقائية";
            this.checkBoxItem_BarCode.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.checkBoxItem_BarCode.CheckedChanged += new DevComponents.DotNetBar.CheckBoxChangeEventHandler(this.checkBoxItem_BarCode_CheckedChanged);
            // 
            // txtTele
            // 
            // 
            // 
            // 
            this.txtTele.Border.Class = "TextBoxBorder";
            this.txtTele.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTele.ButtonCustom.Text = ".";
            this.txtTele.ButtonCustom.Visible = true;
            this.txtTele.FocusHighlightEnabled = true;
            this.txtTele.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.txtTele.Location = new System.Drawing.Point(3, 69);
            this.txtTele.Name = "txtTele";
            this.txtTele.Size = new System.Drawing.Size(91, 23);
            this.txtTele.TabIndex = 1187;
            this.txtTele.ButtonCustomClick += new System.EventHandler(this.txtTele_ButtonCustomClick);
            this.txtTele.Enter += new System.EventHandler(this.txtTele_Enter);
            // 
            // txtRef
            // 
            // 
            // 
            // 
            this.txtRef.Border.Class = "TextBoxBorder";
            this.txtRef.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRef.ButtonCustom.Checked = true;
            this.txtRef.ButtonCustom.Text = ".";
            this.txtRef.ButtonCustom.Visible = true;
            this.txtRef.FocusHighlightEnabled = true;
            this.txtRef.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.txtRef.Location = new System.Drawing.Point(693, 69);
            this.txtRef.Name = "txtRef";
            this.txtRef.Size = new System.Drawing.Size(261, 23);
            this.txtRef.TabIndex = 1188;
            this.txtRef.Visible = false;
            this.txtRef.ButtonCustomClick += new System.EventHandler(this.txtRef_ButtonCustomClick);
            this.txtRef.Enter += new System.EventHandler(this.txtRef_Enter);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(951, 97);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(97, 16);
            this.label15.TabIndex = 1107;
            this.label15.Text = "مركز التكلفـــــة :";
            this.label15.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(223, 73);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 16);
            this.label13.TabIndex = 1111;
            this.label13.Text = "عنوان العميـــل :";
            // 
            // button_SrchCustADD
            // 
            this.button_SrchCustADD.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.button_SrchCustADD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCustADD.Location = new System.Drawing.Point(3, 19);
            this.button_SrchCustADD.Name = "button_SrchCustADD";
            this.button_SrchCustADD.Size = new System.Drawing.Size(42, 23);
            this.button_SrchCustADD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCustADD.Symbol = "";
            this.button_SrchCustADD.SymbolSize = 12F;
            this.button_SrchCustADD.TabIndex = 1215;
            this.button_SrchCustADD.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCustADD.Tooltip = "إضافة عميل";
            this.button_SrchCustADD.Visible = false;
            this.button_SrchCustADD.Click += new System.EventHandler(this.button_SrchCustADD_Click);
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
            this.DGV_Main.Size = new System.Drawing.Size(973, 618);
            this.DGV_Main.TabIndex = 862;
            // 
            // panelEx3
            // 
            this.panelEx3.Controls.Add(this.DGV_Main);
            this.panelEx3.Controls.Add(this.ribbonBar_DGV);
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx3.Location = new System.Drawing.Point(0, 0);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(973, 669);
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
            this.ribbonBar_DGV.Location = new System.Drawing.Point(0, 618);
            this.ribbonBar_DGV.Name = "ribbonBar_DGV";
            this.ribbonBar_DGV.Size = new System.Drawing.Size(973, 51);
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
            this.superTabControl_DGV.Size = new System.Drawing.Size(973, 51);
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
            this.Button_ExportTable2.Symbol = "";
            this.Button_ExportTable2.SymbolSize = 15F;
            this.Button_ExportTable2.Text = "تصدير";
            this.Button_ExportTable2.Tooltip = "تصدير الى الأكسيل";
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
            this.Button_PrintTable.Symbol = "";
            this.Button_PrintTable.SymbolSize = 15F;
            this.Button_PrintTable.Text = "طباعة";
            this.Button_PrintTable.Tooltip = "طباعة";
            // 
            // labelItem3
            // 
            this.labelItem3.Name = "labelItem3";
            this.labelItem3.Width = 40;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.expandableSplitter1);
            this.panel1.Controls.Add(this.panelEx2);
            this.panel1.Controls.Add(this.panelEx3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(973, 669);
            this.panel1.TabIndex = 915;
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor = System.Drawing.Color.Black;
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            this.expandableSplitter1.Dock = System.Windows.Forms.DockStyle.Top;
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
            this.expandableSplitter1.Location = new System.Drawing.Point(0, 0);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(973, 14);
            this.expandableSplitter1.TabIndex = 1;
            this.expandableSplitter1.TabStop = false;
            this.expandableSplitter1.Visible = false;
            // 
            // panelEx2
            // 
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar_Tasks);
            this.superTabControl_Main1.RightToLeftChanged += new System.EventHandler(this.superTabControl_Main1_RightToLeftChanged);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(0, 0);
            this.panelEx2.MinimumSize = new System.Drawing.Size(649, 304);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(973, 669);
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
            this.ribbonBar1.Controls.Add(this.ribbonClientPanel1);
            this.ribbonBar1.Controls.Add(this.superTabStripORDER);
            this.ribbonBar1.Controls.Add(this.txtTotalQ);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem11,
            this.buttonItem6,
            this.metroTileItem1,
            this.labelItem6});
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(973, 618);
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
            // ribbonClientPanel1
            // 
            this.ribbonClientPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.ribbonClientPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Metro;
            this.ribbonClientPanel1.Controls.Add(this.metroTilePanel_Items);
            this.ribbonClientPanel1.Controls.Add(this.txtInvCost);
            this.ribbonClientPanel1.Controls.Add(this.metroTilePanel_Cat);
            this.ribbonClientPanel1.Controls.Add(this.groupBox5);
            this.ribbonClientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonClientPanel1.Location = new System.Drawing.Point(0, 0);
            this.ribbonClientPanel1.Name = "ribbonClientPanel1";
            this.ribbonClientPanel1.Size = new System.Drawing.Size(973, 578);
            // 
            // 
            // 
            this.ribbonClientPanel1.Style.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ribbonClientPanel1.Style.BackColor2 = System.Drawing.Color.AliceBlue;
            this.ribbonClientPanel1.Style.Class = "SlideOutButtonKey";
            this.ribbonClientPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonClientPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonClientPanel1.TabIndex = 1135;
            // 
            // superTabStripORDER
            // 
            this.superTabStripORDER.AutoSelectAttachedControl = false;
            // 
            // 
            // 
            this.superTabStripORDER.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.superTabStripORDER.ContainerControlProcessDialogKey = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabStripORDER.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabStripORDER.ControlBox.MenuBox.Name = "";
            this.superTabStripORDER.ControlBox.Name = "";
            this.superTabStripORDER.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabStripORDER.ControlBox.MenuBox,
            this.superTabStripORDER.ControlBox.CloseBox});
            this.superTabStripORDER.ControlBox.Visible = false;
            this.superTabStripORDER.Controls.Add(this.panel_Table);
            this.superTabStripORDER.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.superTabStripORDER.Location = new System.Drawing.Point(0, 578);
            this.superTabStripORDER.Name = "superTabStripORDER";
            this.superTabStripORDER.ReorderTabsEnabled = true;
            this.superTabStripORDER.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.superTabStripORDER.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabStripORDER.SelectedTabIndex = 0;
            this.superTabStripORDER.Size = new System.Drawing.Size(973, 23);
            this.superTabStripORDER.TabCloseButtonHot = null;
            this.superTabStripORDER.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabStripORDER.TabIndex = 1137;
            this.superTabStripORDER.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem_OrderType});
            this.superTabStripORDER.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.superTabStripORDER.Text = "superTabStrip1";
            this.superTabStripORDER.Visible = false;
            // 
            // panel_Table
            // 
            this.panel_Table.Controls.Add(this.txtPersons);
            this.panel_Table.Controls.Add(this.label31);
            this.panel_Table.Controls.Add(this.button_SrchTable);
            this.panel_Table.Controls.Add(this.txtTable);
            this.panel_Table.Controls.Add(this.button_AddToTable);
            this.panel_Table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Table.Location = new System.Drawing.Point(0, 0);
            this.panel_Table.Name = "panel_Table";
            this.panel_Table.Size = new System.Drawing.Size(973, 23);
            this.panel_Table.TabIndex = 1194;
            // 
            // txtPersons
            // 
            this.txtPersons.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtPersons.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtPersons.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPersons.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtPersons.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtPersons.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtPersons.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtPersons.Location = new System.Drawing.Point(643, 0);
            this.txtPersons.MinValue = 1;
            this.txtPersons.Name = "txtPersons";
            this.txtPersons.Size = new System.Drawing.Size(44, 23);
            this.txtPersons.TabIndex = 1180;
            this.txtPersons.Value = 1;
            this.txtPersons.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.Color.Transparent;
            this.label31.Dock = System.Windows.Forms.DockStyle.Right;
            this.label31.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label31.ForeColor = System.Drawing.Color.Navy;
            this.label31.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label31.Location = new System.Drawing.Point(687, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(67, 23);
            this.label31.TabIndex = 1181;
            this.label31.Text = "الكراسي";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_SrchTable
            // 
            this.button_SrchTable.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchTable.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.button_SrchTable.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_SrchTable.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button_SrchTable.Location = new System.Drawing.Point(754, 0);
            this.button_SrchTable.Name = "button_SrchTable";
            this.button_SrchTable.Size = new System.Drawing.Size(90, 23);
            this.button_SrchTable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchTable.Symbol = "";
            this.button_SrchTable.SymbolSize = 12F;
            this.button_SrchTable.TabIndex = 1179;
            this.button_SrchTable.Text = "الطاولات";
            this.button_SrchTable.TextColor = System.Drawing.Color.Black;
            this.button_SrchTable.Click += new System.EventHandler(this.button_SrchTable_Click);
            // 
            // txtTable
            // 
            this.txtTable.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtTable.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTable.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTable.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtTable.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtTable.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTable.IsInputReadOnly = true;
            this.txtTable.Location = new System.Drawing.Point(844, 0);
            this.txtTable.MinValue = 0;
            this.txtTable.Name = "txtTable";
            this.txtTable.Size = new System.Drawing.Size(58, 23);
            this.txtTable.TabIndex = 1183;
            // 
            // button_AddToTable
            // 
            this.button_AddToTable.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_AddToTable.Checked = true;
            this.button_AddToTable.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.button_AddToTable.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_AddToTable.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button_AddToTable.Location = new System.Drawing.Point(902, 0);
            this.button_AddToTable.Name = "button_AddToTable";
            this.button_AddToTable.Size = new System.Drawing.Size(71, 23);
            this.button_AddToTable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_AddToTable.SymbolSize = 12F;
            this.button_AddToTable.TabIndex = 1192;
            this.button_AddToTable.Text = "توجيه إلى";
            this.button_AddToTable.TextColor = System.Drawing.Color.Black;
            this.button_AddToTable.Visible = false;
            this.button_AddToTable.Click += new System.EventHandler(this.button_AddToTable_Click);
            // 
            // superTabItem_OrderType
            // 
            this.superTabItem_OrderType.GlobalItem = false;
            this.superTabItem_OrderType.Name = "superTabItem_OrderType";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "*.rtf";
            this.saveFileDialog1.FileName = "doc1";
            this.saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf|All Files(*.*)|*.*";
            this.saveFileDialog1.FilterIndex = 2;
            this.saveFileDialog1.Title = "Save File";
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
            // prnt_prev
            // 
            this.prnt_prev.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.prnt_prev.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.prnt_prev.ClientSize = new System.Drawing.Size(400, 300);
            this.prnt_prev.Document = this.prnt_doc;
            this.prnt_prev.Enabled = true;
            this.prnt_prev.Icon = ((System.Drawing.Icon)(resources.GetObject("prnt_prev.Icon")));
            this.prnt_prev.Name = "prnt_prev";
            this.prnt_prev.Visible = false;
            // 
            // prnt_doc
            // 
            this.prnt_doc.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.prnt_doc_BeginPrint);
            this.prnt_doc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.prnt_doc_PrintPage);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.rtf";
            this.openFileDialog1.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf|All Files(*.*)|*.*";
            this.openFileDialog1.FilterIndex = 2;
            this.openFileDialog1.Title = "Open File";
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
            // ToolStripMenuItem_Rep
            // 
            this.ToolStripMenuItem_Rep.Checked = true;
            this.ToolStripMenuItem_Rep.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToolStripMenuItem_Rep.Name = "ToolStripMenuItem_Rep";
            this.ToolStripMenuItem_Rep.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem_Rep.Text = "إظهار التقرير";
            // 
            // timerInfoBallon
            // 
            this.timerInfoBallon.Interval = 3000;
            // 
            // textBox1
            // 
            this.textBox1.AllowEmptyState = false;
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.textBox1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox1.DisplayFormat = "0.00";
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox1.Increment = 0D;
            this.textBox1.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox1.IsInputReadOnly = true;
            this.textBox1.Location = new System.Drawing.Point(390, 701);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(109, 21);
            this.textBox1.TabIndex = 1057;
            this.textBox1.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.AllowEmptyState = false;
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.textBox2.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox2.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox2.DisplayFormat = "0.00";
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox2.Increment = 0D;
            this.textBox2.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox2.IsInputReadOnly = true;
            this.textBox2.Location = new System.Drawing.Point(398, 709);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(109, 21);
            this.textBox2.TabIndex = 1064;
            this.textBox2.Visible = false;
            // 
            // txtCustRep
            // 
            this.txtCustRep.AllowEmptyState = false;
            this.txtCustRep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtCustRep.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtCustRep.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCustRep.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtCustRep.DisplayFormat = "0.00";
            this.txtCustRep.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtCustRep.Increment = 0D;
            this.txtCustRep.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtCustRep.IsInputReadOnly = true;
            this.txtCustRep.Location = new System.Drawing.Point(406, 717);
            this.txtCustRep.Name = "txtCustRep";
            this.txtCustRep.Size = new System.Drawing.Size(109, 21);
            this.txtCustRep.TabIndex = 1065;
            this.txtCustRep.Visible = false;
            // 
            // txtCustNet
            // 
            this.txtCustNet.AllowEmptyState = false;
            this.txtCustNet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtCustNet.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtCustNet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCustNet.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtCustNet.DisplayFormat = "0.00";
            this.txtCustNet.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtCustNet.Increment = 0D;
            this.txtCustNet.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtCustNet.IsInputReadOnly = true;
            this.txtCustNet.Location = new System.Drawing.Point(414, 725);
            this.txtCustNet.Name = "txtCustNet";
            this.txtCustNet.Size = new System.Drawing.Size(109, 21);
            this.txtCustNet.TabIndex = 1066;
            this.txtCustNet.Visible = false;
            // 
            // galleryContainer1
            // 
            // 
            // 
            // 
            this.galleryContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.galleryContainer1.EnableGalleryPopup = false;
            this.galleryContainer1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.galleryContainer1.MinimumSize = new System.Drawing.Size(150, 200);
            this.galleryContainer1.MultiLine = false;
            this.galleryContainer1.Name = "galleryContainer1";
            // 
            // 
            // 
            this.galleryContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // FrmWaiterMenue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 669);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtCustNet);
            this.Controls.Add(this.txtCustRep);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.KeyPreview = true;
            this.Name = "FrmWaiterMenue";
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "size = 1021; 740";
            this.Text = "الطلبات المحلية";
            this.Load += new System.EventHandler(this.FrmWaiterMenue_Load);
            this.SizeChanged += new System.EventHandler(this.FrmInvSalePoint_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDueAmount)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalAmLoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDueAmountLoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalAm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscountValLoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalQ)).EndInit();
            this.ribbonBar_Tasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main2)).EndInit();
            this.metroTilePanel_Items.ResumeLayout(false);
            this.ribbonBar_Items.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_ItemsGrids)).EndInit();
            this.groupPanel_BoardNo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_Rate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvCost)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlxStkQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlxDat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlxInv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Cash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_NetWord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Credit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Info)).EndInit();
            this.superTabControl_Info.ResumeLayout(false);
            this.superTabControlPanel4.ResumeLayout(false);
            this.superTabControlPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_CostSts)).EndInit();
            this.superTabControl_CostSts.ResumeLayout(false);
            this.superTabControlPanel6.ResumeLayout(false);
            this.superTabControlPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotTaxLoc)).EndInit();
            this.superTabControlPanel8.ResumeLayout(false);
            this.superTabControlPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotBankComm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotBankCommLoc)).EndInit();
            this.superTabControlPanel7.ResumeLayout(false);
            this.superTabControlPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotDis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotDisLoc)).EndInit();
            this.superTabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ItemDet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_CreditLoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaymentLoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_NetWorkLoc)).EndInit();
            this.panelEx3.ResumeLayout(false);
            this.ribbonBar_DGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_DGV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            this.ribbonClientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabStripORDER)).EndInit();
            this.superTabStripORDER.ResumeLayout(false);
            this.panel_Table.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPersons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTable)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustRep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustNet)).EndInit();
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
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
        public void FillHDGV(IEnumerable<T_INVHED> new_data_enum)
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
            DGV_Main.PrimaryGrid.DataMember = "T_INVHED";
        }
        public void FillHDGVQ(IQueryable new_data_enum)
        {
            SetReadOnly = true;
            DGV_Main.PrimaryGrid.DataSource = new_data_enum;
            DGV_Main.PrimaryGrid.DataMember = "T_INVHED";
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
                if (!switchButton_Lock.Visible)
                {
                    switchButton_Lock.Visible = true;
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
                SetReadOnly = false;
            }
        }
        public void buttonItem_Print_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_ID.Text != "" && State == FormState.Saved && switchButton_Lock.Value)
                {
                    _PrintInv(data_this.InvHed_ID, data_this.SalsManNo);
                }
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "لا توجد حقول للطباعة تأكد من إعدادات الطباعة" : "No printing fields make sure the print settings", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private int vStr(int vTy)
        {
            if (VarGeneral.InvTyp == 1)
            {
                if (VarGeneral._IsPOS)
                {
                    return 27;
                }
                return 1;
            }
            if (VarGeneral.InvTyp == 1)
            {
                return 1;
            }
            if (VarGeneral.InvTyp == 2)
            {
                return 5;
            }
            if (VarGeneral.InvTyp == 3)
            {
                return 3;
            }
            if (VarGeneral.InvTyp == 4)
            {
                return 7;
            }
            if (VarGeneral.InvTyp == 7)
            {
                return 9;
            }
            if (VarGeneral.InvTyp == 8)
            {
                return 11;
            }
            if (VarGeneral.InvTyp == 9)
            {
                return 13;
            }
            if (VarGeneral.InvTyp == 14)
            {
                return 15;
            }
            if (VarGeneral.InvTyp == 5)
            {
                return 17;
            }
            if (VarGeneral.InvTyp == 6)
            {
                return 19;
            }
            if (VarGeneral.InvTyp == 17)
            {
                return 21;
            }
            if (VarGeneral.InvTyp == 20)
            {
                return 23;
            }
            return 25;
        }
        private void _PrintInv(int _invHd, string _UserNo)
        {
            RepShow _RepShow = new RepShow();
            _RepShow.Tables = "T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
            string vInvH = " T_INVHED.InvHed_ID, T_INVHED.InvId as vID, T_INVHED.InvNo, T_INVHED.InvTyp, T_INVHED.InvCashPay, T_INVHED.CusVenNo,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Arb_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNm,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Eng_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNmE, T_INVHED.CusVenAdd, T_INVHED.CusVenTel, T_INVHED.Remark, T_INVHED.HDat, T_INVHED.GDat, T_INVHED.MndNo, T_INVHED.SalsManNo, T_INVHED.SalsManNam, T_INVHED.InvTot, T_INVHED.InvDisPrs, ((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints, T_INVHED.InvNet, T_INVHED.InvNetLocCur, T_INVHED.CashPayLocCur, T_INVHED.IfRet, T_INVHED.CashPay, T_INVHED.InvTotLocCur, T_INVHED.InvDisValLocCur, T_INVHED.GadeNo, T_INVHED.GadeId, T_INVHED.RetNo, T_INVHED.RetId, T_INVHED.InvCashPayNm, T_INVHED.InvCost, T_INVHED.CustPri, T_INVHED.ArbTaf, T_INVHED.ToStore, T_INVHED.InvCash, T_INVHED.CurTyp, T_INVHED.EstDat,case when DATEDIFF(day, GETDATE(), EstDat) > 0 Then DATEDIFF(day, GETDATE(), EstDat) WHEN DATEDIFF(day, GETDATE(), InvCashPayNm) > 0 THEN DATEDIFF(day, GETDATE(), InvCashPayNm) Else '0' END as EstDatNote, T_INVHED.InvCstNo, T_INVHED.IfDel, T_INVHED.RefNo, T_INVHED.ToStoreNm, T_INVHED.EngTaf, T_INVHED.IfTrans, T_INVHED.InvQty, T_INVHED.CustNet, T_INVHED.CustRep, T_INVHED.InvWight_T, T_INVHED.IfPrint, T_INVHED.LTim, T_INVHED.DATE_CREATED, T_INVHED.MODIFIED_BY, T_INVHED.CreditPay, T_INVHED.DATE_MODIFIED, T_INVHED.CREATED_BY, T_INVHED.CreditPayLocCur, T_INVHED.NetworkPay, T_INVHED.NetworkPayLocCur, T_INVHED.MndExtrnal, T_INVHED.CompanyID, T_INVHED.InvAddCost, T_INVHED.InvAddCostExtrnal, T_INVHED.InvAddCostExtrnalLoc, T_INVHED.IsExtrnalGaid, T_INVHED.ExtrnalCostGaidID, T_INVHED.InvAddCostLoc, T_INVHED.CommMnd_Inv, T_INVHED.Puyaid, T_INVHED.Remming,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.PersonalNm from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as PersonalNm,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.City from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as City,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Email from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Email,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Mobile from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Mobile,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Telphone1 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Telphone1,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select vColStr1 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CustAge,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Telphone2 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Telphone2,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Fax from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Fax,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.zipCod from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as zipCod,T_SYSSETTING.LineGiftlNameA,T_SYSSETTING.LineGiftlNameE,T_Curency.Arb_Des as CurrnceyNm,T_Curency.Eng_Des as CurrnceyNmE,(select max(gdDes)from T_GDDET where gdID = T_INVHED.GadeId )as gdDes, (T_INVDET.Amount - (case when T_INVHED.IsTaxLines = 1 then (case when T_INVHED.IsTaxByTotal = 1 then (case when (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) > 0 then ((Abs(T_INVDET.Qty) *  T_INVDET.Price) - case when (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) > 0 then (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) else 0 end )* T_INVDET.ItmTax / 100   else 0 end) else (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) end) else 0 end )) as TotBeforeTax,(select invGdADesc from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as invGdADesc,(select invGdEDesc from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as invGdEDesc,(select T_CATEGORY.CAT_No from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CAT_No,(select T_CATEGORY.Arb_Des from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CatNmA,(select T_CATEGORY.Eng_Des from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CatNmE,(case when (select t.BarCod1 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit1 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod1 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit1 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt ))  when (select t.BarCod2 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit2 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod2 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit2 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod3 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit3 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod3 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit3 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod4 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit4 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod4 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit4 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod5 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit5 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod5 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit5 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) else T_Items.Itm_No  end) as ItmBarcod";
            string Fields = " Abs(T_INVDET.Qty) as QtyAbs , T_INVDET.InvDet_ID,T_INVHED.tailor1,T_INVHED.tailor2,T_INVHED.tailor3,T_INVHED.tailor4,T_INVHED.tailor5,T_INVHED.tailor6,T_INVHED.tailor7,T_INVHED.tailor8,T_INVHED.tailor9,T_INVHED.tailor10,T_INVHED.tailor11,T_INVHED.tailor12,T_INVHED.tailor13,T_INVHED.tailor14,T_INVHED.tailor15,T_INVHED.tailor16,T_INVHED.tailor17,T_INVHED.tailor18,T_INVHED.tailor19,T_INVHED.tailor20,T_INVHED.InvImg, T_INVDET.InvNo, T_INVDET.InvId, T_INVDET.InvSer, T_INVDET.ItmNo, T_INVDET.Cost, T_INVDET.Qty, T_INVDET.ItmUnt, T_INVDET.ItmDes,T_INVDET.ItmDesE , T_INVDET.ItmUntE, T_INVDET.ItmUntPak, T_INVDET.StoreNo, T_INVDET.Price, T_INVDET.Amount, T_INVDET.RealQty, T_INVDET.ItmTyp,T_INVDET.ItmDis, (Abs(T_INVDET.Qty) *  T_INVDET.Price) * (T_INVDET.ItmDis / 100) as ItmDisVal, T_INVDET.DatExper, T_INVDET.itmInvDsc,ItmIndex," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.LineGiftSts, vStr(VarGeneral.InvTyp)) ? " T_INVDET.ItmWight " : " 0 as ItmWight") + ", T_INVDET.ItmWight_T, T_INVDET.ItmAddCost, T_INVDET.RunCod, T_INVDET.LineDetails ,T_INVDET.Serial_Key, " + vInvH + ", T_Items.* , T_CstTbl.Arb_Des as CstTbl_Arb_Des , T_CstTbl.Eng_Des as CstTbl_Eng_Des , T_Mndob.Arb_Des as Mndob_Arb_Des , T_Mndob.Eng_Des as Mndob_Eng_Des,T_SYSSETTING.LogImg,(select max(T_AccDef.TaxNo) from T_AccDef where T_AccDef.AccDef_No = T_SYSSETTING.TaxAcc) as TaxAcc,T_SYSSETTING.TaxNoteInv,case when T_INVHED.IsTaxLines = 1 then (case when T_INVHED.IsTaxByTotal = 1 then (case when (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) > 0 then ((Abs(T_INVDET.Qty) *  T_INVDET.Price) - case when (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) > 0 then (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) else 0 end )* T_INVDET.ItmTax / 100   else 0 end) else (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) end) else 0 end as TaxValue ,(select InvNamA from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as InvNamA,(select InvNamE from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as InvNamE,(select T_Store.Arb_Des from T_Store where T_Store.Stor_ID = T_INVDET.StoreNo) as StoreNmA,(select T_Store.Eng_Des from T_Store where T_Store.Stor_ID = T_INVDET.StoreNo) as StoreNmE,(select defPrn from T_INVSETTING where CatID = (select ItmCat from T_Items where Itm_No = T_INVDET.ItmNo) ) as defPrn,case when T_INVHED.CusVenNo = '' THEN '0' ELSE (SELECT Sum(T_GDDET.gdValue) FROM T_GDHEAD INNER JOIN  T_GDDET ON T_GDHEAD.gdhead_ID = T_GDDET.gdID where T_GDDET.AccNo = T_INVHED.CusVenNo and T_GDHEAD.gdLok = 0 and (select T_AccDef.AccCat from T_AccDef where T_AccDef.AccDef_No = T_INVHED.CusVenNo) = '4') END as Balanc,T_INVDET.ItmTax,T_INVHED.InvAddTax,T_INVHED.InvAddTaxlLoc,T_INVHED.TaxGaidID,T_INVHED.IsTaxUse,T_INVHED.IsTaxLines,IsTaxByTotal,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.TaxNo from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as TaxCustNo,T_INVHED.OrderTyp," + ((data_this.IsTaxLines.Value && !VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65)) ? " T_INVHED.InvTotLocCur - T_INVHED.InvAddTax as TotWithTaxPoint " : " T_INVHED.InvTotLocCur as TotWithTaxPoint") + " ,T_INVHED.InvTotLocCur - T_INVHED.InvDisVal as TotBeforeDisVal,T_INVHED.IsTaxByNet,T_INVHED.TaxByNetValue," + (data_this.IsTaxUse.Value ? " T_INVHED.InvNetLocCur - T_INVHED.InvAddTax as NetWithoutTax " : " T_INVHED.InvNetLocCur as NetWithoutTax");
            VarGeneral.HeaderRep[0] = Text;
            VarGeneral.HeaderRep[1] = "";
            VarGeneral.HeaderRep[2] = "";
            _RepShow.Rule = " where T_INVHED.InvHed_ID = " + _invHd;
            if (string.IsNullOrEmpty(Fields))
            {
                return;
            }
            _RepShow.Fields = Fields;
            try
            {
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                _RepShow = new RepShow();
                _RepShow.Rule = " WHERE T_Users.UsrNo = '" + _UserNo + "'";
                _RepShow.Tables = " T_Branch INNER JOIN T_Users ON T_Branch.Branch_no = T_Users.Brn ";
                _RepShow.Fields = " T_Users.UsrNamA ,T_Branch.Branch_Name ,T_Users.UsrNamE ,T_Branch.Branch_NameE ,T_Users.UsrImg ";
                try
                {
                    VarGeneral.RepShowStock_Rat = "Rate";
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepShowStock_Rat = "";
                }
                catch (Exception ex2)
                {
                    VarGeneral.RepShowStock_Rat = "";
                    MessageBox.Show(ex2.Message);
                }
                _RepShow.RepData.Tables[0].Merge(VarGeneral.RepData.Tables[0]);
                VarGeneral.RepData = _RepShow.RepData;
                try
                {
                    for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
                    {
                        if (string.IsNullOrEmpty(VarGeneral.RepData.Tables[0].Rows[i]["LogImg"].ToString()))
                        {
                            VarGeneral.RepData.Tables[0].Rows[i]["LogImg"] = VarGeneral.RepData.Tables[0].Rows[VarGeneral.RepData.Tables[0].Rows.Count - 1]["LogImg"];
                            VarGeneral.RepData.Tables[0].Rows[i]["LTim"] = VarGeneral.RepData.Tables[0].Rows[VarGeneral.RepData.Tables[0].Rows.Count - 1]["LTim"];
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
                    {
                        if (string.IsNullOrEmpty(VarGeneral.RepData.Tables[0].Rows[i]["UsrImg"].ToString()))
                        {
                            try
                            {
                                VarGeneral.RepData.Tables[0].Rows[i]["UsrImg"] = VarGeneral.RepData.Tables[0].Rows[0]["UsrImg"];
                            }
                            catch
                            {
                            }
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    if (VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 15))
                    {
                        _RepShow = new RepShow();
                        _RepShow.Tables = "T_SINVDET LEFT OUTER JOIN T_INVHED ON T_SINVDET.SInvIdHEAD = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_SINVDET.SItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                        string vInvH2 = " T_INVHED.InvHed_ID, T_INVHED.InvId as vID, T_INVHED.InvNo, T_INVHED.InvTyp, T_INVHED.InvCashPay, T_INVHED.CusVenNo,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Arb_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNm,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Eng_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNmE, T_INVHED.CusVenAdd, T_INVHED.CusVenTel, T_INVHED.Remark, T_INVHED.HDat, T_INVHED.GDat, T_INVHED.MndNo, T_INVHED.SalsManNo, T_INVHED.SalsManNam, T_INVHED.InvTot, T_INVHED.InvDisPrs, (T_INVHED.InvDisVal + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints, T_INVHED.InvNet, T_INVHED.InvNetLocCur, T_INVHED.CashPayLocCur, T_INVHED.IfRet, T_INVHED.CashPay, T_INVHED.InvTotLocCur, T_INVHED.InvDisValLocCur, T_INVHED.GadeNo, T_INVHED.GadeId, T_INVHED.RetNo, T_INVHED.RetId, T_INVHED.InvCashPayNm, T_INVHED.InvCost, T_INVHED.CustPri, T_INVHED.ArbTaf, T_INVHED.ToStore, T_INVHED.InvCash, T_INVHED.CurTyp, T_INVHED.EstDat,case when DATEDIFF(day, GETDATE(), EstDat) > 0 Then DATEDIFF(day, GETDATE(), EstDat) WHEN DATEDIFF(day, GETDATE(), InvCashPayNm) > 0 THEN DATEDIFF(day, GETDATE(), InvCashPayNm) Else '0' END as EstDatNote, T_INVHED.InvCstNo, T_INVHED.IfDel, T_INVHED.RefNo, T_INVHED.ToStoreNm, T_INVHED.EngTaf, T_INVHED.IfTrans, T_INVHED.InvQty, T_INVHED.CustNet, T_INVHED.CustRep, T_INVHED.InvWight_T, T_INVHED.IfPrint, T_INVHED.LTim, T_INVHED.DATE_CREATED, T_INVHED.MODIFIED_BY, T_INVHED.CreditPay, T_INVHED.DATE_MODIFIED, T_INVHED.CREATED_BY, T_INVHED.CreditPayLocCur, T_INVHED.NetworkPay, T_INVHED.NetworkPayLocCur, T_INVHED.MndExtrnal, T_INVHED.CompanyID, T_INVHED.InvAddCost, T_INVHED.InvAddCostExtrnal, T_INVHED.InvAddCostExtrnalLoc, T_INVHED.IsExtrnalGaid, T_INVHED.ExtrnalCostGaidID, T_INVHED.InvAddCostLoc, T_INVHED.CommMnd_Inv, T_INVHED.Puyaid, T_INVHED.Remming,T_SYSSETTING.LineGiftlNameA,T_SYSSETTING.LineGiftlNameE,T_Curency.Arb_Des as CurrnceyNm,T_Curency.Eng_Des as CurrnceyNmE,(select max(gdDes)from T_GDDET where gdID = T_INVHED.GadeId )as gdDes, (T_INVDET.Amount - (case when T_INVHED.IsTaxLines = 1 then (case when T_INVHED.IsTaxByTotal = 1 then (case when (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) > 0 then ((Abs(T_INVDET.Qty) *  T_INVDET.Price) - case when (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) > 0 then (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) else 0 end )* T_INVDET.ItmTax / 100   else 0 end) else (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) end) else 0 end )) as TotBeforeTax,(select invGdADesc from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as invGdADesc,(select invGdEDesc from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as invGdEDesc,(select T_CATEGORY.CAT_No from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CAT_No,(select T_CATEGORY.Arb_Des from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CatNmA,(select T_CATEGORY.Eng_Des from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CatNmE,(case when (select t.BarCod1 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit1 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod1 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit1 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt ))  when (select t.BarCod2 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit2 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod2 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit2 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod3 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit3 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod3 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit3 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod4 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit4 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod4 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit4 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod5 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit5 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod5 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit5 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) else T_Items.Itm_No  end) as ItmBarcod";
                        _RepShow.Fields = " Abs(T_SINVDET.SQty) as QtyAbs , SInvDet_ID as InvId , SInvNo as InvNo, SInvId as InvDet_ID, SInvSer as InvSer,SItmNo as ItmNo, SCost as Cost, SQty as Qty, SItmDes as ItmDes, SItmUnt as ItmUnt, SItmDesE as ItmDesE, SItmUntE as ItmUntE, SItmUntPak as ItmUntPak, SStoreNo as StoreNo, (SPrice * 0) as Price, (SAmount * 0) as Amount, SRealQty as RealQty, SitmInvDsc as itmInvDsc, SDatExper as DatExper, SItmDis as ItmDis, SItmTyp as ItmTyp,SItmIndex as ItmIndex, SItmWight_T as ItmWight_T, SItmWight as ItmWight , " + vInvH2 + " , T_Items.* , T_CstTbl.Arb_Des as CstTbl_Arb_Des , T_CstTbl.Eng_Des as CstTbl_Eng_Des , T_Mndob.Arb_Des as Mndob_Arb_Des , T_Mndob.Eng_Des as Mndob_Eng_Des,T_SYSSETTING.LogImg,(select max(T_AccDef.TaxNo) from T_AccDef where T_AccDef.AccDef_No = T_SYSSETTING.TaxAcc) as TaxAcc,T_SYSSETTING.TaxNoteInv,case when T_INVHED.IsTaxLines = 1 then (case when T_INVHED.IsTaxByTotal = 1 then (case when (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) > 0 then ((Abs(T_INVDET.Qty) *  T_INVDET.Price) - case when (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) > 0 then (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) else 0 end )* T_INVDET.ItmTax / 100   else 0 end) else (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) end) else 0 end as TaxValue,T_INVHED.IsTaxUse,T_INVHED.IsTaxLines,IsTaxByTotal,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.TaxNo from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as TaxCustNo," + ((data_this.IsTaxLines.Value && !VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65)) ? " T_INVHED.InvTotLocCur - T_INVHED.InvAddTax as TotWithTaxPoint " : " T_INVHED.InvTotLocCur as TotWithTaxPoint");
                        _RepShow.Rule = " where T_INVHED.InvHed_ID = " + _invHd;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData.Tables[0].Merge(_RepShow.RepData.Tables[0]);
                    }
                }
                catch
                {
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
            if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
            {
                return;
            }
            try
            {
                FrmReportsViewer frm = new FrmReportsViewer();
                frm.Repvalue = "InvSalWtr";
                frm.RepCashier = "InvoiceCachierWaiter";

                frm.Tag = LangArEn;
                if (checkBoxItem_BarCode.Checked)
                {
                    frm.BarcodSts = true;
                }
                else
                {
                    frm.BarcodSts = false;
                }
                if (_InvSetting.InvpRINTERInfo.nTyp.Substring(1, 1) == "1")
                {
                    frm.Repvalue = "InvSalWtr";
                }
                else
                {
                    frm.RepCashier = "InvoiceCachierWaiter";
                }
                VarGeneral.CostCenterlbl = label15.Text.Replace(" :", "");
                VarGeneral.Mndoblbl = label18.Text.Replace(" :", "");
                VarGeneral.vTitle = Text;
                VarGeneral.IsCashCredit = false;
                if (_InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1) == "0" || checkBoxItem_BarCode.Checked)
                {
                    frm._Proceess();
                    return;
                }
                frm.TopMost = true;
                frm.ShowDialog();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("buttonItem_Print_Click:", error, enable: true);
                MessageBox.Show(error.Message);
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
                             where item.repTyp == (int?)3
                             where item.repNum == (int?)3
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
                    string strfiled = "";
                    strfiled = ((!(_mInvPrint.pField == "PageNo")) ? VarGeneral.TString.TEmpty_Stock(string.Concat(VarGeneral.RepData.Tables[0].Rows[iiRnt][_mInvPrint.pField])) : (_page + " / " + _PageCount));
                    if (_mInvPrint.IsPrntHd == 1)
                    {
                        if (_mInvPrint.pField == "ItmNo")
                        {
                            StringFormat stringFormat = new StringFormat();
                            stringFormat.Alignment = StringAlignment.Far;
                            StringFormat format = stringFormat;
                            e.Graphics.DrawString(strfiled, _font, Brushes.Black, _mInvPrint.vCol.Value, _Row, format);
                        }
                        else
                        {
                            e.Graphics.DrawString(strfiled, _font, Brushes.Black, _mInvPrint.vCol.Value, _Row, strformat);
                        }
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
        private void prnt_doc_BeginPrint(object sender, PrintEventArgs e)
        {
            if (!(textBox_ID.Text != ""))
            {
                return;
            }
            RepShow _RepShow = new RepShow();
            _RepShow.Tables = "T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
            string vInvH = " T_INVHED.InvHed_ID, T_INVHED.InvId as vID, T_INVHED.InvNo, T_INVHED.InvTyp, T_INVHED.InvCashPay, T_INVHED.CusVenNo,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Arb_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNm,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Eng_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNmE, T_INVHED.CusVenAdd, T_INVHED.CusVenTel, T_INVHED.Remark, T_INVHED.HDat, T_INVHED.GDat, T_INVHED.MndNo, T_INVHED.SalsManNo, T_INVHED.SalsManNam, T_INVHED.InvTot, T_INVHED.InvDisPrs, ((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints, T_INVHED.InvNet, T_INVHED.InvNetLocCur, T_INVHED.CashPayLocCur, T_INVHED.IfRet, T_INVHED.CashPay, T_INVHED.InvTotLocCur, T_INVHED.InvDisValLocCur, T_INVHED.GadeNo, T_INVHED.GadeId, T_INVHED.RetNo, T_INVHED.RetId, T_INVHED.InvCashPayNm, T_INVHED.InvCost, T_INVHED.CustPri, T_INVHED.ArbTaf, T_INVHED.ToStore, T_INVHED.InvCash, T_INVHED.CurTyp, T_INVHED.EstDat,case when DATEDIFF(day, GETDATE(), EstDat) > 0 Then DATEDIFF(day, GETDATE(), EstDat) WHEN DATEDIFF(day, GETDATE(), InvCashPayNm) > 0 THEN DATEDIFF(day, GETDATE(), InvCashPayNm) Else '0' END as EstDatNote, T_INVHED.InvCstNo, T_INVHED.IfDel, T_INVHED.RefNo, T_INVHED.ToStoreNm, T_INVHED.EngTaf, T_INVHED.IfTrans, T_INVHED.InvQty, T_INVHED.CustNet, T_INVHED.CustRep, T_INVHED.InvWight_T, T_INVHED.IfPrint, T_INVHED.LTim, T_INVHED.DATE_CREATED, T_INVHED.MODIFIED_BY, T_INVHED.CreditPay, T_INVHED.DATE_MODIFIED, T_INVHED.CREATED_BY, T_INVHED.CreditPayLocCur, T_INVHED.NetworkPay, T_INVHED.NetworkPayLocCur, T_INVHED.MndExtrnal, T_INVHED.CompanyID, T_INVHED.InvAddCost, T_INVHED.InvAddCostExtrnal, T_INVHED.InvAddCostExtrnalLoc, T_INVHED.IsExtrnalGaid, T_INVHED.ExtrnalCostGaidID, T_INVHED.InvAddCostLoc, T_INVHED.CommMnd_Inv, T_INVHED.Puyaid, T_INVHED.Remming,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.PersonalNm from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as PersonalNm,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.City from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as City,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Email from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Email,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Mobile from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Mobile,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Telphone1 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Telphone1,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select vColStr1 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CustAge,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Telphone2 from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Telphone2,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Fax from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Fax,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.zipCod from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as zipCod,T_SYSSETTING.LineGiftlNameA,T_SYSSETTING.LineGiftlNameE,T_Curency.Arb_Des as CurrnceyNm,T_Curency.Eng_Des as CurrnceyNmE,(select max(gdDes)from T_GDDET where gdID = T_INVHED.GadeId )as gdDes, (T_INVDET.Amount - (case when T_INVHED.IsTaxLines = 1 then (case when T_INVHED.IsTaxByTotal = 1 then (case when (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) > 0 then ((Abs(T_INVDET.Qty) *  T_INVDET.Price) - case when (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) > 0 then (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) else 0 end )* T_INVDET.ItmTax / 100   else 0 end) else (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) end) else 0 end )) as TotBeforeTax,(select invGdADesc from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as invGdADesc,(select invGdEDesc from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as invGdEDesc,(select T_CATEGORY.CAT_No from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CAT_No,(select T_CATEGORY.Arb_Des from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CatNmA,(select T_CATEGORY.Eng_Des from T_CATEGORY where T_CATEGORY.CAT_ID = T_Items.ItmCat) as CatNmE,(case when (select t.BarCod1 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit1 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod1 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit1 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt ))  when (select t.BarCod2 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit2 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod2 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit2 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod3 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit3 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod3 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit3 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod4 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit4 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod4 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit4 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) when (select t.BarCod5 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit5 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) != '' then (select t.BarCod5 from T_Items t where t.Itm_No = T_INVDET.ItmNo and t.Unit5 = (select max(e.Unit_ID) from T_Unit e where e.Arb_Des = T_INVDET.ItmUnt )) else T_Items.Itm_No  end) as ItmBarcod";
            string Fields = " Abs(T_INVDET.Qty) as QtyAbs , T_INVDET.InvDet_ID,T_INVHED.tailor1,T_INVHED.tailor2,T_INVHED.tailor3,T_INVHED.tailor4,T_INVHED.tailor5,T_INVHED.tailor6,T_INVHED.tailor7,T_INVHED.tailor8,T_INVHED.tailor9,T_INVHED.tailor10,T_INVHED.tailor11,T_INVHED.tailor12,T_INVHED.tailor13,T_INVHED.tailor14,T_INVHED.tailor15,T_INVHED.tailor16,T_INVHED.tailor17,T_INVHED.tailor18,T_INVHED.tailor19,T_INVHED.tailor20,T_INVHED.InvImg, T_INVDET.InvNo, T_INVDET.InvId, T_INVDET.InvSer, T_INVDET.ItmNo, T_INVDET.Cost, T_INVDET.Qty, T_INVDET.ItmUnt, T_INVDET.ItmDes,T_INVDET.ItmDesE , T_INVDET.ItmUntE, T_INVDET.ItmUntPak, T_INVDET.StoreNo, T_INVDET.Price, T_INVDET.Amount, T_INVDET.RealQty, T_INVDET.ItmTyp,T_INVDET.ItmDis, (Abs(T_INVDET.Qty) *  T_INVDET.Price) * (T_INVDET.ItmDis / 100) as ItmDisVal, T_INVDET.DatExper, T_INVDET.itmInvDsc,ItmIndex," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.LineGiftSts, vStr(VarGeneral.InvTyp)) ? " T_INVDET.ItmWight " : " 0 as ItmWight") + ", T_INVDET.ItmWight_T, T_INVDET.ItmAddCost, T_INVDET.RunCod, T_INVDET.LineDetails ,T_INVDET.Serial_Key, " + vInvH + ", T_Items.* , T_CstTbl.Arb_Des as CstTbl_Arb_Des , T_CstTbl.Eng_Des as CstTbl_Eng_Des , T_Mndob.Arb_Des as Mndob_Arb_Des , T_Mndob.Eng_Des as Mndob_Eng_Des,T_SYSSETTING.LogImg,(select max(T_AccDef.TaxNo) from T_AccDef where T_AccDef.AccDef_No = T_SYSSETTING.TaxAcc) as TaxAcc,T_SYSSETTING.TaxNoteInv,case when T_INVHED.IsTaxLines = 1 then (case when T_INVHED.IsTaxByTotal = 1 then (case when (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) > 0 then ((Abs(T_INVDET.Qty) *  T_INVDET.Price) - case when (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) > 0 then (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) else 0 end )* T_INVDET.ItmTax / 100   else 0 end) else (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) end) else 0 end as TaxValue ,(select InvNamA from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as InvNamA,(select InvNamE from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as InvNamE,(select T_Store.Arb_Des from T_Store where T_Store.Stor_ID = T_INVDET.StoreNo) as StoreNmA,(select T_Store.Eng_Des from T_Store where T_Store.Stor_ID = T_INVDET.StoreNo) as StoreNmE,(select defPrn from T_INVSETTING where CatID = (select ItmCat from T_Items where Itm_No = T_INVDET.ItmNo) ) as defPrn,case when T_INVHED.CusVenNo = '' THEN '0' ELSE (SELECT Sum(T_GDDET.gdValue) FROM T_GDHEAD INNER JOIN  T_GDDET ON T_GDHEAD.gdhead_ID = T_GDDET.gdID where T_GDDET.AccNo = T_INVHED.CusVenNo and T_GDHEAD.gdLok = 0 and (select T_AccDef.AccCat from T_AccDef where T_AccDef.AccDef_No = T_INVHED.CusVenNo) = '4') END as Balanc,T_INVDET.ItmTax,T_INVHED.InvAddTax,T_INVHED.InvAddTaxlLoc,T_INVHED.TaxGaidID,T_INVHED.IsTaxUse,T_INVHED.IsTaxLines,IsTaxByTotal,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.TaxNo from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as TaxCustNo,T_INVHED.OrderTyp," + ((data_this.IsTaxLines.Value && !VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 65)) ? " T_INVHED.InvTotLocCur - T_INVHED.InvAddTax as TotWithTaxPoint " : " T_INVHED.InvTotLocCur as TotWithTaxPoint") + " ,T_INVHED.InvTotLocCur - T_INVHED.InvDisVal as TotBeforeDisVal,T_INVHED.IsTaxByNet,T_INVHED.TaxByNetValue," + (data_this.IsTaxUse.Value ? " T_INVHED.InvNetLocCur - T_INVHED.InvAddTax as NetWithoutTax " : " T_INVHED.InvNetLocCur as NetWithoutTax");
            VarGeneral.HeaderRep[0] = Text;
            VarGeneral.HeaderRep[1] = "";
            VarGeneral.HeaderRep[2] = "";
            _RepShow.Rule = " where T_INVHED.InvHed_ID = " + data_this.InvHed_ID;
            if (string.IsNullOrEmpty(Fields))
            {
                return;
            }
            _RepShow.Fields = Fields;
            try
            {
                _RepShow = _RepShow.Save();
                VarGeneral.RepData = _RepShow.RepData;
                _RepShow = new RepShow();
                _RepShow.Rule = " WHERE T_Users.UsrNo = '" + data_this.SalsManNo + "'";
                _RepShow.Tables = " T_Branch INNER JOIN T_Users ON T_Branch.Branch_no = T_Users.Brn ";
                _RepShow.Fields = " T_Users.UsrNamA ,T_Branch.Branch_Name ,T_Users.UsrNamE ,T_Branch.Branch_NameE ,T_Users.UsrImg ";
                try
                {
                    VarGeneral.RepShowStock_Rat = "Rate";
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepShowStock_Rat = "";
                }
                catch (Exception ex2)
                {
                    VarGeneral.RepShowStock_Rat = "";
                    MessageBox.Show(ex2.Message);
                }
                try
                {
                    for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
                    {
                        if (string.IsNullOrEmpty(VarGeneral.RepData.Tables[0].Rows[i]["LogImg"].ToString()))
                        {
                            VarGeneral.RepData.Tables[0].Rows[i]["LogImg"] = VarGeneral.RepData.Tables[0].Rows[VarGeneral.RepData.Tables[0].Rows.Count - 1]["LogImg"];
                            VarGeneral.RepData.Tables[0].Rows[i]["LTim"] = VarGeneral.RepData.Tables[0].Rows[VarGeneral.RepData.Tables[0].Rows.Count - 1]["LTim"];
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
                    {
                        try
                        {
                            VarGeneral.RepData.Tables[0].Rows[i]["SalsManNam"] = _RepShow.RepData.Tables[0].Rows[0][(LangArEn == 0) ? "UsrNamA" : "UsrNamE"];
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
                    if (VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 15))
                    {
                        _RepShow = new RepShow();
                        _RepShow.Rule = "";
                        _RepShow.Tables = "T_SINVDET LEFT OUTER JOIN T_INVHED ON T_SINVDET.SInvIdHEAD = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_SINVDET.SItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                        string vInvH2 = " T_INVHED.InvHed_ID, T_INVHED.InvId, T_INVHED.InvNo, T_INVHED.InvTyp, T_INVHED.InvCashPay, T_INVHED.CusVenNo,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE " + ((LangArEn == 0) ? "(select T_AccDef.Arb_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo)" : "(select T_AccDef.Eng_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo)") + " END as CusVenNm, T_INVHED.CusVenAdd, T_INVHED.CusVenTel, T_INVHED.Remark, T_INVHED.HDat, T_INVHED.GDat, T_INVHED.MndNo, T_INVHED.SalsManNo, T_INVHED.SalsManNam, T_INVHED.InvTot, T_INVHED.InvDisPrs, (T_INVHED.InvDisVal + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints, T_INVHED.InvNet, T_INVHED.InvNetLocCur, T_INVHED.CashPayLocCur, T_INVHED.IfRet, T_INVHED.CashPay, T_INVHED.InvTotLocCur, T_INVHED.InvDisValLocCur, T_INVHED.GadeNo, T_INVHED.GadeId, T_INVHED.RetNo, T_INVHED.RetId, T_INVHED.InvCashPayNm, T_INVHED.InvCost, T_INVHED.CustPri, T_INVHED.ArbTaf, T_INVHED.ToStore, T_INVHED.InvCash, T_INVHED.CurTyp, T_INVHED.EstDat, T_INVHED.InvCstNo, T_INVHED.IfDel, T_INVHED.RefNo, T_INVHED.ToStoreNm, T_INVHED.EngTaf, T_INVHED.IfTrans, T_INVHED.InvQty, T_INVHED.CustNet, T_INVHED.CustRep, T_INVHED.InvWight_T, T_INVHED.IfPrint, T_INVHED.LTim, T_INVHED.DATE_CREATED, T_INVHED.MODIFIED_BY, T_INVHED.CreditPay, T_INVHED.DATE_MODIFIED, T_INVHED.CREATED_BY, T_INVHED.CreditPayLocCur, T_INVHED.NetworkPay, T_INVHED.NetworkPayLocCur, T_INVHED.MndExtrnal, T_INVHED.CompanyID, T_INVHED.InvAddCost, T_INVHED.InvAddCostExtrnal, T_INVHED.InvAddCostExtrnalLoc, T_INVHED.IsExtrnalGaid, T_INVHED.ExtrnalCostGaidID, T_INVHED.InvAddCostLoc, T_INVHED.CommMnd_Inv, T_INVHED.Puyaid, T_INVHED.Remming,(select InvNamA from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as InvNamA,(select InvNamE from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as InvNamE,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Mobile from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Mobile ";
                        _RepShow.Fields = " Abs(T_SINVDET.SQty) as QtyAbs , SInvDet_ID as InvId, SInvNo as InvNo, SInvId as InvDet_ID, SInvSer as InvSer,SItmNo as ItmNo, SCost as Cost, SQty as Qty, SItmDes as ItmDes, SItmUnt as ItmUnt, SItmDesE as ItmDesE, SItmUntE as ItmUntE, SItmUntPak as ItmUntPak, SStoreNo as StoreNo, (SPrice * 0) as Price, (SAmount * 0) as Amount, SRealQty as RealQty, SitmInvDsc as itmInvDsc, SDatExper as DatExper, SItmDis as ItmDis, SItmTyp as ItmTyp,SItmIndex as ItmIndex, SItmWight_T as ItmWight_T, SItmWight as ItmWight , " + vInvH2 + " , T_Items.* , T_CstTbl.Arb_Des as CstTbl_Arb_Des , T_CstTbl.Eng_Des as CstTbl_Eng_Des , T_Mndob.Arb_Des as Mndob_Arb_Des , T_Mndob.Eng_Des as Mndob_Eng_Des,T_SYSSETTING.LogImg,(select max(T_AccDef.TaxNo) from T_AccDef where T_AccDef.AccDef_No = T_SYSSETTING.TaxAcc) as TaxAcc";
                        _RepShow.Rule = " where T_INVHED.InvHed_ID = " + data_this.InvHed_ID;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData.Tables[0].Merge(_RepShow.RepData.Tables[0]);
                    }
                }
                catch
                {
                }
                iiRntP = 0;
                _page = 1;
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
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
        private void switchButton_TaxLines_ValueChanged(object sender, EventArgs e)
        {
            if (State == FormState.Saved)
            {
                return;
            }
            for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
            {
                if (!(string.Concat(FlxInv.GetData(iiCnt, 1)) != ""))
                {
                    continue;
                }
                double ItmDis = 0.0;
                double ItmAddTax = 0.0;
                ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 9)))) / 100.0);
                try
                {
                    if ((File.Exists(Application.StartupPath + "\\Script\\SecriptColDisSalesPoint.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", "").Trim() + "\\SecriptColDisSalesPoint.dll"))) && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 36)))) > 0.0)
                    {
                        ItmDis += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 36)))) / 100.0);
                    }
                }
                catch
                {
                }
                ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                if (!switchButton_TaxLines.Value || switchButton_TaxByTotal.Value)
                {
                    ItmAddTax = 0.0;
                }
                FlxInv.SetData(iiCnt, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) - ItmDis + ItmAddTax);
                if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31)))) > 0.0)
                {
                    ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    FlxInv.SetData(iiCnt, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31)))) + ItmAddTax);
                }
            }
            GetInvTot();
            txtDueAmountLoc_ValueChanged(sender, e);
        }
        private void switchButton_TaxByNet_ValueChanged(object sender, EventArgs e)
        {
            if (switchButton_TaxByNet.Value)
            {
                textBoxItem_TaxByNetValue.Visible = true;
                labelItem_TaxByNetPer.Visible = true;
                switchButton_TaxByTotal.Visible = false;
            }
            else
            {
                textBoxItem_TaxByNetValue.Visible = false;
                labelItem_TaxByNetPer.Visible = false;
                switchButton_TaxByTotal.Visible = true;
            }
            txtDueAmountLoc_ValueChanged(sender, e);
        }
        private void textBoxItem_TaxByNetValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b')) && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
            }
            catch
            {
                e.Handled = true;
            }
        }
        private void textBoxItem_TaxByNetValue_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxItem_TaxByNetValue.Text))
                {
                    textBoxItem_TaxByNetValue.Text = "0";
                }
            }
            catch
            {
                textBoxItem_TaxByNetValue.Text = "0";
            }
            GetInvTot();
        }
        public FrmWaiterMenue()
        {
            InitializeComponent();
            textBox_ID.KeyPress += textBox_ID_KeyPress;
            textBox_ID.Click += Button_Edit_Click;
            textBox1.Click += Button_Edit_Click;
            textBox2.Click += Button_Edit_Click;
            textBox_Type.Click += Button_Edit_Click;
            txtAddress.Click += Button_Edit_Click;
            txtCustName.Click += Button_Edit_Click;
            txtCustNet.Click += Button_Edit_Click;
            txtCustNo.Click += Button_Edit_Click;
            textBox_WaiterName.Click += Button_Edit_Click;
            txtCustRep.Click += Button_Edit_Click;
            txtDiscountP.Click += Button_Edit_Click;
            txtDiscountVal.Click += Button_Edit_Click;
            txtDiscountValLoc.Click += Button_Edit_Click;
            txtDueAmount.Click += Button_Edit_Click;
            txtDueAmountLoc.Click += Button_Edit_Click;
            txtGDate.Click += Button_Edit_Click;
            txtHDate.Click += Button_Edit_Click;
            txtInvCost.Click += Button_Edit_Click;
            txtItemName.Click += Button_Edit_Click;
            txtRef.Click += Button_Edit_Click;
            txtRemark.Click += Button_Edit_Click;
            txtTele.Click += Button_Edit_Click;
            txtTime.Click += Button_Edit_Click;
            txtTotalAm.Click += Button_Edit_Click;
            txtTotalAmLoc.Click += Button_Edit_Click;
            txtTotalQ.Click += Button_Edit_Click;
            CmbCostC.Click += Button_Edit_Click;
            CmbCurr.Click += Button_Edit_Click;
            checkBox_Chash.Click += Button_Edit_Click;
            checkBox_NetWork.Click += Button_Edit_Click;
            CmbInvPrice.Click += Button_Edit_Click;
            CmbLegate.Click += Button_Edit_Click;
            txtPaymentLoc.Click += Button_Edit_Click;
            doubleInput_CreditLoc.Click += Button_Edit_Click;
            doubleInput_NetWorkLoc.Click += Button_Edit_Click;
            expandableSplitter1.Click += expandableSplitter1_Click;
            ToolStripMenuItem_Det.Click += ToolStripMenuItem_Det_Click;
            Button_ExportTable2.Click += Button_ExportTable2_Click;
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
            txtHDate.Leave += txtHDate_Leave;
            txtGDate.Leave += txtGDate_Leave;
            txtTime.Leave += txtTime_Leave;
            button_SrchCustNo.Click += button_SrchCustNo_Click;
            CmbCurr.SelectedIndexChanged += CmbCurr_SelectedIndexChanged;
            checkBox_Chash.CheckedChanged += checkBox_Chash_CheckedChanged;
            FlxInv.Click += FlxInv_Click;
            FlxInv.AfterEdit += FlxInv_AfterEdit;
            FlxInv.BeforeEdit += FlxInv_BeforeEdit;
            FlxInv.KeyDown += FlxInv_KeyDown;
            FlxInv.MouseDown += FlxInv_MouseDown;
            FlxInv.RowColChange += FlxInv_RowColChange;
            FlxInv.SelChange += FlxInv_SelChange;
            switchButton_TaxLines.ButtonWidth = 100;
            checkBox_CostGaidTax.Click += Button_Edit_Click;
            switchButton_Tax.Click += Button_Edit_Click;
            switchButton_TaxLines.Click += Button_Edit_Click;
            switchButton_TaxLines.ValueChanged += switchButton_TaxLines_ValueChanged;
            switchButton_TaxByTotal.Click += Button_Edit_Click;
            switchButton_TaxByTotal.ValueChanged += switchButton_TaxLines_ValueChanged;
            switchButton_TaxByNet.Click += Button_Edit_Click;
            switchButton_TaxByNet.ValueChanged += switchButton_TaxLines_ValueChanged;
            switchButton_TaxByNet.ValueChanged += switchButton_TaxByNet_ValueChanged;
            textBoxItem_TaxByNetValue.KeyPress += textBoxItem_TaxByNetValue_KeyPress;
            textBoxItem_TaxByNetValue.LostFocus += textBoxItem_TaxByNetValue_LostFocus;
            textBoxItem_TaxByNetValue.GotFocus += Button_Edit_Click;
            FlxDat.DoubleClick += FlxDat_DoubleClick;
            FlxDat.KeyDown += FlxDat_KeyDown;
            FlxDat.Leave += FlxDat_Leave;
            txtDiscountP.Leave += txtDiscountP_Leave;
            txtDiscountVal.Leave += txtDiscountVal_Leave;
            buttonItem_Print.Click += buttonItem_Print_Click;
            Button_PrintTable.Click += Button_Print_Click;
            txtDueAmountLoc.ValueChanged += txtDueAmountLoc_ValueChanged;
            txtRemark.ButtonCustomClick += txtRemark_ButtonCustomClick;
            txtCustNo.TextChanged += txtCustNo_TextChanged;
            txtPaymentLoc.Leave += txtPaymentLoc_Leave;
            doubleInput_CreditLoc.Leave += doubleInput_CreditLoc_Leave;
            doubleInput_NetWorkLoc.Leave += doubleInput_NetWorkLoc_Leave;
            if (VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F" || VarGeneral.SSSLev == "S" || VarGeneral.SSSLev == "C")
            {
                CmbCostC.Visible = false;
                label15.Visible = false;
            }
            else
            {
                CmbCostC.Visible = true;
                label15.Visible = true;
            }
            try
            {
                if (VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F")
                {
                    RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
                    try
                    {
                        object q = hKey.GetValue("vCoCe");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vCoCe");
                            hKey.SetValue("vCoCe", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vCoCe");
                        hKey.SetValue("vCoCe", "0");
                    }
                    long regval = long.Parse(hKey.GetValue("vCoCe").ToString());
                    if (regval == 1)
                    {
                        CmbCostC.Visible = true;
                        label15.Visible = true;
                    }
                    else
                    {
                        CmbCostC.Visible = false;
                        label15.Visible = false;
                    }
                }
            }
            catch
            {
            }
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
            {
                doubleInput_Rate.DisplayFormat = VarGeneral.DicemalMask;
                txtDiscountVal.DisplayFormat = VarGeneral.DicemalMask;
                txtDiscountP.DisplayFormat = VarGeneral.DicemalMask;
                txtTotalAmLoc.DisplayFormat = VarGeneral.DicemalMask;
                txtDueAmountLoc.DisplayFormat = VarGeneral.DicemalMask;
                txtDiscountValLoc.DisplayFormat = VarGeneral.DicemalMask;
                txtTotalAm.DisplayFormat = VarGeneral.DicemalMask;
                txtDueAmount.DisplayFormat = VarGeneral.DicemalMask;
                txtTotalQ.DisplayFormat = VarGeneral.DicemalMask;
                txtPaymentLoc.DisplayFormat = VarGeneral.DicemalMask;
                doubleInput_CreditLoc.DisplayFormat = VarGeneral.DicemalMask;
                doubleInput_NetWorkLoc.DisplayFormat = VarGeneral.DicemalMask;
                try
                {
                    FlxInv.Cols[8].Format = VarGeneral.DicimalNN;
                    FlxInv.Cols[9].Format = VarGeneral.DicimalNN;
                    FlxInv.Cols[10].Format = VarGeneral.DicimalNN;
                    FlxInv.Cols[11].Format = VarGeneral.DicimalNN;
                    FlxInv.Cols[12].Format = VarGeneral.DicimalNN;
                    FlxInv.Cols[31].Format = VarGeneral.DicimalNN;
                    FlxInv.Cols[38].Format = VarGeneral.DicimalNN;
                    dataGridView_ItemDet.Cols[8].Format = VarGeneral.DicimalNN;
                    dataGridView_ItemDet.Cols[9].Format = VarGeneral.DicimalNN;
                    dataGridView_ItemDet.Cols[10].Format = VarGeneral.DicimalNN;
                    dataGridView_ItemDet.Cols[11].Format = VarGeneral.DicimalNN;
                    dataGridView_ItemDet.Cols[12].Format = VarGeneral.DicimalNN;
                    dataGridView_ItemDet.Cols[31].Format = VarGeneral.DicimalNN;
                }
                catch
                {
                }
            }
        }
        public void Button_Search_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCustSearch frm = new FrmCustSearch();
                frm.vTy_ = 7;
                frm.Tag = LangArEn;
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    textBox_ID.Text = frm.SerachNo.ToString();
                }
            }
            catch
            {
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
                case "T_INVHED":
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
            data_this = new T_INVHED();
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
                    else if (controls[i].GetType() == typeof(ComboBoxEx))
                    {
                        try
                        {
                            (controls[i] as ComboBoxEx).SelectedIndex = 0;
                        }
                        catch
                        {
                        }
                    }
                }
            }
            checkBox_Chash.Checked = true;
            FlxInv.Rows.Count = 1;
            FlxStkQty.Clear(ClearFlags.Content, 1, 1, 1, 1);
            ItemDetRemoved = new List<int>();
            try
            {
                dataGridView_ItemDet.Clear(ClearFlags.Content, 1, 1, dataGridView_ItemDet.Rows.Count - 1, 34);
            }
            catch
            {
            }
            dataGridView_ItemDet.Rows.Count = 1;
            dataGridView_ItemDet.Visible = false;
            try
            {
                CmbCurr.SelectedValue = int.Parse(VarGeneral.Settings_Sys.ImportIp.ToString());
            }
            catch
            {
            }
            CmbCurr_SelectedIndexChanged(null, null);
            textBox_WaiterName.Tag = VarGeneral._WaiterID.ToString();
            textBox_WaiterName.Text = ((LangArEn == 0) ? db.StockWaiterID(VarGeneral._WaiterID).Arb_Des : db.StockWaiterID(VarGeneral._WaiterID).Eng_Des);
            switchButton_Lock.ValueChanged -= switchButton_Lock_ValueChanged;
            switchButton_Lock.Value = true;
            switchButton_Lock.ValueChanged += switchButton_Lock_ValueChanged;
            txtTable.Tag = "";
            TableTyp();
            try
            {
                switchButton_Tax.Value = VarGeneral.TString.ChkStatShow(_InvSetting.TaxOptions, 4);
            }
            catch
            {
                switchButton_Tax.Value = true;
            }
            try
            {
                switchButton_TaxLines.Value = VarGeneral.TString.ChkStatShow(_InvSetting.TaxOptions, 5);
            }
            catch
            {
                switchButton_TaxLines.Value = true;
            }
            try
            {
                switchButton_TaxByTotal.Value = VarGeneral.TString.ChkStatShow(_InvSetting.TaxOptions, 6);
            }
            catch
            {
                switchButton_TaxByTotal.Value = false;
            }
            try
            {
                switchButton_TaxByNet.Value = VarGeneral.TString.ChkStatShow(_InvSetting.TaxOptions, 7);
            }
            catch
            {
                switchButton_TaxByNet.Value = false;
            }
            try
            {
                textBoxItem_TaxByNetValue.Text = (VarGeneral.TString.ChkStatShow(_InvSetting.TaxOptions, 2) ? VarGeneral.Settings_Sys.DefPurchaesTax.Value : VarGeneral.Settings_Sys.DefSalesTax.Value).ToString();
            }
            catch
            {
                textBoxItem_TaxByNetValue.Text = "0";
            }
            checkBox_CostGaidTax.Checked = false;
            SetReadOnly = false;
        }
        private void InvModeChanged()
        {
            pictureBox_Cash.Visible = true;
            pictureBox_NetWord.Visible = false;
            pictureBox_Credit.Visible = false;
            doubleInput_CreditLoc.IsInputReadOnly = true;
            label6.Text = ((LangArEn == 0) ? "نقــدا\u064c :" : "Paid :");
            txtDueAmountLoc_ValueChanged(null, null);
        }
        private void checkBox_Chash_CheckedChanged(object sender, EventArgs e)
        {
            InvModeChanged();
        }
        private void button_SrchCustNo_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            if (State == FormState.Saved)
            {
                return;
            }
            FrmCustSearch frm = new FrmCustSearch();
            frm.vTy_ = 0;
            frm.Tag = LangArEn;
            VarGeneral.SFrmTyp = "T_AccDef";
            VarGeneral.AccTyp = 4;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtCustNo.Text = frm.Serach_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtCustName.Text = db.StockAccDefWithOutBalance(frm.Serach_No).Arb_Des;
                }
                else
                {
                    txtCustName.Text = db.StockAccDefWithOutBalance(frm.Serach_No).Eng_Des;
                }
                txtAddress.Text = db.StockAccDefWithOutBalance(frm.Serach_No).Adders ?? "";
                txtTele.Text = db.StockAccDefWithOutBalance(frm.Serach_No).Telphone1 ?? "";
                try
                {
                    if (db.StockAccDefs(int.Parse(frm.Serach_No)).Mnd.HasValue)
                    {
                        CmbLegate.SelectedValue = db.StockAccDefs(int.Parse(frm.Serach_No)).Mnd;
                    }
                }
                catch
                {
                    CmbLegate.SelectedIndex = 0;
                }
                try
                {
                    txtCustRep.Value = db.StockAccDefs(int.Parse(frm.Serach_No)).Balance.Value;
                }
                catch
                {
                    txtCustRep.Value = 0.0;
                }
            }
            else
            {
                txtCustNo.Text = "";
                txtCustName.Text = "";
                txtAddress.Text = "";
                txtCustRep.Value = 0.0;
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
                FlxInv.Cols[6].Caption = "مستودع";
                FlxInv.Cols[7].Caption = "الكمية";
                FlxInv.Cols[8].Caption = "السعر";
                FlxInv.Cols[9].Caption = "خصم نسبة";
                FlxInv.Cols[9].Visible = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 8);
                FlxInv.Cols[27].Caption = "تاريخ الصلاحية";
                FlxInv.Cols[31].Caption = "الأجمالي";
                FlxInv.Cols[35].Caption = "رقم التصنيع";
                FlxInv.Cols[36].Caption = VarGeneral.Settings_Sys.LineDetailNameA;
                FlxInv.Cols[38].Caption = "ضريبة %";
                FlxStkQty.Cols[0].Caption = "المستودع";
                FlxStkQty.Cols[1].Caption = "الكمية المتاحة";
                FlxStkQty.Cols[2].Caption = "المستودع";
                FlxDat.Cols[0].Caption = "تاريخ الصلاحية";
                FlxDat.Cols[1].Caption = "الكمية";
                FlxDat.Cols[2].Caption = "رقم التصنيع";
                dataGridView_ItemDet.Cols[1].Caption = "رمز الصنف";
                dataGridView_ItemDet.Cols[2].Visible = true;
                dataGridView_ItemDet.Cols[3].Visible = true;
                dataGridView_ItemDet.Cols[4].Visible = false;
                dataGridView_ItemDet.Cols[5].Visible = false;
                dataGridView_ItemDet.Cols[6].Caption = "مستودع";
                dataGridView_ItemDet.Cols[7].Caption = "الكمية";
                dataGridView_ItemDet.Cols[8].Caption = "السعر";
            }
            else
            {
                LangArEn = 1;
                FlxInv.Cols[1].Caption = "Item Code";
                FlxInv.Cols[2].Visible = false;
                FlxInv.Cols[3].Visible = false;
                FlxInv.Cols[4].Visible = true;
                FlxInv.Cols[5].Visible = true;
                FlxInv.Cols[6].Caption = "Store";
                FlxInv.Cols[7].Caption = "Quantity";
                FlxInv.Cols[8].Caption = "Price";
                FlxInv.Cols[9].Caption = "Dis %";
                FlxInv.Cols[9].Visible = VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 8);
                FlxInv.Cols[27].Caption = "Validity Date";
                FlxInv.Cols[31].Caption = "Totel";
                FlxInv.Cols[35].Caption = "Make No";
                FlxInv.Cols[36].Caption = VarGeneral.Settings_Sys.LineDetailNameE;
                FlxInv.Cols[38].Caption = "Tax %";
                FlxStkQty.Cols[0].Caption = "Store";
                FlxStkQty.Cols[1].Caption = "Quantity";
                FlxStkQty.Cols[2].Caption = "Store";
                FlxDat.Cols[0].Caption = "Expir Date";
                FlxDat.Cols[1].Caption = "Quantity";
                FlxDat.Cols[2].Caption = "Make No";
                dataGridView_ItemDet.Cols[1].Caption = "Item Code";
                dataGridView_ItemDet.Cols[2].Visible = false;
                dataGridView_ItemDet.Cols[3].Visible = false;
                dataGridView_ItemDet.Cols[4].Visible = true;
                dataGridView_ItemDet.Cols[5].Visible = true;
                dataGridView_ItemDet.Cols[6].Caption = "Store";
                dataGridView_ItemDet.Cols[7].Caption = "Quantity";
                dataGridView_ItemDet.Cols[8].Caption = "Price";
            }
            if (!VarGeneral.TString.ChkStatShow(_InvSetting.TaxOptions, 0))
            {
                FlxInv.Cols[38].Visible = false;
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
                controls.Add(textBox1);
                controls.Add(textBox2);
                controls.Add(txtAddress);
                controls.Add(txtCustName);
                controls.Add(txtCustNet);
                controls.Add(txtCustNo);
                controls.Add(textBox_WaiterName);
                controls.Add(txtCustRep);
                controls.Add(txtDiscountP);
                controls.Add(txtDiscountVal);
                controls.Add(txtDiscountValLoc);
                controls.Add(txtDueAmount);
                controls.Add(txtDueAmountLoc);
                controls.Add(txtGDate);
                controls.Add(txtHDate);
                controls.Add(txtInvCost);
                controls.Add(txtItemName);
                controls.Add(txtRef);
                controls.Add(txtRemark);
                controls.Add(txtTele);
                controls.Add(txtTime);
                controls.Add(txtTotalAm);
                controls.Add(txtTotalAmLoc);
                controls.Add(txtTotalQ);
                controls.Add(CmbCostC);
                controls.Add(CmbCurr);
                controls.Add(checkBox_Chash);
                controls.Add(checkBox_NetWork);
                controls.Add(CmbInvPrice);
                controls.Add(CmbLegate);
                controls.Add(doubleInput_Rate);
                controls.Add(txtPaymentLoc);
                controls.Add(doubleInput_NetWorkLoc);
                controls.Add(doubleInput_CreditLoc);
                controls.Add(txtPersons);
                controls.Add(txtTable);
                controls.Add(txtTotTax);
                controls.Add(txtTotTaxLoc);
                controls.Add(switchButton_Tax);
                controls.Add(checkBox_CostGaidTax);
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
            }
            else
            {
                if (!data_this.RoomSts.Value)
                {
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
                if (data_this == null || data_this.InvNo == 0.ToString() || !ifOkDelete)
                {
                    return;
                }
                data_this = db.StockInvHead(VarGeneral.InvTyp, DataThis.InvNo);
                IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
                try
                {
                    db.ExecuteCommand("UPDATE [T_Rooms] SET [RomeStatus] = 0, [waiterNo] = NULL Where [RomeStatus] = 1 and ID =" + data_this.RoomNo.Value);
                    for (int i = 0; i < data_this.T_INVDETs.Count; i++)
                    {
                        if (data_this.T_INVDETs[i].ItmTyp.Value == 2)
                        {
                            for (int iicnt = 0; iicnt < data_this.T_INVDETs[i].T_SINVDETs.Count; iicnt++)
                            {
                                db_.ClearParameters();
                                db_.AddParameter("SInvDet_ID", DbType.Int32, data_this.T_INVDETs[i].T_SINVDETs[iicnt].SInvDet_ID);
                                db_.ExecuteNonQuery(storedProcedure: true, "S_T_SINVDET_DELETE");
                            }
                        }
                        db_.ClearParameters();
                        db_.AddParameter("InvDet_ID", DbType.Int32, data_this.T_INVDETs[i].InvDet_ID);
                        db_.ExecuteNonQuery(storedProcedure: true, "S_T_INVDET_DELETE");
                    }
                    try
                    {
                        db.ExecuteCommand("DELETE FROM [T_INVHED] WHERE InvHed_ID=" + data_this.InvHed_ID);
                    }
                    catch
                    {
                    }
                }
                catch (SqlException)
                {
                    data_this = db.StockInvHead(VarGeneral.InvTyp, DataThis.InvNo);
                    return;
                }
                catch (Exception)
                {
                    data_this = db.StockInvHead(VarGeneral.InvTyp, DataThis.InvNo);
                    return;
                }
                Clear();
                RefreshPKeys();
                textBox_ID.Text = PKeys.LastOrDefault();
            }
        }
        private void Button_Add_Click(object sender, EventArgs e)
        {
            if (Button_Add.Visible && Button_Add.Enabled && (State != FormState.Edit || MessageBox.Show((LangArEn == 0) ? "تم تعديل السجل الحالي دون حفظ التغييرات .. هل تريد المتابعة؟" : "Not saved the changes, do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes))
            {
                Clear();
                txtGDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                txtHDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                txtTime.Text = DateTime.Now.ToString("HH:mm");
                GetInvSetting();
                textBox_ID.Text = db.MaxInvheadNo.ToString();
                State = FormState.New;
                if (VarGeneral.SSSTyp != 0 && _InvSetting.autoTaxGaid.Value)
                {
                    checkBox_CostGaidTax.Checked = true;
                }
            }
        }
        public void RefreshPKeys()
        {
            PKeys.Clear();
            var qkeys = from item in db.T_INVHEDs
                        where item.InvTyp == (int?)VarGeneral.InvTyp
                        where item.IfDel == (int?)0
                        where item.SalsManNo == VarGeneral.UserNo
                        where item.RoomNo.HasValue
                        where item.T_Room.T_Waiter.waiter_ID == VarGeneral._WaiterID
                        where item.PaymentOrderTyp == (int?)0
                        select new
                        {
                            Code = item.InvNo + ""
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
        public void Fill_DGV_Main()
        {
            DGV_Main.PrimaryGrid.VirtualMode = true;
            Stock_DataDataContext db = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_INVHED> list = db.FillInvHead_2(VarGeneral.InvTyp, textBox_search.TextBox.Text).ToList();
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmWaiterMenue));
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
                Button_PrintTable.Text = "عــرض";
                Button_PrintTable.Tooltip = "F5";
                buttonItem_Print.Text = ((_InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1) == "0") ? "طباعة" : "عــرض");
                buttonItem_Print.Tooltip = "F5";
                Button_ExportTable2.Text = "تصدير";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "جميع السجلات";
                Label1.Text = "رقم الفاتورة :";
                Label2.Text = "التاريــــــــخ :";
                label7.Text = "رقم المرجع :";
                label19.Text = "العملــــــــة :";
                label18.Text = "المنـــــدوب :";
                label4.Text = "حساب العميــل :";
                label10.Text = "اسم العميـــــل :";
                label13.Text = "عنوان العميل :";
                label15.Text = "مركز التكلفـــــة :";
                label5.Text = "السعر المعتمــد :";
                label12.Text = "هاتف :";
                label8.Text = "نسبة الخصم";
                Label26.Text = "قيمة الخصم";
                label17.Text = "قيمة الفاتـــورة :";
                label9.Text = "صافي الفاتورة :";
                label3.Text = "بالريــال";
                superTabItem_Pay.Text = "الدفع";
                superTabItem_Note.Text = "ملاحظة";
                txtRemark.WatermarkText = "ملاحظات الفاتورة";
                label6.Text = "نقــدا\u064c :";
                label11.Text = "آجــل :";
                label14.Text = "شبكة :";
                checkBox_Chash.Text = "نقـــدي";
                button_Bac.Text = "مسج";
                button_Space.Text = "Space";
                button_DeleteLine.Text = "حذف السطر";
                btnPrevPage.Text = "سابق";
                btnNxtPage.Text = "تالي";
                buttonItem_BestSeller.Text = "أكثر مبيعا\u064c";
                checkBoxItem_BarCode.Text = "إضافة تلقائية";
                switchButton_Tax.OffText = "غير معتمد";
                switchButton_Tax.OnText = "معتمد";
                superTabItem_Tax.Text = "ضريبة";
                superTabItem_Gaids.Text = "سندات";
                switchButton_BankComm.OffText = "عدم احتساب";
                switchButton_BankComm.OnText = "احتســـاب";
                switchButton_TaxLines.OnText = "سطور الضريبة";
                switchButton_TaxLines.OffText = "سطور الضريبة";
                switchButton_TaxByTotal.OnText = "إجمالي سطر";
                switchButton_TaxByTotal.OffText = "إجمالي سطر";
                switchButton_TaxByNet.OffText = "صافي";
                switchButton_TaxByNet.OffText = "صافي";
                button_SrchCustADD.Tooltip = "إضافة عميل";
                switchButton_Lock.OffText = "لم يتم إعتماد الطلب";
                switchButton_Lock.OnText = "تم إعتماد الطلب";
                button_AddToTable.Text = "توجيه إلى";
                Text = "الطلبات المحلية";
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
                Button_PrintTable.Text = "Show";
                Button_PrintTable.Tooltip = "F5";
                buttonItem_Print.Text = ((_InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1) == "0") ? "Print" : "Show");
                buttonItem_Print.Tooltip = "F5";
                Button_ExportTable2.Text = "Export";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "All Records";
                Label1.Text = "Invoice No :";
                Label2.Text = "Date :";
                label7.Text = "Ref No :";
                label19.Text = "Currncy :";
                label18.Text = "Delegate :";
                label4.Text = "Cust Acc :";
                label10.Text = "Cust Name :";
                label13.Text = "Cust Address :";
                label15.Text = "Cost Center :";
                label5.Text = "Price Now : ";
                label12.Text = "Tel :";
                label8.Text = "Discount %";
                Label26.Text = "Dis value";
                label17.Text = "Invoice value :";
                label9.Text = "Invoice Net :";
                label3.Text = "Riyal";
                superTabItem_Pay.Text = "Paid";
                superTabItem_Note.Text = "Note";
                txtRemark.WatermarkText = "Notes";
                label6.Text = "Cash :";
                label11.Text = "Credit :";
                label14.Text = "NetWork :";
                checkBox_Chash.Text = "Cach";
                button_Bac.Text = "Clear";
                button_Space.Text = "Space";
                button_DeleteLine.Text = "DELETE LINE";
                btnPrevPage.Text = "Prev";
                btnNxtPage.Text = "Next";
                buttonItem_BestSeller.Text = "Best Seller";
                superTabItem_OrderType.Text = "Order Type";
                checkBoxItem_BarCode.Text = "Auto ADD";
                switchButton_Tax.OffText = "certified";
                switchButton_Tax.OnText = "un certified";
                superTabItem_Tax.Text = "Tax";
                superTabItem_Gaids.Text = "Bonds";
                switchButton_BankComm.OffText = "Not issuing";
                switchButton_BankComm.OnText = "issuing";
                switchButton_TaxLines.OnText = "Tax Lines";
                switchButton_TaxLines.OffText = "Tax Lines";
                switchButton_TaxByTotal.OnText = "Line Tot";
                switchButton_TaxByTotal.OffText = "Line Tot";
                switchButton_TaxByNet.OffText = "Net";
                switchButton_TaxByNet.OffText = "Net";
                button_SrchCustADD.Tooltip = "Add Customer";
                switchButton_Lock.OffText = "Order not approved";
                switchButton_Lock.OnText = "Order approved";
                button_AddToTable.Text = "Forward to";
                Text = "Local Orders";
            }
            TableTyp();
        }
        private void FrmWaiterMenue_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmWaiterMenue));
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
                    columns_Names_visible.Add("InvNo", new ColumnDictinary("رقم الفاتورة", "Invoice No", ifDefault: true, ""));
                    columns_Names_visible.Add("CusVenNm", new ColumnDictinary("إسم العميل", "Customer Name", ifDefault: true, ""));
                    columns_Names_visible.Add("SalsManNo", new ColumnDictinary("رقم البائع", "SalsMan No", ifDefault: false, ""));
                    columns_Names_visible.Add("HDat", new ColumnDictinary("التاريخ الهجري", "Date Hijri", ifDefault: true, ""));
                    columns_Names_visible.Add("GDat", new ColumnDictinary("التاريخ الميلادي", "Date Gregorian", ifDefault: true, ""));
                    columns_Names_visible.Add("InvTotLocCur", new ColumnDictinary("إجمالي الفاتورة", "Invoice Total", ifDefault: false, ""));
                    columns_Names_visible.Add("InvNetLocCur", new ColumnDictinary("صافي الفاتورة", "Invoice Net", ifDefault: true, ""));
                    columns_Names_visible.Add("InvQty", new ColumnDictinary("إجمالي الكمية", "Quantity Total", ifDefault: true, ""));
                    columns_Names_visible.Add("InvDisPrs", new ColumnDictinary("الخصم نسبة", "Discount Percentage", ifDefault: false, ""));
                    columns_Names_visible.Add("InvDisValLocCur", new ColumnDictinary("الخصم قيمة", "Discount value", ifDefault: true, ""));
                    columns_Names_visible.Add("GadeNo", new ColumnDictinary("رقم القيد المحاسبي", "Gaid No", ifDefault: false, ""));
                    columns_Names_visible.Add("CusVenAdd", new ColumnDictinary("الجوال", "Mobile", ifDefault: true, ""));
                }
                else
                {
                    Clear();
                    textBox_ID.Text = "";
                    TextBox_Index.TextBox.Text = "";
                }
                FillCat();
                FillCombo();
                GetInvSetting();
                ArbEng();
                RefreshPKeys();
                textBox_ID.Text = PKeys.FirstOrDefault();
                listUnit = new List<T_Unit>();
                listStore = new List<T_Store>();
                listUnit = db.FillUnit_2("").ToList();
                listStore = db.FillStore_2("").ToList();
                FlxStkQty.Rows.Count = listStore.Count + 1;
                string Co = "";
                for (int iiCnt = 0; iiCnt < listStore.Count; iiCnt++)
                {
                    _Store = listStore[iiCnt];
                    FlxStkQty.SetData(iiCnt + 1, 0, _Store.Stor_ID.ToString());
                    FlxStkQty.SetData(iiCnt + 1, 2, ((LangArEn == 0) ? _Store.Arb_Des : _Store.Eng_Des).ToString());
                    Co = ((!(Co != "")) ? _Store.Stor_ID.ToString() : (Co + "|" + _Store.Stor_ID));
                }
                FlxInv.Cols[6].ComboList = Co;
                int? calendr = _SysSetting.Calendr;
                if (calendr.Value == 0 && calendr.HasValue)
                {
                    txtGDate.BringToFront();
                }
                else
                {
                    txtHDate.BringToFront();
                }
                if (VarGeneral.vDemo)
                {
                    IfDelete = false;
                }
                checkBoxItem_BarCode_CheckedChanged(null, null);
                if (VarGeneral.SSSTyp == 0)
                {
                    if (VarGeneral.SSSLev == "M")
                    {
                        label4.Visible = false;
                        txtCustNo.Visible = false;
                        button_SrchCustNo.Visible = false;
                    }
                    checkBox_CostGaidTax.Visible = false;
                }
                try
                {
                    textBox_ID.ReadOnly = true;
                    if (!VarGeneral.TString.ChkStatShow(permission.SetStr, 43))
                    {
                        textBox_ID.Enabled = false;
                    }
                }
                catch
                {
                }
                UpdateVcr();
                if (VarGeneral.SSSLev == "R" || VarGeneral.SSSLev == "C" || VarGeneral.SSSLev == "H")
                {
                    superTabStripORDER.Visible = true;
                    labelTableTyp.Visible = true;
                    TableTyp();
                }
                ChangeWindowSize();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptCustBarcode.dll"))
            {
                txtCustNo.ReadOnly = false;
            }
            else
            {
                txtCustNo.ReadOnly = true;
            }
        }
        private void ChangeWindowSize()
        {
            if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 27))
            {
                base.MaximizeBox = true;
                base.WindowState = FormWindowState.Maximized;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    btnPrevPage.Text = "سابق";
                    btnNxtPage.Text = "تالي";
                    buttonItem_BestSeller.Text = "أكثر مبيعا\u064c";
                }
                else
                {
                    btnPrevPage.Text = "Prev";
                    btnNxtPage.Text = "Next";
                    buttonItem_BestSeller.Text = "Best Seller";
                }
            }
            else
            {
                base.WindowState = FormWindowState.Normal;
                btnPrevPage.Text = "";
                btnNxtPage.Text = "";
                buttonItem_BestSeller.Text = "";
            }
        }
        private void FillCat()
        {
            try
            {
                Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
                FillCombo();
                try
                {
                    itemContainer_Cat.SubItems.Clear();
                    List<T_CATEGORY> q = dbc.FillCat_2("").ToList();
                    try
                    {
                        q = q.OrderBy((T_CATEGORY c) => int.Parse(c.CAT_No)).ToList();
                    }
                    catch
                    {
                    }
                    if (q.Count > 0)
                    {
                        q.Insert(0, new T_CATEGORY());
                    }
                    for (int i = 0; i < q.Count; i++)
                    {
                        MetroTileItem vCat = new MetroTileItem();
                        try
                        {
                            if (q[i] == null || q[i].CAT_ID == 0)
                            {
                                vCat.SymbolColor = Color.Empty;
                                vCat.TileColor = eMetroTileColor.Orange;
                                vCat.TileSize = new Size(125, 45);
                                vCat.TileStyle.CornerType = eCornerType.Rounded;
                                vCat.TitleText = ((LangArEn == 0) ? "الكــل" : "ALL");
                                vCat.Tag = 0;
                                vCat.TitleTextAlignment = ContentAlignment.MiddleCenter;
                                vCat.TitleTextColor = Color.White;
                                vCat.TitleTextFont = new Font("Tahoma", 6f, FontStyle.Bold, GraphicsUnit.Point, 0);
                                itemContainer_Cat.SubItems.AddRange(new BaseItem[1]
                                {
                                    vCat
                                });
                            }
                            else
                            {
                                vCat.SymbolColor = Color.Empty;
                                vCat.TileColor = eMetroTileColor.Blueish;
                                vCat.TileSize = new Size(125, 45);
                                vCat.TileStyle.CornerType = eCornerType.Rounded;
                                vCat.TitleText = ((LangArEn == 0) ? q[i].Arb_Des : q[i].Eng_Des);
                                vCat.Tag = q[i].CAT_ID;
                                vCat.TitleTextAlignment = ContentAlignment.MiddleCenter;
                                vCat.TitleTextColor = Color.White;
                                vCat.TitleTextFont = new Font("Tahoma", 6f, FontStyle.Bold, GraphicsUnit.Point, 0);
                                itemContainer_Cat.SubItems.AddRange(new BaseItem[1]
                                {
                                    vCat
                                });
                            }
                        }
                        catch
                        {
                        }
                    }
                    Refresh();
                    ItemsMainSetting();
                }
                catch (Exception error)
                {
                    VarGeneral.DebLog.writeLog("FillCat:", error, enable: true);
                    ItemsMainSetting();
                    Refresh();
                }
            }
            catch
            {
            }
        }
        private void ItemsMainSetting()
        {
            try
            {
                superGridControl1.PrimaryGrid.Columns.Clear();
                superGridControl1.PrimaryGrid.Rows.Clear();
                col = superGridControl1.Width / 130;
                colW = superGridControl1.Width / col;
                row = superGridControl1.Height / 130;
                rowH = superGridControl1.Height / row;
                if (base.WindowState == FormWindowState.Normal)
                {
                    col = 2;
                    colW = superGridControl1.Width / col;
                    row = superGridControl1.Height / 130;
                    rowH = superGridControl1.Height / row;
                }
                PageSize = Math.Abs(col * row);
                for (int i = 0; i < col; i++)
                {
                    GridColumn q = new GridColumn();
                    q.Width = colW;
                    superGridControl1.PrimaryGrid.Columns.Add(q);
                }
                for (int i = 0; i < row; i++)
                {
                    GridRow c = new GridRow();
                    c.RowHeight = rowH / 2 + rowH * 25 / 100;
                    c.RowStyles.Default.Background.Color1 = Color.AliceBlue;
                    for (int j = 0; j < col; j++)
                    {
                        c.Cells.Add(new GridCell(""));
                    }
                    superGridControl1.PrimaryGrid.Rows.Add(c);
                    GridRow cc = new GridRow();
                    cc.RowHeight = rowH / 4;
                    cc.RowStyles.Default.Background.Color1 = Color.AliceBlue;
                    for (int j = 0; j < col; j++)
                    {
                        cc.Cells.Add(new GridCell(""));
                        cc.Cells.LastOrDefault().EditorType = typeof(GridButtonXEditControl);
                        if (base.WindowState == FormWindowState.Normal)
                        {
                            cc.CellStyles.Default.Font = new Font("Tahoma", 6f, FontStyle.Bold);
                        }
                    }
                    superGridControl1.PrimaryGrid.Rows.Add(cc);
                }
            }
            catch
            {
            }
            ItmMainParameter = "";
            FillItmesMain(null, vBestSaller: false);
        }
        private void Button_ExportTable2_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcel.ExportToExcel(DGV_Main, "تقرير فواتير المبيعات");
            }
            catch
            {
            }
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
                var q = db.StockInvHead(VarGeneral.InvTyp, crow.Cells["InvNo"].Value.ToString()).T_INVDETs.Select((T_INVDET item) => new
                {
                    item.ItmNo,
                    item.ItmDes,
                    item.ItmDesE,
                    item.ItmUnt,
                    item.ItmUntE,
                    item.StoreNo,
                    item.Cost,
                    item.Qty,
                    item.Price,
                    item.ItmDis,
                    item.Amount
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
            panel.Columns["InvNo"].Width = 150;
            panel.Columns["InvNo"].Visible = columns_Names_visible["InvNo"].IfDefault;
            panel.Columns["CusVenNm"].Width = 250;
            panel.Columns["CusVenNm"].Visible = columns_Names_visible["CusVenNm"].IfDefault;
            panel.Columns["SalsManNo"].Width = 100;
            panel.Columns["SalsManNo"].Visible = columns_Names_visible["SalsManNo"].IfDefault;
            panel.Columns["HDat"].Width = 100;
            panel.Columns["HDat"].Visible = columns_Names_visible["HDat"].IfDefault;
            panel.Columns["GDat"].Width = 100;
            panel.Columns["GDat"].Visible = columns_Names_visible["GDat"].IfDefault;
            panel.Columns["InvTotLocCur"].Width = 150;
            panel.Columns["InvTotLocCur"].Visible = columns_Names_visible["InvTotLocCur"].IfDefault;
            panel.Columns["InvNetLocCur"].Width = 150;
            panel.Columns["InvNetLocCur"].Visible = columns_Names_visible["InvNetLocCur"].IfDefault;
            panel.Columns["InvQty"].Width = 150;
            panel.Columns["InvQty"].Visible = columns_Names_visible["InvQty"].IfDefault;
            panel.Columns["InvDisPrs"].Width = 100;
            panel.Columns["InvDisPrs"].Visible = columns_Names_visible["InvDisPrs"].IfDefault;
            panel.Columns["InvDisValLocCur"].Width = 100;
            panel.Columns["InvDisValLocCur"].Visible = columns_Names_visible["InvDisValLocCur"].IfDefault;
            panel.Columns["CusVenAdd"].Width = 400;
            panel.Columns["CusVenAdd"].Visible = columns_Names_visible["CusVenAdd"].IfDefault;
            panel.Columns["GadeNo"].Width = 130;
            panel.Columns["GadeNo"].Visible = columns_Names_visible["GadeNo"].IfDefault;
        }
        private void PropLOfferPanel(GridPanel panel)
        {
            panel.ColumnAutoSizeMode = ColumnAutoSizeMode.DisplayedCells;
            panel.Columns["ItmNo"].HeaderText = ((LangArEn == 0) ? "رقم الصنف" : "Item No");
            panel.Columns["ItmDes"].HeaderText = ((LangArEn == 0) ? "الوصف " : "Description");
            panel.Columns["ItmDesE"].HeaderText = ((LangArEn == 0) ? "الوصف" : "Description");
            panel.Columns["ItmUnt"].HeaderText = ((LangArEn == 0) ? "الوحدة" : "Unit");
            panel.Columns["ItmUntE"].HeaderText = ((LangArEn == 0) ? "الوحدة" : "Unit");
            panel.Columns["StoreNo"].HeaderText = ((LangArEn == 0) ? "المستودع" : "Store");
            panel.Columns["Qty"].HeaderText = ((LangArEn == 0) ? "الكمية" : "Qrt.");
            panel.Columns["Cost"].HeaderText = ((LangArEn == 0) ? "التكلفة" : "Cost");
            panel.Columns["Price"].HeaderText = ((LangArEn == 0) ? "السعر" : "Price");
            panel.Columns["ItmDis"].HeaderText = ((LangArEn == 0) ? "الخصم" : "Discount");
            panel.Columns["Amount"].HeaderText = ((LangArEn == 0) ? "الاجمالي" : "Total");
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
                panel.Columns["ItmDesE"].Visible = false;
                panel.Columns["ItmUntE"].Visible = false;
                panel.Columns["ItmDes"].Visible = true;
                panel.Columns["ItmUnt"].Visible = true;
            }
            else
            {
                panel.Columns["ItmDes"].Visible = false;
                panel.Columns["ItmUnt"].Visible = false;
                panel.Columns["ItmDesE"].Visible = true;
                panel.Columns["ItmUntE"].Visible = true;
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
                    string txtId = textBox_ID.Text;
                    if (isPrintSts)
                    {
                        _PrintInv(data_this.InvHed_ID, data_this.SalsManNo);
                    }
                    State = FormState.Saved;
                    RefreshPKeys();
                    TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(data_this.InvNo ?? "") + 1);
                    SetReadOnly = true;
                    checkBoxItem_BarCode_CheckedChanged(null, null);
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
            _InvSetting = db.StockInvSetting(VarGeneral.UserID, VarGeneral.InvTyp);
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
                T_INVHED newData = db.StockInvHead(VarGeneral.InvTyp, no);
                if (newData == null || string.IsNullOrEmpty(newData.InvNo))
                {
                    if (!Button_Add.Visible || !Button_Add.Enabled)
                    {
                        textBox_ID.TextChanged -= textBox_ID_TextChanged;
                        try
                        {
                            textBox_ID.Text = data_this.InvNo;
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
                    int indexA = PKeys.IndexOf(newData.InvNo ?? "");
                    indexA++;
                    TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                    TextBox_Index.TextBox.Text = string.Concat(indexA);
                    TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                }
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
                if (VarGeneral.CheckDate(txtHDate.Text))
                {
                    txtHDate.Text = Convert.ToDateTime(txtHDate.Text).ToString("yyyy/MM/dd");
                    txtHDate.Text = n.FormatHijri(txtHDate.Text, "yyyy/MM/dd");
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 77))
                    {
                        txtGDate.Text = n.HijriToGreg(txtHDate.Text, "yyyy/MM/dd");
                    }
                }
                else
                {
                    txtHDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                }
            }
            catch
            {
                txtHDate.Text = "";
            }
        }
        private void txtGDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtGDate.Text))
                {
                    txtGDate.Text = Convert.ToDateTime(txtGDate.Text).ToString("yyyy/MM/dd");
                    txtGDate.Text = n.FormatGreg(txtGDate.Text, "yyyy/MM/dd");
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 77))
                    {
                        txtHDate.Text = n.GregToHijri(txtGDate.Text, "yyyy/MM/dd");
                    }
                }
                else
                {
                    txtGDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                }
            }
            catch
            {
                txtGDate.Text = "";
            }
        }
        private void Frm_KeyPress(object sender, KeyPressEventArgs e)
        {
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
            else if (e.KeyCode == Keys.F10 && Button_ExportTable2.Enabled && Button_ExportTable2.Visible && !expandableSplitter1.Expanded)
            {
                Button_ExportTable2_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F5)
            {
                if (expandableSplitter1.Expanded && buttonItem_Print.Enabled && buttonItem_Print.Visible && State == FormState.Saved)
                {
                    buttonItem_Print_Click(sender, e);
                }
                else if (Button_PrintTable.Enabled && Button_PrintTable.Visible && !expandableSplitter1.Expanded)
                {
                    Button_Print_Click(sender, e);
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
                    if (int.Parse(Label_Count.Text) > 0 && !checkBoxItem_BarCode.Checked)
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
        private void FlxInv_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            ControlNo = 0;
            CheckSts(ControlNo);
            try
            {
                if (FlxInv.Row <= 0 || !VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 66))
                {
                    return;
                }
                int vRowIndex = FlxInv.Row;
                if (FlxInv.Rows[vRowIndex].Height != 33)
                {
                    return;
                }
                FrmInvDetNoteSrch frm = new FrmInvDetNoteSrch();
                frm.Tag = LangArEn;
                try
                {
                    frm.textbox_Detailes.Text = FlxInv.GetData(vRowIndex, 2).ToString() ?? "";
                }
                catch
                {
                    frm.textbox_Detailes.Text = "";
                }
                frm.TopMost = true;
                frm.ShowDialog();
                if (!(frm.SerachNo != ""))
                {
                    return;
                }
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    FlxInv.Row = vRowIndex;
                    FlxInv.RowSel = vRowIndex;
                    FlxInv.Col = 2;
                    FlxInv.ColSel = 2;
                    FlxInv.SetData(vRowIndex, 2, "");
                    FlxInv.SetData(vRowIndex, 2, FlxInv.GetData(vRowIndex, 2).ToString() + frm.SerachNo);
                    try
                    {
                        FlxInv.SetData(vRowIndex - 1, 36, FlxInv.GetData(vRowIndex, 2).ToString());
                    }
                    catch
                    {
                    }
                }
                else
                {
                    FlxInv.Row = vRowIndex;
                    FlxInv.RowSel = vRowIndex;
                    FlxInv.Col = 4;
                    FlxInv.ColSel = 4;
                    FlxInv.SetData(vRowIndex, 4, "");
                    FlxInv.SetData(vRowIndex, 4, FlxInv.GetData(vRowIndex, 4).ToString() + frm.SerachNo);
                    try
                    {
                        FlxInv.SetData(vRowIndex - 1, 36, FlxInv.GetData(vRowIndex, 4).ToString());
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
        private void FillComboMnd()
        {
            try
            {
                CmbLegate.DataSource = null;
            }
            catch
            {
            }
            try
            {
                CmbLegate.Items.Clear();
            }
            catch
            {
            }
            int _CmbIndex = CmbLegate.SelectedIndex;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                List<T_Mndob> listMnd = new List<T_Mndob>(db.T_Mndobs.Where((T_Mndob item) => item.Mnd_Typ == (int?)0).ToList());
                listMnd.Insert(0, new T_Mndob());
                CmbLegate.DataSource = listMnd;
                CmbLegate.DisplayMember = "Arb_Des";
                CmbLegate.ValueMember = "Mnd_ID";
            }
            else
            {
                List<T_Mndob> listMnd = new List<T_Mndob>(db.T_Mndobs.Where((T_Mndob item) => item.Mnd_Typ == (int?)0).ToList());
                listMnd.Insert(0, new T_Mndob());
                CmbLegate.DataSource = listMnd;
                CmbLegate.DisplayMember = "Eng_Des";
                CmbLegate.ValueMember = "Mnd_ID";
            }
            CmbLegate.SelectedIndex = _CmbIndex;
        }
        private void FillCombo()
        {
            int _CmbIndex = CmbInvPrice.SelectedIndex;
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
            CmbInvPrice.SelectedIndex = _CmbIndex;
            _CmbIndex = CmbCurr.SelectedIndex;
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
            CmbCurr.SelectedIndex = _CmbIndex;
            _CmbIndex = CmbCostC.SelectedIndex;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                List<T_CstTbl> listCs = new List<T_CstTbl>(db.T_CstTbls.Select((T_CstTbl item) => item).ToList());
                CmbCostC.DataSource = listCs;
                CmbCostC.DisplayMember = "Arb_Des";
                CmbCostC.ValueMember = "Cst_ID";
            }
            else
            {
                List<T_CstTbl> listCs = new List<T_CstTbl>(db.T_CstTbls.Select((T_CstTbl item) => item).ToList());
                CmbCostC.DataSource = listCs;
                CmbCostC.DisplayMember = "Eng_Des";
                CmbCostC.ValueMember = "Cst_ID";
            }
            CmbCostC.SelectedIndex = _CmbIndex;
            FillComboMnd();
        }
        public void SetData(T_INVHED value)
        {
            switchButton_Lock.ValueChanged -= switchButton_Lock_ValueChanged;
            try
            {
                try
                {
                    dataGridView_ItemDet.Clear(ClearFlags.Content, 1, 1, dataGridView_ItemDet.Rows.Count - 1, 34);
                }
                catch
                {
                }
                dataGridView_ItemDet.Rows.Count = 1;
                dataGridView_ItemDet.Visible = false;
                State = FormState.Saved;
                Button_Save.Enabled = false;
                textBox_ID.Tag = value.InvHed_ID;
                txtCustNo.Text = value.CusVenNo.ToString();
                button_AddToTable.Visible = false;
                try
                {
                    if (!string.IsNullOrEmpty(value.CusVenNo))
                    {
                        txtCustName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(value.CusVenNo).Arb_Des : db.StockAccDefWithOutBalance(value.CusVenNo).Eng_Des);
                    }
                    else
                    {
                        txtCustName.Text = value.CusVenNm.ToString();
                    }
                }
                catch
                {
                    txtCustName.Text = value.CusVenNm.ToString();
                }
                try
                {
                    if (value.RoomNo > 1 && value.RoomSts.Value)
                    {
                        if (value.T_Room.waiterNo.HasValue)
                        {
                            textBox_WaiterName.Text = ((LangArEn == 0) ? db.StockWaiterID(value.T_Room.waiterNo.Value).Arb_Des : db.StockWaiterID(value.T_Room.waiterNo.Value).Eng_Des);
                            textBox_WaiterName.Tag = value.T_Room.waiterNo.Value.ToString();
                        }
                        else
                        {
                            textBox_WaiterName.Tag = "";
                            textBox_WaiterName.Text = "";
                        }
                    }
                    else
                    {
                        textBox_WaiterName.Tag = "";
                        textBox_WaiterName.Text = "";
                    }
                }
                catch
                {
                    textBox_WaiterName.Tag = "";
                    textBox_WaiterName.Text = "";
                }
                if (VarGeneral.SSSLev == "M")
                {
                    txtCustNo.Text = "";
                }
                txtAddress.Text = value.CusVenAdd;
                txtTele.Text = value.CusVenTel;
                txtRemark.Text = value.Remark;
                txtDiscountP.Value = value.InvDisPrs.Value;
                txtDiscountVal.Value = value.InvDisVal.Value;
                txtDiscountValLoc.Value = value.InvDisValLocCur.Value;
                txtDueAmount.Value = value.InvNet.Value;
                txtDueAmountLoc.Value = value.InvNetLocCur.Value;
                try
                {
                    if (VarGeneral.CheckDate(value.GDat))
                    {
                        txtGDate.Text = Convert.ToDateTime(value.GDat).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        txtGDate.Text = n.FormatGreg(value.GDat, "yyyy/MM/dd");
                    }
                }
                catch
                {
                    txtGDate.Text = value.GDat;
                }
                try
                {
                    if (VarGeneral.CheckDate(value.HDat))
                    {
                        txtHDate.Text = Convert.ToDateTime(value.HDat).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        txtHDate.Text = n.FormatHijri(value.HDat, "yyyy/MM/dd");
                    }
                }
                catch
                {
                    txtHDate.Text = value.HDat;
                }
                txtRef.Text = value.RefNo;
                switchButton_Lock.Value = value.AdminLock.Value;
                FillComboMnd();
                if (VarGeneral.CheckTime(value.LTim))
                {
                    txtTime.Text = value.LTim;
                }
                txtTotalAm.Value = value.InvTot.Value;
                txtTotalAmLoc.Value = value.InvTotLocCur.Value;
                txtTotalQ.Value = value.InvQty.Value;
                txtCustNet.Value = value.CustNet.Value;
                txtCustRep.Value = value.CustRep.Value;
                for (int iiCnt = 0; iiCnt < CmbCostC.Items.Count; iiCnt++)
                {
                    CmbCostC.SelectedIndex = iiCnt;
                    if (CmbCostC.SelectedValue != null && CmbCostC.SelectedValue.ToString() == value.InvCstNo.Value.ToString())
                    {
                        break;
                    }
                }
                for (int iiCnt = 0; iiCnt < CmbCurr.Items.Count; iiCnt++)
                {
                    CmbCurr.SelectedIndex = iiCnt;
                    if (CmbCurr.SelectedValue != null && CmbCurr.SelectedValue.ToString() == value.CurTyp.Value.ToString())
                    {
                        break;
                    }
                }
                if (CmbCurr.SelectedIndex != -1)
                {
                    RateValue = db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value;
                }
                if (value.MndNo.HasValue)
                {
                    CmbLegate.SelectedValue = value.MndNo;
                }
                else
                {
                    CmbLegate.SelectedIndex = 0;
                }
                if (value.CustPri.HasValue)
                {
                    CmbInvPrice.SelectedIndex = value.CustPri.Value;
                }
                checkBox_Chash.Checked = true;
                txtPaymentLoc.Value = value.CashPayLocCur.Value;
                doubleInput_NetWorkLoc.Value = value.NetworkPayLocCur.Value;
                doubleInput_CreditLoc.Value = value.CreditPayLocCur.Value;
                txtTotTax.Value = value.InvAddTax.Value;
                txtTotTaxLoc.Value = value.InvAddTaxlLoc.Value;
                switchButton_Tax.ValueChanged -= switchButton_Tax_ValueChanged;
                if (value.IsTaxUse.Value)
                {
                    switchButton_Tax.Value = true;
                }
                else
                {
                    switchButton_Tax.Value = false;
                }
                switchButton_Tax.ValueChanged += switchButton_Tax_ValueChanged;
                switchButton_TaxLines.ValueChanged -= switchButton_TaxLines_ValueChanged;
                if (value.IsTaxLines.Value)
                {
                    switchButton_TaxLines.Value = true;
                }
                else
                {
                    switchButton_TaxLines.Value = false;
                }
                if (value.IsTaxByTotal.Value)
                {
                    switchButton_TaxByTotal.Value = true;
                }
                else
                {
                    switchButton_TaxByTotal.Value = false;
                }
                if (value.IsTaxByNet.Value)
                {
                    switchButton_TaxByNet.Value = true;
                }
                else
                {
                    switchButton_TaxByNet.Value = false;
                }
                if (value.IsTaxGaid.HasValue)
                {
                    checkBox_CostGaidTax.Checked = value.IsTaxGaid.Value;
                }
                else
                {
                    checkBox_CostGaidTax_CheckedChanged(null, null);
                }
                textBoxItem_TaxByNetValue.Text = value.TaxByNetValue.Value.ToString();
                switchButton_TaxLines.ValueChanged += switchButton_TaxLines_ValueChanged;
                LDataThis = new BindingList<T_INVDET>(value.T_INVDETs).ToList();
                if (value.RoomNo.HasValue)
                {
                    txtTable.Tag = value.RoomNo.Value;
                    txtTable.Value = int.Parse(db.StockRommID(value.RoomNo.Value).RomeNo.ToString());
                }
                else
                {
                    txtTable.Tag = "1";
                    txtTable.Value = 0;
                }
                txtPersons.Value = value.RoomPerson.Value;
                SetLines(LDataThis);
                TableTyp();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SetData:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            switchButton_Lock.ValueChanged += switchButton_Lock_ValueChanged;
        }
        public void SetLines(List<T_INVDET> listDet)
        {
            try
            {
                FlxInv.Rows.Count = 1;
                FlxInv.Rows.Count = listDet.Count * 2 + 1;
                FlxInv.Cols[27].Visible = false;
                FlxInv.Cols[35].Visible = false;
                int i = 0;
                for (int iiCnt = 1; iiCnt <= FlxInv.Rows.Count; iiCnt += 2)
                {
                    if (i >= listDet.Count)
                    {
                        break;
                    }
                    _InvDet = listDet[i];
                    FlxInv.Rows[iiCnt].Height = 35;
                    int Ser = _InvDet.InvSer.GetValueOrDefault();
                    FlxInv.SetData(iiCnt, 0, Ser.ToString());
                    FlxInv.SetData(iiCnt, 1, _InvDet.ItmNo.Trim());
                    FlxInv.SetData(iiCnt, 2, _InvDet.ItmDes.ToString());
                    FlxInv.SetData(iiCnt, 3, _InvDet.ItmUnt.ToString());
                    FlxInv.SetData(iiCnt, 4, _InvDet.ItmDesE.ToString());
                    FlxInv.SetData(iiCnt, 5, _InvDet.ItmUntE.ToString());
                    FlxInv.SetData(iiCnt, 6, _InvDet.StoreNo.Value);
                    FlxInv.SetData(iiCnt, 7, Math.Abs((decimal)_InvDet.Qty.Value));
                    FlxInv.SetData(iiCnt, 8, _InvDet.Price.Value);
                    FlxInv.SetData(iiCnt, 9, _InvDet.ItmDis);
                    FlxInv.SetData(iiCnt, 10, _InvDet.Cost.Value);
                    FlxInv.SetData(iiCnt, 11, _InvDet.ItmUntPak.Value);
                    FlxInv.SetData(iiCnt, 12, Math.Abs((decimal)_InvDet.RealQty.Value));
                    FlxInv.SetData(iiCnt, 13, _InvDet.itmInvDsc.Value);
                    FlxInv.SetData(iiCnt, 14, _InvDet.Cost.Value);
                    FlxInv.SetData(iiCnt, 15, _InvDet.ItmDes.ToString());
                    FlxInv.SetData(iiCnt, 16, _InvDet.Cost.Value);
                    FlxInv.SetData(iiCnt, 18, _InvDet.T_Item.DefultUnit.Value);
                    FlxInv.SetData(iiCnt, 19, _InvDet.T_Item.Price1.Value);
                    FlxInv.SetData(iiCnt, 20, _InvDet.T_Item.Price2.Value);
                    FlxInv.SetData(iiCnt, 21, _InvDet.T_Item.Price3.Value);
                    FlxInv.SetData(iiCnt, 22, _InvDet.T_Item.Price4.Value);
                    FlxInv.SetData(iiCnt, 23, _InvDet.T_Item.Price5.Value);
                    FlxInv.SetData(iiCnt, 25, _InvDet.InvDet_ID);
                    FlxInv.SetData(iiCnt, 27, _InvDet.DatExper ?? "");
                    if ((_InvDet.DatExper ?? "") != "" || (_InvDet.RunCod ?? "") != "")
                    {
                        FlxInv.Cols[27].Visible = true;
                        FlxInv.Cols[35].Visible = true;
                        FlxInv.SetData(iiCnt, 28, 1);
                    }
                    try
                    {
                        FlxInv.SetData(iiCnt, 33, (_InvDet.ItmWight.Value != 0.0) ? true : false);
                    }
                    catch
                    {
                        FlxInv.SetData(iiCnt, 33, false);
                    }
                    FlxInv.SetData(iiCnt, 32, _InvDet.ItmTyp.Value);
                    FlxInv.SetData(iiCnt, 31, _InvDet.Amount.Value);
                    FlxInv.SetData(iiCnt, 35, _InvDet.RunCod.Trim());
                    FlxInv.SetData(iiCnt, 36, _InvDet.LineDetails.Trim());
                    FlxInv.SetData(iiCnt, 38, _InvDet.ItmTax.Value);
                    listStkQty = (from t in db.T_STKSQTies
                                  where t.storeNo == (int?)_InvDet.StoreNo.Value
                                  where t.itmNo == _InvDet.ItmNo.Trim()
                                  select t).ToList();
                    if (listStkQty.Count != 0)
                    {
                        _StksQty = listStkQty[0];
                        FlxInv.SetData(iiCnt, 24, _InvDet.RealQty.Value + _StksQty.stkQty.Value);
                    }
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        FlxInv.MergedRanges.Add(FlxInv.GetCellRange(iiCnt + 1, 37, iiCnt + 1, 2));
                    }
                    else
                    {
                        FlxInv.MergedRanges.Add(FlxInv.GetCellRange(iiCnt + 1, 37, iiCnt + 1, 4));
                    }
                    FlxInv.Rows[iiCnt + 1].Height = 33;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        FlxInv.SetData(iiCnt + 1, 2, _InvDet.LineDetails);
                    }
                    else
                    {
                        FlxInv.SetData(iiCnt + 1, 4, _InvDet.LineDetails);
                    }
                    if (!VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 26))
                    {
                        FlxInv.Rows[iiCnt + 1].Visible = false;
                    }
                    i++;
                }
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "حدث خطأ أثناء تعبئة الأسطر .." : "An error occurred while filling lines ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        public void SetLinesDET(List<T_SINVDET> listDet, int vRow)
        {
            try
            {
                dataGridView_ItemDet.Rows.Count = listDet.Count + 1;
                dataGridView_ItemDet.Cols[27].Visible = false;
                for (int iiCnt = 1; iiCnt <= listDet.Count; iiCnt++)
                {
                    T_SINVDET _SInvDet = listDet[iiCnt - 1];
                    int Ser = _SInvDet.SInvSer.GetValueOrDefault();
                    dataGridView_ItemDet.SetData(iiCnt, 0, Ser.ToString());
                    dataGridView_ItemDet.SetData(iiCnt, 1, _SInvDet.SItmNo.Trim());
                    dataGridView_ItemDet.SetData(iiCnt, 2, _SInvDet.SItmDes.ToString());
                    dataGridView_ItemDet.SetData(iiCnt, 3, _SInvDet.SItmUnt.ToString());
                    dataGridView_ItemDet.SetData(iiCnt, 4, _SInvDet.SItmDesE.ToString());
                    dataGridView_ItemDet.SetData(iiCnt, 5, _SInvDet.SItmUntE.ToString());
                    dataGridView_ItemDet.SetData(iiCnt, 6, _SInvDet.SStoreNo.Value);
                    dataGridView_ItemDet.SetData(iiCnt, 7, Math.Abs((decimal)_SInvDet.SQty.Value));
                    dataGridView_ItemDet.SetData(iiCnt, 8, _SInvDet.SPrice.Value);
                    dataGridView_ItemDet.SetData(iiCnt, 9, _SInvDet.SItmDis);
                    dataGridView_ItemDet.SetData(iiCnt, 10, _SInvDet.SCost.Value);
                    dataGridView_ItemDet.SetData(iiCnt, 11, _SInvDet.SItmUntPak.Value);
                    dataGridView_ItemDet.SetData(iiCnt, 12, Math.Abs((decimal)_SInvDet.SRealQty.Value));
                    dataGridView_ItemDet.SetData(iiCnt, 13, _SInvDet.SitmInvDsc.Value);
                    dataGridView_ItemDet.SetData(iiCnt, 14, _SInvDet.SCost.Value);
                    dataGridView_ItemDet.SetData(iiCnt, 15, _SInvDet.SItmDes.ToString());
                    dataGridView_ItemDet.SetData(iiCnt, 16, _SInvDet.SCost.Value);
                    dataGridView_ItemDet.SetData(iiCnt, 18, _SInvDet.T_Item.DefultUnit.Value);
                    dataGridView_ItemDet.SetData(iiCnt, 19, _SInvDet.T_Item.Price1.Value);
                    dataGridView_ItemDet.SetData(iiCnt, 20, _SInvDet.T_Item.Price2.Value);
                    dataGridView_ItemDet.SetData(iiCnt, 21, _SInvDet.T_Item.Price3.Value);
                    dataGridView_ItemDet.SetData(iiCnt, 22, _SInvDet.T_Item.Price4.Value);
                    dataGridView_ItemDet.SetData(iiCnt, 23, _SInvDet.T_Item.Price5.Value);
                    dataGridView_ItemDet.SetData(iiCnt, 25, _SInvDet.SInvDet_ID);
                    dataGridView_ItemDet.SetData(iiCnt, 27, _SInvDet.SDatExper ?? "");
                    dataGridView_ItemDet.SetData(iiCnt, 32, _SInvDet.SItmTyp.Value);
                    dataGridView_ItemDet.SetData(iiCnt, 31, _SInvDet.SAmount.Value);
                    dataGridView_ItemDet.SetData(iiCnt, 29, _SInvDet.SQtyDef.Value);
                    dataGridView_ItemDet.SetData(iiCnt, 17, _SInvDet.SPriceDef.Value);
                    listStkQty = (from t in db.T_STKSQTies
                                  where t.storeNo == (int?)_SInvDet.SStoreNo.Value
                                  where t.itmNo == _SInvDet.SItmNo.Trim()
                                  select t).ToList();
                    if (listStkQty.Count != 0)
                    {
                        _StksQty = listStkQty[0];
                        dataGridView_ItemDet.SetData(iiCnt, 24, _SInvDet.SRealQty.Value + _StksQty.stkQty.Value);
                    }
                }
                if (State == FormState.Saved)
                {
                    return;
                }
                double InvCost = 0.0;
                for (int i = 1; i < dataGridView_ItemDet.Rows.Count; i++)
                {
                    try
                    {
                        dataGridView_ItemDet.SetData(i, 7, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(i, 29)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(vRow, 7)))));
                        dataGridView_ItemDet.SetData(i, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(i, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(i, 17)))));
                        dataGridView_ItemDet.SetData(i, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(i, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(i, 11)))));
                        InvCost += double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(i, 10)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(i, 12))));
                    }
                    catch
                    {
                    }
                }
                FlxInv.SetData(vRow, 10, InvCost);
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "حدث خطأ أثناء تعبئة الأسطر الفرعية .." : "An error occurred while filling lines ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private bool ValidData()
        {
            if (textBox_ID.Text == "0" || textBox_ID.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ بدون رقم الفاتورة - السند" : "Can not save without the invoice number", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_ID.Focus();
                return false;
            }
            if (!VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 9) && (txtDueAmountLoc.Value == 0.0 || txtDueAmountLoc.Value == 0.0))
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ والصافي يساوي صفر" : "Can not save, and the total is equal to zero", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (txtTotalQ.Value <= 0.0)
            {
                MessageBox.Show((LangArEn == 0) ? "يجب ان لا يكون الكمية فارغة .. يرجى التأكد من وجود الأصناف في الفاتورة" : "We must not be empty value .. Please make sure there are items in the bill.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (txtPaymentLoc.Value + doubleInput_NetWorkLoc.Value + doubleInput_CreditLoc.Value != (checkBox_CostGaidTax.Checked ? (txtDueAmountLoc.Value - txtTotTax.Value) : txtDueAmountLoc.Value))
            {
                MessageBox.Show((LangArEn == 0) ? "يجب ان يكون مجموع المدفوعات النقدية والآجلة مساوية لصافي الفاتورة .. يرجى التاكد من المدفوعات!" : "You must be the total cash payments and futures is equal to the net invoice .. Please confirm the payments!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                superTabControl_Info.SelectedTabIndex = 1;
                txtPaymentLoc.Focus();
                return false;
            }
            if (!VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 9) && checkBox_Chash.Checked && txtPaymentLoc.Value <= 0.0 && doubleInput_NetWorkLoc.Value <= 0.0)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن الحفظ كفاتورة نقدية واجمالي المدفوعات النقدية أصغر من او يساوي الصفر " : "You can not save a bill in cash and total cash payments smaller than or equal to zero", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtPaymentLoc.Focus();
                return false;
            }
            if (State == FormState.Edit)
            {
                T_INVHED newData = db.StockInvHead(VarGeneral.InvTyp, textBox_ID.Text);
                if ((!string.IsNullOrEmpty(newData.InvNo) || newData.InvHed_ID > 0) && newData.InvHed_ID != data_this.InvHed_ID)
                {
                    MessageBox.Show((LangArEn == 0) ? " رقم الفاتورة مكرر يرجى تغييره" : "Employee No It's a existing", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_ID.Focus();
                    return false;
                }
            }
            if (checkBox_CostGaidTax.Checked && txtTotTax.Value <= 0.0)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن انشاء سند محاسبي بقيمة الضريبة واجمالي الضريبة يساوي صفر" : "You can not set up an accounting support tax and the total tax is equal to zero.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                superTabControl_Info.SelectedTabIndex = 3;
                return false;
            }
            for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
            {
                if (!(string.Concat(FlxInv.GetData(iiCnt, 1)) != ""))
                {
                    continue;
                }
                for (int i = 1; i < 7; i++)
                {
                    if (string.Concat(FlxInv.GetData(iiCnt, i)) == "")
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من تعبئة جميع البيانات المطلوبة" : "We must not be empty value .. Please make sure there are items in the bill.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        FlxInv.Row = iiCnt;
                        FlxInv.Col = i;
                        FlxInv.Focus();
                        return false;
                    }
                }
                if (VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7))) == "0")
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب ان لا يكون الكمية فارغة .. يرجى التأكد من وجود الأصناف في الفاتورة" : "We must not be empty value .. Please make sure there are items in the bill.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    FlxInv.Row = iiCnt;
                    FlxInv.Col = 7;
                    FlxInv.Focus();
                    return false;
                }
                if (FlxInv.Cols[27].Visible)
                {
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 7) && VarGeneral.CheckDate(string.Concat(FlxInv.GetData(iiCnt, 27))) && string.Concat(FlxInv.GetData(iiCnt, 35)) == "")
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن حفظ تاريخ الصلاحية بدون رقم التصنيع .. الرجاء مراجعة صلاحيات المستخدم" : "Can not save the expiration date without Make No .. please see User Permissions", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        FlxInv.Row = iiCnt;
                        FlxInv.Col = 35;
                        FlxInv.Focus();
                        return false;
                    }
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 8) && !VarGeneral.CheckDate(string.Concat(FlxInv.GetData(iiCnt, 27))) && string.Concat(FlxInv.GetData(iiCnt, 35)) != "")
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن حفظ رقم التصنيع بدون تاريخ الصلاحية .. الرجاء مراجعة صلاحيات المستخدم" : "Can not save the Make No without expiration date .. please see User Permissions", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        FlxInv.Row = iiCnt;
                        FlxInv.Col = 27;
                        FlxInv.Focus();
                        return false;
                    }
                }
            }
            if (!VarGeneral.CheckDate(txtGDate.Text))
            {
                txtGDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
            }
            if (!VarGeneral.CheckDate(txtHDate.Text))
            {
                txtHDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
            }
            if (VarGeneral.SSSLev != "M" && State == FormState.New)
            {
                T_AccDef q = db.StockAccDefWithOutBalance(txtCustNo.Text);
                if (q.StopInvTyp == 1 && checkBox_Chash.Checked)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. وذلك لأن حساب العميل غير مصرح له البيع بالنقدي " : "Can not complete the operation .. This is because the customer's account is not authorized to Cash Sales", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
            }
            if ((VarGeneral.SSSLev == "R" || VarGeneral.SSSLev == "C" || VarGeneral.SSSLev == "H") && txtTable.Value == 0 && State == FormState.New)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ بدون تحديد رقم الطاولة" : "Can not save without Table No", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtTable.Focus();
                return false;
            }
            try
            {
                if (VarGeneral.CheckDate(VarGeneral.Settings_Sys.AccCusDes.Trim()) && VarGeneral.CheckDate(VarGeneral.Settings_Sys.AccSupDes.Trim()))
                {
                    if (Convert.ToDateTime(n.FormatGreg(txtGDate.Text, "yyyy/MM/dd")) <= Convert.ToDateTime(VarGeneral.Settings_Sys.AccCusDes) && Convert.ToDateTime(n.FormatGreg(txtGDate.Text, "yyyy/MM/dd")) >= Convert.ToDateTime(VarGeneral.Settings_Sys.AccSupDes))
                    {
                        return true;
                    }
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. لقد تخطيت السنة المالية المحدد للنظام \n يرجى التواصل مع الإدارة لإتمام عملية الإقفال السنوية " : "We can not complete the operation .. have you skip the fiscal year specified for the system", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. لقد تخطيت السنة المالية المحدد للنظام \n يرجى التواصل مع الإدارة لإتمام عملية الإقفال السنوية " : "We can not complete the operation .. have you skip the fiscal year specified for the system", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            return true;
        }
        private bool UpdateTableNo()
        {
            if (data_this.RoomNo.HasValue && data_this.RoomSts.Value && data_this.RoomNo.Value == 1 && data_this.OrderTyp.Value != 0)
            {
                if (txtTable.Value == 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "يرجى تحديد الطاولة قبل عملية الحفظ" : "Please Selected Table", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtTable.Focus();
                    return false;
                }
                List<T_Room> newData = (from t in db.T_Rooms
                                        where t.ID == int.Parse(txtTable.Tag.ToString())
                                        where !t.RomeStatus.Value
                                        select t).ToList();
                if (newData.Count > 0)
                {
                    newData.First().RomeStatus = true;
                    if (!string.IsNullOrEmpty(textBox_WaiterName.Text))
                    {
                        newData.First().waiterNo = int.Parse(textBox_WaiterName.Tag.ToString());
                    }
                    else
                    {
                        newData.First().waiterNo = null;
                    }
                    db.Log = VarGeneral.DebugLog;
                    db.SubmitChanges(ConflictMode.ContinueOnConflict);
                }
            }
            return true;
        }
        private bool SaveData()
        {
            isPrintSts = false;
            if (State == FormState.New)
            {
                dbInstance = null;
            }
            if (!ValidData())
            {
                return false;
            }
            try
            {
                IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
                bool mndExtrnal = false;
                int mndNo = 0;
                mndExtrnal = false;
                mndNo = 0;
                int i;
                for (i = 0; i < ItemDetRemoved.Count; i++)
                {
                    try
                    {
                        List<T_SINVDET> q = db.T_SINVDETs.Where((T_SINVDET t) => t.SInvId == (int?)ItemDetRemoved[i]).ToList();
                        for (int iicnt = 0; iicnt < q.Count; iicnt++)
                        {
                            db_.ClearParameters();
                            db_.AddParameter("SInvDet_ID", DbType.Int32, q[iicnt].SInvDet_ID);
                            db_.ExecuteNonQuery(storedProcedure: true, "S_T_SINVDET_DELETE");
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }
                if (State == FormState.New)
                {
                    GetData();
                    try
                    {
                        if (txtTable.Value == 0)
                        {
                            data_this.RoomNo = 1;
                            data_this.RoomSts = false;
                        }
                        else
                        {
                            data_this.RoomNo = int.Parse(txtTable.Tag.ToString());
                            data_this.RoomSts = true;
                        }
                        GetInvSetting();
                        textBox_ID.TextChanged -= textBox_ID_TextChanged;
                        T_INVHED newData = db.StockInvHead(VarGeneral.InvTyp, data_this.InvNo);
                        if (!string.IsNullOrEmpty(newData.InvNo) || newData.InvHed_ID > 0)
                        {
                            string max = "";
                            dbInstance = null;
                            max = db.MaxInvheadNo.ToString();
                            MessageBox.Show("الرمز مستخدم من قبل.\n سيتم الحفظ برقم جديد [" + max + "]", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            textBox_ID.Text = max ?? "";
                            data_this.InvNo = max ?? "";
                        }
                        textBox_ID.TextChanged += textBox_ID_TextChanged;
                        data_this.IfRet = 0;
                        data_this.DATE_CREATED = DateTime.Now;
                        data_this.SalsManNo = VarGeneral.UserNumber;
                        data_this.UserNew = VarGeneral.UserNumber;
                        data_this.SalsManNam = "";
                        IDatabase dbHead = Database.GetDatabase(VarGeneral.BranchCS);
                        dbHead.ClearParameters();
                        dbHead.AddOutParameter("InvHed_ID", DbType.Int32);
                        dbHead.AddParameter("InvId", DbType.Double, data_this.InvId);
                        dbHead.AddParameter("InvNo", DbType.String, data_this.InvNo);
                        dbHead.AddParameter("InvTyp", DbType.Int32, data_this.InvTyp);
                        dbHead.AddParameter("InvCashPay", DbType.Int32, data_this.InvCashPay);
                        dbHead.AddParameter("CusVenNo", DbType.String, data_this.CusVenNo);
                        dbHead.AddParameter("CusVenNm", DbType.String, data_this.CusVenNm);
                        dbHead.AddParameter("CusVenAdd", DbType.String, data_this.CusVenAdd);
                        dbHead.AddParameter("CusVenTel", DbType.String, data_this.CusVenTel);
                        dbHead.AddParameter("Remark", DbType.String, data_this.Remark);
                        dbHead.AddParameter("HDat", DbType.String, data_this.HDat);
                        dbHead.AddParameter("GDat", DbType.String, data_this.GDat);
                        dbHead.AddParameter("MndNo", DbType.Int32, data_this.MndNo);
                        dbHead.AddParameter("SalsManNo", DbType.String, data_this.SalsManNo);
                        dbHead.AddParameter("SalsManNam", DbType.String, data_this.SalsManNam);
                        dbHead.AddParameter("InvTot", DbType.Double, data_this.InvTot);
                        dbHead.AddParameter("InvTotLocCur", DbType.Double, data_this.InvTotLocCur);
                        dbHead.AddParameter("InvDisPrs", DbType.Double, data_this.InvDisPrs);
                        dbHead.AddParameter("InvDisVal", DbType.Double, data_this.InvDisVal);
                        dbHead.AddParameter("InvDisValLocCur", DbType.Double, data_this.InvDisValLocCur);
                        dbHead.AddParameter("InvNet", DbType.Double, data_this.InvNet);
                        dbHead.AddParameter("InvNetLocCur", DbType.Double, data_this.InvNetLocCur);
                        dbHead.AddParameter("CashPay", DbType.Double, data_this.CashPay);
                        dbHead.AddParameter("CashPayLocCur", DbType.Double, data_this.CashPayLocCur);
                        dbHead.AddParameter("IfRet", DbType.Int32, data_this.IfRet);
                        dbHead.AddParameter("GadeNo", DbType.Double, data_this.GadeNo);
                        dbHead.AddParameter("GadeId", DbType.Double, data_this.GadeId);
                        dbHead.AddParameter("IfDel", DbType.Int32, data_this.IfDel);
                        dbHead.AddParameter("RetNo", DbType.String, data_this.RetNo);
                        dbHead.AddParameter("RetId", DbType.Double, data_this.RetId);
                        dbHead.AddParameter("InvCstNo", DbType.Int32, data_this.InvCstNo);
                        dbHead.AddParameter("InvCashPayNm", DbType.String, data_this.InvCashPayNm);
                        dbHead.AddParameter("RefNo", DbType.String, data_this.RefNo);
                        dbHead.AddParameter("InvCost", DbType.Int32, data_this.InvCost);
                        dbHead.AddParameter("EstDat", DbType.String, data_this.EstDat);
                        dbHead.AddParameter("CustPri", DbType.Int32, data_this.CustPri);
                        dbHead.AddParameter("ArbTaf", DbType.String, data_this.ArbTaf);
                        dbHead.AddParameter("CurTyp", DbType.Int32, data_this.CurTyp);
                        dbHead.AddParameter("InvCash", DbType.String, data_this.InvCash);
                        dbHead.AddParameter("ToStore", DbType.String, data_this.ToStore);
                        dbHead.AddParameter("ToStoreNm", DbType.String, data_this.ToStoreNm);
                        dbHead.AddParameter("InvQty", DbType.Double, data_this.InvQty);
                        dbHead.AddParameter("EngTaf", DbType.String, data_this.EngTaf);
                        dbHead.AddParameter("IfTrans", DbType.Int32, data_this.IfTrans);
                        dbHead.AddParameter("CustRep", DbType.Double, data_this.CustRep);
                        dbHead.AddParameter("CustNet", DbType.Double, data_this.CustNet);
                        dbHead.AddParameter("InvWight_T", DbType.Double, data_this.InvWight_T);
                        dbHead.AddParameter("IfPrint", DbType.Int32, data_this.IfPrint);
                        dbHead.AddParameter("LTim", DbType.String, data_this.LTim);
                        dbHead.AddParameter("CREATED_BY", DbType.String, data_this.CREATED_BY);
                        dbHead.AddParameter("DATE_CREATED", DbType.DateTime, data_this.DATE_CREATED);
                        dbHead.AddParameter("MODIFIED_BY", DbType.String, data_this.MODIFIED_BY);
                        dbHead.AddParameter("DATE_MODIFIED", DbType.DateTime, data_this.DATE_MODIFIED);
                        dbHead.AddParameter("CreditPay", DbType.Double, data_this.CreditPay);
                        dbHead.AddParameter("CreditPayLocCur", DbType.Double, data_this.CreditPayLocCur);
                        dbHead.AddParameter("NetworkPay", DbType.Double, data_this.NetworkPay);
                        dbHead.AddParameter("NetworkPayLocCur", DbType.Double, data_this.NetworkPayLocCur);
                        dbHead.AddParameter("CommMnd_Inv", DbType.Double, data_this.CommMnd_Inv);
                        dbHead.AddParameter("MndExtrnal", DbType.Boolean, data_this.MndExtrnal);
                        dbHead.AddParameter("CompanyID", DbType.Int32, data_this.CompanyID);
                        dbHead.AddParameter("InvAddCost", DbType.Double, data_this.InvAddCost);
                        dbHead.AddParameter("InvAddCostLoc", DbType.Double, data_this.InvAddCostLoc);
                        dbHead.AddParameter("InvAddCostExtrnal", DbType.Double, data_this.InvAddCostExtrnal);
                        dbHead.AddParameter("InvAddCostExtrnalLoc", DbType.Double, data_this.InvAddCostExtrnalLoc);
                        dbHead.AddParameter("IsExtrnalGaid", DbType.Boolean, data_this.IsExtrnalGaid);
                        dbHead.AddParameter("ExtrnalCostGaidID", DbType.Double, data_this.ExtrnalCostGaidID);
                        dbHead.AddParameter("Puyaid", DbType.Double, data_this.Puyaid);
                        dbHead.AddParameter("Remming", DbType.Double, data_this.Remming);
                        dbHead.AddParameter("RoomNo", DbType.Int32, data_this.RoomNo);
                        dbHead.AddParameter("OrderTyp", DbType.Int32, data_this.OrderTyp);
                        dbHead.AddParameter("RoomSts", DbType.Boolean, data_this.RoomSts);
                        dbHead.AddParameter("chauffeurNo", DbType.Int32, data_this.chauffeurNo);
                        dbHead.AddParameter("RoomPerson", DbType.Int32, data_this.RoomPerson);
                        dbHead.AddParameter("ServiceValue", DbType.Double, data_this.ServiceValue);
                        dbHead.AddParameter("Sts", DbType.Boolean, data_this.Sts);
                        dbHead.AddParameter("PaymentOrderTyp", DbType.Int32, data_this.PaymentOrderTyp);
                        dbHead.AddParameter("AdminLock", DbType.Boolean, data_this.AdminLock);
                        dbHead.AddParameter("DeleteDate", DbType.String, data_this.DeleteDate);
                        dbHead.AddParameter("DeleteTime", DbType.String, data_this.DeleteTime);
                        dbHead.AddParameter("UserNew", DbType.String, data_this.UserNew);
                        dbHead.AddParameter("IfEnter", DbType.Int32, data_this.IfEnter);
                        dbHead.AddParameter("InvAddTax", DbType.Double, data_this.InvAddTax);
                        dbHead.AddParameter("InvAddTaxlLoc", DbType.Double, data_this.InvAddTaxlLoc);
                        dbHead.AddParameter("IsTaxGaid", DbType.Boolean, data_this.IsTaxGaid);
                        dbHead.AddParameter("TaxGaidID", DbType.Double, data_this.TaxGaidID);
                        dbHead.AddParameter("IsTaxUse", DbType.Boolean, data_this.IsTaxUse);
                        dbHead.AddParameter("InvValGaidDis", DbType.Double, data_this.InvValGaidDis);
                        dbHead.AddParameter("InvValGaidDislLoc", DbType.Double, data_this.InvValGaidDislLoc);
                        dbHead.AddParameter("IsDisGaid", DbType.Boolean, data_this.IsDisGaid);
                        dbHead.AddParameter("DisGaidID1", DbType.Double, data_this.DisGaidID1);
                        dbHead.AddParameter("IsDisUse1", DbType.Boolean, data_this.IsDisUse1);
                        dbHead.AddParameter("InvComm", DbType.Double, data_this.InvComm);
                        dbHead.AddParameter("InvCommLoc", DbType.Double, data_this.InvCommLoc);
                        dbHead.AddParameter("IsCommGaid", DbType.Boolean, data_this.IsCommGaid);
                        dbHead.AddParameter("CommGaidID", DbType.Double, data_this.CommGaidID);
                        dbHead.AddParameter("IsCommUse", DbType.Boolean, data_this.IsCommUse);
                        dbHead.AddParameter("IsTaxLines", DbType.Boolean, data_this.IsTaxLines);
                        dbHead.AddParameter("IsTaxByTotal", DbType.Boolean, data_this.IsTaxByTotal);
                        dbHead.AddParameter("IsTaxByNet", DbType.Boolean, data_this.IsTaxByNet);
                        dbHead.AddParameter("TaxByNetValue", DbType.Double, data_this.TaxByNetValue);
                        dbHead.AddParameter("DesPointsValue", DbType.Double, data_this.DesPointsValue);
                        dbHead.AddParameter("DesPointsValueLocCur", DbType.Double, data_this.DesPointsValueLocCur);
                        dbHead.AddParameter("PointsCount", DbType.Double, data_this.PointsCount);
                        dbHead.AddParameter("IsPoints", DbType.Boolean, data_this.IsPoints);
                        dbHead.AddParameter("tailor20", DbType.String, data_this.tailor20);
                        dbHead.ExecuteNonQuery(storedProcedure: true, "S_T_INVHED_INSERT");
                        data_this.InvHed_ID = int.Parse(dbHead.GetParameterValue("InvHed_ID").ToString());
                    }
                    catch (SqlException ex3)
                    {
                        string max = "";
                        dbInstance = null;
                        max = db.MaxInvheadNo.ToString();
                        int maxSeq = 1;
                        maxSeq = db.MaxInvheadNoSequence;
                        if (ex3.Number == 2627)
                        {
                            MessageBox.Show("الرمز مستخدم من قبل.\n سيتم الحفظ برقم جديد [" + max + "]", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            textBox_ID.Text = max ?? "";
                            data_this.InvNo = max ?? "";
                            Button_Save_Click(null, null);
                        }
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                    if (data_this.RoomNo.Value > 1 && !string.IsNullOrEmpty(txtTable.Tag.ToString()))
                    {
                        List<T_Room> q2 = db.T_Rooms.Where((T_Room t) => t.ID == int.Parse(txtTable.Tag.ToString())).ToList();
                        if (q2.Count > 0)
                        {
                            T_Room vData = new T_Room();
                            vData = q2.First();
                            vData.RomeStatus = true;
                            if (!string.IsNullOrEmpty(textBox_WaiterName.Text))
                            {
                                vData.waiterNo = int.Parse(textBox_WaiterName.Tag.ToString());
                            }
                            else
                            {
                                vData.waiterNo = null;
                            }
                            db.Log = VarGeneral.DebugLog;
                            db.SubmitChanges(ConflictMode.ContinueOnConflict);
                        }
                    }
                }
                else
                {
                    if (!UpdateTableNo())
                    {
                        return false;
                    }
                    GetData();
                    if (data_this.RoomNo.Value > 1 && !string.IsNullOrEmpty(txtTable.Tag.ToString()))
                    {
                        List<T_Room> q2 = db.T_Rooms.Where((T_Room t) => t.ID == int.Parse(txtTable.Tag.ToString())).ToList();
                        if (q2.Count > 0)
                        {
                            T_Room vData = new T_Room();
                            vData = q2.First();
                            if (!string.IsNullOrEmpty(textBox_WaiterName.Text))
                            {
                                vData.waiterNo = int.Parse(textBox_WaiterName.Tag.ToString());
                            }
                            else
                            {
                                vData.waiterNo = null;
                            }
                            db.Log = VarGeneral.DebugLog;
                            db.SubmitChanges(ConflictMode.ContinueOnConflict);
                        }
                    }
                    vSINVDIT.Clear();
                    for (int j = 0; j < data_this.T_INVDETs.Count; j++)
                    {
                        if (data_this.T_INVDETs[j].ItmTyp.Value == 2)
                        {
                            vSINVDIT.Add(data_this.T_INVDETs[j].InvDet_ID, data_this.T_INVDETs[j].T_SINVDETs.ToList());
                        }
                    }
                    for (int j = 0; j < data_this.T_INVDETs.Count; j++)
                    {
                        if (data_this.T_INVDETs[j].ItmTyp.Value == 2)
                        {
                            for (int iicnt = 0; iicnt < data_this.T_INVDETs[j].T_SINVDETs.Count; iicnt++)
                            {
                                db_.ClearParameters();
                                db_.AddParameter("SInvDet_ID", DbType.Int32, data_this.T_INVDETs[j].T_SINVDETs[iicnt].SInvDet_ID);
                                db_.ExecuteNonQuery(storedProcedure: true, "S_T_SINVDET_DELETE");
                            }
                        }
                        db_.ClearParameters();
                        db_.AddParameter("InvDet_ID", DbType.Int32, data_this.T_INVDETs[j].InvDet_ID);
                        db_.ExecuteNonQuery(storedProcedure: true, "S_T_INVDET_DELETE");
                    }
                    data_this.SalsManNam = VarGeneral.UserNumber;
                    IDatabase dbHead = Database.GetDatabase(VarGeneral.BranchCS);
                    dbHead.ClearParameters();
                    dbHead.AddParameter("InvHed_ID", DbType.Int32, data_this.InvHed_ID);
                    dbHead.AddParameter("InvId", DbType.Double, data_this.InvId);
                    dbHead.AddParameter("InvNo", DbType.String, data_this.InvNo);
                    dbHead.AddParameter("InvTyp", DbType.Int32, data_this.InvTyp);
                    dbHead.AddParameter("InvCashPay", DbType.Int32, data_this.InvCashPay);
                    dbHead.AddParameter("CusVenNo", DbType.String, data_this.CusVenNo);
                    dbHead.AddParameter("CusVenNm", DbType.String, data_this.CusVenNm);
                    dbHead.AddParameter("CusVenAdd", DbType.String, data_this.CusVenAdd);
                    dbHead.AddParameter("CusVenTel", DbType.String, data_this.CusVenTel);
                    dbHead.AddParameter("Remark", DbType.String, data_this.Remark);
                    dbHead.AddParameter("HDat", DbType.String, data_this.HDat);
                    dbHead.AddParameter("GDat", DbType.String, data_this.GDat);
                    dbHead.AddParameter("MndNo", DbType.Int32, data_this.MndNo);
                    dbHead.AddParameter("SalsManNo", DbType.String, data_this.SalsManNo);
                    dbHead.AddParameter("SalsManNam", DbType.String, data_this.SalsManNam);
                    dbHead.AddParameter("InvTot", DbType.Double, data_this.InvTot);
                    dbHead.AddParameter("InvTotLocCur", DbType.Double, data_this.InvTotLocCur);
                    dbHead.AddParameter("InvDisPrs", DbType.Double, data_this.InvDisPrs);
                    dbHead.AddParameter("InvDisVal", DbType.Double, data_this.InvDisVal);
                    dbHead.AddParameter("InvDisValLocCur", DbType.Double, data_this.InvDisValLocCur);
                    dbHead.AddParameter("InvNet", DbType.Double, data_this.InvNet);
                    dbHead.AddParameter("InvNetLocCur", DbType.Double, data_this.InvNetLocCur);
                    dbHead.AddParameter("CashPay", DbType.Double, data_this.CashPay);
                    dbHead.AddParameter("CashPayLocCur", DbType.Double, data_this.CashPayLocCur);
                    dbHead.AddParameter("IfRet", DbType.Int32, data_this.IfRet);
                    dbHead.AddParameter("GadeNo", DbType.Double, data_this.GadeNo);
                    dbHead.AddParameter("GadeId", DbType.Double, data_this.GadeId);
                    dbHead.AddParameter("IfDel", DbType.Int32, data_this.IfDel);
                    dbHead.AddParameter("RetNo", DbType.String, data_this.RetNo);
                    dbHead.AddParameter("RetId", DbType.Double, data_this.RetId);
                    dbHead.AddParameter("InvCstNo", DbType.Int32, data_this.InvCstNo);
                    dbHead.AddParameter("InvCashPayNm", DbType.String, data_this.InvCashPayNm);
                    dbHead.AddParameter("RefNo", DbType.String, data_this.RefNo);
                    dbHead.AddParameter("InvCost", DbType.Int32, data_this.InvCost);
                    dbHead.AddParameter("EstDat", DbType.String, data_this.EstDat);
                    dbHead.AddParameter("CustPri", DbType.Int32, data_this.CustPri);
                    dbHead.AddParameter("ArbTaf", DbType.String, data_this.ArbTaf);
                    dbHead.AddParameter("CurTyp", DbType.Int32, data_this.CurTyp);
                    dbHead.AddParameter("InvCash", DbType.String, data_this.InvCash);
                    dbHead.AddParameter("ToStore", DbType.String, data_this.ToStore);
                    dbHead.AddParameter("ToStoreNm", DbType.String, data_this.ToStoreNm);
                    dbHead.AddParameter("InvQty", DbType.Double, data_this.InvQty);
                    dbHead.AddParameter("EngTaf", DbType.String, data_this.EngTaf);
                    dbHead.AddParameter("IfTrans", DbType.Int32, data_this.IfTrans);
                    dbHead.AddParameter("CustRep", DbType.Double, data_this.CustRep);
                    dbHead.AddParameter("CustNet", DbType.Double, data_this.CustNet);
                    dbHead.AddParameter("InvWight_T", DbType.Double, data_this.InvWight_T);
                    dbHead.AddParameter("IfPrint", DbType.Int32, data_this.IfPrint);
                    dbHead.AddParameter("LTim", DbType.String, data_this.LTim);
                    dbHead.AddParameter("CREATED_BY", DbType.String, data_this.CREATED_BY);
                    dbHead.AddParameter("DATE_CREATED", DbType.DateTime, data_this.DATE_CREATED);
                    dbHead.AddParameter("MODIFIED_BY", DbType.String, data_this.MODIFIED_BY);
                    dbHead.AddParameter("DATE_MODIFIED", DbType.DateTime, data_this.DATE_MODIFIED);
                    dbHead.AddParameter("CreditPay", DbType.Double, data_this.CreditPay);
                    dbHead.AddParameter("CreditPayLocCur", DbType.Double, data_this.CreditPayLocCur);
                    dbHead.AddParameter("NetworkPay", DbType.Double, data_this.NetworkPay);
                    dbHead.AddParameter("NetworkPayLocCur", DbType.Double, data_this.NetworkPayLocCur);
                    dbHead.AddParameter("CommMnd_Inv", DbType.Double, data_this.CommMnd_Inv);
                    dbHead.AddParameter("MndExtrnal", DbType.Boolean, data_this.MndExtrnal);
                    dbHead.AddParameter("CompanyID", DbType.Int32, data_this.CompanyID);
                    dbHead.AddParameter("InvAddCost", DbType.Double, data_this.InvAddCost);
                    dbHead.AddParameter("InvAddCostLoc", DbType.Double, data_this.InvAddCostLoc);
                    dbHead.AddParameter("InvAddCostExtrnal", DbType.Double, data_this.InvAddCostExtrnal);
                    dbHead.AddParameter("InvAddCostExtrnalLoc", DbType.Double, data_this.InvAddCostExtrnalLoc);
                    dbHead.AddParameter("IsExtrnalGaid", DbType.Boolean, data_this.IsExtrnalGaid);
                    dbHead.AddParameter("ExtrnalCostGaidID", DbType.Double, data_this.ExtrnalCostGaidID);
                    dbHead.AddParameter("Puyaid", DbType.Double, data_this.Puyaid);
                    dbHead.AddParameter("Remming", DbType.Double, data_this.Remming);
                    dbHead.AddParameter("RoomNo", DbType.Int32, data_this.RoomNo);
                    dbHead.AddParameter("OrderTyp", DbType.Int32, data_this.OrderTyp);
                    dbHead.AddParameter("RoomSts", DbType.Boolean, data_this.RoomSts);
                    dbHead.AddParameter("chauffeurNo", DbType.Int32, data_this.chauffeurNo);
                    dbHead.AddParameter("RoomPerson", DbType.Int32, data_this.RoomPerson);
                    dbHead.AddParameter("ServiceValue", DbType.Double, data_this.ServiceValue);
                    dbHead.AddParameter("Sts", DbType.Boolean, data_this.Sts);
                    dbHead.AddParameter("PaymentOrderTyp", DbType.Int32, data_this.PaymentOrderTyp);
                    dbHead.AddParameter("AdminLock", DbType.Boolean, data_this.AdminLock);
                    dbHead.AddParameter("DeleteDate", DbType.String, data_this.DeleteDate);
                    dbHead.AddParameter("DeleteTime", DbType.String, data_this.DeleteTime);
                    dbHead.AddParameter("UserNew", DbType.String, data_this.UserNew);
                    dbHead.AddParameter("IfEnter", DbType.Int32, data_this.IfEnter);
                    dbHead.AddParameter("InvAddTax", DbType.Double, data_this.InvAddTax);
                    dbHead.AddParameter("InvAddTaxlLoc", DbType.Double, data_this.InvAddTaxlLoc);
                    dbHead.AddParameter("IsTaxGaid", DbType.Boolean, data_this.IsTaxGaid);
                    dbHead.AddParameter("TaxGaidID", DbType.Double, data_this.TaxGaidID);
                    dbHead.AddParameter("IsTaxUse", DbType.Boolean, data_this.IsTaxUse);
                    dbHead.AddParameter("InvValGaidDis", DbType.Double, data_this.InvValGaidDis);
                    dbHead.AddParameter("InvValGaidDislLoc", DbType.Double, data_this.InvValGaidDislLoc);
                    dbHead.AddParameter("IsDisGaid", DbType.Boolean, data_this.IsDisGaid);
                    dbHead.AddParameter("DisGaidID1", DbType.Double, data_this.DisGaidID1);
                    dbHead.AddParameter("IsDisUse1", DbType.Boolean, data_this.IsDisUse1);
                    dbHead.AddParameter("InvComm", DbType.Double, data_this.InvComm);
                    dbHead.AddParameter("InvCommLoc", DbType.Double, data_this.InvCommLoc);
                    dbHead.AddParameter("IsCommGaid", DbType.Boolean, data_this.IsCommGaid);
                    dbHead.AddParameter("CommGaidID", DbType.Double, data_this.CommGaidID);
                    dbHead.AddParameter("IsCommUse", DbType.Boolean, data_this.IsCommUse);
                    dbHead.AddParameter("IsTaxLines", DbType.Boolean, data_this.IsTaxLines);
                    dbHead.AddParameter("IsTaxByTotal", DbType.Boolean, data_this.IsTaxByTotal);
                    dbHead.AddParameter("IsTaxByNet", DbType.Boolean, data_this.IsTaxByNet);
                    dbHead.AddParameter("TaxByNetValue", DbType.Double, data_this.TaxByNetValue);
                    dbHead.AddParameter("DesPointsValue", DbType.Double, data_this.DesPointsValue);
                    dbHead.AddParameter("DesPointsValueLocCur", DbType.Double, data_this.DesPointsValueLocCur);
                    dbHead.AddParameter("PointsCount", DbType.Double, data_this.PointsCount);
                    dbHead.AddParameter("IsPoints", DbType.Boolean, data_this.IsPoints);
                    dbHead.AddParameter("tailor20", DbType.String, data_this.tailor20);
                    dbHead.ExecuteNonQuery(storedProcedure: true, "S_T_INVHED_UPDATE");
                }
                int iiCnt = 0;
                try
                {
                    for (iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
                    {
                        if (FlxInv.GetData(iiCnt, 1) == null)
                        {
                            continue;
                        }
                        db_.ClearParameters();
                        db_.AddParameter("InvDet_ID", DbType.Int32, 0);
                        db_.AddParameter("InvNo", DbType.String, textBox_ID.Text.Trim());
                        db_.AddParameter("InvId", DbType.Int32, data_this.InvHed_ID);
                        db_.AddParameter("InvSer", DbType.Int32, iiCnt);
                        db_.AddParameter("ItmNo", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 1)));
                        db_.AddParameter("Cost", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 10)))));
                        db_.AddParameter("Qty", DbType.Double, 0.0 - double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))));
                        db_.AddParameter("ItmDes", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 2)));
                        db_.AddParameter("ItmUnt", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 3)));
                        db_.AddParameter("ItmDesE", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 4)));
                        db_.AddParameter("ItmUntE", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 5)));
                        db_.AddParameter("ItmUntPak", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 11)))));
                        db_.AddParameter("StoreNo", DbType.Int32, int.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 6).ToString() ?? "")));
                        db_.AddParameter("Price", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))));
                        db_.AddParameter("Amount", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31)))));
                        db_.AddParameter("RealQty", DbType.Double, 0.0 - double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 12)))));
                        db_.AddParameter("itmInvDsc", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 13)))));
                        if (VarGeneral.CheckDate(string.Concat(FlxInv.GetData(iiCnt, 27))))
                        {
                            db_.AddParameter("DatExper", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 27)));
                        }
                        else
                        {
                            db_.AddParameter("DatExper", DbType.String, "");
                        }
                        db_.AddParameter("ItmDis", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 9)))));
                        db_.AddParameter("ItmTyp", DbType.Int32, int.Parse("0" + FlxInv.GetData(iiCnt, 32)));
                        db_.AddParameter("ItmIndex", DbType.Int32, 0);
                        db_.AddParameter("ItmWight", DbType.Double, 0);
                        db_.AddParameter("ItmWight_T", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 34)))));
                        if (!string.IsNullOrEmpty(string.Concat(FlxInv.GetData(iiCnt, 35))))
                        {
                            db_.AddParameter("RunCod", DbType.String, string.Concat(FlxInv.GetData(iiCnt, 35)));
                        }
                        else
                        {
                            db_.AddParameter("RunCod", DbType.String, "");
                        }
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                        {
                            db_.AddParameter("LineDetails", DbType.String, string.Concat(FlxInv.GetData(iiCnt + 1, 2)));
                        }
                        else
                        {
                            db_.AddParameter("LineDetails", DbType.String, string.Concat(FlxInv.GetData(iiCnt + 1, 4)));
                        }
                        db_.AddParameter("Serial_Key", DbType.String, "");
                        db_.AddParameter("ItmTax", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))));
                        db_.ExecuteNonQuery(storedProcedure: true, "S_T_INVDET_INSERT");
                        if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 32)))) != 2.0)
                        {
                            continue;
                        }
                        dataGridView_ItemDet.Visible = false;
                        FlxInv.RowSel = iiCnt;
                        if (State == FormState.New && (int.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 25)))) <= 0 || string.IsNullOrEmpty(FlxInv.GetData(iiCnt, 25).ToString())))
                        {
                            GridDetUpdate(FlxInv.RowSel);
                        }
                        else
                        {
                            for (int j = 0; j < vSINVDIT.Count; j++)
                            {
                                if ((double)vSINVDIT.ToList()[j].Key == double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 25)))))
                                {
                                    SetLinesDET(vSINVDIT.ToList()[j].Value, iiCnt);
                                }
                            }
                        }
                        int SInvHed = 0;
                        try
                        {
                            Stock_DataDataContext dbc_ = new Stock_DataDataContext(VarGeneral.BranchCS);
                            SInvHed = (from t in dbc_.T_INVDETs
                                       where t.InvId == (int?)data_this.InvHed_ID
                                       where t.InvNo == textBox_ID.Text
                                       where t.ItmTyp == (int?)2
                                       where t.InvSer == (int?)iiCnt
                                       select t).ToList().First().InvDet_ID;
                        }
                        catch
                        {
                            SInvHed = 0;
                        }
                        if (SInvHed == 0)
                        {
                            continue;
                        }
                        for (int j = 1; j < dataGridView_ItemDet.Rows.Count; j++)
                        {
                            if (dataGridView_ItemDet.GetData(j, 1) != null)
                            {
                                db_.ClearParameters();
                                db_.AddParameter("SInvDet_ID", DbType.Int32, 0);
                                db_.AddParameter("SInvNo", DbType.String, textBox_ID.Text.Trim());
                                db_.AddParameter("SInvId", DbType.Int32, SInvHed);
                                db_.AddParameter("SInvSer", DbType.Int32, j);
                                db_.AddParameter("SItmNo", DbType.String, string.Concat(dataGridView_ItemDet.GetData(j, 1)));
                                db_.AddParameter("SCost", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 10)))));
                                db_.AddParameter("SQty", DbType.Double, 0.0 - double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 7)))));
                                db_.AddParameter("SItmDes", DbType.String, string.Concat(dataGridView_ItemDet.GetData(j, 2)));
                                db_.AddParameter("SItmUnt", DbType.String, string.Concat(dataGridView_ItemDet.GetData(j, 3)));
                                db_.AddParameter("SItmDesE", DbType.String, string.Concat(dataGridView_ItemDet.GetData(j, 4)));
                                db_.AddParameter("SItmUntE", DbType.String, string.Concat(dataGridView_ItemDet.GetData(j, 5)));
                                db_.AddParameter("SItmUntPak", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 11)))));
                                db_.AddParameter("SStoreNo", DbType.Int32, int.Parse(VarGeneral.TString.TEmpty(dataGridView_ItemDet.GetData(j, 6).ToString() ?? "")));
                                db_.AddParameter("SPrice", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 8)))));
                                db_.AddParameter("SAmount", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 31)))));
                                db_.AddParameter("SRealQty", DbType.Double, 0.0 - double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 12)))));
                                db_.AddParameter("SitmInvDsc", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 13)))));
                                if (VarGeneral.CheckDate(string.Concat(dataGridView_ItemDet.GetData(j, 27))))
                                {
                                    db_.AddParameter("SDatExper", DbType.String, string.Concat(dataGridView_ItemDet.GetData(j, 27)));
                                }
                                else
                                {
                                    db_.AddParameter("SDatExper", DbType.String, "");
                                }
                                db_.AddParameter("SItmDis", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 9)))));
                                db_.AddParameter("SItmTyp", DbType.Int32, int.Parse("0" + dataGridView_ItemDet.GetData(j, 32)));
                                db_.AddParameter("SItmIndex", DbType.Int32, 0);
                                db_.AddParameter("SItmWight", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 33)))));
                                db_.AddParameter("SItmWight_T", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 34)))));
                                db_.AddParameter("SQtyDef", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 29)))));
                                db_.AddParameter("SPriceDef", DbType.Double, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(j, 17)))));
                                db_.AddParameter("SInvIdHEAD", DbType.Int32, data_this.InvHed_ID);
                                db_.AddParameter("SItmTax", DbType.Double, 0);
                                db_.ExecuteNonQuery(storedProcedure: true, "S_T_SINVDET_INSERT");
                            }
                        }
                    }
                }
                catch (Exception ex4)
                {
                    VarGeneral.DebLog.writeLog("LinesInv_Save_WaiterMenue:", ex4, enable: true);
                    MessageBox.Show(ex4.Message);
                    return false;
                }
                dbInstance = null;
                try
                {
                    db.ExecuteCommand("update T_INVHED set RoomNo = 1 where RoomSts = 0");
                }
                catch
                {
                }
            }
            catch (Exception ex4)
            {
                MessageBox.Show(ex4.Message);
                return false;
            }
            return true;
        }
        private T_INVHED GetData()
        {
            txtDueAmountLoc.ValueChanged -= txtDueAmountLoc_ValueChanged;
            try
            {
                GetInvTot();
            }
            catch
            {
            }
            txtDueAmountLoc.ValueChanged += txtDueAmountLoc_ValueChanged;
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
            data_this.PaymentOrderTyp = 0;
            data_this.InvCashPayNm = "";
            data_this.CusVenNm = txtCustName.Text;
            data_this.CusVenNo = txtCustNo.Text;
            data_this.CusVenAdd = txtAddress.Text;
            data_this.CusVenTel = txtTele.Text;
            data_this.Remark = txtRemark.Text;
            data_this.InvNo = textBox_ID.Text;
            data_this.CashPay = txtPaymentLoc.Value;
            try
            {
                data_this.CurTyp = int.Parse(CmbCurr.SelectedValue.ToString());
            }
            catch
            {
                data_this.CurTyp = null;
            }
            data_this.CustNet = txtCustNet.Value;
            data_this.CustRep = txtCustRep.Value;
            data_this.CusVenNm = txtCustName.Text;
            data_this.CusVenNo = txtCustNo.Text;
            data_this.HDat = txtHDate.Text;
            data_this.GDat = txtGDate.Text;
            if (State == FormState.New)
            {
                data_this.AdminLock = true;
            }
            else
            {
                data_this.AdminLock = switchButton_Lock.Value;
            }
            data_this.InvCashPay = 0;
            data_this.InvCash = checkBox_Chash.Text;
            data_this.InvCost = txtInvCost.Value;
            try
            {
                data_this.InvCstNo = int.Parse(CmbCostC.SelectedValue.ToString());
            }
            catch
            {
                data_this.InvCstNo = null;
            }
            data_this.IfEnter = 0;
            data_this.EstDat = "";
            data_this.DeleteDate = "";
            data_this.DeleteTime = "";
            data_this.InvDisPrs = txtDiscountP.Value;
            data_this.InvDisVal = txtDiscountVal.Value;
            data_this.InvDisValLocCur = txtDiscountValLoc.Value;
            data_this.InvNet = txtDueAmount.Value;
            data_this.InvNetLocCur = txtDueAmountLoc.Value;
            data_this.InvQty = txtTotalQ.Value;
            data_this.InvTot = txtTotalAm.Value;
            data_this.InvTotLocCur = txtTotalAmLoc.Value;
            data_this.InvTyp = VarGeneral.InvTyp;
            data_this.IfDel = 0;
            if (State == FormState.New)
            {
                data_this.LTim = DateTime.Now.ToString("HH:mm");
            }
            else
            {
                data_this.LTim = txtTime.Text;
            }
            if (CmbLegate.SelectedIndex > 0)
            {
                data_this.MndNo = int.Parse(CmbLegate.SelectedValue.ToString());
            }
            else
            {
                data_this.MndNo = null;
            }
            data_this.RefNo = txtRef.Text;
            data_this.MndExtrnal = false;
            listCurency = db.Fillcurency_2("").ToList();
            if (listCurency.Count > 0)
            {
                _Curency = listCurency[0];
            }
            data_this.ArbTaf = ScriptNumber1.ScriptNum(decimal.Parse(VarGeneral.TString.TEmpty(txtDueAmountLoc.Text ?? ""))) + " " + _Curency.Arb_Des + " " + "فقط لاغير ";
            data_this.EngTaf = ScriptNumber1.TafEng(decimal.Parse(VarGeneral.TString.TEmpty(txtDueAmountLoc.Text ?? ""))) + " " + _Curency.Eng_Des;
            data_this.DATE_MODIFIED = DateTime.Now;
            data_this.CreditPay = doubleInput_CreditLoc.Value;
            data_this.NetworkPay = doubleInput_NetWorkLoc.Value;
            data_this.CashPayLocCur = txtPaymentLoc.Value;
            data_this.CreditPayLocCur = doubleInput_CreditLoc.Value;
            data_this.NetworkPayLocCur = doubleInput_NetWorkLoc.Value;
            try
            {
                if (CmbLegate.SelectedIndex != -1)
                {
                    T_Mndob q = db.StockMndobID(int.Parse(CmbLegate.SelectedValue.ToString()));
                    if (q.Comm_Inv.Value > 0.0 && txtDueAmountLoc.Value > 0.0)
                    {
                        data_this.CommMnd_Inv = txtDueAmountLoc.Value * (q.Comm_Inv.Value / 100.0);
                    }
                    else
                    {
                        data_this.CommMnd_Inv = 0.0;
                    }
                }
                else
                {
                    data_this.CommMnd_Inv = 0.0;
                }
            }
            catch
            {
                data_this.CommMnd_Inv = 0.0;
            }
            data_this.Puyaid = 0.0;
            data_this.Remming = 0.0;
            data_this.CompanyID = 1;
            data_this.tailor20 = "0";
            try
            {
                if (!string.IsNullOrEmpty(txtTable.Tag.ToString()) && txtTable.Value > 0)
                {
                    data_this.RoomNo = int.Parse(txtTable.Tag.ToString());
                }
                else
                {
                    data_this.RoomNo = 1;
                }
            }
            catch
            {
            }
            data_this.OrderTyp = 0;
            data_this.RoomPerson = txtPersons.Value;
            data_this.ServiceValue = 0.0;
            data_this.Sts = false;
            data_this.chauffeurNo = null;
            data_this.InvAddTax = txtTotTax.Value;
            data_this.InvAddTaxlLoc = txtTotTaxLoc.Value;
            if (switchButton_Tax.Value)
            {
                data_this.IsTaxUse = true;
            }
            else
            {
                data_this.IsTaxUse = false;
            }
            if (switchButton_TaxLines.Value)
            {
                data_this.IsTaxLines = true;
            }
            else
            {
                data_this.IsTaxLines = false;
            }
            if (switchButton_TaxByTotal.Value)
            {
                data_this.IsTaxByTotal = true;
            }
            else
            {
                data_this.IsTaxByTotal = false;
            }
            if (switchButton_TaxByNet.Value)
            {
                data_this.IsTaxByNet = true;
            }
            else
            {
                data_this.IsTaxByNet = false;
            }
            try
            {
                data_this.TaxByNetValue = double.Parse(textBoxItem_TaxByNetValue.Text);
            }
            catch
            {
                data_this.TaxByNetValue = 0.0;
            }
            data_this.IsTaxGaid = checkBox_CostGaidTax.Checked;
            data_this.InvValGaidDis = 0.0;
            data_this.InvValGaidDislLoc = 0.0;
            data_this.IsDisGaid = false;
            data_this.IsDisUse1 = false;
            data_this.InvComm = 0.0;
            data_this.InvCommLoc = 0.0;
            data_this.IsCommUse = false;
            data_this.IsCommGaid = false;
            data_this.DesPointsValue = 0.0;
            data_this.DesPointsValueLocCur = 0.0;
            data_this.PointsCount = 0.0;
            data_this.IsPoints = false;
            try
            {
                if (State == FormState.New && data_this.RoomNo > 1)
                {
                    T_INVHED c = db.StockInvHead(VarGeneral.InvTyp, data_this.InvNo);
                    List<T_INVHED> q2 = (from t in db.T_INVHEDs
                                         where t.IfDel == (int?)0
                                         where t.InvTyp == (int?)VarGeneral.InvTyp
                                         where t.RoomNo == data_this.RoomNo
                                         orderby t.InvNo
                                         select t).ToList();
                    if (q2.Count > 0)
                    {
                        data_this.AdminLock = q2[0].AdminLock.Value;
                    }
                }
            }
            catch
            {
            }
            return data_this;
        }
        private void FlxInv_AfterEdit(object sender, RowColEventArgs e)
        {
            double ItmDis = 0.0;
            double ItmAddTax = 0.0;
            ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 9)))) / 100.0);
            ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
            if (!switchButton_TaxLines.Value || switchButton_TaxByTotal.Value)
            {
                ItmAddTax = 0.0;
            }
            if (e.Col == 1)
            {
                BindDataOfItem();
            }
            else if ((e.Col == 2 || e.Col == 4) && ((string)FlxInv.GetData(e.Row, 1) == "" || FlxInv.GetData(e.Row, 1) == null))
            {
                if (FlxInv.Rows[e.Row].Height != 33)
                {
                    FlxInv.SetData(e.Row, e.Col, oldItemName);
                }
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
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri1 / RateValue);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack1);
                        break;
                    case 2:
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri2 / RateValue);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack2);
                        break;
                    case 3:
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri3 / RateValue);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack3);
                        break;
                    case 4:
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri4 / RateValue);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack4);
                        break;
                    case 5:
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri5 / RateValue);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack5);
                        break;
                }
                Pack = ItemIndex;
                BindDataofItemPrice();
                FlxInv.SetData(e.Row, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 11)))));
                FlxInv.SetData(e.Row, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAddTax);
                if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) > 0.0)
                {
                    ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    FlxInv.SetData(e.Row, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) + ItmAddTax);
                }
                PriceLoc = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8))));
                BindDataOfStkQty(FlxInv.GetData(e.Row, 1).ToString());
                if (CmbCurr.SelectedIndex != -1)
                {
                    List<T_Curency> listSer = db.StockCurrList(int.Parse(CmbCurr.SelectedValue.ToString()));
                    T_Curency _Curency = listSer[0];
                    double CurRate = _Curency.Rate.Value;
                }
                FlxInv.SetData(e.Row, 26, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) / 1.0);
                try
                {
                    ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 9)))) / 100.0);
                    ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    if (!switchButton_TaxLines.Value || switchButton_TaxByTotal.Value)
                    {
                        ItmAddTax = 0.0;
                    }
                    FlxInv.SetData(e.Row, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAddTax);
                    if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) > 0.0)
                    {
                        ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                        FlxInv.SetData(e.Row, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) + ItmAddTax);
                    }
                }
                catch
                {
                }
            }
            else if (e.Col == 6)
            {
                listStkQty = (from t in db.T_STKSQTies
                              where t.itmNo == FlxInv.GetData(e.Row, 1).ToString()
                              where t.storeNo == (int?)int.Parse(FlxInv.GetData(e.Row, 6).ToString())
                              select t).ToList();
                if (listStkQty.Count != 0)
                {
                    _StksQty = listStkQty[0];
                    FlxInv.SetData(e.Row, 24, _StksQty.stkQty.ToString());
                }
                else
                {
                    FlxInv.SetData(e.Row, 24, 0);
                }
                if (string.Concat(FlxInv.GetData(e.Row, 28)) == "1")
                {
                    FlxDat.Clear(ClearFlags.Content, 1, 0, FlxDat.Rows.Count - 1, 1);
                    listQtyExp = (from t in db.T_QTYEXPs
                                  where t.itmNo == FlxInv.GetData(e.Row, 1).ToString()
                                  where t.storeNo == (int?)int.Parse(FlxInv.GetData(e.Row, 6).ToString())
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
            }
            else if (e.Col == 7 || e.Col == 8)
            {
                double RealQ = 0.0;
                RealQ = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 11))));
                if (e.Col == 7 && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 32)))) != 3.0)
                {
                    if (double.Parse(FlxInv.GetData(e.Row, 24).ToString()) <= 0.0)
                    {
                        if (!VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 1))
                        {
                            MessageBox.Show((LangArEn == 0) ? ("لا يمكن البيع والكمية  " + double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 24)))) + "تأكد من صلاحيات المستخدمين") : ("Can't Sale and the Quantity " + double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 24)))) + " Check the Users Authorizations"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            FlxInv.SetData(e.Row, 7, 0);
                        }
                    }
                    else if (double.Parse(FlxInv.GetData(e.Row, 24).ToString()) < RealQ && !VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 1))
                    {
                        MessageBox.Show((LangArEn == 0) ? ("لا يمكن البيع بأكثر من الكمية  " + double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 24)))) + "راجع صلاحيات المستخدمين") : ("Can't Sale More Than available Quantity " + double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 24)))) + " Check the Users Authorizations"), VarGeneral.ProdectNam);
                        FlxInv.SetData(e.Row, 7, 0);
                    }
                }
                if (e.Col == 8 && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 10)))) != 0.0)
                {
                    if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 10)))) > double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))))
                    {
                        if (!VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 2))
                        {
                            MessageBox.Show((LangArEn == 0) ? "لا يمكن البيع بأقل من سعر التكلفة .. راجع صلاحيات المستخدمين" : "Can't Sale Less Then Cost Price ... Check the Users Authorizations", VarGeneral.ProdectNam);
                            FlxInv.SetData(e.Row, 8, PriceLoc);
                        }
                    }
                    else
                    {
                        PermissionPrice(e.Row, 8, _Sts: true);
                    }
                }
                FlxInv.SetData(e.Row, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 11)))));
                FlxInv.SetData(e.Row, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAddTax);
                if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) > 0.0)
                {
                    ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    FlxInv.SetData(e.Row, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) + ItmAddTax);
                }
                chekReptItem(Col_1: false);
            }
            else if (e.Col == 9)
            {
                FlxInv.SetData(e.Row, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAddTax);
                if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) > 0.0)
                {
                    ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    FlxInv.SetData(e.Row, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) + ItmAddTax);
                }
            }
            else if (e.Col == 31)
            {
                if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) > 0.0)
                {
                    ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                }
                if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) != Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAddTax, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2))
                {
                    if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) == 0.0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يجب تحديد الكمية" : "Must Enter The Quantity", VarGeneral.ProdectNam);
                        FlxInv.SetData(e.Row, 31, 0);
                        FlxInv.Col = 7;
                        FlxInv.Row = e.Row;
                        FlxInv.Focus();
                    }
                    else
                    {
                        FlxInv.SetData(e.Row, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) / double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))));
                        FlxInv.SetData(e.Row, 9, 0);
                    }
                }
                try
                {
                    if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 10)))) > double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) && !VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 2))
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن البيع بأقل من سعر التكلفة .. راجع صلاحيات المستخدمين" : "Can't Sale Less Then Cost Price ... Check the Users Authorizations", VarGeneral.ProdectNam);
                        FlxInv.SetData(e.Row, 8, PriceLoc);
                    }
                }
                catch
                {
                }
                chekReptItem(Col_1: false);
            }
            else if (e.Col == 37)
            {
                if (Convert.ToBoolean(FlxInv.GetData(e.Row, e.Col)))
                {
                    if (FlxInv.Rows[e.Row].Height > 33)
                    {
                        FlxInv.SetCellStyle(e.Row, 2, "SubTotal0");
                        FlxInv.SetCellStyle(e.Row, 4, "SubTotal0");
                    }
                    else
                    {
                        FlxInv.SetCellStyle(e.Row - 1, 2, "SubTotal0");
                        FlxInv.SetCellStyle(e.Row - 1, 4, "SubTotal0");
                    }
                }
                else
                {
                    FlxInv.SetCellStyle(e.Row, 2, "SelectedRowHeader");
                    FlxInv.SetCellStyle(e.Row, 4, "SelectedRowHeader");
                }
            }
            else if (e.Col == 33)
            {
                if (Convert.ToBoolean(FlxInv.GetData(e.Row, 33)))
                {
                    ItmDis = 0.0;
                    FlxInv.SetData(e.Row, 8, 0);
                    FlxInv.SetData(e.Row, 9, 0);
                    FlxInv.SetData(e.Row, 38, 0);
                    FlxInv.SetData(e.Row, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAddTax);
                }
            }
            else if (e.Col == 38)
            {
                FlxInv.SetData(e.Row, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis + ItmAddTax);
                if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) > 0.0)
                {
                    ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    FlxInv.SetData(e.Row, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(e.Row, 31)))) + ItmAddTax);
                }
            }
            try
            {
                if (VarGeneral.SSSLev != "R" && VarGeneral.SSSLev != "C" && VarGeneral.SSSLev != "H" && FlxInv.Rows[e.Row].Height == 33)
                {
                    FlxInv.SetData(e.Row - 1, 36, FlxInv.GetData(e.Row, (LangArEn == 0) ? 2 : 4));
                }
            }
            catch
            {
            }
            VarGeneral.Flush();
            GetInvTot();
        }
        private void PermissionPrice(int _row, int _col, bool _Sts)
        {
            try
            {
                double vPri;
                List<T_Item> q;
                if (int.Parse(permission.RepInv2.Trim()) > 0 && int.Parse(permission.RepInv4.Trim()) == 0)
                {
                    vPri = 0.0;
                    q = db.T_Items.Where((T_Item t) => t.Itm_No == FlxInv.GetData(_row, 1).ToString()).ToList();
                    if (q.Count <= 0)
                    {
                        return;
                    }
                    if (int.Parse(permission.RepInv2.Trim()) == 1)
                    {
                        if (q.FirstOrDefault().Unit1.HasValue && q.FirstOrDefault().T_Unit.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                        {
                            vPri = q.FirstOrDefault().UntPri1.Value;
                        }
                        if (q.FirstOrDefault().Unit2.HasValue && q.FirstOrDefault().T_Unit1.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                        {
                            vPri = q.FirstOrDefault().UntPri2.Value;
                        }
                        if (q.FirstOrDefault().Unit3.HasValue && q.FirstOrDefault().T_Unit2.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                        {
                            vPri = q.FirstOrDefault().UntPri3.Value;
                        }
                        if (q.FirstOrDefault().Unit4.HasValue && q.FirstOrDefault().T_Unit3.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                        {
                            vPri = q.FirstOrDefault().UntPri4.Value;
                        }
                        if (q.FirstOrDefault().Unit5.HasValue && q.FirstOrDefault().T_Unit4.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                        {
                            vPri = q.FirstOrDefault().UntPri5.Value;
                        }
                        if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) != vPri && vPri > 0.0)
                        {
                            if (_Sts)
                            {
                                MessageBox.Show((LangArEn == 0) ? "يجب البيع بسعر البيع الإفتراضي .. راجع صلاحيات المستخدمين" : "You must sell at default selling .. Check the Users Authorizations", VarGeneral.ProdectNam);
                            }
                            FlxInv.SetData(_row, 8, PriceLoc);
                        }
                        return;
                    }
                    if (int.Parse(permission.RepInv2.Trim()) == 2)
                    {
                        vPri = q.FirstOrDefault().Price1.Value;
                        if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) != vPri && vPri > 0.0)
                        {
                            if (_Sts)
                            {
                                MessageBox.Show((LangArEn == 0) ? "يجب البيع بسعر الجملة .. راجع صلاحيات المستخدمين" : "You must sell at wholesale selling ... Check the Users Authorizations", VarGeneral.ProdectNam);
                            }
                            FlxInv.SetData(_row, 8, vPri);
                        }
                        return;
                    }
                    if (int.Parse(permission.RepInv2.Trim()) == 3)
                    {
                        vPri = q.FirstOrDefault().Price2.Value;
                        if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) != vPri && vPri > 0.0)
                        {
                            if (_Sts)
                            {
                                MessageBox.Show((LangArEn == 0) ? "يجب البيع بسعر الموزع .. راجع صلاحيات المستخدمين" : "You must sell at the distributor selling ... Check the Users Authorizations", VarGeneral.ProdectNam);
                            }
                            FlxInv.SetData(_row, 8, vPri);
                        }
                        return;
                    }
                    if (int.Parse(permission.RepInv2.Trim()) == 4)
                    {
                        vPri = q.FirstOrDefault().Price3.Value;
                        if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) != vPri && vPri > 0.0)
                        {
                            if (_Sts)
                            {
                                MessageBox.Show((LangArEn == 0) ? "يجب البيع بسعر المندوب .. راجع صلاحيات المستخدمين" : "You must sell at delegate selling ... Check the Users Authorizations", VarGeneral.ProdectNam);
                            }
                            FlxInv.SetData(_row, 8, vPri);
                        }
                        return;
                    }
                    if (int.Parse(permission.RepInv2.Trim()) == 5)
                    {
                        vPri = q.FirstOrDefault().Price4.Value;
                        if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) != vPri && vPri > 0.0)
                        {
                            if (_Sts)
                            {
                                MessageBox.Show((LangArEn == 0) ? "يجب البيع بسعر التجزئة .. راجع صلاحيات المستخدمين" : "You must sell at retail selling ... Check the Users Authorizations", VarGeneral.ProdectNam);
                            }
                            FlxInv.SetData(_row, 8, vPri);
                        }
                        return;
                    }
                    vPri = q.FirstOrDefault().Price5.Value;
                    if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) != vPri && vPri > 0.0)
                    {
                        if (_Sts)
                        {
                            MessageBox.Show((LangArEn == 0) ? "يجب البيع بسعر آخر .. راجع صلاحيات المستخدمين" : "You must sell at other selling ... Check the Users Authorizations", VarGeneral.ProdectNam);
                        }
                        FlxInv.SetData(_row, 8, vPri);
                    }
                    return;
                }
                if (int.Parse(permission.RepInv2.Trim()) == 0 && int.Parse(permission.RepInv4.Trim()) > 0)
                {
                    vPri = 0.0;
                    q = db.T_Items.Where((T_Item t) => t.Itm_No == FlxInv.GetData(_row, 1).ToString()).ToList();
                    if (q.Count <= 0)
                    {
                        return;
                    }
                    if (int.Parse(permission.RepInv4.Trim()) == 1)
                    {
                        if (q.FirstOrDefault().Unit1.HasValue && q.FirstOrDefault().T_Unit.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                        {
                            vPri = q.FirstOrDefault().UntPri1.Value;
                        }
                        if (q.FirstOrDefault().Unit2.HasValue && q.FirstOrDefault().T_Unit1.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                        {
                            vPri = q.FirstOrDefault().UntPri2.Value;
                        }
                        if (q.FirstOrDefault().Unit3.HasValue && q.FirstOrDefault().T_Unit2.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                        {
                            vPri = q.FirstOrDefault().UntPri3.Value;
                        }
                        if (q.FirstOrDefault().Unit4.HasValue && q.FirstOrDefault().T_Unit3.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                        {
                            vPri = q.FirstOrDefault().UntPri4.Value;
                        }
                        if (q.FirstOrDefault().Unit5.HasValue && q.FirstOrDefault().T_Unit4.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                        {
                            vPri = q.FirstOrDefault().UntPri5.Value;
                        }
                        if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) > vPri && vPri > 0.0)
                        {
                            if (_Sts)
                            {
                                MessageBox.Show((LangArEn == 0) ? "يجب البيع بسعر لا يتجاوز سعر البيع الإفتراضي .. راجع صلاحيات المستخدمين" : "You must sell at default selling .. Check the Users Authorizations", VarGeneral.ProdectNam);
                            }
                            FlxInv.SetData(_row, 8, PriceLoc);
                        }
                        return;
                    }
                    if (int.Parse(permission.RepInv4.Trim()) == 2)
                    {
                        vPri = q.FirstOrDefault().Price1.Value;
                        if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) > vPri && vPri > 0.0)
                        {
                            if (_Sts)
                            {
                                MessageBox.Show((LangArEn == 0) ? "يجب البيع بسعر لا يتجاوز سعر الجملة .. راجع صلاحيات المستخدمين" : "You must sell at wholesale selling ... Check the Users Authorizations", VarGeneral.ProdectNam);
                            }
                            FlxInv.SetData(_row, 8, vPri);
                        }
                        return;
                    }
                    if (int.Parse(permission.RepInv4.Trim()) == 3)
                    {
                        vPri = q.FirstOrDefault().Price2.Value;
                        if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) > vPri && vPri > 0.0)
                        {
                            if (_Sts)
                            {
                                MessageBox.Show((LangArEn == 0) ? "يجب البيع بسعر لا يتجاوز سعر الموزع .. راجع صلاحيات المستخدمين" : "You must sell at the distributor selling ... Check the Users Authorizations", VarGeneral.ProdectNam);
                            }
                            FlxInv.SetData(_row, 8, vPri);
                        }
                        return;
                    }
                    if (int.Parse(permission.RepInv4.Trim()) == 4)
                    {
                        vPri = q.FirstOrDefault().Price3.Value;
                        if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) > vPri && vPri > 0.0)
                        {
                            if (_Sts)
                            {
                                MessageBox.Show((LangArEn == 0) ? "يجب البيع بسعر لا يتجاوز سعر المندوب .. راجع صلاحيات المستخدمين" : "You must sell at delegate selling ... Check the Users Authorizations", VarGeneral.ProdectNam);
                            }
                            FlxInv.SetData(_row, 8, vPri);
                        }
                        return;
                    }
                    if (int.Parse(permission.RepInv4.Trim()) == 5)
                    {
                        vPri = q.FirstOrDefault().Price4.Value;
                        if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) > vPri && vPri > 0.0)
                        {
                            if (_Sts)
                            {
                                MessageBox.Show((LangArEn == 0) ? "يجب البيع بسعر لا يتجاوز سعر التجزئة .. راجع صلاحيات المستخدمين" : "You must sell at retail selling ... Check the Users Authorizations", VarGeneral.ProdectNam);
                            }
                            FlxInv.SetData(_row, 8, vPri);
                        }
                        return;
                    }
                    vPri = q.FirstOrDefault().Price5.Value;
                    if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) > vPri && vPri > 0.0)
                    {
                        if (_Sts)
                        {
                            MessageBox.Show((LangArEn == 0) ? "يجب البيع بسعر لا يتجاوز سعر آخر .. راجع صلاحيات المستخدمين" : "You must sell at other selling ... Check the Users Authorizations", VarGeneral.ProdectNam);
                        }
                        FlxInv.SetData(_row, 8, vPri);
                    }
                    return;
                }
                if (int.Parse(permission.RepInv2.Trim()) <= 0 || int.Parse(permission.RepInv4.Trim()) <= 0)
                {
                    return;
                }
                vPri = 0.0;
                double vPri2 = 0.0;
                q = db.T_Items.Where((T_Item t) => t.Itm_No == FlxInv.GetData(_row, 1).ToString()).ToList();
                if (q.Count <= 0)
                {
                    return;
                }
                if (int.Parse(permission.RepInv2.Trim()) != 1)
                {
                    vPri = ((int.Parse(permission.RepInv2.Trim()) == 2) ? q.FirstOrDefault().Price1.Value : ((int.Parse(permission.RepInv2.Trim()) == 3) ? q.FirstOrDefault().Price2.Value : ((int.Parse(permission.RepInv2.Trim()) == 4) ? q.FirstOrDefault().Price3.Value : ((int.Parse(permission.RepInv2.Trim()) != 5) ? q.FirstOrDefault().Price5.Value : q.FirstOrDefault().Price4.Value))));
                }
                else
                {
                    if (q.FirstOrDefault().Unit1.HasValue && q.FirstOrDefault().T_Unit.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                    {
                        vPri = q.FirstOrDefault().UntPri1.Value;
                    }
                    if (q.FirstOrDefault().Unit2.HasValue && q.FirstOrDefault().T_Unit1.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                    {
                        vPri = q.FirstOrDefault().UntPri2.Value;
                    }
                    if (q.FirstOrDefault().Unit3.HasValue && q.FirstOrDefault().T_Unit2.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                    {
                        vPri = q.FirstOrDefault().UntPri3.Value;
                    }
                    if (q.FirstOrDefault().Unit4.HasValue && q.FirstOrDefault().T_Unit3.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                    {
                        vPri = q.FirstOrDefault().UntPri4.Value;
                    }
                    if (q.FirstOrDefault().Unit5.HasValue && q.FirstOrDefault().T_Unit4.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                    {
                        vPri = q.FirstOrDefault().UntPri5.Value;
                    }
                }
                if (int.Parse(permission.RepInv4.Trim()) != 1)
                {
                    vPri2 = ((int.Parse(permission.RepInv4.Trim()) == 2) ? q.FirstOrDefault().Price1.Value : ((int.Parse(permission.RepInv4.Trim()) == 3) ? q.FirstOrDefault().Price2.Value : ((int.Parse(permission.RepInv4.Trim()) == 4) ? q.FirstOrDefault().Price3.Value : ((int.Parse(permission.RepInv4.Trim()) != 5) ? q.FirstOrDefault().Price5.Value : q.FirstOrDefault().Price4.Value))));
                }
                else
                {
                    if (q.FirstOrDefault().Unit1.HasValue && q.FirstOrDefault().T_Unit.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                    {
                        vPri2 = q.FirstOrDefault().UntPri1.Value;
                    }
                    if (q.FirstOrDefault().Unit2.HasValue && q.FirstOrDefault().T_Unit1.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                    {
                        vPri2 = q.FirstOrDefault().UntPri2.Value;
                    }
                    if (q.FirstOrDefault().Unit3.HasValue && q.FirstOrDefault().T_Unit2.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                    {
                        vPri2 = q.FirstOrDefault().UntPri3.Value;
                    }
                    if (q.FirstOrDefault().Unit4.HasValue && q.FirstOrDefault().T_Unit3.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                    {
                        vPri2 = q.FirstOrDefault().UntPri4.Value;
                    }
                    if (q.FirstOrDefault().Unit5.HasValue && q.FirstOrDefault().T_Unit4.Arb_Des == FlxInv.GetData(_row, 3).ToString())
                    {
                        vPri2 = q.FirstOrDefault().UntPri5.Value;
                    }
                }
                if (vPri > 0.0 && vPri2 > 0.0)
                {
                    if (vPri < vPri2)
                    {
                        if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) < vPri || double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) > vPri2)
                        {
                            if (_Sts)
                            {
                                MessageBox.Show((LangArEn == 0) ? ("يجب البيع بسعر " + vPri + " وعدم تجاوز السعر " + vPri2 + " .. راجع صلاحيات المستخدمين") : "You must sell at other selling ... Check the Users Authorizations", VarGeneral.ProdectNam);
                            }
                            FlxInv.SetData(_row, 8, vPri);
                        }
                    }
                    else if (vPri > vPri2)
                    {
                        if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) > vPri || double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) < vPri2)
                        {
                            if (_Sts)
                            {
                                MessageBox.Show((LangArEn == 0) ? ("يجب البيع بسعر " + vPri2 + " وعدم تجاوز السعر " + vPri + " .. راجع صلاحيات المستخدمين") : "You must sell at other selling ... Check the Users Authorizations", VarGeneral.ProdectNam);
                            }
                            FlxInv.SetData(_row, 8, vPri);
                        }
                    }
                    else if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) != vPri)
                    {
                        if (_Sts)
                        {
                            MessageBox.Show((LangArEn == 0) ? ("يجب البيع بسعر " + vPri + " .. راجع صلاحيات المستخدمين") : "You must sell at other selling ... Check the Users Authorizations", VarGeneral.ProdectNam);
                        }
                        FlxInv.SetData(_row, 8, vPri);
                    }
                }
                else if (vPri > 0.0 && vPri2 <= 0.0)
                {
                    if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(_row, 8)))) != vPri)
                    {
                        if (_Sts)
                        {
                            MessageBox.Show((LangArEn == 0) ? ("يجب البيع بسعر " + vPri + " .. راجع صلاحيات المستخدمين") : "You must sell at other selling ... Check the Users Authorizations", VarGeneral.ProdectNam);
                        }
                        FlxInv.SetData(_row, 8, vPri);
                    }
                }
                else if (vPri <= 0.0 && vPri2 > 0.0)
                {
                    if (_Sts)
                    {
                        MessageBox.Show((LangArEn == 0) ? (" يجب عدم تجاوز السعر " + vPri2 + " .. راجع صلاحيات المستخدمين") : "You must sell at other selling ... Check the Users Authorizations", VarGeneral.ProdectNam);
                    }
                    FlxInv.SetData(_row, 8, vPri2);
                }
            }
            catch
            {
            }
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
            try
            {
                if (e.Col == 2 || e.Col == 4)
                {
                    oldItemName = FlxInv.GetData(e.Row, e.Col).ToString() ?? "";
                }
            }
            catch
            {
                oldItemName = "";
            }
            try
            {
                _RowIndex = e.Row;
            }
            catch
            {
            }
            GridDetUpdate(FlxInv.RowSel);
        }
        private void FlxInv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
            {
                return;
            }
            try
            {
                if (FlxInv.GetData(RowSel, 1).ToString() == null)
                {
                }
            }
            catch
            {
            }
        }
        private void FlxInv_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (string.Concat(FlxInv.GetData(FlxInv.RowSel, 1)) != "")
                {
                    _Items = db.StockItem(string.Concat(FlxInv.GetData(FlxInv.RowSel, 1)));
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtItemName.Text = _Items.Arb_Des.Trim();
                    }
                    else
                    {
                        txtItemName.Text = _Items.Eng_Des.Trim();
                    }
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
                    BindDataOfStkQty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 1)));
                }
                int vRowIndex = FlxInv.RowSel;
                try
                {
                    if (FlxInv.ColSel == 7 || FlxInv.ColSel == 8 || FlxInv.ColSel == 9 || FlxInv.ColSel == 31)
                    {
                        PanaHide(Sts: true);
                        if (FlxInv.ColSel == 7)
                        {
                            vQtyGraid = true;
                        }
                        else if (FlxInv.ColSel == 8)
                        {
                            vPriceGraid = true;
                        }
                        else if (FlxInv.ColSel == 9)
                        {
                            vDisGraid = true;
                        }
                        else if (FlxInv.ColSel == 31)
                        {
                            vTotGraid = true;
                        }
                        else if (FlxInv.ColSel == 38)
                        {
                            vTax = true;
                        }
                    }
                }
                catch
                {
                    groupPanel_BoardNo.Enabled = false;
                    vQtyGraid = false;
                    vPriceGraid = false;
                    vDisGraid = false;
                    vTotGraid = false;
                    vTax = false;
                }
            }
            catch
            {
            }
        }
        private void GridDetUpdate(int vRow)
        {
            if (State == FormState.Saved)
            {
                return;
            }
            try
            {
                try
                {
                    dataGridView_ItemDet.Clear(ClearFlags.Content, 1, 1, dataGridView_ItemDet.Rows.Count - 1, 34);
                }
                catch
                {
                }
                dataGridView_ItemDet.Rows.Count = 1;
                if (!string.IsNullOrEmpty(FlxInv.GetData(vRow, 1).ToString()) && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(vRow, 32)))) == 2.0)
                {
                    _Items = db.StockItemList(FlxInv.GetData(vRow, 1).ToString()).First();
                    dataGridView_ItemDet.Visible = false;
                    Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
                    if (State == FormState.New && (int.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(vRow, 25)))) <= 0 || string.IsNullOrEmpty(FlxInv.GetData(vRow, 25).ToString())))
                    {
                        List<T_ItemDet> ItmDet = db.T_ItemDets.Where((T_ItemDet t) => t.ItmNo == _Items.Itm_No).ToList();
                        SetLinesDet(ItmDet);
                        return;
                    }
                    List<T_SINVDET> ItmDEt = dbc.T_SINVDETs.Where((T_SINVDET t) => t.SInvId == (int?)int.Parse(VarGeneral.TString.TEmpty("" + FlxInv.GetData(vRow, 25)))).ToList();
                    if (ItmDEt.Count <= 0)
                    {
                        List<T_ItemDet> ItmDet = db.T_ItemDets.Where((T_ItemDet t) => t.ItmNo == _Items.Itm_No).ToList();
                        SetLinesDet(ItmDet);
                    }
                    else
                    {
                        SetLinesDET(ItmDEt, vRow);
                    }
                }
                else
                {
                    dataGridView_ItemDet.Visible = false;
                }
            }
            catch
            {
                dataGridView_ItemDet.Visible = false;
            }
        }
        private void dataGridView_ItemDet_MouseDown(object sender, MouseEventArgs e)
        {
            if (!(string.Concat(dataGridView_ItemDet.GetData(dataGridView_ItemDet.RowSel, 1)) != ""))
            {
                return;
            }
            _Items = db.StockItem(string.Concat(dataGridView_ItemDet.GetData(dataGridView_ItemDet.RowSel, 1)));
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                txtItemName.Text = _Items.Arb_Des.Trim();
            }
            else
            {
                txtItemName.Text = _Items.Eng_Des.Trim();
            }
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
            dataGridView_ItemDet.Cols[3].ComboList = CoA;
            dataGridView_ItemDet.Cols[5].ComboList = CoE;
            BindDataOfStkQtyDEt(string.Concat(dataGridView_ItemDet.GetData(dataGridView_ItemDet.RowSel, 1)));
        }
        private void BindDataOfStkQtyDEt(string ItmNo)
        {
            try
            {
                FlxStkQty.Clear(ClearFlags.Content, 1, 1, 1, 1);
                listStkQty = db.T_STKSQTies.Where((T_STKSQTY t) => t.itmNo == ItmNo).ToList();
                dataGridView_ItemDet.SetData(dataGridView_ItemDet.Row, 24, 0);
                for (int iiCnt = 0; iiCnt < listStkQty.Count; iiCnt++)
                {
                    _StksQty = listStkQty[iiCnt];
                    for (int I = 1; I < FlxStkQty.Rows.Count; I++)
                    {
                        if (_StksQty.storeNo.Value.ToString().Trim() == FlxStkQty.GetData(I, 0).ToString())
                        {
                            FlxStkQty.SetData(I, 1, _StksQty.stkQty / double.Parse(VarGeneral.TString.TEmpty(dataGridView_ItemDet.GetData(dataGridView_ItemDet.Row, 11).ToString())));
                            if (_StksQty.storeNo.Value.ToString().Trim() == dataGridView_ItemDet.GetData(dataGridView_ItemDet.RowSel, 6).ToString())
                            {
                                dataGridView_ItemDet.SetData(dataGridView_ItemDet.Row, 24, _StksQty.stkQty);
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }
        private void FillItemDet(T_Item _Itm, bool Barcod, int vRow, int vUntID, int vStoreNo, double vQty, double vPrice)
        {
            dataGridView_ItemDet.SetData(vRow, 1, _Itm.Itm_No.Trim());
            dataGridView_ItemDet.SetData(vRow, 2, _Itm.Arb_Des.Trim());
            dataGridView_ItemDet.SetData(vRow, 4, _Itm.Eng_Des.Trim());
            dataGridView_ItemDet.SetData(vRow, 6, (vUntID == 0) ? 1 : vStoreNo);
            string CoA = "";
            string CoE = "";
            string DefUnitA = "";
            string DefUnitE = "";
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (!((vUntID != 0) ? (vUntID == 1) : (_Itm.Unit1 == _Unit.Unit_ID)))
                {
                    continue;
                }
                if (CoA != "")
                {
                    CoA += "|";
                    CoE += "|";
                }
                CoA += _Unit.Arb_Des;
                CoE += _Unit.Eng_Des;
                if (_Itm.DefultUnit == 1 && DefPack == 0)
                {
                    Pack = _Itm.Pack1.Value;
                    if (vUntID == 0)
                    {
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                    }
                    else
                    {
                        DefUnitA = _Itm.T_Unit.Arb_Des;
                        DefUnitE = _Itm.T_Unit.Eng_Des;
                    }
                    dataGridView_ItemDet.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri1.Value : vPrice);
                    dataGridView_ItemDet.SetData(vRow, 11, _Itm.Pack1.Value);
                }
                else if (vUntID != 0 || DefPack == 1)
                {
                    Pack = _Itm.Pack1.Value;
                    if (vUntID == 0)
                    {
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                    }
                    else
                    {
                        DefUnitA = _Itm.T_Unit.Arb_Des;
                        DefUnitE = _Itm.T_Unit.Eng_Des;
                    }
                    dataGridView_ItemDet.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri1.Value : vPrice);
                    dataGridView_ItemDet.SetData(vRow, 11, _Itm.Pack1);
                }
                if (vUntID == 0)
                {
                }
                break;
            }
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (!((vUntID != 0) ? (vUntID == 2) : (_Itm.Unit2 == _Unit.Unit_ID)))
                {
                    continue;
                }
                if (CoA != "")
                {
                    CoA += "|";
                    CoE += "|";
                }
                CoA += _Unit.Arb_Des;
                CoE += _Unit.Arb_Des;
                if (_Itm.DefultUnit == 2 && DefPack == 0)
                {
                    Pack = _Itm.Pack2.Value;
                    if (vUntID == 0)
                    {
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                    }
                    else
                    {
                        DefUnitA = _Itm.T_Unit1.Arb_Des;
                        DefUnitE = _Itm.T_Unit1.Eng_Des;
                    }
                    dataGridView_ItemDet.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri2.Value : vPrice);
                    dataGridView_ItemDet.SetData(vRow, 11, _Itm.Pack2);
                }
                else if (vUntID != 0 || DefPack == 2)
                {
                    Pack = _Itm.Pack2.Value;
                    if (vUntID == 0)
                    {
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                    }
                    else
                    {
                        DefUnitA = _Itm.T_Unit1.Arb_Des;
                        DefUnitE = _Itm.T_Unit1.Eng_Des;
                    }
                    dataGridView_ItemDet.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri2.Value : vPrice);
                    dataGridView_ItemDet.SetData(vRow, 11, _Itm.Pack2);
                }
                if (vUntID == 0)
                {
                }
                break;
            }
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (!((vUntID != 0) ? (vUntID == 3) : (_Itm.Unit3 == _Unit.Unit_ID)))
                {
                    continue;
                }
                if (CoA != "")
                {
                    CoA += "|";
                    CoE += "|";
                }
                CoA += _Unit.Arb_Des;
                CoE += _Unit.Eng_Des;
                if (_Itm.DefultUnit == 3 && DefPack == 0)
                {
                    Pack = _Itm.Pack3.Value;
                    if (vUntID == 0)
                    {
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                    }
                    else
                    {
                        DefUnitA = _Itm.T_Unit2.Arb_Des;
                        DefUnitE = _Itm.T_Unit2.Eng_Des;
                    }
                    dataGridView_ItemDet.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri3.Value : vPrice);
                    dataGridView_ItemDet.SetData(vRow, 11, _Itm.Pack3);
                }
                else if (vUntID != 0 || DefPack == 3)
                {
                    Pack = _Itm.Pack3.Value;
                    if (vUntID == 0)
                    {
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                    }
                    else
                    {
                        DefUnitA = _Itm.T_Unit2.Arb_Des;
                        DefUnitE = _Itm.T_Unit2.Eng_Des;
                    }
                    dataGridView_ItemDet.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri3.Value : vPrice);
                    dataGridView_ItemDet.SetData(vRow, 11, _Itm.Pack3);
                }
                if (vUntID == 0)
                {
                }
                break;
            }
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (!((vUntID != 0) ? (vUntID == 4) : (_Itm.Unit4 == _Unit.Unit_ID)))
                {
                    continue;
                }
                if (CoA != "")
                {
                    CoA += "|";
                    CoE += "|";
                }
                CoA += _Unit.Arb_Des;
                CoE += _Unit.Eng_Des;
                if (_Itm.DefultUnit == 4 && DefPack == 0)
                {
                    Pack = _Itm.Pack4.Value;
                    if (vUntID == 0)
                    {
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                    }
                    else
                    {
                        DefUnitA = _Itm.T_Unit3.Arb_Des;
                        DefUnitE = _Itm.T_Unit3.Eng_Des;
                    }
                    dataGridView_ItemDet.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri4.Value : vPrice);
                    dataGridView_ItemDet.SetData(vRow, 11, _Itm.Pack4);
                }
                else if (vUntID != 0 || DefPack == 4)
                {
                    Pack = _Itm.Pack4.Value;
                    if (vUntID == 0)
                    {
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                    }
                    else
                    {
                        DefUnitA = _Itm.T_Unit3.Arb_Des;
                        DefUnitE = _Itm.T_Unit3.Eng_Des;
                    }
                    dataGridView_ItemDet.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri4.Value : vPrice);
                    dataGridView_ItemDet.SetData(vRow, 11, _Itm.Pack4);
                }
                if (vUntID == 0)
                {
                }
                break;
            }
            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
            {
                _Unit = listUnit[iiCnt];
                if (!((vUntID != 0) ? (vUntID == 5) : (_Itm.Unit5 == _Unit.Unit_ID)))
                {
                    continue;
                }
                if (CoA != "")
                {
                    CoA += "|";
                    CoE += "|";
                }
                CoA += _Unit.Arb_Des;
                CoE += _Unit.Eng_Des;
                if (_Itm.DefultUnit == 5 && DefPack == 0)
                {
                    Pack = _Itm.Pack5.Value;
                    if (vUntID == 0)
                    {
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                    }
                    else
                    {
                        DefUnitA = _Itm.T_Unit4.Arb_Des;
                        DefUnitE = _Itm.T_Unit4.Eng_Des;
                    }
                    dataGridView_ItemDet.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri5.Value : vPrice);
                    dataGridView_ItemDet.SetData(vRow, 11, _Itm.Pack5);
                }
                else if (vUntID != 0 || DefPack == 5)
                {
                    Pack = _Itm.Pack5.Value;
                    if (vUntID == 0)
                    {
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                    }
                    else
                    {
                        DefUnitA = _Itm.T_Unit4.Arb_Des;
                        DefUnitE = _Itm.T_Unit4.Eng_Des;
                    }
                    dataGridView_ItemDet.SetData(vRow, 8, (vUntID == 0) ? _Itm.UntPri5.Value : vPrice);
                    dataGridView_ItemDet.SetData(vRow, 11, _Itm.Pack5);
                }
                if (vUntID == 0)
                {
                }
                break;
            }
            dataGridView_ItemDet.Cols[3].ComboList = CoA;
            dataGridView_ItemDet.Cols[5].ComboList = CoE;
            dataGridView_ItemDet.SetData(vRow, 3, DefUnitA);
            dataGridView_ItemDet.SetData(vRow, 5, DefUnitE);
            dataGridView_ItemDet.SetData(vRow, 10, _Itm.AvrageCost / RateValue);
            dataGridView_ItemDet.SetData(vRow, 30, _Itm.LastCost * double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(vRow, 11)))) / RateValue);
            dataGridView_ItemDet.SetData(vRow, 28, _Itm.Lot);
            dataGridView_ItemDet.SetData(vRow, 32, _Itm.ItmTyp);
            dataGridView_ItemDet.SetData(vRow, 33, _Itm.ItmLoc);
            dataGridView_ItemDet.SetData(vRow, 18, _Itm.DefPack);
            dataGridView_ItemDet.SetData(vRow, 19, _Itm.Price1);
            dataGridView_ItemDet.SetData(vRow, 20, _Itm.Price2);
            dataGridView_ItemDet.SetData(vRow, 21, _Itm.Price3);
            dataGridView_ItemDet.SetData(vRow, 22, _Itm.Price4);
            dataGridView_ItemDet.SetData(vRow, 23, _Itm.Price5);
            dataGridView_ItemDet.SetData(vRow, 17, vPrice);
            dataGridView_ItemDet.SetData(vRow, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(vRow, 17)))) / RateValue);
            dataGridView_ItemDet.SetData(vRow, 7, (vUntID == 0) ? 0.0 : vQty);
            dataGridView_ItemDet.SetData(vRow, 29, vQty);
            dataGridView_ItemDet.SetData(vRow, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(vRow, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(vRow, 11)))));
            dataGridView_ItemDet.SetData(vRow, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(vRow, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(vRow, 8)))));
            VarGeneral.Flush();
        }
        public void SetLinesDet(List<T_ItemDet> listDet)
        {
            try
            {
                dataGridView_ItemDet.Rows.Count = listDet.Count + 1;
                for (int iiCnt = 1; iiCnt <= listDet.Count; iiCnt++)
                {
                    T_ItemDet _ItemsDet = listDet[iiCnt - 1];
                    FillItemDet(db.StockItem(_ItemsDet.GItmNo), Barcod: false, iiCnt, _ItemsDet.Unit_.Value, _ItemsDet.StoreNo.Value, Math.Abs(_ItemsDet.Qty.Value), _ItemsDet.Price.Value);
                }
                if (State == FormState.Saved)
                {
                    return;
                }
                double InvCost = 0.0;
                for (int i = 1; i < dataGridView_ItemDet.Rows.Count; i++)
                {
                    try
                    {
                        dataGridView_ItemDet.SetData(i, 7, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(i, 7)))) * ((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) > 0.0) ? double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) : 1.0));
                        dataGridView_ItemDet.SetData(i, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(i, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(i, 17)))));
                        dataGridView_ItemDet.SetData(i, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(i, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(i, 11)))));
                        InvCost += double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(i, 10)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(dataGridView_ItemDet.GetData(i, 12))));
                    }
                    catch
                    {
                    }
                }
                FlxInv.SetData(FlxInv.RowSel, 10, InvCost);
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "حدث خطأ أثناء تعبئة بيانات الصنف المجمع .." : "An error occurred while filling lines ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtItemName.Text = _Items.Arb_Des.Trim();
                }
                else
                {
                    txtItemName.Text = _Items.Eng_Des.Trim();
                }
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
        private void BindDataOfItem()
        {
            List<T_Item> listSer = new List<T_Item>();
            if ((string)FlxInv.GetData(FlxInv.Row, 1) != "" && FlxInv.GetData(FlxInv.Row, 1) != null)
            {
                listSer = db.StockItemList(FlxInv.GetData(FlxInv.Row, 1).ToString());
                if (listSer.Count != 0)
                {
                    _Items = listSer[0];
                }
            }
            FlxInv.SetData(FlxInv.Row, 1, _Items.Itm_No.Trim());
            FlxInv.SetData(FlxInv.Row, 2, _Items.Arb_Des.Trim());
            FlxInv.SetData(FlxInv.Row, 4, _Items.Eng_Des.Trim());
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                txtItemName.Text = _Items.Arb_Des.Trim();
            }
            else
            {
                txtItemName.Text = _Items.Eng_Des.Trim();
            }
            FlxInv.SetData(FlxInv.Row, 6, 1);
            try
            {
                if (permission.DefStores.HasValue && permission.DefStores.Value > 0)
                {
                    FlxInv.SetData(FlxInv.Row, 6, permission.DefStores.Value);
                }
            }
            catch
            {
                FlxInv.SetData(FlxInv.Row, 6, 1);
            }
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
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri1.Value);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack1.Value);
                    }
                    else if (DefPack == 1)
                    {
                        Pack = _Items.Pack1.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri1.Value);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack1.Value);
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
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri2.Value);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack2.Value);
                    }
                    else if (DefPack == 2)
                    {
                        Pack = _Items.Pack2.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri2.Value);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack2.Value);
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
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri3.Value);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack3.Value);
                    }
                    else if (DefPack == 3)
                    {
                        Pack = _Items.Pack3.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri3.Value);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack3.Value);
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
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri4.Value);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack4.Value);
                    }
                    else if (DefPack == 4)
                    {
                        Pack = _Items.Pack4.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri4.Value);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack4.Value);
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
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri5.Value);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack5.Value);
                    }
                    else if (DefPack == 5)
                    {
                        Pack = _Items.Pack5.Value;
                        DefUnitA = _Unit.Arb_Des;
                        DefUnitE = _Unit.Eng_Des;
                        FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri5.Value);
                        FlxInv.SetData(FlxInv.Row, 11, _Items.Pack5.Value);
                    }
                    break;
                }
            }
            try
            {
                if (_Items.Unit2.HasValue && _stsClick == 0)
                {
                    FrmItemSize frm = new FrmItemSize(_Items.Itm_No);
                    frm.Tag = LangArEn;
                    frm.TopMost = true;
                    frm.ShowDialog();
                    if (frm.vSts_Op)
                    {
                        if (frm.vSize_ == 0)
                        {
                            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                            {
                                _Unit = listUnit[iiCnt];
                                if (_Items.Unit1 == _Unit.Unit_ID)
                                {
                                    Pack = _Items.Pack1.Value;
                                    DefUnitA = _Unit.Arb_Des;
                                    DefUnitE = _Unit.Eng_Des;
                                    FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri1.Value);
                                    FlxInv.SetData(FlxInv.Row, 11, _Items.Pack1.Value);
                                    break;
                                }
                            }
                        }
                        else if (frm.vSize_ == 1)
                        {
                            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                            {
                                _Unit = listUnit[iiCnt];
                                if (_Items.Unit2 == _Unit.Unit_ID)
                                {
                                    Pack = _Items.Pack2.Value;
                                    DefUnitA = _Unit.Arb_Des;
                                    DefUnitE = _Unit.Eng_Des;
                                    FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri2.Value);
                                    FlxInv.SetData(FlxInv.Row, 11, _Items.Pack2.Value);
                                    break;
                                }
                            }
                        }
                        else if (frm.vSize_ == 2)
                        {
                            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                            {
                                _Unit = listUnit[iiCnt];
                                if (_Items.Unit3 == _Unit.Unit_ID)
                                {
                                    Pack = _Items.Pack3.Value;
                                    DefUnitA = _Unit.Arb_Des;
                                    DefUnitE = _Unit.Eng_Des;
                                    FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri3.Value);
                                    FlxInv.SetData(FlxInv.Row, 11, _Items.Pack3.Value);
                                    break;
                                }
                            }
                        }
                        else if (frm.vSize_ == 3)
                        {
                            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                            {
                                _Unit = listUnit[iiCnt];
                                if (_Items.Unit4 == _Unit.Unit_ID)
                                {
                                    Pack = _Items.Pack4.Value;
                                    DefUnitA = _Unit.Arb_Des;
                                    DefUnitE = _Unit.Eng_Des;
                                    FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri4.Value);
                                    FlxInv.SetData(FlxInv.Row, 11, _Items.Pack4.Value);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            for (int iiCnt = 0; iiCnt < listUnit.Count; iiCnt++)
                            {
                                _Unit = listUnit[iiCnt];
                                if (_Items.Unit5 == _Unit.Unit_ID)
                                {
                                    Pack = _Items.Pack5.Value;
                                    DefUnitA = _Unit.Arb_Des;
                                    DefUnitE = _Unit.Eng_Des;
                                    FlxInv.SetData(FlxInv.Row, 8, _Items.UntPri5.Value);
                                    FlxInv.SetData(FlxInv.Row, 11, _Items.Pack5.Value);
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        FlxInv.SetData(FlxInv.Row, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) / RateValue);
                        try
                        {
                            if (FlxInv.RowSel > 0)
                            {
                                if (FlxInv.Rows[FlxInv.Row].Height > 33)
                                {
                                    FlxInv.RemoveItem(FlxInv.Row);
                                    FlxInv.RemoveItem(FlxInv.Row);
                                }
                                else
                                {
                                    FlxInv.RemoveItem(FlxInv.Row - 1);
                                    FlxInv.RemoveItem(FlxInv.Row);
                                }
                                GetInvTot();
                            }
                        }
                        catch
                        {
                            FlxInv.SetData(FlxInv.Row, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) / RateValue);
                        }
                    }
                }
                else
                {
                    FlxInv.SetData(FlxInv.Row, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) / RateValue);
                }
            }
            catch
            {
                FlxInv.SetData(FlxInv.Row, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) / RateValue);
            }
            FlxInv.Cols[3].ComboList = CoA;
            FlxInv.Cols[5].ComboList = CoE;
            FlxInv.SetData(FlxInv.Row, 3, DefUnitA);
            FlxInv.SetData(FlxInv.Row, 5, DefUnitE);
            BindDataofItemPrice();
            PermissionPrice(FlxInv.Row, 8, _Sts: false);
            FlxInv.SetData(FlxInv.Row, 10, _Items.AvrageCost / RateValue);
            FlxInv.SetData(FlxInv.Row, 30, _Items.LastCost * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 11)))) / RateValue);
            FlxInv.SetData(FlxInv.Row, 28, _Items.Lot);
            if (_Items.Lot == 1)
            {
                FlxInv.Cols[27].Visible = true;
                FlxInv.Cols[35].Visible = true;
            }
            FlxInv.SetData(FlxInv.Row, 32, _Items.ItmTyp);
            FlxInv.SetData(FlxInv.Row, 33, _Items.ItmLoc);
            FlxInv.SetData(FlxInv.Row, 18, _Items.DefPack);
            FlxInv.SetData(FlxInv.Row, 19, _Items.Price1);
            FlxInv.SetData(FlxInv.Row, 20, _Items.Price2);
            FlxInv.SetData(FlxInv.Row, 21, _Items.Price3);
            FlxInv.SetData(FlxInv.Row, 22, _Items.Price4);
            FlxInv.SetData(FlxInv.Row, 23, _Items.Price5);
            FlxInv.SetData(FlxInv.Row, 8, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) / RateValue);
            if (FlxInv.Cols[9].Visible)
            {
                FlxInv.SetData(FlxInv.Row, 9, _Items.ItemDis.Value);
            }
            else
            {
                FlxInv.SetData(FlxInv.Row, 9, 0);
            }
            if (FlxInv.Cols[38].Visible)
            {
                FlxInv.SetData(FlxInv.Row, 38, VarGeneral.TString.ChkStatShow(_InvSetting.TaxOptions, 2) ? _Items.TaxPurchas : _Items.TaxSales);
            }
            else
            {
                FlxInv.SetData(FlxInv.Row, 38, 0);
            }
            PriceLoc = (double)FlxInv.GetData(FlxInv.Row, 8);
            BindDataOfStkQty(_Items.Itm_No.Trim());
            FlxInv.SetData(FlxInv.Row, 7, 1);
            FlxInv.SetData(FlxInv.Row, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 11)))));
            double ItmDis = 0.0;
            double ItmAddTax = 0.0;
            try
            {
                ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 9)))) / 100.0);
            }
            catch
            {
                ItmDis = 0.0;
            }
            try
            {
                ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
            }
            catch
            {
                ItmAddTax = 0.0;
            }
            if (!switchButton_TaxLines.Value || switchButton_TaxByTotal.Value)
            {
                ItmAddTax = 0.0;
            }
            FlxInv.SetData(FlxInv.Row, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) - ItmDis + ItmAddTax);
            if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 31)))) > 0.0)
            {
                ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                FlxInv.SetData(FlxInv.Row, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.Row, 31)))) + ItmAddTax);
            }
            if (!chekReptItem(Col_1: true))
            {
                FlxInv.Col = 0;
            }
            else
            {
                FlxInv.Col = 0;
            }
            GetInvTot();
            base.ActiveControl = FlxInv;
            FlxInv.Row = FlxInv.Row;
            FlxInv.RowSel = FlxInv.Row;
            FlxInv.Col = 7;
            FlxInv.ColSel = 7;
            if (FlxInv.ColSel == 7 || FlxInv.ColSel == 8 || FlxInv.ColSel == 9 || FlxInv.ColSel == 31)
            {
                PanaHide(Sts: true);
            }
            vQtyGraid = true;
            VarGeneral.Flush();
        }
        private void BindDataOfStkQty(string ItmNo)
        {
            FlxStkQty.Clear(ClearFlags.Content, 1, 1, 1, 1);
            using (Stock_DataDataContext dbC = new Stock_DataDataContext(VarGeneral.BranchCS))
            {
                listStkQty = dbC.T_STKSQTies.Where((T_STKSQTY t) => t.itmNo == ItmNo).ToList();
            }
            FlxInv.SetData(FlxInv.Row, 24, 0);
            for (int iiCnt = 0; iiCnt < listStkQty.Count; iiCnt++)
            {
                _StksQty = listStkQty[iiCnt];
                for (int I = 1; I < FlxStkQty.Rows.Count; I++)
                {
                    if (_StksQty.storeNo.Value.ToString().Trim() == FlxStkQty.GetData(I, 0).ToString())
                    {
                        FlxStkQty.SetData(I, 1, _StksQty.stkQty / double.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(FlxInv.Row, 11).ToString())));
                        if (_StksQty.storeNo.Value.ToString().Trim() == FlxInv.GetData(FlxInv.RowSel, 6).ToString())
                        {
                            FlxInv.SetData(FlxInv.Row, 24, _StksQty.stkQty);
                        }
                    }
                }
            }
        }
        private void chekRept()
        {
            if (State == FormState.Saved || FlxInv.ColSel != 1)
            {
                return;
            }
            for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
            {
                if (!string.IsNullOrEmpty(string.Concat(FlxInv.GetData(iiCnt, 1))) && iiCnt != FlxInv.RowSel && FlxInv.GetData(iiCnt, 1).ToString() == FlxInv.GetData(FlxInv.RowSel, 1).ToString())
                {
                    MessageBox.Show((LangArEn == 0) ? "تنبيه .. لقد قمت بأدخال هذا الصنف مسبقا\u064b في هذه الفاتورة" : "Alert .. You have entered already this product in this bill", VarGeneral.ProdectNam);
                    break;
                }
            }
        }
        private bool chekReptItem(bool Col_1)
        {
            if (State != 0 && (FlxInv.ColSel == 31 || FlxInv.ColSel == 7 || FlxInv.ColSel == 8 || Col_1) && VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 17))
            {
                double vQty = 0.0;
                try
                {
                    vQty = double.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(FlxInv.RowSel, 7).ToString()));
                }
                catch
                {
                    vQty = 0.0;
                }
                for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
                {
                    if (string.IsNullOrEmpty(string.Concat(FlxInv.GetData(iiCnt, 1))) || iiCnt == FlxInv.RowSel || !(FlxInv.GetData(iiCnt, 1).ToString() == FlxInv.GetData(FlxInv.RowSel, 1).ToString()) || !(FlxInv.GetData(iiCnt, 11).ToString() == FlxInv.GetData(FlxInv.RowSel, 11).ToString()) || !(FlxInv.GetData(iiCnt, 6).ToString() == FlxInv.GetData(FlxInv.RowSel, 6).ToString()))
                    {
                        continue;
                    }
                    double ItmDis = 0.0;
                    double ItmAddTax = 0.0;
                    try
                    {
                        FlxInv.SetData(FlxInv.RowSel, 7, double.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 7).ToString() ?? "")) + vQty);
                        double RealQ = 0.0;
                        RealQ = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 11))));
                        if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 32)))) == 3.0)
                        {
                            goto IL_0b94;
                        }
                        if (double.Parse(FlxInv.GetData(FlxInv.RowSel, 24).ToString()) <= 0.0)
                        {
                            if (VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 1))
                            {
                                goto IL_0b94;
                            }
                            MessageBox.Show((LangArEn == 0) ? ("لا يمكن البيع والكمية  " + double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 24)))) + "تأكد من صلاحيات المستخدمين") : ("Can't Sale and the Quantity " + double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 24)))) + " Check the Users Authorizations"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            FlxInv.SetData(FlxInv.RowSel, 7, 0);
                            ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 9)))) / 100.0);
                            ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                            if (!switchButton_TaxLines.Value || switchButton_TaxByTotal.Value)
                            {
                                ItmAddTax = 0.0;
                            }
                            FlxInv.SetData(FlxInv.RowSel, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 11)))));
                            FlxInv.SetData(FlxInv.RowSel, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) - ItmDis + ItmAddTax);
                            if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 31)))) > 0.0)
                            {
                                ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                                FlxInv.SetData(FlxInv.RowSel, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 31)))) + ItmAddTax);
                            }
                            FlxInv.Row = FlxInv.RowSel;
                            FlxInv.Col = 31;
                        }
                        else
                        {
                            if (!(double.Parse(FlxInv.GetData(FlxInv.RowSel, 24).ToString()) < RealQ) || VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 1))
                            {
                                goto IL_0b94;
                            }
                            MessageBox.Show((LangArEn == 0) ? ("لا يمكن البيع بأكثر من الكمية  " + double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 24)))) + "راجع صلاحيات المستخدمين") : ("Can't Sale More Than available Quantity " + double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 24)))) + " Check the Users Authorizations"), VarGeneral.ProdectNam);
                            FlxInv.SetData(FlxInv.RowSel, 7, 0);
                            ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 9)))) / 100.0);
                            ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                            if (!switchButton_TaxLines.Value || switchButton_TaxByTotal.Value)
                            {
                                ItmAddTax = 0.0;
                            }
                            FlxInv.SetData(FlxInv.RowSel, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 11)))));
                            FlxInv.SetData(FlxInv.RowSel, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) - ItmDis + ItmAddTax);
                            if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 31)))) > 0.0)
                            {
                                ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                                FlxInv.SetData(FlxInv.RowSel, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 31)))) + ItmAddTax);
                            }
                            FlxInv.Row = FlxInv.RowSel;
                            FlxInv.Col = 31;
                        }
                        goto end_IL_01a7;
                    IL_0b94:
                        if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 10)))) > double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) && !VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 2))
                        {
                            MessageBox.Show((LangArEn == 0) ? "لا يمكن البيع بأقل من سعر التكلفة .. راجع صلاحيات المستخدمين" : "Can't Sale Less Then Cost Price ... Check the Users Authorizations", VarGeneral.ProdectNam);
                            FlxInv.SetData(FlxInv.RowSel, 8, PriceLoc);
                            ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 9)))) / 100.0);
                            ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                            if (!switchButton_TaxLines.Value || switchButton_TaxByTotal.Value)
                            {
                                ItmAddTax = 0.0;
                            }
                            FlxInv.SetData(FlxInv.RowSel, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 11)))));
                            FlxInv.SetData(FlxInv.RowSel, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) - ItmDis + ItmAddTax);
                            if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 31)))) > 0.0)
                            {
                                ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                                FlxInv.SetData(FlxInv.RowSel, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 31)))) + ItmAddTax);
                            }
                            FlxInv.Row = FlxInv.RowSel;
                            FlxInv.Col = 31;
                            break;
                        }
                        goto IL_136a;
                    end_IL_01a7:;
                    }
                    catch
                    {
                        FlxInv.SetData(FlxInv.RowSel, 7, 0);
                        ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 9)))) / 100.0);
                        ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                        if (!switchButton_TaxLines.Value || switchButton_TaxByTotal.Value)
                        {
                            ItmAddTax = 0.0;
                        }
                        FlxInv.SetData(FlxInv.RowSel, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 11)))));
                        FlxInv.SetData(FlxInv.RowSel, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) - ItmDis + ItmAddTax);
                        if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 31)))) > 0.0)
                        {
                            ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                            FlxInv.SetData(FlxInv.RowSel, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 31)))) + ItmAddTax);
                        }
                    }
                    break;
                IL_136a:
                    FlxInv.SetData(iiCnt, 7, double.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 7).ToString() ?? "")) + vQty);
                    ItmDis = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 9)))) / 100.0);
                    ItmAddTax = Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    if (!switchButton_TaxLines.Value || switchButton_TaxByTotal.Value)
                    {
                        ItmAddTax = 0.0;
                    }
                    if (FlxInv.RowSel > 0)
                    {
                        if (FlxInv.Rows[FlxInv.Row].Height > 33)
                        {
                            FlxInv.RemoveItem(FlxInv.Row);
                            FlxInv.RemoveItem(FlxInv.Row);
                        }
                        else
                        {
                            FlxInv.RemoveItem(FlxInv.Row - 1);
                            FlxInv.RemoveItem(FlxInv.Row);
                        }
                        FlxInv.SetData(iiCnt, 12, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 11)))));
                        FlxInv.SetData(iiCnt, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) - ItmDis + ItmAddTax);
                        if (switchButton_TaxByTotal.Value && switchButton_TaxLines.Value && double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31)))) > 0.0)
                        {
                            ItmAddTax = Math.Round((double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) - ItmDis) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))) / 100.0), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                            FlxInv.SetData(iiCnt, 31, double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31)))) + ItmAddTax);
                        }
                        GetInvTot();
                        FlxInv.Row = FlxInv.RowSel;
                        FlxInv.Col = 0;
                    }
                    return true;
                }
            }
            return false;
        }
        private void BindDataofItemPrice()
        {
            if (CmbInvPrice.SelectedIndex == 1 && _Items.Price1.HasValue)
            {
                FlxInv.SetData(FlxInv.Row, 8, _Items.Price1.Value / _Items.DefPack.Value * Pack / RateValue);
            }
            else if (CmbInvPrice.SelectedIndex == 2 && _Items.Price2.HasValue)
            {
                FlxInv.SetData(FlxInv.Row, 8, _Items.Price2.Value / _Items.DefPack.Value * Pack / RateValue);
            }
            else if (CmbInvPrice.SelectedIndex == 3 && _Items.Price3.HasValue)
            {
                FlxInv.SetData(FlxInv.Row, 8, _Items.Price3.Value / _Items.DefPack.Value * Pack / RateValue);
            }
            else if (CmbInvPrice.SelectedIndex == 4 && _Items.Price4.HasValue)
            {
                FlxInv.SetData(FlxInv.Row, 8, _Items.Price4.Value / _Items.DefPack.Value * Pack / RateValue);
            }
            else if (CmbInvPrice.SelectedIndex == 5 && _Items.Price5.HasValue)
            {
                FlxInv.SetData(FlxInv.Row, 8, _Items.Price5.Value / _Items.DefPack.Value * Pack / RateValue);
            }
            try
            {
                if (string.IsNullOrEmpty(txtCustNo.Text))
                {
                    return;
                }
                T_AccDef q = db.StockAccDefWithOutBalance(txtCustNo.Text);
                if (q != null && !string.IsNullOrEmpty(q.AccDef_No) && q.Price > 0)
                {
                    if (q.Price == 1 && _Items.Price1.HasValue)
                    {
                        FlxInv.SetData(FlxInv.Row, 8, _Items.Price1.Value / _Items.DefPack.Value * Pack / RateValue);
                    }
                    else if (q.Price == 2 && _Items.Price2.HasValue)
                    {
                        FlxInv.SetData(FlxInv.Row, 8, _Items.Price2.Value / _Items.DefPack.Value * Pack / RateValue);
                    }
                    else if (q.Price == 3 && _Items.Price3.HasValue)
                    {
                        FlxInv.SetData(FlxInv.Row, 8, _Items.Price3.Value / _Items.DefPack.Value * Pack / RateValue);
                    }
                    else if (q.Price == 4 && _Items.Price4.HasValue)
                    {
                        FlxInv.SetData(FlxInv.Row, 8, _Items.Price4.Value / _Items.DefPack.Value * Pack / RateValue);
                    }
                    else if (q.Price == 5 && _Items.Price5.HasValue)
                    {
                        FlxInv.SetData(FlxInv.Row, 8, _Items.Price5.Value / _Items.DefPack.Value * Pack / RateValue);
                    }
                }
            }
            catch
            {
            }
        }
        private void FlxDat_DoubleClick(object sender, EventArgs e)
        {
            if (FlxDat.MouseRow > 0)
            {
                FlxInv.SetData(FlxInv.Row, 27, FlxDat.GetData(FlxDat.Row, 0));
                FlxInv.SetData(FlxInv.Row, 24, FlxDat.GetData(FlxDat.Row, 1));
                FlxInv.SetData(FlxInv.Row, 35, FlxDat.GetData(FlxDat.Row, 2));
                FlxDat.Visible = false;
                FlxInv.Col = 6;
                FlxInv.Focus();
            }
        }
        private void FlxDat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && FlxDat.Row > 0)
            {
                FlxInv.SetData(FlxInv.Row, 27, FlxDat.GetData(FlxDat.Row, 0));
                FlxInv.SetData(FlxInv.Row, 24, FlxDat.GetData(FlxDat.Row, 1));
                FlxInv.SetData(FlxInv.Row, 35, FlxDat.GetData(FlxDat.Row, 2));
                FlxDat.Visible = false;
                FlxInv.Col = 6;
                FlxInv.Focus();
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
        public void Button_Print_Click(object sender, EventArgs e)
        {
            if (ViewState == ViewState.Table)
            {
                VarGeneral.InvType = 21;
                FRInvoice form1 = new FRInvoice(VarGeneral.InvTyp, LangArEn);
                form1.Tag = LangArEn.ToString();
                form1.StartPosition = FormStartPosition.CenterScreen;
                form1.TopMost = true;
                form1.ShowDialog();
            }
        }
        private void GetInvTot()
        {
            double InvTot = 0.0;
            double InvCost = 0.0;
            double InvQty = 0.0;
            double InvDis = 0.0;
            double InvTax = 0.0;
            double ItmDisCount = 0.0;
            if (State != 0)
            {
                InvDis = double.Parse(VarGeneral.TString.TEmpty(txtDiscountVal.Text));
                for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
                {
                    try
                    {
                        if (FlxInv.Rows[iiCnt].Height <= 33)
                        {
                            continue;
                        }
                        InvTot += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 31))));
                        InvCost += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 10)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 12))));
                        InvQty += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7))));
                        if (switchButton_TaxByTotal.Value)
                        {
                            double DisVal = 0.0;
                            try
                            {
                                DisVal = double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 9)))) / 100.0);
                            }
                            catch
                            {
                            }
                            InvTax += (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) - DisVal) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))) / 100.0);
                        }
                        else
                        {
                            InvTax += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 38)))) / 100.0);
                        }
                        ItmDisCount += double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 7)))) * double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 9)))) / 100.0);
                    }
                    catch
                    {
                    }
                }
                txtTotalAm.Text = VarGeneral.TString.TEmpty(Math.Round(InvTot * RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
                txtDueAmount.Text = VarGeneral.TString.TEmpty(Math.Round((InvTot - InvDis) * RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
                txtTotalQ.Text = VarGeneral.TString.TEmpty(InvQty.ToString());
                txtInvCost.Text = VarGeneral.TString.TEmpty(Math.Round(InvCost, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
                txtCustNet.Text = VarGeneral.TString.TEmpty(Math.Round(double.Parse(VarGeneral.TString.TEmpty(string.Concat(txtCustRep.Value))) + double.Parse(txtDueAmountLoc.Text), VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
                txtTotalAmLoc.Text = VarGeneral.TString.TEmpty(Math.Round(InvTot, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
                txtDueAmountLoc.Text = VarGeneral.TString.TEmpty(Math.Round(InvTot - InvDis, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
                double Tax_Per = 0.0;
                try
                {
                    Tax_Per = double.Parse(textBoxItem_TaxByNetValue.Text);
                }
                catch
                {
                    Tax_Per = 0.0;
                }
                if (switchButton_TaxByNet.Value)
                {
                    InvTax = ((!(Tax_Per <= 0.0) && !(txtDueAmountLoc.Value <= 0.0)) ? Math.Round(txtDueAmountLoc.Value * Tax_Per / 100.0, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) : 0.0);
                }
                txtTotTax.Text = VarGeneral.TString.TEmpty(Math.Round(InvTax, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
                txtTotTaxLoc.Text = VarGeneral.TString.TEmpty(Math.Round(InvTax * RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
                if (switchButton_TaxLines.Value)
                {
                    if (!switchButton_Tax.Value)
                    {
                        txtDueAmount.Text = VarGeneral.TString.TEmpty(Math.Round((InvTot - InvTax - InvDis) * RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
                    }
                    if (!switchButton_Tax.Value)
                    {
                        txtDueAmountLoc.Text = VarGeneral.TString.TEmpty(Math.Round(InvTot - InvTax - InvDis, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
                    }
                    if (switchButton_TaxByNet.Value && InvTax > 0.0)
                    {
                        if (switchButton_Tax.Value)
                        {
                            txtDueAmount.Text = VarGeneral.TString.TEmpty(Math.Round((InvTot + InvTax - InvDis) * RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
                        }
                        if (switchButton_Tax.Value)
                        {
                            txtDueAmountLoc.Text = VarGeneral.TString.TEmpty(Math.Round(InvTot + InvTax - InvDis, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
                        }
                    }
                }
                else
                {
                    if (switchButton_Tax.Value)
                    {
                        txtDueAmount.Text = VarGeneral.TString.TEmpty(Math.Round((InvTot + InvTax - InvDis) * RateValue, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
                    }
                    if (switchButton_Tax.Value)
                    {
                        txtDueAmountLoc.Text = VarGeneral.TString.TEmpty(Math.Round(InvTot + InvTax - InvDis, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2).ToString());
                    }
                }
                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 56))
                {
                    txtTotalAm.Value = Math.Round(txtTotalAm.Value, 0);
                    txtDueAmount.Value = Math.Round(txtDueAmount.Value, 0);
                    txtTotalAmLoc.Value = Math.Round(txtTotalAmLoc.Value, 0);
                    txtDueAmountLoc.Value = Math.Round(txtDueAmountLoc.Value, 0);
                }
                try
                {
                    if (checkBox_CostGaidTax.Checked && txtPaymentLoc.Value + doubleInput_NetWorkLoc.Value + doubleInput_CreditLoc.Value != txtDueAmountLoc.Value - txtTotTax.Value)
                    {
                        txtDueAmountLoc_ValueChanged(null, null);
                    }
                }
                catch
                {
                }
            }
            if (FlxInv.Rows.Count <= 1)
            {
                button_DeleteLine.Visible = false;
            }
        }
        private void CmbCurr_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CmbCurr.SelectedIndex == -1)
                {
                    return;
                }
                _Curency = db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString()));
                try
                {
                    if (CmbCurr.SelectedValue.ToString() == VarGeneral.Settings_Sys.ImportIp.ToString())
                    {
                        RateValue = 1.0;
                        doubleInput_Rate.Value = 1.0;
                    }
                    else
                    {
                        RateValue = _Curency.Rate.Value;
                        try
                        {
                            doubleInput_Rate.Value = _Curency.Rate.Value;
                        }
                        catch
                        {
                        }
                    }
                }
                catch
                {
                    RateValue = _Curency.Rate.Value;
                    try
                    {
                        doubleInput_Rate.Value = _Curency.Rate.Value;
                    }
                    catch
                    {
                    }
                }
                try
                {
                    GetInvTot();
                    txtDiscountVal_Leave(sender, e);
                }
                catch
                {
                }
            }
            catch
            {
            }
        }
        private void txtDiscountP_Leave(object sender, EventArgs e)
        {
            if (State != 0)
            {
                txtDiscountVal.Value = txtTotalAmLoc.Value * (txtDiscountP.Value / 100.0);
                txtDiscountValLoc.Value = txtDiscountVal.Value * RateValue;
                GetInvTot();
            }
        }
        private void txtDiscountVal_Leave(object sender, EventArgs e)
        {
            if (State == FormState.Saved)
            {
                return;
            }
            try
            {
                if (txtTotalAm.Value > 0.0)
                {
                    txtDiscountP.Value = Math.Round(txtDiscountVal.Value / txtTotalAmLoc.Value * 100.0, VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                }
            }
            catch
            {
            }
            txtDiscountValLoc.Value = txtDiscountVal.Value * RateValue;
            GetInvTot();
        }
        private void txtDueAmountLoc_ValueChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                if (checkBox_Chash.Checked)
                {
                    txtPaymentLoc.Value = (checkBox_CostGaidTax.Checked ? (txtDueAmountLoc.Value - txtTotTax.Value) : txtDueAmountLoc.Value);
                    doubleInput_CreditLoc.Value = 0.0;
                    doubleInput_NetWorkLoc.Value = 0.0;
                }
                else
                {
                    doubleInput_CreditLoc.Value = (checkBox_CostGaidTax.Checked ? (txtDueAmountLoc.Value - txtTotTax.Value) : txtDueAmountLoc.Value);
                    txtPaymentLoc.Value = 0.0;
                    doubleInput_NetWorkLoc.Value = 0.0;
                }
            }
        }
        private void txtRemark_ButtonCustomClick(object sender, EventArgs e)
        {
            ControlNo = 3;
            CheckSts(ControlNo);
        }
        private void checkBoxItem_BarCode_CheckedChanged(object sender, CheckBoxChangeEventArgs e)
        {
            try
            {
                if (checkBoxItem_BarCode.Checked)
                {
                    superTabControl_Main2.Enabled = false;
                    Button_Search.Enabled = false;
                    Button_Delete.Enabled = false;
                    buttonItem_Print.Enabled = false;
                    expandableSplitter1.Expandable = false;
                    Button_Add_Click(sender, e);
                    return;
                }
                superTabControl_Main2.Enabled = true;
                Button_Search.Enabled = true;
                Button_Add.Enabled = true;
                Button_Delete.Enabled = true;
                buttonItem_Print.Enabled = true;
                expandableSplitter1.Expandable = true;
                State = FormState.Saved;
                dbInstance = null;
                if (pkeys.Count == 1)
                {
                    Button_First_Click(sender, e);
                }
                else
                {
                    textBox_ID_TextChanged(sender, e);
                }
                SetReadOnly = true;
                if (State != FormState.New)
                {
                    button_AddToTable.Visible = false;
                }
            }
            catch
            {
            }
        }
        private void txtCustNo_TextChanged(object sender, EventArgs e)
        {
            if (txtCustNo.Text != "")
            {
                txtCustName.ReadOnly = true;
                txtTele.ReadOnly = true;
                txtAddress.ReadOnly = true;
            }
            else
            {
                txtCustName.ReadOnly = false;
                txtTele.ReadOnly = false;
                txtAddress.ReadOnly = false;
            }
        }
        private void doubleInput_NetWorkLoc_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!(doubleInput_NetWorkLoc.Value > 0.0))
                {
                    return;
                }
                if (txtPaymentLoc.Value > 0.0 || doubleInput_CreditLoc.Value > 0.0)
                {
                    if (!(txtPaymentLoc.Value > 0.0) || !(doubleInput_CreditLoc.Value > 0.0))
                    {
                        if (txtPaymentLoc.Value > 0.0)
                        {
                            txtPaymentLoc.Value = (checkBox_CostGaidTax.Checked ? (txtDueAmountLoc.Value - txtTotTax.Value) : txtDueAmountLoc.Value) - doubleInput_NetWorkLoc.Value;
                        }
                        else
                        {
                            doubleInput_CreditLoc.Value = (checkBox_CostGaidTax.Checked ? (txtDueAmountLoc.Value - txtTotTax.Value) : txtDueAmountLoc.Value) - doubleInput_NetWorkLoc.Value;
                        }
                    }
                }
                else
                {
                    txtPaymentLoc.Value = (checkBox_CostGaidTax.Checked ? (txtDueAmountLoc.Value - txtTotTax.Value) : txtDueAmountLoc.Value) - doubleInput_NetWorkLoc.Value;
                }
            }
            catch
            {
                doubleInput_NetWorkLoc.Value = 0.0;
                doubleInput_NetWorkLoc.Leave -= doubleInput_NetWorkLoc_Leave;
            }
        }
        private void txtPaymentLoc_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!(txtPaymentLoc.Value > 0.0))
                {
                    return;
                }
                if (doubleInput_CreditLoc.Value > 0.0 || doubleInput_NetWorkLoc.Value > 0.0)
                {
                    if (!(doubleInput_CreditLoc.Value > 0.0) || !(doubleInput_NetWorkLoc.Value > 0.0))
                    {
                        if (doubleInput_CreditLoc.Value > 0.0)
                        {
                            doubleInput_CreditLoc.Value = (checkBox_CostGaidTax.Checked ? (txtDueAmountLoc.Value - txtTotTax.Value) : txtDueAmountLoc.Value) - txtPaymentLoc.Value;
                        }
                        else
                        {
                            doubleInput_NetWorkLoc.Value = (checkBox_CostGaidTax.Checked ? (txtDueAmountLoc.Value - txtTotTax.Value) : txtDueAmountLoc.Value) - txtPaymentLoc.Value;
                        }
                    }
                }
                else
                {
                    doubleInput_NetWorkLoc.Value = (checkBox_CostGaidTax.Checked ? (txtDueAmountLoc.Value - txtTotTax.Value) : txtDueAmountLoc.Value) - txtPaymentLoc.Value;
                }
            }
            catch
            {
                txtPaymentLoc.Value = 0.0;
                txtPaymentLoc.Leave -= txtPaymentLoc_Leave;
            }
        }
        private void doubleInput_CreditLoc_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!(doubleInput_CreditLoc.Value > 0.0))
                {
                    return;
                }
                if (txtPaymentLoc.Value > 0.0 || doubleInput_NetWorkLoc.Value > 0.0)
                {
                    if (!(txtPaymentLoc.Value > 0.0) || !(doubleInput_NetWorkLoc.Value > 0.0))
                    {
                        if (txtPaymentLoc.Value > 0.0)
                        {
                            txtPaymentLoc.Value = (checkBox_CostGaidTax.Checked ? (txtDueAmountLoc.Value - txtTotTax.Value) : txtDueAmountLoc.Value) - doubleInput_CreditLoc.Value;
                        }
                        else
                        {
                            doubleInput_NetWorkLoc.Value = (checkBox_CostGaidTax.Checked ? (txtDueAmountLoc.Value - txtTotTax.Value) : txtDueAmountLoc.Value) - doubleInput_CreditLoc.Value;
                        }
                    }
                }
                else
                {
                    txtPaymentLoc.Value = (checkBox_CostGaidTax.Checked ? (txtDueAmountLoc.Value - txtTotTax.Value) : txtDueAmountLoc.Value) - doubleInput_CreditLoc.Value;
                }
            }
            catch
            {
                doubleInput_CreditLoc.Value = 0.0;
                doubleInput_CreditLoc.Leave -= doubleInput_CreditLoc_Leave;
            }
        }
        private void FrmWaiterMenue_SizeChanged(object sender, EventArgs e)
        {
            FillCat();
            if (base.WindowState == FormWindowState.Normal)
            {
                btnPrevPage.Text = "";
                btnNxtPage.Text = "";
                buttonItem_BestSeller.Text = "";
            }
            else if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                btnPrevPage.Text = "سابق";
                btnNxtPage.Text = "تالي";
                buttonItem_BestSeller.Text = "أكثر مبيعا\u064c";
            }
            else
            {
                btnPrevPage.Text = "Prev";
                btnNxtPage.Text = "Next";
                buttonItem_BestSeller.Text = "Best Seller";
            }
        }
        private void metroTilePanel_Cat_ItemClick(object sender, EventArgs e)
        {
            try
            {
                MetroTileItem q = sender as MetroTileItem;
                if (string.IsNullOrEmpty(q.Tag.ToString()))
                {
                    ItmMainParameter = "";
                    return;
                }
                ItmMainParameter = q.Tag.ToString();
                FillItmesMain(q, vBestSaller: false);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("metroTilePanel_Cat_ItemClick:", error, enable: true);
                Refresh();
            }
        }
        private void FillItmesMain(MetroTileItem vSender, bool vBestSaller)
        {
            List<T_Item> vItemsMain = new List<T_Item>();
            Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
            vItemsMain = (from t in dbc.T_Items
                          where t.ItmTyp != (int?)1 && !t.InvSaleStoped.Value
                          orderby t.Itm_ID
                          select t).ToList();
            if (vSender != null)
            {
                vSender.Checked = true;
                if (int.Parse(vSender.Tag.ToString()) != 0)
                {
                    vItemsMain = (from t in dbc.T_Items
                                  where t.ItmCat == (int?)int.Parse(vSender.Tag.ToString())
                                  where t.ItmTyp != (int?)1 && !t.InvSaleStoped.Value
                                  orderby t.Itm_ID
                                  select t).ToList();
                }
            }
            if (vBestSaller)
            {
                vItemsMain = db.ExecuteQuery<T_Item>("SELECT        T_Items.Itm_ID, T_Items.Itm_No, T_Items.ItmCat, T_Items.Arb_Des, T_Items.Eng_Des, T_Items.StartCost, T_Items.AvrageCost, T_Items.LastCost, T_Items.Price1, \r\n                                                                                  T_Items.Price3, T_Items.Price2, T_Items.Price5, T_Items.Price4, T_Items.Price6, T_Items.Unit1, T_Items.Pack1, T_Items.Unit2, T_Items.UntPri2, T_Items.UntPri1, \r\n                                                                                  T_Items.Pack2, T_Items.Unit3, T_Items.Pack3, T_Items.Unit4, T_Items.UntPri3, T_Items.UntPri4, T_Items.Pack4, T_Items.Unit5, T_Items.UntPri5, T_Items.Pack5, \r\n                                                                                  T_Items.DefultUnit, T_Items.DefultVendor, T_Items.OpenQty, T_Items.QtyLvl, T_Items.ItmLoc, T_Items.BarCod1, T_Items.BarCod2, T_Items.BarCod3, \r\n                                                                                  T_Items.BarCod4, T_Items.BarCod5, T_Items.Lot, T_Items.LrnExp, T_Items.DMY, T_Items.ItmTyp, T_Items.DefPack, T_Items.ItmImg, \r\n                                                                                  T_Items.InvSaleStoped, T_Items.InvPaymentStoped, T_Items.InvPaymentReturnStoped, T_Items.FirstCost, T_Items.CompanyID, T_Items.InvSaleReturnStoped, \r\n                                                                                  T_Items.SerialKey,sum(RealQty) as QtyMax\r\n                                                            FROM         T_Items INNER JOIN\r\n                                                                                  T_INVDET ON T_Items.Itm_No = T_INVDET.ItmNo INNER JOIN\r\n                                                                                  T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID  \r\n                                                            WHERE T_INVHED.InvTyp = 21  and T_Items.ItmTyp != 1 and T_Items.InvSaleStoped = 0\r\n                                                            Group By T_Items.Itm_ID, T_Items.Itm_No, T_Items.ItmCat, T_Items.Arb_Des, T_Items.Eng_Des, T_Items.StartCost, T_Items.AvrageCost, T_Items.LastCost, T_Items.Price1, \r\n                                                                                  T_Items.Price3, T_Items.Price2, T_Items.Price5, T_Items.Price4, T_Items.Price6, T_Items.Unit1, T_Items.Pack1, T_Items.Unit2, T_Items.UntPri2, T_Items.UntPri1, \r\n                                                                                  T_Items.Pack2, T_Items.Unit3, T_Items.Pack3, T_Items.Unit4, T_Items.UntPri3, T_Items.UntPri4, T_Items.Pack4, T_Items.Unit5, T_Items.UntPri5, T_Items.Pack5, \r\n                                                                                  T_Items.DefultUnit, T_Items.DefultVendor, T_Items.OpenQty, T_Items.QtyLvl, T_Items.ItmLoc, T_Items.BarCod1, T_Items.BarCod2, T_Items.BarCod3, \r\n                                                                                  T_Items.BarCod4, T_Items.BarCod5, T_Items.Lot, T_Items.QtyMax, T_Items.LrnExp, T_Items.DMY, T_Items.ItmTyp, T_Items.DefPack, T_Items.ItmImg, \r\n                                                                                  T_Items.InvSaleStoped, T_Items.InvPaymentStoped, T_Items.InvPaymentReturnStoped, T_Items.FirstCost, T_Items.CompanyID, T_Items.InvSaleReturnStoped, \r\n                                                                                  T_Items.SerialKey\r\n                                                                                  order by QtyMax desc", new object[0]).ToList();
            }
            if (vItemsMain.Count <= 0)
            {
                ClearItemsMain();
                return;
            }
            CurrentPageIndex = 1;
            CurrentPageIndexItmDet = 1;
            CalculateTotalPages(vItemsMain);
            GetCurrentRecords(1, vBestSaller);
        }
        private void CalculateTotalPages(List<T_Item> vItemsMain)
        {
            try
            {
                int rowCount = vItemsMain.ToList().Count;
                TotalPage = rowCount / PageSize;
                if (rowCount % PageSize > 0)
                {
                    TotalPage++;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("CalculateTotalPages:", error, enable: true);
                if (TotalPage <= 0)
                {
                    TotalPage = 1;
                }
            }
        }
        private void GetCurrentRecords(int page, bool vBestSaller)
        {
            try
            {
                List<T_Item> dt = new List<T_Item>();
                if (!vBestSaller)
                {
                    if (page == 1)
                    {
                        dt = db.ExecuteQuery<T_Item>("Select TOP " + PageSize + " * from T_Items " + ((!string.IsNullOrEmpty(ItmMainParameter) && ItmMainParameter != "0") ? (" where ItmCat = " + ItmMainParameter + " and ") : " where ") + " T_Items.ItmTyp != 1 and T_Items.InvSaleStoped = 0 ORDER BY Itm_ID", new object[0]).ToList();
                    }
                    else
                    {
                        int PreviouspageLimit = (page - 1) * PageSize;
                        dt = db.ExecuteQuery<T_Item>("Select TOP " + PageSize + " * from T_Items WHERE " + ((!string.IsNullOrEmpty(ItmMainParameter) && ItmMainParameter != "0") ? (" ItmCat = " + ItmMainParameter + " AND ") : " ") + " Itm_ID NOT IN (Select TOP " + PreviouspageLimit + " Itm_ID from T_Items WHERE " + ((!string.IsNullOrEmpty(ItmMainParameter) && ItmMainParameter != "0") ? (" ItmCat = " + ItmMainParameter) : " 1 = 1 ") + "ORDER BY Itm_ID) and T_Items.ItmTyp != 1 and T_Items.InvSaleStoped = 0 ORDER BY Itm_ID", new object[0]).ToList();
                    }
                }
                else if (page == 1)
                {
                    dt = db.ExecuteQuery<T_Item>("SELECT   TOP " + PageSize + "  T_Items.Itm_ID, T_Items.Itm_No, T_Items.ItmCat, T_Items.Arb_Des, T_Items.Eng_Des, T_Items.StartCost, T_Items.AvrageCost, T_Items.LastCost, T_Items.Price1, \r\n                                                                                  T_Items.Price3, T_Items.Price2, T_Items.Price5, T_Items.Price4, T_Items.Price6, T_Items.Unit1, T_Items.Pack1, T_Items.Unit2, T_Items.UntPri2, T_Items.UntPri1, \r\n                                                                                  T_Items.Pack2, T_Items.Unit3, T_Items.Pack3, T_Items.Unit4, T_Items.UntPri3, T_Items.UntPri4, T_Items.Pack4, T_Items.Unit5, T_Items.UntPri5, T_Items.Pack5, \r\n                                                                                  T_Items.DefultUnit, T_Items.DefultVendor, T_Items.OpenQty, T_Items.QtyLvl, T_Items.ItmLoc, T_Items.BarCod1, T_Items.BarCod2, T_Items.BarCod3, \r\n                                                                                  T_Items.BarCod4, T_Items.BarCod5, T_Items.Lot, T_Items.LrnExp, T_Items.DMY, T_Items.ItmTyp, T_Items.DefPack, T_Items.ItmImg, \r\n                                                                                  T_Items.InvSaleStoped, T_Items.InvPaymentStoped, T_Items.InvPaymentReturnStoped, T_Items.FirstCost, T_Items.CompanyID, T_Items.InvSaleReturnStoped, \r\n                                                                                  T_Items.SerialKey,sum(RealQty) as QtyMax\r\n                                                            FROM         T_Items INNER JOIN\r\n                                                                                  T_INVDET ON T_Items.Itm_No = T_INVDET.ItmNo INNER JOIN\r\n                                                                                  T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID\r\n                                                            WHERE T_INVHED.InvTyp = 21 and T_Items.ItmTyp != 1 and T_Items.InvSaleStoped = 0\r\n                                                            Group By T_Items.Itm_ID, T_Items.Itm_No, T_Items.ItmCat, T_Items.Arb_Des, T_Items.Eng_Des, T_Items.StartCost, T_Items.AvrageCost, T_Items.LastCost, T_Items.Price1, \r\n                                                                                  T_Items.Price3, T_Items.Price2, T_Items.Price5, T_Items.Price4, T_Items.Price6, T_Items.Unit1, T_Items.Pack1, T_Items.Unit2, T_Items.UntPri2, T_Items.UntPri1, \r\n                                                                                  T_Items.Pack2, T_Items.Unit3, T_Items.Pack3, T_Items.Unit4, T_Items.UntPri3, T_Items.UntPri4, T_Items.Pack4, T_Items.Unit5, T_Items.UntPri5, T_Items.Pack5, \r\n                                                                                  T_Items.DefultUnit, T_Items.DefultVendor, T_Items.OpenQty, T_Items.QtyLvl, T_Items.ItmLoc, T_Items.BarCod1, T_Items.BarCod2, T_Items.BarCod3, \r\n                                                                                  T_Items.BarCod4, T_Items.BarCod5, T_Items.Lot, T_Items.QtyMax, T_Items.LrnExp, T_Items.DMY, T_Items.ItmTyp, T_Items.DefPack, T_Items.ItmImg, \r\n                                                                                  T_Items.InvSaleStoped, T_Items.InvPaymentStoped, T_Items.InvPaymentReturnStoped, T_Items.FirstCost, T_Items.CompanyID, T_Items.InvSaleReturnStoped, \r\n                                                                                  T_Items.SerialKey\r\n                                                                                  order by QtyMax desc", new object[0]).ToList();
                }
                else
                {
                    int PreviouspageLimit = (page - 1) * PageSize;
                    dt = db.ExecuteQuery<T_Item>("SELECT   TOP " + PageSize + "  T_Items.Itm_ID, T_Items.Itm_No, T_Items.ItmCat, T_Items.Arb_Des, T_Items.Eng_Des, T_Items.StartCost, T_Items.AvrageCost, T_Items.LastCost, T_Items.Price1, \r\n                                                                                  T_Items.Price3, T_Items.Price2, T_Items.Price5, T_Items.Price4, T_Items.Price6, T_Items.Unit1, T_Items.Pack1, T_Items.Unit2, T_Items.UntPri2, T_Items.UntPri1, \r\n                                                                                  T_Items.Pack2, T_Items.Unit3, T_Items.Pack3, T_Items.Unit4, T_Items.UntPri3, T_Items.UntPri4, T_Items.Pack4, T_Items.Unit5, T_Items.UntPri5, T_Items.Pack5, \r\n                                                                                  T_Items.DefultUnit, T_Items.DefultVendor, T_Items.OpenQty, T_Items.QtyLvl, T_Items.ItmLoc, T_Items.BarCod1, T_Items.BarCod2, T_Items.BarCod3, \r\n                                                                                  T_Items.BarCod4, T_Items.BarCod5, T_Items.Lot, T_Items.LrnExp, T_Items.DMY, T_Items.ItmTyp, T_Items.DefPack, T_Items.ItmImg, \r\n                                                                                  T_Items.InvSaleStoped, T_Items.InvPaymentStoped, T_Items.InvPaymentReturnStoped, T_Items.FirstCost, T_Items.CompanyID, T_Items.InvSaleReturnStoped, \r\n                                                                                  T_Items.SerialKey,sum(RealQty) as QtyMax\r\n                                                            FROM         T_Items INNER JOIN\r\n                                                                                  T_INVDET ON T_Items.Itm_No = T_INVDET.ItmNo INNER JOIN\r\n                                                                                  T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID\r\n                                                            WHERE T_INVHED.InvTyp = 21 and T_Items.ItmTyp != 1 and T_Items.InvSaleStoped = 0 AND  Itm_No NOT IN (Select TOP " + PreviouspageLimit + " Itm_ID from T_Items ORDER BY Itm_ID)\r\n                                                            Group By T_Items.Itm_ID, T_Items.Itm_No, T_Items.ItmCat, T_Items.Arb_Des, T_Items.Eng_Des, T_Items.StartCost, T_Items.AvrageCost, T_Items.LastCost, T_Items.Price1, \r\n                                                                                  T_Items.Price3, T_Items.Price2, T_Items.Price5, T_Items.Price4, T_Items.Price6, T_Items.Unit1, T_Items.Pack1, T_Items.Unit2, T_Items.UntPri2, T_Items.UntPri1, \r\n                                                                                  T_Items.Pack2, T_Items.Unit3, T_Items.Pack3, T_Items.Unit4, T_Items.UntPri3, T_Items.UntPri4, T_Items.Pack4, T_Items.Unit5, T_Items.UntPri5, T_Items.Pack5, \r\n                                                                                  T_Items.DefultUnit, T_Items.DefultVendor, T_Items.OpenQty, T_Items.QtyLvl, T_Items.ItmLoc, T_Items.BarCod1, T_Items.BarCod2, T_Items.BarCod3, \r\n                                                                                  T_Items.BarCod4, T_Items.BarCod5, T_Items.Lot, T_Items.QtyMax, T_Items.LrnExp, T_Items.DMY, T_Items.ItmTyp, T_Items.DefPack, T_Items.ItmImg, \r\n                                                                                  T_Items.InvSaleStoped, T_Items.InvPaymentStoped, T_Items.InvPaymentReturnStoped, T_Items.FirstCost, T_Items.CompanyID, T_Items.InvSaleReturnStoped, \r\n                                                                                  T_Items.SerialKey\r\n                                                                                  order by QtyMax desc", new object[0]).ToList();
                }
                int iicnt = 0;
                Size newSize = default(Size);
                try
                {
                    newSize = new Size(colW, rowH / 2 + rowH * 25 / 100);
                }
                catch
                {
                    newSize = new Size(130, 110);
                }
                foreach (GridRow rowCell in superGridControl1.PrimaryGrid.Rows)
                {
                    foreach (GridCell cell in rowCell.Cells)
                    {
                        if (iicnt < dt.Count)
                        {
                            try
                            {
                                if (rowCell.RowHeight <= rowH / 4)
                                {
                                    cell.CellStyles.Default.AllowWrap = Tbool.True;
                                    cell.Value = ((LangArEn == 0) ? dt[iicnt].Arb_Des : dt[iicnt].Eng_Des);
                                    cell.Tag = dt[iicnt].Itm_No;
                                    iicnt++;
                                }
                            }
                            catch
                            {
                                iicnt++;
                            }
                        }
                        else
                        {
                            cell.Value = "";
                        }
                    }
                }
                if (VarGeneral.Settings_Sys.Path_Kind < 2)
                {
                    iicnt = 0;
                    foreach (GridRow rowCell in superGridControl1.PrimaryGrid.Rows)
                    {
                        foreach (GridCell cell in rowCell.Cells)
                        {
                            if (iicnt >= dt.Count)
                            {
                                continue;
                            }
                            try
                            {
                                if (rowCell.RowHeight <= rowH / 4)
                                {
                                    continue;
                                }
                                cell.Tag = dt[iicnt].Itm_No;
                                if (VarGeneral.Settings_Sys.Path_Kind == 1)
                                {
                                    if (dt[iicnt].ItmImg != null)
                                    {
                                        byte[] arr = dt[iicnt].ItmImg.ToArray();
                                        MemoryStream stream = new MemoryStream(arr);
                                        cell.CellStyles.Default.Image = new Bitmap(Image.FromStream(stream), newSize);
                                    }
                                    else
                                    {
                                        cell.CellStyles.Default.Image = null;
                                    }
                                    try
                                    {
                                        cell.Tag = dt[iicnt].Itm_No;
                                        cell.Value = ".";
                                    }
                                    catch
                                    {
                                    }
                                }
                                else
                                {
                                    string[] filters = new string[7]
                                    {
                                        "jpg",
                                        "jpeg",
                                        "png",
                                        "gif",
                                        "tiff",
                                        "bmp",
                                        "gif"
                                    };
                                    string[] filePaths = GetFilesFrom(Application.StartupPath + "\\POS_IMG", filters, isRecursive: false);
                                    if (filePaths.Count() > 0)
                                    {
                                        Random rnd = new Random();
                                        string mypic_path = filePaths[rnd.Next(0, filePaths.Count() - 1)];
                                        if (File.Exists(mypic_path))
                                        {
                                            Image original = Image.FromFile(mypic_path);
                                            Image resized = ResizeImage(original, new Size(80, 80), preserveAspectRatio: false);
                                            cell.CellStyles.Default.Image = resized;
                                        }
                                    }
                                    try
                                    {
                                        cell.Tag = dt[iicnt].Itm_No;
                                        cell.Value = ".";
                                    }
                                    catch
                                    {
                                    }
                                }
                                cell.CellStyles.Default.ImageAlignment = Alignment.MiddleCenter;
                                iicnt++;
                            }
                            catch
                            {
                                iicnt++;
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            superGridControl1.Refresh();
            Refresh();
        }
        public static Image ResizeImage(Image image, Size size, bool preserveAspectRatio)
        {
            int newWidth;
            int newHeight;
            if (preserveAspectRatio)
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                float percentWidth = (float)size.Width / (float)originalWidth;
                float percentHeight = (float)size.Height / (float)originalHeight;
                float percent = ((percentHeight < percentWidth) ? percentHeight : percentWidth);
                newWidth = (int)((float)originalWidth * percent);
                newHeight = (int)((float)originalHeight * percent);
            }
            else
            {
                newWidth = size.Width;
                newHeight = size.Height;
            }
            Image newImage = new Bitmap(newWidth, newHeight);
            using (Graphics graphicsHandle = Graphics.FromImage(newImage))
            {
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
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
        private void btnFirstPAge_Click(object sender, EventArgs e)
        {
            CurrentPageIndex = 1;
            GetCurrentRecords(CurrentPageIndex, vBestSaller: false);
        }
        private void btnNxtPage_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndex < TotalPage)
            {
                CurrentPageIndex++;
                GetCurrentRecords(CurrentPageIndex, vBestSaller: false);
            }
        }
        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndex > 1)
            {
                CurrentPageIndex--;
                GetCurrentRecords(CurrentPageIndex, vBestSaller: false);
            }
        }
        private void btnLastPage_Click(object sender, EventArgs e)
        {
            CurrentPageIndex = TotalPage;
            GetCurrentRecords(CurrentPageIndex, vBestSaller: false);
        }
        private void ClearItemsMain()
        {
            foreach (GridRow rowCell in superGridControl1.PrimaryGrid.Rows)
            {
                foreach (GridCell cell in rowCell.Cells)
                {
                    cell.Value = "";
                    cell.Tag = "";
                    cell.CellStyles.Default.Background.Color1 = Color.AliceBlue;
                }
            }
        }
        private void button_1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 0)
                {
                    int vRowIndex = FlxInv.RowSel;
                    if (FlxInv.ColSel == 7 && vQtyGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 8 && vPriceGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 9 && vDisGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 31 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 38 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    FlxInv.SetData(FlxInv.RowSel, FlxInv.ColSel, FlxInv.GetData(FlxInv.RowSel, FlxInv.ColSel).ToString() + "1");
                    FlxInv_AfterEdit(sender, new RowColEventArgs(FlxInv.RowSel, FlxInv.ColSel));
                    vQtyGraid = false;
                    vPriceGraid = false;
                    vTotGraid = false;
                    vDisGraid = false;
                    vTax = false;
                }
                else
                {
                    if (ControlNo == 1 || ControlNo == 2)
                    {
                        return;
                    }
                    if (ControlNo == 3)
                    {
                        txtRemark.Text += "1";
                    }
                    else if (ControlNo == 4)
                    {
                        txtRef.Text += "1";
                    }
                    else if (ControlNo == 5)
                    {
                        if (txtTele.Enabled)
                        {
                            txtTele.Text += "1";
                        }
                    }
                    else if (ControlNo == 6)
                    {
                        txtDiscountVal.Text = txtDiscountVal.Text.Substring(0, txtDiscountVal.Text.Length - 3) + "1";
                        txtDiscountVal_Leave(sender, e);
                    }
                    else if (ControlNo == 7)
                    {
                        txtDiscountP.Text = txtDiscountP.Text.Substring(0, txtDiscountP.Text.Length - 3) + "1";
                        txtDiscountP_Leave(sender, e);
                    }
                    return;
                }
            }
            catch
            {
            }
        }
        private void button_2_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 0)
                {
                    int vRowIndex = FlxInv.RowSel;
                    if (FlxInv.ColSel == 7 && vQtyGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 8 && vPriceGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 9 && vDisGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 31 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 38 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    FlxInv.SetData(FlxInv.RowSel, FlxInv.ColSel, FlxInv.GetData(FlxInv.RowSel, FlxInv.ColSel).ToString() + "2");
                    FlxInv_AfterEdit(sender, new RowColEventArgs(FlxInv.RowSel, FlxInv.ColSel));
                    vQtyGraid = false;
                    vPriceGraid = false;
                    vTotGraid = false;
                    vDisGraid = false;
                    vTax = false;
                }
                else
                {
                    if (ControlNo == 1 || ControlNo == 2)
                    {
                        return;
                    }
                    if (ControlNo == 3)
                    {
                        txtRemark.Text += "2";
                    }
                    else if (ControlNo == 4)
                    {
                        txtRef.Text += "2";
                    }
                    else if (ControlNo == 5)
                    {
                        if (!txtTele.ReadOnly)
                        {
                            txtTele.Text += "2";
                        }
                    }
                    else if (ControlNo == 6)
                    {
                        txtDiscountVal.Text = txtDiscountVal.Text.Substring(0, txtDiscountVal.Text.Length - 3) + "2";
                        txtDiscountVal_Leave(sender, e);
                    }
                    else if (ControlNo == 7)
                    {
                        txtDiscountP.Text = txtDiscountP.Text.Substring(0, txtDiscountP.Text.Length - 3) + "2";
                        txtDiscountP_Leave(sender, e);
                    }
                    return;
                }
            }
            catch
            {
            }
        }
        private void button_3_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 0)
                {
                    int vRowIndex = FlxInv.RowSel;
                    if (FlxInv.ColSel == 7 && vQtyGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 8 && vPriceGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 9 && vDisGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 31 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 38 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    FlxInv.SetData(FlxInv.RowSel, FlxInv.ColSel, FlxInv.GetData(FlxInv.RowSel, FlxInv.ColSel).ToString() + "3");
                    FlxInv_AfterEdit(sender, new RowColEventArgs(FlxInv.RowSel, FlxInv.ColSel));
                    vQtyGraid = false;
                    vPriceGraid = false;
                    vTotGraid = false;
                    vDisGraid = false;
                    vTax = false;
                }
                else
                {
                    if (ControlNo == 1 || ControlNo == 2)
                    {
                        return;
                    }
                    if (ControlNo == 3)
                    {
                        txtRemark.Text += "3";
                    }
                    else if (ControlNo == 4)
                    {
                        txtRef.Text += "3";
                    }
                    else if (ControlNo == 5)
                    {
                        if (!txtTele.ReadOnly)
                        {
                            txtTele.Text += "3";
                        }
                    }
                    else if (ControlNo == 6)
                    {
                        txtDiscountVal.Text = txtDiscountVal.Text.Substring(0, txtDiscountVal.Text.Length - 3) + "3";
                        txtDiscountVal_Leave(sender, e);
                    }
                    else if (ControlNo == 7)
                    {
                        txtDiscountP.Text = txtDiscountP.Text.Substring(0, txtDiscountP.Text.Length - 3) + "3";
                        txtDiscountP_Leave(sender, e);
                    }
                    return;
                }
            }
            catch
            {
            }
        }
        private void button_4_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 0)
                {
                    int vRowIndex = FlxInv.RowSel;
                    if (FlxInv.ColSel == 7 && vQtyGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 8 && vPriceGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 9 && vDisGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 31 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 38 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    FlxInv.SetData(FlxInv.RowSel, FlxInv.ColSel, FlxInv.GetData(FlxInv.RowSel, FlxInv.ColSel).ToString() + "4");
                    FlxInv_AfterEdit(sender, new RowColEventArgs(FlxInv.RowSel, FlxInv.ColSel));
                    vQtyGraid = false;
                    vPriceGraid = false;
                    vTotGraid = false;
                    vDisGraid = false;
                    vTax = false;
                }
                else
                {
                    if (ControlNo == 1 || ControlNo == 2)
                    {
                        return;
                    }
                    if (ControlNo == 3)
                    {
                        txtRemark.Text += "4";
                    }
                    else if (ControlNo == 4)
                    {
                        txtRef.Text += "4";
                    }
                    else if (ControlNo == 5)
                    {
                        if (!txtTele.ReadOnly)
                        {
                            txtTele.Text += "4";
                        }
                    }
                    else if (ControlNo == 6)
                    {
                        txtDiscountVal.Text = txtDiscountVal.Text.Substring(0, txtDiscountVal.Text.Length - 3) + "4";
                        txtDiscountVal_Leave(sender, e);
                    }
                    else if (ControlNo == 7)
                    {
                        txtDiscountP.Text = txtDiscountP.Text.Substring(0, txtDiscountP.Text.Length - 3) + "4";
                        txtDiscountP_Leave(sender, e);
                    }
                    return;
                }
            }
            catch
            {
            }
        }
        private void button_5_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 0)
                {
                    int vRowIndex = FlxInv.RowSel;
                    if (FlxInv.ColSel == 7 && vQtyGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 8 && vPriceGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 9 && vDisGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 31 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 38 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    FlxInv.SetData(FlxInv.RowSel, FlxInv.ColSel, FlxInv.GetData(FlxInv.RowSel, FlxInv.ColSel).ToString() + "5");
                    FlxInv_AfterEdit(sender, new RowColEventArgs(FlxInv.RowSel, FlxInv.ColSel));
                    vQtyGraid = false;
                    vPriceGraid = false;
                    vTotGraid = false;
                    vDisGraid = false;
                    vTax = false;
                }
                else
                {
                    if (ControlNo == 1 || ControlNo == 2)
                    {
                        return;
                    }
                    if (ControlNo == 3)
                    {
                        txtRemark.Text += "5";
                    }
                    else if (ControlNo == 4)
                    {
                        txtRef.Text += "5";
                    }
                    else if (ControlNo == 5)
                    {
                        if (!txtTele.ReadOnly)
                        {
                            txtTele.Text += "5";
                        }
                    }
                    else if (ControlNo == 6)
                    {
                        txtDiscountVal.Text = txtDiscountVal.Text.Substring(0, txtDiscountVal.Text.Length - 3) + "5";
                        txtDiscountVal_Leave(sender, e);
                    }
                    else if (ControlNo == 7)
                    {
                        txtDiscountP.Text = txtDiscountP.Text.Substring(0, txtDiscountP.Text.Length - 3) + "5";
                        txtDiscountP_Leave(sender, e);
                    }
                    return;
                }
            }
            catch
            {
            }
        }
        private void button_6_Click(object sender, EventArgs e)
        {
            try
            {
                int vRowIndex = FlxInv.RowSel;
                if (ControlNo == 0)
                {
                    if (FlxInv.ColSel == 7 && vQtyGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 8 && vPriceGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 9 && vDisGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 31 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 38 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    FlxInv.SetData(FlxInv.RowSel, FlxInv.ColSel, FlxInv.GetData(FlxInv.RowSel, FlxInv.ColSel).ToString() + "6");
                    FlxInv_AfterEdit(sender, new RowColEventArgs(FlxInv.RowSel, FlxInv.ColSel));
                    vQtyGraid = false;
                    vPriceGraid = false;
                    vTotGraid = false;
                    vDisGraid = false;
                    vTax = false;
                }
                else
                {
                    if (ControlNo == 1 || ControlNo == 2)
                    {
                        return;
                    }
                    if (ControlNo == 3)
                    {
                        txtRemark.Text += "6";
                    }
                    else if (ControlNo == 4)
                    {
                        txtRef.Text += "6";
                    }
                    else if (ControlNo == 5)
                    {
                        if (!txtTele.ReadOnly)
                        {
                            txtTele.Text += "6";
                        }
                    }
                    else if (ControlNo == 6)
                    {
                        txtDiscountVal.Text = txtDiscountVal.Text.Substring(0, txtDiscountVal.Text.Length - 3) + "6";
                        txtDiscountVal_Leave(sender, e);
                    }
                    else if (ControlNo == 7)
                    {
                        txtDiscountP.Text = txtDiscountP.Text.Substring(0, txtDiscountP.Text.Length - 3) + "6";
                        txtDiscountP_Leave(sender, e);
                    }
                    return;
                }
            }
            catch
            {
            }
        }
        private void button_9_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 0)
                {
                    int vRowIndex = FlxInv.RowSel;
                    if (FlxInv.ColSel == 7 && vQtyGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 8 && vPriceGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 9 && vDisGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 31 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 38 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    FlxInv.SetData(FlxInv.RowSel, FlxInv.ColSel, FlxInv.GetData(FlxInv.RowSel, FlxInv.ColSel).ToString() + "9");
                    FlxInv_AfterEdit(sender, new RowColEventArgs(FlxInv.RowSel, FlxInv.ColSel));
                    vQtyGraid = false;
                    vPriceGraid = false;
                    vTotGraid = false;
                    vDisGraid = false;
                    vTax = false;
                }
                else
                {
                    if (ControlNo == 1 || ControlNo == 2)
                    {
                        return;
                    }
                    if (ControlNo == 3)
                    {
                        txtRemark.Text += "9";
                    }
                    else if (ControlNo == 4)
                    {
                        txtRef.Text += "9";
                    }
                    else if (ControlNo == 5)
                    {
                        if (!txtTele.ReadOnly)
                        {
                            txtTele.Text += "9";
                        }
                    }
                    else if (ControlNo == 6)
                    {
                        txtDiscountVal.Text = txtDiscountVal.Text.Substring(0, txtDiscountVal.Text.Length - 3) + "9";
                        txtDiscountVal_Leave(sender, e);
                    }
                    else if (ControlNo == 7)
                    {
                        txtDiscountP.Text = txtDiscountP.Text.Substring(0, txtDiscountP.Text.Length - 3) + "9";
                        txtDiscountP_Leave(sender, e);
                    }
                    return;
                }
            }
            catch
            {
            }
        }
        private void button_8_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 0)
                {
                    int vRowIndex = FlxInv.RowSel;
                    if (FlxInv.ColSel == 7 && vQtyGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 8 && vPriceGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 9 && vDisGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 31 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 38 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    FlxInv.SetData(FlxInv.RowSel, FlxInv.ColSel, FlxInv.GetData(FlxInv.RowSel, FlxInv.ColSel).ToString() + "8");
                    FlxInv_AfterEdit(sender, new RowColEventArgs(FlxInv.RowSel, FlxInv.ColSel));
                    vQtyGraid = false;
                    vPriceGraid = false;
                    vTotGraid = false;
                    vDisGraid = false;
                    vTax = false;
                }
                else
                {
                    if (ControlNo == 1 || ControlNo == 2)
                    {
                        return;
                    }
                    if (ControlNo == 3)
                    {
                        txtRemark.Text += "8";
                    }
                    else if (ControlNo == 4)
                    {
                        txtRef.Text += "8";
                    }
                    else if (ControlNo == 5)
                    {
                        if (!txtTele.ReadOnly)
                        {
                            txtTele.Text += "8";
                        }
                    }
                    else if (ControlNo == 6)
                    {
                        txtDiscountVal.Text = txtDiscountVal.Text.Substring(0, txtDiscountVal.Text.Length - 3) + "8";
                        txtDiscountVal_Leave(sender, e);
                    }
                    else if (ControlNo == 7)
                    {
                        txtDiscountP.Text = txtDiscountP.Text.Substring(0, txtDiscountP.Text.Length - 3) + "8";
                        txtDiscountP_Leave(sender, e);
                    }
                    return;
                }
            }
            catch
            {
            }
        }
        private void button_7_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 0)
                {
                    int vRowIndex = FlxInv.RowSel;
                    if (FlxInv.ColSel == 7 && vQtyGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 8 && vPriceGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 9 && vDisGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 31 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 38 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    FlxInv.SetData(FlxInv.RowSel, FlxInv.ColSel, FlxInv.GetData(FlxInv.RowSel, FlxInv.ColSel).ToString() + "7");
                    FlxInv_AfterEdit(sender, new RowColEventArgs(FlxInv.RowSel, FlxInv.ColSel));
                    vQtyGraid = false;
                    vPriceGraid = false;
                    vTotGraid = false;
                    vDisGraid = false;
                    vTax = false;
                }
                else
                {
                    if (ControlNo == 1 || ControlNo == 2)
                    {
                        return;
                    }
                    if (ControlNo == 3)
                    {
                        txtRemark.Text += "7";
                    }
                    else if (ControlNo == 4)
                    {
                        txtRef.Text += "7";
                    }
                    else if (ControlNo == 5)
                    {
                        if (!txtTele.ReadOnly)
                        {
                            txtTele.Text += "7";
                        }
                    }
                    else if (ControlNo == 6)
                    {
                        txtDiscountVal.Text = txtDiscountVal.Text.Substring(0, txtDiscountVal.Text.Length - 3) + "7";
                        txtDiscountVal_Leave(sender, e);
                    }
                    else if (ControlNo == 7)
                    {
                        txtDiscountP.Text = txtDiscountP.Text.Substring(0, txtDiscountP.Text.Length - 3) + "7";
                        txtDiscountP_Leave(sender, e);
                    }
                    return;
                }
            }
            catch
            {
            }
        }
        private void button_Bac_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 0)
                {
                    int vRowIndex = FlxInv.RowSel;
                    FlxInv.SetData(FlxInv.RowSel, FlxInv.ColSel, "0");
                    FlxInv_AfterEdit(sender, new RowColEventArgs(FlxInv.RowSel, FlxInv.ColSel));
                    vQtyGraid = false;
                    vPriceGraid = false;
                    vTotGraid = false;
                    vDisGraid = false;
                    vTax = false;
                }
                else
                {
                    if (ControlNo == 1 || ControlNo == 2)
                    {
                        return;
                    }
                    if (ControlNo == 3)
                    {
                        txtRemark.Text = "";
                    }
                    else if (ControlNo == 4)
                    {
                        txtRef.Text = "";
                    }
                    else if (ControlNo == 5)
                    {
                        if (!txtTele.ReadOnly)
                        {
                            txtTele.Text = "";
                        }
                    }
                    else if (ControlNo == 6)
                    {
                        txtDiscountVal.Text = "0";
                        txtDiscountVal_Leave(sender, e);
                    }
                    else if (ControlNo == 7)
                    {
                        txtDiscountP.Text = "0";
                        txtDiscountP_Leave(sender, e);
                    }
                    return;
                }
            }
            catch
            {
            }
        }
        private void button_0_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 0)
                {
                    int vRowIndex = FlxInv.RowSel;
                    if (FlxInv.ColSel == 7 && vQtyGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 8 && vPriceGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 9 && vDisGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 31 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    else if (FlxInv.ColSel == 38 && vTotGraid)
                    {
                        button_Bac_Click(sender, e);
                    }
                    FlxInv.SetData(FlxInv.RowSel, FlxInv.ColSel, FlxInv.GetData(FlxInv.RowSel, FlxInv.ColSel).ToString() + "0");
                    FlxInv_AfterEdit(sender, new RowColEventArgs(FlxInv.RowSel, FlxInv.ColSel));
                    vQtyGraid = false;
                    vPriceGraid = false;
                    vTotGraid = false;
                    vDisGraid = false;
                    vTax = false;
                }
                else
                {
                    if (ControlNo == 1 || ControlNo == 2)
                    {
                        return;
                    }
                    if (ControlNo == 3)
                    {
                        txtRemark.Text += "0";
                    }
                    else if (ControlNo == 4)
                    {
                        txtRef.Text += "0";
                    }
                    else if (ControlNo == 5)
                    {
                        if (!txtTele.ReadOnly)
                        {
                            txtTele.Text += "0";
                        }
                    }
                    else if (ControlNo == 6)
                    {
                        txtDiscountVal.Text = txtDiscountVal.Text.Substring(0, txtDiscountVal.Text.Length - 3) + "0";
                        txtDiscountVal_Leave(sender, e);
                    }
                    else if (ControlNo == 7)
                    {
                        txtDiscountP.Text = txtDiscountP.Text.Substring(0, txtDiscountP.Text.Length - 3) + "0";
                        txtDiscountP_Leave(sender, e);
                    }
                    return;
                }
            }
            catch
            {
            }
        }
        private void PanaHide(bool Sts)
        {
        }
        private void FlxInv_LeaveCell(object sender, EventArgs e)
        {
            PanaHide(Sts: false);
        }
        private void FlxInv_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.SSSLev != "R" && VarGeneral.SSSLev != "C" && VarGeneral.SSSLev != "H" && FlxInv.Rows[_RowIndex].Height == 33)
                {
                    FlxInv.SetData(_RowIndex - 1, 36, FlxInv.GetData(_RowIndex, (LangArEn == 0) ? 2 : 4));
                }
            }
            catch
            {
            }
        }
        private void FlxInv_AfterSelChange(object sender, RangeEventArgs e)
        {
            try
            {
                int vRowIndex = FlxInv.RowSel;
                for (int i = 1; i < FlxInv.Rows.Count; i++)
                {
                    if (i == vRowIndex)
                    {
                        FlxInv.SetData(i, 37, true);
                        button_DeleteLine.Visible = true;
                    }
                    else
                    {
                        FlxInv.SetData(i, 37, false);
                    }
                    FlxInv_AfterEdit(sender, new RowColEventArgs(i, 37));
                }
            }
            catch
            {
            }
        }
        private void txtGDate_Enter(object sender, EventArgs e)
        {
            ControlNo = 1;
            CheckSts(ControlNo);
        }
        private void txtHDate_Enter(object sender, EventArgs e)
        {
            ControlNo = 2;
            CheckSts(ControlNo);
        }
        private void txtTime_Enter(object sender, EventArgs e)
        {
            ControlNo = 3;
            CheckSts(ControlNo);
        }
        private void txtRef_Enter(object sender, EventArgs e)
        {
            ControlNo = 4;
            CheckSts(ControlNo);
        }
        private void txtTele_Enter(object sender, EventArgs e)
        {
            ControlNo = 5;
            CheckSts(ControlNo);
        }
        private void txtDiscountVal_Enter(object sender, EventArgs e)
        {
            ControlNo = 6;
            CheckSts(ControlNo);
        }
        private void txtDiscountP_Enter(object sender, EventArgs e)
        {
            ControlNo = 7;
            CheckSts(ControlNo);
        }
        private void CheckSts(int Sts)
        {
            try
            {
                if (ControlNo == 0)
                {
                    txtRef.ButtonCustom.Checked = false;
                    txtTele.ButtonCustom.Checked = false;
                    txtDiscountVal.ButtonCustom.Checked = false;
                    txtDiscountP.ButtonCustom.Checked = false;
                }
                else if (ControlNo == 1)
                {
                    txtRef.ButtonCustom.Checked = false;
                    txtTele.ButtonCustom.Checked = false;
                    txtDiscountVal.ButtonCustom.Checked = false;
                    txtDiscountP.ButtonCustom.Checked = false;
                }
                else if (ControlNo == 2)
                {
                    txtRef.ButtonCustom.Checked = false;
                    txtTele.ButtonCustom.Checked = false;
                    txtDiscountVal.ButtonCustom.Checked = false;
                    txtDiscountP.ButtonCustom.Checked = false;
                }
                else if (ControlNo == 3)
                {
                    txtRef.ButtonCustom.Checked = false;
                    txtTele.ButtonCustom.Checked = false;
                    txtDiscountVal.ButtonCustom.Checked = false;
                    txtDiscountP.ButtonCustom.Checked = false;
                }
                else if (ControlNo == 4)
                {
                    txtRef.ButtonCustom.Checked = true;
                    txtTele.ButtonCustom.Checked = false;
                    txtDiscountVal.ButtonCustom.Checked = false;
                    txtDiscountP.ButtonCustom.Checked = false;
                }
                else if (ControlNo == 5)
                {
                    txtRef.ButtonCustom.Checked = false;
                    txtTele.ButtonCustom.Checked = true;
                    txtDiscountVal.ButtonCustom.Checked = false;
                    txtDiscountP.ButtonCustom.Checked = false;
                }
                else if (ControlNo == 6)
                {
                    txtRef.ButtonCustom.Checked = false;
                    txtTele.ButtonCustom.Checked = false;
                    txtDiscountVal.ButtonCustom.Checked = true;
                    txtDiscountP.ButtonCustom.Checked = false;
                }
                else if (ControlNo == 7)
                {
                    txtRef.ButtonCustom.Checked = false;
                    txtTele.ButtonCustom.Checked = false;
                    txtDiscountVal.ButtonCustom.Checked = false;
                    txtDiscountP.ButtonCustom.Checked = true;
                }
            }
            catch
            {
            }
        }
        private void txtGDate_ButtonCustomClick(object sender, EventArgs e)
        {
            ControlNo = 1;
            CheckSts(ControlNo);
        }
        private void txtHDate_ButtonCustomClick(object sender, EventArgs e)
        {
            ControlNo = 2;
            CheckSts(ControlNo);
        }
        private void txtTime_ButtonCustomClick(object sender, EventArgs e)
        {
            ControlNo = 3;
            CheckSts(ControlNo);
        }
        private void txtRef_ButtonCustomClick(object sender, EventArgs e)
        {
            ControlNo = 4;
            CheckSts(ControlNo);
        }
        private void txtTele_ButtonCustomClick(object sender, EventArgs e)
        {
            ControlNo = 5;
            CheckSts(ControlNo);
        }
        private void txtDiscountVal_ButtonCustomClick(object sender, EventArgs e)
        {
            ControlNo = 6;
            CheckSts(ControlNo);
        }
        private void txtDiscountP_ButtonCustomClick(object sender, EventArgs e)
        {
            ControlNo = 7;
            CheckSts(ControlNo);
        }
        private void txtGDate_Click(object sender, EventArgs e)
        {
            txtGDate.SelectAll();
        }
        private void txtHDate_Click(object sender, EventArgs e)
        {
            txtHDate.SelectAll();
        }
        private void txtTime_Click(object sender, EventArgs e)
        {
            txtTime.SelectAll();
        }
        private void txtRemark_Enter(object sender, EventArgs e)
        {
            ControlNo = 3;
            CheckSts(ControlNo);
        }
        private void button_Space_Click(object sender, EventArgs e)
        {
            try
            {
                if (ControlNo == 0 || ControlNo == 1 || ControlNo == 2)
                {
                    return;
                }
                if (ControlNo == 3)
                {
                    txtRemark.Text += " ";
                }
                else if (ControlNo == 4)
                {
                    txtRef.Text += " ";
                }
                else if (ControlNo == 5)
                {
                    if (!txtTele.ReadOnly)
                    {
                        txtTele.Text += " ";
                    }
                }
                else if (ControlNo != 6 && ControlNo != 7)
                {
                }
            }
            catch
            {
            }
        }
        private void buttonItem_OrderOptions_Click(object sender, EventArgs e)
        {
        }
        private void button_SrchTable_Click(object sender, EventArgs e)
        {
            if (State == FormState.Edit || string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            if (State == FormState.Saved)
            {
                Button_Edit_Click(sender, e);
            }
            if ((data_this.RoomSts.HasValue && !data_this.RoomSts.Value) || string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            FrmTables frm2 = new FrmTables(textBox_ID.Text, 0, frmSts: false);
            frm2.Tag = LangArEn;
            VarGeneral.SFrmTyp = "";
            if (State == FormState.New)
            {
                frm2.sts_ = "new";
            }
            else
            {
                if (State != FormState.Edit)
                {
                    return;
                }
                try
                {
                    if (data_this.RoomNo.Value == 0)
                    {
                        frm2.sts_ = "new";
                    }
                    else
                    {
                        frm2.sts_ = "update";
                    }
                }
                catch
                {
                    return;
                }
            }
            frm2.TopMost = true;
            frm2.ShowDialog();
            if (frm2.sts_ == "new")
            {
                txtTable.Value = db.StockRommID(frm2.Serach_No).RomeNo;
                txtTable.Tag = frm2.Serach_No;
            }
            else
            {
                textBox_ID_TextChanged(sender, e);
            }
            TableTyp();
        }
        private void TableTyp()
        {
            try
            {
                if (txtTable.Value < 1 || string.IsNullOrEmpty(txtTable.Tag.ToString()) || State == FormState.New)
                {
                    labelTableTyp.Text = ((LangArEn == 0) ? "بدون طاولة" : "WithOut Table");
                    return;
                }
                T_Room q = db.StockRommID(int.Parse(txtTable.Tag.ToString()));
                if (q == null || string.IsNullOrEmpty(q.RomeNo.ToString()))
                {
                    labelTableTyp.Text = ((LangArEn == 0) ? "بدون طاولة" : "WithOut Table");
                }
                else if (q.Type == 1)
                {
                    labelTableTyp.Text = ((LangArEn == 0) ? "طاولات العوائل" : "Families Tables");
                }
                else if (q.Type == 2)
                {
                    labelTableTyp.Text = ((LangArEn == 0) ? "طاولات الشباب" : "Boys Tables");
                }
                else if (q.Type == 3)
                {
                    labelTableTyp.Text = ((LangArEn == 0) ? "طاولات خارجية" : "Extrnal Tables");
                }
                else if (q.Type == 4)
                {
                    labelTableTyp.Text = ((LangArEn == 0) ? "طاولات أخرى" : "Other Tables");
                }
                else
                {
                    labelTableTyp.Text = ((LangArEn == 0) ? "بدون طاولة" : "WithOut Table");
                }
            }
            catch
            {
                labelTableTyp.Text = ((LangArEn == 0) ? "بدون طاولة" : "WithOut Table");
            }
        }
        private void button_DeleteLine_Click(object sender, EventArgs e)
        {
            try
            {
                if (FlxInv.GetData(RowSel, 1).ToString() != null)
                {
                    if (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 32)))) == 2.0)
                    {
                        ItemDetRemoved.Add(int.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 25)))));
                    }
                    if (FlxInv.Rows[FlxInv.Row].Height > 33)
                    {
                        FlxInv.RemoveItem(FlxInv.Row);
                        FlxInv.RemoveItem(FlxInv.Row);
                    }
                    else
                    {
                        FlxInv.RemoveItem(FlxInv.Row - 1);
                        FlxInv.RemoveItem(FlxInv.Row);
                    }
                    GetInvTot();
                    try
                    {
                        FlxInv.SetData(FlxInv.RowSel, 37, true);
                    }
                    catch
                    {
                    }
                    FlxInv_AfterEdit(sender, new RowColEventArgs(FlxInv.RowSel, 37));
                }
            }
            catch
            {
                GetInvTot();
            }
        }
        private void superGridControl1_CellClick(object sender, GridCellClickEventArgs e)
        {
            try
            {
                int eRow = e.GridCell.RowIndex;
                int eCol = e.GridCell.ColumnIndex;
                if (!string.IsNullOrEmpty(textBox_ID.Text))
                {
                    if (State == FormState.Saved)
                    {
                        Button_Edit_Click(sender, e);
                    }
                    object q = superGridControl1.PrimaryGrid.GetCell(eRow, eCol).Tag;
                    if (!string.IsNullOrEmpty(q.ToString()) && !string.IsNullOrEmpty(superGridControl1.PrimaryGrid.GetCell(eRow, eCol).Value.ToString()))
                    {
                        _stsClick = 0;
                        _ItemProcess(q.ToString());
                    }
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("dataGridView_ItemMains_CellClick:", error, enable: true);
            }
        }
        private void RowNotes()
        {
            FlxInv.Rows.Add();
            FlxInv.Rows[FlxInv.Rows.Count - 1].Height = 33;
            if (!VarGeneral.TString.ChkStatShow(_SysSetting.LineDetailSts, 26))
            {
                FlxInv.Rows[FlxInv.Rows.Count - 1].Visible = false;
            }
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                FlxInv.MergedRanges.Add(FlxInv.GetCellRange(FlxInv.Rows.Count - 1, 37, FlxInv.Rows.Count - 1, 2));
            }
            else
            {
                FlxInv.MergedRanges.Add(FlxInv.GetCellRange(FlxInv.Rows.Count - 1, 37, FlxInv.Rows.Count - 1, 4));
            }
            FlxInv.Row = FlxInv.Rows.Count - 2;
            FlxInv.RowSel = FlxInv.Rows.Count - 2;
            FlxInv.Col = 1;
            FlxInv.Refresh();
        }
        private void _ItemProcess(string q)
        {
            List<T_Item> listSer = new List<T_Item>();
            listSer = db.StockItemList(q.ToString());
            _Items = listSer[0];
            FlxInv.Rows.Add();
            FlxInv.Rows[FlxInv.Rows.Count - 1].Height = 35;
            FlxInv.SetData(FlxInv.Rows.Count - 1, 1, _Items.Itm_No);
            FlxInv.Row = FlxInv.Rows.Count - 1;
            FlxInv.RowSel = FlxInv.Rows.Count - 1;
            FlxInv.Col = 1;
            RowNotes();
            BindDataOfItem();
            BindDataOfStkQty(string.Concat(FlxInv.GetData(FlxInv.RowSel, 1)));
            Refresh();
        }
        private void buttonItem_BestSeller_Click(object sender, EventArgs e)
        {
            try
            {
                ItmMainParameter = "";
                FillItmesMain(null, vBestSaller: true);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("metroTilePanel_Cat_ItemClick:", error, enable: true);
                Refresh();
            }
        }
        private void FrmWaiterMenue_FormClosed(object sender, FormClosedEventArgs e)
        {
            VarGeneral._IsPOS = false;
        }
        private void txtCustNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
        private void txtCustNo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtCustNo.ReadOnly)
                {
                    return;
                }
                List<T_AccDef> LAccDef = new List<T_AccDef>();
                LAccDef = (from t in db.T_AccDefs
                           where t.Lev == (int?)4 && t.AccCat == (int?)4 && t.Sts == (int?)0
                           where !t.StopedState.Value
                           where t.AccDef_No == txtCustNo.Text
                           orderby t.AccDef_No
                           select t).ToList();
                if (LAccDef.Count > 0)
                {
                    txtCustNo.Text = db.StockAccDefWithOutBalance(txtCustNo.Text).AccDef_No;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtCustName.Text = db.StockAccDefWithOutBalance(txtCustNo.Text).Arb_Des;
                    }
                    else
                    {
                        txtCustName.Text = db.StockAccDefWithOutBalance(txtCustNo.Text).Eng_Des;
                    }
                    txtAddress.Text = db.StockAccDefWithOutBalance(txtCustNo.Text).Adders ?? "";
                    txtTele.Text = db.StockAccDefWithOutBalance(txtCustNo.Text).Telphone1 ?? "";
                    try
                    {
                        if (db.StockAccDefWithOutBalance(txtCustNo.Text).Mnd.HasValue)
                        {
                            int? mnd_Typ = db.StockAccDefWithOutBalance(txtCustNo.Text).T_Mndob.Mnd_Typ;
                            if (mnd_Typ.Value == 0 && mnd_Typ.HasValue)
                            {
                                CmbLegate.SelectedValue = db.StockAccDefWithOutBalance(txtCustNo.Text).Mnd;
                            }
                            else
                            {
                                CmbLegate.SelectedValue = db.StockAccDefWithOutBalance(txtCustNo.Text).Mnd;
                            }
                        }
                    }
                    catch
                    {
                        CmbLegate.SelectedIndex = 0;
                    }
                    try
                    {
                        txtCustRep.Value = db.StockAccDef(txtCustNo.Text).Balance.Value;
                    }
                    catch
                    {
                        txtCustRep.Value = 0.0;
                    }
                }
                else
                {
                    txtCustNo.Text = "";
                    txtCustRep.Value = 0.0;
                }
                txtCustNo_TextChanged(sender, e);
            }
            catch
            {
                txtCustNo.Text = "";
                txtCustRep.Value = 0.0;
                txtCustNo_TextChanged(sender, e);
            }
        }
        private void button_SrchCenterCost_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            if (State == FormState.Saved)
            {
                return;
            }
            try
            {
                FrmCustSearch frm = new FrmCustSearch();
                frm.vTy_ = 2;
                frm.Tag = LangArEn;
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    CmbCostC.SelectedValue = db.StockCst(frm.Serach_No).Cst_ID;
                }
                else
                {
                    CmbCostC.SelectedIndex = 0;
                }
            }
            catch
            {
                CmbCostC.SelectedIndex = 0;
            }
        }
        private void button_SrchMnd_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            if (State == FormState.Saved)
            {
                return;
            }
            try
            {
                FrmCustSearch frm = new FrmCustSearch();
                frm.vTy_ = 4;
                frm.Tag = LangArEn;
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    CmbLegate.SelectedValue = db.StockMndob(frm.Serach_No).Mnd_ID;
                }
                else
                {
                    CmbLegate.SelectedIndex = 0;
                }
            }
            catch
            {
                CmbLegate.SelectedIndex = 0;
            }
        }
        private void button_SrchCurr_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            if (State == FormState.Saved)
            {
                return;
            }
            try
            {
                FrmCustSearch frm = new FrmCustSearch();
                frm.vTy_ = 5;
                frm.Tag = LangArEn;
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    CmbCurr.SelectedValue = db.StockCurency(frm.Serach_No).Curency_ID;
                }
                else
                {
                    CmbCurr.SelectedIndex = 0;
                }
            }
            catch
            {
                CmbCurr.SelectedIndex = 0;
            }
        }
        private void button_SrchPriceDefault_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            if (State == FormState.Saved)
            {
                return;
            }
            try
            {
                FrmCustSearch frm = new FrmCustSearch();
                frm.vTy_ = 6;
                frm.Tag = LangArEn;
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    CmbInvPrice.SelectedIndex = int.Parse(frm.Serach_No);
                }
                else
                {
                    CmbInvPrice.SelectedIndex = 0;
                }
            }
            catch
            {
                CmbInvPrice.SelectedIndex = 0;
            }
        }
        private void button_SrchCustADD_Click(object sender, EventArgs e)
        {
            if (!VarGeneral.TString.ChkStatShow(permission.FilStr, 33))
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكنك إضافة عميل جديد .. راجع صلاحيات المستخدمين" : "You can not add a new customer ... Check the Users Authorizations", VarGeneral.ProdectNam);
                return;
            }
            FrmCustomer frm = new FrmCustomer();
            frm.Tag = LangArEn;
            frm.TopMost = true;
            frm.ShowDialog();
        }
        private void FrmInvSalePoint_SizeChanged(object sender, EventArgs e)
        {
            FillCat();
            if (base.WindowState == FormWindowState.Normal)
            {
                btnPrevPage.Text = "";
                btnNxtPage.Text = "";
                buttonItem_BestSeller.Text = "";
            }
            else if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                btnPrevPage.Text = "سابق";
                btnNxtPage.Text = "تالي";
                buttonItem_BestSeller.Text = "أكثر مبيعا\u064c";
            }
            else
            {
                btnPrevPage.Text = "Prev";
                btnNxtPage.Text = "Next";
                buttonItem_BestSeller.Text = "Best Seller";
            }
        }
        private void switchButton_Lock_ValueChanged(object sender, EventArgs e)
        {
            if (!(textBox_ID.Text != "") || State != 0)
            {
                return;
            }
            Stock_DataDataContext _DB = new Stock_DataDataContext(VarGeneral.BranchCS);
            T_INVHED c = _DB.StockInvHead(VarGeneral.InvTyp, data_this.InvNo);
            List<T_INVHED> q = (from t in _DB.T_INVHEDs
                                where t.IfDel == (int?)0
                                where t.InvTyp == (int?)VarGeneral.InvTyp
                                where t.RoomNo == (int?)c.RoomNo.Value
                                orderby t.InvNo
                                select t).ToList();
            for (int i = 0; i < q.Count; i++)
            {
                T_INVHED WiterOrder = q[i];
                _DB.ExecuteCommand("UPDATE [T_INVHED] SET [AdminLock] =" + (switchButton_Lock.Value ? "1" : "0") + " where InvHed_ID= " + WiterOrder.InvHed_ID);
            }
            dbInstance = null;
            RefreshPKeys();
        }
        private void switchButton_Lock_Click(object sender, EventArgs e)
        {
        }
        private void button_AddToTable_Click(object sender, EventArgs e)
        {
            VarGeneral.Tb_Return = false;
            if (State == FormState.Edit || string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            if (State == FormState.Saved)
            {
                Button_Edit_Click(sender, e);
            }
            if ((data_this.RoomSts.HasValue && !data_this.RoomSts.Value) || string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            FrmTables frm2 = new FrmTables(textBox_ID.Text, 0, frmSts: false);
            frm2.Tag = LangArEn;
            VarGeneral.SFrmTyp = "AddToTable";
            if (State == FormState.New)
            {
                frm2.sts_ = "new";
            }
            else
            {
                if (State != FormState.Edit)
                {
                    return;
                }
                if (data_this.RoomNo.Value == 0)
                {
                    frm2.sts_ = "new";
                }
                else
                {
                    frm2.sts_ = "update";
                }
            }
            frm2.TopMost = true;
            frm2.ShowDialog();
            if (VarGeneral.Tb_Return)
            {
                button_SrchTable_Click(sender, e);
            }
            else if (frm2.sts_ == "new")
            {
                txtTable.Value = db.StockRommID(frm2.Serach_No).RomeNo;
                txtTable.Tag = frm2.Serach_No;
            }
            else
            {
                textBox_ID_TextChanged(sender, e);
            }
            VarGeneral.SFrmTyp = "";
            TableTyp();
        }
        private void switchButton_Tax_ValueChanged(object sender, EventArgs e)
        {
            GetInvTot();
        }
        private void checkBox_CostGaidTax_CheckedChanged(object sender, EventArgs e)
        {
            txtDueAmountLoc_ValueChanged(sender, e);
        }
    }
}
