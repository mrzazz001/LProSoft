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
                this.txtMFromDate.Text = dateFormatter.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                this.txtMToDate.Text = dateFormatter.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
            }
        }
        protected override void OnLoad(EventArgs e)
        {
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
ORDER BY dbo.T_INVHED.InvTyp";
        private void ButOk_Click(object sender, EventArgs e)
        {
             
            double totSales = 0.0,totSaleReturn=0.0;
            double totPurchaes = 0.0, totPurchaesReturn = 0.0 ;
            try
            {
                string from="",too="";

                HijriGregDates dateFormatter = new HijriGregDates();

                if (VarGeneral.CheckDate(txtMFromDate.Text) && txtMFromDate.Text.Length == 10)
                {
                    from = ((int.Parse(txtMFromDate.Text.Substring(0, 4)) >= 1800) ? ( dateFormatter.FormatGreg(txtMFromDate.Text, "yyyy/MM/dd") ) : (dateFormatter.FormatHijri(txtMFromDate.Text, "yyyy/MM/dd") ));
                }
                if (VarGeneral.CheckDate(txtMToDate.Text) && txtMToDate.Text.Length == 10)
                {
                    too = ((int.Parse(txtMToDate.Text.Substring(0, 4)) >= 1800) ? (dateFormatter.FormatGreg(txtMToDate.Text, "yyyy/MM/dd")) : (  dateFormatter.FormatHijri(txtMToDate.Text, "yyyy/MM/dd")));
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
                          CASE dbo.T_INVHED.InvCash WHEN 'نقـــدي' THEN 'نقـــدي' WHEN 'Cach' THEN 'نقـــدي' WHEN '  نقـــدي  ' THEN 'نقـــدي' WHEN '  أجـــل  ' THEN 'أجـــل' WHEN 'أجـــل' THEN 'أجـــل' WHEN 'الشبكة' THEN 'شبكـــة' WHEN '  شبكـــة  ' THEN 'شبكـــة' END
                          AS InvPayMethod
FROM            dbo.T_INVHED INNER JOIN
                         dbo.T_INVSETTING ON dbo.T_INVHED.InvTyp = dbo.T_INVSETTING.InvID
WHERE        (TTTTT) AND (dbo.T_INVHED.GDat >= 'FFFFF' AND dbo.T_INVHED.GDat <= 'TOOOOO')bbbbbbbbbb 
GROUP BY dbo.T_INVHED.InvTyp, dbo.T_INVSETTING.InvNamA,jjjjjjj
                         CASE dbo.T_INVHED.InvCash WHEN 'نقـــدي' THEN 'نقـــدي' WHEN 'Cach' THEN 'نقـــدي' WHEN '  نقـــدي  ' THEN 'نقـــدي' WHEN '  أجـــل  ' THEN 'أجـــل' WHEN 'أجـــل' THEN 'أجـــل' WHEN 'الشبكة' THEN 'شبكـــة' WHEN '  شبكـــة  ' THEN 'شبكـــة' END";


string dd = " (dbo.T_INVHED.IfDel <> 1)And (TTTTT)and(dbo.T_INVHED.IsTaxUse = RRRRR) AND (dbo.T_INVHED.GDat >= 'FFFFF') AND (dbo.T_INVHED.GDat <= 'TOOOOO') ";
string where = "dbo.T_INVHED.InvTyp =1 or dbo.T_INVHED.InvTyp=2 or dbo.T_INVHED.InvTyp=3 or dbo.T_INVHED.InvTyp=4";

                scc = scc.Replace("TTTTT", where);

                if(from=="")
                {
                    from = "2000/01/01";

                }
                if(too=="")
                {
                 too=   "2100/01/01";
                }
                string Rule = "";
                if (!this.radioButton_Tax1.Checked)
                {
                    Rule = (!this.radioButton_Tax0.Checked ? string.Concat(Rule, " and T_INVHED.InvAddTax <= 0 ") : string.Concat(Rule, " and T_INVHED.InvAddTax > 0 "));
                }
                string sccmd = "";
                scc = scc.Replace("TOOOOO", too).Replace("FFFFF", from);
                scc = scc.Replace("RRRRR", "1");
                
                
                scc = scc.Replace("xxxxxxxxxxxxxxx", dd);
               
                sccmd = scc.Replace("ffffffffffffffffff",   @"(STUFF((SELECT CAST(', ' + (xx.Arb_Des + ' | ' + xx.Eng_Des) AS VARCHAR(200))
         FROM T_Mndob xx
         WHERE(xx.Mnd_No = T_INVHED.MndNo)
         FOR XML PATH('')), 1, 2, '')) AS MndobName,").Replace("bbbbbbbbbb", " and T_INVHED.MndNo IS NOT NULL "+Rule).Replace("jjjjjjj", " T_INVHED.MndNo,"); ;
                scc = scc.Replace("bbbbbbbbbb", Rule);
                scc = scc.Replace("jjjjjjj", "");
                scc = scc.Replace("ffffffffffffffffff", "");


                DataTable tb =     DBUdate.DbUpdates.execute(scc, VarGeneral.BranchCS);
           DataTable tb2 = DBUdate.DbUpdates.execute(sccmd, VarGeneral.BranchCS);
                if (tb.Rows.Count != 0)
                {

                    if (tb.Rows.Count > 2)
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
                                string n = "";
                                if (kd["InvPayMethod"].ToString().Contains("ق"))
                                    n = "CashNet";
                                else
                                     if (kd["InvPayMethod"].ToString().Contains("ج"))
                                    n = "CreditNet";
                                else if (kd["InvPayMethod"].ToString().Contains("ش"))
                                    n = "NetworkNet";
                                string n2 = "";
                                try
                                {
                                    n2 = kd["InvNetLocCur"].ToString();

                                } catch
                                {
                                    n2 = "0";
                                }

                                try
                                {
                                    kd.SetField(n, double.Parse(n2) - double.Parse(sm));
                                }
                                catch
                                {
                                    kd.SetField(n, double.Parse(n2) - double.Parse(sm));

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

                if (tb2.Rows.Count != 0)
                {

                    if (tb2.Rows.Count > 2)
                    {
                        DataColumn cs = new DataColumn("CashNet");
                        tb2.Columns.Add(cs);

                        DataColumn cs2 = new DataColumn("CreditNet");
                        tb2.Columns.Add(cs2);

                        DataColumn cs3 = new DataColumn("NetworkNet");
                        tb2.Columns.Add(cs3);
                        DataColumn cs22 = new DataColumn("CashTaxNet");
                        tb2.Columns.Add(cs22);

                        DataColumn cs222 = new DataColumn("CreditTaxNet");
                        tb2.Columns.Add(cs222);

                        DataColumn cs32 = new DataColumn("NetworkTaxNet");
                        tb2.Columns.Add(cs32);

                        var dataRowsales = tb2.AsEnumerable().Where(x => x.Field<int>("InvTyp") == 1);

                        var dataRowsalesreturn = tb2.AsEnumerable().Where(x => x.Field<int>("InvTyp") == 3);


                        var dataRowPurshes = tb2.AsEnumerable().Where(x => x.Field<int>("InvTyp") == 2);

                        var dataRowPurshesReturn = tb2.AsEnumerable().Where(x => x.Field<int>("InvTyp") == 4);
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
                                string n = "";
                                if (kd["InvPayMethod"].ToString().Contains("ق"))
                                    n = "CashNet";
                                else
                                     if (kd["InvPayMethod"].ToString().Contains("ج"))
                                    n = "CreditNet";
                                else if (kd["InvPayMethod"].ToString().Contains("ش"))
                                    n = "NetworkNet";
                                string n2 = "";
                                try
                                {
                                    n2 = kd["InvNetLocCur"].ToString();

                                }
                                catch
                                {
                                    n2 = "0";
                                }

                                try
                                {
                                    kd.SetField(n, double.Parse(n2) - double.Parse(sm));
                                }
                                catch
                                {
                                    kd.SetField(n, double.Parse(n2) - double.Parse(sm));

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


                { 
                    FastReport.Report rpt = new FastReport.Report();
                    bool sss = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(1, 1) == "0") ? true : false);
                    string en = (LangArEn == 0 ? "Reports" : "ReportsE");
                    if (sss)
                        rpt.Load(Application.StartupPath + "\\Rpt\\" + en + "\\RepInvTotals.frx");
                    else
                        rpt.Load(Application.StartupPath + "\\Rpt\\" + en + "\\RepInvTotalsCashier.frx");

                    Utilites.AddTarwisa(rpt);

                    tb.TableName = "item";
                    tb2.TableName = "item2";
                    DataSet dts = new DataSet();
                    dts.Tables.Add(tb);

                    dts.Tables.Add(tb2);
                    dts.WriteXml(Application.StartupPath + "\\Rpt\\" + en + "\\RepInvTotals.xml");
                    rpt.RegisterData(tb, "item");

                    rpt.SetParameterValue("HDate", too);
                    rpt.SetParameterValue("GDate", from);
                    rpt.SetParameterValue("totPurchaes", totPurchaes);
                    rpt.SetParameterValue("totPurchaesReturn", totPurchaesReturn);
                    rpt.SetParameterValue("netseles", totSales - totSaleReturn);
                    rpt.SetParameterValue("netpur", totPurchaes - totPurchaesReturn);

                    FrmReport frm = new FrmReport();

                    if (VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "1")
                    {
                        rpt.Show(frm);
                        frm.Show();
                    } else
                    {
                    FrmReportsViewer.PrintSetFsOut(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);

                    }
                }
                
            }
            catch(Exception ex)
            {


                MessageBox.Show(ex.Message);
            }

             
        }
        private string BuildRuleList(string str)
        {
            int iiCnt;
            object obj;
            object[] tag;
            
            bool flag;
            HijriGregDates dateFormatter = new HijriGregDates();
            ////if (this.combobox_RepType.SelectedIndex == 1)
            ////{
            ////    str = " Where (T_INVHED.InvTyp = 1 or T_INVHED.InvTyp = 3) ";
            ////}
            ////else
            ////{
            ////    str = (this.combobox_RepType.SelectedIndex == 2 ? " Where (T_INVHED.InvTyp = 1 or T_INVHED.InvTyp = 2) " : string.Concat(" Where T_INVHED.InvTyp = ", this.CmbInvType.SelectedValue.ToString()));
            ////}
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
            //if (!string.IsNullOrEmpty(this.txtCustNo.Text))
            //{
            //    obj = Rule;
            //    tag = new object[] { obj, " and ", this.txtCustNo.Tag, " = '", this.txtCustNo.Text.Trim(), "'" };
            //    Rule = string.Concat(tag);
            //}
            //if (!string.IsNullOrEmpty(this.txtSuppNo.Text))
            //{
            //    obj = Rule;
            //    tag = new object[] { obj, " and ", this.txtSuppNo.Tag, " = '", this.txtSuppNo.Text.Trim(), "'" };
            //    Rule = string.Concat(tag);
            //}
            //if (!string.IsNullOrEmpty(this.txtLegNo.Text))
            //{
            //    obj = Rule;
            //    tag = new object[] { obj, " and ", this.txtLegNo.Tag, " = ", this.txtLegNo.Text.Trim() };
            //    Rule = string.Concat(tag);
            //}
            //if (!string.IsNullOrEmpty(this.txtUserNo.Text))
            //{
            //    if ((!File.Exists(string.Concat(Application.StartupPath, "\\Script\\SecriptInv.dll")) ? true : VarGeneral.InvType != 1))
            //    {
            //        obj = Rule;
            //        tag = new object[] { obj, " and ", this.txtUserNo.Tag, " = '", this.txtUserNo.Text.Trim(), "'" };
            //        Rule = string.Concat(tag);
            //    }
            //    else
            //    {
            //        Rule = string.Concat(Rule, " and  T_INVHED.UserNew  = '", this.txtUserNo.Text.Trim(), "'");
            //    }
            //}
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
            //if (this.radioButton_Del0.Checked)
            //{
            //    obj = Rule;
            //    tag = new object[] { obj, " and ", this.CmbDeleted.Tag, " != 1 " };
            //    Rule = string.Concat(tag);
            //}
            //else if (this.radioButton_Del2.Checked)
            //{
            //    obj = Rule;
            //    tag = new object[] { obj, " and ", this.CmbDeleted.Tag, " = 1 " };
            //    Rule = string.Concat(tag);
            //}
            //if (this.radioButton_ِReturn0.Checked)
            //{
            //    obj = Rule;
            //    tag = new object[] { obj, " and ", this.CmbReturn.Tag, " != 1 " };
            //    Rule = string.Concat(tag);
            //}
            //else if (this.radioButton_ِReturn2.Checked)
            //{
            ////    obj = Rule;
            ////    tag = new object[] { obj, " and ", this.CmbReturn.Tag, " = 1 " };
            ////    Rule = string.Concat(tag);
            ////}
            //string RuleInvType = ""; int rc = FlexType.Rows.Count; if (rc == 3) rc--;
            //for (iiCnt = 0; iiCnt < rc; iiCnt++)
            //{
            //    if ((bool)this.FlexType.GetData(iiCnt, 0))
            //    {
            //        if (!string.IsNullOrEmpty(RuleInvType))
            //        {
            //            RuleInvType = string.Concat(RuleInvType, " or ");
            //        }
            //        obj = RuleInvType;
            //        tag = new object[] { obj, this.FlexType.Tag, "  = ", iiCnt };
            //        RuleInvType = string.Concat(tag);
            //    }

            //}
            //if (FlexType.Rows.Count == 3)
            //{
            //    RuleInvType = "(" + RuleInvType + ")";
            //    if ((bool)this.FlexType.GetData(2, 0))
            //    {
            //        if (string.IsNullOrEmpty(RuleInvType))
            //        {
            //            obj = RuleInvType;
            //            tag = new object[] { obj, this.FlexType.Tag, "  = ", iiCnt };
            //            RuleInvType = string.Concat(tag);
            //        }

            //        obj = RuleInvType;
            //        tag = new object[] { obj, " or (T_INVHED.InvCash ='  شبكـــة  ' or T_INVHED.InvCash = 'الشبكة' or T_INVHED.InvCash = 'شبكـــة' or T_INVHED.InvCash = '  شبكـــة  ' )" };
            //        RuleInvType = string.Concat(tag);
            //    }
            //    else
            //    {
            //        if (string.IsNullOrEmpty(RuleInvType))
            //        {
            //            obj = RuleInvType;
            //            tag = new object[] { obj, this.FlexType.Tag, "  = ", iiCnt };
            //            RuleInvType = string.Concat(tag);
            //        }

            //        obj = RuleInvType;
            //        tag = new object[] { obj, " and (T_INVHED.InvCash !='  شبكـــة  ' and T_INVHED.InvCash != 'الشبكة' and T_INVHED.InvCash != 'شبكـــة' and T_INVHED.InvCash != '  شبكـــة  ' )" };
            //        RuleInvType = string.Concat(tag);
            //    }

            //}

            //if (!string.IsNullOrEmpty(RuleInvType))
            //{
            //    Rule = string.Concat(Rule, " and (", RuleInvType, ")");
            //}
         
            //if (this.checkBox_DatePay.Checked)
            //{
            //    Rule = string.Concat(Rule, " and ( T_INVHED.EstDat != '' )");
            //}
            //if (!this.switchButton_OrderTyp.Value)
            //{
            //    flag = true;
            //}
            //else
            //{
            //    flag = (this.radioButton_In.Checked || this.radioButton_Out.Checked ? false : !this.radioButton_Delivery.Checked);
            //}
            //if (!flag)
            //{
            //    RuleInvType = "";
            //    for (iiCnt = 0; iiCnt < 3; iiCnt++)
            //    {
            //        if ((iiCnt != 0 ? false : this.radioButton_In.Checked))
            //        {
            //            if (!string.IsNullOrEmpty(RuleInvType))
            //            {
            //                RuleInvType = string.Concat(RuleInvType, " or ");
            //            }
            //            RuleInvType = string.Concat(RuleInvType, " OrderTyp = ", iiCnt);
            //        }
            //        if ((iiCnt != 1 ? false : this.radioButton_Out.Checked))
            //        {
            //            if (!string.IsNullOrEmpty(RuleInvType))
            //            {
            //                RuleInvType = string.Concat(RuleInvType, " or ");
            //            }
            //            RuleInvType = string.Concat(RuleInvType, " OrderTyp = ", iiCnt);
            //        }
            //        if ((iiCnt != 2 ? false : this.radioButton_Delivery.Checked))
            //        {
            //            if (!string.IsNullOrEmpty(RuleInvType))
            //            {
            //                RuleInvType = string.Concat(RuleInvType, " or ");
            //            }
            //            RuleInvType = string.Concat(RuleInvType, " OrderTyp = ", iiCnt);
            //        }
            //    }
            //    if (!string.IsNullOrEmpty(RuleInvType))
            //    {
            //        Rule = string.Concat(Rule, " and (", RuleInvType, ") and T_INVHED.InvId is not null ");
            //    }
            //}
            //if (!this.radioButton_Tax1.Checked)
            //{
            //    Rule = (!this.radioButton_Tax0.Checked ? string.Concat(Rule, " and T_INVHED.InvAddTax <= 0 ") : string.Concat(Rule, " and T_INVHED.InvAddTax > 0 "));
            //}
            return Rule;
        }
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
    }
}
