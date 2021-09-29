using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using InvAcc.GeneralM;
using InvAcc.Properties;
using InvAcc.Stock_Data;
using Library.RepShow;
using SSSDateTime.Date;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmTables : Form
    {
        private IContainer components = null;
        protected ContextMenuStrip contextMenuStrip2;
        protected ToolStripMenuItem ToolStripMenuItem_Det;
        protected ToolStripMenuItem ToolStripMenuItem_Rep;
        protected ContextMenuStrip contextMenuStrip1;
        private SuperTabControl superTabControl_Tables;
        private SuperTabControlPanel superTabControlPanel1;
        private MetroTilePanel metroTilePanel_Family;
        private ItemContainer itemContainer_Family;
        private SuperTabItem superTabItem_Family;
        private SuperTabControlPanel superTabControlPanel4;
        private SuperTabItem superTabItem_Other;
        private SuperTabControlPanel superTabControlPanel3;
        private SuperTabItem superTabItem_Extnal;
        private SuperTabControlPanel superTabControlPanel2;
        private SuperTabItem superTabItem_Boys;
        private MetroTilePanel metroTilePanel_Other;
        private ItemContainer itemContainer_Other;
        private MetroTilePanel metroTilePanel_Extnal;
        private ItemContainer itemContainer_Extrnal;
        private MetroTilePanel metroTilePanel_Boys;
        private ItemContainer itemContainer_Boys;
        private ExpandablePanel expandablePanel_Table;
        private ItemPanel itemPanel2;
        private LabelItem labelItem_ReseTables;
        private LabelItem labelItem_EmptyTable;
        private ItemPanel itemPanel1;
        private LabelItem labelItem_Tables;
        private LabelItem labelItem_Note;
        private LabelItem labelItem_BussyTable;
        private LabelItem labelItem_Time;
        private LabelItem labelItem_Nadel;
        private LabelItem labelItem_StopTable;
        private Panel panel_TableColor;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private MetroTilePanel metroTilePanel1;
        private MetroTileItem metroTileItem1;
        private MetroTileItem metroTileItem2;
        private MetroTileItem metroTileItem3;
        private MetroTileItem metroTileItem5;
        private Panel panel_ButSave;
        private ButtonX ButOk;
        private LabelItem labelItem_Type;
        private LabelItem labelItem_SumTable;
        private ToolStripMenuItem ToolStripMenuItem_Op;
        public int Serach_No = 0;
        public string sts_ = "";
        private string vNo = "";
        private int vTyp = 0;
        private bool frmSts_ = false;
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        private int LangArEn = 0;
        private Stock_DataDataContext dbInstance;
        private MetroTileItem vItemSelect = new MetroTileItem();
        private T_INVSETTING _InvSetting = new T_INVSETTING();
        public int SerachNo
        {
            get
            {
                return Serach_No;
            }
            set
            {
                Serach_No = value;
            }
        }
        public string RomeStatus
        {
            get
            {
                return sts_;
            }
            set
            {
                sts_ = value;
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
        public bool VisibleSts
        {
            set
            {
                if (!frmSts_)
                {
                    panel_ButSave.Visible = !value;
                }
                else
                {
                    panel_ButSave.Visible = false;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmTables));
            contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(components);
            ToolStripMenuItem_Det = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItem_Rep = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItem_Op = new System.Windows.Forms.ToolStripMenuItem();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            superTabControl_Tables = new DevComponents.DotNetBar.SuperTabControl();
            superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            metroTilePanel_Family = new DevComponents.DotNetBar.Metro.MetroTilePanel();
            itemContainer_Family = new DevComponents.DotNetBar.ItemContainer();
            superTabItem_Family = new DevComponents.DotNetBar.SuperTabItem();
            superTabControlPanel4 = new DevComponents.DotNetBar.SuperTabControlPanel();
            metroTilePanel_Other = new DevComponents.DotNetBar.Metro.MetroTilePanel();
            itemContainer_Other = new DevComponents.DotNetBar.ItemContainer();
            superTabItem_Other = new DevComponents.DotNetBar.SuperTabItem();
            superTabControlPanel3 = new DevComponents.DotNetBar.SuperTabControlPanel();
            metroTilePanel_Extnal = new DevComponents.DotNetBar.Metro.MetroTilePanel();
            itemContainer_Extrnal = new DevComponents.DotNetBar.ItemContainer();
            superTabItem_Extnal = new DevComponents.DotNetBar.SuperTabItem();
            superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            metroTilePanel_Boys = new DevComponents.DotNetBar.Metro.MetroTilePanel();
            itemContainer_Boys = new DevComponents.DotNetBar.ItemContainer();
            superTabItem_Boys = new DevComponents.DotNetBar.SuperTabItem();
            expandablePanel_Table = new DevComponents.DotNetBar.ExpandablePanel();
            itemPanel1 = new DevComponents.DotNetBar.ItemPanel();
            labelItem_Tables = new DevComponents.DotNetBar.LabelItem();
            labelItem_Note = new DevComponents.DotNetBar.LabelItem();
            labelItem_Time = new DevComponents.DotNetBar.LabelItem();
            labelItem_Nadel = new DevComponents.DotNetBar.LabelItem();
            labelItem_Type = new DevComponents.DotNetBar.LabelItem();
            itemPanel2 = new DevComponents.DotNetBar.ItemPanel();
            labelItem_EmptyTable = new DevComponents.DotNetBar.LabelItem();
            labelItem_BussyTable = new DevComponents.DotNetBar.LabelItem();
            labelItem_StopTable = new DevComponents.DotNetBar.LabelItem();
            labelItem_ReseTables = new DevComponents.DotNetBar.LabelItem();
            labelItem_SumTable = new DevComponents.DotNetBar.LabelItem();
            panel_ButSave = new System.Windows.Forms.Panel();
            ButOk = new DevComponents.DotNetBar.ButtonX();
            panel_TableColor = new System.Windows.Forms.Panel();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            metroTilePanel1 = new DevComponents.DotNetBar.Metro.MetroTilePanel();
            metroTileItem1 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            metroTileItem2 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            metroTileItem3 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            metroTileItem5 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)superTabControl_Tables).BeginInit();
            superTabControl_Tables.SuspendLayout();
            superTabControlPanel1.SuspendLayout();
            superTabControlPanel4.SuspendLayout();
            superTabControlPanel3.SuspendLayout();
            superTabControlPanel2.SuspendLayout();
            expandablePanel_Table.SuspendLayout();
            panel_ButSave.SuspendLayout();
            panel_TableColor.SuspendLayout();
            SuspendLayout();
            contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[3]
            {
                ToolStripMenuItem_Det,
                ToolStripMenuItem_Rep,
                ToolStripMenuItem_Op
            });
            contextMenuStrip2.Name = "contextMenuStrip2";
            resources.ApplyResources(contextMenuStrip2, "contextMenuStrip2");
            ToolStripMenuItem_Det.Name = "ToolStripMenuItem_Det";
            resources.ApplyResources(ToolStripMenuItem_Det, "ToolStripMenuItem_Det");
            resources.ApplyResources(ToolStripMenuItem_Rep, "ToolStripMenuItem_Rep");
            ToolStripMenuItem_Rep.Checked = true;
            ToolStripMenuItem_Rep.CheckState = System.Windows.Forms.CheckState.Checked;
            ToolStripMenuItem_Rep.Name = "ToolStripMenuItem_Rep";
            ToolStripMenuItem_Rep.Click += new System.EventHandler(ToolStripMenuItem_Rep_Click);
            resources.ApplyResources(ToolStripMenuItem_Op, "ToolStripMenuItem_Op");
            ToolStripMenuItem_Op.Checked = true;
            ToolStripMenuItem_Op.CheckState = System.Windows.Forms.CheckState.Checked;
            ToolStripMenuItem_Op.ForeColor = System.Drawing.Color.FromArgb(64, 0, 0);
            ToolStripMenuItem_Op.Name = "ToolStripMenuItem_Op";
            ToolStripMenuItem_Op.Click += new System.EventHandler(ToolStripMenuItem_Op_Click);
            contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(contextMenuStrip1, "contextMenuStrip1");
            superTabControl_Tables.ControlBox.Category = null;
            superTabControl_Tables.ControlBox.CloseBox.Category = null;
            superTabControl_Tables.ControlBox.CloseBox.Description = null;
            superTabControl_Tables.ControlBox.CloseBox.Name = "";
            superTabControl_Tables.ControlBox.CloseBox.Tag = null;
            superTabControl_Tables.ControlBox.Description = null;
            superTabControl_Tables.ControlBox.MenuBox.Category = null;
            superTabControl_Tables.ControlBox.MenuBox.Description = null;
            superTabControl_Tables.ControlBox.MenuBox.Name = "";
            superTabControl_Tables.ControlBox.MenuBox.Tag = null;
            superTabControl_Tables.ControlBox.Name = "";
            superTabControl_Tables.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[2]
            {
                superTabControl_Tables.ControlBox.MenuBox,
                superTabControl_Tables.ControlBox.CloseBox
            });
            superTabControl_Tables.ControlBox.Tag = null;
            superTabControl_Tables.ControlBox.Visible = false;
            superTabControl_Tables.Controls.Add(superTabControlPanel1);
            superTabControl_Tables.Controls.Add(superTabControlPanel2);
            superTabControl_Tables.Controls.Add(superTabControlPanel4);
            superTabControl_Tables.Controls.Add(superTabControlPanel3);
            resources.ApplyResources(superTabControl_Tables, "superTabControl_Tables");
            superTabControl_Tables.Name = "superTabControl_Tables";
            superTabControl_Tables.ReorderTabsEnabled = true;
            superTabControl_Tables.SelectedTabIndex = 0;
            superTabControl_Tables.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[4]
            {
                superTabItem_Family,
                superTabItem_Boys,
                superTabItem_Extnal,
                superTabItem_Other
            });
            superTabControl_Tables.TabVerticalSpacing = 22;
            superTabControlPanel1.Controls.Add(metroTilePanel_Family);
            resources.ApplyResources(superTabControlPanel1, "superTabControlPanel1");
            superTabControlPanel1.Name = "superTabControlPanel1";
            superTabControlPanel1.TabItem = superTabItem_Family;
            metroTilePanel_Family.BackColor = System.Drawing.Color.Transparent;
            metroTilePanel_Family.BackgroundStyle.Class = "RibbonFileMenuTwoColumnContainer";
            metroTilePanel_Family.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            metroTilePanel_Family.ContainerControlProcessDialogKey = true;
            resources.ApplyResources(metroTilePanel_Family, "metroTilePanel_Family");
            metroTilePanel_Family.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Right;
            metroTilePanel_Family.ImageSize = DevComponents.DotNetBar.eBarImageSize.Medium;
            metroTilePanel_Family.Items.AddRange(new DevComponents.DotNetBar.BaseItem[1]
            {
                itemContainer_Family
            });
            metroTilePanel_Family.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            metroTilePanel_Family.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            metroTilePanel_Family.MultiLine = true;
            metroTilePanel_Family.Name = "metroTilePanel_Family";
            metroTilePanel_Family.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            metroTilePanel_Family.MouseDown += new System.Windows.Forms.MouseEventHandler(metroTilePanel_Family_MouseDown);
            metroTilePanel_Family.ItemClick += new System.EventHandler(metroTilePanel_Family_ItemClick);
            itemContainer_Family.AccessibleRole = System.Windows.Forms.AccessibleRole.ListItem;
            itemContainer_Family.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            itemContainer_Family.MultiLine = true;
            itemContainer_Family.Name = "itemContainer_Family";
            itemContainer_Family.TitleStyle.BackColor = System.Drawing.Color.AliceBlue;
            itemContainer_Family.TitleStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemContainer_Family.TitleStyle.BorderBottomWidth = 1;
            itemContainer_Family.TitleStyle.BorderColor = System.Drawing.Color.FromArgb(255, 255, 255);
            itemContainer_Family.TitleStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemContainer_Family.TitleStyle.BorderLeftWidth = 1;
            itemContainer_Family.TitleStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemContainer_Family.TitleStyle.BorderRightWidth = 1;
            itemContainer_Family.TitleStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemContainer_Family.TitleStyle.BorderTopWidth = 1;
            itemContainer_Family.TitleStyle.Class = "MetroTileGroupTitle";
            itemContainer_Family.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            itemContainer_Family.TitleStyle.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
            itemContainer_Family.TitleStyle.MarginBottom = 5;
            itemContainer_Family.TitleStyle.MarginLeft = 5;
            itemContainer_Family.TitleStyle.MarginRight = 5;
            itemContainer_Family.TitleStyle.MarginTop = 5;
            itemContainer_Family.TitleStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            itemContainer_Family.TitleStyle.TextColor = System.Drawing.Color.FromArgb(0, 0, 0);
            itemContainer_Family.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            superTabItem_Family.AttachedControl = superTabControlPanel1;
            superTabItem_Family.GlobalItem = false;
            superTabItem_Family.Name = "superTabItem_Family";
            resources.ApplyResources(superTabItem_Family, "superTabItem_Family");
            superTabControlPanel4.Controls.Add(metroTilePanel_Other);
            resources.ApplyResources(superTabControlPanel4, "superTabControlPanel4");
            superTabControlPanel4.Name = "superTabControlPanel4";
            superTabControlPanel4.TabItem = superTabItem_Other;
            metroTilePanel_Other.BackColor = System.Drawing.Color.Transparent;
            metroTilePanel_Other.BackgroundStyle.Class = "RibbonFileMenuTwoColumnContainer";
            metroTilePanel_Other.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            metroTilePanel_Other.ContainerControlProcessDialogKey = true;
            resources.ApplyResources(metroTilePanel_Other, "metroTilePanel_Other");
            metroTilePanel_Other.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Right;
            metroTilePanel_Other.Items.AddRange(new DevComponents.DotNetBar.BaseItem[1]
            {
                itemContainer_Other
            });
            metroTilePanel_Other.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            metroTilePanel_Other.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            metroTilePanel_Other.MultiLine = true;
            metroTilePanel_Other.Name = "metroTilePanel_Other";
            metroTilePanel_Other.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            metroTilePanel_Other.MouseDown += new System.Windows.Forms.MouseEventHandler(metroTilePanel_Family_MouseDown);
            metroTilePanel_Other.ItemClick += new System.EventHandler(metroTilePanel_Family_ItemClick);
            itemContainer_Other.AccessibleRole = System.Windows.Forms.AccessibleRole.ListItem;
            itemContainer_Other.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            itemContainer_Other.MultiLine = true;
            itemContainer_Other.Name = "itemContainer_Other";
            itemContainer_Other.TitleStyle.BackColor = System.Drawing.Color.AliceBlue;
            itemContainer_Other.TitleStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemContainer_Other.TitleStyle.BorderBottomWidth = 1;
            itemContainer_Other.TitleStyle.BorderColor = System.Drawing.Color.FromArgb(255, 255, 255);
            itemContainer_Other.TitleStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemContainer_Other.TitleStyle.BorderLeftWidth = 1;
            itemContainer_Other.TitleStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemContainer_Other.TitleStyle.BorderRightWidth = 1;
            itemContainer_Other.TitleStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemContainer_Other.TitleStyle.BorderTopWidth = 1;
            itemContainer_Other.TitleStyle.Class = "MetroTileGroupTitle";
            itemContainer_Other.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            itemContainer_Other.TitleStyle.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
            itemContainer_Other.TitleStyle.MarginBottom = 5;
            itemContainer_Other.TitleStyle.MarginLeft = 5;
            itemContainer_Other.TitleStyle.MarginRight = 5;
            itemContainer_Other.TitleStyle.MarginTop = 5;
            itemContainer_Other.TitleStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            itemContainer_Other.TitleStyle.TextColor = System.Drawing.Color.FromArgb(0, 0, 0);
            itemContainer_Other.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            superTabItem_Other.AttachedControl = superTabControlPanel4;
            superTabItem_Other.GlobalItem = false;
            superTabItem_Other.Name = "superTabItem_Other";
            resources.ApplyResources(superTabItem_Other, "superTabItem_Other");
            superTabControlPanel3.Controls.Add(metroTilePanel_Extnal);
            resources.ApplyResources(superTabControlPanel3, "superTabControlPanel3");
            superTabControlPanel3.Name = "superTabControlPanel3";
            superTabControlPanel3.TabItem = superTabItem_Extnal;
            metroTilePanel_Extnal.BackColor = System.Drawing.Color.Transparent;
            metroTilePanel_Extnal.BackgroundStyle.Class = "RibbonFileMenuTwoColumnContainer";
            metroTilePanel_Extnal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            metroTilePanel_Extnal.ContainerControlProcessDialogKey = true;
            resources.ApplyResources(metroTilePanel_Extnal, "metroTilePanel_Extnal");
            metroTilePanel_Extnal.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Right;
            metroTilePanel_Extnal.Items.AddRange(new DevComponents.DotNetBar.BaseItem[1]
            {
                itemContainer_Extrnal
            });
            metroTilePanel_Extnal.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            metroTilePanel_Extnal.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            metroTilePanel_Extnal.MultiLine = true;
            metroTilePanel_Extnal.Name = "metroTilePanel_Extnal";
            metroTilePanel_Extnal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            metroTilePanel_Extnal.MouseDown += new System.Windows.Forms.MouseEventHandler(metroTilePanel_Family_MouseDown);
            metroTilePanel_Extnal.ItemClick += new System.EventHandler(metroTilePanel_Family_ItemClick);
            itemContainer_Extrnal.AccessibleRole = System.Windows.Forms.AccessibleRole.ListItem;
            itemContainer_Extrnal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            itemContainer_Extrnal.MultiLine = true;
            itemContainer_Extrnal.Name = "itemContainer_Extrnal";
            itemContainer_Extrnal.TitleStyle.BackColor = System.Drawing.Color.AliceBlue;
            itemContainer_Extrnal.TitleStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemContainer_Extrnal.TitleStyle.BorderBottomWidth = 1;
            itemContainer_Extrnal.TitleStyle.BorderColor = System.Drawing.Color.FromArgb(255, 255, 255);
            itemContainer_Extrnal.TitleStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemContainer_Extrnal.TitleStyle.BorderLeftWidth = 1;
            itemContainer_Extrnal.TitleStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemContainer_Extrnal.TitleStyle.BorderRightWidth = 1;
            itemContainer_Extrnal.TitleStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemContainer_Extrnal.TitleStyle.BorderTopWidth = 1;
            itemContainer_Extrnal.TitleStyle.Class = "MetroTileGroupTitle";
            itemContainer_Extrnal.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            itemContainer_Extrnal.TitleStyle.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
            itemContainer_Extrnal.TitleStyle.MarginBottom = 5;
            itemContainer_Extrnal.TitleStyle.MarginLeft = 5;
            itemContainer_Extrnal.TitleStyle.MarginRight = 5;
            itemContainer_Extrnal.TitleStyle.MarginTop = 5;
            itemContainer_Extrnal.TitleStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            itemContainer_Extrnal.TitleStyle.TextColor = System.Drawing.Color.FromArgb(0, 0, 0);
            itemContainer_Extrnal.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            superTabItem_Extnal.AttachedControl = superTabControlPanel3;
            superTabItem_Extnal.GlobalItem = false;
            superTabItem_Extnal.Name = "superTabItem_Extnal";
            resources.ApplyResources(superTabItem_Extnal, "superTabItem_Extnal");
            superTabControlPanel2.Controls.Add(metroTilePanel_Boys);
            resources.ApplyResources(superTabControlPanel2, "superTabControlPanel2");
            superTabControlPanel2.Name = "superTabControlPanel2";
            superTabControlPanel2.TabItem = superTabItem_Boys;
            metroTilePanel_Boys.BackColor = System.Drawing.Color.Transparent;
            metroTilePanel_Boys.BackgroundStyle.Class = "RibbonFileMenuTwoColumnContainer";
            metroTilePanel_Boys.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            metroTilePanel_Boys.ContainerControlProcessDialogKey = true;
            resources.ApplyResources(metroTilePanel_Boys, "metroTilePanel_Boys");
            metroTilePanel_Boys.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Right;
            metroTilePanel_Boys.Items.AddRange(new DevComponents.DotNetBar.BaseItem[1]
            {
                itemContainer_Boys
            });
            metroTilePanel_Boys.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            metroTilePanel_Boys.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            metroTilePanel_Boys.MultiLine = true;
            metroTilePanel_Boys.Name = "metroTilePanel_Boys";
            metroTilePanel_Boys.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            metroTilePanel_Boys.MouseDown += new System.Windows.Forms.MouseEventHandler(metroTilePanel_Family_MouseDown);
            metroTilePanel_Boys.ItemClick += new System.EventHandler(metroTilePanel_Family_ItemClick);
            itemContainer_Boys.AccessibleRole = System.Windows.Forms.AccessibleRole.ListItem;
            itemContainer_Boys.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            itemContainer_Boys.MultiLine = true;
            itemContainer_Boys.Name = "itemContainer_Boys";
            itemContainer_Boys.TitleStyle.BackColor = System.Drawing.Color.AliceBlue;
            itemContainer_Boys.TitleStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemContainer_Boys.TitleStyle.BorderBottomWidth = 1;
            itemContainer_Boys.TitleStyle.BorderColor = System.Drawing.Color.FromArgb(255, 255, 255);
            itemContainer_Boys.TitleStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemContainer_Boys.TitleStyle.BorderLeftWidth = 1;
            itemContainer_Boys.TitleStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemContainer_Boys.TitleStyle.BorderRightWidth = 1;
            itemContainer_Boys.TitleStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            itemContainer_Boys.TitleStyle.BorderTopWidth = 1;
            itemContainer_Boys.TitleStyle.Class = "MetroTileGroupTitle";
            itemContainer_Boys.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            itemContainer_Boys.TitleStyle.Font = new System.Drawing.Font("Tahoma", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, 0);
            itemContainer_Boys.TitleStyle.MarginBottom = 5;
            itemContainer_Boys.TitleStyle.MarginLeft = 5;
            itemContainer_Boys.TitleStyle.MarginRight = 5;
            itemContainer_Boys.TitleStyle.MarginTop = 5;
            itemContainer_Boys.TitleStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            itemContainer_Boys.TitleStyle.TextColor = System.Drawing.Color.FromArgb(0, 0, 0);
            itemContainer_Boys.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            superTabItem_Boys.AttachedControl = superTabControlPanel2;
            superTabItem_Boys.GlobalItem = false;
            superTabItem_Boys.Name = "superTabItem_Boys";
            resources.ApplyResources(superTabItem_Boys, "superTabItem_Boys");
            expandablePanel_Table.CanvasColor = System.Drawing.SystemColors.Control;
            expandablePanel_Table.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            expandablePanel_Table.Controls.Add(itemPanel1);
            expandablePanel_Table.Controls.Add(itemPanel2);
            expandablePanel_Table.Controls.Add(panel_ButSave);
            expandablePanel_Table.Controls.Add(panel_TableColor);
            expandablePanel_Table.Controls.Add(metroTilePanel1);
            resources.ApplyResources(expandablePanel_Table, "expandablePanel_Table");
            expandablePanel_Table.ExpandButtonVisible = false;
            expandablePanel_Table.Name = "expandablePanel_Table";
            expandablePanel_Table.Style.Alignment = System.Drawing.StringAlignment.Center;
            expandablePanel_Table.Style.BackColor1.Color = System.Drawing.Color.AliceBlue;
            expandablePanel_Table.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            expandablePanel_Table.Style.BorderColor.Color = System.Drawing.Color.White;
            expandablePanel_Table.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            expandablePanel_Table.Style.GradientAngle = 90;
            expandablePanel_Table.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            expandablePanel_Table.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            expandablePanel_Table.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            expandablePanel_Table.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            expandablePanel_Table.TitleStyle.ForeColor.Color = System.Drawing.Color.FromArgb(64, 64, 64);
            expandablePanel_Table.TitleStyle.GradientAngle = 90;
            itemPanel1.BackgroundStyle.Class = "ItemPanel";
            itemPanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            itemPanel1.ContainerControlProcessDialogKey = true;
            resources.ApplyResources(itemPanel1, "itemPanel1");
            itemPanel1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[5]
            {
                labelItem_Tables,
                labelItem_Note,
                labelItem_Time,
                labelItem_Nadel,
                labelItem_Type
            });
            itemPanel1.ItemSpacing = 4;
            itemPanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            itemPanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            itemPanel1.Name = "itemPanel1";
            itemPanel1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            labelItem_Tables.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
            labelItem_Tables.Name = "labelItem_Tables";
            resources.ApplyResources(labelItem_Tables, "labelItem_Tables");
            labelItem_Note.ForeColor = System.Drawing.Color.Black;
            labelItem_Note.Name = "labelItem_Note";
            resources.ApplyResources(labelItem_Note, "labelItem_Note");
            labelItem_Time.ForeColor = System.Drawing.Color.Gray;
            labelItem_Time.Name = "labelItem_Time";
            resources.ApplyResources(labelItem_Time, "labelItem_Time");
            labelItem_Nadel.ForeColor = System.Drawing.Color.Maroon;
            labelItem_Nadel.Name = "labelItem_Nadel";
            resources.ApplyResources(labelItem_Nadel, "labelItem_Nadel");
            labelItem_Type.BackColor = System.Drawing.Color.Yellow;
            labelItem_Type.Name = "labelItem_Type";
            resources.ApplyResources(labelItem_Type, "labelItem_Type");
            labelItem_Type.TextAlignment = System.Drawing.StringAlignment.Center;
            itemPanel2.BackgroundStyle.Class = "ItemPanel";
            itemPanel2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            itemPanel2.ContainerControlProcessDialogKey = true;
            resources.ApplyResources(itemPanel2, "itemPanel2");
            itemPanel2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[5]
            {
                labelItem_EmptyTable,
                labelItem_BussyTable,
                labelItem_StopTable,
                labelItem_ReseTables,
                labelItem_SumTable
            });
            itemPanel2.ItemSpacing = 4;
            itemPanel2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            itemPanel2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            itemPanel2.Name = "itemPanel2";
            itemPanel2.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            labelItem_EmptyTable.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
            labelItem_EmptyTable.Name = "labelItem_EmptyTable";
            resources.ApplyResources(labelItem_EmptyTable, "labelItem_EmptyTable");
            labelItem_EmptyTable.TextAlignment = System.Drawing.StringAlignment.Far;
            labelItem_BussyTable.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            labelItem_BussyTable.Name = "labelItem_BussyTable";
            resources.ApplyResources(labelItem_BussyTable, "labelItem_BussyTable");
            labelItem_BussyTable.TextAlignment = System.Drawing.StringAlignment.Far;
            labelItem_StopTable.ForeColor = System.Drawing.Color.Gray;
            labelItem_StopTable.Name = "labelItem_StopTable";
            resources.ApplyResources(labelItem_StopTable, "labelItem_StopTable");
            labelItem_StopTable.TextAlignment = System.Drawing.StringAlignment.Far;
            labelItem_ReseTables.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            labelItem_ReseTables.Name = "labelItem_ReseTables";
            resources.ApplyResources(labelItem_ReseTables, "labelItem_ReseTables");
            labelItem_ReseTables.TextAlignment = System.Drawing.StringAlignment.Far;
            labelItem_SumTable.BackColor = System.Drawing.Color.Red;
            labelItem_SumTable.ForeColor = System.Drawing.Color.White;
            labelItem_SumTable.Name = "labelItem_SumTable";
            resources.ApplyResources(labelItem_SumTable, "labelItem_SumTable");
            labelItem_SumTable.TextAlignment = System.Drawing.StringAlignment.Center;
            panel_ButSave.BackColor = System.Drawing.Color.Transparent;
            panel_ButSave.Controls.Add(ButOk);
            resources.ApplyResources(panel_ButSave, "panel_ButSave");
            panel_ButSave.Name = "panel_ButSave";
            ButOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            ButOk.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            resources.ApplyResources(ButOk, "ButOk");
            ButOk.Name = "ButOk";
            ButOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButOk.Symbol = "\uf00c";
            ButOk.SymbolSize = 16f;
            ButOk.TextColor = System.Drawing.Color.White;
            ButOk.Click += new System.EventHandler(ButOk_Click);
            panel_TableColor.BackColor = System.Drawing.Color.Transparent;
            panel_TableColor.Controls.Add(label4);
            panel_TableColor.Controls.Add(label3);
            panel_TableColor.Controls.Add(label2);
            panel_TableColor.Controls.Add(label1);
            resources.ApplyResources(panel_TableColor, "panel_TableColor");
            panel_TableColor.Name = "panel_TableColor";
            resources.ApplyResources(label4, "label4");
            label4.ForeColor = System.Drawing.Color.Goldenrod;
            label4.Name = "label4";
            resources.ApplyResources(label3, "label3");
            label3.ForeColor = System.Drawing.Color.Gray;
            label3.Name = "label3";
            resources.ApplyResources(label2, "label2");
            label2.ForeColor = System.Drawing.Color.Peru;
            label2.Name = "label2";
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = System.Drawing.Color.SteelBlue;
            label1.Name = "label1";
            metroTilePanel1.BackColor = System.Drawing.Color.Transparent;
            metroTilePanel1.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
            metroTilePanel1.BackgroundStyle.Class = "MetroTilePanel";
            metroTilePanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            metroTilePanel1.ContainerControlProcessDialogKey = true;
            resources.ApplyResources(metroTilePanel1, "metroTilePanel1");
            metroTilePanel1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[4]
            {
                metroTileItem1,
                metroTileItem2,
                metroTileItem3,
                metroTileItem5
            });
            metroTilePanel1.ItemSpacing = 3;
            metroTilePanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            metroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            metroTilePanel1.Name = "metroTilePanel1";
            metroTileItem1.ImageTextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            metroTileItem1.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            metroTileItem1.Name = "metroTileItem1";
            metroTileItem1.SymbolColor = System.Drawing.Color.Empty;
            metroTileItem1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Azure;
            metroTileItem1.TileSize = new System.Drawing.Size(13, 11);
            metroTileItem1.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            metroTileItem1.TitleTextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            metroTileItem2.ImageTextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            metroTileItem2.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            metroTileItem2.Name = "metroTileItem2";
            metroTileItem2.SymbolColor = System.Drawing.Color.Empty;
            metroTileItem2.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Orange;
            metroTileItem2.TileSize = new System.Drawing.Size(13, 11);
            metroTileItem2.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            metroTileItem2.TitleTextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            metroTileItem3.ImageTextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            metroTileItem3.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            metroTileItem3.Name = "metroTileItem3";
            metroTileItem3.SymbolColor = System.Drawing.Color.Empty;
            metroTileItem3.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Gray;
            metroTileItem3.TileSize = new System.Drawing.Size(13, 11);
            metroTileItem3.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            metroTileItem3.TitleTextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            metroTileItem5.ImageTextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            metroTileItem5.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            metroTileItem5.Name = "metroTileItem5";
            metroTileItem5.SymbolColor = System.Drawing.Color.Empty;
            metroTileItem5.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellow;
            metroTileItem5.TileSize = new System.Drawing.Size(13, 11);
            metroTileItem5.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            metroTileItem5.TitleTextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.AliceBlue;
            base.Controls.Add(superTabControl_Tables);
            base.Controls.Add(expandablePanel_Table);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.Name = "FrmTables";
            base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            base.Load += new System.EventHandler(FrmTables_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(FrmTables_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmTables_KeyDown);
            contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)superTabControl_Tables).EndInit();
            superTabControl_Tables.ResumeLayout(false);
            superTabControlPanel1.ResumeLayout(false);
            superTabControlPanel4.ResumeLayout(false);
            superTabControlPanel3.ResumeLayout(false);
            superTabControlPanel2.ResumeLayout(false);
            expandablePanel_Table.ResumeLayout(false);
            panel_ButSave.ResumeLayout(false);
            panel_TableColor.ResumeLayout(false);
            panel_TableColor.PerformLayout();
            ResumeLayout(false);
        }
        public FrmTables(string vno, int vType, bool frmSts)
        {
            InitializeComponent();
            vNo = vno;
            vTyp = vType;
            frmSts_ = frmSts;
        }
        private void FrmTables_Load(object sender, EventArgs e)
        {
            try
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmTables));
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    Language.ChangeLanguage("ar-SA", this, resources);
                    LangArEn = 0;
                }
                else
                {
                    Language.ChangeLanguage("en", this, resources);
                    LangArEn = 1;
                    superTabItem_Family.Text = "Family Tables";
                    superTabItem_Boys.Text = "Boys Tables";
                    superTabItem_Extnal.Text = "Extrnal Tables";
                    superTabItem_Other.Text = "Other Tables";
                    ButOk.Text = "Selected Table";
                }
                GetInvSetting();
                _processFrm();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("Load:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void _processFrm()
        {
            if (vTyp > 0)
            {
                expandablePanel_Table.Visible = false;
                if (vTyp == 1)
                {
                    superTabItem_Boys.Visible = false;
                    superTabItem_Extnal.Visible = false;
                    superTabItem_Other.Visible = false;
                }
                else if (vTyp == 2)
                {
                    superTabItem_Family.Visible = false;
                    superTabItem_Extnal.Visible = false;
                    superTabItem_Other.Visible = false;
                }
                else if (vTyp == 3)
                {
                    superTabItem_Boys.Visible = false;
                    superTabItem_Family.Visible = false;
                    superTabItem_Other.Visible = false;
                }
                else
                {
                    superTabItem_Boys.Visible = false;
                    superTabItem_Extnal.Visible = false;
                    superTabItem_Family.Visible = false;
                }
            }
            FillTable();
            TableInfo(1);
            VisibleSts = true;
        }
        private int DTime(string BTime, string Etime)
        {
            try
            {
                if (string.IsNullOrEmpty(BTime) || string.IsNullOrEmpty(Etime))
                {
                    return 0;
                }
                if (!VarGeneral.CheckDate(BTime) || !VarGeneral.CheckDate(Etime))
                {
                    return 0;
                }
                int LAmount = 0;
                if (TimeSpan.Parse(Etime) > TimeSpan.Parse(BTime))
                {
                    LAmount = int.Parse(Etime.Substring(3, 2)) - int.Parse(BTime.Substring(3, 2));
                    LAmount += 60 * (int.Parse(Etime.Substring(0, 2)) - int.Parse(BTime.Substring(0, 2)));
                }
                return LAmount;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("DTime:", error, enable: true);
                MessageBox.Show(error.Message);
                return 0;
            }
        }
        private void TableInfo(int vTableNo)
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                if (vTableNo > 0)
                {
                    List<T_Room> q = db.T_Rooms.Where((T_Room t) => t.ID == vTableNo).ToList();
                    try
                    {
                        labelItem_Tables.Text = "رقم الطاولة : " + q.FirstOrDefault().RomeNo + "    |     عدد الكراسي : " + q.FirstOrDefault().chair.Value;
                    }
                    catch (Exception error2)
                    {
                        VarGeneral.DebLog.writeLog("DTime:", error2, enable: true);
                    }
                    try
                    {
                        labelItem_Note.Text = "ملاحظة : " + q.FirstOrDefault().Note;
                    }
                    catch (Exception error2)
                    {
                        VarGeneral.DebLog.writeLog("DTime:", error2, enable: true);
                    }
                    try
                    {
                        int vtm = 0;
                        try
                        {
                            vtm = DTime(q.FirstOrDefault().T_INVHEDs.First().LTim, DateTime.Now.ToString("HH:mm"));
                        }
                        catch
                        {
                        }
                        labelItem_Time.Text = "حالة الطاولة :   " + (q.FirstOrDefault().Stop.Value ? "معطل\u0651ة" : (q.FirstOrDefault().reserved.Value ? "محجوزة" : (q.FirstOrDefault().RomeStatus.Value ? ("مشغولة منذ " + vtm + " دقيقة ") : "فارغة")));
                    }
                    catch (Exception error2)
                    {
                        VarGeneral.DebLog.writeLog("DTime:", error2, enable: true);
                    }
                    try
                    {
                        labelItem_Nadel.Text = "النادل : " + (q.FirstOrDefault().waiterNo.HasValue ? q.FirstOrDefault().T_Waiter.Arb_Des : " لا يوجد");
                    }
                    catch (Exception error2)
                    {
                        VarGeneral.DebLog.writeLog("DTime:", error2, enable: true);
                    }
                    try
                    {
                        labelItem_Type.Text = ((q.FirstOrDefault().Type.Value == 1) ? "طاولة عوائـل" : ((q.FirstOrDefault().Type.Value == 2) ? "طاولة شباب" : ((q.FirstOrDefault().Type.Value == 3) ? "طاولة خارجية" : ((q.FirstOrDefault().Type.Value == 4) ? "طاولة آخرى" : "لم يتم تحديد طاولة"))));
                    }
                    catch (Exception error2)
                    {
                        VarGeneral.DebLog.writeLog("DTime:", error2, enable: true);
                    }
                    try
                    {
                        if (q.FirstOrDefault().RomeStatus.Value)
                        {
                            labelItem_Note.Text = "صافي الفاتورة = " + q.FirstOrDefault().T_INVHEDs.Sum((T_INVHED g) => g.InvNetLocCur.Value);
                        }
                    }
                    catch (Exception error2)
                    {
                        VarGeneral.DebLog.writeLog("DTime:", error2, enable: true);
                    }
                }
                else
                {
                    labelItem_Tables.Text = "رقم الطاولة : لم يتم تحديد طاولة ";
                    labelItem_Note.Text = "ملاحظة : لا يوجد ";
                    labelItem_Time.Text = "حالة الطاولة : لم يتم تحديد طاولة ";
                    labelItem_Nadel.Text = "النادل : لا يوجد";
                    labelItem_Type.Text = "لم يتم تحديد طاولة ";
                }
                try
                {
                    labelItem_EmptyTable.Text = "عدد الطاولات الفارغة : " + db.T_Rooms.Where((T_Room t) => t.Type != (int?)0 && !t.RomeStatus.Value && !t.Stop.Value && !t.reserved.Value).ToList().Count + " طاولة ";
                    labelItem_BussyTable.Text = "عدد الطاولات المشغولة : " + db.T_Rooms.Where((T_Room t) => t.RomeStatus.Value && !t.Stop.Value && !t.reserved.Value).ToList().Count + " طاولة ";
                    labelItem_StopTable.Text = "عدد الطاولات المعط\u0651لة : " + db.T_Rooms.Where((T_Room t) => !t.RomeStatus.Value && t.Stop.Value && !t.reserved.Value).ToList().Count + " طاولة ";
                    labelItem_ReseTables.Text = "عدد الطاولات المحجوزة : " + db.T_Rooms.Where((T_Room t) => !t.RomeStatus.Value && !t.Stop.Value && t.reserved.Value).ToList().Count + " طاولة ";
                    labelItem_SumTable.Text = "إجمالي طاولات المطعم : " + db.T_Rooms.Where((T_Room t) => t.Type != (int?)0).ToList().Count + " طاولة ";
                }
                catch (Exception error2)
                {
                    VarGeneral.DebLog.writeLog("DTime:", error2, enable: true);
                }
                return;
            }
            if (vTableNo > 0)
            {
                List<T_Room> q = db.T_Rooms.Where((T_Room t) => t.ID == vTableNo).ToList();
                try
                {
                    labelItem_Tables.Text = "Table No : " + q.FirstOrDefault().RomeNo + "    |     Chair Acount : " + q.FirstOrDefault().chair.Value;
                }
                catch (Exception error2)
                {
                    VarGeneral.DebLog.writeLog("DTime:", error2, enable: true);
                }
                try
                {
                    labelItem_Note.Text = "Note : " + q.FirstOrDefault().Note;
                }
                catch (Exception error2)
                {
                    VarGeneral.DebLog.writeLog("DTime:", error2, enable: true);
                }
                try
                {
                    int vtm = 0;
                    try
                    {
                        vtm = DTime(q.FirstOrDefault().T_INVHEDs.First().LTim, DateTime.Now.ToString("HH:mm"));
                    }
                    catch
                    {
                    }
                    labelItem_Time.Text = "Table State :   " + (q.FirstOrDefault().Stop.Value ? "OFF" : (q.FirstOrDefault().reserved.Value ? "reserved" : (q.FirstOrDefault().RomeStatus.Value ? ("Busy since  " + vtm + " minute ") : "Empty")));
                }
                catch (Exception error2)
                {
                    VarGeneral.DebLog.writeLog("DTime:", error2, enable: true);
                }
                try
                {
                    labelItem_Nadel.Text = "Waiter : " + (q.FirstOrDefault().waiterNo.HasValue ? q.FirstOrDefault().T_Waiter.Eng_Des : " No");
                }
                catch (Exception error2)
                {
                    VarGeneral.DebLog.writeLog("DTime:", error2, enable: true);
                }
                try
                {
                    labelItem_Type.Text = ((q.FirstOrDefault().Type.Value == 1) ? "Family Table" : ((q.FirstOrDefault().Type.Value == 2) ? "Boys Table" : ((q.FirstOrDefault().Type.Value == 3) ? "Extrnal Table" : ((q.FirstOrDefault().Type.Value == 4) ? "Other Table" : "No Selected Table"))));
                }
                catch (Exception error2)
                {
                    VarGeneral.DebLog.writeLog("DTime:", error2, enable: true);
                }
                try
                {
                    if (q.FirstOrDefault().RomeStatus.Value)
                    {
                        labelItem_Note.Text = "Invoice Net = " + q.FirstOrDefault().T_INVHEDs.Sum((T_INVHED g) => g.InvNetLocCur.Value);
                    }
                }
                catch
                {
                }
            }
            else
            {
                labelItem_Tables.Text = "Table No : No Selected Table ";
                labelItem_Note.Text = "Note : No Note ";
                labelItem_Time.Text = "Table State : No Selected Table ";
                labelItem_Nadel.Text = "waiter : No ";
                labelItem_Type.Text = "No Selected Table ";
            }
            try
            {
                labelItem_EmptyTable.Text = "Empty Tables : " + db.T_Rooms.Where((T_Room t) => !t.RomeStatus.Value && !t.Stop.Value && !t.reserved.Value).ToList().Count + " Table ";
                labelItem_BussyTable.Text = "Bussy Tables : " + db.T_Rooms.Where((T_Room t) => t.RomeStatus.Value && !t.Stop.Value && !t.reserved.Value).ToList().Count + " Table ";
                labelItem_StopTable.Text = "OFF Tables : " + db.T_Rooms.Where((T_Room t) => !t.RomeStatus.Value && t.Stop.Value && !t.reserved.Value).ToList().Count + " Table ";
                labelItem_ReseTables.Text = "Reserved Table : " + db.T_Rooms.Where((T_Room t) => !t.RomeStatus.Value && !t.Stop.Value && t.reserved.Value).ToList().Count + " Table ";
                labelItem_SumTable.Text = "Total Tables : " + db.T_Rooms.Where((T_Room t) => t.Type != (int?)0).ToList().Count + " Table ";
            }
            catch (Exception error2)
            {
                VarGeneral.DebLog.writeLog("DTime:", error2, enable: true);
            }
        }
        private void FillComboReserve()
        {
        }
        private void FillTable()
        {
            try
            {
                itemContainer_Family.SubItems.Clear();
                itemContainer_Boys.SubItems.Clear();
                itemContainer_Extrnal.SubItems.Clear();
                itemContainer_Other.SubItems.Clear();
                List<T_Room> q = new List<T_Room>();
                q = ((vTyp > 0) ? db.FillTableSts_2(1).ToList() : ((VarGeneral.SFrmTyp == "AddToTable") ? db.FillTable_2Bussy(1).ToList() : db.FillTable_2(1).ToList()));
                for (int i = 0; i < q.Count; i++)
                {
                    MetroTileItem vTable = new MetroTileItem();
                    vTable.Image = (q[i].Stop.Value ? Resources.vStop : (q[i].reserved.Value ? Resources.reserved_64 : (q[i].RomeStatus.Value ? Resources.Bussy : Resources.Empty)));
                    vTable.ImageTextAlignment = ContentAlignment.MiddleCenter;
                    vTable.SymbolColor = Color.Empty;
                    vTable.TileColor = (q[i].Stop.Value ? eMetroTileColor.Yellow : (q[i].reserved.Value ? eMetroTileColor.Gray : (q[i].RomeStatus.Value ? eMetroTileColor.Orange : eMetroTileColor.Azure)));
                    vTable.TileSize = new Size(160, 140);
                    vTable.TileStyle.CornerType = eCornerType.Diagonal;
                    vTable.TitleText = ((LangArEn == 0) ? "طاولة | " : "Table | ") + q[i].RomeNo;
                    vTable.Tag = q[i].ID.ToString();
                    vTable.TitleTextAlignment = ContentAlignment.BottomCenter;
                    vTable.TitleTextFont = new Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.Point, 0);
                    itemContainer_Family.SubItems.AddRange(new BaseItem[1]
                    {
                        vTable
                    });
                }
                q = ((vTyp > 0) ? db.FillTableSts_2(2).ToList() : ((VarGeneral.SFrmTyp == "AddToTable") ? db.FillTable_2Bussy(2).ToList() : db.FillTable_2(2).ToList()));
                for (int i = 0; i < q.Count; i++)
                {
                    MetroTileItem vTable = new MetroTileItem();
                    vTable.Image = (q[i].Stop.Value ? Resources.vStop : (q[i].reserved.Value ? Resources.reserved_64 : (q[i].RomeStatus.Value ? Resources.Bussy : Resources.Empty)));
                    vTable.ImageTextAlignment = ContentAlignment.MiddleCenter;
                    vTable.SymbolColor = Color.Empty;
                    vTable.TileColor = (q[i].Stop.Value ? eMetroTileColor.Yellow : (q[i].reserved.Value ? eMetroTileColor.Gray : (q[i].RomeStatus.Value ? eMetroTileColor.Orange : eMetroTileColor.Azure)));
                    vTable.TileSize = new Size(160, 140);
                    vTable.TileStyle.CornerType = eCornerType.Diagonal;
                    vTable.TitleText = ((LangArEn == 0) ? "طاولة | " : "Table | ") + q[i].RomeNo;
                    vTable.Tag = q[i].ID.ToString();
                    vTable.TitleTextAlignment = ContentAlignment.BottomCenter;
                    vTable.TitleTextFont = new Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.Point, 0);
                    itemContainer_Boys.SubItems.AddRange(new BaseItem[1]
                    {
                        vTable
                    });
                }
                q = ((vTyp > 0) ? db.FillTableSts_2(3).ToList() : ((VarGeneral.SFrmTyp == "AddToTable") ? db.FillTable_2Bussy(3).ToList() : db.FillTable_2(3).ToList()));
                for (int i = 0; i < q.Count; i++)
                {
                    MetroTileItem vTable = new MetroTileItem();
                    vTable.Image = (q[i].Stop.Value ? Resources.vStop : (q[i].reserved.Value ? Resources.reserved_64 : (q[i].RomeStatus.Value ? Resources.Bussy : Resources.Empty)));
                    vTable.ImageTextAlignment = ContentAlignment.MiddleCenter;
                    vTable.SymbolColor = Color.Empty;
                    vTable.TileColor = (q[i].Stop.Value ? eMetroTileColor.Yellow : (q[i].reserved.Value ? eMetroTileColor.Gray : (q[i].RomeStatus.Value ? eMetroTileColor.Orange : eMetroTileColor.Azure)));
                    vTable.TileSize = new Size(160, 140);
                    vTable.TileStyle.CornerType = eCornerType.Diagonal;
                    vTable.TitleText = ((LangArEn == 0) ? "طاولة | " : "Table | ") + q[i].RomeNo;
                    vTable.Tag = q[i].ID.ToString();
                    vTable.TitleTextAlignment = ContentAlignment.BottomCenter;
                    vTable.TitleTextFont = new Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.Point, 0);
                    itemContainer_Extrnal.SubItems.AddRange(new BaseItem[1]
                    {
                        vTable
                    });
                }
                q = ((vTyp > 0) ? db.FillTableSts_2(4).ToList() : ((VarGeneral.SFrmTyp == "AddToTable") ? db.FillTable_2Bussy(4).ToList() : db.FillTable_2(4).ToList()));
                for (int i = 0; i < q.Count; i++)
                {
                    MetroTileItem vTable = new MetroTileItem();
                    vTable.Image = (q[i].Stop.Value ? Resources.vStop : (q[i].reserved.Value ? Resources.reserved_64 : (q[i].RomeStatus.Value ? Resources.Bussy : Resources.Empty)));
                    vTable.ImageTextAlignment = ContentAlignment.MiddleCenter;
                    vTable.SymbolColor = Color.Empty;
                    vTable.TileColor = (q[i].Stop.Value ? eMetroTileColor.Yellow : (q[i].reserved.Value ? eMetroTileColor.Gray : (q[i].RomeStatus.Value ? eMetroTileColor.Orange : eMetroTileColor.Azure)));
                    vTable.TileSize = new Size(160, 140);
                    vTable.TileStyle.CornerType = eCornerType.Diagonal;
                    vTable.TitleText = ((LangArEn == 0) ? "طاولة | " : "Table | ") + q[i].RomeNo;
                    vTable.Tag = q[i].ID.ToString();
                    vTable.TitleTextAlignment = ContentAlignment.BottomCenter;
                    vTable.TitleTextFont = new Font("Tahoma", 11f, FontStyle.Regular, GraphicsUnit.Point, 0);
                    itemContainer_Other.SubItems.AddRange(new BaseItem[1]
                    {
                        vTable
                    });
                }
                Refresh();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("FillTable:", error, enable: true);
                itemContainer_Family.SubItems.Clear();
                itemContainer_Boys.SubItems.Clear();
                itemContainer_Extrnal.SubItems.Clear();
                itemContainer_Other.SubItems.Clear();
                Refresh();
            }
        }
        private void FrmTables_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void FrmTables_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void metroTilePanel_Family_ItemClick(object sender, EventArgs e)
        {
            try
            {
                MetroTileItem q = (vItemSelect = sender as MetroTileItem);
                if (q != null)
                {
                    TableInfo(int.Parse(q.Tag.ToString()));
                    VisibleSts = false;
                }
                else
                {
                    TableInfo(1);
                    VisibleSts = true;
                }
                if (vTyp > 0)
                {
                    ButOk_Click(sender, e);
                }
            }
            catch
            {
                vItemSelect = null;
                VisibleSts = true;
            }
        }
        private void ButOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (vItemSelect == null)
                {
                    MessageBox.Show((LangArEn == 0) ? "لم تقم باختيار طاولة .. يرجى تحديد الطاولة ثم المحاولة مرة آخرى" : "You do not choose a table .. Please identify the table and then try again", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else if (vItemSelect.TileColor == eMetroTileColor.Orange)
                {
                    if (VarGeneral.SFrmTyp != "AddToTable")
                    {
                        if (!string.IsNullOrEmpty(vItemSelect.TitleText) && !string.IsNullOrEmpty(vItemSelect.Tag.ToString()))
                        {
                            if (MessageBox.Show((LangArEn == 0) ? "عفوا\u064c ..لقد قمت باختيار طاولة مشغولة حاليا .. \n هل تريد القيام بإفراغ هذه الطاولة؟" : "do you want Clear This Table ?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                            {
                                return;
                            }
                            if (db.StockRommID(int.Parse(vItemSelect.Tag.ToString())).T_INVHEDs.FirstOrDefault().InvTyp == 21)
                            {
                                MessageBox.Show((LangArEn == 0) ? "لا يمكن استخدام هذه الطاولة  .. لقد تم ربطه بطلب محلي غير مستخدم \n يرجى استخدام الطلب أولا او ازالته من قائمة الطلبات" : "You do not choose a table .. Please identify the table and then try again", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                return;
                            }
                            db.ExecuteCommand("UPDATE T_INVHED SET RoomNo = 1 ,RoomSts = 0,RoomPerson = 1 where RoomNo =" + int.Parse(vItemSelect.Tag.ToString()));
                            db.ExecuteCommand("UPDATE [T_Rooms] SET [RomeStatus] = 0, [waiterNo] = NULL Where ID =" + int.Parse(vItemSelect.Tag.ToString()));
                            try
                            {
                                Serach_No = int.Parse(vItemSelect.Tag.ToString());
                                Close();
                            }
                            catch (SqlException)
                            {
                            }
                            catch (Exception)
                            {
                            }
                            return;
                        }
                        MessageBox.Show((LangArEn == 0) ? "عفوا\u064c ..لقد قمت باختيار طاولة مشغولة حاليا.. يرجى تغيير الطاولة" : "Sorry .. you choose currently busy table .. please change the table", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        Serach_No = int.Parse(vItemSelect.Tag.ToString());
                        Close();
                    }
                }
                else if (vItemSelect.TileColor == eMetroTileColor.Yellow)
                {
                    if (!string.IsNullOrEmpty(vItemSelect.TitleText) && !string.IsNullOrEmpty(vItemSelect.Tag.ToString()))
                    {
                        if (MessageBox.Show((LangArEn == 0) ? "عفوا\u064c ..لقد قمت باختيار طاولة معط\u0651لة حاليا .. \n هل تريد إلغاء تعطيل هذه الطاولة؟" : "Do you want to cancel disable this table ?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            T_Room DataThis = db.StockRommID(int.Parse(vItemSelect.Tag.ToString()));
                            DataThis.Stop = false;
                            try
                            {
                                db.Log = VarGeneral.DebugLog;
                                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                                Serach_No = int.Parse(vItemSelect.Tag.ToString());
                                Close();
                            }
                            catch (SqlException)
                            {
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show((LangArEn == 0) ? "عفوا\u064c ..لقد قمت باختيار طاولة معط\u0651لة حاليا.. يرجى تغيير الطاولة" : "Sorry .. you choose currently OFF table .. please change the table", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                else if (vItemSelect.TileColor == eMetroTileColor.Gray)
                {
                    if (!string.IsNullOrEmpty(vItemSelect.TitleText) && !string.IsNullOrEmpty(vItemSelect.Tag.ToString()))
                    {
                        if (MessageBox.Show((LangArEn == 0) ? "عفوا\u064c ..لقد قمت باختيار طاولة محجوزة حاليا .. \n هل تريد إزالة حجز هذه الطاولة؟" : "Do you want to cancel a reservation at this table ?", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            T_Room DataThis = db.StockRommID(int.Parse(vItemSelect.Tag.ToString()));
                            DataThis.reserved = false;
                            try
                            {
                                db.Log = VarGeneral.DebugLog;
                                db.SubmitChanges(ConflictMode.ContinueOnConflict);
                                Serach_No = int.Parse(vItemSelect.Tag.ToString());
                                Close();
                            }
                            catch (SqlException)
                            {
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show((LangArEn == 0) ? "عفوا\u064c ..لقد قمت باختيار طاولة محجوزة حاليا.. يرجى تغيير الطاولة" : "Sorry .. you choose currently reserved table .. please change the table", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                else if (!string.IsNullOrEmpty(vItemSelect.TitleText) && !string.IsNullOrEmpty(vItemSelect.Tag.ToString()))
                {
                    Serach_No = int.Parse(vItemSelect.Tag.ToString());
                    Close();
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("ButOk_Click:", error, enable: true);
                MessageBox.Show((LangArEn == 0) ? "لم تقم باختيار طاولة .. يرجى تحديد الطاولة ثم المحاولة مرة آخرى" : "You do not choose a table .. Please identify the table and then try again", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void metroTilePanel_Family_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                ToolStripMenuItem_Rep.Visible = false;
                if (VarGeneral._IsWaiter || e.Button != MouseButtons.Right)
                {
                    return;
                }
                metroTilePanel_Family_ItemClick(sender, e);
                if (!ButOk.Visible || vItemSelect == null)
                {
                    return;
                }
                if (vItemSelect.TileColor == eMetroTileColor.Orange)
                {
                    if (!string.IsNullOrEmpty(vItemSelect.TitleText) && !string.IsNullOrEmpty(vItemSelect.Tag.ToString()))
                    {
                        ToolStripMenuItem_Rep.Visible = true;
                        ToolStripMenuItem_Rep.Text = ((LangArEn == 0) ? "طبــاعـــة" : "Print");
                        ToolStripMenuItem_Op.Text = ((LangArEn == 0) ? "إفـراغ الطاولة" : "Clear");
                        if (db.StockRommID(int.Parse(vItemSelect.Tag.ToString())).T_INVHEDs.FirstOrDefault().InvTyp != 21)
                        {
                            goto IL_0240;
                        }
                    }
                }
                else if (vItemSelect.TileColor == eMetroTileColor.Yellow)
                {
                    if (!string.IsNullOrEmpty(vItemSelect.TitleText) && !string.IsNullOrEmpty(vItemSelect.Tag.ToString()))
                    {
                        ToolStripMenuItem_Op.Text = ((LangArEn == 0) ? "إلغاء تعطيل الطاولة" : "Clear");
                        goto IL_0240;
                    }
                }
                else if (vItemSelect.TileColor == eMetroTileColor.Gray && !string.IsNullOrEmpty(vItemSelect.TitleText) && !string.IsNullOrEmpty(vItemSelect.Tag.ToString()))
                {
                    ToolStripMenuItem_Op.Text = ((LangArEn == 0) ? "إلغاء حجز الطاولة" : "Clear");
                    goto IL_0240;
                }
                goto end_IL_0001;
            IL_0240:
                contextMenuStrip2.Show(Control.MousePosition);
            end_IL_0001:;
            }
            catch
            {
            }
        }
        private void ToolStripMenuItem_Op_Click(object sender, EventArgs e)
        {
            try
            {
                if (vItemSelect == null)
                {
                    return;
                }
                if (vItemSelect.TileColor == eMetroTileColor.Orange)
                {
                    if (!string.IsNullOrEmpty(vItemSelect.TitleText) && !string.IsNullOrEmpty(vItemSelect.Tag.ToString()))
                    {
                        if (db.StockRommID(int.Parse(vItemSelect.Tag.ToString())).T_INVHEDs.FirstOrDefault().InvTyp == 21)
                        {
                            return;
                        }
                        db.ExecuteCommand("UPDATE T_INVHED SET RoomNo = 1 ,RoomSts = 0,RoomPerson = 1 where RoomNo =" + int.Parse(vItemSelect.Tag.ToString()));
                        db.ExecuteCommand("UPDATE [T_Rooms] SET [RomeStatus] = 0, [waiterNo] = NULL Where ID =" + int.Parse(vItemSelect.Tag.ToString()));
                    }
                }
                else if (vItemSelect.TileColor == eMetroTileColor.Yellow)
                {
                    if (!string.IsNullOrEmpty(vItemSelect.TitleText) && !string.IsNullOrEmpty(vItemSelect.Tag.ToString()))
                    {
                        db.ExecuteCommand("UPDATE [T_Rooms] SET [Stop] = 0 Where ID =" + int.Parse(vItemSelect.Tag.ToString()));
                    }
                }
                else if (vItemSelect.TileColor == eMetroTileColor.Gray && !string.IsNullOrEmpty(vItemSelect.TitleText) && !string.IsNullOrEmpty(vItemSelect.Tag.ToString()))
                {
                    db.ExecuteCommand("UPDATE [T_Rooms] SET [reserved] = 0 Where ID =" + int.Parse(vItemSelect.Tag.ToString()));
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("ToolStripMenuItem_Op_Click:", error, enable: true);
                return;
            }
            VarGeneral.Tb_Return = true;
            Close();
        }
        private void GetInvSetting()
        {
            _InvSetting = new T_INVSETTING();
            _InvSetting = db.StockInvSetting(VarGeneral.UserID, VarGeneral.InvTyp);
        }
        private int vStr(int vTy)
        {
            if (VarGeneral.InvTyp == 1)
            {
                if (VarGeneral._IsPOS)
                {
                    return 27;
                }
                return 1;
            }
            if (VarGeneral.InvTyp == 1)
            {
                return 1;
            }
            if (VarGeneral.InvTyp == 2)
            {
                return 5;
            }
            if (VarGeneral.InvTyp == 3)
            {
                return 3;
            }
            if (VarGeneral.InvTyp == 4)
            {
                return 7;
            }
            if (VarGeneral.InvTyp == 7)
            {
                return 9;
            }
            if (VarGeneral.InvTyp == 8)
            {
                return 11;
            }
            if (VarGeneral.InvTyp == 9)
            {
                return 13;
            }
            if (VarGeneral.InvTyp == 14)
            {
                return 15;
            }
            if (VarGeneral.InvTyp == 5)
            {
                return 17;
            }
            if (VarGeneral.InvTyp == 6)
            {
                return 19;
            }
            if (VarGeneral.InvTyp == 17)
            {
                return 21;
            }
            if (VarGeneral.InvTyp == 20)
            {
                return 23;
            }
            return 25;
        }
        private void ToolStripMenuItem_Rep_Click(object sender, EventArgs e)
        {
            VarGeneral.EmptyTablePrint = false;
            if (_InvSetting.InvpRINTERInfo.nTyp.Substring(0, 1) == "1")
            {
                RepShow _RepShow = new RepShow();
                _RepShow.Tables = "T_INVDET LEFT OUTER JOIN T_INVHED ON T_INVDET.InvId = T_INVHED.InvHed_ID LEFT OUTER JOIN T_Rooms ON T_INVHED.RoomNo = T_Rooms.ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_INVDET.ItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                string vInvH = " T_INVHED.InvHed_ID, T_INVHED.InvId as vID, T_INVHED.InvNo, T_INVHED.InvTyp, T_INVHED.InvCashPay, T_INVHED.CusVenNo,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Arb_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNm,case when T_INVHED.CusVenNo = '' THEN T_INVHED.CusVenNm ELSE (select T_AccDef.Eng_Des from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as CusVenNmE, T_INVHED.CusVenAdd, T_INVHED.CusVenTel, T_INVHED.Remark, T_INVHED.HDat, T_INVHED.GDat, T_INVHED.MndNo, T_INVHED.SalsManNo, T_INVHED.SalsManNam, T_INVHED.InvTot, T_INVHED.InvDisPrs, ((case when IsDisUse1 = 1 then T_INVHED.InvValGaidDis else T_INVHED.InvDisVal end) + T_INVHED.DesPointsValue) as InvDisVal,T_INVHED.InvDisVal as InvDisValOnly,T_INVHED.DesPointsValue,T_INVHED.DesPointsValueLocCur,T_INVHED.PointsCount,T_INVHED.IsPoints, T_INVHED.InvNet, T_INVHED.InvNetLocCur, T_INVHED.CashPayLocCur, T_INVHED.IfRet, T_INVHED.CashPay, T_INVHED.InvTotLocCur, T_INVHED.InvDisValLocCur, T_INVHED.GadeNo, T_INVHED.GadeId, T_INVHED.RetNo, T_INVHED.RetId, T_INVHED.InvCashPayNm, T_INVHED.InvCost, T_INVHED.CustPri, T_INVHED.ArbTaf, T_INVHED.ToStore, T_INVHED.InvCash, T_INVHED.CurTyp, T_INVHED.EstDat,case when DATEDIFF(day, GETDATE(), EstDat) > 0 Then DATEDIFF(day, GETDATE(), EstDat) WHEN DATEDIFF(day, GETDATE(), InvCashPayNm) > 0 THEN DATEDIFF(day, GETDATE(), InvCashPayNm) Else '0' END as EstDatNote, T_INVHED.InvCstNo, T_INVHED.IfDel, T_INVHED.RefNo, T_INVHED.ToStoreNm, T_INVHED.EngTaf, T_INVHED.IfTrans, T_INVHED.InvQty, T_INVHED.CustNet, T_INVHED.CustRep, T_INVHED.InvWight_T, T_INVHED.IfPrint, T_INVHED.LTim, T_INVHED.DATE_CREATED, T_INVHED.MODIFIED_BY, T_INVHED.CreditPay, T_INVHED.DATE_MODIFIED, T_INVHED.CREATED_BY, T_INVHED.CreditPayLocCur, T_INVHED.NetworkPay, T_INVHED.NetworkPayLocCur, T_INVHED.MndExtrnal, T_INVHED.CompanyID, T_INVHED.InvAddCost, T_INVHED.InvAddCostExtrnal, T_INVHED.InvAddCostExtrnalLoc, T_INVHED.IsExtrnalGaid, T_INVHED.ExtrnalCostGaidID, T_INVHED.InvAddCostLoc, T_INVHED.CommMnd_Inv, T_INVHED.Puyaid, T_INVHED.Remming,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.PersonalNm from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as PersonalNm,T_SYSSETTING.LineGiftlNameA,T_SYSSETTING.LineGiftlNameE,T_Rooms.RomeNo";
                string Fields = " Abs(T_INVDET.Qty) as QtyAbs , T_INVDET.InvDet_ID, T_INVDET.InvNo, T_INVDET.InvId, T_INVDET.InvSer, T_INVDET.ItmNo, T_INVDET.Cost, T_INVDET.Qty, T_INVDET.ItmUnt, T_INVDET.ItmDes,T_INVDET.ItmDesE , T_INVDET.ItmUntE, T_INVDET.ItmUntPak, T_INVDET.StoreNo, T_INVDET.Price, T_INVDET.Amount, T_INVDET.RealQty, T_INVDET.ItmTyp,T_INVDET.ItmDis, (Abs(T_INVDET.Qty) *  T_INVDET.Price) * (T_INVDET.ItmDis / 100) as ItmDisVal, T_INVDET.DatExper, T_INVDET.itmInvDsc,ItmIndex ," + (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.LineGiftSts, vStr(VarGeneral.InvTyp)) ? " T_INVDET.ItmWight " : " 0 as ItmWight") + ", T_INVDET.ItmWight_T, T_INVDET.ItmAddCost, T_INVDET.RunCod, T_INVDET.LineDetails ,T_INVDET.Serial_Key, " + vInvH + ", T_Items.* , T_CstTbl.Arb_Des as CstTbl_Arb_Des , T_CstTbl.Eng_Des as CstTbl_Eng_Des , T_Mndob.Arb_Des as Mndob_Arb_Des , T_Mndob.Eng_Des as Mndob_Eng_Des,T_SYSSETTING.LogImg,(select max(T_AccDef.TaxNo) from T_AccDef where T_AccDef.AccDef_No = T_SYSSETTING.TaxAcc) as TaxAcc,T_SYSSETTING.TaxNoteInv,case when T_INVHED.IsTaxLines = 1 then (case when T_INVHED.IsTaxByTotal = 1 then (case when (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) > 0 then ((Abs(T_INVDET.Qty) *  T_INVDET.Price) - case when (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) > 0 then (Abs(T_INVDET.Qty) * T_INVDET.Price * T_INVDET.ItmDis / 100) else 0 end )* T_INVDET.ItmTax / 100   else 0 end) else (Abs(T_INVDET.Qty) *  T_INVDET.Price * T_INVDET.ItmTax / 100) end) else 0 end as TaxValue ,(select InvNamA from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as InvNamA,(select InvNamE from T_INVSETTING where T_INVHED.InvTyp = T_INVSETTING.InvID ) as InvNamE,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.Mobile from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as Mobile,(select T_Store.Arb_Des from T_Store where T_Store.Stor_ID = T_INVDET.StoreNo) as StoreNmA,(select T_Store.Eng_Des from T_Store where T_Store.Stor_ID = T_INVDET.StoreNo) as StoreNmE,(select defPrn from T_INVSETTING where CatID = (select ItmCat from T_Items where Itm_No = T_INVDET.ItmNo) ) as defPrn,case when T_INVHED.CusVenNo = '' THEN '0' ELSE (SELECT Sum(T_GDDET.gdValue) FROM T_GDHEAD INNER JOIN  T_GDDET ON T_GDHEAD.gdhead_ID = T_GDDET.gdID where T_GDDET.AccNo = T_INVHED.CusVenNo and T_GDHEAD.gdLok = 0 and (select T_AccDef.AccCat from T_AccDef where T_AccDef.AccDef_No = T_INVHED.CusVenNo) = '4') END as Balanc,T_INVDET.ItmTax,T_INVHED.InvAddTax,T_INVHED.InvAddTaxlLoc,T_INVHED.TaxGaidID,T_INVHED.IsTaxUse,T_INVHED.IsTaxLines,IsTaxByTotal,case when T_INVHED.CusVenNo = '' THEN '' ELSE (select T_AccDef.TaxNo from T_AccDef where AccDef_No = T_INVHED.CusVenNo) END as TaxCustNo";
                VarGeneral.HeaderRep[0] = Text;
                VarGeneral.HeaderRep[1] = "";
                VarGeneral.HeaderRep[2] = "";
                _RepShow.Rule = " where (T_INVHED.InvTyp = 21 or T_INVHED.InvTyp = 1) and T_INVHED.RoomNo > 1 and T_Rooms.RomeStatus = 1 and T_INVHED.RoomSts = 1 and T_INVHED.RoomNo = " + int.Parse(vItemSelect.Tag.ToString());
                if (!string.IsNullOrEmpty(Fields))
                {
                    _RepShow.Fields = Fields;
                    try
                    {
                        _RepShow = _RepShow.Save();
                        VarGeneral.RepData = _RepShow.RepData;
                        _RepShow = new RepShow();
                        _RepShow.Rule = " WHERE T_Users.UsrNo = '" + VarGeneral.RepData.Tables[0].Rows[0]["SalsManNo"].ToString() + "'";
                        _RepShow.Tables = " T_Branch INNER JOIN T_Users ON T_Branch.Branch_no = T_Users.Brn ";
                        _RepShow.Fields = " T_Users.UsrNamA ,T_Branch.Branch_Name ,T_Users.UsrNamE ,T_Branch.Branch_NameE ,T_Users.UsrImg ";
                        try
                        {
                            VarGeneral.RepShowStock_Rat = "Rate";
                            _RepShow = _RepShow.Save();
                            VarGeneral.RepShowStock_Rat = "";
                        }
                        catch (Exception ex2)
                        {
                            VarGeneral.RepShowStock_Rat = "";
                            MessageBox.Show(ex2.Message);
                        }
                        _RepShow.RepData.Tables[0].Merge(VarGeneral.RepData.Tables[0]);
                        VarGeneral.RepData = _RepShow.RepData;
                        try
                        {
                            for (int j = 0; j < VarGeneral.RepData.Tables[0].Rows.Count; j++)
                            {
                                if (string.IsNullOrEmpty(VarGeneral.RepData.Tables[0].Rows[j]["LogImg"].ToString()))
                                {
                                    VarGeneral.RepData.Tables[0].Rows[j]["LogImg"] = VarGeneral.RepData.Tables[0].Rows[VarGeneral.RepData.Tables[0].Rows.Count - 1]["LogImg"];
                                    VarGeneral.RepData.Tables[0].Rows[j]["LTim"] = VarGeneral.RepData.Tables[0].Rows[VarGeneral.RepData.Tables[0].Rows.Count - 1]["LTim"];
                                }
                            }
                        }
                        catch
                        {
                        }
                        try
                        {
                            for (int j = 0; j < VarGeneral.RepData.Tables[0].Rows.Count; j++)
                            {
                                if (string.IsNullOrEmpty(VarGeneral.RepData.Tables[0].Rows[j]["UsrImg"].ToString()))
                                {
                                    try
                                    {
                                        VarGeneral.RepData.Tables[0].Rows[j]["UsrImg"] = VarGeneral.RepData.Tables[0].Rows[0]["UsrImg"];
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                        }
                        catch
                        {
                        }
                        try
                        {
                            if (VarGeneral.TString.ChkStatShow(VarGeneral.Settings_Sys.Seting, 15))
                            {
                                _RepShow = new RepShow();
                                _RepShow.Tables = "T_SINVDET LEFT OUTER JOIN T_INVHED ON T_SINVDET.SInvIdHEAD = T_INVHED.InvHed_ID LEFT OUTER JOIN T_Rooms ON T_INVHED.RoomNo = T_Rooms.ID LEFT OUTER JOIN T_INVSETTING ON T_INVHED.InvTyp = T_INVSETTING.InvID  LEFT OUTER JOIN T_Curency ON T_INVHED.CurTyp = T_Curency.Curency_ID LEFT OUTER JOIN T_CstTbl ON T_INVHED.InvCstNo = T_CstTbl.Cst_ID LEFT OUTER JOIN T_Mndob ON T_INVHED.MndNo = T_Mndob.Mnd_ID LEFT OUTER JOIN T_Items ON T_SINVDET.SItmNo = T_Items.Itm_No LEFT OUTER JOIN T_CATEGORY ON T_Items.ItmCat = T_CATEGORY.CAT_ID LEFT OUTER JOIN T_SYSSETTING ON T_INVHED.CompanyID = T_SYSSETTING.SYSSETTING_ID ";
                                _RepShow.Fields = " Abs(T_SINVDET.SQty) as QtyAbs , SInvDet_ID as InvId , SInvNo as InvNo, SInvId as InvDet_ID, SInvSer as InvSer,SItmNo as ItmNo, SCost as Cost, SQty as Qty, SItmDes as ItmDes, SItmUnt as ItmUnt, SItmDesE as ItmDesE, SItmUntE as ItmUntE, SItmUntPak as ItmUntPak, SStoreNo as StoreNo, (SPrice * 0) as Price, (SAmount * 0) as Amount, SRealQty as RealQty, SitmInvDsc as itmInvDsc, SDatExper as DatExper, SItmDis as ItmDis, SItmTyp as ItmTyp,SItmIndex as ItmIndex, SItmWight_T as ItmWight_T, SItmWight as ItmWight , T_INVHED.* , T_Items.* , T_CstTbl.Arb_Des as CstTbl_Arb_Des , T_CstTbl.Eng_Des as CstTbl_Eng_Des , T_Mndob.Arb_Des as Mndob_Arb_Des , T_Mndob.Eng_Des as Mndob_Eng_Des,T_SYSSETTING.LogImg,(select max(T_AccDef.TaxNo) from T_AccDef where T_AccDef.AccDef_No = T_SYSSETTING.TaxAcc) as TaxAcc,T_SYSSETTING.TaxNoteInv";
                                _RepShow.Rule = " where (T_INVHED.InvTyp = 21 or T_INVHED.InvTyp = 1) and T_INVHED.RoomNo > 1 and T_Rooms.RomeStatus = 1 and T_INVHED.RoomSts = 1 and T_INVHED.RoomNo = " + int.Parse(vItemSelect.Tag.ToString());
                                _RepShow = _RepShow.Save();
                                VarGeneral.RepData.Tables[0].Merge(_RepShow.RepData.Tables[0]);
                            }
                        }
                        catch
                        {
                        }
                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show(ex2.Message);
                    }
                    if (VarGeneral.RepData.Tables[0].Rows.Count != 0)
                    {
                        double sum1 = 0.0;
                        double sum11 = 0.0;
                        double sum12 = 0.0;
                        double sum13 = 0.0;
                        double sum14 = 0.0;
                        double sum15 = 0.0;
                        double sum16 = 0.0;
                        double sum17 = 0.0;
                        double sum18 = 0.0;
                        double sum2 = 0.0;
                        double sum3 = 0.0;
                        double sum4 = 0.0;
                        double sum5 = 0.0;
                        double sum6 = 0.0;
                        double sum7 = 0.0;
                        double sum8 = 0.0;
                        double sum9 = 0.0;
                        double sum10 = 0.0;
                        try
                        {
                            List<string> _list = new List<string>();
                            int i;
                            for (i = 0; i < VarGeneral.RepData.Tables[0].Rows.Count; i++)
                            {
                                try
                                {
                                    if (!string.IsNullOrEmpty(VarGeneral.RepData.Tables[0].Rows[i]["InvHed_ID"].ToString()) && string.IsNullOrEmpty(_list.Find((string x) => x == VarGeneral.RepData.Tables[0].Rows[i]["InvHed_ID"].ToString())))
                                    {
                                        _list.Add(VarGeneral.RepData.Tables[0].Rows[i]["InvHed_ID"].ToString());
                                        try
                                        {
                                            sum1 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["InvTot"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            sum11 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["InvTotLocCur"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            sum12 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["InvDisVal"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            sum13 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["InvDisValLocCur"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            sum14 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["InvNet"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            sum15 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["InvNetLocCur"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            sum16 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["CashPay"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            sum17 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["CashPayLocCur"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            sum18 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["CreditPay"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            sum2 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["CreditPayLocCur"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            sum3 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["NetworkPay"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            sum4 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["NetworkPayLocCur"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            sum5 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["Puyaid"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            sum6 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["Remming"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            sum7 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["InvAddTax"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            sum8 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["InvAddTaxlLoc"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            sum9 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["InvDisPrs"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                        try
                                        {
                                            sum10 += double.Parse(VarGeneral.RepData.Tables[0].Rows[i]["Puyaid"].ToString());
                                        }
                                        catch
                                        {
                                        }
                                    }
                                }
                                catch
                                {
                                }
                            }
                            for (int j = 0; j < VarGeneral.RepData.Tables[0].Rows.Count; j++)
                            {
                                foreach (DataRow dr in VarGeneral.RepData.Tables[0].Rows)
                                {
                                    VarGeneral.RepData.Tables[0].Rows[j]["InvTot"] = sum1;
                                    VarGeneral.RepData.Tables[0].Rows[j]["InvTotLocCur"] = sum11;
                                    VarGeneral.RepData.Tables[0].Rows[j]["InvDisVal"] = sum12;
                                    VarGeneral.RepData.Tables[0].Rows[j]["InvDisValLocCur"] = sum13;
                                    VarGeneral.RepData.Tables[0].Rows[j]["InvNet"] = sum14;
                                    VarGeneral.RepData.Tables[0].Rows[j]["InvNetLocCur"] = sum15;
                                    VarGeneral.RepData.Tables[0].Rows[j]["CashPay"] = sum16;
                                    VarGeneral.RepData.Tables[0].Rows[j]["CashPayLocCur"] = sum17;
                                    VarGeneral.RepData.Tables[0].Rows[j]["CreditPay"] = sum18;
                                    VarGeneral.RepData.Tables[0].Rows[j]["CreditPayLocCur"] = sum2;
                                    VarGeneral.RepData.Tables[0].Rows[j]["NetworkPay"] = sum3;
                                    VarGeneral.RepData.Tables[0].Rows[j]["NetworkPayLocCur"] = sum4;
                                    VarGeneral.RepData.Tables[0].Rows[j]["Puyaid"] = sum5;
                                    VarGeneral.RepData.Tables[0].Rows[j]["Remming"] = sum6;
                                    VarGeneral.RepData.Tables[0].Rows[j]["InvAddTax"] = sum7;
                                    VarGeneral.RepData.Tables[0].Rows[j]["InvAddTaxlLoc"] = sum8;
                                    VarGeneral.RepData.Tables[0].Rows[j]["InvDisPrs"] = sum9;
                                    VarGeneral.RepData.Tables[0].Rows[j]["Puyaid"] = sum10;
                                    if (double.Parse(VarGeneral.TString.TEmpty(VarGeneral.RepData.Tables[0].Rows[j]["Puyaid"].ToString())) > 0.0)
                                    {
                                        VarGeneral.RepData.Tables[0].Rows[j]["Remming"] = double.Parse(VarGeneral.TString.TEmpty(VarGeneral.RepData.Tables[0].Rows[j]["Puyaid"].ToString())) - double.Parse(VarGeneral.TString.TEmpty(VarGeneral.RepData.Tables[0].Rows[j]["InvNetLocCur"].ToString()));
                                    }
                                    else
                                    {
                                        VarGeneral.RepData.Tables[0].Rows[j]["Remming"] = 0;
                                    }
                                }
                            }
                            FrmReportsViewer frm = new FrmReportsViewer();
                            frm.Tag = LangArEn;
                            frm.BarcodSts = false;
                            VarGeneral.EmptyTablePrint = true;
                            if (_InvSetting.InvpRINTERInfo.nTyp.Substring(1, 1) == "1")
                            {
                                frm.Repvalue = "InvSal";
                            }
                            else
                            {
                                frm.RepCashier = "InvoiceCachier";
                            }
                            VarGeneral.vTitle = Text;
                            if (_InvSetting.InvpRINTERInfo.nTyp.Substring(2, 1) == "0")
                            {
                                frm._Proceess();
                            }
                            else
                            {
                                frm.TopMost = true;
                                frm.ShowDialog();
                            }
                        }
                        catch (Exception error)
                        {
                            VarGeneral.DebLog.writeLog("buttonItem_Print_Click:", error, enable: true);
                            MessageBox.Show(error.Message);
                        }
                    }
                }
            }
            VarGeneral.EmptyTablePrint = false;
        }
    }
}
