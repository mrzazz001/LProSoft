using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Framework.UI;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmTransItmAcc : Form
    {
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
        private GroupBox groupBox_BranchFrom;
        private GroupBox groupBox_BranchTo;
        private GroupBox groupBox_Choese;
        private ComboBoxEx combobox_BranchFrom;
        private ComboBoxEx combobox_BranchTo;
        private CheckBoxX chk1;
        private CheckBoxX chk2;
        private ButtonX ButExit;
        private ButtonX ButOk;
        private TextBox textBox_Det;
        private ProgressBarX ProgressBar1;
        private int LangArEn = 0;
        private T_User _User = new T_User();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTransItmAcc));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();

            components = new System.ComponentModel.Container();

            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox_Det = new System.Windows.Forms.TextBox();
            this.groupBox_BranchFrom = new System.Windows.Forms.GroupBox();
            this.combobox_BranchFrom = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.groupBox_BranchTo = new System.Windows.Forms.GroupBox();
            this.combobox_BranchTo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.groupBox_Choese = new System.Windows.Forms.GroupBox();
            this.chk1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.ProgressBar1 = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.ButOk = new DevComponents.DotNetBar.ButtonX();
            this.ButExit = new DevComponents.DotNetBar.ButtonX();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();

            this.ribbonBar1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox_BranchFrom.SuspendLayout();
            this.groupBox_BranchTo.SuspendLayout();
            this.groupBox_Choese.SuspendLayout();

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
            this.ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.Silver;
            this.ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.panel1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(343, 347);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 1195;
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
            this.panel1.Controls.Add(this.textBox_Det);
            this.panel1.Controls.Add(this.groupBox_BranchFrom);
            this.panel1.Controls.Add(this.groupBox_BranchTo);
            this.panel1.Controls.Add(this.groupBox_Choese);
            this.panel1.Controls.Add(this.ProgressBar1);
            this.panel1.Controls.Add(this.ButOk);
            this.panel1.Controls.Add(this.ButExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 330);
            this.panel1.TabIndex = 2;
            // 
            // textBox_Det
            // 
            this.textBox_Det.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox_Det.Font = new System.Drawing.Font("Tahoma", 8F);
            this.textBox_Det.ForeColor = System.Drawing.Color.Black;
            this.textBox_Det.Location = new System.Drawing.Point(10, 167);
            this.textBox_Det.Multiline = true;
            this.textBox_Det.Name = "textBox_Det";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Det, false);
            this.textBox_Det.ReadOnly = true;
            this.textBox_Det.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Det.Size = new System.Drawing.Size(316, 117);
            this.textBox_Det.TabIndex = 7;
            // 
            // groupBox_BranchFrom
            // 
            this.groupBox_BranchFrom.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_BranchFrom.Controls.Add(this.combobox_BranchFrom);
            this.groupBox_BranchFrom.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.groupBox_BranchFrom.Location = new System.Drawing.Point(12, -122);
            this.groupBox_BranchFrom.Name = "groupBox_BranchFrom";
            this.groupBox_BranchFrom.Size = new System.Drawing.Size(498, 75);
            this.groupBox_BranchFrom.TabIndex = 1188;
            this.groupBox_BranchFrom.TabStop = false;
            this.groupBox_BranchFrom.Text = "من فـــــــرع :";
            // 
            // combobox_BranchFrom
            // 
            this.combobox_BranchFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combobox_BranchFrom.DisplayMember = "Text";
            this.combobox_BranchFrom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_BranchFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_BranchFrom.Enabled = false;
            this.combobox_BranchFrom.FormattingEnabled = true;
            this.combobox_BranchFrom.ItemHeight = 15;
            this.combobox_BranchFrom.Location = new System.Drawing.Point(66, 31);
            this.combobox_BranchFrom.Name = "combobox_BranchFrom";
            this.combobox_BranchFrom.Size = new System.Drawing.Size(350, 21);
            this.combobox_BranchFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combobox_BranchFrom.TabIndex = 6;
            // 
            // groupBox_BranchTo
            // 
            this.groupBox_BranchTo.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_BranchTo.Controls.Add(this.combobox_BranchTo);
            this.groupBox_BranchTo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox_BranchTo.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupBox_BranchTo.Location = new System.Drawing.Point(10, 12);
            this.groupBox_BranchTo.Name = "groupBox_BranchTo";
            this.groupBox_BranchTo.Size = new System.Drawing.Size(317, 81);
            this.groupBox_BranchTo.TabIndex = 1187;
            this.groupBox_BranchTo.TabStop = false;
            this.groupBox_BranchTo.Text = "نقل البيانات الى الفرع :";
            // 
            // combobox_BranchTo
            // 
            this.combobox_BranchTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combobox_BranchTo.DisplayMember = "Text";
            this.combobox_BranchTo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_BranchTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_BranchTo.FormattingEnabled = true;
            this.combobox_BranchTo.ItemHeight = 14;
            this.combobox_BranchTo.Location = new System.Drawing.Point(24, 37);
            this.combobox_BranchTo.Name = "combobox_BranchTo";
            this.combobox_BranchTo.Size = new System.Drawing.Size(258, 20);
            this.combobox_BranchTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combobox_BranchTo.TabIndex = 1;
            // 
            // groupBox_Choese
            // 
            this.groupBox_Choese.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_Choese.Controls.Add(this.chk1);
            this.groupBox_Choese.Controls.Add(this.chk2);
            this.groupBox_Choese.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox_Choese.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupBox_Choese.Location = new System.Drawing.Point(10, 99);
            this.groupBox_Choese.Name = "groupBox_Choese";
            this.groupBox_Choese.Size = new System.Drawing.Size(317, 62);
            this.groupBox_Choese.TabIndex = 1186;
            this.groupBox_Choese.TabStop = false;
            this.groupBox_Choese.Tag = "";
            this.groupBox_Choese.Text = "خيارات النقل";
            // 
            // chk1
            // 
            this.chk1.AutoSize = true;
            this.chk1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.chk1.Location = new System.Drawing.Point(178, 28);
            this.chk1.Name = "chk1";
            this.chk1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk1.Size = new System.Drawing.Size(97, 16);
            this.chk1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk1.TabIndex = 2;
            this.chk1.Text = "نقل الأصنـــــــاف";
            // 
            // chk2
            // 
            this.chk2.AutoSize = true;
            this.chk2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.chk2.Location = new System.Drawing.Point(21, 28);
            this.chk2.Name = "chk2";
            this.chk2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk2.Size = new System.Drawing.Size(125, 16);
            this.chk2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk2.TabIndex = 3;
            this.chk2.Text = "نقل كرت الحســــــابات";
            // 
            // ProgressBar1
            // 
            // 
            // 
            // 
            this.ProgressBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ProgressBar1.Location = new System.Drawing.Point(11, 290);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(315, 34);
            this.ProgressBar1.TabIndex = 1189;
            this.ProgressBar1.Text = "progressBarX1";
            this.ProgressBar1.Visible = false;
            // 
            // ButOk
            // 
            this.ButOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButOk.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.ButOk.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButOk.Location = new System.Drawing.Point(173, 292);
            this.ButOk.Name = "ButOk";
            this.ButOk.Size = new System.Drawing.Size(153, 30);
            this.ButOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButOk.Symbol = "";
            this.ButOk.SymbolSize = 16F;
            this.ButOk.TabIndex = 4;
            this.ButOk.Text = "نقــــل";
            this.ButOk.TextColor = System.Drawing.Color.White;
            this.ButOk.Click += new System.EventHandler(this.ButOk_Click);
            // 
            // ButExit
            // 
            this.ButExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButExit.Checked = true;
            this.ButExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ButExit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButExit.Location = new System.Drawing.Point(11, 292);
            this.ButExit.Name = "ButExit";
            this.ButExit.Size = new System.Drawing.Size(153, 30);
            this.ButExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButExit.Symbol = "";
            this.ButExit.SymbolSize = 16F;
            this.ButExit.TabIndex = 5;
            this.ButExit.Text = "خـــروج";
            this.ButExit.TextColor = System.Drawing.Color.Black;
            this.ButExit.Click += new System.EventHandler(this.ButExit_Click);
            // 
            // FrmTransItmAcc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 347);
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmTransItmAcc";
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نقل البيانات بين الفروع";
            this.Load += new System.EventHandler(this.FrmTransItmAcc_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmTransItmAcc_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmTransItmAcc_KeyPress);
            this.ribbonBar1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox_BranchFrom.ResumeLayout(false);
            this.groupBox_BranchTo.ResumeLayout(false);
            this.groupBox_Choese.ResumeLayout(false);
            this.groupBox_Choese.PerformLayout();
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.ResumeLayout(false);
        }
        public FrmTransItmAcc()
        {
            InitializeComponent();
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmTransItmAcc));
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
            FillCombo();
        }
        private void FrmTransItmAcc_Load(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmTransItmAcc));
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
            if (VarGeneral.SSSTyp == 0)
            {
                chk1.Checked = true;
                chk2.Checked = false;
                groupBox_Choese.Visible = false;
                textBox_Det.Size = new Size(316, 184);
                textBox_Det.Location = new Point(10, 99);
            }
            else if (VarGeneral.SSSTyp == 1)
            {
                chk2.Checked = true;
                chk1.Checked = false;
                groupBox_Choese.Visible = false;
                textBox_Det.Size = new Size(316, 184);
                textBox_Det.Location = new Point(10, 99);
            }
            FillCombo();
        }
        private void FillCombo()
        {
            combobox_BranchFrom.DataSource = null;
            combobox_BranchTo.DataSource = null;
            List<T_Branch> qFrom = dbc.T_Branches.Where((T_Branch t) => t.Branch_no == VarGeneral.BranchNumber).ToList();
            combobox_BranchFrom.DataSource = qFrom;
            combobox_BranchFrom.DisplayMember = ((LangArEn == 0) ? "Branch_Name" : "Branch_NameE");
            combobox_BranchFrom.ValueMember = "Branch_no";
            List<T_Branch> qTo = dbc.T_Branches.Where((T_Branch t) => t.Branch_no != VarGeneral.BranchNumber).ToList();
            if (qTo.Count() > 0)
            {
                combobox_BranchTo.DataSource = qTo;
                combobox_BranchTo.DisplayMember = ((LangArEn == 0) ? "Branch_Name" : "Branch_NameE");
                combobox_BranchTo.ValueMember = "Branch_no";
            }
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Text = "نقل البيانات بين الفروع";
            }
            else
            {
                Text = "Transfer Data Between Branches";
            }
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            try
            {
                int Cunit = 0;
                int CCat = 0;
                int CItm = 0;
                int CAccCat = 0;
                int CAccDef = 0;
                textBox_Det.Text = "";
                if (combobox_BranchTo.SelectedIndex == -1)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام العملية قبل تحديد الفرع المراد نقل البياناتا إليه" : "You can not complete the process before determining the branch to be data transfer him", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (!chk1.Checked && !chk2.Checked)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام العملية قبل تحديد خيار واحد على الأقل من خيارات النقل" : "You can not complete the process before determining the branch to be data transfer him", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                Stock_DataDataContext dbTran = new Stock_DataDataContext("Server=" + VarGeneral.gServerName + ";Database=" + VarGeneral.DBNo.Replace("DB", "") + "_" + combobox_BranchTo.SelectedValue.ToString() + ";UID=sa;PWD=" + VarGeneral.UsrPass);
                string xx = "Server=" + VarGeneral.gServerName + ";Database=" + VarGeneral.DBNo.Replace("DB", "") + "_" + combobox_BranchTo.SelectedValue.ToString() + ";UID=sa;PWD=" + VarGeneral.UsrPass;
                if (chk1.Checked)
                {
                    List<T_Unit> vUnit = db.FillUnit_2("").ToList();
                    if (vUnit.Count > 0)
                    {
                        ProgressBar1.Value = 0;
                        ProgressBar1.Maximum = vUnit.Count;
                        ProgressBar1.Minimum = 0;
                        ProgressBar1.Visible = true;
                        int m = 0;
                        while (true)
                        {
                            if (m >= vUnit.Count)
                            {
                                break;
                            }
                            List<T_Unit> q3 = dbTran.T_Units.Where((T_Unit t) => t.Unit_ID == vUnit[m].Unit_ID).ToList();
                            if (q3.Count == 0)
                            {
                                dbTran.ExecuteCommand("SET IDENTITY_INSERT [dbo].[T_Unit] ON\r\n                                                            INSERT [dbo].[T_Unit] ([Unit_ID], [Unit_No], [Arb_Des], [Eng_Des], [CompanyID]) VALUES (" + vUnit[m].Unit_ID + ", N'" + ((dbTran.StockUnit(vUnit[m].Unit_No) == null || dbTran.StockUnit(vUnit[m].Unit_No).Unit_ID == 0) ? vUnit[m].Unit_No : dbTran.MaxUnitNo.ToString()) + "', N'" + vUnit[m].Arb_Des + "', N'" + vUnit[m].Eng_Des + "', 1)\r\n                                                            SET IDENTITY_INSERT [dbo].[T_Unit] OFF");
                                Cunit++;
                                ProgressBar1.Value += 1;
                            }
                            m++;
                        }
                    }
                    ProgressBar1.Visible = false;
                    List<T_CATEGORY> vCat = db.FillCat_2("").ToList();
                    try
                    {
                        vCat = vCat.OrderBy((T_CATEGORY c) => int.Parse(c.CAT_No)).ToList();
                    }
                    catch
                    {
                    }
                    if (vCat.Count > 0)
                    {
                        ProgressBar1.Value = 0;
                        ProgressBar1.Maximum = vCat.Count;
                        ProgressBar1.Minimum = 0;
                        ProgressBar1.Visible = true;
                        int l = 0;
                        while (true)
                        {
                            if (l >= vCat.Count)
                            {
                                break;
                            }
                            List<T_CATEGORY> q4 = dbTran.T_CATEGORies.Where((T_CATEGORY t) => t.CAT_ID == vCat[l].CAT_ID).ToList();
                            if (q4.Count == 0)
                            {
                                dbTran.ExecuteCommand("SET IDENTITY_INSERT [dbo].[T_CATEGORY] ON\r\n                                                            INSERT [dbo].[T_CATEGORY] ([CAT_ID], [CAT_No], [Arb_Des], [Eng_Des], [CompanyID],[TotalPurchaes],[TotalPoint],[CAT_Symbol]) VALUES (" + vCat[l].CAT_ID + ", N'" + ((dbTran.StockCat(vCat[l].CAT_No) == null || dbTran.StockCat(vCat[l].CAT_No).CAT_ID == 0) ? vCat[l].CAT_No : dbTran.MaxCatNo.ToString()) + "', N'" + vCat[l].Arb_Des + "', N'" + vCat[l].Eng_Des + "', 1," + vCat[l].TotalPurchaes.Value + "," + vCat[l].TotalPoint.Value + ", N'" + vCat[l].CAT_Symbol + "')\r\n                                                            SET IDENTITY_INSERT [dbo].[T_CATEGORY] OFF");
                                int max = dbTran.MaxINVSETTING;
                                dbTran.ExecuteCommand("INSERT [dbo].[T_INVSETTING] ([InvID], [InvNamA], [InvNamE], [InvSetting], [InvStartNo], [InvTypA0], [InvTypA1], [InvTypA2], [InvTypA3], [InvTypA4], [InvTypE0], [InvTypE1], [InvTypE2], [InvTypE3], [InvTypE4], [InvColorH], [InvColorD], [InvPrice], [FldA1], [FldA2], [FldA3], [FldA4], [FldA5], [FldE1], [FldE2], [FldE3], [FldE4], [FldE5], [AccCredit0], [AccDebit0], [invALogo], [invELogo], [invGdADesc], [invGdEDesc], [invGdStng], [AccCredit1], [AccDebit1], [AccCredit2], [AccDebit2], [AccCredit3], [AccDebit3], [AccCredit4], [AccDebit4], [hAl], [hAs], [hYm], [hYs], [lnPg], [lnSpc], [defPrn], [nTyp], [ItmTyp], [InvNum], [InvNum1], [DefLines],[CatID],[PrintCat]) VALUES (" + max + ", N'" + vCat[l].Arb_Des + "', N'" + vCat[l].Eng_Des + "', N'212', N'1         ', N'نقدي                          ', N'آجل       ', NULL, NULL, NULL, N'Cash      ', N'Credit    ', NULL, NULL, NULL, -2147483633, 12640511, 0, N'العميل              ', NULL, NULL, NULL, NULL, N'Customer            ', NULL, NULL, NULL, NULL, N'3021001        ', N'1020001        ', NULL, NULL, NULL, NULL, NULL, N'3021005        ', N'***', N'3021005', N'1022001', NULL, NULL, NULL, NULL, 1, 1, 1, 1, 0, 6, N'Microsoft XPS Document Writer', N'110 ', N'1011 ', 1, 1,1," + vCat[l].CAT_ID + ",0)");
                                CCat++;
                                ProgressBar1.Value += 1;
                            }
                            l++;
                        }
                    }
                    ProgressBar1.Visible = false;
                    List<T_Item> vItems = db.FillItem_2("").ToList();
                    if (vItems.Count > 0)
                    {
                        ProgressBar1.Value = 0;
                        ProgressBar1.Maximum = vItems.Count;
                        ProgressBar1.Minimum = 0;
                        ProgressBar1.Visible = true;
                        int k;
                        for (k = 0; k < vItems.Count; k++)
                        {
                            try
                            {
                                List<T_Item> q5 = dbTran.T_Items.Where((T_Item t) => t.Itm_No == vItems[k].Itm_No).ToList();
                                if (q5.Count == 0)
                                {
                                    CItm++;
                                    T_Item vItm = new T_Item();
                                    vItm.Itm_No = vItems[k].Itm_No;
                                    if (vItems[k].ItmCat.HasValue)
                                    {
                                        vItm.ItmCat = vItems[k].ItmCat.Value;
                                    }
                                    vItm.Arb_Des = vItems[k].Arb_Des;
                                    vItm.Eng_Des = vItems[k].Eng_Des;
                                    if (vItems[k].DefultVendor.HasValue)
                                    {
                                        vItm.DefultVendor = vItems[k].DefultVendor.Value;
                                    }
                                    vItm.FirstCost = 0.0;
                                    vItm.StartCost = 0.0;
                                    vItm.AvrageCost = 0.0;
                                    vItm.LastCost = 0.0;
                                    vItm.OpenQty = 0.0;
                                    vItm.ItmLoc = vItems[k].ItmLoc;
                                    if (vItems[k].ItmTyp.HasValue)
                                    {
                                        vItm.ItmTyp = vItems[k].ItmTyp.Value;
                                    }
                                    if (vItems[k].QtyMax.HasValue)
                                    {
                                        vItm.QtyMax = vItems[k].QtyMax.Value;
                                    }
                                    if (vItems[k].QtyLvl.HasValue)
                                    {
                                        vItm.QtyLvl = vItems[k].QtyLvl.Value;
                                    }
                                    if (vItems[k].Lot.HasValue)
                                    {
                                        vItm.Lot = vItems[k].Lot.Value;
                                    }
                                    if (vItems[k].DMY.HasValue)
                                    {
                                        vItm.DMY = vItems[k].DMY.Value;
                                    }
                                    if (vItems[k].LrnExp.HasValue)
                                    {
                                        vItm.LrnExp = vItems[k].LrnExp.Value;
                                    }
                                    if (vItems[k].Unit1.HasValue)
                                    {
                                        vItm.Unit1 = vItems[k].Unit1.Value;
                                    }
                                    if (vItems[k].UntPri1.HasValue)
                                    {
                                        vItm.UntPri1 = vItems[k].UntPri1.Value;
                                    }
                                    if (vItems[k].Pack1.HasValue)
                                    {
                                        vItm.Pack1 = vItems[k].Pack1.Value;
                                    }
                                    if (vItems[k].Unit2.HasValue)
                                    {
                                        vItm.Unit2 = vItems[k].Unit2.Value;
                                    }
                                    if (vItems[k].UntPri2.HasValue)
                                    {
                                        vItm.UntPri2 = vItems[k].UntPri2.Value;
                                    }
                                    if (vItems[k].Pack2.HasValue)
                                    {
                                        vItm.Pack2 = vItems[k].Pack2.Value;
                                    }
                                    if (vItems[k].Unit3.HasValue)
                                    {
                                        vItm.Unit3 = vItems[k].Unit3.Value;
                                    }
                                    if (vItems[k].UntPri3.HasValue)
                                    {
                                        vItm.UntPri3 = vItems[k].UntPri3.Value;
                                    }
                                    if (vItems[k].Pack3.HasValue)
                                    {
                                        vItm.Pack3 = vItems[k].Pack3.Value;
                                    }
                                    if (vItems[k].Unit4.HasValue)
                                    {
                                        vItm.Unit4 = vItems[k].Unit4.Value;
                                    }
                                    if (vItems[k].UntPri4.HasValue)
                                    {
                                        vItm.UntPri4 = vItems[k].UntPri4.Value;
                                    }
                                    if (vItems[k].Pack4.HasValue)
                                    {
                                        vItm.Pack4 = vItems[k].Pack4.Value;
                                    }
                                    if (vItems[k].Unit5.HasValue)
                                    {
                                        vItm.Unit5 = vItems[k].Unit5.Value;
                                    }
                                    if (vItems[k].UntPri5.HasValue)
                                    {
                                        vItm.UntPri5 = vItems[k].UntPri5.Value;
                                    }
                                    if (vItems[k].Pack5.HasValue)
                                    {
                                        vItm.Pack5 = vItems[k].Pack5.Value;
                                    }
                                    if (vItems[k].DefPack.HasValue)
                                    {
                                        vItm.DefPack = vItems[k].DefPack.Value;
                                    }
                                    if (vItems[k].DefultUnit.HasValue)
                                    {
                                        vItm.DefultUnit = vItems[k].DefultUnit.Value;
                                    }
                                    if (vItems[k].Price1.HasValue)
                                    {
                                        vItm.Price1 = vItems[k].Price1;
                                    }
                                    if (vItems[k].Price2.HasValue)
                                    {
                                        vItm.Price2 = vItems[k].Price2;
                                    }
                                    if (vItems[k].Price3.HasValue)
                                    {
                                        vItm.Price3 = vItems[k].Price3;
                                    }
                                    if (vItems[k].Price4.HasValue)
                                    {
                                        vItm.Price4 = vItems[k].Price4;
                                    }
                                    if (vItems[k].Price5.HasValue)
                                    {
                                        vItm.Price5 = vItems[k].Price5;
                                    }
                                    vItm.BarCod1 = vItems[k].BarCod1 ?? "";
                                    vItm.BarCod2 = vItems[k].BarCod2 ?? "";
                                    vItm.BarCod3 = vItems[k].BarCod3 ?? "";
                                    vItm.BarCod4 = vItems[k].BarCod4 ?? "";
                                    vItm.BarCod5 = vItems[k].BarCod5 ?? "";
                                    vItm.ItemComm = vItems[k].ItemComm.Value;
                                    vItm.ItemDis = vItems[k].ItemDis.Value;
                                    vItm.TaxSales = vItems[k].TaxSales.Value;
                                    vItm.TaxPurchas = vItems[k].TaxPurchas.Value;
                                    if (vItems[k].InvSaleStoped.HasValue)
                                    {
                                        vItm.InvSaleStoped = vItems[k].InvSaleStoped.Value;
                                    }
                                    if (vItems[k].InvSaleReturnStoped.HasValue)
                                    {
                                        vItm.InvSaleReturnStoped = vItems[k].InvSaleReturnStoped.Value;
                                    }
                                    if (vItems[k].InvPaymentStoped.HasValue)
                                    {
                                        vItm.InvPaymentStoped = vItems[k].InvPaymentStoped.Value;
                                    }
                                    if (vItems[k].InvPaymentReturnStoped.HasValue)
                                    {
                                        vItm.InvPaymentReturnStoped = vItems[k].InvPaymentReturnStoped;
                                    }
                                    if (vItems[k].InvEnterStoped.HasValue)
                                    {
                                        vItm.InvEnterStoped = vItems[k].InvEnterStoped;
                                    }
                                    if (vItems[k].InvOutStoped.HasValue)
                                    {
                                        vItm.InvOutStoped = vItems[k].InvOutStoped;
                                    }
                                    if (vItems[k].IsBalance.HasValue)
                                    {
                                        vItm.IsBalance = vItems[k].IsBalance.Value;
                                    }
                                    if (vItems[k].IsPoints.HasValue)
                                    {
                                        vItm.IsPoints = vItems[k].IsPoints.Value;
                                    }
                                    if (vItems[k].ItmImg != null)
                                    {
                                        vItm.ItmImg = vItems[k].ItmImg;
                                    }
                                    try
                                    {
                                        vItm.SecriptCeramic = vItems[k].SecriptCeramic;
                                    }
                                    catch
                                    {
                                        vItm.SecriptCeramic = "";
                                    }
                                    try
                                    {
                                        vItm.SecriptCeramicCombo = vItems[k].SecriptCeramicCombo;
                                    }
                                    catch
                                    {
                                        vItm.SecriptCeramicCombo = "0";
                                    }
                                    try
                                    {
                                        vItm.vSize1 = vItems[k].vSize1;
                                        vItm.vSize2 = vItems[k].vSize2;
                                        vItm.vSize3 = vItems[k].vSize3;
                                        vItm.vSize4 = vItems[k].vSize4;
                                        vItm.vSize5 = vItems[k].vSize5;
                                        vItm.vSize6 = vItems[k].vSize6;
                                    }
                                    catch
                                    {
                                    }
                                    vItm.CompanyID = 1;
                                    dbTran.T_Items.InsertOnSubmit(vItm);
                                    dbTran.SubmitChanges();
                                    ProgressBar1.Value += 1;
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                    ProgressBar1.Visible = false;
                    try
                    {
                        textBox_Det.Text = textBox_Det.Text + Environment.NewLine + ((LangArEn == 0) ? (" تم عملية نقل " + Cunit + " وحدة الى كرت الوحدات ") : (" The transfer process " + Cunit + " Unit to the card units "));
                        textBox_Det.Text = textBox_Det.Text + Environment.NewLine + ((LangArEn == 0) ? (" تم عملية نقل " + CCat + " تصنيف الى كرت التصنيفات ") : (" The transfer process " + CCat + " Category to the card Categories "));
                        textBox_Det.Text = textBox_Det.Text + Environment.NewLine + ((LangArEn == 0) ? (" تم عملية نقل " + CItm + " صنف الى كرت الإصناف ") : (" The transfer process " + CItm + " Item to card items "));
                    }
                    catch
                    {
                        textBox_Det.Text = "";
                    }
                    textBox_Det.Text = textBox_Det.Text + Environment.NewLine + ((LangArEn == 0) ? " تمت عملية نقل بيانات الأ\u064bصناف بنجاح ... " : " Data items has successfully transfer process ... ") + Environment.NewLine;
                }
                if (!chk2.Checked)
                {
                    return;
                }
                List<T_AccCat> vAccCat = db.FillAccCat_2("").ToList();
                if (vAccCat.Count > 0)
                {
                    ProgressBar1.Value = 0;
                    ProgressBar1.Maximum = vAccCat.Count;
                    ProgressBar1.Minimum = 0;
                    ProgressBar1.Visible = true;
                    int j = 0;
                    while (true)
                    {
                        if (j >= vAccCat.Count)
                        {
                            break;
                        }
                        List<T_AccCat> q2 = dbTran.T_AccCats.Where((T_AccCat t) => t.AccCat_ID == vAccCat[j].AccCat_ID).ToList();
                        if (q2.Count == 0)
                        {
                            dbTran.ExecuteCommand("SET IDENTITY_INSERT [dbo].[T_AccCat] ON\r\n                                                            INSERT [dbo].[T_AccCat] ([AccCat_ID], [AccCat_No], [Arb_Des], [Eng_Des], [CompanyID]) VALUES (" + vAccCat[j].AccCat_ID + ", N'" + ((dbTran.StockAccCat(vAccCat[j].AccCat_No) == null || dbTran.StockAccCat(vAccCat[j].AccCat_No).AccCat_ID == 0) ? vAccCat[j].AccCat_No : dbTran.MaxAccCatNo.ToString()) + "', N'" + vAccCat[j].Arb_Des + "', N'" + vAccCat[j].Eng_Des + "', 1)\r\n                                                            SET IDENTITY_INSERT [dbo].[T_AccCat] OFF");
                            CAccCat++;
                            ProgressBar1.Value += 1;
                        }
                        j++;
                    }
                }
                ProgressBar1.Visible = false;
                List<T_AccDef> vAccDef = db.FillAccDef_2("").ToList();
                if (vAccDef.Count > 0)
                {
                    int i = 0;
                    while (true)
                    {
                        if (i >= vAccDef.Count)
                        {
                            break;
                        }
                        ProgressBar1.Value = 0;
                        ProgressBar1.Maximum = vAccDef.Count;
                        ProgressBar1.Minimum = 0;
                        ProgressBar1.Visible = true;
                        List<T_AccDef> q = dbTran.T_AccDefs.Where((T_AccDef t) => t.AccDef_No == vAccDef[i].AccDef_No).ToList();
                        if (q.Count == 0)
                        {
                            CAccDef++;
                            T_AccDef vAccDf = new T_AccDef();
                            vAccDf.AccDef_No = vAccDef[i].AccDef_No;
                            vAccDf.Arb_Des = vAccDef[i].Arb_Des;
                            vAccDf.Eng_Des = vAccDef[i].Eng_Des;
                            if (vAccDef[i].Lev.HasValue)
                            {
                                vAccDf.Lev = vAccDef[i].Lev.Value;
                            }
                            vAccDf.ParAcc = vAccDef[i].ParAcc;
                            if (vAccDef[i].AccCat.HasValue)
                            {
                                vAccDf.AccCat = vAccDef[i].AccCat.Value;
                            }
                            if (vAccDef[i].DC.HasValue)
                            {
                                vAccDf.DC = vAccDef[i].DC.Value;
                            }
                            if (vAccDef[i].Sts.HasValue)
                            {
                                vAccDf.Sts = vAccDef[i].Sts.Value;
                            }
                            if (vAccDef[i].MaxLemt.HasValue)
                            {
                                vAccDf.MaxLemt = vAccDef[i].MaxLemt.Value;
                            }
                            vAccDf.Credit = vAccDef[i].Credit;
                            vAccDf.Debit = vAccDef[i].Debit;
                            vAccDf.Balance = vAccDef[i].Balance;
                            vAccDf.Trn = vAccDef[i].Trn;
                            vAccDf.Typ = vAccDef[i].Typ;
                            vAccDf.City = vAccDef[i].City;
                            vAccDf.Email = vAccDef[i].Email;
                            vAccDf.Telphone1 = vAccDef[i].Telphone1;
                            vAccDf.Telphone2 = vAccDef[i].Telphone2;
                            vAccDf.Fax = vAccDef[i].Fax;
                            vAccDf.Mobile = vAccDef[i].Mobile;
                            vAccDf.DesPers = vAccDef[i].DesPers;
                            vAccDf.StrAm = vAccDef[i].StrAm;
                            vAccDf.Adders = vAccDef[i].Adders;
                            vAccDf.Mnd = vAccDef[i].Mnd;
                            vAccDf.Price = vAccDef[i].Price;
                            try
                            {
                                if (vAccDef[i].StopedState.HasValue)
                                {
                                    vAccDf.StopedState = vAccDef[i].StopedState.Value;
                                }
                                else
                                {
                                    vAccDf.StopedState = false;
                                }
                            }
                            catch
                            {
                                vAccDf.StopedState = false;
                            }
                            try
                            {
                                if (vAccDef[i].MainSal.HasValue)
                                {
                                    vAccDf.MainSal = vAccDef[i].MainSal.Value;
                                }
                                else
                                {
                                    vAccDf.MainSal = 0.0;
                                }
                            }
                            catch
                            {
                                vAccDf.MainSal = 0.0;
                            }
                            try
                            {
                                vAccDf.DepreciationPercent = vAccDef[i].DepreciationPercent;
                            }
                            catch
                            {
                                vAccDf.DepreciationPercent = 0.0;
                            }
                            try
                            {
                                vAccDf.MaxDisCust = vAccDef[i].MaxDisCust;
                            }
                            catch
                            {
                                vAccDf.MaxDisCust = 0.0;
                            }
                            try
                            {
                                vAccDf.vColStr1 = vAccDef[i].vColStr1;
                            }
                            catch
                            {
                                vAccDf.vColStr1 = "";
                            }
                            try
                            {
                                vAccDf.vColStr2 = vAccDef[i].vColStr2;
                            }
                            catch
                            {
                                vAccDf.vColStr2 = "";
                            }
                            try
                            {
                                vAccDf.vColStr3 = vAccDef[i].vColStr3;
                            }
                            catch
                            {
                                vAccDf.vColStr3 = "";
                            }
                            try
                            {
                                vAccDf.vColNum1 = vAccDef[i].vColNum1;
                            }
                            catch
                            {
                                vAccDf.vColNum1 = 0.0;
                            }
                            try
                            {
                                vAccDf.vColNum2 = vAccDef[i].vColNum2;
                            }
                            catch
                            {
                                vAccDf.vColNum2 = 0.0;
                            }
                            try
                            {
                                vAccDf.ProofAcc = vAccDef[i].ProofAcc;
                            }
                            catch
                            {
                                vAccDf.ProofAcc = "";
                            }
                            try
                            {
                                vAccDf.RelayAcc = vAccDef[i].RelayAcc;
                            }
                            catch
                            {
                                vAccDf.RelayAcc = "";
                            }
                            vAccDf.BankComm = vAccDef[i].BankComm;
                            vAccDf.TotPoints = vAccDef[i].TotPoints;
                            vAccDf.TaxNo = vAccDef[i].TaxNo;
                            vAccDf.CompanyID = 1;
                            dbTran.T_AccDefs.InsertOnSubmit(vAccDf);
                            dbTran.SubmitChanges();
                            ProgressBar1.Value += 1;
                        }
                        i++;
                    }
                }
                ProgressBar1.Visible = false;
                try
                {
                    textBox_Det.Text = textBox_Det.Text + Environment.NewLine + ((LangArEn == 0) ? (" تم عملية نقل " + CAccCat + " تصنيف حسابي الى كرت تصنيفات الحسابات ") : (" The transfer process " + CAccCat + " Record card to the classification of accounts "));
                    textBox_Det.Text = textBox_Det.Text + Environment.NewLine + ((LangArEn == 0) ? (" تم عملية نقل " + CAccDef + " حساب الى كرت الحسابات ") : (" The transfer process " + CAccDef + " Record to card accounts "));
                }
                catch
                {
                    textBox_Det.Text = "";
                }
                textBox_Det.Text = textBox_Det.Text + Environment.NewLine + ((LangArEn == 0) ? " تمت عملية نقل بيانات الحسابات بنجاح ... " : " It has accounts data transfer process successfully ... ") + Environment.NewLine;
            }
            catch (Exception error)
            {
                ProgressBar1.Visible = false;
                VarGeneral.DebLog.writeLog("ButOk_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void ButExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void FrmTransItmAcc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void FrmTransItmAcc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
    }
}
