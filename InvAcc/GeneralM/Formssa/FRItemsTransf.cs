using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Framework.Date;
using Framework.UI;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Library.RepShow;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FRItemsTransf : Form
    {
        private int LangArEn = 0;
        private T_User _User = new T_User();
        public Dictionary<string, FRItemsTransf.ColumnDictinary> columns_Names_visible = new Dictionary<string, FRItemsTransf.ColumnDictinary>();
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private IContainer components = null;
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
        private void FRInvoice_VisibleChanged(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;
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
        private Panel PanelSpecialContainer;
        public Softgroup.NetResize.NetResize netResize1;
        private RibbonBar ribbonBar1;
        private Label label11;
        private ButtonX button_SrchItemGroup;
        private TextBox txtClassName;
        private TextBox txtClassNo;
        private Label label10;
        private ButtonX button_SrchItemNo;
        private TextBox txtItemName;
        private TextBox txtItemNo;
        private GroupBox CmbReturn;
        private RadioButton radioButton_ِReturn1;
        private RadioButton radioButton_ِReturn2;
        private RadioButton radioButton_ِReturn0;
        private GroupBox CmbDeleted;
        private RadioButton radioButton_Del1;
        private RadioButton radioButton_Del2;
        private RadioButton radioButton_Del0;
        private Label label9;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label8;
        private ButtonX button_SrchUsrNo;
        private ButtonX button_SrchCostNo;
        private ButtonX button_SrchLegNo;
        private ButtonX button_SrchSuppNo;
        private ButtonX button_SrchCustNo;
        private TextBox txtCostNo;
        private TextBox txtUserName;
        private TextBox txtUserNo;
        private TextBox txtLegName;
        private TextBox txtLegNo;
        private TextBox txtSuppName;
        private TextBox txtSuppNo;
        private TextBox txtCustName;
        private TextBox txtCustNo;
        private TextBox txtCostName;
        private GroupBox groupBox3;
        private MaskedTextBox txtMIntoNo;
        private Label label1;
        private Label label2;
        private MaskedTextBox txtMFromNo;
        private GroupBox groupBox_Date;
        private MaskedTextBox txtMToDate;
        private MaskedTextBox txtMFromDate;
        private C1FlexGrid FlexType;
        private Label label3;
        private Label label4;
        private ComboBoxEx combobox_SortTyp;
        private GroupBox groupBox2;
        private RadioButton RButLandscape;
        private RadioButton RButPortrait;
        private SwitchButton RButShort;
        public CheckBoxX chkLine;
        private CheckBoxX checkBox_Defalut;
        private CheckBoxX checkBox_ItemComm;
        private C1.Win.C1Input.C1Button ButOk;
        private C1.Win.C1Input.C1Button ButExit;
        private CheckBoxX checkBox_Note;
        private Stock_DataDataContext db
        {
            get
            {
                if (this.dbInstance == null)
                {
                    this.dbInstance = new Stock_DataDataContext(VarGeneral.BranchCS);
                }
                return this.dbInstance;
            }
        }
        private Rate_DataDataContext dbc
        {
            get
            {
                if (this.dbInstanceRate == null)
                {
                    this.dbInstanceRate = new Rate_DataDataContext(VarGeneral.BranchRt);
                }
                return this.dbInstanceRate;
            }
        }
        public FRItemsTransf()
        {
            this.InitializeComponent();
            this._User = this.dbc.StockUser(VarGeneral.UserNumber);
            if ((VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F" || VarGeneral.SSSLev == "S" ? false : !(VarGeneral.SSSLev == "C")))
            {
                this.label8.Visible = true;
                this.txtCostNo.Visible = true;
                this.button_SrchCostNo.Visible = true;
                this.txtCostName.Visible = true;
            }
            else
            {
                this.label8.Visible = false;
                this.txtCostNo.Visible = false;
                this.button_SrchCostNo.Visible = false;
                this.txtCostName.Visible = false;
            }
            try
            {
                if ((VarGeneral.SSSLev == "B" ? true : VarGeneral.SSSLev == "F"))
                {
                    RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", true);
                    try
                    {
                        if (string.IsNullOrEmpty(hKey.GetValue("vCoCe").ToString()))
                        {
                            hKey.CreateSubKey("vCoCe");
                            hKey.SetValue("vCoCe", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vCoCe");
                        hKey.SetValue("vCoCe", "0");
                    }
                    if (long.Parse(hKey.GetValue("vCoCe").ToString()) != (long)1)
                    {
                        this.label8.Visible = false;
                        this.txtCostNo.Visible = false;
                        this.button_SrchCostNo.Visible = false;
                        this.txtCostName.Visible = false;
                    }
                    else
                    {
                        this.label8.Visible = true;
                        this.txtCostNo.Visible = true;
                        this.button_SrchCostNo.Visible = true;
                        this.txtCostName.Visible = true;
                    }
                }
            }
            catch
            {
            }
        }
        private string BuildRuleList()
        {
            object obj;
            object[] tag;
            HijriGregDates dateFormatter = new HijriGregDates();
            string Rule = string.Concat("Where T_INVHED.InvTyp = ", VarGeneral.InvType);
            if (!string.IsNullOrEmpty(this.txtMFromNo.Text))
            {
                obj = Rule;
                tag = new object[] { obj, " and ", this.txtMFromNo.Tag, " >= ", this.txtMFromNo.Text.Trim() };
                Rule = string.Concat(tag);
            }
            if (!string.IsNullOrEmpty(this.txtMIntoNo.Text))
            {
                obj = Rule;
                tag = new object[] { obj, " and ", this.txtMIntoNo.Tag, " <= ", this.txtMIntoNo.Text.Trim() };
                Rule = string.Concat(tag);
            }
            if (!string.IsNullOrEmpty(this.txtCostNo.Text))
            {
                obj = Rule;
                tag = new object[] { obj, " and ", this.txtCostNo.Tag, " = ", this.txtCostNo.Text.Trim() };
                Rule = string.Concat(tag);
            }
            if (!string.IsNullOrEmpty(this.txtCustNo.Text))
            {
                obj = Rule;
                tag = new object[] { obj, " and ", this.txtCustNo.Tag, " = '", this.txtCustNo.Text.Trim(), "'" };
                Rule = string.Concat(tag);
            }
            if (!string.IsNullOrEmpty(this.txtSuppNo.Text))
            {
                obj = Rule;
                tag = new object[] { obj, " and ", this.txtSuppNo.Tag, " = '", this.txtSuppNo.Text.Trim(), "'" };
                Rule = string.Concat(tag);
            }
            if (!string.IsNullOrEmpty(this.txtLegNo.Text))
            {
                obj = Rule;
                tag = new object[] { obj, " and ", this.txtLegNo.Tag, " = ", this.txtLegNo.Text.Trim() };
                Rule = string.Concat(tag);
            }
            if (!string.IsNullOrEmpty(this.txtUserNo.Text))
            {
                if ((!File.Exists(string.Concat(Application.StartupPath, "\\Script\\SecriptInv.dll")) ? true : VarGeneral.InvType != 1))
                {
                    obj = Rule;
                    tag = new object[] { obj, " and ", this.txtUserNo.Tag, " = '", this.txtUserNo.Text.Trim(), "'" };
                    Rule = string.Concat(tag);
                }
                else
                {
                    Rule = string.Concat(Rule, " and  T_INVHED.UserNew  = '", this.txtUserNo.Text.Trim(), "'");
                }
            }
            if (!string.IsNullOrEmpty(this.txtItemNo.Text))
            {
                obj = Rule;
                tag = new object[] { obj, " and ", this.txtItemNo.Tag, " = '", this.txtItemNo.Text.Trim(), "'" };
                Rule = string.Concat(tag);
            }
            if (!string.IsNullOrEmpty(this.txtClassNo.Text))
            {
                obj = Rule;
                tag = new object[] { obj, " and ", this.txtClassNo.Tag, " = ", this.txtClassNo.Text.Trim() };
                Rule = string.Concat(tag);
            }
            if ((!VarGeneral.CheckDate(this.txtMFromDate.Text) ? false : this.txtMFromDate.Text.Length == 10))
            {
                Rule = (int.Parse(this.txtMFromDate.Text.Substring(0, 4)) >= 1800 ? string.Concat(Rule, " and  T_INVHED.GDat  >= '", dateFormatter.FormatGreg(this.txtMFromDate.Text, "yyyy/MM/dd"), "'") : string.Concat(Rule, " and  T_INVHED.HDat  >= '", dateFormatter.FormatHijri(this.txtMFromDate.Text, "yyyy/MM/dd"), "'"));
            }
            if ((!VarGeneral.CheckDate(this.txtMToDate.Text) ? false : this.txtMToDate.Text.Length == 10))
            {
                Rule = (int.Parse(this.txtMToDate.Text.Substring(0, 4)) >= 1800 ? string.Concat(Rule, " and  T_INVHED.GDat  <= '", dateFormatter.FormatGreg(this.txtMToDate.Text, "yyyy/MM/dd"), "'") : string.Concat(Rule, " and  T_INVHED.HDat  <= '", dateFormatter.FormatHijri(this.txtMToDate.Text, "yyyy/MM/dd"), "'"));
            }
            if (this.radioButton_Del0.Checked)
            {
                obj = Rule;
                tag = new object[] { obj, " and ", this.CmbDeleted.Tag, " != 1 " };
                Rule = string.Concat(tag);
            }
            else if (this.radioButton_Del2.Checked)
            {
                obj = Rule;
                tag = new object[] { obj, " and ", this.CmbDeleted.Tag, " = 1 " };
                Rule = string.Concat(tag);
            }
            if (this.radioButton_ِReturn0.Checked)
            {
                obj = Rule;
                tag = new object[] { obj, " and ", this.CmbReturn.Tag, " != 1 " };
                Rule = string.Concat(tag);
            }
            else if (this.radioButton_ِReturn2.Checked)
            {
                obj = Rule;
                tag = new object[] { obj, " and ", this.CmbReturn.Tag, " = 1 " };
                Rule = string.Concat(tag);
            }
            int iiCnt = 0;
            string RuleInvType = ""; int rc = FlexType.Rows.Count; if (rc == 3) rc--;
            object obj1;
            for (iiCnt = 0; iiCnt < rc; iiCnt++)
            {
                if ((bool)this.FlexType.GetData(iiCnt, 0))
                {
                    if (!string.IsNullOrEmpty(RuleInvType))
                    {
                        RuleInvType = string.Concat(RuleInvType, " or ");
                    }
                    obj1 = RuleInvType;
                    tag = new object[] { obj1, this.FlexType.Tag, "  = ", iiCnt };
                    RuleInvType = string.Concat(tag);
                }
            }
            if (FlexType.Rows.Count == 3)
                if ((bool)this.FlexType.GetData(2, 0))
                {
                    if (string.IsNullOrEmpty(RuleInvType))
                    {
                        obj1 = RuleInvType;
                        tag = new object[] { obj1, this.FlexType.Tag, "  = ", iiCnt };
                        RuleInvType = string.Concat(tag);
                    }
                    obj1 = RuleInvType;
                    tag = new object[] { obj1, " or T_INVHED.InvCash = 'الشبكة' or T_INVHED.InvCash = 'شبكـــة' " };
                    RuleInvType = string.Concat(tag);
                }
            if (!string.IsNullOrEmpty(RuleInvType))
            {
                Rule = string.Concat(Rule, " and (", RuleInvType, ")");
            }
            return Rule;
        }
        private void ButExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            object[] objArray;
            double? itemComm;
            double value;
            try
            {
                if (!(this.Text == "تقرير حركة صنف في فاتورة مبيعات" ? false : !(this.Text == "Sales Invoice Report")))
                {
                    VarGeneral.InvType = 1;
                }
                else if (!(this.Text == "تقرير حركة صنف في فاتورة فاتورة مشتريات" ? false : !(this.Text == "Purchase Invoice Report")))
                {
                    VarGeneral.InvType = 2;
                }
                else if (!(this.Text == "تقرير حركة صنف في مرتجع مبيعات" ? false : !(this.Text == "Sales Return Report")))
                {
                    VarGeneral.InvType = 3;
                }
                else if (!(this.Text == "تقرير حركة صنف في فاتورة مرتجع مشتريات" ? false : !(this.Text == "Purchase Return Report")))
                {
                    VarGeneral.InvType = 4;
                }
                else if (!(this.Text == "تقرير حركة صنف في فاتورة إدخال بضاعة" ? false : !(this.Text == "Transfer In Report")))
                {
                    VarGeneral.InvType = 5;
                }
                else if (!(this.Text == "تقرير حركة صنف في فاتورة إخراج بضاعة" ? false : !(this.Text == "Transfer Out Report")))
                {
                    VarGeneral.InvType = 6;
                }
                else if (!(this.Text == "تقرير حركة صنف في فاتورة عرض سعر للعملاء" ? false : !(this.Text == "Customer Qutation Report")))
                {
                    VarGeneral.InvType = 7;
                }
                else if (!(this.Text == "تقرير حركة صنف في فاتورة عرض سعر للموردين" ? false : !(this.Text == "Supplier Qutation Report")))
                {
                    VarGeneral.InvType = 8;
                }
                else if (!(this.Text == "تقرير حركة صنف في فاتورة طلب شراء" ? false : !(this.Text == "Purchase Order Report")))
                {
                    VarGeneral.InvType = 9;
                }
                else if (!(this.Text == "تقرير حركة صنف في فاتورة تسوية البضاعة" ? false : !(this.Text == "Stock Adjustment Report")))
                {
                    VarGeneral.InvType = 10;
                }
                else if (!(this.Text == "تقرير حركة صنف في فاتورة بضاعة اول المدة" ? false : !(this.Text == "Open Quantities Report")))
                {
                    VarGeneral.InvType = 14;
                }
                else if (!(this.Text == "تقرير حركة صنف في فاتورة صرف بضاعة" ? false : !(this.Text == "Payment Order Report")))
                {
                    VarGeneral.InvType = 17;
                }
                else if ((this.Text == "تقرير حركة صنف في فاتورة مرتجع صرف بضاعة" ? true : this.Text == "Payment Order Return Report"))
                {
                    VarGeneral.InvType = 20;
                }
                if ((this.Text == "تقرير حركة صنف في فاتورة عرض سعر الطلاب" ? true : this.Text == "Students Qutation Report"))
                {
                    VarGeneral.InvType = 7;
                }
                if ((this.Text == "تقرير فواتير عرض سعر السائقين" ? true : this.Text == "Drivers Qutation Reports"))
                {
                    VarGeneral.InvType = 7;
                }
                if ((this.Text == "تقرير حركة صنف في فاتورة الخدمة" ? true : this.Text == "Service Invoice Report"))
                {
                    VarGeneral.InvType = 1;
                }
                if ((this.Text == "تقرير حركة صنف في فاتورة أمر تحميل" ? true : this.Text == "Order"))
                {
                    VarGeneral.InvType = 8;
                }
                if (!(this.Text == "تقرير حركة صنف في فاتورة إصدار عهدة" ? false : !(this.Text == "Report Movement Class in Bill Issue Custody")))
                {
                    VarGeneral.InvType = 17;
                }
                else if ((this.Text == "تقرير حركة صنف في فاتورة إرجاع عهدة" ? true : this.Text == "Report Movement Class in Bill Return Custody"))
                {
                    VarGeneral.InvType = 20;
                }
                if ((this.Text == "تقرير حركة صنف في فاتورة إصدار الدعوات" ? true : this.Text == "Invitation Issuse Item Movement Report"))
                {
                    VarGeneral.InvType = 8;
                }
                RepShow _RepShow = new RepShow()
                {
                    Tables = "T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_Items.CompanyID = T_SYSSETTING.SYSSETTING_ID"
                };
                string Fields = "";
                if (this.LangArEn != 0)
                {
                    objArray = new object[] { " InvDet_ID,T_Items.Itm_No,T_Items.Eng_Des as itemNm,T_Category.Eng_Des as CategoyNm,T_InvDet.StoreNo,T_InvDet.ItmUntE as UnitNm,T_InvDet.ItmUntPak,(Round(T_InvDet.Price,", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2), ")) as Price,T_InvDet.ItmDis,Abs(T_InvDet.Qty) as Qty,(Round(T_InvDet.Amount,", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2), ")) as Amount,T_INVHED.InvNo, T_INVSETTING.InvNamE as InvTypNm,T_INVHED.InvCash,T_Curency.Eng_Des as CurrnceyNm,", (this.checkBox_Note.Checked ? " T_INVHED.Remark as GadeNo" : " T_INVHED.GadeNo "), ",T_INVHED.CusVenNo,T_INVHED.CusVenNm,T_INVHED.GDat,T_INVHED.HDat,T_CstTbl.Eng_Des as CostCenteNm, T_Mndob.Eng_Des as MndNm,T_INVHED.RetNo,T_SYSSETTING.LogImg ,case when T_INVHED.InvTyp =2 or T_INVHED.InvTyp =4 or T_INVHED.InvTyp = 9 or T_INVHED.InvTyp =14 then 0 else (Round(T_InvDet.Amount - (T_InvDet.Cost * Abs(T_InvDet.RealQty)),", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2), ")) end as Profit,case when T_INVHED.InvTyp =2 or T_INVHED.InvTyp =4 or T_INVHED.InvTyp = 9 or T_INVHED.InvTyp =14 then 0 else (T_InvDet.Cost * Abs(T_InvDet.Qty)) end as Cost,T_Items.ItmTyp,Abs(T_InvDet.RealQty) as QtyItemComm,'", this.label7.Text.Replace(":", ""), "' as MndHeaderX,'", this.txtLegNo.Text, "' as MndNoX,'", this.txtLegName.Text, "' as MndNameX,'", this.label5.Text.Replace(":", ""), "' as CustHeaderX,'", this.txtCustNo.Text, "' as CustNoX,'", this.txtCustName.Text, "' as CustNameX,'", this.label6.Text.Replace(":", ""), "' as SuppHeaderX,'", this.txtSuppNo.Text, "' as SuppNoX,'", this.txtSuppName.Text, "' as SuppNameX" };
                    Fields = string.Concat(objArray);
                }
                else
                {
                    objArray = new object[] { " InvDet_ID,T_Items.Itm_No,T_Items.Arb_Des as itemNm,T_Category.Arb_Des as CategoyNm,T_InvDet.StoreNo,T_InvDet.ItmUnt as UnitNm,T_InvDet.ItmUntPak,(Round(T_InvDet.Price,", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2), ")) as Price,T_InvDet.ItmDis,Abs(T_InvDet.Qty) as Qty,(Round(T_InvDet.Amount,", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2), ")) as Amount,T_INVHED.InvNo, T_INVSETTING.InvNamA as InvTypNm,T_INVHED.InvCash,T_Curency.Arb_Des as CurrnceyNm,", (this.checkBox_Note.Checked ? " T_INVHED.Remark as GadeNo" : " T_INVHED.GadeNo "), ",T_INVHED.CusVenNo,T_INVHED.CusVenNm,T_INVHED.GDat,T_INVHED.HDat,T_CstTbl.Arb_Des as CostCenteNm, T_Mndob.Arb_Des as MndNm,T_INVHED.RetNo,T_SYSSETTING.LogImg,case when T_INVHED.InvTyp =2 or T_INVHED.InvTyp =4 or T_INVHED.InvTyp = 9 or T_INVHED.InvTyp =14 then 0 else (Round(T_InvDet.Amount - (T_InvDet.Cost * Abs(T_InvDet.RealQty)),", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2), ")) end as Profit,case when T_INVHED.InvTyp =2 or T_INVHED.InvTyp =4 or T_INVHED.InvTyp = 9 or T_INVHED.InvTyp =14 then 0 else (T_InvDet.Cost * Abs(T_InvDet.Qty)) end as Cost,T_Items.ItmTyp,Abs(T_InvDet.RealQty) as QtyItemComm,'", this.label7.Text.Replace(":", ""), "' as MndHeaderX,'", this.txtLegNo.Text, "' as MndNoX,'", this.txtLegName.Text, "' as MndNameX,'", this.label5.Text.Replace(":", ""), "' as CustHeaderX,'", this.txtCustNo.Text, "' as CustNoX,'", this.txtCustName.Text, "' as CustNameX,'", this.label6.Text.Replace(":", ""), "' as SuppHeaderX,'", this.txtSuppNo.Text, "' as SuppNoX,'", this.txtSuppName.Text, "' as SuppNameX" };
                    Fields = string.Concat(objArray);
                }
                _RepShow.Rule = string.Concat(this.BuildRuleList(), (this.combobox_SortTyp.SelectedIndex == 0 ? " order by T_INVHED.InvNo " : " order by T_INVHED.GDat "));
                _RepShow.Fields = Fields;
                try
                {
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                    try
                    {
                        if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 15))
                        {
                            _RepShow = new RepShow()
                            {
                                Rule = "",
                                Tables = "T_SINVDET LEFT OUTER JOIN T_INVHED ON T_SINVDET.SInvIdHEAD = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_SINVDET.SItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID "
                            };
                            if (this.LangArEn != 0)
                            {
                                RepShow repShow = _RepShow;
                                objArray = new object[] { " SInvId as InvDet_ID,T_Items.Itm_No,T_Items.Eng_Des as itemNm,T_Category.Eng_Des as CategoyNm,T_SINVDET.SStoreNo as StoreNo,T_SINVDET.SItmUntE as UnitNm,T_SINVDET.SItmUntPak as ItmUntPak,(Round(T_SINVDET.SPrice,", null, null, null, null, null, null, null, null };
                                objArray[1] = (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                                objArray[2] = ")) as Price2,T_SINVDET.SItmDis as ItmDis,Abs(T_SINVDET.SQty) as Qty,(Round(T_SINVDET.SAmount,";
                                objArray[3] = (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                                objArray[4] = ")) as Amount,T_INVHED.InvNo, T_INVSETTING.InvNamE as InvTypNm,T_INVHED.InvCash,T_Curency.Eng_Des as CurrnceyNm,";
                                objArray[5] = (this.checkBox_Note.Checked ? " T_INVHED.Remark as GadeNo" : " T_INVHED.GadeNo ");
                                objArray[6] = ",T_INVHED.CusVenNo,T_INVHED.CusVenNm,T_INVHED.GDat,T_INVHED.HDat,T_CstTbl.Eng_Des as CostCenteNm, T_Mndob.Eng_Des as MndNm,T_INVHED.RetNo,T_SYSSETTING.LogImg ,(Round(T_SINVDET.SAmount - (T_SINVDET.SCost * Abs(T_SINVDET.SRealQty)),";
                                objArray[7] = (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                                objArray[8] = ")) as Profit,T_SINVDET.SCost as SCost,T_SINVDET.SRealQty as QtyItemComm";
                                repShow.Fields = string.Concat(objArray);
                            }
                            else
                            {
                                RepShow repShow1 = _RepShow;
                                objArray = new object[] { " SInvId as InvDet_ID,T_Items.Itm_No,T_Items.Arb_Des as itemNm,T_Category.Arb_Des as CategoyNm,T_SINVDET.SStoreNo as StoreNo,T_SINVDET.SItmUnt as UnitNm,T_SINVDET.SItmUntPak as ItmUntPak,(Round(T_SINVDET.SPrice,", null, null, null, null, null, null, null, null };
                                objArray[1] = (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                                objArray[2] = ")) as Price2,T_SINVDET.SItmDis as ItmDis,Abs(T_SINVDET.SQty) as Qty,(Round(T_SINVDET.SAmount,";
                                objArray[3] = (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                                objArray[4] = ")) as Amount,T_INVHED.InvNo, T_INVSETTING.InvNamA as InvTypNm,T_INVHED.InvCash,T_Curency.Arb_Des as CurrnceyNm,";
                                objArray[5] = (this.checkBox_Note.Checked ? " T_INVHED.Remark as GadeNo" : " T_INVHED.GadeNo ");
                                objArray[6] = ",T_INVHED.CusVenNo,T_INVHED.CusVenNm,T_INVHED.GDat,T_INVHED.HDat,T_CstTbl.Arb_Des as CostCenteNm, T_Mndob.Arb_Des as MndNm,T_INVHED.RetNo,T_SYSSETTING.LogImg,(Round(T_SINVDET.SAmount - (T_SINVDET.SCost * Abs(T_SINVDET.SRealQty)),";
                                objArray[7] = (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                                objArray[8] = ")) as Profit ,T_SINVDET.SCost as SCost,T_SINVDET.SRealQty as QtyItemComm";
                                repShow1.Fields = string.Concat(objArray);
                            }
                            _RepShow.Rule = this.BuildRuleList();
                            _RepShow = _RepShow.Save();
                            VarGeneral.RepData.Tables[0].Merge(_RepShow.RepData.Tables[0]);
                        }
                    }
                    catch
                    {
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
                if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                {
                    try
                    {
                        if ((!this.checkBox_ItemComm.Visible ? false : this.checkBox_ItemComm.Checked))
                        {
                            int Comm_ = 0;
                            try
                            {
                                Comm_ = int.Parse(VarGeneral.Settings_Sys.Seting.Substring(50, 1));
                            }
                            catch
                            {
                            }
                            for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
                            {
                                try
                                {
                                    DataRow item = VarGeneral.RepData.Tables[0].Rows[i];
                                    if (Comm_ == 0)
                                    {
                                        double num = double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["Amount"].ToString());
                                        itemComm = this.db.StockItem(VarGeneral.RepData.Tables[0].Rows[i]["Itm_No"].ToString()).ItemComm;
                                        value = num * (itemComm.Value / 100);
                                    }
                                    else if (Comm_ == 1)
                                    {
                                        itemComm = this.db.StockItem(VarGeneral.RepData.Tables[0].Rows[i]["Itm_No"].ToString()).ItemComm;
                                        value = itemComm.Value * double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["QtyItemComm"].ToString());
                                    }
                                    else
                                    {
                                        itemComm = this.db.StockItem(VarGeneral.RepData.Tables[0].Rows[i]["Itm_No"].ToString()).ItemComm;
                                        value = itemComm.Value;
                                    }
                                    item["GadeNo"] = value;
                                }
                                catch
                                {
                                    //  goto Label0;
                                }
                                // Label0:
                            }
                        }
                        FrmReportsViewer frm = new FrmReportsViewer()
                        {
                            Tag = this.LangArEn,
                            Repvalue = "ItemTrans"
                        };
                        VarGeneral.itmDes = "Show";
                        if (!this.RButPortrait.Checked)
                        {
                            VarGeneral.itmDesIndex = 1;
                        }
                        else
                        {
                            VarGeneral.itmDesIndex = 0;
                        }
                        if (this.RButShort.Value)
                        {
                            VarGeneral.itmDesIndex = 3;
                            if (!this.chkLine.Checked)
                            {
                                VarGeneral.itmDes = "Hide";
                            }
                        }
                        try
                        {
                            if (!this.checkBox_ItemComm.Checked)
                            {
                                VarGeneral.itemCommRep = false;
                            }
                            else
                            {
                                VarGeneral.itemCommRep = true;
                            }
                        }
                        catch
                        {
                            VarGeneral.itemCommRep = false;
                        }
                        try
                        {
                            if (this.checkBox_Note.Checked)
                            {
                                VarGeneral.itmDes = "Note";
                            }
                        }
                        catch
                        {
                            VarGeneral.itmDes = "";
                        }
                        VarGeneral.vTitle = this.Text;
                        VarGeneral.Customerlbl = this.label5.Text.Replace(" :", "");
                        VarGeneral.Supplierlbl = this.label6.Text.Replace(" :", "");
                        VarGeneral.CostCenterlbl = this.label8.Text.Replace(" :", "");
                        VarGeneral.Mndoblbl = this.label7.Text.Replace(" :", "");
                        frm.TopMost = true;
                        frm.ShowDialog();
                    }
                    catch (Exception exception1)
                    {
                        Exception error = exception1;
                        VarGeneral.DebLog.writeLog("button_ShowRep_Click:", error, true);
                        MessageBox.Show(error.Message);
                    }
                }
                else
                {
                    MessageBox.Show((this.LangArEn == 0 ? "عفوا .. لا يوجد بيانات لعرضها في التقرير " : "Sorry .. there is no data to display in the report "), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception exception2)
            {
                MessageBox.Show(exception2.Message);
            }
            VarGeneral.itemCommRep = false;
            try
            {
                VarGeneral.itmDesIndex = 0;
                VarGeneral.itmDes = "";
            }
            catch
            {
            }
        }
        private void button_SrchCostNo_Click(object sender, EventArgs e)
        {
            this.columns_Names_visible.Clear();
            this.columns_Names_visible.Add("Cst_No", new FRItemsTransf.ColumnDictinary("الرقم", "No", true, ""));
            this.columns_Names_visible.Add("Arb_Des", new FRItemsTransf.ColumnDictinary("الاسم عربي", "Arabic Name", true, ""));
            this.columns_Names_visible.Add("Eng_Des", new FRItemsTransf.ColumnDictinary("الاسم الانجليزي", "English Name", true, ""));
            FrmSearch frm = new FrmSearch()
            {
                Tag = this.LangArEn
            };
            foreach (KeyValuePair<string, FRItemsTransf.ColumnDictinary> kvp in this.columns_Names_visible)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_CstTbl";
            frm.TopMost = true;
            frm.ShowDialog();
            if (!(frm.SerachNo != ""))
            {
                this.txtCostNo.Text = "";
                this.txtCostName.Text = "";
            }
            else
            {
                TextBox str = this.txtCostNo;
                int cstID = this.db.StockCst(frm.Serach_No).Cst_ID;
                str.Text = cstID.ToString();
                if (this.LangArEn != 0)
                {
                    this.txtCostName.Text = this.db.StockCst(frm.Serach_No).Eng_Des.ToString();
                }
                else
                {
                    this.txtCostName.Text = this.db.StockCst(frm.Serach_No).Arb_Des.ToString();
                }
            }
        }
        private void button_SrchCustNo_Click(object sender, EventArgs e)
        {
            this.columns_Names_visible.Clear();
            this.columns_Names_visible.Add("AccDef_No", new FRItemsTransf.ColumnDictinary("الرقم ", " No", true, ""));
            this.columns_Names_visible.Add("Arb_Des", new FRItemsTransf.ColumnDictinary("الاسم عربي", "Arabic Name", true, ""));
            this.columns_Names_visible.Add("Eng_Des", new FRItemsTransf.ColumnDictinary("الاسم الانجليزي", "English Name", true, ""));
            this.columns_Names_visible.Add("AccDef_ID", new FRItemsTransf.ColumnDictinary(" ", " ", false, ""));
            this.columns_Names_visible.Add("Mobile", new FRItemsTransf.ColumnDictinary("الجوال", "Mobile", false, ""));
            FrmSearch frm = new FrmSearch()
            {
                Tag = this.LangArEn
            };
            foreach (KeyValuePair<string, FRItemsTransf.ColumnDictinary> kvp in this.columns_Names_visible)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_AccDef2";
            VarGeneral.AccTyp = 4;
            frm.TopMost = true;
            frm.ShowDialog();
            if (!(frm.SerachNo != ""))
            {
                this.txtCustNo.Text = "";
                this.txtCustName.Text = "";
            }
            else
            {
                this.txtCustNo.Text = this.db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (this.LangArEn != 0)
                {
                    this.txtCustName.Text = this.db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
                else
                {
                    this.txtCustName.Text = this.db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
            }
        }
        private void button_SrchItemGroup_Click(object sender, EventArgs e)
        {
            this.columns_Names_visible.Clear();
            this.columns_Names_visible.Add("CAT_No", new FRItemsTransf.ColumnDictinary("الرمـــز", "CATEGORY No", true, ""));
            this.columns_Names_visible.Add("Arb_Des", new FRItemsTransf.ColumnDictinary("الاسم عربي", "Arabic Name", true, ""));
            this.columns_Names_visible.Add("Eng_Des", new FRItemsTransf.ColumnDictinary("الاسم الانجليزي", "English Name", true, ""));
            FrmSearch frm = new FrmSearch()
            {
                Tag = this.LangArEn
            };
            foreach (KeyValuePair<string, FRItemsTransf.ColumnDictinary> kvp in this.columns_Names_visible)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_CATEGORY";
            frm.TopMost = true;
            frm.ShowDialog();
            if (!(frm.SerachNo != ""))
            {
                this.txtClassNo.Text = "";
                this.txtClassName.Text = "";
            }
            else
            {
                TextBox str = this.txtClassNo;
                int cATID = this.db.StockCat(frm.Serach_No).CAT_ID;
                str.Text = cATID.ToString();
                if (this.LangArEn != 0)
                {
                    this.txtClassName.Text = this.db.StockCat(frm.Serach_No).Eng_Des;
                }
                else
                {
                    this.txtClassName.Text = this.db.StockCat(frm.Serach_No).Arb_Des;
                }
            }
        }
        private void button_SrchItemNo_Click(object sender, EventArgs e)
        {
            this.columns_Names_visible.Clear();
            this.columns_Names_visible.Add("Itm_No", new FRItemsTransf.ColumnDictinary("رقم الصنف", "Item No", true, ""));
            this.columns_Names_visible.Add("Arb_Des", new FRItemsTransf.ColumnDictinary("الاسم عربي", "Arabic Name", true, ""));
            this.columns_Names_visible.Add("Eng_Des", new FRItemsTransf.ColumnDictinary("الاسم الانجليزي", "English Name", false, ""));
            this.columns_Names_visible.Add("StartCost", new FRItemsTransf.ColumnDictinary("التكلفةالافتتاحية", "Start Cost", false, ""));
            this.columns_Names_visible.Add("AvrageCost", new FRItemsTransf.ColumnDictinary("متوسط التكلفة", "Average Cost", false, ""));
            this.columns_Names_visible.Add("LastCost", new FRItemsTransf.ColumnDictinary("آخر تكلفة", "Last Cost", false, ""));
            this.columns_Names_visible.Add("Arb_Des_Cat", new FRItemsTransf.ColumnDictinary("الاسم العربي لمجموعة الصنف", "CATEGORY Arabic Name", false, ""));
            this.columns_Names_visible.Add("Eng_Des_Cat", new FRItemsTransf.ColumnDictinary("الاسم الانجليزي لمجموعة الصنف", "CATEGORY English Name", false, ""));
            FrmSearch frm = new FrmSearch()
            {
                Tag = this.LangArEn
            };
            foreach (KeyValuePair<string, FRItemsTransf.ColumnDictinary> kvp in this.columns_Names_visible)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_Items";
            frm.TopMost = true;
            frm.ShowDialog();
            if (!(frm.SerachNo != ""))
            {
                this.txtItemNo.Text = "";
                this.txtItemName.Text = "";
            }
            else
            {
                this.txtItemNo.Text = frm.Serach_No;
                if (this.LangArEn != 0)
                {
                    this.txtItemName.Text = this.db.StockItem(frm.Serach_No).Eng_Des.ToString();
                }
                else
                {
                    this.txtItemName.Text = this.db.StockItem(frm.Serach_No).Arb_Des.ToString();
                }
            }
        }
        private void button_SrchLegNo_Click(object sender, EventArgs e)
        {
            this.columns_Names_visible.Clear();
            this.columns_Names_visible.Add("Mnd_No", new FRItemsTransf.ColumnDictinary("رقم المندوب", "Commissary No", true, ""));
            this.columns_Names_visible.Add("Arb_Des", new FRItemsTransf.ColumnDictinary("الاسم عربي", "Arabic Name", true, ""));
            this.columns_Names_visible.Add("Eng_Des", new FRItemsTransf.ColumnDictinary("الاسم الانجليزي", "English Name", true, ""));
            FrmSearch frm = new FrmSearch()
            {
                Tag = this.LangArEn
            };
            foreach (KeyValuePair<string, FRItemsTransf.ColumnDictinary> kvp in this.columns_Names_visible)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_Mndob";
            frm.TopMost = true;
            frm.ShowDialog();
            if (!(frm.SerachNo != ""))
            {
                this.txtLegNo.Text = "";
                this.txtLegName.Text = "";
            }
            else
            {
                TextBox str = this.txtLegNo;
                int mndID = this.db.StockMndob(frm.Serach_No).Mnd_ID;
                str.Text = mndID.ToString();
                if (this.LangArEn != 0)
                {
                    this.txtLegName.Text = this.db.StockMndob(frm.Serach_No).Eng_Des.ToString();
                }
                else
                {
                    this.txtLegName.Text = this.db.StockMndob(frm.Serach_No).Arb_Des.ToString();
                }
            }
        }
        private void button_SrchSuppNo_Click(object sender, EventArgs e)
        {
            this.columns_Names_visible.Clear();
            this.columns_Names_visible.Add("AccDef_No", new FRItemsTransf.ColumnDictinary("الرقم ", " No", true, ""));
            this.columns_Names_visible.Add("Arb_Des", new FRItemsTransf.ColumnDictinary("الاسم عربي", "Arabic Name", true, ""));
            this.columns_Names_visible.Add("Eng_Des", new FRItemsTransf.ColumnDictinary("الاسم الانجليزي", "English Name", true, ""));
            this.columns_Names_visible.Add("AccDef_ID", new FRItemsTransf.ColumnDictinary(" ", " ", false, ""));
            FrmSearch frm = new FrmSearch()
            {
                Tag = this.LangArEn
            };
            foreach (KeyValuePair<string, FRItemsTransf.ColumnDictinary> kvp in this.columns_Names_visible)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_AccDef_Suppliers";
            VarGeneral.AccTyp = 5;
            frm.TopMost = true;
            frm.ShowDialog();
            if (!(frm.SerachNo != ""))
            {
                this.txtSuppNo.Text = "";
                this.txtSuppName.Text = "";
            }
            else
            {
                this.txtSuppNo.Text = this.db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (this.LangArEn != 0)
                {
                    this.txtSuppName.Text = this.db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
                else
                {
                    this.txtSuppName.Text = this.db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
            }
        }
        private void button_SrchUsrNo_Click(object sender, EventArgs e)
        {
            this.columns_Names_visible.Clear();
            this.columns_Names_visible.Add("UsrNo", new FRItemsTransf.ColumnDictinary("رقم المستخدم", "User No", true, ""));
            this.columns_Names_visible.Add("UsrNamA", new FRItemsTransf.ColumnDictinary("الاسم عربي", "Arabic Name", true, ""));
            this.columns_Names_visible.Add("UsrNamE", new FRItemsTransf.ColumnDictinary("الاسم الانجليزي", "English Name", true, ""));
            FrmSearch frm = new FrmSearch()
            {
                Tag = this.LangArEn
            };
            foreach (KeyValuePair<string, FRItemsTransf.ColumnDictinary> kvp in this.columns_Names_visible)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_User";
            frm.TopMost = true;
            frm.ShowDialog();
            if (!(frm.SerachNo != ""))
            {
                this.txtUserNo.Text = "";
                this.txtUserName.Text = "";
            }
            else
            {
                this.txtUserNo.Text = frm.Serach_No;
                if (this.LangArEn != 0)
                {
                    this.txtUserName.Text = this.dbc.StockUser(frm.Serach_No).UsrNamE.ToString();
                }
                else
                {
                    this.txtUserName.Text = this.dbc.StockUser(frm.Serach_No).UsrNamA.ToString();
                }
            }
        }
        protected override void Dispose(bool disposing)
        {
            if ((!disposing ? false : this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }
        public void FillCombo()
        {
            this.combobox_SortTyp.Items.Clear();
            this.combobox_SortTyp.Items.Add((this.LangArEn == 0 ? "رقم الفاتورة" : "Invoice No"));
            this.combobox_SortTyp.Items.Add((this.LangArEn == 0 ? "تاريخ الفاتورة" : "Invoice Date"));
            this.combobox_SortTyp.SelectedIndex = 0;
        }
        private void FillFlex()
        {
            this.checkBox_ItemComm.Checked = false;
            if (this.LangArEn != 0)
            {
                this.FlexType.Rows.Count = 3;
                this.FlexType.SetData(0, 0, true);
                this.FlexType.SetData(0, 1, "Cash");
                this.FlexType.SetData(1, 0, true);
                this.FlexType.SetData(1, 1, "Credit");
                this.FlexType.SetData(2, 0, true);
                this.FlexType.SetData(2, 1, "Network");
                if (VarGeneral.InvType == 1)
                {
                    this.Text = "Sales Invoice Report";
                }
                else if (VarGeneral.InvType == 2)
                {
                    this.Text = "Purchase Invoice Report";
                }
                else if (VarGeneral.InvType == 3)
                {
                    this.Text = "Sales Return Report";
                }
                else if (VarGeneral.InvType == 4)
                {
                    this.Text = "Purchase Return Report";
                }
                else if (VarGeneral.InvType == 5)
                {
                    this.Text = "Transfer In Report";
                    this.FlexType.Rows.Count = 1;
                    this.FlexType.SetData(0, 0, true);
                    this.FlexType.SetData(0, 1, "Receipt");
                }
                else if (VarGeneral.InvType == 6)
                {
                    this.Text = "Transfer Out Report";
                    this.FlexType.Rows.Count = 1;
                    this.FlexType.SetData(0, 0, true);
                    this.FlexType.SetData(0, 1, "Receipt");
                }
                else if (VarGeneral.InvType == 7)
                {
                    this.Text = "Customer Qutation Report";
                }
                else if (VarGeneral.InvType == 8)
                {
                    this.Text = "Supplier Qutation Report";
                }
                else if (VarGeneral.InvType == 9)
                {
                    this.Text = "Purchase Order Report";
                }
                else if (VarGeneral.InvType == 10)
                {
                    this.Text = "Stock Adjustment Report";
                    this.FlexType.Rows.Count = 1;
                    this.FlexType.SetData(0, 0, true);
                    this.FlexType.SetData(0, 1, "Receipt");
                }
                else if (VarGeneral.InvType == 14)
                {
                    this.Text = "Open Quantities Report";
                    this.FlexType.Rows.Count = 1;
                    this.FlexType.SetData(0, 0, true);
                    this.FlexType.SetData(0, 1, "Receipt");
                }
                else if (VarGeneral.InvType == 17)
                {
                    this.Text = "Payment Order Report";
                    this.FlexType.Rows.Count = 1;
                    this.FlexType.SetData(0, 0, true);
                    this.FlexType.SetData(0, 1, "Receipt");
                }
                else if (VarGeneral.InvType == 20)
                {
                    this.Text = "Payment Order Return Report";
                    this.FlexType.Rows.Count = 1;
                    this.FlexType.SetData(0, 0, true);
                    this.FlexType.SetData(0, 1, "Receipt");
                }
            }
            else
            {
                this.FlexType.Rows.Count = 3;
                this.FlexType.SetData(0, 0, true);
                this.FlexType.SetData(0, 1, "نقدي");
                this.FlexType.SetData(1, 0, true);
                this.FlexType.SetData(1, 1, "آجل");
                this.FlexType.SetData(2, 0, true);
                this.FlexType.SetData(2, 1, "الشبكة");
                if (VarGeneral.InvType == 1)
                {
                    this.Text = "تقرير حركة صنف في فاتورة مبيعات";
                }
                else if (VarGeneral.InvType == 2)
                {
                    this.Text = "تقرير حركة صنف في فاتورة فاتورة مشتريات";
                }
                else if (VarGeneral.InvType == 3)
                {
                    this.Text = "تقرير حركة صنف في مرتجع مبيعات";
                }
                else if (VarGeneral.InvType == 4)
                {
                    this.Text = "تقرير حركة صنف في فاتورة مرتجع مشتريات";
                }
                else if (VarGeneral.InvType == 5)
                {
                    this.Text = "تقرير حركة صنف في فاتورة إدخال بضاعة";
                    this.FlexType.Rows.Count = 1;
                    this.FlexType.SetData(0, 0, true);
                    this.FlexType.SetData(0, 1, "سند");
                }
                else if (VarGeneral.InvType == 6)
                {
                    this.Text = "تقرير حركة صنف في فاتورة إخراج بضاعة";
                    this.FlexType.Rows.Count = 1;
                    this.FlexType.SetData(0, 0, true);
                    this.FlexType.SetData(0, 1, "سند");
                }
                else if (VarGeneral.InvType == 7)
                {
                    this.Text = "تقرير حركة صنف في فاتورة عرض سعر للعملاء";
                }
                else if (VarGeneral.InvType == 8)
                {
                    this.Text = "تقرير حركة صنف في فاتورة عرض سعر للموردين";
                }
                else if (VarGeneral.InvType == 9)
                {
                    this.Text = "تقرير حركة صنف في فاتورة طلب شراء";
                }
                else if (VarGeneral.InvType == 10)
                {
                    this.Text = "تقرير حركة صنف في فاتورة تسوية البضاعة";
                    this.FlexType.Rows.Count = 1;
                    this.FlexType.SetData(0, 0, true);
                    this.FlexType.SetData(0, 1, "سند");
                }
                else if (VarGeneral.InvType == 14)
                {
                    this.Text = "تقرير حركة صنف في فاتورة بضاعة اول المدة";
                    this.FlexType.Rows.Count = 1;
                    this.FlexType.SetData(0, 0, true);
                    this.FlexType.SetData(0, 1, "سند");
                }
                else if (VarGeneral.InvType == 17)
                {
                    this.Text = "تقرير حركة صنف في فاتورة صرف بضاعة";
                    this.FlexType.Rows.Count = 1;
                    this.FlexType.SetData(0, 0, true);
                    this.FlexType.SetData(0, 1, "سند");
                }
                else if (VarGeneral.InvType == 20)
                {
                    this.Text = "تقرير حركة صنف في فاتورة مرتجع صرف بضاعة";
                    this.FlexType.Rows.Count = 1;
                    this.FlexType.SetData(0, 0, true);
                    this.FlexType.SetData(0, 1, "سند");
                }
            }
            this.RibunButtons();
            this.FillCombo();
            if (File.Exists(string.Concat(Application.StartupPath, "\\Script\\SecriptInvitationCards.dll")))
            {
                this.Script_InvitationCards();
            }
            if (File.Exists(string.Concat(Application.StartupPath, "\\Script\\SecriptSchool.dll")))
            {
                this.Script_School();
            }
            if (File.Exists(string.Concat(Application.StartupPath, "\\Script\\SecriptStons.dll")))
            {
                if (VarGeneral.InvType == 8)
                {
                    this.Text = (this.LangArEn == 0 ? "تقرير حركة صنف في فاتورة أمر تحميل" : "Order");
                }
            }
            if (File.Exists(string.Concat(Application.StartupPath, "\\Script\\SecriptTegnicalCollage.dll")))
            {
                if (VarGeneral.InvType == 17)
                {
                    this.Text = (this.LangArEn == 0 ? "تقرير حركة صنف في فاتورة إصدار عهدة" : "Report Movement Class in Bill Issue Custody");
                }
                else if (VarGeneral.InvType == 20)
                {
                    this.Text = (this.LangArEn == 0 ? "تقرير حركة صنف في فاتورة إرجاع عهدة" : "Report Movement Class in Bill Return Custody");
                }
            }
            if ((VarGeneral.gUserName != "runsetting" ? false : File.Exists(string.Concat(Application.StartupPath, "\\Script\\", VarGeneral.gServerName.Replace(string.Concat(Environment.MachineName, "\\"), "").Trim(), "\\khalijwatania.dll"))))
            {
                if (VarGeneral.InvType == 1)
                {
                    this.Text = (this.LangArEn == 0 ? "تقرير حركة صنف في فاتورة الخدمة" : "Service Invoice Report");
                }
            }
        }
        private void FRItemsTransf_Load(object sender, EventArgs e)
        {
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.KeyCode != Keys.F5 || !this.ButOk.Enabled ? true : !this.ButOk.Visible))
            {
                this.ButOk_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                base.Close();
            }
        }
        private void Frm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRItemsTransf));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.ButOk = new C1.Win.C1Input.C1Button();
            this.ButExit = new C1.Win.C1Input.C1Button();
            this.checkBox_Defalut = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBox_ItemComm = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBox_Note = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chkLine = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.RButShort = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.combobox_SortTyp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label11 = new System.Windows.Forms.Label();
            this.button_SrchItemGroup = new DevComponents.DotNetBar.ButtonX();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.txtClassNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button_SrchItemNo = new DevComponents.DotNetBar.ButtonX();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtItemNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_SrchUsrNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchLegNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchSuppNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchCustNo = new DevComponents.DotNetBar.ButtonX();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtUserNo = new System.Windows.Forms.TextBox();
            this.txtLegName = new System.Windows.Forms.TextBox();
            this.txtLegNo = new System.Windows.Forms.TextBox();
            this.txtSuppName = new System.Windows.Forms.TextBox();
            this.txtSuppNo = new System.Windows.Forms.TextBox();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.txtCustNo = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtMIntoNo = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMFromNo = new System.Windows.Forms.MaskedTextBox();
            this.groupBox_Date = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMToDate = new System.Windows.Forms.MaskedTextBox();
            this.txtMFromDate = new System.Windows.Forms.MaskedTextBox();
            this.FlexType = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label8 = new System.Windows.Forms.Label();
            this.button_SrchCostNo = new DevComponents.DotNetBar.ButtonX();
            this.txtCostNo = new System.Windows.Forms.TextBox();
            this.txtCostName = new System.Windows.Forms.TextBox();
            this.CmbDeleted = new System.Windows.Forms.GroupBox();
            this.radioButton_Del1 = new System.Windows.Forms.RadioButton();
            this.radioButton_Del2 = new System.Windows.Forms.RadioButton();
            this.radioButton_Del0 = new System.Windows.Forms.RadioButton();
            this.CmbReturn = new System.Windows.Forms.GroupBox();
            this.radioButton_ِReturn1 = new System.Windows.Forms.RadioButton();
            this.radioButton_ِReturn2 = new System.Windows.Forms.RadioButton();
            this.radioButton_ِReturn0 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RButLandscape = new System.Windows.Forms.RadioButton();
            this.RButPortrait = new System.Windows.Forms.RadioButton();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.VisibleChanged += new System.EventHandler(this.FRInvoice_VisibleChanged);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.PanelSpecialContainer.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButExit)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox_Date.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlexType)).BeginInit();
            this.CmbDeleted.SuspendLayout();
            this.CmbReturn.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelSpecialContainer
            // 
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar1);
            this.PanelSpecialContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSpecialContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelSpecialContainer.Name = "PanelSpecialContainer";
            this.PanelSpecialContainer.Size = new System.Drawing.Size(569, 427);
            this.PanelSpecialContainer.TabIndex = 1220;
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            this.ribbonBar1.BackColor = System.Drawing.Color.Gainsboro;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.Gainsboro;
            this.ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.Color.Gainsboro;
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.ButOk);
            this.ribbonBar1.Controls.Add(this.ButExit);
            this.ribbonBar1.Controls.Add(this.checkBox_Defalut);
            this.ribbonBar1.Controls.Add(this.checkBox_ItemComm);
            this.ribbonBar1.Controls.Add(this.checkBox_Note);
            this.ribbonBar1.Controls.Add(this.chkLine);
            this.ribbonBar1.Controls.Add(this.RButShort);
            this.ribbonBar1.Controls.Add(this.combobox_SortTyp);
            this.ribbonBar1.Controls.Add(this.label11);
            this.ribbonBar1.Controls.Add(this.button_SrchItemGroup);
            this.ribbonBar1.Controls.Add(this.txtClassName);
            this.ribbonBar1.Controls.Add(this.txtClassNo);
            this.ribbonBar1.Controls.Add(this.label10);
            this.ribbonBar1.Controls.Add(this.button_SrchItemNo);
            this.ribbonBar1.Controls.Add(this.txtItemName);
            this.ribbonBar1.Controls.Add(this.txtItemNo);
            this.ribbonBar1.Controls.Add(this.label9);
            this.ribbonBar1.Controls.Add(this.label7);
            this.ribbonBar1.Controls.Add(this.label6);
            this.ribbonBar1.Controls.Add(this.label5);
            this.ribbonBar1.Controls.Add(this.button_SrchUsrNo);
            this.ribbonBar1.Controls.Add(this.button_SrchLegNo);
            this.ribbonBar1.Controls.Add(this.button_SrchSuppNo);
            this.ribbonBar1.Controls.Add(this.button_SrchCustNo);
            this.ribbonBar1.Controls.Add(this.txtUserName);
            this.ribbonBar1.Controls.Add(this.txtUserNo);
            this.ribbonBar1.Controls.Add(this.txtLegName);
            this.ribbonBar1.Controls.Add(this.txtLegNo);
            this.ribbonBar1.Controls.Add(this.txtSuppName);
            this.ribbonBar1.Controls.Add(this.txtSuppNo);
            this.ribbonBar1.Controls.Add(this.txtCustName);
            this.ribbonBar1.Controls.Add(this.txtCustNo);
            this.ribbonBar1.Controls.Add(this.groupBox3);
            this.ribbonBar1.Controls.Add(this.groupBox_Date);
            this.ribbonBar1.Controls.Add(this.FlexType);
            this.ribbonBar1.Controls.Add(this.label8);
            this.ribbonBar1.Controls.Add(this.button_SrchCostNo);
            this.ribbonBar1.Controls.Add(this.txtCostNo);
            this.ribbonBar1.Controls.Add(this.txtCostName);
            this.ribbonBar1.Controls.Add(this.CmbDeleted);
            this.ribbonBar1.Controls.Add(this.CmbReturn);
            this.ribbonBar1.Controls.Add(this.groupBox2);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(569, 427);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 1105;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.Black;
            this.ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // ButOk
            // 
            this.ButOk.BackgroundImage = global::InvAcc.Properties.Resources.print;
            this.ButOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButOk.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButOk.Location = new System.Drawing.Point(401, 372);
            this.ButOk.Name = "ButOk";
            this.ButOk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButOk.Size = new System.Drawing.Size(152, 35);
            this.ButOk.TabIndex = 6748;
            this.ButOk.Text = "طباعه | Print";
            this.ButOk.UseVisualStyleBackColor = true;
            this.ButOk.Click += new System.EventHandler(this.ButOk_Click);
            this.ButOk.MouseLeave += new System.EventHandler(this.ButOk_MouseLeave);
            this.ButOk.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButOk_MouseMove);
            // 
            // ButExit
            // 
            this.ButExit.BackgroundImage = global::InvAcc.Properties.Resources.YALO2;
            this.ButExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButExit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButExit.Location = new System.Drawing.Point(286, 372);
            this.ButExit.Name = "ButExit";
            this.ButExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButExit.Size = new System.Drawing.Size(109, 35);
            this.ButExit.TabIndex = 6747;
            this.ButExit.Text = "خروج | ESC";
            this.ButExit.UseVisualStyleBackColor = true;
            this.ButExit.Click += new System.EventHandler(this.ButExit_Click);
            this.ButExit.MouseLeave += new System.EventHandler(this.ButExit_MouseLeave);
            this.ButExit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButExit_MouseMove);
            // 
            // checkBox_Defalut
            // 
            this.checkBox_Defalut.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            // 
            // 
            // 
            this.checkBox_Defalut.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_Defalut.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBox_Defalut.Checked = true;
            this.checkBox_Defalut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Defalut.CheckValue = "Y";
            this.checkBox_Defalut.Location = new System.Drawing.Point(172, 348);
            this.checkBox_Defalut.Name = "checkBox_Defalut";
            this.checkBox_Defalut.Size = new System.Drawing.Size(129, 20);
            this.checkBox_Defalut.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_Defalut.TabIndex = 6742;
            this.checkBox_Defalut.Text = "الإفتــــراضي";
            // 
            // checkBox_ItemComm
            // 
            this.checkBox_ItemComm.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            // 
            // 
            // 
            this.checkBox_ItemComm.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_ItemComm.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBox_ItemComm.Location = new System.Drawing.Point(172, 327);
            this.checkBox_ItemComm.Name = "checkBox_ItemComm";
            this.checkBox_ItemComm.Size = new System.Drawing.Size(129, 20);
            this.checkBox_ItemComm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_ItemComm.TabIndex = 6741;
            this.checkBox_ItemComm.Text = "إظهار عمـــولات الصنف";
            // 
            // checkBox_Note
            // 
            this.checkBox_Note.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            // 
            // 
            // 
            this.checkBox_Note.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_Note.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBox_Note.Location = new System.Drawing.Point(172, 306);
            this.checkBox_Note.Name = "checkBox_Note";
            this.checkBox_Note.Size = new System.Drawing.Size(129, 20);
            this.checkBox_Note.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_Note.TabIndex = 6740;
            this.checkBox_Note.Text = "إظهار عمود الملاحظات";
            // 
            // chkLine
            // 
            this.chkLine.AutoSize = true;
            this.chkLine.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chkLine.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkLine.Checked = true;
            this.chkLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLine.CheckValue = "Y";
            this.chkLine.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.chkLine.Location = new System.Drawing.Point(77, 392);
            this.chkLine.Name = "chkLine";
            this.chkLine.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkLine.Size = new System.Drawing.Size(62, 15);
            this.chkLine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkLine.TabIndex = 6725;
            this.chkLine.Text = "السطور";
            this.chkLine.Visible = false;
            // 
            // RButShort
            // 
            // 
            // 
            // 
            this.RButShort.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.RButShort.Location = new System.Drawing.Point(187, 372);
            this.RButShort.Name = "RButShort";
            this.RButShort.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.RButShort.OffText = "مختصــــر";
            this.RButShort.OffTextColor = System.Drawing.Color.White;
            this.RButShort.OnText = "مختصــــر";
            this.RButShort.Size = new System.Drawing.Size(93, 24);
            this.RButShort.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.RButShort.SwitchWidth = 25;
            this.RButShort.TabIndex = 6724;
            this.RButShort.ValueChanged += new System.EventHandler(this.RButShort_ValueChanged);
            // 
            // combobox_SortTyp
            // 
            this.combobox_SortTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combobox_SortTyp.DisplayMember = "Text";
            this.combobox_SortTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_SortTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_SortTyp.FormattingEnabled = true;
            this.combobox_SortTyp.ItemHeight = 14;
            this.combobox_SortTyp.Location = new System.Drawing.Point(7, 369);
            this.combobox_SortTyp.Name = "combobox_SortTyp";
            this.combobox_SortTyp.Size = new System.Drawing.Size(160, 20);
            this.combobox_SortTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combobox_SortTyp.TabIndex = 6722;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(483, 230);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 1143;
            this.label11.Text = "التصنيـــــــف :";
            // 
            // button_SrchItemGroup
            // 
            this.button_SrchItemGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchItemGroup.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchItemGroup.Location = new System.Drawing.Point(343, 227);
            this.button_SrchItemGroup.Name = "button_SrchItemGroup";
            this.button_SrchItemGroup.Size = new System.Drawing.Size(26, 20);
            this.button_SrchItemGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchItemGroup.Symbol = "";
            this.button_SrchItemGroup.SymbolSize = 12F;
            this.button_SrchItemGroup.TabIndex = 21;
            this.button_SrchItemGroup.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchItemGroup.Click += new System.EventHandler(this.button_SrchItemGroup_Click);
            // 
            // txtClassName
            // 
            this.txtClassName.BackColor = System.Drawing.Color.Ivory;
            this.txtClassName.ForeColor = System.Drawing.Color.White;
            this.txtClassName.Location = new System.Drawing.Point(7, 227);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtClassName, false);
            this.txtClassName.Size = new System.Drawing.Size(335, 20);
            this.txtClassName.TabIndex = 22;
            this.txtClassName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtClassNo
            // 
            this.txtClassNo.BackColor = System.Drawing.Color.White;
            this.txtClassNo.Location = new System.Drawing.Point(372, 227);
            this.txtClassNo.Name = "txtClassNo";
            this.txtClassNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtClassNo, false);
            this.txtClassNo.Size = new System.Drawing.Size(108, 20);
            this.txtClassNo.TabIndex = 20;
            this.txtClassNo.Tag = " T_CATEGORY.CAT_ID ";
            this.txtClassNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(483, 209);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 1142;
            this.label10.Text = "الصنــــــــــف :";
            // 
            // button_SrchItemNo
            // 
            this.button_SrchItemNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchItemNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchItemNo.Location = new System.Drawing.Point(343, 206);
            this.button_SrchItemNo.Name = "button_SrchItemNo";
            this.button_SrchItemNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchItemNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchItemNo.Symbol = "";
            this.button_SrchItemNo.SymbolSize = 12F;
            this.button_SrchItemNo.TabIndex = 18;
            this.button_SrchItemNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchItemNo.Click += new System.EventHandler(this.button_SrchItemNo_Click);
            // 
            // txtItemName
            // 
            this.txtItemName.BackColor = System.Drawing.Color.Ivory;
            this.txtItemName.ForeColor = System.Drawing.Color.White;
            this.txtItemName.Location = new System.Drawing.Point(7, 206);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtItemName, false);
            this.txtItemName.Size = new System.Drawing.Size(335, 20);
            this.txtItemName.TabIndex = 19;
            this.txtItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtItemNo
            // 
            this.txtItemNo.BackColor = System.Drawing.Color.White;
            this.txtItemNo.Location = new System.Drawing.Point(372, 206);
            this.txtItemNo.Name = "txtItemNo";
            this.txtItemNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtItemNo, false);
            this.txtItemNo.Size = new System.Drawing.Size(108, 20);
            this.txtItemNo.TabIndex = 17;
            this.txtItemNo.Tag = " T_Items.Itm_No ";
            this.txtItemNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(483, 188);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 1141;
            this.label9.Text = "المستخـــدم :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(483, 166);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 1140;
            this.label7.Text = "المنـــــــدوب :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(483, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 861;
            this.label6.Text = "المــــــــــورد :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(483, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 860;
            this.label5.Text = "العميـــــــــل :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button_SrchUsrNo
            // 
            this.button_SrchUsrNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchUsrNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchUsrNo.Location = new System.Drawing.Point(343, 185);
            this.button_SrchUsrNo.Name = "button_SrchUsrNo";
            this.button_SrchUsrNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchUsrNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchUsrNo.Symbol = "";
            this.button_SrchUsrNo.SymbolSize = 12F;
            this.button_SrchUsrNo.TabIndex = 15;
            this.button_SrchUsrNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchUsrNo.Click += new System.EventHandler(this.button_SrchUsrNo_Click);
            // 
            // button_SrchLegNo
            // 
            this.button_SrchLegNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchLegNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchLegNo.Location = new System.Drawing.Point(343, 163);
            this.button_SrchLegNo.Name = "button_SrchLegNo";
            this.button_SrchLegNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchLegNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchLegNo.Symbol = "";
            this.button_SrchLegNo.SymbolSize = 12F;
            this.button_SrchLegNo.TabIndex = 12;
            this.button_SrchLegNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchLegNo.Click += new System.EventHandler(this.button_SrchLegNo_Click);
            // 
            // button_SrchSuppNo
            // 
            this.button_SrchSuppNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchSuppNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchSuppNo.Location = new System.Drawing.Point(343, 142);
            this.button_SrchSuppNo.Name = "button_SrchSuppNo";
            this.button_SrchSuppNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchSuppNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchSuppNo.Symbol = "";
            this.button_SrchSuppNo.SymbolSize = 12F;
            this.button_SrchSuppNo.TabIndex = 9;
            this.button_SrchSuppNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchSuppNo.Click += new System.EventHandler(this.button_SrchSuppNo_Click);
            // 
            // button_SrchCustNo
            // 
            this.button_SrchCustNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchCustNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCustNo.Location = new System.Drawing.Point(343, 121);
            this.button_SrchCustNo.Name = "button_SrchCustNo";
            this.button_SrchCustNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchCustNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCustNo.Symbol = "";
            this.button_SrchCustNo.SymbolSize = 12F;
            this.button_SrchCustNo.TabIndex = 6;
            this.button_SrchCustNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCustNo.Click += new System.EventHandler(this.button_SrchCustNo_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.Ivory;
            this.txtUserName.ForeColor = System.Drawing.Color.White;
            this.txtUserName.Location = new System.Drawing.Point(7, 185);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtUserName, false);
            this.txtUserName.Size = new System.Drawing.Size(335, 20);
            this.txtUserName.TabIndex = 16;
            this.txtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUserNo
            // 
            this.txtUserNo.BackColor = System.Drawing.Color.White;
            this.txtUserNo.Location = new System.Drawing.Point(372, 185);
            this.txtUserNo.Name = "txtUserNo";
            this.txtUserNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtUserNo, false);
            this.txtUserNo.Size = new System.Drawing.Size(108, 20);
            this.txtUserNo.TabIndex = 14;
            this.txtUserNo.Tag = " T_INVHED.SalsManNo ";
            this.txtUserNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLegName
            // 
            this.txtLegName.BackColor = System.Drawing.Color.Ivory;
            this.txtLegName.ForeColor = System.Drawing.Color.White;
            this.txtLegName.Location = new System.Drawing.Point(7, 163);
            this.txtLegName.Name = "txtLegName";
            this.txtLegName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtLegName, false);
            this.txtLegName.Size = new System.Drawing.Size(335, 20);
            this.txtLegName.TabIndex = 13;
            this.txtLegName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLegNo
            // 
            this.txtLegNo.BackColor = System.Drawing.Color.White;
            this.txtLegNo.Location = new System.Drawing.Point(372, 163);
            this.txtLegNo.Name = "txtLegNo";
            this.txtLegNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtLegNo, false);
            this.txtLegNo.Size = new System.Drawing.Size(108, 20);
            this.txtLegNo.TabIndex = 11;
            this.txtLegNo.Tag = "T_INVHED.MndNo ";
            this.txtLegNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSuppName
            // 
            this.txtSuppName.BackColor = System.Drawing.Color.Ivory;
            this.txtSuppName.ForeColor = System.Drawing.Color.White;
            this.txtSuppName.Location = new System.Drawing.Point(7, 142);
            this.txtSuppName.Name = "txtSuppName";
            this.txtSuppName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtSuppName, false);
            this.txtSuppName.Size = new System.Drawing.Size(335, 20);
            this.txtSuppName.TabIndex = 10;
            this.txtSuppName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSuppNo
            // 
            this.txtSuppNo.BackColor = System.Drawing.Color.White;
            this.txtSuppNo.Location = new System.Drawing.Point(372, 142);
            this.txtSuppNo.Name = "txtSuppNo";
            this.txtSuppNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtSuppNo, false);
            this.txtSuppNo.Size = new System.Drawing.Size(108, 20);
            this.txtSuppNo.TabIndex = 8;
            this.txtSuppNo.Tag = " T_INVHED.CusVenNo ";
            this.txtSuppNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCustName
            // 
            this.txtCustName.BackColor = System.Drawing.Color.Ivory;
            this.txtCustName.ForeColor = System.Drawing.Color.White;
            this.txtCustName.Location = new System.Drawing.Point(7, 121);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtCustName, false);
            this.txtCustName.Size = new System.Drawing.Size(335, 20);
            this.txtCustName.TabIndex = 7;
            this.txtCustName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCustNo
            // 
            this.txtCustNo.BackColor = System.Drawing.Color.White;
            this.txtCustNo.Location = new System.Drawing.Point(372, 121);
            this.txtCustNo.Name = "txtCustNo";
            this.txtCustNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtCustNo, false);
            this.txtCustNo.Size = new System.Drawing.Size(108, 20);
            this.txtCustNo.TabIndex = 5;
            this.txtCustNo.Tag = " T_INVHED.CusVenNo ";
            this.txtCustNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.txtMIntoNo);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtMFromNo);
            this.groupBox3.Location = new System.Drawing.Point(7, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(557, 48);
            this.groupBox3.TabIndex = 1136;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "حسب رقم الفاتورة";
            // 
            // txtMIntoNo
            // 
            this.txtMIntoNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMIntoNo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtMIntoNo.Location = new System.Drawing.Point(53, 19);
            this.txtMIntoNo.Name = "txtMIntoNo";
            this.txtMIntoNo.Size = new System.Drawing.Size(122, 22);
            this.txtMIntoNo.TabIndex = 2;
            this.txtMIntoNo.Tag = " T_INVHED.InvNo ";
            this.txtMIntoNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMIntoNo.Click += new System.EventHandler(this.txtMIntoNo_Click);
            this.txtMIntoNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMIntoNo_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(463, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 857;
            this.label1.Text = "مـــــن :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(181, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 859;
            this.label2.Text = "إلـــــى :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMFromNo
            // 
            this.txtMFromNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMFromNo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtMFromNo.Location = new System.Drawing.Point(335, 19);
            this.txtMFromNo.Name = "txtMFromNo";
            this.txtMFromNo.Size = new System.Drawing.Size(122, 22);
            this.txtMFromNo.TabIndex = 1;
            this.txtMFromNo.Tag = " T_INVHED.InvNo ";
            this.txtMFromNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMFromNo.Click += new System.EventHandler(this.txtMFromNo_Click);
            this.txtMFromNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMFromNo_KeyPress);
            // 
            // groupBox_Date
            // 
            this.groupBox_Date.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_Date.Controls.Add(this.label3);
            this.groupBox_Date.Controls.Add(this.label4);
            this.groupBox_Date.Controls.Add(this.txtMToDate);
            this.groupBox_Date.Controls.Add(this.txtMFromDate);
            this.groupBox_Date.Location = new System.Drawing.Point(7, 67);
            this.groupBox_Date.Name = "groupBox_Date";
            this.groupBox_Date.Size = new System.Drawing.Size(557, 48);
            this.groupBox_Date.TabIndex = 1135;
            this.groupBox_Date.TabStop = false;
            this.groupBox_Date.Text = "حسب تاريخ الفاتورة";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(463, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 1141;
            this.label3.Text = "مـــــن :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(181, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 1140;
            this.label4.Text = "إلـــــى :";
            // 
            // txtMToDate
            // 
            this.txtMToDate.Location = new System.Drawing.Point(53, 19);
            this.txtMToDate.Mask = "0000/00/00";
            this.txtMToDate.Name = "txtMToDate";
            this.txtMToDate.Size = new System.Drawing.Size(122, 20);
            this.txtMToDate.TabIndex = 4;
            this.txtMToDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMToDate.Click += new System.EventHandler(this.txtMToDate_Click);
            this.txtMToDate.Leave += new System.EventHandler(this.txtMToDate_Leave);
            // 
            // txtMFromDate
            // 
            this.txtMFromDate.Location = new System.Drawing.Point(335, 19);
            this.txtMFromDate.Mask = "0000/00/00";
            this.txtMFromDate.Name = "txtMFromDate";
            this.txtMFromDate.Size = new System.Drawing.Size(122, 20);
            this.txtMFromDate.TabIndex = 3;
            this.txtMFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMFromDate.Click += new System.EventHandler(this.txtMFromDate_Click);
            this.txtMFromDate.Leave += new System.EventHandler(this.txtMFromDate_Leave);
            // 
            // FlexType
            // 
            this.FlexType.BackColor = System.Drawing.Color.White;
            this.FlexType.ColumnInfo = resources.GetString("FlexType.ColumnInfo");
            this.FlexType.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FlexType.Location = new System.Drawing.Point(7, 277);
            this.FlexType.Name = "FlexType";
            this.FlexType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FlexType.Rows.Count = 2;
            this.FlexType.Rows.DefaultSize = 19;
            this.FlexType.Rows.Fixed = 0;
            this.FlexType.Size = new System.Drawing.Size(160, 86);
            this.FlexType.StyleInfo = resources.GetString("FlexType.StyleInfo");
            this.FlexType.TabIndex = 35;
            this.FlexType.Tag = " T_INVHED.InvCashPay ";
            this.FlexType.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(483, 251);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 1137;
            this.label8.Text = "مركز التكلفة :";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // button_SrchCostNo
            // 
            this.button_SrchCostNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchCostNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCostNo.Location = new System.Drawing.Point(343, 248);
            this.button_SrchCostNo.Name = "button_SrchCostNo";
            this.button_SrchCostNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchCostNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCostNo.Symbol = "";
            this.button_SrchCostNo.SymbolSize = 12F;
            this.button_SrchCostNo.TabIndex = 24;
            this.button_SrchCostNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCostNo.Click += new System.EventHandler(this.button_SrchCostNo_Click);
            // 
            // txtCostNo
            // 
            this.txtCostNo.BackColor = System.Drawing.Color.White;
            this.txtCostNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtCostNo.Location = new System.Drawing.Point(372, 248);
            this.txtCostNo.MaxLength = 30;
            this.txtCostNo.Name = "txtCostNo";
            this.txtCostNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtCostNo, false);
            this.txtCostNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCostNo.Size = new System.Drawing.Size(108, 20);
            this.txtCostNo.TabIndex = 23;
            this.txtCostNo.Tag = "  T_INVHED.InvCstNo ";
            this.txtCostNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCostNo.TextChanged += new System.EventHandler(this.txtCostNo_TextChanged);
            // 
            // txtCostName
            // 
            this.txtCostName.BackColor = System.Drawing.Color.Ivory;
            this.txtCostName.ForeColor = System.Drawing.Color.White;
            this.txtCostName.Location = new System.Drawing.Point(7, 248);
            this.txtCostName.Name = "txtCostName";
            this.txtCostName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtCostName, false);
            this.txtCostName.Size = new System.Drawing.Size(335, 20);
            this.txtCostName.TabIndex = 25;
            this.txtCostName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCostName.TextChanged += new System.EventHandler(this.txtCostName_TextChanged);
            // 
            // CmbDeleted
            // 
            this.CmbDeleted.BackColor = System.Drawing.Color.Transparent;
            this.CmbDeleted.Controls.Add(this.radioButton_Del1);
            this.CmbDeleted.Controls.Add(this.radioButton_Del2);
            this.CmbDeleted.Controls.Add(this.radioButton_Del0);
            this.CmbDeleted.Location = new System.Drawing.Point(305, 267);
            this.CmbDeleted.Name = "CmbDeleted";
            this.CmbDeleted.Size = new System.Drawing.Size(257, 53);
            this.CmbDeleted.TabIndex = 1122;
            this.CmbDeleted.TabStop = false;
            this.CmbDeleted.Tag = " T_INVHED.IfDel ";
            // 
            // radioButton_Del1
            // 
            this.radioButton_Del1.AutoSize = true;
            this.radioButton_Del1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Del1.Location = new System.Drawing.Point(-163, 23);
            this.radioButton_Del1.Name = "radioButton_Del1";
            this.radioButton_Del1.Size = new System.Drawing.Size(54, 17);
            this.radioButton_Del1.TabIndex = 28;
            this.radioButton_Del1.Text = "الكـــل";
            this.radioButton_Del1.UseVisualStyleBackColor = true;
            this.radioButton_Del1.Visible = false;
            // 
            // radioButton_Del2
            // 
            this.radioButton_Del2.AutoSize = true;
            this.radioButton_Del2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Del2.Location = new System.Drawing.Point(68, 23);
            this.radioButton_Del2.Name = "radioButton_Del2";
            this.radioButton_Del2.Size = new System.Drawing.Size(89, 17);
            this.radioButton_Del2.TabIndex = 27;
            this.radioButton_Del2.Text = "المحذوفة فقط";
            this.radioButton_Del2.UseVisualStyleBackColor = true;
            // 
            // radioButton_Del0
            // 
            this.radioButton_Del0.AutoSize = true;
            this.radioButton_Del0.Checked = true;
            this.radioButton_Del0.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Del0.Location = new System.Drawing.Point(166, 23);
            this.radioButton_Del0.Name = "radioButton_Del0";
            this.radioButton_Del0.Size = new System.Drawing.Size(84, 17);
            this.radioButton_Del0.TabIndex = 26;
            this.radioButton_Del0.TabStop = true;
            this.radioButton_Del0.Text = "الغير محذوفة";
            this.radioButton_Del0.UseVisualStyleBackColor = true;
            // 
            // CmbReturn
            // 
            this.CmbReturn.BackColor = System.Drawing.Color.Transparent;
            this.CmbReturn.Controls.Add(this.radioButton_ِReturn1);
            this.CmbReturn.Controls.Add(this.radioButton_ِReturn2);
            this.CmbReturn.Controls.Add(this.radioButton_ِReturn0);
            this.CmbReturn.Location = new System.Drawing.Point(305, 316);
            this.CmbReturn.Name = "CmbReturn";
            this.CmbReturn.Size = new System.Drawing.Size(257, 53);
            this.CmbReturn.TabIndex = 1123;
            this.CmbReturn.TabStop = false;
            this.CmbReturn.Tag = " T_INVHED.IfRet ";
            // 
            // radioButton_ِReturn1
            // 
            this.radioButton_ِReturn1.AutoSize = true;
            this.radioButton_ِReturn1.Checked = true;
            this.radioButton_ِReturn1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_ِReturn1.Location = new System.Drawing.Point(5, 23);
            this.radioButton_ِReturn1.Name = "radioButton_ِReturn1";
            this.radioButton_ِReturn1.Size = new System.Drawing.Size(54, 17);
            this.radioButton_ِReturn1.TabIndex = 31;
            this.radioButton_ِReturn1.TabStop = true;
            this.radioButton_ِReturn1.Text = "الكـــل";
            this.radioButton_ِReturn1.UseVisualStyleBackColor = true;
            // 
            // radioButton_ِReturn2
            // 
            this.radioButton_ِReturn2.AutoSize = true;
            this.radioButton_ِReturn2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_ِReturn2.Location = new System.Drawing.Point(70, 23);
            this.radioButton_ِReturn2.Name = "radioButton_ِReturn2";
            this.radioButton_ِReturn2.Size = new System.Drawing.Size(87, 17);
            this.radioButton_ِReturn2.TabIndex = 30;
            this.radioButton_ِReturn2.Text = "المرتجعة فقط";
            this.radioButton_ِReturn2.UseVisualStyleBackColor = true;
            // 
            // radioButton_ِReturn0
            // 
            this.radioButton_ِReturn0.AutoSize = true;
            this.radioButton_ِReturn0.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_ِReturn0.Location = new System.Drawing.Point(168, 23);
            this.radioButton_ِReturn0.Name = "radioButton_ِReturn0";
            this.radioButton_ِReturn0.Size = new System.Drawing.Size(82, 17);
            this.radioButton_ِReturn0.TabIndex = 29;
            this.radioButton_ِReturn0.Text = "الغير مرتجعة";
            this.radioButton_ِReturn0.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.RButLandscape);
            this.groupBox2.Controls.Add(this.RButPortrait);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(171, 267);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(132, 37);
            this.groupBox2.TabIndex = 6723;
            this.groupBox2.TabStop = false;
            // 
            // RButLandscape
            // 
            this.RButLandscape.Checked = true;
            this.RButLandscape.Font = new System.Drawing.Font("Tahoma", 8F);
            this.RButLandscape.ForeColor = System.Drawing.Color.SteelBlue;
            this.RButLandscape.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RButLandscape.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RButLandscape.Location = new System.Drawing.Point(1, 14);
            this.RButLandscape.Name = "RButLandscape";
            this.RButLandscape.Size = new System.Drawing.Size(63, 19);
            this.RButLandscape.TabIndex = 1008;
            this.RButLandscape.TabStop = true;
            this.RButLandscape.Text = "عرضي                ";
            this.RButLandscape.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RButLandscape.UseVisualStyleBackColor = true;
            this.RButLandscape.CheckedChanged += new System.EventHandler(this.RButPortrait_CheckedChanged);
            // 
            // RButPortrait
            // 
            this.RButPortrait.Font = new System.Drawing.Font("Tahoma", 8F);
            this.RButPortrait.ForeColor = System.Drawing.Color.SteelBlue;
            this.RButPortrait.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RButPortrait.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RButPortrait.Location = new System.Drawing.Point(72, 14);
            this.RButPortrait.Name = "RButPortrait";
            this.RButPortrait.Size = new System.Drawing.Size(53, 19);
            this.RButPortrait.TabIndex = 1007;
            this.RButPortrait.Text = "طولي                 ";
            this.RButPortrait.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RButPortrait.UseVisualStyleBackColor = true;
            this.RButPortrait.CheckedChanged += new System.EventHandler(this.RButPortrait_CheckedChanged);
            // 
            // netResize1
            // 
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            // 
            // FRItemsTransf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 427);
            this.Controls.Add(this.PanelSpecialContainer);
            this.Icon = global::InvAcc.Properties.Resources.favicon;
            this.KeyPreview = true;
            this.Name = "FRItemsTransf";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FRItemsTransf_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.PanelSpecialContainer.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            this.ribbonBar1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButExit)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox_Date.ResumeLayout(false);
            this.groupBox_Date.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlexType)).EndInit();
            this.CmbDeleted.ResumeLayout(false);
            this.CmbDeleted.PerformLayout();
            this.CmbReturn.ResumeLayout(false);
            this.CmbReturn.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);
        }
        private void label22_Click(object sender, EventArgs e)
        {
        }
        private void label8_Click(object sender, EventArgs e)
        {
        }
        protected override void OnLoad(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRItemsTransf));
            if (!(VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == ""))
            {
                Language.ChangeLanguage("en", this, resources);
                this.LangArEn = 1;
                this.RButShort.OnText = "Brief";
                this.RButShort.OffText = "Brief";
            }
            else
            {
                Language.ChangeLanguage("ar-SA", this, resources);
                this.LangArEn = 0;
            }
            try
            {
                VarGeneral.itmDesIndex = 0;
                VarGeneral.itmDes = "";
                VarGeneral._DTFrom = "";
                VarGeneral._DTTo = "";
            }
            catch
            {
            }
            this.FillFlex();
            this.RButShort_ValueChanged(null, null);
            if (File.Exists(string.Concat(Application.StartupPath, "\\Script\\SecriptMaintenanceCars.dll")))
            {
                this.label7.Text = (this.LangArEn == 0 ? "نوع السيارة :" : "Car Type :");
            }
            if (File.Exists(string.Concat(Application.StartupPath, "\\Script\\SecriptBus.dll")))
            {
                this.label8.Text = (this.LangArEn == 0 ? "الباص :" : "Bus :");
                this.label7.Text = (this.LangArEn == 0 ? "السائق :" : "Driver :");
            }
            if (File.Exists(string.Concat(Application.StartupPath, "\\Script\\SecriptTegnicalCollage.dll")))
            {
                this.label5.Text = (this.LangArEn == 0 ? "الطـالـب :" : "Student Acc :");
                this.label7.Text = (this.LangArEn == 0 ? "الأستــاذ :" : "Teacher :");
                this.label8.Visible = false;
                this.txtCostNo.Visible = false;
                this.button_SrchCostNo.Visible = false;
                this.txtCostName.Visible = false;
                this.groupBox2.Visible = false;
                this.checkBox_Note.Visible = false;
                this.checkBox_ItemComm.Visible = false;
                this.checkBox_Defalut.Visible = false;
                this.RButShort.Visible = false;
                this.chkLine.Visible = false;
            }
            if (File.Exists(string.Concat(Application.StartupPath, "\\Script\\SecriptWaterPackages.dll")))
            {
                this.label5.Text = (this.LangArEn == 0 ? "الســــــائــق :" : "Driver Acc :");
                this.label7.Text = (this.LangArEn == 0 ? "العميــــــــل :" : "Customer :");
                this.label8.Text = (this.LangArEn == 0 ? "السيــارة :" : "Car :");
                if (VarGeneral.InvType == 7)
                {
                    this.Text = (this.LangArEn == 0 ? "تقرير فواتير عرض سعر السائقين" : "Drivers Qutation Reports");
                }
            }
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRItemsTransf));
            if (!(VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == ""))
            {
                Language.ChangeLanguage("en", this, resources);
                this.LangArEn = 1;
            }
            else
            {
                Language.ChangeLanguage("ar-SA", this, resources);
                this.LangArEn = 0;
            }
            this.FillFlex();
        }
        private void RButPortrait_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.RButPortrait.Checked)
            {
                this.checkBox_Note.Enabled = true;
                this.checkBox_ItemComm.Enabled = true;
            }
            else
            {
                this.checkBox_Note.Enabled = false;
                this.checkBox_ItemComm.Enabled = false;
            }
            this.checkBox_Defalut.Checked = true;
        }
        private void RButShort_ValueChanged(object sender, EventArgs e)
        {
            if (!this.RButShort.Value)
            {
                this.groupBox2.Enabled = true;
                this.chkLine.Visible = false;
                this.RButPortrait_CheckedChanged(sender, e);
            }
            else
            {
                this.groupBox2.Enabled = false;
                this.chkLine.Visible = true;
                this.checkBox_Note.Enabled = false;
                this.checkBox_Note.Checked = false;
                this.checkBox_ItemComm.Enabled = false;
                this.checkBox_ItemComm.Checked = false;
            }
        }
        private void RibunButtons()
        {
            if (this.LangArEn != 0)
            {
                this.ButExit.Text = "Exit Esc";
                this.ButOk.Text = (VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0" ? "Print F5" : "Show F5");
                this.groupBox3.Text = "Invoice No";
                this.groupBox_Date.Text = "Invoice Date";
                this.label1.Text = "From :";
                this.label2.Text = "To :";
                this.label3.Text = "From :";
                this.label4.Text = "To :";
                this.label5.Text = "Customer :";
                this.label6.Text = "Supplier :";
                this.label7.Text = "Delegate :";
                this.label8.Text = "Cost Center :";
                this.label9.Text = "User :";
                this.label10.Text = "Item :";
                this.label11.Text = "Category :";
                this.radioButton_Del0.Text = "Non-Deleted";
                this.radioButton_Del1.Text = "ALL";
                this.radioButton_Del2.Text = "Deleted Only";
                this.radioButton_ِReturn0.Text = "Non-Return";
                this.radioButton_ِReturn1.Text = "ALL";
                this.radioButton_ِReturn2.Text = "Return Only";
            }
            else
            {
                this.ButExit.Text = "خــــروج Esc";
                this.ButOk.Text = (VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0" ? "طبـــاعة F5" : "عــــرض F5");
                this.groupBox3.Text = "حسب رقم الفاتورة";
                this.groupBox_Date.Text = "حسب تاريخ الفاتورة";
                this.label1.Text = "مـــــن :";
                this.label2.Text = "إلـــــى :";
                this.label3.Text = "مـــــن :";
                this.label4.Text = "إلـــــى :";
                this.label5.Text = "العميـــــــــل :";
                this.label6.Text = "المــــــــــورد :";
                this.label7.Text = "المنـــــــدوب :";
                this.label8.Text = "مركز التكلفة :";
                this.label9.Text = "المستخـــدم :";
                this.label10.Text = "الصنــــــــــف :";
                this.label11.Text = "التصنيـــــــف :";
                this.radioButton_Del0.Text = "الغير محذوفة";
                this.radioButton_Del1.Text = "الكـــل";
                this.radioButton_Del2.Text = "المحذوفة فقط";
                this.radioButton_ِReturn0.Text = "الغير مرتجعة";
                this.radioButton_ِReturn1.Text = "الكـــل";
                this.radioButton_ِReturn2.Text = "المرتجعة فقط";
            }
        }
        private void Script_InvitationCards()
        {
            this.checkBox_Note.Visible = false;
            this.checkBox_ItemComm.Visible = false;
            this.checkBox_Defalut.Visible = false;
            this.label6.Text = (this.LangArEn == 0 ? "حساب المكان :" : "Place Account :");
            if (VarGeneral.InvType == 8)
            {
                this.Text = (this.LangArEn == 0 ? "تقرير حركة صنف في فاتورة إصدار الدعوات" : "Invitation Issuse Item Movement Report");
            }
        }
        private void Script_School()
        {
            this.checkBox_Note.Visible = false;
            this.checkBox_ItemComm.Visible = false;
            this.checkBox_Defalut.Visible = false;
            this.label5.Text = (this.LangArEn == 0 ? "الطـالـب :" : "Student Acc :");
            if (VarGeneral.InvType == 7)
            {
                this.Text = (this.LangArEn == 0 ? "تقرير حركة صنف في فاتورة عرض سعر الطلاب" : "Students Qutation Report");
            }
        }
        private void txtCostName_TextChanged(object sender, EventArgs e)
        {
        }
        private void txtCostNo_TextChanged(object sender, EventArgs e)
        {
        }
        private void txtMFromDate_Click(object sender, EventArgs e)
        {
            this.txtMFromDate.SelectAll();
        }
        private void txtMFromDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!VarGeneral.CheckDate(this.txtMFromDate.Text))
                {
                    this.txtMFromDate.Text = "";
                }
                else
                {
                    MaskedTextBox str = this.txtMFromDate;
                    DateTime dateTime = Convert.ToDateTime(this.txtMFromDate.Text);
                    str.Text = dateTime.ToString("yyyy/MM/dd");
                }
            }
            catch
            {
                this.txtMFromDate.Text = "";
            }
        }
        private void txtMFromNo_Click(object sender, EventArgs e)
        {
            this.txtMFromNo.SelectAll();
        }
        private void txtMFromNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        private void txtMIntoNo_Click(object sender, EventArgs e)
        {
            this.txtMIntoNo.SelectAll();
        }
        private void txtMIntoNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        private void txtMToDate_Click(object sender, EventArgs e)
        {
            this.txtMToDate.SelectAll();
        }
        private void txtMToDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!VarGeneral.CheckDate(this.txtMToDate.Text))
                {
                    this.txtMToDate.Text = "";
                }
                else
                {
                    MaskedTextBox str = this.txtMToDate;
                    DateTime dateTime = Convert.ToDateTime(this.txtMToDate.Text);
                    str.Text = dateTime.ToString("yyyy/MM/dd");
                }
            }
            catch
            {
                this.txtMToDate.Text = "";
            }
        }
        public class ColumnDictinary
        {
            public string AText = "";
            public string EText = "";
            public bool IfDefault = false;
            public string Format = "";
            public ColumnDictinary(string aText, string eText, bool ifDefault, string format)
            {
                this.AText = aText;
                this.EText = eText;
                this.IfDefault = ifDefault;
                this.Format = format;
            }
        }
        private void ButOk_MouseMove(object sender, MouseEventArgs e)
        {
            ButOk.BackgroundImage = Properties.Resources.howver;
            ButOk.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void ButExit_MouseMove(object sender, MouseEventArgs e)
        {
            ButExit.BackgroundImage = Properties.Resources.howver;
            ButExit.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void ButExit_MouseLeave(object sender, EventArgs e)
        {
            ButExit.BackgroundImage = Properties.Resources.YALO2;
            ButExit.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void ButOk_MouseLeave(object sender, EventArgs e)
        {
            ButOk.BackgroundImage = Properties.Resources.print;
            ButOk.BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}
