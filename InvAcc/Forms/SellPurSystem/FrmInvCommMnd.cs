using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Framework.Date;
using Framework.UI;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using Library.RepShow;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmInvCommMnd : Form
    { void avs(int arln)

{ 
 label9.Text=   (arln == 0 ? "  المستخـــدم :  " : "  User:") ; label7.Text=   (arln == 0 ? "  المنـــــــدوب :  " : "  Delegate:") ; label6.Text=   (arln == 0 ? "  المــــــــــورد :  " : "  Supplier:") ; label5.Text=   (arln == 0 ? "  العميـــــــــل :  " : "  Customer:") ; groupBox3.Text=   (arln == 0 ? "  حسب رقم الفاتورة  " : "  According to the invoice number") ; label1.Text=   (arln == 0 ? "  مـــــن :  " : "  from:") ; label2.Text=   (arln == 0 ? "  إلـــــى :  " : "  to:") ; groupBox_Date.Text=   (arln == 0 ? "  حسب تاريخ الفاتورة  " : "  According to the invoice date") ; label3.Text=   (arln == 0 ? "  مـــــن :  " : "  from:") ; label4.Text=   (arln == 0 ? "  إلـــــى :  " : "  to:") ; label22.Text=   (arln == 0 ? "  طريقة الدفــــع  " : "  Payment method") ; label8.Text=   (arln == 0 ? "  مركز التكلفة :  " : "  cost center:") ; radioButton_Del1.Text=   (arln == 0 ? "  الكـــل  " : "  the whole") ; radioButton_Del2.Text=   (arln == 0 ? "  المحذوفة فقط  " : "  only deleted") ; radioButton_Del0.Text=   (arln == 0 ? "  الغير محذوفة  " : "  not deleted") ; radioButton__0650Return1.Text=   (arln == 0 ? "  الكـــل  " : "  the whole") ; radioButton__0650Return2.Text=   (arln == 0 ? "  المرتجعة فقط  " : "  Returns only") ; radioButton__0650Return0.Text=   (arln == 0 ? "  الغير مرتجعة  " : "  non-refundable") ; ButExit.Text=   (arln == 0 ? "  خـــروج  " : "  Close") ; ButOk.Text=   (arln == 0 ? "  طبـــاعة  " : "  print") ;}
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
                        frm.Repvalue = "InvoicesComm";
                        frm.Repvalue = "InvoicesComm";
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
        private GroupBox CmbReturn;
        private RadioButton radioButton__0650Return1;
        private RadioButton radioButton__0650Return2;
        private RadioButton radioButton__0650Return0;
        private GroupBox CmbDeleted;
        private RadioButton radioButton_Del1;
        private RadioButton radioButton_Del2;
        private RadioButton radioButton_Del0;
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
        private TextBox txtUserName;
        private TextBox txtUserNo;
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
        private Label label22;
        private C1FlexGrid FlexType;
        private SwitchButton RButTyp;
        private int LangArEn = 0;
        private T_User _User = new T_User();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private ControlContainerItem controlContainerItem1;
        private int vType = 0;
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
        public FrmInvCommMnd(int vTp)
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
            vType = vTp;
        }
        protected override void OnLoad(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmInvCommMnd));
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
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmInvCommMnd));
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
                this.FlexType.Rows.Count = 3;
                this.FlexType.SetData(0, 0, true);
                this.FlexType.SetData(0, 1, "نقدي");
                this.FlexType.SetData(1, 0, true);
                this.FlexType.SetData(1, 1, "آجل");
                this.FlexType.SetData(2, 0, true);
                this.FlexType.SetData(2, 1, "الشبكة");
            }
            else
            {
                FlexType.Rows.Count = 3;
                FlexType.SetData(0, 0, true);
                FlexType.SetData(0, 1, "Cash");
                FlexType.SetData(1, 0, true);
                FlexType.SetData(1, 1, "Credit");
                this.FlexType.SetData(2, 0, true);
                this.FlexType.SetData(2, 1, "Network");
            }
            RibunButtons();
        }
        private string BuildRuleList()
        {
            HijriGregDates dateFormatter = new HijriGregDates();
            string Rule = "Where " + ((!RButTyp.Value) ? " T_INVHED.InvTyp = 1 " : " T_INVHED.InvTyp = 3") + ((vType == 0) ? " and T_INVHED.MndNo > 0 " : " ");
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
            if (!string.IsNullOrEmpty(txtSuppNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtSuppNo.Tag, " = '", txtSuppNo.Text.Trim(), "'");
            }
            if (!string.IsNullOrEmpty(txtLegNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtLegNo.Tag, " = ", txtLegNo.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtUserNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtUserNo.Tag, " = '", txtUserNo.Text.Trim(), "'");
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
            int iiCnt = 0;
            string RuleInvType = ""; int rc = FlexType.Rows.Count; if (rc == 3) rc--;
            object obj1; object[] tag;
            for (iiCnt = 0; iiCnt < rc; iiCnt++)
            {
                if ((bool)this.FlexType.GetData(iiCnt, 0))
                {
                    if (!string.IsNullOrEmpty(RuleInvType))
                    {
                        RuleInvType = string.Concat(RuleInvType, " or ");
                    }
                    obj1 = RuleInvType;
                    tag = new object[] { obj1, this.FlexType.Tag, "  = ", iiCnt };
                    RuleInvType = string.Concat(tag);
                }
            }
            if (FlexType.Rows.Count == 3)
                if ((bool)this.FlexType.GetData(2, 0))
                {
                    if (string.IsNullOrEmpty(RuleInvType))
                    {
                        obj1 = RuleInvType;
                        tag = new object[] { obj1, this.FlexType.Tag, "  = ", iiCnt };
                        RuleInvType = string.Concat(tag);
                    }
                    obj1 = RuleInvType;
                    tag = new object[] { obj1,  " or T_INVHED.InvCash = 'الشبكة' or T_INVHED.InvCash = 'شبكـــة' or T_INVHED.InvCash = '  شبكـــة  ' " };
                    RuleInvType = string.Concat(tag);
                }
            if (!string.IsNullOrEmpty(RuleInvType))
            {
                Rule = Rule + " and (" + RuleInvType + ")";
            }
            return Rule + " order by T_INVHED.MndNo ";
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
        private void ButOk_Click(object sender, EventArgs e)
        {
            try
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_INVHED Left Join  T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  Left Join T_Curency On T_INVHED.CurTyp = T_Curency.Curency_ID Left Join T_CstTbl On T_INVHED.InvCstNo = T_CstTbl.Cst_ID Left Join T_Mndob on T_INVHED.MndNo = T_Mndob.Mnd_Id Left Join T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                string Fields = "";
                Fields = ((LangArEn != 0) ? (" T_INVHED.InvNo,T_INVSETTING.InvNamE as InvTypNm,T_INVHED.GDat,T_INVHED.HDat,T_INVHED.InvCash ,T_CstTbl.Eng_Des as CostCenteNm " + ((vType == 0) ? ",T_Mndob.Mnd_No, T_Mndob.Eng_Des as MndNm" : " ,SalsManNo as Mnd_No,SalsManNam as MndNm") + ",T_INVHED.CashPayLocCur,T_INVHED.NetworkPayLocCur,T_INVHED.CreditPayLocCur,T_INVHED.InvNetLocCur,(Round(T_INVHED.InvCost ," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as  InvCost,(Round(T_INVHED.InvNetLocCur - T_INVHED.InvCost ," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as InvProfit,T_INVHED.GadeNo,T_INVHED.CusVenNo,T_INVHED.CusVenNm,T_SYSSETTING.LogImg ,CommMnd_Inv,T_Curency.Arb_Des as CurrnceyNm") : (" T_INVHED.InvNo, T_INVSETTING.InvNamA as InvTypNm,T_INVHED.GDat,T_INVHED.HDat,T_INVHED.InvCash ,T_CstTbl.Arb_Des as CostCenteNm " + ((vType == 0) ? ",T_Mndob.Mnd_No, T_Mndob.Arb_Des as MndNm" : " ,SalsManNo as Mnd_No,SalsManNam as MndNm") + ",T_INVHED.CashPayLocCur,T_INVHED.NetworkPayLocCur,T_INVHED.CreditPayLocCur,T_INVHED.InvNetLocCur,(Round(T_INVHED.InvCost ," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as  InvCost,(Round(T_INVHED.InvNetLocCur - T_INVHED.InvCost ," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as InvProfit,T_INVHED.GadeNo,T_INVHED.CusVenNo,T_INVHED.CusVenNm,T_SYSSETTING.LogImg ,CommMnd_Inv,T_Curency.Arb_Des as CurrnceyNm"));
                _RepShow.Rule = BuildRuleList();
                _RepShow.Fields = Fields;
                try
                {
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                    if (vType == 1 && VarGeneral.RepData.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
                        {
                            VarGeneral.RepData.Tables[0].Rows[i]["MndNm"] = ((LangArEn == 0) ? dbc.RateUsr(VarGeneral.RepData.Tables[0].Rows[i]["Mnd_No"].ToString()).UsrNamA : dbc.RateUsr(VarGeneral.RepData.Tables[0].Rows[i]["Mnd_No"].ToString()).UsrNamE);
                            VarGeneral.RepData.Tables[0].Rows[i]["CommMnd_Inv"] = ((dbc.RateUsr(VarGeneral.UserNo).RepInv6 == "0") ? (double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["InvNetLocCur"].ToString()) * (dbc.RateUsr(VarGeneral.RepData.Tables[0].Rows[i]["Mnd_No"].ToString()).Comm_Inv.Value / 100.0)) : dbc.RateUsr(VarGeneral.RepData.Tables[0].Rows[i]["Mnd_No"].ToString()).Comm_Inv.Value);
                        }
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
                    frm.Repvalue = "InvoicesComm";
                    frm.Tag = LangArEn;
                    frm.Repvalue = "InvoicesComm";
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
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }
        private void ButExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button_SrchCustNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_AccDef2";
            VarGeneral.AccTyp = 4;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtCustNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
                txtCustNo.Text = "";
                txtCustName.Text = "";
            }
        }
        private void button_SrchSuppNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_AccDef_Suppliers";
            VarGeneral.AccTyp = 5;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtSuppNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtSuppName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    txtSuppName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
            }
            else
            {
                txtSuppNo.Text = "";
                txtSuppName.Text = "";
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
                txtLegNo.Text = db.StockMndob(frm.Serach_No).Mnd_ID.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
                txtLegNo.Text = "";
                txtLegName.Text = "";
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
                txtCostNo.Text = db.StockCst(frm.Serach_No).Cst_ID.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
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
                txtCostNo.Text = "";
                txtCostName.Text = "";
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
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ButExit.Text = "خــــروج Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "طبـــاعة F5" : "عــــرض F5");
                groupBox3.Text = "حسب رقم الفاتورة";
                groupBox_Date.Text = "حسب تاريخ الفاتورة";
                label1.Text = "مـــــن :";
                label2.Text = "إلـــــى :";
                label3.Text = "مـــــن :";
                label4.Text = "إلـــــى :";
                label5.Text = "العميـــــــــل :";
                label6.Text = "المــــــــــورد :";
                label7.Text = "المنـــــــدوب :";
                label8.Text = "مركز التكلفة :";
                label9.Text = "المستخـــدم :";
                label22.Text = "طريقة الدفع";
                radioButton_Del0.Text = "الغير محذوفة";
                radioButton_Del1.Text = "الكـــل";
                radioButton_Del2.Text = "المحذوفة فقط";
                radioButton__0650Return0.Text = "الغير مرتجعة";
                radioButton__0650Return1.Text = "الكـــل";
                radioButton__0650Return2.Text = "المرتجعة فقط";
                RButTyp.OffText = "مبيعات";
                RButTyp.OnText = "مرتجع مبيعات";
            }
            else
            {
                ButExit.Text = "Exit Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "Print F5" : "Show F5");
                groupBox3.Text = "Quantity";
                groupBox_Date.Text = "Date of inactivity";
                label1.Text = "From :";
                label2.Text = "To :";
                label3.Text = "From :";
                label4.Text = "To :";
                label5.Text = "From Item :";
                label6.Text = "To Item :";
                label7.Text = "Delegate :";
                label8.Text = "Cost Center :";
                label9.Text = "User :";
                label22.Text = "Payment method";
                RButTyp.OffText = "Sales";
                RButTyp.OnText = "Sales Return";
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptSchool.dll"))
            {
                label5.Text = ((LangArEn == 0) ? "الطـالـب :" : "Student Acc :");
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptBus.dll"))
            {
                label8.Text = ((LangArEn == 0) ? "الباص :" : "Bus :");
                label7.Text = ((LangArEn == 0) ? "السائق :" : "Driver :");
            }
        }
        private void FrmInvCommMnd_Load(object sender, EventArgs e)
        {
        }
        private void radioButton__0650Return0_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void radioButton__0650Return2_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void radioButton__0650Return1_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void FrmInvCommMnd_VisibleChanged(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
