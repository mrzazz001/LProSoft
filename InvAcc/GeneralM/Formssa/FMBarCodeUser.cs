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
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FMBarCodeUser : Form
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
        private ComboBox CmbPrintP2;
        private Button button1;
        private ComboBox CmbPrintP;
        private ComboBox CmbDir;
        private RibbonBar ribbonBar1;
        private C1FlexGrid FlxFiles;
        private GroupBox groupBox1;
        private IntegerInput txtBarWidth;
        private IntegerInput txtBarHeigth;
        private Label label7;
        private Label label5;
        private Label label1;
        private Label label4;
        private Label label6;
        private Label label2;
        private GroupBox groupBox2;
        private ButtonX ButWithoutSave;
        private ButtonX ButWithSave;
        private DoubleInput txtWidth;
        private DoubleInput txtHeight;
        private DoubleInput txtLeftM;
        private DoubleInput txtTopM;
        private GroupBox groupBox3;
        private DoubleInput txtNumRows;
        private DoubleInput txtNumCols;
        private Label label9;
        private Label label8;
        private ComboBoxEx CmbPrinter;
        private LabelX labelX1;
        private Label label10;
        private IntegerInput txtpageCount;
        private Label label33;
        private ComboBox CmbUnit;
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private List<T_mInvPrint> listmInvPrint = new List<T_mInvPrint>();
        private T_mInvPrint _mInvPrint = new T_mInvPrint();
        private Item _item = new Item("", 0);
        private int ItemIndex = 0;
        private int LangArEn = 0;
        private Stock_DataDataContext dbInstance;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMBarCodeUser));
            this.CmbPrintP2 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.CmbPrintP = new System.Windows.Forms.ComboBox();
            this.CmbDir = new System.Windows.Forms.ComboBox();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.CmbUnit = new System.Windows.Forms.ComboBox();
            this.FlxFiles = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLeftM = new DevComponents.Editors.DoubleInput();
            this.txtTopM = new DevComponents.Editors.DoubleInput();
            this.CmbPrinter = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtWidth = new DevComponents.Editors.DoubleInput();
            this.txtHeight = new DevComponents.Editors.DoubleInput();
            this.txtBarWidth = new DevComponents.Editors.IntegerInput();
            this.txtBarHeigth = new DevComponents.Editors.IntegerInput();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtpageCount = new DevComponents.Editors.IntegerInput();
            this.label33 = new System.Windows.Forms.Label();
            this.txtNumRows = new DevComponents.Editors.DoubleInput();
            this.txtNumCols = new DevComponents.Editors.DoubleInput();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ButWithoutSave = new DevComponents.DotNetBar.ButtonX();
            this.ButWithSave = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.ribbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlxFiles)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeftM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTopM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarHeigth)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtpageCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumCols)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CmbPrintP2
            // 
            this.CmbPrintP2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPrintP2.FormattingEnabled = true;
            this.CmbPrintP2.Location = new System.Drawing.Point(132, 486);
            this.CmbPrintP2.Name = "CmbPrintP2";
            this.CmbPrintP2.Size = new System.Drawing.Size(140, 21);
            this.CmbPrintP2.TabIndex = 33;
            // 
            // button1
            // 
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(610, 384);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 25);
            this.button1.TabIndex = 34;
            this.button1.Text = "شكل توضيح";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CmbPrintP
            // 
            this.CmbPrintP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPrintP.FormattingEnabled = true;
            this.CmbPrintP.Location = new System.Drawing.Point(297, 484);
            this.CmbPrintP.Name = "CmbPrintP";
            this.CmbPrintP.Size = new System.Drawing.Size(140, 21);
            this.CmbPrintP.TabIndex = 32;
            // 
            // CmbDir
            // 
            this.CmbDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDir.FormattingEnabled = true;
            this.CmbDir.Location = new System.Drawing.Point(448, 486);
            this.CmbDir.Name = "CmbDir";
            this.CmbDir.Size = new System.Drawing.Size(140, 21);
            this.CmbDir.TabIndex = 31;
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
            this.ribbonBar1.Controls.Add(this.CmbUnit);
            this.ribbonBar1.Controls.Add(this.FlxFiles);
            this.ribbonBar1.Controls.Add(this.groupBox1);
            this.ribbonBar1.Controls.Add(this.groupBox3);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(594, 549);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 980;
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
            // CmbUnit
            // 
            this.CmbUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.CmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbUnit.FormattingEnabled = true;
            this.CmbUnit.Items.AddRange(new object[] {
            "mm",
            "doc",
            "in",
            "point",
            "pixel"});
            this.CmbUnit.Location = new System.Drawing.Point(7, 172);
            this.CmbUnit.Name = "CmbUnit";
            this.CmbUnit.Size = new System.Drawing.Size(97, 21);
            this.CmbUnit.TabIndex = 991;
            // 
            // FlxFiles
            // 
            this.FlxFiles.ColumnInfo = resources.GetString("FlxFiles.ColumnInfo");
            this.FlxFiles.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FlxFiles.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.FlxFiles.Location = new System.Drawing.Point(7, 32);
            this.FlxFiles.Name = "FlxFiles";
            this.FlxFiles.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FlxFiles.Rows.Count = 20;
            this.FlxFiles.Rows.DefaultSize = 19;
            this.FlxFiles.Size = new System.Drawing.Size(581, 134);
            this.FlxFiles.StyleInfo = resources.GetString("FlxFiles.StyleInfo");
            this.FlxFiles.TabIndex = 11;
            this.FlxFiles.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System;
            this.FlxFiles.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.FlxFiles_AfterEdit);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtLeftM);
            this.groupBox1.Controls.Add(this.txtTopM);
            this.groupBox1.Controls.Add(this.CmbPrinter);
            this.groupBox1.Controls.Add(this.txtWidth);
            this.groupBox1.Controls.Add(this.txtHeight);
            this.groupBox1.Controls.Add(this.txtBarWidth);
            this.groupBox1.Controls.Add(this.txtBarHeigth);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(644, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(581, 110);
            this.groupBox1.TabIndex = 983;
            this.groupBox1.TabStop = false;
            // 
            // txtLeftM
            // 
            this.txtLeftM.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtLeftM.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtLeftM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLeftM.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtLeftM.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtLeftM.Increment = 1D;
            this.txtLeftM.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtLeftM.Location = new System.Drawing.Point(20, 16);
            this.txtLeftM.MinValue = 0D;
            this.txtLeftM.Name = "txtLeftM";
            this.txtLeftM.Size = new System.Drawing.Size(47, 20);
            this.txtLeftM.TabIndex = 3;
            // 
            // txtTopM
            // 
            this.txtTopM.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtTopM.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTopM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTopM.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTopM.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtTopM.Increment = 1D;
            this.txtTopM.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTopM.Location = new System.Drawing.Point(153, 16);
            this.txtTopM.MinValue = 0D;
            this.txtTopM.Name = "txtTopM";
            this.txtTopM.Size = new System.Drawing.Size(47, 20);
            this.txtTopM.TabIndex = 2;
            // 
            // CmbPrinter
            // 
            this.CmbPrinter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbPrinter.DisplayMember = "Text";
            this.CmbPrinter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPrinter.FormattingEnabled = true;
            this.CmbPrinter.ItemHeight = 14;
            this.CmbPrinter.Location = new System.Drawing.Point(291, 16);
            this.CmbPrinter.Name = "CmbPrinter";
            this.CmbPrinter.Size = new System.Drawing.Size(207, 20);
            this.CmbPrinter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbPrinter.TabIndex = 1;
            // 
            // txtWidth
            // 
            this.txtWidth.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtWidth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtWidth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtWidth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtWidth.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtWidth.Increment = 1D;
            this.txtWidth.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtWidth.Location = new System.Drawing.Point(310, 84);
            this.txtWidth.MinValue = 0D;
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.ShowUpDown = true;
            this.txtWidth.Size = new System.Drawing.Size(85, 20);
            this.txtWidth.TabIndex = 6;
            // 
            // txtHeight
            // 
            this.txtHeight.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtHeight.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtHeight.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtHeight.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtHeight.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtHeight.Increment = 1D;
            this.txtHeight.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtHeight.Location = new System.Drawing.Point(52, 81);
            this.txtHeight.MinValue = 0D;
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.ShowUpDown = true;
            this.txtHeight.Size = new System.Drawing.Size(85, 20);
            this.txtHeight.TabIndex = 7;
            this.txtHeight.Value = 2D;
            // 
            // txtBarWidth
            // 
            this.txtBarWidth.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtBarWidth.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.txtBarWidth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtBarWidth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBarWidth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtBarWidth.DisplayFormat = "0";
            this.txtBarWidth.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtBarWidth.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtBarWidth.Location = new System.Drawing.Point(327, 51);
            this.txtBarWidth.MinValue = 0;
            this.txtBarWidth.Name = "txtBarWidth";
            this.txtBarWidth.ShowUpDown = true;
            this.txtBarWidth.Size = new System.Drawing.Size(68, 21);
            this.txtBarWidth.TabIndex = 4;
            this.txtBarWidth.Value = 1;
            // 
            // txtBarHeigth
            // 
            this.txtBarHeigth.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtBarHeigth.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.txtBarHeigth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtBarHeigth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBarHeigth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtBarHeigth.DisplayFormat = "0";
            this.txtBarHeigth.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtBarHeigth.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtBarHeigth.Location = new System.Drawing.Point(69, 51);
            this.txtBarHeigth.MinValue = 0;
            this.txtBarHeigth.Name = "txtBarHeigth";
            this.txtBarHeigth.ShowUpDown = true;
            this.txtBarHeigth.Size = new System.Drawing.Size(68, 21);
            this.txtBarHeigth.TabIndex = 5;
            this.txtBarHeigth.Value = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(143, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "الإرتفاع بين كروت الباركود :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(68, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "هامش يسار :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(143, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "الإرتفـــاع :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(401, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "العـــرض :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(401, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "البعد العرضي بين كروت الباركود :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(498, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "اختيار الطابعة :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(201, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "هامش اعلى :";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.txtpageCount);
            this.groupBox3.Controls.Add(this.label33);
            this.groupBox3.Controls.Add(this.txtNumRows);
            this.groupBox3.Controls.Add(this.txtNumCols);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(797, 270);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(581, 52);
            this.groupBox3.TabIndex = 990;
            this.groupBox3.TabStop = false;
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
            this.txtpageCount.Location = new System.Drawing.Point(96, 20);
            this.txtpageCount.MinValue = 1;
            this.txtpageCount.Name = "txtpageCount";
            this.txtpageCount.ShowUpDown = true;
            this.txtpageCount.Size = new System.Drawing.Size(62, 21);
            this.txtpageCount.TabIndex = 1001;
            this.txtpageCount.Value = 1;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label33.ForeColor = System.Drawing.Color.Blue;
            this.label33.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label33.Location = new System.Drawing.Point(159, 24);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(69, 13);
            this.label33.TabIndex = 1000;
            this.label33.Text = "عدد النسخ :";
            // 
            // txtNumRows
            // 
            this.txtNumRows.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtNumRows.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtNumRows.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtNumRows.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNumRows.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtNumRows.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtNumRows.Increment = 1D;
            this.txtNumRows.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtNumRows.Location = new System.Drawing.Point(419, 20);
            this.txtNumRows.MinValue = 0D;
            this.txtNumRows.Name = "txtNumRows";
            this.txtNumRows.ShowUpDown = true;
            this.txtNumRows.Size = new System.Drawing.Size(62, 20);
            this.txtNumRows.TabIndex = 8;
            this.txtNumRows.Value = 1D;
            // 
            // txtNumCols
            // 
            this.txtNumCols.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtNumCols.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtNumCols.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtNumCols.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNumCols.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtNumCols.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtNumCols.Increment = 1D;
            this.txtNumCols.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtNumCols.Location = new System.Drawing.Point(246, 20);
            this.txtNumCols.MinValue = 0D;
            this.txtNumCols.Name = "txtNumCols";
            this.txtNumCols.ShowUpDown = true;
            this.txtNumCols.Size = new System.Drawing.Size(62, 20);
            this.txtNumCols.TabIndex = 9;
            this.txtNumCols.Value = 1D;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(307, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 13);
            this.label9.TabIndex = 990;
            this.label9.Text = "عدد الكروت عرضيا :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(481, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 989;
            this.label8.Text = "عدد الكروت طوليا :";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox2.Controls.Add(this.ButWithoutSave);
            this.groupBox2.Controls.Add(this.ButWithSave);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 549);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(594, 54);
            this.groupBox2.TabIndex = 983;
            this.groupBox2.TabStop = false;
            // 
            // ButWithoutSave
            // 
            this.ButWithoutSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButWithoutSave.Checked = true;
            this.ButWithoutSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ButWithoutSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButWithoutSave.Location = new System.Drawing.Point(15, 14);
            this.ButWithoutSave.Name = "ButWithoutSave";
            this.ButWithoutSave.Size = new System.Drawing.Size(280, 35);
            this.ButWithoutSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButWithoutSave.Symbol = "";
            this.ButWithoutSave.SymbolSize = 12F;
            this.ButWithoutSave.TabIndex = 13;
            this.ButWithoutSave.Text = "خــــروج Esc";
            this.ButWithoutSave.TextColor = System.Drawing.Color.Black;
            this.ButWithoutSave.Click += new System.EventHandler(this.ButWithoutSave_Click);
            // 
            // ButWithSave
            // 
            this.ButWithSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButWithSave.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.ButWithSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButWithSave.Location = new System.Drawing.Point(303, 14);
            this.ButWithSave.Name = "ButWithSave";
            this.ButWithSave.Size = new System.Drawing.Size(280, 35);
            this.ButWithSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButWithSave.Symbol = "";
            this.ButWithSave.SymbolSize = 12F;
            this.ButWithSave.TabIndex = 12;
            this.ButWithSave.Text = "حفــــظ F2";
            this.ButWithSave.TextColor = System.Drawing.Color.White;
            this.ButWithSave.Click += new System.EventHandler(this.ButWithSave_Click);
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
            this.labelX1.Size = new System.Drawing.Size(594, 26);
            this.labelX1.TabIndex = 984;
            this.labelX1.Text = "إعدادات طباعة الباركود";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // FMBarCodeUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(594, 269);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.ribbonBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.CmbPrintP2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CmbPrintP);
            this.Controls.Add(this.CmbDir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FMBarCodeUser";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FMBarCodeUser_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.ribbonBar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FlxFiles)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLeftM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTopM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarHeigth)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtpageCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumCols)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.ResumeLayout(false);

        }
        public FMBarCodeUser()
        {
            InitializeComponent();
            listInvSetting = db.StockInvSettingList(VarGeneral.UserID);
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ButWithSave.Text = "حفــــظ F2";
                ButWithoutSave.Text = "خــــروج Esc";
                label1.Text = "اختيار الطابعة :";
                label2.Text = "هامش اعلى :";
                label10.Text = "هامش يسار :";
                label4.Text = "العـــرض :";
                label5.Text = "الإرتفـــاع :";
                label6.Text = "البعد العرضي بين كروت الباركود :";
                label7.Text = "الإرتفاع بين كروت الباركود :";
                label8.Text = "عدد الكروت طوليا :";
                label9.Text = "عدد الكروت عرضيا :";
                labelX1.Text = "إعدادات طباعة الباركود";
            }
            else
            {
                ButWithSave.Text = "Save F2";
                ButWithoutSave.Text = "Exit Esc";
                label1.Text = "Select Printer :";
                label2.Text = "Top margin :";
                label10.Text = "Left margin :";
                label4.Text = "width :";
                label5.Text = "Height :";
                label6.Text = "Width dimension between the barcode :";
                label7.Text = "Height between the barcode :";
                label8.Text = "Number of full-length cards :";
                label9.Text = "Number of cards Width :";
                labelX1.Text = "Barcode Setting";
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FMBarCodeUser));
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
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FMBarCodeUser));
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
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("OnParentRightToLeftChanged:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void BindData()
        {
            try
            {
                for (int iiCnt = 0; iiCnt < listInvSetting.Count; iiCnt++)
                {
                    _InvSetting = listInvSetting[iiCnt];
                    if (_InvSetting.InvID == 22)
                    {
                        txtWidth.Text = _InvSetting.InvpRINTERInfo.hAs.ToString();
                        txtLeftM.Text = _InvSetting.InvpRINTERInfo.hYs.ToString();
                        txtNumRows.Text = _InvSetting.InvpRINTERInfo.lnPg.ToString();
                        txtHeight.Text = _InvSetting.InvpRINTERInfo.hYm.ToString();
                        txtTopM.Text = _InvSetting.InvpRINTERInfo.hAl.ToString();
                        txtNumCols.Text = _InvSetting.InvpRINTERInfo.lnSpc.ToString();
                        txtBarHeigth.Text = _InvSetting.InvNum.ToString();
                        txtBarWidth.Text = _InvSetting.InvNum1.ToString();
                        CmbPrinter.Text = _InvSetting.defPrn;
                        txtpageCount.Value = _InvSetting.InvpRINTERInfo.DefLines.Value;
                        break;
                    }
                }
                listmInvPrint = (from item in db.T_mInvPrints
                                 where item.repTyp == (int?)22
                                 where item.repNum == (int?)4
                                 where item.BarcodeTyp == (int?)0 || item.BarcodeTyp == (int?)1
                                 select item).ToList();
                if (listmInvPrint.Count != 0)
                {
                    try
                    {
                        for (int i = 0; i < CmbUnit.Items.Count; i++)
                        {
                            CmbUnit.SelectedIndex = i;
                            if (CmbUnit.Text.ToString().ToUpper().Trim() == listmInvPrint[0].uChr.ToString().ToUpper().Trim())
                            {
                                break;
                            }
                        }
                    }
                    catch
                    {
                        CmbUnit.SelectedIndex = 0;
                    }
                    for (int iiCnt = 1; iiCnt <= listmInvPrint.Count; iiCnt++)
                    {
                        _mInvPrint = listmInvPrint[iiCnt - 1];
                        if ((_mInvPrint.pField ?? "").ToString() == string.Concat(FlxFiles.GetData(iiCnt, 12)))
                        {
                            FlxFiles.SetData(iiCnt, 2, VarGeneral.TString.ChkStatShow(VarGeneral.TString.TEmpty(string.Concat(_mInvPrint.IsPrint)), 0));
                            FlxFiles.SetData(iiCnt, 3, _mInvPrint.vRow);
                            FlxFiles.SetData(iiCnt, 4, _mInvPrint.vCol);
                            FlxFiles.SetData(iiCnt, 13, _mInvPrint.vEt);
                            CmbDir.SelectedIndex = int.Parse(VarGeneral.TString.TEmpty(string.Concat(_mInvPrint.vEt)));
                            FlxFiles.SetData(iiCnt, 5, CmbDir.Text);
                            FlxFiles.SetData(iiCnt, 14, _mInvPrint.IsPrntHd);
                            CmbPrintP.SelectedIndex = int.Parse(VarGeneral.TString.TEmpty(string.Concat(_mInvPrint.IsPrntHd)));
                            FlxFiles.SetData(iiCnt, 6, CmbPrintP.Text);
                            FlxFiles.SetData(iiCnt, 7, _mInvPrint.MaxW);
                            FlxFiles.SetData(iiCnt, 15, _mInvPrint.nTyp);
                            CmbPrintP2.SelectedIndex = int.Parse(VarGeneral.TString.TEmpty(string.Concat(_mInvPrint.nTyp)));
                            FlxFiles.SetData(iiCnt, 11, CmbPrintP2.Text);
                            FlxFiles.SetData(iiCnt, 8, _mInvPrint.vFont);
                            FlxFiles.SetData(iiCnt, 9, _mInvPrint.vSize);
                            FlxFiles.SetData(iiCnt, 10, VarGeneral.TString.ChkStatShow(VarGeneral.TString.TEmpty(string.Concat(_mInvPrint.vBold)), 0));
                        }
                    }
                }
                else
                {
                    CmbUnit.SelectedIndex = 0;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("BindData:", error, enable: true);
            }
        }
        private void FillCombo()
        {
            CmbUnit.SelectedIndex = 0;
            int _CmbIndex = 0;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                CmbPrinter.Items.Clear();
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
                FlxFiles.Rows.Count = 12;
                FlxFiles.Cols[0].Visible = false;
                FlxFiles.Cols[1].Visible = true;
                FlxFiles.SetData(0, 0, "Filed");
                FlxFiles.SetData(0, 1, "العنوان");
                FlxFiles.SetData(0, 2, "طباعة");
                FlxFiles.SetData(0, 3, "السطر");
                FlxFiles.SetData(0, 4, "العمود");
                FlxFiles.SetData(0, 5, "الأتجاه");
                CmbDir.Items.Clear();
                CmbDir.Items.Add("يمين");
                CmbDir.Items.Add("يسار");
                CmbDir.Items.Add("وسط");
                FlxFiles.Cols[5].Editor = CmbDir;
                FlxFiles.SetData(0, 6, "مكان الطباعة");
                CmbPrintP.Items.Clear();
                CmbPrintP.Items.Add("رأس المستند");
                CmbPrintP.Items.Add("سطور المستند");
                FlxFiles.Cols[6].Editor = CmbPrintP;
                FlxFiles.SetData(0, 7, "أقصى عرض");
                FlxFiles.SetData(0, 8, "الخط");
                InstalledFontCollection _font = new InstalledFontCollection();
                string fontString = "";
                for (int i = 0; i < _font.Families.Length; i++)
                {
                    fontString += _font.Families[i].Name;
                    fontString += "|";
                }
                FlxFiles.Cols[8].ComboList = fontString;
                FlxFiles.SetData(0, 9, "الحجم");
                FlxFiles.SetData(0, 10, "عريض");
                FlxFiles.SetData(0, 11, "موقع الطباعة 2");
                CmbPrintP2.Items.Clear();
                CmbPrintP2.Items.Add("كل صفحة");
                CmbPrintP2.Items.Add("الصفحة الأولى");
                CmbPrintP2.Items.Add("الصفحة الأخيرة");
                FlxFiles.Cols[11].Editor = CmbPrintP2;
                FlxFiles.SetData(1, 1, "أسم المنشأة");
                FlxFiles.SetData(1, 12, "CompanyName");
                FlxFiles.SetData(2, 1, "كود الصنف");
                FlxFiles.SetData(2, 12, "ItemNumber");
                FlxFiles.SetData(3, 1, "إسم الصنف");
                FlxFiles.SetData(3, 12, "ItemName");
                FlxFiles.SetData(4, 1, "سعر البيع");
                FlxFiles.SetData(4, 12, "Price");
                FlxFiles.SetData(5, 1, "رقم الباركود");
                FlxFiles.SetData(5, 12, "BarCode");
                FlxFiles.SetData(6, 1, " أسم المنشأة - عميل");
                FlxFiles.SetData(6, 12, "CompanyNm");
                FlxFiles.SetData(7, 1, "إسم العميل");
                FlxFiles.SetData(7, 12, "CustNm");
                FlxFiles.SetData(8, 1, "رقم العميل - باركود");
                FlxFiles.SetData(8, 12, "CustNo");
                FlxFiles.SetData(9, 1, "الملاحظة بالضريبة");
                FlxFiles.SetData(9, 12, "TaxNoteInv");
                FlxFiles.SetData(10, 1, "تاريخ الانتاج: ");
                FlxFiles.SetData(10, 12, "ProductionDate");
                FlxFiles.SetData(11, 1, "تاريخ الانتهاء ");
                FlxFiles.SetData(11, 12, "ExpirationDate");
            }
            else
            {
                CmbPrinter.Items.Clear();
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
                FlxFiles.Rows.Count = 10;
                FlxFiles.Cols[0].Visible = true;
                FlxFiles.Cols[1].Visible = false;
                FlxFiles.SetData(0, 0, "Filed");
                FlxFiles.SetData(0, 1, "العنوان");
                FlxFiles.SetData(0, 2, "Print");
                FlxFiles.SetData(0, 3, "Line");
                FlxFiles.SetData(0, 4, "Column");
                FlxFiles.SetData(0, 5, "Direction");
                CmbDir.Items.Clear();
                CmbDir.Items.Add("Right");
                CmbDir.Items.Add("Left");
                CmbDir.Items.Add("Center");
                FlxFiles.Cols[5].Editor = CmbDir;
                FlxFiles.SetData(0, 6, "Print Place");
                CmbPrintP.Items.Clear();
                CmbPrintP.Items.Add("Document Top");
                CmbPrintP.Items.Add("Document Line");
                FlxFiles.Cols[6].Editor = CmbPrintP;
                FlxFiles.SetData(0, 7, "With");
                FlxFiles.SetData(0, 8, "Font");
                InstalledFontCollection _font = new InstalledFontCollection();
                string fontString = "";
                for (int i = 0; i < _font.Families.Length; i++)
                {
                    fontString += _font.Families[i].Name;
                    fontString += "|";
                }
                FlxFiles.Cols[8].ComboList = fontString;
                FlxFiles.SetData(0, 9, "Size");
                FlxFiles.SetData(0, 10, "Bold");
                FlxFiles.SetData(0, 11, "Print Place 2");
                CmbPrintP2.Items.Clear();
                CmbPrintP2.Items.Add("All Page");
                CmbPrintP2.Items.Add("Frist Page");
                CmbPrintP2.Items.Add("Last Page");
                FlxFiles.Cols[11].Editor = CmbPrintP2;
                FlxFiles.SetData(1, 0, "أسم المنشأة");
                FlxFiles.SetData(1, 12, "CompanyName");
                FlxFiles.SetData(2, 0, "رقم الصنف");
                FlxFiles.SetData(2, 12, "ItemNumber");
                FlxFiles.SetData(3, 0, "إسم الصنف");
                FlxFiles.SetData(3, 12, "ItemName");
                FlxFiles.SetData(4, 0, "سعر البيع");
                FlxFiles.SetData(4, 12, "Price");
                FlxFiles.SetData(5, 0, "رقم الباركود");
                FlxFiles.SetData(5, 12, "BarCode");
                FlxFiles.SetData(6, 0, " أسم المنشأة - عميل");
                FlxFiles.SetData(6, 12, "CompanyNm");
                FlxFiles.SetData(7, 0, "إسم العميل");
                FlxFiles.SetData(7, 12, "CustNm");
                FlxFiles.SetData(8, 0, "رقم العميل - باركود");
                FlxFiles.SetData(8, 12, "CustNo");
                FlxFiles.SetData(9, 1, "الملاحظة بالضريبة");
                FlxFiles.SetData(9, 12, "TaxNoteInv");
            }
            RibunButtons();
        }
        private bool SaveData()
        {
            try
            {
                _InvSetting.InvpRINTERInfo.hAs = txtWidth.Value;
                _InvSetting.InvpRINTERInfo.hYs = txtLeftM.Value;
                _InvSetting.InvpRINTERInfo.lnPg = txtNumRows.Value;
                _InvSetting.InvpRINTERInfo.hYm = txtHeight.Value;
                _InvSetting.InvpRINTERInfo.hAl = txtTopM.Value;
                _InvSetting.InvpRINTERInfo.lnSpc = txtNumCols.Value;
                _InvSetting.InvNum = txtBarHeigth.Value;
                _InvSetting.InvNum1 = txtBarWidth.Value;
                _InvSetting.defPrn = CmbPrinter.Text ?? "";
                _InvSetting.InvpRINTERInfo.DefLines = txtpageCount.Value;
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                int iiCnt = 0;
                if (listmInvPrint.Count != 0)
                {
                    for (iiCnt = 0; iiCnt < listmInvPrint.Count; iiCnt++)
                    {
                        db.T_mInvPrints.DeleteOnSubmit(listmInvPrint[iiCnt]);
                        db.SubmitChanges();
                    }
                }
                for (iiCnt = 1; iiCnt < FlxFiles.Rows.Count; iiCnt++)
                {
                    _mInvPrint = new T_mInvPrint();
                    _mInvPrint.IsPrint = int.Parse(VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(FlxFiles.GetData(iiCnt, 2))));
                    _mInvPrint.vRow = int.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxFiles.GetData(iiCnt, 3))));
                    _mInvPrint.vCol = int.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxFiles.GetData(iiCnt, 4))));
                    _mInvPrint.vEt = int.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxFiles.GetData(iiCnt, 13))));
                    _mInvPrint.IsPrntHd = int.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxFiles.GetData(iiCnt, 14))));
                    _mInvPrint.nTyp = int.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxFiles.GetData(iiCnt, 15))));
                    _mInvPrint.MaxW = int.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxFiles.GetData(iiCnt, 7))));
                    _mInvPrint.vFont = string.Concat(FlxFiles.GetData(iiCnt, 8));
                    _mInvPrint.vSize = int.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxFiles.GetData(iiCnt, 9))));
                    _mInvPrint.vBold = int.Parse(VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(FlxFiles.GetData(iiCnt, 10))));
                    _mInvPrint.pField = string.Concat(FlxFiles.GetData(iiCnt, 12));
                    _mInvPrint.uChr = CmbUnit.Text;
                    _mInvPrint.repTyp = 22;
                    _mInvPrint.repNum = 4;
                    if (iiCnt > 5 && _mInvPrint.pField != "TaxNoteInv" && iiCnt != 10 && iiCnt != 11)
                    {
                        _mInvPrint.BarcodeTyp = 1;
                    }
                    else
                    {
                        _mInvPrint.BarcodeTyp = 0;
                    }
                    db.T_mInvPrints.InsertOnSubmit(_mInvPrint);
                    db.SubmitChanges();
                }
                MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch
            {
                return false;
            }
            return true;
        }
        private void ButWithoutSave_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ButWithSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Close();
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("ButWithSave_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void FlxFiles_AfterEdit(object sender, RowColEventArgs e)
        {
            if (e.Col == 5)
            {
                FlxFiles.SetData(e.Row, 13, CmbDir.SelectedIndex);
            }
            if (e.Col == 6)
            {
                FlxFiles.SetData(e.Row, 14, CmbPrintP.SelectedIndex);
            }
            if (e.Col == 11)
            {
                FlxFiles.SetData(e.Row, 15, CmbPrintP2.SelectedIndex);
            }
        }
        private void CmbInvType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FMExplanation fromExp = new FMExplanation(LangArEn);
            fromExp.ShowDialog();
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
            if (e.KeyCode == Keys.F2 && ButWithSave.Enabled && ButWithSave.Visible)
            {
                ButWithSave_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void FMBarCodeUser_Load(object sender, EventArgs e)
        {
        }
    }
}
