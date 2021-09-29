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
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FRAccount : Form
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
                        frm.Repvalue = "Account";


                        frm.Repvalue = "Account";
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
        private void FrmInvSale_SizeChanged(object sender, EventArgs e)
        {
            netResize1.Refresh();
        }
        private Panel PanelSpecialContainer;
        public Softgroup.NetResize.NetResize netResize1;
        private Label label8;
        private RibbonBar ribbonBar1;
        private TextBox txtLegateName;
        private TextBox txtMainAccName;
        private TextBox txtUserName;
        private TextBox txtCostCName;
        private TextBox txtLegateNo;
        private TextBox txtUserNo;
        private TextBox txtCostCNo;
        private Label label6;
        private Label label5;
        private Label label7;
        private ButtonX button_SrchUsrNo;
        private ButtonX button_SrchCostNo;
        private ButtonX button_SrchLegNo;
        private ButtonX button_SrchAccFrom;
        private GroupBox groupBox4;
        private Label label1;
        private Label label2;
        private GroupBox groupBox3;
        private Label label10;
        private ComboBoxEx combobox_SortTyp;
        private GroupBox groupBox2;
        public RadioButton RButShort;
        public RadioButton RButDet;
        public TextBox txtMainAccNo;
        public MaskedTextBox txtMToDate;
        public MaskedTextBox txtMFromDate;
        private ComboBoxEx CmbCurr;
        private Label label9;
        private DoubleInput txtMBalanceB;
        private DoubleInput txtMBalanceS;
        private Label label3;
        private Label label4;
        private CheckBoxX checkBox_OldBlance;
        private CheckBoxX checkBox_BalanceMove;
        private Label label11;
        private TextBoxX txtRemark;
        private CheckBoxX checkBox_OldBCalcaluat;
        private int LangArEn = 0;
        private T_User _User = new T_User();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private Stock_DataDataContext dbInstance;
        private C1.Win.C1Input.C1Button ButExit;
        private ControlContainerItem controlContainerItem1;
        private C1.Win.C1Input.C1Button ButOk;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRAccount));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.ButOk = new C1.Win.C1Input.C1Button();
            this.ButExit = new C1.Win.C1Input.C1Button();
            this.checkBox_OldBCalcaluat = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.txtRemark = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBox_BalanceMove = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBox_OldBlance = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.label9 = new System.Windows.Forms.Label();
            this.CmbCurr = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label10 = new System.Windows.Forms.Label();
            this.combobox_SortTyp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtLegateName = new System.Windows.Forms.TextBox();
            this.txtMainAccName = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtMainAccNo = new System.Windows.Forms.TextBox();
            this.txtLegateNo = new System.Windows.Forms.TextBox();
            this.txtUserNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_SrchUsrNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchLegNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchAccFrom = new DevComponents.DotNetBar.ButtonX();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtMToDate = new System.Windows.Forms.MaskedTextBox();
            this.txtMFromDate = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtMBalanceB = new DevComponents.Editors.DoubleInput();
            this.txtMBalanceS = new DevComponents.Editors.DoubleInput();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCostCName = new System.Windows.Forms.TextBox();
            this.txtCostCNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button_SrchCostNo = new DevComponents.DotNetBar.ButtonX();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RButShort = new System.Windows.Forms.RadioButton();
            this.RButDet = new System.Windows.Forms.RadioButton();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.PanelSpecialContainer.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButExit)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMBalanceB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMBalanceS)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelSpecialContainer
            // 
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar1);
            this.PanelSpecialContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSpecialContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelSpecialContainer.Name = "PanelSpecialContainer";
            this.PanelSpecialContainer.Size = new System.Drawing.Size(427, 401);
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
            this.ribbonBar1.Controls.Add(this.checkBox_OldBCalcaluat);
            this.ribbonBar1.Controls.Add(this.txtRemark);
            this.ribbonBar1.Controls.Add(this.label11);
            this.ribbonBar1.Controls.Add(this.checkBox_BalanceMove);
            this.ribbonBar1.Controls.Add(this.checkBox_OldBlance);
            this.ribbonBar1.Controls.Add(this.label9);
            this.ribbonBar1.Controls.Add(this.CmbCurr);
            this.ribbonBar1.Controls.Add(this.label10);
            this.ribbonBar1.Controls.Add(this.combobox_SortTyp);
            this.ribbonBar1.Controls.Add(this.txtLegateName);
            this.ribbonBar1.Controls.Add(this.txtMainAccName);
            this.ribbonBar1.Controls.Add(this.txtUserName);
            this.ribbonBar1.Controls.Add(this.txtMainAccNo);
            this.ribbonBar1.Controls.Add(this.txtLegateNo);
            this.ribbonBar1.Controls.Add(this.txtUserNo);
            this.ribbonBar1.Controls.Add(this.label8);
            this.ribbonBar1.Controls.Add(this.label6);
            this.ribbonBar1.Controls.Add(this.label5);
            this.ribbonBar1.Controls.Add(this.button_SrchUsrNo);
            this.ribbonBar1.Controls.Add(this.button_SrchLegNo);
            this.ribbonBar1.Controls.Add(this.button_SrchAccFrom);
            this.ribbonBar1.Controls.Add(this.groupBox4);
            this.ribbonBar1.Controls.Add(this.groupBox3);
            this.ribbonBar1.Controls.Add(this.txtCostCName);
            this.ribbonBar1.Controls.Add(this.txtCostCNo);
            this.ribbonBar1.Controls.Add(this.label7);
            this.ribbonBar1.Controls.Add(this.button_SrchCostNo);
            this.ribbonBar1.Controls.Add(this.groupBox2);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.controlContainerItem1});
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(427, 401);
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
            this.ribbonBar1.ItemClick += new System.EventHandler(this.ribbonBar1_ItemClick);
            // 
            // ButOk
            // 
            this.ButOk.BackgroundImage = global::InvAcc.Properties.Resources.print;
            this.ButOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButOk.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButOk.Location = new System.Drawing.Point(195, 346);
            this.ButOk.Name = "ButOk";
            this.ButOk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButOk.Size = new System.Drawing.Size(227, 35);
            this.ButOk.TabIndex = 6746;
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
            this.ButExit.Location = new System.Drawing.Point(10, 346);
            this.ButExit.Name = "ButExit";
            this.ButExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButExit.Size = new System.Drawing.Size(179, 35);
            this.ButExit.TabIndex = 6745;
            this.ButExit.Text = "خروج | ESC";
            this.ButExit.UseVisualStyleBackColor = true;
            this.ButExit.Click += new System.EventHandler(this.ButExit_Click);
            this.ButExit.MouseLeave += new System.EventHandler(this.ButExit_MouseLeave);
            this.ButExit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButExit_MouseMove);
            // 
            // checkBox_OldBCalcaluat
            // 
            this.checkBox_OldBCalcaluat.BackColor = System.Drawing.Color.LightGray;
            // 
            // 
            // 
            this.checkBox_OldBCalcaluat.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.checkBox_OldBCalcaluat.BackgroundStyle.BorderBottomColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkBox_OldBCalcaluat.BackgroundStyle.BorderBottomWidth = 1;
            this.checkBox_OldBCalcaluat.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkBox_OldBCalcaluat.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.checkBox_OldBCalcaluat.BackgroundStyle.BorderLeftWidth = 1;
            this.checkBox_OldBCalcaluat.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.checkBox_OldBCalcaluat.BackgroundStyle.BorderRightWidth = 1;
            this.checkBox_OldBCalcaluat.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.checkBox_OldBCalcaluat.BackgroundStyle.BorderTopWidth = 1;
            this.checkBox_OldBCalcaluat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_OldBCalcaluat.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            this.checkBox_OldBCalcaluat.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.checkBox_OldBCalcaluat.Location = new System.Drawing.Point(9, 310);
            this.checkBox_OldBCalcaluat.Name = "checkBox_OldBCalcaluat";
            this.checkBox_OldBCalcaluat.Size = new System.Drawing.Size(134, 33);
            this.checkBox_OldBCalcaluat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_OldBCalcaluat.TabIndex = 6744;
            this.checkBox_OldBCalcaluat.Text = "إحتساب الرصيد السابق";
            this.checkBox_OldBCalcaluat.Visible = false;
            this.checkBox_OldBCalcaluat.CheckedChanged += new System.EventHandler(this.checkBox_OldBCalcaluat_CheckedChanged);
            // 
            // txtRemark
            // 
            this.txtRemark.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtRemark.Border.Class = "TextBoxBorder";
            this.txtRemark.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRemark.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("txtRemark.ButtonCustom.Image")));
            this.txtRemark.ButtonCustom.Visible = true;
            this.txtRemark.ForeColor = System.Drawing.Color.Black;
            this.txtRemark.Location = new System.Drawing.Point(9, 234);
            this.txtRemark.Name = "txtRemark";
            this.netResize1.SetResizeTextBoxMultiline(this.txtRemark, false);
            this.txtRemark.Size = new System.Drawing.Size(335, 22);
            this.txtRemark.TabIndex = 6743;
            this.txtRemark.Tag = "T_GDDET.gdDes";
            this.txtRemark.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRemark.ButtonCustomClick += new System.EventHandler(this.txtRemark_ButtonCustomClick);
            this.txtRemark.Click += new System.EventHandler(this.txtRemark_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(347, 239);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 13);
            this.label11.TabIndex = 6742;
            this.label11.Text = "حسب البيان :";
            // 
            // checkBox_BalanceMove
            // 
            // 
            // 
            // 
            this.checkBox_BalanceMove.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.checkBox_BalanceMove.BackgroundStyle.BorderBottomColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkBox_BalanceMove.BackgroundStyle.BorderBottomWidth = 1;
            this.checkBox_BalanceMove.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkBox_BalanceMove.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.checkBox_BalanceMove.BackgroundStyle.BorderLeftWidth = 1;
            this.checkBox_BalanceMove.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.checkBox_BalanceMove.BackgroundStyle.BorderRightWidth = 1;
            this.checkBox_BalanceMove.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.checkBox_BalanceMove.BackgroundStyle.BorderTopWidth = 1;
            this.checkBox_BalanceMove.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_BalanceMove.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            this.checkBox_BalanceMove.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.checkBox_BalanceMove.Location = new System.Drawing.Point(290, 310);
            this.checkBox_BalanceMove.Name = "checkBox_BalanceMove";
            this.checkBox_BalanceMove.Size = new System.Drawing.Size(134, 33);
            this.checkBox_BalanceMove.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_BalanceMove.TabIndex = 6741;
            this.checkBox_BalanceMove.Text = "تحريك الرصيد";
            this.checkBox_BalanceMove.CheckedChanged += new System.EventHandler(this.checkBox_BalanceMove_CheckedChanged);
            // 
            // checkBox_OldBlance
            // 
            // 
            // 
            // 
            this.checkBox_OldBlance.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.checkBox_OldBlance.BackgroundStyle.BorderBottomColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkBox_OldBlance.BackgroundStyle.BorderBottomWidth = 1;
            this.checkBox_OldBlance.BackgroundStyle.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkBox_OldBlance.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.checkBox_OldBlance.BackgroundStyle.BorderLeftWidth = 1;
            this.checkBox_OldBlance.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.checkBox_OldBlance.BackgroundStyle.BorderRightWidth = 1;
            this.checkBox_OldBlance.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Dash;
            this.checkBox_OldBlance.BackgroundStyle.BorderTopWidth = 1;
            this.checkBox_OldBlance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox_OldBlance.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
            this.checkBox_OldBlance.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.checkBox_OldBlance.Location = new System.Drawing.Point(146, 310);
            this.checkBox_OldBlance.Name = "checkBox_OldBlance";
            this.checkBox_OldBlance.Size = new System.Drawing.Size(140, 33);
            this.checkBox_OldBlance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox_OldBlance.TabIndex = 6740;
            this.checkBox_OldBlance.Text = "إظهار الرصيد السابق";
            this.checkBox_OldBlance.CheckedChanged += new System.EventHandler(this.checkBox_OldBlance_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(345, 288);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 6732;
            this.label9.Text = "العملـــــــــــة :";
            // 
            // CmbCurr
            // 
            this.CmbCurr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbCurr.DisplayMember = "Text";
            this.CmbCurr.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbCurr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCurr.Font = new System.Drawing.Font("Tahoma", 8F);
            this.CmbCurr.FormattingEnabled = true;
            this.CmbCurr.ItemHeight = 14;
            this.CmbCurr.Location = new System.Drawing.Point(146, 284);
            this.CmbCurr.Name = "CmbCurr";
            this.CmbCurr.Size = new System.Drawing.Size(198, 20);
            this.CmbCurr.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbCurr.TabIndex = 6731;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(347, 264);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 6722;
            this.label10.Text = "ترتيب حسب :";
            // 
            // combobox_SortTyp
            // 
            this.combobox_SortTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combobox_SortTyp.DisplayMember = "Text";
            this.combobox_SortTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_SortTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_SortTyp.Font = new System.Drawing.Font("Tahoma", 8F);
            this.combobox_SortTyp.FormattingEnabled = true;
            this.combobox_SortTyp.ItemHeight = 14;
            this.combobox_SortTyp.Location = new System.Drawing.Point(146, 260);
            this.combobox_SortTyp.Name = "combobox_SortTyp";
            this.combobox_SortTyp.Size = new System.Drawing.Size(198, 20);
            this.combobox_SortTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combobox_SortTyp.TabIndex = 6721;
            // 
            // txtLegateName
            // 
            this.txtLegateName.BackColor = System.Drawing.Color.Ivory;
            this.txtLegateName.ForeColor = System.Drawing.Color.White;
            this.txtLegateName.Location = new System.Drawing.Point(9, 160);
            this.txtLegateName.Name = "txtLegateName";
            this.txtLegateName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtLegateName, false);
            this.txtLegateName.Size = new System.Drawing.Size(201, 20);
            this.txtLegateName.TabIndex = 10;
            this.txtLegateName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMainAccName
            // 
            this.txtMainAccName.BackColor = System.Drawing.Color.Ivory;
            this.txtMainAccName.ForeColor = System.Drawing.Color.White;
            this.txtMainAccName.Location = new System.Drawing.Point(9, 135);
            this.txtMainAccName.Name = "txtMainAccName";
            this.txtMainAccName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtMainAccName, false);
            this.txtMainAccName.Size = new System.Drawing.Size(201, 20);
            this.txtMainAccName.TabIndex = 7;
            this.txtMainAccName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.Ivory;
            this.txtUserName.ForeColor = System.Drawing.Color.White;
            this.txtUserName.Location = new System.Drawing.Point(9, 185);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtUserName, false);
            this.txtUserName.Size = new System.Drawing.Size(201, 20);
            this.txtUserName.TabIndex = 13;
            this.txtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMainAccNo
            // 
            this.txtMainAccNo.BackColor = System.Drawing.Color.White;
            this.txtMainAccNo.Location = new System.Drawing.Point(241, 135);
            this.txtMainAccNo.Name = "txtMainAccNo";
            this.txtMainAccNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtMainAccNo, false);
            this.txtMainAccNo.Size = new System.Drawing.Size(103, 20);
            this.txtMainAccNo.TabIndex = 5;
            this.txtMainAccNo.Tag = " T_GDDET.AccNo ";
            this.txtMainAccNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLegateNo
            // 
            this.txtLegateNo.BackColor = System.Drawing.Color.White;
            this.txtLegateNo.Location = new System.Drawing.Point(241, 160);
            this.txtLegateNo.Name = "txtLegateNo";
            this.txtLegateNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtLegateNo, false);
            this.txtLegateNo.Size = new System.Drawing.Size(103, 20);
            this.txtLegateNo.TabIndex = 8;
            this.txtLegateNo.Tag = " T_GDHEAD.gdMnd ";
            this.txtLegateNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUserNo
            // 
            this.txtUserNo.BackColor = System.Drawing.Color.White;
            this.txtUserNo.Location = new System.Drawing.Point(241, 185);
            this.txtUserNo.Name = "txtUserNo";
            this.txtUserNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtUserNo, false);
            this.txtUserNo.Size = new System.Drawing.Size(103, 20);
            this.txtUserNo.TabIndex = 11;
            this.txtUserNo.Tag = " T_GDHEAD.gdUser ";
            this.txtUserNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(347, 189);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 1121;
            this.label8.Text = "المستخـــدم :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(347, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 1120;
            this.label6.Text = "المنـــــدوب :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(347, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 1118;
            this.label5.Text = "الحســـاب :";
            // 
            // button_SrchUsrNo
            // 
            this.button_SrchUsrNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchUsrNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchUsrNo.Location = new System.Drawing.Point(212, 185);
            this.button_SrchUsrNo.Name = "button_SrchUsrNo";
            this.button_SrchUsrNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchUsrNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchUsrNo.Symbol = "";
            this.button_SrchUsrNo.SymbolSize = 12F;
            this.button_SrchUsrNo.TabIndex = 12;
            this.button_SrchUsrNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchUsrNo.Click += new System.EventHandler(this.button_SrchUsrNo_Click);
            // 
            // button_SrchLegNo
            // 
            this.button_SrchLegNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchLegNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchLegNo.Location = new System.Drawing.Point(212, 160);
            this.button_SrchLegNo.Name = "button_SrchLegNo";
            this.button_SrchLegNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchLegNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchLegNo.Symbol = "";
            this.button_SrchLegNo.SymbolSize = 12F;
            this.button_SrchLegNo.TabIndex = 9;
            this.button_SrchLegNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchLegNo.Click += new System.EventHandler(this.button_SrchLegNo_Click);
            // 
            // button_SrchAccFrom
            // 
            this.button_SrchAccFrom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchAccFrom.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchAccFrom.Location = new System.Drawing.Point(212, 135);
            this.button_SrchAccFrom.Name = "button_SrchAccFrom";
            this.button_SrchAccFrom.Size = new System.Drawing.Size(26, 20);
            this.button_SrchAccFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchAccFrom.Symbol = "";
            this.button_SrchAccFrom.SymbolSize = 12F;
            this.button_SrchAccFrom.TabIndex = 6;
            this.button_SrchAccFrom.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchAccFrom.Click += new System.EventHandler(this.button_SrchAccFrom_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.txtMToDate);
            this.groupBox4.Controls.Add(this.txtMFromDate);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.groupBox4.Location = new System.Drawing.Point(9, 17);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(412, 52);
            this.groupBox4.TabIndex = 1109;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "حسب التاريخ";
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
            this.txtMFromDate.Location = new System.Drawing.Point(220, 21);
            this.txtMFromDate.Mask = "0000/00/00";
            this.txtMFromDate.Name = "txtMFromDate";
            this.txtMFromDate.Size = new System.Drawing.Size(108, 21);
            this.txtMFromDate.TabIndex = 1;
            this.txtMFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMFromDate.Click += new System.EventHandler(this.txtMFromDate_Click);
            this.txtMFromDate.Leave += new System.EventHandler(this.txtMFromDate_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(335, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 860;
            this.label1.Text = "مـــــن :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label2.Text = "إلـــــى :";
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
            this.groupBox3.Location = new System.Drawing.Point(9, 79);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(412, 52);
            this.groupBox3.TabIndex = 1145;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "الرصيــــد";
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
            this.txtMBalanceB.Location = new System.Drawing.Point(221, 22);
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
            this.txtMBalanceS.Location = new System.Drawing.Point(36, 22);
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
            this.label3.Location = new System.Drawing.Point(333, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 1157;
            this.label3.Text = "مـــــن :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(150, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 1156;
            this.label4.Text = "أصغر من = :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCostCName
            // 
            this.txtCostCName.BackColor = System.Drawing.Color.Ivory;
            this.txtCostCName.ForeColor = System.Drawing.Color.White;
            this.txtCostCName.Location = new System.Drawing.Point(9, 210);
            this.txtCostCName.Name = "txtCostCName";
            this.txtCostCName.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtCostCName, false);
            this.txtCostCName.Size = new System.Drawing.Size(201, 20);
            this.txtCostCName.TabIndex = 16;
            this.txtCostCName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCostCNo
            // 
            this.txtCostCNo.BackColor = System.Drawing.Color.White;
            this.txtCostCNo.Location = new System.Drawing.Point(241, 210);
            this.txtCostCNo.Name = "txtCostCNo";
            this.txtCostCNo.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtCostCNo, false);
            this.txtCostCNo.Size = new System.Drawing.Size(103, 20);
            this.txtCostCNo.TabIndex = 14;
            this.txtCostCNo.Tag = " T_GDHEAD.gdCstNo ";
            this.txtCostCNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(347, 214);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 1117;
            this.label7.Text = "مركز التكلفة :";
            // 
            // button_SrchCostNo
            // 
            this.button_SrchCostNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchCostNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCostNo.Location = new System.Drawing.Point(212, 210);
            this.button_SrchCostNo.Name = "button_SrchCostNo";
            this.button_SrchCostNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchCostNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCostNo.Symbol = "";
            this.button_SrchCostNo.SymbolSize = 12F;
            this.button_SrchCostNo.TabIndex = 15;
            this.button_SrchCostNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCostNo.Click += new System.EventHandler(this.button_SrchCostNo_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.RButShort);
            this.groupBox2.Controls.Add(this.RButDet);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(9, 252);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(134, 54);
            this.groupBox2.TabIndex = 6730;
            this.groupBox2.TabStop = false;
            // 
            // RButShort
            // 
            this.RButShort.AutoSize = true;
            this.RButShort.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.RButShort.ForeColor = System.Drawing.Color.SteelBlue;
            this.RButShort.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RButShort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RButShort.Location = new System.Drawing.Point(37, 32);
            this.RButShort.Name = "RButShort";
            this.RButShort.Size = new System.Drawing.Size(61, 17);
            this.RButShort.TabIndex = 1008;
            this.RButShort.Text = "مختصر";
            this.RButShort.UseVisualStyleBackColor = true;
            this.RButShort.CheckedChanged += new System.EventHandler(this.RButDet_CheckedChanged);
            // 
            // RButDet
            // 
            this.RButDet.AutoSize = true;
            this.RButDet.Checked = true;
            this.RButDet.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.RButDet.ForeColor = System.Drawing.Color.SteelBlue;
            this.RButDet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RButDet.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RButDet.Location = new System.Drawing.Point(31, 12);
            this.RButDet.Name = "RButDet";
            this.RButDet.Size = new System.Drawing.Size(67, 17);
            this.RButDet.TabIndex = 1007;
            this.RButDet.TabStop = true;
            this.RButDet.Text = "تفصيلي";
            this.RButDet.UseVisualStyleBackColor = true;
            this.RButDet.CheckedChanged += new System.EventHandler(this.RButDet_CheckedChanged);
            // 
            // controlContainerItem1
            // 
            this.controlContainerItem1.AllowItemResize = false;
            this.controlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem1.Name = "controlContainerItem1";
            // 
            // netResize1
            // 
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            // 
            // FRAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 401);
            this.Controls.Add(this.PanelSpecialContainer);
            this.Icon = global::InvAcc.Properties.Resources.favicon;
            this.KeyPreview = true;
            this.Name = "FRAccount";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "كشف حساب";
            this.Load += new System.EventHandler(this.FRAccount_Load);
            this.Shown += new System.EventHandler(this.FRAccount_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.PanelSpecialContainer.ResumeLayout(false);
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);
        }
        public FRAccount()
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
                label7.Visible = false;
                txtCostCNo.Visible = false;
                button_SrchCostNo.Visible = false;
                txtCostCName.Visible = false;
            }
            else
            {
                label7.Visible = true;
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
                        label7.Visible = true;
                        txtCostCNo.Visible = true;
                        button_SrchCostNo.Visible = true;
                        txtCostCName.Visible = true;
                    }
                    else
                    {
                        label7.Visible = false;
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
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FRAccount));
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
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptMaintenanceCars.dll"))
                {
                    label7.Text = ((LangArEn == 0) ? "نوع السيارة :" : "Car Type :");
                }
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptBus.dll"))
                {
                    label7.Text = ((LangArEn == 0) ? "الباص :" : "Bus :");
                    label6.Text = ((LangArEn == 0) ? "السائق :" : "Driver :");
                }
                if (File.Exists(Application.StartupPath + "\\Script\\SecriptWaterPackages.dll"))
                {
                    label6.Text = ((LangArEn == 0) ? "العميــــــــل :" : "Customer :");
                    label7.Text = ((LangArEn == 0) ? "السيــارة :" : "Car :");
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRAccount));
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
        }
        private void FillFlex()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                if (VarGeneral.InvType == 1)
                {
                    Text = "كشف حساب";
                }
            }
            else if (VarGeneral.InvType == 1)
            {
                Text = "Statement of Accounts";
            }
            RibunButtons();
            FillCombo();
        }
        private string BuildFieldList()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                return " T_GDDET.AccNo as AccDef_No,(select Arb_Des from T_AccDef where T_AccDef.AccDef_No = T_GDDET.AccNo) as AccDefNm, T_GDHEAD.gdNo,T_INVSETTING.InvNamA as InvNm,T_GDHEAD.gdHDate,T_GDHEAD.gdGDate,T_GDDET.gdDes,CASE WHEN T_GDDET.gdValue > 0 THEN " + ((CmbCurr.SelectedIndex > 0) ? (" case when T_GDHEAD.CurTyp != " + int.Parse(CmbCurr.SelectedValue.ToString()) + " then (Round((T_GDDET.gdValue * (select Rate from T_Curency where T_Curency.Curency_ID = T_GDHEAD.CurTyp)) / " + db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value + "," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) else T_GDDET.gdValue end ") : " T_GDDET.gdValue ") + " ELSE 0 END as Debit,CASE WHEN T_GDDET.gdValue < 0 THEN " + ((CmbCurr.SelectedIndex > 0) ? (" case when T_GDHEAD.CurTyp != " + int.Parse(CmbCurr.SelectedValue.ToString()) + " then (Round(Abs((T_GDDET.gdValue * (select Rate from T_Curency where T_Curency.Curency_ID = T_GDHEAD.CurTyp))) / " + db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value + "," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) else Abs(T_GDDET.gdValue) end ") : " Abs(T_GDDET.gdValue) ") + "  ELSE 0 END as Credit ," + ((CmbCurr.SelectedIndex > 0) ? (" case when T_GDHEAD.CurTyp != " + int.Parse(CmbCurr.SelectedValue.ToString()) + " then (Round((T_GDDET.gdValue * (select Rate from T_Curency where T_Curency.Curency_ID = T_GDHEAD.CurTyp)) / " + db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value + "," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) else (Round(T_GDDET.gdValue," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) end ") : (" (Round(T_GDDET.gdValue," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) ")) + " as Balance,T_SYSSETTING.LogImg,T_SYSSETTING.Calendr," + (checkBox_OldBCalcaluat.Checked ? " 2 as BalanceIsMove " : (checkBox_BalanceMove.Checked ? " 1 as BalanceIsMove " : "  0 as BalanceIsMove "));
            }
            return " T_GDDET.AccNo as AccDef_No,(select Eng_Des from T_AccDef where T_AccDef.AccDef_No = T_GDDET.AccNo) as AccDefNm, T_GDHEAD.gdNo,T_INVSETTING.InvNamE as InvNm,T_GDHEAD.gdHDate,T_GDHEAD.gdGDate,T_GDDET.gdDesE as gdDes,CASE WHEN T_GDDET.gdValue > 0 THEN " + ((CmbCurr.SelectedIndex > 0) ? (" case when T_GDHEAD.CurTyp != " + int.Parse(CmbCurr.SelectedValue.ToString()) + " then (Round((T_GDDET.gdValue * (select Rate from T_Curency where T_Curency.Curency_ID = T_GDHEAD.CurTyp)) / " + db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value + "," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) else T_GDDET.gdValue end ") : " T_GDDET.gdValue ") + " ELSE 0 END as Debit,CASE WHEN T_GDDET.gdValue < 0 THEN " + ((CmbCurr.SelectedIndex > 0) ? (" case when T_GDHEAD.CurTyp != " + int.Parse(CmbCurr.SelectedValue.ToString()) + " then (Round(Abs((T_GDDET.gdValue * (select Rate from T_Curency where T_Curency.Curency_ID = T_GDHEAD.CurTyp))) / " + db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value + "," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) else Abs(T_GDDET.gdValue) end ") : " Abs(T_GDDET.gdValue) ") + "  ELSE 0 END as Credit ," + ((CmbCurr.SelectedIndex > 0) ? (" case when T_GDHEAD.CurTyp != " + int.Parse(CmbCurr.SelectedValue.ToString()) + " then (Round((T_GDDET.gdValue * (select Rate from T_Curency where T_Curency.Curency_ID = T_GDHEAD.CurTyp)) / " + db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value + "," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) else (Round(T_GDDET.gdValue," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) end ") : (" (Round(T_GDDET.gdValue," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) ")) + " as Balance,T_SYSSETTING.LogImg,T_SYSSETTING.Calendr," + (checkBox_OldBCalcaluat.Checked ? " 2 as BalanceIsMove " : (checkBox_BalanceMove.Checked ? " 1 as BalanceIsMove " : "  0 as BalanceIsMove "));
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
            if (!string.IsNullOrEmpty(txtMainAccNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtMainAccNo.Tag, " = '", txtMainAccNo.Text.Trim(), "'");
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
            if (VarGeneral.CheckDate(txtMFromDate.Text) && txtMFromDate.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMFromDate.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_GDHEAD.gdGDate  >= '" + dateFormatter.FormatGreg(txtMFromDate.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_GDHEAD.gdHDate  >= '" + dateFormatter.FormatHijri(txtMFromDate.Text, "yyyy/MM/dd") + "'"));
            }
            if (VarGeneral.CheckDate(txtMToDate.Text) && txtMToDate.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMToDate.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_GDHEAD.gdGDate  <= '" + dateFormatter.FormatGreg(txtMToDate.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_GDHEAD.gdHDate  <= '" + dateFormatter.FormatHijri(txtMToDate.Text, "yyyy/MM/dd") + "'"));
            }
            if (!string.IsNullOrEmpty(txtRemark.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and (", txtRemark.Tag, " like '%", txtRemark.Text.Trim(), "%' or ", txtRemark.Tag, "E like '%", txtRemark.Text.Trim(), "%')");
            }
            return Rule;
        }
        private string BuildRuleList2()
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
            if (!string.IsNullOrEmpty(txtMainAccNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtMainAccNo.Tag, " = '", txtMainAccNo.Text.Trim(), "'");
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
            if (VarGeneral.CheckDate(txtMFromDate.Text) && txtMFromDate.Text.Length == 10)
            {
                Rule = ((int.Parse(txtMFromDate.Text.Substring(0, 4)) >= 1800) ? (Rule + " and  T_GDHEAD.gdGDate  < '" + dateFormatter.FormatGreg(txtMFromDate.Text, "yyyy/MM/dd") + "'") : (Rule + " and  T_GDHEAD.gdHDate  < '" + dateFormatter.FormatHijri(txtMFromDate.Text, "yyyy/MM/dd") + "'"));
            }
            if (!string.IsNullOrEmpty(txtRemark.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and (", txtRemark.Tag, " like '%", txtRemark.Text.Trim(), "%' or ", txtRemark.Tag, "E like '%", txtRemark.Text.Trim(), "%')");
            }
            return Rule + " and c.AccNo = T_GDDET.AccNo ";
        }
        string getratec(string s, double to, double frm)
        {
            double de1 = frm * (double.Parse(s));
            if (de1 != 0)
            {
                de1 = (double)de1 / to;
            }
            return (de1).ToString();
        }
        T_Curency defaltcurr, To, Frm;
        private void ButOk_Click(object sender, EventArgs e)
        {
            if (txtMainAccNo.Text == "")
            {
                MessageBox.Show((LangArEn == 0) ? "يجب تحديد رقم الحساب " : "must specify the account number ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txtMainAccNo.Focus();
                return;
            }
            try
            {
                int ff = CmbCurr.SelectedIndex;
                CmbCurr.SelectedIndex = -1;
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_GDDET LEFT OUTER JOIN  T_GDHEAD ON T_GDDET.gdID = T_GDHEAD.gdhead_ID  LEFT OUTER JOIN T_Curency ON T_GDHEAD.CurTyp = T_Curency.Curency_ID  LEFT OUTER JOIN T_INVSETTING On T_GDHEAD.gdTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_SYSSETTING ON T_GDHEAD.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                string Fields = BuildFieldList() + ",T_GDHEAD.CurTyp as Currancy" + ", case when (select sum(CASE WHEN c.gdValue > 0 THEN " + ((CmbCurr.SelectedIndex > 0) ? (" case when T_GDHEAD.CurTyp != " + int.Parse(CmbCurr.SelectedValue.ToString()) + " then (Round((c.gdValue * (select Rate from T_Curency where T_Curency.Curency_ID = T_GDHEAD.CurTyp)) / " + db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value + "," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) else c.gdValue end ") : " c.gdValue ") + " ELSE 0 END) as DebitPervious from T_GDDET as c LEFT OUTER JOIN T_GDHEAD ON c.gdID = T_GDHEAD.gdhead_ID LEFT OUTER JOIN T_Curency ON T_GDHEAD.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_INVSETTING On T_GDHEAD.gdTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_SYSSETTING ON T_GDHEAD.CompanyID = T_SYSSETTING.SYSSETTING_ID " + BuildRuleList2() + ") != '' then (select sum(CASE WHEN c.gdValue > 0 THEN " + ((CmbCurr.SelectedIndex > 0) ? (" case when T_GDHEAD.CurTyp != " + int.Parse(CmbCurr.SelectedValue.ToString()) + " then (Round((c.gdValue * (select Rate from T_Curency where T_Curency.Curency_ID = T_GDHEAD.CurTyp)) / " + db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value + "," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) else c.gdValue end ") : " c.gdValue ") + " ELSE 0 END) as DebitPervious from T_GDDET as c LEFT OUTER JOIN T_GDHEAD ON c.gdID = T_GDHEAD.gdhead_ID LEFT OUTER JOIN T_Curency ON T_GDHEAD.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_INVSETTING On T_GDHEAD.gdTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_SYSSETTING ON T_GDHEAD.CompanyID = T_SYSSETTING.SYSSETTING_ID " + BuildRuleList2() + ") else '0' end as DebitPervious, case when (select sum(CASE WHEN c.gdValue < 0 THEN " + ((CmbCurr.SelectedIndex > 0) ? (" case when T_GDHEAD.CurTyp != " + int.Parse(CmbCurr.SelectedValue.ToString()) + " then (Round(Abs((c.gdValue * (select Rate from T_Curency where T_Curency.Curency_ID = T_GDHEAD.CurTyp))) / " + db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value + "," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) else Abs(c.gdValue) end ") : " Abs(c.gdValue) ") + "  ELSE 0 END) as CreditPervious from T_GDDET as c LEFT OUTER JOIN T_GDHEAD ON c.gdID = T_GDHEAD.gdhead_ID LEFT OUTER JOIN T_Curency ON T_GDHEAD.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_INVSETTING On T_GDHEAD.gdTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_SYSSETTING ON T_GDHEAD.CompanyID = T_SYSSETTING.SYSSETTING_ID " + BuildRuleList2() + ") != '' then (select sum(CASE WHEN c.gdValue < 0 THEN " + ((CmbCurr.SelectedIndex > 0) ? (" case when T_GDHEAD.CurTyp != " + int.Parse(CmbCurr.SelectedValue.ToString()) + " then (Round(Abs((c.gdValue * (select Rate from T_Curency where T_Curency.Curency_ID = T_GDHEAD.CurTyp))) / " + db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value + "," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) else Abs(c.gdValue) end ") : " Abs(c.gdValue) ") + "  ELSE 0 END) as CreditPervious from T_GDDET as c LEFT OUTER JOIN T_GDHEAD ON c.gdID = T_GDHEAD.gdhead_ID LEFT OUTER JOIN T_Curency ON T_GDHEAD.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_INVSETTING On T_GDHEAD.gdTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_SYSSETTING ON T_GDHEAD.CompanyID = T_SYSSETTING.SYSSETTING_ID " + BuildRuleList2() + ") else '0' end as CreditPervious, case when (select sum(" + ((CmbCurr.SelectedIndex > 0) ? (" case when T_GDHEAD.CurTyp != " + int.Parse(CmbCurr.SelectedValue.ToString()) + " then (Round((c.gdValue * (select Rate from T_Curency where T_Curency.Curency_ID = T_GDHEAD.CurTyp)) / " + db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value + "," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) else c.gdValue end ") : " c.gdValue ") + ") as BalancePervious from T_GDDET as c LEFT OUTER JOIN T_GDHEAD ON c.gdID = T_GDHEAD.gdhead_ID LEFT OUTER JOIN T_Curency ON T_GDHEAD.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_INVSETTING On T_GDHEAD.gdTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_SYSSETTING ON T_GDHEAD.CompanyID = T_SYSSETTING.SYSSETTING_ID " + BuildRuleList2() + ") != '' then (select sum(" + ((CmbCurr.SelectedIndex > 0) ? (" case when T_GDHEAD.CurTyp != " + int.Parse(CmbCurr.SelectedValue.ToString()) + " then (Round((c.gdValue * (select Rate from T_Curency where T_Curency.Curency_ID = T_GDHEAD.CurTyp)) / " + db.StockCurencyID(int.Parse(CmbCurr.SelectedValue.ToString())).Rate.Value + "," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 49) ? VarGeneral.DecimalNo : 2) + ")) else c.gdValue end ") : " c.gdValue ") + ") as BalancePervious from T_GDDET as c LEFT OUTER JOIN T_GDHEAD ON c.gdID = T_GDHEAD.gdhead_ID LEFT OUTER JOIN T_Curency ON T_GDHEAD.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_INVSETTING On T_GDHEAD.gdTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_SYSSETTING ON T_GDHEAD.CompanyID = T_SYSSETTING.SYSSETTING_ID " + BuildRuleList2() + ") else '0' end as BalancePervious";
                _RepShow.Rule = BuildRuleList() + ((combobox_SortTyp.SelectedIndex == 0) ? " order by T_GDHEAD.gdGDate,T_GDHEAD.gdTyp, T_GDHEAD.gdNo" : ((combobox_SortTyp.SelectedIndex == 1) ? " order by T_GDHEAD.gdhead_ID" : " order by T_GDHEAD.gdTyp, T_GDHEAD.gdNo "));
                _RepShow.Fields = Fields;
                CmbCurr.SelectedIndex = ff;
                try
                {
                    _RepShow = _RepShow.Save();
                    if (CmbCurr.SelectedIndex > 0)
                        if (VarGeneral.InvType == 1)
                        {
                            DataTable t = _RepShow.RepData.Tables[0];
                            int parse = int.Parse(CmbCurr.SelectedValue.ToString());
                            To
                                = db.StockCurencyID(parse);
                            double rateTo = (double)To.Rate;
                            defaltcurr = db.StockCurencyID(1);
                            for (int i = 0; i < t.Rows.Count; i++)
                            {
                                Frm = db.StockCurencyID(int.Parse(t.Rows[i]["Currancy"].ToString()));
                                double rateFrom = (double)Frm.Rate;
                                //if (int.Parse(t.Rows[i]["Currancy"].ToString()) != parse)
                                //    {
                                t.Rows[i]["Debit"] = getratec(t.Rows[i]["Debit"].ToString(), rateTo, rateFrom);
                                t.Rows[i]["Credit"] = getratec(t.Rows[i]["Credit"].ToString(), rateTo, rateFrom);
                                t.Rows[i]["BalancePervious"] = getratec(t.Rows[i]["BalancePervious"].ToString(), rateTo, rateFrom);
                                t.Rows[i]["Balance"] = getratec(t.Rows[i]["Balance"].ToString(), rateTo, rateFrom);
                                t.Rows[i]["CreditPervious"] = getratec(t.Rows[i]["CreditPervious"].ToString(), rateTo, rateFrom);
                                t.Rows[i]["DebitPervious"] = getratec(t.Rows[i]["DebitPervious"].ToString(), rateTo, rateFrom);
                                //}                      
                            }
                            _RepShow.RepData.Tables.RemoveAt(0);
                            _RepShow.RepData.Tables.Add(t);
                        }
                    VarGeneral.RepData = _RepShow.RepData;
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.Message);
                }
                if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "عفوا .. لا يوجد بيانات لعرضها في التقرير " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    try
                    {
                        VarGeneral.IsGeneralUsed = true;
                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "Account";



                        frm.Tag = LangArEn;
                        frm.Repvalue = "Account";
                        if (RButDet.Checked)
                        {
                            VarGeneral.itmDesIndex = 0;
                        }
                        else
                        {
                            VarGeneral.itmDesIndex = 1;
                        }
                        try
                        {
                            if (checkBox_OldBlance.Checked)
                            {
                                VarGeneral.itmDes = "OldBalance";
                            }
                            else
                            {
                                VarGeneral.itmDes = "";
                            }
                        }
                        catch
                        {
                            VarGeneral.itmDes = "";
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
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
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
                groupBox3.Text = "الرصيــــد";
                groupBox4.Text = "التاريــــخ";
                label1.Text = "مـــــن :";
                label2.Text = "إلـــــى :";
                label5.Text = "الحســـاب :";
                label6.Text = "المنـــــدوب :";
                label7.Text = "مركز التكلفة :";
                label8.Text = "المستخـــدم :";
                checkBox_OldBlance.Text = "إظهار الرصيد السابق";
                checkBox_BalanceMove.Text = "تحريك الرصيد";
                checkBox_OldBCalcaluat.Text = "إحتساب الرصيد السابق";
            }
            else
            {
                ButExit.Text = "Exit Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "Print F5" : "Show F5");
                groupBox3.Text = "Balance";
                groupBox4.Text = "Date";
                label1.Text = "From :";
                label2.Text = "To :";
                label5.Text = "Account No :";
                label6.Text = "Delegate :";
                label7.Text = "Cost Center :";
                label8.Text = "User :";
                checkBox_OldBlance.Text = "Show previous balance";
                checkBox_BalanceMove.Text = "Move the balance";
                checkBox_OldBCalcaluat.Text = "Calculating the previous balance";
            }
        }
        private void FRAccount_Load(object sender, EventArgs e)
        {
        }
        public void FillCombo()
        {
            combobox_SortTyp.Items.Clear();
            combobox_SortTyp.Items.Add((LangArEn == 0) ? "تاريخ القيد" : "Date");
            combobox_SortTyp.Items.Add((LangArEn == 0) ? "تسلسل القيد" : "Sequence");
            combobox_SortTyp.Items.Add((LangArEn == 0) ? "رقــم القيد" : "No Bound");
            combobox_SortTyp.SelectedIndex = 0;
            List<T_Curency> listCurr = new List<T_Curency>(db.T_Curencies.Select((T_Curency item) => item).ToList());
            listCurr.Insert(0, new T_Curency());
            listCurr[0].Arb_Des = ((LangArEn == 0) ? "--- الإفتراضـــي ---" : "--- Default ---");
            listCurr[0].Eng_Des = ((LangArEn == 0) ? "--- الإفتراضـــي ---" : "--- Default ---");
            CmbCurr.DataSource = listCurr;
            CmbCurr.DisplayMember = ((LangArEn == 0) ? "Arb_Des" : "Eng_Des");
            CmbCurr.ValueMember = "Curency_ID";
            CmbCurr.SelectedIndex = 0;
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
            if (VarGeneral.CheckDate(txtMFromDate.Text) && txtMFromDate.Text.Length == 10)
            {
                checkBox_OldBlance.Enabled = true;
                return;
            }
            checkBox_OldBlance.Checked = false;
            checkBox_OldBlance.Enabled = false;
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
        private void txtMToDate_Click(object sender, EventArgs e)
        {
            txtMToDate.SelectAll();
        }
        private void txtMFromDate_Click(object sender, EventArgs e)
        {
            txtMFromDate.SelectAll();
        }
        private void button_SrchAccFrom_Click(object sender, EventArgs e)
        {
            if (VarGeneral.SSSTyp == 0)
            {
                VarGeneral.StockOnly = true;
                VarGeneral.InvTyp = 555;
            }
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
            if (VarGeneral.SSSTyp == 0)
            {
                VarGeneral.SFrmTyp = "T_AccDef";
            }
            else
            {
                VarGeneral.SFrmTyp = "AccDefID_Setting";
            }
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                txtMainAccNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    txtMainAccName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Arb_Des;
                }
                else
                {
                    txtMainAccName.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).Eng_Des;
                }
            }
            else
            {
                txtMainAccNo.Text = "";
                txtMainAccName.Text = "";
            }
        }
        private void button_SrchLegNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("Mnd_No", new ColumnDictinary("رقم المندوب", "Commissary No", ifDefault: true, ""));
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
        private void ribbonBar1_ItemClick(object sender, EventArgs e)
        {
        }
        private void RButDet_CheckedChanged(object sender, EventArgs e)
        {
            if (RButDet.Checked)
            {
                checkBox_OldBlance.Enabled = true;
                checkBox_BalanceMove.Enabled = true;
                return;
            }
            checkBox_OldBlance.Checked = false;
            checkBox_OldBlance.Enabled = false;
            checkBox_BalanceMove.Checked = false;
            checkBox_BalanceMove.Enabled = false;
        }
        private void checkBox_OldBlance_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_OldBlance.Checked)
            {
                checkBox_OldBCalcaluat.Visible = true;
            }
            else
            {
                checkBox_OldBCalcaluat.Visible = false;
            }
            checkBox_OldBCalcaluat.Checked = false;
        }
        private void checkBox_BalanceMove_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox_BalanceMove.Checked)
            {
                checkBox_OldBCalcaluat.Checked = false;
            }
        }
        private void txtRemark_Click(object sender, EventArgs e)
        {
            txtRemark.SelectAll();
        }
        private void txtRemark_ButtonCustomClick(object sender, EventArgs e)
        {
            txtRemark.Text = "";
        }
        private void checkBox_OldBCalcaluat_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_OldBCalcaluat.Checked)
            {
                checkBox_BalanceMove.Checked = true;
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
        private void FRAccount_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            WindowState = FormWindowState.Maximized;
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
