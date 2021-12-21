namespace InvAcc.Forms.Eqr_Version.New
{
    partial class BaseForm
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
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ubar1 = new InvAcc.Controls.Ubar();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(641, 348);
            this.dataLayoutControl1.TabIndex = 13;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(641, 348);
            this.Root.TextVisible = false;
            // 
            // ubar1
            // 
            this.ubar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ubar1.Location = new System.Drawing.Point(0, 348);
            this.ubar1.Name = "ubar1";
            this.ubar1.Size = new System.Drawing.Size(641, 58);
            this.ubar1.State = ProShared.GeneralM.FormState.Saved;
            this.ubar1.TabIndex = 12;
            this.ubar1.Button_Save_Click += new InvAcc.Controls.Ubar.customMessageHandler(this.ubar1_Button_Save_Click);
            this.ubar1.Button_Delete_Click += new InvAcc.Controls.Ubar.customMessageHandler(this.ubar1_Button_Delete_Click);
            this.ubar1.Button_Close_Click += new InvAcc.Controls.Ubar.customMessageHandler(this.ubar1_Button_Close_Click);
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 406);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.ubar1);
            this.Name = "BaseForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "BaseForm";
            this.Load += new System.EventHandler(this.BaseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public Controls.Ubar ubar1;
        public DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        public DevExpress.XtraLayout.LayoutControlGroup Root;
    }
}