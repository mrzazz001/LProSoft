using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using DevComponents.Editors;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Library.RepShow;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmJob : Form
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
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!keyData.ToString().Contains("Control") && !keyData.ToString().ToLower().Contains("delete") && keyData.ToString().Contains("Alt"))
            {
                try
                {
                    VarGeneral.Print_set_Gen_Stat = true;
                    FrmReportsViewer.IsSettingOnly = true;
                    VarGeneral.IsGeneralUsed = true;

                    {

                        FrmReportsViewer frm = new FrmReportsViewer();
                        frm.Repvalue = "RepGeneral";


                        frm.Repvalue = "RepGeneral";
                        //ADDADD





                        frm.Tag = LangArEn;
                        frm.ShowDialog();
                        VarGeneral.IsGeneralUsed = false;
                    }
                    FrmReportsViewer.IsSettingOnly = false;
                }
                catch
                {
                    VarGeneral.Print_set_Gen_Stat = false;
                }


            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private Timer timer1;
        private ExpandableSplitter expandableSplitter1;
        private PanelEx panelEx2;
        private RibbonBar ribbonBar1;
        private SaveFileDialog saveFileDialog1;
        protected SuperGridControl DGV_Main;
        private PanelEx panelEx3;
        private Timer timerInfoBallon;
        private OpenFileDialog openFileDialog1;
        private Panel panel1;
        private DockSite barTopDockSite;
        private DockSite barBottomDockSite;
        public DotNetBarManager dotNetBarManager1;
        private ImageList imageList1;
        private DockSite barLeftDockSite;
        private DockSite barRightDockSite;
        private DockSite dockSite4;
        private DockSite dockSite1;
        private DockSite dockSite2;
        private DockSite dockSite3;
        protected ContextMenuStrip contextMenuStrip1;
        protected ToolStripMenuItem ToolStripMenuItem_Rep;
        protected ToolStripMenuItem ToolStripMenuItem_Det;
        protected ContextMenuStrip contextMenuStrip2;
        private RibbonBar ribbonBar_Tasks;
        private SuperTabControl superTabControl_Main2;
        protected LabelItem labelItem1;
        protected ButtonItem Button_First;
        protected ButtonItem Button_Prev;
        protected TextBoxItem TextBox_Index;
        protected LabelItem Label_Count;
        protected ButtonItem Button_Next;
        protected ButtonItem Button_Last;
        private SuperTabControl superTabControl_Main1;
        protected ButtonItem Button_Close;
        protected ButtonItem Button_Search;
        protected ButtonItem Button_Delete;
        protected ButtonItem Button_Save;
        protected ButtonItem Button_Add;
        protected LabelItem labelItem2;
        private RibbonBar ribbonBar_DGV;
        private SuperTabControl superTabControl_DGV;
        protected TextBoxItem textBox_search;
        protected ButtonItem Button_ExportTable2;
        protected ButtonItem Button_PrintTable;
        protected LabelItem labelItem3;
        protected TextBox textBox_NameE;
        protected Label label40;
        protected TextBox textBox_NameA;
        protected Label label36;
        protected TextBox textBox_ID;
        protected Label label38;
        private TextBoxX textBox_Note;
        private LabelItem lable_Records;
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private T_AccDef _AccDefBind = new T_AccDef();
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
        private List<string> pkeys = new List<string>();
        private Stock_DataDataContext dbInstance;
        private T_Job data_this;
        private Rate_DataDataContext dbInstanceRate;
        private T_User permission = new T_User();
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
        public bool IfAdd
        {
            set
            {
                Button_Add.Visible = value;
            }
        }
        public bool IfDelete
        {
            set
            {
                Button_Delete.Visible = value;
                superTabControl_Main1.Refresh();
            }
        }
        public bool IfSave
        {
            set
            {
                Button_Save.Visible = value;
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
        public bool SetReadOnly
        {
            set
            {
                if (value)
                {
                    State = FormState.Saved;
                }
                Button_Save.Enabled = !value;
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
        public T_Job DataThis
        {
            get
            {
                return data_this;
            }
            set
            {
                data_this = value;
                SetData(data_this);
            }
        }
        private Rate_DataDataContext dbc
        {
            get
            {
                if (dbInstanceRate == null)
                {
                    dbInstanceRate = new Rate_DataDataContext(VarGeneral.BranchRt);
                }
                return dbInstanceRate;
            }
        }
        public T_User Permmission
        {
            get
            {
                return permission;
            }
            set
            {
                if (value == null || !(value.UsrNo != ""))
                {
                    return;
                }
                permission = value;
                if (VarGeneral.SSSLev == "D" || VarGeneral.SSSLev == "E")
                {
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_FilStr, 13))
                    {
                        IfAdd = false;
                    }
                    else
                    {
                        IfAdd = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_FilStr, 14))
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.Emp_FilStr, 15))
                    {
                        IfDelete = false;
                    }
                    else
                    {
                        IfDelete = true;
                    }
                }
                else
                {
                    if (!VarGeneral.TString.ChkStatShow(value.RepAcc1, 5))
                    {
                        IfAdd = false;
                    }
                    else
                    {
                        IfAdd = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.RepAcc1, 6))
                    {
                        CanEdit = false;
                    }
                    else
                    {
                        CanEdit = true;
                    }
                    if (!VarGeneral.TString.ChkStatShow(value.RepAcc1, 7))
                    {
                        IfDelete = false;
                    }
                    else
                    {
                        IfDelete = true;
                    }
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmJob));
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background3 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor1 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BorderColor borderColor2 = new DevComponents.DotNetBar.SuperGrid.Style.BorderColor();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle1 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle baseTreeButtonVisualStyle2 = new DevComponents.DotNetBar.SuperGrid.Style.BaseTreeButtonVisualStyle();
            DevComponents.DotNetBar.SuperGrid.Style.Background background4 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            timer1 = new System.Windows.Forms.Timer(components);
            expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            panelEx2 = new DevComponents.DotNetBar.PanelEx();
            ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            textBox_Note = new DevComponents.DotNetBar.Controls.TextBoxX();
            textBox_NameE = new System.Windows.Forms.TextBox();
            label40 = new System.Windows.Forms.Label();
            textBox_NameA = new System.Windows.Forms.TextBox();
            label36 = new System.Windows.Forms.Label();
            textBox_ID = new System.Windows.Forms.TextBox();
            label38 = new System.Windows.Forms.Label();
            ribbonBar_Tasks = new DevComponents.DotNetBar.RibbonBar();
            superTabControl_Main1 = new DevComponents.DotNetBar.SuperTabControl();
            labelItem2 = new DevComponents.DotNetBar.LabelItem();
            superTabControl_Main2 = new DevComponents.DotNetBar.SuperTabControl();
            labelItem1 = new DevComponents.DotNetBar.LabelItem();
            TextBox_Index = new DevComponents.DotNetBar.TextBoxItem();
            Label_Count = new DevComponents.DotNetBar.LabelItem();
            lable_Records = new DevComponents.DotNetBar.LabelItem();
            saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            DGV_Main = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            panelEx3 = new DevComponents.DotNetBar.PanelEx();
            ribbonBar_DGV = new DevComponents.DotNetBar.RibbonBar();
            superTabControl_DGV = new DevComponents.DotNetBar.SuperTabControl();
            textBox_search = new DevComponents.DotNetBar.TextBoxItem();
            labelItem3 = new DevComponents.DotNetBar.LabelItem();
            timerInfoBallon = new System.Windows.Forms.Timer(components);
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            panel1 = new System.Windows.Forms.Panel();
            barTopDockSite = new DevComponents.DotNetBar.DockSite();
            barBottomDockSite = new DevComponents.DotNetBar.DockSite();
            dotNetBarManager1 = new DevComponents.DotNetBar.DotNetBarManager(components);
            imageList1 = new System.Windows.Forms.ImageList(components);
            barLeftDockSite = new DevComponents.DotNetBar.DockSite();
            barRightDockSite = new DevComponents.DotNetBar.DockSite();
            dockSite4 = new DevComponents.DotNetBar.DockSite();
            dockSite1 = new DevComponents.DotNetBar.DockSite();
            dockSite2 = new DevComponents.DotNetBar.DockSite();
            dockSite3 = new DevComponents.DotNetBar.DockSite();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            ToolStripMenuItem_Rep = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItem_Det = new System.Windows.Forms.ToolStripMenuItem();
            contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(components);
            Button_Close = new DevComponents.DotNetBar.ButtonItem();
            Button_Search = new DevComponents.DotNetBar.ButtonItem();
            Button_Delete = new DevComponents.DotNetBar.ButtonItem();
            Button_Save = new DevComponents.DotNetBar.ButtonItem();
            Button_Add = new DevComponents.DotNetBar.ButtonItem();
            Button_First = new DevComponents.DotNetBar.ButtonItem();
            Button_Prev = new DevComponents.DotNetBar.ButtonItem();
            Button_Next = new DevComponents.DotNetBar.ButtonItem();
            Button_Last = new DevComponents.DotNetBar.ButtonItem();
            Button_ExportTable2 = new DevComponents.DotNetBar.ButtonItem();
            Button_PrintTable = new DevComponents.DotNetBar.ButtonItem();
            panelEx2.SuspendLayout();
            ribbonBar1.SuspendLayout();
            ribbonBar_Tasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)superTabControl_Main1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)superTabControl_Main2).BeginInit();
            panelEx3.SuspendLayout();
            ribbonBar_DGV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)superTabControl_DGV).BeginInit();
            panel1.SuspendLayout();
            contextMenuStrip2.SuspendLayout();
            SuspendLayout();
            timer1.Interval = 1000;
            expandableSplitter1.BackColor = System.Drawing.Color.FromArgb(227, 239, 255);
            expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(101, 147, 207);
            expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None;
            resources.ApplyResources(expandableSplitter1, "expandableSplitter1");
            expandableSplitter1.ExpandableControl = panelEx2;
            expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(0, 45, 150);
            expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            expandableSplitter1.ExpandLineColor = System.Drawing.SystemColors.ControlText;
            expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            expandableSplitter1.ForeColor = System.Drawing.Color.Black;
            expandableSplitter1.GripDarkColor = System.Drawing.SystemColors.ControlText;
            expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(223, 237, 254);
            expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(254, 142, 75);
            expandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(255, 207, 139);
            expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(0, 45, 150);
            expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            expandableSplitter1.HotExpandLineColor = System.Drawing.SystemColors.ControlText;
            expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(0, 45, 150);
            expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(223, 237, 254);
            expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            expandableSplitter1.Name = "expandableSplitter1";
            expandableSplitter1.TabStop = false;
            panelEx2.Controls.Add(ribbonBar1);
            panelEx2.Controls.Add(ribbonBar_Tasks);
            resources.ApplyResources(panelEx2, "panelEx2");
            panelEx2.MinimumSize = new System.Drawing.Size(649, 304);
            panelEx2.Name = "panelEx2";
            panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            panelEx2.Style.GradientAngle = 90;
            ribbonBar1.AutoOverflowEnabled = true;
            ribbonBar1.BackgroundMouseOverStyle.BackColor = System.Drawing.Color.AliceBlue;
            ribbonBar1.BackgroundMouseOverStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.BackgroundStyle.BackColor = System.Drawing.Color.AliceBlue;
            ribbonBar1.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientActiveCaption;
            ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.ContainerControlProcessDialogKey = true;
            ribbonBar1.Controls.Add(textBox_Note);
            ribbonBar1.Controls.Add(textBox_NameE);
            ribbonBar1.Controls.Add(label40);
            ribbonBar1.Controls.Add(textBox_NameA);
            ribbonBar1.Controls.Add(label36);
            ribbonBar1.Controls.Add(textBox_ID);
            ribbonBar1.Controls.Add(label38);
            resources.ApplyResources(ribbonBar1, "ribbonBar1");
            ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            ribbonBar1.Name = "ribbonBar1";
            ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            ribbonBar1.TitleStyle.BackColor = System.Drawing.Color.FromArgb(227, 239, 255);
            ribbonBar1.TitleStyle.BackColor2 = System.Drawing.Color.FromArgb(101, 147, 207);
            ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_Note.BackColor = System.Drawing.Color.AliceBlue;
            textBox_Note.Border.Class = "TextBoxBorder";
            textBox_Note.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textBox_Note.ButtonCustom.Visible = true;
            textBox_Note.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(textBox_Note, "textBox_Note");
            textBox_Note.Name = "textBox_Note";
            textBox_Note.WatermarkColor = System.Drawing.Color.RosyBrown;
            textBox_Note.WatermarkFont = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            textBox_Note.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            textBox_NameE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(textBox_NameE, "textBox_NameE");
            textBox_NameE.ForeColor = System.Drawing.Color.Black;
            textBox_NameE.Name = "textBox_NameE";
            resources.ApplyResources(label40, "label40");
            label40.BackColor = System.Drawing.Color.Transparent;
            label40.Name = "label40";
            textBox_NameA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(textBox_NameA, "textBox_NameA");
            textBox_NameA.ForeColor = System.Drawing.Color.Black;
            textBox_NameA.Name = "textBox_NameA";
            resources.ApplyResources(label36, "label36");
            label36.BackColor = System.Drawing.Color.Transparent;
            label36.Name = "label36";
            textBox_ID.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
            textBox_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(textBox_ID, "textBox_ID");
            textBox_ID.Name = "textBox_ID";
            textBox_ID.TextChanged += new System.EventHandler(textBox_ID_TextChanged);
            textBox_ID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox_ID_KeyPress);
            resources.ApplyResources(label38, "label38");
            label38.BackColor = System.Drawing.Color.Transparent;
            label38.Name = "label38";
            ribbonBar_Tasks.AutoOverflowEnabled = true;
            ribbonBar_Tasks.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar_Tasks.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar_Tasks.ContainerControlProcessDialogKey = true;
            ribbonBar_Tasks.Controls.Add(superTabControl_Main1);
            ribbonBar_Tasks.Controls.Add(superTabControl_Main2);
            resources.ApplyResources(ribbonBar_Tasks, "ribbonBar_Tasks");
            ribbonBar_Tasks.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            ribbonBar_Tasks.Name = "ribbonBar_Tasks";
            ribbonBar_Tasks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ribbonBar_Tasks.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar_Tasks.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar_Tasks.TitleVisible = false;
            superTabControl_Main1.BackColor = System.Drawing.Color.White;
            superTabControl_Main1.CausesValidation = false;
            superTabControl_Main1.ControlBox.CloseBox.Name = "";
            superTabControl_Main1.ControlBox.MenuBox.Name = "";
            superTabControl_Main1.ControlBox.Name = "";
            superTabControl_Main1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[2]
            {
                superTabControl_Main1.ControlBox.MenuBox,
                superTabControl_Main1.ControlBox.CloseBox
            });
            superTabControl_Main1.ControlBox.Visible = false;
            resources.ApplyResources(superTabControl_Main1, "superTabControl_Main1");
            superTabControl_Main1.ForeColor = System.Drawing.Color.Black;
            superTabControl_Main1.ItemPadding.Bottom = 4;
            superTabControl_Main1.ItemPadding.Left = 2;
            superTabControl_Main1.ItemPadding.Top = 4;
            superTabControl_Main1.Name = "superTabControl_Main1";
            superTabControl_Main1.ReorderTabsEnabled = true;
            superTabControl_Main1.SelectedTabIndex = -1;
            superTabControl_Main1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[6]
            {
                Button_Close,
                Button_Search,
                Button_Delete,
                Button_Save,
                Button_Add,
                labelItem2
            });
            superTabControl_Main1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            superTabControl_Main1.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            labelItem2.Name = "labelItem2";
            labelItem2.Width = 40;
            superTabControl_Main2.BackColor = System.Drawing.Color.White;
            superTabControl_Main2.CausesValidation = false;
            superTabControl_Main2.ControlBox.CloseBox.Name = "";
            superTabControl_Main2.ControlBox.MenuBox.Name = "";
            superTabControl_Main2.ControlBox.Name = "";
            superTabControl_Main2.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[2]
            {
                superTabControl_Main2.ControlBox.MenuBox,
                superTabControl_Main2.ControlBox.CloseBox
            });
            superTabControl_Main2.ControlBox.Visible = false;
            resources.ApplyResources(superTabControl_Main2, "superTabControl_Main2");
            superTabControl_Main2.ForeColor = System.Drawing.Color.Black;
            superTabControl_Main2.ItemPadding.Bottom = 4;
            superTabControl_Main2.ItemPadding.Left = 4;
            superTabControl_Main2.ItemPadding.Right = 4;
            superTabControl_Main2.ItemPadding.Top = 4;
            superTabControl_Main2.Name = "superTabControl_Main2";
            superTabControl_Main2.ReorderTabsEnabled = true;
            superTabControl_Main2.SelectedTabIndex = -1;
            superTabControl_Main2.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[8]
            {
                labelItem1,
                Button_First,
                Button_Prev,
                TextBox_Index,
                Label_Count,
                lable_Records,
                Button_Next,
                Button_Last
            });
            superTabControl_Main2.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            superTabControl_Main2.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            labelItem1.Name = "labelItem1";
            labelItem1.Width = 2;
            TextBox_Index.Name = "TextBox_Index";
            resources.ApplyResources(TextBox_Index, "TextBox_Index");
            TextBox_Index.TextBoxWidth = 50;
            TextBox_Index.Visible = false;
            TextBox_Index.WatermarkColor = System.Drawing.SystemColors.GrayText;
            Label_Count.Name = "Label_Count";
            Label_Count.Visible = false;
            Label_Count.Width = 40;
            lable_Records.BackColor = System.Drawing.Color.SteelBlue;
            lable_Records.ForeColor = System.Drawing.Color.White;
            lable_Records.Name = "lable_Records";
            resources.ApplyResources(lable_Records, "lable_Records");
            saveFileDialog1.DefaultExt = "*.rtf";
            saveFileDialog1.FileName = "doc1";
            resources.ApplyResources(saveFileDialog1, "saveFileDialog1");
            saveFileDialog1.FilterIndex = 2;
            DGV_Main.BackColor = System.Drawing.Color.Transparent;
            background1.BackFillType = DevComponents.DotNetBar.SuperGrid.Style.BackFillType.VerticalCenter;
            background1.Color1 = System.Drawing.Color.Silver;
            background1.Color2 = System.Drawing.Color.White;
            DGV_Main.DefaultVisualStyles.GroupByStyles.Default.Background = background1;
            background2.BackFillType = DevComponents.DotNetBar.SuperGrid.Style.BackFillType.Center;
            background2.Color1 = System.Drawing.Color.LightSteelBlue;
            DGV_Main.DefaultVisualStyles.RowStyles.Default.Background = background2;
            background3.Color1 = System.Drawing.Color.FromArgb(255, 255, 192);
            DGV_Main.DefaultVisualStyles.RowStyles.MouseOver.Background = background3;
            resources.ApplyResources(DGV_Main, "DGV_Main");
            DGV_Main.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            DGV_Main.ForeColor = System.Drawing.Color.Black;
            DGV_Main.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            DGV_Main.Name = "DGV_Main";
            DGV_Main.PrimaryGrid.ActiveRowIndicatorStyle = DevComponents.DotNetBar.SuperGrid.ActiveRowIndicatorStyle.Both;
            DGV_Main.PrimaryGrid.AllowEdit = false;
            DGV_Main.PrimaryGrid.Caption.BackgroundImageLayout = DevComponents.DotNetBar.SuperGrid.GridBackgroundImageLayout.Center;
            DGV_Main.PrimaryGrid.Caption.Text = "";
            DGV_Main.PrimaryGrid.Caption.Visible = false;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.TextColor = System.Drawing.Color.Black;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.TextColor = System.Drawing.Color.Black;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.CaptionStyles.Default.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            DGV_Main.PrimaryGrid.DefaultVisualStyles.CaptionStyles.Default.TextColor = System.Drawing.Color.White;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.CaptionStyles.ReadOnly.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.CellStyles.Selected.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderRowStyles.Default.RowHeader.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            borderColor1.Bottom = System.Drawing.Color.Black;
            borderColor1.Left = System.Drawing.Color.Black;
            borderColor1.Right = System.Drawing.Color.Black;
            borderColor1.Top = System.Drawing.Color.Black;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.BorderColor = borderColor1;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            DGV_Main.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.TextColor = System.Drawing.Color.SteelBlue;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.TextColor = System.Drawing.Color.White;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.FooterStyles.Default.TextColor = System.Drawing.Color.White;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.False;
            borderColor2.Bottom = System.Drawing.Color.Black;
            borderColor2.Left = System.Drawing.Color.Black;
            borderColor2.Right = System.Drawing.Color.Black;
            borderColor2.Top = System.Drawing.Color.Black;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.BorderColor = borderColor2;
            baseTreeButtonVisualStyle1.BorderColor = System.Drawing.Color.White;
            baseTreeButtonVisualStyle1.LineColor = System.Drawing.Color.White;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.CircleTreeButtonStyle.ExpandButton = baseTreeButtonVisualStyle1;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.HeaderHLinePattern = DevComponents.DotNetBar.SuperGrid.Style.LinePattern.None;
            background4.Color1 = System.Drawing.Color.FromArgb(255, 255, 192);
            baseTreeButtonVisualStyle2.Background = background4;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.SquareTreeButtonStyle.ExpandButton = baseTreeButtonVisualStyle2;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.GridPanelStyle.TextColor = System.Drawing.Color.White;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.TitleStyles.Default.RowHeaderStyle.TextAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            DGV_Main.PrimaryGrid.GroupByRow.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.Never;
            DGV_Main.PrimaryGrid.GroupByRow.Text = "???????????? ??????????????????????";
            DGV_Main.PrimaryGrid.GroupByRow.Visible = true;
            DGV_Main.PrimaryGrid.GroupByRow.WatermarkText = "";
            DGV_Main.PrimaryGrid.InitialActiveRow = DevComponents.DotNetBar.SuperGrid.RelativeRow.None;
            DGV_Main.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.None;
            DGV_Main.PrimaryGrid.MultiSelect = false;
            DGV_Main.PrimaryGrid.ShowRowGridIndex = true;
            DGV_Main.PrimaryGrid.Title.AllowSelection = false;
            DGV_Main.PrimaryGrid.Title.Text = "";
            DGV_Main.PrimaryGrid.Title.Visible = false;
            DGV_Main.PrimaryGrid.Visible = false;
            panelEx3.Controls.Add(DGV_Main);
            panelEx3.Controls.Add(ribbonBar_DGV);
            resources.ApplyResources(panelEx3, "panelEx3");
            panelEx3.Name = "panelEx3";
            panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            panelEx3.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            panelEx3.Style.GradientAngle = 90;
            ribbonBar_DGV.AutoOverflowEnabled = true;
            ribbonBar_DGV.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar_DGV.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar_DGV.ContainerControlProcessDialogKey = true;
            ribbonBar_DGV.Controls.Add(superTabControl_DGV);
            resources.ApplyResources(ribbonBar_DGV, "ribbonBar_DGV");
            ribbonBar_DGV.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            ribbonBar_DGV.Name = "ribbonBar_DGV";
            ribbonBar_DGV.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ribbonBar_DGV.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar_DGV.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            ribbonBar_DGV.TitleVisible = false;
            superTabControl_DGV.BackColor = System.Drawing.Color.White;
            superTabControl_DGV.CausesValidation = false;
            superTabControl_DGV.ControlBox.CloseBox.Name = "";
            superTabControl_DGV.ControlBox.MenuBox.Name = "";
            superTabControl_DGV.ControlBox.Name = "";
            superTabControl_DGV.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[2]
            {
                superTabControl_DGV.ControlBox.MenuBox,
                superTabControl_DGV.ControlBox.CloseBox
            });
            superTabControl_DGV.ControlBox.Visible = false;
            resources.ApplyResources(superTabControl_DGV, "superTabControl_DGV");
            superTabControl_DGV.ForeColor = System.Drawing.Color.Black;
            superTabControl_DGV.ItemPadding.Bottom = 4;
            superTabControl_DGV.ItemPadding.Left = 4;
            superTabControl_DGV.ItemPadding.Right = 4;
            superTabControl_DGV.ItemPadding.Top = 4;
            superTabControl_DGV.Name = "superTabControl_DGV";
            superTabControl_DGV.ReorderTabsEnabled = true;
            superTabControl_DGV.SelectedTabIndex = -1;
            superTabControl_DGV.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[4]
            {
                textBox_search,
                Button_ExportTable2,
                Button_PrintTable,
                labelItem3
            });
            superTabControl_DGV.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            superTabControl_DGV.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            textBox_search.ButtonCustom.Text = resources.GetString("textBox_search.ButtonCustom.Text");
            textBox_search.ButtonCustom.Visible = true;
            textBox_search.Name = "textBox_search";
            resources.ApplyResources(textBox_search, "textBox_search");
            textBox_search.TextBoxHeight = 44;
            textBox_search.TextBoxWidth = 150;
            textBox_search.WatermarkColor = System.Drawing.SystemColors.GrayText;
            labelItem3.Name = "labelItem3";
            labelItem3.Width = 40;
            timerInfoBallon.Interval = 3000;
            openFileDialog1.DefaultExt = "*.rtf";
            resources.ApplyResources(openFileDialog1, "openFileDialog1");
            openFileDialog1.FilterIndex = 2;
            panel1.Controls.Add(panelEx3);
            panel1.Controls.Add(expandableSplitter1);
            panel1.Controls.Add(panelEx2);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            barTopDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(barTopDockSite, "barTopDockSite");
            barTopDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            barTopDockSite.Name = "barTopDockSite";
            barTopDockSite.TabStop = false;
            barBottomDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(barBottomDockSite, "barBottomDockSite");
            barBottomDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            barBottomDockSite.Name = "barBottomDockSite";
            barBottomDockSite.TabStop = false;
            dotNetBarManager1.BottomDockSite = barBottomDockSite;
            dotNetBarManager1.Images = imageList1;
            dotNetBarManager1.LeftDockSite = barLeftDockSite;
            dotNetBarManager1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            dotNetBarManager1.MdiSystemItemVisible = false;
            dotNetBarManager1.ParentForm = null;
            dotNetBarManager1.RightDockSite = barRightDockSite;
            dotNetBarManager1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2000;
            dotNetBarManager1.ToolbarBottomDockSite = dockSite4;
            dotNetBarManager1.ToolbarLeftDockSite = dockSite1;
            dotNetBarManager1.ToolbarRightDockSite = dockSite2;
            dotNetBarManager1.ToolbarTopDockSite = dockSite3;
            dotNetBarManager1.TopDockSite = barTopDockSite;
            imageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = System.Drawing.Color.Magenta;
            imageList1.Images.SetKeyName(0, "");
            imageList1.Images.SetKeyName(1, "");
            imageList1.Images.SetKeyName(2, "");
            imageList1.Images.SetKeyName(3, "");
            imageList1.Images.SetKeyName(4, "");
            imageList1.Images.SetKeyName(5, "");
            imageList1.Images.SetKeyName(6, "");
            imageList1.Images.SetKeyName(7, "");
            imageList1.Images.SetKeyName(8, "");
            imageList1.Images.SetKeyName(9, "");
            imageList1.Images.SetKeyName(10, "");
            imageList1.Images.SetKeyName(11, "");
            imageList1.Images.SetKeyName(12, "");
            imageList1.Images.SetKeyName(13, "");
            imageList1.Images.SetKeyName(14, "");
            imageList1.Images.SetKeyName(15, "");
            imageList1.Images.SetKeyName(16, "");
            imageList1.Images.SetKeyName(17, "");
            imageList1.Images.SetKeyName(18, "");
            imageList1.Images.SetKeyName(19, "");
            imageList1.Images.SetKeyName(20, "");
            imageList1.Images.SetKeyName(21, "");
            imageList1.Images.SetKeyName(22, "");
            imageList1.Images.SetKeyName(23, "");
            barLeftDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(barLeftDockSite, "barLeftDockSite");
            barLeftDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            barLeftDockSite.Name = "barLeftDockSite";
            barLeftDockSite.TabStop = false;
            barRightDockSite.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(barRightDockSite, "barRightDockSite");
            barRightDockSite.DocumentDockContainer = new DevComponents.DotNetBar.DocumentDockContainer();
            barRightDockSite.Name = "barRightDockSite";
            barRightDockSite.TabStop = false;
            dockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(dockSite4, "dockSite4");
            dockSite4.Name = "dockSite4";
            dockSite4.TabStop = false;
            dockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(dockSite1, "dockSite1");
            dockSite1.Name = "dockSite1";
            dockSite1.TabStop = false;
            dockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(dockSite2, "dockSite2");
            dockSite2.Name = "dockSite2";
            dockSite2.TabStop = false;
            dockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(dockSite3, "dockSite3");
            dockSite3.Name = "dockSite3";
            dockSite3.TabStop = false;
            contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(contextMenuStrip1, "contextMenuStrip1");
            ToolStripMenuItem_Rep.Checked = true;
            ToolStripMenuItem_Rep.CheckState = System.Windows.Forms.CheckState.Checked;
            ToolStripMenuItem_Rep.Name = "ToolStripMenuItem_Rep";
            resources.ApplyResources(ToolStripMenuItem_Rep, "ToolStripMenuItem_Rep");
            ToolStripMenuItem_Det.Name = "ToolStripMenuItem_Det";
            resources.ApplyResources(ToolStripMenuItem_Det, "ToolStripMenuItem_Det");
            contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[2]
            {
                ToolStripMenuItem_Det,
                ToolStripMenuItem_Rep
            });
            contextMenuStrip2.Name = "contextMenuStrip2";
            resources.ApplyResources(contextMenuStrip2, "contextMenuStrip2");
            Button_Close.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_Close.Checked = true;
            Button_Close.FontBold = true;
            Button_Close.FontItalic = true;
            Button_Close.ForeColor = System.Drawing.Color.Black;
            Button_Close.Image = (System.Drawing.Image)resources.GetObject("Button_Close.Image");
            Button_Close.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_Close.ImagePaddingHorizontal = 15;
            Button_Close.ImagePaddingVertical = 11;
            Button_Close.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_Close.Name = "Button_Close";
            Button_Close.Stretch = true;
            Button_Close.SubItemsExpandWidth = 14;
            Button_Close.Symbol = "\uf057";
            Button_Close.SymbolSize = 15f;
            resources.ApplyResources(Button_Close, "Button_Close");
            Button_Search.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_Search.FontBold = true;
            Button_Search.FontItalic = true;
            Button_Search.ForeColor = System.Drawing.Color.Green;
            Button_Search.Image = (System.Drawing.Image)resources.GetObject("Button_Search.Image");
            Button_Search.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_Search.ImagePaddingHorizontal = 15;
            Button_Search.ImagePaddingVertical = 11;
            Button_Search.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_Search.Name = "Button_Search";
            Button_Search.Stretch = true;
            Button_Search.SubItemsExpandWidth = 14;
            Button_Search.Symbol = "\uf002";
            Button_Search.SymbolSize = 15f;
            resources.ApplyResources(Button_Search, "Button_Search");
            Button_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_Delete.FontBold = true;
            Button_Delete.FontItalic = true;
            Button_Delete.ForeColor = System.Drawing.Color.SteelBlue;
            Button_Delete.Image = (System.Drawing.Image)resources.GetObject("Button_Delete.Image");
            Button_Delete.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_Delete.ImagePaddingHorizontal = 15;
            Button_Delete.ImagePaddingVertical = 11;
            Button_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_Delete.Name = "Button_Delete";
            Button_Delete.Stretch = true;
            Button_Delete.SubItemsExpandWidth = 14;
            Button_Delete.Symbol = "\uf014";
            Button_Delete.SymbolSize = 15f;
            resources.ApplyResources(Button_Delete, "Button_Delete");
            Button_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_Save.FontBold = true;
            Button_Save.FontItalic = true;
            Button_Save.ForeColor = System.Drawing.Color.FromArgb(192, 64, 0);
            Button_Save.Image = (System.Drawing.Image)resources.GetObject("Button_Save.Image");
            Button_Save.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_Save.ImagePaddingHorizontal = 15;
            Button_Save.ImagePaddingVertical = 11;
            Button_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_Save.Name = "Button_Save";
            Button_Save.Stretch = true;
            Button_Save.SubItemsExpandWidth = 14;
            Button_Save.Symbol = "\uf0c7";
            Button_Save.SymbolSize = 15f;
            resources.ApplyResources(Button_Save, "Button_Save");
            Button_Add.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_Add.FontBold = true;
            Button_Add.FontItalic = true;
            Button_Add.ForeColor = System.Drawing.Color.Blue;
            Button_Add.Image = (System.Drawing.Image)resources.GetObject("Button_Add.Image");
            Button_Add.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_Add.ImagePaddingHorizontal = 15;
            Button_Add.ImagePaddingVertical = 11;
            Button_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_Add.Name = "Button_Add";
            Button_Add.Stretch = true;
            Button_Add.SubItemsExpandWidth = 14;
            Button_Add.Symbol = "\uf055";
            Button_Add.SymbolSize = 15f;
            resources.ApplyResources(Button_Add, "Button_Add");
            Button_First.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_First.FontBold = true;
            Button_First.FontItalic = true;
            Button_First.ForeColor = System.Drawing.Color.SteelBlue;
            Button_First.Image = (System.Drawing.Image)resources.GetObject("Button_First.Image");
            Button_First.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_First.ImagePaddingHorizontal = 15;
            Button_First.ImagePaddingVertical = 11;
            Button_First.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_First.Name = "Button_First";
            Button_First.SplitButton = true;
            Button_First.Stretch = true;
            Button_First.SubItemsExpandWidth = 14;
            Button_First.Symbol = "\uf051";
            Button_First.SymbolSize = 15f;
            resources.ApplyResources(Button_First, "Button_First");
            Button_Prev.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_Prev.FontBold = true;
            Button_Prev.FontItalic = true;
            Button_Prev.ForeColor = System.Drawing.Color.SteelBlue;
            Button_Prev.Image = (System.Drawing.Image)resources.GetObject("Button_Prev.Image");
            Button_Prev.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_Prev.ImagePaddingHorizontal = 15;
            Button_Prev.ImagePaddingVertical = 11;
            Button_Prev.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_Prev.Name = "Button_Prev";
            Button_Prev.SplitButton = true;
            Button_Prev.Stretch = true;
            Button_Prev.SubItemsExpandWidth = 14;
            Button_Prev.Symbol = "\uf04e";
            Button_Prev.SymbolSize = 15f;
            resources.ApplyResources(Button_Prev, "Button_Prev");
            Button_Next.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_Next.FontBold = true;
            Button_Next.FontItalic = true;
            Button_Next.ForeColor = System.Drawing.Color.SteelBlue;
            Button_Next.Image = (System.Drawing.Image)resources.GetObject("Button_Next.Image");
            Button_Next.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_Next.ImagePaddingHorizontal = 15;
            Button_Next.ImagePaddingVertical = 11;
            Button_Next.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_Next.Name = "Button_Next";
            Button_Next.SplitButton = true;
            Button_Next.Stretch = true;
            Button_Next.SubItemsExpandWidth = 14;
            Button_Next.Symbol = "\uf04a";
            Button_Next.SymbolSize = 15f;
            resources.ApplyResources(Button_Next, "Button_Next");
            Button_Last.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_Last.FontBold = true;
            Button_Last.FontItalic = true;
            Button_Last.ForeColor = System.Drawing.Color.SteelBlue;
            Button_Last.Image = (System.Drawing.Image)resources.GetObject("Button_Last.Image");
            Button_Last.ImageFixedSize = new System.Drawing.Size(28, 28);
            Button_Last.ImagePaddingHorizontal = 15;
            Button_Last.ImagePaddingVertical = 11;
            Button_Last.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_Last.Name = "Button_Last";
            Button_Last.SplitButton = true;
            Button_Last.Stretch = true;
            Button_Last.SubItemsExpandWidth = 14;
            Button_Last.Symbol = "\uf048";
            Button_Last.SymbolSize = 15f;
            resources.ApplyResources(Button_Last, "Button_Last");
            Button_ExportTable2.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_ExportTable2.FontBold = true;
            Button_ExportTable2.FontItalic = true;
            Button_ExportTable2.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            Button_ExportTable2.Image = (System.Drawing.Image)resources.GetObject("Button_ExportTable2.Image");
            Button_ExportTable2.ImageFixedSize = new System.Drawing.Size(32, 32);
            Button_ExportTable2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_ExportTable2.Name = "Button_ExportTable2";
            Button_ExportTable2.SubItemsExpandWidth = 14;
            Button_ExportTable2.Symbol = "\uf064";
            Button_ExportTable2.SymbolSize = 15f;
            resources.ApplyResources(Button_ExportTable2, "Button_ExportTable2");
            Button_PrintTable.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            Button_PrintTable.Checked = true;
            Button_PrintTable.FontBold = true;
            Button_PrintTable.FontItalic = true;
            Button_PrintTable.Image = (System.Drawing.Image)resources.GetObject("Button_PrintTable.Image");
            Button_PrintTable.ImageFixedSize = new System.Drawing.Size(32, 32);
            Button_PrintTable.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            Button_PrintTable.Name = "Button_PrintTable";
            Button_PrintTable.SubItemsExpandWidth = 14;
            Button_PrintTable.Symbol = "\uf0c5";
            Button_PrintTable.SymbolSize = 15f;
            resources.ApplyResources(Button_PrintTable, "Button_PrintTable");
            resources.ApplyResources(this, "$this");
            base.Controls.Add(panel1);
            base.Controls.Add(barTopDockSite);
            base.Controls.Add(barBottomDockSite);
            base.Controls.Add(barLeftDockSite);
            base.Controls.Add(barRightDockSite);
            base.Controls.Add(dockSite4);
            base.Controls.Add(dockSite1);
            base.Controls.Add(dockSite2);
            base.Controls.Add(dockSite3);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "FrmJob";
            base.Load += new System.EventHandler(FrmJob_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Frm_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(Frm_KeyDown);
            panelEx2.ResumeLayout(false);
            ribbonBar1.ResumeLayout(false);
            ribbonBar1.PerformLayout();
            ribbonBar_Tasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)superTabControl_Main1).EndInit();
            ((System.ComponentModel.ISupportInitialize)superTabControl_Main2).EndInit();
            panelEx3.ResumeLayout(false);
            ribbonBar_DGV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)superTabControl_DGV).EndInit();
            panel1.ResumeLayout(false);
            contextMenuStrip2.ResumeLayout(false);
            ResumeLayout(false);
        }
        public void Button_First_Click(object sender, EventArgs e)
        {
            if (ContinueIfEditOrNew())
            {
                TextBox_Index.TextBox.Text = string.Concat(1);
                UpdateVcr();
                textBox_ID.Focus();
            }
        }
        public void Button_Prev_Click(object sender, EventArgs e)
        {
            if (ContinueIfEditOrNew())
            {
                int index = 0;
                try
                {
                    index = Convert.ToInt32(TextBox_Index.TextBox.Text);
                }
                catch
                {
                }
                if (index > 1)
                {
                    TextBox_Index.TextBox.Text = string.Concat(index - 1);
                }
                UpdateVcr();
                textBox_ID.Focus();
            }
        }
        public void Button_Next_Click(object sender, EventArgs e)
        {
            if (ContinueIfEditOrNew())
            {
                int index = 0;
                int count = 0;
                try
                {
                    index = Convert.ToInt32(TextBox_Index.TextBox.Text);
                }
                catch
                {
                }
                try
                {
                    count = Convert.ToInt32(Label_Count.Text);
                }
                catch
                {
                }
                if (index < count)
                {
                    TextBox_Index.TextBox.Text = string.Concat(index + 1);
                }
                UpdateVcr();
                textBox_ID.Focus();
            }
        }
        public void Button_Last_Click(object sender, EventArgs e)
        {
            if (ContinueIfEditOrNew())
            {
                TextBox_Index.TextBox.Text = Label_Count.Text;
                UpdateVcr();
            }
        }
        private void UpdateVcr()
        {
            int vCount = 0;
            int vPosition = 0;
            try
            {
                vCount = int.Parse(Label_Count.Text);
            }
            catch
            {
                vCount = 0;
            }
            try
            {
                vPosition = int.Parse(TextBox_Index.Text);
            }
            catch
            {
                vPosition = 0;
            }
            if (vCount <= 1)
            {
                Button_First.Enabled = false;
                Button_Prev.Enabled = false;
                Button_Next.Enabled = false;
                Button_Last.Enabled = false;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    lable_Records.Text = ((vCount == 0) ? "???????????? ??????????" : "?????? ???????? ??????");
                }
                else
                {
                    lable_Records.Text = ((vCount == 0) ? "No records" : "Only Record");
                }
                return;
            }
            if (vPosition == 1)
            {
                ButtonItem button_First = Button_First;
                bool enabled = (Button_Prev.Enabled = false);
                button_First.Enabled = enabled;
                ButtonItem button_Last = Button_Last;
                enabled = (Button_Next.Enabled = vCount > 1);
                button_Last.Enabled = enabled;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    lable_Records.Text = "?????????? ???? " + vCount + " ??????????";
                }
                else
                {
                    lable_Records.Text = "First of " + vCount + " records";
                }
                return;
            }
            if (vPosition == vCount)
            {
                Button_Last.Enabled = false;
                Button_Next.Enabled = false;
                ButtonItem button_First2 = Button_First;
                bool enabled = (Button_Prev.Enabled = vCount > 1);
                button_First2.Enabled = enabled;
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    lable_Records.Text = "???????????? ???? " + vCount + " ??????????";
                }
                else
                {
                    lable_Records.Text = "Last of " + vCount + " records";
                }
                return;
            }
            Button_First.Enabled = true;
            Button_Prev.Enabled = true;
            Button_Next.Enabled = true;
            Button_Last.Enabled = true;
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                lable_Records.Text = "?????????? " + vPosition + " ???? " + vCount;
            }
            else
            {
                lable_Records.Text = "Record " + vPosition + " of " + vCount;
            }
        }
        protected bool ContinueIfEditOrNew()
        {
            if (State == FormState.Edit || State == FormState.New)
            {
                if (MessageBox.Show((LangArEn == 0) ? "???? ?????????? ?????????? ???????????? ?????? ?????? ?????????????????? .. ???? ???????? ??????????????????" : "Not saved the changes, do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    return false;
                }
                return true;
            }
            return true;
        }
        public void Button_Search_Click(object sender, EventArgs e)
        {
            FrmSearch frm = new FrmSearch();
            frm.Tag = LangArEn;
            ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
            foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
            {
                frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
            }
            VarGeneral.SFrmTyp = "T_Job";
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.SerachNo != "")
            {
                textBox_ID.Text = frm.SerachNo.ToString();
            }
        }
        private void TextBox_Search_ButtonCustomClick(object sender, EventArgs e)
        {
            textBox_search.Text = "";
        }
        private void textBox_Note_ButtonCustomClick(object sender, EventArgs e)
        {
            textBox_Note.Text = "";
        }
        private void ToolStripMenuItem_Det_Click(object sender, EventArgs e)
        {
            int rowIndex = Convert.ToInt32(DGV_Main.PrimaryGrid.Tag);
            TextBox_Index.TextBox.Text = string.Concat(rowIndex + 1);
            expandableSplitter1.Expanded = true;
            ViewDetails_Click(sender, e);
        }
        public void ViewDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(Label_Count.Text ?? "") <= 0 || (Label_Count.Text ?? "") == "")
                {
                    expandableSplitter1.Expandable = false;
                    return;
                }
                expandableSplitter1.Expandable = true;
                DGV_Main.PrimaryGrid.DataSource = null;
                DGV_Main.PrimaryGrid.VirtualMode = false;
                ViewState = ViewState.Deiles;
            }
            catch
            {
            }
        }
        public void ViewTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(Label_Count.Text ?? "") <= 0 || (Label_Count.Text ?? "") == "")
                {
                    expandableSplitter1.Expandable = false;
                    return;
                }
                expandableSplitter1.Expandable = true;
                ViewState = ViewState.Table;
            }
            catch
            {
            }
            Fill_DGV_Main();
            int index = -1;
            try
            {
                index = Convert.ToInt32(TextBox_Index.TextBox.Text);
            }
            catch
            {
                index = -1;
            }
            index--;
            if (index < DGV_Main.PrimaryGrid.Rows.Count && index >= 0)
            {
                DGV_Main.PrimaryGrid.Rows[index].EnsureVisible();
            }
        }
        private void DGV_Main_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                GridElement item = DGV_Main.GetElementAt(e.Location);
                if (item is GridColumnHeader)
                {
                    GridColumnHeader gch = (GridColumnHeader)item;
                    GridColumn column = null;
                    HeaderArea area = gch.GetHitArea(e.Location, ref column);
                    contextMenuStrip1.Show(Control.MousePosition);
                }
                else
                {
                    contextMenuStrip2.Show(Control.MousePosition);
                }
            }
        }
        public void Fill_DGV_Main()
        {
            DGV_Main.PrimaryGrid.VirtualMode = false;
            List<T_Job> list = db.FillJob_2(textBox_search.TextBox.Text).ToList();
            if (DGV_Main.PrimaryGrid.Columns.Count == 0)
            {
                foreach (KeyValuePair<string, ColumnDictinary> item in columns_Names_visible)
                {
                    DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(item.Key));
                }
            }
            FillHDGV(list);
        }
        public void FillHDGV(IEnumerable<T_Job> new_data_enum)
        {
            bool contextMenuSet = false;
            if (contextMenuStrip1.Items.Count > 0)
            {
                contextMenuSet = true;
            }
            for (int i = 0; i < DGV_Main.PrimaryGrid.Columns.Count; i++)
            {
                if (columns_Names_visible.ContainsKey(DGV_Main.PrimaryGrid.Columns[i].Name))
                {
                    DGV_Main.PrimaryGrid.Columns[i].AutoSizeMode = ColumnAutoSizeMode.None;
                    DGV_Main.PrimaryGrid.Columns[i].MinimumWidth = 50;
                    DGV_Main.PrimaryGrid.Columns[i].Visible = columns_Names_visible[DGV_Main.PrimaryGrid.Columns[i].Name].IfDefault;
                    DGV_Main.PrimaryGrid.Columns[i].HeaderText = ((LangArEn == 0) ? columns_Names_visible[DGV_Main.PrimaryGrid.Columns[i].Name].AText : columns_Names_visible[DGV_Main.PrimaryGrid.Columns[i].Name].EText);
                    if (!contextMenuSet)
                    {
                        ToolStripMenuItem item = new ToolStripMenuItem();
                        item.Checked = columns_Names_visible[DGV_Main.PrimaryGrid.Columns[i].Name].IfDefault;
                        item.CheckOnClick = true;
                        item.Name = DGV_Main.PrimaryGrid.Columns[i].Name;
                        item.Text = DGV_Main.PrimaryGrid.Columns[i].HeaderText;
                        item.CheckedChanged += item_Click;
                        contextMenuStrip1.Items.Add(item);
                    }
                    else
                    {
                        DGV_Main.PrimaryGrid.Columns[i].Visible = (contextMenuStrip1.Items[DGV_Main.PrimaryGrid.Columns[i].Name] as ToolStripMenuItem).Checked;
                    }
                }
                else
                {
                    DGV_Main.PrimaryGrid.Columns[i].Visible = false;
                }
            }
            DGV_Main.PrimaryGrid.DataSource = new_data_enum.ToList();
            DGV_Main.PrimaryGrid.DataMember = "T_Job";
            DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background.Color2 = Color.LightBlue;
        }
        private void item_Click(object sender, EventArgs e)
        {
            string name = (sender as ToolStripMenuItem).Name;
            try
            {
                string NameExsist = DGV_Main.PrimaryGrid.Columns[name].Name;
            }
            catch
            {
                DGV_Main.PrimaryGrid.Columns.Add(new GridColumn(name));
                DGV_Main.PrimaryGrid.Columns[name].AutoSizeMode = ColumnAutoSizeMode.None;
                DGV_Main.PrimaryGrid.Columns[name].MinimumWidth = 90;
                DGV_Main.PrimaryGrid.Columns[name].HeaderText = columns_Names_visible[name].AText;
            }
            DGV_Main.PrimaryGrid.Columns[name].Visible = (sender as ToolStripMenuItem).Checked;
        }
        private void TextBox_Search_InputTextChanged(object sender)
        {
            Fill_DGV_Main();
        }
        public void Clear()
        {
            if (State == FormState.New)
            {
                return;
            }
            State = FormState.New;
            data_this = new T_Job();
            State = FormState.New;
            for (int i = 0; i < controls.Count; i++)
            {
                if (controls[i].GetType() == typeof(DateTimePicker))
                {
                    int? calendr = VarGeneral.Settings_Sys.Calendr;
                    if (calendr.Value == 0 && calendr.HasValue)
                    {
                        (controls[i] as DateTimePicker).Value = Convert.ToDateTime(n.GDateNow());
                    }
                    else
                    {
                        (controls[i] as DateTimePicker).Text = n.HDateNow();
                    }
                }
                else if (controls[i].GetType() == typeof(CheckBox))
                {
                    (controls[i] as CheckBox).Checked = false;
                }
                else if (controls[i].GetType() == typeof(PictureBox))
                {
                    (controls[i] as PictureBox).Image = null;
                }
                else if (!(controls[i].Name == codeControl.Name))
                {
                    if (controls[i].GetType() == typeof(DoubleInput))
                    {
                        (controls[i] as DoubleInput).Value = 0.0;
                    }
                    else if (controls[i].GetType() == typeof(IntegerInput))
                    {
                        (controls[i] as IntegerInput).Value = 0;
                    }
                    else if (controls[i].GetType() == typeof(TextBox) || controls[i].GetType() == typeof(TextBoxX) || controls[i].GetType() == typeof(MaskedTextBox))
                    {
                        controls[i].Text = "";
                    }
                    else if (controls[i].GetType() == typeof(CheckBox))
                    {
                        (controls[i] as CheckBox).Checked = false;
                    }
                    else if (controls[i].GetType() == typeof(RadioButton))
                    {
                        (controls[i] as RadioButton).Checked = false;
                    }
                    else if (controls[i].GetType() == typeof(ComboBox))
                    {
                        (controls[i] as ComboBox).SelectedIndex = -1;
                    }
                }
            }
            textBox_ID.Focus();
            SetReadOnly = false;
        }
        private void Button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void DGV_Main_CellClick(object sender, GridCellClickEventArgs e)
        {
            DGV_Main.PrimaryGrid.Tag = e.GridCell.RowIndex;
        }
        private void DGV_Main_CellDoubleClick(object sender, GridCellDoubleClickEventArgs e)
        {
            ToolStripMenuItem_Det_Click(sender, e);
        }
        private void textBox_ID_Click(object sender, EventArgs e)
        {
            textBox_ID.SelectAll();
        }
        private void textBox_NameA_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("Arabic");
        }
        private void textBox_NameE_Enter(object sender, EventArgs e)
        {
            Framework.Keyboard.Language.Switch("English");
        }
        private void expandableSplitter1_Click(object sender, EventArgs e)
        {
            if (expandableSplitter1.Expanded)
            {
                ViewTable_Click(sender, e);
            }
            else
            {
                ViewDetails_Click(sender, e);
            }
        }
        private void Frm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && Button_Add.Enabled && Button_Add.Visible)
            {
                Button_Add_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F2 && Button_Save.Enabled && Button_Save.Visible && State != 0)
            {
                Button_Save_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F3 && Button_Delete.Enabled && Button_Delete.Visible && State == FormState.Saved)
            {
                Button_Delete_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F4 && Button_Search.Enabled && Button_Search.Visible)
            {
                Button_Search_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F5 && Button_PrintTable.Enabled && Button_PrintTable.Visible && !expandableSplitter1.Expanded)
            {
                Button_Print_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F10 && Button_ExportTable2.Enabled && Button_ExportTable2.Visible && !expandableSplitter1.Expanded)
            {
                Button_ExportTable2_Click(sender, e);
            }
            else
            {
                if (e.KeyCode != Keys.Escape)
                {
                    return;
                }
                if (State == FormState.Saved)
                {
                    Close();
                    return;
                }
                if (State != FormState.New)
                {
                    textBox_ID_TextChanged(sender, e);
                    return;
                }
                try
                {
                    if (int.Parse(Label_Count.Text) > 0)
                    {
                        Button_Last_Click(sender, e);
                    }
                    else
                    {
                        Close();
                    }
                }
                catch
                {
                    Close();
                }
            }
        }
        public void RefreshPKeys()
        {
            PKeys.Clear();
            var qkeys = db.T_Jobs.Select((T_Job item) => new
            {
                Code = item.Job_No + ""
            });
            int count = 0;
            foreach (var item2 in qkeys)
            {
                count++;
                PKeys.Add(item2.Code);
            }
            Label_Count.Text = string.Concat(count);
            UpdateVcr();
        }
        public FrmJob()
        {
            InitializeComponent();
            controls = new List<Control>();
            controls.Add(textBox_ID);
            codeControl = textBox_ID;
            controls.Add(textBox_NameA);
            controls.Add(textBox_NameE);
            controls.Add(textBox_Note);
            textBox_ID.KeyPress += textBox_ID_KeyPress;
            Button_Close.Click += Button_Close_Click;
            textBox_NameA.Click += Button_Edit_Click;
            textBox_NameE.Click += Button_Edit_Click;
            textBox_Note.Click += Button_Edit_Click;
            textBox_NameE.Enter += textBox_NameE_Enter;
            textBox_NameA.Enter += textBox_NameA_Enter;
            textBox_NameE.Leave += textBox_NameE_Leave;
            textBox_NameA.Leave += textBox_NameA_Leave;
            textBox_Note.Click += textBox_Note_Click;
            expandableSplitter1.Click += expandableSplitter1_Click;
            ToolStripMenuItem_Det.Click += ToolStripMenuItem_Det_Click;
            Button_ExportTable2.Click += Button_ExportTable2_Click;
            Button_First.Click += Button_First_Click;
            Button_Prev.Click += Button_Prev_Click;
            Button_Next.Click += Button_Next_Click;
            Button_Last.Click += Button_Last_Click;
            Button_Add.Click += Button_Add_Click;
            Button_Search.Click += Button_Search_Click;
            Button_Delete.Click += Button_Delete_Click;
            Button_Save.Click += Button_Save_Click;
            textBox_search.InputTextChanged += TextBox_Search_InputTextChanged;
            textBox_search.ButtonCustomClick += TextBox_Search_ButtonCustomClick;
            textBox_Note.ButtonCustomClick += textBox_Note_ButtonCustomClick;
            TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
            DGV_Main.MouseDown += DGV_Main_MouseDown;
            DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
            DGV_Main.CellClick += DGV_Main_CellClick;
            DGV_Main.GetCellStyle += DGV_MainGetCellStyle;
            DGV_Main.CellDoubleClick += DGV_Main_CellDoubleClick;
            DGV_Main.DataBindingComplete += DGV_Main_DataBindingComplete;
            Button_PrintTable.Click += Button_Print_Click;
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmJob));
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                SSSLanguage.Language.ChangeLanguage("ar-SA", this, resources);
                LangArEn = 0;
            }
            else
            {
                SSSLanguage.Language.ChangeLanguage("en", this, resources);
                LangArEn = 1;
            }
            RibunButtons();
            try
            {
                if (data_this != null)
                {
                    SetData(data_this);
                }
            }
            catch
            {
            }
        }
        private void RibunButtons()
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Button_First.Text = "??????????";
                Button_Last.Text = "????????????";
                Button_Next.Text = "????????????";
                Button_Prev.Text = "????????????";
                Button_Add.Text = "????????";
                Button_Close.Text = "??????????";
                Button_Delete.Text = "??????";
                Button_Save.Text = "??????";
                Button_Search.Text = "??????";
                Button_First.Tooltip = "?????????? ??????????";
                Button_Last.Tooltip = "?????????? ????????????";
                Button_Next.Tooltip = "?????????? ????????????";
                Button_Prev.Tooltip = "?????????? ????????????";
                Button_Add.Tooltip = "F1";
                Button_Close.Tooltip = "Esc";
                Button_Delete.Tooltip = "F3";
                Button_Save.Tooltip = "F2";
                Button_Search.Tooltip = "F4";
                Button_PrintTable.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "??????????" : "??????????");
                Button_PrintTable.Tooltip = "F5";
                Button_ExportTable2.Text = "??????????";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "???????? ??????????????";
                label38.Text = "?????????? :";
                label36.Text = "?????????? - ???????? :";
                label40.Text = "?????????? - ?????????????? :";
                textBox_Note.WatermarkText = "???????????????????????????? ??????????????";
                Text = "?????? ??????????????????????????";
            }
            else
            {
                Button_First.Text = "First";
                Button_Last.Text = "Last";
                Button_Next.Text = "Next";
                Button_Prev.Text = "Previous";
                Button_Add.Text = "New";
                Button_Close.Text = "Close";
                Button_Delete.Text = "Delete";
                Button_Save.Text = "Save";
                Button_Search.Text = "Search";
                Button_First.Tooltip = "First Record";
                Button_Last.Tooltip = "Last Record";
                Button_Next.Tooltip = "Next Record";
                Button_Prev.Tooltip = "Previous Record";
                Button_Add.Tooltip = "F1";
                Button_Close.Tooltip = "Esc";
                Button_Delete.Tooltip = "F3";
                Button_Save.Tooltip = "F2";
                Button_Search.Tooltip = "F4";
                Button_PrintTable.Text = ((VarGeneral.GeneralPrinter.nTyp_Setting.Substring(2, 1) == "0") ? "Print" : "Show");
                Button_PrintTable.Tooltip = "F5";
                Button_ExportTable2.Text = "Export";
                Button_ExportTable2.Tooltip = "F10";
                DGV_Main.PrimaryGrid.GroupByRow.Text = "All Records";
                label38.Text = "Code :";
                label36.Text = "Name - Arabic :";
                label40.Text = "Name - English :";
                textBox_Note.WatermarkText = "Notes";
                Text = "Jobs Card";
            }
        }
        private void FrmJob_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmJob));
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    SSSLanguage.Language.ChangeLanguage("ar-SA", this, resources);
                    LangArEn = 0;
                }
                else
                {
                    SSSLanguage.Language.ChangeLanguage("en", this, resources);
                    LangArEn = 1;
                }
                Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
                if (columns_Names_visible.Count == 0)
                {
                    columns_Names_visible.Add("Job_No", new ColumnDictinary("?????? ??????????????????", "Job No", ifDefault: true, ""));
                    columns_Names_visible.Add("NameA", new ColumnDictinary("?????????? ????????", "Arabic Name", ifDefault: true, ""));
                    columns_Names_visible.Add("NameE", new ColumnDictinary("?????????? ??????????????????", "English Name", ifDefault: true, ""));
                    columns_Names_visible.Add("Note", new ColumnDictinary("??????????????????", "Note", ifDefault: false, ""));
                }
                else
                {
                    Clear();
                    textBox_ID.Text = "";
                    TextBox_Index.TextBox.Text = "";
                }
                RibunButtons();
                RefreshPKeys();
                textBox_ID.Text = PKeys.FirstOrDefault();
                ViewDetails_Click(sender, e);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void textBox_ID_TextChanged(object sender, EventArgs e)
        {
            int no = 0;
            try
            {
                no = int.Parse(textBox_ID.Text);
            }
            catch
            {
            }
            try
            {
                T_Job newData = db.JobEmp(no);
                if (newData == null || newData.Job_No == 0 || string.IsNullOrEmpty(newData.Job_ID))
                {
                    if (!Button_Add.Visible || !Button_Add.Enabled)
                    {
                        MessageBox.Show((LangArEn == 0) ? "???? ???????? ?????????? ?????? ?????????????? .. ???????????? ???????????? ?????????????? ???????????????????? !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textBox_ID.TextChanged -= textBox_ID_TextChanged;
                        try
                        {
                            textBox_ID.Text = data_this.Job_No.ToString();
                        }
                        catch
                        {
                        }
                        textBox_ID.TextChanged += textBox_ID_TextChanged;
                        return;
                    }
                    Clear();
                    TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                    TextBox_Index.TextBox.Text = string.Concat(PKeys.Count + 1);
                    TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                }
                else
                {
                    DataThis = newData;
                    int indexA = PKeys.IndexOf(string.Concat(newData.Job_No));
                    indexA++;
                    TextBox_Index.InputTextChanged -= TextBox_Index_InputTextChanged;
                    TextBox_Index.TextBox.Text = string.Concat(indexA);
                    TextBox_Index.InputTextChanged += TextBox_Index_InputTextChanged;
                }
                try
                {
                    if (data_this.Job_ID == "1")
                    {
                        IfDelete = false;
                    }
                    else
                    {
                        IfDelete = true;
                    }
                }
                catch
                {
                    IfDelete = true;
                }
            }
            catch
            {
            }
            UpdateVcr();
        }
        public void SetData(T_Job value)
        {
            try
            {
                State = FormState.Saved;
                Button_Save.Enabled = false;
                textBox_NameA.Text = value.NameA;
                textBox_NameE.Text = value.NameE;
                textBox_Note.Text = value.Note;
                textBox_ID.Tag = value.Job_ID;
                Permmission = dbc.Get_PermissionID(VarGeneral.UserID);
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("SetData:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void TextBox_Index_InputTextChanged(object sender)
        {
            int index = 0;
            try
            {
                index = Convert.ToInt32(TextBox_Index.TextBox.Text);
            }
            catch
            {
            }
            if (index <= PKeys.Count && index > 0)
            {
                textBox_ID.Text = PKeys[index - 1];
            }
        }
        private T_Job GetData()
        {
            textBox_ID.Focus();
            try
            {
                data_this.Job_No = int.Parse(textBox_ID.Text);
            }
            catch
            {
            }
            try
            {
                data_this.NameA = textBox_NameA.Text;
            }
            catch
            {
            }
            try
            {
                data_this.NameE = textBox_NameE.Text;
            }
            catch
            {
            }
            try
            {
                data_this.Note = textBox_Note.Text;
            }
            catch
            {
            }
            return data_this;
        }
        private void Button_Edit_Click(object sender, EventArgs e)
        {
            if (CanEdit && State != FormState.Edit && State != FormState.New && !string.IsNullOrEmpty(textBox_ID.Text))
            {
                if (State != FormState.New)
                {
                    State = FormState.Edit;
                }
                SetReadOnly = false;
            }
        }
        private void Button_Add_Click(object sender, EventArgs e)
        {
            if (!Button_Add.Visible || !Button_Add.Enabled)
            {
                MessageBox.Show((LangArEn == 0) ? "???? ???????? ?????????? ?????? ?????????????? .. ???????????? ???????????? ?????????????? ???????????????????? !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (State != FormState.Edit || MessageBox.Show((LangArEn == 0) ? "???? ?????????? ?????????? ???????????? ?????? ?????? ?????????????????? .. ???? ???????? ??????????????????" : "Not saved the changes, do you really want to continue?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                int max = 0;
                max = db.MaxJobNo;
                Clear();
                textBox_ID.Text = max.ToString();
                Guid id = Guid.NewGuid();
                textBox_ID.Tag = id.ToString();
                State = FormState.New;
            }
        }
        private void Button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Button_Save.Enabled)
                {
                    return;
                }
                if (State == FormState.Edit && !CanEdit)
                {
                    MessageBox.Show((LangArEn == 0) ? "???? ???????? ?????????? ?????? ?????????????? .. ???????????? ???????????? ?????????????? ???????????????????? !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (State == FormState.New && !Button_Add.Enabled)
                {
                    MessageBox.Show((LangArEn == 0) ? "???? ???????? ?????????? ?????? ?????????????? .. ???????????? ???????????? ?????????????? ???????????????????? !" : "Can not complete this process .. please see the powers of the users!", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                textBox_ID.Focus();
                if (textBox_ID.Text == "" || textBox_NameA.Text == "" || textBox_NameE.Text == "")
                {
                    MessageBox.Show((LangArEn == 0) ? "???????????? ???? ???????? ?????????? ???? ?????????? ??????????\u0651" : "Can not be a number or name is empty", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (State == FormState.New)
                {
                    GetData();
                    try
                    {
                        data_this.Job_ID = textBox_ID.Tag.ToString();
                        db.T_Jobs.InsertOnSubmit(data_this);
                        db.SubmitChanges();
                    }
                    catch (SqlException ex3)
                    {
                        int max = 0;
                        max = db.MaxJobNo;
                        if (ex3.Number != 2627)
                        {
                            return;
                        }
                        MessageBox.Show("?????? ?????????????? ???????????? ???? ??????.\n ???????? ?????????? ???????? ???????? [" + max + "]", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Question);
                        textBox_ID.Text = string.Concat(max);
                        data_this.Job_No = max;
                        Button_Save_Click(sender, e);
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
                else if (State == FormState.Edit)
                {
                    GetData();
                    try
                    {
                        db.Log = VarGeneral.DebugLog;
                        db.SubmitChanges(ConflictMode.ContinueOnConflict);
                    }
                    catch (SqlException)
                    {
                        return;
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
                State = FormState.Saved;
                RefreshPKeys();
                TextBox_Index.TextBox.Text = string.Concat(PKeys.IndexOf(string.Concat(data_this.Job_No)) + 1);
                SetReadOnly = true;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Save:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void Button_Delete_Click(object sender, EventArgs e)
        {
            if (!Button_Delete.Enabled || !Button_Delete.Visible || State != 0)
            {
                ifOkDelete = false;
                return;
            }
            string Code = "";
            Code = textBox_ID.Text;
            if (Code == "")
            {
                ifOkDelete = false;
                return;
            }
            try
            {
                if (data_this.Job_ID == "1")
                {
                    ifOkDelete = false;
                    return;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                return;
            }
            if (MessageBox.Show("???? ?????? ?????????? ???? ?????? ?????????? [" + Code + "]?? \n Are you sure that you want to delete the record [" + Code + "]?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ifOkDelete = true;
            }
            else
            {
                ifOkDelete = false;
            }
            if (data_this == null || data_this.Job_No == 0 || string.IsNullOrEmpty(data_this.Job_ID) || !ifOkDelete)
            {
                return;
            }
            T_Emp returned = db.SelectJobNoByReturnNo(DataThis.Job_No);
            int num;
            if (returned != null)
            {
                int? job = returned.Job;
                num = ((job.Value == 0 && job.HasValue) ? 1 : 0);
            }
            else
            {
                num = 1;
            }
            if (num == 0)
            {
                MessageBox.Show((LangArEn == 0) ? "???????????? ?????? ?????????????? .. ???????? ?????????? ???????? ????????????????" : "can not be deleted This Job .. because it is linked to one of the employee", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            data_this = db.JobEmp(DataThis.Job_No);
            try
            {
                db.T_Jobs.DeleteOnSubmit(DataThis);
                db.SubmitChanges();
            }
            catch (SqlException)
            {
                data_this = db.JobEmp(DataThis.Job_No);
                return;
            }
            catch (Exception)
            {
                data_this = db.JobEmp(DataThis.Job_No);
                return;
            }
            Clear();
            RefreshPKeys();
            textBox_ID.Text = PKeys.LastOrDefault();
        }
        private void DGV_Main_DataBindingComplete(object sender, GridDataBindingCompleteEventArgs e)
        {
            GridPanel panel = e.GridPanel;
            string dataMember = panel.DataMember;
            if (dataMember != null && dataMember == "T_Job")
            {
                PropBranchPanel(panel);
            }
        }
        private void PropBranchPanel(GridPanel panel)
        {
            DGV_Main.PrimaryGrid.UseAlternateRowStyle = true;
            DGV_Main.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background.Color1 = Color.SkyBlue;
            panel.FrozenColumnCount = 1;
            panel.Columns[0].GroupBoxEffects = GroupBoxEffects.None;
            foreach (GridColumn column in panel.Columns)
            {
                column.ColumnSortMode = ColumnSortMode.Multiple;
            }
            panel.ColumnHeader.RowHeight = 30;
            for (int i = 0; i < panel.Columns.Count; i++)
            {
                DGV_Main.PrimaryGrid.Columns[i].CellStyles.Default.Alignment = Alignment.MiddleCenter;
                DGV_Main.PrimaryGrid.Columns[i].Visible = false;
            }
            panel.Columns["NameA"].Width = 250;
            panel.Columns["NameA"].Visible = columns_Names_visible["NameA"].IfDefault;
            panel.Columns["NameE"].Width = 250;
            panel.Columns["NameE"].Visible = columns_Names_visible["NameE"].IfDefault;
            panel.Columns["Job_No"].Width = 120;
            panel.Columns["Job_No"].Visible = columns_Names_visible["Job_No"].IfDefault;
            panel.Columns["Note"].Width = 350;
            panel.Columns["Note"].Visible = columns_Names_visible["Note"].IfDefault;
            panel.ReadOnly = true;
        }
        private void DGV_MainGetCellStyle(object sender, GridGetCellStyleEventArgs e)
        {
        }
        private void Button_ExportTable2_Click(object sender, EventArgs e)
        {
            try
            {
                ExportExcel.ExportToExcel(DGV_Main, "?????????? ????????????????????????");
            }
            catch
            {
            }
        }
        private void textBox_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        public void Button_Print_Click(object sender, EventArgs e)
        {
            if (ViewState != 0)
            {
                return;
            }
            try
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = " T_Job ";
                string Fields = "";
                Fields = " T_Job.Job_No as No, T_Job.NameA as NmA, T_Job.NameE as NmE,(select T_SYSSETTING.LogImg from T_SYSSETTING) as LogImg ";
                _RepShow.Rule = "";
                if (!string.IsNullOrEmpty(Fields))
                {
                    _RepShow.Fields = Fields;
                    try
                    {
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show(ex2.Message);
                    }
                }
                if (VarGeneral.RepData.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show((LangArEn == 0) ? "???????? .. ???? ???????? ???????????? ???????????? ???? ?????????????? " : "Sorry .. there is no data to display in the report ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                try
                {
                    VarGeneral.IsGeneralUsed = true;
                    FrmReportsViewer frm = new FrmReportsViewer();
                    frm.Repvalue = "RepGeneral";



                    frm.Tag = LangArEn;
                    frm.Repvalue = "RepGeneral";
                    VarGeneral.vTitle = Text;
                    frm.TopMost = true;
                    frm.ShowDialog();
                    VarGeneral.IsGeneralUsed = false;

                }
                catch (Exception error)
                {
                    VarGeneral.DebLog.writeLog("button_ShowRep_Click:", error, enable: true);
                    MessageBox.Show(error.Message);
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }
        public void textBox_NameA_Leave(object sender, EventArgs e)
        {
            SSSLanguage.Language.Switch("AR");
        }
        public void textBox_NameE_Leave(object sender, EventArgs e)
        {
            SSSLanguage.Language.Switch("AR");
        }
        private void textBox_Note_Click(object sender, EventArgs e)
        {
            textBox_Note.SelectAll();
        }
    }
}
