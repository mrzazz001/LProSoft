using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using Framework.UI;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Library.RepShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmRepairPurchaes : Form
    { void avs(int arln)

{ 
 label5.Text=   (arln == 0 ? "  مـن الصنف :  " : "  of category:") ; label6.Text=   (arln == 0 ? "  إلـــى صنف :  " : "  to class:") ; ButOk.Text=   (arln == 0 ? "  عــرض  " : "  show") ; ButExit.Text=   (arln == 0 ? "  خـــروج  " : "  Close") ; Butupdate.Text=   (arln == 0 ? "  تحديث الأسعار  " : "  Prices update") ; button_DetData.Text=   (arln == 0 ? "  مسح كامل   " : "  full scan") ; groupBox_No.Text=   (arln == 0 ? "  حسب رقم الفاتورة  " : "  According to the invoice number") ; label1.Text=   (arln == 0 ? "  من :  " : "  From :") ; label2.Text=   (arln == 0 ? "  إلى :  " : "  to me :") ; Text = "معالج تحديث أسعــار التكلفــــة";this.Text=   (arln == 0 ? "  معالج تحديث أسعــار التكلفــــة  " : "  Cost price update wizard") ;}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
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
       // private IContainer components = null;
        private void netResize1_AfterControlResize(object sender, Softgroup.NetResize.AfterControlResizeEventArgs e)
        {
            if (e.Control.GetType() == typeof(Label))
            {
                Label c = (e.Control as Label); if ((c.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))))) && (c.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))))) && (c.BackColor != System.Drawing.Color.SteelBlue))
                    c.BackColor = Color.Transparent; Size cc = c.PreferredSize;
                c.AutoSize = false;
                c.Size = cc;
                //  e.Control.Font= new System.Drawing.Font("Tahoma",(float) (c-0.5));
            }
        }
        private void FrmInvSale_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;
        }
        private void FrmInvSale_SizeChanged(object sender, EventArgs e)
        {
            netResize1.Refresh();
        }
        public Softgroup.NetResize.NetResize netResize1;
        private C1FlexGrid FlxInv;
        private Label label5;
        private TextBox txtFItemName;
        private TextBox txtFItemNo;
        private ButtonX button_SrchItemFrom;
        private TextBox txtInItemName;
        private TextBox txtInItemNo;
        private Label label6;
        private ButtonX button_SrchItemTo;
        private ButtonX ButOk;
        private ButtonX ButExit;
        private ButtonX Butupdate;
        private ButtonX button_DetData;
        private GroupBox groupBox_No;
        private MaskedTextBox txtMIntoNo;
        private Label label1;
        private Label label2;
        private MaskedTextBox txtMFromNo;
        private int LangArEn = 0;
        private T_User _User = new T_User();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private SplitContainer splitContainer1;
        private T_User permission = new T_User();
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
                if (dbInstanceRate == null)
                {
                    dbInstanceRate = new Rate_DataDataContext(VarGeneral.BranchRt);
                }
                return dbInstanceRate;
            }
        }
        public FrmRepairPurchaes()
        {
            InitializeComponent();this.Load += langloads;
        }
        private void ButExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button_SrchItemFrom_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("Itm_No", new ColumnDictinary("رقم الصنف", "Item No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, ""));
            columns_Names_visible.Add("StartCost", new ColumnDictinary("التكلفةالافتتاحية", "Start Cost", ifDefault: false, ""));
            columns_Names_visible.Add("AvrageCost", new ColumnDictinary("متوسط التكلفة", "Average Cost", ifDefault: false, ""));
            columns_Names_visible.Add("LastCost", new ColumnDictinary("آخر تكلفة", "Last Cost", ifDefault: false, ""));
            columns_Names_visible.Add("Arb_Des_Cat", new ColumnDictinary("الاسم العربي لمجموعة الصنف", "CATEGORY Arabic Name", ifDefault: false, ""));
            columns_Names_visible.Add("Eng_Des_Cat", new ColumnDictinary("الاسم الانجليزي لمجموعة الصنف", "CATEGORY English Name", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_Items";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtFItemNo.Text = frm.Serach_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtFItemName.Text = db.StockItem(frm.Serach_No).Arb_Des.ToString();
                }
                else
                {
                    txtFItemName.Text = db.StockItem(frm.Serach_No).Eng_Des.ToString();
                }
            }
            else
            {
                txtFItemNo.Text = "";
                txtFItemName.Text = "";
            }
        }
        private void button_SrchItemTo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("Itm_No", new ColumnDictinary("رقم الصنف", "Item No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, ""));
            columns_Names_visible.Add("StartCost", new ColumnDictinary("التكلفةالافتتاحية", "Start Cost", ifDefault: false, ""));
            columns_Names_visible.Add("AvrageCost", new ColumnDictinary("متوسط التكلفة", "Average Cost", ifDefault: false, ""));
            columns_Names_visible.Add("LastCost", new ColumnDictinary("آخر تكلفة", "Last Cost", ifDefault: false, ""));
            columns_Names_visible.Add("Arb_Des_Cat", new ColumnDictinary("الاسم العربي لمجموعة الصنف", "CATEGORY Arabic Name", ifDefault: false, ""));
            columns_Names_visible.Add("Eng_Des_Cat", new ColumnDictinary("الاسم الانجليزي لمجموعة الصنف", "CATEGORY English Name", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_Items";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtInItemNo.Text = frm.Serach_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtInItemName.Text = db.StockItem(frm.Serach_No).Arb_Des.ToString();
                }
                else
                {
                    txtInItemName.Text = db.StockItem(frm.Serach_No).Eng_Des.ToString();
                }
            }
            else
            {
                txtInItemNo.Text = "";
                txtInItemName.Text = "";
            }
        }
        private void txtMFromNo_Click(object sender, EventArgs e)
        {
            txtMFromNo.SelectAll();
        }
        private void txtMIntoNo_Click(object sender, EventArgs e)
        {
            txtMIntoNo.SelectAll();
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            FlxInv.Rows.Count = 1;
            string Rule = "";
            if (!string.IsNullOrEmpty(txtFItemNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtFItemNo.Tag, " >= '", txtFItemNo.Text.Trim(), "'");
            }
            if (!string.IsNullOrEmpty(txtInItemNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtInItemNo.Tag, " <= '", txtInItemNo.Text.Trim(), "'");
            }
            if (!string.IsNullOrEmpty(txtMFromNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtMFromNo.Tag, " >= ", txtMFromNo.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtMIntoNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtMIntoNo.Tag, " <= ", txtMIntoNo.Text.Trim());
            }
            List<T_INVDET_Repair> listDet = db.ExecuteQuery<T_INVDET_Repair>("select * from T_INVDET_Repair Where 1 = 1 " + Rule, new object[0]).ToList();
            if (listDet.Count <= 0)
            {
                return;
            }
            FlxInv.Rows.Count = listDet.Count + 1;
            T_INVDET_Repair _InvDet;
            for (int iiCnt = 1; iiCnt <= listDet.Count; iiCnt++)
            {
                _InvDet = listDet[iiCnt - 1];
                double _AvrageCost = 0.0;
                FlxInv.SetData(iiCnt, 0, _InvDet.InvDet_ID_Repair);
                FlxInv.SetData(iiCnt, 1, _InvDet.ItmNo_Repair.Trim());
                FlxInv.SetData(iiCnt, 2, (LangArEn == 0) ? _InvDet.ItmDes_Repair.ToString() : _InvDet.ItmDesE_Repair.ToString());
                FlxInv.SetData(iiCnt, 3, _InvDet.InvNo_Repair.ToString());
                FlxInv.SetData(iiCnt, 4, _InvDet.ItmWight_Repair);
                FlxInv.SetData(iiCnt, 5, _InvDet.ItmWight_T_Repair);
                FlxInv.SetData(iiCnt, 6, db.StockItem(_InvDet.ItmNo_Repair.Trim()).AvrageCost.Value);
                FlxInv.SetData(iiCnt, 7, _InvDet.Qty_Repair);
                FlxInv.SetData(iiCnt, 8, _InvDet.Price_Repair.Value);
                try
                {
                    FlxInv.SetData(iiCnt, 13, db.StockInvHeadID(_InvDet.TypeRepair.Value, _InvDet.InvDet_ID).CurTyp.Value);
                }
                catch
                {
                    FlxInv.SetData(iiCnt, 13, 1);
                }
                double QtyT = 0.0;
                try
                {
                    RepShow _RepShow = new RepShow();
                    _RepShow.Tables = "T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                    string Fields = " MAX(T_Items.Itm_No ) as Itm_No , MAX(T_Items.Arb_Des ) as itemNm   , MAX( T_Category.Arb_Des ) as [CategoyNm] ,  SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) AS [Credit] ,  SUM (CASE WHEN T_InvDet.RealQty < 0 THEN ABS(T_InvDet.RealQty)  Else 0 END ) AS [Debit],MAX (T_SYSSETTING.LogImg) as LogImg ";
                    _RepShow.Rule = " Where 1 = 1 and  T_INVHED.InvTyp != 21 and T_INVHED.InvTyp != 7 and T_INVHED.InvTyp != 8 and T_INVHED.InvTyp != 9 and T_INVHED.IfDel != 1 and  T_INVHED.IfRet != 1 and (T_INVHED.PaymentOrderTyp = 0 or ( T_INVHED.InvTyp = 17 or T_INVHED.InvTyp = 20)) and  T_Items.Itm_No ='" + _InvDet.ItmNo_Repair.Trim() + "' group by T_Items.Itm_No  Order by Itm_No ";
                    _RepShow.Fields = Fields;
                    try
                    {
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                    }
                    catch (Exception)
                    {
                        QtyT = 0.0;
                    }
                    if (VarGeneral.RepData.Tables[0].Rows.Count > 0)
                    {
                        QtyT = double.Parse(VarGeneral.RepData.Tables[0].Rows[0]["Credit"].ToString());
                    }
                    if (QtyT <= 0.0)
                    {
                        QtyT = 0.0;
                    }
                }
                catch
                {
                    QtyT = 0.0;
                }
                double CostT = 0.0;
                try
                {
                    List<T_INVDET> vTot = (from t in db.T_INVDETs
                                           where t.ItmNo == _InvDet.ItmNo_Repair.Trim()
                                           where t.T_INVHED.InvTyp == (int?)2 || t.T_INVHED.InvTyp == (int?)14
                                           where t.T_INVHED.IfDel == (int?)0
                                           select t).ToList();
                    if (vTot.Count > 0)
                    {
                        CostT = vTot.Sum((T_INVDET g) => g.Amount.Value);
                    }
                }
                catch
                {
                    CostT = 0.0;
                }
                if (QtyT > 0.0)
                {
                    try
                    {
                        _AvrageCost = ((!(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 6)))) <= 0.0)) ? (CostT / QtyT) : (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * _InvDet.RealQty_Repair.Value));
                    }
                    catch
                    {
                        _AvrageCost = CostT / QtyT;
                    }
                }
                try
                {
                    if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 45))
                    {
                        _AvrageCost *= db.StockCurencyID(int.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 13))))).Rate.Value;
                    }
                }
                catch
                {
                }
                FlxInv.SetData(iiCnt, 9, _AvrageCost);
                FlxInv.SetData(iiCnt, 10, _AvrageCost);
                FlxInv.SetData(iiCnt, 11, _InvDet.InvDet_ID);
                FlxInv.SetData(iiCnt, 12, _InvDet.ItmUntPak_Repair.Value);
            }
        }
        private void FrmRepairPurchaes_Load(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmRepairPurchaes));
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
            if (VarGeneral.UserID == 1)
            {
                button_DetData.Visible = true;
            }
            else
            {
                button_DetData.Visible = false;
            }
            permission = dbc.Get_PermissionID(VarGeneral.UserID);
            FlxInv.Cols[9].AllowEditing = VarGeneral.TString.ChkStatShow(permission.SetStr, 46);
            RibunButtons();
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ButOk.Text = "عــرض";
                Butupdate.Text = "تحديث الأسعار";
                ButExit.Text = "خـــروج";
                Text = "معالج تحديث أسعــار التكلفــــة";
                return;
            }
            ButOk.Text = "Show";
            Butupdate.Text = "Update Prices";
            ButExit.Text = "Close";
            button_DetData.Text = "Delete All Data";
            Text = "Update Prices Cost Process";
            FlxInv.Cols[1].Caption = "Item No";
            FlxInv.Cols[2].Caption = "Item Name";
            FlxInv.Cols[3].Caption = "Inv No";
            FlxInv.Cols[4].Caption = "Qty / Bef";
            FlxInv.Cols[5].Caption = "Price / Bef";
            FlxInv.Cols[6].Caption = "Average / Bef";
            FlxInv.Cols[7].Caption = "Qty / After";
            FlxInv.Cols[8].Caption = "Price / After";
            FlxInv.Cols[9].Caption = "New Cost";
            FlxInv.Cols[14].Caption = "Exception";
        }
        private void FrmRepairPurchaes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && ButOk.Enabled && ButOk.Visible)
            {
                ButOk_Click(sender, e);
            }
            if (e.KeyCode == Keys.F5 && Butupdate.Enabled && Butupdate.Visible)
            {
                Butupdate_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void Butupdate_Click(object sender, EventArgs e)
        {
            if (FlxInv.Rows.Count <= 1 || MessageBox.Show("سيتم تحديث اسعار التكلفة للاصناف المحددة  \n هل تريد الأستمرار ? ", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                return;
            }
            for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
            {
                try
                {
                    if (FlxInv.GetData(iiCnt, 1) != null && !Convert.ToBoolean(FlxInv.GetData(iiCnt, 14)) && double.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 9).ToString())) >= 0.0)
                    {
                        db.ExecuteCommand("update T_Items set AvrageCost = " + double.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 9).ToString())) + " ,LastCost= " + double.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 10).ToString())) + " where Itm_No = '" + VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 1).ToString()) + "'");
                        db.ExecuteCommand("delete from T_INVDET_Repair where InvDet_ID_Repair = " + FlxInv.GetData(iiCnt, 0));
                        SaveUserEditor(iiCnt);
                    }
                }
                catch
                {
                }
            }
            MessageBox.Show((LangArEn == 0) ? "تم عملية التعديل بنجاح" : "Operation accomplished successfully", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            FlxInv.Rows.Count = 1;
            txtFItemNo.Text = "";
            txtFItemName.Text = "";
            txtInItemNo.Text = "";
            txtInItemName.Text = "";
            txtMFromNo.Text = "";
            txtMIntoNo.Text = "";
        }
        private void SaveUserEditor(int iiCnt)
        {
            try
            {
                T_Item data_this = new T_Item();
                data_this = db.StockItem(FlxInv.GetData(iiCnt, 1).ToString());
                T_EditItemPrice data_this_EditPrice = new T_EditItemPrice();
                data_this_EditPrice.ItmNo = FlxInv.GetData(iiCnt, 1).ToString();
                data_this_EditPrice.SelCostNow = double.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 6).ToString()));
                data_this_EditPrice.SelCostNew = double.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 9).ToString()));
                try
                {
                    if (data_this.Unit1.HasValue)
                    {
                        data_this_EditPrice.SelPriceNow1 = data_this.UntPri1.Value;
                        data_this_EditPrice.SelPriceNew1 = data_this.UntPri1.Value;
                    }
                    else
                    {
                        data_this_EditPrice.SelPriceNow1 = null;
                        data_this_EditPrice.SelPriceNew1 = null;
                    }
                    if (data_this.Unit2.HasValue)
                    {
                        data_this_EditPrice.SelPriceNow2 = data_this.UntPri2.Value;
                        data_this_EditPrice.SelPriceNew2 = data_this.UntPri2.Value;
                    }
                    else
                    {
                        data_this_EditPrice.SelPriceNow2 = null;
                        data_this_EditPrice.SelPriceNew2 = null;
                    }
                    if (data_this.Unit3.HasValue)
                    {
                        data_this_EditPrice.SelPriceNow3 = data_this.UntPri3.Value;
                        data_this_EditPrice.SelPriceNew3 = data_this.UntPri3.Value;
                    }
                    else
                    {
                        data_this_EditPrice.SelPriceNow3 = null;
                        data_this_EditPrice.SelPriceNew3 = null;
                    }
                    if (data_this.Unit4.HasValue)
                    {
                        data_this_EditPrice.SelPriceNow4 = data_this.UntPri4.Value;
                        data_this_EditPrice.SelPriceNew4 = data_this.UntPri4.Value;
                    }
                    else
                    {
                        data_this_EditPrice.SelPriceNow4 = null;
                        data_this_EditPrice.SelPriceNew4 = null;
                    }
                    if (data_this.Unit5.HasValue)
                    {
                        data_this_EditPrice.SelPriceNow5 = data_this.UntPri5.Value;
                        data_this_EditPrice.SelPriceNew5 = data_this.UntPri5.Value;
                    }
                    else
                    {
                        data_this_EditPrice.SelPriceNow5 = null;
                        data_this_EditPrice.SelPriceNew5 = null;
                    }
                    data_this_EditPrice.Distributors = data_this.Price2.Value;
                    data_this_EditPrice.DistributorsNew = data_this.Price2.Value;
                    data_this_EditPrice.Legates = data_this.Price3.Value;
                    data_this_EditPrice.LegatesNew = data_this.Price3.Value;
                    data_this_EditPrice.Sectorial = data_this.Price4.Value;
                    data_this_EditPrice.SectorialNew = data_this.Price4.Value;
                    data_this_EditPrice.Sentence = data_this.Price1.Value;
                    data_this_EditPrice.SentenceNew = data_this.Price1.Value;
                    data_this_EditPrice.VIP = data_this.Price5.Value;
                    data_this_EditPrice.VIPNew = data_this.Price5.Value;
                }
                catch
                {
                }
                data_this_EditPrice.HDate = VarGeneral.Hdate;
                data_this_EditPrice.GDate = VarGeneral.Gdate;
                data_this_EditPrice.UsrNm = VarGeneral.UserNameA;
                data_this_EditPrice.LTim = DateTime.Now.ToString("HH:mm");
                db.T_EditItemPrices.InsertOnSubmit(data_this_EditPrice);
                db.SubmitChanges();
            }
            catch (SqlException ex)
            {
                VarGeneral.DebLog.writeLog("SaveUserEditor:", ex, enable: true);
            }
        }
        private void combobox_Inv_SelectedIndexChanged(object sender, EventArgs e)
        {
            FlxInv.Rows.Count = 1;
        }
        private void txtFItemNo_TextChanged(object sender, EventArgs e)
        {
            FlxInv.Rows.Count = 1;
        }
        private void txtInItemNo_TextChanged(object sender, EventArgs e)
        {
            FlxInv.Rows.Count = 1;
        }
        private void button_DetData_Click(object sender, EventArgs e)
        {
            if (FlxInv.Rows.Count > 1 && MessageBox.Show("هل أنت متاكد من حذف أسعار التكاليف الجديدة قبل تحديثها في كرت الصنف ؟ \n Are you sure to delete the new cost prices before updating them in the product card?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
            {
                string Rule = "";
                if (!string.IsNullOrEmpty(txtFItemNo.Text))
                {
                    object obj = Rule;
                    Rule = string.Concat(obj, " and ", txtFItemNo.Tag, " >= '", txtFItemNo.Text.Trim(), "'");
                }
                if (!string.IsNullOrEmpty(txtInItemNo.Text))
                {
                    object obj = Rule;
                    Rule = string.Concat(obj, " and ", txtInItemNo.Tag, " <= '", txtInItemNo.Text.Trim(), "'");
                }
                if (!string.IsNullOrEmpty(txtMFromNo.Text))
                {
                    object obj = Rule;
                    Rule = string.Concat(obj, " and ", txtMFromNo.Tag, " >= ", txtMFromNo.Text.Trim());
                }
                if (!string.IsNullOrEmpty(txtMIntoNo.Text))
                {
                    object obj = Rule;
                    Rule = string.Concat(obj, " and ", txtMIntoNo.Tag, " <= ", txtMIntoNo.Text.Trim());
                }
                db.ExecuteCommand("Delete From T_INVDET_Repair Where 1 =1 " + Rule);
                Close();
            }
        }
    }
}
