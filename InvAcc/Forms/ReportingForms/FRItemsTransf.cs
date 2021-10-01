using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Framework.Date;
using Framework.UI;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
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
    public partial  class FRItemsTransf : Form
    { void avs(int arln)

{ 
  checkBox_Defalut.Text=   (arln == 0 ? "  الإفتــــراضي  " : "  default") ; checkBox_ItemComm.Text=   (arln == 0 ? "  إظهار عمـــولات الصنف  " : "  Show item commissions") ; checkBox_Note.Text=   (arln == 0 ? "  إظهار عمود الملاحظات  " : "  Show notes column") ; chkLine.Text=   (arln == 0 ? "  السطور  " : "  the lines") ; label11.Text=   (arln == 0 ? "  التصنيـــــــف :  " : "  Classification:") ; label10.Text=   (arln == 0 ? "  الصنــــــــــف :  " : "  Category:") ; label9.Text=   (arln == 0 ? "  المستخـــدم :  " : "  User:") ; label7.Text=   (arln == 0 ? "  المنـــــــدوب :  " : "  Delegate:") ; label6.Text=   (arln == 0 ? "  المــــــــــورد :  " : "  Supplier:") ; label5.Text=   (arln == 0 ? "  العميـــــــــل :  " : "  Customer:") ; groupBox3.Text=   (arln == 0 ? "  حسب رقم الفاتورة  " : "  According to the invoice number") ; label1.Text=   (arln == 0 ? "  مـــــن :  " : "  from:") ; label2.Text=   (arln == 0 ? "  إلـــــى :  " : "  to:") ; groupBox_Date.Text=   (arln == 0 ? "  حسب تاريخ الفاتورة  " : "  According to the invoice date") ; label3.Text=   (arln == 0 ? "  مـــــن :  " : "  from:") ; label4.Text=   (arln == 0 ? "  إلـــــى :  " : "  to:") ; label8.Text=   (arln == 0 ? "  مركز التكلفة :  " : "  cost center:") ; radioButton_Del1.Text=   (arln == 0 ? "  الكـــل  " : "  the whole") ; radioButton_Del2.Text=   (arln == 0 ? "  المحذوفة فقط  " : "  only deleted") ; radioButton_Del0.Text=   (arln == 0 ? "  الغير محذوفة  " : "  not deleted") ; radioButton_ِReturn1.Text=   (arln == 0 ? "  الكـــل  " : "  the whole") ; radioButton_ِReturn2.Text=   (arln == 0 ? "  المرتجعة فقط  " : "  Returns only") ; radioButton_ِReturn0.Text=   (arln == 0 ? "  الغير مرتجعة  " : "  non-refundable") ; RButLandscape.Text=   (arln == 0 ? "  عرضي                  " : "  accidental") ; RButPortrait.Text=   (arln == 0 ? "  طولي                   " : "  linear") ;}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
        private int LangArEn = 0;
        private T_User _User = new T_User();
        public Dictionary<string, FRItemsTransf.ColumnDictinary> columns_Names_visible = new Dictionary<string, FRItemsTransf.ColumnDictinary>();
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
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
            this.InitializeComponent();this.Load += langloads;
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
                    tag = new object[] { obj1, " or T_INVHED.InvCash = 'الشبكة' or T_INVHED.InvCash = 'شبكـــة' or T_INVHED.InvCash = '  شبكـــة  ' " };
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
                        TopMost = false;
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
             avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
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
