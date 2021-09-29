using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Framework.Date;
using Framework.UI;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Library.RepShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmRepairSales : Form
    { void avs(int arln)

{ 
 label5.Text=   (arln == 0 ? "  من صنف :  " : "  of class:") ; label6.Text=   (arln == 0 ? "  إلى صنف :  " : "  to class:") ; ButOk.Text=   (arln == 0 ? "  عــرض  " : "  show") ; ButExit.Text=   (arln == 0 ? "  خـــروج  " : "  Close") ; Butupdate.Text=   (arln == 0 ? "  تحديث الأسعار  " : "  Prices update") ; label10.Text=   (arln == 0 ? "  نوع الفاتورة :  " : "  Invoice type:") ; groupBox_No.Text=   (arln == 0 ? "  حسب رقم الفاتورة  " : "  According to the invoice number") ; label1.Text=   (arln == 0 ? "  مـــــن :  " : "  from:") ; label2.Text=   (arln == 0 ? "  إلـــــى :  " : "  to:") ; groupBox_Date.Text=   (arln == 0 ? "  حسب تاريخ الفاتورة  " : "  According to the invoice date") ; label3.Text=   (arln == 0 ? "  مـــــن :  " : "  from:") ; label4.Text=   (arln == 0 ? "  إلـــــى :  " : "  to:") ; label7.Text=   (arln == 0 ? "  إعتماد التكلفة :  " : "  Cost Approval:") ; Text = "معالج تحديث أسعار تكلفة المبيعات";this.Text=   (arln == 0 ? "  معالج تحديث أسعار تكلفة المبيعات  " : "  Cost of sales price update wizard") ;}
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
        private Label label10;
        private ComboBoxEx combobox_Inv;
        private GroupBox groupBox_No;
        private MaskedTextBox txtMIntoNo;
        private Label label1;
        private Label label2;
        private MaskedTextBox txtMFromNo;
        private GroupBox groupBox_Date;
        private MaskedTextBox txtMToDate;
        private Label label3;
        private Label label4;
        private MaskedTextBox txtMFromDate;
        private Label label7;
        private ComboBoxEx combobox_InvCost;
        private int LangArEn = 0;
        private T_User _User = new T_User();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private Stock_DataDataContext dbInstance;
        private SplitContainer splitContainer1;
        private Rate_DataDataContext dbInstanceRate;
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
        public FrmRepairSales()
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
            var qkeys = from item in db.T_INVHEDs
                        where item.InvTyp == (int?)VarGeneral.InvTyp
                        where item.IfDel == (int?)0
                        select new
                        {
                            Code = item.InvNo + ""
                        };
        }
        private string BuildRuleList()
        {
            HijriGregDates dateFormatter = new HijriGregDates();
            string Rule = "Where T_INVHED.IfDel = 0 ";
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
            if (VarGeneral.CheckDate(txtMFromDate.Text) && txtMFromDate.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMFromDate.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_INVHED.GDat  >= '" + dateFormatter.FormatGreg(txtMFromDate.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_INVHED.HDat  >= '" + dateFormatter.FormatHijri(txtMFromDate.Text, "yyyy/MM/dd") + "'"));
            }
            if (VarGeneral.CheckDate(txtMToDate.Text) && txtMToDate.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMToDate.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_INVHED.GDat  <= '" + dateFormatter.FormatHijri(txtMToDate.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_INVHED.HDat  <= '" + dateFormatter.FormatHijri(txtMToDate.Text, "yyyy/MM/dd") + "'"));
            }
            if (combobox_Inv.SelectedIndex == 0)
            {
                return Rule + " and T_INVHED.InvTyp = 1 ";
            }
            return Rule + " and T_INVHED.InvTyp = 3 ";
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            FlxInv.Rows.Count = 1;
            try
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = "T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No ";
                string Fields = " T_INVDET.*,T_INVHED.*";
                _RepShow.Rule = BuildRuleList();
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
                if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                {
                    FlxInv.Rows.Count = VarGeneral.RepData.Tables[0].Rows.Count + 1;
                    for (int iiCnt = 1; iiCnt <= VarGeneral.RepData.Tables[0].Rows.Count; iiCnt++)
                    {
                        DataRow _InvDet = VarGeneral.RepData.Tables[0].Rows[iiCnt - 1];
                        FlxInv.SetData(iiCnt, 0, iiCnt);
                        FlxInv.SetData(iiCnt, 1, _InvDet["ItmNo"].ToString().Trim());
                        FlxInv.SetData(iiCnt, 2, (LangArEn == 0) ? _InvDet["ItmDes"].ToString().Trim() : _InvDet["ItmDesE"].ToString().Trim());
                        FlxInv.SetData(iiCnt, 3, _InvDet["InvNo"].ToString().Trim());
                        FlxInv.SetData(iiCnt, 4, _InvDet["HDat"].ToString().Trim() + " || " + _InvDet["GDat"].ToString().Trim());
                        FlxInv.SetData(iiCnt, 5, Math.Abs(double.Parse(_InvDet["Qty"].ToString().Trim())));
                        FlxInv.SetData(iiCnt, 6, _InvDet["Price"].ToString().Trim());
                        FlxInv.SetData(iiCnt, 7, _InvDet["Cost"].ToString().Trim());
                        FlxInv.SetData(iiCnt, 8, db.StockItem(_InvDet["ItmNo"].ToString().Trim()).AvrageCost.Value.ToString());
                        FlxInv.SetData(iiCnt, 9, db.StockItem(_InvDet["ItmNo"].ToString().Trim()).LastCost.Value.ToString());
                        FlxInv.SetData(iiCnt, 10, _InvDet["InvDet_ID"].ToString().Trim());
                        FlxInv.SetData(iiCnt, 11, _InvDet["InvHed_ID"].ToString().Trim());
                    }
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }
        private void FrmRepairSales_Load(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmRepairSales));
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
            FillCombo();
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
            Text = "Update Prices Cost Process";
            FlxInv.Cols[1].Caption = "Item No";
            FlxInv.Cols[2].Caption = "Item Name";
            FlxInv.Cols[3].Caption = "Inv No";
            FlxInv.Cols[4].Caption = "Inv Date";
            FlxInv.Cols[5].Caption = "Qty";
            FlxInv.Cols[6].Caption = "Price";
            FlxInv.Cols[7].Caption = "Cost Now";
            FlxInv.Cols[8].Caption = "Cost New";
            FlxInv.Cols[9].Caption = "Last Cost";
            groupBox_No.Text = "Inovice No";
            groupBox_Date.Text = "Invoice Date";
        }
        public void FillCombo()
        {
            combobox_Inv.Items.Clear();
            combobox_Inv.Items.Add((LangArEn == 0) ? "مبيعات" : "Sales");
            combobox_Inv.Items.Add((LangArEn == 0) ? "مرتجع مبيعات" : "Returned sales invoice");
            combobox_Inv.SelectedIndex = 0;
            combobox_InvCost.Items.Clear();
            combobox_InvCost.Items.Add((LangArEn == 0) ? "متوسط التكلفة" : "Average Cost");
            combobox_InvCost.Items.Add((LangArEn == 0) ? "آخر تكلفة" : "Last Cost");
            combobox_InvCost.SelectedIndex = 0;
        }
        private void FrmRepairSales_KeyDown(object sender, KeyEventArgs e)
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
            if (FlxInv.Rows.Count <= 1 || MessageBox.Show("سيتم تحديث تكلفة المبيعات للاصناف المحددة  \n هل تريد الأستمرار ? ", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                return;
            }
            int iiCnt;
            for (iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
            {
                try
                {
                    if (FlxInv.GetData(iiCnt, 1) == null)
                    {
                        continue;
                    }
                    db.ExecuteCommand("update T_INVDET set Cost = " + ((combobox_InvCost.SelectedIndex == 0) ? Math.Abs(double.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 8).ToString()))) : Math.Abs(double.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 9).ToString())))) + " where InvDet_ID = " + double.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 10).ToString())));
                    Stock_DataDataContext dbT = new Stock_DataDataContext(VarGeneral.BranchCS);
                    List<T_INVHED> q = (from t in dbT.T_INVHEDs
                                        where t.IfDel == (int?)0
                                        where t.InvTyp == (int?)((combobox_Inv.SelectedIndex == 0) ? 1 : 3)
                                        where t.InvHed_ID == int.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 11).ToString()))
                                        select t).ToList();
                    if (q.Count > 0)
                    {
                        dbT.ExecuteCommand("update T_INVHED set InvCost = " + Math.Abs(q.FirstOrDefault().T_INVDETs.Sum((T_INVDET g) => g.Cost.Value * g.RealQty.Value)) + " where InvHed_ID = " + q.FirstOrDefault().InvHed_ID);
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
            txtMFromDate.Text = "";
            txtMToDate.Text = "";
        }
        private void txtMFromNo_Click(object sender, EventArgs e)
        {
            txtMFromNo.SelectAll();
        }
        private void txtMIntoNo_Click(object sender, EventArgs e)
        {
            txtMIntoNo.SelectAll();
        }
        private void txtMFromDate_Click(object sender, EventArgs e)
        {
            txtMFromDate.SelectAll();
        }
        private void txtMToDate_Click(object sender, EventArgs e)
        {
            txtMToDate.SelectAll();
        }
        private void txtMFromDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtMFromDate.Text))
                {
                    txtMFromDate.Text = Convert.ToDateTime(txtMFromDate.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    txtMFromDate.Text = "";
                }
            }
            catch
            {
                txtMFromDate.Text = "";
            }
        }
        private void txtMToDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtMToDate.Text))
                {
                    txtMToDate.Text = Convert.ToDateTime(txtMToDate.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    txtMToDate.Text = "";
                }
            }
            catch
            {
                txtMToDate.Text = "";
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
    }
}
