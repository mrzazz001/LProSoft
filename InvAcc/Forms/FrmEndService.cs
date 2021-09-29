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
    public partial  class FrmEndService : Form
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
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private ScriptNumber ScriptNumber1 = new ScriptNumber();
        private T_AccDef _AccDefBind = new T_AccDef();
        private int LangArEn = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
#pragma warning disable CS0414 // The field 'FrmEndService.FlagUpdate' is assigned but its value is never used
        private string FlagUpdate = "";
#pragma warning restore CS0414 // The field 'FrmEndService.FlagUpdate' is assigned but its value is never used
        private double gPeriode = 0.0;
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private T_EndService data_this;
        private T_Attend Data_this_Attend;
        private T_Salary data_this_salary;
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
        private Dictionary<string, ColumnDictinary> Dir_ButSearch = new Dictionary<string, ColumnDictinary>();
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
                        frm.Repvalue = "EndServiceRep";
                        frm.Repvalue = "EndServiceRep";
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
        private MaskedTextBox dateTimeInput_DateAppointment;
        private Label label_lblDaysOfMonth;
        private DoubleInput textBox_Salary;
        private ComboBoxEx comboBox_EmpNo;
        private ButtonX button_SrchEmp;
        private Label label12;
        private MaskedTextBox dateTimeInput_warnDate;
        private Label label54;
        protected TextBox textBox_ID;
        protected Label label38;
        private IntegerInput textBox_Years;
        private IntegerInput textBox_Months;
        private IntegerInput textBox_Days;
        private Label label15;
        private Label label14;
        private Label label1;
        private MaskedTextBox dateTimeInput_LastFilter;
        private Label label10;
        private MaskedTextBox dateTimeInput_DateFilter;
        private Label label13;
        private ComboBoxEx comboBox_CauseLiquidation;
        private ButtonX button_SrchCauseLiquidation;
        private Label label2;
        private DevComponents.DotNetBar.TabControl tabControl1;
        private TabControlPanel tabControlPanel2;
        private TabItem tabItem2;
        private TabControlPanel tabControlPanel3;
        private IntegerInput textBox_VacDayCount;
        private DoubleInput textBox_VacUsed;
        private DoubleInput textBox_VacAcout;
        private DoubleInput textBox_VacBalance;
        private DoubleInput textBox_VacTotal;
        private Label label16;
        private Label label11;
        private Label label9;
        private Label label8;
        private Label label4;
        private Label label5;
        private TabItem tabItem3;
        private TabControlPanel tabControlPanel5;
        private DoubleInput textBox_WagesTotal;
        private TextBox textBox_WagesDetails;
        private Label label48;
        private TabItem tabItem5;
        private TabControlPanel tabControlPanel1;
        private DoubleInput textBox_Paid;
        private DoubleInput textBox_ValueAdvances;
        private DoubleInput textBox_Remaining;
        private Label label27;
        private Label label28;
        private Label label29;
        private TabItem tabItem1;
        private TabControlPanel tabControlPanel4;
        private DoubleInput textBox_TicketValue;
        private DoubleInput textBox_TicketUsed;
        private DoubleInput textBox_Tickets;
        private DoubleInput textBox_TicketBalance;
        private DoubleInput textBox_TicketCount;
        private DoubleInput textBox_TicketTotal;
        private Label label25;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private Label label21;
        private Label label22;
        private TabItem tabItem4;
        private DoubleInput textBox_ETickitValue;
        private DoubleInput textBox_EWagesValue;
        private DoubleInput textBox_ETotal;
        private DoubleInput textBox_EndServiceValue;
        private DoubleInput textBox_EAdvancValue;
        private DoubleInput textBox_EVacValue;
        private Label label52;
        private Label label53;
        private Label label49;
        private Label label51;
        private GroupPanel groupPanel1;
        private Label label6;
        private Label label50;
        private GroupBox groupBox1;
        private SwitchButton switchButton_Sts;
        private TextBox textBox_EmpNo;
        private MaskedTextBox dateTimeInput_ExclusionDate;
        private TextBox textBox_Note;
        private Label label7;
        private IntegerInput textBox_MoreWorth;
        private IntegerInput textBox_LessMoreWorth;
        private IntegerInput textBox_AndLess;
        private IntegerInput textBox_LessWorth;
        private IntegerInput textBox_ServMoreOnly;
        private IntegerInput textBox_ServMore;
        private IntegerInput textBox_ServLess;
        private DoubleInput textBox_GenTotal;
        private Label label23;
        private Label label24;
        private Label label30;
        private Label label31;
        private Label label32;
        private Label label33;
        private Label label35;
        private Label label36;
        private Label label3;
        private Label label39;
        private Label label40;
        private Label label41;
        private Label label42;
        private Label label43;
        private Label label44;
        private Label label45;
        private Label label46;
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
        public T_EndService DataThis
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
        public T_Attend Datathis_Attend
        {
            get
            {
                return Data_this_Attend;
            }
            set
            {
                Data_this_Attend = value;
            }
        }
        public T_Salary Datathis_salary
        {
            get
            {
                return data_this_salary;
            }
            set
            {
                data_this_salary = value;
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
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_MovStr, 41))
                    {
                        IfAdd = false;
                    }
                    else
                    {
                        IfAdd = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_MovStr, 42) || switchButton_Sts.Value)
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_MovStr, 43) || switchButton_Sts.Value)
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
            VarGeneral.SFrmTyp = "T_EndService";
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
            List<T_EndService> list = db.FillEndService_2(textBox_search.TextBox.Text).ToList();
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
        }
        public void FillHDGV(IEnumerable<T_EndService> new_data_enum)
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
            DGV_Main.PrimaryGrid.DataMember = "T_EndService";
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
            List<T_LiquidationTyp> listLiquidationTyp = new List<T_LiquidationTyp>(db.T_LiquidationTyps.Select((T_LiquidationTyp item) => item).ToList());
            comboBox_CauseLiquidation.DataSource = null;
            comboBox_CauseLiquidation.DataSource = listLiquidationTyp;
            comboBox_CauseLiquidation.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_CauseLiquidation.ValueMember = "LiquidationT_No";
            comboBox_EmpNo.SelectedValueChanged -= comboBox_EmpNo_SelectedValueChanged;
            List<T_Emp> listEmps = new List<T_Emp>(db.T_Emps.Select((T_Emp item) => item).ToList());
            comboBox_EmpNo.DataSource = null;
            comboBox_EmpNo.DataSource = listEmps;
            comboBox_EmpNo.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_EmpNo.ValueMember = "Emp_ID";
            comboBox_EmpNo.SelectedValueChanged += comboBox_EmpNo_SelectedValueChanged;
            comboBox_CauseLiquidation.SelectedIndex = -1;
            comboBox_EmpNo.SelectedIndex = -1;
        }
        public void Clear()
        {
            if (State == FormState.New)
            {
                return;
            }
            State = FormState.New;
            data_this = new T_EndService();
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
                            (controls[i] as ComboBox).SelectedIndex = -1;
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
                            (controls[i] as ComboBoxEx).SelectedIndex = -1;
                        }
                        catch
                        {
                            (controls[i] as ComboBoxEx).SelectedIndex = -1;
                        }
                    }
                }
            }
            Guid id = Guid.NewGuid();
            textBox_ID.Tag = id.ToString();
            switchButton_Sts.Value = false;
            calendr = VarGeneral.Settings_Sys.Calendr;
            if (calendr.Value == 0 && calendr.HasValue)
            {
                dateTimeInput_warnDate.Text = Convert.ToDateTime(VarGeneral.Gdate).ToString("yyyy/MM/dd");
            }
            else
            {
                dateTimeInput_warnDate.Text = Convert.ToDateTime(VarGeneral.Hdate).ToString("yyyy/MM/dd");
            }
            comboBox_EmpNo.SelectedValueChanged -= comboBox_EmpNo_SelectedValueChanged;
            comboBox_EmpNo.DataSource = null;
            List<T_Emp> listEmps = new List<T_Emp>(db.T_Emps.Where((T_Emp item) => item.EmpState == (bool?)true).ToList());
            comboBox_EmpNo.DataSource = listEmps;
            comboBox_EmpNo.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_EmpNo.ValueMember = "Emp_ID";
            comboBox_EmpNo.SelectedIndex = -1;
            comboBox_EmpNo.SelectedValueChanged += comboBox_EmpNo_SelectedValueChanged;
            List<T_EndService> q = db.FillEndService_2("").ToList();
            if (q.Count > 0)
            {
                T_EndService newData = q.Last();
                textBox_ServLess.Value = newData.ServLess.Value;
                textBox_LessWorth.Value = newData.LessWorth.Value;
                textBox_ServMore.Value = newData.ServMore.Value;
                textBox_AndLess.Value = newData.AndLess.Value;
                textBox_LessMoreWorth.Value = newData.LessMoreWorth.Value;
                textBox_ServMoreOnly.Value = newData.ServMoreOnly.Value;
                textBox_MoreWorth.Value = newData.MoreWorth.Value;
            }
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
            var qkeys = db.T_EndServices.Select((T_EndService item) => new
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
        public FrmEndService()
        {
            InitializeComponent();this.Load += langloads;
            textBox_ID.KeyPress += textBox_ID_KeyPress;
            Button_Close.Click += Button_Close_Click;
            textBox_Note.Click += Button_Edit_Click;
            dateTimeInput_warnDate.Click += Button_Edit_Click;
            comboBox_EmpNo.Click += Button_Edit_Click;
            comboBox_CauseLiquidation.Click += Button_Edit_Click;
            dateTimeInput_DateFilter.Click += Button_Edit_Click;
            dateTimeInput_ExclusionDate.Click += Button_Edit_Click;
            textBox_ServLess.Click += Button_Edit_Click;
            textBox_LessWorth.Click += Button_Edit_Click;
            textBox_AndLess.Click += Button_Edit_Click;
            textBox_LessMoreWorth.Click += Button_Edit_Click;
            textBox_MoreWorth.Click += Button_Edit_Click;
            textBox_ETickitValue.Click += Button_Edit_Click;
            textBox_Note.Click += Button_Edit_Click;
            dateTimeInput_DateFilter.Leave += dateTimeInput_DateFilter_Leave;
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmEndService));
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
                label38.Text = "الكـــــــــــود :";
                Text = "كرت نهاية الخدمــة";
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
                Text = "Rewards Card";
            }
            tabItem2.Text = ((LangArEn == 0) ? "نهاية الخدمة" : "End Service");
            tabItem3.Text = ((LangArEn == 0) ? "اجازات الموظف" : "Vacations");
            tabItem4.Text = ((LangArEn == 0) ? "تذاكر الموظف" : "Tickits");
            tabItem1.Text = ((LangArEn == 0) ? "سلف الموظف" : "Loans");
            tabItem5.Text = ((LangArEn == 0) ? "أجور الموظف" : "Salary");
        }
        private void FrmEndService_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmEndService));
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
                    columns_Names_visible.Add("warnNo", new ColumnDictinary("رقم الأمر", "Order No", ifDefault: false, ""));
                    columns_Names_visible.Add("Emp_No", new ColumnDictinary("رقم الموظف", "Employee No", ifDefault: false, ""));
                    columns_Names_visible.Add("EmpNm", new ColumnDictinary("اسم الموظف", "Employee Name", ifDefault: false, ""));
                    columns_Names_visible.Add("DateAppointment", new ColumnDictinary("تاريخ التعيين", "Appointment Date", ifDefault: true, ""));
                    columns_Names_visible.Add("DateFilter", new ColumnDictinary("تاريخ التصفية", "Main Salary", ifDefault: true, ""));
                    columns_Names_visible.Add("Years", new ColumnDictinary("عدد السنين", "Bank Code", ifDefault: true, ""));
                    columns_Names_visible.Add("Months", new ColumnDictinary("عدد الشهور", "Account ID", ifDefault: true, ""));
                    columns_Names_visible.Add("Days", new ColumnDictinary("عدد الأيام", "ID No", ifDefault: true, ""));
                    columns_Names_visible.Add("MainSal", new ColumnDictinary("الراتب", "Main Salary", ifDefault: true, ""));
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
            switchButton_Sts.ValueChanging -= switchButton_Sts_ValueChanging;
            try
            {
                T_EndService newData = db.EmpsEndService(no);
                if (newData == null || newData.warnNo == 0 || string.IsNullOrEmpty(newData.EndService_ID))
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
            }
            catch
            {
            }
            switchButton_Sts.ValueChanging += switchButton_Sts_ValueChanging;
            UpdateVcr();
        }
        public void SetData(T_EndService value)
        {
            State = FormState.Saved;
            Button_Save.Enabled = false;
            switchButton_Sts.IsReadOnly = false;
            textBox_AndLess.Value = value.AndLess.Value;
            textBox_Days.Value = value.Days.Value;
            textBox_EAdvancValue.Value = value.EAdvancesRemainning.Value;
            textBox_EndServiceValue.Value = value.eEndServisValue.Value;
            textBox_EWagesValue.Value = value.EWagesValue.Value;
            textBox_GenTotal.Value = value.GenTotal.Value;
            textBox_LessMoreWorth.Value = value.LessMoreWorth.Value;
            textBox_LessWorth.Value = value.LessWorth.Value;
            textBox_Months.Value = value.Months.Value;
            textBox_MoreWorth.Value = value.MoreWorth.Value;
            textBox_Note.Text = value.Note;
            textBox_Paid.Value = value.Paid.Value;
            textBox_Remaining.Value = value.Remaining.Value;
            textBox_Salary.Value = value.Salary.Value;
            textBox_ServLess.Value = value.ServLess.Value;
            textBox_ServMore.Value = value.ServMore.Value;
            textBox_ServMoreOnly.Value = value.ServMoreOnly.Value;
            textBox_TicketBalance.Value = value.TicketBalance.Value;
            textBox_TicketCount.Value = value.TicketCount.Value;
            textBox_Tickets.Value = value.TicketCount.Value;
            textBox_TicketUsed.Value = value.TicketUsed.Value;
            textBox_TicketValue.Value = value.TicketValue.Value;
            textBox_VacAcout.Value = value.VacAcout.Value;
            textBox_VacBalance.Value = value.VacBalance.Value;
            textBox_VacDayCount.Value = value.VacDayCount.Value;
            textBox_VacUsed.Value = textBox_VacUsed.Value;
            textBox_VacTotal.Value = value.VacTotal.Value;
            textBox_ValueAdvances.Value = value.ValueAdvances.Value;
            textBox_TicketTotal.Value = value.TicketTotal.Value;
            textBox_EVacValue.Value = value.TicketTotal.Value;
            textBox_WagesDetails.Text = value.WagesDetails;
            textBox_WagesTotal.Value = value.EWagesValue.Value;
            textBox_Years.Value = value.Years.Value;
            textBox_Salary.Value = value.Salary.Value;
            dateTimeInput_DateAppointment.Text = value.DateAppointment;
            if (VarGeneral.CheckDate(value.LastFilter))
            {
                dateTimeInput_LastFilter.Text = value.LastFilter;
            }
            if (value.CauseLiquidation.HasValue)
            {
                comboBox_CauseLiquidation.SelectedValue = value.CauseLiquidation.Value;
            }
            if (!string.IsNullOrEmpty(value.EmpID))
            {
                comboBox_EmpNo.SelectedValue = value.EmpID;
            }
            try
            {
                if (VarGeneral.CheckDate(value.DateFilter))
                {
                    dateTimeInput_DateFilter.Text = Convert.ToDateTime(value.DateFilter).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_DateFilter.Text = "";
                }
            }
            catch
            {
                dateTimeInput_DateFilter.Text = "";
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
            try
            {
                if (VarGeneral.CheckDate(value.T_Emp.ExclusionDate))
                {
                    dateTimeInput_ExclusionDate.Text = Convert.ToDateTime(value.T_Emp.ExclusionDate).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_ExclusionDate.Text = "";
                }
            }
            catch
            {
                dateTimeInput_ExclusionDate.Text = "";
            }
            if (textBox_VacBalance.Value > 0.0)
            {
                textBox_VacTotal.Value = Math.Round(textBox_Salary.Value * textBox_VacBalance.Value / 30.0, 2);
                textBox_EVacValue.Value = Math.Round(textBox_Salary.Value * textBox_VacBalance.Value / 30.0, 2);
            }
            else
            {
                textBox_VacTotal.Value = 0.0;
                textBox_EVacValue.Value = 0.0;
            }
            textBox_ETotal.Value = Math.Round(textBox_EndServiceValue.Value + textBox_EVacValue.Value - textBox_EAdvancValue.Value + textBox_ETickitValue.Value + textBox_EWagesValue.Value, 2);
            if (value.IFState.HasValue)
            {
                switchButton_Sts.Value = value.IFState.Value;
            }
            else
            {
                switchButton_Sts.Value = false;
            }
            textBox_ETickitValue.LockUpdateChecked = value.ISCalculatTicketVal.Value;
            textBox_EmpNo.Text = db.EmpsEmp(comboBox_EmpNo.SelectedValue.ToString()).Emp_No;
            dateTimeFilterLeave();
            Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
            SetReadOnly = true;
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
        private T_EndService GetData()
        {
            textBox_ID.Focus();
            try
            {
                data_this.warnNo = int.Parse(textBox_ID.Text);
            }
            catch
            {
            }
            try
            {
                data_this.EmpID = comboBox_EmpNo.SelectedValue.ToString();
            }
            catch
            {
            }
            try
            {
                data_this.AndLess = textBox_AndLess.Value;
            }
            catch
            {
            }
            try
            {
                data_this.CauseLiquidation = int.Parse(comboBox_CauseLiquidation.SelectedValue.ToString());
            }
            catch
            {
                data_this.CauseLiquidation = null;
            }
            try
            {
                data_this.DateFilter = Convert.ToDateTime(dateTimeInput_DateFilter.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_DateFilter.Text = "";
                data_this.DateFilter = "";
            }
            try
            {
                data_this.Days = textBox_Days.Value;
            }
            catch
            {
            }
            try
            {
                data_this.Months = textBox_Months.Value;
            }
            catch
            {
            }
            try
            {
                data_this.Years = textBox_Years.Value;
            }
            catch
            {
            }
            try
            {
                data_this.EAdvancesRemainning = textBox_EAdvancValue.Value;
            }
            catch
            {
            }
            try
            {
                data_this.eEndServisValue = textBox_EndServiceValue.Value;
            }
            catch
            {
            }
            try
            {
                data_this.EWagesValue = textBox_EWagesValue.Value;
            }
            catch
            {
            }
            try
            {
                data_this.GenTotal = textBox_GenTotal.Value;
            }
            catch
            {
                data_this.GenTotal = 0.0;
            }
            try
            {
                data_this.ISCalculatTicketVal = textBox_ETickitValue.LockUpdateChecked;
            }
            catch
            {
            }
            try
            {
                data_this.LastFilter = Convert.ToDateTime(dateTimeInput_LastFilter.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_LastFilter.Text = "";
                data_this.LastFilter = "";
            }
            try
            {
                data_this.LessMoreWorth = textBox_LessMoreWorth.Value;
            }
            catch
            {
                data_this.LessMoreWorth = 0;
            }
            try
            {
                data_this.LessWorth = textBox_LessWorth.Value;
            }
            catch
            {
                data_this.LessWorth = 0;
            }
            try
            {
                data_this.MoreWorth = textBox_MoreWorth.Value;
            }
            catch
            {
                data_this.MoreWorth = 0;
            }
            try
            {
                data_this.Note = textBox_Note.Text;
            }
            catch
            {
                data_this.Note = "";
            }
            try
            {
                data_this.Paid = textBox_Paid.Value;
            }
            catch
            {
            }
            try
            {
                data_this.Remaining = textBox_Remaining.Value;
            }
            catch
            {
            }
            try
            {
                data_this.Salary = textBox_Salary.Value;
            }
            catch
            {
            }
            try
            {
                data_this.ServLess = textBox_ServLess.Value;
            }
            catch
            {
                data_this.ServLess = 0;
            }
            try
            {
                data_this.ServMore = textBox_ServMore.Value;
            }
            catch
            {
            }
            try
            {
                data_this.ServMoreOnly = textBox_ServMoreOnly.Value;
            }
            catch
            {
            }
            try
            {
                data_this.TicketBalance = textBox_TicketBalance.Value;
            }
            catch
            {
                data_this.TicketBalance = 0.0;
            }
            try
            {
                data_this.TicketCount = textBox_TicketCount.Value;
            }
            catch
            {
            }
            try
            {
                data_this.Tickets = textBox_Tickets.Value;
            }
            catch
            {
                data_this.Tickets = 0.0;
            }
            try
            {
                data_this.TicketUsed = textBox_TicketUsed.Value;
            }
            catch
            {
                data_this.TicketUsed = 0.0;
            }
            try
            {
                data_this.TicketValue = textBox_TicketValue.Value;
            }
            catch
            {
                data_this.TicketValue = 0.0;
            }
            try
            {
                data_this.TicketTotal = textBox_TicketTotal.Value;
            }
            catch
            {
                data_this.TicketTotal = 0.0;
            }
            try
            {
                data_this.VacAcout = textBox_VacAcout.Value;
            }
            catch
            {
                data_this.VacAcout = 0.0;
            }
            try
            {
                data_this.VacBalance = textBox_VacBalance.Value;
            }
            catch
            {
            }
            try
            {
                data_this.VacDayCount = textBox_VacDayCount.Value;
            }
            catch
            {
            }
            try
            {
                data_this.VacUsed = textBox_VacUsed.Value;
            }
            catch
            {
            }
            try
            {
                data_this.VacTotal = textBox_VacTotal.Value;
            }
            catch
            {
            }
            try
            {
                data_this.ValueAdvances = textBox_ValueAdvances.Value;
            }
            catch
            {
            }
            try
            {
                data_this.WagesDetails = textBox_WagesDetails.Text;
            }
            catch
            {
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
                data_this.IFState = switchButton_Sts.Value;
            }
            catch
            {
                data_this.IFState = false;
            }
            try
            {
                data_this.DateAppointment = Convert.ToDateTime(dateTimeInput_DateAppointment.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_DateAppointment.Text = "";
                data_this.DateAppointment = "";
            }
            try
            {
                data_this.Salary = textBox_Salary.Value;
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
                max = db.MaxEndServiceNo;
                textBox_ID.Text = max.ToString();
                Clear();
                State = FormState.New;
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
                        data_this.EndService_ID = textBox_ID.Tag.ToString();
                        db.T_EndServices.InsertOnSubmit(data_this);
                        db.SubmitChanges();
                        comboBox_EmpNo.SelectedValueChanged -= comboBox_EmpNo_SelectedValueChanged;
                        FillCombo();
                        comboBox_EmpNo.SelectedValueChanged += comboBox_EmpNo_SelectedValueChanged;
                    }
                    catch (SqlException error2)
                    {
                        int max = 0;
                        max = db.MaxEndServiceNo;
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
                    GetData();
                    db.Log = VarGeneral.DebugLog;
                    db.SubmitChanges(ConflictMode.ContinueOnConflict);
                }
                if (VarGeneral.CheckDate(dateTimeInput_ExclusionDate.Text))
                {
                    try
                    {
                        db.ExecuteCommand("UPDATE [T_Emp] SET T_Emp.ExclusionDate = '" + Convert.ToDateTime(dateTimeInput_ExclusionDate.Text).ToString("yyyy/MM/dd") + "' WHERE T_Emp.Emp_ID = '" + data_this.EmpID + "'");
                    }
                    catch
                    {
                        db.ExecuteCommand("UPDATE [T_Emp] SET T_Emp.ExclusionDate = '' WHERE T_Emp.Emp_ID = '" + data_this.EmpID + "'");
                    }
                }
                else
                {
                    db.ExecuteCommand("UPDATE [T_Emp] SET T_Emp.ExclusionDate = '' WHERE T_Emp.Emp_ID = '" + data_this.EmpID + "'");
                }
                State = FormState.Saved;
                RefreshPKeys();
                dbInstance = null;
                textBox_ID_TextChanged(sender, e);
                TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(string.Concat(data_this.warnNo)) + 1);
                SetReadOnly = true;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Button_Save_Click:", error, enable: true);
                MessageBox.Show(error.Message);
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
                if (data_this != null && data_this.warnNo != 0 && !string.IsNullOrEmpty(data_this.EndService_ID) && ifOkDelete)
                {
                    data_this = db.EmpsEndService(DataThis.warnNo);
                    db.T_EndServices.DeleteOnSubmit(DataThis);
                    db.SubmitChanges();
                    Clear();
                    RefreshPKeys();
                    textBox_ID.Text = PKeys.LastOrDefault();
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Button_Delete_Click:", error, enable: true);
                MessageBox.Show(error.Message);
                DataThis = db.EmpsEndService(DataThis.warnNo);
            }
        }
        private void DGV_Main_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            string dataMember = panel.DataMember;
            if (dataMember != null && dataMember == "T_EndService")
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
            panel.Columns["DateFilter"].Width = 120;
            panel.Columns["DateFilter"].Visible = columns_Names_visible["DateFilter"].IfDefault;
            panel.Columns["Emp_No"].Width = 120;
            panel.Columns["Emp_No"].Visible = columns_Names_visible["Emp_No"].IfDefault;
            panel.Columns["EmpNm"].Width = 250;
            panel.Columns["EmpNm"].Visible = columns_Names_visible["EmpNm"].IfDefault;
            panel.Columns["DateAppointment"].Width = 100;
            panel.Columns["DateAppointment"].Visible = columns_Names_visible["DateAppointment"].IfDefault;
            panel.Columns["Years"].Width = 100;
            panel.Columns["Years"].Visible = columns_Names_visible["Years"].IfDefault;
            panel.Columns["Months"].Width = 100;
            panel.Columns["Months"].Visible = columns_Names_visible["Months"].IfDefault;
            panel.Columns["Days"].Width = 100;
            panel.Columns["Days"].Visible = columns_Names_visible["Days"].IfDefault;
            panel.Columns["MainSal"].Width = 150;
            panel.Columns["MainSal"].Visible = columns_Names_visible["MainSal"].IfDefault;
            panel.ReadOnly = true;
        }
        private void DGV_MainGetCellStyle(object sender, GridGetCellStyleEventArgs e)
        {
        }
        private void Button_ExportTable2_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcel.ExportToExcel(DGV_Main, "تقرير نهاية الخدمة");
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
        private void ADD_Controls()
        {
            try
            {
                controls = new List<Control>();
                controls.Add(textBox_ID);
                codeControl = textBox_ID;
                controls.Add(textBox_AndLess);
                controls.Add(textBox_Days);
                controls.Add(textBox_EAdvancValue);
                controls.Add(textBox_EndServiceValue);
                controls.Add(textBox_EWagesValue);
                controls.Add(textBox_ETickitValue);
                controls.Add(textBox_ETotal);
                controls.Add(textBox_EVacValue);
                controls.Add(textBox_GenTotal);
                controls.Add(textBox_LessMoreWorth);
                controls.Add(textBox_LessWorth);
                controls.Add(textBox_Months);
                controls.Add(textBox_MoreWorth);
                controls.Add(textBox_Note);
                controls.Add(textBox_Paid);
                controls.Add(textBox_Remaining);
                controls.Add(textBox_Salary);
                controls.Add(textBox_ServLess);
                controls.Add(textBox_ServMore);
                controls.Add(textBox_ServMoreOnly);
                controls.Add(textBox_TicketBalance);
                controls.Add(textBox_TicketCount);
                controls.Add(textBox_TicketTotal);
                controls.Add(textBox_Tickets);
                controls.Add(textBox_TicketUsed);
                controls.Add(textBox_TicketValue);
                controls.Add(textBox_VacAcout);
                controls.Add(textBox_VacBalance);
                controls.Add(textBox_VacDayCount);
                controls.Add(textBox_VacTotal);
                controls.Add(textBox_VacUsed);
                controls.Add(textBox_ValueAdvances);
                controls.Add(textBox_WagesDetails);
                controls.Add(textBox_WagesTotal);
                controls.Add(textBox_ID);
                controls.Add(textBox_Years);
                controls.Add(comboBox_CauseLiquidation);
                controls.Add(comboBox_EmpNo);
                controls.Add(dateTimeInput_DateAppointment);
                controls.Add(dateTimeInput_DateFilter);
                controls.Add(dateTimeInput_ExclusionDate);
                controls.Add(dateTimeInput_LastFilter);
                controls.Add(dateTimeInput_warnDate);
                controls.Add(switchButton_Sts);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("ADD_Controls:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void textBox_SalDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(dateTimeInput_DateAppointment.Text))
                {
                    dateTimeInput_DateAppointment.Text = Convert.ToDateTime(dateTimeInput_DateAppointment.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    dateTimeInput_DateAppointment.Text = "";
                }
            }
            catch
            {
                dateTimeInput_DateAppointment.Text = "";
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
                if (textBox_EmpNo.Text == "" || comboBox_EmpNo.SelectedIndex == -1)
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب تحديد موظف" : "Most Select Employee", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_EmpNo.Focus();
                    return false;
                }
                if (dateTimeInput_warnDate.Text.Length != 10 || !VarGeneral.CheckDate(dateTimeInput_warnDate.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب تحديد التاريخ " : "You must specify the date", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    dateTimeInput_warnDate.Focus();
                    return false;
                }
                T_EndService q = db.EmpsEndService(int.Parse(textBox_ID.Text));
                if (!string.IsNullOrEmpty(q.EndService_ID) && State == FormState.New)
                {
                    MessageBox.Show((LangArEn == 0) ? " الرقم  موجود من قبل" : " No It's a existing", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_ID.Focus();
                    return false;
                }
                if (dateTimeInput_DateFilter.Text.Length != 10 || !VarGeneral.CheckDate(dateTimeInput_DateFilter.Text))
                {
                    MessageBox.Show((LangArEn == 0) ? " يجب تحديد تاريخ التصفية" : "Most Enter Settlement", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_EmpNo.Focus();
                    return false;
                }
                if (comboBox_CauseLiquidation.SelectedIndex == -1)
                {
                    MessageBox.Show((LangArEn == 0) ? " يجب تحديد سبب التصفية" : "Most select Settlement Type", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_EmpNo.Focus();
                    return false;
                }
                try
                {
                    string dt = (VarGeneral.CheckDate(dateTimeInput_LastFilter.Text) ? Convert.ToDateTime(dateTimeInput_LastFilter.Text).ToString("yyyy/MM/dd") : Convert.ToDateTime(dateTimeInput_DateAppointment.Text).ToString("yyyy/MM/dd"));
                    if (Convert.ToDateTime(dateTimeInput_DateFilter.Text) < Convert.ToDateTime(dt))
                    {
                        MessageBox.Show("يجب ان يكون تاريخ التصفية اكبر من تاريخ التعيين", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
                catch
                {
                    MessageBox.Show("يجب ان يكون تاريخ التصفية اكبر من تاريخ التعيين", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dateTimeInput_DateFilter.Focus();
                    return false;
                }
                if (!db.SelectSecretariatNoByReturnNo(comboBox_EmpNo.SelectedValue.ToString()))
                {
                    MessageBox.Show((LangArEn == 0) ? " يجب ان لا يكون عند الموظف اي عهدة .. الرجاء التأكد من عهد الموظف" : " Can not save .. because this is in the custody of the Secretariat of the employee does not have to hand over", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                string BDate = ((!VarGeneral.CheckDate(dateTimeInput_LastFilter.Text)) ? Convert.ToDateTime(dateTimeInput_DateAppointment.Text).ToString("yyyy/MM/dd") : Convert.ToDateTime(dateTimeInput_LastFilter.Text).ToString("yyyy/MM/dd"));
                string quary = "SELECT * FROM T_VacTyp INNER JOIN T_Vacation ON T_VacTyp.[VacT_No] = T_Vacation.VacTyp WHERE T_Vacation.EmpID ='" + comboBox_EmpNo.SelectedValue.ToString() + "' AND T_VacTyp.Dis_VacT = 1 AND T_Vacation.AdminLock = 0 AND (T_Vacation.StartDate >= '" + Convert.ToDateTime(BDate).ToString("yyyy/MM/dd") + "' AND T_Vacation.EndDate <= '" + Convert.ToDateTime(dateTimeInput_DateFilter.Text).ToString("yyyy/MM/dd") + "')";
                List<T_Vacation> newData = db.ExecuteQuery<T_Vacation>(quary, new object[0]).ToList();
                try
                {
                    if (newData.Count > 0)
                    {
                        MessageBox.Show((LangArEn == 0) ? " هناك اجازات لهذا الموظف معلقة خلال الفترة التي تريد تصفيتها .. \n يرجى الغائها او الموافقة عليها ثم المحاولة مجددا" : "There are vacations for this employee pending during the period you want to liquidate .. \n Please cancel or approve and then try again", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return false;
                    }
                }
                catch
                {
                    MessageBox.Show((LangArEn == 0) ? " هناك اجازات لهذا الموظف معلقة خلال الفترة التي تريد تصفيتها .. \n يرجى الغائها او الموافقة عليها ثم المحاولة مجددا" : "There are vacations for this employee pending during the period you want to liquidate .. \n Please cancel or approve and then try again", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                if (false)
                {
#pragma warning disable CS0162 // Unreachable code detected
                    Environment.Exit(0);
#pragma warning restore CS0162 // Unreachable code detected
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
                            string dtAction = (n.IsHijri(dateTimeInput_DateFilter.Text) ? dateTimeInput_DateFilter.Text : n.GregToHijri(dateTimeInput_DateFilter.Text, "yyyy/MM/dd"));
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
        private void comboBox_EmpNo_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (State == FormState.Saved || comboBox_EmpNo.SelectedIndex == -1 || (State != FormState.New && State != FormState.Edit))
                {
                    return;
                }
                dateTimeInput_LastFilter.Text = "";
                if (State != FormState.New && State != FormState.Edit)
                {
                    return;
                }
                List<T_EndService> q = db.T_EndServices.Where((T_EndService t) => t.IFState == (bool?)false && t.EmpID == comboBox_EmpNo.SelectedValue.ToString()).ToList();
                if (q.Count > 0 && !string.IsNullOrEmpty(q.First().EndService_ID))
                {
                    MessageBox.Show("يرجى ترحيل التصفيات السابقة لهذا الموظف ..ثم عمل تصفية جديدة", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    comboBox_EmpNo.SelectedIndex = -1;
                    return;
                }
                List<T_EndService> EServicData = (from br in db.T_EndServices
                                                  orderby br.warnNo
                                                  where br.EmpID == comboBox_EmpNo.SelectedValue.ToString()
                                                  select br).ToList();
                T_Emp newData = ((EServicData.Count() == 0) ? db.EmpsEmp(comboBox_EmpNo.SelectedValue.ToString()) : ((!EServicData.First().IFState.Value) ? db.EmpsEmp(comboBox_EmpNo.SelectedValue.ToString()) : db.T_Emps.Where((T_Emp t) => t.Emp_ID == comboBox_EmpNo.SelectedValue.ToString()).First()));
                if (string.IsNullOrEmpty(newData.Emp_ID))
                {
                    return;
                }
                if (!string.IsNullOrEmpty(newData.DateAppointment))
                {
                    if (VarGeneral.CheckDate(newData.DateAppointment))
                    {
                        dateTimeInput_DateAppointment.Text = Convert.ToDateTime(newData.DateAppointment).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        dateTimeInput_DateAppointment.Text = "";
                    }
                }
                if (!string.IsNullOrEmpty(newData.LastFilter))
                {
                    if (VarGeneral.CheckDate(newData.LastFilter))
                    {
                        dateTimeInput_LastFilter.Text = Convert.ToDateTime(newData.LastFilter).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        dateTimeInput_LastFilter.Text = "";
                    }
                }
                if (!string.IsNullOrEmpty(newData.EndContr))
                {
                    if (VarGeneral.CheckDate(newData.EndContr))
                    {
                        dateTimeInput_DateFilter.Text = Convert.ToDateTime(newData.EndContr).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        dateTimeInput_DateFilter.Text = "";
                    }
                }
                if (VarGeneral.Settings_Sys.CalculatliquidNo.Value == 2)
                {
                    textBox_Salary.Value = Math.Round(newData.MainSal.Value, 2);
                }
                else if (VarGeneral.Settings_Sys.CalculatliquidNo.Value == 3)
                {
                    textBox_Salary.Value = Math.Round(newData.MainSal.Value + newData.HousingAllowance.Value / 12.0, 2);
                }
                else if (VarGeneral.Settings_Sys.CalculatliquidNo.Value == 4)
                {
                    textBox_Salary.Value = Math.Round(newData.MainSal.Value + newData.HousingAllowance.Value / 12.0, 2) + newData.TransferAllowance.Value + newData.SubsistenceAllowance.Value + newData.NaturalWorkAllowance.Value + newData.OtherAllowance.Value;
                }
                textBox_EmpNo.Text = newData.Emp_No;
                textBox_EmpNo.Tag = newData.Emp_ID;
                textBox_VacDayCount.Value = newData.VacationCount.Value;
                textBox_TicketCount.Value = newData.TicketsCount.Value;
                textBox_TicketValue.Value = Math.Round(newData.TicketsPrice.Value, 2);
                if (!string.IsNullOrEmpty(newData.ExclusionDate))
                {
                    if (VarGeneral.CheckDate(newData.ExclusionDate))
                    {
                        dateTimeInput_ExclusionDate.Text = Convert.ToDateTime(newData.ExclusionDate).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        dateTimeInput_ExclusionDate.Text = "";
                    }
                }
                dateTimeInput_DateFilter_Leave(sender, e);
                GetLoan();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("comboBox_EmpNo_SelectedValueChanged:", error, enable: true);
            }
        }
        private void GetLoan()
        {
            textBox_ValueAdvances.Value = 0.0;
            textBox_Paid.Value = 0.0;
            string quary = "SELECT Sum(T_Premiums.ValuePremiums) FROM T_Emp INNER JOIN (T_Advances INNER JOIN T_Premiums ON T_Advances.[Advances_No] = T_Premiums.Advances_No) ON T_Emp.Emp_ID = T_Advances.EmpID WHERE T_Emp.Emp_ID = '" + comboBox_EmpNo.SelectedValue.ToString() + "'";
            IEnumerable<double> AD_newData = db.ExecuteQuery<double>(quary, new object[0]);
            try
            {
                textBox_ValueAdvances.Value = Math.Round(AD_newData.First(), 2);
            }
            catch
            {
                textBox_ValueAdvances.Value = 0.0;
            }
            quary = "SELECT Sum( T_Premiums.ValuePremiums) FROM T_Emp INNER JOIN (T_Advances INNER JOIN T_Premiums ON T_Advances.[Advances_No] = T_Premiums.Advances_No) ON T_Emp.Emp_ID = T_Advances.EmpID WHERE T_Premiums.IFState = 1 AND T_Emp.Emp_ID ='" + comboBox_EmpNo.SelectedValue.ToString() + "'";
            IEnumerable<double> Pr_newData = db.ExecuteQuery<double>(quary, new object[0]);
            try
            {
                textBox_Paid.Value = Math.Round(Pr_newData.First(), 2);
            }
            catch
            {
                textBox_Paid.Value = 0.0;
            }
            textBox_Remaining.Value = Math.Round(textBox_ValueAdvances.Value - textBox_Paid.Value, 2);
            textBox_EAdvancValue.Value = Math.Round(textBox_ValueAdvances.Value - textBox_Paid.Value, 2);
        }
        private void dateTimeInput_DateFilter_Leave(object sender, EventArgs e)
        {
            dateTimeFilterLeave();
        }
        private void dateTimeFilterLeave()
        {
            try
            {
                if (State == FormState.Saved)
                {
                    return;
                }
                try
                {
                    dateTimeInput_DateFilter.Text = Convert.ToDateTime(dateTimeInput_DateFilter.Text).ToString("yyyy/MM/dd");
                }
                catch
                {
                    MaskedTextBox maskedTextBox = dateTimeInput_DateFilter;
                    int? calendr = VarGeneral.Settings_Sys.Calendr;
                    maskedTextBox.Text = ((calendr.Value == 0 && calendr.HasValue) ? VarGeneral.Gdate : VarGeneral.Hdate);
                }
                string StartDate = ((!VarGeneral.CheckDate(dateTimeInput_LastFilter.Text)) ? Convert.ToDateTime(dateTimeInput_DateAppointment.Text).ToString("yyyy/MM/dd") : Convert.ToDateTime(dateTimeInput_LastFilter.Text).ToString("yyyy/MM/dd"));
                string vD = Convert.ToDateTime(dateTimeInput_DateFilter.Text).ToString("yyyy/MM/dd");
                if (Convert.ToDateTime(StartDate) > Convert.ToDateTime(vD))
                {
                    MessageBox.Show("يجب ان يكون تاريخ التصفية اكبر من تاريخ التعيين", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                int Days = 0;
                int Months = 0;
                int Years = 0;
                gPeriode = 0.0;
                textBox_Years.Value = 0;
                textBox_Months.Value = 0;
                textBox_Days.Value = 0;
                Days = int.Parse(Convert.ToDateTime(vD).ToString("yyyy/MM/dd").Substring(8, 2)) - int.Parse(Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd").Substring(8, 2));
                if (Days < 0)
                {
                    Days += 30;
                    Months--;
                }
                Months = Months + int.Parse(Convert.ToDateTime(vD).ToString("yyyy/MM/dd").Substring(5, 2)) - int.Parse(Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd").Substring(5, 2));
                if (Months < 0)
                {
                    Months += 12;
                    Years--;
                }
                Years = Years + int.Parse(Convert.ToDateTime(vD).ToString("yyyy/MM/dd").Substring(0, 4)) - int.Parse(Convert.ToDateTime(StartDate).ToString("yyyy/MM/dd").Substring(0, 4));
                gPeriode = double.Parse(Years.ToString()) + double.Parse(Months.ToString()) / 12.0 + double.Parse(Days.ToString()) / 360.0;
                textBox_Years.Value = Years;
                textBox_Months.Value = Months;
                textBox_Days.Value = Days;
                if (State == FormState.New || State == FormState.Edit)
                {
                    string vDates = "";
                    vDates = StartDate;
                    textBox_VacAcout.Value = db.VacAmount(StartDate, vD, textBox_VacDayCount.Value);
                    textBox_VacTotal.Value = Math.Round(textBox_Salary.Value * textBox_VacAcout.Value / 30.0, 2);
                    textBox_EVacValue.Value = Math.Round(textBox_Salary.Value * textBox_VacAcout.Value / 30.0, 2);
                    textBox_Tickets.Value = db.TicktAmount(StartDate, vD, textBox_TicketCount.Value);
                    GetLoan();
                    GetVac();
                    GetTickt();
                    GetOldSalaries(SetDone: false);
                    Calc();
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("dateTimeInput_DateFilter_Leave:", error, enable: true);
            }
        }
        private void Calc()
        {
            double Total = 0.0;
            double Periode = gPeriode;
            if (textBox_ServLess.Value > 0)
            {
                if (gPeriode > (double)textBox_ServLess.Value)
                {
                    Total += textBox_Salary.Value * (double)textBox_ServLess.Value * (double)textBox_LessWorth.Value / 30.0;
                    Periode = gPeriode - (double)textBox_ServLess.Value;
                }
                else
                {
                    Total += textBox_Salary.Value * Periode * (double)textBox_LessWorth.Value / 30.0;
                    Periode = 0.0;
                }
            }
            if (textBox_ServLess.Value > 0 && textBox_AndLess.Value > 0 && Periode > 0.0)
            {
                if (gPeriode > (double)textBox_AndLess.Value)
                {
                    Total += textBox_Salary.Value * (double)(textBox_AndLess.Value - textBox_ServLess.Value) * (double)textBox_LessMoreWorth.Value / 30.0;
                    Periode = gPeriode - (double)textBox_AndLess.Value;
                }
                else
                {
                    Total += textBox_Salary.Value * Periode * (double)textBox_LessWorth.Value / 30.0;
                    Periode = 0.0;
                }
            }
            if (textBox_ServLess.Value > 0 && textBox_AndLess.Value > 0 && Periode > 0.0)
            {
                Total += textBox_Salary.Value * Periode * (double)textBox_MoreWorth.Value / 30.0;
            }
            textBox_GenTotal.Value = Math.Round(Total, 2);
            textBox_EndServiceValue.Value = Math.Round(Total, 2);
            textBox_ETotal.Value = Math.Round(textBox_EndServiceValue.Value + textBox_EVacValue.Value - textBox_EAdvancValue.Value + textBox_ETickitValue.Value + textBox_EWagesValue.Value, 2);
        }
        private void GetVac()
        {
            string BDate = ((!VarGeneral.CheckDate(dateTimeInput_LastFilter.Text)) ? Convert.ToDateTime(dateTimeInput_DateAppointment.Text).ToString("yyyy/MM/dd") : Convert.ToDateTime(dateTimeInput_LastFilter.Text).ToString("yyyy/MM/dd"));
            textBox_VacBalance.Value = 0.0;
            textBox_VacUsed.Value = 0.0;
            string quary = "SELECT * FROM T_VacTyp INNER JOIN T_Vacation ON T_VacTyp.[VacT_No] = T_Vacation.VacTyp WHERE T_Vacation.EmpID ='" + comboBox_EmpNo.SelectedValue.ToString() + "' AND T_VacTyp.Dis_VacT = 1 AND T_Vacation.AdminLock = 1 AND (T_Vacation.StartDate >= '" + Convert.ToDateTime(BDate).ToString("yyyy/MM/dd") + "' AND T_Vacation.EndDate <= '" + Convert.ToDateTime(dateTimeInput_DateFilter.Text).ToString("yyyy/MM/dd") + "')";
            List<T_Vacation> newData = db.ExecuteQuery<T_Vacation>(quary, new object[0]).ToList();
            try
            {
                if (newData.Count > 0)
                {
                    textBox_VacUsed.Value = newData.Sum((T_Vacation s) => s.VacCountDay.Value);
                }
                else
                {
                    textBox_VacUsed.Value = 0.0;
                }
            }
            catch
            {
                textBox_VacUsed.Value = 0.0;
            }
            textBox_VacBalance.Value = textBox_VacAcout.Value - textBox_VacUsed.Value;
            if (textBox_Salary.Value != 0.0 && textBox_VacBalance.Value > 0.0)
            {
                textBox_VacTotal.Value = Math.Round(textBox_Salary.Value * textBox_VacBalance.Value / 30.0, 2);
                textBox_EVacValue.Value = Math.Round(textBox_Salary.Value * textBox_VacBalance.Value / 30.0, 2);
            }
            else
            {
                textBox_VacTotal.Value = 0.0;
                textBox_EVacValue.Value = 0.0;
            }
        }
        private void GetTickt()
        {
            string BDate = ((!VarGeneral.CheckDate(dateTimeInput_LastFilter.Text)) ? Convert.ToDateTime(dateTimeInput_DateAppointment.Text).ToString("yyyy/MM/dd") : Convert.ToDateTime(dateTimeInput_LastFilter.Text).ToString("yyyy/MM/dd"));
            textBox_TicketUsed.Value = 0.0;
            textBox_TicketBalance.Value = 0.0;
            string quary = "SELECT Sum(TicketCount) FROM T_Tickets WHERE EmpID ='" + comboBox_EmpNo.SelectedValue.ToString() + "' AND (warnDate >= '" + Convert.ToDateTime(BDate).ToString("yyyy/MM/dd") + "' AND warnDate <= '" + Convert.ToDateTime(dateTimeInput_DateFilter.Text).ToString("yyyy/MM/dd") + "')";
            IEnumerable<double> newData = db.ExecuteQuery<double>(quary, new object[0]);
            try
            {
                textBox_TicketUsed.Value = newData.First();
            }
            catch
            {
                textBox_TicketUsed.Value = 0.0;
            }
            textBox_TicketBalance.Value = textBox_Tickets.Value - textBox_TicketUsed.Value;
            textBox_TicketTotal.Value = textBox_TicketValue.Value * textBox_TicketBalance.Value;
            if (textBox_ETickitValue.LockUpdateChecked)
            {
                textBox_ETickitValue.Value = textBox_TicketValue.Value * textBox_TicketBalance.Value;
            }
            else
            {
                textBox_ETickitValue.Value = 0.0;
            }
        }
        private int GetVacDays(string EmpID, string SalDate)
        {
            int TotDays = 0;
            string quary = "Select T_Vacation.* FROM T_VacTyp INNER JOIN T_Vacation ON T_VacTyp.[VacT_No] = T_Vacation.VacTyp Where T_Vacation.EmpID='" + comboBox_EmpNo.SelectedValue.ToString() + "' AND T_Vacation.AdminLock = 1 And Left(T_Vacation.StartDate,7)='" + Convert.ToDateTime(SalDate).ToString("yyyy/MM") + "' And T_Vacation.Amount = 0 And T_VacTyp.Dis_Sal = 0";
            List<T_Vacation> newData = db.ExecuteQuery<T_Vacation>(quary, new object[0]).ToList();
            for (int i = 0; i < newData.Count; i++)
            {
                TotDays += newData[i].VacCountDay.Value;
            }
            return TotDays;
        }
        private void button_SrchCauseLiquidation_Click(object sender, EventArgs e)
        {
            FrmLiquidation frm = new FrmLiquidation();
            frm.Tag = LangArEn;
            string vList = "";
            if (comboBox_CauseLiquidation.SelectedIndex != -1)
            {
                vList = comboBox_CauseLiquidation.SelectedValue.ToString();
            }
            frm.TopMost = true;
            frm.ShowDialog();
            Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
            List<T_LiquidationTyp> listLiquidationTyp = new List<T_LiquidationTyp>(dbc.T_LiquidationTyps.Select((T_LiquidationTyp item) => item).ToList());
            comboBox_CauseLiquidation.DataSource = null;
            comboBox_CauseLiquidation.DataSource = listLiquidationTyp;
            comboBox_CauseLiquidation.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_CauseLiquidation.ValueMember = "LiquidationT_No";
            if (vList != "")
            {
                for (int i = 0; i < comboBox_CauseLiquidation.Items.Count; i++)
                {
                    comboBox_CauseLiquidation.SelectedIndex = i;
                    if (comboBox_CauseLiquidation.SelectedValue.ToString() == vList)
                    {
                        break;
                    }
                }
            }
            else
            {
                comboBox_CauseLiquidation.SelectedIndex = -1;
            }
        }
        private void GetOldSalaries(bool SetDone)
        {
            string BDate = "";
            double mSalary = 0.0;
            string SalDate = "";
            int StartDays = 0;
            int StopDays = 0;
            int StartMonth = 0;
            int StopMonth = 0;
            int y = 0;
            int i = 0;
            int TotalDays = 0;
            string FirstSalary = "";
            textBox_WagesTotal.Value = 0.0;
            textBox_EWagesValue.Value = 0.0;
            textBox_WagesDetails.Text = "";
            FirstSalary = GetFirstSalaryDone();
            BDate = ((!VarGeneral.CheckDate(dateTimeInput_LastFilter.Text)) ? Convert.ToDateTime(dateTimeInput_DateAppointment.Text).ToString("yyyy/MM/dd") : Convert.ToDateTime(dateTimeInput_LastFilter.Text).ToString("yyyy/MM/dd"));
            if (!string.IsNullOrEmpty(FirstSalary))
            {
                FirstSalary += "/01";
                if (Convert.ToDateTime(FirstSalary) > Convert.ToDateTime(BDate))
                {
                    BDate = FirstSalary;
                }
            }
            for (y = int.Parse(Convert.ToDateTime(BDate).ToString("yyyy/MM/dd").Substring(0, 4)); y <= int.Parse(Convert.ToDateTime(dateTimeInput_DateFilter.Text).ToString("yyyy/MM/dd").Substring(0, 4)); y++)
            {
                StartMonth = ((y != int.Parse(Convert.ToDateTime(BDate).ToString("yyyy/MM/dd").Substring(0, 4))) ? 1 : int.Parse(Convert.ToDateTime(BDate).ToString("yyyy/MM/dd").Substring(5, 2)));
                StopMonth = ((y != int.Parse(Convert.ToDateTime(dateTimeInput_DateFilter.Text).ToString("yyyy/MM/dd").Substring(0, 4))) ? 12 : int.Parse(Convert.ToDateTime(dateTimeInput_DateFilter.Text).ToString("yyyy/MM/dd").Substring(5, 2)));
                for (i = StartMonth; i <= StopMonth; i++)
                {
                    SalDate = "";
                    if (i.ToString().Length == 1)
                    {
                        SalDate = SalDate + "0" + i + "/";
                    }
                    else
                    {
                        SalDate = SalDate + i + "/";
                    }
                    StartDays = ((y != int.Parse(Convert.ToDateTime(BDate).ToString("yyyy/MM/dd").Substring(0, 4)) || i != int.Parse(Convert.ToDateTime(BDate).ToString("yyyy/MM/dd").Substring(5, 2))) ? 1 : int.Parse(Convert.ToDateTime(BDate).ToString("yyyy/MM/dd").Substring(8, 2)));
                    StopDays = ((y != int.Parse(Convert.ToDateTime(dateTimeInput_DateFilter.Text).ToString("yyyy/MM/dd").Substring(0, 4)) || i != int.Parse(Convert.ToDateTime(dateTimeInput_DateFilter.Text).ToString("yyyy/MM/dd").Substring(5, 2))) ? db.GetMaxDayOfMonth(y + "/" + $"{i:00}", GetDefault: false) : int.Parse(Convert.ToDateTime(dateTimeInput_DateFilter.Text).ToString("yyyy/MM/dd").Substring(8, 2)));
                    TotalDays = StopDays - StartDays + 1;
                    SalDate = y + "/" + $"{i:00}" + "/" + $"{StartDays:00}";
                    TotalDays -= GetVacDays(comboBox_EmpNo.SelectedValue.ToString(), SalDate);
                    mSalary = GetNetSalary(comboBox_EmpNo.SelectedValue.ToString(), SalDate, vFinish: false, TotalDays, !SetDone);
                    try
                    {
                        if (TotalDays != db.GetMaxDayOfMonth(y + "/" + $"{i:00}", GetDefault: false))
                        {
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                            {
                                textBox_WagesDetails.Text = textBox_WagesDetails.Text + "* " + mSalary + " إستحقاق راتب لشهر :  " + y + "/" + $"{i:00}" + "  للفترة من " + $"{i:00}" + "/" + $"{StartDays:00}" + "  إلى  " + $"{i:00}" + "/" + $"{StopDays:00}" + ". \r\n";
                            }
                            else
                            {
                                textBox_WagesDetails.Text = textBox_WagesDetails.Text + "* " + mSalary + " Month salary dues :  " + y + "/" + $"{i:00}" + "  For the period from " + $"{i:00}" + "/" + $"{StartDays:00}" + "  To  " + $"{i:00}" + "/" + $"{StopDays:00}" + ". \r\n";
                            }
                        }
                        else if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                        {
                            textBox_WagesDetails.Text = textBox_WagesDetails.Text + "* " + mSalary + " إستحقاق راتب لشهر :  " + y + "/" + $"{i:00}" + ". \r\n";
                        }
                        else
                        {
                            textBox_WagesDetails.Text = textBox_WagesDetails.Text + "* " + mSalary + " Month salary dues :  " + y + "/" + $"{i:00}" + ". \r\n";
                        }
                    }
                    catch
                    {
                        mSalary = 0.0;
                    }
                    textBox_WagesTotal.Value += mSalary;
                }
            }
            textBox_WagesTotal.Value = textBox_WagesTotal.Value;
            textBox_EWagesValue.Value = textBox_WagesTotal.Value;
        }
        private double GetNetSalary(string EmpID, string SalaryDate, bool vFinish, int vWorkDays, bool vRemoved)
        {
            Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
            T_Emp vEmpsData = dbc.EmpsEmp(EmpID);
            double FullSalary = 0.0;
            int DaysOfMonth = 0;
            string BDate = "";
            int FirstDay = 0;
            int SecondDay = 0;
            int WorkDays = 0;
            int Month1 = 0;
            int Month2 = 0;
            int HTime = 0;
            int HPer = 0;
            int PolicyCalc = 0;
            double Total = 0.0;
            bool NewSalRec = false;
            BDate = Convert.ToDateTime(SalaryDate).ToString("yyyy/MM/dd");
            DaysOfMonth = dbc.GetMaxDayOfMonth(BDate, GetDefault: false);
            try
            {
                if (!string.IsNullOrEmpty(vEmpsData.Emp_ID.ToString()) && vEmpsData.Emp_ID != "0")
                {
                    HTime = vEmpsData.AllowancesTime.Value;
                    HPer = vEmpsData.Allowances.Value;
                }
            }
            catch
            {
                HTime = 0;
                HPer = 0;
            }
            try
            {
                PolicyCalc = VarGeneral.Settings_Sys.CalculateNo.Value;
            }
            catch
            {
                PolicyCalc = 0;
            }
            data_this_salary = new T_Salary();
            data_this_salary.SalaryStatus = false;
            List<T_Salary> Quary = (from t in dbc.T_Salaries
                                    where t.SalYear == (int?)int.Parse(Convert.ToDateTime(BDate).ToString("yyyy/MM/dd").Substring(0, 4)) && t.SalMonth == (int?)int.Parse(Convert.ToDateTime(BDate).ToString("yyyy/MM/dd").Substring(5, 2))
                                    where t.EmpID == EmpID
                                    select t).ToList();
            if (Quary.Count() == 0)
            {
                List<T_Emp> vEmp = (from t in dbc.T_Emps
                                    where t.EmpState == (bool?)true
                                    where t.Emp_ID == EmpID
                                    where t.StatusSal == (int?)1
                                    orderby t.Emp_No
                                    select t).ToList();
                if (vEmp.Count <= 0)
                {
                    return 0.0;
                }
                if (vEmp.Count == 1)
                {
                    Guid id = Guid.NewGuid();
                    data_this_salary.SalaryID = id.ToString();
                    data_this_salary.SalYear = int.Parse(Convert.ToDateTime(BDate).ToString("yyyy/MM/dd").Substring(0, 4));
                    data_this_salary.SalMonth = int.Parse(Convert.ToDateTime(BDate).ToString("yyyy/MM/dd").Substring(5, 2));
                    data_this_salary.EmpID = vEmp.First().Emp_ID;
                    try
                    {
                        if (vEmp.First().DirBoss.HasValue)
                        {
                            data_this_salary.DirBoss = vEmp.First().DirBoss.Value;
                        }
                        else
                        {
                            data_this_salary.DirBoss = null;
                        }
                    }
                    catch
                    {
                    }
                    data_this_salary.DeptNo = vEmp.First().Dept.Value;
                    data_this_salary.SectionNo = vEmp.First().Section.Value;
                    data_this_salary.Job = vEmp.First().Job.Value;
                    data_this_salary.Salary = vEmp.First().MainSal.Value;
                    data_this_salary.SalAcc = vEmp.First().SalAcc;
                    data_this_salary.LoanAcc = vEmp.First().LoanAcc;
                    data_this_salary.HouseAcc = vEmp.First().HouseAcc;
                    data_this_salary.fGUID = "";
                    Month1 = int.Parse(Convert.ToDateTime(vEmp.First().DateAppointment).ToString("yyyy/MM/dd").Substring(5, 2));
                    Month2 = int.Parse(Convert.ToDateTime(BDate).ToString("yyyy/MM/dd").Substring(5, 2));
                    if (HTime == 0)
                    {
                        if ((Month2 - Month1) % HPer == 0)
                        {
                            Total = vEmp.First().HousingAllowance.Value * (double)HPer / 12.0;
                        }
                    }
                    else if ((Month2 - Month1 + 1) % HPer == 0)
                    {
                        Total = vEmp.First().HousingAllowance.Value * (double)HPer / 12.0;
                    }
                    data_this_salary.HousingAllowance = Total;
                    data_this_salary.TransferAllowance = vEmp.First().TransferAllowance.Value;
                    data_this_salary.OtherAllowance = vEmp.First().SubsistenceAllowance.Value + vEmp.First().NaturalWorkAllowance.Value + vEmp.First().OtherAllowance.Value;
                    Total = data_this_salary.OtherAllowance.Value;
                    if (VarGeneral.Settings_Sys.CalculateNo == 2)
                    {
                        FullSalary = vEmp.First().MainSal.Value;
                    }
                    else if (VarGeneral.Settings_Sys.CalculateNo == 3)
                    {
                        FullSalary = vEmp.First().MainSal.Value + vEmp.First().HousingAllowance.Value / 12.0;
                    }
                    else if (VarGeneral.Settings_Sys.CalculateNo == 4)
                    {
                        FullSalary = vEmp.First().MainSal.Value + vEmp.First().HousingAllowance.Value / 12.0 + vEmp.First().TransferAllowance.Value + vEmp.First().SubsistenceAllowance.Value + vEmp.First().NaturalWorkAllowance.Value + vEmp.First().OtherAllowance.Value;
                    }
                    data_this_salary.SocialInsuranceComp = FullSalary * (vEmp.First().SocialInsuranceComp.Value / 100.0);
                    data_this_salary.SocialInsurance = FullSalary * (vEmp.First().SocialInsurance.Value / 100.0);
                    if (VarGeneral.Settings_Sys.CalculateNo == 8)
                    {
                        data_this_salary.SocialInsuranceComp = vEmp.First().SocialInsurance.Value;
                        data_this_salary.SocialInsurance = vEmp.First().SocialInsuranceComp.Value;
                    }
                    data_this_salary.InsuranceMedical = vEmp.First().InsuranceMedical.Value;
                    data_this_salary.InsuranceMedicalCom = vEmp.First().InsuranceMedicalCom.Value;
                    if (vWorkDays == 0)
                    {
                        FirstDay = 1;
                        SecondDay = DaysOfMonth;
                        if (vEmp.First().MainSal.Value > 0.0 && DaysOfMonth > 0)
                        {
                            if (Convert.ToDateTime(vEmp.First().DateAppointment).ToString("yyyy/MM") == Convert.ToDateTime(BDate).ToString("yyyy/MM") && int.Parse(Convert.ToDateTime(vEmp.First().DateAppointment).ToString("yyyy/MM/dd").Substring(8, 2)) > 1)
                            {
                                FirstDay = int.Parse(Convert.ToDateTime(vEmp.First().DateAppointment).ToString("yyyy/MM/dd").Substring(8, 2)) - 1;
                            }
                            if (int.Parse(Convert.ToDateTime(BDate).ToString("yyyy/MM/dd").Substring(8, 2)) < DaysOfMonth)
                            {
                                SecondDay = int.Parse(Convert.ToDateTime(BDate).ToString("yyyy/MM/dd").Substring(8, 2));
                            }
                        }
                        WorkDays = SecondDay - FirstDay;
                    }
                    else
                    {
                        WorkDays = vWorkDays;
                    }
                    data_this_salary.Salary = Math.Round((double)WorkDays * vEmp.First().MainSal.Value / (double)DaysOfMonth, 2);
                    data_this_salary.TransferAllowance = Math.Round((double)WorkDays * vEmp.First().TransferAllowance.Value / (double)DaysOfMonth, 2);
                    Total = Math.Round((double)WorkDays * (Total / (double)DaysOfMonth), 2);
                    data_this_salary.OtherAllowance = Total;
                    data_this_salary.InsuranceMedical = Math.Round((double)WorkDays * (vEmp.First().InsuranceMedical.Value / (double)DaysOfMonth), 2);
                    data_this_salary.InsuranceMedicalCom = Math.Round((double)WorkDays * (vEmp.First().InsuranceMedicalCom.Value / (double)DaysOfMonth), 2);
                    if (VarGeneral.Settings_Sys.CalculateNo == 2)
                    {
                        FullSalary = vEmp.First().MainSal.Value;
                    }
                    else if (VarGeneral.Settings_Sys.CalculateNo == 3)
                    {
                        FullSalary = vEmp.First().MainSal.Value + vEmp.First().HousingAllowance.Value / 12.0;
                    }
                    else if (VarGeneral.Settings_Sys.CalculateNo == 4)
                    {
                        FullSalary = vEmp.First().MainSal.Value + vEmp.First().HousingAllowance.Value / 12.0 + vEmp.First().TransferAllowance.Value + vEmp.First().SubsistenceAllowance.Value + vEmp.First().NaturalWorkAllowance.Value + vEmp.First().OtherAllowance.Value;
                    }
                    data_this_salary.SocialInsuranceComp = FullSalary / (double)DaysOfMonth * (double)WorkDays * (vEmp.First().SocialInsuranceComp.Value / 100.0);
                    data_this_salary.SocialInsurance = FullSalary / (double)DaysOfMonth * (double)WorkDays * (vEmp.First().SocialInsurance.Value / 100.0);
                    if (VarGeneral.Settings_Sys.CalculateNo == 8)
                    {
                        data_this_salary.SocialInsuranceComp = Math.Round((double)WorkDays * (vEmp.First().SocialInsuranceComp.Value / (double)DaysOfMonth), 2);
                        data_this_salary.SocialInsurance = Math.Round((double)WorkDays * (vEmp.First().SocialInsurance.Value / (double)DaysOfMonth), 2);
                    }
                    if (data_this_salary.HousingAllowance.Value > 0.0)
                    {
                        data_this_salary.HousingAllowance = Math.Round(data_this_salary.HousingAllowance.Value - (vEmp.First().HousingAllowance.Value / 12.0 - (double)WorkDays * (vEmp.First().HousingAllowance.Value / 12.0) / (double)DaysOfMonth), 2);
                    }
                    List<T_Vacation> data = dbc.ExecuteQuery<T_Vacation>("Select * From T_Vacation Where EmpID='" + vEmp.First().Emp_ID + "' AND T_Vacation.AdminLock = 1 And WithDateSal='" + Convert.ToDateTime(BDate).ToString("yyyy/MM") + "'", new object[0]).ToList();
                    if (data.Count > 0)
                    {
                        double q = data.Sum((T_Vacation t) => t.Amount.Value);
                        if (!string.IsNullOrEmpty(q.ToString()) && q > 0.0)
                        {
                            Total += q;
                        }
                    }
                    data_this_salary.OtherAllowance = Total;
                    double RSum = 0.0;
                    List<T_SalDiscount> QSum = dbc.ExecuteQuery<T_SalDiscount>("Select * from [T_SalDiscount] where [EmpID]='" + vEmp.First().Emp_ID + "' And [SalDate] like '" + Convert.ToDateTime(BDate).ToString("yyyy/MM") + "' And [SubTyp] = 1", new object[0]).ToList();
                    if (QSum.Count() > 0)
                    {
                        RSum = QSum.Sum((T_SalDiscount g) => g.SubTotaly.Value);
                    }
                    if (RSum != 0.0)
                    {
                        if (!string.IsNullOrEmpty(RSum.ToString()))
                        {
                            data_this_salary.SubDay = RSum;
                        }
                        RSum = 0.0;
                    }
                    else
                    {
                        data_this_salary.SubDay = 0.0;
                    }
                    QSum = dbc.ExecuteQuery<T_SalDiscount>("Select * from [T_SalDiscount] where [EmpID]='" + vEmp.First().Emp_ID + "' And [SalDate] like '" + Convert.ToDateTime(BDate).ToString("yyyy/MM") + "' And [SubTyp] = 2", new object[0]).ToList();
                    if (QSum.Count() > 0)
                    {
                        RSum = QSum.Sum((T_SalDiscount g) => g.SubTotaly.Value);
                    }
                    if (RSum != 0.0)
                    {
                        if (!string.IsNullOrEmpty(RSum.ToString()))
                        {
                            data_this_salary.LateHours = RSum;
                        }
                        RSum = 0.0;
                    }
                    else
                    {
                        data_this_salary.LateHours = 0.0;
                    }
                    QSum = dbc.ExecuteQuery<T_SalDiscount>("Select * from [T_SalDiscount] where [EmpID]='" + vEmp.First().Emp_ID + "' And [SalDate] like '" + Convert.ToDateTime(BDate).ToString("yyyy/MM") + "' And [SubTyp] = 3", new object[0]).ToList();
                    if (QSum.Count() > 0)
                    {
                        RSum = QSum.Sum((T_SalDiscount g) => g.SubTotaly.Value);
                    }
                    if (RSum != 0.0)
                    {
                        if (!string.IsNullOrEmpty(RSum.ToString()))
                        {
                            data_this_salary.SubJaza = RSum;
                        }
                        RSum = 0.0;
                    }
                    else
                    {
                        data_this_salary.SubJaza = 0.0;
                    }
                    QSum = dbc.ExecuteQuery<T_SalDiscount>("Select * from [T_SalDiscount] where [EmpID]='" + vEmp.First().Emp_ID + "' And [SalDate] like '" + Convert.ToDateTime(BDate).ToString("yyyy/MM") + "' And [SubTyp] = 4", new object[0]).ToList();
                    if (QSum.Count() > 0)
                    {
                        RSum = QSum.Sum((T_SalDiscount g) => g.SubTotaly.Value);
                    }
                    if (RSum != 0.0)
                    {
                        if (!string.IsNullOrEmpty(RSum.ToString()))
                        {
                            data_this_salary.SubOther = RSum;
                        }
                        RSum = 0.0;
                    }
                    else
                    {
                        data_this_salary.SubOther = 0.0;
                    }
                    List<T_CallPhone> QSumCallPhone = db.ExecuteQuery<T_CallPhone>("Select * from [T_CallPhone] where [EmpID]='" + vEmp.First().Emp_ID + "' And [SalDate] like '" + Convert.ToDateTime(BDate).ToString("yyyy/MM") + "'", new object[0]).ToList();
                    if (QSumCallPhone.Count() > 0)
                    {
                        RSum = QSumCallPhone.Sum((T_CallPhone g) => g.PhoneValue.Value);
                    }
                    if (RSum != 0.0)
                    {
                        if (!string.IsNullOrEmpty(RSum.ToString()))
                        {
                            data_this_salary.SubCallPhone = RSum;
                        }
                        RSum = 0.0;
                    }
                    else
                    {
                        data_this_salary.SubCallPhone = 0.0;
                    }
                    List<T_Commentary> QSumCommentary = db.ExecuteQuery<T_Commentary>("Select * from [T_Commentary] where [EmpID]='" + vEmp.First().Emp_ID + "' And [SalDate] like '" + Convert.ToDateTime(BDate).ToString("yyyy/MM") + "'", new object[0]).ToList();
                    if (QSumCommentary.Count() > 0)
                    {
                        RSum = QSumCommentary.Sum((T_Commentary g) => g.Value.Value);
                    }
                    if (RSum != 0.0)
                    {
                        if (!string.IsNullOrEmpty(RSum.ToString()))
                        {
                            data_this_salary.SubCommentary = RSum;
                        }
                        RSum = 0.0;
                    }
                    else
                    {
                        data_this_salary.SubCommentary = 0.0;
                    }
                    List<T_Add> QSumAdd = dbc.ExecuteQuery<T_Add>("Select * from [T_Add] where [EmpID]='" + vEmp.First().Emp_ID + "' And [SalDate] like '" + Convert.ToDateTime(BDate).ToString("yyyy/MM") + "' And [AddTyp] = 1", new object[0]).ToList();
                    if (QSumAdd.Count() > 0)
                    {
                        RSum = QSumAdd.Sum((T_Add g) => g.AddTotaly.Value);
                    }
                    if (RSum != 0.0)
                    {
                        if (!string.IsNullOrEmpty(RSum.ToString()))
                        {
                            data_this_salary.AddDay = RSum;
                        }
                        RSum = 0.0;
                    }
                    else
                    {
                        data_this_salary.AddDay = 0.0;
                    }
                    QSumAdd = dbc.ExecuteQuery<T_Add>("Select * from [T_Add] where [EmpID]='" + vEmp.First().Emp_ID + "' And [SalDate] like '" + Convert.ToDateTime(BDate).ToString("yyyy/MM") + "' And [AddTyp] = 2", new object[0]).ToList();
                    if (QSumAdd.Count() > 0)
                    {
                        RSum = QSumAdd.Sum((T_Add g) => g.AddTotaly.Value);
                    }
                    if (RSum != 0.0)
                    {
                        if (!string.IsNullOrEmpty(RSum.ToString()))
                        {
                            data_this_salary.AddHour = RSum;
                        }
                        RSum = 0.0;
                    }
                    else
                    {
                        data_this_salary.AddHour = 0.0;
                    }
                    QSumAdd = dbc.ExecuteQuery<T_Add>("Select * from [T_Add] where [EmpID]='" + vEmp.First().Emp_ID + "' And [SalDate] like '" + Convert.ToDateTime(BDate).ToString("yyyy/MM") + "' And [AddTyp] = 3", new object[0]).ToList();
                    if (QSumAdd.Count() > 0)
                    {
                        RSum = QSumAdd.Sum((T_Add g) => g.AddTotaly.Value);
                    }
                    if (RSum != 0.0)
                    {
                        if (!string.IsNullOrEmpty(RSum.ToString()))
                        {
                            data_this_salary.MandateDay = RSum;
                        }
                        RSum = 0.0;
                    }
                    else
                    {
                        data_this_salary.MandateDay = 0.0;
                    }
                    Total = 0.0;
                    List<T_Advance> QAdvanc = dbc.T_Advances.Where((T_Advance t) => t.EmpID == vEmp.First().Emp_ID && t.Remaining.Value != 0.0).ToList();
                    for (int i = 0; i < QAdvanc.Count; i++)
                    {
                        List<T_Premium> QPremimum = dbc.ExecuteQuery<T_Premium>("Select * from [T_Premiums] where [Advances_No]= " + QAdvanc[i].Advances_No + " And [PremiumsDate] like '" + Convert.ToDateTime(BDate).ToString("yyyy/MM") + "'", new object[0]).ToList();
                        for (int ii = 0; ii < QPremimum.Count; ii++)
                        {
                            Total += QPremimum[ii].ValuePremiums.Value;
                        }
                    }
                    data_this_salary.Advance = Total;
                    List<T_Reward> QReward = dbc.ExecuteQuery<T_Reward>("Select * from [T_Rewards] where [EmpID]='" + vEmp.First().Emp_ID + "' And [SalDate] like '" + Convert.ToDateTime(BDate).ToString("yyyy/MM") + "'", new object[0]).ToList();
                    Total = 0.0;
                    for (int i = 0; i < QReward.Count; i++)
                    {
                        Total += QReward[i].RewardValue.Value;
                    }
                    data_this_salary.Rewards = Total;
                    data_this_salary.Bank = vEmp.First().Bank;
                    if (!string.IsNullOrEmpty(vEmp.First().AccountID))
                    {
                        data_this_salary.AccountNo = vEmp.First().AccountID;
                    }
                    data_this_salary.IsPrint = false;
                    data_this_salary.SalaryStatus = false;
                    data_this_salary.Total = double.Parse(VarGeneral.TString.TEmpty(string.Concat(data_this_salary.Salary.Value + data_this_salary.HousingAllowance.Value + data_this_salary.TransferAllowance.Value + data_this_salary.OtherAllowance.Value - data_this_salary.SubDay.Value - data_this_salary.LateHours.Value - data_this_salary.SubJaza.Value - data_this_salary.SubOther.Value - data_this_salary.SubCallPhone.Value - data_this_salary.SubCommentary.Value + data_this_salary.AddDay.Value + data_this_salary.AddHour.Value + data_this_salary.MandateDay.Value - data_this_salary.SocialInsurance.Value - data_this_salary.Advance.Value + data_this_salary.Rewards.Value - data_this_salary.InsuranceMedical.Value)));
                    data_this_salary.SalSpell = ScriptNumber1.ScriptNum(decimal.Parse(VarGeneral.TString.TEmpty(string.Concat(data_this_salary.Total))));
                    NewSalRec = true;
                    dbc.T_Salaries.InsertOnSubmit(data_this_salary);
                    dbc.SubmitChanges();
                }
            }
            else
            {
                data_this_salary = Quary.First();
            }
            try
            {
                if (!data_this_salary.SalaryStatus.HasValue)
                {
                    data_this_salary.SalaryStatus = false;
                }
            }
            catch
            {
                data_this_salary.SalaryStatus = false;
            }
            Total = ((data_this_salary.SalaryStatus.Value != vFinish) ? 0.0 : (data_this_salary.Salary.Value + data_this_salary.HousingAllowance.Value + data_this_salary.TransferAllowance.Value + data_this_salary.OtherAllowance.Value - data_this_salary.SubDay.Value - data_this_salary.LateHours.Value - data_this_salary.SubJaza.Value - data_this_salary.SubOther.Value - data_this_salary.SubCallPhone.Value - data_this_salary.SubCommentary.Value + data_this_salary.AddDay.Value + data_this_salary.AddHour.Value + data_this_salary.MandateDay.Value - data_this_salary.SocialInsurance.Value - data_this_salary.Advance.Value + data_this_salary.Rewards.Value - data_this_salary.InsuranceMedical.Value));
            dbInstance = null;
            List<T_Salary> QSal = db.T_Salaries.Where((T_Salary t) => t.SalaryID == data_this_salary.SalaryID).ToList();
            if (QSal.Count > 0)
            {
                Datathis_salary = new T_Salary();
                data_this_salary = QSal.First();
                if (!vRemoved)
                {
                    data_this_salary.SalaryStatus = true;
                    db.Log = VarGeneral.DebugLog;
                    db.SubmitChanges(ConflictMode.ContinueOnConflict);
                }
                if (vRemoved && NewSalRec)
                {
                    db.T_Salaries.DeleteOnSubmit(Datathis_salary);
                    db.SubmitChanges();
                }
            }
            dbInstance = null;
            return Math.Round(Total, 2);
        }
        private string GetFirstSalaryDone()
        {
            string quary = "Select [SalaryID], [SalMonth],[SalYear] From T_Salary Where [SalaryStatus]=1 group by [SalaryID], [SalMonth],[SalYear] Order by [SalYear] + [SalMonth] ";
            List<T_Salary> newData = db.ExecuteQuery<T_Salary>(quary, new object[0]).ToList();
            if (newData.Count > 0)
            {
                return Convert.ToDateTime(newData.First().SalYear.Value + "/" + newData.First().SalMonth.Value).ToString("yyyy/MM");
            }
            return "";
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
        private void dateTimeInput_DateAppointment_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_DateAppointment.Text = Convert.ToDateTime(dateTimeInput_DateAppointment.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                MaskedTextBox maskedTextBox = dateTimeInput_DateAppointment;
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                maskedTextBox.Text = ((calendr.Value == 0 && calendr.HasValue) ? VarGeneral.Gdate : VarGeneral.Hdate);
            }
        }
        private void dateTimeInput_LastFilter_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_LastFilter.Text = Convert.ToDateTime(dateTimeInput_LastFilter.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_LastFilter.Text = "";
            }
        }
        private void dateTimeInput_LastFilter_Click(object sender, EventArgs e)
        {
            dateTimeInput_LastFilter.SelectAll();
        }
        private void dateTimeInput_DateFilter_Click(object sender, EventArgs e)
        {
            dateTimeInput_DateFilter.SelectAll();
        }
        private void dateTimeInput_warnDate_Click(object sender, EventArgs e)
        {
            dateTimeInput_warnDate.SelectAll();
        }
        private void dateTimeInput_DateAppointment_Click(object sender, EventArgs e)
        {
            dateTimeInput_DateAppointment.SelectAll();
        }
        private void textBox_ServLess_ValueChanged(object sender, EventArgs e)
        {
            if (State == FormState.New || State == FormState.Edit)
            {
                textBox_ServMore.Value = textBox_ServLess.Value;
                Calc();
            }
        }
        private void textBox_LessWorth_ValueChanged(object sender, EventArgs e)
        {
            if (State == FormState.New || State == FormState.Edit)
            {
                Calc();
            }
        }
        private void textBox_AndLess_ValueChanged(object sender, EventArgs e)
        {
            if (State == FormState.New || State == FormState.Edit)
            {
                textBox_ServMoreOnly.Value = textBox_AndLess.Value;
                Calc();
            }
        }
        private void textBox_LessMoreWorth_ValueChanged(object sender, EventArgs e)
        {
            if (State == FormState.New || State == FormState.Edit)
            {
                Calc();
            }
        }
        private void textBox_MoreWorth_ValueChanged(object sender, EventArgs e)
        {
            if (State == FormState.New || State == FormState.Edit)
            {
                Calc();
            }
        }
        private void textBox_VacBalance_ValueChanged(object sender, EventArgs e)
        {
            if (textBox_Salary.Value != 0.0 && textBox_VacBalance.Value > 0.0)
            {
                textBox_VacTotal.Value = Math.Round(textBox_Salary.Value * textBox_VacBalance.Value / 30.0, 2);
                textBox_EVacValue.Value = Math.Round(textBox_Salary.Value * textBox_VacBalance.Value / 30.0, 2);
            }
            else
            {
                textBox_VacTotal.Value = 0.0;
                textBox_EVacValue.Value = 0.0;
            }
        }
        private void FrmEndService_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                List<T_Emp> Quary = db.T_Emps.OrderBy((T_Emp er) => er.Emp_No).ToList();
                int i;
                for (i = 0; i < Quary.Count; i++)
                {
                    try
                    {
                        string vLastDt = (from t in db.T_EndServices
                                          orderby t.DateFilter
                                          where t.IFState == (bool?)true
                                          where t.EmpID == Quary[i].Emp_ID
                                          select t.DateFilter).Max();
                        if (vLastDt.Count() > 0)
                        {
                            if (VarGeneral.CheckDate(vLastDt.ToString()))
                            {
                                db.ExecuteCommand("UPDATE [T_Emp] SET T_Emp.LastFilter = '" + Convert.ToDateTime(vLastDt).ToString("yyyy/MM/dd") + "' WHERE T_Emp.Emp_ID = '" + Quary[i].Emp_ID + "'");
                            }
                            else
                            {
                                db.ExecuteCommand("UPDATE [T_Emp] SET T_Emp.LastFilter = '' WHERE T_Emp.Emp_ID = '" + Quary[i].Emp_ID + "'");
                            }
                        }
                        else
                        {
                            db.ExecuteCommand("UPDATE [T_Emp] SET T_Emp.LastFilter = '' WHERE T_Emp.Emp_ID = '" + Quary[i].Emp_ID + "'");
                        }
                    }
                    catch (Exception error)
                    {
                        try
                        {
                            db.ExecuteCommand("UPDATE [T_Emp] SET T_Emp.LastFilter = '' WHERE T_Emp.Emp_ID = '" + Quary[i].Emp_ID + "'");
                        }
                        catch
                        {
                            VarGeneral.DebLog.writeLog("LastFilter:", error, enable: true);
                        }
                        VarGeneral.DebLog.writeLog("LastFilter:", error, enable: true);
                    }
                }
            }
            catch
            {
            }
        }
        private void dateTimeInput_ExclusionDate_Click(object sender, EventArgs e)
        {
            dateTimeInput_ExclusionDate.SelectAll();
        }
        private void dateTimeInput_ExclusionDate_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_ExclusionDate.Text = Convert.ToDateTime(dateTimeInput_ExclusionDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_ExclusionDate.Text = "";
            }
        }
        private void UndoOldSalaries(string EmpID)
        {
            for (int i = 0; i < textBox_WagesDetails.Text.Length; i++)
            {
                if (textBox_WagesDetails.Text.Substring(i, 1) == ":")
                {
                    string x = textBox_WagesDetails.Text.Substring(i + 3, 7);
                    UnDoSalary(comboBox_EmpNo.SelectedValue.ToString(), textBox_WagesDetails.Text.Substring(i + 3, 7) + "/01");
                }
            }
        }
        private void UnDoSalary(string EmpID, string SalaryDate)
        {
            if (VarGeneral.CheckDate(SalaryDate))
            {
                T_Salary q = db.GetEmpSalaryWithRqst(SalaryDate, EmpID);
                Datathis_salary = new T_Salary();
                data_this_salary = q;
                data_this_salary.SalaryStatus = false;
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
            }
        }
        private void switchButton_Sts_ValueChanging(object sender, EventArgs e)
        {
            try
            {
                string Str1 = "";
                Str1 = (VarGeneral.CheckDate(dateTimeInput_LastFilter.Text) ? dateTimeInput_LastFilter.Text : dateTimeInput_DateAppointment.Text);
                if (State == FormState.Saved && !Button_Save.Enabled)
                {
                    if (switchButton_Sts.Value)
                    {
                        if (MessageBox.Show((LangArEn == 0) ? " سيتم استرجاع جميع البيانات المحددة بين التواريخ \n سيتم عملية فك الترحيل هل تريد المتابعة ؟" : "Will restore all of the loan and holidays between the dates specified \n Are you sure you want to undo Carryover data ?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                        {
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
                        db.ExecuteCommand("UPDATE [T_Emp] SET T_Emp.EmpState = 1 WHERE T_Emp.Emp_ID = '" + data_this.EmpID + "'");
                        db.ExecuteCommand("UPDATE [T_EndService] SET IFState = 0 WHERE EmpID = '" + data_this.EmpID + "' AND T_EndService.EndService_ID = '" + data_this.EndService_ID + "'");
                        db.ExecuteCommand("UPDATE T_Premiums SET T_Premiums.IFState = 0 FROM T_Premiums  INNER JOIN T_Advances ON T_Advances.Advances_No = T_Premiums.Advances_No WHERE T_Advances.EmpID = '" + data_this.EmpID + "' AND T_Premiums.PremiumsDate >= '" + Convert.ToDateTime(Str1).ToString("yyyy/MM") + "' AND T_Premiums.PremiumsDate <= '" + Convert.ToDateTime(dateTimeInput_DateFilter.Text).ToString("yyyy/MM") + "'");
                        db.ExecuteCommand("UPDATE T_Vacation SET T_Vacation.IFState = 0 FROM T_Vacation INNER JOIN T_VacTyp ON T_Vacation.VacTyp = T_VacTyp.VacT_No WHERE T_Vacation.EmpID = '" + data_this.EmpID + "' AND T_VacTyp.Dis_VacT = 1 AND T_Vacation.AdminLock = 1 AND T_Vacation.StartDate >= '" + Str1 + "' AND T_Vacation.EndDate <= '" + Convert.ToDateTime(dateTimeInput_DateFilter.Text).ToString("yyyy/MM/dd") + "'");
                        db.ExecuteCommand("UPDATE [T_Emp] SET T_Emp.VacationBalance = T_Emp.VacationBalance + " + textBox_VacBalance.Value + " WHERE T_Emp.Emp_ID = '" + data_this.EmpID + "'");
                        db.ExecuteCommand("UPDATE [T_Tickets] SET IFState = 0 WHERE EmpID = '" + data_this.EmpID + "' AND T_Tickets.warnDate >= '" + Str1 + "' AND T_Tickets.warnDate <= '" + Convert.ToDateTime(dateTimeInput_DateFilter.Text).ToString("yyyy/MM/dd") + "'");
                        db.ExecuteCommand("UPDATE [T_Emp] SET T_Emp.TicketsBalance = T_Emp.TicketsBalance + " + textBox_TicketBalance.Value + " WHERE T_Emp.Emp_ID = '" + data_this.EmpID + "'");
                        db.ExecuteCommand("UPDATE [T_EndService] SET IFState = 0 WHERE EmpID = '" + data_this.EmpID + "' AND T_EndService.EndService_ID = '" + data_this.EndService_ID + "'");
                        db.ExecuteCommand("UPDATE [T_SalDiscount] SET IFState = 0 WHERE EmpID = '" + data_this.EmpID + "' AND T_SalDiscount.SalDate >= '" + Convert.ToDateTime(Str1).ToString("yyyy/MM") + "' AND T_SalDiscount.SalDate <= '" + Convert.ToDateTime(dateTimeInput_DateFilter.Text).ToString("yyyy/MM") + "'");
                        db.ExecuteCommand("UPDATE [T_Add] SET IFState = 0 WHERE EmpID = '" + data_this.EmpID + "' AND T_Add.SalDate >= '" + Convert.ToDateTime(Str1).ToString("yyyy/MM") + "' AND T_Add.SalDate <= '" + Convert.ToDateTime(dateTimeInput_DateFilter.Text).ToString("yyyy/MM") + "'");
                        db.ExecuteCommand("UPDATE [T_Rewards] SET IFState = 0 WHERE EmpID = '" + data_this.EmpID + "' AND T_Rewards.SalDate >= '" + Convert.ToDateTime(Str1).ToString("yyyy/MM") + "' AND T_Rewards.SalDate <= '" + Convert.ToDateTime(dateTimeInput_DateFilter.Text).ToString("yyyy/MM") + "'");
                        UndoOldSalaries(data_this.EmpID);
                        MessageBox.Show((LangArEn == 0) ? "تم إسترجاع جميع البيانات المحددة بين التواريخ" : "Recovery was all loans and holidays between the dates specified", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        goto IL_0ad6;
                    }
                    if (MessageBox.Show((LangArEn == 0) ? " سيتم تصفية جميع البيانات المحددة بين التواريخ \n سيتم عملية الترحيل هل تريد المتابعة ؟" : "Will filter all advances and holidays between the dates specified \n Are you sure you want to Carryover the data?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.No)
                    {
                        if (MessageBox.Show((LangArEn == 0) ? " هل تريد القيام بفصل هذا الموظف ؟ " : "Do you want to transfer the employee to record the dismissed employees?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            db.ExecuteCommand("UPDATE [T_Emp] SET T_Emp.EmpState = 0 WHERE T_Emp.Emp_ID = '" + data_this.EmpID + "'");
                        }
                        db.ExecuteCommand("UPDATE [T_EndService] SET IFState = 1 WHERE EmpID = '" + data_this.EmpID + "'");
                        db.ExecuteCommand("UPDATE T_Premiums SET T_Premiums.IFState = 1 FROM T_Premiums  INNER JOIN T_Advances ON T_Advances.Advances_No = T_Premiums.Advances_No WHERE T_Advances.EmpID = '" + data_this.EmpID + "' AND T_Premiums.PremiumsDate >= '" + Convert.ToDateTime(Str1).ToString("yyyy/MM") + "' AND T_Premiums.PremiumsDate <= '" + Convert.ToDateTime(dateTimeInput_DateFilter.Text).ToString("yyyy/MM") + "'");
                        db.ExecuteCommand("UPDATE T_Vacation SET T_Vacation.IFState = 1 FROM T_Vacation INNER JOIN T_VacTyp ON T_Vacation.VacTyp = T_VacTyp.VacT_No WHERE T_Vacation.EmpID = '" + data_this.EmpID + "' AND T_VacTyp.Dis_VacT = 1 AND T_Vacation.AdminLock = 1 AND T_Vacation.StartDate >= '" + Str1 + "' AND T_Vacation.EndDate <= '" + Convert.ToDateTime(dateTimeInput_DateFilter.Text).ToString("yyyy/MM/dd") + "'");
                        db.ExecuteCommand("UPDATE [T_Emp] SET T_Emp.VacationBalance = VacationBalance - " + textBox_VacBalance.Value + " WHERE T_Emp.Emp_ID = '" + data_this.EmpID + "'");
                        db.ExecuteCommand("UPDATE [T_Tickets] SET IFState = 1 WHERE EmpID = '" + data_this.EmpID + "' AND T_Tickets.warnDate >= '" + Str1 + "' AND T_Tickets.warnDate <= '" + Convert.ToDateTime(dateTimeInput_DateFilter.Text).ToString("yyyy/MM/dd") + "'");
                        db.ExecuteCommand("UPDATE [T_Emp] SET T_Emp.TicketsBalance = TicketsBalance - " + textBox_TicketBalance.Value + " WHERE T_Emp.Emp_ID = '" + data_this.EmpID + "'");
                        db.ExecuteCommand("UPDATE [T_SalDiscount] SET IFState = 1 WHERE EmpID = '" + data_this.EmpID + "' AND T_SalDiscount.SalDate >= '" + Convert.ToDateTime(Str1).ToString("yyyy/MM") + "' AND T_SalDiscount.SalDate <= '" + Convert.ToDateTime(dateTimeInput_DateFilter.Text).ToString("yyyy/MM") + "'");
                        db.ExecuteCommand("UPDATE [T_Add] SET IFState = 1 WHERE EmpID = '" + data_this.EmpID + "' AND T_Add.SalDate >= '" + Convert.ToDateTime(Str1).ToString("yyyy/MM") + "' AND T_Add.SalDate <= '" + Convert.ToDateTime(dateTimeInput_DateFilter.Text).ToString("yyyy/MM") + "'");
                        db.ExecuteCommand("UPDATE [T_Rewards] SET IFState = 1 WHERE EmpID = '" + data_this.EmpID + "' AND T_Rewards.SalDate >= '" + Convert.ToDateTime(Str1).ToString("yyyy/MM") + "' AND T_Rewards.SalDate <= '" + Convert.ToDateTime(dateTimeInput_DateFilter.Text).ToString("yyyy/MM") + "'");
                        GetOldSalaries(SetDone: true);
                        MessageBox.Show((LangArEn == 0) ? "تم تصفية جميع البيانات المحددة بين التواريخ" : "The settlement of all Loans and holidays between the dates specified", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        goto IL_0ad6;
                    }
                    try
                    {
                        switchButton_Sts.Value = data_this.IFState.Value;
                    }
                    catch
                    {
                        switchButton_Sts.Value = false;
                    }
                }
                else
                {
                    MessageBox.Show((LangArEn == 0) ? " لايمكن ترحيل البيانات قبل اتمام عملية الحفظ" : " can not Curryover .. Please save data", VarGeneral.ProdectNam);
                    try
                    {
                        switchButton_Sts.Value = data_this.IFState.Value;
                    }
                    catch
                    {
                        switchButton_Sts.Value = false;
                    }
                }
                goto end_IL_0001;
            IL_0ad6:
                dbInstance = null;
                textBox_ID_TextChanged(sender, e);
            end_IL_0001:;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("ButtonItem_Relay_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void textBox_ETickitValue_LockUpdateChanged(object sender, EventArgs e)
        {
            if (textBox_ETickitValue.LockUpdateChecked)
            {
                textBox_ETickitValue.Value = textBox_TicketTotal.Value;
            }
            else
            {
                textBox_ETickitValue.Value = 0.0;
            }
            textBox_ETotal.Value = Math.Round(textBox_EndServiceValue.Value + textBox_EVacValue.Value - textBox_EAdvancValue.Value + textBox_ETickitValue.Value + textBox_EWagesValue.Value, 2);
        }
        private void Button_PrintTable_Click(object sender, EventArgs e)
        {
            VarGeneral.IsGeneralUsed = true;
            FrmReportsViewer frm = new FrmReportsViewer();
            frm.Repvalue = "EndServiceRep";
            frm.Tag = LangArEn;
            frm.Repvalue = "EndServiceRep";
            VarGeneral.vTitle = Text;
            frm.SqlWhere = "";
            frm.TopMost = true;
            frm.ShowDialog();
            VarGeneral.IsGeneralUsed = false;
        }
        private void label12_Click(object sender, EventArgs e)
        {
        }
        private void label14_Click(object sender, EventArgs e)
        {
        }
    }
}
