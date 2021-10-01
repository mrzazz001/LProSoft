using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Framework.Date;
using Framework.UI;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using Library.RepShow;
using Microsoft.Win32;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FRInvoiceMnd : Form
    { void avs(int arln)

{ 
  label10.Text=   (arln == 0 ? "  ترتيب حسب :  " : "  sort by :") ; checkBox_DatePay.Text=   (arln == 0 ? "  بتاريخ الاستحقاق  " : "  Due date") ; checkBox_Defalut.Text=   (arln == 0 ? "  الإفتــــراضي  " : "  default") ; checkBox_ItemComm.Text=   (arln == 0 ? "  إظهار عمـــولات الصنف  " : "  Show item commissions") ; checkBox_Note.Text=   (arln == 0 ? "  إظهار عمود الملاحظات  " : "  Show notes column") ; label9.Text=   (arln == 0 ? "  المستخـــدم :  " : "  User:") ; label7.Text=   (arln == 0 ? "  المنـــــــدوب :  " : "  Delegate:") ; label6.Text=   (arln == 0 ? "  المــــــــــورد :  " : "  Supplier:") ; label5.Text=   (arln == 0 ? "  العميـــــــــل :  " : "  Customer:") ; groupBox3.Text=   (arln == 0 ? "  حسب رقم الفاتورة  " : "  According to the invoice number") ; label1.Text=   (arln == 0 ? "  مـــــن :  " : "  from:") ; label2.Text=   (arln == 0 ? "  إلـــــى :  " : "  to:") ; groupBox_Date.Text=   (arln == 0 ? "  حسب تاريخ الفاتورة  " : "  According to the invoice date") ; label3.Text=   (arln == 0 ? "  مـــــن :  " : "  from:") ; label4.Text=   (arln == 0 ? "  إلـــــى :  " : "  to:") ; label8.Text=   (arln == 0 ? "  مركز التكلفة :  " : "  cost center:") ; radioButton_Del1.Text=   (arln == 0 ? "  الكـــل  " : "  the whole") ; radioButton_Del2.Text=   (arln == 0 ? "  المحذوفة فقط  " : "  only deleted") ; radioButton_Del0.Text=   (arln == 0 ? "  الغير محذوفة  " : "  not deleted") ; radioButton_ِReturn1.Text=   (arln == 0 ? "  الكـــل  " : "  the whole") ; radioButton_ِReturn2.Text=   (arln == 0 ? "  المرتجعة فقط  " : "  Returns only") ; radioButton_ِReturn0.Text=   (arln == 0 ? "  الغير مرتجعة  " : "  non-refundable") ;}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
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
        private Label label3;
        private Label label4;
        private MaskedTextBox txtMFromDate;
        private C1FlexGrid FlexType;
        private ComboBoxEx CmbInvType;
        private GroupBox CmbDeleted;
        private RadioButton radioButton_Del1;
        private RadioButton radioButton_Del2;
        private RadioButton radioButton_Del0;
        private GroupBox CmbReturn;
        private RadioButton radioButton_ِReturn1;
        private RadioButton radioButton_ِReturn2;
        private RadioButton radioButton_ِReturn0;
        private CheckBoxX checkBox_ItemComm;
        private CheckBoxX checkBox_Note;
        private CheckBoxX checkBox_Defalut;
        public TextBox txtUserName;
        public TextBox txtUserNo;
        public SwitchButton switchButton_CalclatTax;
        private CheckBox checkBox_DatePay;
        private Label label10;
        private ComboBoxEx combobox_SortTyp;
        private int LangArEn = 0;
        private T_User _User = new T_User();
        public Dictionary<string, FRInvoiceMnd.ColumnDictinary> columns_Names_visible = new Dictionary<string, FRInvoiceMnd.ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private int vType = 0;
        private C1.Win.C1Input.C1Button ButOk;
        private C1.Win.C1Input.C1Button ButExit;
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
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
        public FRInvoiceMnd(int vTp, int langNow)
        {
            this.InitializeComponent();this.Load += langloads;
            this._User = this.dbc.StockUser(VarGeneral.UserNumber);
            HijriGregDates dateFormatter = new HijriGregDates();
            if (VarGeneral.Settings_Sys.Calendr.Value != 0)
            {
                this.txtMFromDate.Text = dateFormatter.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                this.txtMToDate.Text = dateFormatter.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
            }
            else
            {
                this.txtMFromDate.Text = dateFormatter.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                this.txtMToDate.Text = dateFormatter.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
            }
            this.listInvSetting = (
                from t in this.db.T_INVSETTINGs
                where t.InvID == 1 || t.InvID == 2 || t.InvID == 3 || t.InvID == 4 || t.InvID == 5 || t.InvID == 6 || t.InvID == 7 || t.InvID == 8 || t.InvID == 9 || t.InvID == 10 || t.InvID == 14 || t.InvID == 17 || t.InvID == 20
                select t).ToList<T_INVSETTING>();
            this.CmbInvType.Items.Clear();
            if (langNow != 0)
            {
                this.CmbInvType.DataSource = this.listInvSetting;
                this.CmbInvType.DisplayMember = "InvNamE";
                this.CmbInvType.ValueMember = "InvID";
            }
            else
            {
                this.CmbInvType.DataSource = this.listInvSetting;
                this.CmbInvType.DisplayMember = "InvNamA";
                this.CmbInvType.ValueMember = "InvID";
            }
            this.vType = vTp;
            if (vTp != 0)
            {
                this.CmbInvType.SelectedValue = vTp;
            }
            else
            {
                this.CmbInvType.SelectedValue = 1;
            }
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
            string Rule = string.Concat("Where T_INVHED.MndNo != '' and T_INVHED.InvTyp = ", this.CmbInvType.SelectedValue.ToString());
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
            if ((!VarGeneral.CheckDate(this.txtMFromDate.Text) ? false : this.txtMFromDate.Text.Length == 10))
            {
                if (!this.checkBox_DatePay.Checked)
                {
                    Rule = (int.Parse(this.txtMFromDate.Text.Substring(0, 4)) >= 1800 ? string.Concat(Rule, " and  T_INVHED.GDat  >= '", dateFormatter.FormatGreg(this.txtMFromDate.Text, "yyyy/MM/dd"), "'") : string.Concat(Rule, " and  T_INVHED.HDat  >= '", dateFormatter.FormatHijri(this.txtMFromDate.Text, "yyyy/MM/dd"), "'"));
                }
                else
                {
                    Rule = string.Concat(Rule, " and  T_INVHED.EstDat  >= '", dateFormatter.FormatHijri(this.txtMFromDate.Text, "yyyy/MM/dd"), "'");
                }
            }
            if ((!VarGeneral.CheckDate(this.txtMToDate.Text) ? false : this.txtMToDate.Text.Length == 10))
            {
                if (!this.checkBox_DatePay.Checked)
                {
                    Rule = (int.Parse(this.txtMToDate.Text.Substring(0, 4)) >= 1800 ? string.Concat(Rule, " and  T_INVHED.GDat  <= '", dateFormatter.FormatGreg(this.txtMToDate.Text, "yyyy/MM/dd"), "'") : string.Concat(Rule, " and  T_INVHED.HDat  <= '", dateFormatter.FormatHijri(this.txtMToDate.Text, "yyyy/MM/dd"), "'"));
                }
                else
                {
                    Rule = string.Concat(Rule, " and  T_INVHED.EstDat  <= '", dateFormatter.FormatHijri(this.txtMToDate.Text, "yyyy/MM/dd"), "'");
                }
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
            string RuleInvType = string.Empty; int rc = FlexType.Rows.Count; if (rc == 3) rc--;
            for (iiCnt = 0; iiCnt < rc; iiCnt++)
            {
                if ((bool)this.FlexType.GetData(iiCnt, 0))
                {
                    if (!string.IsNullOrEmpty(RuleInvType))
                    {
                        RuleInvType = string.Concat(RuleInvType, " or ");
                    }
                    obj = RuleInvType;
                    tag = new object[] { obj, this.FlexType.Tag, "  = ", iiCnt };
                    RuleInvType = string.Concat(tag);
                }
            }
            if (FlexType.Rows.Count == 3)
                if ((bool)this.FlexType.GetData(2, 0))
                {
                    if (string.IsNullOrEmpty(RuleInvType))
                    {
                        obj = RuleInvType;
                        tag = new object[] { obj, this.FlexType.Tag, "  = ", iiCnt };
                        RuleInvType = string.Concat(tag);
                    }
                    obj = RuleInvType;
                    tag = new object[] { obj,  " or T_INVHED.InvCash = 'الشبكة' or T_INVHED.InvCash = 'شبكـــة' or T_INVHED.InvCash = '  شبكـــة  ' " };
                    RuleInvType = string.Concat(tag);
                }
            if (!string.IsNullOrEmpty(RuleInvType))
            {
                Rule = string.Concat(Rule, " and (", RuleInvType, ")");
            }
            if (VarGeneral.InvTyp == 21)
            {
                Rule = string.Concat(Rule, " and (PaymentOrderTyp = 0 and RoomNo != '' )");
            }
            if (this.checkBox_DatePay.Checked)
            {
                Rule = string.Concat(Rule, " and ( T_INVHED.EstDat != '' )");
            }
            return Rule;
        }
        private void ButExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            object[] text;
            double? amount;
            object obj;
            string str;
            double value;
            object obj1;
            object obj2;
            object obj3;
            try
            {
                VarGeneral.itmDes = string.Empty;
                RepShow _RepShow = new RepShow()
                {
                    Tables = " T_INVHED Left Join  T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  Left Join T_Curency On T_INVHED.CurTyp = T_Curency.Curency_ID Left Join T_CstTbl On T_INVHED.InvCstNo = T_CstTbl.Cst_ID Left Join T_Mndob on T_INVHED.MndNo = T_Mndob.Mnd_Id Left Join T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID"
                };
                string Fields = string.Empty;
                if (VarGeneral.InvTyp == 21)
                {
                    Fields = (this.LangArEn != 0 ? " T_INVHED.InvNo, T_INVSETTING.InvNamA as InvTypNm,T_INVHED.GDat,T_INVHED.HDat,T_INVHED.RoomNo as InvCash ,T_INVHED.RoomPerson as CostCenteNm, case when AdminLock = 0 then 'Approval' else 'Not Apporval' end as MndNm,(select Eng_Des from T_Waiter where waiter_ID = (select waiterNo from T_Rooms where ID = T_INVHED.RoomNo)) as GadeNo,T_INVHED.CusVenNo,T_INVHED.CusVenNm,T_INVHED.Remark,T_SYSSETTING.LogImg,T_SYSSETTING.Calendr ,T_INVHED.SalsManNo,((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints,'' as UsrNamA,''as UsrNamE" : " T_INVHED.InvNo, T_INVSETTING.InvNamA as InvTypNm,T_INVHED.GDat,T_INVHED.HDat,T_INVHED.RoomNo as InvCash ,T_INVHED.RoomPerson as CostCenteNm, case when AdminLock = 0 then 'معتمد' else 'غير معتمد' end as MndNm,(select Arb_Des from T_Waiter where waiter_ID = (select waiterNo from T_Rooms where ID = T_INVHED.RoomNo)) as GadeNo,T_INVHED.CusVenNo,T_INVHED.CusVenNm,T_INVHED.Remark,T_SYSSETTING.LogImg,T_SYSSETTING.Calendr ,T_INVHED.SalsManNo,((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints,'' as UsrNamA,''as UsrNamE");
                }
                else if (this.switchButton_CalclatTax.Value)
                {
                    if (this.LangArEn != 0)
                    {
                        text = new object[27];
                        text[0] = " T_INVHED.InvNo,T_INVSETTING.InvNamE as InvTypNm,T_INVHED.GDat,T_INVHED.HDat,T_INVHED.InvCash ,T_CstTbl.Eng_Des as CostCenteNm,T_Mndob.Eng_Des as MndNm,T_INVHED.CashPayLocCur,T_INVHED.NetworkPayLocCur,T_INVHED.CreditPayLocCur,T_INVHED.InvNetLocCur,case when T_INVHED.InvTyp =2 or T_INVHED.InvTyp =4 or T_INVHED.InvTyp = 9 or T_INVHED.InvTyp =14 then 0 else(Round(T_INVHED.InvCost,";
                        text[1] = (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                        text[2] = ")) end as  InvCost,case when T_INVHED.InvTyp =2 or T_INVHED.InvTyp =4 or T_INVHED.InvTyp = 9 or T_INVHED.InvTyp =14 then 0 else (Round(T_INVHED.InvNetLocCur - T_INVHED.InvCost,";
                        text[3] = (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                        text[4] = ")) end as InvProfit,";
                        object[] objArray = text;
                        if (this.checkBox_Note.Checked)
                        {
                            obj2 = " T_INVHED.Remark as GadeNo";
                        }
                        else
                        {
                            obj2 = (this.checkBox_DatePay.Checked ? " T_INVHED.EstDat as GadeNo " : " T_INVHED.GadeNo ");
                        }
                        objArray[5] = obj2;
                        text[6] = ",T_INVHED.CusVenNo,T_INVHED.CusVenNm,T_SYSSETTING.LogImg,T_SYSSETTING.Calendr ,T_INVHED.SalsManNo,((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints,'' as UsrNamA,''as UsrNamE,Round(case when T_INVHED.IsTaxUse = 1 and T_INVHED.InvAddTax > 0 then T_INVHED.InvAddTax else  0 end ,";
                        text[7] = (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                        text[8] = ") as TaxValue,'";
                        text[9] = this.label7.Text.Replace(":", string.Empty);
                        text[10] = "' as MndHeaderX,'";
                        text[11] = this.txtLegNo.Text;
                        text[12] = "' as MndNoX,'";
                        text[13] = this.txtLegName.Text;
                        text[14] = "' as MndNameX,'";
                        text[15] = this.label5.Text.Replace(":", string.Empty);
                        text[16] = "' as CustHeaderX,'";
                        text[17] = this.txtCustNo.Text;
                        text[18] = "' as CustNoX,'";
                        text[19] = this.txtCustName.Text;
                        text[20] = "' as CustNameX,'";
                        text[21] = this.label6.Text.Replace(":", string.Empty);
                        text[22] = "' as SuppHeaderX,'";
                        text[23] = this.txtSuppNo.Text;
                        text[24] = "' as SuppNoX,'";
                        text[25] = this.txtSuppName.Text;
                        text[26] = "' as SuppNameX";
                        Fields = string.Concat(text);
                    }
                    else
                    {
                        text = new object[27];
                        text[0] = " T_INVHED.InvNo,T_INVSETTING.InvNamA as InvTypNm,T_INVHED.GDat,T_INVHED.HDat,T_INVHED.InvCash ,T_CstTbl.Arb_Des as CostCenteNm,T_Mndob.Arb_Des as MndNm,T_INVHED.CashPayLocCur,T_INVHED.NetworkPayLocCur,T_INVHED.CreditPayLocCur,T_INVHED.InvNetLocCur,case when T_INVHED.InvTyp =2 or T_INVHED.InvTyp =4 or T_INVHED.InvTyp = 9 or T_INVHED.InvTyp =14 then 0 else (Round(T_INVHED.InvCost,";
                        text[1] = (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                        text[2] = ")) end as  InvCost,case when T_INVHED.InvTyp =2 or T_INVHED.InvTyp =4 or T_INVHED.InvTyp = 9 or T_INVHED.InvTyp =14 then 0 else (Round(T_INVHED.InvNetLocCur - T_INVHED.InvCost,";
                        text[3] = (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                        text[4] = ")) end as InvProfit,";
                        object[] objArray1 = text;
                        if (this.checkBox_Note.Checked)
                        {
                            obj3 = " T_INVHED.Remark as GadeNo";
                        }
                        else
                        {
                            obj3 = (this.checkBox_DatePay.Checked ? " T_INVHED.EstDat as GadeNo " : " T_INVHED.GadeNo ");
                        }
                        objArray1[5] = obj3;
                        text[6] = ",T_INVHED.CusVenNo,T_INVHED.CusVenNm,T_SYSSETTING.LogImg,T_SYSSETTING.Calendr ,T_INVHED.SalsManNo,((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints,'' as UsrNamA,''as UsrNamE,Round(case when T_INVHED.IsTaxUse = 1 and T_INVHED.InvAddTax > 0 then T_INVHED.InvAddTax else  0 end ,";
                        text[7] = (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                        text[8] = ") as TaxValue,'";
                        text[9] = this.label7.Text.Replace(":", string.Empty);
                        text[10] = "' as MndHeaderX,'";
                        text[11] = this.txtLegNo.Text;
                        text[12] = "' as MndNoX,'";
                        text[13] = this.txtLegName.Text;
                        text[14] = "' as MndNameX,'";
                        text[15] = this.label5.Text.Replace(":", string.Empty);
                        text[16] = "' as CustHeaderX,'";
                        text[17] = this.txtCustNo.Text;
                        text[18] = "' as CustNoX,'";
                        text[19] = this.txtCustName.Text;
                        text[20] = "' as CustNameX,'";
                        text[21] = this.label6.Text.Replace(":", string.Empty);
                        text[22] = "' as SuppHeaderX,'";
                        text[23] = this.txtSuppNo.Text;
                        text[24] = "' as SuppNoX,'";
                        text[25] = this.txtSuppName.Text;
                        text[26] = "' as SuppNameX";
                        Fields = string.Concat(text);
                    }
                }
                else if (this.LangArEn != 0)
                {
                    text = new object[27];
                    text[0] = " T_INVHED.InvNo,T_INVSETTING.InvNamE as InvTypNm,T_INVHED.GDat,T_INVHED.HDat,T_INVHED.InvCash ,T_CstTbl.Eng_Des as CostCenteNm,T_Mndob.Eng_Des as MndNm,T_INVHED.CashPayLocCur,T_INVHED.NetworkPayLocCur,T_INVHED.CreditPayLocCur,(case when T_INVHED.IsTaxUse = 1 then (T_INVHED.InvNetLocCur - T_INVHED.InvAddTax) else T_INVHED.InvNetLocCur end ) as InvNetLocCur,case when T_INVHED.InvTyp =2 or T_INVHED.InvTyp =4 or T_INVHED.InvTyp = 9 or T_INVHED.InvTyp =14 then 0 else (Round(T_INVHED.InvCost,";
                    text[1] = (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    text[2] = ")) end as  InvCost,case when T_INVHED.InvTyp =2 or T_INVHED.InvTyp =4 or T_INVHED.InvTyp = 9 or T_INVHED.InvTyp =14 then 0 else (Round((  (T_INVHED.InvNetLocCur ) - (case when T_INVHED.IsTaxUse = 1 then (case when T_INVHED.IsTaxByNet = 1 and T_INVHED.IsTaxLines = 0 then (T_INVHED.InvAddTaxlLoc) else ((select sum(Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmTax) from T_INVDET where T_INVDET.InvId = T_INVHED.InvHed_ID) / 100) end) else 0 end)) - T_INVHED.InvCost,";
                    text[3] = (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    text[4] = ")) end as InvProfit,";
                    object[] objArray2 = text;
                    if (this.checkBox_Note.Checked)
                    {
                        obj = " T_INVHED.Remark as GadeNo";
                    }
                    else
                    {
                        obj = (this.checkBox_DatePay.Checked ? " T_INVHED.EstDat as GadeNo " : " T_INVHED.GadeNo ");
                    }
                    objArray2[5] = obj;
                    text[6] = ",T_INVHED.CusVenNo,T_INVHED.CusVenNm,T_SYSSETTING.LogImg ,T_SYSSETTING.Calendr,T_INVHED.SalsManNo,((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints,'' as UsrNamA,''as UsrNamE,Round(case when T_INVHED.IsTaxUse = 1 and T_INVHED.InvAddTax > 0 then T_INVHED.InvAddTax else  0 end ,";
                    text[7] = (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    text[8] = ") as TaxValue,'";
                    text[9] = this.label7.Text.Replace(":", string.Empty);
                    text[10] = "' as MndHeaderX,'";
                    text[11] = this.txtLegNo.Text;
                    text[12] = "' as MndNoX,'";
                    text[13] = this.txtLegName.Text;
                    text[14] = "' as MndNameX,'";
                    text[15] = this.label5.Text.Replace(":", string.Empty);
                    text[16] = "' as CustHeaderX,'";
                    text[17] = this.txtCustNo.Text;
                    text[18] = "' as CustNoX,'";
                    text[19] = this.txtCustName.Text;
                    text[20] = "' as CustNameX,'";
                    text[21] = this.label6.Text.Replace(":", string.Empty);
                    text[22] = "' as SuppHeaderX,'";
                    text[23] = this.txtSuppNo.Text;
                    text[24] = "' as SuppNoX,'";
                    text[25] = this.txtSuppName.Text;
                    text[26] = "' as SuppNameX";
                    Fields = string.Concat(text);
                }
                else
                {
                    text = new object[27];
                    text[0] = " T_INVHED.InvNo,T_INVSETTING.InvNamA as InvTypNm,T_INVHED.GDat,T_INVHED.HDat,T_INVHED.InvCash ,T_CstTbl.Arb_Des as CostCenteNm,T_Mndob.Arb_Des as MndNm,T_INVHED.CashPayLocCur,T_INVHED.NetworkPayLocCur,T_INVHED.CreditPayLocCur,(case when T_INVHED.IsTaxUse = 1 then (T_INVHED.InvNetLocCur - T_INVHED.InvAddTax) else T_INVHED.InvNetLocCur end ) as InvNetLocCur,case when T_INVHED.InvTyp =2 or T_INVHED.InvTyp =4 or T_INVHED.InvTyp = 9 or T_INVHED.InvTyp =14 then 0 else (Round(T_INVHED.InvCost,";
                    text[1] = (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    text[2] = ")) end as  InvCost,case when T_INVHED.InvTyp =2 or T_INVHED.InvTyp =4 or T_INVHED.InvTyp = 9 or T_INVHED.InvTyp =14 then 0 else (Round((  (T_INVHED.InvNetLocCur ) - (case when T_INVHED.IsTaxUse = 1 then (case when T_INVHED.IsTaxByNet = 1 and T_INVHED.IsTaxLines = 0 then (T_INVHED.InvAddTaxlLoc) else ((select sum(Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmTax) from T_INVDET where T_INVDET.InvId = T_INVHED.InvHed_ID) / 100) end) else 0 end)) - T_INVHED.InvCost,";
                    text[3] = (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    text[4] = ")) end as InvProfit,";
                    object[] objArray3 = text;
                    if (this.checkBox_Note.Checked)
                    {
                        obj1 = " T_INVHED.Remark as GadeNo";
                    }
                    else
                    {
                        obj1 = (this.checkBox_DatePay.Checked ? " T_INVHED.EstDat as GadeNo " : " T_INVHED.GadeNo ");
                    }
                    objArray3[5] = obj1;
                    text[6] = ",T_INVHED.CusVenNo,T_INVHED.CusVenNm,T_SYSSETTING.LogImg ,T_SYSSETTING.Calendr,T_INVHED.SalsManNo,((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints,'' as UsrNamA,''as UsrNamE,Round(case when T_INVHED.IsTaxUse = 1 and T_INVHED.InvAddTax > 0 then T_INVHED.InvAddTax else  0 end ,";
                    text[7] = (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                    text[8] = ") as TaxValue,";
                    text[9] = this.label7.Text.Replace(":", string.Empty);
                    text[10] = "' as MndHeaderX,'";
                    text[11] = this.txtLegNo.Text;
                    text[12] = "' as MndNoX,'";
                    text[13] = this.txtLegName.Text;
                    text[14] = "' as MndNameX,'";
                    text[15] = this.label5.Text.Replace(":", string.Empty);
                    text[16] = "' as CustHeaderX,'";
                    text[17] = this.txtCustNo.Text;
                    text[18] = "' as CustNoX,'";
                    text[19] = this.txtCustName.Text;
                    text[20] = "' as CustNameX,'";
                    text[21] = this.label6.Text.Replace(":", string.Empty);
                    text[22] = "' as SuppHeaderX,'";
                    text[23] = this.txtSuppNo.Text;
                    text[24] = "' as SuppNoX,'";
                    text[25] = this.txtSuppName.Text;
                    text[26] = "' as SuppNameX";
                    Fields = string.Concat(text);
                }
                RepShow repShow = _RepShow;
                string str1 = this.BuildRuleList();
                if (this.combobox_SortTyp.SelectedIndex == 0)
                {
                    str = " order by T_INVHED.InvHed_ID";
                }
                else
                {
                    str = (this.combobox_SortTyp.SelectedIndex == 1 ? " order by T_INVHED.GDat,T_INVHED.InvHed_ID" : " order by T_INVHED.InvTyp,  CONVERT(INT, LEFT(T_INVHED.InvNo, PATINDEX('%[^0-9]%', T_INVHED.InvNo + 'z')-1))");
                }
                repShow.Rule = string.Concat(str1, str);
                _RepShow.Fields = Fields;
                try
                {
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
                if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                {
                    try
                    {
                        if (this.checkBox_ItemComm.Checked)
                        {
                            double _c = 0;
                            for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
                            {
                                try
                                {
                                    _c = 0;
                                    List<T_INVDET> q = (
                                        from er in this.db.T_INVDETs
                                        where er.InvNo == VarGeneral.RepData.Tables[0].Rows[i]["InvNo"].ToString()
                                        where er.T_INVHED.InvTyp == (int?)VarGeneral.InvType
                                        orderby er.InvNo
                                        select er).ToList<T_INVDET>();
                                    for (int c = 0; c < q.Count; c++)
                                    {
                                        try
                                        {
                                            int Comm_ = 0;
                                            try
                                            {
                                                Comm_ = int.Parse(VarGeneral.Settings_Sys.Seting.Substring(50, 1));
                                            }
                                            catch
                                            {
                                            }
                                            double num = _c;
                                            if (Comm_ == 0)
                                            {
                                                amount = q[c].Amount;
                                                double value1 = amount.Value;
                                                amount = q[c].T_Item.ItemComm;
                                                value = value1 * (amount.Value / 100);
                                            }
                                            else if (Comm_ == 1)
                                            {
                                                amount = q[c].T_Item.ItemComm;
                                                double num1 = amount.Value;
                                                amount = q[c].RealQty;
                                                value = num1 * Math.Abs(amount.Value);
                                            }
                                            else
                                            {
                                                amount = q[c].T_Item.ItemComm;
                                                value = amount.Value;
                                            }
                                            _c = num + value;
                                        }
                                        catch
                                        {
                                            // goto Label1;
                                        }
                                        //Label1:
                                    }
                                    VarGeneral.RepData.Tables[0].Rows[i]["GadeNo"] = _c;
                                }
                                catch
                                {
                                    //goto Label0;
                                }
                            }
                        }
                        FrmReportsViewer frm = new FrmReportsViewer()
                        {
                            Tag = this.LangArEn,
                            Repvalue = "InvoicesMnd"
                        };
                        VarGeneral.itmDesIndex = 1;
                        try
                        {
                            if (this.checkBox_Note.Checked)
                            {
                                VarGeneral.itmDes = "Note";
                            }
                        }
                        catch
                        {
                            VarGeneral.itmDes = string.Empty;
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
                            if (this.checkBox_DatePay.Checked)
                            {
                                VarGeneral.itmDes = "DatePay";
                            }
                        }
                        catch
                        {
                            VarGeneral.itmDes = string.Empty;
                        }
                        VarGeneral.vTitle = this.Text;
                        VarGeneral.Customerlbl = this.label5.Text.Replace(" :", string.Empty);
                        VarGeneral.Supplierlbl = this.label6.Text.Replace(" :", string.Empty);
                        VarGeneral.CostCenterlbl = this.label8.Text.Replace(" :", string.Empty);
                        VarGeneral.Mndoblbl = this.label7.Text.Replace(" :", string.Empty);
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
                VarGeneral.itmDes = string.Empty;
            }
            catch
            {
            }
        }
        private void button_SrchCostNo_Click(object sender, EventArgs e)
        {
            this.columns_Names_visible.Clear();
            this.columns_Names_visible.Add("Cst_No", new FRInvoiceMnd.ColumnDictinary("الرقم", "No", true, string.Empty));
            this.columns_Names_visible.Add("Arb_Des", new FRInvoiceMnd.ColumnDictinary("الاسم عربي", "Arabic Name", true, string.Empty));
            this.columns_Names_visible.Add("Eng_Des", new FRInvoiceMnd.ColumnDictinary("الاسم الانجليزي", "English Name", true, string.Empty));
            FrmSearch frm = new FrmSearch()
            {
                Tag = this.LangArEn
            };
            foreach (KeyValuePair<string, FRInvoiceMnd.ColumnDictinary> kvp in this.columns_Names_visible)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_CstTbl";
            frm.TopMost = true;
            frm.ShowDialog();
            if (!(frm.SerachNo != string.Empty))
            {
                this.txtCostNo.Text = string.Empty;
                this.txtCostName.Text = string.Empty;
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
            this.columns_Names_visible.Add("AccDef_No", new FRInvoiceMnd.ColumnDictinary("الرقم ", " No", true, string.Empty));
            this.columns_Names_visible.Add("Arb_Des", new FRInvoiceMnd.ColumnDictinary("الاسم عربي", "Arabic Name", true, string.Empty));
            this.columns_Names_visible.Add("Eng_Des", new FRInvoiceMnd.ColumnDictinary("الاسم الانجليزي", "English Name", true, string.Empty));
            this.columns_Names_visible.Add("AccDef_ID", new FRInvoiceMnd.ColumnDictinary(" ", " ", false, string.Empty));
            this.columns_Names_visible.Add("Mobile", new FRInvoiceMnd.ColumnDictinary("الجوال", "Mobile", false, string.Empty));
            this.columns_Names_visible.Add("TaxNo", new FRInvoiceMnd.ColumnDictinary("الرقم الضريبي", "Tax No", false, string.Empty));
            FrmSearch frm = new FrmSearch()
            {
                Tag = this.LangArEn
            };
            foreach (KeyValuePair<string, FRInvoiceMnd.ColumnDictinary> kvp in this.columns_Names_visible)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_AccDef2";
            VarGeneral.AccTyp = 4;
            frm.TopMost = true;
            frm.ShowDialog();
            if (!(frm.SerachNo != string.Empty))
            {
                this.txtCustNo.Text = string.Empty;
                this.txtCustName.Text = string.Empty;
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
        private void button_SrchLegNo_Click(object sender, EventArgs e)
        {
            this.columns_Names_visible.Clear();
            this.columns_Names_visible.Add("Mnd_No", new FRInvoiceMnd.ColumnDictinary("رقم المندوب", "Commissary No", true, string.Empty));
            this.columns_Names_visible.Add("Arb_Des", new FRInvoiceMnd.ColumnDictinary("الاسم عربي", "Arabic Name", true, string.Empty));
            this.columns_Names_visible.Add("Eng_Des", new FRInvoiceMnd.ColumnDictinary("الاسم الانجليزي", "English Name", true, string.Empty));
            FrmSearch frm = new FrmSearch()
            {
                Tag = this.LangArEn
            };
            foreach (KeyValuePair<string, FRInvoiceMnd.ColumnDictinary> kvp in this.columns_Names_visible)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_Mndob";
            frm.TopMost = true;
            frm.ShowDialog();
            if (!(frm.SerachNo != string.Empty))
            {
                this.txtLegNo.Text = string.Empty;
                this.txtLegName.Text = string.Empty;
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
            this.columns_Names_visible.Add("AccDef_No", new FRInvoiceMnd.ColumnDictinary("الرقم ", " No", true, string.Empty));
            this.columns_Names_visible.Add("Arb_Des", new FRInvoiceMnd.ColumnDictinary("الاسم عربي", "Arabic Name", true, string.Empty));
            this.columns_Names_visible.Add("Eng_Des", new FRInvoiceMnd.ColumnDictinary("الاسم الانجليزي", "English Name", true, string.Empty));
            this.columns_Names_visible.Add("AccDef_ID", new FRInvoiceMnd.ColumnDictinary(" ", " ", false, string.Empty));
            FrmSearch frm = new FrmSearch()
            {
                Tag = this.LangArEn
            };
            foreach (KeyValuePair<string, FRInvoiceMnd.ColumnDictinary> kvp in this.columns_Names_visible)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_AccDef_Suppliers";
            VarGeneral.AccTyp = 5;
            frm.TopMost = true;
            frm.ShowDialog();
            if (!(frm.SerachNo != string.Empty))
            {
                this.txtSuppNo.Text = string.Empty;
                this.txtSuppName.Text = string.Empty;
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
            this.columns_Names_visible.Add("UsrNo", new FRInvoiceMnd.ColumnDictinary("رقم المستخدم", "User No", true, string.Empty));
            this.columns_Names_visible.Add("UsrNamA", new FRInvoiceMnd.ColumnDictinary("الاسم عربي", "Arabic Name", true, string.Empty));
            this.columns_Names_visible.Add("UsrNamE", new FRInvoiceMnd.ColumnDictinary("الاسم الانجليزي", "English Name", true, string.Empty));
            FrmSearch frm = new FrmSearch()
            {
                Tag = this.LangArEn
            };
            foreach (KeyValuePair<string, FRInvoiceMnd.ColumnDictinary> kvp in this.columns_Names_visible)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_User";
            frm.TopMost = true;
            frm.ShowDialog();
            if (!(frm.SerachNo != string.Empty))
            {
                this.txtUserNo.Text = string.Empty;
                this.txtUserName.Text = string.Empty;
            }
            else
            {
                this.txtUserNo.Text = this.dbc.StockUser(frm.Serach_No).UsrNo;
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
        private void checkBox_DatePay_CheckedChanged(object sender, EventArgs e)
        {
            bool chksts = this.checkBox_DatePay.Checked;
            this.checkBox_Defalut.Checked = true;
            this.checkBox_DatePay.CheckedChanged -= new EventHandler(this.checkBox_DatePay_CheckedChanged);
            this.checkBox_DatePay.Checked = chksts;
            this.checkBox_DatePay.CheckedChanged += new EventHandler(this.checkBox_DatePay_CheckedChanged);
            if (!this.checkBox_DatePay.Checked)
            {
                this.groupBox_Date.Text = (this.LangArEn == 0 ? "حسب تاريخ الفاتورة" : "Date of inactivity");
            }
            else
            {
                this.groupBox_Date.Text = (this.LangArEn == 0 ? "حسب تاريخ الإستحقاق" : "Date of Pay");
            }
        }
        private void checkBox_Note_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox_DatePay.Checked)
            {
                this.checkBox_DatePay.CheckedChanged -= new EventHandler(this.checkBox_DatePay_CheckedChanged);
                this.checkBox_DatePay.Checked = false;
                this.checkBox_DatePay.CheckedChanged += new EventHandler(this.checkBox_DatePay_CheckedChanged);
                this.groupBox_Date.Text = (this.LangArEn == 0 ? "حسب تاريخ الفاتورة" : "Date of inactivity");
            }
        }
        private void CmbInvType_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                VarGeneral.InvTyp = int.Parse(this.CmbInvType.SelectedValue.ToString());
                VarGeneral.InvType = int.Parse(this.CmbInvType.SelectedValue.ToString());
                this.FillFlex();
            }
            catch
            {
            }
        }
        public void FillCombo()
        {
            this.combobox_SortTyp.Items.Clear();
            this.combobox_SortTyp.Items.Add((this.LangArEn == 0 ? "تسلسل الفواتير" : "Sequence"));
            this.combobox_SortTyp.Items.Add((this.LangArEn == 0 ? "تاريخ الفاتورة" : "Invoice Date"));
            this.combobox_SortTyp.Items.Add((this.LangArEn == 0 ? "رقــم الفاتورة" : "Invoice No"));
            this.combobox_SortTyp.SelectedIndex = 0;
        }
        private void FillFlex()
        {
            this.checkBox_DatePay.Checked = false;
            this.checkBox_DatePay.Enabled = false;
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
                    this.Text = "تقرير فاتورة مبيعات";
                    this.checkBox_DatePay.Enabled = true;
                }
                else if (VarGeneral.InvType == 2)
                {
                    this.Text = "تقرير فاتورة مشتريات";
                }
                else if (VarGeneral.InvType == 3)
                {
                    this.Text = "تقرير مرتجع مبيعات";
                }
                else if (VarGeneral.InvType == 4)
                {
                    this.Text = "تقرير مرتجع مشتريات";
                }
                else if (VarGeneral.InvType == 5)
                {
                    this.Text = "تقرير فاتورة إدخال بضاعة";
                    this.FlexType.Rows.Count = 1;
                    this.FlexType.SetData(0, 0, true);
                    this.FlexType.SetData(0, 1, "سند");
                }
                else if (VarGeneral.InvType == 6)
                {
                    this.Text = "تقرير فاتورة إخراج بضاعة";
                    this.FlexType.Rows.Count = 1;
                    this.FlexType.SetData(0, 0, true);
                    this.FlexType.SetData(0, 1, "سند");
                }
                else if (VarGeneral.InvType == 7)
                {
                    this.Text = "تقرير عرض سعر للعملاء";
                }
                else if (VarGeneral.InvType == 8)
                {
                    this.Text = "تقرير عرض سعر للموردين";
                }
                else if (VarGeneral.InvType == 9)
                {
                    this.Text = "تقرير طلب شراء";
                }
                else if (VarGeneral.InvType == 10)
                {
                    this.Text = "تقرير فاتورة تسوية البضاعة";
                    this.FlexType.Rows.Count = 1;
                    this.FlexType.SetData(0, 0, true);
                    this.FlexType.SetData(0, 1, "سند");
                }
                else if (VarGeneral.InvType == 14)
                {
                    this.Text = "تقرير بضاعة اول المدة";
                    this.FlexType.Rows.Count = 1;
                    this.FlexType.SetData(0, 0, true);
                    this.FlexType.SetData(0, 1, "سند");
                }
                else if (VarGeneral.InvType == 17)
                {
                    this.Text = "تقرير فاتورة صرف بضاعة";
                    this.FlexType.Rows.Count = 1;
                    this.FlexType.SetData(0, 0, true);
                    this.FlexType.SetData(0, 1, "سند");
                }
                else if (VarGeneral.InvType == 20)
                {
                    this.Text = "تقرير مرتجع صرف بضاعة";
                    this.FlexType.Rows.Count = 1;
                    this.FlexType.SetData(0, 0, true);
                    this.FlexType.SetData(0, 1, "سند");
                }
                else if (VarGeneral.InvType == 21)
                {
                    this.Text = "تقرير الطلبات المحلية";
                    this.FlexType.Rows.Count = 1;
                    this.FlexType.SetData(0, 0, true);
                    this.FlexType.SetData(0, 1, "سند");
                    this.FlexType.Visible = false;
                    this.CmbDeleted.Visible = false;
                    this.CmbReturn.Visible = false;
                    this.CmbInvType.Location = new Point(6, 144);
                    this.ButOk.Location = new Point(283, 180);
                    this.ButExit.Location = new Point(6, 180);
                    base.Height = 270;
                    this.label6.Visible = false;
                    this.label7.Visible = false;
                    this.label9.Visible = false;
                    this.label8.Visible = false;
                    this.txtSuppNo.Visible = false;
                    this.txtLegNo.Visible = false;
                    this.txtUserNo.Visible = false;
                    this.txtCostNo.Visible = false;
                    this.button_SrchSuppNo.Visible = false;
                    this.button_SrchLegNo.Visible = false;
                    this.button_SrchUsrNo.Visible = false;
                    this.button_SrchCostNo.Visible = false;
                    this.txtSuppName.Visible = false;
                    this.txtLegName.Visible = false;
                    this.txtUserName.Visible = false;
                    this.txtCostName.Visible = false;
                }
            }
            this.RibunButtons();
            if (this.vType > 0)
            {
                this.CmbInvType.Visible = false;
            }
            if (File.Exists(string.Concat(Application.StartupPath, "\\Script\\SecriptInvitationCards.dll")))
            {
                this.label6.Text = (this.LangArEn == 0 ? "حساب المكان :" : "Place Account :");
                if (VarGeneral.InvType == 8)
                {
                    this.Text = (this.LangArEn == 0 ? "تقرير إصدار الدعوات" : "Invitation Issuse");
                }
            }
            if (File.Exists(string.Concat(Application.StartupPath, "\\Script\\SecriptSchool.dll")))
            {
                this.label5.Text = (this.LangArEn == 0 ? "الطـالـب :" : "Student Acc :");
                if (VarGeneral.InvType == 7)
                {
                    this.Text = (this.LangArEn == 0 ? "تقرير عرض سعر للطلاب" : "Students Qutation Report");
                }
            }
            if (File.Exists(string.Concat(Application.StartupPath, "\\Script\\SecriptStons.dll")))
            {
                if (VarGeneral.InvType == 8)
                {
                    this.Text = (this.LangArEn == 0 ? "تقرير أمر تحميل" : "Order");
                }
            }
            if ((VarGeneral.gUserName != "runsetting" ? false : File.Exists(string.Concat(Application.StartupPath, "\\Script\\", VarGeneral.gServerName.Replace(string.Concat(Environment.MachineName, "\\"), string.Empty).Trim(), "\\khalijwatania.dll"))))
            {
                if (VarGeneral.InvType == 1)
                {
                    this.Text = (this.LangArEn == 0 ? "تقرير فاتورة الخدمة" : "Service Report");
                }
            }
        }
        private void FRInvoiceMnd_Load(object sender, EventArgs e)
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
        private void MaintenanceCars()
        {
            this.listInvSetting = (
                from t in this.db.T_INVSETTINGs
                where t.InvID == 1 || t.InvID == 2 || t.InvID == 3 || t.InvID == 4 || t.InvID == 7
                select t).ToList<T_INVSETTING>();
            try
            {
                this.CmbInvType.DataSource = null;
            }
            catch
            {
            }
            if (this.LangArEn != 0)
            {
                this.CmbInvType.DataSource = this.listInvSetting;
                this.CmbInvType.DisplayMember = "InvNamE";
                this.CmbInvType.ValueMember = "InvID";
            }
            else
            {
                this.CmbInvType.DataSource = this.listInvSetting;
                this.CmbInvType.DisplayMember = "InvNamA";
                this.CmbInvType.ValueMember = "InvID";
            }
            this.label7.Text = (this.LangArEn == 0 ? "نوع السيارة :" : "Car Type :");
        }
        protected override void OnLoad(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRInvoiceMnd));
            if (!(VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty))
            {
                Language.ChangeLanguage("en", this, resources);
                this.LangArEn = 1;
            }
            else
            {
                Language.ChangeLanguage("ar-SA", this, resources);
                this.LangArEn = 0;
            }
            try
            {
                VarGeneral.itmDesIndex = 0;
                VarGeneral.itmDes = string.Empty;
                VarGeneral._DTFrom = string.Empty;
                VarGeneral._DTTo = string.Empty;
            }
            catch
            {
            }
            this.FillFlex();
            this.FillCombo();
            if (File.Exists(string.Concat(Application.StartupPath, "\\Script\\SecriptInvitationCards.dll")))
            {
                this.Script_InvitationCards();
            }
            if (File.Exists(string.Concat(Application.StartupPath, "\\Script\\SecriptSchool.dll")))
            {
                this.Script_School();
            }
            if (File.Exists(string.Concat(Application.StartupPath, "\\Script\\SecriptMaintenanceCars.dll")))
            {
                this.MaintenanceCars();
            }
            if (File.Exists(string.Concat(Application.StartupPath, "\\Script\\SecriptBus.dll")))
            {
                this.label8.Text = (this.LangArEn == 0 ? "الباص :" : "Bus :");
                this.label7.Text = (this.LangArEn == 0 ? "السائق :" : "Driver :");
            }
            if (File.Exists(string.Concat(Application.StartupPath, "\\Script\\SecriptWaterPackages.dll")))
            {
                this.label5.Text = (this.LangArEn == 0 ? "الســــــائــق :" : "Driver Acc :");
                this.label7.Text = (this.LangArEn == 0 ? "العميــــــــل :" : "Customer :");
                this.label8.Text = (this.LangArEn == 0 ? "السيــارة :" : "Car :");
            }
             avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRInvoiceMnd));
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                Language.ChangeLanguage("ar-SA", this, resources);
                this.LangArEn = 0;
            }
            else if (VarGeneral.CurrentLang.ToString() == "1")
            {
                Language.ChangeLanguage("en", this, resources);
                this.LangArEn = 1;
            }
            this.FillFlex();
            this.FillCombo();
        }
        private void RibunButtons()
        {
            if (this.LangArEn != 0)
            {
                this.ButExit.Text = "Exit Esc";
                this.ButOk.Text = (VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0" ? "Print F5" : "Show F5");
                this.groupBox3.Text = "Quantity";
                this.groupBox_Date.Text = "Date of inactivity";
                this.label1.Text = "From :";
                this.label2.Text = "To :";
                this.label3.Text = "From :";
                this.label4.Text = "To :";
                this.label5.Text = "Customer :";
                this.label6.Text = "Supplier :";
                this.label7.Text = "Delegate :";
                this.label8.Text = "Cost Center :";
                this.label9.Text = "User :";
                this.switchButton_CalclatTax.OffText = "Calclate Net with tax";
                this.switchButton_CalclatTax.OnText = "Calclate Net with tax";
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
                this.radioButton_Del0.Text = "الغير محذوفة";
                this.radioButton_Del1.Text = "الكـــل";
                this.radioButton_Del2.Text = "المحذوفة فقط";
                this.radioButton_ِReturn0.Text = "الغير مرتجعة";
                this.radioButton_ِReturn1.Text = "الكـــل";
                this.radioButton_ِReturn2.Text = "المرتجعة فقط";
                this.switchButton_CalclatTax.OffText = "حساب الصافي بالضريبة";
                this.switchButton_CalclatTax.OnText = "حساب الصافي بالضريبة";
            }
        }
        private void Script_InvitationCards()
        {
            this.checkBox_Note.Visible = false;
            this.checkBox_ItemComm.Visible = false;
            this.checkBox_Defalut.Visible = false;
            this.listInvSetting = (
                from t in this.db.T_INVSETTINGs
                where t.InvID == 1 || t.InvID == 8
                select t).ToList<T_INVSETTING>();
            try
            {
                this.CmbInvType.DataSource = null;
            }
            catch
            {
            }
            if (this.LangArEn != 0)
            {
                this.CmbInvType.DataSource = this.listInvSetting;
                this.CmbInvType.DisplayMember = "InvNamE";
                this.CmbInvType.ValueMember = "InvID";
            }
            else
            {
                this.CmbInvType.DataSource = this.listInvSetting;
                this.CmbInvType.DisplayMember = "InvNamA";
                this.CmbInvType.ValueMember = "InvID";
            }
        }
        private void Script_School()
        {
            this.checkBox_Note.Visible = false;
            this.checkBox_ItemComm.Visible = false;
            this.checkBox_Defalut.Visible = false;
            this.listInvSetting = (
                from t in this.db.T_INVSETTINGs
                where t.InvID == 1 || t.InvID == 2 || t.InvID == 3 || t.InvID == 4 || t.InvID == 7 || t.InvID == 8 || t.InvID == 9 || t.InvID == 10 || t.InvID == 14
                select t).ToList<T_INVSETTING>();
            try
            {
                this.CmbInvType.DataSource = null;
            }
            catch
            {
            }
            if (this.LangArEn != 0)
            {
                this.CmbInvType.DataSource = this.listInvSetting;
                this.CmbInvType.DisplayMember = "InvNamE";
                this.CmbInvType.ValueMember = "InvID";
            }
            else
            {
                this.CmbInvType.DataSource = this.listInvSetting;
                this.CmbInvType.DisplayMember = "InvNamA";
                this.CmbInvType.ValueMember = "InvID";
            }
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
                    this.txtMFromDate.Text = string.Empty;
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
                this.txtMFromDate.Text = string.Empty;
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
                    this.txtMToDate.Text = string.Empty;
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
                this.txtMToDate.Text = string.Empty;
            }
        }
        public class ColumnDictinary
        {
            public string AText = string.Empty;
            public string EText = string.Empty;
            public bool IfDefault = false;
            public string Format = string.Empty;
            public ColumnDictinary(string aText, string eText, bool ifDefault, string format)
            {
                this.AText = aText;
                this.EText = eText;
                this.IfDefault = ifDefault;
                this.Format = format;
            }
        }
        private void ribbonBar1_ItemClick(object sender, EventArgs e)
        {
        }
    }
}
