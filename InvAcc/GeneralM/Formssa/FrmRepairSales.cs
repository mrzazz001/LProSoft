using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Framework.Date;
using Framework.UI;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Library.RepShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmRepairSales : Form
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
        private Label label10;
        private ComboBoxEx combobox_Inv;
        private GroupBox groupBox_No;
        private MaskedTextBox txtMIntoNo;
        private Label label1;
        private Label label2;
        private MaskedTextBox txtMFromNo;
        private GroupBox groupBox_Date;
        private MaskedTextBox txtMToDate;
        private Label label3;
        private Label label4;
        private MaskedTextBox txtMFromDate;
        private Label label7;
        private ComboBoxEx combobox_InvCost;
        private int LangArEn = 0;
        private T_User _User = new T_User();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private Stock_DataDataContext dbInstance;
        private SplitContainer splitContainer1;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRepairSales));
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
            this.label10 = new System.Windows.Forms.Label();
            this.combobox_Inv = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.groupBox_No = new System.Windows.Forms.GroupBox();
            this.txtMIntoNo = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMFromNo = new System.Windows.Forms.MaskedTextBox();
            this.groupBox_Date = new System.Windows.Forms.GroupBox();
            this.txtMToDate = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMFromDate = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.combobox_InvCost = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            ((System.ComponentModel.ISupportInitialize)(this.FlxInv)).BeginInit();
            this.groupBox_No.SuspendLayout();
            this.groupBox_Date.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FlxInv
            // 
            this.FlxInv.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.FlxInv.AllowEditing = false;
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
            this.FlxInv.Size = new System.Drawing.Size(1055, 458);
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
            this.label5.Location = new System.Drawing.Point(988, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 1122;
            this.label5.Text = "من صنف :";
            // 
            // txtFItemName
            // 
            this.txtFItemName.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtFItemName.ForeColor = System.Drawing.Color.White;
            this.txtFItemName.Location = new System.Drawing.Point(721, 8);
            this.txtFItemName.Name = "txtFItemName";
            this.txtFItemName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtFItemName, false);
            this.txtFItemName.Size = new System.Drawing.Size(152, 20);
            this.txtFItemName.TabIndex = 1121;
            this.txtFItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFItemNo
            // 
            this.txtFItemNo.BackColor = System.Drawing.Color.White;
            this.txtFItemNo.Location = new System.Drawing.Point(904, 8);
            this.txtFItemNo.Name = "txtFItemNo";
            this.txtFItemNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtFItemNo, false);
            this.txtFItemNo.Size = new System.Drawing.Size(79, 20);
            this.txtFItemNo.TabIndex = 1119;
            this.txtFItemNo.Tag = " T_Items.Itm_No ";
            this.txtFItemNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFItemNo.TextChanged += new System.EventHandler(this.txtFItemNo_TextChanged);
            // 
            // button_SrchItemFrom
            // 
            this.button_SrchItemFrom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchItemFrom.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchItemFrom.Location = new System.Drawing.Point(876, 8);
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
            this.txtInItemName.Location = new System.Drawing.Point(721, 36);
            this.txtInItemName.Name = "txtInItemName";
            this.txtInItemName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtInItemName, false);
            this.txtInItemName.Size = new System.Drawing.Size(152, 20);
            this.txtInItemName.TabIndex = 1125;
            this.txtInItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtInItemNo
            // 
            this.txtInItemNo.BackColor = System.Drawing.Color.White;
            this.txtInItemNo.Location = new System.Drawing.Point(904, 36);
            this.txtInItemNo.Name = "txtInItemNo";
            this.txtInItemNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtInItemNo, false);
            this.txtInItemNo.Size = new System.Drawing.Size(79, 20);
            this.txtInItemNo.TabIndex = 1123;
            this.txtInItemNo.Tag = " T_Items.Itm_No ";
            this.txtInItemNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInItemNo.TextChanged += new System.EventHandler(this.txtInItemNo_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(988, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 1126;
            this.label6.Text = "إلى صنف :";
            // 
            // button_SrchItemTo
            // 
            this.button_SrchItemTo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchItemTo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchItemTo.Location = new System.Drawing.Point(875, 36);
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
            this.ButOk.Location = new System.Drawing.Point(241, 8);
            this.ButOk.Name = "ButOk";
            this.ButOk.Size = new System.Drawing.Size(112, 55);
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
            this.ButExit.Location = new System.Drawing.Point(13, 8);
            this.ButExit.Name = "ButExit";
            this.ButExit.Size = new System.Drawing.Size(112, 55);
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
            this.Butupdate.Location = new System.Drawing.Point(127, 8);
            this.Butupdate.Name = "Butupdate";
            this.Butupdate.Size = new System.Drawing.Size(112, 55);
            this.Butupdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Butupdate.SymbolSize = 16F;
            this.Butupdate.TabIndex = 1129;
            this.Butupdate.Text = "تحديث الأسعار";
            this.Butupdate.TextColor = System.Drawing.Color.White;
            this.Butupdate.Click += new System.EventHandler(this.Butupdate_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(585, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 6722;
            this.label10.Text = "نوع الفاتورة :";
            // 
            // combobox_Inv
            // 
            this.combobox_Inv.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combobox_Inv.DisplayMember = "Text";
            this.combobox_Inv.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_Inv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_Inv.FormattingEnabled = true;
            this.combobox_Inv.ItemHeight = 14;
            this.combobox_Inv.Location = new System.Drawing.Point(380, 8);
            this.combobox_Inv.Name = "combobox_Inv";
            this.combobox_Inv.Size = new System.Drawing.Size(199, 20);
            this.combobox_Inv.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combobox_Inv.TabIndex = 6721;
            this.combobox_Inv.SelectedIndexChanged += new System.EventHandler(this.combobox_Inv_SelectedIndexChanged);
            // 
            // groupBox_No
            // 
            this.groupBox_No.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_No.Controls.Add(this.txtMIntoNo);
            this.groupBox_No.Controls.Add(this.label1);
            this.groupBox_No.Controls.Add(this.label2);
            this.groupBox_No.Controls.Add(this.txtMFromNo);
            this.groupBox_No.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.groupBox_No.Location = new System.Drawing.Point(541, 64);
            this.groupBox_No.Name = "groupBox_No";
            this.groupBox_No.Size = new System.Drawing.Size(506, 48);
            this.groupBox_No.TabIndex = 6724;
            this.groupBox_No.TabStop = false;
            this.groupBox_No.Text = "حسب رقم الفاتورة";
            // 
            // txtMIntoNo
            // 
            this.txtMIntoNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMIntoNo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtMIntoNo.Location = new System.Drawing.Point(55, 19);
            this.txtMIntoNo.Mask = "00000";
            this.txtMIntoNo.Name = "txtMIntoNo";
            this.txtMIntoNo.Size = new System.Drawing.Size(122, 22);
            this.txtMIntoNo.TabIndex = 2;
            this.txtMIntoNo.Tag = " T_INVHED.InvNo ";
            this.txtMIntoNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMIntoNo.Click += new System.EventHandler(this.txtMIntoNo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(447, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 857;
            this.label1.Text = "مـــــن :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(183, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 859;
            this.label2.Text = "إلـــــى :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMFromNo
            // 
            this.txtMFromNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMFromNo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtMFromNo.Location = new System.Drawing.Point(319, 19);
            this.txtMFromNo.Mask = "00000";
            this.txtMFromNo.Name = "txtMFromNo";
            this.txtMFromNo.Size = new System.Drawing.Size(122, 22);
            this.txtMFromNo.TabIndex = 1;
            this.txtMFromNo.Tag = " T_INVHED.InvNo ";
            this.txtMFromNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMFromNo.Click += new System.EventHandler(this.txtMFromNo_Click);
            // 
            // groupBox_Date
            // 
            this.groupBox_Date.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_Date.Controls.Add(this.txtMToDate);
            this.groupBox_Date.Controls.Add(this.label3);
            this.groupBox_Date.Controls.Add(this.label4);
            this.groupBox_Date.Controls.Add(this.txtMFromDate);
            this.groupBox_Date.Location = new System.Drawing.Point(29, 64);
            this.groupBox_Date.Name = "groupBox_Date";
            this.groupBox_Date.Size = new System.Drawing.Size(506, 48);
            this.groupBox_Date.TabIndex = 6723;
            this.groupBox_Date.TabStop = false;
            this.groupBox_Date.Text = "حسب تاريخ الفاتورة";
            // 
            // txtMToDate
            // 
            this.txtMToDate.Location = new System.Drawing.Point(55, 19);
            this.txtMToDate.Mask = "0000/00/00";
            this.txtMToDate.Name = "txtMToDate";
            this.txtMToDate.Size = new System.Drawing.Size(122, 20);
            this.txtMToDate.TabIndex = 4;
            this.txtMToDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMToDate.Click += new System.EventHandler(this.txtMToDate_Click);
            this.txtMToDate.Leave += new System.EventHandler(this.txtMToDate_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(447, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 860;
            this.label3.Text = "مـــــن :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(183, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 861;
            this.label4.Text = "إلـــــى :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMFromDate
            // 
            this.txtMFromDate.Location = new System.Drawing.Point(319, 19);
            this.txtMFromDate.Mask = "0000/00/00";
            this.txtMFromDate.Name = "txtMFromDate";
            this.txtMFromDate.Size = new System.Drawing.Size(122, 20);
            this.txtMFromDate.TabIndex = 3;
            this.txtMFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMFromDate.Click += new System.EventHandler(this.txtMFromDate_Click);
            this.txtMFromDate.Leave += new System.EventHandler(this.txtMFromDate_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(585, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 6726;
            this.label7.Text = "إعتماد التكلفة :";
            // 
            // combobox_InvCost
            // 
            this.combobox_InvCost.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combobox_InvCost.DisplayMember = "Text";
            this.combobox_InvCost.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_InvCost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_InvCost.FormattingEnabled = true;
            this.combobox_InvCost.ItemHeight = 14;
            this.combobox_InvCost.Location = new System.Drawing.Point(380, 39);
            this.combobox_InvCost.Name = "combobox_InvCost";
            this.combobox_InvCost.Size = new System.Drawing.Size(199, 20);
            this.combobox_InvCost.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combobox_InvCost.TabIndex = 6725;
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
            this.splitContainer1.Panel1.Controls.Add(this.txtFItemName);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.button_SrchItemFrom);
            this.splitContainer1.Panel1.Controls.Add(this.combobox_InvCost);
            this.splitContainer1.Panel1.Controls.Add(this.txtFItemNo);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox_No);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox_Date);
            this.splitContainer1.Panel1.Controls.Add(this.button_SrchItemTo);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.combobox_Inv);
            this.splitContainer1.Panel1.Controls.Add(this.txtInItemNo);
            this.splitContainer1.Panel1.Controls.Add(this.Butupdate);
            this.splitContainer1.Panel1.Controls.Add(this.txtInItemName);
            this.splitContainer1.Panel1.Controls.Add(this.ButExit);
            this.splitContainer1.Panel1.Controls.Add(this.ButOk);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.FlxInv);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(1055, 581);
            this.splitContainer1.SplitterDistance = 119;
            this.splitContainer1.TabIndex = 6727;
            // 
            // FrmRepairSales
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
            this.Name = "FrmRepairSales";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "معالج تحديث أسعار تكلفة المبيعات";
            this.Load += new System.EventHandler(this.FrmRepairSales_Load);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmRepairSales_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.FlxInv)).EndInit();
            this.groupBox_No.ResumeLayout(false);
            this.groupBox_No.PerformLayout();
            this.groupBox_Date.ResumeLayout(false);
            this.groupBox_Date.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        public FrmRepairSales()
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
            var qkeys = from item in db.T_INVHEDs
                        where item.InvTyp == (int?)VarGeneral.InvTyp
                        where item.IfDel == (int?)0
                        select new
                        {
                            Code = item.InvNo + ""
                        };
        }
        private string BuildRuleList()
        {
            HijriGregDates dateFormatter = new HijriGregDates();
            string Rule = "Where T_INVHED.IfDel = 0 ";
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
            if (VarGeneral.CheckDate(txtMFromDate.Text) && txtMFromDate.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMFromDate.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_INVHED.GDat  >= '" + dateFormatter.FormatGreg(txtMFromDate.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_INVHED.HDat  >= '" + dateFormatter.FormatHijri(txtMFromDate.Text, "yyyy/MM/dd") + "'"));
            }
            if (VarGeneral.CheckDate(txtMToDate.Text) && txtMToDate.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMToDate.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_INVHED.GDat  <= '" + dateFormatter.FormatHijri(txtMToDate.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_INVHED.HDat  <= '" + dateFormatter.FormatHijri(txtMToDate.Text, "yyyy/MM/dd") + "'"));
            }
            if (combobox_Inv.SelectedIndex == 0)
            {
                return Rule + " and T_INVHED.InvTyp = 1 ";
            }
            return Rule + " and T_INVHED.InvTyp = 3 ";
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            FlxInv.Rows.Count = 1;
            try
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = "T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No ";
                string Fields = " T_INVDET.*,T_INVHED.*";
                _RepShow.Rule = BuildRuleList();
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
                if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                {
                    FlxInv.Rows.Count = VarGeneral.RepData.Tables[0].Rows.Count + 1;
                    for (int iiCnt = 1; iiCnt <= VarGeneral.RepData.Tables[0].Rows.Count; iiCnt++)
                    {
                        DataRow _InvDet = VarGeneral.RepData.Tables[0].Rows[iiCnt - 1];
                        FlxInv.SetData(iiCnt, 0, iiCnt);
                        FlxInv.SetData(iiCnt, 1, _InvDet["ItmNo"].ToString().Trim());
                        FlxInv.SetData(iiCnt, 2, (LangArEn == 0) ? _InvDet["ItmDes"].ToString().Trim() : _InvDet["ItmDesE"].ToString().Trim());
                        FlxInv.SetData(iiCnt, 3, _InvDet["InvNo"].ToString().Trim());
                        FlxInv.SetData(iiCnt, 4, _InvDet["HDat"].ToString().Trim() + " || " + _InvDet["GDat"].ToString().Trim());
                        FlxInv.SetData(iiCnt, 5, Math.Abs(double.Parse(_InvDet["Qty"].ToString().Trim())));
                        FlxInv.SetData(iiCnt, 6, _InvDet["Price"].ToString().Trim());
                        FlxInv.SetData(iiCnt, 7, _InvDet["Cost"].ToString().Trim());
                        FlxInv.SetData(iiCnt, 8, db.StockItem(_InvDet["ItmNo"].ToString().Trim()).AvrageCost.Value.ToString());
                        FlxInv.SetData(iiCnt, 9, db.StockItem(_InvDet["ItmNo"].ToString().Trim()).LastCost.Value.ToString());
                        FlxInv.SetData(iiCnt, 10, _InvDet["InvDet_ID"].ToString().Trim());
                        FlxInv.SetData(iiCnt, 11, _InvDet["InvHed_ID"].ToString().Trim());
                    }
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }
        private void FrmRepairSales_Load(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmRepairSales));
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
            FillCombo();
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
            Text = "Update Prices Cost Process";
            FlxInv.Cols[1].Caption = "Item No";
            FlxInv.Cols[2].Caption = "Item Name";
            FlxInv.Cols[3].Caption = "Inv No";
            FlxInv.Cols[4].Caption = "Inv Date";
            FlxInv.Cols[5].Caption = "Qty";
            FlxInv.Cols[6].Caption = "Price";
            FlxInv.Cols[7].Caption = "Cost Now";
            FlxInv.Cols[8].Caption = "Cost New";
            FlxInv.Cols[9].Caption = "Last Cost";
            groupBox_No.Text = "Inovice No";
            groupBox_Date.Text = "Invoice Date";
        }
        public void FillCombo()
        {
            combobox_Inv.Items.Clear();
            combobox_Inv.Items.Add((LangArEn == 0) ? "مبيعات" : "Sales");
            combobox_Inv.Items.Add((LangArEn == 0) ? "مرتجع مبيعات" : "Returned sales invoice");
            combobox_Inv.SelectedIndex = 0;
            combobox_InvCost.Items.Clear();
            combobox_InvCost.Items.Add((LangArEn == 0) ? "متوسط التكلفة" : "Average Cost");
            combobox_InvCost.Items.Add((LangArEn == 0) ? "آخر تكلفة" : "Last Cost");
            combobox_InvCost.SelectedIndex = 0;
        }
        private void FrmRepairSales_KeyDown(object sender, KeyEventArgs e)
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
            if (FlxInv.Rows.Count <= 1 || MessageBox.Show("سيتم تحديث تكلفة المبيعات للاصناف المحددة  \n هل تريد الأستمرار ? ", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                return;
            }
            int iiCnt;
            for (iiCnt = 1; iiCnt < FlxInv.Rows.Count; iiCnt++)
            {
                try
                {
                    if (FlxInv.GetData(iiCnt, 1) == null)
                    {
                        continue;
                    }
                    db.ExecuteCommand("update T_INVDET set Cost = " + ((combobox_InvCost.SelectedIndex == 0) ? Math.Abs(double.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 8).ToString()))) : Math.Abs(double.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 9).ToString())))) + " where InvDet_ID = " + double.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 10).ToString())));
                    Stock_DataDataContext dbT = new Stock_DataDataContext(VarGeneral.BranchCS);
                    List<T_INVHED> q = (from t in dbT.T_INVHEDs
                                        where t.IfDel == (int?)0
                                        where t.InvTyp == (int?)((combobox_Inv.SelectedIndex == 0) ? 1 : 3)
                                        where t.InvHed_ID == int.Parse(VarGeneral.TString.TEmpty(FlxInv.GetData(iiCnt, 11).ToString()))
                                        select t).ToList();
                    if (q.Count > 0)
                    {
                        dbT.ExecuteCommand("update T_INVHED set InvCost = " + Math.Abs(q.FirstOrDefault().T_INVDETs.Sum((T_INVDET g) => g.Cost.Value * g.RealQty.Value)) + " where InvHed_ID = " + q.FirstOrDefault().InvHed_ID);
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
            txtMFromDate.Text = "";
            txtMToDate.Text = "";
        }
        private void txtMFromNo_Click(object sender, EventArgs e)
        {
            txtMFromNo.SelectAll();
        }
        private void txtMIntoNo_Click(object sender, EventArgs e)
        {
            txtMIntoNo.SelectAll();
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
    }
}
