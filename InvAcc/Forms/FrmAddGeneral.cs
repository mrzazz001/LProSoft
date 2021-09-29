using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.Editors;
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
    public partial  class FrmAddGeneral : Form
    { void avs(int arln)

{ 
 panelEx2.Text=   (arln == 0 ? "  Click to collapse  " : "  Click to collapse") ; checkBox_Minute.Text=   (arln == 0 ? "  بالدقـــائــق  " : "  in minutes") ; itemPanel4.Text=   (arln == 0 ? "  itemPanel4  " : "  itemPanel4") ; itemPanel3.Text=   (arln == 0 ? "  itemPanel3  " : "  itemPanel3") ; itemPanel2.Text=   (arln == 0 ? "  itemPanel2  " : "  itemPanel2") ; itemPanel1.Text=   (arln == 0 ? "  itemPanel1  " : "  itemPanel1") ; label_lblDaysOfMonth.Text=   (arln == 0 ? "  يضاف الى راتب شهر :  " : "  In addition to a month's salary:") ; label6.Text=   (arln == 0 ? "  قيمة الإضافي :  " : "  Additional value:") ; label_DaysAcountInMonth.Text=   (arln == 0 ? "  عدد الأيام في الشهر :  " : "  Number of days in a month:") ; label9.Text=   (arln == 0 ? "  الملاحظــــات :  " : "  Notes:") ; label8.Text=   (arln == 0 ? "  الإجمالـــــــي :  " : "  Total:") ; label5.Text=   (arln == 0 ? "  الــعــــــــــدد :  " : "  number:") ; label2.Text=   (arln == 0 ? "  احتساب حسب :  " : "  Calculate by:") ; label1.Text=   (arln == 0 ? "  نوع الاضافي :  " : "  Extra type:") ; label54.Text=   (arln == 0 ? "  التاريخ :  " : "  Date :") ; superTabControl_Main1.Text=   (arln == 0 ? "  superTabControl3  " : "  superTabControl3") ; Button_Close.Text=   (arln == 0 ? "  إغلاق  " : "  Close") ; Button_Save.Text=   (arln == 0 ? "  حفظ  " : "  save") ; ToolStripMenuItem_Rep.Text=   (arln == 0 ? "  إظهار التقرير  " : "  Show report") ; ToolStripMenuItem_Det.Text=   (arln == 0 ? "  إظهار التفاصيل  " : "  Show details") ; Text = "كــــــرت الإضافــــــــي";this.Text=   (arln == 0 ? "  كــــــرت الإضافــــــــي  " : "  Added card") ;}
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
        private Timer timer1;
        private ExpandableSplitter expandableSplitter1;
        private PanelEx panelEx2;
        private RibbonBar ribbonBar1;
        private System.Windows.Forms. SaveFileDialog saveFileDialog1;
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
        private SuperTabControl superTabControl_Main1;
        protected ButtonItem Button_Close;
        protected ButtonItem Button_Save;
        protected LabelItem labelItem2;
        private Panel panel2;
        private MaskedTextBox textBox_SalDate;
        private Label label_lblDaysOfMonth;
        private Label label9;
        private DoubleInput textBox_AddTotaly;
        private DoubleInput textBox_AddValue;
        private Label label8;
        private Label label6;
        private DoubleInput textBox_Count;
        private Label label5;
        private ComboBoxEx comboBox_CalculateNo;
        private Label label2;
        private IntegerInput textBox_DayOfMonth;
        private Label label_DaysAcountInMonth;
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
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private T_AccDef _AccDefBind = new T_AccDef();
        private int LangArEn = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
#pragma warning disable CS0414 // The field 'FrmAddGeneral.FlagUpdate' is assigned but its value is never used
        private string FlagUpdate = "";
#pragma warning restore CS0414 // The field 'FrmAddGeneral.FlagUpdate' is assigned but its value is never used
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstance;
        private T_Add data_this;
        private Rate_DataDataContext dbInstanceRate;
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
        public T_Add DataThis
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
                if (MessageBox.Show((LangArEn == 0) ? "تم تعديل السجل الحالي دون حفظ التغييرات .. هل تريد المتابعة؟" : "Not saved the changes, do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
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
        public FrmAddGeneral()
        {
            InitializeComponent();this.Load += langloads;
            ADD_Controls();
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Button_Close.Text = "اغلاق";
                Button_Save.Text = "حفظ";
                Button_Close.Tooltip = "Esc";
                Button_Save.Tooltip = "F2";
                textBox_Note.WatermarkText = "ملاحظـــــــات الإضـــافـــي";
                Text = "كرت الإضافـــــي";
            }
            else
            {
                Button_Close.Text = "Close";
                Button_Save.Text = "Save";
                Button_Close.Tooltip = "Esc";
                Button_Save.Tooltip = "F2";
                textBox_Note.WatermarkText = "Notes";
                Text = "ADD Card";
            }
        }
        private void FrmAddGeneral_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmAddGeneral));
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
                catch (Exception error2)
                {
                    VarGeneral.DebLog.writeLog("FrmAddGeneral_Load:", error2, enable: true);
                    MessageBox.Show(error2.Message);
                }
            }
            catch (Exception error2)
            {
                VarGeneral.DebLog.writeLog("Load:", error2, enable: true);
                MessageBox.Show(error2.Message);
            }
        }
        private void SuperGridColumns()
        {
            dataGridViewX_Emp.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "الموظف" : "Employee");
            dataGridViewX_Dept.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "الادارة" : "Management");
            dataGridViewX_Job.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "الوظيفة" : "Job");
            dataGridViewX_Section.PrimaryGrid.Columns[1].HeaderText = ((LangArEn == 0) ? "القسم" : "Section");
            dataGridViewX_Emp.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Background.Color1 = SystemColors.ActiveCaption;
            dataGridViewX_Dept.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Background.Color1 = SystemColors.ActiveCaption;
            dataGridViewX_Job.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Background.Color1 = SystemColors.ActiveCaption;
            dataGridViewX_Section.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Background.Color1 = SystemColors.ActiveCaption;
            dataGridViewX_Emp.PrimaryGrid.UseAlternateColumnStyle = false;
            dataGridViewX_Dept.PrimaryGrid.UseAlternateColumnStyle = false;
            dataGridViewX_Job.PrimaryGrid.UseAlternateColumnStyle = false;
            dataGridViewX_Section.PrimaryGrid.UseAlternateColumnStyle = false;
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
        public void FillCombo()
        {
            List<T_OpMethod> listOpMethod = new List<T_OpMethod>((from item in db.T_OpMethods
                                                                  orderby item.Method_No
                                                                  where item.Method_No != 8 && item.Method_No != 9 && item.Method_No != 10 && item.Method_No != 10 && item.Method_No != 11 && item.Method_No != 12 && item.Method_No != 13
                                                                  select item).ToList());
            comboBox_CalculateNo.DataSource = listOpMethod;
            comboBox_CalculateNo.DisplayMember = ((LangArEn == 0) ? "Name" : "NameE");
            comboBox_CalculateNo.ValueMember = "Method_No";
            List<T_AddTyp> listAddTyp = new List<T_AddTyp>(db.T_AddTyps.Select((T_AddTyp item) => item).ToList());
            comboBox_SubTyp.DataSource = listAddTyp;
            comboBox_SubTyp.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_SubTyp.ValueMember = "AddTyp_No";
        }
        public void Clear()
        {
            if (State == FormState.New)
            {
                return;
            }
            State = FormState.New;
            data_this = new T_Add();
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
        private T_Add GetData()
        {
            dateTimeInput_warnDate.Focus();
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
                data_this.CountDay = textBox_Count.Value;
            }
            catch
            {
                data_this.CountDay = 0.0;
            }
            try
            {
                data_this.DayOfMonth = textBox_DayOfMonth.Value;
            }
            catch
            {
                data_this.DayOfMonth = 0;
            }
            try
            {
                data_this.AddValue = textBox_AddValue.Value;
            }
            catch
            {
                data_this.AddValue = 0.0;
            }
            try
            {
                data_this.AddTotaly = textBox_AddTotaly.Value;
            }
            catch
            {
                data_this.AddTotaly = 0.0;
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
                data_this.AddTyp = int.Parse(comboBox_SubTyp.SelectedValue.ToString());
            }
            catch
            {
                data_this.AddTyp = null;
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
        private void dateTimeInput_warnDate_Click(object sender, EventArgs e)
        {
            dateTimeInput_warnDate.SelectAll();
        }
        private void textBox_SalDate_Click(object sender, EventArgs e)
        {
            textBox_SalDate.SelectAll();
        }
        private void textBox_DayOfMonth_ValueChanged(object sender, EventArgs e)
        {
            if (textBox_DayOfMonth.Value > 0 && State != 0)
            {
                comboBox_AddTyp_SelectedValueChanged(sender, e);
            }
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
                controls.Add(textBox_AddTotaly);
                controls.Add(textBox_AddValue);
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
                textBox_AddTotaly.Value = textBox_Count.Value * textBox_AddValue.Value;
            }
            catch
            {
                textBox_AddTotaly.Value = 0.0;
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
                if (!Button_Save.Enabled)
                {
                    return false;
                }
                if (textBox_Count.Value <= 0.0)
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب تحديد عدد ساعات الاضافي" : "Most Set Count", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_Count.Focus();
                    return false;
                }
                if (textBox_AddValue.Value <= 0.0)
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب تحديد قيمة الإضافي" : "Most Set Value", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_AddValue.Focus();
                    return false;
                }
                if (textBox_SalDate.Text.Trim().Length != 7)
                {
                    MessageBox.Show((LangArEn == 0) ? "تاكد من تاريخ الشهر المضاف اليه" : "Make sure the date of salary", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    textBox_SalDate.Focus();
                    return false;
                }
                if (dateTimeInput_warnDate.Text.Length != 10)
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب تحديد التاريخ " : "You must specify the date", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    dateTimeInput_warnDate.Focus();
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
        private void comboBox_AddTyp_SelectedValueChanged(object sender, EventArgs e)
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
                    label1.Text = ((LangArEn == 0) ? "يـــــوم" : "Day");
                }
                else if (comboBox_SubTyp.SelectedIndex == 1)
                {
                    label1.Visible = true;
                    if (checkBox_Minute.Checked)
                    {
                        label1.Text = ((LangArEn == 0) ? "دقيقة" : "Minute");
                    }
                    else
                    {
                        label1.Text = ((LangArEn == 0) ? "ساعة" : "Hour");
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
                    label_DaysAcountInMonth.Enabled = true;
                }
                else
                {
                    comboBox_CalculateNo.Enabled = false;
                    textBox_DayOfMonth.Enabled = false;
                    label2.Enabled = false;
                    label_DaysAcountInMonth.Enabled = false;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("comboBox_AddTyp_SelectedValueChanged:", error, enable: true);
            }
        }
        private void checkBox_Minute_CheckedChanged(object sender, EventArgs e)
        {
            comboBox_AddTyp_SelectedValueChanged(sender, e);
        }
        private double GetDeductionValue(string EmpID)
        {
            try
            {
                T_Emp newData = db.EmpsEmp(EmpID);
                if (newData != null || newData.Emp_ID != "")
                {
                    if (comboBox_SubTyp.SelectedValue.ToString() == "1")
                    {
                        switch (comboBox_CalculateNo.SelectedIndex)
                        {
                            case 0:
                                return Math.Round(newData.AddDay.Value, 2);
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
                            case 6:
                                {
                                    double I = newData.MainSal.Value;
                                    I += newData.TransferAllowance.Value;
                                    return Math.Round(I / (double)textBox_DayOfMonth.Value, 2);
                                }
                        }
                    }
                    else
                    {
                        if (!(comboBox_SubTyp.SelectedValue.ToString() == "2"))
                        {
                            if (comboBox_SubTyp.SelectedValue.ToString() == "3")
                            {
                                return newData.MandateDay.Value;
                            }
                            return 0.0;
                        }
                        switch (comboBox_CalculateNo.SelectedIndex)
                        {
                            case 0:
                                return Math.Round(newData.AddHours.Value, 2);
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
                            case 6:
                                {
                                    double I = newData.MainSal.Value;
                                    I += newData.TransferAllowance.Value;
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
                        label_DaysAcountInMonth.Enabled = true;
                        textBox_DayOfMonth.Enabled = true;
                    }
                    else
                    {
                        label_DaysAcountInMonth.Enabled = false;
                        textBox_DayOfMonth.Enabled = false;
                        comboBox_CalculateNo.SelectedIndex = 0;
                    }
                }
                else
                {
                    label_DaysAcountInMonth.Enabled = false;
                    textBox_DayOfMonth.Enabled = false;
                }
                comboBox_AddTyp_SelectedValueChanged(sender, e);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("comboBox_CalculateNo_SelectedValueChanged:", error, enable: true);
            }
        }
        private void textBox_AddValue_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(textBox_AddValue.Text == ""))
                {
                    double Amount = textBox_Count.Value - textBox_Count.Value;
                    if (textBox_AddValue.Value < 0.0)
                    {
                        MessageBox.Show((LangArEn == 0) ? "قيمة غير منطقية " : "The value of non-logical", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    else if (comboBox_SubTyp.SelectedIndex == 1)
                    {
                        textBox_AddTotaly.Value = Math.Round((textBox_Count.Value + Amount / 60.0 * 100.0) * textBox_AddValue.Value, 2);
                    }
                    else
                    {
                        textBox_AddTotaly.Value = Math.Round(textBox_Count.Value * textBox_AddValue.Value, 2);
                    }
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("textBox_AddValue_ValueChanged:", error, enable: true);
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
                        MessageBox.Show((LangArEn == 0) ? "قيمة غير منطقية " : "The value of non-logical", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    else if (comboBox_SubTyp.SelectedIndex == 1 && Amount > 0.599)
                    {
                        MessageBox.Show((LangArEn == 0) ? "قيمة غير منطقية " : "The value of non-logical", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    else if (comboBox_SubTyp.SelectedIndex == 1)
                    {
                        textBox_AddTotaly.Value = Math.Round((textBox_Count.Value + Amount / 60.0 * 100.0) * textBox_AddValue.Value, 2);
                    }
                    else
                    {
                        textBox_AddTotaly.Value = Math.Round(textBox_Count.Value * textBox_AddValue.Value, 2);
                    }
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("textBox_Count_ValueChanged:", error, enable: true);
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
                        MessageBox.Show((LangArEn == 0) ? "لا يوجد موظفين حسب المعايير المدخلة " : "No Employee to the criteria entered", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    for (int i = 0; i < q.Count; i++)
                    {
                        data_this = new T_Add();
                        Guid id = Guid.NewGuid();
                        data_this.Add_ID = id.ToString();
                        data_this.EmpID = q[i].Emp_ID;
                        data_this.warnNo = db.MaxADDNo;
                        GetData();
                        db.T_Adds.InsertOnSubmit(data_this);
                        db.SubmitChanges();
                    }
                }
                catch (SqlException error2)
                {
                    if (error2.Number == 2627)
                    {
                        MessageBox.Show((LangArEn == 0) ? "رقم الأمر مستخدم من قبل.\n سيتم الحفظ برقم جديد " : "This No is user before.\n Will be save a new number", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
    }
}
