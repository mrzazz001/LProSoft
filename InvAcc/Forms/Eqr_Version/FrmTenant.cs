using C1.Win.C1BarCode;
using C1.Win.C1FlexGrid;
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
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmTenant : Form
    { void avs(int arln)

{ 
 ToolStripMenuItem_Rep.Text=   (arln == 0 ? "  إظهار التقرير  " : "  Show report") ; label_Option.Text=   (arln == 0 ? "  يرجى الضغط على زر الماوس الأيمن لعرض خيارات انشاء العقود او تعديلها  " : "  Please click the right mouse button to view the options for creating or modifying contracts") ; label9.Text=   (arln == 0 ? "  الجـــــــوال :  " : "  Mobile:") ; label14.Text=   (arln == 0 ? "  رقــــم الهــــاتف :  " : "  Phone number:") ; label5.Text=   (arln == 0 ? "  عنــوان العمـــل :  " : "  Work address:") ; label11.Text=   (arln == 0 ? "  تاريخهـــــــا :  " : "  Its history:") ; label12.Text=   (arln == 0 ? "  مصـــــــدرها :  " : "  Source:") ; label13.Text=   (arln == 0 ? "  رقـــم الهويــــــة :  " : "  ID number:") ; label7.Text=   (arln == 0 ? "  هاتف العمل :  " : "  Work Phone :") ; label3.Text=   (arln == 0 ? "  تاريخهـــــــا :  " : "  Its history:") ; label15.Text=   (arln == 0 ? "  إسـم الكفيــــل :  " : "  Sponsor's name:") ; label22.Text=   (arln == 0 ? "  حساب المستأجر :  " : "  Tenant's account:") ; label6.Text=   (arln == 0 ? "  عنــوان العمـــل :  " : "  Work address:") ; label8.Text=   (arln == 0 ? "  مصـــــــدرها :  " : "  Source:") ; label18.Text=   (arln == 0 ? "  الجنسيــــــة :  " : "  Nationality:") ; label10.Text=   (arln == 0 ? "  الجـــــــوال :  " : "  Mobile:") ; label16.Text=   (arln == 0 ? "  رقــــم الهــــاتف :  " : "  Phone number:") ; label19.Text=   (arln == 0 ? "  رقـــم الهويــــــة :  " : "  ID number:") ; label4.Text=   (arln == 0 ? "  رقم المستأجر :  " : "  Tenant No.:") ; label2.Text=   (arln == 0 ? "  الإسم الإنجليزي :  " : "  English name:") ; label1.Text=   (arln == 0 ? "  الإسم العربـــي :  " : "  Arabic name:") ; c1BarCode1.Text=   (arln == 0 ? "  1225  " : "  1225") ; line1.Text=   (arln == 0 ? "  line1  " : "  line1") ; ToolStripMenuItem_Det.Text=   (arln == 0 ? "  إظهار التفاصيل  " : "  Show details") ; panelEx3.Text=   (arln == 0 ? "  Fill Panel  " : "  Fill Panel") ; DGV_Main.Text=   (arln == 0 ? "    " : "    ") ; DGV_Main.Text=   (arln == 0 ? "  جميــع السجــــلات  " : "  All records") ; DGV_Main.Text=   (arln == 0 ? "    " : "    ") ; superTabControl_DGV.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; textBox_search.Text=   (arln == 0 ? "  ...  " : "  ...") ; Button_ExportTable2.Text=   (arln == 0 ? "  تصدير  " : "  Export") ; /*Button_PrintTable.Text=   (arln == 0 ? "  طباعة  " : "  Print") ; */panelEx2.Text=   (arln == 0 ? "  Click to collapse  " : "  Click to collapse") ; superTabControl_Main1.Text=   (arln == 0 ? "  superTabControl3  " : "  superTabControl3") ; Button_Close.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; Button_Search.Text=   (arln == 0 ? "  بحث  " : "  Search") ; Button_Delete.Text=   (arln == 0 ? "  حذف  " : "  delete") ; Button_Save.Text=   (arln == 0 ? "  حفظ  " : "  save") ; Button_Add.Text=   (arln == 0 ? "  إضافة  " : "  addition") ; superTabControl_Main2.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; Button_First.Text=   (arln == 0 ? "  الأول  " : "  the first") ; Button_Prev.Text=   (arln == 0 ? "  السابق  " : "  the previous") ; lable_Records.Text=   (arln == 0 ? "  ---  " : "  ---") ; Button_Next.Text=   (arln == 0 ? "  التالي  " : "  next one") ; Button_Last.Text=   (arln == 0 ? "  الأخير  " : "  the last one") ; StripMenue_Edit.Text=   (arln == 0 ? "  العقد رقم   " : "  Contract No.") ; StripMenue_Add.Text=   (arln == 0 ? "  عقــد جـــديد  " : "  new decade") ; StripMenue_Del.Text=   (arln == 0 ? "  حذف السجل  " : "  delete record") ; StripMenue_SndCatch.Text=   (arln == 0 ? "  سند قبض مستأجر  " : "  Tenant receipt document") ; StripMenue_SndSerf.Text=   (arln == 0 ? "  سند صرف مستأجر  " : "  Tenant's voucher") ; StripMenue_DelMonth.Text=   (arln == 0 ? "  حــذف دفعــــة  " : "  delete batch") ; Text = "كــــرت المستأجـــــرين";this.Text=   (arln == 0 ? "  كــــرت المستأجـــــرين  " : "  Tenants' card") ;}
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
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private T_AccDef _AccDefBind = new T_AccDef();
        private int LangArEn = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
#pragma warning disable CS0414 // The field 'FrmTenant.FlagUpdate' is assigned but its value is never used
        private string FlagUpdate = "";
#pragma warning restore CS0414 // The field 'FrmTenant.FlagUpdate' is assigned but its value is never used
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private T_Company _Company = new T_Company();
        private T_TenantContract _ContractDet = new T_TenantContract();
        private List<T_AinTyp> listAinTyp = new List<T_AinTyp>();
        private List<T_AinNatural> listAinNature = new List<T_AinNatural>();
        private T_AinTyp _AinTyp = new T_AinTyp();
        private T_AinNatural _AinNature = new T_AinNatural();
        private bool canUpdate = true;
        private T_Tenant data_this;
        private List<T_TenantContract> LData_This;
        private Stock_DataDataContext dbInstance;
        private List<string> pkeys = new List<string>();
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
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
        protected IntegerInput Rep_RecCount;
        protected ToolStripMenuItem ToolStripMenuItem_Rep;
        private RibbonBar ribbonBar1;
        private DockSite barTopDockSite;
        private DockSite barBottomDockSite;
        private DockSite barLeftDockSite;
        private DockSite barRightDockSite;
        private DockSite dockSite1;
        private DockSite dockSite2;
        public DotNetBarManager dotNetBarManager1;
        private DockSite dockSite4;
        private DockSite dockSite3;
        protected ContextMenuStrip contextMenuStrip1;
        protected ContextMenuStrip contextMenuStrip2;
        protected ToolStripMenuItem ToolStripMenuItem_Det;
        private System.Windows.Forms.OpenFileDialog  openFileDialog1;
        private System.Windows.Forms. SaveFileDialog saveFileDialog1;
        private PanelEx panelEx3;
        private PanelEx panelEx2;
        private ExpandableSplitter expandableSplitter1;
        private Panel panel1;
        private RibbonBar ribbonBar_Tasks;
        private SuperTabControl superTabControl_Main1;
        protected ButtonItem Button_Close;
        protected ButtonItem Button_Search;
        protected ButtonItem Button_Delete;
        protected ButtonItem Button_Save;
        protected ButtonItem Button_Add;
        protected LabelItem labelItem2;
        private SuperTabControl superTabControl_Main2;
        protected LabelItem labelItem1;
        protected ButtonItem Button_First;
        protected ButtonItem Button_Prev;
        protected TextBoxItem TextBox_Index;
        protected LabelItem Label_Count;
        protected ButtonItem Button_Next;
        protected ButtonItem Button_Last;
        protected SuperGridControl DGV_Main;
        private RibbonBar ribbonBar_DGV;
        private SuperTabControl superTabControl_DGV;
        protected TextBoxItem textBox_search;
        protected ButtonItem Button_ExportTable2;
        protected ButtonItem Button_PrintTable;
        protected LabelItem labelItem3;
        private Label label6;
        private TextBox txtTenantIDSource;
        private Label label8;
        private Label label18;
        private ComboBox CmbTenantNationality;
        private Label label19;
        private TextBox textBox_ID;
        private Label label4;
        private TextBox txtEngDes;
        private Label label2;
        private TextBox txtArbDes;
        private Label label1;
        private TextBox txtTenantWorkAdd;
        private C1BarCode c1BarCode1;
        private TextBox txtTenantAccNo;
        internal Label label22;
        private Label label10;
        private Label label16;
        private Label label15;
        private TextBox txtTenantIDNo;
        private C1FlexGrid FlxContracts;
        private LabelItem lable_Records;
        private MaskedTextBox txtTenantIDDate;
        private Label label3;
        private TextBox txtTenantTel;
        private Label label5;
        private TextBox txtBossWorkAdd;
        private MaskedTextBox txtBossIDDate;
        private Label label11;
        private TextBox txtBossID;
        private TextBox txtBossIDSource;
        private Label label12;
        private Label label13;
        private TextBox txtTenantWorkPhon;
        private Label label7;
        private TextBox txtTenantMobil;
        private TextBox txtBossName;
        private TextBox txtBossMobil;
        private TextBox txtBossPhon;
        private Label label9;
        private Label label14;
        private Line line1;
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem StripMenue_Edit;
        private ToolStripMenuItem StripMenue_Add;
        private ToolStripMenuItem StripMenue_Del;
        private ToolStripMenuItem StripMenue_SndCatch;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem StripMenue_SndSerf;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem StripMenue_DelMonth;
        private Label label_Option;
        public FormState State
        {
            get
            {
                return statex;
            }
            set
            {
                statex = value;
            }
        }
        public bool IfAdd
        {
            set
            {
            //    Button_Add.Visible = value;
            }
        }
        public bool IfDelete
        {
            set
            {
                Button_Delete.Visible = value;
                superTabControl_Main1.Refresh();
            }
        }
        public bool IfSave
        {
            set
            {
                Button_Save.Visible = value;
            }
        }
        protected bool CanUpdate
        {
            get
            {
                return canUpdate;
            }
            set
            {
                canUpdate = value;
            }
        }
        public T_Tenant DataThis
        {
            get
            {
                return data_this;
            }
            set
            {
                data_this = value;
                SetData(data_this);
            }
        }
        public List<T_TenantContract> LDataThis
        {
            get
            {
                return LData_This;
            }
            set
            {
                LData_This = value;
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
        public List<string> PKeys
        {
            get
            {
                return pkeys;
            }
            set
            {
                pkeys = value;
            }
        }
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
        public T_User Permmission
        {
            get
            {
                return permission;
            }
            set
            {
                if (value != null && value.UsrNo != "")
                {
                    permission = value;
                    if (!VarGeneral.TString.ChkStatShow(value.Eqar_TenantStr, 1))
                    {
                        IfAdd = false;
                    }
                    else
                    {
                        IfAdd = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Eqar_TenantStr, 2))
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Eqar_TenantStr, 3))
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
        private void Frm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
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
            else if (e.KeyCode == Keys.F5 && Button_PrintTable.Enabled && Button_PrintTable.Visible && !expandableSplitter1.Expanded)
            {
                Button_Print_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F10 && Button_ExportTable2.Enabled && Button_ExportTable2.Visible && !expandableSplitter1.Expanded)
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
        public void RefreshPKeys()
        {
            PKeys.Clear();
            var qkeys = from item in db.T_Tenants
                        orderby item.tenantNo
                        select new
                        {
                            Code = item.tenantNo + ""
                        };
            int count = 0;
            foreach (var item2 in qkeys)
            {
                count++;
                PKeys.Add(item2.Code);
            }
            Label_Count.Text = string.Concat(count);
            UpdateVcr();
        }
        protected bool ContinueIfEditOrNew()
        {
            if (State == FormState.Edit || State == FormState.New)
            {
                if (MessageBox.Show((LangArEn == 0) ? "تم تعديل السجل الحالي دون حفظ التغييرات .. هل تريد المتابعة؟" : "Not saved the changes, do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    return false;
                }
                return true;
            }
            return true;
        }
        public FrmTenant()
        {
            InitializeComponent();this.Load += langloads;
            txtArbDes.Click += Button_Edit_Click;
            txtBossID.Click += Button_Edit_Click;
            txtBossIDDate.Click += Button_Edit_Click;
            txtBossMobil.Click += Button_Edit_Click;
            txtBossName.Click += Button_Edit_Click;
            txtBossPhon.Click += Button_Edit_Click;
            txtBossWorkAdd.Click += Button_Edit_Click;
            txtEngDes.Click += Button_Edit_Click;
            txtBossIDSource.Click += Button_Edit_Click;
            txtTenantAccNo.Click += Button_Edit_Click;
            txtTenantIDDate.Click += Button_Edit_Click;
            txtTenantIDNo.Click += Button_Edit_Click;
            txtTenantIDSource.Click += Button_Edit_Click;
            txtTenantMobil.Click += Button_Edit_Click;
            txtTenantTel.Click += Button_Edit_Click;
            txtTenantWorkAdd.Click += Button_Edit_Click;
            txtTenantWorkPhon.Click += Button_Edit_Click;
            CmbTenantNationality.Click += Button_Edit_Click;
            DGV_Main.PrimaryGrid.CheckBoxes = false;
            DGV_Main.PrimaryGrid.ShowCheckBox = false;
            DGV_Main.PrimaryGrid.ShowTreeButton = false;
            DGV_Main.PrimaryGrid.ShowTreeButtons = false;
            DGV_Main.PrimaryGrid.ShowTreeLines = false;
            DGV_Main.PrimaryGrid.RowHeaderWidth = 25;
            DGV_Main.PrimaryGrid.VirtualMode = true;
            DGV_Main.MouseDown += DGV_Main_MouseDown;
            expandableSplitter1.Click += expandableSplitter1_Click;
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
            Button_PrintTable.Click += Button_Print_Click;
            GetInvSetting();
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
        public void Button_Search_Click(object sender, EventArgs e)
        {
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_Tenant";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                textBox_ID.Text = frm.SerachNo.ToString();
            }
        }
        public void Button_First_Click(object sender, EventArgs e)
        {
            if (ContinueIfEditOrNew())
            {
                TextBox_Index.TextBox.Text = string.Concat(1);
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
        public void Button_Last_Click(object sender, EventArgs e)
        {
            if (ContinueIfEditOrNew())
            {
                TextBox_Index.TextBox.Text = Label_Count.Text;
                UpdateVcr();
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
        private void TextBox_Search_InputTextChanged(object sender)
        {
            Fill_DGV_Main();
        }
        private void TextBox_Search_ButtonCustomClick(object sender, EventArgs e)
        {
            textBox_search.Text = "";
        }
        private void ToolStripMenuItem_Det_Click(object sender, EventArgs e)
        {
            int rowIndex = Convert.ToInt32(DGV_Main.PrimaryGrid.Tag);
            TextBox_Index.TextBox.Text = string.Concat(rowIndex + 1);
            expandableSplitter1.Expanded = true;
            ViewDetails_Click(sender, e);
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
        public void Fill_DGV_Main()
        {
            DGV_Main.PrimaryGrid.VirtualMode = false;
            List<T_Tenant> list = db.FillTenantData_2(textBox_search.TextBox.Text).ToList();
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
        }
        public void FillHDGV(IEnumerable<T_Tenant> new_data_enum)
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
                    DGV_Main.PrimaryGrid.Columns[i].Visible = columns_Names_visible[DGV_Main.PrimaryGrid.Columns[i].Name].IfDefault;
                    DGV_Main.PrimaryGrid.Columns[i].HeaderText = ((LangArEn == 0) ? columns_Names_visible[DGV_Main.PrimaryGrid.Columns[i].Name].AText : columns_Names_visible[DGV_Main.PrimaryGrid.Columns[i].Name].EText);
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
                        DGV_Main.PrimaryGrid.Columns[i].Visible = (contextMenuStrip1.Items[DGV_Main.PrimaryGrid.Columns[i].Name] as ToolStripMenuItem).Checked;
                    }
                }
                else
                {
                    DGV_Main.PrimaryGrid.Columns[i].Visible = false;
                }
            }
            DGV_Main.PrimaryGrid.DataSource = new_data_enum.ToList();
            DGV_Main.PrimaryGrid.DataMember = "T_Tenant";
            DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background.Color2 = Color.LightBlue;
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
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmTenant));
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
                Button_PrintTable.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "طباعة" : "عــرض");
                Button_PrintTable.Tooltip = "F5";
                Button_ExportTable2.Text = "تصدير";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "جميع السجلات";
                label_Option.Text = "يرجى الضغط على زر الماوس الأيمن لعرض خيارات انشاء العقود او تعديلها";
                Text = "كرت المستأجــرين";
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
                Button_PrintTable.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "Print" : "Show");
                Button_PrintTable.Tooltip = "F5";
                Button_ExportTable2.Text = "Export";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "All Records";
                label_Option.Text = "Please press the right mouse button to view options for creating or modifying contracts";
                Text = "Tenants Card";
            }
            ArbEng();
        }
        private void FrmTenant_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmTenant));
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
                Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
                if (columns_Names_visible.Count == 0)
                {
                    columns_Names_visible.Add("tenantNo", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
                    columns_Names_visible.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
                    columns_Names_visible.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
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
                FlxContracts.DrawMode = DrawModeEnum.OwnerDraw;
                FlxContracts.OwnerDrawCell += _ownerDraw;
                textBox_ID.Text = PKeys.FirstOrDefault();
                ViewDetails_Click(sender, e);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void _ownerDraw(object sender, OwnerDrawCellEventArgs e)
        {
            if (e.Col == 0 && e.Row > 0)
            {
                e.Text = e.Row.ToString();
            }
        }
        private void FillCombo()
        {
            List<T_Nationality> listNation = new List<T_Nationality>(db.T_Nationalities.Select((T_Nationality item) => item).ToList());
            listNation.Insert(0, new T_Nationality());
            CmbTenantNationality.DataSource = null;
            CmbTenantNationality.DataSource = listNation;
            CmbTenantNationality.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            CmbTenantNationality.ValueMember = "Nation_No";
        }
        private void GetInvSetting()
        {
            _InvSetting = db.StockInvSetting( 22);
            _Company = db.StockCompanyList().FirstOrDefault();
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
                T_Tenant newData = db.StockTenantData(no);
                if (newData == null || newData.tenantNo == 0)
                {
                    if (!Button_Add.Visible || !Button_Add.Enabled)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textBox_ID.TextChanged -= textBox_ID_TextChanged;
                        try
                        {
                            textBox_ID.Text = data_this.tenantNo.ToString();
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
                    int indexA = PKeys.IndexOf(string.Concat(newData.tenantNo));
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
        public void Clear()
        {
            if (State == FormState.New)
            {
                return;
            }
            State = FormState.New;
            data_this = new T_Tenant();
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
                    else if (controls[i].GetType() == typeof(TextBox) || controls[i].GetType() == typeof(TextBoxX) || controls[i].GetType() == typeof(MaskedTextBox))
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
            FlxContracts.Clear(ClearFlags.Content, 1, 1, FlxContracts.Rows.Count, 7);
            textBox_ID.Focus();
            CmbTenantNationality.SelectedIndex = 0;
            SetReadOnly = false;
        }
        public void SetData(T_Tenant value)
        {
            try
            {
                State = FormState.Saved;
                Button_Save.Enabled = false;
                textBox_ID.Tag = value.tenantID.ToString();
                txtArbDes.Text = value.NameA;
                txtEngDes.Text = value.NameE;
                txtBossID.Text = value.BossID;
                try
                {
                    if (VarGeneral.CheckDate(value.BossIDDate))
                    {
                        txtBossIDDate.Text = Convert.ToDateTime(value.BossIDDate).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        txtBossIDDate.Text = "";
                    }
                }
                catch
                {
                    txtBossIDDate.Text = "";
                }
                txtBossMobil.Text = value.BossMobile;
                txtBossName.Text = value.BossName;
                txtBossPhon.Text = value.BossPhone;
                txtBossWorkAdd.Text = value.BossAdd;
                txtBossIDSource.Text = value.BossIDSource;
                if (value.Nationalty.HasValue)
                {
                    CmbTenantNationality.SelectedValue = value.Nationalty;
                }
                else
                {
                    CmbTenantNationality.SelectedIndex = 0;
                }
                try
                {
                    if (!string.IsNullOrEmpty(value.AccNo))
                    {
                        txtTenantAccNo.Text = value.AccNo.ToString();
                    }
                    else
                    {
                        txtTenantAccNo.Text = "";
                    }
                }
                catch
                {
                    txtTenantAccNo.Text = "";
                }
                try
                {
                    if (VarGeneral.CheckDate(value.IDDate))
                    {
                        txtTenantIDDate.Text = Convert.ToDateTime(value.IDDate).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        txtTenantIDDate.Text = "";
                    }
                }
                catch
                {
                    txtTenantIDDate.Text = "";
                }
                txtTenantIDNo.Text = value.IDNo;
                txtTenantIDSource.Text = value.IDSource;
                txtTenantMobil.Text = value.Mobile;
                txtTenantTel.Text = value.Tel;
                txtTenantWorkAdd.Text = value.workAdd;
                txtTenantWorkPhon.Text = value.workPhone;
                LDataThis = new BindingList<T_TenantContract>(value.T_TenantContracts).OrderBy((T_TenantContract g) => g.ContractNo).ToList();
                SetLines(LDataThis);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SetData:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        public void SetLines(List<T_TenantContract> listDet)
        {
            try
            {
                FlxContracts.Rows.Count = listDet.Count + 1;
                for (int iiCnt = 1; iiCnt <= listDet.Count; iiCnt++)
                {
                    _ContractDet = listDet[iiCnt - 1];
                    FlxContracts.SetData(iiCnt, 1, _ContractDet.ContractNo);
                    FlxContracts.SetData(iiCnt, 2, _ContractDet.T_EqarsData.EqarNo);
                    if (_ContractDet.Ain_ID.HasValue)
                    {
                        FlxContracts.SetData(iiCnt, 3, _ContractDet.T_AinsData.AinNo);
                        FlxContracts.SetData(iiCnt, 4, (LangArEn == 0) ? _ContractDet.T_AinsData.T_AinTyp.NameA : _ContractDet.T_AinsData.T_AinTyp.NameE);
                    }
                    FlxContracts.SetData(iiCnt, 5, _ContractDet.ContractStart);
                    FlxContracts.SetData(iiCnt, 6, _ContractDet.ContractEnd);
                    FlxContracts.SetData(iiCnt, 7, _ContractDet.RentOfYear.Value);
                }
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "حدث خطأ أثناء تعبئة الأسطر .." : "An error occurred while filling lines ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void ArbEng()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                LangArEn = 0;
                FlxContracts.Cols[1].Caption = "رقم العقد";
                FlxContracts.Cols[2].Caption = "رقم العقار";
                FlxContracts.Cols[3].Caption = "رقم العين";
                FlxContracts.Cols[4].Caption = "نوع العين";
                FlxContracts.Cols[5].Caption = "تاريخ بداية العقد";
                FlxContracts.Cols[6].Caption = "تاريخ نهاية العقد";
                FlxContracts.Cols[7].Caption = "الإيجار السنوي";
            }
            else
            {
                LangArEn = 1;
                FlxContracts.Cols[1].Caption = "Contract No";
                FlxContracts.Cols[2].Caption = "Real Estate No";
                FlxContracts.Cols[3].Caption = "Eye No";
                FlxContracts.Cols[4].Caption = "Eye Type";
                FlxContracts.Cols[5].Caption = "Start contract";
                FlxContracts.Cols[6].Caption = "End contract";
                FlxContracts.Cols[7].Caption = "annual rent";
            }
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
        private T_Tenant GetData()
        {
            textBox_ID.Focus();
            data_this.tenantNo = int.Parse(textBox_ID.Text);
            data_this.NameA = txtArbDes.Text;
            data_this.NameE = txtEngDes.Text;
            data_this.BossID = txtBossID.Text;
            try
            {
                if (VarGeneral.CheckDate(txtBossIDDate.Text))
                {
                    data_this.BossIDDate = txtBossIDDate.Text;
                }
                else
                {
                    data_this.BossIDDate = "";
                }
            }
            catch
            {
                data_this.BossIDDate = "";
            }
            data_this.BossMobile = txtBossMobil.Text;
            data_this.BossName = txtBossName.Text;
            data_this.BossPhone = txtBossPhon.Text;
            data_this.BossAdd = txtBossWorkAdd.Text;
            data_this.BossIDSource = txtBossIDSource.Text;
            data_this.Nationalty = int.Parse(CmbTenantNationality.SelectedValue.ToString());
            if (!string.IsNullOrEmpty(txtTenantAccNo.Text))
            {
                data_this.AccNo = txtTenantAccNo.Text;
            }
            else
            {
                data_this.AccNo = null;
            }
            try
            {
                if (VarGeneral.CheckDate(txtTenantIDDate.Text))
                {
                    data_this.IDDate = txtTenantIDDate.Text;
                }
                else
                {
                    data_this.IDDate = "";
                }
            }
            catch
            {
                data_this.IDDate = "";
            }
            data_this.IDNo = txtTenantIDNo.Text;
            data_this.IDSource = txtTenantIDSource.Text;
            data_this.Mobile = txtTenantMobil.Text;
            data_this.Tel = txtTenantTel.Text;
            data_this.workAdd = txtTenantWorkAdd.Text;
            data_this.workPhone = txtTenantWorkPhon.Text;
            return data_this;
        }
        private void Button_Edit_Click(object sender, EventArgs e)
        {
            if (CanEdit && State != FormState.Edit && State != FormState.New && !string.IsNullOrEmpty(textBox_ID.Text))
            {
                if (State != FormState.New)
                {
                    State = FormState.Edit;
                }
                SetReadOnly = false;
            }
        }
        private void Button_Add_Click(object sender, EventArgs e)
        {
            if (!Button_Add.Visible || !Button_Add.Enabled)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                if (State == FormState.Edit && MessageBox.Show((LangArEn == 0) ? "تم تعديل السجل الحالي دون حفظ التغييرات .. هل تريد المتابعة؟" : "Not saved the changes, do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    return;
                }
                Clear();
                int id = db.MaxTenantDataNo;
                textBox_ID.Text = id.ToString();
                if (!string.IsNullOrEmpty(VarGeneral.Settings_Sys.tenantAcc))
                {
                    int Value = 0;
                    List<T_AccDef> q = (from t in db.T_AccDefs
                                        where t.ParAcc == VarGeneral.Settings_Sys.tenantAcc
                                        orderby t.AccDef_ID
                                        select t).ToList();
                    if (q.Count == 0)
                    {
                        txtTenantAccNo.Text = VarGeneral.Settings_Sys.tenantAcc + "001";
                    }
                    else
                    {
                        _AccDefBind = q[q.Count - 1];
                        string _Zero = "";
                        for (int iiCnt = 0; iiCnt < _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Length && _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Substring(iiCnt, 1) == "0"; iiCnt++)
                        {
                            _Zero += _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Substring(iiCnt, 1);
                        }
                        Value = int.Parse(_AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length)) + 1;
                        if (!string.IsNullOrEmpty(_Zero))
                        {
                            txtTenantAccNo.Text = _AccDefBind.ParAcc + _Zero + Value;
                        }
                        else
                        {
                            txtTenantAccNo.Text = _AccDefBind.ParAcc + Value;
                        }
                    }
                }
                State = FormState.New;
            }
        }
        private bool ValidData()
        {
            if (!Button_Save.Visible)
            {
                return false;
            }
            if (State == FormState.Edit && !CanEdit)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (State == FormState.New && !Button_Add.Visible)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if (textBox_ID.Text == "0" || textBox_ID.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ بدون رقم العقار" : "Can not save without the Number", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_ID.Focus();
                return false;
            }
            if (txtArbDes.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الإسم فارغا\u0651" : "Can not be name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtArbDes.Focus();
                return false;
            }
            if (txtEngDes.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الإسم فارغا\u0651" : "Can not be name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtEngDes.Focus();
                return false;
            }
            if (txtTenantIDNo.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون رقم هوية المستأجر فارغا\u0651" : "Can not be tenant ID No is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtTenantIDNo.Focus();
                return false;
            }
            if (txtTenantAccNo.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ بدون رقم حساب المستأجر" : "Can not save without the tenant account number.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtTenantAccNo.Focus();
                return false;
            }
            try
            {
                if (int.Parse(CmbTenantNationality.SelectedValue.ToString()) <= 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "تاكد من الجنسية" : "Can not save without Nationality.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    CmbTenantNationality.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "تاكد من الجنسية" : "Can not save without Nationality.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                CmbTenantNationality.Focus();
                return false;
            }
            return true;
        }
        private void Button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidData())
                {
                    return;
                }
                txtArbDes.Focus();
                GetData();
                if (State == FormState.New)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(txtTenantAccNo.Text))
                        {
                            T_AccDef c = db.StockAccDefWithOutBalance(txtTenantAccNo.Text);
                            if (c == null || c.AccDef_ID == 0)
                            {
                                if (!string.IsNullOrEmpty(VarGeneral.Settings_Sys.tenantAcc))
                                {
                                    int Value = 0;
                                    List<T_AccDef> q = (from t in db.T_AccDefs
                                                        where t.ParAcc == VarGeneral.Settings_Sys.tenantAcc
                                                        orderby t.AccDef_ID
                                                        select t).ToList();
                                    if (q.Count == 0)
                                    {
                                        txtTenantAccNo.Text = VarGeneral.Settings_Sys.tenantAcc + "001";
                                    }
                                    else
                                    {
                                        _AccDefBind = q[q.Count - 1];
                                        string _Zero = "";
                                        for (int iiCnt = 0; iiCnt < _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Length && _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Substring(iiCnt, 1) == "0"; iiCnt++)
                                        {
                                            _Zero += _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Substring(iiCnt, 1);
                                        }
                                        Value = int.Parse(_AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length)) + 1;
                                        if (!string.IsNullOrEmpty(_Zero))
                                        {
                                            txtTenantAccNo.Text = _AccDefBind.ParAcc + _Zero + Value;
                                        }
                                        else
                                        {
                                            txtTenantAccNo.Text = _AccDefBind.ParAcc + Value;
                                        }
                                    }
                                }
                                if (string.IsNullOrEmpty(txtTenantAccNo.Text))
                                {
                                    MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ بدون رقم حساب المستأجر" : "Can not save without the Tenant account number.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    txtTenantAccNo.Focus();
                                    return;
                                }
                                data_this.AccNo = txtTenantAccNo.Text;
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [DepreciationPercent], [ProofAcc], [RelayAcc],[MaxDisCust],[vColNum1],[vColNum2],[vColStr1],[vColStr2],[vColStr3]) VALUES (N'" + txtTenantAccNo.Text + "', N'" + txtArbDes.Text + "', N'" + txtEngDes.Text + "', N'" + VarGeneral.Settings_Sys.tenantAcc + "', 4, NULL, 12, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL,0,0,0,'','','')");
                            }
                            else
                            {
                                data_this.AccNo = txtTenantAccNo.Text;
                            }
                        }
                        db.T_Tenants.InsertOnSubmit(data_this);
                        db.SubmitChanges();
                    }
                    catch (SqlException ex4)
                    {
                        if (ex4.Number != 2627)
                        {
                            return;
                        }
                        MessageBox.Show("الرقم مستخدم من قبل.\n سيتم الحفظ برقم جديد ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        int id = db.MaxTenantDataNo;
                        textBox_ID.Text = id.ToString();
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
                        db.ExecuteCommand("update [dbo].[T_AccDef] Set [Arb_Des] = '" + txtArbDes.Text + "' , [Eng_Des] = '" + txtEngDes.Text + "' where AccDef_No = '" + txtTenantAccNo.Text + "'");
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
                MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                State = FormState.Saved;
                RefreshPKeys();
                TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(string.Concat(data_this.tenantNo)) + 1);
                dbInstance = null;
                textBox_ID_TextChanged(sender, e);
                SetReadOnly = true;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
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
            if (MessageBox.Show("هل أنت متاكد من حذف السجل [" + Code + "]؟ \n Are you sure that you want to delete the record [" + Code + "]?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ifOkDelete = true;
            }
            else
            {
                ifOkDelete = false;
            }
            if (data_this == null || data_this.tenantID == 0 || !ifOkDelete)
            {
                return;
            }
            if (LData_This.Count > 0)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكنك حذف هذا المستأجر لان لديه عقود غير ملغية" : "You can't delete this Record because it has contracts", VarGeneral.ProdectNam);
                return;
            }
            data_this = db.StockTenantData(DataThis.tenantNo);
            try
            {
                db.T_Tenants.DeleteOnSubmit(DataThis);
                db.SubmitChanges();
            }
            catch (SqlException)
            {
                data_this = db.StockTenantData(DataThis.tenantNo);
                return;
            }
            catch (Exception)
            {
                data_this = db.StockTenantData(DataThis.tenantNo);
                return;
            }
            Clear();
            RefreshPKeys();
            textBox_ID.Text = PKeys.LastOrDefault();
        }
        private void DGV_Main_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            string dataMember = panel.DataMember;
            if (dataMember != null && dataMember == "T_Tenant")
            {
                PropBranchPanel(panel);
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
            panel.Columns["tenantNo"].Width = 120;
            panel.Columns["tenantNo"].Visible = columns_Names_visible["tenantNo"].IfDefault;
            panel.Columns["NameA"].Width = 180;
            panel.Columns["NameA"].Visible = columns_Names_visible["NameA"].IfDefault;
            panel.Columns["NameE"].Width = 180;
            panel.Columns["NameE"].Visible = columns_Names_visible["NameE"].IfDefault;
        }
        private void DGV_Main_CellClick(object sender, GridCellClickEventArgs e)
        {
            DGV_Main.PrimaryGrid.Tag = e.GridCell.RowIndex;
        }
        private void DGV_Main_CellDoubleClick(object sender, GridCellDoubleClickEventArgs e)
        {
            ToolStripMenuItem_Det_Click(sender, e);
        }
        private void Button_ExportTable2_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcel.ExportToExcel(DGV_Main, "تقرير المستأجرين");
            }
            catch
            {
            }
        }
        private void Button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ADD_Controls()
        {
            try
            {
                controls = new List<Control>();
                controls.Add(textBox_ID);
                controls.Add(txtArbDes);
                controls.Add(txtBossID);
                controls.Add(txtBossIDDate);
                controls.Add(txtBossMobil);
                controls.Add(txtBossName);
                controls.Add(txtBossWorkAdd);
                controls.Add(txtBossPhon);
                controls.Add(txtEngDes);
                controls.Add(txtBossIDSource);
                controls.Add(txtTenantAccNo);
                controls.Add(txtTenantIDDate);
                controls.Add(txtTenantIDNo);
                controls.Add(txtTenantIDSource);
                controls.Add(txtTenantMobil);
                controls.Add(txtTenantTel);
                controls.Add(txtTenantWorkAdd);
                controls.Add(txtTenantWorkPhon);
                controls.Add(CmbTenantNationality);
            }
            catch (SqlException)
            {
            }
        }
        private void txtArbDes_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("Arabic");
        }
        private void txtEngDes_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("English");
        }
        private void textBox_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
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
                _RepShow.Tables = " T_Tenant  ";
                string Fields = "";
                Fields = " T_Tenant.tenantID , T_Tenant.tenantNo as No , T_Tenant.NameA as NmA, T_Tenant.NameE as NmE ,(select T_SYSSETTING.LogImg from T_SYSSETTING) as LogImg";
                _RepShow.Rule = " ";
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
                        MessageBox.Show((LangArEn == 0) ? "عفوا .. لا يوجد بيانات لعرضها في التقرير " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                    MessageBox.Show((LangArEn == 0) ? " يجب تحديد حقل واحد على الأقل للطباعة" : "You must select one field or more", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }
        private void txtTenantIDDate_Click(object sender, EventArgs e)
        {
            txtTenantIDDate.SelectAll();
        }
        private void txtTenantIDDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtTenantIDDate.Text))
                {
                    txtTenantIDDate.Text = Convert.ToDateTime(txtTenantIDDate.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    txtTenantIDDate.Text = "";
                }
            }
            catch
            {
                txtTenantIDDate.Text = "";
            }
        }
        private void txtTenantIDNo_Click(object sender, EventArgs e)
        {
            txtTenantIDNo.SelectAll();
        }
        private void txtTenantIDSource_Click(object sender, EventArgs e)
        {
            txtTenantIDSource.SelectAll();
        }
        private void txtBossID_Click(object sender, EventArgs e)
        {
            txtBossID.SelectAll();
        }
        private void txtIDSource_Click(object sender, EventArgs e)
        {
            txtBossIDSource.SelectAll();
        }
        private void txtBossIDDate_Click(object sender, EventArgs e)
        {
            txtBossIDDate.SelectAll();
        }
        private void txtBossIDDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtBossIDDate.Text))
                {
                    txtBossIDDate.Text = Convert.ToDateTime(txtBossIDDate.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    txtBossIDDate.Text = "";
                }
            }
            catch
            {
                txtBossIDDate.Text = "";
            }
        }
        private void txtTenantTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b')) && e.KeyChar != '-' && e.KeyChar != '\\')
            {
                e.Handled = true;
            }
        }
        private void txtTenantIDNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void FlxContracts_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (State != 0 || data_this == null || data_this.tenantID <= 0 || e.Button != MouseButtons.Right)
                {
                    return;
                }
                int SelNow = FlxContracts.RowSel;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    if (data_this.T_TenantContracts.Count > 0 && FlxContracts.RowSel > 0)
                    {
                        StripMenue_Edit.Visible = true;
                        StripMenue_Edit.Text = "العقد رقم " + FlxContracts.GetData(FlxContracts.RowSel, 1).ToString();
                    }
                    else
                    {
                        StripMenue_Edit.Visible = false;
                    }
                    StripMenue_Add.Text = "عقــد جـــديد";
                    StripMenue_Del.Text = "حذف السجل - العقد";
                    StripMenue_DelMonth.Text = "حــذف دفعــــة";
                    StripMenue_SndCatch.Text = "سند قبض مستأجر";
                    StripMenue_SndSerf.Text = "سند صرف مستأجر";
                }
                else
                {
                    if (data_this.T_TenantContracts.Count > 0 && FlxContracts.RowSel > 0)
                    {
                        StripMenue_Edit.Visible = true;
                        StripMenue_Edit.Text = "Contract No " + FlxContracts.GetData(FlxContracts.RowSel, 1).ToString();
                    }
                    else
                    {
                        StripMenue_Edit.Visible = false;
                    }
                    StripMenue_Add.Text = "New Contract";
                    StripMenue_Del.Text = "Delete Record - Contract";
                    StripMenue_DelMonth.Text = "Delete Premium";
                    StripMenue_SndCatch.Text = "Tenant receipt voucher";
                    StripMenue_SndSerf.Text = "Tenant exchange voucher";
                }
                contextMenu.Show(Cursor.Position.X, Cursor.Position.Y);
            }
            catch
            {
            }
        }
        private void StripMenue_Add_Click(object sender, EventArgs e)
        {
            FrmTenantContract frm = new FrmTenantContract();
            frm.TenantID_ = data_this.tenantID.ToString();
            frm.TenantNm_ = ((LangArEn == 0) ? data_this.NameA : data_this.NameE);
            frm.TenantNo_ = data_this.tenantNo.ToString();
            frm.ProcessTyp = 0;
            frm.Tag = LangArEn;
            frm.TopMost = true;
            frm.ShowDialog();
            dbInstance = null;
            textBox_ID_TextChanged(sender, e);
        }
        private void StripMenue_Edit_Click(object sender, EventArgs e)
        {
            FrmTenantContract frm = new FrmTenantContract();
            frm.TenantID_ = data_this.tenantID.ToString();
            frm.TenantNm_ = ((LangArEn == 0) ? data_this.NameA : data_this.NameE);
            frm.TenantNo_ = data_this.tenantNo.ToString();
            frm.ProcessTyp = 1;
            frm._ContractNo = int.Parse(FlxContracts.GetData(FlxContracts.RowSel, 1).ToString());
            frm.Tag = LangArEn;
            frm.TopMost = true;
            frm.ShowDialog();
            dbInstance = null;
            textBox_ID_TextChanged(sender, e);
        }
        private void StripMenue_Del_Click(object sender, EventArgs e)
        {
            int ContractN_ = 0;
            try
            {
                ContractN_ = int.Parse(FlxContracts.GetData(FlxContracts.RowSel, 1).ToString());
            }
            catch
            {
                ContractN_ = 0;
            }
            if (ContractN_ <= 0)
            {
                MessageBox.Show((LangArEn == 0) ? "يرجى اختيار عقد محدد لاتمام العملية" : "Please select a specific contract to complete the process", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            T_TenantContract q = db.StockTenantContractData(ContractN_, data_this.tenantID);
            if (q == null || q.tenant_ID <= 0 || MessageBox.Show("هل أنت متاكد من حذف العقد رقم [" + ContractN_ + "]؟ \n Are you sure that you want to delete the Contract [" + ContractN_ + "]?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            if (q.T_TenantPayments.ToList().Count > 0 && q.T_TenantPayments.Where((T_TenantPayment g) => g.SndNo.HasValue).ToList().Count > 0)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن حذف العقد لان لديه دفعات" : "Please select a specific contract to complete the process", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            db.ExecuteCommand("DELETE FROM [dbo].[T_TenantPayment] WHERE tenantContract_ID = " + q.ContractID);
            if (q.Ain_ID.HasValue)
            {
                Eqar_Ain_StatusControl(1, 0, q);
            }
            else
            {
                Eqar_Ain_StatusControl(0, 0, q);
            }
            db.T_TenantContracts.DeleteOnSubmit(q);
            db.SubmitChanges();
            dbInstance = null;
            try
            {
                string vPth = Application.StartupPath + "\\ContractRent\\Contract" + q.ContractNo + ".doc";
                if (File.Exists(vPth))
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    File.Delete(vPth);
                }
            }
            catch
            {
            }
            textBox_ID_TextChanged(sender, e);
        }
        private void Eqar_Ain_StatusControl(int ProcessTyp, int StatusValue, T_TenantContract vData)
        {
            if (ProcessTyp == 0)
            {
                db.ExecuteCommand("  UPDATE T_EqarsData SET  EqarStatus = " + StatusValue + " Where EqarID = " + vData.Eqar_ID);
            }
            else
            {
                db.ExecuteCommand("  UPDATE T_AinsData SET  AinStatus = " + StatusValue + " Where AinID = " + vData.Ain_ID);
            }
        }
        private void StripMenue_DelMonth_Click(object sender, EventArgs e)
        {
            if (State != 0)
            {
                return;
            }
            int ContractN_ = 0;
            try
            {
                ContractN_ = int.Parse(FlxContracts.GetData(FlxContracts.RowSel, 1).ToString());
            }
            catch
            {
                ContractN_ = 0;
            }
            if (ContractN_ <= 0)
            {
                MessageBox.Show((LangArEn == 0) ? "يرجى اختيار عقد محدد لاتمام العملية" : "Please select a specific contract to complete the process", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            FrmTenantPayment frm = new FrmTenantPayment();
            frm.Tag = LangArEn;
            T_TenantContract q = db.StockTenantContractData(ContractN_, data_this.tenantID);
            if (new BindingList<T_TenantPayment>(q.T_TenantPayments).OrderBy((T_TenantPayment g) => g.PaymentNo).ToList().Count <= 0)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يوجد دفعات مقسمة لهذا المستأجر" : "There is no split payments for this tenant", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            frm.data_this = q;
            frm.FrmTyp = true;
            frm.TopMost = true;
            frm.ShowDialog();
        }
        private void StripMenue_SndCatch_Click(object sender, EventArgs e)
        {
            if (!VarGeneral.TString.ChkStatShow(permission.Eqar_TenantStr, 4))
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكنك إضافة عميل جديد .. راجع صلاحيات المستخدمين" : "You can not add a new customer ... Check the Users Authorizations", VarGeneral.ProdectNam);
                return;
            }
            int ContractN_ = 0;
            try
            {
                ContractN_ = int.Parse(FlxContracts.GetData(FlxContracts.RowSel, 1).ToString());
            }
            catch
            {
                ContractN_ = 0;
            }
            if (ContractN_ <= 0)
            {
                MessageBox.Show((LangArEn == 0) ? "يرجى اختيار عقد محدد لاتمام العملية" : "Please select a specific contract to complete the process", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            FrmSndTenant frm = new FrmSndTenant();
            frm.TenantID_ = data_this.tenantID.ToString();
            frm.TenantNo_ = data_this.tenantNo.ToString();
            frm.ProcessTyp = 1;
            frm.ContractNo = ContractN_;
            frm.Tag = LangArEn;
            frm.TopMost = true;
            VarGeneral.InvTyp = 29;
            frm.ShowDialog();
            dbInstance = null;
            textBox_ID_TextChanged(sender, e);
        }
        private void StripMenue_SndSerf_Click(object sender, EventArgs e)
        {
            if (!VarGeneral.TString.ChkStatShow(permission.Eqar_TenantStr, 8))
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكنك إضافة عميل جديد .. راجع صلاحيات المستخدمين" : "You can not add a new customer ... Check the Users Authorizations", VarGeneral.ProdectNam);
                return;
            }
            int ContractN_ = 0;
            try
            {
                ContractN_ = int.Parse(FlxContracts.GetData(FlxContracts.RowSel, 1).ToString());
            }
            catch
            {
                ContractN_ = 0;
            }
            if (ContractN_ <= 0)
            {
                MessageBox.Show((LangArEn == 0) ? "يرجى اختيار عقد محدد لاتمام العملية" : "Please select a specific contract to complete the process", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            FrmSndTenant frm = new FrmSndTenant();
            frm.TenantID_ = data_this.tenantID.ToString();
            frm.TenantNo_ = data_this.tenantNo.ToString();
            frm.ProcessTyp = 1;
            frm.ContractNo = ContractN_;
            frm.Tag = LangArEn;
            frm.TopMost = true;
            VarGeneral.InvTyp = 30;
            frm.ShowDialog();
            dbInstance = null;
            textBox_ID_TextChanged(sender, e);
        }
        private void FlxContracts_MouseHover(object sender, EventArgs e)
        {
            if (State != FormState.New)
            {
                label_Option.Visible = true;
            }
        }
        private void FlxContracts_MouseLeave(object sender, EventArgs e)
        {
            label_Option.Visible = false;
        }

        private void FlxContracts_Click(object sender, EventArgs e)
        {

        }
    }
}
