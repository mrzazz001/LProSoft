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
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FRStatementOfAccount : Form
    { void avs(int arln)

{ 
 label9.Text=   (arln == 0 ? "  العملـــــــــــة :  " : "  work:") ; ButExit.Text=   (arln == 0 ? "  خـــروج  " : "  Close") ; ButOk.Text=   (arln == 0 ? "  طبـــاعة  " : "  print") ; label25.Text=   (arln == 0 ? "  الى حساب :  " : "  to account :") ; label26.Text=   (arln == 0 ? "  من حساب :  " : "  from account :") ; label27.Text=   (arln == 0 ? "  مركز التكلفة :  " : "  cost center:") ; groupBox4.Text=   (arln == 0 ? "  حسب التاريخ  " : "  by date") ; label15.Text=   (arln == 0 ? "  مـــــن :  " : "  from:") ; label16.Text=   (arln == 0 ? "  إلـــــى :  " : "  to:") ;}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
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
        private int LangArEn = 0;
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
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
                        frm.Repvalue = "StatmentOfAccount";
                        frm.Repvalue = "StatmentOfAccount";
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
        private TextBox txtIntoAccName;
        private TextBox txtFromAccName;
        private TextBox txtCostCName;
        private TextBox txtFromAccNo;
        private TextBox txtIntoAccNo;
        private TextBox txtCostCNo;
        private ButtonX ButExit;
        private ButtonX ButOk;
        private Label label25;
        private Label label26;
        private Label label27;
        private ButtonX button_SrchCostNo;
        private ButtonX button_SrchAccTo;
        private ButtonX button_SrchAccFrom;
        private GroupBox groupBox4;
        private MaskedTextBox txtMToDate;
        private MaskedTextBox txtMFromDate;
        private Label label15;
        private Label label16;
        private Label label9;
        private ComboBoxEx CmbCurr;
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
        public FRStatementOfAccount(string AccNo, string AccName)
        {
            InitializeComponent();this.Load += langloads;
            txtFromAccNo.Text = AccNo;
            txtIntoAccName.Text = AccName;
            txtFromAccName.Text = AccName;
            txtIntoAccNo.Text = AccNo;
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
                label27.Visible = false;
                txtCostCNo.Visible = false;
                button_SrchCostNo.Visible = false;
                txtCostCName.Visible = false;
            }
            else
            {
                label27.Visible = true;
                txtCostCNo.Visible = true;
                button_SrchCostNo.Visible = true;
                txtCostCName.Visible = true;
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
                    label27.Visible = true;
                    txtCostCNo.Visible = true;
                    button_SrchCostNo.Visible = true;
                    txtCostCName.Visible = true;
                }
                else
                {
                    label27.Visible = false;
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRStatementOfAccount));
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
            FillCombo();
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptBus.dll"))
            {
                label27.Text = ((LangArEn == 0) ? "الباص :" : "Bus :");
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptWaterPackages.dll"))
            {
                label27.Text = ((LangArEn == 0) ? "السيــارة :" : "Car :");
            }
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRStatementOfAccount));
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
            FillCombo();
        }
        public void FillCombo()
        {
            List<T_Curency> listCurr = new List<T_Curency>(db.T_Curencies.Select((T_Curency item) => item).ToList());
            listCurr.Insert(0, new T_Curency());
            listCurr[0].Arb_Des = ((LangArEn == 0) ? "--- الإفتراضـــي ---" : "--- Default ---");
            listCurr[0].Eng_Des = ((LangArEn == 0) ? "--- الإفتراضـــي ---" : "--- Default ---");
            CmbCurr.DataSource = listCurr;
            CmbCurr.DisplayMember = ((LangArEn == 0) ? "Arb_Des" : "Eng_Des");
            CmbCurr.ValueMember = "Curency_ID";
            CmbCurr.SelectedIndex = 0;
        }
        private string BuildRuleList()
        {
            HijriGregDates dateFormatter = new HijriGregDates();
            string Rule = " Where 1 = 1 and T_GDHEAD.gdLok = 0  and T_AccDef.Lev = 4 ";
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
            if (VarGeneral.CheckDate(txtMFromDate.Text) && txtMFromDate.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMFromDate.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_GDHEAD.gdGDate  >= '" + dateFormatter.FormatGreg(txtMFromDate.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_GDHEAD.gdHDate  >= '" + dateFormatter.FormatHijri(txtMFromDate.Text, "yyyy/MM/dd") + "'"));
            }
            if (VarGeneral.CheckDate(txtMToDate.Text) && txtMToDate.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMToDate.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_GDHEAD.gdGDate  <= '" + dateFormatter.FormatGreg(txtMToDate.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_GDHEAD.gdHDate  <= '" + dateFormatter.FormatHijri(txtMToDate.Text, "yyyy/MM/dd") + "'"));
            }
            return Rule + " Order by T_AccDef.AccDef_No , T_GDHEAD.gdGDate , T_GDDET.gdID ";
        }
        private string BuildRuleList2()
        {
            HijriGregDates dateFormatter = new HijriGregDates();
            string Rule = " Where 1 = 1 and T_GDHEAD.gdLok = 0  and T_AccDef.Lev = 4 ";
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
            if (VarGeneral.CheckDate(txtMFromDate.Text) && txtMFromDate.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMFromDate.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_GDHEAD.gdGDate  < '" + dateFormatter.FormatGreg(txtMFromDate.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_GDHEAD.gdHDate  < '" + dateFormatter.FormatHijri(txtMFromDate.Text, "yyyy/MM/dd") + "'"));
            }
            return Rule + " Group by T_AccDef.AccDef_No , T_AccDef.Eng_Des , T_AccDef.Arb_Des ";
        }
        private void ButExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            try
            {
                RepShow _RepShow = new RepShow();
                string Tables = " T_GDDET LEFT OUTER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID  LEFT OUTER JOIN T_Curency ON T_GDHEAD.CurTyp = T_Curency.Curency_ID  LEFT OUTER JOIN T_INVSETTING On T_GDHEAD.gdTyp = T_INVSETTING.InvID   LEFT OUTER JOIN T_AccDef on T_GDDET.AccNo = T_AccDef.AccDef_No  LEFT OUTER JOIN T_CstTbl on T_GDHEAD.gdCstNo = T_CstTbl.Cst_ID Left OUTER JOIN T_SYSSETTING ON T_GDHEAD.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                string Fields = "";
                Fields = ((LangArEn != 0) ? (" T_AccDef.AccDef_No , T_AccDef.Eng_Des  as AccDefNm , T_INVSETTING.InvNamE as InvNm  , T_INVSETTING.InvNamE , T_CstTbl.Eng_Des as CostCenteNm , T_GDHEAD.gdNo ,  T_GDHEAD.gdHDate , T_GDHEAD.gdGDate , T_GDDET.gdDesE as gdDes , T_GDDET.gdDes,CASE WHEN T_GDDET.gdValue > 0 THEN " + ((CmbCurr.SelectedIndex > 0) ? (" case when T_GDHEAD.CurTyp != " + int.Parse(CmbCurr.SelectedValue.ToString()) + " then (Round((T_GDDET.gdValue * (select Rate from T_Curency where T_Curency.Curency_ID = T_GDHEAD.CurTyp)) / " + db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value + "," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) else T_GDDET.gdValue end ") : " T_GDDET.gdValue ") + " ELSE 0 END as Debit,  CASE WHEN T_GDDET.gdValue < 0 THEN " + ((CmbCurr.SelectedIndex > 0) ? (" case when T_GDHEAD.CurTyp != " + int.Parse(CmbCurr.SelectedValue.ToString()) + " then (Round(Abs((T_GDDET.gdValue * (select Rate from T_Curency where T_Curency.Curency_ID = T_GDHEAD.CurTyp))) / " + db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value + "," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) else Abs(T_GDDET.gdValue) end ") : " Abs(T_GDDET.gdValue) ") + "  ELSE 0 END as Credit ,T_SYSSETTING.LogImg ") : (" T_AccDef.AccDef_No , T_AccDef.Arb_Des as AccDefNm, T_INVSETTING.InvNamA as InvNm  , T_INVSETTING.InvNamE , T_CstTbl.Arb_Des as CostCenteNm , T_GDHEAD.gdNo ,  T_GDHEAD.gdHDate , T_GDHEAD.gdGDate , T_GDDET.gdDes , T_GDDET.gdDes,CASE WHEN T_GDDET.gdValue > 0 THEN " + ((CmbCurr.SelectedIndex > 0) ? (" case when T_GDHEAD.CurTyp != " + int.Parse(CmbCurr.SelectedValue.ToString()) + " then (Round((T_GDDET.gdValue * (select Rate from T_Curency where T_Curency.Curency_ID = T_GDHEAD.CurTyp)) / " + db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value + "," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) else T_GDDET.gdValue end ") : " T_GDDET.gdValue ") + " ELSE 0 END as Debit,  CASE WHEN T_GDDET.gdValue < 0 THEN " + ((CmbCurr.SelectedIndex > 0) ? (" case when T_GDHEAD.CurTyp != " + int.Parse(CmbCurr.SelectedValue.ToString()) + " then (Round(Abs((T_GDDET.gdValue * (select Rate from T_Curency where T_Curency.Curency_ID = T_GDHEAD.CurTyp))) / " + db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value + "," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) else Abs(T_GDDET.gdValue) end ") : " Abs(T_GDDET.gdValue) ") + "  ELSE 0 END as Credit ,T_SYSSETTING.LogImg "));
                _RepShow.Rule = BuildRuleList();
                if (!string.IsNullOrEmpty(Fields))
                {
                    _RepShow.Fields = Fields;
                    _RepShow.Tables = Tables;
                    try
                    {
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        if (VarGeneral.CheckDate(txtMFromDate.Text) && txtMFromDate.Text.Length == 10)
                        {
                            _RepShow = new RepShow();
                            _RepShow.Rule = BuildRuleList2();
                            _RepShow.Tables = Tables;
                            _RepShow.Fields = " T_AccDef.AccDef_No , T_AccDef.Eng_Des , T_AccDef.Arb_Des , '' as [InvNamA]  , '' as [InvNamE] , '' as [CstArb_Des] , '' as [CstEng_Des] , '0' as [gdNo] ,  '' as [gdHDate] , '' as [gdGDate] , 'رصيد سابق' as [gdDes], CASE WHEN Sum(T_GDDET.gdValue) < 0 THEN Sum(ABS(T_GDDET.gdValue)) Else 0 END AS [Debit] , CASE WHEN Sum(T_GDDET.gdValue) > 0 THEN Sum(T_GDDET.gdValue) Else 0 END AS [Credit] ";
                            _RepShow = _RepShow.Save();
                            _RepShow.RepData.Tables[0].Merge(VarGeneral.RepData.Tables[0]);
                            VarGeneral.RepData = _RepShow.RepData;
                        }
                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show(ex2.Message);
                    }
                    if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "عفوا .. لا يوجد بيانات لعرضها في التقرير " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    try
                    {
                        VarGeneral.IsGeneralUsed = true;
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "StatmentOfAccount";
                        frm.Tag = LangArEn;
                        frm.Repvalue = "StatmentOfAccount";
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
                else
                {
                    MessageBox.Show((LangArEn == 0) ? " يجب تحديد حقل واحد على الأقل للتقرير" : "You must select one field or more", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
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
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtFromAccNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
                txtFromAccNo.Text = "";
                txtFromAccName.Text = "";
            }
        }
        private void button_SrchAccTo_Click(object sender, EventArgs e)
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
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtIntoAccNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
                txtIntoAccNo.Text = "";
                txtIntoAccName.Text = "";
            }
        }
        private void button_SrchCostNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("Cst_No", new ColumnDictinary("مركز التكلفة", "Cost Center No", ifDefault: true, ""));
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
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ButExit.Text = "خــــروج Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.ISdirectPrinting) ? "طبـــاعة F5" : "عــــرض F5");
                groupBox4.Text = "التاريــــخ";
                label15.Text = "مـــــن :";
                label16.Text = "إلـــــى :";
                label26.Text = "من حساب :";
                label25.Text = "إلى حساب :";
                label27.Text = "مركز التكلفة :";
                Text = "كشف بأكثر من حساب";
            }
            else
            {
                ButExit.Text = "Exit Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.ISdirectPrinting) ? "Print F5" : "Show F5");
                groupBox4.Text = "Date";
                label15.Text = "From :";
                label16.Text = "To :";
                label26.Text = "Account From :";
                label25.Text = "Account To :";
                label27.Text = "Cost Center :";
                Text = "Report more than one account";
            }
        }
        private void FRStatementOfAccount_Load(object sender, EventArgs e)
        {
        }
        private void FRStatementOfAccount_KeyDown(object sender, KeyEventArgs e)
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
        private void FRStatementOfAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
    }
}
