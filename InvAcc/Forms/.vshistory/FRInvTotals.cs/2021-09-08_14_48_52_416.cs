using CrystalDecisions.Shared;
using DevComponents.DotNetBar;
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
using System.Linq;
using System.Windows.Forms;

namespace InvAcc.Forms
{
    public partial  class FRInvTotals : Form
    { void avs(int arln)

        {
        }    private void langloads(object sender, EventArgs e)
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
                        frm.Repvalue = "AccountTax";
                        frm.Repvalue = "AccountTax";
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
        private int LangArEn = 0;
        private T_User _User = new T_User();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private Stock_DataDataContext dbInstance;
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
        public FRInvTotals()
        {
            InitializeComponent();this.Load += langloads;
            _User = dbc.StockUser(VarGeneral.UserNumber);
            HijriGregDates dateFormatter = new HijriGregDates();
            if (VarGeneral.Settings_Sys.Calendr.Value != 0)
            {
                this.txtMFromDate.Text = dateFormatter.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                this.txtMToDate.Text = dateFormatter.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
            }
            else
            {
                this.txtMFromDate.Text =  dateFormatter.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                this.txtMToDate.Text = dateFormatter.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
            }
             }
        protected override void OnLoad(EventArgs e)
        {
            if (this.LangArEn != 0)
            {
                this.FlexType.Rows.Count = 3;
                this.FlexType.SetData(0, 0, true);
                this.FlexType.SetData(0, 1, "Cash");
                this.FlexType.SetData(1, 0, true);
                this.FlexType.SetData(1, 1, "Credit");
                this.FlexType.SetData(2, 0, true);
                this.FlexType.SetData(2, 1, "Network"
                    );
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
            }

            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FRAccountTax));
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
                RibunButtons();
                radioButton2.Text = (LangArEn == 0 ? "تفصيلي" :"Detailed");
                label7.Text = (LangArEn == 0 ? "المنـــــــدوب :" : "Delegator :");
                label9.Text=(LangArEn == 0 ? "المستخدم" : "Users: ");
                radioButton3.Text = (LangArEn == 0 ? "مختصر" : "Summurized");
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            avs(GeneralM.VarGeneral.currentintlanguage);
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRAccountTax));
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
        }
        private string BuildRuleList(int tp)
        {
            return "";
        }
      string script= @"SELECT           dbo.T_INVSETTING.InvNamA AS InvTypNm, dbo.T_INVHED.InvTyp,dbo.T_INVHED.InvCash, SUM(dbo.T_INVHED.InvNetLocCur) AS InvNetLocCur, (CASE WHEN
                             (SELECT        SUM(x.InvAddTax)
                                FROM            T_INVHED x
                                WHERE        x.InvTyp = T_INVHED.InvTyp AND x.IsTaxUse = AAAAAA AND x.GDat >= 'xxxxx' AND x.GDat <= 'yyyyy' AND x.IfDel != 1 AND ((x.InvCashPay = 0 OR
                                                         x.InvCashPay = 1) OR
                                                         (x.InvCash = '  شبكـــة  ' OR
                                                         x.InvCash = 'الشبكة' OR
                                                         x.InvCash = 'شبكـــة' OR
                                                         x.InvCash = '  شبكـــة  '))) > 0 THEN
                             (SELECT        SUM(x.InvAddTax)
                                FROM            T_INVHED x
                                WHERE        x.InvTyp = T_INVHED.InvTyp AND x.IsTaxUse = AAAAAA AND x.GDat >= 'xxxxx' AND x.GDat <= 'yyyyy' AND x.IfDel != 1 AND ((x.InvCashPay = 0 OR
                                                         x.InvCashPay = 1) OR
                                                         (x.InvCash = '  شبكـــة  ' OR
                                                         x.InvCash = 'الشبكة' OR
                                                         x.InvCash = 'شبكـــة' OR
                                                         x.InvCash = '  شبكـــة  '))) ELSE 0 END) AS InvAddTax, 'المنـــــــدوب ' AS MndHeaderX, '' AS MndNoX, '' AS MndNameX, 'العميـــــــــل ' AS CustHeaderX, '' AS CustNoX, '' AS CustNameX, 'المــــــــــورد ' AS SuppHeaderX, 
                         '' AS SuppNoX, '' AS SuppNameX, dbo.T_SYSSETTING.LogImg, (CASE WHEN
                             (SELECT        SUM(x.InvNetLocCur)
                                FROM            T_INVHED x
                                WHERE        x.InvTyp = OOOOO AND x.GDat >= 'xxxxx' AND x.GDat <= 'yyyyy' AND x.IfDel != 1 AND ((x.InvCashPay = 0 OR
                                                         x.InvCashPay = 1) OR
                                                         (x.InvCash = '  شبكـــة  ' OR
                                                         x.InvCash = 'الشبكة' OR
                                                         x.InvCash = 'شبكـــة' OR
                                                         x.InvCash = '  شبكـــة  '))) > 0 THEN
                             (SELECT        SUM(x.InvNetLocCur)
                                FROM            T_INVHED x
                                WHERE        x.InvTyp = OOOOO AND x.GDat >= 'xxxxx' AND x.GDat <= 'yyyyy' AND x.IfDel != 1 AND ((x.InvCashPay = 0 OR
                                                         x.InvCashPay = 1) OR
                                                         (x.InvCash = '  شبكـــة  ' OR
                                                         x.InvCash = 'الشبكة' OR
                                                         x.InvCash = 'شبكـــة' OR
                                                         x.InvCash = '  شبكـــة  '))) ELSE 0 END) - (CASE WHEN
                             (SELECT        SUM(x.InvNetLocCur)
                                FROM            T_INVHED x
                                WHERE        x.InvTyp = RRRRRR AND x.GDat >= 'xxxxx' AND x.GDat <= 'yyyyy' AND x.IfDel != 1 AND ((x.InvCashPay = 0 OR
                                                         x.InvCashPay = 1) OR
                                                         (x.InvCash = '  شبكـــة  ' OR
                                                         x.InvCash = 'الشبكة' OR
                                                         x.InvCash = 'شبكـــة' OR
                                                         x.InvCash = '  شبكـــة  '))) > 0 THEN
                             (SELECT        SUM(x.InvNetLocCur)
                                FROM            T_INVHED x
                                WHERE        x.InvTyp = RRRRRR AND x.GDat >= 'xxxxx' AND x.GDat <= 'yyyyy' AND x.IfDel != 1 AND ((x.InvCashPay = 0 OR
                                                         x.InvCashPay = 1) OR
                                                         (x.InvCash = '  شبكـــة  ' OR
                                                         x.InvCash = 'الشبكة' OR
                                                         x.InvCash = 'شبكـــة' OR
                                                         x.InvCash = '  شبكـــة  '))) ELSE 0 END) AS Balanc, (CASE WHEN
                             (SELECT        SUM(x.InvAddTax)
                                FROM            T_INVHED x
                                WHERE        x.InvTyp = OOOOO AND x.GDat >= 'xxxxx' AND x.GDat <= 'yyyyy' AND x.IfDel != 1 AND ((x.InvCashPay = 0 OR
                                                         x.InvCashPay = 1) OR
                                                         (x.InvCash = '  شبكـــة  ' OR
                                                         x.InvCash = 'الشبكة' OR
                                                         x.InvCash = 'شبكـــة' OR
                                                         x.InvCash = '  شبكـــة  '))) > 0 THEN
                             (SELECT        SUM(x.InvAddTax)
                                FROM            T_INVHED x
                                WHERE        x.InvTyp = OOOOO AND x.GDat >= 'xxxxx' AND x.GDat <= 'yyyyy' AND x.IfDel != 1 AND ((x.InvCashPay = 0 OR
                                                         x.InvCashPay = 1) OR
                                                         (x.InvCash = '  شبكـــة  ' OR
                                                         x.InvCash = 'الشبكة' OR
                                                         x.InvCash = 'شبكـــة' OR
                                                         x.InvCash = '  شبكـــة  '))) ELSE 0 END) - (CASE WHEN
                             (SELECT        SUM(x.InvAddTax)
                                FROM            T_INVHED x
                                WHERE        x.InvTyp = RRRRRR AND x.GDat >= 'xxxxx' AND x.GDat <= 'yyyyy' AND x.IfDel != 1 AND ((x.InvCashPay = 0 OR
                                                         x.InvCashPay = 1) OR
                                                         (x.InvCash = '  شبكـــة  ' OR
                                                         x.InvCash = 'الشبكة' OR
                                                         x.InvCash = 'شبكـــة' OR
                                                         x.InvCash = '  شبكـــة  '))) > 0 THEN
                             (SELECT        SUM(x.InvAddTax)
                                FROM            T_INVHED x
                                WHERE        x.InvTyp = RRRRRR AND x.GDat >= 'xxxxx' AND x.GDat <= 'yyyyy' AND x.IfDel != 1 AND ((x.InvCashPay = 0 OR
                                                         x.InvCashPay = 1) OR
                                                         (x.InvCash = '  شبكـــة  ' OR
                                                         x.InvCash = 'الشبكة' OR
                                                         x.InvCash = 'شبكـــة' OR
                                                         x.InvCash = '  شبكـــة  '))) ELSE 0 END) AS CashPayLocCur
FROM            dbo.T_INVHED LEFT OUTER JOIN
                         dbo.T_INVSETTING ON dbo.T_INVHED.InvTyp = dbo.T_INVSETTING.InvID LEFT OUTER JOIN
                         dbo.T_Curency ON dbo.T_INVHED.CurTyp = dbo.T_Curency.Curency_ID LEFT OUTER JOIN
                         dbo.T_CstTbl ON dbo.T_INVHED.InvCstNo = dbo.T_CstTbl.Cst_ID LEFT OUTER JOIN
                         dbo.T_Mndob ON dbo.T_INVHED.MndNo = dbo.T_Mndob.Mnd_ID LEFT OUTER JOIN
                         dbo.T_SYSSETTING ON dbo.T_INVHED.CompanyID = dbo.T_SYSSETTING.SYSSETTING_ID
WHERE        (dbo.T_INVHED.InvTyp = OOOOO OR
                         dbo.T_INVHED.InvTyp = RRRRRR) AND (dbo.T_INVHED.GDat >= 'xxxxx') AND (dbo.T_INVHED.GDat <= 'yyyyy') AND (dbo.T_INVHED.IfDel <> 1) AND (dbo.T_INVHED.InvCashPay = 0 OR
                         dbo.T_INVHED.InvCashPay = 1) OR
                         (dbo.T_INVHED.InvTyp = OOOOO OR
                         dbo.T_INVHED.InvTyp = RRRRRR) AND (dbo.T_INVHED.GDat >= 'xxxxx') AND (dbo.T_INVHED.GDat <= 'yyyyy') AND (dbo.T_INVHED.IfDel <> 1) AND (dbo.T_INVHED.InvCash = '  شبكـــة  ' OR
                         dbo.T_INVHED.InvCash = 'الشبكة' OR
                         dbo.T_INVHED.InvCash = 'شبكـــة' OR
                         dbo.T_INVHED.InvCash = '  شبكـــة  ')
GROUP BY dbo.T_INVSETTING.InvNamA, dbo.T_SYSSETTING.LogImg, dbo.T_INVHED.InvTyp,dbo.T_INVHED.InvCash
ORDER BY dbo.T_INVHED.InvTyp"; private string BuildRuleList(string typeofbills )
        {
            int iiCnt;
            object obj;
            object[] tag;
            string str= typeofbills;
            bool flag;
            HijriGregDates dateFormatter = new HijriGregDates();
            //if (this.combobox_RepType.SelectedIndex == 1)
            //{
            //    str = " Where (T_INVHED.InvTyp = 1 or T_INVHED.InvTyp = 3) ";
            //}
            //else
            //{
            //    str = (this.combobox_RepType.SelectedIndex == 2 ? " Where (T_INVHED.InvTyp = 1 or T_INVHED.InvTyp = 2) " : string.Concat(" Where T_INVHED.InvTyp = ", this.CmbInvType.SelectedValue.ToString()));
            //}
            string Rule = str;
            //if (!string.IsNullOrEmpty(this.txtMFromNo.Text))
            //{
            //    obj = Rule;
            //    tag = new object[] { obj, " and ", this.txtMFromNo.Tag, " >= ", this.txtMFromNo.Text.Trim() };
            //    Rule = string.Concat(tag);
            //}
            //if (!string.IsNullOrEmpty(this.txtMIntoNo.Text))
            //{
            //    obj = Rule;
            //    tag = new object[] { obj, " and ", this.txtMIntoNo.Tag, " <= ", this.txtMIntoNo.Text.Trim() };
            //    Rule = string.Concat(tag);
            //}
            //if (!string.IsNullOrEmpty(this.txtCostNo.Text))
            //{
            //    obj = Rule;
            //    tag = new object[] { obj, " and ", this.txtCostNo.Tag, " = ", this.txtCostNo.Text.Trim() };
            //    Rule = string.Concat(tag);
            //}
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
            //if ((!VarGeneral.CheckDate(this.txtMFromDate.Text) ? false : this.txtMFromDate.Text.Length == 10))
            //{
            //    if (!this.checkBox_DatePay.Checked)
            //    {
            //        Rule = (int.Parse(this.txtMFromDate.Text.Substring(0, 4)) >= 1800 ? string.Concat(Rule, " and  T_INVHED.GDat  >= '", dateFormatter.FormatGreg(this.txtMFromDate.Text, "yyyy/MM/dd"), "'") : string.Concat(Rule, " and  T_INVHED.HDat  >= '", dateFormatter.FormatHijri(this.txtMFromDate.Text, "yyyy/MM/dd"), "'"));
            //    }
            //    else
            //    {
            //        Rule = string.Concat(Rule, " and  T_INVHED.EstDat  >= '", dateFormatter.FormatHijri(this.txtMFromDate.Text, "yyyy/MM/dd"), "'");
            //    }
            //}
            //if ((!VarGeneral.CheckDate(this.txtMToDate.Text) ? false : this.txtMToDate.Text.Length == 10))
            //{
            //    if (!this.checkBox_DatePay.Checked)
            //    {
            //        Rule = (int.Parse(this.txtMToDate.Text.Substring(0, 4)) >= 1800 ? string.Concat(Rule, " and  T_INVHED.GDat  <= '", dateFormatter.FormatGreg(this.txtMToDate.Text, "yyyy/MM/dd"), "'") : string.Concat(Rule, " and  T_INVHED.HDat  <= '", dateFormatter.FormatHijri(this.txtMToDate.Text, "yyyy/MM/dd"), "'"));
            //    }
            //    else
            //    {
            //        Rule = string.Concat(Rule, " and  T_INVHED.EstDat  <= '", dateFormatter.FormatHijri(this.txtMToDate.Text, "yyyy/MM/dd"), "'");
            //    }
            //}
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
            string RuleInvType = ""; int rc = FlexType.Rows.Count; if (rc == 3) rc--;
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
            {
                RuleInvType = "(" + RuleInvType + ")";
                if ((bool)this.FlexType.GetData(2, 0))
                {
                    if (string.IsNullOrEmpty(RuleInvType))
                    {
                        obj = RuleInvType;
                        tag = new object[] { obj, this.FlexType.Tag, "  = ", iiCnt };
                        RuleInvType = string.Concat(tag);
                    }

                    obj = RuleInvType;
                    tag = new object[] { obj, " or (T_INVHED.InvCash ='  شبكـــة  ' or T_INVHED.InvCash = 'الشبكة' or T_INVHED.InvCash = 'شبكـــة' or T_INVHED.InvCash = '  شبكـــة  ' )" };
                    RuleInvType = string.Concat(tag);
                }
                else
                {
                    if (string.IsNullOrEmpty(RuleInvType))
                    {
                        obj = RuleInvType;
                        tag = new object[] { obj, this.FlexType.Tag, "  = ", iiCnt };
                        RuleInvType = string.Concat(tag);
                    }

                    obj = RuleInvType;
                    tag = new object[] { obj, " and (T_INVHED.InvCash !='  شبكـــة  ' and T_INVHED.InvCash != 'الشبكة' and T_INVHED.InvCash != 'شبكـــة' and T_INVHED.InvCash != '  شبكـــة  ' )" };
                    RuleInvType = string.Concat(tag);
                }

            }

            if (!string.IsNullOrEmpty(RuleInvType))
            {
                Rule = string.Concat(Rule, " and (", RuleInvType, ")");
            }
            if (VarGeneral.InvTyp == 21)
            {
                Rule = string.Concat(Rule, " and (PaymentOrderTyp = 0 and RoomNo != '' )");
            }
            
            //if (!flag)
            //{
            //    RuleInvType = "";
                
                
            //    if (!string.IsNullOrEmpty(RuleInvType))
            //    {
            //        Rule = string.Concat(Rule, " and (", RuleInvType, ") and T_INVHED.InvId is not null ");
            //    }
            //}
            if (!this.radioButton_Tax1.Checked)
            {
                Rule = (!this.radioButton_Tax0.Checked ? string.Concat(Rule, " and T_INVHED.InvAddTax <= 0 ") : string.Concat(Rule, " and T_INVHED.InvAddTax > 0 "));
            }
            return Rule;
        }

        private void ButOkn_Click(object sender, EventArgs e)
        {
            string quryEdit;
            string[] strArrays;
            object[] text;
            double? amount;
            bool flag;
            object obj;
            string str;
            double value;
            object obj1;
            object obj2;
            object obj3;
            try
            {
             
                {
                    VarGeneral.itmDes = "";
                    RepShow _RepShow = new RepShow()
                    {
                        Tables = " T_INVHED Left Join  T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  Left Join T_Curency On T_INVHED.CurTyp = T_Curency.Curency_ID Left Join T_CstTbl On T_INVHED.InvCstNo = T_CstTbl.Cst_ID Left Join T_Mndob on T_INVHED.MndNo = T_Mndob.Mnd_Id Left Join T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID"
                    };
                    string Fields = "";
               
                    { 
                        quryEdit = this.BuildRuleList("Where (T_INVHED.InvTyp = 1 or T_INVHED.InvTyp = 3)");
                        quryEdit = quryEdit.Replace("Where (T_INVHED.InvTyp = 1 or T_INVHED.InvTyp = 3)", " ");
                        quryEdit = quryEdit.Replace("T_INVHED.", "x.");
                        if (this.LangArEn != 0)
                        {
                            strArrays = new string[] { " T_INVSETTING.InvNamE as InvTypNm,T_INVHED.InvTyp,sum(T_INVHED.InvNetLocCur) as InvNetLocCur,(case when (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = T_INVHED.InvTyp and x.IsTaxUse = 1 ", quryEdit, " ) > 0 then (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = T_INVHED.InvTyp and x.IsTaxUse = 1 ", quryEdit, " ) else 0 end) as InvAddTax,'", this.label7.Text.Replace(":", ""), "' as MndHeaderX,'", this.txtLegNo.Text, "' as MndNoX,'", this.txtLegName.Text, "' as MndNameX,'", this.label5.Text.Replace(":", ""), "' as CustHeaderX,'", this.txtCustNo.Text, "' as CustNoX,'", this.txtCustName.Text, "' as CustNameX,'", this.label6.Text.Replace(":", ""), "' as SuppHeaderX,'", this.txtSuppNo.Text, "' as SuppNoX,'", this.txtSuppName.Text, "' as SuppNameX,T_SYSSETTING.LogImg,(case when (select sum(x.InvNetLocCur)  from T_INVHED x where x.InvTyp = 1 ", quryEdit, " ) > 0 then (select sum(x.InvNetLocCur)  from T_INVHED x where x.InvTyp = 1 ", quryEdit, ") else 0 end) - (case when (select sum(x.InvNetLocCur)  from T_INVHED x where x.InvTyp = 3 ", quryEdit, ") > 0 then (select sum(x.InvNetLocCur)  from T_INVHED x where x.InvTyp = 3 ", quryEdit, ") else 0 end) as Balanc,(case when (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = 1 ", quryEdit, " ) > 0 then (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = 1 ", quryEdit, ") else 0 end) - (case when (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = 3 ", quryEdit, ") > 0 then (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = 3 ", quryEdit, ") else 0 end) as CashPayLocCur" };
                            Fields = string.Concat(strArrays);
                        }
                        else
                        {
                            strArrays = new string[] { " T_INVSETTING.InvNamA as InvTypNm,T_INVHED.InvTyp,sum(T_INVHED.InvNetLocCur) as InvNetLocCur,(case when (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = T_INVHED.InvTyp and x.IsTaxUse = 1 ", quryEdit, " ) > 0 then (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = T_INVHED.InvTyp and x.IsTaxUse = 1 ", quryEdit, " ) else 0 end) as InvAddTax,'", this.label7.Text.Replace(":", ""), "' as MndHeaderX,'", this.txtLegNo.Text, "' as MndNoX,'", this.txtLegName.Text, "' as MndNameX,'", this.label5.Text.Replace(":", ""), "' as CustHeaderX,'", this.txtCustNo.Text, "' as CustNoX,'", this.txtCustName.Text, "' as CustNameX,'", this.label6.Text.Replace(":", ""), "' as SuppHeaderX,'", this.txtSuppNo.Text, "' as SuppNoX,'", this.txtSuppName.Text, "' as SuppNameX,T_SYSSETTING.LogImg,(case when (select sum(x.InvNetLocCur)  from T_INVHED x where x.InvTyp = 1 ", quryEdit, " ) > 0 then (select sum(x.InvNetLocCur)  from T_INVHED x where x.InvTyp = 1 ", quryEdit, ") else 0 end) - (case when (select sum(x.InvNetLocCur)  from T_INVHED x where x.InvTyp = 3 ", quryEdit, ") > 0 then (select sum(x.InvNetLocCur)  from T_INVHED x where x.InvTyp = 3 ", quryEdit, ") else 0 end) as Balanc,(case when (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = 1 ", quryEdit, " ) > 0 then (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = 1 ", quryEdit, ") else 0 end) - (case when (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = 3 ", quryEdit, ") > 0 then (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = 3 ", quryEdit, ") else 0 end) as CashPayLocCur" };
                            Fields = string.Concat(strArrays);
                        }
                    }
             
                    RepShow repShow = _RepShow;
                    string str1 = this.BuildRuleList("Where (T_INVHED.InvTyp = 1 or T_INVHED.InvTyp = 3)");
                  
                    {
                        str = string.Concat(" group by ", (this.LangArEn == 0 ? " T_INVSETTING.InvNamA " : " T_INVSETTING.InvNamE "), ",T_SYSSETTING.LogImg ,T_INVHED.InvTyp order by T_INVHED.InvTyp");
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
                           
                            //// Program.createdb_BARACODE(VarGeneral.RepData.Tables[0], "ReportMultiTable");
                            //FrmReportsViewer frm = new FrmReportsViewer()
                            //{
                            //    Tag = this.LangArEn,
                            //    Repvalue = "Invoices"
                            //};
                            //VarGeneral.vTitle = this.Text;
                            //VarGeneral.Customerlbl = this.label5.Text.Replace(" :", "");
                            //VarGeneral.Supplierlbl = this.label6.Text.Replace(" :", "");
                             
                            //VarGeneral.Mndoblbl = this.label7.Text.Replace(" :", "");
                            //if ((!File.Exists(string.Concat(Application.StartupPath, "\\Script\\SecriptGlasses.dll")) ? false : this.checkBox_DatePay.Checked))
                            //{
                            //    VarGeneral.CostCenterlbl = (this.LangArEn == 0 ? "الحالة" : "State");
                            //}
                            //frm.TopMost = true;
                            //frm.ShowDialog();
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

        private void ButOk_Click(object sender, EventArgs e)
        {
             
            double totSales = 0.0,totSaleReturn=0.0;
            double totPurchaes = 0.0, totPurchaesReturn = 0.0 ;
            try
            {
                string from = "", too = "";

                HijriGregDates dateFormatter = new HijriGregDates();

                if (VarGeneral.CheckDate(txtMFromDate.Text) && txtMFromDate.Text.Length == 10)
                {
                    from = ((int.Parse(txtMFromDate.Text.Substring(0, 4)) >= 1800) ? (dateFormatter.FormatGreg(txtMFromDate.Text, "yyyy/MM/dd")) : (dateFormatter.FormatHijri(txtMFromDate.Text, "yyyy/MM/dd")));
                }
                if (VarGeneral.CheckDate(txtMToDate.Text) && txtMToDate.Text.Length == 10)
                {
                    too = ((int.Parse(txtMToDate.Text.Substring(0, 4)) >= 1800) ? (dateFormatter.FormatGreg(txtMToDate.Text, "yyyy/MM/dd")) : (dateFormatter.FormatHijri(txtMToDate.Text, "yyyy/MM/dd")));
                }
                string st;

                string scc = @"SELECT        ffffffffffffffffff dbo.T_INVHED.InvTyp, dbo.T_INVSETTING.InvNamA, COUNT(dbo.T_INVHED.InvHed_ID) AS InvCount, SUM(dbo.T_INVHED.InvTot) AS InvTot, SUM(dbo.T_INVHED.InvTotLocCur) AS InvTotLocCur, SUM(dbo.T_INVHED.InvDisPrs) 
                         AS InvDisPrs, SUM(dbo.T_INVHED.InvDisVal) AS InvDisVal, SUM(dbo.T_INVHED.InvDisValLocCur) AS InvDisValLocCur, SUM(dbo.T_INVHED.InvNet) AS InvNet, SUM(dbo.T_INVHED.InvNetLocCur) AS InvNetLocCur, 
                         SUM(dbo.T_INVHED.CashPay) AS CashPay, SUM(dbo.T_INVHED.CashPayLocCur) AS CashPayLocCur, SUM(dbo.T_INVHED.InvCost) AS InvCost, SUM(dbo.T_INVHED.CustPri) AS CustPri, SUM(dbo.T_INVHED.InvQty) AS InvQty, 
                         SUM(dbo.T_INVHED.CustRep) AS CustRep, SUM(dbo.T_INVHED.CustNet) AS CustNet, SUM(dbo.T_INVHED.CreditPay) AS CreditPay, SUM(dbo.T_INVHED.CreditPayLocCur) AS CreditPayLocCur, SUM(dbo.T_INVHED.NetworkPay) 
                         AS NetworkPay, SUM(dbo.T_INVHED.NetworkPayLocCur) AS NetworkPayLocCur, SUM(dbo.T_INVHED.InvAddCost) AS InvAddCost, SUM(dbo.T_INVHED.InvAddCostLoc) AS InvAddCostLoc, SUM(dbo.T_INVHED.InvAddCostExtrnal) 
                         AS InvAddCostExtrnal, SUM(dbo.T_INVHED.InvAddCostExtrnalLoc) AS InvAddCostExtrnalLoc, SUM(dbo.T_INVHED.InvAddTax) AS InvAddTax, SUM(dbo.T_INVHED.InvAddTaxlLoc) AS InvAddTaxlLoc, 
                         SUM(dbo.T_INVHED.InvValGaidDis) AS InvValGaidDis, SUM(dbo.T_INVHED.InvValGaidDislLoc) AS InvValGaidDislLoc, SUM(dbo.T_INVHED.InvComm) AS InvComm, SUM(dbo.T_INVHED.InvCommLoc) AS InvCommLoc, 
                         SUM(dbo.T_INVHED.TaxByNetValue) AS TaxByNetValue, SUM(dbo.T_INVHED.DesPointsValue) AS DesPointsValue, SUM(dbo.T_INVHED.DesPointsValueLocCur) AS DesPointsValueLocCur, dbo.T_INVSETTING.InvNamA AS Expr1,
                         CASE dbo.T_INVHED.InvCash WHEN 'نقـــدي' THEN 'نقـــدي' WHEN 'Cach' THEN 'نقـــدي' WHEN '  نقـــدي  ' THEN 'نقـــدي' WHEN '  أجـــل  ' THEN 'أجـــل' WHEN 'أجـــل' THEN 'أجـــل' WHEN 'الشبكة' THEN 'شبكـــة' WHEN '  شبكـــة  ' THEN 'شبكـــة' 
WHEN 'Network' THEN 'شبكـــة' WHEN 'Credit' THEN 'أجـــل'  when 'شبكـــة' then 'شبكـــة'
END AS InvPayMethod
FROM            dbo.T_INVHED INNER JOIN
                         dbo.T_INVSETTING ON dbo.T_INVHED.InvTyp = dbo.T_INVSETTING.InvID
WHERE        (TTTTT) AND (dbo.T_INVHED.GDat >= 'FFFFF' AND dbo.T_INVHED.GDat <= 'TOOOOO')bbbbbbbbbb 
GROUP BY dbo.T_INVHED.InvTyp, dbo.T_INVSETTING.InvNamA,jjjjjjj
                        CASE dbo.T_INVHED.InvCash WHEN 'نقـــدي' THEN 'نقـــدي' WHEN 'Cach' THEN 'نقـــدي' WHEN '  نقـــدي  ' THEN 'نقـــدي' WHEN '  أجـــل  ' THEN 'أجـــل' WHEN 'أجـــل' THEN 'أجـــل' WHEN 'الشبكة' THEN 'شبكـــة' WHEN '  شبكـــة  ' THEN 'شبكـــة' 
WHEN 'Network' THEN 'شبكـــة' WHEN 'Credit' THEN 'أجـــل'  when 'شبكـــة' then 'شبكـــة'
END";

                string Xd = "  (TTTTT) AND (ttttttt.GDat >= 'FFFFF' AND dbo.ttttttt.GDat <= 'TOOOOO')bbbbbbbbbb ";
                string dd = " (dbo.T_INVHED.IfDel <> 1)And (TTTTT)and(dbo.T_INVHED.IsTaxUse = RRRRR) AND (dbo.T_INVHED.GDat >= 'FFFFF') AND (dbo.T_INVHED.GDat <= 'TOOOOO') ";
                string where = "dbo.T_INVHED.InvTyp =1 or dbo.T_INVHED.InvTyp=2 or dbo.T_INVHED.InvTyp=3 or dbo.T_INVHED.InvTyp=4";

                scc = scc.Replace("TTTTT", where);


                string date = "x.GDat >= '2021/07/15' AND x.GDat <= '2021/07/15' ";
                string typn = "((x.InvCashPay = 0 OR x.InvCashPay = 1) OR (x.InvCash = '  شبكـــة  ' OR x.InvCash = 'الشبكة' OR x.InvCash = 'شبكـــة' OR x.InvCash = '  شبكـــة  '))";
                string tynet = "( (x.InvCash = '  شبكـــة  ' OR x.InvCash = 'الشبكة' OR x.InvCash = 'شبكـــة' OR x.InvCash = '  شبكـــة  '))";
                string tycash = "((x.InvCashPay = 0 ) and (x.InvCash != '  شبكـــة  ' and x.InvCash != 'الشبكة' and x.InvCash != 'شبكـــة' and x.InvCash != '  شبكـــة  '))";

                ; string tycridet = " ( x.InvCashPay = 1) ";

                string ddsavv = "(CASE WHEN (SELECT SUM(x.InvNetLocCur) FROM T_INVHED x WHERE x.InvTyp = 3 AND jjjjjjjjjjjjjjjjjjjjjj AND x.IfDel ! = 1 AND faaaaaaaaafffffffffffff > 0 THEN (SELECT SUM(x.InvNetLocCur) FROM T_INVHED x WHERE x.InvTyp = 1 AND jjjjjjjjjjjjjjjjjjjjjj AND x.IfDel ! = 1 AND faaaaaaaaafffffffffffff ELSE 0 END) - (CASE WHEN (SELECT SUM(x.InvNetLocCur) FROM T_INVHED x WHERE x.InvTyp = 3 AND jjjjjjjjjjjjjjjjjjjjjj AND x.IfDel ! = 1 AND faaaaaaaaafffffffffffff > 0 THEN (SELECT SUM(x.InvNetLocCur) FROM T_INVHED x WHERE x.InvTyp = 3 AND jjjjjjjjjjjjjjjjjjjjjj AND x.IfDel ! = 1 AND faaaaaaaaafffffffffffff ELSE 0 END)";
                string dfnv = @"(SELECT SUM(x.InvNetLocCur) FROM T_INVHED x WHERE x.InvTyp = 3 AND jjjjjjjjjjjjjjjjjjjjjj AND x.IfDel ! = 1) ReturnInvNetLocCur";


                if (from == "")
                {
                    from = "2000/01/01";

                }
                if (too == "")
                {
                    too = "2100/01/01";
                }
                string Rule = "";
                if (!this.radioButton_Tax1.Checked)
                {
                    Rule = (!this.radioButton_Tax0.Checked ? string.Concat(Rule, " and T_INVHED.InvAddTax <= 0 ") : string.Concat(Rule, " and T_INVHED.InvAddTax > 0 "));
                }
                
                
                Rule += " and T_INVHED.IfDel=0";
                Xd = Xd.Replace("TOOOOO", too).Replace("FFFFF", from).Replace("bbbbbbbbbb", Rule);
                string sccmd = "";
                scc = scc.Replace("TOOOOO", too).Replace("FFFFF", from);
                scc = scc.Replace("RRRRR", "1");


                scc = scc.Replace("xxxxxxxxxxxxxxx", dd);

                sccmd = scc.Replace("ffffffffffffffffff", @"(STUFF((SELECT CAST(', ' + (xx.Arb_Des + ' | ' + xx.Eng_Des) AS VARCHAR(200))
         FROM T_Mndob xx
         WHERE(xx.Mnd_No = T_INVHED.MndNo)
         FOR XML PATH('')), 1, 2, '')) AS MndobName,(SELECT SUM(x.InvNetLocCur) FROM T_INVHED x WHERE x.InvTyp = 3 AND jjjjjjjjjjjjjjjjjjjjjj AND x.IfDel ! = 1) ReturnInvNetLocCur ,((SELECT SUM(x.InvNetLocCur)
 FROM T_INVHED x WHERE x.InvTyp = 1 AND x.MndNo = T_INVHED.MndNo AND x.InvCashPay = 1 AND x.IfDel ! = 1)-(SELECT SUM(x.InvNetLocCur)
 FROM T_INVHED x WHERE x.InvTyp = 3 AND x.MndNo = T_INVHED.MndNo AND x.InvCashPay = 1 AND x.IfDel ! = 1)) AS CreditTotal
,
((SELECT SUM(x.InvNetLocCur)
 FROM T_INVHED x WHERE x.InvTyp = 1 AND x.MndNo = T_INVHED.MndNo AND ((x.InvCashPay = 0 ) and (x.InvCash != '  شبكـــة  ' and x.InvCash != 'الشبكة' and x.InvCash != 'شبكـــة' and x.InvCash != '  شبكـــة  '))  AND x.IfDel ! = 1)-(SELECT SUM(x.InvNetLocCur)
 FROM T_INVHED x WHERE x.InvTyp = 3 AND x.MndNo = T_INVHED.MndNo AND ((x.InvCashPay = 0 ) and (x.InvCash != '  شبكـــة  ' and x.InvCash != 'الشبكة' and x.InvCash != 'شبكـــة' and x.InvCash != '  شبكـــة  '))  AND x.IfDel ! = 1)) AS CashTotal
,
((SELECT SUM(x.InvNetLocCur)
 FROM T_INVHED x WHERE x.InvTyp = 1 AND x.MndNo = T_INVHED.MndNo AND ((x.InvCash == '  شبكـــة  ' and x.InvCash == 'الشبكة' and x.InvCash == 'شبكـــة' and x.InvCash == '  شبكـــة  '))  AND x.IfDel ! = 1)-(SELECT SUM(x.InvNetLocCur)
 FROM T_INVHED x WHERE x.InvTyp = 3 AND x.MndNo = T_INVHED.MndNo AND ((x.InvCash == '  شبكـــة  ' and x.InvCash == 'الشبكة' and x.InvCash == 'شبكـــة' and x.InvCash == '  شبكـــة  '))  AND x.IfDel ! = 1) )AS NetworkTotal
,").Replace("jjjjjjjjjjjjjjjjjjjjjj", Rule).Replace("bbbbbbbbbb", " and T_INVHED.MndNo IS NOT NULL " + Rule).Replace("jjjjjjj", " T_INVHED.MndNo,"); ;
                string rrr = Rule;
                if (txtLegNo.Text.Trim() != "")
                    Rule = " and " + txtLegNo.Tag.ToString() + "=" + txtLegNo.Text + Rule;
                if (txtSuppNo.Text != "")
                    Rule = " and " + txtSuppNo.Tag.ToString() + "=" + txtSuppNo.Text + Rule;
                if (txtUserNo.Text != "")
                    rrr = " and " + txtUserNo.Tag.ToString() + "=" + txtUserNo.Text + Rule;
                
                if (txtCustNo.Text != "")
                    Rule = " and " + txtCustNo.Tag.ToString() + " = " + txtCustNo.Text + Rule;
                sccmd = scc.Replace("ffffffffffffffffff", @"(STUFF((SELECT CAST(', ' + (xx.Arb_Des + ' | ' + xx.Eng_Des) AS VARCHAR(200))
         FROM T_Mndob xx
         WHERE(xx.Mnd_No = T_INVHED.MndNo)
         FOR XML PATH('')), 1, 2, '')) AS MndobName,(SELECT SUM(x.InvNetLocCur) FROM T_INVHED x WHERE x.InvTyp = 3 AND x.MndNo = T_INVHED.MndNo AND x.IfDel ! = 1)as ReturnInvNetLocCur ,").Replace("jjjjjjjjjjjjjjjjjjjjjj", Rule).Replace("bbbbbbbbbb", " and T_INVHED.MndNo IS NOT NULL " + Rule).Replace("jjjjjjj", " T_INVHED.MndNo,"); ;

                scc = scc.Replace("bbbbbbbbbb", rrr);
                scc = scc.Replace("jjjjjjj", "");
                scc = scc.Replace("ffffffffffffffffff", "");

              
                DataTable tb =     DBUdate.DbUpdates.execute(scc, VarGeneral.BranchCS);
           DataTable tb2 = DBUdate.DbUpdates.execute(sccmd, VarGeneral.BranchCS);

                 if (tb.Rows.Count != 0)
                {

                    if (tb.Rows.Count >0)
                    {
                        DataColumn cs = new DataColumn("CashNet");
                        tb.Columns.Add(cs);

                        DataColumn cs2 = new DataColumn("CreditNet");
                        tb.Columns.Add(cs2);

                        DataColumn cs3 = new DataColumn("NetworkNet");
                        tb.Columns.Add(cs3);
                        DataColumn cs22 = new DataColumn("CashTaxNet");
                        tb.Columns.Add(cs22);

                        DataColumn cs222 = new DataColumn("CreditTaxNet");
                        tb.Columns.Add(cs222);

                        DataColumn cs32 = new DataColumn("NetworkTaxNet");
                        tb.Columns.Add(cs32);

                        var dataRowsales = tb.AsEnumerable().Where(x => x.Field<int>("InvTyp") == 1);

                        var dataRowsalesreturn = tb.AsEnumerable().Where(x => x.Field<int>("InvTyp") == 3);
                        double x1 = 0, x2 = 0, x3 = 0;

                        var dataRowPurshes = tb.AsEnumerable().Where(x => x.Field<int>("InvTyp") == 2);

                        var dataRowPurshesReturn = tb.AsEnumerable().Where(x => x.Field<int>("InvTyp") == 4);
                        foreach (DataRow kd in dataRowsales)
                        {
                            string sm = "0";
                            string smt = "0";
                            foreach (DataRow kk in dataRowsalesreturn)
                            {
                                if (kk["InvPayMethod"].ToString() == kd["InvPayMethod"].ToString())
                                {
                                    sm = kk["InvNetLocCur"].ToString();
                                    smt = kk["InvAddTax"].ToString();
                                    break;

                                }
                                kk.SetField("CashNet", 0);
                                kk.SetField("CreditNet", 0);
                                kk.SetField("NetworkNet", 0);
                            }
                            // if(sm!="")
                            {
                                string n = "",nn2="",nn3="";
                               // if (kd["InvPayMethod"].ToString().Contains("ق"))
                                    n = "CashNet";
                              //  else
                                   //  if (kd["InvPayMethod"].ToString().Contains("ج"))
                                    nn2 = "CreditNet";
                             //   else if (kd["InvPayMethod"].ToString().Contains("ش"))
                                    nn3 = "NetworkNet";
                                string n2 = "",n3="",n4="";
                                try
                                {
                                    
                                  
                                    n2 = kd["CashPayLocCur"].ToString();
                                  
                                }
                                catch
                                {
                                    n2 = "0";

                                }
                                try
                                {
                                    n3 = kd["NetworkPayLocCur"].ToString();

                                }
                                catch
                                {
                                    n3 = "0";
                                }
                                try
                                {
                                    n4 = kd["CreditPayLocCur"].ToString();

                                }
                                catch { n4 = "0"; }
                                try
                                {
                                    kd.SetField(n, double.Parse(n2) - double.Parse(sm));
                                }
                                catch
                                {
                                    kd.SetField(n, double.Parse(n2) - double.Parse(sm));

                                }
                                try
                                {
                                    kd.SetField(nn2, double.Parse(n3) - double.Parse(sm));
                                }
                                catch
                                {
                                    kd.SetField(nn2, double.Parse(n3) - double.Parse(sm));

                                }
                                try
                                {
                                    kd.SetField(nn3, double.Parse(n4) - double.Parse(sm));
                                }
                                catch
                                {
                                    kd.SetField(nn3, double.Parse(n) - double.Parse(sm));

                                }
                            }
                            //    if (smt != "")
                            {
                                string n = "";
                                
                                if (kd["InvPayMethod"].ToString().Contains("ق"))
                                    n = "CashTaxNet";
                                else
                                     if (kd["InvPayMethod"].ToString().Contains("ج"))
                                    n = "CreditTaxNet";
                                else if (kd["InvPayMethod"].ToString().Contains("ش"))
                                    n = "NetworkTaxNet";
                                string n2 = "";
                                try
                                {
                                    n2 = kd["InvAddTax"].ToString();

                                }
                                catch
                                {
                                    n2 = "0";
                                }

                                try
                                {
                                    kd.SetField(n, double.Parse(n2) - double.Parse(smt));
                                }
                                catch
                                {
                                    kd.SetField(n, double.Parse(n2) - double.Parse(smt));

                                }
                            }

                        }
                        foreach (DataRow kd in dataRowPurshes)
                        {
                            string sm = "0";
                            string smt = "0";
                            // ((from kk in dataRowPurshesReturn.AsEnumerable() where kk["InvPayMethod"] == kd["InvPayMethod"] select kk["InvNetLocCur"]).First().ToString());
                            foreach (DataRow kk in dataRowPurshesReturn)
                            {
                                if (kk["InvPayMethod"].ToString() == kd["InvPayMethod"].ToString())
                                {
                                    sm = kk["InvNetLocCur"].ToString();
                                    smt = kk["InvAddTax"].ToString(); break;
                                }
                                kk.SetField("CashNet", 0);
                                kk.SetField("CreditNet", 0);
                                kk.SetField("NetworkNet", 0);
                            }

                            {
                                string ssn = "";
                                if (kd["InvPayMethod"].ToString().Contains("ق"))
                                    ssn = "CashNet";
                                else
                                     if (kd["InvPayMethod"].ToString().Contains("ج"))
                                    ssn = "CreditNet";
                                else if (kd["InvPayMethod"].ToString().Contains("ش"))
                                    ssn = "NetworkNet";

                                string sn2 = "";
                                try
                                {
                                    sn2 = kd["InvNetLocCur"].ToString();

                                }
                                catch
                                {
                                    sn2 = "0";
                                }
                                try
                                {
                                    kd.SetField(ssn, double.Parse(sn2) - double.Parse(sm));
                                }
                                catch
                                {

                                }
                            }
                            string n2 = "";
                            try
                            {
                                n2 = kd["InvAddTax"].ToString();

                            }
                            catch
                            {
                                n2 = "0";
                            }
                            string n = "";
                            if (kd["InvPayMethod"].ToString().Contains("ق"))
                                n = "CashTaxNet";
                            else
                                 if (kd["InvPayMethod"].ToString().Contains("ج"))
                                n = "CreditTaxNet";
                            else if (kd["InvPayMethod"].ToString().Contains("ش"))
                                n = "NetworkTaxNet";
                            try
                            {
                                kd.SetField(n, double.Parse(n2) - double.Parse(smt));
                            }
                            catch
                            {
                                kd.SetField(n, double.Parse(n2) - double.Parse(smt));

                            }



                        }


                    }
                }
                DataTable tb3 = new DataTable();
                tb3.Columns.Add("CompanyName");
                tb3.Columns.Add("Cash");
                tb3.Columns.Add("Credit");
                tb3.Columns.Add("Network");
                tb3.Columns.Add("Return");
                tb3.Columns.Add("Net");
                tb3.Columns.Add("Tax");

                DataTable tb4 = new DataTable();
                tb4.Columns.Add("InvNameA");
                tb4.Columns.Add("Cash");
                tb4.Columns.Add("Credit");
                tb4.Columns.Add("Network");
                tb4.Columns.Add("Return");
                tb4.Columns.Add("Net");
                tb4.Columns.Add("Tax");
                tb4.Columns.Add("Type");

                List<string> Mndobs = new List<string>();
                if (tb.Rows.Count > 0)
                {
                    foreach (DataRow k in tb.Rows)
                    {
                        if (!Mndobs.Contains(k["InvNamA"].ToString()))// (k["InvTyp"].ToString()=="1"|| k["InvTyp"].ToString() == "2"))
                        {
                            DataRow rw = tb4.NewRow
                                   ();
                            rw["InvNameA"] = k["InvNamA"];

                            rw["Tax"] = "0";
                            rw["Net"] = k["InvNetLocCur"];
                            double xx = 0;
                             
                            for (int i = 0; i < tb.Rows.Count; i++)
                            {
                                if (tb.Rows[i]["InvTyp"].ToString() == "1" || tb.Rows[i]["InvTyp"].ToString() == "3")
                                {
                                    //if (tb.Rows[i]["InvTyp"].ToString() == "1")
                                    {
                                        if (tb.Rows[i]["InvNamA"].ToString() == k["InvNamA"].ToString())
                                        {
                                            string ss = rw["Tax"].ToString();
                                            if (ss == "") ss = "";
                                            string vsav= tb.Rows[i]["InvAddTax"].ToString();
                                            double dvdd = double.Parse(ss) + double.Parse(vsav);
                                            rw["Tax"] = dvdd.ToString();
                                            if (double.Parse(tb.Rows[i]["CashPayLocCur"].ToString())>0)
                                            {
                                                string sv = rw["Cash"].ToString();
                                                if (sv == "") sv = "0";
                                                string sv2 = tb.Rows[i]["CashPayLocCur"].ToString();
                                                if (sv2 == "") sv2 = "0";
                                                double xz = double.Parse(sv2) + double.Parse(sv);

                                                rw["Cash"] = xz.ToString();
                                            }

                                            if (double.Parse(tb.Rows[i]["CreditPay"].ToString())>0)
                                            {
                                                string sv = rw["Credit"].ToString();
                                                if (sv == "") sv = "0";
                                                string sv2 = tb.Rows[i]["CreditPay"].ToString();
                                                if (sv2 == "") sv2 = "0";
                                                double xz = double.Parse(sv2) + double.Parse(sv);

                                                rw["Credit"] = xz.ToString();
                                            }
                                            if (double.Parse(tb.Rows[i]["NetworkPayLocCur"].ToString()) > 0)
                                            {
                                                string sv = rw["Network"].ToString();
                                                if (sv == "") sv = "0";
                                                string sv2 = tb.Rows[i]["NetworkPayLocCur"].ToString();
                                                if (sv2 == "") sv2 = "0";
                                                double xz = double.Parse(sv2) + double.Parse(sv);

                                                rw["Network"] = xz.ToString();
                                            }
                                        }
                                    }
                                   
                                    rw["Return"] = xx.ToString();
                                    if (rw["Cash"].ToString() == "") rw["Cash"] = "0";

                                    if (rw["Net"].ToString() == "") rw["Net"] = "0";
                                    if (rw["Credit"].ToString() == "") rw["Credit"] = "0";
                                    if (rw["Network"].ToString() == "") rw["Network"] = "0";

                                    if (rw["Tax"].ToString() == "") rw["Tax"] = "0";
                                    rw["Type"] = k["InvTyp"].ToString();

                                }

                                else if (tb.Rows[i]["InvTyp"].ToString() == "2" || tb.Rows[i]["InvTyp"].ToString() == "4")
                                {
                                     
                                    {
                                        if (tb.Rows[i]["InvNamA"].ToString() == k["InvNamA"].ToString())
                                        {
                                            string ss = rw["Tax"].ToString();
                                            if (ss == "") ss = "";
                                            string vsav = tb.Rows[i]["InvAddTax"].ToString();
                                            double dvdd = double.Parse(ss) + double.Parse(vsav);
                                            rw["Tax"] = dvdd.ToString();

                                            if (double.Parse(tb.Rows[i]["CashPayLocCur"].ToString()) > 0)
                                            {
                                                string sv = rw["Cash"].ToString();
                                                if (sv == "") sv = "0";
                                                string sv2 = tb.Rows[i]["CashPayLocCur"].ToString();
                                                if (sv2 == "") sv2 = "0";
                                                double xz = double.Parse(sv2) + double.Parse(sv);

                                                rw["Cash"] = xz.ToString();
                                            }
                                            
                                            if (double.Parse(tb.Rows[i]["NetworkPayLocCur"].ToString()) > 0)
                                            {
                                                string sv = rw["Credit"].ToString();
                                                if (sv == "") sv = "0";
                                                string sv2 = tb.Rows[i]["NetworkPayLocCur"].ToString();
                                                if (sv2 == "") sv2 = "0";
                                                double xz = double.Parse(sv2) + double.Parse(sv);

                                                rw["Credit"] = xz.ToString();
                                            }
                                            if (double.Parse(tb.Rows[i]["CreditPay"].ToString()) > 0)
                                            {
                                                string sv = rw["Network"].ToString();
                                                if (sv == "") sv = "0";
                                                string sv2 = tb.Rows[i]["CreditPay"].ToString();
                                                if (sv2 == "") sv2 = "0";
                                                double xz = double.Parse(sv2) + double.Parse(sv);

                                                rw["Network"] = xz.ToString();
                                            }
                                        }
                                    }
                                    
                                    rw["Return"] = xx.ToString();
                                    if (rw["Cash"].ToString() == "") rw["Cash"] = "0";

                                    if (rw["Net"].ToString() == "") rw["Net"] = "0";
                                    if (rw["Credit"].ToString() == "") rw["Credit"] = "0";
                                    if (rw["Network"].ToString() == "") rw["Network"] = "0";

                                    if (rw["Tax"].ToString() == "") rw["Tax"] = "0";
                                    rw["Type"] = k["InvTyp"].ToString();
                                   

                                }
                             
                            }
                            tb4.Rows.Add(rw);
                            Mndobs.Add(k["InvNamA"].ToString());

                        }

                    }
                
                }
                Mndobs.Clear();
                if (tb2.Rows.Count>0)
                {
                    foreach(DataRow k in tb2.Rows)
                    {
                        if (!Mndobs.Contains(k["MndobName"].ToString()))
                        {
                            DataRow rw = tb3.NewRow
                                   ();
                            rw["CompanyName"] = k["MndobName"];

                            rw["Tax"] = "0";// k["InvAddTax"];
                            rw["Net"] = k["InvNetLocCur"];
                            double xx = 0;
                            double xx1 = 0;
                            double xx2 = 0;
                            for (int i = 0; i < tb2.Rows.Count; i++)
                            {
                                if (tb2.Rows[i]["InvTyp"].ToString() == "1")
                                {
                                    if (tb2.Rows[i]["MndobName"].ToString() == k["MndobName"].ToString())
                                    {
                                        string ss = rw["Tax"].ToString();
                                        if (ss == "") ss = "";
                                        string vsav = tb2.Rows[i]["InvAddTax"].ToString();
                                        double dvdd = double.Parse(ss) + double.Parse(vsav);
                                        rw["Tax"] = dvdd.ToString();
                                        xx1+= double.Parse(vsav);

                                        if (double.Parse(tb2.Rows[i]["CashPayLocCur"].ToString()) > 0)
                                        {
                                            string sv = rw["Cash"].ToString();
                                            if (sv == "") sv = "0";
                                            string sv2= tb2.Rows[i]["CashPayLocCur"].ToString();
                                            if (sv2 == "") sv2 = "0";
                                            double xz = double.Parse(sv2) + double.Parse(sv);
                                           
                                            rw["Cash"] = xz.ToString();
                                        }
                                     
                                          if (tb2.Rows[i]["CreditPay"].ToString().Contains("ج"))
                                        {
                                            string sv = rw["Credit"].ToString();
                                            if (sv == "") sv = "0";
                                            string sv2 = tb2.Rows[i]["CreditPay"].ToString();
                                            if (sv2 == "") sv2 = "0";
                                            double xz = double.Parse(sv2) + double.Parse(sv);
                                       
                                            rw["Credit"] =xz.ToString();
                                        }
                                        if (double.Parse(tb2.Rows[i]["NetworkPayLocCur"].ToString()) > 0)
                                        {
                                            string sv = rw["Network"].ToString();
                                            if (sv == "") sv = "0";
                                            string sv2 = tb2.Rows[i]["NetworkPayLocCur"].ToString();
                                            if (sv2 == "") sv2 = "0";
                                            double xz = double.Parse(sv2) + double.Parse(sv);
                                           
                                            rw["Network"] = xz.ToString();
                                        }
                                    }
                                }else if (tb2.Rows[i]["InvTyp"].ToString() == "3")
                                {
                                    if (tb2.Rows[i]["MndobName"].ToString() == k["MndobName"].ToString())
                                    {
                                        string ss = rw["Tax"].ToString();
                                        if (ss == "") ss = "";
                                            string vsav = tb2.Rows[i]["InvAddTax"].ToString();
                                        double dvdd = double.Parse(ss) - double.Parse(vsav);
                                        rw["Tax"] = dvdd.ToString();
                                        xx2+= double.Parse(vsav);
                                        string tsss = tb2.Rows[i]["InvNetLocCur"].ToString();
                                        if (tsss == "") tsss = "0";
                                        xx +=double.Parse( tsss);
                                    }
                                }
                            }
                            rw["Return"] = xx.ToString();
                            if (rw["Cash"].ToString() == "") rw["Cash"] = "0";

                            if (rw["Net"].ToString() == "") rw["Net"] = "0";
                            if (rw["Credit"].ToString() == "") rw["Credit"] = "0";
                            if (rw["Network"].ToString() == "") rw["Network"] = "0";
                            rw["Tax"] = xx1 - xx2;
                            if (rw["Tax"].ToString() == "") rw["Tax"] = "0";

                            tb3.Rows.Add(rw);
                            Mndobs.Add(k["MndobName"].ToString());
                        }


                    }
                }

                if (tb.Rows.Count>0)
                { 
                    FastReport.Report rpt = new FastReport.Report();
                    bool sss = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(1, 1) == "0") ? true : false);
                    string en = (LangArEn == 0 ? "Reports" : "ReportsE");
                    if (sss)
                    {

                   if(radioButton2.Checked==true)
                           rpt.Load(Application.StartupPath + "\\Rpt\\" + en + "\\RepInvTotals.frx");
                   
                   else
                    if(radioButton3.Checked==true)        
                            rpt.Load(Application.StartupPath + "\\Rpt\\" + en + "\\RepInvTotalsWidth.frx");


                        else if (radioButton4.Checked == true) 
                            rpt.Load(Application.StartupPath + "\\Rpt\\" + en + "\\RepInvTotalsWidth2.frx");

                    }
                    else
                        rpt.Load(Application.StartupPath + "\\Rpt\\" + en + "\\RepInvTotalsCashier.frx");

                    Utilites.AddTarwisa(rpt);
                  
                    tb.TableName = "item";
                    tb3.TableName = "item2";
                    DataSet dts = new DataSet();
                    dts.Tables.Add(tb);
                    tb4.TableName = "item3";
                    dts.Tables.Add(tb4);
                    dts.Tables.Add(tb3);
                    rpt.RegisterData(dts);


                    rpt.SetParameterValue("HDate", too);
                    rpt.SetParameterValue("GDate", from);
                    rpt.SetParameterValue("totPurchaes", totPurchaes);
                    rpt.SetParameterValue("totPurchaesReturn", totPurchaesReturn);
                    rpt.SetParameterValue("netseles", totSales - totSaleReturn);
                    rpt.SetParameterValue("netpur", totPurchaes - totPurchaesReturn);

                    FrmReport frm = new FrmReport();
                    this.TopMost = false;
                    
                    if (VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "1")
                    {
                        if (!flag)
                        {
                            rpt.Show(frm);
                            frm.Show();
                        }else
                        {
                            rpt.Design(frm);
                            frm.Show();

                        }
                    } else
                    {
                    FrmReportsViewer.PrintSetFsOut(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);

                    }
                }
                else
                    MessageBox.Show((LangArEn==0?"لا يوجد بيانات لعرضها ":"There is no Details"));

            }
            catch(Exception ex)
            {


                MessageBox.Show(ex.Message);
            }

             
        }
        //private string BuildRuleList(string str)
        //{
        //    int iiCnt;
        //    object obj;
        //    object[] tag;
            
        //    bool flag;
        //    HijriGregDates dateFormatter = new HijriGregDates();
        //    ////if (this.combobox_RepType.SelectedIndex == 1)
        //    ////{
        //    ////    str = " Where (T_INVHED.InvTyp = 1 or T_INVHED.InvTyp = 3) ";
        //    ////}
        //    ////else
        //    ////{
        //    ////    str = (this.combobox_RepType.SelectedIndex == 2 ? " Where (T_INVHED.InvTyp = 1 or T_INVHED.InvTyp = 2) " : string.Concat(" Where T_INVHED.InvTyp = ", this.CmbInvType.SelectedValue.ToString()));
        //    ////}
        //    string Rule = str;

        //    //if (!string.IsNullOrEmpty(this.txtMFromNo.Text))
        //    //{
        //    //    obj = Rule;
        //    //    tag = new object[] { obj, " and ", this.txtMFromNo.Tag, " >= ", this.txtMFromNo.Text.Trim() };
        //    //    Rule = string.Concat(tag);
        //    //}
        //    //if (!string.IsNullOrEmpty(this.txtMIntoNo.Text))
        //    //{
        //    //    obj = Rule;
        //    //    tag = new object[] { obj, " and ", this.txtMIntoNo.Tag, " <= ", this.txtMIntoNo.Text.Trim() };
        //    //    Rule = string.Concat(tag);
        //    //}
        //    //if (!string.IsNullOrEmpty(this.txtCostNo.Text))
        //    //{
        //    //    obj = Rule;
        //    //    tag = new object[] { obj, " and ", this.txtCostNo.Tag, " = ", this.txtCostNo.Text.Trim() };
        //    //    Rule = string.Concat(tag);
        //    //}
        //    //if (!string.IsNullOrEmpty(this.txtCustNo.Text))
        //    //{
        //    //    obj = Rule;
        //    //    tag = new object[] { obj, " and ", this.txtCustNo.Tag, " = '", this.txtCustNo.Text.Trim(), "'" };
        //    //    Rule = string.Concat(tag);
        //    //}
        //    //if (!string.IsNullOrEmpty(this.txtSuppNo.Text))
        //    //{
        //    //    obj = Rule;
        //    //    tag = new object[] { obj, " and ", this.txtSuppNo.Tag, " = '", this.txtSuppNo.Text.Trim(), "'" };
        //    //    Rule = string.Concat(tag);
        //    //}
        //    //if (!string.IsNullOrEmpty(this.txtLegNo.Text))
        //    //{
        //    //    obj = Rule;
        //    //    tag = new object[] { obj, " and ", this.txtLegNo.Tag, " = ", this.txtLegNo.Text.Trim() };
        //    //    Rule = string.Concat(tag);
        //    //}
        //    //if (!string.IsNullOrEmpty(this.txtUserNo.Text))
        //    //{
        //    //    if ((!File.Exists(string.Concat(Application.StartupPath, "\\Script\\SecriptInv.dll")) ? true : VarGeneral.InvType != 1))
        //    //    {
        //    //        obj = Rule;
        //    //        tag = new object[] { obj, " and ", this.txtUserNo.Tag, " = '", this.txtUserNo.Text.Trim(), "'" };
        //    //        Rule = string.Concat(tag);
        //    //    }
        //    //    else
        //    //    {
        //    //        Rule = string.Concat(Rule, " and  T_INVHED.UserNew  = '", this.txtUserNo.Text.Trim(), "'");
        //    //    }
        //    //}
        //    //if ((!VarGeneral.CheckDate(this.txtMFromDate.Text) ? false : this.txtMFromDate.Text.Length == 10))
        //    //{
        //    //    if (!this.checkBox_DatePay.Checked)
        //    //    {
        //    //        Rule = (int.Parse(this.txtMFromDate.Text.Substring(0, 4)) >= 1800 ? string.Concat(Rule, " and  T_INVHED.GDat  >= '", dateFormatter.FormatGreg(this.txtMFromDate.Text, "yyyy/MM/dd"), "'") : string.Concat(Rule, " and  T_INVHED.HDat  >= '", dateFormatter.FormatHijri(this.txtMFromDate.Text, "yyyy/MM/dd"), "'"));
        //    //    }
        //    //    else
        //    //    {
        //    //        Rule = string.Concat(Rule, " and  T_INVHED.EstDat  >= '", dateFormatter.FormatHijri(this.txtMFromDate.Text, "yyyy/MM/dd"), "'");
        //    //    }
        //    //}
        //    //if ((!VarGeneral.CheckDate(this.txtMToDate.Text) ? false : this.txtMToDate.Text.Length == 10))
        //    //{
        //    //    if (!this.checkBox_DatePay.Checked)
        //    //    {
        //    //        Rule = (int.Parse(this.txtMToDate.Text.Substring(0, 4)) >= 1800 ? string.Concat(Rule, " and  T_INVHED.GDat  <= '", dateFormatter.FormatGreg(this.txtMToDate.Text, "yyyy/MM/dd"), "'") : string.Concat(Rule, " and  T_INVHED.HDat  <= '", dateFormatter.FormatHijri(this.txtMToDate.Text, "yyyy/MM/dd"), "'"));
        //    //    }
        //    //    else
        //    //    {
        //    //        Rule = string.Concat(Rule, " and  T_INVHED.EstDat  <= '", dateFormatter.FormatHijri(this.txtMToDate.Text, "yyyy/MM/dd"), "'");
        //    //    }
        //    //}
        //    //if (this.radioButton_Del0.Checked)
        //    //{
        //    //    obj = Rule;
        //    //    tag = new object[] { obj, " and ", this.CmbDeleted.Tag, " != 1 " };
        //    //    Rule = string.Concat(tag);
        //    //}
        //    //else if (this.radioButton_Del2.Checked)
        //    //{
        //    //    obj = Rule;
        //    //    tag = new object[] { obj, " and ", this.CmbDeleted.Tag, " = 1 " };
        //    //    Rule = string.Concat(tag);
        //    //}
        //    //if (this.radioButton_ِReturn0.Checked)
        //    //{
        //    //    obj = Rule;
        //    //    tag = new object[] { obj, " and ", this.CmbReturn.Tag, " != 1 " };
        //    //    Rule = string.Concat(tag);
        //    //}
        //    //else if (this.radioButton_ِReturn2.Checked)
        //    //{
        //    ////    obj = Rule;
        //    ////    tag = new object[] { obj, " and ", this.CmbReturn.Tag, " = 1 " };
        //    ////    Rule = string.Concat(tag);
        //    ////}
        //    //string RuleInvType = ""; int rc = FlexType.Rows.Count; if (rc == 3) rc--;
        //    //for (iiCnt = 0; iiCnt < rc; iiCnt++)
        //    //{
        //    //    if ((bool)this.FlexType.GetData(iiCnt, 0))
        //    //    {
        //    //        if (!string.IsNullOrEmpty(RuleInvType))
        //    //        {
        //    //            RuleInvType = string.Concat(RuleInvType, " or ");
        //    //        }
        //    //        obj = RuleInvType;
        //    //        tag = new object[] { obj, this.FlexType.Tag, "  = ", iiCnt };
        //    //        RuleInvType = string.Concat(tag);
        //    //    }

        //    //}
        //    //if (FlexType.Rows.Count == 3)
        //    //{
        //    //    RuleInvType = "(" + RuleInvType + ")";
        //    //    if ((bool)this.FlexType.GetData(2, 0))
        //    //    {
        //    //        if (string.IsNullOrEmpty(RuleInvType))
        //    //        {
        //    //            obj = RuleInvType;
        //    //            tag = new object[] { obj, this.FlexType.Tag, "  = ", iiCnt };
        //    //            RuleInvType = string.Concat(tag);
        //    //        }

        //    //        obj = RuleInvType;
        //    //        tag = new object[] { obj, " or (T_INVHED.InvCash ='  شبكـــة  ' or T_INVHED.InvCash = 'الشبكة' or T_INVHED.InvCash = 'شبكـــة' or T_INVHED.InvCash = '  شبكـــة  ' )" };
        //    //        RuleInvType = string.Concat(tag);
        //    //    }
        //    //    else
        //    //    {
        //    //        if (string.IsNullOrEmpty(RuleInvType))
        //    //        {
        //    //            obj = RuleInvType;
        //    //            tag = new object[] { obj, this.FlexType.Tag, "  = ", iiCnt };
        //    //            RuleInvType = string.Concat(tag);
        //    //        }

        //    //        obj = RuleInvType;
        //    //        tag = new object[] { obj, " and (T_INVHED.InvCash !='  شبكـــة  ' and T_INVHED.InvCash != 'الشبكة' and T_INVHED.InvCash != 'شبكـــة' and T_INVHED.InvCash != '  شبكـــة  ' )" };
        //    //        RuleInvType = string.Concat(tag);
        //    //    }

        //    //}

        //    //if (!string.IsNullOrEmpty(RuleInvType))
        //    //{
        //    //    Rule = string.Concat(Rule, " and (", RuleInvType, ")");
        //    //}
         
        //    //if (this.checkBox_DatePay.Checked)
        //    //{
        //    //    Rule = string.Concat(Rule, " and ( T_INVHED.EstDat != '' )");
        //    //}
        //    //if (!this.switchButton_OrderTyp.Value)
        //    //{
        //    //    flag = true;
        //    //}
        //    //else
        //    //{
        //    //    flag = (this.radioButton_In.Checked || this.radioButton_Out.Checked ? false : !this.radioButton_Delivery.Checked);
        //    //}
        //    //if (!flag)
        //    //{
        //    //    RuleInvType = "";
        //    //    for (iiCnt = 0; iiCnt < 3; iiCnt++)
        //    //    {
        //    //        if ((iiCnt != 0 ? false : this.radioButton_In.Checked))
        //    //        {
        //    //            if (!string.IsNullOrEmpty(RuleInvType))
        //    //            {
        //    //                RuleInvType = string.Concat(RuleInvType, " or ");
        //    //            }
        //    //            RuleInvType = string.Concat(RuleInvType, " OrderTyp = ", iiCnt);
        //    //        }
        //    //        if ((iiCnt != 1 ? false : this.radioButton_Out.Checked))
        //    //        {
        //    //            if (!string.IsNullOrEmpty(RuleInvType))
        //    //            {
        //    //                RuleInvType = string.Concat(RuleInvType, " or ");
        //    //            }
        //    //            RuleInvType = string.Concat(RuleInvType, " OrderTyp = ", iiCnt);
        //    //        }
        //    //        if ((iiCnt != 2 ? false : this.radioButton_Delivery.Checked))
        //    //        {
        //    //            if (!string.IsNullOrEmpty(RuleInvType))
        //    //            {
        //    //                RuleInvType = string.Concat(RuleInvType, " or ");
        //    //            }
        //    //            RuleInvType = string.Concat(RuleInvType, " OrderTyp = ", iiCnt);
        //    //        }
        //    //    }
        //    //    if (!string.IsNullOrEmpty(RuleInvType))
        //    //    {
        //    //        Rule = string.Concat(Rule, " and (", RuleInvType, ") and T_INVHED.InvId is not null ");
        //    //    }
        //    //}
        //    //if (!this.radioButton_Tax1.Checked)
        //    //{
        //    //    Rule = (!this.radioButton_Tax0.Checked ? string.Concat(Rule, " and T_INVHED.InvAddTax <= 0 ") : string.Concat(Rule, " and T_INVHED.InvAddTax > 0 "));
        //    //}
        //    return Rule;
        //}
        private void ButExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void RibunButtons()
        {
            radioButton_Tax0.Text = (LangArEn == 0 ? "بالضريبة " : "With Tax");

            radioButton_Tax2.Text = (LangArEn == 0 ? "بدون الضريبة " : "without Tax");

            radioButton_Tax1.Text = (LangArEn == 0 ? "الكل " : " ALL ");

            label1.Text = (LangArEn == 0 ? "من" : "From");

            label2.Text = (LangArEn == 0 ? "الى" : "TO");
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ButExit.Text = "خــــروج Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "طبـــاعة F5" : "عــــرض F5");
                groupBox4.Text = "التاريــــخ";
                Text = "إجماليات الفواتير";
               

                //this.FlexType.Rows.Count = 3;
                //this.FlexType.SetData(0, 0, true);
                //this.FlexType.SetData(0, 1, "نقدي");
                //this.FlexType.SetData(1, 0, true);
                //this.FlexType.SetData(1, 1, "اجل");
                //this.FlexType.SetData(2, 0, true);
                //this.FlexType.SetData(2, 1, "شبكة");

            }
            else
            {
                //this.FlexType.Rows.Count = 3;
                //this.FlexType.SetData(0, 0, true);
                //this.FlexType.SetData(0, 1, "Cash");
                //this.FlexType.SetData(1, 0, true);
                //this.FlexType.SetData(1, 1, "Credit");
                //this.FlexType.SetData(2, 0, true);
                //this.FlexType.SetData(2, 1, "Network");

                ButExit.Text = "Exit Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "Print F5" : "Show F5");
                groupBox4.Text = "Date";
                Text = "Totals Of Net Invoices";
            }
        }
        private void FRAccountTax_Load(object sender, EventArgs e)
        {
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
        private void txtMToDate_Click(object sender, EventArgs e)
        {
            txtMToDate.SelectAll();
        }
        private void txtMFromDate_Click(object sender, EventArgs e)
        {
            txtMFromDate.SelectAll();
        }
        private void button_SrchAccFrom_Click(object sender, EventArgs e)
        {
             
       
        }
        private void button_SrchCostNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("Cst_No", new ColumnDictinary("الرقم", "No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_CstTbl";
            frm.TopMost = true;
            frm.ShowDialog();
        }
        private void button_SrchUsrNo_Click(object sender, EventArgs e)
        {
            this.columns_Names_visible.Clear();
            this.columns_Names_visible.Add("UsrNo", new FRInvTotals.ColumnDictinary("رقم المستخدم", "User No", true, ""));
            this.columns_Names_visible.Add("UsrNamA", new FRInvTotals.ColumnDictinary("الاسم عربي", "Arabic Name", true, ""));
            this.columns_Names_visible.Add("UsrNamE", new FRInvTotals.ColumnDictinary("الاسم الانجليزي", "English Name", true, ""));
            FrmSearch frm = new FrmSearch()
            {
                Tag = this.LangArEn
            };
            foreach (KeyValuePair<string, FRInvTotals.ColumnDictinary> kvp in this.columns_Names_visible)
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
        private void button_SrchPruchaTax_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, ""));
            columns_Names_visible.Add("TaxNo", new ColumnDictinary("الرقم الضريبي", "Tax No", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            if (VarGeneral.SSSTyp == 0)
            {
                VarGeneral.SFrmTyp = "T_AccDef";
            }
            else
            {
                VarGeneral.SFrmTyp = "AccDefID_Setting";
            }
            frm.TopMost = true;
            frm.ShowDialog();
           
        }

        private void ribbonBar1_ItemClick(object sender, EventArgs e)
        {

        }


        private void button_SrchLegNo_Click(object sender, EventArgs e)
        {
            this.columns_Names_visible.Clear();
            this.columns_Names_visible.Add("Mnd_No", new FRInvTotals.ColumnDictinary("رقم المندوب", "Commissary No", true, ""));
            this.columns_Names_visible.Add("Arb_Des", new FRInvTotals.ColumnDictinary("الاسم عربي", "Arabic Name", true, ""));
            this.columns_Names_visible.Add("Eng_Des", new FRInvTotals.ColumnDictinary("الاسم الانجليزي", "English Name", true, ""));
            FrmSearch frm = new FrmSearch()
            {
                Tag = this.LangArEn
            };
            foreach (KeyValuePair<string, FRInvTotals.ColumnDictinary> kvp in this.columns_Names_visible)
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
            this.columns_Names_visible.Add("AccDef_No", new FRInvTotals.ColumnDictinary("الرقم ", " No", true, ""));
            this.columns_Names_visible.Add("Arb_Des", new FRInvTotals.ColumnDictinary("الاسم عربي", "Arabic Name", true, ""));
            this.columns_Names_visible.Add("Eng_Des", new FRInvTotals.ColumnDictinary("الاسم الانجليزي", "English Name", true, ""));
            this.columns_Names_visible.Add("AccDef_ID", new FRInvTotals.ColumnDictinary(" ", " ", false, ""));
            FrmSearch frm = new FrmSearch()
            {
                Tag = this.LangArEn
            };
            foreach (KeyValuePair<string, FRInvTotals.ColumnDictinary> kvp in this.columns_Names_visible)
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

        private void button_SrchCustNo_Click(object sender, EventArgs e)
        {
            this.columns_Names_visible.Clear();
            this.columns_Names_visible.Add("AccDef_No", new FRInvTotals.ColumnDictinary("الرقم ", " No", true, ""));
            this.columns_Names_visible.Add("Arb_Des", new FRInvTotals.ColumnDictinary("الاسم عربي", "Arabic Name", true, ""));
            this.columns_Names_visible.Add("Eng_Des", new FRInvTotals.ColumnDictinary("الاسم الانجليزي", "English Name", true, ""));
            this.columns_Names_visible.Add("AccDef_ID", new FRInvTotals.ColumnDictinary(" ", " ", false, ""));
            this.columns_Names_visible.Add("Mobile", new FRInvTotals.ColumnDictinary("الجوال", "Mobile", false, ""));
            FrmSearch frm = new FrmSearch()
            {
                Tag = this.LangArEn
            };
            foreach (KeyValuePair<string, FRInvTotals.ColumnDictinary> kvp in this.columns_Names_visible)
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
        bool flag = false;
        private void label7_Click(object sender, EventArgs e)
        {
          if(Program.isdevelopermachine())
            flag = !flag;

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
