using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using Framework.Data;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
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
    public partial  class FrmTel : Form
    { void avs(int arln)

{ 
}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
        }
   
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
       // private IContainer components = null;
        private Timer timer1;
        private ExpandableSplitter expandableSplitter1;
        private PanelEx panelEx2;
        private RibbonBar ribbonBar1;
        private System.Windows.Forms. SaveFileDialog saveFileDialog1;
        protected SuperGridControl DGV_Main;
        private PanelEx panelEx3;
        private Timer timerInfoBallon;
        private System.Windows.Forms.OpenFileDialog  openFileDialog1;
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
        protected ButtonItem Button_Search;
        protected ButtonItem Button_Delete;
        protected ButtonItem Button_Save;
        protected ButtonItem Button_Add;
        protected LabelItem labelItem2;
        private RibbonBar ribbonBar_DGV;
        private SuperTabControl superTabControl_DGV;
        protected TextBoxItem textBox_search;
        protected ButtonItem Button_ExportTable2;
        protected LabelItem labelItem3;
        private LabelItem lable_Records;
        private Panel panel2;
        protected TextBox textBox_ID;
        protected Label label38;
        internal Label Label2;
        private MaskedTextBox Label15;
        protected TextBox Text2;
        protected Label label1;
        private ComboBoxEx Combo2;
        internal Label label19;
        protected TextBox Label16;
        protected Label label36;
        internal Label label6;
        internal Label label5;
        internal Label label4;
        private DoubleInput Text6;
        internal Label label17;
        private ButtonX Command3;
        private IntegerInput Text5;
        private IntegerInput Text4;
        private IntegerInput Text3;
        private SwitchButton switchButton_Lock;
        private Panel panel_Gaid;
        private ButtonX button_CustC1;
        private ButtonX button_CustD1;
        private TextBoxX txtDebit1;
        private TextBoxX txtCredit1;
        internal Label labelD1;
        internal Label labelC1;
        internal Label labelGuestStat;
        internal Label labelGaidStat;
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
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
        private bool canUpdate = true;
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstance;
        private T_tel data_this;
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
        private bool Pas;
        private string Ps;
        private int Op;
        private int M;
        private int R1;
        private int R2;
        private int R3;
        private bool vChk;
        private T_GDHEAD _GdHead = new T_GDHEAD();
        private List<T_GDHEAD> listGdHead = new List<T_GDHEAD>();
        private T_GDDET _GdDet = new T_GDDET();
        private List<T_GDDET> listGdDet = new List<T_GDDET>();
        private ScriptNumber ScriptNumber1 = new ScriptNumber();
        public Dictionary<string, ColumnDictinary> columns_Names_visible2 = new Dictionary<string, ColumnDictinary>();
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
        public T_tel DataThis
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
                if (value != null && value.UsrNo != string.Empty)
                {
                    permission = value;
                    if (!VarGeneral.TString.ChkStatShow(value.RepAcc2, 5))
                    {
                        IfAdd = false;
                    }
                    else
                    {
                        IfAdd = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.RepAcc2, 6))
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.RepAcc2, 7))
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
                    lable_Records.Text = ((vCount == 0) ? "???????????? ??????????" : "?????? ???????? ??????");
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
                    lable_Records.Text = "?????????? ???? " + vCount + " ??????????";
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
                    lable_Records.Text = "???????????? ???? " + vCount + " ??????????";
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
                lable_Records.Text = "?????????? " + vPosition + " ???? " + vCount;
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
                if (MessageBox.Show((LangArEn == 0) ? "???? ?????????? ?????????? ???????????? ?????? ?????? ?????????????????? .. ???? ???????? ??????????????????" : "Not saved the changes, do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    return false;
                }
                return true;
            }
            return true;
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
            VarGeneral.SFrmTyp = "T_tel";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                textBox_ID.Text = frm.SerachNo.ToString();
            }
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
            List<T_tel> list = db.FillTel_2(textBox_search.TextBox.Text).ToList();
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
        }
        public void FillHDGV(IEnumerable<T_tel> new_data_enum)
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
            DGV_Main.PrimaryGrid.DataMember = "T_tel";
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
            data_this = new T_tel();
            _GdHead = new T_GDHEAD();
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
            textBox_ID.Focus();
            M = 1;
            Op = 0;
            Ps = string.Empty;
            Pas = true;
            vChk = false;
            labelGuestStat.Visible = false;
            labelGaidStat.Visible = false;
            switchButton_Lock.Value = false;
            Combo2.SelectedIndex = 0;
            Combo2_SelectedValueChanged(null, null);
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
            var qkeys = from item in db.T_tels
                        where item.T_per.ch == (int?)2
                        select new
                        {
                            Code = item.ID + string.Empty
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
        public FrmTel()
        {
            InitializeComponent();this.Load += langloads;
            controls = new List<Control>();
            controls.Add(textBox_ID);
            codeControl = textBox_ID;
            controls.Add(Label16);
            controls.Add(Text2);
            controls.Add(Text3);
            controls.Add(Text4);
            controls.Add(Text5);
            controls.Add(Text6);
            controls.Add(Label15);
            controls.Add(Combo2);
            controls.Add(txtDebit1);
            controls.Add(txtCredit1);
            controls.Add(switchButton_Lock);
            Button_Close.Click += Button_Close_Click;
            Label16.Click += Button_Edit_Click;
            Text2.Click += Button_Edit_Click;
            Text3.Click += Button_Edit_Click;
            Text4.Click += Button_Edit_Click;
            Text5.Click += Button_Edit_Click;
            Text6.Click += Button_Edit_Click;
            Label15.Click += Button_Edit_Click;
            Combo2.Click += Button_Edit_Click;
            txtDebit1.Click += Button_Edit_Click;
            txtCredit1.Click += Button_Edit_Click;
            expandableSplitter1.Click += expandableSplitter1_Click;
            ToolStripMenuItem_Det.Click += ToolStripMenuItem_Det_Click;
            Button_ExportTable2.Click += Button_ExportTable2_Click;
            Button_First.Click += Button_First_Click;
            Button_Prev.Click += Button_Prev_Click;
            Button_Next.Click += Button_Next_Click;
            Button_Last.Click += Button_Last_Click;
            Button_Add.Click += Button_Add_Click;
            Button_Search.Click += Button_Search_Click;
            Button_Delete.Click += Button_Delete_Click;
            Button_Save.Click += Button_Save_Click;
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
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                Button_First.Text = "??????????";
                Button_Last.Text = "????????????";
                Button_Next.Text = "????????????";
                Button_Prev.Text = "????????????";
                Button_Add.Text = "????????";
                Button_Close.Text = "??????????";
                Button_Delete.Text = "??????";
                Button_Save.Text = "??????";
                Button_Search.Text = "??????";
                Button_First.Tooltip = "?????????? ??????????";
                Button_Last.Tooltip = "?????????? ????????????";
                Button_Next.Tooltip = "?????????? ????????????";
                Button_Prev.Tooltip = "?????????? ????????????";
                Button_Add.Tooltip = "F1";
                Button_Close.Tooltip = "Esc";
                Button_Delete.Tooltip = "F3";
                Button_Save.Tooltip = "F2";
                Button_Search.Tooltip = "F4";
                Button_ExportTable2.Text = "??????????";
                Button_ExportTable2.Tooltip = "F10";
                switchButton_Lock.OffText = "?????????? ?????? ????????????";
                switchButton_Lock.OnText = "?????????? ?????? ????????????";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "???????? ??????????????";
                Text = "?????????????? ??????????????";
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
                Button_ExportTable2.Text = "Export";
                Button_ExportTable2.Tooltip = "F10";
                switchButton_Lock.OffText = "Create an accounting record";
                switchButton_Lock.OnText = "Create an accounting record";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "All Records";
                labelGuestStat.Text = "Guest Leaved";
                labelGaidStat.Text = "The accounting record was derecognized at the close of the year";
                Text = "Guest calls";
            }
        }
        private void FrmTel_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmTel));
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
                Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
                if (columns_Names_visible.Count == 0)
                {
                    columns_Names_visible.Add("ID", new ColumnDictinary("?????? ????????????????", "Inv No", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("perno", new ColumnDictinary("?????? ????????????", "Guest No", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("romno", new ColumnDictinary("?????? ????????????", "Room Np", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("price", new ColumnDictinary("???????????? ??????????????", "Value", ifDefault: true, string.Empty));
                }
                else
                {
                    Clear();
                    textBox_ID.Text = string.Empty;
                    TextBox_Index.TextBox.Text = string.Empty;
                }
                RibunButtons();
                RefreshPKeys();
                FillCombo();
                textBox_ID.Text = PKeys.FirstOrDefault();
                ViewDetails_Click(sender, e);
                UpdateVcr();
                Combo2_SelectedValueChanged(sender, e);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void FillCombo()
        {
            List<T_Rom> listRoooms = new List<T_Rom>(db.T_Roms.Where((T_Rom item) => item.state == (int?)3).ToList());
            Combo2.DataSource = null;
            Combo2.DataSource = listRoooms;
            Combo2.DisplayMember = "romno";
            Combo2.ValueMember = "romno";
            Combo2.SelectedIndex = 0;
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
                T_tel newData = db.StockTel(no);
                if (newData == null || newData.ID == 0)
                {
                    if (!Button_Add.Visible || !Button_Add.Enabled)
                    {
                        MessageBox.Show((LangArEn == 0) ? "???? ???????? ?????????? ?????? ?????????????? .. ???????????? ???????????? ?????????????? ???????????????????? !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textBox_ID.TextChanged -= textBox_ID_TextChanged;
                        try
                        {
                            textBox_ID.Text = data_this.ID.ToString();
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
                    int indexA = PKeys.IndexOf(string.Concat(newData.ID));
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
        public void SetData(T_tel value)
        {
            switchButton_Lock.ValueChanged -= switchButton_Lock_ValueChanged;
            Combo2.SelectedValueChanged -= Combo2_SelectedValueChanged;
            try
            {
                State = FormState.Saved;
                Button_Save.Enabled = false;
                Label16.Tag = data_this.perno;
                if (value.romno.HasValue)
                {
                    Combo2.SelectedValue = data_this.romno;
                }
                Text2.Text = data_this.tel;
                Text3.Value = int.Parse(data_this.s.Value.ToString());
                Text4.Value = int.Parse(data_this.m.Value.ToString());
                Text5.Value = int.Parse(data_this.h.Value.ToString());
                Op = data_this.op.Value;
                Text6.Value = data_this.price.Value;
                Label15.Text = data_this.dt;
                txtDebit1.Text = string.Empty;
                txtCredit1.Text = string.Empty;
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
                if (value.T_per.ch == 3)
                {
                    Label15.Enabled = false;
                    labelGuestStat.Visible = true;
                }
                else
                {
                    Label15.Enabled = true;
                    labelGuestStat.Visible = false;
                }
                if (data_this.GadeNo == 0.0 && VarGeneral.UserID != 1)
                {
                    labelGaidStat.Visible = true;
                }
                else
                {
                    labelGaidStat.Visible = false;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SetData:", error, enable: true);
                MessageBox.Show(error.Message);
            }
            Combo2.SelectedValueChanged += Combo2_SelectedValueChanged;
            switchButton_Lock.ValueChanged += switchButton_Lock_ValueChanged;
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
        private T_tel GetData()
        {
            textBox_ID.Focus();
            data_this.perno = int.Parse(Label16.Tag.ToString());
            data_this.ino = int.Parse(textBox_ID.Text);
            data_this.ID = int.Parse(textBox_ID.Text);
            data_this.romno = int.Parse(Combo2.SelectedValue.ToString());
            data_this.tel = Text2.Text;
            data_this.s = Text3.Value;
            data_this.m = Text4.Value;
            data_this.h = Text5.Value;
            data_this.op = Op;
            data_this.price = Text6.Value;
            data_this.Usr = VarGeneral.UserNo;
            data_this.dt = Label15.Text;
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
        private void Button_Add_Click(object sender, EventArgs e)
        {
            if (!Button_Add.Visible || !Button_Add.Enabled)
            {
                MessageBox.Show((LangArEn == 0) ? "???? ???????? ?????????? ?????? ?????????????? .. ???????????? ???????????? ?????????????? ???????????????????? !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                if (State == FormState.Edit && MessageBox.Show((LangArEn == 0) ? "???? ?????????? ?????????? ???????????? ?????? ?????? ?????????????????? .. ???? ???????? ??????????????????" : "Not saved the changes, do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    return;
                }
                int max = 0;
                max = db.MaxTelNo;
                Clear();
                MaskedTextBox label = Label15;
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                label.Text = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
                textBox_ID.Text = max.ToString();
                try
                {
                    if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 46))
                    {
                        switchButton_Lock.Value = true;
                    }
                }
                catch
                {
                    switchButton_Lock.Value = true;
                }
                State = FormState.New;
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
                            string dtAction = (n.IsHijri(Label15.Text) ? Label15.Text : n.GregToHijri(Label15.Text, "yyyy/MM/dd"));
                            if (Convert.ToDateTime(n.GregToHijri(hKeyNew.GetValue("vBackup_New").ToString(), "yyyy/MM/dd")) < Convert.ToDateTime(n.FormatHijri(dtAction, "yyyy/MM/dd")))
                            {
                                MessageBox.Show((LangArEn == 0) ? "???? ???????? ?????????? ?????????????? .. ?????? ?????????? ?????????? ?????????????? ???????????? ???????????? \n ???????? ?????????????? ???? ?????????????? ?????????????????? ???? ?????????? ???????????? " : "We can not complete the operation .. have you skip the fiscal year specified for the system", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return false;
                            }
                        }
                        catch
                        {
                            MessageBox.Show((LangArEn == 0) ? "???? ???????? ?????????? ?????????????? .. ?????? ?????????? ?????????? ?????????????? ???????????? ???????????? \n ???????? ?????????????? ???? ?????????????? ?????????????????? ???? ?????????? ???????????? " : "We can not complete the operation .. have you skip the fiscal year specified for the system", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
                    MessageBox.Show((LangArEn == 0) ? "???? ???????? ?????????? ?????? ?????????????? .. ???????????? ???????????? ?????????????? ???????????????????? !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (State == FormState.New && !Button_Add.Enabled)
                {
                    MessageBox.Show((LangArEn == 0) ? "???? ???????? ?????????? ?????? ?????????????? .. ???????????? ???????????? ?????????????? ???????????????????? !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                textBox_ID.Focus();
                if (textBox_ID.Text == string.Empty || Label16.Text == string.Empty || Combo2.Text == string.Empty || Text6.Value <= 0.0 || string.IsNullOrEmpty(Text2.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "???????? ???????????? ?????????? .. ???????? ?????? ????????" : "There are incomplete data .. Try again", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (string.IsNullOrEmpty(Label15.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "???????????? ???? ?????????????? ??????????" : "Can not be Date is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (switchButton_Lock.Value && (string.IsNullOrEmpty(txtCredit1.Text) || string.IsNullOrEmpty(txtDebit1.Text)))
                {
                    MessageBox.Show((LangArEn == 0) ? "???? ???????? ?????????? ?????????????? .. ???????? ???? ?????? ?????????? ???????????? ?????????????? ?????????? .. " : "You can not complete the operation .. Make sure the creditor and debitor under the party ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
                        db.T_tels.InsertOnSubmit(data_this);
                        db.SubmitChanges();
                    }
                    catch (SqlException ex)
                    {
                        int max = 0;
                        max = db.MaxTelNo;
                        if (ex.Number != 2627)
                        {
                            return;
                        }
                        MessageBox.Show("?????? ???????????? ???????????? ???? ??????.\n ???????? ?????????? ???????? ???????? [" + max + "]", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question);
                        textBox_ID.Text = string.Concat(max);
                        data_this.ID = max;
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
                string AccCrdt = string.Empty;
                string AccDbt = string.Empty;
                if (!switchButton_Lock.Value)
                {
                    goto IL_0447;
                }
                if (Text6.Value > 0.0)
                {
                    AccCrdt = txtCredit1.Tag.ToString();
                    AccDbt = txtDebit1.Tag.ToString();
                }
                if (AccCrdt == string.Empty && Text6.Value > 0.0)
                {
                    MessageBox.Show((LangArEn == 0) ? "???? ???????? ?????????? ?????????????? .. ???????? ???? ?????? ?????????? ???????????? ?????????? .. " : "You can not complete the operation .. Make sure the creditor under the party ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (!(AccDbt == string.Empty) || !(Text6.Value > 0.0))
                {
                    goto IL_0447;
                }
                MessageBox.Show((LangArEn == 0) ? "???? ???????? ?????????? ?????????????? .. ???????? ???? ?????? ?????????? ???????????? ?????????? .. " : "You can not complete the operation .. Make sure the debtor under the party ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                goto end_IL_0001;
                IL_0447:
                if (Text6.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt) && !string.IsNullOrEmpty(AccDbt))
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
                    if (Text6.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt) && !string.IsNullOrEmpty(AccDbt))
                    {
                        db_.StartTransaction();
                        db_.ClearParameters();
                        db_.AddParameter("GDDET_ID", DbType.Int32, 0);
                        db_.AddParameter("gdID", DbType.Int32, _GdHead.gdhead_ID);
                        db_.AddParameter("gdNo", DbType.String, textBox_ID.Text);
                        db_.AddParameter("gdDes", DbType.String, "?????? ???????????? ???????????? ?????????? ???????? ???????? ?????? : " + textBox_ID.Text);
                        db_.AddParameter("gdDesE", DbType.String, "Auto Bound to add guest service : " + textBox_ID.Text);
                        db_.AddParameter("recptTyp", DbType.String, "1");
                        db_.AddParameter("AccNo", DbType.String, AccCrdt);
                        db_.AddParameter("AccName", DbType.String, string.Empty);
                        db_.AddParameter("gdValue", DbType.Double, 0.0 - double.Parse(Text6.Text));
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
                        db_.AddParameter("gdDes", DbType.String, "?????? ???????????? ???????????? ?????????? ???????? ???????? ?????? : " + textBox_ID.Text);
                        db_.AddParameter("gdDesE", DbType.String, "Auto Bound to add guest service : " + textBox_ID.Text);
                        db_.AddParameter("recptTyp", DbType.String, "1");
                        db_.AddParameter("AccNo", DbType.String, AccDbt);
                        db_.AddParameter("AccName", DbType.String, string.Empty);
                        db_.AddParameter("gdValue", DbType.Double, double.Parse(Text6.Text));
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
                if (Text6.Value > 0.0 && !string.IsNullOrEmpty(AccCrdt) && !string.IsNullOrEmpty(AccDbt))
                {
                    data_this.IsGaid = true;
                    data_this.GadeId = _GdHead.gdhead_ID;
                    data_this.GadeNo = int.Parse(textBox_ID.Text);
                }
                else
                {
                    data_this.IsGaid = false;
                    data_this.GadeId = null;
                    try
                    {
                        if (State == FormState.New)
                        {
                            data_this.GadeNo = null;
                        }
                        else if (data_this.GadeNo != 0.0)
                        {
                            data_this.GadeNo = null;
                        }
                    }
                    catch
                    {
                        data_this.GadeNo = null;
                    }
                }
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                State = FormState.Saved;
                RefreshPKeys();
                TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(string.Concat(data_this.ID)) + 1);
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
        private void Total()
        {
            try
            {
                string Cod = Text2.Text;
                string q = Cod.Substring(0, 1);
                if (int.Parse(q) != 0)
                {
                    Op = 0;
                }
                else if (int.Parse(q) == 0)
                {
                    string lp = "0";
                    try
                    {
                        lp = Cod.Substring(0, 2);
                    }
                    catch
                    {
                        lp = "0";
                    }
                    string q2 = lp;
                    if (int.Parse(q2) != 0)
                    {
                        Op = 1;
                    }
                    else if (int.Parse(q2) == 0)
                    {
                        int Cd;
                        try
                        {
                            Cd = int.Parse(Cod.Substring(0, 5));
                        }
                        catch
                        {
                            Cd = 0;
                        }
                        List<cod> c = db.cods.Where((cod t) => t.cod1 == Cd).ToList();
                        if (c.Count > 0)
                        {
                            Op = 2;
                        }
                        else if (Cd == 871 || Cd == 872 || Cd == 873)
                        {
                            Op = 4;
                        }
                        else
                        {
                            Op = 3;
                        }
                    }
                }
                List<T_telmn> Query = db.T_telmns.Where((T_telmn t) => t.pl == Op).ToList();
                int qq = 0;
                qq = ((Text3.Value > 0) ? 1 : 0);
                int hh = Text5.Value * 60;
                double Tot = (double)(Text4.Value + qq + hh) * Query[0].price.Value;
                double Tt = Tot * (double)Query[0].d.Value / 100.0;
                Text6.Value = Tot + Tt;
                Text6.Value = Text6.Value;
            }
            catch
            {
                Text6.Value = 0.0;
            }
        }
        private T_GDHEAD GetDataGd()
        {
            _GdHead.gdHDate = (n.IsHijri(Label15.Text) ? Label15.Text : n.GregToHijri(Label15.Text, "yyyy/MM/dd"));
            _GdHead.gdGDate = (n.IsGreg(Label15.Text) ? Label15.Text : n.HijriToGreg(Label15.Text, "yyyy/MM/dd"));
            _GdHead.gdNo = textBox_ID.Text;
            _GdHead.ArbTaf = ScriptNumber1.ScriptNum(decimal.Parse("0" + Text6.Text));
            _GdHead.BName = _GdHead.BName;
            _GdHead.ChekNo = _GdHead.ChekNo;
            _GdHead.CurTyp = 1;
            _GdHead.EngTaf = ScriptNumber1.TafEng(decimal.Parse("0" + Text6.Text));
            _GdHead.gdCstNo = 1;
            _GdHead.gdID = 0;
            _GdHead.gdLok = false;
            _GdHead.gdMem = "?????? ???????????? ???????????? ?????????? ???????? ????????  | Auto Bound to add guest service ";
            _GdHead.gdMnd = null;
            _GdHead.gdRcptID = (_GdHead.gdRcptID.HasValue ? _GdHead.gdRcptID.Value : 0.0);
            _GdHead.gdTot = Text6.Value;
            _GdHead.gdTp = (_GdHead.gdTp.HasValue ? _GdHead.gdTp.Value : 0);
            _GdHead.gdTyp = VarGeneral.InvTyp;
            _GdHead.RefNo = string.Empty;
            _GdHead.AdminLock = false;
            _GdHead.DATE_MODIFIED = DateTime.Now;
            _GdHead.salMonth = string.Empty;
            _GdHead.gdUser = VarGeneral.UserNumber;
            _GdHead.gdUserNam = VarGeneral.UserNameA;
            _GdHead.CompanyID = 1;
            return _GdHead;
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
            if (MessageBox.Show("???? ?????? ?????????? ???? ?????? ?????????? [" + Code + "]?? \n Are you sure that you want to delete the record [" + Code + "]?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ifOkDelete = true;
            }
            else
            {
                ifOkDelete = false;
            }
            if (labelGuestStat.Visible)
            {
                try
                {
                    if (permission.RepInv5 != "1")
                    {
                        MessageBox.Show((LangArEn == 0) ? "???? ???????? ?????????? ?????????????? .. ?????? ?????? ???????????? ??????????" : "The process can not be completed ... because this guest is leaving", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show((LangArEn == 0) ? "???? ???????? ?????????? ?????????????? .. ?????? ?????? ???????????? ??????????" : "The process can not be completed ... because this guest is leaving", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
            }
            if (data_this != null && data_this.ID != 0 && ifOkDelete)
            {
                data_this = db.StockTel(DataThis.ID);
                try
                {
                    IDatabase db_ = Database.GetDatabase(VarGeneral.BranchCS);
                    db_.StartTransaction();
                    db_.ClearParameters();
                    db_.AddParameter("gdhead_ID", DbType.Int32, _GdHead.gdhead_ID);
                    db_.ExecuteNonQueryWithoutCommit(storedProcedure: true, "S_T_GDHEAD_DELETE");
                    db_.EndTransaction();
                    db.T_tels.DeleteOnSubmit(DataThis);
                    db.SubmitChanges();
                }
                catch (SqlException)
                {
                    data_this = db.StockTel(DataThis.ID);
                    return;
                }
                catch (Exception)
                {
                    data_this = db.StockTel(DataThis.ID);
                    return;
                }
                Clear();
                RefreshPKeys();
                textBox_ID.Text = PKeys.LastOrDefault();
            }
        }
        private void DGV_Main_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            string dataMember = panel.DataMember;
            if (dataMember != null && dataMember == "T_tel")
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
            panel.Columns["perno"].Width = 250;
            panel.Columns["perno"].Visible = columns_Names_visible["perno"].IfDefault;
            panel.Columns["romno"].Width = 250;
            panel.Columns["romno"].Visible = columns_Names_visible["romno"].IfDefault;
            panel.Columns["ID"].Width = 200;
            panel.Columns["ID"].Visible = columns_Names_visible["ID"].IfDefault;
            panel.Columns["price"].Width = 200;
            panel.Columns["price"].Visible = columns_Names_visible["price"].IfDefault;
            panel.ReadOnly = true;
        }
        private void DGV_MainGetCellStyle(object sender, GridGetCellStyleEventArgs e)
        {
        }
        private void Button_ExportTable2_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcel.ExportToExcel(DGV_Main, "?????????? ?????????????? ??????????????");
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
        private void Command3_Click(object sender, EventArgs e)
        {
            if (!VarGeneral.vDemo || VarGeneral.UserID == 1)
            {
                Total();
            }
        }
        private void Label15_Click(object sender, EventArgs e)
        {
            Label15.SelectAll();
        }
        private void Label15_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(Label15.Text))
                {
                    Label15.Text = Convert.ToDateTime(Label15.Text).ToString("yyyy/MM/dd");
                    return;
                }
                MaskedTextBox label = Label15;
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                label.Text = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
            }
            catch
            {
                MaskedTextBox label2 = Label15;
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                label2.Text = ((calendr.Value == 0 && calendr.HasValue) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd"));
            }
        }
        private void Combo2_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    T_Rom Q = db.StockRoom(int.Parse(Combo2.SelectedValue.ToString()));
                    if (Q != null && Q.romno != 0)
                    {
                        Label16.Tag = Q.perno.Value;
                        Label16.Text = Q.T_per.nm;
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
                    else
                    {
                        Label16.Tag = string.Empty;
                        Label16.Text = string.Empty;
                    }
                }
                catch
                {
                    Label16.Tag = string.Empty;
                    Label16.Text = string.Empty;
                }
            }
            catch
            {
            }
        }
        private void Text5_Leave(object sender, EventArgs e)
        {
            Command3_Click(sender, e);
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
            columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("?????????? ", " No", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("?????????? ????????", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("?????????? ??????????????????", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible2.Add("Mobile", new ColumnDictinary("????????????", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
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
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtDebit1.Tag = _AccDef.AccDef_No;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
                    txtDebit1.Text = string.Empty;
                    txtDebit1.Tag = string.Empty;
                }
            }
            catch
            {
                txtDebit1.Text = string.Empty;
                txtDebit1.Tag = string.Empty;
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
            columns_Names_visible2.Add("AccDef_No", new ColumnDictinary("?????????? ", " No", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("?????????? ????????", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("?????????? ??????????????????", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible2.Add("Mobile", new ColumnDictinary("????????????", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
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
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtCredit1.Tag = _AccDef.AccDef_No;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
                    txtCredit1.Text = string.Empty;
                    txtCredit1.Tag = string.Empty;
                }
            }
            catch
            {
                txtCredit1.Text = string.Empty;
                txtCredit1.Tag = string.Empty;
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
                            T_per q2 = db.StockPer(int.Parse(Label16.Tag.ToString()));
                            txtDebit1.Tag = q2.Cust_no;
                            txtDebit1.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(q2.Cust_no).Arb_Des : db.StockAccDefWithOutBalance(q2.Cust_no).Eng_Des);
                        }
                        catch
                        {
                            txtDebit1.Text = string.Empty;
                            txtDebit1.Tag = string.Empty;
                        }
                        try
                        {
                            T_telmn q = db.StockTelMn(0);
                            txtCredit1.Tag = q.accno;
                            txtCredit1.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(q.accno).Arb_Des : db.StockAccDefWithOutBalance(q.accno).Eng_Des);
                        }
                        catch
                        {
                            txtCredit1.Text = string.Empty;
                            txtCredit1.Tag = string.Empty;
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
                    T_per q = db.StockPer(int.Parse(Label16.Tag.ToString()));
                    txtDebit1.Tag = q.Cust_no;
                    txtDebit1.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(q.Cust_no).Arb_Des : db.StockAccDefWithOutBalance(q.Cust_no).Eng_Des);
                }
                catch
                {
                    txtDebit1.Text = string.Empty;
                    txtDebit1.Tag = string.Empty;
                }
            }
        }
        private void button_CustC1_Click(object sender, EventArgs e)
        {
            if (switchButton_Lock.Value)
            {
                try
                {
                    T_per q = db.StockPer(int.Parse(Label16.Tag.ToString()));
                    txtCredit1.Tag = q.Cust_no;
                    txtCredit1.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(q.Cust_no).Arb_Des : db.StockAccDefWithOutBalance(q.Cust_no).Eng_Des);
                }
                catch
                {
                    txtCredit1.Text = string.Empty;
                    txtCredit1.Tag = string.Empty;
                }
            }
        }
    }
}
