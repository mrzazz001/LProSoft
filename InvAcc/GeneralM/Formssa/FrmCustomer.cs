using C1.Win.C1BarCode;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using InputKey;
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
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmCustomer : Form
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
        private Panel PanelSpecialContainer;
        private void superTabControl_Main1_RightToLeftChanged(object sender, EventArgs e)
        {
            superTabControl_Main1.RightToLeftChanged -= superTabControl_Main1_RightToLeftChanged;
            superTabControl_Main1.RightToLeft = RightToLeft.No;
            superTabControl_Main1.RightToLeftChanged -= superTabControl_Main1_RightToLeftChanged;
        }
        private void FrmInvSale_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                superTabControl_Main2.Width = 500;
            }
            else
            {
                superTabControl_Main2.Width = 443;
            }
            netResize1.Refresh();
        }
        private Softgroup.NetResize.NetResize netResize1;
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
        private ImageList imageList1;
        private DockSite dockSite4;
        private DockSite dockSite3;
        protected ContextMenuStrip contextMenuStrip1;
        protected ContextMenuStrip contextMenuStrip2;
        protected ToolStripMenuItem ToolStripMenuItem_Det;
        protected IntegerInput integerInput1;
        private OpenFileDialog openFileDialog1;
        private Timer timerInfoBallon;
        private SaveFileDialog saveFileDialog1;
        private PanelEx panelEx3;
        private Timer timer1;
        private PanelEx panelEx2;
        private ExpandableSplitter expandableSplitter1;
        private Panel panel1;
        private Label label5;
        private CheckBoxX checkBoxX_Stoped;
        private ButtonX buttonX_CustomerStoped;
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
        private TextBox txtZipCod;
        private Label label20;
        private Label label6;
        private TextBox txtEMail;
        private Label label7;
        private TextBox txtCity;
        private Label label8;
        private TextBox txtFax;
        private Label label12;
        private TextBox txtMobile;
        private Label label13;
        private TextBox txtTele1;
        private Label label9;
        private TextBox txtTele2;
        private Label label11;
        private Label label18;
        private ComboBox CmbPrice;
        private IntegerInput txtAgeLimit;
        private Label label10;
        private Label label16;
        private DoubleInput txtBalance;
        private Label label15;
        private DoubleInput txtCredit;
        private Label label14;
        private DoubleInput txtDeb;
        private Label label17;
        private TextBox txtPersonalName;
        private Label label19;
        private ButtonX buttonX_SerchAccNo;
        private Label label3;
        private TextBox textBox_ID;
        private Label label4;
        private TextBox txtEngDes;
        private Label label2;
        private TextBox txtArbDes;
        private Label label1;
        private TextBox txtMainAccNo;
        private DoubleInput txtCreditLimit;
        private TextBox txtAddress;
        private TextBox txtRessonsStoped;
        private LabelItem lable_Records;
        private Label label21;
        private ComboBox CmbLegate;
        private ComboBox CmbInvTyp;
        private ButtonX button_Barcode;
        private PrintDialog printDialog1;
        internal PrintDocument prnt_doc;
        internal PrintPreviewDialog prnt_prev;
        private C1BarCode c1BarCode1;
        private ButtonX button_SrchPlaceNo;
        private TextBox txtPlaceName;
        private TextBox txtTaxNo;
        private Label label22;
        private Line line1;
        private DoubleInput txtMaxDis;
        private Label label23;
        private Label label24;
        private SwitchButton switchButton_DisTyp;
        private TextBox txtAge;
        private Label label25;
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
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private T_Company _Company = new T_Company();
        private bool canUpdate = true;
        private T_AccDef data_this;
        private Stock_DataDataContext dbInstance;
        private List<string> pkeys = new List<string>();
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
        private string IdProof = "";
        private int CountPage = 0;
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
                if (value != null && value.UsrNo != "")
                {
                    permission = value;
                    if (!VarGeneral.TString.ChkStatShow(value.FilStr, 33))
                    {
                        IfAdd = false;
                    }
                    else
                    {
                        IfAdd = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.FilStr, 34))
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.FilStr, 35))
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
            this.components = new System.ComponentModel.Container();
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background3 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor1 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor2 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle1 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle2 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.Background background4 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomer));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.checkBoxX_Stoped = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtMaxDis = new DevComponents.Editors.DoubleInput();
            this.label23 = new System.Windows.Forms.Label();
            this.txtTaxNo = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtRessonsStoped = new System.Windows.Forms.TextBox();
            this.button_SrchPlaceNo = new DevComponents.DotNetBar.ButtonX();
            this.button_Barcode = new DevComponents.DotNetBar.ButtonX();
            this.CmbInvTyp = new System.Windows.Forms.ComboBox();
            this.txtZipCod = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEMail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTele1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTele2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtAgeLimit = new DevComponents.Editors.IntegerInput();
            this.label10 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtBalance = new DevComponents.Editors.DoubleInput();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCredit = new DevComponents.Editors.DoubleInput();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDeb = new DevComponents.Editors.DoubleInput();
            this.label17 = new System.Windows.Forms.Label();
            this.txtPersonalName = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.buttonX_SerchAccNo = new DevComponents.DotNetBar.ButtonX();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEngDes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtArbDes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMainAccNo = new System.Windows.Forms.TextBox();
            this.txtCreditLimit = new DevComponents.Editors.DoubleInput();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.buttonX_CustomerStoped = new DevComponents.DotNetBar.ButtonX();
            this.label5 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.CmbLegate = new System.Windows.Forms.ComboBox();
            this.c1BarCode1 = new C1.Win.C1BarCode.C1BarCode();
            this.CmbPrice = new System.Windows.Forms.ComboBox();
            this.txtPlaceName = new System.Windows.Forms.TextBox();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.switchButton_DisTyp = new DevComponents.DotNetBar.Controls.SwitchButton();
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
            this.Rep_RecCount = new DevComponents.Editors.IntegerInput();
            this.ToolStripMenuItem_Rep = new System.Windows.Forms.ToolStripMenuItem();
            this.barTopDockSite = new DevComponents.DotNetBar.DockSite();
            this.barBottomDockSite = new DevComponents.DotNetBar.DockSite();
            this.barLeftDockSite = new DevComponents.DotNetBar.DockSite();
            this.barRightDockSite = new DevComponents.DotNetBar.DockSite();
            this.dockSite1 = new DevComponents.DotNetBar.DockSite();
            this.dockSite2 = new DevComponents.DotNetBar.DockSite();
            this.dotNetBarManager1 = new DevComponents.DotNetBar.DotNetBarManager(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dockSite4 = new DevComponents.DotNetBar.DockSite();
            this.dockSite3 = new DevComponents.DotNetBar.DockSite();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_Det = new System.Windows.Forms.ToolStripMenuItem();
            this.integerInput1 = new DevComponents.Editors.IntegerInput();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timerInfoBallon = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.DGV_Main = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.ribbonBar_DGV = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl_DGV = new DevComponents.DotNetBar.SuperTabControl();
            this.textBox_search = new DevComponents.DotNetBar.TextBoxItem();
            this.Button_ExportTable2 = new DevComponents.DotNetBar.ButtonItem();
            this.Button_PrintTable = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem3 = new DevComponents.DotNetBar.LabelItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.prnt_doc = new System.Drawing.Printing.PrintDocument();
            this.prnt_prev = new System.Windows.Forms.PrintPreviewDialog();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.PanelSpecialContainer.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxDis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgeLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBalance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCredit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreditLimit)).BeginInit();
            this.ribbonBar_Tasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rep_RecCount)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integerInput1)).BeginInit();
            this.panelEx3.SuspendLayout();
            this.ribbonBar_DGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_DGV)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.PanelSpecialContainer.Size = new System.Drawing.Size(658, 376);
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
            this.ribbonBar1.Controls.Add(this.checkBoxX_Stoped);
            this.ribbonBar1.Controls.Add(this.txtAge);
            this.ribbonBar1.Controls.Add(this.label25);
            this.ribbonBar1.Controls.Add(this.label24);
            this.ribbonBar1.Controls.Add(this.txtMaxDis);
            this.ribbonBar1.Controls.Add(this.label23);
            this.ribbonBar1.Controls.Add(this.txtTaxNo);
            this.ribbonBar1.Controls.Add(this.label22);
            this.ribbonBar1.Controls.Add(this.txtRessonsStoped);
            this.ribbonBar1.Controls.Add(this.button_SrchPlaceNo);
            this.ribbonBar1.Controls.Add(this.button_Barcode);
            this.ribbonBar1.Controls.Add(this.CmbInvTyp);
            this.ribbonBar1.Controls.Add(this.txtZipCod);
            this.ribbonBar1.Controls.Add(this.label20);
            this.ribbonBar1.Controls.Add(this.label6);
            this.ribbonBar1.Controls.Add(this.txtEMail);
            this.ribbonBar1.Controls.Add(this.label7);
            this.ribbonBar1.Controls.Add(this.txtCity);
            this.ribbonBar1.Controls.Add(this.label8);
            this.ribbonBar1.Controls.Add(this.txtFax);
            this.ribbonBar1.Controls.Add(this.label12);
            this.ribbonBar1.Controls.Add(this.txtMobile);
            this.ribbonBar1.Controls.Add(this.label13);
            this.ribbonBar1.Controls.Add(this.txtTele1);
            this.ribbonBar1.Controls.Add(this.label9);
            this.ribbonBar1.Controls.Add(this.txtTele2);
            this.ribbonBar1.Controls.Add(this.label11);
            this.ribbonBar1.Controls.Add(this.label18);
            this.ribbonBar1.Controls.Add(this.txtAgeLimit);
            this.ribbonBar1.Controls.Add(this.label10);
            this.ribbonBar1.Controls.Add(this.label16);
            this.ribbonBar1.Controls.Add(this.txtBalance);
            this.ribbonBar1.Controls.Add(this.label15);
            this.ribbonBar1.Controls.Add(this.txtCredit);
            this.ribbonBar1.Controls.Add(this.label14);
            this.ribbonBar1.Controls.Add(this.txtDeb);
            this.ribbonBar1.Controls.Add(this.label17);
            this.ribbonBar1.Controls.Add(this.txtPersonalName);
            this.ribbonBar1.Controls.Add(this.label19);
            this.ribbonBar1.Controls.Add(this.buttonX_SerchAccNo);
            this.ribbonBar1.Controls.Add(this.label3);
            this.ribbonBar1.Controls.Add(this.textBox_ID);
            this.ribbonBar1.Controls.Add(this.label4);
            this.ribbonBar1.Controls.Add(this.txtEngDes);
            this.ribbonBar1.Controls.Add(this.label2);
            this.ribbonBar1.Controls.Add(this.txtArbDes);
            this.ribbonBar1.Controls.Add(this.label1);
            this.ribbonBar1.Controls.Add(this.txtMainAccNo);
            this.ribbonBar1.Controls.Add(this.txtCreditLimit);
            this.ribbonBar1.Controls.Add(this.txtAddress);
            this.ribbonBar1.Controls.Add(this.buttonX_CustomerStoped);
            this.ribbonBar1.Controls.Add(this.label5);
            this.ribbonBar1.Controls.Add(this.label21);
            this.ribbonBar1.Controls.Add(this.CmbLegate);
            this.ribbonBar1.Controls.Add(this.c1BarCode1);
            this.ribbonBar1.Controls.Add(this.CmbPrice);
            this.ribbonBar1.Controls.Add(this.txtPlaceName);
            this.ribbonBar1.Controls.Add(this.line1);
            this.ribbonBar1.Controls.Add(this.switchButton_DisTyp);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(658, 325);
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
            // checkBoxX_Stoped
            // 
            this.checkBoxX_Stoped.AutoSize = true;
            // 
            // 
            // 
            this.checkBoxX_Stoped.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX_Stoped.Location = new System.Drawing.Point(358, 269);
            this.checkBoxX_Stoped.Name = "checkBoxX_Stoped";
            this.checkBoxX_Stoped.Size = new System.Drawing.Size(73, 15);
            this.checkBoxX_Stoped.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX_Stoped.TabIndex = 92;
            this.checkBoxX_Stoped.Text = "حظر العميل";
            this.checkBoxX_Stoped.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.checkBoxX_Stoped.CheckedChanged += new System.EventHandler(this.checkBoxX_Stoped_CheckedChanged);
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(449, 243);
            this.txtAge.Name = "txtAge";
            this.netResize1.SetResizeTextBoxMultiline(this.txtAge, false);
            this.txtAge.Size = new System.Drawing.Size(104, 20);
            this.txtAge.TabIndex = 1304;
            this.txtAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAge_KeyPress);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label25.Location = new System.Drawing.Point(559, 247);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(47, 13);
            this.label25.TabIndex = 1305;
            this.label25.Text = "العمـــر :";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label24.Location = new System.Drawing.Point(113, 44);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(18, 13);
            this.label24.TabIndex = 1302;
            this.label24.Text = "%";
            // 
            // txtMaxDis
            // 
            this.txtMaxDis.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtMaxDis.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtMaxDis.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMaxDis.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtMaxDis.DisplayFormat = "0.00";
            this.txtMaxDis.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtMaxDis.Increment = 1D;
            this.txtMaxDis.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtMaxDis.Location = new System.Drawing.Point(133, 40);
            this.txtMaxDis.MaxValue = 100D;
            this.txtMaxDis.MinValue = 0D;
            this.txtMaxDis.Name = "txtMaxDis";
            this.txtMaxDis.Size = new System.Drawing.Size(44, 20);
            this.txtMaxDis.TabIndex = 1300;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label23.Location = new System.Drawing.Point(177, 44);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(72, 13);
            this.label23.TabIndex = 1301;
            this.label23.Text = "نسبة الخصم :";
            this.label23.TextChanged += new System.EventHandler(this.label23_TextChanged);
            // 
            // txtTaxNo
            // 
            this.txtTaxNo.BackColor = System.Drawing.Color.White;
            this.txtTaxNo.Location = new System.Drawing.Point(17, 64);
            this.txtTaxNo.MaxLength = 30;
            this.txtTaxNo.Name = "txtTaxNo";
            this.netResize1.SetResizeTextBoxMultiline(this.txtTaxNo, false);
            this.txtTaxNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTaxNo.Size = new System.Drawing.Size(104, 20);
            this.txtTaxNo.TabIndex = 1298;
            this.txtTaxNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(127, 68);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(94, 13);
            this.label22.TabIndex = 1297;
            this.label22.Text = "الــرقم الضريبـــي :";
            // 
            // txtRessonsStoped
            // 
            this.txtRessonsStoped.Location = new System.Drawing.Point(46, 247);
            this.txtRessonsStoped.Multiline = true;
            this.txtRessonsStoped.Name = "txtRessonsStoped";
            this.netResize1.SetResizeTextBoxMultiline(this.txtRessonsStoped, false);
            this.txtRessonsStoped.Size = new System.Drawing.Size(307, 45);
            this.txtRessonsStoped.TabIndex = 21;
            this.txtRessonsStoped.TextChanged += new System.EventHandler(this.txtRessonsStoped_TextChanged);
            // 
            // button_SrchPlaceNo
            // 
            this.button_SrchPlaceNo.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.button_SrchPlaceNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchPlaceNo.Location = new System.Drawing.Point(17, 247);
            this.button_SrchPlaceNo.Name = "button_SrchPlaceNo";
            this.button_SrchPlaceNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchPlaceNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchPlaceNo.Symbol = "";
            this.button_SrchPlaceNo.SymbolSize = 12F;
            this.button_SrchPlaceNo.TabIndex = 1093;
            this.button_SrchPlaceNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchPlaceNo.Visible = false;
            this.button_SrchPlaceNo.Click += new System.EventHandler(this.button_SrchPlaceNo_Click);
            // 
            // button_Barcode
            // 
            this.button_Barcode.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_Barcode.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_Barcode.Location = new System.Drawing.Point(414, 10);
            this.button_Barcode.Name = "button_Barcode";
            this.button_Barcode.Size = new System.Drawing.Size(26, 20);
            this.button_Barcode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_Barcode.Symbol = "";
            this.button_Barcode.SymbolSize = 12F;
            this.button_Barcode.TabIndex = 910;
            this.button_Barcode.TextColor = System.Drawing.Color.SteelBlue;
            this.button_Barcode.Visible = false;
            this.button_Barcode.Click += new System.EventHandler(this.button_Barcode_Click);
            // 
            // CmbInvTyp
            // 
            this.CmbInvTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbInvTyp.BackColor = System.Drawing.Color.AliceBlue;
            this.CmbInvTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbInvTyp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbInvTyp.Font = new System.Drawing.Font("Tahoma", 8F);
            this.CmbInvTyp.FormattingEnabled = true;
            this.CmbInvTyp.ItemHeight = 13;
            this.CmbInvTyp.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.CmbInvTyp.Location = new System.Drawing.Point(249, 114);
            this.CmbInvTyp.Name = "CmbInvTyp";
            this.CmbInvTyp.Size = new System.Drawing.Size(165, 21);
            this.CmbInvTyp.TabIndex = 909;
            // 
            // txtZipCod
            // 
            this.txtZipCod.Location = new System.Drawing.Point(249, 218);
            this.txtZipCod.Name = "txtZipCod";
            this.netResize1.SetResizeTextBoxMultiline(this.txtZipCod, false);
            this.txtZipCod.Size = new System.Drawing.Size(104, 20);
            this.txtZipCod.TabIndex = 19;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label20.Location = new System.Drawing.Point(358, 222);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(73, 13);
            this.label20.TabIndex = 906;
            this.label20.Text = "الرمز البريدي :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(559, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 904;
            this.label6.Text = "العنوان :";
            // 
            // txtEMail
            // 
            this.txtEMail.Location = new System.Drawing.Point(17, 218);
            this.txtEMail.Name = "txtEMail";
            this.netResize1.SetResizeTextBoxMultiline(this.txtEMail, false);
            this.txtEMail.Size = new System.Drawing.Size(169, 20);
            this.txtEMail.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(189, 222);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 903;
            this.label7.Text = "الإيميل :";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(17, 166);
            this.txtCity.Name = "txtCity";
            this.netResize1.SetResizeTextBoxMultiline(this.txtCity, false);
            this.txtCity.Size = new System.Drawing.Size(169, 20);
            this.txtCity.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(189, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 902;
            this.label8.Text = "البلد :";
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(249, 192);
            this.txtFax.Name = "txtFax";
            this.netResize1.SetResizeTextBoxMultiline(this.txtFax, false);
            this.txtFax.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFax.Size = new System.Drawing.Size(104, 20);
            this.txtFax.TabIndex = 16;
            this.txtFax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFax.Click += new System.EventHandler(this.txtFax_Click);
            this.txtFax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTele1_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(358, 196);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 13);
            this.label12.TabIndex = 898;
            this.label12.Text = "الفاكس :";
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(17, 192);
            this.txtMobile.Name = "txtMobile";
            this.netResize1.SetResizeTextBoxMultiline(this.txtMobile, false);
            this.txtMobile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMobile.Size = new System.Drawing.Size(169, 20);
            this.txtMobile.TabIndex = 17;
            this.txtMobile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMobile.Click += new System.EventHandler(this.txtMobile_Click);
            this.txtMobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTele1_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(189, 196);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 13);
            this.label13.TabIndex = 897;
            this.label13.Text = "الجوال :";
            // 
            // txtTele1
            // 
            this.txtTele1.Location = new System.Drawing.Point(449, 192);
            this.txtTele1.Name = "txtTele1";
            this.netResize1.SetResizeTextBoxMultiline(this.txtTele1, false);
            this.txtTele1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTele1.Size = new System.Drawing.Size(104, 20);
            this.txtTele1.TabIndex = 15;
            this.txtTele1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTele1.Click += new System.EventHandler(this.txtTele1_Click);
            this.txtTele1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTele1_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(559, 196);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 896;
            this.label9.Text = "الهاتف :";
            // 
            // txtTele2
            // 
            this.txtTele2.Location = new System.Drawing.Point(449, 218);
            this.txtTele2.Name = "txtTele2";
            this.netResize1.SetResizeTextBoxMultiline(this.txtTele2, false);
            this.txtTele2.Size = new System.Drawing.Size(104, 20);
            this.txtTele2.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(559, 222);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 895;
            this.label11.Text = "ص . ب :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(127, 118);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(93, 13);
            this.label18.TabIndex = 890;
            this.label18.Text = "السعر الإفتراضي :";
            // 
            // txtAgeLimit
            // 
            this.txtAgeLimit.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtAgeLimit.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtAgeLimit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtAgeLimit.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtAgeLimit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtAgeLimit.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtAgeLimit.Location = new System.Drawing.Point(249, 114);
            this.txtAgeLimit.MinValue = 0;
            this.txtAgeLimit.Name = "txtAgeLimit";
            this.txtAgeLimit.ShowUpDown = true;
            this.txtAgeLimit.Size = new System.Drawing.Size(104, 21);
            this.txtAgeLimit.TabIndex = 8;
            this.txtAgeLimit.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(358, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 887;
            this.label10.Text = "عمر الدين :";
            this.label10.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(559, 118);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 13);
            this.label16.TabIndex = 886;
            this.label16.Text = "حد المديونية :";
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
            this.txtBalance.Location = new System.Drawing.Point(17, 140);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(104, 20);
            this.txtBalance.TabIndex = 12;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(127, 144);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 13);
            this.label15.TabIndex = 883;
            this.label15.Text = "الرصيد الحالي :";
            // 
            // txtCredit
            // 
            this.txtCredit.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtCredit.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtCredit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCredit.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtCredit.DisplayFormat = "0.00";
            this.txtCredit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtCredit.Increment = 1D;
            this.txtCredit.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtCredit.IsInputReadOnly = true;
            this.txtCredit.Location = new System.Drawing.Point(249, 140);
            this.txtCredit.Name = "txtCredit";
            this.txtCredit.Size = new System.Drawing.Size(104, 20);
            this.txtCredit.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(358, 144);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 13);
            this.label14.TabIndex = 881;
            this.label14.Text = "دائن :";
            // 
            // txtDeb
            // 
            this.txtDeb.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtDeb.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDeb.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDeb.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtDeb.DisplayFormat = "0.00";
            this.txtDeb.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtDeb.Increment = 1D;
            this.txtDeb.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtDeb.IsInputReadOnly = true;
            this.txtDeb.Location = new System.Drawing.Point(449, 140);
            this.txtDeb.Name = "txtDeb";
            this.txtDeb.Size = new System.Drawing.Size(104, 20);
            this.txtDeb.TabIndex = 10;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(559, 144);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(37, 13);
            this.label17.TabIndex = 879;
            this.label17.Text = "مدين :";
            // 
            // txtPersonalName
            // 
            this.txtPersonalName.Location = new System.Drawing.Point(249, 88);
            this.txtPersonalName.Name = "txtPersonalName";
            this.netResize1.SetResizeTextBoxMultiline(this.txtPersonalName, false);
            this.txtPersonalName.Size = new System.Drawing.Size(304, 20);
            this.txtPersonalName.TabIndex = 6;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label19.Location = new System.Drawing.Point(559, 92);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(81, 13);
            this.label19.TabIndex = 96;
            this.label19.Text = "إسم المسؤول :";
            // 
            // buttonX_SerchAccNo
            // 
            this.buttonX_SerchAccNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_SerchAccNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_SerchAccNo.Location = new System.Drawing.Point(17, 10);
            this.buttonX_SerchAccNo.Name = "buttonX_SerchAccNo";
            this.buttonX_SerchAccNo.Size = new System.Drawing.Size(26, 20);
            this.buttonX_SerchAccNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_SerchAccNo.Symbol = "";
            this.buttonX_SerchAccNo.SymbolSize = 12F;
            this.buttonX_SerchAccNo.TabIndex = 3;
            this.buttonX_SerchAccNo.TextColor = System.Drawing.Color.SteelBlue;
            this.buttonX_SerchAccNo.Click += new System.EventHandler(this.buttonX_SerchAccNo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(324, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 90;
            this.label3.Text = "حساب الأب :";
            // 
            // textBox_ID
            // 
            this.textBox_ID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.textBox_ID.Location = new System.Drawing.Point(442, 10);
            this.textBox_ID.Name = "textBox_ID";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_ID, false);
            this.textBox_ID.Size = new System.Drawing.Size(111, 20);
            this.textBox_ID.TabIndex = 1;
            this.textBox_ID.Tag = "T_AccDef.AccDef_No";
            this.textBox_ID.Click += new System.EventHandler(this.textBox_ID_Click);
            this.textBox_ID.TextChanged += new System.EventHandler(this.textBox_ID_TextChanged);
            this.textBox_ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ID_KeyPress);
            this.textBox_ID.Leave += new System.EventHandler(this.textBox_ID_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(559, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 88;
            this.label4.Text = "رقم العميل :";
            // 
            // txtEngDes
            // 
            this.txtEngDes.BackColor = System.Drawing.Color.White;
            this.txtEngDes.Location = new System.Drawing.Point(250, 62);
            this.txtEngDes.Name = "txtEngDes";
            this.netResize1.SetResizeTextBoxMultiline(this.txtEngDes, false);
            this.txtEngDes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEngDes.Size = new System.Drawing.Size(303, 20);
            this.txtEngDes.TabIndex = 5;
            this.txtEngDes.Enter += new System.EventHandler(this.txtEngDes_Enter);
            this.txtEngDes.Leave += new System.EventHandler(this.txtArbDes_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(559, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 87;
            this.label2.Text = "الإسم الإنجليزي :";
            // 
            // txtArbDes
            // 
            this.txtArbDes.BackColor = System.Drawing.Color.White;
            this.txtArbDes.Location = new System.Drawing.Point(250, 36);
            this.txtArbDes.Name = "txtArbDes";
            this.netResize1.SetResizeTextBoxMultiline(this.txtArbDes, false);
            this.txtArbDes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtArbDes.Size = new System.Drawing.Size(303, 20);
            this.txtArbDes.TabIndex = 4;
            this.txtArbDes.Enter += new System.EventHandler(this.txtArbDes_Enter);
            this.txtArbDes.Leave += new System.EventHandler(this.txtArbDes_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(559, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 86;
            this.label1.Text = "الإسم العربي :";
            // 
            // txtMainAccNo
            // 
            this.txtMainAccNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMainAccNo.ForeColor = System.Drawing.Color.Maroon;
            this.txtMainAccNo.Location = new System.Drawing.Point(46, 10);
            this.txtMainAccNo.Name = "txtMainAccNo";
            this.txtMainAccNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtMainAccNo, false);
            this.txtMainAccNo.Size = new System.Drawing.Size(275, 20);
            this.txtMainAccNo.TabIndex = 2;
            this.txtMainAccNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMainAccNo.TextChanged += new System.EventHandler(this.txtMainAccNo_TextChanged);
            // 
            // txtCreditLimit
            // 
            this.txtCreditLimit.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtCreditLimit.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtCreditLimit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCreditLimit.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtCreditLimit.DisplayFormat = "0.00";
            this.txtCreditLimit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtCreditLimit.Increment = 1D;
            this.txtCreditLimit.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtCreditLimit.Location = new System.Drawing.Point(449, 114);
            this.txtCreditLimit.Name = "txtCreditLimit";
            this.txtCreditLimit.ShowUpDown = true;
            this.txtCreditLimit.Size = new System.Drawing.Size(104, 20);
            this.txtCreditLimit.TabIndex = 7;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(250, 166);
            this.txtAddress.Name = "txtAddress";
            this.netResize1.SetResizeTextBoxMultiline(this.txtAddress, false);
            this.txtAddress.Size = new System.Drawing.Size(303, 20);
            this.txtAddress.TabIndex = 13;
            // 
            // buttonX_CustomerStoped
            // 
            this.buttonX_CustomerStoped.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_CustomerStoped.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta;
            this.buttonX_CustomerStoped.Location = new System.Drawing.Point(449, 266);
            this.buttonX_CustomerStoped.Name = "buttonX_CustomerStoped";
            this.buttonX_CustomerStoped.Size = new System.Drawing.Size(196, 24);
            this.buttonX_CustomerStoped.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_CustomerStoped.Symbol = "";
            this.buttonX_CustomerStoped.SymbolSize = 12F;
            this.buttonX_CustomerStoped.TabIndex = 22;
            this.buttonX_CustomerStoped.Text = "العملاء الموقوفين";
            this.buttonX_CustomerStoped.TextColor = System.Drawing.Color.SteelBlue;
            this.buttonX_CustomerStoped.Click += new System.EventHandler(this.buttonX_CustomerStoped_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(358, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 94;
            this.label5.Text = "سبب الحظـــر :";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label21.Location = new System.Drawing.Point(127, 92);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(93, 13);
            this.label21.TabIndex = 908;
            this.label21.Text = "المنــــــــــــــدوب :";
            // 
            // CmbLegate
            // 
            this.CmbLegate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbLegate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbLegate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbLegate.FormattingEnabled = true;
            this.CmbLegate.ItemHeight = 13;
            this.CmbLegate.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.CmbLegate.Location = new System.Drawing.Point(17, 88);
            this.CmbLegate.Name = "CmbLegate";
            this.CmbLegate.Size = new System.Drawing.Size(104, 21);
            this.CmbLegate.TabIndex = 907;
            // 
            // c1BarCode1
            // 
            this.c1BarCode1.BarWide = 1;
            this.c1BarCode1.CodeType = C1.Win.C1BarCode.CodeTypeEnum.Code128;
            this.c1BarCode1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.c1BarCode1.Location = new System.Drawing.Point(990, 135);
            this.c1BarCode1.Name = "c1BarCode1";
            this.c1BarCode1.ShowText = true;
            this.c1BarCode1.Size = new System.Drawing.Size(142, 40);
            this.c1BarCode1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.c1BarCode1.TabIndex = 923;
            this.c1BarCode1.Text = "1225";
            // 
            // CmbPrice
            // 
            this.CmbPrice.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbPrice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbPrice.FormattingEnabled = true;
            this.CmbPrice.ItemHeight = 13;
            this.CmbPrice.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.CmbPrice.Location = new System.Drawing.Point(17, 114);
            this.CmbPrice.Name = "CmbPrice";
            this.CmbPrice.Size = new System.Drawing.Size(104, 21);
            this.CmbPrice.TabIndex = 9;
            // 
            // txtPlaceName
            // 
            this.txtPlaceName.BackColor = System.Drawing.Color.White;
            this.txtPlaceName.Location = new System.Drawing.Point(46, 268);
            this.txtPlaceName.Name = "txtPlaceName";
            this.netResize1.SetResizeTextBoxMultiline(this.txtPlaceName, false);
            this.txtPlaceName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPlaceName.Size = new System.Drawing.Size(307, 20);
            this.txtPlaceName.TabIndex = 1094;
            this.txtPlaceName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPlaceName.Visible = false;
            // 
            // line1
            // 
            this.line1.Location = new System.Drawing.Point(689, 116);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(768, 23);
            this.line1.TabIndex = 1299;
            this.line1.Text = "line1";
            this.line1.Visible = false;
            // 
            // switchButton_DisTyp
            // 
            // 
            // 
            // 
            this.switchButton_DisTyp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_DisTyp.Font = new System.Drawing.Font("Tahoma", 7F);
            this.switchButton_DisTyp.Location = new System.Drawing.Point(17, 40);
            this.switchButton_DisTyp.Name = "switchButton_DisTyp";
            this.switchButton_DisTyp.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.switchButton_DisTyp.OffText = "خصم سطور";
            this.switchButton_DisTyp.OffTextColor = System.Drawing.Color.White;
            this.switchButton_DisTyp.OnText = "خصم إجمالي";
            this.switchButton_DisTyp.Size = new System.Drawing.Size(95, 21);
            this.switchButton_DisTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_DisTyp.SwitchWidth = 22;
            this.switchButton_DisTyp.TabIndex = 1303;
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
            this.ribbonBar_Tasks.Font = new System.Drawing.Font("Tahoma", 7F);
            this.ribbonBar_Tasks.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar_Tasks.Location = new System.Drawing.Point(0, 325);
            this.ribbonBar_Tasks.Name = "ribbonBar_Tasks";
            this.ribbonBar_Tasks.Size = new System.Drawing.Size(658, 51);
            this.ribbonBar_Tasks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar_Tasks.TabIndex = 870;
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
            this.superTabControl_Main1.Size = new System.Drawing.Size(224, 51);
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
            this.Button_Add.Click += new System.EventHandler(this.Button_Add_Click_1);
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
            this.superTabControl_Main2.Location = new System.Drawing.Point(224, 0);
            this.superTabControl_Main2.Name = "superTabControl_Main2";
            this.superTabControl_Main2.ReorderTabsEnabled = true;
            this.superTabControl_Main2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.superTabControl_Main2.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_Main2.SelectedTabIndex = -1;
            this.superTabControl_Main2.Size = new System.Drawing.Size(434, 51);
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
            this.superTabControl_Main2.SelectedTabChanged += new System.EventHandler<DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs>(this.superTabControl_Main2_SelectedTabChanged);
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
            // Rep_RecCount
            // 
            this.Rep_RecCount.AllowEmptyState = false;
            // 
            // 
            // 
            this.Rep_RecCount.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Rep_RecCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Rep_RecCount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.Rep_RecCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Rep_RecCount.Increment = 0;
            this.Rep_RecCount.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.Rep_RecCount.IsInputReadOnly = true;
            this.Rep_RecCount.Location = new System.Drawing.Point(816, 445);
            this.Rep_RecCount.Name = "Rep_RecCount";
            this.Rep_RecCount.Size = new System.Drawing.Size(73, 21);
            this.Rep_RecCount.TabIndex = 852;
            this.Rep_RecCount.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // ToolStripMenuItem_Rep
            // 
            this.ToolStripMenuItem_Rep.Checked = true;
            this.ToolStripMenuItem_Rep.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToolStripMenuItem_Rep.Name = "ToolStripMenuItem_Rep";
            this.ToolStripMenuItem_Rep.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem_Rep.Text = "إظهار التقرير";
            // 
            // barTopDockSite
            // 
            this.barTopDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barTopDockSite.Dock = System.Windows.Forms.DockStyle.Top;
            this.barTopDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barTopDockSite.Location = new System.Drawing.Point(0, 0);
            this.barTopDockSite.Name = "barTopDockSite";
            this.barTopDockSite.Size = new System.Drawing.Size(658, 0);
            this.barTopDockSite.TabIndex = 869;
            this.barTopDockSite.TabStop = false;
            // 
            // barBottomDockSite
            // 
            this.barBottomDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barBottomDockSite.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barBottomDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barBottomDockSite.Location = new System.Drawing.Point(0, 376);
            this.barBottomDockSite.Name = "barBottomDockSite";
            this.barBottomDockSite.Size = new System.Drawing.Size(658, 0);
            this.barBottomDockSite.TabIndex = 870;
            this.barBottomDockSite.TabStop = false;
            // 
            // barLeftDockSite
            // 
            this.barLeftDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barLeftDockSite.Dock = System.Windows.Forms.DockStyle.Left;
            this.barLeftDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barLeftDockSite.Location = new System.Drawing.Point(0, 0);
            this.barLeftDockSite.Name = "barLeftDockSite";
            this.barLeftDockSite.Size = new System.Drawing.Size(0, 376);
            this.barLeftDockSite.TabIndex = 871;
            this.barLeftDockSite.TabStop = false;
            // 
            // barRightDockSite
            // 
            this.barRightDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barRightDockSite.Dock = System.Windows.Forms.DockStyle.Right;
            this.barRightDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barRightDockSite.Location = new System.Drawing.Point(658, 0);
            this.barRightDockSite.Name = "barRightDockSite";
            this.barRightDockSite.Size = new System.Drawing.Size(0, 376);
            this.barRightDockSite.TabIndex = 872;
            this.barRightDockSite.TabStop = false;
            // 
            // dockSite1
            // 
            this.dockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite1.Location = new System.Drawing.Point(0, 0);
            this.dockSite1.Name = "dockSite1";
            this.dockSite1.Size = new System.Drawing.Size(0, 376);
            this.dockSite1.TabIndex = 873;
            this.dockSite1.TabStop = false;
            // 
            // dockSite2
            // 
            this.dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite2.Location = new System.Drawing.Point(658, 0);
            this.dockSite2.Name = "dockSite2";
            this.dockSite2.Size = new System.Drawing.Size(0, 376);
            this.dockSite2.TabIndex = 874;
            this.dockSite2.TabStop = false;
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
            // dockSite4
            // 
            this.dockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite4.Location = new System.Drawing.Point(0, 376);
            this.dockSite4.Name = "dockSite4";
            this.dockSite4.Size = new System.Drawing.Size(658, 0);
            this.dockSite4.TabIndex = 876;
            this.dockSite4.TabStop = false;
            // 
            // dockSite3
            // 
            this.dockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite3.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite3.Location = new System.Drawing.Point(0, 0);
            this.dockSite3.Name = "dockSite3";
            this.dockSite3.Size = new System.Drawing.Size(658, 0);
            this.dockSite3.TabIndex = 875;
            this.dockSite3.TabStop = false;
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
            // integerInput1
            // 
            this.integerInput1.AllowEmptyState = false;
            // 
            // 
            // 
            this.integerInput1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.integerInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.integerInput1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.integerInput1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.integerInput1.Increment = 0;
            this.integerInput1.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.integerInput1.IsInputReadOnly = true;
            this.integerInput1.Location = new System.Drawing.Point(729, 391);
            this.integerInput1.Name = "integerInput1";
            this.integerInput1.Size = new System.Drawing.Size(73, 21);
            this.integerInput1.TabIndex = 868;
            this.integerInput1.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
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
            this.panelEx3.Size = new System.Drawing.Size(658, 0);
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
            this.DGV_Main.Size = new System.Drawing.Size(658, 0);
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
            this.ribbonBar_DGV.Size = new System.Drawing.Size(658, 51);
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
            this.superTabControl_DGV.Size = new System.Drawing.Size(658, 51);
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
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // panelEx2
            // 
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx2.Location = new System.Drawing.Point(0, 14);
            this.panelEx2.MinimumSize = new System.Drawing.Size(658, 362);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(658, 362);
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
            this.expandableSplitter1.Location = new System.Drawing.Point(0, 0);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(658, 14);
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
            this.panel1.Size = new System.Drawing.Size(658, 376);
            this.panel1.TabIndex = 877;
            // 
            // printDialog1
            // 
            this.printDialog1.AllowSelection = true;
            this.printDialog1.AllowSomePages = true;
            this.printDialog1.Document = this.prnt_doc;
            this.printDialog1.UseEXDialog = true;
            // 
            // prnt_doc
            // 
            this.prnt_doc.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.prnt_doc_BeginPrint);
            this.prnt_doc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.prnt_doc_PrintPage);
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
            this.prnt_prev.ShowIcon = false;
            this.prnt_prev.Visible = false;
            // 
            // netResize1
            // 
            this.netResize1.ParentControl = this;
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            // 
            // FrmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 376);
            this.Controls.Add(this.PanelSpecialContainer);
            this.Controls.Add(this.integerInput1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Rep_RecCount);
            this.Controls.Add(this.barTopDockSite);
            this.Controls.Add(this.barBottomDockSite);
            this.Controls.Add(this.barLeftDockSite);
            this.Controls.Add(this.barRightDockSite);
            this.Controls.Add(this.dockSite1);
            this.Controls.Add(this.dockSite2);
            this.Controls.Add(this.dockSite3);
            this.Controls.Add(this.dockSite4);
            this.Icon = global::InvAcc.Properties.Resources.favicon;
            this.KeyPreview = true;
            this.Name = "FrmCustomer";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "العملاء";
            this.Load += new System.EventHandler(this.FrmCustomer_Load);
            this.Shown += new System.EventHandler(this.FrmCustomer_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.PanelSpecialContainer.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            this.ribbonBar1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxDis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgeLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBalance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCredit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreditLimit)).EndInit();
            this.ribbonBar_Tasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rep_RecCount)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.integerInput1)).EndInit();
            this.panelEx3.ResumeLayout(false);
            this.ribbonBar_DGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_DGV)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);

        }
        private void ksdjfa(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;
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
            else if (e.KeyCode == Keys.F5 && Button_PrintTable.Enabled && Button_PrintTable.Visible && !expandableSplitter1.Expanded)
            {
                Button_Print_Click(sender, e);
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
            var qkeys = from item in db.T_AccDefs
                        where item.Lev == (int?)4 && item.AccCat == (int?)4
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
        private void LockedFrm(bool Stat)
        {
            if (State == FormState.New)
            {
                textBox_ID.ReadOnly = true;
                txtMainAccNo.ReadOnly = true;
                buttonX_SerchAccNo.Enabled = true;
            }
            else
            {
                textBox_ID.ReadOnly = true;
                txtMainAccNo.ReadOnly = true;
                buttonX_SerchAccNo.Enabled = false;
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
        public FrmCustomer()
        {
            InitializeComponent();
            txtAddress.Click += Button_Edit_Click;
            txtAgeLimit.Click += Button_Edit_Click;
            txtArbDes.Click += Button_Edit_Click;
            txtMaxDis.Click += Button_Edit_Click;
            switchButton_DisTyp.Click += Button_Edit_Click;
            txtPersonalName.Click += Button_Edit_Click;
            txtZipCod.Click += Button_Edit_Click;
            txtRessonsStoped.Click += Button_Edit_Click;
            checkBoxX_Stoped.Click += Button_Edit_Click;
            txtTaxNo.Click += Button_Edit_Click;
            txtBalance.Click += Button_Edit_Click;
            txtCity.Click += Button_Edit_Click;
            txtCredit.Click += Button_Edit_Click;
            txtCreditLimit.Click += Button_Edit_Click;
            txtEngDes.Click += Button_Edit_Click;
            txtDeb.Click += Button_Edit_Click;
            txtEMail.Click += Button_Edit_Click;
            txtFax.Click += Button_Edit_Click;
            txtMobile.Click += Button_Edit_Click;
            txtTele1.Click += Button_Edit_Click;
            txtTele2.Click += Button_Edit_Click;
            txtAge.Click += Button_Edit_Click;
            buttonX_SerchAccNo.TextChanged += Button_Edit_Click;
            CmbPrice.Click += Button_Edit_Click;
            CmbLegate.Click += Button_Edit_Click;
            CmbInvTyp.Click += Button_Edit_Click;
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
            Button_Search.Click += Button_Search_Click;
            Button_Delete.Click += Button_Delete_Click;
            Button_Save.Click += Button_Save_Click;
            TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
            buttonX_SerchAccNo.TextChanged += buttonX_SerchAccNo_Click;
            Button_PrintTable.Click += Button_Print_Click;
            GetInvSetting();
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
            {
                txtCreditLimit.DisplayFormat = VarGeneral.DicemalMask;
                txtDeb.DisplayFormat = VarGeneral.DicemalMask;
                txtCredit.DisplayFormat = VarGeneral.DicemalMask;
                txtBalance.DisplayFormat = VarGeneral.DicemalMask;
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
        public void Button_Search_Click(object sender, EventArgs e)
        {
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_AccDef_Suppliers";
            VarGeneral.AccTyp = 4;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                textBox_ID.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
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
            List<T_AccDef> list = db.FillAccDef_2(textBox_search.TextBox.Text, 4, 4).ToList();
            if (list.Count() > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].Debit = list[i].T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.gdValue > 0.0).Sum((T_GDDET g) => g.gdValue.Value);
                    list[i].Credit = Math.Abs(list[i].T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.gdValue < 0.0).Sum((T_GDDET g) => g.gdValue.Value));
                    list[i].Balance = list[i].T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok).Sum((T_GDDET g) => g.gdValue.Value);
                }
            }
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
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
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {   ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmCustomer));
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
            label1.Text = (VarGeneral.UserLang == 0 ? "الإسم العربي :" : "Arabic Name:");
            label10.Text = (VarGeneral.UserLang == 0 ? "عمر الدين :" : "indebtedness Dates:");
            label11.Text = (VarGeneral.UserLang == 0 ? "ص . ب :" : " P.oF");
            label12.Text = (VarGeneral.UserLang == 0 ? "الفاكس :" : "Fax:");
            label13.Text = (VarGeneral.UserLang == 0 ? "الجوال :" : "Mobile");
            label14.Text = (VarGeneral.UserLang == 0 ? "دائن :" : "creditor:");
            label15.Text = (VarGeneral.UserLang == 0 ? "الرصيد الحالي :" : "Current Balance:");
            label16.Text = (VarGeneral.UserLang == 0 ? "حد المديونية :" : "Debit:");
            label17.Text = (VarGeneral.UserLang == 0 ? "مدين :" : "Debit:");
            label18.Text = (VarGeneral.UserLang == 0 ? "السعر الإفتراضي :" : "Default price:");
            label19.Text = (VarGeneral.UserLang == 0 ? "إسم المسؤول :" : "Admin Name:");
            label2.Text = (VarGeneral.UserLang == 0 ? "الإسم الإنجليزي :" : "English name:");
            label20.Text = (VarGeneral.UserLang == 0 ? "الرمز البريدي :" : "Zip Code:");
            label21.Text = (VarGeneral.UserLang == 0 ? "المنــــــــــــــدوب :" : "Delegate:");
            label22.Text = (VarGeneral.UserLang == 0 ? "الــرقم الضريبـــي :" : "Tax No");
            label23.Text = (VarGeneral.UserLang == 0 ? "نسبة الخصم :" : "Discount Percentage:");
            label24.Text = (VarGeneral.UserLang == 0 ? "%" : "%");
            label25.Text = (VarGeneral.UserLang == 0 ? "العمـــر :" : "Age :");
            label3.Text = (VarGeneral.UserLang == 0 ? "حساب الأب :" : "Father Acc:");
            label4.Text = (VarGeneral.UserLang == 0 ? "رقم العميل :" : "Custumer No:");
            label5.Text = (VarGeneral.UserLang == 0 ? "سبب الحظـــر :" : "Reasone Of Block:");
            label6.Text = (VarGeneral.UserLang == 0 ? "العنوان :" : "Address :");
            label7.Text = (VarGeneral.UserLang == 0 ? "الإيميل :" : "Email:");
            label8.Text = (VarGeneral.UserLang == 0 ? "البلد :" : "Counter:");
            label9.Text = (VarGeneral.UserLang == 0 ? "الهاتف :" : "Telphone");

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
                label4.Text = "رقم العميل :";
                label3.Text = "حساب الأب :";
                label1.Text = "الإسم - عربي :";
                label2.Text = "الإسم - إنجليزي :";
                label19.Text = "إسم المسؤول :";
                label16.Text = "حد المديونية :";
                label10.Text = "عمر الدين :";
                label18.Text = "السعر الإفتراضي :";
                label17.Text = "مدين :";
                label14.Text = "دائن :";
                label15.Text = "الرصيد الحالي :";
                label6.Text = "العنوان :";
                label8.Text = "البلد :";
                label9.Text = "الهاتف :";
                label12.Text = "الفاكس :";
                label13.Text = "الجوال :";
                label11.Text = "ص . ب :";
                label20.Text = "الرمز البريدي :";
                label7.Text = "الإيميل :";
                label25.Text = "العمـــر :";
                Text = "كرت العمــــلاء";
                checkBoxX_Stoped.Text = "حظر العميل";
                buttonX_CustomerStoped.Text = "العملاء الموقوفين";
                label5.Text = "سبب الحظر :";
                switchButton_DisTyp.OffText = "خصم سطور";
                switchButton_DisTyp.OnText = "خصم إجمالي";
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
                label4.Text = "Customer No :";
                label3.Text = "Account No :";
                label1.Text = "Name - Arabic :";
                label2.Text = "Name - English :";
                label19.Text = "The official name :";
                label16.Text = "Debt limit :";
                label10.Text = "Life of the loan :";
                label18.Text = "Price Default :";
                label17.Text = "Debtor :";
                label14.Text = "Creditor :";
                label15.Text = "Balance :";
                label6.Text = "Address :";
                label8.Text = "Country :";
                label9.Text = "Tel :";
                label12.Text = "Fax :";
                label13.Text = "Mobile :";
                label11.Text = "PO Box :";
                label20.Text = "Postal Code :";
                label7.Text = "Email :";
                label25.Text = "Age :";
                Text = "Customers Card";
                checkBoxX_Stoped.Text = "Customer ban";
                buttonX_CustomerStoped.Text = "Customers arrested";
                label5.Text = "The reason for the ban :";
                switchButton_DisTyp.OffText = "Discount lines";
                switchButton_DisTyp.OnText = "Discount Total";
            }
        }
        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmCustomer));
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
                    CmbInvTyp.Visible = false;
                    label18.Visible = false;
                    CmbPrice.Visible = false;
                }
                ADD_Controls();
                LockedFrm(Stat: true);
                Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
                if (columns_Names_visible.Count == 0)
                {
                    columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
                    columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
                    columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
                    columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
                    columns_Names_visible.Add("Adders", new ColumnDictinary("العنوان", "Address", ifDefault: true, ""));
                    columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, ""));
                }
                else
                {
                    Clear();
                    textBox_ID.Text = "";
                    TextBox_Index.TextBox.Text = "";
                }
                RefreshPKeys();
                FillCombo();
                RibunButtons();
                textBox_ID.Text = PKeys.FirstOrDefault();
                ViewDetails_Click(sender, e);
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptCustBarcode.dll"))
                {
                    button_Barcode.Visible = true;
                }
                else
                {
                    button_Barcode.Visible = false;
                }
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptInvitationCards.dll"))
                {
                    Script_InvitationCards();
                }
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptSchool.dll"))
                {
                    Script_School();
                }
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptMaintenanceCars.dll"))
                {
                    MaintenanceCars();
                }
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptBus.dll"))
                {
                    label21.Text = ((LangArEn == 0) ? "الســـائق :" : "Driver :");
                }
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptTegnicalCollage.dll"))
                {
                    TegnicalCollage();
                }
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptWaterPackages.dll"))
                {
                    WaterPackages();
                }
                if (File.Exists(Application.StartupPath + "\\Script\\Secriptjustlight.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", "").Trim() + "\\Secriptjustlight.dll")))
                {
                    justlight();
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void WaterPackages()
        {
            Text = ((LangArEn == 0) ? "كرت السائقــين" : "Drivers Card");
            label4.Text = ((LangArEn == 0) ? "رقم السائق :" : "Driver No :");
            label19.Text = ((LangArEn == 0) ? "رقــم الإقـامــة :" : "ID No :");
            label12.Visible = false;
            txtFax.Visible = false;
            label11.Text = ((LangArEn == 0) ? "المساعد :" : "Partner :");
            txtTele2.Width = txtPersonalName.Width;
            txtTele2.Location = new Point(txtPersonalName.Location.X, txtTele2.Location.Y);
            label20.Visible = false;
            txtZipCod.Visible = false;
            label7.Text = ((LangArEn == 0) ? "رقم إقامتة :" : "Partner ID :");
            txtPersonalName.KeyPress += txtTele1_KeyPress;
            txtEMail.KeyPress += txtTele1_KeyPress;
            txtEMail.TextAlign = HorizontalAlignment.Center;
            txtPersonalName.TextAlign = HorizontalAlignment.Center;
            label22.Visible = false;
            txtTaxNo.Visible = false;
            label21.Visible = false;
            CmbLegate.Visible = false;
            label18.Visible = false;
            CmbPrice.Visible = false;
            label17.Visible = false;
            txtDeb.Visible = false;
            label14.Visible = false;
            txtCredit.Visible = false;
            label15.Visible = false;
            txtBalance.Visible = false;
            checkBoxX_Stoped.Visible = false;
            label5.Visible = false;
            txtRessonsStoped.Visible = false;
            buttonX_CustomerStoped.Visible = false;
            CmbInvTyp.Visible = false;
            txtCreditLimit.Visible = false;
            label16.Visible = false;
            line1.Visible = true;
            line1.Thickness = 2;
            line1.Location = new Point(-90, 122);
        }
        private void TegnicalCollage()
        {
            Text = ((LangArEn == 0) ? "الطـــلاب" : "Students");
            label4.Text = ((LangArEn == 0) ? "رقم الطالب :" : "Student No :");
            label22.Visible = false;
            txtTaxNo.Visible = false;
            label21.Visible = false;
            CmbLegate.Visible = false;
            label18.Visible = false;
            CmbPrice.Visible = false;
            label17.Visible = false;
            txtDeb.Visible = false;
            label14.Visible = false;
            txtCredit.Visible = false;
            label15.Visible = false;
            txtBalance.Visible = false;
            checkBoxX_Stoped.Visible = false;
            label5.Visible = false;
            txtRessonsStoped.Visible = false;
            buttonX_CustomerStoped.Visible = false;
            CmbInvTyp.Visible = false;
            txtCreditLimit.Visible = false;
            label16.Visible = false;
            line1.Visible = true;
            line1.Thickness = 2;
            line1.Location = new Point(-90, 122);
        }
        private void Script_InvitationCards()
        {
            button_SrchPlaceNo.Visible = true;
            txtRessonsStoped.Multiline = false;
            txtRessonsStoped.ReadOnly = true;
            txtRessonsStoped.TextAlign = HorizontalAlignment.Center;
            txtPlaceName.Visible = true;
            label5.Text = ((LangArEn == 0) ? "حساب المكان :" : "Place Acc :");
        }
        private void Script_School()
        {
            button_SrchPlaceNo.Visible = true;
            txtRessonsStoped.Multiline = false;
            txtRessonsStoped.ReadOnly = true;
            txtRessonsStoped.TextAlign = HorizontalAlignment.Center;
            txtPlaceName.Visible = true;
            Text = ((LangArEn == 0) ? "الطـــلاب" : "Students");
            label19.Text = ((LangArEn == 0) ? "ولي الأمر :" : "Guardian :");
            label4.Text = ((LangArEn == 0) ? "رقم الطالب :" : "Student No :");
            label22.Visible = false;
            txtTaxNo.Visible = false;
            CmbInvTyp.Visible = false;
        }
        private void justlight()
        {
            label8.Text = ((LangArEn == 0) ? "الجنسيـــة :" : "Nationality :");
            label7.Text = ((LangArEn == 0) ? "رقم الهوية :" : "ID No :");
            label19.Text = ((LangArEn == 0) ? "رقم الهوية_سند :" : "ID No :");
            label22.Text = ((LangArEn == 0) ? "المصــــــدر :" : "Source :");
        }
        private void MaintenanceCars()
        {
            button_SrchPlaceNo.Visible = true;
            txtRessonsStoped.Multiline = false;
            txtRessonsStoped.ReadOnly = true;
            txtRessonsStoped.TextAlign = HorizontalAlignment.Center;
            txtPlaceName.Visible = true;
            Text = ((LangArEn == 0) ? "السيــارات" : "Cars");
            label6.Text = ((LangArEn == 0) ? "رقم الشاص :" : "Chase No :");
            label4.Text = ((LangArEn == 0) ? "رقم السيارة :" : "Car No :");
            label21.Text = ((LangArEn == 0) ? "نوع السيارة :" : "Car Type :");
            label19.Text = ((LangArEn == 0) ? "لون السيارة :" : "Car Color :");
            label8.Text = ((LangArEn == 0) ? "رقم اللوحة :" : "Plate Number :");
            label9.Text = ((LangArEn == 0) ? "سنة الصنع :" : "Year :");
            label12.Visible = false;
            txtFax.Visible = false;
            label13.Visible = false;
            txtMobile.Visible = false;
            label11.Visible = false;
            txtTele2.Visible = false;
            label20.Visible = false;
            txtZipCod.Visible = false;
            label7.Visible = false;
            txtEMail.Visible = false;
            label22.Visible = false;
            txtTaxNo.Visible = false;
            CmbInvTyp.Visible = false;
            CmbPrice.Visible = false;
            label18.Visible = false;
            label16.Visible = false;
            txtCreditLimit.Visible = false;
            checkBoxX_Stoped.Visible = false;
            label5.Visible = false;
            txtRessonsStoped.Visible = false;
            button_SrchPlaceNo.Visible = false;
            buttonX_CustomerStoped.Visible = false;
            txtPlaceName.Visible = false;
            txtEngDes.Width = txtArbDes.Width;
            txtEngDes.Location = new Point(txtArbDes.Location.X, txtEngDes.Location.Y);
            line1.Visible = true;
            line1.Location = new Point(-90, 116);
        }
        private void FillCombo()
        {
            int _CmbIndex = CmbPrice.SelectedIndex;
            CmbPrice.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                CmbPrice.Items.Add("الافتراضي");
                CmbPrice.Items.Add("سعر الجملة");
                CmbPrice.Items.Add("سعر الموزع");
                CmbPrice.Items.Add("سعر المندوب");
                CmbPrice.Items.Add("سعر التجزئة");
                CmbPrice.Items.Add("سعر آخر");
            }
            else
            {
                CmbPrice.Items.Add("Defualt");
                CmbPrice.Items.Add("Wholesale price");
                CmbPrice.Items.Add("Distributor price");
                CmbPrice.Items.Add("Legates Price");
                CmbPrice.Items.Add("Retail price");
                CmbPrice.Items.Add("another Price");
            }
            CmbPrice.SelectedIndex = _CmbIndex;
            CmbInvTyp.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                CmbInvTyp.Items.Add("خيـــارات البيـــع");
                CmbInvTyp.Items.Add("إيقاف البيع النقدي");
                CmbInvTyp.Items.Add("إيقاف البيع الآجل");
            }
            else
            {
                CmbInvTyp.Items.Add("Sales Options");
                CmbInvTyp.Items.Add("Stop cash sales");
                CmbInvTyp.Items.Add("Stop Future sales");
            }
            CmbInvTyp.SelectedIndex = 0;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                List<T_Mndob> listMnd = new List<T_Mndob>(db.T_Mndobs.Select((T_Mndob item) => item).ToList());
                listMnd.Insert(0, new T_Mndob());
                CmbLegate.DataSource = listMnd;
                CmbLegate.DisplayMember = "Arb_Des";
                CmbLegate.ValueMember = "Mnd_ID";
            }
            else
            {
                List<T_Mndob> listMnd = new List<T_Mndob>(db.T_Mndobs.Select((T_Mndob item) => item).ToList());
                listMnd.Insert(0, new T_Mndob());
                CmbLegate.DataSource = listMnd;
                CmbLegate.DisplayMember = "Eng_Des";
                CmbLegate.ValueMember = "Mnd_ID";
            }
            CmbLegate.SelectedIndex = 0;
        }
        private void GetInvSetting()
        {
            _InvSetting = db.StockInvSetting(VarGeneral.UserID, 22);
            _Company = db.StockCompanyList().FirstOrDefault();
        }
        private void textBox_ID_TextChanged(object sender, EventArgs e)
        {
            long no = 0L;
            try
            {
                no = long.Parse(textBox_ID.Text);
            }
            catch
            {
            }
            try
            {
                T_AccDef newData = db.StockAccDef(no.ToString());
                if (newData == null || string.IsNullOrEmpty(newData.AccDef_No))
                {
                    if (!Button_Add.Visible || !Button_Add.Enabled)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textBox_ID.TextChanged -= textBox_ID_TextChanged;
                        try
                        {
                            textBox_ID.Text = data_this.AccDef_No;
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
                    int indexA = PKeys.IndexOf(newData.AccDef_No ?? "");
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
            switchButton_DisTyp.Value = false;
            textBox_ID.Focus();
            SetReadOnly = false;
        }
        public void SetData(T_AccDef value)
        {
            try
            {
                State = FormState.Saved;
                Button_Save.Enabled = false;
                textBox_ID.Tag = value.AccDef_ID.ToString();
                txtEngDes.Text = value.Eng_Des;
                txtArbDes.Text = value.Arb_Des;
                txtMaxDis.Value = value.MaxDisCust.Value;
                if (value.vColNum1.Value == 1.0)
                {
                    switchButton_DisTyp.Value = true;
                }
                else
                {
                    switchButton_DisTyp.Value = false;
                }
                txtRessonsStoped.Text = value.RessonStoped;
                txtPersonalName.Text = value.PersonalNm;
                txtTaxNo.Text = value.TaxNo;
                txtZipCod.Text = value.zipCod;
                try
                {
                    checkBoxX_Stoped.Checked = value.StopedState.Value;
                }
                catch
                {
                    checkBoxX_Stoped.Checked = false;
                }
                txtMainAccNo.Text = value.ParAcc;
                txtBalance.Value = (value.Balance.HasValue ? value.Balance.Value : 0.0);
                txtCredit.Value = (value.Credit.HasValue ? value.Credit.Value : 0.0);
                txtDeb.Value = (value.Debit.HasValue ? value.Debit.Value : 0.0);
                if (value.Price.HasValue)
                {
                    CmbPrice.SelectedIndex = value.Price.Value;
                }
                else
                {
                    CmbPrice.SelectedIndex = 0;
                }
                if (value.Mnd.HasValue)
                {
                    CmbLegate.SelectedValue = value.Mnd;
                }
                else
                {
                    CmbLegate.SelectedIndex = 0;
                }
                if (value.StopInvTyp.HasValue)
                {
                    CmbInvTyp.SelectedIndex = value.StopInvTyp.Value;
                }
                else
                {
                    CmbInvTyp.SelectedIndex = 0;
                }
                txtCreditLimit.Text = value.MaxLemt.ToString();
                txtCity.Text = value.City ?? "";
                txtEMail.Text = value.Email ?? "";
                txtTele1.Text = value.Telphone1 ?? "";
                txtTele2.Text = value.Telphone2 ?? "";
                txtFax.Text = value.Fax ?? "";
                txtMobile.Text = value.Mobile ?? "";
                txtAgeLimit.Text = value.StrAm.ToString();
                txtAddress.Text = value.Adders ?? "";
                txtAge.Text = value.vColStr1 ?? "";
                checkBoxX_Stoped_CheckedChanged(null, null);
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
        private T_AccDef GetData()
        {
            textBox_ID.Focus();
            data_this.Arb_Des = txtArbDes.Text;
            data_this.MaxDisCust = txtMaxDis.Value;
            if (switchButton_DisTyp.Value)
            {
                data_this.vColNum1 = 1.0;
            }
            else
            {
                data_this.vColNum1 = 0.0;
            }
            data_this.PersonalNm = txtPersonalName.Text;
            data_this.zipCod = txtZipCod.Text;
            data_this.TaxNo = txtTaxNo.Text;
            try
            {
                if (State == FormState.New)
                {
                    if (data_this.DepreciationPercent.HasValue)
                    {
                        data_this.DepreciationPercent = data_this.DepreciationPercent.Value;
                    }
                    else
                    {
                        data_this.DepreciationPercent = 0.0;
                    }
                    if (data_this.vColNum2.HasValue)
                    {
                        data_this.vColNum2 = data_this.vColNum2.Value;
                    }
                    else
                    {
                        data_this.vColNum2 = 0.0;
                    }
                    if (!string.IsNullOrEmpty(data_this.vColStr2))
                    {
                        data_this.vColStr2 = data_this.vColStr2;
                    }
                    else
                    {
                        data_this.vColStr2 = "";
                    }
                    if (!string.IsNullOrEmpty(data_this.vColStr3))
                    {
                        data_this.vColStr3 = data_this.vColStr3;
                    }
                    else
                    {
                        data_this.vColStr3 = "";
                    }
                }
            }
            catch
            {
            }
            data_this.RessonStoped = txtRessonsStoped.Text;
            data_this.StopedState = checkBoxX_Stoped.Checked;
            data_this.Eng_Des = txtEngDes.Text;
            data_this.AccDef_No = textBox_ID.Text;
            data_this.Lev = 4;
            data_this.ParAcc = txtMainAccNo.Text;
            data_this.AccCat = 4;
            if (State == FormState.New)
            {
                data_this.DC = 0;
                data_this.Trn = 3;
            }
            data_this.Sts = 0;
            if (double.TryParse(txtCreditLimit.Text, out var value))
            {
                data_this.MaxLemt = value;
            }
            else
            {
                data_this.MaxLemt = 0.0;
            }
            data_this.Typ = "";
            data_this.City = txtCity.Text ?? "";
            data_this.Email = txtEMail.Text ?? "";
            data_this.Telphone1 = txtTele1.Text ?? "";
            data_this.Telphone2 = txtTele2.Text ?? "";
            data_this.vColStr1 = txtAge.Text ?? "";
            data_this.Fax = txtFax.Text ?? "";
            data_this.Mobile = txtMobile.Text ?? "";
            data_this.DesPers = "";
            data_this.StrAm = int.Parse(txtAgeLimit.Text);
            data_this.Adders = txtAddress.Text ?? "";
            data_this.Price = CmbPrice.SelectedIndex;
            if (CmbLegate.SelectedIndex > 0)
            {
                data_this.Mnd = int.Parse(CmbLegate.SelectedValue.ToString());
            }
            else
            {
                data_this.Mnd = null;
            }
            data_this.StopInvTyp = CmbInvTyp.SelectedIndex;
            data_this.BankComm = 0.0;
            if (State == FormState.New)
            {
                data_this.TotPoints = 0.0;
            }
            data_this.CompanyID = 1;
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
                LockedFrm(Stat: false);
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
                Clear();
                int id = db.MaxAccDefNo;
                textBox_ID.Tag = id.ToString();
                State = FormState.New;
                LockedFrm(Stat: false);
                try
                {
                    T_AccDef q = db.StockAccDefWithOutBalance("1022");
                    if (q != null && !string.IsNullOrEmpty(q.AccDef_No))
                    {
                        txtMainAccNo.Text = "1022";
                    }
                }
                catch
                {
                }
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
                if (State == FormState.New && !Button_Add.Enabled)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                textBox_ID.Focus();
                if (textBox_ID.Text == "" || txtArbDes.Text == "" || txtEngDes.Text == "")
                {
                    MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الرمز او الإسم فارغا\u0651" : "Can not be a number or name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                try
                {
                    if (VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 14) && State == FormState.New)
                    {
                        IdProof = "";
                        if (string.IsNullOrEmpty(txtMobile.Text) || string.IsNullOrEmpty(VarGeneral.Settings_Sys.smsUserName) || string.IsNullOrEmpty(VarGeneral.Settings_Sys.smsPass) || string.IsNullOrEmpty(VarGeneral.Settings_Sys.smsSenderName.Trim()))
                        {
                            MessageBox.Show((LangArEn == 0) ? "لم يتم ارسال رسالة نصية الى جوال العميل .. يرجى التأكد من صحة بيانات إعدادات الرسائل النصية" : "SMS Message was not sent to the Boss .. Please make sure the settings information is correct.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }
                        if (!SendMobileMessage())
                        {
                            return;
                        }
                        string vNewNo = InputDialog.mostrar((LangArEn == 0) ? "أدخل الرمز التأكيدي المرسل للعميل : " : "Enter the confirmation code sent to the customer : ", "Confirm Customer Identity");
                        if (vNewNo != IdProof)
                        {
                            MessageBox.Show((LangArEn == 0) ? ".. يرجى التأكد من صحة الرمز" : "Please make sure the code", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show((LangArEn == 0) ? "لم يتم ارسال رسالة نصية الى جوال العميل .. يرجى التأكد من صحة بيانات إعدادات الرسائل النصية" : "SMS Message was not sent to the Boss .. Please make sure the settings information is correct.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (State != FormState.New || string.IsNullOrEmpty(txtMobile.Text))
                {
                    goto IL_047c;
                }
                List<T_AccDef> q = (from item in db.T_AccDefs
                                    where item.Lev == (int?)4 && item.AccCat == (int?)4
                                    where item.Mobile == txtMobile.Text
                                    orderby item.AccDef_No
                                    select item).ToList();
                if (!VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 18) || q.Count <= 0)
                {
                    goto IL_047c;
                }
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                goto end_IL_0001;
            IL_047c:
                GetData();
                if (State == FormState.New)
                {
                    try
                    {
                        data_this.MainSal = 0.0;
                        data_this.Credit = 0.0;
                        data_this.Debit = 0.0;
                        data_this.Balance = 0.0;
                        db.T_AccDefs.InsertOnSubmit(data_this);
                        db.SubmitChanges();
                    }
                    catch (SqlException ex5)
                    {
                        if (ex5.Number != 2627)
                        {
                            return;
                        }
                        MessageBox.Show("الرقم مستخدم من قبل.\n سيتم الحفظ برقم جديد ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        int id = db.MaxAccDefNo;
                        textBox_ID.Tag = id.ToString();
                        Button_Save_Click(sender, e);
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
                else if (State == FormState.Edit)
                {
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
                State = FormState.Saved;
                RefreshPKeys();
                TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(data_this.AccDef_No ?? "") + 1);
                SetReadOnly = true;
                LockedFrm(Stat: true);
            end_IL_0001:;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        private bool SendMobileMessage()
        {
            try
            {
                IdProof = RandomNumber(1000, 9999).ToString();
                string msgTxt = ((LangArEn == 0) ? ("رمز تأكيد الهوية هو :  " + IdProof) : ("The confirmation code is : " + IdProof));
                Regex regex = new Regex("^\\d{10}$");
                Match match = regex.Match(txtMobile.Text);
                if (!match.Success)
                {
                    MessageBox.Show((LangArEn == 0) ? "لم يتم ارسال رسالة نصية الى جوال العميل .. يرجى التأكد من صحة رقم الجوال" : "SMS Message was not sent to the Boss .. Please make sure the Mobile Number.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                if (!txtMobile.Text.StartsWith("05"))
                {
                    MessageBox.Show((LangArEn == 0) ? "لم يتم ارسال رسالة نصية الى جوال العميل .. يرجى التأكد من صحة رقم الجوال" : "SMS Message was not sent to the Boss .. Please make sure the Mobile Number.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                string M_Value = "966" + txtMobile.Text.Substring(1);
                string t = SendMessage(VarGeneral.Settings_Sys.smsUserName, VarGeneral.Settings_Sys.smsPass, ConvertToUnicode(msgTxt), VarGeneral.Settings_Sys.smsSenderName.Trim(), M_Value);
                ShowResult(t);
                if (t != "1")
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show((LangArEn == 0) ? "لم يتم ارسال رسالة نصية الى جوال العميل .. يرجى التأكد من صحة رقم الجوال" : "SMS Message was not sent to the Boss .. Please make sure the Mobile Number.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
        }
        public string SendMessage(string username, string password, string msg, string sender, string numbers)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://www.mobily.ws/api/msgSend.php");
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            string SenderList = "";
            string postData = "mobile=" + username + "&password=" + password + "&numbers=" + (string.IsNullOrEmpty(SenderList) ? numbers : (SenderList + "," + numbers)) + "&sender=" + sender + "&msg=" + msg + "&applicationType=61";
            req.ContentLength = postData.Length;
            StreamWriter stOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
            stOut.Write(postData);
            stOut.Close();
            StreamReader stIn = new StreamReader(req.GetResponse().GetResponseStream());
            string strResponse = stIn.ReadToEnd();
            stIn.Close();
            return strResponse;
        }
        private void ShowResult(string res)
        {
            switch (res)
            {
                case "1":
                    break;
                case "2":
                    MessageBox.Show("إن رصيدك لدى برو سوفت قد إنتهى ولم يعد به أي رسائل. (لحل المشكلة قم بشحن رصيدك من الرسائل لدى برو سوفت. لشحن رصيدك إتبع تعليمات شحن الرصيد)");
                    break;
                case "3":
                    MessageBox.Show("إن رصيدك الحالي لا يكفي لإتمام عملية الإرسال. (لحل المشكلة قم بشحن رصيدك من الرسائل لدى برو سوفت. لشحن رصيدك إتبع تعليمات شحن الرصيد");
                    break;
                case "4":
                    MessageBox.Show("إن إسم المستخدم الذي إستخدمته للدخول إلى حساب الرسائل غير صحيح (تأكد من أن إسم المستخدم الذي إستخدمته هو نفسه الذي تستخدمه عند دخولك إلى موقع برو سوفت).");
                    break;
                case "5":
                    MessageBox.Show("هناك خطأ في كلمة المرور (تأكد من أن كلمة المرور التي تم إستخدامها هي نفسها التي تستخدمها عند دخولك موقع برو سوفت,إذا نسيت كلمة المرور إضغط على رابط نسيت كلمة المرور لتصلك رسالة على جوالك برقم المرور الخاص بك)");
                    break;
                case "6":
                    MessageBox.Show("إن صفحة الإرسال لاتجيب في الوقت الحالي (قد يكون هناك طلب كبير على الصفحة أو توقف مؤقت للصفحة فقط حاول مرة أخرى أو تواصل مع الدعم الفني إذا إستمر الخطأ)");
                    break;
                case "12":
                    MessageBox.Show("إن حسابك بحاجة إلى تحديث يرجى مراجعة الدعم الفني");
                    break;
                case "13":
                    MessageBox.Show("إن إسم المرسل الذي إستخدمته في هذه الرسالة لم يتم قبوله. (يرجى إرسال الرسالة بإسم مرسل آخر أو تعريف إسم المرسل لدى برو سوفت)");
                    break;
                case "14":
                    MessageBox.Show("إن إسم المرسل الذي إستخدمته غير معرف لدى برو سوفت. (يمكنك تعريف إسم المرسل من خلال صفحة إضافة إسم مرسل)");
                    break;
                case "15":
                    MessageBox.Show("يوجد رقم جوال خاطئ في الأرقام التي قمت بالإرسال لها. (تأكد من صحة الأرقام التي تريد الإرسال لها وأنها بالصيغة الدولية)");
                    break;
                case "16":
                    MessageBox.Show("الرسالة التي قمت بإرسالها لا تحتوي على إسم مرسل. (أدخل إسم مرسل عند إرسالك الرسالة)");
                    break;
                case "17":
                    MessageBox.Show("لم يتم ارسال نص الرسالة. الرجاء التأكد من ارسال نص الرسالة والتأكد من تحويل الرسالة الى يوني كود (الرجاء التأكد من استخدام الدالة()");
                    break;
                case "18":
                    MessageBox.Show("الارسال متوقف حاليا");
                    break;
                case "19":
                    MessageBox.Show("applicationType غير موجودة في الرابط");
                    break;
                case "-1":
                    MessageBox.Show("لم يتم التواصل مع خادم (Server) الإرسال برو سوفت بنجاح. (قد يكون هناك محاولات إرسال كثيرة تمت معا , أو قد يكون هناك عطل مؤقت طرأ على الخادم إذا إستمرت المشكلة يرجى التواصل مع الدعم الفني)");
                    break;
                case "-2":
                    MessageBox.Show("لم يتم الربط مع قاعدة البيانات (Database) التي تحتوي على حسابك وبياناتك لدى برو سوفت. (قد يكون هناك محاولات إرسال كثيرة تمت معا , أو قد يكون هناك عطل مؤقت طرأ على الخادم إذا إستمرت المشكلة يرجى التواصل مع الدعم الفني)");
                    break;
                default:
                    MessageBox.Show(res.ToString());
                    break;
            }
        }
        private string ConvertToUnicode(string val)
        {
            string msg2 = string.Empty;
            for (int i = 0; i < val.Length; i++)
            {
                msg2 += convertToUnicode(Convert.ToChar(val.Substring(i, 1)));
            }
            return msg2;
        }
        private string convertToUnicode(char ch)
        {
            UnicodeEncoding class1 = new UnicodeEncoding();
            byte[] msg = class1.GetBytes(Convert.ToString(ch));
            return fourDigits(msg[1] + msg[0].ToString("X"));
        }
        private string fourDigits(string val)
        {
            string result = string.Empty;
            switch (val.Length)
            {
                case 1:
                    result = "000" + val;
                    break;
                case 2:
                    result = "00" + val;
                    break;
                case 3:
                    result = "0" + val;
                    break;
                case 4:
                    result = val;
                    break;
            }
            return result;
        }
        private void Button_Delete_Click(object sender, EventArgs e)
        {
            if (!Button_Delete.Enabled || !Button_Delete.Visible || State != 0)
            {
                ifOkDelete = false;
                return;
            }
            string Code = "";
            Code = textBox_ID.Text;
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
            if (data_this == null || string.IsNullOrEmpty(data_this.AccDef_No) || !ifOkDelete)
            {
                return;
            }
            T_GDDET returned = db.SelectAccDefNoByReturnNo(DataThis.AccDef_No);
            if ((returned != null && returned.GDDET_ID != 0) || textBox_ID.Text == "1")
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن حذف العميل .. لانه مرتبط باحد القيود" : "You can not delete Category .. because it is tied to a Gaid", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            data_this = db.StockAccDefWithOutBalance(DataThis.AccDef_No);
            try
            {
                db.T_AccDefs.DeleteOnSubmit(DataThis);
                db.SubmitChanges();
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
        }
        private void DGV_Main_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            string dataMember = panel.DataMember;
            if (dataMember != null && dataMember == "T_AccDef")
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
            panel.Columns["AccDef_No"].Width = 120;
            panel.Columns["AccDef_No"].Visible = columns_Names_visible["AccDef_No"].IfDefault;
            panel.Columns["Arb_Des"].Width = 180;
            panel.Columns["Arb_Des"].Visible = columns_Names_visible["Arb_Des"].IfDefault;
            panel.Columns["Eng_Des"].Width = 180;
            panel.Columns["Eng_Des"].Visible = columns_Names_visible["Eng_Des"].IfDefault;
            panel.Columns["Adders"].Width = 120;
            panel.Columns["Adders"].Visible = columns_Names_visible["Adders"].IfDefault;
            panel.Columns["Mobile"].Width = 120;
            panel.Columns["Mobile"].Visible = columns_Names_visible["Mobile"].IfDefault;
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
                ExportExcel.ExportToExcel(DGV_Main, "تقرير العملاء");
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
                controls.Add(txtAddress);
                controls.Add(txtAgeLimit);
                controls.Add(txtArbDes);
                controls.Add(txtRessonsStoped);
                controls.Add(txtPersonalName);
                controls.Add(txtZipCod);
                controls.Add(txtTaxNo);
                controls.Add(checkBoxX_Stoped);
                controls.Add(txtBalance);
                controls.Add(txtCity);
                controls.Add(txtCredit);
                controls.Add(txtCreditLimit);
                controls.Add(txtDeb);
                controls.Add(txtEMail);
                controls.Add(txtEngDes);
                controls.Add(txtFax);
                controls.Add(txtMainAccNo);
                controls.Add(txtMobile);
                controls.Add(txtTele1);
                controls.Add(txtTele2);
                controls.Add(txtAge);
                controls.Add(buttonX_SerchAccNo);
                controls.Add(CmbPrice);
                controls.Add(CmbLegate);
                controls.Add(CmbInvTyp);
                controls.Add(txtMaxDis);
                controls.Add(switchButton_DisTyp);
            }
            catch (SqlException)
            {
            }
        }
        private void textBox_ID_Leave(object sender, EventArgs e)
        {
            if (textBox_ID.Text != "" && State == FormState.New)
            {
                List<T_AccDef> q = (from t in db.T_AccDefs
                                    where t.AccDef_No == textBox_ID.Text
                                    orderby t.AccDef_No descending
                                    select t).ToList();
                if (q.Count != 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "الرقم الذي قمت بإدخاله موجود من قبل - مكرر .. يرجى المحاولة مرة اخرى" : "The number you have entered already exists - bis .. Please try again.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_ID.Text = "";
                    textBox_ID.Focus();
                }
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
        private void buttonX_SerchAccNo_Click(object sender, EventArgs e)
        {
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
            VarGeneral.SFrmTyp = "AccDefID_Customer";
            VarGeneral.AccTyp = 4;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtMainAccNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
            }
            else
            {
                txtMainAccNo.Text = "";
            }
        }
        private void txtMainAccNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox_ID.TextChanged -= textBox_ID_TextChanged;
                if (State == FormState.New && !string.IsNullOrEmpty(txtMainAccNo.Text))
                {
                    int Value = 0;
                    List<T_AccDef> q = (from t in db.T_AccDefs
                                        where t.ParAcc == txtMainAccNo.Text
                                        orderby t.AccDef_ID
                                        select t).ToList();
                    if (q.Count == 0)
                    {
                        textBox_ID.Text = txtMainAccNo.Text + "001";
                        txtArbDes.Focus();
                    }
                    else
                    {
                        _AccDefBind = q[q.Count - 1];
                        string _Zero = "";
                        for (int iiCnt = 0; iiCnt < _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Length && _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Substring(iiCnt, 1) == "0"; iiCnt++)
                        {
                            _Zero += _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Substring(iiCnt, 1);
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
                        txtArbDes.Focus();
                    }
                }
                textBox_ID.TextChanged += textBox_ID_TextChanged;
            }
            catch
            {
                txtMainAccNo.Text = "";
                textBox_ID.TextChanged += textBox_ID_TextChanged;
            }
        }
        private void checkBoxX_Stoped_CheckedChanged(object sender, EventArgs e)
        {
            if (!File.Exists(Application.StartupPath + "\\Script\\SecriptInvitationCards.dll"))
            {
                if (checkBoxX_Stoped.Checked)
                {
                    txtRessonsStoped.Enabled = true;
                    return;
                }
                txtRessonsStoped.Enabled = false;
                txtRessonsStoped.Text = "";
            }
        }
        private void buttonX_CustomerStoped_Click(object sender, EventArgs e)
        {
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_AccDef_CustomerStoped";
            VarGeneral.AccTyp = 4;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                textBox_ID.Text = frm.SerachNo.ToString();
            }
        }
        private void txtTele1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b')) && e.KeyChar != '-' && e.KeyChar != '\\')
            {
                e.Handled = true;
            }
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
                _RepShow.Tables = " T_AccDef left join T_SYSSETTING on T_SYSSETTING.SYSSETTING_ID = T_AccDef.CompanyID ";
                string Fields = "";
                Fields = " T_AccDef.AccDef_ID , T_AccDef.AccDef_No as No , T_AccDef.Arb_Des as NmA, T_AccDef.Eng_Des as NmE,T_SYSSETTING.LogImg ";
                _RepShow.Rule = " Where 1 = 1 and T_AccDef.AccCat = '4' and T_AccDef.Lev = 4 ";
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
                        VarGeneral.vTitle = Text;
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
        private void txtTele1_Click(object sender, EventArgs e)
        {
            txtTele1.SelectAll();
        }
        private void txtFax_Click(object sender, EventArgs e)
        {
            txtFax.SelectAll();
        }
        private void txtMobile_Click(object sender, EventArgs e)
        {
            txtMobile.SelectAll();
        }
        private void textBox_ID_Click(object sender, EventArgs e)
        {
            textBox_ID.SelectAll();
        }
        private void prnt_doc_BeginPrint(object sender, PrintEventArgs e)
        {
            CountPage = 0;
        }
        private void prnt_doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                e.PageSettings.Margins.Bottom = 0;
                e.PageSettings.Margins.Top = Convert.ToInt32(_InvSetting.InvpRINTERInfo.hAl);
                e.PageSettings.Margins.Left = Convert.ToInt32(_InvSetting.InvpRINTERInfo.hYs);
                e.PageSettings.Margins.Right = 0;
                e.PageSettings.PrinterSettings.Copies = short.Parse(_InvSetting.InvpRINTERInfo.DefLines.Value.ToString());
                List<T_mInvPrint> listmInvPrint = new List<T_mInvPrint>();
                T_mInvPrint _mInvPrint = new T_mInvPrint();
                listmInvPrint = (from item in db.T_mInvPrints
                                 where item.repTyp == (int?)22
                                 where item.repNum == (int?)4
                                 where item.IsPrint == (int?)1
                                 where item.BarcodeTyp == (int?)1
                                 select item).ToList();
                if (listmInvPrint.Count == 0)
                {
                    return;
                }
                double _isRows = 0.0;
                double _isCols = 0.0;
                float _Row = 0f;
                float _Col = 0f;
                double _PageLine = _InvSetting.InvpRINTERInfo.lnPg.Value;
                double _LineSp = _InvSetting.InvpRINTERInfo.lnSpc.Value;
                StringFormat strformat = new StringFormat((StringFormatFlags)0, 1);
                for (int iiRnt = 0; (double)iiRnt < _PageLine; iiRnt++)
                {
                    _isCols = 0.0;
                    for (int iiCol = 0; (double)iiCol < _LineSp; iiCol++)
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
                            Font _font = new Font(_mInvPrint.vFont, float.Parse(_mInvPrint.vSize.Value.ToString()), e.Graphics.PageUnit);
                            if (_mInvPrint.vBold.Value == 1)
                            {
                                _font = new Font(_mInvPrint.vFont, float.Parse(_mInvPrint.vSize.Value.ToString()), FontStyle.Bold, e.Graphics.PageUnit);
                            }
                            _Row = (float)_mInvPrint.vRow.Value + (float)_isRows;
                            _Col = (float)_mInvPrint.vCol.Value + (float)_isCols;
                            if (_mInvPrint.pField == "CustNo")
                            {
                                e.Graphics.DrawImage(c1BarCode1.Image, _Col, _Row, float.Parse(_mInvPrint.MaxW.Value.ToString()), float.Parse(_mInvPrint.vSize.Value.ToString()));
                            }
                            else if (_mInvPrint.pField == "CustNm")
                            {
                                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                                {
                                    e.Graphics.DrawString(txtArbDes.Text, _font, Brushes.Black, _Col, _Row, strformat);
                                }
                                else
                                {
                                    e.Graphics.DrawString(txtEngDes.Text, _font, Brushes.Black, _Col, _Row, strformat);
                                }
                            }
                            else if (_mInvPrint.pField == "CompanyNm")
                            {
                                e.Graphics.DrawString(_Company.CopNam, _font, Brushes.Black, _Col, _Row, strformat);
                            }
                        }
                        _isCols = _isCols + (double)_InvSetting.InvNum1.Value + _InvSetting.InvpRINTERInfo.hYm.Value;
                    }
                    _isRows = _isRows + (double)_InvSetting.InvNum.Value + _InvSetting.InvpRINTERInfo.hAs.Value;
                }
                CountPage++;
                if (CountPage == e.PageSettings.PrinterSettings.Copies)
                {
                    e.HasMorePages = false;
                }
                else
                {
                    e.HasMorePages = true;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
                MessageBox.Show("عفوا\u064b ... لا توجد حقول للطباعة راجع إعدادات الطباعة  \n Sorry , Not Found Fields for Printing", Application.ProductName);
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
        }
        private void PrintForm_Click(object sender, EventArgs e)
        {
            PrintDialog PrintDialog1 = new PrintDialog();
            printDialog1.Document = prnt_doc;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                prnt_doc.Print();
            }
        }
        private void button_Barcode_Click(object sender, EventArgs e)
        {
            if (!(textBox_ID.Text != ""))
            {
                return;
            }
            c1BarCode1.Text = textBox_ID.Text;
            PrintSet();
            prnt_prev = new PrintPreviewDialog();
            ToolStrip toollstr = (ToolStrip)prnt_prev.Controls["toolStrip1"];
            toollstr.Items.RemoveAt(0);
            toollstr.Items.Add("Print", null, PrintForm_Click);
            prnt_prev.Controls.Add(toollstr);
            prnt_prev.Document = prnt_doc;
            prnt_prev.ShowIcon = false;
            prnt_prev.AllowTransparency = true;
            prnt_prev.MdiParent = base.MdiParent;
            PrintDialog PrintDialog1 = new PrintDialog();
            printDialog1.Document = prnt_doc;
            T_INVSETTING _InvSetting = new T_INVSETTING();
            _InvSetting = db.StockInvSetting(VarGeneral.UserID, 22);
            try
            {
                if (_InvSetting.InvpRINTERInfo.DefLines.Value > 0)
                {
                    if (_InvSetting.InvTypA4 == "1")
                    {
                        prnt_doc.PrinterSettings.Collate = true;
                    }
                    else
                    {
                        prnt_doc.PrinterSettings.Collate = false;
                    }
                }
                else
                {
                    prnt_doc.PrinterSettings.Collate = false;
                }
            }
            catch
            {
                prnt_doc.PrinterSettings.Collate = false;
            }
            try
            {
                if (_InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1) == "0")
                {
                    prnt_doc.Print();
                    return;
                }
                prnt_prev.TopMost = true;
                prnt_prev.ShowDialog();
            }
            catch
            {
            }
        }
        private void button_SrchPlaceNo_Click(object sender, EventArgs e)
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
            VarGeneral.AccTyp = 5;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtRessonsStoped.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtPlaceName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    txtPlaceName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
            }
            else
            {
                txtRessonsStoped.Text = "";
                txtPlaceName.Text = "";
            }
        }
        private void txtRessonsStoped_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(Application.StartupPath + "\\Script\\SecriptInvitationCards.dll"))
                {
                    return;
                }
                if (txtRessonsStoped.Text != "")
                {
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtPlaceName.Text = db.StockAccDefWithOutBalance(txtRessonsStoped.Text).Arb_Des;
                    }
                    else
                    {
                        txtPlaceName.Text = db.StockAccDefWithOutBalance(txtRessonsStoped.Text).Eng_Des;
                    }
                }
                else
                {
                    txtPlaceName.Text = "";
                }
            }
            catch
            {
            }
        }
        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void Button_Add_Click_1(object sender, EventArgs e)
        {
        }
        private void FrmCustomer_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;
        }
        private void superTabControl_Main2_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        {
        }

        private void label23_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
