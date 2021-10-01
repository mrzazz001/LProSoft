// Decompiled with JetBrains decompiler
// Type: InvAcc.Forms.FRSuppBalance
// Assembly: InvAcc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 22382E79-651B-4067-A397-F79FBCB141B5
// Assembly location: C:\Program Files (x86)\PROSOFT\InvAccc\InvAcc.exe
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using Framework.UI;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using Microsoft.Win32;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FRSuppBalance : Form
    { void avs(int arln)

{ 
 label10.Text=   (arln == 0 ? "  المستوى :  " : "  the level :") ; groupBox4.Text=   (arln == 0 ? "  حسب التاريخ  " : "  by date") ; label1.Text=   (arln == 0 ? "  مـــــن :  " : "  from:") ; label2.Text=   (arln == 0 ? "  إلـــــى :  " : "  to:") ; groupBox3.Text=   (arln == 0 ? "  الرصيــــد  " : "  balance") ; label3.Text=   (arln == 0 ? "  مـــــن :  " : "  from:") ; label4.Text=   (arln == 0 ? "  أصغر من " : "  Younger than") ; label9.Text=   (arln == 0 ? "  المستخدم :  " : "  the user :") ; label7.Text=   (arln == 0 ? "  المنـــــدوب :  " : "  The delegate:") ; label6.Text=   (arln == 0 ? "  الى حساب :  " : "  to account :") ; label5.Text=   (arln == 0 ? "  من حساب :  " : "  from account :") ; label8.Text=   (arln == 0 ? "  مركز التكلفة :  " : "  cost center:") ; ButExit.Text=   (arln == 0 ? "  خـــروج  " : "  Close") ; ButOk.Text=   (arln == 0 ? "  طبـــاعة  " : "  print") ;}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
        private int LangArEn = 0;
        private T_User _User = new T_User();
        public Dictionary<string, FRSuppBalance.ColumnDictinary> columns_Names_visible = new Dictionary<string, FRSuppBalance.ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private string having_ = " ";
       // private IContainer components = (IContainer)null;
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
        private ButtonX ButExit;
        private ButtonX ButOk;
        private C1.Win.C1FlexGrid.C1FlexGrid FlexField;
        private GroupBox groupBox4;
        private Label label1;
        private MaskedTextBox txtMToDate;
        private MaskedTextBox txtMFromDate;
        private Label label2;
        private GroupBox groupBox3;
        private Label label3;
        private Label label4;
        private GroupBox groupBox2;
        private Label label9;
        private TextBox txtIntoAccName;
        private TextBox txtLegateName;
        private TextBox txtFromAccName;
        private TextBox txtUserName;
        private TextBox txtCostCName;
        private TextBox txtFromAccNo;
        private TextBox txtIntoAccNo;
        private TextBox txtLegateNo;
        private TextBox txtUserNo;
        private TextBox txtCostCNo;
        private ButtonX button_SrchUsrNo;
        private ButtonX button_SrchCostNo;
        private ButtonX button_SrchLegNo;
        private ButtonX button_SrchAccTo;
        private ButtonX button_SrchAccFrom;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label8;
        private Label label10;
        private NumericUpDown numUpDownLevel;
        private DoubleInput txtMBalanceB;
        private DoubleInput txtMBalanceS;
        public SwitchButton switchButton_CalclatAge;
        private Stock_DataDataContext db
        {
            get
            {
                if (this.dbInstance == null)
                    this.dbInstance = new Stock_DataDataContext(VarGeneral.BranchCS);
                return this.dbInstance;
            }
        }
        private Rate_DataDataContext dbc
        {
            get
            {
                if (this.dbInstanceRate == null)
                    this.dbInstanceRate = new Rate_DataDataContext(VarGeneral.BranchRt);
                return this.dbInstanceRate;
            }
        }
        public FRSuppBalance()
        {
            this.InitializeComponent();this.Load += langloads;
            this._User = this.dbc.StockUser(VarGeneral.UserNumber);
            if (VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F" || VarGeneral.SSSLev == "S" || VarGeneral.SSSLev == "C")
            {
                this.label8.Visible = false;
                this.txtCostCNo.Visible = false;
                this.button_SrchCostNo.Visible = false;
                this.txtCostCName.Visible = false;
            }
            else
            {
                this.label8.Visible = true;
                this.txtCostCNo.Visible = true;
                this.button_SrchCostNo.Visible = true;
                this.txtCostCName.Visible = true;
            }
            try
            {
                if (VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F")
                {
                    RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", true);
                    try
                    {
                        if (string.IsNullOrEmpty(registryKey.GetValue("vCoCe").ToString()))
                        {
                            registryKey.CreateSubKey("vCoCe");
                            registryKey.SetValue("vCoCe", (object)"0");
                        }
                    }
                    catch
                    {
                        registryKey.CreateSubKey("vCoCe");
                        registryKey.SetValue("vCoCe", (object)"0");
                    }
                    if (long.Parse(registryKey.GetValue("vCoCe").ToString()) == 1L)
                    {
                        this.label8.Visible = true;
                        this.txtCostCNo.Visible = true;
                        this.button_SrchCostNo.Visible = true;
                        this.txtCostCName.Visible = true;
                    }
                    else
                    {
                        this.label8.Visible = false;
                        this.txtCostCNo.Visible = false;
                        this.button_SrchCostNo.Visible = false;
                        this.txtCostCName.Visible = false;
                    }
                }
            }
            catch
            {
            }
            if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
                return;
            this.txtMBalanceB.DisplayFormat = VarGeneral.DicemalMask;
            this.txtMBalanceS.DisplayFormat = VarGeneral.DicemalMask;
        }
        protected override void OnLoad(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRSuppBalance));
            if (this.Tag.ToString() == "0")
            {
                Language.ChangeLanguage("ar-SA", (Control)this, resources);
                this.LangArEn = 0;
            }
            else
            {
                Language.ChangeLanguage("en", (Control)this, resources);
                this.LangArEn = 1;
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
            this.RepDef();
            if (VarGeneral.SSSTyp == 0)
            {
                this.numUpDownLevel.Visible = false;
                this.label10.Visible = false;
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptMaintenanceCars.dll"))
                this.label7.Text = this.LangArEn == 0 ? "نوع السيارة :" : "Car Type :";
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptBus.dll"))
            {
                this.label8.Text = this.LangArEn == 0 ? "الباص :" : "Bus :";
                this.label7.Text = this.LangArEn == 0 ? "السائق :" : "Driver :";
            }
            if (!File.Exists(Application.StartupPath + "\\Script\\SecriptWaterPackages.dll"))
                return;
            this.label7.Text = this.LangArEn == 0 ? "العميــــــــل :" : "Customer :";
            this.label8.Text = this.LangArEn == 0 ? "السيــارة :" : "Car :";
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRSuppBalance));
            if (this.Tag.ToString() == "0")
            {
                Language.ChangeLanguage("ar-SA", (Control)this, resources);
                this.LangArEn = 0;
            }
            else
            {
                Language.ChangeLanguage("en", (Control)this, resources);
                this.LangArEn = 1;
            }
            this.FillFlex();
            this.RepDef();
        }
        private void RepDef()
        {
            int num = 0;
            for (int row = 1; row < this.FlexField.Rows.Count; ++row)
            {
                this.FlexField.SetData(row, 0, (object)true);
                ++num;
            }
        }
        private void FillFlex()
        {
            if (this.LangArEn == 0)
            {
                switch (VarGeneral.InvType)
                {
                    case 1:
                        this.Text = "أرصدة الموردين";
                        this.FlexField.Rows.Count = 6;
                        this.FlexField.SetData(0, 0, (object)"أظهار");
                        this.FlexField.SetData(0, 1, (object)"أسم الحقل");
                        this.FlexField.SetData(1, 1, (object)"[رقم الحساب]");
                        this.FlexField.SetData(1, 2, (object)" T_AccDef.AccDef_No ");
                        this.FlexField.SetData(2, 1, (object)"[أسم الحساب]");
                        this.FlexField.SetData(2, 2, (object)" T_AccDef.Arb_Des as AccDefNm ");
                        this.FlexField.SetData(3, 1, (object)"[حركة مدينة]");
                        this.FlexField.SetData(3, 2, (object)" Sum(CASE WHEN T_GDDET.gdValue > 0 THEN T_GDDET.gdValue ELSE 0 END) as Debit ");
                        this.FlexField.SetData(4, 1, (object)"[حركة دائنة]");
                        this.FlexField.SetData(4, 2, (object)" Sum(CASE WHEN T_GDDET.gdValue < 0 THEN Abs(T_GDDET.gdValue) ELSE 0 END) as Credit ");
                        this.FlexField.SetData(5, 1, (object)"[الرصيد]");
                        this.FlexField.SetData(5, 2, (object)" Sum(T_GDDET.gdValue) as Balance ");
                        this.FlexField.Tag = (object)" Group by T_AccDef.AccDef_No,T_AccDef.Arb_Des,T_SYSSETTING.LogImg ";
                        break;
                    case 2:
                        this.Text = "الموردون الراكدون";
                        this.FlexField.Rows.Count = 6;
                        this.FlexField.SetData(0, 0, (object)"أظهار");
                        this.FlexField.SetData(0, 1, (object)"أسم الحقل");
                        this.FlexField.SetData(1, 1, (object)"[رقم الحساب]");
                        this.FlexField.SetData(1, 2, (object)" T_AccDef.AccDef_No ");
                        this.FlexField.SetData(2, 1, (object)"[أسم الحساب]");
                        this.FlexField.SetData(2, 2, (object)" T_AccDef.Arb_Des as AccDefNm ");
                        this.FlexField.SetData(3, 1, (object)"[حركة مدينة]");
                        this.FlexField.SetData(3, 2, (object)" Sum(CASE WHEN T_GDDET.gdValue > 0 THEN T_GDDET.gdValue ELSE 0 END) as Debit ");
                        this.FlexField.SetData(4, 1, (object)"[حركة دائنة]");
                        this.FlexField.SetData(4, 2, (object)" Sum(CASE WHEN T_GDDET.gdValue < 0 THEN Abs(T_GDDET.gdValue) ELSE 0 END) as Credit ");
                        this.FlexField.SetData(5, 1, (object)"[الرصيد]");
                        this.FlexField.SetData(5, 2, (object)" Sum(T_GDDET.gdValue) as Balance ");
                        this.FlexField.Tag = (object)" Group by T_AccDef.AccDef_No,T_AccDef.Arb_Des,T_SYSSETTING.LogImg ";
                        break;
                    case 3:
                        this.Text = "حركة الموردين";
                        this.FlexField.Rows.Count = 4;
                        this.FlexField.SetData(0, 0, (object)"أظهار");
                        this.FlexField.SetData(0, 1, (object)"أسم الحقل");
                        this.FlexField.SetData(1, 1, (object)"[رقم الحساب]");
                        this.FlexField.SetData(1, 2, (object)" T_AccDef.AccDef_No ");
                        this.FlexField.SetData(2, 1, (object)"[أسم الحساب]");
                        this.FlexField.SetData(2, 2, (object)" T_AccDef.Arb_Des as AccDefNm ");
                        this.FlexField.SetData(3, 1, (object)"[الرصيد]");
                        this.FlexField.SetData(3, 2, (object)" Sum(T_GDDET.gdValue) as Balance ");
                        this.FlexField.Tag = (object)" Group by T_AccDef.AccDef_No,T_AccDef.Arb_Des,T_SYSSETTING.LogImg ";
                        break;
                    case 4:
                        this.Text = "ذمم الموردين";
                        this.FlexField.Rows.Count = 4;
                        this.FlexField.SetData(0, 0, (object)"أظهار");
                        this.FlexField.SetData(0, 1, (object)"أسم الحقل");
                        this.FlexField.SetData(1, 1, (object)"[رقم الحساب]");
                        this.FlexField.SetData(1, 2, (object)" T_AccDef.AccDef_No ");
                        this.FlexField.SetData(2, 1, (object)"[أسم الحساب]");
                        this.FlexField.SetData(2, 2, (object)" T_AccDef.Arb_Des as AccDefNm ");
                        this.FlexField.SetData(3, 1, (object)"[الرصيد]");
                        this.FlexField.SetData(3, 2, (object)" Sum(T_GDDET.gdValue) as Balance ");
                        this.FlexField.Tag = (object)" Group by T_AccDef.AccDef_No,T_AccDef.Arb_Des,T_SYSSETTING.LogImg ";
                        this.switchButton_CalclatAge.Visible = true;
                        break;
                }
            }
            else
            {
                switch (VarGeneral.InvType)
                {
                    case 1:
                        this.Text = "Suppliers Balances";
                        this.FlexField.Rows.Count = 6;
                        this.FlexField.SetData(0, 0, (object)"Showing");
                        this.FlexField.SetData(0, 1, (object)"Filed Name");
                        this.FlexField.SetData(1, 1, (object)"[Account No]");
                        this.FlexField.SetData(1, 2, (object)" T_AccDef.AccDef_No ");
                        this.FlexField.SetData(2, 1, (object)"[Account Name]");
                        this.FlexField.SetData(2, 2, (object)" T_AccDef.Eng_Des as AccDefNm ");
                        this.FlexField.SetData(3, 1, (object)"[Debit Trans]");
                        this.FlexField.SetData(3, 2, (object)" Sum(CASE WHEN T_GDDET.gdValue > 0 THEN T_GDDET.gdValue ELSE 0 END) as Debit ");
                        this.FlexField.SetData(4, 1, (object)"[Credit Trans]");
                        this.FlexField.SetData(4, 2, (object)" Sum(CASE WHEN T_GDDET.gdValue < 0 THEN Abs(T_GDDET.gdValue) ELSE 0 END) as Credit ");
                        this.FlexField.SetData(5, 1, (object)"[Balance]");
                        this.FlexField.SetData(5, 2, (object)" Sum(T_GDDET.gdValue) as Balance ");
                        this.FlexField.Tag = (object)" Group by T_AccDef.AccDef_No,T_AccDef.Eng_Des,T_SYSSETTING.LogImg ";
                        break;
                    case 2:
                        this.Text = "Unmoved Suppliers";
                        this.FlexField.Rows.Count = 6;
                        this.FlexField.SetData(0, 0, (object)"Showing");
                        this.FlexField.SetData(0, 1, (object)"Filed Name");
                        this.FlexField.SetData(1, 1, (object)"[Account No]");
                        this.FlexField.SetData(1, 2, (object)" T_AccDef.AccDef_No ");
                        this.FlexField.SetData(2, 1, (object)"[Account Name]");
                        this.FlexField.SetData(2, 2, (object)" T_AccDef.Eng_Des as AccDefNm ");
                        this.FlexField.SetData(3, 1, (object)"[Debit Trans]");
                        this.FlexField.SetData(3, 2, (object)" Sum(CASE WHEN T_GDDET.gdValue > 0 THEN T_GDDET.gdValue ELSE 0 END) as Debit ");
                        this.FlexField.SetData(4, 1, (object)"[Credit Trans]");
                        this.FlexField.SetData(4, 2, (object)" Sum(CASE WHEN T_GDDET.gdValue < 0 THEN Abs(T_GDDET.gdValue) ELSE 0 END) as Credit ");
                        this.FlexField.SetData(5, 1, (object)"[Balance]");
                        this.FlexField.SetData(5, 2, (object)" Sum(T_GDDET.gdValue) as Balance ");
                        this.FlexField.Tag = (object)" Group by T_AccDef.AccDef_No,T_AccDef.Eng_Des,T_SYSSETTING.LogImg ";
                        break;
                    case 3:
                        this.Text = "Suppliers Movement Analysis";
                        this.FlexField.Rows.Count = 4;
                        this.FlexField.SetData(0, 0, (object)"Showing");
                        this.FlexField.SetData(0, 1, (object)"Filed Name");
                        this.FlexField.SetData(1, 1, (object)"[Account No]");
                        this.FlexField.SetData(1, 2, (object)" T_AccDef.AccDef_No ");
                        this.FlexField.SetData(2, 1, (object)"[Account Name]");
                        this.FlexField.SetData(2, 2, (object)" T_AccDef.Eng_Des as AccDefNm ");
                        this.FlexField.SetData(3, 1, (object)"[Balance]");
                        this.FlexField.SetData(3, 2, (object)" Sum(T_GDDET.gdValue) as Balance ");
                        this.FlexField.Tag = (object)" Group by T_AccDef.AccDef_No,T_AccDef.Eng_Des,T_SYSSETTING.LogImg ";
                        break;
                    case 4:
                        this.Text = "Suppliers Credit Age Analysis";
                        this.FlexField.Rows.Count = 4;
                        this.FlexField.SetData(0, 0, (object)"Showing");
                        this.FlexField.SetData(0, 1, (object)"Filed Name");
                        this.FlexField.SetData(1, 1, (object)"[Account No]");
                        this.FlexField.SetData(1, 2, (object)" T_AccDef.AccDef_No ");
                        this.FlexField.SetData(2, 1, (object)"[Account Name]");
                        this.FlexField.SetData(2, 2, (object)" T_AccDef.Eng_Des as AccDefNm ");
                        this.FlexField.SetData(3, 1, (object)"[Balance]");
                        this.FlexField.SetData(3, 2, (object)" Sum(T_GDDET.gdValue) as Balance ");
                        this.FlexField.Tag = (object)" Group by T_AccDef.AccDef_No,T_AccDef.Eng_Des,T_SYSSETTING.LogImg ";
                        this.switchButton_CalclatAge.Visible = true;
                        break;
                }
            }
            this.RibunButtons();
        }
        private string BuildFieldList()
        {
            Framework.Date.HijriGregDates hijriGregDates1 = new Framework.Date.HijriGregDates();
            string str1 = "";
#pragma warning disable CS0219 // The variable 'str2' is assigned but its value is never used
            string str2 = "";
#pragma warning restore CS0219 // The variable 'str2' is assigned but its value is never used
            string str3 = "";
            for (int index = 1; index < this.FlexField.Rows.Count; ++index)
            {
                if (VarGeneral.TString.TEmptyBool(this.FlexField.GetData(index, 0)) && this.FlexField.Rows[index].Visible)
                {
                    if (!string.IsNullOrEmpty(str1))
                        str1 += ",";
                    str1 += this.FlexField.GetData(index, 2).ToString();
                }
            }
            if (VarGeneral.InvType == 3)
            {
                Framework.Date.HijriGregDates hijriGregDates2 = new Framework.Date.HijriGregDates();
                string str4 = hijriGregDates2.FormatGreg(VarGeneral.Gdate, "yyyy");
                str2 = "";
                str3 = "";
                if (this.LangArEn == 0)
                {
                    for (int index = 1; index <= 12; ++index)
                    {
                        if (index != 12)
                        {
                            string str5 = str1 + ",";
                            string str6 = hijriGregDates2.FormatGreg("1/" + (object)index + "/" + str4, "yyyy/MM/dd");
                            string str7 = hijriGregDates2.FormatGreg("1/" + (object)(index + 1) + "/" + str4, "yyyy/MM/dd");
                            str1 = str5 + " Sum(CASE WHEN T_GDDET.gdValue > 0 and T_GDHEAD.gdGDate >= '" + str6 + "' and T_GDHEAD.gdGDate < '" + str7 + "' THEN T_GDDET.gdValue ELSE 0 END) as [المقبوضات " + (object)index + "] " + "," + " Sum(CASE WHEN T_GDDET.gdValue < 0 and T_GDHEAD.gdGDate >= '" + str6 + "' and T_GDHEAD.gdGDate < '" + str7 + "' THEN Abs(T_GDDET.gdValue) ELSE 0 END) as [الفواتير " + (object)index + "] ";
                        }
                        else
                        {
                            string str5 = str1 + ",";
                            string str6 = hijriGregDates2.FormatGreg("1/" + (object)index + "/" + str4, "yyyy/MM/dd");
                            str1 = str5 + " Sum(CASE WHEN T_GDDET.gdValue > 0 and T_GDHEAD.gdGDate >= '" + str6 + "' THEN T_GDDET.gdValue ELSE 0 END) as [المقبوضات " + (object)index + "] " + "," + " Sum(CASE WHEN T_GDDET.gdValue < 0 and T_GDHEAD.gdGDate >= '" + str6 + "' THEN Abs(T_GDDET.gdValue) ELSE 0 END) as [الفواتير " + (object)index + "] ";
                        }
                    }
                }
                else
                {
                    for (int index = 1; index <= 12; ++index)
                    {
                        if (index != 12)
                        {
                            string str5 = str1 + ",";
                            string str6 = hijriGregDates2.FormatGreg("1/" + (object)index + "/" + str4, "yyyy/MM/dd");
                            string str7 = hijriGregDates2.FormatGreg("1/" + (object)(index + 1) + "/" + str4, "yyyy/MM/dd");
                            str1 = str5 + " Sum(CASE WHEN T_GDDET.gdValue > 0 and T_GDHEAD.gdGDate >= '" + str6 + "' and T_GDHEAD.gdGDate < '" + str7 + "' THEN T_GDDET.gdValue ELSE 0 END) as [Receipts " + (object)index + "] " + "," + " Sum(CASE WHEN T_GDDET.gdValue < 0 and T_GDHEAD.gdGDate >= '" + str6 + "' and T_GDHEAD.gdGDate < '" + str7 + "' THEN Abs(T_GDDET.gdValue) ELSE 0 END) as [Invoices " + (object)index + "] ";
                        }
                        else
                        {
                            string str5 = str1 + ",";
                            string str6 = hijriGregDates2.FormatGreg("1/" + (object)index + "/" + str4, "yyyy/MM/dd");
                            str1 = str5 + " Sum(CASE WHEN T_GDDET.gdValue > 0 and T_GDHEAD.gdGDate >= '" + str6 + "' THEN T_GDDET.gdValue ELSE 0 END) as [Receipts " + (object)index + "] " + "," + " Sum(CASE WHEN T_GDDET.gdValue < 0 and T_GDHEAD.gdGDate >= '" + str6 + "' THEN Abs(T_GDDET.gdValue) ELSE 0 END) as [Invoices " + (object)index + "] ";
                        }
                    }
                }
            }
            if (VarGeneral.InvType == 4)
            {
                Framework.Date.HijriGregDates hijriGregDates2 = new Framework.Date.HijriGregDates();
                DateTime dateTime = new DateTime(int.Parse(hijriGregDates2.FormatGreg(VarGeneral.Gdate, "yyyy")), int.Parse(hijriGregDates2.FormatGreg(VarGeneral.Gdate, "MM")), int.Parse(hijriGregDates2.FormatGreg(VarGeneral.Gdate, "dd")));
                string str4 = hijriGregDates2.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                str3 = hijriGregDates2.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                double num = 0.0;
                if (this.LangArEn == 0)
                {
                    for (int index = 1; index <= 12; ++index)
                    {
                        string[] strArray1 = new string[8]
                        {
              str1 + ",",
              " CASE WHEN Sum(CASE WHEN T_GDDET.gdValue < 0 and T_GDHEAD.gdGDate <= '",
              str4,
              "' THEN Abs(T_GDDET.gdValue) ELSE 0 END) > Sum(CASE WHEN T_GDDET.gdValue > 0  THEN T_GDDET.gdValue ELSE 0 END) THEN Sum(CASE WHEN T_GDDET.gdValue < 0 and T_GDHEAD.gdGDate <= '",
              str4,
              "' THEN Abs(T_GDDET.gdValue) ELSE 0 END) - Sum(CASE WHEN T_GDDET.gdValue > 0  THEN T_GDDET.gdValue ELSE 0 END) ELSE 0 END as [",
              null,
              null
                        };
                        string[] strArray2 = strArray1;
                        string str5;
                        switch (index)
                        {
                            case 1:
                                str5 = "a";
                                break;
                            case 2:
                                str5 = "b";
                                break;
                            case 3:
                                str5 = "c";
                                break;
                            case 4:
                                str5 = "d";
                                break;
                            case 5:
                                str5 = "e";
                                break;
                            case 6:
                                str5 = "f";
                                break;
                            case 7:
                                str5 = "g";
                                break;
                            case 8:
                                str5 = "h";
                                break;
                            case 9:
                                str5 = "i";
                                break;
                            case 10:
                                str5 = "j";
                                break;
                            case 11:
                                str5 = "k";
                                break;
                            default:
                                str5 = "l";
                                break;
                        }
                        strArray2[6] = str5;
                        strArray1[7] = "] ";
                        str1 = string.Concat(strArray1);
                        num += this.switchButton_CalclatAge.Value ? 15.0 : 30.0;
                        dateTime = dateTime.Date.AddDays(-num);
                        str4 = hijriGregDates2.FormatGreg(dateTime.Year.ToString() + "/" + (object)dateTime.Month + "/" + (object)dateTime.Day, "yyyy/MM/dd");
                    }
                }
                else
                {
                    for (int index = 1; index <= 12; ++index)
                    {
                        string[] strArray1 = new string[8]
                        {
              str1 + ",",
              " CASE WHEN Sum(CASE WHEN T_GDDET.gdValue < 0 and T_GDHEAD.gdGDate <= '",
              str4,
              "' THEN Abs(T_GDDET.gdValue) ELSE 0 END) > Sum(CASE WHEN T_GDDET.gdValue > 0  THEN T_GDDET.gdValue ELSE 0 END) THEN Sum(CASE WHEN T_GDDET.gdValue < 0 and T_GDHEAD.gdGDate <= '",
              str4,
              "' THEN Abs(T_GDDET.gdValue) ELSE 0 END) - Sum(CASE WHEN T_GDDET.gdValue > 0  THEN T_GDDET.gdValue ELSE 0 END) ELSE 0 END as [",
              null,
              null
                        };
                        string[] strArray2 = strArray1;
                        string str5;
                        switch (index)
                        {
                            case 1:
                                str5 = "a";
                                break;
                            case 2:
                                str5 = "b";
                                break;
                            case 3:
                                str5 = "c";
                                break;
                            case 4:
                                str5 = "d";
                                break;
                            case 5:
                                str5 = "e";
                                break;
                            case 6:
                                str5 = "f";
                                break;
                            case 7:
                                str5 = "g";
                                break;
                            case 8:
                                str5 = "h";
                                break;
                            case 9:
                                str5 = "i";
                                break;
                            case 10:
                                str5 = "j";
                                break;
                            case 11:
                                str5 = "k";
                                break;
                            default:
                                str5 = "l";
                                break;
                        }
                        strArray2[6] = str5;
                        strArray1[7] = "] ";
                        str1 = string.Concat(strArray1);
                        num += this.switchButton_CalclatAge.Value ? 15.0 : 30.0;
                        dateTime = dateTime.Date.AddDays(-num);
                        str4 = hijriGregDates2.FormatGreg(dateTime.Year.ToString() + "/" + (object)dateTime.Month + "/" + (object)dateTime.Day, "yyyy/MM/dd");
                    }
                }
            }
            return str1 + " ,T_SYSSETTING.LogImg ";
        }
        private string BuildRuleList()
        {
            Framework.Date.HijriGregDates hijriGregDates = new Framework.Date.HijriGregDates();
            this.having_ = " having 1 = 1 ";
            string str1 = "Where 1 = 1 and T_GDHEAD.gdLok = 0 and T_AccDef.AccCat = '5' ";
            if (this.txtMBalanceB.LockUpdateChecked)
            {
                FRSuppBalance frSuppBalance = this;
                frSuppBalance.having_ = frSuppBalance.having_ + " and " + this.txtMBalanceB.Tag + " >= " + (object)this.txtMBalanceB.Value;
            }
            if (this.txtMBalanceS.LockUpdateChecked)
            {
                FRSuppBalance frSuppBalance = this;
                frSuppBalance.having_ = frSuppBalance.having_ + " and " + this.txtMBalanceS.Tag + " <= " + (object)this.txtMBalanceS.Value;
            }
            if (!string.IsNullOrEmpty(this.txtFromAccNo.Text))
                str1 = str1 + " and " + this.txtFromAccNo.Tag + " >= '" + this.txtFromAccNo.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(this.txtIntoAccNo.Text))
                str1 = str1 + " and " + this.txtIntoAccNo.Tag + " <= '" + this.txtIntoAccNo.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(this.txtCostCNo.Text))
                str1 = str1 + " and " + this.txtCostCNo.Tag + " = '" + this.txtCostCNo.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(this.txtUserNo.Text))
                str1 = str1 + " and " + this.txtUserNo.Tag + " = '" + this.txtUserNo.Text.Trim() + "'";
            if (!string.IsNullOrEmpty(this.txtLegateNo.Text))
                str1 = str1 + " and " + this.txtLegateNo.Tag + " = '" + this.txtLegateNo.Text.Trim() + "'";
            string str2 = str1 + " and " + this.numUpDownLevel.Tag + " = " + (object)this.numUpDownLevel.Value;
            if (VarGeneral.CheckDate(this.txtMFromDate.Text) && this.txtMFromDate.Text.Length == 10)
                str2 = VarGeneral.InvType == 2 ? (int.Parse(this.txtMFromDate.Text.Substring(0, 4)) >= 1800 ? str2 + " and T_AccDef.AccDef_No Not in (select T_INVHED.CusVenNo from T_INVHED where  T_INVHED.GDat  >= '" + hijriGregDates.FormatGreg(this.txtMFromDate.Text, "yyyy/MM/dd") + "')" : str2 + " and T_AccDef.AccDef_No Not in (select T_INVHED.CusVenNo from T_INVHED where  T_INVHED.HDat  >= '" + hijriGregDates.FormatHijri(this.txtMFromDate.Text, "yyyy/MM/dd") + "')") : (int.Parse(this.txtMFromDate.Text.Substring(0, 4)) >= 1800 ? str2 + " and  T_GDHEAD.gdGDate  >= '" + hijriGregDates.FormatGreg(this.txtMFromDate.Text, "yyyy/MM/dd") + "'" : str2 + " and  T_GDHEAD.gdHDate  >= '" + hijriGregDates.FormatHijri(this.txtMFromDate.Text, "yyyy/MM/dd") + "'");
            if (VarGeneral.CheckDate(this.txtMToDate.Text) && this.txtMToDate.Text.Length == 10)
                str2 = VarGeneral.InvType == 2 ? (int.Parse(this.txtMToDate.Text.Substring(0, 4)) >= 1800 ? str2 + " and T_AccDef.AccDef_No Not in (select T_INVHED.CusVenNo from T_INVHED where  T_INVHED.GDat  <= '" + hijriGregDates.FormatGreg(this.txtMToDate.Text, "yyyy/MM/dd") + "')" : str2 + " and T_AccDef.AccDef_No Not in (select T_INVHED.CusVenNo from T_INVHED where  T_INVHED.HDat  <= '" + hijriGregDates.FormatHijri(this.txtMToDate.Text, "yyyy/MM/dd") + "')") : (int.Parse(this.txtMToDate.Text.Substring(0, 4)) >= 1800 ? str2 + " and  T_GDHEAD.gdGDate  <= '" + hijriGregDates.FormatGreg(this.txtMToDate.Text, "yyyy/MM/dd") + "'" : str2 + " and  T_GDHEAD.gdHDate  <= '" + hijriGregDates.FormatHijri(this.txtMToDate.Text, "yyyy/MM/dd") + "'");
            return str2 + this.FlexField.Tag + this.having_;
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            try
            {
                Library.RepShow.RepShow repShow = new Library.RepShow.RepShow();
                repShow.Tables = " T_GDDET LEFT OUTER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID  LEFT OUTER JOIN T_INVSETTING On T_GDHEAD.gdTyp = T_INVSETTING.InvID   LEFT OUTER JOIN T_AccDef on T_GDDET.AccNo = T_AccDef.AccDef_No LEFT OUTER JOIN T_SYSSETTING ON T_GDHEAD.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                string str = this.BuildFieldList();
                repShow.Rule = this.BuildRuleList();
                repShow.Fields = str;
                try
                {
                    VarGeneral.RepData = (DataSet)repShow.Save().RepData;
                }
                catch (Exception ex)
                {
                    int num = (int)MessageBox.Show(ex.Message);
                }
                if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                {
                    int num1 = (int)MessageBox.Show(this.LangArEn == 0 ? "عفوا .. لا يوجد بيانات لعرضها في التقرير " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    try
                    {
                        FrmReportsViewer frmReportsViewer = new FrmReportsViewer();
                        frmReportsViewer.Tag = (object)this.LangArEn;
                        frmReportsViewer.Repvalue = VarGeneral.InvType != 4 ? "Cust_Supp" : (this.switchButton_CalclatAge.Value ? "CustAge15" : "CustAge");
                        VarGeneral.vTitle = this.Text;
                        VarGeneral._DTFrom = !VarGeneral.CheckDate(this.txtMFromDate.Text) ? "" : this.txtMFromDate.Text;
                        VarGeneral._DTTo = !VarGeneral.CheckDate(this.txtMToDate.Text) ? "" : this.txtMToDate.Text;
                        frmReportsViewer.TopMost = true;
                        int num2 = (int)frmReportsViewer.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        VarGeneral.DebLog.writeLog("button_ShowRep_Click:", ex, true);
                        int num2 = (int)MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
            }
        }
        private void Frm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r')
                return;
            SendKeys.Send("{Tab}");
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 && this.ButOk.Enabled && this.ButOk.Visible)
            {
                this.ButOk_Click(sender, (EventArgs)e);
            }
            else
            {
                if (e.KeyCode != Keys.Escape)
                    return;
                this.Close();
            }
        }
        private void ButExit_Click(object sender, EventArgs e) => this.Close();
        private void txtCustNo_KeyDown(object sender, KeyEventArgs e)
        {
        }
        private void txtMFromDate_Click(object sender, EventArgs e) => this.txtMFromDate.SelectAll();
        private void txtMToDate_Click(object sender, EventArgs e) => this.txtMToDate.SelectAll();
        private void button_SrchAccFrom_Click(object sender, EventArgs e)
        {
            this.columns_Names_visible.Clear();
            this.columns_Names_visible.Add("AccDef_No", new FRSuppBalance.ColumnDictinary("الرقم ", " No", true, ""));
            this.columns_Names_visible.Add("Arb_Des", new FRSuppBalance.ColumnDictinary("الاسم عربي", "Arabic Name", true, ""));
            this.columns_Names_visible.Add("Eng_Des", new FRSuppBalance.ColumnDictinary("الاسم الانجليزي", "English Name", true, ""));
            this.columns_Names_visible.Add("AccDef_ID", new FRSuppBalance.ColumnDictinary(" ", " ", false, ""));
            this.columns_Names_visible.Add("Mobile", new FRSuppBalance.ColumnDictinary("الجوال", "Mobile", false, ""));
            this.columns_Names_visible.Add("TaxNo", new FRSuppBalance.ColumnDictinary("الرقم الضريبي", "Tax No", false, ""));
            FrmSearch frmSearch = new FrmSearch();
            frmSearch.Tag = (object)this.LangArEn;
            foreach (KeyValuePair<string, FRSuppBalance.ColumnDictinary> keyValuePair in (IEnumerable<KeyValuePair<string, FRSuppBalance.ColumnDictinary>>)this.columns_Names_visible)
                frmSearch.columns_Names_visible.Add(keyValuePair.Key, new FrmSearch.SColumnDictinary(keyValuePair.Value.AText, keyValuePair.Value.EText, keyValuePair.Value.IfDefault, ""));
            VarGeneral.SFrmTyp = "T_AccDef2";
            VarGeneral.AccTyp = 5;
            frmSearch.TopMost = true;
            int num = (int)frmSearch.ShowDialog();
            if (frmSearch.SerachNo != "")
            {
                this.txtFromAccNo.Text = this.db.StockAccDefs(int.Parse(frmSearch.Serach_No)).AccDef_No;
                if (this.LangArEn == 0)
                    this.txtFromAccName.Text = this.db.StockAccDefs(int.Parse(frmSearch.Serach_No)).Arb_Des;
                else
                    this.txtFromAccName.Text = this.db.StockAccDefs(int.Parse(frmSearch.Serach_No)).Eng_Des;
            }
            else
            {
                this.txtFromAccNo.Text = "";
                this.txtFromAccName.Text = "";
            }
        }
        private void button_SrchAccTo_Click(object sender, EventArgs e)
        {
            this.columns_Names_visible.Clear();
            this.columns_Names_visible.Add("AccDef_No", new FRSuppBalance.ColumnDictinary("الرقم ", " No", true, ""));
            this.columns_Names_visible.Add("Arb_Des", new FRSuppBalance.ColumnDictinary("الاسم عربي", "Arabic Name", true, ""));
            this.columns_Names_visible.Add("Eng_Des", new FRSuppBalance.ColumnDictinary("الاسم الانجليزي", "English Name", true, ""));
            this.columns_Names_visible.Add("AccDef_ID", new FRSuppBalance.ColumnDictinary(" ", " ", false, ""));
            this.columns_Names_visible.Add("Mobile", new FRSuppBalance.ColumnDictinary("الجوال", "Mobile", false, ""));
            this.columns_Names_visible.Add("TaxNo", new FRSuppBalance.ColumnDictinary("الرقم الضريبي", "Tax No", false, ""));
            FrmSearch frmSearch = new FrmSearch();
            frmSearch.Tag = (object)this.LangArEn;
            foreach (KeyValuePair<string, FRSuppBalance.ColumnDictinary> keyValuePair in (IEnumerable<KeyValuePair<string, FRSuppBalance.ColumnDictinary>>)this.columns_Names_visible)
                frmSearch.columns_Names_visible.Add(keyValuePair.Key, new FrmSearch.SColumnDictinary(keyValuePair.Value.AText, keyValuePair.Value.EText, keyValuePair.Value.IfDefault, ""));
            VarGeneral.SFrmTyp = "T_AccDef2";
            VarGeneral.AccTyp = 5;
            frmSearch.TopMost = true;
            int num = (int)frmSearch.ShowDialog();
            if (frmSearch.SerachNo != "")
            {
                this.txtIntoAccNo.Text = this.db.StockAccDefs(int.Parse(frmSearch.Serach_No)).AccDef_No;
                if (this.LangArEn == 0)
                    this.txtIntoAccName.Text = this.db.StockAccDefs(int.Parse(frmSearch.Serach_No)).Arb_Des;
                else
                    this.txtIntoAccName.Text = this.db.StockAccDefs(int.Parse(frmSearch.Serach_No)).Eng_Des;
            }
            else
            {
                this.txtIntoAccNo.Text = "";
                this.txtIntoAccName.Text = "";
            }
        }
        private void button_SrchCostNo_Click(object sender, EventArgs e)
        {
            this.columns_Names_visible.Clear();
            this.columns_Names_visible.Add("Cst_No", new FRSuppBalance.ColumnDictinary("مركز التكلفة", "Cost Center No", true, ""));
            this.columns_Names_visible.Add("Arb_Des", new FRSuppBalance.ColumnDictinary("الاسم عربي", "Arabic Name", true, ""));
            this.columns_Names_visible.Add("Eng_Des", new FRSuppBalance.ColumnDictinary("الاسم الانجليزي", "English Name", true, ""));
            FrmSearch frmSearch = new FrmSearch();
            frmSearch.Tag = (object)this.LangArEn;
            foreach (KeyValuePair<string, FRSuppBalance.ColumnDictinary> keyValuePair in (IEnumerable<KeyValuePair<string, FRSuppBalance.ColumnDictinary>>)this.columns_Names_visible)
                frmSearch.columns_Names_visible.Add(keyValuePair.Key, new FrmSearch.SColumnDictinary(keyValuePair.Value.AText, keyValuePair.Value.EText, keyValuePair.Value.IfDefault, ""));
            VarGeneral.SFrmTyp = "T_CstTbl";
            frmSearch.TopMost = true;
            int num = (int)frmSearch.ShowDialog();
            if (frmSearch.SerachNo != "")
            {
                this.txtCostCNo.Text = this.db.StockCst(frmSearch.Serach_No).Cst_ID.ToString();
                if (this.LangArEn == 0)
                    this.txtCostCName.Text = this.db.StockCst(frmSearch.Serach_No).Arb_Des.ToString();
                else
                    this.txtCostCName.Text = this.db.StockCst(frmSearch.Serach_No).Eng_Des.ToString();
            }
            else
            {
                this.txtCostCNo.Text = "";
                this.txtCostCName.Text = "";
            }
        }
        private void button_SrchLegNo_Click(object sender, EventArgs e)
        {
            this.columns_Names_visible.Clear();
            this.columns_Names_visible.Add("Mnd_No", new FRSuppBalance.ColumnDictinary("رقم المندوب", "Commissary No", true, ""));
            this.columns_Names_visible.Add("Arb_Des", new FRSuppBalance.ColumnDictinary("الاسم عربي", "Arabic Name", true, ""));
            this.columns_Names_visible.Add("Eng_Des", new FRSuppBalance.ColumnDictinary("الاسم الانجليزي", "English Name", true, ""));
            FrmSearch frmSearch = new FrmSearch();
            frmSearch.Tag = (object)this.LangArEn;
            foreach (KeyValuePair<string, FRSuppBalance.ColumnDictinary> keyValuePair in (IEnumerable<KeyValuePair<string, FRSuppBalance.ColumnDictinary>>)this.columns_Names_visible)
                frmSearch.columns_Names_visible.Add(keyValuePair.Key, new FrmSearch.SColumnDictinary(keyValuePair.Value.AText, keyValuePair.Value.EText, keyValuePair.Value.IfDefault, ""));
            VarGeneral.SFrmTyp = "T_Mndob";
            frmSearch.TopMost = true;
            int num = (int)frmSearch.ShowDialog();
            if (frmSearch.SerachNo != "")
            {
                this.txtLegateNo.Text = this.db.StockMndob(frmSearch.Serach_No).Mnd_ID.ToString();
                if (this.LangArEn == 0)
                    this.txtLegateName.Text = this.db.StockMndob(frmSearch.Serach_No).Arb_Des.ToString();
                else
                    this.txtLegateName.Text = this.db.StockMndob(frmSearch.Serach_No).Eng_Des.ToString();
            }
            else
            {
                this.txtLegateNo.Text = "";
                this.txtLegateName.Text = "";
            }
        }
        private void button_SrchUsrNo_Click(object sender, EventArgs e)
        {
            this.columns_Names_visible.Clear();
            this.columns_Names_visible.Add("UsrNo", new FRSuppBalance.ColumnDictinary("رقم المستخدم", "User No", true, ""));
            this.columns_Names_visible.Add("UsrNamA", new FRSuppBalance.ColumnDictinary("الاسم عربي", "Arabic Name", true, ""));
            this.columns_Names_visible.Add("UsrNamE", new FRSuppBalance.ColumnDictinary("الاسم الانجليزي", "English Name", true, ""));
            FrmSearch frmSearch = new FrmSearch();
            frmSearch.Tag = (object)this.LangArEn;
            foreach (KeyValuePair<string, FRSuppBalance.ColumnDictinary> keyValuePair in (IEnumerable<KeyValuePair<string, FRSuppBalance.ColumnDictinary>>)this.columns_Names_visible)
                frmSearch.columns_Names_visible.Add(keyValuePair.Key, new FrmSearch.SColumnDictinary(keyValuePair.Value.AText, keyValuePair.Value.EText, keyValuePair.Value.IfDefault, ""));
            VarGeneral.SFrmTyp = "T_User";
            frmSearch.TopMost = true;
            int num = (int)frmSearch.ShowDialog();
            if (frmSearch.SerachNo != "")
            {
                this.txtUserNo.Text = frmSearch.Serach_No;
                if (this.LangArEn == 0)
                    this.txtUserName.Text = this.dbc.StockUser(frmSearch.Serach_No).UsrNamA.ToString();
                else
                    this.txtUserName.Text = this.dbc.StockUser(frmSearch.Serach_No).UsrNamE.ToString();
            }
            else
            {
                this.txtUserNo.Text = "";
                this.txtUserName.Text = "";
            }
        }
        private void txtMFromDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(this.txtMFromDate.Text))
                    this.txtMFromDate.Text = Convert.ToDateTime(this.txtMFromDate.Text).ToString("yyyy/MM/dd");
                else
                    this.txtMFromDate.Text = "";
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
                if (VarGeneral.CheckDate(this.txtMToDate.Text))
                    this.txtMToDate.Text = Convert.ToDateTime(this.txtMToDate.Text).ToString("yyyy/MM/dd");
                else
                    this.txtMToDate.Text = "";
            }
            catch
            {
                this.txtMToDate.Text = "";
            }
        }
        private void RibunButtons()
        {
            if (this.LangArEn == 0)
            {
                this.ButExit.Text = "خــــروج Esc";
                this.ButOk.Text = VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0" ? "طبـــاعة F5" : "عــــرض F5";
                this.groupBox3.Text = "الرصيــــد";
                this.groupBox4.Text = "التاريــــخ";
                this.label1.Text = "مـــــن :";
                this.label2.Text = "إلـــــى :";
                this.label5.Text = "من حساب :";
                this.label6.Text = "الى حساب :";
                this.label7.Text = "المنـــــدوب :";
                this.label8.Text = "مركز التكلفة :";
                this.label9.Text = "المستخـــدم :";
                this.label10.Text = "المستوى :";
                this.switchButton_CalclatAge.OnText = "احتساب العمر حسب 15 يوم";
                this.switchButton_CalclatAge.OffText = "احتساب العمر حسب 30 يوم";
            }
            else
            {
                this.ButExit.Text = "Exit Esc";
                this.ButOk.Text = VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0" ? "Print F5" : "Show F5";
                this.groupBox3.Text = "Balance";
                this.groupBox4.Text = "Date";
                this.label1.Text = "From :";
                this.label2.Text = "To :";
                this.label5.Text = "Account From :";
                this.label6.Text = "Account To :";
                this.label7.Text = "Delegate :";
                this.label8.Text = "Cost Center :";
                this.label9.Text = "User :";
                this.label10.Text = "Level :";
                this.switchButton_CalclatAge.OnText = "Calculates age by 15 days";
                this.switchButton_CalclatAge.OffText = "Calculates age by 30 days";
            }
        }
        private void FRSuppBalance_Load(object sender, EventArgs e)
        {
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
    }
}
