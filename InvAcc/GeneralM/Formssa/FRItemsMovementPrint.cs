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
    public partial class FRItemsMovementPrint : Form
    {
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
            if (!keyData.ToString().Contains("Control") && !keyData.ToString().ToLower().Contains("delete") && keyData.ToString().Contains("Alt"))
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
        private IContainer components = null;
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
            InitializeComponent();
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
            FillCombo();
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
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRItemsMovementPrint));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.ButOk = new C1.Win.C1Input.C1Button();
            this.ButExit = new C1.Win.C1Input.C1Button();
            this.label7 = new System.Windows.Forms.Label();
            this.button_SrchLegNo = new DevComponents.DotNetBar.ButtonX();
            this.txtLegNo = new System.Windows.Forms.TextBox();
            this.txtLegName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.combobox_Unit = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label22 = new System.Windows.Forms.Label();
            this.FlexType = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_SrchSuppNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchCustNo = new DevComponents.DotNetBar.ButtonX();
            this.txtSuppNo = new System.Windows.Forms.TextBox();
            this.txtCustNo = new System.Windows.Forms.TextBox();
            this.txtFromItemNo = new System.Windows.Forms.TextBox();
            this.txtIntoItemNo = new System.Windows.Forms.TextBox();
            this.txtGroupItemNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.button_SrchCatNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchItemTo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchItemFrom = new DevComponents.DotNetBar.ButtonX();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtMToDate = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMFromDate = new System.Windows.Forms.MaskedTextBox();
            this.txtIntoItemName = new System.Windows.Forms.TextBox();
            this.txtFromItemName = new System.Windows.Forms.TextBox();
            this.txtGroupItemName = new System.Windows.Forms.TextBox();
            this.txtSuppName = new System.Windows.Forms.TextBox();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RButShort = new System.Windows.Forms.RadioButton();
            this.RButDetails = new System.Windows.Forms.RadioButton();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.PanelSpecialContainer.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlexType)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelSpecialContainer
            // 
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar1);
            this.PanelSpecialContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSpecialContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelSpecialContainer.Name = "PanelSpecialContainer";
            this.PanelSpecialContainer.Size = new System.Drawing.Size(539, 325);
            this.PanelSpecialContainer.TabIndex = 1220;
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
            this.ribbonBar1.Controls.Add(this.ButOk);
            this.ribbonBar1.Controls.Add(this.ButExit);
            this.ribbonBar1.Controls.Add(this.label7);
            this.ribbonBar1.Controls.Add(this.button_SrchLegNo);
            this.ribbonBar1.Controls.Add(this.txtLegNo);
            this.ribbonBar1.Controls.Add(this.txtLegName);
            this.ribbonBar1.Controls.Add(this.label10);
            this.ribbonBar1.Controls.Add(this.combobox_Unit);
            this.ribbonBar1.Controls.Add(this.label22);
            this.ribbonBar1.Controls.Add(this.FlexType);
            this.ribbonBar1.Controls.Add(this.label6);
            this.ribbonBar1.Controls.Add(this.label5);
            this.ribbonBar1.Controls.Add(this.button_SrchSuppNo);
            this.ribbonBar1.Controls.Add(this.button_SrchCustNo);
            this.ribbonBar1.Controls.Add(this.txtSuppNo);
            this.ribbonBar1.Controls.Add(this.txtCustNo);
            this.ribbonBar1.Controls.Add(this.txtFromItemNo);
            this.ribbonBar1.Controls.Add(this.txtIntoItemNo);
            this.ribbonBar1.Controls.Add(this.txtGroupItemNo);
            this.ribbonBar1.Controls.Add(this.label4);
            this.ribbonBar1.Controls.Add(this.label3);
            this.ribbonBar1.Controls.Add(this.label55);
            this.ribbonBar1.Controls.Add(this.button_SrchCatNo);
            this.ribbonBar1.Controls.Add(this.button_SrchItemTo);
            this.ribbonBar1.Controls.Add(this.button_SrchItemFrom);
            this.ribbonBar1.Controls.Add(this.groupBox4);
            this.ribbonBar1.Controls.Add(this.txtIntoItemName);
            this.ribbonBar1.Controls.Add(this.txtFromItemName);
            this.ribbonBar1.Controls.Add(this.txtGroupItemName);
            this.ribbonBar1.Controls.Add(this.txtSuppName);
            this.ribbonBar1.Controls.Add(this.txtCustName);
            this.ribbonBar1.Controls.Add(this.groupBox2);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(539, 325);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 1102;
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
            this.ribbonBar1.ItemClick += new System.EventHandler(this.ribbonBar1_ItemClick);
            // 
            // ButOk
            // 
            this.ButOk.BackgroundImage = global::InvAcc.Properties.Resources.print;
            this.ButOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButOk.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButOk.Location = new System.Drawing.Point(313, 262);
            this.ButOk.Name = "ButOk";
            this.ButOk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButOk.Size = new System.Drawing.Size(206, 35);
            this.ButOk.TabIndex = 6748;
            this.ButOk.Text = "طباعه | Print";
            this.ButOk.UseVisualStyleBackColor = true;
            this.ButOk.Click += new System.EventHandler(this.ButOk_Click);
            this.ButOk.MouseLeave += new System.EventHandler(this.ButOk_MouseLeave);
            this.ButOk.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButOk_MouseMove);
            // 
            // ButExit
            // 
            this.ButExit.BackgroundImage = global::InvAcc.Properties.Resources.YALO2;
            this.ButExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButExit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButExit.Location = new System.Drawing.Point(146, 262);
            this.ButExit.Name = "ButExit";
            this.ButExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButExit.Size = new System.Drawing.Size(161, 35);
            this.ButExit.TabIndex = 6747;
            this.ButExit.Text = "خروج | ESC";
            this.ButExit.UseVisualStyleBackColor = true;
            this.ButExit.Click += new System.EventHandler(this.ButExit_Click);
            this.ButExit.MouseLeave += new System.EventHandler(this.ButExit_MouseLeave);
            this.ButExit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButExit_MouseMove);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(460, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 6746;
            this.label7.Text = "المنـــــــدوب :";
            // 
            // button_SrchLegNo
            // 
            this.button_SrchLegNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchLegNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchLegNo.Location = new System.Drawing.Point(347, 179);
            this.button_SrchLegNo.Name = "button_SrchLegNo";
            this.button_SrchLegNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchLegNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchLegNo.Symbol = "";
            this.button_SrchLegNo.SymbolSize = 12F;
            this.button_SrchLegNo.TabIndex = 6744;
            this.button_SrchLegNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchLegNo.Click += new System.EventHandler(this.button_SrchLegNo_Click);
            // 
            // txtLegNo
            // 
            this.txtLegNo.BackColor = System.Drawing.Color.White;
            this.txtLegNo.Location = new System.Drawing.Point(376, 179);
            this.txtLegNo.Name = "txtLegNo";
            this.txtLegNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtLegNo, false);
            this.txtLegNo.Size = new System.Drawing.Size(79, 20);
            this.txtLegNo.TabIndex = 6743;
            this.txtLegNo.Tag = "T_INVHED.MndNo ";
            this.txtLegNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLegName
            // 
            this.txtLegName.BackColor = System.Drawing.Color.Ivory;
            this.txtLegName.ForeColor = System.Drawing.Color.White;
            this.txtLegName.Location = new System.Drawing.Point(144, 179);
            this.txtLegName.Name = "txtLegName";
            this.txtLegName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtLegName, false);
            this.txtLegName.Size = new System.Drawing.Size(201, 20);
            this.txtLegName.TabIndex = 6745;
            this.txtLegName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(460, 208);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 6742;
            this.label10.Text = "الوحــــــدة :";
            // 
            // combobox_Unit
            // 
            this.combobox_Unit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combobox_Unit.DisplayMember = "Text";
            this.combobox_Unit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_Unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_Unit.FormattingEnabled = true;
            this.combobox_Unit.ItemHeight = 14;
            this.combobox_Unit.Location = new System.Drawing.Point(144, 204);
            this.combobox_Unit.Name = "combobox_Unit";
            this.combobox_Unit.Size = new System.Drawing.Size(311, 20);
            this.combobox_Unit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combobox_Unit.TabIndex = 6741;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(217)))), ((int)(((byte)(243)))));
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label22.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(1, 9);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(139, 42);
            this.label22.TabIndex = 6740;
            this.label22.Text = "الفواتــــير";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FlexType
            // 
            this.FlexType.BackColor = System.Drawing.Color.White;
            this.FlexType.ColumnInfo = resources.GetString("FlexType.ColumnInfo");
            this.FlexType.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FlexType.Location = new System.Drawing.Point(1, 53);
            this.FlexType.Name = "FlexType";
            this.FlexType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FlexType.Rows.Count = 13;
            this.FlexType.Rows.DefaultSize = 19;
            this.FlexType.Rows.Fixed = 0;
            this.FlexType.Size = new System.Drawing.Size(139, 251);
            this.FlexType.StyleInfo = resources.GetString("FlexType.StyleInfo");
            this.FlexType.TabIndex = 6739;
            this.FlexType.Tag = " T_INVHED.InvCashPay ";
            this.FlexType.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(460, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 6738;
            this.label6.Text = "المـــــــورد :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(460, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 6737;
            this.label5.Text = "العميــــــل :";
            // 
            // button_SrchSuppNo
            // 
            this.button_SrchSuppNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchSuppNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchSuppNo.Location = new System.Drawing.Point(347, 155);
            this.button_SrchSuppNo.Name = "button_SrchSuppNo";
            this.button_SrchSuppNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchSuppNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchSuppNo.Symbol = "";
            this.button_SrchSuppNo.SymbolSize = 12F;
            this.button_SrchSuppNo.TabIndex = 6735;
            this.button_SrchSuppNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchSuppNo.Click += new System.EventHandler(this.button_SrchSuppNo_Click);
            // 
            // button_SrchCustNo
            // 
            this.button_SrchCustNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchCustNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCustNo.Location = new System.Drawing.Point(347, 130);
            this.button_SrchCustNo.Name = "button_SrchCustNo";
            this.button_SrchCustNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchCustNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCustNo.Symbol = "";
            this.button_SrchCustNo.SymbolSize = 12F;
            this.button_SrchCustNo.TabIndex = 6732;
            this.button_SrchCustNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCustNo.Click += new System.EventHandler(this.button_SrchCustNo_Click);
            // 
            // txtSuppNo
            // 
            this.txtSuppNo.BackColor = System.Drawing.Color.White;
            this.txtSuppNo.Location = new System.Drawing.Point(376, 155);
            this.txtSuppNo.Name = "txtSuppNo";
            this.txtSuppNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtSuppNo, false);
            this.txtSuppNo.Size = new System.Drawing.Size(79, 20);
            this.txtSuppNo.TabIndex = 6734;
            this.txtSuppNo.Tag = " T_INVHED.CusVenNo ";
            this.txtSuppNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCustNo
            // 
            this.txtCustNo.BackColor = System.Drawing.Color.White;
            this.txtCustNo.Location = new System.Drawing.Point(376, 130);
            this.txtCustNo.Name = "txtCustNo";
            this.txtCustNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtCustNo, false);
            this.txtCustNo.Size = new System.Drawing.Size(79, 20);
            this.txtCustNo.TabIndex = 6731;
            this.txtCustNo.Tag = " T_INVHED.CusVenNo ";
            this.txtCustNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFromItemNo
            // 
            this.txtFromItemNo.BackColor = System.Drawing.Color.White;
            this.txtFromItemNo.Location = new System.Drawing.Point(376, 54);
            this.txtFromItemNo.Name = "txtFromItemNo";
            this.txtFromItemNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtFromItemNo, false);
            this.txtFromItemNo.Size = new System.Drawing.Size(79, 20);
            this.txtFromItemNo.TabIndex = 3;
            this.txtFromItemNo.Tag = " T_Items.Itm_No ";
            this.txtFromItemNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFromItemNo.Click += new System.EventHandler(this.txtFromItemNo_Click);
            // 
            // txtIntoItemNo
            // 
            this.txtIntoItemNo.BackColor = System.Drawing.Color.White;
            this.txtIntoItemNo.Location = new System.Drawing.Point(376, 79);
            this.txtIntoItemNo.Name = "txtIntoItemNo";
            this.txtIntoItemNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtIntoItemNo, false);
            this.txtIntoItemNo.Size = new System.Drawing.Size(79, 20);
            this.txtIntoItemNo.TabIndex = 6;
            this.txtIntoItemNo.Tag = " T_Items.Itm_No ";
            this.txtIntoItemNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIntoItemNo.Click += new System.EventHandler(this.txtIntoItemNo_Click);
            // 
            // txtGroupItemNo
            // 
            this.txtGroupItemNo.BackColor = System.Drawing.Color.White;
            this.txtGroupItemNo.Location = new System.Drawing.Point(376, 105);
            this.txtGroupItemNo.Name = "txtGroupItemNo";
            this.txtGroupItemNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtGroupItemNo, false);
            this.txtGroupItemNo.Size = new System.Drawing.Size(79, 20);
            this.txtGroupItemNo.TabIndex = 9;
            this.txtGroupItemNo.Tag = "  T_CATEGORY.CAT_ID ";
            this.txtGroupItemNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGroupItemNo.Click += new System.EventHandler(this.txtGroupItemNo_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(460, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 1119;
            this.label4.Text = "إلى صنف :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(460, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 1118;
            this.label3.Text = "من صنف :";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.BackColor = System.Drawing.Color.Transparent;
            this.label55.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label55.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label55.Location = new System.Drawing.Point(460, 109);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(56, 13);
            this.label55.TabIndex = 1117;
            this.label55.Text = "التصنيف :";
            // 
            // button_SrchCatNo
            // 
            this.button_SrchCatNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchCatNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCatNo.Location = new System.Drawing.Point(347, 105);
            this.button_SrchCatNo.Name = "button_SrchCatNo";
            this.button_SrchCatNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchCatNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCatNo.Symbol = "";
            this.button_SrchCatNo.SymbolSize = 12F;
            this.button_SrchCatNo.TabIndex = 10;
            this.button_SrchCatNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCatNo.Click += new System.EventHandler(this.button_SrchCatNo_Click);
            // 
            // button_SrchItemTo
            // 
            this.button_SrchItemTo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchItemTo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchItemTo.Location = new System.Drawing.Point(347, 79);
            this.button_SrchItemTo.Name = "button_SrchItemTo";
            this.button_SrchItemTo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchItemTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchItemTo.Symbol = "";
            this.button_SrchItemTo.SymbolSize = 12F;
            this.button_SrchItemTo.TabIndex = 7;
            this.button_SrchItemTo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchItemTo.Click += new System.EventHandler(this.button_SrchItemTo_Click);
            // 
            // button_SrchItemFrom
            // 
            this.button_SrchItemFrom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchItemFrom.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchItemFrom.Location = new System.Drawing.Point(347, 54);
            this.button_SrchItemFrom.Name = "button_SrchItemFrom";
            this.button_SrchItemFrom.Size = new System.Drawing.Size(26, 20);
            this.button_SrchItemFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchItemFrom.Symbol = "";
            this.button_SrchItemFrom.SymbolSize = 12F;
            this.button_SrchItemFrom.TabIndex = 4;
            this.button_SrchItemFrom.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchItemFrom.Click += new System.EventHandler(this.button_SrchItemFrom_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.txtMToDate);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtMFromDate);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox4.Location = new System.Drawing.Point(144, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(391, 48);
            this.groupBox4.TabIndex = 1109;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "حسب التاريخ";
            // 
            // txtMToDate
            // 
            this.txtMToDate.Location = new System.Drawing.Point(23, 19);
            this.txtMToDate.Mask = "0000/00/00";
            this.txtMToDate.Name = "txtMToDate";
            this.txtMToDate.Size = new System.Drawing.Size(108, 21);
            this.txtMToDate.TabIndex = 2;
            this.txtMToDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMToDate.Click += new System.EventHandler(this.txtMToDate_Click);
            this.txtMToDate.Leave += new System.EventHandler(this.txtMToDate_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(322, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 860;
            this.label1.Text = "مـــــن :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(137, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 861;
            this.label2.Text = "إلـــــى :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMFromDate
            // 
            this.txtMFromDate.Location = new System.Drawing.Point(208, 19);
            this.txtMFromDate.Mask = "0000/00/00";
            this.txtMFromDate.Name = "txtMFromDate";
            this.txtMFromDate.Size = new System.Drawing.Size(108, 21);
            this.txtMFromDate.TabIndex = 1;
            this.txtMFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMFromDate.Click += new System.EventHandler(this.txtMFromDate_Click);
            this.txtMFromDate.Leave += new System.EventHandler(this.txtMFromDate_Leave);
            // 
            // txtIntoItemName
            // 
            this.txtIntoItemName.BackColor = System.Drawing.Color.Ivory;
            this.txtIntoItemName.ForeColor = System.Drawing.Color.White;
            this.txtIntoItemName.Location = new System.Drawing.Point(144, 79);
            this.txtIntoItemName.Name = "txtIntoItemName";
            this.txtIntoItemName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtIntoItemName, false);
            this.txtIntoItemName.Size = new System.Drawing.Size(201, 20);
            this.txtIntoItemName.TabIndex = 8;
            this.txtIntoItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIntoItemName.Click += new System.EventHandler(this.txtIntoItemName_Click);
            // 
            // txtFromItemName
            // 
            this.txtFromItemName.BackColor = System.Drawing.Color.Ivory;
            this.txtFromItemName.ForeColor = System.Drawing.Color.White;
            this.txtFromItemName.Location = new System.Drawing.Point(144, 54);
            this.txtFromItemName.Name = "txtFromItemName";
            this.txtFromItemName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtFromItemName, false);
            this.txtFromItemName.Size = new System.Drawing.Size(201, 20);
            this.txtFromItemName.TabIndex = 5;
            this.txtFromItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFromItemName.Click += new System.EventHandler(this.txtFromItemName_Click);
            // 
            // txtGroupItemName
            // 
            this.txtGroupItemName.BackColor = System.Drawing.Color.Ivory;
            this.txtGroupItemName.ForeColor = System.Drawing.Color.White;
            this.txtGroupItemName.Location = new System.Drawing.Point(144, 105);
            this.txtGroupItemName.Name = "txtGroupItemName";
            this.txtGroupItemName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtGroupItemName, false);
            this.txtGroupItemName.Size = new System.Drawing.Size(201, 20);
            this.txtGroupItemName.TabIndex = 11;
            this.txtGroupItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGroupItemName.Click += new System.EventHandler(this.txtGroupItemName_Click);
            this.txtGroupItemName.TextChanged += new System.EventHandler(this.txtGroupItemName_TextChanged);
            // 
            // txtSuppName
            // 
            this.txtSuppName.BackColor = System.Drawing.Color.Ivory;
            this.txtSuppName.ForeColor = System.Drawing.Color.White;
            this.txtSuppName.Location = new System.Drawing.Point(144, 155);
            this.txtSuppName.Name = "txtSuppName";
            this.txtSuppName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtSuppName, false);
            this.txtSuppName.Size = new System.Drawing.Size(201, 20);
            this.txtSuppName.TabIndex = 6736;
            this.txtSuppName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCustName
            // 
            this.txtCustName.BackColor = System.Drawing.Color.Ivory;
            this.txtCustName.ForeColor = System.Drawing.Color.White;
            this.txtCustName.Location = new System.Drawing.Point(144, 130);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtCustName, false);
            this.txtCustName.Size = new System.Drawing.Size(201, 20);
            this.txtCustName.TabIndex = 6733;
            this.txtCustName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.RButShort);
            this.groupBox2.Controls.Add(this.RButDetails);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(144, 220);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(311, 41);
            this.groupBox2.TabIndex = 6730;
            this.groupBox2.TabStop = false;
            // 
            // RButShort
            // 
            this.RButShort.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.RButShort.ForeColor = System.Drawing.Color.SteelBlue;
            this.RButShort.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RButShort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RButShort.Location = new System.Drawing.Point(45, 15);
            this.RButShort.Name = "RButShort";
            this.RButShort.Size = new System.Drawing.Size(75, 20);
            this.RButShort.TabIndex = 1008;
            this.RButShort.Text = "مختصر";
            this.RButShort.UseVisualStyleBackColor = true;
            this.RButShort.CheckedChanged += new System.EventHandler(this.RButShort_CheckedChanged);
            // 
            // RButDetails
            // 
            this.RButDetails.Checked = true;
            this.RButDetails.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.RButDetails.ForeColor = System.Drawing.Color.SteelBlue;
            this.RButDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RButDetails.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RButDetails.Location = new System.Drawing.Point(185, 15);
            this.RButDetails.Name = "RButDetails";
            this.RButDetails.Size = new System.Drawing.Size(75, 20);
            this.RButDetails.TabIndex = 1007;
            this.RButDetails.TabStop = true;
            this.RButDetails.Text = "تفصيلي";
            this.RButDetails.UseVisualStyleBackColor = true;
            // 
            // netResize1
            // 
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            // 
            // FRItemsMovementPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 325);
            this.Controls.Add(this.PanelSpecialContainer);
            this.Icon = global::InvAcc.Properties.Resources.favicon;
            this.KeyPreview = true;
            this.Name = "FRItemsMovementPrint";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FRItemsMovementPrint_Load);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.PanelSpecialContainer.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            this.ribbonBar1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlexType)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);

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
