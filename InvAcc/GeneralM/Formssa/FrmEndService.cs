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
    public partial class FrmEndService : Form
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
        private ScriptNumber ScriptNumber1 = new ScriptNumber();
        private T_AccDef _AccDefBind = new T_AccDef();
        private int LangArEn = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
        private string FlagUpdate = "";
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
            InitializeComponent();
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
                    Environment.Exit(0);
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
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmEndService));
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
            label7 = new System.Windows.Forms.Label();
            textBox_Note = new System.Windows.Forms.TextBox();
            dateTimeInput_ExclusionDate = new System.Windows.Forms.MaskedTextBox();
            textBox_EmpNo = new System.Windows.Forms.TextBox();
            switchButton_Sts = new DevComponents.DotNetBar.Controls.SwitchButton();
            groupBox1 = new System.Windows.Forms.GroupBox();
            textBox_Years = new DevComponents.Editors.IntegerInput();
            textBox_Months = new DevComponents.Editors.IntegerInput();
            label15 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            textBox_Days = new DevComponents.Editors.IntegerInput();
            tabControl1 = new DevComponents.DotNetBar.TabControl();
            tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            textBox_MoreWorth = new DevComponents.Editors.IntegerInput();
            textBox_LessMoreWorth = new DevComponents.Editors.IntegerInput();
            textBox_AndLess = new DevComponents.Editors.IntegerInput();
            textBox_LessWorth = new DevComponents.Editors.IntegerInput();
            textBox_ServMoreOnly = new DevComponents.Editors.IntegerInput();
            textBox_ServMore = new DevComponents.Editors.IntegerInput();
            textBox_ServLess = new DevComponents.Editors.IntegerInput();
            textBox_GenTotal = new DevComponents.Editors.DoubleInput();
            label23 = new System.Windows.Forms.Label();
            label24 = new System.Windows.Forms.Label();
            label30 = new System.Windows.Forms.Label();
            label31 = new System.Windows.Forms.Label();
            label32 = new System.Windows.Forms.Label();
            label33 = new System.Windows.Forms.Label();
            label35 = new System.Windows.Forms.Label();
            label36 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label39 = new System.Windows.Forms.Label();
            label40 = new System.Windows.Forms.Label();
            label41 = new System.Windows.Forms.Label();
            label42 = new System.Windows.Forms.Label();
            label43 = new System.Windows.Forms.Label();
            label44 = new System.Windows.Forms.Label();
            label45 = new System.Windows.Forms.Label();
            label46 = new System.Windows.Forms.Label();
            tabItem2 = new DevComponents.DotNetBar.TabItem(components);
            tabControlPanel5 = new DevComponents.DotNetBar.TabControlPanel();
            textBox_WagesTotal = new DevComponents.Editors.DoubleInput();
            textBox_WagesDetails = new System.Windows.Forms.TextBox();
            label48 = new System.Windows.Forms.Label();
            tabItem5 = new DevComponents.DotNetBar.TabItem(components);
            tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            textBox_Paid = new DevComponents.Editors.DoubleInput();
            textBox_ValueAdvances = new DevComponents.Editors.DoubleInput();
            textBox_Remaining = new DevComponents.Editors.DoubleInput();
            label27 = new System.Windows.Forms.Label();
            label28 = new System.Windows.Forms.Label();
            label29 = new System.Windows.Forms.Label();
            tabItem1 = new DevComponents.DotNetBar.TabItem(components);
            tabControlPanel4 = new DevComponents.DotNetBar.TabControlPanel();
            textBox_TicketValue = new DevComponents.Editors.DoubleInput();
            textBox_TicketUsed = new DevComponents.Editors.DoubleInput();
            textBox_Tickets = new DevComponents.Editors.DoubleInput();
            textBox_TicketBalance = new DevComponents.Editors.DoubleInput();
            textBox_TicketCount = new DevComponents.Editors.DoubleInput();
            textBox_TicketTotal = new DevComponents.Editors.DoubleInput();
            label25 = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            label20 = new System.Windows.Forms.Label();
            label21 = new System.Windows.Forms.Label();
            label22 = new System.Windows.Forms.Label();
            tabItem4 = new DevComponents.DotNetBar.TabItem(components);
            tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            textBox_VacDayCount = new DevComponents.Editors.IntegerInput();
            textBox_VacUsed = new DevComponents.Editors.DoubleInput();
            textBox_VacAcout = new DevComponents.Editors.DoubleInput();
            textBox_VacBalance = new DevComponents.Editors.DoubleInput();
            textBox_VacTotal = new DevComponents.Editors.DoubleInput();
            label16 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            tabItem3 = new DevComponents.DotNetBar.TabItem(components);
            button_SrchCauseLiquidation = new DevComponents.DotNetBar.ButtonX();
            label2 = new System.Windows.Forms.Label();
            dateTimeInput_DateFilter = new System.Windows.Forms.MaskedTextBox();
            label13 = new System.Windows.Forms.Label();
            dateTimeInput_DateAppointment = new System.Windows.Forms.MaskedTextBox();
            label_lblDaysOfMonth = new System.Windows.Forms.Label();
            textBox_Salary = new DevComponents.Editors.DoubleInput();
            button_SrchEmp = new DevComponents.DotNetBar.ButtonX();
            label12 = new System.Windows.Forms.Label();
            dateTimeInput_warnDate = new System.Windows.Forms.MaskedTextBox();
            label54 = new System.Windows.Forms.Label();
            textBox_ID = new System.Windows.Forms.TextBox();
            label38 = new System.Windows.Forms.Label();
            groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            label6 = new System.Windows.Forms.Label();
            label50 = new System.Windows.Forms.Label();
            textBox_ETickitValue = new DevComponents.Editors.DoubleInput();
            textBox_ETotal = new DevComponents.Editors.DoubleInput();
            textBox_EndServiceValue = new DevComponents.Editors.DoubleInput();
            textBox_EAdvancValue = new DevComponents.Editors.DoubleInput();
            label52 = new System.Windows.Forms.Label();
            label53 = new System.Windows.Forms.Label();
            label49 = new System.Windows.Forms.Label();
            label51 = new System.Windows.Forms.Label();
            textBox_EWagesValue = new DevComponents.Editors.DoubleInput();
            textBox_EVacValue = new DevComponents.Editors.DoubleInput();
            dateTimeInput_LastFilter = new System.Windows.Forms.MaskedTextBox();
            comboBox_EmpNo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            label10 = new System.Windows.Forms.Label();
            comboBox_CauseLiquidation = new DevComponents.DotNetBar.Controls.ComboBoxEx();
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
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            panelEx2.SuspendLayout();
            ribbonBar1.SuspendLayout();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)textBox_Years).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBox_Months).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBox_Days).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tabControl1).BeginInit();
            tabControl1.SuspendLayout();
            tabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)textBox_MoreWorth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBox_LessMoreWorth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBox_AndLess).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBox_LessWorth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBox_ServMoreOnly).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBox_ServMore).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBox_ServLess).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBox_GenTotal).BeginInit();
            tabControlPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)textBox_WagesTotal).BeginInit();
            tabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)textBox_Paid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBox_ValueAdvances).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBox_Remaining).BeginInit();
            tabControlPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)textBox_TicketValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBox_TicketUsed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBox_Tickets).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBox_TicketBalance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBox_TicketCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBox_TicketTotal).BeginInit();
            tabControlPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)textBox_VacDayCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBox_VacUsed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBox_VacAcout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBox_VacBalance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBox_VacTotal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBox_Salary).BeginInit();
            groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)textBox_ETickitValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBox_ETotal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBox_EndServiceValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBox_EAdvancValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBox_EWagesValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textBox_EVacValue).BeginInit();
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
            panelEx2.MinimumSize = new System.Drawing.Size(649, 432);
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
            panel2.Controls.Add(label7);
            panel2.Controls.Add(textBox_Note);
            panel2.Controls.Add(dateTimeInput_ExclusionDate);
            panel2.Controls.Add(textBox_EmpNo);
            panel2.Controls.Add(switchButton_Sts);
            panel2.Controls.Add(groupBox1);
            panel2.Controls.Add(tabControl1);
            panel2.Controls.Add(button_SrchCauseLiquidation);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(dateTimeInput_DateFilter);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(dateTimeInput_DateAppointment);
            panel2.Controls.Add(label_lblDaysOfMonth);
            panel2.Controls.Add(textBox_Salary);
            panel2.Controls.Add(button_SrchEmp);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(dateTimeInput_warnDate);
            panel2.Controls.Add(label54);
            panel2.Controls.Add(textBox_ID);
            panel2.Controls.Add(label38);
            panel2.Controls.Add(groupPanel1);
            panel2.Controls.Add(dateTimeInput_LastFilter);
            panel2.Controls.Add(comboBox_EmpNo);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(comboBox_CauseLiquidation);
            resources.ApplyResources(panel2, "panel2");
            panel2.Name = "panel2";
            resources.ApplyResources(label7, "label7");
            label7.BackColor = System.Drawing.Color.Transparent;
            label7.Name = "label7";
            textBox_Note.BackColor = System.Drawing.Color.White;
            textBox_Note.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(textBox_Note, "textBox_Note");
            textBox_Note.Name = "textBox_Note";
            resources.ApplyResources(dateTimeInput_ExclusionDate, "dateTimeInput_ExclusionDate");
            dateTimeInput_ExclusionDate.Name = "dateTimeInput_ExclusionDate";
            textBox_EmpNo.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
            textBox_EmpNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(textBox_EmpNo, "textBox_EmpNo");
            textBox_EmpNo.Name = "textBox_EmpNo";
            textBox_EmpNo.ReadOnly = true;
            resources.ApplyResources(switchButton_Sts, "switchButton_Sts");
            switchButton_Sts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            switchButton_Sts.IsReadOnly = true;
            switchButton_Sts.Name = "switchButton_Sts";
            switchButton_Sts.OffBackColor = System.Drawing.Color.FromArgb(192, 80, 77);
            switchButton_Sts.OffTextColor = System.Drawing.Color.White;
            switchButton_Sts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            switchButton_Sts.ValueChanging += new System.EventHandler(switchButton_Sts_ValueChanging);
            groupBox1.Controls.Add(textBox_Years);
            groupBox1.Controls.Add(textBox_Months);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox_Days);
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            textBox_Years.AllowEmptyState = false;
            textBox_Years.BackgroundStyle.BackColor = System.Drawing.Color.DarkSeaGreen;
            textBox_Years.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_Years.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_Years.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(textBox_Years, "textBox_Years");
            textBox_Years.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_Years.IsInputReadOnly = true;
            textBox_Years.MinValue = 0;
            textBox_Years.Name = "textBox_Years";
            textBox_Months.AllowEmptyState = false;
            textBox_Months.BackgroundStyle.BackColor = System.Drawing.Color.DarkSeaGreen;
            textBox_Months.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_Months.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_Months.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(textBox_Months, "textBox_Months");
            textBox_Months.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_Months.IsInputReadOnly = true;
            textBox_Months.MinValue = 0;
            textBox_Months.Name = "textBox_Months";
            resources.ApplyResources(label15, "label15");
            label15.BackColor = System.Drawing.Color.Transparent;
            label15.Name = "label15";
            resources.ApplyResources(label14, "label14");
            label14.BackColor = System.Drawing.Color.Transparent;
            label14.Name = "label14";
            label14.Click += new System.EventHandler(label14_Click);
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Name = "label1";
            textBox_Days.AllowEmptyState = false;
            textBox_Days.BackgroundStyle.BackColor = System.Drawing.Color.DarkSeaGreen;
            textBox_Days.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_Days.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_Days.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(textBox_Days, "textBox_Days");
            textBox_Days.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_Days.IsInputReadOnly = true;
            textBox_Days.MinValue = 0;
            textBox_Days.Name = "textBox_Days";
            tabControl1.BackColor = System.Drawing.Color.Transparent;
            tabControl1.CanReorderTabs = true;
            tabControl1.Controls.Add(tabControlPanel2);
            tabControl1.Controls.Add(tabControlPanel5);
            tabControl1.Controls.Add(tabControlPanel1);
            tabControl1.Controls.Add(tabControlPanel4);
            tabControl1.Controls.Add(tabControlPanel3);
            resources.ApplyResources(tabControl1, "tabControl1");
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedTabFont = new System.Drawing.Font("Tahoma", 8f, System.Drawing.FontStyle.Bold);
            tabControl1.SelectedTabIndex = 0;
            tabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.RoundHeader;
            tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            tabControl1.Tabs.Add(tabItem2);
            tabControl1.Tabs.Add(tabItem3);
            tabControl1.Tabs.Add(tabItem4);
            tabControl1.Tabs.Add(tabItem1);
            tabControl1.Tabs.Add(tabItem5);
            tabControlPanel2.Controls.Add(textBox_MoreWorth);
            tabControlPanel2.Controls.Add(textBox_LessMoreWorth);
            tabControlPanel2.Controls.Add(textBox_AndLess);
            tabControlPanel2.Controls.Add(textBox_LessWorth);
            tabControlPanel2.Controls.Add(textBox_ServMoreOnly);
            tabControlPanel2.Controls.Add(textBox_ServMore);
            tabControlPanel2.Controls.Add(textBox_ServLess);
            tabControlPanel2.Controls.Add(textBox_GenTotal);
            tabControlPanel2.Controls.Add(label23);
            tabControlPanel2.Controls.Add(label24);
            tabControlPanel2.Controls.Add(label30);
            tabControlPanel2.Controls.Add(label31);
            tabControlPanel2.Controls.Add(label32);
            tabControlPanel2.Controls.Add(label33);
            tabControlPanel2.Controls.Add(label35);
            tabControlPanel2.Controls.Add(label36);
            tabControlPanel2.Controls.Add(label3);
            tabControlPanel2.Controls.Add(label39);
            tabControlPanel2.Controls.Add(label40);
            tabControlPanel2.Controls.Add(label41);
            tabControlPanel2.Controls.Add(label42);
            tabControlPanel2.Controls.Add(label43);
            tabControlPanel2.Controls.Add(label44);
            tabControlPanel2.Controls.Add(label45);
            tabControlPanel2.Controls.Add(label46);
            resources.ApplyResources(tabControlPanel2, "tabControlPanel2");
            tabControlPanel2.Name = "tabControlPanel2";
            tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.White;
            tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(236, 233, 215);
            tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            tabControlPanel2.Style.BorderColor.Color = System.Drawing.SystemColors.ControlDarkDark;
            tabControlPanel2.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right | DevComponents.DotNetBar.eBorderSide.Bottom;
            tabControlPanel2.Style.GradientAngle = 90;
            tabControlPanel2.TabItem = tabItem2;
            textBox_MoreWorth.AllowEmptyState = false;
            textBox_MoreWorth.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_MoreWorth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_MoreWorth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(textBox_MoreWorth, "textBox_MoreWorth");
            textBox_MoreWorth.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_MoreWorth.MinValue = 0;
            textBox_MoreWorth.Name = "textBox_MoreWorth";
            textBox_MoreWorth.ValueChanged += new System.EventHandler(textBox_MoreWorth_ValueChanged);
            textBox_LessMoreWorth.AllowEmptyState = false;
            textBox_LessMoreWorth.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_LessMoreWorth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_LessMoreWorth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(textBox_LessMoreWorth, "textBox_LessMoreWorth");
            textBox_LessMoreWorth.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_LessMoreWorth.MinValue = 0;
            textBox_LessMoreWorth.Name = "textBox_LessMoreWorth";
            textBox_LessMoreWorth.ValueChanged += new System.EventHandler(textBox_LessMoreWorth_ValueChanged);
            textBox_AndLess.AllowEmptyState = false;
            textBox_AndLess.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_AndLess.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_AndLess.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(textBox_AndLess, "textBox_AndLess");
            textBox_AndLess.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_AndLess.MinValue = 0;
            textBox_AndLess.Name = "textBox_AndLess";
            textBox_AndLess.ValueChanged += new System.EventHandler(textBox_AndLess_ValueChanged);
            textBox_LessWorth.AllowEmptyState = false;
            textBox_LessWorth.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_LessWorth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_LessWorth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(textBox_LessWorth, "textBox_LessWorth");
            textBox_LessWorth.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_LessWorth.MinValue = 0;
            textBox_LessWorth.Name = "textBox_LessWorth";
            textBox_LessWorth.ValueChanged += new System.EventHandler(textBox_LessWorth_ValueChanged);
            textBox_ServMoreOnly.AllowEmptyState = false;
            textBox_ServMoreOnly.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_ServMoreOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_ServMoreOnly.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(textBox_ServMoreOnly, "textBox_ServMoreOnly");
            textBox_ServMoreOnly.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_ServMoreOnly.IsInputReadOnly = true;
            textBox_ServMoreOnly.MinValue = 0;
            textBox_ServMoreOnly.Name = "textBox_ServMoreOnly";
            textBox_ServMore.AllowEmptyState = false;
            textBox_ServMore.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_ServMore.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_ServMore.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(textBox_ServMore, "textBox_ServMore");
            textBox_ServMore.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_ServMore.IsInputReadOnly = true;
            textBox_ServMore.MinValue = 0;
            textBox_ServMore.Name = "textBox_ServMore";
            textBox_ServLess.AllowEmptyState = false;
            textBox_ServLess.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_ServLess.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_ServLess.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(textBox_ServLess, "textBox_ServLess");
            textBox_ServLess.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_ServLess.MinValue = 0;
            textBox_ServLess.Name = "textBox_ServLess";
            textBox_ServLess.ValueChanged += new System.EventHandler(textBox_ServLess_ValueChanged);
            textBox_GenTotal.AllowEmptyState = false;
            textBox_GenTotal.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 0);
            textBox_GenTotal.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_GenTotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_GenTotal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(textBox_GenTotal, "textBox_GenTotal");
            textBox_GenTotal.Increment = 1.0;
            textBox_GenTotal.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_GenTotal.IsInputReadOnly = true;
            textBox_GenTotal.Name = "textBox_GenTotal";
            resources.ApplyResources(label23, "label23");
            label23.BackColor = System.Drawing.Color.Transparent;
            label23.Name = "label23";
            resources.ApplyResources(label24, "label24");
            label24.BackColor = System.Drawing.Color.Transparent;
            label24.Name = "label24";
            resources.ApplyResources(label30, "label30");
            label30.BackColor = System.Drawing.Color.Transparent;
            label30.Name = "label30";
            resources.ApplyResources(label31, "label31");
            label31.BackColor = System.Drawing.Color.Transparent;
            label31.Name = "label31";
            resources.ApplyResources(label32, "label32");
            label32.BackColor = System.Drawing.Color.Transparent;
            label32.Name = "label32";
            resources.ApplyResources(label33, "label33");
            label33.BackColor = System.Drawing.Color.Transparent;
            label33.Name = "label33";
            resources.ApplyResources(label35, "label35");
            label35.BackColor = System.Drawing.Color.Transparent;
            label35.Name = "label35";
            resources.ApplyResources(label36, "label36");
            label36.BackColor = System.Drawing.Color.Transparent;
            label36.Name = "label36";
            resources.ApplyResources(label3, "label3");
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Name = "label3";
            resources.ApplyResources(label39, "label39");
            label39.BackColor = System.Drawing.Color.Transparent;
            label39.Name = "label39";
            resources.ApplyResources(label40, "label40");
            label40.BackColor = System.Drawing.Color.Transparent;
            label40.Name = "label40";
            resources.ApplyResources(label41, "label41");
            label41.BackColor = System.Drawing.Color.Transparent;
            label41.Name = "label41";
            resources.ApplyResources(label42, "label42");
            label42.BackColor = System.Drawing.Color.Transparent;
            label42.Name = "label42";
            resources.ApplyResources(label43, "label43");
            label43.BackColor = System.Drawing.Color.Transparent;
            label43.Name = "label43";
            resources.ApplyResources(label44, "label44");
            label44.BackColor = System.Drawing.Color.Transparent;
            label44.Name = "label44";
            resources.ApplyResources(label45, "label45");
            label45.BackColor = System.Drawing.Color.Transparent;
            label45.Name = "label45";
            resources.ApplyResources(label46, "label46");
            label46.BackColor = System.Drawing.Color.Transparent;
            label46.Name = "label46";
            tabItem2.AttachedControl = tabControlPanel2;
            tabItem2.Name = "tabItem2";
            resources.ApplyResources(tabItem2, "tabItem2");
            tabControlPanel5.Controls.Add(textBox_WagesTotal);
            tabControlPanel5.Controls.Add(textBox_WagesDetails);
            tabControlPanel5.Controls.Add(label48);
            resources.ApplyResources(tabControlPanel5, "tabControlPanel5");
            tabControlPanel5.Name = "tabControlPanel5";
            tabControlPanel5.Style.BackColor1.Color = System.Drawing.Color.White;
            tabControlPanel5.Style.BackColor2.Color = System.Drawing.Color.FromArgb(236, 233, 215);
            tabControlPanel5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            tabControlPanel5.Style.BorderColor.Color = System.Drawing.SystemColors.ControlDarkDark;
            tabControlPanel5.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right | DevComponents.DotNetBar.eBorderSide.Bottom;
            tabControlPanel5.Style.GradientAngle = 90;
            tabControlPanel5.TabItem = tabItem5;
            textBox_WagesTotal.AllowEmptyState = false;
            textBox_WagesTotal.BackgroundStyle.BackColor = System.Drawing.Color.Yellow;
            textBox_WagesTotal.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_WagesTotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_WagesTotal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(textBox_WagesTotal, "textBox_WagesTotal");
            textBox_WagesTotal.Increment = 1.0;
            textBox_WagesTotal.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_WagesTotal.IsInputReadOnly = true;
            textBox_WagesTotal.Name = "textBox_WagesTotal";
            textBox_WagesDetails.BackColor = System.Drawing.SystemColors.ButtonFace;
            textBox_WagesDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(textBox_WagesDetails, "textBox_WagesDetails");
            textBox_WagesDetails.Name = "textBox_WagesDetails";
            textBox_WagesDetails.ReadOnly = true;
            resources.ApplyResources(label48, "label48");
            label48.BackColor = System.Drawing.Color.Transparent;
            label48.Name = "label48";
            tabItem5.AttachedControl = tabControlPanel5;
            tabItem5.Name = "tabItem5";
            resources.ApplyResources(tabItem5, "tabItem5");
            tabControlPanel1.Controls.Add(textBox_Paid);
            tabControlPanel1.Controls.Add(textBox_ValueAdvances);
            tabControlPanel1.Controls.Add(textBox_Remaining);
            tabControlPanel1.Controls.Add(label27);
            tabControlPanel1.Controls.Add(label28);
            tabControlPanel1.Controls.Add(label29);
            resources.ApplyResources(tabControlPanel1, "tabControlPanel1");
            tabControlPanel1.Name = "tabControlPanel1";
            tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.White;
            tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(236, 233, 215);
            tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            tabControlPanel1.Style.BorderColor.Color = System.Drawing.SystemColors.ControlDarkDark;
            tabControlPanel1.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right | DevComponents.DotNetBar.eBorderSide.Bottom;
            tabControlPanel1.Style.GradientAngle = 90;
            tabControlPanel1.TabItem = tabItem1;
            textBox_Paid.AllowEmptyState = false;
            textBox_Paid.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            textBox_Paid.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_Paid.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_Paid.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(textBox_Paid, "textBox_Paid");
            textBox_Paid.Increment = 1.0;
            textBox_Paid.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_Paid.IsInputReadOnly = true;
            textBox_Paid.Name = "textBox_Paid";
            textBox_ValueAdvances.AllowEmptyState = false;
            textBox_ValueAdvances.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            textBox_ValueAdvances.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_ValueAdvances.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_ValueAdvances.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(textBox_ValueAdvances, "textBox_ValueAdvances");
            textBox_ValueAdvances.Increment = 1.0;
            textBox_ValueAdvances.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_ValueAdvances.IsInputReadOnly = true;
            textBox_ValueAdvances.Name = "textBox_ValueAdvances";
            textBox_Remaining.AllowEmptyState = false;
            textBox_Remaining.BackgroundStyle.BackColor = System.Drawing.Color.Yellow;
            textBox_Remaining.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_Remaining.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_Remaining.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(textBox_Remaining, "textBox_Remaining");
            textBox_Remaining.Increment = 1.0;
            textBox_Remaining.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_Remaining.IsInputReadOnly = true;
            textBox_Remaining.Name = "textBox_Remaining";
            resources.ApplyResources(label27, "label27");
            label27.BackColor = System.Drawing.Color.Transparent;
            label27.Name = "label27";
            resources.ApplyResources(label28, "label28");
            label28.BackColor = System.Drawing.Color.Transparent;
            label28.Name = "label28";
            resources.ApplyResources(label29, "label29");
            label29.BackColor = System.Drawing.Color.Transparent;
            label29.Name = "label29";
            tabItem1.AttachedControl = tabControlPanel1;
            tabItem1.Name = "tabItem1";
            resources.ApplyResources(tabItem1, "tabItem1");
            tabControlPanel4.Controls.Add(textBox_TicketValue);
            tabControlPanel4.Controls.Add(textBox_TicketUsed);
            tabControlPanel4.Controls.Add(textBox_Tickets);
            tabControlPanel4.Controls.Add(textBox_TicketBalance);
            tabControlPanel4.Controls.Add(textBox_TicketCount);
            tabControlPanel4.Controls.Add(textBox_TicketTotal);
            tabControlPanel4.Controls.Add(label25);
            tabControlPanel4.Controls.Add(label17);
            tabControlPanel4.Controls.Add(label18);
            tabControlPanel4.Controls.Add(label19);
            tabControlPanel4.Controls.Add(label20);
            tabControlPanel4.Controls.Add(label21);
            tabControlPanel4.Controls.Add(label22);
            resources.ApplyResources(tabControlPanel4, "tabControlPanel4");
            tabControlPanel4.Name = "tabControlPanel4";
            tabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.White;
            tabControlPanel4.Style.BackColor2.Color = System.Drawing.Color.FromArgb(236, 233, 215);
            tabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            tabControlPanel4.Style.BorderColor.Color = System.Drawing.SystemColors.ControlDarkDark;
            tabControlPanel4.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right | DevComponents.DotNetBar.eBorderSide.Bottom;
            tabControlPanel4.Style.GradientAngle = 90;
            tabControlPanel4.TabItem = tabItem4;
            textBox_TicketValue.AllowEmptyState = false;
            textBox_TicketValue.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 198);
            textBox_TicketValue.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_TicketValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_TicketValue.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(textBox_TicketValue, "textBox_TicketValue");
            textBox_TicketValue.Increment = 1.0;
            textBox_TicketValue.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_TicketValue.IsInputReadOnly = true;
            textBox_TicketValue.Name = "textBox_TicketValue";
            textBox_TicketUsed.AllowEmptyState = false;
            textBox_TicketUsed.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 198);
            textBox_TicketUsed.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_TicketUsed.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_TicketUsed.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(textBox_TicketUsed, "textBox_TicketUsed");
            textBox_TicketUsed.Increment = 1.0;
            textBox_TicketUsed.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_TicketUsed.IsInputReadOnly = true;
            textBox_TicketUsed.Name = "textBox_TicketUsed";
            textBox_Tickets.AllowEmptyState = false;
            textBox_Tickets.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 198);
            textBox_Tickets.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_Tickets.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_Tickets.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(textBox_Tickets, "textBox_Tickets");
            textBox_Tickets.Increment = 1.0;
            textBox_Tickets.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_Tickets.IsInputReadOnly = true;
            textBox_Tickets.Name = "textBox_Tickets";
            textBox_TicketBalance.AllowEmptyState = false;
            textBox_TicketBalance.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            textBox_TicketBalance.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_TicketBalance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_TicketBalance.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(textBox_TicketBalance, "textBox_TicketBalance");
            textBox_TicketBalance.Increment = 1.0;
            textBox_TicketBalance.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_TicketBalance.IsInputReadOnly = true;
            textBox_TicketBalance.Name = "textBox_TicketBalance";
            textBox_TicketCount.AllowEmptyState = false;
            textBox_TicketCount.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 198);
            textBox_TicketCount.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_TicketCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_TicketCount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(textBox_TicketCount, "textBox_TicketCount");
            textBox_TicketCount.Increment = 1.0;
            textBox_TicketCount.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_TicketCount.IsInputReadOnly = true;
            textBox_TicketCount.Name = "textBox_TicketCount";
            textBox_TicketTotal.AllowEmptyState = false;
            textBox_TicketTotal.BackgroundStyle.BackColor = System.Drawing.Color.Yellow;
            textBox_TicketTotal.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_TicketTotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_TicketTotal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(textBox_TicketTotal, "textBox_TicketTotal");
            textBox_TicketTotal.Increment = 1.0;
            textBox_TicketTotal.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_TicketTotal.IsInputReadOnly = true;
            textBox_TicketTotal.Name = "textBox_TicketTotal";
            resources.ApplyResources(label25, "label25");
            label25.BackColor = System.Drawing.Color.Transparent;
            label25.Name = "label25";
            resources.ApplyResources(label17, "label17");
            label17.BackColor = System.Drawing.Color.Transparent;
            label17.Name = "label17";
            resources.ApplyResources(label18, "label18");
            label18.BackColor = System.Drawing.Color.Transparent;
            label18.Name = "label18";
            resources.ApplyResources(label19, "label19");
            label19.BackColor = System.Drawing.Color.Transparent;
            label19.Name = "label19";
            resources.ApplyResources(label20, "label20");
            label20.BackColor = System.Drawing.Color.Transparent;
            label20.Name = "label20";
            resources.ApplyResources(label21, "label21");
            label21.BackColor = System.Drawing.Color.Transparent;
            label21.Name = "label21";
            resources.ApplyResources(label22, "label22");
            label22.BackColor = System.Drawing.Color.Transparent;
            label22.Name = "label22";
            tabItem4.AttachedControl = tabControlPanel4;
            tabItem4.Name = "tabItem4";
            resources.ApplyResources(tabItem4, "tabItem4");
            tabControlPanel3.Controls.Add(textBox_VacDayCount);
            tabControlPanel3.Controls.Add(textBox_VacUsed);
            tabControlPanel3.Controls.Add(textBox_VacAcout);
            tabControlPanel3.Controls.Add(textBox_VacBalance);
            tabControlPanel3.Controls.Add(textBox_VacTotal);
            tabControlPanel3.Controls.Add(label16);
            tabControlPanel3.Controls.Add(label11);
            tabControlPanel3.Controls.Add(label9);
            tabControlPanel3.Controls.Add(label8);
            tabControlPanel3.Controls.Add(label4);
            tabControlPanel3.Controls.Add(label5);
            resources.ApplyResources(tabControlPanel3, "tabControlPanel3");
            tabControlPanel3.Name = "tabControlPanel3";
            tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.White;
            tabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(236, 233, 215);
            tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            tabControlPanel3.Style.BorderColor.Color = System.Drawing.SystemColors.ControlDarkDark;
            tabControlPanel3.Style.BorderSide = DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right | DevComponents.DotNetBar.eBorderSide.Bottom;
            tabControlPanel3.Style.GradientAngle = 90;
            tabControlPanel3.TabItem = tabItem3;
            textBox_VacDayCount.AllowEmptyState = false;
            textBox_VacDayCount.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 198);
            textBox_VacDayCount.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_VacDayCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_VacDayCount.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(textBox_VacDayCount, "textBox_VacDayCount");
            textBox_VacDayCount.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_VacDayCount.IsInputReadOnly = true;
            textBox_VacDayCount.Name = "textBox_VacDayCount";
            textBox_VacUsed.AllowEmptyState = false;
            textBox_VacUsed.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 198);
            textBox_VacUsed.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_VacUsed.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_VacUsed.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(textBox_VacUsed, "textBox_VacUsed");
            textBox_VacUsed.Increment = 1.0;
            textBox_VacUsed.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_VacUsed.IsInputReadOnly = true;
            textBox_VacUsed.Name = "textBox_VacUsed";
            textBox_VacAcout.AllowEmptyState = false;
            textBox_VacAcout.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 198);
            textBox_VacAcout.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_VacAcout.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_VacAcout.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(textBox_VacAcout, "textBox_VacAcout");
            textBox_VacAcout.Increment = 1.0;
            textBox_VacAcout.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_VacAcout.IsInputReadOnly = true;
            textBox_VacAcout.Name = "textBox_VacAcout";
            textBox_VacBalance.AllowEmptyState = false;
            textBox_VacBalance.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            textBox_VacBalance.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_VacBalance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_VacBalance.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(textBox_VacBalance, "textBox_VacBalance");
            textBox_VacBalance.Increment = 1.0;
            textBox_VacBalance.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_VacBalance.IsInputReadOnly = true;
            textBox_VacBalance.Name = "textBox_VacBalance";
            textBox_VacBalance.ValueChanged += new System.EventHandler(textBox_VacBalance_ValueChanged);
            textBox_VacTotal.AllowEmptyState = false;
            textBox_VacTotal.BackgroundStyle.BackColor = System.Drawing.Color.Yellow;
            textBox_VacTotal.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_VacTotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_VacTotal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(textBox_VacTotal, "textBox_VacTotal");
            textBox_VacTotal.Increment = 1.0;
            textBox_VacTotal.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_VacTotal.IsInputReadOnly = true;
            textBox_VacTotal.Name = "textBox_VacTotal";
            resources.ApplyResources(label16, "label16");
            label16.BackColor = System.Drawing.Color.Transparent;
            label16.Name = "label16";
            resources.ApplyResources(label11, "label11");
            label11.BackColor = System.Drawing.Color.Transparent;
            label11.Name = "label11";
            resources.ApplyResources(label9, "label9");
            label9.BackColor = System.Drawing.Color.Transparent;
            label9.Name = "label9";
            resources.ApplyResources(label8, "label8");
            label8.BackColor = System.Drawing.Color.Transparent;
            label8.Name = "label8";
            resources.ApplyResources(label4, "label4");
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.Name = "label4";
            resources.ApplyResources(label5, "label5");
            label5.BackColor = System.Drawing.Color.Transparent;
            label5.Name = "label5";
            tabItem3.AttachedControl = tabControlPanel3;
            tabItem3.Name = "tabItem3";
            resources.ApplyResources(tabItem3, "tabItem3");
            button_SrchCauseLiquidation.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            button_SrchCauseLiquidation.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(button_SrchCauseLiquidation, "button_SrchCauseLiquidation");
            button_SrchCauseLiquidation.Name = "button_SrchCauseLiquidation";
            button_SrchCauseLiquidation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_SrchCauseLiquidation.Symbol = "\uf067";
            button_SrchCauseLiquidation.SymbolSize = 11f;
            button_SrchCauseLiquidation.TextColor = System.Drawing.Color.SteelBlue;
            button_SrchCauseLiquidation.Click += new System.EventHandler(button_SrchCauseLiquidation_Click);
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            resources.ApplyResources(dateTimeInput_DateFilter, "dateTimeInput_DateFilter");
            dateTimeInput_DateFilter.Name = "dateTimeInput_DateFilter";
            dateTimeInput_DateFilter.Click += new System.EventHandler(dateTimeInput_DateFilter_Click);
            resources.ApplyResources(label13, "label13");
            label13.BackColor = System.Drawing.Color.Transparent;
            label13.Name = "label13";
            dateTimeInput_DateAppointment.BackColor = System.Drawing.Color.Red;
            resources.ApplyResources(dateTimeInput_DateAppointment, "dateTimeInput_DateAppointment");
            dateTimeInput_DateAppointment.ForeColor = System.Drawing.Color.White;
            dateTimeInput_DateAppointment.Name = "dateTimeInput_DateAppointment";
            dateTimeInput_DateAppointment.ReadOnly = true;
            dateTimeInput_DateAppointment.Leave += new System.EventHandler(textBox_SalDate_Leave);
            resources.ApplyResources(label_lblDaysOfMonth, "label_lblDaysOfMonth");
            label_lblDaysOfMonth.BackColor = System.Drawing.Color.Transparent;
            label_lblDaysOfMonth.Name = "label_lblDaysOfMonth";
            textBox_Salary.AllowEmptyState = false;
            resources.ApplyResources(textBox_Salary, "textBox_Salary");
            textBox_Salary.AutoOffFreeTextEntry = true;
            textBox_Salary.AutoResolveFreeTextEntries = false;
            textBox_Salary.BackgroundStyle.BorderBottomWidth = 1;
            textBox_Salary.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_Salary.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_Salary.BackgroundStyle.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            textBox_Salary.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            textBox_Salary.DisplayFormat = "0.00";
            textBox_Salary.Increment = 1.0;
            textBox_Salary.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_Salary.IsInputReadOnly = true;
            textBox_Salary.Name = "textBox_Salary";
            button_SrchEmp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            button_SrchEmp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(button_SrchEmp, "button_SrchEmp");
            button_SrchEmp.Name = "button_SrchEmp";
            button_SrchEmp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_SrchEmp.Symbol = "\uf002";
            button_SrchEmp.SymbolSize = 12f;
            button_SrchEmp.TextColor = System.Drawing.Color.SteelBlue;
            button_SrchEmp.Click += new System.EventHandler(button_SrchEmp_Click);
            resources.ApplyResources(label12, "label12");
            label12.Name = "label12";
            label12.Click += new System.EventHandler(label12_Click);
            resources.ApplyResources(dateTimeInput_warnDate, "dateTimeInput_warnDate");
            dateTimeInput_warnDate.Name = "dateTimeInput_warnDate";
            dateTimeInput_warnDate.Leave += new System.EventHandler(dateTimeInput_warnDate_Leave);
            resources.ApplyResources(label54, "label54");
            label54.BackColor = System.Drawing.Color.Transparent;
            label54.Name = "label54";
            textBox_ID.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            textBox_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(textBox_ID, "textBox_ID");
            textBox_ID.Name = "textBox_ID";
            textBox_ID.TextChanged += new System.EventHandler(textBox_ID_TextChanged);
            textBox_ID.Click += new System.EventHandler(textBox_ID_Click);
            textBox_ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox_ID_KeyPress);
            resources.ApplyResources(label38, "label38");
            label38.BackColor = System.Drawing.Color.Transparent;
            label38.Name = "label38";
            groupPanel1.BackColor = System.Drawing.Color.White;
            groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            groupPanel1.Controls.Add(label6);
            groupPanel1.Controls.Add(label50);
            groupPanel1.Controls.Add(textBox_ETickitValue);
            groupPanel1.Controls.Add(textBox_ETotal);
            groupPanel1.Controls.Add(textBox_EndServiceValue);
            groupPanel1.Controls.Add(textBox_EAdvancValue);
            groupPanel1.Controls.Add(label52);
            groupPanel1.Controls.Add(label53);
            groupPanel1.Controls.Add(label49);
            groupPanel1.Controls.Add(label51);
            groupPanel1.Controls.Add(textBox_EWagesValue);
            groupPanel1.Controls.Add(textBox_EVacValue);
            resources.ApplyResources(groupPanel1, "groupPanel1");
            groupPanel1.Name = "groupPanel1";
            groupPanel1.Style.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.SplitterBackground2;
            groupPanel1.Style.BackColorGradientAngle = 90;
            groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel1.Style.BorderBottomWidth = 1;
            groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel1.Style.BorderLeftWidth = 1;
            groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel1.Style.BorderRightWidth = 1;
            groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel1.Style.BorderTopWidth = 1;
            groupPanel1.Style.CornerDiameter = 4;
            groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            groupPanel1.Style.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            groupPanel1.TitleImagePosition = DevComponents.DotNetBar.eTitleImagePosition.Center;
            resources.ApplyResources(label6, "label6");
            label6.BackColor = System.Drawing.Color.Transparent;
            label6.Name = "label6";
            resources.ApplyResources(label50, "label50");
            label50.BackColor = System.Drawing.Color.Transparent;
            label50.Name = "label50";
            textBox_ETickitValue.AllowEmptyState = false;
            textBox_ETickitValue.BackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            textBox_ETickitValue.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_ETickitValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_ETickitValue.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(textBox_ETickitValue, "textBox_ETickitValue");
            textBox_ETickitValue.Increment = 1.0;
            textBox_ETickitValue.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_ETickitValue.IsInputReadOnly = true;
            textBox_ETickitValue.LockUpdateChecked = false;
            textBox_ETickitValue.Name = "textBox_ETickitValue";
            textBox_ETickitValue.ShowCheckBox = true;
            textBox_ETickitValue.LockUpdateChanged += new System.EventHandler(textBox_ETickitValue_LockUpdateChanged);
            textBox_ETotal.AllowEmptyState = false;
            textBox_ETotal.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 0);
            textBox_ETotal.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_ETotal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_ETotal.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(textBox_ETotal, "textBox_ETotal");
            textBox_ETotal.Increment = 1.0;
            textBox_ETotal.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_ETotal.IsInputReadOnly = true;
            textBox_ETotal.Name = "textBox_ETotal";
            textBox_EndServiceValue.AllowEmptyState = false;
            textBox_EndServiceValue.BackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            textBox_EndServiceValue.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_EndServiceValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_EndServiceValue.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(textBox_EndServiceValue, "textBox_EndServiceValue");
            textBox_EndServiceValue.Increment = 1.0;
            textBox_EndServiceValue.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_EndServiceValue.IsInputReadOnly = true;
            textBox_EndServiceValue.Name = "textBox_EndServiceValue";
            textBox_EAdvancValue.AllowEmptyState = false;
            textBox_EAdvancValue.BackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            textBox_EAdvancValue.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_EAdvancValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_EAdvancValue.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(textBox_EAdvancValue, "textBox_EAdvancValue");
            textBox_EAdvancValue.Increment = 1.0;
            textBox_EAdvancValue.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_EAdvancValue.IsInputReadOnly = true;
            textBox_EAdvancValue.Name = "textBox_EAdvancValue";
            resources.ApplyResources(label52, "label52");
            label52.BackColor = System.Drawing.Color.Transparent;
            label52.Name = "label52";
            resources.ApplyResources(label53, "label53");
            label53.BackColor = System.Drawing.Color.Transparent;
            label53.Name = "label53";
            resources.ApplyResources(label49, "label49");
            label49.BackColor = System.Drawing.Color.Transparent;
            label49.Name = "label49";
            resources.ApplyResources(label51, "label51");
            label51.BackColor = System.Drawing.Color.Transparent;
            label51.Name = "label51";
            textBox_EWagesValue.AllowEmptyState = false;
            textBox_EWagesValue.BackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            textBox_EWagesValue.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_EWagesValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_EWagesValue.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(textBox_EWagesValue, "textBox_EWagesValue");
            textBox_EWagesValue.Increment = 1.0;
            textBox_EWagesValue.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_EWagesValue.IsInputReadOnly = true;
            textBox_EWagesValue.Name = "textBox_EWagesValue";
            textBox_EVacValue.AllowEmptyState = false;
            textBox_EVacValue.BackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            textBox_EVacValue.BackgroundStyle.Class = "DateTimeInputBackground";
            textBox_EVacValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_EVacValue.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            resources.ApplyResources(textBox_EVacValue, "textBox_EVacValue");
            textBox_EVacValue.Increment = 1.0;
            textBox_EVacValue.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            textBox_EVacValue.IsInputReadOnly = true;
            textBox_EVacValue.Name = "textBox_EVacValue";
            resources.ApplyResources(dateTimeInput_LastFilter, "dateTimeInput_LastFilter");
            dateTimeInput_LastFilter.Name = "dateTimeInput_LastFilter";
            dateTimeInput_LastFilter.ReadOnly = true;
            comboBox_EmpNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboBox_EmpNo.DisplayMember = "Text";
            comboBox_EmpNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboBox_EmpNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_EmpNo.FormattingEnabled = true;
            resources.ApplyResources(comboBox_EmpNo, "comboBox_EmpNo");
            comboBox_EmpNo.Name = "comboBox_EmpNo";
            comboBox_EmpNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            comboBox_EmpNo.SelectedValueChanged += new System.EventHandler(comboBox_EmpNo_SelectedValueChanged);
            resources.ApplyResources(label10, "label10");
            label10.BackColor = System.Drawing.Color.Transparent;
            label10.Name = "label10";
            comboBox_CauseLiquidation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboBox_CauseLiquidation.DisplayMember = "Text";
            comboBox_CauseLiquidation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboBox_CauseLiquidation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_CauseLiquidation.FormattingEnabled = true;
            resources.ApplyResources(comboBox_CauseLiquidation, "comboBox_CauseLiquidation");
            comboBox_CauseLiquidation.Name = "comboBox_CauseLiquidation";
            comboBox_CauseLiquidation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
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
            Button_PrintTable.Click += new System.EventHandler(Button_PrintTable_Click);
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
            base.Name = "FrmEndService";
            base.Load += new System.EventHandler(FrmEndService_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Frm_KeyPress);
            base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FrmEndService_FormClosing);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(Frm_KeyDown);
            panelEx2.ResumeLayout(false);
            ribbonBar1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)textBox_Years).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBox_Months).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBox_Days).EndInit();
            ((System.ComponentModel.ISupportInitialize)tabControl1).EndInit();
            tabControl1.ResumeLayout(false);
            tabControlPanel2.ResumeLayout(false);
            tabControlPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)textBox_MoreWorth).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBox_LessMoreWorth).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBox_AndLess).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBox_LessWorth).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBox_ServMoreOnly).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBox_ServMore).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBox_ServLess).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBox_GenTotal).EndInit();
            tabControlPanel5.ResumeLayout(false);
            tabControlPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)textBox_WagesTotal).EndInit();
            tabControlPanel1.ResumeLayout(false);
            tabControlPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)textBox_Paid).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBox_ValueAdvances).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBox_Remaining).EndInit();
            tabControlPanel4.ResumeLayout(false);
            tabControlPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)textBox_TicketValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBox_TicketUsed).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBox_Tickets).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBox_TicketBalance).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBox_TicketCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBox_TicketTotal).EndInit();
            tabControlPanel3.ResumeLayout(false);
            tabControlPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)textBox_VacDayCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBox_VacUsed).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBox_VacAcout).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBox_VacBalance).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBox_VacTotal).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBox_Salary).EndInit();
            groupPanel1.ResumeLayout(false);
            groupPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)textBox_ETickitValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBox_ETotal).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBox_EndServiceValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBox_EAdvancValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBox_EWagesValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)textBox_EVacValue).EndInit();
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
