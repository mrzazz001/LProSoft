using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using InputKey;
using ProShared.GeneralM;using ProShared;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial  class FrmNetWork : Form
    {
        void avs(int arln)

        {


            //button_Exit.Text = (arln == 0 ? "  خروج  " : "  Exit"); label1.Text = (arln == 0 ? "  خاصية ربط الشبكة بين نسخ البرنامج  " : "  Network connection feature between copies of the program"); labelX1.Text = (arln == 0 ? "  معالج التجكم في الخصائص الإضافية  " : "  Additional Features Control Wizard"); buttonX_Close.Text = (arln == 0 ? "  خروج مع الحفظ  " : "  Exit with save");
        }

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
        private Panel PanelSpecialContainer;
        public Softgroup.NetResize.NetResize netResize1;
        private RibbonBar ribbonBar1;
        private Panel panel1;
        private Label label1;
        private LabelX labelX1;
        private ButtonX buttonX_Close;
        private SwitchButton switchButton_Sts;
        private ButtonX button_Exit;
        private RegistryKey hKeyNeew = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", writable: true);
        private RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
        private int vSysType = 0;
        private string vSysTypName = "";
        public FrmNetWork(int vType, string vSub)
        {
            InitializeComponent();this.Load += langloads;
            label1.Text = vSub;
            try
            {
                if (hKey != null)
                {
                    try
                    {
                        object q = hKey.GetValue("vNW");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vNW");
                            hKey.SetValue("vNW", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vNW");
                        hKey.SetValue("vNW", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vNW_Electa");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vNW_Electa");
                            hKey.SetValue("vNW_Electa", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vNW_Electa");
                        hKey.SetValue("vNW_Electa", "0");
                    }
                    try
                    {
                        object q = hKeyNeew.GetValue("vNW_New");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKeyNeew.CreateSubKey("vNW_New");
                            hKeyNeew.SetValue("vNW_New", "0");
                        }
                    }
                    catch
                    {
                        hKeyNeew.CreateSubKey("vNW_New");
                        hKeyNeew.SetValue("vNW_New", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vSt");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vSt");
                            hKey.SetValue("vSt", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vSt");
                        hKey.SetValue("vSt", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vSt_Electa");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vSt_Electa");
                            hKey.SetValue("vSt_Electa", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vSt_Electa");
                        hKey.SetValue("vSt_Electa", "0");
                    }
                    try
                    {
                        object q = hKeyNeew.GetValue("vSt_New");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKeyNeew.CreateSubKey("vSt_New");
                            hKeyNeew.SetValue("vSt_New", "0");
                        }
                    }
                    catch
                    {
                        hKeyNeew.CreateSubKey("vSt_New");
                        hKeyNeew.SetValue("vSt_New", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vCoCe");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vCoCe");
                            hKey.SetValue("vCoCe", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vCoCe");
                        hKey.SetValue("vCoCe", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vCoCe_Electa");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vCoCe_Electa");
                            hKey.SetValue("vCoCe_Electa", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vCoCe_Electa");
                        hKey.SetValue("vCoCe_Electa", "0");
                    }
                    try
                    {
                        object q = hKeyNeew.GetValue("vCoCe_New");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKeyNeew.CreateSubKey("vCoCe_New");
                            hKeyNeew.SetValue("vCoCe_New", "0");
                        }
                    }
                    catch
                    {
                        hKeyNeew.CreateSubKey("vCoCe_New");
                        hKeyNeew.SetValue("vCoCe_New", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vBa");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vBa");
                            hKey.SetValue("vBa", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vBa");
                        hKey.SetValue("vBa", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vBa_Electa");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vBa_Electa");
                            hKey.SetValue("vBa_Electa", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vBa_Electa");
                        hKey.SetValue("vBa_Electa", "0");
                    }
                    try
                    {
                        object q = hKeyNeew.GetValue("vBa_New");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKeyNeew.CreateSubKey("vBa_New");
                            hKeyNeew.SetValue("vBa_New", "0");
                        }
                    }
                    catch
                    {
                        hKeyNeew.CreateSubKey("vBa_New");
                        hKeyNeew.SetValue("vBa_New", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vCsh");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vCsh");
                            hKey.SetValue("vCsh", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vCsh");
                        hKey.SetValue("vCsh", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vCsh_Electa");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vCsh_Electa");
                            hKey.SetValue("vCsh_Electa", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vCsh_Electa");
                        hKey.SetValue("vCsh_Electa", "0");
                    }
                    try
                    {
                        object q = hKeyNeew.GetValue("vCsh_New");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKeyNeew.CreateSubKey("vCsh_New");
                            hKeyNeew.SetValue("vCsh_New", "0");
                        }
                    }
                    catch
                    {
                        hKeyNeew.CreateSubKey("vCsh_New");
                        hKeyNeew.SetValue("vCsh_New", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vBkPeap");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vBkPeap");
                            hKey.SetValue("vBkPeap", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vBkPeap");
                        hKey.SetValue("vBkPeap", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vBkPeap_Electa");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vBkPeap_Electa");
                            hKey.SetValue("vBkPeap_Electa", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vBkPeap_Electa");
                        hKey.SetValue("vBkPeap_Electa", "0");
                    }
                    try
                    {
                        object q = hKeyNeew.GetValue("vBkPeap_New");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKeyNeew.CreateSubKey("vBkPeap_New");
                            hKeyNeew.SetValue("vBkPeap_New", "0");
                        }
                    }
                    catch
                    {
                        hKeyNeew.CreateSubKey("vBkPeap_New");
                        hKeyNeew.SetValue("vBkPeap_New", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vBr");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vBr");
                            hKey.SetValue("vBr", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vBr");
                        hKey.SetValue("vBr", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vBr_Electa");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vBr_Electa");
                            hKey.SetValue("vBr_Electa", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vBr_Electa");
                        hKey.SetValue("vBr_Electa", "0");
                    }
                    try
                    {
                        object q = hKeyNeew.GetValue("vBr_New");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKeyNeew.CreateSubKey("vBr_New");
                            hKeyNeew.SetValue("vBr_New", "0");
                        }
                    }
                    catch
                    {
                        hKeyNeew.CreateSubKey("vBr_New");
                        hKeyNeew.SetValue("vBr_New", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vDB");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vDB");
                            hKey.SetValue("vDB", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vDB");
                        hKey.SetValue("vDB", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vDB_Electa");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vDB_Electa");
                            hKey.SetValue("vDB_Electa", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vDB_Electa");
                        hKey.SetValue("vDB_Electa", "0");
                    }
                    try
                    {
                        object q = hKeyNeew.GetValue("vDB_New");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKeyNeew.CreateSubKey("vDB_New");
                            hKeyNeew.SetValue("vDB_New", "0");
                        }
                    }
                    catch
                    {
                        hKeyNeew.CreateSubKey("vDB_New");
                        hKeyNeew.SetValue("vDB_New", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vPOS");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vPOS");
                            hKey.SetValue("vPOS", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vPOS");
                        hKey.SetValue("vPOS", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vPOS_Electa");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vPOS_Electa");
                            hKey.SetValue("vPOS_Electa", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vPOS_Electa");
                        hKey.SetValue("vPOS_Electa", "0");
                    }
                    try
                    {
                        object q = hKeyNeew.GetValue("vPOS_New");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKeyNeew.CreateSubKey("vPOS_New");
                            hKeyNeew.SetValue("vPOS_New", "0");
                        }
                    }
                    catch
                    {
                        hKeyNeew.CreateSubKey("vPOS_New");
                        hKeyNeew.SetValue("vPOS_New", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vActiv");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vActiv");
                            hKey.SetValue("vActiv", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vActiv");
                        hKey.SetValue("vActiv", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vActiv_Electa");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vActiv_Electa");
                            hKey.SetValue("vActiv_Electa", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vActiv_Electa");
                        hKey.SetValue("vActiv_Electa", "0");
                    }
                    try
                    {
                        object q = hKeyNeew.GetValue("vActiv_New");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKeyNeew.CreateSubKey("vActiv_New");
                            hKeyNeew.SetValue("vActiv_New", "0");
                        }
                    }
                    catch
                    {
                        hKeyNeew.CreateSubKey("vActiv_New");
                        hKeyNeew.SetValue("vActiv_New", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vRemotly");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vRemotly");
                            hKey.SetValue("vRemotly", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vRemotly");
                        hKey.SetValue("vRemotly", "0");
                    }
                    try
                    {
                        object q = hKey.GetValue("vRemotly_Electa");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey("vRemotly_Electa");
                            hKey.SetValue("vRemotly_Electa", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey("vRemotly_Electa");
                        hKey.SetValue("vRemotly_Electa", "0");
                    }
                    try
                    {
                        object q = hKeyNeew.GetValue("vRemotly_New");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKeyNeew.CreateSubKey("vRemotly_New");
                            hKeyNeew.SetValue("vRemotly_New", "0");
                        }
                    }
                    catch
                    {
                        hKeyNeew.CreateSubKey("vRemotly_New");
                        hKeyNeew.SetValue("vRemotly_New", "0");
                    }
                    vSysType = vType;
                }
                else
                {
                    buttonX_Close_Click(null, null);
                }
            }
            catch
            {
                Environment.Exit(0);
            }
        }
        private void FrmNetWork_Load(object sender, EventArgs e)
        {
            if (vSysType == 0)
            {
                vSysTypName = "vNW";
            }
            else if (vSysType == 1)
            {
                vSysTypName = "vSt";
            }
            else if (vSysType == 2)
            {
                vSysTypName = "vCoCe";
            }
            else if (vSysType == 3)
            {
                vSysTypName = "vBa";
            }
            else if (vSysType == 4)
            {
                vSysTypName = "vCsh";
            }
            else if (vSysType == 5)
            {
                vSysTypName = "vBkPeap";
            }
            else if (vSysType == 6)
            {
                vSysTypName = "vBr";
            }
            else if (vSysType == 7)
            {
                vSysTypName = "vDB";
            }
            else if (vSysType == 8)
            {
                vSysTypName = "vPOS";
            }
            else if (vSysType == 9)
            {
                hKey.SetValue(vSysTypName, "1");
                hKey.SetValue(vSysTypName + "_Electa", "1");
                hKeyNeew.SetValue(vSysTypName + "_New", "1");
                vSysTypName = "vActiv";
            }
            else if (vSysType == 10)
            {
                vSysTypName = "vRemotly";
            }
            else if (vSysType == 13)
            {
                vSysTypName = "vMixWaiters";
            }
            else if (vSysType == 14)
            {
                vSysTypName = "vSM";
            }
            if (vSysType == 11)
            {
                return;
            }
            if (vSysType == 12)
            {
                buttonX_Close.Text = "ادخل اسماء اليوزرات";
                switchButton_Sts.Visible = false;
                return;
            }
            try
            {
                if (hKey != null)
                {
                    try
                    {
                        object q = hKey.GetValue(vSysTypName);
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey(vSysTypName);
                            hKey.SetValue(vSysTypName, "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey(vSysTypName);
                        hKey.SetValue(vSysTypName, "0");
                    }
                    try
                    {
                        object q = hKey.GetValue(vSysTypName + "_Electa");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKey.CreateSubKey(vSysTypName + "_Electa");
                            hKey.SetValue(vSysTypName + "_Electa", "0");
                        }
                    }
                    catch
                    {
                        hKey.CreateSubKey(vSysTypName + "_Electa");
                        hKey.SetValue(vSysTypName + "_Electa", "0");
                    }
                    try
                    {
                        object q = hKeyNeew.GetValue(vSysTypName + "_New");
                        if (string.IsNullOrEmpty(q.ToString()))
                        {
                            hKeyNeew.CreateSubKey(vSysTypName + "_New");
                            hKeyNeew.SetValue(vSysTypName + "_New", "0");
                        }
                    }
                    catch
                    {
                        hKeyNeew.CreateSubKey(vSysTypName + "_New");
                        hKeyNeew.SetValue(vSysTypName + "_New", "0");
                    }
                }
                else
                {
                    buttonX_Close_Click(null, null);
                }
                long regval = long.Parse(hKey.GetValue(vSysTypName).ToString());
                if (regval == 1)
                {
                    switchButton_Sts.Value = true;
                }
                else
                {
                    switchButton_Sts.Value = false;
                }
            }
            catch
            {
                Environment.Exit(0);
            }
        }
        private void buttonX_Close_Click(object sender, EventArgs e)
        {
            if (vSysType == 11)
            {
                if (switchButton_Sts.Value)
                {
                    hKey.SetValue("Lev", "F");
                    hKey.SetValue("Typ", "2");
                    hKey.SetValue("vBackupELEC", "");
                }
            }
            else if (vSysType == 12)
            {
                try
                {
                    string vNewNo = InputDialog.mostrar("أدخل اسماء اليوزارات بينهم فاصلة : ", "الدعم الفني");
                    if (!string.IsNullOrEmpty(vNewNo.Trim()))
                    {
                        try
                        {
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                            File.Delete(Application.StartupPath + "\\systemfile.txt");
                        }
                        catch
                        {
                        }
                        TextWriter tw = File.CreateText(Application.StartupPath + "\\systemfile.txt");
                        tw.WriteLine(VarGeneral.Encrypt(vNewNo.Trim()));
                        tw.Close();
                    }
                }
                catch
                {
                }
            }
            else if (switchButton_Sts.Value)
            {
                hKey.SetValue(vSysTypName, "1");
                hKey.SetValue(vSysTypName + "_Electa", "1");
                hKeyNeew.SetValue(vSysTypName + "_New", "1");
            }
            else
            {
                hKey.SetValue(vSysTypName, "0");
                hKey.SetValue(vSysTypName + "_Electa", "0");
                hKeyNeew.SetValue(vSysTypName + "_New", "0");
            }
            string arguments = string.Empty;
            string[] args = Environment.GetCommandLineArgs();
            for (int i = 1; i < args.Length; i++)
            {
                arguments = arguments + args[i] + " ";
            }
            Application.ExitThread();
            Process.Start(Application.ExecutablePath, arguments);
        }
        private void FrmNetWork_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                buttonX_Close_Click(sender, e);
            }
        }
        private void button_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void labelX1_Click(object sender, EventArgs e)
        {
        }
    }
}
