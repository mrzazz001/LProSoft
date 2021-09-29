   

namespace InvAcc.Forms
{
partial class FrmFingerPrintOp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFingerPrintOp));
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonX_ImportFile = new DevComponents.DotNetBar.ButtonX();
            this.textBox_SearchFilePath = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_Cat = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txtDistributors = new System.Windows.Forms.TextBox();
            this.txtSentence = new System.Windows.Forms.TextBox();
            this.txtSectorial = new System.Windows.Forms.TextBox();
            this.textBox_VIP = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtLegates = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtBarcod5 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtPrice5 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtPack5 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtUnit5 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtBarcod4 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtPrice4 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtPack4 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtUnit4 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBarcod3 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPrice3 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPack3 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtUnit3 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBarcod2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPrice2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPack2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtUnit2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBarcod1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrice1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPack1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUnit1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_ItmNo = new System.Windows.Forms.TextBox();
            this.textBox_NameE = new System.Windows.Forms.TextBox();
            this.textBox_NameA = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ExcelGridView = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Button_Cancel = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
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
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
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
            this.panel2.Size = new System.Drawing.Size(756, 506);
            this.panel2.TabIndex = 2;
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
            this.buttonX_ImportFile.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_ImportFile.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.buttonX_ImportFile.Location = new System.Drawing.Point(4, 27);
            this.buttonX_ImportFile.Name = "buttonX_ImportFile";
            this.buttonX_ImportFile.Size = new System.Drawing.Size(162, 57);
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
            this.groupBox1.Controls.Add(this.textBox_Cat);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.txtDistributors);
            this.groupBox1.Controls.Add(this.txtSentence);
            this.groupBox1.Controls.Add(this.txtSectorial);
            this.groupBox1.Controls.Add(this.textBox_VIP);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.txtLegates);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.txtBarcod5);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.txtPrice5);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.txtPack5);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.txtUnit5);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtBarcod4);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.txtPrice4);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.txtPack4);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.txtUnit4);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtBarcod3);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtPrice3);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtPack3);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtUnit3);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtBarcod2);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtPrice2);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtPack2);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtUnit2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtBarcod1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtPrice1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPack1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUnit1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_ItmNo);
            this.groupBox1.Controls.Add(this.textBox_NameE);
            this.groupBox1.Controls.Add(this.textBox_NameA);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(172, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(576, 248);
            this.groupBox1.TabIndex = 867;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تخصيص";
            // 
            // textBox_Cat
            // 
            this.textBox_Cat.BackColor = System.Drawing.Color.Yellow;
            this.textBox_Cat.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox_Cat.ForeColor = System.Drawing.Color.Red;
            this.textBox_Cat.Location = new System.Drawing.Point(21, 23);
            this.textBox_Cat.MaxLength = 2;
            this.textBox_Cat.Name = "textBox_Cat";
            this.textBox_Cat.Size = new System.Drawing.Size(61, 22);
            this.textBox_Cat.TabIndex = 918;
            this.textBox_Cat.Text = "C";
            this.textBox_Cat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label29.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label29.Location = new System.Drawing.Point(86, 28);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(44, 13);
            this.label29.TabIndex = 919;
            this.label29.Text = "التصنيف";
            // 
            // txtDistributors
            // 
            this.txtDistributors.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtDistributors.ForeColor = System.Drawing.Color.Red;
            this.txtDistributors.Location = new System.Drawing.Point(364, 216);
            this.txtDistributors.MaxLength = 2;
            this.txtDistributors.Name = "txtDistributors";
            this.txtDistributors.Size = new System.Drawing.Size(61, 22);
            this.txtDistributors.TabIndex = 917;
            this.txtDistributors.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSentence
            // 
            this.txtSentence.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtSentence.ForeColor = System.Drawing.Color.Red;
            this.txtSentence.Location = new System.Drawing.Point(250, 216);
            this.txtSentence.MaxLength = 2;
            this.txtSentence.Name = "txtSentence";
            this.txtSentence.Size = new System.Drawing.Size(61, 22);
            this.txtSentence.TabIndex = 916;
            this.txtSentence.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSectorial
            // 
            this.txtSectorial.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtSectorial.ForeColor = System.Drawing.Color.Red;
            this.txtSectorial.Location = new System.Drawing.Point(134, 216);
            this.txtSectorial.MaxLength = 2;
            this.txtSectorial.Name = "txtSectorial";
            this.txtSectorial.Size = new System.Drawing.Size(61, 22);
            this.txtSectorial.TabIndex = 915;
            this.txtSectorial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_VIP
            // 
            this.textBox_VIP.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox_VIP.ForeColor = System.Drawing.Color.Red;
            this.textBox_VIP.Location = new System.Drawing.Point(28, 216);
            this.textBox_VIP.MaxLength = 2;
            this.textBox_VIP.Name = "textBox_VIP";
            this.textBox_VIP.Size = new System.Drawing.Size(61, 22);
            this.textBox_VIP.TabIndex = 914;
            this.textBox_VIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic);
            this.label28.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label28.Location = new System.Drawing.Point(244, 193);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(72, 16);
            this.label28.TabIndex = 910;
            this.label28.Text = "سعر الجملة";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic);
            this.label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label24.Location = new System.Drawing.Point(472, 193);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(79, 16);
            this.label24.TabIndex = 909;
            this.label24.Text = "سعر المندوب";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic);
            this.label27.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label27.Location = new System.Drawing.Point(359, 193);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(70, 16);
            this.label27.TabIndex = 908;
            this.label27.Text = "سعر الموزع";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic);
            this.label26.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label26.Location = new System.Drawing.Point(32, 193);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(53, 16);
            this.label26.TabIndex = 912;
            this.label26.Text = "سعر آخر";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic);
            this.label25.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label25.Location = new System.Drawing.Point(128, 193);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(73, 16);
            this.label25.TabIndex = 911;
            this.label25.Text = "سعر التجزئة";
            // 
            // txtLegates
            // 
            this.txtLegates.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtLegates.ForeColor = System.Drawing.Color.Red;
            this.txtLegates.Location = new System.Drawing.Point(481, 216);
            this.txtLegates.MaxLength = 2;
            this.txtLegates.Name = "txtLegates";
            this.txtLegates.Size = new System.Drawing.Size(61, 22);
            this.txtLegates.TabIndex = 907;
            this.txtLegates.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label20.Location = new System.Drawing.Point(88, 165);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(66, 13);
            this.label20.TabIndex = 906;
            this.label20.Text = "رقم الباركود :";
            // 
            // txtBarcod5
            // 
            this.txtBarcod5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtBarcod5.ForeColor = System.Drawing.Color.Red;
            this.txtBarcod5.Location = new System.Drawing.Point(21, 161);
            this.txtBarcod5.MaxLength = 2;
            this.txtBarcod5.Name = "txtBarcod5";
            this.txtBarcod5.Size = new System.Drawing.Size(61, 22);
            this.txtBarcod5.TabIndex = 905;
            this.txtBarcod5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label21.Location = new System.Drawing.Point(231, 165);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(59, 13);
            this.label21.TabIndex = 904;
            this.label21.Text = "سعر البيع :";
            // 
            // txtPrice5
            // 
            this.txtPrice5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtPrice5.ForeColor = System.Drawing.Color.Red;
            this.txtPrice5.Location = new System.Drawing.Point(165, 161);
            this.txtPrice5.MaxLength = 2;
            this.txtPrice5.Name = "txtPrice5";
            this.txtPrice5.Size = new System.Drawing.Size(61, 22);
            this.txtPrice5.TabIndex = 903;
            this.txtPrice5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(368, 165);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(44, 13);
            this.label22.TabIndex = 902;
            this.label22.Text = "التعبئة :";
            // 
            // txtPack5
            // 
            this.txtPack5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtPack5.ForeColor = System.Drawing.Color.Red;
            this.txtPack5.Location = new System.Drawing.Point(301, 161);
            this.txtPack5.MaxLength = 2;
            this.txtPack5.Name = "txtPack5";
            this.txtPack5.Size = new System.Drawing.Size(61, 22);
            this.txtPack5.TabIndex = 901;
            this.txtPack5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label23.Location = new System.Drawing.Point(503, 165);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(52, 13);
            this.label23.TabIndex = 900;
            this.label23.Text = "الوحدة 5 :";
            // 
            // txtUnit5
            // 
            this.txtUnit5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtUnit5.ForeColor = System.Drawing.Color.Red;
            this.txtUnit5.Location = new System.Drawing.Point(434, 161);
            this.txtUnit5.MaxLength = 2;
            this.txtUnit5.Name = "txtUnit5";
            this.txtUnit5.Size = new System.Drawing.Size(61, 22);
            this.txtUnit5.TabIndex = 899;
            this.txtUnit5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(88, 138);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 13);
            this.label16.TabIndex = 898;
            this.label16.Text = "رقم الباركود :";
            // 
            // txtBarcod4
            // 
            this.txtBarcod4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtBarcod4.ForeColor = System.Drawing.Color.Red;
            this.txtBarcod4.Location = new System.Drawing.Point(21, 134);
            this.txtBarcod4.MaxLength = 2;
            this.txtBarcod4.Name = "txtBarcod4";
            this.txtBarcod4.Size = new System.Drawing.Size(61, 22);
            this.txtBarcod4.TabIndex = 897;
            this.txtBarcod4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(231, 138);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 13);
            this.label17.TabIndex = 896;
            this.label17.Text = "سعر البيع :";
            // 
            // txtPrice4
            // 
            this.txtPrice4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtPrice4.ForeColor = System.Drawing.Color.Red;
            this.txtPrice4.Location = new System.Drawing.Point(165, 134);
            this.txtPrice4.MaxLength = 2;
            this.txtPrice4.Name = "txtPrice4";
            this.txtPrice4.Size = new System.Drawing.Size(61, 22);
            this.txtPrice4.TabIndex = 895;
            this.txtPrice4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(368, 138);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(44, 13);
            this.label18.TabIndex = 894;
            this.label18.Text = "التعبئة :";
            // 
            // txtPack4
            // 
            this.txtPack4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtPack4.ForeColor = System.Drawing.Color.Red;
            this.txtPack4.Location = new System.Drawing.Point(301, 134);
            this.txtPack4.MaxLength = 2;
            this.txtPack4.Name = "txtPack4";
            this.txtPack4.Size = new System.Drawing.Size(61, 22);
            this.txtPack4.TabIndex = 893;
            this.txtPack4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label19.Location = new System.Drawing.Point(503, 138);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(52, 13);
            this.label19.TabIndex = 892;
            this.label19.Text = "الوحدة 4 :";
            // 
            // txtUnit4
            // 
            this.txtUnit4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtUnit4.ForeColor = System.Drawing.Color.Red;
            this.txtUnit4.Location = new System.Drawing.Point(434, 134);
            this.txtUnit4.MaxLength = 2;
            this.txtUnit4.Name = "txtUnit4";
            this.txtUnit4.Size = new System.Drawing.Size(61, 22);
            this.txtUnit4.TabIndex = 891;
            this.txtUnit4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(88, 111);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 13);
            this.label12.TabIndex = 890;
            this.label12.Text = "رقم الباركود :";
            // 
            // txtBarcod3
            // 
            this.txtBarcod3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtBarcod3.ForeColor = System.Drawing.Color.Red;
            this.txtBarcod3.Location = new System.Drawing.Point(21, 107);
            this.txtBarcod3.MaxLength = 2;
            this.txtBarcod3.Name = "txtBarcod3";
            this.txtBarcod3.Size = new System.Drawing.Size(61, 22);
            this.txtBarcod3.TabIndex = 889;
            this.txtBarcod3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(231, 111);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 13);
            this.label13.TabIndex = 888;
            this.label13.Text = "سعر البيع :";
            // 
            // txtPrice3
            // 
            this.txtPrice3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtPrice3.ForeColor = System.Drawing.Color.Red;
            this.txtPrice3.Location = new System.Drawing.Point(165, 107);
            this.txtPrice3.MaxLength = 2;
            this.txtPrice3.Name = "txtPrice3";
            this.txtPrice3.Size = new System.Drawing.Size(61, 22);
            this.txtPrice3.TabIndex = 887;
            this.txtPrice3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(368, 111);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 13);
            this.label14.TabIndex = 886;
            this.label14.Text = "التعبئة :";
            // 
            // txtPack3
            // 
            this.txtPack3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtPack3.ForeColor = System.Drawing.Color.Red;
            this.txtPack3.Location = new System.Drawing.Point(301, 107);
            this.txtPack3.MaxLength = 2;
            this.txtPack3.Name = "txtPack3";
            this.txtPack3.Size = new System.Drawing.Size(61, 22);
            this.txtPack3.TabIndex = 885;
            this.txtPack3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(503, 111);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 13);
            this.label15.TabIndex = 884;
            this.label15.Text = "الوحدة 3 :";
            // 
            // txtUnit3
            // 
            this.txtUnit3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtUnit3.ForeColor = System.Drawing.Color.Red;
            this.txtUnit3.Location = new System.Drawing.Point(434, 107);
            this.txtUnit3.MaxLength = 2;
            this.txtUnit3.Name = "txtUnit3";
            this.txtUnit3.Size = new System.Drawing.Size(61, 22);
            this.txtUnit3.TabIndex = 883;
            this.txtUnit3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(88, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 882;
            this.label8.Text = "رقم الباركود :";
            // 
            // txtBarcod2
            // 
            this.txtBarcod2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtBarcod2.ForeColor = System.Drawing.Color.Red;
            this.txtBarcod2.Location = new System.Drawing.Point(21, 80);
            this.txtBarcod2.MaxLength = 2;
            this.txtBarcod2.Name = "txtBarcod2";
            this.txtBarcod2.Size = new System.Drawing.Size(61, 22);
            this.txtBarcod2.TabIndex = 881;
            this.txtBarcod2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(231, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 880;
            this.label9.Text = "سعر البيع :";
            // 
            // txtPrice2
            // 
            this.txtPrice2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtPrice2.ForeColor = System.Drawing.Color.Red;
            this.txtPrice2.Location = new System.Drawing.Point(165, 80);
            this.txtPrice2.MaxLength = 2;
            this.txtPrice2.Name = "txtPrice2";
            this.txtPrice2.Size = new System.Drawing.Size(61, 22);
            this.txtPrice2.TabIndex = 879;
            this.txtPrice2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(368, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 878;
            this.label10.Text = "التعبئة :";
            // 
            // txtPack2
            // 
            this.txtPack2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtPack2.ForeColor = System.Drawing.Color.Red;
            this.txtPack2.Location = new System.Drawing.Point(301, 80);
            this.txtPack2.MaxLength = 2;
            this.txtPack2.Name = "txtPack2";
            this.txtPack2.Size = new System.Drawing.Size(61, 22);
            this.txtPack2.TabIndex = 877;
            this.txtPack2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(503, 84);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 876;
            this.label11.Text = "الوحدة 2 :";
            // 
            // txtUnit2
            // 
            this.txtUnit2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtUnit2.ForeColor = System.Drawing.Color.Red;
            this.txtUnit2.Location = new System.Drawing.Point(434, 80);
            this.txtUnit2.MaxLength = 2;
            this.txtUnit2.Name = "txtUnit2";
            this.txtUnit2.Size = new System.Drawing.Size(61, 22);
            this.txtUnit2.TabIndex = 875;
            this.txtUnit2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(86, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 874;
            this.label7.Text = "رقم الباركود :";
            // 
            // txtBarcod1
            // 
            this.txtBarcod1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtBarcod1.ForeColor = System.Drawing.Color.Red;
            this.txtBarcod1.Location = new System.Drawing.Point(21, 53);
            this.txtBarcod1.MaxLength = 2;
            this.txtBarcod1.Name = "txtBarcod1";
            this.txtBarcod1.Size = new System.Drawing.Size(61, 22);
            this.txtBarcod1.TabIndex = 873;
            this.txtBarcod1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(229, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 872;
            this.label6.Text = "سعر البيع :";
            // 
            // txtPrice1
            // 
            this.txtPrice1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtPrice1.ForeColor = System.Drawing.Color.Red;
            this.txtPrice1.Location = new System.Drawing.Point(165, 53);
            this.txtPrice1.MaxLength = 2;
            this.txtPrice1.Name = "txtPrice1";
            this.txtPrice1.Size = new System.Drawing.Size(61, 22);
            this.txtPrice1.TabIndex = 871;
            this.txtPrice1.Text = "E";
            this.txtPrice1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(366, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 870;
            this.label3.Text = "التعبئة :";
            // 
            // txtPack1
            // 
            this.txtPack1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtPack1.ForeColor = System.Drawing.Color.Red;
            this.txtPack1.Location = new System.Drawing.Point(301, 53);
            this.txtPack1.MaxLength = 2;
            this.txtPack1.Name = "txtPack1";
            this.txtPack1.Size = new System.Drawing.Size(61, 22);
            this.txtPack1.TabIndex = 869;
            this.txtPack1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(501, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 868;
            this.label2.Text = "الوحدة 1 :";
            // 
            // txtUnit1
            // 
            this.txtUnit1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtUnit1.ForeColor = System.Drawing.Color.Red;
            this.txtUnit1.Location = new System.Drawing.Point(434, 53);
            this.txtUnit1.MaxLength = 2;
            this.txtUnit1.Name = "txtUnit1";
            this.txtUnit1.Size = new System.Drawing.Size(61, 22);
            this.txtUnit1.TabIndex = 867;
            this.txtUnit1.Text = "D";
            this.txtUnit1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(501, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 866;
            this.label1.Text = "رقم الصنف";
            // 
            // textBox_ItmNo
            // 
            this.textBox_ItmNo.BackColor = System.Drawing.Color.Yellow;
            this.textBox_ItmNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox_ItmNo.ForeColor = System.Drawing.Color.Red;
            this.textBox_ItmNo.Location = new System.Drawing.Point(434, 23);
            this.textBox_ItmNo.MaxLength = 2;
            this.textBox_ItmNo.Name = "textBox_ItmNo";
            this.textBox_ItmNo.Size = new System.Drawing.Size(61, 22);
            this.textBox_ItmNo.TabIndex = 1;
            this.textBox_ItmNo.Text = "A";
            this.textBox_ItmNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_ItmNo.Click += new System.EventHandler(this.textBox_EmpNo_Click);
            // 
            // textBox_NameE
            // 
            this.textBox_NameE.BackColor = System.Drawing.Color.Yellow;
            this.textBox_NameE.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox_NameE.ForeColor = System.Drawing.Color.Red;
            this.textBox_NameE.Location = new System.Drawing.Point(165, 23);
            this.textBox_NameE.MaxLength = 2;
            this.textBox_NameE.Name = "textBox_NameE";
            this.textBox_NameE.Size = new System.Drawing.Size(61, 22);
            this.textBox_NameE.TabIndex = 6;
            this.textBox_NameE.Text = "B";
            this.textBox_NameE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_NameE.Click += new System.EventHandler(this.textBox_TimeLeave1_Click);
            // 
            // textBox_NameA
            // 
            this.textBox_NameA.BackColor = System.Drawing.Color.Yellow;
            this.textBox_NameA.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.textBox_NameA.ForeColor = System.Drawing.Color.Red;
            this.textBox_NameA.Location = new System.Drawing.Point(301, 23);
            this.textBox_NameA.MaxLength = 2;
            this.textBox_NameA.Name = "textBox_NameA";
            this.textBox_NameA.Size = new System.Drawing.Size(61, 22);
            this.textBox_NameA.TabIndex = 5;
            this.textBox_NameA.Text = "B";
            this.textBox_NameA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_NameA.Click += new System.EventHandler(this.textBox_Time1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(229, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 106;
            this.label5.Text = "إسم انجليزي";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(366, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 864;
            this.label4.Text = "إسم عربي";
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
            this.ExcelGridView.Location = new System.Drawing.Point(4, 277);
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
            this.ExcelGridView.Size = new System.Drawing.Size(747, 224);
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
            this.panel4.Location = new System.Drawing.Point(4, 86);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(162, 185);
            this.panel4.TabIndex = 872;
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Button_Cancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Button_Cancel.Location = new System.Drawing.Point(5, 91);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(150, 89);
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
            this.button_OK.Size = new System.Drawing.Size(150, 89);
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
            this.panel5.Size = new System.Drawing.Size(756, 18);
            this.panel5.TabIndex = 843;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // FrmFingerPrintOp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(756, 506);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = (InvAcc.Properties.Resources.favicon);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmFingerPrintOp";
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "استيراد بيانات الأصناف";
            this.Load += new System.EventHandler(this.FrmFingerPrintOp_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmFingerPrintOp_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmFingerPrintOp_KeyPress);
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
