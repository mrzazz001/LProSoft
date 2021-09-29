using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    partial class FrmLog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLog));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.switchButton_waiter = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.button_SrchUsrNo = new DevComponents.DotNetBar.ButtonX();
            this.button_Support = new DevComponents.DotNetBar.ButtonX();
            this.textBox_Pass = new System.Windows.Forms.TextBox();
            this.textBox_WaiterPass = new System.Windows.Forms.TextBox();
            this.comboBox_UserName = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboBox_Waiter = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.groupPanel_BoardNo = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.button_Space = new DevComponents.DotNetBar.ButtonX();
            this.button_0 = new DevComponents.DotNetBar.ButtonX();
            this.button_2 = new DevComponents.DotNetBar.ButtonX();
            this.button_1 = new DevComponents.DotNetBar.ButtonX();
            this.button_6 = new DevComponents.DotNetBar.ButtonX();
            this.button_5 = new DevComponents.DotNetBar.ButtonX();
            this.button_8 = new DevComponents.DotNetBar.ButtonX();
            this.button_7 = new DevComponents.DotNetBar.ButtonX();
            this.button_Bac = new DevComponents.DotNetBar.ButtonX();
            this.button_3 = new DevComponents.DotNetBar.ButtonX();
            this.button_4 = new DevComponents.DotNetBar.ButtonX();
            this.button_9 = new DevComponents.DotNetBar.ButtonX();
            this.button_KeyWords = new DevComponents.DotNetBar.ButtonX();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.okButton = new DevComponents.DotNetBar.ButtonX();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.labelCompanyName = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStrip_BackuElc = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip_InvSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_SndSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_Stocks = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_BarSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip_BarInvSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip_NetWork = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_CenterCost = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_RemoteDesctop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_Barcode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_Casheir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_BankPeaper = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_Branches = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_DataBase = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_Year = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip_RunSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_StopSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip_POS = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Norton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.SMS = new System.Windows.Forms.ToolStripMenuItem();
            this.نقلالبياناتمنالابسوفتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonX_EnterToSystem = new C1.Win.C1Input.C1Button();
            this.buttonItem_Exit = new C1.Win.C1Input.C1Button();
            this.label5 = new System.Windows.Forms.Label();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.groupPanel_BoardNo.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonX_EnterToSystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonItem_Exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(50)))), ((int)(((byte)(59)))));
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(1204, 222);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(21, 50);
            this.groupBox1.TabIndex = 900;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // switchButton_waiter
            // 
            // 
            // 
            // 
            this.switchButton_waiter.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.switchButton_waiter.Font = new System.Drawing.Font("Tahoma", 10F);
            this.switchButton_waiter.Location = new System.Drawing.Point(322, 423);
            this.switchButton_waiter.Name = "switchButton_waiter";
            this.switchButton_waiter.OffBackColor = System.Drawing.Color.Gainsboro;
            this.switchButton_waiter.OffText = "Basic -||- الأساسي   ";
            this.switchButton_waiter.OffTextColor = System.Drawing.Color.DimGray;
            this.switchButton_waiter.OnText = "Waiter version -||- نسخة النادل   ";
            this.switchButton_waiter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.switchButton_waiter.Size = new System.Drawing.Size(353, 24);
            this.switchButton_waiter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.switchButton_waiter.TabIndex = 1185;
            this.switchButton_waiter.Visible = false;
            this.switchButton_waiter.ValueChanged += new System.EventHandler(this.switchButton_waiter_ValueChanged);
            // 
            // button_SrchUsrNo
            // 
            this.button_SrchUsrNo.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.button_SrchUsrNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchUsrNo.Location = new System.Drawing.Point(316, 272);
            this.button_SrchUsrNo.Name = "button_SrchUsrNo";
            this.button_SrchUsrNo.Size = new System.Drawing.Size(32, 25);
            this.button_SrchUsrNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchUsrNo.Symbol = "";
            this.button_SrchUsrNo.SymbolSize = 12F;
            this.button_SrchUsrNo.TabIndex = 1184;
            this.button_SrchUsrNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchUsrNo.Click += new System.EventHandler(this.button_SrchUsrNo_Click);
            // 
            // button_Support
            // 
            this.button_Support.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_Support.AutoCheckOnClick = true;
            this.button_Support.AutoExpandOnClick = true;
            this.button_Support.BackColor = System.Drawing.Color.Transparent;
            this.button_Support.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.button_Support.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.button_Support.Location = new System.Drawing.Point(322, 241);
            this.button_Support.Name = "button_Support";
            this.button_Support.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button_Support.Size = new System.Drawing.Size(352, 28);
            this.button_Support.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_Support.SubItemsExpandWidth = 16;
            this.button_Support.Symbol = "";
            this.button_Support.SymbolSize = 22F;
            this.button_Support.TabIndex = 1183;
            this.button_Support.TabStop = false;
            this.button_Support.Text = "الدعم الفني - <font color=\"#8C8C8C\">Support</font>";
            this.button_Support.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button_Support.Tooltip = "NumberBoard | لوحة الأرقـــام";
            this.button_Support.Visible = false;
            this.button_Support.CheckedChanged += new System.EventHandler(this.button_Support_CheckedChanged);
            // 
            // textBox_Pass
            // 
            this.textBox_Pass.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.textBox_Pass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox_Pass.Location = new System.Drawing.Point(321, 320);
            this.textBox_Pass.MaxLength = 20;
            this.textBox_Pass.Name = "textBox_Pass";
            this.textBox_Pass.PasswordChar = '*';
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Pass, false);
            this.textBox_Pass.Size = new System.Drawing.Size(353, 25);
            this.textBox_Pass.TabIndex = 1;
            this.textBox_Pass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Pass.Click += new System.EventHandler(this.textBox_Pass_Click);
            this.textBox_Pass.Enter += new System.EventHandler(this.textBox_Pass_Enter);
            this.textBox_Pass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Pass_KeyPress);
            // 
            // textBox_WaiterPass
            // 
            this.textBox_WaiterPass.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.textBox_WaiterPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox_WaiterPass.Location = new System.Drawing.Point(321, 320);
            this.textBox_WaiterPass.MaxLength = 20;
            this.textBox_WaiterPass.Name = "textBox_WaiterPass";
            this.textBox_WaiterPass.PasswordChar = '*';
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_WaiterPass, false);
            this.textBox_WaiterPass.Size = new System.Drawing.Size(353, 25);
            this.textBox_WaiterPass.TabIndex = 5;
            this.textBox_WaiterPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_WaiterPass.Visible = false;
            this.textBox_WaiterPass.Click += new System.EventHandler(this.textBox_WaiterPass_Click);
            this.textBox_WaiterPass.Enter += new System.EventHandler(this.textBox_WaiterPass_Enter);
            // 
            // comboBox_UserName
            // 
            this.comboBox_UserName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox_UserName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_UserName.DisabledBackColor = System.Drawing.Color.Red;
            this.comboBox_UserName.DisabledForeColor = System.Drawing.Color.CornflowerBlue;
            this.comboBox_UserName.DisplayMember = "Text";
            this.comboBox_UserName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_UserName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_UserName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_UserName.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.comboBox_UserName.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.comboBox_UserName.FormattingEnabled = true;
            this.comboBox_UserName.ItemHeight = 19;
            this.comboBox_UserName.Location = new System.Drawing.Point(350, 272);
            this.comboBox_UserName.Name = "comboBox_UserName";
            this.comboBox_UserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox_UserName.Size = new System.Drawing.Size(324, 25);
            this.comboBox_UserName.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.comboBox_UserName.TabIndex = 0;
            this.comboBox_UserName.SelectionChangeCommitted += new System.EventHandler(this.comboBox_UserName_SelectionChangeCommitted);
            this.comboBox_UserName.SelectedValueChanged += new System.EventHandler(this.comboBox_UserName_SelectedValueChanged);
            this.comboBox_UserName.VisibleChanged += new System.EventHandler(this.comboBox_UserName_VisibleChanged);
            this.comboBox_UserName.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.comboBox_UserName_PreviewKeyDown);
            this.comboBox_UserName.Validated += new System.EventHandler(this.comboBox_UserName_Validated);
            // 
            // comboBox_Waiter
            // 
            this.comboBox_Waiter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox_Waiter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Waiter.DisabledBackColor = System.Drawing.Color.Red;
            this.comboBox_Waiter.DisabledForeColor = System.Drawing.Color.CornflowerBlue;
            this.comboBox_Waiter.DisplayMember = "Text";
            this.comboBox_Waiter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_Waiter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Waiter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_Waiter.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.comboBox_Waiter.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.comboBox_Waiter.FormattingEnabled = true;
            this.comboBox_Waiter.ItemHeight = 19;
            this.comboBox_Waiter.Location = new System.Drawing.Point(350, 272);
            this.comboBox_Waiter.Name = "comboBox_Waiter";
            this.comboBox_Waiter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox_Waiter.Size = new System.Drawing.Size(324, 25);
            this.comboBox_Waiter.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.comboBox_Waiter.TabIndex = 4;
            this.comboBox_Waiter.Visible = false;
            // 
            // groupPanel_BoardNo
            // 
            this.groupPanel_BoardNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupPanel_BoardNo.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel_BoardNo.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel_BoardNo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel_BoardNo.Controls.Add(this.button_Space);
            this.groupPanel_BoardNo.Controls.Add(this.button_0);
            this.groupPanel_BoardNo.Controls.Add(this.button_2);
            this.groupPanel_BoardNo.Controls.Add(this.button_1);
            this.groupPanel_BoardNo.Controls.Add(this.button_6);
            this.groupPanel_BoardNo.Controls.Add(this.button_5);
            this.groupPanel_BoardNo.Controls.Add(this.button_8);
            this.groupPanel_BoardNo.Controls.Add(this.button_7);
            this.groupPanel_BoardNo.Controls.Add(this.button_Bac);
            this.groupPanel_BoardNo.Controls.Add(this.button_3);
            this.groupPanel_BoardNo.Controls.Add(this.button_4);
            this.groupPanel_BoardNo.Controls.Add(this.button_9);
            this.groupPanel_BoardNo.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel_BoardNo.Location = new System.Drawing.Point(782, 235);
            this.groupPanel_BoardNo.Name = "groupPanel_BoardNo";
            this.groupPanel_BoardNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupPanel_BoardNo.Size = new System.Drawing.Size(262, 219);
            // 
            // 
            // 
            this.groupPanel_BoardNo.Style.BackColorGradientAngle = 90;
            this.groupPanel_BoardNo.Style.BorderBottomWidth = 1;
            this.groupPanel_BoardNo.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel_BoardNo.Style.BorderLeftWidth = 1;
            this.groupPanel_BoardNo.Style.BorderRightWidth = 1;
            this.groupPanel_BoardNo.Style.BorderTopWidth = 1;
            this.groupPanel_BoardNo.Style.CornerDiameter = 4;
            this.groupPanel_BoardNo.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel_BoardNo.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel_BoardNo.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel_BoardNo.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel_BoardNo.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel_BoardNo.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel_BoardNo.TabIndex = 1181;
            this.groupPanel_BoardNo.Visible = false;
            // 
            // button_Space
            // 
            this.button_Space.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_Space.Checked = true;
            this.button_Space.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.button_Space.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.button_Space.Location = new System.Drawing.Point(1, 117);
            this.button_Space.Name = "button_Space";
            this.button_Space.Size = new System.Drawing.Size(125, 57);
            this.button_Space.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_Space.TabIndex = 13;
            this.button_Space.Text = "Clear | مسج";
            this.button_Space.Click += new System.EventHandler(this.button_Space_Click);
            // 
            // button_0
            // 
            this.button_0.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_0.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.button_0.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_0.Location = new System.Drawing.Point(127, 117);
            this.button_0.Name = "button_0";
            this.button_0.Size = new System.Drawing.Size(63, 57);
            this.button_0.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_0.TabIndex = 12;
            this.button_0.Text = "0";
            this.button_0.Click += new System.EventHandler(this.button_0_Click);
            // 
            // button_2
            // 
            this.button_2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_2.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.button_2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_2.Location = new System.Drawing.Point(127, 1);
            this.button_2.Name = "button_2";
            this.button_2.Size = new System.Drawing.Size(63, 57);
            this.button_2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_2.TabIndex = 10;
            this.button_2.Text = "2";
            this.button_2.Click += new System.EventHandler(this.button_2_Click);
            // 
            // button_1
            // 
            this.button_1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_1.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.button_1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_1.Location = new System.Drawing.Point(190, 1);
            this.button_1.Name = "button_1";
            this.button_1.Size = new System.Drawing.Size(63, 57);
            this.button_1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_1.TabIndex = 9;
            this.button_1.Text = "1";
            this.button_1.Click += new System.EventHandler(this.button_1_Click);
            // 
            // button_6
            // 
            this.button_6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_6.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.button_6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_6.Location = new System.Drawing.Point(127, 59);
            this.button_6.Name = "button_6";
            this.button_6.Size = new System.Drawing.Size(63, 57);
            this.button_6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_6.TabIndex = 8;
            this.button_6.Text = "6";
            this.button_6.Click += new System.EventHandler(this.button_6_Click);
            // 
            // button_5
            // 
            this.button_5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_5.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.button_5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_5.Location = new System.Drawing.Point(190, 59);
            this.button_5.Name = "button_5";
            this.button_5.Size = new System.Drawing.Size(63, 57);
            this.button_5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_5.TabIndex = 7;
            this.button_5.Text = "5";
            this.button_5.Click += new System.EventHandler(this.button_5_Click);
            // 
            // button_8
            // 
            this.button_8.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_8.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.button_8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_8.Location = new System.Drawing.Point(1, 59);
            this.button_8.Name = "button_8";
            this.button_8.Size = new System.Drawing.Size(63, 57);
            this.button_8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_8.TabIndex = 4;
            this.button_8.Text = "8";
            this.button_8.Click += new System.EventHandler(this.button_8_Click);
            // 
            // button_7
            // 
            this.button_7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_7.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.button_7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_7.Location = new System.Drawing.Point(64, 59);
            this.button_7.Name = "button_7";
            this.button_7.Size = new System.Drawing.Size(63, 57);
            this.button_7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_7.TabIndex = 3;
            this.button_7.Text = "7";
            this.button_7.Click += new System.EventHandler(this.button_7_Click);
            // 
            // button_Bac
            // 
            this.button_Bac.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_Bac.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.button_Bac.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.button_Bac.Location = new System.Drawing.Point(1, 178);
            this.button_Bac.Name = "button_Bac";
            this.button_Bac.Size = new System.Drawing.Size(252, 34);
            this.button_Bac.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_Bac.TabIndex = 0;
            this.button_Bac.Text = "إخفـاء  |  Hide";
            this.button_Bac.Click += new System.EventHandler(this.button_Bac_Click);
            // 
            // button_3
            // 
            this.button_3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_3.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.button_3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_3.Location = new System.Drawing.Point(64, 1);
            this.button_3.Name = "button_3";
            this.button_3.Size = new System.Drawing.Size(63, 57);
            this.button_3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_3.TabIndex = 11;
            this.button_3.Text = "3";
            this.button_3.Click += new System.EventHandler(this.button_3_Click);
            // 
            // button_4
            // 
            this.button_4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_4.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.button_4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_4.Location = new System.Drawing.Point(1, 1);
            this.button_4.Name = "button_4";
            this.button_4.Size = new System.Drawing.Size(63, 57);
            this.button_4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_4.TabIndex = 6;
            this.button_4.Text = "4";
            this.button_4.Click += new System.EventHandler(this.button_4_Click);
            // 
            // button_9
            // 
            this.button_9.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_9.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.button_9.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.button_9.Location = new System.Drawing.Point(190, 117);
            this.button_9.Name = "button_9";
            this.button_9.Size = new System.Drawing.Size(63, 57);
            this.button_9.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_9.TabIndex = 5;
            this.button_9.Text = "9";
            this.button_9.Click += new System.EventHandler(this.button_9_Click);
            // 
            // button_KeyWords
            // 
            this.button_KeyWords.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_KeyWords.AutoCheckOnClick = true;
            this.button_KeyWords.AutoExpandOnClick = true;
            this.button_KeyWords.BackColor = System.Drawing.Color.Transparent;
            this.button_KeyWords.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.button_KeyWords.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.button_KeyWords.Location = new System.Drawing.Point(889, 337);
            this.button_KeyWords.Name = "button_KeyWords";
            this.button_KeyWords.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button_KeyWords.Size = new System.Drawing.Size(62, 54);
            this.button_KeyWords.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_KeyWords.Symbol = "";
            this.button_KeyWords.SymbolSize = 36F;
            this.button_KeyWords.TabIndex = 1182;
            this.button_KeyWords.TabStop = false;
            this.button_KeyWords.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button_KeyWords.Tooltip = "NumberBoard | لوحة الأرقـــام";
            this.button_KeyWords.CheckedChanged += new System.EventHandler(this.button_KeyWords_CheckedChanged);
            this.button_KeyWords.Click += new System.EventHandler(this.button_KeyWords_Click);
            this.button_KeyWords.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_KeyWords_MouseDown);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.okButton);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBoxDescription);
            this.groupBox2.Controls.Add(this.labelProductName);
            this.groupBox2.Controls.Add(this.labelCopyright);
            this.groupBox2.Controls.Add(this.labelCompanyName);
            this.groupBox2.Location = new System.Drawing.Point(4, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(16, 255);
            this.groupBox2.TabIndex = 901;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(440, 127);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.label3.MaximumSize = new System.Drawing.Size(0, 17);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 895;
            this.label3.Text = "0567758089";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // okButton
            // 
            this.okButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.okButton.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.okButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.okButton.Location = new System.Drawing.Point(10, 196);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(366, 34);
            this.okButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.okButton.Symbol = "";
            this.okButton.TabIndex = 894;
            this.okButton.Text = "OK";
            this.okButton.TextColor = System.Drawing.Color.Navy;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(437, 149);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.label4.MaximumSize = new System.Drawing.Size(0, 17);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 892;
            this.label4.Text = "----------------";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(419, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.label2.MaximumSize = new System.Drawing.Size(0, 17);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 890;
            this.label2.Text = "www.PROSOFTsa.com";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(420, 105);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.label1.MaximumSize = new System.Drawing.Size(0, 17);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 889;
            this.label1.Text = "info@PROSOFTsa.com";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.BackColor = System.Drawing.Color.GhostWhite;
            this.textBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDescription.ForeColor = System.Drawing.Color.SteelBlue;
            this.textBoxDescription.Location = new System.Drawing.Point(8, 10);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.textBoxDescription, false);
            this.textBoxDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDescription.Size = new System.Drawing.Size(85, 184);
            this.textBoxDescription.TabIndex = 888;
            this.textBoxDescription.TabStop = false;
            this.textBoxDescription.Text = resources.GetString("textBoxDescription.Text");
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelProductName.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelProductName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelProductName.Location = new System.Drawing.Point(408, 39);
            this.labelProductName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelProductName.MaximumSize = new System.Drawing.Size(0, 17);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelProductName.Size = new System.Drawing.Size(105, 13);
            this.labelProductName.TabIndex = 885;
            this.labelProductName.Text = "تطبيقات برو سوفت";
            this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCopyright
            // 
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.labelCopyright.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelCopyright.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCopyright.Location = new System.Drawing.Point(394, 171);
            this.labelCopyright.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelCopyright.MaximumSize = new System.Drawing.Size(0, 17);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelCopyright.Size = new System.Drawing.Size(183, 13);
            this.labelCopyright.TabIndex = 886;
            this.labelCopyright.Text = "Copyright ©2016 -PROSOFTSolution";
            this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.AllowDrop = true;
            this.labelCompanyName.AutoSize = true;
            this.labelCompanyName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelCompanyName.ForeColor = System.Drawing.Color.Brown;
            this.labelCompanyName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCompanyName.Location = new System.Drawing.Point(429, 193);
            this.labelCompanyName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelCompanyName.MaximumSize = new System.Drawing.Size(0, 17);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelCompanyName.Size = new System.Drawing.Size(101, 13);
            this.labelCompanyName.TabIndex = 887;
            this.labelCompanyName.Text = "Pro.Soft Solution";
            this.labelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelVersion
            // 
            this.labelVersion.AutoEllipsis = true;
            this.labelVersion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelVersion.ForeColor = System.Drawing.Color.Goldenrod;
            this.labelVersion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelVersion.Location = new System.Drawing.Point(398, 604);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelVersion.MaximumSize = new System.Drawing.Size(0, 17);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(225, 17);
            this.labelVersion.TabIndex = 884;
            this.labelVersion.Text = "Version : 1.0.5";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelVersion.Click += new System.EventHandler(this.labelVersion_Click);
            this.labelVersion.MouseEnter += new System.EventHandler(this.labelVersion_MouseEnter);
            this.labelVersion.MouseLeave += new System.EventHandler(this.labelVersion_MouseLeave);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_BackuElc,
            this.toolStripSeparator1,
            this.toolStrip_InvSetting,
            this.toolStrip_SndSetting,
            this.toolStrip_Stocks,
            this.toolStripSeparator5,
            this.toolStripMenuItem1,
            this.toolStripSeparator6,
            this.toolStrip_NetWork,
            this.toolStrip_CenterCost,
            this.toolStrip_RemoteDesctop,
            this.toolStrip_Barcode,
            this.toolStrip_Casheir,
            this.toolStrip_BankPeaper,
            this.toolStrip_Branches,
            this.toolStrip_DataBase,
            this.toolStrip_Year,
            this.toolStripSeparator2,
            this.toolStrip_RunSetting,
            this.toolStrip_StopSetting,
            this.toolStripSeparator3,
            this.toolStrip_POS,
            this.toolStripMenuItem_Norton,
            this.toolStripSeparator4,
            this.SMS,
            this.نقلالبياناتمنالابسوفتToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.ShowCheckMargin = true;
            this.contextMenuStrip1.Size = new System.Drawing.Size(355, 480);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // toolStrip_BackuElc
            // 
            this.toolStrip_BackuElc.Name = "toolStrip_BackuElc";
            this.toolStrip_BackuElc.Size = new System.Drawing.Size(354, 22);
            this.toolStrip_BackuElc.Text = "خدمات الدعم الفني و النسخ الإحتياطي الإلكتروني";
            this.toolStrip_BackuElc.Click += new System.EventHandler(this.toolStrip_BackuElc_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(351, 6);
            // 
            // toolStrip_InvSetting
            // 
            this.toolStrip_InvSetting.Name = "toolStrip_InvSetting";
            this.toolStrip_InvSetting.Size = new System.Drawing.Size(354, 22);
            this.toolStrip_InvSetting.Text = "تحديث اعدادات طباعة الفواتير";
            this.toolStrip_InvSetting.Click += new System.EventHandler(this.toolStrip_InvSetting_Click);
            // 
            // toolStrip_SndSetting
            // 
            this.toolStrip_SndSetting.Name = "toolStrip_SndSetting";
            this.toolStrip_SndSetting.Size = new System.Drawing.Size(354, 22);
            this.toolStrip_SndSetting.Text = "تحديث اعدادات طباعة السندات";
            this.toolStrip_SndSetting.Click += new System.EventHandler(this.toolStrip_SndSetting_Click);
            // 
            // toolStrip_Stocks
            // 
            this.toolStrip_Stocks.Name = "toolStrip_Stocks";
            this.toolStrip_Stocks.Size = new System.Drawing.Size(354, 22);
            this.toolStrip_Stocks.Text = "تفعيل خاصية تعدد المستودعات";
            this.toolStrip_Stocks.Click += new System.EventHandler(this.toolStrip_Stocks_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(351, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_BarSetting,
            this.toolStripSeparator7,
            this.toolStrip_BarInvSetting});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(354, 22);
            this.toolStripMenuItem1.Text = "تحديث إعدادات الباركود :";
            // 
            // toolStrip_BarSetting
            // 
            this.toolStrip_BarSetting.Name = "toolStrip_BarSetting";
            this.toolStrip_BarSetting.Size = new System.Drawing.Size(257, 22);
            this.toolStrip_BarSetting.Text = "تحديث اعدادات طباعة باركود الأصناف";
            this.toolStrip_BarSetting.Click += new System.EventHandler(this.toolStrip_BarSetting_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(254, 6);
            // 
            // toolStrip_BarInvSetting
            // 
            this.toolStrip_BarInvSetting.Name = "toolStrip_BarInvSetting";
            this.toolStrip_BarInvSetting.Size = new System.Drawing.Size(257, 22);
            this.toolStrip_BarInvSetting.Text = "تحديث اعدادات طباعة باركود الفواتير";
            this.toolStrip_BarInvSetting.Click += new System.EventHandler(this.toolStrip_BarInvSetting_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(351, 6);
            // 
            // toolStrip_NetWork
            // 
            this.toolStrip_NetWork.Name = "toolStrip_NetWork";
            this.toolStrip_NetWork.Size = new System.Drawing.Size(354, 22);
            this.toolStrip_NetWork.Text = "تفعيل خاصية ربـط الشبكـات";
            this.toolStrip_NetWork.Click += new System.EventHandler(this.toolStrip_NetWork_Click);
            // 
            // toolStrip_CenterCost
            // 
            this.toolStrip_CenterCost.Name = "toolStrip_CenterCost";
            this.toolStrip_CenterCost.Size = new System.Drawing.Size(354, 22);
            this.toolStrip_CenterCost.Text = "تفعيل خاصية تعدد مراكز التكلفة";
            this.toolStrip_CenterCost.Click += new System.EventHandler(this.toolStrip_CenterCost_Click);
            // 
            // toolStrip_RemoteDesctop
            // 
            this.toolStrip_RemoteDesctop.Name = "toolStrip_RemoteDesctop";
            this.toolStrip_RemoteDesctop.Size = new System.Drawing.Size(354, 22);
            this.toolStrip_RemoteDesctop.Text = "تفعيل مميزات الإشتراك السنوي + Remote Descktop";
            this.toolStrip_RemoteDesctop.Click += new System.EventHandler(this.toolStrip_RemoteDesctop_Click);
            // 
            // toolStrip_Barcode
            // 
            this.toolStrip_Barcode.Name = "toolStrip_Barcode";
            this.toolStrip_Barcode.Size = new System.Drawing.Size(354, 22);
            this.toolStrip_Barcode.Text = "  نسخة الطلبات المحلية    Waiter";
            this.toolStrip_Barcode.Click += new System.EventHandler(this.toolStrip_Barcode_Click);
            // 
            // toolStrip_Casheir
            // 
            this.toolStrip_Casheir.Name = "toolStrip_Casheir";
            this.toolStrip_Casheir.Size = new System.Drawing.Size(354, 22);
            this.toolStrip_Casheir.Text = "تفعيل مـــيزة نقاط البيع للنسخة البرونزية";
            this.toolStrip_Casheir.Click += new System.EventHandler(this.toolStrip_Casheir_Click);
            // 
            // toolStrip_BankPeaper
            // 
            this.toolStrip_BankPeaper.Name = "toolStrip_BankPeaper";
            this.toolStrip_BankPeaper.Size = new System.Drawing.Size(354, 22);
            this.toolStrip_BankPeaper.Text = "تفعيل خاصية الأوراق المالية";
            this.toolStrip_BankPeaper.Click += new System.EventHandler(this.toolStrip_BankPeaper_Click);
            // 
            // toolStrip_Branches
            // 
            this.toolStrip_Branches.Name = "toolStrip_Branches";
            this.toolStrip_Branches.Size = new System.Drawing.Size(354, 22);
            this.toolStrip_Branches.Text = "تفعيل خاصية تعدد الفروع";
            this.toolStrip_Branches.Click += new System.EventHandler(this.toolStrip_Branches_Click);
            // 
            // toolStrip_DataBase
            // 
            this.toolStrip_DataBase.Name = "toolStrip_DataBase";
            this.toolStrip_DataBase.Size = new System.Drawing.Size(354, 22);
            this.toolStrip_DataBase.Text = "تفعيل خاصية تعدد قواعد البيانات";
            this.toolStrip_DataBase.Click += new System.EventHandler(this.toolStrip_DataBase_Click);
            // 
            // toolStrip_Year
            // 
            this.toolStrip_Year.Name = "toolStrip_Year";
            this.toolStrip_Year.Size = new System.Drawing.Size(354, 22);
            this.toolStrip_Year.Text = "تشغيل اعدادات تفعيل المنتج";
            this.toolStrip_Year.Click += new System.EventHandler(this.toolStrip_Year_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(351, 6);
            this.toolStripSeparator2.Visible = false;
            // 
            // toolStrip_RunSetting
            // 
            this.toolStrip_RunSetting.Name = "toolStrip_RunSetting";
            this.toolStrip_RunSetting.Size = new System.Drawing.Size(354, 22);
            this.toolStrip_RunSetting.Text = "ازالة ملفات إيقاف النظام السنوي";
            this.toolStrip_RunSetting.Click += new System.EventHandler(this.toolStrip_Setting_Click);
            // 
            // toolStrip_StopSetting
            // 
            this.toolStrip_StopSetting.Name = "toolStrip_StopSetting";
            this.toolStrip_StopSetting.Size = new System.Drawing.Size(354, 22);
            this.toolStrip_StopSetting.Text = "قراءة بيانات التفعيل من ملف نصي";
            this.toolStrip_StopSetting.Click += new System.EventHandler(this.toolStrip_StopSetting_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(351, 6);
            // 
            // toolStrip_POS
            // 
            this.toolStrip_POS.Name = "toolStrip_POS";
            this.toolStrip_POS.Size = new System.Drawing.Size(354, 22);
            this.toolStrip_POS.Text = "تعـيين الجهــاز كنقطة بيــع فقط | نسخة نقاط البيع";
            this.toolStrip_POS.Click += new System.EventHandler(this.toolStrip_POS_Click);
            // 
            // toolStripMenuItem_Norton
            // 
            this.toolStripMenuItem_Norton.Name = "toolStripMenuItem_Norton";
            this.toolStripMenuItem_Norton.Size = new System.Drawing.Size(354, 22);
            this.toolStripMenuItem_Norton.Text = "إلى نسخة الميني برونزي";
            this.toolStripMenuItem_Norton.Click += new System.EventHandler(this.toolStripMenuItem_Norton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(351, 6);
            // 
            // SMS
            // 
            this.SMS.Name = "SMS";
            this.SMS.Size = new System.Drawing.Size(354, 22);
            this.SMS.Text = "نسخة رسائل فقط";
            this.SMS.Click += new System.EventHandler(this.SMS_Click);
            // 
            // نقلالبياناتمنالابسوفتToolStripMenuItem
            // 
            this.نقلالبياناتمنالابسوفتToolStripMenuItem.Name = "نقلالبياناتمنالابسوفتToolStripMenuItem";
            this.نقلالبياناتمنالابسوفتToolStripMenuItem.Size = new System.Drawing.Size(354, 22);
            this.نقلالبياناتمنالابسوفتToolStripMenuItem.Text = "نقل البيانات من الاب سوفت";
            this.نقلالبياناتمنالابسوفتToolStripMenuItem.Click += new System.EventHandler(this.نقلالبياناتمنالابسوفتToolStripMenuItem_Click);
            // 
            // buttonX_EnterToSystem
            // 
            this.buttonX_EnterToSystem.BackgroundImage = global::InvAcc.Properties.Resources.BLU;
            this.buttonX_EnterToSystem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonX_EnterToSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonX_EnterToSystem.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.buttonX_EnterToSystem.Location = new System.Drawing.Point(485, 351);
            this.buttonX_EnterToSystem.Name = "buttonX_EnterToSystem";
            this.buttonX_EnterToSystem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buttonX_EnterToSystem.Size = new System.Drawing.Size(190, 57);
            this.buttonX_EnterToSystem.TabIndex = 1188;
            this.buttonX_EnterToSystem.Text = "دخول | ENTER";
            this.buttonX_EnterToSystem.UseVisualStyleBackColor = true;
            this.buttonX_EnterToSystem.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.buttonX_EnterToSystem.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue;
            this.buttonX_EnterToSystem.Click += new System.EventHandler(this.buttonX_EnterToSystem_Click);
            this.buttonX_EnterToSystem.MouseLeave += new System.EventHandler(this.buttonX_EnterToSystem_MouseLeave);
            this.buttonX_EnterToSystem.MouseHover += new System.EventHandler(this.buttonX_EnterToSystem_MouseHover);
            this.buttonX_EnterToSystem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonX_EnterToSystem_MouseMove);
            // 
            // buttonItem_Exit
            // 
            this.buttonItem_Exit.BackgroundImage = global::InvAcc.Properties.Resources.YALO2;
            this.buttonItem_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonItem_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonItem_Exit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.buttonItem_Exit.Location = new System.Drawing.Point(322, 352);
            this.buttonItem_Exit.Name = "buttonItem_Exit";
            this.buttonItem_Exit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buttonItem_Exit.Size = new System.Drawing.Size(157, 57);
            this.buttonItem_Exit.TabIndex = 1188;
            this.buttonItem_Exit.Text = "خروج | EXIT";
            this.buttonItem_Exit.UseVisualStyleBackColor = true;
            this.buttonItem_Exit.Click += new System.EventHandler(this.buttonItem_Exit_Click);
            this.buttonItem_Exit.MouseLeave += new System.EventHandler(this.buttonItem_Exit_MouseLeave);
            this.buttonItem_Exit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonItem_Exit_MouseMove);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.LawnGreen;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(522, 647);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.label5.MaximumSize = new System.Drawing.Size(0, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 1189;
            this.label5.Text = "DB Version: ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Visible = false;
            // 
            // netResize1
            // 
            this.netResize1.LabelsAutoEllipse = false;
            this.netResize1.ParentControl = this;
            this.netResize1.ResizeMode = Softgroup.NetResize.NetResize.ResizeModeEnum.rmAdvanced;
            // 
            // FrmLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(50)))), ((int)(((byte)(59)))));
            this.BackgroundImage = global::InvAcc.Properties.Resources.Log;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1306, 772);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonItem_Exit);
            this.Controls.Add(this.buttonX_EnterToSystem);
            this.Controls.Add(this.button_KeyWords);
            this.Controls.Add(this.button_SrchUsrNo);
            this.Controls.Add(this.switchButton_waiter);
            this.Controls.Add(this.button_Support);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textBox_Pass);
            this.Controls.Add(this.textBox_WaiterPass);
            this.Controls.Add(this.groupPanel_BoardNo);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.comboBox_UserName);
            this.Controls.Add(this.comboBox_Waiter);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = global::InvAcc.Properties.Resources.favicon;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(505, 251);
            this.Name = "FrmLog";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLog_FormClosing);
            this.Load += new System.EventHandler(this.FrmLog_Load);
            this.Shown += new System.EventHandler(this.FrmLog_Shown);
            this.VisibleChanged += new System.EventHandler(this.FrmLog_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmLog_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmLog_KeyPress);
            this.MouseHover += new System.EventHandler(this.FrmLog_MouseHover);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.FrmLog_PreviewKeyDown);
            this.groupPanel_BoardNo.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonX_EnterToSystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonItem_Exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private GroupBox groupBox1;
        private ComboBoxEx comboBox_UserName;
        private TextBox textBox_Pass;
        private GroupBox groupBox2;
        private TextBox textBoxDescription;
        private Label labelProductName;
        private Label labelVersion;
        private Label labelCopyright;
        private Label labelCompanyName;
        private Label label1;
        private Label label2;
        private Label label4;
        private ButtonX okButton;
        protected ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStrip_BackuElc;
        private ToolStripMenuItem toolStrip_InvSetting;
        private ToolStripMenuItem toolStrip_SndSetting;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem toolStrip_NetWork;
        private Label label3;
        private ToolStripMenuItem toolStrip_Stocks;
        private ToolStripMenuItem toolStrip_Branches;
        private ToolStripMenuItem toolStrip_CenterCost;
        private ToolStripMenuItem toolStrip_Barcode;
        private ToolStripMenuItem toolStrip_Casheir;
        private ToolStripMenuItem toolStrip_BankPeaper;
        private ToolStripMenuItem toolStrip_DataBase;
        private ToolStripMenuItem toolStrip_Year;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem toolStrip_RunSetting;
        private ToolStripMenuItem toolStrip_StopSetting;
        private ToolStripMenuItem toolStrip_POS;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripSeparator toolStripSeparator4;
        private GroupPanel groupPanel_BoardNo;
        private ButtonX button_Space;
        private ButtonX button_0;
        private ButtonX button_2;
        private ButtonX button_1;
        private ButtonX button_6;
        private ButtonX button_5;
        private ButtonX button_8;
        private ButtonX button_7;
        private ButtonX button_Bac;
        private ButtonX button_3;
        private ButtonX button_4;
        private ButtonX button_9;
        private ButtonX button_KeyWords;
        private ComboBoxEx comboBox_Waiter;
        private TextBox textBox_WaiterPass;
        private ButtonX button_Support;
        private ToolStripMenuItem toolStripMenuItem_Norton;
        private ButtonX button_SrchUsrNo;
        private ToolStripMenuItem toolStrip_RemoteDesctop;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStrip_BarSetting;
        private ToolStripMenuItem toolStrip_BarInvSetting;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripSeparator toolStripSeparator6;
        private SwitchButton switchButton_waiter;
        private ToolStripMenuItem SMS;
        private C1.Win.C1Input.C1Button buttonX_EnterToSystem;
        private C1.Win.C1Input.C1Button buttonItem_Exit;
        private ToolStripMenuItem نقلالبياناتمنالابسوفتToolStripMenuItem;
        private Label label5;
        private Softgroup.NetResize.NetResize netResize1;
    }
}
