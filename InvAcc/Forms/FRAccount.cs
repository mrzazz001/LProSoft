using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
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
    public partial  class FRAccount : Form
    { void avs(int arln)

{ 
  checkBox_OldBCalcaluat.Text=   (arln == 0 ? "  إحتساب الرصيد السابق  " : "  Calculate the previous balance") ; label11.Text=   (arln == 0 ? "  حسب البيان :  " : "  According to the statement:") ; checkBox_BalanceMove.Text=   (arln == 0 ? "  تحريك الرصيد  " : "  balance move") ; checkBox_OldBlance.Text=   (arln == 0 ? "  إظهار الرصيد السابق  " : "  Show previous balance") ; label9.Text=   (arln == 0 ? "  العملـــــــــــة :  " : "  work:") ; label10.Text=   (arln == 0 ? "  ترتيب حسب :  " : "  sort by :") ; label8.Text=   (arln == 0 ? "  المستخـــدم :  " : "  User:") ; label6.Text=   (arln == 0 ? "  المنـــــدوب :  " : "  The delegate:") ; label5.Text=   (arln == 0 ? "  الحســـاب :  " : "  Account:") ; groupBox4.Text=   (arln == 0 ? "  حسب التاريخ  " : "  by date") ; label1.Text=   (arln == 0 ? "  مـــــن :  " : "  from:") ; label2.Text=   (arln == 0 ? "  إلـــــى :  " : "  to:") ; groupBox3.Text=   (arln == 0 ? "  الرصيــــد  " : "  balance") ; label3.Text=   (arln == 0 ? "  مـــــن :  " : "  from:") ; label4.Text=   (arln == 0 ? "  أصغر من " : "  Younger than") ; label7.Text=   (arln == 0 ? "  مركز التكلفة :  " : "  cost center:") ; RButShort.Text=   (arln == 0 ? "  مختصر  " : "  short") ; RButDet.Text=   (arln == 0 ? "  تفصيلي  " : "  detailed") ; Text = "كشف حساب";this.Text=   (arln == 0 ? "  كشف حساب  " : "  Account statement") ;}
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
                        frm.Repvalue = "Account";
                        frm.Repvalue = "Account";
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
        private void FrmInvSale_SizeChanged(object sender, EventArgs e)
        {
            netResize1.Refresh();
        }
        private Panel PanelSpecialContainer;
        public Softgroup.NetResize.NetResize netResize1;
        private Label label8;
        private RibbonBar ribbonBar1;
        private TextBox txtLegateName;
        private TextBox txtMainAccName;
        private TextBox txtUserName;
        private TextBox txtCostCName;
        private TextBox txtLegateNo;
        private TextBox txtUserNo;
        private TextBox txtCostCNo;
        private Label label6;
        private Label label5;
        private Label label7;
        private ButtonX button_SrchUsrNo;
        private ButtonX button_SrchCostNo;
        private ButtonX button_SrchLegNo;
        private ButtonX button_SrchAccFrom;
        private GroupBox groupBox4;
        private Label label1;
        private Label label2;
        private GroupBox groupBox3;
        private Label label10;
        private ComboBoxEx combobox_SortTyp;
        private GroupBox groupBox2;
        public RadioButton RButShort;
        public RadioButton RButDet;
        public TextBox txtMainAccNo;
        public MaskedTextBox txtMToDate;
        public MaskedTextBox txtMFromDate;
        private ComboBoxEx CmbCurr;
        private Label label9;
        private DoubleInput txtMBalanceB;
        private DoubleInput txtMBalanceS;
        private Label label3;
        private Label label4;
        private CheckBoxX checkBox_OldBlance;
        private CheckBoxX checkBox_BalanceMove;
        private Label label11;
        private TextBoxX txtRemark;
        private CheckBoxX checkBox_OldBCalcaluat;
        private int LangArEn = 0;
        private T_User _User = new T_User();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private Stock_DataDataContext dbInstance;
        private C1.Win.C1Input.C1Button ButExit;
        private ControlContainerItem controlContainerItem1;
        private C1.Win.C1Input.C1Button ButOk;
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
        public FRAccount()
        {
            InitializeComponent();this.Load += langloads;
            _User = dbc.StockUser(VarGeneral.UserNumber);
            HijriGregDates dateFormatter = new HijriGregDates();
            if (VarGeneral.Settings_Sys.Calendr.Value == 0)
            {
                txtMFromDate.Text = VarGeneral.Gdate.Substring(0, 4) + "/01/01";
                txtMToDate.Text = dateFormatter.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
            }
            else
            {
                txtMFromDate.Text = VarGeneral.Hdate.Substring(0, 4) + "/01/01";
                txtMToDate.Text = dateFormatter.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
            }
            if (VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F" || VarGeneral.SSSLev == "S" || VarGeneral.SSSLev == "C")
            {
                label7.Visible = false;
                txtCostCNo.Visible = false;
                button_SrchCostNo.Visible = false;
                txtCostCName.Visible = false;
            }
            else
            {
                label7.Visible = true;
                txtCostCNo.Visible = true;
                button_SrchCostNo.Visible = true;
                txtCostCName.Visible = true;
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
            }
            catch
            {
            }
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
            {
                txtMBalanceB.DisplayFormat = VarGeneral.DicemalMask;
                txtMBalanceS.DisplayFormat = VarGeneral.DicemalMask;
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FRAccount));
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
                FillFlex();
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
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptMaintenanceCars.dll"))
                {
                    label7.Text = ((LangArEn == 0) ? "نوع السيارة :" : "Car Type :");
                }
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptBus.dll"))
                {
                    label7.Text = ((LangArEn == 0) ? "الباص :" : "Bus :");
                    label6.Text = ((LangArEn == 0) ? "السائق :" : "Driver :");
                }
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptWaterPackages.dll"))
                {
                    label6.Text = ((LangArEn == 0) ? "العميــــــــل :" : "Customer :");
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRAccount));
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
            FillFlex();
        }
        private void FillFlex()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                if (VarGeneral.InvType == 1)
                {
                    Text = "كشف حساب";
                }
            }
            else if (VarGeneral.InvType == 1)
            {
                Text = "Statement of Accounts";
            }
            RibunButtons();
            FillCombo();
        }
        private string BuildFieldList()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                return " T_GDDET.AccNo as AccDef_No,(select Arb_Des from T_AccDef where T_AccDef.AccDef_No = T_GDDET.AccNo) as AccDefNm, T_GDHEAD.gdNo,T_INVSETTING.InvNamA as InvNm,T_GDHEAD.gdHDate,T_GDHEAD.gdGDate,T_GDDET.gdDes,CASE WHEN T_GDDET.gdValue > 0 THEN " + ((CmbCurr.SelectedIndex > 0) ? (" case when T_GDHEAD.CurTyp != " + int.Parse(CmbCurr.SelectedValue.ToString()) + " then (Round((T_GDDET.gdValue * (select Rate from T_Curency where T_Curency.Curency_ID = T_GDHEAD.CurTyp)) / " + db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value + "," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) else T_GDDET.gdValue end ") : " T_GDDET.gdValue ") + " ELSE 0 END as Debit,CASE WHEN T_GDDET.gdValue < 0 THEN " + ((CmbCurr.SelectedIndex > 0) ? (" case when T_GDHEAD.CurTyp != " + int.Parse(CmbCurr.SelectedValue.ToString()) + " then (Round(Abs((T_GDDET.gdValue * (select Rate from T_Curency where T_Curency.Curency_ID = T_GDHEAD.CurTyp))) / " + db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value + "," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) else Abs(T_GDDET.gdValue) end ") : " Abs(T_GDDET.gdValue) ") + "  ELSE 0 END as Credit ," + ((CmbCurr.SelectedIndex > 0) ? (" case when T_GDHEAD.CurTyp != " + int.Parse(CmbCurr.SelectedValue.ToString()) + " then (Round((T_GDDET.gdValue * (select Rate from T_Curency where T_Curency.Curency_ID = T_GDHEAD.CurTyp)) / " + db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value + "," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) else (Round(T_GDDET.gdValue," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) end ") : (" (Round(T_GDDET.gdValue," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) ")) + " as Balance,T_SYSSETTING.LogImg,T_SYSSETTING.Calendr," + (checkBox_OldBCalcaluat.Checked ? " 2 as BalanceIsMove " : (checkBox_BalanceMove.Checked ? " 1 as BalanceIsMove " : "  0 as BalanceIsMove "));
            }
            return " T_GDDET.AccNo as AccDef_No,(select Eng_Des from T_AccDef where T_AccDef.AccDef_No = T_GDDET.AccNo) as AccDefNm, T_GDHEAD.gdNo,T_INVSETTING.InvNamE as InvNm,T_GDHEAD.gdHDate,T_GDHEAD.gdGDate,T_GDDET.gdDesE as gdDes,CASE WHEN T_GDDET.gdValue > 0 THEN " + ((CmbCurr.SelectedIndex > 0) ? (" case when T_GDHEAD.CurTyp != " + int.Parse(CmbCurr.SelectedValue.ToString()) + " then (Round((T_GDDET.gdValue * (select Rate from T_Curency where T_Curency.Curency_ID = T_GDHEAD.CurTyp)) / " + db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value + "," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) else T_GDDET.gdValue end ") : " T_GDDET.gdValue ") + " ELSE 0 END as Debit,CASE WHEN T_GDDET.gdValue < 0 THEN " + ((CmbCurr.SelectedIndex > 0) ? (" case when T_GDHEAD.CurTyp != " + int.Parse(CmbCurr.SelectedValue.ToString()) + " then (Round(Abs((T_GDDET.gdValue * (select Rate from T_Curency where T_Curency.Curency_ID = T_GDHEAD.CurTyp))) / " + db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value + "," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) else Abs(T_GDDET.gdValue) end ") : " Abs(T_GDDET.gdValue) ") + "  ELSE 0 END as Credit ," + ((CmbCurr.SelectedIndex > 0) ? (" case when T_GDHEAD.CurTyp != " + int.Parse(CmbCurr.SelectedValue.ToString()) + " then (Round((T_GDDET.gdValue * (select Rate from T_Curency where T_Curency.Curency_ID = T_GDHEAD.CurTyp)) / " + db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value + "," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) else (Round(T_GDDET.gdValue," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) end ") : (" (Round(T_GDDET.gdValue," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) ")) + " as Balance,T_SYSSETTING.LogImg,T_SYSSETTING.Calendr," + (checkBox_OldBCalcaluat.Checked ? " 2 as BalanceIsMove " : (checkBox_BalanceMove.Checked ? " 1 as BalanceIsMove " : "  0 as BalanceIsMove "));
        }
        private string BuildRuleList()
        {
            HijriGregDates dateFormatter = new HijriGregDates();
            string Rule = "Where 1 = 1 and T_GDHEAD.gdLok = 0 ";
            if (txtMBalanceB.LockUpdateChecked)
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtMBalanceB.Tag, " >= ", txtMBalanceB.Value);
            }
            if (txtMBalanceS.LockUpdateChecked)
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtMBalanceS.Tag, " <= ", txtMBalanceS.Value);
            }
            if (!string.IsNullOrEmpty(txtMainAccNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtMainAccNo.Tag, " = '", txtMainAccNo.Text.Trim(), "'");
            }
            if (!string.IsNullOrEmpty(txtCostCNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtCostCNo.Tag, " = '", txtCostCNo.Text.Trim(), "'");
            }
            if (!string.IsNullOrEmpty(txtUserNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtUserNo.Tag, " = '", txtUserNo.Text.Trim(), "'");
            }
            if (!string.IsNullOrEmpty(txtLegateNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtLegateNo.Tag, " = '", txtLegateNo.Text.Trim(), "'");
            }
            if (VarGeneral.CheckDate(txtMFromDate.Text) && txtMFromDate.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMFromDate.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_GDHEAD.gdGDate  >= '" + dateFormatter.FormatGreg(txtMFromDate.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_GDHEAD.gdHDate  >= '" + dateFormatter.FormatHijri(txtMFromDate.Text, "yyyy/MM/dd") + "'"));
            }
            if (VarGeneral.CheckDate(txtMToDate.Text) && txtMToDate.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMToDate.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_GDHEAD.gdGDate  <= '" + dateFormatter.FormatGreg(txtMToDate.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_GDHEAD.gdHDate  <= '" + dateFormatter.FormatHijri(txtMToDate.Text, "yyyy/MM/dd") + "'"));
            }
            if (!string.IsNullOrEmpty(txtRemark.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and (", txtRemark.Tag, " like '%", txtRemark.Text.Trim(), "%' or ", txtRemark.Tag, "E like '%", txtRemark.Text.Trim(), "%')");
            }
            return Rule;
        }
        private string BuildRuleList2()
        {
            HijriGregDates dateFormatter = new HijriGregDates();
            string Rule = "Where 1 = 1 and T_GDHEAD.gdLok = 0 ";
            if (txtMBalanceB.LockUpdateChecked)
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtMBalanceB.Tag, " >= ", txtMBalanceB.Value);
            }
            if (txtMBalanceS.LockUpdateChecked)
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtMBalanceS.Tag, " <= ", txtMBalanceS.Value);
            }
            if (!string.IsNullOrEmpty(txtMainAccNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtMainAccNo.Tag, " = '", txtMainAccNo.Text.Trim(), "'");
            }
            if (!string.IsNullOrEmpty(txtCostCNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtCostCNo.Tag, " = '", txtCostCNo.Text.Trim(), "'");
            }
            if (!string.IsNullOrEmpty(txtUserNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtUserNo.Tag, " = '", txtUserNo.Text.Trim(), "'");
            }
            if (!string.IsNullOrEmpty(txtLegateNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtLegateNo.Tag, " = '", txtLegateNo.Text.Trim(), "'");
            }
            if (VarGeneral.CheckDate(txtMFromDate.Text) && txtMFromDate.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMFromDate.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_GDHEAD.gdGDate  < '" + dateFormatter.FormatGreg(txtMFromDate.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_GDHEAD.gdHDate  < '" + dateFormatter.FormatHijri(txtMFromDate.Text, "yyyy/MM/dd") + "'"));
            }
            if (!string.IsNullOrEmpty(txtRemark.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and (", txtRemark.Tag, " like '%", txtRemark.Text.Trim(), "%' or ", txtRemark.Tag, "E like '%", txtRemark.Text.Trim(), "%')");
            }
            return Rule + " and c.AccNo = T_GDDET.AccNo ";
        }
        string getratec(string s, double to, double frm)
        {
            double de1 = frm * (double.Parse(s));
            if (de1 != 0)
            {
                de1 = (double)de1 / to;
            }
            return (de1).ToString();
        }
        T_Curency defaltcurr, To, Frm;
        private void ButOk_Click(object sender, EventArgs e)
        {
            if (txtMainAccNo.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "يجب تحديد رقم الحساب " : "must specify the account number ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtMainAccNo.Focus();
                return;
            }
            try
            {
                int ff = CmbCurr.SelectedIndex;
                CmbCurr.SelectedIndex = -1;
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_GDDET LEFT OUTER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID  LEFT OUTER JOIN T_Curency ON T_GDHEAD.CurTyp = T_Curency.Curency_ID  LEFT OUTER JOIN T_INVSETTING On T_GDHEAD.gdTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_SYSSETTING ON T_GDHEAD.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                string Fields = BuildFieldList() + ",T_GDHEAD.CurTyp as Currancy" + ", case when (select sum(CASE WHEN c.gdValue > 0 THEN " + ((CmbCurr.SelectedIndex > 0) ? (" case when T_GDHEAD.CurTyp != " + int.Parse(CmbCurr.SelectedValue.ToString()) + " then (Round((c.gdValue * (select Rate from T_Curency where T_Curency.Curency_ID = T_GDHEAD.CurTyp)) / " + db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value + "," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) else c.gdValue end ") : " c.gdValue ") + " ELSE 0 END) as DebitPervious from T_GDDET as c LEFT OUTER JOIN T_GDHEAD ON c.gdID = T_GDHEAD.gdhead_ID LEFT OUTER JOIN T_Curency ON T_GDHEAD.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_INVSETTING On T_GDHEAD.gdTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_SYSSETTING ON T_GDHEAD.CompanyID = T_SYSSETTING.SYSSETTING_ID " + BuildRuleList2() + ") != '' then (select sum(CASE WHEN c.gdValue > 0 THEN " + ((CmbCurr.SelectedIndex > 0) ? (" case when T_GDHEAD.CurTyp != " + int.Parse(CmbCurr.SelectedValue.ToString()) + " then (Round((c.gdValue * (select Rate from T_Curency where T_Curency.Curency_ID = T_GDHEAD.CurTyp)) / " + db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value + "," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) else c.gdValue end ") : " c.gdValue ") + " ELSE 0 END) as DebitPervious from T_GDDET as c LEFT OUTER JOIN T_GDHEAD ON c.gdID = T_GDHEAD.gdhead_ID LEFT OUTER JOIN T_Curency ON T_GDHEAD.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_INVSETTING On T_GDHEAD.gdTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_SYSSETTING ON T_GDHEAD.CompanyID = T_SYSSETTING.SYSSETTING_ID " + BuildRuleList2() + ") else '0' end as DebitPervious, case when (select sum(CASE WHEN c.gdValue < 0 THEN " + ((CmbCurr.SelectedIndex > 0) ? (" case when T_GDHEAD.CurTyp != " + int.Parse(CmbCurr.SelectedValue.ToString()) + " then (Round(Abs((c.gdValue * (select Rate from T_Curency where T_Curency.Curency_ID = T_GDHEAD.CurTyp))) / " + db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value + "," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) else Abs(c.gdValue) end ") : " Abs(c.gdValue) ") + "  ELSE 0 END) as CreditPervious from T_GDDET as c LEFT OUTER JOIN T_GDHEAD ON c.gdID = T_GDHEAD.gdhead_ID LEFT OUTER JOIN T_Curency ON T_GDHEAD.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_INVSETTING On T_GDHEAD.gdTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_SYSSETTING ON T_GDHEAD.CompanyID = T_SYSSETTING.SYSSETTING_ID " + BuildRuleList2() + ") != '' then (select sum(CASE WHEN c.gdValue < 0 THEN " + ((CmbCurr.SelectedIndex > 0) ? (" case when T_GDHEAD.CurTyp != " + int.Parse(CmbCurr.SelectedValue.ToString()) + " then (Round(Abs((c.gdValue * (select Rate from T_Curency where T_Curency.Curency_ID = T_GDHEAD.CurTyp))) / " + db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value + "," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) else Abs(c.gdValue) end ") : " Abs(c.gdValue) ") + "  ELSE 0 END) as CreditPervious from T_GDDET as c LEFT OUTER JOIN T_GDHEAD ON c.gdID = T_GDHEAD.gdhead_ID LEFT OUTER JOIN T_Curency ON T_GDHEAD.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_INVSETTING On T_GDHEAD.gdTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_SYSSETTING ON T_GDHEAD.CompanyID = T_SYSSETTING.SYSSETTING_ID " + BuildRuleList2() + ") else '0' end as CreditPervious, case when (select sum(" + ((CmbCurr.SelectedIndex > 0) ? (" case when T_GDHEAD.CurTyp != " + int.Parse(CmbCurr.SelectedValue.ToString()) + " then (Round((c.gdValue * (select Rate from T_Curency where T_Curency.Curency_ID = T_GDHEAD.CurTyp)) / " + db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value + "," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) else c.gdValue end ") : " c.gdValue ") + ") as BalancePervious from T_GDDET as c LEFT OUTER JOIN T_GDHEAD ON c.gdID = T_GDHEAD.gdhead_ID LEFT OUTER JOIN T_Curency ON T_GDHEAD.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_INVSETTING On T_GDHEAD.gdTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_SYSSETTING ON T_GDHEAD.CompanyID = T_SYSSETTING.SYSSETTING_ID " + BuildRuleList2() + ") != '' then (select sum(" + ((CmbCurr.SelectedIndex > 0) ? (" case when T_GDHEAD.CurTyp != " + int.Parse(CmbCurr.SelectedValue.ToString()) + " then (Round((c.gdValue * (select Rate from T_Curency where T_Curency.Curency_ID = T_GDHEAD.CurTyp)) / " + db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value + "," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) else c.gdValue end ") : " c.gdValue ") + ") as BalancePervious from T_GDDET as c LEFT OUTER JOIN T_GDHEAD ON c.gdID = T_GDHEAD.gdhead_ID LEFT OUTER JOIN T_Curency ON T_GDHEAD.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_INVSETTING On T_GDHEAD.gdTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_SYSSETTING ON T_GDHEAD.CompanyID = T_SYSSETTING.SYSSETTING_ID " + BuildRuleList2() + ") else '0' end as BalancePervious";
                _RepShow.Rule = BuildRuleList() + ((combobox_SortTyp.SelectedIndex == 0) ? " order by T_GDHEAD.gdGDate,T_GDHEAD.gdTyp, T_GDHEAD.gdNo" : ((combobox_SortTyp.SelectedIndex == 1) ? " order by T_GDHEAD.gdhead_ID" : " order by T_GDHEAD.gdTyp, T_GDHEAD.gdNo "));
                _RepShow.Fields = Fields;
                CmbCurr.SelectedIndex = ff;
                try
                {
                    _RepShow = _RepShow.Save();
                    if (CmbCurr.SelectedIndex > 0)
                        if (VarGeneral.InvType == 1)
                        {
                            DataTable t = _RepShow.RepData.Tables[0];
                            int parse = int.Parse(CmbCurr.SelectedValue.ToString());
                            To
                                = db.StockCurencyID(parse);
                            double rateTo = (double)To.Rate;
                            defaltcurr = db.StockCurencyID(1);
                            for (int i = 0; i < t.Rows.Count; i++)
                            {
                                Frm = db.StockCurencyID(int.Parse(t.Rows[i]["Currancy"].ToString()));
                                double rateFrom = (double)Frm.Rate;
                                //if (int.Parse(t.Rows[i]["Currancy"].ToString()) != parse)
                                //    {
                                t.Rows[i]["Debit"] = getratec(t.Rows[i]["Debit"].ToString(), rateTo, rateFrom);
                                t.Rows[i]["Credit"] = getratec(t.Rows[i]["Credit"].ToString(), rateTo, rateFrom);
                                t.Rows[i]["BalancePervious"] = getratec(t.Rows[i]["BalancePervious"].ToString(), rateTo, rateFrom);
                                t.Rows[i]["Balance"] = getratec(t.Rows[i]["Balance"].ToString(), rateTo, rateFrom);
                                t.Rows[i]["CreditPervious"] = getratec(t.Rows[i]["CreditPervious"].ToString(), rateTo, rateFrom);
                                t.Rows[i]["DebitPervious"] = getratec(t.Rows[i]["DebitPervious"].ToString(), rateTo, rateFrom);
                                //}                      
                            }
                            _RepShow.RepData.Tables.RemoveAt(0);
                            _RepShow.RepData.Tables.Add(t);
                        }
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
                        frm.Repvalue = "Account";
                        frm.Tag = LangArEn;
                        frm.Repvalue = "Account";
                        if (RButDet.Checked)
                        {
                            VarGeneral.itmDesIndex = 0;
                        }
                        else
                        {
                            VarGeneral.itmDesIndex = 1;
                        }
                        try
                        {
                            if (checkBox_OldBlance.Checked)
                            {
                                VarGeneral.itmDes = "OldBalance";
                            }
                            else
                            {
                                VarGeneral.itmDes = "";
                            }
                        }
                        catch
                        {
                            VarGeneral.itmDes = "";
                        }
                        VarGeneral.vTitle = Text;
                        if (VarGeneral.CheckDate(txtMFromDate.Text))
                        {
                            VarGeneral._DTFrom = txtMFromDate.Text;
                        }
                        else
                        {
                            VarGeneral._DTFrom = "";
                        }
                        if (VarGeneral.CheckDate(txtMToDate.Text))
                        {
                            VarGeneral._DTTo = txtMToDate.Text;
                        }
                        else
                        {
                            VarGeneral._DTTo = "";
                        }
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
                groupBox3.Text = "الرصيــــد";
                groupBox4.Text = "التاريــــخ";
                label1.Text = "مـــــن :";
                label2.Text = "إلـــــى :";
                label5.Text = "الحســـاب :";
                label6.Text = "المنـــــدوب :";
                label7.Text = "مركز التكلفة :";
                label8.Text = "المستخـــدم :";
                checkBox_OldBlance.Text = "إظهار الرصيد السابق";
                checkBox_BalanceMove.Text = "تحريك الرصيد";
                checkBox_OldBCalcaluat.Text = "إحتساب الرصيد السابق";
            }
            else
            {
                ButExit.Text = "Exit Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "Print F5" : "Show F5");
                groupBox3.Text = "Balance";
                groupBox4.Text = "Date";
                label1.Text = "From :";
                label2.Text = "To :";
                label5.Text = "Account No :";
                label6.Text = "Delegate :";
                label7.Text = "Cost Center :";
                label8.Text = "User :";
                checkBox_OldBlance.Text = "Show previous balance";
                checkBox_BalanceMove.Text = "Move the balance";
                checkBox_OldBCalcaluat.Text = "Calculating the previous balance";
            }
        }
        private void FRAccount_Load(object sender, EventArgs e)
        {
        }
        public void FillCombo()
        {
            combobox_SortTyp.Items.Clear();
            combobox_SortTyp.Items.Add((LangArEn == 0) ? "تاريخ القيد" : "Date");
            combobox_SortTyp.Items.Add((LangArEn == 0) ? "تسلسل القيد" : "Sequence");
            combobox_SortTyp.Items.Add((LangArEn == 0) ? "رقــم القيد" : "No Bound");
            combobox_SortTyp.SelectedIndex = 0;
            List<T_Curency> listCurr = new List<T_Curency>(db.T_Curencies.Select((T_Curency item) => item).ToList());
            listCurr.Insert(0, new T_Curency());
            listCurr[0].Arb_Des = ((LangArEn == 0) ? "--- الإفتراضـــي ---" : "--- Default ---");
            listCurr[0].Eng_Des = ((LangArEn == 0) ? "--- الإفتراضـــي ---" : "--- Default ---");
            CmbCurr.DataSource = listCurr;
            CmbCurr.DisplayMember = ((LangArEn == 0) ? "Arb_Des" : "Eng_Des");
            CmbCurr.ValueMember = "Curency_ID";
            CmbCurr.SelectedIndex = 0;
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
            if (VarGeneral.CheckDate(txtMFromDate.Text) && txtMFromDate.Text.Length == 10)
            {
                checkBox_OldBlance.Enabled = true;
                return;
            }
            checkBox_OldBlance.Checked = false;
            checkBox_OldBlance.Enabled = false;
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
            if (VarGeneral.SSSTyp == 0)
            {
                VarGeneral.StockOnly = true;
                VarGeneral.InvTyp = 555;
            }
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
                txtMainAccNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtMainAccName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    txtMainAccName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
            }
            else
            {
                txtMainAccNo.Text = "";
                txtMainAccName.Text = "";
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
            if (frm.SerachNo != "")
            {
                txtLegateNo.Text = db.StockMndob(frm.Serach_No).Mnd_ID.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtLegateName.Text = db.StockMndob(frm.Serach_No).Arb_Des.ToString();
                }
                else
                {
                    txtLegateName.Text = db.StockMndob(frm.Serach_No).Eng_Des.ToString();
                }
            }
            else
            {
                txtLegateNo.Text = "";
                txtLegateName.Text = "";
            }
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
            if (frm.SerachNo != "")
            {
                txtUserNo.Text = dbc.StockUser(frm.Serach_No).UsrNo;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
                txtUserNo.Text = "";
                txtUserName.Text = "";
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
        private void ribbonBar1_ItemClick(object sender, EventArgs e)
        {
        }
        private void RButDet_CheckedChanged(object sender, EventArgs e)
        {
            if (RButDet.Checked)
            {
                checkBox_OldBlance.Enabled = true;
                checkBox_BalanceMove.Enabled = true;
                return;
            }
            checkBox_OldBlance.Checked = false;
            checkBox_OldBlance.Enabled = false;
            checkBox_BalanceMove.Checked = false;
            checkBox_BalanceMove.Enabled = false;
        }
        private void checkBox_OldBlance_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_OldBlance.Checked)
            {
                checkBox_OldBCalcaluat.Visible = true;
            }
            else
            {
                checkBox_OldBCalcaluat.Visible = false;
            }
            checkBox_OldBCalcaluat.Checked = false;
        }
        private void checkBox_BalanceMove_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox_BalanceMove.Checked)
            {
                checkBox_OldBCalcaluat.Checked = false;
            }
        }
        private void txtRemark_Click(object sender, EventArgs e)
        {
            txtRemark.SelectAll();
        }
        private void txtRemark_ButtonCustomClick(object sender, EventArgs e)
        {
            txtRemark.Text = "";
        }
        private void checkBox_OldBCalcaluat_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_OldBCalcaluat.Checked)
            {
                checkBox_BalanceMove.Checked = true;
            }
        }
        private void ButOk_MouseMove(object sender, MouseEventArgs e)
        {
            ButOk.BackgroundImage = Properties.Resources.howver;
            ButOk.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void ButOk_MouseLeave(object sender, EventArgs e)
        {
            ButOk.BackgroundImage = Properties.Resources.print;
            ButOk.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void FRAccount_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            WindowState = FormWindowState.Maximized;
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
    }
}
