using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using Framework.UI;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FMInvPrintSetup : Form
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
        private class Item
        {
            public string Name;
            public int Value;
            public Item(string name, int value)
            {
                Name = name;
                Value = value;
            }
            public override string ToString()
            {
                return Name;
            }
        }
        private IContainer components = null;
        private void netResize1_AfterControlResize(object sender, Softgroup.NetResize.AfterControlResizeEventArgs e)
        {
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

        public Softgroup.NetResize.NetResize netResize1;

        private CheckBox ChkPTable;
        private Label label8;
        private RibbonBar ribbonBar1;
        private Panel panel1;
        private LabelX labelX1;
        private GroupBox groupBox_PrintType;
        private RadioButton RedButCasher;
        private RadioButton RedButPaperA4;
        private GroupBox groupBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBoxEx CmbInvType;
        private Label label7;
        private DoubleInput txtTopM;
        private DoubleInput txtBottM;
        private DoubleInput txtRight;
        private DoubleInput txtLeftM;
        private ComboBoxEx CmbPrinter;
        private GroupBox groupBox3;
        private ButtonX ButWithoutSave;
        private ButtonX ButWithSave;
        private CheckBox checkBox_previewPrint;
        private DoubleInput txtDistance;
        private IntegerInput txtLinePage;
        private Label label6;
        private Label label5;
        private IntegerInput txtpageCount;
        private Label label33;
        private GroupBox groupBox4;
        private RadioButton RButLandscape;
        private RadioButton RButPortrait;
        private ComboBoxEx CmbPaperSize;
        private Label label9;
        private TextBoxX textBox_CachierTxtE;
        private TextBoxX textBox_CachierTxtA;
        private PictureBox picture_SSS;
        private SwitchButton chk_Stoped;
        private CheckBoxX checkBox_WaiterAll;
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private Item _item = new Item("", 0);
        private int LangArEn = 0;
        private Stock_DataDataContext dbInstance;
        private int _SettingType = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
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
        public bool SetReadOnly
        {
            set
            {
                if (value)
                {
                    State = FormState.Saved;
                }
                ButWithSave.Enabled = !value;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMInvPrintSetup));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();

            components = new System.ComponentModel.Container();

            this.ChkPTable = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox_WaiterAll = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk_Stoped = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.groupBox_PrintType = new System.Windows.Forms.GroupBox();
            this.RedButCasher = new System.Windows.Forms.RadioButton();
            this.RedButPaperA4 = new System.Windows.Forms.RadioButton();
            this.checkBox_previewPrint = new System.Windows.Forms.CheckBox();
            this.CmbInvType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_CachierTxtA = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBox_CachierTxtE = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.RButLandscape = new System.Windows.Forms.RadioButton();
            this.RButPortrait = new System.Windows.Forms.RadioButton();
            this.CmbPaperSize = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label9 = new System.Windows.Forms.Label();
            this.txtpageCount = new DevComponents.Editors.IntegerInput();
            this.label33 = new System.Windows.Forms.Label();
            this.txtDistance = new DevComponents.Editors.DoubleInput();
            this.txtLinePage = new DevComponents.Editors.IntegerInput();
            this.CmbPrinter = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtTopM = new DevComponents.Editors.DoubleInput();
            this.txtBottM = new DevComponents.Editors.DoubleInput();
            this.txtRight = new DevComponents.Editors.DoubleInput();
            this.txtLeftM = new DevComponents.Editors.DoubleInput();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.picture_SSS = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ButWithoutSave = new DevComponents.DotNetBar.ButtonX();
            this.ButWithSave = new DevComponents.DotNetBar.ButtonX();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();

            this.ribbonBar1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox_PrintType.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtpageCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinePage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTopM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBottM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeftM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_SSS)).BeginInit();
            this.groupBox3.SuspendLayout();

            this.PanelSpecialContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSpecialContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelSpecialContainer.Name = "PanelSpecialContainer";
            this.PanelSpecialContainer.Size = new System.Drawing.Size(1278, 514);
            this.PanelSpecialContainer.TabIndex = 1220;
            this.Controls.Add(this.PanelSpecialContainer);
            // 
            // ChkPTable
            // 
            this.ChkPTable.AutoSize = true;
            this.ChkPTable.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ChkPTable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ChkPTable.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ChkPTable.Location = new System.Drawing.Point(249, 95);
            this.ChkPTable.Name = "ChkPTable";
            this.ChkPTable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ChkPTable.Size = new System.Drawing.Size(201, 17);
            this.ChkPTable.TabIndex = 2;
            this.ChkPTable.Text = "طباعة الفاتورة بالشكل الإفتراضي";
            this.ChkPTable.UseVisualStyleBackColor = true;
            this.ChkPTable.CheckedChanged += new System.EventHandler(this.ChkPTable_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(389, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 41;
            this.label8.Text = " نوع الفاتورة:";
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
            this.ribbonBar1.Controls.Add(this.panel1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(466, 407);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 870;
            this.ribbonBar1.ThemeAware = true;
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.checkBox_WaiterAll);
            this.panel1.Controls.Add(this.chk_Stoped);
            this.panel1.Controls.Add(this.groupBox_PrintType);
            this.panel1.Controls.Add(this.checkBox_previewPrint);
            this.panel1.Controls.Add(this.CmbInvType);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.ChkPTable);
            this.panel1.Controls.Add(this.picture_SSS);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(466, 390);
            this.panel1.TabIndex = 858;
            // 
            // checkBox_WaiterAll
            // 
            this.checkBox_WaiterAll.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // 
            // 
            this.checkBox_WaiterAll.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.checkBox_WaiterAll.BackgroundStyle.BorderBottomWidth = 1;
            this.checkBox_WaiterAll.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionInactiveText;
            this.checkBox_WaiterAll.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.checkBox_WaiterAll.BackgroundStyle.BorderLeftWidth = 1;
            this.checkBox_WaiterAll.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.checkBox_WaiterAll.BackgroundStyle.BorderRightWidth = 1;
            this.checkBox_WaiterAll.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.checkBox_WaiterAll.BackgroundStyle.BorderTopWidth = 1;
            this.checkBox_WaiterAll.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_WaiterAll.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            this.checkBox_WaiterAll.Location = new System.Drawing.Point(224, 60);
            this.checkBox_WaiterAll.Name = "checkBox_WaiterAll";
            this.checkBox_WaiterAll.Size = new System.Drawing.Size(26, 53);
            this.checkBox_WaiterAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_WaiterAll.TabIndex = 1022;
            this.checkBox_WaiterAll.Text = "الكل";
            this.checkBox_WaiterAll.Visible = false;
            this.checkBox_WaiterAll.CheckedChanged += new System.EventHandler(this.checkBox_WaiterAll_CheckedChanged);
            // 
            // chk_Stoped
            // 
            // 
            // 
            // 
            this.chk_Stoped.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk_Stoped.Location = new System.Drawing.Point(252, 87);
            this.chk_Stoped.Name = "chk_Stoped";
            this.chk_Stoped.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.chk_Stoped.OffText = "إيقاف الطباعة";
            this.chk_Stoped.OffTextColor = System.Drawing.Color.White;
            this.chk_Stoped.OnText = "إيقاف الطباعة";
            this.chk_Stoped.Size = new System.Drawing.Size(198, 26);
            this.chk_Stoped.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk_Stoped.SwitchWidth = 40;
            this.chk_Stoped.TabIndex = 1021;
            this.chk_Stoped.Visible = false;
            // 
            // groupBox_PrintType
            // 
            this.groupBox_PrintType.Controls.Add(this.RedButCasher);
            this.groupBox_PrintType.Controls.Add(this.RedButPaperA4);
            this.groupBox_PrintType.Location = new System.Drawing.Point(14, 39);
            this.groupBox_PrintType.Name = "groupBox_PrintType";
            this.groupBox_PrintType.Size = new System.Drawing.Size(208, 88);
            this.groupBox_PrintType.TabIndex = 89;
            this.groupBox_PrintType.TabStop = false;
            this.groupBox_PrintType.Text = "طريقة الطباعة";
            // 
            // RedButCasher
            // 
            this.RedButCasher.AutoSize = true;
            this.RedButCasher.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RedButCasher.Location = new System.Drawing.Point(34, 56);
            this.RedButCasher.Name = "RedButCasher";
            this.RedButCasher.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RedButCasher.Size = new System.Drawing.Size(137, 17);
            this.RedButCasher.TabIndex = 14;
            this.RedButCasher.Text = "طباعة على ورق الكاشير";
            this.RedButCasher.UseVisualStyleBackColor = true;
            this.RedButCasher.CheckedChanged += new System.EventHandler(this.RedButCasher_CheckedChanged);
            this.RedButCasher.Click += new System.EventHandler(this.RedButCasher_Click);
            // 
            // RedButPaperA4
            // 
            this.RedButPaperA4.AutoSize = true;
            this.RedButPaperA4.Checked = true;
            this.RedButPaperA4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RedButPaperA4.Location = new System.Drawing.Point(56, 24);
            this.RedButPaperA4.Name = "RedButPaperA4";
            this.RedButPaperA4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RedButPaperA4.Size = new System.Drawing.Size(115, 17);
            this.RedButPaperA4.TabIndex = 13;
            this.RedButPaperA4.TabStop = true;
            this.RedButPaperA4.Text = "طباعة على ورق A4";
            this.RedButPaperA4.UseVisualStyleBackColor = true;
            this.RedButPaperA4.CheckedChanged += new System.EventHandler(this.RedButPaperA4_CheckedChanged);
            this.RedButPaperA4.Click += new System.EventHandler(this.RedButPaperA4_Click);
            // 
            // checkBox_previewPrint
            // 
            this.checkBox_previewPrint.AutoSize = true;
            this.checkBox_previewPrint.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.checkBox_previewPrint.ForeColor = System.Drawing.Color.Blue;
            this.checkBox_previewPrint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_previewPrint.Location = new System.Drawing.Point(259, 130);
            this.checkBox_previewPrint.Name = "checkBox_previewPrint";
            this.checkBox_previewPrint.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_previewPrint.Size = new System.Drawing.Size(177, 17);
            this.checkBox_previewPrint.TabIndex = 1019;
            this.checkBox_previewPrint.Text = "تعيين إعدادات الطابعة الإفتراضية ";
            this.checkBox_previewPrint.UseVisualStyleBackColor = true;
            this.checkBox_previewPrint.CheckedChanged += new System.EventHandler(this.checkBox_previewPrint_CheckedChanged);
            // 
            // CmbInvType
            // 
            this.CmbInvType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbInvType.DisplayMember = "Text";
            this.CmbInvType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbInvType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbInvType.FormattingEnabled = true;
            this.CmbInvType.ItemHeight = 14;
            this.CmbInvType.Location = new System.Drawing.Point(252, 60);
            this.CmbInvType.Name = "CmbInvType";
            this.CmbInvType.Size = new System.Drawing.Size(198, 20);
            this.CmbInvType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbInvType.TabIndex = 1;
            this.CmbInvType.SelectedIndexChanged += new System.EventHandler(this.CmbInvType_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.textBox_CachierTxtA);
            this.groupBox1.Controls.Add(this.textBox_CachierTxtE);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.CmbPaperSize);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtpageCount);
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Controls.Add(this.txtDistance);
            this.groupBox1.Controls.Add(this.txtLinePage);
            this.groupBox1.Controls.Add(this.CmbPrinter);
            this.groupBox1.Controls.Add(this.txtTopM);
            this.groupBox1.Controls.Add(this.txtBottM);
            this.groupBox1.Controls.Add(this.txtRight);
            this.groupBox1.Controls.Add(this.txtLeftM);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(15, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 255);
            this.groupBox1.TabIndex = 90;
            this.groupBox1.TabStop = false;
            // 
            // textBox_CachierTxtA
            // 
            this.textBox_CachierTxtA.AutoSelectAll = true;
            this.textBox_CachierTxtA.BackColor = System.Drawing.Color.AliceBlue;
            // 
            // 
            // 
            this.textBox_CachierTxtA.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textBox_CachierTxtA.Border.BorderBottomWidth = 1;
            this.textBox_CachierTxtA.Border.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox_CachierTxtA.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textBox_CachierTxtA.Border.BorderLeftWidth = 1;
            this.textBox_CachierTxtA.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textBox_CachierTxtA.Border.BorderRightWidth = 1;
            this.textBox_CachierTxtA.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textBox_CachierTxtA.Border.BorderTopWidth = 1;
            this.textBox_CachierTxtA.Border.Class = "TextBoxBorder";
            this.textBox_CachierTxtA.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_CachierTxtA.ButtonCustom.Checked = true;
            this.textBox_CachierTxtA.ButtonCustom.Visible = true;
            this.textBox_CachierTxtA.Location = new System.Drawing.Point(173, 176);
            this.textBox_CachierTxtA.Multiline = true;
            this.textBox_CachierTxtA.Name = "textBox_CachierTxtA";
            this.textBox_CachierTxtA.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_CachierTxtA.Size = new System.Drawing.Size(249, 36);
            this.textBox_CachierTxtA.TabIndex = 1021;
            this.textBox_CachierTxtA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_CachierTxtA.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.textBox_CachierTxtA.WatermarkText = "ذيل فاتورة الكاشيير";
            this.textBox_CachierTxtA.ButtonCustomClick += new System.EventHandler(this.textBox_CachierTxtA_ButtonCustomClick);
            // 
            // textBox_CachierTxtE
            // 
            this.textBox_CachierTxtE.AutoSelectAll = true;
            // 
            // 
            // 
            this.textBox_CachierTxtE.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textBox_CachierTxtE.Border.BorderBottomWidth = 1;
            this.textBox_CachierTxtE.Border.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox_CachierTxtE.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textBox_CachierTxtE.Border.BorderLeftWidth = 1;
            this.textBox_CachierTxtE.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textBox_CachierTxtE.Border.BorderRightWidth = 1;
            this.textBox_CachierTxtE.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textBox_CachierTxtE.Border.BorderTopWidth = 1;
            this.textBox_CachierTxtE.Border.Class = "TextBoxBorder";
            this.textBox_CachierTxtE.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_CachierTxtE.ButtonCustom.Checked = true;
            this.textBox_CachierTxtE.ButtonCustom.Visible = true;
            this.textBox_CachierTxtE.Location = new System.Drawing.Point(173, 214);
            this.textBox_CachierTxtE.Multiline = true;
            this.textBox_CachierTxtE.Name = "textBox_CachierTxtE";
            this.textBox_CachierTxtE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_CachierTxtE.Size = new System.Drawing.Size(249, 36);
            this.textBox_CachierTxtE.TabIndex = 1020;
            this.textBox_CachierTxtE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_CachierTxtE.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.textBox_CachierTxtE.WatermarkText = "Tail cashier bill";
            this.textBox_CachierTxtE.ButtonCustomClick += new System.EventHandler(this.textBox_CachierTxtE_ButtonCustomClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.RButLandscape);
            this.groupBox4.Controls.Add(this.RButPortrait);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox4.Location = new System.Drawing.Point(21, 124);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(144, 125);
            this.groupBox4.TabIndex = 1013;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "الإتجـــــاه";
            // 
            // RButLandscape
            // 
            this.RButLandscape.AutoSize = true;
            this.RButLandscape.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.RButLandscape.ForeColor = System.Drawing.Color.SteelBlue;
            this.RButLandscape.Image = ((System.Drawing.Image)(resources.GetObject("RButLandscape.Image")));
            this.RButLandscape.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RButLandscape.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RButLandscape.Location = new System.Drawing.Point(11, 76);
            this.RButLandscape.Name = "RButLandscape";
            this.RButLandscape.Size = new System.Drawing.Size(118, 40);
            this.RButLandscape.TabIndex = 1008;
            this.RButLandscape.Text = "عرضي                   ";
            this.RButLandscape.UseVisualStyleBackColor = true;
            // 
            // RButPortrait
            // 
            this.RButPortrait.AutoSize = true;
            this.RButPortrait.Checked = true;
            this.RButPortrait.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.RButPortrait.ForeColor = System.Drawing.Color.SteelBlue;
            this.RButPortrait.Image = ((System.Drawing.Image)(resources.GetObject("RButPortrait.Image")));
            this.RButPortrait.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RButPortrait.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RButPortrait.Location = new System.Drawing.Point(12, 29);
            this.RButPortrait.Name = "RButPortrait";
            this.RButPortrait.Size = new System.Drawing.Size(117, 40);
            this.RButPortrait.TabIndex = 1007;
            this.RButPortrait.TabStop = true;
            this.RButPortrait.Text = "طولي                    ";
            this.RButPortrait.UseVisualStyleBackColor = true;
            // 
            // CmbPaperSize
            // 
            this.CmbPaperSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbPaperSize.DisplayMember = "Text";
            this.CmbPaperSize.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbPaperSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPaperSize.FormattingEnabled = true;
            this.CmbPaperSize.ItemHeight = 14;
            this.CmbPaperSize.Location = new System.Drawing.Point(173, 152);
            this.CmbPaperSize.Name = "CmbPaperSize";
            this.CmbPaperSize.Size = new System.Drawing.Size(152, 20);
            this.CmbPaperSize.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbPaperSize.TabIndex = 1011;
            this.CmbPaperSize.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CmbPaperSize_MouseClick);
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(329, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 21);
            this.label9.TabIndex = 1012;
            this.label9.Text = "حجم الورقة :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtpageCount
            // 
            this.txtpageCount.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtpageCount.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtpageCount.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtpageCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtpageCount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtpageCount.DisplayFormat = "0";
            this.txtpageCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtpageCount.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtpageCount.Location = new System.Drawing.Point(237, 128);
            this.txtpageCount.MinValue = 1;
            this.txtpageCount.Name = "txtpageCount";
            this.txtpageCount.ShowUpDown = true;
            this.txtpageCount.Size = new System.Drawing.Size(68, 21);
            this.txtpageCount.TabIndex = 1001;
            this.txtpageCount.Value = 1;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label33.ForeColor = System.Drawing.Color.Blue;
            this.label33.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label33.Location = new System.Drawing.Point(308, 132);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(69, 13);
            this.label33.TabIndex = 1000;
            this.label33.Text = "عدد النسخ :";
            // 
            // txtDistance
            // 
            this.txtDistance.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtDistance.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtDistance.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDistance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDistance.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtDistance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtDistance.Increment = 1D;
            this.txtDistance.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtDistance.Location = new System.Drawing.Point(21, 104);
            this.txtDistance.MinValue = 0D;
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.ShowUpDown = true;
            this.txtDistance.Size = new System.Drawing.Size(68, 20);
            this.txtDistance.TabIndex = 10;
            // 
            // txtLinePage
            // 
            this.txtLinePage.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtLinePage.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.txtLinePage.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtLinePage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLinePage.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtLinePage.DisplayFormat = "0";
            this.txtLinePage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtLinePage.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtLinePage.Location = new System.Drawing.Point(236, 104);
            this.txtLinePage.LockUpdateChecked = false;
            this.txtLinePage.MinValue = 0;
            this.txtLinePage.Name = "txtLinePage";
            this.txtLinePage.ShowCheckBox = true;
            this.txtLinePage.ShowUpDown = true;
            this.txtLinePage.Size = new System.Drawing.Size(68, 21);
            this.txtLinePage.TabIndex = 9;
            this.txtLinePage.ValueChanged += new System.EventHandler(this.txtLinePage_ValueChanged);
            this.txtLinePage.LockUpdateChanged += new System.EventHandler(this.txtLinePage_LockUpdateChanged);
            // 
            // CmbPrinter
            // 
            this.CmbPrinter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbPrinter.DisplayMember = "Text";
            this.CmbPrinter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPrinter.FormattingEnabled = true;
            this.CmbPrinter.ItemHeight = 14;
            this.CmbPrinter.Location = new System.Drawing.Point(21, 26);
            this.CmbPrinter.Name = "CmbPrinter";
            this.CmbPrinter.Size = new System.Drawing.Size(283, 20);
            this.CmbPrinter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbPrinter.TabIndex = 3;
            this.CmbPrinter.SelectedIndexChanged += new System.EventHandler(this.CmbPrinter_SelectedIndexChanged);
            // 
            // txtTopM
            // 
            this.txtTopM.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtTopM.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtTopM.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTopM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTopM.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTopM.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtTopM.Increment = 1D;
            this.txtTopM.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTopM.Location = new System.Drawing.Point(236, 58);
            this.txtTopM.Name = "txtTopM";
            this.txtTopM.ShowUpDown = true;
            this.txtTopM.Size = new System.Drawing.Size(68, 20);
            this.txtTopM.TabIndex = 5;
            // 
            // txtBottM
            // 
            this.txtBottM.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtBottM.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtBottM.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtBottM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBottM.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtBottM.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtBottM.Increment = 1D;
            this.txtBottM.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtBottM.Location = new System.Drawing.Point(236, 81);
            this.txtBottM.Name = "txtBottM";
            this.txtBottM.ShowUpDown = true;
            this.txtBottM.Size = new System.Drawing.Size(68, 20);
            this.txtBottM.TabIndex = 7;
            // 
            // txtRight
            // 
            this.txtRight.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtRight.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtRight.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtRight.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRight.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtRight.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtRight.Increment = 1D;
            this.txtRight.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtRight.Location = new System.Drawing.Point(21, 81);
            this.txtRight.Name = "txtRight";
            this.txtRight.ShowUpDown = true;
            this.txtRight.Size = new System.Drawing.Size(68, 20);
            this.txtRight.TabIndex = 6;
            // 
            // txtLeftM
            // 
            this.txtLeftM.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtLeftM.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtLeftM.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtLeftM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLeftM.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtLeftM.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtLeftM.Increment = 1D;
            this.txtLeftM.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtLeftM.Location = new System.Drawing.Point(21, 58);
            this.txtLeftM.Name = "txtLeftM";
            this.txtLeftM.ShowUpDown = true;
            this.txtLeftM.Size = new System.Drawing.Size(68, 20);
            this.txtLeftM.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(95, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "المسافة بين السطور :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(95, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "الهامش الأيسر :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(308, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "الهامش الأسفل :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(95, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "الهامش الأيمن :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(308, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "الهامش الأعلى :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(308, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "السطور في الصفحة :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(308, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 48;
            this.label7.Text = "الطابعة الإفتراضية :";
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.DimGray;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX1.Font = new System.Drawing.Font("Tahoma", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labelX1.ForeColor = System.Drawing.Color.White;
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(464, 26);
            this.labelX1.TabIndex = 88;
            this.labelX1.Text = "اعدادات طباعة الفواتير";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // picture_SSS
            // 
            this.picture_SSS.BackColor = System.Drawing.Color.Transparent;
            this.picture_SSS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_SSS.Image = global::InvAcc.Properties.Resources.Untitled_2_copy;
            this.picture_SSS.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picture_SSS.Location = new System.Drawing.Point(14, 43);
            this.picture_SSS.Name = "picture_SSS";
            this.picture_SSS.Size = new System.Drawing.Size(208, 84);
            this.picture_SSS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_SSS.TabIndex = 1020;
            this.picture_SSS.TabStop = false;
            this.picture_SSS.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox3.Controls.Add(this.ButWithoutSave);
            this.groupBox3.Controls.Add(this.ButWithSave);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 407);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(466, 54);
            this.groupBox3.TabIndex = 984;
            this.groupBox3.TabStop = false;
            // 
            // ButWithoutSave
            // 
            this.ButWithoutSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButWithoutSave.Checked = true;
            this.ButWithoutSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ButWithoutSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButWithoutSave.Location = new System.Drawing.Point(10, 14);
            this.ButWithoutSave.Name = "ButWithoutSave";
            this.ButWithoutSave.Size = new System.Drawing.Size(221, 35);
            this.ButWithoutSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButWithoutSave.Symbol = "";
            this.ButWithoutSave.SymbolSize = 12F;
            this.ButWithoutSave.TabIndex = 12;
            this.ButWithoutSave.Text = "خــــروج";
            this.ButWithoutSave.TextColor = System.Drawing.Color.Black;
            this.ButWithoutSave.Click += new System.EventHandler(this.ButWithoutSave_Click);
            // 
            // ButWithSave
            // 
            this.ButWithSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButWithSave.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.ButWithSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButWithSave.Location = new System.Drawing.Point(238, 14);
            this.ButWithSave.Name = "ButWithSave";
            this.ButWithSave.Size = new System.Drawing.Size(221, 35);
            this.ButWithSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButWithSave.Symbol = "";
            this.ButWithSave.SymbolSize = 12F;
            this.ButWithSave.TabIndex = 11;
            this.ButWithSave.Text = "حفــــظ";
            this.ButWithSave.TextColor = System.Drawing.Color.White;
            this.ButWithSave.Click += new System.EventHandler(this.ButWithSave_Click);
            // 
            // FMInvPrintSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 461);
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FMInvPrintSetup";
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FMInvPrintSetup_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.ribbonBar1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox_PrintType.ResumeLayout(false);
            this.groupBox_PrintType.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtpageCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLinePage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTopM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBottM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeftM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_SSS)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.ResumeLayout(false);
        }
        public FMInvPrintSetup(int _typ)
        {
            InitializeComponent();
            _SettingType = _typ;
            txtBottM.Click += Button_Edit_Click;
            txtDistance.Click += Button_Edit_Click;
            txtLeftM.Click += Button_Edit_Click;
            txtLinePage.Click += Button_Edit_Click;
            txtpageCount.Click += Button_Edit_Click;
            txtRight.Click += Button_Edit_Click;
            txtTopM.Click += Button_Edit_Click;
            chk_Stoped.Click += Button_Edit_Click;
            checkBox_WaiterAll.Click += Button_Edit_Click;
            txtDistance.Click += Button_Edit_Click;
            textBox_CachierTxtA.Click += Button_Edit_Click;
            textBox_CachierTxtE.Click += Button_Edit_Click;
            checkBox_previewPrint.Click += Button_Edit_Click;
            RButLandscape.Click += Button_Edit_Click;
            RButPortrait.Click += Button_Edit_Click;
            CmbInvType.Click += Button_Edit_Click;
            CmbPaperSize.Click += Button_Edit_Click;
            CmbPrinter.Click += Button_Edit_Click;
            listInvSetting = db.StockInvSettingList(VarGeneral.UserID);
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptInvitationCards.dll"))
            {
                listInvSetting = db.T_INVSETTINGs.Where((T_INVSETTING t) => t.InvID == 1 || t.InvID == 8).ToList();
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptSchool.dll"))
            {
                listInvSetting = db.T_INVSETTINGs.Where((T_INVSETTING t) => t.InvID == 1 || t.InvID == 2 || t.InvID == 3 || t.InvID == 4 || t.InvID == 7 || t.InvID == 8 || t.InvID == 9 || t.InvID == 10 || t.InvID == 14).ToList();
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptMaintenanceCars.dll"))
            {
                listInvSetting = db.T_INVSETTINGs.Where((T_INVSETTING t) => t.InvID == 1 || t.InvID == 2 || t.InvID == 3 || t.InvID == 4 || t.InvID == 7).ToList();
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptTegnicalCollage.dll"))
            {
                listInvSetting = db.T_INVSETTINGs.Where((T_INVSETTING t) => t.InvID == 2 || t.InvID == 4 || t.InvID == 9 || t.InvID == 10 || t.InvID == 14 || t.InvID == 17 || t.InvID == 20).ToList();
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptWaterPackages.dll"))
            {
                listInvSetting = db.T_INVSETTINGs.Where((T_INVSETTING t) => t.InvID == 1 || t.InvID == 2 || t.InvID == 3 || t.InvID == 4 || t.InvID == 5 || t.InvID == 6 || t.InvID == 7 || t.InvID == 8 || t.InvID == 9 || t.InvID == 10 || t.InvID == 14).ToList();
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FMInvPrintSetup));
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
                chk_Stoped.OnText = ((LangArEn == 0) ? "طابعات التصنيفات فقط" : "Catogaries Printers Only");
                chk_Stoped.OffText = ((LangArEn == 0) ? "طابعة الكاشيير فقط" : "Cashier Printer Only");
                FillCombo();
                BindData();
                if (VarGeneral.vDemo && VarGeneral.UserID != 1)
                {
                    checkBox_previewPrint.Visible = false;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("OnLoad:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FMInvPrintSetup));
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
            FillCombo();
            BindData();
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ButWithSave.Text = "حفــــظ F2";
                ButWithoutSave.Text = "خــــروج Esc";
                labelX1.Text = ((_SettingType == 0) ? "إعدادات طباعة الفواتير" : "إعدادات طباعة التصنيفــات");
            }
            else
            {
                ButWithSave.Text = "Save F2";
                ButWithoutSave.Text = "Exit Esc";
                labelX1.Text = ((_SettingType == 0) ? "Invoice Printer Setting" : "Categories Printer Setting");
            }
        }
        private void BindData()
        {
            try
            {
                State = FormState.Saved;
                ButWithSave.Enabled = false;
                _item = (Item)CmbInvType.SelectedItem;
                for (int iiCnt = 0; iiCnt < listInvSetting.Count; iiCnt++)
                {
                    _InvSetting = listInvSetting[iiCnt];
                    if (_item.Value != _InvSetting.InvID)
                    {
                        continue;
                    }
                    chk_Stoped.Value = false;
                    checkBox_WaiterAll.Checked = false;
                    if (_InvSetting.InvpRINTERInfo.nTyp.Substring(0, 1) == "0")
                    {
                        ChkPTable.Checked = false;
                    }
                    else
                    {
                        ChkPTable.Checked = true;
                    }
                    if (_InvSetting.InvpRINTERInfo.nTyp.Substring(1, 1) == "0")
                    {
                        RedButPaperA4.Checked = false;
                        RedButCasher.Checked = true;
                    }
                    else
                    {
                        RedButPaperA4.Checked = true;
                        RedButCasher.Checked = false;
                    }
                    if (_InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1) == "0")
                    {
                        checkBox_previewPrint.Checked = false;
                    }
                    else
                    {
                        checkBox_previewPrint.Checked = true;
                    }
                    txtBottM.Text = _InvSetting.InvpRINTERInfo.hAs.ToString();
                    txtLeftM.Text = _InvSetting.InvpRINTERInfo.hYs.ToString();
                    txtLinePage.Value = (int)_InvSetting.InvpRINTERInfo.lnPg.Value;
                    if (txtLinePage.Value <= 0)
                    {
                        txtLinePage.LockUpdateChecked = false;
                    }
                    else
                    {
                        txtLinePage.LockUpdateChecked = true;
                    }
                    txtRight.Text = _InvSetting.InvpRINTERInfo.hYm.ToString();
                    txtTopM.Text = _InvSetting.InvpRINTERInfo.hAl.ToString();
                    txtDistance.Text = _InvSetting.InvpRINTERInfo.lnSpc.ToString();
                    textBox_CachierTxtA.Text = _InvSetting.invGdADesc;
                    textBox_CachierTxtE.Text = _InvSetting.invGdEDesc;
                    CmbPrinter.Text = _InvSetting.defPrn;
                    txtpageCount.Value = _InvSetting.InvpRINTERInfo.DefLines.Value;
                    try
                    {
                        chk_Stoped.Value = _InvSetting.PrintCat.Value;
                    }
                    catch
                    {
                        chk_Stoped.Value = true;
                    }
                    if (!string.IsNullOrEmpty(_InvSetting.defSizePaper))
                    {
                        CmbPaperSize.Items.Clear();
                        CmbPaperSize.Items.Add(_InvSetting.defSizePaper);
                        CmbPaperSize.SelectedIndex = 0;
                    }
                    else
                    {
                        CmbPaperSize.Items.Clear();
                    }
                    if (_InvSetting.Orientation.Value == 1)
                    {
                        RButPortrait.Checked = true;
                    }
                    else
                    {
                        RButLandscape.Checked = true;
                    }
                    if (_InvSetting.InvID == 21)
                    {
                        ChkPTable.Visible = false;
                        chk_Stoped.Visible = true;
                        checkBox_WaiterAll.Visible = true;
                        try
                        {
                            if (checkBox_WaiterAll.Visible)
                            {
                                checkBox_WaiterAll.Checked = _InvSetting.autoCommGaid.Value;
                            }
                            else
                            {
                                checkBox_WaiterAll.Checked = false;
                            }
                        }
                        catch
                        {
                            checkBox_WaiterAll.Checked = false;
                        }
                    }
                    else
                    {
                        ChkPTable.Visible = true;
                        chk_Stoped.Visible = false;
                        checkBox_WaiterAll.Visible = false;
                    }
                    break;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("BindData:", error, enable: true);
            }
            if (_SettingType == 1)
            {
                ChkPTable.Visible = false;
                label8.Text = ((LangArEn == 0) ? "التصنيفات :" : "Categories :");
                chk_Stoped.OnText = ((LangArEn == 0) ? "إيقاف الطباعة" : "Printing Stoped");
                chk_Stoped.OffText = ((LangArEn == 0) ? "إيقاف الطباعة" : "Printing Stoped");
                checkBox_previewPrint.Visible = false;
                chk_Stoped.Visible = true;
                if (db.StockInvSetting(VarGeneral.UserID, 1).nTyp.Substring(2, 1) == "1")
                {
                    groupBox_PrintType.Visible = false;
                    picture_SSS.Visible = true;
                }
            }
        }
        private void FillCombo()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                CmbPrinter.Items.Clear();
                CmbPrinter.Items.Add(" ");
                PrinterSettings PrintS = new PrinterSettings();
                if (PrinterSettings.InstalledPrinters.Count != 0)
                {
                    for (int iiCnt = 0; iiCnt < PrinterSettings.InstalledPrinters.Count; iiCnt++)
                    {
                        CmbPrinter.Items.Add(PrinterSettings.InstalledPrinters[iiCnt]);
                    }
                    if (!string.IsNullOrEmpty(VarGeneral.PrintNam))
                    {
                        CmbPrinter.Text = VarGeneral.PrintNam;
                    }
                    else
                    {
                        CmbPrinter.Text = PrintS.DefaultPageSettings.PrinterSettings.PrinterName;
                    }
                }
                CmbInvType.Items.Clear();
                for (int iiCnt = 0; iiCnt < listInvSetting.Count; iiCnt++)
                {
                    _InvSetting = listInvSetting[iiCnt];

                    if (_InvSetting.InvID != VarGeneral.DraftBillId)
                    {
                        try
                        {
                            if (VarGeneral.SSSLev == "R" || VarGeneral.SSSLev == "C" || VarGeneral.SSSLev == "H")
                            {
                                if (_InvSetting.InvSetting != "1" && (int.Parse(_InvSetting.InvSetting.ToString()) < 400 || int.Parse(_InvSetting.InvSetting.ToString()) == 910) && _InvSetting.InvID != 22 && ((_SettingType == 0) ? (!_InvSetting.CatID.HasValue) : _InvSetting.CatID.HasValue))
                                {
                                    CmbInvType.Items.Add(new Item(_InvSetting.InvNamA.Trim(), int.Parse(_InvSetting.InvID.ToString())));
                                }
                            }
                            else if (_InvSetting.InvSetting != "1" && int.Parse(_InvSetting.InvSetting.ToString()) < 400 && _InvSetting.InvID != 22 && ((_SettingType == 0) ? (!_InvSetting.CatID.HasValue) : _InvSetting.CatID.HasValue))
                            {
                                CmbInvType.Items.Add(new Item(_InvSetting.InvNamA.Trim(), int.Parse(_InvSetting.InvID.ToString())));
                            }
                        }
                        catch { }
                    }
                }
                CmbInvType.SelectedIndex = 0;
            }
            else
            {
                CmbPrinter.Items.Clear();
                CmbPrinter.Items.Add(" ");
                PrinterSettings PrintS = new PrinterSettings();
                if (PrinterSettings.InstalledPrinters.Count != 0)
                {
                    for (int iiCnt = 0; iiCnt < PrinterSettings.InstalledPrinters.Count; iiCnt++)
                    {
                        CmbPrinter.Items.Add(PrinterSettings.InstalledPrinters[iiCnt]);
                    }
                    if (!string.IsNullOrEmpty(VarGeneral.PrintNam))
                    {
                        CmbPrinter.Text = VarGeneral.PrintNam;
                    }
                    else
                    {
                        CmbPrinter.Text = PrintS.DefaultPageSettings.PrinterSettings.PrinterName;
                    }
                }
                CmbInvType.Items.Clear();
                for (int iiCnt = 0; iiCnt < listInvSetting.Count; iiCnt++)
                {
                    _InvSetting = listInvSetting[iiCnt];
                    if (_InvSetting.InvID != VarGeneral.DraftBillId)
                    {
                        if (_InvSetting.InvSetting != "1" && int.Parse(_InvSetting.InvSetting.ToString()) < 400 && _InvSetting.InvID != 22 && ((_SettingType == 0) ? (!_InvSetting.CatID.HasValue) : _InvSetting.CatID.HasValue))
                        {
                            CmbInvType.Items.Add(new Item(_InvSetting.InvNamE.Trim(), int.Parse(_InvSetting.InvID.ToString())));
                        }
                    }
                }
                CmbInvType.SelectedIndex = 0;
            }
            RibunButtons();
        }
        private bool SaveData()
        {
            try
            {
                string ntyp = "";
                ntyp = (ChkPTable.Checked ? "1" : "0");
                ntyp = (RedButPaperA4.Checked ? (ntyp + "1") : (ntyp + "0"));
                ntyp = (checkBox_previewPrint.Checked ? (ntyp + "1") : (ntyp + "0"));
                _InvSetting.InvpRINTERInfo.nTyp = ntyp;
                _InvSetting.InvpRINTERInfo.hAs = double.Parse(VarGeneral.TString.TEmpty(txtBottM.Text ?? ""));
                _InvSetting.InvpRINTERInfo.hYs = double.Parse(VarGeneral.TString.TEmpty(txtLeftM.Text ?? ""));
                _InvSetting.InvpRINTERInfo.lnPg = double.Parse(VarGeneral.TString.TEmpty(txtLinePage.Text ?? ""));
                _InvSetting.InvpRINTERInfo.hYm = double.Parse(VarGeneral.TString.TEmpty(txtRight.Text ?? ""));
                _InvSetting.InvpRINTERInfo.hAl = double.Parse(VarGeneral.TString.TEmpty(txtTopM.Text ?? ""));
                _InvSetting.InvpRINTERInfo.lnSpc = double.Parse(VarGeneral.TString.TEmpty(txtDistance.Text ?? ""));
                _InvSetting.invGdADesc = textBox_CachierTxtA.Text;
                _InvSetting.invGdEDesc = textBox_CachierTxtE.Text;
                _InvSetting.defPrn = CmbPrinter.Text ?? "";
                _InvSetting.InvpRINTERInfo.DefLines = txtpageCount.Value;
                _InvSetting.PrintCat = chk_Stoped.Value;
                if (RButPortrait.Checked)
                {
                    _InvSetting.Orientation = 1;
                }
                else
                {
                    _InvSetting.Orientation = 2;
                }
                try
                {
                    if (checkBox_WaiterAll.Visible && _InvSetting.InvID == 21)
                    {
                        _InvSetting.autoCommGaid = checkBox_WaiterAll.Checked;
                    }
                }
                catch
                {
                }
                if (CmbPaperSize.Items.Count > 0)
                {
                    if (!string.IsNullOrEmpty(CmbPrinter.Text))
                    {
                        if (CmbPaperSize.SelectedIndex > 0)
                        {
                            _InvSetting.defSizePaper = CmbPaperSize.Text;
                        }
                        else
                        {
                            _InvSetting.defSizePaper = "";
                        }
                    }
                    else
                    {
                        _InvSetting.defSizePaper = "";
                    }
                }
                else
                {
                    _InvSetting.defSizePaper = "";
                }
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SaveData:", error, enable: true);
                MessageBox.Show(error.Message);
                return false;
            }
            return true;
        }
        private void FlxFiles_AfterEdit(object sender, RowColEventArgs e)
        {
        }
        private void CmbInvType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }
        private void FMInvPrintSetup_Load(object sender, EventArgs e)
        {
        }
        private void Frm_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && ButWithSave.Enabled && ButWithSave.Visible && State != 0)
            {
                ButWithSave_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void ButWithSave_Click(object sender, EventArgs e)
        {
            bool SaveStat = SaveData();
        }
        private void ButWithoutSave_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void checkBox_previewPrint_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_previewPrint.Checked)
            {
                groupBox1.Enabled = false;
            }
            else
            {
                groupBox1.Enabled = true;
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
        private void CmbPaperSize_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (State == FormState.Saved || string.IsNullOrEmpty(CmbPrinter.Text))
                {
                    return;
                }
                CmbPaperSize.Items.Clear();
                CmbPaperSize.Items.Add((LangArEn == 0) ? "الإفتراضي" : "Default");
                PrintDocument pd = new PrintDocument();
                pd.PrinterSettings.PrinterName = CmbPrinter.Text;
                foreach (PaperSize item in pd.PrinterSettings.PaperSizes)
                {
                    CmbPaperSize.Items.Add(item.PaperName);
                }
            }
            catch
            {
                CmbPaperSize.Items.Clear();
            }
        }
        private void CmbPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                CmbPaperSize.Items.Clear();
            }
        }
        private void ChkPTable_CheckedChanged(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            if (!ChkPTable.Checked)
            {
                CmbPaperSize.Items.Clear();
                CmbPaperSize.Enabled = false;
            }
            else
            {
                CmbPaperSize.Items.Clear();
                CmbPaperSize.Enabled = true;
            }
        }
        private void textBox_CachierTxtA_ButtonCustomClick(object sender, EventArgs e)
        {
            textBox_CachierTxtA.Text = "";
        }
        private void textBox_CachierTxtE_ButtonCustomClick(object sender, EventArgs e)
        {
            textBox_CachierTxtE.Text = "";
        }
        private void RedButPaperA4_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }
        private void RedButCasher_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }
        private void txtLinePage_LockUpdateChanged(object sender, EventArgs e)
        {
            if (State != 0)
            {
                if (txtLinePage.LockUpdateChecked)
                {
                    txtLinePage.Value = 1;
                }
                else
                {
                    txtLinePage.Value = 0;
                }
            }
        }
        private void txtLinePage_ValueChanged(object sender, EventArgs e)
        {
            if (txtLinePage.Value == 0)
            {
                txtLinePage.LockUpdateChecked = false;
            }
        }
        private void RedButPaperA4_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void RedButCasher_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void checkBox_WaiterAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_WaiterAll.Checked)
            {
                chk_Stoped.Enabled = false;
            }
            else
            {
                chk_Stoped.Enabled = true;
            }
        }
    }
}
