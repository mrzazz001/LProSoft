using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using Library.RepShow;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmPointsCalc : Form
    { void avs(int arln)

{ 
}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
        public class ColumnDictinary
        {
            public string AText = string.Empty;
            public string EText = string.Empty;
            public bool IfDefault = false;
            public string Format = string.Empty;
            public ColumnDictinary(string aText, string eText, bool ifDefault, string format)
            {
                AText = aText;
                EText = eText;
                IfDefault = ifDefault;
                Format = format;
            }
        }
       // private IContainer components = null;
        private GroupPanel groupPanel1;
        internal Label Label1;
        private DoubleInput txtTotalPurchaes;
        internal Label label2;
        internal Label label3;
        private GroupPanel groupPanel4;
        internal Label labelCurr;
        internal Label label12;
        private DoubleInput txtPointOfRyal;
        private ButtonX ButExit;
        private ButtonX ButOk;
        private GroupPanel groupPanel5;
        private IntegerInput integerInput1;
        internal TextBox txtItem3;
        private IntegerInput integerInput3;
        internal TextBox txtItem2;
        private IntegerInput integerInput2;
        internal TextBox txtItem1;
        internal TextBox txtItem4;
        private IntegerInput integerInput4;
        internal TextBox textBox2;
        internal TextBox textBox5;
        internal TextBox textBox4;
        internal TextBox textBox3;
        private IntegerInput integerInput5;
        private IntegerInput integerInput6;
        private IntegerInput integerInput7;
        private IntegerInput integerInput8;
        internal TextBox txtItem4E;
        internal TextBox txtItem3E;
        internal TextBox txtItem2E;
        internal TextBox txtItem1E;
        internal TextBox textBox1;
        internal TextBox textBox6;
        internal TextBox textBox7;
        internal TextBox textBox8;
        private Label label4;
        private ButtonX button_SrchItemGroup;
        private TextBox txtClassName;
        private TextBox txtClassNo;
        private ButtonX button_UpdatePoint;
        private DoubleInput txtTotalPoint;
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
                ButOk.Enabled = !value;
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
        public FrmPointsCalc()
        {
            InitializeComponent();this.Load += langloads;
            txtPointOfRyal.Click += Button_Edit_Click;
            txtItem1.Click += Button_Edit_Click;
            txtItem2.Click += Button_Edit_Click;
            txtItem1E.Click += Button_Edit_Click;
            txtItem2E.Click += Button_Edit_Click;
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                ButOk.Text = "حفظ";
                ButOk.Tooltip = "F2";
                ButExit.Text = "خروج";
                ButExit.Tooltip = "Esc";
                groupPanel1.Text = "تعميم اعدادات النقاط حسب التصنيف";
                button_UpdatePoint.Text = "تحــــديث";
                try
                {
                    labelCurr.Text = db.StockCurencyID(int.Parse(VarGeneral.Settings_Sys.ImportIp)).Arb_Des;
                }
                catch
                {
                }
                Text = "إعدادات نقاط العملاء";
            }
            else
            {
                ButOk.Text = "Save";
                ButExit.Text = "Exit";
                ButOk.Tooltip = "F2";
                ButExit.Tooltip = "Esc";
                groupPanel1.Text = "Circulation of points by classification";
                button_UpdatePoint.Text = "Update";
                try
                {
                    labelCurr.Text = db.StockCurencyID(int.Parse(VarGeneral.Settings_Sys.ImportIp)).Eng_Des;
                }
                catch
                {
                }
                Text = "Points OF Customers Setting";
            }
        }
        private void Frm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 && ButOk.Enabled && ButOk.Visible)
            {
                ButOk_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void FrmPointsCalc_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmPointsCalc));
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
                RibunButtons();
                listInvSetting = db.StockInvSettingList(VarGeneral.UserID);
                _InvSetting = listInvSetting[0];
                _SysSetting = db.SystemSettingStock();
                listCompany = db.StockCompanyList();
                _Company = listCompany[0];
                _GdAuto = db.GdAutoStock();
                listInfotb = db.StockInfoList();
                _Infotb = listInfotb[0];
                try
                {
                    BindData();
                }
                catch
                {
                }
                ChkPointsUse();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void ChkPointsUse()
        {
            try
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_INVHED Left Join  T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  Left Join T_Curency On T_INVHED.CurTyp = T_Curency.Curency_ID Left Join T_CstTbl On T_INVHED.InvCstNo = T_CstTbl.Cst_ID Left Join T_Mndob on T_INVHED.MndNo = T_Mndob.Mnd_Id Left Join T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                string Fields = string.Empty;
                Fields = ((LangArEn != 0) ? " T_INVHED.InvNo" : " T_INVHED.InvNo");
                _RepShow.Rule = " Where ( T_INVHED.InvTyp = 1  ) and  T_INVHED.IfDel != 1 and T_INVHED.IsPoints = 1 and DesPointsValue > 0 and PointsCount > 0 ";
                _RepShow.Fields = Fields;
                try
                {
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.Message);
                }
                if (VarGeneral.RepData.Tables[0].Rows.Count > 0)
                {
                    txtPointOfRyal.IsInputReadOnly = true;
                }
                else
                {
                    txtTotalPurchaes.IsInputReadOnly = false;
                }
            }
            catch (Exception)
            {
            }
        }
        private void BindData()
        {
            try
            {
                State = FormState.Saved;
                ButOk.Enabled = false;
                txtPointOfRyal.Value = _SysSetting.PointOfRyal.Value;
                txtItem1.Text = _SysSetting.ItemTyp1;
                txtItem2.Text = _SysSetting.ItemTyp2;
                txtItem3.Text = _SysSetting.ItemTyp3;
                txtItem1E.Text = _SysSetting.ItemTyp1E;
                txtItem2E.Text = _SysSetting.ItemTyp2E;
                txtItem3E.Text = _SysSetting.ItemTyp3E;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SaveData()
        {
            try
            {
                db.ExecuteCommand("update T_SYSSETTING set PointOfRyal = " + txtPointOfRyal.Value);
                db.ExecuteCommand("update T_SYSSETTING set ItemTyp1 = '" + txtItem1.Text + "'");
                db.ExecuteCommand("update T_SYSSETTING set ItemTyp2 = '" + txtItem2.Text + "'");
                db.ExecuteCommand("update T_SYSSETTING set ItemTyp3 = '" + txtItem3.Text + "'");
                db.ExecuteCommand("update T_SYSSETTING set ItemTyp1E = '" + txtItem1E.Text + "'");
                db.ExecuteCommand("update T_SYSSETTING set ItemTyp2E = '" + txtItem2E.Text + "'");
                db.ExecuteCommand("update T_SYSSETTING set ItemTyp3E = '" + txtItem3E.Text + "'");
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
        private void ButOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtItem1.Text) || string.IsNullOrEmpty(txtItem1E.Text) || string.IsNullOrEmpty(txtItem2.Text) || string.IsNullOrEmpty(txtItem2E.Text))
            {
                MessageBox.Show((LangArEn == 0) ? "يجب التأكد من صحة أنواع الأصناف" : "Validation of varieties of varieties", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            SaveData();
            State = FormState.Saved;
            SetReadOnly = true;
        }
        private void ButExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void txtItem1_Click(object sender, EventArgs e)
        {
            txtItem1.SelectAll();
        }
        private void txtItem2_Click(object sender, EventArgs e)
        {
            txtItem2.SelectAll();
        }
        private void txtItem1E_Click(object sender, EventArgs e)
        {
            txtItem1E.SelectAll();
        }
        private void txtItem2E_Click(object sender, EventArgs e)
        {
            txtItem2E.SelectAll();
        }
        private void button_SrchItemGroup_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("CAT_No", new ColumnDictinary("الرمـــز", "CATEGORY No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_CATEGORY";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                txtClassNo.Text = db.StockCat(frm.Serach_No).CAT_ID.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    txtClassName.Text = db.StockCat(frm.Serach_No).Arb_Des;
                }
                else
                {
                    txtClassName.Text = db.StockCat(frm.Serach_No).Eng_Des;
                }
                ChkPointsUseGroup();
            }
            else
            {
                txtClassNo.Text = string.Empty;
                txtClassName.Text = string.Empty;
            }
        }
        private void ChkPointsUseGroup()
        {
            try
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = "T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                string Fields = " T_INVHED.CusVenNo,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Arb_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNm,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Eng_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNmE, InvDet_ID,T_Items.Itm_No,T_Items.Arb_Des as itemNm,T_Category.Arb_Des as CategoyNm,T_InvDet.StoreNo,T_InvDet.ItmUnt as UnitNm,(Round(T_InvDet.Price," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Price,T_InvDet.ItmDis,Abs(T_INVDET.Qty) as Qty,Abs(T_INVDET.RealQty) as RealQty,(Round(T_InvDet.Amount," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Amount,(Round(T_InvDet.Cost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Cost,T_INVHED.InvNo, T_INVSETTING.InvNamA as InvTypNm,T_INVHED.InvCash,T_Curency.Arb_Des as CurrnceyNm,T_INVHED.GadeNo, T_Mndob.Arb_Des as MndNm,T_INVHED.RetNo,T_SYSSETTING.LogImg";
                _RepShow.Rule = " Where T_CATEGORY.CAT_ID = " + txtClassNo.Text + " and T_Items.IsPoints = 1 and T_CATEGORY.TotalPurchaes > 0 and T_CATEGORY.TotalPoint > 0 and ( T_INVHED.InvTyp = 1 or T_INVHED.InvTyp = 3 ) and  T_INVHED.IfDel != 1 and T_INVHED.IsPoints = 1 and DesPointsValue > 0 and PointsCount > 0  order by T_INVHED.InvTyp, T_INVHED.InvHed_ID";
                _RepShow.Fields = Fields;
                try
                {
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.Message);
                }
                if (VarGeneral.RepData.Tables[0].Rows.Count > 0)
                {
                    txtTotalPurchaes.IsInputReadOnly = true;
                    txtTotalPoint.IsInputReadOnly = true;
                }
                else
                {
                    txtTotalPurchaes.IsInputReadOnly = false;
                    txtTotalPoint.IsInputReadOnly = false;
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }
        private void button_UpdatePoint_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtTotalPurchaes.IsInputReadOnly && !txtTotalPoint.IsInputReadOnly && MessageBox.Show("سيتم تحديث اعدادات نقاط الاصناف التابعة للتصنيف .. هل حقا تريد المتابعة ؟ \n The ratings of the labels will be updated. Do you really want to continue ?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    db.ExecuteCommand("UPDATE [T_CATEGORY] SET [TotalPurchaes] = " + txtTotalPurchaes.Value + " ,[TotalPoint] = " + txtTotalPoint.Value + ((!string.IsNullOrEmpty(txtClassNo.Text)) ? (" Where CAT_No = '" + txtClassNo.Text + "'") : " "));
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_UpdatePoint_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
    }
}
