   

namespace InvAcc.Forms
{
partial class FrmRepairInvGaid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmRepairInvGaid));
            components = new System.ComponentModel.Container();

            CmbInvType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            ButExit = new DevComponents.DotNetBar.ButtonX();
            ButOk = new DevComponents.DotNetBar.ButtonX();
            label1 = new System.Windows.Forms.Label();
            SuspendLayout();
            CmbInvType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            CmbInvType.DisplayMember = "Text";
            CmbInvType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            CmbInvType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CmbInvType.Font = new System.Drawing.Font("Tahoma", 11f);
            CmbInvType.FormattingEnabled = true;
            CmbInvType.ItemHeight = 19;
            CmbInvType.Location = new System.Drawing.Point(7, 39);
            CmbInvType.Name = "CmbInvType";
            CmbInvType.Size = new System.Drawing.Size(375, 25);
            CmbInvType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            CmbInvType.TabIndex = 2;
            ButExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            ButExit.Checked = true;
            ButExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            ButExit.Font = new System.Drawing.Font("Tahoma", 8f, System.Drawing.FontStyle.Bold);
            ButExit.Location = new System.Drawing.Point(7, 71);
            ButExit.Name = "ButExit";
            ButExit.Size = new System.Drawing.Size(185, 44);
            ButExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButExit.Symbol = "\uf011";
            ButExit.SymbolSize = 16f;
            ButExit.TabIndex = 29;
            ButExit.Text = "خـــروج";
            ButExit.TextColor = System.Drawing.Color.Black;
            ButExit.Click += new System.EventHandler(ButExit_Click);
            ButOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            ButOk.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            ButOk.Font = new System.Drawing.Font("Tahoma", 8f, System.Drawing.FontStyle.Bold);
            ButOk.Location = new System.Drawing.Point(197, 71);
            ButOk.Name = "ButOk";
            ButOk.Size = new System.Drawing.Size(185, 44);
            ButOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButOk.Symbol = "\uf0c5";
            ButOk.SymbolSize = 16f;
            ButOk.TabIndex = 28;
            ButOk.Text = "مـــوافــــق";
            ButOk.TextColor = System.Drawing.Color.White;
            ButOk.Click += new System.EventHandler(ButOk_Click);
            label1.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            label1.Font = new System.Drawing.Font("Tahoma", 8f, System.Drawing.FontStyle.Bold);
            label1.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
            label1.Location = new System.Drawing.Point(7, 10);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(375, 22);
            label1.TabIndex = 30;
            label1.Text = "نــــــوع الفـــاتــورة";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            base.ClientSize = new System.Drawing.Size(389, 123);
            base.ControlBox = false;
            base.Controls.Add(label1);
            base.Controls.Add(ButExit);
            base.Controls.Add(ButOk);
            base.Controls.Add(CmbInvType);
            base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FrmRepairInvGaid";
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            base.ShowIcon = false;
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "صيانة القيد المحاسبي للفواتير حسب النوع";
            base.Load += new System.EventHandler(FrmRepairInvGaid_Load);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmRepairInvGaid_KeyDown);
            ResumeLayout(false);
        }//###########&&&&&&&&&&

}
}
