using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using Framework.Date;
using Framework.UI;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using Library.RepShow;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FRAccountReportGabthSerf : Form
    { void avs(int arln)

{ 
  label10.Text=   (arln == 0 ? "  الطــريقــــــة :  " : "  The way:") ; groupBox4.Text=   (arln == 0 ? "  حسب التاريخ  " : "  by date") ; label1.Text=   (arln == 0 ? "  مـــــن :  " : "  from:") ; label2.Text=   (arln == 0 ? "  إلـــــى :  " : "  to:") ; label9.Text=   (arln == 0 ? "  المستخـــدم :  " : "  User:") ; label7.Text=   (arln == 0 ? "  المنـــــدوب :  " : "  The delegate:") ; label6.Text=   (arln == 0 ? "  الى حساب :  " : "  to account :") ; label5.Text=   (arln == 0 ? "  من حساب :  " : "  from account :") ; groupBox3.Text=   (arln == 0 ? "  الرصيــــد  " : "  balance") ; label3.Text=   (arln == 0 ? "  مـــــن :  " : "  from:") ; label4.Text=   (arln == 0 ? "  أصغر من " : "  Younger than") ; label8.Text=   (arln == 0 ? "  مركز التكلفة :  " : "  cost center:") ;}
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
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
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
                        frm.Repvalue = "AccountSerfGabth";
                        frm.Repvalue = "AccountSerfGabth";
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
        private TextBox txtFromAccNo;
        private RibbonBar ribbonBar1;
        private TextBox txtIntoAccName;
        private TextBox txtLegateName;
        private TextBox txtFromAccName;
        private TextBox txtUserName;
        private TextBox txtCostCName;
        private TextBox txtIntoAccNo;
        private TextBox txtLegateNo;
        private TextBox txtUserNo;
        private TextBox txtCostCNo;
        private Label label9;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label8;
        private ButtonX button_SrchUsrNo;
        private ButtonX button_SrchCostNo;
        private ButtonX button_SrchLegNo;
        private ButtonX button_SrchAccTo;
        private ButtonX button_SrchAccFrom;
        private GroupBox groupBox4;
        private MaskedTextBox txtMToDate;
        private MaskedTextBox txtMFromDate;
        private Label label1;
        private Label label2;
        private GroupBox groupBox3;
        private C1FlexGrid FlexField;
        private Label label10;
        private ComboBoxEx CmbTyp;
        private DoubleInput txtMBalanceB;
        private DoubleInput txtMBalanceS;
        private Label label3;
        private C1.Win.C1Input.C1Button ButOk;
        private C1.Win.C1Input.C1Button ButExit;
        private Label label4;
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
        public FRAccountReportGabthSerf()
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
                label8.Visible = false;
                txtCostCNo.Visible = false;
                button_SrchCostNo.Visible = false;
                txtCostCName.Visible = false;
            }
            else
            {
                label8.Visible = true;
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
                        label8.Visible = true;
                        txtCostCNo.Visible = true;
                        button_SrchCostNo.Visible = true;
                        txtCostCName.Visible = true;
                    }
                    else
                    {
                        label8.Visible = false;
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRAccountReportGabthSerf));
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
            RepDef();
            FillCombo();
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
                label7.Text = ((LangArEn == 0) ? "العميــــــــل :" : "Customer :");
                label8.Text = ((LangArEn == 0) ? "السيــارة :" : "Car :");
            }
             avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRAccountReportGabthSerf));
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
            FillFlex();
            RepDef();
            FillCombo();
        }
        private void RepDef()
        {
            for (int iiCnt = 1; iiCnt < FlexField.Rows.Count; iiCnt++)
            {
                FlexField.SetData(iiCnt, 0, 1);
            }
        }
        private void FillFlex()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                FlexField.Rows.Count = 10;
                FlexField.SetData(0, 0, "أظهار");
                FlexField.SetData(0, 1, "أسم الحقل");
                FlexField.SetData(1, 1, "[رقم الحساب]");
                FlexField.SetData(1, 2, " T_AccDef.AccDef_No ");
                FlexField.SetData(2, 1, "[أسم الحساب]");
                FlexField.SetData(2, 2, " T_AccDef.Arb_Des as AccDefNm ");
                FlexField.SetData(3, 1, "[رقم السند]");
                FlexField.SetData(3, 2, " T_GDHEAD.gdNo ");
                FlexField.SetData(4, 1, "[نوع السند]");
                FlexField.SetData(4, 2, " T_INVSETTING.InvNamA as InvNm");
                FlexField.SetData(5, 1, "[التاريخ الهجري]");
                FlexField.SetData(5, 2, " T_GDHEAD.gdHDate ");
                FlexField.SetData(6, 1, "[التاريخ الميلادي]");
                FlexField.SetData(6, 2, " T_GDHEAD.gdGDate ");
                FlexField.SetData(7, 1, "[وصف السند]");
                FlexField.SetData(7, 2, " T_GDDET.gdDes ");
                FlexField.SetData(8, 1, "[حركة مدينة]");
                FlexField.SetData(8, 2, " CASE WHEN T_GDDET.gdValue > 0 THEN T_GDDET.gdValue ELSE 0 END as Debit ");
                FlexField.SetData(9, 1, "[حركة دائنة]");
                FlexField.SetData(9, 2, " CASE WHEN T_GDDET.gdValue < 0 THEN Abs(T_GDDET.gdValue) ELSE 0 END as Credit ");
            }
            else
            {
                FlexField.Rows.Count = 10;
                FlexField.SetData(0, 0, "Showing");
                FlexField.SetData(0, 1, "Filed Name");
                FlexField.SetData(1, 1, "[Account No]");
                FlexField.SetData(1, 2, " T_AccDef.AccDef_No ");
                FlexField.SetData(2, 1, "[Account Name]");
                FlexField.SetData(2, 2, " T_AccDef.Eng_Des as AccDefNm ");
                FlexField.SetData(3, 1, "[Document No]");
                FlexField.SetData(3, 2, " T_GDHEAD.gdNo ");
                FlexField.SetData(4, 1, "[Document Type]");
                FlexField.SetData(4, 2, " T_INVSETTING.InvNamE as InvNm ");
                FlexField.SetData(5, 1, "[Al-Hijri Date]");
                FlexField.SetData(5, 2, " T_GDHEAD.gdHDate ");
                FlexField.SetData(6, 1, "[Greg Date]");
                FlexField.SetData(6, 2, " T_GDHEAD.gdGDate ");
                FlexField.SetData(7, 1, "[Document Desc]");
                FlexField.SetData(7, 2, " T_GDDET.gdDesE as gdDes ");
                FlexField.SetData(8, 1, "[Debit Trans]");
                FlexField.SetData(8, 2, " CASE WHEN T_GDDET.gdValue > 0 THEN T_GDDET.gdValue ELSE 0 END as Debit ");
                FlexField.SetData(9, 1, "[Credit Trans]");
                FlexField.SetData(9, 2, " CASE WHEN T_GDDET.gdValue < 0 THEN Abs(T_GDDET.gdValue) ELSE 0 END as Credit ");
            }
            CmbTyp_SelectedIndexChanged(null, null);
            RibunButtons();
        }
        private string BuildFieldList()
        {
            string Fields = string.Empty;
            for (int iiCnt = 1; iiCnt < FlexField.Rows.Count; iiCnt++)
            {
                if (VarGeneral.TString.TEmptyBool(FlexField.GetData(iiCnt, 0)) && FlexField.Rows[iiCnt].Visible)
                {
                    if (!string.IsNullOrEmpty(Fields))
                    {
                        Fields += ",";
                    }
                    Fields += FlexField.GetData(iiCnt, 2).ToString();
                }
            }
            return Fields + " ,T_SYSSETTING.LogImg," + ((LangArEn == 0) ? " T_Curency.Arb_Des as CurrnceyNm " : "T_Curency.Eng_Des as CurrnceyNm ");
        }
        private string BuildRuleList(string tp)
        {
            HijriGregDates dateFormatter = new HijriGregDates();
            string Rule = "Where 1 = 1 and T_GDHEAD.gdLok = 0 " + FlexField.Tag;
            Rule = ((!(tp == "serf")) ? (Rule + " and T_GDHEAD.gdTyp = 12 and T_GDDET.gdValue < 0 ") : (Rule + " and T_GDHEAD.gdTyp = 13 and T_GDDET.gdValue > 0 "));
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
            if (!string.IsNullOrEmpty(txtFromAccNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtFromAccNo.Tag, " >= '", txtFromAccNo.Text.Trim(), "'");
            }
            if (!string.IsNullOrEmpty(txtIntoAccNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtIntoAccNo.Tag, " <= '", txtIntoAccNo.Text.Trim(), "'");
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
            return Rule;
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            try
            {
                RepShow _RepShow = new RepShow();
                double debit = 0.0;
                double credit = 0.0;
                _RepShow.Tables = " T_GDDET LEFT OUTER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID  LEFT OUTER JOIN T_Curency ON T_GDHEAD.CurTyp = T_Curency.Curency_ID  LEFT OUTER JOIN T_INVSETTING On T_GDHEAD.gdTyp = T_INVSETTING.InvID   LEFT OUTER JOIN T_AccDef on T_GDDET.AccNo = T_AccDef.AccDef_No LEFT OUTER JOIN T_SYSSETTING ON T_GDHEAD.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                string Fields = "SUM( abs(T_GDDET.gdValue) )as Debit";
                _RepShow.Rule = BuildRuleList("serf");
                _RepShow.Fields = Fields;
                try
                {
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                }
                catch (Exception ex4)
                {
                    MessageBox.Show(ex4.Message);
                }
                if (VarGeneral.RepData.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        debit = double.Parse(VarGeneral.RepData.Tables[0].Rows[0]["Debit"].ToString());
                    }
                    catch
                    {
                    }
                }
                _RepShow = new RepShow();
                _RepShow.Tables = " T_GDDET LEFT OUTER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID  LEFT OUTER JOIN T_Curency ON T_GDHEAD.CurTyp = T_Curency.Curency_ID  LEFT OUTER JOIN T_INVSETTING On T_GDHEAD.gdTyp = T_INVSETTING.InvID   LEFT OUTER JOIN T_AccDef on T_GDDET.AccNo = T_AccDef.AccDef_No LEFT OUTER JOIN T_SYSSETTING ON T_GDHEAD.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                Fields = "SUM( abs(T_GDDET.gdValue) )as Credit";
                _RepShow.Rule = BuildRuleList("Gabth");
                _RepShow.Fields = Fields;
                try
                {
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                }
                catch (Exception ex4)
                {
                    MessageBox.Show(ex4.Message);
                }
                if (VarGeneral.RepData.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        credit = double.Parse(VarGeneral.RepData.Tables[0].Rows[0]["Credit"].ToString());
                    }
                    catch
                    {
                    }
                }
                _RepShow = new RepShow();
                _RepShow.Tables = " T_GDDET LEFT OUTER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID  LEFT OUTER JOIN T_Curency ON T_GDHEAD.CurTyp = T_Curency.Curency_ID  LEFT OUTER JOIN T_INVSETTING On T_GDHEAD.gdTyp = T_INVSETTING.InvID   LEFT OUTER JOIN T_AccDef on T_GDDET.AccNo = T_AccDef.AccDef_No LEFT OUTER JOIN T_SYSSETTING ON T_GDHEAD.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                Fields = (_RepShow.Fields = debit + " as Debit, " + credit + " as Credit," + ((CmbTyp.SelectedIndex == 0) ? (credit - debit) : (debit - credit)) + " as Balance");
                try
                {
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                }
                catch (Exception ex4)
                {
                    MessageBox.Show(ex4.Message);
                }
                if (VarGeneral.RepData.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        VarGeneral.IsGeneralUsed = true;
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "AccountSerfGabth";
                        frm.Tag = LangArEn;
                        frm.Repvalue = "AccountSerfGabth";
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
            catch (Exception ex4)
            {
                MessageBox.Show(ex4.Message);
            }
        }
        private void ButExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ButSaveByDef_Click(object sender, EventArgs e)
        {
            try
            {
                string StrPR = string.Empty;
                for (int iiCnt = 1; iiCnt < FlexField.Rows.Count; iiCnt++)
                {
                    StrPR += VarGeneral.TString.ChkStatSave(VarGeneral.TString.TEmptyBool(FlexField.GetData(iiCnt, 0)));
                }
                _User.RepAcc2 = StrPR;
                dbc.Log = VarGeneral.DebugLog;
                dbc.SubmitChanges(ConflictMode.ContinueOnConflict);
                MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch
            {
            }
        }
        private void button_SrchAccTo_Click(object sender, EventArgs e)
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
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                txtIntoAccNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    txtIntoAccName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    txtIntoAccName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
            }
            else
            {
                txtIntoAccNo.Text = string.Empty;
                txtIntoAccName.Text = string.Empty;
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
                txtCostCNo.Text = db.StockCst(frm.Serach_No).Cst_ID.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
                txtCostCNo.Text = string.Empty;
                txtCostCName.Text = string.Empty;
            }
        }
        private void button_SrchAccFrom_Click(object sender, EventArgs e)
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
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                txtFromAccNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    txtFromAccName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    txtFromAccName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
            }
            else
            {
                txtFromAccNo.Text = string.Empty;
                txtFromAccName.Text = string.Empty;
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
                txtLegateNo.Text = db.StockMndob(frm.Serach_No).Mnd_ID.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
                txtLegateNo.Text = string.Empty;
                txtLegateName.Text = string.Empty;
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
                groupBox3.Text = "الرصيــــد";
                groupBox4.Text = "التاريــــخ";
                label1.Text = "مـــــن :";
                label2.Text = "إلـــــى :";
                label5.Text = "من حساب :";
                label6.Text = "الى حساب :";
                label7.Text = "المنـــــدوب :";
                label8.Text = "مركز التكلفة :";
                label9.Text = "المستخـــدم :";
            }
            else
            {
                ButExit.Text = "Exit Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.ISdirectPrinting) ? "Print F5" : "Show F5");
                groupBox3.Text = "Balance";
                groupBox4.Text = "Date";
                label1.Text = "From :";
                label2.Text = "To :";
                label5.Text = "Account From :";
                label6.Text = "Account To :";
                label7.Text = "Delegate :";
                label8.Text = "Cost Center :";
                label9.Text = "User :";
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
        private void FillCombo()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                CmbTyp.Items.Add("إجمالي سندات القبض -  إجمالي سندات الصرف");
                CmbTyp.Items.Add("إجمالي سندات الصرف -  إجمالي سندات القبض");
            }
            else
            {
                CmbTyp.Items.Add("Total receivable bonds - total exchange bonds");
                CmbTyp.Items.Add("Total exchange bonds - total receivable bonds");
            }
            CmbTyp.SelectedIndex = 0;
        }
        private void FRAccountReportGabthSerf_Load(object sender, EventArgs e)
        {
        }
        private void CmbTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Text = CmbTyp.Text;
            }
            catch
            {
            }
        }
    }
}
