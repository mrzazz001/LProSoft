// Decompiled with JetBrains decompiler
// Type: InvAcc.Forms.FRSuppBalance
// Assembly: InvAcc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 22382E79-651B-4067-A397-F79FBCB141B5
// Assembly location: C:\Program Files (x86)\PROSOFT\InvAccc\InvAcc.exe
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using Framework.UI;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
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
    public partial class FRSuppBalance : Form
    {
        private int LangArEn = 0;
        private T_User _User = new T_User();
        public Dictionary<string, FRSuppBalance.ColumnDictinary> columns_Names_visible = new Dictionary<string, FRSuppBalance.ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private string having_ = " ";
        private IContainer components = (IContainer)null;
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
            this.InitializeComponent();
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
                this.label7.Text = this.LangArEn == 0 ? "?????? ?????????????? :" : "Car Type :";
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptBus.dll"))
            {
                this.label8.Text = this.LangArEn == 0 ? "?????????? :" : "Bus :";
                this.label7.Text = this.LangArEn == 0 ? "???????????? :" : "Driver :";
            }
            if (!File.Exists(Application.StartupPath + "\\Script\\SecriptWaterPackages.dll"))
                return;
            this.label7.Text = this.LangArEn == 0 ? "???????????????????????????? :" : "Customer :";
            this.label8.Text = this.LangArEn == 0 ? "?????????????????? :" : "Car :";
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
                        this.Text = "?????????? ????????????????";
                        this.FlexField.Rows.Count = 6;
                        this.FlexField.SetData(0, 0, (object)"??????????");
                        this.FlexField.SetData(0, 1, (object)"?????? ??????????");
                        this.FlexField.SetData(1, 1, (object)"[?????? ????????????]");
                        this.FlexField.SetData(1, 2, (object)" T_AccDef.AccDef_No ");
                        this.FlexField.SetData(2, 1, (object)"[?????? ????????????]");
                        this.FlexField.SetData(2, 2, (object)" T_AccDef.Arb_Des as AccDefNm ");
                        this.FlexField.SetData(3, 1, (object)"[???????? ??????????]");
                        this.FlexField.SetData(3, 2, (object)" Sum(CASE WHEN T_GDDET.gdValue > 0 THEN T_GDDET.gdValue ELSE 0 END) as Debit ");
                        this.FlexField.SetData(4, 1, (object)"[???????? ??????????]");
                        this.FlexField.SetData(4, 2, (object)" Sum(CASE WHEN T_GDDET.gdValue < 0 THEN Abs(T_GDDET.gdValue) ELSE 0 END) as Credit ");
                        this.FlexField.SetData(5, 1, (object)"[????????????]");
                        this.FlexField.SetData(5, 2, (object)" Sum(T_GDDET.gdValue) as Balance ");
                        this.FlexField.Tag = (object)" Group by T_AccDef.AccDef_No,T_AccDef.Arb_Des,T_SYSSETTING.LogImg ";
                        break;
                    case 2:
                        this.Text = "???????????????? ????????????????";
                        this.FlexField.Rows.Count = 6;
                        this.FlexField.SetData(0, 0, (object)"??????????");
                        this.FlexField.SetData(0, 1, (object)"?????? ??????????");
                        this.FlexField.SetData(1, 1, (object)"[?????? ????????????]");
                        this.FlexField.SetData(1, 2, (object)" T_AccDef.AccDef_No ");
                        this.FlexField.SetData(2, 1, (object)"[?????? ????????????]");
                        this.FlexField.SetData(2, 2, (object)" T_AccDef.Arb_Des as AccDefNm ");
                        this.FlexField.SetData(3, 1, (object)"[???????? ??????????]");
                        this.FlexField.SetData(3, 2, (object)" Sum(CASE WHEN T_GDDET.gdValue > 0 THEN T_GDDET.gdValue ELSE 0 END) as Debit ");
                        this.FlexField.SetData(4, 1, (object)"[???????? ??????????]");
                        this.FlexField.SetData(4, 2, (object)" Sum(CASE WHEN T_GDDET.gdValue < 0 THEN Abs(T_GDDET.gdValue) ELSE 0 END) as Credit ");
                        this.FlexField.SetData(5, 1, (object)"[????????????]");
                        this.FlexField.SetData(5, 2, (object)" Sum(T_GDDET.gdValue) as Balance ");
                        this.FlexField.Tag = (object)" Group by T_AccDef.AccDef_No,T_AccDef.Arb_Des,T_SYSSETTING.LogImg ";
                        break;
                    case 3:
                        this.Text = "???????? ????????????????";
                        this.FlexField.Rows.Count = 4;
                        this.FlexField.SetData(0, 0, (object)"??????????");
                        this.FlexField.SetData(0, 1, (object)"?????? ??????????");
                        this.FlexField.SetData(1, 1, (object)"[?????? ????????????]");
                        this.FlexField.SetData(1, 2, (object)" T_AccDef.AccDef_No ");
                        this.FlexField.SetData(2, 1, (object)"[?????? ????????????]");
                        this.FlexField.SetData(2, 2, (object)" T_AccDef.Arb_Des as AccDefNm ");
                        this.FlexField.SetData(3, 1, (object)"[????????????]");
                        this.FlexField.SetData(3, 2, (object)" Sum(T_GDDET.gdValue) as Balance ");
                        this.FlexField.Tag = (object)" Group by T_AccDef.AccDef_No,T_AccDef.Arb_Des,T_SYSSETTING.LogImg ";
                        break;
                    case 4:
                        this.Text = "?????? ????????????????";
                        this.FlexField.Rows.Count = 4;
                        this.FlexField.SetData(0, 0, (object)"??????????");
                        this.FlexField.SetData(0, 1, (object)"?????? ??????????");
                        this.FlexField.SetData(1, 1, (object)"[?????? ????????????]");
                        this.FlexField.SetData(1, 2, (object)" T_AccDef.AccDef_No ");
                        this.FlexField.SetData(2, 1, (object)"[?????? ????????????]");
                        this.FlexField.SetData(2, 2, (object)" T_AccDef.Arb_Des as AccDefNm ");
                        this.FlexField.SetData(3, 1, (object)"[????????????]");
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
            string str2 = "";
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
                            str1 = str5 + " Sum(CASE WHEN T_GDDET.gdValue > 0 and T_GDHEAD.gdGDate >= '" + str6 + "' and T_GDHEAD.gdGDate < '" + str7 + "' THEN T_GDDET.gdValue ELSE 0 END) as [?????????????????? " + (object)index + "] " + "," + " Sum(CASE WHEN T_GDDET.gdValue < 0 and T_GDHEAD.gdGDate >= '" + str6 + "' and T_GDHEAD.gdGDate < '" + str7 + "' THEN Abs(T_GDDET.gdValue) ELSE 0 END) as [???????????????? " + (object)index + "] ";
                        }
                        else
                        {
                            string str5 = str1 + ",";
                            string str6 = hijriGregDates2.FormatGreg("1/" + (object)index + "/" + str4, "yyyy/MM/dd");
                            str1 = str5 + " Sum(CASE WHEN T_GDDET.gdValue > 0 and T_GDHEAD.gdGDate >= '" + str6 + "' THEN T_GDDET.gdValue ELSE 0 END) as [?????????????????? " + (object)index + "] " + "," + " Sum(CASE WHEN T_GDDET.gdValue < 0 and T_GDHEAD.gdGDate >= '" + str6 + "' THEN Abs(T_GDDET.gdValue) ELSE 0 END) as [???????????????? " + (object)index + "] ";
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
                    int num1 = (int)MessageBox.Show(this.LangArEn == 0 ? "???????? .. ???? ???????? ???????????? ???????????? ???? ?????????????? " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
            this.columns_Names_visible.Add("AccDef_No", new FRSuppBalance.ColumnDictinary("?????????? ", " No", true, ""));
            this.columns_Names_visible.Add("Arb_Des", new FRSuppBalance.ColumnDictinary("?????????? ????????", "Arabic Name", true, ""));
            this.columns_Names_visible.Add("Eng_Des", new FRSuppBalance.ColumnDictinary("?????????? ??????????????????", "English Name", true, ""));
            this.columns_Names_visible.Add("AccDef_ID", new FRSuppBalance.ColumnDictinary(" ", " ", false, ""));
            this.columns_Names_visible.Add("Mobile", new FRSuppBalance.ColumnDictinary("????????????", "Mobile", false, ""));
            this.columns_Names_visible.Add("TaxNo", new FRSuppBalance.ColumnDictinary("?????????? ??????????????", "Tax No", false, ""));
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
            this.columns_Names_visible.Add("AccDef_No", new FRSuppBalance.ColumnDictinary("?????????? ", " No", true, ""));
            this.columns_Names_visible.Add("Arb_Des", new FRSuppBalance.ColumnDictinary("?????????? ????????", "Arabic Name", true, ""));
            this.columns_Names_visible.Add("Eng_Des", new FRSuppBalance.ColumnDictinary("?????????? ??????????????????", "English Name", true, ""));
            this.columns_Names_visible.Add("AccDef_ID", new FRSuppBalance.ColumnDictinary(" ", " ", false, ""));
            this.columns_Names_visible.Add("Mobile", new FRSuppBalance.ColumnDictinary("????????????", "Mobile", false, ""));
            this.columns_Names_visible.Add("TaxNo", new FRSuppBalance.ColumnDictinary("?????????? ??????????????", "Tax No", false, ""));
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
            this.columns_Names_visible.Add("Cst_No", new FRSuppBalance.ColumnDictinary("???????? ??????????????", "Cost Center No", true, ""));
            this.columns_Names_visible.Add("Arb_Des", new FRSuppBalance.ColumnDictinary("?????????? ????????", "Arabic Name", true, ""));
            this.columns_Names_visible.Add("Eng_Des", new FRSuppBalance.ColumnDictinary("?????????? ??????????????????", "English Name", true, ""));
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
            this.columns_Names_visible.Add("Mnd_No", new FRSuppBalance.ColumnDictinary("?????? ??????????????", "Commissary No", true, ""));
            this.columns_Names_visible.Add("Arb_Des", new FRSuppBalance.ColumnDictinary("?????????? ????????", "Arabic Name", true, ""));
            this.columns_Names_visible.Add("Eng_Des", new FRSuppBalance.ColumnDictinary("?????????? ??????????????????", "English Name", true, ""));
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
            this.columns_Names_visible.Add("UsrNo", new FRSuppBalance.ColumnDictinary("?????? ????????????????", "User No", true, ""));
            this.columns_Names_visible.Add("UsrNamA", new FRSuppBalance.ColumnDictinary("?????????? ????????", "Arabic Name", true, ""));
            this.columns_Names_visible.Add("UsrNamE", new FRSuppBalance.ColumnDictinary("?????????? ??????????????????", "English Name", true, ""));
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
                this.ButExit.Text = "???????????????? Esc";
                this.ButOk.Text = VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0" ? "???????????????? F5" : "?????????????? F5";
                this.groupBox3.Text = "????????????????????";
                this.groupBox4.Text = "??????????????????????";
                this.label1.Text = "?????????????? :";
                this.label2.Text = "???????????????? :";
                this.label5.Text = "???? ???????? :";
                this.label6.Text = "?????? ???????? :";
                this.label7.Text = "???????????????????????? :";
                this.label8.Text = "???????? ?????????????? :";
                this.label9.Text = "?????????????????????? :";
                this.label10.Text = "?????????????? :";
                this.switchButton_CalclatAge.OnText = "???????????? ?????????? ?????? 15 ??????";
                this.switchButton_CalclatAge.OffText = "???????????? ?????????? ?????? 30 ??????";
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
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRSuppBalance));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            components = new System.ComponentModel.Container();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.switchButton_CalclatAge = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.label10 = new System.Windows.Forms.Label();
            this.numUpDownLevel = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMToDate = new System.Windows.Forms.MaskedTextBox();
            this.txtMFromDate = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtMBalanceB = new DevComponents.Editors.DoubleInput();
            this.txtMBalanceS = new DevComponents.Editors.DoubleInput();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIntoAccName = new System.Windows.Forms.TextBox();
            this.txtLegateName = new System.Windows.Forms.TextBox();
            this.txtFromAccName = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtFromAccNo = new System.Windows.Forms.TextBox();
            this.txtIntoAccNo = new System.Windows.Forms.TextBox();
            this.txtLegateNo = new System.Windows.Forms.TextBox();
            this.txtUserNo = new System.Windows.Forms.TextBox();
            this.button_SrchUsrNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchLegNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchAccTo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchAccFrom = new DevComponents.DotNetBar.ButtonX();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCostCName = new System.Windows.Forms.TextBox();
            this.txtCostCNo = new System.Windows.Forms.TextBox();
            this.button_SrchCostNo = new DevComponents.DotNetBar.ButtonX();
            this.label8 = new System.Windows.Forms.Label();
            this.ButExit = new DevComponents.DotNetBar.ButtonX();
            this.ButOk = new DevComponents.DotNetBar.ButtonX();
            this.FlexField = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.VisibleChanged += new System.EventHandler(this.FRInvoice_VisibleChanged);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.ribbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownLevel)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMBalanceB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMBalanceS)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlexField)).BeginInit();
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
            this.ribbonBar1.Controls.Add(this.switchButton_CalclatAge);
            this.ribbonBar1.Controls.Add(this.label10);
            this.ribbonBar1.Controls.Add(this.numUpDownLevel);
            this.ribbonBar1.Controls.Add(this.groupBox4);
            this.ribbonBar1.Controls.Add(this.groupBox3);
            this.ribbonBar1.Controls.Add(this.groupBox2);
            this.ribbonBar1.Controls.Add(this.ButExit);
            this.ribbonBar1.Controls.Add(this.ButOk);
            this.ribbonBar1.Controls.Add(this.FlexField);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(418, 385);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 1100;
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
            // switchButton_CalclatAge
            // 
            // 
            // 
            // 
            this.switchButton_CalclatAge.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_CalclatAge.Location = new System.Drawing.Point(12, 292);
            this.switchButton_CalclatAge.Name = "switchButton_CalclatAge";
            this.switchButton_CalclatAge.OffBackColor = System.Drawing.Color.SteelBlue;
            this.switchButton_CalclatAge.OffText = "???????????? ?????????? ?????? 30 ??????";
            this.switchButton_CalclatAge.OffTextColor = System.Drawing.Color.White;
            this.switchButton_CalclatAge.OnBackColor = System.Drawing.Color.DarkSeaGreen;
            this.switchButton_CalclatAge.OnText = "???????????? ?????????? ?????? 15 ??????";
            this.switchButton_CalclatAge.OnTextColor = System.Drawing.Color.Black;
            this.switchButton_CalclatAge.Size = new System.Drawing.Size(197, 26);
            this.switchButton_CalclatAge.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_CalclatAge.SwitchWidth = 25;
            this.switchButton_CalclatAge.TabIndex = 6744;
            this.switchButton_CalclatAge.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(328, 299);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 1173;
            this.label10.Text = "?????????????? :";
            // 
            // numUpDownLevel
            // 
            this.numUpDownLevel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.numUpDownLevel.Location = new System.Drawing.Point(219, 293);
            this.numUpDownLevel.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numUpDownLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDownLevel.Name = "numUpDownLevel";
            this.numUpDownLevel.Size = new System.Drawing.Size(108, 24);
            this.numUpDownLevel.TabIndex = 20;
            this.numUpDownLevel.Tag = " T_AccDef.Lev";
            this.numUpDownLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUpDownLevel.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.txtMToDate);
            this.groupBox4.Controls.Add(this.txtMFromDate);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.groupBox4.Location = new System.Drawing.Point(12, 18);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(391, 52);
            this.groupBox4.TabIndex = 1171;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "?????? ??????????????";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(320, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 866;
            this.label1.Text = "?????????????? :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMToDate
            // 
            this.txtMToDate.Location = new System.Drawing.Point(23, 21);
            this.txtMToDate.Mask = "0000/00/00";
            this.txtMToDate.Name = "txtMToDate";
            this.txtMToDate.Size = new System.Drawing.Size(108, 21);
            this.txtMToDate.TabIndex = 2;
            this.txtMToDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMToDate.Click += new System.EventHandler(this.txtMToDate_Click);
            this.txtMToDate.Leave += new System.EventHandler(this.txtMToDate_Leave);
            // 
            // txtMFromDate
            // 
            this.txtMFromDate.Location = new System.Drawing.Point(203, 21);
            this.txtMFromDate.Mask = "0000/00/00";
            this.txtMFromDate.Name = "txtMFromDate";
            this.txtMFromDate.Size = new System.Drawing.Size(108, 21);
            this.txtMFromDate.TabIndex = 1;
            this.txtMFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMFromDate.Click += new System.EventHandler(this.txtMFromDate_Click);
            this.txtMFromDate.Leave += new System.EventHandler(this.txtMFromDate_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(135, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 861;
            this.label2.Text = "???????????????? :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.txtMBalanceB);
            this.groupBox3.Controls.Add(this.txtMBalanceS);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.groupBox3.Location = new System.Drawing.Point(12, 77);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(391, 52);
            this.groupBox3.TabIndex = 1172;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "????????????????????";
            // 
            // txtMBalanceB
            // 
            this.txtMBalanceB.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtMBalanceB.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtMBalanceB.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtMBalanceB.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMBalanceB.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtMBalanceB.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtMBalanceB.Increment = 1D;
            this.txtMBalanceB.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtMBalanceB.Location = new System.Drawing.Point(207, 20);
            this.txtMBalanceB.LockUpdateChecked = false;
            this.txtMBalanceB.Name = "txtMBalanceB";
            this.txtMBalanceB.ShowCheckBox = true;
            this.txtMBalanceB.ShowUpDown = true;
            this.txtMBalanceB.Size = new System.Drawing.Size(108, 20);
            this.txtMBalanceB.TabIndex = 1149;
            this.txtMBalanceB.Tag = "Sum(T_GDDET.gdValue)";
            // 
            // txtMBalanceS
            // 
            this.txtMBalanceS.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtMBalanceS.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtMBalanceS.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtMBalanceS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMBalanceS.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtMBalanceS.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtMBalanceS.Increment = 1D;
            this.txtMBalanceS.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtMBalanceS.Location = new System.Drawing.Point(23, 20);
            this.txtMBalanceS.LockUpdateChecked = false;
            this.txtMBalanceS.Name = "txtMBalanceS";
            this.txtMBalanceS.ShowCheckBox = true;
            this.txtMBalanceS.ShowUpDown = true;
            this.txtMBalanceS.Size = new System.Drawing.Size(108, 20);
            this.txtMBalanceS.TabIndex = 1148;
            this.txtMBalanceS.Tag = "Sum(T_GDDET.gdValue)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(320, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 1145;
            this.label3.Text = "?????????????? :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(135, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 859;
            this.label4.Text = "???????? ???? = :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtIntoAccName);
            this.groupBox2.Controls.Add(this.txtLegateName);
            this.groupBox2.Controls.Add(this.txtFromAccName);
            this.groupBox2.Controls.Add(this.txtUserName);
            this.groupBox2.Controls.Add(this.txtFromAccNo);
            this.groupBox2.Controls.Add(this.txtIntoAccNo);
            this.groupBox2.Controls.Add(this.txtLegateNo);
            this.groupBox2.Controls.Add(this.txtUserNo);
            this.groupBox2.Controls.Add(this.button_SrchUsrNo);
            this.groupBox2.Controls.Add(this.button_SrchLegNo);
            this.groupBox2.Controls.Add(this.button_SrchAccTo);
            this.groupBox2.Controls.Add(this.button_SrchAccFrom);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtCostCName);
            this.groupBox2.Controls.Add(this.txtCostCNo);
            this.groupBox2.Controls.Add(this.button_SrchCostNo);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(12, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(393, 149);
            this.groupBox2.TabIndex = 1170;
            this.groupBox2.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(312, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 1159;
            this.label9.Text = "???????????????? :";
            // 
            // txtIntoAccName
            // 
            this.txtIntoAccName.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtIntoAccName.ForeColor = System.Drawing.Color.White;
            this.txtIntoAccName.Location = new System.Drawing.Point(8, 42);
            this.txtIntoAccName.Name = "txtIntoAccName";
            this.txtIntoAccName.ReadOnly = true;
            this.txtIntoAccName.Size = new System.Drawing.Size(188, 20);
            this.txtIntoAccName.TabIndex = 10;
            this.txtIntoAccName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLegateName
            // 
            this.txtLegateName.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtLegateName.ForeColor = System.Drawing.Color.White;
            this.txtLegateName.Location = new System.Drawing.Point(8, 67);
            this.txtLegateName.Name = "txtLegateName";
            this.txtLegateName.ReadOnly = true;
            this.txtLegateName.Size = new System.Drawing.Size(188, 20);
            this.txtLegateName.TabIndex = 13;
            this.txtLegateName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFromAccName
            // 
            this.txtFromAccName.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtFromAccName.ForeColor = System.Drawing.Color.White;
            this.txtFromAccName.Location = new System.Drawing.Point(8, 17);
            this.txtFromAccName.Name = "txtFromAccName";
            this.txtFromAccName.ReadOnly = true;
            this.txtFromAccName.Size = new System.Drawing.Size(188, 20);
            this.txtFromAccName.TabIndex = 7;
            this.txtFromAccName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtUserName.ForeColor = System.Drawing.Color.White;
            this.txtUserName.Location = new System.Drawing.Point(8, 92);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(188, 20);
            this.txtUserName.TabIndex = 16;
            this.txtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFromAccNo
            // 
            this.txtFromAccNo.BackColor = System.Drawing.Color.White;
            this.txtFromAccNo.Location = new System.Drawing.Point(228, 17);
            this.txtFromAccNo.Name = "txtFromAccNo";
            this.txtFromAccNo.ReadOnly = true;
            this.txtFromAccNo.Size = new System.Drawing.Size(79, 20);
            this.txtFromAccNo.TabIndex = 5;
            this.txtFromAccNo.Tag = " T_GDDET.AccNo ";
            this.txtFromAccNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIntoAccNo
            // 
            this.txtIntoAccNo.BackColor = System.Drawing.Color.White;
            this.txtIntoAccNo.Location = new System.Drawing.Point(228, 42);
            this.txtIntoAccNo.Name = "txtIntoAccNo";
            this.txtIntoAccNo.ReadOnly = true;
            this.txtIntoAccNo.Size = new System.Drawing.Size(79, 20);
            this.txtIntoAccNo.TabIndex = 8;
            this.txtIntoAccNo.Tag = " T_GDDET.AccNo ";
            this.txtIntoAccNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLegateNo
            // 
            this.txtLegateNo.BackColor = System.Drawing.Color.White;
            this.txtLegateNo.Location = new System.Drawing.Point(228, 67);
            this.txtLegateNo.Name = "txtLegateNo";
            this.txtLegateNo.ReadOnly = true;
            this.txtLegateNo.Size = new System.Drawing.Size(79, 20);
            this.txtLegateNo.TabIndex = 11;
            this.txtLegateNo.Tag = " T_GDHEAD.gdMnd";
            this.txtLegateNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUserNo
            // 
            this.txtUserNo.BackColor = System.Drawing.Color.White;
            this.txtUserNo.Location = new System.Drawing.Point(228, 92);
            this.txtUserNo.Name = "txtUserNo";
            this.txtUserNo.ReadOnly = true;
            this.txtUserNo.Size = new System.Drawing.Size(79, 20);
            this.txtUserNo.TabIndex = 14;
            this.txtUserNo.Tag = " T_GDHEAD.gdUser";
            this.txtUserNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_SrchUsrNo
            // 
            this.button_SrchUsrNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchUsrNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchUsrNo.Location = new System.Drawing.Point(199, 92);
            this.button_SrchUsrNo.Name = "button_SrchUsrNo";
            this.button_SrchUsrNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchUsrNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchUsrNo.Symbol = "???";
            this.button_SrchUsrNo.SymbolSize = 12F;
            this.button_SrchUsrNo.TabIndex = 15;
            this.button_SrchUsrNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchUsrNo.Click += new System.EventHandler(this.button_SrchUsrNo_Click);
            // 
            // button_SrchLegNo
            // 
            this.button_SrchLegNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchLegNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchLegNo.Location = new System.Drawing.Point(199, 67);
            this.button_SrchLegNo.Name = "button_SrchLegNo";
            this.button_SrchLegNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchLegNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchLegNo.Symbol = "???";
            this.button_SrchLegNo.SymbolSize = 12F;
            this.button_SrchLegNo.TabIndex = 12;
            this.button_SrchLegNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchLegNo.Click += new System.EventHandler(this.button_SrchLegNo_Click);
            // 
            // button_SrchAccTo
            // 
            this.button_SrchAccTo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchAccTo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchAccTo.Location = new System.Drawing.Point(199, 42);
            this.button_SrchAccTo.Name = "button_SrchAccTo";
            this.button_SrchAccTo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchAccTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchAccTo.Symbol = "???";
            this.button_SrchAccTo.SymbolSize = 12F;
            this.button_SrchAccTo.TabIndex = 9;
            this.button_SrchAccTo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchAccTo.Click += new System.EventHandler(this.button_SrchAccTo_Click);
            // 
            // button_SrchAccFrom
            // 
            this.button_SrchAccFrom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchAccFrom.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchAccFrom.Location = new System.Drawing.Point(199, 17);
            this.button_SrchAccFrom.Name = "button_SrchAccFrom";
            this.button_SrchAccFrom.Size = new System.Drawing.Size(26, 20);
            this.button_SrchAccFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchAccFrom.Symbol = "???";
            this.button_SrchAccFrom.SymbolSize = 12F;
            this.button_SrchAccFrom.TabIndex = 6;
            this.button_SrchAccFrom.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchAccFrom.Click += new System.EventHandler(this.button_SrchAccFrom_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(312, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 1147;
            this.label7.Text = "???????????????????????? :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(312, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 1146;
            this.label6.Text = "?????? ???????? :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(312, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 1148;
            this.label5.Text = "???? ???????? :";
            // 
            // txtCostCName
            // 
            this.txtCostCName.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtCostCName.ForeColor = System.Drawing.Color.White;
            this.txtCostCName.Location = new System.Drawing.Point(8, 116);
            this.txtCostCName.Name = "txtCostCName";
            this.txtCostCName.ReadOnly = true;
            this.txtCostCName.Size = new System.Drawing.Size(188, 20);
            this.txtCostCName.TabIndex = 19;
            this.txtCostCName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCostCNo
            // 
            this.txtCostCNo.BackColor = System.Drawing.Color.White;
            this.txtCostCNo.Location = new System.Drawing.Point(228, 116);
            this.txtCostCNo.Name = "txtCostCNo";
            this.txtCostCNo.ReadOnly = true;
            this.txtCostCNo.Size = new System.Drawing.Size(79, 20);
            this.txtCostCNo.TabIndex = 17;
            this.txtCostCNo.Tag = " T_GDHEAD.gdCstNo ";
            this.txtCostCNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_SrchCostNo
            // 
            this.button_SrchCostNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchCostNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCostNo.Location = new System.Drawing.Point(199, 116);
            this.button_SrchCostNo.Name = "button_SrchCostNo";
            this.button_SrchCostNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchCostNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCostNo.Symbol = "???";
            this.button_SrchCostNo.SymbolSize = 12F;
            this.button_SrchCostNo.TabIndex = 18;
            this.button_SrchCostNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCostNo.Click += new System.EventHandler(this.button_SrchCostNo_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(312, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 1145;
            this.label8.Text = "???????? ?????????????? :";
            // 
            // ButExit
            // 
            this.ButExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButExit.Checked = true;
            this.ButExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ButExit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButExit.Location = new System.Drawing.Point(8, 328);
            this.ButExit.Name = "ButExit";
            this.ButExit.Size = new System.Drawing.Size(198, 33);
            this.ButExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButExit.Symbol = "???";
            this.ButExit.SymbolSize = 16F;
            this.ButExit.TabIndex = 22;
            this.ButExit.Text = "??????????????";
            this.ButExit.TextColor = System.Drawing.Color.Black;
            this.ButExit.Click += new System.EventHandler(this.ButExit_Click);
            // 
            // ButOk
            // 
            this.ButOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButOk.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.ButOk.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButOk.Location = new System.Drawing.Point(210, 328);
            this.ButOk.Name = "ButOk";
            this.ButOk.Size = new System.Drawing.Size(199, 33);
            this.ButOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButOk.Symbol = "???";
            this.ButOk.SymbolSize = 16F;
            this.ButOk.TabIndex = 21;
            this.ButOk.Text = "????????????????";
            this.ButOk.TextColor = System.Drawing.Color.White;
            this.ButOk.Click += new System.EventHandler(this.ButOk_Click);
            // 
            // FlexField
            // 
            this.FlexField.AllowEditing = false;
            this.FlexField.ColumnInfo = resources.GetString("FlexField.ColumnInfo");
            this.FlexField.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FlexField.Location = new System.Drawing.Point(-242, 23);
            this.FlexField.Name = "FlexField";
            this.FlexField.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FlexField.Rows.DefaultSize = 19;
            this.FlexField.Size = new System.Drawing.Size(236, 289);
            this.FlexField.StyleInfo = resources.GetString("FlexField.StyleInfo");
            this.FlexField.TabIndex = 1140;
            this.FlexField.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System;
            // 
            // FRSuppBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 385);
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FRSuppBalance";
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FRSuppBalance_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.ribbonBar1.ResumeLayout(false);
            this.ribbonBar1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownLevel)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMBalanceB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMBalanceS)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlexField)).EndInit();
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.ResumeLayout(false);
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
