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
    public partial  class FRItemsData : Form
    { void avs(int arln)

{ 
  checkBox_OtherPrices.Text=   (arln == 0 ? "  تقرير بالأسعار الأخرى  " : "  Other prices report") ; label11.Text=   (arln == 0 ? "  حسب :  " : "  according to:") ; label10.Text=   (arln == 0 ? "  الوحــــــدة :  " : "  Unity:") ; label8.Text=   (arln == 0 ? "  المــــورد :  " : "  Supplier:") ; label5.Text=   (arln == 0 ? "  من صنف :  " : "  of class:") ; label9.Text=   (arln == 0 ? "  المستودع :  " : "  Warehouse:") ; label7.Text=   (arln == 0 ? "  التصنيـــف :  " : "  Classification:") ; label6.Text=   (arln == 0 ? "  إلى صنف :  " : "  to class:") ; groupBox_Date.Text=   (arln == 0 ? "  حسب تاريخ الركود  " : "  By date of recession") ; label3.Text=   (arln == 0 ? "  مـــــن :  " : "  from:") ; label4.Text=   (arln == 0 ? "  إلـــــى :  " : "  to:") ; groupBox3.Text=   (arln == 0 ? "  حسب الكمية  " : "  by quantity") ; label1.Text=   (arln == 0 ? "  مـــــن :  " : "  from:") ; label2.Text=   (arln == 0 ? "  إلـــــى :  " : "  to:") ;}
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
                        frm.Repvalue = "ItemsData";
                        frm.Repvalue = "ItemsData";
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
        private Label label4;
        private TextBox txtInItemName;
        private Label label3;
        private TextBox txtClassName;
        private MaskedTextBox txtMFromDate;
        private TextBox txtFItemName;
        private TextBox txtStoreName;
        private MaskedTextBox txtMIntoNo;
        private TextBox txtSuppName;
        private TextBox txtFItemNo;
        private TextBox txtInItemNo;
        private TextBox txtClassNo;
        private MaskedTextBox txtMFromNo;
        private TextBox txtStoreNo;
        private TextBox txtSuppNo;
        private MaskedTextBox txtMToDate;
        private Label label7;
        private Label label6;
        private ButtonX button_SrchStoreNo;
        private RibbonBar ribbonBar1;
        private ButtonX button_SrchSuppNo;
        private ButtonX button_SrchClassNo;
        private ButtonX button_SrchItemTo;
        private ButtonX button_SrchItemFrom;
        private GroupBox groupBox_Date;
        private GroupBox groupBox3;
        private Label label2;
        private C1FlexGrid FlexField;
        private Label label9;
        private Label label1;
        private Label label8;
        private Label label5;
        private Label label10;
        private ComboBoxEx combobox_Unit;
        private Label label11;
        private ComboBoxEx combobox_CostTyp;
        private CheckBox checkBox_OtherPrices;
        private int LangArEn = 0;
        private T_User _User = new T_User();
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
        public FRItemsData()
        {
            InitializeComponent();this.Load += langloads;
            _User = dbc.StockUser(VarGeneral.UserNumber);
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ButExit.Text = "خــــروج Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "طبـــاعة F5" : "عــــرض F5");
                groupBox3.Text = "حسب الكمية";
                groupBox_Date.Text = "حسب تاريخ الركود";
                label1.Text = "مـــــن :";
                label2.Text = "إلـــــى :";
                label3.Text = "مـــــن :";
                label4.Text = "إلـــــى :";
                label5.Text = "من صنف :";
                label6.Text = "إلى صنف :";
                label7.Text = "التصنيـــف :";
                label8.Text = "المــــورد :";
                label9.Text = "المستودع :";
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
                label7.Text = "Category :";
                label8.Text = "Supplier :";
                label9.Text = "Store :";
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRItemsData));
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
            FillCombo();
            RepDef();
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptInvitationCards.dll"))
            {
                label8.Text = ((LangArEn == 0) ? "العميــــل :" : "Customer :");
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptGlasses.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", "").Trim() + "\\SecriptGlasses.dll")))
            {
                checkBox_OtherPrices.Text = ((LangArEn == 0) ? "تقرير بمقاسات الأصناف" : "Items Sizes Report");
            }
            avs(VarGeneral.currentintlanguage);
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRItemsData));
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
            FillCombo();
            RepDef();
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
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                if (VarGeneral.InvType == 1)
                {
                    Text = "بيانات الأصناف";
                    groupBox_Date.Visible = false;
                    txtMFromDate.Visible = false;
                    txtMToDate.Visible = false;
                    checkBox_OtherPrices.Visible = true;
                }
                else if (VarGeneral.InvType == 2)
                {
                    Text = "بيانات الأصناف وكمياتها";
                    groupBox_Date.Visible = false;
                    txtMFromDate.Visible = false;
                    txtMToDate.Visible = false;
                }
                else if (VarGeneral.InvType == 3)
                {
                    Text = "بيانات الأصناف وتكلفتها";
                    groupBox_Date.Visible = false;
                    txtMFromDate.Visible = false;
                    txtMToDate.Visible = false;
                }
                else if (VarGeneral.InvType == 4)
                {
                    Text = "الأصناف الواجب توفرها";
                    groupBox_Date.Visible = false;
                    txtMFromDate.Visible = false;
                    txtMToDate.Visible = false;
                    FlexField.Tag = " and T_Items.OpenQty <= T_Items.QtyLvl and T_Items.QtyLvl != 0 ";
                }
                else if (VarGeneral.InvType == 5)
                {
                    Text = "الأصناف الراكدة";
                    groupBox3.Visible = false;
                }
            }
            else if (VarGeneral.InvType == 1)
            {
                Text = "Items Data";
                groupBox_Date.Visible = false;
                txtMFromDate.Visible = false;
                txtMToDate.Visible = false;
                checkBox_OtherPrices.Visible = true;
            }
            else if (VarGeneral.InvType == 2)
            {
                Text = "Items Quantities";
                groupBox_Date.Visible = false;
                txtMFromDate.Visible = false;
                txtMToDate.Visible = false;
            }
            else if (VarGeneral.InvType == 3)
            {
                Text = "Items Cost";
                groupBox_Date.Visible = false;
                txtMFromDate.Visible = false;
                txtMToDate.Visible = false;
            }
            else if (VarGeneral.InvType == 4)
            {
                Text = "Items Order";
                groupBox_Date.Visible = false;
                txtMFromDate.Visible = false;
                txtMToDate.Visible = false;
                FlexField.Tag = " and T_Items.OpenQty <= T_Items.QtyLvl and T_Items.QtyLvl != 0 ";
            }
            else if (VarGeneral.InvType == 5)
            {
                Text = "UnSale Items";
            }
            RibunButtons();
        }
        private string BuildFieldList()
        {
            string Fields = "";
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                if (VarGeneral.InvType == 1)
                {
                    Fields = "T_Items.Itm_No, T_Items.Arb_Des as itemNm,T_Category.Arb_Des as CategoyNm,T_STKSQTY.storeNo,T_Items.Price1,T_Items.Price2,T_Items.Price3,T_Items.Price4,T_Items.Price5,T_Items.BarCod1, (select Arb_Des from T_AccDef where AccDef_No = T_Items.DefultVendor) as DefultVendor";
                    if (checkBox_OtherPrices.Checked && File.Exists(Application.StartupPath + "\\Script\\SecriptGlasses.dll"))
                    {
                        Fields = "T_Items.Itm_No, T_Items.Arb_Des as itemNm,T_Items.vSize1 as CategoyNm,T_STKSQTY.storeNo,T_Items.vSize4 as Price1,T_Items.vSize3 as Price2,T_Items.vSize2 as Price3,T_Items.vSize5 as Price4,T_Items.vSize5 as Price5,T_Items.BarCod1";
                    }
                    Fields = ((combobox_Unit.SelectedIndex > 0) ? string.Concat(Fields, ",(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = ", combobox_Unit.SelectedValue, ") as  UnitNm,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack5) END as Pack1,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END  as UntPri1,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm5") : (Fields + ",(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNm,(SELECT " + ((LangArEn == 0) ? "T_Unit.Arb_Des" : "T_Unit.Eng_Des") + " FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit2) as  UnitNm2,(SELECT " + ((LangArEn == 0) ? "T_Unit.Arb_Des" : "T_Unit.Eng_Des") + " FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit3) as  UnitNm3,(SELECT " + ((LangArEn == 0) ? "T_Unit.Arb_Des" : "T_Unit.Eng_Des") + " FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit4) as  UnitNm4,(SELECT " + ((LangArEn == 0) ? "T_Unit.Arb_Des" : "T_Unit.Eng_Des") + " FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit5) as  UnitNm5,T_Items.Pack1,T_Items.Pack2,T_Items.Pack3,T_Items.Pack4,T_Items.Pack5 ,(Round(T_Items.UntPri1," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri1,(Round(T_Items.UntPri2," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri2,(Round(T_Items.UntPri3," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri3,(Round(T_Items.UntPri4," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri4,(Round(T_Items.UntPri5," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri5 "));
                }
                else if (VarGeneral.InvType == 2)
                {
                    Fields = "T_Items.Itm_No,T_Items.Arb_Des as itemNm, (select Arb_Des from T_AccDef where AccDef_No = T_Items.DefultVendor) as DefultVendor ,T_STKSQTY.storeNo ";
                    Fields = ((combobox_Unit.SelectedIndex > 0) ? string.Concat(Fields, ",(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = ", combobox_Unit.SelectedValue, ") as  UnitNm,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack5) END as Pack1,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END  as UntPri1,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm5,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END)END as stkQty ") : (Fields + ",(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNm,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit2) as  UnitNm2,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit3) as  UnitNm3,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit4) as  UnitNm4,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit5) as  UnitNm5,T_Items.Pack1,T_Items.Pack2,T_Items.Pack3,T_Items.Pack4,T_Items.Pack5 ,(Round(T_Items.UntPri1," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri1,(Round(T_Items.UntPri2," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri2,(Round(T_Items.UntPri3," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri3,(Round(T_Items.UntPri4," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri4,(Round(T_Items.UntPri5," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri5,CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END as stkQty,CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END as stkQty2,CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END as stkQty3,CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END as stkQty4,CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END as stkQty5 "));
                }
                else if (VarGeneral.InvType == 3)
                {
                    Fields = "T_Items.Itm_No,T_Items.Arb_Des as itemNm, (select Arb_Des from T_AccDef where AccDef_No = T_Items.DefultVendor) as DefultVendor ,T_STKSQTY.storeNo ";
                    Fields = ((combobox_Unit.SelectedIndex > 0) ? string.Concat(Fields, ",(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = ", combobox_Unit.SelectedValue, ") as  UnitNm,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack5) END as Pack1,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END  as UntPri1,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm5,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END)END as stkQty ,", (combobox_CostTyp.SelectedIndex == 4) ? string.Concat(" ( CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, "))  WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, "))  WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END ) as AvrageCost ") : string.Concat("  CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round((", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round((", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round((", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round((", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round((", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack5) END as AvrageCost"), ",(Round(T_STKSQTY.stkQty * (", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack1) as StockNet") : (Fields + ",(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNm,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit2) as  UnitNm2,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit3) as  UnitNm3,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit4) as  UnitNm4,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit5) as  UnitNm5,T_Items.Pack1,T_Items.Pack2,T_Items.Pack3,T_Items.Pack4,T_Items.Pack5 ,(Round(T_Items.UntPri1," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri1,(Round(T_Items.UntPri2," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri2,(Round(T_Items.UntPri3," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri3,(Round(T_Items.UntPri4," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri4,(Round(T_Items.UntPri5," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri5,CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END as stkQty,CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END as stkQty2,CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END as stkQty3,CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END as stkQty4,CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END as stkQty5," + ((combobox_CostTyp.SelectedIndex == 4) ? ("Round(CASE WHEN  UntPri1 > 0 THEN (UntPri1) ElSE (0 ) END," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as AvrageCost,Round(CASE WHEN  UntPri2 > 0 THEN (UntPri2) ElSE (0 ) END ," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as AvrageCost2,Round(CASE WHEN  UntPri3 > 0 THEN (UntPri3) ElSE (0 ) END ," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as AvrageCost3,Round(CASE WHEN  UntPri4 > 0 THEN (UntPri4) ElSE (0 ) END ," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as AvrageCost4,Round(CASE WHEN  UntPri5 > 0 THEN (UntPri5) ElSE (0 ) END ," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as AvrageCost5") : (" (Round((" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as AvrageCost,(Round((" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack2) as AvrageCost2,(Round((" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack3) as AvrageCost3,(Round((" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack4) as AvrageCost4,(Round((" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack5) as AvrageCost5")) + ",(Round(T_STKSQTY.stkQty * (" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as StockNet,(Round(T_STKSQTY.stkQty * (" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack1) as StockNet2,(Round(T_STKSQTY.stkQty * (" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack1) as StockNet3,(Round(T_STKSQTY.stkQty * (" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack1) as StockNet4,(Round(T_STKSQTY.stkQty * (" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack1) as StockNet5 "));
                }
                else if (VarGeneral.InvType == 4)
                {
                    Fields = "T_Items.Itm_No,T_Items.Arb_Des as itemNm, (select Arb_Des from T_AccDef where AccDef_No = T_Items.DefultVendor) as DefultVendor ,T_STKSQTY.storeNo,(Round(T_Items.LastCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as LastCost,T_Items.QtyLvl ";
                    Fields = ((combobox_Unit.SelectedIndex > 0) ? string.Concat(Fields, ",(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = ", combobox_Unit.SelectedValue, ") as  UnitNm,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack5) END as Pack1,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END  as UntPri1,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm5,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END)END as stkQty ") : (Fields + ",(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNm,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit2) as  UnitNm2,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit3) as  UnitNm3,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit4) as  UnitNm4,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit5) as  UnitNm5,T_Items.Pack1,T_Items.Pack2,T_Items.Pack3,T_Items.Pack4,T_Items.Pack5 ,(Round(T_Items.UntPri1," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri1,(Round(T_Items.UntPri2," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri2,(Round(T_Items.UntPri3," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri3,(Round(T_Items.UntPri4," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri4,(Round(T_Items.UntPri5," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri5,CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END as stkQty,CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END as stkQty2,CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END as stkQty3,CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END as stkQty4,CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END as stkQty5 "));
                }
                else if (VarGeneral.InvType == 5)
                {
                    Fields = "T_Items.Itm_No,T_Items.Arb_Des as itemNm, (select Arb_Des from T_AccDef where AccDef_No = T_Items.DefultVendor) as DefultVendor ,T_STKSQTY.storeNo ";
                    Fields = ((combobox_Unit.SelectedIndex > 0) ? string.Concat(Fields, ",(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = ", combobox_Unit.SelectedValue, ") as  UnitNm,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack5) END as Pack1,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END  as UntPri1,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm5,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END)END as stkQty ") : (Fields + ",(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNm,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit2) as  UnitNm2,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit3) as  UnitNm3,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit4) as  UnitNm4,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit5) as  UnitNm5,T_Items.Pack1,T_Items.Pack2,T_Items.Pack3,T_Items.Pack4,T_Items.Pack5 ,(Round(T_Items.UntPri1," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri1,(Round(T_Items.UntPri2," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri2,(Round(T_Items.UntPri3," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri3,(Round(T_Items.UntPri4," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri4,(Round(T_Items.UntPri5," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri5,CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END as stkQty,CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END as stkQty2,CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END as stkQty3,CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END as stkQty4,CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END as stkQty5 "));
                }
            }
            else if (VarGeneral.InvType == 1)
            {
                Fields = "T_Items.Itm_No, T_Items.Eng_Des as itemNm,T_Category.Eng_Des as CategoyNm,T_STKSQTY.storeNo,T_Items.Price1,T_Items.Price2,T_Items.Price3,T_Items.Price4,T_Items.Price5,T_Items.BarCod1, (select Eng_Des from T_AccDef where AccDef_No = T_Items.DefultVendor) as DefultVendor";
                if (checkBox_OtherPrices.Checked && File.Exists(Application.StartupPath + "\\Script\\SecriptGlasses.dll"))
                {
                    Fields = "T_Items.Itm_No, T_Items.Arb_Des as itemNm,T_Items.vSize1 as CategoyNm,T_STKSQTY.storeNo,T_Items.vSize4 as Price1,T_Items.vSize3 as Price2,T_Items.vSize2 as Price3,T_Items.vSize5 as Price4,T_Items.vSize5 as Price5,T_Items.BarCod1";
                }
                Fields = ((combobox_Unit.SelectedIndex > 0) ? string.Concat(Fields, ",(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = ", combobox_Unit.SelectedValue, ") as  UnitNm,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack5) END as Pack1,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END  as UntPri1,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm5") : (Fields + ",(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNm,(SELECT " + ((LangArEn == 0) ? "T_Unit.Eng_Des" : "T_Unit.Eng_Des") + " FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit2) as  UnitNm2,(SELECT " + ((LangArEn == 0) ? "T_Unit.Eng_Des" : "T_Unit.Eng_Des") + " FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit3) as  UnitNm3,(SELECT " + ((LangArEn == 0) ? "T_Unit.Eng_Des" : "T_Unit.Eng_Des") + " FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit4) as  UnitNm4,(SELECT " + ((LangArEn == 0) ? "T_Unit.Eng_Des" : "T_Unit.Eng_Des") + " FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit5) as  UnitNm5,T_Items.Pack1,T_Items.Pack2,T_Items.Pack3,T_Items.Pack4,T_Items.Pack5 ,(Round(T_Items.UntPri1," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri1,(Round(T_Items.UntPri2," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri2,(Round(T_Items.UntPri3," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri3,(Round(T_Items.UntPri4," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri4,(Round(T_Items.UntPri5," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri5 "));
            }
            else if (VarGeneral.InvType == 2)
            {
                Fields = "T_Items.Itm_No,T_Items.Eng_Des as itemNm, (select Eng_Des from T_AccDef where AccDef_No = T_Items.DefultVendor) as DefultVendor ,T_STKSQTY.storeNo ";
                Fields = ((combobox_Unit.SelectedIndex > 0) ? string.Concat(Fields, ",(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = ", combobox_Unit.SelectedValue, ") as  UnitNm,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack5) END as Pack1,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END  as UntPri1,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm5,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0) END)END as stkQty ") : (Fields + ",(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNm,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit2) as  UnitNm2,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit3) as  UnitNm3,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit4) as  UnitNm4,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit5) as  UnitNm5,T_Items.Pack1,T_Items.Pack2,T_Items.Pack3,T_Items.Pack4,T_Items.Pack5 ,(Round(T_Items.UntPri1," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri1,(Round(T_Items.UntPri2," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri2,(Round(T_Items.UntPri3," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri3,(Round(T_Items.UntPri4," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri4,(Round(T_Items.UntPri5," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri5,CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END as stkQty,CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END as stkQty2,CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END as stkQty3,CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END as stkQty4,CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END as stkQty5 "));
            }
            else if (VarGeneral.InvType == 3)
            {
                Fields = "T_Items.Itm_No,T_Items.Eng_Des as itemNm, (select Eng_Des from T_AccDef where AccDef_No = T_Items.DefultVendor) as DefultVendor ,T_STKSQTY.storeNo ";
                Fields = ((combobox_Unit.SelectedIndex > 0) ? string.Concat(Fields, ",(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = ", combobox_Unit.SelectedValue, ") as  UnitNm,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack5) END as Pack1,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END  as UntPri1,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm5,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0) END)END as stkQty ,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round((", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round((", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round((", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round((", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round((", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack5) END as AvrageCost,(Round(T_STKSQTY.stkQty * (", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack1) as StockNet") : (Fields + ",(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNm,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit2) as  UnitNm2,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit3) as  UnitNm3,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit4) as  UnitNm4,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit5) as  UnitNm5,T_Items.Pack1,T_Items.Pack2,T_Items.Pack3,T_Items.Pack4,T_Items.Pack5 ,(Round(T_Items.UntPri1," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri1,(Round(T_Items.UntPri2," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri2,(Round(T_Items.UntPri3," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri3,(Round(T_Items.UntPri4," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri4,(Round(T_Items.UntPri5," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri5,CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END as stkQty,CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END as stkQty2,CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END as stkQty3,CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END as stkQty4,CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END as stkQty5,(Round((" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as AvrageCost,(Round((" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack2) as AvrageCost2,(Round((" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack3) as AvrageCost3,(Round((" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack4) as AvrageCost4,(Round((" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack5) as AvrageCost5,(Round(T_STKSQTY.stkQty * (" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as StockNet,(Round(T_STKSQTY.stkQty * (" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack1) as StockNet2,(Round(T_STKSQTY.stkQty * (" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack1) as StockNet3,(Round(T_STKSQTY.stkQty * (" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack1) as StockNet4,(Round(T_STKSQTY.stkQty * (" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack1) as StockNet5 "));
                Fields = ((combobox_Unit.SelectedIndex > 0) ? string.Concat(Fields, ",(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = ", combobox_Unit.SelectedValue, ") as  UnitNm,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack5) END as Pack1,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END  as UntPri1,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm5,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END)END as stkQty ,", (combobox_CostTyp.SelectedIndex == 4) ? string.Concat(" ( CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, "))  WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, "))  WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END ) as AvrageCost ") : string.Concat("  CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round((", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round((", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round((", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round((", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round((", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack5) END as AvrageCost"), ",(Round(T_STKSQTY.stkQty * (", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack1) as StockNet") : (Fields + ",(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNm,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit2) as  UnitNm2,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit3) as  UnitNm3,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit4) as  UnitNm4,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit5) as  UnitNm5,T_Items.Pack1,T_Items.Pack2,T_Items.Pack3,T_Items.Pack4,T_Items.Pack5 ,(Round(T_Items.UntPri1," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri1,(Round(T_Items.UntPri2," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri2,(Round(T_Items.UntPri3," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri3,(Round(T_Items.UntPri4," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri4,(Round(T_Items.UntPri5," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri5,CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END as stkQty,CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END as stkQty2,CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END as stkQty3,CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END as stkQty4,CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END as stkQty5," + ((combobox_CostTyp.SelectedIndex == 4) ? ("Round(CASE WHEN  UntPri1 > 0 THEN (UntPri1) ElSE (0 ) END," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as AvrageCost,Round(CASE WHEN  UntPri2 > 0 THEN (UntPri2) ElSE (0 ) END ," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as AvrageCost2,Round(CASE WHEN  UntPri3 > 0 THEN (UntPri3) ElSE (0 ) END ," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as AvrageCost3,Round(CASE WHEN  UntPri4 > 0 THEN (UntPri4) ElSE (0 ) END ," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as AvrageCost4,Round(CASE WHEN  UntPri5 > 0 THEN (UntPri5) ElSE (0 ) END ," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as AvrageCost5") : (" (Round((" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as AvrageCost,(Round((" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack2) as AvrageCost2,(Round((" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack3) as AvrageCost3,(Round((" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack4) as AvrageCost4,(Round((" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack5) as AvrageCost5")) + ",(Round(T_STKSQTY.stkQty * (" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as StockNet,(Round(T_STKSQTY.stkQty * (" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack1) as StockNet2,(Round(T_STKSQTY.stkQty * (" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack1) as StockNet3,(Round(T_STKSQTY.stkQty * (" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack1) as StockNet4,(Round(T_STKSQTY.stkQty * (" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack1) as StockNet5 "));
            }
            else if (VarGeneral.InvType == 4)
            {
                Fields = "T_Items.Itm_No,T_Items.Eng_Des as itemNm, (select Eng_Des from T_AccDef where AccDef_No = T_Items.DefultVendor) as DefultVendor ,T_STKSQTY.storeNo,(Round(T_Items.LastCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as LastCost,T_Items.QtyLvl ";
                Fields = ((combobox_Unit.SelectedIndex > 0) ? string.Concat(Fields, ",(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = ", combobox_Unit.SelectedValue, ") as  UnitNm,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack5) END as Pack1,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END  as UntPri1,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm5,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0) END)END as stkQty ") : (Fields + ",(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNm,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit2) as  UnitNm2,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit3) as  UnitNm3,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit4) as  UnitNm4,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit5) as  UnitNm5,T_Items.Pack1,T_Items.Pack2,T_Items.Pack3,T_Items.Pack4,T_Items.Pack5 ,(Round(T_Items.UntPri1," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri1,(Round(T_Items.UntPri2," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri2,(Round(T_Items.UntPri3," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri3,(Round(T_Items.UntPri4," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri4,(Round(T_Items.UntPri5," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri5,CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END as stkQty,CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END as stkQty2,CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END as stkQty3,CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END as stkQty4,CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END as stkQty5 "));
            }
            else if (VarGeneral.InvType == 5)
            {
                Fields = "T_Items.Itm_No,T_Items.Eng_Des as itemNm, (select Eng_Des from T_AccDef where AccDef_No = T_Items.DefultVendor) as DefultVendor ,T_STKSQTY.storeNo ";
                Fields = ((combobox_Unit.SelectedIndex > 0) ? string.Concat(Fields, ",(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = ", combobox_Unit.SelectedValue, ") as  UnitNm,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack5) END as Pack1,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END  as UntPri1,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm5,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0) END)END as stkQty ") : (Fields + ",(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNm,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit2) as  UnitNm2,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit3) as  UnitNm3,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit4) as  UnitNm4,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit5) as  UnitNm5,T_Items.Pack1,T_Items.Pack2,T_Items.Pack3,T_Items.Pack4,T_Items.Pack5 ,(Round(T_Items.UntPri1," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri1,(Round(T_Items.UntPri2," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri2,(Round(T_Items.UntPri3," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri3,(Round(T_Items.UntPri4," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri4,(Round(T_Items.UntPri5," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri5,CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END as stkQty,CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END as stkQty2,CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END as stkQty3,CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END as stkQty4,CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END as stkQty5 "));
            }
            return Fields + " ,T_SYSSETTING.LogImg ";
        }
        private string BuildRuleList()
        {
            HijriGregDates dateFormatter = new HijriGregDates();
            string Rule = "Where 1 = 1 " + FlexField.Tag;
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
            try
            {
                db.ExecuteCommand("select CONVERT(int,T_Items.Itm_No) from T_Items");
                if (!string.IsNullOrEmpty(txtFItemNo.Text))
                {
                    object obj = Rule;
                    Rule = string.Concat(obj, " and ", txtFItemNo.Tag, " >= ", txtFItemNo.Text.Trim());
                }
                if (!string.IsNullOrEmpty(txtInItemNo.Text))
                {
                    object obj = Rule;
                    Rule = string.Concat(obj, " and ", txtInItemNo.Tag, " <= ", txtInItemNo.Text.Trim());
                }
            }
            catch
            {
                if (!string.IsNullOrEmpty(txtFItemNo.Text))
                {
                    object obj = Rule;
                    Rule = string.Concat(obj, " and ", txtFItemNo.Tag, " >= '", txtFItemNo.Text.Trim(), "'");
                }
                if (!string.IsNullOrEmpty(txtInItemNo.Text))
                {
                    object obj = Rule;
                    Rule = string.Concat(obj, " and ", txtInItemNo.Tag, " <= '", txtInItemNo.Text.Trim(), "'");
                }
            }
            if (!string.IsNullOrEmpty(txtSuppNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtSuppNo.Tag, " = ", txtSuppNo.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtStoreNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtStoreNo.Tag, " = '", txtStoreNo.Text.Trim(), "'");
            }
            if (!string.IsNullOrEmpty(txtClassNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtClassNo.Tag, " = ", txtClassNo.Text.Trim());
            }
            if (VarGeneral.CheckDate(txtMFromDate.Text) && !VarGeneral.CheckDate(txtMToDate.Text))
            {
                Rule = ((int.Parse(txtMFromDate.Text.Substring(0, 4)) < 1800) ? ((VarGeneral.InvType == 5) ? (Rule + " and T_Items.Itm_No Not in (select T_INVDET.ItmNo from T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where  T_INVHED.HDat  >= '" + dateFormatter.FormatHijri(txtMFromDate.Text, "yyyy/MM/dd") + "')") : (Rule + " and  T_INVHED.HDat  >= '" + dateFormatter.FormatHijri(txtMFromDate.Text, "yyyy/MM/dd") + "'")) : ((VarGeneral.InvType == 5) ? (Rule + " and T_Items.Itm_No Not in (select T_INVDET.ItmNo from T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where  T_INVHED.GDat  >= '" + dateFormatter.FormatGreg(txtMFromDate.Text, "yyyy/MM/dd") + "')") : (Rule + " and  T_INVHED.GDat  >= '" + dateFormatter.FormatGreg(txtMFromDate.Text, "yyyy/MM/dd") + "'")));
            }
            else if (VarGeneral.CheckDate(txtMToDate.Text) && !VarGeneral.CheckDate(txtMFromDate.Text))
            {
                Rule = ((int.Parse(txtMToDate.Text.Substring(0, 4)) < 1800) ? ((VarGeneral.InvType == 5) ? (Rule + " and T_Items.Itm_No Not in (select T_INVDET.ItmNo from T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where  T_INVHED.HDat  <= '" + dateFormatter.FormatHijri(txtMToDate.Text, "yyyy/MM/dd") + "')") : (Rule + " and  T_INVHED.HDat  <= '" + dateFormatter.FormatHijri(txtMToDate.Text, "yyyy/MM/dd") + "'")) : ((VarGeneral.InvType == 5) ? (Rule + " and T_Items.Itm_No Not in (select T_INVDET.ItmNo from T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where  T_INVHED.GDat  <= '" + dateFormatter.FormatGreg(txtMToDate.Text, "yyyy/MM/dd") + "')") : (Rule + " and  T_INVHED.GDat  <= '" + dateFormatter.FormatGreg(txtMToDate.Text, "yyyy/MM/dd") + "'")));
            }
            else if (VarGeneral.CheckDate(txtMFromDate.Text) && VarGeneral.CheckDate(txtMToDate.Text))
            {
                if (int.Parse(txtMFromDate.Text.Substring(0, 4)) < 1800)
                {
                    if (VarGeneral.InvType != 5)
                    {
                        string text = Rule;
                        Rule = text + " and  T_INVHED.HDat  >= '" + dateFormatter.FormatHijri(txtMFromDate.Text, "yyyy/MM/dd") + "'  and T_INVHED.HDat  <= '" + dateFormatter.FormatHijri(txtMToDate.Text, "yyyy/MM/dd") + "'";
                    }
                    else
                    {
                        string text = Rule;
                        Rule = text + " and T_Items.Itm_No Not in (select T_INVDET.ItmNo from T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where  T_INVHED.HDat  >= '" + dateFormatter.FormatHijri(txtMFromDate.Text, "yyyy/MM/dd") + "' and T_INVHED.HDat  <= '" + dateFormatter.FormatHijri(txtMToDate.Text, "yyyy/MM/dd") + "')";
                    }
                }
                else if (VarGeneral.InvType != 5)
                {
                    string text = Rule;
                    Rule = text + " and  T_INVHED.GDat  >= '" + dateFormatter.FormatGreg(txtMFromDate.Text, "yyyy/MM/dd") + "' and T_INVHED.GDat  <= '" + dateFormatter.FormatGreg(txtMToDate.Text, "yyyy/MM/dd") + "'";
                }
                else
                {
                    string text = Rule;
                    Rule = text + " and T_Items.Itm_No Not in (select T_INVDET.ItmNo from T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where  T_INVHED.GDat  >= '" + dateFormatter.FormatGreg(txtMFromDate.Text, "yyyy/MM/dd") + "' and T_INVHED.GDat  <= '" + dateFormatter.FormatGreg(txtMToDate.Text, "yyyy/MM/dd") + "')";
                }
            }
            if (combobox_Unit.SelectedIndex > 0)
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and (T_Items.Unit1 = ", combobox_Unit.SelectedValue, " or  T_Items.Unit2 = ", combobox_Unit.SelectedValue, " or T_Items.Unit3 = ", combobox_Unit.SelectedValue, " or T_Items.Unit4 = ", combobox_Unit.SelectedValue, " or T_Items.Unit5 = ", combobox_Unit.SelectedValue, ")");
            }
            if (VarGeneral.InvType == 2 || VarGeneral.InvType == 3 || VarGeneral.InvType == 4 || VarGeneral.InvType == 5)
            {
                Rule += " and T_Items.ItmTyp != 2 ";
            }
            return Rule;
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (Text == "بيانات الأصناف" || Text == "Items Data")
                {
                    VarGeneral.InvType = 1;
                }
                else if (Text == "بيانات الأصناف وكمياتها" || Text == "Items Quantities")
                {
                    VarGeneral.InvType = 2;
                }
                else if (Text == "بيانات الأصناف وتكلفتها" || Text == "Items Cost")
                {
                    VarGeneral.InvType = 3;
                }
                else if (Text == "الأصناف الواجب توفرها" || Text == "Items Order")
                {
                    VarGeneral.InvType = 4;
                }
                else if (Text == "الأصناف الراكدة" || Text == "UnSale Items")
                {
                    VarGeneral.InvType = 5;
                }
                VarGeneral.itmDes = "";
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Items LEFT OUTER JOIN  T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID  LEFT OUTER JOIN T_STKSQTY On T_Items.Itm_No = T_STKSQTY.itmNo Left Join T_SYSSETTING ON T_Items.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                string Fields = BuildFieldList();
                _RepShow.Rule = BuildRuleList() + ((VarGeneral.InvType != 3 && combobox_CostTyp.SelectedIndex > 0) ? " order by case when DefultVendor is null then 1 else 0 end, DefultVendor  " : " order by  CONVERT(INT, LEFT(T_Items.Itm_No, PATINDEX('%[^0-9]%', T_Items.Itm_No + 'z')-1))");
                _RepShow.Fields = Fields;
                try
                {
                    try
                    {
                        db.ExecuteCommand("select " + _RepShow.Fields + " From " + _RepShow.Tables + _RepShow.Rule);
                    }
                    catch
                    {
                        _RepShow.Rule = BuildRuleList() + " order by T_Items.Itm_No ";
                    }
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.Message);
                }
                string f = VarGeneral.getselect(_RepShow.Fields, _RepShow.Tables, _RepShow.Rule);
                if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "عفوا .. لا يوجد بيانات لعرضها في التقرير " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                try
                {
                    VarGeneral.IsGeneralUsed = true;
                    FrmReportsViewer frm = new FrmReportsViewer();
                    frm.Repvalue = "ItemsData";
                    frm.Tag = LangArEn;
                    frm.Repvalue = "ItemsData";
                    VarGeneral.vTitle = Text;
                    if (VarGeneral.InvType == 3)
                    {
                        VarGeneral.Customerlbl = combobox_CostTyp.Text;
                    }
                    try
                    {
                        if (checkBox_OtherPrices.Checked)
                        {
                            VarGeneral.itmDes = "OtherPrice";
                        }
                    }
                    catch
                    {
                        VarGeneral.itmDes = "";
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
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }
        private void ButExit_Click(object sender, EventArgs e)
        {
            Close();
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
        private void txtMFromDate_Click(object sender, EventArgs e)
        {
            txtMFromDate.SelectAll();
        }
        private void txtMToDate_Click(object sender, EventArgs e)
        {
            txtMToDate.SelectAll();
        }
        private void txtMFromNo_Click(object sender, EventArgs e)
        {
            txtMFromNo.SelectAll();
        }
        private void txtMIntoNo_Click(object sender, EventArgs e)
        {
            txtMIntoNo.SelectAll();
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
                txtFItemNo.Text = frm.Serach_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtFItemName.Text = db.StockItem(frm.Serach_No).Arb_Des.ToString();
                }
                else
                {
                    txtFItemName.Text = db.StockItem(frm.Serach_No).Eng_Des.ToString();
                }
            }
            else
            {
                txtFItemNo.Text = "";
                txtFItemName.Text = "";
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
                txtInItemNo.Text = frm.Serach_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtInItemName.Text = db.StockItem(frm.Serach_No).Arb_Des.ToString();
                }
                else
                {
                    txtInItemName.Text = db.StockItem(frm.Serach_No).Eng_Des.ToString();
                }
            }
            else
            {
                txtInItemNo.Text = "";
                txtInItemName.Text = "";
            }
        }
        private void button_SrchClassNo_Click(object sender, EventArgs e)
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
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptInvitationCards.dll"))
            {
                VarGeneral.AccTyp = 4;
            }
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
        private void button_SrchStoreNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("Stor_ID", new ColumnDictinary("رقم المستودع", "Store No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            columns_Names_visible.Add("Address", new ColumnDictinary("العنوان", "Adress", ifDefault: false, ""));
            columns_Names_visible.Add("Tel", new ColumnDictinary("الهاتف", "Phone", ifDefault: false, ""));
            columns_Names_visible.Add("City", new ColumnDictinary("المدينة", "City", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_Store";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtStoreNo.Text = frm.Serach_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtStoreName.Text = db.StockStore(int.Parse(frm.Serach_No.ToString())).Arb_Des.ToString();
                }
                else
                {
                    txtStoreName.Text = db.StockStore(int.Parse(frm.Serach_No.ToString())).Eng_Des.ToString();
                }
            }
            else
            {
                txtStoreNo.Text = "";
                txtStoreName.Text = "";
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
        private void FRItemsData_Load(object sender, EventArgs e)
        {
        }
        private void FillCombo()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                List<T_Unit> listUnit1 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
                listUnit1.Insert(0, new T_Unit());
                listUnit1[0].Arb_Des = "الكـل";
                combobox_Unit.DataSource = listUnit1;
                combobox_Unit.DisplayMember = "Arb_Des";
                combobox_Unit.ValueMember = "Unit_ID";
                combobox_Unit.SelectedIndex = 0;
            }
            else
            {
                List<T_Unit> listUnit1 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
                listUnit1.Insert(0, new T_Unit());
                listUnit1[0].Eng_Des = "ALL";
                combobox_Unit.DataSource = listUnit1;
                combobox_Unit.DisplayMember = "Eng_Des";
                combobox_Unit.ValueMember = "Unit_ID";
                combobox_Unit.SelectedIndex = 0;
            }
            combobox_CostTyp.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                if (VarGeneral.InvType == 3)
                {
                    combobox_CostTyp.Items.Add("متوسط التكلفة");
                    combobox_CostTyp.Items.Add("آخر تكلفة");
                    combobox_CostTyp.Items.Add("التكلفة الأفتتاحية");
                    combobox_CostTyp.Items.Add("أول تكلفة");
                    combobox_CostTyp.Items.Add("سعر البيع");
                }
                else
                {
                    combobox_CostTyp.Items.Add("رقم الصنف");
                    combobox_CostTyp.Items.Add("الموردين");
                }
            }
            else if (VarGeneral.InvType == 3)
            {
                combobox_CostTyp.Items.Add("Average Cost");
                combobox_CostTyp.Items.Add("Last Cost");
                combobox_CostTyp.Items.Add("Open Cost");
                combobox_CostTyp.Items.Add("First Cost");
                combobox_CostTyp.Items.Add("Sale Price");
            }
            else
            {
                combobox_CostTyp.Items.Add("Item No");
                combobox_CostTyp.Items.Add("Suppliers");
            }
            combobox_CostTyp.SelectedIndex = 0;
        }
        private void label6_Click(object sender, EventArgs e)
        {
        }
        private void ribbonBar1_ItemClick(object sender, EventArgs e)
        {
        }
        private void checkBox_OtherPrices_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_OtherPrices.Checked)
            {
                combobox_Unit.SelectedIndex = 0;
                combobox_Unit.Enabled = false;
            }
            else
            {
                combobox_Unit.SelectedIndex = 0;
                combobox_Unit.Enabled = true;
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
    }
}
