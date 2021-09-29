   

namespace InvAcc.Forms
{
partial class FrmRoomDigram
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmRoomDigram));
            SuperGrid_RoomDiagram = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            superTabControl_Main1 = new DevComponents.DotNetBar.SuperTabControl();
            Button_Close = new DevComponents.DotNetBar.ButtonItem();
            Button_Save = new DevComponents.DotNetBar.ButtonItem();
            ((System.ComponentModel.ISupportInitialize)superTabControl_Main1).BeginInit();
            SuspendLayout();
            SuperGrid_RoomDiagram.Dock = System.Windows.Forms.DockStyle.Fill;
            SuperGrid_RoomDiagram.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            SuperGrid_RoomDiagram.Tag= "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            SuperGrid_RoomDiagram.Location = new System.Drawing.Point(0, 0);
            SuperGrid_RoomDiagram.Name = "SuperGrid_RoomDiagram";
            SuperGrid_RoomDiagram.PrimaryGrid.ColumnHeader.Visible = false;
            SuperGrid_RoomDiagram.PrimaryGrid.DefaultVisualStyles.AlternateColumnCellStyles.Default.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            SuperGrid_RoomDiagram.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            SuperGrid_RoomDiagram.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            SuperGrid_RoomDiagram.PrimaryGrid.DefaultVisualStyles.ColumnHeaderRowStyles.Default.RowHeader.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            SuperGrid_RoomDiagram.PrimaryGrid.DefaultVisualStyles.RowStyles.Default.RowHeaderStyle.Font = new System.Drawing.Font("Tahoma", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            SuperGrid_RoomDiagram.PrimaryGrid.DefaultVisualStyles.RowStyles.Default.RowHeaderStyle.TextColor = System.Drawing.Color.FromArgb(192, 0, 0);
            SuperGrid_RoomDiagram.PrimaryGrid.InitialActiveRow = DevComponents.DotNetBar.SuperGrid.RelativeRow.None;
            SuperGrid_RoomDiagram.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.None;
            SuperGrid_RoomDiagram.PrimaryGrid.MaxRowHeight = 1000;
            SuperGrid_RoomDiagram.PrimaryGrid.MinRowHeight = 50;
            SuperGrid_RoomDiagram.PrimaryGrid.MultiSelect = false;
            SuperGrid_RoomDiagram.PrimaryGrid.RowHeaderWidth = 100;
            SuperGrid_RoomDiagram.PrimaryGrid.ShowColumnHeader = false;
            SuperGrid_RoomDiagram.Size = new System.Drawing.Size(709, 409);
            SuperGrid_RoomDiagram.TabIndex = 1197;
            superTabControl_Main1.BackColor = System.Drawing.Color.White;
            superTabControl_Main1.CausesValidation = false;
            superTabControl_Main1.ControlBox.CloseBox.Name = string.Empty;
            superTabControl_Main1.ControlBox.MenuBox.Name = string.Empty;
            superTabControl_Main1.ControlBox.Name = string.Empty;
            superTabControl_Main1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[2]
            {
                superTabControl_Main1.ControlBox.MenuBox,
                superTabControl_Main1.ControlBox.CloseBox
            });
            superTabControl_Main1.ControlBox.Visible = false;
            superTabControl_Main1.Dock = System.Windows.Forms.DockStyle.Bottom;
            superTabControl_Main1.ForeColor = System.Drawing.Color.Black;
            superTabControl_Main1.ItemPadding.Bottom = 4;
            superTabControl_Main1.ItemPadding.Left = 2;
            superTabControl_Main1.ItemPadding.Top = 4;
            superTabControl_Main1.Location = new System.Drawing.Point(0, 409);
            superTabControl_Main1.Name = "superTabControl_Main1";
            superTabControl_Main1.ReorderTabsEnabled = true;
            superTabControl_Main1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            superTabControl_Main1.SelectedTabFont = new System.Drawing.Font("Tahoma", 8f, System.Drawing.FontStyle.Bold);
            superTabControl_Main1.SelectedTabIndex = -1;
            superTabControl_Main1.Size = new System.Drawing.Size(709, 51);
            superTabControl_Main1.TabFont = new System.Drawing.Font("Tahoma", 8f);
            superTabControl_Main1.TabIndex = 1198;
            superTabControl_Main1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[2]
            {
                Button_Close,
                Button_Save
            });
            superTabControl_Main1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.WinMediaPlayer12;
            superTabControl_Main1.Text = "superTabControl3";
            superTabControl_Main1.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
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
            Button_Close.Text = "إغلاق";
            Button_Close.Tooltip = "إغلاق النافذة الحالية";
            Button_Close.Click += new System.EventHandler(Button_Close_Click);
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
            Button_Save.Text = "حفظ";
            Button_Save.Tooltip = "حفظ التغييرات";
            Button_Save.Click += new System.EventHandler(Button_Save_Click);
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            base.ClientSize = new System.Drawing.Size(709, 460);
            base.ControlBox = false;
            base.Controls.Add(SuperGrid_RoomDiagram);
            base.Controls.Add(superTabControl_Main1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            base.KeyPreview = true;
            base.Name = "FrmRoomDigram";
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            RightToLeftLayout = true;
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            base.Load += new System.EventHandler(FrmRoomDigram_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(Frm_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(Frm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)superTabControl_Main1).EndInit();
            ResumeLayout(false);
        }//###########&&&&&&&&&&

}
}
