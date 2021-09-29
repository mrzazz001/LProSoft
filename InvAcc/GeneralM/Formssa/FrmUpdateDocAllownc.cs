using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using DevComponents.Editors.DateTimeAdv;
using Framework.UI;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmUpdateDocAllownc : Form
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
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private Dictionary<string, ColumnDictinary> Dir_ButSearch = new Dictionary<string, ColumnDictinary>();
        private int LangArEn = 0;
        private bool relaystate = false;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
        private string FlagUpdate = "";
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private T_Emp data_this;
        private T_UpdateDoc data_this_UpdateID;
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private IContainer components = null;
        private RibbonBar ribbonBar1;
        private Panel panel1;
        private ComboBoxEx comboBox_EmpNo;
        private ButtonX button_SrchEmp;
        private Label label12;
        private MaskedTextBox dateTimeInput_warnDate;
        private Label label54;
        protected TextBox textBox_EmpNo;
        protected Label label38;
        private ButtonX ButExit;
        private ButtonX ButOk;
        private TextBoxX textBox_Note;
        private GroupPanel groupPanel_After;
        private ComboBoxEx comboBox_InsuranceTypeAfter;
        private Label label1;
        private TextBox textBox_Insurance_ClassAfter;
        private Label label146;
        private GroupPanel groupPanel_Now;
        private ComboBoxEx comboBox_InsuranceType;
        private Label label2;
        private TextBox textBox_Insurance_Class;
        private Label label3;
        public bool RelayState
        {
            get
            {
                return relaystate;
            }
            set
            {
                relaystate = value;
            }
        }
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
        public T_Emp DataThis
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
        public T_UpdateDoc DataThis_UpdateID
        {
            get
            {
                return data_this_UpdateID;
            }
            set
            {
                data_this_UpdateID = value;
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
        public FrmUpdateDocAllownc()
        {
            InitializeComponent();
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ButExit.Text = "خــــروج Esc";
                ButOk.Text = "تجـــديــد F5";
                textBox_Note.WatermarkText = "ملاحظــــات العملـــــية";
                Text = "تجديد شركات التأمين";
            }
            else
            {
                ButExit.Text = "Exit Esc";
                ButOk.Text = "Update F5";
                textBox_Note.WatermarkText = "Notes";
                Text = "Update Allownce Company";
            }
        }
        private void FrmUpdateDocAllownc_Load(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmUpdateDocAllownc));
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
            ADD_Controls();
            Clear();
            RibunButtons();
            FillCombo();
        }
        public void FillCombo()
        {
            List<T_Emp> listEmps = new List<T_Emp>(db.T_Emps.Where((T_Emp item) => item.EmpState == (bool?)true).ToList());
            listEmps.Insert(0, new T_Emp());
            comboBox_EmpNo.DataSource = listEmps;
            comboBox_EmpNo.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_EmpNo.ValueMember = "Emp_ID";
            List<T_Insurance> listInsuranceTyp = new List<T_Insurance>(db.T_Insurances.Select((T_Insurance item) => item).ToList());
            comboBox_InsuranceType.DataSource = null;
            listInsuranceTyp.Insert(0, new T_Insurance());
            comboBox_InsuranceType.DataSource = listInsuranceTyp;
            comboBox_InsuranceType.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_InsuranceType.ValueMember = "Insurance_No";
            List<T_Insurance> listInsuranceTyp2 = new List<T_Insurance>(db.T_Insurances.Select((T_Insurance item) => item).ToList());
            comboBox_InsuranceTypeAfter.DataSource = null;
            listInsuranceTyp2.Insert(0, new T_Insurance());
            comboBox_InsuranceTypeAfter.DataSource = listInsuranceTyp2;
            comboBox_InsuranceTypeAfter.DisplayMember = ((LangArEn == 0) ? "NameA" : "NameE");
            comboBox_InsuranceTypeAfter.ValueMember = "Insurance_No";
        }
        public void Clear()
        {
            data_this = new T_Emp();
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
                dateTimeInput_warnDate.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
            }
            else
            {
                dateTimeInput_warnDate.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
            }
        }
        public void SetData(T_Emp value)
        {
            textBox_Insurance_Class.Text = value.Insurance_Name;
            if (value.InsuranceNo.HasValue)
            {
                comboBox_InsuranceType.SelectedValue = value.InsuranceNo.Value;
            }
            else
            {
                comboBox_InsuranceType.SelectedIndex = 0;
            }
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_EmpNo.Items.Count <= 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب تحديد موظف" : "Most Select Employee", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    comboBox_EmpNo.Focus();
                    return;
                }
                if (comboBox_EmpNo.SelectedIndex <= 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب تحديد موظف" : "Most Select Employee", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    comboBox_EmpNo.Focus();
                    return;
                }
                if (dateTimeInput_warnDate.Text.Length != 10)
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب تحديد تاريخ العملية " : "You must specify the date", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    dateTimeInput_warnDate.Focus();
                    return;
                }
                if (comboBox_InsuranceTypeAfter.SelectedIndex <= 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب تحديد شركة تأمين قبل عملية الحفظ" : "You must select Company before save", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    comboBox_InsuranceTypeAfter.Focus();
                    return;
                }
                string query = "SELECT * FROM [dbo].[T_Emp] as [t0] WHERE EmpState = 1 and Emp_ID = '" + comboBox_EmpNo.SelectedValue.ToString() + "' ORDER BY [Emp_No]";
                List<T_Emp> _Emp = db.ExecuteQuery<T_Emp>(query, new object[0]).ToList();
                if (_Emp.Count == 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "لم يستطع النظام الوصول الى بيانات هذا الموظف " : "No data ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                T_Emp newData = _Emp.FirstOrDefault();
                data_this = new T_Emp();
                data_this = newData;
                GetData(newData);
                if (data_this.InsuranceNo == data_this_UpdateID.InsuranceNoAfter && data_this.Insurance_Name == data_this_UpdateID.Insurance_NameAfter)
                {
                    return;
                }
                try
                {
                    if (comboBox_InsuranceTypeAfter.SelectedIndex > 0)
                    {
                        data_this.Insurance_Name = textBox_Insurance_ClassAfter.Text;
                    }
                    else
                    {
                        data_this.Insurance_Name = "";
                    }
                }
                catch
                {
                    data_this.Insurance_Name = "";
                }
                try
                {
                    if (comboBox_InsuranceTypeAfter.SelectedIndex > 0)
                    {
                        data_this.InsuranceNo = int.Parse(comboBox_InsuranceTypeAfter.SelectedValue.ToString());
                    }
                    else
                    {
                        data_this.InsuranceNo = null;
                    }
                }
                catch
                {
                    data_this.InsuranceNo = null;
                }
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                try
                {
                    db.T_UpdateDocs.InsertOnSubmit(data_this_UpdateID);
                    db.SubmitChanges();
                }
                catch (SqlException error2)
                {
                    if (error2.Number == 2627)
                    {
                        data_this_UpdateID.warnNo = db.MaxOUpdateDocEmpNo;
                        db.T_UpdateDocs.InsertOnSubmit(data_this_UpdateID);
                        db.SubmitChanges();
                    }
                    else
                    {
                        VarGeneral.DebLog.writeLog("Button_Ok_Click:", error2, enable: true);
                        MessageBox.Show(error2.Message);
                    }
                    return;
                }
                MessageBox.Show((LangArEn == 0) ? "تمت عملية التجديد بنجاح " : "The completion of the process has been successfully", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                dbInstance = null;
                comboBox_EmpNo.SelectedIndex = 0;
                try
                {
                    comboBox_EmpNo_SelectedValueChanged(sender, e);
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
        private void GetData(T_Emp newData)
        {
            data_this_UpdateID = new T_UpdateDoc();
            data_this_UpdateID.warnNo = db.MaxOUpdateDocEmpNo;
            if (newData.Insurance_From.HasValue)
            {
                data_this_UpdateID.DocFrom = newData.Insurance_From.Value;
            }
            else
            {
                data_this_UpdateID.DocFrom = null;
            }
            data_this_UpdateID.DocNo = newData.Insurance_No;
            data_this_UpdateID.DocTyp = 4;
            data_this_UpdateID.BeginDateBefor = newData.Insurance_Date;
            data_this_UpdateID.EndDateBefor = newData.Insurance_DateEnd;
            if (newData.Insurance_From.HasValue)
            {
                data_this_UpdateID.DocFromAfter = newData.Insurance_From.Value;
            }
            else
            {
                data_this_UpdateID.DocFromAfter = null;
            }
            data_this_UpdateID.DocNoAfter = newData.Insurance_No;
            try
            {
                data_this_UpdateID.BeginDateAfter = newData.Insurance_Date;
            }
            catch
            {
                data_this_UpdateID.BeginDateAfter = "";
            }
            try
            {
                data_this_UpdateID.EndDateAfter = newData.Insurance_DateEnd;
            }
            catch
            {
                data_this_UpdateID.EndDateAfter = "";
            }
            data_this_UpdateID.Note = textBox_Note.Text;
            data_this_UpdateID.EmpID = newData.Emp_ID;
            try
            {
                data_this_UpdateID.warnDate = Convert.ToDateTime(dateTimeInput_warnDate.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_warnDate.Text = "";
                data_this_UpdateID.warnDate = "";
            }
            try
            {
                if (comboBox_InsuranceType.SelectedIndex > 0)
                {
                    data_this_UpdateID.Insurance_NameBefor = textBox_Insurance_Class.Text;
                }
                else
                {
                    data_this_UpdateID.Insurance_NameBefor = "";
                }
            }
            catch
            {
                data_this_UpdateID.Insurance_NameBefor = "";
            }
            try
            {
                if (comboBox_InsuranceType.SelectedIndex > 0)
                {
                    data_this_UpdateID.InsuranceNoBefor = int.Parse(comboBox_InsuranceType.SelectedValue.ToString());
                }
                else
                {
                    data_this_UpdateID.InsuranceNoBefor = null;
                }
            }
            catch
            {
                data_this_UpdateID.InsuranceNoBefor = null;
            }
            try
            {
                if (comboBox_InsuranceTypeAfter.SelectedIndex > 0)
                {
                    data_this_UpdateID.Insurance_NameAfter = textBox_Insurance_ClassAfter.Text;
                }
                else
                {
                    data_this_UpdateID.Insurance_NameAfter = "";
                }
            }
            catch
            {
                data_this_UpdateID.Insurance_NameAfter = "";
            }
            try
            {
                if (comboBox_InsuranceTypeAfter.SelectedIndex > 0)
                {
                    data_this_UpdateID.InsuranceNoAfter = int.Parse(comboBox_InsuranceTypeAfter.SelectedValue.ToString());
                }
                else
                {
                    data_this_UpdateID.InsuranceNoAfter = null;
                }
            }
            catch
            {
                data_this_UpdateID.InsuranceNoAfter = null;
            }
            Guid id = Guid.NewGuid();
            data_this_UpdateID.UpdateDoc_ID = id.ToString();
            data_this_UpdateID.Usr_No = VarGeneral.UserID;
            data_this_UpdateID.Usr_NoEdite = null;
            data_this_UpdateID.DateEdit = "";
        }
        private void ADD_Controls()
        {
            try
            {
                controls = new List<Control>();
                controls.Add(comboBox_EmpNo);
                controls.Add(textBox_Note);
                controls.Add(dateTimeInput_warnDate);
                controls.Add(textBox_Insurance_Class);
                controls.Add(textBox_Insurance_ClassAfter);
                controls.Add(comboBox_InsuranceType);
                controls.Add(comboBox_InsuranceTypeAfter);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("ADD_Controls:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void dateTimeInput_warnDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(dateTimeInput_warnDate.Text))
                {
                    dateTimeInput_warnDate.Text = Convert.ToDateTime(dateTimeInput_warnDate.Text).ToString("yyyy/MM/dd");
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
        }
        private void dateTimeInput_warnDate_Click(object sender, EventArgs e)
        {
            dateTimeInput_warnDate.SelectAll();
        }
        private void FrmAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void FrmAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && ButOk.Enabled && ButOk.Visible)
            {
                ButOk_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void comboBox_EmpNo_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_EmpNo.SelectedIndex <= 0)
                {
                    Clear();
                    return;
                }
                T_Emp newData = db.EmpsEmp(comboBox_EmpNo.SelectedValue.ToString() ?? "");
                if (!string.IsNullOrEmpty(newData.Emp_ID))
                {
                    DataThis = newData;
                    textBox_EmpNo.Text = data_this.Emp_No;
                }
                else
                {
                    Clear();
                }
            }
            catch
            {
                Clear();
            }
        }
        private void button_SrchEmp_Click(object sender, EventArgs e)
        {
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
        private void ButExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void comboBox_InsuranceTypeAfter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_InsuranceTypeAfter.SelectedIndex > 0)
            {
                textBox_Insurance_ClassAfter.Enabled = true;
            }
            else
            {
                textBox_Insurance_ClassAfter.Enabled = false;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmUpdateDocAllownc));
            ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            panel1 = new System.Windows.Forms.Panel();
            groupPanel_Now = new DevComponents.DotNetBar.Controls.GroupPanel();
            comboBox_InsuranceType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            label2 = new System.Windows.Forms.Label();
            textBox_Insurance_Class = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            groupPanel_After = new DevComponents.DotNetBar.Controls.GroupPanel();
            comboBox_InsuranceTypeAfter = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            label1 = new System.Windows.Forms.Label();
            textBox_Insurance_ClassAfter = new System.Windows.Forms.TextBox();
            label146 = new System.Windows.Forms.Label();
            textBox_Note = new DevComponents.DotNetBar.Controls.TextBoxX();
            ButExit = new DevComponents.DotNetBar.ButtonX();
            ButOk = new DevComponents.DotNetBar.ButtonX();
            comboBox_EmpNo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            button_SrchEmp = new DevComponents.DotNetBar.ButtonX();
            label12 = new System.Windows.Forms.Label();
            dateTimeInput_warnDate = new System.Windows.Forms.MaskedTextBox();
            label54 = new System.Windows.Forms.Label();
            textBox_EmpNo = new System.Windows.Forms.TextBox();
            label38 = new System.Windows.Forms.Label();
            ribbonBar1.SuspendLayout();
            panel1.SuspendLayout();
            groupPanel_Now.SuspendLayout();
            groupPanel_After.SuspendLayout();
            SuspendLayout();
            ribbonBar1.AutoOverflowEnabled = true;
            ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.ContainerControlProcessDialogKey = true;
            ribbonBar1.Controls.Add(panel1);
            resources.ApplyResources(ribbonBar1, "ribbonBar1");
            ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            ribbonBar1.Name = "ribbonBar1";
            ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.FromArgb(227, 239, 255);
            ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(101, 147, 207);
            ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            panel1.BackColor = System.Drawing.Color.Transparent;
            panel1.Controls.Add(groupPanel_Now);
            panel1.Controls.Add(groupPanel_After);
            panel1.Controls.Add(textBox_Note);
            panel1.Controls.Add(ButExit);
            panel1.Controls.Add(ButOk);
            panel1.Controls.Add(comboBox_EmpNo);
            panel1.Controls.Add(button_SrchEmp);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(dateTimeInput_warnDate);
            panel1.Controls.Add(label54);
            panel1.Controls.Add(textBox_EmpNo);
            panel1.Controls.Add(label38);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            groupPanel_Now.CanvasColor = System.Drawing.SystemColors.Control;
            groupPanel_Now.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            groupPanel_Now.Controls.Add(comboBox_InsuranceType);
            groupPanel_Now.Controls.Add(label2);
            groupPanel_Now.Controls.Add(textBox_Insurance_Class);
            groupPanel_Now.Controls.Add(label3);
            resources.ApplyResources(groupPanel_Now, "groupPanel_Now");
            groupPanel_Now.Name = "groupPanel_Now";
            groupPanel_Now.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            groupPanel_Now.Style.BackColorGradientAngle = 90;
            groupPanel_Now.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            groupPanel_Now.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel_Now.Style.BorderBottomWidth = 1;
            groupPanel_Now.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            groupPanel_Now.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel_Now.Style.BorderLeftWidth = 1;
            groupPanel_Now.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel_Now.Style.BorderRightWidth = 1;
            groupPanel_Now.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel_Now.Style.BorderTopWidth = 1;
            groupPanel_Now.Style.CornerDiameter = 4;
            groupPanel_Now.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            groupPanel_Now.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            groupPanel_Now.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            groupPanel_Now.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            groupPanel_Now.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            groupPanel_Now.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            comboBox_InsuranceType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboBox_InsuranceType.DisplayMember = "Text";
            comboBox_InsuranceType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboBox_InsuranceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(comboBox_InsuranceType, "comboBox_InsuranceType");
            comboBox_InsuranceType.FormattingEnabled = true;
            comboBox_InsuranceType.Name = "comboBox_InsuranceType";
            comboBox_InsuranceType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            textBox_Insurance_Class.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(textBox_Insurance_Class, "textBox_Insurance_Class");
            textBox_Insurance_Class.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            textBox_Insurance_Class.Name = "textBox_Insurance_Class";
            resources.ApplyResources(label3, "label3");
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Name = "label3";
            groupPanel_After.CanvasColor = System.Drawing.SystemColors.Control;
            groupPanel_After.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            groupPanel_After.Controls.Add(comboBox_InsuranceTypeAfter);
            groupPanel_After.Controls.Add(label1);
            groupPanel_After.Controls.Add(textBox_Insurance_ClassAfter);
            groupPanel_After.Controls.Add(label146);
            resources.ApplyResources(groupPanel_After, "groupPanel_After");
            groupPanel_After.Name = "groupPanel_After";
            groupPanel_After.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            groupPanel_After.Style.BackColorGradientAngle = 90;
            groupPanel_After.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            groupPanel_After.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel_After.Style.BorderBottomWidth = 1;
            groupPanel_After.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            groupPanel_After.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel_After.Style.BorderLeftWidth = 1;
            groupPanel_After.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel_After.Style.BorderRightWidth = 1;
            groupPanel_After.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel_After.Style.BorderTopWidth = 1;
            groupPanel_After.Style.CornerDiameter = 4;
            groupPanel_After.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            groupPanel_After.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            groupPanel_After.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            groupPanel_After.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            groupPanel_After.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            groupPanel_After.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            comboBox_InsuranceTypeAfter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboBox_InsuranceTypeAfter.DisplayMember = "Text";
            comboBox_InsuranceTypeAfter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboBox_InsuranceTypeAfter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_InsuranceTypeAfter.FormattingEnabled = true;
            resources.ApplyResources(comboBox_InsuranceTypeAfter, "comboBox_InsuranceTypeAfter");
            comboBox_InsuranceTypeAfter.Name = "comboBox_InsuranceTypeAfter";
            comboBox_InsuranceTypeAfter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            comboBox_InsuranceTypeAfter.SelectedIndexChanged += new System.EventHandler(comboBox_InsuranceTypeAfter_SelectedIndexChanged);
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            textBox_Insurance_ClassAfter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(textBox_Insurance_ClassAfter, "textBox_Insurance_ClassAfter");
            textBox_Insurance_ClassAfter.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            textBox_Insurance_ClassAfter.Name = "textBox_Insurance_ClassAfter";
            resources.ApplyResources(label146, "label146");
            label146.BackColor = System.Drawing.Color.Transparent;
            label146.Name = "label146";
            textBox_Note.BackColor = System.Drawing.Color.AliceBlue;
            textBox_Note.Border.Class = "TextBoxBorder";
            textBox_Note.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_Note.ButtonCustom.Visible = true;
            textBox_Note.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(textBox_Note, "textBox_Note");
            textBox_Note.Name = "textBox_Note";
            textBox_Note.WatermarkColor = System.Drawing.Color.RosyBrown;
            textBox_Note.WatermarkFont = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            textBox_Note.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ButExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            ButExit.Checked = true;
            ButExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(ButExit, "ButExit");
            ButExit.Name = "ButExit";
            ButExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButExit.Symbol = "\uf011";
            ButExit.SymbolSize = 16f;
            ButExit.TextColor = System.Drawing.Color.Black;
            ButExit.Click += new System.EventHandler(ButExit_Click);
            ButOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            ButOk.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            resources.ApplyResources(ButOk, "ButOk");
            ButOk.Name = "ButOk";
            ButOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButOk.Symbol = "\uf0c5";
            ButOk.SymbolSize = 16f;
            ButOk.TextColor = System.Drawing.Color.White;
            ButOk.Click += new System.EventHandler(ButOk_Click);
            comboBox_EmpNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboBox_EmpNo.DisplayMember = "Text";
            comboBox_EmpNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            comboBox_EmpNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_EmpNo.FormattingEnabled = true;
            resources.ApplyResources(comboBox_EmpNo, "comboBox_EmpNo");
            comboBox_EmpNo.Name = "comboBox_EmpNo";
            comboBox_EmpNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            comboBox_EmpNo.SelectedValueChanged += new System.EventHandler(comboBox_EmpNo_SelectedValueChanged);
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
            resources.ApplyResources(dateTimeInput_warnDate, "dateTimeInput_warnDate");
            dateTimeInput_warnDate.Name = "dateTimeInput_warnDate";
            dateTimeInput_warnDate.Leave += new System.EventHandler(dateTimeInput_warnDate_Leave);
            dateTimeInput_warnDate.Click += new System.EventHandler(dateTimeInput_warnDate_Click);
            resources.ApplyResources(label54, "label54");
            label54.BackColor = System.Drawing.Color.Transparent;
            label54.Name = "label54";
            textBox_EmpNo.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            textBox_EmpNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(textBox_EmpNo, "textBox_EmpNo");
            textBox_EmpNo.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            textBox_EmpNo.Name = "textBox_EmpNo";
            textBox_EmpNo.ReadOnly = true;
            resources.ApplyResources(label38, "label38");
            label38.BackColor = System.Drawing.Color.Transparent;
            label38.Name = "label38";
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(ribbonBar1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "FrmUpdateDocAllownc";
            base.Load += new System.EventHandler(FrmUpdateDocAllownc_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(FrmAdd_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmAdd_KeyDown);
            ribbonBar1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupPanel_Now.ResumeLayout(false);
            groupPanel_Now.PerformLayout();
            groupPanel_After.ResumeLayout(false);
            groupPanel_After.PerformLayout();
            ResumeLayout(false);
        }
    }
}
