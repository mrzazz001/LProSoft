using DevComponents.DotNetBar;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmDeleteDataBase : Form
    {
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

        private ListBox listBox_Branch;
        private Label label29;
        private ListBox listBox_Branch2;
        private ButtonX buttonX_Close;
        private ButtonX button_Del;
        private List<string> AllDataBase = new List<string>();
        private Stock_DataDataContext dbInstance;
        private Rate_DataDataContext dbInstanceRate;
        private int LangArEn = 0;
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
            this.listBox_Branch = new System.Windows.Forms.ListBox();
            components = new System.ComponentModel.Container();

            this.label29 = new System.Windows.Forms.Label();
            this.listBox_Branch2 = new System.Windows.Forms.ListBox();
            this.buttonX_Close = new DevComponents.DotNetBar.ButtonX();
            this.button_Del = new DevComponents.DotNetBar.ButtonX();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();

            this.SuspendLayout();
            // 
            // listBox_Branch
            // 
            this.listBox_Branch.BackColor = System.Drawing.Color.White;
            this.listBox_Branch.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_Branch.ForeColor = System.Drawing.Color.SteelBlue;
            this.listBox_Branch.FormattingEnabled = true;
            this.listBox_Branch.ItemHeight = 14;
            this.listBox_Branch.Location = new System.Drawing.Point(4, 40);
            this.listBox_Branch.Name = "listBox_Branch";
            this.listBox_Branch.ScrollAlwaysVisible = true;
            this.listBox_Branch.Size = new System.Drawing.Size(340, 172);
            this.listBox_Branch.TabIndex = 0;
            this.listBox_Branch.SelectedIndexChanged += new System.EventHandler(this.listBox_Branch_SelectedIndexChanged);
            this.listBox_Branch.DoubleClick += new System.EventHandler(this.listBox_Branch_DoubleClick);
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.White;
            this.label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label29.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label29.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label29.ForeColor = System.Drawing.Color.SteelBlue;
            this.label29.Location = new System.Drawing.Point(4, 4);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(340, 33);
            this.label29.TabIndex = 9;
            this.label29.Text = "قواعد البيانات                 Data Bases";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBox_Branch2
            // 
            this.listBox_Branch2.BackColor = System.Drawing.Color.White;
            this.listBox_Branch2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_Branch2.FormattingEnabled = true;
            this.listBox_Branch2.ItemHeight = 14;
            this.listBox_Branch2.Location = new System.Drawing.Point(155, 100);
            this.listBox_Branch2.Name = "listBox_Branch2";
            this.listBox_Branch2.ScrollAlwaysVisible = true;
            this.listBox_Branch2.Size = new System.Drawing.Size(42, 18);
            this.listBox_Branch2.TabIndex = 11;
            // 
            // buttonX_Close
            // 
            this.buttonX_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_Close.Checked = true;
            this.buttonX_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_Close.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.buttonX_Close.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.buttonX_Close.Location = new System.Drawing.Point(4, 214);
            this.buttonX_Close.Name = "buttonX_Close";
            this.buttonX_Close.Size = new System.Drawing.Size(165, 40);
            this.buttonX_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_Close.Symbol = "";
            this.buttonX_Close.TabIndex = 1581;
            this.buttonX_Close.Text = "Close - إغلاق";
            this.buttonX_Close.TextColor = System.Drawing.Color.Black;
            this.buttonX_Close.Click += new System.EventHandler(this.buttonX_Close_Click);
            // 
            // button_Del
            // 
            this.button_Del.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button_Del.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.button_Del.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button_Del.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.button_Del.Location = new System.Drawing.Point(171, 214);
            this.button_Del.Name = "button_Del";
            this.button_Del.Size = new System.Drawing.Size(165, 40);
            this.button_Del.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.button_Del.Symbol = "";
            this.button_Del.TabIndex = 1580;
            this.button_Del.Text = "Del - حذف";
            this.button_Del.TextColor = System.Drawing.Color.White;
            this.button_Del.Click += new System.EventHandler(this.button_Del_Click);
            // 
            // FrmDeleteDataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(333, 250);
            this.ControlBox = false;
            this.Controls.Add(this.buttonX_Close);
            this.Controls.Add(this.button_Del);
            this.Controls.Add(this.listBox_Branch);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.listBox_Branch2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FrmDeleteDataBase";
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmDeleteDataBase_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmDeleteDataBase_KeyDown);
            this.Icon = ((System.Drawing.Icon)(InvAcc.Properties.Resources.favicon));
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.ResumeLayout(false);
        }
        public FrmDeleteDataBase(List<string> value)
        {
            InitializeComponent();
            AllDataBase = value;
        }
        private void FrmDeleteDataBase_Load(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
                {
                    LangArEn = 0;
                }
                else
                {
                    LangArEn = 1;
                }
                listBox_Branch.SelectedIndexChanged -= listBox_Branch_SelectedIndexChanged;
                for (int i = 0; i < AllDataBase.Count; i++)
                {
                    listBox_Branch.Items.Add(AllDataBase[i].ToString().Replace("DBPROSOFT_", ""));
                    listBox_Branch2.Items.Add(AllDataBase[i].ToString());
                }
                listBox_Branch.SelectedIndexChanged += listBox_Branch_SelectedIndexChanged;
                listBox_Branch.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                VarGeneral.DebLog.writeLog("FrmDeleteDataBase_Load:", ex, enable: true);
                MessageBox.Show(ex.Message, Application.ProductName);
            }
        }
        private void listBox_Branch_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (listBox_Branch.Text != "" && listBox_Branch2.Text.Length > 6)
                {
                    VarGeneral.brNm = listBox_Branch2.Text;
                    Close();
                }
            }
            catch
            {
            }
        }
        private void listBox_Branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listBox_Branch2.SelectedIndex = listBox_Branch.SelectedIndex;
            }
            catch
            {
                listBox_Branch.SelectedIndex = -1;
            }
        }
        private void button_Del_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(listBox_Branch.Text) && listBox_Branch.SelectedIndex != -1 && !(listBox_Branch2.Text == VarGeneral.gDatabaseName))
                {
                    List<string> q = dbc.ExecuteQuery<string>("select name From master..sysdatabases Where name like 'PROSOFT_" + listBox_Branch.Text.Trim() + "%' and name not like '%_Endsyr_%' order by name ", new object[0]).ToList();
                    for (int i = 0; i < q.Count; i++)
                    {
                        dbc.ExecuteCommand("ALTER DATABASE " + q[i] + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE;\r\n                                DROP DATABASE [" + q[i] + "]");
                    }
                    dbc.ExecuteCommand("ALTER DATABASE " + listBox_Branch2.Text.Trim() + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE;\r\n                                DROP DATABASE [" + listBox_Branch2.Text.Trim() + "]");
                    Close();
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_Del_Click:", error, enable: true);
                MessageBox.Show(error.Message);
                Close();
            }
        }
        private void buttonX_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void FrmDeleteDataBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
