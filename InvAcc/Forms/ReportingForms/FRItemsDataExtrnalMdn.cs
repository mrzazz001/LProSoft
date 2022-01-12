using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Framework.Date;
using Framework.UI;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
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
    public partial  class FRItemsDataExtrnalMdn : Form
    { void avs(int arln)

{ 
 label7.Text=   (arln == 0 ? "  التصنيــــــف :  " : "  Classification:") ; label6.Text=   (arln == 0 ? "  إلى صنــــف :  " : "  to class:") ;  label10.Text=   (arln == 0 ? "  الوحــــــدة :  " : "  Unity:") ; label8.Text=   (arln == 0 ? "  المــــورد :  " : "  Supplier:") ; label5.Text=   (arln == 0 ? "  من صنــــف :  " : "  of category:") ; label9.Text=   (arln == 0 ? "  المســـتودع :  " : "  Repository:") ; groupBox3.Text=   (arln == 0 ? "  حسب الكمية  " : "  by quantity") ; label1.Text=   (arln == 0 ? "  مـــــن :  " : "  from:") ; label2.Text=   (arln == 0 ? "  إلـــــى :  " : "  to:") ; label3.Text=   (arln == 0 ? "  المندوب الخارجي :  " : "  External delegate:") ;}
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
        private T_User _User = new T_User();
        private int vTyp = 0;
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
                        frm.Repvalue = "ItemsData\u064fExtrnalMnd";
                        frm.Repvalue = "ItemsData\u064fExtrnalMnd";
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
        private TextBox txtInItemName;
        private TextBox txtClassName;
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
        private Label label7;
        private Label label6;
        private ButtonX button_SrchStoreNo;
        private RibbonBar ribbonBar1;
        private ButtonX button_SrchSuppNo;
        private ButtonX button_SrchClassNo;
        private ButtonX button_SrchItemTo;
        private ButtonX button_SrchItemFrom;
        private GroupBox groupBox3;
        private Label label2;
        private C1FlexGrid FlexField;
        private Label label9;
        private Label label1;
        private Label label8;
        private Label label5;
        private Label label3;
        private TextBox txtLegName;
        private ButtonX button_SrchLegNo;
        private TextBox txtLegNo;
        private Label label10;
        private C1.Win.C1Input.C1Button ButOk;
        private C1.Win.C1Input.C1Button ButExit;
        private ComboBoxEx combobox_Unit;
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
        public FRItemsDataExtrnalMdn(int vType)
        {
            InitializeComponent();this.Load += langloads;
            _User = dbc.StockUser(VarGeneral.UserNumber);
            vTyp = vType;
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ButExit.Text = "خــــروج Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.ISdirectPrinting) ? "طبـــاعة F5" : "عــــرض F5");
                groupBox3.Text = "حسب الكمية";
                label1.Text = "مـــــن :";
                label2.Text = "إلـــــى :";
                if (vTyp == 0)
                {
                    if (File.Exists(Application.StartupPath + "\\Script\\SecriptTegnicalCollage.dll"))
                    {
                        label3.Text = "الأستـــــــاذ :";
                        Text = "البضاعة المصروفة للأسـاتـذة";
                    }
                    else
                    {
                        label3.Text = "المندوب الخارجي :";
                    }
                }
                else if (vTyp == 1)
                {
                    if (File.Exists(Application.StartupPath + "\\Script\\SecriptTegnicalCollage.dll"))
                    {
                        label3.Text = "الطــــالـب :";
                        Text = "البضاعة المصروفة للطـــلاب";
                    }
                    else
                    {
                        label3.Text = "العميـــــــل :";
                    }
                }
                else
                {
                    label3.Text = "المـــــــورد :";
                }
                label5.Text = "من صنف :";
                label6.Text = "إلى صنف :";
                label7.Text = "التصنيـــف :";
                label8.Text = "المــــورد :";
                label9.Text = "المستودع :";
                return;
            }
            ButExit.Text = "Exit Esc";
            ButOk.Text = ((VarGeneral.GeneralPrinter.ISdirectPrinting) ? "Print F5" : "Show F5");
            groupBox3.Text = "Quantity";
            label1.Text = "From :";
            label2.Text = "To :";
            if (vTyp == 0)
            {
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptTegnicalCollage.dll"))
                {
                    label3.Text = "Teacher :";
                    Text = "Teachers goods";
                }
                else
                {
                    label3.Text = "Extrnal delegate :";
                }
            }
            else if (vTyp == 1)
            {
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptTegnicalCollage.dll"))
                {
                    label3.Text = "Student :";
                    Text = "Students goods";
                }
                else
                {
                    label3.Text = "Customer :";
                }
            }
            else
            {
                label3.Text = "Supplier :";
            }
            label5.Text = "From Item :";
            label6.Text = "To Item :";
            label7.Text = "Category :";
            label8.Text = "Supplier :";
            label9.Text = "Store :";
        }
        protected override void OnLoad(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRItemsDataExtrnalMdn));
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
            RepDef();
            FillCombo();  avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
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
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRItemsDataExtrnalMdn));
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
                Text = ((vTyp == 0) ? "البضاعة المصروفة للمندوبين" : ((vTyp == 1) ? "البضاعة المصروفة للعملاء" : "البضاعة المصروفة للمودرين"));
                FlexField.Rows.Count = 9;
                FlexField.SetData(0, 0, "أظهار");
                FlexField.SetData(0, 1, "أسم الحقل");
                FlexField.SetData(1, 1, "[رقم الصنف]");
                FlexField.SetData(1, 2, " T_Items.Itm_No ");
                FlexField.SetData(2, 1, "[إسم الصنف]");
                FlexField.SetData(2, 2, " T_Items.Arb_Des as itemNm");
                FlexField.SetData(3, 1, "[المورد]");
                FlexField.SetData(3, 2, " T_Items.DefultVendor ");
                FlexField.SetData(4, 1, "[رقم المستودع]");
                FlexField.SetData(4, 2, " T_StoreMnd.storeNo ");
                FlexField.SetData(5, 1, "[الكمية الأفتتاحية]");
                FlexField.SetData(5, 2, " T_StoreMnd.stkInt ");
                FlexField.SetData(6, 1, "[الكمية المتاحة]");
                FlexField.SetData(6, 2, " T_StoreMnd.stkQty as x");
                if (vTyp == 0)
                {
                    FlexField.SetData(7, 1, "[رقم المندوب]");
                    FlexField.SetData(7, 2, " T_Mndob.Mnd_No ");
                    FlexField.SetData(8, 1, "[إسم المندوب]");
                    FlexField.SetData(8, 2, " T_Mndob.Arb_Des as MndNm ");
                    txtLegNo.Tag = " T_StoreMnd.MndNo ";
                }
                else
                {
                    FlexField.SetData(7, 1, "[رقم العميل]");
                    FlexField.SetData(7, 2, " T_AccDef.AccDef_No as Mnd_No ");
                    FlexField.SetData(8, 1, "[إسم العميل]");
                    FlexField.SetData(8, 2, " T_AccDef.Arb_Des as MndNm ");
                    txtLegNo.Tag = " T_StoreMnd.CusVenNo ";
                }
            }
            else
            {
                Text = ((vTyp == 0) ? "Goods Disbursed To Delegates" : ((vTyp == 1) ? "Goods Disbursed To Customer" : "Goods Disbursed To Supliers"));
                Text = "بيانات الأصناف في مستودع المندوب الخارجي";
                FlexField.Rows.Count = 9;
                FlexField.SetData(0, 0, "Showing");
                FlexField.SetData(0, 1, "Filed Name");
                FlexField.SetData(1, 1, "[Item No]");
                FlexField.SetData(1, 2, " T_Items.Itm_No ");
                FlexField.SetData(2, 1, "[Item Name]");
                FlexField.SetData(2, 2, " T_Items.Eng_Des as itemNm  ");
                FlexField.SetData(3, 1, "[Defult Supp]");
                FlexField.SetData(3, 2, " T_Items.DefultVendor ");
                FlexField.SetData(4, 1, "[Store No]");
                FlexField.SetData(4, 2, " T_StoreMnd.storeNo ");
                FlexField.SetData(5, 1, "[Open Quantity]");
                FlexField.SetData(5, 2, " T_StoreMnd.stkInt ");
                FlexField.SetData(6, 1, "[Real Quantity]");
                FlexField.SetData(6, 2, " T_StoreMnd.stkQty as x");
                if (vTyp == 0)
                {
                    FlexField.SetData(7, 1, "[Delegate No]");
                    FlexField.SetData(7, 2, " T_Mndob.Mnd_No ");
                    FlexField.SetData(8, 1, "[Delegate Name]");
                    FlexField.SetData(8, 2, " T_Mndob.Arb_Des as MndNm ");
                    txtLegNo.Tag = " T_StoreMnd.MndNo ";
                }
                else
                {
                    FlexField.SetData(7, 1, "[Cust No]");
                    FlexField.SetData(7, 2, " T_AccDef.AccDef_No as Mnd_No ");
                    FlexField.SetData(8, 1, "[Cust Name]");
                    FlexField.SetData(8, 2, " T_AccDef.Arb_Des as MndNm ");
                    txtLegNo.Tag = " T_StoreMnd.CusVenNo ";
                }
            }
            RibunButtons();
        }
        private string BuildFieldList()
        {
            string Fields = "";
            for (int iiCnt = 1; iiCnt < FlexField.Rows.Count; iiCnt++)
            {
                if (VarGeneral.TString.TEmptyBool(FlexField.GetData(iiCnt, 0)) && FlexField.Rows[iiCnt].Visible)
                {
                    if (!string.IsNullOrEmpty(Fields))
                    {
                        Fields += ",";
                    }
                    Fields += FlexField.GetData(iiCnt, 2).ToString();
                }
            }
            Fields = ((combobox_Unit.SelectedIndex > 0) ? string.Concat(Fields, ",(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = ", combobox_Unit.SelectedValue, ") as  UnitNm,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm5,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack1 > 0 THEN (T_StoreMnd.stkQty / Pack1) ElSE (0 ) END) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack2 > 0 THEN (T_StoreMnd.stkQty / Pack2) ElSE (0 ) END) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack3 > 0 THEN (T_StoreMnd.stkQty / Pack3) ElSE (0 ) END) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack4 > 0 THEN (T_StoreMnd.stkQty / Pack4) ElSE (0 ) END) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack5 > 0 THEN (T_StoreMnd.stkQty / Pack5) ElSE (0 ) END)END as stkQty ") : (Fields + ",(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNm,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit2) as  UnitNm2,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit3) as  UnitNm3,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit4) as  UnitNm4,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit5) as  UnitNm5,CASE WHEN  Pack1 > 0 THEN (T_StoreMnd.stkQty / Pack1) ElSE (0 ) END as stkQty,CASE WHEN  Pack2 > 0 THEN (T_StoreMnd.stkQty / Pack2) ElSE (0 ) END as stkQty2,CASE WHEN  Pack3 > 0 THEN (T_StoreMnd.stkQty / Pack3) ElSE (0 ) END as stkQty3,CASE WHEN  Pack4 > 0 THEN (T_StoreMnd.stkQty / Pack4) ElSE (0 ) END as stkQty4,CASE WHEN  Pack5 > 0 THEN (T_StoreMnd.stkQty / Pack5) ElSE (0 ) END as stkQty5 "));
            return Fields + " ,T_SYSSETTING.LogImg ";
        }
        private string BuildRuleList()
        {
            HijriGregDates dateFormatter = new HijriGregDates();
            string Rule = "Where StkQty != 0  and (" + ((vTyp == 0) ? "  T_StoreMnd.MndNo <> '' )" : ((vTyp == 1) ? " T_StoreMnd.CusVenNo <> '' and T_AccDef.AccCat = 4 )" : " T_StoreMnd.CusVenNo <> '' and T_AccDef.AccCat = 5 )")) + FlexField.Tag;
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
            if (!string.IsNullOrEmpty(txtLegNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtLegNo.Tag, " = ", txtLegNo.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtClassNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtClassNo.Tag, " = ", txtClassNo.Text.Trim());
            }
            if (combobox_Unit.SelectedIndex > 0)
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and (T_Items.Unit1 = ", combobox_Unit.SelectedValue, " or  T_Items.Unit2 = ", combobox_Unit.SelectedValue, " or T_Items.Unit3 = ", combobox_Unit.SelectedValue, " or T_Items.Unit4 = ", combobox_Unit.SelectedValue, " or T_Items.Unit5 = ", combobox_Unit.SelectedValue, ")");
            }
            return Rule;
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            try
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_StoreMnd LEFT OUTER JOIN T_Items On T_Items.Itm_No = T_StoreMnd.itmNo LEFT OUTER JOIN  T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID  LEFT OUTER JOIN T_Mndob On T_StoreMnd.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_AccDef On T_StoreMnd.CusVenNo = T_AccDef.AccDef_No Left Join T_SYSSETTING ON T_Items.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
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
                    frm.Repvalue = "ItemsData\u064fExtrnalMnd";
                    frm.Tag = LangArEn;
                    frm.Repvalue = "ItemsData\u064fExtrnalMnd";
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
        private void FRItemsDataExtrnalMdn_Load(object sender, EventArgs e)
        {
        }
        private void button_SrchLegNo_Click(object sender, EventArgs e)
        {
            FrmSearch frm;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection;
            if (vTyp == 0)
            {
                columns_Names_visible.Clear();
                columns_Names_visible.Add("Mnd_No", new ColumnDictinary("الرقـــم", "No", ifDefault: true, ""));
                columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
                columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
                frm = new FrmSearch();
                frm.Tag = LangArEn;
                animalsAsCollection = columns_Names_visible;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                }
                VarGeneral.SFrmTyp = "T_Mndob_Extrnal";
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
                return;
            }
            if (vTyp == 1)
            {
                columns_Names_visible.Clear();
                columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
                columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
                columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
                columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
                columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, ""));
                columns_Names_visible.Add("TaxNo", new ColumnDictinary("الرقم الضريبي", "Tax No", ifDefault: false, ""));
                frm = new FrmSearch();
                frm.Tag = LangArEn;
                animalsAsCollection = columns_Names_visible;
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
                    txtLegNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtLegName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                    }
                    else
                    {
                        txtLegName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                    }
                }
                else
                {
                    txtLegNo.Text = "";
                    txtLegName.Text = "";
                }
                return;
            }
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
            frm = new FrmSearch();
            frm.Tag = LangArEn;
            animalsAsCollection = columns_Names_visible;
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
                txtLegNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtLegName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    txtLegName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
            }
            else
            {
                txtLegNo.Text = "";
                txtLegName.Text = "";
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
        private void ButOk_MouseMove(object sender, MouseEventArgs e)
        {
            ButOk.BackgroundImage = Properties.Resources.howver;
            ButOk.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void ButExit_MouseMove(object sender, MouseEventArgs e)
        {
            ButOk.BackgroundImage = Properties.Resources.howver;
            ButOk.BackgroundImageLayout = ImageLayout.Stretch;
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
    }
}
