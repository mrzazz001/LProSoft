using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
//using GeneralM;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
//using Stock_Data;
namespace InvAcc.Forms
{
    public partial  class FrmGeneralPriceAddation : Form
    { void avs(int arln)

{ 
}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
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
       // private IContainer components = null;
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
            InitializeComponent();this.Load += langloads;
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
    }
}
