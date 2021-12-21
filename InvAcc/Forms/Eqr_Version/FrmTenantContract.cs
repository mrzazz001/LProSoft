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
using Microsoft.Office.Interop.Word;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ProShared;

namespace InvAcc.Forms
{
    public partial class FrmTenantContract : Form
    { void avs(int arln)

{ 
}
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
        private IContainer components = null;
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
        private Label label19;
        private Label label4;
        private Label label2;
        private Label label1;
        private C1BarCode c1BarCode1;
        private ButtonX button_SrchEqarADD;
        private ButtonX button_SrchEqarNo;
        private DoubleInput txtRentOfYear;
        private MaskedTextBox txtContractStart;
        internal TextBox txtEqarName;
        private TextBox txtEqarNo;
        private LabelItem lable_Records;
        internal Label label22;
        private TextBox txtAinNo;
        private ButtonX button_SrchAinNo;
        private Label label3;
        private MaskedTextBox txtContractEnd;
        private Label label7;
        private TextBox txtAinTyp;
        public TextBox txtTenantName;
        public TextBox txtTenantNo;
        public ButtonItem Button_Payment;
        public ButtonItem Button_Renwal;
        public TextBox textBox_ID;
        public ButtonItem Button_ShowContract;
        public ButtonItem Button_DelContract;
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
        private ScriptNumber ScriptNumber1 = new ScriptNumber();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private T_AccDef _AccDefBind = new T_AccDef();
        private int LangArEn = 0;
        public int ProcessTyp = 0;
        public string TenantNo_ = "";
        public string TenantNm_ = "";
        public string TenantID_ = "1";
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
#pragma warning disable CS0414 // The field 'FrmTenantContract.FlagUpdate' is assigned but its value is never used
        private string FlagUpdate = "";
#pragma warning restore CS0414 // The field 'FrmTenantContract.FlagUpdate' is assigned but its value is never used
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
        private T_TenantContract data_this;
        private Stock_DataDataContext dbInstance;
        private List<string> pkeys = new List<string>();
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
        public int _ContractNo;
        private T_TenantContract oldData = new T_TenantContract();
        private bool IsNew = false;
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
        public T_TenantContract DataThis
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
                Button_Renwal.Enabled = value;
                Button_Payment.Enabled = value;
                Button_ShowContract.Enabled = value;
                Button_DelContract.Enabled = value;
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
                }
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
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
                SetReadOnly = true;
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
        public void RefreshPKeys()
        {
            PKeys.Clear();
            var qkeys = from item in db.T_TenantContracts
                        orderby item.ContractNo
                        select new
                        {
                            Code = item.ContractNo + ""
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
        public FrmTenantContract()
        {
            InitializeComponent();this.Load += langloads;
            txtAinNo.Click += Button_Edit_Click;
            txtContractEnd.Click += Button_Edit_Click;
            txtContractStart.Click += Button_Edit_Click;
            txtEqarNo.Click += Button_Edit_Click;
            txtRentOfYear.Click += Button_Edit_Click;
            txtTenantName.Click += Button_Edit_Click;
            txtTenantNo.Click += Button_Edit_Click;
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
            Button_Save.Click += Button_Save_Click;
            TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
            Button_PrintTable.Click += Button_Print_Click;
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
            List<T_TenantContract> list = db.FillTenantContractData_2(textBox_search.TextBox.Text).ToList();
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
        }
        public void FillHDGV(IEnumerable<T_TenantContract> new_data_enum)
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
            DGV_Main.PrimaryGrid.DataMember = "T_TenantContract";
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmTenantContract));
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
                Button_Renwal.Text = "تجديد العقد";
                Button_Save.Text = "حفظ";
                Button_Payment.Text = "الدفعات";
                Button_ShowContract.Text = "عرض العقد";
                Button_DelContract.Text = "حذف العقد";
                Button_First.Tooltip = "السجل الاول";
                Button_Last.Tooltip = "السجل الاخير";
                Button_Next.Tooltip = "السجل التالي";
                Button_Prev.Tooltip = "السجل السابق";
                Button_PrintTable.Tooltip = "F5";
                Button_ExportTable2.Text = "تصدير";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "جميع السجلات";
                Text = "كرت العقــــود";
            }
            else
            {
                Button_First.Text = "First";
                Button_Last.Text = "Last";
                Button_Next.Text = "Next";
                Button_Prev.Text = "Previous";
                Button_Add.Text = "New";
                Button_Close.Text = "Close";
                Button_Save.Text = "Save";
                Button_Renwal.Text = "contract renewal";
                Button_Payment.Text = "Payments";
                Button_ShowContract.Text = "Contract";
                Button_DelContract.Text = "Delete Contract";
                Button_First.Tooltip = "First Record";
                Button_Last.Tooltip = "Last Record";
                Button_Next.Tooltip = "Next Record";
                Button_Prev.Tooltip = "Previous Record";
                Button_PrintTable.Tooltip = "F5";
                Button_ExportTable2.Text = "Export";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "All Records";
                Text = "Contracts Card";
            }
        }
        private void FrmTenantContract_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmTenantContract));
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
                    columns_Names_visible.Add("ContractNo", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
                }
                else
                {
                    Clear();
                    textBox_ID.Text = "";
                    TextBox_Index.TextBox.Text = "";
                }
                RefreshPKeys();
                RibunButtons();
                ViewDetails_Click(sender, e);
                if (ProcessTyp == 0)
                {
                    Button_Add_Click(sender, e);
                    txtTenantNo.Text = TenantNo_;
                    txtTenantNo.Tag = TenantID_;
                    txtTenantName.Text = TenantNm_;
                }
                else
                {
                    textBox_ID.Text = _ContractNo.ToString();
                    SetReadOnly = true;
                }
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
                 T_TenantContract newData = db.StockTenantContractData(no, int.Parse(TenantID_));
                if (newData == null || newData.ContractNo == 0)
                {
                    Clear();
                    TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                    TextBox_Index.TextBox.Text = string.Concat(PKeys.Count + 1);
                    TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                }
                else
                {
                    DataThis = newData;
                    int indexA = PKeys.IndexOf(string.Concat(newData.ContractNo));
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
            data_this = new T_TenantContract();
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
                else if (controls[i].GetType() == typeof(System.Windows.Forms.CheckBox))
                {
                    (controls[i] as System.Windows.Forms.CheckBox).Checked = false;
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
                    else if (controls[i].GetType() == typeof(System.Windows.Forms.CheckBox))
                    {
                        (controls[i] as System.Windows.Forms.CheckBox).Checked = false;
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
        public void SetData(T_TenantContract value)
        {
            try
            {
                State = FormState.Saved;
                Button_Save.Enabled = false;
                textBox_ID.Tag = value.ContractID.ToString();
                try
                {
                    if (!string.IsNullOrEmpty(value.Ain_ID.ToString()))
                    {
                        txtAinNo.Text = value.T_AinsData.AinNo;
                        txtAinNo.Tag = value.T_AinsData.AinID;
                        txtAinTyp.Text = ((LangArEn == 0) ? data_this.T_AinsData.T_AinTyp.NameA : data_this.T_AinsData.T_AinTyp.NameE);
                    }
                }
                catch
                {
                }
                try
                {
                    if (VarGeneral.CheckDate(value.ContractEnd))
                    {
                        txtContractEnd.Text = value.ContractEnd;
                    }
                    else
                    {
                        txtContractEnd.Text = "";
                    }
                }
                catch
                {
                    txtContractEnd.Text = "";
                }
                try
                {
                    if (VarGeneral.CheckDate(value.ContractStart))
                    {
                        txtContractStart.Text = value.ContractStart;
                    }
                    else
                    {
                        txtContractStart.Text = "";
                    }
                }
                catch
                {
                    txtContractStart.Text = "";
                }
                txtEqarName.Text = ((LangArEn == 0) ? value.T_EqarsData.NameA : value.T_EqarsData.NameE);
                txtEqarNo.Text = value.T_EqarsData.EqarNo.ToString();
                txtEqarNo.Tag = value.T_EqarsData.EqarID;
                txtRentOfYear.Value = value.RentOfYear.Value;
                txtTenantName.Text = ((LangArEn == 0) ? value.T_Tenant.NameA : value.T_Tenant.NameE);
                txtTenantNo.Text = value.T_Tenant.tenantNo.ToString();
                txtTenantNo.Tag = value.T_Tenant.tenantID;
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
        private T_TenantContract GetData()
        {
            textBox_ID.Focus();
            data_this.ContractNo = int.Parse(textBox_ID.Text);
            if (!string.IsNullOrEmpty(txtAinNo.Text))
            {
                data_this.Ain_ID = int.Parse(txtAinNo.Tag.ToString());
            }
            else
            {
                data_this.Ain_ID = null;
            }
            try
            {
                if (VarGeneral.CheckDate(txtContractEnd.Text))
                {
                    data_this.ContractEnd = txtContractEnd.Text;
                }
                else
                {
                    data_this.ContractEnd = "";
                }
            }
            catch
            {
                data_this.ContractEnd = "";
            }
            try
            {
                if (VarGeneral.CheckDate(txtContractStart.Text))
                {
                    data_this.ContractStart = txtContractStart.Text;
                }
                else
                {
                    data_this.ContractStart = "";
                }
            }
            catch
            {
                data_this.ContractStart = "";
            }
            data_this.Eqar_ID = int.Parse(txtEqarNo.Tag.ToString());
            data_this.RentOfYear = txtRentOfYear.Value;
            data_this.tenant_ID = int.Parse(TenantID_);
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
            if (State == FormState.Edit && MessageBox.Show((LangArEn == 0) ? "تم تعديل السجل الحالي دون حفظ التغييرات .. هل تريد المتابعة؟" : "Not saved the changes, do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
            {
                return;
            }
            Clear();
            int tt = 1;
            try
            {
                List<T_TenantContract> Quary = (from er in db.T_TenantContracts
                                                where er.tenant_ID == int.Parse(TenantID_)
                                                orderby er.ContractNo
                                                select er).ToList();
                if (Quary.Count() > 0)
                {
                    tt = Quary.Max().ContractNo + 1;
                }
            }
            catch
            {
                tt = 1;
            }
            textBox_ID.Text = tt.ToString();
            State = FormState.New;
            try
            {
                txtContractStart.Text = ((VarGeneral.Settings_Sys.Calendr.Value == 0) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
                txtContractEnd.Focus();
            }
            catch
            {
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
            if (textBox_ID.Text == "0" || textBox_ID.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ بدون رقم العقد" : "Can not save without the Contract No", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_ID.Focus();
                return false;
            }
            if (txtEqarNo.Text == "" || string.IsNullOrEmpty(txtEqarNo.Tag.ToString()))
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ بدون رقم العقار" : "Can not save without the Number", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtEqarNo.Focus();
                return false;
            }
            if (!VarGeneral.CheckDate(txtContractStart.Text))
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون التاريخ فارغا\u0651" : "Can not be Date is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtContractStart.Focus();
                return false;
            }
            if (!VarGeneral.CheckDate(txtContractEnd.Text))
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون التاريخ فارغا\u0651" : "Can not be Date is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtContractEnd.Focus();
                return false;
            }
            if (txtTenantNo.Text == "" || string.IsNullOrEmpty(txtTenantNo.Tag.ToString()))
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون رقم المستأجر فارغا\u0651" : "Can not be Tenant No is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtEqarNo.Focus();
                return false;
            }
            if (txtAinNo.Text == "")
            {
                T_EqarsData q = db.StockEqarData(int.Parse(txtEqarNo.Tag.ToString()));
                for (int i = 0; i < q.T_AinsDatas.Count; i++)
                {
                    try
                    {
                        if (q.T_AinsDatas[i].AinStatus.Value > 0)
                        {
                            MessageBox.Show((LangArEn == 0) ? "لا يمكنك استخدام هذا العقار بالكامل لانه يحتوي على عقد او اكثر لاحد عيونه" : "You cannot use this property entirely", VarGeneral.ProdectNam);
                            return false;
                        }
                    }
                    catch
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكنك استخدام هذا العقار بالكامل لانه يحتوي على عقد او اكثر لاحد عيونه" : "You cannot use this property entirely", VarGeneral.ProdectNam);
                        return false;
                    }
                }
            }
            return true;
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
        private void Button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidData())
                {
                    return;
                }
                if (State == FormState.New)
                {
                    GetData();
                    try
                    {
                        data_this.RentOfYearPayment = txtRentOfYear.Value;
                        data_this.PayMethod = 0;
                        db.T_TenantContracts.InsertOnSubmit(data_this);
                        db.SubmitChanges();
                    }
                    catch (SqlException ex)
                    {
                        int max = 1;
                        try
                        {
                            List<T_TenantContract> Quary = (from er in db.T_TenantContracts
                                                            where er.tenant_ID == int.Parse(TenantID_)
                                                            orderby er.ContractNo
                                                            select er).ToList();
                            if (Quary.Count() > 0)
                            {
                                max = Quary.Max().ContractNo + 1;
                            }
                        }
                        catch
                        {
                            max = 1;
                        }
                        if (ex.Number != 2627)
                        {
                            return;
                        }
                        MessageBox.Show("الرقم مستخدم من قبل.\n سيتم الحفظ برقم جديد [" + max + "]", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question);
                        textBox_ID.Text = string.Concat(max);
                        data_this.ContractNo = max;
                        Button_Save_Click(sender, e);
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
                else 
                
                if (State == FormState.Edit)
                {
                    oldData = new T_TenantContract();
                    oldData = data_this;
                    if (data_this.Ain_ID.HasValue)
                    {
                        Eqar_Ain_StatusControl(1, 0, data_this);
                    }
                    else
                    {
                        Eqar_Ain_StatusControl(0, 0, data_this);
                    }
                    GetData();
                    try
                    {
                        db.Log = VarGeneral.DebugLog;
                        db.SubmitChanges(ConflictMode.ContinueOnConflict);
                    }
                    catch (Exception)
                    {
                        if (!string.IsNullOrEmpty(oldData.Ain_ID.Value.ToString()))
                        {
                            Eqar_Ain_StatusControl(1, 1, oldData);
                        }
                        else
                        {
                            Eqar_Ain_StatusControl(0, 1, oldData);
                        }
                        return;
                    }
                }
                if (data_this.Ain_ID.HasValue)
                {
                    Eqar_Ain_StatusControl(1, 1, data_this);
                }
                else
                {
                    Eqar_Ain_StatusControl(0, 1, data_this);
                }
                MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                State = FormState.Saved;
                RefreshPKeys();
                TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(string.Concat(data_this.ContractNo)) + 1);
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
        private void DGV_Main_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            string dataMember = panel.DataMember;
            if (dataMember != null && dataMember == "T_TenantContract")
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
            panel.Columns["ContractNo"].Width = 120;
            panel.Columns["ContractNo"].Visible = columns_Names_visible["ContractNo"].IfDefault;
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
                ExportExcel.ExportToExcel(DGV_Main, "تقرير العقــود");
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
                controls.Add(txtAinNo);
                controls.Add(txtAinTyp);
                controls.Add(txtContractEnd);
                controls.Add(txtContractStart);
                controls.Add(txtEqarName);
                controls.Add(txtEqarNo);
                controls.Add(txtRentOfYear);
                controls.Add(txtTenantName);
                controls.Add(txtTenantNo);
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
                _RepShow.Tables = " T_TenantContract  ";
                string Fields = "";
                Fields = " T_TenantContract.EqarID , T_TenantContract.ContractNo as No , T_TenantContract.NameA as NmA, T_TenantContract.NameE as NmE ,(select T_SYSSETTING.LogImg from T_SYSSETTING) as LogImg";
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
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Tag = LangArEn;
                        frm.Repvalue = "RepGeneral";
                        VarGeneral.vTitle = Text;
                        frm.TopMost = true;
                        frm.ShowDialog();
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
        private void button_SrchOwnerADD_Click(object sender, EventArgs e)
        {
            FrmEqars frm = new FrmEqars();
            frm.Tag = LangArEn;
            frm.TopMost = true;
            frm.ShowDialog();
        }
        private void button_SrchEqarNo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            Button_Edit_Click(sender, e);
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("EqarNo", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
            columns_Names_visible2.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible2.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            columns_Names_visible2.Add("ContractValue", new ColumnDictinary("قيمة العقار", "Property value", ifDefault: true, ""));
            columns_Names_visible2.Add("ContractRentValue", new ColumnDictinary("إيجار العقار", "Rent the property", ifDefault: false, ""));
            columns_Names_visible2.Add("FloorsCount", new ColumnDictinary("عدد الطوابق", "Floors Count", ifDefault: false, ""));
            columns_Names_visible2.Add("EyesCount", new ColumnDictinary("عدد العيون", "Eyes Count", ifDefault: false, ""));
            columns_Names_visible2.Add("Space", new ColumnDictinary("مساحة العقار", "Space", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_EqarsDataSale";
            VarGeneral.EqarSaleWhere = "";
            try
            {
                if (State == FormState.Edit)
                {
                    if (!string.IsNullOrEmpty(data_this.Eqar_ID.ToString()))
                    {
                        VarGeneral.EqarSaleWhere = " or EqarID = " + data_this.Eqar_ID;
                    }
                    else
                    {
                        VarGeneral.EqarSaleWhere = "";
                    }
                }
            }
            catch
            {
                VarGeneral.EqarSaleWhere = "";
            }
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != "")
                {
                    T_EqarsData _Eqar = db.EqarsDataEmp(int.Parse(frm.Serach_No));
                    txtEqarNo.Text = frm.Serach_No;
                    txtEqarNo.Tag = _Eqar.EqarID;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtEqarName.Text = _Eqar.NameA;
                    }
                    else
                    {
                        txtEqarName.Text = _Eqar.NameE;
                    }
                }
                else
                {
                    txtEqarNo.Text = "";
                    txtEqarName.Text = "";
                    txtEqarNo.Tag = "";
                }
            }
            catch
            {
                txtEqarNo.Text = "";
                txtEqarName.Text = "";
                txtEqarNo.Tag = "";
            }
        }
        private void txtContractStart_Click(object sender, EventArgs e)
        {
            txtContractStart.SelectAll();
        }
        private void txtContractStart_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtContractStart.Text))
                {
                    txtContractStart.Text = Convert.ToDateTime(txtContractStart.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    txtContractStart.Text = "";
                }
            }
            catch
            {
                txtContractStart.Text = "";
            }
        }
        private void txtContractEnd_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtContractEnd.Text))
                {
                    txtContractEnd.Text = Convert.ToDateTime(txtContractEnd.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    txtContractEnd.Text = "";
                }
            }
            catch
            {
                txtContractEnd.Text = "";
            }
        }
        private void txtContractEnd_Click(object sender, EventArgs e)
        {
            txtContractEnd.SelectAll();
        }
        private void button_SrchAinNo_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox_ID.Text) || string.IsNullOrEmpty(txtEqarNo.Text) || string.IsNullOrEmpty(txtEqarNo.Tag.ToString()))
                {
                    return;
                }
                Button_Edit_Click(sender, e);
                columns_Names_visible2.Clear();
                columns_Names_visible2.Add("AinNo", new ColumnDictinary("رقم العين", "Eye No", ifDefault: true, ""));
                columns_Names_visible2.Add("EqarNo", new ColumnDictinary("رقم العقار", "Real Estate No", ifDefault: true, ""));
                columns_Names_visible2.Add("NameA", new ColumnDictinary("اسم العقار -عربي", "Real Estate Name A", ifDefault: true, ""));
                columns_Names_visible2.Add("NameE", new ColumnDictinary("اسم العقار -انجليزي", "Real Estate Name E", ifDefault: false, ""));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                }
                VarGeneral.SFrmTyp = "T_AinsDataSale";
                VarGeneral.EqarSaleWhere = "";
                try
                {
                    if (State == FormState.Edit)
                    {
                        if (!string.IsNullOrEmpty(data_this.Ain_ID.ToString()))
                        {
                            VarGeneral.EqarSaleWhere = " or T_AinsData.AinID = " + data_this.Ain_ID + ") ";
                        }
                        else
                        {
                            VarGeneral.EqarSaleWhere = "";
                        }
                    }
                }
                catch
                {
                    VarGeneral.EqarSaleWhere = "";
                }
                if (string.IsNullOrEmpty(VarGeneral.EqarSaleWhere))
                {
                    VarGeneral.EqarSaleWhere = " )";
                }
                VarGeneral.EqarSaleWhere = VarGeneral.EqarSaleWhere + " and T_AinsData.EqarID = " + txtEqarNo.Tag.ToString();
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    T_AinsData _Ain = db.AinsDataDataNo(frm.Serach_No, int.Parse(txtEqarNo.Tag.ToString()));
                    txtAinNo.Text = frm.Serach_No;
                    txtAinNo.Tag = _Ain.AinID;
                    txtAinTyp.Text = ((LangArEn == 0) ? _Ain.T_AinTyp.NameA : _Ain.T_AinTyp.NameE);
                }
                else
                {
                    txtAinNo.Text = "";
                    txtAinNo.Tag = "";
                    txtAinTyp.Text = "";
                }
            }
            catch
            {
                txtAinNo.Text = "";
                txtAinNo.Tag = "";
                txtAinTyp.Text = "";
            }
        }
        private void Button_Renwal_Click(object sender, EventArgs e)
        {
            if (VarGeneral.CheckDate(txtContractEnd.Text))
            {
                txtContractStart.Text = txtContractEnd.Text;
                txtContractEnd.Text = "";
                txtContractEnd.Focus();
                Button_Edit_Click(sender, e);
            }
        }
        private void Button_Payment_Click(object sender, EventArgs e)
        {
            if (State == FormState.Saved)
            {
                FrmTenantPayment frm = new FrmTenantPayment();
                frm.Tag = LangArEn;
                frm.data_this = data_this;
                frm.TopMost = true;
                frm.ShowDialog();
                dbInstance = null;
                textBox_ID_TextChanged(sender, e);
            }
        }
        private void Button_ShowContract_Click(object sender, EventArgs e)
        {
            if (State != 0)
            {
                return;
            }
            if (VarGeneral.vDemo && VarGeneral.UserID != 1)
            {
                MessageBox.Show((LangArEn == 0) ? "يرجى تفعيل المنتج للاستفادة من جميع مميزات النظام \n  لا تستطيع استخدام هذه الميزة لان النسخة الحالية تجريبية..  " : "Please activate the product to take advantage of all system features \n You can not use this feature because the current version is experimental ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly);
                return;
            }
            IsNew = false;
            string vPth = System.Windows.Forms.Application.StartupPath + "\\ContractRent\\Contract" + textBox_ID.Text + ".doc";
            if (!File.Exists(vPth))
            {
                string DefPath = System.Windows.Forms.Application.StartupPath + "\\Contract.doc";
                File.Copy(DefPath, vPth, overwrite: true);
                IsNew = true;
            }
            object path_YourDocsName = vPth;
            object o = Missing.Value;
            object oFalse = false;
            object oTrue = true;
            _Application app = null;
            Documents docs = null;
            Document doc = null;
            app = new ApplicationClass();
            app.Visible = false;
            app.DisplayAlerts = WdAlertLevel.wdAlertsNone;
            docs = app.Documents;
            doc = docs.Open(ref path_YourDocsName, ref o, ref o, ref o, ref o, ref o, ref o, ref o, ref o, ref o, ref o, ref o, ref o, ref o, ref o, ref o);
            doc.Activate();
            if (IsNew)
            {
                foreach (Range range in doc.StoryRanges)
                {
                    Find find1 = range.Find;
                    object findText1 = "<CRentNo>";
                    object replacText1 = textBox_ID.Text;
                    object replace1 = WdReplace.wdReplaceAll;
                    object findWrap1 = WdFindWrap.wdFindContinue;
                    find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                    Marshal.FinalReleaseComObject(find1);
                    try
                    {
                        find1 = range.Find;
                        findText1 = "<HDat>";
                        replacText1 = VarGeneral.Hdate;
                        replace1 = WdReplace.wdReplaceAll;
                        findWrap1 = WdFindWrap.wdFindContinue;
                        find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                        Marshal.FinalReleaseComObject(find1);
                    }
                    catch
                    {
                    }
                    try
                    {
                        find1 = range.Find;
                        findText1 = "<GDat>";
                        replacText1 = VarGeneral.Gdate;
                        replace1 = WdReplace.wdReplaceAll;
                        findWrap1 = WdFindWrap.wdFindContinue;
                        find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                        Marshal.FinalReleaseComObject(find1);
                    }
                    catch
                    {
                    }
                    try
                    {
                        find1 = range.Find;
                        findText1 = "<OwnerNam>";
                        replacText1 = ((LangArEn == 0) ? data_this.T_EqarsData.T_Owner.NameA : data_this.T_EqarsData.T_Owner.NameE);
                        replace1 = WdReplace.wdReplaceAll;
                        findWrap1 = WdFindWrap.wdFindContinue;
                        find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                        Marshal.FinalReleaseComObject(find1);
                    }
                    catch
                    {
                    }
                    try
                    {
                        find1 = range.Find;
                        findText1 = "<RentNam>";
                        replacText1 = ((LangArEn == 0) ? data_this.T_Tenant.NameA : data_this.T_Tenant.NameE);
                        replace1 = WdReplace.wdReplaceAll;
                        findWrap1 = WdFindWrap.wdFindContinue;
                        find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                        Marshal.FinalReleaseComObject(find1);
                    }
                    catch
                    {
                    }
                    try
                    {
                        find1 = range.Find;
                        findText1 = "<Nat>";
                        replacText1 = ((LangArEn == 0) ? data_this.T_Tenant.T_Nationality.NameA : data_this.T_Tenant.T_Nationality.NameE);
                        replace1 = WdReplace.wdReplaceAll;
                        findWrap1 = WdFindWrap.wdFindContinue;
                        find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                        Marshal.FinalReleaseComObject(find1);
                    }
                    catch
                    {
                    }
                    try
                    {
                        find1 = range.Find;
                        findText1 = "<IdNo>";
                        replacText1 = data_this.T_Tenant.IDNo;
                        replace1 = WdReplace.wdReplaceAll;
                        findWrap1 = WdFindWrap.wdFindContinue;
                        find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                        Marshal.FinalReleaseComObject(find1);
                    }
                    catch
                    {
                    }
                    try
                    {
                        find1 = range.Find;
                        findText1 = "<IdNoSorc>";
                        replacText1 = data_this.T_Tenant.IDSource;
                        replace1 = WdReplace.wdReplaceAll;
                        findWrap1 = WdFindWrap.wdFindContinue;
                        find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                        Marshal.FinalReleaseComObject(find1);
                    }
                    catch
                    {
                    }
                    try
                    {
                        find1 = range.Find;
                        findText1 = "<IdNoDate>";
                        replacText1 = data_this.T_Tenant.IDDate;
                        replace1 = WdReplace.wdReplaceAll;
                        findWrap1 = WdFindWrap.wdFindContinue;
                        find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                        Marshal.FinalReleaseComObject(find1);
                    }
                    catch
                    {
                    }
                    try
                    {
                        find1 = range.Find;
                        findText1 = "<EyeTyp>";
                        replacText1 = ((LangArEn == 0) ? data_this.T_EqarsData.T_AinsDatas.Where((T_AinsData g) => g.AinID == data_this.T_AinsData.AinID).FirstOrDefault().T_AinTyp.NameA : data_this.T_EqarsData.T_AinsDatas.Where((T_AinsData g) => g.AinID == data_this.T_AinsData.AinID).FirstOrDefault().T_AinTyp.NameE);
                        if (LangArEn == 0 && !replacText1.ToString().StartsWith("ال"))
                        {
                            replacText1 = "ال" + replacText1;
                        }
                        replace1 = WdReplace.wdReplaceAll;
                        findWrap1 = WdFindWrap.wdFindContinue;
                        find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                        Marshal.FinalReleaseComObject(find1);
                    }
                    catch
                    {
                    }
                    try
                    {
                        find1 = range.Find;
                        findText1 = "<EyeNo>";
                        replacText1 = data_this.T_EqarsData.T_AinsDatas.Where((T_AinsData g) => g.AinID == data_this.T_AinsData.AinID).FirstOrDefault().AinNo;
                        replace1 = WdReplace.wdReplaceAll;
                        findWrap1 = WdFindWrap.wdFindContinue;
                        find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                        Marshal.FinalReleaseComObject(find1);
                    }
                    catch
                    {
                    }
                    try
                    {
                        find1 = range.Find;
                        findText1 = "<Streat>";
                        replacText1 = data_this.T_EqarsData.Street;
                        replace1 = WdReplace.wdReplaceAll;
                        findWrap1 = WdFindWrap.wdFindContinue;
                        find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                        Marshal.FinalReleaseComObject(find1);
                    }
                    catch
                    {
                    }
                    try
                    {
                        find1 = range.Find;
                        findText1 = "<Dist>";
                        replacText1 = data_this.T_EqarsData.Neighborhood;
                        replace1 = WdReplace.wdReplaceAll;
                        findWrap1 = WdFindWrap.wdFindContinue;
                        find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                        Marshal.FinalReleaseComObject(find1);
                    }
                    catch
                    {
                    }
                    try
                    {
                        find1 = range.Find;
                        findText1 = "<City>";
                        replacText1 = ((LangArEn == 0) ? data_this.T_EqarsData.T_City.NameA : data_this.T_EqarsData.T_City.NameE);
                        replace1 = WdReplace.wdReplaceAll;
                        findWrap1 = WdFindWrap.wdFindContinue;
                        find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                        Marshal.FinalReleaseComObject(find1);
                    }
                    catch
                    {
                    }
                    try
                    {
                        find1 = range.Find;
                        findText1 = "<StrCon>";
                        replacText1 = data_this.ContractStart;
                        replace1 = WdReplace.wdReplaceAll;
                        findWrap1 = WdFindWrap.wdFindContinue;
                        find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                        Marshal.FinalReleaseComObject(find1);
                    }
                    catch
                    {
                    }
                    try
                    {
                        find1 = range.Find;
                        findText1 = "<EndCon>";
                        replacText1 = data_this.ContractEnd;
                        replace1 = WdReplace.wdReplaceAll;
                        findWrap1 = WdFindWrap.wdFindContinue;
                        find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                        Marshal.FinalReleaseComObject(find1);
                    }
                    catch
                    {
                    }
                    try
                    {
                        find1 = range.Find;
                        findText1 = "<YearRent>";
                        replacText1 = data_this.RentOfYear;
                        replace1 = WdReplace.wdReplaceAll;
                        findWrap1 = WdFindWrap.wdFindContinue;
                        find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                        Marshal.FinalReleaseComObject(find1);
                    }
                    catch
                    {
                    }
                    try
                    {
                        find1 = range.Find;
                        findText1 = "<YearRentHr>";
                        replacText1 = ScriptNumber1.ScriptNum(decimal.Parse(VarGeneral.TString.TEmpty(string.Concat(data_this.RentOfYear.Value))));
                        replace1 = WdReplace.wdReplaceAll;
                        findWrap1 = WdFindWrap.wdFindContinue;
                        find1.Execute(ref findText1, ref o, ref o, ref o, ref oFalse, ref o, ref o, ref findWrap1, ref o, ref replacText1, ref replace1, ref o, ref o, ref o, ref o);
                        Marshal.FinalReleaseComObject(find1);
                    }
                    catch
                    {
                    }
                }
            }
            try
            {
                doc.Save();
            }
            catch
            {
            }
            app.Visible = true;
            try
            {
                Window window = app.ActiveWindow;
                window.SetFocus();
                window.Activate();
                if (window != null)
                {
                    Marshal.ReleaseComObject(window);
                }
            }
            catch
            {
            }
            doc = null;
            app = null;
            try
            {
                for (int i = System.Windows.Forms.Application.OpenForms.Count - 1; i >= 0; i--)
                {
                    if (System.Windows.Forms.Application.OpenForms[i].Name != "FrmMn")
                    {
                        System.Windows.Forms.Application.OpenForms[i].Close();
                    }
                }
            }
            catch
            {
            }
        }
        private void Button_DelContract_Click(object sender, EventArgs e)
        {
            if (State != 0)
            {
                return;
            }
            string vPth = System.Windows.Forms.Application.StartupPath + "\\ContractRent\\Contract" + textBox_ID.Text + ".doc";
            if (File.Exists(vPth) && MessageBox.Show("هل أنت متاكد من حذف العقد رقم [" + textBox_ID.Text + "]؟ \n Are you sure that you want to delete the Contract No [" + textBox_ID.Text + "]?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
            {
                try
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    File.Delete(vPth);
                    MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch
                {
                }
            }
        }

        private void ribbonBar1_ItemClick(object sender, EventArgs e)
        {

        }

        private void Button_Save_Click_1(object sender, EventArgs e)
        {

        }
    }
}
