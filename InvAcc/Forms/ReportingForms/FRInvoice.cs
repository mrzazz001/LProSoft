using C1.Win.C1FlexGrid;
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
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FRInvoice : Form
    { void avs(int arln)

{ 
  checkBox_CustomerNam.Text=   (arln == 0 ? "  إظهار العميل / المورد  " : "  Show customer / supplier") ; label10.Text=   (arln == 0 ? "  ترتيب حسب :  " : "  sort by :") ; checkBox_Defalut.Text=   (arln == 0 ? "  الإفتــــراضي  " : "  default") ; checkBox_ItemComm.Text=   (arln == 0 ? "  إظهار عمـــولات الصنف  " : "  Show item commissions") ; checkBox_Note.Text=   (arln == 0 ? "  إظهار عمود الملاحظات  " : "  Show notes column") ; label9.Text=   (arln == 0 ? "  المستخـــدم :  " : "  User:") ; label7.Text=   (arln == 0 ? "  المنـــــــدوب :  " : "  Delegate:") ; label6.Text=   (arln == 0 ? "  المــــــــــورد :  " : "  Supplier:") ; label5.Text=   (arln == 0 ? "  العميـــــــــل :  " : "  Customer:") ; groupBox3.Text=   (arln == 0 ? "  حسب رقم الفاتورة  " : "  According to the invoice number") ; label1.Text=   (arln == 0 ? "  مـــــن :  " : "  from:") ; label2.Text=   (arln == 0 ? "  إلـــــى :  " : "  to:") ; groupBox_Date.Text=   (arln == 0 ? "  حسب تاريخ الفاتورة  " : "  According to the invoice date") ; label3.Text=   (arln == 0 ? "  مـــــن :  " : "  from:") ; label4.Text=   (arln == 0 ? "  إلـــــى :  " : "  to:") ; label8.Text=   (arln == 0 ? "  مركز التكلفة :  " : "  cost center:") ; RButLandscape.Text=   (arln == 0 ? "  عرضي  " : "  accidental") ; RButPortrait.Text=   (arln == 0 ? "  طولي  " : "  linear") ; radioButton_Delivery.Text=   (arln == 0 ? "  طلب توصيل  " : "  delivery request") ; radioButton_Out.Text=   (arln == 0 ? "  سفـــــري  " : "  my travel") ; radioButton_In.Text=   (arln == 0 ? "  محلـــيً  " : "  local") ; radioButton_Tax1.Text=   (arln == 0 ? "  الكـــل  " : "  the whole") ; radioButton_Tax2.Text=   (arln == 0 ? "  بدون الضريبة  " : "  without tax") ; radioButton_Tax0.Text=   (arln == 0 ? "  بالضريبة  " : "  with tax") ; radioButton_Del1.Text=   (arln == 0 ? "  الكـــل  " : "  the whole") ; radioButton_Del2.Text=   (arln == 0 ? "  المحذوفة فقط  " : "  only deleted") ; radioButton_Del0.Text=   (arln == 0 ? "  الغير محذوفة  " : "  not deleted") ; radioButton_ِReturn1.Text=   (arln == 0 ? "  الكـــل  " : "  the whole") ; radioButton_ِReturn2.Text=   (arln == 0 ? "  المرتجعة فقط  " : "  Returns only") ; radioButton_ِReturn0.Text=   (arln == 0 ? "  الغير مرتجعة  " : "  non-refundable") ; checkBox_DatePay.Text=   (arln == 0 ? "  بتاريخ الاستحقاق  " : "  Due date") ;}
        private void langloads(object sender, EventArgs e)
        {
             
        }
   
       // private IContainer components = null;
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
        }
        protected override void OnShown(EventArgs e)
        {
            // Do your work here...
            base.OnShown(e);
        }
        private void FrmInvSale_SizeChanged(object sender, EventArgs e)
        {
            netResize1.Refresh();
        }
        private Panel PanelSpecialContainer;
        public Softgroup.NetResize.NetResize netResize1;
        private RibbonBar ribbonBar1;
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
        private C1FlexGrid FlexType;
        private ComboBoxEx CmbInvType;
        private GroupBox CmbDeleted;
        private RadioButton radioButton_Del1;
        private RadioButton radioButton_Del2;
        private RadioButton radioButton_Del0;
        private GroupBox CmbReturn;
        private RadioButton radioButton_ِReturn1;
        private RadioButton radioButton_ِReturn2;
        private RadioButton radioButton_ِReturn0;
        private GroupBox groupBox2;
        private RadioButton RButLandscape;
        private RadioButton RButPortrait;
        private SwitchButton RButShort;
        private CheckBoxX checkBox_ItemComm;
        private CheckBoxX checkBox_Note;
        private CheckBoxX checkBox_Defalut;
        public TextBox txtUserName;
        public TextBox txtUserNo;
        public SwitchButton RButShort2;
        public SwitchButton switchButton_CalclatTax;
        private CheckBox checkBox_DatePay;
        private Label label10;
        private ComboBoxEx combobox_SortTyp;
        private GroupBox groupBox_OrderTyp;
        private Label labelFooter;
        public SwitchButton switchButton_OrderTyp;
        private CheckBoxX radioButton_In;
        private CheckBoxX radioButton_Delivery;
        private CheckBoxX radioButton_Out;
        private GroupBox groupBox1;
        private RadioButton radioButton_Tax1;
        private RadioButton radioButton_Tax2;
        private RadioButton radioButton_Tax0;
        private ComboBoxEx combobox_RepType;
        private CheckBoxX checkBox_CustomerNam;
        private int LangArEn = 0;
        private T_User _User = new T_User();
        public Dictionary<string, FRInvoice.ColumnDictinary> columns_Names_visible = new Dictionary<string, FRInvoice.ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private int vType = 0;
        private C1.Win.C1Input.C1Button ButOk;
        private C1.Win.C1Input.C1Button ButExit;
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
        private Stock_DataDataContext db
        {
            get
            {
                if (this.dbInstance == null)
                {
                    this.dbInstance = new Stock_DataDataContext(VarGeneral.BranchCS);
                }
                return this.dbInstance;
            }
        }
        private Rate_DataDataContext dbc
        {
            get
            {
                if (this.dbInstanceRate == null)
                {
                    this.dbInstanceRate = new Rate_DataDataContext(VarGeneral.BranchRt);
                }
                return this.dbInstanceRate;
            }
        }
        public FRInvoice(int vTp, int langNow)
        {
            this.InitializeComponent();this.Load += langloads;
            this._User = this.dbc.StockUser(VarGeneral.UserNumber);
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
            this.listInvSetting = (
                from t in this.db.T_INVSETTINGs
                where t.InvID == 1 || t.InvID == 2 || t.InvID == 3 || t.InvID == 4 || t.InvID == 5 || t.InvID == 6 || t.InvID == 7 || t.InvID == 8 || t.InvID == 9 || t.InvID == 10 || t.InvID == 14 || t.InvID == 17 || t.InvID == 20 || ((VarGeneral.SSSLev == "R") || (VarGeneral.SSSLev == "H") || (VarGeneral.SSSLev == "C") ? t.InvID == 21 : t.InvID == 1)
                select t).ToList<T_INVSETTING>();
            this.CmbInvType.Items.Clear();
            if (langNow != 0)
            {
                this.CmbInvType.DataSource = this.listInvSetting;
                this.CmbInvType.DisplayMember = "InvNamE";
                this.CmbInvType.ValueMember = "InvID";
            }
            else
            {
                this.CmbInvType.DataSource = this.listInvSetting;
                this.CmbInvType.DisplayMember = "InvNamA";
                this.CmbInvType.ValueMember = "InvID";
            }
            this.vType = vTp;
            if (vTp != 0)
            {
                this.CmbInvType.SelectedValue = vTp;
            }
            else
            {
                this.CmbInvType.SelectedValue = 1;
            }
            if ((VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F" || VarGeneral.SSSLev == "S" ? false : !(VarGeneral.SSSLev == "C")))
            {
                this.label8.Visible = true;
                this.txtCostNo.Visible = true;
                this.button_SrchCostNo.Visible = true;
                this.txtCostName.Visible = true;
            }
            else
            {
                this.label8.Visible = false;
                this.txtCostNo.Visible = false;
                this.button_SrchCostNo.Visible = false;
                this.txtCostName.Visible = false;
            }
            try
            {
                if ((VarGeneral.SSSLev == "B" ? true : VarGeneral.SSSLev == "F"))
                {
                    RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", true);
                    try
                    {
                        if (string.IsNullOrEmpty(hKey.GetValue("vCoCe").ToString()))
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
                    if (long.Parse(hKey.GetValue("vCoCe").ToString()) != (long)1)
                    {
                        this.label8.Visible = false;
                        this.txtCostNo.Visible = false;
                        this.button_SrchCostNo.Visible = false;
                        this.txtCostName.Visible = false;
                    }
                    else
                    {
                        this.label8.Visible = true;
                        this.txtCostNo.Visible = true;
                        this.button_SrchCostNo.Visible = true;
                        this.txtCostName.Visible = true;
                    }
                }
            }
            catch
            {
            }
            this.radioButton_Del2.Enabled = VarGeneral.TString.ChkStatShow(VarGeneral.UserSetStr, 51);
        }
        private string BuildRuleList()
        {
            int iiCnt;
            object obj;
            object[] tag;
            string str;
            bool flag;
            HijriGregDates dateFormatter = new HijriGregDates();
            if (this.combobox_RepType.SelectedIndex == 1)
            {
                str = " Where (T_INVHED.InvTyp = 1 or T_INVHED.InvTyp = 3) ";
            }
            else
            {
                str = (this.combobox_RepType.SelectedIndex == 2 ? " Where (T_INVHED.InvTyp = 1 or T_INVHED.InvTyp = 2) " : string.Concat(" Where T_INVHED.InvTyp = ", this.CmbInvType.SelectedValue.ToString()));
            }
            string Rule = str;
            if (!string.IsNullOrEmpty(this.txtMFromNo.Text))
            {
                obj = Rule;
                tag = new object[] { obj, " and ", this.txtMFromNo.Tag, " >= ", this.txtMFromNo.Text.Trim() };
                Rule = string.Concat(tag);
            }
            if (!string.IsNullOrEmpty(this.txtMIntoNo.Text))
            {
                obj = Rule;
                tag = new object[] { obj, " and ", this.txtMIntoNo.Tag, " <= ", this.txtMIntoNo.Text.Trim() };
                Rule = string.Concat(tag);
            }
            if (!string.IsNullOrEmpty(this.txtCostNo.Text))
            {
                obj = Rule;
                tag = new object[] { obj, " and ", this.txtCostNo.Tag, " = ", this.txtCostNo.Text.Trim() };
                Rule = string.Concat(tag);
            }
            if (!string.IsNullOrEmpty(this.txtCustNo.Text))
            {
                obj = Rule;
                tag = new object[] { obj, " and ", this.txtCustNo.Tag, " = '", this.txtCustNo.Text.Trim(), "'" };
                Rule = string.Concat(tag);
            }
            if (!string.IsNullOrEmpty(this.txtSuppNo.Text))
            {
                obj = Rule;
                tag = new object[] { obj, " and ", this.txtSuppNo.Tag, " = '", this.txtSuppNo.Text.Trim(), "'" };
                Rule = string.Concat(tag);
            }
            if (!string.IsNullOrEmpty(this.txtLegNo.Text))
            {
                obj = Rule;
                tag = new object[] { obj, " and ", this.txtLegNo.Tag, " = ", this.txtLegNo.Text.Trim() };
                Rule = string.Concat(tag);
            }
            if (!string.IsNullOrEmpty(this.txtUserNo.Text))
            {
                if ((!File.Exists(string.Concat(Application.StartupPath, "\\Script\\SecriptInv.dll")) ? true : VarGeneral.InvType != 1))
                {
                    obj = Rule;
                    tag = new object[] { obj, " and ", this.txtUserNo.Tag, " = '", this.txtUserNo.Text.Trim(), "'" };
                    Rule = string.Concat(tag);
                }
                else
                {
                    Rule = string.Concat(Rule, " and  T_INVHED.UserNew  = '", this.txtUserNo.Text.Trim(), "'");
                }
            }
            if ((!VarGeneral.CheckDate(this.txtMFromDate.Text) ? false : this.txtMFromDate.Text.Length == 10))
            {
                if (!this.checkBox_DatePay.Checked)
                {
                    Rule = (int.Parse(this.txtMFromDate.Text.Substring(0, 4)) >= 1800 ? string.Concat(Rule, " and  T_INVHED.GDat  >= '", dateFormatter.FormatGreg(this.txtMFromDate.Text, "yyyy/MM/dd"), "'") : string.Concat(Rule, " and  T_INVHED.HDat  >= '", dateFormatter.FormatHijri(this.txtMFromDate.Text, "yyyy/MM/dd"), "'"));
                }
                else
                {
                    Rule = string.Concat(Rule, " and  T_INVHED.EstDat  >= '", dateFormatter.FormatHijri(this.txtMFromDate.Text, "yyyy/MM/dd"), "'");
                }
            }
            if ((!VarGeneral.CheckDate(this.txtMToDate.Text) ? false : this.txtMToDate.Text.Length == 10))
            {
                if (!this.checkBox_DatePay.Checked)
                {
                    Rule = (int.Parse(this.txtMToDate.Text.Substring(0, 4)) >= 1800 ? string.Concat(Rule, " and  T_INVHED.GDat  <= '", dateFormatter.FormatGreg(this.txtMToDate.Text, "yyyy/MM/dd"), "'") : string.Concat(Rule, " and  T_INVHED.HDat  <= '", dateFormatter.FormatHijri(this.txtMToDate.Text, "yyyy/MM/dd"), "'"));
                }
                else
                {
                    Rule = string.Concat(Rule, " and  T_INVHED.EstDat  <= '", dateFormatter.FormatHijri(this.txtMToDate.Text, "yyyy/MM/dd"), "'");
                }
            }
            if (this.radioButton_Del0.Checked)
            {
                obj = Rule;
                tag = new object[] { obj, " and ", this.CmbDeleted.Tag, " != 1 " };
                Rule = string.Concat(tag);
            }
            else if (this.radioButton_Del2.Checked)
            {
                obj = Rule;
                tag = new object[] { obj, " and ", this.CmbDeleted.Tag, " = 1 " };
                Rule = string.Concat(tag);
            }
            if (this.radioButton_ِReturn0.Checked)
            {
                obj = Rule;
                tag = new object[] { obj, " and ", this.CmbReturn.Tag, " != 1 " };
                Rule = string.Concat(tag);
            }
            else if (this.radioButton_ِReturn2.Checked)
            {
                obj = Rule;
                tag = new object[] { obj, " and ", this.CmbReturn.Tag, " = 1 " };
                Rule = string.Concat(tag);
            }
            string RuleInvType = ""; int rc = FlexType.Rows.Count; if (rc == 3) rc--;
            for (iiCnt = 0; iiCnt < rc; iiCnt++)
            {
                if ((bool)this.FlexType.GetData(iiCnt, 0))
                {
                    if (!string.IsNullOrEmpty(RuleInvType))
                    {
                        RuleInvType = string.Concat(RuleInvType, " or ");
                    }
                    obj = RuleInvType;
                    tag = new object[] { obj, this.FlexType.Tag, "  = ", iiCnt };
                    RuleInvType = string.Concat(tag);
                }
           
            }
            if (FlexType.Rows.Count == 3)
            {
            if(  !string.IsNullOrEmpty(RuleInvType))
                    RuleInvType = "(" + RuleInvType + ")";
                if ((bool)this.FlexType.GetData(2, 0))
                {
                    if (string.IsNullOrEmpty(RuleInvType))
                    {
                        obj = RuleInvType;
                        tag = new object[] { obj, this.FlexType.Tag, "  = ", iiCnt };
                        RuleInvType = string.Concat(tag);
                    }

                    obj = RuleInvType;
                    tag = new object[] { obj, " or (T_INVHED.InvCash ='  شبكـــة  ' or T_INVHED.InvCash = 'الشبكة' or T_INVHED.InvCash = 'شبكـــة' or T_INVHED.InvCash = '  شبكـــة  ' )" };
                    RuleInvType = string.Concat(tag);
                }
                else
                {
                    if (string.IsNullOrEmpty(RuleInvType))
                    {
                        obj = RuleInvType;
                        tag = new object[] { obj, this.FlexType.Tag, "  = ", iiCnt };
                        RuleInvType = string.Concat(tag);
                    }

                    obj = RuleInvType;
                    tag = new object[] { obj, " and (T_INVHED.InvCash !='  شبكـــة  ' and T_INVHED.InvCash != 'الشبكة' and T_INVHED.InvCash != 'شبكـــة' and T_INVHED.InvCash != '  شبكـــة  ' )" };
                    RuleInvType = string.Concat(tag);
                }

            }

            if (!string.IsNullOrEmpty(RuleInvType))
            {
                Rule = string.Concat(Rule, " and (", RuleInvType, ")");
            }
            if (VarGeneral.InvTyp == 21)
            {
                Rule = string.Concat(Rule, " and (PaymentOrderTyp = 0 and RoomNo != '' )");
            }
            if (this.checkBox_DatePay.Checked)
            {
                Rule = string.Concat(Rule, " and ( T_INVHED.EstDat != '' )");
            }
            if (!this.switchButton_OrderTyp.Value)
            {
                flag = true;
            }
            else
            {
                flag = (this.radioButton_In.Checked || this.radioButton_Out.Checked ? false : !this.radioButton_Delivery.Checked);
            }
            if (!flag)
            {
                RuleInvType = "";
                for (iiCnt = 0; iiCnt < 3; iiCnt++)
                {
                    if ((iiCnt != 0 ? false : this.radioButton_In.Checked))
                    {
                        if (!string.IsNullOrEmpty(RuleInvType))
                        {
                            RuleInvType = string.Concat(RuleInvType, " or ");
                        }
                        RuleInvType = string.Concat(RuleInvType, " OrderTyp = ", iiCnt);
                    }
                    if ((iiCnt != 1 ? false : this.radioButton_Out.Checked))
                    {
                        if (!string.IsNullOrEmpty(RuleInvType))
                        {
                            RuleInvType = string.Concat(RuleInvType, " or ");
                        }
                        RuleInvType = string.Concat(RuleInvType, " OrderTyp = ", iiCnt);
                    }
                    if ((iiCnt != 2 ? false : this.radioButton_Delivery.Checked))
                    {
                        if (!string.IsNullOrEmpty(RuleInvType))
                        {
                            RuleInvType = string.Concat(RuleInvType, " or ");
                        }
                        RuleInvType = string.Concat(RuleInvType, " OrderTyp = ", iiCnt);
                    }
                }
                if (!string.IsNullOrEmpty(RuleInvType))
                {
                    Rule = string.Concat(Rule, " and (", RuleInvType, ") and T_INVHED.InvId is not null ");
                }
            }
            if (!this.radioButton_Tax1.Checked)
            {
                Rule = (!this.radioButton_Tax0.Checked ? string.Concat(Rule, " and T_INVHED.InvAddTax <= 0 ") : string.Concat(Rule, " and T_INVHED.InvAddTax > 0 "));
            }
            return Rule;
        }
        private void ButExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            string quryEdit;
            string[] strArrays;
            object[] text;
            double? amount;
            bool flag;
            object obj;
            string str;
            double value;
            object obj1;
            object obj2;
            object obj3;
            try
            {
                if (!this.switchButton_OrderTyp.Value)
                {
                    flag = true;
                }
                else
                {
                    flag = (this.radioButton_In.Checked || this.radioButton_Out.Checked ? true : this.radioButton_Delivery.Checked);
                }
                if (flag)
                {
                    if (!(this.Text == "تقرير فاتورة مبيعات" ? false : !(this.Text == "Sales Invoice Report")))
                    {
                        VarGeneral.InvType = 1;
                    }
                    else if (!(this.Text == "تقرير فاتورة مشتريات" ? false : !(this.Text == "Purchase Invoice Report")))
                    {
                        VarGeneral.InvType = 2;
                    }
                    else if (!(this.Text == "تقرير مرتجع مبيعات" ? false : !(this.Text == "Sales Return Report")))
                    {
                        VarGeneral.InvType = 3;
                    }
                    else if (!(this.Text == "تقرير مرتجع مشتريات" ? false : !(this.Text == "Purchase Return Report")))
                    {
                        VarGeneral.InvType = 4;
                    }
                    else if (!(this.Text == "تقرير فاتورة إدخال بضاعة" ? false : !(this.Text == "Transfer In Report")))
                    {
                        VarGeneral.InvType = 5;
                    }
                    else if (!(this.Text == "تقرير فاتورة إخراج بضاعة" ? false : !(this.Text == "Transfer Out Report")))
                    {
                        VarGeneral.InvType = 6;
                    }
                    else if (!(this.Text == "تقرير عرض سعر للعملاء" ? false : !(this.Text == "Customer Qutation Report")))
                    {
                        VarGeneral.InvType = 7;
                    }
                    else if (!(this.Text == "تقرير عرض سعر للموردين" ? false : !(this.Text == "Supplier Qutation Report")))
                    {
                        VarGeneral.InvType = 8;
                    }
                    else if (!(this.Text == "تقرير طلب شراء" ? false : !(this.Text == "Purchase Order Report")))
                    {
                        VarGeneral.InvType = 9;
                    }
                    else if (!(this.Text == "تقرير فاتورة تسوية البضاعة" ? false : !(this.Text == "Stock Adjustment Report")))
                    {
                        VarGeneral.InvType = 10;
                    }
                    else if (!(this.Text == "تقرير بضاعة اول المدة" ? false : !(this.Text == "Open Quantities Report")))
                    {
                        VarGeneral.InvType = 14;
                    }
                    else if (!(this.Text == "تقرير فاتورة صرف بضاعة" ? false : !(this.Text == "Payment Order Report")))
                    {
                        VarGeneral.InvType = 17;
                    }
                    else if (!(this.Text == "تقرير مرتجع صرف بضاعة" ? false : !(this.Text == "Payment Order Return Report")))
                    {
                        VarGeneral.InvType = 20;
                    }
                    else if ((this.Text == "تقرير الطلبات المحلية" ? true : this.Text == "Local Order Report"))
                    {
                        VarGeneral.InvType = 21;
                    }
                    if ((this.Text == "تقرير عرض سعر للطلاب" ? true : this.Text == "Students Qutation Report"))
                    {
                        VarGeneral.InvType = 7;
                    }
                    if ((this.Text == "تقرير فواتير عرض سعر السائقين" ? true : this.Text == "Drivers Qutation Reports"))
                    {
                        VarGeneral.InvType = 7;
                    }
                    if ((this.Text == "تقرير فواتير الخدمة" ? true : this.Text == "Service Reports"))
                    {
                        VarGeneral.InvType = 1;
                    }
                    if ((this.Text == "تقرير أمر تحميل" ? true : this.Text == "Order"))
                    {
                        VarGeneral.InvType = 8;
                    }
                    if (!(this.Text == "تقرير فواتير حجز وتأجير" ? false : !(this.Text == "Issuance of a Custody")))
                    {
                        VarGeneral.InvType = 17;
                    }
                    else if ((this.Text == "تقرير فواتير إرجاع العهد" ? true : this.Text == "Return of custody"))
                    {
                        VarGeneral.InvType = 20;
                    }
                    if ((this.Text == "تقرير إصدار الدعوات" ? true : this.Text == "Invitation Issuse"))
                    {
                        VarGeneral.InvType = 8;
                    }
                    if (!(this.Text == "تقرير فواتير إصدار العهد" ? false : !(this.Text == "Renting and Booking Reports")))
                    {
                        VarGeneral.InvType = 1;
                    }
                    else if ((this.Text == "تقرير فواتير إلغاء حجز وتأجير" ? true : this.Text == "Renting and Booking Cancel Reports"))
                    {
                        VarGeneral.InvType = 3;
                    }
                    VarGeneral.itmDes = "";
                    RepShow _RepShow = new RepShow()
                    {
                        Tables = " T_INVHED Left Join  T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  Left Join T_Curency On T_INVHED.CurTyp = T_Curency.Curency_ID Left Join T_CstTbl On T_INVHED.InvCstNo = T_CstTbl.Cst_ID Left Join T_Mndob on T_INVHED.MndNo = T_Mndob.Mnd_Id Left Join T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID"
                    };
                    string Fields = "";
                    if (VarGeneral.InvTyp == 21)
                    {
                        Fields = (this.LangArEn != 0 ? " T_INVHED.InvNo, T_INVSETTING.InvNamA as InvTypNm,T_INVHED.GDat,T_INVHED.HDat,T_INVHED.RoomNo as InvCash ,T_INVHED.RoomPerson as CostCenteNm, case when AdminLock = 0 then 'Approval' else 'Not Apporval' end as MndNm,(select Eng_Des from T_Waiter where waiter_ID = (select waiterNo from T_Rooms where ID = T_INVHED.RoomNo)) as GadeNo,T_INVHED.CusVenNo,T_INVHED.CusVenNm,T_INVHED.Remark,T_SYSSETTING.LogImg,T_SYSSETTING.Calendr ,T_INVHED.SalsManNo,((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints,'' as UsrNamA,''as UsrNamE" : " T_INVHED.InvNo, T_INVSETTING.InvNamA as InvTypNm,T_INVHED.GDat,T_INVHED.HDat,T_INVHED.RoomNo as InvCash ,T_INVHED.RoomPerson as CostCenteNm, case when AdminLock = 0 then 'معتمد' else 'غير معتمد' end as MndNm,(select Arb_Des from T_Waiter where waiter_ID = (select waiterNo from T_Rooms where ID = T_INVHED.RoomNo)) as GadeNo,T_INVHED.CusVenNo,T_INVHED.CusVenNm,T_INVHED.Remark,T_SYSSETTING.LogImg,T_SYSSETTING.Calendr ,T_INVHED.SalsManNo,((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints,'' as UsrNamA,''as UsrNamE");
                    }
                    else if (this.combobox_RepType.SelectedIndex == 1)
                    {
                        quryEdit = this.BuildRuleList();
                        quryEdit = quryEdit.Replace("Where (T_INVHED.InvTyp = 1 or T_INVHED.InvTyp = 3)", " ");
                        quryEdit = quryEdit.Replace("T_INVHED.", "x.");
                        if (this.LangArEn != 0)
                        {
                            strArrays = new string[] { " T_INVSETTING.InvNamE as InvTypNm,T_INVHED.InvTyp,sum(T_INVHED.InvNetLocCur) as InvNetLocCur,(case when (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = T_INVHED.InvTyp and x.IsTaxUse = 1 ", quryEdit, " ) > 0 then (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = T_INVHED.InvTyp and x.IsTaxUse = 1 ", quryEdit, " ) else 0 end) as InvAddTax,'", this.label7.Text.Replace(":", ""), "' as MndHeaderX,'", this.txtLegNo.Text, "' as MndNoX,'", this.txtLegName.Text, "' as MndNameX,'", this.label5.Text.Replace(":", ""), "' as CustHeaderX,'", this.txtCustNo.Text, "' as CustNoX,'", this.txtCustName.Text, "' as CustNameX,'", this.label6.Text.Replace(":", ""), "' as SuppHeaderX,'", this.txtSuppNo.Text, "' as SuppNoX,'", this.txtSuppName.Text, "' as SuppNameX,T_SYSSETTING.LogImg,(case when (select sum(x.InvNetLocCur)  from T_INVHED x where x.InvTyp = 1 ", quryEdit, " ) > 0 then (select sum(x.InvNetLocCur)  from T_INVHED x where x.InvTyp = 1 ", quryEdit, ") else 0 end) - (case when (select sum(x.InvNetLocCur)  from T_INVHED x where x.InvTyp = 3 ", quryEdit, ") > 0 then (select sum(x.InvNetLocCur)  from T_INVHED x where x.InvTyp = 3 ", quryEdit, ") else 0 end) as Balanc,(case when (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = 1 ", quryEdit, " ) > 0 then (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = 1 ", quryEdit, ") else 0 end) - (case when (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = 3 ", quryEdit, ") > 0 then (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = 3 ", quryEdit, ") else 0 end) as CashPayLocCur" };
                            Fields = string.Concat(strArrays);
                        }
                        else
                        {
                            strArrays = new string[] { " T_INVSETTING.InvNamA as InvTypNm,T_INVHED.InvTyp,sum(T_INVHED.InvNetLocCur) as InvNetLocCur,(case when (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = T_INVHED.InvTyp and x.IsTaxUse = 1 ", quryEdit, " ) > 0 then (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = T_INVHED.InvTyp and x.IsTaxUse = 1 ", quryEdit, " ) else 0 end) as InvAddTax,'", this.label7.Text.Replace(":", ""), "' as MndHeaderX,'", this.txtLegNo.Text, "' as MndNoX,'", this.txtLegName.Text, "' as MndNameX,'", this.label5.Text.Replace(":", ""), "' as CustHeaderX,'", this.txtCustNo.Text, "' as CustNoX,'", this.txtCustName.Text, "' as CustNameX,'", this.label6.Text.Replace(":", ""), "' as SuppHeaderX,'", this.txtSuppNo.Text, "' as SuppNoX,'", this.txtSuppName.Text, "' as SuppNameX,T_SYSSETTING.LogImg,(case when (select sum(x.InvNetLocCur)  from T_INVHED x where x.InvTyp = 1 ", quryEdit, " ) > 0 then (select sum(x.InvNetLocCur)  from T_INVHED x where x.InvTyp = 1 ", quryEdit, ") else 0 end) - (case when (select sum(x.InvNetLocCur)  from T_INVHED x where x.InvTyp = 3 ", quryEdit, ") > 0 then (select sum(x.InvNetLocCur)  from T_INVHED x where x.InvTyp = 3 ", quryEdit, ") else 0 end) as Balanc,(case when (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = 1 ", quryEdit, " ) > 0 then (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = 1 ", quryEdit, ") else 0 end) - (case when (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = 3 ", quryEdit, ") > 0 then (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = 3 ", quryEdit, ") else 0 end) as CashPayLocCur" };
                            Fields = string.Concat(strArrays);
                        }
                    }
                    else if (this.combobox_RepType.SelectedIndex == 2)
                    {
                        quryEdit = this.BuildRuleList();
                        quryEdit = quryEdit.Replace("Where (T_INVHED.InvTyp = 1 or T_INVHED.InvTyp = 2)", " ");
                        quryEdit = quryEdit.Replace("T_INVHED.", "x.");
                        if (this.LangArEn != 0)
                        {
                            strArrays = new string[] { " T_INVSETTING.InvNamE as InvTypNm,T_INVHED.InvTyp,sum(T_INVHED.InvNetLocCur) as InvNetLocCur,(case when (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = T_INVHED.InvTyp and x.IsTaxUse = 1 ", quryEdit, " ) > 0 then (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = T_INVHED.InvTyp and x.IsTaxUse = 1 ", quryEdit, " ) else 0 end) as InvAddTax,'", this.label7.Text.Replace(":", ""), "' as MndHeaderX,'", this.txtLegNo.Text, "' as MndNoX,'", this.txtLegName.Text, "' as MndNameX,'", this.label5.Text.Replace(":", ""), "' as CustHeaderX,'", this.txtCustNo.Text, "' as CustNoX,'", this.txtCustName.Text, "' as CustNameX,'", this.label6.Text.Replace(":", ""), "' as SuppHeaderX,'", this.txtSuppNo.Text, "' as SuppNoX,'", this.txtSuppName.Text, "' as SuppNameX,T_SYSSETTING.LogImg,(case when (select sum(x.InvNetLocCur)  from T_INVHED x where x.InvTyp = 1 ", quryEdit, " ) > 0 then (select sum(x.InvNetLocCur)  from T_INVHED x where x.InvTyp = 1 ", quryEdit, ") else 0 end) - (case when (select sum(x.InvNetLocCur)  from T_INVHED x where x.InvTyp = 2 ", quryEdit, ") > 0 then (select sum(x.InvNetLocCur)  from T_INVHED x where x.InvTyp = 2 ", quryEdit, ") else 0 end) as Balanc,(case when (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = 1 ", quryEdit, " ) > 0 then (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = 1 ", quryEdit, ") else 0 end) - (case when (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = 2 ", quryEdit, ") > 0 then (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = 2 ", quryEdit, ") else 0 end) as CashPayLocCur" };
                            Fields = string.Concat(strArrays);
                        }
                        else
                        {
                            strArrays = new string[] { " T_INVSETTING.InvNamA as InvTypNm,T_INVHED.InvTyp,sum(T_INVHED.InvNetLocCur) as InvNetLocCur,(case when (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = T_INVHED.InvTyp and x.IsTaxUse = 1 ", quryEdit, " ) > 0 then (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = T_INVHED.InvTyp and x.IsTaxUse = 1 ", quryEdit, " ) else 0 end) as InvAddTax,'", this.label7.Text.Replace(":", ""), "' as MndHeaderX,'", this.txtLegNo.Text, "' as MndNoX,'", this.txtLegName.Text, "' as MndNameX,'", this.label5.Text.Replace(":", ""), "' as CustHeaderX,'", this.txtCustNo.Text, "' as CustNoX,'", this.txtCustName.Text, "' as CustNameX,'", this.label6.Text.Replace(":", ""), "' as SuppHeaderX,'", this.txtSuppNo.Text, "' as SuppNoX,'", this.txtSuppName.Text, "' as SuppNameX,T_SYSSETTING.LogImg,(case when (select sum(x.InvNetLocCur)  from T_INVHED x where x.InvTyp = 1 ", quryEdit, " ) > 0 then (select sum(x.InvNetLocCur)  from T_INVHED x where x.InvTyp = 1 ", quryEdit, ") else 0 end) - (case when (select sum(x.InvNetLocCur)  from T_INVHED x where x.InvTyp = 2 ", quryEdit, ") > 0 then (select sum(x.InvNetLocCur)  from T_INVHED x where x.InvTyp = 2 ", quryEdit, ") else 0 end) as Balanc,(case when (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = 1 ", quryEdit, " ) > 0 then (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = 1 ", quryEdit, ") else 0 end) - (case when (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = 2 ", quryEdit, ") > 0 then (select sum(x.InvAddTax)  from T_INVHED x where x.InvTyp = 2 ", quryEdit, ") else 0 end) as CashPayLocCur" };
                            Fields = string.Concat(strArrays);
                        }
                    }
                    else if (this.switchButton_CalclatTax.Value)
                    {
                        if (this.LangArEn != 0)
                        {
                            text = new object[27];
                            text[0] = " T_INVHED.InvNo,T_INVSETTING.InvNamE as InvTypNm,T_INVHED.GDat,T_INVHED.HDat,T_INVHED.InvCash ,T_CstTbl.Eng_Des as CostCenteNm,T_Mndob.Eng_Des as MndNm,T_INVHED.CashPayLocCur,T_INVHED.NetworkPayLocCur,T_INVHED.CreditPayLocCur,T_INVHED.InvNetLocCur,";
                            text[1] = (this.checkBox_CustomerNam.Checked ? " case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.TaxNo from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END " : string.Concat(" case when T_INVHED.InvTyp =2 or T_INVHED.InvTyp =4 or T_INVHED.InvTyp = 9 or T_INVHED.InvTyp =14 then 0 else(Round(T_INVHED.InvCost,", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2), ")) end "));
                            text[2] = "  as  InvCost,case when T_INVHED.InvTyp = 2 or T_INVHED.InvTyp =4 or T_INVHED.InvTyp = 9 or T_INVHED.InvTyp =14 then 0 else (Round(T_INVHED.InvNetLocCur - T_INVHED.InvCost,";
                            text[3] = (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                            text[4] = ")) end as InvProfit,";
                            object[] objArray = text;
                            if (this.checkBox_Note.Checked)
                            {
                                obj2 = " T_INVHED.Remark as GadeNo";
                            }
                            else if (this.checkBox_CustomerNam.Checked)
                            {
                                obj2 = " case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Eng_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END  as GadeNo";
                            }
                            else if (this.checkBox_DatePay.Checked)
                            {
                                obj2 = " T_INVHED.EstDat as GadeNo ";
                            }
                            else
                            {
                                obj2 = (VarGeneral.GeneralPrinter.ISCashierType ? string.Concat(" case when T_INVHED.InvTyp =2 or T_INVHED.InvTyp =4 or T_INVHED.InvTyp = 9 or T_INVHED.InvTyp =14 then 0 else (Round(T_INVHED.InvNetLocCur - T_INVHED.InvCost,", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2), ")) end as GadeNo ") : " T_INVHED.GadeNo ");
                            }
                            objArray[5] = obj2;
                            text[6] = ",T_INVHED.CusVenNo,T_INVHED.CusVenNm,T_SYSSETTING.LogImg,T_SYSSETTING.Calendr ,T_INVHED.SalsManNo,((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints,'' as UsrNamA,''as UsrNamE,Round(case when T_INVHED.IsTaxUse = 1 and T_INVHED.InvAddTax > 0 then T_INVHED.InvAddTax else  0 end ,";
                            text[7] = (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                            text[8] = ") as TaxValue,'";
                            text[9] = this.label7.Text.Replace(":", "");
                            text[10] = "' as MndHeaderX,'";
                            text[11] = this.txtLegNo.Text;
                            text[12] = "' as MndNoX,'";
                            text[13] = this.txtLegName.Text;
                            text[14] = "' as MndNameX,'";
                            text[15] = this.label5.Text.Replace(":", "");
                            text[16] = "' as CustHeaderX,'";
                            text[17] = this.txtCustNo.Text;
                            text[18] = "' as CustNoX,'";
                            text[19] = this.txtCustName.Text;
                            text[20] = "' as CustNameX,'";
                            text[21] = this.label6.Text.Replace(":", "");
                            text[22] = "' as SuppHeaderX,'";
                            text[23] = this.txtSuppNo.Text;
                            text[24] = "' as SuppNoX,'";
                            text[25] = this.txtSuppName.Text;
                            text[26] = "' as SuppNameX";
                            Fields = string.Concat(text);
                        }
                        else
                        {
                            text = new object[27];
                            text[0] = " T_INVHED.InvNo,T_INVSETTING.InvNamA as InvTypNm,T_INVHED.GDat,T_INVHED.HDat,T_INVHED.InvCash ,T_CstTbl.Arb_Des as CostCenteNm,T_Mndob.Arb_Des as MndNm,T_INVHED.CashPayLocCur,T_INVHED.NetworkPayLocCur,T_INVHED.CreditPayLocCur,T_INVHED.InvNetLocCur,";
                            text[1] = (this.checkBox_CustomerNam.Checked ? " case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.TaxNo from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END " : string.Concat(" case when T_INVHED.InvTyp =2 or T_INVHED.InvTyp =4 or T_INVHED.InvTyp = 9 or T_INVHED.InvTyp =14 then 0 else (Round(T_INVHED.InvCost,", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2), ")) end "));
                            text[2] = " as InvCost,case when T_INVHED.InvTyp =2 or T_INVHED.InvTyp =4 or T_INVHED.InvTyp = 9 or T_INVHED.InvTyp =14 then 0 else (Round(T_INVHED.InvNetLocCur - T_INVHED.InvCost,";
                            text[3] = (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                            text[4] = ")) end as InvProfit,";
                            object[] objArray1 = text;
                            if (this.checkBox_Note.Checked)
                            {
                                obj3 = " T_INVHED.Remark as GadeNo";
                            }
                            else if (this.checkBox_CustomerNam.Checked)
                            {
                                obj3 = " case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Arb_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END  as GadeNo";
                            }
                            else if (this.checkBox_DatePay.Checked)
                            {
                                obj3 = " T_INVHED.EstDat as GadeNo ";
                            }
                            else
                            {
                                obj3 = (VarGeneral.GeneralPrinter.ISCashierType ? string.Concat(" case when T_INVHED.InvTyp =2 or T_INVHED.InvTyp =4 or T_INVHED.InvTyp = 9 or T_INVHED.InvTyp =14 then 0 else (Round(T_INVHED.InvNetLocCur - T_INVHED.InvCost,", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2), ")) end as GadeNo ") : " T_INVHED.GadeNo ");
                            }
                            objArray1[5] = obj3;
                            text[6] = ",T_INVHED.CusVenNo,T_INVHED.CusVenNm,T_SYSSETTING.LogImg,T_SYSSETTING.Calendr ,T_INVHED.SalsManNo,((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints,'' as UsrNamA,''as UsrNamE,Round(case when T_INVHED.IsTaxUse = 1 and T_INVHED.InvAddTax > 0 then T_INVHED.InvAddTax else  0 end ,";
                            text[7] = (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                            text[8] = ") as TaxValue,'";
                            text[9] = this.label7.Text.Replace(":", "");
                            text[10] = "' as MndHeaderX,'";
                            text[11] = this.txtLegNo.Text;
                            text[12] = "' as MndNoX,'";
                            text[13] = this.txtLegName.Text;
                            text[14] = "' as MndNameX,'";
                            text[15] = this.label5.Text.Replace(":", "");
                            text[16] = "' as CustHeaderX,'";
                            text[17] = this.txtCustNo.Text;
                            text[18] = "' as CustNoX,'";
                            text[19] = this.txtCustName.Text;
                            text[20] = "' as CustNameX,'";
                            text[21] = this.label6.Text.Replace(":", "");
                            text[22] = "' as SuppHeaderX,'";
                            text[23] = this.txtSuppNo.Text;
                            text[24] = "' as SuppNoX,'";
                            text[25] = this.txtSuppName.Text;
                            text[26] = "' as SuppNameX";
                            Fields = string.Concat(text);
                        }
                    }
                    else if (this.LangArEn != 0)
                    {
                        text = new object[27];
                        text[0] = " T_INVHED.InvNo,T_INVSETTING.InvNamE as InvTypNm,T_INVHED.GDat,T_INVHED.HDat,T_INVHED.InvCash ,T_CstTbl.Eng_Des as CostCenteNm,T_Mndob.Eng_Des as MndNm,T_INVHED.CashPayLocCur,T_INVHED.NetworkPayLocCur,T_INVHED.CreditPayLocCur,(case when T_INVHED.IsTaxUse = 1 then (T_INVHED.InvNetLocCur - T_INVHED.InvAddTax) else T_INVHED.InvNetLocCur end ) as InvNetLocCur,";
                        text[1] = (this.checkBox_CustomerNam.Checked ? " case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.TaxNo from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END " : string.Concat(" case when T_INVHED.InvTyp =2 or T_INVHED.InvTyp =4 or T_INVHED.InvTyp = 9 or T_INVHED.InvTyp =14 then 0 else (Round(T_INVHED.InvCost,", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2), ")) end "));
                        text[2] = " as  InvCost,case when T_INVHED.InvTyp =2 or T_INVHED.InvTyp =4 or T_INVHED.InvTyp = 9 or T_INVHED.InvTyp =14 then 0 else (Round((  (T_INVHED.InvNetLocCur ) - (case when T_INVHED.IsTaxUse = 1 then (case when T_INVHED.IsTaxByNet = 1 and T_INVHED.IsTaxLines = 0 then (T_INVHED.InvAddTaxlLoc) else ((select sum(Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmTax) from T_INVDET where T_INVDET.InvId = T_INVHED.InvHed_ID) / 100) end) else 0 end)) - T_INVHED.InvCost,";
                        text[3] = (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                        text[4] = ")) end as InvProfit,";
                        object[] objArray2 = text;
                        if (this.checkBox_Note.Checked)
                        {
                            obj = " T_INVHED.Remark as GadeNo";
                        }
                        else if (this.checkBox_CustomerNam.Checked)
                        {
                            obj = " case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Eng_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END  as GadeNo";
                        }
                        else if (this.checkBox_DatePay.Checked)
                        {
                            obj = " T_INVHED.EstDat as GadeNo ";
                        }
                        else
                        {
                            obj = (VarGeneral.GeneralPrinter.ISCashierType ? string.Concat(" case when T_INVHED.InvTyp =2 or T_INVHED.InvTyp =4 or T_INVHED.InvTyp = 9 or T_INVHED.InvTyp =14 then 0 else (Round(T_INVHED.InvNetLocCur - T_INVHED.InvCost,", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2), ")) end as GadeNo ") : " T_INVHED.GadeNo ");
                        }
                        objArray2[5] = obj;
                        text[6] = ",T_INVHED.CusVenNo,T_INVHED.CusVenNm,T_SYSSETTING.LogImg ,T_SYSSETTING.Calendr,T_INVHED.SalsManNo,((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints,'' as UsrNamA,''as UsrNamE,Round(case when T_INVHED.IsTaxUse = 1 and T_INVHED.InvAddTax > 0 then T_INVHED.InvAddTax else  0 end ,";
                        text[7] = (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                        text[8] = ") as TaxValue,'";
                        text[9] = this.label7.Text.Replace(":", "");
                        text[10] = "' as MndHeaderX,'";
                        text[11] = this.txtLegNo.Text;
                        text[12] = "' as MndNoX,'";
                        text[13] = this.txtLegName.Text;
                        text[14] = "' as MndNameX,'";
                        text[15] = this.label5.Text.Replace(":", "");
                        text[16] = "' as CustHeaderX,'";
                        text[17] = this.txtCustNo.Text;
                        text[18] = "' as CustNoX,'";
                        text[19] = this.txtCustName.Text;
                        text[20] = "' as CustNameX,'";
                        text[21] = this.label6.Text.Replace(":", "");
                        text[22] = "' as SuppHeaderX,'";
                        text[23] = this.txtSuppNo.Text;
                        text[24] = "' as SuppNoX,'";
                        text[25] = this.txtSuppName.Text;
                        text[26] = "' as SuppNameX";
                        Fields = string.Concat(text);
                    }
                    else
                    {
                        text = new object[27];
                        text[0] = " T_INVHED.InvNo,T_INVSETTING.InvNamA as InvTypNm,T_INVHED.GDat,T_INVHED.HDat,T_INVHED.InvCash ,T_CstTbl.Arb_Des as CostCenteNm,T_Mndob.Arb_Des as MndNm,T_INVHED.CashPayLocCur,T_INVHED.NetworkPayLocCur,T_INVHED.CreditPayLocCur,(case when T_INVHED.IsTaxUse = 1 then (T_INVHED.InvNetLocCur - T_INVHED.InvAddTax) else T_INVHED.InvNetLocCur end ) as InvNetLocCur,";
                        text[1] = (this.checkBox_CustomerNam.Checked ? " case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.TaxNo from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END " : string.Concat(" case when T_INVHED.InvTyp =2 or T_INVHED.InvTyp =4 or T_INVHED.InvTyp = 9 or T_INVHED.InvTyp =14 then 0 else (Round(T_INVHED.InvCost,", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2), ")) end "));
                        text[2] = " as  InvCost,case when T_INVHED.InvTyp =2 or T_INVHED.InvTyp =4 or T_INVHED.InvTyp = 9 or T_INVHED.InvTyp =14 then 0 else (Round((  (T_INVHED.InvNetLocCur ) - (case when T_INVHED.IsTaxUse = 1 then (case when T_INVHED.IsTaxByNet = 1 and T_INVHED.IsTaxLines = 0 then (T_INVHED.InvAddTaxlLoc) else ((select sum(Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmTax) from T_INVDET where T_INVDET.InvId = T_INVHED.InvHed_ID) / 100) end) else 0 end)) - T_INVHED.InvCost,";
                        text[3] = (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                        text[4] = ")) end as InvProfit,";
                        object[] objArray3 = text;
                        if (this.checkBox_Note.Checked)
                        {
                            obj1 = " T_INVHED.Remark as GadeNo";
                        }
                        else if (this.checkBox_CustomerNam.Checked)
                        {
                            obj1 = " case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Arb_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END  as GadeNo";
                        }
                        else if (this.checkBox_DatePay.Checked)
                        {
                            obj1 = " T_INVHED.EstDat as GadeNo ";
                        }
                        else
                        {
                            obj1 = (VarGeneral.GeneralPrinter.ISCashierType ? string.Concat(" case when T_INVHED.InvTyp =2 or T_INVHED.InvTyp =4 or T_INVHED.InvTyp = 9 or T_INVHED.InvTyp =14 then 0 else (Round(T_INVHED.InvNetLocCur - T_INVHED.InvCost,", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2), ")) end as GadeNo ") : " T_INVHED.GadeNo ");
                        }
                        objArray3[5] = obj1;
                        text[6] = ",T_INVHED.CusVenNo,T_INVHED.CusVenNm,T_SYSSETTING.LogImg ,T_SYSSETTING.Calendr,T_INVHED.SalsManNo,((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints,'' as UsrNamA,''as UsrNamE,Round(case when T_INVHED.IsTaxUse = 1 and T_INVHED.InvAddTax > 0 then T_INVHED.InvAddTax else  0 end ,";
                        text[7] = (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2);
                        text[8] = ") as TaxValue,'";
                        text[9] = this.label7.Text.Replace(":", "");
                        text[10] = "' as MndHeaderX,'";
                        text[11] = this.txtLegNo.Text;
                        text[12] = "' as MndNoX,'";
                        text[13] = this.txtLegName.Text;
                        text[14] = "' as MndNameX,'";
                        text[15] = this.label5.Text.Replace(":", "");
                        text[16] = "' as CustHeaderX,'";
                        text[17] = this.txtCustNo.Text;
                        text[18] = "' as CustNoX,'";
                        text[19] = this.txtCustName.Text;
                        text[20] = "' as CustNameX,'";
                        text[21] = this.label6.Text.Replace(":", "");
                        text[22] = "' as SuppHeaderX,'";
                        text[23] = this.txtSuppNo.Text;
                        text[24] = "' as SuppNoX,'";
                        text[25] = this.txtSuppName.Text;
                        text[26] = "' as SuppNameX";
                        Fields = string.Concat(text);
                    }
                    RepShow repShow = _RepShow;
                    string str1 = this.BuildRuleList();
                    if (this.combobox_RepType.SelectedIndex > 0)
                    {
                        str = string.Concat(" group by ", (this.LangArEn == 0 ? " T_INVSETTING.InvNamA " : " T_INVSETTING.InvNamE "), ",T_SYSSETTING.LogImg ,T_INVHED.InvTyp order by T_INVHED.InvTyp");
                    }
                    else if (this.combobox_SortTyp.SelectedIndex == 0)
                    {
                        str = " order by T_INVHED.InvHed_ID";
                    }
                    else
                    {
                        str = (this.combobox_SortTyp.SelectedIndex == 1 ? " order by T_INVHED.GDat,T_INVHED.InvHed_ID" : " order by T_INVHED.InvTyp,  CONVERT(INT, LEFT(T_INVHED.InvNo, PATINDEX('%[^0-9]%', T_INVHED.InvNo + 'z')-1))");
                    }
                    repShow.Rule = string.Concat(str1, str);
                    _RepShow.Fields = Fields;
                    if ((!File.Exists(string.Concat(Application.StartupPath, "\\Script\\SecriptGlasses.dll")) ? false : this.checkBox_DatePay.Checked))
                    {
                        if (this.LangArEn != 0)
                        {
                            _RepShow.Fields = _RepShow.Fields.Replace("T_CstTbl.Eng_Des as CostCenteNm", "(case when T_INVHED.IfPrint = 1 then 'Ready' else 'UnReady' end ) as CostCenteNm");
                        }
                        else
                        {
                            _RepShow.Fields = _RepShow.Fields.Replace("T_CstTbl.Arb_Des as CostCenteNm", "(case when T_INVHED.IfPrint = 1 then 'جاهز' else 'غير جاهز' end ) as CostCenteNm");
                        }
                    }
                    try
                    {
                        if (CmbInvType.SelectedIndex == 1)
                        {
                       //     _RepShow.Fields = _RepShow.Fields.Replace("T_INVSETTING.InvNamA as InvTypNm", "(CASE when (T_INVHED.IS_ServiceBill=1 and T_INVHED.InvTyp=2) then 'مصروفات مشتريات' else    T_INVSETTING.InvNamA end) as InvTypNm");
                            if (checkBox1.Checked)
                            {
                                if (_RepShow.Rule.Contains("Where T_INVHED.InvTyp = 2 "))
                                    _RepShow.Rule = _RepShow.Rule.Replace("Where T_INVHED.InvTyp = 2 ", "Where (T_INVHED.InvTyp = 2 or T_INVHED.InvTyp=1002 )");
                            }
                        }
                        _RepShow = _RepShow.Save();
                 
                        VarGeneral.RepData = _RepShow.RepData;
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                    if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                    {
                        try
                        {
                            if (this.RButShort2.Value)
                            {
                                List<string> myData = VarGeneral.RepData.Tables[0].AsEnumerable().Select<DataRow, string>((DataRow myRow) => myRow.Field<string>("SalsManNo")).Distinct<string>().ToList<string>();
                                for (int i = 0; i < myData.Count; i++)
                                {
                                    T_User q = this.dbc.RateUsr(myData[i]);
                                    for (int intCount = 0; intCount < VarGeneral.RepData.Tables[0].Rows.Count; intCount++)
                                    {
                                        if (myData[i] == VarGeneral.RepData.Tables[0].Rows[intCount]["SalsManNo"].ToString())
                                        {
                                            VarGeneral.RepData.Tables[0].Rows[intCount]["UsrNamA"] = q.UsrNamA;
                                            VarGeneral.RepData.Tables[0].Rows[intCount]["UsrNamE"] = q.UsrNamE;
                                        }
                                    }
                                }
                            }
                            if (this.checkBox_ItemComm.Checked)
                            {
                                double _c = 0;
                                for (int k = 0; k < VarGeneral.RepData.Tables[0].Rows.Count; k++)
                                {
                                    try
                                    {
                                        _c = 0;
                                        List<T_INVDET> q = (
                                            from er in this.db.T_INVDETs
                                            where er.InvNo == VarGeneral.RepData.Tables[0].Rows[k]["InvNo"].ToString()
                                            where er.T_INVHED.InvTyp == (int?)VarGeneral.InvType
                                            orderby er.InvNo
                                            select er).ToList<T_INVDET>();
                                        for (int c = 0; c < q.Count; c++)
                                        {
                                            try
                                            {
                                                int Comm_ = 0;
                                                try
                                                {
                                                    Comm_ = int.Parse(VarGeneral.Settings_Sys.Seting.Substring(50, 1));
                                                }
                                                catch
                                                {
                                                }
                                                double num = _c;
                                                if (Comm_ == 0)
                                                {
                                                    amount = q[c].Amount;
                                                    double value1 = amount.Value;
                                                    amount = q[c].T_Item.ItemComm;
                                                    value = value1 * (amount.Value / 100);
                                                }
                                                else if (Comm_ == 1)
                                                {
                                                    amount = q[c].T_Item.ItemComm;
                                                    double num1 = amount.Value;
                                                    amount = q[c].RealQty;
                                                    value = num1 * Math.Abs(amount.Value);
                                                }
                                                else
                                                {
                                                    amount = q[c].T_Item.ItemComm;
                                                    value = amount.Value;
                                                }
                                                _c = num + value;
                                            }
                                            catch
                                            {
                                                // goto Label2;
                                            }
                                        }
                                        VarGeneral.RepData.Tables[0].Rows[k]["GadeNo"] = _c;
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                            VarGeneral.IsGeneralUsed = true;
                           // Program.createdb_BARACODE(VarGeneral.RepData.Tables[0], "ReportMultiTable");
                            FrmReportsViewer frm = new FrmReportsViewer()
                            {
                                Tag = this.LangArEn,
                                Repvalue = "Invoices"
                            };
                            if (this.combobox_RepType.SelectedIndex > 0)
                            {
                                VarGeneral.InvTyp = 0;
                            }
                            if (!this.RButPortrait.Checked)
                            {
                                VarGeneral.itmDesIndex = 1;
                            }
                            else
                            {
                                VarGeneral.itmDesIndex = 0;
                            }
                            if (this.RButShort.Value)
                            {
                                VarGeneral.itmDesIndex = 3;
                            }
                            else if (this.RButShort2.Value)
                            {
                                VarGeneral.itmDesIndex = 4;
                            }
                            try
                            {
                                if (this.checkBox_Note.Checked)
                                {
                                    VarGeneral.itmDes = "Note";
                                }
                            }
                            catch
                            {
                                VarGeneral.itmDes = "";
                            }
                            try
                            {
                                if (this.checkBox_CustomerNam.Checked)
                                {
                                    if ((VarGeneral.InvType == 2 ? false : VarGeneral.InvType != 4))
                                    {
                                        VarGeneral.itmDes = (this.LangArEn == 0 ? "العميل" : "Cust");
                                    }
                                    else
                                    {
                                        VarGeneral.itmDes = (this.LangArEn == 0 ? "المورد" : "Supp");
                                    }
                                }
                            }
                            catch
                            {
                                VarGeneral.itmDes = "";
                            }
                            try
                            {
                                if (!this.checkBox_ItemComm.Checked)
                                {
                                    VarGeneral.itemCommRep = false;
                                }
                                else
                                {
                                    VarGeneral.itemCommRep = true;
                                }
                            }
                            catch
                            {
                                VarGeneral.itemCommRep = false;
                            }
                            try
                            {
                                if (this.checkBox_DatePay.Checked)
                                {
                                    VarGeneral.itmDes = "DatePay";
                                }
                            }
                            catch
                            {
                                VarGeneral.itmDes = "";
                            }
                            VarGeneral.vTitle = this.Text;
                            VarGeneral.Customerlbl = this.label5.Text.Replace(" :", "");
                            VarGeneral.Supplierlbl = this.label6.Text.Replace(" :", "");
                            VarGeneral.CostCenterlbl = this.label8.Text.Replace(" :", "");
                            VarGeneral.Mndoblbl = this.label7.Text.Replace(" :", "");
                            if ((!File.Exists(string.Concat(Application.StartupPath, "\\Script\\SecriptGlasses.dll")) ? false : this.checkBox_DatePay.Checked))
                            {
                                VarGeneral.CostCenterlbl = (this.LangArEn == 0 ? "الحالة" : "State");
                            }
                            frm.TopMost = true;
                            frm.ShowDialog();
                            VarGeneral.IsGeneralUsed = false;
                        }
                        catch (Exception exception1)
                        {
                            Exception error = exception1;
                            VarGeneral.DebLog.writeLog("button_ShowRep_Click:", error, true);
                            MessageBox.Show(error.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show((this.LangArEn == 0 ? "عفوا .. لا يوجد بيانات لعرضها في التقرير " : "Sorry .. there is no data to display in the report "), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else
                {
                    MessageBox.Show((this.LangArEn == 0 ? "يرجى التأكد من اختيار نوع الطلب بالشكل الصحيح " : "Please book your order type correctly"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
            catch (Exception exception2)
            {
                MessageBox.Show(exception2.Message);
            }
            VarGeneral.itemCommRep = false;
            try
            {
                VarGeneral.itmDesIndex = 0;
                VarGeneral.itmDes = "";
            }
            catch
            {
            }
        }
        private void button_SrchCostNo_Click(object sender, EventArgs e)
        {
            this.columns_Names_visible.Clear();
            this.columns_Names_visible.Add("Cst_No", new FRInvoice.ColumnDictinary("الرقم", "No", true, ""));
            this.columns_Names_visible.Add("Arb_Des", new FRInvoice.ColumnDictinary("الاسم عربي", "Arabic Name", true, ""));
            this.columns_Names_visible.Add("Eng_Des", new FRInvoice.ColumnDictinary("الاسم الانجليزي", "English Name", true, ""));
            FrmSearch frm = new FrmSearch()
            {
                Tag = this.LangArEn
            };
            foreach (KeyValuePair<string, FRInvoice.ColumnDictinary> kvp in this.columns_Names_visible)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_CstTbl";
            frm.TopMost = true;
            frm.ShowDialog();
            if (!(frm.SerachNo != ""))
            {
                this.txtCostNo.Text = "";
                this.txtCostName.Text = "";
            }
            else
            {
                TextBox str = this.txtCostNo;
                int cstID = this.db.StockCst(frm.Serach_No).Cst_ID;
                str.Text = cstID.ToString();
                if (this.LangArEn != 0)
                {
                    this.txtCostName.Text = this.db.StockCst(frm.Serach_No).Eng_Des.ToString();
                }
                else
                {
                    this.txtCostName.Text = this.db.StockCst(frm.Serach_No).Arb_Des.ToString();
                }
            }
        }
        private void button_SrchCustNo_Click(object sender, EventArgs e)
        {
            this.columns_Names_visible.Clear();
            this.columns_Names_visible.Add("AccDef_No", new FRInvoice.ColumnDictinary("الرقم ", " No", true, ""));
            this.columns_Names_visible.Add("Arb_Des", new FRInvoice.ColumnDictinary("الاسم عربي", "Arabic Name", true, ""));
            this.columns_Names_visible.Add("Eng_Des", new FRInvoice.ColumnDictinary("الاسم الانجليزي", "English Name", true, ""));
            this.columns_Names_visible.Add("AccDef_ID", new FRInvoice.ColumnDictinary(" ", " ", false, ""));
            this.columns_Names_visible.Add("Mobile", new FRInvoice.ColumnDictinary("الجوال", "Mobile", false, ""));
            FrmSearch frm = new FrmSearch()
            {
                Tag = this.LangArEn
            };
            foreach (KeyValuePair<string, FRInvoice.ColumnDictinary> kvp in this.columns_Names_visible)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_AccDef2";
            VarGeneral.AccTyp = 4;
            frm.TopMost = true;
            frm.ShowDialog();
            if (!(frm.SerachNo != ""))
            {
                this.txtCustNo.Text = "";
                this.txtCustName.Text = "";
            }
            else
            {
                this.txtCustNo.Text = this.db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (this.LangArEn != 0)
                {
                    this.txtCustName.Text = this.db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
                else
                {
                    this.txtCustName.Text = this.db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
            }
        }
        private void button_SrchLegNo_Click(object sender, EventArgs e)
        {
            this.columns_Names_visible.Clear();
            this.columns_Names_visible.Add("Mnd_No", new FRInvoice.ColumnDictinary("رقم المندوب", "Commissary No", true, ""));
            this.columns_Names_visible.Add("Arb_Des", new FRInvoice.ColumnDictinary("الاسم عربي", "Arabic Name", true, ""));
            this.columns_Names_visible.Add("Eng_Des", new FRInvoice.ColumnDictinary("الاسم الانجليزي", "English Name", true, ""));
            FrmSearch frm = new FrmSearch()
            {
                Tag = this.LangArEn
            };
            foreach (KeyValuePair<string, FRInvoice.ColumnDictinary> kvp in this.columns_Names_visible)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_Mndob";
            frm.TopMost = true;
            frm.ShowDialog();
            if (!(frm.SerachNo != ""))
            {
                this.txtLegNo.Text = "";
                this.txtLegName.Text = "";
            }
            else
            {
                TextBox str = this.txtLegNo;
                int mndID = this.db.StockMndob(frm.Serach_No).Mnd_ID;
                str.Text = mndID.ToString();
                if (this.LangArEn != 0)
                {
                    this.txtLegName.Text = this.db.StockMndob(frm.Serach_No).Eng_Des.ToString();
                }
                else
                {
                    this.txtLegName.Text = this.db.StockMndob(frm.Serach_No).Arb_Des.ToString();
                }
            }
        }
        private void button_SrchSuppNo_Click(object sender, EventArgs e)
        {
            this.columns_Names_visible.Clear();
            this.columns_Names_visible.Add("AccDef_No", new FRInvoice.ColumnDictinary("الرقم ", " No", true, ""));
            this.columns_Names_visible.Add("Arb_Des", new FRInvoice.ColumnDictinary("الاسم عربي", "Arabic Name", true, ""));
            this.columns_Names_visible.Add("Eng_Des", new FRInvoice.ColumnDictinary("الاسم الانجليزي", "English Name", true, ""));
            this.columns_Names_visible.Add("AccDef_ID", new FRInvoice.ColumnDictinary(" ", " ", false, ""));
            FrmSearch frm = new FrmSearch()
            {
                Tag = this.LangArEn
            };
            foreach (KeyValuePair<string, FRInvoice.ColumnDictinary> kvp in this.columns_Names_visible)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_AccDef_Suppliers";
            VarGeneral.AccTyp = 5;
            frm.TopMost = true;
            frm.ShowDialog();
            if (!(frm.SerachNo != ""))
            {
                this.txtSuppNo.Text = "";
                this.txtSuppName.Text = "";
            }
            else
            {
                this.txtSuppNo.Text = this.db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (this.LangArEn != 0)
                {
                    this.txtSuppName.Text = this.db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
                else
                {
                    this.txtSuppName.Text = this.db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
            }
        }
        private void button_SrchUsrNo_Click(object sender, EventArgs e)
        {
            this.columns_Names_visible.Clear();
            this.columns_Names_visible.Add("UsrNo", new FRInvoice.ColumnDictinary("رقم المستخدم", "User No", true, ""));
            this.columns_Names_visible.Add("UsrNamA", new FRInvoice.ColumnDictinary("الاسم عربي", "Arabic Name", true, ""));
            this.columns_Names_visible.Add("UsrNamE", new FRInvoice.ColumnDictinary("الاسم الانجليزي", "English Name", true, ""));
            FrmSearch frm = new FrmSearch()
            {
                Tag = this.LangArEn
            };
            foreach (KeyValuePair<string, FRInvoice.ColumnDictinary> kvp in this.columns_Names_visible)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_User";
            frm.TopMost = true;
            frm.ShowDialog();
            if (!(frm.SerachNo != ""))
            {
                this.txtUserNo.Text = "";
                this.txtUserName.Text = "";
            }
            else
            {
                this.txtUserNo.Text = this.dbc.StockUser(frm.Serach_No).UsrNo;
                if (this.LangArEn != 0)
                {
                    this.txtUserName.Text = this.dbc.StockUser(frm.Serach_No).UsrNamE.ToString();
                }
                else
                {
                    this.txtUserName.Text = this.dbc.StockUser(frm.Serach_No).UsrNamA.ToString();
                }
            }
        }
        private void checkBox_CustomerNam_CheckedChanged(object sender, EventArgs e)
        {
            this.checkBox_Note_CheckedChanged(sender, e);
            this.RButLandscape.CheckedChanged -= new EventHandler(this.RButPortrait_CheckedChanged);
            this.RButPortrait.CheckedChanged -= new EventHandler(this.RButPortrait_CheckedChanged);
            try
            {
                if (!(VarGeneral.InvTyp == 2 || VarGeneral.InvTyp == 4 ? !this.checkBox_CustomerNam.Checked : true))
                {
                    this.RButLandscape.Checked = true;
                }
                else if (((VarGeneral.InvTyp == 2 || VarGeneral.InvTyp == 4) && !this.checkBox_CustomerNam.Checked ? this.RButLandscape.Checked : false))
                {
                    this.RButPortrait.Checked = true;
                }
            }
            catch
            {
            }
            this.RButLandscape.CheckedChanged += new EventHandler(this.RButPortrait_CheckedChanged);
            this.RButPortrait.CheckedChanged += new EventHandler(this.RButPortrait_CheckedChanged);
        }
        private void checkBox_DatePay_CheckedChanged(object sender, EventArgs e)
        {
            this.RButPortrait.CheckedChanged -= new EventHandler(this.RButPortrait_CheckedChanged);
            if (this.checkBox_DatePay.Checked)
            {
                this.RButLandscape.Checked = true;
            }
            this.RButPortrait.CheckedChanged += new EventHandler(this.RButPortrait_CheckedChanged);
            bool chksts = this.checkBox_DatePay.Checked;
            this.checkBox_Defalut.Checked = true;
            this.checkBox_DatePay.CheckedChanged -= new EventHandler(this.checkBox_DatePay_CheckedChanged);
            this.checkBox_DatePay.Checked = chksts;
            this.checkBox_DatePay.CheckedChanged += new EventHandler(this.checkBox_DatePay_CheckedChanged);
            if (!this.checkBox_DatePay.Checked)
            {
                this.groupBox_Date.Text = (this.LangArEn == 0 ? "حسب تاريخ الفاتورة" : "Date of inactivity");
            }
            else
            {
                this.groupBox_Date.Text = (this.LangArEn == 0 ? "حسب تاريخ الإستحقاق" : "Date of Pay");
            }
        }
        private void checkBox_Note_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox_DatePay.Checked)
            {
                this.checkBox_DatePay.CheckedChanged -= new EventHandler(this.checkBox_DatePay_CheckedChanged);
                this.checkBox_DatePay.Checked = false;
                this.checkBox_DatePay.CheckedChanged += new EventHandler(this.checkBox_DatePay_CheckedChanged);
                this.groupBox_Date.Text = (this.LangArEn == 0 ? "حسب تاريخ الفاتورة" : "Date of inactivity");
            }
        }
        private void CmbInvType_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (CmbInvType.SelectedIndex == 1)
                {
                    checkBox1.Visible = true;
                   
                }else
                {
                    checkBox1.Checked = true;
                    checkBox1.Visible = false;
                }
                if (this.combobox_RepType.SelectedIndex <= 0)
                {
                    VarGeneral.InvTyp = int.Parse(this.CmbInvType.SelectedValue.ToString());
                    VarGeneral.InvType = int.Parse(this.CmbInvType.SelectedValue.ToString());
                }
                else
                {
                    VarGeneral.InvTyp = 0;
                    VarGeneral.InvType = 0;
                    this.Text = this.combobox_RepType.Text;
                }
                Point cmbLoc = new Point(5, 327);
                Point ButOk_ = new Point(283, 431);
                Point ButExit_ = new Point(6, 431);
                if (VarGeneral.InvTyp != 21)
                {
                    this.FlexType.Visible = true;
                    this.CmbDeleted.Visible = true;
                    this.CmbReturn.Visible = true;
                    this.groupBox2.Visible = true;
                    this.RButPortrait.Checked = false;
                    this.RButShort.Visible = true;
                    this.RButShort2.Visible = true;
                    this.CmbInvType.Location = cmbLoc;
                    this.ButOk.Location = ButOk_;
                    this.ButExit.Location = ButExit_;
                    base.Height = 511;
                    this.label6.Visible = true;
                    this.label7.Visible = true;
                    this.label9.Visible = true;
                    this.label8.Visible = true;
                    this.txtSuppNo.Visible = true;
                    this.txtLegNo.Visible = true;
                    this.txtUserNo.Visible = true;
                    this.txtCostNo.Visible = true;
                    this.button_SrchSuppNo.Visible = true;
                    this.button_SrchLegNo.Visible = true;
                    this.button_SrchUsrNo.Visible = true;
                    this.button_SrchCostNo.Visible = true;
                    this.txtSuppName.Visible = true;
                    this.txtLegName.Visible = true;
                    this.txtUserName.Visible = true;
                    this.txtCostName.Visible = true;
                    this.RButLandscape.Checked = true;
                    this.combobox_RepType.Visible = true;
                    this.combobox_SortTyp.Visible = true;
                    this.label10.Visible = true;
                }
                if (this.combobox_RepType.SelectedIndex > 0)
                {
                    this.groupBox2.Enabled = false;
                    this.RButPortrait.Checked = true;
                    this.checkBox_Defalut.Checked = true;
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 6))
                    {
                        this.checkBox_CustomerNam.Checked = true;
                        this.checkBox_CustomerNam_CheckedChanged(null, null);
                    }
                }
                else if ((this.CmbInvType.SelectedIndex == 0 || VarGeneral.InvTyp == 1 || VarGeneral.InvTyp == 3 ? false : VarGeneral.InvTyp != 7))
                {
                    this.groupBox2.Enabled = false;
                    this.RButPortrait.Checked = true;
                    if ((VarGeneral.InvTyp == 2 ? true : VarGeneral.InvTyp == 4))
                    {
                        if ((this.RButShort.Value ? false : !this.RButShort2.Value))
                        {
                            this.checkBox_CustomerNam.Enabled = true;
                        }
                    }
                }
                else
                {
                    this.groupBox2.Enabled = true;
                    this.RButPortrait_CheckedChanged(sender, e);
                }
                if ((this.RButShort.Value ? true : this.RButShort2.Value))
                {
                    this.checkBox_Note.Enabled = false;
                    this.checkBox_CustomerNam.Enabled = false;
                    this.checkBox_ItemComm.Enabled = false;
                    this.checkBox_DatePay.Checked = false;
                    this.checkBox_DatePay.Enabled = false;
                    this.checkBox_Defalut.Checked = true;
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 6))
                    {
                        this.checkBox_CustomerNam.Checked = true;
                        this.checkBox_CustomerNam_CheckedChanged(null, null);
                    }
                }
                this.FillFlex();
            }
            catch
            {
            }
        }
        private void combobox_RepType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.CmbInvType_SelectedValueChanged(sender, e);
            }
            catch
            {
            }
        }
        public void FillCombo()
        {
            this.combobox_SortTyp.Items.Clear();
            this.combobox_SortTyp.Items.Add((this.LangArEn == 0 ? "تسلسل الفواتير" : "Sequence"));
            this.combobox_SortTyp.Items.Add((this.LangArEn == 0 ? "تاريخ الفاتورة" : "Invoice Date"));
            this.combobox_SortTyp.Items.Add((this.LangArEn == 0 ? "رقــم الفاتورة" : "Invoice No"));
            this.combobox_SortTyp.SelectedIndex = 0;
            this.combobox_RepType.Items.Clear();
            this.combobox_RepType.Items.Add((this.LangArEn == 0 ? "----- خيارات إضافية مختصرة ------" : "----- Another Options ------"));
            this.combobox_RepType.Items.Add((this.LangArEn == 0 ? "صافي المبيعات - صافي المرتجعات" : "Sales Net - Return Net"));
            this.combobox_RepType.Items.Add((this.LangArEn == 0 ? "صافي المبيعات - صافي المشتريات" : "Sales Net - Purchase Net"));
            this.combobox_RepType.SelectedIndex = 0;
        }
        private void FillFlex()
        {
            bool flag;
            this.checkBox_DatePay.Checked = false;
            this.checkBox_DatePay.Enabled = false;
            this.switchButton_OrderTyp.Value = false;
            if (this.LangArEn != 0)
            {
                this.FlexType.Rows.Count = 3;
                this.FlexType.SetData(0, 0, true);
                this.FlexType.SetData(0, 1, "Cash");
                this.FlexType.SetData(1, 0, true);
                this.FlexType.SetData(1, 1, "Credit");
                this.FlexType.SetData(2, 0, true);
                this.FlexType.SetData(2, 1, "Network"
                    );
                if (VarGeneral.InvType == 1)
                {
                    this.Text = "Sales Invoice Report";
                    this.checkBox_DatePay.Enabled = true;
                    if ((VarGeneral.SSSLev == "R" || VarGeneral.SSSLev == "C" ? false : !(VarGeneral.SSSLev == "H")))
                    {
                        this.switchButton_OrderTyp.Visible = false;
                        this.groupBox_OrderTyp.Visible = false;
                    }
                    else
                    {
                        this.switchButton_OrderTyp.Visible = true;
                        this.groupBox_OrderTyp.Visible = true;
                    }
                }
                else if (VarGeneral.InvType == 2)
                {
                    this.Text = "Purchase Invoice Report";
                    this.checkBox_DatePay.Enabled = true;
                    this.switchButton_OrderTyp.Visible = false;
                    this.groupBox_OrderTyp.Visible = false;
                }
                else if (VarGeneral.InvType == 3)
                {
                    this.Text = "Sales Return Report";
                    if ((VarGeneral.SSSLev == "R" || VarGeneral.SSSLev == "C" ? false : !(VarGeneral.SSSLev == "H")))
                    {
                        this.switchButton_OrderTyp.Visible = false;
                        this.groupBox_OrderTyp.Visible = false;
                    }
                    else
                    {
                        this.switchButton_OrderTyp.Visible = true;
                        this.groupBox_OrderTyp.Visible = true;
                    }
                }
                else if (VarGeneral.InvType == 4)
                {
                    this.Text = "Purchase Return Report";
                    this.switchButton_OrderTyp.Visible = false;
                    this.groupBox_OrderTyp.Visible = false;
                }
                else if (VarGeneral.InvType == 5)
                {
                    this.Text = "Transfer In Report";
                    this.FlexType.Rows.Count = 1;
                    this.FlexType.SetData(0, 0, true);
                    this.FlexType.SetData(0, 1, "Receipt");
                    this.switchButton_OrderTyp.Visible = false;
                    this.groupBox_OrderTyp.Visible = false;
                }
                else if (VarGeneral.InvType == 6)
                {
                    this.Text = "Transfer Out Report";
                    this.FlexType.Rows.Count = 1;
                    this.FlexType.SetData(0, 0, true);
                    this.FlexType.SetData(0, 1, "Receipt");
                    this.switchButton_OrderTyp.Visible = false;
                    this.groupBox_OrderTyp.Visible = false;
                }
                else if (VarGeneral.InvType == 7)
                {
                    this.Text = "Customer Qutation Report";
                    this.switchButton_OrderTyp.Visible = false;
                    this.groupBox_OrderTyp.Visible = false;
                }
                else if (VarGeneral.InvType == 8)
                {
                    this.Text = "Supplier Qutation Report";
                    this.switchButton_OrderTyp.Visible = false;
                    this.groupBox_OrderTyp.Visible = false;
                }
                else if (VarGeneral.InvType == 9)
                {
                    this.Text = "Purchase Order Report";
                    this.switchButton_OrderTyp.Visible = false;
                    this.groupBox_OrderTyp.Visible = false;
                }
                else if (VarGeneral.InvType == 10)
                {
                    this.Text = "Stock Adjustment Report";
                    this.FlexType.Rows.Count = 1;
                    this.FlexType.SetData(0, 0, true);
                    this.FlexType.SetData(0, 1, "Receipt");
                    this.switchButton_OrderTyp.Visible = false;
                    this.groupBox_OrderTyp.Visible = false;
                }
                else if (VarGeneral.InvType == 14)
                {
                    this.Text = "Open Quantities Report";
                    this.FlexType.Rows.Count = 1;
                    this.FlexType.SetData(0, 0, true);
                    this.FlexType.SetData(0, 1, "Receipt");
                    this.switchButton_OrderTyp.Visible = false;
                    this.groupBox_OrderTyp.Visible = false;
                }
                else if (VarGeneral.InvType == 17)
                {
                    this.Text = "Payment Order Report";
                    this.FlexType.Rows.Count = 1;
                    this.FlexType.SetData(0, 0, true);
                    this.FlexType.SetData(0, 1, "Receipt");
                    this.switchButton_OrderTyp.Visible = false;
                    this.groupBox_OrderTyp.Visible = false;
                }
                else if (VarGeneral.InvType == 20)
                {
                    this.Text = "Payment Order Return Report";
                    this.FlexType.Rows.Count = 1;
                    this.FlexType.SetData(0, 0, true);
                    this.FlexType.SetData(0, 1, "Receipt");
                    this.switchButton_OrderTyp.Visible = false;
                    this.groupBox_OrderTyp.Visible = false;
                }
                else if (VarGeneral.InvType == 21)
                {
                    this.Text = "Local Order Report";
                    this.FlexType.Rows.Count = 1;
                    this.FlexType.SetData(0, 0, true);
                    this.FlexType.SetData(0, 1, "Receipt");
                    this.FlexType.Visible = false;
                    this.CmbDeleted.Visible = false;
                    this.CmbReturn.Visible = false;
                    this.groupBox2.Visible = false;
                    this.RButPortrait.Checked = true;
                    this.CmbInvType.Location = new Point(6, 144);
                    this.RButShort.Visible = false;
                    this.RButShort2.Visible = false;
                    this.ButOk.Location = new Point(283, 180);
                    this.ButExit.Location = new Point(6, 180);
                    base.Height = 270;
                    this.label6.Visible = false;
                    this.label7.Visible = false;
                    this.label9.Visible = false;
                    this.label8.Visible = false;
                    this.txtSuppNo.Visible = false;
                    this.txtLegNo.Visible = false;
                    this.txtUserNo.Visible = false;
                    this.txtCostNo.Visible = false;
                    this.button_SrchSuppNo.Visible = false;
                    this.button_SrchLegNo.Visible = false;
                    this.button_SrchUsrNo.Visible = false;
                    this.button_SrchCostNo.Visible = false;
                    this.txtSuppName.Visible = false;
                    this.txtLegName.Visible = false;
                    this.txtUserName.Visible = false;
                    this.txtCostName.Visible = false;
                    this.combobox_RepType.Visible = false;
                    this.combobox_SortTyp.Visible = false;
                    this.label10.Visible = false;
                    this.switchButton_OrderTyp.Visible = false;
                    this.groupBox_OrderTyp.Visible = false;
                }
            }
            else
            {
                this.FlexType.Rows.Count = 3;
                this.FlexType.SetData(0, 0, true);
                this.FlexType.SetData(0, 1, "نقدي");
                this.FlexType.SetData(1, 0, true);
                this.FlexType.SetData(1, 1, "آجل");
                this.FlexType.SetData(2, 0, true);
                this.FlexType.SetData(2, 1, "الشبكة");
                if (VarGeneral.InvType == 1)
                {
                    this.Text = "تقرير فاتورة مبيعات";
                    this.checkBox_DatePay.Enabled = true;
                    if ((VarGeneral.SSSLev == "R" || VarGeneral.SSSLev == "C" ? false : !(VarGeneral.SSSLev == "H")))
                    {
                        this.switchButton_OrderTyp.Visible = false;
                        this.groupBox_OrderTyp.Visible = false;
                    }
                    else
                    {
                        this.switchButton_OrderTyp.Visible = true;
                        this.groupBox_OrderTyp.Visible = true;
                    }
                }
                else if (VarGeneral.InvType == 2)
                {
                    this.Text = "تقرير فاتورة مشتريات";
                    this.checkBox_DatePay.Enabled = true;
                    this.switchButton_OrderTyp.Visible = false;
                    this.groupBox_OrderTyp.Visible = false;
                }
                else if (VarGeneral.InvType == 3)
                {
                    this.Text = "تقرير مرتجع مبيعات";
                    if ((VarGeneral.SSSLev == "R" || VarGeneral.SSSLev == "C" ? false : !(VarGeneral.SSSLev == "H")))
                    {
                        this.switchButton_OrderTyp.Visible = false;
                        this.groupBox_OrderTyp.Visible = false;
                    }
                    else
                    {
                        this.switchButton_OrderTyp.Visible = true;
                        this.groupBox_OrderTyp.Visible = true;
                    }
                }
                else if (VarGeneral.InvType == 4)
                {
                    this.Text = "تقرير مرتجع مشتريات";
                    this.switchButton_OrderTyp.Visible = false;
                    this.groupBox_OrderTyp.Visible = false;
                }
                else if (VarGeneral.InvType == 5)
                {
                    this.Text = "تقرير فاتورة إدخال بضاعة";
                    this.FlexType.Rows.Count = 1;
                    this.FlexType.SetData(0, 0, true);
                    this.FlexType.SetData(0, 1, "سند");
                    this.switchButton_OrderTyp.Visible = false;
                    this.groupBox_OrderTyp.Visible = false;
                }
                else if (VarGeneral.InvType == 6)
                {
                    this.Text = "تقرير فاتورة إخراج بضاعة";
                    this.FlexType.Rows.Count = 1;
                    this.FlexType.SetData(0, 0, true);
                    this.FlexType.SetData(0, 1, "سند");
                    this.switchButton_OrderTyp.Visible = false;
                    this.groupBox_OrderTyp.Visible = false;
                }
                else if (VarGeneral.InvType == 7)
                {
                    this.Text = "تقرير عرض سعر للعملاء";
                    this.switchButton_OrderTyp.Visible = false;
                    this.groupBox_OrderTyp.Visible = false;
                }
                else if (VarGeneral.InvType == 8)
                {
                    this.Text = "تقرير عرض سعر للموردين";
                    this.switchButton_OrderTyp.Visible = false;
                    this.groupBox_OrderTyp.Visible = false;
                }
                else if (VarGeneral.InvType == 9)
                {
                    this.Text = "تقرير طلب شراء";
                    this.switchButton_OrderTyp.Visible = false;
                    this.groupBox_OrderTyp.Visible = false;
                }
                else if (VarGeneral.InvType == 10)
                {
                    this.Text = "تقرير فاتورة تسوية البضاعة";
                    this.FlexType.Rows.Count = 1;
                    this.FlexType.SetData(0, 0, true);
                    this.FlexType.SetData(0, 1, "سند");
                    this.switchButton_OrderTyp.Visible = false;
                    this.groupBox_OrderTyp.Visible = false;
                }
                else if (VarGeneral.InvType == 14)
                {
                    this.Text = "تقرير بضاعة اول المدة";
                    this.FlexType.Rows.Count = 1;
                    this.FlexType.SetData(0, 0, true);
                    this.FlexType.SetData(0, 1, "سند");
                    this.switchButton_OrderTyp.Visible = false;
                    this.groupBox_OrderTyp.Visible = false;
                }
                else if (VarGeneral.InvType == 17)
                {
                    this.Text = "تقرير فاتورة صرف بضاعة";
                    this.FlexType.Rows.Count = 1;
                    this.FlexType.SetData(0, 0, true);
                    this.FlexType.SetData(0, 1, "سند");
                    this.switchButton_OrderTyp.Visible = false;
                    this.groupBox_OrderTyp.Visible = false;
                }
                else if (VarGeneral.InvType == 20)
                {
                    this.Text = "تقرير مرتجع صرف بضاعة";
                    this.FlexType.Rows.Count = 1;
                    this.FlexType.SetData(0, 0, true);
                    this.FlexType.SetData(0, 1, "سند");
                    this.switchButton_OrderTyp.Visible = false;
                    this.groupBox_OrderTyp.Visible = false;
                }
                else if (VarGeneral.InvType == 21)
                {
                    this.Text = "تقرير الطلبات المحلية";
                    this.FlexType.Rows.Count = 1;
                    this.FlexType.SetData(0, 0, true);
                    this.FlexType.SetData(0, 1, "سند");
                    this.FlexType.Visible = false;
                    this.CmbDeleted.Visible = false;
                    this.CmbReturn.Visible = false;
                    this.groupBox2.Visible = false;
                    this.RButPortrait.Checked = true;
                    this.CmbInvType.Location = new Point(6, 144);
                    this.RButShort.Visible = false;
                    this.RButShort2.Visible = false;
                    this.ButOk.Location = new Point(283, 180);
                    this.ButExit.Location = new Point(6, 180);
                    base.Height = 270;
                    this.label6.Visible = false;
                    this.label7.Visible = false;
                    this.label9.Visible = false;
                    this.label8.Visible = false;
                    this.txtSuppNo.Visible = false;
                    this.txtLegNo.Visible = false;
                    this.txtUserNo.Visible = false;
                    this.txtCostNo.Visible = false;
                    this.button_SrchSuppNo.Visible = false;
                    this.button_SrchLegNo.Visible = false;
                    this.button_SrchUsrNo.Visible = false;
                    this.button_SrchCostNo.Visible = false;
                    this.txtSuppName.Visible = false;
                    this.txtLegName.Visible = false;
                    this.txtUserName.Visible = false;
                    this.txtCostName.Visible = false;
                    this.combobox_RepType.Visible = false;
                    this.combobox_SortTyp.Visible = false;
                    this.label10.Visible = false;
                    this.switchButton_OrderTyp.Visible = false;
                    this.groupBox_OrderTyp.Visible = false;
                }
            }
            this.RibunButtons();
            if (this.vType > 0)
            {
                this.CmbInvType.Visible = false;
            }
            if (File.Exists(string.Concat(Application.StartupPath, "\\Script\\SecriptInvitationCards.dll")))
            {
                this.label6.Text = (this.LangArEn == 0 ? "حساب المكان :" : "Place Account :");
                if (VarGeneral.InvType == 8)
                {
                    this.Text = (this.LangArEn == 0 ? "تقرير إصدار الدعوات" : "Invitation Issuse");
                }
            }
            if (File.Exists(string.Concat(Application.StartupPath, "\\Script\\SecriptSchool.dll")))
            {
                this.label5.Text = (this.LangArEn == 0 ? "الطـالـب :" : "Student Acc :");
                if (VarGeneral.InvType == 7)
                {
                    this.Text = (this.LangArEn == 0 ? "تقرير عرض سعر للطلاب" : "Students Qutation Report");
                }
            }
            if (File.Exists(string.Concat(Application.StartupPath, "\\Script\\SecriptStons.dll")))
            {
                if (VarGeneral.InvType == 8)
                {
                    this.Text = (this.LangArEn == 0 ? "تقرير أمر تحميل" : "Order");
                }
            }
            if (File.Exists(string.Concat(Application.StartupPath, "\\Script\\SecriptTegnicalCollage.dll")))
            {
                this.label5.Text = (this.LangArEn == 0 ? "الطـالـب :" : "Student Acc :");
                this.label7.Text = (this.LangArEn == 0 ? "الأستــاذ :" : "Teacher :");
                if (VarGeneral.InvType == 17)
                {
                    this.Text = (this.LangArEn == 0 ? "تقرير فواتير إصدار العهد" : "Issuance of a Custody");
                }
                else if (VarGeneral.InvType == 20)
                {
                    this.Text = (this.LangArEn == 0 ? "تقرير فواتير إرجاع العهد" : "Return of custody");
                }
            }
            if (File.Exists(string.Concat(Application.StartupPath, "\\Script\\SecriptWaterPackages.dll")))
            {
                this.label5.Text = (this.LangArEn == 0 ? "الســــــائــق :" : "Driver Acc :");
                this.label7.Text = (this.LangArEn == 0 ? "العميــــــــل :" : "Customer :");
                this.label8.Text = (this.LangArEn == 0 ? "السيــارة :" : "Car :");
                if (VarGeneral.InvType == 7)
                {
                    this.Text = (this.LangArEn == 0 ? "تقرير فواتير عرض سعر السائقين" : "Drivers Qutation Reports");
                }
            }
            if ((VarGeneral.gUserName != "runsetting" ? false : File.Exists(string.Concat(Application.StartupPath, "\\Script\\", VarGeneral.gServerName.Replace(string.Concat(Environment.MachineName, "\\"), "").Trim(), "\\khalijwatania.dll"))))
            {
                if (VarGeneral.InvType == 1)
                {
                    this.Text = (this.LangArEn == 0 ? "تقرير فواتير الخدمة" : "Service Reports");
                }
            }
            if (File.Exists(string.Concat(Application.StartupPath, "\\Script\\Secriptjustlight.dll")))
            {
                flag = false;
            }
            else
            {
                flag = (VarGeneral.gUserName != "runsetting" ? true : !File.Exists(string.Concat(Application.StartupPath, "\\Script\\", VarGeneral.gServerName.Replace(string.Concat(Environment.MachineName, "\\"), "").Trim(), "\\Secriptjustlight.dll")));
            }
            if (!flag)
            {
                if (VarGeneral.InvType == 1)
                {
                    this.Text = (this.LangArEn == 0 ? "تقرير فواتير حجز وتأجير" : "Renting and Booking Reports");
                }
                else if (VarGeneral.InvType == 3)
                {
                    this.Text = (this.LangArEn == 0 ? "تقرير فواتير إلغاء حجز وتأجير" : "Renting and Booking Cancel Reports");
                }
            }
        }
        private void FRInvoice_Load(object sender, EventArgs e)
        {
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(e.KeyCode != Keys.F5 || !this.ButOk.Enabled ? true : !this.ButOk.Visible))
            {
                this.ButOk_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                base.Close();
            }
        }
        private void Frm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void MaintenanceCars()
        {
            this.listInvSetting = (
                from t in this.db.T_INVSETTINGs
                where t.InvID == 1 || t.InvID == 2 || t.InvID == 3 || t.InvID == 4 || t.InvID == 7
                select t).ToList<T_INVSETTING>();
            try
            {
                this.CmbInvType.DataSource = null;
            }
            catch
            {
            }
            if (this.LangArEn != 0)
            {
                this.CmbInvType.DataSource = this.listInvSetting;
                this.CmbInvType.DisplayMember = "InvNamE";
                this.CmbInvType.ValueMember = "InvID";
            }
            else
            {
                this.CmbInvType.DataSource = this.listInvSetting;
                this.CmbInvType.DisplayMember = "InvNamA";
                this.CmbInvType.ValueMember = "InvID";
            }
            this.label7.Text = (this.LangArEn == 0 ? "نوع السيارة :" : "Car Type :");
        }
        protected override void OnLoad(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRInvoice));
            if (!(VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == ""))
            {
                Language.ChangeLanguage("en", this, resources);
                this.LangArEn = 1;
                this.RButShort.OnText = "By Date";
                this.RButShort.OffText = "By Date";
                this.RButShort2.OnText = "Short";
                this.RButShort2.OffText = "Short";
            }
            else
            {
                Language.ChangeLanguage("ar-SA", this, resources);
                this.LangArEn = 0;
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
            this.FillCombo();
            if (VarGeneral.RepSalesPOS)
            {
                this.txtUserNo.Text = VarGeneral.UserNo;
                this.txtUserName.Text = (this.LangArEn == 0 ? VarGeneral.UserNameA : VarGeneral.UserNameE);
                this.RButShort2.Value = true;
            }
            if (!VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 6))
            {
                this.checkBox_Note.Visible = false;
                this.checkBox_Defalut.Visible = false;
                this.checkBox_ItemComm.Visible = false;
                this.checkBox_CustomerNam.Checked = true;
                this.RButPortrait.Enabled = false;
                this.checkBox_DatePay.Visible = false;
                this.checkBox_CustomerNam_CheckedChanged(null, null);
            }
            if (File.Exists(string.Concat(Application.StartupPath, "\\Script\\SecriptInvitationCards.dll")))
            {
                this.Script_InvitationCards();
            }
            if (File.Exists(string.Concat(Application.StartupPath, "\\Script\\SecriptSchool.dll")))
            {
                this.Script_School();
            }
            if (File.Exists(string.Concat(Application.StartupPath, "\\Script\\SecriptMaintenanceCars.dll")))
            {
                this.MaintenanceCars();
            }
            if (File.Exists(string.Concat(Application.StartupPath, "\\Script\\SecriptBus.dll")))
            {
                this.label8.Text = (this.LangArEn == 0 ? "الباص :" : "Bus :");
                this.label7.Text = (this.LangArEn == 0 ? "السائق :" : "Driver :");
            }
            if (File.Exists(string.Concat(Application.StartupPath, "\\Script\\SecriptTegnicalCollage.dll")))
            {
                this.TegnicalCollage();
            }
            if (File.Exists(string.Concat(Application.StartupPath, "\\Script\\SecriptWaterPackages.dll")))
            {
                this.WaterPackages();
            }
             avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRInvoice));
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Language.ChangeLanguage("ar-SA", this, resources);
                this.LangArEn = 0;
            }
            else if (VarGeneral.CurrentLang.ToString() == "1")
            {
                Language.ChangeLanguage("en", this, resources);
                this.LangArEn = 1;
            }
            this.FillFlex();
            this.FillCombo();
             avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;

        }
        private void RButPortrait_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.RButPortrait.Checked)
            {
                this.checkBox_Note.Enabled = true;
                this.checkBox_CustomerNam.Enabled = true;
                this.checkBox_ItemComm.Enabled = true;
                this.checkBox_DatePay.Enabled = true;
            }
            else
            {
                this.checkBox_Note.Enabled = false;
                this.checkBox_CustomerNam.Enabled = false;
                this.checkBox_ItemComm.Enabled = false;
                this.checkBox_DatePay.Checked = false;
                this.checkBox_DatePay.Enabled = false;
            }
            this.checkBox_Defalut.Checked = true;
            if (!VarGeneral.TString.ChkStatShow(VarGeneral.UserPassQty, 6))
            {
                this.checkBox_CustomerNam.Checked = true;
                this.checkBox_CustomerNam_CheckedChanged(null, null);
            }
        }
        private void RButShort_ValueChanged(object sender, EventArgs e)
        {
            if (!this.RButShort.Value)
            {
                this.groupBox2.Enabled = true;
                this.checkBox_DatePay.Enabled = true;
                this.combobox_RepType.Enabled = true;
                this.RButPortrait_CheckedChanged(sender, e);
            }
            else
            {
                this.groupBox2.Enabled = false;
                this.checkBox_Note.Enabled = false;
                this.checkBox_Note.Checked = false;
                this.checkBox_CustomerNam.Enabled = false;
                this.checkBox_CustomerNam.Checked = false;
                this.checkBox_ItemComm.Enabled = false;
                this.checkBox_ItemComm.Checked = false;
                this.checkBox_DatePay.Checked = false;
                this.checkBox_DatePay.Enabled = false;
                this.combobox_RepType.SelectedIndex = 0;
                this.combobox_RepType.Enabled = false;
            }
            this.CmbInvType_SelectedValueChanged(sender, e);
        }
        private void RButShort_ValueChanging(object sender, EventArgs e)
        {
            if (!this.RButShort.Value)
            {
                this.RButShort2.ValueChanging -= new EventHandler(this.RButShort2_ValueChanging);
                this.RButShort2.ValueChanged -= new EventHandler(this.RButShort2_ValueChanged);
                this.RButShort2.Value = false;
                this.RButShort2.ValueChanging += new EventHandler(this.RButShort2_ValueChanging);
                this.RButShort2.ValueChanged += new EventHandler(this.RButShort2_ValueChanged);
            }
        }
        private void RButShort2_ValueChanged(object sender, EventArgs e)
        {
            if (!this.RButShort2.Value)
            {
                this.groupBox2.Enabled = true;
                this.checkBox_DatePay.Enabled = true;
                this.combobox_RepType.Enabled = true;
                this.RButPortrait_CheckedChanged(sender, e);
            }
            else
            {
                this.groupBox2.Enabled = false;
                this.checkBox_Note.Enabled = false;
                this.checkBox_Note.Checked = false;
                this.checkBox_CustomerNam.Enabled = false;
                this.checkBox_CustomerNam.Checked = false;
                this.checkBox_ItemComm.Enabled = false;
                this.checkBox_ItemComm.Checked = false;
                this.checkBox_DatePay.Checked = false;
                this.checkBox_DatePay.Enabled = false;
                this.combobox_RepType.SelectedIndex = 0;
                this.combobox_RepType.Enabled = false;
            }
            this.CmbInvType_SelectedValueChanged(sender, e);
        }
        private void RButShort2_ValueChanging(object sender, EventArgs e)
        {
            if (!this.RButShort2.Value)
            {
                this.RButShort.ValueChanging -= new EventHandler(this.RButShort_ValueChanging);
                this.RButShort.ValueChanged -= new EventHandler(this.RButShort_ValueChanged);
                this.RButShort.Value = false;
                this.RButShort.ValueChanging += new EventHandler(this.RButShort_ValueChanging);
                this.RButShort.ValueChanged += new EventHandler(this.RButShort_ValueChanged);
            }
        }
        private void RibunButtons()
        {
            if (this.LangArEn != 0)
            {
                this.ButExit.Text = "Exit Esc";
                this.ButOk.Text = (VarGeneral.GeneralPrinter.ISdirectPrinting ? "Print F5" : "Show F5");
                this.groupBox3.Text = "Quantity";
                this.groupBox_Date.Text = "Date of inactivity";
                this.label1.Text = "From :";
                this.label2.Text = "To :";
                this.label3.Text = "From :";
                this.label4.Text = "To :";
                this.label5.Text = "Customer :";
                this.label6.Text = "Supplier :";
                this.label7.Text = "Delegate :";
                this.label8.Text = "Cost Center :";
                this.label9.Text = "User :";
                this.switchButton_CalclatTax.OffText = "Calclate Net with tax";
                this.switchButton_CalclatTax.OnText = "Calclate Net with tax";
                this.switchButton_OrderTyp.OffText = "Order Type Option";
                this.switchButton_OrderTyp.OnText = "Order Type Option";
            }
            else
            {
                this.ButExit.Text = "خــــروج Esc";
                this.ButOk.Text = (VarGeneral.GeneralPrinter.ISdirectPrinting ? "طبـــاعة F5" : "عــــرض F5");
                this.groupBox3.Text = "حسب رقم الفاتورة";
                this.groupBox_Date.Text = "حسب تاريخ الفاتورة";
                this.label1.Text = "مـــــن :";
                this.label2.Text = "إلـــــى :";
                this.label3.Text = "مـــــن :";
                this.label4.Text = "إلـــــى :";
                this.label5.Text = "العميـــــــــل :";
                this.label6.Text = "المــــــــــورد :";
                this.label7.Text = "المنـــــــدوب :";
                this.label8.Text = "مركز التكلفة :";
                this.label9.Text = "المستخـــدم :";
                this.radioButton_Del0.Text = "الغير محذوفة";
                this.radioButton_Del1.Text = "الكـــل";
                this.radioButton_Del2.Text = "المحذوفة فقط";
                this.radioButton_ِReturn0.Text = "الغير مرتجعة";
                this.radioButton_ِReturn1.Text = "الكـــل";
                this.radioButton_ِReturn2.Text = "المرتجعة فقط";
                this.switchButton_CalclatTax.OffText = "حساب الصافي بالضريبة";
                this.switchButton_CalclatTax.OnText = "حساب الصافي بالضريبة";
                this.switchButton_OrderTyp.OffText = "خيارات نوع الطلب";
                this.switchButton_OrderTyp.OnText = "خيارات نوع الطلب";
            }
        }
        private void Script_InvitationCards()
        {
            this.checkBox_Note.Visible = false;
            this.checkBox_CustomerNam.Visible = false;
            this.checkBox_ItemComm.Visible = false;
            this.checkBox_Defalut.Visible = false;
            this.listInvSetting = (
                from t in this.db.T_INVSETTINGs
                where t.InvID == 1 || t.InvID == 8
                select t).ToList<T_INVSETTING>();
            try
            {
                this.CmbInvType.DataSource = null;
            }
            catch
            {
            }
            if (this.LangArEn != 0)
            {
                this.CmbInvType.DataSource = this.listInvSetting;
                this.CmbInvType.DisplayMember = "InvNamE";
                this.CmbInvType.ValueMember = "InvID";
            }
            else
            {
                this.CmbInvType.DataSource = this.listInvSetting;
                this.CmbInvType.DisplayMember = "InvNamA";
                this.CmbInvType.ValueMember = "InvID";
            }
        }
        private void Script_School()
        {
            this.checkBox_Note.Visible = false;
            this.checkBox_CustomerNam.Visible = false;
            this.checkBox_ItemComm.Visible = false;
            this.checkBox_Defalut.Visible = false;
            this.listInvSetting = (
                from t in this.db.T_INVSETTINGs
                where t.InvID == 1 || t.InvID == 2 || t.InvID == 3 || t.InvID == 4 || t.InvID == 7 || t.InvID == 8 || t.InvID == 9 || t.InvID == 10 || t.InvID == 14
                select t).ToList<T_INVSETTING>();
            try
            {
                this.CmbInvType.DataSource = null;
            }
            catch
            {
            }
            if (this.LangArEn != 0)
            {
                this.CmbInvType.DataSource = this.listInvSetting;
                this.CmbInvType.DisplayMember = "InvNamE";
                this.CmbInvType.ValueMember = "InvID";
            }
            else
            {
                this.CmbInvType.DataSource = this.listInvSetting;
                this.CmbInvType.DisplayMember = "InvNamA";
                this.CmbInvType.ValueMember = "InvID";
            }
        }
        private void switchButton_OrderTyp_ValueChanged(object sender, EventArgs e)
        {
            this.groupBox_OrderTyp.Enabled = this.switchButton_OrderTyp.Value;
        }
        private void TegnicalCollage()
        {
            this.checkBox_Note.Visible = false;
            this.checkBox_CustomerNam.Visible = false;
            this.checkBox_ItemComm.Visible = false;
            this.checkBox_Defalut.Visible = false;
            this.groupBox2.Visible = false;
            this.checkBox_DatePay.Visible = false;
            this.RButShort2.Visible = false;
            this.label8.Visible = false;
            this.txtCostNo.Visible = false;
            this.button_SrchCostNo.Visible = false;
            this.txtCostName.Visible = false;
            this.listInvSetting = (
                from t in this.db.T_INVSETTINGs
                where t.InvID == 2 || t.InvID == 4 || t.InvID == 9 || t.InvID == 10 || t.InvID == 14 || t.InvID == 17 || t.InvID == 20
                select t).ToList<T_INVSETTING>();
            try
            {
                this.CmbInvType.DataSource = null;
            }
            catch
            {
            }
            if (this.LangArEn != 0)
            {
                this.CmbInvType.DataSource = this.listInvSetting;
                this.CmbInvType.DisplayMember = "InvNamE";
                this.CmbInvType.ValueMember = "InvID";
            }
            else
            {
                this.CmbInvType.DataSource = this.listInvSetting;
                this.CmbInvType.DisplayMember = "InvNamA";
                this.CmbInvType.ValueMember = "InvID";
            }
        }
        private void txtMFromDate_Click(object sender, EventArgs e)
        {
            this.txtMFromDate.SelectAll();
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
        private void txtMFromNo_Click(object sender, EventArgs e)
        {
            this.txtMFromNo.SelectAll();
        }
        private void txtMFromNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        private void txtMIntoNo_Click(object sender, EventArgs e)
        {
            this.txtMIntoNo.SelectAll();
        }
        private void txtMIntoNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
        private void txtMToDate_Click(object sender, EventArgs e)
        {
            this.txtMToDate.SelectAll();
        }
        private void txtMToDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!VarGeneral.CheckDate(this.txtMToDate.Text))
                {
                    this.txtMToDate.Text = "";
                }
                else
                {
                    MaskedTextBox str = this.txtMToDate;
                    DateTime dateTime = Convert.ToDateTime(this.txtMToDate.Text);
                    str.Text = dateTime.ToString("yyyy/MM/dd");
                }
            }
            catch
            {
                this.txtMToDate.Text = "";
            }
        }
        private void WaterPackages()
        {
            this.listInvSetting = (
                from t in this.db.T_INVSETTINGs
                where t.InvID == 1 || t.InvID == 2 || t.InvID == 3 || t.InvID == 4 || t.InvID == 5 || t.InvID == 6 || t.InvID == 7 || t.InvID == 8 || t.InvID == 9 || t.InvID == 10 || t.InvID == 14
                select t).ToList<T_INVSETTING>();
            try
            {
                this.CmbInvType.DataSource = null;
            }
            catch
            {
            }
            if (this.LangArEn != 0)
            {
                this.CmbInvType.DataSource = this.listInvSetting;
                this.CmbInvType.DisplayMember = "InvNamE";
                this.CmbInvType.ValueMember = "InvID";
            }
            else
            {
                this.CmbInvType.DataSource = this.listInvSetting;
                this.CmbInvType.DisplayMember = "InvNamA";
                this.CmbInvType.ValueMember = "InvID";
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
        private void txtCustName_TextChanged(object sender, EventArgs e)
        {
        }
        private void ribbonBar1_ItemClick(object sender, EventArgs e)
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
        private class Item
        {
            public string Name;
            public int Value;
            public Item(string name, int value)
            {
                this.Name = name;
                this.Value = value;
            }
            public override string ToString()
            {
                return this.Name;
            }
        }
            private void FRInvoice_Shown(object sender, EventArgs e)
        {
        }
        private void FRInvoice_Activated(object sender, EventArgs e)
        {
            FrmInvSale_Shown(null, null);
        }

        private void groupBox_Date_Enter(object sender, EventArgs e)
        {

        }

        private void CmbInvType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
