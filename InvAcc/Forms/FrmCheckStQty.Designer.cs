   

namespace InvAcc.Forms
{
partial class FrmCheckStQty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCheckStQty));
            components = new System.ComponentModel.Container();
            this.ButExit = new DevComponents.DotNetBar.ButtonX();
            this.ButShow = new DevComponents.DotNetBar.ButtonX();
            this.ButDel = new DevComponents.DotNetBar.ButtonX();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);  this.netResize1.LabelsAutoEllipse = false;
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.SuspendLayout();
            // 
            // ButExit
            // 
            this.ButExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButExit.Checked = true;
            this.ButExit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ButExit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButExit.Location = new System.Drawing.Point(10, 151);
            this.ButExit.Name = "ButExit";
            this.ButExit.Size = new System.Drawing.Size(218, 60);
            this.ButExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButExit.Symbol = "";
            this.ButExit.SymbolSize = 16F;
            this.ButExit.TabIndex = 6785;
            this.ButExit.Text = "خـــروج";
            this.ButExit.TextColor = System.Drawing.Color.Black;
            this.ButExit.Click += new System.EventHandler(this.ButExit_Click);
            // 
            // ButShow
            // 
            this.ButShow.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButShow.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.ButShow.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButShow.Location = new System.Drawing.Point(10, 11);
            this.ButShow.Name = "ButShow";
            this.ButShow.Size = new System.Drawing.Size(218, 60);
            this.ButShow.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButShow.Symbol = "";
            this.ButShow.SymbolSize = 16F;
            this.ButShow.TabIndex = 6784;
            this.ButShow.Text = "عــــرض";
            this.ButShow.TextColor = System.Drawing.Color.White;
            this.ButShow.Click += new System.EventHandler(this.ButShow_Click);
            // 
            // ButDel
            // 
            this.ButDel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButDel.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.ButDel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButDel.Location = new System.Drawing.Point(10, 81);
            this.ButDel.Name = "ButDel";
            this.ButDel.Size = new System.Drawing.Size(218, 60);
            this.ButDel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButDel.Symbol = "";
            this.ButDel.SymbolSize = 16F;
            this.ButDel.TabIndex = 6786;
            this.ButDel.Text = "حـــذف الأصناف";
            this.ButDel.TextColor = System.Drawing.Color.White;
            this.ButDel.Click += new System.EventHandler(this.ButDel_Click);
            // 
            // FrmCheckStQty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(238, 219);
            this.ControlBox = false;
            this.Controls.Add(this.ButDel);
            this.Controls.Add(this.ButExit);
            this.Controls.Add(this.ButShow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.Name = "FrmCheckStQty";
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الأصناف المعلقة في المستودعات";
            this.Load += new System.EventHandler(this.FrmCheckStQty_Load);
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.ResumeLayout(false);
        }//###########&&&&&&&&&&

}
}
