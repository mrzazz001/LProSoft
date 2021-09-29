using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
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
    public partial class FrmCar : Form
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
        private Dictionary<string, ColumnDictinary> Dir_ButSearch = new Dictionary<string, ColumnDictinary>();
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
        private T_Car data_this;
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
                        frm.Repvalue = "CarRep";


                        frm.Repvalue = "CarRep";
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
            if (e.Control.Name.Contains("ribbonBar_Tasks"))
            {
                ribbonBar_Tasks.Font = new Font("Tahoma", 8F);
                ribbonBar1.BackgroundStyle.BackColor = Color.Gainsboro;
                ribbonBar1.BackgroundStyle.BackColor2 = Color.Gainsboro;
            }
            if (e.Control.GetType() == typeof(Label))
            {
                Label c = (e.Control as Label); if ((c.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))))) && (c.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))))) && (c.BackColor != System.Drawing.Color.SteelBlue))
                    c.BackColor = Color.Transparent; Size cc = c.PreferredSize;
                c.AutoSize = false;
                c.Size = cc;
                //  e.Control.Font= new System.Drawing.Font("Tahoma",(float) (c-0.5));
            }
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
        private void superTabControl_Main1_RightToLeftChanged(object sender, EventArgs e)
        {
            superTabControl_Main1.RightToLeftChanged -= superTabControl_Main1_RightToLeftChanged;
            superTabControl_Main1.RightToLeft = RightToLeft.No;
            superTabControl_Main1.RightToLeftChanged -= superTabControl_Main1_RightToLeftChanged;
        }
        public Softgroup.NetResize.NetResize netResize1;
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
        protected ButtonItem Button_Delete;
        protected ButtonItem Button_Save;
        protected ButtonItem Button_Add;
        protected LabelItem labelItem2;
        private RibbonBar ribbonBar_DGV;
        private SuperTabControl superTabControl_DGV;
        protected TextBoxItem textBox_search;
        protected ButtonItem Button_ExportTable2;
        protected ButtonItem Button_PrintTable;
        protected LabelItem labelItem3;
        protected TextBox textBox_NameE;
        protected Label label40;
        protected TextBox textBox_NameA;
        protected Label label36;
        protected TextBox textBox_ID;
        protected Label label38;
        private TextBoxX textBox_Note;
        private GroupBox groupBox1;
        private Label label_PlayCardExpDat;
        private Label label_CardPlayIssDat;
        private Label label_CardPlayNo;
        private MaskedTextBox dateTimeInput_PlayCardEndDate;
        private MaskedTextBox dateTimeInput_PlayCardBeginDate;
        private TextBox textBox_PlayCardNo;
        private GroupBox groupBox2;
        private Label label_FormExpDat;
        private Label label_FormIssDat;
        private Label label_FormNo;
        private MaskedTextBox dateTimeInput_FormEndDate;
        private MaskedTextBox dateTimeInput_FormBeginDate;
        private TextBox textBox_FormNo;
        private GroupBox groupBox3;
        private Label label_AllownceName;
        private Label label_AllowncExpDat;
        private Label Label_AllowncIssDat;
        private Label label_AllownceNo;
        private MaskedTextBox dateTimeInput_AllownceBeginDate;
        private MaskedTextBox dateTimeInput_AllownceEndDate;
        private TextBox textBox_AllownceNo;
        private TextBox textBox_AllownceName;
        private MaskedTextBox textBox_PlateNo;
        private MaskedTextBox textBox_Model;
        private Label label3;
        private Label label1;
        private TextBox textBox_Color;
        private Label label4;
        private ComboBoxEx comboBox_CarTyp;
        private ButtonX button_AddCar;
        private ButtonX button_SrchCarTyp;
        protected Label label2;
        private ComboBoxEx comboBox_EmpNo;
        private ButtonX button_SrchEmp;
        private Label label12;
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
        public T_Car DataThis
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
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_FilStr, 41))
                    {
                        IfAdd = false;
                    }
                    else
                    {
                        IfAdd = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_FilStr, 42))
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_FilStr, 43))
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
                if (LangArEn == 0)
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
                if (LangArEn == 0)
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
                if (LangArEn == 0)
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
            if (LangArEn == 0)
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
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_Car";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                textBox_ID.Text = frm.SerachNo.ToString();
            }
        }
        private void TextBox_Search_ButtonCustomClick(object sender, EventArgs e)
        {
            textBox_search.Text = "";
        }
        private void textBox_Note_ButtonCustomClick(object sender, EventArgs e)
        {
            textBox_Note.Text = "";
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
            List<T_Car> list = db.FillCars_2(textBox_search.TextBox.Text).ToList();
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
        }
        public void FillHDGV(IEnumerable<T_Car> new_data_enum)
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
            DGV_Main.PrimaryGrid.DataMember = "T_Car";
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
            data_this = new T_Car();
            State = FormState.New;
            for (int i = 0; i < controls.Count; i++)
            {
                if (controls[i].GetType() == typeof(DateTimePicker))
                {
                    int? calendr = VarGeneral.Settings_Sys.Calendr;
                    if (calendr.GetValueOrDefault() == 0 && calendr.HasValue)
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
                else
                {
                    if (controls[i].Name == codeControl.Name)
                    {
                        continue;
                    }
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
                        try
                        {
                            (controls[i] as ComboBox).SelectedIndex = 0;
                        }
                        catch
                        {
                            (controls[i] as ComboBox).SelectedIndex = -1;
                        }
                    }
                    else if (controls[i].GetType() == typeof(ComboBoxEx))
                    {
                        try
                        {
                            (controls[i] as ComboBoxEx).SelectedIndex = 0;
                        }
                        catch
                        {
                            (controls[i] as ComboBoxEx).SelectedIndex = -1;
                        }
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
            var qkeys = db.T_Cars.Select((T_Car item) => new
            {
                Code = item.Car_No + ""
            });
            int count = 0;
            foreach (var item2 in qkeys)
            {
                count++;
                PKeys.Add(item2.Code);
            }
            Label_Count.Text = string.Concat(count);
            UpdateVcr();
        }
        public FrmCar()
        {
            InitializeComponent();
            controls = new List<Control>();
            controls.Add(textBox_ID);
            codeControl = textBox_ID;
            controls.Add(textBox_Color);
            controls.Add(textBox_NameA);
            controls.Add(textBox_NameE);
            controls.Add(textBox_Note);
            controls.Add(textBox_Model);
            controls.Add(textBox_PlateNo);
            controls.Add(textBox_AllownceName);
            controls.Add(textBox_AllownceNo);
            controls.Add(textBox_FormNo);
            controls.Add(textBox_PlayCardNo);
            controls.Add(dateTimeInput_AllownceBeginDate);
            controls.Add(dateTimeInput_AllownceEndDate);
            controls.Add(dateTimeInput_FormBeginDate);
            controls.Add(dateTimeInput_FormEndDate);
            controls.Add(dateTimeInput_PlayCardBeginDate);
            controls.Add(dateTimeInput_PlayCardEndDate);
            controls.Add(comboBox_CarTyp);
            controls.Add(comboBox_EmpNo);
            textBox_ID.KeyPress += textBox_ID_KeyPress;
            Button_Close.Click += Button_Close_Click;
            textBox_Color.Click += Button_Edit_Click;
            textBox_NameA.Click += Button_Edit_Click;
            textBox_NameE.Click += Button_Edit_Click;
            textBox_Note.Click += Button_Edit_Click;
            textBox_Model.Click += Button_Edit_Click;
            textBox_PlateNo.Click += Button_Edit_Click;
            textBox_AllownceName.Click += Button_Edit_Click;
            textBox_AllownceNo.Click += Button_Edit_Click;
            textBox_FormNo.Click += Button_Edit_Click;
            textBox_PlayCardNo.Click += Button_Edit_Click;
            comboBox_CarTyp.Click += Button_Edit_Click;
            comboBox_EmpNo.Click += Button_Edit_Click;
            dateTimeInput_AllownceBeginDate.Click += Button_Edit_Click;
            dateTimeInput_AllownceEndDate.Click += Button_Edit_Click;
            dateTimeInput_FormBeginDate.Click += Button_Edit_Click;
            dateTimeInput_FormEndDate.Click += Button_Edit_Click;
            dateTimeInput_PlayCardBeginDate.Click += Button_Edit_Click;
            dateTimeInput_PlayCardEndDate.Click += Button_Edit_Click;
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
            textBox_search.InputTextChanged += TextBox_Search_InputTextChanged;
            textBox_search.ButtonCustomClick += TextBox_Search_ButtonCustomClick;
            textBox_Note.ButtonCustomClick += textBox_Note_ButtonCustomClick;
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmCar));
            if (base.Tag.ToString() == "0")
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
            if (LangArEn == 0)
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
                label38.Text = "الكود :";
                label36.Text = "الإسم - عربي :";
                label40.Text = "الإسم - إنجليزي :";
                textBox_Note.WatermarkText = "ملاحظـــــــات السيارة";
                Text = "كرت السيارات";
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
                label38.Text = "Code :";
                label36.Text = "Name - Arabic :";
                label40.Text = "Name - English :";
                textBox_Note.WatermarkText = "Notes";
                Text = "Cars Card";
            }
        }
        private void FrmDept_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmCar));
                if (base.Tag.ToString() == "0")
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
                    columns_Names_visible.Add("Car_No", new ColumnDictinary("رقم السيارة", "Car No", ifDefault: true, ""));
                    columns_Names_visible.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
                    columns_Names_visible.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
                    columns_Names_visible.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: false, ""));
                }
                else
                {
                    Clear();
                    textBox_ID.Text = "";
                    TextBox_Index.TextBox.Text = "";
                }
                RibunButtons();
                FillCombo();
                RefreshPKeys();
                textBox_ID.Text = PKeys.FirstOrDefault();
                ViewDetails_Click(sender, e);
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
                T_Car newData = db.CarsEmp(no);
                if (newData == null || newData.Car_No == 0 || string.IsNullOrEmpty(newData.Car_ID))
                {
                    if (!Button_Add.Visible || !Button_Add.Enabled)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textBox_ID.TextChanged -= textBox_ID_TextChanged;
                        try
                        {
                            textBox_ID.Text = data_this.Car_No.ToString();
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
                    int indexA = PKeys.IndexOf(string.Concat(newData.Car_No));
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
        public void SetData(T_Car value)
        {
            try
            {
                State = FormState.Saved;
                Button_Save.Enabled = false;
                if (!string.IsNullOrEmpty(value.EmpID))
                {
                    comboBox_EmpNo.SelectedValue = value.EmpID;
                }
                else
                {
                    comboBox_EmpNo.SelectedIndex = 0;
                }
                textBox_Model.Text = value.Model;
                textBox_NameA.Text = value.NameA;
                textBox_NameE.Text = value.NameE;
                textBox_Note.Text = value.Note;
                textBox_PlateNo.Text = value.PlateNo;
                textBox_Color.Text = value.Color;
                textBox_AllownceName.Text = value.AllownceName;
                textBox_AllownceNo.Text = value.AllownceNo;
                textBox_FormNo.Text = value.FormNo;
                textBox_PlayCardNo.Text = value.PlayCardNo;
                try
                {
                    if (VarGeneral.CheckDate(value.AllownceBeginDate))
                    {
                        dateTimeInput_AllownceBeginDate.Text = Convert.ToDateTime(value.AllownceBeginDate).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        dateTimeInput_AllownceBeginDate.Text = "";
                    }
                }
                catch
                {
                    dateTimeInput_AllownceBeginDate.Text = "";
                }
                try
                {
                    if (VarGeneral.CheckDate(value.AllownceEndDate))
                    {
                        dateTimeInput_AllownceEndDate.Text = Convert.ToDateTime(value.AllownceEndDate).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        dateTimeInput_AllownceEndDate.Text = "";
                    }
                }
                catch
                {
                    dateTimeInput_AllownceEndDate.Text = "";
                }
                try
                {
                    if (VarGeneral.CheckDate(value.FormBeginDate))
                    {
                        dateTimeInput_FormBeginDate.Text = Convert.ToDateTime(value.FormBeginDate).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        dateTimeInput_FormBeginDate.Text = "";
                    }
                }
                catch
                {
                    dateTimeInput_FormBeginDate.Text = "";
                }
                try
                {
                    if (VarGeneral.CheckDate(value.FormEndDate))
                    {
                        dateTimeInput_FormEndDate.Text = Convert.ToDateTime(value.FormEndDate).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        dateTimeInput_FormEndDate.Text = "";
                    }
                }
                catch
                {
                    dateTimeInput_FormEndDate.Text = "";
                }
                try
                {
                    if (VarGeneral.CheckDate(value.PlayCardBeginDate))
                    {
                        dateTimeInput_PlayCardBeginDate.Text = Convert.ToDateTime(value.PlayCardBeginDate).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        dateTimeInput_PlayCardBeginDate.Text = "";
                    }
                }
                catch
                {
                    dateTimeInput_PlayCardBeginDate.Text = "";
                }
                try
                {
                    if (VarGeneral.CheckDate(value.PlayCardEndDate))
                    {
                        dateTimeInput_PlayCardEndDate.Text = Convert.ToDateTime(value.PlayCardEndDate).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        dateTimeInput_PlayCardEndDate.Text = "";
                    }
                }
                catch
                {
                    dateTimeInput_PlayCardEndDate.Text = "";
                }
                if (value.CarType.HasValue)
                {
                    comboBox_CarTyp.SelectedValue = value.CarType.Value;
                }
                textBox_ID.Tag = value.Car_ID;
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
        private T_Car GetData()
        {
            textBox_ID.Focus();
            try
            {
                data_this.Car_No = int.Parse(textBox_ID.Text);
            }
            catch
            {
            }
            try
            {
                if (comboBox_EmpNo.SelectedIndex > 0)
                {
                    data_this.EmpID = comboBox_EmpNo.SelectedValue.ToString();
                }
                else
                {
                    data_this.EmpID = null;
                }
            }
            catch
            {
                data_this.EmpID = null;
            }
            try
            {
                data_this.Model = textBox_Model.Text;
            }
            catch
            {
            }
            try
            {
                data_this.NameA = textBox_NameA.Text;
            }
            catch
            {
            }
            try
            {
                data_this.NameE = textBox_NameE.Text;
            }
            catch
            {
            }
            try
            {
                data_this.PlateNo = textBox_PlateNo.Text;
            }
            catch
            {
            }
            try
            {
                data_this.Note = textBox_Note.Text;
            }
            catch
            {
            }
            try
            {
                data_this.Color = textBox_Color.Text;
            }
            catch
            {
            }
            try
            {
                data_this.AllownceName = textBox_AllownceName.Text;
            }
            catch
            {
            }
            try
            {
                data_this.AllownceNo = textBox_AllownceNo.Text;
            }
            catch
            {
            }
            try
            {
                data_this.FormNo = textBox_FormNo.Text;
            }
            catch
            {
            }
            try
            {
                data_this.PlayCardNo = textBox_PlayCardNo.Text;
            }
            catch
            {
            }
            try
            {
                data_this.AllownceBeginDate = Convert.ToDateTime(dateTimeInput_AllownceBeginDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_AllownceBeginDate.Text = "";
                data_this.AllownceBeginDate = "";
            }
            try
            {
                data_this.AllownceEndDate = Convert.ToDateTime(dateTimeInput_AllownceEndDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_AllownceEndDate.Text = "";
                data_this.AllownceEndDate = "";
            }
            try
            {
                data_this.FormBeginDate = Convert.ToDateTime(dateTimeInput_FormBeginDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_FormBeginDate.Text = "";
                data_this.FormBeginDate = "";
            }
            try
            {
                data_this.FormEndDate = Convert.ToDateTime(dateTimeInput_FormEndDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_FormEndDate.Text = "";
                data_this.FormEndDate = "";
            }
            try
            {
                data_this.PlayCardBeginDate = Convert.ToDateTime(dateTimeInput_PlayCardBeginDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PlayCardBeginDate.Text = "";
                data_this.PlayCardBeginDate = "";
            }
            try
            {
                data_this.PlayCardEndDate = Convert.ToDateTime(dateTimeInput_PlayCardEndDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_PlayCardEndDate.Text = "";
                data_this.PlayCardEndDate = "";
            }
            try
            {
                data_this.CarType = int.Parse(comboBox_CarTyp.SelectedValue.ToString());
            }
            catch
            {
                data_this.CarType = null;
            }
            try
            {
                data_this.CompanyID = 1;
            }
            catch
            {
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
                int max = 0;
                max = db.MaxCarsNo;
                Clear();
                textBox_ID.Text = max.ToString();
                Guid id = Guid.NewGuid();
                textBox_ID.Tag = id.ToString();
                State = FormState.New;
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
                if (State == FormState.New && !Button_Add.Enabled)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                textBox_ID.Focus();
                if (textBox_ID.Text == "" || textBox_NameA.Text == "" || textBox_NameE.Text == "")
                {
                    MessageBox.Show((LangArEn == 0) ? "لايمكن ان يكون الرمز او الإسم فارغا\u0651" : "Can not be a number or name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (comboBox_CarTyp.SelectedIndex == -1)
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب تحديد ماركة السيارة" : "Must Select Car Type", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (State == FormState.New)
                {
                    GetData();
                    try
                    {
                        data_this.Car_ID = textBox_ID.Tag.ToString();
                        db.T_Cars.InsertOnSubmit(data_this);
                        db.SubmitChanges();
                    }
                    catch (SqlException ex3)
                    {
                        int max = 0;
                        max = db.MaxCarsNo;
                        if (ex3.Number != 2627)
                        {
                            return;
                        }
                        MessageBox.Show("رقم السيارة مستخدم من قبل.\n سيتم الحفظ برقم جديد [" + max + "]", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question);
                        textBox_ID.Text = string.Concat(max);
                        data_this.Car_No = max;
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
                State = FormState.Saved;
                RefreshPKeys();
                TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(string.Concat(data_this.Car_No)) + 1);
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
            try
            {
                if (data_this.Car_ID == "1")
                {
                    ifOkDelete = false;
                    return;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
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
            if (data_this == null || data_this.Car_No == 0 || string.IsNullOrEmpty(data_this.Car_ID) || !ifOkDelete)
            {
                return;
            }
            T_Emp returned = db.SelectDeptNoByReturnNo(DataThis.Car_No);
            int num;
            if (returned != null)
            {
                int? dept = returned.Dept;
                num = ((dept.GetValueOrDefault() == 0 && dept.HasValue) ? 1 : 0);
            }
            else
            {
                num = 1;
            }
            if (num == 0)
            {
                MessageBox.Show((LangArEn == 0) ? "لايمكن حذف السيارة .. لانه مرتبط باحد الموظفين" : "can not be deleted This car .. because it is linked to one of the employee", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            data_this = db.CarsEmp(DataThis.Car_No);
            try
            {
                db.T_Cars.DeleteOnSubmit(DataThis);
                db.SubmitChanges();
            }
            catch (SqlException)
            {
                data_this = db.CarsEmp(DataThis.Car_No);
                return;
            }
            catch (Exception)
            {
                data_this = db.CarsEmp(DataThis.Car_No);
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
            if (dataMember != null && dataMember == "T_Car")
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
            panel.Columns["NameA"].Width = 250;
            panel.Columns["NameA"].Visible = columns_Names_visible["NameA"].IfDefault;
            panel.Columns["NameE"].Width = 250;
            panel.Columns["NameE"].Visible = columns_Names_visible["NameE"].IfDefault;
            panel.Columns["Car_No"].Width = 120;
            panel.Columns["Car_No"].Visible = columns_Names_visible["Car_No"].IfDefault;
            panel.Columns["Note"].Width = 350;
            panel.Columns["Note"].Visible = columns_Names_visible["Note"].IfDefault;
            panel.ReadOnly = true;
        }
        private void DGV_MainGetCellStyle(object sender, GridGetCellStyleEventArgs e)
        {
        }
        private void Button_ExportTable2_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcel.ExportToExcel(DGV_Main, "تقرير السيارات");
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
            if (ViewState == ViewState.Table)
            {
                VarGeneral.IsGeneralUsed = true;
                FrmReportsViewer frm = new FrmReportsViewer();
                frm.Repvalue = "CarRep";



                frm.Tag = LangArEn;
                frm.Repvalue = "CarRep";
                VarGeneral.vTitle = Text;
                frm.SqlWhere = "";
                frm.TopMost = true;
                frm.ShowDialog();
                VarGeneral.IsGeneralUsed = false;

            }
        }
        public void textBox_NameA_Leave(object sender, EventArgs e)
        {
            SSSLanguage.Language.Switch("AR");
        }
        public void textBox_NameE_Leave(object sender, EventArgs e)
        {
            SSSLanguage.Language.Switch("AR");
        }
        private void textBox_Note_Click(object sender, EventArgs e)
        {
            textBox_Note.SelectAll();
        }
        private void dateTimeInput_FormBeginDate_Click(object sender, EventArgs e)
        {
            dateTimeInput_FormBeginDate.SelectAll();
        }
        private void dateTimeInput_FormEndDate_Click(object sender, EventArgs e)
        {
            dateTimeInput_FormEndDate.SelectAll();
        }
        private void dateTimeInput_AllownceBeginDate_Click(object sender, EventArgs e)
        {
            dateTimeInput_AllownceBeginDate.SelectAll();
        }
        private void dateTimeInput_AllownceEndDate_Click(object sender, EventArgs e)
        {
            dateTimeInput_AllownceEndDate.SelectAll();
        }
        private void dateTimeInput_PlayCardBeginDate_Click(object sender, EventArgs e)
        {
            dateTimeInput_PlayCardBeginDate.SelectAll();
        }
        private void dateTimeInput_PlayCardEndDate_Click(object sender, EventArgs e)
        {
            dateTimeInput_PlayCardEndDate.SelectAll();
        }
        private void textBox_FormNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void dateTimeInput_FormBeginDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(dateTimeInput_FormBeginDate.Text))
                {
                    dateTimeInput_FormBeginDate.Text = Convert.ToDateTime(dateTimeInput_FormBeginDate.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_FormBeginDate.Text = "";
                }
            }
            catch
            {
                dateTimeInput_FormBeginDate.Text = "";
            }
        }
        private void dateTimeInput_FormEndDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(dateTimeInput_FormEndDate.Text))
                {
                    dateTimeInput_FormEndDate.Text = Convert.ToDateTime(dateTimeInput_FormEndDate.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_FormEndDate.Text = "";
                }
            }
            catch
            {
                dateTimeInput_FormEndDate.Text = "";
            }
        }
        private void dateTimeInput_AllownceBeginDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(dateTimeInput_AllownceBeginDate.Text))
                {
                    dateTimeInput_AllownceBeginDate.Text = Convert.ToDateTime(dateTimeInput_AllownceBeginDate.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_AllownceBeginDate.Text = "";
                }
            }
            catch
            {
                dateTimeInput_AllownceBeginDate.Text = "";
            }
        }
        private void dateTimeInput_AllownceEndDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(dateTimeInput_AllownceEndDate.Text))
                {
                    dateTimeInput_AllownceEndDate.Text = Convert.ToDateTime(dateTimeInput_AllownceEndDate.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_AllownceEndDate.Text = "";
                }
            }
            catch
            {
                dateTimeInput_AllownceEndDate.Text = "";
            }
        }
        private void dateTimeInput_PlayCardBeginDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(dateTimeInput_PlayCardBeginDate.Text))
                {
                    dateTimeInput_PlayCardBeginDate.Text = Convert.ToDateTime(dateTimeInput_PlayCardBeginDate.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_PlayCardBeginDate.Text = "";
                }
            }
            catch
            {
                dateTimeInput_PlayCardBeginDate.Text = "";
            }
        }
        private void dateTimeInput_PlayCardEndDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(dateTimeInput_PlayCardEndDate.Text))
                {
                    dateTimeInput_PlayCardEndDate.Text = Convert.ToDateTime(dateTimeInput_PlayCardEndDate.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_PlayCardEndDate.Text = "";
                }
            }
            catch
            {
                dateTimeInput_PlayCardEndDate.Text = "";
            }
        }
        public bool IsFormOpen(Form formType)
        {
            try
            {
                foreach (Form form in Application.OpenForms)
                {
                    if (formType.Name == form.Name)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        private void button_AddCar_Click(object sender, EventArgs e)
        {
            if (IsFormOpen(new FrmCarTyp()))
            {
                return;
            }
            FrmCarTyp frm = new FrmCarTyp();
            frm.Tag = LangArEn;
            string vList = "";
            if (comboBox_CarTyp.SelectedIndex != -1)
            {
                vList = comboBox_CarTyp.SelectedValue.ToString();
            }
            frm.TopMost = true;
            frm.ShowDialog();
            using (new Stock_DataDataContext(VarGeneral.BranchCS))
            {
                List<T_CarTyp> listJob = new List<T_CarTyp>(db.T_CarTyps.Select((T_CarTyp item) => item).ToList());
                comboBox_CarTyp.DataSource = null;
                comboBox_CarTyp.DataSource = listJob;
                comboBox_CarTyp.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
                comboBox_CarTyp.ValueMember = "CarTyp_No";
                if (vList != "")
                {
                    for (int i = 0; i < comboBox_CarTyp.Items.Count; i++)
                    {
                        comboBox_CarTyp.SelectedIndex = i;
                        if (comboBox_CarTyp.SelectedValue.ToString() == vList)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    comboBox_CarTyp.SelectedIndex = -1;
                }
            }
        }
        private void button_SrchCarTyp_Click(object sender, ClickEventArgs e)
        {
            try
            {
                Dir_ButSearch.Add("CarTyp_No", new ColumnDictinary("الرقم", "No", ifDefault: true, ""));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, ""));
                Dir_ButSearch.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, ""));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                }
                VarGeneral.SFrmTyp = "T_CarTyp";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    comboBox_CarTyp.SelectedValue = int.Parse(frm.SerachNo);
                    Button_Edit_Click(sender, e);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void textBox_Model_Click(object sender, EventArgs e)
        {
            textBox_Model.SelectAll();
        }
        private void textBox_FormNo_Click(object sender, EventArgs e)
        {
            textBox_FormNo.SelectAll();
        }
        private void textBox_AllownceNo_Click(object sender, EventArgs e)
        {
            textBox_AllownceNo.SelectAll();
        }
        private void textBox_PlayCardNo_Click(object sender, EventArgs e)
        {
            textBox_PlayCardNo.SelectAll();
        }
        private void textBox_PlateNo_Click(object sender, EventArgs e)
        {
            textBox_PlateNo.SelectAll();
        }
        private void FillCombo()
        {
            List<T_CarTyp> listJob = new List<T_CarTyp>(db.T_CarTyps.Select((T_CarTyp item) => item).ToList());
            comboBox_CarTyp.DataSource = null;
            comboBox_CarTyp.DataSource = listJob;
            comboBox_CarTyp.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_CarTyp.ValueMember = "CarTyp_No";
            comboBox_CarTyp.SelectedIndex = -1;
            List<T_Emp> listEmps = new List<T_Emp>(db.T_Emps.Where((T_Emp item) => item.EmpState == (bool?)true).ToList());
            listEmps.Insert(0, new T_Emp());
            comboBox_EmpNo.DataSource = listEmps;
            comboBox_EmpNo.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_EmpNo.ValueMember = "Emp_ID";
            comboBox_EmpNo.SelectedIndex = 0;
        }
        private void button_SrchCarTyp_Click(object sender, EventArgs e)
        {
            try
            {
                Dir_ButSearch.Add("CarTyp_No", new ColumnDictinary("رقم النوع", "Type No", ifDefault: true, ""));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, ""));
                Dir_ButSearch.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, ""));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                }
                VarGeneral.SFrmTyp = "T_CarTyp";
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    comboBox_CarTyp.SelectedValue = int.Parse(frm.SerachNo);
                    Button_Edit_Click(sender, e);
                }
                Dir_ButSearch.Clear();
            }
            catch
            {
            }
        }
        private void textBox_AllownceName_Click(object sender, EventArgs e)
        {
            textBox_AllownceName.SelectAll();
        }
        private void button_SrchEmp_Click(object sender, EventArgs e)
        {
            if (!comboBox_EmpNo.Enabled)
            {
                return;
            }
            try
            {
                Dir_ButSearch.Add("Emp_No", new ColumnDictinary("رقم الموظف", "Employee No", ifDefault: true, ""));
                Dir_ButSearch.Add("NameA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
                Dir_ButSearch.Add("NameE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, ""));
                Dir_ButSearch.Add("DateAppointment", new ColumnDictinary("تاريخ التعيين", "Appointment Date", ifDefault: false, ""));
                Dir_ButSearch.Add("StartContr", new ColumnDictinary("بداية العقد", "Start Contract Date", ifDefault: false, ""));
                Dir_ButSearch.Add("EndContr", new ColumnDictinary("نهاية العقد", "End Contract Date", ifDefault: false, ""));
                Dir_ButSearch.Add("MainSal", new ColumnDictinary("الراتب الأساسي", "Main Salary", ifDefault: false, ""));
                Dir_ButSearch.Add("ID_No", new ColumnDictinary("رقم الهوية", "ID No", ifDefault: false, ""));
                Dir_ButSearch.Add("Passport_No", new ColumnDictinary("رقم الجواز", "Passport No", ifDefault: false, ""));
                Dir_ButSearch.Add("AddressA", new ColumnDictinary("العنوان", "Address", ifDefault: false, ""));
                Dir_ButSearch.Add("Tel", new ColumnDictinary("الهاتف", "Tel", ifDefault: false, ""));
                Dir_ButSearch.Add("Note", new ColumnDictinary(" الملاحظــات", "Note", ifDefault: false, ""));
                FrmSearch frm = new FrmSearch();
                frm.Tag = LangArEn;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = Dir_ButSearch;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                }
                VarGeneral.SFrmTyp = "T_Emp";
                VarGeneral.FrmEmpStat = true;
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    frm.Serach_No = db.EmpsEmpNo(frm.Serach_No).Emp_ID;
                    comboBox_EmpNo.SelectedValue = frm.SerachNo;
                }
                Dir_ButSearch.Clear();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_SrchEmp_Click:", error, enable: true);
                MessageBox.Show(error.Message);
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
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background3 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor1 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor2 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle1 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle2 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.Background background4 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCar));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.comboBox_EmpNo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.button_SrchEmp = new DevComponents.DotNetBar.ButtonX();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_CarTyp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.button_AddCar = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchCarTyp = new DevComponents.DotNetBar.ButtonX();
            this.textBox_PlateNo = new System.Windows.Forms.MaskedTextBox();
            this.textBox_Model = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Color = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_PlayCardExpDat = new System.Windows.Forms.Label();
            this.label_CardPlayIssDat = new System.Windows.Forms.Label();
            this.label_CardPlayNo = new System.Windows.Forms.Label();
            this.dateTimeInput_PlayCardEndDate = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_PlayCardBeginDate = new System.Windows.Forms.MaskedTextBox();
            this.textBox_PlayCardNo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_FormNo = new System.Windows.Forms.TextBox();
            this.label_FormExpDat = new System.Windows.Forms.Label();
            this.dateTimeInput_FormEndDate = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_FormBeginDate = new System.Windows.Forms.MaskedTextBox();
            this.label_FormIssDat = new System.Windows.Forms.Label();
            this.label_FormNo = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label_AllownceName = new System.Windows.Forms.Label();
            this.label_AllowncExpDat = new System.Windows.Forms.Label();
            this.Label_AllowncIssDat = new System.Windows.Forms.Label();
            this.label_AllownceNo = new System.Windows.Forms.Label();
            this.dateTimeInput_AllownceBeginDate = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_AllownceEndDate = new System.Windows.Forms.MaskedTextBox();
            this.textBox_AllownceNo = new System.Windows.Forms.TextBox();
            this.textBox_AllownceName = new System.Windows.Forms.TextBox();
            this.textBox_Note = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBox_NameE = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.textBox_NameA = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.ribbonBar_Tasks = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl_Main1 = new DevComponents.DotNetBar.SuperTabControl();
            this.Button_Close = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Search = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Delete = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Save = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Add = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            this.superTabControl_Main2 = new DevComponents.DotNetBar.SuperTabControl();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.Button_First = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Prev = new DevComponents.DotNetBar.ButtonItem();
            this.TextBox_Index = new DevComponents.DotNetBar.TextBoxItem();
            this.Label_Count = new DevComponents.DotNetBar.LabelItem();
            this.lable_Records = new DevComponents.DotNetBar.LabelItem();
            this.Button_Next = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Last = new DevComponents.DotNetBar.ButtonItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
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
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.PanelSpecialContainer.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.ribbonBar_Tasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main2)).BeginInit();
            this.panelEx3.SuspendLayout();
            this.ribbonBar_DGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_DGV)).BeginInit();
            this.panel1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelSpecialContainer
            // 
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar1);
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar_Tasks);
            this.PanelSpecialContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSpecialContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelSpecialContainer.Name = "PanelSpecialContainer";
            this.PanelSpecialContainer.Size = new System.Drawing.Size(649, 445);
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
            this.ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.comboBox_EmpNo);
            this.ribbonBar1.Controls.Add(this.button_SrchEmp);
            this.ribbonBar1.Controls.Add(this.label12);
            this.ribbonBar1.Controls.Add(this.label2);
            this.ribbonBar1.Controls.Add(this.comboBox_CarTyp);
            this.ribbonBar1.Controls.Add(this.button_AddCar);
            this.ribbonBar1.Controls.Add(this.button_SrchCarTyp);
            this.ribbonBar1.Controls.Add(this.textBox_PlateNo);
            this.ribbonBar1.Controls.Add(this.textBox_Model);
            this.ribbonBar1.Controls.Add(this.label3);
            this.ribbonBar1.Controls.Add(this.label1);
            this.ribbonBar1.Controls.Add(this.textBox_Color);
            this.ribbonBar1.Controls.Add(this.label4);
            this.ribbonBar1.Controls.Add(this.groupBox1);
            this.ribbonBar1.Controls.Add(this.groupBox2);
            this.ribbonBar1.Controls.Add(this.groupBox3);
            this.ribbonBar1.Controls.Add(this.textBox_Note);
            this.ribbonBar1.Controls.Add(this.textBox_NameE);
            this.ribbonBar1.Controls.Add(this.label40);
            this.ribbonBar1.Controls.Add(this.textBox_NameA);
            this.ribbonBar1.Controls.Add(this.label36);
            this.ribbonBar1.Controls.Add(this.textBox_ID);
            this.ribbonBar1.Controls.Add(this.label38);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(649, 394);
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
            // comboBox_EmpNo
            // 
            this.comboBox_EmpNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_EmpNo.DisplayMember = "Text";
            this.comboBox_EmpNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_EmpNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_EmpNo.FormattingEnabled = true;
            this.comboBox_EmpNo.ItemHeight = 14;
            this.comboBox_EmpNo.Location = new System.Drawing.Point(95, 47);
            this.comboBox_EmpNo.Name = "comboBox_EmpNo";
            this.comboBox_EmpNo.Size = new System.Drawing.Size(368, 20);
            this.comboBox_EmpNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_EmpNo.TabIndex = 3;
            // 
            // button_SrchEmp
            // 
            this.button_SrchEmp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchEmp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchEmp.Location = new System.Drawing.Point(68, 46);
            this.button_SrchEmp.Name = "button_SrchEmp";
            this.button_SrchEmp.Size = new System.Drawing.Size(26, 20);
            this.button_SrchEmp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchEmp.Symbol = "";
            this.button_SrchEmp.SymbolSize = 12F;
            this.button_SrchEmp.TabIndex = 6698;
            this.button_SrchEmp.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchEmp.Click += new System.EventHandler(this.button_SrchEmp_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(468, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 13);
            this.label12.TabIndex = 6700;
            this.label12.Text = "إسم الموظف :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(261, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 6696;
            this.label2.Text = "ماركة السيارة :";
            // 
            // comboBox_CarTyp
            // 
            this.comboBox_CarTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_CarTyp.DisplayMember = "Text";
            this.comboBox_CarTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_CarTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CarTyp.FormattingEnabled = true;
            this.comboBox_CarTyp.ItemHeight = 14;
            this.comboBox_CarTyp.Location = new System.Drawing.Point(122, 16);
            this.comboBox_CarTyp.Name = "comboBox_CarTyp";
            this.comboBox_CarTyp.Size = new System.Drawing.Size(137, 20);
            this.comboBox_CarTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_CarTyp.TabIndex = 2;
            // 
            // button_AddCar
            // 
            this.button_AddCar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_AddCar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_AddCar.Location = new System.Drawing.Point(68, 16);
            this.button_AddCar.Name = "button_AddCar";
            this.button_AddCar.Size = new System.Drawing.Size(26, 20);
            this.button_AddCar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_AddCar.Symbol = "";
            this.button_AddCar.SymbolSize = 11F;
            this.button_AddCar.TabIndex = 6695;
            this.button_AddCar.TextColor = System.Drawing.Color.SteelBlue;
            this.button_AddCar.Click += new System.EventHandler(this.button_AddCar_Click);
            // 
            // button_SrchCarTyp
            // 
            this.button_SrchCarTyp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchCarTyp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCarTyp.Location = new System.Drawing.Point(95, 16);
            this.button_SrchCarTyp.Name = "button_SrchCarTyp";
            this.button_SrchCarTyp.Size = new System.Drawing.Size(26, 20);
            this.button_SrchCarTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCarTyp.Symbol = "";
            this.button_SrchCarTyp.SymbolSize = 12F;
            this.button_SrchCarTyp.TabIndex = 6694;
            this.button_SrchCarTyp.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCarTyp.Click += new System.EventHandler(this.button_SrchCarTyp_Click);
            // 
            // textBox_PlateNo
            // 
            this.textBox_PlateNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_PlateNo.Location = new System.Drawing.Point(68, 145);
            this.textBox_PlateNo.Mask = "0000 ? ? ?";
            this.textBox_PlateNo.Name = "textBox_PlateNo";
            this.textBox_PlateNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_PlateNo.Size = new System.Drawing.Size(85, 20);
            this.textBox_PlateNo.TabIndex = 8;
            this.textBox_PlateNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_PlateNo.Click += new System.EventHandler(this.textBox_PlateNo_Click);
            // 
            // textBox_Model
            // 
            this.textBox_Model.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Model.Location = new System.Drawing.Point(378, 145);
            this.textBox_Model.Mask = "0000";
            this.textBox_Model.Name = "textBox_Model";
            this.textBox_Model.Size = new System.Drawing.Size(85, 20);
            this.textBox_Model.TabIndex = 6;
            this.textBox_Model.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Model.Click += new System.EventHandler(this.textBox_Model_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(470, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 6691;
            this.label3.Text = "سنة الصنـــع :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(153, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 6690;
            this.label1.Text = "اللوحـــــــة :";
            // 
            // textBox_Color
            // 
            this.textBox_Color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Color.Location = new System.Drawing.Point(228, 145);
            this.textBox_Color.MaxLength = 20;
            this.textBox_Color.Name = "textBox_Color";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Color, false);
            this.textBox_Color.Size = new System.Drawing.Size(97, 20);
            this.textBox_Color.TabIndex = 7;
            this.textBox_Color.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Color.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(330, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 6689;
            this.label4.Text = "اللون";
            this.label4.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_PlayCardExpDat);
            this.groupBox1.Controls.Add(this.label_CardPlayIssDat);
            this.groupBox1.Controls.Add(this.label_CardPlayNo);
            this.groupBox1.Controls.Add(this.dateTimeInput_PlayCardEndDate);
            this.groupBox1.Controls.Add(this.dateTimeInput_PlayCardBeginDate);
            this.groupBox1.Controls.Add(this.textBox_PlayCardNo);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(60, 439);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(539, 55);
            this.groupBox1.TabIndex = 6686;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "بيانات كرت التشغيل";
            this.groupBox1.Visible = false;
            // 
            // label_PlayCardExpDat
            // 
            this.label_PlayCardExpDat.AutoSize = true;
            this.label_PlayCardExpDat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_PlayCardExpDat.Location = new System.Drawing.Point(490, 27);
            this.label_PlayCardExpDat.Name = "label_PlayCardExpDat";
            this.label_PlayCardExpDat.Size = new System.Drawing.Size(35, 13);
            this.label_PlayCardExpDat.TabIndex = 12;
            this.label_PlayCardExpDat.Text = "الرقم";
            // 
            // label_CardPlayIssDat
            // 
            this.label_CardPlayIssDat.AutoSize = true;
            this.label_CardPlayIssDat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_CardPlayIssDat.Location = new System.Drawing.Point(301, 27);
            this.label_CardPlayIssDat.Name = "label_CardPlayIssDat";
            this.label_CardPlayIssDat.Size = new System.Drawing.Size(73, 13);
            this.label_CardPlayIssDat.TabIndex = 10;
            this.label_CardPlayIssDat.Text = "تاريخ الاصدار";
            // 
            // label_CardPlayNo
            // 
            this.label_CardPlayNo.AutoSize = true;
            this.label_CardPlayNo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_CardPlayNo.Location = new System.Drawing.Point(116, 28);
            this.label_CardPlayNo.Name = "label_CardPlayNo";
            this.label_CardPlayNo.Size = new System.Drawing.Size(71, 13);
            this.label_CardPlayNo.TabIndex = 8;
            this.label_CardPlayNo.Text = "تاريخ الانتهاء";
            // 
            // dateTimeInput_PlayCardEndDate
            // 
            this.dateTimeInput_PlayCardEndDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dateTimeInput_PlayCardEndDate.Location = new System.Drawing.Point(8, 23);
            this.dateTimeInput_PlayCardEndDate.Mask = "0000/00/00";
            this.dateTimeInput_PlayCardEndDate.Name = "dateTimeInput_PlayCardEndDate";
            this.dateTimeInput_PlayCardEndDate.Size = new System.Drawing.Size(105, 20);
            this.dateTimeInput_PlayCardEndDate.TabIndex = 17;
            this.dateTimeInput_PlayCardEndDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dateTimeInput_PlayCardBeginDate
            // 
            this.dateTimeInput_PlayCardBeginDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dateTimeInput_PlayCardBeginDate.Location = new System.Drawing.Point(192, 23);
            this.dateTimeInput_PlayCardBeginDate.Mask = "0000/00/00";
            this.dateTimeInput_PlayCardBeginDate.Name = "dateTimeInput_PlayCardBeginDate";
            this.dateTimeInput_PlayCardBeginDate.Size = new System.Drawing.Size(105, 20);
            this.dateTimeInput_PlayCardBeginDate.TabIndex = 16;
            this.dateTimeInput_PlayCardBeginDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_PlayCardNo
            // 
            this.textBox_PlayCardNo.BackColor = System.Drawing.Color.White;
            this.textBox_PlayCardNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_PlayCardNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_PlayCardNo.ForeColor = System.Drawing.Color.Black;
            this.textBox_PlayCardNo.Location = new System.Drawing.Point(378, 23);
            this.textBox_PlayCardNo.MaxLength = 20;
            this.textBox_PlayCardNo.Name = "textBox_PlayCardNo";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_PlayCardNo, false);
            this.textBox_PlayCardNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_PlayCardNo.Size = new System.Drawing.Size(106, 20);
            this.textBox_PlayCardNo.TabIndex = 15;
            this.textBox_PlayCardNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_FormNo);
            this.groupBox2.Controls.Add(this.label_FormExpDat);
            this.groupBox2.Controls.Add(this.dateTimeInput_FormEndDate);
            this.groupBox2.Controls.Add(this.dateTimeInput_FormBeginDate);
            this.groupBox2.Controls.Add(this.label_FormIssDat);
            this.groupBox2.Controls.Add(this.label_FormNo);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.groupBox2.Location = new System.Drawing.Point(60, 223);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(539, 55);
            this.groupBox2.TabIndex = 6684;
            this.groupBox2.TabStop = false;
            // 
            // textBox_FormNo
            // 
            this.textBox_FormNo.BackColor = System.Drawing.Color.White;
            this.textBox_FormNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_FormNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_FormNo.ForeColor = System.Drawing.Color.Black;
            this.textBox_FormNo.Location = new System.Drawing.Point(333, 24);
            this.textBox_FormNo.MaxLength = 20;
            this.textBox_FormNo.Name = "textBox_FormNo";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_FormNo, false);
            this.textBox_FormNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_FormNo.Size = new System.Drawing.Size(114, 20);
            this.textBox_FormNo.TabIndex = 10;
            this.textBox_FormNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_FormNo.Click += new System.EventHandler(this.textBox_FormNo_Click);
            this.textBox_FormNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_FormNo_KeyPress);
            // 
            // label_FormExpDat
            // 
            this.label_FormExpDat.AutoSize = true;
            this.label_FormExpDat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_FormExpDat.Location = new System.Drawing.Point(448, 26);
            this.label_FormExpDat.Name = "label_FormExpDat";
            this.label_FormExpDat.Size = new System.Drawing.Size(78, 13);
            this.label_FormExpDat.TabIndex = 12;
            this.label_FormExpDat.Text = "رقم الاستمارة :";
            // 
            // dateTimeInput_FormEndDate
            // 
            this.dateTimeInput_FormEndDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dateTimeInput_FormEndDate.Location = new System.Drawing.Point(13, 23);
            this.dateTimeInput_FormEndDate.Mask = "0000/00/00";
            this.dateTimeInput_FormEndDate.Name = "dateTimeInput_FormEndDate";
            this.dateTimeInput_FormEndDate.Size = new System.Drawing.Size(89, 20);
            this.dateTimeInput_FormEndDate.TabIndex = 12;
            this.dateTimeInput_FormEndDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_FormEndDate.Click += new System.EventHandler(this.dateTimeInput_FormEndDate_Click);
            this.dateTimeInput_FormEndDate.Leave += new System.EventHandler(this.dateTimeInput_FormEndDate_Leave);
            // 
            // dateTimeInput_FormBeginDate
            // 
            this.dateTimeInput_FormBeginDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dateTimeInput_FormBeginDate.Location = new System.Drawing.Point(160, 23);
            this.dateTimeInput_FormBeginDate.Mask = "0000/00/00";
            this.dateTimeInput_FormBeginDate.Name = "dateTimeInput_FormBeginDate";
            this.dateTimeInput_FormBeginDate.Size = new System.Drawing.Size(89, 20);
            this.dateTimeInput_FormBeginDate.TabIndex = 11;
            this.dateTimeInput_FormBeginDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_FormBeginDate.Click += new System.EventHandler(this.dateTimeInput_FormBeginDate_Click);
            this.dateTimeInput_FormBeginDate.Leave += new System.EventHandler(this.dateTimeInput_FormBeginDate_Leave);
            // 
            // label_FormIssDat
            // 
            this.label_FormIssDat.AutoSize = true;
            this.label_FormIssDat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_FormIssDat.Location = new System.Drawing.Point(249, 26);
            this.label_FormIssDat.Name = "label_FormIssDat";
            this.label_FormIssDat.Size = new System.Drawing.Size(73, 13);
            this.label_FormIssDat.TabIndex = 10;
            this.label_FormIssDat.Text = "تاريخهــــــــــا :";
            // 
            // label_FormNo
            // 
            this.label_FormNo.AutoSize = true;
            this.label_FormNo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_FormNo.Location = new System.Drawing.Point(106, 27);
            this.label_FormNo.Name = "label_FormNo";
            this.label_FormNo.Size = new System.Drawing.Size(45, 13);
            this.label_FormNo.TabIndex = 8;
            this.label_FormNo.Text = "انتهائها :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label_AllownceName);
            this.groupBox3.Controls.Add(this.label_AllowncExpDat);
            this.groupBox3.Controls.Add(this.Label_AllowncIssDat);
            this.groupBox3.Controls.Add(this.label_AllownceNo);
            this.groupBox3.Controls.Add(this.dateTimeInput_AllownceBeginDate);
            this.groupBox3.Controls.Add(this.dateTimeInput_AllownceEndDate);
            this.groupBox3.Controls.Add(this.textBox_AllownceNo);
            this.groupBox3.Controls.Add(this.textBox_AllownceName);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.groupBox3.Location = new System.Drawing.Point(60, 279);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(539, 77);
            this.groupBox3.TabIndex = 6685;
            this.groupBox3.TabStop = false;
            // 
            // label_AllownceName
            // 
            this.label_AllownceName.AutoSize = true;
            this.label_AllownceName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_AllownceName.Location = new System.Drawing.Point(249, 23);
            this.label_AllownceName.Name = "label_AllownceName";
            this.label_AllownceName.Size = new System.Drawing.Size(72, 13);
            this.label_AllownceName.TabIndex = 22;
            this.label_AllownceName.Text = "شركة التأمين:";
            // 
            // label_AllowncExpDat
            // 
            this.label_AllowncExpDat.AutoSize = true;
            this.label_AllowncExpDat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_AllowncExpDat.Location = new System.Drawing.Point(106, 52);
            this.label_AllowncExpDat.Name = "label_AllowncExpDat";
            this.label_AllowncExpDat.Size = new System.Drawing.Size(45, 13);
            this.label_AllowncExpDat.TabIndex = 18;
            this.label_AllowncExpDat.Text = "انتهائها :";
            // 
            // Label_AllowncIssDat
            // 
            this.Label_AllowncIssDat.AutoSize = true;
            this.Label_AllowncIssDat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label_AllowncIssDat.Location = new System.Drawing.Point(249, 52);
            this.Label_AllowncIssDat.Name = "Label_AllowncIssDat";
            this.Label_AllowncIssDat.Size = new System.Drawing.Size(73, 13);
            this.Label_AllowncIssDat.TabIndex = 16;
            this.Label_AllowncIssDat.Text = "تاريخهــــــــــا :";
            // 
            // label_AllownceNo
            // 
            this.label_AllownceNo.AutoSize = true;
            this.label_AllownceNo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_AllownceNo.Location = new System.Drawing.Point(448, 23);
            this.label_AllownceNo.Name = "label_AllownceNo";
            this.label_AllownceNo.Size = new System.Drawing.Size(77, 13);
            this.label_AllownceNo.TabIndex = 14;
            this.label_AllownceNo.Text = "رقم التأمــــين :";
            // 
            // dateTimeInput_AllownceBeginDate
            // 
            this.dateTimeInput_AllownceBeginDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dateTimeInput_AllownceBeginDate.Location = new System.Drawing.Point(160, 49);
            this.dateTimeInput_AllownceBeginDate.Mask = "0000/00/00";
            this.dateTimeInput_AllownceBeginDate.Name = "dateTimeInput_AllownceBeginDate";
            this.dateTimeInput_AllownceBeginDate.Size = new System.Drawing.Size(89, 20);
            this.dateTimeInput_AllownceBeginDate.TabIndex = 15;
            this.dateTimeInput_AllownceBeginDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_AllownceBeginDate.Click += new System.EventHandler(this.dateTimeInput_AllownceBeginDate_Click);
            this.dateTimeInput_AllownceBeginDate.Leave += new System.EventHandler(this.dateTimeInput_AllownceBeginDate_Click);
            // 
            // dateTimeInput_AllownceEndDate
            // 
            this.dateTimeInput_AllownceEndDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dateTimeInput_AllownceEndDate.Location = new System.Drawing.Point(13, 49);
            this.dateTimeInput_AllownceEndDate.Mask = "0000/00/00";
            this.dateTimeInput_AllownceEndDate.Name = "dateTimeInput_AllownceEndDate";
            this.dateTimeInput_AllownceEndDate.Size = new System.Drawing.Size(89, 20);
            this.dateTimeInput_AllownceEndDate.TabIndex = 16;
            this.dateTimeInput_AllownceEndDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_AllownceEndDate.Click += new System.EventHandler(this.dateTimeInput_AllownceEndDate_Click);
            this.dateTimeInput_AllownceEndDate.Leave += new System.EventHandler(this.dateTimeInput_AllownceEndDate_Click);
            // 
            // textBox_AllownceNo
            // 
            this.textBox_AllownceNo.BackColor = System.Drawing.Color.White;
            this.textBox_AllownceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_AllownceNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_AllownceNo.ForeColor = System.Drawing.Color.Black;
            this.textBox_AllownceNo.Location = new System.Drawing.Point(333, 19);
            this.textBox_AllownceNo.MaxLength = 20;
            this.textBox_AllownceNo.Name = "textBox_AllownceNo";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_AllownceNo, false);
            this.textBox_AllownceNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_AllownceNo.Size = new System.Drawing.Size(114, 20);
            this.textBox_AllownceNo.TabIndex = 13;
            this.textBox_AllownceNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_AllownceNo.Click += new System.EventHandler(this.textBox_AllownceNo_Click);
            // 
            // textBox_AllownceName
            // 
            this.textBox_AllownceName.BackColor = System.Drawing.Color.White;
            this.textBox_AllownceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_AllownceName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_AllownceName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox_AllownceName.Location = new System.Drawing.Point(15, 19);
            this.textBox_AllownceName.MaxLength = 40;
            this.textBox_AllownceName.Name = "textBox_AllownceName";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_AllownceName, false);
            this.textBox_AllownceName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_AllownceName.Size = new System.Drawing.Size(234, 20);
            this.textBox_AllownceName.TabIndex = 14;
            this.textBox_AllownceName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_AllownceName.Click += new System.EventHandler(this.textBox_AllownceName_Click);
            // 
            // textBox_Note
            // 
            this.textBox_Note.BackColor = System.Drawing.Color.AliceBlue;
            // 
            // 
            // 
            this.textBox_Note.Border.Class = "TextBoxBorder";
            this.textBox_Note.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_Note.ButtonCustom.Visible = true;
            this.textBox_Note.ForeColor = System.Drawing.Color.Black;
            this.textBox_Note.Location = new System.Drawing.Point(68, 182);
            this.textBox_Note.Multiline = true;
            this.textBox_Note.Name = "textBox_Note";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Note, false);
            this.textBox_Note.Size = new System.Drawing.Size(510, 39);
            this.textBox_Note.TabIndex = 9;
            this.textBox_Note.WatermarkColor = System.Drawing.Color.RosyBrown;
            this.textBox_Note.WatermarkFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Note.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.textBox_Note.WatermarkText = "ملاحظـــــــات السيارة";
            this.textBox_Note.Click += new System.EventHandler(this.textBox_Note_Click);
            // 
            // textBox_NameE
            // 
            this.textBox_NameE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_NameE.Font = new System.Drawing.Font("Tahoma", 8F);
            this.textBox_NameE.ForeColor = System.Drawing.Color.Black;
            this.textBox_NameE.Location = new System.Drawing.Point(68, 112);
            this.textBox_NameE.MaxLength = 30;
            this.textBox_NameE.Name = "textBox_NameE";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_NameE, false);
            this.textBox_NameE.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_NameE.Size = new System.Drawing.Size(395, 20);
            this.textBox_NameE.TabIndex = 5;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.BackColor = System.Drawing.Color.Transparent;
            this.label40.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label40.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label40.Location = new System.Drawing.Point(470, 116);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(119, 13);
            this.label40.TabIndex = 85;
            this.label40.Text = "إسم السيارة - انجليزي :";
            // 
            // textBox_NameA
            // 
            this.textBox_NameA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_NameA.Font = new System.Drawing.Font("Tahoma", 8F);
            this.textBox_NameA.ForeColor = System.Drawing.Color.Black;
            this.textBox_NameA.Location = new System.Drawing.Point(68, 79);
            this.textBox_NameA.MaxLength = 30;
            this.textBox_NameA.Name = "textBox_NameA";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_NameA, false);
            this.textBox_NameA.Size = new System.Drawing.Size(395, 20);
            this.textBox_NameA.TabIndex = 4;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.Transparent;
            this.label36.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label36.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label36.Location = new System.Drawing.Point(470, 83);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(118, 13);
            this.label36.TabIndex = 83;
            this.label36.Text = "إسم السيارة - عربـــي :";
            // 
            // textBox_ID
            // 
            this.textBox_ID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.textBox_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_ID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_ID.Location = new System.Drawing.Point(378, 16);
            this.textBox_ID.Name = "textBox_ID";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_ID, false);
            this.textBox_ID.Size = new System.Drawing.Size(85, 21);
            this.textBox_ID.TabIndex = 1;
            this.textBox_ID.TextChanged += new System.EventHandler(this.textBox_ID_TextChanged);
            this.textBox_ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ID_KeyPress);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.BackColor = System.Drawing.Color.Transparent;
            this.label38.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label38.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label38.Location = new System.Drawing.Point(470, 20);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(75, 13);
            this.label38.TabIndex = 81;
            this.label38.Text = "الرمـــــــــــــز :";
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
            this.ribbonBar_Tasks.Location = new System.Drawing.Point(0, 394);
            this.ribbonBar_Tasks.Name = "ribbonBar_Tasks";
            this.ribbonBar_Tasks.Size = new System.Drawing.Size(649, 51);
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
            this.superTabControl_Main1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl_Main1.ControlBox.MenuBox.Name = "";
            this.superTabControl_Main1.ControlBox.Name = "";
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
            this.superTabControl_Main1.Size = new System.Drawing.Size(239, 51);
            this.superTabControl_Main1.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_Main1.TabIndex = 10;
            this.superTabControl_Main1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.Button_Close,
            this.Button_Search,
            this.Button_Delete,
            this.Button_Save,
            this.Button_Add,
            this.labelItem2});
            this.superTabControl_Main1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.superTabControl_Main1.Text = "superTabControl3";
            this.superTabControl_Main1.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.superTabControl_Main1.RightToLeftChanged += new System.EventHandler(this.superTabControl_Main1_RightToLeftChanged);
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
            // Button_Delete
            // 
            this.Button_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Delete.FontBold = true;
            this.Button_Delete.FontItalic = true;
            this.Button_Delete.ForeColor = System.Drawing.Color.SteelBlue;
            this.Button_Delete.Image = ((System.Drawing.Image)(resources.GetObject("Button_Delete.Image")));
            this.Button_Delete.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Delete.ImagePaddingHorizontal = 15;
            this.Button_Delete.ImagePaddingVertical = 11;
            this.Button_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Delete.Name = "Button_Delete";
            this.Button_Delete.Stretch = true;
            this.Button_Delete.SubItemsExpandWidth = 14;
            this.Button_Delete.Symbol = "";
            this.Button_Delete.SymbolSize = 15F;
            this.Button_Delete.Text = "حذف";
            this.Button_Delete.Tooltip = "حذف السجل الحالي";
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
            // Button_Add
            // 
            this.Button_Add.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Add.FontBold = true;
            this.Button_Add.FontItalic = true;
            this.Button_Add.ForeColor = System.Drawing.Color.Blue;
            this.Button_Add.Image = ((System.Drawing.Image)(resources.GetObject("Button_Add.Image")));
            this.Button_Add.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Add.ImagePaddingHorizontal = 15;
            this.Button_Add.ImagePaddingVertical = 11;
            this.Button_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Add.Name = "Button_Add";
            this.Button_Add.Stretch = true;
            this.Button_Add.SubItemsExpandWidth = 14;
            this.Button_Add.Symbol = "";
            this.Button_Add.SymbolSize = 15F;
            this.Button_Add.Text = "إضافة";
            this.Button_Add.Tooltip = "إضافة سجل جديد";
            // 
            // labelItem2
            // 
            this.labelItem2.Name = "labelItem2";
            this.labelItem2.Width = 40;
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
            this.superTabControl_Main2.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl_Main2.ControlBox.MenuBox.Name = "";
            this.superTabControl_Main2.ControlBox.Name = "";
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
            this.superTabControl_Main2.Location = new System.Drawing.Point(239, 0);
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
            this.expandableSplitter1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.expandableSplitter1.Location = new System.Drawing.Point(0, -2);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(649, 14);
            this.expandableSplitter1.TabIndex = 1;
            this.expandableSplitter1.TabStop = false;
            // 
            // panelEx2
            // 
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx2.Location = new System.Drawing.Point(0, 12);
            this.panelEx2.MinimumSize = new System.Drawing.Size(659, 433);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(659, 433);
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
            this.DGV_Main.PrimaryGrid.Caption.Text = "";
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
            this.DGV_Main.PrimaryGrid.GroupByRow.WatermarkText = "";
            this.DGV_Main.PrimaryGrid.InitialActiveRow = DevComponents.DotNetBar.SuperGrid.RelativeRow.None;
            this.DGV_Main.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.None;
            this.DGV_Main.PrimaryGrid.MultiSelect = false;
            this.DGV_Main.PrimaryGrid.ShowRowGridIndex = true;
            this.DGV_Main.PrimaryGrid.Title.AllowSelection = false;
            this.DGV_Main.PrimaryGrid.Title.Text = "";
            this.DGV_Main.PrimaryGrid.Title.Visible = false;
            this.DGV_Main.PrimaryGrid.Visible = false;
            this.DGV_Main.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DGV_Main.Size = new System.Drawing.Size(649, 0);
            this.DGV_Main.TabIndex = 862;
            // 
            // panelEx3
            // 
            this.panelEx3.Controls.Add(this.DGV_Main);
            this.panelEx3.Controls.Add(this.ribbonBar_DGV);
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx3.Location = new System.Drawing.Point(0, 0);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(649, 0);
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
            this.ribbonBar_DGV.Location = new System.Drawing.Point(0, -51);
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
            this.superTabControl_DGV.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl_DGV.ControlBox.MenuBox.Name = "";
            this.superTabControl_DGV.ControlBox.Name = "";
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
            this.panel1.Size = new System.Drawing.Size(649, 445);
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
            this.barBottomDockSite.Location = new System.Drawing.Point(0, 445);
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
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "");
            this.imageList1.Images.SetKeyName(13, "");
            this.imageList1.Images.SetKeyName(14, "");
            this.imageList1.Images.SetKeyName(15, "");
            this.imageList1.Images.SetKeyName(16, "");
            this.imageList1.Images.SetKeyName(17, "");
            this.imageList1.Images.SetKeyName(18, "");
            this.imageList1.Images.SetKeyName(19, "");
            this.imageList1.Images.SetKeyName(20, "");
            this.imageList1.Images.SetKeyName(21, "");
            this.imageList1.Images.SetKeyName(22, "");
            this.imageList1.Images.SetKeyName(23, "");
            // 
            // barLeftDockSite
            // 
            this.barLeftDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barLeftDockSite.Dock = System.Windows.Forms.DockStyle.Left;
            this.barLeftDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barLeftDockSite.Location = new System.Drawing.Point(0, 0);
            this.barLeftDockSite.Name = "barLeftDockSite";
            this.barLeftDockSite.Size = new System.Drawing.Size(0, 445);
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
            this.barRightDockSite.Size = new System.Drawing.Size(0, 445);
            this.barRightDockSite.TabIndex = 892;
            this.barRightDockSite.TabStop = false;
            // 
            // dockSite4
            // 
            this.dockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite4.Location = new System.Drawing.Point(0, 445);
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
            this.dockSite1.Size = new System.Drawing.Size(0, 445);
            this.dockSite1.TabIndex = 893;
            this.dockSite1.TabStop = false;
            // 
            // dockSite2
            // 
            this.dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite2.Location = new System.Drawing.Point(649, 0);
            this.dockSite2.Name = "dockSite2";
            this.dockSite2.Size = new System.Drawing.Size(0, 445);
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
            // netResize1
            // 
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            // 
            // FrmCar
            // 
            this.ClientSize = new System.Drawing.Size(649, 445);
            this.Controls.Add(this.PanelSpecialContainer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barTopDockSite);
            this.Controls.Add(this.barBottomDockSite);
            this.Controls.Add(this.barLeftDockSite);
            this.Controls.Add(this.barRightDockSite);
            this.Controls.Add(this.dockSite4);
            this.Controls.Add(this.dockSite1);
            this.Controls.Add(this.dockSite2);
            this.Controls.Add(this.dockSite3);
            this.Icon = global::InvAcc.Properties.Resources.favicon;
            this.KeyPreview = true;
            this.Name = "FrmCar";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "كــــــرت السيارات";
            this.Load += new System.EventHandler(this.FrmDept_Load);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.PanelSpecialContainer.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            this.ribbonBar1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ribbonBar_Tasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main2)).EndInit();
            this.panelEx3.ResumeLayout(false);
            this.ribbonBar_DGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_DGV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
