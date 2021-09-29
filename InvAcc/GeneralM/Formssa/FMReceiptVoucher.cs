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
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FMReceiptVoucher : Form
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
                        frm.Repvalue = "RepGaidCatch";

                        frm.Repvalue = "RepGaidCatch";
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
        protected ToolStripMenuItem ToolStripMenuItem_Rep;
        private ExpandableSplitter expandableSplitter1;
        private PanelEx panelEx2;
        private RibbonBar ribbonBar1;
        private TextBox txtChequeNo;
        private Label label5;
        internal Label label3;
        private TextBox txtAccName;
        private Label label6;
        internal PrintPreviewDialog prnt_prev;
        private PrintDocument prnt_doc;
        protected ContextMenuStrip contextMenuStrip2;
        protected ToolStripMenuItem ToolStripMenuItem_Det;
        private DockSite dockSite1;
        private SaveFileDialog saveFileDialog1;
        protected ContextMenuStrip contextMenuStrip1;
        private Panel panel1;
        private PanelEx panelEx3;
        private DockSite dockSite4;
        private DockSite dockSite3;
        private DockSite barTopDockSite;
        private DockSite barBottomDockSite;
        private DockSite barLeftDockSite;
        private DockSite barRightDockSite;
        private DockSite dockSite2;
        private OpenFileDialog openFileDialog1;
        private Timer timerInfoBallon;
        private Timer timer1;
        private ImageList imageList1;
        public DotNetBarManager dotNetBarManager1;
        private RibbonBar ribbonBar_Tasks;
        private SuperTabControl superTabControl_Main1;
        protected ButtonItem Button_Close;
        protected ButtonItem buttonItem_Print;
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
        protected ButtonItem Button_ExportTable2;
        protected LabelItem labelItem3;
        private DoubleInput txtTotalCredit;
        private DoubleInput txtTotalDebit;
        private DoubleInput txtBalance;
        internal Label label10;
        internal Label label17;
        internal Label Label21;
        internal Label label19;
        internal Label label18;
        internal Label label15;
        internal Label label7;
        internal Label Label2;
        internal Label Label1;
        private ButtonX button_SrchAccNo;
        internal Label label4;
        private Label label8;
        private TextBox txtReceivedForm;
        private ComboBoxEx CmbCostC;
        private ComboBoxEx CmbCurr;
        private ComboBoxEx CmbLegate;
        internal TextBox txtRef;
        internal TextBox textBox_ID;
        private LabelItem lable_Records;
        private MaskedTextBox txtGDate;
        private MaskedTextBox txtHDate;
        protected ButtonItem Button_PrintTable;
        private SwitchButton switchButton_Lock;
        internal Label label_LockeName;
        internal TextBox txtGedDesE;
        internal Label label9;
        internal TextBox txtGedDes;
        internal Label label11;
        private C1FlexGrid c1FlexGrid1;
        protected ButtonItem button_Repetition;
        private ButtonX button_SrchInvNo;
        internal Label label12;
        public TextBox txtAccNameR;
        public TextBox txtAccNo;
        public TextBox txtInvType;
        public TextBox txtInvNo;
        private TextBox txtFatherAccName;
        private ButtonX button_SrchMndob;
        private ButtonX button_SrchCostCenter;
        protected ButtonItem Button_PrintTableMulti;
        public static int LangArEn = 0;
        private ScriptNumber ScriptNumber1 = new ScriptNumber();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        public Dictionary<string, string> columns_Nams_Sums = new Dictionary<string, string>();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
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
        private T_SYSSETTING _SysSetting = new T_SYSSETTING();
        private List<T_SYSSETTING> listSysSetting = new List<T_SYSSETTING>();
        private T_AccDef _AccDef = new T_AccDef();
        private List<T_AccDef> listAccDef = new List<T_AccDef>();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
        private T_GDHEAD data_this;
        private T_STKSQTY data_this_stkQ;
        private List<T_GDDET> LData_This;
        private long T1;
        private long T2;
        private Stock_DataDataContext dbInstance;
        private int indColumn = 0;
        private string cellValue;
        private bool ifAcc1F = false;
        private bool ifAcc2F = false;
        private bool ifAccCF = false;
        private T_AccDef _AccFather = new T_AccDef();
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
        public double TotRequest = 0.0;
        private int iiRntP = 0;
        private int _page = 1;
        private bool RepetitionSts = false;
        private bool ReverseSts = false;
        private ButtonItem printersettings;
        private bool ifMultiPrint = false;
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
                button_Repetition.Visible = value;
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
        public T_GDHEAD DataThis
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
        public List<T_GDDET> LDataThis
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
                }
                else
                {
                    switchButton_Lock.Visible = true;
                }
                if (State == FormState.Saved)
                {
                    button_Repetition.Enabled = true;
                    Button_PrintTableMulti.Enabled = true;
                }
                else
                {
                    button_Repetition.Enabled = false;
                    Button_PrintTableMulti.Enabled = false;
                }
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
                if (value == null || !(value.UsrNo != ""))
                {
                    return;
                }
                permission = value;
                if (!VarGeneral.TString.ChkStatShow(value.SndStr, 13))
                {
                    IfAdd = false;
                }
                else
                {
                    IfAdd = true;
                }
                if (!VarGeneral.TString.ChkStatShow(value.SndStr, 14) || switchButton_Lock.Value)
                {
                    CanEdit = false;
                }
                else
                {
                    CanEdit = true;
                }
                if (!VarGeneral.TString.ChkStatShow(value.SndStr, 15) || switchButton_Lock.Value)
                {
                    IfDelete = false;
                }
                else
                {
                    IfDelete = true;
                }
                if (!VarGeneral.TString.ChkStatShow(Permmission.RepInv1, 0))
                {
                    switchButton_Lock.IsReadOnly = true;
                }
                else
                {
                    try
                    {
                        if (data_this == null || string.IsNullOrEmpty(data_this.gdNo))
                        {
                            switchButton_Lock.IsReadOnly = false;
                        }
                        else if (!string.IsNullOrEmpty(data_this.MODIFIED_BY))
                        {
                            if (VarGeneral.UserNumber.Trim() != data_this.MODIFIED_BY.Trim() && switchButton_Lock.Value && State != FormState.Edit)
                            {
                                switchButton_Lock.IsReadOnly = true;
                            }
                            else
                            {
                                switchButton_Lock.IsReadOnly = false;
                            }
                        }
                        else
                        {
                            switchButton_Lock.IsReadOnly = false;
                        }
                    }
                    catch
                    {
                        switchButton_Lock.IsReadOnly = false;
                    }
                }
                if (State != FormState.New)
                {
                    switchButton_Lock.Visible = true;
                }
                if (VarGeneral.vDemo)
                {
                    IfDelete = false;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMReceiptVoucher));
            DevComponents.DotNetBar.SuperGrid.Style.Background background5 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background6 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background7 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor3 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor4 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle3 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle4 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.Background background8 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.button_SrchCostCenter = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchMndob = new DevComponents.DotNetBar.ButtonX();
            this.txtFatherAccName = new System.Windows.Forms.TextBox();
            this.txtInvType = new System.Windows.Forms.TextBox();
            this.button_SrchInvNo = new DevComponents.DotNetBar.ButtonX();
            this.txtInvNo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.c1FlexGrid1 = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.txtGedDesE = new System.Windows.Forms.TextBox();
            this.txtGedDes = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label_LockeName = new System.Windows.Forms.Label();
            this.switchButton_Lock = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.txtGDate = new System.Windows.Forms.MaskedTextBox();
            this.txtHDate = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtAccNameR = new System.Windows.Forms.TextBox();
            this.button_SrchAccNo = new DevComponents.DotNetBar.ButtonX();
            this.txtAccNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtReceivedForm = new System.Windows.Forms.TextBox();
            this.CmbCostC = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.CmbCurr = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.CmbLegate = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtRef = new System.Windows.Forms.TextBox();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.txtTotalCredit = new DevComponents.Editors.DoubleInput();
            this.txtTotalDebit = new DevComponents.Editors.DoubleInput();
            this.txtBalance = new DevComponents.Editors.DoubleInput();
            this.label10 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.Label21 = new System.Windows.Forms.Label();
            this.txtChequeNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAccName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ribbonBar_Tasks = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl_Main1 = new DevComponents.DotNetBar.SuperTabControl();
            this.button_Repetition = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Close = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem_Print = new DevComponents.DotNetBar.ButtonItem();
            this.printersettings = new DevComponents.DotNetBar.ButtonItem();
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
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.prnt_prev = new System.Windows.Forms.PrintPreviewDialog();
            this.prnt_doc = new System.Drawing.Printing.PrintDocument();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_Det = new System.Windows.Forms.ToolStripMenuItem();
            this.dockSite1 = new DevComponents.DotNetBar.DockSite();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.DGV_Main = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.ribbonBar_DGV = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl_DGV = new DevComponents.DotNetBar.SuperTabControl();
            this.textBox_search = new DevComponents.DotNetBar.TextBoxItem();
            this.Button_ExportTable2 = new DevComponents.DotNetBar.ButtonItem();
            this.Button_PrintTable = new DevComponents.DotNetBar.ButtonItem();
            this.Button_PrintTableMulti = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem3 = new DevComponents.DotNetBar.LabelItem();
            this.dockSite4 = new DevComponents.DotNetBar.DockSite();
            this.dockSite3 = new DevComponents.DotNetBar.DockSite();
            this.barTopDockSite = new DevComponents.DotNetBar.DockSite();
            this.barBottomDockSite = new DevComponents.DotNetBar.DockSite();
            this.barLeftDockSite = new DevComponents.DotNetBar.DockSite();
            this.barRightDockSite = new DevComponents.DotNetBar.DockSite();
            this.dockSite2 = new DevComponents.DotNetBar.DockSite();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timerInfoBallon = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dotNetBarManager1 = new DevComponents.DotNetBar.DotNetBarManager(this.components);
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.PanelSpecialContainer.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalCredit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDebit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBalance)).BeginInit();
            this.ribbonBar_Tasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main2)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelEx3.SuspendLayout();
            this.ribbonBar_DGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_DGV)).BeginInit();
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
            this.PanelSpecialContainer.Size = new System.Drawing.Size(786, 397);
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
            this.ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.Gainsboro;
            this.ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.Color.Gainsboro;
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.button_SrchCostCenter);
            this.ribbonBar1.Controls.Add(this.button_SrchMndob);
            this.ribbonBar1.Controls.Add(this.txtFatherAccName);
            this.ribbonBar1.Controls.Add(this.txtInvType);
            this.ribbonBar1.Controls.Add(this.button_SrchInvNo);
            this.ribbonBar1.Controls.Add(this.txtInvNo);
            this.ribbonBar1.Controls.Add(this.label12);
            this.ribbonBar1.Controls.Add(this.c1FlexGrid1);
            this.ribbonBar1.Controls.Add(this.txtGedDesE);
            this.ribbonBar1.Controls.Add(this.txtGedDes);
            this.ribbonBar1.Controls.Add(this.label9);
            this.ribbonBar1.Controls.Add(this.label11);
            this.ribbonBar1.Controls.Add(this.label_LockeName);
            this.ribbonBar1.Controls.Add(this.switchButton_Lock);
            this.ribbonBar1.Controls.Add(this.txtGDate);
            this.ribbonBar1.Controls.Add(this.txtHDate);
            this.ribbonBar1.Controls.Add(this.label7);
            this.ribbonBar1.Controls.Add(this.Label2);
            this.ribbonBar1.Controls.Add(this.Label1);
            this.ribbonBar1.Controls.Add(this.txtAccNameR);
            this.ribbonBar1.Controls.Add(this.button_SrchAccNo);
            this.ribbonBar1.Controls.Add(this.txtAccNo);
            this.ribbonBar1.Controls.Add(this.label8);
            this.ribbonBar1.Controls.Add(this.txtReceivedForm);
            this.ribbonBar1.Controls.Add(this.CmbCostC);
            this.ribbonBar1.Controls.Add(this.CmbCurr);
            this.ribbonBar1.Controls.Add(this.CmbLegate);
            this.ribbonBar1.Controls.Add(this.txtRef);
            this.ribbonBar1.Controls.Add(this.textBox_ID);
            this.ribbonBar1.Controls.Add(this.txtTotalCredit);
            this.ribbonBar1.Controls.Add(this.txtTotalDebit);
            this.ribbonBar1.Controls.Add(this.txtBalance);
            this.ribbonBar1.Controls.Add(this.label10);
            this.ribbonBar1.Controls.Add(this.label17);
            this.ribbonBar1.Controls.Add(this.Label21);
            this.ribbonBar1.Controls.Add(this.txtChequeNo);
            this.ribbonBar1.Controls.Add(this.label5);
            this.ribbonBar1.Controls.Add(this.label3);
            this.ribbonBar1.Controls.Add(this.txtAccName);
            this.ribbonBar1.Controls.Add(this.label6);
            this.ribbonBar1.Controls.Add(this.label19);
            this.ribbonBar1.Controls.Add(this.label18);
            this.ribbonBar1.Controls.Add(this.label15);
            this.ribbonBar1.Controls.Add(this.label4);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(786, 346);
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
            // button_SrchCostCenter
            // 
            this.button_SrchCostCenter.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchCostCenter.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCostCenter.Location = new System.Drawing.Point(142, 38);
            this.button_SrchCostCenter.Name = "button_SrchCostCenter";
            this.button_SrchCostCenter.Size = new System.Drawing.Size(26, 20);
            this.button_SrchCostCenter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCostCenter.Symbol = "";
            this.button_SrchCostCenter.SymbolSize = 12F;
            this.button_SrchCostCenter.TabIndex = 1134;
            this.button_SrchCostCenter.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCostCenter.Click += new System.EventHandler(this.button_SrchCostCenter_Click);
            // 
            // button_SrchMndob
            // 
            this.button_SrchMndob.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchMndob.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchMndob.Location = new System.Drawing.Point(6, 62);
            this.button_SrchMndob.Name = "button_SrchMndob";
            this.button_SrchMndob.Size = new System.Drawing.Size(26, 20);
            this.button_SrchMndob.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchMndob.Symbol = "";
            this.button_SrchMndob.SymbolSize = 12F;
            this.button_SrchMndob.TabIndex = 1133;
            this.button_SrchMndob.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchMndob.Click += new System.EventHandler(this.button_SrchMndob_Click);
            // 
            // txtFatherAccName
            // 
            this.txtFatherAccName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(217)))), ((int)(((byte)(243)))));
            this.txtFatherAccName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFatherAccName.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtFatherAccName.ForeColor = System.Drawing.Color.DimGray;
            this.txtFatherAccName.Location = new System.Drawing.Point(6, 253);
            this.txtFatherAccName.Name = "txtFatherAccName";
            this.txtFatherAccName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtFatherAccName, false);
            this.txtFatherAccName.Size = new System.Drawing.Size(772, 13);
            this.txtFatherAccName.TabIndex = 1132;
            // 
            // txtInvType
            // 
            this.txtInvType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtInvType.ForeColor = System.Drawing.Color.DimGray;
            this.txtInvType.Location = new System.Drawing.Point(142, 14);
            this.txtInvType.MaxLength = 30;
            this.txtInvType.Name = "txtInvType";
            this.txtInvType.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtInvType, false);
            this.txtInvType.Size = new System.Drawing.Size(127, 20);
            this.txtInvType.TabIndex = 1130;
            this.txtInvType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_SrchInvNo
            // 
            this.button_SrchInvNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchInvNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchInvNo.Location = new System.Drawing.Point(272, 13);
            this.button_SrchInvNo.Name = "button_SrchInvNo";
            this.button_SrchInvNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchInvNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchInvNo.Symbol = "";
            this.button_SrchInvNo.SymbolSize = 12F;
            this.button_SrchInvNo.TabIndex = 1129;
            this.button_SrchInvNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchInvNo.Click += new System.EventHandler(this.button_SrchInvNo_Click);
            // 
            // txtInvNo
            // 
            this.txtInvNo.BackColor = System.Drawing.Color.White;
            this.txtInvNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtInvNo.Location = new System.Drawing.Point(303, 14);
            this.txtInvNo.MaxLength = 30;
            this.txtInvNo.Name = "txtInvNo";
            this.txtInvNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtInvNo, false);
            this.txtInvNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtInvNo.Size = new System.Drawing.Size(78, 20);
            this.txtInvNo.TabIndex = 1128;
            this.txtInvNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(387, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 13);
            this.label12.TabIndex = 1131;
            this.label12.Text = "رقم الفاتورة :";
            // 
            // c1FlexGrid1
            // 
            this.c1FlexGrid1.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.c1FlexGrid1.ColumnInfo = resources.GetString("c1FlexGrid1.ColumnInfo");
            this.c1FlexGrid1.ExtendLastCol = true;
            this.c1FlexGrid1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.c1FlexGrid1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.c1FlexGrid1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.c1FlexGrid1.Location = new System.Drawing.Point(6, 114);
            this.c1FlexGrid1.Name = "c1FlexGrid1";
            this.c1FlexGrid1.Rows.Count = 100;
            this.c1FlexGrid1.Rows.DefaultSize = 19;
            this.c1FlexGrid1.Size = new System.Drawing.Size(772, 134);
            this.c1FlexGrid1.StyleInfo = resources.GetString("c1FlexGrid1.StyleInfo");
            this.c1FlexGrid1.TabIndex = 12;
            this.c1FlexGrid1.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System;
            this.c1FlexGrid1.StartEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.c1FlexGrid1_StartEdit);
            this.c1FlexGrid1.LeaveEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.c1FlexGrid1_LeaveEdit);
            this.c1FlexGrid1.Click += new System.EventHandler(this.c1FlexGrid1_Click_1);
            // 
            // txtGedDesE
            // 
            this.txtGedDesE.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtGedDesE.Location = new System.Drawing.Point(315, 292);
            this.txtGedDesE.Name = "txtGedDesE";
            this.netResize1.SetResizeTextBoxMultiline(this.txtGedDesE, false);
            this.txtGedDesE.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtGedDesE.Size = new System.Drawing.Size(378, 21);
            this.txtGedDesE.TabIndex = 14;
            this.txtGedDesE.Click += new System.EventHandler(this.txtGedDesE_Click);
            this.txtGedDesE.Enter += new System.EventHandler(this.textBox_NameE_Enter);
            this.txtGedDesE.Leave += new System.EventHandler(this.textBox_NameA_Enter);
            // 
            // txtGedDes
            // 
            this.txtGedDes.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtGedDes.Location = new System.Drawing.Point(315, 269);
            this.txtGedDes.Name = "txtGedDes";
            this.netResize1.SetResizeTextBoxMultiline(this.txtGedDes, false);
            this.txtGedDes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtGedDes.Size = new System.Drawing.Size(378, 21);
            this.txtGedDes.TabIndex = 13;
            this.txtGedDes.Click += new System.EventHandler(this.txtGedDes_Click);
            this.txtGedDes.Enter += new System.EventHandler(this.textBox_NameA_Enter);
            this.txtGedDes.Leave += new System.EventHandler(this.textBox_NameA_Enter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(694, 294);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 1127;
            this.label9.Text = "البيان - إنجليزي :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(695, 271);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 13);
            this.label11.TabIndex = 1125;
            this.label11.Text = "البيان - عـــربي :";
            // 
            // label_LockeName
            // 
            this.label_LockeName.BackColor = System.Drawing.Color.Transparent;
            this.label_LockeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_LockeName.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label_LockeName.ForeColor = System.Drawing.Color.Maroon;
            this.label_LockeName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_LockeName.Location = new System.Drawing.Point(6, 14);
            this.label_LockeName.Name = "label_LockeName";
            this.label_LockeName.Size = new System.Drawing.Size(132, 43);
            this.label_LockeName.TabIndex = 1120;
            this.label_LockeName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // switchButton_Lock
            // 
            // 
            // 
            // 
            this.switchButton_Lock.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_Lock.Font = new System.Drawing.Font("Tahoma", 7F);
            this.switchButton_Lock.Location = new System.Drawing.Point(472, 12);
            this.switchButton_Lock.Name = "switchButton_Lock";
            this.switchButton_Lock.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.switchButton_Lock.OffText = "لم يتم الموافقة";
            this.switchButton_Lock.OffTextColor = System.Drawing.Color.White;
            this.switchButton_Lock.OnText = "تمت الموافقة";
            this.switchButton_Lock.Size = new System.Drawing.Size(157, 21);
            this.switchButton_Lock.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_Lock.TabIndex = 1119;
            this.switchButton_Lock.ValueChanged += new System.EventHandler(this.switchButton_Lock_ValueChanged);
            this.switchButton_Lock.Click += new System.EventHandler(this.switchButton_Lock_Click);
            // 
            // txtGDate
            // 
            this.txtGDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtGDate.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtGDate.Location = new System.Drawing.Point(631, 38);
            this.txtGDate.Mask = "0000/00/00";
            this.txtGDate.Name = "txtGDate";
            this.txtGDate.Size = new System.Drawing.Size(74, 21);
            this.txtGDate.TabIndex = 2;
            this.txtGDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHDate
            // 
            this.txtHDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtHDate.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtHDate.Location = new System.Drawing.Point(556, 38);
            this.txtHDate.Mask = "0000/00/00";
            this.txtHDate.Name = "txtHDate";
            this.txtHDate.Size = new System.Drawing.Size(74, 21);
            this.txtHDate.TabIndex = 3;
            this.txtHDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(710, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 482;
            this.label7.Text = "رقم المرجع :";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label2.Location = new System.Drawing.Point(709, 42);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(66, 13);
            this.Label2.TabIndex = 480;
            this.Label2.Text = "التاريــــــــخ :";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label1.Location = new System.Drawing.Point(713, 18);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(62, 13);
            this.Label1.TabIndex = 479;
            this.Label1.Text = "رقم السند :";
            // 
            // txtAccNameR
            // 
            this.txtAccNameR.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtAccNameR.ForeColor = System.Drawing.Color.White;
            this.txtAccNameR.Location = new System.Drawing.Point(6, 88);
            this.txtAccNameR.MaxLength = 30;
            this.txtAccNameR.Name = "txtAccNameR";
            this.txtAccNameR.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtAccNameR, false);
            this.txtAccNameR.Size = new System.Drawing.Size(229, 20);
            this.txtAccNameR.TabIndex = 11;
            this.txtAccNameR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_SrchAccNo
            // 
            this.button_SrchAccNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchAccNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchAccNo.Location = new System.Drawing.Point(237, 88);
            this.button_SrchAccNo.Name = "button_SrchAccNo";
            this.button_SrchAccNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchAccNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchAccNo.Symbol = "";
            this.button_SrchAccNo.SymbolSize = 12F;
            this.button_SrchAccNo.TabIndex = 10;
            this.button_SrchAccNo.TextColor = System.Drawing.Color.SteelBlue;
            // 
            // txtAccNo
            // 
            this.txtAccNo.BackColor = System.Drawing.Color.White;
            this.txtAccNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtAccNo.Location = new System.Drawing.Point(265, 88);
            this.txtAccNo.MaxLength = 30;
            this.txtAccNo.Name = "txtAccNo";
            this.txtAccNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtAccNo, false);
            this.txtAccNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAccNo.Size = new System.Drawing.Size(116, 20);
            this.txtAccNo.TabIndex = 9;
            this.txtAccNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(708, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 1059;
            this.label8.Text = "إستلمنا من :";
            // 
            // txtReceivedForm
            // 
            this.txtReceivedForm.BackColor = System.Drawing.Color.White;
            this.txtReceivedForm.Location = new System.Drawing.Point(472, 88);
            this.txtReceivedForm.MaxLength = 50;
            this.txtReceivedForm.Name = "txtReceivedForm";
            this.netResize1.SetResizeTextBoxMultiline(this.txtReceivedForm, false);
            this.txtReceivedForm.Size = new System.Drawing.Size(233, 20);
            this.txtReceivedForm.TabIndex = 5;
            // 
            // CmbCostC
            // 
            this.CmbCostC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbCostC.DisplayMember = "Text";
            this.CmbCostC.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbCostC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCostC.FormattingEnabled = true;
            this.CmbCostC.ItemHeight = 14;
            this.CmbCostC.Location = new System.Drawing.Point(170, 38);
            this.CmbCostC.Name = "CmbCostC";
            this.CmbCostC.Size = new System.Drawing.Size(211, 20);
            this.CmbCostC.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbCostC.TabIndex = 7;
            // 
            // CmbCurr
            // 
            this.CmbCurr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbCurr.DisplayMember = "Text";
            this.CmbCurr.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbCurr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCurr.FormattingEnabled = true;
            this.CmbCurr.ItemHeight = 14;
            this.CmbCurr.Location = new System.Drawing.Point(472, 62);
            this.CmbCurr.Name = "CmbCurr";
            this.CmbCurr.Size = new System.Drawing.Size(113, 20);
            this.CmbCurr.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbCurr.TabIndex = 6;
            // 
            // CmbLegate
            // 
            this.CmbLegate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbLegate.DisplayMember = "Text";
            this.CmbLegate.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbLegate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbLegate.FormattingEnabled = true;
            this.CmbLegate.ItemHeight = 14;
            this.CmbLegate.Location = new System.Drawing.Point(34, 62);
            this.CmbLegate.Name = "CmbLegate";
            this.CmbLegate.Size = new System.Drawing.Size(347, 20);
            this.CmbLegate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbLegate.TabIndex = 8;
            // 
            // txtRef
            // 
            this.txtRef.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtRef.Location = new System.Drawing.Point(631, 62);
            this.txtRef.Name = "txtRef";
            this.netResize1.SetResizeTextBoxMultiline(this.txtRef, false);
            this.txtRef.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRef.Size = new System.Drawing.Size(74, 21);
            this.txtRef.TabIndex = 4;
            // 
            // textBox_ID
            // 
            this.textBox_ID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.textBox_ID.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_ID.Location = new System.Drawing.Point(631, 14);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_ID, false);
            this.textBox_ID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_ID.Size = new System.Drawing.Size(74, 21);
            this.textBox_ID.TabIndex = 1;
            // 
            // txtTotalCredit
            // 
            this.txtTotalCredit.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtTotalCredit.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtTotalCredit.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotalCredit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotalCredit.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotalCredit.DisplayFormat = "0.00";
            this.txtTotalCredit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtTotalCredit.Increment = 1D;
            this.txtTotalCredit.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTotalCredit.IsInputReadOnly = true;
            this.txtTotalCredit.Location = new System.Drawing.Point(158, 292);
            this.txtTotalCredit.Name = "txtTotalCredit";
            this.txtTotalCredit.Size = new System.Drawing.Size(152, 20);
            this.txtTotalCredit.TabIndex = 15;
            // 
            // txtTotalDebit
            // 
            this.txtTotalDebit.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtTotalDebit.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtTotalDebit.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotalDebit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotalDebit.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotalDebit.DisplayFormat = "0.00";
            this.txtTotalDebit.Increment = 1D;
            this.txtTotalDebit.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTotalDebit.IsInputReadOnly = true;
            this.txtTotalDebit.Location = new System.Drawing.Point(77, 471);
            this.txtTotalDebit.Name = "txtTotalDebit";
            this.txtTotalDebit.Size = new System.Drawing.Size(152, 20);
            this.txtTotalDebit.TabIndex = 1056;
            // 
            // txtBalance
            // 
            this.txtBalance.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtBalance.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtBalance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBalance.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtBalance.DisplayFormat = "0.00";
            this.txtBalance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtBalance.Increment = 1D;
            this.txtBalance.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtBalance.IsInputReadOnly = true;
            this.txtBalance.Location = new System.Drawing.Point(5, 292);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(152, 20);
            this.txtBalance.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.SteelBlue;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(311, 429);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 23);
            this.label10.TabIndex = 1074;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.SteelBlue;
            this.label17.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(5, 270);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(152, 21);
            this.label17.TabIndex = 1038;
            this.label17.Text = "الرصيد";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label21
            // 
            this.Label21.BackColor = System.Drawing.Color.SteelBlue;
            this.Label21.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.Label21.ForeColor = System.Drawing.Color.White;
            this.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label21.Location = new System.Drawing.Point(158, 270);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(152, 21);
            this.Label21.TabIndex = 1037;
            this.Label21.Text = "قيمة الدائن";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.BackColor = System.Drawing.Color.White;
            this.txtChequeNo.Location = new System.Drawing.Point(35, 424);
            this.txtChequeNo.MaxLength = 30;
            this.txtChequeNo.Name = "txtChequeNo";
            this.netResize1.SetResizeTextBoxMultiline(this.txtChequeNo, false);
            this.txtChequeNo.Size = new System.Drawing.Size(215, 20);
            this.txtChequeNo.TabIndex = 1070;
            this.txtChequeNo.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(265, 427);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 1071;
            this.label5.Text = "رقم الشيك";
            this.label5.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(39, 449);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 21);
            this.label3.TabIndex = 1053;
            this.label3.Text = "قيمة المدين";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAccName
            // 
            this.txtAccName.BackColor = System.Drawing.Color.White;
            this.txtAccName.Location = new System.Drawing.Point(6, 181);
            this.txtAccName.MaxLength = 30;
            this.txtAccName.Name = "txtAccName";
            this.txtAccName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtAccName, false);
            this.txtAccName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAccName.Size = new System.Drawing.Size(661, 20);
            this.txtAccName.TabIndex = 1051;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(670, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 1052;
            this.label6.Text = "الحســــاب :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label19.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label19.Location = new System.Drawing.Point(587, 65);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(43, 13);
            this.label19.TabIndex = 1049;
            this.label19.Text = "العملة :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label18.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(387, 66);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 13);
            this.label18.TabIndex = 1048;
            this.label18.Text = "المنـــــدوب :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(387, 42);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 13);
            this.label15.TabIndex = 497;
            this.label15.Text = "مركز التكلفــة :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(387, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 1066;
            this.label4.Text = "حساب المدين :";
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
            this.ribbonBar_Tasks.Location = new System.Drawing.Point(0, 346);
            this.ribbonBar_Tasks.Name = "ribbonBar_Tasks";
            this.ribbonBar_Tasks.Size = new System.Drawing.Size(786, 51);
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
            this.superTabControl_Main1.Size = new System.Drawing.Size(411, 51);
            this.superTabControl_Main1.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_Main1.TabIndex = 10;
            this.superTabControl_Main1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.button_Repetition,
            this.Button_Close,
            this.buttonItem_Print,
            this.Button_Search,
            this.Button_Delete,
            this.Button_Save,
            this.Button_Add});
            this.superTabControl_Main1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.superTabControl_Main1.Text = "superTabControl3";
            this.superTabControl_Main1.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.superTabControl_Main1.RightToLeftChanged += new System.EventHandler(this.superTabControl_Main1_RightToLeftChanged);
            // 
            // button_Repetition
            // 
            this.button_Repetition.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.button_Repetition.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground;
            this.button_Repetition.FontBold = true;
            this.button_Repetition.FontItalic = true;
            this.button_Repetition.ForeColor = System.Drawing.Color.Maroon;
            this.button_Repetition.Image = ((System.Drawing.Image)(resources.GetObject("button_Repetition.Image")));
            this.button_Repetition.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.button_Repetition.ImagePaddingHorizontal = 15;
            this.button_Repetition.ImagePaddingVertical = 11;
            this.button_Repetition.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.button_Repetition.Name = "button_Repetition";
            this.button_Repetition.Stretch = true;
            this.button_Repetition.SubItemsExpandWidth = 14;
            this.button_Repetition.Symbol = "";
            this.button_Repetition.SymbolSize = 15F;
            this.button_Repetition.Text = "تكرار القيد";
            this.button_Repetition.Click += new System.EventHandler(this.button_Repetition_Click);
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
            this.buttonItem_Print.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.printersettings});
            this.buttonItem_Print.SubItemsExpandWidth = 14;
            this.buttonItem_Print.Symbol = "";
            this.buttonItem_Print.SymbolSize = 15F;
            this.buttonItem_Print.Text = "طباعة";
            this.buttonItem_Print.Tooltip = "طباعة السجل الحالي";
            this.buttonItem_Print.Click += new System.EventHandler(this.buttonItem_Print_Click_1);
            // 
            // printersettings
            // 
            this.printersettings.Name = "printersettings";
            this.printersettings.Symbol = "";
            this.printersettings.Text = "اعدادات الطابعة";
            this.printersettings.Click += new System.EventHandler(this.printersettings_Click);
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
            this.superTabControl_Main2.Location = new System.Drawing.Point(411, 0);
            this.superTabControl_Main2.Name = "superTabControl_Main2";
            this.superTabControl_Main2.ReorderTabsEnabled = true;
            this.superTabControl_Main2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.superTabControl_Main2.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_Main2.SelectedTabIndex = -1;
            this.superTabControl_Main2.Size = new System.Drawing.Size(375, 51);
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
            // ToolStripMenuItem_Rep
            // 
            this.ToolStripMenuItem_Rep.Checked = true;
            this.ToolStripMenuItem_Rep.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToolStripMenuItem_Rep.Name = "ToolStripMenuItem_Rep";
            this.ToolStripMenuItem_Rep.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem_Rep.Text = "إظهار التقرير";
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
            this.expandableSplitter1.Location = new System.Drawing.Point(0, -1);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(786, 14);
            this.expandableSplitter1.TabIndex = 1;
            this.expandableSplitter1.TabStop = false;
            // 
            // panelEx2
            // 
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx2.Location = new System.Drawing.Point(0, 13);
            this.panelEx2.MinimumSize = new System.Drawing.Size(743, 376);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(786, 384);
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
            // dockSite1
            // 
            this.dockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite1.Location = new System.Drawing.Point(0, 0);
            this.dockSite1.Name = "dockSite1";
            this.dockSite1.Size = new System.Drawing.Size(0, 397);
            this.dockSite1.TabIndex = 900;
            this.dockSite1.TabStop = false;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "*.rtf";
            this.saveFileDialog1.FileName = "doc1";
            this.saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf|All Files(*.*)|*.*";
            this.saveFileDialog1.FilterIndex = 2;
            this.saveFileDialog1.Title = "Save File";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelEx3);
            this.panel1.Controls.Add(this.expandableSplitter1);
            this.panel1.Controls.Add(this.panelEx2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 397);
            this.panel1.TabIndex = 904;
            // 
            // panelEx3
            // 
            this.panelEx3.Controls.Add(this.DGV_Main);
            this.panelEx3.Controls.Add(this.ribbonBar_DGV);
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx3.Location = new System.Drawing.Point(0, 0);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(786, 0);
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
            background5.BackFillType = DevComponents.DotNetBar.SuperGrid.Style.BackFillType.VerticalCenter;
            background5.Color1 = System.Drawing.Color.Silver;
            background5.Color2 = System.Drawing.Color.White;
            this.DGV_Main.DefaultVisualStyles.GroupByStyles.Default.Background = background5;
            background6.BackFillType = DevComponents.DotNetBar.SuperGrid.Style.BackFillType.Center;
            background6.Color1 = System.Drawing.Color.LightSteelBlue;
            this.DGV_Main.DefaultVisualStyles.RowStyles.Default.Background = background6;
            background7.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DGV_Main.DefaultVisualStyles.RowStyles.MouseOver.Background = background7;
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
            borderColor3.Bottom = System.Drawing.Color.Black;
            borderColor3.Left = System.Drawing.Color.Black;
            borderColor3.Right = System.Drawing.Color.Black;
            borderColor3.Top = System.Drawing.Color.Black;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.BorderColor = borderColor3;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.TextColor = System.Drawing.Color.SteelBlue;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.TextColor = System.Drawing.Color.White;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.FooterStyles.Default.TextColor = System.Drawing.Color.White;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            borderColor4.Bottom = System.Drawing.Color.Black;
            borderColor4.Left = System.Drawing.Color.Black;
            borderColor4.Right = System.Drawing.Color.Black;
            borderColor4.Top = System.Drawing.Color.Black;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.BorderColor = borderColor4;
            baseTreeButtonVisualStyle3.BorderColor = System.Drawing.Color.White;
            baseTreeButtonVisualStyle3.LineColor = System.Drawing.Color.White;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.CircleTreeButtonStyle.ExpandButton = baseTreeButtonVisualStyle3;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.HeaderHLinePattern = DevComponents.DotNetBar.SuperGrid.Style.LinePattern.None;
            background8.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            baseTreeButtonVisualStyle4.Background = background8;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.SquareTreeButtonStyle.ExpandButton = baseTreeButtonVisualStyle4;
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
            this.DGV_Main.Size = new System.Drawing.Size(786, 0);
            this.DGV_Main.TabIndex = 876;
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
            this.ribbonBar_DGV.Size = new System.Drawing.Size(786, 51);
            this.ribbonBar_DGV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar_DGV.TabIndex = 877;
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
            this.superTabControl_DGV.Size = new System.Drawing.Size(786, 51);
            this.superTabControl_DGV.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_DGV.TabIndex = 12;
            this.superTabControl_DGV.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.textBox_search,
            this.Button_ExportTable2,
            this.Button_PrintTable,
            this.Button_PrintTableMulti,
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
            // Button_PrintTableMulti
            // 
            this.Button_PrintTableMulti.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_PrintTableMulti.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.Button_PrintTableMulti.FontBold = true;
            this.Button_PrintTableMulti.FontItalic = true;
            this.Button_PrintTableMulti.Image = ((System.Drawing.Image)(resources.GetObject("Button_PrintTableMulti.Image")));
            this.Button_PrintTableMulti.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.Button_PrintTableMulti.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_PrintTableMulti.Name = "Button_PrintTableMulti";
            this.Button_PrintTableMulti.SubItemsExpandWidth = 14;
            this.Button_PrintTableMulti.Symbol = "";
            this.Button_PrintTableMulti.SymbolSize = 15F;
            this.Button_PrintTableMulti.Text = "طباعة السندات المحددة";
            this.Button_PrintTableMulti.Tooltip = "طباعة السندات المحددة";
            this.Button_PrintTableMulti.Click += new System.EventHandler(this.Button_PrintTableMulti_Click);
            // 
            // labelItem3
            // 
            this.labelItem3.Name = "labelItem3";
            this.labelItem3.Width = 40;
            // 
            // dockSite4
            // 
            this.dockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite4.Location = new System.Drawing.Point(0, 397);
            this.dockSite4.Name = "dockSite4";
            this.dockSite4.Size = new System.Drawing.Size(786, 0);
            this.dockSite4.TabIndex = 903;
            this.dockSite4.TabStop = false;
            // 
            // dockSite3
            // 
            this.dockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite3.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite3.Location = new System.Drawing.Point(0, 0);
            this.dockSite3.Name = "dockSite3";
            this.dockSite3.Size = new System.Drawing.Size(786, 0);
            this.dockSite3.TabIndex = 902;
            this.dockSite3.TabStop = false;
            // 
            // barTopDockSite
            // 
            this.barTopDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barTopDockSite.Dock = System.Windows.Forms.DockStyle.Top;
            this.barTopDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barTopDockSite.Location = new System.Drawing.Point(0, 0);
            this.barTopDockSite.Name = "barTopDockSite";
            this.barTopDockSite.Size = new System.Drawing.Size(786, 0);
            this.barTopDockSite.TabIndex = 896;
            this.barTopDockSite.TabStop = false;
            // 
            // barBottomDockSite
            // 
            this.barBottomDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barBottomDockSite.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barBottomDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barBottomDockSite.Location = new System.Drawing.Point(0, 397);
            this.barBottomDockSite.Name = "barBottomDockSite";
            this.barBottomDockSite.Size = new System.Drawing.Size(786, 0);
            this.barBottomDockSite.TabIndex = 897;
            this.barBottomDockSite.TabStop = false;
            // 
            // barLeftDockSite
            // 
            this.barLeftDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barLeftDockSite.Dock = System.Windows.Forms.DockStyle.Left;
            this.barLeftDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barLeftDockSite.Location = new System.Drawing.Point(0, 0);
            this.barLeftDockSite.Name = "barLeftDockSite";
            this.barLeftDockSite.Size = new System.Drawing.Size(0, 397);
            this.barLeftDockSite.TabIndex = 898;
            this.barLeftDockSite.TabStop = false;
            // 
            // barRightDockSite
            // 
            this.barRightDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barRightDockSite.Dock = System.Windows.Forms.DockStyle.Right;
            this.barRightDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barRightDockSite.Location = new System.Drawing.Point(786, 0);
            this.barRightDockSite.Name = "barRightDockSite";
            this.barRightDockSite.Size = new System.Drawing.Size(0, 397);
            this.barRightDockSite.TabIndex = 899;
            this.barRightDockSite.TabStop = false;
            // 
            // dockSite2
            // 
            this.dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite2.Location = new System.Drawing.Point(786, 0);
            this.dockSite2.Name = "dockSite2";
            this.dockSite2.Size = new System.Drawing.Size(0, 397);
            this.dockSite2.TabIndex = 901;
            this.dockSite2.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.rtf";
            this.openFileDialog1.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf|All Files(*.*)|*.*";
            this.openFileDialog1.FilterIndex = 2;
            this.openFileDialog1.Title = "Open File";
            // 
            // timerInfoBallon
            // 
            this.timerInfoBallon.Interval = 3000;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
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
            // netResize1
            // 
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            // 
            // FMReceiptVoucher
            // 
            this.ClientSize = new System.Drawing.Size(786, 397);
            this.Controls.Add(this.PanelSpecialContainer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dockSite1);
            this.Controls.Add(this.dockSite4);
            this.Controls.Add(this.dockSite3);
            this.Controls.Add(this.barTopDockSite);
            this.Controls.Add(this.barBottomDockSite);
            this.Controls.Add(this.barLeftDockSite);
            this.Controls.Add(this.barRightDockSite);
            this.Controls.Add(this.dockSite2);
            this.Icon = global::InvAcc.Properties.Resources.favicon;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(753, 422);
            this.Name = "FMReceiptVoucher";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "سند قبض";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FMReceiptVoucher_FormClosed);
            this.Load += new System.EventHandler(this.FMReceiptVoucher_Load);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.PanelSpecialContainer.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            this.ribbonBar1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalCredit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDebit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBalance)).EndInit();
            this.ribbonBar_Tasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main2)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelEx3.ResumeLayout(false);
            this.ribbonBar_DGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_DGV)).EndInit();
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
        public void RefreshPKeys()
        {
            PKeys.Clear();
            try
            {
                PKeys = db.ExecuteQuery<string>("select gdNo from T_GDHEAD where gdTyp =" + VarGeneral.InvTyp + " and gdLok = 0 ", new object[0]).ToList();
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
            T1 = DateTime.Now.Ticks;
            DGV_Main.PrimaryGrid.VirtualMode = true;
            Stock_DataDataContext db = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_GDHEAD> list = db.FillGDHEAD_2(VarGeneral.InvTyp, textBox_search.TextBox.Text).ToList();
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
        private void FrmInvices_CheckFouce(object sender, EventArgs e)
        {
            VarGeneral.InvTyp = 12;
            if (VarGeneral.SSSTyp == 0)
            {
                VarGeneral.StockOnly = true;
            }
        }
        public FMReceiptVoucher()
        {
            InitializeComponent();
            base.Activated += FrmInvices_CheckFouce;
            ADD_Controls();
            textBox_ID.Click += Button_Edit_Click;
            txtAccName.Click += Button_Edit_Click;
            txtBalance.Click += Button_Edit_Click;
            textBox_Type.Click += Button_Edit_Click;
            txtGDate.Click += Button_Edit_Click;
            txtHDate.Click += Button_Edit_Click;
            txtRef.Click += Button_Edit_Click;
            txtGedDes.Click += Button_Edit_Click;
            txtGedDesE.Click += Button_Edit_Click;
            txtTotalCredit.Click += Button_Edit_Click;
            txtTotalDebit.Click += Button_Edit_Click;
            CmbCostC.Click += Button_Edit_Click;
            CmbCurr.Click += Button_Edit_Click;
            CmbLegate.Click += Button_Edit_Click;
            button_SrchAccNo.Click += Button_Edit_Click;
            txtReceivedForm.Click += Button_Edit_Click;
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
            txtHDate.Click += txtHDate_Click;
            txtHDate.Leave += txtHDate_Leave;
            txtGDate.Click += txtGDate_Click;
            txtGDate.Leave += txtGDate_Leave;
            c1FlexGrid1.Click += c1FlexGrid1_Click;
            c1FlexGrid1.AfterEdit += c1FlexGrid1_AfterEdit;
            c1FlexGrid1.AfterRowColChange += c1FlexGrid1_AfterRowColChange;
            c1FlexGrid1.KeyDown += c1FlexGrid1_KeyDown;
            c1FlexGrid1.MouseDown += c1FlexGrid1_MouseDown;
            c1FlexGrid1.RowColChange += c1FlexGrid1_RowColChange;
            buttonItem_Print.Click += buttonItem_Print_Click;
            button_SrchAccNo.Click += button_SrchAccNo_Click;
            if (VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F" || VarGeneral.SSSLev == "S" || VarGeneral.SSSLev == "C")
            {
                CmbCostC.Visible = false;
                label15.Visible = false;
                button_SrchCostCenter.Visible = false;
            }
            else
            {
                CmbCostC.Visible = true;
                label15.Visible = true;
                button_SrchCostCenter.Visible = true;
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
                        button_SrchCostCenter.Visible = true;
                    }
                    else
                    {
                        CmbCostC.Visible = false;
                        label15.Visible = false;
                        button_SrchCostCenter.Visible = false;
                    }
                }
            }
            catch
            {
            }
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
            {
                txtTotalDebit.DisplayFormat = VarGeneral.DicemalMask;
                txtTotalCredit.DisplayFormat = VarGeneral.DicemalMask;
                txtBalance.DisplayFormat = VarGeneral.DicemalMask;
            }
        }
        public void buttonItem_Print_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(textBox_ID.Text != "") || State != 0)
                {
                    return;
                }
                if (_InvSetting.InvpRINTERInfo.nTyp.Substring(0, 1) == "1")
                {
                    RepShow _RepShow = new RepShow();
                    _RepShow.Tables = "T_GDDET LEFT OUTER JOIN T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID LEFT OUTER JOIN T_INVSETTING ON T_GDHEAD.gdTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_GDHEAD.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_GDHEAD.gdCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_GDHEAD.gdMnd = T_Mndob.Mnd_ID LEFT OUTER JOIN T_AccDef ON T_GDDET.AccNo = T_AccDef.AccDef_No LEFT OUTER JOIN T_SYSSETTING ON T_GDHEAD.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                    string Fields = " CASE WHEN T_GDDET.gdValue > 0 THEN T_GDDET.gdValue ELSE 0 END as DebitBala , CASE WHEN T_GDDET.gdValue < 0 THEN Abs(T_GDDET.gdValue) ELSE 0 END as CreditBala ," + ((LangArEn == 0) ? " T_Curency.Arb_Des " : " T_Curency.Eng_Des ") + " as CurrnceyNm, T_Curency.Rate ," + ((LangArEn == 0) ? " T_CstTbl.Arb_Des as CostCenteNm " : "T_CstTbl.Eng_Des as CostCenteNm") + " , T_Mndob.Arb_Des as MndNm , T_GDHEAD.* , T_GDDET.AccNo as AccDef_No," + ((LangArEn == 0) ? "T_AccDef.Arb_Des as AccDefNm" : "T_AccDef.Eng_Des as AccDefNm") + "," + ((LangArEn == 0) ? " T_GDDET.gdDes as gdDesDet " : " T_GDDET.gdDesE as gdDesDet ") + ",T_SYSSETTING.LogImg,(T_GDHEAD.ArbTaf + T_Curency.Arb_Des) as ArbTafCurr,(T_GDHEAD.EngTaf + T_Curency.Eng_Des) as EngTafCurr,T_CstTbl.Cst_No,(select T_AccDef.Arb_Des from T_AccDef where T_AccDef.AccDef_No = (select (x.AccNo) from T_GDDET as x where x.gdID = (T_GDDET.gdID) and x.Lin = 1 )) as ch,(select T_AccDef.Eng_Des from T_AccDef where T_AccDef.AccDef_No = (select (x.AccNo) from T_GDDET as x where x.gdID = (T_GDDET.gdID) and x.Lin = 1 )) as tm,(select T_AccDef.Arb_Des from T_AccDef where T_AccDef.AccDef_No = (select (x.AccNo) from T_GDDET as x where x.gdID = (T_GDDET.gdID) and x.Lin = 0 )) as dt,(select T_AccDef.Eng_Des from T_AccDef where T_AccDef.AccDef_No = (select (x.AccNo) from T_GDDET as x where x.gdID = (T_GDDET.gdID) and x.Lin = 0 )) as curr,'" + VarGeneral.BranchNameA + "' as BrnchNmA,'" + VarGeneral.BranchNameE + "' as BrnchNmE,(select max(x.AccNo) from T_GDDET as x where x.gdID = (T_GDHEAD.gdhead_ID) and  x.gdValue > 0) as MainAccNo,(select max(T_AccDef.Arb_Des) from T_AccDef right JOIN T_GDDET ON T_AccDef.AccDef_No = T_GDDET.AccNo where T_GDDET.gdID = (T_GDHEAD.gdhead_ID) and  T_GDDET.gdValue > 0) as ManiAccNmA,(select max(T_AccDef.Eng_Des) from T_AccDef right JOIN T_GDDET ON T_AccDef.AccDef_No = T_GDDET.AccNo where T_GDDET.gdID = (T_GDHEAD.gdhead_ID) and  T_GDDET.gdValue > 0) as ManiAccNmE,(select max(T_AccDef.Arb_Des) from T_AccDef where AccDef_No = (select max(x.AccNo) from T_GDDET x where x.gdID = (T_GDDET.gdID) and Lin = 1)) as CusVenNm,(select max(T_AccDef.Eng_Des) from T_AccDef where AccDef_No = (select max(x.AccNo) from T_GDDET x where x.gdID = (T_GDDET.gdID) and Lin = 1)) as CusVenNmE,(select max(T_AccDef.PersonalNm) from T_AccDef where AccDef_No = (select max(x.AccNo) from T_GDDET x where x.gdID = (T_GDDET.gdID) and Lin = 1)) as PersonalNm,(select max(T_AccDef.City) from T_AccDef where AccDef_No = (select max(x.AccNo) from T_GDDET x where x.gdID = (T_GDDET.gdID) and Lin = 1)) as City,(select max(T_AccDef.Email) from T_AccDef where AccDef_No = (select max(x.AccNo) from T_GDDET x where x.gdID = (T_GDDET.gdID) and Lin = 1)) as Email,(select max(T_AccDef.Mobile) from T_AccDef where AccDef_No = (select max(x.AccNo) from T_GDDET x where x.gdID = (T_GDDET.gdID) and Lin = 1)) as Mobile";
                    VarGeneral.HeaderRep[0] = Text;
                    VarGeneral.HeaderRep[1] = "";
                    VarGeneral.HeaderRep[2] = "";
                    _RepShow.Rule = " where T_GDHEAD.gdhead_ID = " + data_this.gdhead_ID + " Order by T_GDDET.Lin ";
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
                        frm.Repvalue = "RepGaidCatch";

                        frm.Tag = LangArEn;
                        if (ifMultiPrint)
                        {
                            frm.BarcodSts = true;
                        }
                        else
                        {
                            frm.BarcodSts = false;
                        }
                        frm.Repvalue = "RepGaidCatch";
                        VarGeneral.vTitle = Text;
                        VarGeneral.CostCenterlbl = label15.Text.Replace(" :", "");
                        VarGeneral.Mndoblbl = label18.Text.Replace(" :", "");
                        FrmShowPriceOption frm2 = new FrmShowPriceOption();
                        frm2.button_Unit1.Text = ((LangArEn == 0) ? (buttonItem_Print.Text + " بشكل السند") : (buttonItem_Print.Text + " in Bond"));
                        frm2.button_Unit2.Text = ((LangArEn == 0) ? (buttonItem_Print.Text + " بشكل القيد") : (buttonItem_Print.Text + " in detail"));
                        frm2.Tag = LangArEn;
                        frm2.TopMost = true;
                        frm2.ShowDialog();
                        if (frm2.vSts_Op)
                        {
                            VarGeneral.Snd_Gaid_Des = frm2.vSize_;
                            if (_InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1) == "0" || ifMultiPrint)
                            {
                                frm._Proceess();
                                return;
                            }
                            frm.TopMost = true;
                            frm.ShowDialog();
                        }
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
        private void DGV_MainGetCellStyle(object sender, GridGetCellStyleEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            if (panel.DataMember.Equals("HISale") && e.GridCell.GridColumn.Name.Equals("Date"))
            {
                DateTime dt = default(DateTime);
                dt = Convert.ToDateTime(e.GridCell.Value);
            }
        }
        private void textBox_ID_Click(object sender, EventArgs e)
        {
            textBox_ID.SelectAll();
        }
        private void Button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void FillHDGV(IEnumerable<T_GDHEAD> new_data_enum)
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
            DGV_Main.PrimaryGrid.DataMember = "T_GDHEAD";
        }
        public void FillHDGVQ(IQueryable new_data_enum)
        {
            SetReadOnly = true;
            DGV_Main.PrimaryGrid.DataSource = new_data_enum;
            DGV_Main.PrimaryGrid.DataMember = "T_GDHEAD";
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
        private void Button_ExportTable2_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcel.ExportToExcel(DGV_Main, "تقرير سندات القبض");
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
            VarGeneral.SFrmTyp = "T_Gaid";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                textBox_ID.Text = frm.SerachNo.ToString();
            }
        }
        private void DGV_Main_AfterCheck(object sender, GridAfterCheckEventArgs e)
        {
            DGV_Main.PrimaryGrid.VirtualMode = false;
            GridRow crow = e.Item as GridRow;
            if (crow != null && crow.Checked)
            {
                GridPanel panel = new GridPanel();
                var q = db.StockGDHEAD(VarGeneral.InvTyp, crow.Cells["gdNo"].Value.ToString()).T_GDDETs.Select((T_GDDET item) => new
                {
                    item.gdNo,
                    item.gdDes,
                    item.gdDesE,
                    item.AccNo,
                    item.AccName,
                    item.gdValue
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
        private void DGV_Main_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            switch (panel.DataMember)
            {
                case "T_GDHEAD":
                    PropHIOfferPanel(panel);
                    break;
                case "Line":
                    PropLOfferPanel(panel);
                    break;
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
            panel.Columns["gdUser"].Width = 220;
            panel.Columns["gdUser"].Visible = columns_Names_visible["gdUser"].IfDefault;
            panel.Columns["gdUserNam"].Width = 220;
            panel.Columns["gdUserNam"].Visible = columns_Names_visible["gdUserNam"].IfDefault;
            panel.Columns["gdNo"].Width = 150;
            panel.Columns["gdNo"].Visible = columns_Names_visible["gdNo"].IfDefault;
            panel.Columns["gdCstNo"].Width = 100;
            panel.Columns["gdCstNo"].Visible = columns_Names_visible["gdCstNo"].IfDefault;
            panel.Columns["gdHDate"].Width = 120;
            panel.Columns["gdHDate"].Visible = columns_Names_visible["gdHDate"].IfDefault;
            panel.Columns["gdGDate"].Width = 120;
            panel.Columns["gdGDate"].Visible = columns_Names_visible["gdGDate"].IfDefault;
            panel.Columns["gdMem"].Width = 250;
            panel.Columns["gdMem"].Visible = columns_Names_visible["gdMem"].IfDefault;
            panel.Columns["gdTot"].Width = 100;
            panel.Columns["gdTot"].Visible = columns_Names_visible["gdTot"].IfDefault;
            panel.Columns["RefNo"].Width = 120;
            panel.Columns["RefNo"].Visible = columns_Names_visible["RefNo"].IfDefault;
            panel.Columns["BName"].Width = 100;
            panel.Columns["BName"].Visible = columns_Names_visible["BName"].IfDefault;
        }
        private void PropLOfferPanel(GridPanel panel)
        {
            panel.ColumnAutoSizeMode = ColumnAutoSizeMode.DisplayedCells;
            panel.Columns["gdNo"].HeaderText = ((LangArEn == 0) ? "رقم القيد" : "Gaid No");
            panel.Columns["gdDes"].HeaderText = ((LangArEn == 0) ? "الوصف عربي " : "Description Ar");
            panel.Columns["gdDesE"].HeaderText = ((LangArEn == 0) ? "الوصف إنجليزي " : "Description En");
            panel.Columns["AccNo"].HeaderText = ((LangArEn == 0) ? "رقم الحساب" : "Acc No");
            panel.Columns["AccName"].HeaderText = ((LangArEn == 0) ? "اسم الحساب" : "Acc Name");
            panel.Columns["gdValue"].HeaderText = ((LangArEn == 0) ? "القيمة" : "Value");
            panel.Footer.Text = ((LangArEn == 0) ? "عدد الاسطر: " : "Lines Count: ") + panel.Rows.Count;
            panel.ReadOnly = true;
            panel.ShowRowDirtyMarker = true;
            panel.ColumnHeader.RowHeight = 30;
            for (int i = 0; i < panel.Columns.Count; i++)
            {
                panel.Columns[i].AutoSizeMode = ColumnAutoSizeMode.AllCells;
            }
            panel.Columns[1].Width = 160;
            panel.Columns[2].Width = 300;
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
                    TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(data_this.gdNo ?? "") + 1);
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
            if (data_this != null && !(data_this.gdNo == 0.ToString()) && ifOkDelete)
            {
                data_this = db.StockGDHEAD(VarGeneral.InvTyp, data_this.gdNo);
                IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
                try
                {
                    db_ = Database.GetDatabase(VarGeneral.BranchCS);
                    db_.StartTransaction();
                    db_.ClearParameters();
                    db_.AddParameter("gdhead_ID", DbType.Int32, data_this.gdhead_ID);
                    db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDHEAD_DELETE");
                    db_.EndTransaction();
                }
                catch (SqlException)
                {
                    data_this = db.StockGDHEAD(VarGeneral.InvTyp, data_this.gdNo);
                    return;
                }
                catch (Exception)
                {
                    data_this = db.StockGDHEAD(VarGeneral.InvTyp, data_this.gdNo);
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
                txtGDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                txtHDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                GetInvSetting();
                textBox_ID.Text = db.MaxGDHEADsNo.ToString();
                if (!string.IsNullOrEmpty(txtInvNo.Text))
                {
                    c1FlexGrid1.Rows.Count = 2;
                }
                else
                {
                    c1FlexGrid1.Rows.Count = c1FlexGrid1.Rows.Count + 100;
                }
                textBox_ID.Focus();
                State = FormState.New;
                try
                {
                    base.ActiveControl = c1FlexGrid1;
                    c1FlexGrid1.Row = 1;
                    c1FlexGrid1.Col = 1;
                }
                catch
                {
                }
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
                if (!string.IsNullOrEmpty(txtInvNo.Text))
                {
                    c1FlexGrid1.Rows.Count = 2;
                }
                else
                {
                    c1FlexGrid1.Rows.Count = c1FlexGrid1.Rows.Count + 100;
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
            data_this = new T_GDHEAD();
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
            txtInvNo.Tag = "";
            if (c1FlexGrid1.Rows.Count <= 1)
            {
                c1FlexGrid1.Rows.Count = 100;
            }
            else
            {
                c1FlexGrid1.Clear(ClearFlags.Content, 1, 1, c1FlexGrid1.Rows.Count - 1, 7);
            }
            switchButton_Lock.Value = false;
            label_LockeName.Text = ((LangArEn == 0) ? "غير مقف\u0651ــلة" : "Unlocked");
            SetReadOnly = false;
        }
        private bool ValidData()
        {
            if (textBox_ID.Text == "0" || textBox_ID.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ بدون رقم الفاتورة - السند" : "Can not save without the invoice number", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            try
            {
                c1FlexGrid1_AfterRowColChange(null, new RangeEventArgs(default(CellRange), default(CellRange)));
            }
            catch
            {
            }
            if (txtAccNo.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام العملية .. يجب تحديد رقم الحساب اولا\u064c" : "You can not complete the process .. must specify the account number first", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (txtTotalCredit.Value == 0.0 || txtTotalCredit.Value == 0.0 || txtTotalCredit.Value == 0.0)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ والصافي يساوي صفر" : "Can not save, and the total is equal to zero", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            for (int iiCnt = 1; iiCnt < c1FlexGrid1.Rows.Count; iiCnt++)
            {
                if (!(string.Concat(c1FlexGrid1.GetData(iiCnt, 1)) != ""))
                {
                    continue;
                }
                for (int i = 1; i < c1FlexGrid1.Cols.Count; i++)
                {
                    if (i != 6 && c1FlexGrid1.GetData(iiCnt, i).ToString() == "")
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من تعبئة جميع البيانات المطلوبة" : "We must not be empty value .. Please make sure there are items in the bill.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        c1FlexGrid1.Row = iiCnt;
                        c1FlexGrid1.Col = i;
                        c1FlexGrid1.Focus();
                        return false;
                    }
                    try
                    {
                        if (double.Parse(VarGeneral.TString.TEmpty(c1FlexGrid1.GetData(iiCnt, 6).ToString())) <= 0.0 && double.Parse(VarGeneral.TString.TEmpty(c1FlexGrid1.GetData(iiCnt, 7).ToString())) <= 0.0)
                        {
                            MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من تعبئة جميع البيانات المطلوبة" : "We must not be empty value .. Please make sure there are items in the bill.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            c1FlexGrid1.Row = iiCnt;
                            c1FlexGrid1.Col = i;
                            c1FlexGrid1.Focus();
                            return false;
                        }
                    }
                    catch
                    {
                    }
                }
            }
            if (!string.IsNullOrEmpty(txtInvNo.Text))
            {
                if (c1FlexGrid1.Rows.Count > 2)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من عدد سطور القيد" : "We must not be empty value .. Check the number of lines of constraint", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                if (txtTotalCredit.Value > TotRequest)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. المبلغ المدفوع أكبر من المتبقي" : "Can not complete the process .. The amount paid more than the remaining", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
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
            //if (false)
            //{
            //	Environment.Exit(0);
            //	return false;
            //}
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
                            try
                            {
                                if (Convert.ToDateTime(n.GregToHijri(hKeyNew.GetValue("vBackup_New").ToString(), "yyyy/MM/dd")) < Convert.ToDateTime(n.FormatHijri(txtHDate.Text, "yyyy/MM/dd")))
                                {
                                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. لقد تخطيت السنة المالية المحدد للنظام \n يرجى التواصل مع الإدارة لللإشتراك في خدمات النسخة " : "We can not complete the operation .. have you skip the fiscal year specified for the system", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    return false;
                                }
                            }
                            catch
                            {
                                if (Convert.ToDateTime(n.FormatGreg(hKeyNew.GetValue("vBackup_New").ToString(), "yyyy/MM/dd")) < Convert.ToDateTime(n.FormatGreg(txtGDate.Text, "yyyy/MM/dd")))
                                {
                                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. لقد تخطيت السنة المالية المحدد للنظام \n يرجى التواصل مع الإدارة لللإشتراك في خدمات النسخة " : "We can not complete the operation .. have you skip the fiscal year specified for the system", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    return false;
                                }
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
        private T_GDHEAD GetData()
        {
            data_this.gdHDate = txtHDate.Text;
            data_this.gdGDate = txtGDate.Text;
            data_this.gdNo = textBox_ID.Text;
            data_this.ChekNo = txtChequeNo.Text;
            data_this.CurTyp = int.Parse(CmbCurr.SelectedValue.ToString());
            data_this.ArbTaf = ScriptNumber1.ScriptNum(decimal.Parse(VarGeneral.TString.TEmpty(string.Concat(txtTotalCredit.Value))));
            data_this.EngTaf = ScriptNumber1.TafEng(decimal.Parse(VarGeneral.TString.TEmpty(string.Concat(txtTotalCredit.Value))));
            data_this.gdCstNo = int.Parse(CmbCostC.SelectedValue.ToString());
            data_this.gdID = 0;
            data_this.gdLok = false;
            data_this.gdMem = txtReceivedForm.Text;
            if (CmbLegate.SelectedIndex > 0)
            {
                data_this.gdMnd = int.Parse(CmbLegate.SelectedValue.ToString());
            }
            else
            {
                data_this.gdMnd = null;
            }
            data_this.gdRcptID = (data_this.gdRcptID.HasValue ? data_this.gdRcptID.Value : 0.0);
            data_this.gdTot = txtTotalCredit.Value;
            data_this.gdTp = (data_this.gdTp.HasValue ? data_this.gdTp.Value : 0);
            data_this.gdTyp = 12;
            data_this.RefNo = txtRef.Text;
            if (!string.IsNullOrEmpty(txtInvNo.Text))
            {
                data_this.BName = txtInvNo.Tag.ToString();
            }
            else
            {
                data_this.BName = "";
            }
            if (State == FormState.New && VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 10))
            {
                data_this.AdminLock = true;
            }
            else
            {
                data_this.AdminLock = switchButton_Lock.Value;
            }
            data_this.salMonth = "";
            try
            {
                if (CmbLegate.SelectedIndex != -1)
                {
                    T_Mndob q = db.StockMndobID(int.Parse(CmbLegate.SelectedValue.ToString()));
                    if (q.Comm_Gaid.Value > 0.0 && txtTotalCredit.Value > 0.0)
                    {
                        data_this.CommMnd_Gaid = txtTotalCredit.Value * (q.Comm_Gaid.Value / 100.0);
                    }
                    else
                    {
                        data_this.CommMnd_Gaid = 0.0;
                    }
                }
                else
                {
                    data_this.CommMnd_Gaid = 0.0;
                }
            }
            catch
            {
                data_this.CommMnd_Gaid = 0.0;
            }
            data_this.CompanyID = 1;
            return data_this;
        }
        public void SetData(T_GDHEAD value)
        {
            switchButton_Lock.ValueChanged -= switchButton_Lock_ValueChanged;
            try
            {
                if (!RepetitionSts && !ReverseSts)
                {
                    State = FormState.Saved;
                    Button_Save.Enabled = false;
                    textBox_ID.Tag = value.gdhead_ID;
                    if (VarGeneral.CheckDate(value.gdGDate))
                    {
                        txtGDate.Text = Convert.ToDateTime(value.gdGDate).ToString("yyyy/MM/dd");
                    }
                    if (VarGeneral.CheckDate(value.gdHDate))
                    {
                        txtHDate.Text = Convert.ToDateTime(value.gdHDate).ToString("yyyy/MM/dd");
                    }
                    textBox_ID.Text = value.gdNo.Trim();
                }
                txtRef.Text = value.RefNo.Trim();
                try
                {
                    if (!string.IsNullOrEmpty(value.BName))
                    {
                        txtInvNo.Text = db.StockInvHeadID2(int.Parse(value.BName)).InvNo;
                        txtInvType.Text = ((LangArEn == 0) ? db.StockInvHeadID2(int.Parse(value.BName)).T_INVSETTING.InvNamA.Trim() : db.StockInvHeadID2(int.Parse(value.BName)).T_INVSETTING.InvNamE.Trim());
                        txtInvNo.Tag = value.BName.ToString();
                        VarGeneral._GaidInv = db.ExecuteQuery<T_INVHED>("select T_INVHED.ArbTaf, T_INVHED.CashPay, T_INVHED.CashPayLocCur, T_INVHED.chauffeurNo, T_INVHED.CommMnd_Inv, T_INVHED.CompanyID, T_INVHED.CREATED_BY, T_INVHED.CreditPay, T_INVHED.CreditPayLocCur, T_INVHED.CurTyp, T_INVHED.CustNet, T_INVHED.CustPri, T_INVHED.CustRep, T_INVHED.CusVenAdd, T_INVHED.CusVenNo, T_INVHED.CusVenTel, T_INVHED.DATE_CREATED, T_INVHED.DATE_MODIFIED, T_INVHED.EstDat, T_INVHED.ExtrnalCostGaidID, T_INVHED.GadeId, T_INVHED.GadeNo, T_INVHED.GDat, T_INVHED.HDat, T_INVHED.IfDel, T_INVHED.IfPrint, T_INVHED.IfRet, T_INVHED.IfTrans, T_INVHED.InvAddCost, T_INVHED.InvAddCostExtrnal, T_INVHED.InvAddCostExtrnalLoc, T_INVHED.InvAddCostLoc, T_INVHED.InvCash, T_INVHED.InvCashPay, T_INVHED.InvCashPayNm, T_INVHED.InvCost, T_INVHED.InvCstNo, T_INVHED.InvDisPrs, ((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints, T_INVHED.InvDisValLocCur, T_INVHED.InvHed_ID, T_INVHED.InvId, T_INVHED.InvNet, T_INVHED.InvNetLocCur, T_INVHED.InvNo, T_INVHED.InvQty, T_INVHED.InvTot, T_INVHED.InvTotLocCur, T_INVHED.InvTyp, T_INVHED.InvWight_T, T_INVHED.IsExtrnalGaid, T_INVHED.LTim, T_INVHED.MndExtrnal, T_INVHED.MndNo, T_INVHED.MODIFIED_BY, T_INVHED.NetworkPay, T_INVHED.NetworkPayLocCur, T_INVHED.OrderTyp,Puyaid, T_INVHED.RefNo, T_INVHED.Remark,Remming, T_INVHED.RetId, T_INVHED.RetNo, T_INVHED.RoomNo, T_INVHED.RoomPerson, T_INVHED.RoomSts, T_INVHED.SalsManNam, T_INVHED.SalsManNo, T_INVHED.ServiceValue, T_INVHED.Sts, T_INVHED.ToStore, T_INVHED.ToStoreNm,case when T_INVHED.CusVenNo <> '' then (select " + ((LangArEn == 0) ? " T_AccDef.Arb_Des " : " T_AccDef.Eng_Des") + " from T_AccDef where T_AccDef.AccDef_No = T_INVHED.CusVenNo) else T_INVHED.CusVenNm end as CusVenNm,case when T_INVHED.CusVenNo <> '' then (select T_AccDef.Mobile from T_AccDef where T_AccDef.AccDef_No = T_INVHED.CusVenNo) else '' end as CusVenAdd from T_INVHED where (InvHed_ID = " + data_this.BName + " and InvCashPay =1 and InvTyp=1) order by InvHed_ID", new object[0]).ToList();
                        if (VarGeneral._GaidInv.Count > 0)
                        {
                            double _totPaid = 0.0;
                            List<T_GDHEAD> _gd = db.ExecuteQuery<T_GDHEAD>("select * from T_GDHEAD where BName='" + VarGeneral._GaidInv.ToList()[0].InvHed_ID.ToString() + "' and gdLok =0 and gdTyp =" + VarGeneral.InvTyp, new object[0]).ToList();
                            _totPaid = 0.0;
                            try
                            {
                                _totPaid = _gd.Sum((T_GDHEAD global) => global.gdTot.Value);
                            }
                            catch
                            {
                                _totPaid = 0.0;
                            }
                            VarGeneral._GaidInv.ToList()[0].Puyaid = _totPaid;
                            VarGeneral._GaidInv.ToList()[0].Remming = VarGeneral._GaidInv[0].CreditPay.Value - _totPaid;
                            if (!string.IsNullOrEmpty(data_this.BName) && VarGeneral._GaidInv[0].InvHed_ID == int.Parse(data_this.BName))
                            {
                                T_INVHED T_INVHED = VarGeneral._GaidInv.ToList()[0];
                                T_INVHED.Puyaid -= data_this.gdTot.Value;
                                T_INVHED T_INVHED2 = VarGeneral._GaidInv.ToList()[0];
                                T_INVHED2.Remming += data_this.gdTot.Value;
                            }
                        }
                        TotRequest = VarGeneral._GaidInv.Where((T_INVHED t) => t.InvHed_ID == int.Parse(value.BName)).ToList().FirstOrDefault()
                            .Remming.Value;
                    }
                    else
                    {
                        txtInvNo.Text = "";
                        txtInvNo.Tag = "";
                        txtInvType.Text = "";
                        TotRequest = 0.0;
                        VarGeneral._GaidInv = new List<T_INVHED>();
                    }
                }
                catch
                {
                    txtInvNo.Text = "";
                    txtInvNo.Tag = "";
                    txtInvType.Text = "";
                    TotRequest = 0.0;
                }
                txtTotalCredit.Value = value.gdTot.Value;
                txtTotalDebit.Value = value.gdTot.Value;
                txtReceivedForm.Text = value.gdMem;
                if (!RepetitionSts && !ReverseSts)
                {
                    switchButton_Lock.Value = value.AdminLock.Value;
                    try
                    {
                        if (data_this.AdminLock.HasValue)
                        {
                            if (!data_this.AdminLock.Value)
                            {
                                label_LockeName.Text = ((LangArEn == 0) ? "غير مقف\u0651ــلة" : "Unlocked");
                            }
                            else
                            {
                                label_LockeName.Text = ((LangArEn == 0) ? ("أقفلها المسؤول : \n" + dbc.RateUsr(data_this.MODIFIED_BY).UsrNamA) : ("Closed By :\n" + dbc.RateUsr(data_this.MODIFIED_BY).UsrNamE));
                            }
                        }
                        else
                        {
                            label_LockeName.Text = ((LangArEn == 0) ? "غير مقف\u0651ــلة" : "Unlocked");
                        }
                    }
                    catch
                    {
                        label_LockeName.Text = ((LangArEn == 0) ? "غير مقف\u0651ــلة" : "Unlocked");
                    }
                }
                for (int iiCnt = 0; iiCnt < CmbCostC.Items.Count; iiCnt++)
                {
                    CmbCostC.SelectedIndex = iiCnt;
                    if (CmbCostC.SelectedValue != null && CmbCostC.SelectedValue.ToString() == value.gdCstNo.ToString().Trim())
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
                if (value.gdMnd.HasValue)
                {
                    CmbLegate.SelectedValue = value.gdMnd;
                }
                else
                {
                    CmbLegate.SelectedIndex = 0;
                }
                LDataThis = new BindingList<T_GDDET>(value.T_GDDETs).OrderBy((T_GDDET g) => g.Lin.Value).ToList();
                SetLines(LDataThis);
                Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
                if (!RepetitionSts && !ReverseSts)
                {
                    try
                    {
                        List<T_Sal> returned3 = db.SelectSalsReturnNo(DataThis.gdhead_ID).ToList();
                        if (returned3.Count > 0)
                        {
                            CanEdit = false;
                            IfDelete = false;
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        List<T_Advance> returned2 = db.SelectAdvanceReturnNo(DataThis.gdhead_ID).ToList();
                        if (returned2.Count > 0)
                        {
                            CanEdit = false;
                            IfDelete = false;
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        List<T_Salary> returned = db.SelectSalaryReturnNo(DataThis.gdhead_ID).ToList();
                        if (returned.Count > 0)
                        {
                            CanEdit = false;
                            IfDelete = false;
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SetData:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            switchButton_Lock.ValueChanged += switchButton_Lock_ValueChanged;
        }
        public void SetLines(List<T_GDDET> listDet)
        {
            try
            {
                T_GDDET _GdDet = new T_GDDET();
                if (!RepetitionSts && !ReverseSts)
                {
                    c1FlexGrid1.Rows.Count = listDet.Count;
                }
                if (listDet.Count == 0)
                {
                    return;
                }
                _GdDet = listDet[0];
                txtAccNo.Text = _GdDet.AccNo.ToString().Trim();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtAccNameR.Text = _GdDet.T_AccDef.Arb_Des.ToString();
                }
                else
                {
                    txtAccNameR.Text = _GdDet.T_AccDef.Eng_Des.ToString();
                }
                txtGedDes.Text = _GdDet.gdDes.ToString();
                txtGedDesE.Text = _GdDet.gdDesE.ToString();
                for (int iiCnt = 1; iiCnt < listDet.Count; iiCnt++)
                {
                    _GdDet = listDet[iiCnt];
                    int Lin = _GdDet.Lin.Value;
                    c1FlexGrid1.SetData(Lin, 0, Lin.ToString());
                    c1FlexGrid1.SetData(Lin, 1, _GdDet.AccNo.ToString());
                    c1FlexGrid1.SetData(Lin, 2, _GdDet.T_AccDef.Arb_Des.ToString());
                    c1FlexGrid1.SetData(Lin, 3, _GdDet.T_AccDef.Eng_Des.ToString());
                    c1FlexGrid1.SetData(Lin, 4, _GdDet.gdDes.ToString());
                    c1FlexGrid1.SetData(Lin, 5, _GdDet.gdDesE.ToString());
                    if (_GdDet.gdValue.Value > 0.0)
                    {
                        c1FlexGrid1.SetData(Lin, 6, _GdDet.gdValue.ToString());
                        c1FlexGrid1.SetData(Lin, 7, 0);
                    }
                    else
                    {
                        c1FlexGrid1.SetData(Lin, 7, Math.Abs(decimal.Parse(VarGeneral.TString.TEmpty(string.Concat(_GdDet.gdValue.Value)))));
                        c1FlexGrid1.SetData(Lin, 6, 0);
                    }
                }
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "حدث خطأ أثناء تعبئة الأسطر .." : "An error occurred while filling lines ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
            listAccDef = new List<T_AccDef>();
            _InvSetting = db.StockInvSetting(VarGeneral.UserID, VarGeneral.InvTyp);
            _SysSetting = db.SystemSettingStock();
            listAccDef = db.StockAccDefList();
        }
        private void FillCombo()
        {
            int _CmbIndex = CmbCurr.SelectedIndex;
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
            _CmbIndex = CmbLegate.SelectedIndex;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                List<T_Mndob> listMnd = new List<T_Mndob>(db.T_Mndobs.Where((T_Mndob item) => item.Mnd_Typ.Value == 0).ToList());
                listMnd.Insert(0, new T_Mndob());
                CmbLegate.DataSource = listMnd;
                CmbLegate.DisplayMember = "Arb_Des";
                CmbLegate.ValueMember = "Mnd_ID";
            }
            else
            {
                List<T_Mndob> listMnd = new List<T_Mndob>(db.T_Mndobs.Where((T_Mndob item) => item.Mnd_Typ.Value == 0).ToList());
                listMnd.Insert(0, new T_Mndob());
                CmbLegate.DataSource = listMnd;
                CmbLegate.DisplayMember = "Eng_Des";
                CmbLegate.ValueMember = "Mnd_ID";
            }
            CmbLegate.SelectedIndex = _CmbIndex;
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
        }
        private void ArbEng()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                LangArEn = 0;
                c1FlexGrid1.Cols[1].Caption = "رقم الحساب";
                c1FlexGrid1.Cols[2].Visible = true;
                c1FlexGrid1.Cols[3].Visible = false;
                c1FlexGrid1.Cols[4].Caption = "البيـــان - عربي";
                c1FlexGrid1.Cols[5].Caption = "البيــان - إنجليزي";
                c1FlexGrid1.Cols[6].Caption = "مــدين";
                c1FlexGrid1.Cols[7].Caption = "دائــن";
                c1FlexGrid1.Cols[6].Visible = false;
            }
            else
            {
                LangArEn = 1;
                c1FlexGrid1.Cols[1].Caption = "Acc Name";
                c1FlexGrid1.Cols[2].Visible = false;
                c1FlexGrid1.Cols[3].Visible = true;
                c1FlexGrid1.Cols[4].Caption = "Description - Ar";
                c1FlexGrid1.Cols[5].Caption = "Description - En";
                c1FlexGrid1.Cols[6].Caption = "Debit";
                c1FlexGrid1.Cols[7].Caption = "Credit";
                c1FlexGrid1.Cols[6].Visible = false;
            }
            RibunButtons();
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
                T_GDHEAD newData = db.StockGDHEAD(VarGeneral.InvTyp, no);
                if (newData == null || string.IsNullOrEmpty(newData.gdNo))
                {
                    if (!Button_Add.Visible || !Button_Add.Enabled)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textBox_ID.TextChanged -= textBox_ID_TextChanged;
                        try
                        {
                            textBox_ID.Text = data_this.gdNo;
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
                    int indexA = PKeys.IndexOf(newData.gdNo ?? "");
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
            UpdateVcr();
            if (State == FormState.Saved)
            {
                button_Repetition.Enabled = true;
                Button_PrintTableMulti.Enabled = true;
            }
            else
            {
                button_Repetition.Enabled = false;
                Button_PrintTableMulti.Enabled = false;
            }
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
        private void ADD_Controls()
        {
            try
            {
                controls = new List<Control>();
                controls.Add(textBox_ID);
                codeControl = textBox_ID;
                controls.Add(textBox_Type);
                controls.Add(txtBalance);
                controls.Add(txtTotalCredit);
                controls.Add(txtTotalDebit);
                controls.Add(txtGDate);
                controls.Add(txtHDate);
                controls.Add(txtRef);
                controls.Add(txtGedDes);
                controls.Add(txtGedDesE);
                controls.Add(CmbCostC);
                controls.Add(CmbCurr);
                controls.Add(CmbLegate);
                controls.Add(txtAccNo);
                controls.Add(txtReceivedForm);
                controls.Add(txtAccNameR);
                controls.Add(txtInvNo);
                controls.Add(txtInvType);
                controls.Add(txtFatherAccName);
            }
            catch (SqlException)
            {
            }
        }
        private void txtHDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtHDate.Text))
                {
                    txtHDate.Text = Convert.ToDateTime(txtHDate.Text).ToString("yyyy/MM/dd");
                    txtHDate.Text = n.FormatHijri(txtHDate.Text, "yyyy/MM/dd");
                    txtGDate.Text = n.HijriToGreg(txtHDate.Text, "yyyy/MM/dd");
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
                    txtHDate.Text = n.GregToHijri(txtGDate.Text, "yyyy/MM/dd");
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
        private void txtGDate_Click(object sender, EventArgs e)
        {
            txtGDate.SelectAll();
        }
        private bool SaveData()
        {
            string max;
            Exception ex;
            Stock_DataDataContext _DB;
            bool flag;
            object[] dataThis;
            if (this.State == FormState.New)
            {
                this.dbInstance = null;
            }
            if (this.ValidData())
            {
                try
                {
                    IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
                    if (this.State != FormState.New)
                    {
                        this.GetData();
                        this.data_this.MODIFIED_BY = VarGeneral.UserNumber;
                        this.db.Log = VarGeneral.DebugLog;
                        this.db.SubmitChanges(ConflictMode.ContinueOnConflict);
                        for (int i = 0; i < this.data_this.T_GDDETs.Count; i++)
                        {
                            db_.StartTransaction();
                            db_.ClearParameters();
                            db_.AddParameter("GDDET_ID", DbType.Int32, this.data_this.T_GDDETs[i].GDDET_ID);
                            db_.ExecuteNonQueryWithoutCommit(true, "S_T_GDDET_DELETE");
                            db_.EndTransaction();
                        }
                    }
                    else
                    {
                        Stock_DataDataContext dbGaid = new Stock_DataDataContext(VarGeneral.BranchCS);
                        try
                        {
                            try
                            {
                                this.GetInvSetting();
                                this.textBox_ID.TextChanged -= new EventHandler(this.textBox_ID_TextChanged);
                                this.data_this = new T_GDHEAD();
                                this.GetData();
                                max = "";
                                max = dbGaid.MaxGDHEADsNo.ToString();
                                this.textBox_ID.Text = max ?? "";
                                this.data_this.gdNo = max ?? "";
                                this.textBox_ID.TextChanged += new EventHandler(this.textBox_ID_TextChanged);
                                this.data_this.DATE_CREATED = new DateTime?(DateTime.Now);
                                this.data_this.gdUser = VarGeneral.UserNumber;
                                this.data_this.gdUserNam = VarGeneral.UserNameA;
                                this.data_this.MODIFIED_BY = "";
                                dbGaid.T_GDHEADs.InsertOnSubmit(this.data_this);
                                dbGaid.SubmitChanges();
                            }
                            catch (SqlException sqlException)
                            {
                                SqlException edx = sqlException;
                                max = "";
                                max = dbGaid.MaxGDHEADsNo.ToString();
                                if (edx.Number == 2627)
                                {
                                    MessageBox.Show(string.Concat("الرمز مستخدم من قبل.\n سيتم الحفظ برقم جديد [", max, "]"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    this.textBox_ID.Text = max ?? "";
                                    this.data_this.gdNo = max ?? "";
                                    this.Button_Save_Click(null, null);
                                }
                            }
                            catch (Exception exception)
                            {
                                ex = exception;
                                VarGeneral.DebLog.writeLog("SaveData Er:", ex, true);
                                MessageBox.Show(ex.Message);
                                flag = false;
                                return flag;
                            }
                        }
                        finally
                        {
                            if (dbGaid != null)
                            {
                                ((IDisposable)dbGaid).Dispose();
                            }
                        }
                    }
                    db_ = Database.GetDatabase(VarGeneral.BranchCS);
                    db_.StartTransaction();
                    db_.ClearParameters();
                    db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                    db_.AddParameter("gdID", DbType.Int32, this.data_this.gdhead_ID);
                    db_.AddParameter("gdNo", DbType.String, this.textBox_ID.Text);
                    db_.AddParameter("gdDes", DbType.String, this.txtGedDes.Text);
                    db_.AddParameter("gdDesE", DbType.String, this.txtGedDesE.Text);
                    db_.AddParameter("recptTyp", DbType.String, "12");
                    db_.AddParameter("AccNo", DbType.String, this.txtAccNo.Text);
                    db_.AddParameter("AccName", DbType.String, this.txtAccNameR.Text);
                    db_.AddParameter("gdValue", DbType.Double, this.txtTotalCredit.Value);
                    db_.AddParameter("recptNo", DbType.String, this.textBox_ID.Text);
                    db_.AddParameter("Lin", DbType.Int32, 0);
                    db_.AddParameter("AccNoDestruction", DbType.String, null);
                    db_.ExecuteNonQueryWithoutCommit(true, "S_T_GDDET_INSERT");
                    db_.EndTransaction();
                    int iiCnt = 0;
                    for (iiCnt = 1; iiCnt < this.c1FlexGrid1.Rows.Count; iiCnt++)
                    {
                        try
                        {
                            if (this.c1FlexGrid1.GetData(iiCnt, 1) != null)
                            {
                                db_.StartTransaction();
                                db_.ClearParameters();
                                db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                                db_.AddParameter("gdID", DbType.Int32, this.data_this.gdhead_ID);
                                db_.AddParameter("gdNo", DbType.String, this.textBox_ID.Text);
                                db_.AddParameter("gdDes", DbType.String, this.c1FlexGrid1.GetData(iiCnt, 4).ToString());
                                try
                                {
                                    db_.AddParameter("gdDesE", DbType.String, this.c1FlexGrid1.GetData(iiCnt, 5).ToString());
                                }
                                catch
                                {
                                    db_.AddParameter("gdDesE", DbType.String, " ");
                                }
                                db_.AddParameter("recptTyp", DbType.String, "12");
                                db_.AddParameter("AccNo", DbType.String, this.c1FlexGrid1.GetData(iiCnt, 1).ToString());
                                db_.AddParameter("AccName", DbType.String, this.c1FlexGrid1.GetData(iiCnt, 2).ToString());
                                if (double.Parse(this.c1FlexGrid1.GetData(iiCnt, 6).ToString()) > 0)
                                {
                                    db_.AddParameter("gdValue", DbType.Double, double.Parse(this.c1FlexGrid1.GetData(iiCnt, 6).ToString()));
                                }
                                else if (double.Parse(this.c1FlexGrid1.GetData(iiCnt, 7).ToString()) > 0)
                                {
                                    db_.AddParameter("gdValue", DbType.Double, -double.Parse(this.c1FlexGrid1.GetData(iiCnt, 7).ToString()));
                                }
                                db_.AddParameter("recptNo", DbType.String, this.textBox_ID.Text);
                                db_.AddParameter("Lin", DbType.Int32, iiCnt);
                                db_.AddParameter("AccNoDestruction", DbType.String, null);
                                db_.ExecuteNonQueryWithoutCommit(true, "S_T_GDDET_INSERT");
                                db_.EndTransaction();
                            }
                        }
                        catch
                        {
                            //             goto Label1;
                        }
                    }
                    this.dbInstance = null;
                    this.textBox_ID_TextChanged(null, null);
                    MessageBox.Show((FMReceiptVoucher.LangArEn == 0 ? "تمت عملية حفظ البيانات بنجاح .." : "Save Data Is Done"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    try
                    {
                        _DB = new Stock_DataDataContext(VarGeneral.BranchCS);
                        try
                        {
                            if ((
                                from t in _DB.T_GDDETs
                                where t.gdNo == this.data_this.gdNo
                                where t.T_GDHEAD.gdTyp == (int?)VarGeneral.InvTyp
                                select t).ToList<T_GDDET>().Count <= 0)
                            {
                                dataThis = new object[] { "DELETE FROM [T_GDHEAD] WHERE gdNo = '", this.data_this.gdNo, "' and gdTyp =", VarGeneral.InvTyp };
                                _DB.ExecuteCommand(string.Concat(dataThis), new object[0]);
                                this.textBox_ID_TextChanged(null, null);
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
                    catch
                    {
                    }
                }
                catch (Exception exception1)
                {
                    ex = exception1;
                    try
                    {
                        _DB = new Stock_DataDataContext(VarGeneral.BranchCS);
                        try
                        {
                            if ((
                                from t in _DB.T_GDDETs
                                where t.gdNo == this.data_this.gdNo
                                where t.T_GDHEAD.gdTyp == (int?)VarGeneral.InvTyp
                                select t).ToList<T_GDDET>().Count <= 0)
                            {
                                dataThis = new object[] { "DELETE FROM [T_GDHEAD] WHERE gdNo = '", this.data_this.gdNo, "' and gdTyp =", VarGeneral.InvTyp };
                                _DB.ExecuteCommand(string.Concat(dataThis), new object[0]);
                                this.textBox_ID_TextChanged(null, null);
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
                    catch
                    {
                    }
                    MessageBox.Show(ex.Message);
                    flag = false;
                    return flag;
                }
                flag = true;
            }
            else
            {
                flag = false;
            }
            return flag;
        }
        private void txtHDate_Click(object sender, EventArgs e)
        {
            txtHDate.SelectAll();
        }
        private void txtGDate_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("English");
        }
        private void txtHDate_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("Arabic");
        }
        private void c1FlexGrid1_AfterEdit(object sender, RowColEventArgs e)
        {
            if (e.Col == 1 || e.Col == 2 || e.Col == 3)
            {
                if (!string.IsNullOrEmpty(txtInvNo.Text))
                {
                    txtInvNo.Text = "";
                    txtInvNo.Tag = "";
                    txtInvType.Text = "";
                    TotRequest = 0.0;
                    c1FlexGrid1.Rows.Count = 100;
                }
                List<T_AccDef> listAccDefSer = new List<T_AccDef>();
                listAccDefSer = db.T_AccDefs.Where((T_AccDef t) => t.AccDef_ID == 0).ToList();
                if (e.Col == 1 && c1FlexGrid1.GetData(e.Row, e.Col).ToString() != "")
                {
                    listAccDefSer = (from t in db.T_AccDefs
                                     where t.AccDef_No == c1FlexGrid1.GetData(e.Row, e.Col).ToString()
                                     where t.Sts == (int?)0
                                     where t.Lev == (int?)4
                                     select t).ToList();
                }
                else if (e.Col == 2 && c1FlexGrid1.GetData(e.Row, e.Col).ToString() != "")
                {
                    listAccDefSer = (from t in db.T_AccDefs
                                     where t.Arb_Des == c1FlexGrid1.GetData(e.Row, e.Col).ToString()
                                     where t.Sts == (int?)0
                                     where t.Lev == (int?)4
                                     select t).ToList();
                }
                else if (e.Col == 3 && c1FlexGrid1.GetData(e.Row, e.Col).ToString() != "")
                {
                    listAccDefSer = (from t in db.T_AccDefs
                                     where t.Eng_Des == c1FlexGrid1.GetData(e.Row, e.Col).ToString()
                                     where t.Sts == (int?)0
                                     where t.Lev == (int?)4
                                     select t).ToList();
                }
                if (listAccDefSer.Count == 0)
                {
                    if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 31))
                    {
                        string _SearchNo = "";
                        RepShow _RepShow = new RepShow();
                        _RepShow.Tables = " T_AccDef ";
                        string Fields = "";
                        Fields = ((LangArEn != 0) ? " T_AccDef.AccDef_ID as [ID_Number], T_AccDef.AccDef_No as [No] , T_AccDef.Arb_Des as [Arabic Name], T_AccDef.Eng_Des as [English Name] " : " T_AccDef.AccDef_ID as [رقم_التعريف], T_AccDef.AccDef_No as [الرقم] , T_AccDef.Arb_Des as [الاسم عربي], T_AccDef.Eng_Des as [الاسم إنجليزي] ");
                        if (VarGeneral.SSSTyp == 0)
                        {
                            GetInvSetting();
                            _RepShow.Rule = " Where 1 = 1 and T_AccDef.Lev = 4 and T_AccDef.Sts = 0 and T_AccDef.StopedState = 0 and AccCat = " + VarGeneral.AccTyp;
                            if ((VarGeneral.TString.ChkStatShow(_SysSetting.Seting, VarGeneral.AccTyp) && VarGeneral.AccTyp != 8) || VarGeneral.StockOnly)
                            {
                                _RepShow.Rule = " Where (T_AccDef.Lev = 4 and T_AccDef.Sts = 0 and T_AccDef.StopedState = 0) and ( AccCat = 4 or AccCat = 5 ) or (" + (VarGeneral.StockOnly ? " AccDef_No = '4011001' " : " 1 = 1") + ")";
                                if (VarGeneral.SSSTyp == 0 && VarGeneral.InvTyp == 555)
                                {
                                    try
                                    {
                                        _RepShow.Rule += " or AccDef_No = '1020001' ";
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                            else if (VarGeneral.TString.ChkStatShow(_SysSetting.Seting, 6))
                            {
                                _RepShow.Rule = " Where 1 = 1 and T_AccDef.Lev = 4 and T_AccDef.Sts = 0 and T_AccDef.StopedState = 0";
                            }
                        }
                        else
                        {
                            _RepShow.Rule = " Where 1 = 1 and T_AccDef.Lev = 4 and T_AccDef.Sts = 0 and T_AccDef.StopedState = 0";
                        }
                        if (!string.IsNullOrEmpty(Fields))
                        {
                            _RepShow.Fields = Fields;
                            _RepShow = _RepShow.Save();
                            VarGeneral.RepData = _RepShow.RepData;
                            if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                            {
                                FMFind FmQuikSerch = new FMFind((string)c1FlexGrid1.GetData(e.Row, e.Col), e.Col);
                                FmQuikSerch.Tag = LangArEn;
                                FmQuikSerch.TopMost = true;
                                FmQuikSerch.ShowDialog();
                                _SearchNo = FmQuikSerch.SerachNo;
                            }
                        }
                        if (_SearchNo != "")
                        {
                            _AccDef = db.StockAccDefs_OnlyGaid(int.Parse(_SearchNo));
                            c1FlexGrid1.SetData(e.Row, 1, _AccDef.AccDef_No.ToString());
                            c1FlexGrid1.SetData(e.Row, 2, _AccDef.Arb_Des.ToString());
                            c1FlexGrid1.SetData(e.Row, 3, _AccDef.Eng_Des.ToString());
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                            {
                                txtAccName.Text = _AccDef.Arb_Des.ToString();
                            }
                            else
                            {
                                txtAccName.Text = _AccDef.Eng_Des.ToString();
                            }
                            txtBalance.Value = _AccDef.Balance.Value;
                        }
                    }
                    else
                    {
                        columns_Names_visible2.Clear();
                        columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
                        columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
                        columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
                        columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
                        columns_Names_visible2.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, ""));
                        columns_Names_visible2.Add("TaxNo", new ColumnDictinary("الرقم الضريبي", "Tax No", ifDefault: false, ""));
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
                        }
                        else
                        {
                            VarGeneral.SFrmTyp = "AccDefID_Setting";
                        }
                        VarGeneral.itmDes = (string)c1FlexGrid1.GetData(e.Row, e.Col);
                        VarGeneral.itmDesIndex = e.Col;
                        frm.TopMost = true;
                        frm.ShowDialog();
                        if (frm.SerachNo != "")
                        {
                            _AccDef = db.StockAccDefs_OnlyGaid(int.Parse(frm.Serach_No));
                            c1FlexGrid1.SetData(e.Row, 1, _AccDef.AccDef_No.ToString());
                            c1FlexGrid1.SetData(e.Row, 2, _AccDef.Arb_Des.ToString());
                            c1FlexGrid1.SetData(e.Row, 3, _AccDef.Eng_Des.ToString());
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                            {
                                txtAccName.Text = _AccDef.Arb_Des.ToString();
                            }
                            else
                            {
                                txtAccName.Text = _AccDef.Eng_Des.ToString();
                            }
                            txtBalance.Text = _AccDef.Balance.ToString();
                        }
                    }
                }
                else
                {
                    _AccDef = listAccDefSer[0];
                    c1FlexGrid1.SetData(e.Row, 1, _AccDef.AccDef_No.ToString());
                    c1FlexGrid1.SetData(e.Row, 2, _AccDef.Arb_Des.ToString());
                    c1FlexGrid1.SetData(e.Row, 3, _AccDef.Eng_Des.ToString());
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtAccName.Text = _AccDef.Arb_Des.ToString();
                    }
                    else
                    {
                        txtAccName.Text = _AccDef.Eng_Des.ToString();
                    }
                    txtBalance.Text = _AccDef.Balance.ToString();
                }
                VarGeneral.Flush();
            }
            else if (e.Col == 6)
            {
                try
                {
                    if (double.Parse(VarGeneral.TString.TEmpty(c1FlexGrid1.GetData(e.Row, 6).ToString())) > 0.0)
                    {
                        c1FlexGrid1.SetData(e.Row, 7, 0);
                    }
                }
                catch
                {
                }
            }
            else
            {
                if (e.Col != 7)
                {
                    return;
                }
                try
                {
                    if (double.Parse(VarGeneral.TString.TEmpty(c1FlexGrid1.GetData(e.Row, 7).ToString())) > 0.0)
                    {
                        c1FlexGrid1.SetData(e.Row, 6, 0);
                    }
                }
                catch
                {
                }
            }
        }
        private void c1FlexGrid1_AfterRowColChange(object sender, RangeEventArgs e)
        {
            try
            {
                if (State == FormState.Saved || !(VarGeneral.TString.TEmpty(string.Concat(c1FlexGrid1.GetData(e.OldRange.r1, 1))) != ""))
                {
                    return;
                }
                double RowVal = 0.0;
                txtTotalCredit.Value = 0.0;
                txtTotalDebit.Value = 0.0;
                for (int iiCnt = 1; iiCnt < c1FlexGrid1.Rows.Count && (string)c1FlexGrid1.GetData(iiCnt, 1) != null; iiCnt++)
                {
                    RowVal = double.Parse("0" + c1FlexGrid1.GetData(iiCnt, 6));
                    txtTotalDebit.Value += RowVal;
                    RowVal = double.Parse("0" + c1FlexGrid1.GetData(iiCnt, 7));
                    txtTotalCredit.Value += RowVal;
                }
                if ((string)c1FlexGrid1.GetData(c1FlexGrid1.Row, 1) != "" && c1FlexGrid1.GetData(c1FlexGrid1.Row, 1) != null)
                {
                    List<T_AccDef> listAccDefSer = new List<T_AccDef>();
                    listAccDefSer = (from t in db.T_AccDefs
                                     where t.AccDef_No == c1FlexGrid1.GetData(c1FlexGrid1.Row, 1).ToString().Trim()
                                     where t.Sts == (int?)0
                                     where t.Lev == (int?)4
                                     select t).ToList();
                    if (listAccDefSer.Count == 0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "رقم الحساب يدل على انه موقوف او انه ليس حساب حركة .." : "Account number indicates that he was not arrested or movement account ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        c1FlexGrid1.SetData(c1FlexGrid1.Row, 1, "");
                        c1FlexGrid1.SetData(c1FlexGrid1.Row, 2, "");
                        c1FlexGrid1.SetData(c1FlexGrid1.Row, 3, "");
                        c1FlexGrid1.Row = e.OldRange.r1;
                        c1FlexGrid1.Col = 1;
                    }
                }
                if (double.Parse("0" + c1FlexGrid1.GetData(c1FlexGrid1.Row, 6)) > 0.0)
                {
                    c1FlexGrid1.SetData(c1FlexGrid1.Row, 7, 0);
                }
                else if (double.Parse("0" + c1FlexGrid1.GetData(e.OldRange.r1, 7)) > 0.0)
                {
                    c1FlexGrid1.SetData(e.OldRange.r1, 6, 0);
                }
            }
            catch
            {
            }
        }
        private void c1FlexGrid1_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            if (!((string)c1FlexGrid1.GetData(c1FlexGrid1.Row, 1) != "") || c1FlexGrid1.GetData(c1FlexGrid1.Row, 1) == null)
            {
                return;
            }
            List<T_AccDef> listAccDefSer = new List<T_AccDef>();
            listAccDefSer = (from t in db.T_AccDefs
                             where t.AccDef_No == c1FlexGrid1.GetData(c1FlexGrid1.Row, 1).ToString().Trim()
                             where t.Sts == (int?)0
                             where t.Lev == (int?)4
                             select t).ToList();
            if (listAccDefSer.Count() > 0)
            {
                try
                {
                    listAccDefSer.First().Debit = db.ExecuteQuery<double>(" select sum(Round(T_GDDET.gdValue," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) from T_GDDET INNER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID where T_GDHEAD.gdLok = 0 and T_GDDET.gdValue > 0 and T_GDDET.AccNo ='" + listAccDefSer.First().AccDef_No + "'", new object[0]).FirstOrDefault();
                }
                catch
                {
                    listAccDefSer.First().Debit = 0.0;
                }
                try
                {
                    listAccDefSer.First().Credit = Math.Abs(db.ExecuteQuery<double>(" select sum(Round(T_GDDET.gdValue," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) from T_GDDET INNER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID where T_GDHEAD.gdLok = 0 and T_GDDET.gdValue < 0 and T_GDDET.AccNo ='" + listAccDefSer.First().AccDef_No + "'", new object[0]).FirstOrDefault());
                }
                catch
                {
                    listAccDefSer.First().Credit = 0.0;
                }
                try
                {
                    listAccDefSer.First().Balance = db.ExecuteQuery<double>(" select sum(Round(T_GDDET.gdValue," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) from T_GDDET INNER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID where T_GDHEAD.gdLok = 0 and T_GDDET.AccNo ='" + listAccDefSer.First().AccDef_No + "'", new object[0]).FirstOrDefault();
                }
                catch
                {
                    listAccDefSer.First().Balance = 0.0;
                }
                _AccDef = listAccDefSer[0];
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtAccName.Text = _AccDef.Arb_Des.ToString();
                }
                else
                {
                    txtAccName.Text = _AccDef.Eng_Des.ToString();
                }
                txtBalance.Text = _AccDef.Balance.ToString();
            }
        }
        private void c1FlexGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                c1FlexGrid1.RemoveItem(c1FlexGrid1.Row);
                double RowVal = 0.0;
                txtTotalCredit.Text = "0";
                txtTotalDebit.Text = "0";
                for (int iiCnt = 1; iiCnt < c1FlexGrid1.Rows.Count && (string)c1FlexGrid1.GetData(iiCnt, 1) != null; iiCnt++)
                {
                    RowVal = double.Parse("0" + c1FlexGrid1.GetData(iiCnt, 6));
                    txtTotalDebit.Text = (double.Parse(txtTotalDebit.Text) + RowVal).ToString();
                    RowVal = double.Parse("0" + c1FlexGrid1.GetData(iiCnt, 7));
                    txtTotalCredit.Text = (double.Parse(txtTotalCredit.Text) + RowVal).ToString();
                }
            }
            else if (e.KeyCode == Keys.Insert && c1FlexGrid1.Col == 4 && c1FlexGrid1.Row >= 2)
            {
                c1FlexGrid1.SetData(c1FlexGrid1.Row, c1FlexGrid1.Col, c1FlexGrid1.GetData(c1FlexGrid1.Row - 1, c1FlexGrid1.Col));
            }
            else if (e.KeyCode == Keys.Insert && c1FlexGrid1.Col == 5 && c1FlexGrid1.Row >= 2)
            {
                c1FlexGrid1.SetData(c1FlexGrid1.Row, c1FlexGrid1.Col, c1FlexGrid1.GetData(c1FlexGrid1.Row - 1, c1FlexGrid1.Col));
            }
        }
        private void c1FlexGrid1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (string.Concat(c1FlexGrid1.GetData(c1FlexGrid1.RowSel, 1)) != "")
                {
                    _AccFather = new T_AccDef();
                    T_AccDef newData = db.StockAccDefWithOutBalance(string.Concat(c1FlexGrid1.GetData(c1FlexGrid1.RowSel, 1)));
                    if (newData == null || string.IsNullOrEmpty(newData.AccDef_No))
                    {
                        txtFatherAccName.Text = "";
                        return;
                    }
                    _AccFather = db.StockAccDefWithOutBalance(newData.ParAcc);
                    txtFatherAccName.Text = ((LangArEn == 0) ? ("  حســاب الأب   |   " + _AccFather.Arb_Des) : ("  Father Account  |  " + _AccFather.Eng_Des));
                }
            }
            catch
            {
                _AccFather = new T_AccDef();
                txtFatherAccName.Text = "";
            }
        }
        private void c1FlexGrid1_RowColChange(object sender, EventArgs e)
        {
            if (c1FlexGrid1.Col == 1)
            {
                Framework.Keyboard.Language.Switch("English");
            }
            if (c1FlexGrid1.Col == 2)
            {
                Framework.Keyboard.Language.Switch("Arabic");
            }
            if (c1FlexGrid1.Col == 3)
            {
                Framework.Keyboard.Language.Switch("English");
            }
        }
        private void Frm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }int kk = 0;
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter && c1FlexGrid1.ColSel == 1) || (e.KeyCode == Keys.Enter && kk == 1))
            {
                {
                    SendKeys.Send("{Tab}");
                }
            }

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
                if (State == FormState.Saved || VarGeneral.vPaidInv)
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
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FMReceiptVoucher));
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
                buttonItem_Print.Text = ((_InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1) == "0") ? "طباعة" : "عــرض");
                buttonItem_Print.Tooltip = "F5";
                Button_PrintTableMulti.Text = "طباعة السندات المحددة";
                Button_ExportTable2.Text = "تصدير";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "جميع السجلات";
                Button_PrintTable.Text = "عــرض";
                Label1.Text = "رقم السند :";
                Label2.Text = "التاريــــــــخ :";
                label7.Text = "رقم المرجع :";
                label12.Text = "رقم الفاتورة :";
                label19.Text = "العملة :";
                label18.Text = "المنـــــدوب :";
                label15.Text = "مركز التكلفـــــة :";
                label6.Text = "الحســــاب :";
                label3.Text = "قيمة المدين";
                Label21.Text = "قيمة الدائن";
                label17.Text = "الرصيد";
                label8.Text = "إستلمنا من :";
                label4.Text = "حساب المدين :";
                Text = "سند قبض";
                switchButton_Lock.OffText = "لم يتم الموافقة";
                switchButton_Lock.OnText = "تمت الموافقة";
                button_Repetition.Text = "تكرار القيد";
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
                buttonItem_Print.Text = ((_InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1) == "0") ? "Print" : "Show");
                buttonItem_Print.Tooltip = "F5";
                Button_PrintTableMulti.Text = "Print of the Bounds selected";
                Button_ExportTable2.Text = "Export";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "All Records";
                Button_PrintTable.Text = "Show";
                Label1.Text = "Number :";
                Label2.Text = "Date :";
                label7.Text = "Reference No :";
                label12.Text = "Inv No :";
                label19.Text = "Curr :";
                label18.Text = "Delegate :";
                label15.Text = "Cost Center :";
                label6.Text = "Account :";
                label3.Text = "Debtor";
                Label21.Text = "Creditor";
                label17.Text = "Balance";
                label8.Text = "Received from :";
                label4.Text = "Debtor account :";
                Text = "Catch";
                switchButton_Lock.OffText = "not approved";
                switchButton_Lock.OnText = "Been approved";
                button_Repetition.Text = "Repetition";
            }
        }
        private void FMReceiptVoucher_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FMReceiptVoucher));
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
                if (VarGeneral.SSSTyp == 1)
                {
                    label12.Visible = false;
                    txtInvNo.Visible = false;
                    button_SrchInvNo.Visible = false;
                    txtInvType.Visible = false;
                }
                Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
                if (columns_Names_visible.Count == 0)
                {
                    columns_Names_visible.Add("gdNo", new ColumnDictinary("رقم القيد", "Gaid No", ifDefault: true, ""));
                    columns_Names_visible.Add("gdHDate", new ColumnDictinary("التاريخ الهجري", "Date Hijri", ifDefault: true, ""));
                    columns_Names_visible.Add("gdGDate", new ColumnDictinary("التاريخ الميلادي", "Date Gregorian", ifDefault: false, ""));
                    columns_Names_visible.Add("gdCstNo", new ColumnDictinary("مركز التكلفة", "Cost Center", ifDefault: true, ""));
                    columns_Names_visible.Add("gdUser", new ColumnDictinary("رقم المستخدم", "User No", ifDefault: false, ""));
                    columns_Names_visible.Add("gdUserNam", new ColumnDictinary("إسم المستخدم", "User Name", ifDefault: true, ""));
                    columns_Names_visible.Add("gdTot", new ColumnDictinary("القيمة", "Value", ifDefault: false, ""));
                    columns_Names_visible.Add("gdMem", new ColumnDictinary("ملاحظات", "Note", ifDefault: true, ""));
                    columns_Names_visible.Add("RefNo", new ColumnDictinary("رقم المرجع", "Ref No", ifDefault: false, ""));
                    columns_Names_visible.Add("BName", new ColumnDictinary("رقم الفاتورة", "Inv No", ifDefault: false, ""));
                }
                else
                {
                    Clear();
                    textBox_ID.Text = "";
                    TextBox_Index.TextBox.Text = "";
                }
                FillCombo();
                GetInvSetting();
                ArbEng();
                RefreshPKeys();
                if (VarGeneral.vGaidHotel)
                {
                    Button_Add_Click(sender, e);
                    c1FlexGrid1.SetData(1, 1, db.StockPer(VarGeneral._hotelper).Cust_no);
                    c1FlexGrid1_AfterEdit(sender, new RowColEventArgs(1, 1));
                    c1FlexGrid1.Rows.Count = 2;
                    c1FlexGrid1.Row = 1;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        c1FlexGrid1.Col = 4;
                    }
                    else
                    {
                        c1FlexGrid1.Col = 5;
                    }
                }
                else if (VarGeneral.vPaidInv)
                {
                    Button_Add_Click(sender, e);
                    c1FlexGrid1.SetData(1, 1, VarGeneral.vCustAcc_InvGaid[0]);
                    c1FlexGrid1_AfterEdit(sender, new RowColEventArgs(1, 1));
                    c1FlexGrid1.Row = 1;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        c1FlexGrid1.Col = 4;
                    }
                    else
                    {
                        c1FlexGrid1.Col = 5;
                    }
                    txtInvNo.Text = VarGeneral.vCustAcc_InvGaid[1];
                    txtInvNo.Tag = VarGeneral.vCustAcc_InvGaid[2];
                    txtInvType.Text = VarGeneral.vCustAcc_InvGaid[3];
                    c1FlexGrid1.SetData(1, 7, VarGeneral.vCustAcc_InvGaid[4]);
                    TotRequest = double.Parse(VarGeneral.vCustAcc_InvGaid[4]);
                    c1FlexGrid1.SetData(1, 4, VarGeneral.vCustAcc_InvGaid[5]);
                    c1FlexGrid1.SetData(1, 5, VarGeneral.vCustAcc_InvGaid[6]);
                    c1FlexGrid1.SetData(1, 6, 0);
                    c1FlexGrid1.Rows.Count = 2;
                    superTabControl_Main2.Enabled = false;
                    expandableSplitter1.Enabled = false;
                    Button_Delete.Visible = false;
                    buttonItem_Print.Visible = false;
                    Button_Search.Visible = false;
                }
                else
                {
                    textBox_ID.Text = PKeys.FirstOrDefault();
                }
                UpdateVcr();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            c1FlexGrid1.DrawMode = DrawModeEnum.OwnerDraw;
            c1FlexGrid1.OwnerDrawCell += _ownerDraw;
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptMaintenanceCars.dll"))
            {
                label18.Visible = false;
                CmbLegate.Visible = false;
                button_SrchMndob.Visible = false;
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptBus.dll"))
            {
                label15.Text = ((LangArEn == 0) ? "الباص : " : "Bus :");
                label18.Text = ((LangArEn == 0) ? "السائق :" : "Driver :");
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptWaterPackages.dll"))
            {
                label15.Text = ((LangArEn == 0) ? "السيارة : " : "Car :");
                label18.Text = ((LangArEn == 0) ? "العميــــل :" : "Customer :");
            }
        }
        private void _ownerDraw(object sender, OwnerDrawCellEventArgs e)
        {
            if (e.Col == 0 && e.Row > 0)
            {
                e.Text = e.Row.ToString();
            }
        }
        private void button_SrchAccNo_Click(object sender, EventArgs e)
        {
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
            columns_Names_visible2.Add("TaxNo", new ColumnDictinary("الرقم الضريبي", "Tax No", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 28))
            {
                VarGeneral.SFrmTyp = "AccDefID_Setting";
            }
            else
            {
                VarGeneral.SFrmTyp = "T_AccDef3";
            }
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                _AccDef = db.StockAccDefs_OnlyGaid(int.Parse(frm.Serach_No));
                txtAccNo.Text = _AccDef.AccDef_No.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtAccNameR.Text = _AccDef.Arb_Des.ToString();
                    txtAccName.Text = _AccDef.Arb_Des.ToString();
                }
                else
                {
                    txtAccNameR.Text = _AccDef.Eng_Des.ToString();
                    txtAccName.Text = _AccDef.Eng_Des.ToString();
                }
                txtBalance.Text = _AccDef.Balance.ToString();
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
                    string strfiled = "";
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
        private void prnt_doc_BeginPrint(object sender, PrintEventArgs e)
        {
            if (!(textBox_ID.Text != ""))
            {
                return;
            }
            RepShow _RepShow = new RepShow();
            _RepShow.Tables = "T_GDDET LEFT OUTER JOIN T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID LEFT OUTER JOIN T_INVSETTING ON T_GDHEAD.gdTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_GDHEAD.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_GDHEAD.gdCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_GDHEAD.gdMnd = T_Mndob.Mnd_ID LEFT OUTER JOIN T_AccDef ON T_GDDET.AccNo = T_AccDef.AccDef_No LEFT OUTER JOIN T_SYSSETTING ON T_GDHEAD.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
            string Fields = " CASE WHEN T_GDDET.gdValue > 0 THEN T_GDDET.gdValue ELSE 0 END as DebitBala , CASE WHEN T_GDDET.gdValue < 0 THEN Abs(T_GDDET.gdValue) ELSE 0 END as CreditBala , T_Curency.Arb_Des as Arb_Cur , T_Curency.Eng_Des as Eng_Cur, T_Curency.Rate , T_CstTbl.Arb_Des as Arb_Cst, T_CstTbl.Eng_Des as Eng_Cst , T_Mndob.Arb_Des as Arb_Mnd, T_Mndob.Eng_Des as Eng_Mnd , T_GDHEAD.* , T_GDDET.AccNo as AccDef_No,T_AccDef.Arb_Des ,T_AccDef.Eng_Des ,T_GDDET.gdDes,T_GDDET.gdDesE,T_SYSSETTING.LogImg,(select InvNamA from T_INVSETTING where T_GDHEAD.gdTyp = T_INVSETTING.InvID ) as InvNamA,(select InvNamE from T_INVSETTING where T_GDHEAD.gdTyp = T_INVSETTING.InvID ) as InvNamE,(select InvTypA0 from T_INVSETTING where T_GDHEAD.gdTyp = T_INVSETTING.InvID ) as InvTypA0 ,T_CstTbl.Cst_No,(select T_AccDef.Arb_Des from T_AccDef where T_AccDef.AccDef_No = (select (x.AccNo) from T_GDDET as x where x.gdID = (T_GDDET.gdID) and x.Lin = 1 )) as ch,(select T_AccDef.Eng_Des from T_AccDef where T_AccDef.AccDef_No = (select (x.AccNo) from T_GDDET as x where x.gdID = (T_GDDET.gdID) and x.Lin = 1 )) as tm,(select T_AccDef.Arb_Des from T_AccDef where T_AccDef.AccDef_No = (select (x.AccNo) from T_GDDET as x where x.gdID = (T_GDDET.gdID) and x.Lin = 0 )) as dt,(select T_AccDef.Eng_Des from T_AccDef where T_AccDef.AccDef_No = (select (x.AccNo) from T_GDDET as x where x.gdID = (T_GDDET.gdID) and x.Lin = 0 )) as curr,(select max(T_AccDef.Arb_Des) from T_AccDef where AccDef_No = (select max(x.AccNo) from T_GDDET x where x.gdID = (T_GDDET.gdID) and Lin = 1)) as CusVenNm,(select max(T_AccDef.Eng_Des) from T_AccDef where AccDef_No = (select max(x.AccNo) from T_GDDET x where x.gdID = (T_GDDET.gdID) and Lin = 1)) as CusVenNmE,(select max(T_AccDef.PersonalNm) from T_AccDef where AccDef_No = (select max(x.AccNo) from T_GDDET x where x.gdID = (T_GDDET.gdID) and Lin = 1)) as PersonalNm,(select max(T_AccDef.City) from T_AccDef where AccDef_No = (select max(x.AccNo) from T_GDDET x where x.gdID = (T_GDDET.gdID) and Lin = 1)) as City,(select max(T_AccDef.Email) from T_AccDef where AccDef_No = (select max(x.AccNo) from T_GDDET x where x.gdID = (T_GDDET.gdID) and Lin = 1)) as Email,(select max(T_AccDef.Mobile) from T_AccDef where AccDef_No = (select max(x.AccNo) from T_GDDET x where x.gdID = (T_GDDET.gdID) and Lin = 1)) as Mobile";
            VarGeneral.HeaderRep[0] = Text;
            VarGeneral.HeaderRep[1] = "";
            VarGeneral.HeaderRep[2] = "";
            _RepShow.Rule = " where T_GDHEAD.gdhead_ID = " + data_this.gdhead_ID + " Order by T_GDDET.Lin ";
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
        private void FMReceiptVoucher_FormClosed(object sender, FormClosedEventArgs e)
        {
            VarGeneral.StockOnly = false;
        }
        private void Button_PrintTable_Click(object sender, EventArgs e)
        {
            VarGeneral.InvType = 1;
            FRAccountReport from1 = new FRAccountReport(2);
            from1.Tag = LangArEn;
            from1.TopMost = true;
            from1.ShowDialog();
        }
        private void switchButton_Lock_ValueChanged(object sender, EventArgs e)
        {
            Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
        }
        private void switchButton_Lock_Click(object sender, EventArgs e)
        {
            if (!switchButton_Lock.IsReadOnly)
            {
                if (data_this.AdminLock.Value && switchButton_Lock.Value && !CanEdit)
                {
                    CanEdit = true;
                }
                Button_Edit_Click(sender, e);
            }
        }
        private void textBox_NameA_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("Arabic");
        }
        private void textBox_NameE_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("English");
        }
        private void txtGedDes_Click(object sender, EventArgs e)
        {
            txtGedDes.SelectAll();
        }
        private void txtGedDesE_Click(object sender, EventArgs e)
        {
            txtGedDesE.SelectAll();
        }
        private void button_Repetition_Click(object sender, EventArgs e)
        {
            try
            {
                string c = textBox_ID.Text;
                if (!string.IsNullOrEmpty(c))
                {
                    Button_Add_Click(sender, e);
                    RepetitionSts = true;
                    SetData(db.StockGDHEAD(VarGeneral.InvTyp, c));
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_Repetition_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            RepetitionSts = false;
            ReverseSts = false;
        }
        private void button_SrchInvNo_Click(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                if (State == FormState.Saved || !(c1FlexGrid1.GetData(1, 1).ToString() != ""))
                {
                    return;
                }
                VarGeneral._GaidInv = new List<T_INVHED>();
                Stock_DataDataContext dbx = new Stock_DataDataContext(VarGeneral.BranchCS);
                VarGeneral._GaidInv = dbx.ExecuteQuery<T_INVHED>("select T_INVHED.ArbTaf, T_INVHED.CashPay, T_INVHED.CashPayLocCur, T_INVHED.chauffeurNo, T_INVHED.CommMnd_Inv, T_INVHED.CompanyID, T_INVHED.CREATED_BY, T_INVHED.CreditPay, T_INVHED.CreditPayLocCur, T_INVHED.CurTyp, T_INVHED.CustNet, T_INVHED.CustPri, T_INVHED.CustRep, T_INVHED.CusVenAdd, T_INVHED.CusVenNo, T_INVHED.CusVenTel, T_INVHED.DATE_CREATED, T_INVHED.DATE_MODIFIED, T_INVHED.EstDat, T_INVHED.ExtrnalCostGaidID, T_INVHED.GadeId, T_INVHED.GadeNo, T_INVHED.GDat, T_INVHED.HDat, T_INVHED.IfDel, T_INVHED.IfPrint, T_INVHED.IfRet, T_INVHED.IfTrans, T_INVHED.InvAddCost, T_INVHED.InvAddCostExtrnal, T_INVHED.InvAddCostExtrnalLoc, T_INVHED.InvAddCostLoc, T_INVHED.InvCash, T_INVHED.InvCashPay, T_INVHED.InvCashPayNm, T_INVHED.InvCost, T_INVHED.InvCstNo, T_INVHED.InvDisPrs, ((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints, T_INVHED.InvDisValLocCur, T_INVHED.InvHed_ID, T_INVHED.InvId, T_INVHED.InvNet, T_INVHED.InvNetLocCur, T_INVHED.InvNo, T_INVHED.InvQty, T_INVHED.InvTot, T_INVHED.InvTotLocCur, T_INVHED.InvTyp, T_INVHED.InvWight_T, T_INVHED.IsExtrnalGaid, T_INVHED.LTim, T_INVHED.MndExtrnal, T_INVHED.MndNo, T_INVHED.MODIFIED_BY, T_INVHED.NetworkPay, T_INVHED.NetworkPayLocCur, T_INVHED.OrderTyp,Puyaid, T_INVHED.RefNo, T_INVHED.Remark,Remming, T_INVHED.RetId, T_INVHED.RetNo, T_INVHED.RoomNo, T_INVHED.RoomPerson, T_INVHED.RoomSts, T_INVHED.SalsManNam, T_INVHED.SalsManNo, T_INVHED.ServiceValue, T_INVHED.Sts, T_INVHED.ToStore, T_INVHED.ToStoreNm,case when T_INVHED.CusVenNo <> '' then (select " + ((LangArEn == 0) ? " T_AccDef.Arb_Des " : " T_AccDef.Eng_Des") + " from T_AccDef where T_AccDef.AccDef_No = T_INVHED.CusVenNo) else T_INVHED.CusVenNm end as CusVenNm,case when T_INVHED.CusVenNo <> '' then (select T_AccDef.Mobile from T_AccDef where T_AccDef.AccDef_No = T_INVHED.CusVenNo) else '' end as CusVenAdd from T_INVHED where (IfDel <> 1 and CreditPay > 0 and (case when (select sum(T_GDHEAD.gdTot) from T_GDHEAD where T_GDHEAD.BName = T_INVHED.InvHed_ID and T_GDHEAD.gdTyp =12 and gdLok =0) is null then 0 else (select sum(T_GDHEAD.gdTot) from T_GDHEAD where T_GDHEAD.BName = T_INVHED.InvHed_ID and T_GDHEAD.gdTyp =12 and gdLok =0) end ) < CreditPay and CusVenNo ='" + c1FlexGrid1.GetData(1, 1).ToString() + "' and InvCashPay =1 and InvTyp=1) order by InvHed_ID", new object[0]).ToList();
                if (VarGeneral._GaidInv.Count != 0)
                {
                    goto IL_01ea;
                }
                if (State == FormState.Edit && !string.IsNullOrEmpty(data_this.BName))
                {
                    VarGeneral._GaidInv = dbx.ExecuteQuery<T_INVHED>("select T_INVHED.ArbTaf, T_INVHED.CashPay, T_INVHED.CashPayLocCur, T_INVHED.chauffeurNo, T_INVHED.CommMnd_Inv, T_INVHED.CompanyID, T_INVHED.CREATED_BY, T_INVHED.CreditPay, T_INVHED.CreditPayLocCur, T_INVHED.CurTyp, T_INVHED.CustNet, T_INVHED.CustPri, T_INVHED.CustRep, T_INVHED.CusVenAdd, T_INVHED.CusVenNo, T_INVHED.CusVenTel, T_INVHED.DATE_CREATED, T_INVHED.DATE_MODIFIED, T_INVHED.EstDat, T_INVHED.ExtrnalCostGaidID, T_INVHED.GadeId, T_INVHED.GadeNo, T_INVHED.GDat, T_INVHED.HDat, T_INVHED.IfDel, T_INVHED.IfPrint, T_INVHED.IfRet, T_INVHED.IfTrans, T_INVHED.InvAddCost, T_INVHED.InvAddCostExtrnal, T_INVHED.InvAddCostExtrnalLoc, T_INVHED.InvAddCostLoc, T_INVHED.InvCash, T_INVHED.InvCashPay, T_INVHED.InvCashPayNm, T_INVHED.InvCost, T_INVHED.InvCstNo, T_INVHED.InvDisPrs, ((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints, T_INVHED.InvDisValLocCur, T_INVHED.InvHed_ID, T_INVHED.InvId, T_INVHED.InvNet, T_INVHED.InvNetLocCur, T_INVHED.InvNo, T_INVHED.InvQty, T_INVHED.InvTot, T_INVHED.InvTotLocCur, T_INVHED.InvTyp, T_INVHED.InvWight_T, T_INVHED.IsExtrnalGaid, T_INVHED.LTim, T_INVHED.MndExtrnal, T_INVHED.MndNo, T_INVHED.MODIFIED_BY, T_INVHED.NetworkPay, T_INVHED.NetworkPayLocCur, T_INVHED.OrderTyp,Puyaid, T_INVHED.RefNo, T_INVHED.Remark,Remming, T_INVHED.RetId, T_INVHED.RetNo, T_INVHED.RoomNo, T_INVHED.RoomPerson, T_INVHED.RoomSts, T_INVHED.SalsManNam, T_INVHED.SalsManNo, T_INVHED.ServiceValue, T_INVHED.Sts, T_INVHED.ToStore, T_INVHED.ToStoreNm,case when T_INVHED.CusVenNo <> '' then (select " + ((LangArEn == 0) ? " T_AccDef.Arb_Des " : " T_AccDef.Eng_Des") + " from T_AccDef where T_AccDef.AccDef_No = T_INVHED.CusVenNo) else T_INVHED.CusVenNm end as CusVenNm,case when T_INVHED.CusVenNo <> '' then (select T_AccDef.Mobile from T_AccDef where T_AccDef.AccDef_No = T_INVHED.CusVenNo) else '' end as CusVenAdd from T_INVHED where (InvHed_ID = " + data_this.BName + " and CusVenNo ='" + c1FlexGrid1.GetData(1, 1).ToString() + "' and InvCashPay =1 and InvTyp=1) order by InvHed_ID", new object[0]).ToList();
                    goto IL_01ea;
                }
                MessageBox.Show((LangArEn == 0) ? ("لا يوجد لـ " + c1FlexGrid1.GetData(1, 2).ToString() + " فواتير مبيعات آجلة غير مسد\u0651دة") : ("There is no" + c1FlexGrid1.GetData(1, 3).ToString() + "Outstanding unpaid bills"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                goto end_IL_0054;
            IL_01ea:
                if (VarGeneral._GaidInv.Count <= 0)
                {
                    return;
                }
                double _totPaid = 0.0;
                for (int i = 0; i < VarGeneral._GaidInv.ToList().Count; i++)
                {
                    VarGeneral._GaidInv.ToList()[i].GDat = db.StockInvSetting(VarGeneral.UserID, VarGeneral._GaidInv.ToList()[i].InvTyp.Value).InvNamA;
                    VarGeneral._GaidInv.ToList()[i].HDat = db.StockInvSetting(VarGeneral.UserID, VarGeneral._GaidInv.ToList()[i].InvTyp.Value).InvNamE;
                    List<T_GDHEAD> _gd = dbx.ExecuteQuery<T_GDHEAD>("select * from T_GDHEAD where BName='" + VarGeneral._GaidInv.ToList()[i].InvHed_ID.ToString() + "' and gdLok =0 and gdTyp =" + VarGeneral.InvTyp, new object[0]).ToList();
                    _totPaid = 0.0;
                    try
                    {
                        _totPaid = _gd.Sum((T_GDHEAD global) => global.gdTot.Value);
                    }
                    catch
                    {
                        _totPaid = 0.0;
                    }
                    VarGeneral._GaidInv.ToList()[i].Puyaid = _totPaid;
                    VarGeneral._GaidInv.ToList()[i].Remming = VarGeneral._GaidInv[i].CreditPay.Value - _totPaid;
                    if (State == FormState.Edit && !string.IsNullOrEmpty(data_this.BName) && VarGeneral._GaidInv[i].InvHed_ID == int.Parse(data_this.BName))
                    {
                        T_INVHED T_INVHED = VarGeneral._GaidInv.ToList()[i];
                        T_INVHED.Puyaid -= data_this.gdTot.Value;
                        T_INVHED T_INVHED2 = VarGeneral._GaidInv.ToList()[i];
                        T_INVHED2.Remming += data_this.gdTot.Value;
                    }
                }
                columns_Names_visible2.Clear();
                columns_Names_visible2.Add("InvNo", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
                columns_Names_visible2.Add("GDat", new ColumnDictinary("نوع الفاتورة عربي", "Inv Type Arabic", ifDefault: true, ""));
                columns_Names_visible2.Add("HDat", new ColumnDictinary("نوع الفاتورة الانجليزي", "Inv Type English", ifDefault: true, ""));
                columns_Names_visible2.Add("Puyaid", new ColumnDictinary("المدفوع منه", "Puaid", ifDefault: true, ""));
                columns_Names_visible2.Add("Remming", new ColumnDictinary("المتبقي عليه", "Remming", ifDefault: true, ""));
                columns_Names_visible2.Add("InvHed_ID", new ColumnDictinary("الرقم المتسلسل", "English Name", ifDefault: true, ""));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                }
                VarGeneral.SFrmTyp = "T_InvGaid";
                TotRequest = 0.0;
                VarGeneral.RepData = new DataSet();
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T_INVHED));
                DataTable table = new DataTable();
                foreach (PropertyDescriptor prop in properties)
                {
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
                foreach (T_INVHED item in VarGeneral._GaidInv)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                    {
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    }
                    table.Rows.Add(row);
                }
                VarGeneral.RepData.Tables.Add(table);
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    txtInvNo.Text = dbx.StockInvHeadID2(int.Parse(frm.Serach_No)).InvNo;
                    txtInvType.Text = ((LangArEn == 0) ? dbx.StockInvHeadID2(int.Parse(frm.Serach_No)).T_INVSETTING.InvNamA.Trim() : dbx.StockInvHeadID2(int.Parse(frm.Serach_No)).T_INVSETTING.InvNamE.Trim());
                    txtInvNo.Tag = frm.Serach_No.ToString();
                    TotRequest = VarGeneral._GaidInv.Where((T_INVHED t) => t.InvHed_ID == int.Parse(frm.Serach_No)).ToList().FirstOrDefault()
                        .Remming.Value;
                    c1FlexGrid1.Rows.Count = 2;
                }
                else
                {
                    txtInvNo.Text = "";
                    txtInvType.Text = "";
                    txtInvNo.Tag = "";
                    c1FlexGrid1.Rows.Count = 100;
                }
            end_IL_0054:;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_SrchInvNo_Click:", error, enable: true);
            }
        }
        private void button_SrchMndob_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            try
            {
                if (State == FormState.Saved)
                {
                    return;
                }
                columns_Names_visible2.Clear();
                columns_Names_visible2.Add("Mnd_No", new ColumnDictinary("الرقم", " No", ifDefault: true, ""));
                columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
                columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                }
                VarGeneral.SFrmTyp = "T_Mndob";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    CmbLegate.SelectedValue = db.StockMndob(frm.Serach_No).Mnd_ID;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_SrchMndob_Click :", error, enable: true);
            }
        }
        private void button_SrchCostCenter_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            try
            {
                if (State == FormState.Saved)
                {
                    return;
                }
                columns_Names_visible2.Clear();
                columns_Names_visible2.Add("Cst_No", new ColumnDictinary("الرقــم", "No", ifDefault: true, ""));
                columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
                columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
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
                    CmbLegate.SelectedValue = db.StockCst(frm.Serach_No).Cst_ID;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_SrchCostCenter_Click :", error, enable: true);
            }
        }
        private void Button_PrintTableMulti_Click(object sender, EventArgs e)
        {
            if (State != 0 || string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            try
            {
                for (int i = 0; i < pkeys.Count; i++)
                {
                    try
                    {
                        GridRow crow = DGV_Main.PrimaryGrid.Rows[i] as GridRow;
                        if (crow.Checked)
                        {
                            ifMultiPrint = true;
                            data_this = new T_GDHEAD();
                            data_this = db.StockGDHEAD(VarGeneral.InvTyp, DGV_Main.PrimaryGrid.GetCell(crow.Index, 0).Value.ToString());
                            buttonItem_Print_Click(sender, e);
                            ifMultiPrint = false;
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
                ifMultiPrint = false;
            }
            textBox_ID_TextChanged(sender, e);
        }
        private void printersettings_Click(object sender, EventArgs e)
        {
            DroBoxSync.Frm_PrinterShow f = new DroBoxSync.Frm_PrinterShow(VarGeneral.InvTyp);
            f.TopMost = true;
            f.ShowDialog();
            _InvSetting.InvpRINTERInfo.nTyp = DroBoxSync.Frm_PrinterShow.PLSetting;
        }

        private void buttonItem_Print_Click_1(object sender, EventArgs e)
        {

        }

        private void c1FlexGrid1_StartEdit(object sender, RowColEventArgs e)
        {
            kk = 1;
        }

        private void c1FlexGrid1_LeaveEdit(object sender, RowColEventArgs e)
        {
            kk = 0;
        }

        private void c1FlexGrid1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
