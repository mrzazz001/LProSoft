using C1.Win.C1FlexGrid;
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
    public partial class FRInvoice : Form
    {
        private IContainer components = null;
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
            this.InitializeComponent();
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
                if ((bool)this.FlexType.GetData(2, 0))
                {
                    if (string.IsNullOrEmpty(RuleInvType))
                    {
                        obj = RuleInvType;
                        tag = new object[] { obj, this.FlexType.Tag, "  = ", iiCnt };
                        RuleInvType = string.Concat(tag);
                    }
                    obj = RuleInvType;
                    tag = new object[] { obj, " or T_INVHED.InvCash = 'الشبكة' or T_INVHED.InvCash = 'شبكـــة' " };
                    RuleInvType = string.Concat(tag);
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
                                obj2 = (VarGeneral.GeneralPrinter.nTyp_Setting.Substring(1, 1) == "1" ? string.Concat(" case when T_INVHED.InvTyp =2 or T_INVHED.InvTyp =4 or T_INVHED.InvTyp = 9 or T_INVHED.InvTyp =14 then 0 else (Round(T_INVHED.InvNetLocCur - T_INVHED.InvCost,", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2), ")) end as GadeNo ") : " T_INVHED.GadeNo ");
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
                                obj3 = (VarGeneral.GeneralPrinter.nTyp_Setting.Substring(1, 1) == "1" ? string.Concat(" case when T_INVHED.InvTyp =2 or T_INVHED.InvTyp =4 or T_INVHED.InvTyp = 9 or T_INVHED.InvTyp =14 then 0 else (Round(T_INVHED.InvNetLocCur - T_INVHED.InvCost,", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2), ")) end as GadeNo ") : " T_INVHED.GadeNo ");
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
                            obj = (VarGeneral.GeneralPrinter.nTyp_Setting.Substring(1, 1) == "1" ? string.Concat(" case when T_INVHED.InvTyp =2 or T_INVHED.InvTyp =4 or T_INVHED.InvTyp = 9 or T_INVHED.InvTyp =14 then 0 else (Round(T_INVHED.InvNetLocCur - T_INVHED.InvCost,", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2), ")) end as GadeNo ") : " T_INVHED.GadeNo ");
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
                            obj1 = (VarGeneral.GeneralPrinter.nTyp_Setting.Substring(1, 1) == "1" ? string.Concat(" case when T_INVHED.InvTyp =2 or T_INVHED.InvTyp =4 or T_INVHED.InvTyp = 9 or T_INVHED.InvTyp =14 then 0 else (Round(T_INVHED.InvNetLocCur - T_INVHED.InvCost,", (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2), ")) end as GadeNo ") : " T_INVHED.GadeNo ");
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
        protected override void Dispose(bool disposing)
        {
            if ((!disposing ? false : this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRInvoice));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.ButOk = new C1.Win.C1Input.C1Button();
            this.ButExit = new C1.Win.C1Input.C1Button();
            this.checkBox_CustomerNam = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.combobox_RepType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.switchButton_OrderTyp = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.label10 = new System.Windows.Forms.Label();
            this.combobox_SortTyp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.switchButton_CalclatTax = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.RButShort2 = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.checkBox_Defalut = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBox_ItemComm = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBox_Note = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.RButShort = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.CmbInvType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_SrchUsrNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchLegNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchSuppNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchCustNo = new DevComponents.DotNetBar.ButtonX();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtUserNo = new System.Windows.Forms.TextBox();
            this.txtLegName = new System.Windows.Forms.TextBox();
            this.txtLegNo = new System.Windows.Forms.TextBox();
            this.txtSuppName = new System.Windows.Forms.TextBox();
            this.txtSuppNo = new System.Windows.Forms.TextBox();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.txtCustNo = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtMIntoNo = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMFromNo = new System.Windows.Forms.MaskedTextBox();
            this.groupBox_Date = new System.Windows.Forms.GroupBox();
            this.txtMToDate = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMFromDate = new System.Windows.Forms.MaskedTextBox();
            this.FlexType = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.txtCostNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button_SrchCostNo = new DevComponents.DotNetBar.ButtonX();
            this.txtCostName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RButLandscape = new System.Windows.Forms.RadioButton();
            this.RButPortrait = new System.Windows.Forms.RadioButton();
            this.groupBox_OrderTyp = new System.Windows.Forms.GroupBox();
            this.radioButton_Delivery = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.radioButton_Out = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.radioButton_In = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelFooter = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_Tax1 = new System.Windows.Forms.RadioButton();
            this.radioButton_Tax2 = new System.Windows.Forms.RadioButton();
            this.radioButton_Tax0 = new System.Windows.Forms.RadioButton();
            this.CmbDeleted = new System.Windows.Forms.GroupBox();
            this.radioButton_Del1 = new System.Windows.Forms.RadioButton();
            this.radioButton_Del2 = new System.Windows.Forms.RadioButton();
            this.radioButton_Del0 = new System.Windows.Forms.RadioButton();
            this.CmbReturn = new System.Windows.Forms.GroupBox();
            this.radioButton_ِReturn1 = new System.Windows.Forms.RadioButton();
            this.radioButton_ِReturn2 = new System.Windows.Forms.RadioButton();
            this.radioButton_ِReturn0 = new System.Windows.Forms.RadioButton();
            this.checkBox_DatePay = new System.Windows.Forms.CheckBox();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.PanelSpecialContainer.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButExit)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox_Date.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlexType)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox_OrderTyp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.CmbDeleted.SuspendLayout();
            this.CmbReturn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelSpecialContainer
            // 
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar1);
            this.PanelSpecialContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSpecialContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelSpecialContainer.Name = "PanelSpecialContainer";
            this.PanelSpecialContainer.Size = new System.Drawing.Size(562, 479);
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
            this.ribbonBar1.Controls.Add(this.checkBox_CustomerNam);
            this.ribbonBar1.Controls.Add(this.combobox_RepType);
            this.ribbonBar1.Controls.Add(this.switchButton_OrderTyp);
            this.ribbonBar1.Controls.Add(this.label10);
            this.ribbonBar1.Controls.Add(this.combobox_SortTyp);
            this.ribbonBar1.Controls.Add(this.switchButton_CalclatTax);
            this.ribbonBar1.Controls.Add(this.RButShort2);
            this.ribbonBar1.Controls.Add(this.checkBox_Defalut);
            this.ribbonBar1.Controls.Add(this.checkBox_ItemComm);
            this.ribbonBar1.Controls.Add(this.checkBox_Note);
            this.ribbonBar1.Controls.Add(this.RButShort);
            this.ribbonBar1.Controls.Add(this.CmbInvType);
            this.ribbonBar1.Controls.Add(this.label9);
            this.ribbonBar1.Controls.Add(this.label7);
            this.ribbonBar1.Controls.Add(this.label6);
            this.ribbonBar1.Controls.Add(this.label5);
            this.ribbonBar1.Controls.Add(this.button_SrchUsrNo);
            this.ribbonBar1.Controls.Add(this.button_SrchLegNo);
            this.ribbonBar1.Controls.Add(this.button_SrchSuppNo);
            this.ribbonBar1.Controls.Add(this.button_SrchCustNo);
            this.ribbonBar1.Controls.Add(this.txtUserName);
            this.ribbonBar1.Controls.Add(this.txtUserNo);
            this.ribbonBar1.Controls.Add(this.txtLegName);
            this.ribbonBar1.Controls.Add(this.txtLegNo);
            this.ribbonBar1.Controls.Add(this.txtSuppName);
            this.ribbonBar1.Controls.Add(this.txtSuppNo);
            this.ribbonBar1.Controls.Add(this.txtCustName);
            this.ribbonBar1.Controls.Add(this.txtCustNo);
            this.ribbonBar1.Controls.Add(this.groupBox3);
            this.ribbonBar1.Controls.Add(this.groupBox_Date);
            this.ribbonBar1.Controls.Add(this.FlexType);
            this.ribbonBar1.Controls.Add(this.txtCostNo);
            this.ribbonBar1.Controls.Add(this.label8);
            this.ribbonBar1.Controls.Add(this.button_SrchCostNo);
            this.ribbonBar1.Controls.Add(this.txtCostName);
            this.ribbonBar1.Controls.Add(this.groupBox2);
            this.ribbonBar1.Controls.Add(this.groupBox_OrderTyp);
            this.ribbonBar1.Controls.Add(this.labelFooter);
            this.ribbonBar1.Controls.Add(this.groupBox1);
            this.ribbonBar1.Controls.Add(this.CmbDeleted);
            this.ribbonBar1.Controls.Add(this.CmbReturn);
            this.ribbonBar1.Controls.Add(this.checkBox_DatePay);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(562, 479);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 1099;
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
            this.ButOk.Location = new System.Drawing.Point(260, 432);
            this.ButOk.Name = "ButOk";
            this.ButOk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButOk.Size = new System.Drawing.Size(227, 27);
            this.ButOk.TabIndex = 6754;
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
            this.ButExit.Location = new System.Drawing.Point(75, 432);
            this.ButExit.Name = "ButExit";
            this.ButExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButExit.Size = new System.Drawing.Size(179, 27);
            this.ButExit.TabIndex = 6753;
            this.ButExit.Text = "خروج | ESC";
            this.ButExit.UseVisualStyleBackColor = true;
            this.ButExit.Click += new System.EventHandler(this.ButExit_Click);
            this.ButExit.MouseLeave += new System.EventHandler(this.ButExit_MouseLeave);
            this.ButExit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButExit_MouseMove);
            // 
            // checkBox_CustomerNam
            // 
            // 
            // 
            // 
            this.checkBox_CustomerNam.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_CustomerNam.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBox_CustomerNam.Location = new System.Drawing.Point(169, 333);
            this.checkBox_CustomerNam.Name = "checkBox_CustomerNam";
            this.checkBox_CustomerNam.Size = new System.Drawing.Size(129, 20);
            this.checkBox_CustomerNam.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_CustomerNam.TabIndex = 6752;
            this.checkBox_CustomerNam.Text = "إظهار العميل / المورد";
            this.checkBox_CustomerNam.CheckedChanged += new System.EventHandler(this.checkBox_CustomerNam_CheckedChanged);
            // 
            // combobox_RepType
            // 
            this.combobox_RepType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combobox_RepType.DisplayMember = "Text";
            this.combobox_RepType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_RepType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_RepType.Font = new System.Drawing.Font("Tahoma", 8F);
            this.combobox_RepType.FormattingEnabled = true;
            this.combobox_RepType.ItemHeight = 14;
            this.combobox_RepType.Location = new System.Drawing.Point(6, 226);
            this.combobox_RepType.Name = "combobox_RepType";
            this.combobox_RepType.Size = new System.Drawing.Size(292, 20);
            this.combobox_RepType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combobox_RepType.TabIndex = 6751;
            this.combobox_RepType.SelectedIndexChanged += new System.EventHandler(this.combobox_RepType_SelectedIndexChanged);
            // 
            // switchButton_OrderTyp
            // 
            // 
            // 
            // 
            this.switchButton_OrderTyp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_OrderTyp.Location = new System.Drawing.Point(6, 399);
            this.switchButton_OrderTyp.Name = "switchButton_OrderTyp";
            this.switchButton_OrderTyp.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.switchButton_OrderTyp.OffText = "خيارات نوع الطلب";
            this.switchButton_OrderTyp.OffTextColor = System.Drawing.Color.White;
            this.switchButton_OrderTyp.OnText = "خيارات نوع الطلب";
            this.switchButton_OrderTyp.Size = new System.Drawing.Size(159, 30);
            this.switchButton_OrderTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_OrderTyp.SwitchWidth = 25;
            this.switchButton_OrderTyp.TabIndex = 6748;
            this.switchButton_OrderTyp.ValueChanged += new System.EventHandler(this.switchButton_OrderTyp_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(486, 230);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 6745;
            this.label10.Text = "ترتيب حسب :";
            // 
            // combobox_SortTyp
            // 
            this.combobox_SortTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combobox_SortTyp.DisplayMember = "Text";
            this.combobox_SortTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_SortTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_SortTyp.Font = new System.Drawing.Font("Tahoma", 8F);
            this.combobox_SortTyp.FormattingEnabled = true;
            this.combobox_SortTyp.ItemHeight = 14;
            this.combobox_SortTyp.Location = new System.Drawing.Point(304, 226);
            this.combobox_SortTyp.Name = "combobox_SortTyp";
            this.combobox_SortTyp.Size = new System.Drawing.Size(176, 20);
            this.combobox_SortTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combobox_SortTyp.TabIndex = 6744;
            // 
            // switchButton_CalclatTax
            // 
            // 
            // 
            // 
            this.switchButton_CalclatTax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_CalclatTax.Location = new System.Drawing.Point(304, 362);
            this.switchButton_CalclatTax.Name = "switchButton_CalclatTax";
            this.switchButton_CalclatTax.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.switchButton_CalclatTax.OffText = "حساب الربح مع الضريبة";
            this.switchButton_CalclatTax.OffTextColor = System.Drawing.Color.White;
            this.switchButton_CalclatTax.OnText = "حساب الربح مع الضريبة";
            this.switchButton_CalclatTax.Size = new System.Drawing.Size(255, 35);
            this.switchButton_CalclatTax.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_CalclatTax.SwitchWidth = 25;
            this.switchButton_CalclatTax.TabIndex = 6742;
            // 
            // RButShort2
            // 
            // 
            // 
            // 
            this.RButShort2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.RButShort2.Location = new System.Drawing.Point(6, 374);
            this.RButShort2.Name = "RButShort2";
            this.RButShort2.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.RButShort2.OffText = "مختصـــر";
            this.RButShort2.OffTextColor = System.Drawing.Color.White;
            this.RButShort2.OnText = "مختصـــر";
            this.RButShort2.Size = new System.Drawing.Size(159, 24);
            this.RButShort2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.RButShort2.SwitchWidth = 25;
            this.RButShort2.TabIndex = 6740;
            this.RButShort2.ValueChanging += new System.EventHandler(this.RButShort2_ValueChanging);
            this.RButShort2.ValueChanged += new System.EventHandler(this.RButShort2_ValueChanged);
            // 
            // checkBox_Defalut
            // 
            // 
            // 
            // 
            this.checkBox_Defalut.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_Defalut.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBox_Defalut.Checked = true;
            this.checkBox_Defalut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Defalut.CheckValue = "Y";
            this.checkBox_Defalut.Location = new System.Drawing.Point(169, 354);
            this.checkBox_Defalut.Name = "checkBox_Defalut";
            this.checkBox_Defalut.Size = new System.Drawing.Size(129, 20);
            this.checkBox_Defalut.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_Defalut.TabIndex = 6739;
            this.checkBox_Defalut.Text = "الإفتــــراضي";
            // 
            // checkBox_ItemComm
            // 
            // 
            // 
            // 
            this.checkBox_ItemComm.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_ItemComm.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBox_ItemComm.Location = new System.Drawing.Point(169, 312);
            this.checkBox_ItemComm.Name = "checkBox_ItemComm";
            this.checkBox_ItemComm.Size = new System.Drawing.Size(129, 20);
            this.checkBox_ItemComm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_ItemComm.TabIndex = 6738;
            this.checkBox_ItemComm.Text = "إظهار عمـــولات الصنف";
            this.checkBox_ItemComm.CheckedChanged += new System.EventHandler(this.checkBox_Note_CheckedChanged);
            // 
            // checkBox_Note
            // 
            // 
            // 
            // 
            this.checkBox_Note.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_Note.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBox_Note.Location = new System.Drawing.Point(169, 291);
            this.checkBox_Note.Name = "checkBox_Note";
            this.checkBox_Note.Size = new System.Drawing.Size(129, 20);
            this.checkBox_Note.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_Note.TabIndex = 6737;
            this.checkBox_Note.Text = "إظهار عمود الملاحظات";
            this.checkBox_Note.CheckedChanged += new System.EventHandler(this.checkBox_Note_CheckedChanged);
            // 
            // RButShort
            // 
            // 
            // 
            // 
            this.RButShort.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.RButShort.Location = new System.Drawing.Point(6, 348);
            this.RButShort.Name = "RButShort";
            this.RButShort.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.RButShort.OffText = "حسب التاريخ";
            this.RButShort.OffTextColor = System.Drawing.Color.White;
            this.RButShort.OnText = "حسب التاريخ";
            this.RButShort.Size = new System.Drawing.Size(159, 24);
            this.RButShort.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.RButShort.SwitchWidth = 25;
            this.RButShort.TabIndex = 6733;
            this.RButShort.ValueChanging += new System.EventHandler(this.RButShort_ValueChanging);
            this.RButShort.ValueChanged += new System.EventHandler(this.RButShort_ValueChanged);
            // 
            // CmbInvType
            // 
            this.CmbInvType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbInvType.DisplayMember = "Text";
            this.CmbInvType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbInvType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbInvType.FormattingEnabled = true;
            this.CmbInvType.ItemHeight = 14;
            this.CmbInvType.Location = new System.Drawing.Point(5, 327);
            this.CmbInvType.Name = "CmbInvType";
            this.CmbInvType.Size = new System.Drawing.Size(159, 20);
            this.CmbInvType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbInvType.TabIndex = 1175;
            this.CmbInvType.SelectedValueChanged += new System.EventHandler(this.CmbInvType_SelectedValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(486, 182);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 1174;
            this.label9.Text = "المستخـــدم :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(486, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 1173;
            this.label7.Text = "المنـــــــدوب :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(486, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 1172;
            this.label6.Text = "المــــــــــورد :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(486, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 1171;
            this.label5.Text = "العميـــــــــل :";
            // 
            // button_SrchUsrNo
            // 
            this.button_SrchUsrNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchUsrNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchUsrNo.Location = new System.Drawing.Point(373, 178);
            this.button_SrchUsrNo.Name = "button_SrchUsrNo";
            this.button_SrchUsrNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchUsrNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchUsrNo.Symbol = "";
            this.button_SrchUsrNo.SymbolSize = 12F;
            this.button_SrchUsrNo.TabIndex = 15;
            this.button_SrchUsrNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchUsrNo.Click += new System.EventHandler(this.button_SrchUsrNo_Click);
            // 
            // button_SrchLegNo
            // 
            this.button_SrchLegNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchLegNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchLegNo.Location = new System.Drawing.Point(373, 155);
            this.button_SrchLegNo.Name = "button_SrchLegNo";
            this.button_SrchLegNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchLegNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchLegNo.Symbol = "";
            this.button_SrchLegNo.SymbolSize = 12F;
            this.button_SrchLegNo.TabIndex = 12;
            this.button_SrchLegNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchLegNo.Click += new System.EventHandler(this.button_SrchLegNo_Click);
            // 
            // button_SrchSuppNo
            // 
            this.button_SrchSuppNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchSuppNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchSuppNo.Location = new System.Drawing.Point(373, 132);
            this.button_SrchSuppNo.Name = "button_SrchSuppNo";
            this.button_SrchSuppNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchSuppNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchSuppNo.Symbol = "";
            this.button_SrchSuppNo.SymbolSize = 12F;
            this.button_SrchSuppNo.TabIndex = 9;
            this.button_SrchSuppNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchSuppNo.Click += new System.EventHandler(this.button_SrchSuppNo_Click);
            // 
            // button_SrchCustNo
            // 
            this.button_SrchCustNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchCustNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCustNo.Location = new System.Drawing.Point(373, 109);
            this.button_SrchCustNo.Name = "button_SrchCustNo";
            this.button_SrchCustNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchCustNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCustNo.Symbol = "";
            this.button_SrchCustNo.SymbolSize = 12F;
            this.button_SrchCustNo.TabIndex = 6;
            this.button_SrchCustNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCustNo.Click += new System.EventHandler(this.button_SrchCustNo_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.Ivory;
            this.txtUserName.ForeColor = System.Drawing.Color.White;
            this.txtUserName.Location = new System.Drawing.Point(6, 178);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtUserName, false);
            this.txtUserName.Size = new System.Drawing.Size(364, 20);
            this.txtUserName.TabIndex = 16;
            this.txtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUserNo
            // 
            this.txtUserNo.BackColor = System.Drawing.Color.White;
            this.txtUserNo.Location = new System.Drawing.Point(401, 178);
            this.txtUserNo.Name = "txtUserNo";
            this.txtUserNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtUserNo, false);
            this.txtUserNo.Size = new System.Drawing.Size(79, 20);
            this.txtUserNo.TabIndex = 14;
            this.txtUserNo.Tag = " T_INVHED.SalsManNo ";
            this.txtUserNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLegName
            // 
            this.txtLegName.BackColor = System.Drawing.Color.Ivory;
            this.txtLegName.ForeColor = System.Drawing.Color.White;
            this.txtLegName.Location = new System.Drawing.Point(6, 155);
            this.txtLegName.Name = "txtLegName";
            this.txtLegName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtLegName, false);
            this.txtLegName.Size = new System.Drawing.Size(364, 20);
            this.txtLegName.TabIndex = 13;
            this.txtLegName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLegNo
            // 
            this.txtLegNo.BackColor = System.Drawing.Color.White;
            this.txtLegNo.Location = new System.Drawing.Point(401, 155);
            this.txtLegNo.Name = "txtLegNo";
            this.txtLegNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtLegNo, false);
            this.txtLegNo.Size = new System.Drawing.Size(79, 20);
            this.txtLegNo.TabIndex = 11;
            this.txtLegNo.Tag = "T_INVHED.MndNo ";
            this.txtLegNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSuppName
            // 
            this.txtSuppName.BackColor = System.Drawing.Color.Ivory;
            this.txtSuppName.ForeColor = System.Drawing.Color.White;
            this.txtSuppName.Location = new System.Drawing.Point(6, 132);
            this.txtSuppName.Name = "txtSuppName";
            this.txtSuppName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtSuppName, false);
            this.txtSuppName.Size = new System.Drawing.Size(364, 20);
            this.txtSuppName.TabIndex = 10;
            this.txtSuppName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSuppNo
            // 
            this.txtSuppNo.BackColor = System.Drawing.Color.White;
            this.txtSuppNo.Location = new System.Drawing.Point(401, 132);
            this.txtSuppNo.Name = "txtSuppNo";
            this.txtSuppNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtSuppNo, false);
            this.txtSuppNo.Size = new System.Drawing.Size(79, 20);
            this.txtSuppNo.TabIndex = 8;
            this.txtSuppNo.Tag = " T_INVHED.CusVenNo ";
            this.txtSuppNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCustName
            // 
            this.txtCustName.BackColor = System.Drawing.Color.Ivory;
            this.txtCustName.ForeColor = System.Drawing.Color.White;
            this.txtCustName.Location = new System.Drawing.Point(6, 109);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtCustName, false);
            this.txtCustName.Size = new System.Drawing.Size(364, 20);
            this.txtCustName.TabIndex = 7;
            this.txtCustName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCustName.TextChanged += new System.EventHandler(this.txtCustName_TextChanged);
            // 
            // txtCustNo
            // 
            this.txtCustNo.BackColor = System.Drawing.Color.White;
            this.txtCustNo.Location = new System.Drawing.Point(401, 109);
            this.txtCustNo.Name = "txtCustNo";
            this.txtCustNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtCustNo, false);
            this.txtCustNo.Size = new System.Drawing.Size(79, 20);
            this.txtCustNo.TabIndex = 5;
            this.txtCustNo.Tag = " T_INVHED.CusVenNo ";
            this.txtCustNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.txtMIntoNo);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtMFromNo);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.groupBox3.Location = new System.Drawing.Point(3, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(554, 48);
            this.groupBox3.TabIndex = 1162;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "حسب رقم الفاتورة";
            // 
            // txtMIntoNo
            // 
            this.txtMIntoNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMIntoNo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtMIntoNo.Location = new System.Drawing.Point(55, 19);
            this.txtMIntoNo.Name = "txtMIntoNo";
            this.txtMIntoNo.Size = new System.Drawing.Size(122, 22);
            this.txtMIntoNo.TabIndex = 2;
            this.txtMIntoNo.Tag = " T_INVHED.InvNo ";
            this.txtMIntoNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMIntoNo.Click += new System.EventHandler(this.txtMIntoNo_Click);
            this.txtMIntoNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMIntoNo_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(447, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 857;
            this.label1.Text = "مـــــن :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(183, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 859;
            this.label2.Text = "إلـــــى :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMFromNo
            // 
            this.txtMFromNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMFromNo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtMFromNo.Location = new System.Drawing.Point(319, 19);
            this.txtMFromNo.Name = "txtMFromNo";
            this.txtMFromNo.Size = new System.Drawing.Size(122, 22);
            this.txtMFromNo.TabIndex = 1;
            this.txtMFromNo.Tag = " T_INVHED.InvNo ";
            this.txtMFromNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMFromNo.Click += new System.EventHandler(this.txtMFromNo_Click);
            this.txtMFromNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMFromNo_KeyPress);
            // 
            // groupBox_Date
            // 
            this.groupBox_Date.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_Date.Controls.Add(this.txtMToDate);
            this.groupBox_Date.Controls.Add(this.label3);
            this.groupBox_Date.Controls.Add(this.label4);
            this.groupBox_Date.Controls.Add(this.txtMFromDate);
            this.groupBox_Date.Location = new System.Drawing.Point(6, 56);
            this.groupBox_Date.Name = "groupBox_Date";
            this.groupBox_Date.Size = new System.Drawing.Size(554, 48);
            this.groupBox_Date.TabIndex = 1161;
            this.groupBox_Date.TabStop = false;
            this.groupBox_Date.Text = "حسب تاريخ الفاتورة";
            // 
            // txtMToDate
            // 
            this.txtMToDate.Location = new System.Drawing.Point(55, 19);
            this.txtMToDate.Mask = "0000/00/00";
            this.txtMToDate.Name = "txtMToDate";
            this.txtMToDate.Size = new System.Drawing.Size(122, 20);
            this.txtMToDate.TabIndex = 4;
            this.txtMToDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMToDate.Click += new System.EventHandler(this.txtMToDate_Click);
            this.txtMToDate.Leave += new System.EventHandler(this.txtMToDate_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(447, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 860;
            this.label3.Text = "مـــــن :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(183, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 861;
            this.label4.Text = "إلـــــى :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMFromDate
            // 
            this.txtMFromDate.Location = new System.Drawing.Point(319, 19);
            this.txtMFromDate.Mask = "0000/00/00";
            this.txtMFromDate.Name = "txtMFromDate";
            this.txtMFromDate.Size = new System.Drawing.Size(122, 20);
            this.txtMFromDate.TabIndex = 3;
            this.txtMFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMFromDate.Click += new System.EventHandler(this.txtMFromDate_Click);
            this.txtMFromDate.Leave += new System.EventHandler(this.txtMFromDate_Leave);
            // 
            // FlexType
            // 
            this.FlexType.BackColor = System.Drawing.Color.White;
            this.FlexType.ColumnInfo = resources.GetString("FlexType.ColumnInfo");
            this.FlexType.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FlexType.Location = new System.Drawing.Point(5, 252);
            this.FlexType.Name = "FlexType";
            this.FlexType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FlexType.Rows.Count = 3;
            this.FlexType.Rows.DefaultSize = 19;
            this.FlexType.Rows.Fixed = 0;
            this.FlexType.Size = new System.Drawing.Size(159, 73);
            this.FlexType.StyleInfo = resources.GetString("FlexType.StyleInfo");
            this.FlexType.TabIndex = 28;
            this.FlexType.Tag = " T_INVHED.InvCashPay ";
            this.FlexType.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System;
            // 
            // txtCostNo
            // 
            this.txtCostNo.BackColor = System.Drawing.Color.White;
            this.txtCostNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtCostNo.Location = new System.Drawing.Point(401, 201);
            this.txtCostNo.MaxLength = 30;
            this.txtCostNo.Name = "txtCostNo";
            this.txtCostNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtCostNo, false);
            this.txtCostNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCostNo.Size = new System.Drawing.Size(79, 20);
            this.txtCostNo.TabIndex = 17;
            this.txtCostNo.Tag = "  T_INVHED.InvCstNo ";
            this.txtCostNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(486, 205);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 1170;
            this.label8.Text = "مركز التكلفة :";
            // 
            // button_SrchCostNo
            // 
            this.button_SrchCostNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchCostNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCostNo.Location = new System.Drawing.Point(373, 201);
            this.button_SrchCostNo.Name = "button_SrchCostNo";
            this.button_SrchCostNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchCostNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCostNo.Symbol = "";
            this.button_SrchCostNo.SymbolSize = 12F;
            this.button_SrchCostNo.TabIndex = 18;
            this.button_SrchCostNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCostNo.Click += new System.EventHandler(this.button_SrchCostNo_Click);
            // 
            // txtCostName
            // 
            this.txtCostName.BackColor = System.Drawing.Color.Ivory;
            this.txtCostName.ForeColor = System.Drawing.Color.White;
            this.txtCostName.Location = new System.Drawing.Point(6, 201);
            this.txtCostName.Name = "txtCostName";
            this.txtCostName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtCostName, false);
            this.txtCostName.Size = new System.Drawing.Size(364, 20);
            this.txtCostName.TabIndex = 19;
            this.txtCostName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.RButLandscape);
            this.groupBox2.Controls.Add(this.RButPortrait);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(169, 246);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(131, 40);
            this.groupBox2.TabIndex = 6732;
            this.groupBox2.TabStop = false;
            // 
            // RButLandscape
            // 
            this.RButLandscape.AutoSize = true;
            this.RButLandscape.Checked = true;
            this.RButLandscape.Font = new System.Drawing.Font("Tahoma", 8F);
            this.RButLandscape.ForeColor = System.Drawing.Color.SteelBlue;
            this.RButLandscape.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RButLandscape.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RButLandscape.Location = new System.Drawing.Point(4, 16);
            this.RButLandscape.Name = "RButLandscape";
            this.RButLandscape.Size = new System.Drawing.Size(57, 17);
            this.RButLandscape.TabIndex = 1008;
            this.RButLandscape.TabStop = true;
            this.RButLandscape.Text = "عرضي";
            this.RButLandscape.UseVisualStyleBackColor = true;
            this.RButLandscape.CheckedChanged += new System.EventHandler(this.RButPortrait_CheckedChanged);
            // 
            // RButPortrait
            // 
            this.RButPortrait.AutoSize = true;
            this.RButPortrait.Font = new System.Drawing.Font("Tahoma", 8F);
            this.RButPortrait.ForeColor = System.Drawing.Color.SteelBlue;
            this.RButPortrait.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RButPortrait.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RButPortrait.Location = new System.Drawing.Point(72, 16);
            this.RButPortrait.Name = "RButPortrait";
            this.RButPortrait.Size = new System.Drawing.Size(51, 17);
            this.RButPortrait.TabIndex = 1007;
            this.RButPortrait.Text = "طولي";
            this.RButPortrait.UseVisualStyleBackColor = true;
            this.RButPortrait.CheckedChanged += new System.EventHandler(this.RButPortrait_CheckedChanged);
            // 
            // groupBox_OrderTyp
            // 
            this.groupBox_OrderTyp.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_OrderTyp.Controls.Add(this.radioButton_Delivery);
            this.groupBox_OrderTyp.Controls.Add(this.radioButton_Out);
            this.groupBox_OrderTyp.Controls.Add(this.radioButton_In);
            this.groupBox_OrderTyp.Enabled = false;
            this.groupBox_OrderTyp.Location = new System.Drawing.Point(169, 392);
            this.groupBox_OrderTyp.Name = "groupBox_OrderTyp";
            this.groupBox_OrderTyp.Size = new System.Drawing.Size(390, 37);
            this.groupBox_OrderTyp.TabIndex = 6746;
            this.groupBox_OrderTyp.TabStop = false;
            this.groupBox_OrderTyp.Tag = " T_INVHED.IfRet ";
            // 
            // radioButton_Delivery
            // 
            // 
            // 
            // 
            this.radioButton_Delivery.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radioButton_Delivery.Location = new System.Drawing.Point(22, 14);
            this.radioButton_Delivery.Name = "radioButton_Delivery";
            this.radioButton_Delivery.Size = new System.Drawing.Size(78, 17);
            this.radioButton_Delivery.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.radioButton_Delivery.TabIndex = 6740;
            this.radioButton_Delivery.Text = "طلب توصيل";
            this.radioButton_Delivery.TextColor = System.Drawing.Color.Black;
            // 
            // radioButton_Out
            // 
            // 
            // 
            // 
            this.radioButton_Out.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radioButton_Out.Location = new System.Drawing.Point(162, 14);
            this.radioButton_Out.Name = "radioButton_Out";
            this.radioButton_Out.Size = new System.Drawing.Size(72, 17);
            this.radioButton_Out.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.radioButton_Out.TabIndex = 6739;
            this.radioButton_Out.Text = "سفـــــري";
            this.radioButton_Out.TextColor = System.Drawing.Color.Black;
            // 
            // radioButton_In
            // 
            // 
            // 
            // 
            this.radioButton_In.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.radioButton_In.Checked = true;
            this.radioButton_In.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radioButton_In.CheckValue = "Y";
            this.radioButton_In.Location = new System.Drawing.Point(296, 14);
            this.radioButton_In.Name = "radioButton_In";
            this.radioButton_In.Size = new System.Drawing.Size(62, 17);
            this.radioButton_In.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.radioButton_In.TabIndex = 6738;
            this.radioButton_In.Text = "محلـــيً";
            this.radioButton_In.TextColor = System.Drawing.Color.Black;
            // 
            // labelFooter
            // 
            this.labelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelFooter.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.labelFooter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelFooter.Location = new System.Drawing.Point(6, 403);
            this.labelFooter.Name = "labelFooter";
            this.labelFooter.Size = new System.Drawing.Size(554, 23);
            this.labelFooter.TabIndex = 6747;
            this.labelFooter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.radioButton_Tax1);
            this.groupBox1.Controls.Add(this.radioButton_Tax2);
            this.groupBox1.Controls.Add(this.radioButton_Tax0);
            this.groupBox1.Location = new System.Drawing.Point(304, 245);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 40);
            this.groupBox1.TabIndex = 6749;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = " T_INVHED.IfRet ";
            // 
            // radioButton_Tax1
            // 
            this.radioButton_Tax1.AutoSize = true;
            this.radioButton_Tax1.Checked = true;
            this.radioButton_Tax1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Tax1.Location = new System.Drawing.Point(6, 14);
            this.radioButton_Tax1.Name = "radioButton_Tax1";
            this.radioButton_Tax1.Size = new System.Drawing.Size(54, 17);
            this.radioButton_Tax1.TabIndex = 31;
            this.radioButton_Tax1.TabStop = true;
            this.radioButton_Tax1.Text = "الكـــل";
            this.radioButton_Tax1.UseVisualStyleBackColor = true;
            // 
            // radioButton_Tax2
            // 
            this.radioButton_Tax2.AutoSize = true;
            this.radioButton_Tax2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Tax2.Location = new System.Drawing.Point(74, 14);
            this.radioButton_Tax2.Name = "radioButton_Tax2";
            this.radioButton_Tax2.Size = new System.Drawing.Size(82, 17);
            this.radioButton_Tax2.TabIndex = 30;
            this.radioButton_Tax2.Text = "بدون الضريبة";
            this.radioButton_Tax2.UseVisualStyleBackColor = true;
            // 
            // radioButton_Tax0
            // 
            this.radioButton_Tax0.AutoSize = true;
            this.radioButton_Tax0.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Tax0.Location = new System.Drawing.Point(186, 14);
            this.radioButton_Tax0.Name = "radioButton_Tax0";
            this.radioButton_Tax0.Size = new System.Drawing.Size(61, 17);
            this.radioButton_Tax0.TabIndex = 29;
            this.radioButton_Tax0.Text = "بالضريبة";
            this.radioButton_Tax0.UseVisualStyleBackColor = true;
            // 
            // CmbDeleted
            // 
            this.CmbDeleted.BackColor = System.Drawing.Color.Transparent;
            this.CmbDeleted.Controls.Add(this.radioButton_Del1);
            this.CmbDeleted.Controls.Add(this.radioButton_Del2);
            this.CmbDeleted.Controls.Add(this.radioButton_Del0);
            this.CmbDeleted.Location = new System.Drawing.Point(304, 282);
            this.CmbDeleted.Name = "CmbDeleted";
            this.CmbDeleted.Size = new System.Drawing.Size(254, 40);
            this.CmbDeleted.TabIndex = 6730;
            this.CmbDeleted.TabStop = false;
            this.CmbDeleted.Tag = " T_INVHED.IfDel ";
            // 
            // radioButton_Del1
            // 
            this.radioButton_Del1.AutoSize = true;
            this.radioButton_Del1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Del1.Location = new System.Drawing.Point(-60, 23);
            this.radioButton_Del1.Name = "radioButton_Del1";
            this.radioButton_Del1.Size = new System.Drawing.Size(54, 17);
            this.radioButton_Del1.TabIndex = 28;
            this.radioButton_Del1.Text = "الكـــل";
            this.radioButton_Del1.UseVisualStyleBackColor = true;
            this.radioButton_Del1.Visible = false;
            // 
            // radioButton_Del2
            // 
            this.radioButton_Del2.AutoSize = true;
            this.radioButton_Del2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Del2.Location = new System.Drawing.Point(67, 15);
            this.radioButton_Del2.Name = "radioButton_Del2";
            this.radioButton_Del2.Size = new System.Drawing.Size(89, 17);
            this.radioButton_Del2.TabIndex = 27;
            this.radioButton_Del2.Text = "المحذوفة فقط";
            this.radioButton_Del2.UseVisualStyleBackColor = true;
            // 
            // radioButton_Del0
            // 
            this.radioButton_Del0.AutoSize = true;
            this.radioButton_Del0.Checked = true;
            this.radioButton_Del0.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Del0.Location = new System.Drawing.Point(163, 15);
            this.radioButton_Del0.Name = "radioButton_Del0";
            this.radioButton_Del0.Size = new System.Drawing.Size(84, 17);
            this.radioButton_Del0.TabIndex = 26;
            this.radioButton_Del0.TabStop = true;
            this.radioButton_Del0.Text = "الغير محذوفة";
            this.radioButton_Del0.UseVisualStyleBackColor = true;
            // 
            // CmbReturn
            // 
            this.CmbReturn.BackColor = System.Drawing.Color.Transparent;
            this.CmbReturn.Controls.Add(this.radioButton_ِReturn1);
            this.CmbReturn.Controls.Add(this.radioButton_ِReturn2);
            this.CmbReturn.Controls.Add(this.radioButton_ِReturn0);
            this.CmbReturn.Location = new System.Drawing.Point(304, 319);
            this.CmbReturn.Name = "CmbReturn";
            this.CmbReturn.Size = new System.Drawing.Size(254, 40);
            this.CmbReturn.TabIndex = 6731;
            this.CmbReturn.TabStop = false;
            this.CmbReturn.Tag = " T_INVHED.IfRet ";
            // 
            // radioButton_ِReturn1
            // 
            this.radioButton_ِReturn1.AutoSize = true;
            this.radioButton_ِReturn1.Checked = true;
            this.radioButton_ِReturn1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_ِReturn1.Location = new System.Drawing.Point(6, 14);
            this.radioButton_ِReturn1.Name = "radioButton_ِReturn1";
            this.radioButton_ِReturn1.Size = new System.Drawing.Size(54, 17);
            this.radioButton_ِReturn1.TabIndex = 31;
            this.radioButton_ِReturn1.TabStop = true;
            this.radioButton_ِReturn1.Text = "الكـــل";
            this.radioButton_ِReturn1.UseVisualStyleBackColor = true;
            // 
            // radioButton_ِReturn2
            // 
            this.radioButton_ِReturn2.AutoSize = true;
            this.radioButton_ِReturn2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_ِReturn2.Location = new System.Drawing.Point(69, 14);
            this.radioButton_ِReturn2.Name = "radioButton_ِReturn2";
            this.radioButton_ِReturn2.Size = new System.Drawing.Size(87, 17);
            this.radioButton_ِReturn2.TabIndex = 30;
            this.radioButton_ِReturn2.Text = "المرتجعة فقط";
            this.radioButton_ِReturn2.UseVisualStyleBackColor = true;
            // 
            // radioButton_ِReturn0
            // 
            this.radioButton_ِReturn0.AutoSize = true;
            this.radioButton_ِReturn0.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_ِReturn0.Location = new System.Drawing.Point(165, 14);
            this.radioButton_ِReturn0.Name = "radioButton_ِReturn0";
            this.radioButton_ِReturn0.Size = new System.Drawing.Size(82, 17);
            this.radioButton_ِReturn0.TabIndex = 29;
            this.radioButton_ِReturn0.Text = "الغير مرتجعة";
            this.radioButton_ِReturn0.UseVisualStyleBackColor = true;
            // 
            // checkBox_DatePay
            // 
            this.checkBox_DatePay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkBox_DatePay.Location = new System.Drawing.Point(169, 375);
            this.checkBox_DatePay.Name = "checkBox_DatePay";
            this.checkBox_DatePay.Size = new System.Drawing.Size(129, 20);
            this.checkBox_DatePay.TabIndex = 6743;
            this.checkBox_DatePay.Text = "بتاريخ الاستحقاق";
            this.checkBox_DatePay.UseVisualStyleBackColor = true;
            this.checkBox_DatePay.CheckedChanged += new System.EventHandler(this.checkBox_DatePay_CheckedChanged);
            // 
            // netResize1
            // 
            this.netResize1.ParentControl = this;
            // 
            // FRInvoice
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(562, 479);
            this.Controls.Add(this.PanelSpecialContainer);
            this.Icon = global::InvAcc.Properties.Resources.favicon;
            this.KeyPreview = true;
            this.Name = "FRInvoice";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.FRInvoice_Activated);
            this.Load += new System.EventHandler(this.FRInvoice_Load);
            this.Shown += new System.EventHandler(this.FRInvoice_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.PanelSpecialContainer.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            this.ribbonBar1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButExit)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox_Date.ResumeLayout(false);
            this.groupBox_Date.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlexType)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox_OrderTyp.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.CmbDeleted.ResumeLayout(false);
            this.CmbDeleted.PerformLayout();
            this.CmbReturn.ResumeLayout(false);
            this.CmbReturn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);
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
                this.ButOk.Text = (VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0" ? "Print F5" : "Show F5");
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
                this.ButOk.Text = (VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0" ? "طبـــاعة F5" : "عــــرض F5");
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
        private void FRInvoice_Shown(object sender, EventArgs e)
        {
        }
        private void FRInvoice_Activated(object sender, EventArgs e)
        {
            FrmInvSale_Shown(null, null);
        }
    }
}
