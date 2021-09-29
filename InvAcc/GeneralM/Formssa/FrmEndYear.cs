using C1.Win.C1FlexGrid;
using Check_Data.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Library.RepShow;
using Microsoft.Win32;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmEndYear : Form
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
        private TextBoxX textBox_EndsPath;
        private Label label25;
        private CheckBoxX chk4;
        private CheckBoxX chk5;
        private CheckBoxX chk1;
        private CheckBoxX chk2;
        private CheckBoxX chk3;
        private GroupBox groupBox_Options;
        private ButtonX ButExit;
        private ButtonX ButOk;
        private CheckBoxX chk6;
        private Label label2;
        private Label label1;
        private IntegerInput txtDateAlarm;
        private Label label3;
        private ComboBoxEx CmbCurr;
        private CheckBoxX chk7;
        public DoubleInput txtTotalPointReturn;
        public DoubleInput txtTotalPointAvalible;
        public DoubleInput txtTotalPointUsed;
        public DoubleInput txtTotalPointAll;
        private IntegerInput txtDateMonth;
        private IntegerInput txtDateDay;
        private Label label5;
        private C1FlexGrid FlexType;
        private SwitchButton switchButton_CloseOption;
        private int LangArEn = 0;
        private string WherTmp = "";
        private string _Year;
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbRate;
        private TmpTbl data_this;
        private T_GDHEAD data_this_GH;
        private T_GDDET data_this_GD;
        private T_INVDET data_this_InvD;
        private T_INVHED data_this_InvH;
        private string cMainPath;
        private bool StopClose;
        private HijriGreg.HijriGregDates n;
        private double TotM;
        private double TotQty;
        private double TotQtyAm;
        private bool _IsHij;
        private string dateLimit;
        private string dateLimit_OtherOptions;
        private List<T_GdAuto> listGdAuto;
        private T_GdAuto _GdAuto;
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
                if (dbRate == null)
                {
                    dbRate = new Rate_DataDataContext(VarGeneral.BranchRt);
                }
                return dbRate;
            }
        }
        public TmpTbl DataThis
        {
            get
            {
                return data_this;
            }
            set
            {
                data_this = value;
            }
        }
        public T_GDHEAD DataThis_GH
        {
            get
            {
                return data_this_GH;
            }
            set
            {
                data_this_GH = value;
            }
        }
        public T_GDDET DataThis_GD
        {
            get
            {
                return data_this_GD;
            }
            set
            {
                data_this_GD = value;
            }
        }
        public T_INVDET DataThis_InvD
        {
            get
            {
                return data_this_InvD;
            }
            set
            {
                data_this_InvD = value;
            }
        }
        public T_INVHED DataThis_InvH
        {
            get
            {
                return data_this_InvH;
            }
            set
            {
                data_this_InvH = value;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEndYear));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.switchButton_CloseOption = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDateMonth = new DevComponents.Editors.IntegerInput();
            this.txtDateDay = new DevComponents.Editors.IntegerInput();
            this.txtTotalPointReturn = new DevComponents.Editors.DoubleInput();
            this.txtTotalPointAvalible = new DevComponents.Editors.DoubleInput();
            this.txtTotalPointUsed = new DevComponents.Editors.DoubleInput();
            this.txtTotalPointAll = new DevComponents.Editors.DoubleInput();
            this.CmbCurr = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDateAlarm = new DevComponents.Editors.IntegerInput();
            this.ButOk = new DevComponents.DotNetBar.ButtonX();
            this.groupBox_Options = new System.Windows.Forms.GroupBox();
            this.chk7 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chk6 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk4 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk5 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk3 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.textBox_EndsPath = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label25 = new System.Windows.Forms.Label();
            this.ButExit = new DevComponents.DotNetBar.ButtonX();
            this.FlexType = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.ribbonBar1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPointReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPointAvalible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPointUsed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPointAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateAlarm)).BeginInit();
            this.groupBox_Options.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlexType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelSpecialContainer
            // 
            this.PanelSpecialContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelSpecialContainer.Name = "PanelSpecialContainer";
            this.PanelSpecialContainer.Size = new System.Drawing.Size(200, 100);
            this.PanelSpecialContainer.TabIndex = 0;
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
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.panel1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(572, 370);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 1103;
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
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.switchButton_CloseOption);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtDateMonth);
            this.panel1.Controls.Add(this.txtDateDay);
            this.panel1.Controls.Add(this.txtTotalPointReturn);
            this.panel1.Controls.Add(this.txtTotalPointAvalible);
            this.panel1.Controls.Add(this.txtTotalPointUsed);
            this.panel1.Controls.Add(this.txtTotalPointAll);
            this.panel1.Controls.Add(this.CmbCurr);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtDateAlarm);
            this.panel1.Controls.Add(this.ButOk);
            this.panel1.Controls.Add(this.groupBox_Options);
            this.panel1.Controls.Add(this.textBox_EndsPath);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.ButExit);
            this.panel1.Controls.Add(this.FlexType);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(572, 353);
            this.panel1.TabIndex = 0;
            // 
            // switchButton_CloseOption
            // 
            this.switchButton_CloseOption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.switchButton_CloseOption.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_CloseOption.Location = new System.Drawing.Point(10, 88);
            this.switchButton_CloseOption.Name = "switchButton_CloseOption";
            this.switchButton_CloseOption.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77)))));
            this.switchButton_CloseOption.OffText = "إقفال جميع الفروع";
            this.switchButton_CloseOption.OffTextColor = System.Drawing.Color.White;
            this.switchButton_CloseOption.OnText = "تحديد الفروع";
            this.switchButton_CloseOption.Size = new System.Drawing.Size(179, 29);
            this.switchButton_CloseOption.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_CloseOption.TabIndex = 6750;
            this.switchButton_CloseOption.ValueChanged += new System.EventHandler(this.switchButton_CloseOption_ValueChanged);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(9, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(553, 27);
            this.label5.TabIndex = 6747;
            this.label5.Text = "طريقة الإقفــــال";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDateMonth
            // 
            this.txtDateMonth.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtDateMonth.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtDateMonth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDateMonth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDateMonth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtDateMonth.DisplayFormat = "0";
            this.txtDateMonth.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDateMonth.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtDateMonth.IsInputReadOnly = true;
            this.txtDateMonth.Location = new System.Drawing.Point(321, 33);
            this.txtDateMonth.LockUpdateChecked = false;
            this.txtDateMonth.MinValue = 0;
            this.txtDateMonth.Name = "txtDateMonth";
            this.txtDateMonth.Size = new System.Drawing.Size(46, 21);
            this.txtDateMonth.TabIndex = 6745;
            this.txtDateMonth.Value = 12;
            // 
            // txtDateDay
            // 
            this.txtDateDay.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtDateDay.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtDateDay.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDateDay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDateDay.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtDateDay.DisplayFormat = "0";
            this.txtDateDay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDateDay.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtDateDay.IsInputReadOnly = true;
            this.txtDateDay.Location = new System.Drawing.Point(370, 33);
            this.txtDateDay.LockUpdateChecked = false;
            this.txtDateDay.MinValue = 0;
            this.txtDateDay.Name = "txtDateDay";
            this.txtDateDay.ShowCheckBox = true;
            this.txtDateDay.Size = new System.Drawing.Size(46, 21);
            this.txtDateDay.TabIndex = 6744;
            this.txtDateDay.Value = 31;
            this.txtDateDay.LockUpdateChanged += new System.EventHandler(this.txtDateDay_LockUpdateChanged);
            // 
            // txtTotalPointReturn
            // 
            this.txtTotalPointReturn.AllowEmptyState = false;
            this.txtTotalPointReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTotalPointReturn.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotalPointReturn.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotalPointReturn.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotalPointReturn.DisplayFormat = "0.00";
            this.txtTotalPointReturn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalPointReturn.Increment = 0D;
            this.txtTotalPointReturn.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTotalPointReturn.IsInputReadOnly = true;
            this.txtTotalPointReturn.Location = new System.Drawing.Point(278, -49);
            this.txtTotalPointReturn.Name = "txtTotalPointReturn";
            this.txtTotalPointReturn.Size = new System.Drawing.Size(137, 21);
            this.txtTotalPointReturn.TabIndex = 6743;
            this.txtTotalPointReturn.Visible = false;
            // 
            // txtTotalPointAvalible
            // 
            this.txtTotalPointAvalible.AllowEmptyState = false;
            this.txtTotalPointAvalible.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTotalPointAvalible.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotalPointAvalible.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotalPointAvalible.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotalPointAvalible.DisplayFormat = "0.00";
            this.txtTotalPointAvalible.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalPointAvalible.Increment = 0D;
            this.txtTotalPointAvalible.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTotalPointAvalible.IsInputReadOnly = true;
            this.txtTotalPointAvalible.Location = new System.Drawing.Point(278, -26);
            this.txtTotalPointAvalible.Name = "txtTotalPointAvalible";
            this.txtTotalPointAvalible.Size = new System.Drawing.Size(137, 21);
            this.txtTotalPointAvalible.TabIndex = 6742;
            this.txtTotalPointAvalible.Visible = false;
            // 
            // txtTotalPointUsed
            // 
            this.txtTotalPointUsed.AllowEmptyState = false;
            this.txtTotalPointUsed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTotalPointUsed.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotalPointUsed.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotalPointUsed.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotalPointUsed.DisplayFormat = "0.00";
            this.txtTotalPointUsed.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalPointUsed.Increment = 0D;
            this.txtTotalPointUsed.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTotalPointUsed.IsInputReadOnly = true;
            this.txtTotalPointUsed.Location = new System.Drawing.Point(278, -72);
            this.txtTotalPointUsed.Name = "txtTotalPointUsed";
            this.txtTotalPointUsed.Size = new System.Drawing.Size(137, 21);
            this.txtTotalPointUsed.TabIndex = 6741;
            this.txtTotalPointUsed.Visible = false;
            // 
            // txtTotalPointAll
            // 
            this.txtTotalPointAll.AllowEmptyState = false;
            this.txtTotalPointAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTotalPointAll.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotalPointAll.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotalPointAll.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotalPointAll.DisplayFormat = "0.00";
            this.txtTotalPointAll.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalPointAll.Increment = 0D;
            this.txtTotalPointAll.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTotalPointAll.IsInputReadOnly = true;
            this.txtTotalPointAll.Location = new System.Drawing.Point(278, -95);
            this.txtTotalPointAll.Name = "txtTotalPointAll";
            this.txtTotalPointAll.Size = new System.Drawing.Size(137, 21);
            this.txtTotalPointAll.TabIndex = 6740;
            this.txtTotalPointAll.Visible = false;
            // 
            // CmbCurr
            // 
            this.CmbCurr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbCurr.DisplayMember = "Text";
            this.CmbCurr.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbCurr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCurr.Enabled = false;
            this.CmbCurr.FormattingEnabled = true;
            this.CmbCurr.ItemHeight = 14;
            this.CmbCurr.Location = new System.Drawing.Point(194, 282);
            this.CmbCurr.Name = "CmbCurr";
            this.CmbCurr.Size = new System.Drawing.Size(368, 20);
            this.CmbCurr.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbCurr.TabIndex = 6739;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(418, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 21);
            this.label3.TabIndex = 941;
            this.label3.Text = "السنــــــة";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDateAlarm
            // 
            this.txtDateAlarm.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtDateAlarm.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtDateAlarm.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDateAlarm.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDateAlarm.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtDateAlarm.DisplayFormat = "0";
            this.txtDateAlarm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDateAlarm.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtDateAlarm.Location = new System.Drawing.Point(9, 33);
            this.txtDateAlarm.MinValue = 0;
            this.txtDateAlarm.Name = "txtDateAlarm";
            this.txtDateAlarm.Size = new System.Drawing.Size(309, 21);
            this.txtDateAlarm.TabIndex = 940;
            this.txtDateAlarm.Leave += new System.EventHandler(this.txtDateAlarm_Leave);
            // 
            // ButOk
            // 
            this.ButOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButOk.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.ButOk.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButOk.Location = new System.Drawing.Point(194, 309);
            this.ButOk.Name = "ButOk";
            this.ButOk.Size = new System.Drawing.Size(368, 36);
            this.ButOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButOk.Symbol = "";
            this.ButOk.SymbolSize = 16F;
            this.ButOk.TabIndex = 1;
            this.ButOk.Text = "إقفـــال";
            this.ButOk.TextColor = System.Drawing.Color.White;
            this.ButOk.Click += new System.EventHandler(this.ButOk_Click);
            // 
            // groupBox_Options
            // 
            this.groupBox_Options.AutoSize = true;
            this.groupBox_Options.Controls.Add(this.chk7);
            this.groupBox_Options.Controls.Add(this.label2);
            this.groupBox_Options.Controls.Add(this.label1);
            this.groupBox_Options.Controls.Add(this.chk6);
            this.groupBox_Options.Controls.Add(this.chk4);
            this.groupBox_Options.Controls.Add(this.chk5);
            this.groupBox_Options.Controls.Add(this.chk1);
            this.groupBox_Options.Controls.Add(this.chk2);
            this.groupBox_Options.Controls.Add(this.chk3);
            this.groupBox_Options.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox_Options.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupBox_Options.Location = new System.Drawing.Point(194, 82);
            this.groupBox_Options.Name = "groupBox_Options";
            this.groupBox_Options.Size = new System.Drawing.Size(368, 201);
            this.groupBox_Options.TabIndex = 938;
            this.groupBox_Options.TabStop = false;
            this.groupBox_Options.Text = "خيارات الإقفال";
            // 
            // chk7
            // 
            this.chk7.AutoSize = true;
            this.chk7.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk7.Checked = true;
            this.chk7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk7.CheckValue = "Y";
            this.chk7.Location = new System.Drawing.Point(176, 95);
            this.chk7.Name = "chk7";
            this.chk7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk7.Size = new System.Drawing.Size(164, 15);
            this.chk7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk7.TabIndex = 941;
            this.chk7.Text = "نقل النقاط العملاء المستحقة";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(77, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 12);
            this.label2.TabIndex = 940;
            this.label2.Text = "[ الإيرادات - المصروفات ]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(164, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 12);
            this.label1.TabIndex = 939;
            this.label1.Text = "[ الميزانية ]";
            // 
            // chk6
            // 
            this.chk6.AutoSize = true;
            this.chk6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk6.Location = new System.Drawing.Point(183, 71);
            this.chk6.Name = "chk6";
            this.chk6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk6.Size = new System.Drawing.Size(156, 15);
            this.chk6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk6.TabIndex = 938;
            this.chk6.Text = "نقل أرصدة الأرباح والخسائر";
            this.chk6.CheckedChanged += new System.EventHandler(this.chk6_CheckedChanged);
            // 
            // chk4
            // 
            this.chk4.AutoSize = true;
            this.chk4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk4.Location = new System.Drawing.Point(192, 119);
            this.chk4.Name = "chk4";
            this.chk4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk4.Size = new System.Drawing.Size(148, 15);
            this.chk4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk4.TabIndex = 936;
            this.chk4.Text = "مسح جميع بيانات الفندق";
            this.chk4.Visible = false;
            this.chk4.CheckedChanged += new System.EventHandler(this.chk4_CheckedChanged);
            // 
            // chk5
            // 
            this.chk5.AutoSize = true;
            this.chk5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk5.Location = new System.Drawing.Point(107, 167);
            this.chk5.Name = "chk5";
            this.chk5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk5.Size = new System.Drawing.Size(231, 15);
            this.chk5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk5.TabIndex = 937;
            this.chk5.Text = "حذف حسابات النـــزلاء الذين ارصدتهم صفر";
            this.chk5.Visible = false;
            // 
            // chk1
            // 
            this.chk1.AutoSize = true;
            this.chk1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk1.Checked = true;
            this.chk1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk1.CheckValue = "Y";
            this.chk1.Location = new System.Drawing.Point(215, 47);
            this.chk1.Name = "chk1";
            this.chk1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk1.Size = new System.Drawing.Size(125, 15);
            this.chk1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk1.TabIndex = 4;
            this.chk1.Text = "نقل أرصدة الحسابات ";
            // 
            // chk2
            // 
            this.chk2.AutoSize = true;
            this.chk2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk2.Checked = true;
            this.chk2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk2.CheckValue = "Y";
            this.chk2.Location = new System.Drawing.Point(68, 23);
            this.chk2.Name = "chk2";
            this.chk2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk2.Size = new System.Drawing.Size(268, 15);
            this.chk2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk2.TabIndex = 5;
            this.chk2.Text = "نقل الكميات الى السنة الجديدة كبضاعة أول المدة";
            // 
            // chk3
            // 
            this.chk3.AutoSize = true;
            this.chk3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk3.Location = new System.Drawing.Point(73, 143);
            this.chk3.Name = "chk3";
            this.chk3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk3.Size = new System.Drawing.Size(263, 15);
            this.chk3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk3.TabIndex = 935;
            this.chk3.Text = "مسح جميع بيانات الفندق | النزلاء المغادرين فقط";
            this.chk3.Visible = false;
            this.chk3.CheckedChanged += new System.EventHandler(this.chk3_CheckedChanged);
            // 
            // textBox_EndsPath
            // 
            this.textBox_EndsPath.BackColor = System.Drawing.SystemColors.ActiveCaption;
            // 
            // 
            // 
            this.textBox_EndsPath.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textBox_EndsPath.Border.BorderBottomWidth = 1;
            this.textBox_EndsPath.Border.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBox_EndsPath.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textBox_EndsPath.Border.BorderLeftWidth = 1;
            this.textBox_EndsPath.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textBox_EndsPath.Border.BorderRightWidth = 1;
            this.textBox_EndsPath.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textBox_EndsPath.Border.BorderTopWidth = 1;
            this.textBox_EndsPath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_EndsPath.Font = new System.Drawing.Font("Tahoma", 6.75F);
            this.textBox_EndsPath.ForeColor = System.Drawing.Color.White;
            this.textBox_EndsPath.Location = new System.Drawing.Point(9, 55);
            this.textBox_EndsPath.Multiline = true;
            this.textBox_EndsPath.Name = "textBox_EndsPath";
            this.textBox_EndsPath.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_EndsPath, false);
            this.textBox_EndsPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_EndsPath.Size = new System.Drawing.Size(407, 22);
            this.textBox_EndsPath.TabIndex = 6;
            this.textBox_EndsPath.WatermarkColor = System.Drawing.Color.White;
            this.textBox_EndsPath.Click += new System.EventHandler(this.textBox_EndsPath_Click);
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label25.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label25.Location = new System.Drawing.Point(418, 56);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(144, 21);
            this.label25.TabIndex = 932;
            this.label25.Text = "مسار الإقفـــــال";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ButExit
            // 
            this.ButExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButExit.Checked = true;
            this.ButExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ButExit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButExit.Location = new System.Drawing.Point(6, 309);
            this.ButExit.Name = "ButExit";
            this.ButExit.Size = new System.Drawing.Size(182, 36);
            this.ButExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButExit.Symbol = "";
            this.ButExit.SymbolSize = 16F;
            this.ButExit.TabIndex = 3;
            this.ButExit.Text = "خـــروج";
            this.ButExit.TextColor = System.Drawing.Color.Black;
            this.ButExit.Click += new System.EventHandler(this.ButExit_Click);
            // 
            // FlexType
            // 
            this.FlexType.AllowEditing = false;
            this.FlexType.BackColor = System.Drawing.Color.White;
            this.FlexType.ColumnInfo = resources.GetString("FlexType.ColumnInfo");
            this.FlexType.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FlexType.Location = new System.Drawing.Point(9, 121);
            this.FlexType.Name = "FlexType";
            this.FlexType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FlexType.Rows.Count = 1;
            this.FlexType.Rows.DefaultSize = 19;
            this.FlexType.Rows.Fixed = 0;
            this.FlexType.Size = new System.Drawing.Size(179, 182);
            this.FlexType.StyleInfo = resources.GetString("FlexType.StyleInfo");
            this.FlexType.TabIndex = 6748;
            this.FlexType.Tag = " T_INVHED.InvCashPay ";
            this.FlexType.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System;
            // 
            // netResize1
            // 
            this.netResize1.ParentControl = this;
            // 
            // FrmEndYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 370);
            this.Controls.Add(this.ribbonBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmEndYear";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إقفال السنـــــة";
            this.Load += new System.EventHandler(this.FrmEndYear_Load);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmEndYear_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmEndYear_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmEndYear_KeyUp);
            this.ribbonBar1.ResumeLayout(false);
            this.ribbonBar1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPointReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPointAvalible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPointUsed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPointAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateAlarm)).EndInit();
            this.groupBox_Options.ResumeLayout(false);
            this.groupBox_Options.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlexType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);

        }
        private int CalculateSupport()
        {
            try
            {
                RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\MrdSoft\\Register", writable: true);
                string regval = "";
                string DT_H = "";
                try
                {
                    regval = n.FormatGreg(hKey.GetValue("DTBackup").ToString(), "yyyy/MM/dd");
                    DT_H = n.GregToHijri(regval);
                }
                catch
                {
                    regval = "";
                    DT_H = "";
                }
                if (!VarGeneral.CheckDate(regval))
                {
                    return 0;
                }
                if (Convert.ToDateTime(VarGeneral.Hdate) > Convert.ToDateTime(n.FormatHijri(DT_H, "yyyy/MM/dd")))
                {
                    return 0;
                }
                return n.vDiff(n.FormatHijri(DT_H, "yyyy/MM/dd"), VarGeneral.Hdate);
            }
            catch
            {
                return 0;
            }
        }
        public FrmEndYear()
        {
            int? calendr = VarGeneral.Settings_Sys.Calendr;
            _Year = ((calendr.Value == 0 && calendr.HasValue) ? VarGeneral.Gdate.Substring(0, 4) : VarGeneral.Hdate.Substring(0, 4));
            cMainPath = "";
            StopClose = false;
            n = new HijriGreg.HijriGregDates();
            TotM = 0.0;
            TotQty = 0.0;
            TotQtyAm = 0.0;
            _IsHij = false;
            dateLimit = "";
            dateLimit_OtherOptions = "";
            listGdAuto = new List<T_GdAuto>();
            _GdAuto = new T_GdAuto();
            //	base._002Ector();
            InitializeComponent();
            RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
            if (!(VarGeneral.gUserName != "runsetting"))
            {
                return;
            }
            long regval = 0L;
            if (hKey == null)
            {
                return;
            }
            try
            {
                object q = hKey.GetValue("vRemotly");
                if (string.IsNullOrEmpty(q.ToString()))
                {
                    hKey.CreateSubKey("vRemotly");
                    hKey.SetValue("vRemotly", "0");
                }
            }
            catch
            {
                hKey.CreateSubKey("vRemotly");
                hKey.SetValue("vRemotly", "0");
            }
            regval = long.Parse(hKey.GetValue("vRemotly").ToString());
        }
        public void FillCombo()
        {
            List<T_Curency> listCurr = new List<T_Curency>(db.T_Curencies.Select((T_Curency item) => item).ToList());
            listCurr.Insert(0, new T_Curency());
            CmbCurr.DataSource = listCurr;
            CmbCurr.DisplayMember = ((LangArEn == 0) ? "Arb_Des" : "Eng_Des");
            CmbCurr.ValueMember = "Curency_ID";
            CmbCurr.SelectedIndex = 0;
            try
            {
                CmbCurr.SelectedValue = int.Parse(VarGeneral.Settings_Sys.ImportIp.ToString());
            }
            catch
            {
            }
            List<T_Branch> listBranch = new List<T_Branch>(dbc.T_Branches.Select((T_Branch item) => item).ToList());
            FlexType.Rows.Count = listBranch.Count;
            for (int i = 0; i < listBranch.Count; i++)
            {
                FlexType.SetData(i, 0, true);
                FlexType.SetData(i, 1, (LangArEn == 0) ? listBranch[i].Branch_Name : listBranch[i].Branch_NameE);
                FlexType.SetData(i, 2, listBranch[i].Branch_no);
            }
        }
        private void FrmEndYear_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmEndYear));
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
                if (VarGeneral.SSSLev == "M")
                {
                    chk1.Visible = false;
                    label1.Visible = false;
                    label2.Visible = false;
                    chk6.Visible = false;
                    chk7.Location = new Point(chk2.Location.X, chk1.Location.Y);
                }
                else if (VarGeneral.SSSTyp == 1)
                {
                    chk2.Visible = false;
                    chk7.Visible = false;
                }
                if (VarGeneral.SSSLev == "H" || VarGeneral.SSSLev == "X")
                {
                    chk4.Visible = true;
                    chk5.Visible = true;
                    chk3.Visible = true;
                    chk5.Checked = true;
                    chk3.Checked = true;
                }
                if (VarGeneral.Settings_Sys.Calendr == 1)
                {
                    txtDateDay.Value = 30;
                }
                txtDateDay_LockUpdateChanged(sender, e);
                chk3_CheckedChanged(sender, e);
                FillCombo();
                RibunButtons();
                txtDateAlarm.Text = _Year;
                GET_Path();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void GET_Path()
        {
            cMainPath = "";
            List<int> vDB = dbc.ExecuteQuery<int>("SELECT database_id FROM sys.databases WHERE name='" + VarGeneral.DBNo + "'", new object[0]).ToList();
            int vDB_ID = vDB.First();
            try
            {
                if (vDB_ID <= 0)
                {
                    return;
                }
                List<string> vRecPath = dbc.ExecuteQuery<string>("SELECT physical_name FROM sys.master_files WHERE type = 0 and database_id=" + vDB_ID, new object[0]).ToList();
                if (vRecPath.Count > 0)
                {
                    if (!Directory.Exists(vRecPath.First().Replace(VarGeneral.DBNo + ".mdf", null) + VarGeneral.DBNo.Replace(".mdf", null).Replace("DBPROSOFT", "DBEndYear_" + _Year)))
                    {
                        Directory.CreateDirectory(vRecPath.First().Replace(VarGeneral.DBNo + ".mdf", null) + VarGeneral.DBNo.Replace("DBPROSOFT", "DBEndYear_" + _Year));
                    }
                    textBox_EndsPath.Text = vRecPath.First().Replace(VarGeneral.DBNo + ".mdf", null) + VarGeneral.DBNo.Replace("DBPROSOFT", "DBEndYear_" + _Year) + "\\DBEndYear_" + _Year + ".lck";
                    cMainPath = vRecPath.First().Replace(VarGeneral.DBNo + ".mdf", null) + VarGeneral.DBNo.Replace("DBPROSOFT", "DBEndYear_" + _Year);
                }
            }
            catch
            {
                textBox_EndsPath.Text = "";
                cMainPath = "";
            }
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ButOk.Text = "إقفـــال F2";
                ButExit.Text = "خـــروج Esc";
                label25.Text = "مسار الإقفـــــال :";
                groupBox_Options.Text = "خيارات الإقفـــــال";
                switchButton_CloseOption.OffText = "إقفال جميع الفروع";
                switchButton_CloseOption.OnText = "تحديد الفروع";
                Text = "إقفال السنـــــة";
            }
            else
            {
                ButOk.Text = "OK F2";
                ButExit.Text = "Exit Esc";
                label25.Text = "Closing Track :";
                groupBox_Options.Text = "Options";
                switchButton_CloseOption.OffText = "Close All Branches";
                switchButton_CloseOption.OnText = "Selecte Branches";
                Text = "The closure of the year";
            }
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmEndYear));
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
            RibunButtons();
        }
        private void DBMain(string BackupPath)
        {
            string CmdText = " BACKUP DATABASE " + VarGeneral.DBNo + " TO DISK='{0}' WITH NOFORMAT, NOINIT, NAME = N'MyDB-FullBackup, SKIP, NOREWIND, NOUNLOAD, STATS = 10'";
            CmdText = string.Format(CmdText, BackupPath);
            db.ExecuteCommand(CmdText);
        }
        private void SSSBackup(string vPaths)
        {
            try
            {
                StopClose = false;
                string BackupPath = ((!switchButton_CloseOption.Value) ? vPaths : (vPaths + "_" + VarGeneral.BranchNumber));
                if (!switchButton_CloseOption.Value)
                {
                    goto IL_0095;
                }
                if (!File.Exists(BackupPath))
                {
                    goto IL_008c;
                }
                if (MessageBox.Show((LangArEn == 0) ? "يوجد ملف تم اقفاله بنفس الإسم في مسار الإقفال هل تريد الكتابة عليه ؟ ..!" : "There have been closing file with the same name in the course of closing Do you want to write it !", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                {
                    StopClose = true;
                    return;
                }
                File.Delete(BackupPath);
                goto IL_008c;
            IL_008c:
                DBMain(BackupPath);
                goto IL_0095;
            IL_0095:
                string CmdText = " BACKUP DATABASE " + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber + " TO DISK='{0}' WITH NOFORMAT, NOINIT, NAME = N'MyDB-FullBackup, SKIP, NOREWIND, NOUNLOAD, STATS = 10'";
                CmdText = string.Format(CmdText, BackupPath);
                db.ExecuteCommand(CmdText);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("ButBackUp_Click:", error, enable: true);
                MessageBox.Show((LangArEn == 0) ? "يرحى التأكد من المسار\n لم تتم عملية النسخ الاحتياطي بنجاح..  " : "Is not the backup process successfully .. Check Path", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void DBBackup(string Dpth)
        {
            try
            {
                SSSBackup(Dpth);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("ButBackUp_Click:", error, enable: true);
                MessageBox.Show((LangArEn == 0) ? "يرحى التأكد من المسار\n لم تتم عملية النسخ الاحتياطي بنجاح..  " : "Is not the backup process successfully .. Check Path", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void textBox_EndsPath_Click(object sender, EventArgs e)
        {
            textBox_EndsPath.SelectAll();
        }
        private void DBBackupElectronic(string tPath)
        {
            string _oldDBNo = VarGeneral.DBNo;
            try
            {
                if (VarGeneral.vEndYears)
                {
                    return;
                }
                List<string> _DBNo = new List<string>();
                using (Rate_DataDataContext _db = new Rate_DataDataContext("Server=" + VarGeneral.gServerName + ";Database=;UID=" + VarGeneral.UsrName + ";PWD=" + VarGeneral.UsrPass))
                {
                    _DBNo = _db.ExecuteQuery<string>("select name From master..sysdatabases Where name like 'DBPROSOFT_%' and name not like '%_Endsyr_%' order by name ", new object[0]).ToList();
                }
                for (int iiCnt = 0; iiCnt < _DBNo.Count; iiCnt++)
                {
                    string BackupPath = tPath;
                    VarGeneral.DBNo = _DBNo[iiCnt];
                    try
                    {
                        List<string> FileBackup = new List<string>();
                        string filepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        DirectoryInfo d = new DirectoryInfo(BackupPath);
                        FileInfo[] files = d.GetFiles("*.bak");
                        foreach (FileInfo file in files)
                        {
                            if (file.Name.StartsWith(VarGeneral.DBNo))
                            {
                                FileBackup.Add(file.FullName);
                            }
                        }
                        FileBackup.Sort();
                        for (int i = 0; i < FileBackup.Count; i++)
                        {
                            if (FileBackup.Count <= 4)
                            {
                                break;
                            }
                            if (File.Exists(FileBackup[i]))
                            {
                                File.Delete(FileBackup[i]);
                                FileBackup.RemoveAt(i);
                            }
                        }
                    }
                    catch
                    {
                    }
                    int? calendr = VarGeneral.Settings_Sys.Calendr;
                    if (calendr.Value == 0 && calendr.HasValue)
                    {
                        object obj2 = BackupPath;
                        BackupPath = string.Concat(obj2, "\\", VarGeneral.DBNo, "_", VarGeneral.Gdate.Substring(0, 4), "_", VarGeneral.Gdate.Substring(5, 2), "_", VarGeneral.Gdate.Substring(8, 2), "_", DateTime.Now.Hour, "_", DateTime.Now.Minute, "_", DateTime.Now.Second, ".bak");
                    }
                    else
                    {
                        object obj2 = BackupPath;
                        BackupPath = string.Concat(obj2, "\\", VarGeneral.DBNo, "_", VarGeneral.Hdate.Substring(0, 4), "_", VarGeneral.Hdate.Substring(5, 2), "_", VarGeneral.Hdate.Substring(8, 2), "_", DateTime.Now.Hour, "_", DateTime.Now.Minute, "_", DateTime.Now.Second, ".bak");
                    }
                    string CmdText = " BACKUP DATABASE " + VarGeneral.DBNo + " TO DISK='{0}' WITH NOFORMAT, NOINIT, NAME = N'MyDB-FullBackup, SKIP, NOREWIND, NOUNLOAD, STATS = 10'";
                    CmdText = string.Format(CmdText, BackupPath);
                    db.ExecuteCommand(CmdText);
                    SSSBackupElectroinc(BackupPath);
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("ButBackUp_Click:", error, enable: true);
            }
            VarGeneral.DBNo = _oldDBNo;
        }
        private void SSSBackupElectroinc(string vPaths)
        {
            try
            {
                List<T_Branch> vBranchCount = dbc.FillBranch_2("").ToList();
                for (int i = 0; i < vBranchCount.Count; i++)
                {
                    try
                    {
                        string CmdText = " BACKUP DATABASE " + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + vBranchCount[i].Branch_no + " TO DISK='{0}' WITH NOFORMAT, NOINIT, NAME = N'MyDB-FullBackup, SKIP, NOREWIND, NOUNLOAD, STATS = 10'";
                        CmdText = string.Format(CmdText, vPaths);
                        db.ExecuteCommand(CmdText);
                    }
                    catch
                    {
                    }
                }
                dbInstance = null;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("ButBackUp_Click:", error, enable: true);
            }
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("يجب التأكد من ان جميع مستخدمين البرنامج في الخارج  \n هل تريد الأستمرار ? ", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                {
                    return;
                }
                if (chk6.Checked && VarGeneral.UserID != 1)
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكنك نقل أرصدة الأرباح والخسائر الى السنة الجديدة .. يرجى التواصل مع الادارة  !" : "You can not transfer the balances of profits and losses to the new year .. Please communicate with the administration!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                List<string> brNo_list = new List<string>();
                for (int i = 0; i < FlexType.Rows.Count; i++)
                {
                    try
                    {
                        if (Convert.ToBoolean(FlexType.Rows[i][0].ToString()))
                        {
                            brNo_list.Add(FlexType.GetData(i, 2).ToString());
                        }
                    }
                    catch
                    {
                    }
                }
                if (brNo_list.Count <= 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "يجب تحديد فرع واحد على الأقل .. لكي يتم اتمام عملية الإقفال !" : "you should select one branch at lest", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                try
                {
                    _IsHij = n.IsHijri(txtDateAlarm.Value + "/" + txtDateMonth.Value + "/" + txtDateDay.Value);
                }
                catch
                {
                    MessageBox.Show((LangArEn == 0) ? "يرجى التأكد من تاريخ الإقفال والمحاولة مجددا  !" : "Please see the closing date and try again!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    _IsHij = false;
                    return;
                }
                if (txtDateDay.LockUpdateChecked && (chk1.Checked || chk2.Checked))
                {
                    dateLimit = txtDateAlarm.Value + "/" + txtDateMonth.Value + "/" + txtDateDay.Value;
                }
                else
                {
                    dateLimit = "";
                }
                if (txtDateDay.LockUpdateChecked && (chk7.Checked || chk4.Checked || chk3.Checked))
                {
                    dateLimit_OtherOptions = txtDateAlarm.Value + "/" + txtDateMonth.Value + "/" + txtDateDay.Value;
                }
                else
                {
                    dateLimit_OtherOptions = "";
                }
                string Dpth = textBox_EndsPath.Text;
                if (string.IsNullOrEmpty(Dpth))
                {
                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. لم يتمكن النظام من إيجاد مسار قاعدة البيانات التي سيتم اقفالها  !" : "Can not complete this process .. please Selected Path !", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                try
                {
                    if (Directory.Exists(cMainPath))
                    {
                        DirectoryInfo dinfo = new DirectoryInfo(cMainPath);
                        FileInfo[] Files = dinfo.GetFiles();
                        FileInfo[] array = Files;
                        foreach (FileInfo file in array)
                        {
                            if (!switchButton_CloseOption.Value)
                            {
                                if (file.FullName.Contains("lck_"))
                                {
                                    MessageBox.Show((LangArEn == 0) ? "لا يمكن اتمام هذه العملية .. فقد تم الإقفال سابقا حسب اختيار الفرع يرجى تحديد الفروع  وثم المحاولة مجددا  !" : "This operation can not be completed. It has already been closed", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    return;
                                }
                            }
                            else if (file.FullName.EndsWith(".lck"))
                            {
                                MessageBox.Show((LangArEn == 0) ? "فقد تم الإقفال سابقا بطريقة الإقفال الكامل للفروع  يرجى تفعيل خيار افقال جميع الفروع وثم المحاولة مجددا  !" : "Closed previously in full closing of branches Please activate the option to break all branches and then try again!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return;
                            }
                        }
                    }
                }
                catch
                {
                }
                if (!File.Exists(Dpth) || switchButton_CloseOption.Value)
                {
                    goto IL_04ad;
                }
                if (MessageBox.Show((LangArEn == 0) ? "يوجد ملف تم اقفاله بنفس الإسم في مسار الإقفال هل تريد الكتابة عليه ؟ ..!" : "There have been closing file with the same name in the course of closing Do you want to write it !", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                {
                    return;
                }
                File.Delete(Dpth);
                goto IL_04ad;
            IL_04ad:
                try
                {
                    int c4 = Dpth.Length - 1;
                    c4 = Dpth.Length - 1;
                    while (c4 <= Dpth.Length && !(Dpth.Substring(c4, 1) == "\\"))
                    {
                        c4--;
                    }
                    DBBackupElectronic(Dpth.Substring(0, c4));
                }
                catch (Exception error2)
                {
                    VarGeneral.DebLog.writeLog("AutoBackUp:", error2, enable: true);
                    MessageBox.Show(error2.Message);
                    return;
                }
                string BackupPath = Dpth;
                if (!switchButton_CloseOption.Value)
                {
                    DBMain(BackupPath);
                }
                List<T_Branch> q = dbc.FillBranch_2("").ToList();
                string OldBr = VarGeneral.BranchNumber;
                if (chk1.Checked)
                {
                    try
                    {
                        for (int i = 0; i < q.Count; i++)
                        {
                            VarGeneral.BranchNumber = q[i].Branch_no;
                            dbRate = null;
                            dbInstance = null;
                            _GdAuto = db.GdAutoStock();
                            T_AccDef newData = db.StockAccDefWithOutBalance(_GdAuto.Acc1.ToString());
                            if (newData == null || string.IsNullOrEmpty(newData.AccDef_No) || newData.AccDef_ID == 0 || _GdAuto.Acc1 == 0)
                            {
                                MessageBox.Show((LangArEn == 0) ? "حساب الأرباح والخسائر غير صحيح .. يرجى الرجوع الى شاشة تهيئة النظام والتأكد من ربط الحساب..!" : "Profit and loss account is not true .. Please refer to the system configuration screen and make sure the account link ..!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                VarGeneral.BranchNumber = OldBr;
                                dbRate = null;
                                dbInstance = null;
                                return;
                            }
                            newData = db.StockAccDefWithOutBalance(_GdAuto.Acc2.ToString());
                            if (newData == null || string.IsNullOrEmpty(newData.AccDef_No) || newData.AccDef_ID == 0 || _GdAuto.Acc2 == 0)
                            {
                                MessageBox.Show((LangArEn == 0) ? "حساب الأرباح والخسائر غير صحيح .. يرجى الرجوع الى شاشة تهيئة النظام والتأكد من ربط الحساب..!" : "Profit and loss account is not true .. Please refer to the system configuration screen and make sure the account link ..!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                VarGeneral.BranchNumber = OldBr;
                                dbRate = null;
                                dbInstance = null;
                                return;
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show((LangArEn == 0) ? "حساب الأرباح والخسائر غير صحيح .. يرجى الرجوع الى شاشة تهيئة النظام والتأكد من ربط الحساب..!" : "Profit and loss account is not true .. Please refer to the system configuration screen and make sure the account link ..!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        VarGeneral.BranchNumber = OldBr;
                        dbRate = null;
                        dbInstance = null;
                        return;
                    }
                }
                VarGeneral.BranchNumber = OldBr;
                string DefBr = VarGeneral.BranchNumber;
                int Counter = 0;
                List<T_AccDef> LAccDef;
                int iAcc;
                List<T_STKSQTY> vSTKQty;
                int vStk;
                int c3;
                int c2;
                int c;
                for (int i = 0; i < q.Count; i++)
                {
                    Counter = 1;
                    string Spth = "";
                    int vID = 0;
                    dbRate = null;
                    dbInstance = null;
                    VarGeneral.BranchNumber = q[i].Branch_no;
                    try
                    {
                        new FrmMain(null, null, VarGeneral.BranchNumber, 0);
                    }
                    catch
                    {
                    }
                    List<int> vRec = dbc.ExecuteQuery<int>("SELECT database_id FROM sys.databases WHERE name='" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber + "'", new object[0]).ToList();
                    vID = vRec.First();
                    if (vID > 0)
                    {
                        List<string> vRecPath = dbc.ExecuteQuery<string>("SELECT physical_name FROM sys.master_files WHERE type = 0 and database_id=" + vID, new object[0]).ToList();
                        if (vRecPath.Count > 0)
                        {
                            Spth = vRecPath.First().ToString();
                        }
                    }
                    if (!(Spth != ""))
                    {
                        continue;
                    }
                    if (!switchButton_CloseOption.Value)
                    {
                        SSSBackup(Dpth);
                    }
                    if (!(brNo_list.Find((string g) => g == VarGeneral.BranchNumber) == VarGeneral.BranchNumber))
                    {
                        continue;
                    }
                    if (switchButton_CloseOption.Value)
                    {
                        SSSBackup(Dpth);
                        if (StopClose)
                        {
                            continue;
                        }
                    }
                    db.ExecuteCommand("UPDATE T_SYSSETTING SET InvID = 1");
                    db.ExecuteCommand("UPDATE T_SYSSETTING SET GedID = 1");
                    db.ExecuteCommand("UPDATE T_INVSETTING SET InvNum = 1");
                    try
                    {
                        _RepairQty(RunDate: false, Genral: true);
                    }
                    catch
                    {
                    }
                    try
                    {
                        List<T_INVHED> j = db.T_INVHEDs.Where((T_INVHED t) => t.GDat.Trim().Length < 10 || t.HDat.Trim().Length < 10).ToList();
                        for (int l = 0; l < j.Count; l++)
                        {
                            try
                            {
                                db.ExecuteCommand("UPDATE [T_INVHED]  SET [T_INVHED].[GDat] ='" + Convert.ToDateTime(j[i].GDat).ToString("yyyy/MM/dd") + "' ,[T_INVHED].[HDat] ='" + Convert.ToDateTime(j[i].HDat).ToString("yyyy/MM/dd") + "' where T_INVHED.InvHed_ID = " + j[i].InvHed_ID);
                            }
                            catch
                            {
                            }
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        List<T_GDHEAD> k = db.T_GDHEADs.Where((T_GDHEAD t) => t.gdGDate.Trim().Length < 10 || t.gdHDate.Trim().Length < 10).ToList();
                        for (int l = 0; l < k.Count; l++)
                        {
                            try
                            {
                                db.ExecuteCommand("UPDATE [T_GDHEAD]  SET [T_GDHEAD].[gdGDate] ='" + Convert.ToDateTime(k[i].gdGDate).ToString("yyyy/MM/dd") + "' ,[T_GDHEAD].[gdHDate] ='" + Convert.ToDateTime(k[i].gdHDate).ToString("yyyy/MM/dd") + "' where T_GDHEAD.gdhead_ID = " + k[i].gdhead_ID);
                            }
                            catch
                            {
                            }
                        }
                    }
                    catch
                    {
                    }
                    if (VarGeneral.CheckDate(dateLimit))
                    {
                        _RepairQty(RunDate: true, Genral: false);
                        try
                        {
                            db.ExecuteCommand("UPDATE u SET u.RomeStatus = 0, u.waiterNo = NULL from T_Rooms u INNER JOIN  T_INVHED ON u.ID = T_INVHED.RoomNo where " + (_IsHij ? (" T_INVHED.HDat <= '" + dateLimit + "'") : (" T_INVHED.GDat <= '" + dateLimit + "'")));
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        try
                        {
                            db.ExecuteCommand("UPDATE [T_Rooms] SET [RomeStatus] = 0, [waiterNo] = NULL ");
                        }
                        catch
                        {
                        }
                    }
                    if (chk1.Checked)
                    {
                        _GdAuto = db.GdAutoStock();
                        T_AccDef newData = db.StockAccDefWithOutBalance(_GdAuto.Acc1.ToString());
                        if (newData == null || string.IsNullOrEmpty(newData.AccDef_No) || newData.AccDef_ID == 0 || _GdAuto.Acc1 == 0)
                        {
                            MessageBox.Show((LangArEn == 0) ? "حساب الأرباح والخسائر غير صحيح .. يرجى الرجوع الى شاشة تهيئة النظام والتأكد من ربط الحساب..!" : "Profit and loss account is not true .. Please refer to the system configuration screen and make sure the account link ..!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }
                        newData = db.StockAccDefWithOutBalance(_GdAuto.Acc2.ToString());
                        if (newData == null || string.IsNullOrEmpty(newData.AccDef_No) || newData.AccDef_ID == 0 || _GdAuto.Acc2 == 0)
                        {
                            MessageBox.Show((LangArEn == 0) ? "حساب الأرباح والخسائر غير صحيح .. يرجى الرجوع الى شاشة تهيئة النظام والتأكد من ربط الحساب..!" : "Profit and loss account is not true .. Please refer to the system configuration screen and make sure the account link ..!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }
                        Mezaniya(_GdAuto.Acc1, _GdAuto.Acc2);
                    }
                    else
                    {
                        db.ExecuteCommand("UPDATE T_AccDef SET  T_AccDef.Debit = 0,T_AccDef.Credit = 0,T_AccDef.Balance = 0 ");
                    }
                    if (chk7.Checked)
                    {
                        try
                        {
                            db.ExecuteCommand("Update [dbo].[T_AccDef] Set [TotPoints] = 0 WHERE [TotPoints] is null or [TotPoints] = ''");
                        }
                        catch
                        {
                        }
                        LAccDef = (from t in db.T_AccDefs
                                   where t.Lev == (int?)4 && t.AccCat == (int?)4 && t.Sts == (int?)0
                                   orderby t.AccDef_No
                                   select t).ToList();
                        iAcc = 0;
                        while (true)
                        {
                            if (iAcc >= LAccDef.Count)
                            {
                                break;
                            }
                            double totPointsIn = 0.0;
                            double totPointsOut = 0.0;
                            double totPoints = 0.0;
                            double _PointUseIn = 0.0;
                            double _PointUseOut = 0.0;
                            txtTotalPointAll.Value = 0.0;
                            txtTotalPointUsed.Value = 0.0;
                            txtTotalPointReturn.Value = 0.0;
                            txtTotalPointAvalible.Value = 0.0;
                            RepShow _RepShow = new RepShow();
                            _RepShow.Tables = " T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                            _RepShow.Rule = " Where " + ((!VarGeneral.CheckDate(dateLimit_OtherOptions)) ? " 1 = 1 " : (_IsHij ? (" T_INVHED.HDat <= '" + dateLimit_OtherOptions + "'") : (" T_INVHED.GDat <= '" + dateLimit_OtherOptions + "'"))) + " and T_Items.IsPoints = 1 and T_INVHED.InvTyp = 1  and  T_INVHED.IfDel != 1 and T_INVHED.IsPoints = 1 and CusVenNo = '" + LAccDef[iAcc].AccDef_No + "' and T_CATEGORY.TotalPurchaes > 0 and T_CATEGORY.TotalPoint > 0 group by T_items.ItmCat";
                            _RepShow.Fields = " sum (Round(T_InvDet.Amount,2)) as Amount,T_items.ItmCat ,case when  CONVERT(INT,(sum(Round(T_InvDet.Amount,2)) / (select T_CATEGORY.TotalPurchaes from T_CATEGORY where T_CATEGORY.CAT_ID = T_items.ItmCat))) * (select T_CATEGORY.TotalPoint from T_CATEGORY where T_CATEGORY.CAT_ID = T_items.ItmCat) > 0 then  CONVERT(INT,(sum(Round(T_InvDet.Amount,2)) / (select T_CATEGORY.TotalPurchaes from T_CATEGORY where T_CATEGORY.CAT_ID = T_items.ItmCat))) * (select T_CATEGORY.TotalPoint from T_CATEGORY where T_CATEGORY.CAT_ID = T_items.ItmCat) else 0 end as PointsCount ";
                            try
                            {
                                _RepShow = _RepShow.Save();
                                VarGeneral.RepData = _RepShow.RepData;
                            }
                            catch (Exception ex2)
                            {
                                MessageBox.Show(ex2.Message);
                            }
                            try
                            {
                                totPointsIn = LAccDef[iAcc].TotPoints.Value;
                            }
                            catch
                            {
                                totPointsIn = 0.0;
                            }
                            if (VarGeneral.RepData.Tables[0].Rows.Count > 0)
                            {
                                for (int cc = 0; cc < VarGeneral.RepData.Tables[0].Rows.Count; cc++)
                                {
                                    try
                                    {
                                        if (double.Parse(VarGeneral.TString.TEmpty(VarGeneral.RepData.Tables[0].Rows[cc][0].ToString())) > 0.0)
                                        {
                                            totPointsIn += double.Parse(VarGeneral.TString.TEmpty(VarGeneral.RepData.Tables[0].Rows[cc][2].ToString()));
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                            totPoints = totPointsIn - totPointsOut;
                            if (totPoints > 0.0)
                            {
                                txtTotalPointAll.Value = totPoints;
                            }
                            List<T_INVHED> _in = new List<T_INVHED>();
                            _in = ((!VarGeneral.CheckDate(dateLimit_OtherOptions)) ? db.T_INVHEDs.Where((T_INVHED t) => t.InvTyp == (int?)1 && t.IfDel != (int?)1 && t.IsPoints.Value && t.CusVenNo == LAccDef[iAcc].AccDef_No).ToList() : db.T_INVHEDs.Where((T_INVHED t) => (_IsHij ? (Convert.ToDateTime(t.HDat) <= Convert.ToDateTime(dateLimit_OtherOptions)) : (Convert.ToDateTime(t.GDat) <= Convert.ToDateTime(dateLimit_OtherOptions))) && t.InvTyp == (int?)1 && t.IfDel != (int?)1 && t.IsPoints.Value && t.CusVenNo == LAccDef[iAcc].AccDef_No).ToList());
                            _RepShow = new RepShow();
                            _RepShow.Tables = " T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                            _RepShow.Rule = " Where " + ((!VarGeneral.CheckDate(dateLimit_OtherOptions)) ? " 1 = 1 " : (_IsHij ? (" T_INVHED.HDat <= '" + dateLimit_OtherOptions + "'") : (" T_INVHED.GDat <= '" + dateLimit_OtherOptions + "'"))) + " and T_Items.IsPoints = 1 and T_INVHED.InvTyp = 3  and  T_INVHED.IfDel != 1 and T_INVHED.IsPoints = 1 and CusVenNo = '" + LAccDef[iAcc].AccDef_No + "' and T_CATEGORY.TotalPurchaes > 0 and T_CATEGORY.TotalPoint > 0 group by T_items.ItmCat";
                            _RepShow.Fields = " sum (Round(T_InvDet.Amount,2)) as Amount,T_items.ItmCat ,case when  CONVERT(INT,(sum(Round(T_InvDet.Amount,2)) / (select T_CATEGORY.TotalPurchaes from T_CATEGORY where T_CATEGORY.CAT_ID = T_items.ItmCat))) * (select T_CATEGORY.TotalPoint from T_CATEGORY where T_CATEGORY.CAT_ID = T_items.ItmCat) > 0 then  CONVERT(INT,(sum(Round(T_InvDet.Amount,2)) / (select T_CATEGORY.TotalPurchaes from T_CATEGORY where T_CATEGORY.CAT_ID = T_items.ItmCat))) * (select T_CATEGORY.TotalPoint from T_CATEGORY where T_CATEGORY.CAT_ID = T_items.ItmCat) else 0 end as PointsCount ";
                            try
                            {
                                _RepShow = _RepShow.Save();
                                VarGeneral.RepData = _RepShow.RepData;
                            }
                            catch (Exception ex2)
                            {
                                MessageBox.Show(ex2.Message);
                            }
                            if (VarGeneral.RepData.Tables[0].Rows.Count > 0)
                            {
                                for (int cc = 0; cc < VarGeneral.RepData.Tables[0].Rows.Count; cc++)
                                {
                                    try
                                    {
                                        if (double.Parse(VarGeneral.TString.TEmpty(VarGeneral.RepData.Tables[0].Rows[cc][0].ToString())) > 0.0)
                                        {
                                            _PointUseOut += double.Parse(VarGeneral.TString.TEmpty(VarGeneral.RepData.Tables[0].Rows[cc][2].ToString()));
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                            if (_in.Count > 0)
                            {
                                _PointUseIn = _in.Sum((T_INVHED g) => g.PointsCount.Value);
                            }
                            txtTotalPointUsed.Value = _PointUseIn;
                            txtTotalPointReturn.Value = _PointUseOut;
                            try
                            {
                                if (txtTotalPointAll.Value - txtTotalPointReturn.Value - txtTotalPointUsed.Value >= 0.0)
                                {
                                    txtTotalPointAvalible.Value = txtTotalPointAll.Value - txtTotalPointReturn.Value - txtTotalPointUsed.Value;
                                }
                                else
                                {
                                    txtTotalPointAvalible.Value = 0.0;
                                }
                            }
                            catch
                            {
                                txtTotalPointAvalible.Value = 0.0;
                            }
                            db.ExecuteCommand("UPDATE [T_AccDef] SET [TotPoints] = " + txtTotalPointAvalible.Value + "  WHERE AccDef_No = '" + LAccDef[iAcc].AccDef_No + "'");
                            iAcc++;
                        }
                    }
                    while (true)
                    {
                        if (VarGeneral.CheckDate(dateLimit))
                        {
                            try
                            {
                                db.ExecuteCommand("delete w FROM T_INVHED INNER JOIN T_INVDET ON T_INVHED.InvHed_ID = T_INVDET.InvId INNER JOIN  T_SINVDET w ON T_INVHED.InvHed_ID = w.SInvIdHEAD AND T_INVDET.InvDet_ID = w.SInvId where " + (_IsHij ? (" HDat <= '" + dateLimit + "'") : (" GDat <= '" + dateLimit + "'")));
                            }
                            catch
                            {
                            }
                            db.ExecuteCommand("delete w FROM  T_GDHEAD INNER JOIN  T_GDDET w ON T_GDHEAD.gdhead_ID = w.gdID where T_GDHEAD.salMonth = 'OpenGD' or " + (_IsHij ? (" gdHDate <= '" + dateLimit + "'") : (" gdGDate <= '" + dateLimit + "'")));
                            db.ExecuteCommand("delete from T_GDHEAD where T_GDHEAD.salMonth = 'OpenGD' or " + (_IsHij ? (" gdHDate <= '" + dateLimit + "'") : (" gdGDate <= '" + dateLimit + "'")));
                            db.ExecuteCommand("delete w FROM T_INVHED INNER JOIN  T_INVDET w ON T_INVHED.InvHed_ID = w.InvId where " + (_IsHij ? (" HDat <= '" + dateLimit + "'") : (" GDat <= '" + dateLimit + "'")));
                            db.ExecuteCommand("delete from T_INVHED where " + (_IsHij ? (" HDat <= '" + dateLimit + "'") : (" GDat <= '" + dateLimit + "'")));
                        }
                        else
                        {
                            try
                            {
                                db.ExecuteCommand("delete from T_SINVDET ");
                            }
                            catch
                            {
                            }
                            try
                            {
                                db.ExecuteCommand("delete from T_BankPeaper where gdID is not null and PayState = 1 ");
                            }
                            catch
                            {
                            }
                            db.ExecuteCommand("delete from T_GDDET ");
                            db.ExecuteCommand("delete from T_GDHEAD ");
                            db.ExecuteCommand("delete from T_INVDET ");
                            db.ExecuteCommand("delete from T_INVHED ");
                            db.ExecuteCommand("DBCC CHECKIDENT(T_GDDET, RESEED, 0) ");
                            db.ExecuteCommand("DBCC CHECKIDENT(T_GDHEAD, RESEED, 0) ");
                            db.ExecuteCommand("DBCC CHECKIDENT(T_INVDET, RESEED, 0) ");
                            db.ExecuteCommand("DBCC CHECKIDENT(T_INVHED, RESEED, 0) ");
                        }
                        if (!chk1.Checked)
                        {
                            break;
                        }
                        Stock_DataDataContext stock_DataDataContext3 = new Stock_DataDataContext(VarGeneral.BranchCS);
                        stock_DataDataContext3.ExecuteCommand("UPDATE T_SYSSETTING  SET GedID = 2");
                        data_this_GH = new T_GDHEAD();
                        data_this_GH.gdHDate = VarGeneral.Hdate;
                        data_this_GH.gdGDate = VarGeneral.Gdate;
                        if (VarGeneral.CheckDate(dateLimit))
                        {
                            VarGeneral.InvTyp = 11;
                            data_this_GH.gdNo = db.MaxGDHEADsNo.ToString();
                        }
                        else
                        {
                            data_this_GH.gdNo = "1";
                        }
                        data_this_GH.BName = data_this_GH.BName;
                        data_this_GH.ChekNo = data_this_GH.ChekNo;
                        try
                        {
                            data_this_GH.CurTyp = int.Parse(VarGeneral.Settings_Sys.ImportIp.ToString());
                        }
                        catch
                        {
                            data_this_GH.CurTyp = 1;
                        }
                        data_this_GH.ArbTaf = "1";
                        data_this_GH.EngTaf = "1";
                        data_this_GH.gdCstNo = 1;
                        data_this_GH.gdID = 0;
                        data_this_GH.gdLok = false;
                        data_this_GH.gdMem = "";
                        data_this_GH.AdminLock = false;
                        data_this_GH.gdMnd = null;
                        data_this_GH.gdRcptID = 0.0;
                        data_this_GH.gdTot = TotM;
                        data_this_GH.gdTp = 0;
                        data_this_GH.gdTyp = 11;
                        data_this_GH.gdUser = VarGeneral.UserNumber;
                        data_this_GH.gdUserNam = VarGeneral.UserNameA;
                        data_this_GH.RefNo = "";
                        data_this_GH.salMonth = "OpenGD";
                        data_this_GH.CommMnd_Gaid = 0.0;
                        data_this_GH.DATE_CREATED = DateTime.Now;
                        data_this_GH.MODIFIED_BY = "";
                        data_this_GH.CompanyID = 1;
                        stock_DataDataContext3.T_GDHEADs.InsertOnSubmit(data_this_GH);
                        stock_DataDataContext3.SubmitChanges();
                        if (data_this_GH.gdhead_ID <= 0 && Counter == 1)
                        {
                            Counter++;
                            continue;
                        }
                        List<TmpTbl> vQ = stock_DataDataContext3.TmpTbls.Select((TmpTbl t) => t).ToList();
                        int vAutoNo = 0;
                        if (VarGeneral.CheckDate(dateLimit))
                        {
                            List<T_GDHEAD> IDRecords = db.T_GDHEADs.OrderBy((T_GDHEAD br) => br.gdGDate).ToList();
                            double _StartCounter = vQ.Count;
                        }
                        for (int vI = 0; vI < vQ.Count; vI++)
                        {
                            if ((vQ[vI].Num1.HasValue ? vQ[vI].Num1.Value : 0.0) - (vQ[vI].Num2.HasValue ? vQ[vI].Num2.Value : 0.0) != 0.0)
                            {
                                vAutoNo++;
                                data_this_GD = new T_GDDET();
                                if (VarGeneral.CheckDate(dateLimit))
                                {
                                    data_this_GD.gdID = data_this_GH.gdhead_ID;
                                }
                                else
                                {
                                    data_this_GD.gdID = 1;
                                }
                                if (VarGeneral.CheckDate(dateLimit))
                                {
                                    data_this_GD.gdNo = data_this_GH.gdNo;
                                }
                                else
                                {
                                    data_this_GD.gdNo = "1";
                                }
                                data_this_GD.gdDes = "الرصيد الإفتتاحي";
                                data_this_GD.gdDesE = "Start Balance";
                                data_this_GD.recptTyp = "11";
                                data_this_GD.AccNo = vQ[vI].AccNo;
                                data_this_GD.AccName = vQ[vI].AccNm;
                                data_this_GD.gdValue = (vQ[vI].Num1.HasValue ? vQ[vI].Num1.Value : 0.0) - (vQ[vI].Num2.HasValue ? vQ[vI].Num2.Value : 0.0);
                                if (VarGeneral.CheckDate(dateLimit))
                                {
                                    data_this_GD.recptNo = data_this_GH.gdhead_ID.ToString();
                                }
                                else
                                {
                                    data_this_GD.recptNo = "1";
                                }
                                data_this_GD.Lin = vAutoNo;
                                stock_DataDataContext3.T_GDDETs.InsertOnSubmit(data_this_GD);
                                stock_DataDataContext3.SubmitChanges();
                            }
                        }
                        try
                        {
                            List<T_GDDET> _c = stock_DataDataContext3.T_GDDETs.Select((T_GDDET t) => t).ToList();
                            if (_c.Count <= 0)
                            {
                                stock_DataDataContext3.ExecuteCommand("delete from T_GDHEAD ");
                            }
                        }
                        catch
                        {
                        }
                        if (!VarGeneral.CheckDate(dateLimit))
                        {
                            stock_DataDataContext3.ExecuteCommand("UPDATE T_AccDef SET  T_AccDef.Debit = 0,T_AccDef.Credit = 0,T_AccDef.Balance = 0 ");
                            stock_DataDataContext3.ExecuteCommand("UPDATE T_AccDef SET  T_AccDef.Debit = T_AccDef.Debit + CASE WHEN T_GDDET.gdValue>0 THEN T_GDDET.gdValue ELSE 0 END ,T_AccDef.Credit = T_AccDef.Credit + CASE WHEN T_GDDET.gdValue<0 THEN -T_GDDET.gdValue ELSE 0 END  from T_GDDET LEFT JOIN T_AccDef ON T_GDDET.AccNo = T_AccDef.AccDef_No WHERE T_GDDET.gdID=1 ");
                            stock_DataDataContext3.ExecuteCommand("UPDATE T_AccDef SET T_AccDef.Balance = T_AccDef.Debit - T_AccDef.Credit ");
                        }
                        break;
                    }
                    if (chk2.Checked)
                    {
                        Stock_DataDataContext stock_DataDataContext2 = new Stock_DataDataContext(VarGeneral.BranchCS);
                        List<T_INVDET> listDet = new List<T_INVDET>();
                        stock_DataDataContext2.ExecuteCommand("UPDATE T_SYSSETTING   SET InvId = 2");
                        stock_DataDataContext2.ExecuteCommand("UPDATE T_INVSETTING  SET InvNum = 2 Where InvID= 14");
                        string InvStart = "1";
                        try
                        {
                            VarGeneral.InvTyp = 14;
                            InvStart = db.MaxInvheadNo.ToString();
                        }
                        catch
                        {
                            InvStart = "1";
                        }
                        vSTKQty = stock_DataDataContext2.T_STKSQTies.Where((T_STKSQTY t) => t.stkQty > (double?)0.0).ToList();
                        int Sequenc = 0;
                        vStk = 0;
                        while (true)
                        {
                            if (vStk >= vSTKQty.Count)
                            {
                                break;
                            }
                            T_Item vItem = stock_DataDataContext2.T_Items.Where((T_Item t) => t.Itm_No == vSTKQty[vStk].itmNo).First();
                            List<T_QTYEXP> vQTyEXP = stock_DataDataContext2.T_QTYEXPs.Where((T_QTYEXP t) => t.itmNo == vSTKQty[vStk].itmNo && t.storeNo.Value == vSTKQty[vStk].storeNo.Value && t.stkQty.Value > 0.0).ToList();
                            int vQtyExpSts = 0;
                            try
                            {
                                if (vQTyEXP.Count > 0)
                                {
                                    if (vQTyEXP.Sum((T_QTYEXP g) => g.stkQty.Value) == vSTKQty[vStk].stkQty.Value)
                                    {
                                        vQtyExpSts = 1;
                                    }
                                    else if (vQTyEXP.Sum((T_QTYEXP g) => g.stkQty.Value) < vSTKQty[vStk].stkQty.Value)
                                    {
                                        vQtyExpSts = 2;
                                    }
                                    else
                                    {
                                        vQtyExpSts = 0;
                                        stock_DataDataContext2.ExecuteCommand(" Delete From T_QTYEXP where itmNo ='" + vSTKQty[vStk].itmNo + "' and storeNo=" + vSTKQty[vStk].storeNo.Value);
                                    }
                                }
                            }
                            catch
                            {
                                vQtyExpSts = 0;
                                stock_DataDataContext2.ExecuteCommand(" Delete From T_QTYEXP where itmNo ='" + vSTKQty[vStk].itmNo + "' and storeNo=" + vSTKQty[vStk].storeNo.Value);
                            }
                            if (vQtyExpSts > 0)
                            {
                                for (int c4 = 0; c4 < vQTyEXP.Count; c4++)
                                {
                                    Sequenc++;
                                    data_this_InvD = new T_INVDET();
                                    data_this_InvD.InvNo = InvStart;
                                    data_this_InvD.InvId = int.Parse(InvStart);
                                    data_this_InvD.ItmNo = vQTyEXP[c4].itmNo;
                                    data_this_InvD.Qty = vQTyEXP[c4].stkQty.Value;
                                    data_this_InvD.ItmDes = vItem.Arb_Des;
                                    data_this_InvD.ItmDesE = vItem.Eng_Des;
                                    data_this_InvD.ItmUnt = vItem.T_Unit.Arb_Des;
                                    data_this_InvD.ItmUntE = vItem.T_Unit.Eng_Des;
                                    data_this_InvD.ItmUntPak = 1.0;
                                    data_this_InvD.StoreNo = vQTyEXP[c4].storeNo.Value;
                                    data_this_InvD.Price = vItem.LastCost.Value;
                                    data_this_InvD.Amount = data_this_InvD.Qty.Value * data_this_InvD.Price.Value;
                                    data_this_InvD.RealQty = vQTyEXP[c4].stkQty.Value;
                                    data_this_InvD.Cost = 0.0;
                                    data_this_InvD.itmInvDsc = 0.0;
                                    data_this_InvD.InvSer = Sequenc;
                                    data_this_InvD.ItmIndex = 0;
                                    data_this_InvD.ItmTyp = vItem.ItmTyp.Value;
                                    data_this_InvD.DatExper = vQTyEXP[c4].DatExper;
                                    data_this_InvD.ItmDis = 0.0;
                                    data_this_InvD.ItmWight = 0.0;
                                    data_this_InvD.ItmWight_T = 0.0;
                                    data_this_InvD.RunCod = vQTyEXP[c4].RunCod;
                                    data_this_InvD.LineDetails = "";
                                    data_this_InvD.ItmTax = 0.0;
                                    TotQty += vQTyEXP[c4].stkQty.Value;
                                    TotQtyAm += data_this_InvD.Amount.Value;
                                    listDet.Add(data_this_InvD);
                                }
                                if (vQtyExpSts == 2)
                                {
                                    Sequenc++;
                                    data_this_InvD = new T_INVDET();
                                    data_this_InvD.InvNo = InvStart;
                                    data_this_InvD.InvId = int.Parse(InvStart);
                                    data_this_InvD.ItmNo = vSTKQty[vStk].itmNo;
                                    data_this_InvD.Qty = vSTKQty[vStk].stkQty.Value - vQTyEXP.Sum((T_QTYEXP g) => g.stkQty.Value);
                                    data_this_InvD.ItmDes = vItem.Arb_Des;
                                    data_this_InvD.ItmDesE = vItem.Eng_Des;
                                    data_this_InvD.ItmUnt = vItem.T_Unit.Arb_Des;
                                    data_this_InvD.ItmUntE = vItem.T_Unit.Eng_Des;
                                    data_this_InvD.ItmUntPak = 1.0;
                                    data_this_InvD.StoreNo = vSTKQty[vStk].storeNo.Value;
                                    data_this_InvD.Price = vItem.LastCost.Value;
                                    data_this_InvD.Amount = data_this_InvD.Qty.Value * data_this_InvD.Price.Value;
                                    data_this_InvD.RealQty = vSTKQty[vStk].stkQty.Value - vQTyEXP.Sum((T_QTYEXP g) => g.stkQty.Value);
                                    data_this_InvD.Cost = 0.0;
                                    data_this_InvD.itmInvDsc = 0.0;
                                    data_this_InvD.InvSer = Sequenc;
                                    data_this_InvD.ItmIndex = 0;
                                    data_this_InvD.ItmTyp = vItem.ItmTyp.Value;
                                    data_this_InvD.DatExper = "";
                                    data_this_InvD.ItmDis = 0.0;
                                    data_this_InvD.ItmWight = 0.0;
                                    data_this_InvD.ItmWight_T = 0.0;
                                    data_this_InvD.RunCod = "";
                                    data_this_InvD.LineDetails = "";
                                    data_this_InvD.ItmTax = 0.0;
                                    TotQty += vSTKQty[vStk].stkQty.Value - vQTyEXP.Sum((T_QTYEXP g) => g.stkQty.Value);
                                    TotQtyAm += data_this_InvD.Amount.Value;
                                    listDet.Add(data_this_InvD);
                                }
                            }
                            else
                            {
                                Sequenc++;
                                data_this_InvD = new T_INVDET();
                                data_this_InvD.InvNo = InvStart;
                                data_this_InvD.InvId = int.Parse(InvStart);
                                data_this_InvD.ItmNo = vSTKQty[vStk].itmNo;
                                data_this_InvD.Qty = vSTKQty[vStk].stkQty.Value;
                                data_this_InvD.ItmDes = vItem.Arb_Des;
                                data_this_InvD.ItmDesE = vItem.Eng_Des;
                                data_this_InvD.ItmUnt = vItem.T_Unit.Arb_Des;
                                data_this_InvD.ItmUntE = vItem.T_Unit.Eng_Des;
                                data_this_InvD.ItmUntPak = 1.0;
                                data_this_InvD.StoreNo = vSTKQty[vStk].storeNo.Value;
                                data_this_InvD.Price = vItem.LastCost.Value;
                                data_this_InvD.Amount = data_this_InvD.Qty.Value * data_this_InvD.Price.Value;
                                data_this_InvD.RealQty = vSTKQty[vStk].stkQty.Value;
                                data_this_InvD.Cost = 0.0;
                                data_this_InvD.itmInvDsc = 0.0;
                                data_this_InvD.InvSer = Sequenc;
                                data_this_InvD.ItmIndex = 0;
                                data_this_InvD.ItmTyp = vItem.ItmTyp.Value;
                                data_this_InvD.DatExper = "";
                                data_this_InvD.ItmDis = 0.0;
                                data_this_InvD.ItmWight = 0.0;
                                data_this_InvD.ItmWight_T = 0.0;
                                data_this_InvD.RunCod = "";
                                data_this_InvD.LineDetails = "";
                                data_this_InvD.ItmTax = 0.0;
                                TotQty += vSTKQty[vStk].stkQty.Value;
                                TotQtyAm += data_this_InvD.Amount.Value;
                                listDet.Add(data_this_InvD);
                            }
                            vStk++;
                        }
                        if (listDet.Count > 0)
                        {
                            data_this_InvH = new T_INVHED();
                            data_this_InvH.CustPri = 0;
                            data_this_InvH.CusVenNm = "";
                            data_this_InvH.CusVenNo = "";
                            data_this_InvH.CusVenAdd = "";
                            data_this_InvH.CusVenTel = "";
                            data_this_InvH.CustNet = 0.0;
                            data_this_InvH.CustRep = 0.0;
                            data_this_InvH.Remark = "";
                            data_this_InvH.InvNo = InvStart;
                            data_this_InvH.CashPay = TotQtyAm;
                            try
                            {
                                try
                                {
                                    data_this_InvH.CurTyp = int.Parse(VarGeneral.Settings_Sys.ImportIp.ToString());
                                }
                                catch
                                {
                                    data_this_InvH.CurTyp = 1;
                                }
                            }
                            catch
                            {
                                data_this_InvH.CurTyp = null;
                            }
                            data_this_InvH.HDat = VarGeneral.Hdate;
                            data_this_InvH.GDat = VarGeneral.Gdate;
                            data_this_InvH.InvCashPay = 0;
                            data_this_InvH.InvCash = "0";
                            data_this_InvH.InvCost = TotQtyAm;
                            try
                            {
                                data_this_InvH.InvCstNo = 1;
                            }
                            catch
                            {
                                data_this_InvH.InvCstNo = null;
                            }
                            data_this_InvH.InvDisPrs = 0.0;
                            data_this_InvH.InvDisVal = 0.0;
                            data_this_InvH.InvDisValLocCur = 0.0;
                            data_this_InvH.InvNet = TotQtyAm;
                            data_this_InvH.InvNetLocCur = TotQtyAm;
                            data_this_InvH.InvQty = TotQty;
                            data_this_InvH.InvTot = TotQtyAm;
                            data_this_InvH.InvTotLocCur = TotQtyAm;
                            data_this_InvH.InvTyp = 14;
                            data_this_InvH.IfDel = 0;
                            data_this_InvH.LTim = DateTime.Now.ToString("HH:mm");
                            data_this_InvH.MndNo = null;
                            data_this_InvH.RefNo = "";
                            data_this_InvH.CommMnd_Inv = 0.0;
                            data_this_InvH.MndExtrnal = false;
                            data_this_InvH.ArbTaf = "1";
                            data_this_InvH.EngTaf = "1";
                            data_this_InvH.DATE_MODIFIED = DateTime.Now;
                            data_this_InvH.SalsManNo = VarGeneral.UserNumber;
                            data_this_InvH.CreditPay = 0.0;
                            data_this_InvH.NetworkPay = 0.0;
                            data_this_InvH.CashPayLocCur = TotQtyAm;
                            data_this_InvH.CreditPayLocCur = 0.0;
                            data_this_InvH.NetworkPayLocCur = 0.0;
                            data_this_InvH.CompanyID = 1;
                            data_this_InvH.tailor20 = "0";
                            data_this_InvH.IfRet = 0;
                            data_this_InvH.IfEnter = 0;
                            data_this_InvH.DATE_CREATED = DateTime.Now;
                            data_this_InvH.UserNew = VarGeneral.UserNumber;
                            data_this_InvH.SalsManNam = "";
                            data_this_InvH.Puyaid = 0.0;
                            data_this_InvH.Remming = 0.0;
                            data_this_InvH.AdminLock = true;
                            data_this_InvH.PaymentOrderTyp = 0;
                            data_this_InvH.EstDat = "";
                            data_this_InvH.InvCashPayNm = "";
                            data_this_InvH.DeleteDate = "";
                            data_this_InvH.DeleteTime = "";
                            data_this_InvH.RoomNo = 1;
                            data_this_InvH.OrderTyp = 1;
                            data_this_InvH.RoomSts = false;
                            data_this_InvH.RoomPerson = 1;
                            data_this_InvH.ServiceValue = 0.0;
                            data_this_InvH.Sts = false;
                            data_this_InvH.chauffeurNo = null;
                            data_this_InvH.InvAddTax = 0.0;
                            data_this_InvH.InvAddTaxlLoc = 0.0;
                            data_this_InvH.IsTaxGaid = false;
                            data_this_InvH.IsTaxUse = true;
                            data_this_InvH.IsTaxLines = true;
                            data_this_InvH.IsTaxByTotal = false;
                            data_this_InvH.IsTaxByNet = false;
                            data_this_InvH.TaxByNetValue = 0.0;
                            data_this_InvH.InvValGaidDis = 0.0;
                            data_this_InvH.InvValGaidDislLoc = 0.0;
                            data_this_InvH.IsDisGaid = false;
                            data_this_InvH.IsDisUse1 = false;
                            data_this_InvH.InvComm = 0.0;
                            data_this_InvH.InvCommLoc = 0.0;
                            data_this_InvH.IsCommUse = false;
                            data_this_InvH.IsCommGaid = false;
                            data_this_InvH.DesPointsValue = 0.0;
                            data_this_InvH.DesPointsValueLocCur = 0.0;
                            data_this_InvH.PointsCount = 0.0;
                            data_this_InvH.IsPoints = false;
                            stock_DataDataContext2.T_INVHEDs.InsertOnSubmit(data_this_InvH);
                            stock_DataDataContext2.SubmitChanges();
                        }
                        for (int iList = 0; iList < listDet.Count; iList++)
                        {
                            listDet[iList].InvId = data_this_InvH.InvHed_ID;
                            stock_DataDataContext2.T_INVDETs.InsertOnSubmit(listDet[iList]);
                            stock_DataDataContext2.SubmitChanges();
                        }
                        stock_DataDataContext2.ExecuteCommand("UPDATE T_STKSQTY SET  T_STKSQTY.stkInt = T_STKSQTY.stkQty ");
                        stock_DataDataContext2.ExecuteCommand("UPDATE T_Items SET  T_Items.Itm_No = T_STKSQTY.itmNo,T_Items.OpenQty = T_STKSQTY.stkInt from T_STKSQTY LEFT JOIN T_Items ON (T_STKSQTY.itmNo = T_Items.Itm_No) ");
                        double vCheckQty = 0.0;
                        VarGeneral.InvTyp = 17;
                        InvStart = "1";
                        RepShow _RepShow = new RepShow();
                        _RepShow.Tables = " T_StoreMnd LEFT OUTER JOIN T_Items On T_Items.Itm_No = T_StoreMnd.itmNo LEFT OUTER JOIN  T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID  LEFT OUTER JOIN T_Mndob On T_StoreMnd.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_AccDef On T_StoreMnd.CusVenNo = T_AccDef.AccDef_No Left Join T_SYSSETTING ON T_Items.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                        string Fields = " distinct  T_Items.*, T_StoreMnd.storeNo , T_StoreMnd.stkInt , T_StoreMnd.stkQty as x, T_Mndob.Mnd_No , T_Mndob.Arb_Des as MndNm ,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as UnitNm,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm5,CASE WHEN T_Items.Unit1 = T_Items.Unit1 THEN (CASE WHEN  Pack1 > 0 THEN (T_StoreMnd.stkQty / Pack1) ElSE (0 ) END) WHEN T_Items.Unit2 = T_Items.Unit1 THEN (CASE WHEN  Pack2 > 0 THEN (T_StoreMnd.stkQty / Pack2) ElSE (0 ) END) WHEN T_Items.Unit3 = T_Items.Unit1 THEN (CASE WHEN  Pack3 > 0 THEN (T_StoreMnd.stkQty / Pack3) ElSE (0 ) END) WHEN T_Items.Unit4 = T_Items.Unit1 THEN (CASE WHEN  Pack4 > 0 THEN (T_StoreMnd.stkQty / Pack4) ElSE (0 ) END) WHEN T_Items.Unit5 = T_Items.Unit1 THEN (CASE WHEN  Pack5 > 0 THEN (T_StoreMnd.stkQty / Pack5) ElSE (0 ) END)END as stkQty  ,T_SYSSETTING.LogImg,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNmE  ,T_StoreMnd.CusVenNo";
                        _RepShow.Rule = " Where StkQty != 0  and (  T_StoreMnd.MndNo <> '' )  and T_Items.Unit1 = T_Items.Unit1 or  T_Items.Unit2 = T_Items.Unit1 or T_Items.Unit3 = T_Items.Unit1 or T_Items.Unit4 = T_Items.Unit1 or T_Items.Unit5 = T_Items.Unit1";
                        _RepShow.Fields = Fields;
                        try
                        {
                            _RepShow = _RepShow.Save();
                            VarGeneral.RepData = _RepShow.RepData;
                        }
                        catch (Exception ex2)
                        {
                            MessageBox.Show(ex2.Message);
                        }
                        if (VarGeneral.RepData.Tables[0].Rows.Count > 0)
                        {
                            List<string> MndData = (from myRow in VarGeneral.RepData.Tables[0].AsEnumerable()
                                                    select myRow.Field<string>("Mnd_No")).Distinct().ToList();
                            for (int iicnt = 0; iicnt < MndData.Count; iicnt++)
                            {
                                if (string.IsNullOrEmpty(VarGeneral.RepData.Tables[0].Rows[iicnt]["Mnd_No"].ToString()))
                                {
                                    continue;
                                }
                                List<T_INVDET> listDetNMnd = new List<T_INVDET>();
                                try
                                {
                                    InvStart = db.MaxInvheadNo.ToString();
                                }
                                catch
                                {
                                    InvStart = "1";
                                }
                                c3 = 0;
                                while (true)
                                {
                                    if (c3 >= VarGeneral.RepData.Tables[0].Rows.Count)
                                    {
                                        break;
                                    }
                                    if (VarGeneral.RepData.Tables[0].Rows[c3]["Mnd_No"].ToString() == MndData[iicnt])
                                    {
                                        if (VarGeneral.CheckDate(dateLimit))
                                        {
                                            vCheckQty = 0.0;
                                            try
                                            {
                                                _RepShow = new RepShow();
                                                _RepShow.Tables = " T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                                                Fields = " MAX(T_Items.Itm_No ) as Itm_No , MAX(T_Items.Arb_Des ) as itemNm   , MAX( T_Category.Arb_Des ) as [CategoyNm] ,  SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) AS [Credit] ,  SUM (CASE WHEN T_InvDet.RealQty < 0 THEN ABS(T_InvDet.RealQty)  Else 0 END ) AS [Debit],MAX (T_SYSSETTING.LogImg) as LogImg  ,(SUM (CASE WHEN T_InvDet.RealQty < 0 THEN ABS(T_InvDet.RealQty)  Else 0 END ) - SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END )) as Balances,(select T_STKSQTY.stkQty from T_STKSQTY where T_STKSQTY.itmNo = T_Items.Itm_No and T_STKSQTY.storeNo = T_INVDET.StoreNo) as STQNow,T_INVDET.StoreNo";
                                                _RepShow.Rule = " Where " + (_IsHij ? (" T_INVHED.HDat > '" + dateLimit + "'") : (" T_INVHED.GDat > '" + dateLimit + "'")) + " and T_INVHED.MndNo <> '' and  T_INVHED.MndNo = " + int.Parse(VarGeneral.RepData.Tables[0].Rows[c3]["Mnd_No"].ToString()) + " and  T_INVDET.StoreNo = " + int.Parse(VarGeneral.RepData.Tables[0].Rows[c3]["storeNo"].ToString()) + "  and  T_INVHED.IfDel != 1 and (T_INVHED.InvTyp = 17 or T_INVHED.InvTyp = 20) group by T_Items.Itm_No,T_INVDET.StoreNo Order by Itm_No ";
                                                _RepShow.Fields = Fields;
                                                _RepShow = _RepShow.Save();
                                                DataSet vQtyMnd = _RepShow.RepData;
                                                if (vQtyMnd.Tables[0].Rows.Count > 0)
                                                {
                                                    try
                                                    {
                                                        vCheckQty = double.Parse(VarGeneral.RepData.Tables[0].Rows[c3]["stkQty"].ToString()) - double.Parse(VarGeneral.TString.TEmpty(vQtyMnd.Tables[0].Rows[i]["Balances"].ToString()));
                                                    }
                                                    catch
                                                    {
                                                        vCheckQty = 0.0;
                                                    }
                                                    if (!(vCheckQty > 0.0))
                                                    {
                                                        goto IL_45cc;
                                                    }
                                                    VarGeneral.RepData.Tables[0].Rows[c3]["stkQty"] = vCheckQty;
                                                }
                                            }
                                            catch
                                            {
                                            }
                                        }
                                        T_Item vItem = stock_DataDataContext2.T_Items.Where((T_Item t) => t.Itm_No == VarGeneral.RepData.Tables[0].Rows[c3]["Itm_No"].ToString()).First();
                                        data_this_InvD = new T_INVDET();
                                        data_this_InvD.InvNo = InvStart;
                                        data_this_InvD.ItmNo = VarGeneral.RepData.Tables[0].Rows[c3]["Itm_No"].ToString();
                                        data_this_InvD.Qty = double.Parse(VarGeneral.RepData.Tables[0].Rows[c3]["stkQty"].ToString());
                                        data_this_InvD.ItmDes = vItem.Arb_Des;
                                        data_this_InvD.ItmDesE = vItem.Eng_Des;
                                        data_this_InvD.ItmUnt = vItem.T_Unit.Arb_Des;
                                        data_this_InvD.ItmUntE = vItem.T_Unit.Eng_Des;
                                        data_this_InvD.ItmUntPak = 1.0;
                                        data_this_InvD.StoreNo = int.Parse(VarGeneral.RepData.Tables[0].Rows[c3]["storeNo"].ToString());
                                        data_this_InvD.Price = vItem.LastCost.Value;
                                        data_this_InvD.Amount = data_this_InvD.Qty.Value * data_this_InvD.Price.Value;
                                        data_this_InvD.RealQty = double.Parse(VarGeneral.RepData.Tables[0].Rows[c3]["stkQty"].ToString());
                                        data_this_InvD.Cost = 0.0;
                                        data_this_InvD.itmInvDsc = 0.0;
                                        data_this_InvD.InvSer = c3 + 1;
                                        data_this_InvD.ItmIndex = 0;
                                        data_this_InvD.ItmTyp = vItem.ItmTyp.Value;
                                        data_this_InvD.DatExper = "";
                                        data_this_InvD.ItmDis = 0.0;
                                        data_this_InvD.ItmWight = 0.0;
                                        data_this_InvD.ItmWight_T = 0.0;
                                        data_this_InvD.RunCod = "";
                                        data_this_InvD.LineDetails = "";
                                        data_this_InvD.ItmTax = 0.0;
                                        listDetNMnd.Add(data_this_InvD);
                                    }
                                    goto IL_45cc;
                                IL_45cc:
                                    c3++;
                                }
                                data_this_InvH = new T_INVHED();
                                try
                                {
                                    try
                                    {
                                        data_this_InvH.CurTyp = int.Parse(VarGeneral.Settings_Sys.ImportIp.ToString());
                                    }
                                    catch
                                    {
                                        data_this_InvH.CurTyp = 1;
                                    }
                                }
                                catch
                                {
                                    data_this_InvH.CurTyp = null;
                                }
                                data_this_InvH.CommMnd_Inv = 0.0;
                                data_this_InvH.MndExtrnal = false;
                                data_this_InvH.CusVenNm = "";
                                data_this_InvH.CusVenNo = "";
                                data_this_InvH.CusVenAdd = "";
                                data_this_InvH.CusVenTel = "";
                                data_this_InvH.CustNet = 0.0;
                                data_this_InvH.CustRep = 0.0;
                                data_this_InvH.Remark = "اثبات الكميات الموجودة عند المندوبين والعملاء والموردين خلال عملية اقفال سنة " + txtDateAlarm.Text + "  || اثبات الكميات الموجودة عند المندوبين والعملاء والموردين خلال عملية اقفال سنة " + txtDateAlarm.Text;
                                data_this_InvH.InvNo = InvStart;
                                data_this_InvH.CashPay = listDetNMnd.Sum((T_INVDET g) => g.Amount.Value);
                                data_this_InvH.AdminLock = false;
                                data_this_InvH.HDat = VarGeneral.Hdate;
                                data_this_InvH.GDat = VarGeneral.Gdate;
                                try
                                {
                                    data_this_InvH.InvCashPay = 0;
                                }
                                catch
                                {
                                    data_this_InvH.InvCashPay = 0;
                                }
                                data_this_InvH.InvCash = "أمر صرف";
                                data_this_InvH.InvCost = listDetNMnd.Sum((T_INVDET g) => g.Cost.Value) * listDetNMnd.Sum((T_INVDET g) => g.RealQty.Value);
                                data_this_InvH.InvCstNo = 1;
                                data_this_InvH.InvDisPrs = 0.0;
                                data_this_InvH.InvDisVal = 0.0;
                                data_this_InvH.InvDisValLocCur = 0.0;
                                data_this_InvH.InvNet = listDetNMnd.Sum((T_INVDET g) => g.Amount.Value);
                                data_this_InvH.InvNetLocCur = listDetNMnd.Sum((T_INVDET g) => g.Amount.Value);
                                data_this_InvH.InvQty = listDetNMnd.Sum((T_INVDET g) => g.Qty.Value);
                                data_this_InvH.InvTot = listDetNMnd.Sum((T_INVDET g) => g.Amount.Value);
                                data_this_InvH.InvTotLocCur = listDetNMnd.Sum((T_INVDET g) => g.Amount.Value);
                                data_this_InvH.InvTyp = VarGeneral.InvTyp;
                                data_this_InvH.IfDel = 0;
                                data_this_InvH.LTim = DateTime.Now.ToString("HH:mm");
                                data_this_InvH.MndNo = int.Parse(MndData[iicnt].ToString());
                                data_this_InvH.IfEnter = 0;
                                data_this_InvH.PaymentOrderTyp = 0;
                                data_this_InvH.EstDat = "";
                                data_this_InvH.InvCashPayNm = "";
                                data_this_InvH.DeleteDate = "";
                                data_this_InvH.RefNo = "";
                                data_this_InvH.ArbTaf = "";
                                data_this_InvH.EngTaf = "";
                                data_this_InvH.DATE_MODIFIED = DateTime.Now;
                                data_this_InvH.CreditPay = 0.0;
                                data_this_InvH.NetworkPay = 0.0;
                                data_this_InvH.CashPayLocCur = listDetNMnd.Sum((T_INVDET g) => g.Amount.Value);
                                data_this_InvH.CreditPayLocCur = 0.0;
                                data_this_InvH.NetworkPayLocCur = 0.0;
                                data_this_InvH.Puyaid = 0.0;
                                data_this_InvH.Remming = 0.0;
                                data_this_InvH.CompanyID = 1;
                                data_this_InvH.tailor20 = "0";
                                data_this_InvH.RoomNo = 1;
                                data_this_InvH.OrderTyp = 1;
                                data_this_InvH.RoomSts = false;
                                data_this_InvH.RoomPerson = 1;
                                data_this_InvH.ServiceValue = 0.0;
                                data_this_InvH.Sts = false;
                                data_this_InvH.chauffeurNo = null;
                                data_this_InvH.InvAddTax = 0.0;
                                data_this_InvH.InvAddTaxlLoc = 0.0;
                                data_this_InvH.IsTaxUse = true;
                                data_this_InvH.IsTaxLines = true;
                                data_this_InvH.IsTaxByTotal = true;
                                data_this_InvH.IsTaxByNet = false;
                                data_this_InvH.TaxByNetValue = 0.0;
                                data_this_InvH.IsTaxGaid = false;
                                data_this_InvH.InvValGaidDis = 0.0;
                                data_this_InvH.InvValGaidDislLoc = 0.0;
                                data_this_InvH.IsDisUse1 = false;
                                data_this_InvH.IsDisGaid = false;
                                data_this_InvH.InvComm = 0.0;
                                data_this_InvH.InvCommLoc = 0.0;
                                data_this_InvH.IsCommUse = false;
                                data_this_InvH.IsCommGaid = false;
                                data_this_InvH.DesPointsValue = 0.0;
                                data_this_InvH.DesPointsValueLocCur = 0.0;
                                data_this_InvH.PointsCount = 0.0;
                                data_this_InvH.IsPoints = false;
                                stock_DataDataContext2.T_INVHEDs.InsertOnSubmit(data_this_InvH);
                                stock_DataDataContext2.SubmitChanges();
                                for (int iList = 0; iList < listDetNMnd.Count; iList++)
                                {
                                    listDetNMnd[iList].InvId = data_this_InvH.InvHed_ID;
                                    listDetNMnd[iList].InvSer = iList + 1;
                                    listDetNMnd[iList].InvNo = data_this_InvH.InvNo;
                                    stock_DataDataContext2.T_INVDETs.InsertOnSubmit(listDetNMnd[iList]);
                                    stock_DataDataContext2.SubmitChanges();
                                }
                            }
                        }
                        _RepShow = new RepShow();
                        _RepShow.Tables = " T_StoreMnd LEFT OUTER JOIN T_Items On T_Items.Itm_No = T_StoreMnd.itmNo LEFT OUTER JOIN  T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID  LEFT OUTER JOIN T_Mndob On T_StoreMnd.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_AccDef On T_StoreMnd.CusVenNo = T_AccDef.AccDef_No Left Join T_SYSSETTING ON T_Items.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                        Fields = " distinct  T_Items.*, T_StoreMnd.storeNo , T_StoreMnd.stkInt , T_StoreMnd.stkQty as x, T_Mndob.Mnd_No , T_Mndob.Arb_Des as MndNm ,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as UnitNm,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm5,CASE WHEN T_Items.Unit1 = T_Items.Unit1 THEN (CASE WHEN  Pack1 > 0 THEN (T_StoreMnd.stkQty / Pack1) ElSE (0 ) END) WHEN T_Items.Unit2 = T_Items.Unit1 THEN (CASE WHEN  Pack2 > 0 THEN (T_StoreMnd.stkQty / Pack2) ElSE (0 ) END) WHEN T_Items.Unit3 = T_Items.Unit1 THEN (CASE WHEN  Pack3 > 0 THEN (T_StoreMnd.stkQty / Pack3) ElSE (0 ) END) WHEN T_Items.Unit4 = T_Items.Unit1 THEN (CASE WHEN  Pack4 > 0 THEN (T_StoreMnd.stkQty / Pack4) ElSE (0 ) END) WHEN T_Items.Unit5 = T_Items.Unit1 THEN (CASE WHEN  Pack5 > 0 THEN (T_StoreMnd.stkQty / Pack5) ElSE (0 ) END)END as stkQty  ,T_SYSSETTING.LogImg,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNmE ,T_StoreMnd.CusVenNo ";
                        _RepShow.Rule = " Where StkQty != 0  and ( T_StoreMnd.CusVenNo <> '' and T_AccDef.AccCat = 4 )  and T_Items.Unit1 = T_Items.Unit1 or  T_Items.Unit2 = T_Items.Unit1 or T_Items.Unit3 = T_Items.Unit1 or T_Items.Unit4 = T_Items.Unit1 or T_Items.Unit5 = T_Items.Unit1";
                        _RepShow.Fields = Fields;
                        try
                        {
                            _RepShow = _RepShow.Save();
                            VarGeneral.RepData = _RepShow.RepData;
                        }
                        catch (Exception ex2)
                        {
                            MessageBox.Show(ex2.Message);
                        }
                        if (VarGeneral.RepData.Tables[0].Rows.Count > 0)
                        {
                            List<string> MndData = (from myRow in VarGeneral.RepData.Tables[0].AsEnumerable()
                                                    select myRow.Field<string>("CusVenNo")).Distinct().ToList();
                            for (int iicnt = 0; iicnt < MndData.Count; iicnt++)
                            {
                                if (string.IsNullOrEmpty(VarGeneral.RepData.Tables[0].Rows[iicnt]["CusVenNo"].ToString()))
                                {
                                    continue;
                                }
                                List<T_INVDET> listDetNMnd = new List<T_INVDET>();
                                try
                                {
                                    InvStart = db.MaxInvheadNo.ToString();
                                }
                                catch
                                {
                                    InvStart = "1";
                                }
                                c2 = 0;
                                while (true)
                                {
                                    if (c2 >= VarGeneral.RepData.Tables[0].Rows.Count)
                                    {
                                        break;
                                    }
                                    if (VarGeneral.RepData.Tables[0].Rows[c2]["CusVenNo"].ToString() == MndData[iicnt])
                                    {
                                        if (VarGeneral.CheckDate(dateLimit))
                                        {
                                            vCheckQty = 0.0;
                                            try
                                            {
                                                _RepShow = new RepShow();
                                                _RepShow.Tables = " T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                                                Fields = " MAX(T_Items.Itm_No ) as Itm_No , MAX(T_Items.Arb_Des ) as itemNm   , MAX( T_Category.Arb_Des ) as [CategoyNm] ,  SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) AS [Credit] ,  SUM (CASE WHEN T_InvDet.RealQty < 0 THEN ABS(T_InvDet.RealQty)  Else 0 END ) AS [Debit],MAX (T_SYSSETTING.LogImg) as LogImg  ,(SUM (CASE WHEN T_InvDet.RealQty < 0 THEN ABS(T_InvDet.RealQty)  Else 0 END ) - SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END )) as Balances,(select T_STKSQTY.stkQty from T_STKSQTY where T_STKSQTY.itmNo = T_Items.Itm_No and T_STKSQTY.storeNo = T_INVDET.StoreNo) as STQNow,T_INVDET.StoreNo";
                                                _RepShow.Rule = " Where " + (_IsHij ? (" T_INVHED.HDat > '" + dateLimit + "'") : (" T_INVHED.GDat > '" + dateLimit + "'")) + " and T_INVHED.CusVenNo <> '' and  T_INVHED.CusVenNo = '" + VarGeneral.RepData.Tables[0].Rows[c2]["Mnd_No"].ToString() + "' and  T_INVDET.StoreNo = " + int.Parse(VarGeneral.RepData.Tables[0].Rows[c2]["storeNo"].ToString()) + "  and  T_INVHED.IfDel != 1 and (T_INVHED.InvTyp = 17 or T_INVHED.InvTyp = 20) group by T_Items.Itm_No,T_INVDET.StoreNo Order by Itm_No ";
                                                _RepShow.Fields = Fields;
                                                _RepShow = _RepShow.Save();
                                                DataSet vQtyMnd = _RepShow.RepData;
                                                if (vQtyMnd.Tables[0].Rows.Count > 0)
                                                {
                                                    try
                                                    {
                                                        vCheckQty = double.Parse(VarGeneral.RepData.Tables[0].Rows[c2]["stkQty"].ToString()) - double.Parse(VarGeneral.TString.TEmpty(vQtyMnd.Tables[0].Rows[i]["Balances"].ToString()));
                                                    }
                                                    catch
                                                    {
                                                        vCheckQty = 0.0;
                                                    }
                                                    if (!(vCheckQty > 0.0))
                                                    {
                                                        goto IL_5748;
                                                    }
                                                    VarGeneral.RepData.Tables[0].Rows[c2]["stkQty"] = vCheckQty;
                                                }
                                            }
                                            catch
                                            {
                                            }
                                        }
                                        T_Item vItem = stock_DataDataContext2.T_Items.Where((T_Item t) => t.Itm_No == VarGeneral.RepData.Tables[0].Rows[c2]["Itm_No"].ToString()).First();
                                        data_this_InvD = new T_INVDET();
                                        data_this_InvD.InvNo = InvStart;
                                        data_this_InvD.ItmNo = VarGeneral.RepData.Tables[0].Rows[c2]["Itm_No"].ToString();
                                        data_this_InvD.Qty = double.Parse(VarGeneral.RepData.Tables[0].Rows[c2]["stkQty"].ToString());
                                        data_this_InvD.ItmDes = vItem.Arb_Des;
                                        data_this_InvD.ItmDesE = vItem.Eng_Des;
                                        data_this_InvD.ItmUnt = vItem.T_Unit.Arb_Des;
                                        data_this_InvD.ItmUntE = vItem.T_Unit.Eng_Des;
                                        data_this_InvD.ItmUntPak = 1.0;
                                        data_this_InvD.StoreNo = int.Parse(VarGeneral.RepData.Tables[0].Rows[c2]["storeNo"].ToString());
                                        data_this_InvD.Price = vItem.LastCost.Value;
                                        data_this_InvD.Amount = data_this_InvD.Qty.Value * data_this_InvD.Price.Value;
                                        data_this_InvD.RealQty = double.Parse(VarGeneral.RepData.Tables[0].Rows[c2]["stkQty"].ToString());
                                        data_this_InvD.Cost = 0.0;
                                        data_this_InvD.itmInvDsc = 0.0;
                                        data_this_InvD.InvSer = c2 + 1;
                                        data_this_InvD.ItmIndex = 0;
                                        data_this_InvD.ItmTyp = vItem.ItmTyp.Value;
                                        data_this_InvD.DatExper = "";
                                        data_this_InvD.ItmDis = 0.0;
                                        data_this_InvD.ItmWight = 0.0;
                                        data_this_InvD.ItmWight_T = 0.0;
                                        data_this_InvD.RunCod = "";
                                        data_this_InvD.LineDetails = "";
                                        data_this_InvD.ItmTax = 0.0;
                                        listDetNMnd.Add(data_this_InvD);
                                    }
                                    goto IL_5748;
                                IL_5748:
                                    c2++;
                                }
                                data_this_InvH = new T_INVHED();
                                try
                                {
                                    try
                                    {
                                        data_this_InvH.CurTyp = int.Parse(VarGeneral.Settings_Sys.ImportIp.ToString());
                                    }
                                    catch
                                    {
                                        data_this_InvH.CurTyp = 1;
                                    }
                                }
                                catch
                                {
                                    data_this_InvH.CurTyp = null;
                                }
                                data_this_InvH.CommMnd_Inv = 0.0;
                                data_this_InvH.MndExtrnal = false;
                                data_this_InvH.CusVenNm = "";
                                data_this_InvH.CusVenNo = VarGeneral.RepData.Tables[0].Rows[iicnt]["CusVenNo"].ToString();
                                data_this_InvH.CusVenAdd = db.StockAccDefWithOutBalance(data_this_InvH.CusVenNo).Adders;
                                data_this_InvH.CusVenTel = db.StockAccDefWithOutBalance(data_this_InvH.CusVenNo).Telphone1;
                                data_this_InvH.CustNet = 0.0;
                                data_this_InvH.CustRep = 0.0;
                                data_this_InvH.Remark = "اثبات الكميات الموجودة عند المندوبين والعملاء والموردين خلال عملية اقفال سنة " + txtDateAlarm.Text + "  || اثبات الكميات الموجودة عند المندوبين والعملاء والموردين خلال عملية اقفال سنة " + txtDateAlarm.Text;
                                data_this_InvH.InvNo = InvStart;
                                data_this_InvH.CashPay = listDetNMnd.Sum((T_INVDET g) => g.Amount.Value);
                                data_this_InvH.AdminLock = false;
                                data_this_InvH.HDat = VarGeneral.Hdate;
                                data_this_InvH.GDat = VarGeneral.Gdate;
                                try
                                {
                                    data_this_InvH.InvCashPay = 0;
                                }
                                catch
                                {
                                    data_this_InvH.InvCashPay = 0;
                                }
                                data_this_InvH.InvCash = "أمر صرف";
                                data_this_InvH.InvCost = listDetNMnd.Sum((T_INVDET g) => g.Cost.Value) * listDetNMnd.Sum((T_INVDET g) => g.RealQty.Value);
                                data_this_InvH.InvCstNo = 1;
                                data_this_InvH.InvDisPrs = 0.0;
                                data_this_InvH.InvDisVal = 0.0;
                                data_this_InvH.InvDisValLocCur = 0.0;
                                data_this_InvH.InvNet = listDetNMnd.Sum((T_INVDET g) => g.Amount.Value);
                                data_this_InvH.InvNetLocCur = listDetNMnd.Sum((T_INVDET g) => g.Amount.Value);
                                data_this_InvH.InvQty = listDetNMnd.Sum((T_INVDET g) => g.Qty.Value);
                                data_this_InvH.InvTot = listDetNMnd.Sum((T_INVDET g) => g.Amount.Value);
                                data_this_InvH.InvTotLocCur = listDetNMnd.Sum((T_INVDET g) => g.Amount.Value);
                                data_this_InvH.InvTyp = VarGeneral.InvTyp;
                                data_this_InvH.IfDel = 0;
                                data_this_InvH.LTim = DateTime.Now.ToString("HH:mm");
                                data_this_InvH.MndNo = null;
                                data_this_InvH.IfEnter = 0;
                                data_this_InvH.PaymentOrderTyp = 1;
                                data_this_InvH.EstDat = "";
                                data_this_InvH.InvCashPayNm = "";
                                data_this_InvH.DeleteDate = "";
                                data_this_InvH.RefNo = "";
                                data_this_InvH.ArbTaf = "";
                                data_this_InvH.EngTaf = "";
                                data_this_InvH.DATE_MODIFIED = DateTime.Now;
                                data_this_InvH.CreditPay = 0.0;
                                data_this_InvH.NetworkPay = 0.0;
                                data_this_InvH.CashPayLocCur = listDetNMnd.Sum((T_INVDET g) => g.Amount.Value);
                                data_this_InvH.CreditPayLocCur = 0.0;
                                data_this_InvH.NetworkPayLocCur = 0.0;
                                data_this_InvH.Puyaid = 0.0;
                                data_this_InvH.Remming = 0.0;
                                data_this_InvH.CompanyID = 1;
                                data_this_InvH.tailor20 = "0";
                                data_this_InvH.RoomNo = 1;
                                data_this_InvH.OrderTyp = 1;
                                data_this_InvH.RoomSts = false;
                                data_this_InvH.RoomPerson = 1;
                                data_this_InvH.ServiceValue = 0.0;
                                data_this_InvH.Sts = false;
                                data_this_InvH.chauffeurNo = null;
                                data_this_InvH.InvAddTax = 0.0;
                                data_this_InvH.InvAddTaxlLoc = 0.0;
                                data_this_InvH.IsTaxUse = true;
                                data_this_InvH.IsTaxLines = true;
                                data_this_InvH.IsTaxByTotal = true;
                                data_this_InvH.IsTaxByNet = false;
                                data_this_InvH.TaxByNetValue = 0.0;
                                data_this_InvH.IsTaxGaid = false;
                                data_this_InvH.InvValGaidDis = 0.0;
                                data_this_InvH.InvValGaidDislLoc = 0.0;
                                data_this_InvH.IsDisUse1 = false;
                                data_this_InvH.IsDisGaid = false;
                                data_this_InvH.InvComm = 0.0;
                                data_this_InvH.InvCommLoc = 0.0;
                                data_this_InvH.IsCommUse = false;
                                data_this_InvH.IsCommGaid = false;
                                data_this_InvH.DesPointsValue = 0.0;
                                data_this_InvH.DesPointsValueLocCur = 0.0;
                                data_this_InvH.PointsCount = 0.0;
                                data_this_InvH.IsPoints = false;
                                stock_DataDataContext2.T_INVHEDs.InsertOnSubmit(data_this_InvH);
                                stock_DataDataContext2.SubmitChanges();
                                for (int iList = 0; iList < listDetNMnd.Count; iList++)
                                {
                                    listDetNMnd[iList].InvId = data_this_InvH.InvHed_ID;
                                    listDetNMnd[iList].InvSer = iList + 1;
                                    listDetNMnd[iList].InvNo = data_this_InvH.InvNo;
                                    stock_DataDataContext2.T_INVDETs.InsertOnSubmit(listDetNMnd[iList]);
                                    stock_DataDataContext2.SubmitChanges();
                                }
                            }
                        }
                        _RepShow = new RepShow();
                        _RepShow.Tables = " T_StoreMnd LEFT OUTER JOIN T_Items On T_Items.Itm_No = T_StoreMnd.itmNo LEFT OUTER JOIN  T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID  LEFT OUTER JOIN T_Mndob On T_StoreMnd.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_AccDef On T_StoreMnd.CusVenNo = T_AccDef.AccDef_No Left Join T_SYSSETTING ON T_Items.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                        Fields = " distinct  T_Items.*, T_StoreMnd.storeNo , T_StoreMnd.stkInt , T_StoreMnd.stkQty as x, T_Mndob.Mnd_No , T_Mndob.Arb_Des as MndNm ,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as UnitNm,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1  )as  UnitNm5,CASE WHEN T_Items.Unit1 = T_Items.Unit1 THEN (CASE WHEN  Pack1 > 0 THEN (T_StoreMnd.stkQty / Pack1) ElSE (0 ) END) WHEN T_Items.Unit2 = T_Items.Unit1 THEN (CASE WHEN  Pack2 > 0 THEN (T_StoreMnd.stkQty / Pack2) ElSE (0 ) END) WHEN T_Items.Unit3 = T_Items.Unit1 THEN (CASE WHEN  Pack3 > 0 THEN (T_StoreMnd.stkQty / Pack3) ElSE (0 ) END) WHEN T_Items.Unit4 = T_Items.Unit1 THEN (CASE WHEN  Pack4 > 0 THEN (T_StoreMnd.stkQty / Pack4) ElSE (0 ) END) WHEN T_Items.Unit5 = T_Items.Unit1 THEN (CASE WHEN  Pack5 > 0 THEN (T_StoreMnd.stkQty / Pack5) ElSE (0 ) END)END as stkQty  ,T_SYSSETTING.LogImg,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNmE ,T_StoreMnd.CusVenNo ";
                        _RepShow.Rule = " Where StkQty != 0  and ( T_StoreMnd.CusVenNo <> '' and T_AccDef.AccCat = 5 )  and T_Items.Unit1 = T_Items.Unit1 or  T_Items.Unit2 = T_Items.Unit1 or T_Items.Unit3 = T_Items.Unit1 or T_Items.Unit4 = T_Items.Unit1 or T_Items.Unit5 = T_Items.Unit1";
                        _RepShow.Fields = Fields;
                        try
                        {
                            _RepShow = _RepShow.Save();
                            VarGeneral.RepData = _RepShow.RepData;
                        }
                        catch (Exception ex2)
                        {
                            MessageBox.Show(ex2.Message);
                        }
                        if (VarGeneral.RepData.Tables[0].Rows.Count > 0)
                        {
                            List<string> MndData = (from myRow in VarGeneral.RepData.Tables[0].AsEnumerable()
                                                    select myRow.Field<string>("CusVenNo")).Distinct().ToList();
                            for (int iicnt = 0; iicnt < MndData.Count; iicnt++)
                            {
                                if (string.IsNullOrEmpty(VarGeneral.RepData.Tables[0].Rows[iicnt]["CusVenNo"].ToString()))
                                {
                                    continue;
                                }
                                List<T_INVDET> listDetNMnd = new List<T_INVDET>();
                                try
                                {
                                    InvStart = db.MaxInvheadNo.ToString();
                                }
                                catch
                                {
                                    InvStart = "1";
                                }
                                c = 0;
                                while (true)
                                {
                                    if (c >= VarGeneral.RepData.Tables[0].Rows.Count)
                                    {
                                        break;
                                    }
                                    if (VarGeneral.RepData.Tables[0].Rows[c]["CusVenNo"].ToString() == MndData[iicnt])
                                    {
                                        if (VarGeneral.CheckDate(dateLimit))
                                        {
                                            vCheckQty = 0.0;
                                            try
                                            {
                                                _RepShow = new RepShow();
                                                _RepShow.Tables = " T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                                                Fields = " MAX(T_Items.Itm_No ) as Itm_No , MAX(T_Items.Arb_Des ) as itemNm   , MAX( T_Category.Arb_Des ) as [CategoyNm] ,  SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) AS [Credit] ,  SUM (CASE WHEN T_InvDet.RealQty < 0 THEN ABS(T_InvDet.RealQty)  Else 0 END ) AS [Debit],MAX (T_SYSSETTING.LogImg) as LogImg  ,(SUM (CASE WHEN T_InvDet.RealQty < 0 THEN ABS(T_InvDet.RealQty)  Else 0 END ) - SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END )) as Balances,(select T_STKSQTY.stkQty from T_STKSQTY where T_STKSQTY.itmNo = T_Items.Itm_No and T_STKSQTY.storeNo = T_INVDET.StoreNo) as STQNow,T_INVDET.StoreNo";
                                                _RepShow.Rule = " Where " + (_IsHij ? (" T_INVHED.HDat > '" + dateLimit + "'") : (" T_INVHED.GDat > '" + dateLimit + "'")) + " and T_INVHED.CusVenNo <> '' and  T_INVHED.CusVenNo = '" + VarGeneral.RepData.Tables[0].Rows[c]["Mnd_No"].ToString() + "' and  T_INVDET.StoreNo = " + int.Parse(VarGeneral.RepData.Tables[0].Rows[c]["storeNo"].ToString()) + "  and  T_INVHED.IfDel != 1 and (T_INVHED.InvTyp = 17 or T_INVHED.InvTyp = 20) group by T_Items.Itm_No,T_INVDET.StoreNo Order by Itm_No ";
                                                _RepShow.Fields = Fields;
                                                _RepShow = _RepShow.Save();
                                                DataSet vQtyMnd = _RepShow.RepData;
                                                if (vQtyMnd.Tables[0].Rows.Count > 0)
                                                {
                                                    try
                                                    {
                                                        vCheckQty = double.Parse(VarGeneral.RepData.Tables[0].Rows[c]["stkQty"].ToString()) - double.Parse(VarGeneral.TString.TEmpty(vQtyMnd.Tables[0].Rows[i]["Balances"].ToString()));
                                                    }
                                                    catch
                                                    {
                                                        vCheckQty = 0.0;
                                                    }
                                                    if (!(vCheckQty > 0.0))
                                                    {
                                                        goto IL_6908;
                                                    }
                                                    VarGeneral.RepData.Tables[0].Rows[c]["stkQty"] = vCheckQty;
                                                }
                                            }
                                            catch
                                            {
                                            }
                                        }
                                        T_Item vItem = stock_DataDataContext2.T_Items.Where((T_Item t) => t.Itm_No == VarGeneral.RepData.Tables[0].Rows[c]["Itm_No"].ToString()).First();
                                        data_this_InvD = new T_INVDET();
                                        data_this_InvD.InvNo = InvStart;
                                        data_this_InvD.ItmNo = VarGeneral.RepData.Tables[0].Rows[c]["Itm_No"].ToString();
                                        data_this_InvD.Qty = double.Parse(VarGeneral.RepData.Tables[0].Rows[c]["stkQty"].ToString());
                                        data_this_InvD.ItmDes = vItem.Arb_Des;
                                        data_this_InvD.ItmDesE = vItem.Eng_Des;
                                        data_this_InvD.ItmUnt = vItem.T_Unit.Arb_Des;
                                        data_this_InvD.ItmUntE = vItem.T_Unit.Eng_Des;
                                        data_this_InvD.ItmUntPak = 1.0;
                                        data_this_InvD.StoreNo = int.Parse(VarGeneral.RepData.Tables[0].Rows[c]["storeNo"].ToString());
                                        data_this_InvD.Price = vItem.LastCost.Value;
                                        data_this_InvD.Amount = data_this_InvD.Qty.Value * data_this_InvD.Price.Value;
                                        data_this_InvD.RealQty = double.Parse(VarGeneral.RepData.Tables[0].Rows[c]["stkQty"].ToString());
                                        data_this_InvD.Cost = 0.0;
                                        data_this_InvD.itmInvDsc = 0.0;
                                        data_this_InvD.InvSer = c + 1;
                                        data_this_InvD.ItmIndex = 0;
                                        data_this_InvD.ItmTyp = vItem.ItmTyp.Value;
                                        data_this_InvD.DatExper = "";
                                        data_this_InvD.ItmDis = 0.0;
                                        data_this_InvD.ItmWight = 0.0;
                                        data_this_InvD.ItmWight_T = 0.0;
                                        data_this_InvD.RunCod = "";
                                        data_this_InvD.LineDetails = "";
                                        data_this_InvD.ItmTax = 0.0;
                                        listDetNMnd.Add(data_this_InvD);
                                    }
                                    goto IL_6908;
                                IL_6908:
                                    c++;
                                }
                                data_this_InvH = new T_INVHED();
                                try
                                {
                                    try
                                    {
                                        data_this_InvH.CurTyp = int.Parse(VarGeneral.Settings_Sys.ImportIp.ToString());
                                    }
                                    catch
                                    {
                                        data_this_InvH.CurTyp = 1;
                                    }
                                }
                                catch
                                {
                                    data_this_InvH.CurTyp = null;
                                }
                                data_this_InvH.CommMnd_Inv = 0.0;
                                data_this_InvH.MndExtrnal = false;
                                data_this_InvH.CusVenNm = "";
                                data_this_InvH.CusVenNo = VarGeneral.RepData.Tables[0].Rows[iicnt]["CusVenNo"].ToString();
                                data_this_InvH.CusVenAdd = db.StockAccDefWithOutBalance(data_this_InvH.CusVenNo).Adders;
                                data_this_InvH.CusVenTel = db.StockAccDefWithOutBalance(data_this_InvH.CusVenNo).Telphone1;
                                data_this_InvH.CustNet = 0.0;
                                data_this_InvH.CustRep = 0.0;
                                data_this_InvH.Remark = "اثبات الكميات الموجودة عند المندوبين والعملاء والموردين خلال عملية اقفال سنة " + txtDateAlarm.Text + "  || اثبات الكميات الموجودة عند المندوبين والعملاء والموردين خلال عملية اقفال سنة " + txtDateAlarm.Text;
                                data_this_InvH.InvNo = InvStart;
                                data_this_InvH.CashPay = listDetNMnd.Sum((T_INVDET g) => g.Amount.Value);
                                data_this_InvH.AdminLock = false;
                                data_this_InvH.HDat = VarGeneral.Hdate;
                                data_this_InvH.GDat = VarGeneral.Gdate;
                                try
                                {
                                    data_this_InvH.InvCashPay = 0;
                                }
                                catch
                                {
                                    data_this_InvH.InvCashPay = 0;
                                }
                                data_this_InvH.InvCash = "أمر صرف";
                                data_this_InvH.InvCost = listDetNMnd.Sum((T_INVDET g) => g.Cost.Value) * listDetNMnd.Sum((T_INVDET g) => g.RealQty.Value);
                                data_this_InvH.InvCstNo = 1;
                                data_this_InvH.InvDisPrs = 0.0;
                                data_this_InvH.InvDisVal = 0.0;
                                data_this_InvH.InvDisValLocCur = 0.0;
                                data_this_InvH.InvNet = listDetNMnd.Sum((T_INVDET g) => g.Amount.Value);
                                data_this_InvH.InvNetLocCur = listDetNMnd.Sum((T_INVDET g) => g.Amount.Value);
                                data_this_InvH.InvQty = listDetNMnd.Sum((T_INVDET g) => g.Qty.Value);
                                data_this_InvH.InvTot = listDetNMnd.Sum((T_INVDET g) => g.Amount.Value);
                                data_this_InvH.InvTotLocCur = listDetNMnd.Sum((T_INVDET g) => g.Amount.Value);
                                data_this_InvH.InvTyp = VarGeneral.InvTyp;
                                data_this_InvH.IfDel = 0;
                                data_this_InvH.LTim = DateTime.Now.ToString("HH:mm");
                                data_this_InvH.MndNo = null;
                                data_this_InvH.IfEnter = 0;
                                data_this_InvH.PaymentOrderTyp = 2;
                                data_this_InvH.EstDat = "";
                                data_this_InvH.InvCashPayNm = "";
                                data_this_InvH.DeleteDate = "";
                                data_this_InvH.RefNo = "";
                                data_this_InvH.ArbTaf = "";
                                data_this_InvH.EngTaf = "";
                                data_this_InvH.DATE_MODIFIED = DateTime.Now;
                                data_this_InvH.CreditPay = 0.0;
                                data_this_InvH.NetworkPay = 0.0;
                                data_this_InvH.CashPayLocCur = listDetNMnd.Sum((T_INVDET g) => g.Amount.Value);
                                data_this_InvH.CreditPayLocCur = 0.0;
                                data_this_InvH.NetworkPayLocCur = 0.0;
                                data_this_InvH.Puyaid = 0.0;
                                data_this_InvH.Remming = 0.0;
                                data_this_InvH.CompanyID = 1;
                                data_this_InvH.tailor20 = "0";
                                data_this_InvH.RoomNo = 1;
                                data_this_InvH.OrderTyp = 1;
                                data_this_InvH.RoomSts = false;
                                data_this_InvH.RoomPerson = 1;
                                data_this_InvH.ServiceValue = 0.0;
                                data_this_InvH.Sts = false;
                                data_this_InvH.chauffeurNo = null;
                                data_this_InvH.InvAddTax = 0.0;
                                data_this_InvH.InvAddTaxlLoc = 0.0;
                                data_this_InvH.IsTaxUse = true;
                                data_this_InvH.IsTaxLines = true;
                                data_this_InvH.IsTaxByTotal = true;
                                data_this_InvH.IsTaxByNet = false;
                                data_this_InvH.TaxByNetValue = 0.0;
                                data_this_InvH.IsTaxGaid = false;
                                data_this_InvH.InvValGaidDis = 0.0;
                                data_this_InvH.InvValGaidDislLoc = 0.0;
                                data_this_InvH.IsDisUse1 = false;
                                data_this_InvH.IsDisGaid = false;
                                data_this_InvH.InvComm = 0.0;
                                data_this_InvH.InvCommLoc = 0.0;
                                data_this_InvH.IsCommUse = false;
                                data_this_InvH.IsCommGaid = false;
                                data_this_InvH.DesPointsValue = 0.0;
                                data_this_InvH.DesPointsValueLocCur = 0.0;
                                data_this_InvH.PointsCount = 0.0;
                                data_this_InvH.IsPoints = false;
                                stock_DataDataContext2.T_INVHEDs.InsertOnSubmit(data_this_InvH);
                                stock_DataDataContext2.SubmitChanges();
                                for (int iList = 0; iList < listDetNMnd.Count; iList++)
                                {
                                    listDetNMnd[iList].InvId = data_this_InvH.InvHed_ID;
                                    listDetNMnd[iList].InvSer = iList + 1;
                                    listDetNMnd[iList].InvNo = data_this_InvH.InvNo;
                                    stock_DataDataContext2.T_INVDETs.InsertOnSubmit(listDetNMnd[iList]);
                                    stock_DataDataContext2.SubmitChanges();
                                }
                            }
                        }
                    }
                    else
                    {
                        db.ExecuteCommand(" Delete From T_STKSQTY ");
                        db.ExecuteCommand(" UPDATE T_Items SET  T_Items.OpenQty = 0 ");
                        db.ExecuteCommand(" Delete From T_StoreMnd ");
                        db.ExecuteCommand(" Delete From T_QTYEXP ");
                    }
                    if (chk4.Checked && chk4.Enabled)
                    {
                        db.ExecuteCommand(" Delete From T_Snd ");
                        db.ExecuteCommand(" Delete From T_tel ");
                        db.ExecuteCommand(" Delete From T_tran ");
                        db.ExecuteCommand(" UPDATE [T_Rom] SET [ch] = 0, [state] = 1, [row] = 1, [col] = 1, [wcno] = 0, [wc] = 0, [perno] = NULL, [bedno] = 0, [bed] = 0, [tv] = 0, [bl] = 0, [aline] = 1, [typ] = 0, [gropno] = 0, [price] = 0 , [hed] = 0, [tax] = 0, [ser] = 0, [dt] = N' ', [tm] = N' ', [pri0] = 0, [pri1] = 0, [pri2] = 0, [pri3] = 0, [priM0] = 0, [priM1] = 0, [ShortDsc] = N' ', [Numcounter] = N' ', [CompanyID] = 1,[Furnished] = 0,[AreaDetail] = '',[RoomCount] = 1,[loungesCount] = 0,[kitchensCount] = 0");
                        db.ExecuteCommand(" Delete From T_per1 ");
                        db.ExecuteCommand(" Delete From T_per ");
                        db.ExecuteCommand(" Delete From T_Reserv ");
                        db.ExecuteCommand(" Delete From T_romtrn ");
                    }
                    if (chk3.Checked && chk3.Enabled)
                    {
                        db.ExecuteCommand(" Delete T_Snd From T_per INNER JOIN T_Snd ON T_per.perno = T_Snd.perno where T_per.ch = 3 ");
                        db.ExecuteCommand(" Delete T_tel From T_per INNER JOIN T_tel ON T_per.perno = T_tel.perno where T_per.ch = 3 ");
                        db.ExecuteCommand(" Delete T_tran From T_per INNER JOIN T_tran ON T_per.perno = T_tran.perno where T_per.ch = 3 ");
                        db.ExecuteCommand(" Delete T_romtrn From T_per INNER JOIN T_romtrn ON T_per.perno = T_romtrn.perno where T_per.ch = 3 ");
                        db.ExecuteCommand(" Delete T_per1 From T_per INNER JOIN T_per1 ON T_per.perno = T_per1.perno where T_per.ch = 3 ");
                        db.ExecuteCommand(" Delete T_per From T_per where T_per.ch = 3 ");
                    }
                    Stock_DataDataContext RDB = new Stock_DataDataContext(VarGeneral.BranchCS);
                    try
                    {
                        if (chk5.Checked)
                        {
                            List<T_AccDef> GuestData = RDB.FillAccDefwithLev_2(11, 4).ToList();
                            List<T_AccDef> results = (from t1 in GuestData
                                                      where !RDB.T_GDDETs.Select((T_GDDET t2) => t2.AccNo).Contains(t1.AccDef_No)
                                                      where !RDB.T_pers.Select((T_per t3) => t3.Cust_no).Contains(t1.AccDef_No)
                                                      select t1).ToList();
                            for (int l = 0; l < results.Count; l++)
                            {
                                RDB.ExecuteCommand("delete from T_AccDef where AccDef_No = '" + results[l].AccDef_No.Trim() + "'");
                            }
                        }
                        try
                        {
                            RDB.ExecuteCommand("UPDATE T_tran SET IsGaid = 0 , GadeId = null ,GadeNo = 0 where T_tran.IsGaid =1 and T_tran.GadeId not in (select T_GDHEAD.gdhead_ID from T_GDHEAD where T_GDHEAD.gdLok = 0 and T_GDHEAD.gdTyp = 15) ");
                        }
                        catch
                        {
                        }
                        try
                        {
                            RDB.ExecuteCommand("UPDATE T_tel SET IsGaid = 0 , GadeId = null ,GadeNo = 0 where T_tel.IsGaid =1 and T_tel.GadeId not in (select T_GDHEAD.gdhead_ID from T_GDHEAD where T_GDHEAD.gdLok = 0 and T_GDHEAD.gdTyp = 15) ");
                        }
                        catch
                        {
                        }
                        try
                        {
                            RDB.ExecuteCommand("UPDATE T_Snd SET  GadeId = null ,GadeNo = 0 where T_Snd.typ = 1 and T_Snd.GadeId not in (select T_GDHEAD.gdhead_ID from T_GDHEAD where T_GDHEAD.gdLok = 0 and T_GDHEAD.gdTyp = 27) ");
                        }
                        catch
                        {
                        }
                        try
                        {
                            RDB.ExecuteCommand("UPDATE T_Snd SET  GadeId = null ,GadeNo = 0 where T_Snd.typ = 2 and T_Snd.GadeId not in (select T_GDHEAD.gdhead_ID from T_GDHEAD where T_GDHEAD.gdLok = 0 and T_GDHEAD.gdTyp = 28) ");
                        }
                        catch
                        {
                        }
                    }
                    finally
                    {
                        if (RDB != null)
                        {
                            ((IDisposable)RDB).Dispose();
                        }
                    }
                    if (!VarGeneral.CheckDate(dateLimit))
                    {
                        continue;
                    }
                    _RepairQty(RunDate: false, Genral: false);
                    Stock_DataDataContext stock_DataDataContext = new Stock_DataDataContext(VarGeneral.BranchCS);
                    stock_DataDataContext.ExecuteCommand("UPDATE T_AccDef SET  T_AccDef.Debit = 0,T_AccDef.Credit = 0,T_AccDef.Balance = 0 ");
                    List<T_AccDef> updateBalance = db.FillAccDef_2("").ToList();
                    for (int y = 0; y < updateBalance.Count; y++)
                    {
                        try
                        {
                            stock_DataDataContext.ExecuteCommand("UPDATE T_AccDef SET  T_AccDef.Debit = CASE WHEN (select sum(Round(T_GDDET.gdValue," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) from T_GDDET INNER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID where T_GDHEAD.gdLok = 0 and T_GDDET.gdValue > 0 and T_GDDET.AccNo ='" + updateBalance[y].AccDef_No + "') >0 THEN  (select sum(Round(T_GDDET.gdValue," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) from T_GDDET INNER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID where T_GDHEAD.gdLok = 0 and T_GDDET.gdValue > 0 and T_GDDET.AccNo ='" + updateBalance[y].AccDef_No + "') else 0 end  from T_AccDef where T_AccDef.AccDef_No = '" + updateBalance[y].AccDef_No + "'");
                            stock_DataDataContext.ExecuteCommand("UPDATE T_AccDef SET  T_AccDef.Credit = CASE WHEN (select sum(Round(T_GDDET.gdValue," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) from T_GDDET INNER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID where T_GDHEAD.gdLok = 0 and T_GDDET.gdValue < 0 and T_GDDET.AccNo ='" + updateBalance[y].AccDef_No + "') <0 THEN  (select sum(Round(abs(T_GDDET.gdValue)," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) from T_GDDET INNER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID where T_GDHEAD.gdLok = 0 and T_GDDET.gdValue < 0 and T_GDDET.AccNo ='" + updateBalance[y].AccDef_No + "') else 0 end  from T_AccDef where T_AccDef.AccDef_No = '" + updateBalance[y].AccDef_No + "'");
                            stock_DataDataContext.ExecuteCommand("UPDATE T_AccDef SET T_AccDef.Balance = T_AccDef.Debit - T_AccDef.Credit ");
                        }
                        catch
                        {
                        }
                    }
                }
                MessageBox.Show((LangArEn == 0) ? " تم عملية الإقفال بنجاح.. سيتم إعادة تشغيل النظام الان " : "Closing Data is successfully .. will be Restart the system now ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                string arguments = string.Empty;
                string[] args = Environment.GetCommandLineArgs();
                for (int i = 1; i < args.Length; i++)
                {
                    arguments = arguments + args[i] + " ";
                }
                Application.ExitThread();
                Process.Start(Application.ExecutablePath, arguments);
            }
            catch (Exception error2)
            {
                VarGeneral.DebLog.writeLog("ButOk_Click:", error2, enable: true);
                MessageBox.Show(error2.Message);
            }
        }
        private void _RepairQty(bool RunDate, bool Genral)
        {
            try
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                string Fields = " MAX(T_Items.Itm_No ) as Itm_No , MAX(T_Items.Arb_Des ) as itemNm   , MAX( T_Category.Arb_Des ) as [CategoyNm] ,  SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) AS [Credit] ,  SUM (CASE WHEN T_InvDet.RealQty < 0 THEN ABS(T_InvDet.RealQty)  Else 0 END ) AS [Debit],MAX (T_SYSSETTING.LogImg) as LogImg  ,(SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) - SUM (CASE WHEN T_InvDet.RealQty < 0 THEN ABS(T_InvDet.RealQty)  Else 0 END )) as Balances,(select T_STKSQTY.stkQty from T_STKSQTY where T_STKSQTY.itmNo = T_Items.Itm_No and T_STKSQTY.storeNo = T_INVDET.StoreNo) as STQNow,T_INVDET.StoreNo";
                _RepShow.Rule = " Where " + ((!RunDate || Genral) ? " 1 = 1 " : (_IsHij ? (" T_INVHED.HDat <= '" + dateLimit + "'") : (" T_INVHED.GDat <= '" + dateLimit + "'"))) + " and T_INVHED.InvTyp != 21 and T_INVHED.InvTyp != 7 and T_INVHED.InvTyp != 8 and T_INVHED.InvTyp != 9 and  T_INVHED.IfDel != 1 and T_Items.ItmTyp != 2 and T_Items.ItmTyp != 3 and (T_INVHED.PaymentOrderTyp = 0 or ( T_INVHED.InvTyp = 17 or T_INVHED.InvTyp = 20))  group by T_Items.Itm_No,T_INVDET.StoreNo Order by Itm_No ";
                _RepShow.Fields = Fields;
                try
                {
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (VarGeneral.RepData.Tables[0].Rows.Count <= 0)
                {
                    return;
                }
                double t2 = 0.0;
                for (int j = 0; j < VarGeneral.RepData.Tables[0].Rows.Count; j++)
                {
                    t2 = 0.0;
                    try
                    {
                        t2 = double.Parse(VarGeneral.TString.TEmpty(VarGeneral.RepData.Tables[0].Rows[j]["Balances"].ToString()));
                    }
                    catch
                    {
                        t2 = 0.0;
                    }
                    try
                    {
                        if (!string.IsNullOrEmpty(VarGeneral.RepData.Tables[0].Rows[j]["Itm_No"].ToString()))
                        {
                            db.ExecuteCommand(string.Concat("  UPDATE T_STKSQTY SET T_STKSQTY.stkQty = ", t2, " From T_STKSQTY where T_STKSQTY.storeNo = ", VarGeneral.RepData.Tables[0].Rows[j]["StoreNo"], " and  T_STKSQTY.itmNo ='", VarGeneral.RepData.Tables[0].Rows[j]["Itm_No"].ToString(), "'"));
                        }
                    }
                    catch
                    {
                    }
                }
                if (RunDate || Genral)
                {
                    return;
                }
                int i;
                for (i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
                {
                    t2 = 0.0;
                    try
                    {
                        t2 = db.T_STKSQTies.Where((T_STKSQTY t) => t.itmNo == VarGeneral.RepData.Tables[0].Rows[i]["Itm_No"].ToString()).ToList().Sum((T_STKSQTY g) => g.stkQty.Value);
                    }
                    catch
                    {
                        t2 = 0.0;
                    }
                    db.ExecuteCommand("  UPDATE T_Items SET T_Items.OpenQty = " + t2 + " From T_Items where T_Items.Itm_No ='" + VarGeneral.RepData.Tables[0].Rows[i]["Itm_No"].ToString() + "'");
                }
            }
            catch
            {
            }
        }
        private double Mezaniya(int acc1, int acc2)
        {
            double Tot = 0.0;
            Tot = ((!chk6.Checked) ? Arbah() : 0.0);
            DataThis = new TmpTbl();
            db.ExecuteCommand("delete from TmpTbl ");
            data_this.AccNo = acc1.ToString();
            data_this.AccNm = ((LangArEn == 0) ? "صافي الربح" : "Net Profits");
            data_this.Num4 = Tot;
            data_this.Num1 = 0.0;
            data_this.Num2 = 0.0;
            data_this.Num3 = 0.0;
            db.TmpTbls.InsertOnSubmit(data_this);
            db.SubmitChanges();
            db.ExecuteCommand("insert into TmpTbl ( AccNo, AccNm, Num3, Num4 ) SELECT T_AccDef.AccDef_No, T_AccDef.Arb_Des,Round( Sum(CASE WHEN T_GDDET.gdValue>0 THEN T_GDDET.gdValue ELSE 0 END)," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") AS Expr1, Round( Sum(CASE WHEN T_GDDET.gdValue<0 THEN Abs(T_GDDET.gdValue) ELSE 0 END)," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") AS Expr2 FROM (T_GDHEAD RIGHT JOIN T_GDDET ON T_GDHEAD.gdhead_ID = T_GDDET.gdID) LEFT JOIN T_AccDef ON T_GDDET.AccNo  = T_AccDef.AccDef_No where " + ((!VarGeneral.CheckDate(dateLimit)) ? " 1 = 1 " : (_IsHij ? (" gdHDate <= '" + dateLimit + "'") : (" gdGDate <= '" + dateLimit + "'"))) + " and T_GDHEAD.gdLok=0 and (" + (chk6.Checked ? " T_AccDef.Trn=1 or T_AccDef.Trn=2 or T_AccDef.Trn=3 " : " T_AccDef.Trn=3 ") + ") and T_AccDef.lev=4 " + WherTmp + " GROUP BY T_AccDef.AccDef_No, T_AccDef.Arb_Des ");
            db.ExecuteCommand("UPDATE TmpTbl SET TmpTbl.Num1 = CASE WHEN TmpTbl.Num3-TmpTbl.Num4>0 THEN TmpTbl.Num3-TmpTbl.Num4 ELSE 0 END , TmpTbl.Num2 = CASE WHEN TmpTbl.Num3-TmpTbl.Num4<0 THEN Abs(TmpTbl.Num3-TmpTbl.Num4) ElSE 0 END ");
            db.ExecuteCommand("UPDATE TmpTbl SET TmpTbl.AccNm = T_AccDef.Arb_Des, TmpTbl.AccNo = T_AccDef.AccDef_No from  TmpTbl RIGHT JOIN T_AccDef ON TmpTbl.AccNo = T_AccDef.AccDef_No where T_AccDef.lev=4 and (" + (chk6.Checked ? " T_AccDef.Trn=1 or T_AccDef.Trn=2 or T_AccDef.Trn=3 " : " T_AccDef.Trn=3 ") + ")");
            DataThis = new TmpTbl();
            double DD = 0.0;
            try
            {
                List<double> q = db.ExecuteQuery<double>("Select  Round(Sum((T_Items.AvrageCost * T_STKSQTY.stkQty))," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") As AMT FROM T_Items INNER JOIN T_STKSQTY ON T_Items.Itm_No = T_STKSQTY.itmNo", new object[0]).ToList();
                DD = ((q.Count <= 0) ? 0.0 : q.First());
            }
            catch
            {
                DD = 0.0;
            }
            data_this.AccNo = acc2.ToString();
            data_this.AccNm = ((LangArEn == 0) ? "بضاعة اخر المدة" : "Net Stock Value");
            data_this.Num4 = DD;
            data_this.Num1 = DD;
            data_this.Num2 = 0.0;
            data_this.Num3 = 0.0;
            db.TmpTbls.InsertOnSubmit(data_this);
            db.SubmitChanges();
            double S2 = 0.0;
            double S3 = 0.0;
            try
            {
                List<double> q = db.ExecuteQuery<double>("Select sum(num1) as S2 FROM TmpTbl", new object[0]).ToList();
                S2 = ((q.Count <= 0) ? 0.0 : q.First());
            }
            catch
            {
                S2 = 0.0;
            }
            try
            {
                List<double> q = db.ExecuteQuery<double>("Select sum(num2) as S3 FROM TmpTbl", new object[0]).ToList();
                S3 = ((q.Count <= 0) ? 0.0 : q.First());
            }
            catch
            {
                S3 = 0.0;
            }
            TotM = S3;
            return S3 - S2;
        }
        private double Arbah()
        {
            double Tot = 0.0;
            Tot = Motajara();
            DataThis = new TmpTbl();
            db.ExecuteCommand("delete from TmpTbl ");
            data_this.AccNo = "";
            data_this.AccNm = ((LangArEn == 0) ? "أرباح السنة" : "Profits This Year");
            data_this.Num4 = Tot;
            data_this.Num1 = 0.0;
            data_this.Num2 = 0.0;
            data_this.Num3 = 0.0;
            db.TmpTbls.InsertOnSubmit(data_this);
            db.SubmitChanges();
            db.ExecuteCommand("insert into TmpTbl ( AccNo, AccNm, Num3, Num4 ) SELECT T_AccDef.AccDef_No, T_AccDef.Arb_Des,Round(Sum(CASE WHEN T_GDDET.gdValue>0 THEN T_GDDET.gdValue ELSE 0 END)," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") AS Expr1,Round( Sum(CASE WHEN T_GDDET.gdValue<0 THEN Abs(T_GDDET.gdValue) ELSE 0 END)," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") AS Expr2 FROM (T_GDHEAD RIGHT JOIN T_GDDET ON T_GDHEAD.gdhead_ID = T_GDDET.gdID) LEFT JOIN T_AccDef ON T_GDDET.AccNo  = T_AccDef.AccDef_No where " + ((!VarGeneral.CheckDate(dateLimit)) ? " 1 = 1 " : (_IsHij ? (" gdHDate <= '" + dateLimit + "'") : (" gdGDate <= '" + dateLimit + "'"))) + " and T_GDHEAD.gdLok=0 and T_AccDef.Trn=2 and T_AccDef.lev=4 " + WherTmp + " GROUP BY T_AccDef.AccDef_No, T_AccDef.Arb_Des ");
            db.ExecuteCommand("UPDATE TmpTbl SET TmpTbl.Num1 = CASE WHEN TmpTbl.Num3-TmpTbl.Num4>0 THEN TmpTbl.Num3-TmpTbl.Num4 ELSE 0 END , TmpTbl.Num2 = CASE WHEN TmpTbl.Num3-TmpTbl.Num4<0 THEN Abs(TmpTbl.Num3-TmpTbl.Num4) ElSE 0 END ");
            db.ExecuteCommand("UPDATE TmpTbl SET TmpTbl.AccNm = T_AccDef.Arb_Des, TmpTbl.AccNo = T_AccDef.AccDef_No from  TmpTbl RIGHT JOIN T_AccDef ON TmpTbl.AccNo = T_AccDef.AccDef_No where T_AccDef.lev=4 and T_AccDef.Trn=2");
            double S2 = 0.0;
            double S3 = 0.0;
            try
            {
                List<double> q = db.ExecuteQuery<double>("Select sum(num1) as S2 FROM TmpTbl", new object[0]).ToList();
                S2 = ((q.Count <= 0) ? 0.0 : q.First());
            }
            catch
            {
                S2 = 0.0;
            }
            try
            {
                List<double> q = db.ExecuteQuery<double>("Select sum(num2) as S3 FROM TmpTbl", new object[0]).ToList();
                S3 = ((q.Count <= 0) ? 0.0 : q.First());
            }
            catch
            {
                S3 = 0.0;
            }
            return S3 - S2;
        }
        private double Motajara()
        {
            DataThis = new TmpTbl();
            db.ExecuteCommand("delete from TmpTbl ");
            db.ExecuteCommand("insert into TmpTbl ( AccNo, AccNm, Num3, Num4 ) SELECT T_AccDef.AccDef_No, T_AccDef.Arb_Des,Round( Sum(CASE WHEN T_GDDET.gdValue>0 THEN T_GDDET.gdValue ELSE 0 END)," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") AS Expr1,Round( Sum(CASE WHEN T_GDDET.gdValue<0 THEN Abs(T_GDDET.gdValue) ELSE 0 END)," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") AS Expr2 FROM (T_GDHEAD RIGHT JOIN T_GDDET ON T_GDHEAD.gdhead_ID = T_GDDET.gdID) LEFT JOIN T_AccDef ON T_GDDET.AccNo  = T_AccDef.AccDef_No where " + ((!VarGeneral.CheckDate(dateLimit)) ? " 1 = 1 " : (_IsHij ? (" gdHDate <= '" + dateLimit + "'") : (" gdGDate <= '" + dateLimit + "'"))) + " and T_GDHEAD.gdLok=0 and T_AccDef.Trn=1 and T_AccDef.lev=4 " + WherTmp + " GROUP BY T_AccDef.AccDef_No, T_AccDef.Arb_Des ");
            db.ExecuteCommand("UPDATE TmpTbl SET TmpTbl.Num1 = CASE WHEN TmpTbl.Num3-TmpTbl.Num4>0 THEN TmpTbl.Num3-TmpTbl.Num4 ELSE 0 END , TmpTbl.Num2 = CASE WHEN TmpTbl.Num3-TmpTbl.Num4<0 THEN Abs(TmpTbl.Num3-TmpTbl.Num4) ElSE 0 END ");
            db.ExecuteCommand("UPDATE TmpTbl SET TmpTbl.AccNm = T_AccDef.Arb_Des, TmpTbl.AccNo = T_AccDef.AccDef_No from  TmpTbl RIGHT JOIN T_AccDef ON TmpTbl.AccNo = T_AccDef.AccDef_No where T_AccDef.lev=4 and T_AccDef.Trn=1");
            double DD = 0.0;
            try
            {
                List<double> q = db.ExecuteQuery<double>("Select  Round(Sum((T_Items.AvrageCost * T_STKSQTY.stkQty))," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") As AMT FROM T_Items INNER JOIN T_STKSQTY ON T_Items.Itm_No = T_STKSQTY.itmNo", new object[0]).ToList();
                DD = ((q.Count <= 0) ? 0.0 : q.First());
            }
            catch
            {
                DD = 0.0;
            }
            data_this.AccNo = "";
            data_this.AccNm = ((LangArEn == 0) ? "بضاعة اخر المدة" : "Net Stock Value");
            data_this.Num4 = DD;
            data_this.Num2 = DD;
            data_this.Num1 = 0.0;
            data_this.Num3 = 0.0;
            db.TmpTbls.InsertOnSubmit(data_this);
            db.SubmitChanges();
            double S2 = 0.0;
            double S3 = 0.0;
            try
            {
                List<double> q = db.ExecuteQuery<double>("Select sum(num1) as S2 FROM TmpTbl", new object[0]).ToList();
                S2 = ((q.Count <= 0) ? 0.0 : q.First());
            }
            catch
            {
                S2 = 0.0;
            }
            try
            {
                List<double> q = db.ExecuteQuery<double>("Select sum(num2) as S3 FROM TmpTbl", new object[0]).ToList();
                S3 = ((q.Count <= 0) ? 0.0 : q.First());
            }
            catch
            {
                S3 = 0.0;
            }
            return S3 - S2;
        }
        private void ButExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void FrmEndYear_KeyUp(object sender, KeyEventArgs e)
        {
        }
        private void FrmEndYear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && ButOk.Enabled && ButOk.Visible)
            {
                ButOk_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void FrmEndYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void txtDateAlarm_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtDateAlarm.Value + "/01/01"))
                {
                    _Year = txtDateAlarm.Value.ToString();
                }
                else
                {
                    _Year = VarGeneral.Gdate.Substring(0, 4);
                }
            }
            catch
            {
                _Year = VarGeneral.Gdate.Substring(0, 4);
            }
            GET_Path();
        }
        private void chk4_CheckedChanged(object sender, EventArgs e)
        {
            chk3.Enabled = !chk4.Checked;
        }
        private void chk3_CheckedChanged(object sender, EventArgs e)
        {
            chk4.Enabled = !chk3.Checked;
        }
        private void chk6_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void txtDateDay_LockUpdateChanged(object sender, EventArgs e)
        {
            txtDateMonth.LockUpdateChecked = txtDateDay.LockUpdateChecked;
            txtDateMonth.Enabled = txtDateMonth.LockUpdateChecked;
            if (txtDateDay.LockUpdateChecked)
            {
                label3.Text = ((LangArEn == 0) ? "إقفال حتى تاريخ " : "Close To Date ");
                chk1.Checked = true;
                chk2.Checked = true;
                chk1.Enabled = false;
                chk2.Enabled = false;
            }
            else
            {
                label3.Text = ((LangArEn == 0) ? "إقفال كامل للبيانات" : "Close All Data");
                chk1.Enabled = true;
                chk2.Enabled = true;
            }
        }
        private void switchButton_CloseOption_ValueChanged(object sender, EventArgs e)
        {
            if (switchButton_CloseOption.Value)
            {
                FlexType.AllowEditing = true;
            }
            else
            {
                FlexType.AllowEditing = false;
            }
            for (int i = 0; i < FlexType.Rows.Count; i++)
            {
                FlexType.SetData(i, 0, true);
            }
        }
    }
}
