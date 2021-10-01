   

namespace InvAcc.Forms
{
partial class FrmCarS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCarS));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_CarTyp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.button_AddCar = new DevComponents.DotNetBar.ButtonX();
            this.button_SrchCarTyp = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_PlayCardExpDat = new System.Windows.Forms.Label();
            this.label_CardPlayIssDat = new System.Windows.Forms.Label();
            this.label_CardPlayNo = new System.Windows.Forms.Label();
            this.dateTimeInput_PlayCardEndDate = new System.Windows.Forms.MaskedTextBox();
            this.dateTimeInput_PlayCardBeginDate = new System.Windows.Forms.MaskedTextBox();
            this.textBox_PlayCardNo = new System.Windows.Forms.TextBox();
            this.textBox_Note = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBox_NameE = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.textBox_NameA = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.textBox_ID = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.ribbonBar_Tasks = new DevComponents.DotNetBar.RibbonBar();
            this.superTabControl_Main1 = new DevComponents.DotNetBar.SuperTabControl();
            this.Button_Close = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Search = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Delete = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Save = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Add = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            this.superTabControl_Main2 = new DevComponents.DotNetBar.SuperTabControl();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.Button_First = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Prev = new DevComponents.DotNetBar.ButtonItem();
            this.TextBox_Index = new DevComponents.DotNetBar.TextBoxItem();
            this.Label_Count = new DevComponents.DotNetBar.LabelItem();
            this.lable_Records = new DevComponents.DotNetBar.LabelItem();
            this.Button_Next = new DevComponents.DotNetBar.ButtonItem();
            this.Button_Last = new DevComponents.DotNetBar.ButtonItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.timerInfoBallon = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.barTopDockSite = new DevComponents.DotNetBar.DockSite();
            this.barBottomDockSite = new DevComponents.DotNetBar.DockSite();
            this.dotNetBarManager1 = new DevComponents.DotNetBar.DotNetBarManager(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.barLeftDockSite = new DevComponents.DotNetBar.DockSite();
            this.barRightDockSite = new DevComponents.DotNetBar.DockSite();
            this.dockSite4 = new DevComponents.DotNetBar.DockSite();
            this.dockSite1 = new DevComponents.DotNetBar.DockSite();
            this.dockSite2 = new DevComponents.DotNetBar.DockSite();
            this.dockSite3 = new DevComponents.DotNetBar.DockSite();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_Rep = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Det = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);  this.netResize1.LabelsAutoEllipse = false;
            this.netResize2 = new Softgroup.NetResize.NetResize(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.ribbonBar1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ribbonBar_Tasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main2)).BeginInit();
            this.panel1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.netResize2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // panelEx2
            // 
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx2.Location = new System.Drawing.Point(0, -224);
            this.panelEx2.MinimumSize = new System.Drawing.Size(659, 433);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(659, 433);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 0;
            this.panelEx2.Text = "Click to collapse";
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
            this.ribbonBar1.Controls.Add(this.label2);
            this.ribbonBar1.Controls.Add(this.comboBox_CarTyp);
            this.ribbonBar1.Controls.Add(this.button_AddCar);
            this.ribbonBar1.Controls.Add(this.button_SrchCarTyp);
            this.ribbonBar1.Controls.Add(this.groupBox1);
            this.ribbonBar1.Controls.Add(this.textBox_Note);
            this.ribbonBar1.Controls.Add(this.textBox_NameE);
            this.ribbonBar1.Controls.Add(this.label40);
            this.ribbonBar1.Controls.Add(this.textBox_NameA);
            this.ribbonBar1.Controls.Add(this.label36);
            this.ribbonBar1.Controls.Add(this.textBox_ID);
            this.ribbonBar1.Controls.Add(this.label38);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonBar1.DragDropSupport = true;
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(649, 209);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.ribbonBar1.TabIndex = 867;
            this.ribbonBar1.Tag = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.Gainsboro;
            this.ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.Black;
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(250, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 6696;
            this.label2.Text = "ماركة السيارة :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // comboBox_CarTyp
            // 
            this.comboBox_CarTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_CarTyp.DisplayMember = "Text";
            this.comboBox_CarTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_CarTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CarTyp.FormattingEnabled = true;
            this.comboBox_CarTyp.ItemHeight = 15;
            this.comboBox_CarTyp.Location = new System.Drawing.Point(111, 15);
            this.comboBox_CarTyp.Name = "comboBox_CarTyp";
            this.comboBox_CarTyp.Size = new System.Drawing.Size(137, 21);
            this.comboBox_CarTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBox_CarTyp.TabIndex = 2;
            this.comboBox_CarTyp.SelectedIndexChanged += new System.EventHandler(this.comboBox_CarTyp_SelectedIndexChanged);
            // 
            // button_AddCar
            // 
            this.button_AddCar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_AddCar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_AddCar.Location = new System.Drawing.Point(57, 15);
            this.button_AddCar.Name = "button_AddCar";
            this.button_AddCar.Size = new System.Drawing.Size(26, 20);
            this.button_AddCar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_AddCar.Symbol = "";
            this.button_AddCar.SymbolSize = 11F;
            this.button_AddCar.TabIndex = 6695;
            this.button_AddCar.TextColor = System.Drawing.Color.SteelBlue;
            this.button_AddCar.Click += new System.EventHandler(this.button_AddCar_Click);
            // 
            // button_SrchCarTyp
            // 
            this.button_SrchCarTyp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_SrchCarTyp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchCarTyp.Location = new System.Drawing.Point(84, 15);
            this.button_SrchCarTyp.Name = "button_SrchCarTyp";
            this.button_SrchCarTyp.Size = new System.Drawing.Size(26, 20);
            this.button_SrchCarTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchCarTyp.Symbol = "";
            this.button_SrchCarTyp.SymbolSize = 12F;
            this.button_SrchCarTyp.TabIndex = 6694;
            this.button_SrchCarTyp.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchCarTyp.Click += new System.EventHandler(this.button_SrchCarTyp_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_PlayCardExpDat);
            this.groupBox1.Controls.Add(this.label_CardPlayIssDat);
            this.groupBox1.Controls.Add(this.label_CardPlayNo);
            this.groupBox1.Controls.Add(this.dateTimeInput_PlayCardEndDate);
            this.groupBox1.Controls.Add(this.dateTimeInput_PlayCardBeginDate);
            this.groupBox1.Controls.Add(this.textBox_PlayCardNo);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(108, 355);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(539, 55);
            this.groupBox1.TabIndex = 6686;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "بيانات كرت التشغيل";
            this.groupBox1.Visible = false;
            // 
            // label_PlayCardExpDat
            // 
            this.label_PlayCardExpDat.AutoSize = true;
            this.label_PlayCardExpDat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_PlayCardExpDat.Location = new System.Drawing.Point(538, -57);
            this.label_PlayCardExpDat.Name = "label_PlayCardExpDat";
            this.label_PlayCardExpDat.Size = new System.Drawing.Size(35, 13);
            this.label_PlayCardExpDat.TabIndex = 12;
            this.label_PlayCardExpDat.Text = "الرقم";
            // 
            // label_CardPlayIssDat
            // 
            this.label_CardPlayIssDat.AutoSize = true;
            this.label_CardPlayIssDat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_CardPlayIssDat.Location = new System.Drawing.Point(349, -57);
            this.label_CardPlayIssDat.Name = "label_CardPlayIssDat";
            this.label_CardPlayIssDat.Size = new System.Drawing.Size(73, 13);
            this.label_CardPlayIssDat.TabIndex = 10;
            this.label_CardPlayIssDat.Text = "تاريخ الاصدار";
            // 
            // label_CardPlayNo
            // 
            this.label_CardPlayNo.AutoSize = true;
            this.label_CardPlayNo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_CardPlayNo.Location = new System.Drawing.Point(164, -56);
            this.label_CardPlayNo.Name = "label_CardPlayNo";
            this.label_CardPlayNo.Size = new System.Drawing.Size(71, 13);
            this.label_CardPlayNo.TabIndex = 8;
            this.label_CardPlayNo.Text = "تاريخ الانتهاء";
            // 
            // dateTimeInput_PlayCardEndDate
            // 
            this.dateTimeInput_PlayCardEndDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dateTimeInput_PlayCardEndDate.Location = new System.Drawing.Point(56, -61);
            this.dateTimeInput_PlayCardEndDate.Mask = "0000/00/00";
            this.dateTimeInput_PlayCardEndDate.Name = "dateTimeInput_PlayCardEndDate";
            this.dateTimeInput_PlayCardEndDate.Size = new System.Drawing.Size(105, 20);
            this.dateTimeInput_PlayCardEndDate.TabIndex = 17;
            this.dateTimeInput_PlayCardEndDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dateTimeInput_PlayCardBeginDate
            // 
            this.dateTimeInput_PlayCardBeginDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dateTimeInput_PlayCardBeginDate.Location = new System.Drawing.Point(240, -61);
            this.dateTimeInput_PlayCardBeginDate.Mask = "0000/00/00";
            this.dateTimeInput_PlayCardBeginDate.Name = "dateTimeInput_PlayCardBeginDate";
            this.dateTimeInput_PlayCardBeginDate.Size = new System.Drawing.Size(105, 20);
            this.dateTimeInput_PlayCardBeginDate.TabIndex = 16;
            this.dateTimeInput_PlayCardBeginDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_PlayCardNo
            // 
            this.textBox_PlayCardNo.BackColor = System.Drawing.Color.White;
            this.textBox_PlayCardNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_PlayCardNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_PlayCardNo.ForeColor = System.Drawing.Color.Black;
            this.textBox_PlayCardNo.Location = new System.Drawing.Point(426, -61);
            this.textBox_PlayCardNo.MaxLength = 20;
            this.textBox_PlayCardNo.Name = "textBox_PlayCardNo";
            this.netResize2.SetResizeTextBoxMultiline(this.textBox_PlayCardNo, false);
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_PlayCardNo, false);
            this.textBox_PlayCardNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_PlayCardNo.Size = new System.Drawing.Size(106, 20);
            this.textBox_PlayCardNo.TabIndex = 15;
            this.textBox_PlayCardNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Note
            // 
            this.textBox_Note.BackColor = System.Drawing.Color.AliceBlue;
            // 
            // 
            // 
            this.textBox_Note.Border.Class = "TextBoxBorder";
            this.textBox_Note.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_Note.ButtonCustom.Visible = true;
            this.textBox_Note.ForeColor = System.Drawing.Color.Black;
            this.textBox_Note.Location = new System.Drawing.Point(57, 101);
            this.textBox_Note.Multiline = true;
            this.textBox_Note.Name = "textBox_Note";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Note, false);
            this.netResize2.SetResizeTextBoxMultiline(this.textBox_Note, false);
            this.textBox_Note.Size = new System.Drawing.Size(517, 39);
            this.textBox_Note.TabIndex = 9;
            this.textBox_Note.WatermarkColor = System.Drawing.Color.RosyBrown;
            this.textBox_Note.WatermarkFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Note.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.textBox_Note.WatermarkText = "ملاحظـــــــات السيارة";
            this.textBox_Note.Click += new System.EventHandler(this.textBox_Note_Click);
            // 
            // textBox_NameE
            // 
            this.textBox_NameE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_NameE.Font = new System.Drawing.Font("Tahoma", 8F);
            this.textBox_NameE.ForeColor = System.Drawing.Color.Black;
            this.textBox_NameE.Location = new System.Drawing.Point(57, 75);
            this.textBox_NameE.MaxLength = 30;
            this.textBox_NameE.Name = "textBox_NameE";
            this.netResize2.SetResizeTextBoxMultiline(this.textBox_NameE, false);
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_NameE, false);
            this.textBox_NameE.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_NameE.Size = new System.Drawing.Size(395, 20);
            this.textBox_NameE.TabIndex = 5;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.BackColor = System.Drawing.Color.Transparent;
            this.label40.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label40.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label40.Location = new System.Drawing.Point(459, 79);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(119, 13);
            this.label40.TabIndex = 85;
            this.label40.Text = "إسم السيارة - انجليزي :";
            // 
            // textBox_NameA
            // 
            this.textBox_NameA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_NameA.Font = new System.Drawing.Font("Tahoma", 8F);
            this.textBox_NameA.ForeColor = System.Drawing.Color.Black;
            this.textBox_NameA.Location = new System.Drawing.Point(57, 42);
            this.textBox_NameA.MaxLength = 30;
            this.textBox_NameA.Name = "textBox_NameA";
            this.netResize2.SetResizeTextBoxMultiline(this.textBox_NameA, false);
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_NameA, false);
            this.textBox_NameA.Size = new System.Drawing.Size(395, 20);
            this.textBox_NameA.TabIndex = 4;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.Transparent;
            this.label36.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label36.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label36.Location = new System.Drawing.Point(459, 46);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(118, 13);
            this.label36.TabIndex = 83;
            this.label36.Text = "إسم السيارة - عربـــي :";
            // 
            // textBox_ID
            // 
            this.textBox_ID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.textBox_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_ID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBox_ID.Location = new System.Drawing.Point(367, 15);
            this.textBox_ID.Name = "textBox_ID";
            this.netResize2.SetResizeTextBoxMultiline(this.textBox_ID, false);
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_ID, false);
            this.textBox_ID.Size = new System.Drawing.Size(85, 21);
            this.textBox_ID.TabIndex = 1;
            this.textBox_ID.TextChanged += new System.EventHandler(this.textBox_ID_TextChanged);
            this.textBox_ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ID_KeyPress);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.BackColor = System.Drawing.Color.Transparent;
            this.label38.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label38.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label38.Location = new System.Drawing.Point(459, 19);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(75, 13);
            this.label38.TabIndex = 81;
            this.label38.Text = "الرمـــــــــــــز :";
            this.label38.Click += new System.EventHandler(this.label38_Click);
            // 
            // ribbonBar_Tasks
            // 
            this.ribbonBar_Tasks.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar_Tasks.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar_Tasks.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar_Tasks.ContainerControlProcessDialogKey = true;
            this.ribbonBar_Tasks.Controls.Add(this.superTabControl_Main1);
            this.ribbonBar_Tasks.Controls.Add(this.superTabControl_Main2);
            this.ribbonBar_Tasks.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ribbonBar_Tasks.DragDropSupport = true;
            this.ribbonBar_Tasks.Location = new System.Drawing.Point(0, 158);
            this.ribbonBar_Tasks.Name = "ribbonBar_Tasks";
            this.ribbonBar_Tasks.Size = new System.Drawing.Size(649, 51);
            this.ribbonBar_Tasks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar_Tasks.TabIndex = 868;
            this.ribbonBar_Tasks.Tag = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // 
            // 
            this.ribbonBar_Tasks.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar_Tasks.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar_Tasks.TitleVisible = false;
            // 
            // superTabControl_Main1
            // 
            this.superTabControl_Main1.BackColor = System.Drawing.Color.White;
            this.superTabControl_Main1.CausesValidation = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl_Main1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl_Main1.ControlBox.MenuBox.Name = "";
            this.superTabControl_Main1.ControlBox.Name = "";
            this.superTabControl_Main1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl_Main1.ControlBox.MenuBox,
            this.superTabControl_Main1.ControlBox.CloseBox});
            this.superTabControl_Main1.ControlBox.Visible = false;
            this.superTabControl_Main1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl_Main1.ForeColor = System.Drawing.Color.Black;
            this.superTabControl_Main1.ItemPadding.Bottom = 4;
            this.superTabControl_Main1.ItemPadding.Left = 2;
            this.superTabControl_Main1.ItemPadding.Top = 4;
            this.superTabControl_Main1.Location = new System.Drawing.Point(0, 0);
            this.superTabControl_Main1.Name = "superTabControl_Main1";
            this.superTabControl_Main1.ReorderTabsEnabled = true;
            this.superTabControl_Main1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.superTabControl_Main1.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_Main1.SelectedTabIndex = -1;
            this.superTabControl_Main1.Size = new System.Drawing.Size(239, 51);
            this.superTabControl_Main1.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_Main1.TabIndex = 10;
            this.superTabControl_Main1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.Button_Close,
            this.Button_Search,
            this.Button_Delete,
            this.Button_Save,
            this.Button_Add,
            this.labelItem2});
            this.superTabControl_Main1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.superTabControl_Main1.Text = "superTabControl3";
            this.superTabControl_Main1.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            // 
            // Button_Close
            // 
            this.Button_Close.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Close.Checked = true;
            this.Button_Close.FontBold = true;
            this.Button_Close.FontItalic = true;
            this.Button_Close.ForeColor = System.Drawing.Color.Black;
            this.Button_Close.Image = ((System.Drawing.Image)(resources.GetObject("Button_Close.Image")));
            this.Button_Close.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Close.ImagePaddingHorizontal = 15;
            this.Button_Close.ImagePaddingVertical = 11;
            this.Button_Close.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Close.Name = "Button_Close";
            this.Button_Close.Stretch = true;
            this.Button_Close.SubItemsExpandWidth = 14;
            this.Button_Close.Symbol = "";
            this.Button_Close.SymbolSize = 15F;
            this.Button_Close.Text = "إغلاق";
            this.Button_Close.Tooltip = "إغلاق النافذة الحالية";
            // 
            // Button_Search
            // 
            this.Button_Search.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Search.FontBold = true;
            this.Button_Search.FontItalic = true;
            this.Button_Search.ForeColor = System.Drawing.Color.Green;
            this.Button_Search.Image = ((System.Drawing.Image)(resources.GetObject("Button_Search.Image")));
            this.Button_Search.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Search.ImagePaddingHorizontal = 15;
            this.Button_Search.ImagePaddingVertical = 11;
            this.Button_Search.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Search.Name = "Button_Search";
            this.Button_Search.Stretch = true;
            this.Button_Search.SubItemsExpandWidth = 14;
            this.Button_Search.Symbol = "";
            this.Button_Search.SymbolSize = 15F;
            this.Button_Search.Text = "بحث";
            this.Button_Search.Tooltip = "البحث عن سجل ما";
            // 
            // Button_Delete
            // 
            this.Button_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Delete.FontBold = true;
            this.Button_Delete.FontItalic = true;
            this.Button_Delete.ForeColor = System.Drawing.Color.SteelBlue;
            this.Button_Delete.Image = ((System.Drawing.Image)(resources.GetObject("Button_Delete.Image")));
            this.Button_Delete.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Delete.ImagePaddingHorizontal = 15;
            this.Button_Delete.ImagePaddingVertical = 11;
            this.Button_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Delete.Name = "Button_Delete";
            this.Button_Delete.Stretch = true;
            this.Button_Delete.SubItemsExpandWidth = 14;
            this.Button_Delete.Symbol = "";
            this.Button_Delete.SymbolSize = 15F;
            this.Button_Delete.Text = "حذف";
            this.Button_Delete.Tooltip = "حذف السجل الحالي";
            // 
            // Button_Save
            // 
            this.Button_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Save.FontBold = true;
            this.Button_Save.FontItalic = true;
            this.Button_Save.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Button_Save.Image = ((System.Drawing.Image)(resources.GetObject("Button_Save.Image")));
            this.Button_Save.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Save.ImagePaddingHorizontal = 15;
            this.Button_Save.ImagePaddingVertical = 11;
            this.Button_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Stretch = true;
            this.Button_Save.SubItemsExpandWidth = 14;
            this.Button_Save.Symbol = "";
            this.Button_Save.SymbolSize = 15F;
            this.Button_Save.Text = "حفظ";
            this.Button_Save.Tooltip = "حفظ التغييرات";
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click_1);
            // 
            // Button_Add
            // 
            this.Button_Add.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Add.FontBold = true;
            this.Button_Add.FontItalic = true;
            this.Button_Add.ForeColor = System.Drawing.Color.Blue;
            this.Button_Add.Image = ((System.Drawing.Image)(resources.GetObject("Button_Add.Image")));
            this.Button_Add.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Add.ImagePaddingHorizontal = 15;
            this.Button_Add.ImagePaddingVertical = 11;
            this.Button_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Add.Name = "Button_Add";
            this.Button_Add.Stretch = true;
            this.Button_Add.SubItemsExpandWidth = 14;
            this.Button_Add.Symbol = "";
            this.Button_Add.SymbolSize = 15F;
            this.Button_Add.Text = "إضافة";
            this.Button_Add.Tooltip = "إضافة سجل جديد";
            // 
            // labelItem2
            // 
            this.labelItem2.Name = "labelItem2";
            this.labelItem2.Width = 40;
            // 
            // superTabControl_Main2
            // 
            this.superTabControl_Main2.BackColor = System.Drawing.Color.White;
            this.superTabControl_Main2.CausesValidation = false;
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl_Main2.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl_Main2.ControlBox.MenuBox.Name = "";
            this.superTabControl_Main2.ControlBox.Name = "";
            this.superTabControl_Main2.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl_Main2.ControlBox.MenuBox,
            this.superTabControl_Main2.ControlBox.CloseBox});
            this.superTabControl_Main2.ControlBox.Visible = false;
            this.superTabControl_Main2.Dock = System.Windows.Forms.DockStyle.Right;
            this.superTabControl_Main2.ForeColor = System.Drawing.Color.Black;
            this.superTabControl_Main2.ItemPadding.Bottom = 4;
            this.superTabControl_Main2.ItemPadding.Left = 4;
            this.superTabControl_Main2.ItemPadding.Right = 4;
            this.superTabControl_Main2.ItemPadding.Top = 4;
            this.superTabControl_Main2.Location = new System.Drawing.Point(239, 0);
            this.superTabControl_Main2.Name = "superTabControl_Main2";
            this.superTabControl_Main2.ReorderTabsEnabled = true;
            this.superTabControl_Main2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.superTabControl_Main2.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_Main2.SelectedTabIndex = -1;
            this.superTabControl_Main2.Size = new System.Drawing.Size(410, 51);
            this.superTabControl_Main2.TabFont = new System.Drawing.Font("Tahoma", 8F);
            this.superTabControl_Main2.TabIndex = 11;
            this.superTabControl_Main2.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem1,
            this.Button_First,
            this.Button_Prev,
            this.TextBox_Index,
            this.Label_Count,
            this.lable_Records,
            this.Button_Next,
            this.Button_Last});
            this.superTabControl_Main2.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            this.superTabControl_Main2.Text = "superTabControl1";
            this.superTabControl_Main2.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Width = 2;
            // 
            // Button_First
            // 
            this.Button_First.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_First.FontBold = true;
            this.Button_First.FontItalic = true;
            this.Button_First.ForeColor = System.Drawing.Color.SteelBlue;
            this.Button_First.Image = ((System.Drawing.Image)(resources.GetObject("Button_First.Image")));
            this.Button_First.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_First.ImagePaddingHorizontal = 15;
            this.Button_First.ImagePaddingVertical = 11;
            this.Button_First.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_First.Name = "Button_First";
            this.Button_First.SplitButton = true;
            this.Button_First.Stretch = true;
            this.Button_First.SubItemsExpandWidth = 14;
            this.Button_First.Symbol = "";
            this.Button_First.SymbolSize = 15F;
            this.Button_First.Text = "الأول";
            this.Button_First.Tooltip = "السجل الاول";
            // 
            // Button_Prev
            // 
            this.Button_Prev.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Prev.FontBold = true;
            this.Button_Prev.FontItalic = true;
            this.Button_Prev.ForeColor = System.Drawing.Color.SteelBlue;
            this.Button_Prev.Image = ((System.Drawing.Image)(resources.GetObject("Button_Prev.Image")));
            this.Button_Prev.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Prev.ImagePaddingHorizontal = 15;
            this.Button_Prev.ImagePaddingVertical = 11;
            this.Button_Prev.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Prev.Name = "Button_Prev";
            this.Button_Prev.SplitButton = true;
            this.Button_Prev.Stretch = true;
            this.Button_Prev.SubItemsExpandWidth = 14;
            this.Button_Prev.Symbol = "";
            this.Button_Prev.SymbolSize = 15F;
            this.Button_Prev.Text = "السابق";
            this.Button_Prev.Tooltip = "السجل السابق";
            // 
            // TextBox_Index
            // 
            this.TextBox_Index.Name = "TextBox_Index";
            this.TextBox_Index.TextBoxWidth = 50;
            this.TextBox_Index.Visible = false;
            this.TextBox_Index.WatermarkColor = System.Drawing.SystemColors.GrayText;
            // 
            // Label_Count
            // 
            this.Label_Count.Name = "Label_Count";
            this.Label_Count.Visible = false;
            this.Label_Count.Width = 40;
            // 
            // lable_Records
            // 
            this.lable_Records.BackColor = System.Drawing.Color.SteelBlue;
            this.lable_Records.ForeColor = System.Drawing.Color.White;
            this.lable_Records.Name = "lable_Records";
            this.lable_Records.Text = "---";
            // 
            // Button_Next
            // 
            this.Button_Next.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Next.FontBold = true;
            this.Button_Next.FontItalic = true;
            this.Button_Next.ForeColor = System.Drawing.Color.SteelBlue;
            this.Button_Next.Image = ((System.Drawing.Image)(resources.GetObject("Button_Next.Image")));
            this.Button_Next.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Next.ImagePaddingHorizontal = 15;
            this.Button_Next.ImagePaddingVertical = 11;
            this.Button_Next.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Next.Name = "Button_Next";
            this.Button_Next.SplitButton = true;
            this.Button_Next.Stretch = true;
            this.Button_Next.SubItemsExpandWidth = 14;
            this.Button_Next.Symbol = "";
            this.Button_Next.SymbolSize = 15F;
            this.Button_Next.Text = "التالي";
            this.Button_Next.Tooltip = " السجل التالي";
            // 
            // Button_Last
            // 
            this.Button_Last.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.Button_Last.FontBold = true;
            this.Button_Last.FontItalic = true;
            this.Button_Last.ForeColor = System.Drawing.Color.SteelBlue;
            this.Button_Last.Image = ((System.Drawing.Image)(resources.GetObject("Button_Last.Image")));
            this.Button_Last.ImageFixedSize = new System.Drawing.Size(28, 28);
            this.Button_Last.ImagePaddingHorizontal = 15;
            this.Button_Last.ImagePaddingVertical = 11;
            this.Button_Last.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.Button_Last.Name = "Button_Last";
            this.Button_Last.SplitButton = true;
            this.Button_Last.Stretch = true;
            this.Button_Last.SubItemsExpandWidth = 14;
            this.Button_Last.Symbol = "";
            this.Button_Last.SymbolSize = 15F;
            this.Button_Last.Text = "الأخير";
            this.Button_Last.Tooltip = " السجل الاخير";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "*.rtf";
            this.saveFileDialog1.FileName = "doc1";
            this.saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf|All Files(*.*)|*.*";
            this.saveFileDialog1.FilterIndex = 2;
            this.saveFileDialog1.Title = "Save File";
            // 
            // timerInfoBallon
            // 
            this.timerInfoBallon.Interval = 3000;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.rtf";
            this.openFileDialog1.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf|All Files(*.*)|*.*";
            this.openFileDialog1.FilterIndex = 2;
            this.openFileDialog1.Title = "Open File";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelEx2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(649, 209);
            this.panel1.TabIndex = 897;
            // 
            // barTopDockSite
            // 
            this.barTopDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barTopDockSite.Dock = System.Windows.Forms.DockStyle.Top;
            this.barTopDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barTopDockSite.Location = new System.Drawing.Point(0, 0);
            this.barTopDockSite.Name = "barTopDockSite";
            this.barTopDockSite.Size = new System.Drawing.Size(649, 0);
            this.barTopDockSite.TabIndex = 889;
            this.barTopDockSite.TabStop = false;
            // 
            // barBottomDockSite
            // 
            this.barBottomDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barBottomDockSite.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barBottomDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barBottomDockSite.Location = new System.Drawing.Point(0, 209);
            this.barBottomDockSite.Name = "barBottomDockSite";
            this.barBottomDockSite.Size = new System.Drawing.Size(649, 0);
            this.barBottomDockSite.TabIndex = 890;
            this.barBottomDockSite.TabStop = false;
            // 
            // dotNetBarManager1
            // 
            this.dotNetBarManager1.BottomDockSite = this.barBottomDockSite;
            this.dotNetBarManager1.Images = this.imageList1;
            this.dotNetBarManager1.LeftDockSite = this.barLeftDockSite;
            this.dotNetBarManager1.MdiSystemItemVisible = false;
            this.dotNetBarManager1.ParentForm = null;
            this.dotNetBarManager1.RightDockSite = this.barRightDockSite;
            this.dotNetBarManager1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2000;
            this.dotNetBarManager1.ToolbarBottomDockSite = this.dockSite4;
            this.dotNetBarManager1.ToolbarLeftDockSite = this.dockSite1;
            this.dotNetBarManager1.ToolbarRightDockSite = this.dockSite2;
            this.dotNetBarManager1.ToolbarTopDockSite = this.dockSite3;
            this.dotNetBarManager1.TopDockSite = this.barTopDockSite;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "");
            this.imageList1.Images.SetKeyName(13, "");
            this.imageList1.Images.SetKeyName(14, "");
            this.imageList1.Images.SetKeyName(15, "");
            this.imageList1.Images.SetKeyName(16, "");
            this.imageList1.Images.SetKeyName(17, "");
            this.imageList1.Images.SetKeyName(18, "");
            this.imageList1.Images.SetKeyName(19, "");
            this.imageList1.Images.SetKeyName(20, "");
            this.imageList1.Images.SetKeyName(21, "");
            this.imageList1.Images.SetKeyName(22, "");
            this.imageList1.Images.SetKeyName(23, "");
            // 
            // barLeftDockSite
            // 
            this.barLeftDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barLeftDockSite.Dock = System.Windows.Forms.DockStyle.Left;
            this.barLeftDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barLeftDockSite.Location = new System.Drawing.Point(0, 0);
            this.barLeftDockSite.Name = "barLeftDockSite";
            this.barLeftDockSite.Size = new System.Drawing.Size(0, 209);
            this.barLeftDockSite.TabIndex = 891;
            this.barLeftDockSite.TabStop = false;
            // 
            // barRightDockSite
            // 
            this.barRightDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.barRightDockSite.Dock = System.Windows.Forms.DockStyle.Right;
            this.barRightDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            this.barRightDockSite.Location = new System.Drawing.Point(649, 0);
            this.barRightDockSite.Name = "barRightDockSite";
            this.barRightDockSite.Size = new System.Drawing.Size(0, 209);
            this.barRightDockSite.TabIndex = 892;
            this.barRightDockSite.TabStop = false;
            // 
            // dockSite4
            // 
            this.dockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dockSite4.Location = new System.Drawing.Point(0, 209);
            this.dockSite4.Name = "dockSite4";
            this.dockSite4.Size = new System.Drawing.Size(649, 0);
            this.dockSite4.TabIndex = 896;
            this.dockSite4.TabStop = false;
            // 
            // dockSite1
            // 
            this.dockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dockSite1.Location = new System.Drawing.Point(0, 0);
            this.dockSite1.Name = "dockSite1";
            this.dockSite1.Size = new System.Drawing.Size(0, 209);
            this.dockSite1.TabIndex = 893;
            this.dockSite1.TabStop = false;
            // 
            // dockSite2
            // 
            this.dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite2.Dock = System.Windows.Forms.DockStyle.Right;
            this.dockSite2.Location = new System.Drawing.Point(649, 0);
            this.dockSite2.Name = "dockSite2";
            this.dockSite2.Size = new System.Drawing.Size(0, 209);
            this.dockSite2.TabIndex = 894;
            this.dockSite2.TabStop = false;
            // 
            // dockSite3
            // 
            this.dockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.dockSite3.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockSite3.Location = new System.Drawing.Point(0, 0);
            this.dockSite3.Name = "dockSite3";
            this.dockSite3.Size = new System.Drawing.Size(649, 0);
            this.dockSite3.TabIndex = 895;
            this.dockSite3.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // ToolStripMenuItem_Rep
            // 
            this.ToolStripMenuItem_Rep.Checked = true;
            this.ToolStripMenuItem_Rep.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToolStripMenuItem_Rep.Name = "ToolStripMenuItem_Rep";
            this.ToolStripMenuItem_Rep.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem_Rep.Text = "إظهار التقرير";
            // 
            // ToolStripMenuItem_Det
            // 
            this.ToolStripMenuItem_Det.Name = "ToolStripMenuItem_Det";
            this.ToolStripMenuItem_Det.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem_Det.Text = "إظهار التفاصيل";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Det,
            this.ToolStripMenuItem_Rep});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip2.Size = new System.Drawing.Size(149, 48);
            // 
            // netResize1
            // 
            this.netResize1.ParentControl = this;
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            // 
            // netResize2
            // 
            this.netResize2.ParentControl = this;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ribbonBar_Tasks);
            this.panel2.Controls.Add(this.ribbonBar1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(649, 209);
            this.panel2.TabIndex = 898;
            // 
            // FrmCarS
            // 
            this.ClientSize = new System.Drawing.Size(649, 209);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barTopDockSite);
            this.Controls.Add(this.barBottomDockSite);
            this.Controls.Add(this.barLeftDockSite);
            this.Controls.Add(this.barRightDockSite);
            this.Controls.Add(this.dockSite4);
            this.Controls.Add(this.dockSite1);
            this.Controls.Add(this.dockSite2);
            this.Controls.Add(this.dockSite3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = global::InvAcc.Properties.Resources.favicon;
            this.KeyPreview = true;
            this.Name = "FrmCarS";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "كــــــرت السيارات";
            this.Load += new System.EventHandler(this.FrmDept_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.ribbonBar1.ResumeLayout(false);
            this.ribbonBar1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ribbonBar_Tasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Main2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.netResize2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }//###########&&&&&&&&&&

}
}
