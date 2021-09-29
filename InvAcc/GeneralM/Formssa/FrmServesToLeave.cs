using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using Framework.Data;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Library.RepShow;
using Microsoft.Win32;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmServesToLeave : Form
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
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private T_AccDef _AccDefBind = new T_AccDef();
        private int LangArEn = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
        private string FlagUpdate = "";
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstance;
        private T_tran data_this;
        private bool Pas;
        private string Ps;
        private bool vChk;
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
        private T_GDHEAD _GdHead = new T_GDHEAD();
        private List<T_GDHEAD> listGdHead = new List<T_GDHEAD>();
        private T_GDDET _GdDet = new T_GDDET();
        private List<T_GDDET> listGdDet = new List<T_GDDET>();
        private ScriptNumber ScriptNumber1 = new ScriptNumber();
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
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


        private Timer timer1;
        private ExpandableSplitter expandableSplitter1;
        private PanelEx panelEx2;
        private RibbonBar ribbonBar1;
        private SaveFileDialog saveFileDialog1;
        protected SuperGridControl DGV_Main;
        private PanelEx panelEx3;
        private Timer timerInfoBallon;
        private OpenFileDialog openFileDialog1;
        private Panel panel1;
        private DockSite barTopDockSite;
        private DockSite barBottomDockSite;
        public DotNetBarManager dotNetBarManager1;
        private ImageList imageList1;
        private DockSite barLeftDockSite;
        private DockSite barRightDockSite;
        private DockSite dockSite4;
        private DockSite dockSite1;
        private DockSite dockSite2;
        private DockSite dockSite3;
        protected ContextMenuStrip contextMenuStrip1;
        protected ToolStripMenuItem ToolStripMenuItem_Rep;
        protected ToolStripMenuItem ToolStripMenuItem_Det;
        protected ContextMenuStrip contextMenuStrip2;
        private RibbonBar ribbonBar_Tasks;
        private SuperTabControl superTabControl_Main2;
        protected LabelItem labelItem1;
        protected ButtonItem Button_First;
        protected ButtonItem Button_Prev;
        protected TextBoxItem TextBox_Index;
        protected LabelItem Label_Count;
        protected ButtonItem Button_Next;
        protected ButtonItem Button_Last;
        private SuperTabControl superTabControl_Main1;
        protected ButtonItem Button_Close;
        protected ButtonItem Button_Save;
        private RibbonBar ribbonBar_DGV;
        private SuperTabControl superTabControl_DGV;
        protected TextBoxItem textBox_search;
        protected ButtonItem Button_ExportTable2;
        protected ButtonItem Button_PrintTable;
        protected LabelItem labelItem3;
        private LabelItem lable_Records;
        private Panel panel2;
        protected TextBox textBox_ID;
        private Label label2;
        private ComboBoxEx Cmb_GuestNm;
        internal Label label13z;
        private Label label1;
        private ComboBoxEx Cmb_ServiceTyp;
        internal Label label6z;
        private MaskedTextBox txtDate;
        protected Label label3;
        private DoubleInput txtValue;
        private Label label8;
        private TextBox txtDetails;
        internal Label label4;
        protected ButtonItem Button_Search;
        private TextBox txtTime;
        private SwitchButton switchButton_Lock;
        private Panel panel_Gaid;
        private ButtonX button_CustC1;
        private ButtonX button_CustD1;
        private TextBoxX txtDebit1;
        private TextBoxX txtCredit1;
        internal Label labelD1;
        internal Label labelC1;
        internal Label labelGuestStat;
        private TextBox txtRoom;
        internal Label labelGaidStat;
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
        public T_tran DataThis
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
                    if (!VarGeneral.TString.ChkStatShow(value.RepAcc2, 2))
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                }
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
            List<T_tran> list = db.FilltranToLeave_2(textBox_search.TextBox.Text).ToList();
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
        }
        public void FillHDGV(IEnumerable<T_tran> new_data_enum)
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
            DGV_Main.PrimaryGrid.DataMember = "T_tran";
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
        private void TextBox_Search_InputTextChanged(object sender)
        {
            Fill_DGV_Main();
        }
        public void Clear()
        {
            if (State == FormState.New)
            {
                return;
            }
            State = FormState.New;
            data_this = new T_tran();
            _GdHead = new T_GDHEAD();
            State = FormState.New;
            int? calendr;
            for (int i = 0; i < controls.Count; i++)
            {
                if (controls[i].GetType() == typeof(DateTimePicker))
                {
                    calendr = VarGeneral.Settings_Sys.Calendr;
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
            Pas = false;
            Ps = "";
            switchButton_Lock.Value = false;
            labelGaidStat.Visible = false;
            vChk = false;
            Ps = VarGeneral.UserNo;
            MaskedTextBox maskedTextBox = txtDate;
            calendr = VarGeneral.Settings_Sys.Calendr;
            maskedTextBox.Text = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
            string xx = DateTime.Now.ToString("hh:mm:ss tt");
            txtTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
            textBox_ID.Focus();
            SetReadOnly = false;
        }
        private void Button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void DGV_Main_CellClick(object sender, GridCellClickEventArgs e)
        {
            DGV_Main.PrimaryGrid.Tag = e.GridCell.RowIndex;
        }
        private void DGV_Main_CellDoubleClick(object sender, GridCellDoubleClickEventArgs e)
        {
            ToolStripMenuItem_Det_Click(sender, e);
        }
        private void textBox_ID_Click(object sender, EventArgs e)
        {
            textBox_ID.SelectAll();
        }
        private void textBox_NameA_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("Arabic");
        }
        private void textBox_NameE_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("English");
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
        private void Frm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && Button_Save.Enabled && Button_Save.Visible && State != 0)
            {
                Button_Save_Click(sender, e);
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
            var qkeys = from item in db.T_trans
                        where item.T_per.ch == (int?)3
                        select new
                        {
                            Code = item.fat + ""
                        };
            int count = 0;
            foreach (var item2 in qkeys)
            {
                count++;
                PKeys.Add(item2.Code);
            }
            try
            {
                PKeys = PKeys.OrderBy((string c) => int.Parse(c)).ToList();
            }
            catch
            {
            }
            Label_Count.Text = string.Concat(count);
            UpdateVcr();
        }
        public FrmServesToLeave()
        {
            InitializeComponent();
            controls = new List<Control>();
            controls.Add(textBox_ID);
            codeControl = textBox_ID;
            controls.Add(txtDate);
            controls.Add(txtDetails);
            controls.Add(txtTime);
            controls.Add(txtValue);
            controls.Add(Cmb_GuestNm);
            controls.Add(txtRoom);
            controls.Add(Cmb_ServiceTyp);
            controls.Add(txtDebit1);
            controls.Add(txtCredit1);
            controls.Add(switchButton_Lock);
            Button_Close.Click += Button_Close_Click;
            txtDate.Click += Button_Edit_Click;
            txtDetails.Click += Button_Edit_Click;
            txtTime.Click += Button_Edit_Click;
            txtValue.Click += Button_Edit_Click;
            Cmb_GuestNm.Click += Button_Edit_Click;
            Cmb_ServiceTyp.Click += Button_Edit_Click;
            txtDebit1.Click += Button_Edit_Click;
            txtCredit1.Click += Button_Edit_Click;
            expandableSplitter1.Click += expandableSplitter1_Click;
            ToolStripMenuItem_Det.Click += ToolStripMenuItem_Det_Click;
            Button_ExportTable2.Click += Button_ExportTable2_Click;
            Button_First.Click += Button_First_Click;
            Button_Prev.Click += Button_Prev_Click;
            Button_Next.Click += Button_Next_Click;
            Button_Last.Click += Button_Last_Click;
            Button_Save.Click += Button_Save_Click;
            Button_Search.Click += Button_Search_Click;
            txtDebit1.ButtonCustomClick += txtDebit1_ButtonCustomClick;
            txtCredit1.ButtonCustomClick += txtCredit1_ButtonCustomClick;
            textBox_search.InputTextChanged += TextBox_Search_InputTextChanged;
            textBox_search.ButtonCustomClick += TextBox_Search_ButtonCustomClick;
            TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
            DGV_Main.MouseDown += DGV_Main_MouseDown;
            DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
            DGV_Main.CellClick += DGV_Main_CellClick;
            DGV_Main.GetCellStyle += DGV_MainGetCellStyle;
            DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
            DGV_Main.DataBindingComplete += DGV_Main_DataBindingComplete;
            Button_PrintTable.Click += Button_Print_Click;
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmServesToLeave));
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
                Button_Close.Text = "اغلاق";
                Button_Save.Text = "حفظ";
                Button_Search.Text = "بحث";
                Button_First.Tooltip = "السجل الاول";
                Button_Last.Tooltip = "السجل الاخير";
                Button_Next.Tooltip = "السجل التالي";
                Button_Prev.Tooltip = "السجل السابق";
                Button_Close.Tooltip = "Esc";
                Button_Save.Tooltip = "F2";
                Button_Search.Tooltip = "F4";
                Button_PrintTable.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "طباعة" : "عــرض");
                Button_PrintTable.Tooltip = "F5";
                Button_ExportTable2.Text = "تصدير";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "جميع السجلات";
                switchButton_Lock.OffText = "إنشاء قيد محاسبي";
                switchButton_Lock.OnText = "إنشاء قيد محاسبي";
                Text = "الخدمات المقدمة للنزلاء المغادرين";
            }
            else
            {
                Button_First.Text = "First";
                Button_Last.Text = "Last";
                Button_Next.Text = "Next";
                Button_Prev.Text = "Previous";
                Button_Close.Text = "Close";
                Button_Save.Text = "Save";
                Button_Search.Text = "Search";
                Button_First.Tooltip = "First Record";
                Button_Last.Tooltip = "Last Record";
                Button_Next.Tooltip = "Next Record";
                Button_Prev.Tooltip = "Previous Record";
                Button_Close.Tooltip = "Esc";
                Button_Save.Tooltip = "F2";
                Button_Search.Tooltip = "F4";
                Button_PrintTable.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "Print" : "Show");
                Button_PrintTable.Tooltip = "F5";
                Button_ExportTable2.Text = "Export";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "All Records";
                switchButton_Lock.OffText = "Create an accounting record";
                switchButton_Lock.OnText = "Create an accounting record";
                labelGuestStat.Text = "Guest Leaved";
                labelGaidStat.Text = "The accounting record was derecognized at the close of the year";
                Text = "Services Offered to Departing Guests";
            }
        }
        private void FrmServesToLeave_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmServesToLeave));
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
                Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
                if (columns_Names_visible.Count == 0)
                {
                    columns_Names_visible.Add("fat", new ColumnDictinary("رقم الأمــر", "Order No", ifDefault: true, ""));
                    columns_Names_visible.Add("nm", new ColumnDictinary("الاسم", "Name", ifDefault: true, ""));
                    columns_Names_visible.Add("romno", new ColumnDictinary("رقم الغرفة", "Room No", ifDefault: true, ""));
                    columns_Names_visible.Add("price", new ColumnDictinary("قيمة الخدمة", "Service Value", ifDefault: true, ""));
                }
                else
                {
                    Clear();
                    textBox_ID.Text = "";
                    TextBox_Index.TextBox.Text = "";
                }
                RibunButtons();
                RefreshPKeys();
                FillCombo();
                textBox_ID.Text = PKeys.FirstOrDefault();
                ViewDetails_Click(sender, e);
                UpdateVcr();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
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
                T_tran newData = db.StockTran(no);
                if (newData == null || newData.ID == 0)
                {
                    Clear();
                    TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                    TextBox_Index.TextBox.Text = string.Concat(PKeys.Count + 1);
                    TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                }
                else
                {
                    DataThis = newData;
                    int indexA = PKeys.IndexOf(string.Concat(newData.fat));
                    indexA++;
                    TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                    TextBox_Index.TextBox.Text = string.Concat(indexA);
                    TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                }
            }
            catch
            {
            }
            UpdateVcr();
        }
        private void FillCombo()
        {
            List<T_sertyp> listServicType = new List<T_sertyp>(db.T_sertyps.Select((T_sertyp item) => item).ToList());
            Cmb_ServiceTyp.DataSource = null;
            Cmb_ServiceTyp.DataSource = listServicType;
            Cmb_ServiceTyp.DisplayMember = ((LangArEn == 0) ? "Arb_Des" : "Eng_Des");
            Cmb_ServiceTyp.ValueMember = "Serv_ID";
            List<T_per> listGuest = new List<T_per>(db.T_pers.Where((T_per item) => item.ch == (int?)3 && item.romno.HasValue).ToList());
            Cmb_GuestNm.DataSource = null;
            Cmb_GuestNm.DataSource = listGuest;
            Cmb_GuestNm.DisplayMember = "nm";
            Cmb_GuestNm.ValueMember = "perno";
        }
        public void SetData(T_tran value)
        {
            try
            {
                switchButton_Lock.ValueChanged -= switchButton_Lock_ValueChanged;
                State = FormState.Saved;
                Button_Save.Enabled = false;
                textBox_ID.Tag = value.ID;
                txtDate.Text = value.dt;
                txtTime.Text = value.tm;
                txtDetails.Text = value.detal;
                txtValue.Value = value.price.Value;
                Cmb_GuestNm.SelectedValue = value.perno;
                txtRoom.Text = value.romno.Value.ToString();
                txtDebit1.Text = "";
                txtCredit1.Text = "";
                if (value.GadeId.HasValue)
                {
                    listGdHead = db.StockGdHeadid((int)value.GadeId.Value);
                    if (listGdHead.Count != 0)
                    {
                        _GdHead = listGdHead[0];
                        listGdDet = _GdHead.T_GDDETs.ToList();
                        for (int i = 0; i < listGdDet.Count; i++)
                        {
                            if (listGdDet[i].Lin == 1)
                            {
                                if (listGdDet[i].gdValue > 0.0)
                                {
                                    txtDebit1.Tag = listGdDet[i].AccNo;
                                    txtDebit1.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(listGdDet[i].AccNo).Arb_Des : db.SelectAccRootByCode(listGdDet[i].AccNo).Eng_Des);
                                }
                                else
                                {
                                    txtCredit1.Tag = listGdDet[i].AccNo;
                                    txtCredit1.Text = ((LangArEn == 0) ? db.SelectAccRootByCode(listGdDet[i].AccNo).Arb_Des : db.SelectAccRootByCode(listGdDet[i].AccNo).Eng_Des);
                                }
                            }
                        }
                    }
                    else
                    {
                        _GdHead = new T_GDHEAD();
                    }
                }
                try
                {
                    switchButton_Lock.Value = value.IsGaid.Value;
                    panel_Gaid.Enabled = value.IsGaid.Value;
                }
                catch
                {
                    switchButton_Lock.Value = false;
                    panel_Gaid.Enabled = false;
                }
                if (data_this.GadeNo == 0.0 && VarGeneral.UserID != 1)
                {
                    labelGaidStat.Visible = true;
                }
                else
                {
                    labelGaidStat.Visible = false;
                }
                switchButton_Lock.ValueChanged += switchButton_Lock_ValueChanged;
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
        private T_tran GetData()
        {
            textBox_ID.Focus();
            data_this.fat = int.Parse(textBox_ID.Text);
            data_this.detal = txtDetails.Text;
            data_this.dt = txtDate.Text;
            data_this.perno = int.Parse(Cmb_GuestNm.SelectedValue.ToString());
            data_this.price = txtValue.Value;
            data_this.romno = int.Parse(txtRoom.Text);
            data_this.tm = txtTime.Text;
            data_this.Usr = VarGeneral.UserNo;
            data_this.typ = int.Parse(Cmb_ServiceTyp.SelectedValue.ToString());
            data_this.IsGaid = switchButton_Lock.Value;
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
        private bool CheckRemotDate()
        {
            try
            {
                if (VarGeneral.gUserName != "runsetting")
                {
                    bool User_Remotly = CheckUserIFRemote();
                    RegistryKey hKeyNew = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", writable: true);
                    RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
                    long regval = 0L;
                    long regvalNew = 0L;
                    if (hKey != null)
                    {
                        try
                        {
                            object q = hKey.GetValue("vRemotly");
                            if (string.IsNullOrEmpty(q.ToString()))
                            {
                                hKey.CreateSubKey("vRemotly");
                                hKey.SetValue("vRemotly", "0");
                            }
                        }
                        catch
                        {
                            hKey.CreateSubKey("vRemotly");
                            hKey.SetValue("vRemotly", "0");
                        }
                        try
                        {
                            object t = hKeyNew.GetValue("vRemotly_New");
                            if (string.IsNullOrEmpty(t.ToString()))
                            {
                                hKeyNew.CreateSubKey("vRemotly_New");
                                hKeyNew.SetValue("vRemotly_New", "0");
                            }
                        }
                        catch
                        {
                            hKeyNew.CreateSubKey("vRemotly_New");
                            hKeyNew.SetValue("vRemotly_New", "0");
                        }
                        regval = long.Parse(hKey.GetValue("vRemotly").ToString());
                        regvalNew = long.Parse(hKeyNew.GetValue("vRemotly_New").ToString());
                    }
                    if (User_Remotly || regval == 1 || regvalNew == 1)
                    {
                        try
                        {
                            if (VarGeneral.vDemo)
                            {
                                return false;
                            }
                            string dtAction = (n.IsHijri(txtDate.Text) ? txtDate.Text : n.GregToHijri(txtDate.Text, "yyyy/MM/dd"));
                            if (Convert.ToDateTime(n.GregToHijri(hKeyNew.GetValue("vBackup_New").ToString(), "yyyy/MM/dd")) < Convert.ToDateTime(n.FormatHijri(dtAction, "yyyy/MM/dd")))
                            {
                                MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. لقد تخطيت السنة المالية المحدد للنظام \n يرجى التواصل مع الإدارة لللإشتراك في خدمات النسخة " : "We can not complete the operation .. have you skip the fiscal year specified for the system", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return false;
                            }
                        }
                        catch
                        {
                            MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. لقد تخطيت السنة المالية المحدد للنظام \n يرجى التواصل مع الإدارة لللإشتراك في خدمات النسخة " : "We can not complete the operation .. have you skip the fiscal year specified for the system", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return false;
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        private bool CheckUserIFRemote()
        {
            try
            {
               return false; if (SystemInformation.TerminalServerSession)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return true;
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
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (State == FormState.New)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                textBox_ID.Focus();
                if (textBox_ID.Text == "" || string.IsNullOrEmpty(Cmb_GuestNm.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الرقم او الإسم فارغا\u0651" : "Can not be a number or name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (string.IsNullOrEmpty(txtRoom.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "لايمكن ان رقم الغرفة فارغا" : "Can not be Room No is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (txtValue.Value <= 0.0)
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من قيمة الخدمة" : "Make sure the value of the service", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (switchButton_Lock.Value && (string.IsNullOrEmpty(txtCredit1.Text) || string.IsNullOrEmpty(txtDebit1.Text)))
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف الدائن والمدين للقيد .. " : "You can not complete the operation .. Make sure the creditor and debitor under the party ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (false)
                {
                    Environment.Exit(0);
                    return;
                }
                if (State == FormState.New)
                {
                    GetData();
                    try
                    {
                        db.T_trans.InsertOnSubmit(data_this);
                        db.SubmitChanges();
                    }
                    catch (SqlException ex)
                    {
                        int max = 0;
                        max = db.MaxTranNo;
                        if (ex.Number != 2627)
                        {
                            return;
                        }
                        MessageBox.Show("رقم الوحدة مستخدم من قبل.\n سيتم الحفظ برقم جديد [" + max + "]", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question);
                        textBox_ID.Text = string.Concat(max);
                        data_this.fat = max;
                        Button_Save_Click(sender, e);
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
                else if (State == FormState.Edit)
                {
                    GetData();
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
                string AccCrdt = "";
                string AccDbt = "";
                if (!switchButton_Lock.Value)
                {
                    goto IL_0441;
                }
                if (txtValue.Value > 0.0)
                {
                    AccCrdt = txtCredit1.Tag.ToString();
                    AccDbt = txtDebit1.Tag.ToString();
                }
                if (AccCrdt == "" && txtValue.Value > 0.0)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف الدائن للقيد .. " : "You can not complete the operation .. Make sure the creditor under the party ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (!(AccDbt == "") || !(txtValue.Value > 0.0))
                {
                    goto IL_0441;
                }
                MessageBox.Show((LangArEn == 0) ? "لا يمكن إتمام العملية .. تأكد من صحة الطرف المدين للقيد .. " : "You can not complete the operation .. Make sure the debtor under the party ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                goto end_IL_0001;
            IL_0441:
                if (txtValue.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt) && !string.IsNullOrEmpty(AccDbt))
                {
                    IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
                    Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
                    if (State == FormState.New)
                    {
                        GetDataGd();
                        _GdHead.DATE_CREATED = DateTime.Now;
                        dbc.T_GDHEADs.InsertOnSubmit(_GdHead);
                        dbc.SubmitChanges();
                    }
                    else
                    {
                        dbInstance = null;
                        if (!data_this.GadeId.HasValue)
                        {
                            _GdHead = new T_GDHEAD();
                        }
                        textBox_ID_TextChanged(null, null);
                        GetDataGd();
                        if (!data_this.GadeId.HasValue)
                        {
                            dbc.T_GDHEADs.InsertOnSubmit(_GdHead);
                            dbc.SubmitChanges();
                        }
                        else
                        {
                            db.Log = VarGeneral.DebugLog;
                            db.SubmitChanges(ConflictMode.ContinueOnConflict);
                        }
                        for (int i = 0; i < _GdHead.T_GDDETs.Count; i++)
                        {
                            db_.StartTransaction();
                            db_.ClearParameters();
                            db_.AddParameter("GDDET_ID", DbType.Int32, _GdHead.T_GDDETs[i].GDDET_ID);
                            db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_DELETE");
                            db_.EndTransaction();
                        }
                    }
                    if (txtValue.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt) && !string.IsNullOrEmpty(AccDbt))
                    {
                        db_.StartTransaction();
                        db_.ClearParameters();
                        db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                        db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                        db_.AddParameter("gdNo", DbType.String, textBox_ID.Text);
                        db_.AddParameter("gdDes", DbType.String, "قيد تلقائي لعملية اضافة خدمة نزيل رقم : " + textBox_ID.Text);
                        db_.AddParameter("gdDesE", DbType.String, "Auto Bound to add guest service : " + textBox_ID.Text);
                        db_.AddParameter("recptTyp", DbType.String, "1");
                        db_.AddParameter("AccNo", DbType.String, AccCrdt);
                        db_.AddParameter("AccName", DbType.String, "");
                        db_.AddParameter("gdValue", DbType.Double, 0.0 - double.Parse(txtValue.Text));
                        db_.AddParameter("recptNo", DbType.String, textBox_ID.Text);
                        db_.AddParameter("Lin", DbType.Int32, 1);
                        db_.AddParameter("AccNoDestruction", DbType.String, null);
                        db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                        db_.EndTransaction();
                        db_.StartTransaction();
                        db_.ClearParameters();
                        db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                        db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                        db_.AddParameter("gdNo", DbType.String, textBox_ID.Text);
                        db_.AddParameter("gdDes", DbType.String, "قيد تلقائي لعملية اضافة خدمة نزيل رقم : " + textBox_ID.Text);
                        db_.AddParameter("gdDesE", DbType.String, "Auto Bound to add guest service : " + textBox_ID.Text);
                        db_.AddParameter("recptTyp", DbType.String, "1");
                        db_.AddParameter("AccNo", DbType.String, AccDbt);
                        db_.AddParameter("AccName", DbType.String, "");
                        db_.AddParameter("gdValue", DbType.Double, double.Parse(txtValue.Text));
                        db_.AddParameter("recptNo", DbType.String, textBox_ID.Text);
                        db_.AddParameter("Lin", DbType.Int32, 1);
                        db_.AddParameter("AccNoDestruction", DbType.String, null);
                        db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDDET_INSERT");
                        db_.EndTransaction();
                    }
                }
                else if (State == FormState.Edit && data_this.GadeId.HasValue)
                {
                    db.ExecuteCommand("UPDATE T_GDHEAD SET T_GDHEAD.gdLok = 1  where gdhead_ID = " + data_this.GadeId);
                }
                dbInstance = null;
                textBox_ID_TextChanged(null, null);
                if (txtValue.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt) && !string.IsNullOrEmpty(AccDbt))
                {
                    data_this.IsGaid = true;
                    data_this.GadeId = _GdHead.gdhead_ID;
                    data_this.GadeNo = int.Parse(textBox_ID.Text);
                }
                else
                {
                    data_this.IsGaid = false;
                    data_this.GadeId = null;
                    data_this.GadeNo = null;
                }
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                State = FormState.Saved;
                RefreshPKeys();
                TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(string.Concat(data_this.fat)) + 1);
                textBox_ID_TextChanged(null, null);
                SetReadOnly = true;
            end_IL_0001:;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private T_GDHEAD GetDataGd()
        {
            _GdHead.gdNo = textBox_ID.Text;
            _GdHead.ArbTaf = ScriptNumber1.ScriptNum(decimal.Parse("0" + txtValue.Text));
            _GdHead.BName = _GdHead.BName;
            _GdHead.ChekNo = _GdHead.ChekNo;
            _GdHead.CurTyp = 1;
            _GdHead.EngTaf = ScriptNumber1.TafEng(decimal.Parse("0" + txtValue.Text));
            _GdHead.gdCstNo = 1;
            _GdHead.gdID = 0;
            _GdHead.gdLok = false;
            _GdHead.gdMem = txtDetails.Text;
            _GdHead.gdMnd = null;
            _GdHead.gdRcptID = (_GdHead.gdRcptID.HasValue ? _GdHead.gdRcptID.Value : 0.0);
            _GdHead.gdTot = txtValue.Value;
            _GdHead.gdTp = (_GdHead.gdTp.HasValue ? _GdHead.gdTp.Value : 0);
            _GdHead.gdTyp = VarGeneral.InvTyp;
            _GdHead.RefNo = "";
            _GdHead.AdminLock = false;
            _GdHead.DATE_MODIFIED = DateTime.Now;
            _GdHead.salMonth = "";
            _GdHead.gdUser = VarGeneral.UserNumber;
            _GdHead.gdUserNam = VarGeneral.UserNameA;
            _GdHead.CompanyID = 1;
            return _GdHead;
        }
        private void DGV_Main_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            string dataMember = panel.DataMember;
            if (dataMember != null && dataMember == "T_tran")
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
            panel.Columns["nm"].Width = 300;
            panel.Columns["nm"].Visible = columns_Names_visible["nm"].IfDefault;
            panel.Columns["romno"].Width = 200;
            panel.Columns["romno"].Visible = columns_Names_visible["romno"].IfDefault;
            panel.Columns["price"].Width = 200;
            panel.Columns["price"].Visible = columns_Names_visible["price"].IfDefault;
            panel.Columns["fat"].Width = 200;
            panel.Columns["fat"].Visible = columns_Names_visible["fat"].IfDefault;
            panel.ReadOnly = true;
        }
        private void DGV_MainGetCellStyle(object sender, GridGetCellStyleEventArgs e)
        {
        }
        private void Button_ExportTable2_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcel.ExportToExcel(DGV_Main, "تقرير خدمات النزلاء");
            }
            catch
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
        public void Button_Search_Click(object sender, EventArgs e)
        {
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_tranToLeave";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                textBox_ID.Text = frm.SerachNo.ToString();
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
                _RepShow.Tables = " T_tran left join T_SYSSETTING on T_SYSSETTING.SYSSETTING_ID = T_tran.CompanyID ";
                string Fields = "";
                Fields = " T_tran.fat as No, T_tran.Arb_Des as NmA, T_tran.Eng_Des as NmE,T_SYSSETTING.LogImg ";
                _RepShow.Rule = "";
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
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }
        private void txtDate_Leave(object sender, EventArgs e)
        {
        }
        private void txtDate_Click(object sender, EventArgs e)
        {
            txtDate.SelectAll();
        }
        private void txtTime_Click(object sender, EventArgs e)
        {
            txtTime.SelectAll();
        }
        private void txtDebit1_ButtonCustomClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            Button_Edit_Click(sender, e);
            columns_Names_visible2.Clear();
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
            columns_Names_visible2.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            if (VarGeneral.SSSTyp == 0)
            {
                VarGeneral.SFrmTyp = "T_AccDef";
                VarGeneral.AccTyp = 4;
            }
            else
            {
                VarGeneral.SFrmTyp = "AccDefID_Setting";
            }
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != "")
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtDebit1.Tag = _AccDef.AccDef_No;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtDebit1.Text = _AccDef.Arb_Des;
                    }
                    else
                    {
                        txtDebit1.Text = _AccDef.Eng_Des;
                    }
                }
                else
                {
                    txtDebit1.Text = "";
                    txtDebit1.Tag = "";
                }
            }
            catch
            {
                txtDebit1.Text = "";
                txtDebit1.Tag = "";
            }
        }
        private void txtCredit1_ButtonCustomClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_ID.Text))
            {
                return;
            }
            Button_Edit_Click(sender, e);
            columns_Names_visible2.Clear();
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
            columns_Names_visible2.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            if (VarGeneral.SSSTyp == 0)
            {
                VarGeneral.SFrmTyp = "T_AccDef";
                VarGeneral.AccTyp = 4;
            }
            else
            {
                VarGeneral.SFrmTyp = "AccDefID_Setting";
            }
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != "")
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtCredit1.Tag = _AccDef.AccDef_No;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        txtCredit1.Text = _AccDef.Arb_Des;
                    }
                    else
                    {
                        txtCredit1.Text = _AccDef.Eng_Des;
                    }
                }
                else
                {
                    txtCredit1.Text = "";
                    txtCredit1.Tag = "";
                }
            }
            catch
            {
                txtCredit1.Text = "";
                txtCredit1.Tag = "";
            }
        }
        private void switchButton_Lock_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (switchButton_Lock.Value)
                {
                    panel_Gaid.Enabled = true;
                    if (switchButton_Lock.Value)
                    {
                        try
                        {
                            T_per q2 = db.StockPer(int.Parse(Cmb_GuestNm.SelectedValue.ToString()));
                            txtDebit1.Tag = q2.Cust_no;
                            txtDebit1.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(q2.Cust_no).Arb_Des : db.StockAccDefWithOutBalance(q2.Cust_no).Eng_Des);
                        }
                        catch
                        {
                            txtDebit1.Text = "";
                            txtDebit1.Tag = "";
                        }
                        try
                        {
                            T_sertyp q = db.StockServTypeID(int.Parse(Cmb_ServiceTyp.SelectedValue.ToString()));
                            txtCredit1.Tag = q.accno;
                            txtCredit1.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(q.accno).Arb_Des : db.StockAccDefWithOutBalance(q.accno).Eng_Des);
                        }
                        catch
                        {
                            txtCredit1.Text = "";
                            txtCredit1.Tag = "";
                        }
                    }
                }
                else
                {
                    panel_Gaid.Enabled = false;
                }
            }
            catch
            {
            }
        }
        private void switchButton_Lock_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }
        private void button_CustD1_Click(object sender, EventArgs e)
        {
            if (switchButton_Lock.Value)
            {
                try
                {
                    T_per q = db.StockPer(int.Parse(Cmb_GuestNm.SelectedValue.ToString()));
                    txtDebit1.Tag = q.Cust_no;
                    txtDebit1.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(q.Cust_no).Arb_Des : db.StockAccDefWithOutBalance(q.Cust_no).Eng_Des);
                }
                catch
                {
                    txtDebit1.Text = "";
                    txtDebit1.Tag = "";
                }
            }
        }
        private void button_CustC1_Click(object sender, EventArgs e)
        {
            if (switchButton_Lock.Value)
            {
                try
                {
                    T_per q = db.StockPer(int.Parse(Cmb_GuestNm.SelectedValue.ToString()));
                    txtCredit1.Tag = q.Cust_no;
                    txtCredit1.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(q.Cust_no).Arb_Des : db.StockAccDefWithOutBalance(q.Cust_no).Eng_Des);
                }
                catch
                {
                    txtCredit1.Text = "";
                    txtCredit1.Tag = "";
                }
            }
        }
        private void Cmb_ServiceTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (State != FormState.Edit)
                {
                    switchButton_Lock_ValueChanged(sender, e);
                }
            }
            catch
            {
            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmServesToLeave));
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background3 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor1 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor2 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle1 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle2 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.Background background4 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            timer1 = new System.Windows.Forms.Timer(components);
            expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            panelEx2 = new DevComponents.DotNetBar.PanelEx();
            ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            panel2 = new System.Windows.Forms.Panel();
            labelGaidStat = new System.Windows.Forms.Label();
            txtRoom = new System.Windows.Forms.TextBox();
            labelGuestStat = new System.Windows.Forms.Label();
            switchButton_Lock = new DevComponents.DotNetBar.Controls.SwitchButton();
            txtTime = new System.Windows.Forms.TextBox();
            txtDetails = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            txtValue = new DevComponents.Editors.DoubleInput();
            label8 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            Cmb_ServiceTyp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            label6z = new System.Windows.Forms.Label();
            txtDate = new System.Windows.Forms.MaskedTextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            textBox_ID = new System.Windows.Forms.TextBox();
            Cmb_GuestNm = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            label13z = new System.Windows.Forms.Label();
            panel_Gaid = new System.Windows.Forms.Panel();
            button_CustC1 = new DevComponents.DotNetBar.ButtonX();
            button_CustD1 = new DevComponents.DotNetBar.ButtonX();
            txtDebit1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            txtCredit1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            labelD1 = new System.Windows.Forms.Label();
            labelC1 = new System.Windows.Forms.Label();
            ribbonBar_Tasks = new DevComponents.DotNetBar.RibbonBar();
            superTabControl_Main1 = new DevComponents.DotNetBar.SuperTabControl();
            Button_Close = new DevComponents.DotNetBar.ButtonItem();
            Button_Search = new DevComponents.DotNetBar.ButtonItem();
            Button_Save = new DevComponents.DotNetBar.ButtonItem();
            superTabControl_Main2 = new DevComponents.DotNetBar.SuperTabControl();
            labelItem1 = new DevComponents.DotNetBar.LabelItem();
            Button_First = new DevComponents.DotNetBar.ButtonItem();
            Button_Prev = new DevComponents.DotNetBar.ButtonItem();
            TextBox_Index = new DevComponents.DotNetBar.TextBoxItem();
            Label_Count = new DevComponents.DotNetBar.LabelItem();
            lable_Records = new DevComponents.DotNetBar.LabelItem();
            Button_Next = new DevComponents.DotNetBar.ButtonItem();
            Button_Last = new DevComponents.DotNetBar.ButtonItem();
            saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            DGV_Main = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            panelEx3 = new DevComponents.DotNetBar.PanelEx();
            ribbonBar_DGV = new DevComponents.DotNetBar.RibbonBar();
            superTabControl_DGV = new DevComponents.DotNetBar.SuperTabControl();
            textBox_search = new DevComponents.DotNetBar.TextBoxItem();
            Button_ExportTable2 = new DevComponents.DotNetBar.ButtonItem();
            Button_PrintTable = new DevComponents.DotNetBar.ButtonItem();
            labelItem3 = new DevComponents.DotNetBar.LabelItem();
            timerInfoBallon = new System.Windows.Forms.Timer(components);
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            panel1 = new System.Windows.Forms.Panel();
            barTopDockSite = new DevComponents.DotNetBar.DockSite();
            barBottomDockSite = new DevComponents.DotNetBar.DockSite();
            dotNetBarManager1 = new DevComponents.DotNetBar.DotNetBarManager(components);
            imageList1 = new System.Windows.Forms.ImageList(components);
            barLeftDockSite = new DevComponents.DotNetBar.DockSite();
            barRightDockSite = new DevComponents.DotNetBar.DockSite();
            dockSite4 = new DevComponents.DotNetBar.DockSite();
            dockSite1 = new DevComponents.DotNetBar.DockSite();
            dockSite2 = new DevComponents.DotNetBar.DockSite();
            dockSite3 = new DevComponents.DotNetBar.DockSite();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            ToolStripMenuItem_Rep = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItem_Det = new System.Windows.Forms.ToolStripMenuItem();
            contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(components);
            panelEx2.SuspendLayout();
            ribbonBar1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtValue).BeginInit();
            panel_Gaid.SuspendLayout();
            ribbonBar_Tasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)superTabControl_Main1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)superTabControl_Main2).BeginInit();
            panelEx3.SuspendLayout();
            ribbonBar_DGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)superTabControl_DGV).BeginInit();
            panel1.SuspendLayout();
            contextMenuStrip2.SuspendLayout();
            SuspendLayout();
            timer1.Interval = 1000;
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
            panelEx2.Controls.Add(ribbonBar1);
            panelEx2.Controls.Add(ribbonBar_Tasks);
            resources.ApplyResources(panelEx2, "panelEx2");
            panelEx2.MinimumSize = new System.Drawing.Size(659, 300);
            panelEx2.Name = "panelEx2";
            panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            panelEx2.Style.GradientAngle = 90;
            ribbonBar1.AutoOverflowEnabled = true;
            ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.ContainerControlProcessDialogKey = true;
            ribbonBar1.Controls.Add(panel2);
            resources.ApplyResources(ribbonBar1, "ribbonBar1");
            ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            ribbonBar1.Name = "ribbonBar1";
            ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.FromArgb(227, 239, 255);
            ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(101, 147, 207);
            ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            panel2.Controls.Add(labelGaidStat);
            panel2.Controls.Add(txtRoom);
            panel2.Controls.Add(labelGuestStat);
            panel2.Controls.Add(switchButton_Lock);
            panel2.Controls.Add(txtTime);
            panel2.Controls.Add(txtDetails);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtValue);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(Cmb_ServiceTyp);
            panel2.Controls.Add(label6z);
            panel2.Controls.Add(txtDate);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(textBox_ID);
            panel2.Controls.Add(Cmb_GuestNm);
            panel2.Controls.Add(label13z);
            panel2.Controls.Add(panel_Gaid);
            resources.ApplyResources(panel2, "panel2");
            panel2.Name = "panel2";
            panel2.Paint += new System.Windows.Forms.PaintEventHandler(panel2_Paint);
            labelGaidStat.BackColor = System.Drawing.Color.DarkSeaGreen;
            labelGaidStat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            resources.ApplyResources(labelGaidStat, "labelGaidStat");
            labelGaidStat.ForeColor = System.Drawing.Color.White;
            labelGaidStat.Name = "labelGaidStat";
            txtRoom.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(txtRoom, "txtRoom");
            txtRoom.ForeColor = System.Drawing.Color.Maroon;
            txtRoom.Name = "txtRoom";
            txtRoom.ReadOnly = true;
            labelGuestStat.BackColor = System.Drawing.Color.FromArgb(192, 0, 0);
            labelGuestStat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            resources.ApplyResources(labelGuestStat, "labelGuestStat");
            labelGuestStat.ForeColor = System.Drawing.Color.White;
            labelGuestStat.Name = "labelGuestStat";
            switchButton_Lock.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            resources.ApplyResources(switchButton_Lock, "switchButton_Lock");
            switchButton_Lock.Name = "switchButton_Lock";
            switchButton_Lock.OffBackColor = System.Drawing.Color.FromArgb(192, 80, 77);
            switchButton_Lock.OffTextColor = System.Drawing.Color.White;
            switchButton_Lock.OnBackColor = System.Drawing.Color.FromArgb(0, 192, 0);
            switchButton_Lock.OnTextColor = System.Drawing.Color.White;
            switchButton_Lock.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            switchButton_Lock.SwitchWidth = 50;
            switchButton_Lock.ValueChanged += new System.EventHandler(switchButton_Lock_ValueChanged);
            switchButton_Lock.Click += new System.EventHandler(switchButton_Lock_Click);
            txtTime.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(txtTime, "txtTime");
            txtTime.ForeColor = System.Drawing.Color.Black;
            txtTime.Name = "txtTime";
            txtTime.ReadOnly = true;
            txtTime.Click += new System.EventHandler(txtTime_Click);
            txtDetails.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(txtDetails, "txtDetails");
            txtDetails.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            txtDetails.Name = "txtDetails";
            resources.ApplyResources(label4, "label4");
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label4.Name = "label4";
            txtValue.AllowEmptyState = false;
            resources.ApplyResources(txtValue, "txtValue");
            txtValue.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 0);
            txtValue.BackgroundStyle.Class = "DateTimeInputBackground";
            txtValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            txtValue.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            txtValue.DisplayFormat = "0.00";
            txtValue.Increment = 0.0;
            txtValue.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            txtValue.Name = "txtValue";
            resources.ApplyResources(label8, "label8");
            label8.BackColor = System.Drawing.Color.Transparent;
            label8.Name = "label8";
            resources.ApplyResources(label3, "label3");
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Name = "label3";
            Cmb_ServiceTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            Cmb_ServiceTyp.DisplayMember = "Text";
            Cmb_ServiceTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            Cmb_ServiceTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(Cmb_ServiceTyp, "Cmb_ServiceTyp");
            Cmb_ServiceTyp.FocusHighlightColor = System.Drawing.Color.Empty;
            Cmb_ServiceTyp.FormattingEnabled = true;
            Cmb_ServiceTyp.Name = "Cmb_ServiceTyp";
            Cmb_ServiceTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            Cmb_ServiceTyp.SelectedIndexChanged += new System.EventHandler(Cmb_ServiceTyp_SelectedIndexChanged);
            resources.ApplyResources(label6z, "label6z");
            label6z.BackColor = System.Drawing.Color.Transparent;
            label6z.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label6z.Name = "label6z";
            txtDate.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(txtDate, "txtDate");
            txtDate.Name = "txtDate";
            txtDate.ReadOnly = true;
            txtDate.Leave += new System.EventHandler(txtDate_Leave);
            txtDate.Click += new System.EventHandler(txtDate_Click);
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.ForeColor = System.Drawing.Color.Black;
            label1.Name = "label1";
            resources.ApplyResources(label2, "label2");
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.ForeColor = System.Drawing.Color.Black;
            label2.Name = "label2";
            textBox_ID.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
            textBox_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(textBox_ID, "textBox_ID");
            textBox_ID.Name = "textBox_ID";
            textBox_ID.ReadOnly = true;
            textBox_ID.TextChanged += new System.EventHandler(textBox_ID_TextChanged);
            textBox_ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox_ID_KeyPress);
            Cmb_GuestNm.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            Cmb_GuestNm.DisplayMember = "Text";
            Cmb_GuestNm.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            Cmb_GuestNm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(Cmb_GuestNm, "Cmb_GuestNm");
            Cmb_GuestNm.FocusHighlightColor = System.Drawing.Color.Empty;
            Cmb_GuestNm.FormattingEnabled = true;
            Cmb_GuestNm.Name = "Cmb_GuestNm";
            Cmb_GuestNm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            resources.ApplyResources(label13z, "label13z");
            label13z.BackColor = System.Drawing.Color.Transparent;
            label13z.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label13z.Name = "label13z";
            panel_Gaid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            panel_Gaid.Controls.Add(button_CustC1);
            panel_Gaid.Controls.Add(button_CustD1);
            panel_Gaid.Controls.Add(txtDebit1);
            panel_Gaid.Controls.Add(txtCredit1);
            panel_Gaid.Controls.Add(labelD1);
            panel_Gaid.Controls.Add(labelC1);
            resources.ApplyResources(panel_Gaid, "panel_Gaid");
            panel_Gaid.Name = "panel_Gaid";
            button_CustC1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            button_CustC1.Checked = true;
            button_CustC1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(button_CustC1, "button_CustC1");
            button_CustC1.Name = "button_CustC1";
            button_CustC1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_CustC1.Symbol = "\uf00c";
            button_CustC1.SymbolSize = 7f;
            button_CustC1.TextColor = System.Drawing.Color.SteelBlue;
            button_CustC1.Click += new System.EventHandler(button_CustC1_Click);
            button_CustD1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            button_CustD1.Checked = true;
            button_CustD1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(button_CustD1, "button_CustD1");
            button_CustD1.Name = "button_CustD1";
            button_CustD1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_CustD1.Symbol = "\uf00c";
            button_CustD1.SymbolSize = 7f;
            button_CustD1.TextColor = System.Drawing.Color.SteelBlue;
            button_CustD1.Click += new System.EventHandler(button_CustD1_Click);
            txtDebit1.BackColor = System.Drawing.SystemColors.Control;
            txtDebit1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            txtDebit1.ButtonCustom.Visible = true;
            resources.ApplyResources(txtDebit1, "txtDebit1");
            txtDebit1.ForeColor = System.Drawing.SystemColors.ControlText;
            txtDebit1.Name = "txtDebit1";
            txtDebit1.ReadOnly = true;
            txtCredit1.BackColor = System.Drawing.SystemColors.Control;
            txtCredit1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            txtCredit1.ButtonCustom.Visible = true;
            resources.ApplyResources(txtCredit1, "txtCredit1");
            txtCredit1.ForeColor = System.Drawing.SystemColors.ControlText;
            txtCredit1.Name = "txtCredit1";
            txtCredit1.ReadOnly = true;
            resources.ApplyResources(labelD1, "labelD1");
            labelD1.BackColor = System.Drawing.Color.Transparent;
            labelD1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            labelD1.Name = "labelD1";
            resources.ApplyResources(labelC1, "labelC1");
            labelC1.BackColor = System.Drawing.Color.Transparent;
            labelC1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            labelC1.Name = "labelC1";
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
            superTabControl_Main1.ControlBox.CloseBox.Name = "";
            superTabControl_Main1.ControlBox.MenuBox.Name = "";
            superTabControl_Main1.ControlBox.Name = "";
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
            superTabControl_Main1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[3]
            {
                Button_Close,
                Button_Search,
                Button_Save
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
            superTabControl_Main2.BackColor = System.Drawing.Color.White;
            superTabControl_Main2.CausesValidation = false;
            superTabControl_Main2.ControlBox.CloseBox.Name = "";
            superTabControl_Main2.ControlBox.MenuBox.Name = "";
            superTabControl_Main2.ControlBox.Name = "";
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
            saveFileDialog1.DefaultExt = "*.rtf";
            saveFileDialog1.FileName = "doc1";
            resources.ApplyResources(saveFileDialog1, "saveFileDialog1");
            saveFileDialog1.FilterIndex = 2;
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
            DGV_Main.PrimaryGrid.Caption.Text = "";
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
            DGV_Main.PrimaryGrid.GroupByRow.WatermarkText = "";
            DGV_Main.PrimaryGrid.InitialActiveRow = DevComponents.DotNetBar.SuperGrid.RelativeRow.None;
            DGV_Main.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.None;
            DGV_Main.PrimaryGrid.MultiSelect = false;
            DGV_Main.PrimaryGrid.ShowRowGridIndex = true;
            DGV_Main.PrimaryGrid.Title.AllowSelection = false;
            DGV_Main.PrimaryGrid.Title.Text = "";
            DGV_Main.PrimaryGrid.Title.Visible = false;
            DGV_Main.PrimaryGrid.Visible = false;
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
            superTabControl_DGV.ControlBox.CloseBox.Name = "";
            superTabControl_DGV.ControlBox.MenuBox.Name = "";
            superTabControl_DGV.ControlBox.Name = "";
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
            Button_PrintTable.Visible = false;
            labelItem3.Name = "labelItem3";
            labelItem3.Width = 40;
            timerInfoBallon.Interval = 3000;
            openFileDialog1.DefaultExt = "*.rtf";
            resources.ApplyResources(openFileDialog1, "openFileDialog1");
            openFileDialog1.FilterIndex = 2;
            panel1.Controls.Add(panelEx3);
            panel1.Controls.Add(expandableSplitter1);
            panel1.Controls.Add(panelEx2);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
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
            dotNetBarManager1.BottomDockSite = barBottomDockSite;
            dotNetBarManager1.Images = imageList1;
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
            imageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = System.Drawing.Color.Magenta;
            imageList1.Images.SetKeyName(0, "");
            imageList1.Images.SetKeyName(1, "");
            imageList1.Images.SetKeyName(2, "");
            imageList1.Images.SetKeyName(3, "");
            imageList1.Images.SetKeyName(4, "");
            imageList1.Images.SetKeyName(5, "");
            imageList1.Images.SetKeyName(6, "");
            imageList1.Images.SetKeyName(7, "");
            imageList1.Images.SetKeyName(8, "");
            imageList1.Images.SetKeyName(9, "");
            imageList1.Images.SetKeyName(10, "");
            imageList1.Images.SetKeyName(11, "");
            imageList1.Images.SetKeyName(12, "");
            imageList1.Images.SetKeyName(13, "");
            imageList1.Images.SetKeyName(14, "");
            imageList1.Images.SetKeyName(15, "");
            imageList1.Images.SetKeyName(16, "");
            imageList1.Images.SetKeyName(17, "");
            imageList1.Images.SetKeyName(18, "");
            imageList1.Images.SetKeyName(19, "");
            imageList1.Images.SetKeyName(20, "");
            imageList1.Images.SetKeyName(21, "");
            imageList1.Images.SetKeyName(22, "");
            imageList1.Images.SetKeyName(23, "");
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
            dockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(dockSite4, "dockSite4");
            dockSite4.Name = "dockSite4";
            dockSite4.TabStop = false;
            dockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(dockSite1, "dockSite1");
            dockSite1.Name = "dockSite1";
            dockSite1.TabStop = false;
            dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(dockSite2, "dockSite2");
            dockSite2.Name = "dockSite2";
            dockSite2.TabStop = false;
            dockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(dockSite3, "dockSite3");
            dockSite3.Name = "dockSite3";
            dockSite3.TabStop = false;
            contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(contextMenuStrip1, "contextMenuStrip1");
            ToolStripMenuItem_Rep.Checked = true;
            ToolStripMenuItem_Rep.CheckState = System.Windows.Forms.CheckState.Checked;
            ToolStripMenuItem_Rep.Name = "ToolStripMenuItem_Rep";
            resources.ApplyResources(ToolStripMenuItem_Rep, "ToolStripMenuItem_Rep");
            ToolStripMenuItem_Det.Name = "ToolStripMenuItem_Det";
            resources.ApplyResources(ToolStripMenuItem_Det, "ToolStripMenuItem_Det");
            contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[2]
            {
                ToolStripMenuItem_Det,
                ToolStripMenuItem_Rep
            });
            contextMenuStrip2.Name = "contextMenuStrip2";
            resources.ApplyResources(contextMenuStrip2, "contextMenuStrip2");
            resources.ApplyResources(this, "$this");
            base.Controls.Add(panel1);
            base.Controls.Add(barTopDockSite);
            base.Controls.Add(barBottomDockSite);
            base.Controls.Add(barLeftDockSite);
            base.Controls.Add(barRightDockSite);
            base.Controls.Add(dockSite4);
            base.Controls.Add(dockSite1);
            base.Controls.Add(dockSite2);
            base.Controls.Add(dockSite3);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "FrmServesToLeave";
            base.Load += new System.EventHandler(FrmServesToLeave_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Frm_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(Frm_KeyDown);
            panelEx2.ResumeLayout(false);
            ribbonBar1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtValue).EndInit();
            panel_Gaid.ResumeLayout(false);
            panel_Gaid.PerformLayout();
            ribbonBar_Tasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)superTabControl_Main1).EndInit();
            ((System.ComponentModel.ISupportInitialize)superTabControl_Main2).EndInit();
            panelEx3.ResumeLayout(false);
            ribbonBar_DGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)superTabControl_DGV).EndInit();
            panel1.ResumeLayout(false);
            contextMenuStrip2.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
