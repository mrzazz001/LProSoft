namespace InvAcc.Forms
{
    partial class FrmPrinters
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.xPrinterSetting1 = new ProRealEstate.Utilties.xXPrinterSetting();
            this.t_PrintersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.t_PrintersBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.treeListBand1 = new DevExpress.XtraTreeList.Columns.TreeListBand();
            ((System.ComponentModel.ISupportInitialize)(this.t_PrintersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_PrintersBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // xPrinterSetting1
            // 
            this.xPrinterSetting1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPrinterSetting1.Location = new System.Drawing.Point(0, 0);
            this.xPrinterSetting1.Name = "xPrinterSetting1";
            this.xPrinterSetting1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.xPrinterSetting1.Size = new System.Drawing.Size(967, 586);
            this.xPrinterSetting1.TabIndex = 0;
            this.xPrinterSetting1.Load += new System.EventHandler(this.xPrinterSetting1_Load);
            // 
            // t_PrintersBindingSource
            // 
            this.t_PrintersBindingSource.DataSource = typeof(ProShared.Stock_Data.T_Printer);
            // 
            // t_PrintersBindingSource1
            // 
            this.t_PrintersBindingSource1.DataSource = typeof(ProShared.Stock_Data.T_Printer);
            // 
            // treeListBand1
            // 
            this.treeListBand1.Caption = "treeListBand1";
            this.treeListBand1.Name = "treeListBand1";
            // 
            // FrmPrinters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 586);
            this.Controls.Add(this.xPrinterSetting1);
            this.Name = "FrmPrinters";
            this.Text = "الطابعات";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.XtraForm1_FormClosing);
            this.Load += new System.EventHandler(this.XtraForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.t_PrintersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t_PrintersBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ProRealEstate.Utilties.xXPrinterSetting xPrinterSetting1;
        private System.Windows.Forms.BindingSource t_PrintersBindingSource;
        private System.Windows.Forms.BindingSource t_PrintersBindingSource1;
        private DevExpress.XtraTreeList.Columns.TreeListBand treeListBand1;
    }
}