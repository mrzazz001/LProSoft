using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using Framework.UI;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Library.RepShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmRepairPurchaes : Form
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

        public Softgroup.NetResize.NetResize netResize1;

        private C1FlexGrid FlxInv;
        private Label label5;
        private TextBox txtFItemName;
        private TextBox txtFItemNo;
        private ButtonX button_SrchItemFrom;
        private TextBox txtInItemName;
        private TextBox txtInItemNo;
        private Label label6;
        private ButtonX button_SrchItemTo;
        private ButtonX ButOk;
        private ButtonX ButExit;
        private ButtonX Butupdate;
        private ButtonX button_DetData;
        private GroupBox groupBox_No;
        private MaskedTextBox txtMIntoNo;
        private Label label1;
        private Label label2;
        private MaskedTextBox txtMFromNo;
        private int LangArEn = 0;
        private T_User _User = new T_User();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private SplitContainer splitContainer1;
        private T_User permission = new T_User();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRepairPurchaes));
            this.FlxInv = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFItemName = new System.Windows.Forms.TextBox();
            this.txtFItemNo = new System.Windows.Forms.TextBox();
            this.button_SrchItemFrom = new DevComponents.DotNetBar.ButtonX();
            this.txtInItemName = new System.Windows.Forms.TextBox();
            this.txtInItemNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button_SrchItemTo = new DevComponents.DotNetBar.ButtonX();
            this.ButOk = new DevComponents.DotNetBar.ButtonX();
            this.ButExit = new DevComponents.DotNetBar.ButtonX();
            this.Butupdate = new DevComponents.DotNetBar.ButtonX();
            this.button_DetData = new DevComponents.DotNetBar.ButtonX();
            this.groupBox_No = new System.Windows.Forms.GroupBox();
            this.txtMIntoNo = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMFromNo = new System.Windows.Forms.MaskedTextBox();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            ((System.ComponentModel.ISupportInitialize)(this.FlxInv)).BeginInit();
            this.groupBox_No.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FlxInv
            // 
            this.FlxInv.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.FlxInv.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.FlxInv.ColumnInfo = resources.GetString("FlxInv.ColumnInfo");
            this.FlxInv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlxInv.ExtendLastCol = true;
            this.FlxInv.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FlxInv.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            this.FlxInv.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            this.FlxInv.Location = new System.Drawing.Point(0, 0);
            this.FlxInv.Name = "FlxInv";
            this.FlxInv.Rows.Count = 1;
            this.FlxInv.Rows.DefaultSize = 19;
            this.FlxInv.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
            this.FlxInv.Size = new System.Drawing.Size(1055, 503);
            this.FlxInv.StyleInfo = resources.GetString("FlxInv.StyleInfo");
            this.FlxInv.TabIndex = 18;
            this.FlxInv.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(981, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 1122;
            this.label5.Text = "مـن الصنف :";
            // 
            // txtFItemName
            // 
            this.txtFItemName.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtFItemName.ForeColor = System.Drawing.Color.White;
            this.txtFItemName.Location = new System.Drawing.Point(708, 19);
            this.txtFItemName.Name = "txtFItemName";
            this.txtFItemName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtFItemName, false);
            this.txtFItemName.Size = new System.Drawing.Size(164, 20);
            this.txtFItemName.TabIndex = 1121;
            this.txtFItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFItemNo
            // 
            this.txtFItemNo.BackColor = System.Drawing.Color.White;
            this.txtFItemNo.Location = new System.Drawing.Point(902, 19);
            this.txtFItemNo.Name = "txtFItemNo";
            this.txtFItemNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtFItemNo, false);
            this.txtFItemNo.Size = new System.Drawing.Size(79, 20);
            this.txtFItemNo.TabIndex = 1119;
            this.txtFItemNo.Tag = "T_INVDET_Repair.ItmNo_Repair ";
            this.txtFItemNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFItemNo.TextChanged += new System.EventHandler(this.txtFItemNo_TextChanged);
            // 
            // button_SrchItemFrom
            // 
            this.button_SrchItemFrom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchItemFrom.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchItemFrom.Location = new System.Drawing.Point(874, 19);
            this.button_SrchItemFrom.Name = "button_SrchItemFrom";
            this.button_SrchItemFrom.Size = new System.Drawing.Size(26, 20);
            this.button_SrchItemFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchItemFrom.Symbol = "";
            this.button_SrchItemFrom.SymbolSize = 12F;
            this.button_SrchItemFrom.TabIndex = 1120;
            this.button_SrchItemFrom.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchItemFrom.Click += new System.EventHandler(this.button_SrchItemFrom_Click);
            // 
            // txtInItemName
            // 
            this.txtInItemName.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtInItemName.ForeColor = System.Drawing.Color.White;
            this.txtInItemName.Location = new System.Drawing.Point(708, 41);
            this.txtInItemName.Name = "txtInItemName";
            this.txtInItemName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtInItemName, false);
            this.txtInItemName.Size = new System.Drawing.Size(164, 20);
            this.txtInItemName.TabIndex = 1125;
            this.txtInItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtInItemNo
            // 
            this.txtInItemNo.BackColor = System.Drawing.Color.White;
            this.txtInItemNo.Location = new System.Drawing.Point(902, 41);
            this.txtInItemNo.Name = "txtInItemNo";
            this.txtInItemNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtInItemNo, false);
            this.txtInItemNo.Size = new System.Drawing.Size(79, 20);
            this.txtInItemNo.TabIndex = 1123;
            this.txtInItemNo.Tag = "T_INVDET_Repair.ItmNo_Repair ";
            this.txtInItemNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInItemNo.TextChanged += new System.EventHandler(this.txtInItemNo_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(981, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 1126;
            this.label6.Text = "إلـــى صنف :";
            // 
            // button_SrchItemTo
            // 
            this.button_SrchItemTo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchItemTo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchItemTo.Location = new System.Drawing.Point(874, 41);
            this.button_SrchItemTo.Name = "button_SrchItemTo";
            this.button_SrchItemTo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchItemTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchItemTo.Symbol = "";
            this.button_SrchItemTo.SymbolSize = 12F;
            this.button_SrchItemTo.TabIndex = 1124;
            this.button_SrchItemTo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchItemTo.Click += new System.EventHandler(this.button_SrchItemTo_Click);
            // 
            // ButOk
            // 
            this.ButOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButOk.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.ButOk.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButOk.Location = new System.Drawing.Point(208, 17);
            this.ButOk.Name = "ButOk";
            this.ButOk.Size = new System.Drawing.Size(96, 43);
            this.ButOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButOk.SymbolSize = 16F;
            this.ButOk.TabIndex = 1127;
            this.ButOk.Text = "عــرض";
            this.ButOk.TextColor = System.Drawing.Color.White;
            this.ButOk.Click += new System.EventHandler(this.ButOk_Click);
            // 
            // ButExit
            // 
            this.ButExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButExit.Checked = true;
            this.ButExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ButExit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButExit.Location = new System.Drawing.Point(11, 17);
            this.ButExit.Name = "ButExit";
            this.ButExit.Size = new System.Drawing.Size(96, 43);
            this.ButExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButExit.Symbol = "";
            this.ButExit.SymbolSize = 16F;
            this.ButExit.TabIndex = 1128;
            this.ButExit.Text = "خـــروج";
            this.ButExit.TextColor = System.Drawing.Color.Black;
            this.ButExit.Click += new System.EventHandler(this.ButExit_Click);
            // 
            // Butupdate
            // 
            this.Butupdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Butupdate.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.Butupdate.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Butupdate.Location = new System.Drawing.Point(110, 17);
            this.Butupdate.Name = "Butupdate";
            this.Butupdate.Size = new System.Drawing.Size(96, 43);
            this.Butupdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Butupdate.SymbolSize = 16F;
            this.Butupdate.TabIndex = 1129;
            this.Butupdate.Text = "تحديث الأسعار";
            this.Butupdate.TextColor = System.Drawing.Color.White;
            this.Butupdate.Click += new System.EventHandler(this.Butupdate_Click);
            // 
            // button_DetData
            // 
            this.button_DetData.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_DetData.Checked = true;
            this.button_DetData.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta;
            this.button_DetData.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button_DetData.Location = new System.Drawing.Point(307, 17);
            this.button_DetData.Name = "button_DetData";
            this.button_DetData.Size = new System.Drawing.Size(74, 43);
            this.button_DetData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_DetData.Symbol = "";
            this.button_DetData.SymbolSize = 16F;
            this.button_DetData.TabIndex = 1130;
            this.button_DetData.Text = "مسح كامل ";
            this.button_DetData.TextColor = System.Drawing.Color.Maroon;
            this.button_DetData.Visible = false;
            this.button_DetData.Click += new System.EventHandler(this.button_DetData_Click);
            // 
            // groupBox_No
            // 
            this.groupBox_No.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_No.Controls.Add(this.txtMIntoNo);
            this.groupBox_No.Controls.Add(this.label1);
            this.groupBox_No.Controls.Add(this.label2);
            this.groupBox_No.Controls.Add(this.txtMFromNo);
            this.groupBox_No.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.groupBox_No.Location = new System.Drawing.Point(387, 11);
            this.groupBox_No.Name = "groupBox_No";
            this.groupBox_No.Size = new System.Drawing.Size(315, 48);
            this.groupBox_No.TabIndex = 6725;
            this.groupBox_No.TabStop = false;
            this.groupBox_No.Text = "حسب رقم الفاتورة";
            // 
            // txtMIntoNo
            // 
            this.txtMIntoNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMIntoNo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtMIntoNo.Location = new System.Drawing.Point(10, 19);
            this.txtMIntoNo.Name = "txtMIntoNo";
            this.txtMIntoNo.Size = new System.Drawing.Size(112, 22);
            this.txtMIntoNo.TabIndex = 2;
            this.txtMIntoNo.Tag = "T_INVDET_Repair.InvNo_Repair";
            this.txtMIntoNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMIntoNo.Click += new System.EventHandler(this.txtMIntoNo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(280, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 857;
            this.label1.Text = "من :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(125, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 859;
            this.label2.Text = "إلى :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMFromNo
            // 
            this.txtMFromNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMFromNo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtMFromNo.Location = new System.Drawing.Point(166, 19);
            this.txtMFromNo.Name = "txtMFromNo";
            this.txtMFromNo.Size = new System.Drawing.Size(112, 22);
            this.txtMFromNo.TabIndex = 1;
            this.txtMFromNo.Tag = "T_INVDET_Repair.InvNo_Repair ";
            this.txtMFromNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMFromNo.Click += new System.EventHandler(this.txtMFromNo_Click);
            // 
            // netResize1
            // 
            this.netResize1.ParentControl = this;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ButOk);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox_No);
            this.splitContainer1.Panel1.Controls.Add(this.button_SrchItemFrom);
            this.splitContainer1.Panel1.Controls.Add(this.Butupdate);
            this.splitContainer1.Panel1.Controls.Add(this.txtFItemNo);
            this.splitContainer1.Panel1.Controls.Add(this.ButExit);
            this.splitContainer1.Panel1.Controls.Add(this.txtFItemName);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.button_DetData);
            this.splitContainer1.Panel1.Controls.Add(this.button_SrchItemTo);
            this.splitContainer1.Panel1.Controls.Add(this.txtInItemName);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.txtInItemNo);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.FlxInv);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(1055, 581);
            this.splitContainer1.SplitterDistance = 74;
            this.splitContainer1.TabIndex = 6726;
            // 
            // FrmRepairPurchaes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1055, 581);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmRepairPurchaes";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "معالج تحديث أسعــار التكلفــــة";
            this.Load += new System.EventHandler(this.FrmRepairPurchaes_Load);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmRepairPurchaes_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.FlxInv)).EndInit();
            this.groupBox_No.ResumeLayout(false);
            this.groupBox_No.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        public FrmRepairPurchaes()
        {
            InitializeComponent();
        }
        private void ButExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button_SrchItemFrom_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("Itm_No", new ColumnDictinary("رقم الصنف", "Item No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, ""));
            columns_Names_visible.Add("StartCost", new ColumnDictinary("التكلفةالافتتاحية", "Start Cost", ifDefault: false, ""));
            columns_Names_visible.Add("AvrageCost", new ColumnDictinary("متوسط التكلفة", "Average Cost", ifDefault: false, ""));
            columns_Names_visible.Add("LastCost", new ColumnDictinary("آخر تكلفة", "Last Cost", ifDefault: false, ""));
            columns_Names_visible.Add("Arb_Des_Cat", new ColumnDictinary("الاسم العربي لمجموعة الصنف", "CATEGORY Arabic Name", ifDefault: false, ""));
            columns_Names_visible.Add("Eng_Des_Cat", new ColumnDictinary("الاسم الانجليزي لمجموعة الصنف", "CATEGORY English Name", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_Items";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtFItemNo.Text = frm.Serach_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtFItemName.Text = db.StockItem(frm.Serach_No).Arb_Des.ToString();
                }
                else
                {
                    txtFItemName.Text = db.StockItem(frm.Serach_No).Eng_Des.ToString();
                }
            }
            else
            {
                txtFItemNo.Text = "";
                txtFItemName.Text = "";
            }
        }
        private void button_SrchItemTo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("Itm_No", new ColumnDictinary("رقم الصنف", "Item No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, ""));
            columns_Names_visible.Add("StartCost", new ColumnDictinary("التكلفةالافتتاحية", "Start Cost", ifDefault: false, ""));
            columns_Names_visible.Add("AvrageCost", new ColumnDictinary("متوسط التكلفة", "Average Cost", ifDefault: false, ""));
            columns_Names_visible.Add("LastCost", new ColumnDictinary("آخر تكلفة", "Last Cost", ifDefault: false, ""));
            columns_Names_visible.Add("Arb_Des_Cat", new ColumnDictinary("الاسم العربي لمجموعة الصنف", "CATEGORY Arabic Name", ifDefault: false, ""));
            columns_Names_visible.Add("Eng_Des_Cat", new ColumnDictinary("الاسم الانجليزي لمجموعة الصنف", "CATEGORY English Name", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_Items";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtInItemNo.Text = frm.Serach_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtInItemName.Text = db.StockItem(frm.Serach_No).Arb_Des.ToString();
                }
                else
                {
                    txtInItemName.Text = db.StockItem(frm.Serach_No).Eng_Des.ToString();
                }
            }
            else
            {
                txtInItemNo.Text = "";
                txtInItemName.Text = "";
            }
        }
        private void txtMFromNo_Click(object sender, EventArgs e)
        {
            txtMFromNo.SelectAll();
        }
        private void txtMIntoNo_Click(object sender, EventArgs e)
        {
            txtMIntoNo.SelectAll();
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            FlxInv.Rows.Count = 1;
            string Rule = "";
            if (!string.IsNullOrEmpty(txtFItemNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtFItemNo.Tag, " >= '", txtFItemNo.Text.Trim(), "'");
            }
            if (!string.IsNullOrEmpty(txtInItemNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtInItemNo.Tag, " <= '", txtInItemNo.Text.Trim(), "'");
            }
            if (!string.IsNullOrEmpty(txtMFromNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtMFromNo.Tag, " >= ", txtMFromNo.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtMIntoNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtMIntoNo.Tag, " <= ", txtMIntoNo.Text.Trim());
            }
            List<T_INVDET_Repair> listDet = db.ExecuteQuery<T_INVDET_Repair>("select * from T_INVDET_Repair Where 1 = 1 " + Rule, new object[0]).ToList();
            if (listDet.Count <= 0)
            {
                return;
            }
            FlxInv.Rows.Count = listDet.Count + 1;
            T_INVDET_Repair _InvDet;
            for (int iiCnt = 1; iiCnt <= listDet.Count; iiCnt++)
            {
                _InvDet = listDet[iiCnt - 1];
                double _AvrageCost = 0.0;
                FlxInv.SetData(iiCnt, 0, _InvDet.InvDet_ID_Repair);
                FlxInv.SetData(iiCnt, 1, _InvDet.ItmNo_Repair.Trim());
                FlxInv.SetData(iiCnt, 2, (LangArEn == 0) ? _InvDet.ItmDes_Repair.ToString() : _InvDet.ItmDesE_Repair.ToString());
                FlxInv.SetData(iiCnt, 3, _InvDet.InvNo_Repair.ToString());
                FlxInv.SetData(iiCnt, 4, _InvDet.ItmWight_Repair);
                FlxInv.SetData(iiCnt, 5, _InvDet.ItmWight_T_Repair);
                FlxInv.SetData(iiCnt, 6, db.StockItem(_InvDet.ItmNo_Repair.Trim()).AvrageCost.Value);
                FlxInv.SetData(iiCnt, 7, _InvDet.Qty_Repair);
                FlxInv.SetData(iiCnt, 8, _InvDet.Price_Repair.Value);
                try
                {
                    FlxInv.SetData(iiCnt, 13, db.StockInvHeadID(_InvDet.TypeRepair.Value, _InvDet.InvDet_ID).CurTyp.Value);
                }
                catch
                {
                    FlxInv.SetData(iiCnt, 13, 1);
                }
                double QtyT = 0.0;
                try
                {
                    RepShow _RepShow = new RepShow();
                    _RepShow.Tables = "T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                    string Fields = " MAX(T_Items.Itm_No ) as Itm_No , MAX(T_Items.Arb_Des ) as itemNm   , MAX( T_Category.Arb_Des ) as [CategoyNm] ,  SUM (CASE WHEN T_InvDet.RealQty > 0 THEN T_InvDet.RealQty Else 0 END ) AS [Credit] ,  SUM (CASE WHEN T_InvDet.RealQty < 0 THEN ABS(T_InvDet.RealQty)  Else 0 END ) AS [Debit],MAX (T_SYSSETTING.LogImg) as LogImg ";
                    _RepShow.Rule = " Where 1 = 1 and  T_INVHED.InvTyp != 21 and T_INVHED.InvTyp != 7 and T_INVHED.InvTyp != 8 and T_INVHED.InvTyp != 9 and T_INVHED.IfDel != 1 and  T_INVHED.IfRet != 1 and (T_INVHED.PaymentOrderTyp = 0 or ( T_INVHED.InvTyp = 17 or T_INVHED.InvTyp = 20)) and  T_Items.Itm_No ='" + _InvDet.ItmNo_Repair.Trim() + "' group by T_Items.Itm_No  Order by Itm_No ";
                    _RepShow.Fields = Fields;
                    try
                    {
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                    }
                    catch (Exception)
                    {
                        QtyT = 0.0;
                    }
                    if (VarGeneral.RepData.Tables[0].Rows.Count > 0)
                    {
                        QtyT = double.Parse(VarGeneral.RepData.Tables[0].Rows[0]["Credit"].ToString());
                    }
                    if (QtyT <= 0.0)
                    {
                        QtyT = 0.0;
                    }
                }
                catch
                {
                    QtyT = 0.0;
                }
                double CostT = 0.0;
                try
                {
                    List<T_INVDET> vTot = (from t in db.T_INVDETs
                                           where t.ItmNo == _InvDet.ItmNo_Repair.Trim()
                                           where t.T_INVHED.InvTyp == (int?)2 || t.T_INVHED.InvTyp == (int?)14
                                           where t.T_INVHED.IfDel == (int?)0
                                           select t).ToList();
                    if (vTot.Count > 0)
                    {
                        CostT = vTot.Sum((T_INVDET g) => g.Amount.Value);
                    }
                }
                catch
                {
                    CostT = 0.0;
                }
                if (QtyT > 0.0)
                {
                    try
                    {
                        _AvrageCost = ((!(double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 6)))) <= 0.0)) ? (CostT / QtyT) : (double.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 8)))) * _InvDet.RealQty_Repair.Value));
                    }
                    catch
                    {
                        _AvrageCost = CostT / QtyT;
                    }
                }
                try
                {
                    if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 45))
                    {
                        _AvrageCost *= db.StockCurencyID(int.Parse(VarGeneral.TString.TEmpty(string.Concat(FlxInv.GetData(iiCnt, 13))))).Rate.Value;
                    }
                }
                catch
                {
                }
                FlxInv.SetData(iiCnt, 9, _AvrageCost);
                FlxInv.SetData(iiCnt, 10, _AvrageCost);
                FlxInv.SetData(iiCnt, 11, _InvDet.InvDet_ID);
                FlxInv.SetData(iiCnt, 12, _InvDet.ItmUntPak_Repair.Value);
            }
        }
        private void FrmRepairPurchaes_Load(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmRepairPurchaes));
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
            if (VarGeneral.UserID == 1)
            {
                button_DetData.Visible = true;
            }
            else
            {
                button_DetData.Visible = false;
            }
            permission = dbc.Get_PermissionID(VarGeneral.UserID);
            FlxInv.Cols[9].AllowEditing = VarGeneral.TString.ChkStatShow(permission.SetStr, 46);
            RibunButtons();
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ButOk.Text = "عــرض";
                Butupdate.Text = "تحديث الأسعار";
                ButExit.Text = "خـــروج";
                Text = "معالج تحديث أسعــار التكلفــــة";
                return;
            }
            ButOk.Text = "Show";
            Butupdate.Text = "Update Prices";
            ButExit.Text = "Close";
            button_DetData.Text = "Delete All Data";
            Text = "Update Prices Cost Process";
            FlxInv.Cols[1].Caption = "Item No";
            FlxInv.Cols[2].Caption = "Item Name";
            FlxInv.Cols[3].Caption = "Inv No";
            FlxInv.Cols[4].Caption = "Qty / Bef";
            FlxInv.Cols[5].Caption = "Price / Bef";
            FlxInv.Cols[6].Caption = "Average / Bef";
            FlxInv.Cols[7].Caption = "Qty / After";
            FlxInv.Cols[8].Caption = "Price / After";
            FlxInv.Cols[9].Caption = "New Cost";
            FlxInv.Cols[14].Caption = "Exception";
        }
        private void FrmRepairPurchaes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && ButOk.Enabled && ButOk.Visible)
            {
                ButOk_Click(sender, e);
            }
            if (e.KeyCode == Keys.F5 && Butupdate.Enabled && Butupdate.Visible)
            {
                Butupdate_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void Butupdate_Click(object sender, EventArgs e)
        {
            if (FlxInv.Rows.Count <= 1 || MessageBox.Show("سيتم تحديث اسعار التكلفة للاصناف المحددة  \n هل تريد الأستمرار ? ", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                return;
            }
            for (int iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
            {
                try
                {
                    if (FlxInv.GetData(iiCnt, 1) != null && !Convert.ToBoolean(FlxInv.GetData(iiCnt, 14)) && double.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 9).ToString())) >= 0.0)
                    {
                        db.ExecuteCommand("update T_Items set AvrageCost = " + double.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 9).ToString())) + " ,LastCost= " + double.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 10).ToString())) + " where Itm_No = '" + VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 1).ToString()) + "'");
                        db.ExecuteCommand("delete from T_INVDET_Repair where InvDet_ID_Repair = " + FlxInv.GetData(iiCnt, 0));
                        SaveUserEditor(iiCnt);
                    }
                }
                catch
                {
                }
            }
            MessageBox.Show((LangArEn == 0) ? "تم عملية التعديل بنجاح" : "Operation accomplished successfully", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            FlxInv.Rows.Count = 1;
            txtFItemNo.Text = "";
            txtFItemName.Text = "";
            txtInItemNo.Text = "";
            txtInItemName.Text = "";
            txtMFromNo.Text = "";
            txtMIntoNo.Text = "";
        }
        private void SaveUserEditor(int iiCnt)
        {
            try
            {
                T_Item data_this = new T_Item();
                data_this = db.StockItem(FlxInv.GetData(iiCnt, 1).ToString());
                T_EditItemPrice data_this_EditPrice = new T_EditItemPrice();
                data_this_EditPrice.ItmNo = FlxInv.GetData(iiCnt, 1).ToString();
                data_this_EditPrice.SelCostNow = double.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 6).ToString()));
                data_this_EditPrice.SelCostNew = double.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 9).ToString()));
                try
                {
                    if (data_this.Unit1.HasValue)
                    {
                        data_this_EditPrice.SelPriceNow1 = data_this.UntPri1.Value;
                        data_this_EditPrice.SelPriceNew1 = data_this.UntPri1.Value;
                    }
                    else
                    {
                        data_this_EditPrice.SelPriceNow1 = null;
                        data_this_EditPrice.SelPriceNew1 = null;
                    }
                    if (data_this.Unit2.HasValue)
                    {
                        data_this_EditPrice.SelPriceNow2 = data_this.UntPri2.Value;
                        data_this_EditPrice.SelPriceNew2 = data_this.UntPri2.Value;
                    }
                    else
                    {
                        data_this_EditPrice.SelPriceNow2 = null;
                        data_this_EditPrice.SelPriceNew2 = null;
                    }
                    if (data_this.Unit3.HasValue)
                    {
                        data_this_EditPrice.SelPriceNow3 = data_this.UntPri3.Value;
                        data_this_EditPrice.SelPriceNew3 = data_this.UntPri3.Value;
                    }
                    else
                    {
                        data_this_EditPrice.SelPriceNow3 = null;
                        data_this_EditPrice.SelPriceNew3 = null;
                    }
                    if (data_this.Unit4.HasValue)
                    {
                        data_this_EditPrice.SelPriceNow4 = data_this.UntPri4.Value;
                        data_this_EditPrice.SelPriceNew4 = data_this.UntPri4.Value;
                    }
                    else
                    {
                        data_this_EditPrice.SelPriceNow4 = null;
                        data_this_EditPrice.SelPriceNew4 = null;
                    }
                    if (data_this.Unit5.HasValue)
                    {
                        data_this_EditPrice.SelPriceNow5 = data_this.UntPri5.Value;
                        data_this_EditPrice.SelPriceNew5 = data_this.UntPri5.Value;
                    }
                    else
                    {
                        data_this_EditPrice.SelPriceNow5 = null;
                        data_this_EditPrice.SelPriceNew5 = null;
                    }
                    data_this_EditPrice.Distributors = data_this.Price2.Value;
                    data_this_EditPrice.DistributorsNew = data_this.Price2.Value;
                    data_this_EditPrice.Legates = data_this.Price3.Value;
                    data_this_EditPrice.LegatesNew = data_this.Price3.Value;
                    data_this_EditPrice.Sectorial = data_this.Price4.Value;
                    data_this_EditPrice.SectorialNew = data_this.Price4.Value;
                    data_this_EditPrice.Sentence = data_this.Price1.Value;
                    data_this_EditPrice.SentenceNew = data_this.Price1.Value;
                    data_this_EditPrice.VIP = data_this.Price5.Value;
                    data_this_EditPrice.VIPNew = data_this.Price5.Value;
                }
                catch
                {
                }
                data_this_EditPrice.HDate = VarGeneral.Hdate;
                data_this_EditPrice.GDate = VarGeneral.Gdate;
                data_this_EditPrice.UsrNm = VarGeneral.UserNameA;
                data_this_EditPrice.LTim = DateTime.Now.ToString("HH:mm");
                db.T_EditItemPrices.InsertOnSubmit(data_this_EditPrice);
                db.SubmitChanges();
            }
            catch (SqlException ex)
            {
                VarGeneral.DebLog.writeLog("SaveUserEditor:", ex, enable: true);
            }
        }
        private void combobox_Inv_SelectedIndexChanged(object sender, EventArgs e)
        {
            FlxInv.Rows.Count = 1;
        }
        private void txtFItemNo_TextChanged(object sender, EventArgs e)
        {
            FlxInv.Rows.Count = 1;
        }
        private void txtInItemNo_TextChanged(object sender, EventArgs e)
        {
            FlxInv.Rows.Count = 1;
        }
        private void button_DetData_Click(object sender, EventArgs e)
        {
            if (FlxInv.Rows.Count > 1 && MessageBox.Show("هل أنت متاكد من حذف أسعار التكاليف الجديدة قبل تحديثها في كرت الصنف ؟ \n Are you sure to delete the new cost prices before updating them in the product card?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
            {
                string Rule = "";
                if (!string.IsNullOrEmpty(txtFItemNo.Text))
                {
                    object obj = Rule;
                    Rule = string.Concat(obj, " and ", txtFItemNo.Tag, " >= '", txtFItemNo.Text.Trim(), "'");
                }
                if (!string.IsNullOrEmpty(txtInItemNo.Text))
                {
                    object obj = Rule;
                    Rule = string.Concat(obj, " and ", txtInItemNo.Tag, " <= '", txtInItemNo.Text.Trim(), "'");
                }
                if (!string.IsNullOrEmpty(txtMFromNo.Text))
                {
                    object obj = Rule;
                    Rule = string.Concat(obj, " and ", txtMFromNo.Tag, " >= ", txtMFromNo.Text.Trim());
                }
                if (!string.IsNullOrEmpty(txtMIntoNo.Text))
                {
                    object obj = Rule;
                    Rule = string.Concat(obj, " and ", txtMIntoNo.Tag, " <= ", txtMIntoNo.Text.Trim());
                }
                db.ExecuteCommand("Delete From T_INVDET_Repair Where 1 =1 " + Rule);
                Close();
            }
        }
    }
}
