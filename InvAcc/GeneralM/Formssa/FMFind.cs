using C1.Win.C1TrueDBGrid;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Framework.Keyboard;
using InvAcc.GeneralM;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FMFind : Form
    {
        public string Serach_No = "";
        private IContainer components = null;
        private C1TrueDBGrid c1TrueDBGrid1;
        private BindingSource categoryBindingSource;
        private DataSet dataSet1;
        private LabelX labelX1;
        private GroupBox groupBoxTxtSearch;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private C1.Win.C1Input.C1Button buttonItem_Exit;
        private C1.Win.C1Input.C1Button ButOK;
        private C1.Win.C1Input.C1Button c1Button1;
        private TextBoxX txtSearch;
        public string SerachNo
        {
            get
            {
                return Serach_No;
            }
            set
            {
                Serach_No = value;
            }
        }
        public FMFind(string filter, int index)
        {
            InitializeComponent();
            DataSetFill();
            c1TrueDBGrid1.DataSource = dataSet1.Tables[0];
            c1TrueDBGrid1.EditActive = true;
            c1TrueDBGrid1.FilterBar = true;
            c1TrueDBGrid1.AllowFilter = true;
            c1TrueDBGrid1.EditActive = true;
            for (int iiCnt = 0; iiCnt < c1TrueDBGrid1.Columns.Count; iiCnt++)
            {
                if (iiCnt == 1)
                {
                    c1TrueDBGrid1.Splits[0].DisplayColumns[iiCnt].Width = c1TrueDBGrid1.Width / 6;
                }
                if (iiCnt == 2 || iiCnt == 3)
                {
                    c1TrueDBGrid1.Splits[0].DisplayColumns[iiCnt].Width = c1TrueDBGrid1.Width / 3;
                }
                if (iiCnt == 4)
                {
                    c1TrueDBGrid1.Splits[0].DisplayColumns[iiCnt].Width = c1TrueDBGrid1.Width / 9;
                }
                c1TrueDBGrid1.Splits[0].DisplayColumns[iiCnt].HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center;
                c1TrueDBGrid1.Splits[0].DisplayColumns[c1TrueDBGrid1.Columns.Count - 1].AllowFocus = true;
            }
            if (VarGeneral.InvTyp == 11 || VarGeneral.InvTyp == 12 || VarGeneral.InvTyp == 13)
            {
                base.Width -= c1TrueDBGrid1.Width / 9;
            }
            c1TrueDBGrid1.Splits[0].DisplayColumns[0].Visible = false;
            c1TrueDBGrid1.FocusedSplit.AllowFocus = true;
            c1TrueDBGrid1.Focus();
            c1TrueDBGrid1.Col = 1;
            if (filter != "")
            {
                c1TrueDBGrid1.Columns[index].FilterText = filter;
                c1TrueDBGrid1.Col = index;
            }
            c1TrueDBGrid1.FilterActive = true;
            SendKeys.Send("{F2}");
            SendKeys.Send("{End}");
        }
        protected override void OnLoad(EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SerachNo = "";
            Close();
        }
        private void c1TrueDBGrid1_FilterChange(object sender, EventArgs e)
        {
            try
            {
                txtSearch.TextChanged -= txtSearch_TextChanged;
                txtSearch.Text = "";
                txtSearch.TextChanged += txtSearch_TextChanged;
            }
            catch
            {
            }
        }
        private void DataSetFill()
        {
            try
            {
                dataSet1 = VarGeneral.RepData;
            }
            catch
            {
            }
        }
        private void c1TrueDBGrid1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (c1TrueDBGrid1.Row >= 0)
                {
                    int Index = c1TrueDBGrid1.Row;
                    SerachNo = c1TrueDBGrid1.Columns[0].CellValue(c1TrueDBGrid1.Row).ToString();
                    Close();
                }
                else
                {
                    SerachNo = "";
                    Close();
                }
            }
            catch
            {
                SerachNo = "";
                Close();
            }
        }
        private void c1TrueDBGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Return)
                {
                    if (c1TrueDBGrid1.Row >= 0)
                    {
                        int Index = c1TrueDBGrid1.Row;
                        SerachNo = c1TrueDBGrid1.Columns[0].CellValue(c1TrueDBGrid1.Row).ToString();
                        Close();
                    }
                    else
                    {
                        SerachNo = "";
                        Close();
                    }
                }
            }
            catch
            {
                SerachNo = "";
                Close();
            }
        }
        private void ButClear_Click(object sender, EventArgs e)
        {
        }
        private void FMFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                ButClear_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                button1_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F10)
            {
                txtSearch_ButtonCustom2Click(sender, e);
            }
        }
        private void c1TrueDBGrid1_RowColChange(object sender, RowColChangeEventArgs e)
        {
            if (c1TrueDBGrid1.Col == 1)
            {
                Language.Switch("English");
            }
            if (c1TrueDBGrid1.Col == 2)
            {
                Language.Switch("Arabic");
            }
            if (c1TrueDBGrid1.Col == 3)
            {
                Language.Switch("English");
            }
        }
        private void ButOK_Click(object sender, EventArgs e)
        {
            c1TrueDBGrid1_DoubleClick(sender, e);
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                c1TrueDBGrid1.FilterChange -= c1TrueDBGrid1_FilterChange;
                for (int i = 0; i < c1TrueDBGrid1.Columns.Count; i++)
                {
                    c1TrueDBGrid1.Columns[i].FilterText = "";
                }
                c1TrueDBGrid1.FilterChange += c1TrueDBGrid1_FilterChange;
                (c1TrueDBGrid1.DataSource as DataTable).DefaultView.RowFilter = string.Format("[" + dataSet1.Tables[0].Columns[(c1TrueDBGrid1.Columns.Count <= 4) ? 1 : 0].Caption + "] LIKE '%{0}%' OR [" + dataSet1.Tables[0].Columns[1].Caption + "] LIKE '%{0}%' OR [" + dataSet1.Tables[0].Columns[2].Caption + "] LIKE '%{0}%' OR [" + dataSet1.Tables[0].Columns[3].Caption + "] LIKE '%{0}%'", txtSearch.Text);
            }
            catch
            {
            }
        }
        private void txtSearch_ButtonCustomClick(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }
        private void FMFind_Load(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.gUserName == "runsetting")
                {
                    SendKeys.Send("%{TAB}");
                }
            }
            catch
            {
            }
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
        }
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == '\r')
                {
                    c1TrueDBGrid1.Focus();
                    c1TrueDBGrid1.Col = 1;
                    c1TrueDBGrid1.Row = 0;
                }
            }
            catch
            {
            }
        }
        private void txtSearch_ButtonCustom2Click(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
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
            this.labelX1.Text = "البحث الســريع - Quick Search";
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
            this.radioButton1.Text = "بحث محتوى";
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
            this.radioButton2.Text = "بحث مطابق";
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
            this.buttonItem_Exit.Text = "خروج | ESC";
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
            this.ButOK.Text = "موافق | OK";
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
            this.c1Button1.Text = "مسح | CLEAR";
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
        }
    }
}
