using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
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
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FRItemsDataMoreSale : Form
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
                        frm.Repvalue = "ItemsDataBestSales";


                        frm.Repvalue = "ItemsDataBestSales";
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
        private TextBox txtInItemName;
        private TextBox txtClassName;
        private TextBox txtFItemName;
        private TextBox txtCustName;
        private TextBox txtFItemNo;
        private TextBox txtInItemNo;
        private TextBox txtClassNo;
        private TextBox txtCustNo;
        private ButtonX ButExit;
        private ButtonX ButOk;
        private Label label7;
        private Label label6;
        private RibbonBar ribbonBar1;
        private ButtonX button_SrchCustNo;
        private ButtonX button_SrchClassNo;
        private ButtonX button_SrchItemTo;
        private ButtonX button_SrchItemFrom;
        private C1FlexGrid FlexField;
        private Label label8;
        private Label label5;
        private int LangArEn = 0;
        private T_User _User = new T_User();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRItemsDataMoreSale));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            components = new System.ComponentModel.Container();
            this.txtInItemName = new System.Windows.Forms.TextBox();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.txtFItemName = new System.Windows.Forms.TextBox();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.txtFItemNo = new System.Windows.Forms.TextBox();
            this.txtInItemNo = new System.Windows.Forms.TextBox();
            this.txtClassNo = new System.Windows.Forms.TextBox();
            this.txtCustNo = new System.Windows.Forms.TextBox();
            this.ButExit = new DevComponents.DotNetBar.ButtonX();
            this.ButOk = new DevComponents.DotNetBar.ButtonX();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_SrchCustNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchClassNo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchItemTo = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchItemFrom = new DevComponents.DotNetBar.ButtonX();
            this.FlexField = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.VisibleChanged += new System.EventHandler(this.FRInvoice_VisibleChanged);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.ribbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlexField)).BeginInit();
            this.PanelSpecialContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSpecialContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelSpecialContainer.Name = "PanelSpecialContainer";
            this.PanelSpecialContainer.Size = new System.Drawing.Size(1278, 514);
            this.PanelSpecialContainer.TabIndex = 1220;
            this.Controls.Add(this.PanelSpecialContainer);
            // 
            // txtInItemName
            // 
            this.txtInItemName.BackColor = System.Drawing.Color.Ivory;
            this.txtInItemName.ForeColor = System.Drawing.Color.White;
            this.txtInItemName.Location = new System.Drawing.Point(5, 41);
            this.txtInItemName.Name = "txtInItemName";
            this.netResize1.SetResizeTextBoxMultiline(this.txtInItemName, false);
            this.txtInItemName.ReadOnly = true;
            this.txtInItemName.Size = new System.Drawing.Size(243, 20);
            this.txtInItemName.TabIndex = 6;
            this.txtInItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtClassName
            // 
            this.txtClassName.BackColor = System.Drawing.Color.Ivory;
            this.txtClassName.ForeColor = System.Drawing.Color.White;
            this.txtClassName.Location = new System.Drawing.Point(5, 66);
            this.txtClassName.Name = "txtClassName";
            this.netResize1.SetResizeTextBoxMultiline(this.txtClassName, false);
            this.txtClassName.ReadOnly = true;
            this.txtClassName.Size = new System.Drawing.Size(243, 20);
            this.txtClassName.TabIndex = 9;
            this.txtClassName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFItemName
            // 
            this.txtFItemName.BackColor = System.Drawing.Color.Ivory;
            this.txtFItemName.ForeColor = System.Drawing.Color.White;
            this.txtFItemName.Location = new System.Drawing.Point(5, 16);
            this.txtFItemName.Name = "txtFItemName";
            this.netResize1.SetResizeTextBoxMultiline(this.txtFItemName, false);
            this.txtFItemName.ReadOnly = true;
            this.txtFItemName.Size = new System.Drawing.Size(243, 20);
            this.txtFItemName.TabIndex = 3;
            this.txtFItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCustName
            // 
            this.txtCustName.BackColor = System.Drawing.Color.Ivory;
            this.txtCustName.ForeColor = System.Drawing.Color.White;
            this.txtCustName.Location = new System.Drawing.Point(5, 91);
            this.txtCustName.Name = "txtCustName";
            this.netResize1.SetResizeTextBoxMultiline(this.txtCustName, false);
            this.txtCustName.ReadOnly = true;
            this.txtCustName.Size = new System.Drawing.Size(243, 20);
            this.txtCustName.TabIndex = 12;
            this.txtCustName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFItemNo
            // 
            this.txtFItemNo.BackColor = System.Drawing.Color.White;
            this.txtFItemNo.Location = new System.Drawing.Point(281, 16);
            this.txtFItemNo.Name = "txtFItemNo";
            this.netResize1.SetResizeTextBoxMultiline(this.txtFItemNo, false);
            this.txtFItemNo.ReadOnly = true;
            this.txtFItemNo.Size = new System.Drawing.Size(79, 20);
            this.txtFItemNo.TabIndex = 1;
            this.txtFItemNo.Tag = " T_Items.Itm_No ";
            this.txtFItemNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtInItemNo
            // 
            this.txtInItemNo.BackColor = System.Drawing.Color.White;
            this.txtInItemNo.Location = new System.Drawing.Point(281, 41);
            this.txtInItemNo.Name = "txtInItemNo";
            this.netResize1.SetResizeTextBoxMultiline(this.txtInItemNo, false);
            this.txtInItemNo.ReadOnly = true;
            this.txtInItemNo.Size = new System.Drawing.Size(79, 20);
            this.txtInItemNo.TabIndex = 4;
            this.txtInItemNo.Tag = " T_Items.Itm_No ";
            this.txtInItemNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtClassNo
            // 
            this.txtClassNo.BackColor = System.Drawing.Color.White;
            this.txtClassNo.Location = new System.Drawing.Point(281, 66);
            this.txtClassNo.Name = "txtClassNo";
            this.netResize1.SetResizeTextBoxMultiline(this.txtClassNo, false);
            this.txtClassNo.ReadOnly = true;
            this.txtClassNo.Size = new System.Drawing.Size(79, 20);
            this.txtClassNo.TabIndex = 7;
            this.txtClassNo.Tag = " T_CATEGORY.CAT_ID ";
            this.txtClassNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCustNo
            // 
            this.txtCustNo.BackColor = System.Drawing.Color.White;
            this.txtCustNo.Location = new System.Drawing.Point(281, 91);
            this.txtCustNo.Name = "txtCustNo";
            this.netResize1.SetResizeTextBoxMultiline(this.txtCustNo, false);
            this.txtCustNo.ReadOnly = true;
            this.txtCustNo.Size = new System.Drawing.Size(79, 20);
            this.txtCustNo.TabIndex = 10;
            this.txtCustNo.Tag = " T_INVHED.CusVenNo ";
            this.txtCustNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ButExit
            // 
            this.ButExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButExit.Checked = true;
            this.ButExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ButExit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButExit.Location = new System.Drawing.Point(7, 120);
            this.ButExit.Name = "ButExit";
            this.ButExit.Size = new System.Drawing.Size(207, 33);
            this.ButExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButExit.Symbol = "";
            this.ButExit.SymbolSize = 16F;
            this.ButExit.TabIndex = 17;
            this.ButExit.Text = "خـــروج";
            this.ButExit.TextColor = System.Drawing.Color.Black;
            this.ButExit.Click += new System.EventHandler(this.ButExit_Click);
            // 
            // ButOk
            // 
            this.ButOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButOk.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.ButOk.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButOk.Location = new System.Drawing.Point(220, 120);
            this.ButOk.Name = "ButOk";
            this.ButOk.Size = new System.Drawing.Size(207, 33);
            this.ButOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButOk.Symbol = "";
            this.ButOk.SymbolSize = 16F;
            this.ButOk.TabIndex = 16;
            this.ButOk.Text = "طبـــاعة";
            this.ButOk.TextColor = System.Drawing.Color.White;
            this.ButOk.Click += new System.EventHandler(this.ButOk_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(365, 70);
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
            this.label6.Location = new System.Drawing.Point(365, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 1119;
            this.label6.Text = "إلى صنف :";
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
            this.ribbonBar1.Controls.Add(this.label8);
            this.ribbonBar1.Controls.Add(this.label5);
            this.ribbonBar1.Controls.Add(this.txtInItemName);
            this.ribbonBar1.Controls.Add(this.txtClassName);
            this.ribbonBar1.Controls.Add(this.txtFItemName);
            this.ribbonBar1.Controls.Add(this.txtCustName);
            this.ribbonBar1.Controls.Add(this.txtFItemNo);
            this.ribbonBar1.Controls.Add(this.txtInItemNo);
            this.ribbonBar1.Controls.Add(this.txtClassNo);
            this.ribbonBar1.Controls.Add(this.txtCustNo);
            this.ribbonBar1.Controls.Add(this.ButExit);
            this.ribbonBar1.Controls.Add(this.ButOk);
            this.ribbonBar1.Controls.Add(this.label7);
            this.ribbonBar1.Controls.Add(this.label6);
            this.ribbonBar1.Controls.Add(this.button_SrchCustNo);
            this.ribbonBar1.Controls.Add(this.button_SrchClassNo);
            this.ribbonBar1.Controls.Add(this.button_SrchItemTo);
            this.ribbonBar1.Controls.Add(this.button_SrchItemFrom);
            this.ribbonBar1.Controls.Add(this.FlexField);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(433, 180);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 1101;
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(365, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 1117;
            this.label8.Text = "العميــــــل :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(365, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 1118;
            this.label5.Text = "من صنف :";
            // 
            // button_SrchCustNo
            // 
            this.button_SrchCustNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchCustNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCustNo.Location = new System.Drawing.Point(251, 91);
            this.button_SrchCustNo.Name = "button_SrchCustNo";
            this.button_SrchCustNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchCustNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCustNo.Symbol = "";
            this.button_SrchCustNo.SymbolSize = 12F;
            this.button_SrchCustNo.TabIndex = 11;
            this.button_SrchCustNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCustNo.Click += new System.EventHandler(this.button_SrchCustNo_Click);
            // 
            // button_SrchClassNo
            // 
            this.button_SrchClassNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchClassNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchClassNo.Location = new System.Drawing.Point(251, 66);
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
            this.button_SrchItemTo.Location = new System.Drawing.Point(251, 41);
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
            this.button_SrchItemFrom.Location = new System.Drawing.Point(251, 16);
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
            // FRItemsDataMoreSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 180);
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = (InvAcc.Properties.Resources.favicon);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FRItemsDataMoreSale";
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FRItemsData_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.ribbonBar1.ResumeLayout(false);
            this.ribbonBar1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlexField)).EndInit();
            this.Icon = (InvAcc.Properties.Resources.favicon);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.ResumeLayout(false);
        }
        public FRItemsDataMoreSale()
        {
            InitializeComponent();
            _User = dbc.StockUser(VarGeneral.UserNumber);
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                ButExit.Text = "خــــروج Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "طبـــاعة F5" : "عــــرض F5");
                label5.Text = "من صنف :";
                label6.Text = "إلى صنف :";
                label7.Text = "التصنيـــف :";
                label8.Text = "العميــــــل :";
                Text = "الأصناف الأكثر مبيعا\u064e";
            }
            else
            {
                ButExit.Text = "Exit Esc";
                ButOk.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "Print F5" : "Show F5");
                label5.Text = "From Item :";
                label6.Text = "To Item :";
                label7.Text = "Category :";
                label8.Text = "Customers :";
                Text = "Best Selling Items";
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRItemsDataMoreSale));
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
            RepDef();
            if (File.Exists(Application.StartupPath + "\\Script\\SecriptWaterPackages.dll"))
            {
                label8.Text = ((LangArEn == 0) ? "السائـق :" : "Driver Acc :");
            }
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FRItemsDataMoreSale));
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
            RepDef();
        }
        private void RepDef()
        {
            for (int iiCnt = 1; iiCnt < FlexField.Rows.Count; iiCnt++)
            {
                FlexField.SetData(iiCnt, 0, 1);
            }
        }
        private string BuildRuleList()
        {
            HijriGregDates dateFormatter = new HijriGregDates();
            string Rule = "Where 1 = 1 " + FlexField.Tag;
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
            if (!string.IsNullOrEmpty(txtCustNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtCustNo.Tag, " = ", txtCustNo.Text.Trim());
            }
            if (!string.IsNullOrEmpty(txtClassNo.Text))
            {
                object obj = Rule;
                Rule = string.Concat(obj, " and ", txtClassNo.Tag, " = ", txtClassNo.Text.Trim());
            }
            return Rule + " and T_Items.ItmTyp != 2 ";
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            try
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Items LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID INNER JOIN T_INVDET ON T_Items.Itm_No = T_INVDET.ItmNo INNER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID Left Join T_SYSSETTING ON T_Items.CompanyID = T_SYSSETTING.SYSSETTING_ID";
                string Fields = "T_Items.Itm_ID, T_Items.Itm_No, T_Items.ItmCat, " + ((LangArEn == 0) ? " T_Items.Arb_Des as itemNm" : " T_Items.Eng_Des as itemNm ") + " ," + ((LangArEn == 0) ? " T_CATEGORY.Arb_Des as CategoyNm" : " T_CATEGORY.Eng_Des as CategoyNm ") + ", T_Items.StartCost, T_Items.AvrageCost, T_Items.LastCost, T_Items.Price1, \r\n                                                                                  T_Items.Price3, T_Items.Price2, T_Items.Price5, T_Items.Price4, T_Items.Price6, T_Items.Unit1, T_Items.Pack1, T_Items.Unit2, T_Items.UntPri2, T_Items.UntPri1, \r\n                                                                                  T_Items.Pack2, T_Items.Unit3, T_Items.Pack3, T_Items.Unit4, T_Items.UntPri3, T_Items.UntPri4, T_Items.Pack4, T_Items.Unit5, T_Items.UntPri5, T_Items.Pack5, \r\n                                                                                  T_Items.DefultUnit, T_Items.DefultVendor, T_Items.OpenQty, T_Items.QtyLvl, T_Items.ItmLoc, T_Items.BarCod1, T_Items.BarCod2, T_Items.BarCod3, \r\n                                                                                  T_Items.BarCod4, T_Items.BarCod5, T_Items.Lot, T_Items.LrnExp, T_Items.DMY, T_Items.ItmTyp, T_Items.DefPack, T_Items.ItmImg, \r\n                                                                                  T_Items.InvSaleStoped, T_Items.InvPaymentStoped, T_Items.InvPaymentReturnStoped, T_Items.FirstCost, T_Items.CompanyID, T_Items.InvSaleReturnStoped, \r\n                                                                                  T_Items.SerialKey,sum(RealQty) as QtyMax";
                _RepShow.Rule = BuildRuleList() + " Group By T_Items.Itm_ID, T_Items.Itm_No, T_Items.ItmCat, T_Items.Arb_Des, T_Items.Eng_Des, T_Items.StartCost, T_Items.AvrageCost, T_Items.LastCost, T_Items.Price1, \r\n                                                                                  T_Items.Price3, T_Items.Price2, T_Items.Price5, T_Items.Price4, T_Items.Price6, T_Items.Unit1, T_Items.Pack1, T_Items.Unit2, T_Items.UntPri2, T_Items.UntPri1, \r\n                                                                                  T_Items.Pack2, T_Items.Unit3, T_Items.Pack3, T_Items.Unit4, T_Items.UntPri3, T_Items.UntPri4, T_Items.Pack4, T_Items.Unit5, T_Items.UntPri5, T_Items.Pack5, \r\n                                                                                  T_Items.DefultUnit, T_Items.DefultVendor, T_Items.OpenQty, T_Items.QtyLvl, T_Items.ItmLoc, T_Items.BarCod1, T_Items.BarCod2, T_Items.BarCod3, \r\n                                                                                  T_Items.BarCod4, T_Items.BarCod5, T_Items.Lot, T_Items.QtyMax, T_Items.LrnExp, T_Items.DMY, T_Items.ItmTyp, T_Items.DefPack, T_Items.ItmImg, \r\n                                                                                  T_Items.InvSaleStoped, T_Items.InvPaymentStoped, T_Items.InvPaymentReturnStoped, T_Items.FirstCost, T_Items.CompanyID, T_Items.InvSaleReturnStoped, \r\n                                                                                  T_Items.SerialKey,T_CATEGORY.Arb_Des,T_CATEGORY.Eng_Des \r\n                                                                                  order by QtyMax desc";
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
                    VarGeneral.IsGeneralUsed = true;
                    FrmReportsViewer frm = new FrmReportsViewer();
                    frm.Repvalue = "ItemsDataBestSales";



                    frm.Tag = LangArEn;
                    frm.Repvalue = "ItemsDataBestSales";
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
        private void button_SrchItemFrom_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("Itm_No", new ColumnDictinary("رقم الصنف", "Item No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, string.Empty));
            columns_Names_visible.Add("StartCost", new ColumnDictinary("التكلفةالافتتاحية", "Start Cost", ifDefault: false, string.Empty));
            columns_Names_visible.Add("AvrageCost", new ColumnDictinary("متوسط التكلفة", "Average Cost", ifDefault: false, string.Empty));
            columns_Names_visible.Add("LastCost", new ColumnDictinary("آخر تكلفة", "Last Cost", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Arb_Des_Cat", new ColumnDictinary("الاسم العربي لمجموعة الصنف", "CATEGORY Arabic Name", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Eng_Des_Cat", new ColumnDictinary("الاسم الانجليزي لمجموعة الصنف", "CATEGORY English Name", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_Items";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                txtFItemNo.Text = frm.Serach_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
                txtFItemNo.Text = string.Empty;
                txtFItemName.Text = string.Empty;
            }
        }
        private void button_SrchItemTo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("Itm_No", new ColumnDictinary("رقم الصنف", "Item No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: false, string.Empty));
            columns_Names_visible.Add("StartCost", new ColumnDictinary("التكلفةالافتتاحية", "Start Cost", ifDefault: false, string.Empty));
            columns_Names_visible.Add("AvrageCost", new ColumnDictinary("متوسط التكلفة", "Average Cost", ifDefault: false, string.Empty));
            columns_Names_visible.Add("LastCost", new ColumnDictinary("آخر تكلفة", "Last Cost", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Arb_Des_Cat", new ColumnDictinary("الاسم العربي لمجموعة الصنف", "CATEGORY Arabic Name", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Eng_Des_Cat", new ColumnDictinary("الاسم الانجليزي لمجموعة الصنف", "CATEGORY English Name", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_Items";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                txtInItemNo.Text = frm.Serach_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
                txtInItemNo.Text = string.Empty;
                txtInItemName.Text = string.Empty;
            }
        }
        private void button_SrchClassNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("CAT_No", new ColumnDictinary("الرمـــز", "CATEGORY No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_CATEGORY";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                txtClassNo.Text = db.StockCat(frm.Serach_No).CAT_ID.ToString();
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
                txtClassNo.Text = string.Empty;
                txtClassName.Text = string.Empty;
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
        private void button_SrchCustNo_Click(object sender, EventArgs e)
        {
            columns_Names_visible.Clear();
            columns_Names_visible.Add("AccDef_No", new ColumnDictinary("الرقم ", " No", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Arb_Des", new ColumnDictinary("الاسم عربي", "Arabic Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("Eng_Des", new ColumnDictinary("الاسم الانجليزي", "English Name", ifDefault: true, string.Empty));
            columns_Names_visible.Add("AccDef_ID", new ColumnDictinary(" ", " ", ifDefault: false, string.Empty));
            columns_Names_visible.Add("Mobile", new ColumnDictinary("الجوال", "Mobile", ifDefault: false, string.Empty));
            columns_Names_visible.Add("TaxNo", new ColumnDictinary("الرقم الضريبي", "Tax No", ifDefault: false, string.Empty));
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, string.Empty));
            }
            VarGeneral.SFrmTyp = "T_AccDef2";
            VarGeneral.AccTyp = 4;
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != string.Empty)
            {
                txtCustNo.Text = db.StockAccDefs(int.Parse(frm.Serach_No)).AccDef_No;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
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
                txtCustNo.Text = string.Empty;
                txtCustName.Text = string.Empty;
            }
        }
    }
}
