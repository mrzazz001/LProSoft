using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Library.RepShow;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmPointsCalc : Form
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
        private GroupPanel groupPanel1;
        internal Label Label1;
        private DoubleInput txtTotalPurchaes;
        internal Label label2;
        internal Label label3;
        private GroupPanel groupPanel4;
        internal Label labelCurr;
        internal Label label12;
        private DoubleInput txtPointOfRyal;
        private ButtonX ButExit;
        private ButtonX ButOk;
        private GroupPanel groupPanel5;
        private IntegerInput integerInput1;
        internal TextBox txtItem3;
        private IntegerInput integerInput3;
        internal TextBox txtItem2;
        private IntegerInput integerInput2;
        internal TextBox txtItem1;
        internal TextBox txtItem4;
        private IntegerInput integerInput4;
        internal TextBox textBox2;
        internal TextBox textBox5;
        internal TextBox textBox4;
        internal TextBox textBox3;
        private IntegerInput integerInput5;
        private IntegerInput integerInput6;
        private IntegerInput integerInput7;
        private IntegerInput integerInput8;
        internal TextBox txtItem4E;
        internal TextBox txtItem3E;
        internal TextBox txtItem2E;
        internal TextBox txtItem1E;
        internal TextBox textBox1;
        internal TextBox textBox6;
        internal TextBox textBox7;
        internal TextBox textBox8;
        private Label label4;
        private ButtonX button_SrchItemGroup;
        private TextBox txtClassName;
        private TextBox txtClassNo;
        private ButtonX button_UpdatePoint;
        private DoubleInput txtTotalPoint;
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private List<T_SYSSETTING> listSysSetting = new List<T_SYSSETTING>();
        private T_SYSSETTING _SysSetting = new T_SYSSETTING();
        private List<T_AccDef> listAccDef = new List<T_AccDef>();
        private T_AccDef _AccDef = new T_AccDef();
        private List<T_Company> listCompany = new List<T_Company>();
        private T_Company _Company = new T_Company();
        private List<T_GdAuto> listGdAuto = new List<T_GdAuto>();
        private T_GdAuto _GdAuto = new T_GdAuto();
        private List<T_InfoTb> listInfotb = new List<T_InfoTb>();
        private T_InfoTb _Infotb = new T_InfoTb();
        private int LangArEn = 0;
        private Stock_DataDataContext dbInstance;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
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
                ButOk.Enabled = !value;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmPointsCalc));
            groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            txtTotalPoint = new DevComponents.Editors.DoubleInput();
            button_UpdatePoint = new DevComponents.DotNetBar.ButtonX();
            label4 = new System.Windows.Forms.Label();
            button_SrchItemGroup = new DevComponents.DotNetBar.ButtonX();
            txtClassName = new System.Windows.Forms.TextBox();
            txtClassNo = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            txtTotalPurchaes = new DevComponents.Editors.DoubleInput();
            Label1 = new System.Windows.Forms.Label();
            groupPanel4 = new DevComponents.DotNetBar.Controls.GroupPanel();
            labelCurr = new System.Windows.Forms.Label();
            txtPointOfRyal = new DevComponents.Editors.DoubleInput();
            label12 = new System.Windows.Forms.Label();
            ButExit = new DevComponents.DotNetBar.ButtonX();
            ButOk = new DevComponents.DotNetBar.ButtonX();
            groupPanel5 = new DevComponents.DotNetBar.Controls.GroupPanel();
            txtItem4E = new System.Windows.Forms.TextBox();
            txtItem3E = new System.Windows.Forms.TextBox();
            txtItem2E = new System.Windows.Forms.TextBox();
            txtItem1E = new System.Windows.Forms.TextBox();
            textBox1 = new System.Windows.Forms.TextBox();
            textBox6 = new System.Windows.Forms.TextBox();
            textBox7 = new System.Windows.Forms.TextBox();
            textBox8 = new System.Windows.Forms.TextBox();
            integerInput5 = new DevComponents.Editors.IntegerInput();
            integerInput6 = new DevComponents.Editors.IntegerInput();
            integerInput7 = new DevComponents.Editors.IntegerInput();
            integerInput8 = new DevComponents.Editors.IntegerInput();
            textBox5 = new System.Windows.Forms.TextBox();
            textBox4 = new System.Windows.Forms.TextBox();
            textBox3 = new System.Windows.Forms.TextBox();
            textBox2 = new System.Windows.Forms.TextBox();
            txtItem4 = new System.Windows.Forms.TextBox();
            integerInput4 = new DevComponents.Editors.IntegerInput();
            txtItem3 = new System.Windows.Forms.TextBox();
            integerInput3 = new DevComponents.Editors.IntegerInput();
            txtItem2 = new System.Windows.Forms.TextBox();
            integerInput2 = new DevComponents.Editors.IntegerInput();
            txtItem1 = new System.Windows.Forms.TextBox();
            integerInput1 = new DevComponents.Editors.IntegerInput();
            groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtTotalPoint).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtTotalPurchaes).BeginInit();
            groupPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtPointOfRyal).BeginInit();
            groupPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)integerInput5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)integerInput6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)integerInput7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)integerInput8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)integerInput4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)integerInput3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)integerInput2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)integerInput1).BeginInit();
            SuspendLayout();
            groupPanel1.AccessibleDescription = null;
            groupPanel1.AccessibleName = null;
            resources.ApplyResources(groupPanel1, "groupPanel1");
            groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            groupPanel1.Controls.Add(txtTotalPoint);
            groupPanel1.Controls.Add(button_UpdatePoint);
            groupPanel1.Controls.Add(label4);
            groupPanel1.Controls.Add(button_SrchItemGroup);
            groupPanel1.Controls.Add(txtClassName);
            groupPanel1.Controls.Add(txtClassNo);
            groupPanel1.Controls.Add(label3);
            groupPanel1.Controls.Add(label2);
            groupPanel1.Controls.Add(txtTotalPurchaes);
            groupPanel1.Controls.Add(Label1);
            groupPanel1.Name = "groupPanel1";
            groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            groupPanel1.Style.BackColorGradientAngle = 90;
            groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel1.Style.BorderBottomWidth = 1;
            groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel1.Style.BorderLeftWidth = 1;
            groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel1.Style.BorderRightWidth = 1;
            groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel1.Style.BorderTopWidth = 1;
            groupPanel1.Style.CornerDiameter = 4;
            groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            groupPanel1.TitleImagePosition = DevComponents.DotNetBar.eTitleImagePosition.Center;
            txtTotalPoint.AccessibleDescription = null;
            txtTotalPoint.AccessibleName = null;
            txtTotalPoint.AllowEmptyState = false;
            resources.ApplyResources(txtTotalPoint, "txtTotalPoint");
            txtTotalPoint.BackgroundImage = null;
            txtTotalPoint.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 0);
            txtTotalPoint.BackgroundStyle.Class = "DateTimeInputBackground";
            txtTotalPoint.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            txtTotalPoint.ButtonCalculator.DisplayPosition = (int)resources.GetObject("txtTotalPoint.ButtonCalculator.DisplayPosition");
            txtTotalPoint.ButtonCalculator.Image = null;
            txtTotalPoint.ButtonCalculator.Text = resources.GetString("txtTotalPoint.ButtonCalculator.Text");
            txtTotalPoint.ButtonClear.DisplayPosition = (int)resources.GetObject("txtTotalPoint.ButtonClear.DisplayPosition");
            txtTotalPoint.ButtonClear.Image = null;
            txtTotalPoint.ButtonClear.Text = resources.GetString("txtTotalPoint.ButtonClear.Text");
            txtTotalPoint.ButtonCustom.DisplayPosition = (int)resources.GetObject("txtTotalPoint.ButtonCustom.DisplayPosition");
            txtTotalPoint.ButtonCustom.Image = null;
            txtTotalPoint.ButtonCustom.Text = resources.GetString("txtTotalPoint.ButtonCustom.Text");
            txtTotalPoint.ButtonCustom2.DisplayPosition = (int)resources.GetObject("txtTotalPoint.ButtonCustom2.DisplayPosition");
            txtTotalPoint.ButtonCustom2.Image = null;
            txtTotalPoint.ButtonCustom2.Text = resources.GetString("txtTotalPoint.ButtonCustom2.Text");
            txtTotalPoint.ButtonDropDown.DisplayPosition = (int)resources.GetObject("txtTotalPoint.ButtonDropDown.DisplayPosition");
            txtTotalPoint.ButtonDropDown.Image = null;
            txtTotalPoint.ButtonDropDown.Text = resources.GetString("txtTotalPoint.ButtonDropDown.Text");
            txtTotalPoint.ButtonFreeText.DisplayPosition = (int)resources.GetObject("txtTotalPoint.ButtonFreeText.DisplayPosition");
            txtTotalPoint.ButtonFreeText.Image = null;
            txtTotalPoint.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            txtTotalPoint.ButtonFreeText.Text = resources.GetString("txtTotalPoint.ButtonFreeText.Text");
            txtTotalPoint.CommandParameter = null;
            txtTotalPoint.DisplayFormat = "0.00";
            txtTotalPoint.Increment = 0.0;
            txtTotalPoint.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            txtTotalPoint.MinValue = 0.0;
            txtTotalPoint.Name = "txtTotalPoint";
            txtTotalPoint.ShowUpDown = true;
            button_UpdatePoint.AccessibleDescription = null;
            button_UpdatePoint.AccessibleName = null;
            button_UpdatePoint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_UpdatePoint, "button_UpdatePoint");
            button_UpdatePoint.BackgroundImage = null;
            button_UpdatePoint.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            button_UpdatePoint.CommandParameter = null;
            button_UpdatePoint.Name = "button_UpdatePoint";
            button_UpdatePoint.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_UpdatePoint.Symbol = "\uf021";
            button_UpdatePoint.SymbolSize = 16f;
            button_UpdatePoint.TextColor = System.Drawing.Color.Black;
            button_UpdatePoint.Click += new System.EventHandler(button_UpdatePoint_Click);
            label4.AccessibleDescription = null;
            label4.AccessibleName = null;
            resources.ApplyResources(label4, "label4");
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.Name = "label4";
            button_SrchItemGroup.AccessibleDescription = null;
            button_SrchItemGroup.AccessibleName = null;
            button_SrchItemGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_SrchItemGroup, "button_SrchItemGroup");
            button_SrchItemGroup.BackgroundImage = null;
            button_SrchItemGroup.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            button_SrchItemGroup.CommandParameter = null;
            button_SrchItemGroup.Font = null;
            button_SrchItemGroup.Name = "button_SrchItemGroup";
            button_SrchItemGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_SrchItemGroup.Symbol = "\uf002";
            button_SrchItemGroup.SymbolSize = 12f;
            button_SrchItemGroup.TextColor = System.Drawing.Color.SteelBlue;
            button_SrchItemGroup.Click += new System.EventHandler(button_SrchItemGroup_Click);
            txtClassName.AccessibleDescription = null;
            txtClassName.AccessibleName = null;
            resources.ApplyResources(txtClassName, "txtClassName");
            txtClassName.BackColor = System.Drawing.Color.DarkSeaGreen;
            txtClassName.BackgroundImage = null;
            txtClassName.Font = null;
            txtClassName.ForeColor = System.Drawing.Color.White;
            txtClassName.Name = "txtClassName";
            txtClassName.ReadOnly = true;
            txtClassNo.AccessibleDescription = null;
            txtClassNo.AccessibleName = null;
            resources.ApplyResources(txtClassNo, "txtClassNo");
            txtClassNo.BackColor = System.Drawing.Color.White;
            txtClassNo.BackgroundImage = null;
            txtClassNo.Font = null;
            txtClassNo.Name = "txtClassNo";
            txtClassNo.ReadOnly = true;
            txtClassNo.Tag = " T_CATEGORY.CAT_ID ";
            label3.AccessibleDescription = null;
            label3.AccessibleName = null;
            resources.ApplyResources(label3, "label3");
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label3.Name = "label3";
            label2.AccessibleDescription = null;
            label2.AccessibleName = null;
            resources.ApplyResources(label2, "label2");
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label2.Name = "label2";
            txtTotalPurchaes.AccessibleDescription = null;
            txtTotalPurchaes.AccessibleName = null;
            txtTotalPurchaes.AllowEmptyState = false;
            resources.ApplyResources(txtTotalPurchaes, "txtTotalPurchaes");
            txtTotalPurchaes.BackgroundImage = null;
            txtTotalPurchaes.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            txtTotalPurchaes.BackgroundStyle.Class = "DateTimeInputBackground";
            txtTotalPurchaes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            txtTotalPurchaes.ButtonCalculator.DisplayPosition = (int)resources.GetObject("txtTotalPurchaes.ButtonCalculator.DisplayPosition");
            txtTotalPurchaes.ButtonCalculator.Image = null;
            txtTotalPurchaes.ButtonCalculator.Text = resources.GetString("txtTotalPurchaes.ButtonCalculator.Text");
            txtTotalPurchaes.ButtonClear.DisplayPosition = (int)resources.GetObject("txtTotalPurchaes.ButtonClear.DisplayPosition");
            txtTotalPurchaes.ButtonClear.Image = null;
            txtTotalPurchaes.ButtonClear.Text = resources.GetString("txtTotalPurchaes.ButtonClear.Text");
            txtTotalPurchaes.ButtonCustom.DisplayPosition = (int)resources.GetObject("txtTotalPurchaes.ButtonCustom.DisplayPosition");
            txtTotalPurchaes.ButtonCustom.Image = null;
            txtTotalPurchaes.ButtonCustom.Text = resources.GetString("txtTotalPurchaes.ButtonCustom.Text");
            txtTotalPurchaes.ButtonCustom2.DisplayPosition = (int)resources.GetObject("txtTotalPurchaes.ButtonCustom2.DisplayPosition");
            txtTotalPurchaes.ButtonCustom2.Image = null;
            txtTotalPurchaes.ButtonCustom2.Text = resources.GetString("txtTotalPurchaes.ButtonCustom2.Text");
            txtTotalPurchaes.ButtonDropDown.DisplayPosition = (int)resources.GetObject("txtTotalPurchaes.ButtonDropDown.DisplayPosition");
            txtTotalPurchaes.ButtonDropDown.Image = null;
            txtTotalPurchaes.ButtonDropDown.Text = resources.GetString("txtTotalPurchaes.ButtonDropDown.Text");
            txtTotalPurchaes.ButtonFreeText.DisplayPosition = (int)resources.GetObject("txtTotalPurchaes.ButtonFreeText.DisplayPosition");
            txtTotalPurchaes.ButtonFreeText.Image = null;
            txtTotalPurchaes.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            txtTotalPurchaes.ButtonFreeText.Text = resources.GetString("txtTotalPurchaes.ButtonFreeText.Text");
            txtTotalPurchaes.CommandParameter = null;
            txtTotalPurchaes.DisplayFormat = "0.00";
            txtTotalPurchaes.Increment = 0.0;
            txtTotalPurchaes.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            txtTotalPurchaes.MinValue = 0.0;
            txtTotalPurchaes.Name = "txtTotalPurchaes";
            Label1.AccessibleDescription = null;
            Label1.AccessibleName = null;
            resources.ApplyResources(Label1, "Label1");
            Label1.BackColor = System.Drawing.Color.Transparent;
            Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Label1.Name = "Label1";
            groupPanel4.AccessibleDescription = null;
            groupPanel4.AccessibleName = null;
            resources.ApplyResources(groupPanel4, "groupPanel4");
            groupPanel4.CanvasColor = System.Drawing.SystemColors.Control;
            groupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            groupPanel4.Controls.Add(labelCurr);
            groupPanel4.Controls.Add(txtPointOfRyal);
            groupPanel4.Controls.Add(label12);
            groupPanel4.Name = "groupPanel4";
            groupPanel4.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            groupPanel4.Style.BackColorGradientAngle = 90;
            groupPanel4.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            groupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel4.Style.BorderBottomWidth = 1;
            groupPanel4.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            groupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel4.Style.BorderLeftWidth = 1;
            groupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel4.Style.BorderRightWidth = 1;
            groupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel4.Style.BorderTopWidth = 1;
            groupPanel4.Style.CornerDiameter = 4;
            groupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            groupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            groupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            groupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            groupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            groupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            groupPanel4.TitleImagePosition = DevComponents.DotNetBar.eTitleImagePosition.Center;
            labelCurr.AccessibleDescription = null;
            labelCurr.AccessibleName = null;
            resources.ApplyResources(labelCurr, "labelCurr");
            labelCurr.BackColor = System.Drawing.Color.Transparent;
            labelCurr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            labelCurr.ForeColor = System.Drawing.SystemColors.HotTrack;
            labelCurr.Name = "labelCurr";
            txtPointOfRyal.AccessibleDescription = null;
            txtPointOfRyal.AccessibleName = null;
            txtPointOfRyal.AllowEmptyState = false;
            resources.ApplyResources(txtPointOfRyal, "txtPointOfRyal");
            txtPointOfRyal.BackgroundImage = null;
            txtPointOfRyal.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 130, 132);
            txtPointOfRyal.BackgroundStyle.Class = "DateTimeInputBackground";
            txtPointOfRyal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            txtPointOfRyal.ButtonCalculator.DisplayPosition = (int)resources.GetObject("txtPointOfRyal.ButtonCalculator.DisplayPosition");
            txtPointOfRyal.ButtonCalculator.Image = null;
            txtPointOfRyal.ButtonCalculator.Text = resources.GetString("txtPointOfRyal.ButtonCalculator.Text");
            txtPointOfRyal.ButtonClear.DisplayPosition = (int)resources.GetObject("txtPointOfRyal.ButtonClear.DisplayPosition");
            txtPointOfRyal.ButtonClear.Image = null;
            txtPointOfRyal.ButtonClear.Text = resources.GetString("txtPointOfRyal.ButtonClear.Text");
            txtPointOfRyal.ButtonCustom.DisplayPosition = (int)resources.GetObject("txtPointOfRyal.ButtonCustom.DisplayPosition");
            txtPointOfRyal.ButtonCustom.Image = null;
            txtPointOfRyal.ButtonCustom.Text = resources.GetString("txtPointOfRyal.ButtonCustom.Text");
            txtPointOfRyal.ButtonCustom2.DisplayPosition = (int)resources.GetObject("txtPointOfRyal.ButtonCustom2.DisplayPosition");
            txtPointOfRyal.ButtonCustom2.Image = null;
            txtPointOfRyal.ButtonCustom2.Text = resources.GetString("txtPointOfRyal.ButtonCustom2.Text");
            txtPointOfRyal.ButtonDropDown.DisplayPosition = (int)resources.GetObject("txtPointOfRyal.ButtonDropDown.DisplayPosition");
            txtPointOfRyal.ButtonDropDown.Image = null;
            txtPointOfRyal.ButtonDropDown.Text = resources.GetString("txtPointOfRyal.ButtonDropDown.Text");
            txtPointOfRyal.ButtonFreeText.DisplayPosition = (int)resources.GetObject("txtPointOfRyal.ButtonFreeText.DisplayPosition");
            txtPointOfRyal.ButtonFreeText.Image = null;
            txtPointOfRyal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            txtPointOfRyal.ButtonFreeText.Text = resources.GetString("txtPointOfRyal.ButtonFreeText.Text");
            txtPointOfRyal.CommandParameter = null;
            txtPointOfRyal.DisplayFormat = "0.00";
            txtPointOfRyal.Increment = 0.0;
            txtPointOfRyal.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            txtPointOfRyal.MinValue = 0.0;
            txtPointOfRyal.Name = "txtPointOfRyal";
            txtPointOfRyal.Value = 0.01;
            label12.AccessibleDescription = null;
            label12.AccessibleName = null;
            resources.ApplyResources(label12, "label12");
            label12.BackColor = System.Drawing.Color.Transparent;
            label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label12.ForeColor = System.Drawing.SystemColors.HotTrack;
            label12.Name = "label12";
            ButExit.AccessibleDescription = null;
            ButExit.AccessibleName = null;
            ButExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(ButExit, "ButExit");
            ButExit.BackgroundImage = null;
            ButExit.Checked = true;
            ButExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            ButExit.CommandParameter = null;
            ButExit.Name = "ButExit";
            ButExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButExit.Symbol = "\uf011";
            ButExit.SymbolSize = 16f;
            ButExit.TextColor = System.Drawing.Color.Black;
            ButExit.Click += new System.EventHandler(ButExit_Click);
            ButOk.AccessibleDescription = null;
            ButOk.AccessibleName = null;
            ButOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(ButOk, "ButOk");
            ButOk.BackgroundImage = null;
            ButOk.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            ButOk.CommandParameter = null;
            ButOk.Name = "ButOk";
            ButOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButOk.Symbol = "\uf00c";
            ButOk.SymbolSize = 16f;
            ButOk.TextColor = System.Drawing.Color.White;
            ButOk.Click += new System.EventHandler(ButOk_Click);
            groupPanel5.AccessibleDescription = null;
            groupPanel5.AccessibleName = null;
            resources.ApplyResources(groupPanel5, "groupPanel5");
            groupPanel5.CanvasColor = System.Drawing.SystemColors.Control;
            groupPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            groupPanel5.ColorTable = DevComponents.DotNetBar.Controls.ePanelColorTable.Green;
            groupPanel5.Controls.Add(txtItem4E);
            groupPanel5.Controls.Add(txtItem3E);
            groupPanel5.Controls.Add(txtItem2E);
            groupPanel5.Controls.Add(txtItem1E);
            groupPanel5.Controls.Add(textBox1);
            groupPanel5.Controls.Add(textBox6);
            groupPanel5.Controls.Add(textBox7);
            groupPanel5.Controls.Add(textBox8);
            groupPanel5.Controls.Add(integerInput5);
            groupPanel5.Controls.Add(integerInput6);
            groupPanel5.Controls.Add(integerInput7);
            groupPanel5.Controls.Add(integerInput8);
            groupPanel5.Controls.Add(textBox5);
            groupPanel5.Controls.Add(textBox4);
            groupPanel5.Controls.Add(textBox3);
            groupPanel5.Controls.Add(textBox2);
            groupPanel5.Controls.Add(txtItem4);
            groupPanel5.Controls.Add(integerInput4);
            groupPanel5.Controls.Add(txtItem3);
            groupPanel5.Controls.Add(integerInput3);
            groupPanel5.Controls.Add(txtItem2);
            groupPanel5.Controls.Add(integerInput2);
            groupPanel5.Controls.Add(txtItem1);
            groupPanel5.Controls.Add(integerInput1);
            groupPanel5.Name = "groupPanel5";
            groupPanel5.Style.BackColor = System.Drawing.Color.FromArgb(195, 217, 185);
            groupPanel5.Style.BackColor2 = System.Drawing.Color.FromArgb(156, 191, 139);
            groupPanel5.Style.BackColorGradientAngle = 90;
            groupPanel5.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel5.Style.BorderBottomWidth = 1;
            groupPanel5.Style.BorderColor = System.Drawing.Color.FromArgb(114, 164, 90);
            groupPanel5.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel5.Style.BorderLeftWidth = 1;
            groupPanel5.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel5.Style.BorderRightWidth = 1;
            groupPanel5.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel5.Style.BorderTopWidth = 1;
            groupPanel5.Style.CornerDiameter = 4;
            groupPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            groupPanel5.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            groupPanel5.Style.TextColor = System.Drawing.Color.FromArgb(60, 74, 31);
            groupPanel5.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            groupPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            groupPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            groupPanel5.TitleImagePosition = DevComponents.DotNetBar.eTitleImagePosition.Center;
            txtItem4E.AccessibleDescription = null;
            txtItem4E.AccessibleName = null;
            resources.ApplyResources(txtItem4E, "txtItem4E");
            txtItem4E.BackgroundImage = null;
            txtItem4E.ForeColor = System.Drawing.Color.DodgerBlue;
            txtItem4E.Name = "txtItem4E";
            txtItem3E.AccessibleDescription = null;
            txtItem3E.AccessibleName = null;
            resources.ApplyResources(txtItem3E, "txtItem3E");
            txtItem3E.BackgroundImage = null;
            txtItem3E.ForeColor = System.Drawing.Color.DodgerBlue;
            txtItem3E.Name = "txtItem3E";
            txtItem2E.AccessibleDescription = null;
            txtItem2E.AccessibleName = null;
            resources.ApplyResources(txtItem2E, "txtItem2E");
            txtItem2E.BackgroundImage = null;
            txtItem2E.ForeColor = System.Drawing.Color.DodgerBlue;
            txtItem2E.Name = "txtItem2E";
            txtItem2E.Click += new System.EventHandler(txtItem2E_Click);
            txtItem1E.AccessibleDescription = null;
            txtItem1E.AccessibleName = null;
            resources.ApplyResources(txtItem1E, "txtItem1E");
            txtItem1E.BackgroundImage = null;
            txtItem1E.ForeColor = System.Drawing.Color.DodgerBlue;
            txtItem1E.Name = "txtItem1E";
            txtItem1E.Click += new System.EventHandler(txtItem1E_Click);
            textBox1.AccessibleDescription = null;
            textBox1.AccessibleName = null;
            resources.ApplyResources(textBox1, "textBox1");
            textBox1.BackgroundImage = null;
            textBox1.ForeColor = System.Drawing.Color.SlateGray;
            textBox1.Name = "textBox1";
            textBox6.AccessibleDescription = null;
            textBox6.AccessibleName = null;
            resources.ApplyResources(textBox6, "textBox6");
            textBox6.BackgroundImage = null;
            textBox6.ForeColor = System.Drawing.Color.SlateGray;
            textBox6.Name = "textBox6";
            textBox7.AccessibleDescription = null;
            textBox7.AccessibleName = null;
            resources.ApplyResources(textBox7, "textBox7");
            textBox7.BackgroundImage = null;
            textBox7.ForeColor = System.Drawing.Color.SlateGray;
            textBox7.Name = "textBox7";
            textBox8.AccessibleDescription = null;
            textBox8.AccessibleName = null;
            resources.ApplyResources(textBox8, "textBox8");
            textBox8.BackgroundImage = null;
            textBox8.ForeColor = System.Drawing.Color.SlateGray;
            textBox8.Name = "textBox8";
            integerInput5.AccessibleDescription = null;
            integerInput5.AccessibleName = null;
            integerInput5.AllowEmptyState = false;
            resources.ApplyResources(integerInput5, "integerInput5");
            integerInput5.BackgroundImage = null;
            integerInput5.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            integerInput5.BackgroundStyle.Class = "DateTimeInputBackground";
            integerInput5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            integerInput5.ButtonCalculator.DisplayPosition = (int)resources.GetObject("integerInput5.ButtonCalculator.DisplayPosition");
            integerInput5.ButtonCalculator.Image = null;
            integerInput5.ButtonCalculator.Text = resources.GetString("integerInput5.ButtonCalculator.Text");
            integerInput5.ButtonClear.DisplayPosition = (int)resources.GetObject("integerInput5.ButtonClear.DisplayPosition");
            integerInput5.ButtonClear.Image = null;
            integerInput5.ButtonClear.Text = resources.GetString("integerInput5.ButtonClear.Text");
            integerInput5.ButtonCustom.DisplayPosition = (int)resources.GetObject("integerInput5.ButtonCustom.DisplayPosition");
            integerInput5.ButtonCustom.Image = null;
            integerInput5.ButtonCustom.Text = resources.GetString("integerInput5.ButtonCustom.Text");
            integerInput5.ButtonCustom2.DisplayPosition = (int)resources.GetObject("integerInput5.ButtonCustom2.DisplayPosition");
            integerInput5.ButtonCustom2.Image = null;
            integerInput5.ButtonCustom2.Text = resources.GetString("integerInput5.ButtonCustom2.Text");
            integerInput5.ButtonDropDown.DisplayPosition = (int)resources.GetObject("integerInput5.ButtonDropDown.DisplayPosition");
            integerInput5.ButtonDropDown.Image = null;
            integerInput5.ButtonDropDown.Text = resources.GetString("integerInput5.ButtonDropDown.Text");
            integerInput5.ButtonFreeText.DisplayPosition = (int)resources.GetObject("integerInput5.ButtonFreeText.DisplayPosition");
            integerInput5.ButtonFreeText.Image = null;
            integerInput5.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            integerInput5.ButtonFreeText.Text = resources.GetString("integerInput5.ButtonFreeText.Text");
            integerInput5.CommandParameter = null;
            integerInput5.DisplayFormat = "0";
            integerInput5.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            integerInput5.IsInputReadOnly = true;
            integerInput5.MinValue = 0;
            integerInput5.Name = "integerInput5";
            integerInput5.Value = 4;
            integerInput6.AccessibleDescription = null;
            integerInput6.AccessibleName = null;
            integerInput6.AllowEmptyState = false;
            resources.ApplyResources(integerInput6, "integerInput6");
            integerInput6.BackgroundImage = null;
            integerInput6.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            integerInput6.BackgroundStyle.Class = "DateTimeInputBackground";
            integerInput6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            integerInput6.ButtonCalculator.DisplayPosition = (int)resources.GetObject("integerInput6.ButtonCalculator.DisplayPosition");
            integerInput6.ButtonCalculator.Image = null;
            integerInput6.ButtonCalculator.Text = resources.GetString("integerInput6.ButtonCalculator.Text");
            integerInput6.ButtonClear.DisplayPosition = (int)resources.GetObject("integerInput6.ButtonClear.DisplayPosition");
            integerInput6.ButtonClear.Image = null;
            integerInput6.ButtonClear.Text = resources.GetString("integerInput6.ButtonClear.Text");
            integerInput6.ButtonCustom.DisplayPosition = (int)resources.GetObject("integerInput6.ButtonCustom.DisplayPosition");
            integerInput6.ButtonCustom.Image = null;
            integerInput6.ButtonCustom.Text = resources.GetString("integerInput6.ButtonCustom.Text");
            integerInput6.ButtonCustom2.DisplayPosition = (int)resources.GetObject("integerInput6.ButtonCustom2.DisplayPosition");
            integerInput6.ButtonCustom2.Image = null;
            integerInput6.ButtonCustom2.Text = resources.GetString("integerInput6.ButtonCustom2.Text");
            integerInput6.ButtonDropDown.DisplayPosition = (int)resources.GetObject("integerInput6.ButtonDropDown.DisplayPosition");
            integerInput6.ButtonDropDown.Image = null;
            integerInput6.ButtonDropDown.Text = resources.GetString("integerInput6.ButtonDropDown.Text");
            integerInput6.ButtonFreeText.DisplayPosition = (int)resources.GetObject("integerInput6.ButtonFreeText.DisplayPosition");
            integerInput6.ButtonFreeText.Image = null;
            integerInput6.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            integerInput6.ButtonFreeText.Text = resources.GetString("integerInput6.ButtonFreeText.Text");
            integerInput6.CommandParameter = null;
            integerInput6.DisplayFormat = "0";
            integerInput6.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            integerInput6.IsInputReadOnly = true;
            integerInput6.MinValue = 0;
            integerInput6.Name = "integerInput6";
            integerInput6.Value = 3;
            integerInput7.AccessibleDescription = null;
            integerInput7.AccessibleName = null;
            integerInput7.AllowEmptyState = false;
            resources.ApplyResources(integerInput7, "integerInput7");
            integerInput7.BackgroundImage = null;
            integerInput7.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            integerInput7.BackgroundStyle.Class = "DateTimeInputBackground";
            integerInput7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            integerInput7.ButtonCalculator.DisplayPosition = (int)resources.GetObject("integerInput7.ButtonCalculator.DisplayPosition");
            integerInput7.ButtonCalculator.Image = null;
            integerInput7.ButtonCalculator.Text = resources.GetString("integerInput7.ButtonCalculator.Text");
            integerInput7.ButtonClear.DisplayPosition = (int)resources.GetObject("integerInput7.ButtonClear.DisplayPosition");
            integerInput7.ButtonClear.Image = null;
            integerInput7.ButtonClear.Text = resources.GetString("integerInput7.ButtonClear.Text");
            integerInput7.ButtonCustom.DisplayPosition = (int)resources.GetObject("integerInput7.ButtonCustom.DisplayPosition");
            integerInput7.ButtonCustom.Image = null;
            integerInput7.ButtonCustom.Text = resources.GetString("integerInput7.ButtonCustom.Text");
            integerInput7.ButtonCustom2.DisplayPosition = (int)resources.GetObject("integerInput7.ButtonCustom2.DisplayPosition");
            integerInput7.ButtonCustom2.Image = null;
            integerInput7.ButtonCustom2.Text = resources.GetString("integerInput7.ButtonCustom2.Text");
            integerInput7.ButtonDropDown.DisplayPosition = (int)resources.GetObject("integerInput7.ButtonDropDown.DisplayPosition");
            integerInput7.ButtonDropDown.Image = null;
            integerInput7.ButtonDropDown.Text = resources.GetString("integerInput7.ButtonDropDown.Text");
            integerInput7.ButtonFreeText.DisplayPosition = (int)resources.GetObject("integerInput7.ButtonFreeText.DisplayPosition");
            integerInput7.ButtonFreeText.Image = null;
            integerInput7.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            integerInput7.ButtonFreeText.Text = resources.GetString("integerInput7.ButtonFreeText.Text");
            integerInput7.CommandParameter = null;
            integerInput7.DisplayFormat = "0";
            integerInput7.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            integerInput7.IsInputReadOnly = true;
            integerInput7.MinValue = 0;
            integerInput7.Name = "integerInput7";
            integerInput7.Value = 2;
            integerInput8.AccessibleDescription = null;
            integerInput8.AccessibleName = null;
            integerInput8.AllowEmptyState = false;
            resources.ApplyResources(integerInput8, "integerInput8");
            integerInput8.BackgroundImage = null;
            integerInput8.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            integerInput8.BackgroundStyle.Class = "DateTimeInputBackground";
            integerInput8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            integerInput8.ButtonCalculator.DisplayPosition = (int)resources.GetObject("integerInput8.ButtonCalculator.DisplayPosition");
            integerInput8.ButtonCalculator.Image = null;
            integerInput8.ButtonCalculator.Text = resources.GetString("integerInput8.ButtonCalculator.Text");
            integerInput8.ButtonClear.DisplayPosition = (int)resources.GetObject("integerInput8.ButtonClear.DisplayPosition");
            integerInput8.ButtonClear.Image = null;
            integerInput8.ButtonClear.Text = resources.GetString("integerInput8.ButtonClear.Text");
            integerInput8.ButtonCustom.DisplayPosition = (int)resources.GetObject("integerInput8.ButtonCustom.DisplayPosition");
            integerInput8.ButtonCustom.Image = null;
            integerInput8.ButtonCustom.Text = resources.GetString("integerInput8.ButtonCustom.Text");
            integerInput8.ButtonCustom2.DisplayPosition = (int)resources.GetObject("integerInput8.ButtonCustom2.DisplayPosition");
            integerInput8.ButtonCustom2.Image = null;
            integerInput8.ButtonCustom2.Text = resources.GetString("integerInput8.ButtonCustom2.Text");
            integerInput8.ButtonDropDown.DisplayPosition = (int)resources.GetObject("integerInput8.ButtonDropDown.DisplayPosition");
            integerInput8.ButtonDropDown.Image = null;
            integerInput8.ButtonDropDown.Text = resources.GetString("integerInput8.ButtonDropDown.Text");
            integerInput8.ButtonFreeText.DisplayPosition = (int)resources.GetObject("integerInput8.ButtonFreeText.DisplayPosition");
            integerInput8.ButtonFreeText.Image = null;
            integerInput8.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            integerInput8.ButtonFreeText.Text = resources.GetString("integerInput8.ButtonFreeText.Text");
            integerInput8.CommandParameter = null;
            integerInput8.DisplayFormat = "0";
            integerInput8.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            integerInput8.IsInputReadOnly = true;
            integerInput8.MinValue = 0;
            integerInput8.Name = "integerInput8";
            integerInput8.Value = 1;
            textBox5.AccessibleDescription = null;
            textBox5.AccessibleName = null;
            resources.ApplyResources(textBox5, "textBox5");
            textBox5.BackgroundImage = null;
            textBox5.ForeColor = System.Drawing.Color.SlateGray;
            textBox5.Name = "textBox5";
            textBox4.AccessibleDescription = null;
            textBox4.AccessibleName = null;
            resources.ApplyResources(textBox4, "textBox4");
            textBox4.BackgroundImage = null;
            textBox4.ForeColor = System.Drawing.Color.SlateGray;
            textBox4.Name = "textBox4";
            textBox3.AccessibleDescription = null;
            textBox3.AccessibleName = null;
            resources.ApplyResources(textBox3, "textBox3");
            textBox3.BackgroundImage = null;
            textBox3.ForeColor = System.Drawing.Color.SlateGray;
            textBox3.Name = "textBox3";
            textBox2.AccessibleDescription = null;
            textBox2.AccessibleName = null;
            resources.ApplyResources(textBox2, "textBox2");
            textBox2.BackgroundImage = null;
            textBox2.ForeColor = System.Drawing.Color.SlateGray;
            textBox2.Name = "textBox2";
            txtItem4.AccessibleDescription = null;
            txtItem4.AccessibleName = null;
            resources.ApplyResources(txtItem4, "txtItem4");
            txtItem4.BackgroundImage = null;
            txtItem4.ForeColor = System.Drawing.Color.DodgerBlue;
            txtItem4.Name = "txtItem4";
            integerInput4.AccessibleDescription = null;
            integerInput4.AccessibleName = null;
            integerInput4.AllowEmptyState = false;
            resources.ApplyResources(integerInput4, "integerInput4");
            integerInput4.BackgroundImage = null;
            integerInput4.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            integerInput4.BackgroundStyle.Class = "DateTimeInputBackground";
            integerInput4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            integerInput4.ButtonCalculator.DisplayPosition = (int)resources.GetObject("integerInput4.ButtonCalculator.DisplayPosition");
            integerInput4.ButtonCalculator.Image = null;
            integerInput4.ButtonCalculator.Text = resources.GetString("integerInput4.ButtonCalculator.Text");
            integerInput4.ButtonClear.DisplayPosition = (int)resources.GetObject("integerInput4.ButtonClear.DisplayPosition");
            integerInput4.ButtonClear.Image = null;
            integerInput4.ButtonClear.Text = resources.GetString("integerInput4.ButtonClear.Text");
            integerInput4.ButtonCustom.DisplayPosition = (int)resources.GetObject("integerInput4.ButtonCustom.DisplayPosition");
            integerInput4.ButtonCustom.Image = null;
            integerInput4.ButtonCustom.Text = resources.GetString("integerInput4.ButtonCustom.Text");
            integerInput4.ButtonCustom2.DisplayPosition = (int)resources.GetObject("integerInput4.ButtonCustom2.DisplayPosition");
            integerInput4.ButtonCustom2.Image = null;
            integerInput4.ButtonCustom2.Text = resources.GetString("integerInput4.ButtonCustom2.Text");
            integerInput4.ButtonDropDown.DisplayPosition = (int)resources.GetObject("integerInput4.ButtonDropDown.DisplayPosition");
            integerInput4.ButtonDropDown.Image = null;
            integerInput4.ButtonDropDown.Text = resources.GetString("integerInput4.ButtonDropDown.Text");
            integerInput4.ButtonFreeText.DisplayPosition = (int)resources.GetObject("integerInput4.ButtonFreeText.DisplayPosition");
            integerInput4.ButtonFreeText.Image = null;
            integerInput4.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            integerInput4.ButtonFreeText.Text = resources.GetString("integerInput4.ButtonFreeText.Text");
            integerInput4.CommandParameter = null;
            integerInput4.DisplayFormat = "0";
            integerInput4.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            integerInput4.IsInputReadOnly = true;
            integerInput4.MinValue = 0;
            integerInput4.Name = "integerInput4";
            integerInput4.Value = 4;
            txtItem3.AccessibleDescription = null;
            txtItem3.AccessibleName = null;
            resources.ApplyResources(txtItem3, "txtItem3");
            txtItem3.BackgroundImage = null;
            txtItem3.ForeColor = System.Drawing.Color.DodgerBlue;
            txtItem3.Name = "txtItem3";
            integerInput3.AccessibleDescription = null;
            integerInput3.AccessibleName = null;
            integerInput3.AllowEmptyState = false;
            resources.ApplyResources(integerInput3, "integerInput3");
            integerInput3.BackgroundImage = null;
            integerInput3.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            integerInput3.BackgroundStyle.Class = "DateTimeInputBackground";
            integerInput3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            integerInput3.ButtonCalculator.DisplayPosition = (int)resources.GetObject("integerInput3.ButtonCalculator.DisplayPosition");
            integerInput3.ButtonCalculator.Image = null;
            integerInput3.ButtonCalculator.Text = resources.GetString("integerInput3.ButtonCalculator.Text");
            integerInput3.ButtonClear.DisplayPosition = (int)resources.GetObject("integerInput3.ButtonClear.DisplayPosition");
            integerInput3.ButtonClear.Image = null;
            integerInput3.ButtonClear.Text = resources.GetString("integerInput3.ButtonClear.Text");
            integerInput3.ButtonCustom.DisplayPosition = (int)resources.GetObject("integerInput3.ButtonCustom.DisplayPosition");
            integerInput3.ButtonCustom.Image = null;
            integerInput3.ButtonCustom.Text = resources.GetString("integerInput3.ButtonCustom.Text");
            integerInput3.ButtonCustom2.DisplayPosition = (int)resources.GetObject("integerInput3.ButtonCustom2.DisplayPosition");
            integerInput3.ButtonCustom2.Image = null;
            integerInput3.ButtonCustom2.Text = resources.GetString("integerInput3.ButtonCustom2.Text");
            integerInput3.ButtonDropDown.DisplayPosition = (int)resources.GetObject("integerInput3.ButtonDropDown.DisplayPosition");
            integerInput3.ButtonDropDown.Image = null;
            integerInput3.ButtonDropDown.Text = resources.GetString("integerInput3.ButtonDropDown.Text");
            integerInput3.ButtonFreeText.DisplayPosition = (int)resources.GetObject("integerInput3.ButtonFreeText.DisplayPosition");
            integerInput3.ButtonFreeText.Image = null;
            integerInput3.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            integerInput3.ButtonFreeText.Text = resources.GetString("integerInput3.ButtonFreeText.Text");
            integerInput3.CommandParameter = null;
            integerInput3.DisplayFormat = "0";
            integerInput3.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            integerInput3.IsInputReadOnly = true;
            integerInput3.MinValue = 0;
            integerInput3.Name = "integerInput3";
            integerInput3.Value = 3;
            txtItem2.AccessibleDescription = null;
            txtItem2.AccessibleName = null;
            resources.ApplyResources(txtItem2, "txtItem2");
            txtItem2.BackgroundImage = null;
            txtItem2.ForeColor = System.Drawing.Color.DodgerBlue;
            txtItem2.Name = "txtItem2";
            txtItem2.Click += new System.EventHandler(txtItem2_Click);
            integerInput2.AccessibleDescription = null;
            integerInput2.AccessibleName = null;
            integerInput2.AllowEmptyState = false;
            resources.ApplyResources(integerInput2, "integerInput2");
            integerInput2.BackgroundImage = null;
            integerInput2.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            integerInput2.BackgroundStyle.Class = "DateTimeInputBackground";
            integerInput2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            integerInput2.ButtonCalculator.DisplayPosition = (int)resources.GetObject("integerInput2.ButtonCalculator.DisplayPosition");
            integerInput2.ButtonCalculator.Image = null;
            integerInput2.ButtonCalculator.Text = resources.GetString("integerInput2.ButtonCalculator.Text");
            integerInput2.ButtonClear.DisplayPosition = (int)resources.GetObject("integerInput2.ButtonClear.DisplayPosition");
            integerInput2.ButtonClear.Image = null;
            integerInput2.ButtonClear.Text = resources.GetString("integerInput2.ButtonClear.Text");
            integerInput2.ButtonCustom.DisplayPosition = (int)resources.GetObject("integerInput2.ButtonCustom.DisplayPosition");
            integerInput2.ButtonCustom.Image = null;
            integerInput2.ButtonCustom.Text = resources.GetString("integerInput2.ButtonCustom.Text");
            integerInput2.ButtonCustom2.DisplayPosition = (int)resources.GetObject("integerInput2.ButtonCustom2.DisplayPosition");
            integerInput2.ButtonCustom2.Image = null;
            integerInput2.ButtonCustom2.Text = resources.GetString("integerInput2.ButtonCustom2.Text");
            integerInput2.ButtonDropDown.DisplayPosition = (int)resources.GetObject("integerInput2.ButtonDropDown.DisplayPosition");
            integerInput2.ButtonDropDown.Image = null;
            integerInput2.ButtonDropDown.Text = resources.GetString("integerInput2.ButtonDropDown.Text");
            integerInput2.ButtonFreeText.DisplayPosition = (int)resources.GetObject("integerInput2.ButtonFreeText.DisplayPosition");
            integerInput2.ButtonFreeText.Image = null;
            integerInput2.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            integerInput2.ButtonFreeText.Text = resources.GetString("integerInput2.ButtonFreeText.Text");
            integerInput2.CommandParameter = null;
            integerInput2.DisplayFormat = "0";
            integerInput2.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            integerInput2.IsInputReadOnly = true;
            integerInput2.MinValue = 0;
            integerInput2.Name = "integerInput2";
            integerInput2.Value = 2;
            txtItem1.AccessibleDescription = null;
            txtItem1.AccessibleName = null;
            resources.ApplyResources(txtItem1, "txtItem1");
            txtItem1.BackgroundImage = null;
            txtItem1.ForeColor = System.Drawing.Color.DodgerBlue;
            txtItem1.Name = "txtItem1";
            txtItem1.Click += new System.EventHandler(txtItem1_Click);
            integerInput1.AccessibleDescription = null;
            integerInput1.AccessibleName = null;
            integerInput1.AllowEmptyState = false;
            resources.ApplyResources(integerInput1, "integerInput1");
            integerInput1.BackgroundImage = null;
            integerInput1.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            integerInput1.BackgroundStyle.Class = "DateTimeInputBackground";
            integerInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            integerInput1.ButtonCalculator.DisplayPosition = (int)resources.GetObject("integerInput1.ButtonCalculator.DisplayPosition");
            integerInput1.ButtonCalculator.Image = null;
            integerInput1.ButtonCalculator.Text = resources.GetString("integerInput1.ButtonCalculator.Text");
            integerInput1.ButtonClear.DisplayPosition = (int)resources.GetObject("integerInput1.ButtonClear.DisplayPosition");
            integerInput1.ButtonClear.Image = null;
            integerInput1.ButtonClear.Text = resources.GetString("integerInput1.ButtonClear.Text");
            integerInput1.ButtonCustom.DisplayPosition = (int)resources.GetObject("integerInput1.ButtonCustom.DisplayPosition");
            integerInput1.ButtonCustom.Image = null;
            integerInput1.ButtonCustom.Text = resources.GetString("integerInput1.ButtonCustom.Text");
            integerInput1.ButtonCustom2.DisplayPosition = (int)resources.GetObject("integerInput1.ButtonCustom2.DisplayPosition");
            integerInput1.ButtonCustom2.Image = null;
            integerInput1.ButtonCustom2.Text = resources.GetString("integerInput1.ButtonCustom2.Text");
            integerInput1.ButtonDropDown.DisplayPosition = (int)resources.GetObject("integerInput1.ButtonDropDown.DisplayPosition");
            integerInput1.ButtonDropDown.Image = null;
            integerInput1.ButtonDropDown.Text = resources.GetString("integerInput1.ButtonDropDown.Text");
            integerInput1.ButtonFreeText.DisplayPosition = (int)resources.GetObject("integerInput1.ButtonFreeText.DisplayPosition");
            integerInput1.ButtonFreeText.Image = null;
            integerInput1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            integerInput1.ButtonFreeText.Text = resources.GetString("integerInput1.ButtonFreeText.Text");
            integerInput1.CommandParameter = null;
            integerInput1.DisplayFormat = "0";
            integerInput1.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            integerInput1.IsInputReadOnly = true;
            integerInput1.MinValue = 0;
            integerInput1.Name = "integerInput1";
            integerInput1.Value = 1;
            base.AccessibleDescription = null;
            base.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            BackgroundImage = null;
            base.Controls.Add(groupPanel5);
            base.Controls.Add(ButExit);
            base.Controls.Add(ButOk);
            base.Controls.Add(groupPanel4);
            base.Controls.Add(groupPanel1);
            Font = null;
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "FrmPointsCalc";
            base.Load += new System.EventHandler(FrmPointsCalc_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Frm_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(Frm_KeyDown);
            groupPanel1.ResumeLayout(false);
            groupPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtTotalPoint).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtTotalPurchaes).EndInit();
            groupPanel4.ResumeLayout(false);
            groupPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtPointOfRyal).EndInit();
            groupPanel5.ResumeLayout(false);
            groupPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)integerInput5).EndInit();
            ((System.ComponentModel.ISupportInitialize)integerInput6).EndInit();
            ((System.ComponentModel.ISupportInitialize)integerInput7).EndInit();
            ((System.ComponentModel.ISupportInitialize)integerInput8).EndInit();
            ((System.ComponentModel.ISupportInitialize)integerInput4).EndInit();
            ((System.ComponentModel.ISupportInitialize)integerInput3).EndInit();
            ((System.ComponentModel.ISupportInitialize)integerInput2).EndInit();
            ((System.ComponentModel.ISupportInitialize)integerInput1).EndInit();
            ResumeLayout(false);
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
        public FrmPointsCalc()
        {
            InitializeComponent();
            txtPointOfRyal.Click += Button_Edit_Click;
            txtItem1.Click += Button_Edit_Click;
            txtItem2.Click += Button_Edit_Click;
            txtItem1E.Click += Button_Edit_Click;
            txtItem2E.Click += Button_Edit_Click;
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                ButOk.Text = "حفظ";
                ButOk.Tooltip = "F2";
                ButExit.Text = "خروج";
                ButExit.Tooltip = "Esc";
                groupPanel1.Text = "تعميم اعدادات النقاط حسب التصنيف";
                button_UpdatePoint.Text = "تحــــديث";
                try
                {
                    labelCurr.Text = db.StockCurencyID(int.Parse(VarGeneral.Settings_Sys.ImportIp)).Arb_Des;
                }
                catch
                {
                }
                Text = "إعدادات نقاط العملاء";
            }
            else
            {
                ButOk.Text = "Save";
                ButExit.Text = "Exit";
                ButOk.Tooltip = "F2";
                ButExit.Tooltip = "Esc";
                groupPanel1.Text = "Circulation of points by classification";
                button_UpdatePoint.Text = "Update";
                try
                {
                    labelCurr.Text = db.StockCurencyID(int.Parse(VarGeneral.Settings_Sys.ImportIp)).Eng_Des;
                }
                catch
                {
                }
                Text = "Points OF Customers Setting";
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
            if (e.KeyCode == Keys.F5 && ButOk.Enabled && ButOk.Visible)
            {
                ButOk_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void FrmPointsCalc_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmPointsCalc));
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
                RibunButtons();
                listInvSetting = db.StockInvSettingList(VarGeneral.UserID);
                _InvSetting = listInvSetting[0];
                _SysSetting = db.SystemSettingStock();
                listCompany = db.StockCompanyList();
                _Company = listCompany[0];
                _GdAuto = db.GdAutoStock();
                listInfotb = db.StockInfoList();
                _Infotb = listInfotb[0];
                try
                {
                    BindData();
                }
                catch
                {
                }
                ChkPointsUse();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void ChkPointsUse()
        {
            try
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_INVHED Left Join  T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  Left Join T_Curency On T_INVHED.CurTyp = T_Curency.Curency_ID Left Join T_CstTbl On T_INVHED.InvCstNo = T_CstTbl.Cst_ID Left Join T_Mndob on T_INVHED.MndNo = T_Mndob.Mnd_Id Left Join T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                string Fields = string.Empty;
                Fields = ((LangArEn != 0) ? " T_INVHED.InvNo" : " T_INVHED.InvNo");
                _RepShow.Rule = " Where ( T_INVHED.InvTyp = 1  ) and  T_INVHED.IfDel != 1 and T_INVHED.IsPoints = 1 and DesPointsValue > 0 and PointsCount > 0 ";
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
                if (VarGeneral.RepData.Tables[0].Rows.Count > 0)
                {
                    txtPointOfRyal.IsInputReadOnly = true;
                }
                else
                {
                    txtTotalPurchaes.IsInputReadOnly = false;
                }
            }
            catch (Exception)
            {
            }
        }
        private void BindData()
        {
            try
            {
                State = FormState.Saved;
                ButOk.Enabled = false;
                txtPointOfRyal.Value = _SysSetting.PointOfRyal.Value;
                txtItem1.Text = _SysSetting.ItemTyp1;
                txtItem2.Text = _SysSetting.ItemTyp2;
                txtItem3.Text = _SysSetting.ItemTyp3;
                txtItem1E.Text = _SysSetting.ItemTyp1E;
                txtItem2E.Text = _SysSetting.ItemTyp2E;
                txtItem3E.Text = _SysSetting.ItemTyp3E;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SaveData()
        {
            try
            {
                db.ExecuteCommand("update T_SYSSETTING set PointOfRyal = " + txtPointOfRyal.Value);
                db.ExecuteCommand("update T_SYSSETTING set ItemTyp1 = '" + txtItem1.Text + "'");
                db.ExecuteCommand("update T_SYSSETTING set ItemTyp2 = '" + txtItem2.Text + "'");
                db.ExecuteCommand("update T_SYSSETTING set ItemTyp3 = '" + txtItem3.Text + "'");
                db.ExecuteCommand("update T_SYSSETTING set ItemTyp1E = '" + txtItem1E.Text + "'");
                db.ExecuteCommand("update T_SYSSETTING set ItemTyp2E = '" + txtItem2E.Text + "'");
                db.ExecuteCommand("update T_SYSSETTING set ItemTyp3E = '" + txtItem3E.Text + "'");
                using (Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS))
                {
                    VarGeneral.Settings_Sys = new T_SYSSETTING();
                    VarGeneral.Settings_Sys = dbc.SystemSettingStock();
                    VarGeneral._SysDirPath = VarGeneral.Settings_Sys.SysDir;
                    VarGeneral._BackPath = VarGeneral.Settings_Sys.BackPath;
                    try
                    {
                        VarGeneral._AutoSync = VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 41);
                    }
                    catch
                    {
                        VarGeneral._AutoSync = false;
                    }
                }
                MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Close();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtItem1.Text) || string.IsNullOrEmpty(txtItem1E.Text) || string.IsNullOrEmpty(txtItem2.Text) || string.IsNullOrEmpty(txtItem2E.Text))
            {
                MessageBox.Show((LangArEn == 0) ? "يجب التأكد من صحة أنواع الأصناف" : "Validation of varieties of varieties", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            SaveData();
            State = FormState.Saved;
            SetReadOnly = true;
        }
        private void ButExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void txtItem1_Click(object sender, EventArgs e)
        {
            txtItem1.SelectAll();
        }
        private void txtItem2_Click(object sender, EventArgs e)
        {
            txtItem2.SelectAll();
        }
        private void txtItem1E_Click(object sender, EventArgs e)
        {
            txtItem1E.SelectAll();
        }
        private void txtItem2E_Click(object sender, EventArgs e)
        {
            txtItem2E.SelectAll();
        }
        private void button_SrchItemGroup_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("CAT_No", new ColumnDictinary("الرمـــز", "CATEGORY No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_CATEGORY";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                txtClassNo.Text = db.StockCat(frm.Serach_No).CAT_ID.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    txtClassName.Text = db.StockCat(frm.Serach_No).Arb_Des;
                }
                else
                {
                    txtClassName.Text = db.StockCat(frm.Serach_No).Eng_Des;
                }
                ChkPointsUseGroup();
            }
            else
            {
                txtClassNo.Text = string.Empty;
                txtClassName.Text = string.Empty;
            }
        }
        private void ChkPointsUseGroup()
        {
            try
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = "T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                string Fields = " T_INVHED.CusVenNo,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Arb_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNm,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Eng_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNmE, InvDet_ID,T_Items.Itm_No,T_Items.Arb_Des as itemNm,T_Category.Arb_Des as CategoyNm,T_InvDet.StoreNo,T_InvDet.ItmUnt as UnitNm,(Round(T_InvDet.Price," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Price,T_InvDet.ItmDis,Abs(T_INVDET.Qty) as Qty,Abs(T_INVDET.RealQty) as RealQty,(Round(T_InvDet.Amount," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Amount,(Round(T_InvDet.Cost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Cost,T_INVHED.InvNo, T_INVSETTING.InvNamA as InvTypNm,T_INVHED.InvCash,T_Curency.Arb_Des as CurrnceyNm,T_INVHED.GadeNo, T_Mndob.Arb_Des as MndNm,T_INVHED.RetNo,T_SYSSETTING.LogImg";
                _RepShow.Rule = " Where T_CATEGORY.CAT_ID = " + txtClassNo.Text + " and T_Items.IsPoints = 1 and T_CATEGORY.TotalPurchaes > 0 and T_CATEGORY.TotalPoint > 0 and ( T_INVHED.InvTyp = 1 or T_INVHED.InvTyp = 3 ) and  T_INVHED.IfDel != 1 and T_INVHED.IsPoints = 1 and DesPointsValue > 0 and PointsCount > 0  order by T_INVHED.InvTyp, T_INVHED.InvHed_ID";
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
                if (VarGeneral.RepData.Tables[0].Rows.Count > 0)
                {
                    txtTotalPurchaes.IsInputReadOnly = true;
                    txtTotalPoint.IsInputReadOnly = true;
                }
                else
                {
                    txtTotalPurchaes.IsInputReadOnly = false;
                    txtTotalPoint.IsInputReadOnly = false;
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }
        private void button_UpdatePoint_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtTotalPurchaes.IsInputReadOnly && !txtTotalPoint.IsInputReadOnly && MessageBox.Show("سيتم تحديث اعدادات نقاط الاصناف التابعة للتصنيف .. هل حقا تريد المتابعة ؟ \n The ratings of the labels will be updated. Do you really want to continue ?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.ExecuteCommand("UPDATE [T_CATEGORY] SET [TotalPurchaes] = " + txtTotalPurchaes.Value + " ,[TotalPoint] = " + txtTotalPoint.Value + ((!string.IsNullOrEmpty(txtClassNo.Text)) ? (" Where CAT_No = '" + txtClassNo.Text + "'") : " "));
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_UpdatePoint_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
    }
}
