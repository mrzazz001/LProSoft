   

namespace InvAcc.Forms
{
partial class FMFind
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMFind));
            this.c1TrueDBGrid1 = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.dataSet1 = new System.Data.DataSet();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.groupBoxTxtSearch = new System.Windows.Forms.GroupBox();
            this.txtSearch = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.categoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonItem_Exit = new C1.Win.C1Input.C1Button();
            this.ButOK = new C1.Win.C1Input.C1Button();
            this.c1Button1 = new C1.Win.C1Input.C1Button();
            ((System.ComponentModel.ISupportInitialize)(this.c1TrueDBGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.groupBoxTxtSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonItem_Exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Button1)).BeginInit();
            this.SuspendLayout();
            // 
            // c1TrueDBGrid1
            // 
            this.c1TrueDBGrid1.AllowUpdate = false;
            this.c1TrueDBGrid1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.c1TrueDBGrid1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.c1TrueDBGrid1.CaptionHeight = 2220;
            this.c1TrueDBGrid1.Dock = System.Windows.Forms.DockStyle.Top;
            this.c1TrueDBGrid1.FetchRowStyles = true;
            this.c1TrueDBGrid1.FilterBar = true;
            this.c1TrueDBGrid1.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Flat;
            this.c1TrueDBGrid1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.c1TrueDBGrid1.ForeColor = System.Drawing.Color.DimGray;
            this.c1TrueDBGrid1.GroupByCaption = "Drag a column header here to group by that column";
            this.c1TrueDBGrid1.Images.Add(((System.Drawing.Image)(resources.GetObject("c1TrueDBGrid1.Images"))));
            this.c1TrueDBGrid1.LinesPerRow = 1;
            this.c1TrueDBGrid1.Location = new System.Drawing.Point(0, 74);
            this.c1TrueDBGrid1.Name = "c1TrueDBGrid1";
            this.c1TrueDBGrid1.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.c1TrueDBGrid1.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.c1TrueDBGrid1.PreviewInfo.ZoomFactor = 75D;
            this.c1TrueDBGrid1.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("c1TrueDBGrid1.PrintInfo.PageSettings")));
            this.c1TrueDBGrid1.RowHeight = 20;
            this.c1TrueDBGrid1.Size = new System.Drawing.Size(721, 320);
            this.c1TrueDBGrid1.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation;
            this.c1TrueDBGrid1.TabIndex = 0;
            this.c1TrueDBGrid1.Text = "c1TrueDBGrid1";
            this.c1TrueDBGrid1.VisualStyle = C1.Win.C1TrueDBGrid.VisualStyle.Office2007Blue;
            this.c1TrueDBGrid1.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.c1TrueDBGrid1_RowColChange);
            this.c1TrueDBGrid1.FilterChange += new System.EventHandler(this.c1TrueDBGrid1_FilterChange);
            this.c1TrueDBGrid1.DoubleClick += new System.EventHandler(this.c1TrueDBGrid1_DoubleClick);
            this.c1TrueDBGrid1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c1TrueDBGrid1_KeyDown);
            this.c1TrueDBGrid1.PropBag = resources.GetString("c1TrueDBGrid1.PropBag");
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.DimGray;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX1.Font = new System.Drawing.Font("Tahoma", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labelX1.ForeColor = System.Drawing.Color.White;
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(721, 26);
            this.labelX1.TabIndex = 985;
            this.labelX1.Text = "?????????? ???????????????? - Quick Search";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // groupBoxTxtSearch
            // 
            this.groupBoxTxtSearch.Controls.Add(this.txtSearch);
            this.groupBoxTxtSearch.Controls.Add(this.radioButton1);
            this.groupBoxTxtSearch.Controls.Add(this.radioButton2);
            this.groupBoxTxtSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxTxtSearch.Location = new System.Drawing.Point(0, 26);
            this.groupBoxTxtSearch.Name = "groupBoxTxtSearch";
            this.groupBoxTxtSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBoxTxtSearch.Size = new System.Drawing.Size(721, 48);
            this.groupBoxTxtSearch.TabIndex = 993;
            this.groupBoxTxtSearch.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtSearch.Border.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.DockSiteBackColor;
            this.txtSearch.Border.Class = "TextBoxBorder";
            this.txtSearch.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSearch.ButtonCustom.Image = ((System.Drawing.Image)(resources.GetObject("txtSearch.ButtonCustom.Image")));
            this.txtSearch.ButtonCustom.Visible = true;
            this.txtSearch.ButtonCustom2.Shortcut = DevComponents.DotNetBar.eShortcut.F10;
            this.txtSearch.ButtonCustom2.Text = "F10";
            this.txtSearch.ButtonCustom2.Visible = true;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Location = new System.Drawing.Point(3, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(715, 22);
            this.txtSearch.TabIndex = 990;
            this.txtSearch.Text = "";
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearch.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtSearch.WatermarkText = "Enter text to search...";
            this.txtSearch.ButtonCustomClick += new System.EventHandler(this.txtSearch_ButtonCustomClick);
            this.txtSearch.ButtonCustom2Click += new System.EventHandler(this.txtSearch_ButtonCustom2Click);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.radioButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radioButton1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton1.Location = new System.Drawing.Point(848, 18);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(87, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "?????? ??????????";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Visible = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.radioButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radioButton2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton2.Location = new System.Drawing.Point(949, 18);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(87, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "?????? ??????????";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Visible = false;
            // 
            // categoryBindingSource
            // 
            this.categoryBindingSource.DataSource = typeof(InvAcc.Stock_Data.T_CATEGORY);
            // 
            // buttonItem_Exit
            // 
            this.buttonItem_Exit.BackgroundImage = global::InvAcc.Properties.Resources.YALO2;
            this.buttonItem_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonItem_Exit.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonItem_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonItem_Exit.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonItem_Exit.Location = new System.Drawing.Point(618, 394);
            this.buttonItem_Exit.Name = "buttonItem_Exit";
            this.buttonItem_Exit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buttonItem_Exit.Size = new System.Drawing.Size(103, 45);
            this.buttonItem_Exit.TabIndex = 1189;
            this.buttonItem_Exit.Text = "???????? | ESC";
            this.buttonItem_Exit.UseVisualStyleBackColor = true;
            this.buttonItem_Exit.Click += new System.EventHandler(this.button1_Click);
            // 
            // ButOK
            // 
            this.ButOK.BackgroundImage = global::InvAcc.Properties.Resources.GREEN;
            this.ButOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButOK.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.ButOK.Location = new System.Drawing.Point(182, 394);
            this.ButOK.Name = "ButOK";
            this.ButOK.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ButOK.Size = new System.Drawing.Size(438, 45);
            this.ButOK.TabIndex = 1189;
            this.ButOK.Text = "?????????? | OK";
            this.ButOK.UseVisualStyleBackColor = true;
            this.ButOK.Click += new System.EventHandler(this.ButOK_Click);
            // 
            // c1Button1
            // 
            this.c1Button1.BackgroundImage = global::InvAcc.Properties.Resources.pin;
            this.c1Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.c1Button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.c1Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.c1Button1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.c1Button1.Location = new System.Drawing.Point(0, 394);
            this.c1Button1.Name = "c1Button1";
            this.c1Button1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.c1Button1.Size = new System.Drawing.Size(185, 45);
            this.c1Button1.TabIndex = 1189;
            this.c1Button1.Text = "?????? | CLEAR";
            this.c1Button1.UseVisualStyleBackColor = true;
            this.c1Button1.Click += new System.EventHandler(this.ButClear_Click);
            // 
            // FMFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(721, 439);
            this.ControlBox = false;
            this.Controls.Add(this.c1Button1);
            this.Controls.Add(this.ButOK);
            this.Controls.Add(this.buttonItem_Exit);
            this.Controls.Add(this.c1TrueDBGrid1);
            this.Controls.Add(this.groupBoxTxtSearch);
            this.Controls.Add(this.labelX1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FMFind";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".";
            this.Load += new System.EventHandler(this.FMFind_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FMFind_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.c1TrueDBGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.groupBoxTxtSearch.ResumeLayout(false);
            this.groupBoxTxtSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonItem_Exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Button1)).EndInit();
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            this.ResumeLayout(false);
        }//###########&&&&&&&&&&

}
}
