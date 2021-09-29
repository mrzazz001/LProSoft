using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Framework.Date;
using Framework.UI;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
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
    public partial class FRInvoiceMnd : Form
    {
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
            this.InitializeComponent();
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
                    tag = new object[] { obj, " or T_INVHED.InvCash = 'الشبكة' or T_INVHED.InvCash = 'شبكـــة' " };
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRInvoiceMnd));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            components = new System.ComponentModel.Container();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.ButOk = new C1.Win.C1Input.C1Button();
            this.ButExit = new C1.Win.C1Input.C1Button();
            this.label10 = new System.Windows.Forms.Label();
            this.combobox_SortTyp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.checkBox_DatePay = new System.Windows.Forms.CheckBox();
            this.switchButton_CalclatTax = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.checkBox_Defalut = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBox_ItemComm = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBox_Note = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.CmbInvType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
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
            this.txtMToDate = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMFromDate = new System.Windows.Forms.MaskedTextBox();
            this.FlexType = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.txtCostNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button_SrchCostNo = new DevComponents.DotNetBar.ButtonX();
            this.txtCostName = new System.Windows.Forms.TextBox();
            this.CmbDeleted = new System.Windows.Forms.GroupBox();
            this.radioButton_Del1 = new System.Windows.Forms.RadioButton();
            this.radioButton_Del2 = new System.Windows.Forms.RadioButton();
            this.radioButton_Del0 = new System.Windows.Forms.RadioButton();
            this.CmbReturn = new System.Windows.Forms.GroupBox();
            this.radioButton_ِReturn1 = new System.Windows.Forms.RadioButton();
            this.radioButton_ِReturn2 = new System.Windows.Forms.RadioButton();
            this.radioButton_ِReturn0 = new System.Windows.Forms.RadioButton();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.VisibleChanged += new System.EventHandler(this.FRInvoice_VisibleChanged);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.ribbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButExit)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox_Date.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlexType)).BeginInit();
            this.CmbDeleted.SuspendLayout();
            this.CmbReturn.SuspendLayout();
            this.PanelSpecialContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSpecialContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelSpecialContainer.Name = "PanelSpecialContainer";
            this.PanelSpecialContainer.Size = new System.Drawing.Size(1278, 514);
            this.PanelSpecialContainer.TabIndex = 1220;
            this.Controls.Add(this.PanelSpecialContainer);
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
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
            this.ribbonBar1.Controls.Add(this.label10);
            this.ribbonBar1.Controls.Add(this.combobox_SortTyp);
            this.ribbonBar1.Controls.Add(this.checkBox_DatePay);
            this.ribbonBar1.Controls.Add(this.switchButton_CalclatTax);
            this.ribbonBar1.Controls.Add(this.checkBox_Defalut);
            this.ribbonBar1.Controls.Add(this.checkBox_ItemComm);
            this.ribbonBar1.Controls.Add(this.checkBox_Note);
            this.ribbonBar1.Controls.Add(this.CmbInvType);
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
            this.ribbonBar1.Controls.Add(this.txtCostNo);
            this.ribbonBar1.Controls.Add(this.label8);
            this.ribbonBar1.Controls.Add(this.button_SrchCostNo);
            this.ribbonBar1.Controls.Add(this.txtCostName);
            this.ribbonBar1.Controls.Add(this.CmbDeleted);
            this.ribbonBar1.Controls.Add(this.CmbReturn);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(562, 448);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 1099;
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
            this.ribbonBar1.ItemClick += new System.EventHandler(this.ribbonBar1_ItemClick);
            // 
            // ButOk
            // 
            this.ButOk.BackgroundImage = global::InvAcc.Properties.Resources.print;
            this.ButOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButOk.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButOk.Location = new System.Drawing.Point(260, 400);
            this.ButOk.Name = "ButOk";
            this.ButOk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButOk.Size = new System.Drawing.Size(227, 29);
            this.ButOk.TabIndex = 6748;
            this.ButOk.Text = "طباعه | Print";
            this.ButOk.UseVisualStyleBackColor = true;
            this.ButOk.Click += new System.EventHandler(this.ButOk_Click);
            // 
            // ButExit
            // 
            this.ButExit.BackgroundImage = global::InvAcc.Properties.Resources.YALO2;
            this.ButExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButExit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButExit.Location = new System.Drawing.Point(75, 400);
            this.ButExit.Name = "ButExit";
            this.ButExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButExit.Size = new System.Drawing.Size(179, 29);
            this.ButExit.TabIndex = 6747;
            this.ButExit.Text = "خروج | ESC";
            this.ButExit.UseVisualStyleBackColor = true;
            this.ButExit.Click += new System.EventHandler(this.ButExit_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(486, 261);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 6745;
            this.label10.Text = "ترتيب حسب :";
            // 
            // combobox_SortTyp
            // 
            this.combobox_SortTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combobox_SortTyp.DisplayMember = "Text";
            this.combobox_SortTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_SortTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_SortTyp.Font = new System.Drawing.Font("Tahoma", 11F);
            this.combobox_SortTyp.FormattingEnabled = true;
            this.combobox_SortTyp.ItemHeight = 19;
            this.combobox_SortTyp.Location = new System.Drawing.Point(5, 255);
            this.combobox_SortTyp.Name = "combobox_SortTyp";
            this.combobox_SortTyp.Size = new System.Drawing.Size(475, 25);
            this.combobox_SortTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combobox_SortTyp.TabIndex = 6744;
            // 
            // checkBox_DatePay
            // 
            this.checkBox_DatePay.AutoSize = true;
            this.checkBox_DatePay.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBox_DatePay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkBox_DatePay.Location = new System.Drawing.Point(304, 364);
            this.checkBox_DatePay.Name = "checkBox_DatePay";
            this.checkBox_DatePay.Size = new System.Drawing.Size(90, 29);
            this.checkBox_DatePay.TabIndex = 6743;
            this.checkBox_DatePay.Text = "بتاريخ الاستحقاق";
            this.checkBox_DatePay.UseVisualStyleBackColor = true;
            this.checkBox_DatePay.CheckedChanged += new System.EventHandler(this.checkBox_DatePay_CheckedChanged);
            // 
            // switchButton_CalclatTax
            // 
            // 
            // 
            // 
            this.switchButton_CalclatTax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_CalclatTax.Location = new System.Drawing.Point(397, 362);
            this.switchButton_CalclatTax.Name = "switchButton_CalclatTax";
            this.switchButton_CalclatTax.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.switchButton_CalclatTax.OffText = "حساب الربح مع الضريبة";
            this.switchButton_CalclatTax.OffTextColor = System.Drawing.Color.White;
            this.switchButton_CalclatTax.OnText = "حساب الربح مع الضريبة";
            this.switchButton_CalclatTax.Size = new System.Drawing.Size(162, 35);
            this.switchButton_CalclatTax.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_CalclatTax.SwitchWidth = 25;
            this.switchButton_CalclatTax.TabIndex = 6742;
            this.switchButton_CalclatTax.Value = true;
            this.switchButton_CalclatTax.ValueObject = "Y";
            // 
            // checkBox_Defalut
            // 
            // 
            // 
            // 
            this.checkBox_Defalut.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_Defalut.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBox_Defalut.Checked = true;
            this.checkBox_Defalut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Defalut.CheckValue = "Y";
            this.checkBox_Defalut.Location = new System.Drawing.Point(169, 376);
            this.checkBox_Defalut.Name = "checkBox_Defalut";
            this.checkBox_Defalut.Size = new System.Drawing.Size(129, 20);
            this.checkBox_Defalut.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_Defalut.TabIndex = 6739;
            this.checkBox_Defalut.Text = "الإفتــــراضي";
            // 
            // checkBox_ItemComm
            // 
            // 
            // 
            // 
            this.checkBox_ItemComm.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_ItemComm.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBox_ItemComm.Location = new System.Drawing.Point(169, 350);
            this.checkBox_ItemComm.Name = "checkBox_ItemComm";
            this.checkBox_ItemComm.Size = new System.Drawing.Size(129, 20);
            this.checkBox_ItemComm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_ItemComm.TabIndex = 6738;
            this.checkBox_ItemComm.Text = "إظهار عمـــولات الصنف";
            this.checkBox_ItemComm.CheckedChanged += new System.EventHandler(this.checkBox_Note_CheckedChanged);
            // 
            // checkBox_Note
            // 
            // 
            // 
            // 
            this.checkBox_Note.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_Note.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBox_Note.Location = new System.Drawing.Point(169, 323);
            this.checkBox_Note.Name = "checkBox_Note";
            this.checkBox_Note.Size = new System.Drawing.Size(129, 20);
            this.checkBox_Note.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_Note.TabIndex = 6737;
            this.checkBox_Note.Text = "إظهار عمود الملاحظات";
            this.checkBox_Note.CheckedChanged += new System.EventHandler(this.checkBox_Note_CheckedChanged);
            // 
            // CmbInvType
            // 
            this.CmbInvType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbInvType.DisplayMember = "Text";
            this.CmbInvType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbInvType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbInvType.Font = new System.Drawing.Font("Tahoma", 13F);
            this.CmbInvType.FormattingEnabled = true;
            this.CmbInvType.ItemHeight = 22;
            this.CmbInvType.Location = new System.Drawing.Point(6, 285);
            this.CmbInvType.Name = "CmbInvType";
            this.CmbInvType.Size = new System.Drawing.Size(292, 28);
            this.CmbInvType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbInvType.TabIndex = 1175;
            this.CmbInvType.SelectedValueChanged += new System.EventHandler(this.CmbInvType_SelectedValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(486, 206);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 1174;
            this.label9.Text = "المستخـــدم :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(486, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 1173;
            this.label7.Text = "المنـــــــدوب :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(486, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 1172;
            this.label6.Text = "المــــــــــورد :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(486, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 1171;
            this.label5.Text = "العميـــــــــل :";
            // 
            // button_SrchUsrNo
            // 
            this.button_SrchUsrNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchUsrNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchUsrNo.Location = new System.Drawing.Point(373, 202);
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
            this.button_SrchLegNo.Location = new System.Drawing.Point(373, 173);
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
            this.button_SrchSuppNo.Location = new System.Drawing.Point(373, 144);
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
            this.button_SrchCustNo.Location = new System.Drawing.Point(373, 115);
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
            this.txtUserName.Location = new System.Drawing.Point(6, 202);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(364, 20);
            this.txtUserName.TabIndex = 16;
            this.txtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUserNo
            // 
            this.txtUserNo.BackColor = System.Drawing.Color.White;
            this.txtUserNo.Location = new System.Drawing.Point(401, 203);
            this.txtUserNo.Name = "txtUserNo";
            this.txtUserNo.ReadOnly = true;
            this.txtUserNo.Size = new System.Drawing.Size(79, 20);
            this.txtUserNo.TabIndex = 14;
            this.txtUserNo.Tag = " T_INVHED.SalsManNo ";
            this.txtUserNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLegName
            // 
            this.txtLegName.BackColor = System.Drawing.Color.Ivory;
            this.txtLegName.ForeColor = System.Drawing.Color.White;
            this.txtLegName.Location = new System.Drawing.Point(6, 173);
            this.txtLegName.Name = "txtLegName";
            this.txtLegName.ReadOnly = true;
            this.txtLegName.Size = new System.Drawing.Size(364, 20);
            this.txtLegName.TabIndex = 13;
            this.txtLegName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLegNo
            // 
            this.txtLegNo.BackColor = System.Drawing.Color.White;
            this.txtLegNo.Location = new System.Drawing.Point(401, 173);
            this.txtLegNo.Name = "txtLegNo";
            this.txtLegNo.ReadOnly = true;
            this.txtLegNo.Size = new System.Drawing.Size(79, 20);
            this.txtLegNo.TabIndex = 11;
            this.txtLegNo.Tag = "T_INVHED.MndNo ";
            this.txtLegNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSuppName
            // 
            this.txtSuppName.BackColor = System.Drawing.Color.Ivory;
            this.txtSuppName.ForeColor = System.Drawing.Color.White;
            this.txtSuppName.Location = new System.Drawing.Point(6, 144);
            this.txtSuppName.Name = "txtSuppName";
            this.txtSuppName.ReadOnly = true;
            this.txtSuppName.Size = new System.Drawing.Size(364, 20);
            this.txtSuppName.TabIndex = 10;
            this.txtSuppName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSuppNo
            // 
            this.txtSuppNo.BackColor = System.Drawing.Color.White;
            this.txtSuppNo.Location = new System.Drawing.Point(401, 144);
            this.txtSuppNo.Name = "txtSuppNo";
            this.txtSuppNo.ReadOnly = true;
            this.txtSuppNo.Size = new System.Drawing.Size(79, 20);
            this.txtSuppNo.TabIndex = 8;
            this.txtSuppNo.Tag = " T_INVHED.CusVenNo ";
            this.txtSuppNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCustName
            // 
            this.txtCustName.BackColor = System.Drawing.Color.Ivory;
            this.txtCustName.ForeColor = System.Drawing.Color.White;
            this.txtCustName.Location = new System.Drawing.Point(6, 115);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.ReadOnly = true;
            this.txtCustName.Size = new System.Drawing.Size(364, 20);
            this.txtCustName.TabIndex = 7;
            this.txtCustName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCustNo
            // 
            this.txtCustNo.BackColor = System.Drawing.Color.White;
            this.txtCustNo.Location = new System.Drawing.Point(401, 115);
            this.txtCustNo.Name = "txtCustNo";
            this.txtCustNo.ReadOnly = true;
            this.txtCustNo.Size = new System.Drawing.Size(79, 20);
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
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.groupBox3.Location = new System.Drawing.Point(3, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(554, 48);
            this.groupBox3.TabIndex = 1162;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "حسب رقم الفاتورة";
            // 
            // txtMIntoNo
            // 
            this.txtMIntoNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMIntoNo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtMIntoNo.Location = new System.Drawing.Point(55, 19);
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
            this.label1.Location = new System.Drawing.Point(447, 24);
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
            this.label2.Location = new System.Drawing.Point(183, 24);
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
            this.txtMFromNo.Location = new System.Drawing.Point(319, 19);
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
            this.groupBox_Date.Controls.Add(this.txtMToDate);
            this.groupBox_Date.Controls.Add(this.label3);
            this.groupBox_Date.Controls.Add(this.label4);
            this.groupBox_Date.Controls.Add(this.txtMFromDate);
            this.groupBox_Date.Location = new System.Drawing.Point(6, 59);
            this.groupBox_Date.Name = "groupBox_Date";
            this.groupBox_Date.Size = new System.Drawing.Size(554, 48);
            this.groupBox_Date.TabIndex = 1161;
            this.groupBox_Date.TabStop = false;
            this.groupBox_Date.Text = "حسب تاريخ الفاتورة";
            // 
            // txtMToDate
            // 
            this.txtMToDate.Location = new System.Drawing.Point(55, 19);
            this.txtMToDate.Mask = "0000/00/00";
            this.txtMToDate.Name = "txtMToDate";
            this.txtMToDate.Size = new System.Drawing.Size(122, 20);
            this.txtMToDate.TabIndex = 4;
            this.txtMToDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMToDate.Click += new System.EventHandler(this.txtMToDate_Click);
            this.txtMToDate.Leave += new System.EventHandler(this.txtMToDate_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(447, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 860;
            this.label3.Text = "مـــــن :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(183, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 861;
            this.label4.Text = "إلـــــى :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMFromDate
            // 
            this.txtMFromDate.Location = new System.Drawing.Point(319, 19);
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
            this.FlexType.Location = new System.Drawing.Point(5, 322);
            this.FlexType.Name = "FlexType";
            this.FlexType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FlexType.Rows.Count = 3;
            this.FlexType.Rows.DefaultSize = 19;
            this.FlexType.Rows.Fixed = 0;
            this.FlexType.Size = new System.Drawing.Size(159, 74);
            this.FlexType.StyleInfo = resources.GetString("FlexType.StyleInfo");
            this.FlexType.TabIndex = 28;
            this.FlexType.Tag = " T_INVHED.InvCashPay ";
            this.FlexType.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System;
            // 
            // txtCostNo
            // 
            this.txtCostNo.BackColor = System.Drawing.Color.White;
            this.txtCostNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtCostNo.Location = new System.Drawing.Point(401, 231);
            this.txtCostNo.MaxLength = 30;
            this.txtCostNo.Name = "txtCostNo";
            this.txtCostNo.ReadOnly = true;
            this.txtCostNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCostNo.Size = new System.Drawing.Size(79, 20);
            this.txtCostNo.TabIndex = 17;
            this.txtCostNo.Tag = "  T_INVHED.InvCstNo ";
            this.txtCostNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(486, 235);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 1170;
            this.label8.Text = "مركز التكلفة :";
            // 
            // button_SrchCostNo
            // 
            this.button_SrchCostNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchCostNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCostNo.Location = new System.Drawing.Point(373, 231);
            this.button_SrchCostNo.Name = "button_SrchCostNo";
            this.button_SrchCostNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchCostNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCostNo.Symbol = "";
            this.button_SrchCostNo.SymbolSize = 12F;
            this.button_SrchCostNo.TabIndex = 18;
            this.button_SrchCostNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCostNo.Click += new System.EventHandler(this.button_SrchCostNo_Click);
            // 
            // txtCostName
            // 
            this.txtCostName.BackColor = System.Drawing.Color.Ivory;
            this.txtCostName.ForeColor = System.Drawing.Color.White;
            this.txtCostName.Location = new System.Drawing.Point(6, 231);
            this.txtCostName.Name = "txtCostName";
            this.txtCostName.ReadOnly = true;
            this.txtCostName.Size = new System.Drawing.Size(364, 20);
            this.txtCostName.TabIndex = 19;
            this.txtCostName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CmbDeleted
            // 
            this.CmbDeleted.BackColor = System.Drawing.Color.Transparent;
            this.CmbDeleted.Controls.Add(this.radioButton_Del1);
            this.CmbDeleted.Controls.Add(this.radioButton_Del2);
            this.CmbDeleted.Controls.Add(this.radioButton_Del0);
            this.CmbDeleted.Location = new System.Drawing.Point(304, 278);
            this.CmbDeleted.Name = "CmbDeleted";
            this.CmbDeleted.Size = new System.Drawing.Size(254, 40);
            this.CmbDeleted.TabIndex = 6730;
            this.CmbDeleted.TabStop = false;
            this.CmbDeleted.Tag = " T_INVHED.IfDel ";
            // 
            // radioButton_Del1
            // 
            this.radioButton_Del1.AutoSize = true;
            this.radioButton_Del1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Del1.Location = new System.Drawing.Point(-60, 23);
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
            this.radioButton_Del2.Location = new System.Drawing.Point(66, 15);
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
            this.radioButton_Del0.Location = new System.Drawing.Point(166, 15);
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
            this.CmbReturn.Location = new System.Drawing.Point(302, 317);
            this.CmbReturn.Name = "CmbReturn";
            this.CmbReturn.Size = new System.Drawing.Size(257, 40);
            this.CmbReturn.TabIndex = 6731;
            this.CmbReturn.TabStop = false;
            this.CmbReturn.Tag = " T_INVHED.IfRet ";
            // 
            // radioButton_ِReturn1
            // 
            this.radioButton_ِReturn1.AutoSize = true;
            this.radioButton_ِReturn1.Checked = true;
            this.radioButton_ِReturn1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_ِReturn1.Location = new System.Drawing.Point(5, 14);
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
            this.radioButton_ِReturn2.Location = new System.Drawing.Point(70, 14);
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
            this.radioButton_ِReturn0.Location = new System.Drawing.Point(168, 14);
            this.radioButton_ِReturn0.Name = "radioButton_ِReturn0";
            this.radioButton_ِReturn0.Size = new System.Drawing.Size(82, 17);
            this.radioButton_ِReturn0.TabIndex = 29;
            this.radioButton_ِReturn0.Text = "الغير مرتجعة";
            this.radioButton_ِReturn0.UseVisualStyleBackColor = true;
            // 
            // FRInvoiceMnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(562, 448);
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = (InvAcc.Properties.Resources.favicon);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FRInvoiceMnd";
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FRInvoiceMnd_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
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
            this.Icon = (InvAcc.Properties.Resources.favicon);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.ResumeLayout(false);
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
