using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.Editors;
using DevComponents.Editors.DateTimeAdv;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Microsoft.Win32;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmDisGeneral : Form
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
        public class ColumnDictinary_Dis
        {
            public string EmpNo;
            public ColumnDictinary_Dis(string empNo)
            {
                EmpNo = empNo;
            }
        }
        private Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private Dictionary<string, ColumnDictinary> Dir_ButSearch = new Dictionary<string, ColumnDictinary>();
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
        private T_SalDiscount data_this;
        private T_AttendOperat data_this_op;
        private Rate_DataDataContext dbInstanceRate;
        private IContainer components = null;
        private Timer timer1;
        private ExpandableSplitter expandableSplitter1;
        private PanelEx panelEx2;
        private RibbonBar ribbonBar1;
        private SaveFileDialog saveFileDialog1;
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
        private SuperTabControl superTabControl_Main1;
        protected ButtonItem Button_Close;
        protected ButtonItem Button_Save;
        protected LabelItem labelItem2;
        private Panel panel2;
        private MaskedTextBox textBox_SalDate;
        private Label label_lblDaysOfMonth;
        private Label label9;
        private DoubleInput textBox_SubTotaly;
        private DoubleInput textBox_SubValue;
        private Label label8;
        private Label lblValue;
        private DoubleInput textBox_Count;
        private Label lblNumber;
        private ComboBoxEx comboBox_CalculateNo;
        private Label label2;
        private IntegerInput textBox_DayOfMonth;
        private Label lblDaysOfMonth;
        private ComboBoxEx comboBox_SubTyp;
        private Label label1;
        private MaskedTextBox dateTimeInput_warnDate;
        private Label label54;
        private TextBoxX textBox_Note;
        private ExpandablePanel expandablePanel_Girds;
        private ExpandablePanel expandablePanel_Emp;
        private ItemPanel itemPanel4;
        private SuperGridControl dataGridViewX_Emp;
        private ExpandablePanel expandablePanel_Job;
        private ItemPanel itemPanel3;
        private SuperGridControl dataGridViewX_Job;
        private ExpandablePanel expandablePanel_Section;
        private ItemPanel itemPanel2;
        private SuperGridControl dataGridViewX_Section;
        private ExpandablePanel expandablePanel_Dept;
        private ItemPanel itemPanel1;
        private SuperGridControl dataGridViewX_Dept;
        private CheckBox checkBox_Minute;
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
        public T_SalDiscount DataThis
        {
            get
            {
                return data_this;
            }
            set
            {
                data_this = value;
            }
        }
        public T_AttendOperat Data_this_op
        {
            get
            {
                return data_this_op;
            }
            set
            {
                data_this_op = value;
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
        private void textBox_Note_ButtonCustomClick(object sender, EventArgs e)
        {
            textBox_Note.Text = "";
        }
        private void Button_Close_Click(object sender, EventArgs e)
        {
            Close();
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
            if (e.KeyCode == Keys.F2 && Button_Save.Enabled && Button_Save.Visible)
            {
                Button_Save_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        public FrmDisGeneral()
        {
            InitializeComponent();
            ADD_Controls();
            Button_Close.Click += Button_Close_Click;
            Button_Save.Click += Button_Save_Click;
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Button_Close.Text = "??????????";
                Button_Save.Text = "??????";
                Button_Close.Tooltip = "Esc";
                Button_Save.Tooltip = "F2";
                textBox_Note.WatermarkText = "???????????????????????????? ??????????????????";
                Text = "???????? ????????????????????";
            }
            else
            {
                Button_Close.Text = "Close";
                Button_Save.Text = "Save";
                Button_Close.Tooltip = "Esc";
                Button_Save.Tooltip = "F2";
                textBox_Note.WatermarkText = "Notes";
                Text = "Discount Card";
            }
        }
        private void FrmDisGeneral_Load(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmDisGeneral));
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
            try
            {
                RibunButtons();
                SuperGridColumns();
                FillCombo();
                FillGrid();
                Clear();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FrmDisGeneral_Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void SuperGridColumns()
        {
            dataGridViewX_Emp.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "????????????" : "Employee");
            dataGridViewX_Dept.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "??????????????" : "Management");
            dataGridViewX_Job.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "??????????????" : "Job");
            dataGridViewX_Section.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "??????????" : "Section");
            dataGridViewX_Emp.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Background.Color1 = SystemColors.ActiveCaption;
            dataGridViewX_Dept.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Background.Color1 = SystemColors.ActiveCaption;
            dataGridViewX_Job.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Background.Color1 = SystemColors.ActiveCaption;
            dataGridViewX_Section.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Background.Color1 = SystemColors.ActiveCaption;
            dataGridViewX_Emp.PrimaryGrid.UseAlternateColumnStyle = false;
            dataGridViewX_Dept.PrimaryGrid.UseAlternateColumnStyle = false;
            dataGridViewX_Job.PrimaryGrid.UseAlternateColumnStyle = false;
            dataGridViewX_Section.PrimaryGrid.UseAlternateColumnStyle = false;
        }
        public void FillCombo()
        {
            List<T_OpMethod> listOpMethod = new List<T_OpMethod>((from item in db.T_OpMethods
                                                                  orderby item.Method_No
                                                                  where item.Method_No != 7 && item.Method_No != 8 && item.Method_No != 9 && item.Method_No != 10 && item.Method_No != 10 && item.Method_No != 11 && item.Method_No != 12 && item.Method_No != 13
                                                                  select item).ToList());
            comboBox_CalculateNo.DataSource = listOpMethod;
            comboBox_CalculateNo.DisplayMember = ((LangArEn == 0) ? "Name" : "NameE");
            comboBox_CalculateNo.ValueMember = "Method_No";
            List<T_SubTyp> listSubTyp = new List<T_SubTyp>(db.T_SubTyps.Select((T_SubTyp item) => item).ToList());
            comboBox_SubTyp.DataSource = listSubTyp;
            comboBox_SubTyp.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_SubTyp.ValueMember = "SubNo";
            comboBox_SubTyp.SelectedIndex = -1;
        }
        private void FillGrid()
        {
            GridRow row = new GridRow();
            List<T_Dept> listDept = db.FillDept_2("").ToList();
            for (int i = 0; i < listDept.Count; i++)
            {
                row = new GridRow();
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                dataGridViewX_Dept.PrimaryGrid.Rows.Add(row);
                dataGridViewX_Dept.PrimaryGrid.GetCell(i, 1).Value = ((LangArEn == 0) ? listDept[i].NameA.ToString() : listDept[i].NameE.ToString());
                dataGridViewX_Dept.PrimaryGrid.GetCell(i, 2).Value = listDept[i].Dept_No.ToString();
            }
            List<T_Section> listSection = db.FillSection_2("").ToList();
            for (int i = 0; i < listSection.Count; i++)
            {
                row = new GridRow();
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                dataGridViewX_Section.PrimaryGrid.Rows.Add(row);
                dataGridViewX_Section.PrimaryGrid.GetCell(i, 1).Value = ((LangArEn == 0) ? listSection[i].NameA.ToString() : listSection[i].NameE.ToString());
                dataGridViewX_Section.PrimaryGrid.GetCell(i, 2).Value = listSection[i].Section_No.ToString();
            }
            List<T_Job> listJob = db.FillJob_2("").ToList();
            for (int i = 0; i < listJob.Count; i++)
            {
                row = new GridRow();
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                dataGridViewX_Job.PrimaryGrid.Rows.Add(row);
                dataGridViewX_Job.PrimaryGrid.GetCell(i, 1).Value = ((LangArEn == 0) ? listJob[i].NameA.ToString() : listJob[i].NameE.ToString());
                dataGridViewX_Job.PrimaryGrid.GetCell(i, 2).Value = listJob[i].Job_No.ToString();
            }
            List<T_Emp> listEmp = db.FillEmps_2("").ToList();
            for (int i = 0; i < listEmp.Count; i++)
            {
                row = new GridRow();
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                row.Cells.Add(new GridCell(""));
                dataGridViewX_Emp.PrimaryGrid.Rows.Add(row);
                dataGridViewX_Emp.PrimaryGrid.GetCell(i, 1).Value = ((LangArEn == 0) ? listEmp[i].NameA.ToString() : listEmp[i].NameE.ToString());
                dataGridViewX_Emp.PrimaryGrid.GetCell(i, 2).Value = listEmp[i].Emp_ID.ToString();
            }
        }
        public void Clear()
        {
            if (State == FormState.New)
            {
                return;
            }
            State = FormState.New;
            data_this = new T_SalDiscount();
            State = FormState.New;
            int? calendr;
            for (int i = 0; i < controls.Count; i++)
            {
                if (controls[i].GetType() == typeof(DateTimePicker))
                {
                    calendr = VarGeneral.Settings_Sys.Calendr;
                    if (calendr.Value == 0 && calendr.HasValue)
                    {
                        (controls[i] as DateTimePicker).Text = VarGeneral.Gdate;
                    }
                    else
                    {
                        (controls[i] as DateTimePicker).Text = VarGeneral.Hdate;
                    }
                }
                else if (controls[i].GetType() == typeof(DateTimeInput))
                {
                    (controls[i] as DateTimeInput).Value = DateTime.Now;
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
                }
            }
            calendr = VarGeneral.Settings_Sys.Calendr;
            if (calendr.Value == 0 && calendr.HasValue)
            {
                textBox_SalDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM");
                dateTimeInput_warnDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
            }
            else
            {
                textBox_SalDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM");
                dateTimeInput_warnDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
            }
            comboBox_SubTyp.SelectedIndex = -1;
            comboBox_SubTyp.SelectedIndex = 0;
            checkBox_Minute.Checked = false;
            checkBox_Minute.Visible = false;
            SetReadOnly = false;
        }
        private void textBox_Note_Click(object sender, EventArgs e)
        {
            textBox_Note.SelectAll();
        }
        private void dateTimeInput_warnDate_Click(object sender, EventArgs e)
        {
            dateTimeInput_warnDate.SelectAll();
        }
        private void textBox_SalDate_Click(object sender, EventArgs e)
        {
            textBox_SalDate.SelectAll();
        }
        private void ADD_Controls()
        {
            try
            {
                controls = new List<Control>();
                controls.Add(textBox_Count);
                controls.Add(textBox_DayOfMonth);
                controls.Add(textBox_Note);
                controls.Add(textBox_SalDate);
                controls.Add(textBox_SubTotaly);
                controls.Add(textBox_SubValue);
                controls.Add(comboBox_CalculateNo);
                controls.Add(comboBox_SubTyp);
                controls.Add(dateTimeInput_warnDate);
                controls.Add(checkBox_Minute);
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
                textBox_DayOfMonth.Enabled = false;
                if (VarGeneral.CheckDate(textBox_SalDate.Text))
                {
                    textBox_SalDate.Text = Convert.ToDateTime(textBox_SalDate.Text).ToString("yyyy/MM");
                }
                else
                {
                    textBox_DayOfMonth.Value = 1;
                    int? calendr = VarGeneral.Settings_Sys.Calendr;
                    if (calendr.Value == 0 && calendr.HasValue)
                    {
                        textBox_SalDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM");
                    }
                    else
                    {
                        textBox_SalDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM");
                    }
                }
                textBox_DayOfMonth.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textBox_SalDate.Text + "/01").ToString("yyyy/MM/dd"), GetDefault: true);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("textBox_SalDate_Leave:", error, enable: true);
            }
        }
        private void textBox_Count_Leave(object sender, EventArgs e)
        {
        }
        private void textBox_SubValue_Leave(object sender, EventArgs e)
        {
            try
            {
                textBox_SubTotaly.Value = textBox_Count.Value * textBox_SubValue.Value;
            }
            catch
            {
                textBox_SubTotaly.Value = 0.0;
            }
        }
        private bool ValidData()
        {
            try
            {
                if (!Button_Save.Enabled)
                {
                    return false;
                }
                if (State == FormState.Edit && !CanEdit)
                {
                    MessageBox.Show((LangArEn == 0) ? "???? ???????? ???????????????? ?????? ?????????????? .. ???????? ???????????? ??????????????????" : "You are not permission this operation .. Please check permissions", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return false;
                }
                if (textBox_Count.Value <= 0.0)
                {
                    MessageBox.Show((LangArEn == 0) ? "???????? ???????????? ???? ???????? ??????????" : "Most Set Value For Count", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_Count.Focus();
                    return false;
                }
                if (textBox_SubTotaly.Value <= 0.0)
                {
                    MessageBox.Show((LangArEn == 0) ? "???????? ???? ???????????? ??????????" : "Must be a total discount is greater than zero", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_SubValue.Focus();
                    return false;
                }
                if (textBox_SalDate.Text.Trim().Length != 7)
                {
                    MessageBox.Show((LangArEn == 0) ? "???????? ???? ?????????? ?????????? ???????????? ????????" : "Make sure the date of salary", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_SalDate.Focus();
                    return false;
                }
                if (dateTimeInput_warnDate.Text.Length != 10)
                {
                    MessageBox.Show((LangArEn == 0) ? "?????? ?????????? ?????????????? " : "You must specify the date", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    dateTimeInput_warnDate.Focus();
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
                            string dtAction = (n.IsHijri(textBox_SalDate.Text + "/01") ? (textBox_SalDate.Text + "/01") : n.GregToHijri(textBox_SalDate.Text + "/01", "yyyy/MM/dd"));
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
        private void comboBox_SubTyp_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_SubTyp.SelectedIndex == 1)
                {
                    checkBox_Minute.Visible = true;
                }
                else
                {
                    checkBox_Minute.Visible = false;
                }
                if (comboBox_SubTyp.SelectedIndex == 0)
                {
                    label1.Visible = true;
                    label1.Text = ((LangArEn == 0) ? "????????????????" : "Day");
                }
                else if (comboBox_SubTyp.SelectedIndex == 1)
                {
                    label1.Visible = true;
                    if (checkBox_Minute.Checked)
                    {
                        label1.Text = ((LangArEn == 0) ? "??????????" : "Minute");
                    }
                    else
                    {
                        label1.Text = ((LangArEn == 0) ? "????????" : "Hour");
                    }
                }
                else
                {
                    label1.Visible = false;
                }
                if (comboBox_SubTyp.SelectedIndex == 0 || comboBox_SubTyp.SelectedIndex == 1)
                {
                    comboBox_CalculateNo.Enabled = true;
                    textBox_DayOfMonth.Enabled = true;
                    label2.Enabled = true;
                    lblDaysOfMonth.Enabled = true;
                }
                else
                {
                    comboBox_CalculateNo.Enabled = false;
                    textBox_DayOfMonth.Enabled = false;
                    label2.Enabled = false;
                    lblDaysOfMonth.Enabled = false;
                }
                switch (comboBox_SubTyp.SelectedIndex)
                {
                    case 0:
                        lblNumber.Text = ((LangArEn == 0) ? "???????????? :" : "Count :");
                        lblValue.Text = ((LangArEn == 0) ? "?????????????? :" : "Value :");
                        lblValue.Visible = true;
                        textBox_SubValue.Visible = true;
                        textBox_SubValue.Value = 0.0;
                        break;
                    case 1:
                        lblNumber.Text = ((LangArEn == 0) ? "???????????? :" : "Count");
                        lblValue.Text = ((LangArEn == 0) ? "?????????????? :" : "Value");
                        lblValue.Visible = true;
                        textBox_SubValue.Visible = true;
                        textBox_SubValue.Value = 0.0;
                        break;
                    case 2:
                    case 3:
                        lblNumber.Text = ((LangArEn == 0) ? "?????????????? :" : "Value");
                        lblValue.Visible = false;
                        textBox_SubValue.Visible = false;
                        textBox_SubValue.Value = 1.0;
                        break;
                }
                if (comboBox_CalculateNo.SelectedIndex == -1)
                {
                    comboBox_CalculateNo.SelectedIndex = 0;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("ComboBox_SubTyp_SelectedValueChanged:", error, enable: true);
            }
        }
        private void checkBox_Minute_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_SubTyp_SelectedValueChanged(sender, e);
        }
        private double GetDeductionValue(string EmpID)
        {
            try
            {
                T_Emp newData = db.EmpsEmp(EmpID);
                if ((newData != null || newData.Emp_ID != "") && newData.MainSal.Value > 0.0)
                {
                    if (comboBox_SubTyp.SelectedValue.ToString() == "1")
                    {
                        switch (comboBox_CalculateNo.SelectedIndex)
                        {
                            case 0:
                                return Math.Round(newData.DisOneDay.Value, 2);
                            case 1:
                                return Math.Round(newData.MainSal.Value / (double)textBox_DayOfMonth.Value, 2);
                            case 2:
                                if (newData.HousingAllowance.Value > 0.0)
                                {
                                    return Math.Round((newData.HousingAllowance.Value / 12.0 + newData.MainSal.Value) / (double)textBox_DayOfMonth.Value, 2);
                                }
                                return Math.Round(newData.MainSal.Value / (double)textBox_DayOfMonth.Value, 2);
                            case 3:
                                {
                                    double I = 0.0;
                                    if (newData.HousingAllowance.Value > 0.0)
                                    {
                                        I = newData.HousingAllowance.Value / 12.0;
                                    }
                                    I += newData.MainSal.Value;
                                    I = I + newData.TransferAllowance.Value + newData.SubsistenceAllowance.Value + newData.NaturalWorkAllowance.Value + newData.OtherAllowance.Value;
                                    return Math.Round(I / (double)textBox_DayOfMonth.Value, 2);
                                }
                            case 4:
                                {
                                    double I = 0.0;
                                    if (newData.HousingAllowance.Value > 0.0)
                                    {
                                        I = newData.HousingAllowance.Value / 12.0;
                                    }
                                    I += newData.MainSal.Value;
                                    I += newData.TransferAllowance.Value;
                                    return Math.Round(I / (double)textBox_DayOfMonth.Value, 2);
                                }
                            case 5:
                                {
                                    double I = newData.MainSal.Value;
                                    I += newData.SubsistenceAllowance.Value;
                                    return Math.Round(I / (double)textBox_DayOfMonth.Value, 2);
                                }
                        }
                    }
                    else if (comboBox_SubTyp.SelectedValue.ToString() == "2")
                    {
                        switch (comboBox_CalculateNo.SelectedIndex)
                        {
                            case 0:
                                return Math.Round(newData.LateHours.Value, 2);
                            case 1:
                                {
                                    double I = Math.Round(newData.MainSal.Value / (double)textBox_DayOfMonth.Value, 2);
                                    return Math.Round(I / newData.WorkHours.Value, 2);
                                }
                            case 2:
                                {
                                    double I;
                                    if (newData.HousingAllowance.Value > 0.0)
                                    {
                                        I = Math.Round((newData.HousingAllowance.Value / 12.0 + newData.MainSal.Value) / (double)textBox_DayOfMonth.Value, 2);
                                        return Math.Round(I / newData.WorkHours.Value, 2);
                                    }
                                    I = Math.Round(newData.MainSal.Value / (double)textBox_DayOfMonth.Value, 2);
                                    return Math.Round(I / newData.WorkHours.Value, 2);
                                }
                            case 3:
                                {
                                    double I = 0.0;
                                    if (newData.HousingAllowance.Value > 0.0)
                                    {
                                        I = newData.HousingAllowance.Value / 12.0;
                                    }
                                    I += newData.MainSal.Value;
                                    I = I + newData.TransferAllowance.Value + newData.SubsistenceAllowance.Value + newData.NaturalWorkAllowance.Value + newData.OtherAllowance.Value;
                                    I /= (double)textBox_DayOfMonth.Value;
                                    return Math.Round(I / newData.WorkHours.Value, 2);
                                }
                            case 4:
                                {
                                    double I = 0.0;
                                    if (newData.HousingAllowance.Value > 0.0)
                                    {
                                        I = newData.HousingAllowance.Value / 12.0;
                                    }
                                    I += newData.MainSal.Value;
                                    I += newData.TransferAllowance.Value;
                                    I /= (double)textBox_DayOfMonth.Value;
                                    return Math.Round(I / newData.WorkHours.Value, 2);
                                }
                            case 5:
                                {
                                    double I = newData.MainSal.Value;
                                    I += newData.SubsistenceAllowance.Value;
                                    I /= (double)textBox_DayOfMonth.Value;
                                    return Math.Round(I / newData.WorkHours.Value, 2);
                                }
                        }
                    }
                }
                return 0.0;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("GetDeductionValue:", error, enable: true);
                MessageBox.Show(error.Message);
                return 0.0;
            }
        }
        private void comboBox_CalculateNo_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (State == FormState.Saved)
                {
                    return;
                }
                if (comboBox_CalculateNo.SelectedIndex != 0)
                {
                    if (!string.IsNullOrEmpty(textBox_SalDate.Text) && textBox_SalDate.Text.Length == 7 && textBox_SalDate.Text != "__/____")
                    {
                        textBox_DayOfMonth.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textBox_SalDate.Text + "/01").ToString("yyyy/MM/dd"), GetDefault: false);
                        lblDaysOfMonth.Enabled = true;
                        textBox_DayOfMonth.Enabled = true;
                    }
                    else
                    {
                        lblDaysOfMonth.Enabled = false;
                        textBox_DayOfMonth.Enabled = false;
                        comboBox_CalculateNo.SelectedIndex = 0;
                    }
                }
                else
                {
                    lblDaysOfMonth.Enabled = false;
                    textBox_DayOfMonth.Enabled = false;
                }
                comboBox_SubTyp_SelectedValueChanged(sender, e);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("comboBox_CalculateNo_SelectedValueChanged:", error, enable: true);
            }
        }
        private void textBox_Count_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(textBox_Count.Text == ""))
                {
                    double Amount = textBox_Count.Value - textBox_Count.Value;
                    if (textBox_Count.Value < 0.0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "???????? ???? ?????? ???????? ?????????? " : "The value of non-logical", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    else if (comboBox_SubTyp.SelectedIndex == 1 && Amount > 0.599)
                    {
                        MessageBox.Show((LangArEn == 0) ? "???????? ?????? ???? ???????????????? ,,  " : "There is an error in the input,", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else if (comboBox_SubTyp.SelectedIndex == 1)
                    {
                        textBox_SubTotaly.Value = Math.Round((textBox_Count.Value + Amount / 60.0 * 100.0) * textBox_SubValue.Value, 2);
                    }
                    else
                    {
                        textBox_SubTotaly.Value = Math.Round(textBox_Count.Value * textBox_SubValue.Value, 2);
                    }
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("textBox_Count_ValueChanged:", error, enable: true);
            }
        }
        private void textBox_SubValue_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(textBox_SubValue.Text == ""))
                {
                    double Amount = textBox_Count.Value - textBox_Count.Value;
                    if (textBox_SubValue.Value < 0.0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "???????? ?????? ???? ???????????????? ,,  " : "There is an error in the input,", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else if (comboBox_SubTyp.SelectedIndex == 1)
                    {
                        textBox_SubTotaly.Value = Math.Round((textBox_Count.Value + Amount / 60.0 * 100.0) * textBox_SubValue.Value, 2);
                    }
                    else
                    {
                        textBox_SubTotaly.Value = Math.Round(textBox_Count.Value * textBox_SubValue.Value, 2);
                    }
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("textBox_SubValue_ValueChanged:", error, enable: true);
            }
        }
        private void textBox_DayOfMonth_ValueChanged(object sender, EventArgs e)
        {
            if (textBox_DayOfMonth.Value > 0 && State != 0)
            {
                comboBox_SubTyp_SelectedValueChanged(sender, e);
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
        private string GetSqlWhere()
        {
            string QStr = "";
            string tmpStr = "";
            string[] GetSql = getDeptNo();
            for (int num2 = 0; num2 < GetSql.Length; num2++)
            {
                if (!string.IsNullOrEmpty(GetSql[num2]))
                {
                    tmpStr = ((!string.IsNullOrEmpty(tmpStr)) ? (tmpStr + " OR ") : (tmpStr + " AND ( "));
                    tmpStr = tmpStr + " ( Dept = " + GetSql[num2].Trim() + " ) ";
                }
            }
            QStr += ((tmpStr != "") ? (tmpStr + " )") : "");
            tmpStr = "";
            GetSql = getEmpNo();
            for (int num2 = 0; num2 < GetSql.Length; num2++)
            {
                if (!string.IsNullOrEmpty(GetSql[num2]))
                {
                    tmpStr = ((!string.IsNullOrEmpty(tmpStr)) ? (tmpStr + " OR ") : (tmpStr + " AND ( "));
                    tmpStr = tmpStr + " ( Emp_ID = '" + GetSql[num2].Trim() + "' ) ";
                }
            }
            QStr += ((tmpStr != "") ? (tmpStr + " )") : "");
            tmpStr = "";
            GetSql = getJobNo();
            for (int num2 = 0; num2 < GetSql.Length; num2++)
            {
                if (!string.IsNullOrEmpty(GetSql[num2]))
                {
                    tmpStr = ((!string.IsNullOrEmpty(tmpStr)) ? (tmpStr + " OR ") : (tmpStr + " AND ( "));
                    tmpStr = tmpStr + " ( Job = " + GetSql[num2].Trim() + " ) ";
                }
            }
            QStr += ((tmpStr != "") ? (tmpStr + " )") : "");
            tmpStr = "";
            GetSql = getSectionNo();
            for (int num2 = 0; num2 < GetSql.Length; num2++)
            {
                if (!string.IsNullOrEmpty(GetSql[num2]))
                {
                    tmpStr = ((!string.IsNullOrEmpty(tmpStr)) ? (tmpStr + " OR ") : (tmpStr + " AND ( "));
                    tmpStr = tmpStr + " ( Section = " + GetSql[num2].Trim() + " ) ";
                }
            }
            return QStr + ((tmpStr != "") ? (tmpStr + " )") : "");
        }
        private string[] getDeptNo()
        {
            string[] listSalse = new string[dataGridViewX_Dept.PrimaryGrid.Rows.Count];
            for (int i = 0; i < dataGridViewX_Dept.PrimaryGrid.Rows.Count; i++)
            {
                if (dataGridViewX_Dept.PrimaryGrid.GetCell(i, 0).Value.ToString() == "True")
                {
                    listSalse[i] = dataGridViewX_Dept.PrimaryGrid.GetCell(i, 2).Value.ToString();
                }
            }
            return listSalse;
        }
        private string[] getEmpNo()
        {
            string[] listSalse = new string[dataGridViewX_Emp.PrimaryGrid.Rows.Count];
            for (int i = 0; i < dataGridViewX_Emp.PrimaryGrid.Rows.Count; i++)
            {
                if (dataGridViewX_Emp.PrimaryGrid.GetCell(i, 0).Value.ToString() == "True")
                {
                    listSalse[i] = dataGridViewX_Emp.PrimaryGrid.GetCell(i, 2).Value.ToString();
                }
            }
            return listSalse;
        }
        private string[] getJobNo()
        {
            string[] listSalse = new string[dataGridViewX_Job.PrimaryGrid.Rows.Count];
            for (int i = 0; i < dataGridViewX_Job.PrimaryGrid.Rows.Count; i++)
            {
                if (dataGridViewX_Job.PrimaryGrid.GetCell(i, 0).Value.ToString() == "True")
                {
                    listSalse[i] = dataGridViewX_Job.PrimaryGrid.GetCell(i, 2).Value.ToString();
                }
            }
            return listSalse;
        }
        private string[] getSectionNo()
        {
            string[] listSalse = new string[dataGridViewX_Section.PrimaryGrid.Rows.Count];
            for (int i = 0; i < dataGridViewX_Section.PrimaryGrid.Rows.Count; i++)
            {
                if (dataGridViewX_Section.PrimaryGrid.GetCell(i, 0).Value.ToString() == "True")
                {
                    listSalse[i] = dataGridViewX_Section.PrimaryGrid.GetCell(i, 2).Value.ToString();
                }
            }
            return listSalse;
        }
        private T_SalDiscount GetData()
        {
            try
            {
                data_this.ACount = textBox_Count.Value;
            }
            catch
            {
                data_this.ACount = 0.0;
            }
            try
            {
                data_this.DayOfMonth = textBox_DayOfMonth.Value;
            }
            catch
            {
                data_this.DayOfMonth = 0;
            }
            data_this.Note = textBox_Note.Text;
            try
            {
                data_this.SalDate = Convert.ToDateTime(textBox_SalDate.Text).ToString("yyyy/MM");
            }
            catch
            {
                data_this.SalDate = DateTime.Now.ToString("yyyy/MM");
            }
            data_this.MinuteTyp = checkBox_Minute.Checked;
            try
            {
                data_this.SubValue = textBox_SubValue.Value;
            }
            catch
            {
                data_this.SubValue = 0.0;
            }
            try
            {
                data_this.SubTotaly = textBox_SubTotaly.Value;
            }
            catch
            {
                data_this.SubTotaly = 0.0;
            }
            try
            {
                data_this.CalculateNo = int.Parse(comboBox_CalculateNo.SelectedValue.ToString());
            }
            catch
            {
                data_this.CalculateNo = null;
            }
            try
            {
                data_this.SubTyp = int.Parse(comboBox_SubTyp.SelectedValue.ToString());
            }
            catch
            {
                data_this.SubTyp = null;
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
                data_this.IFState = false;
            }
            catch
            {
            }
            return data_this;
        }
        private void Button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidData())
                {
                    return;
                }
                try
                {
                    List<T_Emp> q = db.ExecuteQuery<T_Emp>("Select * from [T_Emp]  Where StatusSal = 1 " + GetSqlWhere(), new object[0]).ToList();
                    if (q.Count <= 0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "???? ???????? ???????????? ?????? ???????????????? ?????????????? " : "No Employee to the criteria entered", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    for (int i = 0; i < q.Count; i++)
                    {
                        data_this = new T_SalDiscount();
                        Guid id = Guid.NewGuid();
                        data_this.Discont_ID = id.ToString();
                        data_this.EmpID = q[i].Emp_ID;
                        data_this.warnNo = db.MaxSalDiscountNo;
                        GetData();
                        db.T_SalDiscounts.InsertOnSubmit(data_this);
                        db.SubmitChanges();
                    }
                }
                catch (SqlException error2)
                {
                    if (error2.Number == 2627)
                    {
                        MessageBox.Show((LangArEn == 0) ? "?????? ?????????? ???????????? ???? ??????.\n ???????? ?????????? ???????? ???????? " : "This No is user before.\n Will be save a new number", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        Button_Save_Click(sender, e);
                    }
                    else
                    {
                        VarGeneral.DebLog.writeLog("Button_Save_Click:", error2, enable: true);
                        MessageBox.Show(error2.Message);
                    }
                    return;
                }
                State = FormState.Saved;
                SetReadOnly = true;
                Close();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Button_Save_Click:", error, enable: true);
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
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background3 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background4 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background5 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background6 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn10 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn11 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn12 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background7 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background8 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDisGeneral));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox_Minute = new System.Windows.Forms.CheckBox();
            this.expandablePanel_Girds = new DevComponents.DotNetBar.ExpandablePanel();
            this.expandablePanel_Emp = new DevComponents.DotNetBar.ExpandablePanel();
            this.itemPanel4 = new DevComponents.DotNetBar.ItemPanel();
            this.dataGridViewX_Emp = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.expandablePanel_Job = new DevComponents.DotNetBar.ExpandablePanel();
            this.itemPanel3 = new DevComponents.DotNetBar.ItemPanel();
            this.dataGridViewX_Job = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.expandablePanel_Section = new DevComponents.DotNetBar.ExpandablePanel();
            this.itemPanel2 = new DevComponents.DotNetBar.ItemPanel();
            this.dataGridViewX_Section = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.expandablePanel_Dept = new DevComponents.DotNetBar.ExpandablePanel();
            this.itemPanel1 = new DevComponents.DotNetBar.ItemPanel();
            this.dataGridViewX_Dept = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.textBox_Note = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBox_SalDate = new System.Windows.Forms.MaskedTextBox();
            this.label_lblDaysOfMonth = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_SubTotaly = new DevComponents.Editors.DoubleInput();
            this.label8 = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.textBox_Count = new DevComponents.Editors.DoubleInput();
            this.lblNumber = new System.Windows.Forms.Label();
            this.comboBox_CalculateNo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_DayOfMonth = new DevComponents.Editors.IntegerInput();
            this.lblDaysOfMonth = new System.Windows.Forms.Label();
            this.comboBox_SubTyp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimeInput_warnDate = new System.Windows.Forms.MaskedTextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.textBox_SubValue = new DevComponents.Editors.DoubleInput();
            this.ribbonBar_Tasks = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl_Main1 = new DevComponents.DotNetBar.SuperTabControl();
            this.Button_Close = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Save = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
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
            this.expandablePanel_Girds.SuspendLayout();
            this.expandablePanel_Emp.SuspendLayout();
            this.itemPanel4.SuspendLayout();
            this.expandablePanel_Job.SuspendLayout();
            this.itemPanel3.SuspendLayout();
            this.expandablePanel_Section.SuspendLayout();
            this.itemPanel2.SuspendLayout();
            this.expandablePanel_Dept.SuspendLayout();
            this.itemPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_SubTotaly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_Count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_DayOfMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_SubValue)).BeginInit();
            this.ribbonBar_Tasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).BeginInit();
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
            this.expandableSplitter1.BackColor = System.Drawing.Color.Black;
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            this.expandableSplitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.expandableSplitter1.Expandable = false;
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
            this.expandableSplitter1.Location = new System.Drawing.Point(0, -1);
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
            this.panelEx2.Location = new System.Drawing.Point(0, 13);
            this.panelEx2.MinimumSize = new System.Drawing.Size(649, 348);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(649, 348);
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
            this.ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.Gainsboro;
            this.ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.Color.Gainsboro;
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.panel2);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(649, 297);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 867;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.Black;
            this.ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkBox_Minute);
            this.panel2.Controls.Add(this.expandablePanel_Girds);
            this.panel2.Controls.Add(this.textBox_Note);
            this.panel2.Controls.Add(this.textBox_SalDate);
            this.panel2.Controls.Add(this.label_lblDaysOfMonth);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.textBox_SubTotaly);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.lblValue);
            this.panel2.Controls.Add(this.textBox_Count);
            this.panel2.Controls.Add(this.lblNumber);
            this.panel2.Controls.Add(this.comboBox_CalculateNo);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBox_DayOfMonth);
            this.panel2.Controls.Add(this.lblDaysOfMonth);
            this.panel2.Controls.Add(this.comboBox_SubTyp);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dateTimeInput_warnDate);
            this.panel2.Controls.Add(this.label54);
            this.panel2.Controls.Add(this.textBox_SubValue);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(649, 280);
            this.panel2.TabIndex = 6709;
            // 
            // checkBox_Minute
            // 
            this.checkBox_Minute.AutoSize = true;
            this.checkBox_Minute.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox_Minute.Location = new System.Drawing.Point(247, 95);
            this.checkBox_Minute.Name = "checkBox_Minute";
            this.checkBox_Minute.Size = new System.Drawing.Size(77, 17);
            this.checkBox_Minute.TabIndex = 6778;
            this.checkBox_Minute.Text = "??????????????????????????";
            this.checkBox_Minute.UseVisualStyleBackColor = true;
            this.checkBox_Minute.Visible = false;
            this.checkBox_Minute.CheckedChanged += new System.EventHandler(this.checkBox_Minute_CheckedChanged);
            // 
            // expandablePanel_Girds
            // 
            this.expandablePanel_Girds.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel_Girds.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft;
            this.expandablePanel_Girds.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanel_Girds.Controls.Add(this.expandablePanel_Emp);
            this.expandablePanel_Girds.Controls.Add(this.expandablePanel_Job);
            this.expandablePanel_Girds.Controls.Add(this.expandablePanel_Section);
            this.expandablePanel_Girds.Controls.Add(this.expandablePanel_Dept);
            this.expandablePanel_Girds.Dock = System.Windows.Forms.DockStyle.Left;
            this.expandablePanel_Girds.Expanded = false;
            this.expandablePanel_Girds.ExpandedBounds = new System.Drawing.Rectangle(0, 0, 314, 280);
            this.expandablePanel_Girds.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.expandablePanel_Girds.Location = new System.Drawing.Point(0, 0);
            this.expandablePanel_Girds.Name = "expandablePanel_Girds";
            this.expandablePanel_Girds.Size = new System.Drawing.Size(30, 280);
            this.expandablePanel_Girds.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_Girds.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandablePanel_Girds.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_Girds.Style.GradientAngle = 90;
            this.expandablePanel_Girds.TabIndex = 6777;
            this.expandablePanel_Girds.TitleStyle.Alignment = System.Drawing.StringAlignment.Far;
            this.expandablePanel_Girds.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel_Girds.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel_Girds.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel_Girds.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel_Girds.TitleStyle.GradientAngle = 90;
            this.expandablePanel_Girds.TitleStyle.MarginLeft = 6;
            this.expandablePanel_Girds.TitleText = "?????? ??????????????";
            // 
            // expandablePanel_Emp
            // 
            this.expandablePanel_Emp.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel_Emp.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanel_Emp.Controls.Add(this.itemPanel4);
            this.expandablePanel_Emp.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel_Emp.Expanded = false;
            this.expandablePanel_Emp.ExpandedBounds = new System.Drawing.Rectangle(0, 104, 314, 172);
            this.expandablePanel_Emp.ExpandOnTitleClick = true;
            this.expandablePanel_Emp.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.expandablePanel_Emp.Location = new System.Drawing.Point(0, 104);
            this.expandablePanel_Emp.Name = "expandablePanel_Emp";
            this.expandablePanel_Emp.Size = new System.Drawing.Size(30, 26);
            this.expandablePanel_Emp.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_Emp.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandablePanel_Emp.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel_Emp.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_Emp.Style.GradientAngle = 90;
            this.expandablePanel_Emp.TabIndex = 6;
            this.expandablePanel_Emp.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel_Emp.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel_Emp.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel_Emp.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel_Emp.TitleStyle.GradientAngle = 90;
            this.expandablePanel_Emp.TitleStyle.MarginLeft = 12;
            this.expandablePanel_Emp.TitleText = "????????????";
            // 
            // itemPanel4
            // 
            // 
            // 
            // 
            this.itemPanel4.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.itemPanel4.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel4.BackgroundStyle.BorderBottomWidth = 1;
            this.itemPanel4.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.itemPanel4.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel4.BackgroundStyle.BorderLeftWidth = 1;
            this.itemPanel4.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel4.BackgroundStyle.BorderRightWidth = 1;
            this.itemPanel4.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel4.BackgroundStyle.BorderTopWidth = 1;
            this.itemPanel4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel4.BackgroundStyle.PaddingBottom = 1;
            this.itemPanel4.BackgroundStyle.PaddingLeft = 1;
            this.itemPanel4.BackgroundStyle.PaddingRight = 1;
            this.itemPanel4.BackgroundStyle.PaddingTop = 1;
            this.itemPanel4.ContainerControlProcessDialogKey = true;
            this.itemPanel4.Controls.Add(this.dataGridViewX_Emp);
            this.itemPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPanel4.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel4.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel4.Location = new System.Drawing.Point(0, 26);
            this.itemPanel4.Name = "itemPanel4";
            this.itemPanel4.Size = new System.Drawing.Size(30, 0);
            this.itemPanel4.TabIndex = 3;
            this.itemPanel4.Text = "itemPanel4";
            // 
            // dataGridViewX_Emp
            // 
            this.dataGridViewX_Emp.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewX_Emp.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewX_Emp.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dataGridViewX_Emp.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewX_Emp.HScrollBarVisible = false;
            this.dataGridViewX_Emp.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.dataGridViewX_Emp.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX_Emp.Name = "dataGridViewX_Emp";
            this.dataGridViewX_Emp.PrimaryGrid.AllowRowHeaderResize = true;
            this.dataGridViewX_Emp.PrimaryGrid.AllowRowResize = true;
            this.dataGridViewX_Emp.PrimaryGrid.ColumnHeader.RowHeight = 30;
            this.dataGridViewX_Emp.PrimaryGrid.ColumnHeader.SortImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Emp.PrimaryGrid.ColumnHeader.Visible = false;
            gridColumn1.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn1.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.None;
            gridColumn1.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn1.Name = "*";
            gridColumn1.Width = 50;
            gridColumn2.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn2.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn2.FilterAutoScan = true;
            gridColumn2.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn2.InfoImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn2.Name = "?????? / ?????? ??????????????";
            gridColumn2.ReadOnly = true;
            gridColumn2.Width = 263;
            gridColumn3.ReadOnly = true;
            gridColumn3.Visible = false;
            this.dataGridViewX_Emp.PrimaryGrid.Columns.Add(gridColumn1);
            this.dataGridViewX_Emp.PrimaryGrid.Columns.Add(gridColumn2);
            this.dataGridViewX_Emp.PrimaryGrid.Columns.Add(gridColumn3);
            this.dataGridViewX_Emp.PrimaryGrid.DefaultRowHeight = 24;
            background1.Color1 = System.Drawing.Color.White;
            background1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewX_Emp.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = background1;
            background2.Color1 = System.Drawing.Color.White;
            background2.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewX_Emp.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background2;
            this.dataGridViewX_Emp.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Emp.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Emp.PrimaryGrid.EnableColumnFiltering = true;
            this.dataGridViewX_Emp.PrimaryGrid.EnableFiltering = true;
            this.dataGridViewX_Emp.PrimaryGrid.EnableRowFiltering = true;
            this.dataGridViewX_Emp.PrimaryGrid.Filter.Visible = true;
            this.dataGridViewX_Emp.PrimaryGrid.FilterLevel = ((DevComponents.DotNetBar.SuperGrid.FilterLevel)((DevComponents.DotNetBar.SuperGrid.FilterLevel.Root | DevComponents.DotNetBar.SuperGrid.FilterLevel.Expanded)));
            this.dataGridViewX_Emp.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.dataGridViewX_Emp.PrimaryGrid.MultiSelect = false;
            this.dataGridViewX_Emp.PrimaryGrid.NullString = "-----";
            this.dataGridViewX_Emp.PrimaryGrid.RowHeaderWidth = 45;
            this.dataGridViewX_Emp.PrimaryGrid.ShowColumnHeader = false;
            this.dataGridViewX_Emp.PrimaryGrid.ShowRowGridIndex = true;
            this.dataGridViewX_Emp.PrimaryGrid.ShowRowHeaders = false;
            this.dataGridViewX_Emp.PrimaryGrid.UseAlternateRowStyle = true;
            this.dataGridViewX_Emp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridViewX_Emp.Size = new System.Drawing.Size(313, 0);
            this.dataGridViewX_Emp.TabIndex = 481;
            // 
            // expandablePanel_Job
            // 
            this.expandablePanel_Job.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel_Job.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanel_Job.Controls.Add(this.itemPanel3);
            this.expandablePanel_Job.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel_Job.Expanded = false;
            this.expandablePanel_Job.ExpandedBounds = new System.Drawing.Rectangle(0, 78, 314, 179);
            this.expandablePanel_Job.ExpandOnTitleClick = true;
            this.expandablePanel_Job.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.expandablePanel_Job.Location = new System.Drawing.Point(0, 78);
            this.expandablePanel_Job.Name = "expandablePanel_Job";
            this.expandablePanel_Job.Size = new System.Drawing.Size(30, 26);
            this.expandablePanel_Job.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_Job.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandablePanel_Job.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel_Job.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_Job.Style.GradientAngle = 90;
            this.expandablePanel_Job.TabIndex = 5;
            this.expandablePanel_Job.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel_Job.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel_Job.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel_Job.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel_Job.TitleStyle.GradientAngle = 90;
            this.expandablePanel_Job.TitleStyle.MarginLeft = 12;
            this.expandablePanel_Job.TitleText = "??????????????";
            // 
            // itemPanel3
            // 
            // 
            // 
            // 
            this.itemPanel3.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.itemPanel3.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel3.BackgroundStyle.BorderBottomWidth = 1;
            this.itemPanel3.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.itemPanel3.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel3.BackgroundStyle.BorderLeftWidth = 1;
            this.itemPanel3.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel3.BackgroundStyle.BorderRightWidth = 1;
            this.itemPanel3.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel3.BackgroundStyle.BorderTopWidth = 1;
            this.itemPanel3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel3.BackgroundStyle.PaddingBottom = 1;
            this.itemPanel3.BackgroundStyle.PaddingLeft = 1;
            this.itemPanel3.BackgroundStyle.PaddingRight = 1;
            this.itemPanel3.BackgroundStyle.PaddingTop = 1;
            this.itemPanel3.ContainerControlProcessDialogKey = true;
            this.itemPanel3.Controls.Add(this.dataGridViewX_Job);
            this.itemPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPanel3.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel3.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel3.Location = new System.Drawing.Point(0, 26);
            this.itemPanel3.Name = "itemPanel3";
            this.itemPanel3.Size = new System.Drawing.Size(30, 0);
            this.itemPanel3.TabIndex = 3;
            this.itemPanel3.Text = "itemPanel3";
            // 
            // dataGridViewX_Job
            // 
            this.dataGridViewX_Job.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewX_Job.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewX_Job.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dataGridViewX_Job.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewX_Job.HScrollBarVisible = false;
            this.dataGridViewX_Job.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.dataGridViewX_Job.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX_Job.Name = "dataGridViewX_Job";
            this.dataGridViewX_Job.PrimaryGrid.AllowRowHeaderResize = true;
            this.dataGridViewX_Job.PrimaryGrid.AllowRowResize = true;
            this.dataGridViewX_Job.PrimaryGrid.ColumnHeader.RowHeight = 30;
            this.dataGridViewX_Job.PrimaryGrid.ColumnHeader.SortImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Job.PrimaryGrid.ColumnHeader.Visible = false;
            gridColumn4.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn4.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn4.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.None;
            gridColumn4.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn4.Name = "*";
            gridColumn4.Width = 50;
            gridColumn5.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn5.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn5.FilterAutoScan = true;
            gridColumn5.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn5.InfoImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn5.Name = "?????? / ?????? ??????????????";
            gridColumn5.ReadOnly = true;
            gridColumn5.Width = 263;
            gridColumn6.ReadOnly = true;
            gridColumn6.Visible = false;
            this.dataGridViewX_Job.PrimaryGrid.Columns.Add(gridColumn4);
            this.dataGridViewX_Job.PrimaryGrid.Columns.Add(gridColumn5);
            this.dataGridViewX_Job.PrimaryGrid.Columns.Add(gridColumn6);
            this.dataGridViewX_Job.PrimaryGrid.DefaultRowHeight = 24;
            background3.Color1 = System.Drawing.Color.White;
            background3.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewX_Job.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = background3;
            background4.Color1 = System.Drawing.Color.White;
            background4.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewX_Job.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background4;
            this.dataGridViewX_Job.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Job.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Job.PrimaryGrid.EnableColumnFiltering = true;
            this.dataGridViewX_Job.PrimaryGrid.EnableFiltering = true;
            this.dataGridViewX_Job.PrimaryGrid.EnableRowFiltering = true;
            this.dataGridViewX_Job.PrimaryGrid.Filter.Visible = true;
            this.dataGridViewX_Job.PrimaryGrid.FilterLevel = ((DevComponents.DotNetBar.SuperGrid.FilterLevel)((DevComponents.DotNetBar.SuperGrid.FilterLevel.Root | DevComponents.DotNetBar.SuperGrid.FilterLevel.Expanded)));
            this.dataGridViewX_Job.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.dataGridViewX_Job.PrimaryGrid.MultiSelect = false;
            this.dataGridViewX_Job.PrimaryGrid.NullString = "-----";
            this.dataGridViewX_Job.PrimaryGrid.RowHeaderWidth = 45;
            this.dataGridViewX_Job.PrimaryGrid.ShowColumnHeader = false;
            this.dataGridViewX_Job.PrimaryGrid.ShowRowGridIndex = true;
            this.dataGridViewX_Job.PrimaryGrid.ShowRowHeaders = false;
            this.dataGridViewX_Job.PrimaryGrid.UseAlternateRowStyle = true;
            this.dataGridViewX_Job.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridViewX_Job.Size = new System.Drawing.Size(313, 0);
            this.dataGridViewX_Job.TabIndex = 481;
            // 
            // expandablePanel_Section
            // 
            this.expandablePanel_Section.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel_Section.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanel_Section.Controls.Add(this.itemPanel2);
            this.expandablePanel_Section.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel_Section.Expanded = false;
            this.expandablePanel_Section.ExpandedBounds = new System.Drawing.Rectangle(0, 52, 314, 179);
            this.expandablePanel_Section.ExpandOnTitleClick = true;
            this.expandablePanel_Section.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.expandablePanel_Section.Location = new System.Drawing.Point(0, 52);
            this.expandablePanel_Section.Name = "expandablePanel_Section";
            this.expandablePanel_Section.Size = new System.Drawing.Size(30, 26);
            this.expandablePanel_Section.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_Section.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandablePanel_Section.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel_Section.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_Section.Style.GradientAngle = 90;
            this.expandablePanel_Section.TabIndex = 4;
            this.expandablePanel_Section.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel_Section.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel_Section.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel_Section.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel_Section.TitleStyle.GradientAngle = 90;
            this.expandablePanel_Section.TitleStyle.MarginLeft = 12;
            this.expandablePanel_Section.TitleText = "??????????";
            // 
            // itemPanel2
            // 
            // 
            // 
            // 
            this.itemPanel2.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.itemPanel2.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel2.BackgroundStyle.BorderBottomWidth = 1;
            this.itemPanel2.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.itemPanel2.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel2.BackgroundStyle.BorderLeftWidth = 1;
            this.itemPanel2.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel2.BackgroundStyle.BorderRightWidth = 1;
            this.itemPanel2.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel2.BackgroundStyle.BorderTopWidth = 1;
            this.itemPanel2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel2.BackgroundStyle.PaddingBottom = 1;
            this.itemPanel2.BackgroundStyle.PaddingLeft = 1;
            this.itemPanel2.BackgroundStyle.PaddingRight = 1;
            this.itemPanel2.BackgroundStyle.PaddingTop = 1;
            this.itemPanel2.ContainerControlProcessDialogKey = true;
            this.itemPanel2.Controls.Add(this.dataGridViewX_Section);
            this.itemPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPanel2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel2.Location = new System.Drawing.Point(0, 26);
            this.itemPanel2.Name = "itemPanel2";
            this.itemPanel2.Size = new System.Drawing.Size(30, 0);
            this.itemPanel2.TabIndex = 3;
            this.itemPanel2.Text = "itemPanel2";
            // 
            // dataGridViewX_Section
            // 
            this.dataGridViewX_Section.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewX_Section.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewX_Section.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dataGridViewX_Section.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewX_Section.HScrollBarVisible = false;
            this.dataGridViewX_Section.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.dataGridViewX_Section.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX_Section.Name = "dataGridViewX_Section";
            this.dataGridViewX_Section.PrimaryGrid.AllowRowHeaderResize = true;
            this.dataGridViewX_Section.PrimaryGrid.AllowRowResize = true;
            this.dataGridViewX_Section.PrimaryGrid.ColumnHeader.RowHeight = 30;
            this.dataGridViewX_Section.PrimaryGrid.ColumnHeader.SortImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Section.PrimaryGrid.ColumnHeader.Visible = false;
            gridColumn7.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn7.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn7.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.None;
            gridColumn7.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn7.Name = "*";
            gridColumn7.Width = 50;
            gridColumn8.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn8.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn8.FilterAutoScan = true;
            gridColumn8.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn8.InfoImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn8.Name = "?????? / ?????? ??????????????";
            gridColumn8.ReadOnly = true;
            gridColumn8.Width = 263;
            gridColumn9.ReadOnly = true;
            gridColumn9.Visible = false;
            this.dataGridViewX_Section.PrimaryGrid.Columns.Add(gridColumn7);
            this.dataGridViewX_Section.PrimaryGrid.Columns.Add(gridColumn8);
            this.dataGridViewX_Section.PrimaryGrid.Columns.Add(gridColumn9);
            this.dataGridViewX_Section.PrimaryGrid.DefaultRowHeight = 24;
            background5.Color1 = System.Drawing.Color.White;
            background5.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewX_Section.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = background5;
            background6.Color1 = System.Drawing.Color.White;
            background6.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewX_Section.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background6;
            this.dataGridViewX_Section.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Section.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Section.PrimaryGrid.EnableColumnFiltering = true;
            this.dataGridViewX_Section.PrimaryGrid.EnableFiltering = true;
            this.dataGridViewX_Section.PrimaryGrid.EnableRowFiltering = true;
            this.dataGridViewX_Section.PrimaryGrid.Filter.Visible = true;
            this.dataGridViewX_Section.PrimaryGrid.FilterLevel = ((DevComponents.DotNetBar.SuperGrid.FilterLevel)((DevComponents.DotNetBar.SuperGrid.FilterLevel.Root | DevComponents.DotNetBar.SuperGrid.FilterLevel.Expanded)));
            this.dataGridViewX_Section.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.dataGridViewX_Section.PrimaryGrid.MultiSelect = false;
            this.dataGridViewX_Section.PrimaryGrid.NullString = "-----";
            this.dataGridViewX_Section.PrimaryGrid.RowHeaderWidth = 45;
            this.dataGridViewX_Section.PrimaryGrid.ShowColumnHeader = false;
            this.dataGridViewX_Section.PrimaryGrid.ShowRowGridIndex = true;
            this.dataGridViewX_Section.PrimaryGrid.ShowRowHeaders = false;
            this.dataGridViewX_Section.PrimaryGrid.UseAlternateRowStyle = true;
            this.dataGridViewX_Section.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridViewX_Section.Size = new System.Drawing.Size(313, 0);
            this.dataGridViewX_Section.TabIndex = 481;
            // 
            // expandablePanel_Dept
            // 
            this.expandablePanel_Dept.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel_Dept.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.expandablePanel_Dept.Controls.Add(this.itemPanel1);
            this.expandablePanel_Dept.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandablePanel_Dept.Expanded = false;
            this.expandablePanel_Dept.ExpandedBounds = new System.Drawing.Rectangle(0, 26, 314, 179);
            this.expandablePanel_Dept.ExpandOnTitleClick = true;
            this.expandablePanel_Dept.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.expandablePanel_Dept.Location = new System.Drawing.Point(0, 26);
            this.expandablePanel_Dept.Name = "expandablePanel_Dept";
            this.expandablePanel_Dept.Size = new System.Drawing.Size(30, 26);
            this.expandablePanel_Dept.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_Dept.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandablePanel_Dept.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel_Dept.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_Dept.Style.GradientAngle = 90;
            this.expandablePanel_Dept.TabIndex = 3;
            this.expandablePanel_Dept.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel_Dept.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel_Dept.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel_Dept.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel_Dept.TitleStyle.GradientAngle = 90;
            this.expandablePanel_Dept.TitleStyle.MarginLeft = 12;
            this.expandablePanel_Dept.TitleText = "??????????????";
            // 
            // itemPanel1
            // 
            // 
            // 
            // 
            this.itemPanel1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.itemPanel1.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel1.BackgroundStyle.BorderBottomWidth = 1;
            this.itemPanel1.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
            this.itemPanel1.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel1.BackgroundStyle.BorderLeftWidth = 1;
            this.itemPanel1.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel1.BackgroundStyle.BorderRightWidth = 1;
            this.itemPanel1.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemPanel1.BackgroundStyle.BorderTopWidth = 1;
            this.itemPanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel1.BackgroundStyle.PaddingBottom = 1;
            this.itemPanel1.BackgroundStyle.PaddingLeft = 1;
            this.itemPanel1.BackgroundStyle.PaddingRight = 1;
            this.itemPanel1.BackgroundStyle.PaddingTop = 1;
            this.itemPanel1.ContainerControlProcessDialogKey = true;
            this.itemPanel1.Controls.Add(this.dataGridViewX_Dept);
            this.itemPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel1.Location = new System.Drawing.Point(0, 26);
            this.itemPanel1.Name = "itemPanel1";
            this.itemPanel1.Size = new System.Drawing.Size(30, 0);
            this.itemPanel1.TabIndex = 3;
            this.itemPanel1.Text = "itemPanel1";
            // 
            // dataGridViewX_Dept
            // 
            this.dataGridViewX_Dept.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewX_Dept.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewX_Dept.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.dataGridViewX_Dept.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewX_Dept.HScrollBarVisible = false;
            this.dataGridViewX_Dept.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.dataGridViewX_Dept.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX_Dept.Name = "dataGridViewX_Dept";
            this.dataGridViewX_Dept.PrimaryGrid.AllowRowHeaderResize = true;
            this.dataGridViewX_Dept.PrimaryGrid.AllowRowResize = true;
            this.dataGridViewX_Dept.PrimaryGrid.ColumnHeader.RowHeight = 30;
            this.dataGridViewX_Dept.PrimaryGrid.ColumnHeader.SortImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Dept.PrimaryGrid.ColumnHeader.Visible = false;
            gridColumn10.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn10.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn10.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.None;
            gridColumn10.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn10.Name = "*";
            gridColumn10.Width = 50;
            gridColumn11.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft;
            gridColumn11.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
            gridColumn11.FilterAutoScan = true;
            gridColumn11.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn11.InfoImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn11.Name = "?????? / ?????? ??????????????";
            gridColumn11.ReadOnly = true;
            gridColumn11.Width = 263;
            gridColumn12.ReadOnly = true;
            gridColumn12.Visible = false;
            this.dataGridViewX_Dept.PrimaryGrid.Columns.Add(gridColumn10);
            this.dataGridViewX_Dept.PrimaryGrid.Columns.Add(gridColumn11);
            this.dataGridViewX_Dept.PrimaryGrid.Columns.Add(gridColumn12);
            this.dataGridViewX_Dept.PrimaryGrid.DefaultRowHeight = 24;
            background7.Color1 = System.Drawing.Color.White;
            background7.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewX_Dept.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Background = background7;
            background8.Color1 = System.Drawing.Color.White;
            background8.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewX_Dept.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background8;
            this.dataGridViewX_Dept.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Dept.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.dataGridViewX_Dept.PrimaryGrid.EnableColumnFiltering = true;
            this.dataGridViewX_Dept.PrimaryGrid.EnableFiltering = true;
            this.dataGridViewX_Dept.PrimaryGrid.EnableRowFiltering = true;
            this.dataGridViewX_Dept.PrimaryGrid.Filter.Visible = true;
            this.dataGridViewX_Dept.PrimaryGrid.FilterLevel = ((DevComponents.DotNetBar.SuperGrid.FilterLevel)((DevComponents.DotNetBar.SuperGrid.FilterLevel.Root | DevComponents.DotNetBar.SuperGrid.FilterLevel.Expanded)));
            this.dataGridViewX_Dept.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions;
            this.dataGridViewX_Dept.PrimaryGrid.MultiSelect = false;
            this.dataGridViewX_Dept.PrimaryGrid.NullString = "-----";
            this.dataGridViewX_Dept.PrimaryGrid.RowHeaderWidth = 45;
            this.dataGridViewX_Dept.PrimaryGrid.ShowColumnHeader = false;
            this.dataGridViewX_Dept.PrimaryGrid.ShowRowGridIndex = true;
            this.dataGridViewX_Dept.PrimaryGrid.ShowRowHeaders = false;
            this.dataGridViewX_Dept.PrimaryGrid.UseAlternateRowStyle = true;
            this.dataGridViewX_Dept.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridViewX_Dept.Size = new System.Drawing.Size(313, 0);
            this.dataGridViewX_Dept.TabIndex = 481;
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
            this.textBox_Note.Location = new System.Drawing.Point(69, 199);
            this.textBox_Note.Multiline = true;
            this.textBox_Note.Name = "textBox_Note";
            this.textBox_Note.Size = new System.Drawing.Size(423, 67);
            this.textBox_Note.TabIndex = 9;
            this.textBox_Note.WatermarkColor = System.Drawing.Color.RosyBrown;
            this.textBox_Note.WatermarkFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Note.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.textBox_Note.WatermarkText = "???????????????????????????? ??????????????????????";
            // 
            // textBox_SalDate
            // 
            this.textBox_SalDate.BackColor = System.Drawing.Color.Red;
            this.textBox_SalDate.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textBox_SalDate.ForeColor = System.Drawing.Color.White;
            this.textBox_SalDate.Location = new System.Drawing.Point(73, 127);
            this.textBox_SalDate.Mask = "0000/00";
            this.textBox_SalDate.Name = "textBox_SalDate";
            this.textBox_SalDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_SalDate.Size = new System.Drawing.Size(49, 21);
            this.textBox_SalDate.TabIndex = 7;
            this.textBox_SalDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_SalDate.Click += new System.EventHandler(this.textBox_SalDate_Click);
            this.textBox_SalDate.Leave += new System.EventHandler(this.textBox_SalDate_Leave);
            // 
            // label_lblDaysOfMonth
            // 
            this.label_lblDaysOfMonth.AutoSize = true;
            this.label_lblDaysOfMonth.BackColor = System.Drawing.Color.Transparent;
            this.label_lblDaysOfMonth.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label_lblDaysOfMonth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_lblDaysOfMonth.Location = new System.Drawing.Point(123, 131);
            this.label_lblDaysOfMonth.Name = "label_lblDaysOfMonth";
            this.label_lblDaysOfMonth.Size = new System.Drawing.Size(109, 13);
            this.label_lblDaysOfMonth.TabIndex = 6731;
            this.label_lblDaysOfMonth.Text = "???????? ???? ???????? ???????? :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(496, 199);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 6728;
            this.label9.Text = "?????????????????????????? :";
            // 
            // textBox_SubTotaly
            // 
            this.textBox_SubTotaly.AllowEmptyState = false;
            this.textBox_SubTotaly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_SubTotaly.AutoOffFreeTextEntry = true;
            this.textBox_SubTotaly.AutoResolveFreeTextEntries = false;
            // 
            // 
            // 
            this.textBox_SubTotaly.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.textBox_SubTotaly.BackgroundStyle.BorderBottomWidth = 1;
            this.textBox_SubTotaly.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_SubTotaly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_SubTotaly.BackgroundStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_SubTotaly.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_SubTotaly.DisplayFormat = "0.00";
            this.textBox_SubTotaly.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_SubTotaly.Increment = 1D;
            this.textBox_SubTotaly.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_SubTotaly.IsInputReadOnly = true;
            this.textBox_SubTotaly.Location = new System.Drawing.Point(69, 161);
            this.textBox_SubTotaly.Name = "textBox_SubTotaly";
            this.textBox_SubTotaly.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_SubTotaly.Size = new System.Drawing.Size(423, 21);
            this.textBox_SubTotaly.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(496, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 6726;
            this.label8.Text = "?????????????????????????????? :";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.BackColor = System.Drawing.Color.Transparent;
            this.lblValue.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblValue.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblValue.Location = new System.Drawing.Point(325, 131);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(69, 13);
            this.lblValue.TabIndex = 6725;
            this.lblValue.Text = "???????? ?????????? :";
            // 
            // textBox_Count
            // 
            this.textBox_Count.AllowEmptyState = false;
            this.textBox_Count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Count.AutoOffFreeTextEntry = true;
            this.textBox_Count.AutoResolveFreeTextEntries = false;
            // 
            // 
            // 
            this.textBox_Count.BackgroundStyle.BorderBottomWidth = 1;
            this.textBox_Count.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_Count.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_Count.BackgroundStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Count.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_Count.DisplayFormat = "0.00";
            this.textBox_Count.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_Count.Increment = 1D;
            this.textBox_Count.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_Count.Location = new System.Drawing.Point(426, 127);
            this.textBox_Count.Name = "textBox_Count";
            this.textBox_Count.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_Count.Size = new System.Drawing.Size(66, 21);
            this.textBox_Count.TabIndex = 5;
            this.textBox_Count.ValueChanged += new System.EventHandler(this.textBox_Count_ValueChanged);
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblNumber.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblNumber.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNumber.Location = new System.Drawing.Point(496, 131);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(37, 13);
            this.lblNumber.TabIndex = 6723;
            this.lblNumber.Text = "?????????? :";
            // 
            // comboBox_CalculateNo
            // 
            this.comboBox_CalculateNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_CalculateNo.DisplayMember = "Text";
            this.comboBox_CalculateNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_CalculateNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CalculateNo.FormattingEnabled = true;
            this.comboBox_CalculateNo.ItemHeight = 14;
            this.comboBox_CalculateNo.Location = new System.Drawing.Point(74, 59);
            this.comboBox_CalculateNo.Name = "comboBox_CalculateNo";
            this.comboBox_CalculateNo.Size = new System.Drawing.Size(418, 20);
            this.comboBox_CalculateNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_CalculateNo.TabIndex = 2;
            this.comboBox_CalculateNo.SelectedValueChanged += new System.EventHandler(this.comboBox_CalculateNo_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(496, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 6721;
            this.label2.Text = "???????????? ?????? :";
            // 
            // textBox_DayOfMonth
            // 
            this.textBox_DayOfMonth.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_DayOfMonth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_DayOfMonth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_DayOfMonth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_DayOfMonth.DisplayFormat = "0";
            this.textBox_DayOfMonth.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_DayOfMonth.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_DayOfMonth.Location = new System.Drawing.Point(74, 93);
            this.textBox_DayOfMonth.MaxValue = 31;
            this.textBox_DayOfMonth.MinValue = 1;
            this.textBox_DayOfMonth.Name = "textBox_DayOfMonth";
            this.textBox_DayOfMonth.Size = new System.Drawing.Size(48, 21);
            this.textBox_DayOfMonth.TabIndex = 4;
            this.textBox_DayOfMonth.Value = 1;
            this.textBox_DayOfMonth.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Center;
            this.textBox_DayOfMonth.ValueChanged += new System.EventHandler(this.textBox_DayOfMonth_ValueChanged);
            // 
            // lblDaysOfMonth
            // 
            this.lblDaysOfMonth.AutoSize = true;
            this.lblDaysOfMonth.BackColor = System.Drawing.Color.Transparent;
            this.lblDaysOfMonth.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblDaysOfMonth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDaysOfMonth.Location = new System.Drawing.Point(123, 97);
            this.lblDaysOfMonth.Name = "lblDaysOfMonth";
            this.lblDaysOfMonth.Size = new System.Drawing.Size(109, 13);
            this.lblDaysOfMonth.TabIndex = 6719;
            this.lblDaysOfMonth.Text = "?????? ???????????? ???? ?????????? :";
            // 
            // comboBox_SubTyp
            // 
            this.comboBox_SubTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_SubTyp.DisplayMember = "Text";
            this.comboBox_SubTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_SubTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SubTyp.FormattingEnabled = true;
            this.comboBox_SubTyp.ItemHeight = 14;
            this.comboBox_SubTyp.Location = new System.Drawing.Point(327, 93);
            this.comboBox_SubTyp.Name = "comboBox_SubTyp";
            this.comboBox_SubTyp.Size = new System.Drawing.Size(165, 20);
            this.comboBox_SubTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_SubTyp.TabIndex = 3;
            this.comboBox_SubTyp.SelectedValueChanged += new System.EventHandler(this.comboBox_SubTyp_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(496, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 6717;
            this.label1.Text = "?????? ?????????? :";
            // 
            // dateTimeInput_warnDate
            // 
            this.dateTimeInput_warnDate.Location = new System.Drawing.Point(339, 25);
            this.dateTimeInput_warnDate.Mask = "0000/00/00";
            this.dateTimeInput_warnDate.Name = "dateTimeInput_warnDate";
            this.dateTimeInput_warnDate.Size = new System.Drawing.Size(153, 20);
            this.dateTimeInput_warnDate.TabIndex = 1;
            this.dateTimeInput_warnDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_warnDate.Click += new System.EventHandler(this.dateTimeInput_warnDate_Click);
            this.dateTimeInput_warnDate.Leave += new System.EventHandler(this.dateTimeInput_warnDate_Leave);
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.BackColor = System.Drawing.Color.Transparent;
            this.label54.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label54.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label54.Location = new System.Drawing.Point(496, 29);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(42, 13);
            this.label54.TabIndex = 6712;
            this.label54.Text = "?????????????? :";
            // 
            // textBox_SubValue
            // 
            this.textBox_SubValue.AllowEmptyState = false;
            this.textBox_SubValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_SubValue.AutoOffFreeTextEntry = true;
            this.textBox_SubValue.AutoResolveFreeTextEntries = false;
            // 
            // 
            // 
            this.textBox_SubValue.BackgroundStyle.BorderBottomWidth = 1;
            this.textBox_SubValue.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_SubValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_SubValue.BackgroundStyle.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_SubValue.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_SubValue.DisplayFormat = "0.00";
            this.textBox_SubValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_SubValue.Increment = 1D;
            this.textBox_SubValue.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_SubValue.Location = new System.Drawing.Point(258, 127);
            this.textBox_SubValue.Name = "textBox_SubValue";
            this.textBox_SubValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_SubValue.Size = new System.Drawing.Size(66, 21);
            this.textBox_SubValue.TabIndex = 6;
            this.textBox_SubValue.ValueChanged += new System.EventHandler(this.textBox_SubValue_ValueChanged);
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
            this.ribbonBar_Tasks.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ribbonBar_Tasks.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar_Tasks.Location = new System.Drawing.Point(0, 297);
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
            this.superTabControl_Main1.Size = new System.Drawing.Size(649, 51);
            this.superTabControl_Main1.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_Main1.TabIndex = 10;
            this.superTabControl_Main1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.Button_Close,
            this.Button_Save,
            this.labelItem2});
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
            this.Button_Close.Symbol = "???";
            this.Button_Close.SymbolSize = 15F;
            this.Button_Close.Text = "??????????";
            this.Button_Close.Tooltip = "?????????? ?????????????? ??????????????";
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
            this.Button_Save.Symbol = "???";
            this.Button_Save.SymbolSize = 15F;
            this.Button_Save.Text = "??????";
            this.Button_Save.Tooltip = "?????? ??????????????????";
            // 
            // labelItem2
            // 
            this.labelItem2.Name = "labelItem2";
            this.labelItem2.Width = 40;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "*.rtf";
            this.saveFileDialog1.FileName = "doc1";
            this.saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf|All Files(*.*)|*.*";
            this.saveFileDialog1.FilterIndex = 2;
            this.saveFileDialog1.Title = "Save File";
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
            this.panel1.Controls.Add(this.expandableSplitter1);
            this.panel1.Controls.Add(this.panelEx2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(649, 361);
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
            this.barBottomDockSite.Location = new System.Drawing.Point(0, 361);
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
            this.barLeftDockSite.Size = new System.Drawing.Size(0, 361);
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
            this.barRightDockSite.Size = new System.Drawing.Size(0, 361);
            this.barRightDockSite.TabIndex = 892;
            this.barRightDockSite.TabStop = false;
            // 
            // dockSite4
            // 
            this.dockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite4.Location = new System.Drawing.Point(0, 361);
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
            this.dockSite1.Size = new System.Drawing.Size(0, 361);
            this.dockSite1.TabIndex = 893;
            this.dockSite1.TabStop = false;
            // 
            // dockSite2
            // 
            this.dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite2.Location = new System.Drawing.Point(649, 0);
            this.dockSite2.Name = "dockSite2";
            this.dockSite2.Size = new System.Drawing.Size(0, 361);
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
            this.ToolStripMenuItem_Rep.Text = "?????????? ??????????????";
            // 
            // ToolStripMenuItem_Det
            // 
            this.ToolStripMenuItem_Det.Name = "ToolStripMenuItem_Det";
            this.ToolStripMenuItem_Det.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem_Det.Text = "?????????? ????????????????";
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
            // FrmDisGeneral
            // 
            this.ClientSize = new System.Drawing.Size(649, 361);
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
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmDisGeneral";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "?????????????????? ??????????????????????";
            this.Load += new System.EventHandler(this.FrmDisGeneral_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.panelEx2.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.expandablePanel_Girds.ResumeLayout(false);
            this.expandablePanel_Emp.ResumeLayout(false);
            this.itemPanel4.ResumeLayout(false);
            this.expandablePanel_Job.ResumeLayout(false);
            this.itemPanel3.ResumeLayout(false);
            this.expandablePanel_Section.ResumeLayout(false);
            this.itemPanel2.ResumeLayout(false);
            this.expandablePanel_Dept.ResumeLayout(false);
            this.itemPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textBox_SubTotaly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_Count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_DayOfMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_SubValue)).EndInit();
            this.ribbonBar_Tasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.ResumeLayout(false);
        }
    }
}
