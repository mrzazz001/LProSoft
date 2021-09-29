using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
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
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FRItemsTransfDatExpir : Form
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
        private class Item
        {
            public string Name;
            public int Value;
            public Item(string name, int value)
            {
                Name = name;
                Value = value;
            }
            public override string ToString()
            {
                return Name;
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
                        frm.Repvalue = "ItemTransExpirDat";


                        frm.Repvalue = "ItemTransExpirDat";
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
        private Label label11;
        private ButtonX button_SrchItemGroup;
        private TextBox txtClassName;
        private TextBox txtClassNo;
        private Label label10;
        private ButtonX button_SrchItemNo;
        private TextBox txtItemName;
        private TextBox txtItemNo;
        private GroupBox CmbReturn;
        private RadioButton radioButton__0650Return1;
        private RadioButton radioButton__0650Return2;
        private RadioButton radioButton__0650Return0;
        private GroupBox CmbDeleted;
        private RadioButton radioButton_Del1;
        private RadioButton radioButton_Del2;
        private RadioButton radioButton_Del0;
        private Label label9;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label8;
        private ButtonX button_SrchUsrNo;
        private ButtonX button_SrchCostNo;
        private ButtonX button_SrchLegNo;
        private ButtonX button_SrchSuppNo;
        private ButtonX button_SrchCustNo;
        private TextBox txtCostNo;
        private TextBox txtUserName;
        private TextBox txtUserNo;
        private TextBox txtLegName;
        private TextBox txtLegNo;
        private TextBox txtSuppName;
        private TextBox txtSuppNo;
        private TextBox txtCustName;
        private TextBox txtCustNo;
        private TextBox txtCostName;
        private GroupBox groupBox3;
        private MaskedTextBox txtMIntoNo;
        private Label label1;
        private Label label2;
        private MaskedTextBox txtMFromNo;
        private GroupBox groupBox_Date;
        private MaskedTextBox txtMToDate;
        private MaskedTextBox txtMFromDate;
        private Label label22;
        private C1FlexGrid FlexType;
        private Label label3;
        private Label label4;
        private ComboBoxEx combobox_SortTyp;
        private ComboBoxEx CmbInvType;
        private ComboBoxEx combobox_RunNo;
        private Label label12;
        private ComboBoxEx combobox_RunDateExpir;
        private Label label14;
        private ComboBoxEx combobox_ExpirRunNo;
        private ComboBoxEx combobox_DateExpir;
        private Label label13;
        private GroupBox groupBox_ExpirDate;
        private Label label15;
        private Label label16;
        private MaskedTextBox txtMToDateExpir;
        private MaskedTextBox txtMFromDateExpir;
        private int LangArEn = 0;
        private T_User _User = new T_User();
        private List<T_INVSETTING> listInvSetting = new List<T_INVSETTING>();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRItemsTransfDatExpir));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            components = new System.ComponentModel.Container();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.ButOk = new C1.Win.C1Input.C1Button();
            this.ButExit = new C1.Win.C1Input.C1Button();
            this.label13 = new System.Windows.Forms.Label();
            this.CmbInvType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.combobox_SortTyp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label11 = new System.Windows.Forms.Label();
            this.button_SrchItemGroup = new DevComponents.DotNetBar.ButtonX();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.txtClassNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button_SrchItemNo = new DevComponents.DotNetBar.ButtonX();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtItemNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_SrchUsrNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchLegNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchSuppNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchCustNo = new DevComponents.DotNetBar.ButtonX();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtUserNo = new System.Windows.Forms.TextBox();
            this.txtLegName = new System.Windows.Forms.TextBox();
            this.txtLegNo = new System.Windows.Forms.TextBox();
            this.txtSuppName = new System.Windows.Forms.TextBox();
            this.txtSuppNo = new System.Windows.Forms.TextBox();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.txtCustNo = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtMIntoNo = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMFromNo = new System.Windows.Forms.MaskedTextBox();
            this.groupBox_Date = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMToDate = new System.Windows.Forms.MaskedTextBox();
            this.txtMFromDate = new System.Windows.Forms.MaskedTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.FlexType = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label8 = new System.Windows.Forms.Label();
            this.button_SrchCostNo = new DevComponents.DotNetBar.ButtonX();
            this.txtCostNo = new System.Windows.Forms.TextBox();
            this.txtCostName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.combobox_DateExpir = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.combobox_RunNo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label12 = new System.Windows.Forms.Label();
            this.combobox_RunDateExpir = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.combobox_ExpirRunNo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.groupBox_ExpirDate = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtMToDateExpir = new System.Windows.Forms.MaskedTextBox();
            this.txtMFromDateExpir = new System.Windows.Forms.MaskedTextBox();
            this.CmbDeleted = new System.Windows.Forms.GroupBox();
            this.radioButton_Del1 = new System.Windows.Forms.RadioButton();
            this.radioButton_Del2 = new System.Windows.Forms.RadioButton();
            this.radioButton_Del0 = new System.Windows.Forms.RadioButton();
            this.CmbReturn = new System.Windows.Forms.GroupBox();
            this.radioButton__0650Return1 = new System.Windows.Forms.RadioButton();
            this.radioButton__0650Return2 = new System.Windows.Forms.RadioButton();
            this.radioButton__0650Return0 = new System.Windows.Forms.RadioButton();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.VisibleChanged += new System.EventHandler(this.FRInvoice_VisibleChanged);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.ribbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButExit)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox_Date.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlexType)).BeginInit();
            this.groupBox_ExpirDate.SuspendLayout();
            this.CmbDeleted.SuspendLayout();
            this.CmbReturn.SuspendLayout();
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
            this.ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.ButOk);
            this.ribbonBar1.Controls.Add(this.ButExit);
            this.ribbonBar1.Controls.Add(this.label13);
            this.ribbonBar1.Controls.Add(this.CmbInvType);
            this.ribbonBar1.Controls.Add(this.label11);
            this.ribbonBar1.Controls.Add(this.button_SrchItemGroup);
            this.ribbonBar1.Controls.Add(this.txtClassName);
            this.ribbonBar1.Controls.Add(this.txtClassNo);
            this.ribbonBar1.Controls.Add(this.label10);
            this.ribbonBar1.Controls.Add(this.button_SrchItemNo);
            this.ribbonBar1.Controls.Add(this.txtItemName);
            this.ribbonBar1.Controls.Add(this.txtItemNo);
            this.ribbonBar1.Controls.Add(this.label9);
            this.ribbonBar1.Controls.Add(this.label7);
            this.ribbonBar1.Controls.Add(this.label6);
            this.ribbonBar1.Controls.Add(this.label5);
            this.ribbonBar1.Controls.Add(this.button_SrchUsrNo);
            this.ribbonBar1.Controls.Add(this.button_SrchLegNo);
            this.ribbonBar1.Controls.Add(this.button_SrchSuppNo);
            this.ribbonBar1.Controls.Add(this.button_SrchCustNo);
            this.ribbonBar1.Controls.Add(this.txtUserName);
            this.ribbonBar1.Controls.Add(this.txtUserNo);
            this.ribbonBar1.Controls.Add(this.txtLegName);
            this.ribbonBar1.Controls.Add(this.txtLegNo);
            this.ribbonBar1.Controls.Add(this.txtSuppName);
            this.ribbonBar1.Controls.Add(this.txtSuppNo);
            this.ribbonBar1.Controls.Add(this.txtCustName);
            this.ribbonBar1.Controls.Add(this.txtCustNo);
            this.ribbonBar1.Controls.Add(this.groupBox3);
            this.ribbonBar1.Controls.Add(this.groupBox_Date);
            this.ribbonBar1.Controls.Add(this.label22);
            this.ribbonBar1.Controls.Add(this.FlexType);
            this.ribbonBar1.Controls.Add(this.label8);
            this.ribbonBar1.Controls.Add(this.button_SrchCostNo);
            this.ribbonBar1.Controls.Add(this.txtCostNo);
            this.ribbonBar1.Controls.Add(this.txtCostName);
            this.ribbonBar1.Controls.Add(this.label14);
            this.ribbonBar1.Controls.Add(this.combobox_DateExpir);
            this.ribbonBar1.Controls.Add(this.combobox_RunNo);
            this.ribbonBar1.Controls.Add(this.label12);
            this.ribbonBar1.Controls.Add(this.combobox_RunDateExpir);
            this.ribbonBar1.Controls.Add(this.combobox_ExpirRunNo);
            this.ribbonBar1.Controls.Add(this.groupBox_ExpirDate);
            this.ribbonBar1.Controls.Add(this.CmbDeleted);
            this.ribbonBar1.Controls.Add(this.CmbReturn);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(569, 475);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 1105;
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
            // ButOk
            // 
            this.ButOk.BackgroundImage = global::InvAcc.Properties.Resources.print;
            this.ButOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButOk.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButOk.Location = new System.Drawing.Point(333, 419);
            this.ButOk.Name = "ButOk";
            this.ButOk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButOk.Size = new System.Drawing.Size(230, 35);
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
            this.ButExit.Location = new System.Drawing.Point(178, 419);
            this.ButExit.Name = "ButExit";
            this.ButExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButExit.Size = new System.Drawing.Size(149, 35);
            this.ButExit.TabIndex = 6747;
            this.ButExit.Text = "خروج | ESC";
            this.ButExit.UseVisualStyleBackColor = true;
            this.ButExit.Click += new System.EventHandler(this.ButExit_Click);
            this.ButExit.MouseLeave += new System.EventHandler(this.ButExit_MouseLeave);
            this.ButExit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButExit_MouseMove);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(483, 303);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 13);
            this.label13.TabIndex = 6732;
            this.label13.Text = "نـوع الفــاتورة :";
            // 
            // CmbInvType
            // 
            this.CmbInvType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbInvType.DisplayMember = "Text";
            this.CmbInvType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbInvType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbInvType.FormattingEnabled = true;
            this.CmbInvType.ItemHeight = 14;
            this.CmbInvType.Location = new System.Drawing.Point(7, 299);
            this.CmbInvType.Name = "CmbInvType";
            this.CmbInvType.Size = new System.Drawing.Size(473, 20);
            this.CmbInvType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbInvType.TabIndex = 6723;
            this.CmbInvType.SelectedIndexChanged += new System.EventHandler(this.CmbInvType_SelectedIndexChanged);
            // 
            // combobox_SortTyp
            // 
            this.combobox_SortTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combobox_SortTyp.DisplayMember = "Text";
            this.combobox_SortTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_SortTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_SortTyp.FormattingEnabled = true;
            this.combobox_SortTyp.ItemHeight = 14;
            this.combobox_SortTyp.Location = new System.Drawing.Point(6, 18);
            this.combobox_SortTyp.Name = "combobox_SortTyp";
            this.combobox_SortTyp.Size = new System.Drawing.Size(145, 20);
            this.combobox_SortTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combobox_SortTyp.TabIndex = 6722;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(483, 280);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 1143;
            this.label11.Text = "التصنيـــــــف :";
            // 
            // button_SrchItemGroup
            // 
            this.button_SrchItemGroup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchItemGroup.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchItemGroup.Location = new System.Drawing.Point(343, 277);
            this.button_SrchItemGroup.Name = "button_SrchItemGroup";
            this.button_SrchItemGroup.Size = new System.Drawing.Size(26, 20);
            this.button_SrchItemGroup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchItemGroup.Symbol = "";
            this.button_SrchItemGroup.SymbolSize = 12F;
            this.button_SrchItemGroup.TabIndex = 21;
            this.button_SrchItemGroup.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchItemGroup.Click += new System.EventHandler(this.button_SrchItemGroup_Click);
            // 
            // txtClassName
            // 
            this.txtClassName.BackColor = System.Drawing.Color.Ivory;
            this.txtClassName.ForeColor = System.Drawing.Color.White;
            this.txtClassName.Location = new System.Drawing.Point(7, 277);
            this.txtClassName.Name = "txtClassName";
            this.netResize1.SetResizeTextBoxMultiline(this.txtClassName, false);
            this.txtClassName.ReadOnly = true;
            this.txtClassName.Size = new System.Drawing.Size(335, 20);
            this.txtClassName.TabIndex = 22;
            this.txtClassName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtClassNo
            // 
            this.txtClassNo.BackColor = System.Drawing.Color.White;
            this.txtClassNo.Location = new System.Drawing.Point(372, 277);
            this.txtClassNo.Name = "txtClassNo";
            this.netResize1.SetResizeTextBoxMultiline(this.txtClassNo, false);
            this.txtClassNo.ReadOnly = true;
            this.txtClassNo.Size = new System.Drawing.Size(108, 20);
            this.txtClassNo.TabIndex = 20;
            this.txtClassNo.Tag = " T_CATEGORY.CAT_ID ";
            this.txtClassNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(483, 259);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 1142;
            this.label10.Text = "الصنــــــــــف :";
            // 
            // button_SrchItemNo
            // 
            this.button_SrchItemNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchItemNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchItemNo.Location = new System.Drawing.Point(343, 256);
            this.button_SrchItemNo.Name = "button_SrchItemNo";
            this.button_SrchItemNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchItemNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchItemNo.Symbol = "";
            this.button_SrchItemNo.SymbolSize = 12F;
            this.button_SrchItemNo.TabIndex = 18;
            this.button_SrchItemNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchItemNo.Click += new System.EventHandler(this.button_SrchItemNo_Click);
            // 
            // txtItemName
            // 
            this.txtItemName.BackColor = System.Drawing.Color.Ivory;
            this.txtItemName.ForeColor = System.Drawing.Color.White;
            this.txtItemName.Location = new System.Drawing.Point(7, 256);
            this.txtItemName.Name = "txtItemName";
            this.netResize1.SetResizeTextBoxMultiline(this.txtItemName, false);
            this.txtItemName.ReadOnly = true;
            this.txtItemName.Size = new System.Drawing.Size(335, 20);
            this.txtItemName.TabIndex = 19;
            this.txtItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtItemNo
            // 
            this.txtItemNo.BackColor = System.Drawing.Color.White;
            this.txtItemNo.Location = new System.Drawing.Point(372, 256);
            this.txtItemNo.Name = "txtItemNo";
            this.netResize1.SetResizeTextBoxMultiline(this.txtItemNo, false);
            this.txtItemNo.ReadOnly = true;
            this.txtItemNo.Size = new System.Drawing.Size(108, 20);
            this.txtItemNo.TabIndex = 17;
            this.txtItemNo.Tag = " T_Items.Itm_No ";
            this.txtItemNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(483, 238);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 1141;
            this.label9.Text = "المستخـــدم :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(483, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 1140;
            this.label7.Text = "المنـــــــدوب :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(483, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 861;
            this.label6.Text = "المــــــــــورد :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(483, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 860;
            this.label5.Text = "العميـــــــــل :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button_SrchUsrNo
            // 
            this.button_SrchUsrNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchUsrNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchUsrNo.Location = new System.Drawing.Point(343, 235);
            this.button_SrchUsrNo.Name = "button_SrchUsrNo";
            this.button_SrchUsrNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchUsrNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchUsrNo.Symbol = "";
            this.button_SrchUsrNo.SymbolSize = 12F;
            this.button_SrchUsrNo.TabIndex = 15;
            this.button_SrchUsrNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchUsrNo.Click += new System.EventHandler(this.button_SrchUsrNo_Click);
            // 
            // button_SrchLegNo
            // 
            this.button_SrchLegNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchLegNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchLegNo.Location = new System.Drawing.Point(343, 213);
            this.button_SrchLegNo.Name = "button_SrchLegNo";
            this.button_SrchLegNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchLegNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchLegNo.Symbol = "";
            this.button_SrchLegNo.SymbolSize = 12F;
            this.button_SrchLegNo.TabIndex = 12;
            this.button_SrchLegNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchLegNo.Click += new System.EventHandler(this.button_SrchLegNo_Click);
            // 
            // button_SrchSuppNo
            // 
            this.button_SrchSuppNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchSuppNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchSuppNo.Location = new System.Drawing.Point(343, 192);
            this.button_SrchSuppNo.Name = "button_SrchSuppNo";
            this.button_SrchSuppNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchSuppNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchSuppNo.Symbol = "";
            this.button_SrchSuppNo.SymbolSize = 12F;
            this.button_SrchSuppNo.TabIndex = 9;
            this.button_SrchSuppNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchSuppNo.Click += new System.EventHandler(this.button_SrchSuppNo_Click);
            // 
            // button_SrchCustNo
            // 
            this.button_SrchCustNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchCustNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCustNo.Location = new System.Drawing.Point(343, 171);
            this.button_SrchCustNo.Name = "button_SrchCustNo";
            this.button_SrchCustNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchCustNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCustNo.Symbol = "";
            this.button_SrchCustNo.SymbolSize = 12F;
            this.button_SrchCustNo.TabIndex = 6;
            this.button_SrchCustNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCustNo.Click += new System.EventHandler(this.button_SrchCustNo_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.Ivory;
            this.txtUserName.ForeColor = System.Drawing.Color.White;
            this.txtUserName.Location = new System.Drawing.Point(7, 235);
            this.txtUserName.Name = "txtUserName";
            this.netResize1.SetResizeTextBoxMultiline(this.txtUserName, false);
            this.txtUserName.ReadOnly = true;
            this.txtUserName.Size = new System.Drawing.Size(335, 20);
            this.txtUserName.TabIndex = 16;
            this.txtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUserNo
            // 
            this.txtUserNo.BackColor = System.Drawing.Color.White;
            this.txtUserNo.Location = new System.Drawing.Point(372, 235);
            this.txtUserNo.Name = "txtUserNo";
            this.netResize1.SetResizeTextBoxMultiline(this.txtUserNo, false);
            this.txtUserNo.ReadOnly = true;
            this.txtUserNo.Size = new System.Drawing.Size(108, 20);
            this.txtUserNo.TabIndex = 14;
            this.txtUserNo.Tag = " T_INVHED.SalsManNo ";
            this.txtUserNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLegName
            // 
            this.txtLegName.BackColor = System.Drawing.Color.Ivory;
            this.txtLegName.ForeColor = System.Drawing.Color.White;
            this.txtLegName.Location = new System.Drawing.Point(7, 213);
            this.txtLegName.Name = "txtLegName";
            this.netResize1.SetResizeTextBoxMultiline(this.txtLegName, false);
            this.txtLegName.ReadOnly = true;
            this.txtLegName.Size = new System.Drawing.Size(335, 20);
            this.txtLegName.TabIndex = 13;
            this.txtLegName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLegNo
            // 
            this.txtLegNo.BackColor = System.Drawing.Color.White;
            this.txtLegNo.Location = new System.Drawing.Point(372, 213);
            this.txtLegNo.Name = "txtLegNo";
            this.netResize1.SetResizeTextBoxMultiline(this.txtLegNo, false);
            this.txtLegNo.ReadOnly = true;
            this.txtLegNo.Size = new System.Drawing.Size(108, 20);
            this.txtLegNo.TabIndex = 11;
            this.txtLegNo.Tag = "T_INVHED.MndNo ";
            this.txtLegNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSuppName
            // 
            this.txtSuppName.BackColor = System.Drawing.Color.Ivory;
            this.txtSuppName.ForeColor = System.Drawing.Color.White;
            this.txtSuppName.Location = new System.Drawing.Point(7, 192);
            this.txtSuppName.Name = "txtSuppName";
            this.netResize1.SetResizeTextBoxMultiline(this.txtSuppName, false);
            this.txtSuppName.ReadOnly = true;
            this.txtSuppName.Size = new System.Drawing.Size(335, 20);
            this.txtSuppName.TabIndex = 10;
            this.txtSuppName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSuppNo
            // 
            this.txtSuppNo.BackColor = System.Drawing.Color.White;
            this.txtSuppNo.Location = new System.Drawing.Point(372, 192);
            this.txtSuppNo.Name = "txtSuppNo";
            this.netResize1.SetResizeTextBoxMultiline(this.txtSuppNo, false);
            this.txtSuppNo.ReadOnly = true;
            this.txtSuppNo.Size = new System.Drawing.Size(108, 20);
            this.txtSuppNo.TabIndex = 8;
            this.txtSuppNo.Tag = " T_INVHED.CusVenNo ";
            this.txtSuppNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCustName
            // 
            this.txtCustName.BackColor = System.Drawing.Color.Ivory;
            this.txtCustName.ForeColor = System.Drawing.Color.White;
            this.txtCustName.Location = new System.Drawing.Point(7, 171);
            this.txtCustName.Name = "txtCustName";
            this.netResize1.SetResizeTextBoxMultiline(this.txtCustName, false);
            this.txtCustName.ReadOnly = true;
            this.txtCustName.Size = new System.Drawing.Size(335, 20);
            this.txtCustName.TabIndex = 7;
            this.txtCustName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCustNo
            // 
            this.txtCustNo.BackColor = System.Drawing.Color.White;
            this.txtCustNo.Location = new System.Drawing.Point(372, 171);
            this.txtCustNo.Name = "txtCustNo";
            this.netResize1.SetResizeTextBoxMultiline(this.txtCustNo, false);
            this.txtCustNo.ReadOnly = true;
            this.txtCustNo.Size = new System.Drawing.Size(108, 20);
            this.txtCustNo.TabIndex = 5;
            this.txtCustNo.Tag = " T_INVHED.CusVenNo ";
            this.txtCustNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.txtMIntoNo);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtMFromNo);
            this.groupBox3.Location = new System.Drawing.Point(7, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(557, 39);
            this.groupBox3.TabIndex = 1136;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "حسب رقم الفاتورة";
            // 
            // txtMIntoNo
            // 
            this.txtMIntoNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMIntoNo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtMIntoNo.Location = new System.Drawing.Point(64, 13);
            this.txtMIntoNo.Name = "txtMIntoNo";
            this.txtMIntoNo.Size = new System.Drawing.Size(122, 22);
            this.txtMIntoNo.TabIndex = 2;
            this.txtMIntoNo.Tag = " T_INVHED.InvNo ";
            this.txtMIntoNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMIntoNo.Click += new System.EventHandler(this.txtMIntoNo_Click);
            this.txtMIntoNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMIntoNo_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(390, 18);
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
            this.label2.Location = new System.Drawing.Point(192, 18);
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
            this.txtMFromNo.Location = new System.Drawing.Point(262, 13);
            this.txtMFromNo.Name = "txtMFromNo";
            this.txtMFromNo.Size = new System.Drawing.Size(122, 22);
            this.txtMFromNo.TabIndex = 1;
            this.txtMFromNo.Tag = " T_INVHED.InvNo ";
            this.txtMFromNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMFromNo.Click += new System.EventHandler(this.txtMFromNo_Click);
            this.txtMFromNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMFromNo_KeyPress);
            // 
            // groupBox_Date
            // 
            this.groupBox_Date.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_Date.Controls.Add(this.label3);
            this.groupBox_Date.Controls.Add(this.label4);
            this.groupBox_Date.Controls.Add(this.txtMToDate);
            this.groupBox_Date.Controls.Add(this.txtMFromDate);
            this.groupBox_Date.Location = new System.Drawing.Point(7, 46);
            this.groupBox_Date.Name = "groupBox_Date";
            this.groupBox_Date.Size = new System.Drawing.Size(557, 39);
            this.groupBox_Date.TabIndex = 1135;
            this.groupBox_Date.TabStop = false;
            this.groupBox_Date.Text = "حسب تاريخ الفاتورة";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(390, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 1141;
            this.label3.Text = "مـــــن :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(192, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 1140;
            this.label4.Text = "إلـــــى :";
            // 
            // txtMToDate
            // 
            this.txtMToDate.Location = new System.Drawing.Point(64, 13);
            this.txtMToDate.Mask = "0000/00/00";
            this.txtMToDate.Name = "txtMToDate";
            this.txtMToDate.Size = new System.Drawing.Size(122, 20);
            this.txtMToDate.TabIndex = 4;
            this.txtMToDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMToDate.Click += new System.EventHandler(this.txtMToDate_Click);
            this.txtMToDate.Leave += new System.EventHandler(this.txtMToDate_Leave);
            // 
            // txtMFromDate
            // 
            this.txtMFromDate.Location = new System.Drawing.Point(262, 13);
            this.txtMFromDate.Mask = "0000/00/00";
            this.txtMFromDate.Name = "txtMFromDate";
            this.txtMFromDate.Size = new System.Drawing.Size(122, 20);
            this.txtMFromDate.TabIndex = 3;
            this.txtMFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMFromDate.Click += new System.EventHandler(this.txtMFromDate_Click);
            this.txtMFromDate.Leave += new System.EventHandler(this.txtMFromDate_Leave);
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(217)))), ((int)(((byte)(243)))));
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(8, 323);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(158, 23);
            this.label22.TabIndex = 1110;
            this.label22.Text = "طريقة الدفــــع";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FlexType
            // 
            this.FlexType.BackColor = System.Drawing.Color.White;
            this.FlexType.ColumnInfo = resources.GetString("FlexType.ColumnInfo");
            this.FlexType.Font = new System.Drawing.Font("Tahoma", 8F);
            this.FlexType.Location = new System.Drawing.Point(7, 347);
            this.FlexType.Name = "FlexType";
            this.FlexType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FlexType.Rows.Count = 2;
            this.FlexType.Rows.DefaultSize = 19;
            this.FlexType.Rows.Fixed = 0;
            this.FlexType.Size = new System.Drawing.Size(159, 93);
            this.FlexType.StyleInfo = resources.GetString("FlexType.StyleInfo");
            this.FlexType.TabIndex = 35;
            this.FlexType.Tag = " T_INVHED.InvCashPay ";
            this.FlexType.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(1193, 251);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 1137;
            this.label8.Text = "مركز التكلفة :";
            // 
            // button_SrchCostNo
            // 
            this.button_SrchCostNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchCostNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCostNo.Location = new System.Drawing.Point(1053, 248);
            this.button_SrchCostNo.Name = "button_SrchCostNo";
            this.button_SrchCostNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchCostNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCostNo.Symbol = "";
            this.button_SrchCostNo.SymbolSize = 12F;
            this.button_SrchCostNo.TabIndex = 24;
            this.button_SrchCostNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCostNo.Click += new System.EventHandler(this.button_SrchCostNo_Click);
            // 
            // txtCostNo
            // 
            this.txtCostNo.BackColor = System.Drawing.Color.White;
            this.txtCostNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtCostNo.Location = new System.Drawing.Point(1082, 248);
            this.txtCostNo.MaxLength = 30;
            this.txtCostNo.Name = "txtCostNo";
            this.netResize1.SetResizeTextBoxMultiline(this.txtCostNo, false);
            this.txtCostNo.ReadOnly = true;
            this.txtCostNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCostNo.Size = new System.Drawing.Size(108, 20);
            this.txtCostNo.TabIndex = 23;
            this.txtCostNo.Tag = "  T_INVHED.InvCstNo ";
            this.txtCostNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCostName
            // 
            this.txtCostName.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtCostName.ForeColor = System.Drawing.Color.White;
            this.txtCostName.Location = new System.Drawing.Point(717, 248);
            this.txtCostName.Name = "txtCostName";
            this.netResize1.SetResizeTextBoxMultiline(this.txtCostName, false);
            this.txtCostName.ReadOnly = true;
            this.txtCostName.Size = new System.Drawing.Size(335, 20);
            this.txtCostName.TabIndex = 25;
            this.txtCostName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(483, 154);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(72, 13);
            this.label14.TabIndex = 6731;
            this.label14.Text = "تاريخ صلاحية :";
            // 
            // combobox_DateExpir
            // 
            this.combobox_DateExpir.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combobox_DateExpir.DisplayMember = "Text";
            this.combobox_DateExpir.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_DateExpir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_DateExpir.FormattingEnabled = true;
            this.combobox_DateExpir.ItemHeight = 14;
            this.combobox_DateExpir.Location = new System.Drawing.Point(344, 150);
            this.combobox_DateExpir.Name = "combobox_DateExpir";
            this.combobox_DateExpir.Size = new System.Drawing.Size(136, 20);
            this.combobox_DateExpir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combobox_DateExpir.TabIndex = 6729;
            this.combobox_DateExpir.SelectedIndexChanged += new System.EventHandler(this.combobox_DateExpir_SelectedIndexChanged);
            // 
            // combobox_RunNo
            // 
            this.combobox_RunNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combobox_RunNo.DisplayMember = "Text";
            this.combobox_RunNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_RunNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_RunNo.FormattingEnabled = true;
            this.combobox_RunNo.ItemHeight = 14;
            this.combobox_RunNo.Location = new System.Drawing.Point(344, 129);
            this.combobox_RunNo.Name = "combobox_RunNo";
            this.combobox_RunNo.Size = new System.Drawing.Size(136, 20);
            this.combobox_RunNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combobox_RunNo.TabIndex = 6726;
            this.combobox_RunNo.SelectedIndexChanged += new System.EventHandler(this.combobox_RunNo_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(483, 133);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 13);
            this.label12.TabIndex = 6728;
            this.label12.Text = "رقـم التصنيـع :";
            // 
            // combobox_RunDateExpir
            // 
            this.combobox_RunDateExpir.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combobox_RunDateExpir.DisplayMember = "Text";
            this.combobox_RunDateExpir.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_RunDateExpir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_RunDateExpir.Enabled = false;
            this.combobox_RunDateExpir.FormattingEnabled = true;
            this.combobox_RunDateExpir.ItemHeight = 14;
            this.combobox_RunDateExpir.Location = new System.Drawing.Point(8, 129);
            this.combobox_RunDateExpir.Name = "combobox_RunDateExpir";
            this.combobox_RunDateExpir.Size = new System.Drawing.Size(334, 20);
            this.combobox_RunDateExpir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combobox_RunDateExpir.TabIndex = 6727;
            // 
            // combobox_ExpirRunNo
            // 
            this.combobox_ExpirRunNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combobox_ExpirRunNo.DisplayMember = "Text";
            this.combobox_ExpirRunNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_ExpirRunNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_ExpirRunNo.Enabled = false;
            this.combobox_ExpirRunNo.FormattingEnabled = true;
            this.combobox_ExpirRunNo.ItemHeight = 14;
            this.combobox_ExpirRunNo.Location = new System.Drawing.Point(8, 150);
            this.combobox_ExpirRunNo.Name = "combobox_ExpirRunNo";
            this.combobox_ExpirRunNo.Size = new System.Drawing.Size(334, 20);
            this.combobox_ExpirRunNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combobox_ExpirRunNo.TabIndex = 6730;
            // 
            // groupBox_ExpirDate
            // 
            this.groupBox_ExpirDate.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_ExpirDate.Controls.Add(this.label15);
            this.groupBox_ExpirDate.Controls.Add(this.label16);
            this.groupBox_ExpirDate.Controls.Add(this.txtMToDateExpir);
            this.groupBox_ExpirDate.Controls.Add(this.txtMFromDateExpir);
            this.groupBox_ExpirDate.Location = new System.Drawing.Point(6, 85);
            this.groupBox_ExpirDate.Name = "groupBox_ExpirDate";
            this.groupBox_ExpirDate.Size = new System.Drawing.Size(557, 39);
            this.groupBox_ExpirDate.TabIndex = 6733;
            this.groupBox_ExpirDate.TabStop = false;
            this.groupBox_ExpirDate.Text = "حسب تاريخ الصلاحية ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(390, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 13);
            this.label15.TabIndex = 1141;
            this.label15.Text = "مـــــن :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(192, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 13);
            this.label16.TabIndex = 1140;
            this.label16.Text = "إلـــــى :";
            // 
            // txtMToDateExpir
            // 
            this.txtMToDateExpir.Location = new System.Drawing.Point(64, 13);
            this.txtMToDateExpir.Mask = "0000/00/00";
            this.txtMToDateExpir.Name = "txtMToDateExpir";
            this.txtMToDateExpir.Size = new System.Drawing.Size(122, 20);
            this.txtMToDateExpir.TabIndex = 4;
            this.txtMToDateExpir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMToDateExpir.Click += new System.EventHandler(this.txtMToDateExpir_Click);
            this.txtMToDateExpir.Leave += new System.EventHandler(this.txtMToDateExpir_Leave);
            // 
            // txtMFromDateExpir
            // 
            this.txtMFromDateExpir.Location = new System.Drawing.Point(262, 13);
            this.txtMFromDateExpir.Mask = "0000/00/00";
            this.txtMFromDateExpir.Name = "txtMFromDateExpir";
            this.txtMFromDateExpir.Size = new System.Drawing.Size(122, 20);
            this.txtMFromDateExpir.TabIndex = 3;
            this.txtMFromDateExpir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMFromDateExpir.Click += new System.EventHandler(this.txtMFromDateExpir_Click);
            this.txtMFromDateExpir.Leave += new System.EventHandler(this.txtMFromDateExpir_Leave);
            // 
            // CmbDeleted
            // 
            this.CmbDeleted.BackColor = System.Drawing.Color.Transparent;
            this.CmbDeleted.Controls.Add(this.radioButton_Del1);
            this.CmbDeleted.Controls.Add(this.radioButton_Del2);
            this.CmbDeleted.Controls.Add(this.radioButton_Del0);
            this.CmbDeleted.Location = new System.Drawing.Point(172, 317);
            this.CmbDeleted.Name = "CmbDeleted";
            this.CmbDeleted.Size = new System.Drawing.Size(391, 44);
            this.CmbDeleted.TabIndex = 1122;
            this.CmbDeleted.TabStop = false;
            this.CmbDeleted.Tag = " T_INVHED.IfDel ";
            this.CmbDeleted.Enter += new System.EventHandler(this.CmbDeleted_Enter);
            // 
            // radioButton_Del1
            // 
            this.radioButton_Del1.AutoSize = true;
            this.radioButton_Del1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Del1.Location = new System.Drawing.Point(-152, 23);
            this.radioButton_Del1.Name = "radioButton_Del1";
            this.radioButton_Del1.Size = new System.Drawing.Size(54, 17);
            this.radioButton_Del1.TabIndex = 28;
            this.radioButton_Del1.Text = "الكـــل";
            this.radioButton_Del1.UseVisualStyleBackColor = true;
            this.radioButton_Del1.Visible = false;
            // 
            // radioButton_Del2
            // 
            this.radioButton_Del2.AutoSize = true;
            this.radioButton_Del2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Del2.Location = new System.Drawing.Point(129, 18);
            this.radioButton_Del2.Name = "radioButton_Del2";
            this.radioButton_Del2.Size = new System.Drawing.Size(89, 17);
            this.radioButton_Del2.TabIndex = 27;
            this.radioButton_Del2.Text = "المحذوفة فقط";
            this.radioButton_Del2.UseVisualStyleBackColor = true;
            // 
            // radioButton_Del0
            // 
            this.radioButton_Del0.AutoSize = true;
            this.radioButton_Del0.Checked = true;
            this.radioButton_Del0.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton_Del0.Location = new System.Drawing.Point(269, 18);
            this.radioButton_Del0.Name = "radioButton_Del0";
            this.radioButton_Del0.Size = new System.Drawing.Size(84, 17);
            this.radioButton_Del0.TabIndex = 26;
            this.radioButton_Del0.TabStop = true;
            this.radioButton_Del0.Text = "الغير محذوفة";
            this.radioButton_Del0.UseVisualStyleBackColor = true;
            // 
            // CmbReturn
            // 
            this.CmbReturn.BackColor = System.Drawing.Color.Transparent;
            this.CmbReturn.Controls.Add(this.radioButton__0650Return1);
            this.CmbReturn.Controls.Add(this.radioButton__0650Return2);
            this.CmbReturn.Controls.Add(this.radioButton__0650Return0);
            this.CmbReturn.Controls.Add(this.combobox_SortTyp);
            this.CmbReturn.Location = new System.Drawing.Point(172, 366);
            this.CmbReturn.Name = "CmbReturn";
            this.CmbReturn.Size = new System.Drawing.Size(391, 44);
            this.CmbReturn.TabIndex = 1123;
            this.CmbReturn.TabStop = false;
            this.CmbReturn.Tag = " T_INVHED.IfRet ";
            // 
            // radioButton__0650Return1
            // 
            this.radioButton__0650Return1.AutoSize = true;
            this.radioButton__0650Return1.Checked = true;
            this.radioButton__0650Return1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton__0650Return1.Location = new System.Drawing.Point(147, 18);
            this.radioButton__0650Return1.Name = "radioButton__0650Return1";
            this.radioButton__0650Return1.Size = new System.Drawing.Size(54, 17);
            this.radioButton__0650Return1.TabIndex = 31;
            this.radioButton__0650Return1.TabStop = true;
            this.radioButton__0650Return1.Text = "الكـــل";
            this.radioButton__0650Return1.UseVisualStyleBackColor = true;
            // 
            // radioButton__0650Return2
            // 
            this.radioButton__0650Return2.AutoSize = true;
            this.radioButton__0650Return2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton__0650Return2.Location = new System.Drawing.Point(207, 18);
            this.radioButton__0650Return2.Name = "radioButton__0650Return2";
            this.radioButton__0650Return2.Size = new System.Drawing.Size(87, 17);
            this.radioButton__0650Return2.TabIndex = 30;
            this.radioButton__0650Return2.Text = "المرتجعة فقط";
            this.radioButton__0650Return2.UseVisualStyleBackColor = true;
            this.radioButton__0650Return2.CheckedChanged += new System.EventHandler(this.radioButton__0650Return2_CheckedChanged);
            // 
            // radioButton__0650Return0
            // 
            this.radioButton__0650Return0.AutoSize = true;
            this.radioButton__0650Return0.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton__0650Return0.Location = new System.Drawing.Point(294, 18);
            this.radioButton__0650Return0.Name = "radioButton__0650Return0";
            this.radioButton__0650Return0.Size = new System.Drawing.Size(82, 17);
            this.radioButton__0650Return0.TabIndex = 29;
            this.radioButton__0650Return0.Text = "الغير مرتجعة";
            this.radioButton__0650Return0.UseVisualStyleBackColor = true;
            // 
            // FRItemsTransfDatExpir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 475);
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FRItemsTransfDatExpir";
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FRItemsTransfDatExpir_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.ribbonBar1.ResumeLayout(false);
            this.ribbonBar1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButExit)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox_Date.ResumeLayout(false);
            this.groupBox_Date.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlexType)).EndInit();
            this.groupBox_ExpirDate.ResumeLayout(false);
            this.groupBox_ExpirDate.PerformLayout();
            this.CmbDeleted.ResumeLayout(false);
            this.CmbDeleted.PerformLayout();
            this.CmbReturn.ResumeLayout(false);
            this.CmbReturn.PerformLayout();
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
        public FRItemsTransfDatExpir()
        {
            InitializeComponent();
            _User = dbc.StockUser(VarGeneral.UserNumber);
            if (VarGeneral.SSSLev == "B" || VarGeneral.SSSLev == "F" || VarGeneral.SSSLev == "S" || VarGeneral.SSSLev == "C")
            {
                label8.Visible = false;
                txtCostNo.Visible = false;
                button_SrchCostNo.Visible = false;
                txtCostName.Visible = false;
            }
            else
            {
                label8.Visible = true;
                txtCostNo.Visible = true;
                button_SrchCostNo.Visible = true;
                txtCostName.Visible = true;
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
                        txtCostNo.Visible = true;
                        button_SrchCostNo.Visible = true;
                        txtCostName.Visible = true;
                    }
                    else
                    {
                        label8.Visible = false;
                        txtCostNo.Visible = false;
                        button_SrchCostNo.Visible = false;
                        txtCostName.Visible = false;
                    }
                }
            }
            catch
            {
            }
            listInvSetting = (from er in db.T_INVSETTINGs
                              where er.InvID == 1 || er.InvID == 2 || er.InvID == 3 || er.InvID == 4 || er.InvID == 5 || er.InvID == 6 || er.InvID == 7 || er.InvID == 8 || er.InvID == 9 || er.InvID == 10 || er.InvID == 14 || er.InvID == 17 || er.InvID == 20
                              orderby er.InvID
                              select er).ToList();
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptWaterPackages.dll"))
            {
                listInvSetting = db.T_INVSETTINGs.Where((T_INVSETTING t) => t.InvID == 1 || t.InvID == 2 || t.InvID == 3 || t.InvID == 4 || t.InvID == 5 || t.InvID == 6 || t.InvID == 7 || t.InvID == 8 || t.InvID == 9 || t.InvID == 10 || t.InvID == 14).ToList();
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRItemsTransfDatExpir));
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
            RibunButtons();
            FillCombo();
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptMaintenanceCars.dll"))
            {
                label7.Text = ((LangArEn == 0) ? "نوع السيارة :" : "Car Type :");
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptBus.dll"))
            {
                label7.Text = ((LangArEn == 0) ? "السائق :" : "Driver :");
            }
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRItemsTransfDatExpir));
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
            RibunButtons();
            FillCombo();
        }
        private void FillFlex()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                this.FlexType.Rows.Count = 3;
                this.FlexType.SetData(0, 0, true);
                this.FlexType.SetData(0, 1, "نقدي");
                this.FlexType.SetData(1, 0, true);
                this.FlexType.SetData(1, 1, "آجل");
                this.FlexType.SetData(2, 0, true);
                this.FlexType.SetData(2, 1, "الشبكة");
                if (VarGeneral.InvType == 1)
                {
                    Text = "تقرير حركة صنف في فاتورة مبيعات";
                }
                else if (VarGeneral.InvType == 2)
                {
                    Text = "تقرير حركة صنف في فاتورة فاتورة مشتريات";
                }
                else if (VarGeneral.InvType == 3)
                {
                    Text = "تقرير حركة صنف في مرتجع مبيعات";
                }
                else if (VarGeneral.InvType == 4)
                {
                    Text = "تقرير حركة صنف في فاتورة مرتجع مشتريات";
                }
                else if (VarGeneral.InvType == 5)
                {
                    Text = "تقرير حركة صنف في فاتورة إدخال بضاعة";
                    FlexType.Rows.Count = 1;
                    FlexType.SetData(0, 0, true);
                    FlexType.SetData(0, 1, "سند");
                }
                else if (VarGeneral.InvType == 6)
                {
                    Text = "تقرير حركة صنف في فاتورة إخراج بضاعة";
                    FlexType.Rows.Count = 1;
                    FlexType.SetData(0, 0, true);
                    FlexType.SetData(0, 1, "سند");
                }
                else if (VarGeneral.InvType == 7)
                {
                    Text = "تقرير حركة صنف في فاتورة عرض سعر للعملاء";
                }
                else if (VarGeneral.InvType == 8)
                {
                    Text = "تقرير حركة صنف في فاتورة عرض سعر للموردين";
                }
                else if (VarGeneral.InvType == 9)
                {
                    Text = "تقرير حركة صنف في فاتورة طلب شراء";
                }
                else if (VarGeneral.InvType == 10)
                {
                    Text = "تقرير حركة صنف في فاتورة تسوية البضاعة";
                    FlexType.Rows.Count = 1;
                    FlexType.SetData(0, 0, true);
                    FlexType.SetData(0, 1, "سند");
                }
                else if (VarGeneral.InvType == 14)
                {
                    Text = "تقرير حركة صنف في فاتورة بضاعة اول المدة";
                    FlexType.Rows.Count = 1;
                    FlexType.SetData(0, 0, true);
                    FlexType.SetData(0, 1, "سند");
                }
                else if (VarGeneral.InvType == 17)
                {
                    Text = "تقرير حركة صنف في فاتورة صرف بضاعة";
                    FlexType.Rows.Count = 1;
                    FlexType.SetData(0, 0, true);
                    FlexType.SetData(0, 1, "سند");
                }
                else if (VarGeneral.InvType == 20)
                {
                    Text = "تقرير حركة صنف في فاتورة مرتجع صرف بضاعة";
                    FlexType.Rows.Count = 1;
                    FlexType.SetData(0, 0, true);
                    FlexType.SetData(0, 1, "سند");
                }
            }
            else
            {
                FlexType.Rows.Count = 2;
                FlexType.SetData(0, 0, true);
                FlexType.SetData(0, 1, "Cash");
                FlexType.SetData(1, 0, true);
                FlexType.SetData(1, 1, "Credit");
                FlexType.SetData(2, 0, true);
                FlexType.SetData(2, 1, "Network");
                if (VarGeneral.InvType == 1)
                {
                    Text = "Sales Invoice Report";
                }
                else if (VarGeneral.InvType == 2)
                {
                    Text = "Purchase Invoice Report";
                }
                else if (VarGeneral.InvType == 3)
                {
                    Text = "Sales Return Report";
                }
                else if (VarGeneral.InvType == 4)
                {
                    Text = "Purchase Return Report";
                }
                else if (VarGeneral.InvType == 5)
                {
                    Text = "Transfer In Report";
                    FlexType.Rows.Count = 1;
                    FlexType.SetData(0, 0, true);
                    FlexType.SetData(0, 1, "Receipt");
                }
                else if (VarGeneral.InvType == 6)
                {
                    Text = "Transfer Out Report";
                    FlexType.Rows.Count = 1;
                    FlexType.SetData(0, 0, true);
                    FlexType.SetData(0, 1, "Receipt");
                }
                else if (VarGeneral.InvType == 7)
                {
                    Text = "Customer Qutation Report";
                }
                else if (VarGeneral.InvType == 8)
                {
                    Text = "Supplier Qutation Report";
                }
                else if (VarGeneral.InvType == 9)
                {
                    Text = "Purchase Order Report";
                }
                else if (VarGeneral.InvType == 10)
                {
                    Text = "Stock Adjustment Report";
                    FlexType.Rows.Count = 1;
                    FlexType.SetData(0, 0, true);
                    FlexType.SetData(0, 1, "Receipt");
                }
                else if (VarGeneral.InvType == 14)
                {
                    Text = "Open Quantities Report";
                    FlexType.Rows.Count = 1;
                    FlexType.SetData(0, 0, true);
                    FlexType.SetData(0, 1, "Receipt");
                }
                else if (VarGeneral.InvType == 17)
                {
                    Text = "Payment Order Report";
                    FlexType.Rows.Count = 1;
                    FlexType.SetData(0, 0, true);
                    FlexType.SetData(0, 1, "Receipt");
                }
                else if (VarGeneral.InvType == 20)
                {
                    Text = "Payment Order Return Report";
                    FlexType.Rows.Count = 1;
                    FlexType.SetData(0, 0, true);
                    FlexType.SetData(0, 1, "Receipt");
                }
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptSchool.dll"))
            {
                label5.Text = ((LangArEn == 0) ? "الطـالـب :" : "Student Acc :");
                if (VarGeneral.InvType == 7)
                {
                    Text = ((LangArEn == 0) ? "تقرير حركة صنف في فاتورة عرض سعر للطلاب" : "Students Qutation Report");
                }
            }
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptWaterPackages.dll"))
            {
                label5.Text = ((LangArEn == 0) ? "الســــــائــق :" : "Driver Acc :");
                label7.Text = ((LangArEn == 0) ? "العميــــــــل :" : "Customer :");
                label8.Text = ((LangArEn == 0) ? "السيــارة :" : "Car :");
                if (VarGeneral.InvType == 7)
                {
                    Text = ((LangArEn == 0) ? "تقرير فواتير عرض سعر السائقين" : "Drivers Qutation Reports");
                }
            }
            if (VarGeneral.gUserName == "runsetting" && File.Exists(Application.StartupPath + "\\Script\\" + VarGeneral.gServerName.Replace(Environment.MachineName + "\\", "").Trim() + "\\khalijwatania.dll") && VarGeneral.InvType == 1)
            {
                Text = ((LangArEn == 0) ? "تقرير حركة صنف في فاتورة الخدمة" : "Service Invoice Report");
            }
        }
        private string BuildRuleList()
        {
            HijriGregDates dateFormatter = new HijriGregDates();
            string Rule = "Where (T_INVDET.DatExper <> '' or T_INVDET.RunCod <> '') and T_INVHED.InvTyp = " + VarGeneral.InvType;
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
            if (!string.IsNullOrEmpty(txtCostNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtCostNo.Tag, " = ", txtCostNo.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtCustNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtCustNo.Tag, " = '", txtCustNo.Text.Trim(), "'");
            }
            if (!string.IsNullOrEmpty(txtSuppNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtSuppNo.Tag, " = '", txtSuppNo.Text.Trim(), "'");
            }
            if (!string.IsNullOrEmpty(txtLegNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtLegNo.Tag, " = ", txtLegNo.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtUserNo.Text))
            {
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptInv.dll") && VarGeneral.InvType == 1)
                {
                    Rule = Rule + " and  T_INVHED.UserNew  = '" + txtUserNo.Text.Trim() + "'";
                }
                else
                {
                    object obj = Rule;
                    Rule = string.Concat(obj, " and ", txtUserNo.Tag, " = '", txtUserNo.Text.Trim(), "'");
                }
            }
            if (!string.IsNullOrEmpty(txtItemNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtItemNo.Tag, " = '", txtItemNo.Text.Trim(), "'");
            }
            if (!string.IsNullOrEmpty(txtClassNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtClassNo.Tag, " = ", txtClassNo.Text.Trim());
            }
            if (VarGeneral.CheckDate(txtMFromDate.Text) && txtMFromDate.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMFromDate.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_INVHED.GDat  >= '" + dateFormatter.FormatGreg(txtMFromDate.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_INVHED.HDat  >= '" + dateFormatter.FormatHijri(txtMFromDate.Text, "yyyy/MM/dd") + "'"));
            }
            if (VarGeneral.CheckDate(txtMToDate.Text) && txtMToDate.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMToDate.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_INVHED.GDat  <= '" + dateFormatter.FormatGreg(txtMToDate.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_INVHED.HDat  <= '" + dateFormatter.FormatHijri(txtMToDate.Text, "yyyy/MM/dd") + "'"));
            }
            if (VarGeneral.CheckDate(txtMFromDateExpir.Text) && txtMFromDateExpir.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMFromDateExpir.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_INVDET.DatExper  >= '" + dateFormatter.FormatGreg(txtMFromDateExpir.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_INVDET.DatExper  >= '" + dateFormatter.FormatHijri(txtMFromDateExpir.Text, "yyyy/MM/dd") + "'"));
            }
            if (VarGeneral.CheckDate(txtMToDateExpir.Text) && txtMToDateExpir.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMToDateExpir.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_INVDET.DatExper  <= '" + dateFormatter.FormatGreg(txtMToDateExpir.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_INVDET.DatExper  <= '" + dateFormatter.FormatHijri(txtMToDateExpir.Text, "yyyy/MM/dd") + "'"));
            }
            if (radioButton_Del0.Checked)
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", CmbDeleted.Tag, " != 1 ");
            }
            else if (radioButton_Del2.Checked)
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", CmbDeleted.Tag, " = 1 ");
            }
            if (radioButton__0650Return0.Checked)
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", CmbReturn.Tag, " != 1 ");
            }
            else if (radioButton__0650Return2.Checked)
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", CmbReturn.Tag, " = 1 ");
            }
            if (combobox_RunNo.SelectedIndex > 0)
            {
                if (combobox_RunDateExpir.SelectedIndex > 0)
                {
                    string text = Rule;
                    Rule = text + " and (T_QTYEXP.RunCod = '" + combobox_RunNo.Text + "' and T_QTYEXP.DatExper = '" + combobox_RunDateExpir.Text + "')";
                }
                else
                {
                    Rule = Rule + " and T_QTYEXP.RunCod = '" + combobox_RunNo.Text + "'";
                }
            }
            if (combobox_DateExpir.SelectedIndex > 0)
            {
                if (combobox_ExpirRunNo.SelectedIndex > 0)
                {
                    string text = Rule;
                    Rule = text + " and (T_QTYEXP.DatExper = '" + combobox_DateExpir.Text + "' and T_QTYEXP.RunCod = '" + combobox_ExpirRunNo.Text + "')";
                }
                else
                {
                    Rule = Rule + " and T_QTYEXP.DatExper = '" + combobox_DateExpir.Text + "'";
                }
            }
            int iiCnt = 0;
            string RuleInvType = ""; int rc = FlexType.Rows.Count; if (rc == 3) rc--;
            for (iiCnt = 0; iiCnt < rc; iiCnt++)
            {
                if ((bool)this.FlexType.GetData(iiCnt, 0))
                {
                    if (!string.IsNullOrEmpty(RuleInvType))
                    {
                        RuleInvType = string.Concat(RuleInvType, " or ");
                    }
                    object obj = RuleInvType;
                    object[] tag = new object[] { obj, this.FlexType.Tag, "  = ", iiCnt };
                    RuleInvType = string.Concat(tag);
                }
            }
            if (FlexType.Rows.Count == 3)
                if ((bool)this.FlexType.GetData(2, 0))
                {
                    object obj;// = //RuleInvType;
                    object[] tag;// = new object[] { obj, " or T_INVHED.InvCash = 'الشبكة' or T_INVHED.InvCash = 'شبكـــة' " };
                    if (string.IsNullOrEmpty(RuleInvType))
                    {
                        obj = RuleInvType;
                        tag = new object[] { obj, this.FlexType.Tag, "  = ", iiCnt };
                        RuleInvType = string.Concat(tag);
                    }
                    obj = RuleInvType;
                    tag = new object[] { obj, " or T_INVHED.InvCash = 'الشبكة' or T_INVHED.InvCash = 'شبكـــة' " };
                    RuleInvType = string.Concat(tag);
                }
            if (!string.IsNullOrEmpty(RuleInvType))
            {
                Rule = Rule + " and (" + RuleInvType + ")";
            }
            return Rule;
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (Text == "تقرير حركة صنف في فاتورة مبيعات" || Text == "Sales Invoice Report")
                {
                    VarGeneral.InvType = 1;
                }
                else if (Text == "تقرير حركة صنف في فاتورة فاتورة مشتريات" || Text == "Purchase Invoice Report")
                {
                    VarGeneral.InvType = 2;
                }
                else if (Text == "تقرير حركة صنف في مرتجع مبيعات" || Text == "Sales Return Report")
                {
                    VarGeneral.InvType = 3;
                }
                else if (Text == "تقرير حركة صنف في فاتورة مرتجع مشتريات" || Text == "Purchase Return Report")
                {
                    VarGeneral.InvType = 4;
                }
                else if (Text == "تقرير حركة صنف في فاتورة إدخال بضاعة" || Text == "Transfer In Report")
                {
                    VarGeneral.InvType = 5;
                }
                else if (Text == "تقرير حركة صنف في فاتورة إخراج بضاعة" || Text == "Transfer Out Report")
                {
                    VarGeneral.InvType = 6;
                }
                else if (Text == "تقرير حركة صنف في فاتورة عرض سعر للعملاء" || Text == "Customer Qutation Report")
                {
                    VarGeneral.InvType = 7;
                }
                else if (Text == "تقرير حركة صنف في فاتورة عرض سعر للموردين" || Text == "Supplier Qutation Report")
                {
                    VarGeneral.InvType = 8;
                }
                else if (Text == "تقرير حركة صنف في فاتورة طلب شراء" || Text == "Purchase Order Report")
                {
                    VarGeneral.InvType = 9;
                }
                else if (Text == "تقرير حركة صنف في فاتورة تسوية البضاعة" || Text == "Stock Adjustment Report")
                {
                    VarGeneral.InvType = 10;
                }
                else if (Text == "تقرير حركة صنف في فاتورة بضاعة اول المدة" || Text == "Open Quantities Report")
                {
                    VarGeneral.InvType = 14;
                }
                else if (Text == "تقرير حركة صنف في فاتورة صرف بضاعة" || Text == "Payment Order Report")
                {
                    VarGeneral.InvType = 17;
                }
                else if (Text == "تقرير حركة صنف في فاتورة مرتجع صرف بضاعة" || Text == "Payment Order Return Report")
                {
                    VarGeneral.InvType = 20;
                }
                if (Text == "تقرير حركة صنف في فاتورة عرض سعر للطلاب" || Text == "Students Qutation Report")
                {
                    VarGeneral.InvType = 7;
                }
                if (Text == "تقرير فواتير عرض سعر السائقين" || Text == "Drivers Qutation Reports")
                {
                    VarGeneral.InvType = 7;
                }
                if (Text == "تقرير حركة صنف في فاتورة الخدمة" || Text == "Service Invoice Report")
                {
                    VarGeneral.InvType = 1;
                }
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = "T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_QTYEXP On (T_INVDET.RunCod = T_QTYEXP.RunCod and T_INVDET.DatExper = T_QTYEXP.DatExper) LEFT OUTER JOIN T_SYSSETTING ON T_Items.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                string Fields = "";
                Fields = ((LangArEn != 0) ? (" InvDet_ID,T_Items.Itm_No,T_Items.Eng_Des as itemNm,T_Category.Eng_Des as CategoyNm,T_InvDet.StoreNo,T_InvDet.ItmUntE as UnitNm,T_InvDet.ItmUntPak,(Round(T_InvDet.Price," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Price,T_InvDet.ItmDis,Abs(T_InvDet.Qty) as Qty,(Round(T_InvDet.Amount," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Amount,T_INVHED.InvNo, T_INVSETTING.InvNamE as InvTypNm,T_INVHED.InvCash,T_Curency.Eng_Des as CurrnceyNm,T_INVHED.GadeNo,T_INVHED.CusVenNo,T_INVHED.CusVenNm,T_INVHED.GDat,T_INVHED.HDat,T_CstTbl.Eng_Des as CostCenteNm, T_Mndob.Eng_Des as MndNm,T_INVHED.RetNo,T_SYSSETTING.LogImg ,(Round(T_InvDet.Amount - (T_InvDet.Cost * ABS(RealQty))," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Profit,T_InvDet.Cost as Cost,T_QTYEXP.DatExper,T_QTYEXP.RunCod,T_QTYEXP.stkQty") : (" InvDet_ID,T_Items.Itm_No,T_Items.Arb_Des as itemNm,T_Category.Arb_Des as CategoyNm,T_InvDet.StoreNo,T_InvDet.ItmUnt as UnitNm,T_InvDet.ItmUntPak,(Round(T_InvDet.Price," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Price,T_InvDet.ItmDis,Abs(T_InvDet.Qty) as Qty,(Round(T_InvDet.Amount," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Amount,T_INVHED.InvNo, T_INVSETTING.InvNamA as InvTypNm,T_INVHED.InvCash,T_Curency.Arb_Des as CurrnceyNm,T_INVHED.GadeNo,T_INVHED.CusVenNo,T_INVHED.CusVenNm,T_INVHED.GDat,T_INVHED.HDat,T_CstTbl.Arb_Des as CostCenteNm, T_Mndob.Arb_Des as MndNm,T_INVHED.RetNo,T_SYSSETTING.LogImg,(Round(T_InvDet.Amount - (T_InvDet.Cost * ABS(RealQty))," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Profit,T_InvDet.Cost as Cost,T_QTYEXP.DatExper,T_QTYEXP.RunCod,T_QTYEXP.stkQty"));
                _RepShow.Rule = BuildRuleList() + ((combobox_SortTyp.SelectedIndex == 0) ? " order by T_INVHED.InvHed_ID " : " order by T_INVHED.GDat ");
                _RepShow.Fields = Fields;
                try
                {
                    _RepShow = _RepShow.Save();
                    VarGeneral.RepData = _RepShow.RepData;
                    try
                    {
                        if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 15))
                        {
                            _RepShow = new RepShow();
                            _RepShow.Rule = "";
                            _RepShow.Tables = "T_SINVDET LEFT OUTER JOIN T_INVHED ON T_SINVDET.SInvIdHEAD = T_INVHED.InvHed_ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_SINVDET.SItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                            {
                                _RepShow.Fields = " SInvId as InvDet_ID,T_Items.Itm_No,T_Items.Arb_Des as itemNm,T_Category.Arb_Des as CategoyNm,T_SINVDET.SStoreNo as StoreNo,T_SINVDET.SItmUnt as UnitNm,T_SINVDET.SItmUntPak as ItmUntPak,(Round(T_SINVDET.SPrice," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Price,T_SINVDET.SItmDis as ItmDis,Abs(T_SINVDET.SQty) as Qty,(Round(T_SINVDET.SAmount," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Amount,T_INVHED.InvNo, T_INVSETTING.InvNamA as InvTypNm,T_INVHED.InvCash,T_Curency.Arb_Des as CurrnceyNm,T_INVHED.GadeNo,T_INVHED.CusVenNo,T_INVHED.CusVenNm,T_INVHED.GDat,T_INVHED.HDat,T_CstTbl.Arb_Des as CostCenteNm, T_Mndob.Arb_Des as MndNm,T_INVHED.RetNo,T_SYSSETTING.LogImg,(Round(T_SINVDET.SAmount - (T_SINVDET.SCost * Abs(T_SINVDET.SRealQty))," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Profit ,T_SINVDET.SCost as SCost";
                            }
                            else
                            {
                                _RepShow.Fields = " SInvId as InvDet_ID,T_Items.Itm_No,T_Items.Eng_Des as itemNm,T_Category.Eng_Des as CategoyNm,T_SINVDET.SStoreNo as StoreNo,T_SINVDET.SItmUntE as UnitNm,T_SINVDET.SItmUntPak as ItmUntPak,(Round(T_SINVDET.SPrice," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Price,T_SINVDET.SItmDis as ItmDis,Abs(T_SINVDET.SQty) as Qty,(Round(T_SINVDET.SAmount," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Amount,T_INVHED.InvNo, T_INVSETTING.InvNamE as InvTypNm,T_INVHED.InvCash,T_Curency.Eng_Des as CurrnceyNm,T_INVHED.GadeNo,T_INVHED.CusVenNo,T_INVHED.CusVenNm,T_INVHED.GDat,T_INVHED.HDat,T_CstTbl.Eng_Des as CostCenteNm, T_Mndob.Eng_Des as MndNm,T_INVHED.RetNo,T_SYSSETTING.LogImg ,(Round(T_SINVDET.SAmount - (T_SINVDET.SCost * Abs(T_SINVDET.SRealQty))," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) as Profit,T_SINVDET.SCost as SCost";
                            }
                            _RepShow.Rule = BuildRuleList();
                            _RepShow = _RepShow.Save();
                            VarGeneral.RepData.Tables[0].Merge(_RepShow.RepData.Tables[0]);
                        }
                    }
                    catch
                    {
                    }
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
                    VarGeneral.IsGeneralUsed = true;
                    FrmReportsViewer frm = new FrmReportsViewer();
                    frm.Repvalue = "ItemTransExpirDat";



                    frm.Tag = LangArEn;
                    frm.Repvalue = "ItemTransExpirDat";
                    VarGeneral.vTitle = Text;
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
                ButExit.Text = "خــــروج Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "طبـــاعة F5" : "عــــرض F5");
                groupBox3.Text = "حسب رقم الفاتورة";
                groupBox_Date.Text = "حسب تاريخ الفاتورة";
                groupBox_ExpirDate.Text = "حسب تاريخ الصلاحية";
                label1.Text = "مـــــن :";
                label2.Text = "إلـــــى :";
                label3.Text = "مـــــن :";
                label4.Text = "إلـــــى :";
                label5.Text = "العميـــــــــل :";
                label6.Text = "المــــــــــورد :";
                label7.Text = "المنـــــــدوب :";
                label8.Text = "مركز التكلفة :";
                label9.Text = "المستخـــدم :";
                label10.Text = "الصنــــــــــف :";
                label11.Text = "التصنيـــــــف :";
                label22.Text = "طريقة الدفع";
                radioButton_Del0.Text = "الغير محذوفة";
                radioButton_Del1.Text = "الكـــل";
                radioButton_Del2.Text = "المحذوفة فقط";
                radioButton__0650Return0.Text = "الغير مرتجعة";
                radioButton__0650Return1.Text = "الكـــل";
                radioButton__0650Return2.Text = "المرتجعة فقط";
            }
            else
            {
                ButExit.Text = "Exit Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "Print F5" : "Show F5");
                groupBox3.Text = "Invoice No";
                groupBox_Date.Text = "Invoice Date";
                groupBox_ExpirDate.Text = "Expir Date";
                label1.Text = "From :";
                label2.Text = "To :";
                label3.Text = "From :";
                label4.Text = "To :";
                label5.Text = "Customer :";
                label6.Text = "Supplier :";
                label7.Text = "Delegate :";
                label8.Text = "Cost Center :";
                label9.Text = "User :";
                label10.Text = "Item :";
                label11.Text = "Category :";
                label22.Text = "Payment method";
                radioButton_Del0.Text = "Non-Deleted";
                radioButton_Del1.Text = "ALL";
                radioButton_Del2.Text = "Deleted Only";
                radioButton__0650Return0.Text = "Non-Return";
                radioButton__0650Return1.Text = "ALL";
                radioButton__0650Return2.Text = "Return Only";
            }
        }
        private void FRItemsTransfDatExpir_Load(object sender, EventArgs e)
        {
        }
        public void FillCombo()
        {
            combobox_SortTyp.Items.Clear();
            combobox_SortTyp.Items.Add((LangArEn == 0) ? "رقم الفاتورة" : "Invoice No");
            combobox_SortTyp.Items.Add((LangArEn == 0) ? "تاريخ الفاتورة" : "Invoice Date");
            combobox_SortTyp.SelectedIndex = 0;
            CmbInvType.Items.Clear();
            CmbInvType.DataSource = listInvSetting;
            CmbInvType.DisplayMember = ((LangArEn == 0) ? "InvNamA" : "InvNamE");
            CmbInvType.ValueMember = "InvID";
            CmbInvType.SelectedIndex = 0;
            List<string> listRunCod = db.ExecuteQuery<string>("select distinct RunCod from T_QTYEXP where T_QTYEXP.RunCod != '' order by RunCod", new object[0]).ToList();
            listRunCod.Insert(0, "");
            combobox_RunNo.DataSource = listRunCod;
            combobox_RunNo.SelectedIndex = 0;
            List<string> listDateExpir = db.ExecuteQuery<string>("select distinct DatExper from T_QTYEXP where T_QTYEXP.DatExper != '' order by DatExper", new object[0]).ToList();
            listDateExpir.Insert(0, "");
            combobox_DateExpir.DataSource = listDateExpir;
            combobox_DateExpir.SelectedIndex = 0;
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
        private void button_SrchLegNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("Mnd_No", new ColumnDictinary("الــرقم", "No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
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
                txtLegNo.Text = db.StockMndob(frm.Serach_No).Mnd_ID.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtLegName.Text = db.StockMndob(frm.Serach_No).Arb_Des.ToString();
                }
                else
                {
                    txtLegName.Text = db.StockMndob(frm.Serach_No).Eng_Des.ToString();
                }
            }
            else
            {
                txtLegNo.Text = "";
                txtLegName.Text = "";
            }
        }
        private void button_SrchCostNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("Cst_No", new ColumnDictinary("الرقم", "No", ifDefault: true, ""));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
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
                txtCostNo.Text = db.StockCst(frm.Serach_No).Cst_ID.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtCostName.Text = db.StockCst(frm.Serach_No).Arb_Des.ToString();
                }
                else
                {
                    txtCostName.Text = db.StockCst(frm.Serach_No).Eng_Des.ToString();
                }
            }
            else
            {
                txtCostNo.Text = "";
                txtCostName.Text = "";
            }
        }
        private void button_SrchUsrNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("UsrNo", new ColumnDictinary("رقم المستخدم", "User No", ifDefault: true, ""));
            columns_Names_visible.Add("UsrNamA", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, ""));
            columns_Names_visible.Add("UsrNamE", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, ""));
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
                txtUserNo.Text = frm.Serach_No;
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
        private void button_SrchItemNo_Click(object sender, EventArgs e)
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
                txtItemNo.Text = frm.Serach_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtItemName.Text = db.StockItem(frm.Serach_No).Arb_Des.ToString();
                }
                else
                {
                    txtItemName.Text = db.StockItem(frm.Serach_No).Eng_Des.ToString();
                }
            }
            else
            {
                txtItemNo.Text = "";
                txtItemName.Text = "";
            }
        }
        private void button_SrchItemGroup_Click(object sender, EventArgs e)
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
        private void CmbInvType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                VarGeneral.InvType = int.Parse(CmbInvType.SelectedValue.ToString());
            }
            catch
            {
                VarGeneral.InvType = 1;
            }
            FillFlex();
        }
        private void combobox_DateExpir_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combobox_ExpirRunNo.DataSource = null;
                if (combobox_DateExpir.SelectedIndex > 0)
                {
                    combobox_ExpirRunNo.Enabled = true;
                    List<T_QTYEXP> listDateExpir = new List<T_QTYEXP>(db.T_QTYEXPs.Where((T_QTYEXP item) => item.DatExper == combobox_DateExpir.Text)).ToList();
                    listDateExpir.Insert(0, new T_QTYEXP());
                    listDateExpir[0].RunCod = ((LangArEn == 0) ? "----------أرقام التصنيع----------" : "----------Make No----------");
                    combobox_ExpirRunNo.DataSource = listDateExpir;
                    combobox_ExpirRunNo.DisplayMember = "RunCod";
                    combobox_ExpirRunNo.ValueMember = "RunCod";
                    combobox_ExpirRunNo.SelectedIndex = 0;
                }
                else
                {
                    combobox_ExpirRunNo.Enabled = false;
                }
            }
            catch
            {
                combobox_ExpirRunNo.DataSource = null;
            }
        }
        private void combobox_RunNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combobox_RunDateExpir.DataSource = null;
                if (combobox_RunNo.SelectedIndex > 0)
                {
                    combobox_RunDateExpir.Enabled = true;
                    List<T_QTYEXP> listDateExpir = new List<T_QTYEXP>(db.T_QTYEXPs.Where((T_QTYEXP item) => item.RunCod == combobox_RunNo.Text)).ToList();
                    listDateExpir.Insert(0, new T_QTYEXP());
                    listDateExpir[0].DatExper = ((LangArEn == 0) ? "----------تــواريـخ الصلاحية----------" : "----------Expir Date----------");
                    combobox_RunDateExpir.DataSource = listDateExpir;
                    combobox_RunDateExpir.DisplayMember = "DatExper";
                    combobox_RunDateExpir.ValueMember = "DatExper";
                    combobox_RunDateExpir.SelectedIndex = 0;
                }
                else
                {
                    combobox_RunDateExpir.Enabled = false;
                }
            }
            catch
            {
                combobox_RunDateExpir.DataSource = null;
            }
        }
        private void txtMFromDateExpir_Click(object sender, EventArgs e)
        {
            txtMFromDateExpir.SelectAll();
        }
        private void txtMToDateExpir_Click(object sender, EventArgs e)
        {
            txtMToDateExpir.SelectAll();
        }
        private void txtMFromDateExpir_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtMFromDateExpir.Text))
                {
                    txtMFromDateExpir.Text = Convert.ToDateTime(txtMFromDateExpir.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    txtMFromDateExpir.Text = "";
                }
            }
            catch
            {
                txtMFromDateExpir.Text = "";
            }
        }
        private void txtMToDateExpir_Leave(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CheckDate(txtMToDateExpir.Text))
                {
                    txtMToDateExpir.Text = Convert.ToDateTime(txtMToDateExpir.Text).ToString("yyyy/MM/dd");
                }
                else
                {
                    txtMToDateExpir.Text = "";
                }
            }
            catch
            {
                txtMToDateExpir.Text = "";
            }
        }
        private void txtMFromNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void txtMIntoNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void ButOk_MouseMove(object sender, MouseEventArgs e)
        {
            ButOk.BackgroundImage = Properties.Resources.howver;
            ButOk.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void ButExit_MouseMove(object sender, MouseEventArgs e)
        {
            ButExit.BackgroundImage = Properties.Resources.howver;
            ButExit.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void ButOk_MouseLeave(object sender, EventArgs e)
        {
            ButOk.BackgroundImage = Properties.Resources.print;
            ButOk.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void ButExit_MouseLeave(object sender, EventArgs e)
        {
            ButExit.BackgroundImage = Properties.Resources.YALO2;
            ButExit.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void CmbDeleted_Enter(object sender, EventArgs e)
        {
        }
        private void radioButton__0650Return2_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
