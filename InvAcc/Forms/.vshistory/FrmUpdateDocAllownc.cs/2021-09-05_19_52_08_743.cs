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
    public partial  class FrmUpdateDocAllownc : Form
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
       // private IContainer components = null;
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
            InitializeComponent();this.Load += langloads;
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
    }
}
