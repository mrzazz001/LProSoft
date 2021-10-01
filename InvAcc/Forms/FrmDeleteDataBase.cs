using DevComponents.DotNetBar;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmDeleteDataBase : Form
    { void avs(int arln)

{ 
 label29.Text=   (arln == 0 ? "  قواعد البيانات                 Data Bases  " : "  Databases") ; buttonX_Close.Text=   (arln == 0 ? "  Close - إغلاق  " : "  Close") ; button_Del.Text=   (arln == 0 ? "  Del - حذف  " : "  Del - delete") ;}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
       // private IContainer components = null;
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
#pragma warning disable CS0414 // The field 'FrmDeleteDataBase.LangArEn' is assigned but its value is never used
        private int LangArEn = 0;
#pragma warning restore CS0414 // The field 'FrmDeleteDataBase.LangArEn' is assigned but its value is never used
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
        public FrmDeleteDataBase(List<string> value)
        {
            InitializeComponent();this.Load += langloads;
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
