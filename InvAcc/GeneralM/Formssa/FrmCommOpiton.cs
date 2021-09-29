using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
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
    public partial class FrmCommOpiton : Form
    {
        public class ColumnDictinaryBankopp
        {
            public string AText = "";
            public string EText = "";
            public bool IfDefault = false;
            public string Format = "";
            public ColumnDictinaryBankopp(string aText, string eText, bool ifDefault, string format)
            {
                AText = aText;
                EText = eText;
                IfDefault = ifDefault;
                Format = format;
            }
        }
        public Dictionary<string, ColumnDictinaryBankopp> columns_Names_visibleBankopp = new Dictionary<string, ColumnDictinaryBankopp>();
        private List<T_INVSETTING> listInvSettingBankopp = new List<T_INVSETTING>();
        private T_INVSETTING _InvSettingBankopp = new T_INVSETTING();
        private List<T_SYSSETTING> listSysSettingBankopp = new List<T_SYSSETTING>();
        private T_SYSSETTING _SysSettingBankopp = new T_SYSSETTING();
        private List<T_AccDef> listAccDefBankopp = new List<T_AccDef>();
        private T_AccDef _AccDefBankopp = new T_AccDef();
        private List<T_Company> listCompanyBankopp = new List<T_Company>();
        private T_Company _CompanyBankopp = new T_Company();
        private List<T_GdAuto> listGdAutoBankopp = new List<T_GdAuto>();
        private T_GdAuto _GdAutoBankopp = new T_GdAuto();
        private List<T_InfoTb> listInfotbBankopp = new List<T_InfoTb>();
        private T_InfoTb _InfotbBankopp = new T_InfoTb();
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
        private C1FlexGrid c1FlexGrid1Bankopp;
        private ButtonX ButWithoutSave;
        private ButtonX ButWithSave;
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
        public FrmCommOpiton()
        {
            InitializeComponent();
        }
        private void FrmCommOpiton_Load(object sender, EventArgs e)
        {
            loadBankop();
        }
        void loadBankop()
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmCommOpiton));
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
                RibunButtonsBankopp();
                listInvSettingBankopp = db.StockInvSettingList(VarGeneral.UserID);
                _InvSettingBankopp = listInvSettingBankopp[0];
                _SysSettingBankopp = db.SystemSettingStock();
                listCompanyBankopp = db.StockCompanyList();
                _CompanyBankopp = listCompanyBankopp[0];
                _GdAutoBankopp = db.GdAutoStock();
                listInfotbBankopp = db.StockInfoList();
                _InfotbBankopp = listInfotbBankopp[0];
                listAccDefBankopp = db.FillAccDef_2("").ToList();
                listAccDefBankopp = listAccDefBankopp.Where((T_AccDef q) => q.Trn == 3 && q.Lev == 4 && q.AccDef_No.StartsWith("1") && q.AccCat != 2 && q.AccCat != 3).ToList();
                try
                {
                    FillComboBankopp();
                }
                catch
                {
                }
                try
                {
                    BindDataBankopp();
                }
                catch
                {
                }
                if (VarGeneral.SSSTyp == 0)
                {
                    c1FlexGrid1Bankopp.Cols[9].Visible = false;
                    c1FlexGrid1Bankopp.Cols[10].Visible = false;
                    c1FlexGrid1Bankopp.Cols[11].Visible = false;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void RibunButtonsBankopp()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ButWithSave.Text = "حفظ";
                ButWithSave.Tooltip = "F2";
                ButWithoutSave.Text = "خروج";
                ButWithoutSave.Tooltip = "Esc";
                Text = "خيارات العمولات البنكية";
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
        private void FillComboBankopp()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                try
                {
                    c1FlexGrid1Bankopp.SetData(0, 1, "الفاتورة");
                    c1FlexGrid1Bankopp.SetData(0, 2, "إحتســــاب");
                    c1FlexGrid1Bankopp.SetData(0, 9, "حساب المدين");
                    c1FlexGrid1Bankopp.SetData(0, 10, "حساب الدائن");
                    c1FlexGrid1Bankopp.SetData(0, 11, "قيد محاسبي");
                    c1FlexGrid1Bankopp.SetData(1, 1, "فاتورة مبيعات");
                    c1FlexGrid1Bankopp.SetData(1, 6, 1);
                    c1FlexGrid1Bankopp.SetData(1, 7, 0);
                    c1FlexGrid1Bankopp.SetData(2, 1, "فاتورة مشتريات");
                    c1FlexGrid1Bankopp.SetData(2, 6, 2);
                    c1FlexGrid1Bankopp.SetData(2, 7, 0);
                    c1FlexGrid1Bankopp.SetData(3, 1, "مرتجع مبيعات");
                    c1FlexGrid1Bankopp.SetData(3, 6, 3);
                    c1FlexGrid1Bankopp.SetData(3, 7, 0);
                    c1FlexGrid1Bankopp.Rows[3].Visible = false;
                    c1FlexGrid1Bankopp.SetData(4, 1, "مرتجع مشتريات");
                    c1FlexGrid1Bankopp.SetData(4, 6, 4);
                    c1FlexGrid1Bankopp.SetData(4, 7, 0);
                    c1FlexGrid1Bankopp.Rows[4].Visible = false;
                    c1FlexGrid1Bankopp.SetData(5, 1, "سند أدخال بضاعة");
                    c1FlexGrid1Bankopp.SetData(5, 6, 5);
                    c1FlexGrid1Bankopp.SetData(5, 7, 0);
                    c1FlexGrid1Bankopp.Rows[5].Visible = false;
                    c1FlexGrid1Bankopp.SetData(6, 1, "سند أخراج بضاعة");
                    c1FlexGrid1Bankopp.SetData(6, 6, 6);
                    c1FlexGrid1Bankopp.SetData(6, 7, 0);
                    c1FlexGrid1Bankopp.Rows[6].Visible = false;
                    c1FlexGrid1Bankopp.SetData(7, 1, "عرض سعر عملاء");
                    c1FlexGrid1Bankopp.SetData(7, 6, 7);
                    c1FlexGrid1Bankopp.SetData(7, 7, 0);
                    c1FlexGrid1Bankopp.Rows[7].Visible = false;
                    c1FlexGrid1Bankopp.SetData(8, 1, "عرض سعر مورد");
                    c1FlexGrid1Bankopp.SetData(8, 6, 8);
                    c1FlexGrid1Bankopp.SetData(8, 7, 0);
                    c1FlexGrid1Bankopp.Rows[8].Visible = false;
                    c1FlexGrid1Bankopp.SetData(9, 1, "طلب شراء");
                    c1FlexGrid1Bankopp.SetData(9, 6, 9);
                    c1FlexGrid1Bankopp.SetData(9, 7, 0);
                    c1FlexGrid1Bankopp.Rows[9].Visible = false;
                    c1FlexGrid1Bankopp.SetData(10, 1, "سند تسوية بضاعة");
                    c1FlexGrid1Bankopp.SetData(10, 6, 10);
                    c1FlexGrid1Bankopp.SetData(10, 7, 0);
                    c1FlexGrid1Bankopp.Rows[10].Visible = false;
                    c1FlexGrid1Bankopp.SetData(11, 1, "بضاعة اول المدة");
                    c1FlexGrid1Bankopp.SetData(11, 6, 14);
                    c1FlexGrid1Bankopp.SetData(11, 7, 0);
                    c1FlexGrid1Bankopp.Rows[11].Visible = false;
                    c1FlexGrid1Bankopp.SetData(12, 1, "أمر صرف بضاعة");
                    c1FlexGrid1Bankopp.SetData(12, 6, 17);
                    c1FlexGrid1Bankopp.SetData(12, 7, 0);
                    c1FlexGrid1Bankopp.Rows[12].Visible = false;
                    c1FlexGrid1Bankopp.SetData(13, 1, "مرتجع صرف بضاعة");
                    c1FlexGrid1Bankopp.SetData(13, 6, 20);
                    c1FlexGrid1Bankopp.SetData(13, 7, 0);
                    c1FlexGrid1Bankopp.Rows[13].Visible = false;
                    c1FlexGrid1Bankopp.SetData(14, 1, "إنتاج الأصناف - تصنيع");
                    c1FlexGrid1Bankopp.SetData(14, 6, 16);
                    c1FlexGrid1Bankopp.SetData(14, 7, 0);
                    c1FlexGrid1Bankopp.Rows[14].Visible = false;
                }
                catch
                {
                }
                return;
            }
            try
            {
                c1FlexGrid1Bankopp.SetData(0, 1, "Invoice");
                c1FlexGrid1Bankopp.SetData(0, 2, "Issuance");
                c1FlexGrid1Bankopp.SetData(0, 3, "Print");
                c1FlexGrid1Bankopp.SetData(0, 4, "Sales Tax");
                c1FlexGrid1Bankopp.SetData(0, 5, "Purchaes Tax");
                c1FlexGrid1Bankopp.SetData(0, 9, "Debitor Acc");
                c1FlexGrid1Bankopp.SetData(0, 10, "Creditor Acc");
                c1FlexGrid1Bankopp.SetData(0, 11, "Create Gaid");
                c1FlexGrid1Bankopp.SetData(1, 1, "Sales Invoice");
                c1FlexGrid1Bankopp.SetData(1, 6, 1);
                c1FlexGrid1Bankopp.SetData(1, 7, 0);
                c1FlexGrid1Bankopp.SetData(2, 1, "Purchase Receipt");
                c1FlexGrid1Bankopp.SetData(2, 6, 2);
                c1FlexGrid1Bankopp.SetData(2, 7, 0);
                c1FlexGrid1Bankopp.SetData(3, 1, "Sales Return");
                c1FlexGrid1Bankopp.SetData(3, 6, 3);
                c1FlexGrid1Bankopp.SetData(3, 7, 0);
                c1FlexGrid1Bankopp.Rows[3].Visible = false;
                c1FlexGrid1Bankopp.SetData(4, 1, "Purchase Return");
                c1FlexGrid1Bankopp.SetData(4, 6, 4);
                c1FlexGrid1Bankopp.SetData(4, 7, 0);
                c1FlexGrid1Bankopp.Rows[4].Visible = false;
                c1FlexGrid1Bankopp.SetData(5, 1, "Transfer In");
                c1FlexGrid1Bankopp.SetData(5, 6, 5);
                c1FlexGrid1Bankopp.SetData(5, 7, 0);
                c1FlexGrid1Bankopp.Rows[5].Visible = false;
                c1FlexGrid1Bankopp.SetData(6, 1, "Transfer Out");
                c1FlexGrid1Bankopp.SetData(6, 6, 6);
                c1FlexGrid1Bankopp.SetData(6, 7, 0);
                c1FlexGrid1Bankopp.Rows[6].Visible = false;
                c1FlexGrid1Bankopp.SetData(7, 1, "Customer Qutation");
                c1FlexGrid1Bankopp.SetData(7, 6, 7);
                c1FlexGrid1Bankopp.SetData(7, 7, 0);
                c1FlexGrid1Bankopp.Rows[7].Visible = false;
                c1FlexGrid1Bankopp.SetData(8, 1, "Supplier Qutation");
                c1FlexGrid1Bankopp.SetData(8, 6, 8);
                c1FlexGrid1Bankopp.SetData(8, 7, 0);
                c1FlexGrid1Bankopp.Rows[8].Visible = false;
                c1FlexGrid1Bankopp.SetData(9, 1, "Purchase Order");
                c1FlexGrid1Bankopp.SetData(9, 6, 9);
                c1FlexGrid1Bankopp.SetData(9, 7, 0);
                c1FlexGrid1Bankopp.Rows[9].Visible = false;
                c1FlexGrid1Bankopp.SetData(10, 1, "Stock Adjustment");
                c1FlexGrid1Bankopp.SetData(10, 6, 10);
                c1FlexGrid1Bankopp.SetData(10, 7, 0);
                c1FlexGrid1Bankopp.Rows[10].Visible = false;
                c1FlexGrid1Bankopp.SetData(11, 1, "Open Quantities");
                c1FlexGrid1Bankopp.SetData(11, 6, 14);
                c1FlexGrid1Bankopp.SetData(11, 7, 0);
                c1FlexGrid1Bankopp.Rows[11].Visible = false;
                c1FlexGrid1Bankopp.SetData(12, 1, "Payment Order");
                c1FlexGrid1Bankopp.SetData(12, 6, 17);
                c1FlexGrid1Bankopp.SetData(12, 7, 0);
                c1FlexGrid1Bankopp.Rows[12].Visible = false;
                c1FlexGrid1Bankopp.SetData(13, 1, "Payment Order Return");
                c1FlexGrid1Bankopp.SetData(13, 6, 20);
                c1FlexGrid1Bankopp.SetData(13, 7, 0);
                c1FlexGrid1Bankopp.Rows[13].Visible = false;
                c1FlexGrid1Bankopp.SetData(14, 1, "Production of varieties - Manufacture");
                c1FlexGrid1Bankopp.SetData(14, 6, 16);
                c1FlexGrid1Bankopp.SetData(14, 7, 0);
                c1FlexGrid1Bankopp.Rows[14].Visible = false;
            }
            catch
            {
            }
        }
        private void SaveDataBankopp()
        {
            try
            {
                for (int iiCnt = 1; iiCnt < c1FlexGrid1Bankopp.Rows.Count; iiCnt++)
                {
                    for (int i = 0; i < listInvSettingBankopp.Count; i++)
                    {
                        _InvSettingBankopp = listInvSettingBankopp[i];
                        if (_InvSettingBankopp.InvID == int.Parse(c1FlexGrid1Bankopp.GetData(iiCnt, 6).ToString()))
                        {
                            _InvSettingBankopp.CommOptions = VarGeneral.TString.ChkStatSave((bool)c1FlexGrid1Bankopp.GetData(iiCnt, 2)) + VarGeneral.TString.ChkStatSave((bool)c1FlexGrid1Bankopp.GetData(iiCnt, 3));
                            try
                            {
                                _InvSettingBankopp.CommDebit = c1FlexGrid1Bankopp.GetData(iiCnt, 9).ToString();
                            }
                            catch
                            {
                                _InvSettingBankopp.CommDebit = "***";
                            }
                            try
                            {
                                _InvSettingBankopp.CommCredit = c1FlexGrid1Bankopp.GetData(iiCnt, 10).ToString();
                            }
                            catch
                            {
                                _InvSettingBankopp.CommCredit = "***";
                            }
                            _InvSettingBankopp.autoCommGaid = Convert.ToBoolean(c1FlexGrid1Bankopp.GetData(iiCnt, 11));
                            db.Log = VarGeneral.DebugLog;
                            db.SubmitChanges(ConflictMode.ContinueOnConflict);
                            break;
                        }
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
        private void BindDataBankopp()
        {
            try
            {
                State = FormState.Saved;
                ButWithSave.Enabled = false;
                for (int iiCnt = 1; iiCnt < c1FlexGrid1Bankopp.Rows.Count; iiCnt++)
                {
                    for (int i = 0; i < listInvSettingBankopp.Count; i++)
                    {
                        _InvSettingBankopp = listInvSettingBankopp[i];
                        if (_InvSettingBankopp.InvID == int.Parse(c1FlexGrid1Bankopp.GetData(iiCnt, 6).ToString()))
                        {
                            c1FlexGrid1Bankopp.SetData(iiCnt, 2, VarGeneral.TString.ChkStatShow(_InvSettingBankopp.CommOptions, 0));
                            c1FlexGrid1Bankopp.SetData(iiCnt, 3, VarGeneral.TString.ChkStatShow(_InvSettingBankopp.CommOptions, 1));
                            c1FlexGrid1Bankopp.SetData(iiCnt, 9, _InvSettingBankopp.CommDebit);
                            c1FlexGrid1Bankopp.SetData(iiCnt, 10, _InvSettingBankopp.CommCredit);
                            c1FlexGrid1Bankopp.SetData(iiCnt, 11, _InvSettingBankopp.autoCommGaid);
                            break;
                        }
                    }
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
        private void c1FlexGrid1Bankopp_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }

        private void ButWithSave_Click(object sender, EventArgs e)
        {
            SaveDataBankopp();
            State = FormState.Saved;
            SetReadOnly = true;
        }
        private void FrmCommOpiton_KeyDown(object sender, KeyEventArgs e)
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
        private void FrmCommOpiton_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
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
                if (Convert.ToBoolean(c1FlexGrid1Bankopp.Rows[e.Row][4]))
                {
                    c1FlexGrid1Bankopp.Rows[e.Row][5] = false;
                }
                else
                {
                    c1FlexGrid1Bankopp.Rows[e.Row][5] = true;
                }
            }
            else if (Convert.ToBoolean(c1FlexGrid1Bankopp.Rows[e.Row][5]))
            {
                c1FlexGrid1Bankopp.Rows[e.Row][4] = false;
            }
            else
            {
                c1FlexGrid1Bankopp.Rows[e.Row][4] = true;
            }
        }
        private void c1FlexGrid1_DoubleClick(object sender, EventArgs e)
        {
            if ((c1FlexGrid1Bankopp.Col != 9 && c1FlexGrid1Bankopp.Col != 10) || c1FlexGrid1Bankopp.Row <= 0 || (c1FlexGrid1Bankopp.Col == 9 && c1FlexGrid1Bankopp.Row == 1) || (c1FlexGrid1Bankopp.Col == 10 && c1FlexGrid1Bankopp.Row == 2))
            {
                return;
            }
            columns_Names_visibleBankopp.Clear();
            columns_Names_visibleBankopp.Add("AccDef_No", new ColumnDictinaryBankopp("الرقم ", " No", ifDefault: true, ""));
            columns_Names_visibleBankopp.Add("Arb_Des", new ColumnDictinaryBankopp("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visibleBankopp.Add("Eng_Des", new ColumnDictinaryBankopp("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            columns_Names_visibleBankopp.Add("AccDef_ID", new ColumnDictinaryBankopp(" ", " ", ifDefault: false, ""));
            columns_Names_visibleBankopp.Add("Mobile", new ColumnDictinaryBankopp("الجوال", "Mobile", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinaryBankopp>> animalsAsCollection = columns_Names_visibleBankopp;
            foreach (KeyValuePair<string, ColumnDictinaryBankopp> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != "")
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    c1FlexGrid1Bankopp.SetData(c1FlexGrid1Bankopp.Row, c1FlexGrid1Bankopp.Col, _AccDef.AccDef_No.ToString());
                }
                else
                {
                    c1FlexGrid1Bankopp.SetData(c1FlexGrid1Bankopp.Row, c1FlexGrid1Bankopp.Col, "***");
                }
            }
            catch
            {
                c1FlexGrid1Bankopp.SetData(c1FlexGrid1Bankopp.Row, c1FlexGrid1Bankopp.Col, "***");
            }
            VarGeneral.Flush();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCommOpiton));
            this.c1FlexGrid1Bankopp = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.ButWithoutSave = new DevComponents.DotNetBar.ButtonX();
            this.ButWithSave = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1Bankopp)).BeginInit();
            this.SuspendLayout();
            // 
            // c1FlexGrid1Bankopp
            // 
            this.c1FlexGrid1Bankopp.ColumnInfo = resources.GetString("c1FlexGrid1Bankopp.ColumnInfo");
            this.c1FlexGrid1Bankopp.Dock = System.Windows.Forms.DockStyle.Top;
            this.c1FlexGrid1Bankopp.Font = new System.Drawing.Font("Tahoma", 8F);
            this.c1FlexGrid1Bankopp.Location = new System.Drawing.Point(0, 0);
            this.c1FlexGrid1Bankopp.Name = "c1FlexGrid1Bankopp";
            this.c1FlexGrid1Bankopp.Rows.Count = 15;
            this.c1FlexGrid1Bankopp.Rows.DefaultSize = 19;
            this.c1FlexGrid1Bankopp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.c1FlexGrid1Bankopp.Size = new System.Drawing.Size(542, 168);
            this.c1FlexGrid1Bankopp.StyleInfo = resources.GetString("c1FlexGrid1Bankopp.StyleInfo");
            this.c1FlexGrid1Bankopp.TabIndex = 22;
            this.c1FlexGrid1Bankopp.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Black;
            this.c1FlexGrid1Bankopp.CellChecked += new C1.Win.C1FlexGrid.RowColEventHandler(this.c1FlexGrid1_CellChecked);
            this.c1FlexGrid1Bankopp.Click += new System.EventHandler(this.c1FlexGrid1Bankopp_Click);
            this.c1FlexGrid1Bankopp.DoubleClick += new System.EventHandler(this.c1FlexGrid1_DoubleClick);
            // 
            // ButWithoutSave
            // 
            this.ButWithoutSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButWithoutSave.Checked = true;
            this.ButWithoutSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ButWithoutSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButWithoutSave.Location = new System.Drawing.Point(2, 171);
            this.ButWithoutSave.Name = "ButWithoutSave";
            this.ButWithoutSave.Size = new System.Drawing.Size(268, 48);
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
            this.ButWithSave.Location = new System.Drawing.Point(274, 171);
            this.ButWithSave.Name = "ButWithSave";
            this.ButWithSave.Size = new System.Drawing.Size(268, 48);
            this.ButWithSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButWithSave.Symbol = "";
            this.ButWithSave.SymbolSize = 16F;
            this.ButWithSave.TabIndex = 6784;
            this.ButWithSave.Text = "حفــــظ";
            this.ButWithSave.TextColor = System.Drawing.Color.White;
            this.ButWithSave.Click += new System.EventHandler(this.ButWithSave_Click);
            // 
            // FrmCommOpiton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 221);
            this.ControlBox = false;
            this.Controls.Add(this.ButWithoutSave);
            this.Controls.Add(this.ButWithSave);
            this.Controls.Add(this.c1FlexGrid1Bankopp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.KeyPreview = true;
            this.Name = "FrmCommOpiton";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "خيارات العمولات البنكية";
            this.Load += new System.EventHandler(this.FrmCommOpiton_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCommOpiton_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmCommOpiton_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1Bankopp)).EndInit();
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.ResumeLayout(false);
        }
    }
}
