using DevComponents.DotNetBar;
using ProShared.GeneralM;using ProShared;
using SSSLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmScannerFiles : Form
    { void avs(int arln)

{ 
}
        private void langloads(object sender, EventArgs e)
        {
              avs(ProShared. GeneralM.VarGeneral.currentintlanguage);;
        }
   
#pragma warning disable CS0414 // The field 'FrmScannerFiles.LangArEn' is assigned but its value is never used
        private int LangArEn = 0;
#pragma warning restore CS0414 // The field 'FrmScannerFiles.LangArEn' is assigned but its value is never used
        private string vEmpNo = "";
        private string vEmpName = "";
        private string ServiceNm = "";
       // private IContainer components = null;
        private Panel panel10;
        private ListBox listBox_ImageFiles;
        private PictureBox pictureBox_ScannerFile;
        protected Panel panel2;
        private Button button_Print;
        private TextBox textBox_ID;
        private Label label1;
        private ButtonX Button_Close;
        public FrmScannerFiles(string vEmp, string vEmpNm)
        {
            InitializeComponent();this.Load += langloads;
            vEmpNo = vEmp;
            vEmpName = vEmpNm;
        }
        private void FrmScannerFiles_Load(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmScannerFiles));
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                Language.ChangeLanguage("ar-SA", this, resources);
                LangArEn = 0;
                Button_Close.Text = "خــــــــــــــــروج";
            }
            else
            {
                Language.ChangeLanguage("en", this, resources);
                LangArEn = 1;
                Button_Close.Text = "Close";
            }
            int b = 0;
            ServiceNm = "";
            for (b = 0; b < VarGeneral.gServerName.Length && !(VarGeneral.gServerName.Substring(b, 1) == "\\"); b++)
            {
            }
            try
            {
                ServiceNm = VarGeneral.gServerName.Substring(b + 1);
            }
            catch
            {
                ServiceNm = "";
            }
            if (string.IsNullOrEmpty(ServiceNm))
            {
                ServiceNm = VarGeneral.DBNo.Replace("DBPROSOFT_", null);
            }
            try
            {
                if (!Directory.Exists((string.IsNullOrEmpty(VarGeneral.Settings_Sys.DocumentPath) ? Application.StartupPath : VarGeneral.Settings_Sys.DocumentPath) + "\\" + ServiceNm))
                {
                    Directory.CreateDirectory((string.IsNullOrEmpty(VarGeneral.Settings_Sys.DocumentPath) ? Application.StartupPath : VarGeneral.Settings_Sys.DocumentPath) + "\\" + ServiceNm);
                }
            }
            catch
            {
            }
            try
            {
                if (!Directory.Exists((string.IsNullOrEmpty(VarGeneral.Settings_Sys.DocumentPath) ? Application.StartupPath : VarGeneral.Settings_Sys.DocumentPath) + "\\" + ServiceNm + "\\" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber))
                {
                    Directory.CreateDirectory((string.IsNullOrEmpty(VarGeneral.Settings_Sys.DocumentPath) ? Application.StartupPath : VarGeneral.Settings_Sys.DocumentPath) + "\\" + ServiceNm + "\\" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber);
                }
            }
            catch
            {
            }
            string subPath = (string.IsNullOrEmpty(VarGeneral.Settings_Sys.DocumentPath) ? Application.StartupPath : VarGeneral.Settings_Sys.DocumentPath) + "\\" + ServiceNm + "\\" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber + "\\EmpDocuments";
            if (!Directory.Exists(subPath))
            {
                Directory.CreateDirectory(subPath);
            }
            textBox_ID.Text = vEmpName;
            FillImageList();
        }
        protected override void OnParentRightToLeftChanged(EventArgs e)
        {
            if (VarGeneral.CurrentLang.ToString() == "0" || VarGeneral.CurrentLang.ToString() == "")
            {
                ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmScannerFiles));
                if (base.Parent.RightToLeft == RightToLeft.Yes)
                {
                    Language.ChangeLanguage("ar-SA", this, resources);
                    LangArEn = 0;
                }
                else
                {
                    Language.ChangeLanguage("en", this, resources);
                    LangArEn = 1;
                }
            }
        }
        public static string[] GetFilesFrom(string searchFolder, string[] filters, bool isRecursive)
        {
            List<string> filesFound = new List<string>();
            SearchOption searchOption = (isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
            foreach (string filter in filters)
            {
                filesFound.AddRange(Directory.GetFiles(searchFolder, $"*.{filter}", searchOption));
            }
            return filesFound.ToArray();
        }
        private void FillImageList()
        {
            try
            {
                listBox_ImageFiles.Items.Clear();
            }
            catch
            {
            }
            try
            {
                listBox_ImageFiles.DataSource = null;
            }
            catch
            {
            }
            try
            {
                string[] filters = new string[15]
                {
                    "jpeg",
                    "docx",
                    "BMP",
                    "JPG",
                    "GIF",
                    "PNG",
                    "TIF",
                    "PDF",
                    "PCX",
                    "TGA",
                    "JP2",
                    "JPC",
                    "RAS",
                    "PGX",
                    "PNM"
                };
                string[] filePaths = GetFilesFrom(string.IsNullOrEmpty(VarGeneral.Settings_Sys.DocumentPath) ? (Application.StartupPath + "\\" + ServiceNm + "\\" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber + "\\EmpDocuments") : (VarGeneral.Settings_Sys.DocumentPath + "\\" + ServiceNm + "\\" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber + "\\EmpDocuments"), filters, isRecursive: false);
                if (filePaths.Count() <= 0)
                {
                    return;
                }
                for (int i = 0; i < filePaths.Count(); i++)
                {
                    if (Path.GetFileName(filePaths[i]).StartsWith(vEmpNo))
                    {
                        listBox_ImageFiles.Items.Add(Path.GetFileName(filePaths[i]));
                    }
                }
                listBox_ImageFiles.Sorted = true;
            }
            catch
            {
            }
        }
        private void listBox_ImageFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listBox_ImageFiles.SelectedIndex != -1 && listBox_ImageFiles.Items.Count > 0)
                {
                    pictureBox_ScannerFile.Image = Image.FromFile(string.IsNullOrEmpty(VarGeneral.Settings_Sys.DocumentPath) ? (Application.StartupPath + "\\" + ServiceNm + "\\" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber + "\\EmpDocuments\\" + listBox_ImageFiles.Text) : (VarGeneral.Settings_Sys.DocumentPath + "\\" + ServiceNm + "\\" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber + "\\EmpDocuments\\" + listBox_ImageFiles.Text));
                    pictureBox_ScannerFile.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch
            {
                pictureBox_ScannerFile.Image = null;
            }
        }
        private void Button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button_Print_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox_ImageFiles.SelectedIndex != -1 && listBox_ImageFiles.Items.Count > 0)
                {
                    Process.Start(string.IsNullOrEmpty(VarGeneral.Settings_Sys.DocumentPath) ? (Application.StartupPath + "\\" + ServiceNm + "\\" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber + "\\EmpDocuments\\" + listBox_ImageFiles.Text) : (VarGeneral.Settings_Sys.DocumentPath + "\\" + ServiceNm + "\\" + VarGeneral.DBNo.Replace("DBPROSOFT", "PROSOFT") + "_" + VarGeneral.BranchNumber + "\\EmpDocuments\\" + listBox_ImageFiles.Text));
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("button_Print_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void FrmScannerFiles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void listBox_ImageFiles_DoubleClick(object sender, EventArgs e)
        {
            button_Print_Click(sender, e);
        }
    }
}
