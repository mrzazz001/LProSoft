using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using Framework.Date;
using Framework.UI;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Library.RepShow;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FRAccountTrans : Form
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
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!keyData.ToString().Contains("Control") && !keyData.ToString().ToLower().Contains("delete") && keyData.ToString().Contains("Alt"))
            {
                try
                {
                    VarGeneral.Print_set_Gen_Stat = true;
                    FrmReportsViewer.IsSettingOnly = true;
                    VarGeneral.IsGeneralUsed = true;

                    {

                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "AccountTrans";


                        frm.Repvalue = "AccountTrans";
                        //ADDADD





                        frm.Tag = LangArEn;
                        frm.ShowDialog();
                        VarGeneral.IsGeneralUsed = false;
                    }
                    FrmReportsViewer.IsSettingOnly = false;
                }
                catch
                {
                    VarGeneral.Print_set_Gen_Stat = false;
                }


            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


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
        private void FRInvoice_VisibleChanged(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;
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
        private C1FlexGrid FlexField;
        private NumericUpDown numUpDownLevel;
        private GroupBox groupBox2;
        private TextBox txtIntoAccName;
        private TextBox txtLegateName;
        private TextBox txtFromAccName;
        private TextBox txtUserName;
        private TextBox txtCostCName;
        private TextBox txtFromAccNo;
        private TextBox txtIntoAccNo;
        private TextBox txtLegateNo;
        private TextBox txtUserNo;
        private TextBox txtCostCNo;
        private ButtonX button_SrchUsrNo;
        private ButtonX button_SrchCostNo;
        private ButtonX button_SrchLegNo;
        private ButtonX button_SrchAccTo;
        private ButtonX button_SrchAccFrom;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label8;
        private GroupBox groupBox4;
        private MaskedTextBox txtMToDate;
        private MaskedTextBox txtMFromDate;
        private Label label2;
        private GroupBox groupBox3;
        private Label label1;
        private Label label9;
        private Label label10;
        private PictureBox pictureBox1;
        private DoubleInput txtMBalanceB;
        private DoubleInput txtMBalanceS;
        private Label label3;
        private Label label4;
        private SwitchButton switchButton_OpenValue;
        private int LangArEn = 0;
        private T_User _User = new T_User();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private Stock_DataDataContext dbInstance;
        private C1.Win.C1Input.C1Button ButOk;
        private C1.Win.C1Input.C1Button ButExit;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRAccountTrans));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            components = new System.ComponentModel.Container();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.ButOk = new C1.Win.C1Input.C1Button();
            this.ButExit = new C1.Win.C1Input.C1Button();
            this.switchButton_OpenValue = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMToDate = new System.Windows.Forms.MaskedTextBox();
            this.txtMFromDate = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtMBalanceB = new DevComponents.Editors.DoubleInput();
            this.txtMBalanceS = new DevComponents.Editors.DoubleInput();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numUpDownLevel = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIntoAccName = new System.Windows.Forms.TextBox();
            this.txtLegateName = new System.Windows.Forms.TextBox();
            this.txtFromAccName = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtFromAccNo = new System.Windows.Forms.TextBox();
            this.txtIntoAccNo = new System.Windows.Forms.TextBox();
            this.txtLegateNo = new System.Windows.Forms.TextBox();
            this.txtUserNo = new System.Windows.Forms.TextBox();
            this.button_SrchUsrNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchLegNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchAccTo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchAccFrom = new DevComponents.DotNetBar.ButtonX();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCostCName = new System.Windows.Forms.TextBox();
            this.txtCostCNo = new System.Windows.Forms.TextBox();
            this.button_SrchCostNo = new DevComponents.DotNetBar.ButtonX();
            this.label8 = new System.Windows.Forms.Label();
            this.FlexField = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.VisibleChanged += new System.EventHandler(this.FRInvoice_VisibleChanged);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.ribbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButExit)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMBalanceB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMBalanceS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownLevel)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlexField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.ribbonBar1.Controls.Add(this.ButOk);
            this.ribbonBar1.Controls.Add(this.ButExit);
            this.ribbonBar1.Controls.Add(this.switchButton_OpenValue);
            this.ribbonBar1.Controls.Add(this.label10);
            this.ribbonBar1.Controls.Add(this.groupBox4);
            this.ribbonBar1.Controls.Add(this.groupBox3);
            this.ribbonBar1.Controls.Add(this.numUpDownLevel);
            this.ribbonBar1.Controls.Add(this.groupBox2);
            this.ribbonBar1.Controls.Add(this.FlexField);
            this.ribbonBar1.Controls.Add(this.pictureBox1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(408, 362);
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
            // ButOk
            // 
            this.ButOk.BackgroundImage = global::InvAcc.Properties.Resources.print;
            this.ButOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButOk.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButOk.Location = new System.Drawing.Point(190, 303);
            this.ButOk.Name = "ButOk";
            this.ButOk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButOk.Size = new System.Drawing.Size(204, 35);
            this.ButOk.TabIndex = 6748;
            this.ButOk.Text = "?????????? | Print";
            this.ButOk.UseVisualStyleBackColor = true;
            this.ButOk.Click += new System.EventHandler(this.ButOk_Click);
            // 
            // ButExit
            // 
            this.ButExit.BackgroundImage = global::InvAcc.Properties.Resources.YALO2;
            this.ButExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButExit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButExit.Location = new System.Drawing.Point(5, 303);
            this.ButExit.Name = "ButExit";
            this.ButExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButExit.Size = new System.Drawing.Size(156, 35);
            this.ButExit.TabIndex = 6747;
            this.ButExit.Text = "???????? | ESC";
            this.ButExit.UseVisualStyleBackColor = true;
            this.ButExit.Click += new System.EventHandler(this.ButExit_Click);
            // 
            // switchButton_OpenValue
            // 
            // 
            // 
            // 
            this.switchButton_OpenValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_OpenValue.Font = new System.Drawing.Font("Tahoma", 7F);
            this.switchButton_OpenValue.Location = new System.Drawing.Point(17, 278);
            this.switchButton_OpenValue.Name = "switchButton_OpenValue";
            this.switchButton_OpenValue.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.switchButton_OpenValue.OffText = "?????????? ???????????? ??????????????????";
            this.switchButton_OpenValue.OffTextColor = System.Drawing.Color.White;
            this.switchButton_OpenValue.OnText = "?????????? ???????????? ??????????????????";
            this.switchButton_OpenValue.Size = new System.Drawing.Size(188, 21);
            this.switchButton_OpenValue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_OpenValue.TabIndex = 1166;
            this.switchButton_OpenValue.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(321, 282);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 1163;
            this.label10.Text = "?????????????? :";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.txtMToDate);
            this.groupBox4.Controls.Add(this.txtMFromDate);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.groupBox4.Location = new System.Drawing.Point(9, 11);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(391, 52);
            this.groupBox4.TabIndex = 1148;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "?????? ??????????????";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(320, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 866;
            this.label1.Text = "?????????????? :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMToDate
            // 
            this.txtMToDate.Location = new System.Drawing.Point(23, 21);
            this.txtMToDate.Mask = "0000/00/00";
            this.txtMToDate.Name = "txtMToDate";
            this.txtMToDate.Size = new System.Drawing.Size(108, 21);
            this.txtMToDate.TabIndex = 2;
            this.txtMToDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMToDate.Click += new System.EventHandler(this.txtMToDate_Click);
            this.txtMToDate.Leave += new System.EventHandler(this.txtMToDate_Leave);
            // 
            // txtMFromDate
            // 
            this.txtMFromDate.Location = new System.Drawing.Point(208, 21);
            this.txtMFromDate.Mask = "0000/00/00";
            this.txtMFromDate.Name = "txtMFromDate";
            this.txtMFromDate.Size = new System.Drawing.Size(108, 21);
            this.txtMFromDate.TabIndex = 1;
            this.txtMFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMFromDate.Click += new System.EventHandler(this.txtMFromDate_Click);
            this.txtMFromDate.Leave += new System.EventHandler(this.txtMFromDate_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(137, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 861;
            this.label2.Text = "???????????????? :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.txtMBalanceB);
            this.groupBox3.Controls.Add(this.txtMBalanceS);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.groupBox3.Location = new System.Drawing.Point(9, 65);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(391, 52);
            this.groupBox3.TabIndex = 1149;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "????????????????????";
            // 
            // txtMBalanceB
            // 
            this.txtMBalanceB.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtMBalanceB.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtMBalanceB.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtMBalanceB.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMBalanceB.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtMBalanceB.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtMBalanceB.Increment = 1D;
            this.txtMBalanceB.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtMBalanceB.Location = new System.Drawing.Point(210, 21);
            this.txtMBalanceB.LockUpdateChecked = false;
            this.txtMBalanceB.Name = "txtMBalanceB";
            this.txtMBalanceB.ShowCheckBox = true;
            this.txtMBalanceB.ShowUpDown = true;
            this.txtMBalanceB.Size = new System.Drawing.Size(108, 20);
            this.txtMBalanceB.TabIndex = 1159;
            this.txtMBalanceB.Tag = "T_GDDET.gdValue";
            // 
            // txtMBalanceS
            // 
            this.txtMBalanceS.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtMBalanceS.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtMBalanceS.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtMBalanceS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMBalanceS.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtMBalanceS.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txtMBalanceS.Increment = 1D;
            this.txtMBalanceS.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtMBalanceS.Location = new System.Drawing.Point(25, 21);
            this.txtMBalanceS.LockUpdateChecked = false;
            this.txtMBalanceS.Name = "txtMBalanceS";
            this.txtMBalanceS.ShowCheckBox = true;
            this.txtMBalanceS.ShowUpDown = true;
            this.txtMBalanceS.Size = new System.Drawing.Size(108, 20);
            this.txtMBalanceS.TabIndex = 1158;
            this.txtMBalanceS.Tag = "T_GDDET.gdValue";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(322, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 1157;
            this.label3.Text = "?????????????? :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(139, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 1156;
            this.label4.Text = "???????? ???? = :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numUpDownLevel
            // 
            this.numUpDownLevel.Font = new System.Drawing.Font("Tahoma", 8F);
            this.numUpDownLevel.Location = new System.Drawing.Point(212, 278);
            this.numUpDownLevel.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numUpDownLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDownLevel.Name = "numUpDownLevel";
            this.numUpDownLevel.Size = new System.Drawing.Size(108, 20);
            this.numUpDownLevel.TabIndex = 20;
            this.numUpDownLevel.Tag = " T_AccDef.Lev";
            this.numUpDownLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numUpDownLevel.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtIntoAccName);
            this.groupBox2.Controls.Add(this.txtLegateName);
            this.groupBox2.Controls.Add(this.txtFromAccName);
            this.groupBox2.Controls.Add(this.txtUserName);
            this.groupBox2.Controls.Add(this.txtFromAccNo);
            this.groupBox2.Controls.Add(this.txtIntoAccNo);
            this.groupBox2.Controls.Add(this.txtLegateNo);
            this.groupBox2.Controls.Add(this.txtUserNo);
            this.groupBox2.Controls.Add(this.button_SrchUsrNo);
            this.groupBox2.Controls.Add(this.button_SrchLegNo);
            this.groupBox2.Controls.Add(this.button_SrchAccTo);
            this.groupBox2.Controls.Add(this.button_SrchAccFrom);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtCostCName);
            this.groupBox2.Controls.Add(this.txtCostCNo);
            this.groupBox2.Controls.Add(this.button_SrchCostNo);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(9, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(393, 149);
            this.groupBox2.TabIndex = 1146;
            this.groupBox2.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(312, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 1159;
            this.label9.Text = "???????????????? :";
            // 
            // txtIntoAccName
            // 
            this.txtIntoAccName.BackColor = System.Drawing.Color.Ivory;
            this.txtIntoAccName.ForeColor = System.Drawing.Color.White;
            this.txtIntoAccName.Location = new System.Drawing.Point(8, 42);
            this.txtIntoAccName.Name = "txtIntoAccName";
            this.netResize1.SetResizeTextBoxMultiline(this.txtIntoAccName, false);
            this.txtIntoAccName.ReadOnly = true;
            this.txtIntoAccName.Size = new System.Drawing.Size(188, 20);
            this.txtIntoAccName.TabIndex = 10;
            this.txtIntoAccName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLegateName
            // 
            this.txtLegateName.BackColor = System.Drawing.Color.Ivory;
            this.txtLegateName.ForeColor = System.Drawing.Color.White;
            this.txtLegateName.Location = new System.Drawing.Point(8, 67);
            this.txtLegateName.Name = "txtLegateName";
            this.netResize1.SetResizeTextBoxMultiline(this.txtLegateName, false);
            this.txtLegateName.ReadOnly = true;
            this.txtLegateName.Size = new System.Drawing.Size(188, 20);
            this.txtLegateName.TabIndex = 13;
            this.txtLegateName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFromAccName
            // 
            this.txtFromAccName.BackColor = System.Drawing.Color.Ivory;
            this.txtFromAccName.ForeColor = System.Drawing.Color.White;
            this.txtFromAccName.Location = new System.Drawing.Point(8, 17);
            this.txtFromAccName.Name = "txtFromAccName";
            this.netResize1.SetResizeTextBoxMultiline(this.txtFromAccName, false);
            this.txtFromAccName.ReadOnly = true;
            this.txtFromAccName.Size = new System.Drawing.Size(188, 20);
            this.txtFromAccName.TabIndex = 7;
            this.txtFromAccName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.Ivory;
            this.txtUserName.ForeColor = System.Drawing.Color.White;
            this.txtUserName.Location = new System.Drawing.Point(8, 92);
            this.txtUserName.Name = "txtUserName";
            this.netResize1.SetResizeTextBoxMultiline(this.txtUserName, false);
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(188, 20);
            this.txtUserName.TabIndex = 16;
            this.txtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFromAccNo
            // 
            this.txtFromAccNo.BackColor = System.Drawing.Color.White;
            this.txtFromAccNo.Location = new System.Drawing.Point(228, 17);
            this.txtFromAccNo.Name = "txtFromAccNo";
            this.netResize1.SetResizeTextBoxMultiline(this.txtFromAccNo, false);
            this.txtFromAccNo.ReadOnly = true;
            this.txtFromAccNo.Size = new System.Drawing.Size(79, 20);
            this.txtFromAccNo.TabIndex = 5;
            this.txtFromAccNo.Tag = " T_GDDET.AccNo ";
            this.txtFromAccNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtIntoAccNo
            // 
            this.txtIntoAccNo.BackColor = System.Drawing.Color.White;
            this.txtIntoAccNo.Location = new System.Drawing.Point(228, 42);
            this.txtIntoAccNo.Name = "txtIntoAccNo";
            this.netResize1.SetResizeTextBoxMultiline(this.txtIntoAccNo, false);
            this.txtIntoAccNo.ReadOnly = true;
            this.txtIntoAccNo.Size = new System.Drawing.Size(79, 20);
            this.txtIntoAccNo.TabIndex = 8;
            this.txtIntoAccNo.Tag = " T_GDDET.AccNo ";
            this.txtIntoAccNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLegateNo
            // 
            this.txtLegateNo.BackColor = System.Drawing.Color.White;
            this.txtLegateNo.Location = new System.Drawing.Point(228, 67);
            this.txtLegateNo.Name = "txtLegateNo";
            this.netResize1.SetResizeTextBoxMultiline(this.txtLegateNo, false);
            this.txtLegateNo.ReadOnly = true;
            this.txtLegateNo.Size = new System.Drawing.Size(79, 20);
            this.txtLegateNo.TabIndex = 11;
            this.txtLegateNo.Tag = " T_GDHEAD.gdMnd";
            this.txtLegateNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUserNo
            // 
            this.txtUserNo.BackColor = System.Drawing.Color.White;
            this.txtUserNo.Location = new System.Drawing.Point(228, 92);
            this.txtUserNo.Name = "txtUserNo";
            this.netResize1.SetResizeTextBoxMultiline(this.txtUserNo, false);
            this.txtUserNo.ReadOnly = true;
            this.txtUserNo.Size = new System.Drawing.Size(79, 20);
            this.txtUserNo.TabIndex = 14;
            this.txtUserNo.Tag = " T_GDHEAD.gdUser";
            this.txtUserNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_SrchUsrNo
            // 
            this.button_SrchUsrNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchUsrNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchUsrNo.Location = new System.Drawing.Point(199, 92);
            this.button_SrchUsrNo.Name = "button_SrchUsrNo";
            this.button_SrchUsrNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchUsrNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchUsrNo.Symbol = "???";
            this.button_SrchUsrNo.SymbolSize = 12F;
            this.button_SrchUsrNo.TabIndex = 15;
            this.button_SrchUsrNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchUsrNo.Click += new System.EventHandler(this.button_SrchUsrNo_Click);
            // 
            // button_SrchLegNo
            // 
            this.button_SrchLegNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchLegNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchLegNo.Location = new System.Drawing.Point(199, 67);
            this.button_SrchLegNo.Name = "button_SrchLegNo";
            this.button_SrchLegNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchLegNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchLegNo.Symbol = "???";
            this.button_SrchLegNo.SymbolSize = 12F;
            this.button_SrchLegNo.TabIndex = 12;
            this.button_SrchLegNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchLegNo.Click += new System.EventHandler(this.button_SrchLegNo_Click);
            // 
            // button_SrchAccTo
            // 
            this.button_SrchAccTo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchAccTo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchAccTo.Location = new System.Drawing.Point(199, 42);
            this.button_SrchAccTo.Name = "button_SrchAccTo";
            this.button_SrchAccTo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchAccTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchAccTo.Symbol = "???";
            this.button_SrchAccTo.SymbolSize = 12F;
            this.button_SrchAccTo.TabIndex = 9;
            this.button_SrchAccTo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchAccTo.Click += new System.EventHandler(this.button_SrchAccTo_Click);
            // 
            // button_SrchAccFrom
            // 
            this.button_SrchAccFrom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchAccFrom.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchAccFrom.Location = new System.Drawing.Point(199, 17);
            this.button_SrchAccFrom.Name = "button_SrchAccFrom";
            this.button_SrchAccFrom.Size = new System.Drawing.Size(26, 20);
            this.button_SrchAccFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchAccFrom.Symbol = "???";
            this.button_SrchAccFrom.SymbolSize = 12F;
            this.button_SrchAccFrom.TabIndex = 6;
            this.button_SrchAccFrom.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchAccFrom.Click += new System.EventHandler(this.button_SrchAccFrom_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(312, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 1147;
            this.label7.Text = "???????????????????????? :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(312, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 1146;
            this.label6.Text = "?????? ???????? :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(312, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 1148;
            this.label5.Text = "???? ???????? :";
            // 
            // txtCostCName
            // 
            this.txtCostCName.BackColor = System.Drawing.Color.Ivory;
            this.txtCostCName.ForeColor = System.Drawing.Color.White;
            this.txtCostCName.Location = new System.Drawing.Point(8, 117);
            this.txtCostCName.Name = "txtCostCName";
            this.netResize1.SetResizeTextBoxMultiline(this.txtCostCName, false);
            this.txtCostCName.ReadOnly = true;
            this.txtCostCName.Size = new System.Drawing.Size(188, 20);
            this.txtCostCName.TabIndex = 19;
            this.txtCostCName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCostCNo
            // 
            this.txtCostCNo.BackColor = System.Drawing.Color.White;
            this.txtCostCNo.Location = new System.Drawing.Point(228, 117);
            this.txtCostCNo.Name = "txtCostCNo";
            this.netResize1.SetResizeTextBoxMultiline(this.txtCostCNo, false);
            this.txtCostCNo.ReadOnly = true;
            this.txtCostCNo.Size = new System.Drawing.Size(79, 20);
            this.txtCostCNo.TabIndex = 17;
            this.txtCostCNo.Tag = " T_GDHEAD.gdCstNo ";
            this.txtCostCNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_SrchCostNo
            // 
            this.button_SrchCostNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchCostNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCostNo.Location = new System.Drawing.Point(199, 117);
            this.button_SrchCostNo.Name = "button_SrchCostNo";
            this.button_SrchCostNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchCostNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCostNo.Symbol = "???";
            this.button_SrchCostNo.SymbolSize = 12F;
            this.button_SrchCostNo.TabIndex = 18;
            this.button_SrchCostNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCostNo.Click += new System.EventHandler(this.button_SrchCostNo_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(312, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 1145;
            this.label8.Text = "???????? ?????????????? :";
            // 
            // FlexField
            // 
            this.FlexField.AllowEditing = false;
            this.FlexField.ColumnInfo = resources.GetString("FlexField.ColumnInfo");
            this.FlexField.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FlexField.Location = new System.Drawing.Point(-249, 19);
            this.FlexField.Name = "FlexField";
            this.FlexField.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FlexField.Rows.DefaultSize = 19;
            this.FlexField.Size = new System.Drawing.Size(224, 285);
            this.FlexField.StyleInfo = resources.GetString("FlexField.StyleInfo");
            this.FlexField.TabIndex = 1140;
            this.FlexField.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::InvAcc.Properties.Resources.Untitled_2_copy;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(11, 126);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(391, 143);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1165;
            this.pictureBox1.TabStop = false;
            // 
            // FRAccountTrans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 362);
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FRAccountTrans";
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FRAccountTrans_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.ribbonBar1.ResumeLayout(false);
            this.ribbonBar1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButExit)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMBalanceB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMBalanceS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownLevel)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlexField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.ResumeLayout(false);
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
            if (e.KeyCode == Keys.F5 && ButOk.Enabled && ButOk.Visible)
            {
                ButOk_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        public FRAccountTrans()
        {
            InitializeComponent();
            _User = dbc.StockUser(VarGeneral.UserNumber);
            HijriGregDates dateFormatter = new HijriGregDates();
            if (VarGeneral.Settings_Sys.Calendr.Value == 0)
            {
                txtMFromDate.Text = VarGeneral.Gdate.Substring(0, 4) + "/01/01";
                txtMToDate.Text = dateFormatter.FormatGreg(VarGeneral.Gdate, "yyyy/MM/dd");
            }
            else
            {
                txtMFromDate.Text = VarGeneral.Hdate.Substring(0, 4) + "/01/01";
                txtMToDate.Text = dateFormatter.FormatHijri(VarGeneral.Hdate, "yyyy/MM/dd");
            }
            if (VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F" || VarGeneral.SSSLev == "S" || VarGeneral.SSSLev == "C")
            {
                label8.Visible = false;
                txtCostCNo.Visible = false;
                button_SrchCostNo.Visible = false;
                txtCostCName.Visible = false;
            }
            else
            {
                label8.Visible = true;
                txtCostCNo.Visible = true;
                button_SrchCostNo.Visible = true;
                txtCostCName.Visible = true;
            }
            try
            {
                if (VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F")
                {
                    RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
                    try
                    {
                        object q = hKey.GetValue("vCoCe");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vCoCe");
                            hKey.SetValue("vCoCe", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vCoCe");
                        hKey.SetValue("vCoCe", "0");
                    }
                    long regval = long.Parse(hKey.GetValue("vCoCe").ToString());
                    if (regval == 1)
                    {
                        label8.Visible = true;
                        txtCostCNo.Visible = true;
                        button_SrchCostNo.Visible = true;
                        txtCostCName.Visible = true;
                    }
                    else
                    {
                        label8.Visible = false;
                        txtCostCNo.Visible = false;
                        button_SrchCostNo.Visible = false;
                        txtCostCName.Visible = false;
                    }
                }
            }
            catch
            {
            }
            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49))
            {
                txtMBalanceB.DisplayFormat = VarGeneral.DicemalMask;
                txtMBalanceS.DisplayFormat = VarGeneral.DicemalMask;
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRAccountTrans));
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
            try
            {
                VarGeneral.itmDesIndex = 0;
                VarGeneral.itmDes = "";
                VarGeneral._DTFrom = "";
                VarGeneral._DTTo = "";
            }
            catch
            {
            }
            FillFlex();
            RepDef();
            if (VarGeneral.SSSTyp == 0)
            {
                numUpDownLevel.Visible = false;
                label10.Visible = false;
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptMaintenanceCars.dll"))
            {
                label7.Text = ((LangArEn == 0) ? "?????? ?????????????? :" : "Car Type :");
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptBus.dll"))
            {
                label8.Text = ((LangArEn == 0) ? "?????????? :" : "Bus :");
                label7.Text = ((LangArEn == 0) ? "???????????? :" : "Driver :");
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptWaterPackages.dll"))
            {
                label7.Text = ((LangArEn == 0) ? "???????????????????????????? :" : "Customer :");
                label8.Text = ((LangArEn == 0) ? "?????????????????? :" : "Car :");
            }
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRAccountTrans));
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
            FillFlex();
            RepDef();
        }
        private void RepDef()
        {
            for (int iiCnt = 1; iiCnt < FlexField.Rows.Count; iiCnt++)
            {
                FlexField.SetData(iiCnt, 0, 1);
            }
        }
        private void FillFlex()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                if (VarGeneral.InvType == 1)
                {
                    Text = "?????????? ???????????? ??????????????";
                    FlexField.Rows.Count = 5;
                    FlexField.SetData(0, 0, "??????????");
                    FlexField.SetData(0, 1, "?????? ??????????");
                    FlexField.SetData(1, 1, "[?????? ????????????]");
                    FlexField.SetData(1, 2, " T_AccDef.AccDef_No ");
                    FlexField.SetData(2, 1, "[?????? ????????????]");
                    FlexField.SetData(2, 2, " T_AccDef.Arb_Des as AccDefNm ");
                    FlexField.SetData(3, 1, "[???????? ??????????]");
                    FlexField.SetData(3, 2, " Sum(CASE WHEN T_GDDET.gdValue > 0 THEN T_GDDET.gdValue ELSE 0 END) as Debit");
                    FlexField.SetData(4, 1, "[???????? ??????????]");
                    FlexField.SetData(4, 2, " Sum(CASE WHEN T_GDDET.gdValue < 0 THEN Abs(T_GDDET.gdValue) ELSE 0 END) as Credit");
                    FlexField.Tag = " Group by T_AccDef.AccDef_No,T_AccDef.Arb_Des,T_SYSSETTING.LogImg  ";
                }
                else if (VarGeneral.InvType == 2)
                {
                    Text = "?????????? ???????????? ????????????????";
                    FlexField.Rows.Count = 5;
                    FlexField.SetData(0, 0, "??????????");
                    FlexField.SetData(0, 1, "?????? ??????????");
                    FlexField.SetData(1, 1, "[?????? ????????????]");
                    FlexField.SetData(1, 2, " T_AccDef.AccDef_No ");
                    FlexField.SetData(2, 1, "[?????? ????????????]");
                    FlexField.SetData(2, 2, " T_AccDef.Arb_Des as AccDefNm ");
                    FlexField.SetData(3, 1, "[???????????? ????????]");
                    FlexField.SetData(3, 2, " CASE WHEN Sum(T_GDDET.gdValue) > 0 THEN Sum(T_GDDET.gdValue) ELSE 0 END as Debit");
                    FlexField.SetData(4, 1, "[???????????? ????????]");
                    FlexField.SetData(4, 2, " CASE WHEN Sum(T_GDDET.gdValue) < 0 THEN Abs(Sum(T_GDDET.gdValue)) ELSE 0 END as Credit");
                    FlexField.Tag = " Group by T_AccDef.AccDef_No,T_AccDef.Arb_Des,T_SYSSETTING.LogImg  ";
                }
                else if (VarGeneral.InvType == 3)
                {
                    Text = "?????????? ???????????? ??????????????????";
                    FlexField.Rows.Count = 5;
                    FlexField.SetData(0, 0, "??????????");
                    FlexField.SetData(0, 1, "?????? ??????????");
                    FlexField.SetData(1, 1, "[?????? ????????????]");
                    FlexField.SetData(1, 2, " T_AccDef.AccDef_No ");
                    FlexField.SetData(2, 1, "[?????? ????????????]");
                    FlexField.SetData(2, 2, " T_AccDef.Arb_Des as AccDefNm ");
                    FlexField.SetData(3, 1, "[?????????? ????????]");
                    FlexField.SetData(3, 2, " Sum(CASE WHEN T_GDDET.gdValue > 0 THEN T_GDDET.gdValue ELSE 0 END) as Debit");
                    FlexField.SetData(4, 1, "[?????????? ????????]");
                    FlexField.SetData(4, 2, " Sum(CASE WHEN T_GDDET.gdValue < 0 THEN Abs(T_GDDET.gdValue) ELSE 0 END) as Credit");
                    FlexField.Tag = " Group by T_AccDef.AccDef_No,T_AccDef.Arb_Des,T_SYSSETTING.LogImg  ";
                }
                else if (VarGeneral.InvType == 4)
                {
                    Text = "?????????? ???????????? ???????????????? ?? ????????????????";
                    FlexField.Rows.Count = 7;
                    FlexField.SetData(0, 0, "??????????");
                    FlexField.SetData(0, 1, "?????? ??????????");
                    FlexField.SetData(1, 1, "[?????? ????????????]");
                    FlexField.SetData(1, 2, " T_AccDef.AccDef_No ");
                    FlexField.SetData(2, 1, "[?????? ????????????]");
                    FlexField.SetData(2, 2, " T_AccDef.Arb_Des as AccDefNm ");
                    FlexField.SetData(3, 1, "[?????????? ????????]");
                    FlexField.SetData(3, 2, " Sum(CASE WHEN T_GDDET.gdValue > 0 THEN T_GDDET.gdValue ELSE 0 END) as Debit");
                    FlexField.SetData(4, 1, "[?????????? ????????]");
                    FlexField.SetData(4, 2, " Sum(CASE WHEN T_GDDET.gdValue < 0 THEN Abs(T_GDDET.gdValue) ELSE 0 END) as Credit");
                    FlexField.SetData(5, 1, "[???????????? ????????]");
                    FlexField.SetData(5, 2, " CASE WHEN Sum(T_GDDET.gdValue) > 0 THEN Sum(T_GDDET.gdValue) ELSE 0 END as TotDebit");
                    FlexField.SetData(6, 1, "[???????????? ????????]");
                    FlexField.SetData(6, 2, " CASE WHEN Sum(T_GDDET.gdValue) < 0 THEN Abs(Sum(T_GDDET.gdValue)) ELSE 0 END TotCreit");
                    FlexField.Tag = " Group by T_AccDef.AccDef_No,T_AccDef.Arb_Des,T_SYSSETTING.LogImg  ";
                    switchButton_OpenValue.Visible = true;
                }
                else if (VarGeneral.InvType == 5)
                {
                    Text = "???????? ????????????????";
                    FlexField.Rows.Count = 6;
                    FlexField.SetData(0, 0, "??????????");
                    FlexField.SetData(0, 1, "?????? ??????????");
                    FlexField.SetData(1, 1, "[?????? ????????????]");
                    FlexField.SetData(1, 2, " T_AccDef.AccDef_No ");
                    FlexField.SetData(2, 1, "[?????? ????????????]");
                    FlexField.SetData(2, 2, " T_AccDef.Arb_Des as AccDefNm ");
                    FlexField.SetData(3, 1, "[???????????? ????????]");
                    FlexField.SetData(3, 2, " CASE WHEN Sum(T_GDDET.gdValue) > 0 THEN Sum(T_GDDET.gdValue) ELSE 0 END as Debit");
                    FlexField.SetData(4, 1, "[???????????? ????????]");
                    FlexField.SetData(4, 2, " CASE WHEN Sum(T_GDDET.gdValue) < 0 THEN Abs(Sum(T_GDDET.gdValue)) ELSE 0 END as Credit");
                    FlexField.SetData(5, 1, "[????????????]");
                    FlexField.SetData(5, 2, " Sum(T_GDDET.gdValue) as Balance ");
                    FlexField.Tag = " and T_AccDef.Trn = 1 Group by T_AccDef.AccDef_No,T_AccDef.Arb_Des,T_SYSSETTING.LogImg  ";
                    groupBox2.Visible = false;
                }
                else if (VarGeneral.InvType == 6)
                {
                    Text = "???????? ?????????????? ????????????????";
                    FlexField.Rows.Count = 6;
                    FlexField.SetData(0, 0, "??????????");
                    FlexField.SetData(0, 1, "?????? ??????????");
                    FlexField.SetData(1, 1, "[?????? ????????????]");
                    FlexField.SetData(1, 2, " T_AccDef.AccDef_No ");
                    FlexField.SetData(2, 1, "[?????? ????????????]");
                    FlexField.SetData(2, 2, " T_AccDef.Arb_Des as AccDefNm ");
                    FlexField.SetData(3, 1, "[???????????? ????????]");
                    FlexField.SetData(3, 2, " CASE WHEN Sum(T_GDDET.gdValue) > 0 THEN Sum(T_GDDET.gdValue) ELSE 0 END as Debit");
                    FlexField.SetData(4, 1, "[???????????? ????????]");
                    FlexField.SetData(4, 2, " CASE WHEN Sum(T_GDDET.gdValue) < 0 THEN Abs(Sum(T_GDDET.gdValue)) ELSE 0 END as Credit");
                    FlexField.SetData(5, 1, "[????????????]");
                    FlexField.SetData(5, 2, " Sum(T_GDDET.gdValue) as Balance");
                    FlexField.Tag = " and T_AccDef.Trn = 2 Group by T_AccDef.AccDef_No,T_AccDef.Arb_Des,T_SYSSETTING.LogImg  ";
                    groupBox2.Visible = false;
                }
                else if (VarGeneral.InvType == 7)
                {
                    Text = "?????????????????? ????????????????";
                    FlexField.Rows.Count = 5;
                    FlexField.SetData(0, 0, "??????????");
                    FlexField.SetData(0, 1, "?????? ??????????");
                    FlexField.SetData(1, 1, "[?????? ????????????]");
                    FlexField.SetData(1, 2, " T_AccDef.AccDef_No ");
                    FlexField.SetData(2, 1, "[?????? ????????????]");
                    FlexField.SetData(2, 2, " T_AccDef.Arb_Des as AccDefNm ");
                    FlexField.SetData(3, 1, "[???????????? ????????]");
                    FlexField.SetData(3, 2, " CASE WHEN Sum(T_GDDET.gdValue) > 0 THEN Sum(T_GDDET.gdValue) ELSE 0 END as Debit");
                    FlexField.SetData(4, 1, "[???????????? ????????]");
                    FlexField.SetData(4, 2, " CASE WHEN Sum(T_GDDET.gdValue) < 0 THEN Abs(Sum(T_GDDET.gdValue)) ELSE 0 END as Credit");
                    FlexField.Tag = " and T_AccDef.Trn = 3 Group by T_AccDef.AccDef_No,T_AccDef.Arb_Des,T_SYSSETTING.LogImg  ";
                    groupBox2.Visible = false;
                }
            }
            else if (VarGeneral.InvType == 1)
            {
                Text = "Movements Entrails Balance";
                FlexField.Rows.Count = 5;
                FlexField.SetData(0, 0, "Showing");
                FlexField.SetData(0, 1, "Filed Name");
                FlexField.SetData(1, 1, "[Account No]");
                FlexField.SetData(1, 2, " T_AccDef.AccDef_No ");
                FlexField.SetData(2, 1, "[Account Name]");
                FlexField.SetData(2, 2, " T_AccDef.Eng_Des as AccDefNm ");
                FlexField.SetData(3, 1, "[Debit Trans]");
                FlexField.SetData(3, 2, " Sum(CASE WHEN T_GDDET.gdValue > 0 THEN T_GDDET.gdValue ELSE 0 END) as Debit");
                FlexField.SetData(4, 1, "[Credit Trans]");
                FlexField.SetData(4, 2, " Sum(CASE WHEN T_GDDET.gdValue < 0 THEN Abs(T_GDDET.gdValue) ELSE 0 END) as Credit");
                FlexField.Tag = " Group by T_AccDef.AccDef_No,T_AccDef.Eng_Des,T_SYSSETTING.LogImg  ";
            }
            else if (VarGeneral.InvType == 2)
            {
                Text = "Trial balance of balances";
                FlexField.Rows.Count = 5;
                FlexField.SetData(0, 0, "Showing");
                FlexField.SetData(0, 1, "Filed Name");
                FlexField.SetData(1, 1, "[Account No]");
                FlexField.SetData(1, 2, " T_AccDef.AccDef_No ");
                FlexField.SetData(2, 1, "[Account Name]");
                FlexField.SetData(2, 2, " T_AccDef.Eng_Des as AccDefNm ");
                FlexField.SetData(3, 1, "[Debit Balance]");
                FlexField.SetData(3, 2, " CASE WHEN Sum(T_GDDET.gdValue) > 0 THEN Sum(T_GDDET.gdValue) ELSE 0 END as Debit");
                FlexField.SetData(4, 1, "[Credit Balance]");
                FlexField.SetData(4, 2, " CASE WHEN Sum(T_GDDET.gdValue) < 0 THEN Abs(Sum(T_GDDET.gdValue)) ELSE 0 END as Credit");
                FlexField.Tag = " Group by T_AccDef.AccDef_No,T_AccDef.Eng_Des,T_SYSSETTING.LogImg  ";
            }
            else if (VarGeneral.InvType == 3)
            {
                Text = "Totals Trial Balance";
                FlexField.Rows.Count = 5;
                FlexField.SetData(0, 0, "Showing");
                FlexField.SetData(0, 1, "Filed Name");
                FlexField.SetData(1, 1, "[Account No]");
                FlexField.SetData(1, 2, " T_AccDef.AccDef_No ");
                FlexField.SetData(2, 1, "[Account Name]");
                FlexField.SetData(2, 2, " T_AccDef.Eng_Des as AccDefNm ");
                FlexField.SetData(3, 1, "[Total Debit]");
                FlexField.SetData(3, 2, " Sum(CASE WHEN T_GDDET.gdValue > 0 THEN T_GDDET.gdValue ELSE 0 END) as Debit");
                FlexField.SetData(4, 1, "[Total Credit]");
                FlexField.SetData(4, 2, " Sum(CASE WHEN T_GDDET.gdValue < 0 THEN Abs(T_GDDET.gdValue) ELSE 0 END) as Credit");
                FlexField.Tag = " Group by T_AccDef.AccDef_No,T_AccDef.Eng_Des,T_SYSSETTING.LogImg  ";
            }
            else if (VarGeneral.InvType == 4)
            {
                Text = "Balance and Totally Trial Balance";
                FlexField.Rows.Count = 7;
                FlexField.SetData(0, 0, "Showing");
                FlexField.SetData(0, 1, "Filed Name");
                FlexField.SetData(1, 1, "[Account No]");
                FlexField.SetData(1, 2, " T_AccDef.AccDef_No ");
                FlexField.SetData(2, 1, "[Account Name]");
                FlexField.SetData(2, 2, " T_AccDef.Eng_Des as AccDefNm ");
                FlexField.SetData(3, 1, "[Total Debit]");
                FlexField.SetData(3, 2, " Sum(CASE WHEN T_GDDET.gdValue > 0 THEN T_GDDET.gdValue ELSE 0 END) as Debit");
                FlexField.SetData(4, 1, "[Total Credit]");
                FlexField.SetData(4, 2, " Sum(CASE WHEN T_GDDET.gdValue < 0 THEN Abs(T_GDDET.gdValue) ELSE 0 END) as Credit");
                FlexField.SetData(5, 1, "[Debit Balance]");
                FlexField.SetData(5, 2, " CASE WHEN Sum(T_GDDET.gdValue) > 0 THEN Sum(T_GDDET.gdValue) ELSE 0 END as TotDebit");
                FlexField.SetData(6, 1, "[Credit Balance]");
                FlexField.SetData(6, 2, " CASE WHEN Sum(T_GDDET.gdValue) < 0 THEN Abs(Sum(T_GDDET.gdValue)) ELSE 0 END TotCreit");
                switchButton_OpenValue.Visible = true;
                FlexField.Tag = " Group by T_AccDef.AccDef_No,T_AccDef.Eng_Des,T_SYSSETTING.LogImg  ";
            }
            else if (VarGeneral.InvType == 5)
            {
                Text = "Trading Account";
                FlexField.Rows.Count = 6;
                FlexField.SetData(0, 0, "Showing");
                FlexField.SetData(0, 1, "Filed Name");
                FlexField.SetData(1, 1, "[Account No]");
                FlexField.SetData(1, 2, " T_AccDef.AccDef_No ");
                FlexField.SetData(2, 1, "[Account Name]");
                FlexField.SetData(2, 2, " T_AccDef.Eng_Des as AccDefNm ");
                FlexField.SetData(3, 1, "[Debit Balance]");
                FlexField.SetData(3, 2, " CASE WHEN Sum(T_GDDET.gdValue) > 0 THEN Sum(T_GDDET.gdValue) ELSE 0 END as Debit");
                FlexField.SetData(4, 1, "[Credit Balance]");
                FlexField.SetData(4, 2, " CASE WHEN Sum(T_GDDET.gdValue) < 0 THEN Abs(Sum(T_GDDET.gdValue)) ELSE 0 END as Credit");
                FlexField.SetData(5, 1, "[Balance]");
                FlexField.SetData(5, 2, " Sum(T_GDDET.gdValue) as Balance");
                FlexField.Tag = " and T_AccDef.Trn = 1 Group by T_AccDef.AccDef_No,T_AccDef.Eng_Des,T_SYSSETTING.LogImg  ";
                groupBox2.Visible = false;
            }
            else if (VarGeneral.InvType == 6)
            {
                Text = "Profits and Losses";
                FlexField.Rows.Count = 6;
                FlexField.SetData(0, 0, "Showing");
                FlexField.SetData(0, 1, "Filed Name");
                FlexField.SetData(1, 1, "[Account No]");
                FlexField.SetData(1, 2, " T_AccDef.AccDef_No ");
                FlexField.SetData(2, 1, "[Account Name]");
                FlexField.SetData(2, 2, " T_AccDef.Eng_Des as AccDefNm ");
                FlexField.SetData(3, 1, "[Debit Balance]");
                FlexField.SetData(3, 2, " CASE WHEN Sum(T_GDDET.gdValue) > 0 THEN Sum(T_GDDET.gdValue) ELSE 0 END as Debit");
                FlexField.SetData(4, 1, "[Credit Balance]");
                FlexField.SetData(4, 2, " CASE WHEN Sum(T_GDDET.gdValue) < 0 THEN Abs(Sum(T_GDDET.gdValue)) ELSE 0 END as Credit");
                FlexField.SetData(5, 1, "[Balance]");
                FlexField.SetData(5, 2, " Sum(T_GDDET.gdValue) as Balance");
                FlexField.Tag = " and T_AccDef.Trn = 2 Group by T_AccDef.AccDef_No,T_AccDef.Eng_Des,T_SYSSETTING.LogImg  ";
                groupBox2.Visible = false;
            }
            else if (VarGeneral.InvType == 7)
            {
                Text = "General Budget";
                FlexField.Rows.Count = 5;
                FlexField.SetData(0, 0, "Showing");
                FlexField.SetData(0, 1, "Filed Name");
                FlexField.SetData(1, 1, "[Account No]");
                FlexField.SetData(1, 2, " T_AccDef.AccDef_No ");
                FlexField.SetData(2, 1, "[Account Name]");
                FlexField.SetData(2, 2, " T_AccDef.Eng_Des as AccDefNm ");
                FlexField.SetData(3, 1, "[Debit Balance]");
                FlexField.SetData(3, 2, " Round(CASE WHEN Sum(T_GDDET.gdValue) > 0 THEN Sum(T_GDDET.gdValue) ELSE 0 END," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as Debit");
                FlexField.SetData(4, 1, "[Credit Balance]");
                FlexField.SetData(4, 2, " Round(CASE WHEN Sum(T_GDDET.gdValue) < 0 THEN Abs(Sum(T_GDDET.gdValue)) ELSE 0 END," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as Credit");
                FlexField.Tag = " and T_AccDef.Trn = 3 Group by T_AccDef.AccDef_No,T_AccDef.Eng_Des , T_AccDef.AccCat , T_AccDef.ParAcc,T_SYSSETTING.LogImg  ";
                groupBox2.Visible = false;
            }
            RibunButtons();
        }
        private string BuildFieldList()
        {
            string Fields = "";
            for (int iiCnt = 1; iiCnt < FlexField.Rows.Count; iiCnt++)
            {
                if (VarGeneral.TString.TEmptyBool(FlexField.GetData(iiCnt, 0)) && FlexField.Rows[iiCnt].Visible)
                {
                    if (!string.IsNullOrEmpty(Fields))
                    {
                        Fields += ",";
                    }
                    Fields += FlexField.GetData(iiCnt, 2).ToString();
                }
            }
            return Fields + " ,T_SYSSETTING.LogImg " + (switchButton_OpenValue.Value ? ",case when (select sum(gdValue) from T_GDDET x LEFT OUTER JOIN T_GDHEAD ON x.gdID = T_GDHEAD.gdhead_ID where x.AccNo = T_AccDef.AccDef_No and T_GDHEAD.salMonth = 'OpenGD' and x.gdValue > 0) > 0 then (select sum(gdValue) from T_GDDET x LEFT OUTER JOIN T_GDHEAD ON x.gdID = T_GDHEAD.gdhead_ID where x.AccNo = T_AccDef.AccDef_No and T_GDHEAD.salMonth = 'OpenGD' and x.gdValue > 0) else 0 end as DebitPervious,case when (select abs(sum(gdValue)) from T_GDDET x LEFT OUTER JOIN T_GDHEAD ON x.gdID = T_GDHEAD.gdhead_ID where x.AccNo = T_AccDef.AccDef_No and T_GDHEAD.salMonth = 'OpenGD' and x.gdValue < 0) > 0 then (select abs(sum(gdValue)) from T_GDDET x LEFT OUTER JOIN T_GDHEAD ON x.gdID = T_GDHEAD.gdhead_ID where x.AccNo = T_AccDef.AccDef_No and T_GDHEAD.salMonth = 'OpenGD' and x.gdValue < 0) else 0 end as CreditPervious" : " ");
        }
        private string BuildRuleList()
        {
            HijriGregDates dateFormatter = new HijriGregDates();
            string Rule = "Where 1 = 1 and T_GDHEAD.gdLok = 0 ";
            if (txtMBalanceB.LockUpdateChecked)
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtMBalanceB.Tag, " >= ", txtMBalanceB.Value);
            }
            if (txtMBalanceS.LockUpdateChecked)
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtMBalanceS.Tag, " <= ", txtMBalanceS.Value);
            }
            if (!string.IsNullOrEmpty(txtFromAccNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtFromAccNo.Tag, " >= '", txtFromAccNo.Text.Trim(), "'");
            }
            if (!string.IsNullOrEmpty(txtIntoAccNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtIntoAccNo.Tag, " <= '", txtIntoAccNo.Text.Trim(), "'");
            }
            if (!string.IsNullOrEmpty(txtCostCNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtCostCNo.Tag, " = '", txtCostCNo.Text.Trim(), "'");
            }
            if (!string.IsNullOrEmpty(txtUserNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtUserNo.Tag, " = '", txtUserNo.Text.Trim(), "'");
            }
            if (!string.IsNullOrEmpty(txtLegateNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtLegateNo.Tag, " = '", txtLegateNo.Text.Trim(), "'");
            }
            if (VarGeneral.InvType == 7 && numUpDownLevel.Value == 4m)
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", numUpDownLevel.Tag, " =  CASE WHEN T_AccDef.AccCat = '4' OR T_AccDef.AccCat = '5' OR T_AccDef.AccCat = '6' THEN 3 ELSE 4 END ");
            }
            else
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", numUpDownLevel.Tag, " = ", numUpDownLevel.Value);
            }
            if (VarGeneral.CheckDate(txtMFromDate.Text) && txtMFromDate.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMFromDate.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_GDHEAD.gdGDate  >= '" + dateFormatter.FormatGreg(txtMFromDate.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_GDHEAD.gdHDate  >= '" + dateFormatter.FormatHijri(txtMFromDate.Text, "yyyy/MM/dd") + "'"));
            }
            if (VarGeneral.CheckDate(txtMToDate.Text) && txtMToDate.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMToDate.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_GDHEAD.gdGDate  <= '" + dateFormatter.FormatGreg(txtMToDate.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_GDHEAD.gdHDate  <= '" + dateFormatter.FormatHijri(txtMToDate.Text, "yyyy/MM/dd") + "'"));
            }
            return Rule + FlexField.Tag;
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (Text == "?????????? ???????????? ??????????????" || Text == "Movements Entrails Balance")
                {
                    VarGeneral.InvType = 1;
                }
                else if (Text == "?????????? ???????????? ????????????????" || Text == "Trial balance of balances")
                {
                    VarGeneral.InvType = 2;
                }
                else if (Text == "?????????? ???????????? ??????????????????" || Text == "Totals Trial Balance")
                {
                    VarGeneral.InvType = 3;
                }
                else if (Text == "?????????? ???????????? ???????????????? ?? ????????????????" || Text == "Balance and Totally Trial Balance")
                {
                    VarGeneral.InvType = 4;
                }
                else if (Text == "???????? ????????????????" || Text == "Trading Account")
                {
                    VarGeneral.InvType = 5;
                }
                else if (Text == "???????? ?????????????? ????????????????" || Text == "Profits and Losses")
                {
                    VarGeneral.InvType = 6;
                }
                else if (Text == "?????????????????? ????????????????" || Text == "General Budget")
                {
                    VarGeneral.InvType = 7;
                }
                RepShow _RepShow = new RepShow();
                string Tables = " T_GDDET LEFT OUTER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID  LEFT OUTER JOIN T_INVSETTING On T_GDHEAD.gdTyp = T_INVSETTING.InvID  " + ((VarGeneral.InvType == 7 && numUpDownLevel.Value == 4m) ? " LEFT OUTER JOIN T_AccDef on (T_GDDET.AccNo = T_AccDef.AccDef_No or (T_GDDET.AccNo LIKE T_AccDef.AccDef_No + '%' and (T_AccDef.AccCat = '4' OR T_AccDef.AccCat = '5' OR T_AccDef.AccCat = '6'))) LEFT OUTER JOIN " : " LEFT OUTER JOIN T_AccDef on T_GDDET.AccNo = T_AccDef.AccDef_No LEFT OUTER JOIN ") + "T_SYSSETTING ON T_GDHEAD.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                string Fields = BuildFieldList();
                _RepShow.Rule = BuildRuleList() + " order by AccDef_No ";
                if (string.IsNullOrEmpty(Fields))
                {
                    return;
                }
                _RepShow.Fields = Fields;
                _RepShow.Tables = Tables;
                try
                {
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                    if (VarGeneral.InvType == 5)
                    {
                        _RepShow = new RepShow();
                        _RepShow.Rule = "";
                        _RepShow.Tables = " T_Items INNER JOIN T_stksQty ON T_Items.Itm_No = T_stksQty.itmNo Left Join  T_SYSSETTING ON T_Items.CompanyID = T_SYSSETTING.SYSSETTING_ID Group by T_SYSSETTING.LogImg ";
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                        {
                            _RepShow.Fields = " '----'  As [AccDef_No], '?????????? ?????? ?????????? '  As [AccDefNm], Round(Sum(T_Items.AvrageCost * T_stksQty.stkQty) * 0," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")  As [Debit], Round(Sum(T_Items.AvrageCost * T_stksQty.stkQty)," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")  As [Credit] ,  -Round(Sum(T_Items.AvrageCost * T_stksQty.stkQty)," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")  As [Balance],T_SYSSETTING.LogImg ";
                        }
                        else
                        {
                            _RepShow.Fields = " '----'  As [AccDef_No], 'Net Stock Value'  As [AccDefNm], Round(Sum(T_Items.AvrageCost * T_stksQty.stkQty) * 0," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")  As [Debit], Round(Sum(T_Items.AvrageCost * T_stksQty.stkQty)," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") As [Credit] , -Round(Sum(T_Items.AvrageCost * T_stksQty.stkQty)," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")  As [Balance] ,T_SYSSETTING.LogImg ";
                        }
                        _RepShow = _RepShow.Save();
                        _RepShow.RepData.Tables[0].Merge(VarGeneral.RepData.Tables[0]);
                        VarGeneral.RepData = _RepShow.RepData;
                    }
                    else if (VarGeneral.InvType == 6)
                    {
                        double NetStock = 0.0;
                        _RepShow = new RepShow();
                        _RepShow.Rule = "";
                        _RepShow.Tables = " T_Items INNER JOIN T_stksQty ON T_Items.Itm_No = T_stksQty.itmNo ";
                        _RepShow.Fields = " Round(Sum(T_Items.AvrageCost * T_stksQty.stkQty)," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")  As [MTA] ";
                        _RepShow = _RepShow.Save();
                        if (_RepShow.RepData.Tables[0].Rows.Count != 0)
                        {
                            NetStock = double.Parse(VarGeneral.TString.TEmpty(string.Concat(_RepShow.RepData.Tables[0].Rows[0][0])));
                        }
                        _RepShow = new RepShow();
                        _RepShow.Rule = " Where 1 = 1 and T_GDHEAD.gdLok = 0  and T_AccDef.Trn = 1 and T_AccDef.Lev = 4 Group by T_SYSSETTING.LogImg ";
                        _RepShow.Tables = Tables;
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                        {
                            _RepShow.Fields = " '----'  As [AccDef_No], '???????? ?????????????? ????????????????'  As [AccDefNm], Round(CASE WHEN (Sum(T_GDDET.gdValue) -  " + NetStock + ") > 0 THEN (Sum(T_GDDET.gdValue) -  " + NetStock + ") ELSE 0 END," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")  As [Debit], Round(CASE WHEN (Sum(T_GDDET.gdValue) -  " + NetStock + ") < 0 THEN Abs(Sum(T_GDDET.gdValue) -  " + NetStock + ") ELSE 0 END," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")  As [Credit] , Round(Sum(T_GDDET.gdValue) -  " + NetStock + "," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as [Balance] ,T_SYSSETTING.LogImg ";
                        }
                        else
                        {
                            _RepShow.Fields = " '----'  As [AccDef_No], 'Net profits and losses'  As [AccDefNm], Round(CASE WHEN (Sum(T_GDDET.gdValue)  -  " + NetStock + ") > 0 THEN (Sum(T_GDDET.gdValue)  -  " + NetStock + ") ELSE 0 END," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")  As [Debit], Round(CASE WHEN (Sum(T_GDDET.gdValue)  -  " + NetStock + ") < 0 THEN Abs(Sum(T_GDDET.gdValue) -  " + NetStock + ") ELSE 0 END," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")  As [Credit] , Round(Sum(T_GDDET.gdValue) -  " + NetStock + "," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as [Balance] ,T_SYSSETTING.LogImg ";
                        }
                        _RepShow = _RepShow.Save();
                        _RepShow.RepData.Tables[0].Merge(VarGeneral.RepData.Tables[0]);
                        VarGeneral.RepData = _RepShow.RepData;
                    }
                    else if (VarGeneral.InvType == 7)
                    {
                        double NetStock = 0.0;
                        _RepShow = new RepShow();
                        _RepShow.Rule = "";
                        _RepShow.Tables = " T_Items INNER JOIN T_stksQty ON T_Items.Itm_No = T_stksQty.itmNo ";
                        _RepShow.Fields = " Round(Sum(T_Items.AvrageCost * T_stksQty.stkQty)," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")  As [MTA] ";
                        _RepShow = _RepShow.Save();
                        if (_RepShow.RepData.Tables[0].Rows.Count != 0)
                        {
                            NetStock = double.Parse(VarGeneral.TString.TEmpty(string.Concat(_RepShow.RepData.Tables[0].Rows[0][0])));
                        }
                        _RepShow = new RepShow();
                        _RepShow.Rule = " Where 1 = 1 and T_GDHEAD.gdLok = 0  and (T_AccDef.Trn = 1 or T_AccDef.Trn = 2) and T_AccDef.Lev = 4 Group by T_SYSSETTING.LogImg";
                        _RepShow.Tables = Tables;
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                        {
                            _RepShow.Fields = " '----'  As [AccDef_No], '???????? ?????????????? ????????????????'  As [AccDefNm], Round(CASE WHEN (Sum(T_GDDET.gdValue) -  " + NetStock + ") > 0 THEN (Sum(T_GDDET.gdValue) -  " + NetStock + ") ELSE 0 END," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")  As [Debit], Round(CASE WHEN (Sum(T_GDDET.gdValue) -  " + NetStock + ") < 0 THEN Abs(Sum(T_GDDET.gdValue) -  " + NetStock + ") ELSE 0 END," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")  As [Credit] ,T_SYSSETTING.LogImg ";
                        }
                        else
                        {
                            _RepShow.Fields = " '----'  As [AccDef_No], 'Net profits and losses'  As [AccDefNm], Round(CASE WHEN (Sum(T_GDDET.gdValue) -  " + NetStock + ") > 0 THEN (Sum(T_GDDET.gdValue) - " + NetStock + ") ELSE 0 END," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")  As [Debit], Round(CASE WHEN (Sum(T_GDDET.gdValue) - " + NetStock + ") < 0 THEN Abs(Sum(T_GDDET.gdValue) - " + NetStock + ") ELSE 0 END ," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") As [Credit] ,T_SYSSETTING.LogImg ";
                        }
                        _RepShow = _RepShow.Save();
                        _RepShow.RepData.Tables[0].Merge(VarGeneral.RepData.Tables[0]);
                        VarGeneral.RepData = _RepShow.RepData;
                        _RepShow = new RepShow();
                        _RepShow.Rule = "";
                        _RepShow.Tables = " T_Items INNER JOIN T_stksQty ON T_Items.Itm_No = T_stksQty.itmNo Left Join  T_SYSSETTING ON T_Items.CompanyID = T_SYSSETTING.SYSSETTING_ID Group by T_SYSSETTING.LogImg ";
                        if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                        {
                            _RepShow.Fields = " '----'  As [AccDef_No], '?????????? ?????? ??????????'  As [AccDefNm], Round(Sum(T_Items.AvrageCost * T_stksQty.stkQty)," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")  As [Debit], Round(Sum(T_Items.AvrageCost * T_stksQty.stkQty) * 0," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")  As [Credit],T_SYSSETTING.LogImg ";
                        }
                        else
                        {
                            _RepShow.Fields = " '----'  As [AccDef_No], 'Net Stock Value'  As [AccDefNm], Round(Sum(T_Items.AvrageCost * T_stksQty.stkQty)," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")  As [Debit], Round(Sum(T_Items.AvrageCost * T_stksQty.stkQty)* 0," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") As [Credit],T_SYSSETTING.LogImg ";
                        }
                        _RepShow = _RepShow.Save();
                        _RepShow.RepData.Tables[0].Merge(VarGeneral.RepData.Tables[0]);
                        VarGeneral.RepData = _RepShow.RepData;
                    }
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.Message);
                }
                if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "???????? .. ???? ???????? ???????????? ???????????? ???? ?????????????? " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                try
                {
                    VarGeneral.IsGeneralUsed = true;
                    FrmReportsViewer frm = new FrmReportsViewer();
                    frm.Repvalue = "AccountTrans";



                    frm.Tag = LangArEn;
                    frm.Repvalue = "AccountTrans";
                    if (switchButton_OpenValue.Value && switchButton_OpenValue.Visible)
                    {
                        VarGeneral.itmDesIndex = 1;
                    }
                    else
                    {
                        VarGeneral.itmDesIndex = 0;
                    }
                    VarGeneral.vTitle = Text;
                    if (VarGeneral.CheckDate(txtMFromDate.Text))
                    {
                        VarGeneral._DTFrom = txtMFromDate.Text;
                    }
                    else
                    {
                        VarGeneral._DTFrom = "";
                    }
                    if (VarGeneral.CheckDate(txtMToDate.Text))
                    {
                        VarGeneral._DTTo = txtMToDate.Text;
                    }
                    else
                    {
                        VarGeneral._DTTo = "";
                    }
                    frm.TopMost = true;
                    frm.ShowDialog();
                    VarGeneral.IsGeneralUsed = false;

                }
                catch (Exception error)
                {
                    VarGeneral.DebLog.writeLog("button_ShowRep_Click:", error, enable: true);
                    MessageBox.Show(error.Message);
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }
        private void ButExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ButExit.Text = "???????????????? Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "???????????????? F5" : "?????????????? F5");
                groupBox3.Text = "????????????????????";
                groupBox4.Text = "??????????????????????";
                label1.Text = "?????????????? :";
                label2.Text = "???????????????? :";
                label5.Text = "???? ???????? :";
                label6.Text = "?????? ???????? :";
                label7.Text = "???????????????????????? :";
                label8.Text = "???????? ?????????????? :";
                label9.Text = "?????????????????????? :";
                label10.Text = "?????????????? :";
                switchButton_OpenValue.OffText = "?????????? ???????????? ??????????????????";
                switchButton_OpenValue.OnText = "?????????? ???????????? ??????????????????";
            }
            else
            {
                ButExit.Text = "Exit Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "Print F5" : "Show F5");
                groupBox3.Text = "Balance";
                groupBox4.Text = "Date";
                label1.Text = "From :";
                label2.Text = "To :";
                label5.Text = "Account From :";
                label6.Text = "Account To :";
                label7.Text = "Delegate :";
                label8.Text = "Cost Center :";
                label9.Text = "User:";
                label10.Text = "Level :";
                switchButton_OpenValue.OffText = "Show opening balance";
                switchButton_OpenValue.OnText = "Show opening balance";
            }
        }
        private void FRAccountTrans_Load(object sender, EventArgs e)
        {
        }
        private void txtMFromDate_Click(object sender, EventArgs e)
        {
            txtMFromDate.SelectAll();
        }
        private void txtMToDate_Click(object sender, EventArgs e)
        {
            txtMToDate.SelectAll();
        }
        private void txtMFromDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtMFromDate.Text))
                {
                    txtMFromDate.Text = Convert.ToDateTime(txtMFromDate.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    txtMFromDate.Text = "";
                }
            }
            catch
            {
                txtMFromDate.Text = "";
            }
        }
        private void txtMToDate_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtMToDate.Text))
                {
                    txtMToDate.Text = Convert.ToDateTime(txtMToDate.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    txtMToDate.Text = "";
                }
            }
            catch
            {
                txtMToDate.Text = "";
            }
        }
        private void button_SrchAccFrom_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("?????????? ", " No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("?????????? ????????", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("?????????? ??????????????????", "English Name", ifDefault: true, ""));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("????????????", "Mobile", ifDefault: false, ""));
            columns_Names_visible.Add("TaxNo", new ColumnDictinary("?????????? ??????????????", "Tax No", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtFromAccNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtFromAccName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    txtFromAccName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
            }
            else
            {
                txtFromAccNo.Text = "";
                txtFromAccName.Text = "";
            }
        }
        private void button_SrchAccTo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("?????????? ", " No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("?????????? ????????", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("?????????? ??????????????????", "English Name", ifDefault: true, ""));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("????????????", "Mobile", ifDefault: false, ""));
            columns_Names_visible.Add("TaxNo", new ColumnDictinary("?????????? ??????????????", "Tax No", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "AccDefID_Setting";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtIntoAccNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtIntoAccName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    txtIntoAccName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
            }
            else
            {
                txtIntoAccNo.Text = "";
                txtIntoAccName.Text = "";
            }
        }
        private void button_SrchLegNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("Mnd_No", new ColumnDictinary("?????? ??????????????", "Commissary No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("?????????? ????????", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("?????????? ??????????????????", "English Name", ifDefault: true, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_Mndob";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtLegateNo.Text = db.StockMndob(frm.Serach_No).Mnd_ID.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtLegateName.Text = db.StockMndob(frm.Serach_No).Arb_Des.ToString();
                }
                else
                {
                    txtLegateName.Text = db.StockMndob(frm.Serach_No).Eng_Des.ToString();
                }
            }
            else
            {
                txtLegateNo.Text = "";
                txtLegateName.Text = "";
            }
        }
        private void button_SrchCostNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("Cst_No", new ColumnDictinary("??????????", "No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("?????????? ????????", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("?????????? ??????????????????", "English Name", ifDefault: true, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_CstTbl";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtCostCNo.Text = db.StockCst(frm.Serach_No).Cst_ID.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtCostCName.Text = db.StockCst(frm.Serach_No).Arb_Des.ToString();
                }
                else
                {
                    txtCostCName.Text = db.StockCst(frm.Serach_No).Eng_Des.ToString();
                }
            }
            else
            {
                txtCostCNo.Text = "";
                txtCostCName.Text = "";
            }
        }
        private void button_SrchUsrNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("UsrNo", new ColumnDictinary("?????? ????????????????", "User No", ifDefault: true, ""));
            columns_Names_visible.Add("UsrNamA", new ColumnDictinary("?????????? ????????", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("UsrNamE", new ColumnDictinary("?????????? ??????????????????", "English Name", ifDefault: true, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_User";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtUserNo.Text = dbc.StockUser(frm.Serach_No).UsrNo;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtUserName.Text = dbc.StockUser(frm.Serach_No).UsrNamA.ToString();
                }
                else
                {
                    txtUserName.Text = dbc.StockUser(frm.Serach_No).UsrNamE.ToString();
                }
            }
            else
            {
                txtUserNo.Text = "";
                txtUserName.Text = "";
            }
        }
    }
}
