using DevComponents.DotNetBar;
using InvAcc.GeneralM;
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
    public partial class FrmScannerFiles : Form
    {
        private int LangArEn = 0;
        private string vEmpNo = "";
        private string vEmpName = "";
        private string ServiceNm = "";
        private IContainer components = null;
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
            InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvAcc.Forms.FrmScannerFiles));
            panel10 = new System.Windows.Forms.Panel();
            textBox_ID = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            listBox_ImageFiles = new System.Windows.Forms.ListBox();
            panel2 = new System.Windows.Forms.Panel();
            button_Print = new System.Windows.Forms.Button();
            Button_Close = new DevComponents.DotNetBar.ButtonX();
            pictureBox_ScannerFile = new System.Windows.Forms.PictureBox();
            panel10.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_ScannerFile).BeginInit();
            SuspendLayout();
            panel10.AccessibleDescription = null;
            panel10.AccessibleName = null;
            resources.ApplyResources(panel10, "panel10");
            panel10.BackgroundImage = null;
            panel10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            panel10.Controls.Add(textBox_ID);
            panel10.Controls.Add(label1);
            panel10.Font = null;
            panel10.Name = "panel10";
            textBox_ID.AccessibleDescription = null;
            textBox_ID.AccessibleName = null;
            resources.ApplyResources(textBox_ID, "textBox_ID");
            textBox_ID.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
            textBox_ID.BackgroundImage = null;
            textBox_ID.Name = "textBox_ID";
            textBox_ID.ReadOnly = true;
            label1.AccessibleDescription = null;
            label1.AccessibleName = null;
            resources.ApplyResources(label1, "label1");
            label1.Font = null;
            label1.Name = "label1";
            listBox_ImageFiles.AccessibleDescription = null;
            listBox_ImageFiles.AccessibleName = null;
            resources.ApplyResources(listBox_ImageFiles, "listBox_ImageFiles");
            listBox_ImageFiles.BackColor = System.Drawing.Color.Yellow;
            listBox_ImageFiles.BackgroundImage = null;
            listBox_ImageFiles.ForeColor = System.Drawing.Color.SteelBlue;
            listBox_ImageFiles.FormattingEnabled = true;
            listBox_ImageFiles.Name = "listBox_ImageFiles";
            listBox_ImageFiles.Sorted = true;
            listBox_ImageFiles.SelectedIndexChanged += new System.EventHandler(listBox_ImageFiles_SelectedIndexChanged);
            listBox_ImageFiles.DoubleClick += new System.EventHandler(listBox_ImageFiles_DoubleClick);
            panel2.AccessibleDescription = null;
            panel2.AccessibleName = null;
            resources.ApplyResources(panel2, "panel2");
            panel2.BackColor = System.Drawing.Color.Transparent;
            panel2.BackgroundImage = null;
            panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel2.Controls.Add(button_Print);
            panel2.Font = null;
            panel2.Name = "panel2";
            button_Print.AccessibleDescription = null;
            button_Print.AccessibleName = null;
            resources.ApplyResources(button_Print, "button_Print");
            button_Print.BackgroundImage = null;
            button_Print.Name = "button_Print";
            button_Print.UseVisualStyleBackColor = true;
            button_Print.Click += new System.EventHandler(button_Print_Click);
            Button_Close.AccessibleDescription = null;
            Button_Close.AccessibleName = null;
            Button_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            resources.ApplyResources(Button_Close, "Button_Close");
            Button_Close.BackgroundImage = null;
            Button_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            Button_Close.CommandParameter = null;
            Button_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            Button_Close.Name = "Button_Close";
            Button_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            Button_Close.Symbol = "\uf011";
            Button_Close.TextColor = System.Drawing.Color.White;
            Button_Close.Click += new System.EventHandler(Button_Close_Click);
            pictureBox_ScannerFile.AccessibleDescription = null;
            pictureBox_ScannerFile.AccessibleName = null;
            resources.ApplyResources(pictureBox_ScannerFile, "pictureBox_ScannerFile");
            pictureBox_ScannerFile.BackColor = System.Drawing.Color.White;
            pictureBox_ScannerFile.BackgroundImage = null;
            pictureBox_ScannerFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBox_ScannerFile.Font = null;
            pictureBox_ScannerFile.ImageLocation = null;
            pictureBox_ScannerFile.Name = "pictureBox_ScannerFile";
            pictureBox_ScannerFile.TabStop = false;
            base.AccessibleDescription = null;
            base.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            BackgroundImage = null;
            base.ControlBox = false;
            base.Controls.Add(Button_Close);
            base.Controls.Add(panel2);
            base.Controls.Add(panel10);
            base.Controls.Add(listBox_ImageFiles);
            base.Controls.Add(pictureBox_ScannerFile);
            Font = null;
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            base.KeyPreview = true;
            base.MaximizeBox = false;
            base.Name = "FrmScannerFiles";
            base.Load += new System.EventHandler(FrmScannerFiles_Load);
            base.KeyDown += new System.Windows.Forms.KeyEventHandler(FrmScannerFiles_KeyDown);
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox_ScannerFile).EndInit();
            ResumeLayout(false);
        }
    }
}
