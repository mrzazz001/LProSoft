using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using InvAcc.GeneralM;
using InvAcc.Properties;
using InvAcc.Stock_Data;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmCustSearch : Form
    {
        public int vTy_ = 0;
        public string Serach_No = "";
        public string sts_ = "";
        private string vNo = "";
        private int vTyp = 0;
        private bool frmSts_ = false;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private int LangArEn = 0;
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRt;
        private MetroTileItem vItemSelect = new MetroTileItem();
        private IContainer components = null;
        protected ContextMenuStrip contextMenuStrip2;
        protected ToolStripMenuItem ToolStripMenuItem_Det;
        protected ToolStripMenuItem ToolStripMenuItem_Rep;
        protected ContextMenuStrip contextMenuStrip1;
        private SuperTabControl superTabControl_Tables;
        private SuperTabControlPanel superTabControlPanel1;
        private MetroTilePanel metroTilePanel_Customer;
        private ItemContainer itemContainer_Customer;
        private SuperTabItem superTabItem_Customer;
        private ExpandablePanel expandablePanel_Table;
        private ItemPanel itemPanel2;
        private ItemPanel itemPanel1;
        private LabelItem labelItem_Tables;
        private LabelItem labelItem_Note;
        private LabelItem labelItem_Time;
        private LabelItem labelItem_Nadel;
        private Panel panel_ButSave;
        private ButtonX ButOk;
        private LabelItem labelItem_Type;
        private LabelItem labelItem_SumTable;
        private LabelItem labelItem2;
        private LabelItem labelItem_Mobile;
        private TextBoxItem txtSearchMobile;
        private CheckBoxItem checkBox_ByMobile;
        private CheckBoxItem checkBox_ByName;
        public string SerachNo
        {
            get
            {
                return Serach_No;
            }
            set
            {
                Serach_No = value;
            }
        }
        public string RomeStatus
        {
            get
            {
                return sts_;
            }
            set
            {
                sts_ = value;
            }
        }
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
        private Rate_DataDataContext dbc
        {
            get
            {
                if (dbInstanceRt == null)
                {
                    dbInstanceRt = new Rate_DataDataContext(VarGeneral.BranchRt);
                }
                return dbInstanceRt;
            }
        }
        public bool VisibleSts
        {
            set
            {
                if (!frmSts_)
                {
                    panel_ButSave.Visible = !value;
                }
                else
                {
                    panel_ButSave.Visible = false;
                }
            }
        }
        public FrmCustSearch()
        {
            InitializeComponent();
        }
        private void FrmCustSearch_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmCustSearch));
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    Language.ChangeLanguage("ar-SA", this, resources);
                    LangArEn = 0;
                    if (vTy_ == 0)
                    {
                        superTabItem_Customer.Text = "العمــــلاء";
                        labelItem_Mobile.Visible = true;
                        txtSearchMobile.Visible = true;
                    }
                    else if (vTy_ == 1)
                    {
                        superTabItem_Customer.Text = "النـــادل";
                    }
                    else if (vTy_ == 2)
                    {
                        superTabItem_Customer.Text = "مراكز التكلفة";
                    }
                    else if (vTy_ == 3)
                    {
                        superTabItem_Customer.Text = "السائقــين";
                    }
                    else if (vTy_ == 4)
                    {
                        superTabItem_Customer.Text = "المندوبـــين";
                    }
                    else if (vTy_ == 5)
                    {
                        superTabItem_Customer.Text = "العمـــلات";
                    }
                    else if (vTy_ == 6)
                    {
                        superTabItem_Customer.Text = "الأسعـــار";
                        itemPanel1.Visible = false;
                    }
                    else if (vTy_ == 7)
                    {
                        superTabItem_Customer.Text = "الفواتــير";
                    }
                }
                else
                {
                    Language.ChangeLanguage("en", this, resources);
                    LangArEn = 1;
                    superTabItem_Customer.Text = "Customers";
                    if (vTy_ == 0)
                    {
                        superTabItem_Customer.Text = "Customers";
                        labelItem_Mobile.Visible = true;
                        txtSearchMobile.Visible = true;
                        labelItem2.Text = "      Search By";
                        labelItem_Mobile.Text = "Cust Mobile";
                        checkBox_ByMobile.Text = "Cust Mobile";
                        checkBox_ByName.Text = "Cust Name";
                        txtSearchMobile.ButtonCustom.Text = "Search";
                        txtSearchMobile.ButtonCustom.Text = "Clear";
                    }
                    else if (vTy_ == 1)
                    {
                        superTabItem_Customer.Text = "Waiter";
                    }
                    else if (vTy_ == 2)
                    {
                        superTabItem_Customer.Text = "Cost Centers";
                    }
                    else if (vTy_ == 3)
                    {
                        superTabItem_Customer.Text = "Drivers";
                    }
                    else if (vTy_ == 4)
                    {
                        superTabItem_Customer.Text = "Delegates";
                    }
                    else if (vTy_ == 5)
                    {
                        superTabItem_Customer.Text = "Currncies";
                    }
                    else if (vTy_ == 6)
                    {
                        superTabItem_Customer.Text = "Prices";
                        itemPanel1.Visible = false;
                    }
                    else if (vTy_ == 7)
                    {
                        superTabItem_Customer.Text = "Inovices";
                    }
                    ButOk.Text = "Selected";
                    expandablePanel_Table.TitleText = "Informations Bar";
                }
                FillItems();
                TableInfo("");
                VisibleSts = true;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void TableInfo(string vTableNo)
        {
            if (!string.IsNullOrEmpty(vTableNo))
            {
                if (vTy_ == 0)
                {
                    List<T_AccDef> q2 = db.T_AccDefs.Where((T_AccDef t) => t.AccDef_No == vTableNo).ToList();
                    labelItem_Tables.Text = ((LangArEn == 0) ? "رقم العميل : " : "Customer No : ") + q2.FirstOrDefault().AccDef_No;
                    labelItem_Note.Text = ((LangArEn == 0) ? "إسم العميل - عـربــي : " : "Customer Name A : ") + q2.FirstOrDefault().Arb_Des;
                    labelItem_Time.Text = ((LangArEn == 0) ? "إسم العميل - إنجليزي : " : "Customer Name E : ") + q2.FirstOrDefault().Eng_Des;
                    labelItem_Nadel.Text = ((LangArEn == 0) ? "إجمالي المدين : " : "Debit Total : ") + q2.FirstOrDefault().Debit.Value + "    |    " + ((LangArEn == 0) ? " إجمالي الدائن : " : "Credit Total : ") + q2.FirstOrDefault().Credit.Value;
                    labelItem_Type.Text = ((LangArEn == 0) ? " رصيد العميل : " : "Balance : ") + q2.FirstOrDefault().Balance.Value;
                }
                else if (vTy_ == 1)
                {
                    var q3 = from t in db.T_Waiters
                             where t.waiter_No == vTableNo
                             orderby t.waiter_No
                             select new
                             {
                                 t.waiter_No,
                                 t.Arb_Des,
                                 t.Eng_Des
                             };
                    labelItem_Tables.Text = ((LangArEn == 0) ? "رقم النادل : " : "Waiter No : ") + q3.FirstOrDefault().waiter_No;
                    labelItem_Note.Text = ((LangArEn == 0) ? "إسم النادل - عـربــي : " : "Waiter Name A : ") + q3.FirstOrDefault().Arb_Des;
                    labelItem_Time.Text = ((LangArEn == 0) ? "إسم النادل - إنجليزي : " : "Waiter Name E : ") + q3.FirstOrDefault().Eng_Des;
                    labelItem_Nadel.Text = "";
                    labelItem_Type.Text = "";
                }
                else if (vTy_ == 2)
                {
                    var q4 = from t in db.T_CstTbls
                             where t.Cst_No == vTableNo
                             orderby t.Cst_No
                             select new
                             {
                                 t.Cst_No,
                                 t.Arb_Des,
                                 t.Eng_Des
                             };
                    labelItem_Tables.Text = ((LangArEn == 0) ? "رقم مركز التكلفة : " : "No : ") + q4.FirstOrDefault().Cst_No;
                    labelItem_Note.Text = ((LangArEn == 0) ? "إسم مركز التكلفة - عـربــي : " : "Name A : ") + q4.FirstOrDefault().Arb_Des;
                    labelItem_Time.Text = ((LangArEn == 0) ? "إسم مركز التكلفة - إنجليزي : " : "Name E : ") + q4.FirstOrDefault().Eng_Des;
                    labelItem_Nadel.Text = "";
                    labelItem_Type.Text = "";
                }
                else if (vTy_ == 3)
                {
                    var q5 = from t in db.T_Chauffeurs
                             where t.chauffeur_No == vTableNo
                             orderby t.chauffeur_No
                             select new
                             {
                                 t.chauffeur_No,
                                 t.Arb_Des,
                                 t.Eng_Des
                             };
                    labelItem_Tables.Text = ((LangArEn == 0) ? "رقم السائق : " : "No : ") + q5.FirstOrDefault().chauffeur_No;
                    labelItem_Note.Text = ((LangArEn == 0) ? "إسم السائق - عـربــي : " : "Name A : ") + q5.FirstOrDefault().Arb_Des;
                    labelItem_Time.Text = ((LangArEn == 0) ? "إسم السائق - إنجليزي : " : "Name E : ") + q5.FirstOrDefault().Eng_Des;
                    labelItem_Nadel.Text = "";
                    labelItem_Type.Text = "";
                }
                else if (vTy_ == 4)
                {
                    var q6 = from t in db.T_Mndobs
                             where t.Mnd_No == vTableNo
                             where t.Mnd_Typ == (int?)0
                             orderby t.Mnd_No
                             select new
                             {
                                 t.Mnd_No,
                                 t.Arb_Des,
                                 t.Eng_Des
                             };
                    labelItem_Tables.Text = ((LangArEn == 0) ? "رقم المندوب : " : "No : ") + q6.FirstOrDefault().Mnd_No;
                    labelItem_Note.Text = ((LangArEn == 0) ? "إسم المندوب - عـربــي : " : "Name A : ") + q6.FirstOrDefault().Arb_Des;
                    labelItem_Time.Text = ((LangArEn == 0) ? "إسم المندوب - إنجليزي : " : "Name E : ") + q6.FirstOrDefault().Eng_Des;
                    labelItem_Nadel.Text = "";
                    labelItem_Type.Text = "";
                }
                else if (vTy_ == 5)
                {
                    var q7 = from t in db.T_Curencies
                             where t.Curency_No == vTableNo
                             orderby t.Curency_No
                             select new
                             {
                                 t.Curency_No,
                                 t.Arb_Des,
                                 t.Eng_Des,
                                 t.Symbol,
                                 t.Rate
                             };
                    labelItem_Tables.Text = ((LangArEn == 0) ? "رقم العملة : " : "No : ") + q7.FirstOrDefault().Curency_No;
                    labelItem_Note.Text = ((LangArEn == 0) ? "إسم العملة - عـربــي : " : "Name A : ") + q7.FirstOrDefault().Arb_Des;
                    labelItem_Time.Text = ((LangArEn == 0) ? "إسم العملة - إنجليزي : " : "Name E : ") + q7.FirstOrDefault().Eng_Des;
                    labelItem_Nadel.Text = ((LangArEn == 0) ? "سعر الصرف : " : "Exchange Rate : ") + q7.FirstOrDefault().Rate.Value;
                    labelItem_Type.Text = ((LangArEn == 0) ? " الــرمـز : " : "Symbol : ") + q7.FirstOrDefault().Symbol;
                }
                else if (vTy_ == 6)
                {
                    labelItem_Tables.Text = "";
                    labelItem_Note.Text = "";
                    labelItem_Time.Text = "";
                    labelItem_Nadel.Text = "";
                    labelItem_Type.Text = "";
                }
                if (vTy_ == 7)
                {
                    List<T_INVHED> q = (from t in db.T_INVHEDs
                                        where t.InvNo == vTableNo
                                        where t.InvTyp == (int?)VarGeneral.InvTyp
                                        where t.IfDel == (int?)0

                                        select t).ToList();
                    labelItem_Tables.Text = ((LangArEn == 0) ? "رقم الفاتورة : " : "Customer No : ") + q.FirstOrDefault().InvNo;
                    labelItem_Note.Text = ((LangArEn == 0) ? "تاريخ الفاتورة هجري : " : "Date Hij : ") + q.FirstOrDefault().HDat + "    |    " + ((LangArEn == 0) ? " تاريخ الفاتورة ميلادي : " : "Date Ger : ") + q.FirstOrDefault().GDat;
                    labelItem_Time.Text = ((LangArEn == 0) ? "إجمالي الفاتورة : " : "Invoice Total : ") + q.FirstOrDefault().InvTotLocCur.Value + "    |    " + ((LangArEn == 0) ? " صافي الفاتورة : " : "Invoice Net : ") + q.FirstOrDefault().InvNetLocCur.Value;
                    labelItem_Nadel.Text = ((LangArEn == 0) ? "إسم العميل : " : "Customer Name : ") + q.FirstOrDefault().CusVenNm + "    |    " + ((LangArEn == 0) ? " رقم العميل : " : "Customer No : ") + q.FirstOrDefault().CusVenNo;
                    labelItem_Type.Text = ((LangArEn == 0) ? " الملاحظـــات : " : "Notes : ") + q.FirstOrDefault().Remark;
                }
            }
            else
            {
                if (vTy_ == 0)
                {
                    labelItem_Tables.Text = "رقم العميل : لا يوجد ";
                    labelItem_Note.Text = "إسم العميل - عربي : لا يوجد ";
                    labelItem_Time.Text = "إسم العميل - انجليزي : لا يوجد ";
                    labelItem_Nadel.Text = "إجمالي المدين والدائن : لا يوجد";
                    labelItem_Type.Text = "لم يتم تحديد عميل ";
                }
                else if (vTy_ == 1)
                {
                    labelItem_Tables.Text = "رقم النادل : لا يوجد ";
                    labelItem_Note.Text = "إسم النادل - عربي : لا يوجد ";
                    labelItem_Time.Text = "إسم النادل - انجليزي : لا يوجد ";
                    labelItem_Nadel.Text = "";
                    labelItem_Type.Text = "لم يتم تحديد النادل ";
                }
                else if (vTy_ == 2)
                {
                    labelItem_Tables.Text = "رقم مركز التكلفة : لا يوجد ";
                    labelItem_Note.Text = "إسم مركز التكلفة - عربي : لا يوجد ";
                    labelItem_Time.Text = "إسم مركز التكلفة - انجليزي : لا يوجد ";
                    labelItem_Nadel.Text = "";
                    labelItem_Type.Text = "لم يتم تحديد مركز التكلفة ";
                }
                else if (vTy_ == 3)
                {
                    labelItem_Tables.Text = "رقم السائق : لا يوجد ";
                    labelItem_Note.Text = "إسم السائق - عربي : لا يوجد ";
                    labelItem_Time.Text = "إسم السائق - انجليزي : لا يوجد ";
                    labelItem_Nadel.Text = "";
                    labelItem_Type.Text = "لم يتم تحديد سائق ";
                }
                else if (vTy_ == 4)
                {
                    labelItem_Tables.Text = "رقم المندوب : لا يوجد ";
                    labelItem_Note.Text = "إسم المندوب - عربي : لا يوجد ";
                    labelItem_Time.Text = "إسم المندوب - انجليزي : لا يوجد ";
                    labelItem_Nadel.Text = "";
                    labelItem_Type.Text = "لم يتم تحديد مندوب ";
                }
                else if (vTy_ == 5)
                {
                    labelItem_Tables.Text = "رقم العملة : لا يوجد ";
                    labelItem_Note.Text = "إسم العملة - عربي : لا يوجد ";
                    labelItem_Time.Text = "إسم العملة - انجليزي : لا يوجد ";
                    labelItem_Nadel.Text = "سعر الصرف : لا يوجد ";
                    labelItem_Type.Text = "لم يتم تحديد عمــلة ";
                }
                else if (vTy_ == 6)
                {
                    labelItem_Tables.Text = "";
                    labelItem_Note.Text = "";
                    labelItem_Time.Text = "";
                    labelItem_Nadel.Text = "";
                    labelItem_Type.Text = "";
                }
                if (vTy_ == 7)
                {
                    labelItem_Tables.Text = "رقم الفاتورة : لا يوجد ";
                    labelItem_Note.Text = "صافي الفاتورة : لا يوجد ";
                    labelItem_Time.Text = "صافي الفاتورة : لا يوجد ";
                    labelItem_Nadel.Text = "إسم العميل  : لا يوجد ";
                    labelItem_Type.Text = "لم يتم تحديد فاتورة ";
                }
            }
            if (vTy_ == 0)
            {
                labelItem_SumTable.Text = ((LangArEn == 0) ? "إجمالي عدد العملاء : " : "Customers Total : ") + itemContainer_Customer.SubItems.Count + ((LangArEn == 0) ? " عميل " : "Customer");
            }
            else if (vTy_ == 1)
            {
                labelItem_SumTable.Text = ((LangArEn == 0) ? "إجمالي عدد النادلين : " : "Waiters Total : ") + itemContainer_Customer.SubItems.Count + ((LangArEn == 0) ? " نادل " : "Waiter");
            }
            else if (vTy_ == 2)
            {
                labelItem_SumTable.Text = ((LangArEn == 0) ? "إجمالي عدد المراكز : " : "Total : ") + itemContainer_Customer.SubItems.Count + ((LangArEn == 0) ? " مركز " : "Center");
            }
            else if (vTy_ == 3)
            {
                labelItem_SumTable.Text = ((LangArEn == 0) ? "إجمالي عدد السائقين : " : "Drivers Total : ") + itemContainer_Customer.SubItems.Count + ((LangArEn == 0) ? " سائق " : "Driver");
            }
            else if (vTy_ == 4)
            {
                labelItem_SumTable.Text = ((LangArEn == 0) ? "إجمالي عدد المندوبـين : " : "Drivers Total : ") + itemContainer_Customer.SubItems.Count + ((LangArEn == 0) ? " مندوب " : "Delegate");
            }
            else if (vTy_ == 5)
            {
                labelItem_SumTable.Text = ((LangArEn == 0) ? "إجمالي عدد العمــلات : " : "Currncies Total : ") + itemContainer_Customer.SubItems.Count + ((LangArEn == 0) ? " عملة " : "Currncy");
            }
            else if (vTy_ == 6)
            {
                labelItem_SumTable.Text = ((LangArEn == 0) ? "إجمالي عدد الأسعار : " : "Prices Total : ") + itemContainer_Customer.SubItems.Count + ((LangArEn == 0) ? " سعر " : "Price");
            }
            else if (vTy_ == 7)
            {
                labelItem_SumTable.Text = ((LangArEn == 0) ? "إجمالي عدد الفواتـير : " : "Inoices Total : ") + itemContainer_Customer.SubItems.Count + ((LangArEn == 0) ? " فاتورة " : "Invoice");
            }
        }
        private void FillItems()
        {
            try
            {
                itemContainer_Customer.SubItems.Clear();
                if (vTy_ == 0)
                {
                    List<T_AccDef> LAccDef2 = new List<T_AccDef>();
                    LAccDef2 = (from t in db.T_AccDefs
                                where t.Lev == (int?)4 && t.AccCat == (int?)VarGeneral.AccTyp && t.Sts == (int?)0 && !t.StopedState.Value
                                where (!string.IsNullOrEmpty(txtSearchMobile.Text) && checkBox_ByMobile.Checked) ? t.Mobile.StartsWith(txtSearchMobile.Text) : ((!string.IsNullOrEmpty(txtSearchMobile.Text) && checkBox_ByName.Checked) ? ((LangArEn == 0) ? t.Arb_Des.Contains(txtSearchMobile.Text) : t.Eng_Des.Contains(txtSearchMobile.Text)) : true)
                                orderby t.AccDef_No
                                select t).ToList();
                    if (LAccDef2.Count() > 0)
                    {
                        for (int i = 0; i < LAccDef2.Count; i++)
                        {
                            LAccDef2[i].Debit = LAccDef2[i].T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.gdValue > 0.0).Sum((T_GDDET g) => g.gdValue.Value);
                            LAccDef2[i].Credit = Math.Abs(LAccDef2[i].T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.gdValue < 0.0).Sum((T_GDDET g) => g.gdValue.Value));
                            LAccDef2[i].Balance = LAccDef2[i].T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok).Sum((T_GDDET g) => g.gdValue.Value);
                        }
                    }
                    if ((VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, VarGeneral.AccTyp) && VarGeneral.AccTyp != 8) || VarGeneral.StockOnly)
                    {
                        LAccDef2 = (from t in db.T_AccDefs
                                    where (t.Lev == (int?)4 && t.Sts == (int?)0 && !t.StopedState.Value && (t.AccCat == (int?)4 || t.AccCat == (int?)5)) || (VarGeneral.StockOnly ? (t.AccDef_No == "4011001") : true)
                                    where (!string.IsNullOrEmpty(txtSearchMobile.Text) && checkBox_ByMobile.Checked) ? t.Mobile.StartsWith(txtSearchMobile.Text) : ((!string.IsNullOrEmpty(txtSearchMobile.Text) && checkBox_ByName.Checked) ? ((LangArEn == 0) ? t.Arb_Des.Contains(txtSearchMobile.Text) : t.Eng_Des.Contains(txtSearchMobile.Text)) : true)
                                    orderby t.AccDef_No
                                    select t).ToList();
                        if (LAccDef2.Count() > 0)
                        {
                            for (int i = 0; i < LAccDef2.Count; i++)
                            {
                                LAccDef2[i].Debit = LAccDef2[i].T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.gdValue > 0.0).Sum((T_GDDET g) => g.gdValue.Value);
                                LAccDef2[i].Credit = Math.Abs(LAccDef2[i].T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.gdValue < 0.0).Sum((T_GDDET g) => g.gdValue.Value));
                                LAccDef2[i].Balance = LAccDef2[i].T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok).Sum((T_GDDET g) => g.gdValue.Value);
                            }
                        }
                        if (VarGeneral.SSSTyp == 0 && VarGeneral.InvTyp == 555)
                        {
                            try
                            {
                                LAccDef2.Insert(0, db.StockAccDef("1020001"));
                            }
                            catch
                            {
                            }
                        }
                    }
                    else if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 6))
                    {
                        LAccDef2 = (from t in db.T_AccDefs
                                    where t.Lev == (int?)4 && t.Sts == (int?)0 && !t.StopedState.Value
                                    where (!string.IsNullOrEmpty(txtSearchMobile.Text) && checkBox_ByMobile.Checked) ? t.Mobile.StartsWith(txtSearchMobile.Text) : ((!string.IsNullOrEmpty(txtSearchMobile.Text) && checkBox_ByName.Checked) ? ((LangArEn == 0) ? t.Arb_Des.Contains(txtSearchMobile.Text) : t.Eng_Des.Contains(txtSearchMobile.Text)) : true)
                                    orderby t.AccDef_No
                                    select t).ToList();
                        if (LAccDef2.Count() > 0)
                        {
                            for (int i = 0; i < LAccDef2.Count; i++)
                            {
                                LAccDef2[i].Debit = LAccDef2[i].T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.gdValue > 0.0).Sum((T_GDDET g) => g.gdValue.Value);
                                LAccDef2[i].Credit = Math.Abs(LAccDef2[i].T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.gdValue < 0.0).Sum((T_GDDET g) => g.gdValue.Value));
                                LAccDef2[i].Balance = LAccDef2[i].T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok).Sum((T_GDDET g) => g.gdValue.Value);
                            }
                        }
                    }
                    if ((VarGeneral.SSSLev == "H" || VarGeneral.SSSLev == "X") && VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 47) && !VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 6))
                    {
                        LAccDef2 = (from t in db.T_AccDefs
                                    where t.Lev == (int?)4 && (t.AccCat == (int?)VarGeneral.AccTyp || t.AccCat == (int?)11) && t.Sts == (int?)0
                                    where !t.StopedState.Value
                                    where (!string.IsNullOrEmpty(txtSearchMobile.Text) && checkBox_ByMobile.Checked) ? t.Mobile.StartsWith(txtSearchMobile.Text) : ((!string.IsNullOrEmpty(txtSearchMobile.Text) && checkBox_ByName.Checked) ? ((LangArEn == 0) ? t.Arb_Des.Contains(txtSearchMobile.Text) : t.Eng_Des.Contains(txtSearchMobile.Text)) : true)
                                    orderby t.AccDef_No
                                    select t).ToList();
                        if (LAccDef2.Count() > 0)
                        {
                            for (int i = 0; i < LAccDef2.Count; i++)
                            {
                                LAccDef2[i].Debit = LAccDef2[i].T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.gdValue > 0.0).Sum((T_GDDET g) => g.gdValue.Value);
                                LAccDef2[i].Credit = Math.Abs(LAccDef2[i].T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.gdValue < 0.0).Sum((T_GDDET g) => g.gdValue.Value));
                                LAccDef2[i].Balance = LAccDef2[i].T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok).Sum((T_GDDET g) => g.gdValue.Value);
                            }
                        }
                        if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, VarGeneral.AccTyp) && VarGeneral.AccTyp != 8)
                        {
                            LAccDef2 = (from t in db.T_AccDefs
                                        where t.Lev == (int?)4 && t.Sts == (int?)0 && (t.AccCat == (int?)4 || t.AccCat == (int?)5 || t.AccCat == (int?)11)
                                        where !t.StopedState.Value
                                        where (!string.IsNullOrEmpty(txtSearchMobile.Text) && checkBox_ByMobile.Checked) ? t.Mobile.StartsWith(txtSearchMobile.Text) : ((!string.IsNullOrEmpty(txtSearchMobile.Text) && checkBox_ByName.Checked) ? ((LangArEn == 0) ? t.Arb_Des.Contains(txtSearchMobile.Text) : t.Eng_Des.Contains(txtSearchMobile.Text)) : true)
                                        orderby t.AccDef_No
                                        select t).ToList();
                            if (LAccDef2.Count() > 0)
                            {
                                for (int i = 0; i < LAccDef2.Count; i++)
                                {
                                    LAccDef2[i].Debit = LAccDef2[i].T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.gdValue > 0.0).Sum((T_GDDET g) => g.gdValue.Value);
                                    LAccDef2[i].Credit = Math.Abs(LAccDef2[i].T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.gdValue < 0.0).Sum((T_GDDET g) => g.gdValue.Value));
                                    LAccDef2[i].Balance = LAccDef2[i].T_GDDETs.Where((T_GDDET g) => !g.T_GDHEAD.gdLok).Sum((T_GDDET g) => g.gdValue.Value);
                                }
                            }
                        }
                    }
                    for (int i = 0; i < LAccDef2.Count; i++)
                    {
                        MetroTileItem vTable = new MetroTileItem();
                        vTable.Image = Resources.Customer;
                        vTable.ImageTextAlignment = ContentAlignment.MiddleCenter;
                        vTable.SymbolColor = Color.Empty;
                        vTable.TileColor = eMetroTileColor.Azure;
                        vTable.TileSize = new Size(160, 150);
                        vTable.TileStyle.CornerType = eCornerType.Diagonal;
                        vTable.TitleText = ((LangArEn == 0) ? LAccDef2[i].Arb_Des : LAccDef2[i].Eng_Des) + "\n" + LAccDef2[i].Mobile;
                        vTable.Tag = LAccDef2[i].AccDef_No.ToString();
                        vTable.TitleTextAlignment = ContentAlignment.BottomCenter;
                        vTable.TitleTextFont = new Font("Tahoma", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
                        itemContainer_Customer.SubItems.AddRange(new BaseItem[1]
                        {
                            vTable
                        });
                    }
                }
                else if (vTy_ == 1)
                {
                    List<T_Waiter> LAccDef5 = new List<T_Waiter>();
                    LAccDef5 = db.T_Waiters.OrderBy((T_Waiter t) => t.waiter_No).ToList();
                    for (int i = 0; i < LAccDef5.Count; i++)
                    {
                        MetroTileItem vTable = new MetroTileItem();
                        vTable.Image = Resources.Customer;
                        vTable.ImageTextAlignment = ContentAlignment.MiddleCenter;
                        vTable.SymbolColor = Color.Empty;
                        vTable.TileColor = eMetroTileColor.Azure;
                        vTable.TileSize = new Size(160, 140);
                        vTable.TileStyle.CornerType = eCornerType.Diagonal;
                        vTable.TitleText = ((LangArEn == 0) ? LAccDef5[i].Arb_Des : LAccDef5[i].Eng_Des);
                        vTable.Tag = LAccDef5[i].waiter_No.ToString();
                        vTable.TitleTextAlignment = ContentAlignment.BottomCenter;
                        vTable.TitleTextFont = new Font("Tahoma", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
                        itemContainer_Customer.SubItems.AddRange(new BaseItem[1]
                        {
                            vTable
                        });
                    }
                }
                else if (vTy_ == 2)
                {
                    List<T_CstTbl> LAccDef7 = new List<T_CstTbl>();
                    LAccDef7 = db.T_CstTbls.OrderBy((T_CstTbl t) => t.Cst_No).ToList();
                    for (int i = 0; i < LAccDef7.Count; i++)
                    {
                        MetroTileItem vTable = new MetroTileItem();
                        vTable.Image = Resources.Customer;
                        vTable.ImageTextAlignment = ContentAlignment.MiddleCenter;
                        vTable.SymbolColor = Color.Empty;
                        vTable.TileColor = eMetroTileColor.Azure;
                        vTable.TileSize = new Size(160, 140);
                        vTable.TileStyle.CornerType = eCornerType.Diagonal;
                        vTable.TitleText = ((LangArEn == 0) ? LAccDef7[i].Arb_Des : LAccDef7[i].Eng_Des);
                        vTable.Tag = LAccDef7[i].Cst_No.ToString();
                        vTable.TitleTextAlignment = ContentAlignment.BottomCenter;
                        vTable.TitleTextFont = new Font("Tahoma", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
                        itemContainer_Customer.SubItems.AddRange(new BaseItem[1]
                        {
                            vTable
                        });
                    }
                }
                else if (vTy_ == 3)
                {
                    List<T_Chauffeur> LAccDef8 = new List<T_Chauffeur>();
                    LAccDef8 = db.T_Chauffeurs.OrderBy((T_Chauffeur t) => t.chauffeur_No).ToList();
                    for (int i = 0; i < LAccDef8.Count; i++)
                    {
                        MetroTileItem vTable = new MetroTileItem();
                        vTable.Image = Resources.Customer;
                        vTable.ImageTextAlignment = ContentAlignment.MiddleCenter;
                        vTable.SymbolColor = Color.Empty;
                        vTable.TileColor = eMetroTileColor.Azure;
                        vTable.TileSize = new Size(160, 140);
                        vTable.TileStyle.CornerType = eCornerType.Diagonal;
                        vTable.TitleText = ((LangArEn == 0) ? LAccDef8[i].Arb_Des : LAccDef8[i].Eng_Des);
                        vTable.Tag = LAccDef8[i].chauffeur_No.ToString();
                        vTable.TitleTextAlignment = ContentAlignment.BottomCenter;
                        vTable.TitleTextFont = new Font("Tahoma", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
                        itemContainer_Customer.SubItems.AddRange(new BaseItem[1]
                        {
                            vTable
                        });
                    }
                }
                else if (vTy_ == 4)
                {
                    List<T_Mndob> LAccDef6 = new List<T_Mndob>();
                    LAccDef6 = (from t in db.T_Mndobs
                                where t.Mnd_Typ == (int?)0
                                orderby t.Mnd_No
                                select t).ToList();
                    for (int i = 0; i < LAccDef6.Count; i++)
                    {
                        MetroTileItem vTable = new MetroTileItem();
                        vTable.Image = Resources.Customer;
                        vTable.ImageTextAlignment = ContentAlignment.MiddleCenter;
                        vTable.SymbolColor = Color.Empty;
                        vTable.TileColor = eMetroTileColor.Azure;
                        vTable.TileSize = new Size(160, 140);
                        vTable.TileStyle.CornerType = eCornerType.Diagonal;
                        vTable.TitleText = ((LangArEn == 0) ? LAccDef6[i].Arb_Des : LAccDef6[i].Eng_Des);
                        vTable.Tag = LAccDef6[i].Mnd_No.ToString();
                        vTable.TitleTextAlignment = ContentAlignment.BottomCenter;
                        vTable.TitleTextFont = new Font("Tahoma", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
                        itemContainer_Customer.SubItems.AddRange(new BaseItem[1]
                        {
                            vTable
                        });
                    }
                }
                else if (vTy_ == 5)
                {
                    List<T_Curency> LAccDef4 = new List<T_Curency>();
                    LAccDef4 = db.T_Curencies.OrderBy((T_Curency t) => t.Curency_No).ToList();
                    for (int i = 0; i < LAccDef4.Count; i++)
                    {
                        MetroTileItem vTable = new MetroTileItem();
                        vTable.Image = Resources.Customer;
                        vTable.ImageTextAlignment = ContentAlignment.MiddleCenter;
                        vTable.SymbolColor = Color.Empty;
                        vTable.TileColor = eMetroTileColor.Azure;
                        vTable.TileSize = new Size(160, 140);
                        vTable.TileStyle.CornerType = eCornerType.Diagonal;
                        vTable.TitleText = ((LangArEn == 0) ? LAccDef4[i].Arb_Des : LAccDef4[i].Eng_Des);
                        vTable.Tag = LAccDef4[i].Curency_No.ToString();
                        vTable.TitleTextAlignment = ContentAlignment.BottomCenter;
                        vTable.TitleTextFont = new Font("Tahoma", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
                        itemContainer_Customer.SubItems.AddRange(new BaseItem[1]
                        {
                            vTable
                        });
                    }
                }
                else if (vTy_ == 6)
                {
                    List<string> LAccDef3 = new List<string>();
                    LAccDef3.Add((LangArEn == 0) ? "الأفتراضي" : "Default");
                    LAccDef3.Add((LangArEn == 0) ? "سعر الجملة" : "Wholesale price");
                    LAccDef3.Add((LangArEn == 0) ? "سعر الموزع" : "Distributor price");
                    LAccDef3.Add((LangArEn == 0) ? "سعر المندوب" : "Legates Price");
                    LAccDef3.Add((LangArEn == 0) ? "سعر التجزئة" : "Retail price");
                    LAccDef3.Add((LangArEn == 0) ? "سعر آخر" : "Other price");
                    for (int i = 0; i < LAccDef3.Count; i++)
                    {
                        MetroTileItem vTable = new MetroTileItem();
                        vTable.Image = Resources.Customer;
                        vTable.ImageTextAlignment = ContentAlignment.MiddleCenter;
                        vTable.SymbolColor = Color.Empty;
                        vTable.TileColor = eMetroTileColor.Azure;
                        vTable.TileSize = new Size(160, 140);
                        vTable.TileStyle.CornerType = eCornerType.Diagonal;
                        vTable.TitleText = LAccDef3[i];
                        vTable.Tag = i;
                        vTable.TitleTextAlignment = ContentAlignment.BottomCenter;
                        vTable.TitleTextFont = new Font("Tahoma", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
                        itemContainer_Customer.SubItems.AddRange(new BaseItem[1]
                        {
                            vTable
                        });
                    }
                }
                else if (vTy_ == 7)
                {
                    List<T_INVHED> LAccDef = new List<T_INVHED>();
                    if (VarGeneral.InvTyp == 21)
                    {
                        LAccDef = (from item in db.T_INVHEDs
                                   where item.InvTyp == (int?)VarGeneral.InvTyp
                                   where item.IfDel == (int?)0
                                   where item.SalsManNo == VarGeneral.UserNo
                                   where item.RoomNo.HasValue
                                   where item.T_Room.T_Waiter.waiter_ID == VarGeneral._WaiterID
                                   where item.PaymentOrderTyp == (int?)0
                                   select item).ToList();
                    }
                    else
                    {
                        int vSts = dbc.StockUser(VarGeneral.UserNo).UserPointTyp.Value;
                        LAccDef = db.ExecuteQuery<T_INVHED>("select T_INVHED.ArbTaf, T_INVHED.CashPay, T_INVHED.CashPayLocCur, T_INVHED.chauffeurNo, T_INVHED.CommMnd_Inv, T_INVHED.CompanyID, T_INVHED.CREATED_BY, T_INVHED.CreditPay, T_INVHED.CreditPayLocCur, T_INVHED.CurTyp, T_INVHED.CustNet, T_INVHED.CustPri, T_INVHED.CustRep, T_INVHED.CusVenAdd, T_INVHED.CusVenNo, T_INVHED.CusVenTel, T_INVHED.DATE_CREATED, T_INVHED.DATE_MODIFIED, T_INVHED.EstDat, T_INVHED.ExtrnalCostGaidID, T_INVHED.GadeId, T_INVHED.GadeNo, T_INVHED.GDat, T_INVHED.HDat, T_INVHED.IfDel, T_INVHED.IfPrint, T_INVHED.IfRet, T_INVHED.IfTrans, T_INVHED.InvAddCost, T_INVHED.InvAddCostExtrnal, T_INVHED.InvAddCostExtrnalLoc, T_INVHED.InvAddCostLoc, T_INVHED.InvCash, T_INVHED.InvCashPay, T_INVHED.InvCashPayNm, T_INVHED.InvCost, T_INVHED.InvCstNo, T_INVHED.InvDisPrs, ((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints, T_INVHED.InvDisValLocCur, T_INVHED.InvHed_ID, T_INVHED.InvId, T_INVHED.InvNet, T_INVHED.InvNetLocCur, T_INVHED.InvNo, T_INVHED.InvQty, T_INVHED.InvTot, T_INVHED.InvTotLocCur, T_INVHED.InvTyp, T_INVHED.InvWight_T, T_INVHED.IsExtrnalGaid, T_INVHED.LTim, T_INVHED.MndExtrnal, T_INVHED.MndNo, T_INVHED.MODIFIED_BY, T_INVHED.NetworkPay, T_INVHED.NetworkPayLocCur, T_INVHED.OrderTyp, T_INVHED.Puyaid, T_INVHED.RefNo, T_INVHED.Remark, T_INVHED.Remming, T_INVHED.RetId, T_INVHED.RetNo, T_INVHED.RoomNo, T_INVHED.RoomPerson, T_INVHED.RoomSts, T_INVHED.SalsManNam, T_INVHED.SalsManNo, T_INVHED.ServiceValue, T_INVHED.Sts, T_INVHED.ToStore, T_INVHED.ToStoreNm,case when T_INVHED.CusVenNo <> '' then (select " + ((LangArEn == 0) ? " T_AccDef.Arb_Des " : " T_AccDef.Eng_Des") + " from T_AccDef where T_AccDef.AccDef_No = T_INVHED.CusVenNo) else T_INVHED.CusVenNm end as CusVenNm from T_INVHED where InvTyp = " + VarGeneral.InvTyp + " and IfDel <> 1 and PaymentOrderTyp = 0 " + ((VarGeneral.InvTyp == 1) ? " and T_INVHED.InvId > 0 and T_INVHED.InvId != '' " : " ") + ((vSts == 1) ? (" and SalsManNo = '" + VarGeneral.UserNo + "'") : "  order by InvHed_ID") + ((!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 25)) ? " and (InvCashPay = 0 or InvCashPay=2)  " : " "), new object[0]).ToList();
                    }
                    for (int i = 0; i < LAccDef.Count; i++)
                    {
                        MetroTileItem vTable = new MetroTileItem();
                        vTable.Image = Resources.Customer;
                        vTable.ImageTextAlignment = ContentAlignment.MiddleCenter;
                        vTable.SymbolColor = Color.Empty;
                        vTable.TileColor = eMetroTileColor.Azure;
                        vTable.TileSize = new Size(160, 140);
                        vTable.TileStyle.CornerType = eCornerType.Diagonal;
                        vTable.TitleText = LAccDef[i].InvNo.ToString();
                        vTable.Tag = LAccDef[i].InvNo.ToString();
                        vTable.TitleTextAlignment = ContentAlignment.BottomCenter;
                        vTable.TitleTextFont = new Font("Tahoma", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
                        itemContainer_Customer.SubItems.AddRange(new BaseItem[1]
                        {
                            vTable
                        });
                    }

                }
                else if (vTy_ == 8)
                {
                    List<T_INVHED> LAccDef = new List<T_INVHED>();
                    if (true)
                    {
                        LAccDef = (from item in db.T_INVHEDs
                                   where item.InvTyp == (int?)7
                                   where item.IfDel == (int?)0
                                   where item.OrderStatus == 1
                                   select item).ToList();
                    }
                    else
                    {
                        int vSts = dbc.StockUser(VarGeneral.UserNo).UserPointTyp.Value;
                        LAccDef = db.ExecuteQuery<T_INVHED>("select T_INVHED.ArbTaf, T_INVHED.CashPay, T_INVHED.CashPayLocCur, T_INVHED.chauffeurNo, T_INVHED.CommMnd_Inv, T_INVHED.CompanyID, T_INVHED.CREATED_BY, T_INVHED.CreditPay, T_INVHED.CreditPayLocCur, T_INVHED.CurTyp, T_INVHED.CustNet, T_INVHED.CustPri, T_INVHED.CustRep, T_INVHED.CusVenAdd, T_INVHED.CusVenNo, T_INVHED.CusVenTel, T_INVHED.DATE_CREATED, T_INVHED.DATE_MODIFIED, T_INVHED.EstDat, T_INVHED.ExtrnalCostGaidID, T_INVHED.GadeId, T_INVHED.GadeNo, T_INVHED.GDat, T_INVHED.HDat, T_INVHED.IfDel, T_INVHED.IfPrint, T_INVHED.IfRet, T_INVHED.IfTrans, T_INVHED.InvAddCost, T_INVHED.InvAddCostExtrnal, T_INVHED.InvAddCostExtrnalLoc, T_INVHED.InvAddCostLoc, T_INVHED.InvCash, T_INVHED.InvCashPay, T_INVHED.InvCashPayNm, T_INVHED.InvCost, T_INVHED.InvCstNo, T_INVHED.InvDisPrs, ((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints, T_INVHED.InvDisValLocCur, T_INVHED.InvHed_ID, T_INVHED.InvId, T_INVHED.InvNet, T_INVHED.InvNetLocCur, T_INVHED.InvNo, T_INVHED.InvQty, T_INVHED.InvTot, T_INVHED.InvTotLocCur, T_INVHED.InvTyp, T_INVHED.InvWight_T, T_INVHED.IsExtrnalGaid, T_INVHED.LTim, T_INVHED.MndExtrnal, T_INVHED.MndNo, T_INVHED.MODIFIED_BY, T_INVHED.NetworkPay, T_INVHED.NetworkPayLocCur, T_INVHED.OrderTyp, T_INVHED.Puyaid, T_INVHED.RefNo, T_INVHED.Remark, T_INVHED.Remming, T_INVHED.RetId, T_INVHED.RetNo, T_INVHED.RoomNo, T_INVHED.RoomPerson, T_INVHED.RoomSts, T_INVHED.SalsManNam, T_INVHED.SalsManNo, T_INVHED.ServiceValue, T_INVHED.Sts, T_INVHED.ToStore, T_INVHED.ToStoreNm,case when T_INVHED.CusVenNo <> '' then (select " + ((LangArEn == 0) ? " T_AccDef.Arb_Des " : " T_AccDef.Eng_Des") + " from T_AccDef where T_AccDef.AccDef_No = T_INVHED.CusVenNo) else T_INVHED.CusVenNm end as CusVenNm from T_INVHED where InvTyp = " + VarGeneral.InvTyp + " and IfDel <> 1 and PaymentOrderTyp = 0 " + ((VarGeneral.InvTyp == 1) ? " and T_INVHED.InvId > 0 and T_INVHED.InvId != '' " : " ") + ((vSts == 1) ? (" and SalsManNo = '" + VarGeneral.UserNo + "'") : "  order by InvHed_ID") + ((!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 25)) ? " and InvCashPay = 0 " : " "), new object[0]).ToList();
                    }
                    for (int i = 0; i < LAccDef.Count; i++)
                    {
                        MetroTileItem vTable = new MetroTileItem();
                        vTable.Image = Resources.Customer;
                        vTable.ImageTextAlignment = ContentAlignment.MiddleCenter;
                        vTable.SymbolColor = Color.Empty;
                        vTable.TileColor = eMetroTileColor.Azure;
                        vTable.TileSize = new Size(160, 140);
                        vTable.TileStyle.CornerType = eCornerType.Diagonal;
                        vTable.TitleText = LAccDef[i].InvNo.ToString();
                        vTable.Tag = LAccDef[i].InvNo.ToString();
                        vTable.TitleTextAlignment = ContentAlignment.BottomCenter;
                        vTable.TitleTextFont = new Font("Tahoma", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
                        itemContainer_Customer.SubItems.AddRange(new BaseItem[1]
                        {
                            vTable
                        });
                    }

                }

                Refresh();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FillItems:", error, enable: true);
                itemContainer_Customer.SubItems.Clear();
                Refresh();
            }
        }
        private void FrmCustSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void FrmCustSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (vItemSelect == null)
                {
                    Serach_No = "";
                    Close();
                }
                else if (!string.IsNullOrEmpty(vItemSelect.TitleText) && !string.IsNullOrEmpty(vItemSelect.Tag.ToString()))
                {
                    Serach_No = vItemSelect.Tag.ToString();
                    Close();
                }
                else
                {
                    Serach_No = "";
                    Close();
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("ButOk_Click:", error, enable: true);
                MessageBox.Show((LangArEn == 0) ? "حدث خطأ ما .. يرجى تحديد العميل ثم المحاولة مرة آخرى" : "Error .. Please identify the Customer and then try again", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Serach_No = "";
                Close();
            }
        }
        private void metroTilePanel_Customer_ItemClick(object sender, EventArgs e)
        {
            try
            {
                MetroTileItem q = (vItemSelect = sender as MetroTileItem);
                if (q != null)
                {
                    TableInfo(q.Tag.ToString());
                    VisibleSts = false;
                }
                else
                {
                    TableInfo("");
                    VisibleSts = true;
                }
            }
            catch
            {
                vItemSelect = null;
                VisibleSts = true;
            }
        }
        private void txtSearchMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b')) && checkBox_ByMobile.Checked)
            {
                e.Handled = true;
            }
        }
        private void txtSearchMobile_ButtonCustomClick(object sender, EventArgs e)
        {
            FillItems();
            TableInfo("");
            VisibleSts = true;
        }
        private void txtSearchMobile_ButtonCustom2Click(object sender, EventArgs e)
        {
            txtSearchMobile.Text = "";
            FillItems();
            TableInfo("");
            VisibleSts = true;
        }
        private void txtSearchMobile_VisibleChanged(object sender, EventArgs e)
        {
            if (vTy_ == 0)
            {
                checkBox_ByMobile.Visible = txtSearchMobile.Visible;
                checkBox_ByName.Visible = txtSearchMobile.Visible;
            }
            else
            {
                checkBox_ByMobile.Visible = false;
                checkBox_ByName.Visible = false;
            }
        }
        private void checkBox_ByMobile_CheckedChanged(object sender, CheckBoxChangeEventArgs e)
        {
            labelItem_Mobile.Text = checkBox_ByMobile.Text + " :";
        }
        private void checkBox_ByName_CheckedChanged(object sender, CheckBoxChangeEventArgs e)
        {
            labelItem_Mobile.Text = checkBox_ByName.Text + " :";
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustSearch));
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_Det = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Rep = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.superTabControl_Tables = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.metroTilePanel_Customer = new DevComponents.DotNetBar.Metro.MetroTilePanel();
            this.itemContainer_Customer = new DevComponents.DotNetBar.ItemContainer();
            this.superTabItem_Customer = new DevComponents.DotNetBar.SuperTabItem();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem_Mobile = new DevComponents.DotNetBar.LabelItem();
            this.txtSearchMobile = new DevComponents.DotNetBar.TextBoxItem();
            this.checkBox_ByMobile = new DevComponents.DotNetBar.CheckBoxItem();
            this.checkBox_ByName = new DevComponents.DotNetBar.CheckBoxItem();
            this.expandablePanel_Table = new DevComponents.DotNetBar.ExpandablePanel();
            this.itemPanel1 = new DevComponents.DotNetBar.ItemPanel();
            this.labelItem_Tables = new DevComponents.DotNetBar.LabelItem();
            this.labelItem_Note = new DevComponents.DotNetBar.LabelItem();
            this.labelItem_Time = new DevComponents.DotNetBar.LabelItem();
            this.labelItem_Nadel = new DevComponents.DotNetBar.LabelItem();
            this.labelItem_Type = new DevComponents.DotNetBar.LabelItem();
            this.itemPanel2 = new DevComponents.DotNetBar.ItemPanel();
            this.labelItem_SumTable = new DevComponents.DotNetBar.LabelItem();
            this.panel_ButSave = new System.Windows.Forms.Panel();
            this.ButOk = new DevComponents.DotNetBar.ButtonX();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Tables)).BeginInit();
            this.superTabControl_Tables.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.expandablePanel_Table.SuspendLayout();
            this.panel_ButSave.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Det,
            this.ToolStripMenuItem_Rep});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip2.Size = new System.Drawing.Size(149, 48);
            this.contextMenuStrip2.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip2_Opening);
            // 
            // ToolStripMenuItem_Det
            // 
            this.ToolStripMenuItem_Det.Name = "ToolStripMenuItem_Det";
            this.ToolStripMenuItem_Det.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem_Det.Text = "إظهار التفاصيل";
            this.ToolStripMenuItem_Det.Click += new System.EventHandler(this.ToolStripMenuItem_Det_Click);
            // 
            // ToolStripMenuItem_Rep
            // 
            this.ToolStripMenuItem_Rep.Checked = true;
            this.ToolStripMenuItem_Rep.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToolStripMenuItem_Rep.Name = "ToolStripMenuItem_Rep";
            this.ToolStripMenuItem_Rep.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem_Rep.Text = "إظهار التقرير";
            this.ToolStripMenuItem_Rep.Click += new System.EventHandler(this.ToolStripMenuItem_Rep_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // superTabControl_Tables
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl_Tables.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl_Tables.ControlBox.MenuBox.Name = "";
            this.superTabControl_Tables.ControlBox.Name = "";
            this.superTabControl_Tables.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl_Tables.ControlBox.MenuBox,
            this.superTabControl_Tables.ControlBox.CloseBox});
            this.superTabControl_Tables.ControlBox.Visible = false;
            this.superTabControl_Tables.Controls.Add(this.superTabControlPanel1);
            this.superTabControl_Tables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl_Tables.Location = new System.Drawing.Point(0, 0);
            this.superTabControl_Tables.Name = "superTabControl_Tables";
            this.superTabControl_Tables.ReorderTabsEnabled = true;
            this.superTabControl_Tables.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_Tables.SelectedTabIndex = 0;
            this.superTabControl_Tables.Size = new System.Drawing.Size(754, 475);
            this.superTabControl_Tables.TabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_Tables.TabIndex = 2;
            this.superTabControl_Tables.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem_Customer,
            this.labelItem2,
            this.labelItem_Mobile,
            this.txtSearchMobile,
            this.checkBox_ByMobile,
            this.checkBox_ByName});
            this.superTabControl_Tables.TabVerticalSpacing = 22;
            this.superTabControl_Tables.SelectedTabChanged += new System.EventHandler<DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs>(this.superTabControl_Tables_SelectedTabChanged);
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.metroTilePanel_Customer);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 61);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(754, 414);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.superTabItem_Customer;
            this.superTabControlPanel1.Text = ".";
            this.superTabControlPanel1.Click += new System.EventHandler(this.superTabControlPanel1_Click);
            // 
            // metroTilePanel_Customer
            // 
            this.metroTilePanel_Customer.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.metroTilePanel_Customer.BackgroundStyle.Class = "RibbonFileMenuTwoColumnContainer";
            this.metroTilePanel_Customer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTilePanel_Customer.ContainerControlProcessDialogKey = true;
            this.metroTilePanel_Customer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTilePanel_Customer.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Right;
            this.metroTilePanel_Customer.ImageSize = DevComponents.DotNetBar.eBarImageSize.Medium;
            this.metroTilePanel_Customer.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer_Customer});
            this.metroTilePanel_Customer.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.metroTilePanel_Customer.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.metroTilePanel_Customer.Location = new System.Drawing.Point(0, 0);
            this.metroTilePanel_Customer.MultiLine = true;
            this.metroTilePanel_Customer.Name = "metroTilePanel_Customer";
            this.metroTilePanel_Customer.Size = new System.Drawing.Size(754, 414);
            this.metroTilePanel_Customer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.metroTilePanel_Customer.TabIndex = 1132;
            this.metroTilePanel_Customer.ItemClick += new System.EventHandler(this.metroTilePanel_Customer_ItemClick);
            // 
            // itemContainer_Customer
            // 
            this.itemContainer_Customer.AccessibleRole = System.Windows.Forms.AccessibleRole.ListItem;
            // 
            // 
            // 
            this.itemContainer_Customer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer_Customer.MultiLine = true;
            this.itemContainer_Customer.Name = "itemContainer_Customer";
            // 
            // 
            // 
            this.itemContainer_Customer.TitleStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.itemContainer_Customer.TitleStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemContainer_Customer.TitleStyle.BorderBottomWidth = 1;
            this.itemContainer_Customer.TitleStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.itemContainer_Customer.TitleStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemContainer_Customer.TitleStyle.BorderLeftWidth = 1;
            this.itemContainer_Customer.TitleStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemContainer_Customer.TitleStyle.BorderRightWidth = 1;
            this.itemContainer_Customer.TitleStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemContainer_Customer.TitleStyle.BorderTopWidth = 1;
            this.itemContainer_Customer.TitleStyle.Class = "MetroTileGroupTitle";
            this.itemContainer_Customer.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer_Customer.TitleStyle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.itemContainer_Customer.TitleStyle.MarginBottom = 5;
            this.itemContainer_Customer.TitleStyle.MarginLeft = 5;
            this.itemContainer_Customer.TitleStyle.MarginRight = 5;
            this.itemContainer_Customer.TitleStyle.MarginTop = 5;
            this.itemContainer_Customer.TitleStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.itemContainer_Customer.TitleStyle.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.itemContainer_Customer.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // superTabItem_Customer
            // 
            this.superTabItem_Customer.AttachedControl = this.superTabControlPanel1;
            this.superTabItem_Customer.GlobalItem = false;
            this.superTabItem_Customer.Name = "superTabItem_Customer";
            this.superTabItem_Customer.Text = "العمـــــــلاء";
            // 
            // labelItem2
            // 
            this.labelItem2.Name = "labelItem2";
            this.labelItem2.Text = "        بحث بـ";
            this.labelItem2.Click += new System.EventHandler(this.labelItem2_Click);
            // 
            // labelItem_Mobile
            // 
            this.labelItem_Mobile.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem_Mobile.Name = "labelItem_Mobile";
            this.labelItem_Mobile.Text = "جوال العميل :";
            this.labelItem_Mobile.Visible = false;
            this.labelItem_Mobile.Click += new System.EventHandler(this.labelItem_Mobile_Click);
            // 
            // txtSearchMobile
            // 
            this.txtSearchMobile.ButtonCustom.Text = "بحـــــث";
            this.txtSearchMobile.ButtonCustom.Visible = true;
            this.txtSearchMobile.ButtonCustom2.Text = "مســــح";
            this.txtSearchMobile.ButtonCustom2.Visible = true;
            this.txtSearchMobile.FocusHighlightEnabled = true;
            this.txtSearchMobile.Name = "txtSearchMobile";
            this.txtSearchMobile.Stretch = true;
            this.txtSearchMobile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearchMobile.TextBoxHeight = 45;
            this.txtSearchMobile.TextBoxWidth = 300;
            this.txtSearchMobile.Visible = false;
            this.txtSearchMobile.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.txtSearchMobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchMobile_KeyPress);
            this.txtSearchMobile.ButtonCustomClick += new System.EventHandler(this.txtSearchMobile_ButtonCustomClick);
            this.txtSearchMobile.ButtonCustom2Click += new System.EventHandler(this.txtSearchMobile_ButtonCustom2Click);
            this.txtSearchMobile.VisibleChanged += new System.EventHandler(this.txtSearchMobile_VisibleChanged);
            // 
            // checkBox_ByMobile
            // 
            this.checkBox_ByMobile.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBox_ByMobile.Checked = true;
            this.checkBox_ByMobile.CheckSignSize = new System.Drawing.Size(20, 20);
            this.checkBox_ByMobile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_ByMobile.Name = "checkBox_ByMobile";
            this.checkBox_ByMobile.Text = "جوال العميل";
            this.checkBox_ByMobile.Visible = false;
            this.checkBox_ByMobile.CheckedChanged += new DevComponents.DotNetBar.CheckBoxChangeEventHandler(this.checkBox_ByMobile_CheckedChanged);
            this.checkBox_ByMobile.Click += new System.EventHandler(this.checkBox_ByMobile_Click);
            // 
            // checkBox_ByName
            // 
            this.checkBox_ByName.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBox_ByName.CheckSignSize = new System.Drawing.Size(20, 20);
            this.checkBox_ByName.Name = "checkBox_ByName";
            this.checkBox_ByName.Text = "إسم العميل";
            this.checkBox_ByName.Visible = false;
            this.checkBox_ByName.CheckedChanged += new DevComponents.DotNetBar.CheckBoxChangeEventHandler(this.checkBox_ByName_CheckedChanged);
            this.checkBox_ByName.Click += new System.EventHandler(this.checkBox_ByName_Click);
            // 
            // expandablePanel_Table
            // 
            this.expandablePanel_Table.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel_Table.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.expandablePanel_Table.Controls.Add(this.itemPanel1);
            this.expandablePanel_Table.Controls.Add(this.itemPanel2);
            this.expandablePanel_Table.Controls.Add(this.panel_ButSave);
            this.expandablePanel_Table.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.expandablePanel_Table.ExpandButtonVisible = false;
            this.expandablePanel_Table.ExpandOnTitleClick = true;
            this.expandablePanel_Table.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.expandablePanel_Table.Location = new System.Drawing.Point(0, 348);
            this.expandablePanel_Table.Name = "expandablePanel_Table";
            this.expandablePanel_Table.Size = new System.Drawing.Size(754, 127);
            this.expandablePanel_Table.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_Table.Style.BackColor1.Color = System.Drawing.Color.AliceBlue;
            this.expandablePanel_Table.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            this.expandablePanel_Table.Style.BorderColor.Color = System.Drawing.Color.White;
            this.expandablePanel_Table.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_Table.Style.GradientAngle = 90;
            this.expandablePanel_Table.TabIndex = 976;
            this.expandablePanel_Table.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_Table.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel_Table.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel_Table.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel_Table.TitleStyle.ForeColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.expandablePanel_Table.TitleStyle.GradientAngle = 90;
            this.expandablePanel_Table.TitleText = "شريط المعلومات";
            this.expandablePanel_Table.Click += new System.EventHandler(this.expandablePanel_Table_Click);
            // 
            // itemPanel1
            // 
            // 
            // 
            // 
            this.itemPanel1.BackgroundStyle.Class = "ItemPanel";
            this.itemPanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel1.ContainerControlProcessDialogKey = true;
            this.itemPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPanel1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.itemPanel1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem_Tables,
            this.labelItem_Note,
            this.labelItem_Time,
            this.labelItem_Nadel,
            this.labelItem_Type});
            this.itemPanel1.ItemSpacing = 4;
            this.itemPanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel1.Location = new System.Drawing.Point(373, 26);
            this.itemPanel1.Name = "itemPanel1";
            this.itemPanel1.Size = new System.Drawing.Size(381, 101);
            this.itemPanel1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.itemPanel1.TabIndex = 1;
            this.itemPanel1.Text = "itemPanel1";
            this.itemPanel1.ItemClick += new System.EventHandler(this.itemPanel1_ItemClick);
            // 
            // labelItem_Tables
            // 
            this.labelItem_Tables.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem_Tables.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelItem_Tables.Name = "labelItem_Tables";
            this.labelItem_Tables.Text = "labelItem1";
            this.labelItem_Tables.Click += new System.EventHandler(this.labelItem_Tables_Click);
            //            this.itemPanel1.ItemClick += new System.EventHandler(this.itemPanel1_ItemClick);

            // 
            // labelItem_Note
            // 
            this.labelItem_Note.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem_Note.ForeColor = System.Drawing.Color.Gray;
            this.labelItem_Note.Name = "labelItem_Note";
            this.labelItem_Note.Text = "labelItem2";
            this.labelItem_Note.Click += new System.EventHandler(this.labelItem_Note_Click);
            // 
            // labelItem_Time
            // 
            this.labelItem_Time.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem_Time.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelItem_Time.Name = "labelItem_Time";
            this.labelItem_Time.Text = "labelItem6";
            this.labelItem_Time.Click += new System.EventHandler(this.labelItem_Time_Click);
            // 
            // labelItem_Nadel
            // 
            this.labelItem_Nadel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem_Nadel.ForeColor = System.Drawing.Color.Maroon;
            this.labelItem_Nadel.Name = "labelItem_Nadel";
            this.labelItem_Nadel.Text = "labelItem7";
            this.labelItem_Nadel.Click += new System.EventHandler(this.labelItem_Nadel_Click);
            // 
            // labelItem_Type
            // 
            this.labelItem_Type.BackColor = System.Drawing.Color.Yellow;
            this.labelItem_Type.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem_Type.Name = "labelItem_Type";
            this.labelItem_Type.Text = "labelItem1";
            this.labelItem_Type.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelItem_Type.Click += new System.EventHandler(this.labelItem_Type_Click);
            //  this.labelItem_Nadel.Click += new System.EventHandler(this.labelItem_Nadel_Click);
            // 
            // itemPanel2
            // 
            // 
            // 
            // 
            this.itemPanel2.BackgroundStyle.Class = "ItemPanel";
            this.itemPanel2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel2.ContainerControlProcessDialogKey = true;
            this.itemPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.itemPanel2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.itemPanel2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem_SumTable});
            this.itemPanel2.ItemSpacing = 4;
            this.itemPanel2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel2.Location = new System.Drawing.Point(133, 26);
            this.itemPanel2.Name = "itemPanel2";
            this.itemPanel2.Size = new System.Drawing.Size(240, 101);
            this.itemPanel2.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.itemPanel2.TabIndex = 2;
            this.itemPanel2.Text = "itemPanel2";
            // 
            // labelItem_SumTable
            // 
            this.labelItem_SumTable.BackColor = System.Drawing.Color.Red;
            this.labelItem_SumTable.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem_SumTable.ForeColor = System.Drawing.Color.White;
            this.labelItem_SumTable.Name = "labelItem_SumTable";
            this.labelItem_SumTable.Text = "labelItem1";
            this.labelItem_SumTable.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // panel_ButSave
            // 
            this.panel_ButSave.BackColor = System.Drawing.Color.Transparent;
            this.panel_ButSave.Controls.Add(this.ButOk);
            this.panel_ButSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_ButSave.Location = new System.Drawing.Point(0, 26);
            this.panel_ButSave.Name = "panel_ButSave";
            this.panel_ButSave.Size = new System.Drawing.Size(133, 101);
            this.panel_ButSave.TabIndex = 5;
            // 
            // ButOk
            // 
            this.ButOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButOk.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.ButOk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButOk.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButOk.Location = new System.Drawing.Point(0, 0);
            this.ButOk.Name = "ButOk";
            this.ButOk.Size = new System.Drawing.Size(133, 101);
            this.ButOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButOk.Symbol = "";
            this.ButOk.SymbolSize = 16F;
            this.ButOk.TabIndex = 6784;
            this.ButOk.Text = "اختيــــــــار";
            this.ButOk.TextColor = System.Drawing.Color.White;
            this.labelItem_Type.Click += new System.EventHandler(this.labelItem_Type_Click);
            this.labelItem_Nadel.Click += new System.EventHandler(this.labelItem_Nadel_Click);
            this.itemPanel2.ItemClick += new System.EventHandler(this.itemPanel2_ItemClick);

            this.labelItem_SumTable.Click += new System.EventHandler(this.labelItem_SumTable_Click);

            this.panel_ButSave.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_ButSave_Paint);

            this.ButOk.Click += new System.EventHandler(this.ButOk_Click);
            // 
            // FrmCustSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(754, 475);
            this.Controls.Add(this.expandablePanel_Table);
            this.Controls.Add(this.superTabControl_Tables);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.KeyPreview = true;
            this.Name = "FrmCustSearch";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCustSearch_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCustSearch_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmCustSearch_KeyPress);
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Tables)).EndInit();
            this.superTabControl_Tables.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.expandablePanel_Table.ResumeLayout(false);
            this.panel_ButSave.ResumeLayout(false);
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.ResumeLayout(false);

        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void ToolStripMenuItem_Det_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem_Rep_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void superTabControl_Tables_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        {

        }

        private void superTabControlPanel1_Click(object sender, EventArgs e)
        {

        }

        private void labelItem2_Click(object sender, EventArgs e)
        {

        }

        private void labelItem_Mobile_Click(object sender, EventArgs e)
        {

        }

        private void checkBox_ByMobile_Click(object sender, EventArgs e)
        {

        }

        private void checkBox_ByName_Click(object sender, EventArgs e)
        {

        }

        private void expandablePanel_Table_Click(object sender, EventArgs e)
        {

        }

        private void itemPanel1_ItemClick(object sender, EventArgs e)
        {

        }

        private void labelItem_Tables_Click(object sender, EventArgs e)
        {

        }

        private void labelItem_Note_Click(object sender, EventArgs e)
        {

        }

        private void labelItem_Time_Click(object sender, EventArgs e)
        {

        }

        private void labelItem_Nadel_Click(object sender, EventArgs e)
        {

        }

        private void labelItem_Type_Click(object sender, EventArgs e)
        {

        }

        private void itemPanel2_ItemClick(object sender, EventArgs e)
        {

        }

        private void labelItem_SumTable_Click(object sender, EventArgs e)
        {

        }

        private void panel_ButSave_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
