using Check_Data.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FMBranchSelect : Form
    {
        private T_Branch _Branch = new T_Branch();
        private List<T_Branch> list = new List<T_Branch>();
        private int LangArEn = 0;
        private Rate_DataDataContext dbInstance;
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
        private TextBox txtOldBranch;
        private LabelX labelX1;
        private ButtonX buttonX_Close;
        private ComboBoxEx CmbNewBranch;
        private ButtonX buttonX_Ok;
        private Rate_DataDataContext dbc
        {
            get
            {
                if (dbInstance == null)
                {
                    dbInstance = new Rate_DataDataContext(VarGeneral.BranchRt);
                }
                return dbInstance;
            }
        }
        public FMBranchSelect()
        {
            InitializeComponent();
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                buttonX_Close.Text = "إغلاق";
                buttonX_Ok.Text = "موافــــق";
                labelX1.Text = " تغيير الفرع الحالي ";
            }
            else
            {
                buttonX_Close.Text = "Close";
                buttonX_Ok.Text = "OK";
                labelX1.Text = "Change Branch";
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FMBranchSelect));
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    Language.ChangeLanguage("ar-SA", this, resources);
                    LangArEn = 0;
                }
                else if (VarGeneral.CurrentLang.ToString() == "1")
                {
                    Language.ChangeLanguage("en", this, resources);
                    LangArEn = 1;
                }
                FillData();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("OnLoad:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FMBranchSelect));
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                RightToLeft = RightToLeft.Yes;
                Language.ChangeLanguage("ar-SA", this, resources);
                LangArEn = 0;
            }
            else if (VarGeneral.CurrentLang.ToString() == "1")
            {
                RightToLeft = RightToLeft.No;
                Language.ChangeLanguage("en", this, resources);
                LangArEn = 1;
            }
            FillData();
        }
        private void FillData()
        {
            try
            {
                txtOldBranch.Tag = VarGeneral.BranchNumber;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    List<T_Branch> listBranch = new List<T_Branch>(dbc.T_Branches.Where((T_Branch item) => item.Branch_no != VarGeneral.BranchNumber).ToList());
                    CmbNewBranch.DataSource = listBranch;
                    CmbNewBranch.DisplayMember = "Branch_Name";
                    CmbNewBranch.ValueMember = "Branch_no";
                }
                else
                {
                    List<T_Branch> listBranch = new List<T_Branch>(dbc.T_Branches.Where((T_Branch item) => item.Branch_no != VarGeneral.BranchNumber).ToList());
                    CmbNewBranch.DataSource = listBranch;
                    CmbNewBranch.DisplayMember = "Branch_NameE";
                    CmbNewBranch.ValueMember = "Branch_no";
                }
                RibunButtons();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FillData:", error, enable: true);
            }
        }
        private void buttonX_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(CmbNewBranch.Text != "") || CmbNewBranch.SelectedIndex < 0)
                {
                    return;
                }
                if (File.Exists(Application.StartupPath + "\\SqlPath.xml"))
                {
                    T_Branch br = dbc.RateBranch(CmbNewBranch.SelectedValue.ToString());

                    VarGeneral.BranchNumber = br.Branch_no;
                    VarGeneral.BranchNameA = br.Branch_Name;
                    VarGeneral.BranchNameE = br.Branch_NameE;
                    VarGeneral.ChangBr_ = true;
                    new FrmMain(null, null, VarGeneral.BranchNumber, 0);
                    MessageBox.Show((LangArEn == 0) ? " تم تغيير مسار قاعدة البيانات بنجاح..  " : "Data Base Path is Changed successfully .. ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    try
                    {
                        new FrmMain(null, null, VarGeneral.BranchNumber, 0);
                        //VarGeneral.currentDbVersion = DBUdate.DbUpdates.GetDatabaseVersion();

                        //if (VarGeneral.currentDbVersion == "ERROR" || VarGeneral.currentDbVersion == "old")
                        //{
                        //    MessageBox.Show("إصدار قاعدة البيانات لهذا الفرع قديمة اضغط موافق للتحديث وانتضر قليلا");
                        //    this.Enabled = false;

                        //    DBUdate.DbUpdates.internalupdate(0);
                        //    this.Enabled = true;

                        //}

                    }
                    catch
                    {
                    }
                    Close();
                }
                else
                {
                    MessageBox.Show((LangArEn == 0) ? "خطأ .. لم يتم الوصول الى الملف الخاص ببيانات السيرفر ؟" : "Error .. Not Found Data Server File ?", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            catch (Exception error)
            {
                VarGeneral.ChangBr_ = false;
                MessageBox.Show((LangArEn == 0) ? "لم يتم تغيير مسار قاعدة البيانات بنجاح.." : "Data Base Path not Changed", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                VarGeneral.DebLog.writeLog("buttonX_Ok_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void buttonX_Close_Click(object sender, EventArgs e)
        {
            Close();
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
            if (e.KeyCode == Keys.F2 && buttonX_Ok.Enabled && buttonX_Ok.Visible)
            {
                buttonX_Ok_Click(sender, e);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMBranchSelect));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();

            components = new System.ComponentModel.Container();

            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CmbNewBranch = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtOldBranch = new System.Windows.Forms.TextBox();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
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
            this.ribbonBar1.Size = new System.Drawing.Size(318, 188);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 869;
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
            this.panel1.Controls.Add(this.CmbNewBranch);
            this.panel1.Controls.Add(this.txtOldBranch);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Controls.Add(this.buttonX_Close);
            this.panel1.Controls.Add(this.buttonX_Ok);
            this.panel1.Location = new System.Drawing.Point(10, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 160);
            this.panel1.TabIndex = 858;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // CmbNewBranch
            // 
            this.CmbNewBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbNewBranch.DisplayMember = "Text";
            this.CmbNewBranch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbNewBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbNewBranch.ForeColor = System.Drawing.Color.SteelBlue;
            this.CmbNewBranch.FormattingEnabled = true;
            this.CmbNewBranch.ItemHeight = 14;
            this.CmbNewBranch.Location = new System.Drawing.Point(22, 64);
            this.CmbNewBranch.Name = "CmbNewBranch";
            this.CmbNewBranch.Size = new System.Drawing.Size(256, 20);
            this.CmbNewBranch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbNewBranch.TabIndex = 1;
            // 
            // txtOldBranch
            // 
            this.txtOldBranch.BackColor = System.Drawing.Color.White;
            this.txtOldBranch.Location = new System.Drawing.Point(309, 50);
            this.txtOldBranch.Name = "txtOldBranch";
            this.netResize1.SetResizeTextBoxMultiline(this.txtOldBranch, false);
            this.txtOldBranch.ReadOnly = true;
            this.txtOldBranch.Size = new System.Drawing.Size(190, 20);
            this.txtOldBranch.TabIndex = 91;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.DimGray;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX1.Font = new System.Drawing.Font("Tahoma", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labelX1.ForeColor = System.Drawing.Color.White;
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(300, 26);
            this.labelX1.TabIndex = 88;
            this.labelX1.Text = "تغيير مسار قاعدة البيانات ( تغيير الفرع )";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // buttonX_Close
            // 
            this.buttonX_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Close.Checked = true;
            this.buttonX_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_Close.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonX_Close.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.buttonX_Close.Location = new System.Drawing.Point(18, 106);
            this.buttonX_Close.Name = "buttonX_Close";
            this.buttonX_Close.Size = new System.Drawing.Size(122, 39);
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
            this.buttonX_Ok.Location = new System.Drawing.Point(156, 106);
            this.buttonX_Ok.Name = "buttonX_Ok";
            this.buttonX_Ok.Size = new System.Drawing.Size(122, 38);
            this.buttonX_Ok.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Ok.Symbol = "";
            this.buttonX_Ok.TabIndex = 2;
            this.buttonX_Ok.Text = "موافــــق";
            this.buttonX_Ok.TextColor = System.Drawing.Color.White;
            this.buttonX_Ok.Click += new System.EventHandler(this.buttonX_Ok_Click);
            // 
            // FMBranchSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 188);
            this.ControlBox = false;
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FMBranchSelect";
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FMBranchSelect_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.ribbonBar1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.ResumeLayout(false);
        }
        private void FMBranchSelect_Load(object sender, EventArgs e)
        {
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
