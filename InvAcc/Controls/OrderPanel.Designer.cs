namespace InvAcc.Controls
{
    partial class OrderPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ButOk = new DevComponents.DotNetBar.ButtonX();
            this.labelItem_SumTable = new DevComponents.DotNetBar.LabelItem();
            this.itemPanel2 = new DevComponents.DotNetBar.ItemPanel();
            this.labelItem_Type = new DevComponents.DotNetBar.LabelItem();
            this.labelItem_Nadel = new DevComponents.DotNetBar.LabelItem();
            this.labelItem_Time = new DevComponents.DotNetBar.LabelItem();
            this.labelItem_Note = new DevComponents.DotNetBar.LabelItem();
            this.labelItem_Tables = new DevComponents.DotNetBar.LabelItem();
            this.itemPanel1 = new DevComponents.DotNetBar.ItemPanel();
            this.expandablePanel_Table = new DevComponents.DotNetBar.ExpandablePanel();
            this.panel_ButSave = new System.Windows.Forms.Panel();
            this.checkBox_ByName = new DevComponents.DotNetBar.CheckBoxItem();
            this.checkBox_ByMobile = new DevComponents.DotNetBar.CheckBoxItem();
            this.labelItem_Mobile = new DevComponents.DotNetBar.LabelItem();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            this.superTabItem_Customer = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.metroTilePanel_Customer = new DevComponents.DotNetBar.Metro.MetroTilePanel();
            this.itemContainer_Customer = new DevComponents.DotNetBar.ItemContainer();
            this.superTabControl_Tables = new DevComponents.DotNetBar.SuperTabControl();
            this.txtSearchMobile = new DevComponents.DotNetBar.TextBoxItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_Rep = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Det = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.expandablePanel_Table.SuspendLayout();
            this.panel_ButSave.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Tables)).BeginInit();
            this.superTabControl_Tables.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButOk
            // 
            this.ButOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButOk.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.ButOk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButOk.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButOk.Location = new System.Drawing.Point(0, 0);
            this.ButOk.Name = "ButOk";
            this.ButOk.Size = new System.Drawing.Size(133, 101);
            this.ButOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButOk.Symbol = "???";
            this.ButOk.SymbolSize = 16F;
            this.ButOk.TabIndex = 6784;
            this.ButOk.Text = "????????????????????????????";
            this.ButOk.TextColor = System.Drawing.Color.White;
            this.ButOk.Click += new System.EventHandler(this.ButOk_Click);
            // 
            // labelItem_SumTable
            // 
            this.labelItem_SumTable.BackColor = System.Drawing.Color.Red;
            this.labelItem_SumTable.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem_SumTable.ForeColor = System.Drawing.Color.White;
            this.labelItem_SumTable.Name = "labelItem_SumTable";
            this.labelItem_SumTable.Text = "labelItem1";
            this.labelItem_SumTable.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelItem_SumTable.Click += new System.EventHandler(this.labelItem_SumTable_Click);
            // 
            // itemPanel2
            // 
            // 
            // 
            // 
            this.itemPanel2.BackgroundStyle.Class = "ItemPanel";
            this.itemPanel2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel2.ContainerControlProcessDialogKey = true;
            this.itemPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.itemPanel2.Font = new System.Drawing.Font("Tahoma", 8F);
            this.itemPanel2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem_SumTable});
            this.itemPanel2.ItemSpacing = 4;
            this.itemPanel2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel2.Tag= "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel2.Location = new System.Drawing.Point(133, 26);
            this.itemPanel2.Name = "itemPanel2";
            this.itemPanel2.Size = new System.Drawing.Size(240, 101);
            this.itemPanel2.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.itemPanel2.TabIndex = 2;
            this.itemPanel2.Text = "itemPanel2";
            this.itemPanel2.ItemClick += new System.EventHandler(this.itemPanel2_ItemClick);
            // 
            // labelItem_Type
            // 
            this.labelItem_Type.BackColor = System.Drawing.Color.Yellow;
            this.labelItem_Type.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem_Type.Name = "labelItem_Type";
            this.labelItem_Type.Text = "labelItem1";
            this.labelItem_Type.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelItem_Type.Click += new System.EventHandler(this.labelItem_Type_Click);
            // 
            // labelItem_Nadel
            // 
            this.labelItem_Nadel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem_Nadel.ForeColor = System.Drawing.Color.Maroon;
            this.labelItem_Nadel.Name = "labelItem_Nadel";
            this.labelItem_Nadel.Text = "labelItem7";
            this.labelItem_Nadel.Click += new System.EventHandler(this.labelItem_Nadel_Click);
            // 
            // labelItem_Time
            // 
            this.labelItem_Time.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem_Time.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelItem_Time.Name = "labelItem_Time";
            this.labelItem_Time.Text = "labelItem6";
            this.labelItem_Time.Click += new System.EventHandler(this.labelItem_Time_Click);
            // 
            // labelItem_Note
            // 
            this.labelItem_Note.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem_Note.ForeColor = System.Drawing.Color.Gray;
            this.labelItem_Note.Name = "labelItem_Note";
            this.labelItem_Note.Text = "labelItem2";
            this.labelItem_Note.Click += new System.EventHandler(this.labelItem_Note_Click);
            // 
            // labelItem_Tables
            // 
            this.labelItem_Tables.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem_Tables.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.labelItem_Tables.Name = "labelItem_Tables";
            this.labelItem_Tables.Text = "labelItem1";
            this.labelItem_Tables.Click += new System.EventHandler(this.labelItem_Tables_Click);
            // 
            // itemPanel1
            // 
            // 
            // 
            // 
            this.itemPanel1.BackgroundStyle.Class = "ItemPanel";
            this.itemPanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel1.ContainerControlProcessDialogKey = true;
            this.itemPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPanel1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.itemPanel1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem_Tables,
            this.labelItem_Note,
            this.labelItem_Time,
            this.labelItem_Nadel,
            this.labelItem_Type});
            this.itemPanel1.ItemSpacing = 4;
            this.itemPanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel1.Tag= "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.itemPanel1.Location = new System.Drawing.Point(373, 26);
            this.itemPanel1.Name = "itemPanel1";
            this.itemPanel1.Size = new System.Drawing.Size(530, 101);
            this.itemPanel1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.itemPanel1.TabIndex = 1;
            this.itemPanel1.Text = "itemPanel1";
            this.itemPanel1.ItemClick += new System.EventHandler(this.itemPanel1_ItemClick);
            // 
            // expandablePanel_Table
            // 
            this.expandablePanel_Table.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel_Table.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.expandablePanel_Table.Controls.Add(this.itemPanel1);
            this.expandablePanel_Table.Controls.Add(this.itemPanel2);
            this.expandablePanel_Table.Controls.Add(this.panel_ButSave);
            this.expandablePanel_Table.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.expandablePanel_Table.ExpandButtonVisible = false;
            this.expandablePanel_Table.ExpandOnTitleClick = true;
            this.expandablePanel_Table.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.expandablePanel_Table.Location = new System.Drawing.Point(0, 333);
            this.expandablePanel_Table.Name = "expandablePanel_Table";
            this.expandablePanel_Table.Size = new System.Drawing.Size(903, 127);
            this.expandablePanel_Table.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_Table.Style.BackColor1.Color = System.Drawing.Color.AliceBlue;
            this.expandablePanel_Table.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            this.expandablePanel_Table.Style.BorderColor.Color = System.Drawing.Color.White;
            this.expandablePanel_Table.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel_Table.Style.GradientAngle = 90;
            this.expandablePanel_Table.TabIndex = 978;
            this.expandablePanel_Table.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel_Table.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel_Table.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel_Table.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel_Table.TitleStyle.ForeColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.expandablePanel_Table.TitleStyle.GradientAngle = 90;
            this.expandablePanel_Table.TitleText = "???????? ??????????????????";
            this.expandablePanel_Table.Click += new System.EventHandler(this.expandablePanel_Table_Click);
            // 
            // panel_ButSave
            // 
            this.panel_ButSave.BackColor = System.Drawing.Color.Transparent;
            this.panel_ButSave.Controls.Add(this.ButOk);
            this.panel_ButSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_ButSave.Location = new System.Drawing.Point(0, 26);
            this.panel_ButSave.Name = "panel_ButSave";
            this.panel_ButSave.Size = new System.Drawing.Size(133, 101);
            this.panel_ButSave.TabIndex = 5;
            this.panel_ButSave.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_ButSave_Paint);
            // 
            // checkBox_ByName
            // 
            this.checkBox_ByName.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBox_ByName.CheckSignSize = new System.Drawing.Size(20, 20);
            this.checkBox_ByName.Name = "checkBox_ByName";
            this.checkBox_ByName.Text = "?????? ????????????";
            this.checkBox_ByName.Visible = false;
            // 
            // checkBox_ByMobile
            // 
            this.checkBox_ByMobile.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.checkBox_ByMobile.Checked = true;
            this.checkBox_ByMobile.CheckSignSize = new System.Drawing.Size(20, 20);
            this.checkBox_ByMobile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_ByMobile.Name = "checkBox_ByMobile";
            this.checkBox_ByMobile.Text = "???????? ????????????";
            this.checkBox_ByMobile.Visible = false;
            this.checkBox_ByMobile.Click += new System.EventHandler(this.checkBox_ByMobile_Click);
            // 
            // labelItem_Mobile
            // 
            this.labelItem_Mobile.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItem_Mobile.Name = "labelItem_Mobile";
            this.labelItem_Mobile.Text = "???????? ???????????? :";
            this.labelItem_Mobile.Visible = false;
            this.labelItem_Mobile.Click += new System.EventHandler(this.labelItem_Mobile_Click);
            // 
            // labelItem2
            // 
            this.labelItem2.Name = "labelItem2";
            this.labelItem2.Text = "        ?????? ????";
            this.labelItem2.Click += new System.EventHandler(this.labelItem2_Click);
            // 
            // superTabItem_Customer
            // 
            this.superTabItem_Customer.AttachedControl = this.superTabControlPanel1;
            this.superTabItem_Customer.GlobalItem = false;
            this.superTabItem_Customer.Name = "superTabItem_Customer";
            this.superTabItem_Customer.Text = "????????????????????????????";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.metroTilePanel_Customer);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 61);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(903, 399);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.superTabItem_Customer;
            this.superTabControlPanel1.Text = ".";
            this.superTabControlPanel1.Click += new System.EventHandler(this.superTabControlPanel1_Click);
            // 
            // metroTilePanel_Customer
            // 
            this.metroTilePanel_Customer.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.metroTilePanel_Customer.BackgroundStyle.Class = "RibbonFileMenuTwoColumnContainer";
            this.metroTilePanel_Customer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTilePanel_Customer.ContainerControlProcessDialogKey = true;
            this.metroTilePanel_Customer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTilePanel_Customer.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Right;
            this.metroTilePanel_Customer.ImageSize = DevComponents.DotNetBar.eBarImageSize.Medium;
            this.metroTilePanel_Customer.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer_Customer});
            this.metroTilePanel_Customer.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.metroTilePanel_Customer.Tag= "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.metroTilePanel_Customer.Location = new System.Drawing.Point(0, 0);
            this.metroTilePanel_Customer.MultiLine = true;
            this.metroTilePanel_Customer.Name = "metroTilePanel_Customer";
            this.metroTilePanel_Customer.Size = new System.Drawing.Size(903, 399);
            this.metroTilePanel_Customer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.metroTilePanel_Customer.TabIndex = 1132;
            this.metroTilePanel_Customer.ItemClick += new System.EventHandler(this.metroTilePanel_Customer_ItemClick);
            // 
            // itemContainer_Customer
            // 
            this.itemContainer_Customer.AccessibleRole = System.Windows.Forms.AccessibleRole.ListItem;
            // 
            // 
            // 
            this.itemContainer_Customer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer_Customer.MultiLine = true;
            this.itemContainer_Customer.Name = "itemContainer_Customer";
            // 
            // 
            // 
            this.itemContainer_Customer.TitleStyle.BackColor = System.Drawing.Color.AliceBlue;
            this.itemContainer_Customer.TitleStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemContainer_Customer.TitleStyle.BorderBottomWidth = 1;
            this.itemContainer_Customer.TitleStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.itemContainer_Customer.TitleStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemContainer_Customer.TitleStyle.BorderLeftWidth = 1;
            this.itemContainer_Customer.TitleStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemContainer_Customer.TitleStyle.BorderRightWidth = 1;
            this.itemContainer_Customer.TitleStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.itemContainer_Customer.TitleStyle.BorderTopWidth = 1;
            this.itemContainer_Customer.TitleStyle.Class = "MetroTileGroupTitle";
            this.itemContainer_Customer.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer_Customer.TitleStyle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.itemContainer_Customer.TitleStyle.MarginBottom = 5;
            this.itemContainer_Customer.TitleStyle.MarginLeft = 5;
            this.itemContainer_Customer.TitleStyle.MarginRight = 5;
            this.itemContainer_Customer.TitleStyle.MarginTop = 5;
            this.itemContainer_Customer.TitleStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.itemContainer_Customer.TitleStyle.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.itemContainer_Customer.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // superTabControl_Tables
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl_Tables.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl_Tables.ControlBox.MenuBox.Name = "";
            this.superTabControl_Tables.ControlBox.Name = "";
            this.superTabControl_Tables.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl_Tables.ControlBox.MenuBox,
            this.superTabControl_Tables.ControlBox.CloseBox});
            this.superTabControl_Tables.ControlBox.Visible = false;
            this.superTabControl_Tables.Controls.Add(this.superTabControlPanel1);
            this.superTabControl_Tables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl_Tables.Location = new System.Drawing.Point(0, 0);
            this.superTabControl_Tables.Name = "superTabControl_Tables";
            this.superTabControl_Tables.ReorderTabsEnabled = true;
            this.superTabControl_Tables.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_Tables.SelectedTabIndex = 0;
            this.superTabControl_Tables.Size = new System.Drawing.Size(903, 460);
            this.superTabControl_Tables.TabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.superTabControl_Tables.TabIndex = 977;
            this.superTabControl_Tables.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem_Customer,
            this.labelItem2,
            this.labelItem_Mobile,
            this.txtSearchMobile,
            this.checkBox_ByMobile,
            this.checkBox_ByName});
            this.superTabControl_Tables.TabVerticalSpacing = 22;
            this.superTabControl_Tables.SelectedTabChanged += new System.EventHandler<DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs>(this.superTabControl_Tables_SelectedTabChanged);
            // 
            // txtSearchMobile
            // 
            this.txtSearchMobile.ButtonCustom.Text = "????????????????";
            this.txtSearchMobile.ButtonCustom.Visible = true;
            this.txtSearchMobile.ButtonCustom2.Text = "??????????????";
            this.txtSearchMobile.ButtonCustom2.Visible = true;
            this.txtSearchMobile.FocusHighlightEnabled = true;
            this.txtSearchMobile.Name = "txtSearchMobile";
            this.txtSearchMobile.Stretch = true;
            this.txtSearchMobile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearchMobile.TextBoxHeight = 45;
            this.txtSearchMobile.TextBoxWidth = 300;
            this.txtSearchMobile.Visible = false;
            this.txtSearchMobile.WatermarkColor = System.Drawing.SystemColors.GrayText;
            this.txtSearchMobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchMobile_KeyPress);
            this.txtSearchMobile.ButtonCustomClick += new System.EventHandler(this.txtSearchMobile_ButtonCustomClick);
            this.txtSearchMobile.ButtonCustom2Click += new System.EventHandler(this.txtSearchMobile_ButtonCustom2Click);
            this.txtSearchMobile.VisibleChanged += new System.EventHandler(this.txtSearchMobile_VisibleChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // ToolStripMenuItem_Rep
            // 
            this.ToolStripMenuItem_Rep.Checked = true;
            this.ToolStripMenuItem_Rep.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToolStripMenuItem_Rep.Name = "ToolStripMenuItem_Rep";
            this.ToolStripMenuItem_Rep.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem_Rep.Text = "?????????? ??????????????";
            this.ToolStripMenuItem_Rep.Click += new System.EventHandler(this.ToolStripMenuItem_Rep_Click);
            // 
            // ToolStripMenuItem_Det
            // 
            this.ToolStripMenuItem_Det.Name = "ToolStripMenuItem_Det";
            this.ToolStripMenuItem_Det.Size = new System.Drawing.Size(148, 22);
            this.ToolStripMenuItem_Det.Text = "?????????? ????????????????";
            this.ToolStripMenuItem_Det.Click += new System.EventHandler(this.ToolStripMenuItem_Det_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Det,
            this.ToolStripMenuItem_Rep});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip2.Size = new System.Drawing.Size(149, 48);
            this.contextMenuStrip2.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip2_Opening);
            // 
            // OrderPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.expandablePanel_Table);
            this.Controls.Add(this.superTabControl_Tables);
            this.Name = "OrderPanel";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(903, 460);
            this.expandablePanel_Table.ResumeLayout(false);
            this.panel_ButSave.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl_Tables)).EndInit();
            this.superTabControl_Tables.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
         //   this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX ButOk;
        private DevComponents.DotNetBar.LabelItem labelItem_SumTable;
        private DevComponents.DotNetBar.ItemPanel itemPanel2;
        private DevComponents.DotNetBar.LabelItem labelItem_Type;
        private DevComponents.DotNetBar.LabelItem labelItem_Nadel;
        private DevComponents.DotNetBar.LabelItem labelItem_Time;
        private DevComponents.DotNetBar.LabelItem labelItem_Note;
        private DevComponents.DotNetBar.LabelItem labelItem_Tables;
        private DevComponents.DotNetBar.ItemPanel itemPanel1;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel_Table;
        private System.Windows.Forms.Panel panel_ButSave;
        private DevComponents.DotNetBar.CheckBoxItem checkBox_ByName;
        private DevComponents.DotNetBar.CheckBoxItem checkBox_ByMobile;
        private DevComponents.DotNetBar.LabelItem labelItem_Mobile;
        private DevComponents.DotNetBar.LabelItem labelItem2;
        private DevComponents.DotNetBar.SuperTabItem superTabItem_Customer;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.Metro.MetroTilePanel metroTilePanel_Customer;
        private DevComponents.DotNetBar.ItemContainer itemContainer_Customer;
        private DevComponents.DotNetBar.SuperTabControl superTabControl_Tables;
        private DevComponents.DotNetBar.TextBoxItem txtSearchMobile;
        protected System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        protected System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Rep;
        protected System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Det;
        protected System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
    }
}
