   

namespace InvAcc.Forms
{
partial class FrmTransItmAcc
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

private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTransItmAcc));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();

            components = new System.ComponentModel.Container();

            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox_Det = new System.Windows.Forms.TextBox();
            this.groupBox_BranchFrom = new System.Windows.Forms.GroupBox();
            this.combobox_BranchFrom = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.groupBox_BranchTo = new System.Windows.Forms.GroupBox();
            this.combobox_BranchTo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.groupBox_Choese = new System.Windows.Forms.GroupBox();
            this.chk1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.chk2 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.ProgressBar1 = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.ButOk = new DevComponents.DotNetBar.ButtonX();
            this.ButExit = new DevComponents.DotNetBar.ButtonX();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();

            this.ribbonBar1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox_BranchFrom.SuspendLayout();
            this.groupBox_BranchTo.SuspendLayout();
            this.groupBox_Choese.SuspendLayout();

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
            this.ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.Silver;
            this.ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.panel1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(343, 347);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 1195;
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.textBox_Det);
            this.panel1.Controls.Add(this.groupBox_BranchFrom);
            this.panel1.Controls.Add(this.groupBox_BranchTo);
            this.panel1.Controls.Add(this.groupBox_Choese);
            this.panel1.Controls.Add(this.ProgressBar1);
            this.panel1.Controls.Add(this.ButOk);
            this.panel1.Controls.Add(this.ButExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 330);
            this.panel1.TabIndex = 2;
            // 
            // textBox_Det
            // 
            this.textBox_Det.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox_Det.Font = new System.Drawing.Font("Tahoma", 8F);
            this.textBox_Det.ForeColor = System.Drawing.Color.Black;
            this.textBox_Det.Location = new System.Drawing.Point(10, 167);
            this.textBox_Det.Multiline = true;
            this.textBox_Det.Name = "textBox_Det";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Det, false);
            this.textBox_Det.ReadOnly = true;
            this.textBox_Det.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Det.Size = new System.Drawing.Size(316, 117);
            this.textBox_Det.TabIndex = 7;
            // 
            // groupBox_BranchFrom
            // 
            this.groupBox_BranchFrom.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_BranchFrom.Controls.Add(this.combobox_BranchFrom);
            this.groupBox_BranchFrom.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.groupBox_BranchFrom.Location = new System.Drawing.Point(12, -122);
            this.groupBox_BranchFrom.Name = "groupBox_BranchFrom";
            this.groupBox_BranchFrom.Size = new System.Drawing.Size(498, 75);
            this.groupBox_BranchFrom.TabIndex = 1188;
            this.groupBox_BranchFrom.TabStop = false;
            this.groupBox_BranchFrom.Text = "من فـــــــرع :";
            // 
            // combobox_BranchFrom
            // 
            this.combobox_BranchFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combobox_BranchFrom.DisplayMember = "Text";
            this.combobox_BranchFrom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_BranchFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_BranchFrom.Enabled = false;
            this.combobox_BranchFrom.FormattingEnabled = true;
            this.combobox_BranchFrom.ItemHeight = 15;
            this.combobox_BranchFrom.Location = new System.Drawing.Point(66, 31);
            this.combobox_BranchFrom.Name = "combobox_BranchFrom";
            this.combobox_BranchFrom.Size = new System.Drawing.Size(350, 21);
            this.combobox_BranchFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combobox_BranchFrom.TabIndex = 6;
            // 
            // groupBox_BranchTo
            // 
            this.groupBox_BranchTo.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_BranchTo.Controls.Add(this.combobox_BranchTo);
            this.groupBox_BranchTo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox_BranchTo.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupBox_BranchTo.Location = new System.Drawing.Point(10, 12);
            this.groupBox_BranchTo.Name = "groupBox_BranchTo";
            this.groupBox_BranchTo.Size = new System.Drawing.Size(317, 81);
            this.groupBox_BranchTo.TabIndex = 1187;
            this.groupBox_BranchTo.TabStop = false;
            this.groupBox_BranchTo.Text = "نقل البيانات الى الفرع :";
            // 
            // combobox_BranchTo
            // 
            this.combobox_BranchTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combobox_BranchTo.DisplayMember = "Text";
            this.combobox_BranchTo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combobox_BranchTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_BranchTo.FormattingEnabled = true;
            this.combobox_BranchTo.ItemHeight = 14;
            this.combobox_BranchTo.Location = new System.Drawing.Point(24, 37);
            this.combobox_BranchTo.Name = "combobox_BranchTo";
            this.combobox_BranchTo.Size = new System.Drawing.Size(258, 20);
            this.combobox_BranchTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.combobox_BranchTo.TabIndex = 1;
            // 
            // groupBox_Choese
            // 
            this.groupBox_Choese.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_Choese.Controls.Add(this.chk1);
            this.groupBox_Choese.Controls.Add(this.chk2);
            this.groupBox_Choese.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox_Choese.ForeColor = System.Drawing.Color.SteelBlue;
            this.groupBox_Choese.Location = new System.Drawing.Point(10, 99);
            this.groupBox_Choese.Name = "groupBox_Choese";
            this.groupBox_Choese.Size = new System.Drawing.Size(317, 62);
            this.groupBox_Choese.TabIndex = 1186;
            this.groupBox_Choese.TabStop = false;
            this.groupBox_Choese.Tag = "";
            this.groupBox_Choese.Text = "خيارات النقل";
            // 
            // chk1
            // 
            this.chk1.AutoSize = true;
            this.chk1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.chk1.Location = new System.Drawing.Point(178, 28);
            this.chk1.Name = "chk1";
            this.chk1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk1.Size = new System.Drawing.Size(97, 16);
            this.chk1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk1.TabIndex = 2;
            this.chk1.Text = "نقل الأصنـــــــاف";
            // 
            // chk2
            // 
            this.chk2.AutoSize = true;
            this.chk2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.chk2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chk2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.chk2.Location = new System.Drawing.Point(21, 28);
            this.chk2.Name = "chk2";
            this.chk2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chk2.Size = new System.Drawing.Size(125, 16);
            this.chk2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chk2.TabIndex = 3;
            this.chk2.Text = "نقل كرت الحســــــابات";
            // 
            // ProgressBar1
            // 
            // 
            // 
            // 
            this.ProgressBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ProgressBar1.Location = new System.Drawing.Point(11, 290);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(315, 34);
            this.ProgressBar1.TabIndex = 1189;
            this.ProgressBar1.Text = "progressBarX1";
            this.ProgressBar1.Visible = false;
            // 
            // ButOk
            // 
            this.ButOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButOk.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.ButOk.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButOk.Location = new System.Drawing.Point(173, 292);
            this.ButOk.Name = "ButOk";
            this.ButOk.Size = new System.Drawing.Size(153, 30);
            this.ButOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButOk.Symbol = "";
            this.ButOk.SymbolSize = 16F;
            this.ButOk.TabIndex = 4;
            this.ButOk.Text = "نقــــل";
            this.ButOk.TextColor = System.Drawing.Color.White;
            this.ButOk.Click += new System.EventHandler(this.ButOk_Click);
            // 
            // ButExit
            // 
            this.ButExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButExit.Checked = true;
            this.ButExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ButExit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButExit.Location = new System.Drawing.Point(11, 292);
            this.ButExit.Name = "ButExit";
            this.ButExit.Size = new System.Drawing.Size(153, 30);
            this.ButExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButExit.Symbol = "";
            this.ButExit.SymbolSize = 16F;
            this.ButExit.TabIndex = 5;
            this.ButExit.Text = "خـــروج";
            this.ButExit.TextColor = System.Drawing.Color.Black;
            this.ButExit.Click += new System.EventHandler(this.ButExit_Click);
            // 
            // FrmTransItmAcc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 347);
            this.PanelSpecialContainer.Controls.Add(this.ribbonBar1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmTransItmAcc";
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نقل البيانات بين الفروع";
            this.Load += new System.EventHandler(this.FrmTransItmAcc_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmTransItmAcc_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmTransItmAcc_KeyPress);
            this.ribbonBar1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox_BranchFrom.ResumeLayout(false);
            this.groupBox_BranchTo.ResumeLayout(false);
            this.groupBox_Choese.ResumeLayout(false);
            this.groupBox_Choese.PerformLayout();
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.ResumeLayout(false);
        }//###########&&&&&&&&&&

}
}
