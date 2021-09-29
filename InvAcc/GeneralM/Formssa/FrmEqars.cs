using C1.Win.C1BarCode;
using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
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
    public partial class FrmEqars : Form
    {
        public class ColumnDictinary
        {
            public string AText = string.Empty;
            public string EText = string.Empty;
            public bool IfDefault = false;
            public string Format = string.Empty;
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
        private string FlagUpdate = string.Empty;
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
        private T_EqarsData data_this;
        private List<T_AinsData> LData_This;
        private Stock_DataDataContext dbInstance;
        private List<string> pkeys = new List<string>();
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
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
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private PanelEx panelEx3;
        private PanelEx panelEx2;
        private ExpandableSplitter expandableSplitter1;
        private Panel panel1;
        private Label label5;
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
        private TextBox txtStreet;
        private Label label8;
        private Label label12;
        private TextBox txtTotSpace;
        private Label label13;
        private Label label9;
        private Label label18;
        private ComboBox CmbEqarNature;
        private Label label19;
        private TextBox textBox_ID;
        private Label label4;
        private TextBox txtEngDes;
        private Label label2;
        private TextBox txtArbDes;
        private Label label1;
        private TextBox txtInstrumentNo;
        private TextBox txtNote;
        private Label label21;
        private ComboBox CmbEqarTyp;
        private C1BarCode c1BarCode1;
        private TextBox txtEqarAccNo;
        internal Label label22;
        private ButtonX button_SrchOwnerADD;
        private ButtonX button_SrchOwnerNo;
        private IntegerInput txtFloors;
        private Label label10;
        private Label label16;
        private DoubleInput txtContractValue;
        internal Label label14;
        private MaskedTextBox txtInstrumentDate;
        private IntegerInput txtEyes;
        private DoubleInput txtRentContractValue;
        private TextBox txtNeighborhood;
        private Label label17;
        private Label label15;
        private ComboBox CmbCity;
        internal TextBox txt_OwnerName;
        private TextBox txt_OwnerNo;
        private C1FlexGrid FlxAinDet;
        private LabelItem lable_Records;
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
        public T_EqarsData DataThis
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
                if (value != null && value.UsrNo != string.Empty)
                {
                    permission = value;
                    if (!VarGeneral.TString.ChkStatShow(value.Eqar_FilStr, 17))
                    {
                        IfAdd = false;
                    }
                    else
                    {
                        IfAdd = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Eqar_FilStr, 18))
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Eqar_FilStr, 19))
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
            var qkeys = from item in db.T_EqarsDatas
                        orderby item.EqarNo
                        select new
                        {
                            Code = item.EqarNo + string.Empty
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
        public FrmEqars()
        {
            InitializeComponent();
            txt_OwnerNo.Click += Button_Edit_Click;
            txt_OwnerName.Click += Button_Edit_Click;
            txtArbDes.Click += Button_Edit_Click;
            txtContractValue.Click += Button_Edit_Click;
            txtEngDes.Click += Button_Edit_Click;
            txtEqarAccNo.Click += Button_Edit_Click;
            txtEyes.Click += Button_Edit_Click;
            txtFloors.Click += Button_Edit_Click;
            txtInstrumentDate.Click += Button_Edit_Click;
            txtInstrumentNo.Click += Button_Edit_Click;
            txtNeighborhood.Click += Button_Edit_Click;
            txtNote.Click += Button_Edit_Click;
            txtRentContractValue.Click += Button_Edit_Click;
            txtStreet.Click += Button_Edit_Click;
            txtTotSpace.Click += Button_Edit_Click;
            CmbCity.Click += Button_Edit_Click;
            CmbEqarNature.Click += Button_Edit_Click;
            CmbEqarTyp.Click += Button_Edit_Click;
            button_SrchOwnerADD.Click += Button_Edit_Click;
            button_SrchOwnerNo.Click += Button_Edit_Click;
            FlxAinDet.Click += Button_Edit_Click;
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
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
            {
                txtContractValue.DisplayFormat = VarGeneral.DicemalMask;
                txtRentContractValue.DisplayFormat = VarGeneral.DicemalMask;
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
        public void Button_Search_Click(object sender, EventArgs e)
        {
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_EqarsData";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
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
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
            textBox_search.Text = string.Empty;
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
                if (int.Parse(Label_Count.Text ?? string.Empty) <= 0 || (Label_Count.Text ?? string.Empty) == string.Empty)
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
                if (int.Parse(Label_Count.Text ?? string.Empty) <= 0 || (Label_Count.Text ?? string.Empty) == string.Empty)
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
            List<T_EqarsData> list = db.FillEqarData_2(textBox_search.TextBox.Text).ToList();
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
        }
        public void FillHDGV(IEnumerable<T_EqarsData> new_data_enum)
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
            DGV_Main.PrimaryGrid.DataMember = "T_EqarsData";
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmEqars));
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
                Text = "كرت العقــارات";
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
                Text = "Real Estate Card";
            }
            ArbEng();
        }
        private void FrmEqars_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmEqars));
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
                    columns_Names_visible.Add("EqarNo", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("ContractValue", new ColumnDictinary("قيمة العقار", "Property value", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("ContractRentValue", new ColumnDictinary("إيجار العقار", "Rent the property", ifDefault: false, string.Empty));
                    columns_Names_visible.Add("FloorsCount", new ColumnDictinary("عدد الطوابق", "Floors Count", ifDefault: false, string.Empty));
                    columns_Names_visible.Add("EyesCount", new ColumnDictinary("عدد العيون", "Eyes Count", ifDefault: false, string.Empty));
                    columns_Names_visible.Add("Space", new ColumnDictinary("مساحة العقار", "Space", ifDefault: false, string.Empty));
                }
                else
                {
                    Clear();
                    textBox_ID.Text = string.Empty;
                    TextBox_Index.TextBox.Text = string.Empty;
                }
                RefreshPKeys();
                FillCombo();
                RibunButtons();
                listAinTyp = new List<T_AinTyp>();
                listAinTyp = db.FillAinTyp_2(string.Empty).ToList();
                string Co = string.Empty;
                for (int iiCnt = 0; iiCnt < listAinTyp.Count; iiCnt++)
                {
                    _AinTyp = listAinTyp[iiCnt];
                    Co = ((!(Co != string.Empty)) ? ((LangArEn == 0) ? _AinTyp.NameA : _AinTyp.NameE) : (Co + "|" + ((LangArEn == 0) ? _AinTyp.NameA : _AinTyp.NameE)));
                }
                FlxAinDet.Cols[2].ComboList = Co;
                listAinNature = new List<T_AinNatural>();
                listAinNature = db.FillAinNatural_2(string.Empty).ToList();
                Co = string.Empty;
                for (int iiCnt = 0; iiCnt < listAinNature.Count; iiCnt++)
                {
                    _AinNature = listAinNature[iiCnt];
                    Co = ((!(Co != string.Empty)) ? ((LangArEn == 0) ? _AinNature.NameA : _AinNature.NameE) : (Co + "|" + ((LangArEn == 0) ? _AinNature.NameA : _AinNature.NameE)));
                }
                FlxAinDet.Cols[3].ComboList = Co;
                FlxAinDet.DrawMode = DrawModeEnum.OwnerDraw;
                FlxAinDet.OwnerDrawCell += _ownerDraw;
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
            List<T_City> listCity = new List<T_City>(db.T_Cities.Select((T_City item) => item).ToList());
            CmbCity.DataSource = null;
            CmbCity.DataSource = listCity;
            CmbCity.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            CmbCity.ValueMember = "City_No";
            CmbCity.SelectedIndex = 0;
            List<T_EqarTyp> listEqarTyp = new List<T_EqarTyp>(db.T_EqarTyps.Select((T_EqarTyp item) => item).ToList());
            CmbEqarTyp.DataSource = listEqarTyp;
            CmbEqarTyp.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            CmbEqarTyp.ValueMember = "EqarTyp_No";
            CmbEqarTyp.SelectedIndex = 0;
            List<T_EqarNatural> listEqarNature = new List<T_EqarNatural>(db.T_EqarNaturals.Select((T_EqarNatural item) => item).ToList());
            CmbEqarNature.DataSource = listEqarNature;
            CmbEqarNature.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            CmbEqarNature.ValueMember = "EqarNatural_No";
            CmbEqarNature.SelectedIndex = 0;
        }
        private void GetInvSetting()
        {
            _InvSetting = db.StockInvSetting(VarGeneral.UserID, 22);
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
                T_EqarsData newData = db.StockEqarData(no);
                if (newData == null || newData.EqarNo == 0)
                {
                    if (!Button_Add.Visible || !Button_Add.Enabled)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textBox_ID.TextChanged -= textBox_ID_TextChanged;
                        try
                        {
                            textBox_ID.Text = data_this.EqarNo.ToString();
                        }
                        catch
                        {
                        }
                        textBox_ID.TextChanged += textBox_ID_TextChanged;
                        return;
                    }
                    Clear();
                    FlxAinDet.Rows.Count = 50;
                    TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                    TextBox_Index.TextBox.Text = string.Concat(PKeys.Count + 1);
                    TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                }
                else
                {
                    DataThis = newData;
                    int indexA = PKeys.IndexOf(string.Concat(newData.EqarNo));
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
            data_this = new T_EqarsData();
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
                        controls[i].Text = string.Empty;
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
            if (FlxAinDet.Rows.Count <= 1)
            {
                FlxAinDet.Rows.Count = 50;
            }
            else
            {
                int _rowsCnt = FlxAinDet.Rows.Count;
                FlxAinDet.Rows.Count = 1;
                FlxAinDet.Rows.Count = _rowsCnt;
                FlxAinDet.Clear(ClearFlags.Content, 1, 1, FlxAinDet.Rows.Count - 1, 8);
            }
            textBox_ID.Focus();
            CmbCity.SelectedIndex = 0;
            CmbEqarTyp.SelectedIndex = 0;
            CmbEqarNature.SelectedIndex = 0;
            SetReadOnly = false;
        }
        public void SetData(T_EqarsData value)
        {
            try
            {
                State = FormState.Saved;
                Button_Save.Enabled = false;
                textBox_ID.Tag = value.EqarID.ToString();
                txt_OwnerName.Text = ((LangArEn == 0) ? value.T_Owner.NameA : value.T_Owner.NameE);
                txt_OwnerNo.Text = value.OwnerNo.ToString();
                txtArbDes.Text = value.NameA;
                txtContractValue.Value = value.ContractValue.Value;
                txtEngDes.Text = value.NameE;
                txtEyes.Value = value.EyesCount.Value;
                txtFloors.Value = value.FloorsCount.Value;
                try
                {
                    if (VarGeneral.CheckDate(value.SQDate))
                    {
                        txtInstrumentDate.Text = Convert.ToDateTime(value.SQDate).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        txtInstrumentDate.Text = string.Empty;
                    }
                }
                catch
                {
                    txtInstrumentDate.Text = string.Empty;
                }
                txtInstrumentNo.Text = value.SQNo;
                if (value.EqarTypNo.HasValue)
                {
                    CmbEqarTyp.SelectedValue = value.EqarTypNo;
                }
                else
                {
                    CmbEqarTyp.SelectedIndex = 0;
                }
                if (value.EqarNatureNo.HasValue)
                {
                    CmbEqarNature.SelectedValue = value.EqarNatureNo;
                }
                else
                {
                    CmbEqarNature.SelectedIndex = 0;
                }
                if (value.CityNo.HasValue)
                {
                    CmbCity.SelectedValue = value.CityNo;
                }
                else
                {
                    CmbCity.SelectedIndex = 0;
                }
                try
                {
                    if (!string.IsNullOrEmpty(value.AccNo))
                    {
                        txtEqarAccNo.Text = value.AccNo.ToString();
                    }
                    else
                    {
                        txtEqarAccNo.Text = string.Empty;
                    }
                }
                catch
                {
                    txtEqarAccNo.Text = string.Empty;
                }
                txtNeighborhood.Text = value.Neighborhood;
                txtNote.Text = value.Note;
                txtRentContractValue.Value = value.ContractRentValue.Value;
                txtStreet.Text = value.Street;
                txtTotSpace.Text = value.Space;
                LDataThis = new BindingList<T_AinsData>(value.T_AinsDatas).OrderBy((T_AinsData g) => g.AinNo).ToList();
                SetLines(LDataThis);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SetData:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        public void SetLines(List<T_AinsData> listDet)
        {
            try
            {
                FlxAinDet.Rows.Count = listDet.Count + 1;
                for (int iiCnt = 1; iiCnt <= listDet.Count; iiCnt++)
                {
                    _AinDet = listDet[iiCnt - 1];
                    FlxAinDet.SetData(iiCnt, 1, _AinDet.AinNo);
                    FlxAinDet.SetData(iiCnt, 2, (LangArEn == 0) ? db.AinTypEmp(_AinDet.AinTyp).NameA : db.AinTypEmp(_AinDet.AinTyp).NameE);
                    FlxAinDet.SetData(iiCnt, 3, (LangArEn == 0) ? db.AinNaturalEmp(_AinDet.AinNature).NameA : db.AinTypEmp(_AinDet.AinNature).NameE);
                    FlxAinDet.SetData(iiCnt, 4, _AinDet.RentOfYear.Value);
                    FlxAinDet.SetData(iiCnt, 5, _AinDet.EyeValue.Value);
                    FlxAinDet.SetData(iiCnt, 6, _AinDet.EyeDetail);
                    FlxAinDet.SetData(iiCnt, 7, _AinDet.AinStatus.Value);
                    FlxAinDet.SetData(iiCnt, 8, _AinDet.AinID);
                }
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "حدث خطأ أثناء تعبئة الأسطر .." : "An error occurred while filling lines ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void ArbEng()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                LangArEn = 0;
                FlxAinDet.Cols[1].Caption = "رقم العين";
                FlxAinDet.Cols[2].Caption = "نوع العين";
                FlxAinDet.Cols[3].Caption = "طبيعة العين";
                FlxAinDet.Cols[4].Caption = "الإيجار السنوي";
                FlxAinDet.Cols[5].Caption = "قيمة العين";
                FlxAinDet.Cols[6].Caption = "تفاصيل العين - المواصفات";
            }
            else
            {
                LangArEn = 1;
                FlxAinDet.Cols[1].Caption = "Eye No";
                FlxAinDet.Cols[2].Caption = "Eye Type";
                FlxAinDet.Cols[3].Caption = "Eye Nature";
                FlxAinDet.Cols[4].Caption = "Rent of year";
                FlxAinDet.Cols[5].Caption = "Eye Value";
                FlxAinDet.Cols[6].Caption = "Eye Details";
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
        private T_EqarsData GetData()
        {
            textBox_ID.Focus();
            data_this.EqarNo = int.Parse(textBox_ID.Text);
            data_this.OwnerNo = int.Parse(txt_OwnerNo.Text);
            data_this.NameA = txtArbDes.Text;
            data_this.ContractValue = txtContractValue.Value;
            data_this.NameE = txtEngDes.Text;
            data_this.EyesCount = txtEyes.Value;
            data_this.FloorsCount = txtFloors.Value;
            try
            {
                if (VarGeneral.CheckDate(txtInstrumentDate.Text))
                {
                    data_this.SQDate = txtInstrumentDate.Text;
                }
                else
                {
                    data_this.SQDate = string.Empty;
                }
            }
            catch
            {
                data_this.SQDate = string.Empty;
            }
            data_this.SQNo = txtInstrumentNo.Text;
            data_this.EqarTypNo = int.Parse(CmbEqarTyp.SelectedValue.ToString());
            data_this.EqarNatureNo = int.Parse(CmbEqarNature.SelectedValue.ToString());
            data_this.CityNo = int.Parse(CmbCity.SelectedValue.ToString());
            if (!string.IsNullOrEmpty(txtEqarAccNo.Text))
            {
                data_this.AccNo = txtEqarAccNo.Text;
            }
            else
            {
                data_this.AccNo = null;
            }
            data_this.Neighborhood = txtNeighborhood.Text;
            data_this.Note = txtNote.Text;
            data_this.ContractRentValue = txtRentContractValue.Value;
            data_this.Street = txtStreet.Text;
            data_this.Space = txtTotSpace.Text;
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
                FlxAinDet.Rows.Count = FlxAinDet.Rows.Count + 50;
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
                int id = db.MaxEqarDataNo;
                textBox_ID.Text = id.ToString();
                if (!string.IsNullOrEmpty(VarGeneral.Settings_Sys.EqarAcc))
                {
                    int Value = 0;
                    List<T_AccDef> q = (from t in db.T_AccDefs
                                        where t.ParAcc == VarGeneral.Settings_Sys.EqarAcc
                                        orderby t.AccDef_ID
                                        select t).ToList();
                    if (q.Count == 0)
                    {
                        txtEqarAccNo.Text = VarGeneral.Settings_Sys.EqarAcc + "001";
                    }
                    else
                    {
                        _AccDefBind = q[q.Count - 1];
                        string _Zero = string.Empty;
                        for (int iiCnt = 0; iiCnt < _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Length && _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Substring(iiCnt, 1) == "0"; iiCnt++)
                        {
                            _Zero += _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Substring(iiCnt, 1);
                        }
                        Value = int.Parse(_AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length)) + 1;
                        if (!string.IsNullOrEmpty(_Zero))
                        {
                            txtEqarAccNo.Text = _AccDefBind.ParAcc + _Zero + Value;
                        }
                        else
                        {
                            txtEqarAccNo.Text = _AccDefBind.ParAcc + Value;
                        }
                    }
                }
                FlxAinDet.Rows.Count = 50;
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
            if (textBox_ID.Text == "0" || textBox_ID.Text == string.Empty)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ بدون رقم العقار" : "Can not save without the Number", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                textBox_ID.Focus();
                return false;
            }
            if (txtArbDes.Text == string.Empty)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الإسم فارغا\u0651" : "Can not be name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtArbDes.Focus();
                return false;
            }
            if (txtEngDes.Text == string.Empty)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الإسم فارغا\u0651" : "Can not be name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtEngDes.Focus();
                return false;
            }
            if (txt_OwnerNo.Text == string.Empty)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون رقم المالك فارغا\u0651" : "Can not be Owner No is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txt_OwnerNo.Focus();
                return false;
            }
            if (txtEqarAccNo.Text == string.Empty)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ بدون رقم حساب العقار" : "Can not save without the property account number.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtEqarAccNo.Focus();
                return false;
            }
            try
            {
                if (string.IsNullOrEmpty(CmbEqarTyp.SelectedValue.ToString()))
                {
                    MessageBox.Show((LangArEn == 0) ? "تاكد من نوع العقار" : "Can not save without the property type.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    CmbEqarTyp.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "تاكد من نوع العقار" : "Can not save without the property type.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                CmbEqarTyp.Focus();
                return false;
            }
            try
            {
                if (string.IsNullOrEmpty(CmbEqarNature.SelectedValue.ToString()))
                {
                    MessageBox.Show((LangArEn == 0) ? "تاكد من طبيعة العقار" : "Can not save without the property Nature.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    CmbEqarNature.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "تاكد من طبيعة العقار" : "Can not save without the property Nature.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                CmbEqarNature.Focus();
                return false;
            }
            try
            {
                if (string.IsNullOrEmpty(CmbCity.SelectedValue.ToString()))
                {
                    MessageBox.Show((LangArEn == 0) ? "تاكد من اختيار المدينة" : "Can not save without select city.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    CmbCity.Focus();
                    return false;
                }
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "تاكد من اختيار المدينة" : "Can not save without select city.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                CmbCity.Focus();
                return false;
            }
            for (int iiCnt = 1; iiCnt < FlxAinDet.Rows.Count; iiCnt++)
            {
                if (!(string.Concat(FlxAinDet.GetData(iiCnt, 1)) != string.Empty))
                {
                    continue;
                }
                for (int i = 2; i < 4; i++)
                {
                    if (string.Concat(FlxAinDet.GetData(iiCnt, i)) == string.Empty)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من تعبئة جميع البيانات المطلوبة" : "We must not be empty value .. Please make sure there are items in the bill.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        FlxAinDet.Row = iiCnt;
                        FlxAinDet.Col = i;
                        FlxAinDet.Focus();
                        return false;
                    }
                }
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
                        if (!string.IsNullOrEmpty(txtEqarAccNo.Text))
                        {
                            T_AccDef c = db.StockAccDefWithOutBalance(txtEqarAccNo.Text);
                            if (c == null || c.AccDef_ID == 0)
                            {
                                if (!string.IsNullOrEmpty(VarGeneral.Settings_Sys.EqarAcc))
                                {
                                    int Value = 0;
                                    List<T_AccDef> q = (from t in db.T_AccDefs
                                                        where t.ParAcc == VarGeneral.Settings_Sys.EqarAcc
                                                        orderby t.AccDef_ID
                                                        select t).ToList();
                                    if (q.Count == 0)
                                    {
                                        txtEqarAccNo.Text = VarGeneral.Settings_Sys.EqarAcc + "001";
                                    }
                                    else
                                    {
                                        _AccDefBind = q[q.Count - 1];
                                        string _Zero = string.Empty;
                                        for (int iiCnt = 0; iiCnt < _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Length && _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Substring(iiCnt, 1) == "0"; iiCnt++)
                                        {
                                            _Zero += _AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length).Substring(iiCnt, 1);
                                        }
                                        Value = int.Parse(_AccDefBind.AccDef_No.Substring(_AccDefBind.ParAcc.Length)) + 1;
                                        if (!string.IsNullOrEmpty(_Zero))
                                        {
                                            txtEqarAccNo.Text = _AccDefBind.ParAcc + _Zero + Value;
                                        }
                                        else
                                        {
                                            txtEqarAccNo.Text = _AccDefBind.ParAcc + Value;
                                        }
                                    }
                                }
                                if (string.IsNullOrEmpty(txtEqarAccNo.Text))
                                {
                                    MessageBox.Show((LangArEn == 0) ? "لا يمكن الحفظ بدون رقم حساب العقار" : "Can not save without the Real Estate account number.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    txtEqarAccNo.Focus();
                                    return;
                                }
                                data_this.AccNo = txtEqarAccNo.Text;
                                db.ExecuteCommand("INSERT [dbo].[T_AccDef] ([AccDef_No], [Arb_Des], [Eng_Des], [ParAcc], [Lev], [Typ], [AccCat], [DC], [Sts], [Debit], [Credit], [Balance], [Trn], [City], [Email], [Telphone1], [Telphone2], [Fax], [Mobile], [MaxLemt], [DesPers], [StrAm], [Adders], [Mnd], [Price], [zipCod], [PersonalNm], [RessonStoped], [StopedState], [CompanyID], [StopInvTyp], [DateAppointment], [ID_Date], [ID_DateEnd], [Passport_Date], [Insurance_Date], [Passport_DateEnd], [Insurance_DateEnd], [ID_No], [Passport_No], [Insurance_No], [ID_From], [Passport_From], [Insurance_From], [MainSal], [DepreciationPercent], [ProofAcc], [RelayAcc],[MaxDisCust],[vColNum1],[vColNum2],[vColStr1],[vColStr2],[vColStr3]) VALUES (N'" + txtEqarAccNo.Text + "', N'" + txtArbDes.Text + "', N'" + txtEngDes.Text + "', N'" + VarGeneral.Settings_Sys.EqarAcc + "', 4, NULL, 1, 0, 0, 0, 0, 0, 3, NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, NULL, NULL,0,0,0,'','','')");
                            }
                            else
                            {
                                data_this.AccNo = txtEqarAccNo.Text;
                            }
                        }
                        data_this.EqarStatus = 0;
                        db.T_EqarsDatas.InsertOnSubmit(data_this);
                        db.SubmitChanges();
                    }
                    catch (SqlException ex4)
                    {
                        if (ex4.Number != 2627)
                        {
                            return;
                        }
                        MessageBox.Show("الرقم مستخدم من قبل.\n سيتم الحفظ برقم جديد ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        int id = db.MaxEqarDataNo;
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
                        for (int i = 0; i < LData_This.ToList().Count; i++)
                        {
                            int? ainStatus = LData_This[i].AinStatus;
                            if (ainStatus.Value == 0 && ainStatus.HasValue)
                            {
                                db.T_AinsDatas.DeleteOnSubmit(LData_This[i]);
                                db.SubmitChanges();
                            }
                        }
                        db.ExecuteCommand("update [dbo].[T_AccDef] Set [Arb_Des] = '" + txtArbDes.Text + "' , [Eng_Des] = '" + txtEngDes.Text + "' where AccDef_No = '" + txtEqarAccNo.Text + "'");
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
                int ii = 0;
                for (ii = 1; ii < FlxAinDet.Rows.Count; ii++)
                {
                    if (FlxAinDet.GetData(ii, 1) == null)
                    {
                        continue;
                    }
                    try
                    {
                        if (int.Parse(FlxAinDet.GetData(ii, 7).ToString()) > 0)
                        {
                            _AinDet = new T_AinsData();
                            _AinDet = LData_This.Where((T_AinsData g) => g.AinID == int.Parse(FlxAinDet.GetData(ii, 8).ToString())).FirstOrDefault();
                            if (_AinDet != null && _AinDet.AinID > 0)
                            {
                                goto IL_07a6;
                            }
                            continue;
                        }
                        _AinDet = new T_AinsData();
                        goto IL_06e6;
                    }
                    catch
                    {
                        _AinDet = new T_AinsData();
                        goto IL_06e6;
                    }
                    IL_07a6:
                    try
                    {
                        _AinDet.AinNature = db.T_AinNaturals.Where((T_AinNatural t) => t.NameA == FlxAinDet.GetData(ii, 3).ToString() || t.NameE == FlxAinDet.GetData(ii, 3).ToString()).FirstOrDefault().AinNatural_No;
                    }
                    catch (Exception error3)
                    {
                        VarGeneral.DebLog.writeLog("Save AinNature:", error3, enable: true);
                        continue;
                    }
                    try
                    {
                        _AinDet.AinTyp = db.T_AinTyps.Where((T_AinTyp t) => t.NameA == FlxAinDet.GetData(ii, 2) || t.NameE == FlxAinDet.GetData(ii, 2)).FirstOrDefault().AinTyp_No;
                    }
                    catch (Exception error3)
                    {
                        VarGeneral.DebLog.writeLog("Save AinTyp:", error3, enable: true);
                        continue;
                    }
                    try
                    {
                        _AinDet.EyeDetail = string.Concat(FlxAinDet.GetData(ii, 6));
                    }
                    catch
                    {
                        _AinDet.EyeDetail = string.Empty;
                    }
                    try
                    {
                        _AinDet.RentOfYear = double.Parse(FlxAinDet.GetData(ii, 4).ToString());
                    }
                    catch
                    {
                        _AinDet.RentOfYear = 0.0;
                    }
                    try
                    {
                        _AinDet.EyeValue = double.Parse(FlxAinDet.GetData(ii, 5).ToString());
                    }
                    catch
                    {
                        _AinDet.EyeValue = 0.0;
                    }
                    try
                    {
                        if (int.Parse(FlxAinDet.GetData(ii, 7).ToString()) == 0)
                        {
                            db.T_AinsDatas.InsertOnSubmit(_AinDet);
                            db.SubmitChanges();
                        }
                        else
                        {
                            db.Log = VarGeneral.DebugLog;
                            db.SubmitChanges(ConflictMode.ContinueOnConflict);
                        }
                    }
                    catch
                    {
                        db.T_AinsDatas.InsertOnSubmit(_AinDet);
                        db.SubmitChanges();
                    }
                    continue;
                    IL_06e6:
                    _AinDet.AinNo = FlxAinDet.GetData(ii, 1).ToString();
                    _AinDet.EqarID = data_this.EqarID;
                    try
                    {
                        if (string.IsNullOrEmpty(FlxAinDet.GetData(ii, 7).ToString()))
                        {
                            _AinDet.AinStatus = 0;
                        }
                        else
                        {
                            _AinDet.AinStatus = int.Parse(FlxAinDet.GetData(ii, 7).ToString());
                        }
                    }
                    catch
                    {
                        _AinDet.AinStatus = 0;
                    }
                    goto IL_07a6;
                }
                MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                State = FormState.Saved;
                RefreshPKeys();
                TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(string.Concat(data_this.EqarNo)) + 1);
                dbInstance = null;
                textBox_ID_TextChanged(sender, e);
                SetReadOnly = true;
            }
            catch (Exception error3)
            {
                VarGeneral.DebLog.writeLog("Save:", error3, enable: true);
                MessageBox.Show(error3.Message);
            }
        }
        private void Button_Delete_Click(object sender, EventArgs e)
        {
            if (!Button_Delete.Enabled || !Button_Delete.Visible || State != 0)
            {
                ifOkDelete = false;
                return;
            }
            string Code = string.Empty;
            Code = textBox_ID.Text;
            if (Code == string.Empty)
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
            if (data_this.EqarStatus.Value != 0)
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكنك حذف هذا العقار لانه مأجر او مباع في الوقت الحالي" : "You can't delete this Record because it's rented or sold right now", VarGeneral.ProdectNam);
                return;
            }
            for (int i = 0; i < data_this.T_AinsDatas.Count; i++)
            {
                try
                {
                    if (data_this.T_AinsDatas[i].AinStatus.Value > 0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكنك حذف هذا العقار لانه مأجر او مباع في الوقت الحالي" : "You can't delete this Record because it's rented or sold right now", VarGeneral.ProdectNam);
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكنك حذف هذا العقار لانه مأجر او مباع في الوقت الحالي" : "You can't delete this Record because it's rented or sold right now", VarGeneral.ProdectNam);
                    return;
                }
            }
            data_this = db.StockEqarData(DataThis.EqarNo);
            try
            {
                db.T_AinsDatas.DeleteAllOnSubmit(data_this.T_AinsDatas);
                db.SubmitChanges();
                db.T_EqarsDatas.DeleteOnSubmit(DataThis);
                db.SubmitChanges();
            }
            catch (SqlException)
            {
                data_this = db.StockEqarData(DataThis.EqarNo);
                return;
            }
            catch (Exception)
            {
                data_this = db.StockEqarData(DataThis.EqarNo);
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
            if (dataMember != null && dataMember == "T_EqarsData")
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
            panel.Columns["EqarNo"].Width = 120;
            panel.Columns["EqarNo"].Visible = columns_Names_visible["EqarNo"].IfDefault;
            panel.Columns["NameA"].Width = 180;
            panel.Columns["NameA"].Visible = columns_Names_visible["NameA"].IfDefault;
            panel.Columns["NameE"].Width = 180;
            panel.Columns["NameE"].Visible = columns_Names_visible["NameE"].IfDefault;
            panel.Columns["ContractValue"].Width = 80;
            panel.Columns["ContractValue"].Visible = columns_Names_visible["ContractValue"].IfDefault;
            panel.Columns["ContractRentValue"].Width = 80;
            panel.Columns["ContractRentValue"].Visible = columns_Names_visible["ContractRentValue"].IfDefault;
            panel.Columns["FloorsCount"].Width = 80;
            panel.Columns["FloorsCount"].Visible = columns_Names_visible["FloorsCount"].IfDefault;
            panel.Columns["EyesCount"].Width = 80;
            panel.Columns["EyesCount"].Visible = columns_Names_visible["EyesCount"].IfDefault;
            panel.Columns["Space"].Width = 120;
            panel.Columns["Space"].Visible = columns_Names_visible["Space"].IfDefault;
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
                ExportExcel.ExportToExcel(DGV_Main, "تقرير العقارات");
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
                controls.Add(txt_OwnerNo);
                controls.Add(txt_OwnerName);
                controls.Add(txtArbDes);
                controls.Add(txtContractValue);
                controls.Add(txtEngDes);
                controls.Add(txtEqarAccNo);
                controls.Add(txtEyes);
                controls.Add(txtFloors);
                controls.Add(txtInstrumentDate);
                controls.Add(txtInstrumentNo);
                controls.Add(txtNeighborhood);
                controls.Add(txtNote);
                controls.Add(txtRentContractValue);
                controls.Add(txtStreet);
                controls.Add(txtTotSpace);
                controls.Add(CmbCity);
                controls.Add(CmbEqarNature);
                controls.Add(CmbEqarTyp);
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
                _RepShow.Tables = " T_EqarsData  ";
                string Fields = string.Empty;
                Fields = " T_EqarsData.EqarID , T_EqarsData.EqarNo as No , T_EqarsData.NameA as NmA, T_EqarsData.NameE as NmE ,(select T_SYSSETTING.LogImg from T_SYSSETTING) as LogImg";
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
        private void txtMobile_Click(object sender, EventArgs e)
        {
            txtTotSpace.SelectAll();
        }
        private void textBox_ID_Click(object sender, EventArgs e)
        {
            textBox_ID.SelectAll();
        }
        private void button_SrchOwnerNo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            Button_Edit_Click(sender, e);
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("Owner_No", new ColumnDictinary("الرقـــــم", "No", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_Owner";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_Owner _Owner = db.OwnerEmp(int.Parse(frm.Serach_No));
                    txt_OwnerNo.Text = _Owner.Owner_No.ToString();
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                    {
                        txt_OwnerName.Text = _Owner.NameA;
                    }
                    else
                    {
                        txt_OwnerName.Text = _Owner.NameE;
                    }
                }
                else
                {
                    txt_OwnerNo.Text = string.Empty;
                    txt_OwnerName.Text = string.Empty;
                }
            }
            catch
            {
                txt_OwnerNo.Text = string.Empty;
                txt_OwnerName.Text = string.Empty;
            }
        }
        private void txtInstrumentDate_Click(object sender, EventArgs e)
        {
            txtInstrumentDate.SelectAll();
        }
        private void txtInstrumentDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtInstrumentDate.Text))
                {
                    txtInstrumentDate.Text = Convert.ToDateTime(txtInstrumentDate.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    txtInstrumentDate.Text = string.Empty;
                }
            }
            catch
            {
                txtInstrumentDate.Text = string.Empty;
            }
        }
        private void button_SrchOwnerADD_Click(object sender, EventArgs e)
        {
            if (!VarGeneral.TString.ChkStatShow(permission.Eqar_FilStr, 24))
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكنك إضافة عميل جديد .. راجع صلاحيات المستخدمين" : "You can not add a new customer ... Check the Users Authorizations", VarGeneral.ProdectNam);
                return;
            }
            FrmOwners frm = new FrmOwners();
            frm.Tag = LangArEn;
            frm.TopMost = true;
            frm.ShowDialog();
        }
        private void FlxAinDet_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (int.Parse(FlxAinDet.GetData(FlxAinDet.Row, 7).ToString()) == 0)
                    {
                        FlxAinDet.RemoveItem(FlxAinDet.Row);
                        FlxAinDet.Rows.Add();
                    }
                    else
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكنك حذف هذا العين لانه مأجر او مباع في الوقت الحالي" : "You can't delete this eye because it's rented or sold right now", VarGeneral.ProdectNam);
                    }
                }
            }
            catch
            {
                MessageBox.Show((LangArEn == 0) ? "لا يمكنك حذف هذا العين لانه مأجر او مباع في الوقت الحالي" : "You can't delete this eye because it's rented or sold right now", VarGeneral.ProdectNam);
            }
        }
        private void FlxAinDet_BeforeEdit(object sender, RowColEventArgs e)
        {
            try
            {
                if (int.Parse(FlxAinDet.GetData(FlxAinDet.Row, 7).ToString()) != 0 && e.Col == 1)
                {
                    e.Cancel = true;
                }
            }
            catch
            {
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
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmEqars));
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background3 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor1 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor2 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle1 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle2 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.Background background4 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            Rep_RecCount = new DevComponents.Editors.IntegerInput();
            ToolStripMenuItem_Rep = new System.Windows.Forms.ToolStripMenuItem();
            ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            FlxAinDet = new C1.Win.C1FlexGrid.C1FlexGrid();
            txtEyes = new DevComponents.Editors.IntegerInput();
            txtRentContractValue = new DevComponents.Editors.DoubleInput();
            txtNeighborhood = new System.Windows.Forms.TextBox();
            label17 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            CmbCity = new System.Windows.Forms.ComboBox();
            label14 = new System.Windows.Forms.Label();
            txtInstrumentDate = new System.Windows.Forms.MaskedTextBox();
            txt_OwnerName = new System.Windows.Forms.TextBox();
            button_SrchOwnerADD = new DevComponents.DotNetBar.ButtonX();
            txt_OwnerNo = new System.Windows.Forms.TextBox();
            button_SrchOwnerNo = new DevComponents.DotNetBar.ButtonX();
            label22 = new System.Windows.Forms.Label();
            txtNote = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            txtStreet = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            txtTotSpace = new System.Windows.Forms.TextBox();
            label13 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            txtFloors = new DevComponents.Editors.IntegerInput();
            label10 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            txtEngDes = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            txtArbDes = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            txtContractValue = new DevComponents.Editors.DoubleInput();
            txtInstrumentNo = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            label21 = new System.Windows.Forms.Label();
            CmbEqarTyp = new System.Windows.Forms.ComboBox();
            c1BarCode1 = new C1.Win.C1BarCode.C1BarCode();
            CmbEqarNature = new System.Windows.Forms.ComboBox();
            textBox_ID = new System.Windows.Forms.TextBox();
            txtEqarAccNo = new System.Windows.Forms.TextBox();
            barTopDockSite = new DevComponents.DotNetBar.DockSite();
            barBottomDockSite = new DevComponents.DotNetBar.DockSite();
            barLeftDockSite = new DevComponents.DotNetBar.DockSite();
            barRightDockSite = new DevComponents.DotNetBar.DockSite();
            dockSite1 = new DevComponents.DotNetBar.DockSite();
            dockSite2 = new DevComponents.DotNetBar.DockSite();
            dotNetBarManager1 = new DevComponents.DotNetBar.DotNetBarManager(components);
            dockSite4 = new DevComponents.DotNetBar.DockSite();
            dockSite3 = new DevComponents.DotNetBar.DockSite();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(components);
            ToolStripMenuItem_Det = new System.Windows.Forms.ToolStripMenuItem();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            panelEx3 = new DevComponents.DotNetBar.PanelEx();
            DGV_Main = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            ribbonBar_DGV = new DevComponents.DotNetBar.RibbonBar();
            superTabControl_DGV = new DevComponents.DotNetBar.SuperTabControl();
            textBox_search = new DevComponents.DotNetBar.TextBoxItem();
            Button_ExportTable2 = new DevComponents.DotNetBar.ButtonItem();
            Button_PrintTable = new DevComponents.DotNetBar.ButtonItem();
            labelItem3 = new DevComponents.DotNetBar.LabelItem();
            panelEx2 = new DevComponents.DotNetBar.PanelEx();
            ribbonBar_Tasks = new DevComponents.DotNetBar.RibbonBar();
            superTabControl_Main1 = new DevComponents.DotNetBar.SuperTabControl();
            Button_Close = new DevComponents.DotNetBar.ButtonItem();
            Button_Search = new DevComponents.DotNetBar.ButtonItem();
            Button_Delete = new DevComponents.DotNetBar.ButtonItem();
            Button_Save = new DevComponents.DotNetBar.ButtonItem();
            Button_Add = new DevComponents.DotNetBar.ButtonItem();
            labelItem2 = new DevComponents.DotNetBar.LabelItem();
            superTabControl_Main2 = new DevComponents.DotNetBar.SuperTabControl();
            labelItem1 = new DevComponents.DotNetBar.LabelItem();
            Button_First = new DevComponents.DotNetBar.ButtonItem();
            Button_Prev = new DevComponents.DotNetBar.ButtonItem();
            TextBox_Index = new DevComponents.DotNetBar.TextBoxItem();
            Label_Count = new DevComponents.DotNetBar.LabelItem();
            lable_Records = new DevComponents.DotNetBar.LabelItem();
            Button_Next = new DevComponents.DotNetBar.ButtonItem();
            Button_Last = new DevComponents.DotNetBar.ButtonItem();
            expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)Rep_RecCount).BeginInit();
            ribbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)FlxAinDet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtEyes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtRentContractValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtFloors).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtContractValue).BeginInit();
            contextMenuStrip2.SuspendLayout();
            panelEx3.SuspendLayout();
            ribbonBar_DGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)superTabControl_DGV).BeginInit();
            panelEx2.SuspendLayout();
            ribbonBar_Tasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)superTabControl_Main1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)superTabControl_Main2).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            Rep_RecCount.AllowEmptyState = false;
            Rep_RecCount.BackgroundStyle.Class = "DateTimeInputBackground";
            Rep_RecCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            Rep_RecCount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(Rep_RecCount, "Rep_RecCount");
            Rep_RecCount.Increment = 0;
            Rep_RecCount.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            Rep_RecCount.IsInputReadOnly = true;
            Rep_RecCount.Name = "Rep_RecCount";
            Rep_RecCount.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            ToolStripMenuItem_Rep.Checked = true;
            ToolStripMenuItem_Rep.CheckState = System.Windows.Forms.CheckState.Checked;
            ToolStripMenuItem_Rep.Name = "ToolStripMenuItem_Rep";
            resources.ApplyResources(ToolStripMenuItem_Rep, "ToolStripMenuItem_Rep");
            ribbonBar1.AutoOverflowEnabled = true;
            ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.ContainerControlProcessDialogKey = true;
            ribbonBar1.Controls.Add(FlxAinDet);
            ribbonBar1.Controls.Add(txtEyes);
            ribbonBar1.Controls.Add(txtRentContractValue);
            ribbonBar1.Controls.Add(txtNeighborhood);
            ribbonBar1.Controls.Add(label17);
            ribbonBar1.Controls.Add(label15);
            ribbonBar1.Controls.Add(CmbCity);
            ribbonBar1.Controls.Add(label14);
            ribbonBar1.Controls.Add(txtInstrumentDate);
            ribbonBar1.Controls.Add(txt_OwnerName);
            ribbonBar1.Controls.Add(button_SrchOwnerADD);
            ribbonBar1.Controls.Add(txt_OwnerNo);
            ribbonBar1.Controls.Add(button_SrchOwnerNo);
            ribbonBar1.Controls.Add(label22);
            ribbonBar1.Controls.Add(txtNote);
            ribbonBar1.Controls.Add(label6);
            ribbonBar1.Controls.Add(txtStreet);
            ribbonBar1.Controls.Add(label8);
            ribbonBar1.Controls.Add(label12);
            ribbonBar1.Controls.Add(txtTotSpace);
            ribbonBar1.Controls.Add(label13);
            ribbonBar1.Controls.Add(label9);
            ribbonBar1.Controls.Add(label18);
            ribbonBar1.Controls.Add(txtFloors);
            ribbonBar1.Controls.Add(label10);
            ribbonBar1.Controls.Add(label16);
            ribbonBar1.Controls.Add(label19);
            ribbonBar1.Controls.Add(label4);
            ribbonBar1.Controls.Add(txtEngDes);
            ribbonBar1.Controls.Add(label2);
            ribbonBar1.Controls.Add(txtArbDes);
            ribbonBar1.Controls.Add(label1);
            ribbonBar1.Controls.Add(txtContractValue);
            ribbonBar1.Controls.Add(txtInstrumentNo);
            ribbonBar1.Controls.Add(label5);
            ribbonBar1.Controls.Add(label21);
            ribbonBar1.Controls.Add(CmbEqarTyp);
            ribbonBar1.Controls.Add(c1BarCode1);
            ribbonBar1.Controls.Add(CmbEqarNature);
            ribbonBar1.Controls.Add(textBox_ID);
            ribbonBar1.Controls.Add(txtEqarAccNo);
            resources.ApplyResources(ribbonBar1, "ribbonBar1");
            ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            ribbonBar1.Name = "ribbonBar1";
            ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.FromArgb(227, 239, 255);
            ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(101, 147, 207);
            ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            FlxAinDet.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            FlxAinDet.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            resources.ApplyResources(FlxAinDet, "FlxAinDet");
            FlxAinDet.ExtendLastCol = true;
            FlxAinDet.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            FlxAinDet.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            FlxAinDet.Name = "FlxAinDet";
            FlxAinDet.Rows.Count = 13;
            FlxAinDet.Rows.DefaultSize = 19;
            FlxAinDet.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
            FlxAinDet.StyleInfo = resources.GetString("FlxAinDet.StyleInfo");
            FlxAinDet.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System;
            FlxAinDet.KeyDown += new System.Windows.Forms.KeyEventHandler(FlxAinDet_KeyDown);
            FlxAinDet.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(FlxAinDet_BeforeEdit);
            txtEyes.AllowEmptyState = false;
            txtEyes.BackgroundStyle.Class = "DateTimeInputBackground";
            txtEyes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            txtEyes.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(txtEyes, "txtEyes");
            txtEyes.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            txtEyes.MinValue = 0;
            txtEyes.Name = "txtEyes";
            txtEyes.ShowUpDown = true;
            txtRentContractValue.AllowEmptyState = false;
            txtRentContractValue.BackgroundStyle.Class = "DateTimeInputBackground";
            txtRentContractValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            txtRentContractValue.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            txtRentContractValue.DisplayFormat = "0.00";
            resources.ApplyResources(txtRentContractValue, "txtRentContractValue");
            txtRentContractValue.Increment = 1.0;
            txtRentContractValue.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            txtRentContractValue.Name = "txtRentContractValue";
            txtRentContractValue.ShowUpDown = true;
            resources.ApplyResources(txtNeighborhood, "txtNeighborhood");
            txtNeighborhood.Name = "txtNeighborhood";
            resources.ApplyResources(label17, "label17");
            label17.Name = "label17";
            resources.ApplyResources(label15, "label15");
            label15.Name = "label15";
            CmbCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            CmbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(CmbCity, "CmbCity");
            CmbCity.FormattingEnabled = true;
            CmbCity.Items.AddRange(new object[6]
            {
                resources.GetString("CmbCity.Items"),
                resources.GetString("CmbCity.Items1"),
                resources.GetString("CmbCity.Items2"),
                resources.GetString("CmbCity.Items3"),
                resources.GetString("CmbCity.Items4"),
                resources.GetString("CmbCity.Items5")
            });
            CmbCity.Name = "CmbCity";
            resources.ApplyResources(label14, "label14");
            label14.BackColor = System.Drawing.Color.Transparent;
            label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label14.Name = "label14";
            txtInstrumentDate.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(txtInstrumentDate, "txtInstrumentDate");
            txtInstrumentDate.Name = "txtInstrumentDate";
            txtInstrumentDate.Leave += new System.EventHandler(txtInstrumentDate_Leave);
            txtInstrumentDate.Click += new System.EventHandler(txtInstrumentDate_Click);
            resources.ApplyResources(txt_OwnerName, "txt_OwnerName");
            txt_OwnerName.BackColor = System.Drawing.SystemColors.Window;
            txt_OwnerName.Name = "txt_OwnerName";
            txt_OwnerName.ReadOnly = true;
            button_SrchOwnerADD.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            button_SrchOwnerADD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(button_SrchOwnerADD, "button_SrchOwnerADD");
            button_SrchOwnerADD.Name = "button_SrchOwnerADD";
            button_SrchOwnerADD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_SrchOwnerADD.Symbol = "\uf055";
            button_SrchOwnerADD.SymbolSize = 12f;
            button_SrchOwnerADD.TextColor = System.Drawing.Color.SteelBlue;
            button_SrchOwnerADD.Click += new System.EventHandler(button_SrchOwnerADD_Click);
            txt_OwnerNo.BackColor = System.Drawing.Color.White;
            txt_OwnerNo.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            resources.ApplyResources(txt_OwnerNo, "txt_OwnerNo");
            txt_OwnerNo.Name = "txt_OwnerNo";
            txt_OwnerNo.ReadOnly = true;
            button_SrchOwnerNo.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            button_SrchOwnerNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(button_SrchOwnerNo, "button_SrchOwnerNo");
            button_SrchOwnerNo.Name = "button_SrchOwnerNo";
            button_SrchOwnerNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_SrchOwnerNo.Symbol = "\uf002";
            button_SrchOwnerNo.SymbolSize = 12f;
            button_SrchOwnerNo.TextColor = System.Drawing.Color.SteelBlue;
            button_SrchOwnerNo.Click += new System.EventHandler(button_SrchOwnerNo_Click);
            resources.ApplyResources(label22, "label22");
            label22.BackColor = System.Drawing.Color.Transparent;
            label22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label22.Name = "label22";
            resources.ApplyResources(txtNote, "txtNote");
            txtNote.Name = "txtNote";
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            resources.ApplyResources(txtStreet, "txtStreet");
            txtStreet.Name = "txtStreet";
            resources.ApplyResources(label8, "label8");
            label8.Name = "label8";
            resources.ApplyResources(label12, "label12");
            label12.Name = "label12";
            resources.ApplyResources(txtTotSpace, "txtTotSpace");
            txtTotSpace.Name = "txtTotSpace";
            txtTotSpace.Click += new System.EventHandler(txtMobile_Click);
            resources.ApplyResources(label13, "label13");
            label13.Name = "label13";
            resources.ApplyResources(label9, "label9");
            label9.Name = "label9";
            resources.ApplyResources(label18, "label18");
            label18.Name = "label18";
            txtFloors.AllowEmptyState = false;
            txtFloors.BackgroundStyle.Class = "DateTimeInputBackground";
            txtFloors.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            txtFloors.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(txtFloors, "txtFloors");
            txtFloors.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            txtFloors.MinValue = 0;
            txtFloors.Name = "txtFloors";
            txtFloors.ShowUpDown = true;
            resources.ApplyResources(label10, "label10");
            label10.Name = "label10";
            resources.ApplyResources(label16, "label16");
            label16.Name = "label16";
            resources.ApplyResources(label19, "label19");
            label19.Name = "label19";
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            txtEngDes.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(txtEngDes, "txtEngDes");
            txtEngDes.Name = "txtEngDes";
            txtEngDes.Leave += new System.EventHandler(txtArbDes_Enter);
            txtEngDes.Enter += new System.EventHandler(txtEngDes_Enter);
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            txtArbDes.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(txtArbDes, "txtArbDes");
            txtArbDes.Name = "txtArbDes";
            txtArbDes.Leave += new System.EventHandler(txtArbDes_Enter);
            txtArbDes.Enter += new System.EventHandler(txtArbDes_Enter);
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            txtContractValue.AllowEmptyState = false;
            txtContractValue.BackgroundStyle.Class = "DateTimeInputBackground";
            txtContractValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            txtContractValue.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            txtContractValue.DisplayFormat = "0.00";
            resources.ApplyResources(txtContractValue, "txtContractValue");
            txtContractValue.Increment = 1.0;
            txtContractValue.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            txtContractValue.Name = "txtContractValue";
            txtContractValue.ShowUpDown = true;
            resources.ApplyResources(txtInstrumentNo, "txtInstrumentNo");
            txtInstrumentNo.Name = "txtInstrumentNo";
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            resources.ApplyResources(label21, "label21");
            label21.Name = "label21";
            CmbEqarTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            CmbEqarTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(CmbEqarTyp, "CmbEqarTyp");
            CmbEqarTyp.FormattingEnabled = true;
            CmbEqarTyp.Items.AddRange(new object[6]
            {
                resources.GetString("CmbEqarTyp.Items"),
                resources.GetString("CmbEqarTyp.Items1"),
                resources.GetString("CmbEqarTyp.Items2"),
                resources.GetString("CmbEqarTyp.Items3"),
                resources.GetString("CmbEqarTyp.Items4"),
                resources.GetString("CmbEqarTyp.Items5")
            });
            CmbEqarTyp.Name = "CmbEqarTyp";
            c1BarCode1.BarWide = 1;
            c1BarCode1.CodeType = C1.Win.C1BarCode.CodeTypeEnum.Code128;
            resources.ApplyResources(c1BarCode1, "c1BarCode1");
            c1BarCode1.Name = "c1BarCode1";
            c1BarCode1.ShowText = true;
            c1BarCode1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            CmbEqarNature.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            CmbEqarNature.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(CmbEqarNature, "CmbEqarNature");
            CmbEqarNature.FormattingEnabled = true;
            CmbEqarNature.Items.AddRange(new object[6]
            {
                resources.GetString("CmbEqarNature.Items"),
                resources.GetString("CmbEqarNature.Items1"),
                resources.GetString("CmbEqarNature.Items2"),
                resources.GetString("CmbEqarNature.Items3"),
                resources.GetString("CmbEqarNature.Items4"),
                resources.GetString("CmbEqarNature.Items5")
            });
            CmbEqarNature.Name = "CmbEqarNature";
            textBox_ID.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
            resources.ApplyResources(textBox_ID, "textBox_ID");
            textBox_ID.Name = "textBox_ID";
            textBox_ID.ReadOnly = true;
            textBox_ID.Tag = string.Empty;
            textBox_ID.TextChanged += new System.EventHandler(textBox_ID_TextChanged);
            textBox_ID.Click += new System.EventHandler(textBox_ID_Click);
            textBox_ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox_ID_KeyPress);
            txtEqarAccNo.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            txtEqarAccNo.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            resources.ApplyResources(txtEqarAccNo, "txtEqarAccNo");
            txtEqarAccNo.Name = "txtEqarAccNo";
            txtEqarAccNo.ReadOnly = true;
            barTopDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(barTopDockSite, "barTopDockSite");
            barTopDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            barTopDockSite.Name = "barTopDockSite";
            barTopDockSite.TabStop = false;
            barBottomDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(barBottomDockSite, "barBottomDockSite");
            barBottomDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            barBottomDockSite.Name = "barBottomDockSite";
            barBottomDockSite.TabStop = false;
            barLeftDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(barLeftDockSite, "barLeftDockSite");
            barLeftDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            barLeftDockSite.Name = "barLeftDockSite";
            barLeftDockSite.TabStop = false;
            barRightDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(barRightDockSite, "barRightDockSite");
            barRightDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            barRightDockSite.Name = "barRightDockSite";
            barRightDockSite.TabStop = false;
            dockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(dockSite1, "dockSite1");
            dockSite1.Name = "dockSite1";
            dockSite1.TabStop = false;
            dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(dockSite2, "dockSite2");
            dockSite2.Name = "dockSite2";
            dockSite2.TabStop = false;
            dotNetBarManager1.BottomDockSite = barBottomDockSite;
            dotNetBarManager1.LeftDockSite = barLeftDockSite;
            dotNetBarManager1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            dotNetBarManager1.MdiSystemItemVisible = false;
            dotNetBarManager1.ParentForm = null;
            dotNetBarManager1.RightDockSite = barRightDockSite;
            dotNetBarManager1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2000;
            dotNetBarManager1.ToolbarBottomDockSite = dockSite4;
            dotNetBarManager1.ToolbarLeftDockSite = dockSite1;
            dotNetBarManager1.ToolbarRightDockSite = dockSite2;
            dotNetBarManager1.ToolbarTopDockSite = dockSite3;
            dotNetBarManager1.TopDockSite = barTopDockSite;
            dockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(dockSite4, "dockSite4");
            dockSite4.Name = "dockSite4";
            dockSite4.TabStop = false;
            dockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(dockSite3, "dockSite3");
            dockSite3.Name = "dockSite3";
            dockSite3.TabStop = false;
            contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(contextMenuStrip1, "contextMenuStrip1");
            contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[2]
            {
                ToolStripMenuItem_Det,
                ToolStripMenuItem_Rep
            });
            contextMenuStrip2.Name = "contextMenuStrip2";
            resources.ApplyResources(contextMenuStrip2, "contextMenuStrip2");
            ToolStripMenuItem_Det.Name = "ToolStripMenuItem_Det";
            resources.ApplyResources(ToolStripMenuItem_Det, "ToolStripMenuItem_Det");
            openFileDialog1.DefaultExt = "*.rtf";
            resources.ApplyResources(openFileDialog1, "openFileDialog1");
            openFileDialog1.FilterIndex = 2;
            saveFileDialog1.DefaultExt = "*.rtf";
            saveFileDialog1.FileName = "doc1";
            resources.ApplyResources(saveFileDialog1, "saveFileDialog1");
            saveFileDialog1.FilterIndex = 2;
            panelEx3.Controls.Add(DGV_Main);
            panelEx3.Controls.Add(ribbonBar_DGV);
            resources.ApplyResources(panelEx3, "panelEx3");
            panelEx3.Name = "panelEx3";
            panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            panelEx3.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            panelEx3.Style.GradientAngle = 90;
            DGV_Main.BackColor = System.Drawing.Color.Transparent;
            background1.BackFillType = DevComponents.DotNetBar.SuperGrid.Style.BackFillType.VerticalCenter;
            background1.Color1 = System.Drawing.Color.Silver;
            background1.Color2 = System.Drawing.Color.White;
            DGV_Main.DefaultVisualStyles.GroupByStyles.Default.Background = background1;
            background2.BackFillType = DevComponents.DotNetBar.SuperGrid.Style.BackFillType.Center;
            background2.Color1 = System.Drawing.Color.LightSteelBlue;
            DGV_Main.DefaultVisualStyles.RowStyles.Default.Background = background2;
            background3.Color1 = System.Drawing.Color.FromArgb(255, 255, 192);
            DGV_Main.DefaultVisualStyles.RowStyles.MouseOver.Background = background3;
            resources.ApplyResources(DGV_Main, "DGV_Main");
            DGV_Main.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            DGV_Main.ForeColor = System.Drawing.Color.Black;
            DGV_Main.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            DGV_Main.Name = "DGV_Main";
            DGV_Main.PrimaryGrid.ActiveRowIndicatorStyle = DevComponents.DotNetBar.SuperGrid.ActiveRowIndicatorStyle.Both;
            DGV_Main.PrimaryGrid.AllowEdit = false;
            DGV_Main.PrimaryGrid.Caption.BackgroundImageLayout = DevComponents.DotNetBar.SuperGrid.GridBackgroundImageLayout.Center;
            DGV_Main.PrimaryGrid.Caption.Text = string.Empty;
            DGV_Main.PrimaryGrid.Caption.Visible = false;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.TextColor = System.Drawing.Color.Black;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.TextColor = System.Drawing.Color.Black;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.CaptionStyles.Default.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            DGV_Main.PrimaryGrid.DefaultVisualStyles.CaptionStyles.Default.TextColor = System.Drawing.Color.White;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.CaptionStyles.ReadOnly.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.CellStyles.Selected.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderRowStyles.Default.RowHeader.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            borderColor1.Bottom = System.Drawing.Color.Black;
            borderColor1.Left = System.Drawing.Color.Black;
            borderColor1.Right = System.Drawing.Color.Black;
            borderColor1.Top = System.Drawing.Color.Black;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.BorderColor = borderColor1;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.TextColor = System.Drawing.Color.SteelBlue;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.TextColor = System.Drawing.Color.White;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.FooterStyles.Default.TextColor = System.Drawing.Color.White;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            borderColor2.Bottom = System.Drawing.Color.Black;
            borderColor2.Left = System.Drawing.Color.Black;
            borderColor2.Right = System.Drawing.Color.Black;
            borderColor2.Top = System.Drawing.Color.Black;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.BorderColor = borderColor2;
            baseTreeButtonVisualStyle1.BorderColor = System.Drawing.Color.White;
            baseTreeButtonVisualStyle1.LineColor = System.Drawing.Color.White;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.CircleTreeButtonStyle.ExpandButton = baseTreeButtonVisualStyle1;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.HeaderHLinePattern = DevComponents.DotNetBar.SuperGrid.Style.LinePattern.None;
            background4.Color1 = System.Drawing.Color.FromArgb(255, 255, 192);
            baseTreeButtonVisualStyle2.Background = background4;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.SquareTreeButtonStyle.ExpandButton = baseTreeButtonVisualStyle2;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.TextColor = System.Drawing.Color.White;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.TitleStyles.Default.RowHeaderStyle.TextAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            DGV_Main.PrimaryGrid.GroupByRow.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.Never;
            DGV_Main.PrimaryGrid.GroupByRow.Text = "جميــع السجــــلات";
            DGV_Main.PrimaryGrid.GroupByRow.Visible = true;
            DGV_Main.PrimaryGrid.GroupByRow.WatermarkText = string.Empty;
            DGV_Main.PrimaryGrid.InitialActiveRow = DevComponents.DotNetBar.SuperGrid.RelativeRow.None;
            DGV_Main.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.None;
            DGV_Main.PrimaryGrid.MultiSelect = false;
            DGV_Main.PrimaryGrid.ShowRowGridIndex = true;
            DGV_Main.PrimaryGrid.Title.AllowSelection = false;
            DGV_Main.PrimaryGrid.Title.Text = string.Empty;
            DGV_Main.PrimaryGrid.Title.Visible = false;
            DGV_Main.PrimaryGrid.Visible = false;
            ribbonBar_DGV.AutoOverflowEnabled = true;
            ribbonBar_DGV.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar_DGV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar_DGV.ContainerControlProcessDialogKey = true;
            ribbonBar_DGV.Controls.Add(superTabControl_DGV);
            resources.ApplyResources(ribbonBar_DGV, "ribbonBar_DGV");
            ribbonBar_DGV.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            ribbonBar_DGV.Name = "ribbonBar_DGV";
            ribbonBar_DGV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ribbonBar_DGV.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar_DGV.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar_DGV.TitleVisible = false;
            superTabControl_DGV.BackColor = System.Drawing.Color.White;
            superTabControl_DGV.CausesValidation = false;
            superTabControl_DGV.ControlBox.CloseBox.Name = string.Empty;
            superTabControl_DGV.ControlBox.MenuBox.Name = string.Empty;
            superTabControl_DGV.ControlBox.Name = string.Empty;
            superTabControl_DGV.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[2]
            {
                superTabControl_DGV.ControlBox.MenuBox,
                superTabControl_DGV.ControlBox.CloseBox
            });
            superTabControl_DGV.ControlBox.Visible = false;
            resources.ApplyResources(superTabControl_DGV, "superTabControl_DGV");
            superTabControl_DGV.ForeColor = System.Drawing.Color.Black;
            superTabControl_DGV.ItemPadding.Bottom = 4;
            superTabControl_DGV.ItemPadding.Left = 4;
            superTabControl_DGV.ItemPadding.Right = 4;
            superTabControl_DGV.ItemPadding.Top = 4;
            superTabControl_DGV.Name = "superTabControl_DGV";
            superTabControl_DGV.ReorderTabsEnabled = true;
            superTabControl_DGV.SelectedTabIndex = -1;
            superTabControl_DGV.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[4]
            {
                textBox_search,
                Button_ExportTable2,
                Button_PrintTable,
                labelItem3
            });
            superTabControl_DGV.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            superTabControl_DGV.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            textBox_search.ButtonCustom.Text = resources.GetString("textBox_search.ButtonCustom.Text");
            textBox_search.ButtonCustom.Visible = true;
            textBox_search.Name = "textBox_search";
            resources.ApplyResources(textBox_search, "textBox_search");
            textBox_search.TextBoxHeight = 44;
            textBox_search.TextBoxWidth = 150;
            textBox_search.WatermarkColor = System.Drawing.SystemColors.GrayText;
            Button_ExportTable2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_ExportTable2.FontBold = true;
            Button_ExportTable2.FontItalic = true;
            Button_ExportTable2.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            Button_ExportTable2.Image = (System.Drawing.Image)resources.GetObject("Button_ExportTable2.Image");
            Button_ExportTable2.ImageFixedSize = new System.Drawing.Size(32, 32);
            Button_ExportTable2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_ExportTable2.Name = "Button_ExportTable2";
            Button_ExportTable2.SubItemsExpandWidth = 14;
            Button_ExportTable2.Symbol = "\uf064";
            Button_ExportTable2.SymbolSize = 15f;
            resources.ApplyResources(Button_ExportTable2, "Button_ExportTable2");
            Button_PrintTable.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_PrintTable.Checked = true;
            Button_PrintTable.FontBold = true;
            Button_PrintTable.FontItalic = true;
            Button_PrintTable.Image = (System.Drawing.Image)resources.GetObject("Button_PrintTable.Image");
            Button_PrintTable.ImageFixedSize = new System.Drawing.Size(32, 32);
            Button_PrintTable.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_PrintTable.Name = "Button_PrintTable";
            Button_PrintTable.SubItemsExpandWidth = 14;
            Button_PrintTable.Symbol = "\uf0c5";
            Button_PrintTable.SymbolSize = 15f;
            resources.ApplyResources(Button_PrintTable, "Button_PrintTable");
            labelItem3.Name = "labelItem3";
            labelItem3.Width = 40;
            panelEx2.Controls.Add(ribbonBar1);
            panelEx2.Controls.Add(ribbonBar_Tasks);
            resources.ApplyResources(panelEx2, "panelEx2");
            panelEx2.MinimumSize = new System.Drawing.Size(658, 516);
            panelEx2.Name = "panelEx2";
            panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            panelEx2.Style.GradientAngle = 90;
            ribbonBar_Tasks.AutoOverflowEnabled = true;
            ribbonBar_Tasks.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar_Tasks.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar_Tasks.ContainerControlProcessDialogKey = true;
            ribbonBar_Tasks.Controls.Add(superTabControl_Main1);
            ribbonBar_Tasks.Controls.Add(superTabControl_Main2);
            resources.ApplyResources(ribbonBar_Tasks, "ribbonBar_Tasks");
            ribbonBar_Tasks.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            ribbonBar_Tasks.Name = "ribbonBar_Tasks";
            ribbonBar_Tasks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ribbonBar_Tasks.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar_Tasks.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar_Tasks.TitleVisible = false;
            superTabControl_Main1.BackColor = System.Drawing.Color.White;
            superTabControl_Main1.CausesValidation = false;
            superTabControl_Main1.ControlBox.CloseBox.Name = string.Empty;
            superTabControl_Main1.ControlBox.MenuBox.Name = string.Empty;
            superTabControl_Main1.ControlBox.Name = string.Empty;
            superTabControl_Main1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[2]
            {
                superTabControl_Main1.ControlBox.MenuBox,
                superTabControl_Main1.ControlBox.CloseBox
            });
            superTabControl_Main1.ControlBox.Visible = false;
            resources.ApplyResources(superTabControl_Main1, "superTabControl_Main1");
            superTabControl_Main1.ForeColor = System.Drawing.Color.Black;
            superTabControl_Main1.ItemPadding.Bottom = 4;
            superTabControl_Main1.ItemPadding.Left = 2;
            superTabControl_Main1.ItemPadding.Top = 4;
            superTabControl_Main1.Name = "superTabControl_Main1";
            superTabControl_Main1.ReorderTabsEnabled = true;
            superTabControl_Main1.SelectedTabIndex = -1;
            superTabControl_Main1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[6]
            {
                Button_Close,
                Button_Search,
                Button_Delete,
                Button_Save,
                Button_Add,
                labelItem2
            });
            superTabControl_Main1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            superTabControl_Main1.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            Button_Close.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_Close.Checked = true;
            Button_Close.FontBold = true;
            Button_Close.FontItalic = true;
            Button_Close.ForeColor = System.Drawing.Color.Black;
            Button_Close.Image = (System.Drawing.Image)resources.GetObject("Button_Close.Image");
            Button_Close.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_Close.ImagePaddingHorizontal = 15;
            Button_Close.ImagePaddingVertical = 11;
            Button_Close.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_Close.Name = "Button_Close";
            Button_Close.Stretch = true;
            Button_Close.SubItemsExpandWidth = 14;
            Button_Close.Symbol = "\uf057";
            Button_Close.SymbolSize = 15f;
            resources.ApplyResources(Button_Close, "Button_Close");
            Button_Search.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_Search.FontBold = true;
            Button_Search.FontItalic = true;
            Button_Search.ForeColor = System.Drawing.Color.Green;
            Button_Search.Image = (System.Drawing.Image)resources.GetObject("Button_Search.Image");
            Button_Search.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_Search.ImagePaddingHorizontal = 15;
            Button_Search.ImagePaddingVertical = 11;
            Button_Search.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_Search.Name = "Button_Search";
            Button_Search.Stretch = true;
            Button_Search.SubItemsExpandWidth = 14;
            Button_Search.Symbol = "\uf002";
            Button_Search.SymbolSize = 15f;
            resources.ApplyResources(Button_Search, "Button_Search");
            Button_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_Delete.FontBold = true;
            Button_Delete.FontItalic = true;
            Button_Delete.ForeColor = System.Drawing.Color.SteelBlue;
            Button_Delete.Image = (System.Drawing.Image)resources.GetObject("Button_Delete.Image");
            Button_Delete.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_Delete.ImagePaddingHorizontal = 15;
            Button_Delete.ImagePaddingVertical = 11;
            Button_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_Delete.Name = "Button_Delete";
            Button_Delete.Stretch = true;
            Button_Delete.SubItemsExpandWidth = 14;
            Button_Delete.Symbol = "\uf014";
            Button_Delete.SymbolSize = 15f;
            resources.ApplyResources(Button_Delete, "Button_Delete");
            Button_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_Save.FontBold = true;
            Button_Save.FontItalic = true;
            Button_Save.ForeColor = System.Drawing.Color.FromArgb(192, 64, 0);
            Button_Save.Image = (System.Drawing.Image)resources.GetObject("Button_Save.Image");
            Button_Save.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_Save.ImagePaddingHorizontal = 15;
            Button_Save.ImagePaddingVertical = 11;
            Button_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_Save.Name = "Button_Save";
            Button_Save.Stretch = true;
            Button_Save.SubItemsExpandWidth = 14;
            Button_Save.Symbol = "\uf0c7";
            Button_Save.SymbolSize = 15f;
            resources.ApplyResources(Button_Save, "Button_Save");
            Button_Add.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_Add.FontBold = true;
            Button_Add.FontItalic = true;
            Button_Add.ForeColor = System.Drawing.Color.Blue;
            Button_Add.Image = (System.Drawing.Image)resources.GetObject("Button_Add.Image");
            Button_Add.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_Add.ImagePaddingHorizontal = 15;
            Button_Add.ImagePaddingVertical = 11;
            Button_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_Add.Name = "Button_Add";
            Button_Add.Stretch = true;
            Button_Add.SubItemsExpandWidth = 14;
            Button_Add.Symbol = "\uf055";
            Button_Add.SymbolSize = 15f;
            resources.ApplyResources(Button_Add, "Button_Add");
            labelItem2.Name = "labelItem2";
            labelItem2.Width = 40;
            superTabControl_Main2.BackColor = System.Drawing.Color.White;
            superTabControl_Main2.CausesValidation = false;
            superTabControl_Main2.ControlBox.CloseBox.Name = string.Empty;
            superTabControl_Main2.ControlBox.MenuBox.Name = string.Empty;
            superTabControl_Main2.ControlBox.Name = string.Empty;
            superTabControl_Main2.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[2]
            {
                superTabControl_Main2.ControlBox.MenuBox,
                superTabControl_Main2.ControlBox.CloseBox
            });
            superTabControl_Main2.ControlBox.Visible = false;
            resources.ApplyResources(superTabControl_Main2, "superTabControl_Main2");
            superTabControl_Main2.ForeColor = System.Drawing.Color.Black;
            superTabControl_Main2.ItemPadding.Bottom = 4;
            superTabControl_Main2.ItemPadding.Left = 4;
            superTabControl_Main2.ItemPadding.Right = 4;
            superTabControl_Main2.ItemPadding.Top = 4;
            superTabControl_Main2.Name = "superTabControl_Main2";
            superTabControl_Main2.ReorderTabsEnabled = true;
            superTabControl_Main2.SelectedTabIndex = -1;
            superTabControl_Main2.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[8]
            {
                labelItem1,
                Button_First,
                Button_Prev,
                TextBox_Index,
                Label_Count,
                lable_Records,
                Button_Next,
                Button_Last
            });
            superTabControl_Main2.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            superTabControl_Main2.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            labelItem1.Name = "labelItem1";
            labelItem1.Width = 2;
            Button_First.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_First.FontBold = true;
            Button_First.FontItalic = true;
            Button_First.ForeColor = System.Drawing.Color.SteelBlue;
            Button_First.Image = (System.Drawing.Image)resources.GetObject("Button_First.Image");
            Button_First.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_First.ImagePaddingHorizontal = 15;
            Button_First.ImagePaddingVertical = 11;
            Button_First.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_First.Name = "Button_First";
            Button_First.SplitButton = true;
            Button_First.Stretch = true;
            Button_First.SubItemsExpandWidth = 14;
            Button_First.Symbol = "\uf051";
            Button_First.SymbolSize = 15f;
            resources.ApplyResources(Button_First, "Button_First");
            Button_Prev.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_Prev.FontBold = true;
            Button_Prev.FontItalic = true;
            Button_Prev.ForeColor = System.Drawing.Color.SteelBlue;
            Button_Prev.Image = (System.Drawing.Image)resources.GetObject("Button_Prev.Image");
            Button_Prev.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_Prev.ImagePaddingHorizontal = 15;
            Button_Prev.ImagePaddingVertical = 11;
            Button_Prev.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_Prev.Name = "Button_Prev";
            Button_Prev.SplitButton = true;
            Button_Prev.Stretch = true;
            Button_Prev.SubItemsExpandWidth = 14;
            Button_Prev.Symbol = "\uf04e";
            Button_Prev.SymbolSize = 15f;
            resources.ApplyResources(Button_Prev, "Button_Prev");
            TextBox_Index.Name = "TextBox_Index";
            resources.ApplyResources(TextBox_Index, "TextBox_Index");
            TextBox_Index.TextBoxWidth = 50;
            TextBox_Index.Visible = false;
            TextBox_Index.WatermarkColor = System.Drawing.SystemColors.GrayText;
            Label_Count.Name = "Label_Count";
            Label_Count.Visible = false;
            Label_Count.Width = 40;
            lable_Records.BackColor = System.Drawing.Color.SteelBlue;
            lable_Records.ForeColor = System.Drawing.Color.White;
            lable_Records.Name = "lable_Records";
            resources.ApplyResources(lable_Records, "lable_Records");
            Button_Next.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_Next.FontBold = true;
            Button_Next.FontItalic = true;
            Button_Next.ForeColor = System.Drawing.Color.SteelBlue;
            Button_Next.Image = (System.Drawing.Image)resources.GetObject("Button_Next.Image");
            Button_Next.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_Next.ImagePaddingHorizontal = 15;
            Button_Next.ImagePaddingVertical = 11;
            Button_Next.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_Next.Name = "Button_Next";
            Button_Next.SplitButton = true;
            Button_Next.Stretch = true;
            Button_Next.SubItemsExpandWidth = 14;
            Button_Next.Symbol = "\uf04a";
            Button_Next.SymbolSize = 15f;
            resources.ApplyResources(Button_Next, "Button_Next");
            Button_Last.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_Last.FontBold = true;
            Button_Last.FontItalic = true;
            Button_Last.ForeColor = System.Drawing.Color.SteelBlue;
            Button_Last.Image = (System.Drawing.Image)resources.GetObject("Button_Last.Image");
            Button_Last.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_Last.ImagePaddingHorizontal = 15;
            Button_Last.ImagePaddingVertical = 11;
            Button_Last.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_Last.Name = "Button_Last";
            Button_Last.SplitButton = true;
            Button_Last.Stretch = true;
            Button_Last.SubItemsExpandWidth = 14;
            Button_Last.Symbol = "\uf048";
            Button_Last.SymbolSize = 15f;
            resources.ApplyResources(Button_Last, "Button_Last");
            expandableSplitter1.BackColor = System.Drawing.Color.FromArgb(227, 239, 255);
            expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(101, 147, 207);
            expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            resources.ApplyResources(expandableSplitter1, "expandableSplitter1");
            expandableSplitter1.ExpandableControl = panelEx2;
            expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(0, 45, 150);
            expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            expandableSplitter1.ExpandLineColor = System.Drawing.SystemColors.ControlText;
            expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            expandableSplitter1.ForeColor = System.Drawing.Color.Black;
            expandableSplitter1.GripDarkColor = System.Drawing.SystemColors.ControlText;
            expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(223, 237, 254);
            expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(254, 142, 75);
            expandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(255, 207, 139);
            expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(0, 45, 150);
            expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            expandableSplitter1.HotExpandLineColor = System.Drawing.SystemColors.ControlText;
            expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(0, 45, 150);
            expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(223, 237, 254);
            expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            expandableSplitter1.Name = "expandableSplitter1";
            expandableSplitter1.TabStop = false;
            panel1.Controls.Add(panelEx3);
            panel1.Controls.Add(expandableSplitter1);
            panel1.Controls.Add(panelEx2);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(panel1);
            base.Controls.Add(Rep_RecCount);
            base.Controls.Add(barTopDockSite);
            base.Controls.Add(barBottomDockSite);
            base.Controls.Add(barLeftDockSite);
            base.Controls.Add(barRightDockSite);
            base.Controls.Add(dockSite1);
            base.Controls.Add(dockSite2);
            base.Controls.Add(dockSite3);
            base.Controls.Add(dockSite4);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "FrmEqars";
            base.Load += new System.EventHandler(FrmEqars_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Frm_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(Frm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)Rep_RecCount).EndInit();
            ribbonBar1.ResumeLayout(false);
            ribbonBar1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)FlxAinDet).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtEyes).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtRentContractValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtFloors).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtContractValue).EndInit();
            contextMenuStrip2.ResumeLayout(false);
            panelEx3.ResumeLayout(false);
            ribbonBar_DGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)superTabControl_DGV).EndInit();
            panelEx2.ResumeLayout(false);
            ribbonBar_Tasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)superTabControl_Main1).EndInit();
            ((System.ComponentModel.ISupportInitialize)superTabControl_Main2).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
