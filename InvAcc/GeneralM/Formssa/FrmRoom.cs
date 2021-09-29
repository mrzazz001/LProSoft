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
    public partial class FrmRoom : Form
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
        private T_Rom data_this;
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
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
        protected ButtonItem Button_Search;
        protected ButtonItem Button_Save;
        private RibbonBar ribbonBar_DGV;
        private SuperTabControl superTabControl_DGV;
        protected TextBoxItem textBox_search;
        protected ButtonItem Button_ExportTable2;
        protected ButtonItem Button_PrintTable;
        protected LabelItem labelItem3;
        private LabelItem lable_Records;
        private Panel panel2;
        protected Label label11;
        protected Label label10;
        protected Label label8;
        protected Label label9;
        private DoubleInput txtRoomPriceMonth2;
        private DoubleInput txtRoomPriceMonth1;
        protected Label label7;
        protected Label label6;
        private DoubleInput txtRoomPriceDaily2;
        private DoubleInput txtRoomPriceDaily1;
        protected TextBox txtRoomDescription;
        protected Label label5;
        protected TextBox txtRoomCounterNo;
        protected Label label400;
        protected Label label300;
        protected Label label200;
        private ComboBoxEx txtRoomTyp;
        private TextBoxX txtRoomSts;
        protected TextBox txtRoomGuest;
        protected Label label40;
        protected Label label36;
        protected TextBox textBox_ID;
        protected Label label380;
        protected Label label15;
        private ComboBoxEx txtRoomTv;
        protected Label label14;
        private ComboBoxEx txtRoomBalcony;
        protected Label label13;
        private ComboBoxEx txtRoomTwalitTyp;
        protected Label label12;
        private ComboBoxEx txtRoomBedTyp;
        private ComboBoxEx txtRoomDirction;
        private IntegerInput txtRoomBedCount;
        private IntegerInput txtRoomTwalitCount;
        private IntegerInput txtRoomFloor;
        protected Label label1;
        protected ButtonItem buttonItem_Digram;
        private ButtonX button_SrchLoc;
        private ButtonX button_SrchLocADD;
        protected Label label3;
        private IntegerInput txtRoomCount;
        protected Label label2;
        protected TextBox txtRoomArea;
        protected Label label17;
        private ComboBoxEx txtRoomFurnitur;
        protected Label label16;
        private IntegerInput txtSalaacount;
        protected Label label4;
        private IntegerInput txtKitchinCount;
        protected TextBox txtFloorName;
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
        public T_Rom DataThis
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
                    if (!VarGeneral.TString.ChkStatShow(value.RepAcc1, 1))
                    {
                        CanEdit = false;
                        buttonItem_Digram.Enabled = false;
                    }
                    else
                    {
                        CanEdit = true;
                        buttonItem_Digram.Enabled = true;
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
        public void Button_Search_Click(object sender, EventArgs e)
        {
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_Rom";
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
            List<T_Rom> list = db.FillRoom_2(textBox_search.TextBox.Text).ToList();
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
        }
        public void FillHDGV(IEnumerable<T_Rom> new_data_enum)
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
            DGV_Main.PrimaryGrid.DataMember = "T_Rom";
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
            data_this = new T_Rom();
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
            var qkeys = db.T_Roms.Select((T_Rom item) => new
            {
                Code = item.romno + string.Empty
            });
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
        public FrmRoom()
        {
            InitializeComponent();
            controls = new List<Control>();
            controls.Add(textBox_ID);
            codeControl = textBox_ID;
            controls.Add(txtRoomFloor);
            controls.Add(txtRoomGuest);
            controls.Add(txtFloorName);
            Button_Close.Click += Button_Close_Click;
            txtRoomBalcony.Click += Button_Edit_Click;
            txtRoomBedCount.Click += Button_Edit_Click;
            txtRoomFurnitur.Click += Button_Edit_Click;
            txtRoomCount.Click += Button_Edit_Click;
            txtSalaacount.Click += Button_Edit_Click;
            txtKitchinCount.Click += Button_Edit_Click;
            txtRoomArea.Click += Button_Edit_Click;
            txtRoomBedTyp.Click += Button_Edit_Click;
            txtRoomCounterNo.Click += Button_Edit_Click;
            txtRoomDescription.Click += Button_Edit_Click;
            txtRoomDirction.Click += Button_Edit_Click;
            txtRoomFloor.Click += Button_Edit_Click;
            txtRoomGuest.Click += Button_Edit_Click;
            txtRoomPriceDaily1.Click += Button_Edit_Click;
            txtRoomPriceDaily2.Click += Button_Edit_Click;
            txtRoomPriceMonth1.Click += Button_Edit_Click;
            txtRoomPriceMonth2.Click += Button_Edit_Click;
            txtRoomSts.Click += Button_Edit_Click;
            txtRoomTv.Click += Button_Edit_Click;
            txtRoomTwalitCount.Click += Button_Edit_Click;
            txtRoomTwalitTyp.Click += Button_Edit_Click;
            txtRoomTyp.Click += Button_Edit_Click;
            expandableSplitter1.Click += expandableSplitter1_Click;
            ToolStripMenuItem_Det.Click += ToolStripMenuItem_Det_Click;
            Button_ExportTable2.Click += Button_ExportTable2_Click;
            Button_First.Click += Button_First_Click;
            Button_Prev.Click += Button_Prev_Click;
            Button_Next.Click += Button_Next_Click;
            Button_Last.Click += Button_Last_Click;
            Button_Search.Click += Button_Search_Click;
            Button_Save.Click += Button_Save_Click;
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmRoom));
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
                Text = "كرت الغــرف";
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
                buttonItem_Digram.Text = "Room Diagram";
                Text = "Room Card";
            }
        }
        private void FrmRoom_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmRoom));
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
                    columns_Names_visible.Add("romno", new ColumnDictinary("رقم الغرفة", "Room No", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("flore", new ColumnDictinary("الطابق", "Floor", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("state", new ColumnDictinary("حالة الغرفة", "Room State", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("nmA", new ColumnDictinary("الإسم النزيل العربي", "Arabic Name", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("nmE", new ColumnDictinary("الإسم النزيل الانجليزي", "English Name", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("pri0", new ColumnDictinary("السعر 1 - يومي", "Price 1 - Daily", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("priM0", new ColumnDictinary("السعر 1 - شهري", "Price 1 - Monthly", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("bedno", new ColumnDictinary("عدد السراير", "Beds Count", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("wcno", new ColumnDictinary("عدد الحمامات", "TW Count", ifDefault: true, string.Empty));
                    columns_Names_visible.Add("ShortDsc", new ColumnDictinary("ملاحظـــة", "Note", ifDefault: true, string.Empty));
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
                if (VarGeneral._rr)
                {
                    textBox_ID.Text = VarGeneral._hotelrom.ToString();
                    superTabControl_Main2.Visible = false;
                    buttonItem_Digram.Visible = false;
                    Button_Search.Visible = false;
                    expandableSplitter1.Enabled = false;
                }
                else
                {
                    textBox_ID.Text = PKeys.FirstOrDefault();
                }
                ViewDetails_Click(sender, e);
                UpdateVcr();
                if (VarGeneral.vDemo && VarGeneral.UserID != 1)
                {
                    label7.Visible = false;
                    txtRoomPriceDaily2.Visible = false;
                    label8.Visible = false;
                    txtRoomPriceMonth2.Visible = false;
                }
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
                T_Rom newData = db.StockRoom(no);
                if (newData == null || newData.romno == 0)
                {
                    Clear();
                    TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                    TextBox_Index.TextBox.Text = string.Concat(PKeys.Count + 1);
                    TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                }
                else
                {
                    DataThis = newData;
                    int indexA = PKeys.IndexOf(string.Concat(newData.romno));
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
            txtRoomTyp.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                txtRoomTyp.Items.Add("غرفة");
                txtRoomTyp.Items.Add("جناح");
                txtRoomTyp.Items.Add("فيلا");
                txtRoomTyp.Items.Add("شقة");
            }
            else
            {
                txtRoomTyp.Items.Add("Room");
                txtRoomTyp.Items.Add("suite");
                txtRoomTyp.Items.Add("villa");
                txtRoomTyp.Items.Add("apartment");
            }
            txtRoomTyp.SelectedIndex = 0;
            List<T_Loc> listAccCat = new List<T_Loc>(db.T_Locs.Select((T_Loc item) => item).ToList());
            txtRoomDirction.DataSource = listAccCat;
            txtRoomDirction.DisplayMember = ((LangArEn == 0) ? "Arb_Des" : "Eng_Des");
            txtRoomDirction.ValueMember = "Loc_ID";
            txtRoomDirction.SelectedIndex = 0;
            txtRoomBedTyp.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                txtRoomBedTyp.Items.Add("غير متوفر");
                txtRoomBedTyp.Items.Add("مزدوج");
                txtRoomBedTyp.Items.Add("فردي");
            }
            else
            {
                txtRoomBedTyp.Items.Add("not available");
                txtRoomBedTyp.Items.Add("Double");
                txtRoomBedTyp.Items.Add("Single");
            }
            txtRoomBedTyp.SelectedIndex = 0;
            txtRoomFurnitur.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                txtRoomFurnitur.Items.Add("غير مفـروشة");
                txtRoomFurnitur.Items.Add("مفــروشة");
            }
            else
            {
                txtRoomFurnitur.Items.Add("Not furnished");
                txtRoomFurnitur.Items.Add("Furnished");
            }
            txtRoomFurnitur.SelectedIndex = 0;
            txtRoomTwalitTyp.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                txtRoomTwalitTyp.Items.Add("غير متوفر");
                txtRoomTwalitTyp.Items.Add("مستقل داخلي");
                txtRoomTwalitTyp.Items.Add("مستقل خارجي");
                txtRoomTwalitTyp.Items.Add("مشترك");
            }
            else
            {
                txtRoomTwalitTyp.Items.Add("not available");
                txtRoomTwalitTyp.Items.Add("Independent");
                txtRoomTwalitTyp.Items.Add("Independent external");
                txtRoomTwalitTyp.Items.Add("Mutual");
            }
            txtRoomTwalitTyp.SelectedIndex = 0;
            txtRoomTv.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                txtRoomTv.Items.Add("متوفر");
                txtRoomTv.Items.Add("غير متوفر");
            }
            else
            {
                txtRoomTv.Items.Add("available");
                txtRoomTv.Items.Add("not available");
            }
            txtRoomTv.SelectedIndex = 0;
            txtRoomBalcony.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                txtRoomBalcony.Items.Add("متوفر");
                txtRoomBalcony.Items.Add("غير متوفر");
            }
            else
            {
                txtRoomBalcony.Items.Add("available");
                txtRoomBalcony.Items.Add("not available");
            }
            txtRoomBalcony.SelectedIndex = 0;
        }
        public void SetData(T_Rom value)
        {
            try
            {
                State = FormState.Saved;
                Button_Save.Enabled = false;
                textBox_ID.Tag = value.romno;
                txtRoomBalcony.SelectedIndex = value.bl.Value;
                txtRoomBedCount.Value = value.bedno.Value;
                txtRoomFurnitur.SelectedIndex = value.Furnished.Value;
                txtRoomCount.Value = value.RoomCount.Value;
                txtSalaacount.Value = value.loungesCount.Value;
                txtKitchinCount.Value = value.kitchensCount.Value;
                txtRoomArea.Text = value.AreaDetail;
                txtRoomBedTyp.SelectedIndex = value.bed.Value;
                txtRoomCounterNo.Text = value.Numcounter;
                txtRoomDescription.Text = value.ShortDsc;
                if (value.aline.HasValue)
                {
                    txtRoomDirction.SelectedValue = value.aline;
                }
                else
                {
                    txtRoomDirction.SelectedIndex = 0;
                }
                txtRoomFloor.Text = value.flore.ToString();
                txtRoomFloor_TextChanged(null, null);
                try
                {
                    if (value.perno.HasValue)
                    {
                        txtRoomGuest.Text = ((LangArEn == 0) ? db.StockPer(value.perno.Value).T_AccDef.Arb_Des : db.StockPer(value.perno.Value).T_AccDef.Eng_Des);
                    }
                    else
                    {
                        txtRoomGuest.Text = ((LangArEn == 0) ? "لا يوجد" : "not available");
                    }
                }
                catch
                {
                    txtRoomGuest.Text = ((LangArEn == 0) ? "لا يوجد" : "not available");
                }
                txtRoomPriceDaily1.Value = value.pri0.Value;
                txtRoomPriceDaily2.Value = value.pri1.Value;
                txtRoomPriceMonth1.Value = value.priM0.Value;
                txtRoomPriceMonth2.Value = value.priM1.Value;
                if (value.state.Value == 0)
                {
                    txtRoomSts.Text = ((LangArEn == 0) ? "صيانة" : "Repair");
                }
                if (value.state.Value == 1)
                {
                    txtRoomSts.Text = ((LangArEn == 0) ? "فارغة" : "Empty");
                }
                if (value.state.Value == 2)
                {
                    txtRoomSts.Text = ((LangArEn == 0) ? "نظافة" : "Cleaning");
                }
                if (value.state.Value == 3)
                {
                    txtRoomSts.Text = ((LangArEn == 0) ? "مشغولة" : "Bussy");
                }
                txtRoomTv.SelectedIndex = value.tv.Value;
                txtRoomTwalitCount.Value = value.wcno.Value;
                txtRoomTwalitTyp.SelectedIndex = value.wc.Value;
                txtRoomTyp.SelectedIndex = value.typ.Value;
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
        private T_Rom GetData()
        {
            textBox_ID.Focus();
            data_this.bl = txtRoomBalcony.SelectedIndex;
            data_this.bedno = txtRoomBedCount.Value;
            data_this.Furnished = txtRoomFurnitur.SelectedIndex;
            data_this.RoomCount = txtRoomCount.Value;
            data_this.loungesCount = txtSalaacount.Value;
            data_this.kitchensCount = txtKitchinCount.Value;
            data_this.AreaDetail = txtRoomArea.Text;
            data_this.bed = txtRoomBedTyp.SelectedIndex;
            data_this.Numcounter = txtRoomCounterNo.Text;
            data_this.ShortDsc = txtRoomDescription.Text;
            try
            {
                data_this.aline = int.Parse(txtRoomDirction.SelectedValue.ToString());
            }
            catch
            {
                data_this.aline = 1;
            }
            data_this.flore = txtRoomFloor.Value;
            data_this.pri0 = txtRoomPriceDaily1.Value;
            data_this.pri1 = txtRoomPriceDaily2.Value;
            data_this.priM0 = txtRoomPriceMonth1.Value;
            data_this.priM1 = txtRoomPriceMonth2.Value;
            data_this.tv = txtRoomTv.SelectedIndex;
            data_this.wcno = txtRoomTwalitCount.Value;
            data_this.wc = txtRoomTwalitTyp.SelectedIndex;
            data_this.typ = txtRoomTyp.SelectedIndex;
            data_this.CompanyID = 1;
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
                if (textBox_ID.Text == string.Empty || txtRoomFloor.Text == string.Empty || txtRoomGuest.Text == string.Empty)
                {
                    MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الرمز او الإسم فارغا\u0651" : "Can not be a number or name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (State == FormState.Edit)
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
                State = FormState.Saved;
                RefreshPKeys();
                TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(string.Concat(data_this.romno)) + 1);
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
            if (dataMember != null && dataMember == "T_Rom")
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
            panel.Columns["romno"].Width = 100;
            panel.Columns["romno"].Visible = columns_Names_visible["romno"].IfDefault;
            panel.Columns["flore"].Width = 100;
            panel.Columns["flore"].Visible = columns_Names_visible["flore"].IfDefault;
            panel.Columns["state"].Width = 150;
            panel.Columns["state"].Visible = columns_Names_visible["state"].IfDefault;
            panel.Columns["nmA"].Width = 250;
            panel.Columns["nmA"].Visible = columns_Names_visible["nmA"].IfDefault;
            panel.Columns["nmE"].Width = 250;
            panel.Columns["nmE"].Visible = columns_Names_visible["nmE"].IfDefault;
            panel.Columns["pri0"].Width = 150;
            panel.Columns["pri0"].Visible = columns_Names_visible["pri0"].IfDefault;
            panel.Columns["priM0"].Width = 150;
            panel.Columns["priM0"].Visible = columns_Names_visible["priM0"].IfDefault;
            panel.Columns["bedno"].Width = 100;
            panel.Columns["bedno"].Visible = columns_Names_visible["bedno"].IfDefault;
            panel.Columns["wcno"].Width = 100;
            panel.Columns["wcno"].Visible = columns_Names_visible["wcno"].IfDefault;
            panel.Columns["ShortDsc"].Width = 250;
            panel.Columns["ShortDsc"].Visible = columns_Names_visible["ShortDsc"].IfDefault;
            panel.ReadOnly = true;
        }
        private void DGV_MainGetCellStyle(object sender, GridGetCellStyleEventArgs e)
        {
        }
        private void Button_ExportTable2_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcel.ExportToExcel(DGV_Main, "تقرير مواصفات الغرف");
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
        public void Button_Print_Click(object sender, EventArgs e)
        {
            if (ViewState != 0)
            {
                return;
            }
            try
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Rom left join T_SYSSETTING on T_SYSSETTING.SYSSETTING_ID = T_Rom.CompanyID ";
                string Fields = string.Empty;
                Fields = " T_Rom.romno as No, T_Rom.Arb_Des as NmA, T_Rom.Eng_Des as NmE,T_SYSSETTING.LogImg ";
                _RepShow.Rule = string.Empty;
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
        private void DGV_Main_GetCellFormattedValue(object sender, GridGetCellFormattedValueEventArgs e)
        {
            try
            {
                if (!e.GridCell.GridColumn.Name.Equals("state") || e.GridCell.Value == null)
                {
                    return;
                }
                try
                {
                    if (e.GridCell.Value.ToString() == "0")
                    {
                        e.FormattedValue = ((LangArEn == 0) ? "صيانة" : "Repair");
                    }
                    if (e.GridCell.Value.ToString() == "1")
                    {
                        e.FormattedValue = ((LangArEn == 0) ? "فارغة" : "Empty");
                    }
                    if (e.GridCell.Value.ToString() == "2")
                    {
                        e.FormattedValue = ((LangArEn == 0) ? "نظافة" : "Cleaning");
                    }
                    if (e.GridCell.Value.ToString() == "3")
                    {
                        e.FormattedValue = ((LangArEn == 0) ? "مشغولة" : "Bussy");
                    }
                }
                catch
                {
                    e.FormattedValue = ((LangArEn == 0) ? "فارغة" : "Empty");
                }
            }
            catch
            {
            }
        }
        private void buttonItem_Digram_Click(object sender, EventArgs e)
        {
            if (State != 0)
            {
                return;
            }
            try
            {
                if (string.IsNullOrEmpty(textBox_ID.Text))
                {
                    return;
                }
            }
            catch
            {
                return;
            }
            FrmRoomDigram frm = new FrmRoomDigram();
            frm.Tag = LangArEn;
            VarGeneral._RunDiagram = true;
            frm.TopMost = true;
            frm.ShowDialog();
            dbInstance = null;
            RefreshPKeys();
            Button_Last_Click(sender, e);
        }
        private void button_SrchLocADD_Click(object sender, EventArgs e)
        {
            FrmLocation frm = new FrmLocation();
            frm.Tag = LangArEn;
            frm.TopMost = true;
            frm.ShowDialog();
            object c = txtRoomDirction.SelectedValue;
            try
            {
                txtRoomDirction.DataSource = null;
            }
            catch
            {
            }
            try
            {
                txtRoomDirction.Items.Clear();
            }
            catch
            {
            }
            List<T_Loc> listAccCat = new List<T_Loc>(db.T_Locs.Select((T_Loc item) => item).ToList());
            txtRoomDirction.DataSource = listAccCat;
            txtRoomDirction.DisplayMember = ((LangArEn == 0) ? "Arb_Des" : "Eng_Des");
            txtRoomDirction.ValueMember = "Loc_ID";
            txtRoomDirction.SelectedIndex = 0;
            txtRoomDirction.SelectedValue = c;
        }
        private void button_SrchLoc_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
            if (State == FormState.Saved)
            {
                return;
            }
            columns_Names_visible2.Clear();
            columns_Names_visible2.Add("Loc_No", new ColumnDictinary("الرقـــم", "No", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible2.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible2;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_Loc";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                txtRoomDirction.SelectedValue = db.StockLoc(int.Parse(frm.Serach_No).ToString()).Loc_ID;
            }
            else
            {
                txtRoomDirction.SelectedIndex = 0;
            }
        }
        private void txtRoomFloor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtRoomFloor.Text))
                {
                    txtFloorName.Text = string.Empty;
                    return;
                }
                List<T_RomChart> q = db.T_RomCharts.Where((T_RomChart t) => t.ID == txtRoomFloor.Value).ToList();
                if (q.Count > 0)
                {
                    txtFloorName.Text = ((LangArEn == 0) ? q.FirstOrDefault().FName : q.FirstOrDefault().FNameE);
                }
                else
                {
                    txtFloorName.Text = string.Empty;
                }
            }
            catch
            {
                txtFloorName.Text = string.Empty;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRoom));
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background3 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor1 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor2 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle1 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle2 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.Background background4 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtFloorName = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtRoomFurnitur = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label16 = new System.Windows.Forms.Label();
            this.txtSalaacount = new DevComponents.Editors.IntegerInput();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKitchinCount = new DevComponents.Editors.IntegerInput();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRoomCount = new DevComponents.Editors.IntegerInput();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRoomArea = new System.Windows.Forms.TextBox();
            this.button_SrchLoc = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtRoomTv = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRoomTwalitTyp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRoomBedTyp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRoomPriceMonth2 = new DevComponents.Editors.DoubleInput();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRoomPriceDaily2 = new DevComponents.Editors.DoubleInput();
            this.txtRoomDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label200 = new System.Windows.Forms.Label();
            this.txtRoomTyp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtRoomSts = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label400 = new System.Windows.Forms.Label();
            this.label300 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label380 = new System.Windows.Forms.Label();
            this.txtRoomFloor = new DevComponents.Editors.IntegerInput();
            this.txtRoomBedCount = new DevComponents.Editors.IntegerInput();
            this.txtRoomTwalitCount = new DevComponents.Editors.IntegerInput();
            this.txtRoomDirction = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtRoomBalcony = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtRoomPriceMonth1 = new DevComponents.Editors.DoubleInput();
            this.txtRoomPriceDaily1 = new DevComponents.Editors.DoubleInput();
            this.txtRoomCounterNo = new System.Windows.Forms.TextBox();
            this.txtRoomGuest = new System.Windows.Forms.TextBox();
            this.button_SrchLocADD = new DevComponents.DotNetBar.ButtonX();
            this.ribbonBar_Tasks = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl_Main1 = new DevComponents.DotNetBar.SuperTabControl();
            this.Button_Close = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Search = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Save = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem_Digram = new DevComponents.DotNetBar.ButtonItem();
            this.superTabControl_Main2 = new DevComponents.DotNetBar.SuperTabControl();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.Button_First = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Prev = new DevComponents.DotNetBar.ButtonItem();
            this.TextBox_Index = new DevComponents.DotNetBar.TextBoxItem();
            this.Label_Count = new DevComponents.DotNetBar.LabelItem();
            this.lable_Records = new DevComponents.DotNetBar.LabelItem();
            this.Button_Next = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Last = new DevComponents.DotNetBar.ButtonItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.DGV_Main = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.ribbonBar_DGV = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl_DGV = new DevComponents.DotNetBar.SuperTabControl();
            this.textBox_search = new DevComponents.DotNetBar.TextBoxItem();
            this.Button_ExportTable2 = new DevComponents.DotNetBar.ButtonItem();
            this.Button_PrintTable = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem3 = new DevComponents.DotNetBar.LabelItem();
            this.timerInfoBallon = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.barTopDockSite = new DevComponents.DotNetBar.DockSite();
            this.barBottomDockSite = new DevComponents.DotNetBar.DockSite();
            this.dotNetBarManager1 = new DevComponents.DotNetBar.DotNetBarManager(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.barLeftDockSite = new DevComponents.DotNetBar.DockSite();
            this.barRightDockSite = new DevComponents.DotNetBar.DockSite();
            this.dockSite4 = new DevComponents.DotNetBar.DockSite();
            this.dockSite1 = new DevComponents.DotNetBar.DockSite();
            this.dockSite2 = new DevComponents.DotNetBar.DockSite();
            this.dockSite3 = new DevComponents.DotNetBar.DockSite();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_Rep = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Det = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panelEx2.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalaacount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKitchinCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoomCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoomPriceMonth2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoomPriceDaily2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoomFloor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoomBedCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoomTwalitCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoomPriceMonth1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoomPriceDaily1)).BeginInit();
            this.ribbonBar_Tasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main2)).BeginInit();
            this.panelEx3.SuspendLayout();
            this.ribbonBar_DGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_DGV)).BeginInit();
            this.panel1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            this.expandableSplitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.expandableSplitter1.ExpandableControl = this.panelEx2;
            this.expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.ExpandLineColor = System.Drawing.SystemColors.ControlText;
            this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.ForeColor = System.Drawing.Color.Black;
            this.expandableSplitter1.GripDarkColor = System.Drawing.SystemColors.ControlText;
            this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(142)))), ((int)(((byte)(75)))));
            this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(139)))));
            this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotExpandLineColor = System.Drawing.SystemColors.ControlText;
            this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.Location = new System.Drawing.Point(0, 1);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(649, 14);
            this.expandableSplitter1.TabIndex = 1;
            this.expandableSplitter1.TabStop = false;
            // 
            // panelEx2
            // 
            this.panelEx2.Controls.Add(this.ribbonBar1);
            this.panelEx2.Controls.Add(this.ribbonBar_Tasks);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx2.Location = new System.Drawing.Point(0, 15);
            this.panelEx2.MinimumSize = new System.Drawing.Size(659, 353);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(659, 412);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 0;
            this.panelEx2.Text = "Click to collapse";
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
            this.ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.panel2);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(659, 361);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 867;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtFloorName);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.txtRoomFurnitur);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.txtSalaacount);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtKitchinCount);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtRoomCount);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtRoomArea);
            this.panel2.Controls.Add(this.button_SrchLoc);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.txtRoomTv);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.txtRoomTwalitTyp);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txtRoomBedTyp);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtRoomPriceMonth2);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtRoomPriceDaily2);
            this.panel2.Controls.Add(this.txtRoomDescription);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label200);
            this.panel2.Controls.Add(this.txtRoomTyp);
            this.panel2.Controls.Add(this.txtRoomSts);
            this.panel2.Controls.Add(this.textBox_ID);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label400);
            this.panel2.Controls.Add(this.label300);
            this.panel2.Controls.Add(this.label40);
            this.panel2.Controls.Add(this.label36);
            this.panel2.Controls.Add(this.label380);
            this.panel2.Controls.Add(this.txtRoomFloor);
            this.panel2.Controls.Add(this.txtRoomBedCount);
            this.panel2.Controls.Add(this.txtRoomTwalitCount);
            this.panel2.Controls.Add(this.txtRoomDirction);
            this.panel2.Controls.Add(this.txtRoomBalcony);
            this.panel2.Controls.Add(this.txtRoomPriceMonth1);
            this.panel2.Controls.Add(this.txtRoomPriceDaily1);
            this.panel2.Controls.Add(this.txtRoomCounterNo);
            this.panel2.Controls.Add(this.txtRoomGuest);
            this.panel2.Controls.Add(this.button_SrchLocADD);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(659, 344);
            this.panel2.TabIndex = 0;
            // 
            // txtFloorName
            // 
            this.txtFloorName.BackColor = System.Drawing.Color.DimGray;
            this.txtFloorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFloorName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtFloorName.ForeColor = System.Drawing.Color.White;
            this.txtFloorName.Location = new System.Drawing.Point(295, 34);
            this.txtFloorName.MaxLength = 30;
            this.txtFloorName.Name = "txtFloorName";
            this.txtFloorName.ReadOnly = true;
            this.txtFloorName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFloorName.Size = new System.Drawing.Size(164, 20);
            this.txtFloorName.TabIndex = 1226;
            this.txtFloorName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(221, 94);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(66, 13);
            this.label17.TabIndex = 1225;
            this.label17.Text = "حالة الفرش :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtRoomFurnitur
            // 
            this.txtRoomFurnitur.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtRoomFurnitur.DisplayMember = "Text";
            this.txtRoomFurnitur.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.txtRoomFurnitur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtRoomFurnitur.FormattingEnabled = true;
            this.txtRoomFurnitur.ItemHeight = 14;
            this.txtRoomFurnitur.Location = new System.Drawing.Point(30, 90);
            this.txtRoomFurnitur.Name = "txtRoomFurnitur";
            this.txtRoomFurnitur.Size = new System.Drawing.Size(187, 20);
            this.txtRoomFurnitur.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtRoomFurnitur.TabIndex = 1224;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(221, 150);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(69, 13);
            this.label16.TabIndex = 1222;
            this.label16.Text = "عدد الصالات :";
            // 
            // txtSalaacount
            // 
            this.txtSalaacount.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtSalaacount.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtSalaacount.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtSalaacount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSalaacount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtSalaacount.DisplayFormat = "0";
            this.txtSalaacount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtSalaacount.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtSalaacount.Location = new System.Drawing.Point(30, 146);
            this.txtSalaacount.MinValue = 0;
            this.txtSalaacount.Name = "txtSalaacount";
            this.txtSalaacount.ShowUpDown = true;
            this.txtSalaacount.Size = new System.Drawing.Size(187, 21);
            this.txtSalaacount.TabIndex = 1223;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(543, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 1220;
            this.label4.Text = "عدد المطابخ :";
            // 
            // txtKitchinCount
            // 
            this.txtKitchinCount.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtKitchinCount.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtKitchinCount.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtKitchinCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtKitchinCount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtKitchinCount.DisplayFormat = "0";
            this.txtKitchinCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtKitchinCount.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtKitchinCount.Location = new System.Drawing.Point(351, 146);
            this.txtKitchinCount.MinValue = 0;
            this.txtKitchinCount.Name = "txtKitchinCount";
            this.txtKitchinCount.ShowUpDown = true;
            this.txtKitchinCount.Size = new System.Drawing.Size(187, 21);
            this.txtKitchinCount.TabIndex = 1221;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(221, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 1218;
            this.label3.Text = "عدد الغرف :";
            // 
            // txtRoomCount
            // 
            this.txtRoomCount.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtRoomCount.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtRoomCount.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtRoomCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRoomCount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtRoomCount.DisplayFormat = "0";
            this.txtRoomCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtRoomCount.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtRoomCount.Location = new System.Drawing.Point(30, 118);
            this.txtRoomCount.MinValue = 1;
            this.txtRoomCount.Name = "txtRoomCount";
            this.txtRoomCount.ShowUpDown = true;
            this.txtRoomCount.Size = new System.Drawing.Size(187, 21);
            this.txtRoomCount.TabIndex = 1219;
            this.txtRoomCount.Value = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(543, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1217;
            this.label2.Text = "المساحة :";
            // 
            // txtRoomArea
            // 
            this.txtRoomArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRoomArea.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtRoomArea.ForeColor = System.Drawing.Color.Maroon;
            this.txtRoomArea.Location = new System.Drawing.Point(351, 118);
            this.txtRoomArea.MaxLength = 30;
            this.txtRoomArea.Name = "txtRoomArea";
            this.txtRoomArea.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRoomArea.Size = new System.Drawing.Size(187, 20);
            this.txtRoomArea.TabIndex = 1216;
            this.txtRoomArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_SrchLoc
            // 
            this.button_SrchLoc.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.button_SrchLoc.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchLoc.Location = new System.Drawing.Point(322, 90);
            this.button_SrchLoc.Name = "button_SrchLoc";
            this.button_SrchLoc.Size = new System.Drawing.Size(26, 20);
            this.button_SrchLoc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchLoc.Symbol = "";
            this.button_SrchLoc.SymbolSize = 12F;
            this.button_SrchLoc.TabIndex = 1090;
            this.button_SrchLoc.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchLoc.Click += new System.EventHandler(this.button_SrchLoc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(221, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1035;
            this.label1.Text = "حالة الغرفة :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(221, 262);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 13);
            this.label15.TabIndex = 1030;
            this.label15.Text = "تلفــــاز :";
            // 
            // txtRoomTv
            // 
            this.txtRoomTv.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtRoomTv.DisplayMember = "Text";
            this.txtRoomTv.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.txtRoomTv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtRoomTv.FormattingEnabled = true;
            this.txtRoomTv.ItemHeight = 14;
            this.txtRoomTv.Location = new System.Drawing.Point(30, 258);
            this.txtRoomTv.Name = "txtRoomTv";
            this.txtRoomTv.Size = new System.Drawing.Size(187, 20);
            this.txtRoomTv.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtRoomTv.TabIndex = 1029;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(221, 234);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 13);
            this.label13.TabIndex = 1026;
            this.label13.Text = "وصف الحمام :";
            // 
            // txtRoomTwalitTyp
            // 
            this.txtRoomTwalitTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtRoomTwalitTyp.DisplayMember = "Text";
            this.txtRoomTwalitTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.txtRoomTwalitTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtRoomTwalitTyp.FormattingEnabled = true;
            this.txtRoomTwalitTyp.ItemHeight = 14;
            this.txtRoomTwalitTyp.Location = new System.Drawing.Point(30, 230);
            this.txtRoomTwalitTyp.Name = "txtRoomTwalitTyp";
            this.txtRoomTwalitTyp.Size = new System.Drawing.Size(187, 20);
            this.txtRoomTwalitTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtRoomTwalitTyp.TabIndex = 1025;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(221, 206);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 1024;
            this.label12.Text = "وصف السرير :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtRoomBedTyp
            // 
            this.txtRoomBedTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtRoomBedTyp.DisplayMember = "Text";
            this.txtRoomBedTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.txtRoomBedTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtRoomBedTyp.FormattingEnabled = true;
            this.txtRoomBedTyp.ItemHeight = 14;
            this.txtRoomBedTyp.Location = new System.Drawing.Point(30, 202);
            this.txtRoomBedTyp.Name = "txtRoomBedTyp";
            this.txtRoomBedTyp.Size = new System.Drawing.Size(187, 20);
            this.txtRoomBedTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtRoomBedTyp.TabIndex = 1023;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(221, 318);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 13);
            this.label8.TabIndex = 1018;
            this.label8.Text = "السعر 2 - شهري :";
            // 
            // txtRoomPriceMonth2
            // 
            this.txtRoomPriceMonth2.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtRoomPriceMonth2.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtRoomPriceMonth2.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtRoomPriceMonth2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRoomPriceMonth2.ButtonCalculator.Visible = true;
            this.txtRoomPriceMonth2.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtRoomPriceMonth2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtRoomPriceMonth2.Increment = 1D;
            this.txtRoomPriceMonth2.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtRoomPriceMonth2.Location = new System.Drawing.Point(30, 314);
            this.txtRoomPriceMonth2.MinValue = 0D;
            this.txtRoomPriceMonth2.Name = "txtRoomPriceMonth2";
            this.txtRoomPriceMonth2.ShowUpDown = true;
            this.txtRoomPriceMonth2.Size = new System.Drawing.Size(187, 20);
            this.txtRoomPriceMonth2.TabIndex = 1016;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(221, 290);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 1014;
            this.label7.Text = "السعر 2 - يومــي :";
            // 
            // txtRoomPriceDaily2
            // 
            this.txtRoomPriceDaily2.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtRoomPriceDaily2.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtRoomPriceDaily2.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtRoomPriceDaily2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRoomPriceDaily2.ButtonCalculator.Visible = true;
            this.txtRoomPriceDaily2.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtRoomPriceDaily2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtRoomPriceDaily2.Increment = 1D;
            this.txtRoomPriceDaily2.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtRoomPriceDaily2.Location = new System.Drawing.Point(30, 286);
            this.txtRoomPriceDaily2.MinValue = 0D;
            this.txtRoomPriceDaily2.Name = "txtRoomPriceDaily2";
            this.txtRoomPriceDaily2.ShowUpDown = true;
            this.txtRoomPriceDaily2.Size = new System.Drawing.Size(187, 20);
            this.txtRoomPriceDaily2.TabIndex = 1012;
            // 
            // txtRoomDescription
            // 
            this.txtRoomDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRoomDescription.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtRoomDescription.ForeColor = System.Drawing.Color.Black;
            this.txtRoomDescription.Location = new System.Drawing.Point(30, 174);
            this.txtRoomDescription.MaxLength = 30;
            this.txtRoomDescription.Name = "txtRoomDescription";
            this.txtRoomDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRoomDescription.Size = new System.Drawing.Size(187, 20);
            this.txtRoomDescription.TabIndex = 1010;
            this.txtRoomDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(221, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 1009;
            this.label5.Text = "وصف مختصر :";
            // 
            // label200
            // 
            this.label200.AutoSize = true;
            this.label200.BackColor = System.Drawing.Color.Transparent;
            this.label200.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label200.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label200.Location = new System.Drawing.Point(221, 38);
            this.label200.Name = "label200";
            this.label200.Size = new System.Drawing.Size(60, 13);
            this.label200.TabIndex = 1004;
            this.label200.Text = "نوع الغرفة :";
            // 
            // txtRoomTyp
            // 
            this.txtRoomTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtRoomTyp.DisplayMember = "Text";
            this.txtRoomTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.txtRoomTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtRoomTyp.FormattingEnabled = true;
            this.txtRoomTyp.ItemHeight = 14;
            this.txtRoomTyp.Location = new System.Drawing.Point(30, 34);
            this.txtRoomTyp.Name = "txtRoomTyp";
            this.txtRoomTyp.Size = new System.Drawing.Size(187, 20);
            this.txtRoomTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtRoomTyp.TabIndex = 1003;
            // 
            // txtRoomSts
            // 
            this.txtRoomSts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            // 
            // 
            // 
            this.txtRoomSts.Border.Class = "TextBoxBorder";
            this.txtRoomSts.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRoomSts.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtRoomSts.ForeColor = System.Drawing.Color.Blue;
            this.txtRoomSts.Location = new System.Drawing.Point(30, 6);
            this.txtRoomSts.Name = "txtRoomSts";
            this.txtRoomSts.ReadOnly = true;
            this.txtRoomSts.Size = new System.Drawing.Size(187, 20);
            this.txtRoomSts.TabIndex = 1001;
            this.txtRoomSts.Tag = "rTrwes1";
            this.txtRoomSts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_ID
            // 
            this.textBox_ID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.textBox_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_ID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_ID.Location = new System.Drawing.Point(295, 6);
            this.textBox_ID.Name = "textBox_ID";
            this.textBox_ID.ReadOnly = true;
            this.textBox_ID.Size = new System.Drawing.Size(243, 21);
            this.textBox_ID.TabIndex = 995;
            this.textBox_ID.TextChanged += new System.EventHandler(this.textBox_ID_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(543, 262);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 13);
            this.label14.TabIndex = 1028;
            this.label14.Text = "شرفة / بلكونة :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(543, 234);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 13);
            this.label11.TabIndex = 1022;
            this.label11.Text = "عدد الحمامات :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(543, 206);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 1020;
            this.label10.Text = "عدد السراير  :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(543, 318);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 13);
            this.label9.TabIndex = 1017;
            this.label9.Text = "السعر - شهري :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(543, 290);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 1013;
            this.label6.Text = "السعر  - يومـي :";
            // 
            // label400
            // 
            this.label400.AutoSize = true;
            this.label400.BackColor = System.Drawing.Color.Transparent;
            this.label400.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label400.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label400.Location = new System.Drawing.Point(543, 178);
            this.label400.Name = "label400";
            this.label400.Size = new System.Drawing.Size(71, 13);
            this.label400.TabIndex = 1007;
            this.label400.Text = "عدّاد الكهرباء :";
            // 
            // label300
            // 
            this.label300.AutoSize = true;
            this.label300.BackColor = System.Drawing.Color.Transparent;
            this.label300.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label300.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label300.Location = new System.Drawing.Point(543, 94);
            this.label300.Name = "label300";
            this.label300.Size = new System.Drawing.Size(70, 13);
            this.label300.TabIndex = 1005;
            this.label300.Text = "وصف الموقع :";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.BackColor = System.Drawing.Color.Transparent;
            this.label40.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label40.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label40.Location = new System.Drawing.Point(543, 66);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(40, 13);
            this.label40.TabIndex = 1000;
            this.label40.Text = "النزيل :";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.Transparent;
            this.label36.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label36.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label36.Location = new System.Drawing.Point(543, 38);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(75, 13);
            this.label36.TabIndex = 999;
            this.label36.Text = "الدور / الطابق :";
            // 
            // label380
            // 
            this.label380.AutoSize = true;
            this.label380.BackColor = System.Drawing.Color.Transparent;
            this.label380.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label380.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label380.Location = new System.Drawing.Point(543, 10);
            this.label380.Name = "label380";
            this.label380.Size = new System.Drawing.Size(62, 13);
            this.label380.TabIndex = 998;
            this.label380.Text = "رقم الغرفة :";
            // 
            // txtRoomFloor
            // 
            this.txtRoomFloor.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtRoomFloor.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtRoomFloor.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtRoomFloor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRoomFloor.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtRoomFloor.DisplayFormat = "0";
            this.txtRoomFloor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtRoomFloor.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtRoomFloor.IsInputReadOnly = true;
            this.txtRoomFloor.Location = new System.Drawing.Point(461, 34);
            this.txtRoomFloor.MinValue = 1;
            this.txtRoomFloor.Name = "txtRoomFloor";
            this.txtRoomFloor.Size = new System.Drawing.Size(77, 21);
            this.txtRoomFloor.TabIndex = 1034;
            this.txtRoomFloor.Value = 1;
            this.txtRoomFloor.TextChanged += new System.EventHandler(this.txtRoomFloor_TextChanged);
            // 
            // txtRoomBedCount
            // 
            this.txtRoomBedCount.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtRoomBedCount.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtRoomBedCount.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtRoomBedCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRoomBedCount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtRoomBedCount.DisplayFormat = "0";
            this.txtRoomBedCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtRoomBedCount.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtRoomBedCount.Location = new System.Drawing.Point(351, 202);
            this.txtRoomBedCount.MinValue = 0;
            this.txtRoomBedCount.Name = "txtRoomBedCount";
            this.txtRoomBedCount.ShowUpDown = true;
            this.txtRoomBedCount.Size = new System.Drawing.Size(187, 21);
            this.txtRoomBedCount.TabIndex = 1033;
            // 
            // txtRoomTwalitCount
            // 
            this.txtRoomTwalitCount.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtRoomTwalitCount.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtRoomTwalitCount.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtRoomTwalitCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRoomTwalitCount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtRoomTwalitCount.DisplayFormat = "0";
            this.txtRoomTwalitCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtRoomTwalitCount.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtRoomTwalitCount.Location = new System.Drawing.Point(351, 230);
            this.txtRoomTwalitCount.MinValue = 0;
            this.txtRoomTwalitCount.Name = "txtRoomTwalitCount";
            this.txtRoomTwalitCount.ShowUpDown = true;
            this.txtRoomTwalitCount.Size = new System.Drawing.Size(187, 21);
            this.txtRoomTwalitCount.TabIndex = 1032;
            // 
            // txtRoomDirction
            // 
            this.txtRoomDirction.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtRoomDirction.DisplayMember = "Text";
            this.txtRoomDirction.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.txtRoomDirction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtRoomDirction.FormattingEnabled = true;
            this.txtRoomDirction.ItemHeight = 14;
            this.txtRoomDirction.Location = new System.Drawing.Point(351, 90);
            this.txtRoomDirction.Name = "txtRoomDirction";
            this.txtRoomDirction.Size = new System.Drawing.Size(187, 20);
            this.txtRoomDirction.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtRoomDirction.TabIndex = 1031;
            // 
            // txtRoomBalcony
            // 
            this.txtRoomBalcony.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtRoomBalcony.DisplayMember = "Text";
            this.txtRoomBalcony.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.txtRoomBalcony.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtRoomBalcony.FormattingEnabled = true;
            this.txtRoomBalcony.ItemHeight = 14;
            this.txtRoomBalcony.Location = new System.Drawing.Point(351, 258);
            this.txtRoomBalcony.Name = "txtRoomBalcony";
            this.txtRoomBalcony.Size = new System.Drawing.Size(187, 20);
            this.txtRoomBalcony.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtRoomBalcony.TabIndex = 1027;
            // 
            // txtRoomPriceMonth1
            // 
            this.txtRoomPriceMonth1.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtRoomPriceMonth1.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtRoomPriceMonth1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtRoomPriceMonth1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRoomPriceMonth1.ButtonCalculator.Visible = true;
            this.txtRoomPriceMonth1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtRoomPriceMonth1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtRoomPriceMonth1.Increment = 1D;
            this.txtRoomPriceMonth1.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtRoomPriceMonth1.Location = new System.Drawing.Point(351, 314);
            this.txtRoomPriceMonth1.MinValue = 0D;
            this.txtRoomPriceMonth1.Name = "txtRoomPriceMonth1";
            this.txtRoomPriceMonth1.ShowUpDown = true;
            this.txtRoomPriceMonth1.Size = new System.Drawing.Size(187, 20);
            this.txtRoomPriceMonth1.TabIndex = 1015;
            // 
            // txtRoomPriceDaily1
            // 
            this.txtRoomPriceDaily1.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtRoomPriceDaily1.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtRoomPriceDaily1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtRoomPriceDaily1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRoomPriceDaily1.ButtonCalculator.Visible = true;
            this.txtRoomPriceDaily1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtRoomPriceDaily1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtRoomPriceDaily1.Increment = 1D;
            this.txtRoomPriceDaily1.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtRoomPriceDaily1.Location = new System.Drawing.Point(351, 286);
            this.txtRoomPriceDaily1.MinValue = 0D;
            this.txtRoomPriceDaily1.Name = "txtRoomPriceDaily1";
            this.txtRoomPriceDaily1.ShowUpDown = true;
            this.txtRoomPriceDaily1.Size = new System.Drawing.Size(187, 20);
            this.txtRoomPriceDaily1.TabIndex = 1011;
            // 
            // txtRoomCounterNo
            // 
            this.txtRoomCounterNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRoomCounterNo.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtRoomCounterNo.ForeColor = System.Drawing.Color.Black;
            this.txtRoomCounterNo.Location = new System.Drawing.Point(351, 174);
            this.txtRoomCounterNo.MaxLength = 30;
            this.txtRoomCounterNo.Name = "txtRoomCounterNo";
            this.txtRoomCounterNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRoomCounterNo.Size = new System.Drawing.Size(187, 20);
            this.txtRoomCounterNo.TabIndex = 1008;
            this.txtRoomCounterNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRoomGuest
            // 
            this.txtRoomGuest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRoomGuest.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtRoomGuest.ForeColor = System.Drawing.Color.Maroon;
            this.txtRoomGuest.Location = new System.Drawing.Point(30, 62);
            this.txtRoomGuest.MaxLength = 30;
            this.txtRoomGuest.Name = "txtRoomGuest";
            this.txtRoomGuest.ReadOnly = true;
            this.txtRoomGuest.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRoomGuest.Size = new System.Drawing.Size(507, 20);
            this.txtRoomGuest.TabIndex = 997;
            this.txtRoomGuest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_SrchLocADD
            // 
            this.button_SrchLocADD.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.button_SrchLocADD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchLocADD.Location = new System.Drawing.Point(295, 90);
            this.button_SrchLocADD.Name = "button_SrchLocADD";
            this.button_SrchLocADD.Size = new System.Drawing.Size(26, 20);
            this.button_SrchLocADD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchLocADD.Symbol = "";
            this.button_SrchLocADD.SymbolSize = 12F;
            this.button_SrchLocADD.TabIndex = 1215;
            this.button_SrchLocADD.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchLocADD.Click += new System.EventHandler(this.button_SrchLocADD_Click);
            // 
            // ribbonBar_Tasks
            // 
            this.ribbonBar_Tasks.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar_Tasks.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar_Tasks.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar_Tasks.ContainerControlProcessDialogKey = true;
            this.ribbonBar_Tasks.Controls.Add(this.superTabControl_Main1);
            this.ribbonBar_Tasks.Controls.Add(this.superTabControl_Main2);
            this.ribbonBar_Tasks.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ribbonBar_Tasks.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar_Tasks.Location = new System.Drawing.Point(0, 361);
            this.ribbonBar_Tasks.Name = "ribbonBar_Tasks";
            this.ribbonBar_Tasks.Size = new System.Drawing.Size(659, 51);
            this.ribbonBar_Tasks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar_Tasks.TabIndex = 868;
            // 
            // 
            // 
            this.ribbonBar_Tasks.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar_Tasks.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar_Tasks.TitleVisible = false;
            // 
            // superTabControl_Main1
            // 
            this.superTabControl_Main1.BackColor = System.Drawing.Color.White;
            this.superTabControl_Main1.CausesValidation = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl_Main1.ControlBox.CloseBox.Name = string.Empty;
            // 
            // 
            // 
            this.superTabControl_Main1.ControlBox.MenuBox.Name = string.Empty;
            this.superTabControl_Main1.ControlBox.Name = string.Empty;
            this.superTabControl_Main1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl_Main1.ControlBox.MenuBox,
            this.superTabControl_Main1.ControlBox.CloseBox});
            this.superTabControl_Main1.ControlBox.Visible = false;
            this.superTabControl_Main1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl_Main1.ForeColor = System.Drawing.Color.Black;
            this.superTabControl_Main1.ItemPadding.Bottom = 4;
            this.superTabControl_Main1.ItemPadding.Left = 2;
            this.superTabControl_Main1.ItemPadding.Top = 4;
            this.superTabControl_Main1.Location = new System.Drawing.Point(0, 0);
            this.superTabControl_Main1.Name = "superTabControl_Main1";
            this.superTabControl_Main1.ReorderTabsEnabled = true;
            this.superTabControl_Main1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.superTabControl_Main1.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_Main1.SelectedTabIndex = -1;
            this.superTabControl_Main1.Size = new System.Drawing.Size(249, 51);
            this.superTabControl_Main1.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_Main1.TabIndex = 10;
            this.superTabControl_Main1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.Button_Close,
            this.Button_Search,
            this.Button_Save,
            this.buttonItem_Digram});
            this.superTabControl_Main1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.superTabControl_Main1.Text = "superTabControl3";
            this.superTabControl_Main1.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            // 
            // Button_Close
            // 
            this.Button_Close.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Close.Checked = true;
            this.Button_Close.FontBold = true;
            this.Button_Close.FontItalic = true;
            this.Button_Close.ForeColor = System.Drawing.Color.Black;
            this.Button_Close.Image = ((System.Drawing.Image)(resources.GetObject("Button_Close.Image")));
            this.Button_Close.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Close.ImagePaddingHorizontal = 15;
            this.Button_Close.ImagePaddingVertical = 11;
            this.Button_Close.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Close.Name = "Button_Close";
            this.Button_Close.Stretch = true;
            this.Button_Close.SubItemsExpandWidth = 14;
            this.Button_Close.Symbol = "";
            this.Button_Close.SymbolSize = 15F;
            this.Button_Close.Text = "إغلاق";
            this.Button_Close.Tooltip = "إغلاق النافذة الحالية";
            // 
            // Button_Search
            // 
            this.Button_Search.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Search.FontBold = true;
            this.Button_Search.FontItalic = true;
            this.Button_Search.ForeColor = System.Drawing.Color.Green;
            this.Button_Search.Image = ((System.Drawing.Image)(resources.GetObject("Button_Search.Image")));
            this.Button_Search.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Search.ImagePaddingHorizontal = 15;
            this.Button_Search.ImagePaddingVertical = 11;
            this.Button_Search.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Search.Name = "Button_Search";
            this.Button_Search.Stretch = true;
            this.Button_Search.SubItemsExpandWidth = 14;
            this.Button_Search.Symbol = "";
            this.Button_Search.SymbolSize = 15F;
            this.Button_Search.Text = "بحث";
            this.Button_Search.Tooltip = "البحث عن سجل ما";
            // 
            // Button_Save
            // 
            this.Button_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Save.FontBold = true;
            this.Button_Save.FontItalic = true;
            this.Button_Save.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Button_Save.Image = ((System.Drawing.Image)(resources.GetObject("Button_Save.Image")));
            this.Button_Save.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Save.ImagePaddingHorizontal = 15;
            this.Button_Save.ImagePaddingVertical = 11;
            this.Button_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Stretch = true;
            this.Button_Save.SubItemsExpandWidth = 14;
            this.Button_Save.Symbol = "";
            this.Button_Save.SymbolSize = 15F;
            this.Button_Save.Text = "حفظ";
            this.Button_Save.Tooltip = "حفظ التغييرات";
            // 
            // buttonItem_Digram
            // 
            this.buttonItem_Digram.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem_Digram.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.buttonItem_Digram.FontBold = true;
            this.buttonItem_Digram.FontItalic = true;
            this.buttonItem_Digram.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.buttonItem_Digram.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem_Digram.Image")));
            this.buttonItem_Digram.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.buttonItem_Digram.ImagePaddingHorizontal = 15;
            this.buttonItem_Digram.ImagePaddingVertical = 11;
            this.buttonItem_Digram.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.buttonItem_Digram.Name = "buttonItem_Digram";
            this.buttonItem_Digram.Stretch = true;
            this.buttonItem_Digram.SubItemsExpandWidth = 14;
            this.buttonItem_Digram.Symbol = "";
            this.buttonItem_Digram.SymbolSize = 15F;
            this.buttonItem_Digram.Text = "تخطيط الغرف";
            this.buttonItem_Digram.Click += new System.EventHandler(this.buttonItem_Digram_Click);
            // 
            // superTabControl_Main2
            // 
            this.superTabControl_Main2.BackColor = System.Drawing.Color.White;
            this.superTabControl_Main2.CausesValidation = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl_Main2.ControlBox.CloseBox.Name = string.Empty;
            // 
            // 
            // 
            this.superTabControl_Main2.ControlBox.MenuBox.Name = string.Empty;
            this.superTabControl_Main2.ControlBox.Name = string.Empty;
            this.superTabControl_Main2.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl_Main2.ControlBox.MenuBox,
            this.superTabControl_Main2.ControlBox.CloseBox});
            this.superTabControl_Main2.ControlBox.Visible = false;
            this.superTabControl_Main2.Dock = System.Windows.Forms.DockStyle.Right;
            this.superTabControl_Main2.ForeColor = System.Drawing.Color.Black;
            this.superTabControl_Main2.ItemPadding.Bottom = 4;
            this.superTabControl_Main2.ItemPadding.Left = 4;
            this.superTabControl_Main2.ItemPadding.Right = 4;
            this.superTabControl_Main2.ItemPadding.Top = 4;
            this.superTabControl_Main2.Location = new System.Drawing.Point(249, 0);
            this.superTabControl_Main2.Name = "superTabControl_Main2";
            this.superTabControl_Main2.ReorderTabsEnabled = true;
            this.superTabControl_Main2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.superTabControl_Main2.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_Main2.SelectedTabIndex = -1;
            this.superTabControl_Main2.Size = new System.Drawing.Size(410, 51);
            this.superTabControl_Main2.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_Main2.TabIndex = 11;
            this.superTabControl_Main2.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem1,
            this.Button_First,
            this.Button_Prev,
            this.TextBox_Index,
            this.Label_Count,
            this.lable_Records,
            this.Button_Next,
            this.Button_Last});
            this.superTabControl_Main2.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.superTabControl_Main2.Text = "superTabControl1";
            this.superTabControl_Main2.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Width = 2;
            // 
            // Button_First
            // 
            this.Button_First.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_First.FontBold = true;
            this.Button_First.FontItalic = true;
            this.Button_First.ForeColor = System.Drawing.Color.SteelBlue;
            this.Button_First.Image = ((System.Drawing.Image)(resources.GetObject("Button_First.Image")));
            this.Button_First.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_First.ImagePaddingHorizontal = 15;
            this.Button_First.ImagePaddingVertical = 11;
            this.Button_First.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_First.Name = "Button_First";
            this.Button_First.SplitButton = true;
            this.Button_First.Stretch = true;
            this.Button_First.SubItemsExpandWidth = 14;
            this.Button_First.Symbol = "";
            this.Button_First.SymbolSize = 15F;
            this.Button_First.Text = "الأول";
            this.Button_First.Tooltip = "السجل الاول";
            // 
            // Button_Prev
            // 
            this.Button_Prev.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Prev.FontBold = true;
            this.Button_Prev.FontItalic = true;
            this.Button_Prev.ForeColor = System.Drawing.Color.SteelBlue;
            this.Button_Prev.Image = ((System.Drawing.Image)(resources.GetObject("Button_Prev.Image")));
            this.Button_Prev.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Prev.ImagePaddingHorizontal = 15;
            this.Button_Prev.ImagePaddingVertical = 11;
            this.Button_Prev.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Prev.Name = "Button_Prev";
            this.Button_Prev.SplitButton = true;
            this.Button_Prev.Stretch = true;
            this.Button_Prev.SubItemsExpandWidth = 14;
            this.Button_Prev.Symbol = "";
            this.Button_Prev.SymbolSize = 15F;
            this.Button_Prev.Text = "السابق";
            this.Button_Prev.Tooltip = "السجل السابق";
            // 
            // TextBox_Index
            // 
            this.TextBox_Index.Name = "TextBox_Index";
            this.TextBox_Index.TextBoxWidth = 50;
            this.TextBox_Index.Visible = false;
            this.TextBox_Index.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // Label_Count
            // 
            this.Label_Count.Name = "Label_Count";
            this.Label_Count.Visible = false;
            this.Label_Count.Width = 40;
            // 
            // lable_Records
            // 
            this.lable_Records.BackColor = System.Drawing.Color.SteelBlue;
            this.lable_Records.ForeColor = System.Drawing.Color.White;
            this.lable_Records.Name = "lable_Records";
            this.lable_Records.Text = "---";
            // 
            // Button_Next
            // 
            this.Button_Next.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Next.FontBold = true;
            this.Button_Next.FontItalic = true;
            this.Button_Next.ForeColor = System.Drawing.Color.SteelBlue;
            this.Button_Next.Image = ((System.Drawing.Image)(resources.GetObject("Button_Next.Image")));
            this.Button_Next.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Next.ImagePaddingHorizontal = 15;
            this.Button_Next.ImagePaddingVertical = 11;
            this.Button_Next.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Next.Name = "Button_Next";
            this.Button_Next.SplitButton = true;
            this.Button_Next.Stretch = true;
            this.Button_Next.SubItemsExpandWidth = 14;
            this.Button_Next.Symbol = "";
            this.Button_Next.SymbolSize = 15F;
            this.Button_Next.Text = "التالي";
            this.Button_Next.Tooltip = " السجل التالي";
            // 
            // Button_Last
            // 
            this.Button_Last.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Last.FontBold = true;
            this.Button_Last.FontItalic = true;
            this.Button_Last.ForeColor = System.Drawing.Color.SteelBlue;
            this.Button_Last.Image = ((System.Drawing.Image)(resources.GetObject("Button_Last.Image")));
            this.Button_Last.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Last.ImagePaddingHorizontal = 15;
            this.Button_Last.ImagePaddingVertical = 11;
            this.Button_Last.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Last.Name = "Button_Last";
            this.Button_Last.SplitButton = true;
            this.Button_Last.Stretch = true;
            this.Button_Last.SubItemsExpandWidth = 14;
            this.Button_Last.Symbol = "";
            this.Button_Last.SymbolSize = 15F;
            this.Button_Last.Text = "الأخير";
            this.Button_Last.Tooltip = " السجل الاخير";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "*.rtf";
            this.saveFileDialog1.FileName = "doc1";
            this.saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf|All Files(*.*)|*.*";
            this.saveFileDialog1.FilterIndex = 2;
            this.saveFileDialog1.Title = "Save File";
            // 
            // DGV_Main
            // 
            this.DGV_Main.BackColor = System.Drawing.Color.Transparent;
            background1.BackFillType = DevComponents.DotNetBar.SuperGrid.Style.BackFillType.VerticalCenter;
            background1.Color1 = System.Drawing.Color.Silver;
            background1.Color2 = System.Drawing.Color.White;
            this.DGV_Main.DefaultVisualStyles.GroupByStyles.Default.Background = background1;
            background2.BackFillType = DevComponents.DotNetBar.SuperGrid.Style.BackFillType.Center;
            background2.Color1 = System.Drawing.Color.LightSteelBlue;
            this.DGV_Main.DefaultVisualStyles.RowStyles.Default.Background = background2;
            background3.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.DGV_Main.DefaultVisualStyles.RowStyles.MouseOver.Background = background3;
            this.DGV_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Main.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.DGV_Main.Font = new System.Drawing.Font("Tahoma", 9F);
            this.DGV_Main.ForeColor = System.Drawing.Color.Black;
            this.DGV_Main.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.DGV_Main.Location = new System.Drawing.Point(0, 0);
            this.DGV_Main.Name = "DGV_Main";
            this.DGV_Main.PrimaryGrid.ActiveRowIndicatorStyle = DevComponents.DotNetBar.SuperGrid.ActiveRowIndicatorStyle.Both;
            this.DGV_Main.PrimaryGrid.AllowEdit = false;
            this.DGV_Main.PrimaryGrid.Caption.BackgroundImageLayout = DevComponents.DotNetBar.SuperGrid.GridBackgroundImageLayout.Center;
            this.DGV_Main.PrimaryGrid.Caption.Text = string.Empty;
            this.DGV_Main.PrimaryGrid.Caption.Visible = false;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.TextColor = System.Drawing.Color.Black;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.TextColor = System.Drawing.Color.Black;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.CaptionStyles.Default.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.CaptionStyles.Default.TextColor = System.Drawing.Color.White;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.CaptionStyles.ReadOnly.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.CellStyles.Selected.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderRowStyles.Default.RowHeader.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            borderColor1.Bottom = System.Drawing.Color.Black;
            borderColor1.Left = System.Drawing.Color.Black;
            borderColor1.Right = System.Drawing.Color.Black;
            borderColor1.Top = System.Drawing.Color.Black;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.BorderColor = borderColor1;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.TextColor = System.Drawing.Color.SteelBlue;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.TextColor = System.Drawing.Color.White;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.FooterStyles.Default.TextColor = System.Drawing.Color.White;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            borderColor2.Bottom = System.Drawing.Color.Black;
            borderColor2.Left = System.Drawing.Color.Black;
            borderColor2.Right = System.Drawing.Color.Black;
            borderColor2.Top = System.Drawing.Color.Black;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.BorderColor = borderColor2;
            baseTreeButtonVisualStyle1.BorderColor = System.Drawing.Color.White;
            baseTreeButtonVisualStyle1.LineColor = System.Drawing.Color.White;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.CircleTreeButtonStyle.ExpandButton = baseTreeButtonVisualStyle1;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.HeaderHLinePattern = DevComponents.DotNetBar.SuperGrid.Style.LinePattern.None;
            background4.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            baseTreeButtonVisualStyle2.Background = background4;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.SquareTreeButtonStyle.ExpandButton = baseTreeButtonVisualStyle2;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.TextColor = System.Drawing.Color.White;
            this.DGV_Main.PrimaryGrid.DefaultVisualStyles.TitleStyles.Default.RowHeaderStyle.TextAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.DGV_Main.PrimaryGrid.GroupByRow.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.Never;
            this.DGV_Main.PrimaryGrid.GroupByRow.Text = "جميــع السجــــلات";
            this.DGV_Main.PrimaryGrid.GroupByRow.Visible = true;
            this.DGV_Main.PrimaryGrid.GroupByRow.WatermarkText = string.Empty;
            this.DGV_Main.PrimaryGrid.InitialActiveRow = DevComponents.DotNetBar.SuperGrid.RelativeRow.None;
            this.DGV_Main.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.None;
            this.DGV_Main.PrimaryGrid.MultiSelect = false;
            this.DGV_Main.PrimaryGrid.ShowRowGridIndex = true;
            this.DGV_Main.PrimaryGrid.Title.AllowSelection = false;
            this.DGV_Main.PrimaryGrid.Title.Text = string.Empty;
            this.DGV_Main.PrimaryGrid.Title.Visible = false;
            this.DGV_Main.PrimaryGrid.Visible = false;
            this.DGV_Main.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DGV_Main.Size = new System.Drawing.Size(649, 0);
            this.DGV_Main.TabIndex = 862;
            this.DGV_Main.GetCellFormattedValue += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridGetCellFormattedValueEventArgs>(this.DGV_Main_GetCellFormattedValue);
            // 
            // panelEx3
            // 
            this.panelEx3.Controls.Add(this.DGV_Main);
            this.panelEx3.Controls.Add(this.ribbonBar_DGV);
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx3.Location = new System.Drawing.Point(0, 0);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(649, 1);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.panelEx3.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 2;
            this.panelEx3.Text = "Fill Panel";
            // 
            // ribbonBar_DGV
            // 
            this.ribbonBar_DGV.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar_DGV.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar_DGV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar_DGV.ContainerControlProcessDialogKey = true;
            this.ribbonBar_DGV.Controls.Add(this.superTabControl_DGV);
            this.ribbonBar_DGV.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ribbonBar_DGV.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar_DGV.Location = new System.Drawing.Point(0, -50);
            this.ribbonBar_DGV.Name = "ribbonBar_DGV";
            this.ribbonBar_DGV.Size = new System.Drawing.Size(649, 51);
            this.ribbonBar_DGV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar_DGV.TabIndex = 869;
            // 
            // 
            // 
            this.ribbonBar_DGV.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar_DGV.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar_DGV.TitleVisible = false;
            // 
            // superTabControl_DGV
            // 
            this.superTabControl_DGV.BackColor = System.Drawing.Color.White;
            this.superTabControl_DGV.CausesValidation = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl_DGV.ControlBox.CloseBox.Name = string.Empty;
            // 
            // 
            // 
            this.superTabControl_DGV.ControlBox.MenuBox.Name = string.Empty;
            this.superTabControl_DGV.ControlBox.Name = string.Empty;
            this.superTabControl_DGV.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl_DGV.ControlBox.MenuBox,
            this.superTabControl_DGV.ControlBox.CloseBox});
            this.superTabControl_DGV.ControlBox.Visible = false;
            this.superTabControl_DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl_DGV.ForeColor = System.Drawing.Color.Black;
            this.superTabControl_DGV.ItemPadding.Bottom = 4;
            this.superTabControl_DGV.ItemPadding.Left = 4;
            this.superTabControl_DGV.ItemPadding.Right = 4;
            this.superTabControl_DGV.ItemPadding.Top = 4;
            this.superTabControl_DGV.Location = new System.Drawing.Point(0, 0);
            this.superTabControl_DGV.Name = "superTabControl_DGV";
            this.superTabControl_DGV.ReorderTabsEnabled = true;
            this.superTabControl_DGV.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.superTabControl_DGV.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_DGV.SelectedTabIndex = -1;
            this.superTabControl_DGV.Size = new System.Drawing.Size(649, 51);
            this.superTabControl_DGV.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_DGV.TabIndex = 12;
            this.superTabControl_DGV.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.textBox_search,
            this.Button_ExportTable2,
            this.Button_PrintTable,
            this.labelItem3});
            this.superTabControl_DGV.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.superTabControl_DGV.Text = "superTabControl1";
            this.superTabControl_DGV.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            // 
            // textBox_search
            // 
            this.textBox_search.ButtonCustom.Text = "...";
            this.textBox_search.ButtonCustom.Visible = true;
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.TextBoxHeight = 44;
            this.textBox_search.TextBoxWidth = 150;
            this.textBox_search.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // Button_ExportTable2
            // 
            this.Button_ExportTable2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_ExportTable2.FontBold = true;
            this.Button_ExportTable2.FontItalic = true;
            this.Button_ExportTable2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Button_ExportTable2.Image = ((System.Drawing.Image)(resources.GetObject("Button_ExportTable2.Image")));
            this.Button_ExportTable2.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.Button_ExportTable2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_ExportTable2.Name = "Button_ExportTable2";
            this.Button_ExportTable2.SubItemsExpandWidth = 14;
            this.Button_ExportTable2.Symbol = "";
            this.Button_ExportTable2.SymbolSize = 15F;
            this.Button_ExportTable2.Text = "تصدير";
            this.Button_ExportTable2.Tooltip = "تصدير الى الأكسيل";
            // 
            // Button_PrintTable
            // 
            this.Button_PrintTable.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_PrintTable.Checked = true;
            this.Button_PrintTable.FontBold = true;
            this.Button_PrintTable.FontItalic = true;
            this.Button_PrintTable.Image = ((System.Drawing.Image)(resources.GetObject("Button_PrintTable.Image")));
            this.Button_PrintTable.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.Button_PrintTable.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_PrintTable.Name = "Button_PrintTable";
            this.Button_PrintTable.SubItemsExpandWidth = 14;
            this.Button_PrintTable.Symbol = "";
            this.Button_PrintTable.SymbolSize = 15F;
            this.Button_PrintTable.Text = "طباعة";
            this.Button_PrintTable.Tooltip = "طباعة";
            this.Button_PrintTable.Visible = false;
            // 
            // labelItem3
            // 
            this.labelItem3.Name = "labelItem3";
            this.labelItem3.Width = 40;
            // 
            // timerInfoBallon
            // 
            this.timerInfoBallon.Interval = 3000;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.rtf";
            this.openFileDialog1.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf|All Files(*.*)|*.*";
            this.openFileDialog1.FilterIndex = 2;
            this.openFileDialog1.Title = "Open File";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelEx3);
            this.panel1.Controls.Add(this.expandableSplitter1);
            this.panel1.Controls.Add(this.panelEx2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(649, 427);
            this.panel1.TabIndex = 897;
            // 
            // barTopDockSite
            // 
            this.barTopDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barTopDockSite.Dock = System.Windows.Forms.DockStyle.Top;
            this.barTopDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barTopDockSite.Location = new System.Drawing.Point(0, 0);
            this.barTopDockSite.Name = "barTopDockSite";
            this.barTopDockSite.Size = new System.Drawing.Size(649, 0);
            this.barTopDockSite.TabIndex = 889;
            this.barTopDockSite.TabStop = false;
            // 
            // barBottomDockSite
            // 
            this.barBottomDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barBottomDockSite.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barBottomDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barBottomDockSite.Location = new System.Drawing.Point(0, 427);
            this.barBottomDockSite.Name = "barBottomDockSite";
            this.barBottomDockSite.Size = new System.Drawing.Size(649, 0);
            this.barBottomDockSite.TabIndex = 890;
            this.barBottomDockSite.TabStop = false;
            // 
            // dotNetBarManager1
            // 
            this.dotNetBarManager1.BottomDockSite = this.barBottomDockSite;
            this.dotNetBarManager1.Images = this.imageList1;
            this.dotNetBarManager1.LeftDockSite = this.barLeftDockSite;
            this.dotNetBarManager1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.dotNetBarManager1.MdiSystemItemVisible = false;
            this.dotNetBarManager1.ParentForm = null;
            this.dotNetBarManager1.RightDockSite = this.barRightDockSite;
            this.dotNetBarManager1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2000;
            this.dotNetBarManager1.ToolbarBottomDockSite = this.dockSite4;
            this.dotNetBarManager1.ToolbarLeftDockSite = this.dockSite1;
            this.dotNetBarManager1.ToolbarRightDockSite = this.dockSite2;
            this.dotNetBarManager1.ToolbarTopDockSite = this.dockSite3;
            this.dotNetBarManager1.TopDockSite = this.barTopDockSite;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, string.Empty);
            this.imageList1.Images.SetKeyName(1, string.Empty);
            this.imageList1.Images.SetKeyName(2, string.Empty);
            this.imageList1.Images.SetKeyName(3, string.Empty);
            this.imageList1.Images.SetKeyName(4, string.Empty);
            this.imageList1.Images.SetKeyName(5, string.Empty);
            this.imageList1.Images.SetKeyName(6, string.Empty);
            this.imageList1.Images.SetKeyName(7, string.Empty);
            this.imageList1.Images.SetKeyName(8, string.Empty);
            this.imageList1.Images.SetKeyName(9, string.Empty);
            this.imageList1.Images.SetKeyName(10, string.Empty);
            this.imageList1.Images.SetKeyName(11, string.Empty);
            this.imageList1.Images.SetKeyName(12, string.Empty);
            this.imageList1.Images.SetKeyName(13, string.Empty);
            this.imageList1.Images.SetKeyName(14, string.Empty);
            this.imageList1.Images.SetKeyName(15, string.Empty);
            this.imageList1.Images.SetKeyName(16, string.Empty);
            this.imageList1.Images.SetKeyName(17, string.Empty);
            this.imageList1.Images.SetKeyName(18, string.Empty);
            this.imageList1.Images.SetKeyName(19, string.Empty);
            this.imageList1.Images.SetKeyName(20, string.Empty);
            this.imageList1.Images.SetKeyName(21, string.Empty);
            this.imageList1.Images.SetKeyName(22, string.Empty);
            this.imageList1.Images.SetKeyName(23, string.Empty);
            // 
            // barLeftDockSite
            // 
            this.barLeftDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barLeftDockSite.Dock = System.Windows.Forms.DockStyle.Left;
            this.barLeftDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barLeftDockSite.Location = new System.Drawing.Point(0, 0);
            this.barLeftDockSite.Name = "barLeftDockSite";
            this.barLeftDockSite.Size = new System.Drawing.Size(0, 427);
            this.barLeftDockSite.TabIndex = 891;
            this.barLeftDockSite.TabStop = false;
            // 
            // barRightDockSite
            // 
            this.barRightDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barRightDockSite.Dock = System.Windows.Forms.DockStyle.Right;
            this.barRightDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barRightDockSite.Location = new System.Drawing.Point(649, 0);
            this.barRightDockSite.Name = "barRightDockSite";
            this.barRightDockSite.Size = new System.Drawing.Size(0, 427);
            this.barRightDockSite.TabIndex = 892;
            this.barRightDockSite.TabStop = false;
            // 
            // dockSite4
            // 
            this.dockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite4.Location = new System.Drawing.Point(0, 427);
            this.dockSite4.Name = "dockSite4";
            this.dockSite4.Size = new System.Drawing.Size(649, 0);
            this.dockSite4.TabIndex = 896;
            this.dockSite4.TabStop = false;
            // 
            // dockSite1
            // 
            this.dockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite1.Location = new System.Drawing.Point(0, 0);
            this.dockSite1.Name = "dockSite1";
            this.dockSite1.Size = new System.Drawing.Size(0, 427);
            this.dockSite1.TabIndex = 893;
            this.dockSite1.TabStop = false;
            // 
            // dockSite2
            // 
            this.dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite2.Location = new System.Drawing.Point(649, 0);
            this.dockSite2.Name = "dockSite2";
            this.dockSite2.Size = new System.Drawing.Size(0, 427);
            this.dockSite2.TabIndex = 894;
            this.dockSite2.TabStop = false;
            // 
            // dockSite3
            // 
            this.dockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite3.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite3.Location = new System.Drawing.Point(0, 0);
            this.dockSite3.Name = "dockSite3";
            this.dockSite3.Size = new System.Drawing.Size(649, 0);
            this.dockSite3.TabIndex = 895;
            this.dockSite3.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // ToolStripMenuItem_Rep
            // 
            this.ToolStripMenuItem_Rep.Checked = true;
            this.ToolStripMenuItem_Rep.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToolStripMenuItem_Rep.Name = "ToolStripMenuItem_Rep";
            this.ToolStripMenuItem_Rep.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem_Rep.Text = "إظهار التقرير";
            // 
            // ToolStripMenuItem_Det
            // 
            this.ToolStripMenuItem_Det.Name = "ToolStripMenuItem_Det";
            this.ToolStripMenuItem_Det.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem_Det.Text = "إظهار التفاصيل";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Det,
            this.ToolStripMenuItem_Rep});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip2.Size = new System.Drawing.Size(149, 48);
            // 
            // FrmRoom
            // 
            this.ClientSize = new System.Drawing.Size(649, 427);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barTopDockSite);
            this.Controls.Add(this.barBottomDockSite);
            this.Controls.Add(this.barLeftDockSite);
            this.Controls.Add(this.barRightDockSite);
            this.Controls.Add(this.dockSite4);
            this.Controls.Add(this.dockSite1);
            this.Controls.Add(this.dockSite2);
            this.Controls.Add(this.dockSite3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = (InvAcc.Properties.Resources.favicon);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmRoom";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "كرت الغـــــرف";
            this.Load += new System.EventHandler(this.FrmRoom_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.panelEx2.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalaacount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKitchinCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoomCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoomPriceMonth2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoomPriceDaily2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoomFloor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoomBedCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoomTwalitCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoomPriceMonth1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoomPriceDaily1)).EndInit();
            this.ribbonBar_Tasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main2)).EndInit();
            this.panelEx3.ResumeLayout(false);
            this.ribbonBar_DGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_DGV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.Icon = (InvAcc.Properties.Resources.favicon);
            this.ResumeLayout(false);
        }
    }
}
