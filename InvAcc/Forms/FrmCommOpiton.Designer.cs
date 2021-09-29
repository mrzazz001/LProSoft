   

namespace InvAcc.Forms
{
partial class FrmCommOpiton
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCommOpiton));
            this.c1FlexGrid1Bankopp = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.ButWithoutSave = new DevComponents.DotNetBar.ButtonX();
            this.ButWithSave = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1Bankopp)).BeginInit();
            this.SuspendLayout();
            // 
            // c1FlexGrid1Bankopp
            // 
            this.c1FlexGrid1Bankopp.ColumnInfo = resources.GetString("c1FlexGrid1Bankopp.ColumnInfo");
            this.c1FlexGrid1Bankopp.Dock = System.Windows.Forms.DockStyle.Top;
            this.c1FlexGrid1Bankopp.Font = new System.Drawing.Font("Tahoma", 8F);
            this.c1FlexGrid1Bankopp.Location = new System.Drawing.Point(0, 0);
            this.c1FlexGrid1Bankopp.Name = "c1FlexGrid1Bankopp";
            this.c1FlexGrid1Bankopp.Rows.Count = 15;
            this.c1FlexGrid1Bankopp.Rows.DefaultSize = 19;
            this.c1FlexGrid1Bankopp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.c1FlexGrid1Bankopp.Size = new System.Drawing.Size(542, 168);
            this.c1FlexGrid1Bankopp.StyleInfo = resources.GetString("c1FlexGrid1Bankopp.StyleInfo");
            this.c1FlexGrid1Bankopp.TabIndex = 22;
            this.c1FlexGrid1Bankopp.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Black;
            this.c1FlexGrid1Bankopp.CellChecked += new C1.Win.C1FlexGrid.RowColEventHandler(this.c1FlexGrid1_CellChecked);
            this.c1FlexGrid1Bankopp.Click += new System.EventHandler(this.c1FlexGrid1Bankopp_Click);
            this.c1FlexGrid1Bankopp.DoubleClick += new System.EventHandler(this.c1FlexGrid1_DoubleClick);
            // 
            // ButWithoutSave
            // 
            this.ButWithoutSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButWithoutSave.Checked = true;
            this.ButWithoutSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ButWithoutSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButWithoutSave.Location = new System.Drawing.Point(2, 171);
            this.ButWithoutSave.Name = "ButWithoutSave";
            this.ButWithoutSave.Size = new System.Drawing.Size(268, 48);
            this.ButWithoutSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButWithoutSave.Symbol = "";
            this.ButWithoutSave.SymbolSize = 16F;
            this.ButWithoutSave.TabIndex = 6785;
            this.ButWithoutSave.Text = "خـــروج";
            this.ButWithoutSave.TextColor = System.Drawing.Color.Black;
            this.ButWithoutSave.Click += new System.EventHandler(this.ButExit_Click);
            // 
            // ButWithSave
            // 
            this.ButWithSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButWithSave.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.ButWithSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButWithSave.Location = new System.Drawing.Point(274, 171);
            this.ButWithSave.Name = "ButWithSave";
            this.ButWithSave.Size = new System.Drawing.Size(268, 48);
            this.ButWithSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButWithSave.Symbol = "";
            this.ButWithSave.SymbolSize = 16F;
            this.ButWithSave.TabIndex = 6784;
            this.ButWithSave.Text = "حفــــظ";
            this.ButWithSave.TextColor = System.Drawing.Color.White;
            this.ButWithSave.Click += new System.EventHandler(this.ButWithSave_Click);
            // 
            // FrmCommOpiton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 221);
            this.ControlBox = false;
            this.Controls.Add(this.ButWithoutSave);
            this.Controls.Add(this.ButWithSave);
            this.Controls.Add(this.c1FlexGrid1Bankopp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.KeyPreview = true;
            this.Name = "FrmCommOpiton";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "خيارات العمولات البنكية";
            this.Load += new System.EventHandler(this.FrmCommOpiton_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCommOpiton_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmCommOpiton_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1Bankopp)).EndInit();
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.ResumeLayout(false);
        }//###########&&&&&&&&&&

}
}
