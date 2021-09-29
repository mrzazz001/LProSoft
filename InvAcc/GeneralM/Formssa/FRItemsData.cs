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
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FRItemsData : Form
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
                        frm.Repvalue = "ItemsData";


                        frm.Repvalue = "ItemsData";
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
        private Label label4;
        private TextBox txtInItemName;
        private Label label3;
        private TextBox txtClassName;
        private MaskedTextBox txtMFromDate;
        private TextBox txtFItemName;
        private TextBox txtStoreName;
        private MaskedTextBox txtMIntoNo;
        private TextBox txtSuppName;
        private TextBox txtFItemNo;
        private TextBox txtInItemNo;
        private TextBox txtClassNo;
        private MaskedTextBox txtMFromNo;
        private TextBox txtStoreNo;
        private TextBox txtSuppNo;
        private MaskedTextBox txtMToDate;
        private Label label7;
        private Label label6;
        private ButtonX button_SrchStoreNo;
        private RibbonBar ribbonBar1;
        private ButtonX button_SrchSuppNo;
        private ButtonX button_SrchClassNo;
        private ButtonX button_SrchItemTo;
        private ButtonX button_SrchItemFrom;
        private GroupBox groupBox_Date;
        private GroupBox groupBox3;
        private Label label2;
        private C1FlexGrid FlexField;
        private Label label9;
        private Label label1;
        private Label label8;
        private Label label5;
        private Label label10;
        private ComboBoxEx combobox_Unit;
        private Label label11;
        private ComboBoxEx combobox_CostTyp;
        private CheckBox checkBox_OtherPrices;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRItemsData));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.ButOk = new C1.Win.C1Input.C1Button();
            this.ButExit = new C1.Win.C1Input.C1Button();
            this.checkBox_OtherPrices = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.combobox_CostTyp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label10 = new System.Windows.Forms.Label();
            this.combobox_Unit = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtInItemName = new System.Windows.Forms.TextBox();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.txtFItemName = new System.Windows.Forms.TextBox();
            this.txtStoreName = new System.Windows.Forms.TextBox();
            this.txtSuppName = new System.Windows.Forms.TextBox();
            this.txtFItemNo = new System.Windows.Forms.TextBox();
            this.txtInItemNo = new System.Windows.Forms.TextBox();
            this.txtClassNo = new System.Windows.Forms.TextBox();
            this.txtStoreNo = new System.Windows.Forms.TextBox();
            this.txtSuppNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_SrchStoreNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchSuppNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchClassNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchItemTo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchItemFrom = new DevComponents.DotNetBar.ButtonX();
            this.FlexField = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupBox_Date = new System.Windows.Forms.GroupBox();
            this.txtMToDate = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMFromDate = new System.Windows.Forms.MaskedTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMIntoNo = new System.Windows.Forms.MaskedTextBox();
            this.txtMFromNo = new System.Windows.Forms.MaskedTextBox();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.VisibleChanged += new System.EventHandler(this.FRInvoice_VisibleChanged);
            this.PanelSpecialContainer.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlexField)).BeginInit();
            this.groupBox_Date.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelSpecialContainer
            // 
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar1);
            this.PanelSpecialContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSpecialContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelSpecialContainer.Name = "PanelSpecialContainer";
            this.PanelSpecialContainer.Size = new System.Drawing.Size(506, 283);
            this.PanelSpecialContainer.TabIndex = 1220;
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
            this.ribbonBar1.Controls.Add(this.checkBox_OtherPrices);
            this.ribbonBar1.Controls.Add(this.label11);
            this.ribbonBar1.Controls.Add(this.combobox_CostTyp);
            this.ribbonBar1.Controls.Add(this.label10);
            this.ribbonBar1.Controls.Add(this.combobox_Unit);
            this.ribbonBar1.Controls.Add(this.label8);
            this.ribbonBar1.Controls.Add(this.label5);
            this.ribbonBar1.Controls.Add(this.label9);
            this.ribbonBar1.Controls.Add(this.txtInItemName);
            this.ribbonBar1.Controls.Add(this.txtClassName);
            this.ribbonBar1.Controls.Add(this.txtFItemName);
            this.ribbonBar1.Controls.Add(this.txtStoreName);
            this.ribbonBar1.Controls.Add(this.txtSuppName);
            this.ribbonBar1.Controls.Add(this.txtFItemNo);
            this.ribbonBar1.Controls.Add(this.txtInItemNo);
            this.ribbonBar1.Controls.Add(this.txtClassNo);
            this.ribbonBar1.Controls.Add(this.txtStoreNo);
            this.ribbonBar1.Controls.Add(this.txtSuppNo);
            this.ribbonBar1.Controls.Add(this.label7);
            this.ribbonBar1.Controls.Add(this.label6);
            this.ribbonBar1.Controls.Add(this.button_SrchStoreNo);
            this.ribbonBar1.Controls.Add(this.button_SrchSuppNo);
            this.ribbonBar1.Controls.Add(this.button_SrchClassNo);
            this.ribbonBar1.Controls.Add(this.button_SrchItemTo);
            this.ribbonBar1.Controls.Add(this.button_SrchItemFrom);
            this.ribbonBar1.Controls.Add(this.FlexField);
            this.ribbonBar1.Controls.Add(this.groupBox_Date);
            this.ribbonBar1.Controls.Add(this.groupBox3);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(506, 283);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 1101;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.Silver;
            this.ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ItemClick += new System.EventHandler(this.ribbonBar1_ItemClick);
            // 
            // ButOk
            // 
            this.ButOk.BackgroundImage = global::InvAcc.Properties.Resources.print;
            this.ButOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButOk.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButOk.Location = new System.Drawing.Point(232, 228);
            this.ButOk.Name = "ButOk";
            this.ButOk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButOk.Size = new System.Drawing.Size(227, 35);
            this.ButOk.TabIndex = 6748;
            this.ButOk.Text = "طباعه | Print";
            this.ButOk.UseVisualStyleBackColor = true;
            this.ButOk.Click += new System.EventHandler(this.ButOk_Click);
            this.ButOk.MouseLeave += new System.EventHandler(this.ButOk_MouseLeave);
            this.ButOk.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButOk_MouseMove);
            // 
            // ButExit
            // 
            this.ButExit.BackgroundImage = global::InvAcc.Properties.Resources.YALO2;
            this.ButExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButExit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButExit.Location = new System.Drawing.Point(47, 228);
            this.ButExit.Name = "ButExit";
            this.ButExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButExit.Size = new System.Drawing.Size(179, 35);
            this.ButExit.TabIndex = 6747;
            this.ButExit.Text = "خروج | ESC";
            this.ButExit.UseVisualStyleBackColor = true;
            this.ButExit.Click += new System.EventHandler(this.ButExit_Click);
            this.ButExit.MouseLeave += new System.EventHandler(this.ButExit_MouseLeave);
            this.ButExit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButExit_MouseMove);
            // 
            // checkBox_OtherPrices
            // 
            this.checkBox_OtherPrices.AutoSize = true;
            this.checkBox_OtherPrices.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_OtherPrices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_OtherPrices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.checkBox_OtherPrices.Location = new System.Drawing.Point(5, 204);
            this.checkBox_OtherPrices.Name = "checkBox_OtherPrices";
            this.checkBox_OtherPrices.Size = new System.Drawing.Size(120, 17);
            this.checkBox_OtherPrices.TabIndex = 6723;
            this.checkBox_OtherPrices.Text = "تقرير بالأسعار الأخرى";
            this.checkBox_OtherPrices.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox_OtherPrices.UseVisualStyleBackColor = false;
            this.checkBox_OtherPrices.Visible = false;
            this.checkBox_OtherPrices.CheckedChanged += new System.EventHandler(this.checkBox_OtherPrices_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(260, 206);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 6722;
            this.label11.Text = "حسب :";
            // 
            // combobox_CostTyp
            // 
            this.combobox_CostTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combobox_CostTyp.DisplayMember = "Text";
            this.combobox_CostTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_CostTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_CostTyp.FormattingEnabled = true;
            this.combobox_CostTyp.ItemHeight = 14;
            this.combobox_CostTyp.Location = new System.Drawing.Point(131, 202);
            this.combobox_CostTyp.Name = "combobox_CostTyp";
            this.combobox_CostTyp.Size = new System.Drawing.Size(124, 20);
            this.combobox_CostTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combobox_CostTyp.TabIndex = 6721;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(436, 206);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 6720;
            this.label10.Text = "الوحــــــدة :";
            // 
            // combobox_Unit
            // 
            this.combobox_Unit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combobox_Unit.DisplayMember = "Text";
            this.combobox_Unit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_Unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_Unit.FormattingEnabled = true;
            this.combobox_Unit.ItemHeight = 14;
            this.combobox_Unit.Location = new System.Drawing.Point(307, 202);
            this.combobox_Unit.Name = "combobox_Unit";
            this.combobox_Unit.Size = new System.Drawing.Size(126, 20);
            this.combobox_Unit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combobox_Unit.TabIndex = 6719;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(436, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 1117;
            this.label8.Text = "المــــورد :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(436, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 1118;
            this.label5.Text = "من صنف :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(436, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 1147;
            this.label9.Text = "المستودع :";
            // 
            // txtInItemName
            // 
            this.txtInItemName.BackColor = System.Drawing.Color.Ivory;
            this.txtInItemName.ForeColor = System.Drawing.Color.White;
            this.txtInItemName.Location = new System.Drawing.Point(5, 101);
            this.txtInItemName.Name = "txtInItemName";
            this.txtInItemName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtInItemName, false);
            this.txtInItemName.Size = new System.Drawing.Size(300, 20);
            this.txtInItemName.TabIndex = 6;
            this.txtInItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtClassName
            // 
            this.txtClassName.BackColor = System.Drawing.Color.Ivory;
            this.txtClassName.ForeColor = System.Drawing.Color.White;
            this.txtClassName.Location = new System.Drawing.Point(5, 126);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtClassName, false);
            this.txtClassName.Size = new System.Drawing.Size(300, 20);
            this.txtClassName.TabIndex = 9;
            this.txtClassName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFItemName
            // 
            this.txtFItemName.BackColor = System.Drawing.Color.Ivory;
            this.txtFItemName.ForeColor = System.Drawing.Color.White;
            this.txtFItemName.Location = new System.Drawing.Point(5, 76);
            this.txtFItemName.Name = "txtFItemName";
            this.txtFItemName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtFItemName, false);
            this.txtFItemName.Size = new System.Drawing.Size(300, 20);
            this.txtFItemName.TabIndex = 3;
            this.txtFItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStoreName
            // 
            this.txtStoreName.BackColor = System.Drawing.Color.Ivory;
            this.txtStoreName.ForeColor = System.Drawing.Color.White;
            this.txtStoreName.Location = new System.Drawing.Point(5, 176);
            this.txtStoreName.Name = "txtStoreName";
            this.txtStoreName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtStoreName, false);
            this.txtStoreName.Size = new System.Drawing.Size(300, 20);
            this.txtStoreName.TabIndex = 15;
            this.txtStoreName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSuppName
            // 
            this.txtSuppName.BackColor = System.Drawing.Color.Ivory;
            this.txtSuppName.ForeColor = System.Drawing.Color.White;
            this.txtSuppName.Location = new System.Drawing.Point(5, 151);
            this.txtSuppName.Name = "txtSuppName";
            this.txtSuppName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtSuppName, false);
            this.txtSuppName.Size = new System.Drawing.Size(300, 20);
            this.txtSuppName.TabIndex = 12;
            this.txtSuppName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFItemNo
            // 
            this.txtFItemNo.BackColor = System.Drawing.Color.White;
            this.txtFItemNo.Location = new System.Drawing.Point(335, 76);
            this.txtFItemNo.Name = "txtFItemNo";
            this.txtFItemNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtFItemNo, false);
            this.txtFItemNo.Size = new System.Drawing.Size(98, 20);
            this.txtFItemNo.TabIndex = 1;
            this.txtFItemNo.Tag = " T_Items.Itm_No ";
            this.txtFItemNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtInItemNo
            // 
            this.txtInItemNo.BackColor = System.Drawing.Color.White;
            this.txtInItemNo.Location = new System.Drawing.Point(335, 101);
            this.txtInItemNo.Name = "txtInItemNo";
            this.txtInItemNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtInItemNo, false);
            this.txtInItemNo.Size = new System.Drawing.Size(98, 20);
            this.txtInItemNo.TabIndex = 4;
            this.txtInItemNo.Tag = " T_Items.Itm_No ";
            this.txtInItemNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtClassNo
            // 
            this.txtClassNo.BackColor = System.Drawing.Color.White;
            this.txtClassNo.Location = new System.Drawing.Point(335, 126);
            this.txtClassNo.Name = "txtClassNo";
            this.txtClassNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtClassNo, false);
            this.txtClassNo.Size = new System.Drawing.Size(98, 20);
            this.txtClassNo.TabIndex = 7;
            this.txtClassNo.Tag = " T_CATEGORY.CAT_ID ";
            this.txtClassNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStoreNo
            // 
            this.txtStoreNo.BackColor = System.Drawing.Color.White;
            this.txtStoreNo.Location = new System.Drawing.Point(335, 176);
            this.txtStoreNo.Name = "txtStoreNo";
            this.txtStoreNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtStoreNo, false);
            this.txtStoreNo.Size = new System.Drawing.Size(98, 20);
            this.txtStoreNo.TabIndex = 13;
            this.txtStoreNo.Tag = " T_STKSQTY.storeNo ";
            this.txtStoreNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSuppNo
            // 
            this.txtSuppNo.BackColor = System.Drawing.Color.White;
            this.txtSuppNo.Location = new System.Drawing.Point(335, 151);
            this.txtSuppNo.Name = "txtSuppNo";
            this.txtSuppNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtSuppNo, false);
            this.txtSuppNo.Size = new System.Drawing.Size(98, 20);
            this.txtSuppNo.TabIndex = 10;
            this.txtSuppNo.Tag = " T_Items.DefultVendor ";
            this.txtSuppNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(436, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 1120;
            this.label7.Text = "التصنيـــف :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(436, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 1119;
            this.label6.Text = "إلى صنف :";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // button_SrchStoreNo
            // 
            this.button_SrchStoreNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchStoreNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchStoreNo.Location = new System.Drawing.Point(307, 176);
            this.button_SrchStoreNo.Name = "button_SrchStoreNo";
            this.button_SrchStoreNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchStoreNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchStoreNo.Symbol = "";
            this.button_SrchStoreNo.SymbolSize = 12F;
            this.button_SrchStoreNo.TabIndex = 14;
            this.button_SrchStoreNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchStoreNo.Click += new System.EventHandler(this.button_SrchStoreNo_Click);
            // 
            // button_SrchSuppNo
            // 
            this.button_SrchSuppNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchSuppNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchSuppNo.Location = new System.Drawing.Point(307, 151);
            this.button_SrchSuppNo.Name = "button_SrchSuppNo";
            this.button_SrchSuppNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchSuppNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchSuppNo.Symbol = "";
            this.button_SrchSuppNo.SymbolSize = 12F;
            this.button_SrchSuppNo.TabIndex = 11;
            this.button_SrchSuppNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchSuppNo.Click += new System.EventHandler(this.button_SrchSuppNo_Click);
            // 
            // button_SrchClassNo
            // 
            this.button_SrchClassNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchClassNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchClassNo.Location = new System.Drawing.Point(307, 126);
            this.button_SrchClassNo.Name = "button_SrchClassNo";
            this.button_SrchClassNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchClassNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchClassNo.Symbol = "";
            this.button_SrchClassNo.SymbolSize = 12F;
            this.button_SrchClassNo.TabIndex = 8;
            this.button_SrchClassNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchClassNo.Click += new System.EventHandler(this.button_SrchClassNo_Click);
            // 
            // button_SrchItemTo
            // 
            this.button_SrchItemTo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchItemTo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchItemTo.Location = new System.Drawing.Point(307, 101);
            this.button_SrchItemTo.Name = "button_SrchItemTo";
            this.button_SrchItemTo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchItemTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchItemTo.Symbol = "";
            this.button_SrchItemTo.SymbolSize = 12F;
            this.button_SrchItemTo.TabIndex = 5;
            this.button_SrchItemTo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchItemTo.Click += new System.EventHandler(this.button_SrchItemTo_Click);
            // 
            // button_SrchItemFrom
            // 
            this.button_SrchItemFrom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchItemFrom.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchItemFrom.Location = new System.Drawing.Point(307, 76);
            this.button_SrchItemFrom.Name = "button_SrchItemFrom";
            this.button_SrchItemFrom.Size = new System.Drawing.Size(26, 20);
            this.button_SrchItemFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchItemFrom.Symbol = "";
            this.button_SrchItemFrom.SymbolSize = 12F;
            this.button_SrchItemFrom.TabIndex = 2;
            this.button_SrchItemFrom.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchItemFrom.Click += new System.EventHandler(this.button_SrchItemFrom_Click);
            // 
            // FlexField
            // 
            this.FlexField.BackColor = System.Drawing.Color.White;
            this.FlexField.ColumnInfo = resources.GetString("FlexField.ColumnInfo");
            this.FlexField.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FlexField.Location = new System.Drawing.Point(6, 355);
            this.FlexField.Name = "FlexField";
            this.FlexField.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FlexField.Rows.DefaultSize = 19;
            this.FlexField.Size = new System.Drawing.Size(224, 231);
            this.FlexField.StyleInfo = resources.GetString("FlexField.StyleInfo");
            this.FlexField.TabIndex = 1146;
            // 
            // groupBox_Date
            // 
            this.groupBox_Date.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_Date.Controls.Add(this.txtMToDate);
            this.groupBox_Date.Controls.Add(this.label3);
            this.groupBox_Date.Controls.Add(this.label4);
            this.groupBox_Date.Controls.Add(this.txtMFromDate);
            this.groupBox_Date.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.groupBox_Date.Location = new System.Drawing.Point(5, 18);
            this.groupBox_Date.Name = "groupBox_Date";
            this.groupBox_Date.Size = new System.Drawing.Size(493, 48);
            this.groupBox_Date.TabIndex = 1109;
            this.groupBox_Date.TabStop = false;
            this.groupBox_Date.Text = "حسب تاريخ الركود";
            // 
            // txtMToDate
            // 
            this.txtMToDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMToDate.Location = new System.Drawing.Point(25, 19);
            this.txtMToDate.Mask = "0000/00/00";
            this.txtMToDate.Name = "txtMToDate";
            this.txtMToDate.Size = new System.Drawing.Size(108, 21);
            this.txtMToDate.TabIndex = 19;
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
            this.label3.Location = new System.Drawing.Point(401, 23);
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
            this.label4.Location = new System.Drawing.Point(139, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 861;
            this.label4.Text = "إلـــــى :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMFromDate
            // 
            this.txtMFromDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMFromDate.Location = new System.Drawing.Point(287, 19);
            this.txtMFromDate.Mask = "0000/00/00";
            this.txtMFromDate.Name = "txtMFromDate";
            this.txtMFromDate.Size = new System.Drawing.Size(108, 21);
            this.txtMFromDate.TabIndex = 18;
            this.txtMFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMFromDate.Click += new System.EventHandler(this.txtMFromDate_Click);
            this.txtMFromDate.Leave += new System.EventHandler(this.txtMFromDate_Leave);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtMIntoNo);
            this.groupBox3.Controls.Add(this.txtMFromNo);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.groupBox3.Location = new System.Drawing.Point(5, 18);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(493, 48);
            this.groupBox3.TabIndex = 1145;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "حسب الكمية";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(401, 24);
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
            this.label2.Location = new System.Drawing.Point(137, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 859;
            this.label2.Text = "إلـــــى :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMIntoNo
            // 
            this.txtMIntoNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMIntoNo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtMIntoNo.Location = new System.Drawing.Point(23, 19);
            this.txtMIntoNo.Mask = "00000";
            this.txtMIntoNo.Name = "txtMIntoNo";
            this.txtMIntoNo.Size = new System.Drawing.Size(108, 22);
            this.txtMIntoNo.TabIndex = 21;
            this.txtMIntoNo.Tag = " T_STKSQTY.stkQty  ";
            this.txtMIntoNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMIntoNo.Click += new System.EventHandler(this.txtMIntoNo_Click);
            // 
            // txtMFromNo
            // 
            this.txtMFromNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMFromNo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtMFromNo.Location = new System.Drawing.Point(287, 19);
            this.txtMFromNo.Mask = "00000";
            this.txtMFromNo.Name = "txtMFromNo";
            this.txtMFromNo.Size = new System.Drawing.Size(108, 22);
            this.txtMFromNo.TabIndex = 20;
            this.txtMFromNo.Tag = " T_STKSQTY.stkQty ";
            this.txtMFromNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMFromNo.Click += new System.EventHandler(this.txtMFromNo_Click);
            // 
            // netResize1
            // 
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            this.netResize1.ResizeMode = Softgroup.NetResize.NetResize.ResizeModeEnum.rmAdvanced;
            // 
            // FRItemsData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 283);
            this.Controls.Add(this.PanelSpecialContainer);
            this.Icon = global::InvAcc.Properties.Resources.favicon;
            this.KeyPreview = true;
            this.Name = "FRItemsData";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Load += new System.EventHandler(this.FRItemsData_Load);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.PanelSpecialContainer.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            this.ribbonBar1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlexField)).EndInit();
            this.groupBox_Date.ResumeLayout(false);
            this.groupBox_Date.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);
        }
        public FRItemsData()
        {
            InitializeComponent();
            _User = dbc.StockUser(VarGeneral.UserNumber);
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ButExit.Text = "خــــروج Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "طبـــاعة F5" : "عــــرض F5");
                groupBox3.Text = "حسب الكمية";
                groupBox_Date.Text = "حسب تاريخ الركود";
                label1.Text = "مـــــن :";
                label2.Text = "إلـــــى :";
                label3.Text = "مـــــن :";
                label4.Text = "إلـــــى :";
                label5.Text = "من صنف :";
                label6.Text = "إلى صنف :";
                label7.Text = "التصنيـــف :";
                label8.Text = "المــــورد :";
                label9.Text = "المستودع :";
            }
            else
            {
                ButExit.Text = "Exit Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "Print F5" : "Show F5");
                groupBox3.Text = "Quantity";
                groupBox_Date.Text = "Date of inactivity";
                label1.Text = "From :";
                label2.Text = "To :";
                label3.Text = "From :";
                label4.Text = "To :";
                label5.Text = "From Item :";
                label6.Text = "To Item :";
                label7.Text = "Category :";
                label8.Text = "Supplier :";
                label9.Text = "Store :";
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRItemsData));
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
            FillCombo();
            RepDef();
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptInvitationCards.dll"))
            {
                label8.Text = ((LangArEn == 0) ? "العميــــل :" : "Customer :");
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptGlasses.dll") || (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", "").Trim() + "\\SecriptGlasses.dll")))
            {
                checkBox_OtherPrices.Text = ((LangArEn == 0) ? "تقرير بمقاسات الأصناف" : "Items Sizes Report");
            }
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRItemsData));
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
            FillCombo();
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
                    Text = "بيانات الأصناف";
                    groupBox_Date.Visible = false;
                    txtMFromDate.Visible = false;
                    txtMToDate.Visible = false;
                    checkBox_OtherPrices.Visible = true;
                }
                else if (VarGeneral.InvType == 2)
                {
                    Text = "بيانات الأصناف وكمياتها";
                    groupBox_Date.Visible = false;
                    txtMFromDate.Visible = false;
                    txtMToDate.Visible = false;
                }
                else if (VarGeneral.InvType == 3)
                {
                    Text = "بيانات الأصناف وتكلفتها";
                    groupBox_Date.Visible = false;
                    txtMFromDate.Visible = false;
                    txtMToDate.Visible = false;
                }
                else if (VarGeneral.InvType == 4)
                {
                    Text = "الأصناف الواجب توفرها";
                    groupBox_Date.Visible = false;
                    txtMFromDate.Visible = false;
                    txtMToDate.Visible = false;
                    FlexField.Tag = " and T_Items.OpenQty <= T_Items.QtyLvl and T_Items.QtyLvl != 0 ";
                }
                else if (VarGeneral.InvType == 5)
                {
                    Text = "الأصناف الراكدة";
                    groupBox3.Visible = false;
                }
            }
            else if (VarGeneral.InvType == 1)
            {
                Text = "Items Data";
                groupBox_Date.Visible = false;
                txtMFromDate.Visible = false;
                txtMToDate.Visible = false;
                checkBox_OtherPrices.Visible = true;
            }
            else if (VarGeneral.InvType == 2)
            {
                Text = "Items Quantities";
                groupBox_Date.Visible = false;
                txtMFromDate.Visible = false;
                txtMToDate.Visible = false;
            }
            else if (VarGeneral.InvType == 3)
            {
                Text = "Items Cost";
                groupBox_Date.Visible = false;
                txtMFromDate.Visible = false;
                txtMToDate.Visible = false;
            }
            else if (VarGeneral.InvType == 4)
            {
                Text = "Items Order";
                groupBox_Date.Visible = false;
                txtMFromDate.Visible = false;
                txtMToDate.Visible = false;
                FlexField.Tag = " and T_Items.OpenQty <= T_Items.QtyLvl and T_Items.QtyLvl != 0 ";
            }
            else if (VarGeneral.InvType == 5)
            {
                Text = "UnSale Items";
            }
            RibunButtons();
        }
        private string BuildFieldList()
        {
            string Fields = "";
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                if (VarGeneral.InvType == 1)
                {
                    Fields = "T_Items.Itm_No, T_Items.Arb_Des as itemNm,T_Category.Arb_Des as CategoyNm,T_STKSQTY.storeNo,T_Items.Price1,T_Items.Price2,T_Items.Price3,T_Items.Price4,T_Items.Price5,T_Items.BarCod1, (select Arb_Des from T_AccDef where AccDef_No = T_Items.DefultVendor) as DefultVendor";
                    if (checkBox_OtherPrices.Checked && File.Exists(Application.StartupPath + "\\Script\\SecriptGlasses.dll"))
                    {
                        Fields = "T_Items.Itm_No, T_Items.Arb_Des as itemNm,T_Items.vSize1 as CategoyNm,T_STKSQTY.storeNo,T_Items.vSize4 as Price1,T_Items.vSize3 as Price2,T_Items.vSize2 as Price3,T_Items.vSize5 as Price4,T_Items.vSize5 as Price5,T_Items.BarCod1";
                    }
                    Fields = ((combobox_Unit.SelectedIndex > 0) ? string.Concat(Fields, ",(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = ", combobox_Unit.SelectedValue, ") as  UnitNm,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack5) END as Pack1,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END  as UntPri1,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm5") : (Fields + ",(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNm,(SELECT " + ((LangArEn == 0) ? "T_Unit.Arb_Des" : "T_Unit.Eng_Des") + " FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit2) as  UnitNm2,(SELECT " + ((LangArEn == 0) ? "T_Unit.Arb_Des" : "T_Unit.Eng_Des") + " FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit3) as  UnitNm3,(SELECT " + ((LangArEn == 0) ? "T_Unit.Arb_Des" : "T_Unit.Eng_Des") + " FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit4) as  UnitNm4,(SELECT " + ((LangArEn == 0) ? "T_Unit.Arb_Des" : "T_Unit.Eng_Des") + " FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit5) as  UnitNm5,T_Items.Pack1,T_Items.Pack2,T_Items.Pack3,T_Items.Pack4,T_Items.Pack5 ,(Round(T_Items.UntPri1," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri1,(Round(T_Items.UntPri2," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri2,(Round(T_Items.UntPri3," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri3,(Round(T_Items.UntPri4," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri4,(Round(T_Items.UntPri5," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri5 "));
                }
                else if (VarGeneral.InvType == 2)
                {
                    Fields = "T_Items.Itm_No,T_Items.Arb_Des as itemNm, (select Arb_Des from T_AccDef where AccDef_No = T_Items.DefultVendor) as DefultVendor ,T_STKSQTY.storeNo ";
                    Fields = ((combobox_Unit.SelectedIndex > 0) ? string.Concat(Fields, ",(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = ", combobox_Unit.SelectedValue, ") as  UnitNm,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack5) END as Pack1,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END  as UntPri1,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm5,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END)END as stkQty ") : (Fields + ",(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNm,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit2) as  UnitNm2,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit3) as  UnitNm3,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit4) as  UnitNm4,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit5) as  UnitNm5,T_Items.Pack1,T_Items.Pack2,T_Items.Pack3,T_Items.Pack4,T_Items.Pack5 ,(Round(T_Items.UntPri1," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri1,(Round(T_Items.UntPri2," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri2,(Round(T_Items.UntPri3," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri3,(Round(T_Items.UntPri4," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri4,(Round(T_Items.UntPri5," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri5,CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END as stkQty,CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END as stkQty2,CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END as stkQty3,CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END as stkQty4,CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END as stkQty5 "));
                }
                else if (VarGeneral.InvType == 3)
                {
                    Fields = "T_Items.Itm_No,T_Items.Arb_Des as itemNm, (select Arb_Des from T_AccDef where AccDef_No = T_Items.DefultVendor) as DefultVendor ,T_STKSQTY.storeNo ";
                    Fields = ((combobox_Unit.SelectedIndex > 0) ? string.Concat(Fields, ",(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = ", combobox_Unit.SelectedValue, ") as  UnitNm,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack5) END as Pack1,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END  as UntPri1,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm5,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END)END as stkQty ,", (combobox_CostTyp.SelectedIndex == 4) ? string.Concat(" ( CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, "))  WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, "))  WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END ) as AvrageCost ") : string.Concat("  CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round((", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round((", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round((", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round((", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round((", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack5) END as AvrageCost"), ",(Round(T_STKSQTY.stkQty * (", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack1) as StockNet") : (Fields + ",(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNm,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit2) as  UnitNm2,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit3) as  UnitNm3,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit4) as  UnitNm4,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit5) as  UnitNm5,T_Items.Pack1,T_Items.Pack2,T_Items.Pack3,T_Items.Pack4,T_Items.Pack5 ,(Round(T_Items.UntPri1," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri1,(Round(T_Items.UntPri2," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri2,(Round(T_Items.UntPri3," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri3,(Round(T_Items.UntPri4," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri4,(Round(T_Items.UntPri5," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri5,CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END as stkQty,CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END as stkQty2,CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END as stkQty3,CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END as stkQty4,CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END as stkQty5," + ((combobox_CostTyp.SelectedIndex == 4) ? ("Round(CASE WHEN  UntPri1 > 0 THEN (UntPri1) ElSE (0 ) END," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as AvrageCost,Round(CASE WHEN  UntPri2 > 0 THEN (UntPri2) ElSE (0 ) END ," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as AvrageCost2,Round(CASE WHEN  UntPri3 > 0 THEN (UntPri3) ElSE (0 ) END ," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as AvrageCost3,Round(CASE WHEN  UntPri4 > 0 THEN (UntPri4) ElSE (0 ) END ," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as AvrageCost4,Round(CASE WHEN  UntPri5 > 0 THEN (UntPri5) ElSE (0 ) END ," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as AvrageCost5") : (" (Round((" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as AvrageCost,(Round((" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack2) as AvrageCost2,(Round((" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack3) as AvrageCost3,(Round((" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack4) as AvrageCost4,(Round((" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack5) as AvrageCost5")) + ",(Round(T_STKSQTY.stkQty * (" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as StockNet,(Round(T_STKSQTY.stkQty * (" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack1) as StockNet2,(Round(T_STKSQTY.stkQty * (" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack1) as StockNet3,(Round(T_STKSQTY.stkQty * (" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack1) as StockNet4,(Round(T_STKSQTY.stkQty * (" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack1) as StockNet5 "));
                }
                else if (VarGeneral.InvType == 4)
                {
                    Fields = "T_Items.Itm_No,T_Items.Arb_Des as itemNm, (select Arb_Des from T_AccDef where AccDef_No = T_Items.DefultVendor) as DefultVendor ,T_STKSQTY.storeNo,(Round(T_Items.LastCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as LastCost,T_Items.QtyLvl ";
                    Fields = ((combobox_Unit.SelectedIndex > 0) ? string.Concat(Fields, ",(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = ", combobox_Unit.SelectedValue, ") as  UnitNm,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack5) END as Pack1,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END  as UntPri1,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm5,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END)END as stkQty ") : (Fields + ",(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNm,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit2) as  UnitNm2,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit3) as  UnitNm3,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit4) as  UnitNm4,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit5) as  UnitNm5,T_Items.Pack1,T_Items.Pack2,T_Items.Pack3,T_Items.Pack4,T_Items.Pack5 ,(Round(T_Items.UntPri1," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri1,(Round(T_Items.UntPri2," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri2,(Round(T_Items.UntPri3," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri3,(Round(T_Items.UntPri4," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri4,(Round(T_Items.UntPri5," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri5,CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END as stkQty,CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END as stkQty2,CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END as stkQty3,CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END as stkQty4,CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END as stkQty5 "));
                }
                else if (VarGeneral.InvType == 5)
                {
                    Fields = "T_Items.Itm_No,T_Items.Arb_Des as itemNm, (select Arb_Des from T_AccDef where AccDef_No = T_Items.DefultVendor) as DefultVendor ,T_STKSQTY.storeNo ";
                    Fields = ((combobox_Unit.SelectedIndex > 0) ? string.Concat(Fields, ",(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = ", combobox_Unit.SelectedValue, ") as  UnitNm,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack5) END as Pack1,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END  as UntPri1,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm5,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END)END as stkQty ") : (Fields + ",(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNm,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit2) as  UnitNm2,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit3) as  UnitNm3,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit4) as  UnitNm4,(SELECT T_Unit.Arb_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit5) as  UnitNm5,T_Items.Pack1,T_Items.Pack2,T_Items.Pack3,T_Items.Pack4,T_Items.Pack5 ,(Round(T_Items.UntPri1," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri1,(Round(T_Items.UntPri2," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri2,(Round(T_Items.UntPri3," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri3,(Round(T_Items.UntPri4," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri4,(Round(T_Items.UntPri5," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri5,CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END as stkQty,CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END as stkQty2,CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END as stkQty3,CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END as stkQty4,CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END as stkQty5 "));
                }
            }
            else if (VarGeneral.InvType == 1)
            {
                Fields = "T_Items.Itm_No, T_Items.Eng_Des as itemNm,T_Category.Eng_Des as CategoyNm,T_STKSQTY.storeNo,T_Items.Price1,T_Items.Price2,T_Items.Price3,T_Items.Price4,T_Items.Price5,T_Items.BarCod1, (select Eng_Des from T_AccDef where AccDef_No = T_Items.DefultVendor) as DefultVendor";
                if (checkBox_OtherPrices.Checked && File.Exists(Application.StartupPath + "\\Script\\SecriptGlasses.dll"))
                {
                    Fields = "T_Items.Itm_No, T_Items.Arb_Des as itemNm,T_Items.vSize1 as CategoyNm,T_STKSQTY.storeNo,T_Items.vSize4 as Price1,T_Items.vSize3 as Price2,T_Items.vSize2 as Price3,T_Items.vSize5 as Price4,T_Items.vSize5 as Price5,T_Items.BarCod1";
                }
                Fields = ((combobox_Unit.SelectedIndex > 0) ? string.Concat(Fields, ",(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = ", combobox_Unit.SelectedValue, ") as  UnitNm,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack5) END as Pack1,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END  as UntPri1,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm5") : (Fields + ",(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNm,(SELECT " + ((LangArEn == 0) ? "T_Unit.Eng_Des" : "T_Unit.Eng_Des") + " FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit2) as  UnitNm2,(SELECT " + ((LangArEn == 0) ? "T_Unit.Eng_Des" : "T_Unit.Eng_Des") + " FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit3) as  UnitNm3,(SELECT " + ((LangArEn == 0) ? "T_Unit.Eng_Des" : "T_Unit.Eng_Des") + " FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit4) as  UnitNm4,(SELECT " + ((LangArEn == 0) ? "T_Unit.Eng_Des" : "T_Unit.Eng_Des") + " FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit5) as  UnitNm5,T_Items.Pack1,T_Items.Pack2,T_Items.Pack3,T_Items.Pack4,T_Items.Pack5 ,(Round(T_Items.UntPri1," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri1,(Round(T_Items.UntPri2," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri2,(Round(T_Items.UntPri3," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri3,(Round(T_Items.UntPri4," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri4,(Round(T_Items.UntPri5," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri5 "));
            }
            else if (VarGeneral.InvType == 2)
            {
                Fields = "T_Items.Itm_No,T_Items.Eng_Des as itemNm, (select Eng_Des from T_AccDef where AccDef_No = T_Items.DefultVendor) as DefultVendor ,T_STKSQTY.storeNo ";
                Fields = ((combobox_Unit.SelectedIndex > 0) ? string.Concat(Fields, ",(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = ", combobox_Unit.SelectedValue, ") as  UnitNm,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack5) END as Pack1,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END  as UntPri1,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm5,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0) END)END as stkQty ") : (Fields + ",(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNm,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit2) as  UnitNm2,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit3) as  UnitNm3,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit4) as  UnitNm4,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit5) as  UnitNm5,T_Items.Pack1,T_Items.Pack2,T_Items.Pack3,T_Items.Pack4,T_Items.Pack5 ,(Round(T_Items.UntPri1," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri1,(Round(T_Items.UntPri2," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri2,(Round(T_Items.UntPri3," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri3,(Round(T_Items.UntPri4," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri4,(Round(T_Items.UntPri5," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri5,CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END as stkQty,CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END as stkQty2,CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END as stkQty3,CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END as stkQty4,CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END as stkQty5 "));
            }
            else if (VarGeneral.InvType == 3)
            {
                Fields = "T_Items.Itm_No,T_Items.Eng_Des as itemNm, (select Eng_Des from T_AccDef where AccDef_No = T_Items.DefultVendor) as DefultVendor ,T_STKSQTY.storeNo ";
                Fields = ((combobox_Unit.SelectedIndex > 0) ? string.Concat(Fields, ",(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = ", combobox_Unit.SelectedValue, ") as  UnitNm,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack5) END as Pack1,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END  as UntPri1,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm5,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0) END)END as stkQty ,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round((", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round((", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round((", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round((", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round((", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack5) END as AvrageCost,(Round(T_STKSQTY.stkQty * (", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack1) as StockNet") : (Fields + ",(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNm,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit2) as  UnitNm2,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit3) as  UnitNm3,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit4) as  UnitNm4,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit5) as  UnitNm5,T_Items.Pack1,T_Items.Pack2,T_Items.Pack3,T_Items.Pack4,T_Items.Pack5 ,(Round(T_Items.UntPri1," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri1,(Round(T_Items.UntPri2," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri2,(Round(T_Items.UntPri3," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri3,(Round(T_Items.UntPri4," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri4,(Round(T_Items.UntPri5," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri5,CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END as stkQty,CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END as stkQty2,CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END as stkQty3,CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END as stkQty4,CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END as stkQty5,(Round((" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as AvrageCost,(Round((" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack2) as AvrageCost2,(Round((" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack3) as AvrageCost3,(Round((" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack4) as AvrageCost4,(Round((" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack5) as AvrageCost5,(Round(T_STKSQTY.stkQty * (" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as StockNet,(Round(T_STKSQTY.stkQty * (" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack1) as StockNet2,(Round(T_STKSQTY.stkQty * (" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack1) as StockNet3,(Round(T_STKSQTY.stkQty * (" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack1) as StockNet4,(Round(T_STKSQTY.stkQty * (" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack1) as StockNet5 "));
                Fields = ((combobox_Unit.SelectedIndex > 0) ? string.Concat(Fields, ",(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = ", combobox_Unit.SelectedValue, ") as  UnitNm,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack5) END as Pack1,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END  as UntPri1,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm5,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END)END as stkQty ,", (combobox_CostTyp.SelectedIndex == 4) ? string.Concat(" ( CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, "))  WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, "))  WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END ) as AvrageCost ") : string.Concat("  CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round((", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round((", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round((", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round((", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round((", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack5) END as AvrageCost"), ",(Round(T_STKSQTY.stkQty * (", (combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost ")), "),", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ") * Pack1) as StockNet") : (Fields + ",(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNm,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit2) as  UnitNm2,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit3) as  UnitNm3,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit4) as  UnitNm4,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit5) as  UnitNm5,T_Items.Pack1,T_Items.Pack2,T_Items.Pack3,T_Items.Pack4,T_Items.Pack5 ,(Round(T_Items.UntPri1," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri1,(Round(T_Items.UntPri2," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri2,(Round(T_Items.UntPri3," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri3,(Round(T_Items.UntPri4," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri4,(Round(T_Items.UntPri5," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri5,CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END as stkQty,CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END as stkQty2,CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END as stkQty3,CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END as stkQty4,CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END as stkQty5," + ((combobox_CostTyp.SelectedIndex == 4) ? ("Round(CASE WHEN  UntPri1 > 0 THEN (UntPri1) ElSE (0 ) END," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as AvrageCost,Round(CASE WHEN  UntPri2 > 0 THEN (UntPri2) ElSE (0 ) END ," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as AvrageCost2,Round(CASE WHEN  UntPri3 > 0 THEN (UntPri3) ElSE (0 ) END ," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as AvrageCost3,Round(CASE WHEN  UntPri4 > 0 THEN (UntPri4) ElSE (0 ) END ," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as AvrageCost4,Round(CASE WHEN  UntPri5 > 0 THEN (UntPri5) ElSE (0 ) END ," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") as AvrageCost5") : (" (Round((" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as AvrageCost,(Round((" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack2) as AvrageCost2,(Round((" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack3) as AvrageCost3,(Round((" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack4) as AvrageCost4,(Round((" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack5) as AvrageCost5")) + ",(Round(T_STKSQTY.stkQty * (" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as StockNet,(Round(T_STKSQTY.stkQty * (" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack1) as StockNet2,(Round(T_STKSQTY.stkQty * (" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack1) as StockNet3,(Round(T_STKSQTY.stkQty * (" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack1) as StockNet4,(Round(T_STKSQTY.stkQty * (" + ((combobox_CostTyp.SelectedIndex == 0) ? " T_Items.AvrageCost " : ((combobox_CostTyp.SelectedIndex == 1) ? " T_Items.LastCost " : ((combobox_CostTyp.SelectedIndex == 2) ? " T_Items.StartCost " : " T_Items.FirstCost "))) + ")," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ") * Pack1) as StockNet5 "));
            }
            else if (VarGeneral.InvType == 4)
            {
                Fields = "T_Items.Itm_No,T_Items.Eng_Des as itemNm, (select Eng_Des from T_AccDef where AccDef_No = T_Items.DefultVendor) as DefultVendor ,T_STKSQTY.storeNo,(Round(T_Items.LastCost," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as LastCost,T_Items.QtyLvl ";
                Fields = ((combobox_Unit.SelectedIndex > 0) ? string.Concat(Fields, ",(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = ", combobox_Unit.SelectedValue, ") as  UnitNm,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack5) END as Pack1,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END  as UntPri1,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm5,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0) END)END as stkQty ") : (Fields + ",(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNm,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit2) as  UnitNm2,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit3) as  UnitNm3,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit4) as  UnitNm4,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit5) as  UnitNm5,T_Items.Pack1,T_Items.Pack2,T_Items.Pack3,T_Items.Pack4,T_Items.Pack5 ,(Round(T_Items.UntPri1," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri1,(Round(T_Items.UntPri2," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri2,(Round(T_Items.UntPri3," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri3,(Round(T_Items.UntPri4," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri4,(Round(T_Items.UntPri5," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri5,CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END as stkQty,CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END as stkQty2,CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END as stkQty3,CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END as stkQty4,CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END as stkQty5 "));
            }
            else if (VarGeneral.InvType == 5)
            {
                Fields = "T_Items.Itm_No,T_Items.Eng_Des as itemNm, (select Eng_Des from T_AccDef where AccDef_No = T_Items.DefultVendor) as DefultVendor ,T_STKSQTY.storeNo ";
                Fields = ((combobox_Unit.SelectedIndex > 0) ? string.Concat(Fields, ",(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = ", combobox_Unit.SelectedValue, ") as  UnitNm,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack1) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack2) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack3) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack4) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (T_Items.Pack5) END as Pack1,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri1,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri2,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri3,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri4,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (Round(T_Items.UntPri5,", VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2, ")) END  as UntPri1,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm2,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm3,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm4,(SELECT T_INVSETTING.FldE5 FROM T_INVSETTING WHERE T_INVSETTING.InvSet_ID = 1 ) as  UnitNm5,CASE WHEN T_Items.Unit1 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END) WHEN T_Items.Unit2 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END) WHEN T_Items.Unit3 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END) WHEN T_Items.Unit4 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END) WHEN T_Items.Unit5 = ", combobox_Unit.SelectedValue, " THEN (CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0) END)END as stkQty ") : (Fields + ",(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit1) as  UnitNm,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit2) as  UnitNm2,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit3) as  UnitNm3,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit4) as  UnitNm4,(SELECT T_Unit.Eng_Des FROM T_Unit WHERE T_Unit.Unit_ID = T_Items.Unit5) as  UnitNm5,T_Items.Pack1,T_Items.Pack2,T_Items.Pack3,T_Items.Pack4,T_Items.Pack5 ,(Round(T_Items.UntPri1," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri1,(Round(T_Items.UntPri2," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri2,(Round(T_Items.UntPri3," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri3,(Round(T_Items.UntPri4," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri4,(Round(T_Items.UntPri5," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as UntPri5,CASE WHEN  Pack1 > 0 THEN (T_STKSQTY.stkQty / Pack1) ElSE (0 ) END as stkQty,CASE WHEN  Pack2 > 0 THEN (T_STKSQTY.stkQty / Pack2) ElSE (0 ) END as stkQty2,CASE WHEN  Pack3 > 0 THEN (T_STKSQTY.stkQty / Pack3) ElSE (0 ) END as stkQty3,CASE WHEN  Pack4 > 0 THEN (T_STKSQTY.stkQty / Pack4) ElSE (0 ) END as stkQty4,CASE WHEN  Pack5 > 0 THEN (T_STKSQTY.stkQty / Pack5) ElSE (0 ) END as stkQty5 "));
            }
            return Fields + " ,T_SYSSETTING.LogImg ";
        }
        private string BuildRuleList()
        {
            HijriGregDates dateFormatter = new HijriGregDates();
            string Rule = "Where 1 = 1 " + FlexField.Tag;
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
            try
            {
                db.ExecuteCommand("select CONVERT(int,T_Items.Itm_No) from T_Items");
                if (!string.IsNullOrEmpty(txtFItemNo.Text))
                {
                    object obj = Rule;
                    Rule = string.Concat(obj, " and ", txtFItemNo.Tag, " >= ", txtFItemNo.Text.Trim());
                }
                if (!string.IsNullOrEmpty(txtInItemNo.Text))
                {
                    object obj = Rule;
                    Rule = string.Concat(obj, " and ", txtInItemNo.Tag, " <= ", txtInItemNo.Text.Trim());
                }
            }
            catch
            {
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
            }
            if (!string.IsNullOrEmpty(txtSuppNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtSuppNo.Tag, " = ", txtSuppNo.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtStoreNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtStoreNo.Tag, " = '", txtStoreNo.Text.Trim(), "'");
            }
            if (!string.IsNullOrEmpty(txtClassNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtClassNo.Tag, " = ", txtClassNo.Text.Trim());
            }
            if (VarGeneral.CheckDate(txtMFromDate.Text) && !VarGeneral.CheckDate(txtMToDate.Text))
            {
                Rule = ((int.Parse(txtMFromDate.Text.Substring(0, 4)) < 1800) ? ((VarGeneral.InvType == 5) ? (Rule + " and T_Items.Itm_No Not in (select T_INVDET.ItmNo from T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where  T_INVHED.HDat  >= '" + dateFormatter.FormatHijri(txtMFromDate.Text, "yyyy/MM/dd") + "')") : (Rule + " and  T_INVHED.HDat  >= '" + dateFormatter.FormatHijri(txtMFromDate.Text, "yyyy/MM/dd") + "'")) : ((VarGeneral.InvType == 5) ? (Rule + " and T_Items.Itm_No Not in (select T_INVDET.ItmNo from T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where  T_INVHED.GDat  >= '" + dateFormatter.FormatGreg(txtMFromDate.Text, "yyyy/MM/dd") + "')") : (Rule + " and  T_INVHED.GDat  >= '" + dateFormatter.FormatGreg(txtMFromDate.Text, "yyyy/MM/dd") + "'")));
            }
            else if (VarGeneral.CheckDate(txtMToDate.Text) && !VarGeneral.CheckDate(txtMFromDate.Text))
            {
                Rule = ((int.Parse(txtMToDate.Text.Substring(0, 4)) < 1800) ? ((VarGeneral.InvType == 5) ? (Rule + " and T_Items.Itm_No Not in (select T_INVDET.ItmNo from T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where  T_INVHED.HDat  <= '" + dateFormatter.FormatHijri(txtMToDate.Text, "yyyy/MM/dd") + "')") : (Rule + " and  T_INVHED.HDat  <= '" + dateFormatter.FormatHijri(txtMToDate.Text, "yyyy/MM/dd") + "'")) : ((VarGeneral.InvType == 5) ? (Rule + " and T_Items.Itm_No Not in (select T_INVDET.ItmNo from T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where  T_INVHED.GDat  <= '" + dateFormatter.FormatGreg(txtMToDate.Text, "yyyy/MM/dd") + "')") : (Rule + " and  T_INVHED.GDat  <= '" + dateFormatter.FormatGreg(txtMToDate.Text, "yyyy/MM/dd") + "'")));
            }
            else if (VarGeneral.CheckDate(txtMFromDate.Text) && VarGeneral.CheckDate(txtMToDate.Text))
            {
                if (int.Parse(txtMFromDate.Text.Substring(0, 4)) < 1800)
                {
                    if (VarGeneral.InvType != 5)
                    {
                        string text = Rule;
                        Rule = text + " and  T_INVHED.HDat  >= '" + dateFormatter.FormatHijri(txtMFromDate.Text, "yyyy/MM/dd") + "'  and T_INVHED.HDat  <= '" + dateFormatter.FormatHijri(txtMToDate.Text, "yyyy/MM/dd") + "'";
                    }
                    else
                    {
                        string text = Rule;
                        Rule = text + " and T_Items.Itm_No Not in (select T_INVDET.ItmNo from T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where  T_INVHED.HDat  >= '" + dateFormatter.FormatHijri(txtMFromDate.Text, "yyyy/MM/dd") + "' and T_INVHED.HDat  <= '" + dateFormatter.FormatHijri(txtMToDate.Text, "yyyy/MM/dd") + "')";
                    }
                }
                else if (VarGeneral.InvType != 5)
                {
                    string text = Rule;
                    Rule = text + " and  T_INVHED.GDat  >= '" + dateFormatter.FormatGreg(txtMFromDate.Text, "yyyy/MM/dd") + "' and T_INVHED.GDat  <= '" + dateFormatter.FormatGreg(txtMToDate.Text, "yyyy/MM/dd") + "'";
                }
                else
                {
                    string text = Rule;
                    Rule = text + " and T_Items.Itm_No Not in (select T_INVDET.ItmNo from T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID where  T_INVHED.GDat  >= '" + dateFormatter.FormatGreg(txtMFromDate.Text, "yyyy/MM/dd") + "' and T_INVHED.GDat  <= '" + dateFormatter.FormatGreg(txtMToDate.Text, "yyyy/MM/dd") + "')";
                }
            }
            if (combobox_Unit.SelectedIndex > 0)
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and (T_Items.Unit1 = ", combobox_Unit.SelectedValue, " or  T_Items.Unit2 = ", combobox_Unit.SelectedValue, " or T_Items.Unit3 = ", combobox_Unit.SelectedValue, " or T_Items.Unit4 = ", combobox_Unit.SelectedValue, " or T_Items.Unit5 = ", combobox_Unit.SelectedValue, ")");
            }
            if (VarGeneral.InvType == 2 || VarGeneral.InvType == 3 || VarGeneral.InvType == 4 || VarGeneral.InvType == 5)
            {
                Rule += " and T_Items.ItmTyp != 2 ";
            }
            return Rule;
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (Text == "بيانات الأصناف" || Text == "Items Data")
                {
                    VarGeneral.InvType = 1;
                }
                else if (Text == "بيانات الأصناف وكمياتها" || Text == "Items Quantities")
                {
                    VarGeneral.InvType = 2;
                }
                else if (Text == "بيانات الأصناف وتكلفتها" || Text == "Items Cost")
                {
                    VarGeneral.InvType = 3;
                }
                else if (Text == "الأصناف الواجب توفرها" || Text == "Items Order")
                {
                    VarGeneral.InvType = 4;
                }
                else if (Text == "الأصناف الراكدة" || Text == "UnSale Items")
                {
                    VarGeneral.InvType = 5;
                }
                VarGeneral.itmDes = "";
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Items LEFT OUTER JOIN  T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID  LEFT OUTER JOIN T_STKSQTY On T_Items.Itm_No = T_STKSQTY.itmNo Left Join T_SYSSETTING ON T_Items.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                string Fields = BuildFieldList();
                _RepShow.Rule = BuildRuleList() + ((VarGeneral.InvType != 3 && combobox_CostTyp.SelectedIndex > 0) ? " order by case when DefultVendor is null then 1 else 0 end, DefultVendor  " : " order by  CONVERT(INT, LEFT(T_Items.Itm_No, PATINDEX('%[^0-9]%', T_Items.Itm_No + 'z')-1))");
                _RepShow.Fields = Fields;
                try
                {
                    try
                    {
                        db.ExecuteCommand("select " + _RepShow.Fields + " From " + _RepShow.Tables + _RepShow.Rule);
                    }
                    catch
                    {
                        _RepShow.Rule = BuildRuleList() + " order by T_Items.Itm_No ";
                    }
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.Message);
                }
                string f = VarGeneral.getselect(_RepShow.Fields, _RepShow.Tables, _RepShow.Rule);
                if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "عفوا .. لا يوجد بيانات لعرضها في التقرير " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                try
                {
                    VarGeneral.IsGeneralUsed = true;
                    FrmReportsViewer frm = new FrmReportsViewer();
                    frm.Repvalue = "ItemsData";



                    frm.Tag = LangArEn;
                    frm.Repvalue = "ItemsData";
                    VarGeneral.vTitle = Text;
                    if (VarGeneral.InvType == 3)
                    {
                        VarGeneral.Customerlbl = combobox_CostTyp.Text;
                    }
                    try
                    {
                        if (checkBox_OtherPrices.Checked)
                        {
                            VarGeneral.itmDes = "OtherPrice";
                        }
                    }
                    catch
                    {
                        VarGeneral.itmDes = "";
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
        private void txtMFromDate_Click(object sender, EventArgs e)
        {
            txtMFromDate.SelectAll();
        }
        private void txtMToDate_Click(object sender, EventArgs e)
        {
            txtMToDate.SelectAll();
        }
        private void txtMFromNo_Click(object sender, EventArgs e)
        {
            txtMFromNo.SelectAll();
        }
        private void txtMIntoNo_Click(object sender, EventArgs e)
        {
            txtMIntoNo.SelectAll();
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
        private void button_SrchClassNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("CAT_No", new ColumnDictinary("الرمـــز", "CATEGORY No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_CATEGORY";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtClassNo.Text = db.StockCat(frm.Serach_No).CAT_ID.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtClassName.Text = db.StockCat(frm.Serach_No).Arb_Des;
                }
                else
                {
                    txtClassName.Text = db.StockCat(frm.Serach_No).Eng_Des;
                }
            }
            else
            {
                txtClassNo.Text = "";
                txtClassName.Text = "";
            }
        }
        private void button_SrchSuppNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_AccDef_Suppliers";
            VarGeneral.AccTyp = 5;
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptInvitationCards.dll"))
            {
                VarGeneral.AccTyp = 4;
            }
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtSuppNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtSuppName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    txtSuppName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
            }
            else
            {
                txtSuppNo.Text = "";
                txtSuppName.Text = "";
            }
        }
        private void button_SrchStoreNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("Stor_ID", new ColumnDictinary("رقم المستودع", "Store No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
            columns_Names_visible.Add("Address", new ColumnDictinary("العنوان", "Adress", ifDefault: false, ""));
            columns_Names_visible.Add("Tel", new ColumnDictinary("الهاتف", "Phone", ifDefault: false, ""));
            columns_Names_visible.Add("City", new ColumnDictinary("المدينة", "City", ifDefault: false, ""));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_Store";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtStoreNo.Text = frm.Serach_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtStoreName.Text = db.StockStore(int.Parse(frm.Serach_No.ToString())).Arb_Des.ToString();
                }
                else
                {
                    txtStoreName.Text = db.StockStore(int.Parse(frm.Serach_No.ToString())).Eng_Des.ToString();
                }
            }
            else
            {
                txtStoreNo.Text = "";
                txtStoreName.Text = "";
            }
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
        private void FRItemsData_Load(object sender, EventArgs e)
        {
        }
        private void FillCombo()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                List<T_Unit> listUnit1 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
                listUnit1.Insert(0, new T_Unit());
                listUnit1[0].Arb_Des = "الكـل";
                combobox_Unit.DataSource = listUnit1;
                combobox_Unit.DisplayMember = "Arb_Des";
                combobox_Unit.ValueMember = "Unit_ID";
                combobox_Unit.SelectedIndex = 0;
            }
            else
            {
                List<T_Unit> listUnit1 = new List<T_Unit>(db.T_Units.Select((T_Unit item) => item).ToList());
                listUnit1.Insert(0, new T_Unit());
                listUnit1[0].Eng_Des = "ALL";
                combobox_Unit.DataSource = listUnit1;
                combobox_Unit.DisplayMember = "Eng_Des";
                combobox_Unit.ValueMember = "Unit_ID";
                combobox_Unit.SelectedIndex = 0;
            }
            combobox_CostTyp.Items.Clear();
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                if (VarGeneral.InvType == 3)
                {
                    combobox_CostTyp.Items.Add("متوسط التكلفة");
                    combobox_CostTyp.Items.Add("آخر تكلفة");
                    combobox_CostTyp.Items.Add("التكلفة الأفتتاحية");
                    combobox_CostTyp.Items.Add("أول تكلفة");
                    combobox_CostTyp.Items.Add("سعر البيع");
                }
                else
                {
                    combobox_CostTyp.Items.Add("رقم الصنف");
                    combobox_CostTyp.Items.Add("الموردين");
                }
            }
            else if (VarGeneral.InvType == 3)
            {
                combobox_CostTyp.Items.Add("Average Cost");
                combobox_CostTyp.Items.Add("Last Cost");
                combobox_CostTyp.Items.Add("Open Cost");
                combobox_CostTyp.Items.Add("First Cost");
                combobox_CostTyp.Items.Add("Sale Price");
            }
            else
            {
                combobox_CostTyp.Items.Add("Item No");
                combobox_CostTyp.Items.Add("Suppliers");
            }
            combobox_CostTyp.SelectedIndex = 0;
        }
        private void label6_Click(object sender, EventArgs e)
        {
        }
        private void ribbonBar1_ItemClick(object sender, EventArgs e)
        {
        }
        private void checkBox_OtherPrices_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_OtherPrices.Checked)
            {
                combobox_Unit.SelectedIndex = 0;
                combobox_Unit.Enabled = false;
            }
            else
            {
                combobox_Unit.SelectedIndex = 0;
                combobox_Unit.Enabled = true;
            }
        }
        private void ButOk_MouseMove(object sender, MouseEventArgs e)
        {
            ButOk.BackgroundImage = Properties.Resources.howver;
            ButOk.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void ButOk_MouseLeave(object sender, EventArgs e)
        {
            ButOk.BackgroundImage = Properties.Resources.print;
            ButOk.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void ButExit_MouseMove(object sender, MouseEventArgs e)
        {
            ButExit.BackgroundImage = Properties.Resources.howver;
            ButExit.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void ButExit_MouseLeave(object sender, EventArgs e)
        {
            ButExit.BackgroundImage = Properties.Resources.YALO2;
            ButExit.BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}
