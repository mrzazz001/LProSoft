using DevComponents.DotNetBar;
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
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FRInvoiceGaid : Form
    { void avs(int arln)

{ 
  label9.Text=   (arln == 0 ? "  المستخـــدم :  " : "  User:") ; label7.Text=   (arln == 0 ? "  المنـــــــدوب :  " : "  Delegate:") ; label5.Text=   (arln == 0 ? "  العميـــــــــل :  " : "  Customer:") ; groupBox3.Text=   (arln == 0 ? "  حسب رقم الفاتورة  " : "  According to the invoice number") ; label1.Text=   (arln == 0 ? "  مـــــن :  " : "  from:") ; label2.Text=   (arln == 0 ? "  إلـــــى :  " : "  to:") ; groupBox_Date.Text=   (arln == 0 ? "  حسب تاريخ الفاتورة  " : "  According to the invoice date") ; label3.Text=   (arln == 0 ? "  مـــــن :  " : "  from:") ; label4.Text=   (arln == 0 ? "  إلـــــى :  " : "  to:") ; label8.Text=   (arln == 0 ? "  مركز التكلفة :  " : "  cost center:") ; radioButton_Del1.Text=   (arln == 0 ? "  الكـــل  " : "  the whole") ; radioButton_Del2.Text=   (arln == 0 ? "  المحذوفة فقط  " : "  only deleted") ; radioButton_Del0.Text=   (arln == 0 ? "  الغير محذوفة  " : "  not deleted") ; radioButton__0650Return1.Text=   (arln == 0 ? "  الكـــل  " : "  the whole") ; radioButton__0650Return2.Text=   (arln == 0 ? "  المرتجعة فقط  " : "  Returns only") ; radioButton__0650Return0.Text=   (arln == 0 ? "  الغير مرتجعة  " : "  non-refundable") ; RButLandscape.Text=   (arln == 0 ? "  عرضي  " : "  accidental") ; RButPortrait.Text=   (arln == 0 ? "  طولي  " : "  linear") ;}
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
        private int LangArEn = 0;
        private T_User _User = new T_User();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private int vType = 0;
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
       // private IContainer components = null;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData.ToString().Contains("Control") && !keyData.ToString().ToLower().Contains("delete") && keyData.ToString().Contains("Alt"))
            {
                try
                {
                    VarGeneral.Print_set_Gen_Stat = true;
                    FrmReportsViewer.IsSettingOnly = true;
                    VarGeneral.IsGeneralUsed = true;
                    {
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "InvoicesGaid";
                        frm.Repvalue = "InvoicesGaid";
                        //ADDADD
                        frm.Tag = LangArEn;
                        frm.ShowDialog();
                        VarGeneral.IsGeneralUsed = false;
                    }
                    FrmReportsViewer.IsSettingOnly = false;
                }
                catch
                {
                    VarGeneral.Print_set_Gen_Stat = false;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
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
        private Label label5;
        private Label label8;
        private ButtonX button_SrchUsrNo;
        private ButtonX button_SrchCostNo;
        private ButtonX button_SrchLegNo;
        private ButtonX button_SrchCustNo;
        private TextBox txtCostNo;
        private TextBox txtUserName;
        private TextBox txtUserNo;
        private TextBox txtLegName;
        private TextBox txtLegNo;
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
        private GroupBox CmbDeleted;
        private RadioButton radioButton_Del1;
        private RadioButton radioButton_Del2;
        private RadioButton radioButton_Del0;
        private GroupBox CmbReturn;
        private RadioButton radioButton__0650Return1;
        private RadioButton radioButton__0650Return2;
        private RadioButton radioButton__0650Return0;
        private GroupBox groupBox2;
        private RadioButton RButLandscape;
        private C1.Win.C1Input.C1Button ButOk;
        private C1.Win.C1Input.C1Button ButExit;
        private RadioButton RButPortrait;
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
        public FRInvoiceGaid(int vTp, int langNow)
        {
            InitializeComponent();this.Load += langloads;
            _User = dbc.StockUser(VarGeneral.UserNumber);
            HijriGregDates dateFormatter = new HijriGregDates();
            if (VarGeneral.Settings_Sys.Calendr.Value == 0)
            {
                txtMFromDate.Text = dateFormatter.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                txtMToDate.Text = dateFormatter.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
            }
            else
            {
                txtMFromDate.Text = dateFormatter.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                txtMToDate.Text = dateFormatter.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
            }
            vType = vTp;
            if (VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F" || VarGeneral.SSSLev == "S" || VarGeneral.SSSLev == "C")
            {
                label8.Visible = false;
                txtCostNo.Visible = false;
                button_SrchCostNo.Visible = false;
                txtCostName.Visible = false;
            }
            else
            {
                label8.Visible = true;
                txtCostNo.Visible = true;
                button_SrchCostNo.Visible = true;
                txtCostName.Visible = true;
            }
            try
            {
                if (VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F")
                {
                    RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
                    try
                    {
                        object q = hKey.GetValue("vCoCe");
                        if (string.IsNullOrEmpty(q.ToString()))
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
                    long regval = long.Parse(hKey.GetValue("vCoCe").ToString());
                    if (regval == 1)
                    {
                        label8.Visible = true;
                        txtCostNo.Visible = true;
                        button_SrchCostNo.Visible = true;
                        txtCostName.Visible = true;
                    }
                    else
                    {
                        label8.Visible = false;
                        txtCostNo.Visible = false;
                        button_SrchCostNo.Visible = false;
                        txtCostName.Visible = false;
                    }
                }
            }
            catch
            {
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptMaintenanceCars.dll"))
            {
                label7.Text = ((LangArEn == 0) ? "نوع السيارة :" : "Car Type :");
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRInvoiceGaid));
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
            FillFlex();
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptMaintenanceCars.dll"))
            {
                label7.Text = ((LangArEn == 0) ? "نوع السيارة :" : "Car Type :");
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptBus.dll"))
            {
                label8.Text = ((LangArEn == 0) ? "الباص :" : "Bus :");
                label7.Text = ((LangArEn == 0) ? "السائق :" : "Driver :");
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptWaterPackages.dll"))
            {
                label5.Text = ((LangArEn == 0) ? "الســــــائــق :" : "Driver Acc :");
                label7.Text = ((LangArEn == 0) ? "العميــــــــل :" : "Customer :");
                label8.Text = ((LangArEn == 0) ? "السيــارة :" : "Car :");
            }
             avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRInvoiceGaid));
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                Language.ChangeLanguage("ar-SA", this, resources);
                LangArEn = 0;
            }
            else if (VarGeneral.CurrentLang.ToString() == "1")
            {
                Language.ChangeLanguage("en", this, resources);
                LangArEn = 1;
            }
            FillFlex();
        }
        private void FillFlex()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                if (VarGeneral.InvType == 1)
                {
                    Text = "تقرير فاتورة مبيعات";
                }
                else if (VarGeneral.InvType == 2)
                {
                    Text = "تقرير فاتورة مشتريات";
                }
            }
            else if (VarGeneral.InvType == 1)
            {
                Text = "Sales Invoice Report";
            }
            else if (VarGeneral.InvType == 2)
            {
                Text = "Purchase Invoice Report";
            }
            RibunButtons();
        }
        private string BuildRuleList()
        {
            HijriGregDates dateFormatter = new HijriGregDates();
            string Rule = "Where T_INVHED.InvCashPay =1 and T_INVHED.CreditPay > 0 And T_GDHEAD.BName <> '' and T_INVHED.InvTyp = " + vType;
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
            if (!string.IsNullOrEmpty(txtCostNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtCostNo.Tag, " = ", txtCostNo.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtCustNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtCustNo.Tag, " = '", txtCustNo.Text.Trim(), "'");
            }
            if (!string.IsNullOrEmpty(txtLegNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtLegNo.Tag, " = ", txtLegNo.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtUserNo.Text))
            {
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptInv.dll") && VarGeneral.InvType == 1)
                {
                    Rule = Rule + " and  T_INVHED.UserNew  = '" + txtUserNo.Text.Trim() + "'";
                }
                else
                {
                    object obj = Rule;
                    Rule = string.Concat(obj, " and ", txtUserNo.Tag, " = '", txtUserNo.Text.Trim(), "'");
                }
            }
            if (VarGeneral.CheckDate(txtMFromDate.Text) && txtMFromDate.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMFromDate.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_INVHED.GDat  >= '" + dateFormatter.FormatGreg(txtMFromDate.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_INVHED.HDat  >= '" + dateFormatter.FormatHijri(txtMFromDate.Text, "yyyy/MM/dd") + "'"));
            }
            if (VarGeneral.CheckDate(txtMToDate.Text) && txtMToDate.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMToDate.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_INVHED.GDat  <= '" + dateFormatter.FormatGreg(txtMToDate.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_INVHED.HDat  <= '" + dateFormatter.FormatHijri(txtMToDate.Text, "yyyy/MM/dd") + "'"));
            }
            if (radioButton_Del0.Checked)
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", CmbDeleted.Tag, " != 1 ");
            }
            else if (radioButton_Del2.Checked)
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", CmbDeleted.Tag, " = 1 ");
            }
            if (radioButton__0650Return0.Checked)
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", CmbReturn.Tag, " != 1 ");
            }
            else if (radioButton__0650Return2.Checked)
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", CmbReturn.Tag, " = 1 ");
            }
            string RuleInvType = string.Empty;
            if (!string.IsNullOrEmpty(RuleInvType))
            {
                Rule = Rule + " and (" + RuleInvType + ")";
            }
            return Rule;
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            try
            {
                VarGeneral.itmDes = string.Empty;
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_INVHED Left Join   T_GDHEAD On T_INVHED.InvHed_ID = T_GDHEAD.BName Left Join  T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  Left Join  T_Curency On T_INVHED.CurTyp = T_Curency.Curency_ID Left Join  T_CstTbl On T_INVHED.InvCstNo = T_CstTbl.Cst_ID Left Join  T_Mndob on T_INVHED.MndNo = T_Mndob.Mnd_Id Left Join  T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                string Fields = string.Empty;
                string _GdInv = string.Empty;
                _GdInv = ((vType != 1) ? "(case when (select (select sum(ABS(T_GDDET.gdValue)) from T_GDDET where T_GDHEAD.gdhead_ID = T_GDDET.gdID and T_GDDET.gdValue < 0) from T_GDHEAD where T_GDHEAD.BName=T_INVHED.InvHed_ID and gdLok =0 and gdTyp =13) is null then 0 else (select (select sum(ABS(T_GDDET.gdValue)) from T_GDDET where T_GDHEAD.gdhead_ID = T_GDDET.gdID and T_GDDET.gdValue < 0) from T_GDHEAD where T_GDHEAD.BName=T_INVHED.InvHed_ID and gdLok =0 and gdTyp =13) end  )as Puyaid,(CreditPay - (case when (select (select sum(ABS(T_GDDET.gdValue)) from T_GDDET where T_GDHEAD.gdhead_ID = T_GDDET.gdID and T_GDDET.gdValue < 0) from T_GDHEAD where T_GDHEAD.BName=T_INVHED.InvHed_ID and gdLok =0 and gdTyp =13) is null then 0 else (select (select sum(ABS(T_GDDET.gdValue)) from T_GDDET where T_GDHEAD.gdhead_ID = T_GDDET.gdID and T_GDDET.gdValue < 0) from T_GDHEAD where T_GDHEAD.BName=T_INVHED.InvHed_ID and gdLok =0 and gdTyp =13) end)) as Remming,(select InvNamA from T_INVSETTING where T_INVSETTING.InvID = T_GDHEAD.gdTyp) as Mndob_Arb_Des,(select InvNamE from T_INVSETTING where T_INVSETTING.InvID = T_GDHEAD.gdTyp) as Mndob_Eng_Des" : "case when (select sum(gdTot) from T_GDHEAD where T_GDHEAD.BName=T_INVHED.InvHed_ID and gdLok =0 and gdTyp =12) is null then 0 else (select sum(gdTot) from T_GDHEAD where T_GDHEAD.BName=T_INVHED.InvHed_ID and gdLok =0 and gdTyp =12) end as Puyaid,(CreditPay - case when (select sum(gdTot) from T_GDHEAD where T_GDHEAD.BName=T_INVHED.InvHed_ID and gdLok =0 and gdTyp =12) is null then 0 else (select sum(gdTot) from T_GDHEAD where T_GDHEAD.BName=T_INVHED.InvHed_ID and gdLok =0 and gdTyp =12) end) as Remming,(select InvNamA from T_INVSETTING where T_INVSETTING.InvID = T_GDHEAD.gdTyp) as Mndob_Arb_Des,(select InvNamE from T_INVSETTING where T_INVSETTING.InvID = T_GDHEAD.gdTyp) as Mndob_Eng_Des");
                Fields = ((LangArEn != 0) ? (" distinct T_INVHED.InvNo,T_INVSETTING.InvNamE as InvTypNm,T_INVHED.GDat,T_INVHED.HDat,T_INVHED.InvCash ,T_CstTbl.Eng_Des as CostCenteNm,T_Mndob.Eng_Des as MndNm,T_INVHED.CashPayLocCur,T_INVHED.NetworkPayLocCur,T_INVHED.CreditPayLocCur,(case when T_INVHED.IsTaxUse = 1 then (T_INVHED.InvNetLocCur - T_INVHED.InvAddTax) else T_INVHED.InvNetLocCur end ) as InvNetLocCur,case when T_INVHED.InvTyp =2 or T_INVHED.InvTyp =4 or T_INVHED.InvTyp = 9 or T_INVHED.InvTyp =14 then 0 else (Round(T_INVHED.InvCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) end as  InvCost,case when T_INVHED.InvTyp =2 or T_INVHED.InvTyp =4 or T_INVHED.InvTyp = 9 or T_INVHED.InvTyp =14 then 0 else (Round(    (case when T_INVHED.IsTaxUse = 1 then (T_INVHED.InvNetLocCur - T_INVHED.InvAddTax) else T_INVHED.InvNetLocCur end ) - T_INVHED.InvCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) end as InvProfit,T_INVHED.GadeNo,T_INVHED.CusVenNo,T_INVHED.CusVenNm,T_INVHED.Remark,T_SYSSETTING.LogImg,T_SYSSETTING.Calendr,Round(case when T_INVHED.IsTaxUse = 1 and T_INVHED.InvAddTax > 0 then T_INVHED.InvAddTax else  0 end ," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as TaxValue, " + _GdInv) : (" distinct T_INVHED.InvNo, T_INVSETTING.InvNamA as InvTypNm,T_INVHED.GDat,T_INVHED.HDat,T_INVHED.InvCash ,T_CstTbl.Arb_Des as CostCenteNm, T_Mndob.Arb_Des as MndNm,T_INVHED.CashPayLocCur,T_INVHED.NetworkPayLocCur,T_INVHED.CreditPayLocCur,(case when T_INVHED.IsTaxUse = 1 then (T_INVHED.InvNetLocCur - T_INVHED.InvAddTax) else T_INVHED.InvNetLocCur end ) as InvNetLocCur,case when T_INVHED.InvTyp =2 or T_INVHED.InvTyp =4 or T_INVHED.InvTyp = 9 or T_INVHED.InvTyp =14 then 0 else (Round(T_INVHED.InvCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) end as  InvCost,case when T_INVHED.InvTyp =2 or T_INVHED.InvTyp =4 or T_INVHED.InvTyp = 9 or T_INVHED.InvTyp =14 then 0 else (Round(  (case when T_INVHED.IsTaxUse = 1 then (T_INVHED.InvNetLocCur - T_INVHED.InvAddTax) else T_INVHED.InvNetLocCur end ) - T_INVHED.InvCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) end as InvProfit, T_INVHED.GadeNo ,T_INVHED.CusVenNo,T_INVHED.CusVenNm,T_SYSSETTING.LogImg,T_SYSSETTING.Calendr ,Round(case when T_INVHED.IsTaxUse = 1 and T_INVHED.InvAddTax > 0 then T_INVHED.InvAddTax else  0 end ," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as TaxValue, " + _GdInv));
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
                if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "عفوا .. لا يوجد بيانات لعرضها في التقرير " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    try
                    {
                        VarGeneral.IsGeneralUsed = true;
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "InvoicesGaid";
                        frm.Tag = LangArEn;
                        frm.Repvalue = "InvoicesGaid";
                        if (RButPortrait.Checked)
                        {
                            VarGeneral.itmDesIndex = 0;
                        }
                        else
                        {
                            VarGeneral.itmDesIndex = 1;
                        }
                        VarGeneral.itmDes = vType.ToString();
                        VarGeneral.vTitle = Text;
                        frm.TopMost = true;
                        frm.ShowDialog();
                        VarGeneral.IsGeneralUsed = false;
                    }
                    catch (Exception error)
                    {
                        VarGeneral.DebLog.writeLog("button_ShowRep_Click:", error, enable: true);
                        MessageBox.Show(error.Message);
                    }
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
            VarGeneral.itemCommRep = false;
            try
            {
                VarGeneral.itmDesIndex = 0;
            }
            catch
            {
            }
        }
        private void ButExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button_SrchCustNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            columns_Names_visible.Add("TaxNo", new ColumnDictinary("الرقم الضريبي", "Tax No", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            if (vType == 1)
            {
                VarGeneral.SFrmTyp = "T_AccDef2";
                VarGeneral.AccTyp = 4;
            }
            else
            {
                VarGeneral.SFrmTyp = "T_AccDef_Suppliers";
                VarGeneral.AccTyp = 5;
            }
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                txtCustNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    txtCustName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    txtCustName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
            }
            else
            {
                txtCustNo.Text = string.Empty;
                txtCustName.Text = string.Empty;
            }
        }
        private void button_SrchLegNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("Mnd_No", new ColumnDictinary("رقم المندوب", "Commissary No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_Mndob";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                txtLegNo.Text = db.StockMndob(frm.Serach_No).Mnd_ID.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    txtLegName.Text = db.StockMndob(frm.Serach_No).Arb_Des.ToString();
                }
                else
                {
                    txtLegName.Text = db.StockMndob(frm.Serach_No).Eng_Des.ToString();
                }
            }
            else
            {
                txtLegNo.Text = string.Empty;
                txtLegName.Text = string.Empty;
            }
        }
        private void button_SrchCostNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("Cst_No", new ColumnDictinary("الرقم", "No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_CstTbl";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                txtCostNo.Text = db.StockCst(frm.Serach_No).Cst_ID.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    txtCostName.Text = db.StockCst(frm.Serach_No).Arb_Des.ToString();
                }
                else
                {
                    txtCostName.Text = db.StockCst(frm.Serach_No).Eng_Des.ToString();
                }
            }
            else
            {
                txtCostNo.Text = string.Empty;
                txtCostName.Text = string.Empty;
            }
        }
        private void button_SrchUsrNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("UsrNo", new ColumnDictinary("رقم المستخدم", "User No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("UsrNamA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("UsrNamE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_User";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                txtUserNo.Text = dbc.StockUser(frm.Serach_No).UsrNo;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    txtUserName.Text = dbc.StockUser(frm.Serach_No).UsrNamA.ToString();
                }
                else
                {
                    txtUserName.Text = dbc.StockUser(frm.Serach_No).UsrNamE.ToString();
                }
            }
            else
            {
                txtUserNo.Text = string.Empty;
                txtUserName.Text = string.Empty;
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
                    txtMFromDate.Text = string.Empty;
                }
            }
            catch
            {
                txtMFromDate.Text = string.Empty;
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
                    txtMToDate.Text = string.Empty;
                }
            }
            catch
            {
                txtMToDate.Text = string.Empty;
            }
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                ButExit.Text = "خــــروج Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.ISdirectPrinting) ? "طبـــاعة F5" : "عــــرض F5");
                groupBox3.Text = "حسب رقم الفاتورة";
                groupBox_Date.Text = "حسب تاريخ الفاتورة";
                label1.Text = "مـــــن :";
                label2.Text = "إلـــــى :";
                label3.Text = "مـــــن :";
                label4.Text = "إلـــــى :";
                label5.Text = ((vType == 1) ? "العميـــــــــل :" : "المــــــــــورد :");
                label7.Text = "المنـــــــدوب :";
                label8.Text = "مركز التكلفة :";
                label9.Text = "المستخـــدم :";
                radioButton_Del0.Text = "الغير محذوفة";
                radioButton_Del1.Text = "الكـــل";
                radioButton_Del2.Text = "المحذوفة فقط";
                radioButton__0650Return0.Text = "الغير مرتجعة";
                radioButton__0650Return1.Text = "الكـــل";
                radioButton__0650Return2.Text = "المرتجعة فقط";
                if (vType == 1)
                {
                    Text = "المبيعات الآجلة وسندات الدفع - القبض";
                }
                else
                {
                    Text = "المشتريات الآجلة وسندات الصرف";
                }
            }
            else
            {
                ButExit.Text = "Exit Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.ISdirectPrinting) ? "Print F5" : "Show F5");
                groupBox3.Text = "Quantity";
                groupBox_Date.Text = "Date of inactivity";
                label1.Text = "From :";
                label2.Text = "To :";
                label3.Text = "From :";
                label4.Text = "To :";
                label5.Text = ((vType == 1) ? "Customer :" : "Suppliers :");
                label7.Text = "Delegate :";
                label8.Text = "Cost Center :";
                label9.Text = "User :";
                if (vType == 1)
                {
                    Text = "Futures Sales";
                }
                else
                {
                    Text = "Forward purchases";
                }
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptSchool.dll"))
            {
                label5.Text = ((LangArEn == 0) ? "الطـالـب :" : "Student Acc :");
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
        private void FRInvoiceGaid_Load(object sender, EventArgs e)
        {
        }
        private void txtMFromNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void txtMIntoNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
    }
}
