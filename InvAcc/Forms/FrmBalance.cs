using DevComponents.DotNetBar;
using DevComponents.Editors;
using Framework.UI;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmBalance : Form
    { void avs(int arln)

{ 
 labelHeader.Text=   (arln == 0 ? "  إعدادات الميزان الباركود  " : "  Barcode Scale Settings") ; checkBox_BalanceActivated.Text=   (arln == 0 ? "  تفعيل خاصية الميزان مع الأصناف  " : "  Activate the balance feature with items") ; label8.Text=   (arln == 0 ? "  بداية فاصلة السعر العشرية بعد :  " : "  Starting price decimal point after:") ; label7.Text=   (arln == 0 ? "  بداية فاصلة الــوزن العشرية بعد :  " : "  Beginning of the decimal point after:") ; label3.Text=   (arln == 0 ? "  إجمالي خانات الباركود :  " : "  Total barcode digits:") ; label1.Text=   (arln == 0 ? "  رقم بداية الباركود :  " : "  Barcode starting number:") ; groupBox_PrintType.Text=   (arln == 0 ? "  نوع الميزان  " : "  scale type") ; RedButWightPrice.Text=   (arln == 0 ? "  إستخدام بالوزن والسعر  " : "  Use by weight and price") ; RedButPrice.Text=   (arln == 0 ? "  إستخدام بالسعر  " : "  use price") ; RedButWight.Text=   (arln == 0 ? "  إستخدام بالوزن  " : "  Use by weight") ; label5.Text=   (arln == 0 ? "  عدد بداية السعر :  " : "  number start price:") ; label6.Text=   (arln == 0 ? "  إجمالي خانات السعر :  " : "  Total price tags:") ; label4.Text=   (arln == 0 ? "  عدد بداية الوزن :  " : "  Starting weight:") ; label2.Text=   (arln == 0 ? "  إجمالي خانات الوزن :  " : "  Total weight boxes:") ; ButWithoutSave.Text=   (arln == 0 ? "  خروج | ESC  " : "  exit | ESC") ; ButWithSave.Text=   (arln == 0 ? "  حفظ | Save  " : "  save | Save") ;}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
        public class ColumnDictinaryBalance
        {
            public string AText = "";
            public string EText = "";
            public bool IfDefault = false;
            public string Format = "";
            public ColumnDictinaryBalance(string aText, string eText, bool ifDefault, string format)
            {
                AText = aText;
                EText = eText;
                IfDefault = ifDefault;
                Format = format;
            }
        }
       // private IContainer components = null;
        private LabelX labelHeader;
        private CheckBox checkBox_BalanceActivated;
        private GroupBox groupPanel_Main;
        private GroupBox groupBox_PrintType;
        private RadioButton RedButWightPrice;
        private RadioButton RedButPrice;
        private RadioButton RedButWight;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private IntegerInput txtPriceTo;
        private IntegerInput txtPriceFrom;
        private Label label5;
        private Label label6;
        private IntegerInput txtWightTo;
        private IntegerInput txtWightFrom;
        private IntegerInput txtBarcodTo;
        private IntegerInput txtBarcodFrom;
        private IntegerInput txtWieghtQ;
        private Label label7;
        private IntegerInput txtPriceQ;
        private Label label8;
        public Dictionary<string, ColumnDictinaryBalance> columns_Names_visibleBalance = new Dictionary<string, ColumnDictinaryBalance>();
        private List<T_SYSSETTING> listSysSettingBalance = new List<T_SYSSETTING>();
        private T_SYSSETTING _SysSettingBalance = new T_SYSSETTING();
        private int LangArEn = 0;
        private Stock_DataDataContext dbInstance;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private C1.Win.C1Input.C1Button ButWithoutSave;
        private C1.Win.C1Input.C1Button ButWithSave;
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
        public FrmBalance()
        {
            InitializeComponent();this.Load += langloads;
            checkBox_BalanceActivated.Click += Button_Edit_Click;
            RedButWight.Click += Button_Edit_Click;
            RedButPrice.Click += Button_Edit_Click;
            RedButWightPrice.Click += Button_Edit_Click;
            txtWightFrom.Click += Button_Edit_Click;
            txtWightTo.Click += Button_Edit_Click;
            txtPriceFrom.Click += Button_Edit_Click;
            txtPriceTo.Click += Button_Edit_Click;
            txtBarcodFrom.Click += Button_Edit_Click;
            txtBarcodTo.Click += Button_Edit_Click;
            txtWieghtQ.Click += Button_Edit_Click;
            txtPriceQ.Click += Button_Edit_Click;
        }
        private void BindDataBalance()
        {
            try
            {
                State = FormState.Saved;
                ButWithSave.Enabled = false;
                checkBox_BalanceActivated.Checked = _SysSettingBalance.IsActiveBalance.Value;
                if (_SysSettingBalance.BalanceType.Value == 0)
                {
                    RedButWight.Checked = true;
                }
                else if (_SysSettingBalance.BalanceType.Value == 1)
                {
                    RedButPrice.Checked = true;
                }
                else
                {
                    RedButWightPrice.Checked = true;
                }
                txtBarcodFrom.Value = _SysSettingBalance.BarcodFrom.Value;
                txtBarcodTo.Value = _SysSettingBalance.BarcodTo.Value;
                txtWightFrom.Value = _SysSettingBalance.WightFrom.Value;
                txtWightTo.Value = _SysSettingBalance.WightTo.Value;
                txtPriceFrom.Value = _SysSettingBalance.PriceFrom.Value;
                txtPriceTo.Value = _SysSettingBalance.PriceTo.Value;
                txtWieghtQ.Value = _SysSettingBalance.WightQ.Value;
                txtPriceQ.Value = _SysSettingBalance.PriceQ.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SaveDataBalance()
        {
            try
            {
                if (txtWieghtQ.Value > txtWightTo.Value)
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من صحة رقم الفاصلة العشرية للوزن" : "Make sure the decimal point number is correct", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (txtPriceQ.Value > txtPriceTo.Value)
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من صحة رقم الفاصلة العشرية للسعر" : "Make sure the decimal point number is correct", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                db.ExecuteCommand("update T_SYSSETTING set IsActiveBalance = " + (checkBox_BalanceActivated.Checked ? 1 : 0));
                db.ExecuteCommand("update T_SYSSETTING set BalanceType = " + ((!RedButWight.Checked) ? (RedButPrice.Checked ? 1 : 2) : 0));
                db.ExecuteCommand("update T_SYSSETTING set BarcodFrom = " + txtBarcodFrom.Value);
                db.ExecuteCommand("update T_SYSSETTING set BarcodTo = " + txtBarcodTo.Value);
                db.ExecuteCommand("update T_SYSSETTING set WightFrom = " + txtWightFrom.Value);
                db.ExecuteCommand("update T_SYSSETTING set WightTo = " + txtWightTo.Value);
                db.ExecuteCommand("update T_SYSSETTING set PriceFrom = " + txtPriceFrom.Value);
                db.ExecuteCommand("update T_SYSSETTING set PriceTo = " + txtPriceTo.Value);
                db.ExecuteCommand("update T_SYSSETTING set WightQ = " + txtWieghtQ.Value);
                db.ExecuteCommand("update T_SYSSETTING set PriceQ = " + txtPriceQ.Value);
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
                //	MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Close();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void RibunButtonsBalance()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ButWithSave.Text = "حفظ";
                //	ButWithSave.Tooltip = "F2";
                ButWithoutSave.Text = "خروج";
                //ButWithoutSave.Tooltip = "Esc";
                labelHeader.Text = "إعدادات الميزان الباركود";
            }
            else
            {
                ButWithSave.Text = "Save";
                ButWithoutSave.Text = "Exit";
                //ButWithSave.Tooltip = "F2";
                //ButWithoutSave.Tooltip = "Esc";
                labelHeader.Text = "Balance Setting";
            }
        }
        private void FrmBalance_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmBalance));
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
                RibunButtonsBalance();
                _SysSettingBalance = db.SystemSettingStock();
                try
                {
                    BindDataBalance();
                }
                catch
                {
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FrmBalance_Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void ButWithoutSave_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ButWithSave_Click(object sender, EventArgs e)
        {
            SaveDataBalance();
            State = FormState.Saved;
            SetReadOnly = true;
        }
        private void FrmBalance_KeyDown(object sender, KeyEventArgs e)
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
        private void FrmBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void checkBox_BalanceActivated_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_BalanceActivated.Checked)
            {
                groupPanel_Main.Enabled = true;
            }
            else
            {
                groupPanel_Main.Enabled = false;
            }
        }
        private void labelHeader_Click(object sender, EventArgs e)
        {
        }
    }
}
