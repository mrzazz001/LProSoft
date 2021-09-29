using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Microsoft.Win32;
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
    public partial  class FrmVacation : Form
    { void avs(int arln)

{ 
}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
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
                        frm.Repvalue = "VacRep";
                        frm.Repvalue = "VacRep";
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
        protected ButtonItem Button_PrintTable;
        protected LabelItem labelItem3;
        private Panel panel2;
        private ComboBoxEx comboBox_EmpNo;
        private ButtonX button_SrchEmp;
        private Label label12;
        private MaskedTextBox dateTimeInput_warnDate;
        private Label label54;
        protected TextBox textBox_ID;
        protected Label label38;
        private TextBoxX textBox_Note;
        private DoubleInput textBox_VacUsed;
        private DoubleInput textBox_VacTotaly;
        private DoubleInput textBox_VacBalance;
        private Label label3;
        private Label label1;
        private Label label9;
        private Label label6;
        private Label label5;
        private Line line1;
        private ComboBoxEx comboBox_VacTyp;
        private IntegerInput textbox_VacCountDay;
        private Label label2;
        private MaskedTextBox dateTimeInput_EndDate;
        private MaskedTextBox dateTimeInput_StopSalFrom;
        private MaskedTextBox dateTimeInput_StartDate;
        private Label label11;
        private Label label8;
        private Label label7;
        private Panel panel3;
        private MaskedTextBox textBox_WithDateSal;
        private DoubleInput textBox_Amount;
        private ComboBox comboBox_CalculateNo;
        private Label label10;
        private Label label24;
        private CheckBox checkBox_VacAllowance;
        private SwitchButton switchButton_Sts;
        private LabelItem lable_Records;
        private SwitchButton switchButton_Lock;
        private Label label4;
        private ComboBoxEx comboBox_EmpNoCover;
        private ButtonX button_SrchEmpCover;
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private T_AccDef _AccDefBind = new T_AccDef();
        private int LangArEn = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
#pragma warning disable CS0414 // The field 'FrmVacation.FlagUpdate' is assigned but its value is never used
        private string FlagUpdate = "";
#pragma warning restore CS0414 // The field 'FrmVacation.FlagUpdate' is assigned but its value is never used
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstance;
        private T_Vacation data_this;
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
        private Dictionary<string, ColumnDictinary> Dir_ButSearch = new Dictionary<string, ColumnDictinary>();
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
                switchButton_Sts.IsReadOnly = !value;
                if (State == FormState.New)
                {
                    switchButton_Lock.Visible = false;
                    try
                    {
                        if (VarGeneral.TString.ChkStatShow(permission.Emp_GenStr, 12))
                        {
                            comboBox_EmpNoCover.Enabled = true;
                        }
                        else
                        {
                            comboBox_EmpNoCover.Enabled = false;
                        }
                    }
                    catch
                    {
                        comboBox_EmpNoCover.Enabled = false;
                    }
                }
                else
                {
                    switchButton_Lock.Visible = true;
                }
                try
                {
                    if (State == FormState.Saved && !switchButton_Lock.Value)
                    {
                        switchButton_Sts.IsReadOnly = true;
                    }
                }
                catch
                {
                }
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
        public T_Vacation DataThis
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
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_MovStr, 9))
                    {
                        IfAdd = false;
                    }
                    else
                    {
                        IfAdd = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_MovStr, 10) || switchButton_Sts.Value)
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_MovStr, 11) || switchButton_Sts.Value)
                    {
                        IfDelete = false;
                    }
                    else
                    {
                        IfDelete = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_GenStr, 12))
                    {
                        switchButton_Lock.IsReadOnly = true;
                    }
                    if (State != FormState.New)
                    {
                        switchButton_Lock.Visible = true;
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
        public void Button_Search_Click(object sender, EventArgs e)
        {
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_Vacation";
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
            List<T_Vacation> list = db.FillVacation_2(textBox_search.TextBox.Text).ToList();
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
        }
        public void FillHDGV(IEnumerable<T_Vacation> new_data_enum)
        {
            bool contextMenuSet = false;
            if (contextMenuStrip1.Items.Count > 0)
            {
                contextMenuSet = true;
            }
            for (int i = 0; i < DGV_Main.PrimaryGrid.Columns.Count; i++)
            {
                if (columns_Names_visible.ContainsKey(DGV_Main.PrimaryGrid.Columns[i].Name) && DGV_Main.PrimaryGrid.Columns[i].Name != "EmpNm" && DGV_Main.PrimaryGrid.Columns[i].Name != "Emp_No")
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
            DGV_Main.PrimaryGrid.DataMember = "T_Vacation";
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
        public void FillCombo()
        {
            List<T_Emp> listEmps = new List<T_Emp>(db.T_Emps.OrderBy((T_Emp item) => item.Emp_No).ToList());
            comboBox_EmpNo.DataSource = listEmps;
            comboBox_EmpNo.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_EmpNo.ValueMember = "Emp_ID";
            List<T_VacTyp> listVacTyp = new List<T_VacTyp>(db.T_VacTyps.Select((T_VacTyp item) => item).ToList());
            comboBox_VacTyp.DataSource = listVacTyp;
            comboBox_VacTyp.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_VacTyp.ValueMember = "VacT_No";
            List<T_OpMethod> listOpMethod = new List<T_OpMethod>((from item in db.T_OpMethods
                                                                  orderby item.Method_No
                                                                  where item.Method_No != 1 && item.Method_No != 7 && item.Method_No != 8 && item.Method_No != 9 && item.Method_No != 10 && item.Method_No != 10 && item.Method_No != 11 && item.Method_No != 12 && item.Method_No != 13
                                                                  select item).ToList());
            comboBox_CalculateNo.DataSource = listOpMethod;
            comboBox_CalculateNo.DisplayMember = ((LangArEn == 0) ? "Name" : "NameE");
            comboBox_CalculateNo.ValueMember = "Method_No";
            List<T_Emp> listEmpsCover = new List<T_Emp>(db.T_Emps.OrderBy((T_Emp item) => item.Emp_No).ToList());
            listEmpsCover.Insert(0, new T_Emp());
            comboBox_EmpNoCover.DataSource = listEmpsCover;
            comboBox_EmpNoCover.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_EmpNoCover.ValueMember = "Emp_ID";
            comboBox_EmpNoCover.SelectedIndex = 0;
        }
        public void Clear()
        {
            if (State == FormState.New)
            {
                return;
            }
            State = FormState.New;
            data_this = new T_Vacation();
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
                    else if (controls[i].GetType() == typeof(ComboBox) && (controls[i] as ComboBox).Items.Count > 0)
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
                    else if (controls[i].GetType() == typeof(ComboBoxEx) && (controls[i] as ComboBoxEx).Items.Count > 0)
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
            calendr = VarGeneral.Settings_Sys.Calendr;
            if (calendr.Value == 0 && calendr.HasValue)
            {
                dateTimeInput_StartDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                dateTimeInput_StopSalFrom.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                dateTimeInput_warnDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
            }
            else
            {
                dateTimeInput_StartDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                dateTimeInput_StopSalFrom.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                dateTimeInput_warnDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
            }
            Guid id = Guid.NewGuid();
            textBox_ID.Tag = id.ToString();
            switchButton_Sts.Value = false;
            checkBox_VacAllowance.Checked = false;
            switchButton_Lock.Value = false;
            Fill_VacationBalance();
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
                Button_PrintTable_Click(sender, e);
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
            var qkeys = db.T_Vacations.Select((T_Vacation item) => new
            {
                Code = item.warnNo + ""
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
        public FrmVacation()
        {
            InitializeComponent();this.Load += langloads;
            switchButton_Sts.ValueChanging += switchButton_Sts_ValueChanging;
            checkBox_VacAllowance.CheckedChanged += checkBox_VacAllowance_CheckedChanged;
            textBox_ID.KeyPress += textBox_ID_KeyPress;
            Button_Close.Click += Button_Close_Click;
            textBox_Amount.Click += Button_Edit_Click;
            textbox_VacCountDay.Click += Button_Edit_Click;
            textBox_Note.Click += Button_Edit_Click;
            textBox_WithDateSal.Click += Button_Edit_Click;
            comboBox_CalculateNo.Click += Button_Edit_Click;
            comboBox_EmpNo.Click += Button_Edit_Click;
            comboBox_VacTyp.Click += Button_Edit_Click;
            comboBox_EmpNoCover.Click += Button_Edit_Click;
            checkBox_VacAllowance.Click += Button_Edit_Click;
            dateTimeInput_EndDate.MouseDown += Button_Edit_Click;
            dateTimeInput_StartDate.MouseDown += Button_Edit_Click;
            dateTimeInput_StopSalFrom.MouseDown += Button_Edit_Click;
            dateTimeInput_warnDate.MouseDown += Button_Edit_Click;
            checkBox_VacAllowance.Click += Button_Edit_Click;
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
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmVacation));
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
                label38.Text = "الكـــــــــــــــــــود :";
                textBox_Note.WatermarkText = "ملاحظـــــــات الإجـــازات";
                switchButton_Lock.OffText = "لم يتم الموافقة";
                switchButton_Lock.OnText = "تمت الموافقة";
                Text = "كرت الإجـــازات";
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
                textBox_Note.WatermarkText = "Notes";
                switchButton_Lock.OffText = "not approved";
                switchButton_Lock.OnText = "Been approved";
                Text = "Vacations Card";
            }
        }
        private void FrmVacation_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmVacation));
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
                ADD_Controls();
                Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
                FillCombo();
                if (columns_Names_visible.Count == 0)
                {
                    columns_Names_visible.Add("warnNo", new ColumnDictinary("رقم العملية", "No", ifDefault: true, ""));
                    columns_Names_visible.Add("EmpNm", new ColumnDictinary("اسم الموظف", "Employee Name", ifDefault: false, ""));
                    columns_Names_visible.Add("Emp_No", new ColumnDictinary("رقم الموظف", "Employee No", ifDefault: false, ""));
                    columns_Names_visible.Add("warnDate", new ColumnDictinary("تاريخ العملية", "Date", ifDefault: true, ""));
                    columns_Names_visible.Add("StartDate", new ColumnDictinary("تاريخ بداية الاجازة", "Start Date", ifDefault: true, ""));
                    columns_Names_visible.Add("EndDate", new ColumnDictinary("تاريخ نهاية الإجازة", "End Date", ifDefault: false, ""));
                    columns_Names_visible.Add("VacCountDay", new ColumnDictinary("عدد أيام الاجازة", "Acount Days", ifDefault: true, ""));
                    columns_Names_visible.Add("Note", new ColumnDictinary("الملاحظات", "Note", ifDefault: true, ""));
                }
                else
                {
                    Clear();
                    textBox_ID.Text = "";
                    TextBox_Index.TextBox.Text = "";
                }
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
            switchButton_Sts.ValueChanging -= switchButton_Sts_ValueChanging;
            checkBox_VacAllowance.CheckedChanged -= checkBox_VacAllowance_CheckedChanged;
            try
            {
                T_Vacation newData = db.VacEmp(no);
                if (newData == null || newData.warnNo == 0 || string.IsNullOrEmpty(newData.vacation_ID))
                {
                    if (!Button_Add.Visible || !Button_Add.Enabled)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textBox_ID.TextChanged -= textBox_ID_TextChanged;
                        try
                        {
                            textBox_ID.Text = data_this.warnNo.ToString();
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
                    int indexA = PKeys.IndexOf(string.Concat(newData.warnNo));
                    indexA++;
                    TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                    TextBox_Index.TextBox.Text = string.Concat(indexA);
                    TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                }
                Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
            }
            catch
            {
            }
            switchButton_Sts.ValueChanging += switchButton_Sts_ValueChanging;
            checkBox_VacAllowance.CheckedChanged += checkBox_VacAllowance_CheckedChanged;
            UpdateVcr();
        }
        public void SetData(T_Vacation value)
        {
            State = FormState.Saved;
            Button_Save.Enabled = false;
            switchButton_Sts.IsReadOnly = false;
            if (value.IFState.HasValue)
            {
                switchButton_Sts.Value = value.IFState.Value;
            }
            else
            {
                switchButton_Sts.Value = false;
            }
            switchButton_Lock.Value = value.AdminLock.Value;
            if (!string.IsNullOrEmpty(value.EmpID))
            {
                comboBox_EmpNo.SelectedValue = value.EmpID;
                Fill_VacationBalance();
            }
            try
            {
                if (!string.IsNullOrEmpty(value.EmpCover))
                {
                    comboBox_EmpNoCover.SelectedValue = value.EmpCover;
                }
                else
                {
                    comboBox_EmpNoCover.SelectedIndex = 0;
                }
            }
            catch
            {
                comboBox_EmpNoCover.SelectedIndex = 0;
            }
            if (value.VacTyp.HasValue)
            {
                comboBox_VacTyp.SelectedValue = value.VacTyp;
            }
            checkBox_VacAllowance.Checked = value.VacAllowance.Value;
            if (checkBox_VacAllowance.Checked)
            {
                panel3.Enabled = true;
                textBox_WithDateSal.Enabled = true;
                textBox_Amount.Enabled = true;
                textBox_Amount.Value = value.Amount.Value;
                textBox_WithDateSal.Text = value.WithDateSal;
                if (value.CalculateNo.HasValue)
                {
                    comboBox_CalculateNo.SelectedValue = value.CalculateNo;
                }
            }
            textbox_VacCountDay.Value = value.VacCountDay.Value;
            textBox_Note.Text = value.Note;
            dateTimeInput_StartDate.Text = value.StartDate;
            textBox_ID.Tag = value.vacation_ID;
            try
            {
                if (VarGeneral.CheckDate(value.StartDate))
                {
                    dateTimeInput_StartDate.Text = Convert.ToDateTime(value.StartDate).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_StartDate.Text = "";
                }
            }
            catch
            {
                dateTimeInput_StartDate.Text = "";
            }
            try
            {
                if (VarGeneral.CheckDate(value.EndDate))
                {
                    dateTimeInput_EndDate.Text = Convert.ToDateTime(value.EndDate).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_EndDate.Text = "";
                }
            }
            catch
            {
                dateTimeInput_EndDate.Text = "";
            }
            try
            {
                if (VarGeneral.CheckDate(value.StopSalFrom))
                {
                    dateTimeInput_StopSalFrom.Text = Convert.ToDateTime(value.StopSalFrom).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_StopSalFrom.Text = "";
                }
            }
            catch
            {
                dateTimeInput_StopSalFrom.Text = "";
            }
            try
            {
                if (VarGeneral.CheckDate(value.warnDate))
                {
                    dateTimeInput_warnDate.Text = Convert.ToDateTime(value.warnDate).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_warnDate.Text = "";
                }
            }
            catch
            {
                dateTimeInput_warnDate.Text = "";
            }
            SetReadOnly = true;
            switchButton_Lock_ValueChanged(null, null);
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
        private T_Vacation GetData()
        {
            textBox_ID.Focus();
            try
            {
                if (checkBox_VacAllowance.Checked)
                {
                    data_this.Amount = textBox_Amount.Value;
                }
                else
                {
                    data_this.Amount = 0.0;
                }
            }
            catch
            {
                data_this.Amount = 0.0;
            }
            try
            {
                data_this.VacCountDay = textbox_VacCountDay.Value;
            }
            catch
            {
                data_this.VacCountDay = 0;
            }
            try
            {
                data_this.EndDate = Convert.ToDateTime(dateTimeInput_EndDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_EndDate.Text = "";
                data_this.EndDate = "";
            }
            try
            {
                data_this.StartDate = Convert.ToDateTime(dateTimeInput_StartDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_StartDate.Text = "";
                data_this.StartDate = "";
            }
            try
            {
                data_this.StopSalFrom = Convert.ToDateTime(dateTimeInput_StopSalFrom.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_StopSalFrom.Text = "";
                data_this.StopSalFrom = "";
            }
            try
            {
                data_this.warnDate = Convert.ToDateTime(dateTimeInput_warnDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_warnDate.Text = "";
                data_this.warnDate = "";
            }
            try
            {
                data_this.VacAllowance = checkBox_VacAllowance.Checked;
            }
            catch
            {
                data_this.VacAllowance = false;
            }
            try
            {
                if (checkBox_VacAllowance.Checked)
                {
                    data_this.CalculateNo = int.Parse(comboBox_CalculateNo.SelectedValue.ToString());
                }
                else
                {
                    data_this.CalculateNo = null;
                }
            }
            catch
            {
                data_this.CalculateNo = null;
            }
            try
            {
                data_this.EmpID = comboBox_EmpNo.SelectedValue.ToString();
            }
            catch
            {
                data_this.EmpID = null;
            }
            try
            {
                if (comboBox_EmpNoCover.SelectedIndex > 0 && switchButton_Lock.Value)
                {
                    data_this.EmpCover = comboBox_EmpNoCover.SelectedValue.ToString();
                }
                else
                {
                    data_this.EmpCover = null;
                }
            }
            catch
            {
                data_this.EmpCover = null;
            }
            try
            {
                data_this.VacTyp = int.Parse(comboBox_VacTyp.SelectedValue.ToString());
            }
            catch
            {
                data_this.VacTyp = null;
            }
            data_this.warnNo = int.Parse(textBox_ID.Text);
            data_this.Note = textBox_Note.Text;
            try
            {
                if (checkBox_VacAllowance.Checked)
                {
                    data_this.WithDateSal = Convert.ToDateTime(textBox_WithDateSal.Text).ToString("yyyy/MM");
                }
                else
                {
                    data_this.WithDateSal = null;
                }
            }
            catch
            {
                data_this.WithDateSal = DateTime.Now.ToString("yyyy/MM");
            }
            try
            {
                data_this.IFState = switchButton_Sts.Value;
            }
            catch
            {
                data_this.IFState = false;
            }
            if (State == FormState.New && VarGeneral.TString.ChkStatShow(permission.Emp_GenStr, 12))
            {
                data_this.AdminLock = true;
            }
            else
            {
                data_this.AdminLock = switchButton_Lock.Value;
            }
            return data_this;
        }
        private void Button_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Button_Add.Visible || !Button_Add.Enabled)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا تملك الصلاحية هذه العملية .. يرجى مراجعة الصلاحيات" : "You are not permission this operation .. Please check permissions", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else if (State != FormState.Edit || !(textBox_ID.Text != "") || MessageBox.Show((LangArEn == 0) ? "لم يتم حفظ التغيرات, هل حقا\u064b تريد المتابعة؟" : "Not saved the changes, do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    int max = 0;
                    max = db.MaxVacationNo;
                    textBox_ID.Text = max.ToString();
                    Clear();
                    State = FormState.New;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Button_Add_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void Button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                textBox_ID.Focus();
                if (!ValidData())
                {
                    return;
                }
                if (State == FormState.New)
                {
                    try
                    {
                        GetData();
                        data_this.vacation_ID = textBox_ID.Tag.ToString();
                        db.T_Vacations.InsertOnSubmit(data_this);
                        db.SubmitChanges();
                        T_VacTyp q = db.VacTypEmp(int.Parse(comboBox_VacTyp.SelectedValue.ToString()));
                        if (q.Dis_VacT.Value)
                        {
                            if (data_this.AdminLock.Value)
                            {
                                db.Update_VacBalance(comboBox_EmpNo.SelectedValue.ToString(), textbox_VacCountDay.Value, 0.0);
                            }
                            else
                            {
                                db.Update_VacBalance(comboBox_EmpNo.SelectedValue.ToString(), 0.0, 0.0);
                            }
                        }
                    }
                    catch (SqlException error2)
                    {
                        int max = 0;
                        max = db.MaxVacationNo;
                        if (error2.Number == 2627)
                        {
                            MessageBox.Show((LangArEn == 0) ? ("رقم الأمر مستخدم من قبل.\nسيتم الحفظ برقم جديد [" + max + "]") : ("This No is user before.\nWill be save a new number [" + max + "]"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            textBox_ID.TextChanged -= textBox_ID_TextChanged;
                            textBox_ID.Text = string.Concat(max);
                            textBox_ID.TextChanged += textBox_ID_TextChanged;
                            data_this.warnNo = max;
                            Button_Save_Click(sender, e);
                        }
                        else
                        {
                            VarGeneral.DebLog.writeLog("Button_Save_Click:", error2, enable: true);
                            MessageBox.Show(error2.Message);
                        }
                        return;
                    }
                }
                else if (State == FormState.Edit)
                {
                    T_VacTyp q = db.VacTypEmp(int.Parse(comboBox_VacTyp.SelectedValue.ToString()));
                    if (q.Dis_VacT.Value)
                    {
                        if (data_this.AdminLock.Value)
                        {
                            if (switchButton_Lock.Value)
                            {
                                db.Update_VacBalance(comboBox_EmpNo.SelectedValue.ToString(), textbox_VacCountDay.Value, data_this.VacCountDay.Value);
                            }
                            else
                            {
                                db.Update_VacBalance(comboBox_EmpNo.SelectedValue.ToString(), 0.0, data_this.VacCountDay.Value);
                            }
                        }
                        else if (!switchButton_Lock.Value)
                        {
                            db.Update_VacBalance(comboBox_EmpNo.SelectedValue.ToString(), 0.0, 0.0);
                        }
                        else
                        {
                            db.Update_VacBalance(comboBox_EmpNo.SelectedValue.ToString(), textbox_VacCountDay.Value, 0.0);
                        }
                    }
                    GetData();
                    db.Log = VarGeneral.DebugLog;
                    db.SubmitChanges(ConflictMode.ContinueOnConflict);
                }
                State = FormState.Saved;
                RefreshPKeys();
                TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(string.Concat(data_this.warnNo)) + 1);
                dbInstance = null;
                textBox_ID_TextChanged(sender, e);
                SetReadOnly = true;
                try
                {
                    Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
                    dbc.ExecuteCommand("UPDATE [T_Emp] SET T_Emp.StatusSal = 2 FROM [T_Emp] INNER JOIN dbo.T_Vacation ON T_Emp.Emp_ID = T_Vacation.[EmpID] WHERE T_Vacation.IFState = 0 and (((SUBSTRING(T_Vacation.StopSalFrom,1,4) >= 1800 and '" + n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") + "' >= T_Vacation.StopSalFrom )) OR ((SUBSTRING(T_Vacation.StopSalFrom,1,4) < 1800 and '" + n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd") + "' >= T_Vacation.StopSalFrom ))) AND T_Vacation.StopSalFrom <> '' ");
                }
                catch
                {
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Button_Save_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void UpVacOfEmp(string EmpNo_)
        {
            try
            {
                Stock_DataDataContext DBEmp = new Stock_DataDataContext(VarGeneral.BranchCS);
                T_Emp q = DBEmp.EmpsEmp(EmpNo_);
                string vD = "";
                string vD2 = "";
                string vD3 = "";
                string vD4 = "";
                if (VarGeneral.CheckDate(q.LastFilter))
                {
                    vD = Convert.ToDateTime(q.LastFilter).ToString("yyyy/MM/dd");
                }
                if (VarGeneral.CheckDate(q.DateAppointment))
                {
                    vD2 = Convert.ToDateTime(q.DateAppointment).ToString("yyyy/MM/dd");
                }
                if (VarGeneral.CheckDate(q.EndContr))
                {
                    vD3 = Convert.ToDateTime(q.EndContr).ToString("yyyy/MM/dd");
                }
                double TicketUse = 0.0;
                int VacUse = 0;
                TicketUse = DBEmp.ExecuteQuery<double>("select dbo.GetTickeUsed('" + q.Emp_ID + "')", new object[0]).FirstOrDefault();
                VacUse = DBEmp.ExecuteQuery<int>("select dbo.GetVacUsed('" + q.Emp_ID + "')", new object[0]).FirstOrDefault();
                vD4 = (VarGeneral.CheckDate(vD) ? vD : vD2);
                q.VacationBalance = DBEmp.VacAmount(vD4, VarGeneral.CheckDate(vD3) ? vD3 : (n.IsGreg(vD4) ? n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") : n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd")), q.VacationCount.Value) - VacUse;
                DBEmp.Log = VarGeneral.DebugLog;
                DBEmp.SubmitChanges(ConflictMode.ContinueOnConflict);
            }
            catch
            {
            }
        }
        private void Button_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Button_Delete.Enabled || !Button_Delete.Visible)
                {
                    ifOkDelete = false;
                    return;
                }
                string Code = "???";
                if (codeControl != null)
                {
                    Code = codeControl.Text;
                }
                if (Code == "")
                {
                    ifOkDelete = false;
                    return;
                }
                if (MessageBox.Show((LangArEn == 0) ? ("هل أنت متاكد من حذف السجل " + Code) : ("Are you sure you want to delete the record ? " + Code), VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ifOkDelete = true;
                }
                else
                {
                    ifOkDelete = false;
                }
                if (data_this != null && data_this.warnNo != 0 && !string.IsNullOrEmpty(data_this.vacation_ID) && ifOkDelete)
                {
                    data_this = db.VacEmp(DataThis.warnNo);
                    db.T_Vacations.DeleteOnSubmit(DataThis);
                    db.SubmitChanges();
                    if (data_this.AdminLock.Value)
                    {
                        db.Update_VacBalance(comboBox_EmpNo.SelectedValue.ToString(), 0.0, textbox_VacCountDay.Value);
                    }
                    Clear();
                    RefreshPKeys();
                    textBox_ID.Text = PKeys.LastOrDefault();
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Button_Delete_Click:", error, enable: true);
                MessageBox.Show(error.Message);
                DataThis = db.VacEmp(DataThis.warnNo);
            }
        }
        private void DGV_Main_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            string dataMember = panel.DataMember;
            if (dataMember != null && dataMember == "T_Vacation")
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
            panel.Columns["warnNo"].Width = 120;
            panel.Columns["warnNo"].Visible = columns_Names_visible["warnNo"].IfDefault;
            panel.Columns["warnDate"].Width = 120;
            panel.Columns["warnDate"].Visible = columns_Names_visible["warnDate"].IfDefault;
            panel.Columns["Emp_No"].Width = 120;
            panel.Columns["Emp_No"].Visible = columns_Names_visible["Emp_No"].IfDefault;
            panel.Columns["EmpNm"].Width = 250;
            panel.Columns["EmpNm"].Visible = columns_Names_visible["EmpNm"].IfDefault;
            panel.Columns["StartDate"].Width = 120;
            panel.Columns["StartDate"].Visible = columns_Names_visible["StartDate"].IfDefault;
            panel.Columns["EndDate"].Width = 120;
            panel.Columns["EndDate"].Visible = columns_Names_visible["EndDate"].IfDefault;
            panel.Columns["VacCountDay"].Width = 120;
            panel.Columns["VacCountDay"].Visible = columns_Names_visible["VacCountDay"].IfDefault;
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
                ExportExcel.ExportToExcel(DGV_Main, "تقرير التذاكــــر");
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
        private void textBox_Note_Click(object sender, EventArgs e)
        {
            textBox_Note.SelectAll();
        }
        private void dateTimeInput_warnDate_Click(object sender, EventArgs e)
        {
            dateTimeInput_warnDate.SelectAll();
        }
        private void ADD_Controls()
        {
            try
            {
                controls = new List<Control>();
                controls.Add(textBox_ID);
                codeControl = textBox_ID;
                controls.Add(textBox_Amount);
                controls.Add(textbox_VacCountDay);
                controls.Add(textBox_Note);
                controls.Add(textBox_VacBalance);
                controls.Add(textBox_VacTotaly);
                controls.Add(textBox_VacUsed);
                controls.Add(textBox_WithDateSal);
                controls.Add(dateTimeInput_EndDate);
                controls.Add(dateTimeInput_StartDate);
                controls.Add(dateTimeInput_StopSalFrom);
                controls.Add(dateTimeInput_warnDate);
                controls.Add(checkBox_VacAllowance);
                controls.Add(comboBox_CalculateNo);
                controls.Add(comboBox_EmpNo);
                controls.Add(comboBox_EmpNoCover);
                controls.Add(comboBox_VacTyp);
                controls.Add(switchButton_Sts);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("ADD_Controls:", error, enable: true);
                MessageBox.Show(error.Message);
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
                            string dtAction = (n.IsHijri(dateTimeInput_warnDate.Text) ? dateTimeInput_warnDate.Text : n.GregToHijri(dateTimeInput_warnDate.Text, "yyyy/MM/dd"));
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
#pragma warning disable CS0162 // Unreachable code detected
               return false; if (SystemInformation.TerminalServerSession)
#pragma warning restore CS0162 // Unreachable code detected
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
        private bool ValidData()
        {
            try
            {
                try
                {
                    if (int.Parse(textBox_ID.Text) <= 0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "هناك خطأ في المدخلات ,, الرجاء التأكد من الرقم " : "There is an error in the input, please make sure of the No", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textBox_ID.Focus();
                        return false;
                    }
                }
                catch
                {
                }
                if (!Button_Save.Enabled)
                {
                    return false;
                }
                if (State == FormState.Edit && !CanEdit)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا تملك الصلاحية هذه العملية .. يرجى مراجعة الصلاحيات" : "You are not permission this operation .. Please check permissions", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                if (State == FormState.New && !Button_Add.Enabled)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا تملك الصلاحية هذه العملية .. يرجى مراجعة الصلاحيات" : "You are not permission this operation .. Please check permissions", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                if (textBox_ID.Text == "")
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب تحديد الرقم " : "Must Set the order number", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_ID.Focus();
                    return false;
                }
                T_Vacation q = db.VacEmp(int.Parse(textBox_ID.Text));
                if (!string.IsNullOrEmpty(q.vacation_ID) && State == FormState.New)
                {
                    MessageBox.Show((LangArEn == 0) ? " الرقم  موجود من قبل" : " No It's a existing", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_ID.Focus();
                    return false;
                }
                if (comboBox_EmpNo.SelectedIndex == -1)
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب تحديد موظف" : "Most Select Employee", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    comboBox_EmpNo.Focus();
                    return false;
                }
                try
                {
                    if (comboBox_EmpNoCover.SelectedIndex > 0 && comboBox_EmpNoCover.SelectedValue == comboBox_EmpNo.SelectedValue)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يصح ان يكون الموظف البديل نفسه صاحب الإجازة .. " : "It is not right that the alternative employee himself has the license ..", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        comboBox_EmpNoCover.Focus();
                        return false;
                    }
                }
                catch
                {
                }
                if (false)
                {
#pragma warning disable CS0162 // Unreachable code detected
                    Environment.Exit(0);
#pragma warning restore CS0162 // Unreachable code detected
                    return false;
                }
                try
                {
                    if (State == FormState.New)
                    {
                        List<T_Vacation> vVac = db.T_Vacations.Where((T_Vacation t) => t.IFState == (bool?)false && t.EmpID == comboBox_EmpNo.SelectedValue.ToString()).ToList();
                        if (vVac.Count > 0)
                        {
                            try
                            {
                                if (!string.IsNullOrEmpty(vVac.First().vacation_ID))
                                {
                                    MessageBox.Show("يرجى ترحيل الاجازات السابقة لهذا الموظف قبل اتمام عملية الحفظ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    return false;
                                }
                            }
                            catch
                            {
                                MessageBox.Show("يرجى ترحيل الاجازات السابقة لهذا الموظف قبل اتمام عملية الحفظ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return false;
                            }
                        }
                    }
                }
                catch
                {
                }
                if (comboBox_VacTyp.SelectedIndex == -1)
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من نوع الإجازة " : "You must select vacation type", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    comboBox_EmpNo.Focus();
                    return false;
                }
                if (checkBox_VacAllowance.Checked && textBox_WithDateSal.Text.Trim().Length != 7)
                {
                    MessageBox.Show((LangArEn == 0) ? "تاكد من تاريخ الراتب" : "Make sure the date of salary", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                if (!VarGeneral.CheckDate(dateTimeInput_StartDate.Text.Trim()))
                {
                    MessageBox.Show((LangArEn == 0) ? "عفوا\u064b , تأكد من تاريخ البداية " : "Sorry .. Start Date is Uncorrecte", VarGeneral.ProdectNam);
                    dateTimeInput_StartDate.Focus();
                    return false;
                }
                if (!VarGeneral.CheckDate(dateTimeInput_EndDate.Text.Trim()))
                {
                    MessageBox.Show((LangArEn == 0) ? "عفوا\u064b , تأكد من تاريخ النهاية " : "Sorry .. End Date is Uncorrecte", VarGeneral.ProdectNam);
                    dateTimeInput_EndDate.Focus();
                    return false;
                }
                try
                {
                    if (textbox_VacCountDay.Value <= 0 || Convert.ToDateTime(dateTimeInput_StartDate.Text) > Convert.ToDateTime(dateTimeInput_EndDate.Text))
                    {
                        MessageBox.Show((LangArEn == 0) ? "عفوا\u064b , تأكد من تاريخ البداية والنهاية " : "Sorry .. Start Date and End Date is Uncorrecte", VarGeneral.ProdectNam);
                        dateTimeInput_StartDate.Focus();
                        return false;
                    }
                }
                catch
                {
                    MessageBox.Show((LangArEn == 0) ? "عفوا\u064b , تأكد من تاريخ البداية والنهاية " : "Sorry .. Start Date and End Date is Uncorrecte", VarGeneral.ProdectNam);
                    dateTimeInput_StartDate.Focus();
                    return false;
                }
                if (textbox_VacCountDay.Value <= 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "عفوا\u064b , يجب إدخال عدد صحيح لأيام الإجازة " : "Sorry, you must enter an integer to vacation days", VarGeneral.ProdectNam);
                    textbox_VacCountDay.Focus();
                    return false;
                }
                if (!VarGeneral.CheckDate(dateTimeInput_warnDate.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب تحديد تاريخ القرار" : "You must specify the date of the decision", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    dateTimeInput_warnDate.Focus();
                    return false;
                }
                if (State == FormState.New)
                {
                    if ((double)textbox_VacCountDay.Value > textBox_VacBalance.Value && MessageBox.Show((LangArEn == 0) ? "قيمة الإجازة أكبر من المدة المستحقة .. هل تريد المتابعة؟ " : "Value greater than the duration of leave accrued .. Do you want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        return false;
                    }
                }
                else if (State == FormState.Edit && (double)(textbox_VacCountDay.Value - data_this.VacCountDay.Value) > textBox_VacBalance.Value && MessageBox.Show((LangArEn == 0) ? "قيمة الإجازة أكبر من المدة المستحقة .. هل تريد المتابعة؟ " : "Value greater than the duration of leave accrued .. Do you want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return false;
                }
                return true;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("ValidData:", error, enable: true);
                MessageBox.Show(error.Message);
                return false;
            }
        }
        private void dateTimeInput_warnDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(dateTimeInput_warnDate.Text))
                {
                    dateTimeInput_warnDate.Text = Convert.ToDateTime(dateTimeInput_warnDate.Text).ToString("yyyy/MM/dd");
                    return;
                }
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                if (calendr.Value == 0 && calendr.HasValue)
                {
                    dateTimeInput_warnDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_warnDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                }
            }
            catch
            {
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                if (calendr.Value == 0 && calendr.HasValue)
                {
                    dateTimeInput_warnDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_warnDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                }
            }
        }
        private void button_SrchEmp_Click(object sender, EventArgs e)
        {
            if (!comboBox_EmpNo.Enabled)
            {
                return;
            }
            try
            {
                Dir_ButSearch.Clear();
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
        private void switchButton_Sts_ValueChanging(object sender, EventArgs e)
        {
            try
            {
                if (State == FormState.Saved && !Button_Save.Enabled)
                {
                    if (!VarGeneral.TString.ChkStatShow(Permmission.Emp_GenStr, 7))
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. الرجاء مراجعة صلاحيات المستخدمين !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        try
                        {
                            switchButton_Sts.Value = data_this.IFState.Value;
                        }
                        catch
                        {
                            switchButton_Sts.Value = false;
                        }
                        return;
                    }
                    try
                    {
                        if (!switchButton_Sts.Value)
                        {
                            data_this.IFState = true;
                        }
                        else
                        {
                            data_this.IFState = false;
                        }
                    }
                    catch
                    {
                        data_this.IFState = false;
                    }
                    db.Log = VarGeneral.DebugLog;
                    db.SubmitChanges(ConflictMode.ContinueOnConflict);
                    try
                    {
                        if (!VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.EmpSeting, 0))
                        {
                            Stock_DataDataContext dbc_ = new Stock_DataDataContext(VarGeneral.BranchCS);
                            int? calendr = VarGeneral.Settings_Sys.Calendr;
                            if (calendr.Value == 0 && calendr.HasValue)
                            {
                                if (!switchButton_Sts.Value)
                                {
                                    if (data_this.StartDate.Substring(5, 2) == VarGeneral.Gdate.Substring(5, 2) && data_this.EndDate.Substring(5, 2) == VarGeneral.Gdate.Substring(5, 2) && data_this.StartDate.Substring(0, 4) == VarGeneral.Gdate.Substring(0, 4) && data_this.EndDate.Substring(0, 4) == VarGeneral.Gdate.Substring(0, 4))
                                    {
                                        dbc_.ExecuteCommand("UPDATE [T_Emp] SET T_Emp.StatusSal = 1 FROM [T_Emp] INNER JOIN dbo.T_Vacation ON T_Emp.Emp_ID = T_Vacation.[EmpID] WHERE T_Vacation.IFState = 1 and T_Emp.StatusSal = 2 ");
                                        dbc_.ExecuteCommand("UPDATE [T_Emp] SET T_Emp.StatusSal = 2 FROM [T_Emp] INNER JOIN dbo.T_Vacation ON T_Emp.Emp_ID = T_Vacation.[EmpID] WHERE T_Vacation.IFState = 0 and (((SUBSTRING(T_Vacation.StopSalFrom,1,4) >= 1800 and '" + n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") + "' >= T_Vacation.StopSalFrom)) OR ((SUBSTRING(T_Vacation.StopSalFrom,1,4) < 1800 and '" + n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd") + "' >= T_Vacation.StopSalFrom ))) AND T_Vacation.StopSalFrom <> '' ");
                                    }
                                }
                                else
                                {
                                    dbc_.ExecuteCommand("UPDATE [T_Emp] SET T_Emp.StatusSal = 2 FROM [T_Emp] INNER JOIN dbo.T_Vacation ON T_Emp.Emp_ID = T_Vacation.[EmpID] WHERE T_Vacation.IFState = 0 and (((SUBSTRING(T_Vacation.StopSalFrom,1,4) >= 1800 and '" + n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") + "' >= T_Vacation.StopSalFrom)) OR ((SUBSTRING(T_Vacation.StopSalFrom,1,4) < 1800 and '" + n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd") + "' >= T_Vacation.StopSalFrom ))) AND T_Vacation.StopSalFrom <> '' ");
                                }
                            }
                            else if (!switchButton_Sts.Value)
                            {
                                if (data_this.StartDate.Substring(5, 2) == VarGeneral.Hdate.Substring(5, 2) && data_this.EndDate.Substring(5, 2) == VarGeneral.Hdate.Substring(5, 2) && data_this.StartDate.Substring(0, 4) == VarGeneral.Hdate.Substring(0, 4) && data_this.EndDate.Substring(0, 4) == VarGeneral.Hdate.Substring(0, 4))
                                {
                                    dbc_.ExecuteCommand("UPDATE [T_Emp] SET T_Emp.StatusSal = 1 FROM [T_Emp] INNER JOIN dbo.T_Vacation ON T_Emp.Emp_ID = T_Vacation.[EmpID] WHERE T_Vacation.IFState = 1 and T_Emp.StatusSal = 2 ");
                                    dbc_.ExecuteCommand("UPDATE [T_Emp] SET T_Emp.StatusSal = 2 FROM [T_Emp] INNER JOIN dbo.T_Vacation ON T_Emp.Emp_ID = T_Vacation.[EmpID] WHERE T_Vacation.IFState = 0 and (((SUBSTRING(T_Vacation.StopSalFrom,1,4) >= 1800 and '" + n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") + "' >= T_Vacation.StopSalFrom)) OR ((SUBSTRING(T_Vacation.StopSalFrom,1,4) < 1800 and '" + n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd") + "' >= T_Vacation.StopSalFrom ))) AND T_Vacation.StopSalFrom <> '' ");
                                }
                            }
                            else
                            {
                                dbc_.ExecuteCommand("UPDATE [T_Emp] SET T_Emp.StatusSal = 2 FROM [T_Emp] INNER JOIN dbo.T_Vacation ON T_Emp.Emp_ID = T_Vacation.[EmpID] WHERE T_Vacation.IFState = 0 and (((SUBSTRING(T_Vacation.StopSalFrom,1,4) >= 1800 and '" + n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd") + "' >= T_Vacation.StopSalFrom)) OR ((SUBSTRING(T_Vacation.StopSalFrom,1,4) < 1800 and '" + n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd") + "' >= T_Vacation.StopSalFrom ))) AND T_Vacation.StopSalFrom <> '' ");
                            }
                        }
                    }
                    catch (Exception error2)
                    {
                        VarGeneral.DebLog.writeLog("Change Sal Status after Check:", error2, enable: true);
                    }
                    State = FormState.Saved;
                    dbInstance = null;
                    textBox_ID_TextChanged(sender, e);
                }
                else
                {
                    MessageBox.Show((LangArEn == 0) ? " يرجى حفظ البيانات العهدة قبل القيام بهذه العملية" : "Please save data", VarGeneral.ProdectNam);
                    try
                    {
                        switchButton_Sts.Value = data_this.IFState.Value;
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception error2)
            {
                VarGeneral.DebLog.writeLog("switchButton_Sts_ValueChanging:", error2, enable: true);
                MessageBox.Show(error2.Message);
            }
        }
        private void Fill_VacationBalance()
        {
            try
            {
                if (comboBox_EmpNo.Items.Count > 0)
                {
                    T_Emp listEmps = db.EmpsEmp(comboBox_EmpNo.SelectedValue.ToString());
                    if (!string.IsNullOrEmpty(listEmps.Emp_ID) && listEmps != null)
                    {
                        textBox_VacUsed.Value = db.ExecuteQuery<int>("select dbo.GetVacUsed('" + listEmps.Emp_ID + "')", new object[0]).FirstOrDefault();
                        textBox_VacTotaly.Value = listEmps.VacationBalance.Value + textBox_VacUsed.Value;
                        textBox_VacBalance.Value = listEmps.VacationBalance.Value;
                    }
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Fill_VacationBalance:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void comboBox_EmpNo_SelectedValueChanged(object sender, EventArgs e)
        {
            Fill_VacationBalance();
        }
        private void textbox_VacCountDay_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (State != FormState.Edit && State != FormState.New)
                {
                    return;
                }
                DateTime BeginDate = Convert.ToDateTime(dateTimeInput_StartDate.Text);
                if (textbox_VacCountDay.Value > 0)
                {
                    if (checkBox_VacAllowance.Checked)
                    {
                        int Ind = comboBox_CalculateNo.SelectedIndex;
                        comboBox_CalculateNo.SelectedIndex = -1;
                        comboBox_CalculateNo.SelectedIndex = Ind;
                    }
                    BeginDate = BeginDate.AddDays(textbox_VacCountDay.Value - 1);
                    dateTimeInput_EndDate.Text = BeginDate.ToString("yyyy/MM/dd");
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("textbox_VacCountDay_ValueChanged:", error, enable: true);
            }
        }
        private void comboBox_CalculateNo_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if ((State != FormState.New && State != FormState.Edit) || comboBox_CalculateNo.SelectedIndex == -1)
                {
                    return;
                }
                T_Emp newData = db.EmpsEmp(comboBox_EmpNo.SelectedValue.ToString());
                if (newData != null || newData.Emp_ID != "")
                {
                    if (comboBox_CalculateNo.SelectedIndex == 0)
                    {
                        textBox_Amount.Value = Math.Round(newData.MainSal.Value / (double)newData.DayOfMonth.Value * (double)textbox_VacCountDay.Value, 2);
                    }
                    else if (comboBox_CalculateNo.SelectedIndex == 1)
                    {
                        textBox_Amount.Value = Math.Round((newData.MainSal.Value + newData.HousingAllowance.Value / 12.0) / (double)newData.DayOfMonth.Value * (double)textbox_VacCountDay.Value, 2);
                    }
                    else if (comboBox_CalculateNo.SelectedIndex == 3)
                    {
                        textBox_Amount.Value = Math.Round((newData.MainSal.Value + newData.TransferAllowance.Value + newData.HousingAllowance.Value / 12.0) / (double)newData.DayOfMonth.Value * (double)textbox_VacCountDay.Value, 2);
                    }
                    else if (comboBox_CalculateNo.SelectedIndex == 4)
                    {
                        textBox_Amount.Value = Math.Round((newData.MainSal.Value + newData.SubsistenceAllowance.Value) / (double)newData.DayOfMonth.Value * (double)textbox_VacCountDay.Value, 2);
                    }
                    else if (comboBox_CalculateNo.SelectedIndex == 2)
                    {
                        double I = newData.MainSal.Value;
                        I = I + newData.TransferAllowance.Value + newData.SubsistenceAllowance.Value + newData.NaturalWorkAllowance.Value + newData.OtherAllowance.Value;
                        I += newData.HousingAllowance.Value / 12.0;
                        textBox_Amount.Value = Math.Round(I / (double)newData.DayOfMonth.Value * (double)textbox_VacCountDay.Value, 2);
                    }
                }
                if (checkBox_VacAllowance.Checked)
                {
                    textBox_Note.Text = ((LangArEn == 0) ? ("صرف له بدل  " + textBox_Amount.Value) : ("Taking Allownce " + textBox_Amount.Value));
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("comboBox_CalculateNo_SelectedValueChanged:", error, enable: true);
            }
        }
        private void dateTimeInput_StopSalFrom_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_StopSalFrom.Text = Convert.ToDateTime(dateTimeInput_StopSalFrom.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_StopSalFrom.Text = "";
            }
        }
        private void dateTimeInput_StartDate_Click(object sender, EventArgs e)
        {
            dateTimeInput_StartDate.SelectAll();
        }
        private void dateTimeInput_EndDate_Click(object sender, EventArgs e)
        {
            dateTimeInput_EndDate.SelectAll();
        }
        private void dateTimeInput_StopSalFrom_Click(object sender, EventArgs e)
        {
            dateTimeInput_StopSalFrom.SelectAll();
        }
        private void textBox_WithDateSal_Click(object sender, EventArgs e)
        {
            textBox_WithDateSal.SelectAll();
        }
        private void dateTimeInput_EndDate_Leave(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    dateTimeInput_StartDate.Text = Convert.ToDateTime(dateTimeInput_StartDate.Text).ToString("yyyy/MM/dd");
                }
                catch
                {
                    int? calendr = VarGeneral.Settings_Sys.Calendr;
                    if (calendr.Value == 0 && calendr.HasValue)
                    {
                        dateTimeInput_StartDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                        dateTimeInput_StopSalFrom.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                    }
                    else
                    {
                        dateTimeInput_StartDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                        dateTimeInput_StopSalFrom.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                    }
                }
                try
                {
                    dateTimeInput_EndDate.Text = Convert.ToDateTime(dateTimeInput_EndDate.Text).ToString("yyyy/MM/dd");
                }
                catch
                {
                    dateTimeInput_EndDate.Text = "";
                    textbox_VacCountDay.Value = 0;
                    return;
                }
                if (State == FormState.New || State == FormState.Edit)
                {
                    DateTime d1 = Convert.ToDateTime(dateTimeInput_EndDate.Text);
                    DateTime d2 = Convert.ToDateTime(dateTimeInput_StartDate.Text);
                    int t = d1.Subtract(d2).Days + 1;
                    textbox_VacCountDay.Value = t;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("dateTimeInput_EndDate_Leave:", error, enable: true);
            }
        }
        private void dateTimeInput_StartDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (State != FormState.Edit && State != FormState.New)
                {
                    return;
                }
                try
                {
                    dateTimeInput_StartDate.Text = Convert.ToDateTime(dateTimeInput_StartDate.Text).ToString("yyyy/MM/dd");
                }
                catch
                {
                    int? calendr = VarGeneral.Settings_Sys.Calendr;
                    if (calendr.Value == 0 && calendr.HasValue)
                    {
                        dateTimeInput_StartDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                        dateTimeInput_StopSalFrom.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
                    }
                    else
                    {
                        dateTimeInput_StartDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                        dateTimeInput_StopSalFrom.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
                    }
                }
                dateTimeInput_StopSalFrom.Text = Convert.ToDateTime(dateTimeInput_StartDate.Text).ToString("yyyy/MM/dd");
                try
                {
                    dateTimeInput_EndDate.Text = Convert.ToDateTime(dateTimeInput_EndDate.Text).ToString("yyyy/MM/dd");
                }
                catch
                {
                    dateTimeInput_EndDate.Text = "";
                    return;
                }
                if (State == FormState.New || State == FormState.Edit)
                {
                    DateTime d1 = Convert.ToDateTime(dateTimeInput_EndDate.Text);
                    DateTime d2 = Convert.ToDateTime(dateTimeInput_StartDate.Text);
                    int t = d1.Subtract(d2).Days + 1;
                    textbox_VacCountDay.Value = t;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("dateTimeInput_StartDate_Leave:", error, enable: true);
            }
        }
        private void checkBox_VacAllowance_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Button_Edit_Click(sender, e);
                if (checkBox_VacAllowance.Checked)
                {
                    try
                    {
                        comboBox_CalculateNo.SelectedIndex = 0;
                    }
                    catch
                    {
                        comboBox_CalculateNo.SelectedIndex = -1;
                    }
                    if (int.Parse(Convert.ToDateTime(dateTimeInput_StartDate.Text).ToString("yyyy/MM/dd").Substring(5, 2)) == 1)
                    {
                        textBox_WithDateSal.Text = Convert.ToDateTime("12/" + (int.Parse(Convert.ToDateTime(dateTimeInput_StartDate.Text).ToString("yyyy/MM/dd").Substring(0, 4)) - 1)).ToString("yyyy/MM");
                    }
                    else
                    {
                        textBox_WithDateSal.Text = Convert.ToDateTime(int.Parse(Convert.ToDateTime(dateTimeInput_StartDate.Text).ToString("yyyy/MM/dd").Substring(5, 2)) - 1 + "/" + Convert.ToDateTime(dateTimeInput_StartDate.Text).ToString("yyyy/MM/dd").Substring(0, 4)).ToString("yyyy/MM");
                    }
                    panel3.Enabled = true;
                    textBox_WithDateSal.Enabled = true;
                    textBox_Amount.Enabled = true;
                }
                else
                {
                    try
                    {
                        comboBox_CalculateNo.SelectedIndex = -1;
                    }
                    catch
                    {
                    }
                    textBox_Amount.Value = 0.0;
                    textBox_WithDateSal.Text = "";
                    textBox_Note.Text = "";
                    panel3.Enabled = false;
                    textBox_WithDateSal.Enabled = false;
                    textBox_Amount.Enabled = false;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("checkBox_VacAllowance_CheckedChanged:", error, enable: true);
            }
        }
        private void textBox_WithDateSal_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(textBox_WithDateSal.Text))
                {
                    textBox_WithDateSal.Text = Convert.ToDateTime(textBox_WithDateSal.Text).ToString("yyyy/MM");
                    return;
                }
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                if (calendr.Value == 0 && calendr.HasValue)
                {
                    textBox_WithDateSal.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM");
                }
                else
                {
                    textBox_WithDateSal.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM");
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("textBox_WithDateSal_Leave:", error, enable: true);
            }
        }
        private void Button_PrintTable_Click(object sender, EventArgs e)
        {
            VarGeneral.IsGeneralUsed = true;
            FrmReportsViewer frm = new FrmReportsViewer();
            frm.Repvalue = "VacRep";
            frm.Tag = LangArEn;
            frm.Repvalue = "VacRep";
            VarGeneral.vTitle = Text;
            frm.SqlWhere = "";
            frm.TopMost = true;
            frm.ShowDialog();
            VarGeneral.IsGeneralUsed = false;
        }
        private void switchButton_Lock_Click(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }
        private void button_SrchEmpCover_Click(object sender, EventArgs e)
        {
            if (!comboBox_EmpNoCover.Enabled)
            {
                return;
            }
            try
            {
                Dir_ButSearch.Clear();
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
                    Button_Edit_Click(sender, e);
                    frm.Serach_No = db.EmpsEmpNo(frm.Serach_No).Emp_ID;
                    comboBox_EmpNoCover.SelectedValue = frm.SerachNo;
                }
                Dir_ButSearch.Clear();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_SrchEmp_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void switchButton_Lock_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!VarGeneral.TString.ChkStatShow(permission.Emp_GenStr, 12))
                {
                    comboBox_EmpNoCover.Enabled = false;
                }
                else
                {
                    comboBox_EmpNoCover.Enabled = switchButton_Lock.Value;
                }
            }
            catch
            {
                comboBox_EmpNoCover.Enabled = false;
            }
        }
    }
}
