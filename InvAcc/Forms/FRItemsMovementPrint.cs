using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Framework.Date;
using Framework.UI;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Library.RepShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FRItemsMovementPrint : Form
    { void avs(int arln)

{ 
  label7.Text=   (arln == 0 ? "  المنـــــــدوب :  " : "  Delegate:") ; label10.Text=   (arln == 0 ? "  الوحــــــدة :  " : "  Unity:") ; label22.Text=   (arln == 0 ? "  الفواتــــير  " : "  billing") ; label6.Text=   (arln == 0 ? "  المـــــــورد :  " : "  Supplier:") ; label5.Text=   (arln == 0 ? "  العميــــــل :  " : "  Customer:") ; label4.Text=   (arln == 0 ? "  إلى صنف :  " : "  to class:") ; label3.Text=   (arln == 0 ? "  من صنف :  " : "  of class:") ; label55.Text=   (arln == 0 ? "  التصنيف :  " : "  Category :") ; groupBox4.Text=   (arln == 0 ? "  حسب التاريخ  " : "  by date") ; label1.Text=   (arln == 0 ? "  مـــــن :  " : "  from:") ; label2.Text=   (arln == 0 ? "  إلـــــى :  " : "  to:") ; RButShort.Text=   (arln == 0 ? "  مختصر  " : "  short") ; RButDetails.Text=   (arln == 0 ? "  تفصيلي  " : "  detailed") ;}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
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
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData.ToString().Contains("Control") && !keyData.ToString().ToLower().Contains("delete") && keyData.ToString().Contains("Alt"))
            {
                try
                {
                    VarGeneral.Print_set_Gen_Stat = true;
                    FrmReportsViewer.IsSettingOnly = true;
                    {
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "ItemsMovementPrint";
                        frm.Repvalue = "ItemsMovementPrint";
                        //ADDADD
                        frm.Tag = LangArEn;
                        frm.ShowDialog();
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
        private T_User _User = new T_User();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
       // private IContainer components = null;
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
        private Softgroup.NetResize.NetResize netResize1;
        private Label label4;
        private Label label3;
        private ButtonX button_SrchItemFrom;
        private RibbonBar ribbonBar1;
        private TextBox txtIntoItemName;
        private TextBox txtFromItemName;
        private TextBox txtGroupItemName;
        private TextBox txtFromItemNo;
        private TextBox txtIntoItemNo;
        private TextBox txtGroupItemNo;
        private Label label55;
        private ButtonX button_SrchCatNo;
        private ButtonX button_SrchItemTo;
        private GroupBox groupBox4;
        private MaskedTextBox txtMToDate;
        private MaskedTextBox txtMFromDate;
        private Label label1;
        private Label label2;
        private GroupBox groupBox2;
        private RadioButton RButShort;
        private RadioButton RButDetails;
        private Label label6;
        private Label label5;
        private ButtonX button_SrchSuppNo;
        private ButtonX button_SrchCustNo;
        private TextBox txtSuppName;
        private TextBox txtSuppNo;
        private TextBox txtCustName;
        private TextBox txtCustNo;
        private C1FlexGrid FlexType;
        private Label label22;
        private Label label10;
        private ComboBoxEx combobox_Unit;
        private Label label7;
        private ButtonX button_SrchLegNo;
        private TextBox txtLegNo;
        private C1.Win.C1Input.C1Button ButOk;
        private C1.Win.C1Input.C1Button ButExit;
        private TextBox txtLegName;
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
        public FRItemsMovementPrint(string ItemNo, string ItemName)
        {
            InitializeComponent();this.Load += langloads;
            txtFromItemName.Text = ItemName;
            txtFromItemNo.Text = ItemNo;
            txtIntoItemName.Text = ItemName;
            txtIntoItemNo.Text = ItemNo;
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
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ButExit.Text = "خــــروج Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "طبـــاعة F5" : "عــــرض F5");
                groupBox4.Text = "حسب التاريخ";
                label1.Text = "مـــــن :";
                label2.Text = "إلـــــى :";
                label3.Text = "من الصنف :";
                label4.Text = "إلى الصنف :";
                label55.Text = "المجموعة :";
                Text = "طباعة حركة صنف";
            }
            else
            {
                ButExit.Text = "Exit Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "Print F5" : "Show F5");
                groupBox4.Text = "Date";
                label1.Text = "From :";
                label2.Text = "To :";
                label3.Text = "From Item :";
                label4.Text = "To Item :";
                label55.Text = "Group :";
                Text = "Print Item Movement";
            }
            if (File.Exists(Application.StartupPath + "\\\\Script\\\\SecriptSchool.dll"))
            {
                label5.Text = ((LangArEn == 0) ? "الطـالـب :" : "Student Acc :");
                FlexType.SetData(4, 1, "عرض سعر للطلاب");
                FlexType.Rows[8].Visible = false;
                FlexType.Rows[9].Visible = false;
                FlexType.Rows[10].Visible = false;
                FlexType.Rows[11].Visible = false;
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRItemsMovementPrint));
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
            FillFlex();
            FillCombo(); avs(GeneralM.VarGeneral.currentintlanguage);
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRItemsMovementPrint));
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
        private void FillFlex()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                FlexType.Rows.Count = 13;
                FlexType.SetData(0, 0, true);
                FlexType.SetData(0, 1, "مبيعات");
                FlexType.SetData(0, 2, "1");
                FlexType.SetData(1, 0, true);
                FlexType.SetData(1, 1, "مرتجع مبيعات");
                FlexType.SetData(1, 2, "3");
                FlexType.SetData(2, 0, true);
                FlexType.SetData(2, 1, "مشتريات");
                FlexType.SetData(2, 2, "2");
                FlexType.SetData(3, 0, true);
                FlexType.SetData(3, 1, "مرتجع مشتريات");
                FlexType.SetData(3, 2, "4");
                FlexType.SetData(4, 0, true);
                FlexType.SetData(4, 1, "عرض سعر عملاء");
                FlexType.SetData(4, 2, "7");
                FlexType.SetData(5, 0, true);
                FlexType.SetData(5, 1, "عرض سعر مورد");
                FlexType.SetData(5, 2, "8");
                FlexType.SetData(6, 0, true);
                FlexType.SetData(6, 1, "طلب شراء");
                FlexType.SetData(6, 2, "9");
                FlexType.SetData(7, 0, true);
                FlexType.SetData(7, 1, "بضاعة أول المدة");
                FlexType.SetData(7, 2, "14");
                FlexType.SetData(8, 0, true);
                FlexType.SetData(8, 1, "إدخال بضاعة");
                FlexType.SetData(8, 2, "5");
                FlexType.SetData(9, 0, true);
                FlexType.SetData(9, 1, "إخراج بضاعة");
                FlexType.SetData(9, 2, "6");
                FlexType.SetData(10, 0, true);
                FlexType.SetData(10, 1, "صرف بضاعة");
                FlexType.SetData(10, 2, "17");
                FlexType.SetData(11, 0, true);
                FlexType.SetData(11, 1, "مرتجع صرف بضاعة");
                FlexType.SetData(11, 2, "20");
                FlexType.SetData(12, 0, true);
                FlexType.SetData(12, 1, "تسوية البضاعة");
                FlexType.SetData(12, 2, "10");
                Text = "تقرير حركة صنف";
            }
            else
            {
                FlexType.Rows.Count = 13;
                FlexType.SetData(0, 0, true);
                FlexType.SetData(0, 1, "Sales");
                FlexType.SetData(0, 2, "1");
                FlexType.SetData(1, 0, true);
                FlexType.SetData(1, 1, "Returned sales");
                FlexType.SetData(1, 2, "3");
                FlexType.SetData(2, 0, true);
                FlexType.SetData(2, 1, "Purchases");
                FlexType.SetData(2, 2, "2");
                FlexType.SetData(3, 0, true);
                FlexType.SetData(3, 1, "Returned Purchases");
                FlexType.SetData(3, 2, "4");
                FlexType.SetData(4, 0, true);
                FlexType.SetData(4, 1, "Quote Cust");
                FlexType.SetData(4, 2, "7");
                FlexType.SetData(5, 0, true);
                FlexType.SetData(5, 1, "Quote Supp");
                FlexType.SetData(5, 2, "8");
                FlexType.SetData(6, 0, true);
                FlexType.SetData(6, 1, "Purchase Order");
                FlexType.SetData(6, 2, "9");
                FlexType.SetData(7, 0, true);
                FlexType.SetData(7, 1, "Quantitative opening");
                FlexType.SetData(7, 2, "14");
                FlexType.SetData(8, 0, true);
                FlexType.SetData(8, 1, "introduction goods");
                FlexType.SetData(8, 2, "5");
                FlexType.SetData(9, 0, true);
                FlexType.SetData(9, 1, "Directed goods");
                FlexType.SetData(9, 2, "6");
                FlexType.SetData(10, 0, true);
                FlexType.SetData(10, 1, "Exchange goods");
                FlexType.SetData(10, 2, "17");
                FlexType.SetData(11, 0, true);
                FlexType.SetData(11, 1, "Return Exchange goods");
                FlexType.SetData(11, 2, "20");
                FlexType.SetData(12, 0, true);
                FlexType.SetData(12, 1, "Settlement goods");
                FlexType.SetData(12, 2, "10");
                Text = "Item Movement Report";
            }
            if (File.Exists(Application.StartupPath + "\\\\Script\\\\SecriptTegnicalCollage.dll"))
            {
                label5.Text = ((LangArEn == 0) ? "الطـالـب :" : "Student Acc :");
                label7.Text = ((LangArEn == 0) ? "الأستــاذ :" : "Teacher :");
                FlexType.Rows[0].Visible = false;
                FlexType.Rows[1].Visible = false;
                FlexType.Rows[4].Visible = false;
                FlexType.Rows[5].Visible = false;
                FlexType.Rows[8].Visible = false;
                FlexType.Rows[9].Visible = false;
                FlexType.SetData(10, 1, "فاتورة إصدار عهدة");
                FlexType.SetData(11, 1, "فاتورة إرجاع عهدة");
            }
            if (File.Exists(Application.StartupPath + "\\\\Script\\\\SecriptWaterPackages.dll"))
            {
                label5.Text = ((LangArEn == 0) ? "الســائـق :" : "Driver Acc :");
                label7.Text = ((LangArEn == 0) ? "العميـــل :" : "Customer :");
                FlexType.Rows[10].Visible = false;
                FlexType.Rows[11].Visible = false;
                FlexType.SetData(4, 1, "عرض سعر سائقين");
            }
            if (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", "").Trim() + "\\khalijwatania.dll"))
            {
                FlexType.SetData(0, 1, (LangArEn == 0) ? "خدمة" : "Service");
            }
            RibunButtons();
        }
        private string BuildRuleList()
        {
            HijriGregDates dateFormatter = new HijriGregDates();
            string Rule = " Where T_INVHED.InvTyp != 21 and  T_INVHED.IfDel != 1 and T_Items.ItmTyp != 2 and (T_INVHED.PaymentOrderTyp = 0 or ( T_INVHED.InvTyp = 17 or T_INVHED.InvTyp = 20))";
            try
            {
                db.ExecuteCommand("select CONVERT(int,T_Items.Itm_No) from T_Items");
                if (!string.IsNullOrEmpty(txtFromItemNo.Text))
                {
                    object obj = Rule;
                    Rule = string.Concat(obj, " and ", txtFromItemNo.Tag, " >= ", txtFromItemNo.Text.Trim());
                }
                if (!string.IsNullOrEmpty(txtIntoItemNo.Text))
                {
                    object obj = Rule;
                    Rule = string.Concat(obj, " and ", txtIntoItemNo.Tag, " <= ", txtIntoItemNo.Text.Trim());
                }
            }
            catch
            {
                if (!string.IsNullOrEmpty(txtFromItemNo.Text))
                {
                    object obj = Rule;
                    Rule = string.Concat(obj, " and ", txtFromItemNo.Tag, " >= '", txtFromItemNo.Text.Trim(), "'");
                }
                if (!string.IsNullOrEmpty(txtIntoItemNo.Text))
                {
                    object obj = Rule;
                    Rule = string.Concat(obj, " and ", txtIntoItemNo.Tag, " <= '", txtIntoItemNo.Text.Trim(), "'");
                }
            }
            if (!string.IsNullOrEmpty(txtGroupItemNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtGroupItemNo.Tag, " = '", txtGroupItemNo.Text.Trim(), "'");
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
            if (VarGeneral.CheckDate(txtMFromDate.Text) && txtMFromDate.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMFromDate.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_INVHED.GDat  >= '" + dateFormatter.FormatGreg(txtMFromDate.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_INVHED.HDat  >= '" + dateFormatter.FormatHijri(txtMFromDate.Text, "yyyy/MM/dd") + "'"));
            }
            if (VarGeneral.CheckDate(txtMToDate.Text) && txtMToDate.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMToDate.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_INVHED.GDat  <= '" + dateFormatter.FormatGreg(txtMToDate.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_INVHED.HDat  <= '" + dateFormatter.FormatHijri(txtMToDate.Text, "yyyy/MM/dd") + "'"));
            }
            for (int i = 0; i < FlexType.Rows.Count; i++)
            {
                try
                {
                    if (!Convert.ToBoolean(FlexType.Rows[i][0].ToString()))
                    {
                        Rule = Rule + " and T_INVHED.InvTyp != " + FlexType.Rows[i][2].ToString();
                    }
                }
                catch
                {
                }
            }
            if (RButShort.Checked)
            {
                return Rule + "  group by T_Items.Itm_No  Order by Itm_No ";
            }
            return Rule + " Order by Itm_No , GDat , StoreNo ";
        }
        private string BuildRuleList2()
        {
            HijriGregDates dateFormatter = new HijriGregDates();
            string Rule = " Where 1 = 1 and  T_INVHED.IfDel != 1  and (T_INVHED.PaymentOrderTyp = 0 or ( T_INVHED.InvTyp = 17 or T_INVHED.InvTyp = 20)) ";
            try
            {
                db.ExecuteCommand("select CONVERT(int,T_Items.Itm_No) from T_Items");
                if (!string.IsNullOrEmpty(txtFromItemNo.Text))
                {
                    object obj = Rule;
                    Rule = string.Concat(obj, " and ", txtFromItemNo.Tag, " >= ", txtFromItemNo.Text.Trim());
                }
                if (!string.IsNullOrEmpty(txtIntoItemNo.Text))
                {
                    object obj = Rule;
                    Rule = string.Concat(obj, " and ", txtIntoItemNo.Tag, " <= ", txtIntoItemNo.Text.Trim());
                }
            }
            catch
            {
                if (!string.IsNullOrEmpty(txtFromItemNo.Text))
                {
                    object obj = Rule;
                    Rule = string.Concat(obj, " and ", txtFromItemNo.Tag, " >= '", txtFromItemNo.Text.Trim(), "'");
                }
                if (!string.IsNullOrEmpty(txtIntoItemNo.Text))
                {
                    object obj = Rule;
                    Rule = string.Concat(obj, " and ", txtIntoItemNo.Tag, " <= '", txtIntoItemNo.Text.Trim(), "'");
                }
            }
            if (!string.IsNullOrEmpty(txtGroupItemNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtGroupItemNo.Tag, " = '", txtGroupItemNo.Text.Trim(), "'");
            }
            if (VarGeneral.CheckDate(txtMFromDate.Text) && txtMFromDate.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMFromDate.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_INVHED.GDat  < '" + dateFormatter.FormatGreg(txtMFromDate.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_INVHED.HDate  < '" + dateFormatter.FormatHijri(txtMFromDate.Text, "yyyy/MM/dd") + "'"));
            }
            return Rule + " Group by T_Items.Itm_No , T_Items.Eng_Des , T_Items.Arb_Des ";
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
                _RepShow.Tables = "T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                string Fields = "";
                Fields = ((LangArEn == 0) ? ((!RButDetails.Checked) ? " MAX(T_Items.Itm_No ) as Itm_No , MAX(T_Items.Arb_Des ) as itemNm   , MAX( T_Category.Arb_Des ) as [CategoyNm] ,  SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) AS [Credit] ,  SUM (CASE WHEN T_InvDet.RealQty < 0 THEN ABS(T_InvDet.RealQty)  Else 0 END ) AS [Debit],MAX (T_SYSSETTING.LogImg) as LogImg  " : ((combobox_Unit.SelectedIndex <= 0) ? " T_Items.Itm_No , T_Items.Arb_Des as itemNm  , T_INVSETTING.InvNamA as InvNm  , T_Category.Arb_Des as [CategoyNm], T_INVHED.InvNo ,  T_INVHED.HDat , T_INVHED.GDat , T_InvDet.StoreNo , T_InvDet.ItmUnt as ItmUntNm, (T_InvDet.ItmUntPak) as [ItmUntPak], (Abs(T_InvDet.Qty)) as [Qty] ,  CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END AS [Credit] ,  CASE WHEN T_InvDet.RealQty < 0 THEN ABS(T_InvDet.RealQty)  Else 0 END AS [Debit],T_SYSSETTING.LogImg  " : (" T_Items.Itm_No , T_Items.Arb_Des as itemNm  , T_INVSETTING.InvNamA as InvNm  , T_Category.Arb_Des as [CategoyNm], T_INVHED.InvNo ,  T_INVHED.HDat , T_INVHED.GDat , T_InvDet.StoreNo , (case when (select T_Items.Pack1 where (select T_Unit.Arb_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit1) = '" + combobox_Unit.Text + "' and T_INVDET.ItmUnt != '" + combobox_Unit.Text + "') > 0 then  (select T_Unit.Arb_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit1) WHEN (select T_Items.Pack2 where (select T_Unit.Arb_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit2) = '" + combobox_Unit.Text + "' and T_INVDET.ItmUnt != '" + combobox_Unit.Text + "') > 0 then  (select T_Unit.Arb_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit2)  WHEN (select T_Items.Pack3 where (select T_Unit.Arb_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit3) = '" + combobox_Unit.Text + "' and T_INVDET.ItmUnt != '" + combobox_Unit.Text + "') > 0 then  (select T_Unit.Arb_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit3)  WHEN (select T_Items.Pack4 where (select T_Unit.Arb_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit4) = '" + combobox_Unit.Text + "' and T_INVDET.ItmUnt != '" + combobox_Unit.Text + "') > 0 then  (select T_Unit.Arb_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit4) WHEN (select T_Items.Pack5 where (select T_Unit.Arb_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit5) = '" + combobox_Unit.Text + "' and T_INVDET.ItmUnt != '" + combobox_Unit.Text + "') > 0 then  (select T_Unit.Arb_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit5) else T_InvDet.ItmUnt end) AS [ItmUntNm], (case when (select T_Items.Pack1 where (select T_Unit.Arb_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit1) = '" + combobox_Unit.Text + "' and T_INVDET.ItmUnt != '" + combobox_Unit.Text + "') > 0 then  T_Items.Pack1 WHEN (select T_Items.Pack2 where (select T_Unit.Arb_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit2) = '" + combobox_Unit.Text + "' and T_INVDET.ItmUnt != '" + combobox_Unit.Text + "') > 0 then  T_Items.Pack2  WHEN (select T_Items.Pack3 where (select T_Unit.Arb_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit3) = '" + combobox_Unit.Text + "' and T_INVDET.ItmUnt != '" + combobox_Unit.Text + "') > 0 then  T_Items.Pack3 WHEN (select T_Items.Pack4 where (select T_Unit.Arb_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit4) = '" + combobox_Unit.Text + "' and T_INVDET.ItmUnt != '" + combobox_Unit.Text + "') > 0 then  T_Items.Pack4 WHEN (select T_Items.Pack5 where (select T_Unit.Arb_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit5) = '" + combobox_Unit.Text + "' and T_INVDET.ItmUnt != '" + combobox_Unit.Text + "') > 0 then  T_Items.Pack5 else (T_InvDet.ItmUntPak) end) AS [ItmUntPak], (case when (select T_Items.Pack1 where (select T_Unit.Arb_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit1) = '" + combobox_Unit.Text + "' and T_INVDET.ItmUnt != '" + combobox_Unit.Text + "') > 0 then (Abs(T_InvDet.RealQty))/ T_Items.Pack1 WHEN (select T_Items.Pack2 where (select T_Unit.Arb_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit2) = '" + combobox_Unit.Text + "' and T_INVDET.ItmUnt != '" + combobox_Unit.Text + "') > 0 then (Abs(T_InvDet.RealQty))/ T_Items.Pack2  WHEN (select T_Items.Pack3 where (select T_Unit.Arb_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit3) = '" + combobox_Unit.Text + "' and T_INVDET.ItmUnt != '" + combobox_Unit.Text + "') > 0 then (Abs(T_InvDet.RealQty))/ T_Items.Pack3 WHEN (select T_Items.Pack4 where (select T_Unit.Arb_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit4) = '" + combobox_Unit.Text + "' and T_INVDET.ItmUnt != '" + combobox_Unit.Text + "') > 0 then (Abs(T_InvDet.RealQty))/ T_Items.Pack4 WHEN (select T_Items.Pack5 where (select T_Unit.Arb_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit5) = '" + combobox_Unit.Text + "' and T_INVDET.ItmUnt != '" + combobox_Unit.Text + "') > 0 then (Abs(T_InvDet.RealQty))/ T_Items.Pack5 else (Abs(T_InvDet.Qty)) end) AS [Qty] ,  CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END AS [Credit] ,  CASE WHEN T_InvDet.RealQty < 0 THEN ABS(T_InvDet.RealQty)  Else 0 END AS [Debit],T_SYSSETTING.LogImg  "))) : ((!RButDetails.Checked) ? " MAX(T_Items.Itm_No ) as Itm_No , MAX(T_Items.Eng_Des ) as itemNm   , MAX( T_Category.Eng_Des ) as [CategoyNm] ,  SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) AS [Credit] ,  SUM (CASE WHEN T_InvDet.RealQty < 0 THEN ABS(T_InvDet.RealQty)  Else 0 END ) AS [Debit],MAX (T_SYSSETTING.LogImg) as LogImg " : ((combobox_Unit.SelectedIndex <= 0) ? " T_Items.Itm_No , T_Items.Eng_Des as itemNm  , T_INVSETTING.InvNamE as InvNm  , T_Category.Eng_Des as [CategoyNm], T_INVHED.InvNo ,  T_INVHED.HDat , T_INVHED.GDat , T_InvDet.StoreNo , T_InvDet.ItmUntE as ItmUntNm, (T_InvDet.ItmUntPak) as [ItmUntPak], (Abs(T_InvDet.Qty)) as [Qty] ,  CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END AS [Credit] ,  CASE WHEN T_InvDet.RealQty < 0 THEN ABS(T_InvDet.RealQty)  Else 0 END AS [Debit],T_SYSSETTING.LogImg  " : (" T_Items.Itm_No , T_Items.Eng_Des as itemNm  , T_INVSETTING.InvNamA as InvNm  , T_Category.Eng_Des as [CategoyNm], T_INVHED.InvNo ,  T_INVHED.HDat , T_INVHED.GDat , T_InvDet.StoreNo ,(case when (select T_Items.Pack1 where (select T_Unit.Eng_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit1) = '" + combobox_Unit.Text + "' and T_INVDET.ItmUntE != '" + combobox_Unit.Text + "') > 0 then  (select T_Unit.Eng_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit1) WHEN (select T_Items.Pack2 where (select T_Unit.Eng_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit2) = '" + combobox_Unit.Text + "' and T_INVDET.ItmUntE != '" + combobox_Unit.Text + "') > 0 then  (select T_Unit.Eng_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit2)  WHEN (select T_Items.Pack3 where (select T_Unit.Eng_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit3) = '" + combobox_Unit.Text + "' and T_INVDET.ItmUntE != '" + combobox_Unit.Text + "') > 0 then  (select T_Unit.Eng_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit3)  WHEN (select T_Items.Pack4 where (select T_Unit.Eng_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit4) = '" + combobox_Unit.Text + "' and T_INVDET.ItmUntE != '" + combobox_Unit.Text + "') > 0 then  (select T_Unit.Eng_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit4) WHEN (select T_Items.Pack5 where (select T_Unit.Eng_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit5) = '" + combobox_Unit.Text + "' and T_INVDET.ItmUntE != '" + combobox_Unit.Text + "') > 0 then  (select T_Unit.Eng_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit5) else T_InvDet.ItmUntE end) AS [ItmUntNm], (case when (select T_Items.Pack1 where (select T_Unit.Eng_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit1) = '" + combobox_Unit.Text + "' and T_INVDET.ItmUntE != '" + combobox_Unit.Text + "') > 0 then  T_Items.Pack1 WHEN (select T_Items.Pack2 where (select T_Unit.Eng_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit2) = '" + combobox_Unit.Text + "' and T_INVDET.ItmUntE != '" + combobox_Unit.Text + "') > 0 then  T_Items.Pack2  WHEN (select T_Items.Pack3 where (select T_Unit.Eng_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit3) = '" + combobox_Unit.Text + "' and T_INVDET.ItmUntE != '" + combobox_Unit.Text + "') > 0 then  T_Items.Pack3 WHEN (select T_Items.Pack4 where (select T_Unit.Eng_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit4) = '" + combobox_Unit.Text + "' and T_INVDET.ItmUntE != '" + combobox_Unit.Text + "') > 0 then  T_Items.Pack4 WHEN (select T_Items.Pack5 where (select T_Unit.Eng_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit5) = '" + combobox_Unit.Text + "' and T_INVDET.ItmUntE != '" + combobox_Unit.Text + "') > 0 then  T_Items.Pack5 else (T_InvDet.ItmUntPak) end) AS [ItmUntPak], (case when (select T_Items.Pack1 where (select T_Unit.Eng_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit1) = '" + combobox_Unit.Text + "' and T_INVDET.ItmUntE != '" + combobox_Unit.Text + "') > 0 then (Abs(T_InvDet.RealQty))/ T_Items.Pack1 WHEN (select T_Items.Pack2 where (select T_Unit.Eng_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit2) = '" + combobox_Unit.Text + "' and T_INVDET.ItmUntE != '" + combobox_Unit.Text + "') > 0 then (Abs(T_InvDet.RealQty))/ T_Items.Pack2  WHEN (select T_Items.Pack3 where (select T_Unit.Eng_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit3) = '" + combobox_Unit.Text + "' and T_INVDET.ItmUntE != '" + combobox_Unit.Text + "') > 0 then (Abs(T_InvDet.RealQty))/ T_Items.Pack3 WHEN (select T_Items.Pack4 where (select T_Unit.Eng_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit4) = '" + combobox_Unit.Text + "' and T_INVDET.ItmUntE != '" + combobox_Unit.Text + "') > 0 then (Abs(T_InvDet.RealQty))/ T_Items.Pack4 WHEN (select T_Items.Pack5 where (select T_Unit.Eng_Des from T_Unit where T_Unit.Unit_ID = T_Items.Unit5) = '" + combobox_Unit.Text + "' and T_INVDET.ItmUntE != '" + combobox_Unit.Text + "') > 0 then (Abs(T_InvDet.RealQty))/ T_Items.Pack5 else (Abs(T_InvDet.Qty)) end) AS [Qty] ,  CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END AS [Credit] ,  CASE WHEN T_InvDet.RealQty < 0 THEN ABS(T_InvDet.RealQty)  Else 0 END AS [Debit],T_SYSSETTING.LogImg  "))));
                _RepShow.Rule = BuildRuleList();
                _RepShow.Fields = Fields;
                try
                {
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                    try
                    {
                        _RepShow = new RepShow();
                        _RepShow.Tables = "T_SINVDET LEFT OUTER JOIN T_INVHED ON T_SINVDET.SInvIdHEAD = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID LEFT OUTER JOIN T_Items ON T_SINVDET.SItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                        Fields = ((LangArEn == 0) ? ((!RButDetails.Checked) ? " MAX(T_Items.Itm_No ) as Itm_No , MAX(T_Items.Arb_Des ) as itemNm   , MAX( T_Category.Arb_Des ) as [CategoyNm] ,  SUM (CASE WHEN T_SINVDET.SRealQty > 0 THEN T_SINVDET.SRealQty Else 0 END ) AS [Credit] ,  SUM (CASE WHEN T_SINVDET.SRealQty < 0 THEN ABS(T_SINVDET.SRealQty)  Else 0 END ) AS [Debit]  " : " T_Items.Itm_No , T_Items.Arb_Des as itemNm  , T_INVSETTING.InvNamA as InvNm  , T_Category.Arb_Des as [CategoyNm], T_INVHED.InvNo ,  T_INVHED.HDat , T_INVHED.GDat , T_SINVDET.SStoreNo as StoreNo , T_SINVDET.SItmUnt as ItmUntNm, (T_SINVDET.SItmUntPak) as [ItmUntPak], (Abs(T_SINVDET.SQty)) as [Qty] ,  CASE WHEN T_SINVDET.SRealQty > 0 THEN T_SINVDET.SRealQty Else 0 END AS [Credit] ,  CASE WHEN T_SINVDET.SRealQty < 0 THEN ABS(T_SINVDET.SRealQty) Else 0 END AS [Debit]  ") : ((!RButDetails.Checked) ? " MAX(T_Items.Itm_No ) as Itm_No , MAX(T_Items.Eng_Des ) as itemNm   , MAX( T_Category.Eng_Des ) as [CategoyNm] ,  SUM (CASE WHEN T_SINVDET.SRealQty > 0 THEN T_SINVDET.SRealQty Else 0 END ) AS [Credit] ,  SUM (CASE WHEN T_SINVDET.SRealQty < 0 THEN ABS(T_SINVDET.SRealQty)  Else 0 END ) AS [Debit]  " : " T_Items.Itm_No , T_Items.Eng_Des as itemNm  , T_INVSETTING.InvNamE as InvNm  , T_Category.Eng_Des as [CategoyNm], T_INVHED.InvNo ,  T_INVHED.HDat , T_INVHED.GDat , T_SINVDET.SStoreNo as StoreNo , T_SINVDET.SItmUnt as ItmUntNm, (T_SINVDET.SItmUntPak) as [ItmUntPak], (Abs(T_SINVDET.SQty)) as [Qty] ,  CASE WHEN T_SINVDET.SRealQty > 0 THEN T_SINVDET.SRealQty Else 0 END AS [Credit] ,  CASE WHEN T_SINVDET.SRealQty < 0 THEN ABS(T_SINVDET.SRealQty) Else 0 END AS [Debit]  "));
                        _RepShow.Rule = BuildRuleList();
                        _RepShow.Fields = Fields;
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData.Tables[0].Merge(_RepShow.RepData.Tables[0]);
                    }
                    catch
                    {
                    }
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
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "ItemsMovementPrint";
                        frm.Tag = LangArEn;
                        frm.Repvalue = "ItemsMovementPrint";
                        if (RButDetails.Checked)
                        {
                            VarGeneral.itmDesIndex = 0;
                        }
                        else
                        {
                            VarGeneral.itmDesIndex = 1;
                        }
                        VarGeneral.vTitle = Text;
                        frm.TopMost = true;
                        frm.ShowDialog();
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
            }
            catch
            {
            }
        }
        private void FillCombo()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                List<T_Unit> listUnit1 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
                listUnit1.Insert(0, new T_Unit());
                listUnit1[0].Arb_Des = "    ";
                combobox_Unit.DataSource = listUnit1;
                combobox_Unit.DisplayMember = "Arb_Des";
                combobox_Unit.ValueMember = "Unit_ID";
                combobox_Unit.SelectedIndex = 0;
            }
            else
            {
                List<T_Unit> listUnit1 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
                listUnit1.Insert(0, new T_Unit());
                listUnit1[0].Eng_Des = "    ";
                combobox_Unit.DataSource = listUnit1;
                combobox_Unit.DisplayMember = "Eng_Des";
                combobox_Unit.ValueMember = "Unit_ID";
                combobox_Unit.SelectedIndex = 0;
            }
        }
        private void FRItemsMovementPrint_Load(object sender, EventArgs e)
        {
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
        private void button_SrchItemFrom_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("Itm_No", new ColumnDictinary("رقم الصنف", "Item No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, ""));
            columns_Names_visible.Add("StartCost", new ColumnDictinary("التكلفةالافتتاحية", "Start Cost", ifDefault: false, ""));
            columns_Names_visible.Add("AvrageCost", new ColumnDictinary("متوسط التكلفة", "Average Cost", ifDefault: false, ""));
            columns_Names_visible.Add("LastCost", new ColumnDictinary("آخر تكلفة", "Last Cost", ifDefault: false, ""));
            columns_Names_visible.Add("Arb_Des_Cat", new ColumnDictinary("الاسم العربي لمجموعة الصنف", "CATEGORY Arabic Name", ifDefault: false, ""));
            columns_Names_visible.Add("Eng_Des_Cat", new ColumnDictinary("الاسم الانجليزي لمجموعة الصنف", "CATEGORY English Name", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_Items";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtFromItemNo.Text = frm.Serach_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtFromItemName.Text = db.StockItem(frm.Serach_No).Arb_Des.ToString();
                }
                else
                {
                    txtFromItemName.Text = db.StockItem(frm.Serach_No).Eng_Des.ToString();
                }
            }
            else
            {
                txtFromItemNo.Text = "";
                txtFromItemName.Text = "";
            }
        }
        private void button_SrchItemTo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("Itm_No", new ColumnDictinary("رقم الصنف", "Item No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, ""));
            columns_Names_visible.Add("StartCost", new ColumnDictinary("التكلفةالافتتاحية", "Start Cost", ifDefault: false, ""));
            columns_Names_visible.Add("AvrageCost", new ColumnDictinary("متوسط التكلفة", "Average Cost", ifDefault: false, ""));
            columns_Names_visible.Add("LastCost", new ColumnDictinary("آخر تكلفة", "Last Cost", ifDefault: false, ""));
            columns_Names_visible.Add("Arb_Des_Cat", new ColumnDictinary("الاسم العربي لمجموعة الصنف", "CATEGORY Arabic Name", ifDefault: false, ""));
            columns_Names_visible.Add("Eng_Des_Cat", new ColumnDictinary("الاسم الانجليزي لمجموعة الصنف", "CATEGORY English Name", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_Items";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtIntoItemNo.Text = frm.Serach_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtIntoItemName.Text = db.StockItem(frm.Serach_No).Arb_Des.ToString();
                }
                else
                {
                    txtIntoItemName.Text = db.StockItem(frm.Serach_No).Eng_Des.ToString();
                }
            }
            else
            {
                txtIntoItemNo.Text = "";
                txtIntoItemName.Text = "";
            }
        }
        private void button_SrchCatNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("CAT_No", new ColumnDictinary("الرمـــز", "CATEGORY No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_CATEGORY";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtGroupItemNo.Text = db.StockCat(frm.Serach_No).CAT_ID.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtGroupItemName.Text = db.StockCat(frm.Serach_No).Arb_Des;
                }
                else
                {
                    txtGroupItemName.Text = db.StockCat(frm.Serach_No).Eng_Des;
                }
            }
            else
            {
                txtGroupItemNo.Text = "";
                txtGroupItemName.Text = "";
            }
        }
        private void txtFromItemNo_Click(object sender, EventArgs e)
        {
            txtFromItemNo.SelectAll();
        }
        private void txtIntoItemNo_Click(object sender, EventArgs e)
        {
            txtIntoItemNo.SelectAll();
        }
        private void txtGroupItemNo_Click(object sender, EventArgs e)
        {
            txtGroupItemNo.SelectAll();
        }
        private void txtFromItemName_Click(object sender, EventArgs e)
        {
            txtFromItemName.SelectAll();
        }
        private void txtIntoItemName_Click(object sender, EventArgs e)
        {
            txtIntoItemName.SelectAll();
        }
        private void txtGroupItemName_Click(object sender, EventArgs e)
        {
            txtGroupItemName.SelectAll();
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
        private void txtGroupItemName_TextChanged(object sender, EventArgs e)
        {
        }
        private void button_SrchCustNo_Click(object sender, EventArgs e)
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
        private void RButShort_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                combobox_Unit.SelectedIndex = 0;
                if (RButShort.Checked)
                {
                    combobox_Unit.Enabled = false;
                }
                else
                {
                    combobox_Unit.Enabled = true;
                }
            }
            catch
            {
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
        private void ButOk_MouseMove(object sender, MouseEventArgs e)
        {
            ButOk.BackgroundImage = Properties.Resources.howver;
            ButOk.BackgroundImageLayout = ImageLayout.Stretch;
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
        private void ButOk_MouseLeave(object sender, EventArgs e)
        {
            ButOk.BackgroundImage = Properties.Resources.print;
            ButOk.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void ribbonBar1_ItemClick(object sender, EventArgs e)
        {
        }
    }
}
