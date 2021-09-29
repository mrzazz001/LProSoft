using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmCustomerDisplay : Form
    {
        public class ColumnDictinaryCusDis
        {
            public string AText = "";
            public string EText = "";
            public bool IfDefault = false;
            public string Format = "";
            public ColumnDictinaryCusDis(string aText, string eText, bool ifDefault, string format)
            {
                AText = aText;
                EText = eText;
                IfDefault = ifDefault;
                Format = format;
            }
        }
        private IContainer components = null;
        private GroupPanel groupPanel_Main;
        private CheckBoxX chkIsActive;
        private Label label8CustDis;
        private ComboBoxEx cmbPort;
        private Label label1CustDis;
        private ComboBoxEx cmbFast;
        private GroupPanel groupPanel1CustDis;
        private CheckBoxX chkStop1;
        private GroupPanel groupPanel2CustDis;
        private CheckBoxX chkData3;
        private CheckBoxX chkData2;
        private CheckBoxX chkData1;
        private CheckBoxX chkStop3;
        private CheckBoxX chkStop2;
        private GroupPanel groupPanel3CustDis;
        private CheckBoxX chkSync5;
        private CheckBoxX chkSync4;
        private CheckBoxX chkSync3;
        private CheckBoxX chkSync2;
        private CheckBoxX chkSync1;
        private CheckBoxX chkData5;
        private CheckBoxX chkData4;
        private TextBox txtHello;
        private Label label14CustDis;
        private ButtonX button_CheckConn;
        private ButtonX ButWithoutSave;
        private ButtonX ButWithSave;
        private Label label2custDis;
        private ComboBoxEx cmbShowState;
        public Dictionary<string, ColumnDictinaryCusDis> columns_Names_visibleCustDis = new Dictionary<string, ColumnDictinaryCusDis>();
        private List<T_INVSETTING> listInvSettingCustDis = new List<T_INVSETTING>();
        private T_INVSETTING _InvSettingCustDis = new T_INVSETTING();
        private List<T_SYSSETTING> listSysSettingCustDis = new List<T_SYSSETTING>();
        private T_SYSSETTING _SysSettingCustDis = new T_SYSSETTING();
        private List<T_AccDef> listAccDefCustDis = new List<T_AccDef>();
        private T_AccDef _AccDefCustDis = new T_AccDef();
        private List<T_Company> listCompanyCustDis = new List<T_Company>();
        private T_Company _CompanyCustDis = new T_Company();
        private List<T_GdAuto> listGdAutoCustDis = new List<T_GdAuto>();
        private T_GdAuto _GdAutoCustDis = new T_GdAuto();
        private List<T_InfoTb> listInfotbCustDis = new List<T_InfoTb>();
        private T_InfoTb _InfotbCustDis = new T_InfoTb();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomerDisplay));
            this.groupPanel_Main = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label2custDis = new System.Windows.Forms.Label();
            this.cmbShowState = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.button_CheckConn = new DevComponents.DotNetBar.ButtonX();
            this.txtHello = new System.Windows.Forms.TextBox();
            this.label14CustDis = new System.Windows.Forms.Label();
            this.groupPanel3CustDis = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.chkSync5 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkSync4 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkSync3 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkSync2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkSync1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.groupPanel2CustDis = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.chkData5 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkData4 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkData3 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkData2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkData1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.groupPanel1CustDis = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.chkStop3 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkStop2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkStop1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label1CustDis = new System.Windows.Forms.Label();
            this.cmbFast = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label8CustDis = new System.Windows.Forms.Label();
            this.cmbPort = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.chkIsActive = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.ButWithoutSave = new DevComponents.DotNetBar.ButtonX();
            this.ButWithSave = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel_Main.SuspendLayout();
            this.groupPanel3CustDis.SuspendLayout();
            this.groupPanel2CustDis.SuspendLayout();
            this.groupPanel1CustDis.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel_Main
            // 
            this.groupPanel_Main.BackColor = System.Drawing.Color.Gainsboro;
            this.groupPanel_Main.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel_Main.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel_Main.Controls.Add(this.label2custDis);
            this.groupPanel_Main.Controls.Add(this.cmbShowState);
            this.groupPanel_Main.Controls.Add(this.button_CheckConn);
            this.groupPanel_Main.Controls.Add(this.txtHello);
            this.groupPanel_Main.Controls.Add(this.label14CustDis);
            this.groupPanel_Main.Controls.Add(this.groupPanel3CustDis);
            this.groupPanel_Main.Controls.Add(this.groupPanel2CustDis);
            this.groupPanel_Main.Controls.Add(this.groupPanel1CustDis);
            this.groupPanel_Main.Controls.Add(this.label1CustDis);
            this.groupPanel_Main.Controls.Add(this.cmbFast);
            this.groupPanel_Main.Controls.Add(this.label8CustDis);
            this.groupPanel_Main.Controls.Add(this.cmbPort);
            this.groupPanel_Main.Enabled = false;
            this.groupPanel_Main.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupPanel_Main.Location = new System.Drawing.Point(5, 52);
            this.groupPanel_Main.Name = "groupPanel_Main";
            this.groupPanel_Main.Size = new System.Drawing.Size(457, 246);
            // 
            // 
            // 
            this.groupPanel_Main.Style.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupPanel_Main.Style.BackColorGradientAngle = 90;
            this.groupPanel_Main.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel_Main.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Main.Style.BorderBottomWidth = 1;
            this.groupPanel_Main.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel_Main.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Main.Style.BorderLeftWidth = 1;
            this.groupPanel_Main.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Main.Style.BorderRightWidth = 1;
            this.groupPanel_Main.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel_Main.Style.BorderTopWidth = 1;
            this.groupPanel_Main.Style.CornerDiameter = 4;
            this.groupPanel_Main.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel_Main.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel_Main.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel_Main.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel_Main.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel_Main.TabIndex = 977;
            // 
            // label2custDis
            // 
            this.label2custDis.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2custDis.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2custDis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2custDis.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2custDis.Location = new System.Drawing.Point(334, 217);
            this.label2custDis.Name = "label2custDis";
            this.label2custDis.Size = new System.Drawing.Size(105, 20);
            this.label2custDis.TabIndex = 994;
            this.label2custDis.Text = "طريقة العرض";
            this.label2custDis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbShowState
            // 
            this.cmbShowState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbShowState.DisplayMember = "Text";
            this.cmbShowState.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbShowState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShowState.FocusHighlightColor = System.Drawing.Color.Empty;
            this.cmbShowState.FormattingEnabled = true;
            this.cmbShowState.ItemHeight = 14;
            this.cmbShowState.Location = new System.Drawing.Point(114, 217);
            this.cmbShowState.Name = "cmbShowState";
            this.cmbShowState.Size = new System.Drawing.Size(218, 20);
            this.cmbShowState.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbShowState.TabIndex = 993;
            // 
            // button_CheckConn
            // 
            this.button_CheckConn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_CheckConn.Checked = true;
            this.button_CheckConn.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.button_CheckConn.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button_CheckConn.Location = new System.Drawing.Point(12, 191);
            this.button_CheckConn.Name = "button_CheckConn";
            this.button_CheckConn.Size = new System.Drawing.Size(100, 46);
            this.button_CheckConn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_CheckConn.Symbol = "";
            this.button_CheckConn.SymbolSize = 13F;
            this.button_CheckConn.TabIndex = 991;
            this.button_CheckConn.Text = "إختبــــار";
            this.button_CheckConn.TextColor = System.Drawing.Color.SteelBlue;
            this.button_CheckConn.Click += new System.EventHandler(this.button_CheckConn_Click);
            // 
            // txtHello
            // 
            this.txtHello.BackColor = System.Drawing.Color.White;
            this.txtHello.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHello.Location = new System.Drawing.Point(114, 191);
            this.txtHello.MaxLength = 50;
            this.txtHello.Name = "txtHello";
            this.txtHello.Size = new System.Drawing.Size(218, 20);
            this.txtHello.TabIndex = 980;
            this.txtHello.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHello.Click += new System.EventHandler(this.txtHello_Click);
            // 
            // label14CustDis
            // 
            this.label14CustDis.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label14CustDis.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14CustDis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label14CustDis.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14CustDis.Location = new System.Drawing.Point(334, 191);
            this.label14CustDis.Name = "label14CustDis";
            this.label14CustDis.Size = new System.Drawing.Size(105, 20);
            this.label14CustDis.TabIndex = 981;
            this.label14CustDis.Text = "رسالة ترحيبية";
            this.label14CustDis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupPanel3CustDis
            // 
            this.groupPanel3CustDis.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel3CustDis.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3CustDis.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3CustDis.Controls.Add(this.chkSync5);
            this.groupPanel3CustDis.Controls.Add(this.chkSync4);
            this.groupPanel3CustDis.Controls.Add(this.chkSync3);
            this.groupPanel3CustDis.Controls.Add(this.chkSync2);
            this.groupPanel3CustDis.Controls.Add(this.chkSync1);
            this.groupPanel3CustDis.Location = new System.Drawing.Point(12, 48);
            this.groupPanel3CustDis.Name = "groupPanel3CustDis";
            this.groupPanel3CustDis.Size = new System.Drawing.Size(101, 135);
            // 
            // 
            // 
            this.groupPanel3CustDis.Style.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupPanel3CustDis.Style.BackColorGradientAngle = 90;
            this.groupPanel3CustDis.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3CustDis.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3CustDis.Style.BorderBottomWidth = 1;
            this.groupPanel3CustDis.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3CustDis.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3CustDis.Style.BorderLeftWidth = 1;
            this.groupPanel3CustDis.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3CustDis.Style.BorderRightWidth = 1;
            this.groupPanel3CustDis.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3CustDis.Style.BorderTopWidth = 1;
            this.groupPanel3CustDis.Style.CornerDiameter = 4;
            this.groupPanel3CustDis.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3CustDis.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3CustDis.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel3CustDis.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3CustDis.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3CustDis.TabIndex = 979;
            this.groupPanel3CustDis.Text = "التمـــاثل";
            // 
            // chkSync5
            // 
            this.chkSync5.AutoSize = true;
            this.chkSync5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkSync5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkSync5.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkSync5.Location = new System.Drawing.Point(13, 90);
            this.chkSync5.Name = "chkSync5";
            this.chkSync5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkSync5.Size = new System.Drawing.Size(58, 15);
            this.chkSync5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkSync5.TabIndex = 980;
            this.chkSync5.Text = "مسافة";
            // 
            // chkSync4
            // 
            this.chkSync4.AutoSize = true;
            this.chkSync4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkSync4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkSync4.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkSync4.Location = new System.Drawing.Point(20, 69);
            this.chkSync4.Name = "chkSync4";
            this.chkSync4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkSync4.Size = new System.Drawing.Size(51, 15);
            this.chkSync4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkSync4.TabIndex = 979;
            this.chkSync4.Text = "علامة";
            // 
            // chkSync3
            // 
            this.chkSync3.AutoSize = true;
            this.chkSync3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkSync3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkSync3.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkSync3.Location = new System.Drawing.Point(37, 48);
            this.chkSync3.Name = "chkSync3";
            this.chkSync3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkSync3.Size = new System.Drawing.Size(34, 15);
            this.chkSync3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkSync3.TabIndex = 978;
            this.chkSync3.Text = "بلا";
            // 
            // chkSync2
            // 
            this.chkSync2.AutoSize = true;
            this.chkSync2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkSync2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkSync2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkSync2.Location = new System.Drawing.Point(17, 27);
            this.chkSync2.Name = "chkSync2";
            this.chkSync2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkSync2.Size = new System.Drawing.Size(53, 15);
            this.chkSync2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkSync2.TabIndex = 977;
            this.chkSync2.Text = "زوجي";
            // 
            // chkSync1
            // 
            this.chkSync1.AutoSize = true;
            this.chkSync1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkSync1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkSync1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkSync1.Location = new System.Drawing.Point(21, 6);
            this.chkSync1.Name = "chkSync1";
            this.chkSync1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkSync1.Size = new System.Drawing.Size(50, 15);
            this.chkSync1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkSync1.TabIndex = 976;
            this.chkSync1.Text = "فردي";
            // 
            // groupPanel2CustDis
            // 
            this.groupPanel2CustDis.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2CustDis.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2CustDis.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2CustDis.Controls.Add(this.chkData5);
            this.groupPanel2CustDis.Controls.Add(this.chkData4);
            this.groupPanel2CustDis.Controls.Add(this.chkData3);
            this.groupPanel2CustDis.Controls.Add(this.chkData2);
            this.groupPanel2CustDis.Controls.Add(this.chkData1);
            this.groupPanel2CustDis.Location = new System.Drawing.Point(174, 48);
            this.groupPanel2CustDis.Name = "groupPanel2CustDis";
            this.groupPanel2CustDis.Size = new System.Drawing.Size(101, 135);
            // 
            // 
            // 
            this.groupPanel2CustDis.Style.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupPanel2CustDis.Style.BackColorGradientAngle = 90;
            this.groupPanel2CustDis.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2CustDis.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2CustDis.Style.BorderBottomWidth = 1;
            this.groupPanel2CustDis.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2CustDis.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2CustDis.Style.BorderLeftWidth = 1;
            this.groupPanel2CustDis.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2CustDis.Style.BorderRightWidth = 1;
            this.groupPanel2CustDis.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2CustDis.Style.BorderTopWidth = 1;
            this.groupPanel2CustDis.Style.CornerDiameter = 4;
            this.groupPanel2CustDis.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2CustDis.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2CustDis.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel2CustDis.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2CustDis.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2CustDis.TabIndex = 978;
            this.groupPanel2CustDis.Text = "البيــانات";
            // 
            // chkData5
            // 
            this.chkData5.AutoSize = true;
            this.chkData5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkData5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkData5.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkData5.Location = new System.Drawing.Point(31, 90);
            this.chkData5.Name = "chkData5";
            this.chkData5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkData5.Size = new System.Drawing.Size(29, 15);
            this.chkData5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkData5.TabIndex = 980;
            this.chkData5.Text = "8";
            // 
            // chkData4
            // 
            this.chkData4.AutoSize = true;
            this.chkData4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkData4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkData4.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkData4.Location = new System.Drawing.Point(31, 69);
            this.chkData4.Name = "chkData4";
            this.chkData4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkData4.Size = new System.Drawing.Size(29, 15);
            this.chkData4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkData4.TabIndex = 979;
            this.chkData4.Text = "7";
            // 
            // chkData3
            // 
            this.chkData3.AutoSize = true;
            this.chkData3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkData3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkData3.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkData3.Location = new System.Drawing.Point(32, 48);
            this.chkData3.Name = "chkData3";
            this.chkData3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkData3.Size = new System.Drawing.Size(29, 15);
            this.chkData3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkData3.TabIndex = 978;
            this.chkData3.Text = "6";
            // 
            // chkData2
            // 
            this.chkData2.AutoSize = true;
            this.chkData2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkData2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkData2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkData2.Location = new System.Drawing.Point(32, 27);
            this.chkData2.Name = "chkData2";
            this.chkData2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkData2.Size = new System.Drawing.Size(29, 15);
            this.chkData2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkData2.TabIndex = 977;
            this.chkData2.Text = "5";
            // 
            // chkData1
            // 
            this.chkData1.AutoSize = true;
            this.chkData1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkData1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkData1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkData1.Location = new System.Drawing.Point(32, 6);
            this.chkData1.Name = "chkData1";
            this.chkData1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkData1.Size = new System.Drawing.Size(29, 15);
            this.chkData1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkData1.TabIndex = 976;
            this.chkData1.Text = "4";
            // 
            // groupPanel1CustDis
            // 
            this.groupPanel1CustDis.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1CustDis.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1CustDis.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1CustDis.Controls.Add(this.chkStop3);
            this.groupPanel1CustDis.Controls.Add(this.chkStop2);
            this.groupPanel1CustDis.Controls.Add(this.chkStop1);
            this.groupPanel1CustDis.Location = new System.Drawing.Point(336, 48);
            this.groupPanel1CustDis.Name = "groupPanel1CustDis";
            this.groupPanel1CustDis.Size = new System.Drawing.Size(101, 135);
            // 
            // 
            // 
            this.groupPanel1CustDis.Style.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupPanel1CustDis.Style.BackColorGradientAngle = 90;
            this.groupPanel1CustDis.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1CustDis.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1CustDis.Style.BorderBottomWidth = 1;
            this.groupPanel1CustDis.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1CustDis.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1CustDis.Style.BorderLeftWidth = 1;
            this.groupPanel1CustDis.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1CustDis.Style.BorderRightWidth = 1;
            this.groupPanel1CustDis.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1CustDis.Style.BorderTopWidth = 1;
            this.groupPanel1CustDis.Style.CornerDiameter = 4;
            this.groupPanel1CustDis.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1CustDis.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1CustDis.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            // 
            // 
            // 
            this.groupPanel1CustDis.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1CustDis.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1CustDis.TabIndex = 977;
            this.groupPanel1CustDis.Text = "التــوقـف";
            // 
            // chkStop3
            // 
            this.chkStop3.AutoSize = true;
            this.chkStop3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkStop3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkStop3.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkStop3.Location = new System.Drawing.Point(32, 83);
            this.chkStop3.Name = "chkStop3";
            this.chkStop3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkStop3.Size = new System.Drawing.Size(29, 15);
            this.chkStop3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkStop3.TabIndex = 978;
            this.chkStop3.Text = "2";
            // 
            // chkStop2
            // 
            this.chkStop2.AutoSize = true;
            this.chkStop2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkStop2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkStop2.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkStop2.Location = new System.Drawing.Point(22, 47);
            this.chkStop2.Name = "chkStop2";
            this.chkStop2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkStop2.Size = new System.Drawing.Size(39, 15);
            this.chkStop2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkStop2.TabIndex = 977;
            this.chkStop2.Text = "1.5";
            // 
            // chkStop1
            // 
            this.chkStop1.AutoSize = true;
            this.chkStop1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkStop1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkStop1.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.chkStop1.Location = new System.Drawing.Point(32, 11);
            this.chkStop1.Name = "chkStop1";
            this.chkStop1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkStop1.Size = new System.Drawing.Size(29, 15);
            this.chkStop1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkStop1.TabIndex = 976;
            this.chkStop1.Text = "1";
            // 
            // label1CustDis
            // 
            this.label1CustDis.AutoSize = true;
            this.label1CustDis.BackColor = System.Drawing.Color.Transparent;
            this.label1CustDis.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label1CustDis.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1CustDis.Location = new System.Drawing.Point(134, 18);
            this.label1CustDis.Name = "label1CustDis";
            this.label1CustDis.Size = new System.Drawing.Size(56, 13);
            this.label1CustDis.TabIndex = 969;
            this.label1CustDis.Text = "الســرعة :";
            this.label1CustDis.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cmbFast
            // 
            this.cmbFast.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFast.DisplayMember = "Text";
            this.cmbFast.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFast.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFast.FocusHighlightColor = System.Drawing.Color.Empty;
            this.cmbFast.FormattingEnabled = true;
            this.cmbFast.ItemHeight = 14;
            this.cmbFast.Location = new System.Drawing.Point(14, 14);
            this.cmbFast.Name = "cmbFast";
            this.cmbFast.Size = new System.Drawing.Size(116, 20);
            this.cmbFast.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbFast.TabIndex = 970;
            // 
            // label8CustDis
            // 
            this.label8CustDis.AutoSize = true;
            this.label8CustDis.BackColor = System.Drawing.Color.Transparent;
            this.label8CustDis.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label8CustDis.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8CustDis.Location = new System.Drawing.Point(390, 18);
            this.label8CustDis.Name = "label8CustDis";
            this.label8CustDis.Size = new System.Drawing.Size(52, 13);
            this.label8CustDis.TabIndex = 967;
            this.label8CustDis.Text = "المنفـــذ :";
            this.label8CustDis.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cmbPort
            // 
            this.cmbPort.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPort.DisplayMember = "Text";
            this.cmbPort.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPort.FocusHighlightColor = System.Drawing.Color.Empty;
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.ItemHeight = 14;
            this.cmbPort.Location = new System.Drawing.Point(270, 14);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(116, 20);
            this.cmbPort.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbPort.TabIndex = 968;
            // 
            // chkIsActive
            // 
            this.chkIsActive.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkIsActive.BackgroundStyle.BorderBottomWidth = 1;
            this.chkIsActive.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionBackground2;
            this.chkIsActive.BackgroundStyle.BorderLeftWidth = 1;
            this.chkIsActive.BackgroundStyle.BorderRightWidth = 1;
            this.chkIsActive.BackgroundStyle.BorderTopWidth = 1;
            this.chkIsActive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkIsActive.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            this.chkIsActive.CheckSignSize = new System.Drawing.Size(15, 15);
            this.chkIsActive.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.chkIsActive.Location = new System.Drawing.Point(4, 8);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIsActive.Size = new System.Drawing.Size(459, 40);
            this.chkIsActive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkIsActive.TabIndex = 978;
            this.chkIsActive.Text = "تفعيل شاشة الــزبــون";
            this.chkIsActive.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.chkIsActive.CheckedChanged += new System.EventHandler(this.chkIsActive_CheckedChanged);
            // 
            // ButWithoutSave
            // 
            this.ButWithoutSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButWithoutSave.Checked = true;
            this.ButWithoutSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ButWithoutSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButWithoutSave.Location = new System.Drawing.Point(5, 301);
            this.ButWithoutSave.Name = "ButWithoutSave";
            this.ButWithoutSave.Size = new System.Drawing.Size(227, 32);
            this.ButWithoutSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButWithoutSave.Symbol = "";
            this.ButWithoutSave.SymbolSize = 16F;
            this.ButWithoutSave.TabIndex = 6789;
            this.ButWithoutSave.Text = "خـــروج";
            this.ButWithoutSave.TextColor = System.Drawing.Color.Black;
            this.ButWithoutSave.Click += new System.EventHandler(this.ButWithoutSave_Click);
            // 
            // ButWithSave
            // 
            this.ButWithSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButWithSave.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.ButWithSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButWithSave.Location = new System.Drawing.Point(235, 301);
            this.ButWithSave.Name = "ButWithSave";
            this.ButWithSave.Size = new System.Drawing.Size(227, 32);
            this.ButWithSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButWithSave.Symbol = "";
            this.ButWithSave.SymbolSize = 16F;
            this.ButWithSave.TabIndex = 6788;
            this.ButWithSave.Text = "حفــــظ";
            this.ButWithSave.TextColor = System.Drawing.Color.White;
            this.ButWithSave.Click += new System.EventHandler(this.ButWithSave_Click);
            // 
            // FrmCustomerDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(464, 334);
            this.ControlBox = false;
            this.Controls.Add(this.ButWithoutSave);
            this.Controls.Add(this.ButWithSave);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.groupPanel_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.KeyPreview = true;
            this.Name = "FrmCustomerDisplay";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "شاشة الزبون";
            this.Load += new System.EventHandler(this.FrmCustomerDisplay_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCustomerDisplay_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmCustomerDisplay_KeyPress);
            this.groupPanel_Main.ResumeLayout(false);
            this.groupPanel_Main.PerformLayout();
            this.groupPanel3CustDis.ResumeLayout(false);
            this.groupPanel3CustDis.PerformLayout();
            this.groupPanel2CustDis.ResumeLayout(false);
            this.groupPanel2CustDis.PerformLayout();
            this.groupPanel1CustDis.ResumeLayout(false);
            this.groupPanel1CustDis.PerformLayout();
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.ResumeLayout(false);
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
        public FrmCustomerDisplay()
        {
            InitializeComponent();
            cmbPort.Click += Button_Edit_Click;
            cmbFast.Click += Button_Edit_Click;
            cmbShowState.Click += Button_Edit_Click;
            chkStop1.Click += Button_Edit_Click;
            chkStop2.Click += Button_Edit_Click;
            chkStop3.Click += Button_Edit_Click;
            chkData1.Click += Button_Edit_Click;
            chkData2.Click += Button_Edit_Click;
            chkData3.Click += Button_Edit_Click;
            chkData4.Click += Button_Edit_Click;
            chkData5.Click += Button_Edit_Click;
            chkSync1.Click += Button_Edit_Click;
            chkSync2.Click += Button_Edit_Click;
            chkSync3.Click += Button_Edit_Click;
            chkSync4.Click += Button_Edit_Click;
            chkSync5.Click += Button_Edit_Click;
            txtHello.Click += Button_Edit_Click;
            chkIsActive.Click += Button_Edit_Click;
        }
        private void RibunButtonsCustDis()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ButWithSave.Text = "حفظ";
                ButWithSave.Tooltip = "F2";
                ButWithoutSave.Text = "خروج";
                ButWithoutSave.Tooltip = "Esc";
                chkIsActive.Text = "تفعيل شاشة الــزبــون";
                groupPanel1CustDis.Text = "التــوقـف";
                groupPanel2CustDis.Text = "البيــانات";
                groupPanel3CustDis.Text = "التمـــاثل";
                chkSync1.Text = "فردي";
                chkSync2.Text = "زوجي";
                chkSync3.Text = "بلا";
                chkSync4.Text = "علامة";
                chkSync5.Text = "مسافة";
                button_CheckConn.Text = "إختبــــار";
                Text = "شـاشـة الــزيــون";
            }
            else
            {
                ButWithSave.Text = "Save";
                ButWithoutSave.Text = "Exit";
                ButWithSave.Tooltip = "F2";
                ButWithoutSave.Tooltip = "Esc";
                chkIsActive.Text = "Custome Display Active";
                groupPanel1CustDis.Text = "Bit Stop";
                groupPanel2CustDis.Text = "Bit Data";
                groupPanel3CustDis.Text = "Parity";
                chkSync1.Text = "Single";
                chkSync2.Text = "Double";
                chkSync3.Text = "None";
                chkSync4.Text = "sign";
                chkSync5.Text = "Space";
                button_CheckConn.Text = "Check";
                Text = "Customer Display";
            }
        }
        private void FrmCustomerDisplay_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmCustomerDisplay));
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
                RibunButtonsCustDis();
                listInvSettingCustDis = db.StockInvSettingList(VarGeneral.UserID);
                _InvSettingCustDis = listInvSettingCustDis[0];
                _SysSettingCustDis = db.SystemSettingStock();
                listCompanyCustDis = db.StockCompanyList();
                _CompanyCustDis = listCompanyCustDis[0];
                _GdAutoCustDis = db.GdAutoStock();
                listInfotbCustDis = db.StockInfoList();
                _InfotbCustDis = listInfotbCustDis[0];
                listAccDefCustDis = db.FillAccDef_2("").ToList();
                listAccDefCustDis = listAccDefCustDis.Where((T_AccDef q) => q.Trn == 3 && q.Lev == 4 && q.AccDef_No.StartsWith("1") && q.AccCat != 2 && q.AccCat != 3).ToList();
                try
                {
                    FillComboCustDis();
                }
                catch
                {
                }
                try
                {
                    BindDataCustDis();
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
        private void FillComboCustDis()
        {
            cmbPort.Items.Clear();
            cmbPort.Items.Add("COM1");
            cmbPort.Items.Add("COM2");
            cmbPort.Items.Add("COM3");
            cmbPort.Items.Add("COM4");
            cmbPort.Items.Add("COM5");
            cmbPort.Items.Add("COM6");
            cmbPort.Items.Add("COM7");
            cmbPort.Items.Add("COM8");
            cmbPort.Items.Add("COM9");
            cmbPort.Items.Add("COM10");
            cmbPort.Items.Add("COM11");
            cmbPort.Items.Add("COM12");
            cmbPort.Items.Add("COM13");
            cmbPort.Items.Add("COM14");
            cmbPort.Items.Add("COM15");
            cmbPort.Items.Add("USB");
            cmbPort.Items.Add("USB1");
            cmbPort.Items.Add("USB2");
            cmbPort.Items.Add("USB3");
            cmbPort.Items.Add("USB4");
            cmbPort.Items.Add("USB5");
            cmbPort.Items.Add("USB6");
            cmbPort.SelectedIndex = 0;
            cmbFast.Items.Clear();
            cmbFast.Items.Add("110");
            cmbFast.Items.Add("300");
            cmbFast.Items.Add("600");
            cmbFast.Items.Add("1200");
            cmbFast.Items.Add("2400");
            cmbFast.Items.Add("9600");
            cmbFast.Items.Add("14400");
            cmbFast.Items.Add("19200");
            cmbFast.Items.Add("28800");
            cmbFast.Items.Add("38400");
            cmbFast.Items.Add("56000");
            cmbFast.Items.Add("128000");
            cmbFast.Items.Add("256000");
            cmbFast.SelectedIndex = 0;
            cmbShowState.Items.Clear();
            cmbShowState.Items.Add((LangArEn == 0) ? "الكـــــــل" : "ALL");
            cmbShowState.Items.Add((LangArEn == 0) ? "السعــر فقط" : "Only Price");
            cmbShowState.Items.Add((LangArEn == 0) ? "الإجمالي فقط" : "Only Total");
            cmbShowState.SelectedIndex = 0;
        }
        private void BindDataCustDis()
        {
            chkIsActive.CheckedChanged -= chkIsActive_CheckedChanged;
            try
            {
                State = FormState.Saved;
                ButWithSave.Enabled = false;
                chkIsActive.Checked = _SysSettingCustDis.IsCustomerDisplay.Value;
                cmbPort.Text = _SysSettingCustDis.Port;
                cmbFast.Text = _SysSettingCustDis.Fast.Value.ToString();
                cmbShowState.SelectedIndex = _SysSettingCustDis.DisplayTypeShow.Value;
                if (_SysSettingCustDis.BitStop.Value == 1)
                {
                    chkStop1.Checked = true;
                }
                else if (_SysSettingCustDis.BitStop.Value == 2)
                {
                    chkStop2.Checked = true;
                }
                else
                {
                    chkStop3.Checked = true;
                }
                if (_SysSettingCustDis.BitData.Value == 4)
                {
                    chkData1.Checked = true;
                }
                else if (_SysSettingCustDis.BitData.Value == 5)
                {
                    chkData2.Checked = true;
                }
                else if (_SysSettingCustDis.BitData.Value == 6)
                {
                    chkData3.Checked = true;
                }
                else if (_SysSettingCustDis.BitData.Value == 7)
                {
                    chkData4.Checked = true;
                }
                else
                {
                    chkData5.Checked = true;
                }
                if (_SysSettingCustDis.Parity.Value == 1)
                {
                    chkSync1.Checked = true;
                }
                else if (_SysSettingCustDis.Parity.Value == 2)
                {
                    chkSync2.Checked = true;
                }
                else if (_SysSettingCustDis.Parity.Value == 3)
                {
                    chkSync3.Checked = true;
                }
                else if (_SysSettingCustDis.Parity.Value == 4)
                {
                    chkSync4.Checked = true;
                }
                else
                {
                    chkSync5.Checked = true;
                }
                txtHello.Text = _SysSettingCustDis.CustomerHello;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            chkIsActive.CheckedChanged += chkIsActive_CheckedChanged;
            chkIsActive_CheckedChanged(null, null);
        }
        private void SaveDataCustDis()
        {
            try
            {
                db.ExecuteCommand("update T_SYSSETTING set IsCustomerDisplay = " + (chkIsActive.Checked ? 1 : 0));
                db.ExecuteCommand("update T_SYSSETTING set Port = '" + cmbPort.Text + "'");
                db.ExecuteCommand("update T_SYSSETTING set Fast = " + cmbFast.Text);
                db.ExecuteCommand("update T_SYSSETTING set DisplayTypeShow = " + cmbShowState.SelectedIndex);
                db.ExecuteCommand("update T_SYSSETTING set BitStop = " + (chkStop1.Checked ? 1 : (chkStop2.Checked ? 2 : 3)));
                db.ExecuteCommand("update T_SYSSETTING set BitData = " + (chkData1.Checked ? 4 : (chkData2.Checked ? 5 : (chkData3.Checked ? 6 : (chkData4.Checked ? 7 : 8)))));
                db.ExecuteCommand("update T_SYSSETTING set Parity = " + (chkSync1.Checked ? 1 : (chkSync2.Checked ? 2 : (chkSync3.Checked ? 3 : (chkSync4.Checked ? 4 : 5)))));
                db.ExecuteCommand("update T_SYSSETTING set CustomerHello = '" + txtHello.Text + "'");
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
        private void ButWithSave_Click(object sender, EventArgs e)
        {
            SaveDataCustDis();
            State = FormState.Saved;
            SetReadOnly = true;
        }
        private void ButWithoutSave_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void FrmCustomerDisplay_KeyDown(object sender, KeyEventArgs e)
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
        private void FrmCustomerDisplay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsActive.Checked)
            {
                groupPanel_Main.Enabled = true;
            }
            else
            {
                groupPanel_Main.Enabled = false;
            }
        }
        private void txtHello_Click(object sender, EventArgs e)
        {
            txtHello.SelectAll();
        }
        private void button_CheckConn_Click(object sender, EventArgs e)
        {
            CustomerDisplayData(0.0, 0.0);
        }
        private void CustomerDisplayData(double _vTot, double _price)
        {
            try
            {
                SerialPort sport = new SerialPort(VarGeneral.Settings_Sys.Port, VarGeneral.Settings_Sys.Fast.Value, (VarGeneral.Settings_Sys.Parity.Value == 1) ? Parity.Even : ((VarGeneral.Settings_Sys.Parity.Value == 2) ? Parity.Mark : ((VarGeneral.Settings_Sys.Parity.Value != 3) ? ((VarGeneral.Settings_Sys.Parity.Value == 4) ? Parity.Odd : Parity.Space) : Parity.None)), VarGeneral.Settings_Sys.BitData.Value, (VarGeneral.Settings_Sys.BitStop.Value == 1) ? StopBits.One : ((VarGeneral.Settings_Sys.BitStop.Value == 2) ? StopBits.OnePointFive : StopBits.Two));
                sport.Open();
                sport.Write(new byte[1]
                {
                    12
                }, 0, 1);
                sport.Write(txtHello.Text);
                sport.Write(new byte[2]
                {
                    10,
                    13
                }, 0, 2);
                if (cmbShowState.SelectedIndex == 0)
                {
                    sport.Write("Price:" + _price + " Total:" + _vTot);
                }
                else if (cmbShowState.SelectedIndex == 1)
                {
                    sport.Write("Price:" + _price);
                }
                else
                {
                    sport.Write(" Total:" + _vTot);
                }
                sport.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show((LangArEn == 0) ? "توجد هناك مشكلة في الإتصال بالجهاز الآخر يرجى التأكد من الإعدادات .. ثم المحاولة مرة اخرى " : "There is a problem connecting to the other device Please make sure the settings .. then try again", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                VarGeneral.DebLog.writeLog("CustomerDisplayData :", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
    }
}
