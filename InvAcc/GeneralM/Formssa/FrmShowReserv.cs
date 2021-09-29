using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmShowReserv : Form
    {
        public class ColumnDictinary
        {
            public string AText = "";
            public string EText = "";
            public bool IfDefault = false;
            public string Format = "";
            public ColumnDictinary(string aText, string eText, bool ifDefault, string format)
            {
                AText = aText;
                EText = eText;
                IfDefault = ifDefault;
                Format = format;
            }
        }
        private IContainer components = null;
        private PanelEx Frame1;
        private Label label8;
        private Label label5;
        private Label label6;
        private Label label3;
        private Label label4;
        private Label label2;
        private Label label1;
        private Label Label2_6;
        private Label Label2_5;
        private Label Label2_4;
        private Label Label2_3;
        private Label Label2_2;
        private Label Label2_1;
        private Label Label2_0;
        private ButtonX Option1_0;
        private ButtonX Option1_2;
        private ButtonX Option1_1;
        private ButtonX button_Close;
        private ButtonX button_Save;
        public C1FlexGrid VS;
        private ButtonX buttonExt;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem sdfaToolStripMenuItem_Option0;
        private ToolStripMenuItem sdfaToolStripMenuItem_Option2;
        private ToolStripMenuItem sdfaToolStripMenuItem_Option1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private int LangArEn = 0;
        protected bool ifOkDelete;
        public bool CanEdit = true;
        protected bool CanInsert = true;
        private string FlagUpdate = "";
        public ViewState ViewState = ViewState.Deiles;
        private FormState statex;
        public List<Control> controls;
        public Control codeControl = new Control();
        private bool canUpdate = true;
        private int ControlNo = 0;
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstance;
        private T_INVHED data_this;
        private int vRow = 0;
        private int bb = 0;
        public FormState State
        {
            get
            {
                return statex;
            }
            set
            {
                statex = value;
            }
        }
        protected bool CanUpdate
        {
            get
            {
                return canUpdate;
            }
            set
            {
                canUpdate = value;
            }
        }
        public List<string> PKeys
        {
            get
            {
                return pkeys;
            }
            set
            {
                pkeys = value;
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
        public T_INVHED DataThis
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmShowReserv));
            VS = new C1.Win.C1FlexGrid.C1FlexGrid();
            Frame1 = new DevComponents.DotNetBar.PanelEx();
            button_Close = new DevComponents.DotNetBar.ButtonX();
            button_Save = new DevComponents.DotNetBar.ButtonX();
            Option1_0 = new DevComponents.DotNetBar.ButtonX();
            Option1_2 = new DevComponents.DotNetBar.ButtonX();
            Option1_1 = new DevComponents.DotNetBar.ButtonX();
            Label2_6 = new System.Windows.Forms.Label();
            Label2_5 = new System.Windows.Forms.Label();
            Label2_4 = new System.Windows.Forms.Label();
            Label2_3 = new System.Windows.Forms.Label();
            Label2_2 = new System.Windows.Forms.Label();
            Label2_1 = new System.Windows.Forms.Label();
            Label2_0 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            buttonExt = new DevComponents.DotNetBar.ButtonX();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            sdfaToolStripMenuItem_Option0 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            sdfaToolStripMenuItem_Option1 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            sdfaToolStripMenuItem_Option2 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)VS).BeginInit();
            Frame1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            VS.AccessibleDescription = null;
            VS.AccessibleName = null;
            VS.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            VS.AllowEditing = false;
            VS.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
            VS.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            resources.ApplyResources(VS, "VS");
            VS.BackgroundImage = null;
            VS.ExtendLastCol = true;
            VS.HighLight = C1.Win.C1FlexGrid.HighLightEnum.Never;
            VS.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            VS.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            VS.Name = "VS";
            VS.Rows.DefaultSize = 19;
            VS.Rows.MinSize = 30;
            VS.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
            VS.StyleInfo = resources.GetString("VS.StyleInfo");
            VS.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System;
            VS.Click += new System.EventHandler(VS_Click);
            Frame1.AccessibleDescription = null;
            Frame1.AccessibleName = null;
            resources.ApplyResources(Frame1, "Frame1");
            Frame1.CanvasColor = System.Drawing.SystemColors.Control;
            Frame1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            Frame1.Controls.Add(button_Close);
            Frame1.Controls.Add(button_Save);
            Frame1.Controls.Add(Option1_0);
            Frame1.Controls.Add(Option1_2);
            Frame1.Controls.Add(Option1_1);
            Frame1.Controls.Add(Label2_6);
            Frame1.Controls.Add(Label2_5);
            Frame1.Controls.Add(Label2_4);
            Frame1.Controls.Add(Label2_3);
            Frame1.Controls.Add(Label2_2);
            Frame1.Controls.Add(Label2_1);
            Frame1.Controls.Add(Label2_0);
            Frame1.Controls.Add(label8);
            Frame1.Controls.Add(label5);
            Frame1.Controls.Add(label6);
            Frame1.Controls.Add(label3);
            Frame1.Controls.Add(label4);
            Frame1.Controls.Add(label2);
            Frame1.Controls.Add(label1);
            Frame1.Font = null;
            Frame1.Name = "Frame1";
            Frame1.Style.Alignment = System.Drawing.StringAlignment.Center;
            Frame1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            Frame1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            Frame1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            Frame1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            Frame1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            Frame1.Style.GradientAngle = 90;
            Frame1.VisibleChanged += new System.EventHandler(Frame1_VisibleChanged);
            button_Close.AccessibleDescription = null;
            button_Close.AccessibleName = null;
            button_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_Close, "button_Close");
            button_Close.BackgroundImage = null;
            button_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            button_Close.CommandParameter = null;
            button_Close.Name = "button_Close";
            button_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_Close.Symbol = "\uf011";
            button_Close.SymbolSize = 16f;
            button_Close.TextColor = System.Drawing.Color.Black;
            button_Close.Click += new System.EventHandler(button_Close_Click);
            button_Save.AccessibleDescription = null;
            button_Save.AccessibleName = null;
            button_Save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_Save, "button_Save");
            button_Save.BackgroundImage = null;
            button_Save.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            button_Save.CommandParameter = null;
            button_Save.Name = "button_Save";
            button_Save.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_Save.Symbol = "\uf00c";
            button_Save.SymbolSize = 16f;
            button_Save.TextColor = System.Drawing.Color.White;
            button_Save.Click += new System.EventHandler(button_Save_Click);
            Option1_0.AccessibleDescription = null;
            Option1_0.AccessibleName = null;
            Option1_0.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            resources.ApplyResources(Option1_0, "Option1_0");
            Option1_0.AutoCheckOnClick = true;
            Option1_0.BackgroundImage = null;
            Option1_0.Checked = true;
            Option1_0.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            Option1_0.CommandParameter = null;
            Option1_0.Name = "Option1_0";
            Option1_0.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            Option1_0.SymbolSize = 5f;
            Option1_0.TextColor = System.Drawing.Color.FromArgb(64, 64, 64);
            Option1_0.Click += new System.EventHandler(Option1_0_Click);
            Option1_2.AccessibleDescription = null;
            Option1_2.AccessibleName = null;
            Option1_2.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            resources.ApplyResources(Option1_2, "Option1_2");
            Option1_2.AutoCheckOnClick = true;
            Option1_2.BackgroundImage = null;
            Option1_2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            Option1_2.CommandParameter = null;
            Option1_2.Name = "Option1_2";
            Option1_2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            Option1_2.SymbolSize = 5f;
            Option1_2.TextColor = System.Drawing.Color.FromArgb(64, 64, 64);
            Option1_2.Click += new System.EventHandler(Option1_2_Click);
            Option1_1.AccessibleDescription = null;
            Option1_1.AccessibleName = null;
            Option1_1.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            resources.ApplyResources(Option1_1, "Option1_1");
            Option1_1.AutoCheckOnClick = true;
            Option1_1.BackgroundImage = null;
            Option1_1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            Option1_1.CommandParameter = null;
            Option1_1.Name = "Option1_1";
            Option1_1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            Option1_1.SymbolSize = 5f;
            Option1_1.TextColor = System.Drawing.Color.FromArgb(64, 64, 64);
            Option1_1.Click += new System.EventHandler(Option1_1_Click);
            Label2_6.AccessibleDescription = null;
            Label2_6.AccessibleName = null;
            resources.ApplyResources(Label2_6, "Label2_6");
            Label2_6.BackColor = System.Drawing.Color.White;
            Label2_6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Label2_6.Font = null;
            Label2_6.Name = "Label2_6";
            Label2_5.AccessibleDescription = null;
            Label2_5.AccessibleName = null;
            resources.ApplyResources(Label2_5, "Label2_5");
            Label2_5.BackColor = System.Drawing.Color.White;
            Label2_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Label2_5.Font = null;
            Label2_5.Name = "Label2_5";
            Label2_4.AccessibleDescription = null;
            Label2_4.AccessibleName = null;
            resources.ApplyResources(Label2_4, "Label2_4");
            Label2_4.BackColor = System.Drawing.Color.White;
            Label2_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Label2_4.Font = null;
            Label2_4.Name = "Label2_4";
            Label2_3.AccessibleDescription = null;
            Label2_3.AccessibleName = null;
            resources.ApplyResources(Label2_3, "Label2_3");
            Label2_3.BackColor = System.Drawing.Color.White;
            Label2_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Label2_3.Font = null;
            Label2_3.Name = "Label2_3";
            Label2_2.AccessibleDescription = null;
            Label2_2.AccessibleName = null;
            resources.ApplyResources(Label2_2, "Label2_2");
            Label2_2.BackColor = System.Drawing.Color.White;
            Label2_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Label2_2.Font = null;
            Label2_2.Name = "Label2_2";
            Label2_1.AccessibleDescription = null;
            Label2_1.AccessibleName = null;
            resources.ApplyResources(Label2_1, "Label2_1");
            Label2_1.BackColor = System.Drawing.Color.White;
            Label2_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Label2_1.Font = null;
            Label2_1.Name = "Label2_1";
            Label2_0.AccessibleDescription = null;
            Label2_0.AccessibleName = null;
            resources.ApplyResources(Label2_0, "Label2_0");
            Label2_0.BackColor = System.Drawing.Color.White;
            Label2_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Label2_0.Font = null;
            Label2_0.Name = "Label2_0";
            label8.AccessibleDescription = null;
            label8.AccessibleName = null;
            resources.ApplyResources(label8, "label8");
            label8.BackColor = System.Drawing.Color.Gainsboro;
            label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            label8.Font = null;
            label8.Name = "label8";
            label5.AccessibleDescription = null;
            label5.AccessibleName = null;
            resources.ApplyResources(label5, "label5");
            label5.BackColor = System.Drawing.Color.Gainsboro;
            label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            label5.Font = null;
            label5.Name = "label5";
            label6.AccessibleDescription = null;
            label6.AccessibleName = null;
            resources.ApplyResources(label6, "label6");
            label6.BackColor = System.Drawing.Color.Gainsboro;
            label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            label6.Font = null;
            label6.Name = "label6";
            label3.AccessibleDescription = null;
            label3.AccessibleName = null;
            resources.ApplyResources(label3, "label3");
            label3.BackColor = System.Drawing.Color.Gainsboro;
            label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            label3.Font = null;
            label3.Name = "label3";
            label4.AccessibleDescription = null;
            label4.AccessibleName = null;
            resources.ApplyResources(label4, "label4");
            label4.BackColor = System.Drawing.Color.Gainsboro;
            label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            label4.Font = null;
            label4.Name = "label4";
            label2.AccessibleDescription = null;
            label2.AccessibleName = null;
            resources.ApplyResources(label2, "label2");
            label2.BackColor = System.Drawing.Color.Gainsboro;
            label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            label2.Font = null;
            label2.Name = "label2";
            label1.AccessibleDescription = null;
            label1.AccessibleName = null;
            resources.ApplyResources(label1, "label1");
            label1.BackColor = System.Drawing.Color.Gainsboro;
            label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            label1.Font = null;
            label1.Name = "label1";
            buttonExt.AccessibleDescription = null;
            buttonExt.AccessibleName = null;
            buttonExt.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(buttonExt, "buttonExt");
            buttonExt.BackgroundImage = null;
            buttonExt.Checked = true;
            buttonExt.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            buttonExt.CommandParameter = null;
            buttonExt.Name = "buttonExt";
            buttonExt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            buttonExt.Symbol = "\uf011";
            buttonExt.SymbolSize = 16f;
            buttonExt.TextColor = System.Drawing.Color.Black;
            buttonExt.Click += new System.EventHandler(buttonExt_Click);
            contextMenuStrip1.AccessibleDescription = null;
            contextMenuStrip1.AccessibleName = null;
            resources.ApplyResources(contextMenuStrip1, "contextMenuStrip1");
            contextMenuStrip1.BackgroundImage = null;
            contextMenuStrip1.Font = null;
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[5]
            {
                sdfaToolStripMenuItem_Option0,
                toolStripSeparator1,
                sdfaToolStripMenuItem_Option1,
                toolStripSeparator2,
                sdfaToolStripMenuItem_Option2
            });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(contextMenuStrip1_Closed);
            sdfaToolStripMenuItem_Option0.AccessibleDescription = null;
            sdfaToolStripMenuItem_Option0.AccessibleName = null;
            resources.ApplyResources(sdfaToolStripMenuItem_Option0, "sdfaToolStripMenuItem_Option0");
            sdfaToolStripMenuItem_Option0.BackgroundImage = null;
            sdfaToolStripMenuItem_Option0.Checked = true;
            sdfaToolStripMenuItem_Option0.CheckState = System.Windows.Forms.CheckState.Checked;
            sdfaToolStripMenuItem_Option0.ForeColor = System.Drawing.Color.Blue;
            sdfaToolStripMenuItem_Option0.Name = "sdfaToolStripMenuItem_Option0";
            sdfaToolStripMenuItem_Option0.ShortcutKeyDisplayString = null;
            sdfaToolStripMenuItem_Option0.Click += new System.EventHandler(sdfaToolStripMenuItem_Option0_Click);
            toolStripSeparator1.AccessibleDescription = null;
            toolStripSeparator1.AccessibleName = null;
            resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
            toolStripSeparator1.Name = "toolStripSeparator1";
            sdfaToolStripMenuItem_Option1.AccessibleDescription = null;
            sdfaToolStripMenuItem_Option1.AccessibleName = null;
            resources.ApplyResources(sdfaToolStripMenuItem_Option1, "sdfaToolStripMenuItem_Option1");
            sdfaToolStripMenuItem_Option1.BackgroundImage = null;
            sdfaToolStripMenuItem_Option1.Checked = true;
            sdfaToolStripMenuItem_Option1.CheckState = System.Windows.Forms.CheckState.Checked;
            sdfaToolStripMenuItem_Option1.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            sdfaToolStripMenuItem_Option1.Name = "sdfaToolStripMenuItem_Option1";
            sdfaToolStripMenuItem_Option1.ShortcutKeyDisplayString = null;
            sdfaToolStripMenuItem_Option1.Click += new System.EventHandler(sdfaToolStripMenuItem_Option1_Click);
            toolStripSeparator2.AccessibleDescription = null;
            toolStripSeparator2.AccessibleName = null;
            resources.ApplyResources(toolStripSeparator2, "toolStripSeparator2");
            toolStripSeparator2.Name = "toolStripSeparator2";
            sdfaToolStripMenuItem_Option2.AccessibleDescription = null;
            sdfaToolStripMenuItem_Option2.AccessibleName = null;
            resources.ApplyResources(sdfaToolStripMenuItem_Option2, "sdfaToolStripMenuItem_Option2");
            sdfaToolStripMenuItem_Option2.BackgroundImage = null;
            sdfaToolStripMenuItem_Option2.Checked = true;
            sdfaToolStripMenuItem_Option2.CheckState = System.Windows.Forms.CheckState.Checked;
            sdfaToolStripMenuItem_Option2.ForeColor = System.Drawing.Color.FromArgb(0, 64, 0);
            sdfaToolStripMenuItem_Option2.Name = "sdfaToolStripMenuItem_Option2";
            sdfaToolStripMenuItem_Option2.ShortcutKeyDisplayString = null;
            sdfaToolStripMenuItem_Option2.Click += new System.EventHandler(sdfaToolStripMenuItem_Option2_Click);
            base.AccessibleDescription = null;
            base.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = null;
            base.Controls.Add(buttonExt);
            base.Controls.Add(VS);
            base.Controls.Add(Frame1);
            Font = null;
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "FrmShowReserv";
            base.Load += new System.EventHandler(FrmShowReserv_Load);
            base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(FrmShowReserv_FormClosed);
            base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FrmShowReserv_FormClosing);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmShowReserv_KeyDown);
            ((System.ComponentModel.ISupportInitialize)VS).EndInit();
            Frame1.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }
        public FrmShowReserv()
        {
            InitializeComponent();
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                sdfaToolStripMenuItem_Option0.Text = "إستخدام حجز";
                sdfaToolStripMenuItem_Option1.Text = "إلغــاء حجـــز";
                sdfaToolStripMenuItem_Option2.Text = "تعديل حجـــز";
                Text = "الحجوزات";
                return;
            }
            VS.Cols[0].Caption = "*";
            VS.Cols[1].Caption = "Reserv No";
            VS.Cols[2].Caption = "Date";
            VS.Cols[3].Caption = "Name";
            VS.Cols[4].Caption = "Nationality";
            VS.Cols[5].Caption = "ID No";
            VS.Cols[6].Caption = "Room No";
            VS.Cols[7].Caption = "Status";
            VS.Cols[9].Caption = "Leave Date";
            sdfaToolStripMenuItem_Option0.Text = "Reservation Use";
            sdfaToolStripMenuItem_Option1.Text = "Reservation Cancel";
            sdfaToolStripMenuItem_Option2.Text = "Reservation Edit";
            buttonExt.Text = "Close";
            Text = "Reservations";
        }
        private void FrmShowReserv_Load(object sender, EventArgs e)
        {
            Frame1.Visible = false;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                LangArEn = 0;
            }
            else
            {
                LangArEn = 1;
            }
            RibunButtons();
        }
        private void button_Close_Click(object sender, EventArgs e)
        {
            VS.RowSel = 0;
            VS.Enabled = true;
            Frame1.Visible = false;
        }
        private void FrmShowReserv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (Frame1.Visible)
                {
                    button_Close_Click(sender, e);
                }
                else
                {
                    Close();
                }
            }
        }
        private void Option1_0_Click(object sender, EventArgs e)
        {
            if (!Option1_0.Checked)
            {
                Option1_0.Checked = true;
                return;
            }
            Option1_0.Checked = true;
            Option1_1.Checked = false;
            Option1_2.Checked = false;
        }
        private void Option1_1_Click(object sender, EventArgs e)
        {
            if (!Option1_1.Checked)
            {
                Option1_1.Checked = true;
                return;
            }
            Option1_0.Checked = false;
            Option1_1.Checked = true;
            Option1_2.Checked = false;
        }
        private void Option1_2_Click(object sender, EventArgs e)
        {
            if (!Option1_2.Checked)
            {
                Option1_2.Checked = true;
                return;
            }
            Option1_0.Checked = false;
            Option1_1.Checked = false;
            Option1_2.Checked = true;
        }
        private void button_Save_Click(object sender, EventArgs e)
        {
            if (Option1_0.Checked)
            {
                VarGeneral.SndTyp = 2;
                List<T_Reserv> rsTmp = db.ExecuteQuery<T_Reserv>("select * from T_Reserv where ResrvNo=" + Label2_0.Text, new object[0]).ToList();
                VarGeneral.FormSend = int.Parse(Label2_0.Text);
                if (rsTmp.FirstOrDefault().Nat.HasValue)
                {
                    VarGeneral.Tmp1 = rsTmp.FirstOrDefault().Nat.Value.ToString();
                }
                else
                {
                    VarGeneral.Tmp1 = "";
                }
                VarGeneral.Tmp2 = Label2_2.Text;
                VarGeneral.Tmp3 = Label2_4.Text;
                VarGeneral.Tmp4 = int.Parse(Label2_5.Text);
                VarGeneral.Tmp6 = Label2_0.Text;
                VarGeneral.Tmp7 = rsTmp.FirstOrDefault().DayImport.Value.ToString();
                bb = 1;
                VarGeneral._hotelrom = rsTmp.FirstOrDefault().Rom.Value;
                VarGeneral._hotelper = 0;
                if (!string.IsNullOrEmpty(VarGeneral.Tmp4.ToString()) && db.StockRoom(VarGeneral.Tmp4).state.Value != 1)
                {
                    MessageBox.Show((LangArEn == 0) ? ("رقم : " + VarGeneral.Tmp4 + " مشغولة الآن .. يرجى المحاولة مرة اخرى") : ("Eye number: " + VarGeneral.Tmp4 + " busy now .. please try again"), VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    bb = 0;
                }
                else
                {
                    Close();
                }
            }
            else if (Option1_1.Checked)
            {
                if (MessageBox.Show("هل أنت متاكد من إلغاء الحجز رقم [" + Label2_0.Text + "]؟ \n Are you sure that you want to cancel reservation No [" + Label2_0.Text + "]?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
                {
                    List<T_Reserv> q = db.T_Reservs.Where((T_Reserv t) => t.ResrvNo == int.Parse(Label2_0.Text)).ToList();
                    if (q.Count > 0)
                    {
                        q[0].Sts = 2;
                        db.Log = VarGeneral.DebugLog;
                        db.SubmitChanges(ConflictMode.ContinueOnConflict);
                        bb = 2;
                        Close();
                    }
                }
            }
            else if (Option1_2.Checked)
            {
                VarGeneral.SndTyp = 2;
                VarGeneral.FormSend = int.Parse(Label2_0.Text);
                bb = 3;
                Close();
            }
        }
        private void FrmShowReserv_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        private void FrmShowReserv_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (bb == 1)
            {
                VarGeneral.vGuestData = 1;
                VarGeneral._hotelper = 0;
                FrmGuests frm2 = new FrmGuests();
                frm2.Tag = LangArEn;
                frm2.TopMost = true;
                frm2.ShowDialog();
            }
            else if (bb == 3)
            {
                FrmResv frm = new FrmResv();
                frm.Tag = LangArEn;
                frm.TopMost = true;
                frm.ShowDialog();
            }
        }
        private void Frame1_VisibleChanged(object sender, EventArgs e)
        {
            if (Frame1.Visible)
            {
                bb = 0;
            }
        }
        private void buttonExt_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void contextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            button_Close_Click(sender, e);
        }
        private void sdfaToolStripMenuItem_Option0_Click(object sender, EventArgs e)
        {
            Option1_0.Checked = true;
            Option1_1.Checked = false;
            Option1_2.Checked = false;
            button_Save_Click(sender, e);
        }
        private void sdfaToolStripMenuItem_Option1_Click(object sender, EventArgs e)
        {
            Option1_0.Checked = false;
            Option1_1.Checked = true;
            Option1_2.Checked = false;
            button_Save_Click(sender, e);
        }
        private void sdfaToolStripMenuItem_Option2_Click(object sender, EventArgs e)
        {
            Option1_0.Checked = false;
            Option1_1.Checked = false;
            Option1_2.Checked = true;
            button_Save_Click(sender, e);
        }
        private void VS_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(VS.GetData(VS.RowSel, 1).ToString()) > 0)
                {
                    Label2_0.Text = VS.GetData(VS.RowSel, 1).ToString();
                    Label2_1.Text = VS.GetData(VS.RowSel, 2).ToString();
                    Label2_2.Text = VS.GetData(VS.RowSel, 3).ToString();
                    Label2_3.Text = VS.GetData(VS.RowSel, 4).ToString();
                    Label2_4.Text = VS.GetData(VS.RowSel, 5).ToString();
                    Label2_5.Text = VS.GetData(VS.RowSel, 6).ToString();
                    Label2_6.Text = VS.GetData(VS.RowSel, 7).ToString();
                    if (VS.GetData(VS.RowSel, 8).ToString() == "0")
                    {
                        Label2_0.Enabled = true;
                        Option1_1.Enabled = true;
                        Option1_2.Enabled = true;
                        button_Save.Enabled = true;
                    }
                    else
                    {
                        Option1_0.Enabled = false;
                        Option1_1.Enabled = false;
                        Option1_2.Enabled = false;
                        button_Save.Enabled = false;
                    }
                    Frame1.Visible = true;
                    VS.Enabled = false;
                    contextMenuStrip1.Show(Control.MousePosition);
                }
            }
            catch
            {
            }
            VS.RowSel = 0;
        }
    }
}
