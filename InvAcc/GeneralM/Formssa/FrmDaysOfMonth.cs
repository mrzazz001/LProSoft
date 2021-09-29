using DevComponents.DotNetBar;
using DevComponents.Editors;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSDateTime.Date;
using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmDaysOfMonth : Form
    {
        private IContainer components = null;
        protected PanelEx Main_Panel;
        private IntegerInput textbox_Year;
        private IntegerInput textBox_M12;
        private IntegerInput textBox_M11;
        private IntegerInput textBox_M10;
        private IntegerInput textBox_M9;
        private IntegerInput textBox_M8;
        private IntegerInput textBox_M7;
        private IntegerInput textBox_M6;
        private IntegerInput textBox_M5;
        private IntegerInput textBox_M4;
        private IntegerInput textBox_M3;
        private IntegerInput textBox_M2;
        private IntegerInput textBox_M1;
        private Label label_M12;
        private Label label_M11;
        private Label label_M10;
        private Label label_M9;
        private Label label_M8;
        private Label label_M7;
        private Label label_M6;
        private Label label_M5;
        private Label label_M4;
        private Label label_M3;
        private Label label_M2;
        private Label label_M1;
        private ButtonX button_Defalte;
        private ButtonX button_Save;
        private ButtonX button_Close;
        private Panel panel1;
        private PictureBox picture_SSS;
        private int LangArEn = 0;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private T_DaysOfMonth data_this;
        private Stock_DataDataContext dbInstance;
        public T_DaysOfMonth DataThis
        {
            get
            {
                return data_this;
            }
            set
            {
                data_this = value;
            }
        }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDaysOfMonth));
            this.Main_Panel = new DevComponents.DotNetBar.PanelEx();
            this.button_Save = new DevComponents.DotNetBar.ButtonX();
            this.button_Close = new DevComponents.DotNetBar.ButtonX();
            this.textBox_M12 = new DevComponents.Editors.IntegerInput();
            this.textBox_M11 = new DevComponents.Editors.IntegerInput();
            this.textBox_M10 = new DevComponents.Editors.IntegerInput();
            this.textBox_M9 = new DevComponents.Editors.IntegerInput();
            this.textBox_M8 = new DevComponents.Editors.IntegerInput();
            this.textBox_M7 = new DevComponents.Editors.IntegerInput();
            this.textBox_M6 = new DevComponents.Editors.IntegerInput();
            this.textBox_M5 = new DevComponents.Editors.IntegerInput();
            this.textBox_M4 = new DevComponents.Editors.IntegerInput();
            this.textBox_M3 = new DevComponents.Editors.IntegerInput();
            this.textBox_M2 = new DevComponents.Editors.IntegerInput();
            this.textBox_M1 = new DevComponents.Editors.IntegerInput();
            this.label_M12 = new System.Windows.Forms.Label();
            this.label_M11 = new System.Windows.Forms.Label();
            this.label_M10 = new System.Windows.Forms.Label();
            this.label_M9 = new System.Windows.Forms.Label();
            this.label_M8 = new System.Windows.Forms.Label();
            this.label_M7 = new System.Windows.Forms.Label();
            this.label_M6 = new System.Windows.Forms.Label();
            this.label_M5 = new System.Windows.Forms.Label();
            this.label_M4 = new System.Windows.Forms.Label();
            this.label_M3 = new System.Windows.Forms.Label();
            this.label_M2 = new System.Windows.Forms.Label();
            this.label_M1 = new System.Windows.Forms.Label();
            this.textbox_Year = new DevComponents.Editors.IntegerInput();
            this.button_Defalte = new DevComponents.DotNetBar.ButtonX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picture_SSS = new System.Windows.Forms.PictureBox();
            this.Main_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_M12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_M11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_M10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_M9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_M8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_M7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_M6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_M5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_M4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_M3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_M2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_M1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_Year)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_SSS)).BeginInit();
            this.SuspendLayout();
            // 
            // Main_Panel
            // 
            this.Main_Panel.AutoSize = true;
            this.Main_Panel.CanvasColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Main_Panel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.Main_Panel.Controls.Add(this.button_Save);
            this.Main_Panel.Controls.Add(this.button_Close);
            this.Main_Panel.Controls.Add(this.textBox_M12);
            this.Main_Panel.Controls.Add(this.textBox_M11);
            this.Main_Panel.Controls.Add(this.textBox_M10);
            this.Main_Panel.Controls.Add(this.textBox_M9);
            this.Main_Panel.Controls.Add(this.textBox_M8);
            this.Main_Panel.Controls.Add(this.textBox_M7);
            this.Main_Panel.Controls.Add(this.textBox_M6);
            this.Main_Panel.Controls.Add(this.textBox_M5);
            this.Main_Panel.Controls.Add(this.textBox_M4);
            this.Main_Panel.Controls.Add(this.textBox_M3);
            this.Main_Panel.Controls.Add(this.textBox_M2);
            this.Main_Panel.Controls.Add(this.textBox_M1);
            this.Main_Panel.Controls.Add(this.label_M12);
            this.Main_Panel.Controls.Add(this.label_M11);
            this.Main_Panel.Controls.Add(this.label_M10);
            this.Main_Panel.Controls.Add(this.label_M9);
            this.Main_Panel.Controls.Add(this.label_M8);
            this.Main_Panel.Controls.Add(this.label_M7);
            this.Main_Panel.Controls.Add(this.label_M6);
            this.Main_Panel.Controls.Add(this.label_M5);
            this.Main_Panel.Controls.Add(this.label_M4);
            this.Main_Panel.Controls.Add(this.label_M3);
            this.Main_Panel.Controls.Add(this.label_M2);
            this.Main_Panel.Controls.Add(this.label_M1);
            this.Main_Panel.Controls.Add(this.textbox_Year);
            this.Main_Panel.Controls.Add(this.button_Defalte);
            this.Main_Panel.Controls.Add(this.panel1);
            this.Main_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_Panel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.Main_Panel.Location = new System.Drawing.Point(0, 0);
            this.Main_Panel.Name = "Main_Panel";
            this.Main_Panel.RightToLeftLayout = true;
            this.Main_Panel.Size = new System.Drawing.Size(449, 324);
            this.Main_Panel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.Main_Panel.Style.BackColor1.Color = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Main_Panel.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            this.Main_Panel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.Main_Panel.Style.BorderColor.Color = System.Drawing.Color.Black;
            this.Main_Panel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.Main_Panel.Style.GradientAngle = 90;
            this.Main_Panel.Style.MarginBottom = 1;
            this.Main_Panel.Style.MarginLeft = 1;
            this.Main_Panel.Style.MarginRight = 1;
            this.Main_Panel.Style.MarginTop = 1;
            this.Main_Panel.Style.TextTrimming = System.Drawing.StringTrimming.None;
            this.Main_Panel.Style.WordWrap = true;
            this.Main_Panel.TabIndex = 845;
            this.Main_Panel.Click += new System.EventHandler(this.Main_Panel_Click);
            // 
            // button_Save
            // 
            this.button_Save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_Save.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.button_Save.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button_Save.Location = new System.Drawing.Point(197, 280);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(161, 36);
            this.button_Save.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_Save.Symbol = "";
            this.button_Save.SymbolSize = 16F;
            this.button_Save.TabIndex = 1598;
            this.button_Save.Text = "حفــــظ";
            this.button_Save.TextColor = System.Drawing.Color.White;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Close
            // 
            this.button_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_Close.Checked = true;
            this.button_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.button_Close.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.button_Close.Location = new System.Drawing.Point(360, 280);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(81, 36);
            this.button_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.button_Close.SubItemsExpandWidth = 15;
            this.button_Close.Symbol = "";
            this.button_Close.SymbolSize = 13F;
            this.button_Close.TabIndex = 1597;
            this.button_Close.Text = "رجــوع";
            this.button_Close.Tooltip = "إستعراض";
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // textBox_M12
            // 
            this.textBox_M12.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_M12.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_M12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_M12.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_M12.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_M12.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_M12.Location = new System.Drawing.Point(114, 296);
            this.textBox_M12.MaxValue = 31;
            this.textBox_M12.MinValue = 1;
            this.textBox_M12.Name = "textBox_M12";
            this.textBox_M12.Size = new System.Drawing.Size(68, 20);
            this.textBox_M12.TabIndex = 12;
            this.textBox_M12.Value = 1;
            // 
            // textBox_M11
            // 
            this.textBox_M11.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_M11.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_M11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_M11.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_M11.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_M11.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_M11.Location = new System.Drawing.Point(30, 296);
            this.textBox_M11.MaxValue = 31;
            this.textBox_M11.MinValue = 1;
            this.textBox_M11.Name = "textBox_M11";
            this.textBox_M11.Size = new System.Drawing.Size(68, 20);
            this.textBox_M11.TabIndex = 11;
            this.textBox_M11.Value = 1;
            // 
            // textBox_M10
            // 
            this.textBox_M10.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_M10.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_M10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_M10.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_M10.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_M10.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_M10.Location = new System.Drawing.Point(114, 235);
            this.textBox_M10.MaxValue = 31;
            this.textBox_M10.MinValue = 1;
            this.textBox_M10.Name = "textBox_M10";
            this.textBox_M10.Size = new System.Drawing.Size(68, 20);
            this.textBox_M10.TabIndex = 10;
            this.textBox_M10.Value = 1;
            // 
            // textBox_M9
            // 
            this.textBox_M9.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_M9.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_M9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_M9.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_M9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_M9.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_M9.Location = new System.Drawing.Point(30, 235);
            this.textBox_M9.MaxValue = 31;
            this.textBox_M9.MinValue = 1;
            this.textBox_M9.Name = "textBox_M9";
            this.textBox_M9.Size = new System.Drawing.Size(68, 20);
            this.textBox_M9.TabIndex = 9;
            this.textBox_M9.Value = 1;
            // 
            // textBox_M8
            // 
            this.textBox_M8.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_M8.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_M8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_M8.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_M8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_M8.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_M8.Location = new System.Drawing.Point(114, 183);
            this.textBox_M8.MaxValue = 31;
            this.textBox_M8.MinValue = 1;
            this.textBox_M8.Name = "textBox_M8";
            this.textBox_M8.Size = new System.Drawing.Size(68, 20);
            this.textBox_M8.TabIndex = 8;
            this.textBox_M8.Value = 1;
            // 
            // textBox_M7
            // 
            this.textBox_M7.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_M7.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_M7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_M7.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_M7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_M7.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_M7.Location = new System.Drawing.Point(30, 183);
            this.textBox_M7.MaxValue = 31;
            this.textBox_M7.MinValue = 1;
            this.textBox_M7.Name = "textBox_M7";
            this.textBox_M7.Size = new System.Drawing.Size(68, 20);
            this.textBox_M7.TabIndex = 7;
            this.textBox_M7.Value = 1;
            // 
            // textBox_M6
            // 
            this.textBox_M6.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_M6.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_M6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_M6.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_M6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_M6.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_M6.Location = new System.Drawing.Point(114, 131);
            this.textBox_M6.MaxValue = 31;
            this.textBox_M6.MinValue = 1;
            this.textBox_M6.Name = "textBox_M6";
            this.textBox_M6.Size = new System.Drawing.Size(68, 20);
            this.textBox_M6.TabIndex = 6;
            this.textBox_M6.Value = 1;
            // 
            // textBox_M5
            // 
            this.textBox_M5.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_M5.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_M5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_M5.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_M5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_M5.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_M5.Location = new System.Drawing.Point(30, 131);
            this.textBox_M5.MaxValue = 31;
            this.textBox_M5.MinValue = 1;
            this.textBox_M5.Name = "textBox_M5";
            this.textBox_M5.Size = new System.Drawing.Size(68, 20);
            this.textBox_M5.TabIndex = 5;
            this.textBox_M5.Value = 1;
            // 
            // textBox_M4
            // 
            this.textBox_M4.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_M4.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_M4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_M4.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_M4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_M4.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_M4.Location = new System.Drawing.Point(114, 83);
            this.textBox_M4.MaxValue = 31;
            this.textBox_M4.MinValue = 1;
            this.textBox_M4.Name = "textBox_M4";
            this.textBox_M4.Size = new System.Drawing.Size(68, 20);
            this.textBox_M4.TabIndex = 4;
            this.textBox_M4.Value = 1;
            // 
            // textBox_M3
            // 
            this.textBox_M3.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_M3.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_M3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_M3.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_M3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_M3.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_M3.Location = new System.Drawing.Point(30, 83);
            this.textBox_M3.MaxValue = 31;
            this.textBox_M3.MinValue = 1;
            this.textBox_M3.Name = "textBox_M3";
            this.textBox_M3.Size = new System.Drawing.Size(68, 20);
            this.textBox_M3.TabIndex = 3;
            this.textBox_M3.Value = 1;
            // 
            // textBox_M2
            // 
            this.textBox_M2.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_M2.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_M2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_M2.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_M2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_M2.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_M2.Location = new System.Drawing.Point(114, 32);
            this.textBox_M2.MaxValue = 31;
            this.textBox_M2.MinValue = 1;
            this.textBox_M2.Name = "textBox_M2";
            this.textBox_M2.Size = new System.Drawing.Size(68, 20);
            this.textBox_M2.TabIndex = 2;
            this.textBox_M2.Value = 1;
            // 
            // textBox_M1
            // 
            this.textBox_M1.AllowEmptyState = false;
            // 
            // 
            // 
            this.textBox_M1.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textBox_M1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_M1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textBox_M1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textBox_M1.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textBox_M1.Location = new System.Drawing.Point(30, 32);
            this.textBox_M1.MaxValue = 31;
            this.textBox_M1.MinValue = 1;
            this.textBox_M1.Name = "textBox_M1";
            this.textBox_M1.Size = new System.Drawing.Size(68, 20);
            this.textBox_M1.TabIndex = 1;
            this.textBox_M1.Value = 1;
            // 
            // label_M12
            // 
            this.label_M12.AutoSize = true;
            this.label_M12.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label_M12.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label_M12.ForeColor = System.Drawing.Color.Gray;
            this.label_M12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_M12.Location = new System.Drawing.Point(125, 276);
            this.label_M12.Name = "label_M12";
            this.label_M12.Size = new System.Drawing.Size(46, 13);
            this.label_M12.TabIndex = 156;
            this.label_M12.Text = "ذو الحجة";
            // 
            // label_M11
            // 
            this.label_M11.AutoSize = true;
            this.label_M11.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label_M11.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label_M11.ForeColor = System.Drawing.Color.Gray;
            this.label_M11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_M11.Location = new System.Drawing.Point(40, 276);
            this.label_M11.Name = "label_M11";
            this.label_M11.Size = new System.Drawing.Size(49, 13);
            this.label_M11.TabIndex = 154;
            this.label_M11.Text = "ذو القعدة";
            // 
            // label_M10
            // 
            this.label_M10.AutoSize = true;
            this.label_M10.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label_M10.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label_M10.ForeColor = System.Drawing.Color.Gray;
            this.label_M10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_M10.Location = new System.Drawing.Point(132, 216);
            this.label_M10.Name = "label_M10";
            this.label_M10.Size = new System.Drawing.Size(33, 13);
            this.label_M10.TabIndex = 152;
            this.label_M10.Text = "شوال";
            // 
            // label_M9
            // 
            this.label_M9.AutoSize = true;
            this.label_M9.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label_M9.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label_M9.ForeColor = System.Drawing.Color.Gray;
            this.label_M9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_M9.Location = new System.Drawing.Point(46, 216);
            this.label_M9.Name = "label_M9";
            this.label_M9.Size = new System.Drawing.Size(36, 13);
            this.label_M9.TabIndex = 149;
            this.label_M9.Text = "رمضان";
            // 
            // label_M8
            // 
            this.label_M8.AutoSize = true;
            this.label_M8.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label_M8.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label_M8.ForeColor = System.Drawing.Color.Gray;
            this.label_M8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_M8.Location = new System.Drawing.Point(129, 164);
            this.label_M8.Name = "label_M8";
            this.label_M8.Size = new System.Drawing.Size(38, 13);
            this.label_M8.TabIndex = 147;
            this.label_M8.Text = "شعبان";
            // 
            // label_M7
            // 
            this.label_M7.AutoSize = true;
            this.label_M7.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label_M7.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label_M7.ForeColor = System.Drawing.Color.Gray;
            this.label_M7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_M7.Location = new System.Drawing.Point(50, 164);
            this.label_M7.Name = "label_M7";
            this.label_M7.Size = new System.Drawing.Size(28, 13);
            this.label_M7.TabIndex = 145;
            this.label_M7.Text = "رجب";
            // 
            // label_M6
            // 
            this.label_M6.AutoSize = true;
            this.label_M6.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label_M6.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label_M6.ForeColor = System.Drawing.Color.Gray;
            this.label_M6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_M6.Location = new System.Drawing.Point(114, 112);
            this.label_M6.Name = "label_M6";
            this.label_M6.Size = new System.Drawing.Size(69, 13);
            this.label_M6.TabIndex = 144;
            this.label_M6.Text = "جمادى الثاني";
            // 
            // label_M5
            // 
            this.label_M5.AutoSize = true;
            this.label_M5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label_M5.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label_M5.ForeColor = System.Drawing.Color.Gray;
            this.label_M5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_M5.Location = new System.Drawing.Point(32, 112);
            this.label_M5.Name = "label_M5";
            this.label_M5.Size = new System.Drawing.Size(64, 13);
            this.label_M5.TabIndex = 141;
            this.label_M5.Text = "جمادى الأول";
            // 
            // label_M4
            // 
            this.label_M4.AutoSize = true;
            this.label_M4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label_M4.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label_M4.ForeColor = System.Drawing.Color.Gray;
            this.label_M4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_M4.Location = new System.Drawing.Point(121, 64);
            this.label_M4.Name = "label_M4";
            this.label_M4.Size = new System.Drawing.Size(54, 13);
            this.label_M4.TabIndex = 140;
            this.label_M4.Text = "ربيع الثاني";
            // 
            // label_M3
            // 
            this.label_M3.AutoSize = true;
            this.label_M3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label_M3.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label_M3.ForeColor = System.Drawing.Color.Gray;
            this.label_M3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_M3.Location = new System.Drawing.Point(40, 64);
            this.label_M3.Name = "label_M3";
            this.label_M3.Size = new System.Drawing.Size(49, 13);
            this.label_M3.TabIndex = 138;
            this.label_M3.Text = "ربيع الأول";
            // 
            // label_M2
            // 
            this.label_M2.AutoSize = true;
            this.label_M2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label_M2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label_M2.ForeColor = System.Drawing.Color.Gray;
            this.label_M2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_M2.Location = new System.Drawing.Point(135, 13);
            this.label_M2.Name = "label_M2";
            this.label_M2.Size = new System.Drawing.Size(27, 13);
            this.label_M2.TabIndex = 135;
            this.label_M2.Text = "صفر";
            // 
            // label_M1
            // 
            this.label_M1.AutoSize = true;
            this.label_M1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label_M1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label_M1.ForeColor = System.Drawing.Color.Gray;
            this.label_M1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_M1.Location = new System.Drawing.Point(48, 13);
            this.label_M1.Name = "label_M1";
            this.label_M1.Size = new System.Drawing.Size(32, 13);
            this.label_M1.TabIndex = 134;
            this.label_M1.Text = "محرم";
            // 
            // textbox_Year
            // 
            this.textbox_Year.AllowEmptyState = false;
            // 
            // 
            // 
            this.textbox_Year.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textbox_Year.BackgroundStyle.Class = "DateTimeInputBackground";
            this.textbox_Year.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textbox_Year.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.textbox_Year.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.textbox_Year.ForeColor = System.Drawing.Color.White;
            this.textbox_Year.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.textbox_Year.IsInputReadOnly = true;
            this.textbox_Year.Location = new System.Drawing.Point(197, 198);
            this.textbox_Year.Name = "textbox_Year";
            this.textbox_Year.Size = new System.Drawing.Size(244, 20);
            this.textbox_Year.TabIndex = 158;
            // 
            // button_Defalte
            // 
            this.button_Defalte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_Defalte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_Defalte.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button_Defalte.Location = new System.Drawing.Point(197, 224);
            this.button_Defalte.Name = "button_Defalte";
            this.button_Defalte.Size = new System.Drawing.Size(244, 50);
            this.button_Defalte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_Defalte.Symbol = "";
            this.button_Defalte.SymbolSize = 20F;
            this.button_Defalte.TabIndex = 991;
            this.button_Defalte.Text = "استرجاع التقويم السنوي";
            this.button_Defalte.TextColor = System.Drawing.Color.SteelBlue;
            this.button_Defalte.Click += new System.EventHandler(this.button_Defalte_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.picture_SSS);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(449, 324);
            this.panel1.TabIndex = 1599;
            // 
            // picture_SSS
            // 
            this.picture_SSS.BackColor = System.Drawing.Color.Transparent;
            this.picture_SSS.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picture_SSS.Location = new System.Drawing.Point(-29, 29);
            this.picture_SSS.Name = "picture_SSS";
            this.picture_SSS.Size = new System.Drawing.Size(327, 146);
            this.picture_SSS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_SSS.TabIndex = 1600;
            this.picture_SSS.TabStop = false;
            // 
            // FrmDaysOfMonth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 324);
            this.ControlBox = false;
            this.Controls.Add(this.Main_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.KeyPreview = true;
            this.Name = "FrmDaysOfMonth";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmDaysOfMonth_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmDaysOfMonth_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmDaysOfMonth_KeyPress);
            this.Main_Panel.ResumeLayout(false);
            this.Main_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_M12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_M11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_M10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_M9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_M8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_M7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_M6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_M5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_M4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_M3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_M2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_M1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textbox_Year)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picture_SSS)).EndInit();
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        public FrmDaysOfMonth()
        {
            InitializeComponent();
        }
        private void Main_Panel_Click(object sender, EventArgs e)
        {
        }
        private void FrmDaysOfMonth_Load(object sender, EventArgs e)
        {
            try
            {
                int? calendr = VarGeneral.Settings_Sys.Calendr;
                if (calendr.Value == 0 && calendr.HasValue)
                {
                    textbox_Year.Text = n.FormatGreg(VarGeneral.Gdate, "yyyy");
                }
                else
                {
                    textbox_Year.Text = n.FormatHijri(VarGeneral.Hdate, "yyyy");
                }
                for (int i = 1; i <= 12; i++)
                {
                    if (i == 1)
                    {
                        textBox_M1.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: false);
                        label_M1.Text = (n.IsHijri(textbox_Year.Text + "/01/01") ? "محرم" : "Jan");
                    }
                    if (i == 2)
                    {
                        textBox_M2.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: false);
                        label_M2.Text = (n.IsHijri(textbox_Year.Text + "/01/01") ? "صفر" : "Feb");
                    }
                    if (i == 3)
                    {
                        textBox_M3.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: false);
                        label_M3.Text = (n.IsHijri(textbox_Year.Text + "/01/01") ? "ربيع الاول" : "March");
                    }
                    if (i == 4)
                    {
                        textBox_M4.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: false);
                        label_M4.Text = (n.IsHijri(textbox_Year.Text + "/01/01") ? "ربيع الثاني" : "April");
                    }
                    if (i == 5)
                    {
                        textBox_M5.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: false);
                        label_M5.Text = (n.IsHijri(textbox_Year.Text + "/01/01") ? "جمادى الاول" : "May");
                    }
                    if (i == 6)
                    {
                        textBox_M6.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: false);
                        label_M6.Text = (n.IsHijri(textbox_Year.Text + "/01/01") ? "جمادى الثاني" : "Jun");
                    }
                    if (i == 7)
                    {
                        textBox_M7.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: false);
                        label_M7.Text = (n.IsHijri(textbox_Year.Text + "/01/01") ? "رجب" : "Jul");
                    }
                    if (i == 8)
                    {
                        textBox_M8.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: false);
                        label_M8.Text = (n.IsHijri(textbox_Year.Text + "/01/01") ? "شعبان" : "Aug");
                    }
                    if (i == 9)
                    {
                        textBox_M9.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: false);
                        label_M9.Text = (n.IsHijri(textbox_Year.Text + "/01/01") ? "رمضان" : "Sep");
                    }
                    if (i == 10)
                    {
                        textBox_M10.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: false);
                        label_M10.Text = (n.IsHijri(textbox_Year.Text + "/01/01") ? "شوال" : "Oct");
                    }
                    if (i == 11)
                    {
                        textBox_M11.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: false);
                        label_M11.Text = (n.IsHijri(textbox_Year.Text + "/01/01") ? "ذو القعدة" : "Nov");
                    }
                    if (i == 12)
                    {
                        textBox_M12.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: false);
                        label_M12.Text = (n.IsHijri(textbox_Year.Text + "/01/01") ? "ذو الحجة" : "Dec");
                    }
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FrmDaysOfMonth_Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void button_Defalte_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 1; i <= 12; i++)
                {
                    if (i == 1)
                    {
                        textBox_M1.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: true);
                    }
                    if (i == 2)
                    {
                        textBox_M2.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: true);
                    }
                    if (i == 3)
                    {
                        textBox_M3.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: true);
                    }
                    if (i == 4)
                    {
                        textBox_M4.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: true);
                    }
                    if (i == 5)
                    {
                        textBox_M5.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: true);
                    }
                    if (i == 6)
                    {
                        textBox_M6.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: true);
                    }
                    if (i == 7)
                    {
                        textBox_M7.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: true);
                    }
                    if (i == 8)
                    {
                        textBox_M8.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: true);
                    }
                    if (i == 9)
                    {
                        textBox_M9.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: true);
                    }
                    if (i == 10)
                    {
                        textBox_M10.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: true);
                    }
                    if (i == 11)
                    {
                        textBox_M11.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: true);
                    }
                    if (i == 12)
                    {
                        textBox_M12.Value = db.GetMaxDayOfMonth(Convert.ToDateTime(textbox_Year.Text + "/" + i + "/01").ToString("yyyy/MM/dd"), GetDefault: true);
                    }
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_Defalte_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 1; i <= 12; i++)
                {
                    data_this = new T_DaysOfMonth();
                    T_DaysOfMonth newdata = db.EmpFirstDayofMonth(textbox_Year.Text + "/" + i);
                    if (string.IsNullOrEmpty(newdata.ID) || newdata == null)
                    {
                        GetData(i);
                        Guid id = Guid.NewGuid();
                        data_this.ID = id.ToString();
                        db.T_DaysOfMonths.InsertOnSubmit(data_this);
                        db.SubmitChanges();
                    }
                    else
                    {
                        DataThis = newdata;
                        GetData(i);
                        db.Log = VarGeneral.DebugLog;
                        db.SubmitChanges(ConflictMode.ContinueOnConflict);
                    }
                }
                button_Close_Click(sender, e);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_Save_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private T_DaysOfMonth GetData(int iFlag)
        {
            data_this.Year = textbox_Year.Value;
            data_this.Month = iFlag;
            switch (iFlag)
            {
                case 1:
                    data_this.DaysOfMonth = textBox_M1.Value;
                    break;
                case 2:
                    data_this.DaysOfMonth = textBox_M2.Value;
                    break;
            }
            if (iFlag == 3)
            {
                data_this.DaysOfMonth = textBox_M3.Value;
            }
            if (iFlag == 4)
            {
                data_this.DaysOfMonth = textBox_M4.Value;
            }
            if (iFlag == 5)
            {
                data_this.DaysOfMonth = textBox_M5.Value;
            }
            if (iFlag == 6)
            {
                data_this.DaysOfMonth = textBox_M6.Value;
            }
            if (iFlag == 7)
            {
                data_this.DaysOfMonth = textBox_M7.Value;
            }
            if (iFlag == 8)
            {
                data_this.DaysOfMonth = textBox_M8.Value;
            }
            if (iFlag == 9)
            {
                data_this.DaysOfMonth = textBox_M9.Value;
            }
            if (iFlag == 10)
            {
                data_this.DaysOfMonth = textBox_M10.Value;
            }
            if (iFlag == 11)
            {
                data_this.DaysOfMonth = textBox_M11.Value;
            }
            if (iFlag == 12)
            {
                data_this.DaysOfMonth = textBox_M12.Value;
            }
            return data_this;
        }
        private void FrmDaysOfMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void FrmDaysOfMonth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && button_Save.Enabled && button_Save.Visible)
            {
                button_Save_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
