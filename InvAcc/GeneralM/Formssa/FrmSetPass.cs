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
    public partial class FrmSetPass : Form
    {
        private int LangArEn = 0;
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
        private IContainer components = null;
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
            InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSetPass));
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bubbleButton_Exit = new DevComponents.DotNetBar.ButtonX();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox_EmpPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Button_Ok = new DevComponents.DotNetBar.ButtonX();
            this.ribbonBar1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
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
            this.ribbonBar1.Controls.Add(this.panel1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(358, 139);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 1102;
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.bubbleButton_Exit);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.Button_Ok);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(358, 122);
            this.panel1.TabIndex = 1148;
            // 
            // bubbleButton_Exit
            // 
            this.bubbleButton_Exit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bubbleButton_Exit.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.bubbleButton_Exit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.bubbleButton_Exit.Location = new System.Drawing.Point(32, 86);
            this.bubbleButton_Exit.Name = "bubbleButton_Exit";
            this.bubbleButton_Exit.Size = new System.Drawing.Size(150, 35);
            this.bubbleButton_Exit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bubbleButton_Exit.Symbol = "";
            this.bubbleButton_Exit.SymbolSize = 16F;
            this.bubbleButton_Exit.TabIndex = 3;
            this.bubbleButton_Exit.Text = "خــــروج";
            this.bubbleButton_Exit.TextColor = System.Drawing.Color.White;
            this.bubbleButton_Exit.Click += new System.EventHandler(this.bubbleButton_Exit_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.textBox_EmpPass);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(356, 79);
            this.panel3.TabIndex = 853;
            // 
            // textBox_EmpPass
            // 
            this.textBox_EmpPass.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox_EmpPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_EmpPass.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_EmpPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox_EmpPass.Location = new System.Drawing.Point(46, 44);
            this.textBox_EmpPass.Name = "textBox_EmpPass";
            this.textBox_EmpPass.PasswordChar = '*';
            this.textBox_EmpPass.Size = new System.Drawing.Size(241, 20);
            this.textBox_EmpPass.TabIndex = 1;
            this.textBox_EmpPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_EmpPass.Click += new System.EventHandler(this.textBox_EmpPass_Click);
            this.textBox_EmpPass.TextChanged += new System.EventHandler(this.textBox_EmpPass_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(112, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 83;
            this.label1.Text = "تعــــيين كلمة الســر";
            // 
            // Button_Ok
            // 
            this.Button_Ok.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Button_Ok.Checked = true;
            this.Button_Ok.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Button_Ok.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Button_Ok.Location = new System.Drawing.Point(189, 86);
            this.Button_Ok.Name = "Button_Ok";
            this.Button_Ok.Size = new System.Drawing.Size(150, 35);
            this.Button_Ok.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Button_Ok.Symbol = "";
            this.Button_Ok.SymbolSize = 16F;
            this.Button_Ok.TabIndex = 2;
            this.Button_Ok.Text = "تعـــيين";
            this.Button_Ok.TextColor = System.Drawing.Color.Navy;
            this.Button_Ok.Click += new System.EventHandler(this.Button_Ok_Click);
            // 
            // FrmSetPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 139);
            this.ControlBox = false;
            this.Controls.Add(this.ribbonBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.KeyPreview = true;
            this.Name = "FrmSetPass";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmSetPass_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSetPass_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmSetPass_KeyPress);
            this.ribbonBar1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.ResumeLayout(false);
        }
    }
}
