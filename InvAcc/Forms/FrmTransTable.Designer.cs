   

namespace InvAcc.Forms
{
partial class FrmTransTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmTransTable));
            expandablePanel_TablesMove = new DevComponents.DotNetBar.ExpandablePanel();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            Button_Move = new DevComponents.DotNetBar.ButtonX();
            ButExit = new DevComponents.DotNetBar.ButtonX();
            comboBox_ToTable = new System.Windows.Forms.ComboBox();
            combobox_FromTable = new System.Windows.Forms.ComboBox();
            expandablePanel_TablesMove.SuspendLayout();
            SuspendLayout();
            expandablePanel_TablesMove.CanvasColor = System.Drawing.SystemColors.GradientActiveCaption;
            expandablePanel_TablesMove.Controls.Add(label1);
            expandablePanel_TablesMove.Controls.Add(label3);
            expandablePanel_TablesMove.Controls.Add(Button_Move);
            expandablePanel_TablesMove.Controls.Add(ButExit);
            expandablePanel_TablesMove.Controls.Add(comboBox_ToTable);
            expandablePanel_TablesMove.Controls.Add(combobox_FromTable);
            resources.ApplyResources(expandablePanel_TablesMove, "expandablePanel_TablesMove");
            expandablePanel_TablesMove.ExpandButtonVisible = false;
            expandablePanel_TablesMove.Name = "expandablePanel_TablesMove";
            expandablePanel_TablesMove.Style.Alignment = System.Drawing.StringAlignment.Center;
            expandablePanel_TablesMove.Style.BackColor1.Color = System.Drawing.Color.AliceBlue;
            expandablePanel_TablesMove.Style.BackColor2.Color = System.Drawing.SystemColors.GradientActiveCaption;
            expandablePanel_TablesMove.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            expandablePanel_TablesMove.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            expandablePanel_TablesMove.Style.GradientAngle = 90;
            expandablePanel_TablesMove.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            expandablePanel_TablesMove.TitleStyle.BackColor1.Color = System.Drawing.Color.FromArgb(255, 128, 0);
            expandablePanel_TablesMove.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            expandablePanel_TablesMove.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            expandablePanel_TablesMove.TitleStyle.ForeColor.Color = System.Drawing.Color.White;
            expandablePanel_TablesMove.TitleStyle.GradientAngle = 90;
            label1.BackColor = System.Drawing.Color.White;
            label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            label3.BackColor = System.Drawing.Color.White;
            label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            Button_Move.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            Button_Move.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            resources.ApplyResources(Button_Move, "Button_Move");
            Button_Move.Name = "Button_Move";
            Button_Move.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            Button_Move.Symbol = "\uf00c";
            Button_Move.SymbolSize = 16f;
            Button_Move.TextColor = System.Drawing.Color.White;
            Button_Move.Click += new System.EventHandler(Button_Move_Click);
            ButExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            ButExit.Checked = true;
            ButExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(ButExit, "ButExit");
            ButExit.Name = "ButExit";
            ButExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButExit.Symbol = "\uf011";
            ButExit.SymbolSize = 16f;
            ButExit.TextColor = System.Drawing.Color.Black;
            ButExit.Click += new System.EventHandler(ButExit_Click);
            comboBox_ToTable.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            comboBox_ToTable.BackColor = System.Drawing.Color.Gainsboro;
            comboBox_ToTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(comboBox_ToTable, "comboBox_ToTable");
            comboBox_ToTable.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            comboBox_ToTable.FormattingEnabled = true;
            comboBox_ToTable.Name = "comboBox_ToTable";
            combobox_FromTable.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            combobox_FromTable.BackColor = System.Drawing.Color.Gainsboro;
            combobox_FromTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(combobox_FromTable, "combobox_FromTable");
            combobox_FromTable.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            combobox_FromTable.FormattingEnabled = true;
            combobox_FromTable.Name = "combobox_FromTable";
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            base.Controls.Add(expandablePanel_TablesMove);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            base.KeyPreview = true;
            base.Name = "FrmTransTable";
            base.Load += new System.EventHandler(FrmTransTable_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(FrmTransTable_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmTransTable_KeyDown);
            expandablePanel_TablesMove.ResumeLayout(false);
            ResumeLayout(false);
        }//###########&&&&&&&&&&

}
}
