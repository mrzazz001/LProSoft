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
    public partial  class FrmCustSearch : Form
    { void avs(int arln)

{ 
 ToolStripMenuItem_Det.Text=   (arln == 0 ? "  إظهار التفاصيل  " : "  Show details") ; ToolStripMenuItem_Rep.Text=   (arln == 0 ? "  إظهار التقرير  " : "  Show report") ; superTabControlPanel1.Text=   (arln == 0 ? "  .  " : "  .") ; superTabItem_Customer.Text=   (arln == 0 ? "  العمـــــــلاء  " : "  customer") ; labelItem2.Text=   (arln == 0 ? "          بحث بـ  " : "          search by") ; labelItem_Mobile.Text=   (arln == 0 ? "  جوال العميل :  " : "  Customer mobile:") ; txtSearchMobile.Text=   (arln == 0 ? "  بحـــــث  " : "  search") ; txtSearchMobile.Text=   (arln == 0 ? "  مســــح  " : "  clear") ; checkBox_ByMobile.Text=   (arln == 0 ? "  جوال العميل  " : "  Customer mobile") ; checkBox_ByName.Text=   (arln == 0 ? "  إسم العميل  " : "  customer name") ; itemPanel1.Text=   (arln == 0 ? "  itemPanel1  " : "  itemPanel1") ; labelItem_Tables.Text=   (arln == 0 ? "  labelItem1  " : "  labelItem1") ; labelItem_Note.Text=   (arln == 0 ? "  labelItem2  " : "  labelItem2") ; labelItem_Time.Text=   (arln == 0 ? "  labelItem6  " : "  labelItem6") ; labelItem_Nadel.Text=   (arln == 0 ? "  labelItem7  " : "  labelItem7") ; labelItem_Type.Text=   (arln == 0 ? "  labelItem1  " : "  labelItem1") ; itemPanel2.Text=   (arln == 0 ? "  itemPanel2  " : "  itemPanel2") ; labelItem_SumTable.Text=   (arln == 0 ? "  labelItem1  " : "  labelItem1") ; ButOk.Text=   (arln == 0 ? "  اختيــــــــار  " : "  choose") ;}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
        }
   
        public int vTy_ = 0;
        public string Serach_No = "";
        public string sts_ = "";
#pragma warning disable CS0414 // The field 'FrmCustSearch.vNo' is assigned but its value is never used
        private string vNo = "";
#pragma warning restore CS0414 // The field 'FrmCustSearch.vNo' is assigned but its value is never used
#pragma warning disable CS0414 // The field 'FrmCustSearch.vTyp' is assigned but its value is never used
        private int vTyp = 0;
#pragma warning restore CS0414 // The field 'FrmCustSearch.vTyp' is assigned but its value is never used
        private bool frmSts_ = false;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private int LangArEn = 0;
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRt;
        private MetroTileItem vItemSelect = new MetroTileItem();
       // private IContainer components = null;
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
            InitializeComponent();this.Load += langloads;
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
#pragma warning disable CS0162 // Unreachable code detected
                        int vSts = dbc.StockUser(VarGeneral.UserNo).UserPointTyp.Value;
#pragma warning restore CS0162 // Unreachable code detected
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
