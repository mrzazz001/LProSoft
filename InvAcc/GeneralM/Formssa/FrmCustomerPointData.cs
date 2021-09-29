using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Library.RepShow;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmCustomerPointData : Form
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
            panel1.BringToFront();
        }
        private void FrmInvSale_SizeChanged(object sender, EventArgs e)
        {
            netResize1.Refresh();
        }
        public Softgroup.NetResize.NetResize netResize1;
        public TextBox txtCustNo;
        public TextBox txtCustName;
        public Panel panel1;
        public LabelX labelHeader;
        public ButtonX buttonX_Close;
        public ButtonX buttonX_Ok;
        public Label label4;
        public Label label1;
        public DoubleInput txtTotalPointAvalible;
        public Label label3;
        public DoubleInput txtTotalPointUsed;
        public Label label2;
        public DoubleInput txtTotalPointAll;
        public Label Label26;
        public DoubleInput txtDueAmountLoc;
        public Label label5;
        public DoubleInput txtDiscoundPointsValue;
        public Label lablPoint;
        public DoubleInput txtDiscoundPoints;
        public Label label9;
        public Line line1;
        public Label lablCurr;
        public DoubleInput txtTotalPointAvalibleValue;
        public Label label10;
        public Label label8;
        public Label label7;
        public Label label6;
        public Label lablCurr2;
        public Label label11;
        public DoubleInput txtTotalPointReturn;
        public Label label12;
        private ButtonX button_SrchCustNo;
        public ButtonX button_ItemMovementPoint;
        public Label label13;
        public DoubleInput txtTotalPointsOld;
        public Label label14;
        public ButtonX buttonX_RepPointAll;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private int LangArEn = 0;
        public bool IsDone = false;
        private Stock_DataDataContext dbInstance;
        private bool Rep_ = false;
        private bool IsEdit_ = false;
        private int InvID_ = 0;
        private double DiscoundPointsVal_ = 0.0;
        public double totPointsIn = 0.0;
        public double totPointsOut = 0.0;
        public double totPoints = 0.0;
        public double _PointUseIn = 0.0;
        public double _PointUseOut = 0.0;
        public double totPointUse = 0.0;
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonX_RepPointAll = new DevComponents.DotNetBar.ButtonX();
            this.button_ItemMovementPoint = new DevComponents.DotNetBar.ButtonX();
            this.buttonX_Close = new DevComponents.DotNetBar.ButtonX();
            this.buttonX_Ok = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchCustNo = new DevComponents.DotNetBar.ButtonX();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTotalPointReturn = new DevComponents.Editors.DoubleInput();
            this.label12 = new System.Windows.Forms.Label();
            this.lablCurr2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lablCurr = new System.Windows.Forms.Label();
            this.txtTotalPointAvalibleValue = new DevComponents.Editors.DoubleInput();
            this.label10 = new System.Windows.Forms.Label();
            this.lablPoint = new System.Windows.Forms.Label();
            this.txtDiscoundPoints = new DevComponents.Editors.DoubleInput();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDiscoundPointsValue = new DevComponents.Editors.DoubleInput();
            this.label5 = new System.Windows.Forms.Label();
            this.Label26 = new System.Windows.Forms.Label();
            this.txtDueAmountLoc = new DevComponents.Editors.DoubleInput();
            this.txtTotalPointAvalible = new DevComponents.Editors.DoubleInput();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalPointUsed = new DevComponents.Editors.DoubleInput();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalPointAll = new DevComponents.Editors.DoubleInput();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustNo = new System.Windows.Forms.TextBox();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelHeader = new DevComponents.DotNetBar.LabelX();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTotalPointsOld = new DevComponents.Editors.DoubleInput();
            this.label14 = new System.Windows.Forms.Label();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPointReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPointAvalibleValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscoundPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscoundPointsValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDueAmountLoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPointAvalible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPointUsed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPointAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPointsOld)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonX_RepPointAll);
            this.panel1.Controls.Add(this.button_ItemMovementPoint);
            this.panel1.Controls.Add(this.buttonX_Close);
            this.panel1.Controls.Add(this.buttonX_Ok);
            this.panel1.Controls.Add(this.button_SrchCustNo);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtTotalPointReturn);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.lablCurr2);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lablCurr);
            this.panel1.Controls.Add(this.txtTotalPointAvalibleValue);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.lablPoint);
            this.panel1.Controls.Add(this.txtDiscoundPoints);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtDiscoundPointsValue);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.Label26);
            this.panel1.Controls.Add(this.txtDueAmountLoc);
            this.panel1.Controls.Add(this.txtTotalPointAvalible);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtTotalPointUsed);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtTotalPointAll);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtCustNo);
            this.panel1.Controls.Add(this.txtCustName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.labelHeader);
            this.panel1.Controls.Add(this.line1);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtTotalPointsOld);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(446, 334);
            this.panel1.TabIndex = 859;
            // 
            // buttonX_RepPointAll
            // 
            this.buttonX_RepPointAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_RepPointAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX_RepPointAll.Checked = true;
            this.buttonX_RepPointAll.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta;
            this.buttonX_RepPointAll.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonX_RepPointAll.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.buttonX_RepPointAll.Location = new System.Drawing.Point(235, 161);
            this.buttonX_RepPointAll.Name = "buttonX_RepPointAll";
            this.buttonX_RepPointAll.Size = new System.Drawing.Size(203, 39);
            this.buttonX_RepPointAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_RepPointAll.TabIndex = 1141;
            this.buttonX_RepPointAll.Text = "تقرير بإجمالي النقاط المستحقة والمرتجعة حسب كل فاتورة";
            this.buttonX_RepPointAll.TextColor = System.Drawing.Color.Black;
            this.buttonX_RepPointAll.Click += new System.EventHandler(this.buttonX_RepPointAll_Click);
            // 
            // button_ItemMovementPoint
            // 
            this.button_ItemMovementPoint.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_ItemMovementPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ItemMovementPoint.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.button_ItemMovementPoint.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button_ItemMovementPoint.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.button_ItemMovementPoint.Location = new System.Drawing.Point(235, 203);
            this.button_ItemMovementPoint.Name = "button_ItemMovementPoint";
            this.button_ItemMovementPoint.Size = new System.Drawing.Size(203, 66);
            this.button_ItemMovementPoint.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_ItemMovementPoint.TabIndex = 1137;
            this.button_ItemMovementPoint.Text = "تقرير تفصـــيلي بالنقاط المستحقة حسب حركة الأصناف";
            this.button_ItemMovementPoint.TextColor = System.Drawing.Color.Black;
            this.button_ItemMovementPoint.Visible = false;
            this.button_ItemMovementPoint.VisibleChanged += new System.EventHandler(this.button_ItemMovementPoint_VisibleChanged);
            this.button_ItemMovementPoint.Click += new System.EventHandler(this.button_ItemMovementPoint_Click);
            // 
            // buttonX_Close
            // 
            this.buttonX_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX_Close.Checked = true;
            this.buttonX_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_Close.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonX_Close.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.buttonX_Close.Location = new System.Drawing.Point(30, 272);
            this.buttonX_Close.Name = "buttonX_Close";
            this.buttonX_Close.Size = new System.Drawing.Size(203, 39);
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
            this.buttonX_Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX_Ok.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX_Ok.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonX_Ok.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.buttonX_Ok.Location = new System.Drawing.Point(235, 272);
            this.buttonX_Ok.Name = "buttonX_Ok";
            this.buttonX_Ok.Size = new System.Drawing.Size(203, 39);
            this.buttonX_Ok.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Ok.TabIndex = 2;
            this.buttonX_Ok.Text = "موافــــق";
            this.buttonX_Ok.TextColor = System.Drawing.Color.White;
            this.buttonX_Ok.Click += new System.EventHandler(this.buttonX_Ok_Click);
            // 
            // button_SrchCustNo
            // 
            this.button_SrchCustNo.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.button_SrchCustNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_SrchCustNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCustNo.Location = new System.Drawing.Point(28, 24);
            this.button_SrchCustNo.Name = "button_SrchCustNo";
            this.button_SrchCustNo.Size = new System.Drawing.Size(64, 21);
            this.button_SrchCustNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCustNo.Symbol = "";
            this.button_SrchCustNo.SymbolSize = 12F;
            this.button_SrchCustNo.TabIndex = 1136;
            this.button_SrchCustNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCustNo.Visible = false;
            this.button_SrchCustNo.Click += new System.EventHandler(this.button_SrchCustNo_Click);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(31, 115);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 21);
            this.label11.TabIndex = 1135;
            this.label11.Text = "نقطــــة";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.txtTotalPointReturn.Location = new System.Drawing.Point(96, 115);
            this.txtTotalPointReturn.Name = "txtTotalPointReturn";
            this.txtTotalPointReturn.Size = new System.Drawing.Size(137, 21);
            this.txtTotalPointReturn.TabIndex = 1134;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(235, 115);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(203, 20);
            this.label12.TabIndex = 1133;
            this.label12.Text = "إجمالي النقاط المرتجعــــة";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lablCurr2
            // 
            this.lablCurr2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lablCurr2.BackColor = System.Drawing.Color.White;
            this.lablCurr2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lablCurr2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lablCurr2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lablCurr2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lablCurr2.Location = new System.Drawing.Point(31, 226);
            this.lablCurr2.Name = "lablCurr2";
            this.lablCurr2.Size = new System.Drawing.Size(64, 21);
            this.lablCurr2.TabIndex = 1132;
            this.lablCurr2.Text = "ريــال";
            this.lablCurr2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(31, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 21);
            this.label8.TabIndex = 1131;
            this.label8.Text = "نقطــــة";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(31, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 21);
            this.label7.TabIndex = 1130;
            this.label7.Text = "نقطــــة";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(31, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 21);
            this.label6.TabIndex = 1129;
            this.label6.Text = "نقطــــة";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lablCurr
            // 
            this.lablCurr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lablCurr.BackColor = System.Drawing.Color.White;
            this.lablCurr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lablCurr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lablCurr.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lablCurr.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lablCurr.Location = new System.Drawing.Point(31, 161);
            this.lablCurr.Name = "lablCurr";
            this.lablCurr.Size = new System.Drawing.Size(64, 21);
            this.lablCurr.TabIndex = 1128;
            this.lablCurr.Text = "ريــال";
            this.lablCurr.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtTotalPointAvalibleValue
            // 
            this.txtTotalPointAvalibleValue.AllowEmptyState = false;
            this.txtTotalPointAvalibleValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTotalPointAvalibleValue.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotalPointAvalibleValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotalPointAvalibleValue.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotalPointAvalibleValue.DisplayFormat = "0.00";
            this.txtTotalPointAvalibleValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalPointAvalibleValue.Increment = 0D;
            this.txtTotalPointAvalibleValue.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTotalPointAvalibleValue.IsInputReadOnly = true;
            this.txtTotalPointAvalibleValue.Location = new System.Drawing.Point(96, 161);
            this.txtTotalPointAvalibleValue.Name = "txtTotalPointAvalibleValue";
            this.txtTotalPointAvalibleValue.Size = new System.Drawing.Size(100, 21);
            this.txtTotalPointAvalibleValue.TabIndex = 1127;
            this.txtTotalPointAvalibleValue.ValueChanged += new System.EventHandler(this.txtTotalPointAvalibleValue_ValueChanged);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(198, 161);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 20);
            this.label10.TabIndex = 1126;
            this.label10.Text = "=";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lablPoint
            // 
            this.lablPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lablPoint.BackColor = System.Drawing.Color.White;
            this.lablPoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lablPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lablPoint.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lablPoint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lablPoint.Location = new System.Drawing.Point(31, 249);
            this.lablPoint.Name = "lablPoint";
            this.lablPoint.Size = new System.Drawing.Size(64, 21);
            this.lablPoint.TabIndex = 1124;
            this.lablPoint.Text = "نقطــــة";
            this.lablPoint.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDiscoundPoints
            // 
            this.txtDiscoundPoints.AllowEmptyState = false;
            this.txtDiscoundPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtDiscoundPoints.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDiscoundPoints.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDiscoundPoints.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtDiscoundPoints.DisplayFormat = "0.00";
            this.txtDiscoundPoints.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDiscoundPoints.Increment = 0D;
            this.txtDiscoundPoints.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtDiscoundPoints.IsInputReadOnly = true;
            this.txtDiscoundPoints.Location = new System.Drawing.Point(96, 249);
            this.txtDiscoundPoints.Name = "txtDiscoundPoints";
            this.txtDiscoundPoints.Size = new System.Drawing.Size(100, 21);
            this.txtDiscoundPoints.TabIndex = 1123;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(198, 249);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 20);
            this.label9.TabIndex = 1122;
            this.label9.Text = "=";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDiscoundPointsValue
            // 
            this.txtDiscoundPointsValue.AllowEmptyState = false;
            this.txtDiscoundPointsValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtDiscoundPointsValue.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDiscoundPointsValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDiscoundPointsValue.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtDiscoundPointsValue.DisplayFormat = "0.00";
            this.txtDiscoundPointsValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDiscoundPointsValue.Increment = 0D;
            this.txtDiscoundPointsValue.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtDiscoundPointsValue.Location = new System.Drawing.Point(96, 226);
            this.txtDiscoundPointsValue.MaxValue = 0D;
            this.txtDiscoundPointsValue.MinValue = 0D;
            this.txtDiscoundPointsValue.Name = "txtDiscoundPointsValue";
            this.txtDiscoundPointsValue.Size = new System.Drawing.Size(137, 21);
            this.txtDiscoundPointsValue.TabIndex = 1118;
            this.txtDiscoundPointsValue.ValueChanged += new System.EventHandler(this.txtDiscoundPointsValue_ValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(30, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(203, 21);
            this.label5.TabIndex = 1117;
            this.label5.Text = "قيمة خصم النقاط";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label26
            // 
            this.Label26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Label26.ForeColor = System.Drawing.Color.White;
            this.Label26.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label26.Location = new System.Drawing.Point(235, 203);
            this.Label26.Name = "Label26";
            this.Label26.Size = new System.Drawing.Size(203, 21);
            this.Label26.TabIndex = 1115;
            this.Label26.Text = "صافي الفاتورة";
            this.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDueAmountLoc
            // 
            this.txtDueAmountLoc.AllowEmptyState = false;
            this.txtDueAmountLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtDueAmountLoc.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.txtDueAmountLoc.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtDueAmountLoc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDueAmountLoc.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtDueAmountLoc.DisplayFormat = "0.00";
            this.txtDueAmountLoc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDueAmountLoc.Increment = 0D;
            this.txtDueAmountLoc.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtDueAmountLoc.IsInputReadOnly = true;
            this.txtDueAmountLoc.Location = new System.Drawing.Point(235, 226);
            this.txtDueAmountLoc.Name = "txtDueAmountLoc";
            this.txtDueAmountLoc.Size = new System.Drawing.Size(203, 21);
            this.txtDueAmountLoc.TabIndex = 1114;
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
            this.txtTotalPointAvalible.Location = new System.Drawing.Point(96, 138);
            this.txtTotalPointAvalible.Name = "txtTotalPointAvalible";
            this.txtTotalPointAvalible.Size = new System.Drawing.Size(137, 21);
            this.txtTotalPointAvalible.TabIndex = 1101;
            this.txtTotalPointAvalible.ValueChanged += new System.EventHandler(this.txtTotalPointAvalible_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(235, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 20);
            this.label3.TabIndex = 1100;
            this.label3.Text = "إجمالي النقاط المتبقية";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.txtTotalPointUsed.Location = new System.Drawing.Point(96, 92);
            this.txtTotalPointUsed.Name = "txtTotalPointUsed";
            this.txtTotalPointUsed.Size = new System.Drawing.Size(137, 21);
            this.txtTotalPointUsed.TabIndex = 1099;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(235, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 20);
            this.label2.TabIndex = 1098;
            this.label2.Text = "إجمالي النقاط المستخدمة";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.txtTotalPointAll.Location = new System.Drawing.Point(96, 69);
            this.txtTotalPointAll.Name = "txtTotalPointAll";
            this.txtTotalPointAll.Size = new System.Drawing.Size(137, 21);
            this.txtTotalPointAll.TabIndex = 1097;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(235, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 20);
            this.label1.TabIndex = 1096;
            this.label1.Text = "إجمالي النقاط المستحقة";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtCustNo
            // 
            this.txtCustNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustNo.BackColor = System.Drawing.Color.White;
            this.txtCustNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtCustNo.Location = new System.Drawing.Point(235, 24);
            this.txtCustNo.MaxLength = 30;
            this.txtCustNo.Name = "txtCustNo";
            this.txtCustNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtCustNo, false);
            this.txtCustNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCustNo.Size = new System.Drawing.Size(111, 20);
            this.txtCustNo.TabIndex = 1093;
            this.txtCustNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCustName
            // 
            this.txtCustName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustName.BackColor = System.Drawing.SystemColors.Window;
            this.txtCustName.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtCustName.Location = new System.Drawing.Point(96, 24);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtCustName, false);
            this.txtCustName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCustName.Size = new System.Drawing.Size(137, 21);
            this.txtCustName.TabIndex = 1094;
            this.txtCustName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.Gainsboro;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(348, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 1095;
            this.label4.Text = "حساب العميــل";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelHeader
            // 
            this.labelHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelHeader.BackColor = System.Drawing.Color.SteelBlue;
            // 
            // 
            // 
            this.labelHeader.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelHeader.Font = new System.Drawing.Font("Tahoma", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(24, 0);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(421, 21);
            this.labelHeader.TabIndex = 88;
            this.labelHeader.Text = "بيانات نقاط عميل";
            this.labelHeader.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // line1
            // 
            this.line1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.line1.Location = new System.Drawing.Point(30, 182);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(408, 23);
            this.line1.TabIndex = 1125;
            this.line1.Text = "line1";
            this.line1.Thickness = 3;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(31, 46);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 21);
            this.label13.TabIndex = 1140;
            this.label13.Text = "نقطــــة";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtTotalPointsOld
            // 
            this.txtTotalPointsOld.AllowEmptyState = false;
            this.txtTotalPointsOld.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtTotalPointsOld.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtTotalPointsOld.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotalPointsOld.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtTotalPointsOld.DisplayFormat = "0.00";
            this.txtTotalPointsOld.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalPointsOld.Increment = 0D;
            this.txtTotalPointsOld.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtTotalPointsOld.IsInputReadOnly = true;
            this.txtTotalPointsOld.Location = new System.Drawing.Point(96, 46);
            this.txtTotalPointsOld.Name = "txtTotalPointsOld";
            this.txtTotalPointsOld.Size = new System.Drawing.Size(137, 21);
            this.txtTotalPointsOld.TabIndex = 1139;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(235, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(203, 20);
            this.label14.TabIndex = 1138;
            this.label14.Text = "رصيد سابق للنقاط";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // netResize1
            // 
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            // 
            // FrmCustomerPointData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(446, 334);
            this.Controls.Add(this.panel1);
            this.Icon = global::InvAcc.Properties.Resources.favicon;
            this.KeyPreview = true;
            this.Name = "FrmCustomerPointData";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmCustomerPointData_Load);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCustomerPointData_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmCustomerPointData_KeyPress);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPointReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPointAvalibleValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscoundPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscoundPointsValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDueAmountLoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPointAvalible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPointUsed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPointAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPointsOld)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);
        }
        public FrmCustomerPointData(bool Rep, bool IsEdit, int InvID, double DiscoundPointsVal)
        {
            InitializeComponent();
            IsEdit_ = IsEdit;
            InvID_ = InvID;
            DiscoundPointsVal_ = DiscoundPointsVal;
            Rep_ = Rep;
        }
        private void FrmCustomerPointData_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmCustomerPointData));
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
                if (Rep_)
                {
                    button_SrchCustNo.Visible = true;
                    button_ItemMovementPoint.Visible = true;
                    if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                    {
                        buttonX_Close.Size = new Size(203, 112);
                        buttonX_Close.Location = new Point(6, 203);
                    }
                    else
                    {
                        buttonX_Close.Size = new Size(203, 108);
                        buttonX_Close.Location = new Point(211, 204);
                        Label26.Visible = false;
                        txtDueAmountLoc.Visible = false;
                    }
                }
                MainProcess();
                button_ItemMovementPoint_VisibleChanged(sender, e);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void MainProcess()
        {
            if (!string.IsNullOrEmpty(txtCustNo.Text))
            {
                totPointsIn = 0.0;
                totPointsOut = 0.0;
                totPoints = 0.0;
                _PointUseIn = 0.0;
                _PointUseOut = 0.0;
                totPointUse = 0.0;
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                _RepShow.Rule = " Where T_Items.IsPoints = 1 and T_INVHED.InvTyp = 1  and  T_INVHED.IfDel != 1 and T_INVHED.IsPoints = 1 and CusVenNo = '" + txtCustNo.Text + "' and T_CATEGORY.TotalPurchaes > 0 and T_CATEGORY.TotalPoint > 0 " + (IsEdit_ ? (" and InvHed_ID != " + InvID_) : " ") + " group by T_items.ItmCat";
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
                    double t_ = (totPointsIn = db.StockAccDefWithOutBalance(txtCustNo.Text).TotPoints.Value);
                    txtTotalPointsOld.Value = t_;
                }
                catch
                {
                    totPointsIn = 0.0;
                    txtTotalPointsOld.Value = 0.0;
                }
                if (VarGeneral.RepData.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
                    {
                        try
                        {
                            if (double.Parse(VarGeneral.TString.TEmpty(VarGeneral.RepData.Tables[0].Rows[i][0].ToString())) > 0.0)
                            {
                                totPointsIn += double.Parse(VarGeneral.TString.TEmpty(VarGeneral.RepData.Tables[0].Rows[i][2].ToString()));
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
                    if (VarGeneral.InvTyp == 1 || Rep_)
                    {
                        txtTotalPointAvalibleValue.Value = totPoints * VarGeneral.Settings_Sys.PointOfRyal.Value;
                    }
                }
                List<T_INVHED> _in = db.T_INVHEDs.Where((T_INVHED t) => t.InvTyp == (int?)1 && t.IfDel != (int?)1 && t.IsPoints.Value && (IsEdit_ ? (t.InvHed_ID != InvID_) : true) && t.CusVenNo == txtCustNo.Text).ToList();
                _RepShow = new RepShow();
                _RepShow.Tables = " T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                _RepShow.Rule = " Where T_Items.IsPoints = 1 and T_INVHED.InvTyp = 3  and  T_INVHED.IfDel != 1 and T_INVHED.IsPoints = 1 and CusVenNo = '" + txtCustNo.Text + "' and T_CATEGORY.TotalPurchaes > 0 and T_CATEGORY.TotalPoint > 0 " + (IsEdit_ ? (" and InvHed_ID != " + InvID_) : " ") + " group by T_items.ItmCat";
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
                    for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
                    {
                        try
                        {
                            if (double.Parse(VarGeneral.TString.TEmpty(VarGeneral.RepData.Tables[0].Rows[i][0].ToString())) > 0.0)
                            {
                                _PointUseOut += double.Parse(VarGeneral.TString.TEmpty(VarGeneral.RepData.Tables[0].Rows[i][2].ToString()));
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
                if (VarGeneral.InvTyp == 3 && !Rep_)
                {
                    txtTotalPointAvalible.Value -= txtTotalPointReturn.Value;
                    label3.Text = ((LangArEn == 0) ? "إجمالي النقاط المسموح ارجاعها" : "Total points allowed to be returned");
                }
                else
                {
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
                }
                if (!IsEdit_)
                {
                    txtDiscoundPointsValue.Value = txtTotalPointAvalibleValue.Value;
                }
                else
                {
                    txtDiscoundPointsValue.Value = DiscoundPointsVal_;
                }
            }
            else
            {
                txtTotalPointsOld.Value = 0.0;
                txtDiscoundPoints.Value = 0.0;
                txtDiscoundPointsValue.Value = 0.0;
                txtDueAmountLoc.Value = 0.0;
                txtTotalPointAll.Value = 0.0;
                txtTotalPointAvalible.Value = 0.0;
                txtTotalPointAvalibleValue.Value = 0.0;
                txtTotalPointReturn.Value = 0.0;
                txtTotalPointUsed.Value = 0.0;
            }
        }
        private void MainProcess_OLD()
        {
            if (!string.IsNullOrEmpty(txtCustNo.Text))
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                _RepShow.Rule = " Where T_Items.IsPoints = 1 and T_INVHED.InvTyp = 1  and  T_INVHED.IfDel != 1 and T_INVHED.IsPoints = 1 and CusVenNo = '" + txtCustNo.Text + "' and T_CATEGORY.TotalPurchaes > 0 and T_CATEGORY.TotalPoint > 0 " + (IsEdit_ ? (" and InvHed_ID != " + InvID_) : " ") + " group by T_items.ItmCat";
                _RepShow.Fields = " sum (Round(T_InvDet.Amount,2)) as Amount,T_items.ItmCat ,case when  CONVERT(INT,(sum(Round(T_InvDet.Amount,2)) / (select T_CATEGORY.TotalPurchaes from T_CATEGORY where T_CATEGORY.CAT_ID = T_items.ItmCat))) * (select T_CATEGORY.TotalPoint from T_CATEGORY where T_CATEGORY.CAT_ID = T_items.ItmCat) > 0 then  CONVERT(INT,(sum(Round(T_InvDet.Amount,2)) / (select T_CATEGORY.TotalPurchaes from T_CATEGORY where T_CATEGORY.CAT_ID = T_items.ItmCat))) * (select T_CATEGORY.TotalPoint from T_CATEGORY where T_CATEGORY.CAT_ID = T_items.ItmCat) else 0 end as PointsCount ";
                try
                {
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                try
                {
                    double t_ = (totPointsIn = db.StockAccDefWithOutBalance(txtCustNo.Text).TotPoints.Value);
                    txtTotalPointsOld.Value = t_;
                }
                catch
                {
                    totPointsIn = 0.0;
                    txtTotalPointsOld.Value = 0.0;
                }
                if (VarGeneral.RepData.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
                    {
                        try
                        {
                            if (double.Parse(VarGeneral.TString.TEmpty(VarGeneral.RepData.Tables[0].Rows[i][0].ToString())) > 0.0)
                            {
                                totPointsIn += double.Parse(VarGeneral.TString.TEmpty(VarGeneral.RepData.Tables[0].Rows[i][2].ToString()));
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
                    if (VarGeneral.InvTyp == 1 || Rep_)
                    {
                        txtTotalPointAvalibleValue.Value = totPoints * VarGeneral.Settings_Sys.PointOfRyal.Value;
                    }
                }
                List<T_INVHED> _in = db.T_INVHEDs.Where((T_INVHED t) => t.InvTyp == (int?)1 && t.IfDel != (int?)1 && t.IsPoints.Value && (IsEdit_ ? (t.InvHed_ID != InvID_) : true) && t.CusVenNo == txtCustNo.Text).ToList();
                List<T_INVHED> _Out = db.T_INVHEDs.Where((T_INVHED t) => t.InvTyp == (int?)3 && t.IfDel != (int?)1 && t.IsPoints.Value && (IsEdit_ ? (t.InvHed_ID != InvID_) : true) && t.CusVenNo == txtCustNo.Text).ToList();
                if (_in.Count > 0)
                {
                    _PointUseIn = _in.Sum((T_INVHED g) => g.PointsCount.Value);
                }
                if (_Out.Count > 0)
                {
                    _PointUseOut = _Out.Sum((T_INVHED g) => g.PointsCount.Value);
                }
                txtTotalPointUsed.Value = _PointUseIn;
                txtTotalPointReturn.Value = _PointUseOut;
                if (VarGeneral.InvTyp == 3 && !Rep_)
                {
                    txtTotalPointAvalible.Value = txtTotalPointUsed.Value - txtTotalPointReturn.Value;
                    label3.Text = ((LangArEn == 0) ? "إجمالي النقاط المسموح ارجاعها" : "Total points allowed to be returned");
                }
                else if (txtTotalPointAll.Value - txtTotalPointUsed.Value + txtTotalPointReturn.Value > txtTotalPointAll.Value)
                {
                    txtTotalPointAvalible.Value = txtTotalPointAll.Value;
                }
                else
                {
                    txtTotalPointAvalible.Value = txtTotalPointAll.Value - txtTotalPointUsed.Value + txtTotalPointReturn.Value;
                }
                if (!IsEdit_)
                {
                    txtDiscoundPointsValue.Value = txtTotalPointAvalibleValue.Value;
                }
                else
                {
                    txtDiscoundPointsValue.Value = DiscoundPointsVal_;
                }
            }
            else
            {
                txtTotalPointsOld.Value = 0.0;
                txtDiscoundPoints.Value = 0.0;
                txtDiscoundPointsValue.Value = 0.0;
                txtDueAmountLoc.Value = 0.0;
                txtTotalPointAll.Value = 0.0;
                txtTotalPointAvalible.Value = 0.0;
                txtTotalPointAvalibleValue.Value = 0.0;
                txtTotalPointReturn.Value = 0.0;
                txtTotalPointUsed.Value = 0.0;
            }
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                buttonX_Ok.Text = ((!Rep_) ? "موافـــق" : "تقرير بنقاط العميل المستخدمة في الفواتير");
                button_ItemMovementPoint.Text = "تقرير تفصـــيلي بالنقاط المستحقة حسب حركة كل صنف";
                buttonX_RepPointAll.Text = "تقرير بإجمالي النقاط المستحقة والمرتجعة حسب كل فاتورةة";
                buttonX_Close.Text = ((!Rep_) ? "تـراجـع" : "خــــــروج");
            }
            else
            {
                buttonX_Ok.Text = ((!Rep_) ? "Save" : "Report of client points used in invoices");
                button_ItemMovementPoint.Text = "Report of movement of points of items";
                buttonX_RepPointAll.Text = "Report the total points due and return to the customer per invoice";
                buttonX_Close.Text = ((!Rep_) ? "Back" : "Close");
            }
            try
            {
                lablCurr.Text = db.StockCurencyID(int.Parse(VarGeneral.Settings_Sys.ImportIp)).Symbol;
            }
            catch
            {
            }
            try
            {
                lablCurr2.Text = db.StockCurencyID(int.Parse(VarGeneral.Settings_Sys.ImportIp)).Symbol;
            }
            catch
            {
            }
        }
        private void buttonX_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void txtTotalPointAvalible_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtTotalPointAvalibleValue.Value = txtTotalPointAvalible.Value * VarGeneral.Settings_Sys.PointOfRyal.Value;
            }
            catch
            {
            }
        }
        private void txtTotalPointAvalibleValue_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtDiscoundPointsValue.MaxValue = txtTotalPointAvalibleValue.Value;
            }
            catch
            {
            }
        }
        private void buttonX_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Rep_)
                {
                    if (txtDiscoundPointsValue.Value > txtDueAmountLoc.Value)
                    {
                        MessageBox.Show((LangArEn == 0) ? "لا يمكن ان يكون قيمة خصم النقاط أكبر من صافي الفاتورة .. يرجى التأكد من المدخلات" : "Value of discount points can not be greater than net invoice .. Please make sure the input", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    IsDone = true;
                    Close();
                    return;
                }
                VarGeneral.itmDes = "";
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_INVHED Left Join  T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  Left Join T_Curency On T_INVHED.CurTyp = T_Curency.Curency_ID Left Join T_CstTbl On T_INVHED.InvCstNo = T_CstTbl.Cst_ID Left Join T_Mndob on T_INVHED.MndNo = T_Mndob.Mnd_Id Left Join T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                string Fields = "";
                Fields = ((LangArEn != 0) ? (" T_INVHED.InvTyp,T_INVHED.InvNo,T_INVSETTING.InvNamE as InvTypNm,T_INVHED.GDat,T_INVHED.HDat,T_INVHED.InvCash ,T_CstTbl.Eng_Des as CostCenteNm,T_Mndob.Eng_Des as MndNm,T_INVHED.CashPayLocCur,T_INVHED.NetworkPayLocCur,T_INVHED.CreditPayLocCur,T_INVHED.InvNetLocCur,(Round(T_INVHED.InvCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as  InvCost,(Round(T_INVHED.InvNetLocCur - T_INVHED.InvCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as InvProfit, T_INVHED.GadeNo ,T_INVHED.CusVenNo,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Arb_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNm,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Eng_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNmE,T_SYSSETTING.LogImg,T_SYSSETTING.Calendr ,T_INVHED.SalsManNo,((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.DesPointsValue,(case when T_INVHED.InvTyp = 3 then (select  CONVERT(INT,(Round(sum(T_InvDet.Amount),2) / max(T_CATEGORY.TotalPurchaes))) * max(TotalPoint) from T_INVDET LEFT  OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID where  T_INVDET.InvId = T_INVHED.InvHed_ID and T_INVHED.InvTyp = 3 and T_Items.IsPoints = 1 and T_CATEGORY.TotalPurchaes > 0 and T_CATEGORY.TotalPoint > 0 and  T_INVHED.IfDel != 1 and T_INVHED.IsPoints = 1) else T_INVHED.PointsCount end) as PointsCount,T_INVHED.IsPoints,'' as UsrNamA,''as UsrNamE,Round(case when IsTaxByNet = 1 and T_INVHED.TaxByNetValue > 0 then (T_INVHED.TaxByNetValue * T_INVHED.InvNetLocCur / 100) else (case when T_INVHED.IsTaxLines = 1 then((select sum(Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmTax) from T_INVDET where T_INVDET.InvId = T_INVHED.InvHed_ID) / 100) else 0 end ) end ," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as TaxValue,'" + txtTotalPointAll.Value + "' as DesPointsValueWithDisVal,'" + txtTotalPointUsed.Value + "' as InvDisValOnly,'" + txtTotalPointReturn.Value + "' as DesPointsValueLocCur,'" + txtTotalPointAvalible.Value + "' as InvAddTax,case when T_INVHED.CusVenNo = '' THEN 0 ELSE (select T_AccDef.TotPoints from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as InvTotLocCur,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Mobile from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Mobile") : (" T_INVHED.InvTyp,T_INVHED.InvNo,T_INVSETTING.InvNamA as InvTypNm,T_INVHED.GDat,T_INVHED.HDat,T_INVHED.InvCash ,T_CstTbl.Arb_Des as CostCenteNm,T_Mndob.Arb_Des as MndNm,T_INVHED.CashPayLocCur,T_INVHED.NetworkPayLocCur,T_INVHED.CreditPayLocCur,T_INVHED.InvNetLocCur,(Round(T_INVHED.InvCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as  InvCost,(Round(T_INVHED.InvNetLocCur - T_INVHED.InvCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as InvProfit, T_INVHED.GadeNo ,T_INVHED.CusVenNo,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Arb_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNm,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Eng_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNmE,T_SYSSETTING.LogImg,T_SYSSETTING.Calendr ,T_INVHED.SalsManNo,((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.DesPointsValue,(case when T_INVHED.InvTyp = 3 then (select  CONVERT(INT,(Round(sum(T_InvDet.Amount),2) / max(T_CATEGORY.TotalPurchaes))) * max(TotalPoint) from T_INVDET LEFT  OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID where  T_INVDET.InvId = T_INVHED.InvHed_ID and T_INVHED.InvTyp = 3 and T_Items.IsPoints = 1 and T_CATEGORY.TotalPurchaes > 0 and T_CATEGORY.TotalPoint > 0 and  T_INVHED.IfDel != 1 and T_INVHED.IsPoints = 1) else T_INVHED.PointsCount end) as PointsCount,T_INVHED.IsPoints,'' as UsrNamA,''as UsrNamE,Round(case when IsTaxByNet = 1 and T_INVHED.TaxByNetValue > 0 then (T_INVHED.TaxByNetValue * T_INVHED.InvNetLocCur / 100) else (case when T_INVHED.IsTaxLines = 1 then((select sum(Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmTax) from T_INVDET where T_INVDET.InvId = T_INVHED.InvHed_ID) / 100) else 0 end ) end ," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as TaxValue,'" + txtTotalPointAll.Value + "' as DesPointsValueWithDisVal,'" + txtTotalPointUsed.Value + "' as InvDisValOnly,'" + txtTotalPointReturn.Value + "' as DesPointsValueLocCur,'" + txtTotalPointAvalible.Value + "' as InvAddTax,case when T_INVHED.CusVenNo = '' THEN 0 ELSE (select T_AccDef.TotPoints from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as InvTotLocCur,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Mobile from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Mobile"));
                _RepShow.Rule = " Where ( T_INVHED.InvTyp = 1 or T_INVHED.InvTyp = 3 ) and  T_INVHED.IfDel != 1 and T_INVHED.IsPoints = 1 and ((( DesPointsValue > 0 and T_INVHED.InvTyp = 1) and (PointsCount > 0 and T_INVHED.InvTyp = 1)) or  T_INVHED.InvTyp = 3) and CusVenNo = '" + txtCustNo.Text + "' order by T_INVHED.InvTyp, T_INVHED.InvHed_ID";
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
                if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "عفوا .. لا يوجد بيانات لعرضها في التقرير " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                try
                {
                    FrmReportsViewer frm = new FrmReportsViewer();
                    frm.Tag = LangArEn;
                    frm.Repvalue = "InvoicesCustPoints";
                    VarGeneral.vTitle = labelHeader.Text;
                    frm.TopMost = true;
                    frm.ShowDialog();
                }
                catch (Exception error2)
                {
                    VarGeneral.DebLog.writeLog("button_ShowRep_Click:", error2, enable: true);
                    MessageBox.Show(error2.Message);
                }
            }
            catch (Exception error2)
            {
                VarGeneral.DebLog.writeLog("buttonX_Ok_Click:", error2, enable: true);
                MessageBox.Show(error2.Message);
                IsDone = false;
                Close();
            }
        }
        private void FrmCustomerPointData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void FrmCustomerPointData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void txtDiscoundPointsValue_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtDiscoundPoints.Value = txtDiscoundPointsValue.Value / VarGeneral.Settings_Sys.PointOfRyal.Value;
            }
            catch
            {
            }
        }
        private void button_SrchCustNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, ""));
            columns_Names_visible.Add("TaxNo", new ColumnDictinary("الرقم الضريبي", "Tax No", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_AccDef2";
            VarGeneral.AccTyp = 4;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtCustNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtCustName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    txtCustName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
            }
            else
            {
                txtCustNo.Text = "";
                txtCustName.Text = "";
            }
            MainProcess();
        }
        private string BuildFieldList()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                return " CONVERT(INT,(Round(T_InvDet.Amount,2) / T_CATEGORY.TotalPurchaes)) * TotalPoint as ItmUntPak,(CONVERT(INT,(Round(T_InvDet.Amount,2) / T_CATEGORY.TotalPurchaes)) * TotalPoint) * T_SYSSETTING.PointOfRyal as ItmDis,T_INVHED.CusVenNo,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Arb_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNm,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Eng_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNmE, InvDet_ID,T_Items.Itm_No,T_Items.Arb_Des as itemNm,T_Category.Arb_Des as CategoyNm,T_InvDet.StoreNo,T_InvDet.ItmUnt as UnitNm,(Round(T_InvDet.Price," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Price,T_InvDet.ItmDis,Abs(T_INVDET.Qty) as Qty,Abs(T_INVDET.RealQty) as RealQty,(Round(T_InvDet.Amount," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Amount,(Round(T_InvDet.Cost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Cost,T_INVHED.InvNo, T_INVSETTING.InvNamA as InvTypNm,T_INVHED.InvCash,T_Curency.Arb_Des as CurrnceyNm,T_INVHED.GadeNo, T_Mndob.Arb_Des as MndNm,T_INVHED.RetNo,T_SYSSETTING.LogImg,'" + txtTotalPointAll.Value + "' as Profit,'" + txtTotalPointUsed.Value + "' as CostCenteNm,'" + txtTotalPointReturn.Value + "' as HDat,'" + txtTotalPointAvalible.Value + "' as GDat,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Mobile from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Mobile";
            }
            return " CONVERT(INT,(Round(T_InvDet.Amount,2) / T_CATEGORY.TotalPurchaes)) * TotalPoint as ItmUntPak,(CONVERT(INT,(Round(T_InvDet.Amount,2) / T_CATEGORY.TotalPurchaes)) * TotalPoint) * T_SYSSETTING.PointOfRyal as ItmDis,T_INVHED.CusVenNo,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Arb_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNm,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Eng_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNmE,InvDet_ID,T_Items.Itm_No,T_Items.Eng_Des as itemNm,T_Category.Eng_Des as CategoyNm,T_InvDet.StoreNo,T_InvDet.ItmUntE as UnitNm,(Round(T_InvDet.Price," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Price,T_InvDet.ItmDis,Abs(T_INVDET.Qty) as Qty,Abs(T_INVDET.RealQty) as RealQty,(Round(T_InvDet.Amount," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Amount,(Round(T_InvDet.Cost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Cost,T_INVHED.InvNo, T_INVSETTING.InvNamE as InvTypNm,T_INVHED.InvCash,T_Curency.Eng_Des as CurrnceyNm,T_INVHED.GadeNo, T_Mndob.Eng_Des as MndNm,T_INVHED.RetNo,T_SYSSETTING.LogImg,'" + txtTotalPointAll.Value + "' as Profit,'" + txtTotalPointUsed.Value + "' as CostCenteNm,'" + txtTotalPointReturn.Value + "' as HDat,'" + txtTotalPointAvalible.Value + "' as GDat,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Mobile from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Mobile";
        }
        private void button_ItemMovementPoint_Click(object sender, EventArgs e)
        {
            try
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = "T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                string Fields = BuildFieldList();
                _RepShow.Rule = " Where T_Items.IsPoints = 1 and T_CATEGORY.TotalPurchaes > 0 and T_CATEGORY.TotalPoint > 0 and ( T_INVHED.InvTyp = 1 or T_INVHED.InvTyp = 3 ) and  T_INVHED.IfDel != 1 and T_INVHED.IsPoints = 1 and CusVenNo = '" + txtCustNo.Text + "' order by T_INVHED.InvTyp, T_INVHED.InvHed_ID";
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
                if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "عفوا .. لا يوجد بيانات لعرضها في التقرير " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                try
                {
                    FrmReportsViewer frm = new FrmReportsViewer();
                    frm.Tag = LangArEn;
                    frm.Repvalue = "ItemMovementsCustPoints";
                    VarGeneral.vTitle = labelHeader.Text;
                    frm.TopMost = true;
                    frm.ShowDialog();
                }
                catch (Exception error)
                {
                    VarGeneral.DebLog.writeLog("button_ItemMovementPoint_Click:", error, enable: true);
                    MessageBox.Show(error.Message);
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }
        private void button_ItemMovementPoint_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                buttonX_RepPointAll.Visible = button_ItemMovementPoint.Visible;
                line1.Visible = !button_ItemMovementPoint.Visible;
            }
            catch
            {
                buttonX_RepPointAll.Visible = false;
                line1.Visible = true;
            }
        }
        private void buttonX_RepPointAll_Click(object sender, EventArgs e)
        {
            try
            {
                VarGeneral.itmDes = "";
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_INVHED Left Join  T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  Left Join T_Curency On T_INVHED.CurTyp = T_Curency.Curency_ID Left Join T_CstTbl On T_INVHED.InvCstNo = T_CstTbl.Cst_ID Left Join T_Mndob on T_INVHED.MndNo = T_Mndob.Mnd_Id Left Join T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                string Fields = "";
                Fields = ((LangArEn != 0) ? (" T_INVHED.InvTyp,T_INVHED.InvNo,T_INVSETTING.InvNamE as InvTypNm,T_INVHED.GDat,T_INVHED.HDat,T_INVHED.InvCash ,T_CstTbl.Eng_Des as CostCenteNm,T_Mndob.Eng_Des as MndNm,T_INVHED.CashPayLocCur,T_INVHED.NetworkPayLocCur,T_INVHED.CreditPayLocCur,T_INVHED.InvNetLocCur,(Round(T_INVHED.InvCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as  InvCost,(Round(T_INVHED.InvNetLocCur - T_INVHED.InvCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as InvProfit, T_INVHED.GadeNo ,T_INVHED.CusVenNo,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Arb_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNm,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Eng_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNmE,T_SYSSETTING.LogImg,T_SYSSETTING.Calendr ,T_INVHED.SalsManNo,((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.DesPointsValue,((select  CONVERT(INT,(Round(sum(T_InvDet.Amount),2) / max(T_CATEGORY.TotalPurchaes))) * max(TotalPoint) from T_INVDET LEFT  OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID where  T_INVDET.InvId = T_INVHED.InvHed_ID and T_Items.IsPoints = 1 and T_CATEGORY.TotalPurchaes > 0 and T_CATEGORY.TotalPoint > 0 and  T_INVHED.IfDel != 1 and T_INVHED.IsPoints = 1)) as PointsCount,T_INVHED.IsPoints,'' as UsrNamA,''as UsrNamE,Round(case when IsTaxByNet = 1 and T_INVHED.TaxByNetValue > 0 then (T_INVHED.TaxByNetValue * T_INVHED.InvNetLocCur / 100) else (case when T_INVHED.IsTaxLines = 1 then((select sum(Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmTax) from T_INVDET where T_INVDET.InvId = T_INVHED.InvHed_ID) / 100) else 0 end ) end ," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as TaxValue,'" + txtTotalPointAll.Value + "' as DesPointsValueWithDisVal,'" + txtTotalPointUsed.Value + "' as InvDisValOnly,'" + txtTotalPointReturn.Value + "' as DesPointsValueLocCur,'" + txtTotalPointAvalible.Value + "' as InvAddTax,case when T_INVHED.CusVenNo = '' THEN 0 ELSE (select T_AccDef.TotPoints from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as InvTotLocCur,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Mobile from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Mobile") : (" T_INVHED.InvTyp,T_INVHED.InvNo,T_INVSETTING.InvNamA as InvTypNm,T_INVHED.GDat,T_INVHED.HDat,T_INVHED.InvCash ,T_CstTbl.Arb_Des as CostCenteNm,T_Mndob.Arb_Des as MndNm,T_INVHED.CashPayLocCur,T_INVHED.NetworkPayLocCur,T_INVHED.CreditPayLocCur,T_INVHED.InvNetLocCur,(Round(T_INVHED.InvCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as  InvCost,(Round(T_INVHED.InvNetLocCur - T_INVHED.InvCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as InvProfit, T_INVHED.GadeNo ,T_INVHED.CusVenNo,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Arb_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNm,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Eng_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNmE,T_SYSSETTING.LogImg,T_SYSSETTING.Calendr ,T_INVHED.SalsManNo,((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.DesPointsValue,((select  CONVERT(INT,(Round(sum(T_InvDet.Amount),2) / max(T_CATEGORY.TotalPurchaes))) * max(TotalPoint) from T_INVDET LEFT  OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID where  T_INVDET.InvId = T_INVHED.InvHed_ID and T_Items.IsPoints = 1 and T_CATEGORY.TotalPurchaes > 0 and T_CATEGORY.TotalPoint > 0 and  T_INVHED.IfDel != 1 and T_INVHED.IsPoints = 1)) as PointsCount,T_INVHED.IsPoints,'' as UsrNamA,''as UsrNamE,Round(case when IsTaxByNet = 1 and T_INVHED.TaxByNetValue > 0 then (T_INVHED.TaxByNetValue * T_INVHED.InvNetLocCur / 100) else (case when T_INVHED.IsTaxLines = 1 then((select sum(Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmTax) from T_INVDET where T_INVDET.InvId = T_INVHED.InvHed_ID) / 100) else 0 end ) end ," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as TaxValue,'" + txtTotalPointAll.Value + "' as DesPointsValueWithDisVal,'" + txtTotalPointUsed.Value + "' as InvDisValOnly,'" + txtTotalPointReturn.Value + "' as DesPointsValueLocCur,'" + txtTotalPointAvalible.Value + "' as InvAddTax,case when T_INVHED.CusVenNo = '' THEN 0 ELSE (select T_AccDef.TotPoints from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as InvTotLocCur,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Mobile from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Mobile"));
                _RepShow.Rule = " Where ( T_INVHED.InvTyp = 1 or T_INVHED.InvTyp = 3 ) and  T_INVHED.IfDel != 1 and T_INVHED.IsPoints = 1 and CusVenNo = '" + txtCustNo.Text + "' order by T_INVHED.InvTyp, T_INVHED.InvHed_ID";
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
                if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "عفوا .. لا يوجد بيانات لعرضها في التقرير " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                try
                {
                    FrmReportsViewer frm = new FrmReportsViewer();
                    frm.Tag = LangArEn;
                    frm.Repvalue = "InvoicesCustPointsALL";
                    VarGeneral.vTitle = labelHeader.Text;
                    frm.TopMost = true;
                    frm.ShowDialog();
                }
                catch (Exception error2)
                {
                    VarGeneral.DebLog.writeLog("button_ShowRep_Click:", error2, enable: true);
                    MessageBox.Show(error2.Message);
                }
            }
            catch (Exception error2)
            {
                VarGeneral.DebLog.writeLog("buttonX_Ok_Click:", error2, enable: true);
                MessageBox.Show(error2.Message);
                IsDone = false;
                Close();
            }
        }
    }
}
