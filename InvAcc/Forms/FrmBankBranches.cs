using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using Library.RepShow;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmBankBranches : Form
    { void avs(int arln)

{ 
 label22.Text=   (arln == 0 ? "  الــرقم الضريبـــي :  " : "  Tax number:") ; label21.Text=   (arln == 0 ? "  العمــولة البنكيـــة :  " : "  Bank commission:") ; label20.Text=   (arln == 0 ? "  الرمز البريدي :  " : "  Postal code :") ; label6.Text=   (arln == 0 ? "  العنوان :  " : "  Address :") ; label7.Text=   (arln == 0 ? "  الإيميل :  " : "  Email:") ; label8.Text=   (arln == 0 ? "  البلد :  " : "  Country :") ; label12.Text=   (arln == 0 ? "  الفاكس :  " : "  Fax:") ; label13.Text=   (arln == 0 ? "  الجوال :  " : "  cell phone :") ; label9.Text=   (arln == 0 ? "  الهاتف :  " : "  the phone :") ; label11.Text=   (arln == 0 ? "  ص . ب :  " : "  s . B :") ; label18.Text=   (arln == 0 ? "  السعر الإفتراضي :  " : "  Default price:") ; label10.Text=   (arln == 0 ? "  عمر الدين :  " : "  Omar Eddin:") ; label16.Text=   (arln == 0 ? "  حد المديونية :  " : "  Debt Limit:") ; label15.Text=   (arln == 0 ? "  الرصيد الحالي :  " : "  current balance :") ; label14.Text=   (arln == 0 ? "  دائن :  " : "  Creditor :") ; label17.Text=   (arln == 0 ? "  مدين :  " : "  Debit :") ; label19.Text=   (arln == 0 ? "  إسم المسؤول :  " : "  Name of the manager :") ; label3.Text=   (arln == 0 ? "  البنك الرئيسي :  " : "  Main Bank:") ; label4.Text=   (arln == 0 ? "  حساب الفرع :  " : "  Branch account:") ; label2.Text=   (arln == 0 ? "  الإسم الإنجليزي :  " : "  English name:") ; label1.Text=   (arln == 0 ? "  الإسم العربي :  " : "  Arabic name:") ; buttonX_CustomerStoped.Text=   (arln == 0 ? "  الفروع الموقوفة  " : "  Suspended branches") ; label5.Text=   (arln == 0 ? "  الســـبب :  " : "  The reason:") ; checkBoxX_Stoped.Text=   (arln == 0 ? "  إيقاف الفرع   " : "  Branch off") ; superTabControl_Main1.Text=   (arln == 0 ? "  superTabControl3  " : "  superTabControl3") ; Button_Close.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; Button_Search.Text=   (arln == 0 ? "  بحث  " : "  Search") ; Button_Delete.Text=   (arln == 0 ? "  حذف  " : "  delete") ; Button_Save.Text=   (arln == 0 ? "  حفظ  " : "  save") ; Button_Add.Text=   (arln == 0 ? "  إضافة  " : "  addition") ; superTabControl_Main2.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; Button_First.Text=   (arln == 0 ? "  الأول  " : "  the first") ; Button_Prev.Text=   (arln == 0 ? "  السابق  " : "  the previous") ; lable_Records.Text=   (arln == 0 ? "  ---  " : "  ---") ; Button_Next.Text=   (arln == 0 ? "  التالي  " : "  next one") ; Button_Last.Text=   (arln == 0 ? "  الأخير  " : "  the last one") ; ToolStripMenuItem_Rep.Text=   (arln == 0 ? "  إظهار التقرير  " : "  Show report") ; ToolStripMenuItem_Det.Text=   (arln == 0 ? "  إظهار التفاصيل  " : "  Show details") ; panelEx3.Text=   (arln == 0 ? "  Fill Panel  " : "  Fill Panel") ; DGV_Main.Text=   (arln == 0 ? "    " : "    ") ; DGV_Main.Text=   (arln == 0 ? "  جميــع السجــــلات  " : "  All records") ; DGV_Main.Text=   (arln == 0 ? "    " : "    ") ; superTabControl_DGV.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; textBox_search.Text=   (arln == 0 ? "  ...  " : "  ...") ; Button_ExportTable2.Text=   (arln == 0 ? "  تصدير  " : "  Export") ; /*Button_PrintTable.Text=   (arln == 0 ? "  طباعة  " : "  Print") ; */panelEx2.Text=   (arln == 0 ? "  Click to collapse  " : "  Click to collapse") ; Text = "كــرت فروع البنوك المصرفية";this.Text=   (arln == 0 ? "  كــرت فروع البنوك المصرفية  " : "  Bank branch cards ك") ;}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
        private T_AccDef _AccDefBind = new T_AccDef();
        private DockSite barBottomDockSite;
        private DockSite barLeftDockSite;
        private DockSite barRightDockSite;
        private DockSite barTopDockSite;
        private ButtonX buttonX_CustomerStoped;
        private ButtonX buttonX_SerchAccNo;
        private bool canUpdate = true;
        private CheckBoxX checkBoxX_Stoped;
        private ComboBox CmbPrice;
       // private IContainer components = null;
        private T_AccDef data_this;
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private DockSite dockSite1;
        private DockSite dockSite2;
        private DockSite dockSite3;
        private DockSite dockSite4;
        private ExpandableSplitter expandableSplitter1;
#pragma warning disable CS0414 // The field 'FrmBankBranches.FlagUpdate' is assigned but its value is never used
        private string FlagUpdate = "";
#pragma warning restore CS0414 // The field 'FrmBankBranches.FlagUpdate' is assigned but its value is never used
        private ImageList imageList1;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label2;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private LabelItem lable_Records;
        private int LangArEn = 0;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private System.Windows.Forms.OpenFileDialog  openFileDialog1;
        private Panel panel1;
        private PanelEx panelEx2;
        private PanelEx panelEx3;
        private Panel PanelSpecialContainer;
        private T_User permission = new T_User();
        private List<string> pkeys = new List<string>();
        private RibbonBar ribbonBar_DGV;
        private RibbonBar ribbonBar_Tasks;
        private RibbonBar ribbonBar1;
        private System.Windows.Forms. SaveFileDialog saveFileDialog1;
        private FormState statex;
        private SuperTabControl superTabControl_DGV;
        private SuperTabControl superTabControl_Main1;
        private SuperTabControl superTabControl_Main2;
        private TextBox textBox_ID;
        private Timer timer1;
        private Timer timerInfoBallon;
        private TextBox txtAddress;
        private IntegerInput txtAgeLimit;
        private TextBox txtArbDes;
        private DoubleInput txtBalance;
        private DoubleInput txtBankComm;
        private TextBox txtCity;
        private DoubleInput txtCredit;
        private DoubleInput txtCreditLimit;
        private DoubleInput txtDeb;
        private TextBox txtEMail;
        private TextBox txtEngDes;
        private TextBox txtFax;
        private TextBox txtMainAccName;
        private TextBox txtMainAccNo;
        private TextBox txtMobile;
        private TextBox txtPersonalName;
        private TextBox txtRessonsStoped;
        private TextBox txtTaxNo;
        private TextBox txtTele1;
        private TextBox txtTele2;
        private TextBox txtZipCod;
        protected ButtonItem Button_Add;
        protected ButtonItem Button_Close;
        protected ButtonItem Button_Delete;
        protected ButtonItem Button_ExportTable2;
        protected ButtonItem Button_First;
        protected ButtonItem Button_Last;
        protected ButtonItem Button_Next;
        protected ButtonItem Button_Prev;
        protected ButtonItem Button_PrintTable;
        protected ButtonItem Button_Save;
        protected ButtonItem Button_Search;
        protected bool CanInsert = true;
        protected ContextMenuStrip contextMenuStrip1;
        protected ContextMenuStrip contextMenuStrip2;
        protected SuperGridControl DGV_Main;
        protected bool ifOkDelete;
        protected IntegerInput integerInput1;
        protected LabelItem Label_Count;
        protected LabelItem labelItem1;
        protected LabelItem labelItem2;
        protected LabelItem labelItem3;
        protected IntegerInput Rep_RecCount;
        protected TextBoxItem TextBox_Index;
        protected TextBoxItem textBox_search;
        protected ToolStripMenuItem ToolStripMenuItem_Det;
        protected ToolStripMenuItem ToolStripMenuItem_Rep;
        public bool CanEdit = true;
        public Control codeControl = new Control();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
        public List<Control> controls;
        public DotNetBarManager dotNetBarManager1;
        public Softgroup.NetResize.NetResize netResize1;
        public ViewState ViewState = ViewState.Deiles;
        public FrmBankBranches()
        {
            InitializeComponent();this.Load += langloads;
            txtAddress.Click += Button_Edit_Click;
            txtAgeLimit.Click += Button_Edit_Click;
            txtBankComm.Click += Button_Edit_Click;
            txtArbDes.Click += Button_Edit_Click;
            txtPersonalName.Click += Button_Edit_Click;
            txtTaxNo.Click += Button_Edit_Click;
            txtZipCod.Click += Button_Edit_Click;
            txtRessonsStoped.Click += Button_Edit_Click;
            checkBoxX_Stoped.Click += Button_Edit_Click;
            txtBalance.Click += Button_Edit_Click;
            txtCity.Click += Button_Edit_Click;
            txtCredit.Click += Button_Edit_Click;
            txtCreditLimit.Click += Button_Edit_Click;
            txtEngDes.Click += Button_Edit_Click;
            txtDeb.Click += Button_Edit_Click;
            txtEMail.Click += Button_Edit_Click;
            txtFax.Click += Button_Edit_Click;
            txtMobile.Click += Button_Edit_Click;
            txtTele1.Click += Button_Edit_Click;
            txtTele2.Click += Button_Edit_Click;
            buttonX_SerchAccNo.TextChanged += Button_Edit_Click;
            CmbPrice.Click += Button_Edit_Click;
            DGV_Main.PrimaryGrid.CheckBoxes = false;
            DGV_Main.PrimaryGrid.ShowCheckBox = false;
            DGV_Main.PrimaryGrid.ShowTreeButton = false;
            DGV_Main.PrimaryGrid.ShowTreeButtons = false;
            DGV_Main.PrimaryGrid.ShowTreeLines = false;
            DGV_Main.PrimaryGrid.RowHeaderWidth = 25;
            expandableSplitter1.Click += expandableSplitter1_Click;
            DGV_Main.MouseDown += DGV_Main_MouseDown;
            DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
            DGV_Main.CellClick += DGV_Main_CellClick;
            ToolStripMenuItem_Det.Click += ToolStripMenuItem_Det_Click;
            Button_ExportTable2.Click += Button_ExportTable2_Click;
            DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
            textBox_search.InputTextChanged += TextBox_Search_InputTextChanged;
            textBox_search.ButtonCustomClick += TextBox_Search_ButtonCustomClick;
            TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
            DGV_Main.DataBindingComplete += DGV_Main_DataBindingComplete;
            Button_Close.Click += Button_Close_Click;
            Button_First.Click += Button_First_Click;
            Button_Prev.Click += Button_Prev_Click;
            Button_Next.Click += Button_Next_Click;
            Button_Last.Click += Button_Last_Click;
            Button_Add.Click += Button_Add_Click;
            Button_Search.Click += Button_Search_Click;
            Button_Delete.Click += Button_Delete_Click;
            Button_Save.Click += Button_Save_Click;
            TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
            buttonX_SerchAccNo.TextChanged += buttonX_SerchAccNo_Click;
            Button_PrintTable.Click += Button_Print_Click;
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
            {
                txtCreditLimit.DisplayFormat = VarGeneral.DicemalMask;
                txtDeb.DisplayFormat = VarGeneral.DicemalMask;
                txtCredit.DisplayFormat = VarGeneral.DicemalMask;
                txtBalance.DisplayFormat = VarGeneral.DicemalMask;
            }
        }
        private void ADD_Controls()
        {
            try
            {
                controls = new List<Control>();
                controls.Add(textBox_ID);
                controls.Add(txtAddress);
                controls.Add(txtAgeLimit);
                controls.Add(txtBankComm);
                controls.Add(txtArbDes);
                controls.Add(txtRessonsStoped);
                controls.Add(txtPersonalName);
                controls.Add(txtTaxNo);
                controls.Add(txtZipCod);
                controls.Add(checkBoxX_Stoped);
                controls.Add(txtBalance);
                controls.Add(txtCity);
                controls.Add(txtCredit);
                controls.Add(txtCreditLimit);
                controls.Add(txtDeb);
                controls.Add(txtEMail);
                controls.Add(txtEngDes);
                controls.Add(txtFax);
                controls.Add(txtMainAccNo);
                controls.Add(txtMainAccName);
                controls.Add(txtMobile);
                controls.Add(txtTele1);
                controls.Add(txtTele2);
                controls.Add(buttonX_SerchAccNo);
                controls.Add(CmbPrice);
            }
            catch (SqlException)
            {
            }
        }
        private void Button_Add_Click(object sender, EventArgs e)
        {
            if (!Button_Add.Visible || !Button_Add.Enabled)
            {
                MessageBox.Show(
                    (LangArEn == 0)
                        ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !"
                        : "Can not complete this process .. please see the powers of the users!",
                    VarGeneral.ProdectNam,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
            }
            else
            {
                if (State == FormState.Edit &&
                    MessageBox.Show(
                        (LangArEn == 0)
                            ? "تم تعديل السجل الحالي دون حفظ التغييرات .. هل تريد المتابعة؟"
                            : "Not saved the changes, do you really want to continue?",
                        VarGeneral.ProdectNam,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Exclamation) !=
                    DialogResult.Yes)
                {
                    return;
                }
                Clear();
                int id = db.MaxAccDefNo;
                textBox_ID.Tag = id.ToString();
                State = FormState.New;
                LockedFrm(Stat: false);
                try
                {
                    T_AccDef q = db.StockAccDefWithOutBalance("1031");
                    if (q != null && !string.IsNullOrEmpty(q.AccDef_No))
                    {
                        txtMainAccNo.Text = "1031";
                        txtMainAccName.Text = ((LangArEn == 0)
                            ? db.SelectAccRootByCode(txtMainAccNo.Text).Arb_Des
                            : db.SelectAccRootByCode(txtMainAccNo.Text).Eng_Des);
                    }
                }
                catch
                {
                    txtMainAccNo.Text = "";
                    txtMainAccName.Text = "";
                }
            }
        }
        private void Button_Close_Click(object sender, EventArgs e) { Close(); }
        private void Button_Delete_Click(object sender, EventArgs e)
        {
            if (!Button_Delete.Enabled || !Button_Delete.Visible || State != 0)
            {
                ifOkDelete = false;
                return;
            }
            string Code = "";
            Code = textBox_ID.Text;
            if (Code == "")
            {
                ifOkDelete = false;
                return;
            }
            if (MessageBox.Show(
                    "هل أنت متاكد من حذف السجل [" +
                        Code +
                        "]؟ \n Are you sure that you want to delete the record [" +
                        Code +
                        "]?",
                    VarGeneral.ProdectNam,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                ifOkDelete = true;
            }
            else
            {
                ifOkDelete = false;
            }
            if (data_this == null || string.IsNullOrEmpty(data_this.AccDef_No) || !ifOkDelete)
            {
                return;
            }
            T_GDDET returned = db.SelectAccDefNoByReturnNo(DataThis.AccDef_No);
            if ((returned != null && returned.GDDET_ID != 0) || textBox_ID.Text == "1")
            {
                MessageBox.Show(
                    (LangArEn == 0)
                        ? "لايمكن حذف العميل .. لانه مرتبط باحد القيود"
                        : "You can not delete Category .. because it is tied to a Gaid",
                    VarGeneral.ProdectNam,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
                return;
            }
            data_this = db.StockAccDefWithOutBalance(DataThis.AccDef_No);
            try
            {
                db.T_AccDefs.DeleteOnSubmit(DataThis);
                db.SubmitChanges();
            }
            catch (SqlException)
            {
                data_this = db.StockAccDefWithOutBalance(DataThis.AccDef_No);
                return;
            }
            catch (Exception)
            {
                data_this = db.StockAccDefWithOutBalance(DataThis.AccDef_No);
                return;
            }
            Clear();
            RefreshPKeys();
            textBox_ID.Text = PKeys.LastOrDefault();
        }
        private void Button_Edit_Click(object sender, EventArgs e)
        {
            if (CanEdit && State != FormState.Edit && State != FormState.New && !string.IsNullOrEmpty(textBox_ID.Text))
            {
                if (State != FormState.New)
                {
                    State = FormState.Edit;
                }
                LockedFrm(Stat: false);
                SetReadOnly = false;
            }
        }
        private void Button_ExportTable2_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcel.ExportToExcel(DGV_Main, "تقرير العملاء");
            }
            catch
            {
            }
        }
        private void Button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Button_Save.Enabled)
                {
                    return;
                }
                if (State == FormState.Edit && !CanEdit)
                {
                    MessageBox.Show(
                        (LangArEn == 0)
                            ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !"
                            : "Can not complete this process .. please see the powers of the users!",
                        VarGeneral.ProdectNam,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Hand);
                    return;
                }
                if (State == FormState.New && !Button_Add.Enabled)
                {
                    MessageBox.Show(
                        (LangArEn == 0)
                            ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !"
                            : "Can not complete this process .. please see the powers of the users!",
                        VarGeneral.ProdectNam,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Hand);
                    return;
                }
                textBox_ID.Focus();
                if (textBox_ID.Text == "")
                {
                    MessageBox.Show(
                        (LangArEn == 0)
                            ? "لايمكن ان يكون الرمز او الإسم فارغا\u0651"
                            : "Can not be a number or name is empty",
                        VarGeneral.ProdectNam,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Hand);
                    return;
                }
                GetData();
                if (State == FormState.New)
                {
                    try
                    {
                        data_this.Credit = 0.0;
                        data_this.Debit = 0.0;
                        data_this.Balance = 0.0;
                        data_this.StopedState = false;
                        db.T_AccDefs.InsertOnSubmit(data_this);
                        db.SubmitChanges();
                    }
                    catch (SqlException ex3)
                    {
                        if (ex3.Number != 2627)
                        {
                            return;
                        }
                        MessageBox.Show(
                            "الرقم مستخدم من قبل.\n سيتم الحفظ برقم جديد ",
                            VarGeneral.ProdectNam,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Hand);
                        int id = db.MaxAccDefNo;
                        textBox_ID.Tag = id.ToString();
                        Button_Save_Click(sender, e);
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
                else if (State == FormState.Edit)
                {
                    try
                    {
                        db.Log = VarGeneral.DebugLog;
                        db.SubmitChanges(ConflictMode.ContinueOnConflict);
                    }
                    catch (SqlException)
                    {
                        return;
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
                State = FormState.Saved;
                RefreshPKeys();
                TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(data_this.AccDef_No ?? "") + 1);
                SetReadOnly = true;
                LockedFrm(Stat: true);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void buttonX_CustomerStoped_Click(object sender, EventArgs e)
        {
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible
                    .Add(
                        kvp.Key,
                        new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_AccDef_CustomerStoped";
            VarGeneral.AccTyp = 3;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                textBox_ID.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
            }
        }
        private void buttonX_SerchAccNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible2.Add(
                "Eng_Des",
                new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
            columns_Names_visible2.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible
                    .Add(
                        kvp.Key,
                        new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "AccDefID_Customer";
            VarGeneral.AccTyp = 3;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtMainAccNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                txtMainAccName.Text = ((LangArEn == 0)
                    ? db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des
                    : db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des);
            }
            else
            {
                txtMainAccNo.Text = "";
                txtMainAccName.Text = "";
            }
        }
        private void checkBoxX_Stoped_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxX_Stoped.Checked)
            {
                txtRessonsStoped.Enabled = true;
                return;
            }
            txtRessonsStoped.Enabled = false;
            txtRessonsStoped.Text = "";
        }
        private void DGV_Main_CellClick(object sender, GridCellClickEventArgs e)
        { DGV_Main.PrimaryGrid.Tag = e.GridCell.RowIndex; }
        private void DGV_Main_CellDoubleClick(object sender, GridCellDoubleClickEventArgs e)
        { ToolStripMenuItem_Det_Click(sender, e); }
        private void DGV_Main_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            string dataMember = panel.DataMember;
            if (dataMember != null && dataMember == "T_AccDef")
            {
                PropBranchPanel(panel);
            }
        }
        private void DGV_Main_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                GridElement item = DGV_Main.GetElementAt(e.Location);
                if (item is GridColumnHeader)
                {
                    GridColumnHeader gch = (GridColumnHeader)item;
                    GridColumn column = null;
                    HeaderArea area = gch.GetHitArea(e.Location, ref column);
                    contextMenuStrip1.Show(Control.MousePosition);
                }
                else
                {
                    contextMenuStrip2.Show(Control.MousePosition);
                }
            }
        }
        private void expandableSplitter1_Click(object sender, EventArgs e)
        {
            if (expandableSplitter1.Expanded)
            {
                ViewTable_Click(sender, e);
            }
            else
            {
                ViewDetails_Click(sender, e);
            }
        }
        private void FillCombo()
        {
            int _CmbIndex = CmbPrice.SelectedIndex;
            CmbPrice.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                CmbPrice.Items.Add("الافتراضي");
                CmbPrice.Items.Add("سعر الجملة");
                CmbPrice.Items.Add("سعر الموزع");
                CmbPrice.Items.Add("سعر المندوب");
                CmbPrice.Items.Add("سعر التجزئة");
                CmbPrice.Items.Add("سعر آخر");
            }
            else
            {
                CmbPrice.Items.Add("Defualt");
                CmbPrice.Items.Add("Wholesale price");
                CmbPrice.Items.Add("Distributor price");
                CmbPrice.Items.Add("Legates Price");
                CmbPrice.Items.Add("Retail price");
                CmbPrice.Items.Add("another Price");
            }
            CmbPrice.SelectedIndex = _CmbIndex;
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && Button_Add.Enabled && Button_Add.Visible)
            {
                Button_Add_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F2 && Button_Save.Enabled && Button_Save.Visible && State != 0)
            {
                Button_Save_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F3 && Button_Delete.Enabled && Button_Delete.Visible && State == FormState.Saved)
            {
                Button_Delete_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F4 && Button_Search.Enabled && Button_Search.Visible)
            {
                Button_Search_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F5 &&
              Button_PrintTable.Enabled &&
              Button_PrintTable.Visible &&
              !expandableSplitter1.Expanded)
            {
                Button_Print_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F10 &&
              Button_ExportTable2.Enabled &&
              Button_ExportTable2.Visible &&
              !expandableSplitter1.Expanded)
            {
                Button_ExportTable2_Click(sender, e);
            }
            else
            {
                if (e.KeyCode != Keys.Escape)
                {
                    return;
                }
                if (State == FormState.Saved)
                {
                    Close();
                    return;
                }
                if (State != FormState.New)
                {
                    textBox_ID_TextChanged(sender, e);
                    return;
                }
                try
                {
                    if (int.Parse(Label_Count.Text) > 0)
                    {
                        Button_Last_Click(sender, e);
                    }
                    else
                    {
                        Close();
                    }
                }
                catch
                {
                    Close();
                }
            }
        }
        private void Frm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void FrmBankBranches_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmBankBranches));
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    SSSLanguage.Language.ChangeLanguage("ar-SA", this, resources);
                    LangArEn = 0;
                }
                else
                {
                    SSSLanguage.Language.ChangeLanguage("en", this, resources);
                    LangArEn = 1;
                }
                ADD_Controls();
                LockedFrm(Stat: true);
                Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
                if (columns_Names_visible.Count == 0)
                {
                    columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
                    columns_Names_visible.Add(
                        "Arb_Des",
                        new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
                    columns_Names_visible.Add(
                        "Eng_Des",
                        new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
                    columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
                }
                else
                {
                    Clear();
                    textBox_ID.Text = "";
                    TextBox_Index.TextBox.Text = "";
                }
                RefreshPKeys();
                FillCombo();
                RibunButtons();
                textBox_ID.Text = PKeys.FirstOrDefault();
                ViewDetails_Click(sender, e);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void FrmInvSale_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;
        }
        private void FrmInvSale_SizeChanged(object sender, EventArgs e) { netResize1.Refresh(); }
        private T_AccDef GetData()
        {
            textBox_ID.Focus();
            data_this.Arb_Des = txtArbDes.Text;
            data_this.PersonalNm = txtPersonalName.Text;
            data_this.TaxNo = txtTaxNo.Text;
            try
            {
                if (State == FormState.New)
                {
                    if (data_this.DepreciationPercent.HasValue)
                    {
                        data_this.DepreciationPercent = data_this.DepreciationPercent.Value;
                    }
                    else
                    {
                        data_this.DepreciationPercent = 0.0;
                    }
                    if (data_this.MaxDisCust.HasValue)
                    {
                        data_this.MaxDisCust = data_this.MaxDisCust.Value;
                    }
                    else
                    {
                        data_this.MaxDisCust = 0.0;
                    }
                    if (data_this.vColNum1.HasValue)
                    {
                        data_this.vColNum1 = data_this.vColNum1.Value;
                    }
                    else
                    {
                        data_this.vColNum1 = 0.0;
                    }
                    if (data_this.vColNum2.HasValue)
                    {
                        data_this.vColNum2 = data_this.vColNum2.Value;
                    }
                    else
                    {
                        data_this.vColNum2 = 0.0;
                    }
                    if (!string.IsNullOrEmpty(data_this.vColStr1))
                    {
                        data_this.vColStr1 = data_this.vColStr1;
                    }
                    else
                    {
                        data_this.vColStr1 = "";
                    }
                    if (!string.IsNullOrEmpty(data_this.vColStr2))
                    {
                        data_this.vColStr2 = data_this.vColStr2;
                    }
                    else
                    {
                        data_this.vColStr2 = "";
                    }
                    if (!string.IsNullOrEmpty(data_this.vColStr3))
                    {
                        data_this.vColStr3 = data_this.vColStr3;
                    }
                    else
                    {
                        data_this.vColStr3 = "";
                    }
                }
            }
            catch
            {
            }
            data_this.zipCod = txtZipCod.Text;
            data_this.RessonStoped = txtRessonsStoped.Text;
            data_this.StopedState = checkBoxX_Stoped.Checked;
            data_this.Eng_Des = txtEngDes.Text;
            data_this.AccDef_No = textBox_ID.Text;
            data_this.Lev = 4;
            data_this.ParAcc = txtMainAccNo.Text;
            data_this.AccCat = 3;
            if (State == FormState.New)
            {
                data_this.DC = 0;
                data_this.Trn = 3;
            }
            data_this.Sts = 0;
            if (double.TryParse(txtCreditLimit.Text, out var value))
            {
                data_this.MaxLemt = value;
            }
            else
            {
                data_this.MaxLemt = 0.0;
            }
            data_this.Typ = "";
            data_this.City = txtCity.Text ?? "";
            data_this.Email = txtEMail.Text ?? "";
            data_this.Telphone1 = txtTele1.Text ?? "";
            data_this.Telphone2 = txtTele2.Text ?? "";
            data_this.Fax = txtFax.Text ?? "";
            data_this.Mobile = txtMobile.Text ?? "";
            data_this.DesPers = "";
            data_this.StrAm = int.Parse(txtAgeLimit.Text);
            data_this.BankComm = txtBankComm.Value;
            data_this.Adders = txtAddress.Text ?? "";
            data_this.Mnd = null;
            data_this.Price = CmbPrice.SelectedIndex;
            data_this.CompanyID = 1;
            return data_this;
        }
        private void item_Click(object sender, EventArgs e)
        {
            string name = (sender as ToolStripMenuItem).Name;
            try
            {
                string NameExsist = DGV_Main.PrimaryGrid.Columns[name].Name;
            }
            catch
            {
                DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(name));
                DGV_Main.PrimaryGrid.Columns[name].AutoSizeMode = ColumnAutoSizeMode.None;
                DGV_Main.PrimaryGrid.Columns[name].MinimumWidth = 90;
                DGV_Main.PrimaryGrid.Columns[name].HeaderText = columns_Names_visible[name].AText;
            }
            DGV_Main.PrimaryGrid.Columns[name].Visible = (sender as ToolStripMenuItem).Checked;
        }
        private void LockedFrm(bool Stat)
        {
            if (State == FormState.New)
            {
                textBox_ID.ReadOnly = true;
                txtMainAccNo.ReadOnly = true;
                buttonX_SerchAccNo.Enabled = true;
            }
            else
            {
                textBox_ID.ReadOnly = true;
                txtMainAccNo.ReadOnly = true;
                buttonX_SerchAccNo.Enabled = false;
            }
        }
        private void netResize1_AfterControlResize(object sender, Softgroup.NetResize.AfterControlResizeEventArgs e)
        {
            if (e.Control.Name.Contains("ribbonBar_Tasks"))
            {
                ribbonBar_Tasks.Font = new Font("Tahoma", 8F);
                ribbonBar1.BackgroundStyle.BackColor = Color.Gainsboro;
                ribbonBar1.BackgroundStyle.BackColor2 = Color.Gainsboro;
            }
            if (e.Control.GetType() == typeof(Label))
            {
                Label c = (e.Control as Label);
                if ((c.BackColor !=
                        System.Drawing.Color
                            .FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))))) &&
                    (c.BackColor !=
                        System.Drawing.Color
                            .FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))))) &&
                    (c.BackColor != System.Drawing.Color.SteelBlue))
                    c.BackColor = Color.Transparent;
                Size cc = c.PreferredSize;
                c.AutoSize = false;
                c.Size = cc;
                //  e.Control.Font= new System.Drawing.Font("Tahoma",(float) (c-0.5));
            }
        }
        private void PropBranchPanel(GridPanel panel)
        {
            DGV_Main.PrimaryGrid.UseAlternateRowStyle = true;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background.Color1 = Color.SkyBlue;
            panel.FrozenColumnCount = 1;
            panel.Columns[0].GroupBoxEffects = GroupBoxEffects.None;
            foreach (GridColumn column in panel.Columns)
            {
                column.ColumnSortMode = ColumnSortMode.Multiple;
            }
            panel.ColumnHeader.RowHeight = 30;
            for (int i = 0; i < panel.Columns.Count; i++)
            {
                DGV_Main.PrimaryGrid.Columns[i].CellStyles.Default.Alignment = Alignment.MiddleCenter;
                DGV_Main.PrimaryGrid.Columns[i].Visible = false;
            }
            panel.Columns["AccDef_No"].Width = 120;
            panel.Columns["AccDef_No"].Visible = columns_Names_visible["AccDef_No"].IfDefault;
            panel.Columns["Arb_Des"].Width = 180;
            panel.Columns["Arb_Des"].Visible = columns_Names_visible["Arb_Des"].IfDefault;
            panel.Columns["Eng_Des"].Width = 180;
            panel.Columns["Eng_Des"].Visible = columns_Names_visible["Eng_Des"].IfDefault;
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Button_First.Text = "الأول";
                Button_Last.Text = "الأخير";
                Button_Next.Text = "التالي";
                Button_Prev.Text = "السابق";
                Button_Add.Text = "جديد";
                Button_Close.Text = "اغلاق";
                Button_Delete.Text = "حذف";
                Button_Save.Text = "حفظ";
                Button_Search.Text = "بحث";
                Button_First.Tooltip = "السجل الاول";
                Button_Last.Tooltip = "السجل الاخير";
                Button_Next.Tooltip = "السجل التالي";
                Button_Prev.Tooltip = "السجل السابق";
                Button_Add.Tooltip = "F1";
                Button_Close.Tooltip = "Esc";
                Button_Delete.Tooltip = "F3";
                Button_Save.Tooltip = "F2";
                Button_Search.Tooltip = "F4";
                Button_PrintTable.Text = ((VarGeneral.GeneralPrinter.ISdirectPrinting)
                    ? "طباعة"
                    : "عــرض");
                Button_PrintTable.Tooltip = "F5";
                Button_ExportTable2.Text = "تصدير";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "جميع السجلات";
                label4.Text = "حساب الفرع :";
                label3.Text = "البنك الرئيسي :";
                label1.Text = "الإسم - عربي :";
                label2.Text = "الإسم - إنجليزي :";
                label19.Text = "إسم المسؤول :";
                label16.Text = "حد المديونية :";
                label10.Text = "عمر الدين :";
                label18.Text = "السعر الإفتراضي :";
                label17.Text = "مدين :";
                label14.Text = "دائن :";
                label15.Text = "الرصيد الحالي :";
                label6.Text = "العنوان :";
                label8.Text = "البلد :";
                label9.Text = "الهاتف :";
                label12.Text = "الفاكس :";
                label13.Text = "الجوال :";
                label11.Text = "ص . ب :";
                label20.Text = "الرمز البريدي :";
                label7.Text = "الإيميل :";
                Text = "كــرت فروع البنوك المصرفية";
                checkBoxX_Stoped.Text = "إيقاف الفــرع";
                buttonX_CustomerStoped.Text = "الفروع الموقوفة";
                label5.Text = "الســـبب :";
            }
            else
            {
                Button_First.Text = "First";
                Button_Last.Text = "Last";
                Button_Next.Text = "Next";
                Button_Prev.Text = "Previous";
                Button_Add.Text = "New";
                Button_Close.Text = "Close";
                Button_Delete.Text = "Delete";
                Button_Save.Text = "Save";
                Button_Search.Text = "Search";
                Button_First.Tooltip = "First Record";
                Button_Last.Tooltip = "Last Record";
                Button_Next.Tooltip = "Next Record";
                Button_Prev.Tooltip = "Previous Record";
                Button_Add.Tooltip = "F1";
                Button_Close.Tooltip = "Esc";
                Button_Delete.Tooltip = "F3";
                Button_Save.Tooltip = "F2";
                Button_Search.Tooltip = "F4";
                Button_PrintTable.Text = ((VarGeneral.GeneralPrinter.ISdirectPrinting)
                    ? "Print"
                    : "Show");
                Button_PrintTable.Tooltip = "F5";
                Button_ExportTable2.Text = "Export";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "All Records";
                label4.Text = "Branch Acc :";
                label3.Text = "Bank Main :";
                label1.Text = "Name - Arabic :";
                label2.Text = "Name - English :";
                label19.Text = "The official name :";
                label16.Text = "Debt limit :";
                label10.Text = "Life of the loan :";
                label18.Text = "Price Default :";
                label17.Text = "Debtor :";
                label14.Text = "Creditor :";
                label15.Text = "Balance :";
                label6.Text = "Address :";
                label8.Text = "Country :";
                label9.Text = "Tel :";
                label12.Text = "Fax :";
                label13.Text = "Mobile :";
                label11.Text = "PO Box :";
                label20.Text = "Postal Code :";
                label7.Text = "Email :";
                Text = "Branches of Banks Card";
                checkBoxX_Stoped.Text = "Branche Stoped";
                buttonX_CustomerStoped.Text = "Branches Stoped";
                label5.Text = "The reason :";
            }
        }
        private void superTabControl_Main1_RightToLeftChanged(object sender, EventArgs e)
        {
            superTabControl_Main1.RightToLeftChanged -= superTabControl_Main1_RightToLeftChanged;
            superTabControl_Main1.RightToLeft = RightToLeft.No;
            superTabControl_Main1.RightToLeftChanged -= superTabControl_Main1_RightToLeftChanged;
        }
        private void textBox_ID_Click(object sender, EventArgs e) { textBox_ID.SelectAll(); }
        private void textBox_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void textBox_ID_Leave(object sender, EventArgs e)
        {
            if (textBox_ID.Text != "" && State == FormState.New)
            {
                List<T_AccDef> q = (from t in db.T_AccDefs
                                    where t.AccDef_No == textBox_ID.Text
                                    orderby t.AccDef_No descending
                                    select t).ToList();
                if (q.Count != 0)
                {
                    MessageBox.Show(
                        (LangArEn == 0)
                            ? "الرقم الذي قمت بإدخاله موجود من قبل - مكرر .. يرجى المحاولة مرة اخرى"
                            : "The number you have entered already exists - bis .. Please try again.",
                        VarGeneral.ProdectNam,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Hand);
                    textBox_ID.Text = "";
                    textBox_ID.Focus();
                }
            }
        }
        private void textBox_ID_TextChanged(object sender, EventArgs e)
        {
            int no = 0;
            try
            {
                no = int.Parse(textBox_ID.Text);
            }
            catch
            {
            }
            try
            {
                T_AccDef newData = db.StockAccDef(no.ToString());
                if (newData == null || string.IsNullOrEmpty(newData.AccDef_No))
                {
                    if (!Button_Add.Visible || !Button_Add.Enabled)
                    {
                        MessageBox.Show(
                            (LangArEn == 0)
                                ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !"
                                : "Can not complete this process .. please see the powers of the users!",
                            VarGeneral.ProdectNam,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Hand);
                        textBox_ID.TextChanged -= textBox_ID_TextChanged;
                        try
                        {
                            textBox_ID.Text = data_this.AccDef_No;
                        }
                        catch
                        {
                        }
                        textBox_ID.TextChanged += textBox_ID_TextChanged;
                        return;
                    }
                    Clear();
                    TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                    TextBox_Index.TextBox.Text = string.Concat(PKeys.Count + 1);
                    TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                }
                else
                {
                    DataThis = newData;
                    int indexA = PKeys.IndexOf(newData.AccDef_No ?? "");
                    indexA++;
                    TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                    TextBox_Index.TextBox.Text = string.Concat(indexA);
                    TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            UpdateVcr();
        }
        private void TextBox_Index_InputTextChanged(object sender)
        {
            int index = 0;
            try
            {
                index = Convert.ToInt32(TextBox_Index.TextBox.Text);
            }
            catch
            {
            }
            if (index <= PKeys.Count && index > 0)
            {
                textBox_ID.Text = PKeys[index - 1];
            }
        }
        private void TextBox_Search_ButtonCustomClick(object sender, EventArgs e) { textBox_search.Text = ""; }
        private void TextBox_Search_InputTextChanged(object sender) { Fill_DGV_Main(); }
        private void ToolStripMenuItem_Det_Click(object sender, EventArgs e)
        {
            int rowIndex = Convert.ToInt32(DGV_Main.PrimaryGrid.Tag);
            TextBox_Index.TextBox.Text = string.Concat(rowIndex + 1);
            expandableSplitter1.Expanded = true;
            ViewDetails_Click(sender, e);
        }
        private void txtArbDes_Enter(object sender, EventArgs e) { Framework.Keyboard.Language.Switch("Arabic"); }
        private void txtEngDes_Enter(object sender, EventArgs e) { Framework.Keyboard.Language.Switch("English"); }
        private void txtFax_Click(object sender, EventArgs e) { txtFax.SelectAll(); }
        private void txtMainAccNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox_ID.TextChanged -= textBox_ID_TextChanged;
                if (State == FormState.New && !string.IsNullOrEmpty(txtMainAccNo.Text))
                {
                    int Value = 0;
                    List<T_AccDef> q = (from t in db.T_AccDefs
                                        where t.ParAcc == txtMainAccNo.Text
                                        orderby t.AccDef_ID
                                        select t).ToList();
                    if (q.Count == 0)
                    {
                        textBox_ID.Text = txtMainAccNo.Text + "001";
                        txtArbDes.Focus();
                    }
                    else
                    {
                        _AccDefBind = q[q.Count - 1];
                        string _Zero = "";
                        for (int iiCnt = 0; iiCnt < _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Length &&
                            _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Substring(iiCnt, 1) == "0"; iiCnt++)
                        {
                            _Zero += _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Substring(iiCnt, 1);
                        }
                        Value = int.Parse(_AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length)) + 1;
                        if (!string.IsNullOrEmpty(_Zero))
                        {
                            textBox_ID.Text = _AccDefBind.ParAcc + _Zero + Value;
                        }
                        else
                        {
                            textBox_ID.Text = _AccDefBind.ParAcc + Value;
                        }
                        txtArbDes.Focus();
                    }
                }
                textBox_ID.TextChanged += textBox_ID_TextChanged;
            }
            catch
            {
                txtMainAccNo.Text = "";
                txtMainAccName.Text = "";
                textBox_ID.TextChanged += textBox_ID_TextChanged;
            }
        }
        private void txtMobile_Click(object sender, EventArgs e) { txtMobile.SelectAll(); }
        private void txtTele1_Click(object sender, EventArgs e) { txtTele1.SelectAll(); }
        private void txtTele1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b')) && e.KeyChar != '-' && e.KeyChar != '\\')
            {
                e.Handled = true;
            }
        }
        private void UpdateVcr()
        {
            int vCount = 0;
            int vPosition = 0;
            try
            {
                vCount = int.Parse(Label_Count.Text);
            }
            catch
            {
                vCount = 0;
            }
            try
            {
                vPosition = int.Parse(TextBox_Index.Text);
            }
            catch
            {
                vPosition = 0;
            }
            if (vCount <= 1)
            {
                Button_First.Enabled = false;
                Button_Prev.Enabled = false;
                Button_Next.Enabled = false;
                Button_Last.Enabled = false;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    lable_Records.Text = ((vCount == 0) ? "لايوجد سجلات" : "سجل واحد فقط");
                }
                else
                {
                    lable_Records.Text = ((vCount == 0) ? "No records" : "Only Record");
                }
                return;
            }
            if (vPosition == 1)
            {
                ButtonItem button_First = Button_First;
                bool enabled = (Button_Prev.Enabled = false);
                button_First.Enabled = enabled;
                ButtonItem button_Last = Button_Last;
                enabled = (Button_Next.Enabled = vCount > 1);
                button_Last.Enabled = enabled;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    lable_Records.Text = "الأول من " + vCount + " سجلات";
                }
                else
                {
                    lable_Records.Text = "First of " + vCount + " records";
                }
                return;
            }
            if (vPosition == vCount)
            {
                Button_Last.Enabled = false;
                Button_Next.Enabled = false;
                ButtonItem button_First2 = Button_First;
                bool enabled = (Button_Prev.Enabled = vCount > 1);
                button_First2.Enabled = enabled;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    lable_Records.Text = "الأخير من " + vCount + " سجلات";
                }
                else
                {
                    lable_Records.Text = "Last of " + vCount + " records";
                }
                return;
            }
            Button_First.Enabled = true;
            Button_Prev.Enabled = true;
            Button_Next.Enabled = true;
            Button_Last.Enabled = true;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                lable_Records.Text = "السجل " + vPosition + " من " + vCount;
            }
            else
            {
                lable_Records.Text = "Record " + vPosition + " of " + vCount;
            }
        }
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
        protected bool ContinueIfEditOrNew()
        {
            if (State == FormState.Edit || State == FormState.New)
            {
                if (MessageBox.Show(
                        (LangArEn == 0)
                            ? "تم تعديل السجل الحالي دون حفظ التغييرات .. هل تريد المتابعة؟"
                            : "Not saved the changes, do you really want to continue?",
                        VarGeneral.ProdectNam,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Exclamation) !=
                    DialogResult.Yes)
                {
                    return false;
                }
                return true;
            }
            return true;
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmBankBranches));
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                SSSLanguage.Language.ChangeLanguage("ar-SA", this, resources);
                LangArEn = 0;
            }
            else
            {
                SSSLanguage.Language.ChangeLanguage("en", this, resources);
                LangArEn = 1;
            }
            RibunButtons();
            FillCombo();
            try
            {
                if (data_this != null)
                {
                    SetData(data_this);
                }
            }
            catch
            {
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData.ToString().Contains("Control") &&
                !keyData.ToString().ToLower().Contains("delete") &&
                keyData.ToString().Contains("Alt"))
            {
                try
                {
                    VarGeneral.Print_set_Gen_Stat = true;
                    FrmReportsViewer.IsSettingOnly = true;
                    VarGeneral.IsGeneralUsed = true;
                    {
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "RepGeneral";
                        frm.Repvalue = "RepGeneral";
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
        protected bool CanUpdate { get { return canUpdate; } set { canUpdate = value; } }
        public void Button_First_Click(object sender, EventArgs e)
        {
            if (ContinueIfEditOrNew())
            {
                TextBox_Index.TextBox.Text = string.Concat(1);
                UpdateVcr();
                textBox_ID.Focus();
            }
        }
        public void Button_Last_Click(object sender, EventArgs e)
        {
            if (ContinueIfEditOrNew())
            {
                TextBox_Index.TextBox.Text = Label_Count.Text;
                UpdateVcr();
            }
        }
        public void Button_Next_Click(object sender, EventArgs e)
        {
            if (ContinueIfEditOrNew())
            {
                int index = 0;
                int count = 0;
                try
                {
                    index = Convert.ToInt32(TextBox_Index.TextBox.Text);
                }
                catch
                {
                }
                try
                {
                    count = Convert.ToInt32(Label_Count.Text);
                }
                catch
                {
                }
                if (index < count)
                {
                    TextBox_Index.TextBox.Text = string.Concat(index + 1);
                }
                UpdateVcr();
                textBox_ID.Focus();
            }
        }
        public void Button_Prev_Click(object sender, EventArgs e)
        {
            if (ContinueIfEditOrNew())
            {
                int index = 0;
                try
                {
                    index = Convert.ToInt32(TextBox_Index.TextBox.Text);
                }
                catch
                {
                }
                if (index > 1)
                {
                    TextBox_Index.TextBox.Text = string.Concat(index - 1);
                }
                UpdateVcr();
                textBox_ID.Focus();
            }
        }
        public void Button_Print_Click(object sender, EventArgs e)
        {
            if (ViewState != 0)
            {
                return;
            }
            try
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_AccDef left join T_SYSSETTING on T_SYSSETTING.SYSSETTING_ID = T_AccDef.CompanyID ";
                string Fields = "";
                Fields = " T_AccDef.AccDef_ID , T_AccDef.AccDef_No as No , T_AccDef.Arb_Des as NmA, T_AccDef.Eng_Des as NmE,T_SYSSETTING.LogImg ";
                _RepShow.Rule = " Where 1 = 1 and T_AccDef.AccCat = '3' and T_AccDef.Lev = 4 ";
                if (!string.IsNullOrEmpty(Fields))
                {
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
                        MessageBox.Show(
                            (LangArEn == 0)
                                ? "عفوا .. لا يوجد بيانات لعرضها في التقرير "
                                : "Sorry .. there is no data to display in the report ",
                            VarGeneral.ProdectNam,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk);
                        return;
                    }
                    try
                    {
                        VarGeneral.IsGeneralUsed = true;
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "RepGeneral";
                        frm.Tag = LangArEn;
                        frm.Repvalue = "RepGeneral";
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
                else
                {
                    MessageBox.Show(
                        (LangArEn == 0) ? " يجب تحديد حقل واحد على الأقل للطباعة" : "You must select one field or more",
                        VarGeneral.ProdectNam,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Hand);
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }
        public void Button_Search_Click(object sender, EventArgs e)
        {
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible
                    .Add(
                        kvp.Key,
                        new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_AccDef_Suppliers";
            VarGeneral.AccTyp = 3;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                textBox_ID.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
            }
        }
        public void Clear()
        {
            if (State == FormState.New)
            {
                return;
            }
            State = FormState.New;
            data_this = new T_AccDef();
            State = FormState.New;
            for (int i = 0; i < controls.Count; i++)
            {
                if (controls[i].GetType() == typeof(DateTimePicker))
                {
                    int? calendr = VarGeneral.Settings_Sys.Calendr;
                    if (calendr.Value == 0 && calendr.HasValue)
                    {
                        (controls[i] as DateTimePicker).Value = Convert.ToDateTime(n.GDateNow());
                    }
                    else
                    {
                        (controls[i] as DateTimePicker).Text = n.HDateNow();
                    }
                }
                else if (controls[i].GetType() == typeof(CheckBox))
                {
                    (controls[i] as CheckBox).Checked = false;
                }
                else if (controls[i].GetType() == typeof(PictureBox))
                {
                    (controls[i] as PictureBox).Image = null;
                }
                else if (!(controls[i].Name == codeControl.Name))
                {
                    if (controls[i].GetType() == typeof(DoubleInput))
                    {
                        (controls[i] as DoubleInput).Value = 0.0;
                    }
                    else if (controls[i].GetType() == typeof(IntegerInput))
                    {
                        (controls[i] as IntegerInput).Value = 0;
                    }
                    else if (controls[i].GetType() == typeof(TextBox) ||
                      controls[i].GetType() == typeof(TextBoxX) ||
                      controls[i].GetType() == typeof(MaskedTextBox))
                    {
                        controls[i].Text = "";
                    }
                    else if (controls[i].GetType() == typeof(CheckBox))
                    {
                        (controls[i] as CheckBox).Checked = false;
                    }
                    else if (controls[i].GetType() == typeof(RadioButton))
                    {
                        (controls[i] as RadioButton).Checked = false;
                    }
                    else if (controls[i].GetType() == typeof(ComboBox))
                    {
                        (controls[i] as ComboBox).SelectedIndex = -1;
                    }
                }
            }
            textBox_ID.Focus();
            SetReadOnly = false;
        }
        public void Fill_DGV_Main()
        {
            DGV_Main.PrimaryGrid.VirtualMode = false;
            List<T_AccDef> list = db.FillAccDef_2(textBox_search.TextBox.Text, 4, 3).ToList();
            if (list.Count() > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].Debit = list[i].T_GDDETs
                        .Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.gdValue > 0.0)
                        .Sum((T_GDDET g) => g.gdValue.Value);
                    list[i].Credit = Math.Abs(
                        list[i].T_GDDETs
                            .Where((T_GDDET g) => !g.T_GDHEAD.gdLok && g.gdValue < 0.0)
                            .Sum((T_GDDET g) => g.gdValue.Value));
                    list[i].Balance = list[i].T_GDDETs
                        .Where((T_GDDET g) => !g.T_GDHEAD.gdLok)
                        .Sum((T_GDDET g) => g.gdValue.Value);
                }
            }
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
        }
        public void FillHDGV(IEnumerable<T_AccDef> new_data_enum)
        {
            bool contextMenuSet = false;
            if (contextMenuStrip1.Items.Count > 0)
            {
                contextMenuSet = true;
            }
            for (int i = 0; i < DGV_Main.PrimaryGrid.Columns.Count; i++)
            {
                if (columns_Names_visible.ContainsKey(DGV_Main.PrimaryGrid.Columns[i].Name))
                {
                    DGV_Main.PrimaryGrid.Columns[i].AutoSizeMode = ColumnAutoSizeMode.None;
                    DGV_Main.PrimaryGrid.Columns[i].MinimumWidth = 50;
                    DGV_Main.PrimaryGrid.Columns[i].Visible = columns_Names_visible[
                        DGV_Main.PrimaryGrid.Columns[i].Name].IfDefault;
                    DGV_Main.PrimaryGrid.Columns[i].HeaderText = ((LangArEn == 0)
                        ? columns_Names_visible[DGV_Main.PrimaryGrid.Columns[i].Name].AText
                        : columns_Names_visible[DGV_Main.PrimaryGrid.Columns[i].Name].EText);
                    if (!contextMenuSet)
                    {
                        ToolStripMenuItem item = new ToolStripMenuItem();
                        item.Checked = columns_Names_visible[DGV_Main.PrimaryGrid.Columns[i].Name].IfDefault;
                        item.CheckOnClick = true;
                        item.Name = DGV_Main.PrimaryGrid.Columns[i].Name;
                        item.Text = DGV_Main.PrimaryGrid.Columns[i].HeaderText;
                        item.CheckedChanged += item_Click;
                        contextMenuStrip1.Items.Add(item);
                    }
                    else
                    {
                        DGV_Main.PrimaryGrid.Columns[i].Visible = (contextMenuStrip1.Items[
                            DGV_Main.PrimaryGrid.Columns[i].Name] as ToolStripMenuItem).Checked;
                    }
                }
                else
                {
                    DGV_Main.PrimaryGrid.Columns[i].Visible = false;
                }
            }
            DGV_Main.PrimaryGrid.DataSource = new_data_enum.ToList();
            DGV_Main.PrimaryGrid.DataMember = "T_AccDef";
            DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background.Color2 = Color.LightBlue;
        }
        public void RefreshPKeys()
        {
            PKeys.Clear();
            var qkeys = from item in db.T_AccDefs
                        where item.Lev == (int?)4 && item.AccCat == (int?)3
                        orderby item.AccDef_No
                        select new { Code = item.AccDef_No + "" };
            int count = 0;
            foreach (var item2 in qkeys)
            {
                count++;
                PKeys.Add(item2.Code);
            }
            Label_Count.Text = string.Concat(count);
            UpdateVcr();
        }
        public void SetData(T_AccDef value)
        {
            try
            {
                State = FormState.Saved;
                Button_Save.Enabled = false;
                textBox_ID.Tag = value.AccDef_ID.ToString();
                txtEngDes.Text = value.Eng_Des;
                txtArbDes.Text = value.Arb_Des;
                txtRessonsStoped.Text = value.RessonStoped;
                txtPersonalName.Text = value.PersonalNm;
                txtTaxNo.Text = value.TaxNo;
                txtZipCod.Text = value.zipCod;
                try
                {
                    checkBoxX_Stoped.Checked = value.StopedState.Value;
                }
                catch
                {
                    checkBoxX_Stoped.Checked = false;
                }
                txtMainAccNo.Text = value.ParAcc;
                txtMainAccName.Text = ((LangArEn == 0)
                    ? db.StockAccDefWithOutBalance(value.ParAcc).Arb_Des
                    : db.StockAccDefWithOutBalance(value.ParAcc).Eng_Des);
                txtBalance.Value = (value.Balance.HasValue ? value.Balance.Value : 0.0);
                txtCredit.Value = (value.Credit.HasValue ? value.Credit.Value : 0.0);
                txtDeb.Value = (value.Debit.HasValue ? value.Debit.Value : 0.0);
                if (value.Price.HasValue)
                {
                    CmbPrice.SelectedIndex = value.Price.Value;
                }
                else
                {
                    CmbPrice.SelectedIndex = 0;
                }
                txtCreditLimit.Text = value.MaxLemt.ToString();
                txtCity.Text = value.City ?? "";
                txtEMail.Text = value.Email ?? "";
                txtTele1.Text = value.Telphone1 ?? "";
                txtTele2.Text = value.Telphone2 ?? "";
                txtFax.Text = value.Fax ?? "";
                txtMobile.Text = value.Mobile ?? "";
                txtAgeLimit.Text = value.StrAm.ToString();
                txtBankComm.Value = value.BankComm.Value;
                txtAddress.Text = value.Adders ?? "";
                checkBoxX_Stoped_CheckedChanged(null, null);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SetData:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        public void ViewDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(Label_Count.Text ?? "") <= 0 || (Label_Count.Text ?? "") == "")
                {
                    expandableSplitter1.Expandable = false;
                    return;
                }
                expandableSplitter1.Expandable = true;
                DGV_Main.PrimaryGrid.DataSource = null;
                DGV_Main.PrimaryGrid.VirtualMode = false;
                ViewState = ViewState.Deiles;
            }
            catch
            {
            }
        }
        public void ViewTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(Label_Count.Text ?? "") <= 0 || (Label_Count.Text ?? "") == "")
                {
                    expandableSplitter1.Expandable = false;
                    return;
                }
                expandableSplitter1.Expandable = true;
                ViewState = ViewState.Table;
            }
            catch
            {
            }
            Fill_DGV_Main();
            int index = -1;
            try
            {
                index = Convert.ToInt32(TextBox_Index.TextBox.Text);
            }
            catch
            {
                index = -1;
            }
            index--;
            if (index < DGV_Main.PrimaryGrid.Rows.Count && index >= 0)
            {
                DGV_Main.PrimaryGrid.Rows[index].EnsureVisible();
            }
        }
        public T_AccDef DataThis
        {
            get { return data_this; }
            set
            {
                data_this = value;
                SetData(data_this);
            }
        }
        public bool IfAdd { set { Button_Add.Visible = value; } }
        public bool IfDelete
        {
            set
            {
                Button_Delete.Visible = value;
                superTabControl_Main1.Refresh();
            }
        }
        public bool IfSave { set { Button_Save.Visible = value; } }
        public T_User Permmission
        {
            get { return permission; }
            set
            {
                if (value != null && value.UsrNo != "")
                {
                    permission = value;
                    if (!VarGeneral.TString.ChkStatShow(value.SndStr, 25))
                    {
                        IfAdd = false;
                    }
                    else
                    {
                        IfAdd = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.SndStr, 26))
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.SndStr, 27))
                    {
                        IfDelete = false;
                    }
                    else
                    {
                        IfDelete = true;
                    }
                }
            }
        }
        public List<string> PKeys { get { return pkeys; } set { pkeys = value; } }
        public bool SetReadOnly
        {
            set
            {
                if (value)
                {
                    State = FormState.Saved;
                }
                Button_Save.Enabled = !value;
            }
        }
        public FormState State { get { return statex; } set { statex = value; } }
        public class ColumnDictinary
        {
            public string AText = "";
            public string EText = "";
            public string Format = "";
            public bool IfDefault = false;
            public ColumnDictinary(string aText, string eText, bool ifDefault, string format)
            {
                AText = aText;
                EText = eText;
                IfDefault = ifDefault;
                Format = format;
            }
        }

        private void ribbonBar1_ItemClick(object sender, EventArgs e)
        {

        }
    }
}
