   

namespace InvAcc.Forms
{
partial class FMBranchSelect
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
            this.components = new System.ComponentModel.Container();
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CmbNewBranch = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.txtOldBranch = new System.Windows.Forms.TextBox();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.buttonX_Close = new DevComponents.DotNetBar.ButtonX();
            this.buttonX_Ok = new DevComponents.DotNetBar.ButtonX();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
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
            this.PanelSpecialContainer.Size = new System.Drawing.Size(318, 188);
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
            this.ribbonBar1.Controls.Add(this.panel1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.DragDropSupport = true;
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(318, 188);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 869;
            this.ribbonBar1.Tag = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
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
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.CmbNewBranch);
            this.panel1.Controls.Add(this.txtOldBranch);
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Controls.Add(this.buttonX_Close);
            this.panel1.Controls.Add(this.buttonX_Ok);
            this.panel1.Location = new System.Drawing.Point(10, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 160);
            this.panel1.TabIndex = 858;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // CmbNewBranch
            // 
            this.CmbNewBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbNewBranch.DisplayMember = "Text";
            this.CmbNewBranch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CmbNewBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbNewBranch.ForeColor = System.Drawing.Color.SteelBlue;
            this.CmbNewBranch.FormattingEnabled = true;
            this.CmbNewBranch.ItemHeight = 15;
            this.CmbNewBranch.Location = new System.Drawing.Point(22, 64);
            this.CmbNewBranch.Name = "CmbNewBranch";
            this.CmbNewBranch.Size = new System.Drawing.Size(256, 21);
            this.CmbNewBranch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CmbNewBranch.TabIndex = 1;
            // 
            // txtOldBranch
            // 
            this.txtOldBranch.BackColor = System.Drawing.Color.White;
            this.txtOldBranch.Location = new System.Drawing.Point(309, 50);
            this.txtOldBranch.Name = "txtOldBranch";
            this.txtOldBranch.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.txtOldBranch, false);
            this.txtOldBranch.Size = new System.Drawing.Size(190, 20);
            this.txtOldBranch.TabIndex = 91;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.DimGray;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX1.Font = new System.Drawing.Font("Tahoma", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labelX1.ForeColor = System.Drawing.Color.White;
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(300, 26);
            this.labelX1.TabIndex = 88;
            this.labelX1.Text = "تغيير مسار قاعدة البيانات ( تغيير الفرع )";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // buttonX_Close
            // 
            this.buttonX_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Close.Checked = true;
            this.buttonX_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_Close.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonX_Close.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.buttonX_Close.Location = new System.Drawing.Point(18, 106);
            this.buttonX_Close.Name = "buttonX_Close";
            this.buttonX_Close.Size = new System.Drawing.Size(122, 39);
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
            this.buttonX_Ok.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX_Ok.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonX_Ok.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.buttonX_Ok.Location = new System.Drawing.Point(156, 106);
            this.buttonX_Ok.Name = "buttonX_Ok";
            this.buttonX_Ok.Size = new System.Drawing.Size(122, 38);
            this.buttonX_Ok.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Ok.Symbol = "";
            this.buttonX_Ok.TabIndex = 2;
            this.buttonX_Ok.Text = "موافــــق";
            this.buttonX_Ok.TextColor = System.Drawing.Color.White;
            this.buttonX_Ok.Click += new System.EventHandler(this.buttonX_Ok_Click);
            // 
            // netResize1
            // 
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.LabelsAutoEllipse = false;
            this.netResize1.ParentControl = this;
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            // 
            // FMBranchSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 188);
            this.ControlBox = false;
            this.Controls.Add(this.PanelSpecialContainer);
            this.Icon = global::InvAcc.Properties.Resources.favicon;
            this.KeyPreview = true;
            this.Name = "FMBranchSelect";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FMBranchSelect_Load);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.PanelSpecialContainer.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);

        }//###########&&&&&&&&&&

}
}
