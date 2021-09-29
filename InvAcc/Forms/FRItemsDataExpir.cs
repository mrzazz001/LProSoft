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
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FRItemsDataExpir : Form
    { void avs(int arln)

{ 
  groupBox_ExpirDate.Text=   (arln == 0 ? "  حسب تاريخ الصلاحية   " : "  According to the expiration date") ; label15.Text=   (arln == 0 ? "  مـــــن :  " : "  from:") ; label16.Text=   (arln == 0 ? "  إلـــــى :  " : "  to:") ; checkBox_Details.Text=   (arln == 0 ? "  تفصيلي  " : "  detailed") ; groupBox_DateExpir.Text=   (arln == 0 ? "  حسب تاريخ الصلاحية  " : "  According to the expiration date") ; label12.Text=   (arln == 0 ? "  مـــــن :  " : "  from:") ; label13.Text=   (arln == 0 ? "  إلـــــى :  " : "  to:") ; groupBox_Date.Text=   (arln == 0 ? "  حسب تاريخ الركود  " : "  By date of recession") ; label3.Text=   (arln == 0 ? "  مـــــن :  " : "  from:") ; label4.Text=   (arln == 0 ? "  إلـــــى :  " : "  to:") ; groupBox3.Text=   (arln == 0 ? "  حسب الكمية  " : "  by quantity") ; label1.Text=   (arln == 0 ? "  مـــــن :  " : "  from:") ; label2.Text=   (arln == 0 ? "  إلـــــى :  " : "  to:") ; label10.Text=   (arln == 0 ? "  الوحـــــــــــــدة :  " : "  Unity:") ; label8.Text=   (arln == 0 ? "  المـــــــــــــورد :  " : "  Supplier:") ; label5.Text=   (arln == 0 ? "  مــــن صــــنف :  " : "  By category:") ; label9.Text=   (arln == 0 ? "  المســـــــتودع :  " : "  Repository:") ; label7.Text=   (arln == 0 ? "  التصنيـــــــــف :  " : "  Classification:") ; label6.Text=   (arln == 0 ? "  إلـــى صــــنف :  " : "  to class:") ; label14.Text=   (arln == 0 ? "  تاريخ الصلاحية :  " : "  Expiration date :") ; label11.Text=   (arln == 0 ? "  رقــم التصنيــع :  " : "  Manufacture Number:") ;}
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
        private ComboBoxEx combobox_RunNo;
        private GroupBox groupBox_DateExpir;
        private Label label12;
        private Label label13;
        private MaskedTextBox txtExpirDateBegin;
        private MaskedTextBox txtExpirDateTo;
        private ComboBoxEx combobox_RunDateExpir;
        private Label label11;
        private Label label14;
        private ComboBoxEx combobox_ExpirRunNo;
        private ComboBoxEx combobox_DateExpir;
        private CheckBox checkBox_Details;
        private GroupBox groupBox_ExpirDate;
        private Label label15;
        private Label label16;
        private MaskedTextBox txtMToDateExpir;
        private C1.Win.C1Input.C1Button ButOk;
        private C1.Win.C1Input.C1Button ButExit;
        private MaskedTextBox txtMFromDateExpir;
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
        public FRItemsDataExpir()
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
                groupBox_DateExpir.Text = "حسب تاريخ الصلاحية";
                groupBox_ExpirDate.Text = "حسب تاريخ الصلاحية";
                label1.Text = "مـــــن :";
                label2.Text = "إلـــــى :";
                label3.Text = "مـــــن :";
                label4.Text = "إلـــــى :";
                label12.Text = "مـــــن :";
                label13.Text = "إلـــــى :";
                label5.Text = "مــــن صــــنف :";
                label6.Text = "إلـــى صــــنف :";
                label7.Text = "التصنيـــــــــف :";
                label8.Text = "المـــــــــــــورد :";
                label9.Text = "المســـــــتودع :";
            }
            else
            {
                ButExit.Text = "Exit Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "Print F5" : "Show F5");
                groupBox3.Text = "Quantity";
                groupBox_Date.Text = "Date of inactivity";
                groupBox_DateExpir.Text = "Date Expir";
                groupBox_ExpirDate.Text = "Date Expir";
                label1.Text = "From :";
                label2.Text = "To :";
                label3.Text = "From :";
                label4.Text = "To :";
                label5.Text = "From Item :";
                label6.Text = "To Item :";
                label12.Text = "From :";
                label3.Text = "To :";
                label7.Text = "Category :";
                label8.Text = "Supplier :";
                label9.Text = "Store :";
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRItemsDataExpir));
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
            RepDef(); avs(GeneralM.VarGeneral.currentintlanguage);
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRItemsDataExpir));
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
                }
                else if (VarGeneral.InvType == 999)
                {
                    Text = "بيانات الأصناف منتهية الصلاحية وكمياتها";
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
            }
            else if (VarGeneral.InvType == 999)
            {
                Text = "Items of Expir Date and Quantities";
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
                    Fields = "T_Items.Itm_No, T_Items.Arb_Des as itemNm,T_Category.Arb_Des as CategoyNm,T_STKSQTY.storeNo,T_Items.Price1,T_Items.Price2,T_Items.Price3,T_Items.Price4,T_Items.Price5,T_Items.BarCod1";
                    Fields = ((combobox_Unit.SelectedIndex > 0) ? string.Concat(Fields, ",(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = ", combobox_Unit.SelectedValue, ") as  UnitNm,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack5) END as Pack1,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END  as UntPri1,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm5") : (Fields + ",(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNm,(SELECT " + ((LangArEn == 0) ? "T_Unit.Arb_Des" : "T_Unit.Eng_Des") + " FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit2) as  UnitNm2,(SELECT " + ((LangArEn == 0) ? "T_Unit.Arb_Des" : "T_Unit.Eng_Des") + " FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit3) as  UnitNm3,(SELECT " + ((LangArEn == 0) ? "T_Unit.Arb_Des" : "T_Unit.Eng_Des") + " FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit4) as  UnitNm4,(SELECT " + ((LangArEn == 0) ? "T_Unit.Arb_Des" : "T_Unit.Eng_Des") + " FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit5) as  UnitNm5,T_Items.Pack1,T_Items.Pack2,T_Items.Pack3,T_Items.Pack4,T_Items.Pack5 ,(Round(T_Items.UntPri1," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri1,(Round(T_Items.UntPri2," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri2,(Round(T_Items.UntPri3," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri3,(Round(T_Items.UntPri4," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri4,(Round(T_Items.UntPri5," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri5 "));
                }
                else if (VarGeneral.InvType == 999)
                {
                    Fields = "T_Items.Itm_No,T_Items.Arb_Des as itemNm,T_Category.Arb_Des as CategoyNm, T_Items.DefultVendor ,T_QTYEXP.storeNo,T_QTYEXP.RunCod,T_QTYEXP.DatExper ";
                    Fields = ((combobox_Unit.SelectedIndex > 0) ? string.Concat(Fields, ",(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = ", combobox_Unit.SelectedValue, ") as  UnitNm,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack5) END as Pack1,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END  as UntPri1,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm5,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack1 > 0 THEN (T_QTYEXP.stkQty / Pack1) ElSE (0 ) END) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack2 > 0 THEN (T_QTYEXP.stkQty / Pack2) ElSE (0 ) END) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack3 > 0 THEN (T_QTYEXP.stkQty / Pack3) ElSE (0 ) END) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack4 > 0 THEN (T_QTYEXP.stkQty / Pack4) ElSE (0 ) END) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack5 > 0 THEN (T_QTYEXP.stkQty / Pack5) ElSE (0 ) END)END as stkQty,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack1 > 0 THEN case when ((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack1) <> 0 then (((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack1)) ElSE (T_QTYEXP.stkQty / Pack1) END ElSE (0 ) END ) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack2 > 0 THEN case when ((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack2) <> 0 then (((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack2)) ElSE (T_QTYEXP.stkQty / Pack2) END ElSE (0 ) END) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack3 > 0 THEN case when ((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack3) <> 0 then (((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack3)) ElSE (T_QTYEXP.stkQty / Pack3) END ElSE (0 ) END) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack4 > 0 THEN case when ((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack4) <> 0 then (((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack4)) ElSE (T_QTYEXP.stkQty / Pack4) END ElSE (0 ) END) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack5 > 0 THEN case when ((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack5) <> 0 then (((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack5)) ElSE (T_QTYEXP.stkQty / Pack5) END ElSE (0 ) END) ElSE (0 ) END as stkQtyTotal,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack1 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack1) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack1)) ElSE (0) END ElSE (0 ) END ) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack2 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack2) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack2)) ElSE (0) END ElSE (0 ) END) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack3 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack3) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack3)) ElSE (0) END ElSE (0 ) END) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack4 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack4) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack4)) ElSE (0) END ElSE (0 ) END) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack5 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack5) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack5)) ElSE (0) END ElSE (0 ) END) ElSE (0 ) END as stkIntExpir,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack1 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack1) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack1)) ElSE (0) END ElSE (0 ) END ) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack2 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack2) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack2)) ElSE (0) END ElSE (0 ) END) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack3 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack3) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack3)) ElSE (0) END ElSE (0 ) END) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack4 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack4) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack4)) ElSE (0) END ElSE (0 ) END) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack5 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack5) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack5)) ElSE (0) END ElSE (0 ) END) ElSE (0 ) END as stkPurchasExpir ,0 as stkQtyTotal2,0 as stkQtyTotal3,0 as stkQtyTotal4,0 as stkQtyTotal5,0 as stkQty2,0 as stkQty3,0 as stkQty4,0 as stkQty5") : (Fields + ",(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNm,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit2) as  UnitNm2,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit3) as  UnitNm3,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit4) as  UnitNm4,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit5) as  UnitNm5,T_Items.Pack1,T_Items.Pack2,T_Items.Pack3,T_Items.Pack4,T_Items.Pack5 ,(Round(T_Items.UntPri1," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri1,(Round(T_Items.UntPri2," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri2,(Round(T_Items.UntPri3," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri3,(Round(T_Items.UntPri4," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri4,(Round(T_Items.UntPri5," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri5,CASE WHEN  Pack1 > 0 THEN (T_QTYEXP.stkQty / Pack1) ElSE (0 ) END as stkQty,CASE WHEN  Pack2 > 0 THEN (T_QTYEXP.stkQty / Pack2) ElSE (0 ) END as stkQty2,CASE WHEN  Pack3 > 0 THEN (T_QTYEXP.stkQty / Pack3) ElSE (0 ) END as stkQty3,CASE WHEN  Pack4 > 0 THEN (T_QTYEXP.stkQty / Pack4) ElSE (0 ) END as stkQty4,CASE WHEN  Pack5 > 0 THEN (T_QTYEXP.stkQty / Pack5) ElSE (0 ) END as stkQty5,CASE WHEN  Pack1 > 0 THEN case when ((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack1) <> 0 then (((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack1)) ElSE (T_QTYEXP.stkQty / Pack1) END ElSE (0 ) END as stkQtyTotal,CASE WHEN  Pack2 > 0 THEN case when ((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack2) <> 0 then (((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack2)) ElSE (T_QTYEXP.stkQty / Pack2) END ElSE (0 ) END as stkQtyTotal2,CASE WHEN  Pack3 > 0 THEN case when ((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack3) <> 0 then (((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack3)) ElSE (T_QTYEXP.stkQty / Pack3) END ElSE (0 ) END as stkQtyTotal3,CASE WHEN  Pack4 > 0 THEN case when ((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack4) <> 0 then (((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack4)) ElSE (T_QTYEXP.stkQty / Pack4) END ElSE (0 ) END as stkQtyTotal4 ,CASE WHEN  Pack5 > 0 THEN case when ((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack5) <> 0 then (((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack5)) ElSE (T_QTYEXP.stkQty / Pack5) END ElSE (0 ) END as stkQtyTotal5,CASE WHEN  Pack1 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack1) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack1)) ElSE (0) END ElSE (0 ) END as stkIntExpir,CASE WHEN  Pack2 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack2) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack2)) ElSE (0) END ElSE (0 ) END as stkIntExpir2,CASE WHEN  Pack3 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack3) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack3)) ElSE (0) END ElSE (0 ) END as stkIntExpir3,CASE WHEN  Pack4 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack4) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack4)) ElSE (0) END ElSE (0 ) END as stkIntExpir4,CASE WHEN  Pack5 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack5) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack5)) ElSE (0) END ElSE (0 ) END as stkIntExpir5,CASE WHEN  Pack1 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack1) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack1)) ElSE (0) END ElSE (0 ) END as stkPurchasExpir,CASE WHEN  Pack2 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack2) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack2)) ElSE (0) END ElSE (0 ) END as stkPurchasExpir2,CASE WHEN  Pack3 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack3) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack3)) ElSE (0) END ElSE (0 ) END as stkPurchasExpir3,CASE WHEN  Pack4 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack4) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack4)) ElSE (0) END ElSE (0 ) END as stkPurchasExpir4,CASE WHEN  Pack5 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack5) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack5)) ElSE (0) END ElSE (0 ) END as stkPurchasExpir5"));
                }
                else if (VarGeneral.InvType == 3)
                {
                    Fields = "T_Items.Itm_No,T_Items.Arb_Des as itemNm, T_Items.DefultVendor ,T_STKSQTY.storeNo ";
                    Fields = ((combobox_Unit.SelectedIndex > 0) ? string.Concat(Fields, ",(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = ", combobox_Unit.SelectedValue, ") as  UnitNm,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack5) END as Pack1,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END  as UntPri1,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm5,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END)END as stkQty ,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.AvrageCost,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.AvrageCost,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.AvrageCost,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.AvrageCost,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.AvrageCost,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack5) END as AvrageCost,(Round(T_STKSQTY.stkQty * T_Items.AvrageCost,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack1) as StockNet") : (Fields + ",(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNm,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit2) as  UnitNm2,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit3) as  UnitNm3,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit4) as  UnitNm4,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit5) as  UnitNm5,T_Items.Pack1,T_Items.Pack2,T_Items.Pack3,T_Items.Pack4,T_Items.Pack5 ,(Round(T_Items.UntPri1," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri1,(Round(T_Items.UntPri2," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri2,(Round(T_Items.UntPri3," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri3,(Round(T_Items.UntPri4," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri4,(Round(T_Items.UntPri5," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri5,CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END as stkQty,CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END as stkQty2,CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END as stkQty3,CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END as stkQty4,CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END as stkQty5,(Round(T_Items.AvrageCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as AvrageCost,(Round(T_Items.AvrageCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack2) as AvrageCost2,(Round(T_Items.AvrageCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack3) as AvrageCost3,(Round(T_Items.AvrageCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack4) as AvrageCost4,(Round(T_Items.AvrageCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack5) as AvrageCost5,(Round(T_STKSQTY.stkQty * T_Items.AvrageCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as StockNet,(Round(T_STKSQTY.stkQty * T_Items.AvrageCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack1) as StockNet2,(Round(T_STKSQTY.stkQty * T_Items.AvrageCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack1) as StockNet3,(Round(T_STKSQTY.stkQty * T_Items.AvrageCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack1) as StockNet4,(Round(T_STKSQTY.stkQty * T_Items.AvrageCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack1) as StockNet5 "));
                }
                else if (VarGeneral.InvType == 4)
                {
                    Fields = "T_Items.Itm_No,T_Items.Arb_Des as itemNm, T_Items.DefultVendor ,T_STKSQTY.storeNo,(Round(T_Items.LastCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as LastCost,T_Items.QtyLvl ";
                    Fields = ((combobox_Unit.SelectedIndex > 0) ? string.Concat(Fields, ",(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = ", combobox_Unit.SelectedValue, ") as  UnitNm,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack5) END as Pack1,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END  as UntPri1,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm5,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END)END as stkQty ") : (Fields + ",(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNm,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit2) as  UnitNm2,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit3) as  UnitNm3,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit4) as  UnitNm4,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit5) as  UnitNm5,T_Items.Pack1,T_Items.Pack2,T_Items.Pack3,T_Items.Pack4,T_Items.Pack5 ,(Round(T_Items.UntPri1," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri1,(Round(T_Items.UntPri2," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri2,(Round(T_Items.UntPri3," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri3,(Round(T_Items.UntPri4," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri4,(Round(T_Items.UntPri5," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri5,CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END as stkQty,CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END as stkQty2,CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END as stkQty3,CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END as stkQty4,CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END as stkQty5 "));
                }
                else if (VarGeneral.InvType == 5)
                {
                    Fields = "T_Items.Itm_No,T_Items.Arb_Des as itemNm, T_Items.DefultVendor ,T_STKSQTY.storeNo ";
                    Fields = ((combobox_Unit.SelectedIndex > 0) ? string.Concat(Fields, ",(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = ", combobox_Unit.SelectedValue, ") as  UnitNm,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack5) END as Pack1,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END  as UntPri1,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm5,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END)END as stkQty ") : (Fields + ",(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNm,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit2) as  UnitNm2,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit3) as  UnitNm3,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit4) as  UnitNm4,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit5) as  UnitNm5,T_Items.Pack1,T_Items.Pack2,T_Items.Pack3,T_Items.Pack4,T_Items.Pack5 ,(Round(T_Items.UntPri1," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri1,(Round(T_Items.UntPri2," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri2,(Round(T_Items.UntPri3," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri3,(Round(T_Items.UntPri4," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri4,(Round(T_Items.UntPri5," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri5,CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END as stkQty,CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END as stkQty2,CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END as stkQty3,CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END as stkQty4,CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END as stkQty5 "));
                }
            }
            else if (VarGeneral.InvType == 1)
            {
                Fields = "T_Items.Itm_No, T_Items.Eng_Des as itemNm,T_Category.Eng_Des as CategoyNm,T_STKSQTY.storeNo,T_Items.Price1,T_Items.Price2,T_Items.Price3,T_Items.Price4,T_Items.Price5,T_Items.BarCod1";
                Fields = ((combobox_Unit.SelectedIndex > 0) ? string.Concat(Fields, ",(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = ", combobox_Unit.SelectedValue, ") as  UnitNm,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack5) END as Pack1,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END  as UntPri1,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm5") : (Fields + ",(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNm,(SELECT " + ((LangArEn == 0) ? "T_Unit.Eng_Des" : "T_Unit.Eng_Des") + " FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit2) as  UnitNm2,(SELECT " + ((LangArEn == 0) ? "T_Unit.Eng_Des" : "T_Unit.Eng_Des") + " FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit3) as  UnitNm3,(SELECT " + ((LangArEn == 0) ? "T_Unit.Eng_Des" : "T_Unit.Eng_Des") + " FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit4) as  UnitNm4,(SELECT " + ((LangArEn == 0) ? "T_Unit.Eng_Des" : "T_Unit.Eng_Des") + " FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit5) as  UnitNm5,T_Items.Pack1,T_Items.Pack2,T_Items.Pack3,T_Items.Pack4,T_Items.Pack5 ,(Round(T_Items.UntPri1," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri1,(Round(T_Items.UntPri2," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri2,(Round(T_Items.UntPri3," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri3,(Round(T_Items.UntPri4," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri4,(Round(T_Items.UntPri5," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri5 "));
            }
            else if (VarGeneral.InvType == 999)
            {
                Fields = "T_Items.Itm_No,T_Items.Eng_Des as itemNm,T_Category.Eng_Des as CategoyNm, T_Items.DefultVendor ,T_QTYEXP.storeNo,T_QTYEXP.RunCod,T_QTYEXP.DatExper ";
                Fields = ((combobox_Unit.SelectedIndex > 0) ? string.Concat(Fields, ",(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = ", combobox_Unit.SelectedValue, ") as  UnitNm,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack5) END as Pack1,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END  as UntPri1,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm5,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack1 > 0 THEN (T_QTYEXP.stkQty / Pack1) ElSE (0 ) END) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack2 > 0 THEN (T_QTYEXP.stkQty / Pack2) ElSE (0 ) END) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack3 > 0 THEN (T_QTYEXP.stkQty / Pack3) ElSE (0 ) END) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack4 > 0 THEN (T_QTYEXP.stkQty / Pack4) ElSE (0 ) END) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack5 > 0 THEN (T_QTYEXP.stkQty / Pack5) ElSE (0 ) END)END as stkQty,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack1 > 0 THEN case when ((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack1) <> 0 then (((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack1)) ElSE (T_QTYEXP.stkQty / Pack1) END ElSE (0 ) END ) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack2 > 0 THEN case when ((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack2) <> 0 then (((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack2)) ElSE (T_QTYEXP.stkQty / Pack2) END ElSE (0 ) END) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack3 > 0 THEN case when ((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack3) <> 0 then (((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack3)) ElSE (T_QTYEXP.stkQty / Pack3) END ElSE (0 ) END) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack4 > 0 THEN case when ((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack4) <> 0 then (((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack4)) ElSE (T_QTYEXP.stkQty / Pack4) END ElSE (0 ) END) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack5 > 0 THEN case when ((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack5) <> 0 then (((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack5)) ElSE (T_QTYEXP.stkQty / Pack5) END ElSE (0 ) END) ElSE (0 ) END as stkQtyTotal,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack1 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack1) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack1)) ElSE (0) END ElSE (0 ) END ) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack2 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack2) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack2)) ElSE (0) END ElSE (0 ) END) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack3 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack3) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack3)) ElSE (0) END ElSE (0 ) END) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack4 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack4) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack4)) ElSE (0) END ElSE (0 ) END) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack5 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack5) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack5)) ElSE (0) END ElSE (0 ) END) ElSE (0 ) END as stkIntExpir,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack1 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack1) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack1)) ElSE (0) END ElSE (0 ) END ) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack2 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack2) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack2)) ElSE (0) END ElSE (0 ) END) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack3 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack3) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack3)) ElSE (0) END ElSE (0 ) END) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack4 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack4) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack4)) ElSE (0) END ElSE (0 ) END) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack5 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack5) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack5)) ElSE (0) END ElSE (0 ) END) ElSE (0 ) END as stkPurchasExpir ,0 as stkQtyTotal2,0 as stkQtyTotal3,0 as stkQtyTotal4,0 as stkQtyTotal5,0 as stkQty2,0 as stkQty3,0 as stkQty4,0 as stkQty5") : (Fields + ",(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNm,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit2) as  UnitNm2,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit3) as  UnitNm3,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit4) as  UnitNm4,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit5) as  UnitNm5,T_Items.Pack1,T_Items.Pack2,T_Items.Pack3,T_Items.Pack4,T_Items.Pack5 ,(Round(T_Items.UntPri1," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri1,(Round(T_Items.UntPri2," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri2,(Round(T_Items.UntPri3," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri3,(Round(T_Items.UntPri4," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri4,(Round(T_Items.UntPri5," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri5,CASE WHEN  Pack1 > 0 THEN (T_QTYEXP.stkQty / Pack1) ElSE (0 ) END as stkQty,CASE WHEN  Pack2 > 0 THEN (T_QTYEXP.stkQty / Pack2) ElSE (0 ) END as stkQty2,CASE WHEN  Pack3 > 0 THEN (T_QTYEXP.stkQty / Pack3) ElSE (0 ) END as stkQty3,CASE WHEN  Pack4 > 0 THEN (T_QTYEXP.stkQty / Pack4) ElSE (0 ) END as stkQty4,CASE WHEN  Pack5 > 0 THEN (T_QTYEXP.stkQty / Pack5) ElSE (0 ) END as stkQty5,CASE WHEN  Pack1 > 0 THEN case when ((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack1) <> 0 then (((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack1)) ElSE (T_QTYEXP.stkQty / Pack1) END ElSE (0 ) END as stkQtyTotal,CASE WHEN  Pack2 > 0 THEN case when ((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack2) <> 0 then (((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack2)) ElSE (T_QTYEXP.stkQty / Pack2) END ElSE (0 ) END as stkQtyTotal2,CASE WHEN  Pack3 > 0 THEN case when ((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack3) <> 0 then (((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack3)) ElSE (T_QTYEXP.stkQty / Pack3) END ElSE (0 ) END as stkQtyTotal3,CASE WHEN  Pack4 > 0 THEN case when ((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack4) <> 0 then (((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack4)) ElSE (T_QTYEXP.stkQty / Pack4) END ElSE (0 ) END as stkQtyTotal4 ,CASE WHEN  Pack5 > 0 THEN case when ((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack5) <> 0 then (((select sum(abs(T_INVDET.RealQty)) + T_QTYEXP.stkQty from T_INVDET where T_INVDET.RealQty <= 0 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack5)) ElSE (T_QTYEXP.stkQty / Pack5) END ElSE (0 ) END as stkQtyTotal5,CASE WHEN  Pack1 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack1) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack1)) ElSE (0) END ElSE (0 ) END as stkIntExpir,CASE WHEN  Pack2 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack2) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack2)) ElSE (0) END ElSE (0 ) END as stkIntExpir2,CASE WHEN  Pack3 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack3) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack3)) ElSE (0) END ElSE (0 ) END as stkIntExpir3,CASE WHEN  Pack4 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack4) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack4)) ElSE (0) END ElSE (0 ) END as stkIntExpir4,CASE WHEN  Pack5 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack5) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 14 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack5)) ElSE (0) END ElSE (0 ) END as stkIntExpir5,CASE WHEN  Pack1 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack1) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack1)) ElSE (0) END ElSE (0 ) END as stkPurchasExpir,CASE WHEN  Pack2 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack2) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack2)) ElSE (0) END ElSE (0 ) END as stkPurchasExpir2,CASE WHEN  Pack3 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack3) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack3)) ElSE (0) END ElSE (0 ) END as stkPurchasExpir3,CASE WHEN  Pack4 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack4) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack4)) ElSE (0) END ElSE (0 ) END as stkPurchasExpir4,CASE WHEN  Pack5 > 0 THEN case when ((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack5) <> 0 then (((select SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) from T_INVDET INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where T_INVHED.InvTyp = 2 and T_INVDET.ItmNo = T_QTYEXP.itmNo and T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper ) / Pack5)) ElSE (0) END ElSE (0 ) END as stkPurchasExpir5"));
            }
            else if (VarGeneral.InvType == 3)
            {
                Fields = "T_Items.Itm_No,T_Items.Eng_Des as itemNm, T_Items.DefultVendor ,T_STKSQTY.storeNo ";
                Fields = ((combobox_Unit.SelectedIndex > 0) ? string.Concat(Fields, ",(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = ", combobox_Unit.SelectedValue, ") as  UnitNm,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack5) END as Pack1,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END  as UntPri1,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm5,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0) END)END as stkQty ,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.AvrageCost,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.AvrageCost,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.AvrageCost,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.AvrageCost,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.AvrageCost,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack5) END as AvrageCost,(Round(T_STKSQTY.stkQty * T_Items.AvrageCost,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack1) as StockNet") : (Fields + ",(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNm,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit2) as  UnitNm2,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit3) as  UnitNm3,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit4) as  UnitNm4,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit5) as  UnitNm5,T_Items.Pack1,T_Items.Pack2,T_Items.Pack3,T_Items.Pack4,T_Items.Pack5 ,(Round(T_Items.UntPri1," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri1,(Round(T_Items.UntPri2," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri2,(Round(T_Items.UntPri3," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri3,(Round(T_Items.UntPri4," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri4,(Round(T_Items.UntPri5," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri5,CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END as stkQty,CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END as stkQty2,CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END as stkQty3,CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END as stkQty4,CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END as stkQty5,(Round(T_Items.AvrageCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as AvrageCost,(Round(T_Items.AvrageCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack2) as AvrageCost2,(Round(T_Items.AvrageCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack3) as AvrageCost3,(Round(T_Items.AvrageCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack4) as AvrageCost4,(Round(T_Items.AvrageCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack5) as AvrageCost5,(Round(T_STKSQTY.stkQty * T_Items.AvrageCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as StockNet,(Round(T_STKSQTY.stkQty * T_Items.AvrageCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack1) as StockNet2,(Round(T_STKSQTY.stkQty * T_Items.AvrageCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack1) as StockNet3,(Round(T_STKSQTY.stkQty * T_Items.AvrageCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack1) as StockNet4,(Round(T_STKSQTY.stkQty * T_Items.AvrageCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack1) as StockNet5 "));
            }
            else if (VarGeneral.InvType == 4)
            {
                Fields = "T_Items.Itm_No,T_Items.Eng_Des as itemNm, T_Items.DefultVendor ,T_STKSQTY.storeNo,(Round(T_Items.LastCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as LastCost,T_Items.QtyLvl ";
                Fields = ((combobox_Unit.SelectedIndex > 0) ? string.Concat(Fields, ",(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = ", combobox_Unit.SelectedValue, ") as  UnitNm,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack5) END as Pack1,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END  as UntPri1,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm5,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0) END)END as stkQty ") : (Fields + ",(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNm,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit2) as  UnitNm2,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit3) as  UnitNm3,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit4) as  UnitNm4,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit5) as  UnitNm5,T_Items.Pack1,T_Items.Pack2,T_Items.Pack3,T_Items.Pack4,T_Items.Pack5 ,(Round(T_Items.UntPri1," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri1,(Round(T_Items.UntPri2," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri2,(Round(T_Items.UntPri3," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri3,(Round(T_Items.UntPri4," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri4,(Round(T_Items.UntPri5," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri5,CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END as stkQty,CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END as stkQty2,CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END as stkQty3,CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END as stkQty4,CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END as stkQty5 "));
            }
            else if (VarGeneral.InvType == 5)
            {
                Fields = "T_Items.Itm_No,T_Items.Eng_Des as itemNm, T_Items.DefultVendor ,T_STKSQTY.storeNo ";
                Fields = ((combobox_Unit.SelectedIndex > 0) ? string.Concat(Fields, ",(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = ", combobox_Unit.SelectedValue, ") as  UnitNm,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack5) END as Pack1,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END  as UntPri1,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm5,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0) END)END as stkQty ") : (Fields + ",(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNm,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit2) as  UnitNm2,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit3) as  UnitNm3,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit4) as  UnitNm4,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit5) as  UnitNm5,T_Items.Pack1,T_Items.Pack2,T_Items.Pack3,T_Items.Pack4,T_Items.Pack5 ,(Round(T_Items.UntPri1," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri1,(Round(T_Items.UntPri2," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri2,(Round(T_Items.UntPri3," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri3,(Round(T_Items.UntPri4," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri4,(Round(T_Items.UntPri5," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri5,CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END as stkQty,CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END as stkQty2,CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END as stkQty3,CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END as stkQty4,CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END as stkQty5 "));
            }
            return Fields + " ,T_SYSSETTING.LogImg ";
        }
        private string BuildRuleList()
        {
            HijriGregDates dateFormatter = new HijriGregDates();
            string Rule = "Where (T_QTYEXP.DatExper <> '' or T_QTYEXP.RunCod <> '') " + FlexField.Tag;
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
            if (VarGeneral.CheckDate(txtMFromDateExpir.Text) && txtMFromDateExpir.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMFromDateExpir.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_QTYEXP.DatExper  >= '" + dateFormatter.FormatGreg(txtMFromDateExpir.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_QTYEXP.DatExper  >= '" + dateFormatter.FormatHijri(txtMFromDateExpir.Text, "yyyy/MM/dd") + "'"));
            }
            if (VarGeneral.CheckDate(txtMToDateExpir.Text) && txtMToDateExpir.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMToDateExpir.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_QTYEXP.DatExper  <= '" + dateFormatter.FormatGreg(txtMToDateExpir.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_QTYEXP.DatExper  <= '" + dateFormatter.FormatHijri(txtMToDateExpir.Text, "yyyy/MM/dd") + "'"));
            }
            if (VarGeneral.CheckDate(txtExpirDateBegin.Text) && !VarGeneral.CheckDate(txtExpirDateTo.Text))
            {
                Rule = Rule + " and ( T_QTYEXP.DatExper  >= '" + txtExpirDateBegin.Text + "')";
            }
            else if (VarGeneral.CheckDate(txtExpirDateTo.Text) && !VarGeneral.CheckDate(txtExpirDateBegin.Text))
            {
                Rule = Rule + " and (T_QTYEXP.DatExper  <= '" + txtExpirDateTo.Text + "')";
            }
            else if (VarGeneral.CheckDate(txtExpirDateBegin.Text) && VarGeneral.CheckDate(txtExpirDateTo.Text))
            {
                string text = Rule;
                Rule = text + " and ( T_QTYEXP.DatExper  >= '" + txtExpirDateBegin.Text + "'  and T_QTYEXP.DatExper  <= '" + txtExpirDateTo.Text + "')";
            }
            if (combobox_Unit.SelectedIndex > 0)
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and (T_Items.Unit1 = ", combobox_Unit.SelectedValue, " or  T_Items.Unit2 = ", combobox_Unit.SelectedValue, " or T_Items.Unit3 = ", combobox_Unit.SelectedValue, " or T_Items.Unit4 = ", combobox_Unit.SelectedValue, " or T_Items.Unit5 = ", combobox_Unit.SelectedValue, ")");
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
            return Rule;
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            try
            {
                VarGeneral.InvType = 999;
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Items LEFT OUTER JOIN  T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID  LEFT OUTER JOIN T_STKSQTY On T_Items.Itm_No = T_STKSQTY.itmNo  LEFT OUTER JOIN T_QTYEXP On T_Items.Itm_No = T_QTYEXP.itmNo Left Join T_SYSSETTING ON T_Items.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                string Fields = BuildFieldList();
                Fields = " distinct " + Fields;
                _RepShow.Rule = BuildRuleList();
                _RepShow.Fields = Fields;
                try
                {
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
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
                    frm.Repvalue = "ItemsData";
                    frm.Tag = LangArEn;
                    frm.Repvalue = "ItemsData";
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
        private void FRItemsDataExpir_Load(object sender, EventArgs e)
        {
        }
        private void FillCombo()
        {
            combobox_RunNo.SelectedIndexChanged -= combobox_RunNo_SelectedIndexChanged;
            combobox_DateExpir.SelectedIndexChanged -= combobox_DateExpir_SelectedIndexChanged;
            try
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
                List<string> listRunCod = db.ExecuteQuery<string>("select distinct RunCod from T_QTYEXP where T_QTYEXP.RunCod != '' order by RunCod", new object[0]).ToList();
                listRunCod.Insert(0, "");
                combobox_RunNo.DataSource = listRunCod;
                combobox_RunNo.SelectedIndex = 0;
                List<string> listDateExpir = db.ExecuteQuery<string>("select distinct DatExper from T_QTYEXP where T_QTYEXP.DatExper != '' order by DatExper", new object[0]).ToList();
                listDateExpir.Insert(0, "");
                combobox_DateExpir.DataSource = listDateExpir;
                combobox_DateExpir.SelectedIndex = 0;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FillCombo:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            combobox_RunNo.SelectedIndexChanged += combobox_RunNo_SelectedIndexChanged;
            combobox_DateExpir.SelectedIndexChanged += combobox_DateExpir_SelectedIndexChanged;
        }
        private void txtExpirDateBegin_Click(object sender, EventArgs e)
        {
            txtExpirDateBegin.SelectAll();
        }
        private void txtExpirDateTo_Click(object sender, EventArgs e)
        {
            txtExpirDateTo.SelectAll();
        }
        private void txtExpirDateBegin_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtExpirDateBegin.Text))
                {
                    txtExpirDateBegin.Text = Convert.ToDateTime(txtExpirDateBegin.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    txtExpirDateBegin.Text = "";
                }
            }
            catch
            {
                txtExpirDateBegin.Text = "";
            }
        }
        private void txtExpirDateTo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtExpirDateTo.Text))
                {
                    txtExpirDateTo.Text = Convert.ToDateTime(txtExpirDateTo.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    txtExpirDateTo.Text = "";
                }
            }
            catch
            {
                txtExpirDateTo.Text = "";
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
        private void label16_Click(object sender, EventArgs e)
        {
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
