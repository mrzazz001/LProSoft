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
#pragma warning disable CS0414 // The field 'FrmPathSetting.LangArEn' is assigned but its value is never used
        private int LangArEn = 0;
#pragma warning restore CS0414 // The field 'FrmPathSetting.LangArEn' is assigned but its value is never used
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
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox_Pass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_ServerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_ComputerName = new System.Windows.Forms.TextBox();
            this.label3 = new DevComponents.DotNetBar.LabelX();
            this.label1 = new System.Windows.Forms.Label();
            this.ribbonBar1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.panel1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.DragDropSupport = true;
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(503, 282);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 869;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ItemClick += new System.EventHandler(this.ribbonBar1_ItemClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.textBox_Pass);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBox_ServerName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox_ComputerName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(503, 265);
            this.panel1.TabIndex = 857;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(208, 211);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 31);
            this.button1.TabIndex = 93;
            this.button1.Text = "موافق";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.buttonX_OK_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(94, 211);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 31);
            this.button2.TabIndex = 93;
            this.button2.Text = "إغلاق";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.buttonX_Close_Click);
            // 
            // textBox_Pass
            // 
            this.textBox_Pass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Pass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_Pass.ForeColor = System.Drawing.Color.Maroon;
            this.textBox_Pass.Location = new System.Drawing.Point(47, 158);
            this.textBox_Pass.MaxLength = 35;
            this.textBox_Pass.Name = "textBox_Pass";
            this.textBox_Pass.PasswordChar = '*';
            this.textBox_Pass.Size = new System.Drawing.Size(287, 21);
            this.textBox_Pass.TabIndex = 91;
            this.textBox_Pass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Pass.Click += new System.EventHandler(this.textBox_Pass_Click);
            this.textBox_Pass.TextChanged += new System.EventHandler(this.textBox_Pass_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(350, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 92;
            this.label4.Text = "باسورد السيرفر - Sa";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // textBox_ServerName
            // 
            this.textBox_ServerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_ServerName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_ServerName.ForeColor = System.Drawing.Color.Maroon;
            this.textBox_ServerName.Location = new System.Drawing.Point(46, 126);
            this.textBox_ServerName.MaxLength = 35;
            this.textBox_ServerName.Name = "textBox_ServerName";
            this.textBox_ServerName.Size = new System.Drawing.Size(287, 21);
            this.textBox_ServerName.TabIndex = 89;
            this.textBox_ServerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_ServerName.Click += new System.EventHandler(this.textBox_ServerName_Click);
            this.textBox_ServerName.TextChanged += new System.EventHandler(this.textBox_ServerName_TextChanged);
            this.textBox_ServerName.Enter += new System.EventHandler(this.textBox_DataBaseNm_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(349, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 90;
            this.label2.Text = "إسم السيرفر :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBox_ComputerName
            // 
            this.textBox_ComputerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_ComputerName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_ComputerName.ForeColor = System.Drawing.Color.Maroon;
            this.textBox_ComputerName.Location = new System.Drawing.Point(46, 94);
            this.textBox_ComputerName.MaxLength = 35;
            this.textBox_ComputerName.Name = "textBox_ComputerName";
            this.textBox_ComputerName.Size = new System.Drawing.Size(287, 21);
            this.textBox_ComputerName.TabIndex = 0;
            this.textBox_ComputerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_ComputerName.Click += new System.EventHandler(this.textBox_ComputerName_Click);
            this.textBox_ComputerName.TextChanged += new System.EventHandler(this.textBox_ComputerName_TextChanged);
            this.textBox_ComputerName.Enter += new System.EventHandler(this.textBox_DataBaseNm_Enter);
            this.textBox_ComputerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_DataBaseNm_KeyPress);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Silver;
            // 
            // 
            // 
            this.label3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(501, 50);
            this.label3.TabIndex = 88;
            this.label3.Text = "تحديد مسار قاعدة البيانات";
            this.label3.TextAlignment = System.Drawing.StringAlignment.Center;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(349, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 86;
            this.label1.Text = "اسم الجهاز الرئيسي:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // FrmPathSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(503, 282);
            this.ControlBox = false;
            this.Controls.Add(this.ribbonBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmPathSetting";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmPathSetting_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPathSetting_KeyDown);
            this.ribbonBar1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

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

        private void ribbonBar1_ItemClick(object sender, EventArgs e)
        {

        }

        private void textBox_Pass_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox_ServerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox_ComputerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
