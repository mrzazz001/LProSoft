using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSLanguage;
using System;
using System.ComponentModel;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmTableType : Form
    {
        private int LangArEn = 0;
        private string vItemNo = string.Empty;
        public int vSize_ = 0;
        public bool vSts_Op = false;
        private Stock_DataDataContext dbInstance;
        private IContainer components = null;
        private RibbonBar ribbonBar1;
        private GroupPanel groupPanel1;
        private ButtonX button_Unit2;
        private ButtonX button_Unit3;
        private ButtonX button_Unit4;
        protected Label label4E;
        protected Label label3E;
        protected Label label1E;
        protected Label label2E;
        protected Label label4;
        private ButtonX button_Close;
        protected Label label3;
        protected Label label1;
        protected Label label2;
        private ButtonX button_Unit1;
        public int vSize
        {
            get
            {
                return vSize_;
            }
            set
            {
                vSize_ = value;
            }
        }
        public bool vStsOp
        {
            get
            {
                return vSts_Op;
            }
            set
            {
                vSts_Op = value;
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
        public FrmTableType()
        {
            InitializeComponent();
        }
        private void FrmTableType_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmTableType));
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
                {
                    Language.ChangeLanguage("ar-SA", this, resources);
                    LangArEn = 0;
                    button_Close.Text = "تــــراجــــــع";
                }
                else
                {
                    Language.ChangeLanguage("en", this, resources);
                    LangArEn = 1;
                    button_Close.Text = "Back";
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void button_Close_Click(object sender, EventArgs e)
        {
            vStsOp = false;
            vSize = 0;
            Close();
        }
        private void FrmTableType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                button_Close_Click(sender, e);
            }
        }
        private void FrmTableType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void button_Unit1_Click(object sender, EventArgs e)
        {
            if (button_Unit1.Checked)
            {
                vStsOp = true;
                vSize = 1;
                Close();
            }
        }
        private void button_Unit2_Click(object sender, EventArgs e)
        {
            if (button_Unit2.Checked)
            {
                vStsOp = true;
                vSize = 2;
                Close();
            }
        }
        private void button_Unit3_Click(object sender, EventArgs e)
        {
            if (button_Unit3.Checked)
            {
                vStsOp = true;
                vSize = 3;
                Close();
            }
        }
        private void button_Unit4_Click(object sender, EventArgs e)
        {
            if (button_Unit4.Checked)
            {
                vStsOp = true;
                vSize = 4;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmTableType));
            ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            button_Unit2 = new DevComponents.DotNetBar.ButtonX();
            button_Unit3 = new DevComponents.DotNetBar.ButtonX();
            button_Unit4 = new DevComponents.DotNetBar.ButtonX();
            label4E = new System.Windows.Forms.Label();
            label3E = new System.Windows.Forms.Label();
            label1E = new System.Windows.Forms.Label();
            label2E = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            button_Close = new DevComponents.DotNetBar.ButtonX();
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            button_Unit1 = new DevComponents.DotNetBar.ButtonX();
            ribbonBar1.SuspendLayout();
            groupPanel1.SuspendLayout();
            SuspendLayout();
            ribbonBar1.AutoOverflowEnabled = true;
            ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.ContainerControlProcessDialogKey = true;
            ribbonBar1.Controls.Add(groupPanel1);
            resources.ApplyResources(ribbonBar1, "ribbonBar1");
            ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            ribbonBar1.Name = "ribbonBar1";
            ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.FromArgb(227, 239, 255);
            ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(101, 147, 207);
            ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            groupPanel1.BackColor = System.Drawing.Color.AliceBlue;
            groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            groupPanel1.Controls.Add(button_Unit2);
            groupPanel1.Controls.Add(button_Unit3);
            groupPanel1.Controls.Add(button_Unit4);
            groupPanel1.Controls.Add(label4E);
            groupPanel1.Controls.Add(label3E);
            groupPanel1.Controls.Add(label1E);
            groupPanel1.Controls.Add(label2E);
            groupPanel1.Controls.Add(label4);
            groupPanel1.Controls.Add(button_Close);
            groupPanel1.Controls.Add(label3);
            groupPanel1.Controls.Add(label1);
            groupPanel1.Controls.Add(label2);
            groupPanel1.Controls.Add(button_Unit1);
            resources.ApplyResources(groupPanel1, "groupPanel1");
            groupPanel1.Name = "groupPanel1";
            groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            groupPanel1.Style.BackColorGradientAngle = 90;
            groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
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
            groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            button_Unit2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            button_Unit2.Checked = true;
            button_Unit2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(button_Unit2, "button_Unit2");
            button_Unit2.Name = "button_Unit2";
            button_Unit2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_Unit2.Symbol = "\uf00a";
            button_Unit2.Click += new System.EventHandler(button_Unit2_Click);
            button_Unit3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            button_Unit3.Checked = true;
            button_Unit3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(button_Unit3, "button_Unit3");
            button_Unit3.Name = "button_Unit3";
            button_Unit3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_Unit3.Symbol = "\uf00a";
            button_Unit3.Click += new System.EventHandler(button_Unit3_Click);
            button_Unit4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            button_Unit4.Checked = true;
            button_Unit4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(button_Unit4, "button_Unit4");
            button_Unit4.Name = "button_Unit4";
            button_Unit4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_Unit4.Symbol = "\uf00a";
            button_Unit4.Click += new System.EventHandler(button_Unit4_Click);
            resources.ApplyResources(label4E, "label4E");
            label4E.BackColor = System.Drawing.Color.Transparent;
            label4E.ForeColor = System.Drawing.Color.Black;
            label4E.Name = "label4E";
            resources.ApplyResources(label3E, "label3E");
            label3E.BackColor = System.Drawing.Color.Transparent;
            label3E.ForeColor = System.Drawing.Color.Black;
            label3E.Name = "label3E";
            resources.ApplyResources(label1E, "label1E");
            label1E.BackColor = System.Drawing.Color.Transparent;
            label1E.ForeColor = System.Drawing.Color.Black;
            label1E.Name = "label1E";
            resources.ApplyResources(label2E, "label2E");
            label2E.BackColor = System.Drawing.Color.Transparent;
            label2E.ForeColor = System.Drawing.Color.Black;
            label2E.Name = "label2E";
            resources.ApplyResources(label4, "label4");
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.ForeColor = System.Drawing.Color.Black;
            label4.Name = "label4";
            button_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            button_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            resources.ApplyResources(button_Close, "button_Close");
            button_Close.Name = "button_Close";
            button_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_Close.Symbol = "\uf01e";
            button_Close.SymbolSize = 18f;
            button_Close.TextColor = System.Drawing.Color.White;
            button_Close.Click += new System.EventHandler(button_Close_Click);
            resources.ApplyResources(label3, "label3");
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.ForeColor = System.Drawing.Color.Black;
            label3.Name = "label3";
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.ForeColor = System.Drawing.Color.Black;
            label1.Name = "label1";
            resources.ApplyResources(label2, "label2");
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.ForeColor = System.Drawing.Color.Black;
            label2.Name = "label2";
            button_Unit1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            button_Unit1.Checked = true;
            button_Unit1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(button_Unit1, "button_Unit1");
            button_Unit1.Name = "button_Unit1";
            button_Unit1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_Unit1.Symbol = "\uf00a";
            button_Unit1.Click += new System.EventHandler(button_Unit1_Click);
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.AppWorkspace;
            base.ControlBox = false;
            base.Controls.Add(ribbonBar1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FrmTableType";
            base.ShowIcon = false;
            base.Load += new System.EventHandler(FrmTableType_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(FrmTableType_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmTableType_KeyDown);
            ribbonBar1.ResumeLayout(false);
            groupPanel1.ResumeLayout(false);
            groupPanel1.PerformLayout();
            ResumeLayout(false);
        }
    }
}
