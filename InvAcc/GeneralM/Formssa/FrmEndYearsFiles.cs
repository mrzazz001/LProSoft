using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmEndYearsFiles : Form
    {
        private int LangArEn = 0;
        private Rate_DataDataContext dbInstanceRate;
        private Stock_DataDataContext dbInstance;
        private IContainer components = null;
        private void netResize1_AfterControlResize(object sender, Softgroup.NetResize.AfterControlResizeEventArgs e)
        {
            if (e.Control.GetType() == typeof(Label))
            {
                Label c = (e.Control as Label); if ((c.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))))) && (c.BackColor != System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))))) && (c.BackColor != System.Drawing.Color.SteelBlue))
                    c.BackColor = Color.Transparent; Size cc = c.PreferredSize;
                c.AutoSize = false;
                c.Size = cc;

                //  e.Control.Font= new System.Drawing.Font("Tahoma",(float) (c-0.5));

            }
        }


        private void FrmInvSale_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;
        }

        private void FrmInvSale_SizeChanged(object sender, EventArgs e)
        {
            netResize1.Refresh();
        }

        public Softgroup.NetResize.NetResize netResize1;

        private ListBox listBox_Paths;
        private Label label29;
        private TextBoxX textBox_EndsPath;
        private GroupBox groupBox1;
        private ButtonX buttonX_Ok;
        private ButtonX buttonX_Close;
        private ListBox listBox_Paths2;
        private Rate_DataDataContext dbc
        {
            get
            {
                if (dbInstanceRate == null)
                {
                    dbInstanceRate = new Rate_DataDataContext(VarGeneral.BranchRt);
                }
                return dbInstanceRate;
            }
        }
        private Stock_DataDataContext db
        {
            get
            {
                if (dbInstance == null)
                {
                    dbInstance = new Stock_DataDataContext(VarGeneral.BranchCS);
                }
                return dbInstance;
            }
        }
        public FrmEndYearsFiles()
        {
            InitializeComponent();
        }
        private void buttonX_Close_Click(object sender, EventArgs e)
        {
            VarGeneral.brNm = string.Empty;
            Close();
        }
        private void listBox_Paths_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listBox_Paths2.SelectedIndex = listBox_Paths.SelectedIndex;
            }
            catch
            {
                listBox_Paths.SelectedIndex = -1;
            }
        }
        private void buttonX_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox_Paths.Text != string.Empty && listBox_Paths2.Text.Contains("DBEndYear_"))
                {
                    VarGeneral.brNm = listBox_Paths2.Text;
                    Close();
                }
            }
            catch
            {
                VarGeneral.brNm = string.Empty;
                Close();
            }
        }
        private void FrmEndYearsFiles_Load(object sender, EventArgs e)
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == string.Empty)
            {
                LangArEn = 0;
            }
            else
            {
                LangArEn = 1;
            }
            GET_Path();
        }
        private void GET_Path()
        {
            List<int> vDB = new List<int>();
            vDB = ((!VarGeneral.DBNo.Contains("_Endsyr_")) ? dbc.ExecuteQuery<int>("SELECT database_id FROM sys.databases WHERE name='" + VarGeneral.DBNo + "'", new object[0]).ToList() : dbc.ExecuteQuery<int>("SELECT database_id FROM sys.databases WHERE name like 'PROSOFT%' and name not like '%_Endsyr_%'", new object[0]).ToList());
            int vDB_ID = vDB.First();
            try
            {
                if (vDB_ID <= 0)
                {
                    return;
                }
                List<string> vRecPath = dbc.ExecuteQuery<string>("SELECT physical_name FROM sys.master_files WHERE type = 0 and database_id=" + vDB_ID, new object[0]).ToList();
                if (vRecPath.Count > 0)
                {
                    if (VarGeneral.DBNo.Contains("_Endsyr_"))
                    {
                        List<string> c = db.ExecuteQuery<string>("SELECT name FROM sys.databases WHERE database_id = " + vDB_ID, new object[0]).ToList();
                        textBox_EndsPath.Text = vRecPath.First().Replace(c.First() + ".mdf", null);
                    }
                    else
                    {
                        textBox_EndsPath.Text = vRecPath.First().Replace(VarGeneral.DBNo + ".mdf", null);
                    }
                }
            }
            catch
            {
                textBox_EndsPath.Text = string.Empty;
            }
        }
        private void textBox_EndsPath_ButtonCustomClick(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                DialogResult result = fbd.ShowDialog();
                textBox_EndsPath.Text = fbd.SelectedPath;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("textBox_EndsPath_ButtonCustomClick:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void textBox_EndsPath_TextChanged(object sender, EventArgs e)
        {
            listBox_Paths.SelectedIndexChanged -= listBox_Paths_SelectedIndexChanged;
            listBox_Paths.Items.Clear();
            listBox_Paths2.Items.Clear();
            List<string> directories = Directory.GetDirectories(textBox_EndsPath.Text).ToList();
            for (int i = 0; i < directories.Count; i++)
            {
                if (directories[i].Contains("DBEndYear_"))
                {
                    DirectoryInfo d = new DirectoryInfo(directories[i]);
                    List<FileInfo> q = d.GetFiles("*.lck").ToList();
                    for (int c = 0; c < q.Count; c++)
                    {
                        listBox_Paths.Items.Add(q[c].Name);
                        listBox_Paths2.Items.Add(q[c].FullName);
                    }
                }
            }
            listBox_Paths.SelectedIndexChanged += listBox_Paths_SelectedIndexChanged;
        }
        private void listBox_Paths_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (listBox_Paths.Text != string.Empty && listBox_Paths2.Text.Contains("DBEndYear_"))
                {
                    VarGeneral.brNm = listBox_Paths2.Text;
                    Close();
                }
            }
            catch
            {
                VarGeneral.brNm = string.Empty;
                Close();
            }
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
            this.listBox_Paths = new System.Windows.Forms.ListBox();
            this.label29 = new System.Windows.Forms.Label();
            this.textBox_EndsPath = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonX_Ok = new DevComponents.DotNetBar.ButtonX();
            this.buttonX_Close = new DevComponents.DotNetBar.ButtonX();
            this.listBox_Paths2 = new System.Windows.Forms.ListBox();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox_Paths
            // 
            this.listBox_Paths.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listBox_Paths.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBox_Paths.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_Paths.ForeColor = System.Drawing.Color.SteelBlue;
            this.listBox_Paths.FormattingEnabled = true;
            this.listBox_Paths.ItemHeight = 14;
            this.listBox_Paths.Location = new System.Drawing.Point(0, 33);
            this.listBox_Paths.Name = "listBox_Paths";
            this.listBox_Paths.ScrollAlwaysVisible = true;
            this.listBox_Paths.Size = new System.Drawing.Size(551, 158);
            this.listBox_Paths.TabIndex = 1;
            this.listBox_Paths.SelectedIndexChanged += new System.EventHandler(this.listBox_Paths_SelectedIndexChanged);
            this.listBox_Paths.DoubleClick += new System.EventHandler(this.listBox_Paths_DoubleClick);
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label29.Dock = System.Windows.Forms.DockStyle.Top;
            this.label29.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label29.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label29.ForeColor = System.Drawing.Color.SteelBlue;
            this.label29.Location = new System.Drawing.Point(0, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(551, 33);
            this.label29.TabIndex = 10;
            this.label29.Text = "البيانات المقفلة                             The Data Locked";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_EndsPath
            // 
            this.textBox_EndsPath.BackColor = System.Drawing.SystemColors.ActiveCaption;
            // 
            // 
            // 
            this.textBox_EndsPath.Border.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textBox_EndsPath.Border.BorderBottomWidth = 1;
            this.textBox_EndsPath.Border.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBox_EndsPath.Border.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textBox_EndsPath.Border.BorderLeftWidth = 1;
            this.textBox_EndsPath.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textBox_EndsPath.Border.BorderRightWidth = 1;
            this.textBox_EndsPath.Border.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.textBox_EndsPath.Border.BorderTopWidth = 1;
            this.textBox_EndsPath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBox_EndsPath.ButtonCustom.Text = "....";
            this.textBox_EndsPath.ButtonCustom.Visible = true;
            this.textBox_EndsPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox_EndsPath.Font = new System.Drawing.Font("Tahoma", 6.75F);
            this.textBox_EndsPath.ForeColor = System.Drawing.Color.Black;
            this.textBox_EndsPath.Location = new System.Drawing.Point(0, 191);
            this.textBox_EndsPath.Multiline = true;
            this.textBox_EndsPath.Name = "textBox_EndsPath";
            this.textBox_EndsPath.ReadOnly = true;
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_EndsPath, false);
            this.textBox_EndsPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_EndsPath.Size = new System.Drawing.Size(551, 24);
            this.textBox_EndsPath.TabIndex = 933;
            this.textBox_EndsPath.WatermarkColor = System.Drawing.Color.Black;
            this.textBox_EndsPath.WatermarkImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.textBox_EndsPath.ButtonCustomClick += new System.EventHandler(this.textBox_EndsPath_ButtonCustomClick);
            this.textBox_EndsPath.TextChanged += new System.EventHandler(this.textBox_EndsPath_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.buttonX_Ok);
            this.groupBox1.Controls.Add(this.buttonX_Close);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 214);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(551, 77);
            this.groupBox1.TabIndex = 934;
            this.groupBox1.TabStop = false;
            // 
            // buttonX_Ok
            // 
            this.buttonX_Ok.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Ok.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.buttonX_Ok.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonX_Ok.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.buttonX_Ok.Location = new System.Drawing.Point(202, 11);
            this.buttonX_Ok.Name = "buttonX_Ok";
            this.buttonX_Ok.Size = new System.Drawing.Size(343, 47);
            this.buttonX_Ok.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Ok.Symbol = "";
            this.buttonX_Ok.TabIndex = 13;
            this.buttonX_Ok.Text = "OK  موافـق";
            this.buttonX_Ok.TextColor = System.Drawing.Color.White;
            this.buttonX_Ok.Click += new System.EventHandler(this.buttonX_Ok_Click);
            // 
            // buttonX_Close
            // 
            this.buttonX_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Close.Checked = true;
            this.buttonX_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_Close.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonX_Close.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.buttonX_Close.Location = new System.Drawing.Point(5, 11);
            this.buttonX_Close.Name = "buttonX_Close";
            this.buttonX_Close.Size = new System.Drawing.Size(194, 47);
            this.buttonX_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Close.Symbol = "";
            this.buttonX_Close.TabIndex = 14;
            this.buttonX_Close.Text = "Close  إغلاق";
            this.buttonX_Close.TextColor = System.Drawing.Color.Black;
            this.buttonX_Close.Click += new System.EventHandler(this.buttonX_Close_Click);
            // 
            // listBox_Paths2
            // 
            this.listBox_Paths2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listBox_Paths2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_Paths2.ForeColor = System.Drawing.Color.SteelBlue;
            this.listBox_Paths2.FormattingEnabled = true;
            this.listBox_Paths2.ItemHeight = 14;
            this.listBox_Paths2.Location = new System.Drawing.Point(4, 117);
            this.listBox_Paths2.Name = "listBox_Paths2";
            this.listBox_Paths2.ScrollAlwaysVisible = true;
            this.listBox_Paths2.Size = new System.Drawing.Size(525, 74);
            this.listBox_Paths2.TabIndex = 935;
            this.listBox_Paths2.Visible = false;
            // 
            // netResize1
            // 
            this.netResize1.ParentControl = this;
            // 
            // FrmEndYearsFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(551, 291);
            this.ControlBox = false;
            this.Controls.Add(this.textBox_EndsPath);
            this.Controls.Add(this.listBox_Paths);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox_Paths2);
            this.Name = "FrmEndYearsFiles";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmEndYearsFiles_Load);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
