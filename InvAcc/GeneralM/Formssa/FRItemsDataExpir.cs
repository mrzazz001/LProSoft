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
    public partial class FRItemsDataExpir : Form
    {
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
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!keyData.ToString().Contains("Control") && !keyData.ToString().ToLower().Contains("delete") && keyData.ToString().Contains("Alt"))
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
            InitializeComponent();
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
            RepDef();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRItemsDataExpir));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.ButOk = new C1.Win.C1Input.C1Button();
            this.ButExit = new C1.Win.C1Input.C1Button();
            this.groupBox_ExpirDate = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtMToDateExpir = new System.Windows.Forms.MaskedTextBox();
            this.txtMFromDateExpir = new System.Windows.Forms.MaskedTextBox();
            this.checkBox_Details = new System.Windows.Forms.CheckBox();
            this.FlexField = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupBox_DateExpir = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtExpirDateBegin = new System.Windows.Forms.MaskedTextBox();
            this.txtExpirDateTo = new System.Windows.Forms.MaskedTextBox();
            this.groupBox_Date = new System.Windows.Forms.GroupBox();
            this.txtMToDate = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMFromDate = new System.Windows.Forms.MaskedTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMIntoNo = new System.Windows.Forms.MaskedTextBox();
            this.txtMFromNo = new System.Windows.Forms.MaskedTextBox();
            this.combobox_RunNo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label10 = new System.Windows.Forms.Label();
            this.combobox_Unit = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtInItemName = new System.Windows.Forms.TextBox();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.txtFItemName = new System.Windows.Forms.TextBox();
            this.txtStoreName = new System.Windows.Forms.TextBox();
            this.txtSuppName = new System.Windows.Forms.TextBox();
            this.txtFItemNo = new System.Windows.Forms.TextBox();
            this.txtInItemNo = new System.Windows.Forms.TextBox();
            this.txtClassNo = new System.Windows.Forms.TextBox();
            this.txtStoreNo = new System.Windows.Forms.TextBox();
            this.txtSuppNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_SrchStoreNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchSuppNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchClassNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchItemTo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchItemFrom = new DevComponents.DotNetBar.ButtonX();
            this.label14 = new System.Windows.Forms.Label();
            this.combobox_ExpirRunNo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.combobox_DateExpir = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label11 = new System.Windows.Forms.Label();
            this.combobox_RunDateExpir = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.PanelSpecialContainer.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButExit)).BeginInit();
            this.groupBox_ExpirDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlexField)).BeginInit();
            this.groupBox_DateExpir.SuspendLayout();
            this.groupBox_Date.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelSpecialContainer
            // 
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar1);
            this.PanelSpecialContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSpecialContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelSpecialContainer.Name = "PanelSpecialContainer";
            this.PanelSpecialContainer.Size = new System.Drawing.Size(479, 328);
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
            this.ribbonBar1.Controls.Add(this.groupBox_ExpirDate);
            this.ribbonBar1.Controls.Add(this.checkBox_Details);
            this.ribbonBar1.Controls.Add(this.FlexField);
            this.ribbonBar1.Controls.Add(this.groupBox_DateExpir);
            this.ribbonBar1.Controls.Add(this.groupBox_Date);
            this.ribbonBar1.Controls.Add(this.groupBox3);
            this.ribbonBar1.Controls.Add(this.combobox_RunNo);
            this.ribbonBar1.Controls.Add(this.label10);
            this.ribbonBar1.Controls.Add(this.combobox_Unit);
            this.ribbonBar1.Controls.Add(this.label8);
            this.ribbonBar1.Controls.Add(this.label5);
            this.ribbonBar1.Controls.Add(this.label9);
            this.ribbonBar1.Controls.Add(this.txtInItemName);
            this.ribbonBar1.Controls.Add(this.txtClassName);
            this.ribbonBar1.Controls.Add(this.txtFItemName);
            this.ribbonBar1.Controls.Add(this.txtStoreName);
            this.ribbonBar1.Controls.Add(this.txtSuppName);
            this.ribbonBar1.Controls.Add(this.txtFItemNo);
            this.ribbonBar1.Controls.Add(this.txtInItemNo);
            this.ribbonBar1.Controls.Add(this.txtClassNo);
            this.ribbonBar1.Controls.Add(this.txtStoreNo);
            this.ribbonBar1.Controls.Add(this.txtSuppNo);
            this.ribbonBar1.Controls.Add(this.label7);
            this.ribbonBar1.Controls.Add(this.label6);
            this.ribbonBar1.Controls.Add(this.button_SrchStoreNo);
            this.ribbonBar1.Controls.Add(this.button_SrchSuppNo);
            this.ribbonBar1.Controls.Add(this.button_SrchClassNo);
            this.ribbonBar1.Controls.Add(this.button_SrchItemTo);
            this.ribbonBar1.Controls.Add(this.button_SrchItemFrom);
            this.ribbonBar1.Controls.Add(this.label14);
            this.ribbonBar1.Controls.Add(this.combobox_ExpirRunNo);
            this.ribbonBar1.Controls.Add(this.combobox_DateExpir);
            this.ribbonBar1.Controls.Add(this.label11);
            this.ribbonBar1.Controls.Add(this.combobox_RunDateExpir);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(479, 328);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 1101;
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
            // 
            // ButOk
            // 
            this.ButOk.BackgroundImage = global::InvAcc.Properties.Resources.print;
            this.ButOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButOk.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButOk.Location = new System.Drawing.Point(216, 265);
            this.ButOk.Name = "ButOk";
            this.ButOk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButOk.Size = new System.Drawing.Size(227, 35);
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
            this.ButExit.Location = new System.Drawing.Point(31, 265);
            this.ButExit.Name = "ButExit";
            this.ButExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButExit.Size = new System.Drawing.Size(179, 35);
            this.ButExit.TabIndex = 6747;
            this.ButExit.Text = "خروج | ESC";
            this.ButExit.UseVisualStyleBackColor = true;
            this.ButExit.Click += new System.EventHandler(this.ButExit_Click);
            this.ButExit.MouseLeave += new System.EventHandler(this.ButExit_MouseLeave);
            this.ButExit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButExit_MouseMove);
            // 
            // groupBox_ExpirDate
            // 
            this.groupBox_ExpirDate.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_ExpirDate.Controls.Add(this.label15);
            this.groupBox_ExpirDate.Controls.Add(this.label16);
            this.groupBox_ExpirDate.Controls.Add(this.txtMToDateExpir);
            this.groupBox_ExpirDate.Controls.Add(this.txtMFromDateExpir);
            this.groupBox_ExpirDate.Location = new System.Drawing.Point(5, 8);
            this.groupBox_ExpirDate.Name = "groupBox_ExpirDate";
            this.groupBox_ExpirDate.Size = new System.Drawing.Size(467, 39);
            this.groupBox_ExpirDate.TabIndex = 6734;
            this.groupBox_ExpirDate.TabStop = false;
            this.groupBox_ExpirDate.Text = "حسب تاريخ الصلاحية ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(305, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 13);
            this.label15.TabIndex = 1141;
            this.label15.Text = "مـــــن :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(147, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 13);
            this.label16.TabIndex = 1140;
            this.label16.Text = "إلـــــى :";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // txtMToDateExpir
            // 
            this.txtMToDateExpir.Location = new System.Drawing.Point(45, 13);
            this.txtMToDateExpir.Mask = "0000/00/00";
            this.txtMToDateExpir.Name = "txtMToDateExpir";
            this.txtMToDateExpir.Size = new System.Drawing.Size(97, 20);
            this.txtMToDateExpir.TabIndex = 4;
            this.txtMToDateExpir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMToDateExpir.Click += new System.EventHandler(this.txtMToDateExpir_Click);
            this.txtMToDateExpir.Leave += new System.EventHandler(this.txtMToDateExpir_Leave);
            // 
            // txtMFromDateExpir
            // 
            this.txtMFromDateExpir.Location = new System.Drawing.Point(203, 13);
            this.txtMFromDateExpir.Mask = "0000/00/00";
            this.txtMFromDateExpir.Name = "txtMFromDateExpir";
            this.txtMFromDateExpir.Size = new System.Drawing.Size(97, 20);
            this.txtMFromDateExpir.TabIndex = 3;
            this.txtMFromDateExpir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMFromDateExpir.Click += new System.EventHandler(this.txtMFromDateExpir_Click);
            this.txtMFromDateExpir.Leave += new System.EventHandler(this.txtMFromDateExpir_Leave);
            // 
            // checkBox_Details
            // 
            this.checkBox_Details.AutoSize = true;
            this.checkBox_Details.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_Details.Checked = true;
            this.checkBox_Details.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Details.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_Details.Location = new System.Drawing.Point(7, 235);
            this.checkBox_Details.Name = "checkBox_Details";
            this.checkBox_Details.Size = new System.Drawing.Size(63, 17);
            this.checkBox_Details.TabIndex = 6729;
            this.checkBox_Details.Text = "تفصيلي";
            this.checkBox_Details.UseVisualStyleBackColor = false;
            this.checkBox_Details.Visible = false;
            // 
            // FlexField
            // 
            this.FlexField.BackColor = System.Drawing.Color.White;
            this.FlexField.ColumnInfo = resources.GetString("FlexField.ColumnInfo");
            this.FlexField.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FlexField.Location = new System.Drawing.Point(6, 355);
            this.FlexField.Name = "FlexField";
            this.FlexField.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FlexField.Rows.DefaultSize = 19;
            this.FlexField.Size = new System.Drawing.Size(224, 231);
            this.FlexField.StyleInfo = resources.GetString("FlexField.StyleInfo");
            this.FlexField.TabIndex = 1146;
            // 
            // groupBox_DateExpir
            // 
            this.groupBox_DateExpir.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_DateExpir.Controls.Add(this.label12);
            this.groupBox_DateExpir.Controls.Add(this.label13);
            this.groupBox_DateExpir.Controls.Add(this.txtExpirDateBegin);
            this.groupBox_DateExpir.Controls.Add(this.txtExpirDateTo);
            this.groupBox_DateExpir.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.groupBox_DateExpir.Location = new System.Drawing.Point(1064, 62);
            this.groupBox_DateExpir.Name = "groupBox_DateExpir";
            this.groupBox_DateExpir.Size = new System.Drawing.Size(424, 48);
            this.groupBox_DateExpir.TabIndex = 6723;
            this.groupBox_DateExpir.TabStop = false;
            this.groupBox_DateExpir.Text = "حسب تاريخ الصلاحية";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(348, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 857;
            this.label12.Text = "مـــــن :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(137, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 13);
            this.label13.TabIndex = 859;
            this.label13.Text = "إلـــــى :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtExpirDateBegin
            // 
            this.txtExpirDateBegin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtExpirDateBegin.Location = new System.Drawing.Point(234, 19);
            this.txtExpirDateBegin.Mask = "0000/00/00";
            this.txtExpirDateBegin.Name = "txtExpirDateBegin";
            this.txtExpirDateBegin.Size = new System.Drawing.Size(108, 21);
            this.txtExpirDateBegin.TabIndex = 860;
            this.txtExpirDateBegin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtExpirDateBegin.Click += new System.EventHandler(this.txtExpirDateBegin_Click);
            this.txtExpirDateBegin.Leave += new System.EventHandler(this.txtExpirDateBegin_Leave);
            // 
            // txtExpirDateTo
            // 
            this.txtExpirDateTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtExpirDateTo.Location = new System.Drawing.Point(23, 19);
            this.txtExpirDateTo.Mask = "0000/00/00";
            this.txtExpirDateTo.Name = "txtExpirDateTo";
            this.txtExpirDateTo.Size = new System.Drawing.Size(108, 21);
            this.txtExpirDateTo.TabIndex = 861;
            this.txtExpirDateTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtExpirDateTo.Click += new System.EventHandler(this.txtExpirDateTo_Click);
            this.txtExpirDateTo.Leave += new System.EventHandler(this.txtExpirDateTo_Leave);
            // 
            // groupBox_Date
            // 
            this.groupBox_Date.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_Date.Controls.Add(this.txtMToDate);
            this.groupBox_Date.Controls.Add(this.label3);
            this.groupBox_Date.Controls.Add(this.label4);
            this.groupBox_Date.Controls.Add(this.txtMFromDate);
            this.groupBox_Date.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.groupBox_Date.Location = new System.Drawing.Point(805, 8);
            this.groupBox_Date.Name = "groupBox_Date";
            this.groupBox_Date.Size = new System.Drawing.Size(422, 48);
            this.groupBox_Date.TabIndex = 1109;
            this.groupBox_Date.TabStop = false;
            this.groupBox_Date.Text = "حسب تاريخ الركود";
            // 
            // txtMToDate
            // 
            this.txtMToDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMToDate.Location = new System.Drawing.Point(25, 19);
            this.txtMToDate.Mask = "0000/00/00";
            this.txtMToDate.Name = "txtMToDate";
            this.txtMToDate.Size = new System.Drawing.Size(108, 21);
            this.txtMToDate.TabIndex = 19;
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
            this.label3.Location = new System.Drawing.Point(347, 23);
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
            this.label4.Location = new System.Drawing.Point(139, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 861;
            this.label4.Text = "إلـــــى :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMFromDate
            // 
            this.txtMFromDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMFromDate.Location = new System.Drawing.Point(233, 19);
            this.txtMFromDate.Mask = "0000/00/00";
            this.txtMFromDate.Name = "txtMFromDate";
            this.txtMFromDate.Size = new System.Drawing.Size(108, 21);
            this.txtMFromDate.TabIndex = 18;
            this.txtMFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMFromDate.Click += new System.EventHandler(this.txtMFromDate_Click);
            this.txtMFromDate.Leave += new System.EventHandler(this.txtMFromDate_Leave);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtMIntoNo);
            this.groupBox3.Controls.Add(this.txtMFromNo);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.groupBox3.Location = new System.Drawing.Point(830, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(424, 48);
            this.groupBox3.TabIndex = 1145;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "حسب الكمية";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(348, 24);
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
            this.label2.Location = new System.Drawing.Point(137, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 859;
            this.label2.Text = "إلـــــى :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMIntoNo
            // 
            this.txtMIntoNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMIntoNo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtMIntoNo.Location = new System.Drawing.Point(23, 19);
            this.txtMIntoNo.Mask = "00000";
            this.txtMIntoNo.Name = "txtMIntoNo";
            this.txtMIntoNo.Size = new System.Drawing.Size(108, 22);
            this.txtMIntoNo.TabIndex = 21;
            this.txtMIntoNo.Tag = " T_STKSQTY.stkQty  ";
            this.txtMIntoNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMIntoNo.Click += new System.EventHandler(this.txtMIntoNo_Click);
            // 
            // txtMFromNo
            // 
            this.txtMFromNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMFromNo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtMFromNo.Location = new System.Drawing.Point(234, 19);
            this.txtMFromNo.Mask = "00000";
            this.txtMFromNo.Name = "txtMFromNo";
            this.txtMFromNo.Size = new System.Drawing.Size(108, 22);
            this.txtMFromNo.TabIndex = 20;
            this.txtMFromNo.Tag = " T_STKSQTY.stkQty ";
            this.txtMFromNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMFromNo.Click += new System.EventHandler(this.txtMFromNo_Click);
            // 
            // combobox_RunNo
            // 
            this.combobox_RunNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combobox_RunNo.DisplayMember = "Text";
            this.combobox_RunNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_RunNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_RunNo.FormattingEnabled = true;
            this.combobox_RunNo.ItemHeight = 14;
            this.combobox_RunNo.Location = new System.Drawing.Point(251, 81);
            this.combobox_RunNo.Name = "combobox_RunNo";
            this.combobox_RunNo.Size = new System.Drawing.Size(136, 20);
            this.combobox_RunNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combobox_RunNo.TabIndex = 6721;
            this.combobox_RunNo.SelectedIndexChanged += new System.EventHandler(this.combobox_RunNo_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(388, 237);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 6720;
            this.label10.Text = "الوحـــــــــــــدة :";
            // 
            // combobox_Unit
            // 
            this.combobox_Unit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combobox_Unit.DisplayMember = "Text";
            this.combobox_Unit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_Unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_Unit.FormattingEnabled = true;
            this.combobox_Unit.ItemHeight = 14;
            this.combobox_Unit.Location = new System.Drawing.Point(87, 233);
            this.combobox_Unit.Name = "combobox_Unit";
            this.combobox_Unit.Size = new System.Drawing.Size(300, 20);
            this.combobox_Unit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combobox_Unit.TabIndex = 6719;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(388, 186);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 1117;
            this.label8.Text = "المـــــــــــــورد :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(388, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 1118;
            this.label5.Text = "مــــن صــــنف :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(388, 211);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 1147;
            this.label9.Text = "المســـــــتودع :";
            // 
            // txtInItemName
            // 
            this.txtInItemName.BackColor = System.Drawing.Color.Ivory;
            this.txtInItemName.ForeColor = System.Drawing.Color.White;
            this.txtInItemName.Location = new System.Drawing.Point(5, 132);
            this.txtInItemName.Name = "txtInItemName";
            this.txtInItemName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtInItemName, false);
            this.txtInItemName.Size = new System.Drawing.Size(243, 20);
            this.txtInItemName.TabIndex = 6;
            this.txtInItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtClassName
            // 
            this.txtClassName.BackColor = System.Drawing.Color.Ivory;
            this.txtClassName.ForeColor = System.Drawing.Color.White;
            this.txtClassName.Location = new System.Drawing.Point(5, 157);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtClassName, false);
            this.txtClassName.Size = new System.Drawing.Size(243, 20);
            this.txtClassName.TabIndex = 9;
            this.txtClassName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFItemName
            // 
            this.txtFItemName.BackColor = System.Drawing.Color.Ivory;
            this.txtFItemName.ForeColor = System.Drawing.Color.White;
            this.txtFItemName.Location = new System.Drawing.Point(5, 107);
            this.txtFItemName.Name = "txtFItemName";
            this.txtFItemName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtFItemName, false);
            this.txtFItemName.Size = new System.Drawing.Size(243, 20);
            this.txtFItemName.TabIndex = 3;
            this.txtFItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStoreName
            // 
            this.txtStoreName.BackColor = System.Drawing.Color.Ivory;
            this.txtStoreName.ForeColor = System.Drawing.Color.White;
            this.txtStoreName.Location = new System.Drawing.Point(5, 207);
            this.txtStoreName.Name = "txtStoreName";
            this.txtStoreName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtStoreName, false);
            this.txtStoreName.Size = new System.Drawing.Size(243, 20);
            this.txtStoreName.TabIndex = 15;
            this.txtStoreName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSuppName
            // 
            this.txtSuppName.BackColor = System.Drawing.Color.Ivory;
            this.txtSuppName.ForeColor = System.Drawing.Color.White;
            this.txtSuppName.Location = new System.Drawing.Point(5, 182);
            this.txtSuppName.Name = "txtSuppName";
            this.txtSuppName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtSuppName, false);
            this.txtSuppName.Size = new System.Drawing.Size(243, 20);
            this.txtSuppName.TabIndex = 12;
            this.txtSuppName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFItemNo
            // 
            this.txtFItemNo.BackColor = System.Drawing.Color.White;
            this.txtFItemNo.Location = new System.Drawing.Point(281, 107);
            this.txtFItemNo.Name = "txtFItemNo";
            this.txtFItemNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtFItemNo, false);
            this.txtFItemNo.Size = new System.Drawing.Size(106, 20);
            this.txtFItemNo.TabIndex = 1;
            this.txtFItemNo.Tag = " T_Items.Itm_No ";
            this.txtFItemNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtInItemNo
            // 
            this.txtInItemNo.BackColor = System.Drawing.Color.White;
            this.txtInItemNo.Location = new System.Drawing.Point(281, 132);
            this.txtInItemNo.Name = "txtInItemNo";
            this.txtInItemNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtInItemNo, false);
            this.txtInItemNo.Size = new System.Drawing.Size(106, 20);
            this.txtInItemNo.TabIndex = 4;
            this.txtInItemNo.Tag = " T_Items.Itm_No ";
            this.txtInItemNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtClassNo
            // 
            this.txtClassNo.BackColor = System.Drawing.Color.White;
            this.txtClassNo.Location = new System.Drawing.Point(281, 157);
            this.txtClassNo.Name = "txtClassNo";
            this.txtClassNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtClassNo, false);
            this.txtClassNo.Size = new System.Drawing.Size(106, 20);
            this.txtClassNo.TabIndex = 7;
            this.txtClassNo.Tag = " T_CATEGORY.CAT_ID ";
            this.txtClassNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStoreNo
            // 
            this.txtStoreNo.BackColor = System.Drawing.Color.White;
            this.txtStoreNo.Location = new System.Drawing.Point(281, 207);
            this.txtStoreNo.Name = "txtStoreNo";
            this.txtStoreNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtStoreNo, false);
            this.txtStoreNo.Size = new System.Drawing.Size(106, 20);
            this.txtStoreNo.TabIndex = 13;
            this.txtStoreNo.Tag = " T_STKSQTY.storeNo ";
            this.txtStoreNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSuppNo
            // 
            this.txtSuppNo.BackColor = System.Drawing.Color.White;
            this.txtSuppNo.Location = new System.Drawing.Point(281, 182);
            this.txtSuppNo.Name = "txtSuppNo";
            this.txtSuppNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtSuppNo, false);
            this.txtSuppNo.Size = new System.Drawing.Size(106, 20);
            this.txtSuppNo.TabIndex = 10;
            this.txtSuppNo.Tag = " T_Items.DefultVendor ";
            this.txtSuppNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(388, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 1120;
            this.label7.Text = "التصنيـــــــــف :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(388, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 1119;
            this.label6.Text = "إلـــى صــــنف :";
            // 
            // button_SrchStoreNo
            // 
            this.button_SrchStoreNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchStoreNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchStoreNo.Location = new System.Drawing.Point(251, 207);
            this.button_SrchStoreNo.Name = "button_SrchStoreNo";
            this.button_SrchStoreNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchStoreNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchStoreNo.Symbol = "";
            this.button_SrchStoreNo.SymbolSize = 12F;
            this.button_SrchStoreNo.TabIndex = 14;
            this.button_SrchStoreNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchStoreNo.Click += new System.EventHandler(this.button_SrchStoreNo_Click);
            // 
            // button_SrchSuppNo
            // 
            this.button_SrchSuppNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchSuppNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchSuppNo.Location = new System.Drawing.Point(251, 182);
            this.button_SrchSuppNo.Name = "button_SrchSuppNo";
            this.button_SrchSuppNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchSuppNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchSuppNo.Symbol = "";
            this.button_SrchSuppNo.SymbolSize = 12F;
            this.button_SrchSuppNo.TabIndex = 11;
            this.button_SrchSuppNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchSuppNo.Click += new System.EventHandler(this.button_SrchSuppNo_Click);
            // 
            // button_SrchClassNo
            // 
            this.button_SrchClassNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchClassNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchClassNo.Location = new System.Drawing.Point(251, 157);
            this.button_SrchClassNo.Name = "button_SrchClassNo";
            this.button_SrchClassNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchClassNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchClassNo.Symbol = "";
            this.button_SrchClassNo.SymbolSize = 12F;
            this.button_SrchClassNo.TabIndex = 8;
            this.button_SrchClassNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchClassNo.Click += new System.EventHandler(this.button_SrchClassNo_Click);
            // 
            // button_SrchItemTo
            // 
            this.button_SrchItemTo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchItemTo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchItemTo.Location = new System.Drawing.Point(251, 132);
            this.button_SrchItemTo.Name = "button_SrchItemTo";
            this.button_SrchItemTo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchItemTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchItemTo.Symbol = "";
            this.button_SrchItemTo.SymbolSize = 12F;
            this.button_SrchItemTo.TabIndex = 5;
            this.button_SrchItemTo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchItemTo.Click += new System.EventHandler(this.button_SrchItemTo_Click);
            // 
            // button_SrchItemFrom
            // 
            this.button_SrchItemFrom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchItemFrom.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchItemFrom.Location = new System.Drawing.Point(251, 107);
            this.button_SrchItemFrom.Name = "button_SrchItemFrom";
            this.button_SrchItemFrom.Size = new System.Drawing.Size(26, 20);
            this.button_SrchItemFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchItemFrom.Symbol = "";
            this.button_SrchItemFrom.SymbolSize = 12F;
            this.button_SrchItemFrom.TabIndex = 2;
            this.button_SrchItemFrom.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchItemFrom.Click += new System.EventHandler(this.button_SrchItemFrom_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(388, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 13);
            this.label14.TabIndex = 6728;
            this.label14.Text = "تاريخ الصلاحية :";
            // 
            // combobox_ExpirRunNo
            // 
            this.combobox_ExpirRunNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combobox_ExpirRunNo.DisplayMember = "Text";
            this.combobox_ExpirRunNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_ExpirRunNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_ExpirRunNo.Enabled = false;
            this.combobox_ExpirRunNo.FormattingEnabled = true;
            this.combobox_ExpirRunNo.ItemHeight = 14;
            this.combobox_ExpirRunNo.Location = new System.Drawing.Point(6, 56);
            this.combobox_ExpirRunNo.Name = "combobox_ExpirRunNo";
            this.combobox_ExpirRunNo.Size = new System.Drawing.Size(242, 20);
            this.combobox_ExpirRunNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combobox_ExpirRunNo.TabIndex = 6727;
            // 
            // combobox_DateExpir
            // 
            this.combobox_DateExpir.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combobox_DateExpir.DisplayMember = "Text";
            this.combobox_DateExpir.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_DateExpir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_DateExpir.FormattingEnabled = true;
            this.combobox_DateExpir.ItemHeight = 14;
            this.combobox_DateExpir.Location = new System.Drawing.Point(251, 56);
            this.combobox_DateExpir.Name = "combobox_DateExpir";
            this.combobox_DateExpir.Size = new System.Drawing.Size(136, 20);
            this.combobox_DateExpir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combobox_DateExpir.TabIndex = 6726;
            this.combobox_DateExpir.SelectedIndexChanged += new System.EventHandler(this.combobox_DateExpir_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(388, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 13);
            this.label11.TabIndex = 6725;
            this.label11.Text = "رقــم التصنيــع :";
            // 
            // combobox_RunDateExpir
            // 
            this.combobox_RunDateExpir.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combobox_RunDateExpir.DisplayMember = "Text";
            this.combobox_RunDateExpir.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_RunDateExpir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_RunDateExpir.Enabled = false;
            this.combobox_RunDateExpir.FormattingEnabled = true;
            this.combobox_RunDateExpir.ItemHeight = 14;
            this.combobox_RunDateExpir.Location = new System.Drawing.Point(6, 81);
            this.combobox_RunDateExpir.Name = "combobox_RunDateExpir";
            this.combobox_RunDateExpir.Size = new System.Drawing.Size(242, 20);
            this.combobox_RunDateExpir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combobox_RunDateExpir.TabIndex = 6724;
            // 
            // netResize1
            // 
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            // 
            // FRItemsDataExpir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 328);
            this.Controls.Add(this.PanelSpecialContainer);
            this.Icon = global::InvAcc.Properties.Resources.favicon;
            this.KeyPreview = true;
            this.Name = "FRItemsDataExpir";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FRItemsDataExpir_Load);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.VisibleChanged += new System.EventHandler(this.FRInvoice_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.PanelSpecialContainer.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            this.ribbonBar1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButExit)).EndInit();
            this.groupBox_ExpirDate.ResumeLayout(false);
            this.groupBox_ExpirDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlexField)).EndInit();
            this.groupBox_DateExpir.ResumeLayout(false);
            this.groupBox_DateExpir.PerformLayout();
            this.groupBox_Date.ResumeLayout(false);
            this.groupBox_Date.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);

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
