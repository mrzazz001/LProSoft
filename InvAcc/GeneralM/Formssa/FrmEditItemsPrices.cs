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
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmEditItemsPrices : Form
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
        private DockSite dockSite5;
        protected ContextMenuStrip contextMenuStrip3;
        protected ToolStripMenuItem toolStripMenuItem1;
        private DockSite dockSite6;
        protected ToolStripMenuItem toolStripMenuItem2;
        private DockSite dockSite7;
        private SaveFileDialog saveFileDialog2;
        private DockSite dockSite8;
        private DockSite dockSite9;
        private DockSite dockSite10;
        private DockSite dockSite11;
        private DockSite dockSite12;
        protected ContextMenuStrip contextMenuStrip4;
        public DotNetBarManager dotNetBarManager2;
        private ImageList imageList2;
        private RibbonBar ribbonBar1;
        private RibbonBar ribbonBar_Tasks;
        private SuperTabControl superTabControl_Main1;
        protected ButtonItem Button_Close;
        protected ButtonItem Button_Save;
        protected LabelItem labelItem2;
        private GroupBox groupBox1;
        private Label label12;
        private DoubleInput doubleInput_SelPriceNew1;
        private DoubleInput doubleInput_SelPriceNow1;
        private Label label1;
        private GroupBox groupBox2;
        private GroupBox groupBoxUnit;
        private ReflectionImage pictureBox_PicItem;
        private DoubleInput doubleInput_SelPriceNew5;
        private DoubleInput doubleInput_SelPriceNow5;
        private Label label6;
        private DoubleInput doubleInput_SelPriceNew4;
        private DoubleInput doubleInput_SelPriceNow4;
        private Label label5;
        private DoubleInput doubleInput_SelPriceNew3;
        private DoubleInput doubleInput_SelPriceNow3;
        private Label label3;
        private DoubleInput doubleInput_SelPriceNew2;
        private DoubleInput doubleInput_SelPriceNow2;
        private Label label2;
        private ComboBoxEx comboBoxUnit;
        private DoubleInput textbox_LegatesNew;
        private DoubleInput textbox_DistributorsNew;
        private DoubleInput textbox_VIPNew;
        private DoubleInput textbox_SectorialNew;
        private DoubleInput textbox_Sentence;
        private Label label28;
        private DoubleInput textbox_Legates;
        private DoubleInput textbox_Distributors;
        private Label label24;
        private Label label27;
        private DoubleInput textbox_VIP;
        private Label label26;
        private DoubleInput textbox_Sectorial;
        private Label label25;
        private TextBox textBox_ID;
        private DataGridViewX dataGridViewX_Data;
        private DataGridViewTextBoxColumn Co1;
        private DataGridViewTextBoxColumn Col2;
        private DataGridViewTextBoxColumn Col3;
        private DataGridViewTextBoxColumn Col4;
        private DataGridViewTextBoxColumn Col5;
        private DataGridViewTextBoxColumn Col6;
        private DataGridViewTextBoxColumn Col7;
        private DataGridViewTextBoxColumn Col8;
        private DataGridViewTextBoxColumn Col9;
        private DataGridViewTextBoxColumn Col10;
        private DataGridViewTextBoxColumn Col11;
        private DataGridViewTextBoxColumn Col12;
        private DataGridViewTextBoxColumn Col13;
        private DataGridViewTextBoxColumn Col14;
        private DataGridViewTextBoxColumn Col15;
        private DataGridViewTextBoxColumn Col16;
        private DataGridViewTextBoxColumn Col17;
        private DataGridViewTextBoxColumn Col18;
        private DataGridViewTextBoxColumn Col19;
        private DataGridViewTextBoxColumn Col20;
        private DataGridViewTextBoxColumn Col21;
        private DataGridViewTextBoxColumn Col22;
        private DataGridViewTextBoxColumn Col23;
        private DataGridViewTextBoxColumn Col24;
        private DataGridViewTextBoxColumn Col25;
        private DataGridViewTextBoxColumn Col26;
        private DataGridViewTextBoxColumn Col27;
        private DataGridViewTextBoxColumn Col28;
        public DoubleInput doubleInput_SelCostNew;
        public Label label4;
        public DoubleInput doubleInput_SelCostNow;
        private Label label7;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private int LangArEn = 0;
        public List<Control> controls;
        public Control codeControl = new Control();
        private string vItmNo = string.Empty;
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstance;
        private T_Item data_this;
        private DoubleInput textbox_SentenceNew;
        private T_EditItemPrice data_this_EditPrice;
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
        public T_Item DataThis
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
        public T_EditItemPrice DataThis_EditPrice
        {
            get
            {
                return data_this_EditPrice;
            }
            set
            {
                data_this_EditPrice = value;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditItemsPrices));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dockSite5 = new DevComponents.DotNetBar.DockSite();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dockSite6 = new DevComponents.DotNetBar.DockSite();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.dockSite7 = new DevComponents.DotNetBar.DockSite();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.dockSite8 = new DevComponents.DotNetBar.DockSite();
            this.dockSite9 = new DevComponents.DotNetBar.DockSite();
            this.dockSite10 = new DevComponents.DotNetBar.DockSite();
            this.dockSite11 = new DevComponents.DotNetBar.DockSite();
            this.dockSite12 = new DevComponents.DotNetBar.DockSite();
            this.contextMenuStrip4 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dotNetBarManager2 = new DevComponents.DotNetBar.DotNetBarManager(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.doubleInput_SelCostNew = new DevComponents.Editors.DoubleInput();
            this.dataGridViewX_Data = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Co1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox_PicItem = new DevComponents.DotNetBar.Controls.ReflectionImage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textbox_LegatesNew = new DevComponents.Editors.DoubleInput();
            this.textbox_DistributorsNew = new DevComponents.Editors.DoubleInput();
            this.textbox_VIPNew = new DevComponents.Editors.DoubleInput();
            this.textbox_SectorialNew = new DevComponents.Editors.DoubleInput();
            this.textbox_Sentence = new DevComponents.Editors.DoubleInput();
            this.label28 = new System.Windows.Forms.Label();
            this.textbox_Legates = new DevComponents.Editors.DoubleInput();
            this.textbox_Distributors = new DevComponents.Editors.DoubleInput();
            this.label24 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.textbox_VIP = new DevComponents.Editors.DoubleInput();
            this.label26 = new System.Windows.Forms.Label();
            this.textbox_Sectorial = new DevComponents.Editors.DoubleInput();
            this.label25 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBoxUnit = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.doubleInput_SelPriceNew4 = new DevComponents.Editors.DoubleInput();
            this.doubleInput_SelPriceNew3 = new DevComponents.Editors.DoubleInput();
            this.doubleInput_SelPriceNew5 = new DevComponents.Editors.DoubleInput();
            this.doubleInput_SelPriceNew2 = new DevComponents.Editors.DoubleInput();
            this.doubleInput_SelPriceNew1 = new DevComponents.Editors.DoubleInput();
            this.doubleInput_SelPriceNow1 = new DevComponents.Editors.DoubleInput();
            this.doubleInput_SelPriceNow2 = new DevComponents.Editors.DoubleInput();
            this.doubleInput_SelPriceNow3 = new DevComponents.Editors.DoubleInput();
            this.doubleInput_SelPriceNow4 = new DevComponents.Editors.DoubleInput();
            this.doubleInput_SelPriceNow5 = new DevComponents.Editors.DoubleInput();
            this.comboBoxUnit = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.doubleInput_SelCostNow = new DevComponents.Editors.DoubleInput();
            this.ribbonBar_Tasks = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl_Main1 = new DevComponents.DotNetBar.SuperTabControl();
            this.Button_Close = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Save = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            this.textbox_SentenceNew = new DevComponents.Editors.DoubleInput();
            this.contextMenuStrip4.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_SelCostNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX_Data)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_LegatesNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_DistributorsNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_VIPNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_SectorialNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_Sentence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_Legates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_Distributors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_VIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_Sectorial)).BeginInit();
            this.groupBoxUnit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_SelPriceNew4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_SelPriceNew3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_SelPriceNew5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_SelPriceNew2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_SelPriceNew1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_SelPriceNow1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_SelPriceNow2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_SelPriceNow3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_SelPriceNow4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_SelPriceNow5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_SelCostNow)).BeginInit();
            this.ribbonBar_Tasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_SentenceNew)).BeginInit();
            this.SuspendLayout();
            // 
            // dockSite5
            // 
            this.dockSite5.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite5.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite5.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite5.Location = new System.Drawing.Point(0, 0);
            this.dockSite5.Name = "dockSite5";
            this.dockSite5.Size = new System.Drawing.Size(737, 0);
            this.dockSite5.TabIndex = 908;
            this.dockSite5.TabStop = false;
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.Name = "contextMenuStrip1";
            this.contextMenuStrip3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip3.Size = new System.Drawing.Size(61, 4);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem1.Text = "إظهار التفاصيل";
            // 
            // dockSite6
            // 
            this.dockSite6.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite6.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite6.Location = new System.Drawing.Point(0, 431);
            this.dockSite6.Name = "dockSite6";
            this.dockSite6.Size = new System.Drawing.Size(737, 0);
            this.dockSite6.TabIndex = 909;
            this.dockSite6.TabStop = false;
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Checked = true;
            this.toolStripMenuItem2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem2.Text = "إظهار التقرير";
            // 
            // dockSite7
            // 
            this.dockSite7.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite7.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite7.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite7.Location = new System.Drawing.Point(0, 0);
            this.dockSite7.Name = "dockSite7";
            this.dockSite7.Size = new System.Drawing.Size(0, 431);
            this.dockSite7.TabIndex = 910;
            this.dockSite7.TabStop = false;
            // 
            // saveFileDialog2
            // 
            this.saveFileDialog2.DefaultExt = "*.rtf";
            this.saveFileDialog2.FileName = "doc1";
            this.saveFileDialog2.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf|All Files(*.*)|*.*";
            this.saveFileDialog2.FilterIndex = 2;
            this.saveFileDialog2.Title = "Save File";
            // 
            // dockSite8
            // 
            this.dockSite8.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite8.Location = new System.Drawing.Point(0, 431);
            this.dockSite8.Name = "dockSite8";
            this.dockSite8.Size = new System.Drawing.Size(737, 0);
            this.dockSite8.TabIndex = 915;
            this.dockSite8.TabStop = false;
            // 
            // dockSite9
            // 
            this.dockSite9.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite9.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite9.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.dockSite9.Location = new System.Drawing.Point(737, 0);
            this.dockSite9.Name = "dockSite9";
            this.dockSite9.Size = new System.Drawing.Size(0, 431);
            this.dockSite9.TabIndex = 911;
            this.dockSite9.TabStop = false;
            // 
            // dockSite10
            // 
            this.dockSite10.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite10.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite10.Location = new System.Drawing.Point(0, 0);
            this.dockSite10.Name = "dockSite10";
            this.dockSite10.Size = new System.Drawing.Size(0, 431);
            this.dockSite10.TabIndex = 912;
            this.dockSite10.TabStop = false;
            // 
            // dockSite11
            // 
            this.dockSite11.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite11.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite11.Location = new System.Drawing.Point(737, 0);
            this.dockSite11.Name = "dockSite11";
            this.dockSite11.Size = new System.Drawing.Size(0, 431);
            this.dockSite11.TabIndex = 913;
            this.dockSite11.TabStop = false;
            // 
            // dockSite12
            // 
            this.dockSite12.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite12.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite12.Location = new System.Drawing.Point(0, 0);
            this.dockSite12.Name = "dockSite12";
            this.dockSite12.Size = new System.Drawing.Size(737, 0);
            this.dockSite12.TabIndex = 914;
            this.dockSite12.TabStop = false;
            // 
            // contextMenuStrip4
            // 
            this.contextMenuStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStrip4.Name = "contextMenuStrip2";
            this.contextMenuStrip4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip4.Size = new System.Drawing.Size(149, 48);
            // 
            // dotNetBarManager2
            // 
            this.dotNetBarManager2.BottomDockSite = this.dockSite6;
            this.dotNetBarManager2.Images = this.imageList2;
            this.dotNetBarManager2.LeftDockSite = this.dockSite7;
            this.dotNetBarManager2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.dotNetBarManager2.MdiSystemItemVisible = false;
            this.dotNetBarManager2.ParentForm = null;
            this.dotNetBarManager2.RightDockSite = this.dockSite9;
            this.dotNetBarManager2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2000;
            this.dotNetBarManager2.ToolbarBottomDockSite = this.dockSite8;
            this.dotNetBarManager2.ToolbarLeftDockSite = this.dockSite10;
            this.dotNetBarManager2.ToolbarRightDockSite = this.dockSite11;
            this.dotNetBarManager2.ToolbarTopDockSite = this.dockSite12;
            this.dotNetBarManager2.TopDockSite = this.dockSite5;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList2.Images.SetKeyName(0, string.Empty);
            this.imageList2.Images.SetKeyName(1, string.Empty);
            this.imageList2.Images.SetKeyName(2, string.Empty);
            this.imageList2.Images.SetKeyName(3, string.Empty);
            this.imageList2.Images.SetKeyName(4, string.Empty);
            this.imageList2.Images.SetKeyName(5, string.Empty);
            this.imageList2.Images.SetKeyName(6, string.Empty);
            this.imageList2.Images.SetKeyName(7, string.Empty);
            this.imageList2.Images.SetKeyName(8, string.Empty);
            this.imageList2.Images.SetKeyName(9, string.Empty);
            this.imageList2.Images.SetKeyName(10, string.Empty);
            this.imageList2.Images.SetKeyName(11, string.Empty);
            this.imageList2.Images.SetKeyName(12, string.Empty);
            this.imageList2.Images.SetKeyName(13, string.Empty);
            this.imageList2.Images.SetKeyName(14, string.Empty);
            this.imageList2.Images.SetKeyName(15, string.Empty);
            this.imageList2.Images.SetKeyName(16, string.Empty);
            this.imageList2.Images.SetKeyName(17, string.Empty);
            this.imageList2.Images.SetKeyName(18, string.Empty);
            this.imageList2.Images.SetKeyName(19, string.Empty);
            this.imageList2.Images.SetKeyName(20, string.Empty);
            this.imageList2.Images.SetKeyName(21, string.Empty);
            this.imageList2.Images.SetKeyName(22, string.Empty);
            this.imageList2.Images.SetKeyName(23, string.Empty);
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
            this.ribbonBar1.Controls.Add(this.groupBox1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(737, 380);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 916;
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
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.doubleInput_SelCostNew);
            this.groupBox1.Controls.Add(this.dataGridViewX_Data);
            this.groupBox1.Controls.Add(this.textBox_ID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.pictureBox_PicItem);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.groupBoxUnit);
            this.groupBox1.Controls.Add(this.doubleInput_SelCostNow);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(737, 363);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // doubleInput_SelCostNew
            // 
            this.doubleInput_SelCostNew.AllowEmptyState = false;
            // 
            // 
            // 
            this.doubleInput_SelCostNew.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.doubleInput_SelCostNew.BackgroundStyle.Class = "DateTimeInputBackground";
            this.doubleInput_SelCostNew.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doubleInput_SelCostNew.ButtonCalculator.Visible = true;
            this.doubleInput_SelCostNew.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.doubleInput_SelCostNew.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.doubleInput_SelCostNew.Increment = 1D;
            this.doubleInput_SelCostNew.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.doubleInput_SelCostNew.Location = new System.Drawing.Point(147, 25);
            this.doubleInput_SelCostNew.MinValue = 0D;
            this.doubleInput_SelCostNew.Name = "doubleInput_SelCostNew";
            this.doubleInput_SelCostNew.Size = new System.Drawing.Size(145, 20);
            this.doubleInput_SelCostNew.TabIndex = 2;
            this.doubleInput_SelCostNew.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // dataGridViewX_Data
            // 
            this.dataGridViewX_Data.AllowUserToAddRows = false;
            this.dataGridViewX_Data.AllowUserToDeleteRows = false;
            this.dataGridViewX_Data.AllowUserToOrderColumns = true;
            this.dataGridViewX_Data.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewX_Data.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewX_Data.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX_Data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX_Data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Co1,
            this.Col2,
            this.Col3,
            this.Col4,
            this.Col5,
            this.Col6,
            this.Col7,
            this.Col8,
            this.Col9,
            this.Col10,
            this.Col11,
            this.Col12,
            this.Col13,
            this.Col14,
            this.Col15,
            this.Col16,
            this.Col17,
            this.Col18,
            this.Col19,
            this.Col20,
            this.Col21,
            this.Col22,
            this.Col23,
            this.Col24,
            this.Col25,
            this.Col26,
            this.Col27,
            this.Col28});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX_Data.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewX_Data.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX_Data.Location = new System.Drawing.Point(13, 239);
            this.dataGridViewX_Data.Name = "dataGridViewX_Data";
            this.dataGridViewX_Data.ReadOnly = true;
            this.dataGridViewX_Data.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX_Data.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewX_Data.RowHeadersVisible = false;
            this.dataGridViewX_Data.RowHeadersWidth = 45;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewX_Data.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewX_Data.Size = new System.Drawing.Size(714, 118);
            this.dataGridViewX_Data.TabIndex = 15;
            // 
            // Co1
            // 
            this.Co1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Co1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Co1.HeaderText = "رقم الصنف";
            this.Co1.Name = "Co1";
            this.Co1.ReadOnly = true;
            this.Co1.Width = 70;
            // 
            // Col2
            // 
            this.Col2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Col2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Col2.HeaderText = "اسم الصنف";
            this.Col2.Name = "Col2";
            this.Col2.ReadOnly = true;
            this.Col2.Width = 170;
            // 
            // Col3
            // 
            this.Col3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.NullValue = "0";
            this.Col3.DefaultCellStyle = dataGridViewCellStyle4;
            this.Col3.HeaderText = "سعر التكلفة قبل";
            this.Col3.Name = "Col3";
            this.Col3.ReadOnly = true;
            this.Col3.Width = 90;
            // 
            // Col4
            // 
            this.Col4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.NullValue = "0";
            this.Col4.DefaultCellStyle = dataGridViewCellStyle5;
            this.Col4.HeaderText = "سعر التكلفة بعد";
            this.Col4.Name = "Col4";
            this.Col4.ReadOnly = true;
            this.Col4.Width = 90;
            // 
            // Col5
            // 
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Col5.DefaultCellStyle = dataGridViewCellStyle6;
            this.Col5.HeaderText = "التاريخ هـ";
            this.Col5.Name = "Col5";
            this.Col5.ReadOnly = true;
            this.Col5.Width = 65;
            // 
            // Col6
            // 
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Col6.DefaultCellStyle = dataGridViewCellStyle7;
            this.Col6.HeaderText = "التاريخ م";
            this.Col6.Name = "Col6";
            this.Col6.ReadOnly = true;
            this.Col6.Width = 65;
            // 
            // Col7
            // 
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Col7.DefaultCellStyle = dataGridViewCellStyle8;
            this.Col7.HeaderText = "الوقت";
            this.Col7.Name = "Col7";
            this.Col7.ReadOnly = true;
            this.Col7.Width = 60;
            // 
            // Col8
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Col8.DefaultCellStyle = dataGridViewCellStyle9;
            this.Col8.HeaderText = "المستخدم";
            this.Col8.Name = "Col8";
            this.Col8.ReadOnly = true;
            // 
            // Col9
            // 
            this.Col9.HeaderText = "سعر البيع 1 قبل";
            this.Col9.Name = "Col9";
            this.Col9.ReadOnly = true;
            // 
            // Col10
            // 
            this.Col10.HeaderText = "سعر البيع 1 بعد";
            this.Col10.Name = "Col10";
            this.Col10.ReadOnly = true;
            // 
            // Col11
            // 
            this.Col11.HeaderText = "سعر البيع 2 قبل";
            this.Col11.Name = "Col11";
            this.Col11.ReadOnly = true;
            // 
            // Col12
            // 
            this.Col12.HeaderText = "سعر البيع 2 بعد";
            this.Col12.Name = "Col12";
            this.Col12.ReadOnly = true;
            // 
            // Col13
            // 
            this.Col13.HeaderText = "سعر البيع 3 قبل";
            this.Col13.Name = "Col13";
            this.Col13.ReadOnly = true;
            // 
            // Col14
            // 
            this.Col14.HeaderText = "سعر البيع 3 بعد";
            this.Col14.Name = "Col14";
            this.Col14.ReadOnly = true;
            // 
            // Col15
            // 
            this.Col15.HeaderText = "سعر البيع 4 قبل";
            this.Col15.Name = "Col15";
            this.Col15.ReadOnly = true;
            // 
            // Col16
            // 
            this.Col16.HeaderText = "سعر البيع 4 بعد";
            this.Col16.Name = "Col16";
            this.Col16.ReadOnly = true;
            // 
            // Col17
            // 
            this.Col17.HeaderText = "سعر البيع 5 قبل";
            this.Col17.Name = "Col17";
            this.Col17.ReadOnly = true;
            // 
            // Col18
            // 
            this.Col18.HeaderText = "سعر البيع 5 بعد";
            this.Col18.Name = "Col18";
            this.Col18.ReadOnly = true;
            // 
            // Col19
            // 
            this.Col19.HeaderText = "سعر المندوب قبل";
            this.Col19.Name = "Col19";
            this.Col19.ReadOnly = true;
            // 
            // Col20
            // 
            this.Col20.HeaderText = "سعر المندوب بعد";
            this.Col20.Name = "Col20";
            this.Col20.ReadOnly = true;
            // 
            // Col21
            // 
            this.Col21.HeaderText = "سعر الموزع قبل";
            this.Col21.Name = "Col21";
            this.Col21.ReadOnly = true;
            // 
            // Col22
            // 
            this.Col22.HeaderText = "سعر الموزع بعد";
            this.Col22.Name = "Col22";
            this.Col22.ReadOnly = true;
            // 
            // Col23
            // 
            this.Col23.HeaderText = "سعر الجملة قبل";
            this.Col23.Name = "Col23";
            this.Col23.ReadOnly = true;
            // 
            // Col24
            // 
            this.Col24.HeaderText = "سعر الموزع بعد";
            this.Col24.Name = "Col24";
            this.Col24.ReadOnly = true;
            // 
            // Col25
            // 
            this.Col25.HeaderText = "سعر التجزئة قبل";
            this.Col25.Name = "Col25";
            this.Col25.ReadOnly = true;
            // 
            // Col26
            // 
            this.Col26.HeaderText = "سعر التجزئة بعد";
            this.Col26.Name = "Col26";
            this.Col26.ReadOnly = true;
            // 
            // Col27
            // 
            this.Col27.HeaderText = "سعر اخر قبل";
            this.Col27.Name = "Col27";
            this.Col27.ReadOnly = true;
            // 
            // Col28
            // 
            this.Col28.HeaderText = "سعر اخر بعد";
            this.Col28.Name = "Col28";
            this.Col28.ReadOnly = true;
            // 
            // textBox_ID
            // 
            this.textBox_ID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.textBox_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_ID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_ID.Location = new System.Drawing.Point(535, 22);
            this.textBox_ID.MaxLength = 6;
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.ReadOnly = true;
            this.textBox_ID.Size = new System.Drawing.Size(110, 21);
            this.textBox_ID.TabIndex = 1;
            this.textBox_ID.TextChanged += new System.EventHandler(this.textBox_ID_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(298, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 16);
            this.label4.TabIndex = 953;
            this.label4.Text = "سعر التكلفة  :";
            // 
            // pictureBox_PicItem
            // 
            // 
            // 
            // 
            this.pictureBox_PicItem.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.pictureBox_PicItem.BackgroundStyle.BorderBottomColor = System.Drawing.Color.SteelBlue;
            this.pictureBox_PicItem.BackgroundStyle.BorderBottomWidth = 1;
            this.pictureBox_PicItem.BackgroundStyle.BorderColor = System.Drawing.Color.SteelBlue;
            this.pictureBox_PicItem.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.pictureBox_PicItem.BackgroundStyle.BorderLeftColor = System.Drawing.Color.SteelBlue;
            this.pictureBox_PicItem.BackgroundStyle.BorderLeftWidth = 1;
            this.pictureBox_PicItem.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.pictureBox_PicItem.BackgroundStyle.BorderRightWidth = 1;
            this.pictureBox_PicItem.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.pictureBox_PicItem.BackgroundStyle.BorderTopColor = System.Drawing.Color.SteelBlue;
            this.pictureBox_PicItem.BackgroundStyle.BorderTopWidth = 1;
            this.pictureBox_PicItem.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pictureBox_PicItem.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.pictureBox_PicItem.Location = new System.Drawing.Point(12, 10);
            this.pictureBox_PicItem.Name = "pictureBox_PicItem";
            this.pictureBox_PicItem.Size = new System.Drawing.Size(128, 141);
            this.pictureBox_PicItem.TabIndex = 944;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textbox_SentenceNew);
            this.groupBox2.Controls.Add(this.textbox_LegatesNew);
            this.groupBox2.Controls.Add(this.textbox_DistributorsNew);
            this.groupBox2.Controls.Add(this.textbox_VIPNew);
            this.groupBox2.Controls.Add(this.textbox_SectorialNew);
            this.groupBox2.Controls.Add(this.textbox_Sentence);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.textbox_Legates);
            this.groupBox2.Controls.Add(this.textbox_Distributors);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.textbox_VIP);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.textbox_Sectorial);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Location = new System.Drawing.Point(12, 148);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(719, 85);
            this.groupBox2.TabIndex = 941;
            this.groupBox2.TabStop = false;
            // 
            // textbox_LegatesNew
            // 
            this.textbox_LegatesNew.AllowEmptyState = false;
            // 
            // 
            // 
            this.textbox_LegatesNew.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textbox_LegatesNew.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textbox_LegatesNew.ButtonCalculator.Visible = true;
            this.textbox_LegatesNew.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textbox_LegatesNew.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textbox_LegatesNew.Increment = 1D;
            this.textbox_LegatesNew.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textbox_LegatesNew.Location = new System.Drawing.Point(596, 42);
            this.textbox_LegatesNew.MinValue = 0D;
            this.textbox_LegatesNew.Name = "textbox_LegatesNew";
            this.textbox_LegatesNew.Size = new System.Drawing.Size(85, 20);
            this.textbox_LegatesNew.TabIndex = 4;
            this.textbox_LegatesNew.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // textbox_DistributorsNew
            // 
            this.textbox_DistributorsNew.AllowEmptyState = false;
            // 
            // 
            // 
            this.textbox_DistributorsNew.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textbox_DistributorsNew.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textbox_DistributorsNew.ButtonCalculator.Visible = true;
            this.textbox_DistributorsNew.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textbox_DistributorsNew.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textbox_DistributorsNew.Increment = 1D;
            this.textbox_DistributorsNew.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textbox_DistributorsNew.Location = new System.Drawing.Point(453, 42);
            this.textbox_DistributorsNew.MinValue = 0D;
            this.textbox_DistributorsNew.Name = "textbox_DistributorsNew";
            this.textbox_DistributorsNew.Size = new System.Drawing.Size(85, 20);
            this.textbox_DistributorsNew.TabIndex = 5;
            this.textbox_DistributorsNew.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // textbox_VIPNew
            // 
            this.textbox_VIPNew.AllowEmptyState = false;
            // 
            // 
            // 
            this.textbox_VIPNew.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textbox_VIPNew.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textbox_VIPNew.ButtonCalculator.Visible = true;
            this.textbox_VIPNew.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textbox_VIPNew.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textbox_VIPNew.Increment = 1D;
            this.textbox_VIPNew.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textbox_VIPNew.Location = new System.Drawing.Point(38, 42);
            this.textbox_VIPNew.MinValue = 0D;
            this.textbox_VIPNew.Name = "textbox_VIPNew";
            this.textbox_VIPNew.Size = new System.Drawing.Size(85, 20);
            this.textbox_VIPNew.TabIndex = 8;
            this.textbox_VIPNew.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // textbox_SectorialNew
            // 
            this.textbox_SectorialNew.AllowEmptyState = false;
            // 
            // 
            // 
            this.textbox_SectorialNew.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textbox_SectorialNew.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textbox_SectorialNew.ButtonCalculator.Visible = true;
            this.textbox_SectorialNew.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textbox_SectorialNew.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textbox_SectorialNew.Increment = 1D;
            this.textbox_SectorialNew.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textbox_SectorialNew.Location = new System.Drawing.Point(184, 42);
            this.textbox_SectorialNew.MinValue = 0D;
            this.textbox_SectorialNew.Name = "textbox_SectorialNew";
            this.textbox_SectorialNew.Size = new System.Drawing.Size(85, 20);
            this.textbox_SectorialNew.TabIndex = 7;
            this.textbox_SectorialNew.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // textbox_Sentence
            // 
            this.textbox_Sentence.AllowEmptyState = false;
            // 
            // 
            // 
            this.textbox_Sentence.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.textbox_Sentence.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textbox_Sentence.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textbox_Sentence.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textbox_Sentence.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textbox_Sentence.Increment = 1D;
            this.textbox_Sentence.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textbox_Sentence.IsInputReadOnly = true;
            this.textbox_Sentence.Location = new System.Drawing.Point(326, 42);
            this.textbox_Sentence.MinValue = 0D;
            this.textbox_Sentence.Name = "textbox_Sentence";
            this.textbox_Sentence.Size = new System.Drawing.Size(85, 20);
            this.textbox_Sentence.TabIndex = 943;
            this.textbox_Sentence.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic);
            this.label28.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label28.Location = new System.Drawing.Point(332, 19);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(72, 16);
            this.label28.TabIndex = 942;
            this.label28.Text = "سعر الجملة";
            // 
            // textbox_Legates
            // 
            this.textbox_Legates.AllowEmptyState = false;
            // 
            // 
            // 
            this.textbox_Legates.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.textbox_Legates.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textbox_Legates.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textbox_Legates.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textbox_Legates.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textbox_Legates.Increment = 1D;
            this.textbox_Legates.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textbox_Legates.IsInputReadOnly = true;
            this.textbox_Legates.Location = new System.Drawing.Point(596, 42);
            this.textbox_Legates.MinValue = 0D;
            this.textbox_Legates.Name = "textbox_Legates";
            this.textbox_Legates.Size = new System.Drawing.Size(85, 20);
            this.textbox_Legates.TabIndex = 941;
            this.textbox_Legates.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // textbox_Distributors
            // 
            this.textbox_Distributors.AllowEmptyState = false;
            // 
            // 
            // 
            this.textbox_Distributors.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.textbox_Distributors.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textbox_Distributors.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textbox_Distributors.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textbox_Distributors.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textbox_Distributors.Increment = 1D;
            this.textbox_Distributors.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textbox_Distributors.IsInputReadOnly = true;
            this.textbox_Distributors.Location = new System.Drawing.Point(453, 42);
            this.textbox_Distributors.MinValue = 0D;
            this.textbox_Distributors.Name = "textbox_Distributors";
            this.textbox_Distributors.Size = new System.Drawing.Size(85, 20);
            this.textbox_Distributors.TabIndex = 940;
            this.textbox_Distributors.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic);
            this.label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label24.Location = new System.Drawing.Point(599, 19);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(79, 16);
            this.label24.TabIndex = 939;
            this.label24.Text = "سعر المندوب";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic);
            this.label27.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label27.Location = new System.Drawing.Point(460, 19);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(70, 16);
            this.label27.TabIndex = 938;
            this.label27.Text = "سعر الموزع";
            // 
            // textbox_VIP
            // 
            this.textbox_VIP.AllowEmptyState = false;
            // 
            // 
            // 
            this.textbox_VIP.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.textbox_VIP.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textbox_VIP.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textbox_VIP.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textbox_VIP.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textbox_VIP.Increment = 1D;
            this.textbox_VIP.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textbox_VIP.IsInputReadOnly = true;
            this.textbox_VIP.Location = new System.Drawing.Point(38, 42);
            this.textbox_VIP.MinValue = 0D;
            this.textbox_VIP.Name = "textbox_VIP";
            this.textbox_VIP.Size = new System.Drawing.Size(85, 20);
            this.textbox_VIP.TabIndex = 947;
            this.textbox_VIP.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic);
            this.label26.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label26.Location = new System.Drawing.Point(54, 19);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(53, 16);
            this.label26.TabIndex = 946;
            this.label26.Text = "سعر اخر";
            // 
            // textbox_Sectorial
            // 
            this.textbox_Sectorial.AllowEmptyState = false;
            // 
            // 
            // 
            this.textbox_Sectorial.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.textbox_Sectorial.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textbox_Sectorial.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textbox_Sectorial.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textbox_Sectorial.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textbox_Sectorial.Increment = 1D;
            this.textbox_Sectorial.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textbox_Sectorial.IsInputReadOnly = true;
            this.textbox_Sectorial.Location = new System.Drawing.Point(184, 42);
            this.textbox_Sectorial.MinValue = 0D;
            this.textbox_Sectorial.Name = "textbox_Sectorial";
            this.textbox_Sectorial.Size = new System.Drawing.Size(85, 20);
            this.textbox_Sectorial.TabIndex = 945;
            this.textbox_Sectorial.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic);
            this.label25.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label25.Location = new System.Drawing.Point(190, 19);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(73, 16);
            this.label25.TabIndex = 944;
            this.label25.Text = "سعر التجزئة";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(649, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 13);
            this.label12.TabIndex = 920;
            this.label12.Text = "رقم الصنــــف :";
            // 
            // groupBoxUnit
            // 
            this.groupBoxUnit.Controls.Add(this.label7);
            this.groupBoxUnit.Controls.Add(this.label6);
            this.groupBoxUnit.Controls.Add(this.label5);
            this.groupBoxUnit.Controls.Add(this.label3);
            this.groupBoxUnit.Controls.Add(this.label2);
            this.groupBoxUnit.Controls.Add(this.label1);
            this.groupBoxUnit.Controls.Add(this.doubleInput_SelPriceNew4);
            this.groupBoxUnit.Controls.Add(this.doubleInput_SelPriceNew3);
            this.groupBoxUnit.Controls.Add(this.doubleInput_SelPriceNew5);
            this.groupBoxUnit.Controls.Add(this.doubleInput_SelPriceNew2);
            this.groupBoxUnit.Controls.Add(this.doubleInput_SelPriceNew1);
            this.groupBoxUnit.Controls.Add(this.doubleInput_SelPriceNow1);
            this.groupBoxUnit.Controls.Add(this.doubleInput_SelPriceNow2);
            this.groupBoxUnit.Controls.Add(this.doubleInput_SelPriceNow3);
            this.groupBoxUnit.Controls.Add(this.doubleInput_SelPriceNow4);
            this.groupBoxUnit.Controls.Add(this.doubleInput_SelPriceNow5);
            this.groupBoxUnit.Controls.Add(this.comboBoxUnit);
            this.groupBoxUnit.Location = new System.Drawing.Point(147, 52);
            this.groupBoxUnit.Name = "groupBoxUnit";
            this.groupBoxUnit.Size = new System.Drawing.Size(574, 95);
            this.groupBoxUnit.TabIndex = 942;
            this.groupBoxUnit.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(502, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 948;
            this.label7.Text = "الوحـــــدة :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(101, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 16);
            this.label6.TabIndex = 946;
            this.label6.Text = "سعر البيع 5 :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(292, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 16);
            this.label5.TabIndex = 943;
            this.label5.Text = "سعر البيع 4 :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(485, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 940;
            this.label3.Text = "سعر البيع 3 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(101, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 937;
            this.label2.Text = "سعر البيع 2 :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(292, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 933;
            this.label1.Text = "سعر البيع 1 :";
            // 
            // doubleInput_SelPriceNew4
            // 
            this.doubleInput_SelPriceNew4.AllowEmptyState = false;
            // 
            // 
            // 
            this.doubleInput_SelPriceNew4.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.doubleInput_SelPriceNew4.BackgroundStyle.Class = "DateTimeInputBackground";
            this.doubleInput_SelPriceNew4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doubleInput_SelPriceNew4.ButtonCalculator.Visible = true;
            this.doubleInput_SelPriceNew4.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.doubleInput_SelPriceNew4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.doubleInput_SelPriceNew4.Increment = 1D;
            this.doubleInput_SelPriceNew4.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.doubleInput_SelPriceNew4.Location = new System.Drawing.Point(201, 60);
            this.doubleInput_SelPriceNew4.MinValue = 0D;
            this.doubleInput_SelPriceNew4.Name = "doubleInput_SelPriceNew4";
            this.doubleInput_SelPriceNew4.Size = new System.Drawing.Size(85, 20);
            this.doubleInput_SelPriceNew4.TabIndex = 13;
            this.doubleInput_SelPriceNew4.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            this.doubleInput_SelPriceNew4.ValueChanged += new System.EventHandler(this.doubleInput_SelPriceNew4_ValueChanged);
            // 
            // doubleInput_SelPriceNew3
            // 
            this.doubleInput_SelPriceNew3.AllowEmptyState = false;
            // 
            // 
            // 
            this.doubleInput_SelPriceNew3.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.doubleInput_SelPriceNew3.BackgroundStyle.Class = "DateTimeInputBackground";
            this.doubleInput_SelPriceNew3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doubleInput_SelPriceNew3.ButtonCalculator.Visible = true;
            this.doubleInput_SelPriceNew3.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.doubleInput_SelPriceNew3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.doubleInput_SelPriceNew3.Increment = 1D;
            this.doubleInput_SelPriceNew3.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.doubleInput_SelPriceNew3.Location = new System.Drawing.Point(394, 63);
            this.doubleInput_SelPriceNew3.MinValue = 0D;
            this.doubleInput_SelPriceNew3.Name = "doubleInput_SelPriceNew3";
            this.doubleInput_SelPriceNew3.Size = new System.Drawing.Size(85, 20);
            this.doubleInput_SelPriceNew3.TabIndex = 12;
            this.doubleInput_SelPriceNew3.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // doubleInput_SelPriceNew5
            // 
            this.doubleInput_SelPriceNew5.AllowEmptyState = false;
            // 
            // 
            // 
            this.doubleInput_SelPriceNew5.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.doubleInput_SelPriceNew5.BackgroundStyle.Class = "DateTimeInputBackground";
            this.doubleInput_SelPriceNew5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doubleInput_SelPriceNew5.ButtonCalculator.Visible = true;
            this.doubleInput_SelPriceNew5.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.doubleInput_SelPriceNew5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.doubleInput_SelPriceNew5.Increment = 1D;
            this.doubleInput_SelPriceNew5.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.doubleInput_SelPriceNew5.Location = new System.Drawing.Point(10, 60);
            this.doubleInput_SelPriceNew5.MinValue = 0D;
            this.doubleInput_SelPriceNew5.Name = "doubleInput_SelPriceNew5";
            this.doubleInput_SelPriceNew5.Size = new System.Drawing.Size(85, 20);
            this.doubleInput_SelPriceNew5.TabIndex = 14;
            this.doubleInput_SelPriceNew5.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // doubleInput_SelPriceNew2
            // 
            this.doubleInput_SelPriceNew2.AllowEmptyState = false;
            // 
            // 
            // 
            this.doubleInput_SelPriceNew2.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.doubleInput_SelPriceNew2.BackgroundStyle.Class = "DateTimeInputBackground";
            this.doubleInput_SelPriceNew2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doubleInput_SelPriceNew2.ButtonCalculator.Visible = true;
            this.doubleInput_SelPriceNew2.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.doubleInput_SelPriceNew2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.doubleInput_SelPriceNew2.Increment = 1D;
            this.doubleInput_SelPriceNew2.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.doubleInput_SelPriceNew2.Location = new System.Drawing.Point(10, 26);
            this.doubleInput_SelPriceNew2.MinValue = 0D;
            this.doubleInput_SelPriceNew2.Name = "doubleInput_SelPriceNew2";
            this.doubleInput_SelPriceNew2.Size = new System.Drawing.Size(85, 20);
            this.doubleInput_SelPriceNew2.TabIndex = 11;
            this.doubleInput_SelPriceNew2.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // doubleInput_SelPriceNew1
            // 
            this.doubleInput_SelPriceNew1.AllowEmptyState = false;
            // 
            // 
            // 
            this.doubleInput_SelPriceNew1.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.doubleInput_SelPriceNew1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.doubleInput_SelPriceNew1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doubleInput_SelPriceNew1.ButtonCalculator.Visible = true;
            this.doubleInput_SelPriceNew1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.doubleInput_SelPriceNew1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.doubleInput_SelPriceNew1.Increment = 1D;
            this.doubleInput_SelPriceNew1.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.doubleInput_SelPriceNew1.Location = new System.Drawing.Point(201, 26);
            this.doubleInput_SelPriceNew1.MinValue = 0D;
            this.doubleInput_SelPriceNew1.Name = "doubleInput_SelPriceNew1";
            this.doubleInput_SelPriceNew1.Size = new System.Drawing.Size(85, 20);
            this.doubleInput_SelPriceNew1.TabIndex = 10;
            this.doubleInput_SelPriceNew1.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            this.doubleInput_SelPriceNew1.ValueChanged += new System.EventHandler(this.doubleInput_SelPriceNew1_ValueChanged);
            // 
            // doubleInput_SelPriceNow1
            // 
            this.doubleInput_SelPriceNow1.AllowEmptyState = false;
            // 
            // 
            // 
            this.doubleInput_SelPriceNow1.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.doubleInput_SelPriceNow1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.doubleInput_SelPriceNow1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doubleInput_SelPriceNow1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.doubleInput_SelPriceNow1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.doubleInput_SelPriceNow1.Increment = 1D;
            this.doubleInput_SelPriceNow1.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.doubleInput_SelPriceNow1.IsInputReadOnly = true;
            this.doubleInput_SelPriceNow1.Location = new System.Drawing.Point(201, 26);
            this.doubleInput_SelPriceNow1.MinValue = 0D;
            this.doubleInput_SelPriceNow1.Name = "doubleInput_SelPriceNow1";
            this.doubleInput_SelPriceNow1.Size = new System.Drawing.Size(85, 20);
            this.doubleInput_SelPriceNow1.TabIndex = 934;
            this.doubleInput_SelPriceNow1.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // doubleInput_SelPriceNow2
            // 
            this.doubleInput_SelPriceNow2.AllowEmptyState = false;
            // 
            // 
            // 
            this.doubleInput_SelPriceNow2.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.doubleInput_SelPriceNow2.BackgroundStyle.Class = "DateTimeInputBackground";
            this.doubleInput_SelPriceNow2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doubleInput_SelPriceNow2.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.doubleInput_SelPriceNow2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.doubleInput_SelPriceNow2.Increment = 1D;
            this.doubleInput_SelPriceNow2.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.doubleInput_SelPriceNow2.IsInputReadOnly = true;
            this.doubleInput_SelPriceNow2.Location = new System.Drawing.Point(10, 26);
            this.doubleInput_SelPriceNow2.MinValue = 0D;
            this.doubleInput_SelPriceNow2.Name = "doubleInput_SelPriceNow2";
            this.doubleInput_SelPriceNow2.Size = new System.Drawing.Size(85, 20);
            this.doubleInput_SelPriceNow2.TabIndex = 938;
            this.doubleInput_SelPriceNow2.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // doubleInput_SelPriceNow3
            // 
            this.doubleInput_SelPriceNow3.AllowEmptyState = false;
            // 
            // 
            // 
            this.doubleInput_SelPriceNow3.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.doubleInput_SelPriceNow3.BackgroundStyle.Class = "DateTimeInputBackground";
            this.doubleInput_SelPriceNow3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doubleInput_SelPriceNow3.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.doubleInput_SelPriceNow3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.doubleInput_SelPriceNow3.Increment = 1D;
            this.doubleInput_SelPriceNow3.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.doubleInput_SelPriceNow3.IsInputReadOnly = true;
            this.doubleInput_SelPriceNow3.Location = new System.Drawing.Point(394, 63);
            this.doubleInput_SelPriceNow3.MinValue = 0D;
            this.doubleInput_SelPriceNow3.Name = "doubleInput_SelPriceNow3";
            this.doubleInput_SelPriceNow3.Size = new System.Drawing.Size(85, 20);
            this.doubleInput_SelPriceNow3.TabIndex = 941;
            this.doubleInput_SelPriceNow3.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // doubleInput_SelPriceNow4
            // 
            this.doubleInput_SelPriceNow4.AllowEmptyState = false;
            // 
            // 
            // 
            this.doubleInput_SelPriceNow4.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.doubleInput_SelPriceNow4.BackgroundStyle.Class = "DateTimeInputBackground";
            this.doubleInput_SelPriceNow4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doubleInput_SelPriceNow4.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.doubleInput_SelPriceNow4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.doubleInput_SelPriceNow4.Increment = 1D;
            this.doubleInput_SelPriceNow4.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.doubleInput_SelPriceNow4.IsInputReadOnly = true;
            this.doubleInput_SelPriceNow4.Location = new System.Drawing.Point(201, 63);
            this.doubleInput_SelPriceNow4.MinValue = 0D;
            this.doubleInput_SelPriceNow4.Name = "doubleInput_SelPriceNow4";
            this.doubleInput_SelPriceNow4.Size = new System.Drawing.Size(85, 20);
            this.doubleInput_SelPriceNow4.TabIndex = 944;
            this.doubleInput_SelPriceNow4.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // doubleInput_SelPriceNow5
            // 
            this.doubleInput_SelPriceNow5.AllowEmptyState = false;
            // 
            // 
            // 
            this.doubleInput_SelPriceNow5.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.doubleInput_SelPriceNow5.BackgroundStyle.Class = "DateTimeInputBackground";
            this.doubleInput_SelPriceNow5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doubleInput_SelPriceNow5.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.doubleInput_SelPriceNow5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.doubleInput_SelPriceNow5.Increment = 1D;
            this.doubleInput_SelPriceNow5.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.doubleInput_SelPriceNow5.IsInputReadOnly = true;
            this.doubleInput_SelPriceNow5.Location = new System.Drawing.Point(10, 60);
            this.doubleInput_SelPriceNow5.MinValue = 0D;
            this.doubleInput_SelPriceNow5.Name = "doubleInput_SelPriceNow5";
            this.doubleInput_SelPriceNow5.Size = new System.Drawing.Size(85, 20);
            this.doubleInput_SelPriceNow5.TabIndex = 947;
            this.doubleInput_SelPriceNow5.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // comboBoxUnit
            // 
            this.comboBoxUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxUnit.DisplayMember = "Text";
            this.comboBoxUnit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUnit.FormattingEnabled = true;
            this.comboBoxUnit.ItemHeight = 14;
            this.comboBoxUnit.Location = new System.Drawing.Point(394, 27);
            this.comboBoxUnit.Name = "comboBoxUnit";
            this.comboBoxUnit.Size = new System.Drawing.Size(104, 20);
            this.comboBoxUnit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxUnit.TabIndex = 9;
            this.comboBoxUnit.SelectedIndexChanged += new System.EventHandler(this.comboBoxUnit_SelectedIndexChanged);
            // 
            // doubleInput_SelCostNow
            // 
            this.doubleInput_SelCostNow.AllowEmptyState = false;
            // 
            // 
            // 
            this.doubleInput_SelCostNow.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.doubleInput_SelCostNow.BackgroundStyle.Class = "DateTimeInputBackground";
            this.doubleInput_SelCostNow.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.doubleInput_SelCostNow.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.doubleInput_SelCostNow.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.doubleInput_SelCostNow.Increment = 1D;
            this.doubleInput_SelCostNow.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.doubleInput_SelCostNow.IsInputReadOnly = true;
            this.doubleInput_SelCostNow.Location = new System.Drawing.Point(147, 25);
            this.doubleInput_SelCostNow.MinValue = 0D;
            this.doubleInput_SelCostNow.Name = "doubleInput_SelCostNow";
            this.doubleInput_SelCostNow.Size = new System.Drawing.Size(85, 20);
            this.doubleInput_SelCostNow.TabIndex = 955;
            this.doubleInput_SelCostNow.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
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
            this.ribbonBar_Tasks.Location = new System.Drawing.Point(0, 380);
            this.ribbonBar_Tasks.Name = "ribbonBar_Tasks";
            this.ribbonBar_Tasks.Size = new System.Drawing.Size(737, 51);
            this.ribbonBar_Tasks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar_Tasks.TabIndex = 917;
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
            this.superTabControl_Main1.ControlBox.CloseBox.Name = string.Empty;
            // 
            // 
            // 
            this.superTabControl_Main1.ControlBox.MenuBox.Name = string.Empty;
            this.superTabControl_Main1.ControlBox.Name = string.Empty;
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
            this.superTabControl_Main1.Size = new System.Drawing.Size(737, 51);
            this.superTabControl_Main1.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_Main1.TabIndex = 10;
            this.superTabControl_Main1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.Button_Close,
            this.Button_Save,
            this.labelItem2});
            this.superTabControl_Main1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.superTabControl_Main1.Text = "superTabControl3";
            this.superTabControl_Main1.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.superTabControl_Main1.SelectedTabChanged += new System.EventHandler<DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs>(this.superTabControl_Main1_SelectedTabChanged);
            // 
            // Button_Close
            // 
            this.Button_Close.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Close.Checked = true;
            this.Button_Close.FontBold = true;
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
            // Button_Save
            // 
            this.Button_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Save.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.Button_Save.FontBold = true;
            this.Button_Save.ForeColor = System.Drawing.Color.White;
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
            // textbox_SentenceNew
            // 
            this.textbox_SentenceNew.AllowEmptyState = false;
            // 
            // 
            // 
            this.textbox_SentenceNew.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textbox_SentenceNew.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textbox_SentenceNew.ButtonCalculator.Visible = true;
            this.textbox_SentenceNew.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textbox_SentenceNew.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textbox_SentenceNew.Increment = 1D;
            this.textbox_SentenceNew.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textbox_SentenceNew.Location = new System.Drawing.Point(326, 42);
            this.textbox_SentenceNew.MinValue = 0D;
            this.textbox_SentenceNew.Name = "textbox_SentenceNew";
            this.textbox_SentenceNew.Size = new System.Drawing.Size(85, 20);
            this.textbox_SentenceNew.TabIndex = 948;
            this.textbox_SentenceNew.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            // 
            // FrmEditItemsPrices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 431);
            this.Controls.Add(this.ribbonBar1);
            this.Controls.Add(this.ribbonBar_Tasks);
            this.Controls.Add(this.dockSite5);
            this.Controls.Add(this.dockSite6);
            this.Controls.Add(this.dockSite7);
            this.Controls.Add(this.dockSite8);
            this.Controls.Add(this.dockSite9);
            this.Controls.Add(this.dockSite10);
            this.Controls.Add(this.dockSite11);
            this.Controls.Add(this.dockSite12);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = (InvAcc.Properties.Resources.favicon);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmEditItemsPrices";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "شاشة تعديل اسعار الصنف";
            this.Load += new System.EventHandler(this.FrmEditItemsPrices_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.contextMenuStrip4.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_SelCostNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX_Data)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_LegatesNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_DistributorsNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_VIPNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_SectorialNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_Sentence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_Legates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_Distributors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_VIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_Sectorial)).EndInit();
            this.groupBoxUnit.ResumeLayout(false);
            this.groupBoxUnit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_SelPriceNew4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_SelPriceNew3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_SelPriceNew5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_SelPriceNew2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_SelPriceNew1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_SelPriceNow1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_SelPriceNow2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_SelPriceNow3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_SelPriceNow4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_SelPriceNow5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleInput_SelCostNow)).EndInit();
            this.ribbonBar_Tasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_SentenceNew)).EndInit();
            this.Icon = (InvAcc.Properties.Resources.favicon);
            this.ResumeLayout(false);

        }
        public FrmEditItemsPrices(string itmNo)
        {
            InitializeComponent();
            vItmNo = itmNo;
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
            {
                doubleInput_SelCostNew.DisplayFormat = VarGeneral.DicemalMask;
                doubleInput_SelPriceNew1.DisplayFormat = VarGeneral.DicemalMask;
                doubleInput_SelPriceNew2.DisplayFormat = VarGeneral.DicemalMask;
                doubleInput_SelPriceNew3.DisplayFormat = VarGeneral.DicemalMask;
                doubleInput_SelPriceNew4.DisplayFormat = VarGeneral.DicemalMask;
                doubleInput_SelPriceNew5.DisplayFormat = VarGeneral.DicemalMask;
                textbox_LegatesNew.DisplayFormat = VarGeneral.DicemalMask;
                textbox_DistributorsNew.DisplayFormat = VarGeneral.DicemalMask;
                textbox_SentenceNew.DisplayFormat = VarGeneral.DicemalMask;
                textbox_SectorialNew.DisplayFormat = VarGeneral.DicemalMask;
                textbox_VIPNew.DisplayFormat = VarGeneral.DicemalMask;
            }
        }
        public void Clear()
        {
            data_this = new T_Item();
            for (int i = 0; i < controls.Count; i++)
            {
                if (controls[i].GetType() == typeof(CheckBox))
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
                        (controls[i] as ComboBox).SelectedIndex = 0;
                    }
                    else if (controls[i].GetType() == typeof(ComboBoxEx))
                    {
                        (controls[i] as ComboBoxEx).SelectedIndex = 0;
                    }
                }
            }
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmEditItemsPrices));
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                Language.ChangeLanguage("ar-SA", this, resources);
                LangArEn = 0;
            }
            else if (VarGeneral.CurrentLang.ToString() == "1")
            {
                Language.ChangeLanguage("en", this, resources);
                LangArEn = 1;
            }
            FillCombo();
            ChangLang();
        }
        private void FrmEditItemsPrices_Load(object sender, EventArgs e)
        {
            ADD_Controls();
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmEditItemsPrices));
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    Language.ChangeLanguage("ar-SA", this, resources);
                    LangArEn = 0;
                }
                else
                {
                    Language.ChangeLanguage("en", this, resources);
                    LangArEn = 1;
                }
                Clear();
                FillCombo();
                textBox_ID.Text = vItmNo;
                comboBoxUnit_SelectedIndexChanged(sender, e);
                ChangLang();
                try
                {
                    List<T_EditItemPrice> q = (from t in db.T_EditItemPrices
                                               orderby t.ID
                                               where t.ItmNo == vItmNo
                                               select t).ToList();
                    if (q.Count > 0)
                    {
                        for (int i = 0; i < q.Count; i++)
                        {
                            dataGridViewX_Data.Rows.Add();
                            dataGridViewX_Data.Rows[i].Cells[0].Value = q[i].ItmNo;
                            dataGridViewX_Data.Rows[i].Cells[1].Value = ((LangArEn == 0) ? q[i].T_Item.Arb_Des : q[i].T_Item.Eng_Des);
                            dataGridViewX_Data.Rows[i].Cells[2].Value = q[i].SelCostNow.Value;
                            dataGridViewX_Data.Rows[i].Cells[3].Value = q[i].SelCostNew.Value;
                            dataGridViewX_Data.Rows[i].Cells[4].Value = n.FormatHijri(q[i].HDate, "yyyy/MM/dd");
                            dataGridViewX_Data.Rows[i].Cells[5].Value = n.FormatHijri(q[i].GDate, "yyyy/MM/dd");
                            dataGridViewX_Data.Rows[i].Cells[6].Value = (VarGeneral.CheckTime(q[i].LTim) ? q[i].LTim : string.Empty);
                            dataGridViewX_Data.Rows[i].Cells[7].Value = q[i].UsrNm;
                            dataGridViewX_Data.Rows[i].Cells[8].Value = q[i].SelPriceNow1;
                            dataGridViewX_Data.Rows[i].Cells[9].Value = q[i].SelPriceNew1;
                            dataGridViewX_Data.Rows[i].Cells[10].Value = q[i].SelPriceNow2;
                            dataGridViewX_Data.Rows[i].Cells[11].Value = q[i].SelPriceNew2;
                            dataGridViewX_Data.Rows[i].Cells[12].Value = q[i].SelPriceNow3;
                            dataGridViewX_Data.Rows[i].Cells[13].Value = q[i].SelPriceNew3;
                            dataGridViewX_Data.Rows[i].Cells[14].Value = q[i].SelPriceNow4;
                            dataGridViewX_Data.Rows[i].Cells[15].Value = q[i].SelPriceNew4;
                            dataGridViewX_Data.Rows[i].Cells[16].Value = q[i].SelPriceNow5;
                            dataGridViewX_Data.Rows[i].Cells[17].Value = q[i].SelPriceNew5;
                            dataGridViewX_Data.Rows[i].Cells[18].Value = q[i].Legates;
                            dataGridViewX_Data.Rows[i].Cells[19].Value = q[i].LegatesNew;
                            dataGridViewX_Data.Rows[i].Cells[20].Value = q[i].Distributors;
                            dataGridViewX_Data.Rows[i].Cells[21].Value = q[i].DistributorsNew;
                            dataGridViewX_Data.Rows[i].Cells[22].Value = q[i].Sentence;
                            dataGridViewX_Data.Rows[i].Cells[23].Value = q[i].SentenceNew;
                            dataGridViewX_Data.Rows[i].Cells[24].Value = q[i].Sectorial;
                            dataGridViewX_Data.Rows[i].Cells[25].Value = q[i].SectorialNew;
                            dataGridViewX_Data.Rows[i].Cells[26].Value = q[i].VIP;
                            dataGridViewX_Data.Rows[i].Cells[27].Value = q[i].VIPNew;
                        }
                    }
                    else
                    {
                        dataGridViewX_Data.Rows.Clear();
                    }
                }
                catch
                {
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void ChangLang()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                dataGridViewX_Data.Columns[0].HeaderText = "رقم الصنف";
                dataGridViewX_Data.Columns[1].HeaderText = "إسم الصنف";
                dataGridViewX_Data.Columns[2].HeaderText = "سعر التكلفة قبل";
                dataGridViewX_Data.Columns[3].HeaderText = "سعر التكلفة بعد";
                dataGridViewX_Data.Columns[4].HeaderText = "التاريخ هـ";
                dataGridViewX_Data.Columns[5].HeaderText = "التاريخ م";
                dataGridViewX_Data.Columns[6].HeaderText = "الوقت";
                dataGridViewX_Data.Columns[7].HeaderText = "المستخدم";
                dataGridViewX_Data.Columns[8].HeaderText = "سعر البيع 1 قبل";
                dataGridViewX_Data.Columns[9].HeaderText = "سعر البيع 1 بعد";
                dataGridViewX_Data.Columns[10].HeaderText = "سعر البيع 2 قبل";
                dataGridViewX_Data.Columns[11].HeaderText = "سعر البيع 2 بعد";
                dataGridViewX_Data.Columns[12].HeaderText = "سعر البيع 3 قبل";
                dataGridViewX_Data.Columns[13].HeaderText = "سعر البيع 3 بعد";
                dataGridViewX_Data.Columns[14].HeaderText = "سعر البيع 4 قبل";
                dataGridViewX_Data.Columns[15].HeaderText = "سعر البيع 4 بعد";
                dataGridViewX_Data.Columns[16].HeaderText = "سعر البيع 5 قبل";
                dataGridViewX_Data.Columns[17].HeaderText = "سعر البيع 5 بعد";
                dataGridViewX_Data.Columns[18].HeaderText = "سعر المندوب قبل";
                dataGridViewX_Data.Columns[19].HeaderText = "سعر المندوب بعد";
                dataGridViewX_Data.Columns[20].HeaderText = "سعر الموزع قبل";
                dataGridViewX_Data.Columns[21].HeaderText = "سعر الموزع بعد";
                dataGridViewX_Data.Columns[22].HeaderText = "سعر الجملة قبل";
                dataGridViewX_Data.Columns[23].HeaderText = "سعر الجملة بعد";
                dataGridViewX_Data.Columns[24].HeaderText = "سعر التجزئة قبل";
                dataGridViewX_Data.Columns[25].HeaderText = "سعر التجزئة بعد";
                dataGridViewX_Data.Columns[26].HeaderText = "سعر اخر قبل";
                dataGridViewX_Data.Columns[27].HeaderText = "سعر آخر بعد";
                Button_Close.Text = "خروج";
                Button_Save.Text = "حفظ";
                Text = "شاشة تعديل الأسعار";
            }
            else
            {
                dataGridViewX_Data.Columns[0].HeaderText = "Item No";
                dataGridViewX_Data.Columns[1].HeaderText = "Item Name";
                dataGridViewX_Data.Columns[2].HeaderText = "Cost Value Before";
                dataGridViewX_Data.Columns[3].HeaderText = "Cost Value After";
                dataGridViewX_Data.Columns[4].HeaderText = "Date H";
                dataGridViewX_Data.Columns[5].HeaderText = "Date G";
                dataGridViewX_Data.Columns[6].HeaderText = "Time";
                dataGridViewX_Data.Columns[7].HeaderText = "User";
                dataGridViewX_Data.Columns[8].HeaderText = "Price Sel 1 Befor";
                dataGridViewX_Data.Columns[9].HeaderText = "Price Sel 1 after";
                dataGridViewX_Data.Columns[10].HeaderText = "Price Sel 1 Befor";
                dataGridViewX_Data.Columns[11].HeaderText = "Price Sel 1 after";
                dataGridViewX_Data.Columns[12].HeaderText = "Price Sel 1 Befor";
                dataGridViewX_Data.Columns[13].HeaderText = "Price Sel 1 after";
                dataGridViewX_Data.Columns[14].HeaderText = "Price Sel 1 Befor";
                dataGridViewX_Data.Columns[15].HeaderText = "Price Sel 1 after";
                dataGridViewX_Data.Columns[16].HeaderText = "Price Sel 1 Befor";
                dataGridViewX_Data.Columns[17].HeaderText = "Price Sel 1 after";
                dataGridViewX_Data.Columns[18].HeaderText = "Price Delegate before";
                dataGridViewX_Data.Columns[19].HeaderText = "Price Delegate after";
                dataGridViewX_Data.Columns[20].HeaderText = "Price Distributor Befor";
                dataGridViewX_Data.Columns[21].HeaderText = "Price Distributor After";
                dataGridViewX_Data.Columns[22].HeaderText = "Price Sentence Befor";
                dataGridViewX_Data.Columns[23].HeaderText = "Price Sentence After";
                dataGridViewX_Data.Columns[24].HeaderText = "Price Retail Befor";
                dataGridViewX_Data.Columns[25].HeaderText = "Price Retail After";
                dataGridViewX_Data.Columns[26].HeaderText = "Price Other Befor";
                dataGridViewX_Data.Columns[27].HeaderText = "Price Other After";
                Button_Close.Text = "Close";
                Button_Save.Text = "Save";
                Text = "Price Edite Form";
            }
        }
        private void ADD_Controls()
        {
            try
            {
                controls = new List<Control>();
                controls.Add(doubleInput_SelCostNew);
                controls.Add(doubleInput_SelCostNow);
                controls.Add(doubleInput_SelPriceNew1);
                controls.Add(doubleInput_SelPriceNow1);
                controls.Add(doubleInput_SelPriceNew2);
                controls.Add(doubleInput_SelPriceNow2);
                controls.Add(doubleInput_SelPriceNew3);
                controls.Add(doubleInput_SelPriceNow3);
                controls.Add(doubleInput_SelPriceNew4);
                controls.Add(doubleInput_SelPriceNow4);
                controls.Add(doubleInput_SelPriceNew5);
                controls.Add(doubleInput_SelPriceNow5);
                controls.Add(textbox_Distributors);
                controls.Add(textbox_DistributorsNew);
                controls.Add(textbox_Legates);
                controls.Add(textbox_LegatesNew);
                controls.Add(textbox_Sectorial);
                controls.Add(textbox_SectorialNew);
                controls.Add(textbox_Sentence);
                controls.Add(textbox_SentenceNew);
                controls.Add(textbox_VIP);
                controls.Add(textbox_VIPNew);
                controls.Add(pictureBox_PicItem);
            }
            catch
            {
            }
        }
        private void FillCombo()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                comboBoxUnit.DataSource = null;
                List<T_Unit> listUnit1 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
                listUnit1.Insert(0, new T_Unit());
                comboBoxUnit.DataSource = listUnit1;
                comboBoxUnit.DisplayMember = "Arb_Des";
                comboBoxUnit.ValueMember = "Unit_ID";
                comboBoxUnit.SelectedIndex = 0;
            }
            else
            {
                comboBoxUnit.DataSource = null;
                List<T_Unit> listUnit1 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
                listUnit1.Insert(0, new T_Unit());
                comboBoxUnit.DataSource = listUnit1;
                comboBoxUnit.DisplayMember = "Eng_Des";
                comboBoxUnit.ValueMember = "Unit_ID";
                comboBoxUnit.SelectedIndex = 0;
            }
        }
        public void SetData(T_Item value)
        {
            try
            {
                textbox_Distributors.Value = value.Price2.Value;
                textbox_Legates.Value = value.Price3.Value;
                textbox_Sectorial.Value = value.Price4.Value;
                textbox_Sentence.Value = value.Price1.Value;
                textbox_VIP.Value = value.Price5.Value;
                textbox_DistributorsNew.Value = value.Price2.Value;
                textbox_LegatesNew.Value = value.Price3.Value;
                textbox_SectorialNew.Value = value.Price4.Value;
                textbox_SentenceNew.Value = value.Price1.Value;
                textbox_VIPNew.Value = value.Price5.Value;
                doubleInput_SelCostNow.Value = value.AvrageCost.Value;
                doubleInput_SelCostNew.Value = value.AvrageCost.Value;
                doubleInput_SelPriceNow1.Value = value.UntPri1.Value;
                doubleInput_SelPriceNow2.Value = value.UntPri2.Value;
                doubleInput_SelPriceNow3.Value = value.UntPri3.Value;
                doubleInput_SelPriceNow4.Value = value.UntPri4.Value;
                doubleInput_SelPriceNow5.Value = value.UntPri5.Value;
                doubleInput_SelPriceNew1.Value = value.UntPri1.Value;
                doubleInput_SelPriceNew2.Value = value.UntPri2.Value;
                doubleInput_SelPriceNew3.Value = value.UntPri3.Value;
                doubleInput_SelPriceNew4.Value = value.UntPri4.Value;
                doubleInput_SelPriceNew5.Value = value.UntPri5.Value;
                if (value.ItmImg != null)
                {
                    byte[] arr = value.ItmImg.ToArray();
                    MemoryStream stream = new MemoryStream(arr);
                    pictureBox_PicItem.Image = Image.FromStream(stream);
                }
                else
                {
                    pictureBox_PicItem.Image = null;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SetData:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void comboBoxUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                doubleInput_SelPriceNew1.Enabled = false;
                doubleInput_SelPriceNew2.Enabled = false;
                doubleInput_SelPriceNew3.Enabled = false;
                doubleInput_SelPriceNew4.Enabled = false;
                doubleInput_SelPriceNew5.Enabled = false;
                if (comboBoxUnit.SelectedIndex <= 0)
                {
                    return;
                }
                List<T_Item> q = db.T_Items.Where((T_Item t) => t.Itm_No == textBox_ID.Text && (t.Unit1.Value == int.Parse(comboBoxUnit.SelectedValue.ToString()) || t.Unit2.Value == int.Parse(comboBoxUnit.SelectedValue.ToString()) || t.Unit3.Value == int.Parse(comboBoxUnit.SelectedValue.ToString()) || t.Unit4.Value == int.Parse(comboBoxUnit.SelectedValue.ToString()) || t.Unit5.Value == int.Parse(comboBoxUnit.SelectedValue.ToString()))).ToList();
                if (q != null && !string.IsNullOrEmpty(q.First().Itm_No))
                {
                    if (q.First().Unit1 == int.Parse(comboBoxUnit.SelectedValue.ToString()))
                    {
                        doubleInput_SelPriceNew1.Enabled = true;
                        doubleInput_SelPriceNew2.Enabled = false;
                        doubleInput_SelPriceNew3.Enabled = false;
                        doubleInput_SelPriceNew4.Enabled = false;
                        doubleInput_SelPriceNew5.Enabled = false;
                    }
                    else if (q.First().Unit2 == int.Parse(comboBoxUnit.SelectedValue.ToString()))
                    {
                        doubleInput_SelPriceNew1.Enabled = false;
                        doubleInput_SelPriceNew2.Enabled = true;
                        doubleInput_SelPriceNew3.Enabled = false;
                        doubleInput_SelPriceNew4.Enabled = false;
                        doubleInput_SelPriceNew5.Enabled = false;
                    }
                    else if (q.First().Unit3 == int.Parse(comboBoxUnit.SelectedValue.ToString()))
                    {
                        doubleInput_SelPriceNew1.Enabled = false;
                        doubleInput_SelPriceNew2.Enabled = false;
                        doubleInput_SelPriceNew3.Enabled = true;
                        doubleInput_SelPriceNew4.Enabled = false;
                        doubleInput_SelPriceNew5.Enabled = false;
                    }
                    else if (q.First().Unit4 == int.Parse(comboBoxUnit.SelectedValue.ToString()))
                    {
                        doubleInput_SelPriceNew1.Enabled = false;
                        doubleInput_SelPriceNew2.Enabled = false;
                        doubleInput_SelPriceNew3.Enabled = false;
                        doubleInput_SelPriceNew4.Enabled = true;
                        doubleInput_SelPriceNew5.Enabled = false;
                    }
                    else if (q.First().Unit5 == int.Parse(comboBoxUnit.SelectedValue.ToString()))
                    {
                        doubleInput_SelPriceNew1.Enabled = false;
                        doubleInput_SelPriceNew2.Enabled = false;
                        doubleInput_SelPriceNew3.Enabled = false;
                        doubleInput_SelPriceNew4.Enabled = false;
                        doubleInput_SelPriceNew5.Enabled = true;
                    }
                }
            }
            catch
            {
                doubleInput_SelPriceNew1.Enabled = false;
                doubleInput_SelPriceNew2.Enabled = false;
                doubleInput_SelPriceNew3.Enabled = false;
                doubleInput_SelPriceNew4.Enabled = false;
                doubleInput_SelPriceNow5.Enabled = false;
            }
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
            if (e.KeyCode == Keys.F2 && Button_Save.Enabled && Button_Save.Visible)
            {
                Button_Save_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private bool CheckUpdate()
        {
            try
            {
                if (doubleInput_SelCostNew.Value != data_this.AvrageCost.Value)
                {
                    return true;
                }
                if (data_this.Unit1.HasValue && doubleInput_SelPriceNew1.Value != data_this.UntPri1.Value)
                {
                    return true;
                }
                if (data_this.Unit2.HasValue && doubleInput_SelPriceNew2.Value != data_this.UntPri2.Value)
                {
                    return true;
                }
                if (data_this.Unit3.HasValue && doubleInput_SelPriceNew3.Value != data_this.UntPri3.Value)
                {
                    return true;
                }
                if (data_this.Unit4.HasValue && doubleInput_SelPriceNew4.Value != data_this.UntPri4.Value)
                {
                    return true;
                }
                if (data_this.Unit5.HasValue && doubleInput_SelPriceNew5.Value != data_this.UntPri5.Value)
                {
                    return true;
                }
                if (data_this.Price1 != textbox_SentenceNew.Value)
                {
                    return true;
                }
                if (data_this.Price2 != textbox_DistributorsNew.Value)
                {
                    return true;
                }
                if (data_this.Price3 != textbox_LegatesNew.Value)
                {
                    return true;
                }
                if (data_this.Price4 != textbox_SectorialNew.Value)
                {
                    return true;
                }
                if (data_this.Price5 != textbox_VIPNew.Value)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        private void Button_Save_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_ID.Text) && CheckUpdate())
            {
                GetData();
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                data_this_EditPrice = new T_EditItemPrice();
                data_this_EditPrice.ItmNo = textBox_ID.Text;
                data_this_EditPrice.SelCostNow = doubleInput_SelCostNow.Value;
                data_this_EditPrice.SelCostNew = doubleInput_SelCostNew.Value;
                if (data_this.Unit1.HasValue)
                {
                    data_this_EditPrice.SelPriceNow1 = doubleInput_SelPriceNow1.Value;
                    data_this_EditPrice.SelPriceNew1 = doubleInput_SelPriceNew1.Value;
                }
                else
                {
                    data_this_EditPrice.SelPriceNow1 = null;
                    data_this_EditPrice.SelPriceNew1 = null;
                }
                if (data_this.Unit2.HasValue)
                {
                    data_this_EditPrice.SelPriceNow2 = doubleInput_SelPriceNow2.Value;
                    data_this_EditPrice.SelPriceNew2 = doubleInput_SelPriceNew2.Value;
                }
                else
                {
                    data_this_EditPrice.SelPriceNow2 = null;
                    data_this_EditPrice.SelPriceNew2 = null;
                }
                if (data_this.Unit3.HasValue)
                {
                    data_this_EditPrice.SelPriceNow3 = doubleInput_SelPriceNow3.Value;
                    data_this_EditPrice.SelPriceNew3 = doubleInput_SelPriceNew3.Value;
                }
                else
                {
                    data_this_EditPrice.SelPriceNow3 = null;
                    data_this_EditPrice.SelPriceNew3 = null;
                }
                if (data_this.Unit4.HasValue)
                {
                    data_this_EditPrice.SelPriceNow4 = doubleInput_SelPriceNow4.Value;
                    data_this_EditPrice.SelPriceNew4 = doubleInput_SelPriceNew4.Value;
                }
                else
                {
                    data_this_EditPrice.SelPriceNow4 = null;
                    data_this_EditPrice.SelPriceNew4 = null;
                }
                if (data_this.Unit5.HasValue)
                {
                    data_this_EditPrice.SelPriceNow5 = doubleInput_SelPriceNow5.Value;
                    data_this_EditPrice.SelPriceNew5 = doubleInput_SelPriceNew5.Value;
                }
                else
                {
                    data_this_EditPrice.SelPriceNow5 = null;
                    data_this_EditPrice.SelPriceNew5 = null;
                }
                data_this_EditPrice.Distributors = textbox_Distributors.Value;
                data_this_EditPrice.DistributorsNew = textbox_DistributorsNew.Value;
                data_this_EditPrice.Legates = textbox_Legates.Value;
                data_this_EditPrice.LegatesNew = textbox_LegatesNew.Value;
                data_this_EditPrice.Sectorial = textbox_Sectorial.Value;
                data_this_EditPrice.SectorialNew = textbox_SectorialNew.Value;
                data_this_EditPrice.Sentence = textbox_Sentence.Value;
                data_this_EditPrice.SentenceNew = textbox_SentenceNew.Value;
                data_this_EditPrice.VIP = textbox_VIP.Value;
                data_this_EditPrice.VIPNew = textbox_VIPNew.Value;
                data_this_EditPrice.HDate = VarGeneral.Hdate;
                data_this_EditPrice.GDate = VarGeneral.Gdate;
                data_this_EditPrice.UsrNm = VarGeneral.UserNameA;
                data_this_EditPrice.LTim = DateTime.Now.ToString("HH:mm");
                try
                {
                    db.T_EditItemPrices.InsertOnSubmit(data_this_EditPrice);
                    db.SubmitChanges();
                    MessageBox.Show((LangArEn == 0) ? "تم عملية التعديل بنجاح" : "Operation accomplished successfully", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Close();
                }
                catch (SqlException ex)
                {
                    VarGeneral.DebLog.writeLog("Butto_Save_Click:", ex, enable: true);
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private T_Item GetData()
        {
            try
            {
                if (double.TryParse(doubleInput_SelCostNew.Text, out var value))
                {
                    data_this.AvrageCost = value;
                    data_this.LastCost = value;
                }
                else
                {
                    data_this.AvrageCost = 0.0;
                }
                if (data_this.Unit1.HasValue)
                {
                    if (double.TryParse(doubleInput_SelPriceNew1.Text, out value))
                    {
                        data_this.UntPri1 = value;
                    }
                    else
                    {
                        data_this.UntPri1 = 0.0;
                    }
                }
                if (data_this.Unit2.HasValue)
                {
                    if (double.TryParse(doubleInput_SelPriceNew2.Text, out value))
                    {
                        data_this.UntPri2 = value;
                    }
                    else
                    {
                        data_this.UntPri2 = 0.0;
                    }
                }
                if (data_this.Unit3.HasValue)
                {
                    if (double.TryParse(doubleInput_SelPriceNew3.Text, out value))
                    {
                        data_this.UntPri3 = value;
                    }
                    else
                    {
                        data_this.UntPri3 = 0.0;
                    }
                }
                if (data_this.Unit4.HasValue)
                {
                    if (double.TryParse(doubleInput_SelPriceNew4.Text, out value))
                    {
                        data_this.UntPri4 = value;
                    }
                    else
                    {
                        data_this.UntPri4 = 0.0;
                    }
                }
                if (data_this.Unit5.HasValue)
                {
                    if (double.TryParse(doubleInput_SelPriceNew5.Text, out value))
                    {
                        data_this.UntPri5 = value;
                    }
                    else
                    {
                        data_this.UntPri5 = 0.0;
                    }
                }
                data_this.Price1 = textbox_SentenceNew.Value;
                data_this.Price2 = textbox_DistributorsNew.Value;
                data_this.Price3 = textbox_LegatesNew.Value;
                data_this.Price4 = textbox_SectorialNew.Value;
                data_this.Price5 = textbox_VIPNew.Value;
                return data_this;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return data_this;
        }
        private void textBox_ID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                T_Item newData = db.StockItem(textBox_ID.Text);
                if (newData == null || string.IsNullOrEmpty(newData.Itm_No))
                {
                    Clear();
                }
                else
                {
                    DataThis = newData;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("textBox_ID_TextChanged:", error, enable: true);
                MessageBox.Show(error.Message);
                Close();
            }
        }

        private void superTabControl_Main1_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        {

        }

        private void doubleInput_SelPriceNew1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void doubleInput_SelPriceNew4_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
