using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmUserPointReturn : Form
    {
        public class ColumnDictinary
        {
            public string AText = string.Empty;
            public string EText = string.Empty;
            public bool IfDefault = false;
            public string Format = string.Empty;
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

        private LabelX label3;
        private ButtonX buttonX_Close;
        private RibbonBar ribbonBar1;
        private Panel panel1;
        private Label label1;
        private ButtonX buttonX_OK;
        private ComboBoxEx CmbUsers;
        private CheckBox ChkGaid;
        private ButtonX buttonX_Delete;
        private Label label13;
        private GroupPanel groupPanel4;
        private TextBoxX txtDebit3_R;
        private TextBoxX txtCredit3_R;
        internal Label label7;
        internal Label label8;
        private GroupPanel groupPanel5;
        private TextBoxX txtDebit1_R;
        private TextBoxX txtCredit1_R;
        internal Label label9;
        internal Label label10;
        private GroupPanel groupPanel6;
        private TextBoxX txtDebit2_R;
        private TextBoxX txtCredit2_R;
        internal Label label11;
        internal Label label12;
        private GroupPanel groupPanel3;
        private TextBoxX txtDebit3;
        private TextBoxX txtCredit3;
        internal Label label5;
        internal Label label6;
        private GroupPanel groupPanel1;
        private TextBoxX txtDebit1;
        private TextBoxX txtCredit1;
        internal Label labelD1;
        internal Label labelC1;
        private GroupPanel groupPanel2;
        private TextBoxX txtDebit2;
        private TextBoxX txtCredit2;
        internal Label label2;
        internal Label label4;
        private Label label14;
        private int LangArEn = 0;
        private Rate_DataDataContext dbInstance;
        private Stock_DataDataContext dbStock;
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
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
        private Stock_DataDataContext db
        {
            get
            {
                if (dbStock == null)
                {
                    dbStock = new Stock_DataDataContext(VarGeneral.BranchCS);
                }
                return dbStock;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserPointReturn));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();

            components = new System.ComponentModel.Container();

            this.label3 = new DevComponents.DotNetBar.LabelX();
            this.buttonX_Close = new DevComponents.DotNetBar.ButtonX();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.groupPanel4 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtDebit3_R = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtCredit3_R = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupPanel5 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtDebit1_R = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtCredit1_R = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupPanel6 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtDebit2_R = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtCredit2_R = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtDebit3 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtCredit3 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtDebit1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtCredit1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelD1 = new System.Windows.Forms.Label();
            this.labelC1 = new System.Windows.Forms.Label();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtDebit2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtCredit2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.buttonX_Delete = new DevComponents.DotNetBar.ButtonX();
            this.ChkGaid = new System.Windows.Forms.CheckBox();
            this.CmbUsers = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonX_OK = new DevComponents.DotNetBar.ButtonX();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();

            this.ribbonBar1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupPanel4.SuspendLayout();
            this.groupPanel5.SuspendLayout();
            this.groupPanel6.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();

            this.PanelSpecialContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSpecialContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelSpecialContainer.Name = "PanelSpecialContainer";
            this.PanelSpecialContainer.Size = new System.Drawing.Size(1278, 514);
            this.PanelSpecialContainer.TabIndex = 1220;
            this.Controls.Add(this.PanelSpecialContainer);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DimGray;
            // 
            // 
            // 
            this.label3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, ((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(602, 28);
            this.label3.TabIndex = 88;
            this.label3.Text = "تعيين مستخدمين نقاط البيع";
            this.label3.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // buttonX_Close
            // 
            this.buttonX_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Close.Checked = true;
            this.buttonX_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_Close.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonX_Close.Location = new System.Drawing.Point(6, 361);
            this.buttonX_Close.Name = "buttonX_Close";
            this.buttonX_Close.Size = new System.Drawing.Size(196, 42);
            this.buttonX_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Close.Symbol = "";
            this.buttonX_Close.TabIndex = 2;
            this.buttonX_Close.Text = "إغلاق";
            this.buttonX_Close.TextColor = System.Drawing.Color.SteelBlue;
            this.buttonX_Close.Click += new System.EventHandler(this.buttonX_Close_Click);
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
            this.ribbonBar1.Size = new System.Drawing.Size(609, 429);
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
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.groupPanel4);
            this.panel1.Controls.Add(this.groupPanel5);
            this.panel1.Controls.Add(this.groupPanel6);
            this.panel1.Controls.Add(this.groupPanel3);
            this.panel1.Controls.Add(this.groupPanel1);
            this.panel1.Controls.Add(this.groupPanel2);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.buttonX_Delete);
            this.panel1.Controls.Add(this.ChkGaid);
            this.panel1.Controls.Add(this.CmbUsers);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.buttonX_Close);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonX_OK);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 409);
            this.panel1.TabIndex = 857;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.SteelBlue;
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(304, 85);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(295, 21);
            this.label13.TabIndex = 105;
            this.label13.Text = "حسابات فاتورة المبيعات";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupPanel4
            // 
            this.groupPanel4.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel4.Controls.Add(this.txtDebit3_R);
            this.groupPanel4.Controls.Add(this.txtCredit3_R);
            this.groupPanel4.Controls.Add(this.label7);
            this.groupPanel4.Controls.Add(this.label8);
            this.groupPanel4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupPanel4.Location = new System.Drawing.Point(4, 278);
            this.groupPanel4.Name = "groupPanel4";
            this.groupPanel4.Size = new System.Drawing.Size(295, 78);
            // 
            // 
            // 
            this.groupPanel4.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel4.Style.BackColorGradientAngle = 90;
            this.groupPanel4.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderBottomWidth = 1;
            this.groupPanel4.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderLeftWidth = 1;
            this.groupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderRightWidth = 1;
            this.groupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderTopWidth = 1;
            this.groupPanel4.Style.CornerDiameter = 4;
            this.groupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel4.TabIndex = 104;
            this.groupPanel4.Text = "حسابات القيد الآجــل";
            // 
            // txtDebit3_R
            // 
            this.txtDebit3_R.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtDebit3_R.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDebit3_R.ButtonCustom.Visible = true;
            this.txtDebit3_R.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtDebit3_R.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDebit3_R.Location = new System.Drawing.Point(4, 10);
            this.txtDebit3_R.Name = "txtDebit3_R";
            this.txtDebit3_R.ReadOnly = true;
            this.txtDebit3_R.Size = new System.Drawing.Size(194, 14);
            this.txtDebit3_R.TabIndex = 1118;
            this.txtDebit3_R.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDebit3_R.ButtonCustomClick += new System.EventHandler(this.txtDebit3_R_ButtonCustomClick);
            // 
            // txtCredit3_R
            // 
            this.txtCredit3_R.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtCredit3_R.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCredit3_R.ButtonCustom.Visible = true;
            this.txtCredit3_R.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtCredit3_R.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCredit3_R.Location = new System.Drawing.Point(5, 31);
            this.txtCredit3_R.Name = "txtCredit3_R";
            this.txtCredit3_R.ReadOnly = true;
            this.txtCredit3_R.Size = new System.Drawing.Size(194, 14);
            this.txtCredit3_R.TabIndex = 1119;
            this.txtCredit3_R.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCredit3_R.ButtonCustomClick += new System.EventHandler(this.txtCredit3_R_ButtonCustomClick);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(193, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 1116;
            this.label7.Text = "الحساب المديـن :";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(193, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 1117;
            this.label8.Text = "الحساب الدائـــن :";
            // 
            // groupPanel5
            // 
            this.groupPanel5.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel5.Controls.Add(this.txtDebit1_R);
            this.groupPanel5.Controls.Add(this.txtCredit1_R);
            this.groupPanel5.Controls.Add(this.label9);
            this.groupPanel5.Controls.Add(this.label10);
            this.groupPanel5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupPanel5.Location = new System.Drawing.Point(6, 112);
            this.groupPanel5.Name = "groupPanel5";
            this.groupPanel5.Size = new System.Drawing.Size(295, 78);
            // 
            // 
            // 
            this.groupPanel5.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel5.Style.BackColorGradientAngle = 90;
            this.groupPanel5.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel5.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderBottomWidth = 1;
            this.groupPanel5.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel5.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderLeftWidth = 1;
            this.groupPanel5.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderRightWidth = 1;
            this.groupPanel5.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderTopWidth = 1;
            this.groupPanel5.Style.CornerDiameter = 4;
            this.groupPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel5.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel5.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel5.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel5.TabIndex = 102;
            this.groupPanel5.Text = "حسابات القيد النقــدي";
            // 
            // txtDebit1_R
            // 
            this.txtDebit1_R.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtDebit1_R.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDebit1_R.ButtonCustom.Visible = true;
            this.txtDebit1_R.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtDebit1_R.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDebit1_R.Location = new System.Drawing.Point(3, 10);
            this.txtDebit1_R.Name = "txtDebit1_R";
            this.txtDebit1_R.ReadOnly = true;
            this.txtDebit1_R.Size = new System.Drawing.Size(194, 14);
            this.txtDebit1_R.TabIndex = 1118;
            this.txtDebit1_R.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDebit1_R.ButtonCustomClick += new System.EventHandler(this.txtDebit1_R_ButtonCustomClick);
            // 
            // txtCredit1_R
            // 
            this.txtCredit1_R.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtCredit1_R.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCredit1_R.ButtonCustom.Visible = true;
            this.txtCredit1_R.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtCredit1_R.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCredit1_R.Location = new System.Drawing.Point(4, 31);
            this.txtCredit1_R.Name = "txtCredit1_R";
            this.txtCredit1_R.ReadOnly = true;
            this.txtCredit1_R.Size = new System.Drawing.Size(194, 14);
            this.txtCredit1_R.TabIndex = 1119;
            this.txtCredit1_R.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCredit1_R.ButtonCustomClick += new System.EventHandler(this.txtCredit1_R_ButtonCustomClick);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(193, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 13);
            this.label9.TabIndex = 1116;
            this.label9.Text = "الحساب المديـن :";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(193, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 1117;
            this.label10.Text = "الحسـاب الدائـن :";
            // 
            // groupPanel6
            // 
            this.groupPanel6.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel6.Controls.Add(this.txtDebit2_R);
            this.groupPanel6.Controls.Add(this.txtCredit2_R);
            this.groupPanel6.Controls.Add(this.label11);
            this.groupPanel6.Controls.Add(this.label12);
            this.groupPanel6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupPanel6.Location = new System.Drawing.Point(4, 195);
            this.groupPanel6.Name = "groupPanel6";
            this.groupPanel6.Size = new System.Drawing.Size(295, 78);
            // 
            // 
            // 
            this.groupPanel6.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel6.Style.BackColorGradientAngle = 90;
            this.groupPanel6.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel6.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderBottomWidth = 1;
            this.groupPanel6.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel6.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderLeftWidth = 1;
            this.groupPanel6.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderRightWidth = 1;
            this.groupPanel6.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderTopWidth = 1;
            this.groupPanel6.Style.CornerDiameter = 4;
            this.groupPanel6.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel6.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel6.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel6.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel6.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel6.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel6.TabIndex = 103;
            this.groupPanel6.Text = "حسابات قيد الشــبكة";
            // 
            // txtDebit2_R
            // 
            this.txtDebit2_R.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtDebit2_R.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDebit2_R.ButtonCustom.Visible = true;
            this.txtDebit2_R.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtDebit2_R.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDebit2_R.Location = new System.Drawing.Point(4, 10);
            this.txtDebit2_R.Name = "txtDebit2_R";
            this.txtDebit2_R.ReadOnly = true;
            this.txtDebit2_R.Size = new System.Drawing.Size(194, 14);
            this.txtDebit2_R.TabIndex = 1118;
            this.txtDebit2_R.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDebit2_R.ButtonCustomClick += new System.EventHandler(this.txtDebit2_R_ButtonCustomClick);
            // 
            // txtCredit2_R
            // 
            this.txtCredit2_R.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtCredit2_R.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCredit2_R.ButtonCustom.Visible = true;
            this.txtCredit2_R.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtCredit2_R.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCredit2_R.Location = new System.Drawing.Point(5, 31);
            this.txtCredit2_R.Name = "txtCredit2_R";
            this.txtCredit2_R.ReadOnly = true;
            this.txtCredit2_R.Size = new System.Drawing.Size(194, 14);
            this.txtCredit2_R.TabIndex = 1119;
            this.txtCredit2_R.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCredit2_R.ButtonCustomClick += new System.EventHandler(this.txtCredit2_R_ButtonCustomClick);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(193, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 13);
            this.label11.TabIndex = 1116;
            this.label11.Text = "الحساب المديـن :";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(193, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 13);
            this.label12.TabIndex = 1117;
            this.label12.Text = "الحساب الدائـــن :";
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.txtDebit3);
            this.groupPanel3.Controls.Add(this.txtCredit3);
            this.groupPanel3.Controls.Add(this.label5);
            this.groupPanel3.Controls.Add(this.label6);
            this.groupPanel3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupPanel3.Location = new System.Drawing.Point(302, 278);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(295, 78);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 101;
            this.groupPanel3.Text = "حسابات القيد الآجــل";
            // 
            // txtDebit3
            // 
            this.txtDebit3.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtDebit3.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDebit3.ButtonCustom.Visible = true;
            this.txtDebit3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtDebit3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDebit3.Location = new System.Drawing.Point(4, 10);
            this.txtDebit3.Name = "txtDebit3";
            this.txtDebit3.ReadOnly = true;
            this.txtDebit3.Size = new System.Drawing.Size(194, 14);
            this.txtDebit3.TabIndex = 1118;
            this.txtDebit3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDebit3.ButtonCustomClick += new System.EventHandler(this.txtDebit3_ButtonCustomClick);
            // 
            // txtCredit3
            // 
            this.txtCredit3.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtCredit3.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCredit3.ButtonCustom.Visible = true;
            this.txtCredit3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtCredit3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCredit3.Location = new System.Drawing.Point(5, 31);
            this.txtCredit3.Name = "txtCredit3";
            this.txtCredit3.ReadOnly = true;
            this.txtCredit3.Size = new System.Drawing.Size(194, 14);
            this.txtCredit3.TabIndex = 1119;
            this.txtCredit3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCredit3.ButtonCustomClick += new System.EventHandler(this.txtCredit3_ButtonCustomClick);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(196, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 1116;
            this.label5.Text = "الحساب المديـن :";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(196, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 1117;
            this.label6.Text = "الحساب الدائـــن :";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.txtDebit1);
            this.groupPanel1.Controls.Add(this.txtCredit1);
            this.groupPanel1.Controls.Add(this.labelD1);
            this.groupPanel1.Controls.Add(this.labelC1);
            this.groupPanel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupPanel1.Location = new System.Drawing.Point(304, 112);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(295, 78);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 99;
            this.groupPanel1.Text = "حسابات القيد النقــدي";
            // 
            // txtDebit1
            // 
            this.txtDebit1.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtDebit1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDebit1.ButtonCustom.Visible = true;
            this.txtDebit1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtDebit1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDebit1.Location = new System.Drawing.Point(4, 10);
            this.txtDebit1.Name = "txtDebit1";
            this.txtDebit1.ReadOnly = true;
            this.txtDebit1.Size = new System.Drawing.Size(194, 14);
            this.txtDebit1.TabIndex = 1118;
            this.txtDebit1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDebit1.ButtonCustomClick += new System.EventHandler(this.txtDebit1_ButtonCustomClick);
            // 
            // txtCredit1
            // 
            this.txtCredit1.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtCredit1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCredit1.ButtonCustom.Visible = true;
            this.txtCredit1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtCredit1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCredit1.Location = new System.Drawing.Point(5, 31);
            this.txtCredit1.Name = "txtCredit1";
            this.txtCredit1.ReadOnly = true;
            this.txtCredit1.Size = new System.Drawing.Size(194, 14);
            this.txtCredit1.TabIndex = 1119;
            this.txtCredit1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCredit1.ButtonCustomClick += new System.EventHandler(this.txtCredit1_ButtonCustomClick);
            // 
            // labelD1
            // 
            this.labelD1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.labelD1.AutoSize = true;
            this.labelD1.BackColor = System.Drawing.Color.Transparent;
            this.labelD1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelD1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.labelD1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelD1.Location = new System.Drawing.Point(196, 10);
            this.labelD1.Name = "labelD1";
            this.labelD1.Size = new System.Drawing.Size(87, 13);
            this.labelD1.TabIndex = 1116;
            this.labelD1.Text = "الحساب المديـن :";
            // 
            // labelC1
            // 
            this.labelC1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.labelC1.AutoSize = true;
            this.labelC1.BackColor = System.Drawing.Color.Transparent;
            this.labelC1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelC1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.labelC1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelC1.Location = new System.Drawing.Point(196, 31);
            this.labelC1.Name = "labelC1";
            this.labelC1.Size = new System.Drawing.Size(86, 13);
            this.labelC1.TabIndex = 1117;
            this.labelC1.Text = "الحسـاب الدائـن :";
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.txtDebit2);
            this.groupPanel2.Controls.Add(this.txtCredit2);
            this.groupPanel2.Controls.Add(this.label2);
            this.groupPanel2.Controls.Add(this.label4);
            this.groupPanel2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupPanel2.Location = new System.Drawing.Point(302, 195);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(295, 78);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 100;
            this.groupPanel2.Text = "حسابات قيد الشــبكة";
            // 
            // txtDebit2
            // 
            this.txtDebit2.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtDebit2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDebit2.ButtonCustom.Visible = true;
            this.txtDebit2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtDebit2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDebit2.Location = new System.Drawing.Point(4, 10);
            this.txtDebit2.Name = "txtDebit2";
            this.txtDebit2.ReadOnly = true;
            this.txtDebit2.Size = new System.Drawing.Size(194, 14);
            this.txtDebit2.TabIndex = 1118;
            this.txtDebit2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDebit2.ButtonCustomClick += new System.EventHandler(this.txtDebit2_ButtonCustomClick);
            // 
            // txtCredit2
            // 
            this.txtCredit2.BackColor = System.Drawing.SystemColors.Control;
            // 
            // 
            // 
            this.txtCredit2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCredit2.ButtonCustom.Visible = true;
            this.txtCredit2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtCredit2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCredit2.Location = new System.Drawing.Point(5, 31);
            this.txtCredit2.Name = "txtCredit2";
            this.txtCredit2.ReadOnly = true;
            this.txtCredit2.Size = new System.Drawing.Size(194, 14);
            this.txtCredit2.TabIndex = 1119;
            this.txtCredit2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCredit2.ButtonCustomClick += new System.EventHandler(this.txtCredit2_ButtonCustomClick);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(196, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 1116;
            this.label2.Text = "الحساب المديـن :";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(196, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 1117;
            this.label4.Text = "الحساب الدائـــن :";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.SteelBlue;
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(6, 85);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(295, 21);
            this.label14.TabIndex = 106;
            this.label14.Text = "حسابات فاتورة مرتجع المبيعات";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonX_Delete
            // 
            this.buttonX_Delete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Delete.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX_Delete.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonX_Delete.Location = new System.Drawing.Point(205, 361);
            this.buttonX_Delete.Name = "buttonX_Delete";
            this.buttonX_Delete.Size = new System.Drawing.Size(196, 42);
            this.buttonX_Delete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Delete.Symbol = "";
            this.buttonX_Delete.TabIndex = 93;
            this.buttonX_Delete.Text = "حــــذف";
            this.buttonX_Delete.TextColor = System.Drawing.Color.White;
            this.buttonX_Delete.Click += new System.EventHandler(this.buttonX_Delete_Click);
            // 
            // ChkGaid
            // 
            this.ChkGaid.AutoSize = true;
            this.ChkGaid.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ChkGaid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ChkGaid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ChkGaid.Location = new System.Drawing.Point(45, 52);
            this.ChkGaid.Name = "ChkGaid";
            this.ChkGaid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ChkGaid.Size = new System.Drawing.Size(113, 17);
            this.ChkGaid.TabIndex = 92;
            this.ChkGaid.Text = "انشاء قيد تلقائي";
            this.ChkGaid.UseVisualStyleBackColor = true;
            this.ChkGaid.CheckedChanged += new System.EventHandler(this.ChkGaid_CheckedChanged);
            // 
            // CmbUsers
            // 
            this.CmbUsers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbUsers.DisplayMember = "Text";
            this.CmbUsers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbUsers.FormattingEnabled = true;
            this.CmbUsers.ItemHeight = 14;
            this.CmbUsers.Location = new System.Drawing.Point(167, 51);
            this.CmbUsers.Name = "CmbUsers";
            this.CmbUsers.Size = new System.Drawing.Size(259, 20);
            this.CmbUsers.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbUsers.TabIndex = 89;
            this.CmbUsers.SelectedIndexChanged += new System.EventHandler(this.CmbUsers_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(432, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 86;
            this.label1.Text = "إسم المستخدم :";
            // 
            // buttonX_OK
            // 
            this.buttonX_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX_OK.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonX_OK.Location = new System.Drawing.Point(402, 361);
            this.buttonX_OK.Name = "buttonX_OK";
            this.buttonX_OK.Size = new System.Drawing.Size(196, 42);
            this.buttonX_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_OK.Symbol = "";
            this.buttonX_OK.TabIndex = 1;
            this.buttonX_OK.Text = "حفــظ";
            this.buttonX_OK.TextColor = System.Drawing.Color.White;
            this.buttonX_OK.Click += new System.EventHandler(this.buttonX_OK_Click);
            // 
            // FrmUserPointReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(609, 429);
            this.ControlBox = false;
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = (InvAcc.Properties.Resources.favicon);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmUserPointReturn";
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmUserPointReturn_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmUserPointReturn_KeyDown);
            this.ribbonBar1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupPanel4.ResumeLayout(false);
            this.groupPanel4.PerformLayout();
            this.groupPanel5.ResumeLayout(false);
            this.groupPanel5.PerformLayout();
            this.groupPanel6.ResumeLayout(false);
            this.groupPanel6.PerformLayout();
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.Icon = (InvAcc.Properties.Resources.favicon);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.ResumeLayout(false);
        }
        public FrmUserPointReturn()
        {
            InitializeComponent();
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                buttonX_Close.Text = "إغلاق";
                buttonX_OK.Text = "حفــظ";
                buttonX_Delete.Text = "حــــذف";
                label1.Text = "إسم المستخدم :";
                label3.Text = "إزالة مستخدمين نقاط البيع";
                groupPanel1.Text = "حسابات القيد النقــدي";
                groupPanel2.Text = "حسابات قيد الشــبكة";
                groupPanel3.Text = "حسابات القيد الآجــل";
            }
            else
            {
                buttonX_Close.Text = "Close";
                buttonX_OK.Text = "Save";
                buttonX_Delete.Text = "Delete";
                label1.Text = "User Name :";
                label3.Text = "Delete Users POS";
                groupPanel1.Text = "Cash Accounts";
                groupPanel2.Text = "Network Accounts";
                groupPanel3.Text = "Credit Accounts";
            }
        }
        private void FrmUserPointReturn_Load(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmUserPointReturn));
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
            FillCombo();
            if (VarGeneral.SSSTyp == 0)
            {
                txtDebit1.Enabled = false;
                txtDebit2.Enabled = false;
                txtDebit3.Enabled = false;
                txtCredit1.Enabled = false;
                txtCredit2.Enabled = false;
                txtCredit3.Enabled = false;
                txtDebit1_R.Enabled = false;
                txtDebit2_R.Enabled = false;
                txtDebit3_R.Enabled = false;
                txtCredit1_R.Enabled = false;
                txtCredit2_R.Enabled = false;
                txtCredit3_R.Enabled = false;
            }
        }
        private void FillCombo()
        {
            CmbUsers.DataSource = null;
            List<T_User> listUsers = new List<T_User>(dbc.T_Users.Where((T_User item) => item.Usr_ID != 1 && item.Usr_ID != 2 && item.UserPointTyp.Value == 1).ToList());
            listUsers.Insert(0, new T_User());
            CmbUsers.DataSource = listUsers;
            CmbUsers.DisplayMember = ((LangArEn == 0) ? "UsrNamA" : "UsrNamE");
            CmbUsers.ValueMember = "UsrNo";
            CmbUsers.SelectedIndex = 0;
        }
        private void FrmUserPointReturn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void buttonX_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbUsers.SelectedIndex <= 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "الرجاء تحديد اسم المستخدم" : "Please Select User Name", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (ChkGaid.Checked && (string.IsNullOrEmpty(txtCredit1.Text) || string.IsNullOrEmpty(txtCredit2.Text) || string.IsNullOrEmpty(txtCredit3.Text) || string.IsNullOrEmpty(txtDebit1.Text) || string.IsNullOrEmpty(txtDebit2.Text) || string.IsNullOrEmpty(txtDebit3.Text) || string.IsNullOrEmpty(txtCredit1_R.Text) || string.IsNullOrEmpty(txtCredit2_R.Text) || string.IsNullOrEmpty(txtCredit3_R.Text) || string.IsNullOrEmpty(txtDebit1_R.Text) || string.IsNullOrEmpty(txtDebit2_R.Text) || string.IsNullOrEmpty(txtDebit3_R.Text)))
                {
                    MessageBox.Show((LangArEn == 0) ? "الرجاء التأكد من تعبئة حسابات القيود النقدية الشبكة والآجلة" : "Please be sure to fill in the accounts cash and network.", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                T_User DataThis = dbc.StockUser(CmbUsers.SelectedValue.ToString());
                if (DataThis == null || DataThis.Usr_ID == 0)
                {
                    ChkGaid.Checked = false;
                    ChkGaid_CheckedChanged(sender, e);
                    return;
                }
                T_User newData = new T_User();
                newData = DataThis;
                newData.UserPointTyp = 1;
                if (ChkGaid.Checked)
                {
                    newData.CreateGaid = 1;
                    newData.CashAccNo_D = txtDebit1.Tag.ToString();
                    newData.CashAccNo_C = txtCredit1.Tag.ToString();
                    newData.NetworkAccNo_D = txtDebit2.Tag.ToString();
                    newData.NetworkAccNo_C = txtCredit2.Tag.ToString();
                    newData.CreaditAccNo_D = txtDebit3.Tag.ToString();
                    newData.CreaditAccNo_C = txtCredit3.Tag.ToString();
                    newData.CashAccNo_D_R = txtDebit1_R.Tag.ToString();
                    newData.CashAccNo_C_R = txtCredit1_R.Tag.ToString();
                    newData.NetworkAccNo_D_R = txtDebit2_R.Tag.ToString();
                    newData.NetworkAccNo_C_R = txtCredit2_R.Tag.ToString();
                    newData.CreaditAccNo_D_R = txtDebit3_R.Tag.ToString();
                    newData.CreaditAccNo_C_R = txtCredit3_R.Tag.ToString();
                }
                else
                {
                    newData.CreateGaid = 0;
                    newData.CashAccNo_D = string.Empty;
                    newData.CashAccNo_C = string.Empty;
                    newData.NetworkAccNo_D = string.Empty;
                    newData.NetworkAccNo_C = string.Empty;
                    newData.CreaditAccNo_D = string.Empty;
                    newData.CreaditAccNo_C = string.Empty;
                    newData.CashAccNo_D_R = string.Empty;
                    newData.CashAccNo_C_R = string.Empty;
                    newData.NetworkAccNo_D_R = string.Empty;
                    newData.NetworkAccNo_C_R = string.Empty;
                    newData.CreaditAccNo_D_R = string.Empty;
                    newData.CreaditAccNo_C_R = string.Empty;
                }
                try
                {
                    dbc.Log = VarGeneral.DebugLog;
                    dbc.SubmitChanges(ConflictMode.ContinueOnConflict);
                }
                catch (SqlException)
                {
                    return;
                }
                catch (Exception)
                {
                    return;
                }
                MessageBox.Show((LangArEn == 0) ? "لقد تم اتمام العملية بنجاح .." : "This Opration Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                dbInstance = null;
                FillCombo();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("buttonX_OK_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
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
        private void CmbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbUsers.SelectedIndex > 0)
            {
                T_User DataThis = dbc.StockUser(CmbUsers.SelectedValue.ToString());
                if (DataThis == null || DataThis.Usr_ID == 0)
                {
                    ChkGaid.Checked = false;
                    ChkGaid_CheckedChanged(sender, e);
                }
                else if (DataThis.CreateGaid.HasValue)
                {
                    if (DataThis.CreateGaid.Value == 1)
                    {
                        ChkGaid.Checked = true;
                        txtCredit1.Tag = DataThis.CashAccNo_C;
                        txtDebit1.Tag = DataThis.CashAccNo_D;
                        txtCredit2.Tag = DataThis.NetworkAccNo_C;
                        txtDebit2.Tag = DataThis.NetworkAccNo_D;
                        txtCredit3.Tag = DataThis.CreaditAccNo_C;
                        txtDebit3.Tag = DataThis.CreaditAccNo_D;
                        if (DataThis.CashAccNo_C == "***")
                        {
                            txtCredit1.Text = "***";
                        }
                        else
                        {
                            txtCredit1.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.CashAccNo_C).Arb_Des : db.StockAccDefWithOutBalance(DataThis.CashAccNo_C).Eng_Des);
                        }
                        if (DataThis.CashAccNo_D == "***")
                        {
                            txtDebit1.Text = "***";
                        }
                        else
                        {
                            txtDebit1.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.CashAccNo_D).Arb_Des : db.StockAccDefWithOutBalance(DataThis.CashAccNo_D).Eng_Des);
                        }
                        if (DataThis.NetworkAccNo_C == "***")
                        {
                            txtCredit2.Text = "***";
                        }
                        else
                        {
                            txtCredit2.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.NetworkAccNo_C).Arb_Des : db.StockAccDefWithOutBalance(DataThis.NetworkAccNo_C).Eng_Des);
                        }
                        if (DataThis.NetworkAccNo_D == "***")
                        {
                            txtDebit2.Text = "***";
                        }
                        else
                        {
                            txtDebit2.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.NetworkAccNo_D).Arb_Des : db.StockAccDefWithOutBalance(DataThis.NetworkAccNo_D).Eng_Des);
                        }
                        if (DataThis.CreaditAccNo_C == "***")
                        {
                            txtCredit3.Text = "***";
                        }
                        else
                        {
                            txtCredit3.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.CreaditAccNo_C).Arb_Des : db.StockAccDefWithOutBalance(DataThis.CreaditAccNo_C).Eng_Des);
                        }
                        if (DataThis.CreaditAccNo_D == "***")
                        {
                            txtDebit3.Text = "***";
                        }
                        else
                        {
                            txtDebit3.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.CreaditAccNo_D).Arb_Des : db.StockAccDefWithOutBalance(DataThis.CreaditAccNo_D).Eng_Des);
                        }
                        txtCredit1_R.Tag = DataThis.CashAccNo_C_R;
                        txtDebit1_R.Tag = DataThis.CashAccNo_D_R;
                        txtCredit2_R.Tag = DataThis.NetworkAccNo_C_R;
                        txtDebit2_R.Tag = DataThis.NetworkAccNo_D_R;
                        txtCredit3_R.Tag = DataThis.CreaditAccNo_C_R;
                        txtDebit3_R.Tag = DataThis.CreaditAccNo_D_R;
                        if (DataThis.CashAccNo_C_R == "***")
                        {
                            txtCredit1_R.Text = "***";
                        }
                        else
                        {
                            txtCredit1_R.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.CashAccNo_C_R).Arb_Des : db.StockAccDefWithOutBalance(DataThis.CashAccNo_C_R).Eng_Des);
                        }
                        if (DataThis.CashAccNo_D_R == "***")
                        {
                            txtDebit1_R.Text = "***";
                        }
                        else
                        {
                            txtDebit1_R.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.CashAccNo_D_R).Arb_Des : db.StockAccDefWithOutBalance(DataThis.CashAccNo_D_R).Eng_Des);
                        }
                        if (DataThis.NetworkAccNo_C_R == "***")
                        {
                            txtCredit2_R.Text = "***";
                        }
                        else
                        {
                            txtCredit2_R.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.NetworkAccNo_C_R).Arb_Des : db.StockAccDefWithOutBalance(DataThis.NetworkAccNo_C_R).Eng_Des);
                        }
                        if (DataThis.NetworkAccNo_D_R == "***")
                        {
                            txtDebit2_R.Text = "***";
                        }
                        else
                        {
                            txtDebit2_R.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.NetworkAccNo_D_R).Arb_Des : db.StockAccDefWithOutBalance(DataThis.NetworkAccNo_D_R).Eng_Des);
                        }
                        if (DataThis.CreaditAccNo_C_R == "***")
                        {
                            txtCredit3_R.Text = "***";
                        }
                        else
                        {
                            txtCredit3_R.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.CreaditAccNo_C_R).Arb_Des : db.StockAccDefWithOutBalance(DataThis.CreaditAccNo_C_R).Eng_Des);
                        }
                        if (DataThis.CreaditAccNo_D_R == "***")
                        {
                            txtDebit3_R.Text = "***";
                        }
                        else
                        {
                            txtDebit3_R.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.CreaditAccNo_D_R).Arb_Des : db.StockAccDefWithOutBalance(DataThis.CreaditAccNo_D_R).Eng_Des);
                        }
                    }
                    else
                    {
                        ChkGaid.Checked = false;
                        ChkGaid_CheckedChanged(sender, e);
                    }
                }
                else
                {
                    ChkGaid.Checked = false;
                    ChkGaid_CheckedChanged(sender, e);
                }
            }
            else
            {
                ChkGaid.Checked = false;
                ChkGaid_CheckedChanged(sender, e);
            }
        }
        private void txtDebit1_ButtonCustomClick(object sender, EventArgs e)
        {
            if (CmbUsers.SelectedIndex <= 0 || !ChkGaid.Checked)
            {
                return;
            }
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtDebit1.Tag = _AccDef.AccDef_No.ToString();
                    txtDebit1.Text = ((LangArEn == 0) ? _AccDef.Arb_Des : _AccDef.Eng_Des);
                }
                else
                {
                    txtDebit1.Text = "***";
                    txtDebit1.Tag = "***";
                }
            }
            catch
            {
                txtDebit1.Text = "***";
                txtDebit1.Tag = "***";
            }
        }
        private void txtCredit1_ButtonCustomClick(object sender, EventArgs e)
        {
            if (CmbUsers.SelectedIndex <= 0 || !ChkGaid.Checked)
            {
                return;
            }
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtCredit1.Tag = _AccDef.AccDef_No.ToString();
                    txtCredit1.Text = ((LangArEn == 0) ? _AccDef.Arb_Des : _AccDef.Eng_Des);
                }
                else
                {
                    txtCredit1.Text = "***";
                    txtCredit1.Tag = "***";
                }
            }
            catch
            {
                txtCredit1.Text = "***";
                txtCredit1.Tag = "***";
            }
        }
        private void txtDebit2_ButtonCustomClick(object sender, EventArgs e)
        {
            if (CmbUsers.SelectedIndex <= 0 || !ChkGaid.Checked || CmbUsers.SelectedIndex <= 0 || !ChkGaid.Checked)
            {
                return;
            }
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtDebit2.Tag = _AccDef.AccDef_No.ToString();
                    txtDebit2.Text = ((LangArEn == 0) ? _AccDef.Arb_Des : _AccDef.Eng_Des);
                }
                else
                {
                    txtDebit2.Text = "***";
                    txtDebit2.Tag = "***";
                }
            }
            catch
            {
                txtDebit2.Text = "***";
                txtDebit2.Tag = "***";
            }
        }
        private void txtCredit2_ButtonCustomClick(object sender, EventArgs e)
        {
            if (CmbUsers.SelectedIndex <= 0 || !ChkGaid.Checked)
            {
                return;
            }
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtCredit2.Tag = _AccDef.AccDef_No.ToString();
                    txtCredit2.Text = ((LangArEn == 0) ? _AccDef.Arb_Des : _AccDef.Eng_Des);
                }
                else
                {
                    txtCredit2.Text = "***";
                    txtCredit2.Tag = "***";
                }
            }
            catch
            {
                txtCredit2.Text = "***";
                txtCredit2.Tag = "***";
            }
        }
        private void ChkGaid_CheckedChanged(object sender, EventArgs e)
        {
            if (!ChkGaid.Checked)
            {
                txtDebit3.Text = string.Empty;
                txtDebit2.Text = string.Empty;
                txtDebit1.Text = string.Empty;
                txtCredit3.Text = string.Empty;
                txtCredit2.Text = string.Empty;
                txtCredit1.Text = string.Empty;
                txtDebit3.Tag = string.Empty;
                txtDebit2.Tag = string.Empty;
                txtDebit1.Tag = string.Empty;
                txtCredit3.Tag = string.Empty;
                txtCredit2.Tag = string.Empty;
                txtCredit1.Tag = string.Empty;
                txtDebit3_R.Text = string.Empty;
                txtDebit2_R.Text = string.Empty;
                txtDebit1_R.Text = string.Empty;
                txtCredit3_R.Text = string.Empty;
                txtCredit2_R.Text = string.Empty;
                txtCredit1_R.Text = string.Empty;
                txtDebit3_R.Tag = string.Empty;
                txtDebit2_R.Tag = string.Empty;
                txtDebit1_R.Tag = string.Empty;
                txtCredit3_R.Tag = string.Empty;
                txtCredit2_R.Tag = string.Empty;
                txtCredit1_R.Tag = string.Empty;
            }
            else if (CmbUsers.SelectedIndex > 0)
            {
                T_User DataThis = dbc.StockUser(CmbUsers.SelectedValue.ToString());
                if (DataThis == null || DataThis.Usr_ID == 0)
                {
                    txtDebit3.Text = string.Empty;
                    txtDebit2.Text = string.Empty;
                    txtDebit1.Text = string.Empty;
                    txtCredit3.Text = string.Empty;
                    txtCredit2.Text = string.Empty;
                    txtCredit1.Text = string.Empty;
                    txtDebit3.Tag = string.Empty;
                    txtDebit2.Tag = string.Empty;
                    txtDebit1.Tag = string.Empty;
                    txtCredit3.Tag = string.Empty;
                    txtCredit2.Tag = string.Empty;
                    txtCredit1.Tag = string.Empty;
                    txtDebit3_R.Text = string.Empty;
                    txtDebit2_R.Text = string.Empty;
                    txtDebit1_R.Text = string.Empty;
                    txtCredit3_R.Text = string.Empty;
                    txtCredit2_R.Text = string.Empty;
                    txtCredit1_R.Text = string.Empty;
                    txtDebit3_R.Tag = string.Empty;
                    txtDebit2_R.Tag = string.Empty;
                    txtDebit1_R.Tag = string.Empty;
                    txtCredit3_R.Tag = string.Empty;
                    txtCredit2_R.Tag = string.Empty;
                    txtCredit1_R.Tag = string.Empty;
                }
                else if (DataThis.CreateGaid.HasValue)
                {
                    if (DataThis.CreateGaid.Value == 1)
                    {
                        ChkGaid.Checked = true;
                        txtCredit1.Tag = DataThis.CashAccNo_C;
                        txtDebit1.Tag = DataThis.CashAccNo_D;
                        txtCredit2.Tag = DataThis.NetworkAccNo_C;
                        txtDebit2.Tag = DataThis.NetworkAccNo_D;
                        if (DataThis.CashAccNo_C == "***")
                        {
                            txtCredit1.Text = "***";
                        }
                        else
                        {
                            txtCredit1.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.CashAccNo_C).Arb_Des : db.StockAccDefWithOutBalance(DataThis.CashAccNo_C).Eng_Des);
                        }
                        if (DataThis.CashAccNo_D == "***")
                        {
                            txtDebit1.Text = "***";
                        }
                        else
                        {
                            txtDebit1.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.CashAccNo_D).Arb_Des : db.StockAccDefWithOutBalance(DataThis.CashAccNo_D).Eng_Des);
                        }
                        if (DataThis.NetworkAccNo_C == "***")
                        {
                            txtCredit2.Text = "***";
                        }
                        else
                        {
                            txtCredit2.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.NetworkAccNo_C).Arb_Des : db.StockAccDefWithOutBalance(DataThis.NetworkAccNo_C).Eng_Des);
                        }
                        if (DataThis.NetworkAccNo_D == "***")
                        {
                            txtDebit2.Text = "***";
                        }
                        else
                        {
                            txtDebit2.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.NetworkAccNo_D).Arb_Des : db.StockAccDefWithOutBalance(DataThis.NetworkAccNo_D).Eng_Des);
                        }
                        if (DataThis.CreaditAccNo_C == "***")
                        {
                            txtCredit3.Text = "***";
                        }
                        else
                        {
                            txtCredit3.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.CreaditAccNo_C).Arb_Des : db.StockAccDefWithOutBalance(DataThis.CreaditAccNo_C).Eng_Des);
                        }
                        if (DataThis.CreaditAccNo_D == "***")
                        {
                            txtDebit3.Text = "***";
                        }
                        else
                        {
                            txtDebit3.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.CreaditAccNo_D).Arb_Des : db.StockAccDefWithOutBalance(DataThis.CreaditAccNo_D).Eng_Des);
                        }
                        txtCredit1_R.Tag = DataThis.CashAccNo_C_R;
                        txtDebit1_R.Tag = DataThis.CashAccNo_D_R;
                        txtCredit2_R.Tag = DataThis.NetworkAccNo_C_R;
                        txtDebit2_R.Tag = DataThis.NetworkAccNo_D_R;
                        if (DataThis.CashAccNo_C_R == "***")
                        {
                            txtCredit1_R.Text = "***";
                        }
                        else
                        {
                            txtCredit1_R.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.CashAccNo_C_R).Arb_Des : db.StockAccDefWithOutBalance(DataThis.CashAccNo_C_R).Eng_Des);
                        }
                        if (DataThis.CashAccNo_D_R == "***")
                        {
                            txtDebit1_R.Text = "***";
                        }
                        else
                        {
                            txtDebit1_R.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.CashAccNo_D_R).Arb_Des : db.StockAccDefWithOutBalance(DataThis.CashAccNo_D_R).Eng_Des);
                        }
                        if (DataThis.NetworkAccNo_C_R == "***")
                        {
                            txtCredit2_R.Text = "***";
                        }
                        else
                        {
                            txtCredit2_R.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.NetworkAccNo_C_R).Arb_Des : db.StockAccDefWithOutBalance(DataThis.NetworkAccNo_C_R).Eng_Des);
                        }
                        if (DataThis.NetworkAccNo_D_R == "***")
                        {
                            txtDebit2_R.Text = "***";
                        }
                        else
                        {
                            txtDebit2_R.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.NetworkAccNo_D_R).Arb_Des : db.StockAccDefWithOutBalance(DataThis.NetworkAccNo_D_R).Eng_Des);
                        }
                        if (DataThis.CreaditAccNo_C_R == "***")
                        {
                            txtCredit3_R.Text = "***";
                        }
                        else
                        {
                            txtCredit3_R.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.CreaditAccNo_C_R).Arb_Des : db.StockAccDefWithOutBalance(DataThis.CreaditAccNo_C_R).Eng_Des);
                        }
                        if (DataThis.CreaditAccNo_D_R == "***")
                        {
                            txtDebit3_R.Text = "***";
                        }
                        else
                        {
                            txtDebit3_R.Text = ((LangArEn == 0) ? db.StockAccDefWithOutBalance(DataThis.CreaditAccNo_D_R).Arb_Des : db.StockAccDefWithOutBalance(DataThis.CreaditAccNo_D_R).Eng_Des);
                        }
                    }
                    else
                    {
                        txtDebit3.Text = string.Empty;
                        txtDebit2.Text = string.Empty;
                        txtDebit1.Text = string.Empty;
                        txtCredit3.Text = string.Empty;
                        txtCredit2.Text = string.Empty;
                        txtCredit1.Text = string.Empty;
                        txtDebit3.Tag = string.Empty;
                        txtDebit2.Tag = string.Empty;
                        txtDebit1.Tag = string.Empty;
                        txtCredit3.Tag = string.Empty;
                        txtCredit2.Tag = string.Empty;
                        txtCredit1.Tag = string.Empty;
                        txtDebit3_R.Text = string.Empty;
                        txtDebit2_R.Text = string.Empty;
                        txtDebit1_R.Text = string.Empty;
                        txtCredit3_R.Text = string.Empty;
                        txtCredit2_R.Text = string.Empty;
                        txtCredit1_R.Text = string.Empty;
                        txtDebit3_R.Tag = string.Empty;
                        txtDebit2_R.Tag = string.Empty;
                        txtDebit1_R.Tag = string.Empty;
                        txtCredit3_R.Tag = string.Empty;
                        txtCredit2_R.Tag = string.Empty;
                        txtCredit1_R.Tag = string.Empty;
                    }
                }
                else
                {
                    txtDebit3.Text = string.Empty;
                    txtDebit2.Text = string.Empty;
                    txtDebit1.Text = string.Empty;
                    txtCredit3.Text = string.Empty;
                    txtCredit2.Text = string.Empty;
                    txtCredit1.Text = string.Empty;
                    txtDebit3.Tag = string.Empty;
                    txtDebit2.Tag = string.Empty;
                    txtDebit1.Tag = string.Empty;
                    txtCredit3.Tag = string.Empty;
                    txtCredit2.Tag = string.Empty;
                    txtCredit1.Tag = string.Empty;
                    txtDebit3_R.Text = string.Empty;
                    txtDebit2_R.Text = string.Empty;
                    txtDebit1_R.Text = string.Empty;
                    txtCredit3_R.Text = string.Empty;
                    txtCredit2_R.Text = string.Empty;
                    txtCredit1_R.Text = string.Empty;
                    txtDebit3_R.Tag = string.Empty;
                    txtDebit2_R.Tag = string.Empty;
                    txtDebit1_R.Tag = string.Empty;
                    txtCredit3_R.Tag = string.Empty;
                    txtCredit2_R.Tag = string.Empty;
                    txtCredit1_R.Tag = string.Empty;
                }
            }
            else
            {
                txtDebit3.Text = string.Empty;
                txtDebit2.Text = string.Empty;
                txtDebit1.Text = string.Empty;
                txtCredit3.Text = string.Empty;
                txtCredit2.Text = string.Empty;
                txtCredit1.Text = string.Empty;
                txtDebit3.Tag = string.Empty;
                txtDebit2.Tag = string.Empty;
                txtDebit1.Tag = string.Empty;
                txtCredit3.Tag = string.Empty;
                txtCredit2.Tag = string.Empty;
                txtCredit1.Tag = string.Empty;
                txtDebit3_R.Text = string.Empty;
                txtDebit2_R.Text = string.Empty;
                txtDebit1_R.Text = string.Empty;
                txtCredit3_R.Text = string.Empty;
                txtCredit2_R.Text = string.Empty;
                txtCredit1_R.Text = string.Empty;
                txtDebit3_R.Tag = string.Empty;
                txtDebit2_R.Tag = string.Empty;
                txtDebit1_R.Tag = string.Empty;
                txtCredit3_R.Tag = string.Empty;
                txtCredit2_R.Tag = string.Empty;
                txtCredit1_R.Tag = string.Empty;
            }
        }
        private void buttonX_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbUsers.SelectedIndex <= 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "الرجاء تحديد اسم المستخدم" : "Please Select User Name", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    if (MessageBox.Show("هل أنت متاكد من ازالة نقطة البيع للمستخدم  [" + CmbUsers.Text + "]؟ \n Are you sure that you want to delete the POS  [" + CmbUsers.Text + "]?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        return;
                    }
                    T_User DataThis = dbc.StockUser(CmbUsers.SelectedValue.ToString());
                    if (DataThis == null || DataThis.Usr_ID == 0)
                    {
                        ChkGaid.Checked = false;
                        ChkGaid_CheckedChanged(sender, e);
                        return;
                    }
                    T_User newData = new T_User();
                    newData = DataThis;
                    newData.UserPointTyp = 0;
                    newData.CreateGaid = 0;
                    newData.CashAccNo_D = string.Empty;
                    newData.CashAccNo_C = string.Empty;
                    newData.NetworkAccNo_D = string.Empty;
                    newData.NetworkAccNo_C = string.Empty;
                    newData.CreaditAccNo_D = string.Empty;
                    newData.CreaditAccNo_C = string.Empty;
                    newData.CashAccNo_D_R = string.Empty;
                    newData.CashAccNo_C_R = string.Empty;
                    newData.NetworkAccNo_D_R = string.Empty;
                    newData.NetworkAccNo_C_R = string.Empty;
                    newData.CreaditAccNo_D_R = string.Empty;
                    newData.CreaditAccNo_C_R = string.Empty;
                    try
                    {
                        dbc.Log = VarGeneral.DebugLog;
                        dbc.SubmitChanges(ConflictMode.ContinueOnConflict);
                    }
                    catch (SqlException)
                    {
                        return;
                    }
                    catch (Exception)
                    {
                        return;
                    }
                    MessageBox.Show((LangArEn == 0) ? "تمت العملية بنجاح .." : "Delete OPS Is Done", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    dbInstance = null;
                    FillCombo();
                    return;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("buttonX_Delete_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void txtDebit3_ButtonCustomClick(object sender, EventArgs e)
        {
            if (CmbUsers.SelectedIndex <= 0 || !ChkGaid.Checked || CmbUsers.SelectedIndex <= 0 || !ChkGaid.Checked)
            {
                return;
            }
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtDebit3.Tag = _AccDef.AccDef_No.ToString();
                    txtDebit3.Text = ((LangArEn == 0) ? _AccDef.Arb_Des : _AccDef.Eng_Des);
                }
                else
                {
                    txtDebit3.Text = "***";
                    txtDebit3.Tag = "***";
                }
            }
            catch
            {
                txtDebit3.Text = "***";
                txtDebit3.Tag = "***";
            }
        }
        private void txtCredit3_ButtonCustomClick(object sender, EventArgs e)
        {
            if (CmbUsers.SelectedIndex <= 0 || !ChkGaid.Checked)
            {
                return;
            }
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtCredit3.Tag = _AccDef.AccDef_No.ToString();
                    txtCredit3.Text = ((LangArEn == 0) ? _AccDef.Arb_Des : _AccDef.Eng_Des);
                }
                else
                {
                    txtCredit3.Text = "***";
                    txtCredit3.Tag = "***";
                }
            }
            catch
            {
                txtCredit3.Text = "***";
                txtCredit3.Tag = "***";
            }
        }
        private void txtDebit1_R_ButtonCustomClick(object sender, EventArgs e)
        {
            if (CmbUsers.SelectedIndex <= 0 || !ChkGaid.Checked)
            {
                return;
            }
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtDebit1_R.Tag = _AccDef.AccDef_No.ToString();
                    txtDebit1_R.Text = ((LangArEn == 0) ? _AccDef.Arb_Des : _AccDef.Eng_Des);
                }
                else
                {
                    txtDebit1_R.Text = "***";
                    txtDebit1_R.Tag = "***";
                }
            }
            catch
            {
                txtDebit1_R.Text = "***";
                txtDebit1_R.Tag = "***";
            }
        }
        private void txtDebit2_R_ButtonCustomClick(object sender, EventArgs e)
        {
            if (CmbUsers.SelectedIndex <= 0 || !ChkGaid.Checked)
            {
                return;
            }
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtDebit2_R.Tag = _AccDef.AccDef_No.ToString();
                    txtDebit2_R.Text = ((LangArEn == 0) ? _AccDef.Arb_Des : _AccDef.Eng_Des);
                }
                else
                {
                    txtDebit2_R.Text = "***";
                    txtDebit2_R.Tag = "***";
                }
            }
            catch
            {
                txtDebit2_R.Text = "***";
                txtDebit2_R.Tag = "***";
            }
        }
        private void txtDebit3_R_ButtonCustomClick(object sender, EventArgs e)
        {
            if (CmbUsers.SelectedIndex <= 0 || !ChkGaid.Checked)
            {
                return;
            }
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtDebit3_R.Tag = _AccDef.AccDef_No.ToString();
                    txtDebit3_R.Text = ((LangArEn == 0) ? _AccDef.Arb_Des : _AccDef.Eng_Des);
                }
                else
                {
                    txtDebit3_R.Text = "***";
                    txtDebit3_R.Tag = "***";
                }
            }
            catch
            {
                txtDebit3_R.Text = "***";
                txtDebit3_R.Tag = "***";
            }
        }
        private void txtCredit1_R_ButtonCustomClick(object sender, EventArgs e)
        {
            if (CmbUsers.SelectedIndex <= 0 || !ChkGaid.Checked)
            {
                return;
            }
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtCredit1_R.Tag = _AccDef.AccDef_No.ToString();
                    txtCredit1_R.Text = ((LangArEn == 0) ? _AccDef.Arb_Des : _AccDef.Eng_Des);
                }
                else
                {
                    txtCredit1_R.Text = "***";
                    txtCredit1_R.Tag = "***";
                }
            }
            catch
            {
                txtCredit1_R.Text = "***";
                txtCredit1_R.Tag = "***";
            }
        }
        private void txtCredit2_R_ButtonCustomClick(object sender, EventArgs e)
        {
            if (CmbUsers.SelectedIndex <= 0 || !ChkGaid.Checked)
            {
                return;
            }
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtCredit2_R.Tag = _AccDef.AccDef_No.ToString();
                    txtCredit2_R.Text = ((LangArEn == 0) ? _AccDef.Arb_Des : _AccDef.Eng_Des);
                }
                else
                {
                    txtCredit2_R.Text = "***";
                    txtCredit2_R.Tag = "***";
                }
            }
            catch
            {
                txtCredit2_R.Text = "***";
                txtCredit2_R.Tag = "***";
            }
        }
        private void txtCredit3_R_ButtonCustomClick(object sender, EventArgs e)
        {
            if (CmbUsers.SelectedIndex <= 0 || !ChkGaid.Checked)
            {
                return;
            }
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            try
            {
                if (frm.SerachNo != string.Empty)
                {
                    T_AccDef _AccDef = db.StockAccDefs(int.Parse(frm.Serach_No));
                    txtCredit3_R.Tag = _AccDef.AccDef_No.ToString();
                    txtCredit3_R.Text = ((LangArEn == 0) ? _AccDef.Arb_Des : _AccDef.Eng_Des);
                }
                else
                {
                    txtCredit3_R.Text = "***";
                    txtCredit3_R.Tag = "***";
                }
            }
            catch
            {
                txtCredit3_R.Text = "***";
                txtCredit3_R.Tag = "***";
            }
        }
    }
}
