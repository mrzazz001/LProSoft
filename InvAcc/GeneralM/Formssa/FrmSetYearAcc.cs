using DevComponents.DotNetBar;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Drawing;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmSetYearAcc : Form
    {
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private int LangArEn = 0;
        private Stock_DataDataContext dbInstance;
        private List<T_SYSSETTING> listSysSetting = new List<T_SYSSETTING>();
        private T_SYSSETTING _SysSetting = new T_SYSSETTING();
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
        private Label label1;
        private LabelX label_HEADER;
        private ButtonX buttonX_Close;
        private ButtonX buttonX_Ok;
        private MaskedTextBox dateTimeInput_DT;
        private MaskedTextBox dateTimeInput_DTEnd;
        private Label label54;
        private Label label55;
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
        public FrmSetYearAcc()
        {
            InitializeComponent();
        }
        private void FrmSetYearAcc_Load(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmSetYearAcc));
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Language.ChangeLanguage("ar-SA", this, resources);
                RightToLeft = RightToLeft.Yes;
                LangArEn = 0;
            }
            else
            {
                Language.ChangeLanguage("en", this, resources);
                RightToLeft = RightToLeft.Yes;
                LangArEn = 1;
                buttonX_Close.Text = "Close ";
                buttonX_Ok.Text = "OK";
            }
            _SysSetting = db.SystemSettingStock();
            if (VarGeneral.CheckDate(_SysSetting.AccSupDes.Trim()))
            {
                dateTimeInput_DT.Text = Convert.ToDateTime(_SysSetting.AccSupDes.Trim()).ToString("yyyy/MM/dd");
            }
            if (VarGeneral.CheckDate(_SysSetting.AccCusDes.Trim()))
            {
                dateTimeInput_DTEnd.Text = Convert.ToDateTime(_SysSetting.AccCusDes.Trim()).ToString("yyyy/MM/dd");
            }
        }
        private void buttonX_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void buttonX_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                string vDT = "";
                string vDTEnd = "";
                if (VarGeneral.CheckDate(dateTimeInput_DT.Text))
                {
                    vDT = Convert.ToDateTime(dateTimeInput_DT.Text).ToString("yyyy/MM/dd");
                }
                if (VarGeneral.CheckDate(dateTimeInput_DTEnd.Text))
                {
                    vDTEnd = Convert.ToDateTime(dateTimeInput_DTEnd.Text).ToString("yyyy/MM/dd");
                }
                if (!VarGeneral.CheckDate(vDTEnd))
                {
                    vDT = "";
                }
                if (!VarGeneral.CheckDate(vDT))
                {
                    vDTEnd = "";
                }
                if (VarGeneral.CheckDate(vDT) && !VarGeneral.CheckDate(vDTEnd))
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من صحة تاريخ النهاية " : "End Date is Uncorrecte", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    dateTimeInput_DTEnd.Focus();
                    return;
                }
                if (!VarGeneral.CheckDate(vDT) && VarGeneral.CheckDate(vDTEnd))
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من صحة تاريخ البداية " : "Start Date is Uncorrecte", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    dateTimeInput_DT.Focus();
                    return;
                }
                if (VarGeneral.CheckDate(vDT) && VarGeneral.CheckDate(vDTEnd) && Convert.ToDateTime(vDTEnd) < Convert.ToDateTime(vDT))
                {
                    MessageBox.Show((LangArEn == 0) ? "تأكد من صحة تاريخ البدايةوالنهاية " : "Start Date and End Date is Uncorrecte", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    vDTEnd = "";
                    dateTimeInput_DT.Focus();
                    return;
                }
                _SysSetting.AccCusDes = vDTEnd;
                _SysSetting.AccSupDes = vDT;
                db.Log = VarGeneral.DebugLog;
                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                MessageBox.Show(".. لقد تم تعيين السنة المالية بنجاح", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                try
                {
                    Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
                    VarGeneral.Settings_Sys = new T_SYSSETTING();
                    VarGeneral.Settings_Sys = dbc.SystemSettingStock();
                }
                catch
                {
                    Application.Exit();
                }
                Close();
            }
            catch
            {
                MessageBox.Show("لقد فمت بإدخال تاريخ غير صحيح ,تأكد من صحة التاريخ ثم حاول مجدداآ", VarGeneral.ProdectNam, MessageBoxButtons.OK);
            }
        }
        private void FrmSetYearAcc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && buttonX_Ok.Enabled && buttonX_Ok.Visible)
            {
                buttonX_Ok_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void dateTimeInput_DT_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_DT.Text = Convert.ToDateTime(dateTimeInput_DT.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_DT.Text = "";
            }
        }
        private void dateTimeInput_DTEnd_Leave(object sender, EventArgs e)
        {
            try
            {
                dateTimeInput_DTEnd.Text = Convert.ToDateTime(dateTimeInput_DTEnd.Text).ToString("yyyy/MM/dd");
            }
            catch
            {
                dateTimeInput_DTEnd.Text = "";
            }
        }
        private void dateTimeInput_DT_Click(object sender, EventArgs e)
        {
            dateTimeInput_DT.SelectAll();
        }
        private void dateTimeInput_DTEnd_Click(object sender, EventArgs e)
        {
            dateTimeInput_DTEnd.SelectAll();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSetYearAcc));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();

            components = new System.ComponentModel.Container();

            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.dateTimeInput_DTEnd = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_DT = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_HEADER = new DevComponents.DotNetBar.LabelX();
            this.buttonX_Close = new DevComponents.DotNetBar.ButtonX();
            this.buttonX_Ok = new DevComponents.DotNetBar.ButtonX();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();

            this.ribbonBar1.SuspendLayout();
            this.panel1.SuspendLayout();

            this.PanelSpecialContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSpecialContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelSpecialContainer.Name = "PanelSpecialContainer";
            this.PanelSpecialContainer.Size = new System.Drawing.Size(1278, 514);
            this.PanelSpecialContainer.TabIndex = 1220;
            this.Controls.Add(this.PanelSpecialContainer);
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
            this.ribbonBar1.Size = new System.Drawing.Size(504, 223);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 870;
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
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label54);
            this.panel1.Controls.Add(this.label55);
            this.panel1.Controls.Add(this.dateTimeInput_DTEnd);
            this.panel1.Controls.Add(this.dateTimeInput_DT);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label_HEADER);
            this.panel1.Controls.Add(this.buttonX_Close);
            this.panel1.Controls.Add(this.buttonX_Ok);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(507, 208);
            this.panel1.TabIndex = 858;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.BackColor = System.Drawing.Color.Transparent;
            this.label54.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label54.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label54.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label54.Location = new System.Drawing.Point(381, 94);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(41, 13);
            this.label54.TabIndex = 6688;
            this.label54.Text = "مــــن :";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.BackColor = System.Drawing.Color.Transparent;
            this.label55.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label55.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label55.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label55.Location = new System.Drawing.Point(381, 121);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(42, 13);
            this.label55.TabIndex = 6689;
            this.label55.Text = "إلـــى :";
            // 
            // dateTimeInput_DTEnd
            // 
            this.dateTimeInput_DTEnd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dateTimeInput_DTEnd.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.dateTimeInput_DTEnd.Location = new System.Drawing.Point(115, 117);
            this.dateTimeInput_DTEnd.Mask = "0000/00/00";
            this.dateTimeInput_DTEnd.Name = "dateTimeInput_DTEnd";
            this.dateTimeInput_DTEnd.Size = new System.Drawing.Size(260, 21);
            this.dateTimeInput_DTEnd.TabIndex = 93;
            this.dateTimeInput_DTEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_DTEnd.Click += new System.EventHandler(this.dateTimeInput_DTEnd_Click);
            this.dateTimeInput_DTEnd.Leave += new System.EventHandler(this.dateTimeInput_DTEnd_Leave);
            // 
            // dateTimeInput_DT
            // 
            this.dateTimeInput_DT.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dateTimeInput_DT.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.dateTimeInput_DT.Location = new System.Drawing.Point(115, 90);
            this.dateTimeInput_DT.Mask = "0000/00/00";
            this.dateTimeInput_DT.Name = "dateTimeInput_DT";
            this.dateTimeInput_DT.Size = new System.Drawing.Size(260, 21);
            this.dateTimeInput_DT.TabIndex = 92;
            this.dateTimeInput_DT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dateTimeInput_DT.Click += new System.EventHandler(this.dateTimeInput_DT_Click);
            this.dateTimeInput_DT.Leave += new System.EventHandler(this.dateTimeInput_DT_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(72, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(373, 13);
            this.label1.TabIndex = 90;
            this.label1.Text = "سيتم تعيين السنة المالية للنظام ,يرجى كتابة تاريخ البداية لإتمام العملية";
            // 
            // label_HEADER
            // 
            this.label_HEADER.BackColor = System.Drawing.Color.DimGray;
            // 
            // 
            // 
            this.label_HEADER.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.label_HEADER.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_HEADER.Font = new System.Drawing.Font("Tahoma", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label_HEADER.ForeColor = System.Drawing.Color.White;
            this.label_HEADER.Location = new System.Drawing.Point(0, 0);
            this.label_HEADER.Name = "label_HEADER";
            this.label_HEADER.Size = new System.Drawing.Size(505, 26);
            this.label_HEADER.TabIndex = 88;
            this.label_HEADER.Text = "تعيين السنة المالية";
            this.label_HEADER.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // buttonX_Close
            // 
            this.buttonX_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Close.Checked = true;
            this.buttonX_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_Close.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonX_Close.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.buttonX_Close.Location = new System.Drawing.Point(115, 151);
            this.buttonX_Close.Name = "buttonX_Close";
            this.buttonX_Close.Size = new System.Drawing.Size(129, 38);
            this.buttonX_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Close.Symbol = "";
            this.buttonX_Close.TabIndex = 3;
            this.buttonX_Close.Text = "إغلاق";
            this.buttonX_Close.TextColor = System.Drawing.Color.Black;
            this.buttonX_Close.Click += new System.EventHandler(this.buttonX_Close_Click);
            // 
            // buttonX_Ok
            // 
            this.buttonX_Ok.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Ok.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX_Ok.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonX_Ok.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.buttonX_Ok.Location = new System.Drawing.Point(246, 151);
            this.buttonX_Ok.Name = "buttonX_Ok";
            this.buttonX_Ok.Size = new System.Drawing.Size(129, 38);
            this.buttonX_Ok.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Ok.Symbol = "";
            this.buttonX_Ok.TabIndex = 2;
            this.buttonX_Ok.Text = "موافــــق";
            this.buttonX_Ok.TextColor = System.Drawing.Color.White;
            this.buttonX_Ok.Click += new System.EventHandler(this.buttonX_Ok_Click);
            // 
            // FrmSetYearAcc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(504, 223);
            this.ControlBox = false;
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.KeyPreview = true;
            this.Name = "FrmSetYearAcc";
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmSetYearAcc_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSetYearAcc_KeyDown);
            this.ribbonBar1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.ResumeLayout(false);
        }
    }
}
