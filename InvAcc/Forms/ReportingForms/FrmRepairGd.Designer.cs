   

namespace InvAcc.Forms
{
partial class FrmRepairGd
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
            label10 = new System.Windows.Forms.Label();
            components = new System.ComponentModel.Container();

            CmbTyp = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            ButExit = new DevComponents.DotNetBar.ButtonX();
            ButOk = new DevComponents.DotNetBar.ButtonX();
            SuspendLayout();
            label10.AutoSize = true;
            label10.BackColor = System.Drawing.Color.Transparent;
            label10.Font = new System.Drawing.Font("Tahoma", 8f, System.Drawing.FontStyle.Bold);
            label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label10.Location = new System.Drawing.Point(298, 25);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(77, 13);
            label10.TabIndex = 1152;
            label10.Text = "نوع السنــــد :";
            CmbTyp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            CmbTyp.DisplayMember = "Text";
            CmbTyp.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            CmbTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CmbTyp.FormattingEnabled = true;
            CmbTyp.ItemHeight = 14;
            CmbTyp.Location = new System.Drawing.Point(65, 52);
            CmbTyp.Name = "CmbTyp";
            CmbTyp.Size = new System.Drawing.Size(307, 20);
            CmbTyp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            CmbTyp.TabIndex = 1151;
            ButExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            ButExit.Checked = true;
            ButExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            ButExit.Font = new System.Drawing.Font("Tahoma", 8f, System.Drawing.FontStyle.Bold);
            ButExit.Location = new System.Drawing.Point(12, 105);
            ButExit.Name = "ButExit";
            ButExit.Size = new System.Drawing.Size(193, 35);
            ButExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButExit.Symbol = "\uf011";
            ButExit.SymbolSize = 16f;
            ButExit.TabIndex = 1154;
            ButExit.Text = "خـــروج";
            ButExit.TextColor = System.Drawing.Color.Black;
            ButExit.Click += new System.EventHandler(ButExit_Click);
            ButOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            ButOk.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            ButOk.Font = new System.Drawing.Font("Tahoma", 8f, System.Drawing.FontStyle.Bold);
            ButOk.Location = new System.Drawing.Point(210, 105);
            ButOk.Name = "ButOk";
            ButOk.Size = new System.Drawing.Size(193, 35);
            ButOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            ButOk.Symbol = "\uf0c5";
            ButOk.SymbolSize = 16f;
            ButOk.TabIndex = 1153;
            ButOk.Text = "صيانة";
            ButOk.TextColor = System.Drawing.Color.White;
            ButOk.Click += new System.EventHandler(ButOk_Click);
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            base.ClientSize = new System.Drawing.Size(427, 161);
            base.ControlBox = false;
            base.Controls.Add(ButExit);
            base.Controls.Add(ButOk);
            base.Controls.Add(label10);
            base.Controls.Add(CmbTyp);
            base.KeyPreview = true;
            base.Name = "FrmRepairGd";
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            base.ShowIcon = false;
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "صيانة ارقام القيود";
            base.Load += new System.EventHandler(FrmRepairGd_Load);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmRepairGd_KeyDown);
            ResumeLayout(false);
            PerformLayout();
        }//###########&&&&&&&&&&

}
}
