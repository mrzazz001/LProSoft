using C1.Win.C1FlexGrid;
using CrystalDecisions.Shared;
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
    public partial  class FRInVatRep : Form
    {
        void avs(int arln)

        {
          //label3.Text = (arln == 0 ? "  ح.ضريبة المبيعـــــات :  " : "  H. Sales Tax:"); //Text = (arln == 0 ? "  المنــــــــــــــــــــدوب :  " : "  The delegate:"); label5.Text = (arln == 0 ? "  ح.ضريبة المشتريات :  " : "  H. Purchase Tax:"); groupBox4.Text = (arln == 0 ? "  حسب التاريخ  " : "  by date"); label1.Text = (arln == 0 ? "  مـــــن :  " : "  from:"); label2.Text = (arln == 0 ? "  إلـــــى :  " : "  to:"); label7.Text = (arln == 0 ? "  مركــــــز التكلفـــــــة :  " : "  Cost center:"); Text = "حساب الضريبة المستحقة"; this.Text = (arln == 0 ? "  حساب الضريبة المستحقة  " : "  Calculation of tax due");
        }
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
        private Panel PanelSpecialContainer;
        public Softgroup.NetResize.NetResize netResize1;
        private RibbonBar ribbonBar1;
        private TextBox txtSalesAccName;
        private TextBox txtCostCName;
        private TextBox txtCostCNo;
        private Label label5;
        private Label label7;
        private ButtonX button_SrchCostNo;
        private ButtonX button_SrchAccFrom;
        private GroupBox groupBox4;
        private Label label1;
        private Label label2;
        public TextBox txtSalesAccNo;
        public MaskedTextBox txtMToDate;
        public MaskedTextBox txtMFromDate;
        private TextBox txtPurchaesAccName;
        public TextBox txtPurchaesAccNo;
        private ButtonX button_SrchPruchaTax;
        private Label label3;
        private int LangArEn = 0;
        private T_User _User = new T_User();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private Stock_DataDataContext dbInstance;
        private C1.Win.C1Input.C1Button ButOk;
        private C1.Win.C1Input.C1Button ButExit;
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
        public FRInVatRep()
        {
            InitializeComponent(); this.Load += langloads;
            _User = dbc.StockUser(VarGeneral.UserNumber);
            HijriGregDates dateFormatter = new HijriGregDates();
            if (VarGeneral.Settings_Sys.Calendr.Value != 0)
            {
                HijriGreg.HijriGregDates ff = new HijriGreg.HijriGregDates();
               
                this.txtMFromDate.Text = dateFormatter.FormatHijri(ff.GregToHijri(ff.GDateAdd2(VarGeneral.Gdate, -365),"yyyy/MM/dd"), "yyyy/MM/dd");
                this.txtMToDate.Text = dateFormatter.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
            }
            else
            {
                HijriGreg. HijriGregDates ff = new HijriGreg.HijriGregDates();
               
                this.txtMFromDate.Text = dateFormatter.FormatGreg(ff.GDateAdd2(VarGeneral.Gdate, -365), "yyyy/MM/dd");
                this.txtMToDate.Text = dateFormatter.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
            }
           
            try
            {
                if (!(VarGeneral.SSSLev == "B") && !(VarGeneral.SSSLev == "F"))
                {
                    return;
                }
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
                    label7.Visible = true;
                    txtCostCNo.Visible = true;
                    button_SrchCostNo.Visible = true;
                    txtCostCName.Visible = true;
                }
                else
                {
                    label7.Visible = false;
                    txtCostCNo.Visible = false;
                    button_SrchCostNo.Visible = false;
                    txtCostCName.Visible = false;
                }
            }
            catch
            {
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
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptMaintenanceCars.dll"))
                {
                    //Text = ((LangArEn == 0) ? "نوع السيارة :" : "Car Type :");
                }
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptBus.dll"))
                {
                    label7.Text = ((LangArEn == 0) ? "الباص :" : "Bus :");
                    //Text = ((LangArEn == 0) ? "السائق :" : "Driver :");
                }
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptWaterPackages.dll"))
                {
                    //Text = ((LangArEn == 0) ? "العميــــــــل :" : "Customer :");
                    label7.Text = ((LangArEn == 0) ? "السيــارة :" : "Car :");
                }
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
            HijriGregDates dateFormatter = new HijriGregDates();
            string Rule = " ";
           
            if (VarGeneral.CheckDate(txtMFromDate.Text) && txtMFromDate.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMFromDate.Text.Substring(0, 4)) >= 1800) ? (Rule + "   T_INVHED.GDat  >= '" + dateFormatter.FormatGreg(txtMFromDate.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_INVHED.HDat  >= '" + dateFormatter.FormatHijri(txtMFromDate.Text, "yyyy/MM/dd") + "'"));
                Rule += " and ";
            }
            if (VarGeneral.CheckDate(txtMToDate.Text) && txtMToDate.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMToDate.Text.Substring(0, 4)) >= 1800) ? (Rule + "    T_INVHED.GDat  <= '" + dateFormatter.FormatGreg(txtMToDate.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_INVHED.HDat  <= '" + dateFormatter.FormatHijri(txtMToDate.Text, "yyyy/MM/dd") + "'"));
                Rule += " and ";
            }
            return Rule;
        }
        private void ButOk_Click(object sender, EventArgs e)
        {   double totSales = 0.0;
            double totPurchaes = 0.0;
            try
            {
                string scc = @"sELECT      fvc.InvTyp,case when fvc.InvTyp=1 then ' مبيعات' else 'مشتريات'end as NameOFInv,( case when  (SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.IsTaxUse > 0)and (dbo.T_INVHED.InvTyp=fvc.InvTyp
)) is null then 0 else 
 (SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.IsTaxUse > 0)and (dbo.T_INVHED.InvTyp=fvc.InvTyp
))
end )as TotalNetOfInvUsingTax

,case when ( SELECT         SUM( dbo.T_INVHED.InvAddTaxlLoc) AS Expr1
FROM            dbo.T_INVHED 
WHERE        (dbo.T_INVHED.IfDel <> 1) and (dbo.T_INVHED.InvTyp=fvc.InvTyp)and (dbo.T_INVHED.IsTaxUse=1)

)is null 

then 0 else 
( SELECT         SUM( dbo.T_INVHED.InvAddTaxlLoc) AS Expr1
FROM            dbo.T_INVHED 
WHERE        (dbo.T_INVHED.IfDel <> 1) and (dbo.T_INVHED.InvTyp=fvc.InvTyp)and (dbo.T_INVHED.IsTaxUse=1)
)
end
as ADDTAX
,
(case when ( (SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.IsTaxUse=1)and (dbo.T_INVHED.InvTyp=fvc.InvTyp
)) -( SELECT        SUM( dbo.T_INVHED.InvAddTaxlLoc)  AS Expr1
FROM            dbo.T_INVHED  
WHERE        (dbo.T_INVHED.IfDel <> 1)  and   (dbo.T_INVHED.InvTyp=fvc.InvTyp)and (dbo.T_INVHED.IsTaxUse=1)

) 

)is null then 0
else 
( (SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.IsTaxUse=1)and (dbo.T_INVHED.InvTyp=fvc.InvTyp
)) -( SELECT        SUM( dbo.T_INVHED.InvAddTaxlLoc)  AS Expr1
FROM            dbo.T_INVHED 
                      
WHERE        (dbo.T_INVHED.IfDel <> 1)  and (dbo.T_INVHED.InvTyp=fvc.InvTyp)and (dbo.T_INVHED.IsTaxUse=1)

) 

)
end)
as TotalNetOfInvUsingTaxwithoutTax
,
(case when 
(SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.IsTaxGaid = 0)and (dbo.T_INVHED.InvTyp=fvc.InvTyp
)) is  null
then 0
else
(SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.IsTaxGaid = 0)and (dbo.T_INVHED.InvTyp=fvc.InvTyp)
) 
end)

as TotalOfInvNotUsingTax


,

(case when ( (SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.IsTaxUse=1)and (dbo.T_INVHED.InvTyp=fvc.InvTyp
)) -( SELECT        SUM( dbo.T_INVHED.InvAddTaxlLoc)  AS Expr1
FROM            dbo.T_INVHED  
WHERE        (dbo.T_INVHED.IfDel <> 1)  and   (dbo.T_INVHED.InvTyp=fvc.InvTyp)and (dbo.T_INVHED.IsTaxUse=1)

) 

)is null then 0
else 
( (SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.IsTaxUse=1)and (dbo.T_INVHED.InvTyp=fvc.InvTyp
)) -( SELECT        SUM( dbo.T_INVHED.InvAddTaxlLoc)  AS Expr1
FROM            dbo.T_INVHED 
                      
WHERE        (dbo.T_INVHED.IfDel <> 1)  and (dbo.T_INVHED.InvTyp=fvc.InvTyp)and (dbo.T_INVHED.IsTaxUse=1)

) 

)
end)+
(case when 
(SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.IsTaxGaid = 0)and (dbo.T_INVHED.InvTyp=fvc.InvTyp
)) is  null
then 0
else
(SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.IsTaxGaid = 0)and (dbo.T_INVHED.InvTyp=fvc.InvTyp)
) 
end)as TotalInvOfThisTypeWithoutTax
 ,(case when (CASE WHEN fvc.InvTyp=1 then 
(SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.IsTaxUse= 1)and (dbo.T_INVHED.InvTyp=3)
)
when fvc.InvTyp=2 then
(SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.IsTaxUse = 1)and (dbo.T_INVHED.InvTyp=4)
)
end
) is null then 0 else 

 (CASE WHEN fvc.InvTyp=1 then 
(SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.IsTaxUse= 1)and (dbo.T_INVHED.InvTyp=3)
)
when fvc.InvTyp=2 then
(SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.IsTaxUse = 1)and (dbo.T_INVHED.InvTyp=4)
)
end
)end)as TotalReturnInvUsingTax
,
(case when (CASE WHEN fvc.InvTyp=1 then 
(SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.IsTaxUse= 1)and (dbo.T_INVHED.InvTyp=3)
)
when fvc.InvTyp=2 then
(SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.IsTaxUse = 1)and (dbo.T_INVHED.InvTyp=4)
)
end
) is null then 0 else 

 (CASE WHEN fvc.InvTyp=1 then 
(SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.IsTaxUse= 1)and (dbo.T_INVHED.InvTyp=3)
)
when fvc.InvTyp=2 then
(SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.IsTaxUse = 1)and (dbo.T_INVHED.InvTyp=4)
)
end
)end)-
(case when (CASE WHEN fvc.InvTyp=1 then 
( SELECT        SUM( dbo.T_INVHED.InvAddTaxlLoc) AS Expr1
FROM            dbo.T_INVHED 
WHERE        (dbo.T_INVHED.IfDel <> 1) and(dbo.T_INVHED.InvTyp=3)and (dbo.T_INVHED.IsTaxUse=1)

)
  when fvc.InvTyp=2 then 
( SELECT        SUM( dbo.T_INVHED.InvAddTaxlLoc) AS Expr1
FROM            dbo.T_INVHED 
                       
WHERE        (dbo.T_INVHED.IfDel <> 1) and (dbo.T_INVHED.InvTyp=4)and (dbo.T_INVHED.IsTaxUse=1)

)
end) is null then 0 else 
(CASE WHEN fvc.InvTyp=1 then 
( SELECT        SUM( dbo.T_INVHED.InvAddTaxlLoc) AS Expr1
FROM            dbo.T_INVHED 
WHERE        (dbo.T_INVHED.IfDel <> 1) and(dbo.T_INVHED.InvTyp=3)and (dbo.T_INVHED.IsTaxUse=1)

)
  when fvc.InvTyp=2 then 
( SELECT        SUM( dbo.T_INVHED.InvAddTaxlLoc) AS Expr1
FROM            dbo.T_INVHED 
                       
WHERE        (dbo.T_INVHED.IfDel <> 1) and (dbo.T_INVHED.InvTyp=4)and (dbo.T_INVHED.IsTaxUse=1)

)
end)
end)  as TotalRetunInvUsingTaxWithoutTax
,(case when (CASE WHEN fvc.InvTyp=1 then 
( SELECT        SUM( dbo.T_INVHED.InvAddTaxlLoc) AS Expr1
FROM            dbo.T_INVHED 
WHERE        (dbo.T_INVHED.IfDel <> 1) and(dbo.T_INVHED.InvTyp=3)and (dbo.T_INVHED.IsTaxUse=1)

)
  when fvc.InvTyp=2 then 
( SELECT        SUM( dbo.T_INVHED.InvAddTaxlLoc) AS Expr1
FROM            dbo.T_INVHED 
                       
WHERE        (dbo.T_INVHED.IfDel <> 1) and (dbo.T_INVHED.InvTyp=4)and (dbo.T_INVHED.IsTaxUse=1)

)
end) is null then 0 else 
(CASE WHEN fvc.InvTyp=1 then 
( SELECT        SUM( dbo.T_INVHED.InvAddTaxlLoc) AS Expr1
FROM            dbo.T_INVHED 
WHERE        (dbo.T_INVHED.IfDel <> 1) and(dbo.T_INVHED.InvTyp=3)and (dbo.T_INVHED.IsTaxUse=1)

)
  when fvc.InvTyp=2 then 
( SELECT        SUM( dbo.T_INVHED.InvAddTaxlLoc) AS Expr1
FROM            dbo.T_INVHED 
                       
WHERE        (dbo.T_INVHED.IfDel <> 1) and (dbo.T_INVHED.InvTyp=4)and (dbo.T_INVHED.IsTaxUse=1)

)
end)
end)as ReturnInvADDTAx
,(
case when (CASE WHEN fvc.InvTyp=1 then 
(SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.IsTaxUse = 0)and (dbo.T_INVHED.InvTyp=3
))
  when fvc.InvTyp=2 then 
(SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.IsTaxUse = 0)and (dbo.T_INVHED.InvTyp=4
))

end


)is null then 0 
else
(CASE WHEN fvc.InvTyp=1 then 
(SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.IsTaxUse = 0)and (dbo.T_INVHED.InvTyp=3
))
  when fvc.InvTyp=2 then 
(SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.IsTaxUse = 0)and (dbo.T_INVHED.InvTyp=4
))

end


)


end) as TotalOfReturnInvUnotusingTax
FROM            dbo.T_INVHED fvc

";
                scc = @"sELECT      fvc.InvTyp,case when fvc.InvTyp=1 then ' مبيعات' else 'مشتريات'end as NameOFInv,( case when  (SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.InvAddTax > 0)and (dbo.T_INVHED.InvTyp=fvc.InvTyp
)) is null then 0 else 
 (SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.InvAddTax > 0)and (dbo.T_INVHED.InvTyp=fvc.InvTyp
))
end )as TotalNetOfInvUsingTax

,case when ( SELECT         SUM( dbo.T_INVHED.InvAddTaxlLoc) AS Expr1
FROM            dbo.T_INVHED 
WHERE        (dbo.T_INVHED.IfDel <> 1) and (dbo.T_INVHED.InvTyp=fvc.InvTyp)and (dbo.T_INVHED.InvAddTax>0)

)is null 

then 0 else 
( SELECT         SUM( dbo.T_INVHED.InvAddTaxlLoc) AS Expr1
FROM            dbo.T_INVHED 
WHERE        (dbo.T_INVHED.IfDel <> 1) and (dbo.T_INVHED.InvTyp=fvc.InvTyp)and (dbo.T_INVHED.InvAddTax>0)
)
end
as ADDTAX
,
(case when ( (SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.InvAddTax>0)and (dbo.T_INVHED.InvTyp=fvc.InvTyp
)) -( SELECT        SUM( dbo.T_INVHED.InvAddTaxlLoc)  AS Expr1
FROM            dbo.T_INVHED  
WHERE        (dbo.T_INVHED.IfDel <> 1)  and   (dbo.T_INVHED.InvTyp=fvc.InvTyp)and (dbo.T_INVHED.InvAddTax>0)

) 

)is null then 0
else 
( (SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.InvAddTax>0)and (dbo.T_INVHED.InvTyp=fvc.InvTyp
)) -( SELECT        SUM( dbo.T_INVHED.InvAddTaxlLoc)  AS Expr1
FROM            dbo.T_INVHED 
                      
WHERE        (dbo.T_INVHED.IfDel <> 1)  and (dbo.T_INVHED.InvTyp=fvc.InvTyp)and (dbo.T_INVHED.InvAddTax>0)

) 

)
end)
as TotalNetOfInvUsingTaxwithoutTax
,
(case when 
(SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.InvAddTax=0)and (dbo.T_INVHED.InvTyp=fvc.InvTyp
)) is  null
then 0
else
(SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.InvAddTax=0)and (dbo.T_INVHED.InvTyp=fvc.InvTyp)
) 
end)

as TotalOfInvNotUsingTax


,

(case when ( (SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.InvAddTax>0)and (dbo.T_INVHED.InvTyp=fvc.InvTyp
)) -( SELECT        SUM( dbo.T_INVHED.InvAddTaxlLoc)  AS Expr1
FROM            dbo.T_INVHED  
WHERE        (dbo.T_INVHED.IfDel <> 1)  and   (dbo.T_INVHED.InvTyp=fvc.InvTyp)and (dbo.T_INVHED.InvAddTax>0)

) 

)is null then 0
else 
( (SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.InvAddTax>0)and (dbo.T_INVHED.InvTyp=fvc.InvTyp
)) -( SELECT        SUM( dbo.T_INVHED.InvAddTaxlLoc)  AS Expr1
FROM            dbo.T_INVHED 
                      
WHERE        (dbo.T_INVHED.IfDel <> 1)  and (dbo.T_INVHED.InvTyp=fvc.InvTyp)and (dbo.T_INVHED.InvAddTax>0)

) 

)
end)+
(case when 
(SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.InvAddTax=0)and (dbo.T_INVHED.InvTyp=fvc.InvTyp
)) is  null
then 0
else
(SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.InvAddTax=0)and (dbo.T_INVHED.InvTyp=fvc.InvTyp)
) 
end)as TotalInvOfThisTypeWithoutTax
 ,(case when (CASE WHEN fvc.InvTyp=1 then 
(SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.InvAddTax>0)and (dbo.T_INVHED.InvTyp=3)
)
when fvc.InvTyp=2 then
(SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.InvAddTax>0)and (dbo.T_INVHED.InvTyp=4)
)
end
) is null then 0 else 

 (CASE WHEN fvc.InvTyp=1 then 
(SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.InvAddTax>0)and (dbo.T_INVHED.InvTyp=3)
)
when fvc.InvTyp=2 then
(SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.InvAddTax>0)and (dbo.T_INVHED.InvTyp=4)
)
end
)end)as TotalReturnInvUsingTax
,
(case when (CASE WHEN fvc.InvTyp=1 then 
(SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.InvAddTax>0)and (dbo.T_INVHED.InvTyp=3)
)
when fvc.InvTyp=2 then
(SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.InvAddTax>0)and (dbo.T_INVHED.InvTyp=4)
)
end
) is null then 0 else 

 (CASE WHEN fvc.InvTyp=1 then 
(SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.InvAddTax>0)and (dbo.T_INVHED.InvTyp=3)
)
when fvc.InvTyp=2 then
(SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.InvAddTax>0)and (dbo.T_INVHED.InvTyp=4)
)
end
)end)-
(case when (CASE WHEN fvc.InvTyp=1 then 
( SELECT        SUM( dbo.T_INVHED.InvAddTaxlLoc) AS Expr1
FROM            dbo.T_INVHED 
WHERE        (dbo.T_INVHED.IfDel <> 1) and(dbo.T_INVHED.InvTyp=3)and (dbo.T_INVHED.InvAddTax>0)

)
  when fvc.InvTyp=2 then 
( SELECT        SUM( dbo.T_INVHED.InvAddTaxlLoc) AS Expr1
FROM            dbo.T_INVHED 
                       
WHERE        (dbo.T_INVHED.IfDel <> 1) and (dbo.T_INVHED.InvTyp=4)and (dbo.T_INVHED.InvAddTax>0)

)
end) is null then 0 else 
(CASE WHEN fvc.InvTyp=1 then 
( SELECT        SUM( dbo.T_INVHED.InvAddTaxlLoc) AS Expr1
FROM            dbo.T_INVHED 
WHERE        (dbo.T_INVHED.IfDel <> 1) and(dbo.T_INVHED.InvTyp=3)and (dbo.T_INVHED.InvAddTax>0)

)
  when fvc.InvTyp=2 then 
( SELECT        SUM( dbo.T_INVHED.InvAddTaxlLoc) AS Expr1
FROM            dbo.T_INVHED 
                       
WHERE        (dbo.T_INVHED.IfDel <> 1) and (dbo.T_INVHED.InvTyp=4)and (dbo.T_INVHED.InvAddTax>0)

)
end)
end)  as TotalRetunInvUsingTaxWithoutTax
,(case when (CASE WHEN fvc.InvTyp=1 then 
( SELECT        SUM( dbo.T_INVHED.InvAddTaxlLoc) AS Expr1
FROM            dbo.T_INVHED 
WHERE        (dbo.T_INVHED.IfDel <> 1) and(dbo.T_INVHED.InvTyp=3)and (dbo.T_INVHED.InvAddTax>0)

)
  when fvc.InvTyp=2 then 
( SELECT        SUM( dbo.T_INVHED.InvAddTaxlLoc) AS Expr1
FROM            dbo.T_INVHED 
                       
WHERE        (dbo.T_INVHED.IfDel <> 1) and (dbo.T_INVHED.InvTyp=4)and (dbo.T_INVHED.InvAddTax>0)

)
end) is null then 0 else 
(CASE WHEN fvc.InvTyp=1 then 
( SELECT        SUM( dbo.T_INVHED.InvAddTaxlLoc) AS Expr1
FROM            dbo.T_INVHED 
WHERE        (dbo.T_INVHED.IfDel <> 1) and(dbo.T_INVHED.InvTyp=3)and (dbo.T_INVHED.InvAddTax>0)

)
  when fvc.InvTyp=2 then 
( SELECT        SUM( dbo.T_INVHED.InvAddTaxlLoc) AS Expr1
FROM            dbo.T_INVHED 
                       
WHERE        (dbo.T_INVHED.IfDel <> 1) and (dbo.T_INVHED.InvTyp=4)and (dbo.T_INVHED.InvAddTax>0)

)
end)
end)as ReturnInvADDTAx
,(
case when (CASE WHEN fvc.InvTyp=1 then 
(SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.InvAddTax=0)and (dbo.T_INVHED.InvTyp=3
))
  when fvc.InvTyp=2 then 
(SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.InvAddTax=0)and (dbo.T_INVHED.InvTyp=4
))

end


)is null then 0 
else
(CASE WHEN fvc.InvTyp=1 then 
(SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.InvAddTax=0)and (dbo.T_INVHED.InvTyp=3
))
  when fvc.InvTyp=2 then 
(SELECT        SUM(dbo.T_INVHED.InvNetLocCur) 
FROM            dbo.T_INVHED
WHERE        (dbo.T_INVHED.IfDel = 0) AND (dbo.T_INVHED.InvAddTax=0)and (dbo.T_INVHED.InvTyp=4
))

end


)


end) as TotalOfReturnInvUnotusingTax
FROM            dbo.T_INVHED fvc
";
                string w=@" 

WHERE (fvc.IfDel <> 1) AND(fvc.InvTyp = 1 or fvc.InvTyp = 2)
GROUP BY fvc.InvTyp";
                w = w.Replace("WHERE ", "WHERE " + BuildRuleList(0).Replace("T_INVHED.", "fvc."));

                scc = scc.Replace("WHERE ", " WHERE " + BuildRuleList(0));
                scc += w;
                scc = scc.Replace("IsTaxGaid", "IsTaxUse");
                DataTable tb = DBUdate.DbUpdates.execute(scc, VarGeneral.BranchCS);
               
            if(tb.Rows.Count>0)
                {
                    FastReport.Report rpt = new FastReport.Report();
                    bool sss = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(1, 1) == "0") ? true : false);
                    string en = (LangArEn == 0 ? "Reports" : "ReportsE");
                    if (sss)
                    {
                         
                            rpt.Load(Application.StartupPath + "\\Rpt\\" + en + "\\RepInvIqrar.frx");

                    }
                    else
                        rpt.Load(Application.StartupPath + "\\Rpt\\" + en + "\\RepInvIqrar.frx");

                    Utilites.AddTarwisa(rpt);

                    tb.TableName = "item";
                   
                    DataSet dts = new DataSet();
                    dts.Tables.Add(tb);
                    rpt.RegisterData(dts);


                    rpt.SetParameterValue("HDate", Convert.ToDateTime(txtMToDate.Text).ToString("yyyy/MM/dd") );
                    rpt.SetParameterValue("GDate", Convert.ToDateTime(txtMFromDate.Text).ToString("yyyy/MM/dd"));
                    rpt.SetParameterValue("totPurchaes", totPurchaes);
                   
                    FrmReport frm = new FrmReport();
                    this.TopMost = false;

                    if (VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "1")
                    {
                        if (!flag)
                        {
                            rpt.Show(frm);
                            frm.Show();
                        }
                        else
                        {
                            rpt.Design(frm);
                            frm.Show();

                        }
                    }
                    else
                    {
                        FrmReportsViewer.PrintSetFsOut(rpt, (int)VarGeneral.GeneralPrinter.lnPg_Setting.Value, (VarGeneral.GeneralPrinter.Orientation_Setting == 1) ? PaperOrientation.Portrait : PaperOrientation.Landscape, VarGeneral.GeneralPrinter.defSizePaper_Setting, VarGeneral.GeneralPrinter.DefLines_Setting.Value, VarGeneral.GeneralPrinter.defPrn_Setting, VarGeneral.GeneralPrinter.hAs_Setting.Value, VarGeneral.GeneralPrinter.hYs_Setting.Value, VarGeneral.GeneralPrinter.hYm_Setting.Value, VarGeneral.GeneralPrinter.hAl_Setting.Value);

                    }
                }
            }
            catch (Exception ex4)
            {
                MessageBox.Show(ex4.Message);
            }
        }
        private void ButExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ButExit.Text = "خــــروج Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "طبـــاعة F5" : "عــــرض F5");
                groupBox4.Text = "التاريــــخ";
                Text = "إحتساب الضريبة المستحقة";
            }
            else
            {
                ButExit.Text = "Exit Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "Print F5" : "Show F5");
                groupBox4.Text = "Date";
                Text = "Calculate the tax due";
            }
        }
        private void FRAccountTax_Load(object sender, EventArgs e)
        {
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
            if (frm.SerachNo != "")
            {
                txtSalesAccNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtSalesAccName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    txtSalesAccName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
            }
            else
            {
                txtSalesAccNo.Text = "";
                txtSalesAccName.Text = "";
            }
        }
        private void button_SrchLegNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("Mnd_No", new ColumnDictinary("رقم المندوب", "Commissary No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_Mndob";
            frm.TopMost = true;
            frm.ShowDialog();
 
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
            if (frm.SerachNo != "")
            {
                txtCostCNo.Text = db.StockCst(frm.Serach_No).Cst_ID.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtCostCName.Text = db.StockCst(frm.Serach_No).Arb_Des.ToString();
                }
                else
                {
                    txtCostCName.Text = db.StockCst(frm.Serach_No).Eng_Des.ToString();
                }
            }
            else
            {
                txtCostCNo.Text = "";
                txtCostCName.Text = "";
            }
        }
        private void button_SrchUsrNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("UsrNo", new ColumnDictinary("رقم المستخدم", "User No", ifDefault: true, ""));
            columns_Names_visible.Add("UsrNamA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("UsrNamE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_User";
            frm.TopMost = true;
            frm.ShowDialog();
           
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
            if (frm.SerachNo != "")
            {
                txtPurchaesAccNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtPurchaesAccName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    txtPurchaesAccName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
            }
            else
            {
                txtPurchaesAccNo.Text = "";
                txtPurchaesAccName.Text = "";
            }
        }bool flag = false;

        private void label1_Click(object sender, EventArgs e)
        {
            flag =!flag;
        }
    }
}
