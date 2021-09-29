   

namespace InvAcc.Forms
{
partial class FrmTaxOpiton
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTaxOpiton));
            this.c1FlexGriadTax = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.ButWithoutSave = new DevComponents.DotNetBar.ButtonX();
            this.ButWithSave = new DevComponents.DotNetBar.ButtonX();
            this.label30Tax = new System.Windows.Forms.Label();
            this.txtSalesTax = new DevComponents.Editors.DoubleInput();
            this.label1Tax = new System.Windows.Forms.Label();
            this.ButGeneralSalesTax = new System.Windows.Forms.Button();
            this.ButGeneralPurchaesTax = new System.Windows.Forms.Button();
            this.label2Tax = new System.Windows.Forms.Label();
            this.label3Tax = new System.Windows.Forms.Label();
            this.txtPurchaesTax = new DevComponents.Editors.DoubleInput();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTaxID = new System.Windows.Forms.TextBox();
            this.button_SrchTaxNo = new DevComponents.DotNetBar.ButtonX();
            this.txtTaxNo = new System.Windows.Forms.TextBox();
            this.txtTaxName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label4Tax = new System.Windows.Forms.Label();
            this.txtTaxNote = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGriadTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesTax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurchaesTax)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // c1FlexGriadTax
            // 
            this.c1FlexGriadTax.ColumnInfo = resources.GetString("c1FlexGriadTax.ColumnInfo");
            this.c1FlexGriadTax.Font = new System.Drawing.Font("Tahoma", 8F);
            this.c1FlexGriadTax.Location = new System.Drawing.Point(338, 0);
            this.c1FlexGriadTax.Name = "c1FlexGriadTax";
            this.c1FlexGriadTax.Rows.Count = 15;
            this.c1FlexGriadTax.Rows.DefaultSize = 19;
            this.c1FlexGriadTax.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.c1FlexGriadTax.Size = new System.Drawing.Size(683, 271);
            this.c1FlexGriadTax.StyleInfo = resources.GetString("c1FlexGriadTax.StyleInfo");
            this.c1FlexGriadTax.TabIndex = 22;
            this.c1FlexGriadTax.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Black;
            this.c1FlexGriadTax.CellChecked += new C1.Win.C1FlexGrid.RowColEventHandler(this.c1FlexGrid1_CellChecked);
            this.c1FlexGriadTax.Click += new System.EventHandler(this.c1FlexGrid1_Click);
            this.c1FlexGriadTax.DoubleClick += new System.EventHandler(this.c1FlexGrid1_DoubleClick);
            // 
            // ButWithoutSave
            // 
            this.ButWithoutSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.ButWithoutSave.Checked = true;
            this.ButWithoutSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.ButWithoutSave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButWithoutSave.Location = new System.Drawing.Point(2, 375);
            this.ButWithoutSave.Name = "ButWithoutSave";
            this.ButWithoutSave.Size = new System.Drawing.Size(506, 48);
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
            this.ButWithSave.Location = new System.Drawing.Point(512, 375);
            this.ButWithSave.Name = "ButWithSave";
            this.ButWithSave.Size = new System.Drawing.Size(507, 48);
            this.ButWithSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ButWithSave.Symbol = "";
            this.ButWithSave.SymbolSize = 16F;
            this.ButWithSave.TabIndex = 6784;
            this.ButWithSave.Text = "حفــــظ";
            this.ButWithSave.TextColor = System.Drawing.Color.White;
            this.ButWithSave.Click += new System.EventHandler(this.ButWithSave_Click);
            // 
            // label30Tax
            // 
            this.label30Tax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label30Tax.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label30Tax.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label30Tax.Location = new System.Drawing.Point(888, 273);
            this.label30Tax.Name = "label30Tax";
            this.label30Tax.Size = new System.Drawing.Size(128, 22);
            this.label30Tax.TabIndex = 6788;
            this.label30Tax.Text = "ضريبة المبيعات";
            this.label30Tax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSalesTax
            // 
            this.txtSalesTax.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtSalesTax.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtSalesTax.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtSalesTax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSalesTax.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtSalesTax.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtSalesTax.Increment = 1D;
            this.txtSalesTax.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtSalesTax.Location = new System.Drawing.Point(827, 273);
            this.txtSalesTax.MinValue = 0D;
            this.txtSalesTax.Name = "txtSalesTax";
            this.txtSalesTax.Size = new System.Drawing.Size(58, 22);
            this.txtSalesTax.TabIndex = 6789;
            this.txtSalesTax.Click += new System.EventHandler(this.txtSalesTax_Click);
            // 
            // label1Tax
            // 
            this.label1Tax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1Tax.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1Tax.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1Tax.Location = new System.Drawing.Point(797, 273);
            this.label1Tax.Name = "label1Tax";
            this.label1Tax.Size = new System.Drawing.Size(28, 22);
            this.label1Tax.TabIndex = 6790;
            this.label1Tax.Text = "%";
            this.label1Tax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ButGeneralSalesTax
            // 
            this.ButGeneralSalesTax.BackColor = System.Drawing.Color.Transparent;
            this.ButGeneralSalesTax.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButGeneralSalesTax.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.ButGeneralSalesTax.ForeColor = System.Drawing.Color.Maroon;
            this.ButGeneralSalesTax.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ButGeneralSalesTax.Location = new System.Drawing.Point(686, 273);
            this.ButGeneralSalesTax.Name = "ButGeneralSalesTax";
            this.ButGeneralSalesTax.Size = new System.Drawing.Size(109, 22);
            this.ButGeneralSalesTax.TabIndex = 6791;
            this.ButGeneralSalesTax.Text = "تعميم";
            this.ButGeneralSalesTax.UseVisualStyleBackColor = false;
            this.ButGeneralSalesTax.Click += new System.EventHandler(this.ButGeneralSalesTax_Click);
            // 
            // ButGeneralPurchaesTax
            // 
            this.ButGeneralPurchaesTax.BackColor = System.Drawing.Color.Transparent;
            this.ButGeneralPurchaesTax.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButGeneralPurchaesTax.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.ButGeneralPurchaesTax.ForeColor = System.Drawing.Color.Maroon;
            this.ButGeneralPurchaesTax.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ButGeneralPurchaesTax.Location = new System.Drawing.Point(338, 273);
            this.ButGeneralPurchaesTax.Name = "ButGeneralPurchaesTax";
            this.ButGeneralPurchaesTax.Size = new System.Drawing.Size(109, 22);
            this.ButGeneralPurchaesTax.TabIndex = 6795;
            this.ButGeneralPurchaesTax.Text = "تعميم";
            this.ButGeneralPurchaesTax.UseVisualStyleBackColor = false;
            this.ButGeneralPurchaesTax.Click += new System.EventHandler(this.ButGeneralPurchaesTax_Click);
            // 
            // label2Tax
            // 
            this.label2Tax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2Tax.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2Tax.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2Tax.Location = new System.Drawing.Point(450, 273);
            this.label2Tax.Name = "label2Tax";
            this.label2Tax.Size = new System.Drawing.Size(28, 22);
            this.label2Tax.TabIndex = 6794;
            this.label2Tax.Text = "%";
            this.label2Tax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3Tax
            // 
            this.label3Tax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3Tax.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3Tax.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3Tax.Location = new System.Drawing.Point(540, 273);
            this.label3Tax.Name = "label3Tax";
            this.label3Tax.Size = new System.Drawing.Size(139, 22);
            this.label3Tax.TabIndex = 6792;
            this.label3Tax.Text = "ضريبة المشتريات";
            this.label3Tax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPurchaesTax
            // 
            this.txtPurchaesTax.AllowEmptyState = false;
            // 
            // 
            // 
            this.txtPurchaesTax.BackgroundStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(198)))));
            this.txtPurchaesTax.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtPurchaesTax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPurchaesTax.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtPurchaesTax.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtPurchaesTax.Increment = 1D;
            this.txtPurchaesTax.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
            this.txtPurchaesTax.Location = new System.Drawing.Point(480, 273);
            this.txtPurchaesTax.MinValue = 0D;
            this.txtPurchaesTax.Name = "txtPurchaesTax";
            this.txtPurchaesTax.Size = new System.Drawing.Size(58, 22);
            this.txtPurchaesTax.TabIndex = 6793;
            this.txtPurchaesTax.Click += new System.EventHandler(this.txtPurchaesTax_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtTaxID);
            this.panel1.Controls.Add(this.button_SrchTaxNo);
            this.panel1.Controls.Add(this.txtTaxNo);
            this.panel1.Controls.Add(this.txtTaxName);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label4Tax);
            this.panel1.Location = new System.Drawing.Point(338, 298);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(683, 51);
            this.panel1.TabIndex = 6796;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txtTaxID
            // 
            this.txtTaxID.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtTaxID.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTaxID.Location = new System.Drawing.Point(3, 25);
            this.txtTaxID.Name = "txtTaxID";
            this.txtTaxID.ReadOnly = true;
            this.txtTaxID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTaxID.Size = new System.Drawing.Size(547, 21);
            this.txtTaxID.TabIndex = 1098;
            this.txtTaxID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_SrchTaxNo
            // 
            this.button_SrchTaxNo.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.button_SrchTaxNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button_SrchTaxNo.Location = new System.Drawing.Point(392, 2);
            this.button_SrchTaxNo.Name = "button_SrchTaxNo";
            this.button_SrchTaxNo.Size = new System.Drawing.Size(26, 20);
            this.button_SrchTaxNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_SrchTaxNo.Symbol = "";
            this.button_SrchTaxNo.SymbolSize = 12F;
            this.button_SrchTaxNo.TabIndex = 1094;
            this.button_SrchTaxNo.TextColor = System.Drawing.Color.SteelBlue;
            this.button_SrchTaxNo.Click += new System.EventHandler(this.button_SrchTaxNo_Click);
            // 
            // txtTaxNo
            // 
            this.txtTaxNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTaxNo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTaxNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtTaxNo.Location = new System.Drawing.Point(424, 2);
            this.txtTaxNo.MaxLength = 30;
            this.txtTaxNo.Name = "txtTaxNo";
            this.txtTaxNo.ReadOnly = true;
            this.txtTaxNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTaxNo.Size = new System.Drawing.Size(126, 21);
            this.txtTaxNo.TabIndex = 1093;
            this.txtTaxNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTaxName
            // 
            this.txtTaxName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTaxName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTaxName.Location = new System.Drawing.Point(3, 2);
            this.txtTaxName.Name = "txtTaxName";
            this.txtTaxName.ReadOnly = true;
            this.txtTaxName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTaxName.Size = new System.Drawing.Size(383, 21);
            this.txtTaxName.TabIndex = 1095;
            this.txtTaxName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(553, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 20);
            this.label10.TabIndex = 1097;
            this.label10.Text = "الرقم الضريبـــي";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4Tax
            // 
            this.label4Tax.BackColor = System.Drawing.Color.Transparent;
            this.label4Tax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4Tax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4Tax.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4Tax.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4Tax.Location = new System.Drawing.Point(553, 2);
            this.label4Tax.Name = "label4Tax";
            this.label4Tax.Size = new System.Drawing.Size(128, 20);
            this.label4Tax.TabIndex = 1096;
            this.label4Tax.Text = "حساب الضريبــة";
            this.label4Tax.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtTaxNote
            // 
            this.txtTaxNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtTaxNote.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTaxNote.Location = new System.Drawing.Point(338, 351);
            this.txtTaxNote.MaxLength = 150;
            this.txtTaxNote.Name = "txtTaxNote";
            this.txtTaxNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTaxNote.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTaxNote.Size = new System.Drawing.Size(547, 21);
            this.txtTaxNote.TabIndex = 6798;
            this.txtTaxNote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTaxNote.Click += new System.EventHandler(this.txtTaxNote_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(888, 351);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 20);
            this.label5.TabIndex = 6797;
            this.label5.Text = "ملاحظة بالضريبـة";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FrmTaxOpiton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 423);
            this.Controls.Add(this.txtTaxNote);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ButGeneralPurchaesTax);
            this.Controls.Add(this.label2Tax);
            this.Controls.Add(this.label3Tax);
            this.Controls.Add(this.txtPurchaesTax);
            this.Controls.Add(this.ButGeneralSalesTax);
            this.Controls.Add(this.label1Tax);
            this.Controls.Add(this.label30Tax);
            this.Controls.Add(this.txtSalesTax);
            this.Controls.Add(this.ButWithoutSave);
            this.Controls.Add(this.ButWithSave);
            this.Controls.Add(this.c1FlexGriadTax);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = (InvAcc.Properties.Resources.favicon);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTaxOpiton";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "خيارات الضــرائب";
            this.Load += new System.EventHandler(this.FrmTaxOpiton_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmTaxOpiton_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmTaxOpiton_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGriadTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesTax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPurchaesTax)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Icon = (InvAcc.Properties.Resources.favicon);
            this.ResumeLayout(false);
            this.PerformLayout();
        }//###########&&&&&&&&&&

}
}
