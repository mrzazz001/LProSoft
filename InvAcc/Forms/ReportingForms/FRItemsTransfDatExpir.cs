using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Framework.Date;
using Framework.UI;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using Library.RepShow;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FRItemsTransfDatExpir : Form
    { void avs(int arln)

{ 
  label13.Text=   (arln == 0 ? "  نـوع الفــاتورة :  " : "  Invoice type:") ; label11.Text=   (arln == 0 ? "  التصنيـــــــف :  " : "  Classification:") ; label10.Text=   (arln == 0 ? "  الصنــــــــــف :  " : "  Category:") ; label9.Text=   (arln == 0 ? "  المستخـــدم :  " : "  User:") ; label7.Text=   (arln == 0 ? "  المنـــــــدوب :  " : "  Delegate:") ; label6.Text=   (arln == 0 ? "  المــــــــــورد :  " : "  Supplier:") ; label5.Text=   (arln == 0 ? "  العميـــــــــل :  " : "  Customer:") ; groupBox3.Text=   (arln == 0 ? "  حسب رقم الفاتورة  " : "  According to the invoice number") ; label1.Text=   (arln == 0 ? "  مـــــن :  " : "  from:") ; label2.Text=   (arln == 0 ? "  إلـــــى :  " : "  to:") ; groupBox_Date.Text=   (arln == 0 ? "  حسب تاريخ الفاتورة  " : "  According to the invoice date") ; label3.Text=   (arln == 0 ? "  مـــــن :  " : "  from:") ; label4.Text=   (arln == 0 ? "  إلـــــى :  " : "  to:") ; label22.Text=   (arln == 0 ? "  طريقة الدفــــع  " : "  Payment method") ; label8.Text=   (arln == 0 ? "  مركز التكلفة :  " : "  cost center:") ; label14.Text=   (arln == 0 ? "  تاريخ صلاحية :  " : "  Expiry date:") ; label12.Text=   (arln == 0 ? "  رقـم التصنيـع :  " : "  Manufacture Number:") ; groupBox_ExpirDate.Text=   (arln == 0 ? "  حسب تاريخ الصلاحية   " : "  According to the expiration date") ; label15.Text=   (arln == 0 ? "  مـــــن :  " : "  from:") ; label16.Text=   (arln == 0 ? "  إلـــــى :  " : "  to:") ; radioButton_Del1.Text=   (arln == 0 ? "  الكـــل  " : "  the whole") ; radioButton_Del2.Text=   (arln == 0 ? "  المحذوفة فقط  " : "  only deleted") ; radioButton_Del0.Text=   (arln == 0 ? "  الغير محذوفة  " : "  not deleted") ; radioButton__0650Return1.Text=   (arln == 0 ? "  الكـــل  " : "  the whole") ; radioButton__0650Return2.Text=   (arln == 0 ? "  المرتجعة فقط  " : "  Returns only") ; radioButton__0650Return0.Text=   (arln == 0 ? "  الغير مرتجعة  " : "  non-refundable") ;}
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
        private class Item
        {
            public string Name;
            public int Value;
            public Item(string name, int value)
            {
                Name = name;
                Value = value;
            }
            public override string ToString()
            {
                return Name;
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
                        frm.Repvalue = "ItemTransExpirDat";
                        frm.Repvalue = "ItemTransExpirDat";
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
        private Label label11;
        private ButtonX button_SrchItemGroup;
        private TextBox txtClassName;
        private TextBox txtClassNo;
        private Label label10;
        private ButtonX button_SrchItemNo;
        private TextBox txtItemName;
        private TextBox txtItemNo;
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
        private MaskedTextBox txtMFromDate;
        private Label label22;
        private C1FlexGrid FlexType;
        private Label label3;
        private Label label4;
        private ComboBoxEx combobox_SortTyp;
        private ComboBoxEx CmbInvType;
        private ComboBoxEx combobox_RunNo;
        private Label label12;
        private ComboBoxEx combobox_RunDateExpir;
        private Label label14;
        private ComboBoxEx combobox_ExpirRunNo;
        private ComboBoxEx combobox_DateExpir;
        private Label label13;
        private GroupBox groupBox_ExpirDate;
        private Label label15;
        private Label label16;
        private MaskedTextBox txtMToDateExpir;
        private MaskedTextBox txtMFromDateExpir;
        private int LangArEn = 0;
        private T_User _User = new T_User();
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private Stock_DataDataContext dbInstance;
        private C1.Win.C1Input.C1Button ButOk;
        private C1.Win.C1Input.C1Button ButExit;
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
        public FRItemsTransfDatExpir()
        {
            InitializeComponent();this.Load += langloads;
            _User = dbc.StockUser(VarGeneral.UserNumber);
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
                        txtCostNo.Visible = true;
                        button_SrchCostNo.Visible = true;
                        txtCostName.Visible = true;
                    }
                    else
                    {
                        label8.Visible = false;
                        txtCostNo.Visible = false;
                        button_SrchCostNo.Visible = false;
                        txtCostName.Visible = false;
                    }
                }
            }
            catch
            {
            }
            listInvSetting = (from er in db.T_INVSETTINGs
                              where er.InvID == 1 || er.InvID == 2 || er.InvID == 3 || er.InvID == 4 || er.InvID == 5 || er.InvID == 6 || er.InvID == 7 || er.InvID == 8 || er.InvID == 9 || er.InvID == 10 || er.InvID == 14 || er.InvID == 17 || er.InvID == 20
                              orderby er.InvID
                              select er).ToList();
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptWaterPackages.dll"))
            {
                listInvSetting = db.T_INVSETTINGs.Where((T_INVSETTING t) => t.InvID == 1 || t.InvID == 2 || t.InvID == 3 || t.InvID == 4 || t.InvID == 5 || t.InvID == 6 || t.InvID == 7 || t.InvID == 8 || t.InvID == 9 || t.InvID == 10 || t.InvID == 14).ToList();
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRItemsTransfDatExpir));
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
            FillFlex();
            RibunButtons();
            FillCombo();
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptMaintenanceCars.dll"))
            {
                label7.Text = ((LangArEn == 0) ? "نوع السيارة :" : "Car Type :");
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptBus.dll"))
            {
                label7.Text = ((LangArEn == 0) ? "السائق :" : "Driver :");
            }
             avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRItemsTransfDatExpir));
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
            RibunButtons();
            FillCombo();
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
                if (VarGeneral.InvType == 1)
                {
                    Text = "تقرير حركة صنف في فاتورة مبيعات";
                }
                else if (VarGeneral.InvType == 2)
                {
                    Text = "تقرير حركة صنف في فاتورة فاتورة مشتريات";
                }
                else if (VarGeneral.InvType == 3)
                {
                    Text = "تقرير حركة صنف في مرتجع مبيعات";
                }
                else if (VarGeneral.InvType == 4)
                {
                    Text = "تقرير حركة صنف في فاتورة مرتجع مشتريات";
                }
                else if (VarGeneral.InvType == 5)
                {
                    Text = "تقرير حركة صنف في فاتورة إدخال بضاعة";
                    FlexType.Rows.Count = 1;
                    FlexType.SetData(0, 0, true);
                    FlexType.SetData(0, 1, "سند");
                }
                else if (VarGeneral.InvType == 6)
                {
                    Text = "تقرير حركة صنف في فاتورة إخراج بضاعة";
                    FlexType.Rows.Count = 1;
                    FlexType.SetData(0, 0, true);
                    FlexType.SetData(0, 1, "سند");
                }
                else if (VarGeneral.InvType == 7)
                {
                    Text = "تقرير حركة صنف في فاتورة عرض سعر للعملاء";
                }
                else if (VarGeneral.InvType == 8)
                {
                    Text = "تقرير حركة صنف في فاتورة عرض سعر للموردين";
                }
                else if (VarGeneral.InvType == 9)
                {
                    Text = "تقرير حركة صنف في فاتورة طلب شراء";
                }
                else if (VarGeneral.InvType == 10)
                {
                    Text = "تقرير حركة صنف في فاتورة تسوية البضاعة";
                    FlexType.Rows.Count = 1;
                    FlexType.SetData(0, 0, true);
                    FlexType.SetData(0, 1, "سند");
                }
                else if (VarGeneral.InvType == 14)
                {
                    Text = "تقرير حركة صنف في فاتورة بضاعة اول المدة";
                    FlexType.Rows.Count = 1;
                    FlexType.SetData(0, 0, true);
                    FlexType.SetData(0, 1, "سند");
                }
                else if (VarGeneral.InvType == 17)
                {
                    Text = "تقرير حركة صنف في فاتورة صرف بضاعة";
                    FlexType.Rows.Count = 1;
                    FlexType.SetData(0, 0, true);
                    FlexType.SetData(0, 1, "سند");
                }
                else if (VarGeneral.InvType == 20)
                {
                    Text = "تقرير حركة صنف في فاتورة مرتجع صرف بضاعة";
                    FlexType.Rows.Count = 1;
                    FlexType.SetData(0, 0, true);
                    FlexType.SetData(0, 1, "سند");
                }
            }
            else
            {
                FlexType.Rows.Count = 3;
                FlexType.SetData(0, 0, true);
                FlexType.SetData(0, 1, "Cash");
                FlexType.SetData(1, 0, true);
                FlexType.SetData(1, 1, "Credit");
                FlexType.SetData(2, 0, true);
                FlexType.SetData(2, 1, "Network");
                if (VarGeneral.InvType == 1)
                {
                    Text = "Sales Invoice Report";
                }
                else if (VarGeneral.InvType == 2)
                {
                    Text = "Purchase Invoice Report";
                }
                else if (VarGeneral.InvType == 3)
                {
                    Text = "Sales Return Report";
                }
                else if (VarGeneral.InvType == 4)
                {
                    Text = "Purchase Return Report";
                }
                else if (VarGeneral.InvType == 5)
                {
                    Text = "Transfer In Report";
                    FlexType.Rows.Count = 1;
                    FlexType.SetData(0, 0, true);
                    FlexType.SetData(0, 1, "Receipt");
                }
                else if (VarGeneral.InvType == 6)
                {
                    Text = "Transfer Out Report";
                    FlexType.Rows.Count = 1;
                    FlexType.SetData(0, 0, true);
                    FlexType.SetData(0, 1, "Receipt");
                }
                else if (VarGeneral.InvType == 7)
                {
                    Text = "Customer Qutation Report";
                }
                else if (VarGeneral.InvType == 8)
                {
                    Text = "Supplier Qutation Report";
                }
                else if (VarGeneral.InvType == 9)
                {
                    Text = "Purchase Order Report";
                }
                else if (VarGeneral.InvType == 10)
                {
                    Text = "Stock Adjustment Report";
                    FlexType.Rows.Count = 1;
                    FlexType.SetData(0, 0, true);
                    FlexType.SetData(0, 1, "Receipt");
                }
                else if (VarGeneral.InvType == 14)
                {
                    Text = "Open Quantities Report";
                    FlexType.Rows.Count = 1;
                    FlexType.SetData(0, 0, true);
                    FlexType.SetData(0, 1, "Receipt");
                }
                else if (VarGeneral.InvType == 17)
                {
                    Text = "Payment Order Report";
                    FlexType.Rows.Count = 1;
                    FlexType.SetData(0, 0, true);
                    FlexType.SetData(0, 1, "Receipt");
                }
                else if (VarGeneral.InvType == 20)
                {
                    Text = "Payment Order Return Report";
                    FlexType.Rows.Count = 1;
                    FlexType.SetData(0, 0, true);
                    FlexType.SetData(0, 1, "Receipt");
                }
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptSchool.dll"))
            {
                label5.Text = ((LangArEn == 0) ? "الطـالـب :" : "Student Acc :");
                if (VarGeneral.InvType == 7)
                {
                    Text = ((LangArEn == 0) ? "تقرير حركة صنف في فاتورة عرض سعر للطلاب" : "Students Qutation Report");
                }
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptWaterPackages.dll"))
            {
                label5.Text = ((LangArEn == 0) ? "الســــــائــق :" : "Driver Acc :");
                label7.Text = ((LangArEn == 0) ? "العميــــــــل :" : "Customer :");
                label8.Text = ((LangArEn == 0) ? "السيــارة :" : "Car :");
                if (VarGeneral.InvType == 7)
                {
                    Text = ((LangArEn == 0) ? "تقرير فواتير عرض سعر السائقين" : "Drivers Qutation Reports");
                }
            }
            if (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", "").Trim() + "\\khalijwatania.dll") && VarGeneral.InvType == 1)
            {
                Text = ((LangArEn == 0) ? "تقرير حركة صنف في فاتورة الخدمة" : "Service Invoice Report");
            }
        }
        private string BuildRuleList()
        {
            HijriGregDates dateFormatter = new HijriGregDates();
            string Rule = "Where (T_INVDET.DatExper <> '' or T_INVDET.RunCod <> '') and T_INVHED.InvTyp = " + VarGeneral.InvType;
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
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptInv.dll") && VarGeneral.InvType == 1)
                {
                    Rule = Rule + " and  T_INVHED.UserNew  = '" + txtUserNo.Text.Trim() + "'";
                }
                else
                {
                    object obj = Rule;
                    Rule = string.Concat(obj, " and ", txtUserNo.Tag, " = '", txtUserNo.Text.Trim(), "'");
                }
            }
            if (!string.IsNullOrEmpty(txtItemNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtItemNo.Tag, " = '", txtItemNo.Text.Trim(), "'");
            }
            if (!string.IsNullOrEmpty(txtClassNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtClassNo.Tag, " = ", txtClassNo.Text.Trim());
            }
            if (VarGeneral.CheckDate(txtMFromDate.Text) && txtMFromDate.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMFromDate.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_INVHED.GDat  >= '" + dateFormatter.FormatGreg(txtMFromDate.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_INVHED.HDat  >= '" + dateFormatter.FormatHijri(txtMFromDate.Text, "yyyy/MM/dd") + "'"));
            }
            if (VarGeneral.CheckDate(txtMToDate.Text) && txtMToDate.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMToDate.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_INVHED.GDat  <= '" + dateFormatter.FormatGreg(txtMToDate.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_INVHED.HDat  <= '" + dateFormatter.FormatHijri(txtMToDate.Text, "yyyy/MM/dd") + "'"));
            }
            if (VarGeneral.CheckDate(txtMFromDateExpir.Text) && txtMFromDateExpir.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMFromDateExpir.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_INVDET.DatExper  >= '" + dateFormatter.FormatGreg(txtMFromDateExpir.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_INVDET.DatExper  >= '" + dateFormatter.FormatHijri(txtMFromDateExpir.Text, "yyyy/MM/dd") + "'"));
            }
            if (VarGeneral.CheckDate(txtMToDateExpir.Text) && txtMToDateExpir.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMToDateExpir.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_INVDET.DatExper  <= '" + dateFormatter.FormatGreg(txtMToDateExpir.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_INVDET.DatExper  <= '" + dateFormatter.FormatHijri(txtMToDateExpir.Text, "yyyy/MM/dd") + "'"));
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
            if (combobox_RunNo.SelectedIndex > 0)
            {
                if (combobox_RunDateExpir.SelectedIndex > 0)
                {
                    string text = Rule;
                    Rule = text + " and (T_QTYEXP.RunCod = '" + combobox_RunNo.Text + "' and T_QTYEXP.DatExper = '" + combobox_RunDateExpir.Text + "')";
                }
                else
                {
                    Rule = Rule + " and T_QTYEXP.RunCod = '" + combobox_RunNo.Text + "'";
                }
            }
            if (combobox_DateExpir.SelectedIndex > 0)
            {
                if (combobox_ExpirRunNo.SelectedIndex > 0)
                {
                    string text = Rule;
                    Rule = text + " and (T_QTYEXP.DatExper = '" + combobox_DateExpir.Text + "' and T_QTYEXP.RunCod = '" + combobox_ExpirRunNo.Text + "')";
                }
                else
                {
                    Rule = Rule + " and T_QTYEXP.DatExper = '" + combobox_DateExpir.Text + "'";
                }
            }
            int iiCnt = 0;
            string RuleInvType = ""; int rc = FlexType.Rows.Count; if (rc == 3) rc--;
            for (iiCnt = 0; iiCnt < rc; iiCnt++)
            {
                if ((bool)this.FlexType.GetData(iiCnt, 0))
                {
                    if (!string.IsNullOrEmpty(RuleInvType))
                    {
                        RuleInvType = string.Concat(RuleInvType, " or ");
                    }
                    object obj = RuleInvType;
                    object[] tag = new object[] { obj, this.FlexType.Tag, "  = ", iiCnt };
                    RuleInvType = string.Concat(tag);
                }
            }
            if (FlexType.Rows.Count == 3)
                if ((bool)this.FlexType.GetData(2, 0))
                {
                    object obj;// = //RuleInvType;
                    object[] tag;// = new object[] { obj,  " or T_INVHED.InvCash = 'الشبكة' or T_INVHED.InvCash = 'شبكـــة' or T_INVHED.InvCash = '  شبكـــة  ' " };
                    if (string.IsNullOrEmpty(RuleInvType))
                    {
                        obj = RuleInvType;
                        tag = new object[] { obj, this.FlexType.Tag, "  = ", iiCnt };
                        RuleInvType = string.Concat(tag);
                    }
                    obj = RuleInvType;
                    tag = new object[] { obj,  " or T_INVHED.InvCash = 'الشبكة' or T_INVHED.InvCash = 'شبكـــة' or T_INVHED.InvCash = '  شبكـــة  ' " };
                    RuleInvType = string.Concat(tag);
                }
            if (!string.IsNullOrEmpty(RuleInvType))
            {
                Rule = Rule + " and (" + RuleInvType + ")";
            }
            return Rule;
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (Text == "تقرير حركة صنف في فاتورة مبيعات" || Text == "Sales Invoice Report")
                {
                    VarGeneral.InvType = 1;
                }
                else if (Text == "تقرير حركة صنف في فاتورة فاتورة مشتريات" || Text == "Purchase Invoice Report")
                {
                    VarGeneral.InvType = 2;
                }
                else if (Text == "تقرير حركة صنف في مرتجع مبيعات" || Text == "Sales Return Report")
                {
                    VarGeneral.InvType = 3;
                }
                else if (Text == "تقرير حركة صنف في فاتورة مرتجع مشتريات" || Text == "Purchase Return Report")
                {
                    VarGeneral.InvType = 4;
                }
                else if (Text == "تقرير حركة صنف في فاتورة إدخال بضاعة" || Text == "Transfer In Report")
                {
                    VarGeneral.InvType = 5;
                }
                else if (Text == "تقرير حركة صنف في فاتورة إخراج بضاعة" || Text == "Transfer Out Report")
                {
                    VarGeneral.InvType = 6;
                }
                else if (Text == "تقرير حركة صنف في فاتورة عرض سعر للعملاء" || Text == "Customer Qutation Report")
                {
                    VarGeneral.InvType = 7;
                }
                else if (Text == "تقرير حركة صنف في فاتورة عرض سعر للموردين" || Text == "Supplier Qutation Report")
                {
                    VarGeneral.InvType = 8;
                }
                else if (Text == "تقرير حركة صنف في فاتورة طلب شراء" || Text == "Purchase Order Report")
                {
                    VarGeneral.InvType = 9;
                }
                else if (Text == "تقرير حركة صنف في فاتورة تسوية البضاعة" || Text == "Stock Adjustment Report")
                {
                    VarGeneral.InvType = 10;
                }
                else if (Text == "تقرير حركة صنف في فاتورة بضاعة اول المدة" || Text == "Open Quantities Report")
                {
                    VarGeneral.InvType = 14;
                }
                else if (Text == "تقرير حركة صنف في فاتورة صرف بضاعة" || Text == "Payment Order Report")
                {
                    VarGeneral.InvType = 17;
                }
                else if (Text == "تقرير حركة صنف في فاتورة مرتجع صرف بضاعة" || Text == "Payment Order Return Report")
                {
                    VarGeneral.InvType = 20;
                }
                if (Text == "تقرير حركة صنف في فاتورة عرض سعر للطلاب" || Text == "Students Qutation Report")
                {
                    VarGeneral.InvType = 7;
                }
                if (Text == "تقرير فواتير عرض سعر السائقين" || Text == "Drivers Qutation Reports")
                {
                    VarGeneral.InvType = 7;
                }
                if (Text == "تقرير حركة صنف في فاتورة الخدمة" || Text == "Service Invoice Report")
                {
                    VarGeneral.InvType = 1;
                }
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = "T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_QTYEXP On (T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper) LEFT OUTER JOIN T_SYSSETTING ON T_Items.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                string Fields = "";
                Fields = ((LangArEn != 0) ? (" InvDet_ID,T_Items.Itm_No,T_Items.Eng_Des as itemNm,T_Category.Eng_Des as CategoyNm,T_InvDet.StoreNo,T_InvDet.ItmUntE as UnitNm,T_InvDet.ItmUntPak,(Round(T_InvDet.Price," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Price,T_InvDet.ItmDis,Abs(T_InvDet.Qty) as Qty,(Round(T_InvDet.Amount," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Amount,T_INVHED.InvNo, T_INVSETTING.InvNamE as InvTypNm,T_INVHED.InvCash,T_Curency.Eng_Des as CurrnceyNm,T_INVHED.GadeNo,T_INVHED.CusVenNo,T_INVHED.CusVenNm,T_INVHED.GDat,T_INVHED.HDat,T_CstTbl.Eng_Des as CostCenteNm, T_Mndob.Eng_Des as MndNm,T_INVHED.RetNo,T_SYSSETTING.LogImg ,(Round(T_InvDet.Amount - (T_InvDet.Cost * ABS(RealQty))," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Profit,T_InvDet.Cost as Cost,T_QTYEXP.DatExper,T_QTYEXP.RunCod,T_QTYEXP.stkQty") : (" InvDet_ID,T_Items.Itm_No,T_Items.Arb_Des as itemNm,T_Category.Arb_Des as CategoyNm,T_InvDet.StoreNo,T_InvDet.ItmUnt as UnitNm,T_InvDet.ItmUntPak,(Round(T_InvDet.Price," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Price,T_InvDet.ItmDis,Abs(T_InvDet.Qty) as Qty,(Round(T_InvDet.Amount," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Amount,T_INVHED.InvNo, T_INVSETTING.InvNamA as InvTypNm,T_INVHED.InvCash,T_Curency.Arb_Des as CurrnceyNm,T_INVHED.GadeNo,T_INVHED.CusVenNo,T_INVHED.CusVenNm,T_INVHED.GDat,T_INVHED.HDat,T_CstTbl.Arb_Des as CostCenteNm, T_Mndob.Arb_Des as MndNm,T_INVHED.RetNo,T_SYSSETTING.LogImg,(Round(T_InvDet.Amount - (T_InvDet.Cost * ABS(RealQty))," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Profit,T_InvDet.Cost as Cost,T_QTYEXP.DatExper,T_QTYEXP.RunCod,T_QTYEXP.stkQty"));
                _RepShow.Rule = BuildRuleList() + ((combobox_SortTyp.SelectedIndex == 0) ? " order by T_INVHED.InvHed_ID " : " order by T_INVHED.GDat ");
                _RepShow.Fields = Fields;
                try
                {
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                    try
                    {
                        if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 15))
                        {
                            _RepShow = new RepShow();
                            _RepShow.Rule = "";
                            _RepShow.Tables = "T_SINVDET LEFT OUTER JOIN T_INVHED ON T_SINVDET.SInvIdHEAD = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_SINVDET.SItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                            {
                                _RepShow.Fields = " SInvId as InvDet_ID,T_Items.Itm_No,T_Items.Arb_Des as itemNm,T_Category.Arb_Des as CategoyNm,T_SINVDET.SStoreNo as StoreNo,T_SINVDET.SItmUnt as UnitNm,T_SINVDET.SItmUntPak as ItmUntPak,(Round(T_SINVDET.SPrice," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Price,T_SINVDET.SItmDis as ItmDis,Abs(T_SINVDET.SQty) as Qty,(Round(T_SINVDET.SAmount," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Amount,T_INVHED.InvNo, T_INVSETTING.InvNamA as InvTypNm,T_INVHED.InvCash,T_Curency.Arb_Des as CurrnceyNm,T_INVHED.GadeNo,T_INVHED.CusVenNo,T_INVHED.CusVenNm,T_INVHED.GDat,T_INVHED.HDat,T_CstTbl.Arb_Des as CostCenteNm, T_Mndob.Arb_Des as MndNm,T_INVHED.RetNo,T_SYSSETTING.LogImg,(Round(T_SINVDET.SAmount - (T_SINVDET.SCost * Abs(T_SINVDET.SRealQty))," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Profit ,T_SINVDET.SCost as SCost";
                            }
                            else
                            {
                                _RepShow.Fields = " SInvId as InvDet_ID,T_Items.Itm_No,T_Items.Eng_Des as itemNm,T_Category.Eng_Des as CategoyNm,T_SINVDET.SStoreNo as StoreNo,T_SINVDET.SItmUntE as UnitNm,T_SINVDET.SItmUntPak as ItmUntPak,(Round(T_SINVDET.SPrice," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Price,T_SINVDET.SItmDis as ItmDis,Abs(T_SINVDET.SQty) as Qty,(Round(T_SINVDET.SAmount," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Amount,T_INVHED.InvNo, T_INVSETTING.InvNamE as InvTypNm,T_INVHED.InvCash,T_Curency.Eng_Des as CurrnceyNm,T_INVHED.GadeNo,T_INVHED.CusVenNo,T_INVHED.CusVenNm,T_INVHED.GDat,T_INVHED.HDat,T_CstTbl.Eng_Des as CostCenteNm, T_Mndob.Eng_Des as MndNm,T_INVHED.RetNo,T_SYSSETTING.LogImg ,(Round(T_SINVDET.SAmount - (T_SINVDET.SCost * Abs(T_SINVDET.SRealQty))," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Profit,T_SINVDET.SCost as SCost";
                            }
                            _RepShow.Rule = BuildRuleList();
                            _RepShow = _RepShow.Save();
                            VarGeneral.RepData.Tables[0].Merge(_RepShow.RepData.Tables[0]);
                        }
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
                    return;
                }
                try
                {
                    VarGeneral.IsGeneralUsed = true;
                    FrmReportsViewer frm = new FrmReportsViewer();
                    frm.Repvalue = "ItemTransExpirDat";
                    frm.Tag = LangArEn;
                    frm.Repvalue = "ItemTransExpirDat";
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
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ButExit.Text = "خــــروج Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.ISdirectPrinting) ? "طبـــاعة F5" : "عــــرض F5");
                groupBox3.Text = "حسب رقم الفاتورة";
                groupBox_Date.Text = "حسب تاريخ الفاتورة";
                groupBox_ExpirDate.Text = "حسب تاريخ الصلاحية";
                label1.Text = "مـــــن :";
                label2.Text = "إلـــــى :";
                label3.Text = "مـــــن :";
                label4.Text = "إلـــــى :";
                label5.Text = "العميـــــــــل :";
                label6.Text = "المــــــــــورد :";
                label7.Text = "المنـــــــدوب :";
                label8.Text = "مركز التكلفة :";
                label9.Text = "المستخـــدم :";
                label10.Text = "الصنــــــــــف :";
                label11.Text = "التصنيـــــــف :";
                label22.Text = "طريقة الدفع";
                radioButton_Del0.Text = "الغير محذوفة";
                radioButton_Del1.Text = "الكـــل";
                radioButton_Del2.Text = "المحذوفة فقط";
                radioButton__0650Return0.Text = "الغير مرتجعة";
                radioButton__0650Return1.Text = "الكـــل";
                radioButton__0650Return2.Text = "المرتجعة فقط";
            }
            else
            {
                ButExit.Text = "Exit Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.ISdirectPrinting) ? "Print F5" : "Show F5");
                groupBox3.Text = "Invoice No";
                groupBox_Date.Text = "Invoice Date";
                groupBox_ExpirDate.Text = "Expir Date";
                label1.Text = "From :";
                label2.Text = "To :";
                label3.Text = "From :";
                label4.Text = "To :";
                label5.Text = "Customer :";
                label6.Text = "Supplier :";
                label7.Text = "Delegate :";
                label8.Text = "Cost Center :";
                label9.Text = "User :";
                label10.Text = "Item :";
                label11.Text = "Category :";
                label22.Text = "Payment method";
                radioButton_Del0.Text = "Non-Deleted";
                radioButton_Del1.Text = "ALL";
                radioButton_Del2.Text = "Deleted Only";
                radioButton__0650Return0.Text = "Non-Return";
                radioButton__0650Return1.Text = "ALL";
                radioButton__0650Return2.Text = "Return Only";
            }
        }
        private void FRItemsTransfDatExpir_Load(object sender, EventArgs e)
        {
        }
        public void FillCombo()
        {
            combobox_SortTyp.Items.Clear();
            combobox_SortTyp.Items.Add((LangArEn == 0) ? "رقم الفاتورة" : "Invoice No");
            combobox_SortTyp.Items.Add((LangArEn == 0) ? "تاريخ الفاتورة" : "Invoice Date");
            combobox_SortTyp.SelectedIndex = 0;
            CmbInvType.Items.Clear();
            CmbInvType.DataSource = listInvSetting;
            CmbInvType.DisplayMember = ((LangArEn == 0) ? "InvNamA" : "InvNamE");
            CmbInvType.ValueMember = "InvID";
            CmbInvType.SelectedIndex = 0;
            List<string> listRunCod = db.ExecuteQuery<string>("select distinct RunCod from T_QTYEXP where T_QTYEXP.RunCod != '' order by RunCod", new object[0]).ToList();
            listRunCod.Insert(0, "");
            combobox_RunNo.DataSource = listRunCod;
            combobox_RunNo.SelectedIndex = 0;
            List<string> listDateExpir = db.ExecuteQuery<string>("select distinct DatExper from T_QTYEXP where T_QTYEXP.DatExper != '' order by DatExper", new object[0]).ToList();
            listDateExpir.Insert(0, "");
            combobox_DateExpir.DataSource = listDateExpir;
            combobox_DateExpir.SelectedIndex = 0;
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
        private void button_SrchLegNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("Mnd_No", new ColumnDictinary("الــرقم", "No", ifDefault: true, ""));
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
                txtUserNo.Text = frm.Serach_No;
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
        private void button_SrchItemNo_Click(object sender, EventArgs e)
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
                txtItemNo.Text = frm.Serach_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtItemName.Text = db.StockItem(frm.Serach_No).Arb_Des.ToString();
                }
                else
                {
                    txtItemName.Text = db.StockItem(frm.Serach_No).Eng_Des.ToString();
                }
            }
            else
            {
                txtItemNo.Text = "";
                txtItemName.Text = "";
            }
        }
        private void button_SrchItemGroup_Click(object sender, EventArgs e)
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
                txtClassNo.Text = db.StockCat(frm.Serach_No).CAT_ID.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtClassName.Text = db.StockCat(frm.Serach_No).Arb_Des;
                }
                else
                {
                    txtClassName.Text = db.StockCat(frm.Serach_No).Eng_Des;
                }
            }
            else
            {
                txtClassNo.Text = "";
                txtClassName.Text = "";
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
        private void CmbInvType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                VarGeneral.InvType = int.Parse(CmbInvType.SelectedValue.ToString());
            }
            catch
            {
                VarGeneral.InvType = 1;
            }
            FillFlex();
        }
        private void combobox_DateExpir_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combobox_ExpirRunNo.DataSource = null;
                if (combobox_DateExpir.SelectedIndex > 0)
                {
                    combobox_ExpirRunNo.Enabled = true;
                    List<T_QTYEXP> listDateExpir = new List<T_QTYEXP>(db.T_QTYEXPs.Where((T_QTYEXP item) => item.DatExper == combobox_DateExpir.Text)).ToList();
                    listDateExpir.Insert(0, new T_QTYEXP());
                    listDateExpir[0].RunCod = ((LangArEn == 0) ? "----------أرقام التصنيع----------" : "----------Make No----------");
                    combobox_ExpirRunNo.DataSource = listDateExpir;
                    combobox_ExpirRunNo.DisplayMember = "RunCod";
                    combobox_ExpirRunNo.ValueMember = "RunCod";
                    combobox_ExpirRunNo.SelectedIndex = 0;
                }
                else
                {
                    combobox_ExpirRunNo.Enabled = false;
                }
            }
            catch
            {
                combobox_ExpirRunNo.DataSource = null;
            }
        }
        private void combobox_RunNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combobox_RunDateExpir.DataSource = null;
                if (combobox_RunNo.SelectedIndex > 0)
                {
                    combobox_RunDateExpir.Enabled = true;
                    List<T_QTYEXP> listDateExpir = new List<T_QTYEXP>(db.T_QTYEXPs.Where((T_QTYEXP item) => item.RunCod == combobox_RunNo.Text)).ToList();
                    listDateExpir.Insert(0, new T_QTYEXP());
                    listDateExpir[0].DatExper = ((LangArEn == 0) ? "----------تــواريـخ الصلاحية----------" : "----------Expir Date----------");
                    combobox_RunDateExpir.DataSource = listDateExpir;
                    combobox_RunDateExpir.DisplayMember = "DatExper";
                    combobox_RunDateExpir.ValueMember = "DatExper";
                    combobox_RunDateExpir.SelectedIndex = 0;
                }
                else
                {
                    combobox_RunDateExpir.Enabled = false;
                }
            }
            catch
            {
                combobox_RunDateExpir.DataSource = null;
            }
        }
        private void txtMFromDateExpir_Click(object sender, EventArgs e)
        {
            txtMFromDateExpir.SelectAll();
        }
        private void txtMToDateExpir_Click(object sender, EventArgs e)
        {
            txtMToDateExpir.SelectAll();
        }
        private void txtMFromDateExpir_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtMFromDateExpir.Text))
                {
                    txtMFromDateExpir.Text = Convert.ToDateTime(txtMFromDateExpir.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    txtMFromDateExpir.Text = "";
                }
            }
            catch
            {
                txtMFromDateExpir.Text = "";
            }
        }
        private void txtMToDateExpir_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtMToDateExpir.Text))
                {
                    txtMToDateExpir.Text = Convert.ToDateTime(txtMToDateExpir.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    txtMToDateExpir.Text = "";
                }
            }
            catch
            {
                txtMToDateExpir.Text = "";
            }
        }
        private void txtMFromNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void txtMIntoNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
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
        private void ButOk_MouseLeave(object sender, EventArgs e)
        {
            ButOk.BackgroundImage = Properties.Resources.print;
            ButOk.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void ButExit_MouseLeave(object sender, EventArgs e)
        {
            ButExit.BackgroundImage = Properties.Resources.YALO2;
            ButExit.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void CmbDeleted_Enter(object sender, EventArgs e)
        {
        }
        private void radioButton__0650Return2_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
