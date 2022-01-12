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
using SSSLanguage;
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
    public partial  class FrmAlarmTenant : Form
    { void avs(int arln)

{ 
 ToolStripMenuItem_Rep.Text=   (arln == 0 ? "  إظهار التقرير  " : "  Show report") ; label22.Text=   (arln == 0 ? "  التاريـــــــخ :  " : "  date:") ; label16.Text=   (arln == 0 ? "  التفاصيـــــــــــل :  " : "  Details:") ; label19.Text=   (arln == 0 ? "  المــوضـــــــــوع :  " : "  Subject:") ; label4.Text=   (arln == 0 ? "  رقم الإشعــــــار :  " : "  Notice number:") ; label2.Text=   (arln == 0 ? "  المســــــــــؤول :  " : "  Responsible:") ; label1.Text=   (arln == 0 ? "  المستــأجـــــــر :  " : "  Tenant:") ; c1BarCode1.Text=   (arln == 0 ? "  1225  " : "  1225") ; ToolStripMenuItem_Det.Text=   (arln == 0 ? "  إظهار التفاصيل  " : "  Show details") ; panelEx3.Text=   (arln == 0 ? "  Fill Panel  " : "  Fill Panel") ; DGV_Main.Text=   (arln == 0 ? "    " : "    ") ; DGV_Main.Text=   (arln == 0 ? "  جميــع السجــــلات  " : "  All records") ; DGV_Main.Text=   (arln == 0 ? "    " : "    ") ; superTabControl_DGV.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; textBox_search.Text=   (arln == 0 ? "  ...  " : "  ...") ; Button_ExportTable2.Text=   (arln == 0 ? "  تصدير  " : "  Export") ; /*Button_PrintTable.Text=   (arln == 0 ? "  طباعة  " : "  Print") ; */panelEx2.Text=   (arln == 0 ? "  Click to collapse  " : "  Click to collapse") ; superTabControl_Main1.Text=   (arln == 0 ? "  superTabControl3  " : "  superTabControl3") ; Button_Close.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; Button_Search.Text=   (arln == 0 ? "  بحث  " : "  Search") ; /*buttonItem_Print.Text=   (arln == 0 ? "  طباعة  " : "  Print") ;*/ Button_Delete.Text=   (arln == 0 ? "  حذف  " : "  delete") ; Button_Save.Text=   (arln == 0 ? "  حفظ  " : "  save") ; Button_Add.Text=   (arln == 0 ? "  إضافة  " : "  addition") ; superTabControl_Main2.Text=   (arln == 0 ? "  superTabControl1  " : "  superTabControl1") ; Button_First.Text=   (arln == 0 ? "  الأول  " : "  the first") ; Button_Prev.Text=   (arln == 0 ? "  السابق  " : "  the previous") ; lable_Records.Text=   (arln == 0 ? "  ---  " : "  ---") ; Button_Next.Text=   (arln == 0 ? "  التالي  " : "  next one") ; Button_Last.Text=   (arln == 0 ? "  الأخير  " : "  the last one") ; Text = "كــــرت الإشعــــــارات";this.Text=   (arln == 0 ? "  كــــرت الإشعــــــارات  " : "  Notification card") ;}
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
                        frm.Repvalue = "RepAlarmTenant";
                        frm.Repvalue = "RepGeneral";
                        frm.Repvalue = "RepAlarmTenant";
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
        private TextBox txtSubject;
        private Label label19;
        private TextBox textBox_ID;
        private Label label4;
        private Label label2;
        private Label label1;
        private TextBox txtAdmin;
        private TextBox txtDetail;
        private C1BarCode c1BarCode1;
        internal Label label22;
        private ButtonX button_SrchTenantNo;
        private Label label16;
        internal TextBox txtTenantName;
        private TextBox txtTenantNo;
        private LabelItem lable_Records;
        private MaskedTextBox txtGDate;
        private MaskedTextBox txtHDate;
        protected ButtonItem buttonItem_Print;
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private T_AccDef _AccDefBind = new T_AccDef();
        private int LangArEn = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
#pragma warning disable CS0414 // The field 'FrmAlarmTenant.FlagUpdate' is assigned but its value is never used
        private string FlagUpdate = "";
#pragma warning restore CS0414 // The field 'FrmAlarmTenant.FlagUpdate' is assigned but its value is never used
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        private T_Company _Company = new T_Company();
        private T_AinsData _AinDet = new T_AinsData();
        private List<T_AinTyp> listAinTyp = new List<T_AinTyp>();
        private List<T_AinNatural> listAinNature = new List<T_AinNatural>();
        private T_AinTyp _AinTyp = new T_AinTyp();
        private T_AinNatural _AinNature = new T_AinNatural();
        private bool canUpdate = true;
        private T_AlarmTenant data_this;
        private List<T_AinsData> LData_This;
        private Stock_DataDataContext dbInstance;
        private List<string> pkeys = new List<string>();
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
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
                Button_Add.Visible = value;
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
        public T_AlarmTenant DataThis
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
        public List<T_AinsData> LDataThis
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
                    if (!VarGeneral.TString.ChkStatShow(value.Eqar_TenantStr, 13))
                    {
                        IfAdd = false;
                    }
                    else
                    {
                        IfAdd = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Eqar_TenantStr, 14))
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Eqar_TenantStr, 15))
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
                if (expandableSplitter1.Expanded && buttonItem_Print.Enabled && buttonItem_Print.Visible && State == FormState.Saved)
                {
                    Button_Print_Click(sender, e);
                }
                else if (Button_PrintTable.Enabled && Button_PrintTable.Visible && !expandableSplitter1.Expanded)
                {
                    Button_PrintTable_Click(sender, e);
                }
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
            var qkeys = from item in db.T_AlarmTenants
                        orderby item.AlarmTenantNo
                        select new
                        {
                            Code = item.AlarmTenantNo + ""
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
        public FrmAlarmTenant()
        {
            InitializeComponent();this.Load += langloads;
            txtAdmin.Click += Button_Edit_Click;
            txtDetail.Click += Button_Edit_Click;
            txtGDate.Click += Button_Edit_Click;
            txtHDate.Click += Button_Edit_Click;
            txtSubject.Click += Button_Edit_Click;
            button_SrchTenantNo.Click += Button_Edit_Click;
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
            Button_PrintTable.Click += Button_PrintTable_Click;
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
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("AlarmTenantNo", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
            columns_Names_visible2.Add("NameA", new ColumnDictinary("إسم المستأجر عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible2.Add("NameE", new ColumnDictinary("إسم المستأجر إنجليزي", "English Name", ifDefault: true, ""));
            columns_Names_visible2.Add("AlarmSubject", new ColumnDictinary("موضوع الإشعار", "Subject", ifDefault: true, ""));
            columns_Names_visible2.Add("AlarmAdmin", new ColumnDictinary("المســؤول", "Administrator", ifDefault: false, ""));
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_AlarmTenant";
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
            List<T_AlarmTenant> list = db.FillAlarmTenant_2(textBox_search.TextBox.Text).ToList();
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
        }
        public void FillHDGV(IEnumerable<T_AlarmTenant> new_data_enum)
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
            DGV_Main.PrimaryGrid.DataMember = "T_AlarmTenant";
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmAlarmTenant));
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
                buttonItem_Print.Text = ((VarGeneral.GeneralPrinter.ISdirectPrinting) ? "طباعة" : "عــرض");
                buttonItem_Print.Tooltip = "F5";
                Button_PrintTable.Text = ((VarGeneral.GeneralPrinter.ISdirectPrinting) ? "طباعة" : "عــرض");
                Button_PrintTable.Tooltip = "F5";
                Button_ExportTable2.Text = "تصدير";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "جميع السجلات";
                Text = "كرت الإشعــــارات";
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
                buttonItem_Print.Text = ((VarGeneral.GeneralPrinter.ISdirectPrinting) ? "Print" : "Show");
                buttonItem_Print.Tooltip = "F5";
                Button_PrintTable.Text = ((VarGeneral.GeneralPrinter.ISdirectPrinting) ? "Print" : "Show");
                Button_PrintTable.Tooltip = "F5";
                Button_ExportTable2.Text = "Export";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "All Records";
                Text = "Notifications Card";
            }
        }
        private void FrmAlarmTenant_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmAlarmTenant));
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
                ADD_Controls();
                Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
                if (columns_Names_visible.Count == 0)
                {
                    columns_Names_visible.Add("AlarmTenantNo", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
                    columns_Names_visible.Add("AlarmSubject", new ColumnDictinary("موضوع الإشعار", "Subject", ifDefault: true, ""));
                    columns_Names_visible.Add("AlarmAdmin", new ColumnDictinary("المســؤول", "Administrator", ifDefault: true, ""));
                    columns_Names_visible.Add("AlarmDateG", new ColumnDictinary("التاريخ الميلادي", "Date Ger", ifDefault: true, ""));
                    columns_Names_visible.Add("AlarmDateH", new ColumnDictinary("التاريخ الهجري", "Date Hijri", ifDefault: true, ""));
                }
                else
                {
                    Clear();
                    textBox_ID.Text = "";
                    TextBox_Index.TextBox.Text = "";
                }
                RefreshPKeys();
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
        private void _ownerDraw(object sender, OwnerDrawCellEventArgs e)
        {
            if (e.Col == 0 && e.Row > 0)
            {
                e.Text = e.Row.ToString();
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
                T_AlarmTenant newData = db.StockAlarmTenant(no);
                if (newData == null || newData.AlarmTenantNo == 0)
                {
                    if (!Button_Add.Visible || !Button_Add.Enabled)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textBox_ID.TextChanged -= textBox_ID_TextChanged;
                        try
                        {
                            textBox_ID.Text = data_this.AlarmTenantNo.ToString();
                        }
                        catch
                        {
                        }
                        textBox_ID.TextChanged += textBox_ID_TextChanged;
                        return;
                    }
                    Clear();
                    txtGDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                    txtHDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                    try
                    {
                        txtAdmin.Text = ((LangArEn == 0) ? VarGeneral.UserNameA : VarGeneral.UserNameE);
                    }
                    catch
                    {
                    }
                    TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                    TextBox_Index.TextBox.Text = string.Concat(PKeys.Count + 1);
                    TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                }
                else
                {
                    DataThis = newData;
                    int indexA = PKeys.IndexOf(string.Concat(newData.AlarmTenantNo));
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
            data_this = new T_AlarmTenant();
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
            textBox_ID.Focus();
            SetReadOnly = false;
        }
        public void SetData(T_AlarmTenant value)
        {
            try
            {
                State = FormState.Saved;
                Button_Save.Enabled = false;
                textBox_ID.Tag = value.AlarmTenantID.ToString();
                txtAdmin.Text = value.AlarmAdmin;
                txtDetail.Text = value.AlarmDetail;
                txtSubject.Text = value.AlarmSubject;
                txtTenantNo.Text = value.T_Tenant.tenantNo.ToString();
                txtTenantNo.Tag = value.T_Tenant.tenantID.ToString();
                txtTenantName.Text = ((LangArEn == 0) ? value.T_Tenant.NameA : value.T_Tenant.NameE);
                try
                {
                    if (VarGeneral.CheckDate(value.AlarmDateG))
                    {
                        txtGDate.Text = Convert.ToDateTime(value.AlarmDateG).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        txtGDate.Text = "";
                    }
                }
                catch
                {
                    txtGDate.Text = "";
                }
                try
                {
                    if (VarGeneral.CheckDate(value.AlarmDateH))
                    {
                        txtHDate.Text = Convert.ToDateTime(value.AlarmDateH).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        txtHDate.Text = "";
                    }
                }
                catch
                {
                    txtHDate.Text = "";
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SetData:", error, enable: true);
                MessageBox.Show(error.Message);
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
        private T_AlarmTenant GetData()
        {
            textBox_ID.Focus();
            data_this.AlarmTenantNo = int.Parse(textBox_ID.Text);
            data_this.AlarmAdmin = txtAdmin.Text;
            data_this.AlarmDetail = txtDetail.Text;
            data_this.AlarmSubject = txtSubject.Text;
            data_this.tenant_ID = int.Parse(txtTenantNo.Tag.ToString());
            try
            {
                if (VarGeneral.CheckDate(txtGDate.Text))
                {
                    data_this.AlarmDateG = txtGDate.Text;
                }
                else
                {
                    data_this.AlarmDateG = "";
                }
            }
            catch
            {
                data_this.AlarmDateG = "";
            }
            try
            {
                if (VarGeneral.CheckDate(txtHDate.Text))
                {
                    data_this.AlarmDateH = txtHDate.Text;
                }
                else
                {
                    data_this.AlarmDateH = "";
                }
            }
            catch
            {
                data_this.AlarmDateH = "";
            }
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
            else if (State != FormState.Edit || MessageBox.Show((LangArEn == 0) ? "تم تعديل السجل الحالي دون حفظ التغييرات .. هل تريد المتابعة؟" : "Not saved the changes, do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Clear();
                int id = db.MaxAlarmTenantNo;
                textBox_ID.Text = id.ToString();
                State = FormState.New;
                txtGDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                txtHDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                try
                {
                    txtAdmin.Text = ((LangArEn == 0) ? VarGeneral.UserNameA : VarGeneral.UserNameE);
                }
                catch
                {
                }
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
                MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ بدون رقم الإشعار" : "Can not save without the Number", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_ID.Focus();
                return false;
            }
            if (txtSubject.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الإسم الموضوع" : "Can not be subject is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtSubject.Focus();
                return false;
            }
            try
            {
#pragma warning disable CS0252 // Possible unintended reference comparison; to get a value comparison, cast the left hand side to type 'string'
                if (txtTenantNo.Text == "" || txtTenantNo.Tag == "")
#pragma warning restore CS0252 // Possible unintended reference comparison; to get a value comparison, cast the left hand side to type 'string'
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ بدون رقم حساب المستأجر" : "Can not be Tenant No is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtTenantNo.Focus();
                    return false;
                }
            }
            catch
            {
                return false;
            }
            if (!VarGeneral.CheckDate(txtGDate.Text))
            {
                txtGDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
            }
            if (!VarGeneral.CheckDate(txtHDate.Text))
            {
                txtHDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
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
                textBox_ID.Focus();
                GetData();
                if (State == FormState.New)
                {
                    try
                    {
                        db.T_AlarmTenants.InsertOnSubmit(data_this);
                        db.SubmitChanges();
                    }
                    catch (SqlException ex3)
                    {
                        if (ex3.Number != 2627)
                        {
                            return;
                        }
                        MessageBox.Show("الرقم مستخدم من قبل.\n سيتم الحفظ برقم جديد ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        int id = db.MaxAlarmTenantNo;
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
                TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(string.Concat(data_this.AlarmTenantNo)) + 1);
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
            data_this = db.StockAlarmTenant(DataThis.AlarmTenantNo);
            try
            {
                db.T_AlarmTenants.DeleteOnSubmit(DataThis);
                db.SubmitChanges();
            }
            catch (SqlException)
            {
                data_this = db.StockAlarmTenant(DataThis.AlarmTenantNo);
                return;
            }
            catch (Exception)
            {
                data_this = db.StockAlarmTenant(DataThis.AlarmTenantNo);
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
            if (dataMember != null && dataMember == "T_AlarmTenant")
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
            panel.Columns["AlarmTenantNo"].Width = 120;
            panel.Columns["AlarmTenantNo"].Visible = columns_Names_visible["AlarmTenantNo"].IfDefault;
            panel.Columns["AlarmSubject"].Width = 200;
            panel.Columns["AlarmSubject"].Visible = columns_Names_visible["AlarmSubject"].IfDefault;
            panel.Columns["AlarmAdmin"].Width = 200;
            panel.Columns["AlarmAdmin"].Visible = columns_Names_visible["AlarmAdmin"].IfDefault;
            panel.Columns["AlarmDateG"].Width = 100;
            panel.Columns["AlarmDateG"].Visible = columns_Names_visible["AlarmDateG"].IfDefault;
            panel.Columns["AlarmDateH"].Width = 100;
            panel.Columns["AlarmDateH"].Visible = columns_Names_visible["AlarmDateH"].IfDefault;
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
                ExportExcel.ExportToExcel(DGV_Main, "تقرير الإشعارات");
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
                controls.Add(txtAdmin);
                controls.Add(txtDetail);
                controls.Add(txtGDate);
                controls.Add(txtHDate);
                controls.Add(txtSubject);
                controls.Add(txtTenantName);
                controls.Add(txtTenantNo);
            }
            catch (SqlException)
            {
            }
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
            try
            {
                if (!(textBox_ID.Text != "") || State != 0)
                {
                    return;
                }
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_AlarmTenant INNER JOIN T_Tenant ON T_AlarmTenant.tenant_ID = T_Tenant.tenantID ";
                string Fields = " T_AlarmTenant.*, T_Tenant.tenantNo, T_Tenant.NameA, T_Tenant.NameE, T_Tenant.AccNo ,(select T_SYSSETTING.LogImg from T_SYSSETTING) as LogImg";
                _RepShow.Rule = " where AlarmTenantNo = " + textBox_ID.Text;
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
                        frm.Repvalue = "RepAlarmTenant";
                        frm.Repvalue = "RepGeneral";
                        frm.Tag = LangArEn;
                        frm.Repvalue = "RepAlarmTenant";
                        VarGeneral.vTitle = ((LangArEn == 0) ? "إشعــــار" : "Notice");
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
        public void Button_PrintTable_Click(object sender, EventArgs e)
        {
            if (ViewState != 0)
            {
                return;
            }
            try
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_AlarmTenant INNER JOIN T_Tenant ON T_AlarmTenant.tenant_ID = T_Tenant.tenantID  ";
                string Fields = "";
                Fields = " T_AlarmTenant.AlarmTenantID , T_AlarmTenant.AlarmTenantNo as No , T_Tenant.NameA as NmA, T_Tenant.NameE as NmE ,(select T_SYSSETTING.LogImg from T_SYSSETTING) as LogImg";
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
                        frm.Repvalue = "RepAlarmTenant";
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
        private void textBox_ID_Click(object sender, EventArgs e)
        {
            textBox_ID.SelectAll();
        }
        private void txtHDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtHDate.Text))
                {
                    txtHDate.Text = Convert.ToDateTime(txtHDate.Text).ToString("yyyy/MM/dd");
                    txtHDate.Text = n.FormatHijri(txtHDate.Text, "yyyy/MM/dd");
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 77))
                    {
                        txtGDate.Text = n.HijriToGreg(txtHDate.Text, "yyyy/MM/dd");
                    }
                }
                else
                {
                    txtHDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                }
            }
            catch
            {
                txtHDate.Text = "";
            }
        }
        private void txtGDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtGDate.Text))
                {
                    txtGDate.Text = Convert.ToDateTime(txtGDate.Text).ToString("yyyy/MM/dd");
                    txtGDate.Text = n.FormatGreg(txtGDate.Text, "yyyy/MM/dd");
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 77))
                    {
                        txtHDate.Text = n.GregToHijri(txtGDate.Text, "yyyy/MM/dd");
                    }
                }
                else
                {
                    txtGDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                }
            }
            catch
            {
                txtGDate.Text = "";
            }
        }
        private void txtGDate_Click(object sender, EventArgs e)
        {
            txtGDate.SelectAll();
        }
        private void txtHDate_Click(object sender, EventArgs e)
        {
            txtHDate.SelectAll();
        }
        private void txtAdmin_Click(object sender, EventArgs e)
        {
            txtAdmin.SelectAll();
        }
        private void txtSubject_Click(object sender, EventArgs e)
        {
            txtSubject.SelectAll();
        }
        private void button_SrchTenantNo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            Button_Edit_Click(sender, e);
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("tenantNo", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
            columns_Names_visible2.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible2.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_Tenant";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != "")
                {
                    T_Tenant _tenant = db.StockTenantData(int.Parse(frm.Serach_No));
                    txtTenantNo.Text = _tenant.tenantNo.ToString();
                    txtTenantNo.Tag = _tenant.tenantID.ToString();
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtTenantName.Text = _tenant.NameA;
                    }
                    else
                    {
                        txtTenantName.Text = _tenant.NameE;
                    }
                }
                else
                {
                    txtTenantNo.Text = "";
                    txtTenantName.Text = "";
                    txtTenantNo.Tag = "";
                }
            }
            catch
            {
                txtTenantNo.Text = "";
                txtTenantName.Text = "";
                txtTenantNo.Tag = "";
            }
        }

        private void ribbonBar1_ItemClick(object sender, EventArgs e)
        {

        }

        private void Button_Search_Click_1(object sender, EventArgs e)
        {

        }
    }
}
