using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar.SuperGrid.Style;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmInvDetNoteSrch : Form
    {
        private IContainer components = null;
        private GroupPanel groupPanel_BoardNo;
        private ButtonX button_0;
        private ButtonX button_2;
        private ButtonX button_1;
        private ButtonX button_6;
        private ButtonX button_5;
        private ButtonX button_8;
        private ButtonX button_7;
        private ButtonX button_Bac;
        private ButtonX button_3;
        private ButtonX button_4;
        private ButtonX button_9;
        private Panel panel1;
        private SuperTabControl superTabControl_ItemsGrids;
        protected LabelItem labelItem2;
        protected ButtonItem btnPrevPage_Det;
        protected ButtonItem btnNxtPage_Det;
        private SuperGridControl dataGridView_ItemDet;
        private ButtonX button_Exit;
        private ButtonX button_Save;
        protected ButtonItem buttonItem_FrmNotes;
        public TextBoxX textbox_Detailes;
        private string vTot = "";
        private int PageSizeDet = 10;
        private int CurrentPageIndexItmDet = 1;
        private int TotalPageDet = 0;
        private int col_Det = 0;
        private int colW_Det = 0;
        private int row_Det = 0;
        private int rowH_Det = 0;
        public static int LangArEn = 0;
        public string Serach_No = "";
        private Stock_DataDataContext dbInstance;
        public string SerachNo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmInvDetNoteSrch));
            groupPanel_BoardNo = new DevComponents.DotNetBar.Controls.GroupPanel();
            button_0 = new DevComponents.DotNetBar.ButtonX();
            button_2 = new DevComponents.DotNetBar.ButtonX();
            button_1 = new DevComponents.DotNetBar.ButtonX();
            button_6 = new DevComponents.DotNetBar.ButtonX();
            button_5 = new DevComponents.DotNetBar.ButtonX();
            button_8 = new DevComponents.DotNetBar.ButtonX();
            button_7 = new DevComponents.DotNetBar.ButtonX();
            button_Bac = new DevComponents.DotNetBar.ButtonX();
            button_3 = new DevComponents.DotNetBar.ButtonX();
            button_4 = new DevComponents.DotNetBar.ButtonX();
            button_9 = new DevComponents.DotNetBar.ButtonX();
            panel1 = new System.Windows.Forms.Panel();
            button_Exit = new DevComponents.DotNetBar.ButtonX();
            button_Save = new DevComponents.DotNetBar.ButtonX();
            textbox_Detailes = new DevComponents.DotNetBar.Controls.TextBoxX();
            superTabControl_ItemsGrids = new DevComponents.DotNetBar.SuperTabControl();
            labelItem2 = new DevComponents.DotNetBar.LabelItem();
            btnPrevPage_Det = new DevComponents.DotNetBar.ButtonItem();
            btnNxtPage_Det = new DevComponents.DotNetBar.ButtonItem();
            buttonItem_FrmNotes = new DevComponents.DotNetBar.ButtonItem();
            dataGridView_ItemDet = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            groupPanel_BoardNo.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)superTabControl_ItemsGrids).BeginInit();
            SuspendLayout();
            groupPanel_BoardNo.AccessibleDescription = null;
            groupPanel_BoardNo.AccessibleName = null;
            resources.ApplyResources(groupPanel_BoardNo, "groupPanel_BoardNo");
            groupPanel_BoardNo.BackColor = System.Drawing.Color.Transparent;
            groupPanel_BoardNo.CanvasColor = System.Drawing.Color.Transparent;
            groupPanel_BoardNo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Metro;
            groupPanel_BoardNo.Controls.Add(button_0);
            groupPanel_BoardNo.Controls.Add(button_2);
            groupPanel_BoardNo.Controls.Add(button_1);
            groupPanel_BoardNo.Controls.Add(button_6);
            groupPanel_BoardNo.Controls.Add(button_5);
            groupPanel_BoardNo.Controls.Add(button_8);
            groupPanel_BoardNo.Controls.Add(button_7);
            groupPanel_BoardNo.Controls.Add(button_Bac);
            groupPanel_BoardNo.Controls.Add(button_3);
            groupPanel_BoardNo.Controls.Add(button_4);
            groupPanel_BoardNo.Controls.Add(button_9);
            groupPanel_BoardNo.Font = null;
            groupPanel_BoardNo.Name = "groupPanel_BoardNo";
            groupPanel_BoardNo.Style.BackColor = System.Drawing.Color.Transparent;
            groupPanel_BoardNo.Style.BackColorGradientAngle = 90;
            groupPanel_BoardNo.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel_BoardNo.Style.BorderBottomWidth = 1;
            groupPanel_BoardNo.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            groupPanel_BoardNo.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel_BoardNo.Style.BorderLeftWidth = 1;
            groupPanel_BoardNo.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel_BoardNo.Style.BorderRightWidth = 1;
            groupPanel_BoardNo.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            groupPanel_BoardNo.Style.BorderTopWidth = 1;
            groupPanel_BoardNo.Style.CornerDiameter = 4;
            groupPanel_BoardNo.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            groupPanel_BoardNo.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            groupPanel_BoardNo.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            groupPanel_BoardNo.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            groupPanel_BoardNo.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            groupPanel_BoardNo.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            button_0.AccessibleDescription = null;
            button_0.AccessibleName = null;
            button_0.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_0, "button_0");
            button_0.BackgroundImage = null;
            button_0.Checked = true;
            button_0.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            button_0.CommandParameter = null;
            button_0.Name = "button_0";
            button_0.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_0.Click += new System.EventHandler(button_0_Click);
            button_2.AccessibleDescription = null;
            button_2.AccessibleName = null;
            button_2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_2, "button_2");
            button_2.BackgroundImage = null;
            button_2.Checked = true;
            button_2.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            button_2.CommandParameter = null;
            button_2.Name = "button_2";
            button_2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_2.Click += new System.EventHandler(button_2_Click);
            button_1.AccessibleDescription = null;
            button_1.AccessibleName = null;
            button_1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_1, "button_1");
            button_1.BackgroundImage = null;
            button_1.Checked = true;
            button_1.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            button_1.CommandParameter = null;
            button_1.Name = "button_1";
            button_1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_1.Click += new System.EventHandler(button_1_Click);
            button_6.AccessibleDescription = null;
            button_6.AccessibleName = null;
            button_6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_6, "button_6");
            button_6.BackgroundImage = null;
            button_6.Checked = true;
            button_6.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            button_6.CommandParameter = null;
            button_6.Name = "button_6";
            button_6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_6.Click += new System.EventHandler(button_6_Click);
            button_5.AccessibleDescription = null;
            button_5.AccessibleName = null;
            button_5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_5, "button_5");
            button_5.BackgroundImage = null;
            button_5.Checked = true;
            button_5.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            button_5.CommandParameter = null;
            button_5.Name = "button_5";
            button_5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_5.Click += new System.EventHandler(button_5_Click);
            button_8.AccessibleDescription = null;
            button_8.AccessibleName = null;
            button_8.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_8, "button_8");
            button_8.BackgroundImage = null;
            button_8.Checked = true;
            button_8.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            button_8.CommandParameter = null;
            button_8.Name = "button_8";
            button_8.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_8.Click += new System.EventHandler(button_8_Click);
            button_7.AccessibleDescription = null;
            button_7.AccessibleName = null;
            button_7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_7, "button_7");
            button_7.BackgroundImage = null;
            button_7.Checked = true;
            button_7.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            button_7.CommandParameter = null;
            button_7.Name = "button_7";
            button_7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_7.Click += new System.EventHandler(button_7_Click);
            button_Bac.AccessibleDescription = null;
            button_Bac.AccessibleName = null;
            button_Bac.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_Bac, "button_Bac");
            button_Bac.BackgroundImage = null;
            button_Bac.Checked = true;
            button_Bac.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            button_Bac.CommandParameter = null;
            button_Bac.Name = "button_Bac";
            button_Bac.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_Bac.Click += new System.EventHandler(button_Bac_Click);
            button_3.AccessibleDescription = null;
            button_3.AccessibleName = null;
            button_3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_3, "button_3");
            button_3.BackgroundImage = null;
            button_3.Checked = true;
            button_3.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            button_3.CommandParameter = null;
            button_3.Name = "button_3";
            button_3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_3.Click += new System.EventHandler(button_3_Click);
            button_4.AccessibleDescription = null;
            button_4.AccessibleName = null;
            button_4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_4, "button_4");
            button_4.BackgroundImage = null;
            button_4.Checked = true;
            button_4.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            button_4.CommandParameter = null;
            button_4.Name = "button_4";
            button_4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_4.Click += new System.EventHandler(button_4_Click);
            button_9.AccessibleDescription = null;
            button_9.AccessibleName = null;
            button_9.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_9, "button_9");
            button_9.BackgroundImage = null;
            button_9.Checked = true;
            button_9.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            button_9.CommandParameter = null;
            button_9.Name = "button_9";
            button_9.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_9.Click += new System.EventHandler(button_9_Click);
            panel1.AccessibleDescription = null;
            panel1.AccessibleName = null;
            resources.ApplyResources(panel1, "panel1");
            panel1.BackgroundImage = null;
            panel1.Controls.Add(button_Exit);
            panel1.Controls.Add(button_Save);
            panel1.Controls.Add(textbox_Detailes);
            panel1.Font = null;
            panel1.Name = "panel1";
            button_Exit.AccessibleDescription = null;
            button_Exit.AccessibleName = null;
            button_Exit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_Exit, "button_Exit");
            button_Exit.BackgroundImage = null;
            button_Exit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            button_Exit.CommandParameter = null;
            button_Exit.Name = "button_Exit";
            button_Exit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_Exit.Click += new System.EventHandler(button_Exit_Click);
            button_Save.AccessibleDescription = null;
            button_Save.AccessibleName = null;
            button_Save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_Save, "button_Save");
            button_Save.BackgroundImage = null;
            button_Save.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            button_Save.CommandParameter = null;
            button_Save.Name = "button_Save";
            button_Save.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_Save.Click += new System.EventHandler(button_Save_Click);
            textbox_Detailes.AcceptsReturn = true;
            textbox_Detailes.AccessibleDescription = null;
            textbox_Detailes.AccessibleName = null;
            resources.ApplyResources(textbox_Detailes, "textbox_Detailes");
            textbox_Detailes.BackColor = System.Drawing.Color.White;
            textbox_Detailes.BackgroundImage = null;
            textbox_Detailes.Border.Class = "TextBoxBorder";
            textbox_Detailes.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            textbox_Detailes.ButtonCustom.DisplayPosition = (int)resources.GetObject("textbox_Detailes.ButtonCustom.DisplayPosition");
            textbox_Detailes.ButtonCustom.Image = null;
            textbox_Detailes.ButtonCustom.Text = resources.GetString("textbox_Detailes.ButtonCustom.Text");
            textbox_Detailes.ButtonCustom.Visible = true;
            textbox_Detailes.ButtonCustom2.DisplayPosition = (int)resources.GetObject("textbox_Detailes.ButtonCustom2.DisplayPosition");
            textbox_Detailes.ButtonCustom2.Image = null;
            textbox_Detailes.ButtonCustom2.Text = resources.GetString("textbox_Detailes.ButtonCustom2.Text");
            textbox_Detailes.ForeColor = System.Drawing.Color.Black;
            textbox_Detailes.Name = "textbox_Detailes";
            textbox_Detailes.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            textbox_Detailes.ButtonCustomClick += new System.EventHandler(textbox_Detailes_ButtonCustomClick);
            superTabControl_ItemsGrids.AccessibleDescription = null;
            superTabControl_ItemsGrids.AccessibleName = null;
            resources.ApplyResources(superTabControl_ItemsGrids, "superTabControl_ItemsGrids");
            superTabControl_ItemsGrids.BackColor = System.Drawing.Color.White;
            superTabControl_ItemsGrids.BackgroundImage = null;
            superTabControl_ItemsGrids.CausesValidation = false;
            superTabControl_ItemsGrids.ControlBox.Category = null;
            superTabControl_ItemsGrids.ControlBox.CloseBox.Category = null;
            superTabControl_ItemsGrids.ControlBox.CloseBox.CommandParameter = null;
            superTabControl_ItemsGrids.ControlBox.CloseBox.Description = null;
            superTabControl_ItemsGrids.ControlBox.CloseBox.Name = "";
            superTabControl_ItemsGrids.ControlBox.CloseBox.Tag = null;
            superTabControl_ItemsGrids.ControlBox.CloseBox.Text = resources.GetString("superTabControl_ItemsGrids.ControlBox.CloseBox.Text");
            superTabControl_ItemsGrids.ControlBox.CloseBox.Tooltip = resources.GetString("superTabControl_ItemsGrids.ControlBox.CloseBox.Tooltip");
            superTabControl_ItemsGrids.ControlBox.CommandParameter = null;
            superTabControl_ItemsGrids.ControlBox.Description = null;
            superTabControl_ItemsGrids.ControlBox.MenuBox.Category = null;
            superTabControl_ItemsGrids.ControlBox.MenuBox.CommandParameter = null;
            superTabControl_ItemsGrids.ControlBox.MenuBox.Description = null;
            superTabControl_ItemsGrids.ControlBox.MenuBox.Name = "";
            superTabControl_ItemsGrids.ControlBox.MenuBox.Tag = null;
            superTabControl_ItemsGrids.ControlBox.MenuBox.Text = resources.GetString("superTabControl_ItemsGrids.ControlBox.MenuBox.Text");
            superTabControl_ItemsGrids.ControlBox.MenuBox.Tooltip = resources.GetString("superTabControl_ItemsGrids.ControlBox.MenuBox.Tooltip");
            superTabControl_ItemsGrids.ControlBox.Name = "";
            superTabControl_ItemsGrids.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[2]
            {
                superTabControl_ItemsGrids.ControlBox.MenuBox,
                superTabControl_ItemsGrids.ControlBox.CloseBox
            });
            superTabControl_ItemsGrids.ControlBox.Tag = null;
            superTabControl_ItemsGrids.ControlBox.Text = resources.GetString("superTabControl_ItemsGrids.ControlBox.Text");
            superTabControl_ItemsGrids.ControlBox.Tooltip = resources.GetString("superTabControl_ItemsGrids.ControlBox.Tooltip");
            superTabControl_ItemsGrids.ControlBox.Visible = false;
            superTabControl_ItemsGrids.Font = null;
            superTabControl_ItemsGrids.ForeColor = System.Drawing.Color.Black;
            superTabControl_ItemsGrids.ItemPadding.Bottom = 4;
            superTabControl_ItemsGrids.ItemPadding.Left = 4;
            superTabControl_ItemsGrids.ItemPadding.Right = 4;
            superTabControl_ItemsGrids.ItemPadding.Top = 4;
            superTabControl_ItemsGrids.Name = "superTabControl_ItemsGrids";
            superTabControl_ItemsGrids.ReorderTabsEnabled = true;
            superTabControl_ItemsGrids.SelectedTabIndex = -1;
            superTabControl_ItemsGrids.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[4]
            {
                labelItem2,
                btnPrevPage_Det,
                btnNxtPage_Det,
                buttonItem_FrmNotes
            });
            superTabControl_ItemsGrids.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            superTabControl_ItemsGrids.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            resources.ApplyResources(labelItem2, "labelItem2");
            labelItem2.CommandParameter = null;
            labelItem2.Name = "labelItem2";
            labelItem2.TextAlignment = System.Drawing.StringAlignment.Center;
            labelItem2.Width = 2;
            resources.ApplyResources(btnPrevPage_Det, "btnPrevPage_Det");
            btnPrevPage_Det.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            btnPrevPage_Det.Checked = true;
            btnPrevPage_Det.CommandParameter = null;
            btnPrevPage_Det.FontBold = true;
            btnPrevPage_Det.FontItalic = true;
            btnPrevPage_Det.ForeColor = System.Drawing.Color.SteelBlue;
            btnPrevPage_Det.Image = (System.Drawing.Image)resources.GetObject("btnPrevPage_Det.Image");
            btnPrevPage_Det.ImageFixedSize = new System.Drawing.Size(28, 28);
            btnPrevPage_Det.ImagePaddingHorizontal = 15;
            btnPrevPage_Det.ImagePaddingVertical = 11;
            btnPrevPage_Det.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            btnPrevPage_Det.Name = "btnPrevPage_Det";
            btnPrevPage_Det.SplitButton = true;
            btnPrevPage_Det.Stretch = true;
            btnPrevPage_Det.SubItemsExpandWidth = 14;
            btnPrevPage_Det.Symbol = "\uf04e";
            btnPrevPage_Det.SymbolSize = 15f;
            btnPrevPage_Det.Click += new System.EventHandler(btnPrevPage_Det_Click);
            resources.ApplyResources(btnNxtPage_Det, "btnNxtPage_Det");
            btnNxtPage_Det.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            btnNxtPage_Det.Checked = true;
            btnNxtPage_Det.CommandParameter = null;
            btnNxtPage_Det.FontBold = true;
            btnNxtPage_Det.FontItalic = true;
            btnNxtPage_Det.ForeColor = System.Drawing.Color.SteelBlue;
            btnNxtPage_Det.Image = (System.Drawing.Image)resources.GetObject("btnNxtPage_Det.Image");
            btnNxtPage_Det.ImageFixedSize = new System.Drawing.Size(28, 28);
            btnNxtPage_Det.ImagePaddingHorizontal = 15;
            btnNxtPage_Det.ImagePaddingVertical = 11;
            btnNxtPage_Det.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            btnNxtPage_Det.Name = "btnNxtPage_Det";
            btnNxtPage_Det.SplitButton = true;
            btnNxtPage_Det.Stretch = true;
            btnNxtPage_Det.SubItemsExpandWidth = 14;
            btnNxtPage_Det.Symbol = "\uf04a";
            btnNxtPage_Det.SymbolSize = 15f;
            btnNxtPage_Det.Click += new System.EventHandler(btnNxtPage_Det_Click);
            resources.ApplyResources(buttonItem_FrmNotes, "buttonItem_FrmNotes");
            buttonItem_FrmNotes.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            buttonItem_FrmNotes.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            buttonItem_FrmNotes.CommandParameter = null;
            buttonItem_FrmNotes.FontBold = true;
            buttonItem_FrmNotes.FontItalic = true;
            buttonItem_FrmNotes.ForeColor = System.Drawing.Color.SteelBlue;
            buttonItem_FrmNotes.Image = (System.Drawing.Image)resources.GetObject("buttonItem_FrmNotes.Image");
            buttonItem_FrmNotes.ImageFixedSize = new System.Drawing.Size(28, 28);
            buttonItem_FrmNotes.ImagePaddingHorizontal = 15;
            buttonItem_FrmNotes.ImagePaddingVertical = 11;
            buttonItem_FrmNotes.Name = "buttonItem_FrmNotes";
            buttonItem_FrmNotes.SplitButton = true;
            buttonItem_FrmNotes.Stretch = true;
            buttonItem_FrmNotes.SubItemsExpandWidth = 14;
            buttonItem_FrmNotes.Symbol = "\uf067";
            buttonItem_FrmNotes.SymbolSize = 15f;
            buttonItem_FrmNotes.Click += new System.EventHandler(buttonItem_FrmNotes_Click);
            dataGridView_ItemDet.AccessibleDescription = null;
            dataGridView_ItemDet.AccessibleName = null;
            resources.ApplyResources(dataGridView_ItemDet, "dataGridView_ItemDet");
            dataGridView_ItemDet.BackgroundImage = null;
            dataGridView_ItemDet.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            dataGridView_ItemDet.Font = null;
            dataGridView_ItemDet.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            dataGridView_ItemDet.Name = "dataGridView_ItemDet";
            dataGridView_ItemDet.PrimaryGrid.AllowEdit = false;
            dataGridView_ItemDet.PrimaryGrid.ColumnHeader.Visible = false;
            dataGridView_ItemDet.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            dataGridView_ItemDet.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            dataGridView_ItemDet.PrimaryGrid.InitialActiveRow = DevComponents.DotNetBar.SuperGrid.RelativeRow.None;
            dataGridView_ItemDet.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.None;
            dataGridView_ItemDet.PrimaryGrid.MultiSelect = false;
            dataGridView_ItemDet.PrimaryGrid.ShowColumnHeader = false;
            dataGridView_ItemDet.PrimaryGrid.ShowRowHeaders = false;
            dataGridView_ItemDet.CellClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellClickEventArgs>(dataGridView_ItemDet_CellClick);
            base.AccessibleDescription = null;
            base.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            BackgroundImage = null;
            base.ControlBox = false;
            base.Controls.Add(panel1);
            base.Controls.Add(superTabControl_ItemsGrids);
            base.Controls.Add(dataGridView_ItemDet);
            base.Controls.Add(groupPanel_BoardNo);
            Font = null;
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.Name = "FrmInvDetNoteSrch";
            base.Load += new System.EventHandler(FrmInvDetNoteSrch_Load);
            base.SizeChanged += new System.EventHandler(FrmInvDetNoteSrch_SizeChanged);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Frm_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(Frm_KeyDown);
            groupPanel_BoardNo.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)superTabControl_ItemsGrids).EndInit();
            ResumeLayout(false);
        }
        public FrmInvDetNoteSrch()
        {
            InitializeComponent();
        }
        private void Frm_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                SerachNo = "";
                Close();
            }
        }
        private void FrmInvDetNoteSrch_Load(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmInvDetNoteSrch));
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Language.ChangeLanguage("ar-SA", this, resources);
                LangArEn = 0;
            }
            else
            {
                Language.ChangeLanguage("en", this, resources);
                LangArEn = 1;
                button_Save.Text = "OK";
                button_Exit.Text = "Close";
                button_Bac.Text = "Clear";
                btnPrevPage_Det.Text = "Previous";
                btnNxtPage_Det.Text = "Next";
            }
            ItemsDetSetting();
            base.ActiveControl = textbox_Detailes;
        }
        private void ItemsDetSetting()
        {
            dataGridView_ItemDet.PrimaryGrid.Rows.Clear();
            dataGridView_ItemDet.PrimaryGrid.Columns.Clear();
            col_Det = dataGridView_ItemDet.Width / 100;
            colW_Det = dataGridView_ItemDet.Width / col_Det;
            row_Det = dataGridView_ItemDet.Height / 43;
            rowH_Det = dataGridView_ItemDet.Height / row_Det;
            PageSizeDet = Math.Abs(col_Det * row_Det);
            try
            {
                for (int i = 0; i < col_Det; i++)
                {
                    GridColumn q = new GridColumn();
                    q.Width = colW_Det;
                    dataGridView_ItemDet.PrimaryGrid.Columns.Add(q);
                }
                for (int i = 0; i < row_Det; i++)
                {
                    GridRow c = new GridRow();
                    c.RowHeight = rowH_Det;
                    c.RowStyles.Default.Background.Color1 = Color.AliceBlue;
                    for (int j = 0; j < col_Det; j++)
                    {
                        c.Cells.Add(new GridCell(""));
                    }
                    dataGridView_ItemDet.PrimaryGrid.Rows.Add(c);
                }
            }
            catch
            {
            }
            FillItmesDet();
        }
        private void FillItmesDet()
        {
            List<T_InvDetNote> vItems = new List<T_InvDetNote>();
            Stock_DataDataContext dbc = new Stock_DataDataContext(VarGeneral.BranchCS);
            vItems = dbc.T_InvDetNotes.OrderBy((T_InvDetNote t) => t.InvDetNote_No).ToList();
            if (vItems.Count <= 0)
            {
                ClearItemsDet();
                return;
            }
            CalculateTotalPagesItemDet(vItems);
            GetCurrentRecordsItemDet(1);
        }
        private void CalculateTotalPagesItemDet(List<T_InvDetNote> vItems)
        {
            try
            {
                int rowCount = vItems.ToList().Count;
                TotalPageDet = rowCount / PageSizeDet;
                if (rowCount % PageSizeDet > 0)
                {
                    TotalPageDet++;
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("CalculateTotalPagesItemDet:", error, enable: true);
                if (TotalPageDet <= 0)
                {
                    TotalPageDet = 1;
                }
            }
        }
        private void GetCurrentRecordsItemDet(int page)
        {
            try
            {
                List<T_InvDetNote> dt = new List<T_InvDetNote>();
                if (page == 1)
                {
                    dt = db.ExecuteQuery<T_InvDetNote>("Select TOP " + PageSizeDet + " * from T_InvDetNote ORDER BY InvDetNote_No", new object[0]).ToList();
                }
                else
                {
                    int PreviouspageLimit = (page - 1) * PageSizeDet;
                    dt = db.ExecuteQuery<T_InvDetNote>("Select TOP " + PageSizeDet + " * from T_InvDetNote WHERE InvDetNote_No NOT IN (Select TOP " + PreviouspageLimit + " InvDetNote_No from T_InvDetNote ORDER BY InvDetNote_No)) ", new object[0]).ToList();
                }
                int iicnt = 0;
                foreach (GridRow rowCell in dataGridView_ItemDet.PrimaryGrid.Rows)
                {
                    foreach (GridCell cell in rowCell.Cells)
                    {
                        if (iicnt < dt.Count)
                        {
                            try
                            {
                                cell.Value = ((LangArEn == 0) ? dt[iicnt].Arb_Des : dt[iicnt].Eng_Des);
                                cell.Tag = dt[iicnt].InvDetNote_No;
                                cell.CellStyles.Default.AllowWrap = Tbool.True;
                                iicnt++;
                            }
                            catch
                            {
                                iicnt++;
                            }
                        }
                        else
                        {
                            cell.Value = "";
                        }
                    }
                }
            }
            catch
            {
            }
        }
        private void btnFirstPAge_Det_Click(object sender, EventArgs e)
        {
            CurrentPageIndexItmDet = 1;
            GetCurrentRecordsItemDet(CurrentPageIndexItmDet);
        }
        private void btnPrevPage_Det_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndexItmDet > 1)
            {
                CurrentPageIndexItmDet--;
                GetCurrentRecordsItemDet(CurrentPageIndexItmDet);
            }
        }
        private void btnNxtPage_Det_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndexItmDet < TotalPageDet)
            {
                CurrentPageIndexItmDet++;
                GetCurrentRecordsItemDet(CurrentPageIndexItmDet);
            }
        }
        private void btnLastPage_Det_Click(object sender, EventArgs e)
        {
            CurrentPageIndexItmDet = TotalPageDet;
            GetCurrentRecordsItemDet(CurrentPageIndexItmDet);
        }
        private void ClearItemsDet()
        {
            foreach (GridRow rowCell in dataGridView_ItemDet.PrimaryGrid.Rows)
            {
                foreach (GridCell cell in rowCell.Cells)
                {
                    cell.Value = "";
                    cell.Tag = "";
                }
            }
        }
        private void FrmInvDetNoteSrch_SizeChanged(object sender, EventArgs e)
        {
            ItemsDetSetting();
        }
        private void button_1_Click(object sender, EventArgs e)
        {
            vTot += 1;
            textbox_Detailes.Focus();
            try
            {
                textbox_Detailes.SelectionStart = textbox_Detailes.Text.Length;
                textbox_Detailes.SelectionLength = 0;
            }
            catch
            {
                textbox_Detailes.SelectionLength = 0;
            }
        }
        private void button_2_Click(object sender, EventArgs e)
        {
            vTot += 2;
            textbox_Detailes.Focus();
            try
            {
                textbox_Detailes.SelectionStart = textbox_Detailes.Text.Length;
                textbox_Detailes.SelectionLength = 0;
            }
            catch
            {
                textbox_Detailes.SelectionLength = 0;
            }
        }
        private void button_3_Click(object sender, EventArgs e)
        {
            vTot += 3;
            textbox_Detailes.Focus();
            try
            {
                textbox_Detailes.SelectionStart = textbox_Detailes.Text.Length;
                textbox_Detailes.SelectionLength = 0;
            }
            catch
            {
                textbox_Detailes.SelectionLength = 0;
            }
        }
        private void button_4_Click(object sender, EventArgs e)
        {
            vTot += 4;
            textbox_Detailes.Focus();
            try
            {
                textbox_Detailes.SelectionStart = textbox_Detailes.Text.Length;
                textbox_Detailes.SelectionLength = 0;
            }
            catch
            {
                textbox_Detailes.SelectionLength = 0;
            }
        }
        private void button_5_Click(object sender, EventArgs e)
        {
            vTot += 5;
            textbox_Detailes.Focus();
            try
            {
                textbox_Detailes.SelectionStart = textbox_Detailes.Text.Length;
                textbox_Detailes.SelectionLength = 0;
            }
            catch
            {
                textbox_Detailes.SelectionLength = 0;
            }
        }
        private void button_6_Click(object sender, EventArgs e)
        {
            vTot += 6;
            textbox_Detailes.Focus();
            try
            {
                textbox_Detailes.SelectionStart = textbox_Detailes.Text.Length;
                textbox_Detailes.SelectionLength = 0;
            }
            catch
            {
                textbox_Detailes.SelectionLength = 0;
            }
        }
        private void button_7_Click(object sender, EventArgs e)
        {
            vTot += 7;
            textbox_Detailes.Focus();
            try
            {
                textbox_Detailes.SelectionStart = textbox_Detailes.Text.Length;
                textbox_Detailes.SelectionLength = 0;
            }
            catch
            {
                textbox_Detailes.SelectionLength = 0;
            }
        }
        private void button_8_Click(object sender, EventArgs e)
        {
            vTot += 8;
            textbox_Detailes.Focus();
            try
            {
                textbox_Detailes.SelectionStart = textbox_Detailes.Text.Length;
                textbox_Detailes.SelectionLength = 0;
            }
            catch
            {
                textbox_Detailes.SelectionLength = 0;
            }
        }
        private void button_9_Click(object sender, EventArgs e)
        {
            vTot += 9;
            textbox_Detailes.Focus();
            try
            {
                textbox_Detailes.SelectionStart = textbox_Detailes.Text.Length;
                textbox_Detailes.SelectionLength = 0;
            }
            catch
            {
                textbox_Detailes.SelectionLength = 0;
            }
        }
        private void button_0_Click(object sender, EventArgs e)
        {
            vTot += 0;
            textbox_Detailes.Focus();
            try
            {
                textbox_Detailes.SelectionStart = textbox_Detailes.Text.Length;
                textbox_Detailes.SelectionLength = 0;
            }
            catch
            {
                textbox_Detailes.SelectionLength = 0;
            }
        }
        private void button_Bac_Click(object sender, EventArgs e)
        {
            textbox_Detailes.Text = "";
            vTot = "";
            textbox_Detailes.Focus();
            try
            {
                textbox_Detailes.SelectionStart = textbox_Detailes.Text.Length;
                textbox_Detailes.SelectionLength = 0;
            }
            catch
            {
                textbox_Detailes.SelectionLength = 0;
            }
        }
        private void button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                SerachNo = textbox_Detailes.Text;
                Close();
            }
            catch
            {
                SerachNo = "";
                Close();
            }
        }
        private void button_Exit_Click(object sender, EventArgs e)
        {
            SerachNo = "";
            Close();
        }
        private void textbox_Detailes_ButtonCustomClick(object sender, EventArgs e)
        {
            textbox_Detailes.Text = "";
        }
        private void dataGridView_ItemDet_CellClick(object sender, GridCellClickEventArgs e)
        {
            try
            {
                int eRow = e.GridCell.RowIndex;
                int eCol = e.GridCell.ColumnIndex;
                object q = dataGridView_ItemDet.PrimaryGrid.GetCell(eRow, eCol).Tag;
                if (string.IsNullOrEmpty(q.ToString()) || string.IsNullOrEmpty(dataGridView_ItemDet.PrimaryGrid.GetCell(eRow, eCol).Value.ToString()))
                {
                    return;
                }
                SerachNo = q.ToString();
                textbox_Detailes.Text += ((LangArEn != 0) ? (string.IsNullOrEmpty(textbox_Detailes.Text) ? (vTot + " " + db.StockInvDetNote(SerachNo).Eng_Des + " ") : (" + " + vTot + " " + db.StockInvDetNote(SerachNo).Eng_Des + " ")) : (string.IsNullOrEmpty(textbox_Detailes.Text) ? (vTot + " " + db.StockInvDetNote(SerachNo).Arb_Des + " ") : (" + " + vTot + " " + db.StockInvDetNote(SerachNo).Arb_Des + " ")));
            }
            catch
            {
                SerachNo = "";
            }
            vTot = "";
        }
        private void buttonItem_FrmNotes_Click(object sender, EventArgs e)
        {
            FrmInvDetNote frm = new FrmInvDetNote();
            frm.Tag = LangArEn;
            frm.TopMost = true;
            frm.ShowDialog();
            ItemsDetSetting();
        }
    }
}
