using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using ProShared.GeneralM;using ProShared;
using ProShared.Stock_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmEndYearsFiles : Form
    { void avs(int arln)

{ 
 label29.Text=   (arln == 0 ? "  البيانات المقفلة                             The Data Locked  " : "  The Data Locked") ; textBox_EndsPath.Text=   (arln == 0 ? "  ....  " : "  ....") ; buttonX_Ok.Text=   (arln == 0 ? "  OK  موافـق  " : "  OK") ; buttonX_Close.Text=   (arln == 0 ? "  Close  إغلاق  " : "  Close") ;}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
#pragma warning disable CS0414 // The field 'FrmEndYearsFiles.LangArEn' is assigned but its value is never used
        private int LangArEn = 0;
#pragma warning restore CS0414 // The field 'FrmEndYearsFiles.LangArEn' is assigned but its value is never used
        private Rate_DataDataContext dbInstanceRate;
        private Stock_DataDataContext dbInstance;
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
            InitializeComponent();this.Load += langloads;
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
    }
}
