using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.Editors;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
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
    public partial  class FrmTaxOpiton : Form
    { void avs(int arln)

{ 
 ButWithoutSave.Text=   (arln == 0 ? "  خـــروج  " : "  Close") ; ButWithSave.Text=   (arln == 0 ? "  حفــــظ  " : "  save") ; label30Tax.Text=   (arln == 0 ? "  ضريبة المبيعات  " : "  sales tax") ; label1Tax.Text=   (arln == 0 ? "  %  " : "  %") ; ButGeneralSalesTax.Text=   (arln == 0 ? "  تعميم  " : "  Generalization") ; ButGeneralPurchaesTax.Text=   (arln == 0 ? "  تعميم  " : "  Generalization") ; label2Tax.Text=   (arln == 0 ? "  %  " : "  %") ; label3Tax.Text=   (arln == 0 ? "  ضريبة المشتريات  " : "  purchase tax") ; label10.Text=   (arln == 0 ? "  الرقم الضريبـــي  " : "  tax number") ; label4Tax.Text=   (arln == 0 ? "  حساب الضريبــة  " : "  tax account") ; label5.Text=   (arln == 0 ? "  ملاحظة بالضريبـة  " : "  tax note") ; Text = "خيارات الضــرائب";this.Text=   (arln == 0 ? "  خيارات الضــرائب  " : "  Tax Options") ;}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
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
       // private IContainer components = null;
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
            InitializeComponent();this.Load += langloads;
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
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
