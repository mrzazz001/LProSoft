   

namespace InvAcc.Forms
{
partial class FrmInvExport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInvExport));
            this.panel2 = new System.Windows.Forms.Panel();
            this.Button_Cancel = new DevComponents.DotNetBar.ButtonX();
            this.button_OK = new DevComponents.DotNetBar.ButtonX();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonX_ImportFile = new DevComponents.DotNetBar.ButtonX();
            this.textBox_SearchFilePath = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_Unt = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.textBox_RunNo = new System.Windows.Forms.TextBox();
            this.textBox_Tax = new System.Windows.Forms.TextBox();
            this.textBox_DateExpir = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_Discount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Price = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Qty = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Store = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_ItmNo = new System.Windows.Forms.TextBox();
            this.textBox_NameE = new System.Windows.Forms.TextBox();
            this.textBox_NameA = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ExcelGridView = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExcelGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.Button_Cancel);
            this.panel2.Controls.Add(this.button_OK);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.buttonX_ImportFile);
            this.panel2.Controls.Add(this.textBox_SearchFilePath);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.ExcelGridView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(590, 506);
            this.panel2.TabIndex = 2;
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Button_Cancel.Checked = true;
            this.Button_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Button_Cancel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Button_Cancel.Location = new System.Drawing.Point(4, 147);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(162, 57);
            this.Button_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Button_Cancel.Symbol = "";
            this.Button_Cancel.SymbolSize = 16F;
            this.Button_Cancel.TabIndex = 875;
            this.Button_Cancel.Text = "خـــروج";
            this.Button_Cancel.TextColor = System.Drawing.Color.Black;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // button_OK
            // 
            this.button_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.button_OK.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.button_OK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button_OK.Location = new System.Drawing.Point(168, 147);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(162, 57);
            this.button_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_OK.Symbol = "";
            this.button_OK.SymbolSize = 16F;
            this.button_OK.TabIndex = 11;
            this.button_OK.Text = "موافق";
            this.button_OK.TextColor = System.Drawing.Color.White;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 6F);
            this.textBox1.Location = new System.Drawing.Point(3, 555);
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
            this.buttonX_ImportFile.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
            this.buttonX_ImportFile.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.buttonX_ImportFile.Location = new System.Drawing.Point(332, 147);
            this.buttonX_ImportFile.Name = "buttonX_ImportFile";
            this.buttonX_ImportFile.Size = new System.Drawing.Size(249, 57);
            this.buttonX_ImportFile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
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
            this.groupBox1.Controls.Add(this.textBox_Unt);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.textBox_RunNo);
            this.groupBox1.Controls.Add(this.textBox_Tax);
            this.groupBox1.Controls.Add(this.textBox_DateExpir);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox_Discount);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox_Price);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_Qty);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_Store);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_ItmNo);
            this.groupBox1.Controls.Add(this.textBox_NameE);
            this.groupBox1.Controls.Add(this.textBox_NameA);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(5, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(576, 119);
            this.groupBox1.TabIndex = 867;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تعيين أعمدة القراءة من ملف الأكسيل";
            // 
            // textBox_Unt
            // 
            this.textBox_Unt.BackColor = System.Drawing.Color.White;
            this.textBox_Unt.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox_Unt.ForeColor = System.Drawing.Color.Red;
            this.textBox_Unt.Location = new System.Drawing.Point(17, 23);
            this.textBox_Unt.MaxLength = 2;
            this.textBox_Unt.Name = "textBox_Unt";
            this.textBox_Unt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_Unt.Size = new System.Drawing.Size(61, 22);
            this.textBox_Unt.TabIndex = 918;
            this.textBox_Unt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Unt.TextChanged += new System.EventHandler(this.textBox_ItmNo_TextChanged);
            this.textBox_Unt.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label29.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label29.Location = new System.Drawing.Point(82, 28);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(51, 13);
            this.label29.TabIndex = 919;
            this.label29.Text = "الوحـــــدة";
            // 
            // textBox_RunNo
            // 
            this.textBox_RunNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox_RunNo.ForeColor = System.Drawing.Color.Red;
            this.textBox_RunNo.Location = new System.Drawing.Point(292, 83);
            this.textBox_RunNo.MaxLength = 2;
            this.textBox_RunNo.Name = "textBox_RunNo";
            this.textBox_RunNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_RunNo.Size = new System.Drawing.Size(61, 22);
            this.textBox_RunNo.TabIndex = 917;
            this.textBox_RunNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_RunNo.TextChanged += new System.EventHandler(this.textBox_ItmNo_TextChanged);
            this.textBox_RunNo.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // textBox_Tax
            // 
            this.textBox_Tax.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox_Tax.ForeColor = System.Drawing.Color.Red;
            this.textBox_Tax.Location = new System.Drawing.Point(147, 83);
            this.textBox_Tax.MaxLength = 2;
            this.textBox_Tax.Name = "textBox_Tax";
            this.textBox_Tax.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_Tax.Size = new System.Drawing.Size(61, 22);
            this.textBox_Tax.TabIndex = 916;
            this.textBox_Tax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Tax.TextChanged += new System.EventHandler(this.textBox_ItmNo_TextChanged);
            this.textBox_Tax.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // textBox_DateExpir
            // 
            this.textBox_DateExpir.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox_DateExpir.ForeColor = System.Drawing.Color.Red;
            this.textBox_DateExpir.Location = new System.Drawing.Point(426, 83);
            this.textBox_DateExpir.MaxLength = 2;
            this.textBox_DateExpir.Name = "textBox_DateExpir";
            this.textBox_DateExpir.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_DateExpir.Size = new System.Drawing.Size(61, 22);
            this.textBox_DateExpir.TabIndex = 907;
            this.textBox_DateExpir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_DateExpir.TextChanged += new System.EventHandler(this.textBox_ItmNo_TextChanged);
            this.textBox_DateExpir.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(211, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 880;
            this.label9.Text = "الضريبـــــة %";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(357, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 878;
            this.label10.Text = "رقم التصنيع";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(493, 87);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 13);
            this.label11.TabIndex = 876;
            this.label11.Text = "تاريخ الصلاحية";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(82, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 874;
            this.label7.Text = "الخصم %";
            // 
            // textBox_Discount
            // 
            this.textBox_Discount.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox_Discount.ForeColor = System.Drawing.Color.Red;
            this.textBox_Discount.Location = new System.Drawing.Point(17, 53);
            this.textBox_Discount.MaxLength = 2;
            this.textBox_Discount.Name = "textBox_Discount";
            this.textBox_Discount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_Discount.Size = new System.Drawing.Size(61, 22);
            this.textBox_Discount.TabIndex = 873;
            this.textBox_Discount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Discount.TextChanged += new System.EventHandler(this.textBox_ItmNo_TextChanged);
            this.textBox_Discount.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(211, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 872;
            this.label6.Text = "السعـــــــــــر";
            // 
            // textBox_Price
            // 
            this.textBox_Price.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox_Price.ForeColor = System.Drawing.Color.Red;
            this.textBox_Price.Location = new System.Drawing.Point(147, 53);
            this.textBox_Price.MaxLength = 2;
            this.textBox_Price.Name = "textBox_Price";
            this.textBox_Price.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_Price.Size = new System.Drawing.Size(61, 22);
            this.textBox_Price.TabIndex = 871;
            this.textBox_Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Price.TextChanged += new System.EventHandler(this.textBox_ItmNo_TextChanged);
            this.textBox_Price.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(357, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 870;
            this.label3.Text = "الكميــــــــة";
            // 
            // textBox_Qty
            // 
            this.textBox_Qty.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox_Qty.ForeColor = System.Drawing.Color.Red;
            this.textBox_Qty.Location = new System.Drawing.Point(292, 53);
            this.textBox_Qty.MaxLength = 2;
            this.textBox_Qty.Name = "textBox_Qty";
            this.textBox_Qty.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_Qty.Size = new System.Drawing.Size(61, 22);
            this.textBox_Qty.TabIndex = 869;
            this.textBox_Qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Qty.TextChanged += new System.EventHandler(this.textBox_ItmNo_TextChanged);
            this.textBox_Qty.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(493, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 868;
            this.label2.Text = "المستــــــودع";
            // 
            // textBox_Store
            // 
            this.textBox_Store.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox_Store.ForeColor = System.Drawing.Color.Red;
            this.textBox_Store.Location = new System.Drawing.Point(426, 53);
            this.textBox_Store.MaxLength = 2;
            this.textBox_Store.Name = "textBox_Store";
            this.textBox_Store.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_Store.Size = new System.Drawing.Size(61, 22);
            this.textBox_Store.TabIndex = 867;
            this.textBox_Store.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Store.TextChanged += new System.EventHandler(this.textBox_ItmNo_TextChanged);
            this.textBox_Store.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(493, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 866;
            this.label1.Text = "رقم الصنـــــف";
            // 
            // textBox_ItmNo
            // 
            this.textBox_ItmNo.BackColor = System.Drawing.Color.Yellow;
            this.textBox_ItmNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox_ItmNo.ForeColor = System.Drawing.Color.Red;
            this.textBox_ItmNo.Location = new System.Drawing.Point(426, 23);
            this.textBox_ItmNo.MaxLength = 2;
            this.textBox_ItmNo.Name = "textBox_ItmNo";
            this.textBox_ItmNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_ItmNo.Size = new System.Drawing.Size(61, 22);
            this.textBox_ItmNo.TabIndex = 1;
            this.textBox_ItmNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_ItmNo.Click += new System.EventHandler(this.textBox_EmpNo_Click);
            this.textBox_ItmNo.TextChanged += new System.EventHandler(this.textBox_ItmNo_TextChanged);
            this.textBox_ItmNo.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // textBox_NameE
            // 
            this.textBox_NameE.BackColor = System.Drawing.Color.White;
            this.textBox_NameE.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox_NameE.ForeColor = System.Drawing.Color.Red;
            this.textBox_NameE.Location = new System.Drawing.Point(147, 23);
            this.textBox_NameE.MaxLength = 2;
            this.textBox_NameE.Name = "textBox_NameE";
            this.textBox_NameE.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_NameE.Size = new System.Drawing.Size(61, 22);
            this.textBox_NameE.TabIndex = 6;
            this.textBox_NameE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_NameE.Visible = false;
            this.textBox_NameE.Click += new System.EventHandler(this.textBox_TimeLeave1_Click);
            this.textBox_NameE.TextChanged += new System.EventHandler(this.textBox_ItmNo_TextChanged);
            this.textBox_NameE.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // textBox_NameA
            // 
            this.textBox_NameA.BackColor = System.Drawing.Color.White;
            this.textBox_NameA.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox_NameA.ForeColor = System.Drawing.Color.Red;
            this.textBox_NameA.Location = new System.Drawing.Point(292, 23);
            this.textBox_NameA.MaxLength = 2;
            this.textBox_NameA.Name = "textBox_NameA";
            this.textBox_NameA.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_NameA.Size = new System.Drawing.Size(61, 22);
            this.textBox_NameA.TabIndex = 5;
            this.textBox_NameA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_NameA.Visible = false;
            this.textBox_NameA.Click += new System.EventHandler(this.textBox_Time1_Click);
            this.textBox_NameA.TextChanged += new System.EventHandler(this.textBox_ItmNo_TextChanged);
            this.textBox_NameA.Enter += new System.EventHandler(this.textBox_ItmNo_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(211, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 106;
            this.label5.Text = "إسم انجليزي";
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(357, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 864;
            this.label4.Text = "إسم عربـي";
            this.label4.Visible = false;
            // 
            // ExcelGridView
            // 
            this.ExcelGridView.AllowUserToAddRows = false;
            this.ExcelGridView.AllowUserToDeleteRows = false;
            this.ExcelGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
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
            this.ExcelGridView.Location = new System.Drawing.Point(4, 207);
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
            this.ExcelGridView.Size = new System.Drawing.Size(582, 294);
            this.ExcelGridView.TabIndex = 854;
            this.ExcelGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExcelGridView_CellEndEdit);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SteelBlue;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(590, 18);
            this.panel5.TabIndex = 843;
            // 
            // FrmInvExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(590, 506);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmInvExport";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إستيراد بيانات الأصناف الى الفاتورة";
            this.Load += new System.EventHandler(this.FrmInvExport_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmInvExport_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmInvExport_KeyPress);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExcelGridView)).EndInit();
            this.ResumeLayout(false);

        }//###########&&&&&&&&&&

}
}
