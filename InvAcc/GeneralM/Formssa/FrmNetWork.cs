using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using InputKey;
using InvAcc.GeneralM;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmNetWork : Form
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
        private Label label1;
        private LabelX labelX1;
        private ButtonX buttonX_Close;
        private SwitchButton switchButton_Sts;
        private ButtonX button_Exit;
        private RegistryKey hKeyNeew = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", writable: true);
        private RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
        private int vSysType = 0;
        private string vSysTypName = "";
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
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Exit = new DevComponents.DotNetBar.ButtonX();
            this.switchButton_Sts = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.label1 = new System.Windows.Forms.Label();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.buttonX_Close = new DevComponents.DotNetBar.ButtonX();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.PanelSpecialContainer.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelSpecialContainer
            // 
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar1);
            this.PanelSpecialContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSpecialContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelSpecialContainer.Name = "PanelSpecialContainer";
            this.PanelSpecialContainer.Size = new System.Drawing.Size(504, 223);
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
            this.ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.panel1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(504, 223);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 870;
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
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button_Exit);
            this.panel1.Controls.Add(this.switchButton_Sts);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Controls.Add(this.buttonX_Close);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(507, 208);
            this.panel1.TabIndex = 858;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button_Exit
            // 
            this.button_Exit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_Exit.Checked = true;
            this.button_Exit.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.button_Exit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button_Exit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.button_Exit.Location = new System.Drawing.Point(131, 147);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(74, 39);
            this.button_Exit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_Exit.Symbol = "";
            this.button_Exit.TabIndex = 93;
            this.button_Exit.Text = "خروج";
            this.button_Exit.TextColor = System.Drawing.Color.Maroon;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // switchButton_Sts
            // 
            // 
            // 
            // 
            this.switchButton_Sts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_Sts.Location = new System.Drawing.Point(131, 92);
            this.switchButton_Sts.Name = "switchButton_Sts";
            this.switchButton_Sts.Size = new System.Drawing.Size(226, 32);
            this.switchButton_Sts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_Sts.TabIndex = 92;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(146, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 13);
            this.label1.TabIndex = 90;
            this.label1.Text = "خاصية ربط الشبكة بين نسخ البرنامج";
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.SteelBlue;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX1.Font = new System.Drawing.Font("Tahoma", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labelX1.ForeColor = System.Drawing.Color.White;
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(505, 26);
            this.labelX1.TabIndex = 88;
            this.labelX1.Text = "معالج التجكم في الخصائص الإضافية";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelX1.Click += new System.EventHandler(this.labelX1_Click);
            // 
            // buttonX_Close
            // 
            this.buttonX_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX_Close.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonX_Close.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.buttonX_Close.Location = new System.Drawing.Point(208, 147);
            this.buttonX_Close.Name = "buttonX_Close";
            this.buttonX_Close.Size = new System.Drawing.Size(149, 39);
            this.buttonX_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Close.Symbol = "";
            this.buttonX_Close.TabIndex = 3;
            this.buttonX_Close.Text = "خروج مع الحفظ";
            this.buttonX_Close.TextColor = System.Drawing.Color.White;
            this.buttonX_Close.Click += new System.EventHandler(this.buttonX_Close_Click);
            // 
            // netResize1
            // 
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            // 
            // FrmNetWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(504, 223);
            this.ControlBox = false;
            this.Controls.Add(this.PanelSpecialContainer);
            this.Icon = global::InvAcc.Properties.Resources.favicon;
            this.KeyPreview = true;
            this.Name = "FrmNetWork";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmNetWork_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmNetWork_KeyDown);
            this.PanelSpecialContainer.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);

        }
        public FrmNetWork(int vType, string vSub)
        {
            InitializeComponent();
            label1.Text = vSub;
            try
            {
                if (hKey != null)
                {
                    try
                    {
                        object q = hKey.GetValue("vNW");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vNW");
                            hKey.SetValue("vNW", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vNW");
                        hKey.SetValue("vNW", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vNW_Electa");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vNW_Electa");
                            hKey.SetValue("vNW_Electa", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vNW_Electa");
                        hKey.SetValue("vNW_Electa", "0");
                    }
                    try
                    {
                        object q = hKeyNeew.GetValue("vNW_New");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKeyNeew.CreateSubKey("vNW_New");
                            hKeyNeew.SetValue("vNW_New", "0");
                        }
                    }
                    catch
                    {
                        hKeyNeew.CreateSubKey("vNW_New");
                        hKeyNeew.SetValue("vNW_New", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vSt");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vSt");
                            hKey.SetValue("vSt", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vSt");
                        hKey.SetValue("vSt", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vSt_Electa");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vSt_Electa");
                            hKey.SetValue("vSt_Electa", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vSt_Electa");
                        hKey.SetValue("vSt_Electa", "0");
                    }
                    try
                    {
                        object q = hKeyNeew.GetValue("vSt_New");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKeyNeew.CreateSubKey("vSt_New");
                            hKeyNeew.SetValue("vSt_New", "0");
                        }
                    }
                    catch
                    {
                        hKeyNeew.CreateSubKey("vSt_New");
                        hKeyNeew.SetValue("vSt_New", "0");
                    }
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
                    try
                    {
                        object q = hKey.GetValue("vCoCe_Electa");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vCoCe_Electa");
                            hKey.SetValue("vCoCe_Electa", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vCoCe_Electa");
                        hKey.SetValue("vCoCe_Electa", "0");
                    }
                    try
                    {
                        object q = hKeyNeew.GetValue("vCoCe_New");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKeyNeew.CreateSubKey("vCoCe_New");
                            hKeyNeew.SetValue("vCoCe_New", "0");
                        }
                    }
                    catch
                    {
                        hKeyNeew.CreateSubKey("vCoCe_New");
                        hKeyNeew.SetValue("vCoCe_New", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vBa");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vBa");
                            hKey.SetValue("vBa", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vBa");
                        hKey.SetValue("vBa", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vBa_Electa");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vBa_Electa");
                            hKey.SetValue("vBa_Electa", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vBa_Electa");
                        hKey.SetValue("vBa_Electa", "0");
                    }
                    try
                    {
                        object q = hKeyNeew.GetValue("vBa_New");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKeyNeew.CreateSubKey("vBa_New");
                            hKeyNeew.SetValue("vBa_New", "0");
                        }
                    }
                    catch
                    {
                        hKeyNeew.CreateSubKey("vBa_New");
                        hKeyNeew.SetValue("vBa_New", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vCsh");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vCsh");
                            hKey.SetValue("vCsh", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vCsh");
                        hKey.SetValue("vCsh", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vCsh_Electa");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vCsh_Electa");
                            hKey.SetValue("vCsh_Electa", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vCsh_Electa");
                        hKey.SetValue("vCsh_Electa", "0");
                    }
                    try
                    {
                        object q = hKeyNeew.GetValue("vCsh_New");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKeyNeew.CreateSubKey("vCsh_New");
                            hKeyNeew.SetValue("vCsh_New", "0");
                        }
                    }
                    catch
                    {
                        hKeyNeew.CreateSubKey("vCsh_New");
                        hKeyNeew.SetValue("vCsh_New", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vBkPeap");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vBkPeap");
                            hKey.SetValue("vBkPeap", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vBkPeap");
                        hKey.SetValue("vBkPeap", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vBkPeap_Electa");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vBkPeap_Electa");
                            hKey.SetValue("vBkPeap_Electa", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vBkPeap_Electa");
                        hKey.SetValue("vBkPeap_Electa", "0");
                    }
                    try
                    {
                        object q = hKeyNeew.GetValue("vBkPeap_New");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKeyNeew.CreateSubKey("vBkPeap_New");
                            hKeyNeew.SetValue("vBkPeap_New", "0");
                        }
                    }
                    catch
                    {
                        hKeyNeew.CreateSubKey("vBkPeap_New");
                        hKeyNeew.SetValue("vBkPeap_New", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vBr");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vBr");
                            hKey.SetValue("vBr", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vBr");
                        hKey.SetValue("vBr", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vBr_Electa");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vBr_Electa");
                            hKey.SetValue("vBr_Electa", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vBr_Electa");
                        hKey.SetValue("vBr_Electa", "0");
                    }
                    try
                    {
                        object q = hKeyNeew.GetValue("vBr_New");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKeyNeew.CreateSubKey("vBr_New");
                            hKeyNeew.SetValue("vBr_New", "0");
                        }
                    }
                    catch
                    {
                        hKeyNeew.CreateSubKey("vBr_New");
                        hKeyNeew.SetValue("vBr_New", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vDB");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vDB");
                            hKey.SetValue("vDB", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vDB");
                        hKey.SetValue("vDB", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vDB_Electa");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vDB_Electa");
                            hKey.SetValue("vDB_Electa", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vDB_Electa");
                        hKey.SetValue("vDB_Electa", "0");
                    }
                    try
                    {
                        object q = hKeyNeew.GetValue("vDB_New");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKeyNeew.CreateSubKey("vDB_New");
                            hKeyNeew.SetValue("vDB_New", "0");
                        }
                    }
                    catch
                    {
                        hKeyNeew.CreateSubKey("vDB_New");
                        hKeyNeew.SetValue("vDB_New", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vPOS");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vPOS");
                            hKey.SetValue("vPOS", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vPOS");
                        hKey.SetValue("vPOS", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vPOS_Electa");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vPOS_Electa");
                            hKey.SetValue("vPOS_Electa", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vPOS_Electa");
                        hKey.SetValue("vPOS_Electa", "0");
                    }
                    try
                    {
                        object q = hKeyNeew.GetValue("vPOS_New");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKeyNeew.CreateSubKey("vPOS_New");
                            hKeyNeew.SetValue("vPOS_New", "0");
                        }
                    }
                    catch
                    {
                        hKeyNeew.CreateSubKey("vPOS_New");
                        hKeyNeew.SetValue("vPOS_New", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vActiv");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vActiv");
                            hKey.SetValue("vActiv", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vActiv");
                        hKey.SetValue("vActiv", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vActiv_Electa");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vActiv_Electa");
                            hKey.SetValue("vActiv_Electa", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vActiv_Electa");
                        hKey.SetValue("vActiv_Electa", "0");
                    }
                    try
                    {
                        object q = hKeyNeew.GetValue("vActiv_New");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKeyNeew.CreateSubKey("vActiv_New");
                            hKeyNeew.SetValue("vActiv_New", "0");
                        }
                    }
                    catch
                    {
                        hKeyNeew.CreateSubKey("vActiv_New");
                        hKeyNeew.SetValue("vActiv_New", "0");
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
                    try
                    {
                        object q = hKey.GetValue("vRemotly_Electa");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vRemotly_Electa");
                            hKey.SetValue("vRemotly_Electa", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vRemotly_Electa");
                        hKey.SetValue("vRemotly_Electa", "0");
                    }
                    try
                    {
                        object q = hKeyNeew.GetValue("vRemotly_New");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKeyNeew.CreateSubKey("vRemotly_New");
                            hKeyNeew.SetValue("vRemotly_New", "0");
                        }
                    }
                    catch
                    {
                        hKeyNeew.CreateSubKey("vRemotly_New");
                        hKeyNeew.SetValue("vRemotly_New", "0");
                    }
                    vSysType = vType;
                }
                else
                {
                    buttonX_Close_Click(null, null);
                }
            }
            catch
            {
                Environment.Exit(0);
            }
        }
        private void FrmNetWork_Load(object sender, EventArgs e)
        {
            if (vSysType == 0)
            {
                vSysTypName = "vNW";
            }
            else if (vSysType == 1)
            {
                vSysTypName = "vSt";
            }
            else if (vSysType == 2)
            {
                vSysTypName = "vCoCe";
            }
            else if (vSysType == 3)
            {
                vSysTypName = "vBa";
            }
            else if (vSysType == 4)
            {
                vSysTypName = "vCsh";
            }
            else if (vSysType == 5)
            {
                vSysTypName = "vBkPeap";
            }
            else if (vSysType == 6)
            {
                vSysTypName = "vBr";
            }
            else if (vSysType == 7)
            {
                vSysTypName = "vDB";
            }
            else if (vSysType == 8)
            {
                vSysTypName = "vPOS";
            }
            else if (vSysType == 9)
            {
                hKey.SetValue(vSysTypName, "1");
                hKey.SetValue(vSysTypName + "_Electa", "1");
                hKeyNeew.SetValue(vSysTypName + "_New", "1");
                vSysTypName = "vActiv";
            }
            else if (vSysType == 10)
            {
                vSysTypName = "vRemotly";
            }
            else if (vSysType == 13)
            {
                vSysTypName = "vMixWaiters";
            }
            else if (vSysType == 14)
            {
                vSysTypName = "vSM";
            }
            if (vSysType == 11)
            {
                return;
            }
            if (vSysType == 12)
            {
                buttonX_Close.Text = "ادخل اسماء اليوزرات";
                switchButton_Sts.Visible = false;
                return;
            }
            try
            {
                if (hKey != null)
                {
                    try
                    {
                        object q = hKey.GetValue(vSysTypName);
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey(vSysTypName);
                            hKey.SetValue(vSysTypName, "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey(vSysTypName);
                        hKey.SetValue(vSysTypName, "0");
                    }
                    try
                    {
                        object q = hKey.GetValue(vSysTypName + "_Electa");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey(vSysTypName + "_Electa");
                            hKey.SetValue(vSysTypName + "_Electa", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey(vSysTypName + "_Electa");
                        hKey.SetValue(vSysTypName + "_Electa", "0");
                    }
                    try
                    {
                        object q = hKeyNeew.GetValue(vSysTypName + "_New");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKeyNeew.CreateSubKey(vSysTypName + "_New");
                            hKeyNeew.SetValue(vSysTypName + "_New", "0");
                        }
                    }
                    catch
                    {
                        hKeyNeew.CreateSubKey(vSysTypName + "_New");
                        hKeyNeew.SetValue(vSysTypName + "_New", "0");
                    }
                }
                else
                {
                    buttonX_Close_Click(null, null);
                }
                long regval = long.Parse(hKey.GetValue(vSysTypName).ToString());
                if (regval == 1)
                {
                    switchButton_Sts.Value = true;
                }
                else
                {
                    switchButton_Sts.Value = false;
                }
            }
            catch
            {
                Environment.Exit(0);
            }
        }
        private void buttonX_Close_Click(object sender, EventArgs e)
        {
            if (vSysType == 11)
            {
                if (switchButton_Sts.Value)
                {
                    hKey.SetValue("Lev", "F");
                    hKey.SetValue("Typ", "2");
                    hKey.SetValue("vBackupELEC", "");
                }
            }
            else if (vSysType == 12)
            {
                try
                {
                    string vNewNo = InputDialog.mostrar("أدخل اسماء اليوزارات بينهم فاصلة : ", "الدعم الفني");
                    if (!string.IsNullOrEmpty(vNewNo.Trim()))
                    {
                        try
                        {
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                            File.Delete(Application.StartupPath + "\\systemfile.txt");
                        }
                        catch
                        {
                        }
                        TextWriter tw = File.CreateText(Application.StartupPath + "\\systemfile.txt");
                        tw.WriteLine(VarGeneral.Encrypt(vNewNo.Trim()));
                        tw.Close();
                    }
                }
                catch
                {
                }
            }
            else if (switchButton_Sts.Value)
            {
                hKey.SetValue(vSysTypName, "1");
                hKey.SetValue(vSysTypName + "_Electa", "1");
                hKeyNeew.SetValue(vSysTypName + "_New", "1");
            }
            else
            {
                hKey.SetValue(vSysTypName, "0");
                hKey.SetValue(vSysTypName + "_Electa", "0");
                hKeyNeew.SetValue(vSysTypName + "_New", "0");
            }
            string arguments = string.Empty;
            string[] args = Environment.GetCommandLineArgs();
            for (int i = 1; i < args.Length; i++)
            {
                arguments = arguments + args[i] + " ";
            }
            Application.ExitThread();
            Process.Start(Application.ExecutablePath, arguments);
        }
        private void FrmNetWork_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                buttonX_Close_Click(sender, e);
            }
        }
        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void labelX1_Click(object sender, EventArgs e)
        {
        }
    }
}
