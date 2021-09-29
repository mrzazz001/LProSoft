namespace Check_Data.Forms
{
    using DevComponents.DotNetBar;
    using InvAcc. GeneralM;
    using SSSLanguage;
    using InvAcc.Stock_Data;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Xml;

    public class FrmPathSetting : Form
    {
        private int LangArEn = 0;
        private Stock_DataDataContext dbInstance;
        private IContainer components = null;
        private RibbonBar ribbonBar1;
        private Panel panel1;
        private Label label1;
        protected TextBox textBox_ComputerName;
        protected TextBox textBox_ServerName;
        private Label label2;
        protected TextBox textBox_Pass;
        private Label label4;
        private Button button1;
        private Button button2;
        private LabelX label3;

        public FrmPathSetting()
        {
            this.InitializeComponent();//this.Load += langloads;
        }

        private void button_ComputerName_Click(object sender, EventArgs e)
        {
            this.textBox_ComputerName.Text = Environment.MachineName;
        }

        private void buttonItem_Support_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Application.StartupPath + @"\SystemFiles\TeamViewer\TeamViewer.exe");
            }
            catch
            {
            }
        }

        private void buttonX_Close_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void buttonX_OK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.textBox_ComputerName.Text) && !string.IsNullOrEmpty(this.textBox_ServerName.Text))
            {
                XmlDocument document = new XmlDocument();
                document.Load(Application.StartupPath + "/SqlPath.xml");
                XmlNodeList childNodes = document.SelectNodes("/VarGeneral")[0].ChildNodes;
                int num = 0;
                while (true)
                {
                    if (num >= childNodes.Count)
                    {
                        document.Save(Application.StartupPath + "/SqlPath.xml");
                        base.Close();
                        break;
                    }
                    if (childNodes[num].Name == "ServerName")
                    {
                        childNodes[num].InnerText = this.textBox_ComputerName.Text + @"\" + this.textBox_ServerName.Text;
                    }
                    else if (childNodes[num].Name == "Password")
                    {
                        childNodes[num].InnerText = this.textBox_Pass.Text;
                    }
                    num++;
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void FrmPathSetting_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                base.Close();
            }
        }

        private void FrmPathSetting_Load(object sender, EventArgs e)
        {
            VarGeneral.ReadConnectionSettings();
            int startIndex = 0;
            startIndex = 0;
            while (true)
            {
                if ((startIndex < VarGeneral.gServerName.Length) && (VarGeneral.gServerName.Substring(startIndex, 1) != @"\"))
                {
                    startIndex++;
                    continue;
                }
                try
                {
                    this.textBox_ComputerName.Text = VarGeneral.gServerName.Substring(0, startIndex);
                }
                catch
                {
                    this.textBox_ComputerName.Text = ".";
                }
                break;
            }
            try
            {
                this.textBox_ServerName.Text = VarGeneral.gServerName.Substring(startIndex + 1);
            }
            catch
            {
                this.textBox_ServerName.Text = "";
            }
            try
            {
                this.textBox_Pass.Text = VarGeneral.gPassword;
            }
            catch
            {
                this.textBox_Pass.Text = "";
            }
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(FrmPathSetting));
            this.ribbonBar1 = new RibbonBar();
            this.panel1 = new Panel();
            this.textBox_Pass = new TextBox();
            this.label4 = new Label();
            this.textBox_ServerName = new TextBox();
            this.label2 = new Label();
            this.textBox_ComputerName = new TextBox();
            this.label1 = new Label();
            this.label3 = new LabelX();
            this.button2 = new Button();
            this.button1 = new Button();
            this.ribbonBar1.SuspendLayout();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.ribbonBar1.AutoOverflowEnabled = true;
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = eCornerType.Square;
            this.ribbonBar1.BackgroundStyle.BackColor = Color.AliceBlue;
            this.ribbonBar1.BackgroundStyle.BackColor2 = SystemColors.GradientActiveCaption;
            this.ribbonBar1.BackgroundStyle.CornerType = eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.panel1);
            this.ribbonBar1.Dock = DockStyle.Fill;
           // this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new Size(0x1f7, 0x11a);
            this.ribbonBar1.Style = eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 0x365;
            this.ribbonBar1.TitleStyle.BackColor = Color.FromArgb(0xe3, 0xef, 0xff);
            this.ribbonBar1.TitleStyle.BackColor2 = Color.FromArgb(0x65, 0x93, 0xcf);
            this.ribbonBar1.TitleStyle.CornerType = eCornerType.Square;
            this.ribbonBar1.TitleStyleMouseOver.CornerType = eCornerType.Square;
            this.panel1.BackColor = Color.White;
            this.panel1.BorderStyle = BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.textBox_Pass);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBox_ServerName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox_ComputerName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x1f7, 0x109);
            this.panel1.TabIndex = 0x359;
            this.panel1.Paint += new PaintEventHandler(this.panel1_Paint);
            this.textBox_Pass.BorderStyle = BorderStyle.FixedSingle;
            this.textBox_Pass.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
            this.textBox_Pass.ForeColor = Color.Maroon;
            this.textBox_Pass.Location = new Point(0x2f, 0x9e);
            this.textBox_Pass.MaxLength = 0x23;
            this.textBox_Pass.Name = "textBox_Pass";
            this.textBox_Pass.PasswordChar = '*';
            this.textBox_Pass.Size = new Size(0x11f, 0x15);
            this.textBox_Pass.TabIndex = 0x5b;
            this.textBox_Pass.TextAlign = HorizontalAlignment.Center;
            this.textBox_Pass.Click += new EventHandler(this.textBox_Pass_Click);
            this.label4.AutoSize = true;
            this.label4.BackColor = Color.Transparent;
            this.label4.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
            this.label4.ForeColor = Color.SteelBlue;
            this.label4.ImeMode = ImeMode.NoControl;
            this.label4.Location = new Point(350, 160);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x73, 13);
            this.label4.TabIndex = 0x5c;
            this.label4.Text = "باسورد السيرفر - Sa";
            this.textBox_ServerName.BorderStyle = BorderStyle.FixedSingle;
            this.textBox_ServerName.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
            this.textBox_ServerName.ForeColor = Color.Maroon;
            this.textBox_ServerName.Location = new Point(0x2e, 0x7e);
            this.textBox_ServerName.MaxLength = 0x23;
            this.textBox_ServerName.Name = "textBox_ServerName";
            this.textBox_ServerName.Size = new Size(0x11f, 0x15);
            this.textBox_ServerName.TabIndex = 0x59;
            this.textBox_ServerName.TextAlign = HorizontalAlignment.Center;
            this.textBox_ServerName.Click += new EventHandler(this.textBox_ServerName_Click);
            this.textBox_ServerName.Enter += new EventHandler(this.textBox_DataBaseNm_Enter);
            this.label2.AutoSize = true;
            this.label2.BackColor = Color.Transparent;
            this.label2.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
            this.label2.ForeColor = Color.SteelBlue;
            this.label2.ImeMode = ImeMode.NoControl;
            this.label2.Location = new Point(0x15d, 0x80);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x53, 13);
            this.label2.TabIndex = 90;
            this.label2.Text = "إسم السيرفر :";
            this.textBox_ComputerName.BorderStyle = BorderStyle.FixedSingle;
            this.textBox_ComputerName.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
            this.textBox_ComputerName.ForeColor = Color.Maroon;
            this.textBox_ComputerName.Location = new Point(0x2e, 0x5e);
            this.textBox_ComputerName.MaxLength = 0x23;
            this.textBox_ComputerName.Name = "textBox_ComputerName";
            this.textBox_ComputerName.Size = new Size(0x11f, 0x15);
            this.textBox_ComputerName.TabIndex = 0;
            this.textBox_ComputerName.TextAlign = HorizontalAlignment.Center;
            this.textBox_ComputerName.Click += new EventHandler(this.textBox_ComputerName_Click);
            this.textBox_ComputerName.Enter += new EventHandler(this.textBox_DataBaseNm_Enter);
            this.textBox_ComputerName.KeyPress += new KeyPressEventHandler(this.textBox_DataBaseNm_KeyPress);
            this.label1.AutoSize = true;
            this.label1.BackColor = Color.Transparent;
            this.label1.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
            this.label1.ForeColor = Color.SteelBlue;
            this.label1.ImeMode = ImeMode.NoControl;
            this.label1.Location = new Point(0x15d, 0x60);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x77, 13);
            this.label1.TabIndex = 0x56;
            this.label1.Text = "اسم الجهاز الرئيسي:";
            this.label3.BackColor = Color.Silver;
            this.label3.BackgroundStyle.CornerType = eCornerType.Square;
            this.label3.Dock = DockStyle.Top;
            this.label3.Font = new Font("Tahoma", 12f, FontStyle.Italic | FontStyle.Bold);
            this.label3.ForeColor = Color.White;
            this.label3.Location = new Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x1f5, 50);
            this.label3.TabIndex = 0x58;
            this.label3.Text = "تحديد مسار قاعدة البيانات";
            this.label3.TextAlignment = StringAlignment.Center;
            this.button2.BackColor = Color.MediumSlateBlue;
            this.button2.FlatStyle = FlatStyle.Flat;
            this.button2.Font = new Font("Tahoma", 12f, FontStyle.Bold);
            this.button2.Location = new Point(0x5e, 0xd3);
            this.button2.Name = "button2";
            this.button2.Size = new Size(0x5e, 0x1f);
            this.button2.TabIndex = 0x5d;
            this.button2.Text = "إغلاق";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new EventHandler(this.buttonX_Close_Click);
            this.button1.BackColor = Color.MediumSlateBlue;
            this.button1.FlatStyle = FlatStyle.Flat;
            this.button1.Font = new Font("Tahoma", 12f, FontStyle.Bold);
            this.button1.Location = new Point(0xd0, 0xd3);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x5e, 0x1f);
            this.button1.TabIndex = 0x5d;
            this.button1.Text = "موافق";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new EventHandler(this.buttonX_OK_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = SystemColors.ControlLightLight;
            base.ClientSize = new Size(0x1f7, 0x11a);
            base.ControlBox = false;
            base.Controls.Add(this.ribbonBar1);
            base.FormBorderStyle = FormBorderStyle.Fixed3D;
            base.Icon = (Icon)manager.GetObject("$this.Icon");
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "FrmPathSetting";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            base.StartPosition = FormStartPosition.CenterScreen;
            base.Load += new EventHandler(this.FrmPathSetting_Load);
            base.KeyDown += new KeyEventHandler(this.FrmPathSetting_KeyDown);
            this.ribbonBar1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            base.ResumeLayout(false);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void textBox_ComputerName_Click(object sender, EventArgs e)
        {
            this.textBox_ComputerName.SelectAll();
        }

        private void textBox_DataBaseNm_Enter(object sender, EventArgs e)
        {
            Language.Switch("EN");
        }

        private void textBox_DataBaseNm_KeyPress(object sender, KeyPressEventArgs e)
        {
            Language.Switch("EN");
        }

        private void textBox_Pass_Click(object sender, EventArgs e)
        {
            this.textBox_Pass.SelectAll();
        }

        private void textBox_ServerName_Click(object sender, EventArgs e)
        {
            this.textBox_ServerName.SelectAll();
        }

        private Stock_DataDataContext db
        {
            get
            {
                if (ReferenceEquals(this.dbInstance, null))
                {
                    this.dbInstance = new Stock_DataDataContext(VarGeneral.BranchCS);
                }
                return this.dbInstance;
            }
        }
    }
}
