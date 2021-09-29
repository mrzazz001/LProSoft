   

namespace InvAcc.Forms
{
partial class FrmCustSuppImport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            components = new System.ComponentModel.Container();

            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustSuppImport));
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonX_ImportFile = new DevComponents.DotNetBar.ButtonX();
            this.textBox_SearchFilePath = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_Mobile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonX_SerchAccNo = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_AccNo = new System.Windows.Forms.TextBox();
            this.textBox_NameE = new System.Windows.Forms.TextBox();
            this.textBox_NameA = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ExcelGridView = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Button_Cancel = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();

            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExcelGridView)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.buttonX_ImportFile);
            this.panel2.Controls.Add(this.textBox_SearchFilePath);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.ExcelGridView);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(499, 390);
            this.panel2.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 6F);
            this.textBox1.Location = new System.Drawing.Point(3, 391);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(1659, 168);
            this.textBox1.TabIndex = 873;
            this.textBox1.WordWrap = false;
            // 
            // buttonX_ImportFile
            // 
            this.buttonX_ImportFile.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_ImportFile.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_ImportFile.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.buttonX_ImportFile.Location = new System.Drawing.Point(4, 23);
            this.buttonX_ImportFile.Name = "buttonX_ImportFile";
            this.buttonX_ImportFile.Size = new System.Drawing.Size(162, 36);
            this.buttonX_ImportFile.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.buttonX_ImportFile.TabIndex = 870;
            this.buttonX_ImportFile.Text = "الإستيراد من ملف أكسيل";
            this.buttonX_ImportFile.Click += new System.EventHandler(this.buttonX_ImportFile_Click);
            // 
            // textBox_SearchFilePath
            // 
            this.textBox_SearchFilePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox_SearchFilePath.Enabled = false;
            this.textBox_SearchFilePath.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_SearchFilePath.ForeColor = System.Drawing.Color.Red;
            this.textBox_SearchFilePath.Location = new System.Drawing.Point(22, -4);
            this.textBox_SearchFilePath.Name = "textBox_SearchFilePath";
            this.textBox_SearchFilePath.ReadOnly = true;
            this.textBox_SearchFilePath.Size = new System.Drawing.Size(447, 21);
            this.textBox_SearchFilePath.TabIndex = 868;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.textBox_Mobile);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.buttonX_SerchAccNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_AccNo);
            this.groupBox1.Controls.Add(this.textBox_NameE);
            this.groupBox1.Controls.Add(this.textBox_NameA);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(172, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 110);
            this.groupBox1.TabIndex = 867;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تخصيص";
            // 
            // textBox_Mobile
            // 
            this.textBox_Mobile.BackColor = System.Drawing.Color.Yellow;
            this.textBox_Mobile.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox_Mobile.ForeColor = System.Drawing.Color.Red;
            this.textBox_Mobile.Location = new System.Drawing.Point(26, 83);
            this.textBox_Mobile.MaxLength = 2;
            this.textBox_Mobile.Name = "textBox_Mobile";
            this.textBox_Mobile.Size = new System.Drawing.Size(199, 22);
            this.textBox_Mobile.TabIndex = 868;
            this.textBox_Mobile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Mobile.Click += new System.EventHandler(this.textBox_Mobile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(231, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 869;
            this.label2.Text = "رقم الجوال :";
            // 
            // buttonX_SerchAccNo
            // 
            this.buttonX_SerchAccNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_SerchAccNo.Checked = true;
            this.buttonX_SerchAccNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_SerchAccNo.Location = new System.Drawing.Point(26, 15);
            this.buttonX_SerchAccNo.Name = "buttonX_SerchAccNo";
            this.buttonX_SerchAccNo.Size = new System.Drawing.Size(26, 22);
            this.buttonX_SerchAccNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_SerchAccNo.Symbol = "";
            this.buttonX_SerchAccNo.SymbolSize = 12F;
            this.buttonX_SerchAccNo.TabIndex = 867;
            this.buttonX_SerchAccNo.TextColor = System.Drawing.Color.SteelBlue;
            this.buttonX_SerchAccNo.Click += new System.EventHandler(this.buttonX_SerchAccNo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(231, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 866;
            this.label1.Text = "حساب الأب :";
            // 
            // textBox_AccNo
            // 
            this.textBox_AccNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox_AccNo.ForeColor = System.Drawing.Color.Red;
            this.textBox_AccNo.Location = new System.Drawing.Point(55, 15);
            this.textBox_AccNo.MaxLength = 2;
            this.textBox_AccNo.Name = "textBox_AccNo";
            this.textBox_AccNo.ReadOnly = true;
            this.textBox_AccNo.Size = new System.Drawing.Size(170, 22);
            this.textBox_AccNo.TabIndex = 1;
            this.textBox_AccNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_AccNo.Click += new System.EventHandler(this.textBox_EmpNo_Click);
            // 
            // textBox_NameE
            // 
            this.textBox_NameE.BackColor = System.Drawing.Color.Yellow;
            this.textBox_NameE.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox_NameE.ForeColor = System.Drawing.Color.Red;
            this.textBox_NameE.Location = new System.Drawing.Point(26, 59);
            this.textBox_NameE.MaxLength = 2;
            this.textBox_NameE.Name = "textBox_NameE";
            this.textBox_NameE.Size = new System.Drawing.Size(114, 22);
            this.textBox_NameE.TabIndex = 6;
            this.textBox_NameE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_NameE.Click += new System.EventHandler(this.textBox_TimeLeave1_Click);
            // 
            // textBox_NameA
            // 
            this.textBox_NameA.BackColor = System.Drawing.Color.Yellow;
            this.textBox_NameA.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox_NameA.ForeColor = System.Drawing.Color.Red;
            this.textBox_NameA.Location = new System.Drawing.Point(177, 59);
            this.textBox_NameA.MaxLength = 2;
            this.textBox_NameA.Name = "textBox_NameA";
            this.textBox_NameA.Size = new System.Drawing.Size(114, 22);
            this.textBox_NameA.TabIndex = 5;
            this.textBox_NameA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_NameA.Click += new System.EventHandler(this.textBox_Time1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(39, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 106;
            this.label5.Text = "الإسم الانجليزي :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(196, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 864;
            this.label4.Text = "الإسم العربي :";
            // 
            // ExcelGridView
            // 
            this.ExcelGridView.AllowUserToAddRows = false;
            this.ExcelGridView.AllowUserToDeleteRows = false;
            this.ExcelGridView.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.ExcelGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ExcelGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ExcelGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ExcelGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.ExcelGridView.Location = new System.Drawing.Point(4, 140);
            this.ExcelGridView.MultiSelect = false;
            this.ExcelGridView.Name = "ExcelGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ExcelGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ExcelGridView.RowHeadersVisible = false;
            this.ExcelGridView.Size = new System.Drawing.Size(491, 244);
            this.ExcelGridView.TabIndex = 854;
            this.ExcelGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExcelGridView_CellContentClick);
            this.ExcelGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExcelGridView_CellEndEdit);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.Button_Cancel);
            this.panel4.Controls.Add(this.button_OK);
            this.panel4.Location = new System.Drawing.Point(4, 65);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(162, 68);
            this.panel4.TabIndex = 872;
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Button_Cancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Button_Cancel.Location = new System.Drawing.Point(5, 33);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(150, 30);
            this.Button_Cancel.TabIndex = 13;
            this.Button_Cancel.Text = "خـــروج";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // button_OK
            // 
            this.button_OK.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.button_OK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_OK.Location = new System.Drawing.Point(5, 2);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(150, 30);
            this.button_OK.TabIndex = 11;
            this.button_OK.Text = "موافق";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.CadetBlue;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(499, 16);
            this.panel5.TabIndex = 843;
            // 
            // FrmCustSuppImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(499, 390);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = (InvAcc.Properties.Resources.favicon);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmCustSuppImport";
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "استيراد بيانات الأصناف";
            this.Load += new System.EventHandler(this.FrmCustSuppImport_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCustSuppImport_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmCustSuppImport_KeyPress);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExcelGridView)).EndInit();
            this.panel4.ResumeLayout(false);
            this.Icon = (InvAcc.Properties.Resources.favicon);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.ResumeLayout(false);
        }//###########&&&&&&&&&&

}
}
