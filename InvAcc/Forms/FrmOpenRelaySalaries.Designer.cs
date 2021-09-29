   

namespace InvAcc.Forms
{
partial class FrmOpenRelaySalaries
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOpenRelaySalaries));
            this.PanelSpecialContainer = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button_SrchMonth = new DevComponents.DotNetBar.ButtonX();
            this.comboBox_Month = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.button_Close = new DevComponents.DotNetBar.ButtonX();
            this.Button_OK = new DevComponents.DotNetBar.ButtonX();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);  this.netResize1.LabelsAutoEllipse = false;
            this.panel1 = new System.Windows.Forms.Panel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_DayOfMonth = new DevComponents.Editors.IntegerInput();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.panel1.SuspendLayout();
            this.ribbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_DayOfMonth)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelSpecialContainer
            // 
            this.PanelSpecialContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelSpecialContainer.Name = "PanelSpecialContainer";
            this.PanelSpecialContainer.Size = new System.Drawing.Size(200, 100);
            this.PanelSpecialContainer.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(263, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 70;
            this.label1.Text = "الشهـــــر :";
            // 
            // button_SrchMonth
            // 
            this.button_SrchMonth.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchMonth.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchMonth.Location = new System.Drawing.Point(56, 42);
            this.button_SrchMonth.Name = "button_SrchMonth";
            this.button_SrchMonth.Size = new System.Drawing.Size(26, 20);
            this.button_SrchMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchMonth.Symbol = "";
            this.button_SrchMonth.SymbolSize = 12F;
            this.button_SrchMonth.TabIndex = 1587;
            this.button_SrchMonth.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchMonth.Click += new System.EventHandler(this.button_SrchMonth_Click);
            // 
            // comboBox_Month
            // 
            this.comboBox_Month.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Month.DisplayMember = "Text";
            this.comboBox_Month.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_Month.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Month.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.comboBox_Month.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboBox_Month.FormattingEnabled = true;
            this.comboBox_Month.ItemHeight = 14;
            this.comboBox_Month.Location = new System.Drawing.Point(84, 42);
            this.comboBox_Month.Name = "comboBox_Month";
            this.comboBox_Month.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBox_Month.Size = new System.Drawing.Size(173, 20);
            this.comboBox_Month.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_Month.TabIndex = 1584;
            this.comboBox_Month.WatermarkText = "لا يوجد رواتب مرّحلة";
            // 
            // button_Close
            // 
            this.button_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_Close.Checked = true;
            this.button_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_Close.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button_Close.Location = new System.Drawing.Point(11, 106);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(208, 37);
            this.button_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_Close.Symbol = "";
            this.button_Close.SymbolSize = 16F;
            this.button_Close.TabIndex = 19;
            this.button_Close.Text = "خـــروج";
            this.button_Close.TextColor = System.Drawing.Color.Black;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // Button_OK
            // 
            this.Button_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Button_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.Button_OK.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Button_OK.Location = new System.Drawing.Point(223, 106);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(208, 37);
            this.Button_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Button_OK.Symbol = "";
            this.Button_OK.SymbolSize = 16F;
            this.Button_OK.TabIndex = 18;
            this.Button_OK.Text = "إلغاء الترحيل";
            this.Button_OK.TextColor = System.Drawing.Color.White;
            this.Button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // netResize1
            // 
            this.netResize1.ParentControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.button_Close);
            this.panel1.Controls.Add(this.Button_OK);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(442, 154);
            this.panel1.TabIndex = 1104;
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
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.panel1);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.Tag= "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(442, 171);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 1103;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(114, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 69;
            this.label3.Text = "عدد الأيام :";
            // 
            // textBox_DayOfMonth
            // 
            this.textBox_DayOfMonth.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_DayOfMonth.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_DayOfMonth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_DayOfMonth.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_DayOfMonth.Enabled = false;
            this.textBox_DayOfMonth.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_DayOfMonth.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_DayOfMonth.Location = new System.Drawing.Point(13, 169);
            this.textBox_DayOfMonth.MaxValue = 31;
            this.textBox_DayOfMonth.MinValue = 1;
            this.textBox_DayOfMonth.Name = "textBox_DayOfMonth";
            this.textBox_DayOfMonth.Size = new System.Drawing.Size(95, 20);
            this.textBox_DayOfMonth.TabIndex = 5;
            this.textBox_DayOfMonth.Value = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_SrchMonth);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_DayOfMonth);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox_Month);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(11, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 88);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // FrmOpenRelaySalaries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 171);
            this.Controls.Add(this.ribbonBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmOpenRelaySalaries";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إلغاء ترحيل رواتب شهر";
            this.Load += new System.EventHandler(this.FrmOpenRelaySalaries_Load);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmOpenRelaySalaries_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmOpenRelaySalaries_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ribbonBar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textBox_DayOfMonth)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }//###########&&&&&&&&&&

}
}
