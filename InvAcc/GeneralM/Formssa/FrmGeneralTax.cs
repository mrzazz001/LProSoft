using DevComponents.DotNetBar;
using DevComponents.Editors;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmGeneralTax : Form
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
        private int tp = 0;
        private IContainer components = null;
        private Label label1;
        private Label label30;
        private ButtonX ButWithoutSave;
        private ButtonX ButWithSave;
        private TextBox txtClassName;
        private TextBox txtClassNo;
        private Label label7;
        private ButtonX button_SrchClassNo;
        public DoubleInput txtSalesTax;
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
        public FrmGeneralTax(int vTp)
        {
            InitializeComponent();
            tp = vTp;
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
                Text = "تعميم ضرائب الأصناف";
                if (tp == 0)
                {
                    label30.Text = "ضريبة المبيعات";
                }
                else
                {
                    label30.Text = "ضريبة المشتريات";
                }
            }
            else
            {
                ButWithSave.Text = "Save";
                ButWithoutSave.Text = "Exit";
                ButWithSave.Tooltip = "F2";
                ButWithoutSave.Tooltip = "Esc";
                Text = "Items Taxes Popularization";
                if (tp == 0)
                {
                    label30.Text = "Sales Tax";
                }
                else
                {
                    label30.Text = "Purchaes Tax";
                }
            }
        }
        private void FrmGeneralTax_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmGeneralTax));
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
                RibunButtons();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
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
            if (tp == 0)
            {
                db.ExecuteCommand(" UPDATE [T_Items]\r\n                                     SET [TaxSales] = " + txtSalesTax.Value + ((!string.IsNullOrEmpty(txtClassNo.Text)) ? (" Where ItmCat = " + txtClassNo.Text) : " "));
                MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Close();
            }
            else
            {
                db.ExecuteCommand(" UPDATE [T_Items]\r\n                                     SET [TaxPurchas] = " + txtSalesTax.Value + ((!string.IsNullOrEmpty(txtClassNo.Text)) ? (" Where ItmCat = " + txtClassNo.Text) : " "));
                MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Close();
            }
        }
        private void FrmGeneralTax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void FrmGeneralTax_KeyDown(object sender, KeyEventArgs e)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmGeneralTax));
            label1 = new System.Windows.Forms.Label();
            label30 = new System.Windows.Forms.Label();
            txtSalesTax = new DevComponents.Editors.DoubleInput();
            ButWithoutSave = new DevComponents.DotNetBar.ButtonX();
            ButWithSave = new DevComponents.DotNetBar.ButtonX();
            txtClassName = new System.Windows.Forms.TextBox();
            txtClassNo = new System.Windows.Forms.TextBox();
            label7 = new System.Windows.Forms.Label();
            button_SrchClassNo = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)txtSalesTax).BeginInit();
            SuspendLayout();
            label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            label30.BackColor = System.Drawing.SystemColors.ButtonFace;
            label30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(label30, "label30");
            label30.Name = "label30";
            txtSalesTax.AllowEmptyState = false;
            txtSalesTax.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 198);
            txtSalesTax.BackgroundStyle.Class = "DateTimeInputBackground";
            txtSalesTax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            txtSalesTax.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(txtSalesTax, "txtSalesTax");
            txtSalesTax.Increment = 1.0;
            txtSalesTax.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            txtSalesTax.MinValue = 0.0;
            txtSalesTax.Name = "txtSalesTax";
            ButWithoutSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            ButWithoutSave.Checked = true;
            ButWithoutSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(ButWithoutSave, "ButWithoutSave");
            ButWithoutSave.Name = "ButWithoutSave";
            ButWithoutSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButWithoutSave.Symbol = "\uf011";
            ButWithoutSave.SymbolSize = 16f;
            ButWithoutSave.TextColor = System.Drawing.Color.Black;
            ButWithoutSave.Click += new System.EventHandler(ButWithoutSave_Click);
            ButWithSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            ButWithSave.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            resources.ApplyResources(ButWithSave, "ButWithSave");
            ButWithSave.Name = "ButWithSave";
            ButWithSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButWithSave.Symbol = "\uf00c";
            ButWithSave.SymbolSize = 16f;
            ButWithSave.TextColor = System.Drawing.Color.White;
            ButWithSave.Click += new System.EventHandler(ButWithSave_Click);
            txtClassName.BackColor = System.Drawing.Color.DarkSeaGreen;
            txtClassName.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(txtClassName, "txtClassName");
            txtClassName.Name = "txtClassName";
            txtClassName.ReadOnly = true;
            txtClassNo.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(txtClassNo, "txtClassNo");
            txtClassNo.Name = "txtClassNo";
            txtClassNo.ReadOnly = true;
            txtClassNo.Tag = " T_CATEGORY.CAT_ID ";
            label7.BackColor = System.Drawing.Color.Transparent;
            label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            button_SrchClassNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            button_SrchClassNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(button_SrchClassNo, "button_SrchClassNo");
            button_SrchClassNo.Name = "button_SrchClassNo";
            button_SrchClassNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_SrchClassNo.Symbol = "\uf002";
            button_SrchClassNo.SymbolSize = 12f;
            button_SrchClassNo.TextColor = System.Drawing.Color.SteelBlue;
            button_SrchClassNo.Click += new System.EventHandler(button_SrchClassNo_Click);
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            base.ControlBox = false;
            base.Controls.Add(txtClassName);
            base.Controls.Add(txtClassNo);
            base.Controls.Add(label7);
            base.Controls.Add(button_SrchClassNo);
            base.Controls.Add(ButWithoutSave);
            base.Controls.Add(ButWithSave);
            base.Controls.Add(label1);
            base.Controls.Add(label30);
            base.Controls.Add(txtSalesTax);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.Name = "FrmGeneralTax";
            base.Load += new System.EventHandler(FrmGeneralTax_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(FrmGeneralTax_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmGeneralTax_KeyDown);
            ((System.ComponentModel.ISupportInitialize)txtSalesTax).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
