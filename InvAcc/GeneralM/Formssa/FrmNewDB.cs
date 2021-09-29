using Check_Data.Forms;
using DevComponents.DotNetBar;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmNewDB : Form
    {
        private IContainer components = null;
        private void netResize1_AfterControlResize(object sender, Softgroup.NetResize.AfterControlResizeEventArgs e)
        {
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

        public Softgroup.NetResize.NetResize netResize1;

        private LabelX label3;
        private ButtonX buttonX_Close;
        private RibbonBar ribbonBar1;
        private Panel panel1;
        private Label label1;
        protected TextBox textBox_DataBaseNm;
        private ButtonX buttonX_OK;
        private int LangArEn = 0;
        private Stock_DataDataContext dbInstance;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmNewDB));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();

            components = new System.ComponentModel.Container();

            label3 = new DevComponents.DotNetBar.LabelX();
            buttonX_Close = new DevComponents.DotNetBar.ButtonX();
            ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            panel1 = new System.Windows.Forms.Panel();
            textBox_DataBaseNm = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            buttonX_OK = new DevComponents.DotNetBar.ButtonX();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();

            ribbonBar1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            label3.BackColor = System.Drawing.Color.SteelBlue;
            label3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            resources.ApplyResources(label3, "label3");
            label3.ForeColor = System.Drawing.Color.White;
            label3.Name = "label3";
            label3.TextAlignment = System.Drawing.StringAlignment.Center;
            buttonX_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            buttonX_Close.Checked = true;
            buttonX_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(buttonX_Close, "buttonX_Close");
            buttonX_Close.Name = "buttonX_Close";
            buttonX_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            buttonX_Close.Symbol = "\uf011";
            buttonX_Close.TextColor = System.Drawing.Color.SteelBlue;
            buttonX_Close.Click += new System.EventHandler(buttonX_Close_Click);
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
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(textBox_DataBaseNm);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(buttonX_Close);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(buttonX_OK);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            textBox_DataBaseNm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(textBox_DataBaseNm, "textBox_DataBaseNm");
            textBox_DataBaseNm.ForeColor = System.Drawing.Color.Maroon;
            textBox_DataBaseNm.Name = "textBox_DataBaseNm";
            textBox_DataBaseNm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox_DataBaseNm_KeyPress);
            textBox_DataBaseNm.Enter += new System.EventHandler(textBox_DataBaseNm_Enter);
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.ForeColor = System.Drawing.Color.SteelBlue;
            label1.Name = "label1";
            buttonX_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            buttonX_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            resources.ApplyResources(buttonX_OK, "buttonX_OK");
            buttonX_OK.Name = "buttonX_OK";
            buttonX_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            buttonX_OK.Symbol = "\uf00c";
            buttonX_OK.TextColor = System.Drawing.Color.White;
            buttonX_OK.Click += new System.EventHandler(buttonX_OK_Click);
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            base.ControlBox = false;
            base.Controls.Add(ribbonBar1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "FrmNewDB";
            base.Load += new System.EventHandler(FrmNewDB_Load);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmNewDB_KeyDown);
            ribbonBar1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }
        public FrmNewDB()
        {
            InitializeComponent();
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                buttonX_Close.Text = "إغلاق";
                buttonX_OK.Text = "موافق";
                label1.Text = "إسم قاعدة البيانات :";
                label3.Text = "إضافة قاعدة بيانات جديدة";
            }
            else
            {
                buttonX_Close.Text = "Close";
                buttonX_OK.Text = "OK";
                label1.Text = "Data Base Name :";
                label3.Text = "ADD NEW DATA BASE";
            }
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmNewDB));
                if (base.Parent.RightToLeft == RightToLeft.Yes)
                {
                    Language.ChangeLanguage("ar-SA", this, resources);
                    LangArEn = 0;
                }
                else
                {
                    Language.ChangeLanguage("en", this, resources);
                    LangArEn = 1;
                }
            }
        }
        private void FrmNewDB_Load(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmNewDB));
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
        }
        private void FrmNewDB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void buttonX_OK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_DataBaseNm.Text))
            {
                return;
            }
            List<string> q = db.ExecuteQuery<string>("SELECT name FROM sys.databases Where name = 'DBSSS_" + textBox_DataBaseNm.Text + "' ORDER BY name ", new object[0]).ToList();
            if (q.Count > 0)
            {
                MessageBox.Show((LangArEn == 0) ? " اسم قاعدة البيانات الجديدة موجود في السيرفر الحالي ..\n الرجاء تغيير الاسم والمحاولة مرة اخرى ؟" : " name the new database exists in the current server ..\n Please change the name and try again ?", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            try
            {
                Rate_DataDataContext dbc = new Rate_DataDataContext("Server=" + VarGeneral.gServerName + ";Database=;UID=" + VarGeneral.UsrName + ";PWD=" + VarGeneral.UsrPass);
                FrmMain frm = new FrmMain(null, dbc, textBox_DataBaseNm.Text, 0);
            }
            catch (Exception error)
            {
                MessageBox.Show((LangArEn == 0) ? ("خطأ .. لم يتم اضافة قاعدة البيانات بنجاح \n " + error.Message) : ("Error .. Don't Add Data Base Successfully \n " + error.Message), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                VarGeneral.DebLog.writeLog("buttonItem_AddData_Click:", error, enable: true);
                Application.ExitThread();
            }
            MessageBox.Show((LangArEn == 0) ? (" تم اضافة قاعدة البيانات : " + textBox_DataBaseNm.Text) : (" .. Add Data Base is : " + textBox_DataBaseNm.Text), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Close();
        }
        private void buttonX_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void textBox_DataBaseNm_Enter(object sender, EventArgs e)
        {
            Language.Switch("EN");
        }
        private void textBox_DataBaseNm_KeyPress(object sender, KeyPressEventArgs e)
        {
            Language.Switch("EN");
        }
    }
}
