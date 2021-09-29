   

namespace InvAcc.Forms
{
partial class FrmSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSearch));
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background2 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Padding padding1 = new DevComponents.DotNetBar.SuperGrid.Style.Padding();
            DevComponents.DotNetBar.SuperGrid.Style.Padding padding2 = new DevComponents.DotNetBar.SuperGrid.Style.Padding();
            DevComponents.DotNetBar.SuperGrid.Style.Background background3 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Background background4 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Padding padding3 = new DevComponents.DotNetBar.SuperGrid.Style.Padding();
            DevComponents.DotNetBar.SuperGrid.Style.Padding padding4 = new DevComponents.DotNetBar.SuperGrid.Style.Padding();
            DevComponents.DotNetBar.SuperGrid.Style.Background background5 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Padding padding5 = new DevComponents.DotNetBar.SuperGrid.Style.Padding();
            DevComponents.DotNetBar.SuperGrid.Style.Padding padding6 = new DevComponents.DotNetBar.SuperGrid.Style.Padding();
            DevComponents.DotNetBar.SuperGrid.Style.Background background6 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            DevComponents.DotNetBar.SuperGrid.Style.Padding padding7 = new DevComponents.DotNetBar.SuperGrid.Style.Padding();
            DevComponents.DotNetBar.SuperGrid.Style.Padding padding8 = new DevComponents.DotNetBar.SuperGrid.Style.Padding();
            DevComponents.DotNetBar.SuperGrid.Style.Background background7 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
            this.buttonX_Close = new DevComponents.DotNetBar.ButtonX();
            this.buttonX_Clear = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.buttonX_Ok = new DevComponents.DotNetBar.ButtonX();
            this.GridCheck = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.buttonX_Additem = new DevComponents.DotNetBar.ButtonX();
            this.c1TrueDBGrid1 = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.dataSet1 = new System.Data.DataSet();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1TrueDBGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonX_Close
            // 
            this.buttonX_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Close.Checked = true;
            this.buttonX_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonX_Close.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.buttonX_Close.Location = new System.Drawing.Point(4, 334);
            this.buttonX_Close.Name = "buttonX_Close";
            this.buttonX_Close.Size = new System.Drawing.Size(310, 27);
            this.buttonX_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Close.TabIndex = 743;
            this.buttonX_Close.Text = "إغـــلاق";
            this.buttonX_Close.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // buttonX_Clear
            // 
            this.buttonX_Clear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Clear.Checked = true;
            this.buttonX_Clear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_Clear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonX_Clear.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.buttonX_Clear.Location = new System.Drawing.Point(211, 334);
            this.buttonX_Clear.Name = "buttonX_Clear";
            this.buttonX_Clear.Size = new System.Drawing.Size(206, 27);
            this.buttonX_Clear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Clear.TabIndex = 742;
            this.buttonX_Clear.Text = "مســـح";
            this.buttonX_Clear.Visible = false;
            this.buttonX_Clear.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Location = new System.Drawing.Point(244, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(380, 42);
            this.groupBox1.TabIndex = 745;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 45;
            this.button1.Text = "حذف";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.radioButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radioButton1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton1.Location = new System.Drawing.Point(87, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(87, 17);
            this.radioButton1.TabIndex = 44;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "بحث محتوى";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.radioButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.radioButton2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButton2.Location = new System.Drawing.Point(212, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(87, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "بحث مطابق";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(244, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(211, 42);
            this.groupBox2.TabIndex = 741;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "الترتيب حسب";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // buttonX_Ok
            // 
            this.buttonX_Ok.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Ok.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX_Ok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonX_Ok.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.buttonX_Ok.Location = new System.Drawing.Point(317, 334);
            this.buttonX_Ok.Name = "buttonX_Ok";
            this.buttonX_Ok.Size = new System.Drawing.Size(310, 27);
            this.buttonX_Ok.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Ok.TabIndex = 746;
            this.buttonX_Ok.Text = "موافق";
            this.buttonX_Ok.TextColor = System.Drawing.Color.White;
            this.buttonX_Ok.Click += new System.EventHandler(this.buttonX_Ok_Click);
            // 
            // GridCheck
            // 
            this.GridCheck.Anchor = ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right));
            this.GridCheck.BackColor = System.Drawing.Color.White;
            this.GridCheck.DefaultVisualStyles.FooterStyles.Default.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.GridCheck.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.GridCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.GridCheck.HScrollBarVisible = false;
            this.GridCheck.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.GridCheck.Location = new System.Drawing.Point(4, 3);
            this.GridCheck.Name = "GridCheck";
            this.GridCheck.PrimaryGrid.AllowSelection = false;
            this.GridCheck.PrimaryGrid.AutoGenerateColumns = false;
            this.GridCheck.PrimaryGrid.AutoHideDeletedRows = false;
            this.GridCheck.PrimaryGrid.AutoSelectDeleteBoundRows = false;
            this.GridCheck.PrimaryGrid.AutoSelectNewBoundRows = false;
            this.GridCheck.PrimaryGrid.Caption.Text = "(Caption)<div align=\"vcenter\">Wolf Power and Machine Works Inc.</div>";
            this.GridCheck.PrimaryGrid.Caption.Visible = false;
            this.GridCheck.PrimaryGrid.ColumnHeader.AllowSelection = false;
            this.GridCheck.PrimaryGrid.ColumnHeader.Visible = false;
            gridColumn1.CellHighlightMode = DevComponents.DotNetBar.SuperGrid.Style.CellHighlightMode.None;
            gridColumn1.DefaultNewRowCellValue = "false";
            gridColumn1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            gridColumn1.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            gridColumn1.InfoImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn1.Name = "إظهار";
            gridColumn1.Width = 70;
            gridColumn2.InfoImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            gridColumn2.Name = "حقل جديد";
            gridColumn2.ReadOnly = true;
            gridColumn2.Width = 200;
            gridColumn3.Name = string.Empty;
            gridColumn3.Visible = false;
            this.GridCheck.PrimaryGrid.Columns.Add(gridColumn1);
            this.GridCheck.PrimaryGrid.Columns.Add(gridColumn2);
            this.GridCheck.PrimaryGrid.Columns.Add(gridColumn3);
            this.GridCheck.PrimaryGrid.DefaultRowHeight = 30;
            background1.BackFillType = DevComponents.DotNetBar.SuperGrid.Style.BackFillType.HorizontalCenter;
            background1.Color1 = System.Drawing.Color.White;
            background1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.GridCheck.PrimaryGrid.DefaultVisualStyles.AlternateRowCellStyles.Default.Background = background1;
            background2.Color1 = System.Drawing.Color.AliceBlue;
            this.GridCheck.PrimaryGrid.DefaultVisualStyles.CaptionStyles.Default.Background = background2;
            this.GridCheck.PrimaryGrid.DefaultVisualStyles.CaptionStyles.Default.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            padding1.Right = 6;
            this.GridCheck.PrimaryGrid.DefaultVisualStyles.CaptionStyles.Default.ImagePadding = padding1;
            padding2.Bottom = 6;
            padding2.Left = 6;
            padding2.Right = 6;
            padding2.Top = 6;
            this.GridCheck.PrimaryGrid.DefaultVisualStyles.CaptionStyles.Default.Margin = padding2;
            background3.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.GridCheck.PrimaryGrid.DefaultVisualStyles.CaptionStyles.SelectedMouseOver.Background = background3;
            background4.Color1 = System.Drawing.Color.Lavender;
            background4.Color2 = System.Drawing.Color.DarkSlateGray;
            background4.GradientAngle = 45;
            this.GridCheck.PrimaryGrid.DefaultVisualStyles.ColumnHeaderRowStyles.Default.RowHeader.Background = background4;
            this.GridCheck.PrimaryGrid.DefaultVisualStyles.ColumnHeaderRowStyles.Default.RowHeader.BorderHighlightColor = System.Drawing.Color.White;
            padding3.Bottom = 4;
            padding3.Left = 4;
            padding3.Right = 4;
            padding3.Top = 4;
            this.GridCheck.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.Margin = padding3;
            this.GridCheck.PrimaryGrid.DefaultVisualStyles.FooterStyles.Default.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            this.GridCheck.PrimaryGrid.DefaultVisualStyles.FooterStyles.Default.ImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.TopLeft;
            padding4.Bottom = 4;
            padding4.Left = 4;
            padding4.Right = 4;
            padding4.Top = 4;
            this.GridCheck.PrimaryGrid.DefaultVisualStyles.FooterStyles.Default.Margin = padding4;
            background5.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.GridCheck.PrimaryGrid.DefaultVisualStyles.FooterStyles.SelectedMouseOver.Background = background5;
            this.GridCheck.PrimaryGrid.DefaultVisualStyles.HeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.GridCheck.PrimaryGrid.DefaultVisualStyles.HeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.GridCheck.PrimaryGrid.DefaultVisualStyles.HeaderStyles.Default.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            this.GridCheck.PrimaryGrid.DefaultVisualStyles.HeaderStyles.Default.ImageOverlay = DevComponents.DotNetBar.SuperGrid.Style.ImageOverlay.None;
            padding5.Right = 4;
            this.GridCheck.PrimaryGrid.DefaultVisualStyles.HeaderStyles.Default.ImagePadding = padding5;
            padding6.Bottom = 4;
            padding6.Left = 4;
            padding6.Right = 4;
            padding6.Top = 4;
            this.GridCheck.PrimaryGrid.DefaultVisualStyles.HeaderStyles.Default.Margin = padding6;
            background6.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.GridCheck.PrimaryGrid.DefaultVisualStyles.HeaderStyles.SelectedMouseOver.Background = background6;
            this.GridCheck.PrimaryGrid.DefaultVisualStyles.TitleStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.True;
            this.GridCheck.PrimaryGrid.DefaultVisualStyles.TitleStyles.Default.Font = new System.Drawing.Font("Lucida Handwriting", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GridCheck.PrimaryGrid.DefaultVisualStyles.TitleStyles.Default.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image4")));
            padding7.Right = 6;
            this.GridCheck.PrimaryGrid.DefaultVisualStyles.TitleStyles.Default.ImagePadding = padding7;
            padding8.Bottom = 4;
            padding8.Left = 4;
            padding8.Right = 4;
            padding8.Top = 4;
            this.GridCheck.PrimaryGrid.DefaultVisualStyles.TitleStyles.Default.Margin = padding8;
            this.GridCheck.PrimaryGrid.DefaultVisualStyles.TitleStyles.Default.TextColor = System.Drawing.Color.Navy;
            background7.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.GridCheck.PrimaryGrid.DefaultVisualStyles.TitleStyles.SelectedMouseOver.Background = background7;
            this.GridCheck.PrimaryGrid.Footer.Text = "(Footer)<div align=\"vcenter\">Check with your Supervisor if you have <b>ANY</b> qu" +
    "estions.</div>";
            this.GridCheck.PrimaryGrid.Footer.Visible = false;
            this.GridCheck.PrimaryGrid.GridLines = DevComponents.DotNetBar.SuperGrid.GridLines.None;
            this.GridCheck.PrimaryGrid.Header.Text = "(Header) <div align=\"vcenter\">Make sure operator is a <b><font color=\"#ED1C24\">SA" +
    "FE DISTANCE</font> </b>away from the machine power panel before starting machine" +
    ".</div>";
            this.GridCheck.PrimaryGrid.Header.Visible = false;
            this.GridCheck.PrimaryGrid.ImmediateResize = true;
            this.GridCheck.PrimaryGrid.RowDragBehavior = DevComponents.DotNetBar.SuperGrid.RowDragBehavior.Move;
            this.GridCheck.PrimaryGrid.ShowColumnHeader = false;
            this.GridCheck.PrimaryGrid.ShowRowGridIndex = true;
            this.GridCheck.PrimaryGrid.ShowRowHeaders = false;
            this.GridCheck.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled;
            this.GridCheck.PrimaryGrid.Title.Text = "(Title)<div align=\"vcenter\">Check operators manual for suggested maintanance inte" +
    "rvals</div>";
            this.GridCheck.PrimaryGrid.Title.Visible = false;
            this.GridCheck.PrimaryGrid.UseAlternateRowStyle = true;
            this.GridCheck.Size = new System.Drawing.Size(237, 328);
            this.GridCheck.TabIndex = 747;
            this.GridCheck.VScrollBarVisible = false;
            this.GridCheck.CellClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellClickEventArgs>(this.GridCheck_CellClick);
            // 
            // buttonX_Additem
            // 
            this.buttonX_Additem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Additem.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_Additem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonX_Additem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.buttonX_Additem.Location = new System.Drawing.Point(7, 295);
            this.buttonX_Additem.Name = "buttonX_Additem";
            this.buttonX_Additem.Size = new System.Drawing.Size(231, 33);
            this.buttonX_Additem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Additem.TabIndex = 748;
            this.buttonX_Additem.Text = "إضافة الصنف";
            this.buttonX_Additem.Click += new System.EventHandler(this.buttonX_Additem_Click);
            // 
            // c1TrueDBGrid1
            // 
            this.c1TrueDBGrid1.AllowUpdate = false;
            this.c1TrueDBGrid1.BackColor = System.Drawing.Color.Gainsboro;
            this.c1TrueDBGrid1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.c1TrueDBGrid1.FetchRowStyles = true;
            this.c1TrueDBGrid1.FilterBar = true;
            this.c1TrueDBGrid1.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Flat;
            this.c1TrueDBGrid1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.c1TrueDBGrid1.ForeColor = System.Drawing.Color.DimGray;
            this.c1TrueDBGrid1.GroupByCaption = "Drag a column header here to group by that column";
            this.c1TrueDBGrid1.Images.Add(((System.Drawing.Image)(resources.GetObject("c1TrueDBGrid1.Images"))));
            this.c1TrueDBGrid1.LinesPerRow = 1;
            this.c1TrueDBGrid1.Location = new System.Drawing.Point(244, 48);
            this.c1TrueDBGrid1.Name = "c1TrueDBGrid1";
            this.c1TrueDBGrid1.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.c1TrueDBGrid1.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.c1TrueDBGrid1.PreviewInfo.ZoomFactor = 75D;
            this.c1TrueDBGrid1.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("c1TrueDBGrid1.PrintInfo.PageSettings")));
            this.c1TrueDBGrid1.RecordSelectors = false;
            this.c1TrueDBGrid1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.c1TrueDBGrid1.RowHeight = 20;
            this.c1TrueDBGrid1.Size = new System.Drawing.Size(380, 283);
            this.c1TrueDBGrid1.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation;
            this.c1TrueDBGrid1.TabIndex = 0;
            this.c1TrueDBGrid1.Text = "c1TrueDBGrid1";
            this.c1TrueDBGrid1.VisualStyle = C1.Win.C1TrueDBGrid.VisualStyle.Office2007Blue;
            this.c1TrueDBGrid1.RowColChange += new C1.Win.C1TrueDBGrid.RowColChangeEventHandler(this.c1TrueDBGrid1_RowColChange);
            this.c1TrueDBGrid1.FilterChange += new System.EventHandler(this.c1TrueDBGrid1_FilterChange);
            this.c1TrueDBGrid1.Click += new System.EventHandler(this.c1TrueDBGrid1_Click);
            this.c1TrueDBGrid1.DoubleClick += new System.EventHandler(this.c1TrueDBGrid1_DoubleClick);
            this.c1TrueDBGrid1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.c1TrueDBGrid1_KeyDown);
            this.c1TrueDBGrid1.PropBag = resources.GetString("c1TrueDBGrid1.PropBag");
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // FrmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(627, 363);
            this.ControlBox = false;
            this.Controls.Add(this.c1TrueDBGrid1);
            this.Controls.Add(this.buttonX_Additem);
            this.Controls.Add(this.buttonX_Ok);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonX_Close);
            this.Controls.Add(this.buttonX_Clear);
            this.Controls.Add(this.GridCheck);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = (InvAcc.Properties.Resources.favicon);
            this.KeyPreview = true;
            this.Name = "FrmSearch";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "البحث - Search";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmSearch_FormClosed);
            this.Load += new System.EventHandler(this.FrmSearch_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSearch_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1TrueDBGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.Icon = (InvAcc.Properties.Resources.favicon);
            this.ResumeLayout(false);

        }//###########&&&&&&&&&&

}
}
