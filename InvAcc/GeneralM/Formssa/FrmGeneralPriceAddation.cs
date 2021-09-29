using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
//using GeneralM;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
//using Stock_Data;
namespace InvAcc.Forms
{
    public partial class FrmGeneralPriceAddation : Form
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
        private IContainer components = null;
        private ButtonX ButWithoutSave;
        private ButtonX ButWithSave;
        private TextBox txtClassName;
        private TextBox txtClassNo;
        private Label label7;
        private ButtonX button_SrchClassNo;
        private ComboBoxEx comboBox_CalculatliquidNo;
        private Label label3;
        private GroupBox groupBox1;
        private DoubleInput txtVal;
        private Label label70;
        private Label label19;
        private ComboBoxEx comboBox_CalculateTyp;
        private Label label1;
        public ComboBoxEx comboBox_Allowances;
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
        public FrmGeneralPriceAddation()
        {
            InitializeComponent();
        }
        private void FrmTaxOpiton_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ButWithSave.Text = "تعميم";
                ButWithSave.Tooltip = "F2";
                ButWithoutSave.Text = "خروج";
                ButWithoutSave.Tooltip = "Esc";
                Text = "الزيادة والنقصان للاسعار والتكاليف";
            }
            else
            {
                ButWithSave.Text = "Save";
                ButWithoutSave.Text = "Exit";
                ButWithSave.Tooltip = "F2";
                ButWithoutSave.Tooltip = "Esc";
                Text = "Increase and decrease in prices and costs";
            }
        }
        private void FrmGeneralPriceAddation_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmGeneralPriceAddation));
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
                RibunButtons();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        public void FillCombo()
        {
            comboBox_CalculateTyp.Items.Clear();
            comboBox_CalculateTyp.Items.Add((LangArEn == 0) ? "زيادة" : "Increase");
            comboBox_CalculateTyp.Items.Add((LangArEn == 0) ? "نقص" : "Decrease");
            comboBox_CalculateTyp.SelectedIndex = 0;
            comboBox_CalculatliquidNo.Items.Clear();
            comboBox_CalculatliquidNo.Items.Add((LangArEn == 0) ? "في المائة" : "Percent");
            comboBox_CalculatliquidNo.Items.Add((LangArEn == 0) ? "مبلغ مقطوع" : "Fixed Sum");
            comboBox_CalculatliquidNo.SelectedIndex = 0;
            comboBox_Allowances.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                comboBox_Allowances.Items.Add("سعر البيع 1");
                comboBox_Allowances.Items.Add("سعر البيع 2");
                comboBox_Allowances.Items.Add("سعر البيع 3");
                comboBox_Allowances.Items.Add("سعر البيع 4");
                comboBox_Allowances.Items.Add("سعر البيع 5");
                comboBox_Allowances.Items.Add("سعر التكلفة");
            }
            else
            {
                comboBox_Allowances.Items.Add("Sale Price 1");
                comboBox_Allowances.Items.Add("Sale Price 2");
                comboBox_Allowances.Items.Add("Sale Price 3");
                comboBox_Allowances.Items.Add("Sale Price 4");
                comboBox_Allowances.Items.Add("Sale Price 5");
                comboBox_Allowances.Items.Add("Cost Price");
            }
            comboBox_Allowances.SelectedIndex = 0;
        }
        private void button_SrchClassNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("CAT_No", new ColumnDictinary("الرمـــز", "CATEGORY No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_CATEGORY";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtClassNo.Text = db.StockCat(frm.Serach_No).CAT_ID.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtClassName.Text = db.StockCat(frm.Serach_No).Arb_Des;
                }
                else
                {
                    txtClassName.Text = db.StockCat(frm.Serach_No).Eng_Des;
                }
            }
            else
            {
                txtClassNo.Text = "";
                txtClassName.Text = "";
            }
        }
        private void ButWithSave_Click(object sender, EventArgs e)
        {
            if (txtVal.Value <= 0.0)
            {
                return;
            }
            string sPrice1 = " UntPri1 ";
            string sPrice2 = " UntPri2 ";
            string sPrice3 = " UntPri3 ";
            string sPrice4 = " UntPri4 ";
            string sPrice5 = " UntPri5 ";
            string sAverCost = " AvrageCost ";
            string vField = ((comboBox_Allowances.SelectedIndex == 0) ? sPrice1 : ((comboBox_Allowances.SelectedIndex == 1) ? sPrice2 : ((comboBox_Allowances.SelectedIndex == 2) ? sPrice3 : ((comboBox_Allowances.SelectedIndex == 3) ? sPrice4 : ((comboBox_Allowances.SelectedIndex == 4) ? sPrice5 : sAverCost)))));
            using (Stock_DataDataContext dbT = new Stock_DataDataContext(VarGeneral.BranchCS))
            {
                if (comboBox_CalculateTyp.SelectedIndex == 0)
                {
                    if (comboBox_CalculatliquidNo.SelectedIndex == 0)
                    {
                        dbT.ExecuteCommand(" UPDATE [T_Items]\r\n                                                     SET " + vField + "= (Round(" + vField + " + ((" + vField + "  / 100) * " + txtVal.Value + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) Where " + ((!vField.Contains("AvrageCost")) ? (vField.Replace("UntPri", "Unit") + " > 0 ") : " (AvrageCost > 0 or FirstCost > 0) ") + " and (Round(" + vField + " + ((" + vField + "  / 100) * " + txtVal.Value + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) > 0" + ((!string.IsNullOrEmpty(txtClassNo.Text)) ? (" and ItmCat = " + txtClassNo.Text) : " "));
                    }
                    else
                    {
                        dbT.ExecuteCommand(" UPDATE [T_Items]\r\n                                                     SET " + vField + "= (Round(" + vField + " + " + txtVal.Value + "," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) Where " + ((!vField.Contains("AvrageCost")) ? (vField.Replace("UntPri", "Unit") + " > 0 ") : " (AvrageCost > 0 or FirstCost > 0) ") + " and (Round(" + vField + " + ( " + txtVal.Value + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) > 0" + ((!string.IsNullOrEmpty(txtClassNo.Text)) ? (" and ItmCat = " + txtClassNo.Text) : " "));
                    }
                }
                else if (comboBox_CalculatliquidNo.SelectedIndex == 0)
                {
                    dbT.ExecuteCommand(" UPDATE [T_Items]\r\n                                                     SET " + vField + "= (Round(" + vField + " - ((" + vField + "  / 100) * " + txtVal.Value + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) Where " + ((!vField.Contains("AvrageCost")) ? (vField.Replace("UntPri", "Unit") + " > 0 ") : " (AvrageCost > 0 or FirstCost > 0) ") + " and (Round(" + vField + " - ((" + vField + "  / 100) * " + txtVal.Value + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) > 0" + ((!string.IsNullOrEmpty(txtClassNo.Text)) ? (" and ItmCat = " + txtClassNo.Text) : " "));
                }
                else
                {
                    dbT.ExecuteCommand(" UPDATE [T_Items]\r\n                                                     SET " + vField + "= (Round(" + vField + " - " + txtVal.Value + "," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) Where " + ((!vField.Contains("AvrageCost")) ? (vField.Replace("UntPri", "Unit") + " > 0 ") : " (AvrageCost > 0 or FirstCost > 0) ") + " and (Round(" + vField + " - ( " + txtVal.Value + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) > 0" + ((!string.IsNullOrEmpty(txtClassNo.Text)) ? (" and ItmCat = " + txtClassNo.Text) : " "));
                }
            }
            MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        private void FrmGeneralPriceAddation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void FrmGeneralPriceAddation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                ButWithSave_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void ButWithoutSave_Click(object sender, EventArgs e)
        {
            Close();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmGeneralPriceAddation));
            ButWithoutSave = new DevComponents.DotNetBar.ButtonX();
            ButWithSave = new DevComponents.DotNetBar.ButtonX();
            txtClassName = new System.Windows.Forms.TextBox();
            txtClassNo = new System.Windows.Forms.TextBox();
            label7 = new System.Windows.Forms.Label();
            button_SrchClassNo = new DevComponents.DotNetBar.ButtonX();
            comboBox_CalculatliquidNo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            label3 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            txtVal = new DevComponents.Editors.DoubleInput();
            label70 = new System.Windows.Forms.Label();
            comboBox_Allowances = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            label19 = new System.Windows.Forms.Label();
            comboBox_CalculateTyp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            label1 = new System.Windows.Forms.Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtVal).BeginInit();
            SuspendLayout();
            ButWithoutSave.AccessibleDescription = null;
            ButWithoutSave.AccessibleName = null;
            ButWithoutSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(ButWithoutSave, "ButWithoutSave");
            ButWithoutSave.BackgroundImage = null;
            ButWithoutSave.Checked = true;
            ButWithoutSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            ButWithoutSave.CommandParameter = null;
            ButWithoutSave.Name = "ButWithoutSave";
            ButWithoutSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButWithoutSave.Symbol = "\uf011";
            ButWithoutSave.SymbolSize = 16f;
            ButWithoutSave.TextColor = System.Drawing.Color.Black;
            ButWithoutSave.Click += new System.EventHandler(ButWithoutSave_Click);
            ButWithSave.AccessibleDescription = null;
            ButWithSave.AccessibleName = null;
            ButWithSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(ButWithSave, "ButWithSave");
            ButWithSave.BackgroundImage = null;
            ButWithSave.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            ButWithSave.CommandParameter = null;
            ButWithSave.Name = "ButWithSave";
            ButWithSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButWithSave.Symbol = "\uf00c";
            ButWithSave.SymbolSize = 16f;
            ButWithSave.TextColor = System.Drawing.Color.White;
            ButWithSave.Click += new System.EventHandler(ButWithSave_Click);
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
            label7.AccessibleDescription = null;
            label7.AccessibleName = null;
            resources.ApplyResources(label7, "label7");
            label7.BackColor = System.Drawing.Color.Transparent;
            label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            label7.Name = "label7";
            button_SrchClassNo.AccessibleDescription = null;
            button_SrchClassNo.AccessibleName = null;
            button_SrchClassNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_SrchClassNo, "button_SrchClassNo");
            button_SrchClassNo.BackgroundImage = null;
            button_SrchClassNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            button_SrchClassNo.CommandParameter = null;
            button_SrchClassNo.Font = null;
            button_SrchClassNo.Name = "button_SrchClassNo";
            button_SrchClassNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_SrchClassNo.Symbol = "\uf002";
            button_SrchClassNo.SymbolSize = 12f;
            button_SrchClassNo.TextColor = System.Drawing.Color.SteelBlue;
            button_SrchClassNo.Click += new System.EventHandler(button_SrchClassNo_Click);
            comboBox_CalculatliquidNo.AccessibleDescription = null;
            comboBox_CalculatliquidNo.AccessibleName = null;
            resources.ApplyResources(comboBox_CalculatliquidNo, "comboBox_CalculatliquidNo");
            comboBox_CalculatliquidNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboBox_CalculatliquidNo.BackgroundImage = null;
            comboBox_CalculatliquidNo.CommandParameter = null;
            comboBox_CalculatliquidNo.DisplayMember = "Text";
            comboBox_CalculatliquidNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboBox_CalculatliquidNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_CalculatliquidNo.Font = null;
            comboBox_CalculatliquidNo.FormattingEnabled = true;
            comboBox_CalculatliquidNo.Name = "comboBox_CalculatliquidNo";
            comboBox_CalculatliquidNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            label3.AccessibleDescription = null;
            label3.AccessibleName = null;
            resources.ApplyResources(label3, "label3");
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            label3.Name = "label3";
            groupBox1.AccessibleDescription = null;
            groupBox1.AccessibleName = null;
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.BackColor = System.Drawing.Color.Transparent;
            groupBox1.BackgroundImage = null;
            groupBox1.Controls.Add(txtVal);
            groupBox1.Controls.Add(label70);
            groupBox1.Controls.Add(comboBox_Allowances);
            groupBox1.Controls.Add(label19);
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            txtVal.AccessibleDescription = null;
            txtVal.AccessibleName = null;
            txtVal.AllowEmptyState = false;
            resources.ApplyResources(txtVal, "txtVal");
            txtVal.BackgroundImage = null;
            txtVal.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 198);
            txtVal.BackgroundStyle.Class = "DateTimeInputBackground";
            txtVal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            txtVal.ButtonCalculator.DisplayPosition = (int)resources.GetObject("txtVal.ButtonCalculator.DisplayPosition");
            txtVal.ButtonCalculator.Image = null;
            txtVal.ButtonCalculator.Text = resources.GetString("txtVal.ButtonCalculator.Text");
            txtVal.ButtonClear.DisplayPosition = (int)resources.GetObject("txtVal.ButtonClear.DisplayPosition");
            txtVal.ButtonClear.Image = null;
            txtVal.ButtonClear.Text = resources.GetString("txtVal.ButtonClear.Text");
            txtVal.ButtonCustom.DisplayPosition = (int)resources.GetObject("txtVal.ButtonCustom.DisplayPosition");
            txtVal.ButtonCustom.Image = null;
            txtVal.ButtonCustom.Text = resources.GetString("txtVal.ButtonCustom.Text");
            txtVal.ButtonCustom2.DisplayPosition = (int)resources.GetObject("txtVal.ButtonCustom2.DisplayPosition");
            txtVal.ButtonCustom2.Image = null;
            txtVal.ButtonCustom2.Text = resources.GetString("txtVal.ButtonCustom2.Text");
            txtVal.ButtonDropDown.DisplayPosition = (int)resources.GetObject("txtVal.ButtonDropDown.DisplayPosition");
            txtVal.ButtonDropDown.Image = null;
            txtVal.ButtonDropDown.Text = resources.GetString("txtVal.ButtonDropDown.Text");
            txtVal.ButtonFreeText.DisplayPosition = (int)resources.GetObject("txtVal.ButtonFreeText.DisplayPosition");
            txtVal.ButtonFreeText.Image = null;
            txtVal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            txtVal.ButtonFreeText.Text = resources.GetString("txtVal.ButtonFreeText.Text");
            txtVal.CommandParameter = null;
            txtVal.Increment = 1.0;
            txtVal.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            txtVal.MinValue = 0.0;
            txtVal.Name = "txtVal";
            label70.AccessibleDescription = null;
            label70.AccessibleName = null;
            resources.ApplyResources(label70, "label70");
            label70.BackColor = System.Drawing.Color.Transparent;
            label70.Name = "label70";
            comboBox_Allowances.AccessibleDescription = null;
            comboBox_Allowances.AccessibleName = null;
            resources.ApplyResources(comboBox_Allowances, "comboBox_Allowances");
            comboBox_Allowances.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboBox_Allowances.BackgroundImage = null;
            comboBox_Allowances.CommandParameter = null;
            comboBox_Allowances.DisplayMember = "Text";
            comboBox_Allowances.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboBox_Allowances.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_Allowances.Font = null;
            comboBox_Allowances.FormattingEnabled = true;
            comboBox_Allowances.Name = "comboBox_Allowances";
            comboBox_Allowances.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            label19.AccessibleDescription = null;
            label19.AccessibleName = null;
            resources.ApplyResources(label19, "label19");
            label19.Font = null;
            label19.Name = "label19";
            comboBox_CalculateTyp.AccessibleDescription = null;
            comboBox_CalculateTyp.AccessibleName = null;
            resources.ApplyResources(comboBox_CalculateTyp, "comboBox_CalculateTyp");
            comboBox_CalculateTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboBox_CalculateTyp.BackgroundImage = null;
            comboBox_CalculateTyp.CommandParameter = null;
            comboBox_CalculateTyp.DisplayMember = "Text";
            comboBox_CalculateTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboBox_CalculateTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_CalculateTyp.Font = null;
            comboBox_CalculateTyp.FormattingEnabled = true;
            comboBox_CalculateTyp.Name = "comboBox_CalculateTyp";
            comboBox_CalculateTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            label1.AccessibleDescription = null;
            label1.AccessibleName = null;
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            label1.Name = "label1";
            base.AccessibleDescription = null;
            base.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            BackgroundImage = null;
            base.ControlBox = false;
            base.Controls.Add(label1);
            base.Controls.Add(comboBox_CalculateTyp);
            base.Controls.Add(label3);
            base.Controls.Add(comboBox_CalculatliquidNo);
            base.Controls.Add(txtClassName);
            base.Controls.Add(txtClassNo);
            base.Controls.Add(label7);
            base.Controls.Add(button_SrchClassNo);
            base.Controls.Add(ButWithoutSave);
            base.Controls.Add(ButWithSave);
            base.Controls.Add(groupBox1);
            Font = null;
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.Icon = null;
            base.KeyPreview = true;
            base.Name = "FrmGeneralPriceAddation";
            base.Load += new System.EventHandler(FrmGeneralPriceAddation_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(FrmGeneralPriceAddation_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmGeneralPriceAddation_KeyDown);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtVal).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
