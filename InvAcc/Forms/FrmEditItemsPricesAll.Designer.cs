   

namespace InvAcc.Forms
{
partial class FrmEditItemsPricesAll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmEditItemsPricesAll));
            FlxItems = new C1.Win.C1FlexGrid.C1FlexGrid();
            ButExit = new DevComponents.DotNetBar.ButtonX();
            ButOk = new DevComponents.DotNetBar.ButtonX();
            panel1 = new System.Windows.Forms.Panel();
            button_Search = new DevComponents.DotNetBar.ButtonX();
            txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            groupBox1 = new System.Windows.Forms.GroupBox();
            radBarcode5 = new System.Windows.Forms.RadioButton();
            radBarcode4 = new System.Windows.Forms.RadioButton();
            radBarcode3 = new System.Windows.Forms.RadioButton();
            radBarcode2 = new System.Windows.Forms.RadioButton();
            radBarcode1 = new System.Windows.Forms.RadioButton();
            radItmNo = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)FlxItems).BeginInit();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            FlxItems.AccessibleDescription = null;
            FlxItems.AccessibleName = null;
            FlxItems.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            FlxItems.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            resources.ApplyResources(FlxItems, "FlxItems");
            FlxItems.BackgroundImage = null;
            FlxItems.ExtendLastCol = true;
            FlxItems.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None;
            FlxItems.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
            FlxItems.Name = "FlxItems";
            FlxItems.Rows.Count = 13;
            FlxItems.Rows.DefaultSize = 19;
            FlxItems.ShowSortPosition = C1.Win.C1FlexGrid.ShowSortPositionEnum.None;
            FlxItems.StyleInfo = resources.GetString("FlxItems.StyleInfo");
            FlxItems.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.System;
            FlxItems.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(FlxItems_BeforeEdit);
            FlxItems.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(FlxItems_AfterEdit);
            ButExit.AccessibleDescription = null;
            ButExit.AccessibleName = null;
            ButExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(ButExit, "ButExit");
            ButExit.BackgroundImage = null;
            ButExit.Checked = true;
            ButExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            ButExit.CommandParameter = null;
            ButExit.Image = (System.Drawing.Image)resources.GetObject("ButExit.Image");
            ButExit.Name = "ButExit";
            ButExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButExit.Symbol = "\uf011";
            ButExit.SymbolSize = 16f;
            ButExit.TextColor = System.Drawing.Color.Black;
            ButExit.Click += new System.EventHandler(ButExit_Click);
            ButOk.AccessibleDescription = null;
            ButOk.AccessibleName = null;
            ButOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(ButOk, "ButOk");
            ButOk.BackgroundImage = null;
            ButOk.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            ButOk.CommandParameter = null;
            ButOk.Image = (System.Drawing.Image)resources.GetObject("ButOk.Image");
            ButOk.Name = "ButOk";
            ButOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButOk.Symbol = "\uf00c";
            ButOk.SymbolSize = 16f;
            ButOk.TextColor = System.Drawing.Color.White;
            ButOk.Click += new System.EventHandler(ButOk_Click);
            panel1.AccessibleDescription = null;
            panel1.AccessibleName = null;
            resources.ApplyResources(panel1, "panel1");
            panel1.BackgroundImage = null;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(button_Search);
            panel1.Controls.Add(txtSearch);
            panel1.Font = null;
            panel1.Name = "panel1";
            button_Search.AccessibleDescription = null;
            button_Search.AccessibleName = null;
            button_Search.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(button_Search, "button_Search");
            button_Search.BackgroundImage = null;
            button_Search.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            button_Search.CommandParameter = null;
            button_Search.Image = (System.Drawing.Image)resources.GetObject("button_Search.Image");
            button_Search.Name = "button_Search";
            button_Search.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            button_Search.Symbol = "\uf002";
            button_Search.SymbolSize = 16f;
            button_Search.TextColor = System.Drawing.Color.Black;
            button_Search.Click += new System.EventHandler(button_Search_Click);
            txtSearch.AccessibleDescription = null;
            txtSearch.AccessibleName = null;
            resources.ApplyResources(txtSearch, "txtSearch");
            txtSearch.BackgroundImage = null;
            txtSearch.Border.Class = "TextBoxBorder";
            txtSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            txtSearch.ButtonCustom.DisplayPosition = (int)resources.GetObject("txtSearch.ButtonCustom.DisplayPosition");
            txtSearch.ButtonCustom.Image = (System.Drawing.Image)resources.GetObject("txtSearch.ButtonCustom.Image");
            txtSearch.ButtonCustom.Text = resources.GetString("txtSearch.ButtonCustom.Text");
            txtSearch.ButtonCustom2.DisplayPosition = (int)resources.GetObject("txtSearch.ButtonCustom2.DisplayPosition");
            txtSearch.ButtonCustom2.Image = null;
            txtSearch.ButtonCustom2.Text = resources.GetString("txtSearch.ButtonCustom2.Text");
            txtSearch.Name = "txtSearch";
            groupBox1.AccessibleDescription = null;
            groupBox1.AccessibleName = null;
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.BackgroundImage = null;
            groupBox1.Controls.Add(radBarcode5);
            groupBox1.Controls.Add(radBarcode4);
            groupBox1.Controls.Add(radBarcode3);
            groupBox1.Controls.Add(radBarcode2);
            groupBox1.Controls.Add(radBarcode1);
            groupBox1.Controls.Add(radItmNo);
            groupBox1.Font = null;
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            radBarcode5.AccessibleDescription = null;
            radBarcode5.AccessibleName = null;
            resources.ApplyResources(radBarcode5, "radBarcode5");
            radBarcode5.BackgroundImage = null;
            radBarcode5.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            radBarcode5.Name = "radBarcode5";
            radBarcode5.UseVisualStyleBackColor = true;
            radBarcode4.AccessibleDescription = null;
            radBarcode4.AccessibleName = null;
            resources.ApplyResources(radBarcode4, "radBarcode4");
            radBarcode4.BackgroundImage = null;
            radBarcode4.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            radBarcode4.Name = "radBarcode4";
            radBarcode4.UseVisualStyleBackColor = true;
            radBarcode3.AccessibleDescription = null;
            radBarcode3.AccessibleName = null;
            resources.ApplyResources(radBarcode3, "radBarcode3");
            radBarcode3.BackgroundImage = null;
            radBarcode3.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            radBarcode3.Name = "radBarcode3";
            radBarcode3.UseVisualStyleBackColor = true;
            radBarcode2.AccessibleDescription = null;
            radBarcode2.AccessibleName = null;
            resources.ApplyResources(radBarcode2, "radBarcode2");
            radBarcode2.BackgroundImage = null;
            radBarcode2.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            radBarcode2.Name = "radBarcode2";
            radBarcode2.UseVisualStyleBackColor = true;
            radBarcode1.AccessibleDescription = null;
            radBarcode1.AccessibleName = null;
            resources.ApplyResources(radBarcode1, "radBarcode1");
            radBarcode1.BackgroundImage = null;
            radBarcode1.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            radBarcode1.Name = "radBarcode1";
            radBarcode1.UseVisualStyleBackColor = true;
            radItmNo.AccessibleDescription = null;
            radItmNo.AccessibleName = null;
            resources.ApplyResources(radItmNo, "radItmNo");
            radItmNo.BackgroundImage = null;
            radItmNo.Checked = true;
            radItmNo.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            radItmNo.Name = "radItmNo";
            radItmNo.TabStop = true;
            radItmNo.UseVisualStyleBackColor = true;
            base.AccessibleDescription = null;
            base.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            BackgroundImage = null;
            base.Controls.Add(panel1);
            base.Controls.Add(ButExit);
            base.Controls.Add(ButOk);
            base.Controls.Add(FlxItems);
            base.Controls.Add(groupBox1);
            Font = null;
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "FrmEditItemsPricesAll";
            base.Load += new System.EventHandler(FrmEditItemsPricesAll_Load);
            base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(FrmEditItemsPricesAll_KeyPress);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmEditItemsPricesAll_KeyDown);
            ((System.ComponentModel.ISupportInitialize)FlxItems).EndInit();
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }//###########&&&&&&&&&&

}
}
