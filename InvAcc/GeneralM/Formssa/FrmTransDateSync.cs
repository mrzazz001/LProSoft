using DevComponents.DotNetBar;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmTransDateSync : Form
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

        private RibbonBar ribbonBar1;
        private Panel panel1;
        private MaskedTextBox dateTimeInput_DateG;
        private MaskedTextBox dateTimeInput_DateH;
        private Label label1;
        private Label label2;
        private ButtonX buttonX_Close;
        private LabelX label3;
        public ButtonX ButOk;
        private int LangArEn = 0;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private List<T_SYSSETTING> listSysSetting = new List<T_SYSSETTING>();
        private T_SYSSETTING _SysSetting = new T_SYSSETTING();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmTransDateSync));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();

            components = new System.ComponentModel.Container();

            ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            panel1 = new System.Windows.Forms.Panel();
            ButOk = new DevComponents.DotNetBar.ButtonX();
            label3 = new DevComponents.DotNetBar.LabelX();
            buttonX_Close = new DevComponents.DotNetBar.ButtonX();
            dateTimeInput_DateG = new System.Windows.Forms.MaskedTextBox();
            dateTimeInput_DateH = new System.Windows.Forms.MaskedTextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();

            ribbonBar1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            ribbonBar1.AccessibleDescription = null;
            ribbonBar1.AccessibleName = null;
            resources.ApplyResources(ribbonBar1, "ribbonBar1");
            ribbonBar1.AutoOverflowEnabled = true;
            ribbonBar1.BackgroundImage = null;
            ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.ContainerControlProcessDialogKey = true;
            ribbonBar1.Controls.Add(panel1);
            ribbonBar1.Font = null;
            ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            ribbonBar1.Name = "ribbonBar1";
            ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.FromArgb(227, 239, 255);
            ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(101, 147, 207);
            ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.ItemClick += new System.EventHandler(ribbonBar1_ItemClick);
            panel1.AccessibleDescription = null;
            panel1.AccessibleName = null;
            resources.ApplyResources(panel1, "panel1");
            panel1.BackColor = System.Drawing.Color.Transparent;
            panel1.BackgroundImage = null;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(ButOk);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(buttonX_Close);
            panel1.Controls.Add(dateTimeInput_DateG);
            panel1.Controls.Add(dateTimeInput_DateH);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Font = null;
            panel1.Name = "panel1";
            ButOk.AccessibleDescription = null;
            ButOk.AccessibleName = null;
            ButOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(ButOk, "ButOk");
            ButOk.BackgroundImage = null;
            ButOk.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            ButOk.CommandParameter = null;
            ButOk.Name = "ButOk";
            ButOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButOk.Symbol = "\uf00c";
            ButOk.SymbolSize = 16f;
            ButOk.TextColor = System.Drawing.Color.White;
            ButOk.Click += new System.EventHandler(ButOk_Click);
            label3.AccessibleDescription = null;
            label3.AccessibleName = null;
            resources.ApplyResources(label3, "label3");
            label3.BackColor = System.Drawing.Color.SteelBlue;
            label3.BackgroundImage = null;
            label3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            label3.CommandParameter = null;
            label3.ForeColor = System.Drawing.Color.White;
            label3.Name = "label3";
            label3.TextAlignment = System.Drawing.StringAlignment.Center;
            buttonX_Close.AccessibleDescription = null;
            buttonX_Close.AccessibleName = null;
            buttonX_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(buttonX_Close, "buttonX_Close");
            buttonX_Close.BackgroundImage = null;
            buttonX_Close.Checked = true;
            buttonX_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            buttonX_Close.CommandParameter = null;
            buttonX_Close.Name = "buttonX_Close";
            buttonX_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            buttonX_Close.Symbol = "\uf011";
            buttonX_Close.TextColor = System.Drawing.Color.Black;
            buttonX_Close.Click += new System.EventHandler(buttonX_Close_Click);
            dateTimeInput_DateG.AccessibleDescription = null;
            dateTimeInput_DateG.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_DateG, "dateTimeInput_DateG");
            dateTimeInput_DateG.BackColor = System.Drawing.Color.SteelBlue;
            dateTimeInput_DateG.BackgroundImage = null;
            dateTimeInput_DateG.ForeColor = System.Drawing.Color.White;
            dateTimeInput_DateG.Name = "dateTimeInput_DateG";
            dateTimeInput_DateG.Leave += new System.EventHandler(dateTimeInput_DateG_Leave);
            dateTimeInput_DateG.Click += new System.EventHandler(dateTimeInput_DateG_Click);
            dateTimeInput_DateH.AccessibleDescription = null;
            dateTimeInput_DateH.AccessibleName = null;
            resources.ApplyResources(dateTimeInput_DateH, "dateTimeInput_DateH");
            dateTimeInput_DateH.BackColor = System.Drawing.Color.SteelBlue;
            dateTimeInput_DateH.BackgroundImage = null;
            dateTimeInput_DateH.ForeColor = System.Drawing.Color.White;
            dateTimeInput_DateH.Name = "dateTimeInput_DateH";
            dateTimeInput_DateH.Leave += new System.EventHandler(dateTimeInput_DateH_Leave);
            dateTimeInput_DateH.Click += new System.EventHandler(dateTimeInput_DateH_Click);
            label1.AccessibleDescription = null;
            label1.AccessibleName = null;
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.ForeColor = System.Drawing.Color.SteelBlue;
            label1.Name = "label1";
            label2.AccessibleDescription = null;
            label2.AccessibleName = null;
            resources.ApplyResources(label2, "label2");
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.ForeColor = System.Drawing.Color.SteelBlue;
            label2.Name = "label2";
            base.AccessibleDescription = null;
            base.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = null;
            base.ControlBox = false;
            base.Controls.Add(ribbonBar1);
            Font = null;
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.Icon = null;
            base.KeyPreview = true;
            base.Name = "FrmTransDateSync";
            base.ShowIcon = false;
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Frm_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(Frm_KeyDown);
            ribbonBar1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }
        public FrmTransDateSync()
        {
            InitializeComponent();
            dateTimeInput_DateG.Text = VarGeneral.Gdate;
            dateTimeInput_DateH.Text = VarGeneral.Hdate;
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                buttonX_Close.Text = "إغلاق";
                ButOk.Text = "حفــظ";
                label1.Text = "التاريخ الميـلادي :";
                label2.Text = "التاريخ الهجـــري :";
                label3.Text = "تاريخ جلسة العمل";
            }
            else
            {
                buttonX_Close.Text = "Close";
                ButOk.Text = "Save";
                label1.Text = "Date / Gregorian :";
                label2.Text = "Date / Hijri :";
                label3.Text = "Session Date";
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmTransDateSync));
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
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmTransDateSync));
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
        }
        private void dateTimeInput_DateH_Click(object sender, EventArgs e)
        {
            dateTimeInput_DateH.SelectAll();
        }
        private void dateTimeInput_DateG_Click(object sender, EventArgs e)
        {
            dateTimeInput_DateG.SelectAll();
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
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void dateTimeInput_DateH_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(dateTimeInput_DateH.Text))
                {
                    dateTimeInput_DateG.Text = n.HijriToGreg(n.GDateAdd3(dateTimeInput_DateH.Text, VarGeneral.Settings_Sys.HDat.Value), "yyyy/MM/dd");
                    return;
                }
                dateTimeInput_DateG.Text = VarGeneral.Gdate;
                dateTimeInput_DateH.Text = VarGeneral.Hdate;
            }
            catch
            {
                dateTimeInput_DateG.Text = VarGeneral.Gdate;
                dateTimeInput_DateH.Text = VarGeneral.Hdate;
            }
        }
        private void dateTimeInput_DateG_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(dateTimeInput_DateG.Text))
                {
                    dateTimeInput_DateH.Text = n.GregToHijri(n.GDateAdd2(dateTimeInput_DateG.Text, VarGeneral.Settings_Sys.HDat.Value), "yyyy/MM/dd");
                    return;
                }
                dateTimeInput_DateG.Text = VarGeneral.Gdate;
                dateTimeInput_DateH.Text = VarGeneral.Hdate;
            }
            catch
            {
                dateTimeInput_DateG.Text = VarGeneral.Gdate;
                dateTimeInput_DateH.Text = VarGeneral.Hdate;
            }
        }
        private void buttonX_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ribbonBar1_ItemClick(object sender, EventArgs e)
        {
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            try
            {
                int GdateY = int.Parse(dateTimeInput_DateG.Text.Substring(0, 4));
                int GdateM = int.Parse(dateTimeInput_DateG.Text.Substring(5, 2));
                int GdateD = int.Parse(dateTimeInput_DateG.Text.Substring(8, 2));
                int GdateY_h = int.Parse(dateTimeInput_DateH.Text.Substring(0, 4));
                int GdateM_h = int.Parse(dateTimeInput_DateH.Text.Substring(5, 2));
                int GdateD_h = int.Parse(dateTimeInput_DateH.Text.Substring(8, 2));
                try
                {
                    DateTime TmpdateTime = new DateTime(GdateY, GdateM, GdateD);
                    VarGeneral.Gdate = n.FormatGreg(TmpdateTime.Year + "/" + TmpdateTime.Month + "/" + TmpdateTime.Day, "yyyy/MM/dd");
                }
                catch
                {
                    DateTime TmpdateTime = default(DateTime);
                    DateTime TmpdateTime_h = new DateTime(GdateY_h, GdateM_h, GdateD_h);
                    VarGeneral.Hdate = n.FormatHijri(TmpdateTime_h.Year + "/" + TmpdateTime_h.Month + "/" + TmpdateTime_h.Day, "yyyy/MM/dd");
                    VarGeneral.Gdate = n.HijriToGreg(VarGeneral.Hdate, "yyyy/MM/dd");
                }
                try
                {
                    DateTime TmpdateTime_h = new DateTime(GdateY_h, GdateM_h, GdateD_h);
                    VarGeneral.Hdate = n.FormatHijri(TmpdateTime_h.Year + "/" + TmpdateTime_h.Month + "/" + TmpdateTime_h.Day, "yyyy/MM/dd");
                }
                catch
                {
                    DateTime TmpdateTime_h = default(DateTime);
                    VarGeneral.Hdate = n.GregToHijri(VarGeneral.Gdate, "yyyy/MM/dd");
                }
                Close();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("ButOk_Click:", error, enable: true);
                MessageBox.Show(error.Message);
                db.getdate = "";
                Close();
            }
        }
    }
}
