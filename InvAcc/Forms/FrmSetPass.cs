using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmSetPass : Form
    { void avs(int arln)

{ 
 bubbleButton_Exit.Text=   (arln == 0 ? "  خــــروج  " : "  exit") ; label1.Text=   (arln == 0 ? "  تعــــيين كلمة الســر  " : "  Set password") ; Button_Ok.Text=   (arln == 0 ? "  تعـــيين  " : "  set") ;}
        private void langloads(object sender, EventArgs e)
        {
             avs(GeneralM.VarGeneral.currentintlanguage);
        }
   
#pragma warning disable CS0414 // The field 'FrmSetPass.LangArEn' is assigned but its value is never used
        private int LangArEn = 0;
#pragma warning restore CS0414 // The field 'FrmSetPass.LangArEn' is assigned but its value is never used
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private string Emp_Num;
        private T_Emp data_this;
        private Stock_DataDataContext dbInstance;
       // private IContainer components = null;
        private RibbonBar ribbonBar1;
        private Panel panel1;
        private Panel panel3;
        protected TextBox textBox_EmpPass;
        protected Label label1;
        private ButtonX Button_Ok;
        private ButtonX bubbleButton_Exit;
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
        public string Emp_no
        {
            get
            {
                return Emp_Num;
            }
            set
            {
                Emp_Num = value;
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
        public bool SetReadOnly
        {
            set
            {
                if (value)
                {
                    State = FormState.Saved;
                }
                Button_Ok.Enabled = !value;
            }
        }
        public FrmSetPass()
        {
            InitializeComponent();this.Load += langloads;
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Button_Ok.Text = "تعـــيين";
                bubbleButton_Exit.Text = "خــــروج";
            }
            else
            {
                Button_Ok.Text = "SET";
                bubbleButton_Exit.Text = "Close";
            }
        }
        private void FrmSetPass_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmSetPass));
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
                RibunButtons();
                controls = new List<Control>();
                controls.Add(textBox_EmpPass);
                T_Emp newData = db.EmpsEmp(Emp_no);
                if (newData == null || string.IsNullOrEmpty(newData.Emp_ID))
                {
                    Clear();
                }
                else
                {
                    DataThis = newData;
                    State = FormState.Saved;
                }
                SetReadOnly = true;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FrmSetPass_Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        public void Clear()
        {
            data_this = new T_Emp();
            State = FormState.New;
            for (int i = 0; i < controls.Count; i++)
            {
                if (controls[i].GetType() == typeof(TextBox) || controls[i].GetType() == typeof(TextBoxX) || controls[i].GetType() == typeof(MaskedTextBox))
                {
                    controls[i].Text = "";
                }
            }
            Button_Ok.Enabled = false;
        }
        private void Button_Edit_Click(object sender, EventArgs e)
        {
            if (CanEdit && State != FormState.Edit && State != FormState.New)
            {
                if (State != FormState.New)
                {
                    State = FormState.Edit;
                }
                SetReadOnly = false;
            }
        }
        private T_Emp GetData()
        {
            textBox_EmpPass.Focus();
            try
            {
                data_this.Pass = VarGeneral.Encrypt(textBox_EmpPass.Text);
            }
            catch
            {
            }
            return data_this;
        }
        private void textBox_EmpPass_TextChanged(object sender, EventArgs e)
        {
            Button_Edit_Click(sender, e);
        }
        private void Button_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                if (State == FormState.Edit)
                {
                    GetData();
                    db.Log = VarGeneral.DebugLog;
                    db.SubmitChanges(ConflictMode.ContinueOnConflict);
                    State = FormState.Saved;
                    SetReadOnly = true;
                    bubbleButton_Exit_Click(sender, e);
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Button_Ok_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void FrmSetPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void bubbleButton_Exit_Click(object sender, EventArgs e)
        {
            if (State != 0)
            {
                if (State == FormState.New)
                {
                    Close();
                }
                else
                {
                    Close();
                }
            }
            else
            {
                Close();
            }
        }
        private void textBox_EmpPass_Click(object sender, EventArgs e)
        {
            textBox_EmpPass.SelectAll();
        }
        private void FrmSetPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && Button_Ok.Enabled && Button_Ok.Visible)
            {
                Button_Ok_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
