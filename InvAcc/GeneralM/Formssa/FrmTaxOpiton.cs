using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.Editors;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmTaxOpiton : Form
    {
        public class ColumnDictinaryTax
        {
            public string AText = string.Empty;
            public string EText = string.Empty;
            public bool IfDefault = false;
            public string Format = string.Empty;
            public ColumnDictinaryTax(string aText, string eText, bool ifDefault, string format)
            {
                AText = aText;
                EText = eText;
                IfDefault = ifDefault;
                Format = format;
            }
        }
        public Dictionary<string, ColumnDictinaryTax> columns_Names_visibleTax = new Dictionary<string, ColumnDictinaryTax>();
        private List<T_INVSETTING> listInvSettingTax = new List<T_INVSETTING>();
        private T_INVSETTING _InvSettingTax = new T_INVSETTING();
        private List<T_SYSSETTING> listSysSettingTax = new List<T_SYSSETTING>();
        private T_SYSSETTING _SysSettingTax = new T_SYSSETTING();
        private List<T_AccDef> listAccDefTax = new List<T_AccDef>();
        private T_AccDef _AccDefTax = new T_AccDef();
        private List<T_Company> listCompanyTax = new List<T_Company>();
        private T_Company _CompanyTax = new T_Company();
        private List<T_GdAuto> listGdAutoTax = new List<T_GdAuto>();
        private T_GdAuto _GdAutoTax = new T_GdAuto();
        private List<T_InfoTb> listInfotbTax = new List<T_InfoTb>();
        private T_InfoTb _InfotbTax = new T_InfoTb();
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
        private IContainer components = null;
        private C1FlexGrid c1FlexGriadTax;
        private ButtonX ButWithoutSave;
        private ButtonX ButWithSave;
        private Label label30Tax;
        private DoubleInput txtSalesTax;
        private Label label1Tax;
        private Button ButGeneralSalesTax;
        private Button ButGeneralPurchaesTax;
        private Label label2Tax;
        private Label label3Tax;
        private DoubleInput txtPurchaesTax;
        private Panel panel1;
        internal TextBox txtTaxID;
        private ButtonX button_SrchTaxNo;
        private TextBox txtTaxNo;
        internal TextBox txtTaxName;
        internal Label label10;
        internal Label label4Tax;
        internal TextBox txtTaxNote;
        internal Label label5;
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
        public FrmTaxOpiton()
        {
            InitializeComponent();
        }
        private void FrmTaxOpiton_Load(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmTaxOpiton));
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
                }
                catch
                {
                }
                RibunButtonsTax();
                listInvSettingTax = db.StockInvSettingList(VarGeneral.UserID);
                _InvSettingTax = listInvSettingTax[0];
                _SysSettingTax = db.SystemSettingStock();
                listCompanyTax = db.StockCompanyList();
                _CompanyTax = listCompanyTax[0];
                _GdAutoTax = db.GdAutoStock();
                listInfotbTax = db.StockInfoList();
                _InfotbTax = listInfotbTax[0];
                listAccDefTax = db.FillAccDef_2(string.Empty).ToList();
                listAccDefTax = listAccDefTax.Where((T_AccDef q) => q.Trn == 3 && q.Lev == 4 && q.AccDef_No.StartsWith("1") && q.AccCat != 2 && q.AccCat != 3).ToList();
                try
                {
                    FillComboTax();
                }
                catch
                {
                }
                try
                {
                    BindDataTax();
                }
                catch
                {
                }
                if (VarGeneral.SSSTyp == 0)
                {
                    c1FlexGriadTax.Cols[11].Visible = false;
                    c1FlexGriadTax.Cols[16].Visible = false;
                    c1FlexGriadTax.Cols[17].Visible = false;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void FillComboTax()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                try
                {
                    c1FlexGriadTax.SetData(0, 1, "الفاتورة");
                    c1FlexGriadTax.SetData(0, 2, "إظهار");
                    c1FlexGriadTax.SetData(0, 3, "طباعة");
                    c1FlexGriadTax.SetData(0, 4, "ض .مبيعات");
                    c1FlexGriadTax.SetData(0, 5, "ض .مشتريات");
                    c1FlexGriadTax.SetData(0, 9, "ح. المدين - نقدي");
                    c1FlexGriadTax.SetData(0, 10, "ح. الدائن - نقدي");
                    c1FlexGriadTax.SetData(0, 11, "إصدار قيد");
                    c1FlexGriadTax.SetData(0, 12, "+ الصافي");
                    c1FlexGriadTax.SetData(0, 13, "+ السطور");
                    c1FlexGriadTax.SetData(0, 14, "إجمالي السطر");
                    c1FlexGriadTax.SetData(0, 15, "صافي الفاتورة");
                    c1FlexGriadTax.SetData(0, 16, "ح. المدين - آجل");
                    c1FlexGriadTax.SetData(0, 17, "ح. الدائن - آجل");
                    c1FlexGriadTax.SetData(1, 1, "فاتورة مبيعات");
                    c1FlexGriadTax.SetData(1, 6, 1);
                    c1FlexGriadTax.SetData(1, 7, 0);
                    c1FlexGriadTax.SetData(2, 1, "فاتورة مشتريات");
                    c1FlexGriadTax.SetData(2, 6, 2);
                    c1FlexGriadTax.SetData(2, 7, 0);
                    c1FlexGriadTax.SetData(3, 1, "مرتجع مبيعات");
                    c1FlexGriadTax.SetData(3, 6, 3);
                    c1FlexGriadTax.SetData(3, 7, 0);
                    c1FlexGriadTax.SetData(4, 1, "مرتجع مشتريات");
                    c1FlexGriadTax.SetData(4, 6, 4);
                    c1FlexGriadTax.SetData(4, 7, 0);
                    c1FlexGriadTax.SetData(5, 1, "سند أدخال بضاعة");
                    c1FlexGriadTax.SetData(5, 6, 5);
                    c1FlexGriadTax.SetData(5, 7, 0);
                    c1FlexGriadTax.SetData(6, 1, "سند أخراج بضاعة");
                    c1FlexGriadTax.SetData(6, 6, 6);
                    c1FlexGriadTax.SetData(6, 7, 0);
                    c1FlexGriadTax.SetData(7, 1, "عرض سعر عملاء");
                    c1FlexGriadTax.SetData(7, 6, 7);
                    c1FlexGriadTax.SetData(7, 7, 0);
                    c1FlexGriadTax.SetData(8, 1, "عرض سعر مورد");
                    c1FlexGriadTax.SetData(8, 6, 8);
                    c1FlexGriadTax.SetData(8, 7, 0);
                    c1FlexGriadTax.SetData(9, 1, "طلب شراء");
                    c1FlexGriadTax.SetData(9, 6, 9);
                    c1FlexGriadTax.SetData(9, 7, 0);
                    c1FlexGriadTax.SetData(10, 1, "سند تسوية بضاعة");
                    c1FlexGriadTax.SetData(10, 6, 10);
                    c1FlexGriadTax.SetData(10, 7, 0);
                    c1FlexGriadTax.SetData(11, 1, "بضاعة اول المدة");
                    c1FlexGriadTax.SetData(11, 6, 14);
                    c1FlexGriadTax.SetData(11, 7, 0);
                    c1FlexGriadTax.SetData(12, 1, "أمر صرف بضاعة");
                    c1FlexGriadTax.SetData(12, 6, 17);
                    c1FlexGriadTax.SetData(12, 7, 0);
                    c1FlexGriadTax.SetData(13, 1, "مرتجع صرف بضاعة");
                    c1FlexGriadTax.SetData(13, 6, 20);
                    c1FlexGriadTax.SetData(13, 7, 0);
                    c1FlexGriadTax.SetData(14, 1, "الطلبات المحلية");
                    c1FlexGriadTax.SetData(14, 6, 21);
                    c1FlexGriadTax.SetData(14, 7, 0);
                    if (VarGeneral.SSSLev == "R" || VarGeneral.SSSLev == "C" || VarGeneral.SSSLev == "H")
                    {
                        c1FlexGriadTax.Rows[14].Visible = true;
                    }
                    else
                    {
                        c1FlexGriadTax.Rows[14].Visible = false;
                    }
                }
                catch
                {
                }
                return;
            }
            try
            {
                c1FlexGriadTax.SetData(0, 1, "Invoice");
                c1FlexGriadTax.SetData(0, 2, "Show");
                c1FlexGriadTax.SetData(0, 3, "Print");
                c1FlexGriadTax.SetData(0, 4, "Sale Tax");
                c1FlexGriadTax.SetData(0, 5, "Purch Tax");
                c1FlexGriadTax.SetData(0, 9, "Debit Acc Cash");
                c1FlexGriadTax.SetData(0, 10, "Credit Acc Cash");
                c1FlexGriadTax.SetData(0, 11, "Create Gaid");
                c1FlexGriadTax.SetData(0, 12, "+ Net");
                c1FlexGriadTax.SetData(0, 13, "+ Lines");
                c1FlexGriadTax.SetData(0, 14, "Line Total");
                c1FlexGriadTax.SetData(0, 15, "Invoice Net");
                c1FlexGriadTax.SetData(0, 16, "Debit Acc Cr");
                c1FlexGriadTax.SetData(0, 17, "Credit Acc Cr");
                c1FlexGriadTax.SetData(1, 1, "Sales Invoice");
                c1FlexGriadTax.SetData(1, 6, 1);
                c1FlexGriadTax.SetData(1, 7, 0);
                c1FlexGriadTax.SetData(2, 1, "Purchase Receipt");
                c1FlexGriadTax.SetData(2, 6, 2);
                c1FlexGriadTax.SetData(2, 7, 0);
                c1FlexGriadTax.SetData(3, 1, "Sales Return");
                c1FlexGriadTax.SetData(3, 6, 3);
                c1FlexGriadTax.SetData(3, 7, 0);
                c1FlexGriadTax.SetData(4, 1, "Purchase Return");
                c1FlexGriadTax.SetData(4, 6, 4);
                c1FlexGriadTax.SetData(4, 7, 0);
                c1FlexGriadTax.SetData(5, 1, "Transfer In");
                c1FlexGriadTax.SetData(5, 6, 5);
                c1FlexGriadTax.SetData(5, 7, 0);
                c1FlexGriadTax.SetData(6, 1, "Transfer Out");
                c1FlexGriadTax.SetData(6, 6, 6);
                c1FlexGriadTax.SetData(6, 7, 0);
                c1FlexGriadTax.SetData(7, 1, "Customer Qutation");
                c1FlexGriadTax.SetData(7, 6, 7);
                c1FlexGriadTax.SetData(7, 7, 0);
                c1FlexGriadTax.SetData(8, 1, "Supplier Qutation");
                c1FlexGriadTax.SetData(8, 6, 8);
                c1FlexGriadTax.SetData(8, 7, 0);
                c1FlexGriadTax.SetData(9, 1, "Purchase Order");
                c1FlexGriadTax.SetData(9, 6, 9);
                c1FlexGriadTax.SetData(9, 7, 0);
                c1FlexGriadTax.SetData(10, 1, "Stock Adjustment");
                c1FlexGriadTax.SetData(10, 6, 10);
                c1FlexGriadTax.SetData(10, 7, 0);
                c1FlexGriadTax.SetData(11, 1, "Open Quantities");
                c1FlexGriadTax.SetData(11, 6, 14);
                c1FlexGriadTax.SetData(11, 7, 0);
                c1FlexGriadTax.SetData(12, 1, "Payment Order");
                c1FlexGriadTax.SetData(12, 6, 17);
                c1FlexGriadTax.SetData(12, 7, 0);
                c1FlexGriadTax.SetData(13, 1, "Payment Order Return");
                c1FlexGriadTax.SetData(13, 6, 20);
                c1FlexGriadTax.SetData(13, 7, 0);
                c1FlexGriadTax.SetData(14, 1, "Local Orders");
                c1FlexGriadTax.SetData(14, 6, 21);
                c1FlexGriadTax.SetData(14, 7, 0);
                if (VarGeneral.SSSLev == "R" || VarGeneral.SSSLev == "C" || VarGeneral.SSSLev == "H")
                {
                    c1FlexGriadTax.Rows[14].Visible = true;
                }
                else
                {
                    c1FlexGriadTax.Rows[14].Visible = false;
                }
            }
            catch
            {
            }
        }
        private void BindDataTax()
        {
            try
            {
                State = FormState.Saved;
                ButWithSave.Enabled = false;
                for (int iiCnt = 1; iiCnt < c1FlexGriadTax.Rows.Count; iiCnt++)
                {
                    for (int i = 0; i < listInvSettingTax.Count; i++)
                    {
                        _InvSettingTax = listInvSettingTax[i];
                        if (_InvSettingTax.InvID == int.Parse(c1FlexGriadTax.GetData(iiCnt, 6).ToString()))
                        {
                            c1FlexGriadTax.SetData(iiCnt, 2, VarGeneral.TString.ChkStatShow(_InvSettingTax.TaxOptions, 0));
                            c1FlexGriadTax.SetData(iiCnt, 3, VarGeneral.TString.ChkStatShow(_InvSettingTax.TaxOptions, 1));
                            c1FlexGriadTax.SetData(iiCnt, 4, VarGeneral.TString.ChkStatShow(_InvSettingTax.TaxOptions, 2));
                            c1FlexGriadTax.SetData(iiCnt, 5, VarGeneral.TString.ChkStatShow(_InvSettingTax.TaxOptions, 3));
                            c1FlexGriadTax.SetData(iiCnt, 9, _InvSettingTax.TaxDebit);
                            c1FlexGriadTax.SetData(iiCnt, 10, _InvSettingTax.TaxCredit);
                            c1FlexGriadTax.SetData(iiCnt, 11, _InvSettingTax.autoTaxGaid);
                            c1FlexGriadTax.SetData(iiCnt, 12, VarGeneral.TString.ChkStatShow(_InvSettingTax.TaxOptions, 4));
                            c1FlexGriadTax.SetData(iiCnt, 13, VarGeneral.TString.ChkStatShow(_InvSettingTax.TaxOptions, 5));
                            c1FlexGriadTax.SetData(iiCnt, 14, VarGeneral.TString.ChkStatShow(_InvSettingTax.TaxOptions, 6));
                            c1FlexGriadTax.SetData(iiCnt, 15, VarGeneral.TString.ChkStatShow(_InvSettingTax.TaxOptions, 7));
                            c1FlexGriadTax.SetData(iiCnt, 16, _InvSettingTax.TaxDebitCredit);
                            c1FlexGriadTax.SetData(iiCnt, 17, _InvSettingTax.TaxCreditCredit);
                            break;
                        }
                    }
                }
                txtPurchaesTax.Value = _SysSettingTax.DefPurchaesTax.Value;
                txtSalesTax.Value = _SysSettingTax.DefSalesTax.Value;
                txtTaxNote.Text = _SysSettingTax.TaxNoteInv;
                if (!string.IsNullOrEmpty(_SysSettingTax.TaxAcc))
                {
                    txtTaxNo.Text = _SysSettingTax.TaxAcc;
                    txtTaxName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(_SysSettingTax.TaxAcc.ToString()).Arb_Des : db.StockAccDefWithOutBalance(_SysSettingTax.TaxAcc.ToString()).Eng_Des);
                    txtTaxID.Text = db.StockAccDefWithOutBalance(_SysSettingTax.TaxAcc.ToString()).TaxNo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ButExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void c1FlexGrid1_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }
        private void SaveDataTax()
        {
            try
            {
                for (int iiCnt = 1; iiCnt < c1FlexGriadTax.Rows.Count; iiCnt++)
                {
                    for (int i = 0; i < listInvSettingTax.Count; i++)
                    {
                        _InvSettingTax = listInvSettingTax[i];
                        if (_InvSettingTax.InvID == int.Parse(c1FlexGriadTax.GetData(iiCnt, 6).ToString()))
                        {
                            _InvSettingTax.TaxOptions = VarGeneral.TString.ChkStatSave((bool)c1FlexGriadTax.GetData(iiCnt, 2)) + VarGeneral.TString.ChkStatSave((bool)c1FlexGriadTax.GetData(iiCnt, 3)) + VarGeneral.TString.ChkStatSave((bool)c1FlexGriadTax.GetData(iiCnt, 4)) + VarGeneral.TString.ChkStatSave((bool)c1FlexGriadTax.GetData(iiCnt, 5)) + VarGeneral.TString.ChkStatSave((bool)c1FlexGriadTax.GetData(iiCnt, 12)) + VarGeneral.TString.ChkStatSave((bool)c1FlexGriadTax.GetData(iiCnt, 13)) + VarGeneral.TString.ChkStatSave((bool)c1FlexGriadTax.GetData(iiCnt, 14)) + VarGeneral.TString.ChkStatSave((bool)c1FlexGriadTax.GetData(iiCnt, 15));
                            try
                            {
                                _InvSettingTax.TaxDebit = c1FlexGriadTax.GetData(iiCnt, 9).ToString();
                            }
                            catch
                            {
                                _InvSettingTax.TaxDebit = "***";
                            }
                            try
                            {
                                _InvSettingTax.TaxCredit = c1FlexGriadTax.GetData(iiCnt, 10).ToString();
                            }
                            catch
                            {
                                _InvSettingTax.TaxCredit = "***";
                            }
                            try
                            {
                                _InvSettingTax.TaxDebitCredit = c1FlexGriadTax.GetData(iiCnt, 16).ToString();
                            }
                            catch
                            {
                                _InvSettingTax.TaxDebitCredit = "***";
                            }
                            try
                            {
                                _InvSettingTax.TaxCreditCredit = c1FlexGriadTax.GetData(iiCnt, 17).ToString();
                            }
                            catch
                            {
                                _InvSettingTax.TaxCreditCredit = "***";
                            }
                            _InvSettingTax.autoTaxGaid = Convert.ToBoolean(c1FlexGriadTax.GetData(iiCnt, 11));
                            db.Log = VarGeneral.DebugLog;
                            db.SubmitChanges(ConflictMode.ContinueOnConflict);
                            break;
                        }
                    }
                }
                db.ExecuteCommand("update T_SYSSETTING set DefSalesTax = " + txtSalesTax.Value);
                db.ExecuteCommand("update T_SYSSETTING set DefPurchaesTax = " + txtPurchaesTax.Value);
                db.ExecuteCommand("update T_SYSSETTING set TaxAcc = '" + txtTaxNo.Text + "'");
                db.ExecuteCommand("update T_SYSSETTING set TaxNoteInv = '" + txtTaxNote.Text + "'");
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
            SaveDataTax();
            State = FormState.Saved;
            SetReadOnly = true;
        }
        private void FrmTaxOpiton_KeyDown(object sender, KeyEventArgs e)
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
        private void FrmTaxOpiton_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void RibunButtonsTax()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                ButWithSave.Text = "حفظ";
                ButWithSave.Tooltip = "F2";
                ButWithoutSave.Text = "خروج";
                ButWithoutSave.Tooltip = "Esc";
                Text = "خيارات الضريبة";
            }
            else
            {
                ButWithSave.Text = "Save";
                ButWithoutSave.Text = "Exit";
                ButWithSave.Tooltip = "F2";
                ButWithoutSave.Tooltip = "Esc";
                Text = "Taxes Options";
            }
        }
        private void c1FlexGrid1_CellChecked(object sender, RowColEventArgs e)
        {
            if (e.Col != 4 && e.Col != 5)
            {
                return;
            }
            if (e.Col == 4)
            {
                if (Convert.ToBoolean(c1FlexGriadTax.Rows[e.Row][4]))
                {
                    c1FlexGriadTax.Rows[e.Row][5] = false;
                }
                else
                {
                    c1FlexGriadTax.Rows[e.Row][5] = true;
                }
            }
            else if (Convert.ToBoolean(c1FlexGriadTax.Rows[e.Row][5]))
            {
                c1FlexGriadTax.Rows[e.Row][4] = false;
            }
            else
            {
                c1FlexGriadTax.Rows[e.Row][4] = true;
            }
        }
        private void txtSalesTax_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }
        private void txtPurchaesTax_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }
        private void ButGeneralSalesTax_Click(object sender, EventArgs e)
        {
            FrmGeneralTax frm = new FrmGeneralTax(0);
            frm.Tag = LangArEn;
            frm.txtSalesTax.Value = txtSalesTax.Value;
            frm.TopMost = true;
            frm.ShowDialog();
        }
        private void ButGeneralPurchaesTax_Click(object sender, EventArgs e)
        {
            FrmGeneralTax frm = new FrmGeneralTax(1);
            frm.Tag = LangArEn;
            frm.txtSalesTax.Value = txtPurchaesTax.Value;
            frm.TopMost = true;
            frm.ShowDialog();
        }
        private void c1FlexGrid1_DoubleClick(object sender, EventArgs e)
        {
            if ((c1FlexGriadTax.Col != 9 && c1FlexGriadTax.Col != 10 && c1FlexGriadTax.Col != 16 && c1FlexGriadTax.Col != 17) || c1FlexGriadTax.Row <= 0)
            {
                return;
            }
            columns_Names_visibleTax.Clear();
            columns_Names_visibleTax.Add("AccDef_No", new ColumnDictinaryTax("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visibleTax.Add("Arb_Des", new ColumnDictinaryTax("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visibleTax.Add("Eng_Des", new ColumnDictinaryTax("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visibleTax.Add("AccDef_ID", new ColumnDictinaryTax(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visibleTax.Add("Mobile", new ColumnDictinaryTax("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinaryTax>> animalsAsCollection = columns_Names_visibleTax;
            foreach (KeyValuePair<string, ColumnDictinaryTax> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    c1FlexGriadTax.SetData(c1FlexGriadTax.Row, c1FlexGriadTax.Col, _AccDef.AccDef_No.ToString());
                }
                else
                {
                    c1FlexGriadTax.SetData(c1FlexGriadTax.Row, c1FlexGriadTax.Col, "***");
                }
            }
            catch
            {
                c1FlexGriadTax.SetData(c1FlexGriadTax.Row, c1FlexGriadTax.Col, "***");
            }
            VarGeneral.Flush();
        }
        private void button_SrchTaxNo_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            columns_Names_visibleTax.Clear();
            columns_Names_visibleTax.Add("AccDef_No", new ColumnDictinaryTax("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visibleTax.Add("Arb_Des", new ColumnDictinaryTax("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visibleTax.Add("Eng_Des", new ColumnDictinaryTax("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visibleTax.Add("AccDef_ID", new ColumnDictinaryTax(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visibleTax.Add("Mobile", new ColumnDictinaryTax("الجوال", "Mobile", ifDefault: false, string.Empty));
            columns_Names_visibleTax.Add("TaxNo", new ColumnDictinaryTax("الرقم الضريبي", "Tax No", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinaryTax>> animalsAsCollection = columns_Names_visibleTax;
            foreach (KeyValuePair<string, ColumnDictinaryTax> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                txtTaxNo.Text = _AccDef.AccDef_No.ToString();
                txtTaxName.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(txtTaxNo.Text).Arb_Des : db.StockAccDefWithOutBalance(txtTaxNo.Text).Eng_Des);
                txtTaxID.Text = db.StockAccDefWithOutBalance(txtTaxNo.Text).TaxNo;
            }
            else
            {
                txtTaxNo.Text = string.Empty;
                txtTaxName.Text = string.Empty;
                txtTaxID.Text = string.Empty;
            }
        }
        private void txtTaxNote_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTaxOpiton));
            this.c1FlexGriadTax = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.ButWithoutSave = new DevComponents.DotNetBar.ButtonX();
            this.ButWithSave = new DevComponents.DotNetBar.ButtonX();
            this.label30Tax = new System.Windows.Forms.Label();
            this.txtSalesTax = new DevComponents.Editors.DoubleInput();
            this.label1Tax = new System.Windows.Forms.Label();
            this.ButGeneralSalesTax = new System.Windows.Forms.Button();
            this.ButGeneralPurchaesTax = new System.Windows.Forms.Button();
            this.label2Tax = new System.Windows.Forms.Label();
            this.label3Tax = new System.Windows.Forms.Label();
            this.txtPurchaesTax = new DevComponents.Editors.DoubleInput();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTaxID = new System.Windows.Forms.TextBox();
            this.button_SrchTaxNo = new DevComponents.DotNetBar.ButtonX();
            this.txtTaxNo = new System.Windows.Forms.TextBox();
            this.txtTaxName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label4Tax = new System.Windows.Forms.Label();
            this.txtTaxNote = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGriadTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurchaesTax)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // c1FlexGriadTax
            // 
            this.c1FlexGriadTax.ColumnInfo = resources.GetString("c1FlexGriadTax.ColumnInfo");
            this.c1FlexGriadTax.Font = new System.Drawing.Font("Tahoma", 8F);
            this.c1FlexGriadTax.Location = new System.Drawing.Point(338, 0);
            this.c1FlexGriadTax.Name = "c1FlexGriadTax";
            this.c1FlexGriadTax.Rows.Count = 15;
            this.c1FlexGriadTax.Rows.DefaultSize = 19;
            this.c1FlexGriadTax.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.c1FlexGriadTax.Size = new System.Drawing.Size(683, 271);
            this.c1FlexGriadTax.StyleInfo = resources.GetString("c1FlexGriadTax.StyleInfo");
            this.c1FlexGriadTax.TabIndex = 22;
            this.c1FlexGriadTax.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Black;
            this.c1FlexGriadTax.CellChecked += new C1.Win.C1FlexGrid.RowColEventHandler(this.c1FlexGrid1_CellChecked);
            this.c1FlexGriadTax.Click += new System.EventHandler(this.c1FlexGrid1_Click);
            this.c1FlexGriadTax.DoubleClick += new System.EventHandler(this.c1FlexGrid1_DoubleClick);
            // 
            // ButWithoutSave
            // 
            this.ButWithoutSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButWithoutSave.Checked = true;
            this.ButWithoutSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ButWithoutSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButWithoutSave.Location = new System.Drawing.Point(2, 375);
            this.ButWithoutSave.Name = "ButWithoutSave";
            this.ButWithoutSave.Size = new System.Drawing.Size(506, 48);
            this.ButWithoutSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButWithoutSave.Symbol = "";
            this.ButWithoutSave.SymbolSize = 16F;
            this.ButWithoutSave.TabIndex = 6785;
            this.ButWithoutSave.Text = "خـــروج";
            this.ButWithoutSave.TextColor = System.Drawing.Color.Black;
            this.ButWithoutSave.Click += new System.EventHandler(this.ButExit_Click);
            // 
            // ButWithSave
            // 
            this.ButWithSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButWithSave.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.ButWithSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButWithSave.Location = new System.Drawing.Point(512, 375);
            this.ButWithSave.Name = "ButWithSave";
            this.ButWithSave.Size = new System.Drawing.Size(507, 48);
            this.ButWithSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButWithSave.Symbol = "";
            this.ButWithSave.SymbolSize = 16F;
            this.ButWithSave.TabIndex = 6784;
            this.ButWithSave.Text = "حفــــظ";
            this.ButWithSave.TextColor = System.Drawing.Color.White;
            this.ButWithSave.Click += new System.EventHandler(this.ButWithSave_Click);
            // 
            // label30Tax
            // 
            this.label30Tax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label30Tax.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label30Tax.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label30Tax.Location = new System.Drawing.Point(888, 273);
            this.label30Tax.Name = "label30Tax";
            this.label30Tax.Size = new System.Drawing.Size(128, 22);
            this.label30Tax.TabIndex = 6788;
            this.label30Tax.Text = "ضريبة المبيعات";
            this.label30Tax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSalesTax
            // 
            this.txtSalesTax.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtSalesTax.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtSalesTax.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtSalesTax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSalesTax.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtSalesTax.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtSalesTax.Increment = 1D;
            this.txtSalesTax.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtSalesTax.Location = new System.Drawing.Point(827, 273);
            this.txtSalesTax.MinValue = 0D;
            this.txtSalesTax.Name = "txtSalesTax";
            this.txtSalesTax.Size = new System.Drawing.Size(58, 22);
            this.txtSalesTax.TabIndex = 6789;
            this.txtSalesTax.Click += new System.EventHandler(this.txtSalesTax_Click);
            // 
            // label1Tax
            // 
            this.label1Tax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1Tax.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1Tax.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1Tax.Location = new System.Drawing.Point(797, 273);
            this.label1Tax.Name = "label1Tax";
            this.label1Tax.Size = new System.Drawing.Size(28, 22);
            this.label1Tax.TabIndex = 6790;
            this.label1Tax.Text = "%";
            this.label1Tax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ButGeneralSalesTax
            // 
            this.ButGeneralSalesTax.BackColor = System.Drawing.Color.Transparent;
            this.ButGeneralSalesTax.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButGeneralSalesTax.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.ButGeneralSalesTax.ForeColor = System.Drawing.Color.Maroon;
            this.ButGeneralSalesTax.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ButGeneralSalesTax.Location = new System.Drawing.Point(686, 273);
            this.ButGeneralSalesTax.Name = "ButGeneralSalesTax";
            this.ButGeneralSalesTax.Size = new System.Drawing.Size(109, 22);
            this.ButGeneralSalesTax.TabIndex = 6791;
            this.ButGeneralSalesTax.Text = "تعميم";
            this.ButGeneralSalesTax.UseVisualStyleBackColor = false;
            this.ButGeneralSalesTax.Click += new System.EventHandler(this.ButGeneralSalesTax_Click);
            // 
            // ButGeneralPurchaesTax
            // 
            this.ButGeneralPurchaesTax.BackColor = System.Drawing.Color.Transparent;
            this.ButGeneralPurchaesTax.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButGeneralPurchaesTax.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.ButGeneralPurchaesTax.ForeColor = System.Drawing.Color.Maroon;
            this.ButGeneralPurchaesTax.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ButGeneralPurchaesTax.Location = new System.Drawing.Point(338, 273);
            this.ButGeneralPurchaesTax.Name = "ButGeneralPurchaesTax";
            this.ButGeneralPurchaesTax.Size = new System.Drawing.Size(109, 22);
            this.ButGeneralPurchaesTax.TabIndex = 6795;
            this.ButGeneralPurchaesTax.Text = "تعميم";
            this.ButGeneralPurchaesTax.UseVisualStyleBackColor = false;
            this.ButGeneralPurchaesTax.Click += new System.EventHandler(this.ButGeneralPurchaesTax_Click);
            // 
            // label2Tax
            // 
            this.label2Tax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2Tax.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2Tax.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2Tax.Location = new System.Drawing.Point(450, 273);
            this.label2Tax.Name = "label2Tax";
            this.label2Tax.Size = new System.Drawing.Size(28, 22);
            this.label2Tax.TabIndex = 6794;
            this.label2Tax.Text = "%";
            this.label2Tax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3Tax
            // 
            this.label3Tax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3Tax.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3Tax.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3Tax.Location = new System.Drawing.Point(540, 273);
            this.label3Tax.Name = "label3Tax";
            this.label3Tax.Size = new System.Drawing.Size(139, 22);
            this.label3Tax.TabIndex = 6792;
            this.label3Tax.Text = "ضريبة المشتريات";
            this.label3Tax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPurchaesTax
            // 
            this.txtPurchaesTax.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtPurchaesTax.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtPurchaesTax.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtPurchaesTax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPurchaesTax.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtPurchaesTax.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtPurchaesTax.Increment = 1D;
            this.txtPurchaesTax.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtPurchaesTax.Location = new System.Drawing.Point(480, 273);
            this.txtPurchaesTax.MinValue = 0D;
            this.txtPurchaesTax.Name = "txtPurchaesTax";
            this.txtPurchaesTax.Size = new System.Drawing.Size(58, 22);
            this.txtPurchaesTax.TabIndex = 6793;
            this.txtPurchaesTax.Click += new System.EventHandler(this.txtPurchaesTax_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtTaxID);
            this.panel1.Controls.Add(this.button_SrchTaxNo);
            this.panel1.Controls.Add(this.txtTaxNo);
            this.panel1.Controls.Add(this.txtTaxName);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label4Tax);
            this.panel1.Location = new System.Drawing.Point(338, 298);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(683, 51);
            this.panel1.TabIndex = 6796;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txtTaxID
            // 
            this.txtTaxID.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtTaxID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTaxID.Location = new System.Drawing.Point(3, 25);
            this.txtTaxID.Name = "txtTaxID";
            this.txtTaxID.ReadOnly = true;
            this.txtTaxID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTaxID.Size = new System.Drawing.Size(547, 21);
            this.txtTaxID.TabIndex = 1098;
            this.txtTaxID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_SrchTaxNo
            // 
            this.button_SrchTaxNo.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.button_SrchTaxNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchTaxNo.Location = new System.Drawing.Point(392, 2);
            this.button_SrchTaxNo.Name = "button_SrchTaxNo";
            this.button_SrchTaxNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchTaxNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchTaxNo.Symbol = "";
            this.button_SrchTaxNo.SymbolSize = 12F;
            this.button_SrchTaxNo.TabIndex = 1094;
            this.button_SrchTaxNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchTaxNo.Click += new System.EventHandler(this.button_SrchTaxNo_Click);
            // 
            // txtTaxNo
            // 
            this.txtTaxNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTaxNo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTaxNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtTaxNo.Location = new System.Drawing.Point(424, 2);
            this.txtTaxNo.MaxLength = 30;
            this.txtTaxNo.Name = "txtTaxNo";
            this.txtTaxNo.ReadOnly = true;
            this.txtTaxNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTaxNo.Size = new System.Drawing.Size(126, 21);
            this.txtTaxNo.TabIndex = 1093;
            this.txtTaxNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTaxName
            // 
            this.txtTaxName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTaxName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTaxName.Location = new System.Drawing.Point(3, 2);
            this.txtTaxName.Name = "txtTaxName";
            this.txtTaxName.ReadOnly = true;
            this.txtTaxName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTaxName.Size = new System.Drawing.Size(383, 21);
            this.txtTaxName.TabIndex = 1095;
            this.txtTaxName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(553, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 20);
            this.label10.TabIndex = 1097;
            this.label10.Text = "الرقم الضريبـــي";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4Tax
            // 
            this.label4Tax.BackColor = System.Drawing.Color.Transparent;
            this.label4Tax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4Tax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4Tax.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4Tax.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4Tax.Location = new System.Drawing.Point(553, 2);
            this.label4Tax.Name = "label4Tax";
            this.label4Tax.Size = new System.Drawing.Size(128, 20);
            this.label4Tax.TabIndex = 1096;
            this.label4Tax.Text = "حساب الضريبــة";
            this.label4Tax.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtTaxNote
            // 
            this.txtTaxNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtTaxNote.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTaxNote.Location = new System.Drawing.Point(338, 351);
            this.txtTaxNote.MaxLength = 150;
            this.txtTaxNote.Name = "txtTaxNote";
            this.txtTaxNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTaxNote.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTaxNote.Size = new System.Drawing.Size(547, 21);
            this.txtTaxNote.TabIndex = 6798;
            this.txtTaxNote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTaxNote.Click += new System.EventHandler(this.txtTaxNote_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(888, 351);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 20);
            this.label5.TabIndex = 6797;
            this.label5.Text = "ملاحظة بالضريبـة";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FrmTaxOpiton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 423);
            this.Controls.Add(this.txtTaxNote);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ButGeneralPurchaesTax);
            this.Controls.Add(this.label2Tax);
            this.Controls.Add(this.label3Tax);
            this.Controls.Add(this.txtPurchaesTax);
            this.Controls.Add(this.ButGeneralSalesTax);
            this.Controls.Add(this.label1Tax);
            this.Controls.Add(this.label30Tax);
            this.Controls.Add(this.txtSalesTax);
            this.Controls.Add(this.ButWithoutSave);
            this.Controls.Add(this.ButWithSave);
            this.Controls.Add(this.c1FlexGriadTax);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = (InvAcc.Properties.Resources.favicon);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTaxOpiton";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "خيارات الضــرائب";
            this.Load += new System.EventHandler(this.FrmTaxOpiton_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmTaxOpiton_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmTaxOpiton_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGriadTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurchaesTax)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Icon = (InvAcc.Properties.Resources.favicon);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
