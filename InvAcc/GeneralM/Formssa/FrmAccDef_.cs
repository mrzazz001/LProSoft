using DevComponents.AdvTree;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
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
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmAccDef_ : Form
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
                        frm.Repvalue = "RepGeneral";


                        frm.Repvalue = "RepGeneral";
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
        private SuperTabControl superTabControl_DGV;
        protected ButtonItem Button_ExportTable2;
        protected ButtonItem Button_PrintTable;
        protected LabelItem labelItem3;
        protected SuperGridControl DGV_Main;
        protected LabelItem Label_Count;
        private PanelEx panelEx3;
        private RibbonBar ribbonBar_DGV;
        protected ButtonItem Button_Next;
        protected TextBoxItem TextBox_Index;
        protected ButtonItem Button_Last;
        private Timer timerInfoBallon;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog1;
        protected ContextMenuStrip contextMenuStrip1;
        protected ToolStripMenuItem ToolStripMenuItem_Det;
        private Panel panel1;
        private ExpandableSplitter expandableSplitter1;
        private RibbonBar ribbonBar1;
        private RibbonBar ribbonBar_Tasks;
        private SuperTabControl superTabControl_Main1;
        protected ButtonItem Button_Close;
        protected ButtonItem Button_Search;
        protected ButtonItem Button_Delete;
        protected ButtonItem Button_Save;
        protected ButtonItem Button_Add;
        protected LabelItem labelItem2;
        private SuperTabControl superTabControl_Main2;
        protected LabelItem labelItem1;
        protected ButtonItem Button_First;
        protected ButtonItem Button_Prev;
        protected ToolStripMenuItem ToolStripMenuItem_Rep;
        private ImageList imageList1;
        private DockSite barTopDockSite;
        private DockSite barLeftDockSite;
        private DockSite barBottomDockSite;
        private DockSite barRightDockSite;
        private DockSite dockSite4;
        private DockSite dockSite1;
        public DotNetBarManager dotNetBarManager1;
        private DockSite dockSite2;
        private DockSite dockSite3;
        protected ContextMenuStrip contextMenuStrip2;
        private DevComponents.DotNetBar.TabControl tabControl1;
        private TabControlPanel tabControlPanel1;
        private AdvTree advTree3;
        private ProgressBarX progressBarX1;
        private Node node4;
        private Node node15;
        private Node node17;
        private Node node18;
        private Cell cell17;
        private Node node19;
        private Node node20;
        private Node node21;
        private Node node22;
        private Node node23;
        private Node node24;
        private Cell cell18;
        private Node node25;
        private Node node26;
        private Node node27;
        private Node node28;
        private Node node29;
        private Node node30;
        private ElementStyle elementStyle4;
        private NodeConnector nodeConnector1;
        private ElementStyle elementStyle3;
        private TabItem tabItem1;
        private TabControlPanel tabControlPanel3;
        private AdvTree advTree5;
        private ElementStyle elementStyle6;
        private TabItem tabItem3;
        private TabControlPanel tabControlPanel2;
        private AdvTree advTree4;
        private DevComponents.AdvTree.ColumnHeader columnHeader7;
        private DevComponents.AdvTree.ColumnHeader columnHeader8;
        private Node node31;
        private Node node38;
        private Cell cell28;
        private Cell cell29;
        private Node node39;
        private Cell cell30;
        private Cell cell31;
        private Node node32;
        private Node node34;
        private Cell cell22;
        private Cell cell23;
        private Node node35;
        private Cell cell24;
        private Cell cell25;
        private Node node36;
        private Cell cell26;
        private Cell cell27;
        private Node node33;
        private Node node37;
        private Cell cell32;
        private Cell cell33;
        private ElementStyle elementStyle5;
        private TabItem tabItem2;
        private AdvTree advTree2;
        private DevComponents.AdvTree.ColumnHeader columnHeader4;
        private DevComponents.AdvTree.ColumnHeader columnHeader5;
        private DevComponents.AdvTree.ColumnHeader columnHeader6;
        private Node node1;
        private Node node2;
        private Node node5;
        private Node node10;
        private Cell cell7;
        private Cell cell8;
        private ElementStyle unreadEmailStyle;
        private Node node8;
        private Cell cell15;
        private Cell cell16;
        private Node node9;
        private Cell cell13;
        private Cell cell14;
        private Node node11;
        private Cell cell1;
        private Cell cell2;
        private Node node12;
        private Cell cell3;
        private Cell cell4;
        private Node node13;
        private Cell cell5;
        private Cell cell6;
        private Node node6;
        private Node node14;
        private Cell cell9;
        private Cell cell10;
        private Node node7;
        private ElementStyle elementStyle2;
        private TextBox txtParLevel;
        private Label label6;
        private TextBox txtAccDefId;
        private Label label10;
        private ComboBox CmbStat;
        private GroupBox groupBox1;
        private TextBox txtAccLevel;
        private Label label5;
        private TextBox txtParName;
        private ButtonX button_SrchAccFrom;
        private Label label7;
        private TextBox textBox_ID;
        private Label label4;
        private TextBox txtEngDes;
        private Label label2;
        private TextBox txtArbDes;
        private Label label1;
        private TextBox txtParAcc;
        private GroupBox groupBox2;
        private DoubleInput txtCreditLimit;
        private Label label14;
        private Label label8;
        private ComboBoxEx CmbPosting;
        private ComboBoxEx CmbClass;
        private Label label3;
        internal GroupBox groupBox5;
        private CheckBoxX checkBox_Credit;
        private CheckBoxX checkBox_Debit;
        private GroupBox groupBox3;
        private DoubleInput txtTDebit;
        private DoubleInput txtTCredit;
        private DoubleInput txtBalance;
        private Label label13;
        private Label label12;
        private Label label11;
        protected PanelEx panelEx2;
        protected TextBoxItem textBox_search;
        private ImageList imageList_AccTree;
        private ButtonX buttonX_Expand;
        private AdvTree treeView1;
        private ElementStyle elementStyle1;
        private ElementStyle elementStyle7;
        private ElementStyle elementStyle8;
        private ElementStyle elementStyle9;
        private ElementStyle elementStyle10;
        private ElementStyle elementStyle11;
        private ElementStyle elementStyle12;
        private ElementStyle elementStyle13;
        private ElementStyle elementStyle14;
        private ElementStyle elementStyle15;
        private ElementStyle elementStyle16;
        private ElementStyle elementStyle17;
        private ButtonX buttonX_Collaps;
        private ElementStyle elementStyle18;
        private DoubleInput txtOpenAcc;
        private Label label9;
        private Label label15;
        private LabelItem lable_Records;
        private CheckBoxX checkBoxX_Stoped;
        private TextBox txtTaxNo;
        private Label label16;
        private DoubleInput txtPerSales;
        private Label label17;
        private Label label18;
        private T_AccDef _AccDef = new T_AccDef();
        private T_AccDef _AccDefBind = new T_AccDef();
        private int ItemIndex = 0;
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
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
        private T_AccDef data_this;
        private long T1;
        private long T2;
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
        private int indColumn = 0;
        private string cellValue;
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
                superTabControl_Main1.Refresh();
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
                superTabControl_Main1.Refresh();
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
        public T_AccDef DataThis
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
                    if (!VarGeneral.TString.ChkStatShow(value.SndStr, 5))
                    {
                        IfAdd = false;
                    }
                    else
                    {
                        IfAdd = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.SndStr, 6))
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.SndStr, 7) || txtAccLevel.Text == "1")
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
                    button_SrchAccFrom.Enabled = true;
                }
                else
                {
                    button_SrchAccFrom.Enabled = false;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAccDef_));
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background3 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background4 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor1 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor2 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle1 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle2 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.Background background5 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.buttonX_Collaps = new DevComponents.DotNetBar.ButtonX();
            this.txtParLevel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAccDefId = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.CmbStat = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAccLevel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtParName = new System.Windows.Forms.TextBox();
            this.button_SrchAccFrom = new DevComponents.DotNetBar.ButtonX();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEngDes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtArbDes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtParAcc = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtPerSales = new DevComponents.Editors.DoubleInput();
            this.label18 = new System.Windows.Forms.Label();
            this.txtTaxNo = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.checkBoxX_Stoped = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label15 = new System.Windows.Forms.Label();
            this.txtOpenAcc = new DevComponents.Editors.DoubleInput();
            this.txtCreditLimit = new DevComponents.Editors.DoubleInput();
            this.label8 = new System.Windows.Forms.Label();
            this.CmbPosting = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.CmbClass = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBox_Credit = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBox_Debit = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label9 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTDebit = new DevComponents.Editors.DoubleInput();
            this.txtTCredit = new DevComponents.Editors.DoubleInput();
            this.txtBalance = new DevComponents.Editors.DoubleInput();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonX_Expand = new DevComponents.DotNetBar.ButtonX();
            this.treeView1 = new DevComponents.AdvTree.AdvTree();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle17 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle7 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle8 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle9 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle10 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle11 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle12 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle13 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle14 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle15 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle16 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle18 = new DevComponents.DotNetBar.ElementStyle();
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.superTabControl_DGV = new DevComponents.DotNetBar.SuperTabControl();
            this.textBox_search = new DevComponents.DotNetBar.TextBoxItem();
            this.Button_ExportTable2 = new DevComponents.DotNetBar.ButtonItem();
            this.Button_PrintTable = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem3 = new DevComponents.DotNetBar.LabelItem();
            this.DGV_Main = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.ribbonBar_DGV = new DevComponents.DotNetBar.RibbonBar();
            this.timerInfoBallon = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_Det = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.imageList_AccTree = new System.Windows.Forms.ImageList(this.components);
            this.ToolStripMenuItem_Rep = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.barTopDockSite = new DevComponents.DotNetBar.DockSite();
            this.barLeftDockSite = new DevComponents.DotNetBar.DockSite();
            this.barBottomDockSite = new DevComponents.DotNetBar.DockSite();
            this.barRightDockSite = new DevComponents.DotNetBar.DockSite();
            this.dockSite4 = new DevComponents.DotNetBar.DockSite();
            this.dockSite1 = new DevComponents.DotNetBar.DockSite();
            this.dotNetBarManager1 = new DevComponents.DotNetBar.DotNetBarManager(this.components);
            this.dockSite2 = new DevComponents.DotNetBar.DockSite();
            this.dockSite3 = new DevComponents.DotNetBar.DockSite();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.advTree3 = new DevComponents.AdvTree.AdvTree();
            this.progressBarX1 = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.node4 = new DevComponents.AdvTree.Node();
            this.node15 = new DevComponents.AdvTree.Node();
            this.node17 = new DevComponents.AdvTree.Node();
            this.node18 = new DevComponents.AdvTree.Node();
            this.cell17 = new DevComponents.AdvTree.Cell();
            this.node19 = new DevComponents.AdvTree.Node();
            this.node20 = new DevComponents.AdvTree.Node();
            this.node21 = new DevComponents.AdvTree.Node();
            this.node22 = new DevComponents.AdvTree.Node();
            this.node23 = new DevComponents.AdvTree.Node();
            this.node24 = new DevComponents.AdvTree.Node();
            this.cell18 = new DevComponents.AdvTree.Cell();
            this.node25 = new DevComponents.AdvTree.Node();
            this.node26 = new DevComponents.AdvTree.Node();
            this.node27 = new DevComponents.AdvTree.Node();
            this.node28 = new DevComponents.AdvTree.Node();
            this.node29 = new DevComponents.AdvTree.Node();
            this.node30 = new DevComponents.AdvTree.Node();
            this.elementStyle4 = new DevComponents.DotNetBar.ElementStyle();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle3 = new DevComponents.DotNetBar.ElementStyle();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.advTree5 = new DevComponents.AdvTree.AdvTree();
            this.elementStyle6 = new DevComponents.DotNetBar.ElementStyle();
            this.tabItem3 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.advTree4 = new DevComponents.AdvTree.AdvTree();
            this.columnHeader7 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader8 = new DevComponents.AdvTree.ColumnHeader();
            this.node31 = new DevComponents.AdvTree.Node();
            this.node38 = new DevComponents.AdvTree.Node();
            this.cell28 = new DevComponents.AdvTree.Cell();
            this.cell29 = new DevComponents.AdvTree.Cell();
            this.node39 = new DevComponents.AdvTree.Node();
            this.cell30 = new DevComponents.AdvTree.Cell();
            this.cell31 = new DevComponents.AdvTree.Cell();
            this.node32 = new DevComponents.AdvTree.Node();
            this.node34 = new DevComponents.AdvTree.Node();
            this.cell22 = new DevComponents.AdvTree.Cell();
            this.cell23 = new DevComponents.AdvTree.Cell();
            this.node35 = new DevComponents.AdvTree.Node();
            this.cell24 = new DevComponents.AdvTree.Cell();
            this.cell25 = new DevComponents.AdvTree.Cell();
            this.node36 = new DevComponents.AdvTree.Node();
            this.cell26 = new DevComponents.AdvTree.Cell();
            this.cell27 = new DevComponents.AdvTree.Cell();
            this.node33 = new DevComponents.AdvTree.Node();
            this.node37 = new DevComponents.AdvTree.Node();
            this.cell32 = new DevComponents.AdvTree.Cell();
            this.cell33 = new DevComponents.AdvTree.Cell();
            this.elementStyle5 = new DevComponents.DotNetBar.ElementStyle();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.advTree2 = new DevComponents.AdvTree.AdvTree();
            this.columnHeader4 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader5 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader6 = new DevComponents.AdvTree.ColumnHeader();
            this.node1 = new DevComponents.AdvTree.Node();
            this.node2 = new DevComponents.AdvTree.Node();
            this.node5 = new DevComponents.AdvTree.Node();
            this.node10 = new DevComponents.AdvTree.Node();
            this.cell7 = new DevComponents.AdvTree.Cell();
            this.cell8 = new DevComponents.AdvTree.Cell();
            this.unreadEmailStyle = new DevComponents.DotNetBar.ElementStyle();
            this.node8 = new DevComponents.AdvTree.Node();
            this.cell15 = new DevComponents.AdvTree.Cell();
            this.cell16 = new DevComponents.AdvTree.Cell();
            this.node9 = new DevComponents.AdvTree.Node();
            this.cell13 = new DevComponents.AdvTree.Cell();
            this.cell14 = new DevComponents.AdvTree.Cell();
            this.node11 = new DevComponents.AdvTree.Node();
            this.cell1 = new DevComponents.AdvTree.Cell();
            this.cell2 = new DevComponents.AdvTree.Cell();
            this.node12 = new DevComponents.AdvTree.Node();
            this.cell3 = new DevComponents.AdvTree.Cell();
            this.cell4 = new DevComponents.AdvTree.Cell();
            this.node13 = new DevComponents.AdvTree.Node();
            this.cell5 = new DevComponents.AdvTree.Cell();
            this.cell6 = new DevComponents.AdvTree.Cell();
            this.node6 = new DevComponents.AdvTree.Node();
            this.node14 = new DevComponents.AdvTree.Node();
            this.cell9 = new DevComponents.AdvTree.Cell();
            this.cell10 = new DevComponents.AdvTree.Cell();
            this.node7 = new DevComponents.AdvTree.Node();
            this.elementStyle2 = new DevComponents.DotNetBar.ElementStyle();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.PanelSpecialContainer.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPerSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOpenAcc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreditLimit)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTDebit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTCredit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeView1)).BeginInit();
            this.ribbonBar_Tasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_DGV)).BeginInit();
            this.panelEx3.SuspendLayout();
            this.ribbonBar_DGV.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTree3)).BeginInit();
            this.advTree3.SuspendLayout();
            this.tabControlPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTree5)).BeginInit();
            this.tabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTree4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advTree2)).BeginInit();
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
            this.PanelSpecialContainer.Size = new System.Drawing.Size(773, 458);
            this.PanelSpecialContainer.TabIndex = 1220;
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
            this.ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.Silver;
            this.ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.buttonX_Collaps);
            this.ribbonBar1.Controls.Add(this.txtParLevel);
            this.ribbonBar1.Controls.Add(this.label6);
            this.ribbonBar1.Controls.Add(this.txtAccDefId);
            this.ribbonBar1.Controls.Add(this.label10);
            this.ribbonBar1.Controls.Add(this.CmbStat);
            this.ribbonBar1.Controls.Add(this.groupBox1);
            this.ribbonBar1.Controls.Add(this.groupBox2);
            this.ribbonBar1.Controls.Add(this.groupBox3);
            this.ribbonBar1.Controls.Add(this.buttonX_Expand);
            this.ribbonBar1.Controls.Add(this.treeView1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(773, 407);
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
            // buttonX_Collaps
            // 
            this.buttonX_Collaps.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Collaps.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX_Collaps.Location = new System.Drawing.Point(345, 321);
            this.buttonX_Collaps.Name = "buttonX_Collaps";
            this.buttonX_Collaps.Size = new System.Drawing.Size(26, 24);
            this.buttonX_Collaps.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Collaps.Symbol = "";
            this.buttonX_Collaps.SymbolSize = 12F;
            this.buttonX_Collaps.TabIndex = 1141;
            this.buttonX_Collaps.TextColor = System.Drawing.Color.White;
            this.buttonX_Collaps.Tooltip = "طي الكل";
            this.buttonX_Collaps.Click += new System.EventHandler(this.buttonX_Collaps_Click);
            // 
            // txtParLevel
            // 
            this.txtParLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtParLevel.Location = new System.Drawing.Point(-72, 431);
            this.txtParLevel.MaxLength = 20;
            this.txtParLevel.Name = "txtParLevel";
            this.netResize1.SetResizeTextBoxMultiline(this.txtParLevel, false);
            this.txtParLevel.Size = new System.Drawing.Size(99, 20);
            this.txtParLevel.TabIndex = 206;
            this.txtParLevel.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(26, 434);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 207;
            this.label6.Text = "مستوى الحساب الأب";
            this.label6.Visible = false;
            // 
            // txtAccDefId
            // 
            this.txtAccDefId.Location = new System.Drawing.Point(-4, -18);
            this.txtAccDefId.Name = "txtAccDefId";
            this.netResize1.SetResizeTextBoxMultiline(this.txtAccDefId, false);
            this.txtAccDefId.Size = new System.Drawing.Size(100, 20);
            this.txtAccDefId.TabIndex = 205;
            this.txtAccDefId.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(42, 413);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 211;
            this.label10.Text = "الحالة";
            this.label10.Visible = false;
            // 
            // CmbStat
            // 
            this.CmbStat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbStat.Enabled = false;
            this.CmbStat.FormattingEnabled = true;
            this.CmbStat.Items.AddRange(new object[] {
            "السعر الأفتراضي"});
            this.CmbStat.Location = new System.Drawing.Point(-81, 410);
            this.CmbStat.Name = "CmbStat";
            this.CmbStat.Size = new System.Drawing.Size(121, 21);
            this.CmbStat.TabIndex = 209;
            this.CmbStat.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAccLevel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtParName);
            this.groupBox1.Controls.Add(this.button_SrchAccFrom);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox_ID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtEngDes);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtArbDes);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtParAcc);
            this.groupBox1.Location = new System.Drawing.Point(345, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 157);
            this.groupBox1.TabIndex = 208;
            this.groupBox1.TabStop = false;
            // 
            // txtAccLevel
            // 
            this.txtAccLevel.BackColor = System.Drawing.Color.White;
            this.txtAccLevel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtAccLevel.ForeColor = System.Drawing.Color.Maroon;
            this.txtAccLevel.Location = new System.Drawing.Point(8, 25);
            this.txtAccLevel.MaxLength = 2;
            this.txtAccLevel.Name = "txtAccLevel";
            this.txtAccLevel.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtAccLevel, false);
            this.txtAccLevel.Size = new System.Drawing.Size(104, 20);
            this.txtAccLevel.TabIndex = 2;
            this.txtAccLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(113, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 1141;
            this.label5.Text = "المستوى :";
            // 
            // txtParName
            // 
            this.txtParName.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtParName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtParName.ForeColor = System.Drawing.Color.White;
            this.txtParName.Location = new System.Drawing.Point(8, 121);
            this.txtParName.Name = "txtParName";
            this.txtParName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtParName, false);
            this.txtParName.Size = new System.Drawing.Size(182, 20);
            this.txtParName.TabIndex = 7;
            this.txtParName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_SrchAccFrom
            // 
            this.button_SrchAccFrom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchAccFrom.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchAccFrom.Enabled = false;
            this.button_SrchAccFrom.Location = new System.Drawing.Point(192, 121);
            this.button_SrchAccFrom.Name = "button_SrchAccFrom";
            this.button_SrchAccFrom.Size = new System.Drawing.Size(26, 20);
            this.button_SrchAccFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchAccFrom.Symbol = "";
            this.button_SrchAccFrom.SymbolSize = 12F;
            this.button_SrchAccFrom.TabIndex = 6;
            this.button_SrchAccFrom.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchAccFrom.Click += new System.EventHandler(this.button_SrchAccFrom_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(303, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "الحساب الرئيسي :";
            // 
            // textBox_ID
            // 
            this.textBox_ID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.textBox_ID.Location = new System.Drawing.Point(194, 25);
            this.textBox_ID.MaxLength = 30;
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_ID, false);
            this.textBox_ID.Size = new System.Drawing.Size(102, 20);
            this.textBox_ID.TabIndex = 1;
            this.textBox_ID.Click += new System.EventHandler(this.textBox_ID_Click);
            this.textBox_ID.TextChanged += new System.EventHandler(this.textBox_ID_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(303, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "رقم الحساب :";
            // 
            // txtEngDes
            // 
            this.txtEngDes.BackColor = System.Drawing.Color.White;
            this.txtEngDes.Location = new System.Drawing.Point(8, 89);
            this.txtEngDes.MaxLength = 100;
            this.txtEngDes.Name = "txtEngDes";
            this.netResize1.SetResizeTextBoxMultiline(this.txtEngDes, false);
            this.txtEngDes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEngDes.Size = new System.Drawing.Size(288, 20);
            this.txtEngDes.TabIndex = 4;
            this.txtEngDes.Enter += new System.EventHandler(this.txtEngDes_Enter);
            this.txtEngDes.Leave += new System.EventHandler(this.txtArbDes_Enter);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(303, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "إسم الحساب انجليزي :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtArbDes
            // 
            this.txtArbDes.BackColor = System.Drawing.Color.White;
            this.txtArbDes.Location = new System.Drawing.Point(8, 57);
            this.txtArbDes.MaxLength = 100;
            this.txtArbDes.Name = "txtArbDes";
            this.netResize1.SetResizeTextBoxMultiline(this.txtArbDes, false);
            this.txtArbDes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtArbDes.Size = new System.Drawing.Size(288, 20);
            this.txtArbDes.TabIndex = 3;
            this.txtArbDes.Enter += new System.EventHandler(this.txtArbDes_Enter);
            this.txtArbDes.Leave += new System.EventHandler(this.txtArbDes_Enter);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(303, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "إسم الحساب  عربي :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtParAcc
            // 
            this.txtParAcc.BackColor = System.Drawing.Color.White;
            this.txtParAcc.Location = new System.Drawing.Point(219, 121);
            this.txtParAcc.Name = "txtParAcc";
            this.txtParAcc.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtParAcc, false);
            this.txtParAcc.Size = new System.Drawing.Size(79, 20);
            this.txtParAcc.TabIndex = 5;
            this.txtParAcc.Tag = " T_GDDET.AccNo ";
            this.txtParAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txtPerSales);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.txtTaxNo);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.checkBoxX_Stoped);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtOpenAcc);
            this.groupBox2.Controls.Add(this.txtCreditLimit);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.CmbPosting);
            this.groupBox2.Controls.Add(this.CmbClass);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Location = new System.Drawing.Point(345, 157);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(426, 158);
            this.groupBox2.TabIndex = 212;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(8, 111);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(113, 18);
            this.label17.TabIndex = 1296;
            this.label17.Text = "النسبة من المبيعات";
            this.label17.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtPerSales
            // 
            this.txtPerSales.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtPerSales.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtPerSales.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtPerSales.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPerSales.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtPerSales.DisplayFormat = "0.00";
            this.txtPerSales.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtPerSales.Increment = 1D;
            this.txtPerSales.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtPerSales.Location = new System.Drawing.Point(28, 130);
            this.txtPerSales.MinValue = 0D;
            this.txtPerSales.Name = "txtPerSales";
            this.txtPerSales.ShowUpDown = true;
            this.txtPerSales.Size = new System.Drawing.Size(93, 20);
            this.txtPerSales.TabIndex = 1295;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(9, 133);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(18, 13);
            this.label18.TabIndex = 1297;
            this.label18.Text = "%";
            // 
            // txtTaxNo
            // 
            this.txtTaxNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtTaxNo.Location = new System.Drawing.Point(8, 52);
            this.txtTaxNo.MaxLength = 30;
            this.txtTaxNo.Name = "txtTaxNo";
            this.netResize1.SetResizeTextBoxMultiline(this.txtTaxNo, false);
            this.txtTaxNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTaxNo.Size = new System.Drawing.Size(148, 20);
            this.txtTaxNo.TabIndex = 1294;
            this.txtTaxNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(159, 56);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(75, 13);
            this.label16.TabIndex = 1293;
            this.label16.Text = "رقم ضريبـــي :";
            // 
            // checkBoxX_Stoped
            // 
            this.checkBoxX_Stoped.AutoSize = true;
            // 
            // 
            // 
            this.checkBoxX_Stoped.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX_Stoped.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.checkBoxX_Stoped.Location = new System.Drawing.Point(8, 21);
            this.checkBoxX_Stoped.Name = "checkBoxX_Stoped";
            this.checkBoxX_Stoped.Size = new System.Drawing.Size(107, 15);
            this.checkBoxX_Stoped.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX_Stoped.TabIndex = 1292;
            this.checkBoxX_Stoped.Text = "حظــر الحســــاب";
            this.checkBoxX_Stoped.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(22, 90);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 13);
            this.label15.TabIndex = 1291;
            this.label15.Text = "*";
            // 
            // txtOpenAcc
            // 
            this.txtOpenAcc.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtOpenAcc.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtOpenAcc.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtOpenAcc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOpenAcc.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtOpenAcc.DisplayFormat = "0.00";
            this.txtOpenAcc.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtOpenAcc.Increment = 1D;
            this.txtOpenAcc.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtOpenAcc.IsInputReadOnly = true;
            this.txtOpenAcc.Location = new System.Drawing.Point(55, 86);
            this.txtOpenAcc.Name = "txtOpenAcc";
            this.txtOpenAcc.Size = new System.Drawing.Size(101, 20);
            this.txtOpenAcc.TabIndex = 1030;
            this.txtOpenAcc.ValueChanged += new System.EventHandler(this.txtOpenAcc_ValueChanged);
            // 
            // txtCreditLimit
            // 
            this.txtCreditLimit.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtCreditLimit.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtCreditLimit.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtCreditLimit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCreditLimit.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtCreditLimit.DisplayFormat = "0.00";
            this.txtCreditLimit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtCreditLimit.Increment = 1D;
            this.txtCreditLimit.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtCreditLimit.Location = new System.Drawing.Point(123, 130);
            this.txtCreditLimit.MinValue = 0D;
            this.txtCreditLimit.Name = "txtCreditLimit";
            this.txtCreditLimit.ShowUpDown = true;
            this.txtCreditLimit.Size = new System.Drawing.Size(113, 20);
            this.txtCreditLimit.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(349, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 1028;
            this.label8.Text = "ترحيـــل إلى :";
            // 
            // CmbPosting
            // 
            this.CmbPosting.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbPosting.DisplayMember = "Text";
            this.CmbPosting.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbPosting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPosting.FormattingEnabled = true;
            this.CmbPosting.ItemHeight = 15;
            this.CmbPosting.Location = new System.Drawing.Point(244, 52);
            this.CmbPosting.Name = "CmbPosting";
            this.CmbPosting.Size = new System.Drawing.Size(102, 21);
            this.CmbPosting.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbPosting.TabIndex = 9;
            // 
            // CmbClass
            // 
            this.CmbClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbClass.DisplayMember = "Text";
            this.CmbClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbClass.FormattingEnabled = true;
            this.CmbClass.ItemHeight = 14;
            this.CmbClass.Location = new System.Drawing.Point(127, 19);
            this.CmbClass.Name = "CmbClass";
            this.CmbClass.Size = new System.Drawing.Size(219, 20);
            this.CmbClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbClass.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(349, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 1024;
            this.label3.Text = "التصنيــــــف :";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.checkBox_Credit);
            this.groupBox5.Controls.Add(this.checkBox_Debit);
            this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox5.ForeColor = System.Drawing.Color.DarkRed;
            this.groupBox5.Location = new System.Drawing.Point(244, 86);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox5.Size = new System.Drawing.Size(174, 66);
            this.groupBox5.TabIndex = 1023;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "نوع الحساب";
            // 
            // checkBox_Credit
            // 
            this.checkBox_Credit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_Credit.AutoSize = true;
            this.checkBox_Credit.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBox_Credit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_Credit.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBox_Credit.CheckSignSize = new System.Drawing.Size(14, 14);
            this.checkBox_Credit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.checkBox_Credit.Location = new System.Drawing.Point(11, 30);
            this.checkBox_Credit.Name = "checkBox_Credit";
            this.checkBox_Credit.Size = new System.Drawing.Size(52, 16);
            this.checkBox_Credit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_Credit.TabIndex = 11;
            this.checkBox_Credit.Text = "دائــن";
            // 
            // checkBox_Debit
            // 
            this.checkBox_Debit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_Debit.AutoSize = true;
            this.checkBox_Debit.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.checkBox_Debit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_Debit.BackgroundStyle.TextShadowColor = System.Drawing.SystemColors.ControlLight;
            this.checkBox_Debit.BackgroundStyle.TextShadowOffset = new System.Drawing.Point(3, 3);
            this.checkBox_Debit.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBox_Debit.Checked = true;
            this.checkBox_Debit.CheckSignSize = new System.Drawing.Size(14, 14);
            this.checkBox_Debit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Debit.CheckValue = "Y";
            this.checkBox_Debit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.checkBox_Debit.Location = new System.Drawing.Point(100, 30);
            this.checkBox_Debit.Name = "checkBox_Debit";
            this.checkBox_Debit.Size = new System.Drawing.Size(56, 16);
            this.checkBox_Debit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_Debit.TabIndex = 10;
            this.checkBox_Debit.Text = "مــدين";
            this.checkBox_Debit.CheckedChanged += new System.EventHandler(this.checkBox_Debit_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(159, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 1031;
            this.label9.Text = "رصيد إفتتاحي :";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(123, 111);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(113, 18);
            this.label14.TabIndex = 1029;
            this.label14.Text = "حد المديونيـــة";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtTDebit);
            this.groupBox3.Controls.Add(this.txtTCredit);
            this.groupBox3.Controls.Add(this.txtBalance);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(373, 314);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(397, 59);
            this.groupBox3.TabIndex = 213;
            this.groupBox3.TabStop = false;
            // 
            // txtTDebit
            // 
            this.txtTDebit.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtTDebit.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtTDebit.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTDebit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTDebit.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTDebit.DisplayFormat = "0.00";
            this.txtTDebit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtTDebit.Increment = 1D;
            this.txtTDebit.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTDebit.IsInputReadOnly = true;
            this.txtTDebit.Location = new System.Drawing.Point(276, 36);
            this.txtTDebit.Name = "txtTDebit";
            this.txtTDebit.Size = new System.Drawing.Size(116, 20);
            this.txtTDebit.TabIndex = 13;
            // 
            // txtTCredit
            // 
            this.txtTCredit.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtTCredit.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtTCredit.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTCredit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTCredit.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTCredit.DisplayFormat = "0.00";
            this.txtTCredit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtTCredit.Increment = 1D;
            this.txtTCredit.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTCredit.IsInputReadOnly = true;
            this.txtTCredit.Location = new System.Drawing.Point(158, 36);
            this.txtTCredit.Name = "txtTCredit";
            this.txtTCredit.Size = new System.Drawing.Size(116, 20);
            this.txtTCredit.TabIndex = 14;
            // 
            // txtBalance
            // 
            this.txtBalance.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtBalance.BackgroundStyle.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtBalance.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtBalance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBalance.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtBalance.DisplayFormat = "0.00";
            this.txtBalance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtBalance.Increment = 1D;
            this.txtBalance.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtBalance.IsInputReadOnly = true;
            this.txtBalance.Location = new System.Drawing.Point(5, 36);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(151, 20);
            this.txtBalance.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.Maroon;
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(5, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(151, 20);
            this.label13.TabIndex = 203;
            this.label13.Text = "الرصيد";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.Maroon;
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(276, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 20);
            this.label12.TabIndex = 202;
            this.label12.Text = "أجمالي المدين";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.Maroon;
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(158, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 20);
            this.label11.TabIndex = 201;
            this.label11.Text = "أجمالي الدائن";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonX_Expand
            // 
            this.buttonX_Expand.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Expand.Checked = true;
            this.buttonX_Expand.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.buttonX_Expand.Location = new System.Drawing.Point(345, 348);
            this.buttonX_Expand.Name = "buttonX_Expand";
            this.buttonX_Expand.Size = new System.Drawing.Size(26, 24);
            this.buttonX_Expand.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Expand.Symbol = "";
            this.buttonX_Expand.SymbolSize = 12F;
            this.buttonX_Expand.TabIndex = 1139;
            this.buttonX_Expand.TextColor = System.Drawing.Color.SteelBlue;
            this.buttonX_Expand.Tooltip = "فتح الكل";
            this.buttonX_Expand.Click += new System.EventHandler(this.buttonX_Expand_Click);
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.AlternateRowColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.treeView1.BackColor = System.Drawing.Color.AliceBlue;
            // 
            // 
            // 
            this.treeView1.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.treeView1.BackgroundStyle.BorderBottomWidth = 1;
            this.treeView1.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(65)))), ((int)(((byte)(66)))));
            this.treeView1.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.treeView1.BackgroundStyle.BorderLeftWidth = 1;
            this.treeView1.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.treeView1.BackgroundStyle.BorderRightWidth = 1;
            this.treeView1.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.treeView1.BackgroundStyle.BorderTopWidth = 1;
            this.treeView1.BackgroundStyle.Class = "TreeBorderKey";
            this.treeView1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.treeView1.ColumnsBackgroundStyle = this.elementStyle1;
            this.treeView1.ColumnsVisible = false;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.ExpandButtonSize = new System.Drawing.Size(22, 22);
            this.treeView1.ExpandButtonType = DevComponents.AdvTree.eExpandButtonType.Triangle;
            this.treeView1.ExpandWidth = 22;
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.treeView1.GridRowLines = true;
            this.treeView1.GroupNodeStyle = this.elementStyle1;
            this.treeView1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(5);
            this.treeView1.Name = "treeView1";
            this.treeView1.NodeHorizontalSpacing = 20;
            this.treeView1.NodeSpacing = 5;
            this.treeView1.NodeStyle = this.elementStyle1;
            this.treeView1.NodeStyleSelected = this.elementStyle17;
            this.treeView1.PathSeparator = ";";
            this.treeView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.treeView1.SelectionBoxStyle = DevComponents.AdvTree.eSelectionStyle.FullRowSelect;
            this.treeView1.Size = new System.Drawing.Size(343, 390);
            this.treeView1.Styles.Add(this.elementStyle1);
            this.treeView1.Styles.Add(this.elementStyle7);
            this.treeView1.Styles.Add(this.elementStyle8);
            this.treeView1.Styles.Add(this.elementStyle9);
            this.treeView1.Styles.Add(this.elementStyle10);
            this.treeView1.Styles.Add(this.elementStyle11);
            this.treeView1.Styles.Add(this.elementStyle12);
            this.treeView1.Styles.Add(this.elementStyle13);
            this.treeView1.Styles.Add(this.elementStyle14);
            this.treeView1.Styles.Add(this.elementStyle15);
            this.treeView1.Styles.Add(this.elementStyle16);
            this.treeView1.Styles.Add(this.elementStyle17);
            this.treeView1.Styles.Add(this.elementStyle18);
            this.treeView1.TabIndex = 1140;
            this.treeView1.Text = "advTree2";
            this.treeView1.NodeClick += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.treeView1_NodeClick);
            // 
            // elementStyle1
            // 
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.Color.SteelBlue;
            // 
            // elementStyle17
            // 
            this.elementStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(213)))));
            this.elementStyle17.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(105)))));
            this.elementStyle17.BackColorGradientAngle = 90;
            this.elementStyle17.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle17.BorderBottomWidth = 1;
            this.elementStyle17.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle17.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle17.BorderLeftWidth = 1;
            this.elementStyle17.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle17.BorderRightWidth = 1;
            this.elementStyle17.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle17.BorderTopWidth = 1;
            this.elementStyle17.CornerDiameter = 4;
            this.elementStyle17.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle17.Description = "Yellow";
            this.elementStyle17.Name = "elementStyle17";
            this.elementStyle17.PaddingBottom = 1;
            this.elementStyle17.PaddingLeft = 1;
            this.elementStyle17.PaddingRight = 1;
            this.elementStyle17.PaddingTop = 1;
            this.elementStyle17.TextColor = System.Drawing.Color.Black;
            // 
            // elementStyle7
            // 
            this.elementStyle7.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elementStyle7.Name = "elementStyle7";
            // 
            // elementStyle8
            // 
            this.elementStyle8.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle8.Name = "elementStyle8";
            // 
            // elementStyle9
            // 
            this.elementStyle9.BackColor = System.Drawing.Color.White;
            this.elementStyle9.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(228)))), ((int)(((byte)(240)))));
            this.elementStyle9.BackColorGradientAngle = 90;
            this.elementStyle9.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle9.BorderBottomWidth = 1;
            this.elementStyle9.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle9.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle9.BorderLeftWidth = 1;
            this.elementStyle9.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle9.BorderRightWidth = 1;
            this.elementStyle9.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle9.BorderTopWidth = 1;
            this.elementStyle9.CornerDiameter = 4;
            this.elementStyle9.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle9.Description = "Gray";
            this.elementStyle9.Name = "elementStyle9";
            this.elementStyle9.PaddingBottom = 1;
            this.elementStyle9.PaddingLeft = 1;
            this.elementStyle9.PaddingRight = 1;
            this.elementStyle9.PaddingTop = 1;
            this.elementStyle9.TextColor = System.Drawing.Color.Black;
            // 
            // elementStyle10
            // 
            this.elementStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(230)))), ((int)(((byte)(247)))));
            this.elementStyle10.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(228)))));
            this.elementStyle10.BackColorGradientAngle = 90;
            this.elementStyle10.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle10.BorderBottomWidth = 1;
            this.elementStyle10.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle10.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle10.BorderLeftWidth = 1;
            this.elementStyle10.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle10.BorderRightWidth = 1;
            this.elementStyle10.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle10.BorderTopWidth = 1;
            this.elementStyle10.CornerDiameter = 4;
            this.elementStyle10.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle10.Description = "Blue";
            this.elementStyle10.Name = "elementStyle10";
            this.elementStyle10.PaddingBottom = 1;
            this.elementStyle10.PaddingLeft = 1;
            this.elementStyle10.PaddingRight = 1;
            this.elementStyle10.PaddingTop = 1;
            this.elementStyle10.TextColor = System.Drawing.Color.Black;
            // 
            // elementStyle11
            // 
            this.elementStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(213)))));
            this.elementStyle11.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(216)))), ((int)(((byte)(105)))));
            this.elementStyle11.BackColorGradientAngle = 90;
            this.elementStyle11.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle11.BorderBottomWidth = 1;
            this.elementStyle11.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle11.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle11.BorderLeftWidth = 1;
            this.elementStyle11.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle11.BorderRightWidth = 1;
            this.elementStyle11.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle11.BorderTopWidth = 1;
            this.elementStyle11.CornerDiameter = 4;
            this.elementStyle11.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle11.Description = "Yellow";
            this.elementStyle11.Name = "elementStyle11";
            this.elementStyle11.PaddingBottom = 1;
            this.elementStyle11.PaddingLeft = 1;
            this.elementStyle11.PaddingRight = 1;
            this.elementStyle11.PaddingTop = 1;
            this.elementStyle11.TextColor = System.Drawing.Color.Black;
            // 
            // elementStyle12
            // 
            this.elementStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(240)))), ((int)(((byte)(226)))));
            this.elementStyle12.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            this.elementStyle12.BackColorGradientAngle = 90;
            this.elementStyle12.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle12.BorderBottomWidth = 1;
            this.elementStyle12.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle12.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle12.BorderLeftWidth = 1;
            this.elementStyle12.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle12.BorderRightWidth = 1;
            this.elementStyle12.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle12.BorderTopWidth = 1;
            this.elementStyle12.CornerDiameter = 4;
            this.elementStyle12.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle12.Description = "Green";
            this.elementStyle12.Name = "elementStyle12";
            this.elementStyle12.PaddingBottom = 1;
            this.elementStyle12.PaddingLeft = 1;
            this.elementStyle12.PaddingRight = 1;
            this.elementStyle12.PaddingTop = 1;
            this.elementStyle12.TextColor = System.Drawing.Color.Black;
            // 
            // elementStyle13
            // 
            this.elementStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(236)))), ((int)(((byte)(243)))));
            this.elementStyle13.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(187)))), ((int)(((byte)(210)))));
            this.elementStyle13.BackColorGradientAngle = 90;
            this.elementStyle13.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle13.BorderBottomWidth = 1;
            this.elementStyle13.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle13.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle13.BorderLeftWidth = 1;
            this.elementStyle13.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle13.BorderRightWidth = 1;
            this.elementStyle13.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle13.BorderTopWidth = 1;
            this.elementStyle13.CornerDiameter = 4;
            this.elementStyle13.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle13.Description = "Cyan";
            this.elementStyle13.Name = "elementStyle13";
            this.elementStyle13.PaddingBottom = 1;
            this.elementStyle13.PaddingLeft = 1;
            this.elementStyle13.PaddingRight = 1;
            this.elementStyle13.PaddingTop = 1;
            this.elementStyle13.TextColor = System.Drawing.Color.Black;
            // 
            // elementStyle14
            // 
            this.elementStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(242)))), ((int)(((byte)(226)))));
            this.elementStyle14.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(209)))), ((int)(((byte)(153)))));
            this.elementStyle14.BackColorGradientAngle = 90;
            this.elementStyle14.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle14.BorderBottomWidth = 1;
            this.elementStyle14.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle14.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle14.BorderLeftWidth = 1;
            this.elementStyle14.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle14.BorderRightWidth = 1;
            this.elementStyle14.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle14.BorderTopWidth = 1;
            this.elementStyle14.CornerDiameter = 4;
            this.elementStyle14.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle14.Description = "Tan";
            this.elementStyle14.Name = "elementStyle14";
            this.elementStyle14.PaddingBottom = 1;
            this.elementStyle14.PaddingLeft = 1;
            this.elementStyle14.PaddingRight = 1;
            this.elementStyle14.PaddingTop = 1;
            this.elementStyle14.TextColor = System.Drawing.Color.Black;
            // 
            // elementStyle15
            // 
            this.elementStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(229)))), ((int)(((byte)(236)))));
            this.elementStyle15.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(164)))), ((int)(((byte)(187)))));
            this.elementStyle15.BackColorGradientAngle = 90;
            this.elementStyle15.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle15.BorderBottomWidth = 1;
            this.elementStyle15.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle15.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle15.BorderLeftWidth = 1;
            this.elementStyle15.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle15.BorderRightWidth = 1;
            this.elementStyle15.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle15.BorderTopWidth = 1;
            this.elementStyle15.CornerDiameter = 4;
            this.elementStyle15.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle15.Description = "Magenta";
            this.elementStyle15.Name = "elementStyle15";
            this.elementStyle15.PaddingBottom = 1;
            this.elementStyle15.PaddingLeft = 1;
            this.elementStyle15.PaddingRight = 1;
            this.elementStyle15.PaddingTop = 1;
            this.elementStyle15.TextColor = System.Drawing.Color.Black;
            // 
            // elementStyle16
            // 
            this.elementStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(233)))), ((int)(((byte)(217)))));
            this.elementStyle16.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(176)))), ((int)(((byte)(120)))));
            this.elementStyle16.BackColorGradientAngle = 90;
            this.elementStyle16.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle16.BorderBottomWidth = 1;
            this.elementStyle16.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle16.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle16.BorderLeftWidth = 1;
            this.elementStyle16.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle16.BorderRightWidth = 1;
            this.elementStyle16.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle16.BorderTopWidth = 1;
            this.elementStyle16.CornerDiameter = 4;
            this.elementStyle16.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle16.Description = "Orange";
            this.elementStyle16.Name = "elementStyle16";
            this.elementStyle16.PaddingBottom = 1;
            this.elementStyle16.PaddingLeft = 1;
            this.elementStyle16.PaddingRight = 1;
            this.elementStyle16.PaddingTop = 1;
            this.elementStyle16.TextColor = System.Drawing.Color.Black;
            // 
            // elementStyle18
            // 
            this.elementStyle18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(229)))), ((int)(((byte)(236)))));
            this.elementStyle18.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(164)))), ((int)(((byte)(187)))));
            this.elementStyle18.BackColorGradientAngle = 90;
            this.elementStyle18.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle18.BorderBottomWidth = 1;
            this.elementStyle18.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle18.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle18.BorderLeftWidth = 1;
            this.elementStyle18.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle18.BorderRightWidth = 1;
            this.elementStyle18.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle18.BorderTopWidth = 1;
            this.elementStyle18.CornerDiameter = 4;
            this.elementStyle18.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle18.Description = "Magenta";
            this.elementStyle18.Name = "elementStyle18";
            this.elementStyle18.PaddingBottom = 1;
            this.elementStyle18.PaddingLeft = 1;
            this.elementStyle18.PaddingRight = 1;
            this.elementStyle18.PaddingTop = 1;
            this.elementStyle18.TextColor = System.Drawing.Color.Black;
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
            this.ribbonBar_Tasks.Location = new System.Drawing.Point(0, 407);
            this.ribbonBar_Tasks.Name = "ribbonBar_Tasks";
            this.ribbonBar_Tasks.Size = new System.Drawing.Size(773, 51);
            this.ribbonBar_Tasks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar_Tasks.TabIndex = 869;
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
            this.superTabControl_Main1.Size = new System.Drawing.Size(298, 51);
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
            this.superTabControl_Main2.Location = new System.Drawing.Point(298, 0);
            this.superTabControl_Main2.Name = "superTabControl_Main2";
            this.superTabControl_Main2.ReorderTabsEnabled = true;
            this.superTabControl_Main2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.superTabControl_Main2.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_Main2.SelectedTabIndex = -1;
            this.superTabControl_Main2.Size = new System.Drawing.Size(475, 51);
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
            // timer1
            // 
            this.timer1.Interval = 1000;
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
            this.superTabControl_DGV.Size = new System.Drawing.Size(773, 51);
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
            this.Button_PrintTable.Click += new System.EventHandler(this.Button_PrintTable_Click);
            // 
            // labelItem3
            // 
            this.labelItem3.Name = "labelItem3";
            this.labelItem3.Width = 40;
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
            background4.Color1 = System.Drawing.Color.SkyBlue;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background4;
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
            background5.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            baseTreeButtonVisualStyle2.Background = background5;
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
            this.DGV_Main.PrimaryGrid.UseAlternateRowStyle = true;
            this.DGV_Main.PrimaryGrid.Visible = false;
            this.DGV_Main.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DGV_Main.Size = new System.Drawing.Size(773, 0);
            this.DGV_Main.TabIndex = 872;
            this.DGV_Main.CellClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellClickEventArgs>(this.DGV_Main_CellClick);
            this.DGV_Main.CellDoubleClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellDoubleClickEventArgs>(this.DGV_Main_CellDoubleClick);
            this.DGV_Main.CellMouseDown += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellMouseEventArgs>(this.DGV_Main_CellMouseDown);
            this.DGV_Main.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DGV_Main_MouseDown);
            // 
            // panelEx3
            // 
            this.panelEx3.Controls.Add(this.DGV_Main);
            this.panelEx3.Controls.Add(this.ribbonBar_DGV);
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx3.Location = new System.Drawing.Point(0, 0);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(773, 0);
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
            this.ribbonBar_DGV.Size = new System.Drawing.Size(773, 51);
            this.ribbonBar_DGV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar_DGV.TabIndex = 873;
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
            // timerInfoBallon
            // 
            this.timerInfoBallon.Interval = 3000;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "*.rtf";
            this.saveFileDialog1.FileName = "doc1";
            this.saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf|All Files(*.*)|*.*";
            this.saveFileDialog1.FilterIndex = 2;
            this.saveFileDialog1.Title = "Save File";
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
            // ToolStripMenuItem_Det
            // 
            this.ToolStripMenuItem_Det.Name = "ToolStripMenuItem_Det";
            this.ToolStripMenuItem_Det.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem_Det.Text = "إظهار التفاصيل";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelEx3);
            this.panel1.Controls.Add(this.expandableSplitter1);
            this.panel1.Controls.Add(this.panelEx2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(773, 458);
            this.panel1.TabIndex = 906;
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
            this.expandableSplitter1.Location = new System.Drawing.Point(0, 0);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(773, 14);
            this.expandableSplitter1.TabIndex = 1;
            this.expandableSplitter1.TabStop = false;
            // 
            // panelEx2
            // 
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx2.Location = new System.Drawing.Point(0, 14);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(773, 444);
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
            // imageList_AccTree
            // 
            this.imageList_AccTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_AccTree.ImageStream")));
            this.imageList_AccTree.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_AccTree.Images.SetKeyName(0, "6.png");
            // 
            // ToolStripMenuItem_Rep
            // 
            this.ToolStripMenuItem_Rep.Checked = true;
            this.ToolStripMenuItem_Rep.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToolStripMenuItem_Rep.Name = "ToolStripMenuItem_Rep";
            this.ToolStripMenuItem_Rep.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem_Rep.Text = "إظهار التقرير";
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
            // barTopDockSite
            // 
            this.barTopDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barTopDockSite.Dock = System.Windows.Forms.DockStyle.Top;
            this.barTopDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barTopDockSite.Location = new System.Drawing.Point(0, 0);
            this.barTopDockSite.Name = "barTopDockSite";
            this.barTopDockSite.Size = new System.Drawing.Size(773, 0);
            this.barTopDockSite.TabIndex = 898;
            this.barTopDockSite.TabStop = false;
            // 
            // barLeftDockSite
            // 
            this.barLeftDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barLeftDockSite.Dock = System.Windows.Forms.DockStyle.Left;
            this.barLeftDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barLeftDockSite.Location = new System.Drawing.Point(0, 0);
            this.barLeftDockSite.Name = "barLeftDockSite";
            this.barLeftDockSite.Size = new System.Drawing.Size(0, 458);
            this.barLeftDockSite.TabIndex = 900;
            this.barLeftDockSite.TabStop = false;
            // 
            // barBottomDockSite
            // 
            this.barBottomDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barBottomDockSite.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barBottomDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barBottomDockSite.Location = new System.Drawing.Point(0, 458);
            this.barBottomDockSite.Name = "barBottomDockSite";
            this.barBottomDockSite.Size = new System.Drawing.Size(773, 0);
            this.barBottomDockSite.TabIndex = 899;
            this.barBottomDockSite.TabStop = false;
            // 
            // barRightDockSite
            // 
            this.barRightDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barRightDockSite.Dock = System.Windows.Forms.DockStyle.Right;
            this.barRightDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barRightDockSite.Location = new System.Drawing.Point(773, 0);
            this.barRightDockSite.Name = "barRightDockSite";
            this.barRightDockSite.Size = new System.Drawing.Size(0, 458);
            this.barRightDockSite.TabIndex = 901;
            this.barRightDockSite.TabStop = false;
            // 
            // dockSite4
            // 
            this.dockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite4.Location = new System.Drawing.Point(0, 458);
            this.dockSite4.Name = "dockSite4";
            this.dockSite4.Size = new System.Drawing.Size(773, 0);
            this.dockSite4.TabIndex = 905;
            this.dockSite4.TabStop = false;
            // 
            // dockSite1
            // 
            this.dockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite1.Location = new System.Drawing.Point(0, 0);
            this.dockSite1.Name = "dockSite1";
            this.dockSite1.Size = new System.Drawing.Size(0, 458);
            this.dockSite1.TabIndex = 902;
            this.dockSite1.TabStop = false;
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
            // dockSite2
            // 
            this.dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite2.Location = new System.Drawing.Point(773, 0);
            this.dockSite2.Name = "dockSite2";
            this.dockSite2.Size = new System.Drawing.Size(0, 458);
            this.dockSite2.TabIndex = 903;
            this.dockSite2.TabStop = false;
            // 
            // dockSite3
            // 
            this.dockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite3.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite3.Location = new System.Drawing.Point(0, 0);
            this.dockSite3.Name = "dockSite3";
            this.dockSite3.Size = new System.Drawing.Size(773, 0);
            this.dockSite3.TabIndex = 904;
            this.dockSite3.TabStop = false;
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
            // tabControl1
            // 
            this.tabControl1.AntiAlias = true;
            this.tabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.ColorScheme.TabBackground = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.tabControl1.ColorScheme.TabBackground2 = System.Drawing.Color.Empty;
            this.tabControl1.ColorScheme.TabItemBackgroundColorBlend.AddRange(new DevComponents.DotNetBar.BackgroundColorBlend[] {
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(230)))), ((int)(((byte)(249))))), 0F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(220)))), ((int)(((byte)(248))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(208)))), ((int)(((byte)(245))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(229)))), ((int)(((byte)(247))))), 1F)});
            this.tabControl1.ColorScheme.TabItemHotBackgroundColorBlend.AddRange(new DevComponents.DotNetBar.BackgroundColorBlend[] {
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(235))))), 0F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(168))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(218)))), ((int)(((byte)(89))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(141))))), 1F)});
            this.tabControl1.ColorScheme.TabItemSelectedBackgroundColorBlend.AddRange(new DevComponents.DotNetBar.BackgroundColorBlend[] {
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.White, 0F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254))))), 1F)});
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Controls.Add(this.tabControlPanel3);
            this.tabControl1.Controls.Add(this.tabControlPanel2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ForeColor = System.Drawing.Color.Black;
            this.tabControl1.Location = new System.Drawing.Point(4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(436, 280);
            this.tabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Dock;
            this.tabControl1.TabIndex = 4;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItem1);
            this.tabControl1.Tabs.Add(this.tabItem2);
            this.tabControl1.Tabs.Add(this.tabItem3);
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.advTree3);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(436, 254);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItem1;
            this.tabControlPanel1.UseCustomStyle = true;
            // 
            // advTree3
            // 
            this.advTree3.AllowDrop = true;
            this.advTree3.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTree3.BackgroundStyle.BackColor = System.Drawing.Color.White;
            this.advTree3.BackgroundStyle.BackColor2 = System.Drawing.Color.MintCream;
            this.advTree3.BackgroundStyle.BackColorGradientAngle = 90;
            this.advTree3.BackgroundStyle.Class = "TreeBorderKey";
            this.advTree3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTree3.Controls.Add(this.progressBarX1);
            this.advTree3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTree3.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.advTree3.Location = new System.Drawing.Point(1, 1);
            this.advTree3.Name = "advTree3";
            this.advTree3.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node4});
            this.advTree3.NodesConnector = this.nodeConnector1;
            this.advTree3.NodeStyle = this.elementStyle3;
            this.advTree3.PathSeparator = ";";
            this.advTree3.Size = new System.Drawing.Size(434, 252);
            this.advTree3.Styles.Add(this.elementStyle3);
            this.advTree3.Styles.Add(this.elementStyle4);
            this.advTree3.TabIndex = 0;
            // 
            // progressBarX1
            // 
            // 
            // 
            // 
            this.progressBarX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressBarX1.ColorTable = DevComponents.DotNetBar.eProgressBarItemColor.Paused;
            this.progressBarX1.Location = new System.Drawing.Point(58, 246);
            this.progressBarX1.Name = "progressBarX1";
            this.progressBarX1.Size = new System.Drawing.Size(140, 20);
            this.progressBarX1.TabIndex = 4;
            this.progressBarX1.Value = 63;
            // 
            // node4
            // 
            this.node4.Expanded = true;
            this.node4.ExpandVisibility = DevComponents.AdvTree.eNodeExpandVisibility.Hidden;
            this.node4.FullRowBackground = true;
            this.node4.Name = "node4";
            this.node4.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node15,
            this.node19,
            this.node23,
            this.node27,
            this.node29});
            this.node4.Selectable = false;
            this.node4.Style = this.elementStyle4;
            this.node4.Text = "<b>AdvTree</b> Control";
            // 
            // node15
            // 
            this.node15.Expanded = true;
            this.node15.Name = "node15";
            this.node15.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node17,
            this.node18});
            this.node15.Text = "Check-boxes";
            // 
            // node17
            // 
            this.node17.CheckBoxVisible = true;
            this.node17.Expanded = true;
            this.node17.Name = "node17";
            this.node17.Text = "Option 2";
            // 
            // node18
            // 
            this.node18.Cells.Add(this.cell17);
            this.node18.CheckBoxVisible = true;
            this.node18.Expanded = true;
            this.node18.Name = "node18";
            this.node18.Text = "Option 3";
            // 
            // cell17
            // 
            this.cell17.CheckBoxVisible = true;
            this.cell17.Name = "cell17";
            this.cell17.StyleMouseOver = null;
            this.cell17.Text = "Option 3";
            // 
            // node19
            // 
            this.node19.Expanded = true;
            this.node19.Name = "node19";
            this.node19.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node20,
            this.node21,
            this.node22});
            this.node19.Text = "Radio-buttons";
            // 
            // node20
            // 
            this.node20.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.node20.CheckBoxVisible = true;
            this.node20.Expanded = true;
            this.node20.Name = "node20";
            this.node20.Text = "Option 1";
            // 
            // node21
            // 
            this.node21.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.node21.CheckBoxVisible = true;
            this.node21.Expanded = true;
            this.node21.Name = "node21";
            this.node21.Text = "Option 2";
            // 
            // node22
            // 
            this.node22.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.node22.CheckBoxVisible = true;
            this.node22.Expanded = true;
            this.node22.Name = "node22";
            this.node22.Text = "Option 3";
            // 
            // node23
            // 
            this.node23.Expanded = true;
            this.node23.Name = "node23";
            this.node23.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node24,
            this.node25,
            this.node26});
            this.node23.Text = "Images";
            // 
            // node24
            // 
            this.node24.Cells.Add(this.cell18);
            this.node24.Expanded = true;
            this.node24.Name = "node24";
            this.node24.Text = "Multiple images per node";
            // 
            // cell18
            // 
            this.cell18.Name = "cell18";
            this.cell18.StyleMouseOver = null;
            // 
            // node25
            // 
            this.node25.Expanded = true;
            this.node25.ImageAlignment = DevComponents.AdvTree.eCellPartAlignment.FarCenter;
            this.node25.Name = "node25";
            this.node25.Text = "Image/text alignment";
            // 
            // node26
            // 
            this.node26.CellPartLayout = DevComponents.AdvTree.eCellPartLayout.Vertical;
            this.node26.Expanded = true;
            this.node26.ImageAlignment = DevComponents.AdvTree.eCellPartAlignment.CenterTop;
            this.node26.Name = "node26";
            this.node26.Text = "Orientation";
            // 
            // node27
            // 
            this.node27.Expanded = true;
            this.node27.Name = "node27";
            this.node27.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node28});
            this.node27.Text = "Text-markup support";
            // 
            // node28
            // 
            this.node28.Expanded = true;
            this.node28.Name = "node28";
            this.node28.Text = "DotNetBar <a href=\"textmarkup\">text-markup</a> is fully supported";
            // 
            // node29
            // 
            this.node29.Expanded = true;
            this.node29.Name = "node29";
            this.node29.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node30});
            this.node29.Text = "Windows Forms Control Hosting";
            // 
            // node30
            // 
            this.node30.Expanded = true;
            this.node30.HostedControl = this.progressBarX1;
            this.node30.Name = "node30";
            this.node30.Text = "Progress bar";
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
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "Advanced Features";
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Controls.Add(this.advTree5);
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel3.Size = new System.Drawing.Size(436, 254);
            this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel3.Style.GradientAngle = 90;
            this.tabControlPanel3.TabIndex = 3;
            this.tabControlPanel3.TabItem = this.tabItem3;
            // 
            // advTree5
            // 
            this.advTree5.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTree5.AllowDrop = true;
            this.advTree5.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTree5.BackgroundStyle.Class = "TreeBorderKey";
            this.advTree5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTree5.DisplayMembers = "CompanyName,ContactName,ContactTitle,Phone";
            this.advTree5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTree5.ExpandButtonType = DevComponents.AdvTree.eExpandButtonType.Triangle;
            this.advTree5.ExpandWidth = 14;
            this.advTree5.GroupingMembers = "Country";
            this.advTree5.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.advTree5.Location = new System.Drawing.Point(1, 1);
            this.advTree5.Name = "advTree5";
            this.advTree5.NodeStyle = this.elementStyle6;
            this.advTree5.PathSeparator = ";";
            this.advTree5.SelectionBoxStyle = DevComponents.AdvTree.eSelectionStyle.FullRowSelect;
            this.advTree5.Size = new System.Drawing.Size(434, 252);
            this.advTree5.Styles.Add(this.elementStyle6);
            this.advTree5.TabIndex = 0;
            this.advTree5.ValueMember = "CustomerId";
            // 
            // elementStyle6
            // 
            this.elementStyle6.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle6.Name = "elementStyle6";
            this.elementStyle6.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // tabItem3
            // 
            this.tabItem3.AttachedControl = this.tabControlPanel3;
            this.tabItem3.Name = "tabItem3";
            this.tabItem3.Text = "Data-Binding";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.advTree4);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(436, 254);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tabItem2;
            this.tabControlPanel2.UseCustomStyle = true;
            // 
            // advTree4
            // 
            this.advTree4.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTree4.AllowDrop = true;
            this.advTree4.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTree4.BackgroundStyle.Class = "TreeBorderKey";
            this.advTree4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTree4.Columns.Add(this.columnHeader7);
            this.advTree4.Columns.Add(this.columnHeader8);
            this.advTree4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTree4.ExpandButtonType = DevComponents.AdvTree.eExpandButtonType.Triangle;
            this.advTree4.GridColumnLines = false;
            this.advTree4.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.advTree4.Location = new System.Drawing.Point(1, 1);
            this.advTree4.Name = "advTree4";
            this.advTree4.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node31,
            this.node32,
            this.node33});
            this.advTree4.NodeStyle = this.elementStyle5;
            this.advTree4.PathSeparator = ";";
            this.advTree4.Size = new System.Drawing.Size(434, 252);
            this.advTree4.Styles.Add(this.elementStyle5);
            this.advTree4.TabIndex = 0;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Name = "columnHeader7";
            this.columnHeader7.Text = "Invoice Number";
            this.columnHeader7.Width.Absolute = 150;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Name = "columnHeader8";
            this.columnHeader8.Text = "Customer";
            this.columnHeader8.Width.Absolute = 276;
            // 
            // node31
            // 
            this.node31.Expanded = true;
            this.node31.Name = "node31";
            this.node31.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node38,
            this.node39});
            this.node31.Text = "102-290120";
            // 
            // node38
            // 
            this.node38.Cells.Add(this.cell28);
            this.node38.Cells.Add(this.cell29);
            this.node38.Expanded = true;
            this.node38.Name = "node38";
            this.node38.Text = "10";
            // 
            // cell28
            // 
            this.cell28.Name = "cell28";
            this.cell28.StyleMouseOver = null;
            this.cell28.Text = "Refurbished Rubber Band";
            // 
            // cell29
            // 
            this.cell29.Name = "cell29";
            this.cell29.StyleMouseOver = null;
            this.cell29.Text = "$10.00";
            // 
            // node39
            // 
            this.node39.Cells.Add(this.cell30);
            this.node39.Cells.Add(this.cell31);
            this.node39.Expanded = true;
            this.node39.Name = "node39";
            this.node39.Text = "1";
            // 
            // cell30
            // 
            this.cell30.Name = "cell30";
            this.cell30.StyleMouseOver = null;
            this.cell30.Text = "Toy Rocket Engine";
            // 
            // cell31
            // 
            this.cell31.Name = "cell31";
            this.cell31.StyleMouseOver = null;
            this.cell31.Text = "$50.00";
            // 
            // node32
            // 
            this.node32.Expanded = true;
            this.node32.Name = "node32";
            this.node32.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node34,
            this.node35,
            this.node36});
            this.node32.Text = "102-290122";
            // 
            // node34
            // 
            this.node34.Cells.Add(this.cell22);
            this.node34.Cells.Add(this.cell23);
            this.node34.Expanded = true;
            this.node34.Name = "node34";
            this.node34.Text = "1";
            // 
            // cell22
            // 
            this.cell22.Name = "cell22";
            this.cell22.StyleMouseOver = null;
            this.cell22.Text = "Giant Rubber Band (for tripping Road Runners)";
            // 
            // cell23
            // 
            this.cell23.Name = "cell23";
            this.cell23.StyleMouseOver = null;
            this.cell23.Text = "$349.00";
            // 
            // node35
            // 
            this.node35.Cells.Add(this.cell24);
            this.node35.Cells.Add(this.cell25);
            this.node35.Expanded = true;
            this.node35.Name = "node35";
            this.node35.Text = "1";
            // 
            // cell24
            // 
            this.cell24.Name = "cell24";
            this.cell24.StyleMouseOver = null;
            this.cell24.Text = "Acme Rocket Sled";
            // 
            // cell25
            // 
            this.cell25.Name = "cell25";
            this.cell25.StyleMouseOver = null;
            this.cell25.Text = "$982.00";
            // 
            // node36
            // 
            this.node36.Cells.Add(this.cell26);
            this.node36.Cells.Add(this.cell27);
            this.node36.Expanded = true;
            this.node36.Name = "node36";
            this.node36.Text = "1";
            // 
            // cell26
            // 
            this.cell26.Name = "cell26";
            this.cell26.StyleMouseOver = null;
            this.cell26.Text = "Bat-Man Outfit";
            // 
            // cell27
            // 
            this.cell27.Name = "cell27";
            this.cell27.StyleMouseOver = null;
            this.cell27.Text = "$99.00";
            // 
            // node33
            // 
            this.node33.Expanded = true;
            this.node33.Name = "node33";
            this.node33.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node37});
            this.node33.Text = "102-290123";
            // 
            // node37
            // 
            this.node37.Cells.Add(this.cell32);
            this.node37.Cells.Add(this.cell33);
            this.node37.Expanded = true;
            this.node37.Name = "node37";
            this.node37.Text = "1";
            // 
            // cell32
            // 
            this.cell32.Name = "cell32";
            this.cell32.StyleMouseOver = null;
            this.cell32.Text = "Black Silk Role 50m";
            // 
            // cell33
            // 
            this.cell33.Name = "cell33";
            this.cell33.StyleMouseOver = null;
            this.cell33.Text = "$115.99";
            // 
            // elementStyle5
            // 
            this.elementStyle5.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle5.Name = "elementStyle5";
            this.elementStyle5.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // tabItem2
            // 
            this.tabItem2.AttachedControl = this.tabControlPanel2;
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "Node Columns";
            // 
            // advTree2
            // 
            this.advTree2.AllowDrop = true;
            this.advTree2.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTree2.BackgroundStyle.Class = "TreeBorderKey";
            this.advTree2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTree2.Columns.Add(this.columnHeader4);
            this.advTree2.Columns.Add(this.columnHeader5);
            this.advTree2.Columns.Add(this.columnHeader6);
            this.advTree2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTree2.ExpandButtonType = DevComponents.AdvTree.eExpandButtonType.Triangle;
            this.advTree2.ExpandWidth = 14;
            this.advTree2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.advTree2.Location = new System.Drawing.Point(4, 4);
            this.advTree2.Name = "advTree2";
            this.advTree2.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node1});
            this.advTree2.NodeStyle = this.elementStyle2;
            this.advTree2.PathSeparator = ";";
            this.advTree2.SelectionBoxStyle = DevComponents.AdvTree.eSelectionStyle.FullRowSelect;
            this.advTree2.Size = new System.Drawing.Size(894, 242);
            this.advTree2.Styles.Add(this.elementStyle2);
            this.advTree2.Styles.Add(this.unreadEmailStyle);
            this.advTree2.TabIndex = 0;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Name = "columnHeader4";
            this.columnHeader4.Text = "From";
            this.columnHeader4.Width.Absolute = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Name = "columnHeader5";
            this.columnHeader5.Text = "Subject";
            this.columnHeader5.Width.Absolute = 512;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Name = "columnHeader6";
            this.columnHeader6.Text = "Received";
            this.columnHeader6.Width.Absolute = 150;
            // 
            // node1
            // 
            this.node1.Expanded = true;
            this.node1.Name = "node1";
            this.node1.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node2,
            this.node5,
            this.node6,
            this.node7});
            this.node1.Text = "Personal Folders";
            // 
            // node2
            // 
            this.node2.Name = "node2";
            this.node2.Text = "Deleted Items <font color=\"Red\"><b>(1)</b></font>";
            // 
            // node5
            // 
            this.node5.Expanded = true;
            this.node5.Name = "node5";
            this.node5.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node10,
            this.node8,
            this.node9,
            this.node11,
            this.node12,
            this.node13});
            this.node5.Text = "Inbox";
            // 
            // node10
            // 
            this.node10.Cells.Add(this.cell7);
            this.node10.Cells.Add(this.cell8);
            this.node10.Expanded = true;
            this.node10.Name = "node10";
            this.node10.Style = this.unreadEmailStyle;
            this.node10.Text = "NewEgg";
            // 
            // cell7
            // 
            this.cell7.Name = "cell7";
            this.cell7.StyleMouseOver = null;
            this.cell7.Text = "Free Shipping on Acer Notebook $549.99, and Don’t Miss Our Canon SD1100 Sweepstak" +
    "es!";
            // 
            // cell8
            // 
            this.cell8.Name = "cell8";
            this.cell8.StyleMouseOver = null;
            this.cell8.Text = "Thu 4/10/2008 6:38 AM";
            // 
            // unreadEmailStyle
            // 
            this.unreadEmailStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.unreadEmailStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unreadEmailStyle.Name = "unreadEmailStyle";
            // 
            // node8
            // 
            this.node8.Cells.Add(this.cell15);
            this.node8.Cells.Add(this.cell16);
            this.node8.Expanded = true;
            this.node8.Name = "node8";
            this.node8.Style = this.unreadEmailStyle;
            this.node8.Text = "Denis Basaric (DevComponents)";
            // 
            // cell15
            // 
            this.cell15.Name = "cell15";
            this.cell15.StyleMouseOver = null;
            this.cell15.Text = "DotNetBar for Windows Forms 7.3 Released";
            // 
            // cell16
            // 
            this.cell16.Name = "cell16";
            this.cell16.StyleMouseOver = null;
            this.cell16.Text = "Wed 4/30/2008 8:00 PM";
            // 
            // node9
            // 
            this.node9.Cells.Add(this.cell13);
            this.node9.Cells.Add(this.cell14);
            this.node9.Expanded = true;
            this.node9.Name = "node9";
            this.node9.Text = "GoDaddy.com";
            // 
            // cell13
            // 
            this.cell13.Name = "cell13";
            this.cell13.StyleMouseOver = null;
            this.cell13.Text = "Certified GoDaddy.com Renewal Notice";
            // 
            // cell14
            // 
            this.cell14.Name = "cell14";
            this.cell14.StyleMouseOver = null;
            this.cell14.Text = "Wed 4/2/2008 7:09 AM";
            // 
            // node11
            // 
            this.node11.Cells.Add(this.cell1);
            this.node11.Cells.Add(this.cell2);
            this.node11.Expanded = true;
            this.node11.Name = "node11";
            this.node11.Style = this.unreadEmailStyle;
            this.node11.Text = "DevComponents";
            // 
            // cell1
            // 
            this.cell1.Name = "cell1";
            this.cell1.StyleMouseOver = null;
            this.cell1.Text = "DotNetBar now includes advanced Tree control";
            // 
            // cell2
            // 
            this.cell2.Name = "cell2";
            this.cell2.StyleMouseOver = null;
            this.cell2.Text = "Fri 4/11/2008 11:45 AM";
            // 
            // node12
            // 
            this.node12.Cells.Add(this.cell3);
            this.node12.Cells.Add(this.cell4);
            this.node12.Expanded = true;
            this.node12.Name = "node12";
            this.node12.Text = "Autoblog";
            // 
            // cell3
            // 
            this.cell3.Name = "cell3";
            this.cell3.StyleMouseOver = null;
            this.cell3.Text = "VW brings back Golf GTI Pirelli in the UK";
            // 
            // cell4
            // 
            this.cell4.Name = "cell4";
            this.cell4.StyleMouseOver = null;
            this.cell4.Text = "Fri 4/10/2008 9:01 AM";
            // 
            // node13
            // 
            this.node13.Cells.Add(this.cell5);
            this.node13.Cells.Add(this.cell6);
            this.node13.Expanded = true;
            this.node13.Name = "node13";
            this.node13.Text = "Engadget";
            // 
            // cell5
            // 
            this.cell5.Name = "cell5";
            this.cell5.StyleMouseOver = null;
            this.cell5.Text = "Canon\'s Rebel XSi turns up in retail spy shot";
            // 
            // cell6
            // 
            this.cell6.Name = "cell6";
            this.cell6.StyleMouseOver = null;
            this.cell6.Text = "Fri 4/10/2008 9:01 AM";
            // 
            // node6
            // 
            this.node6.Expanded = true;
            this.node6.Name = "node6";
            this.node6.Nodes.AddRange(new DevComponents.AdvTree.Node[] {
            this.node14});
            this.node6.Text = "Junk E-mail";
            // 
            // node14
            // 
            this.node14.Cells.Add(this.cell9);
            this.node14.Cells.Add(this.cell10);
            this.node14.Expanded = true;
            this.node14.Name = "node14";
            this.node14.Text = "ZipZoomfly";
            // 
            // cell9
            // 
            this.cell9.Name = "cell9";
            this.cell9.StyleMouseOver = null;
            this.cell9.Text = "ZipZoomfly Your Luck is Here";
            // 
            // cell10
            // 
            this.cell10.Name = "cell10";
            this.cell10.StyleMouseOver = null;
            this.cell10.Text = "Tue 3/4/2008 1:38 PM";
            // 
            // node7
            // 
            this.node7.Expanded = true;
            this.node7.Name = "node7";
            this.node7.Text = "Outbox";
            // 
            // elementStyle2
            // 
            this.elementStyle2.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle2.Name = "elementStyle2";
            this.elementStyle2.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // netResize1
            // 
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            // 
            // FrmAccDef_
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 458);
            this.Controls.Add(this.PanelSpecialContainer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barTopDockSite);
            this.Controls.Add(this.barLeftDockSite);
            this.Controls.Add(this.barBottomDockSite);
            this.Controls.Add(this.barRightDockSite);
            this.Controls.Add(this.dockSite4);
            this.Controls.Add(this.dockSite1);
            this.Controls.Add(this.dockSite2);
            this.Controls.Add(this.dockSite3);
            this.Icon = global::InvAcc.Properties.Resources.favicon;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(779, 486);
            this.Name = "FrmAccDef_";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "كرت الحســــابات";
            this.Load += new System.EventHandler(this.FrmAccDef__Load);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmAccDef_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmAccDef_KeyPress);
            this.PanelSpecialContainer.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            this.ribbonBar1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPerSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOpenAcc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreditLimit)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTDebit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTCredit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeView1)).EndInit();
            this.ribbonBar_Tasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_DGV)).EndInit();
            this.panelEx3.ResumeLayout(false);
            this.ribbonBar_DGV.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advTree3)).EndInit();
            this.advTree3.ResumeLayout(false);
            this.tabControlPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advTree5)).EndInit();
            this.tabControlPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advTree4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advTree2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);
        }
        public void RefreshPKeys()
        {
            PKeys.Clear();
            Stock_DataDataContext db = new Stock_DataDataContext(VarGeneral.BranchCS);
            var qkeys = from item in db.T_AccDefs
                        orderby item.AccDef_No
                        select new
                        {
                            Code = item.AccDef_No + ""
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
            List<T_AccDef> list = db.FillAccDef_2(textBox_search.TextBox.Text).ToList();
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
        public void FillHDGV(IEnumerable<T_AccDef> new_data_enum)
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
            DGV_Main.PrimaryGrid.DataMember = "T_AccDef";
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
        public FrmAccDef_()
        {
            InitializeComponent();
            ADD_Controls();
            for (int i = 0; i < controls.Count; i++)
            {
                if (controls[i].GetType() != typeof(AdvTree))
                {
                    controls[i].Click += Button_Edit_Click;
                }
            }
            checkBoxX_Stoped.Click += Button_Edit_Click;
            DGV_Main.PrimaryGrid.RowHeaderWidth = 25;
            DGV_Main.PrimaryGrid.VirtualMode = true;
            DGV_Main.DataBindingComplete += DGV_Main_DataBindingComplete;
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
            Button_Search.Click += Button_Search_Click;
            Button_Delete.Click += Button_Delete_Click;
            Button_Save.Click += Button_Save_Click;
            TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
            DGV_Main.PrimaryGrid.CheckBoxes = false;
            DGV_Main.PrimaryGrid.ShowCheckBox = false;
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
            {
                txtCreditLimit.DisplayFormat = VarGeneral.DicemalMask;
                txtOpenAcc.DisplayFormat = VarGeneral.DicemalMask;
                txtTDebit.DisplayFormat = VarGeneral.DicemalMask;
                txtTCredit.DisplayFormat = VarGeneral.DicemalMask;
                txtBalance.DisplayFormat = VarGeneral.DicemalMask;
                txtPerSales.DisplayFormat = VarGeneral.DicemalMask;
            }
        }
        public void Button_First_Click(object sender, EventArgs e)
        {
            if (ContinueIfEditOrNew())
            {
                TextBox_Index.TextBox.Text = string.Concat(1);
                UpdateVcr();
                textBox_ID.Focus();
                superTabControl_Main1.Refresh();
            }
        }
        private void Button_Close_Click(object sender, EventArgs e)
        {
            Close();
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
                superTabControl_Main1.Refresh();
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
                superTabControl_Main1.Refresh();
            }
        }
        public void Button_Last_Click(object sender, EventArgs e)
        {
            if (ContinueIfEditOrNew())
            {
                TextBox_Index.TextBox.Text = Label_Count.Text;
                UpdateVcr();
                superTabControl_Main1.Refresh();
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
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmAccDef_));
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
            FillCombo();
            FillTree();
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
                Button_PrintTable.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "طباعة" : "عــرض");
                Button_PrintTable.Tooltip = "F5";
                Button_ExportTable2.Text = "تصدير";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "جميع السجلات";
                buttonX_Collaps.Tooltip = "طي الكل";
                buttonX_Expand.Tooltip = "فتح الكل";
                Text = "كرت الحسابات";
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
                buttonX_Collaps.Tooltip = "Collapse all";
                buttonX_Expand.Tooltip = "Expand All";
                label4.Text = "Account NO :";
                label5.Text = "Level :";
                label1.Text = "Account Arabic NAme:";
                label2.Text = "Account English Name:";
                label7.Text = "Main Account:";
                label3.Text = "Category :";
                checkBoxX_Stoped.Text = "Block Account:";
                label8.Text = "Transfer TO:";
                groupBox5.Text = "Account Type:";
                label16.Text = "Tax Acc:";
                checkBox_Debit.Text = "Debit";
                checkBox_Credit.Text = "Credit";
                label9.Text = "Open Account:";
                label12.Text = "Debit Total:";
                label11.Text = "Credit Total:";
                label13.Text = "Balance:";
                label14.Text = "Debit Limit:";
                label17.Text = "Sales%:";
                Text = "Card of accounts";
            }
        }
        private void FrmAccDef__Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmAccDef_));
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
                Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
                if (columns_Names_visible.Count == 0)
                {
                    columns_Names_visible.Add("AccDef_No", new ColumnDictinary("رقم الحساب", "Account No", ifDefault: true, ""));
                    columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الإسم عربي", "Arabic Name", ifDefault: true, ""));
                    columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الإسم إنجليزي", "English Name", ifDefault: true, ""));
                    columns_Names_visible.Add("Telphone1", new ColumnDictinary("هاتف 1", "Phone 1", ifDefault: true, ""));
                    columns_Names_visible.Add("Telphone2", new ColumnDictinary("هاتف 2", "Phone 2", ifDefault: false, ""));
                    columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: true, ""));
                    columns_Names_visible.Add("City", new ColumnDictinary("المدينة", "City", ifDefault: false, ""));
                    columns_Names_visible.Add("Adders", new ColumnDictinary("العنوان", "Address", ifDefault: true, ""));
                    columns_Names_visible.Add("TaxNo", new ColumnDictinary("الرقم الضريبي", "Tax No", ifDefault: false, ""));
                }
                else
                {
                    Clear();
                    textBox_ID.Text = "";
                    TextBox_Index.TextBox.Text = "";
                }
                RefreshPKeys();
                RibunButtons();
                FillCombo();
                FillTree();
                textBox_ID.Text = PKeys.FirstOrDefault();
                UpdateVcr();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void Button_ExportTable2_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcel.ExportToExcel(DGV_Main, "تقرير كرت الحسابات");
            }
            catch
            {
            }
        }
        private void TextBox_Search_ButtonCustomClick(object sender, EventArgs e)
        {
            textBox_search.Text = "";
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
            VarGeneral.SFrmTyp = "T_AccDef4";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                textBox_ID.Text = frm.SerachNo.ToString();
            }
        }
        private void DGV_Main_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            string dataMember = panel.DataMember;
            if (dataMember != null && dataMember == "T_AccDef")
            {
                PropHIOfferPanel(panel);
            }
            T2 = DateTime.Now.Ticks;
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
            panel.Columns["Arb_Des"].Width = 220;
            panel.Columns["Arb_Des"].Visible = columns_Names_visible["Arb_Des"].IfDefault;
            panel.Columns["Eng_Des"].Width = 220;
            panel.Columns["Eng_Des"].Visible = columns_Names_visible["Eng_Des"].IfDefault;
            panel.Columns["AccDef_No"].Width = 150;
            panel.Columns["AccDef_No"].Visible = columns_Names_visible["AccDef_No"].IfDefault;
            panel.Columns["Telphone1"].Width = 100;
            panel.Columns["Telphone1"].Visible = columns_Names_visible["Telphone1"].IfDefault;
            panel.Columns["Telphone2"].Width = 100;
            panel.Columns["Telphone2"].Visible = columns_Names_visible["Telphone2"].IfDefault;
            panel.Columns["Mobile"].Width = 100;
            panel.Columns["Mobile"].Visible = columns_Names_visible["Mobile"].IfDefault;
            panel.Columns["City"].Width = 150;
            panel.Columns["City"].Visible = columns_Names_visible["City"].IfDefault;
            panel.Columns["Adders"].Width = 180;
            panel.Columns["Adders"].Visible = columns_Names_visible["Adders"].IfDefault;
            panel.Columns["TaxNo"].Width = 180;
            panel.Columns["TaxNo"].Visible = columns_Names_visible["TaxNo"].IfDefault;
            panel.ReadOnly = true;
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
                    TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(data_this.AccDef_No ?? "") + 1);
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
            if (data_this == null || data_this.AccDef_No == 0.ToString() || !ifOkDelete)
            {
                return;
            }
            try
            {
                if (!string.IsNullOrEmpty(textBox_ID.Text))
                {
                    T_GdAuto _GdAuto = db.GdAutoStock();
                    if (_GdAuto != null && _GdAuto.GdAuto_Id != 0 && (_GdAuto.Acc0.ToString() == textBox_ID.Text || _GdAuto.Acc1.ToString() == textBox_ID.Text || _GdAuto.Acc2.ToString() == textBox_ID.Text || _GdAuto.Acc3.ToString() == textBox_ID.Text))
                    {
                        MessageBox.Show("عفوا\u064b ... لا يمكن حذف السجل لأنه حساب افتراضي \n Default >>> Can Not be DELETED", VarGeneral.ProdectNam);
                        return;
                    }
                }
            }
            catch
            {
            }
            try
            {
                List<T_GdAuto> q = db.T_GdAutos.Where((T_GdAuto t) => t.Acc0.ToString().StartsWith(textBox_ID.Text) || t.Acc1.ToString().StartsWith(textBox_ID.Text) || t.Acc2.ToString().StartsWith(textBox_ID.Text) || t.Acc3.ToString().StartsWith(textBox_ID.Text)).ToList();
                if (q.Count > 0)
                {
                    MessageBox.Show("عفوا\u064b ... لا يمكن حذف السجل لأنه حساب افتراضي \n Default >>> Can Not be DELETED", VarGeneral.ProdectNam);
                    return;
                }
            }
            catch
            {
            }
            T_GDDET returned = db.SelectAccDefNoByReturnNo(textBox_ID.Text.Trim());
            T_sertyp returnedServType = db.SelectSerTypeoByReturnNo(textBox_ID.Text.Trim());
            T_telmn returnedTelMn = db.SelectTelMnoByReturnNo(textBox_ID.Text.Trim());
            T_per returnedPer = db.SelectPerByReturnNo(textBox_ID.Text.Trim());
            T_SYSSETTING returnedTax = db.SelectSyssettingReturnNo(textBox_ID.Text.Trim());
            T_INVSETTING returnedTaxOption = db.SelectTaxOptionReturnNo(textBox_ID.Text.Trim());
            if (returned != null && returned.GDDET_ID != 0)
            {
                MessageBox.Show("عفوا\u064b ... لا يمكن حذف السجل لأنه مستخدم \n USED >>> Can Not be DELETED", VarGeneral.ProdectNam);
                return;
            }
            if (returnedServType != null && returnedServType.Serv_ID != 0)
            {
                MessageBox.Show("عفوا\u064b ... لا يمكن حذف السجل لأنه مستخدم \n USED >>> Can Not be DELETED", VarGeneral.ProdectNam);
                return;
            }
            if (returnedTelMn != null)
            {
                MessageBox.Show("عفوا\u064b ... لا يمكن حذف السجل لأنه مستخدم \n USED >>> Can Not be DELETED", VarGeneral.ProdectNam);
                return;
            }
            if (returnedTax != null && returnedTax.SYSSETTING_ID != 0)
            {
                MessageBox.Show("عفوا\u064b ... لا يمكن حذف السجل لأنه مستخدم \n USED >>> Can Not be DELETED", VarGeneral.ProdectNam);
                return;
            }
            if (returnedTaxOption != null && returnedTaxOption.InvSet_ID != 0)
            {
                MessageBox.Show("عفوا\u064b ... لا يمكن حذف السجل لأنه مستخدم \n USED >>> Can Not be DELETED", VarGeneral.ProdectNam);
                return;
            }
            if (returnedPer != null && returnedPer.perno != 0)
            {
                MessageBox.Show("عفوا\u064b ... لا يمكن حذف السجل لأنه مستخدم \n USED >>> Can Not be DELETED", VarGeneral.ProdectNam);
                return;
            }
            string c = "Select * from T_GDDET where AccNo LIKE '" + textBox_ID.Text.Trim() + "%'";
            List<T_GDDET> ListAcc = db.ExecuteQuery<T_GDDET>("Select * from T_GDDET where AccNo LIKE '" + textBox_ID.Text.Trim() + "%'", new object[0]).ToList();
            if (ListAcc.Count > 0)
            {
                MessageBox.Show("عفوا\u064b ... لا يمكن حذف السجل لأن هناك حسابات اخرى عليها قيود ومرتبطة بهذا الحساب \n Sorry ... can not delete the record because there are other accounts and the restrictions associated with this account", VarGeneral.ProdectNam);
                return;
            }
            if (VarGeneral.SSSLev == "E" || VarGeneral.SSSLev == "D")
            {
                T_Emp returned2 = db.SelectEmpAccDefNoByReturnNo(textBox_ID.Text.Trim());
                if (returned2 != null && !string.IsNullOrEmpty(returned2.Emp_ID))
                {
                    MessageBox.Show("عفوا\u064b ... لا يمكن حذف السجل لأنه مرتبط بموظف \n USED >>> Can Not be DELETED", VarGeneral.ProdectNam);
                    return;
                }
                T_Advance returned3 = db.SelectAdvanceAccDefNoByReturnNo(textBox_ID.Text.Trim());
                if (returned3 != null && !string.IsNullOrEmpty(returned3.Advances_ID))
                {
                    MessageBox.Show("عفوا\u064b ... لا يمكن حذف السجل لأنه مرتبط بسجل السلف \n USED >>> Can Not be DELETED", VarGeneral.ProdectNam);
                    return;
                }
            }
            data_this = db.StockAccDefWithOutBalance(DataThis.AccDef_No);
            try
            {
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [GuestAcc] = '' where [GuestAcc] = '" + textBox_ID.Text.Trim() + "'");
                    VarGeneral.Settings_Sys.GuestAcc = "";
                }
                catch
                {
                }
                try
                {
                    db.ExecuteCommand("Update [dbo].[T_SYSSETTING] Set [GuestBoxAcc] = '' where [GuestBoxAcc] = '" + textBox_ID.Text.Trim() + "'");
                    VarGeneral.Settings_Sys.GuestBoxAcc = "";
                }
                catch
                {
                }
                db.ExecuteCommand("delete from T_AccDef where AccDef_No LIKE '" + textBox_ID.Text.Trim() + "%'");
            }
            catch (SqlException)
            {
                data_this = db.StockAccDefWithOutBalance(DataThis.AccDef_No);
                return;
            }
            catch (Exception)
            {
                data_this = db.StockAccDefWithOutBalance(DataThis.AccDef_No);
                return;
            }
            Clear();
            RefreshPKeys();
            textBox_ID.Text = PKeys.LastOrDefault();
            FillTree();
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
                txtParAcc.Focus();
                State = FormState.New;
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
        public void Clear()
        {
            if (State == FormState.New)
            {
                return;
            }
            State = FormState.New;
            data_this = new T_AccDef();
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
            if (State == FormState.New)
            {
                txtAccLevel.ReadOnly = true;
                txtParLevel.ReadOnly = false;
                txtParName.ReadOnly = false;
            }
            else
            {
                txtAccLevel.ReadOnly = true;
                txtParLevel.ReadOnly = true;
                txtParName.ReadOnly = true;
            }
            checkBox_Debit.Checked = true;
            SetReadOnly = false;
        }
        private T_AccDef GetData()
        {
            data_this.TaxNo = txtTaxNo.Text;
            data_this.DepreciationPercent = txtPerSales.Value;
            data_this.Arb_Des = txtArbDes.Text;
            data_this.Eng_Des = txtEngDes.Text;
            data_this.AccDef_No = textBox_ID.Text;
            data_this.Lev = int.Parse(txtAccLevel.Text);
            data_this.ParAcc = txtParAcc.Text;
            if (CmbClass.SelectedValue != null && CmbClass.SelectedValue.ToString() != "0")
            {
                data_this.AccCat = int.Parse(CmbClass.SelectedValue.ToString());
            }
            else
            {
                data_this.AccCat = null;
            }
            if (checkBox_Debit.Checked)
            {
                data_this.DC = 0;
            }
            else
            {
                data_this.DC = 1;
            }
            data_this.Sts = CmbStat.SelectedIndex;
            double value = 0.0;
            try
            {
                if (double.TryParse(txtCreditLimit.Text, out value))
                {
                    data_this.MaxLemt = value;
                }
                else
                {
                    data_this.MaxLemt = 0.0;
                }
            }
            catch
            {
                data_this.MaxLemt = 0.0;
            }
            value = 0.0;
            try
            {
                if (double.TryParse(data_this.Credit.Value.ToString(), out value))
                {
                    data_this.Credit = value;
                }
                else
                {
                    data_this.Credit = 0.0;
                }
            }
            catch
            {
                data_this.Credit = 0.0;
            }
            value = 0.0;
            try
            {
                if (double.TryParse(data_this.Debit.Value.ToString(), out value))
                {
                    data_this.Debit = value;
                }
                else
                {
                    data_this.Debit = 0.0;
                }
            }
            catch
            {
                data_this.Debit = 0.0;
            }
            value = 0.0;
            try
            {
                if (double.TryParse(data_this.Balance.Value.ToString(), out value))
                {
                    data_this.Balance = value;
                }
                else
                {
                    data_this.Balance = 0.0;
                }
            }
            catch
            {
                data_this.Balance = 0.0;
            }
            data_this.Trn = CmbPosting.SelectedIndex;
            data_this.Typ = data_this.Typ;
            data_this.City = data_this.City;
            data_this.Email = data_this.Email;
            data_this.Telphone1 = data_this.Telphone1;
            data_this.Telphone2 = data_this.Telphone2;
            data_this.Fax = data_this.Fax;
            data_this.Mobile = data_this.Mobile;
            data_this.DesPers = data_this.DesPers;
            data_this.StrAm = data_this.StrAm;
            data_this.Adders = data_this.Adders;
            data_this.Mnd = data_this.Mnd;
            data_this.Price = data_this.Price;
            data_this.StopedState = checkBoxX_Stoped.Checked;
            if (State == FormState.New)
            {
                data_this.BankComm = 0.0;
                data_this.TotPoints = 0.0;
                data_this.MaxDisCust = 0.0;
                data_this.vColNum1 = 0.0;
                data_this.vColNum2 = 0.0;
                data_this.vColStr1 = "";
                data_this.vColStr2 = "";
                data_this.vColStr3 = "";
            }
            data_this.CompanyID = 1;
            return data_this;
        }
        public void SetData(T_AccDef value)
        {
            try
            {
                State = FormState.Saved;
                Button_Save.Enabled = false;
                button_SrchAccFrom.Enabled = false;
                txtAccDefId.Text = value.AccDef_ID.ToString();
                txtEngDes.Text = value.Eng_Des;
                txtArbDes.Text = value.Arb_Des;
                txtTaxNo.Text = value.TaxNo;
                txtPerSales.Value = value.DepreciationPercent.Value;
                textBox_ID.Text = value.AccDef_No;
                txtAccLevel.Text = value.Lev.ToString();
                txtParAcc.Text = value.ParAcc;
                txtBalance.Value = value.Balance.Value;
                txtTCredit.Value = value.Credit.Value;
                txtTDebit.Value = value.Debit.Value;
                try
                {
                    if (value.AccCat.HasValue)
                    {
                        CmbClass.SelectedValue = value.AccCat.ToString();
                    }
                    else
                    {
                        CmbClass.SelectedIndex = -1;
                    }
                }
                catch
                {
                    CmbClass.SelectedIndex = -1;
                }
                if (value.DC.HasValue)
                {
                    if (value.DC.Value == 0)
                    {
                        checkBox_Debit.Checked = true;
                    }
                    else
                    {
                        checkBox_Credit.Checked = true;
                    }
                }
                CmbStat.SelectedIndex = value.Sts.Value;
                if (value.MaxLemt.HasValue)
                {
                    txtCreditLimit.Value = value.MaxLemt.Value;
                }
                else
                {
                    txtCreditLimit.Value = 0.0;
                }
                try
                {
                    txtOpenAcc.Value = db.OpenAccDebit(value.AccDef_No) - Math.Abs(db.OpenAccCredit(value.AccDef_No));
                }
                catch
                {
                    txtOpenAcc.Value = 0.0;
                }
                CmbPosting.SelectedIndex = int.Parse(VarGeneral.TString.TEmpty(string.Concat(value.Trn)));
                if (value.ParAcc != "")
                {
                    List<string> _pky = pkeys;
                    try
                    {
                        if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 76) && _pky.Count > 0)
                        {
                            _pky = new List<string>();
                            _pky = db.ExecuteQuery<string>("Select AccDef_No from T_AccDef where Lev != 4 order by AccDef_No", new object[0]).ToList();
                        }
                    }
                    catch
                    {
                        _pky = pkeys;
                    }
                    for (int iiCnt = 0; iiCnt < _pky.Count; iiCnt++)
                    {
                        _AccDefBind = db.StockAccDefWithOutBalance(_pky[iiCnt]);
                        if (_AccDefBind.AccDef_No == value.ParAcc)
                        {
                            if (RightToLeft == RightToLeft.Yes)
                            {
                                txtParName.Text = _AccDefBind.Arb_Des;
                            }
                            else if (RightToLeft == RightToLeft.No)
                            {
                                txtParName.Text = _AccDefBind.Eng_Des;
                            }
                            txtParLevel.Text = _AccDefBind.Lev.ToString();
                            break;
                        }
                    }
                }
                else
                {
                    txtParName.Text = "";
                    txtParLevel.Text = "";
                }
                try
                {
                    checkBoxX_Stoped.Checked = value.StopedState.Value;
                }
                catch
                {
                    checkBoxX_Stoped.Checked = false;
                }
                Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SetData:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void FillTree()
        {
            treeView1.Nodes.Clear();
            List<string> _pky = pkeys;
            try
            {
                if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 76) && _pky.Count > 0)
                {
                    _pky = new List<string>();
                    _pky = db.ExecuteQuery<string>("Select AccDef_No from T_AccDef where Lev != 4 order by AccDef_No", new object[0]).ToList();
                }
            }
            catch
            {
                _pky = pkeys;
            }
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                List<Node> MainNodeList = new List<Node>();
                Node Child = new Node();
                for (int iiCnt = 0; iiCnt < _pky.Count; iiCnt++)
                {
                    _AccDef = db.StockAccDefWithOutBalance(_pky[iiCnt]);
                    string _ParAcc = _AccDef.ParAcc;
                    if (_ParAcc == "" || _ParAcc == null)
                    {
                        Node MainNode = new Node();
                        MainNode.Tag = _AccDef.AccDef_No;
                        MainNode.Text = _AccDef.Arb_Des;
                        MainNodeList.Add(MainNode);
                        continue;
                    }
                    Child = new Node();
                    Child.Tag = _AccDef.AccDef_No;
                    Child.Text = _AccDef.Arb_Des;
                    foreach (Node mainNode in MainNodeList)
                    {
                        if (mainNode.Tag.ToString()[0] == Child.Tag.ToString()[0])
                        {
                            FindParent(mainNode, _AccDef.ParAcc)?.Nodes.Add(Child);
                        }
                    }
                }
                foreach (Node node in MainNodeList)
                {
                    treeView1.Nodes.Add(node);
                }
            }
            else
            {
                List<Node> MainNodeList = new List<Node>();
                Node Child = new Node();
                for (int iiCnt = 0; iiCnt < _pky.Count; iiCnt++)
                {
                    _AccDef = db.StockAccDefWithOutBalance(_pky[iiCnt]);
                    string _ParAcc = _AccDef.ParAcc;
                    if (_ParAcc == "" || _ParAcc == null)
                    {
                        Node MainNode = new Node();
                        MainNode.Tag = _AccDef.AccDef_No;
                        MainNode.Text = _AccDef.Eng_Des;
                        MainNodeList.Add(MainNode);
                        continue;
                    }
                    Child = new Node();
                    Child.Tag = _AccDef.AccDef_No;
                    Child.Text = _AccDef.Eng_Des;
                    foreach (Node mainNode in MainNodeList)
                    {
                        if (mainNode.Tag.ToString()[0] == Child.Tag.ToString()[0])
                        {
                            FindParent(mainNode, _AccDef.ParAcc)?.Nodes.Add(Child);
                        }
                    }
                }
                foreach (Node node in MainNodeList)
                {
                    treeView1.Nodes.Add(node);
                }
            }
            try
            {
                treeView1.Nodes[0].Image = imageList_AccTree.Images[0];
                treeView1.Nodes[1].Image = imageList_AccTree.Images[0];
                treeView1.Nodes[2].Image = imageList_AccTree.Images[0];
                treeView1.Nodes[3].Image = imageList_AccTree.Images[0];
            }
            catch
            {
            }
        }
        private Node FindParent(Node node, string ParentNo)
        {
            if (node.Tag.ToString() == ParentNo)
            {
                return node;
            }
            if (node.Nodes.Count > 0)
            {
                foreach (Node childNode in node.Nodes)
                {
                    if (childNode.Tag.ToString() == ParentNo)
                    {
                        return childNode;
                    }
                }
                foreach (Node childNode in node.Nodes)
                {
                    if (childNode.Nodes.Count > 0)
                    {
                        Node found = FindParent(childNode, ParentNo);
                        if (found != null)
                        {
                            return found;
                        }
                    }
                }
                return null;
            }
            return null;
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
        private void FillCombo()
        {
            int _CmbIndex = CmbStat.SelectedIndex;
            CmbStat.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                CmbStat.Items.Add("شغال");
                CmbStat.Items.Add("موقوف");
            }
            else
            {
                CmbStat.Items.Add("On");
                CmbStat.Items.Add("Off");
            }
            CmbStat.SelectedIndex = _CmbIndex;
            _CmbIndex = CmbPosting.SelectedIndex;
            CmbPosting.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                CmbPosting.Items.Add("-----------");
                CmbPosting.Items.Add("متاجرة");
                CmbPosting.Items.Add("أرباح وخسائر");
                CmbPosting.Items.Add("الميزانية العمومية");
            }
            else
            {
                CmbPosting.Items.Add("-----------");
                CmbPosting.Items.Add("Trading");
                CmbPosting.Items.Add("Profits and Losses");
                CmbPosting.Items.Add("General Budget");
            }
            CmbPosting.SelectedIndex = _CmbIndex;
            _CmbIndex = CmbClass.SelectedIndex;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                List<T_AccCat> listAccCat = new List<T_AccCat>(db.T_AccCats.Select((T_AccCat item) => item).ToList());
                listAccCat.Insert(0, new T_AccCat());
                CmbClass.DataSource = listAccCat;
                CmbClass.DisplayMember = "Arb_Des";
                CmbClass.ValueMember = "AccCat_No";
                CmbClass.SelectedIndex = _CmbIndex;
            }
            else
            {
                List<T_AccCat> listAccCat = new List<T_AccCat>(db.T_AccCats.Select((T_AccCat item) => item).ToList());
                listAccCat.Insert(0, new T_AccCat());
                CmbClass.DataSource = listAccCat;
                CmbClass.DisplayMember = "Eng_Des";
                CmbClass.ValueMember = "AccCat_No";
                CmbClass.SelectedIndex = _CmbIndex;
            }
            CmbClass.SelectedIndex = _CmbIndex;
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
                T_AccDef newData = db.StockAccDef(no);
                if (newData == null || string.IsNullOrEmpty(newData.AccDef_No))
                {
                    if (!Button_Add.Visible || !Button_Add.Enabled)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
                    int indexA = PKeys.IndexOf(newData.AccDef_No ?? "");
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
        private void Button_Filter_Click(object sender, EventArgs e)
        {
            Fill_DGV_Main();
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
        private void ADD_Controls()
        {
            try
            {
                controls = new List<Control>();
                controls.Add(textBox_ID);
                codeControl = textBox_ID;
                controls.Add(txtAccDefId);
                controls.Add(txtAccLevel);
                controls.Add(txtArbDes);
                controls.Add(txtTaxNo);
                controls.Add(txtPerSales);
                controls.Add(txtBalance);
                controls.Add(txtCreditLimit);
                controls.Add(checkBoxX_Stoped);
                controls.Add(txtOpenAcc);
                controls.Add(txtEngDes);
                controls.Add(txtParAcc);
                controls.Add(txtParLevel);
                controls.Add(txtParName);
                controls.Add(txtTCredit);
                controls.Add(txtTDebit);
                controls.Add(checkBox_Credit);
                controls.Add(checkBox_Debit);
                controls.Add(CmbClass);
                controls.Add(CmbPosting);
                controls.Add(CmbStat);
                controls.Add(treeView1);
            }
            catch (SqlException)
            {
            }
        }
        private bool SaveData()
        {
            try
            {
                if (!Button_Save.Enabled)
                {
                    return false;
                }
                if (State == FormState.Edit && !CanEdit)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                if (State == FormState.New && !Button_Add.Enabled)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                textBox_ID.Focus();
                if (textBox_ID.Text == "" || txtArbDes.Text == "" || txtEngDes.Text == "")
                {
                    MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون رقم الحساب او إسم الحساب فارغا\u064c" : "Can not be a number or name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                try
                {
                    if (CmbClass.SelectedIndex <= 0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يجب تحديد التصنيف" : "You must select Category", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return false;
                    }
                }
                catch
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب تحديد التصنيف" : "You must select Category", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                if (CmbPosting.SelectedIndex > 0)
                {
                    if (textBox_ID.Text == "1" || textBox_ID.Text == "2")
                    {
                        if (CmbPosting.SelectedIndex != 3)
                        {
                            MessageBox.Show((LangArEn == 0) ? "يجب ان يكون جهة ترحيل هذا الحساب إلى : الميزانية العمومية" : "Must be hand carried over to this account: the balance sheet", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            CmbPosting.Focus();
                            return false;
                        }
                    }
                    else if (textBox_ID.Text == "3")
                    {
                        if (CmbPosting.SelectedIndex != 1)
                        {
                            MessageBox.Show((LangArEn == 0) ? "يجب ان يكون جهة ترحيل هذا الحساب إلى : المتاجرة" : "We must be hand carried over to this account: trading", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            CmbPosting.Focus();
                            return false;
                        }
                    }
                    else if (textBox_ID.Text == "4")
                    {
                        if (CmbPosting.SelectedIndex != 2)
                        {
                            MessageBox.Show((LangArEn == 0) ? "يجب ان يكون جهة ترحيل هذا الحساب إلى : الأرباح والخسائر" : "We must be hand carried over to this account: profit and loss", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            CmbPosting.Focus();
                            return false;
                        }
                    }
                    else if (textBox_ID.Text.Substring(0, 1) == "1" || textBox_ID.Text.Substring(0, 1) == "2")
                    {
                        if (CmbPosting.SelectedIndex != 3)
                        {
                            try
                            {
                                T_GdAuto _GdAuto = db.GdAutoStock();
                                if (_GdAuto == null || _GdAuto.GdAuto_Id == 0)
                                {
                                    MessageBox.Show((LangArEn == 0) ? "يجب ان يكون جهة ترحيل هذا الحساب إلى : الميزانية العمومية" : "Must be hand carried over to this account: the balance sheet", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    CmbPosting.Focus();
                                    return false;
                                }
                                if (!(_GdAuto.Acc2.ToString() == textBox_ID.Text) && !(_GdAuto.Acc3.ToString() == textBox_ID.Text))
                                {
                                    MessageBox.Show((LangArEn == 0) ? "يجب ان يكون جهة ترحيل هذا الحساب إلى : الميزانية العمومية" : "Must be hand carried over to this account: the balance sheet", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    CmbPosting.Focus();
                                    return false;
                                }
                                if (CmbPosting.SelectedIndex != 1)
                                {
                                    MessageBox.Show((LangArEn == 0) ? "يجب ان يكون جهة ترحيل هذا الحساب إلى : الميزانية العمومية" : "Must be hand carried over to this account: the balance sheet", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    CmbPosting.Focus();
                                    return false;
                                }
                            }
                            catch (Exception ex2)
                            {
                                MessageBox.Show(ex2.ToString());
                                MessageBox.Show((LangArEn == 0) ? "يجب ان يكون جهة ترحيل هذا الحساب إلى : الميزانية العمومية" : "Must be hand carried over to this account: the balance sheet", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                CmbPosting.Focus();
                                return false;
                            }
                        }
                    }
                    else if (textBox_ID.Text.Substring(0, 1) == "3")
                    {
                        if (CmbPosting.SelectedIndex != 1)
                        {
                            MessageBox.Show((LangArEn == 0) ? "يجب ان يكون جهة ترحيل هذا الحساب إلى : المتاجرة" : "We must be hand carried over to this account: trading", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            CmbPosting.Focus();
                            return false;
                        }
                    }
                    else if (textBox_ID.Text.Substring(0, 1) == "4" && CmbPosting.SelectedIndex != 2)
                    {
                        MessageBox.Show((LangArEn == 0) ? "يجب ان يكون جهة ترحيل هذا الحساب إلى : الأرباح والخسائر" : "We must be hand carried over to this account: profit and loss", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        CmbPosting.Focus();
                        return false;
                    }
                }
                GetData();
                if (State == FormState.New)
                {
                    data_this.MainSal = 0.0;
                    db.T_AccDefs.InsertOnSubmit(data_this);
                    db.SubmitChanges();
                }
                else
                {
                    try
                    {
                        T_per returnedPer = db.SelectPerByReturnNo(textBox_ID.Text.Trim());
                        if (returnedPer != null && returnedPer.perno != 0)
                        {
                            db.ExecuteCommand("update T_per set nm='" + data_this.Arb_Des + "' where Cust_no='" + textBox_ID.Text.Trim() + "'");
                        }
                    }
                    catch
                    {
                    }
                    db.Log = VarGeneral.DebugLog;
                    db.SubmitChanges(ConflictMode.ContinueOnConflict);
                }
                MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                RefreshPKeys();
                FillTree();
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
                return false;
            }
            return true;
        }
        private void txtArbDes_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("Arabic");
        }
        private void txtEngDes_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("English");
        }
        private void FrmAccDef_KeyDown(object sender, KeyEventArgs e)
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
        private void FrmAccDef_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void button_SrchAccFrom_Click(object sender, EventArgs e)
        {
            textBox_ID.TextChanged -= textBox_ID_TextChanged;
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
            VarGeneral.SFrmTyp = "T_AccDef5";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                _AccDefBind = db.StockAccDefWithOutBalance(frm.SerachNo);
                txtParAcc.Text = _AccDefBind.AccDef_No;
                txtParLevel.Text = _AccDefBind.Lev.ToString();
                txtParName.Text = _AccDefBind.Arb_Des;
                int Value = _AccDefBind.Lev.Value + 1;
                txtAccLevel.Text = string.Concat(Value);
                List<T_AccDef> listFilter = (from t in db.T_AccDefs
                                             where t.ParAcc == _AccDefBind.AccDef_No
                                             orderby t.AccDef_ID
                                             select t).ToList();
                if (listFilter.Count == 0)
                {
                    if (_AccDefBind.Lev == 3)
                    {
                        textBox_ID.Text = txtParAcc.Text + "001";
                    }
                    else if (_AccDefBind.Lev == 2)
                    {
                        textBox_ID.Text = txtParAcc.Text + "1";
                    }
                    else if (_AccDefBind.Lev == 1)
                    {
                        textBox_ID.Text = txtParAcc.Text + "01";
                    }
                }
                else
                {
                    _AccDefBind = listFilter[listFilter.Count - 1];
                    string _Zero = "";
                    for (int i = 0; i < _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Length && _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Substring(i, 1) == "0"; i++)
                    {
                        _Zero += _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Substring(i, 1);
                    }
                    Value = int.Parse(_AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length)) + 1;
                    if (!string.IsNullOrEmpty(_Zero))
                    {
                        textBox_ID.Text = _AccDefBind.ParAcc + _Zero + Value;
                    }
                    else
                    {
                        textBox_ID.Text = _AccDefBind.ParAcc + Value;
                    }
                }
                try
                {
                    if (txtParAcc.Text.Substring(0, 1) == "1" || txtParAcc.Text.Substring(0, 1) == "2")
                    {
                        CmbPosting.SelectedIndex = 3;
                    }
                    else if (txtParAcc.Text.Substring(0, 1) == "3")
                    {
                        CmbPosting.SelectedIndex = 1;
                    }
                    else
                    {
                        CmbPosting.SelectedIndex = 2;
                    }
                }
                catch
                {
                    CmbPosting.SelectedIndex = 0;
                }
            }
            textBox_ID.TextChanged += textBox_ID_TextChanged;
        }
        private void Button_Save_EnabledChanged(object sender, EventArgs e)
        {
            if (Button_Save.Enabled)
            {
                CmbClass.Enabled = true;
                CmbPosting.Enabled = true;
                CmbStat.Enabled = true;
                treeView1.Enabled = false;
            }
            else
            {
                CmbClass.Enabled = false;
                CmbPosting.Enabled = false;
                CmbStat.Enabled = false;
                treeView1.Enabled = true;
            }
        }
        private void textBox_ID_Click(object sender, EventArgs e)
        {
            textBox_ID.SelectAll();
        }
        private void buttonX_Expand_Click(object sender, EventArgs e)
        {
            if (treeView1.Enabled)
            {
                treeView1.ExpandAll();
            }
        }
        private void buttonX_Collaps_Click(object sender, EventArgs e)
        {
            if (treeView1.Enabled)
            {
                treeView1.CollapseAll();
            }
        }
        private void Button_PrintTable_Click(object sender, EventArgs e)
        {
            try
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_AccDef left join T_SYSSETTING on T_SYSSETTING.SYSSETTING_ID = T_AccDef.CompanyID ";
                string Fields = "";
                Fields = "  Str(T_AccDef.AccDef_ID) , T_AccDef.AccDef_No as No , T_AccDef.Arb_Des as NmA, T_AccDef.Eng_Des as NmE,T_SYSSETTING.LogImg ";
                _RepShow.Rule = " Order by T_AccDef.AccDef_No ";
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
                        VarGeneral.IsGeneralUsed = true;
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "RepGeneral";



                        frm.Tag = LangArEn;
                        frm.Repvalue = "RepGeneral";
                        VarGeneral.vTitle = ((LangArEn == 0) ? "كرت الحسابات" : "Chart of Accounts");
                        frm.TopMost = true;
                        frm.ShowDialog();
                        VarGeneral.IsGeneralUsed = false;

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
        private void treeView1_NodeClick(object sender, TreeNodeMouseEventArgs e)
        {
            try
            {
                if (!ContinueIfEditOrNew())
                {
                    return;
                }
                List<string> _pky = pkeys;
                try
                {
                    if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 76) && _pky.Count > 0)
                    {
                        _pky = new List<string>();
                        _pky = db.ExecuteQuery<string>("Select AccDef_No from T_AccDef where Lev != 4 order by AccDef_No", new object[0]).ToList();
                    }
                }
                catch
                {
                    _pky = pkeys;
                }
                string SelectedValue = e.Node.Tag.ToString();
                for (int iiCnt = 0; iiCnt < _pky.Count; iiCnt++)
                {
                    _AccDef = db.StockAccDef(_pky[iiCnt]);
                    string _AccNo = _AccDef.AccDef_No;
                    if (SelectedValue == _AccNo)
                    {
                        SetData(_AccDef);
                        break;
                    }
                }
            }
            catch
            {
            }
        }
        private void txtOpenAcc_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBalance.Value > 0.0)
                {
                    label15.Text = ((LangArEn == 0) ? "مدين" : "Debit");
                }
                else if (txtBalance.Value < 0.0)
                {
                    label15.Text = ((LangArEn == 0) ? "دائـن" : "Credit");
                }
                else
                {
                    label15.Text = "";
                }
            }
            catch
            {
                label15.Text = "";
            }
        }
        private void checkBox_Debit_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void label13_Click(object sender, EventArgs e)
        {
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }
    }
}
