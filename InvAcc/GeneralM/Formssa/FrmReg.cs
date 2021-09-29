using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using InvAcc.GeneralM;
using Microsoft.Win32;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Management;
using System.Windows.Forms;
namespace InvAcc.Forms
{
    public partial class FrmReg : Form
    {
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
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
            //this.WindowState = FormWindowState.Minimized;
            //this.WindowState = FormWindowState.Maximized;
        }
        private void FrmInvSale_SizeChanged(object sender, EventArgs e)
        {
            netResize1.Refresh();
        }
        public Softgroup.NetResize.NetResize netResize1;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Panel panel1;
        protected BubbleBar bubbleBar_Cancel;
        protected BubbleBarTab bubbleBarTab4;
        protected BubbleButton bubbleButton_Cancel;
        protected BubbleBar bubbleBar_Ok;
        protected BubbleBarTab bubbleBarTab1;
        protected BubbleButton bubbleButton_Ok;
        protected BubbleBar bubbleBar_Leave;
        protected BubbleBarTab bubbleBarTab2;
        protected BubbleButton bubbleButton_Print;
        private DevComponents.DotNetBar.TabControl tabControl1;
        private TabControlPanel tabControlPanel1;
        private Label label29;
        private TabItem tabItem1;
        private TabControlPanel tabControlPanel3;
        private GroupBox groupBox1;
        private TextBox txtRunNo;
        private Label label10;
        private TextBox txtSerNo;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private TextBox txtProName;
        private TextBox txtDiskInfo;
        private TextBox txtWindowsName;
        private TextBox txtBIOSId;
        private TextBox txtProcessorId;
        private TabItem tabItem3;
        private TextBox txtDiskSerNo;
        private Panel panel4;
        private Label label40;
        private TextBox textBox_Email;
        private Label label41;
        private TextBox textBox_ActivatedCompany;
        private Label label43;
        private TextBox textBox_City;
        private Label label44;
        private TextBox txtPost;
        private Label label45;
        private TextBox txtPOBOX;
        private Label label46;
        private TextBox txtMobile;
        private Label label47;
        private TextBox txtFax;
        private Label label48;
        private TextBox txtTel;
        private Label label49;
        private TextBox txtPrsName;
        private Label label50;
        private TextBox txtCsutName;
        private Panel panel3;
        private Label label28;
        private TextBox txt_PaidInvDate;
        private Label label31;
        private TextBox txt_PaidInv;
        private Label label32;
        private TextBox txt_PaidFax;
        private Label label33;
        private TextBox txt_PaidTel;
        private Label label34;
        private TextBox txt_PaidCity;
        private Label label35;
        private TextBox txt_PaidPlace;
        private Label label20;
        private Label label21;
        private PictureBox Picture_SSS;
        private GroupPanel groupPanel1;
        private CheckBox checkBox1;
        private TextBox textBox9;
        private C1.Win.C1Input.C1Button c1Button1;
        private Label label1;
        public FrmReg()
        {
            InitializeComponent();
            try
            {
                txtProName.Text = Application.ProductName + "  " + Application.ProductVersion;
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS");
                try
                {
                    ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = searcher.Get().GetEnumerator();
                    if (managementObjectEnumerator.MoveNext())
                    {
                        ManagementObject wmi_HD = (ManagementObject)managementObjectEnumerator.Current;
                        if (string.Concat(wmi_HD["SerialNumber"]).Trim() != "")
                        {
                            txtBIOSId.Text = wmi_HD["SerialNumber"].ToString();
                        }
                        else if (wmi_HD["Version"] == null)
                        {
                            txtBIOSId.Text = "None";
                        }
                        else
                        {
                            txtBIOSId.Text = wmi_HD["Version"].ToString().Trim();
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
                    ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = searcher.Get().GetEnumerator();
                    if (managementObjectEnumerator.MoveNext())
                    {
                        ManagementObject wmi_HD = (ManagementObject)managementObjectEnumerator.Current;
                        txtProcessorId.Text = wmi_HD["ProcessorId"].ToString();
                    }
                }
                catch
                {
                }
                try
                {
                    searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
                    ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = searcher.Get().GetEnumerator();
                    if (managementObjectEnumerator.MoveNext())
                    {
                        ManagementObject wmi_HD = (ManagementObject)managementObjectEnumerator.Current;
                        txtWindowsName.Text = wmi_HD["Caption"].ToString();
                    }
                }
                catch
                {
                }
                try
                {
                    searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
                    ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = searcher.Get().GetEnumerator();
                    if (managementObjectEnumerator.MoveNext())
                    {
                        ManagementObject wmi_HD = (ManagementObject)managementObjectEnumerator.Current;
                        if (wmi_HD["Caption"] != null)
                        {
                            txtDiskInfo.Text = wmi_HD["Caption"].ToString().Trim();
                        }
                        else if (wmi_HD["Model"] == null)
                        {
                            txtDiskInfo.Text = "None";
                        }
                        else
                        {
                            txtDiskInfo.Text = wmi_HD["Model"].ToString().Trim();
                        }
                    }
                }
                catch
                {
                }
                try
                {
                    searcher = new ManagementObjectSearcher("SELECT * FROM Win32_LogicalDisk");
                    foreach (ManagementObject wmi_HD in searcher.Get())
                    {
                        if (string.Concat(wmi_HD["Caption"]) == "C:")
                        {
                            txtDiskSerNo.Text = Math.Abs(Convert.ToInt32(wmi_HD["VolumeSerialNumber"].ToString().Trim(), 16)).ToString();
                            break;
                        }
                    }
                }
                catch
                {
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("LoadReg:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        public void disableactivation()
        {
            c1Button1.Visible = true;
            txtSerNo.ReadOnly = true;
            txtRunNo.ReadOnly = true;
            bubbleBar_Ok.Enabled = false;
        }
        public void copyreg(string run, string ser)
        {
            RegistryKey hKeyNew = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", writable: true);
            RegistryKey hKeyElc = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
            RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\MrdSoft\\Register", writable: true);
            long regval = long.Parse(hKey.GetValue("SSSActivationNo").ToString());
            string SerHrd = txtDiskSerNo.Text;
            if (run == long.Parse(RetScrt1(SerHrd)).ToString())
            {
                hKey.SetValue("SSSActivationNo", long.Parse(run));
                hKey.SetValue("DT", "DONE");
                hKey.SetValue("vSr", ser.Trim().ToUpper());
                try
                {
                    if (VarGeneral.vDemo)
                    {
                        hKeyElc.SetValue("vMixWaiters", "0");
                        hKeyElc.SetValue("vMixWaiters_Electa", "0");
                        hKeyNew.SetValue("vMixWaiters_New", "0");
                    }
                }
                catch
                {
                }
                FrmBackupElectDate fa = new FrmBackupElectDate(0);
                fa.TopMost = true;
                fa.ShowDialog();
            }
            else
            {
                MessageBox.Show("المفتاح غير صالح");
            }
        }
        private void bubbleButton_Ok_Click(object sender, ClickEventArgs e)
        {
            try
            {
                if (Picture_SSS.Visible)
                {
                    MessageBox.Show("لايمكنك تفعيل النسخة .. تحتاج الى ملف التفعيل الخاص بالمنتج لإتمام العملية.. \n يرجى الإتصال بالإدارة للحصول على ملف التفعيل", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (!checkBox1.Checked)
                {
                    MessageBox.Show("يجب الموافقة على جميع شروط المنتج", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    checkBox1.Focus();
                }
                else if (txtDiskSerNo.Text == "")
                {
                    MessageBox.Show("خانة رقم المنتج فارغة .. يرجى مراجعة الادارة بالمشكلة", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    tabItem3.AttachedControl.Select();
                    txtDiskSerNo.Focus();
                }
                else if (txtRunNo.Text == "")
                {
                    MessageBox.Show("يرجى التأكد من ان لا يكون خانة كود التفعيل فارغا\u064c", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    tabItem3.AttachedControl.Select();
                    txtRunNo.Focus();
                }
                else if (txtSerNo.Text == "")
                {
                    MessageBox.Show("يرجى التأكد من ان لا يكون خانة كود التسلسل فارغا\u064c", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    tabItem3.AttachedControl.Select();
                    txtSerNo.Focus();
                }
                else if (txtSerNo.Text.Length != 10)
                {
                    MessageBox.Show("يرجى التأكد من ان لا يكون خانة كود التسلسل فارغا\u064c", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    tabItem3.AttachedControl.Select();
                    txtSerNo.Focus();
                }
                else if (VarGeneral.SSSLev == "G")
                {
                    if (VarGeneral.SSSTyp == 0)
                    {
                        if (!(txtSerNo.Text.Substring(3, 3) != "00W"))
                        {
                            goto IL_081e;
                        }
                        MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        tabItem3.AttachedControl.Select();
                        txtSerNo.Focus();
                    }
                    else if (VarGeneral.SSSTyp == 1)
                    {
                        if (!(txtSerNo.Text.Substring(3, 3) != "01I"))
                        {
                            goto IL_081e;
                        }
                        MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        tabItem3.AttachedControl.Select();
                        txtSerNo.Focus();
                    }
                    else
                    {
                        if (!(txtSerNo.Text.Substring(3, 3) != "02G"))
                        {
                            goto IL_081e;
                        }
                        MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        tabItem3.AttachedControl.Select();
                        txtSerNo.Focus();
                    }
                }
                else if (VarGeneral.SSSLev == "S")
                {
                    if (!(txtSerNo.Text.Substring(3, 3) != "02S"))
                    {
                        goto IL_081e;
                    }
                    MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    tabItem3.AttachedControl.Select();
                    txtSerNo.Focus();
                }
                else if (VarGeneral.SSSLev == "B")
                {
                    if (!(txtSerNo.Text.Substring(3, 3) != "02B"))
                    {
                        goto IL_081e;
                    }
                    MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    tabItem3.AttachedControl.Select();
                    txtSerNo.Focus();
                }
                else if (VarGeneral.SSSLev == "F")
                {
                    if (!(txtSerNo.Text.Substring(3, 3) != "02F"))
                    {
                        goto IL_081e;
                    }
                    MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    tabItem3.AttachedControl.Select();
                    txtSerNo.Focus();
                }
                else if (VarGeneral.SSSLev == "C")
                {
                    if (!(txtSerNo.Text.Substring(3, 3) != "02C"))
                    {
                        goto IL_081e;
                    }
                    MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    tabItem3.AttachedControl.Select();
                    txtSerNo.Focus();
                }
                else if (VarGeneral.SSSLev == "D")
                {
                    if (!(txtSerNo.Text.Substring(3, 3) != "02D"))
                    {
                        goto IL_081e;
                    }
                    MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    tabItem3.AttachedControl.Select();
                    txtSerNo.Focus();
                }
                else if (VarGeneral.SSSLev == "E")
                {
                    if (!(txtSerNo.Text.Substring(3, 3) != "01E"))
                    {
                        goto IL_081e;
                    }
                    MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    tabItem3.AttachedControl.Select();
                    txtSerNo.Focus();
                }
                else if (VarGeneral.SSSLev == "R")
                {
                    if (!(txtSerNo.Text.Substring(3, 3) != "02R"))
                    {
                        goto IL_081e;
                    }
                    MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    tabItem3.AttachedControl.Select();
                    txtSerNo.Focus();
                }
                else if (VarGeneral.SSSLev == "H")
                {
                    if (!(txtSerNo.Text.Substring(3, 3) != "02H"))
                    {
                        goto IL_081e;
                    }
                    MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    tabItem3.AttachedControl.Select();
                    txtSerNo.Focus();
                }
                else if (VarGeneral.SSSLev == "X")
                {
                    if (!(txtSerNo.Text.Substring(3, 3) != "01X"))
                    {
                        goto IL_081e;
                    }
                    MessageBox.Show("السيريال نمبر الذي ادخلته لا يتوافق مع هذا النظام ,تأكد من صحة السيريال ثم حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    tabItem3.AttachedControl.Select();
                    txtSerNo.Focus();
                }
                else if (VarGeneral.SSSLev == "K")
                {
                    if (!(txtSerNo.Text.Substring(3, 3) != "00K"))
                    {
                        goto IL_081e;
                    }
                    MessageBox.Show("لقد تم تفعيل أحد برامجنا على جهازك هذا ومن ثم قمت بتغيير النسخة دون الرجوع الى الإدارة.. لترقية نظامك يرجى التحدث مع الإدارة", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Environment.Exit(0);
                }
                else
                {
                    if (!(VarGeneral.SSSLev == "Z") || !(txtSerNo.Text.Substring(3, 3) != "01Z"))
                    {
                        goto IL_081e;
                    }
                    MessageBox.Show("لقد تم تفعيل أحد برامجنا على جهازك هذا ومن ثم قمت بتغيير النسخة دون الرجوع الى الإدارة.. لترقية نظامك يرجى التحدث مع الإدارة", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Environment.Exit(0);
                }
                goto end_IL_0001;
            IL_081e:
                RegistryKey hKeyNew = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", writable: true);
                RegistryKey hKeyElc = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
                RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\MrdSoft\\Register", writable: true);
                long regval = long.Parse(hKey.GetValue("SSSActivationNo").ToString());
                string SerHrd = txtDiskSerNo.Text;
                if (txtRunNo.Text == long.Parse(RetScrt1(SerHrd)).ToString())
                {
                    hKey.SetValue("SSSActivationNo", long.Parse(txtRunNo.Text));
                    hKey.SetValue("DT", "DONE");
                    hKey.SetValue("vSr", txtSerNo.Text.Trim().ToUpper());
                    try
                    {
                        if (VarGeneral.vDemo)
                        {
                            hKeyElc.SetValue("vMixWaiters", "0");
                            hKeyElc.SetValue("vMixWaiters_Electa", "0");
                            hKeyNew.SetValue("vMixWaiters_New", "0");
                        }
                    }
                    catch
                    {
                    }
                    FrmBackupElectDate fa = new FrmBackupElectDate(0);
                    fa.ShowDialog();
                    MessageBox.Show("مبروووك .. لقد تم تفعيل نسختك الخاصة بنجاح .. \n لا تنسى .. طباعة استمارة التسجيل قبل إغلاق النافذة", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    VarGeneral.vDemo = false;
                    string arguments = string.Empty;
                    string[] args = Environment.GetCommandLineArgs();
                    for (int i = 1; i < args.Length; i++)
                    {
                        arguments = arguments + args[i] + " ";
                    }
                    Application.ExitThread();
                    Process.Start(Application.ExecutablePath, arguments);
                }
                else
                {
                    MessageBox.Show("هناك خطأ ... كود التفعيل الذي ادخلته غير صحيح .. حاول مرة اخرى", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtRunNo.Focus();
                }
            end_IL_0001:;
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("bubbleButton_Ok_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private string RetScrt1(string pNo)
        {
            string RetScrt = "";
            try
            {
                if (pNo == "" || !Program.sIsNumeric(pNo))
                {
                    return RetScrt;
                }
                int ii = 0;
                int jj = 0;
                int lnNo = 0;
                string retNo = "";
                string TretNo = "";
                lnNo = pNo.Length + 1;
                for (ii = 1; ii <= lnNo; ii++)
                {
                    TretNo = "";
                    jj = 0;
                    while (TretNo.Length <= lnNo)
                    {
                        jj++;
                        if (Program.sIsNumeric(pNo.Substring(jj, 1)))
                        {
                            TretNo += (double)(int.Parse(pNo.Substring(jj, 1)) * ii) * 0.1651;
                        }
                    }
                    retNo = ((!(TretNo.Substring(ii, 1) == ".")) ? (retNo + TretNo.Substring(ii, 1)) : (retNo + (ii * 45).ToString().Substring(2)));
                }
                RetScrt = retNo.Substring(0, lnNo - 1).ToString();
                return RetScrt;
            }
            catch
            {
                return RetScrt;
            }
        }
        private void bubbleButton_Cancel_Click(object sender, ClickEventArgs e)
        {
            RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\MrdSoft\\Register", writable: true);
            long regval = long.Parse(VarGeneral.TString.TEmpty(string.Concat(hKey.GetValue("SSSActivationNo"))));
            try
            {
                string SerHrd = txtDiskSerNo.Text;
                if (txtRunNo.Text == long.Parse(RetScrt1(SerHrd)).ToString())
                {
                    goto IL_038e;
                }
            }
            catch
            {
            }
            try
            {
                string dt = hKey.GetValue("DT").ToString();
                try
                {
                    if (!Program.sIsNumeric(dt.Substring(2, 1)))
                    {
                        dt = dt.Substring(6, 4) + "/" + dt.Substring(3, 2) + "/" + dt.Substring(0, 2);
                    }
                    if (dt.Substring(8, 2) == "31")
                    {
                        dt = ((!(dt.Substring(5, 2) != "12")) ? (int.Parse(dt.Substring(0, 4)) + 1 + "/01/01") : (dt.Substring(0, 4) + "/" + $"{int.Parse(dt.Substring(5, 2)) + 1:00}" + "/01"));
                    }
                    if (int.Parse(Convert.ToDateTime(DateTime.Now).ToString("yyyy/MM/dd").Substring(0, 4)) < 1900)
                    {
                        if (n.IsGreg(dt))
                        {
                            dt = n.GregToHijri(dt, "yyyy/MM/dd");
                        }
                    }
                    else if (n.IsHijri(dt))
                    {
                        dt = n.HijriToGreg(dt, "yyyy/MM/dd");
                    }
                }
                catch
                {
                    dt = hKey.GetValue("DT").ToString();
                }
                if (dt != "DONE" && Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd")) > Convert.ToDateTime(Convert.ToDateTime(dt).AddMonths(1).ToString("yyyy/MM/dd")))
                {
                    MessageBox.Show("نأسف .. لقد انتهت الفترة التجريبية للمنتج .. يرجى التواصل مع الادارة لشراء النسخة \n " + VarGeneral.vCompany + "\n" + VarGeneral.vAboutAddress2 + "\n" + VarGeneral.vAboutWeb + "\n" + VarGeneral.vAboutEmail, VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Application.Exit();
                    return;
                }
            }
            catch
            {
            }
            if (regval <= 60)
            {
                hKey.SetValue("SSSActivationNo", regval + 1);
                Close();
                return;
            }
            MessageBox.Show("نأسف .. لقد انتهت الفترة التجريبية للمنتج .. يرجى التواصل مع الادارة لشراء النسخة \n " + VarGeneral.vCompany + "\n" + VarGeneral.vAboutAddress2 + "\n" + VarGeneral.vAboutWeb + "\n" + VarGeneral.vAboutEmail, VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            Application.Exit();
            return;
        IL_038e:
            Close();
        }
        private void bubbleButton_Print_Click(object sender, ClickEventArgs e)
        {
            try
            {
                if (Picture_SSS.Visible)
                {
                    MessageBox.Show("لايمكنك طباعة الإستمارة .. تحتاج الى ملف التفعيل الخاص بالمنتج لإتمام العملية.. \n يرجى الإتصال بالإدارة للحصول على ملف التفعيل", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                string[] txtReg = new string[25];
                if (!checkBox1.Checked)
                {
                    MessageBox.Show("يجب الموافقة على جميع شروط المنتج", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    checkBox1.Focus();
                    return;
                }
                if (txtCsutName.Text == "")
                {
                    MessageBox.Show("هناك خطأ.. يجب عليك كتابة اسم المنشأة قبل الطباعة", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    tabItem1.AttachedControl.Select();
                    txtCsutName.Focus();
                    return;
                }
                if (txtCsutName.Text == "")
                {
                    MessageBox.Show("هناك خطأ., يجب عليك تحديد اسم العميل المسؤول قبل الطباعة", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    tabItem1.AttachedControl.Select();
                    txtCsutName.Focus();
                    return;
                }
                if (txtMobile.Text == "")
                {
                    MessageBox.Show("هناك خطأ., يجب عليك كتابة رقم موبايل العميل قبل الطباعة", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    tabItem1.AttachedControl.Select();
                    txtMobile.Focus();
                    return;
                }
                if (txtDiskSerNo.Text == "")
                {
                    MessageBox.Show("خانة رقم المنتج فارغة .. يرجى مراجعة الادارة بالمشكلة", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    tabItem3.AttachedControl.Select();
                    txtDiskSerNo.Focus();
                    return;
                }
                if (txtRunNo.Text == "")
                {
                    MessageBox.Show("يرجى التأكد من ان لا يكون خانة كود الفعيل فارغا\u064c", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    tabItem3.AttachedControl.Select();
                    txtRunNo.Focus();
                    return;
                }
                if (txtSerNo.Text == "")
                {
                    MessageBox.Show("هناك خطأ ... يجب عليك كتابة كود التسلسل قبل الطباعة", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    tabItem3.AttachedControl.Select();
                    txtSerNo.Focus();
                    return;
                }
                RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\MrdSoft\\Register", writable: true);
                long regval = long.Parse(hKey.GetValue("SSSActivationNo").ToString());
                string SerHrd = txtDiskSerNo.Text;
                if (txtRunNo.Text != long.Parse(RetScrt1(SerHrd)).ToString())
                {
                    MessageBox.Show("هناك خطأ ...يجب عليك تفعيل المنتج ثم طباعة استمارة التسجيل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtRunNo.Focus();
                    return;
                }
                FrmReportsViewer frm = new FrmReportsViewer();
                frm.Tag = 0;
                frm.Repvalue = "RegRep";
                try
                {
                    VarGeneral.AutoAlarmitms = new List<string>();
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms.Add("");
                    VarGeneral.AutoAlarmitms[1] = txtCsutName.Text;
                    VarGeneral.AutoAlarmitms[2] = "";
                    VarGeneral.AutoAlarmitms[3] = txtPrsName.Text;
                    VarGeneral.AutoAlarmitms[4] = textBox_ActivatedCompany.Text;
                    VarGeneral.AutoAlarmitms[5] = txtTel.Text;
                    VarGeneral.AutoAlarmitms[6] = txtFax.Text;
                    VarGeneral.AutoAlarmitms[7] = txtMobile.Text;
                    VarGeneral.AutoAlarmitms[8] = textBox_Email.Text;
                    VarGeneral.AutoAlarmitms[9] = textBox_City.Text;
                    VarGeneral.AutoAlarmitms[11] = txtPOBOX.Text;
                    VarGeneral.AutoAlarmitms[12] = txtPost.Text;
                    VarGeneral.AutoAlarmitms[13] = txt_PaidPlace.Text;
                    VarGeneral.AutoAlarmitms[14] = txt_PaidCity.Text;
                    VarGeneral.AutoAlarmitms[15] = txt_PaidInv.Text;
                    VarGeneral.AutoAlarmitms[16] = txt_PaidInvDate.Text;
                    VarGeneral.AutoAlarmitms[17] = VarGeneral.ProdectNam;
                    VarGeneral.AutoAlarmitms[18] = VarGeneral.ProdectNo;
                    VarGeneral.AutoAlarmitms[19] = txtDiskSerNo.Text;
                    VarGeneral.AutoAlarmitms[20] = txtSerNo.Text;
                    VarGeneral.AutoAlarmitms[21] = txtRunNo.Text;
                    VarGeneral.AutoAlarmitms[22] = txtWindowsName.Text;
                    VarGeneral.AutoAlarmitms[23] = txtProcessorId.Text;
                    VarGeneral.AutoAlarmitms[24] = txtDiskInfo.Text;
                    VarGeneral.AutoAlarmitms[25] = txtBIOSId.Text;
                }
                catch
                {
                }
                frm.TopMost = true;
                frm.ShowDialog();
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("bubbleButton_Print_Click:", error, enable: true);
                MessageBox.Show(error.Message);
            }
        }
        private void txtRunNo_Click(object sender, EventArgs e)
        {
            txtRunNo.SelectAll();
        }
        private void txtDiskSerNo_Click(object sender, EventArgs e)
        {
            txtDiskSerNo.SelectAll();
        }
        private void Frm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                SendKeys.Send("{Tab}");
            }
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                bubbleButton_Cancel_Click(null, null);
            }
        }
        private void FrmReg_Load(object sender, EventArgs e)
        {
            if (VarGeneral.UserID != 1) disableactivation();
            try
            {
                RegistryKey SSS = Registry.CurrentUser.OpenSubKey("Software\\SystemSupportedFile\\Files\\ActivFile", writable: true);
                if (SSS == null)
                {
                    SSS = Registry.CurrentUser.OpenSubKey("Software\\SystemSupportedFile", writable: true);
                    if (SSS != null)
                    {
                        SSS = Registry.CurrentUser.OpenSubKey("Software\\SystemSupportedFile\\Files", writable: true);
                        if (SSS == null)
                        {
                            SSS = Registry.CurrentUser.OpenSubKey("Software\\SystemSupportedFile", writable: true);
                            SSS.CreateSubKey("Files");
                            SSS = Registry.CurrentUser.OpenSubKey("Software\\SystemSupportedFile\\Files", writable: true);
                            SSS.CreateSubKey("ActivFile");
                            SSS = Registry.CurrentUser.OpenSubKey("Software\\SystemSupportedFile\\Files\\ActivFile", writable: true);
                            SSS.SetValue("sFile", "0");
                            SSS.Close();
                        }
                        else
                        {
                            SSS = Registry.CurrentUser.OpenSubKey("Software\\SystemSupportedFile\\Files\\ActivFile", writable: true);
                            if (SSS == null)
                            {
                                SSS = Registry.CurrentUser.OpenSubKey("Software\\SystemSupportedFile\\Files", writable: true);
                                SSS.CreateSubKey("ActivFile");
                                SSS = Registry.CurrentUser.OpenSubKey("Software\\SystemSupportedFile\\Files\\ActivFile", writable: true);
                                SSS.SetValue("sFile", "0");
                                SSS.Close();
                            }
                        }
                    }
                    else
                    {
                        SSS = Registry.CurrentUser.OpenSubKey("Software", writable: true);
                        if (SSS != null)
                        {
                            SSS.CreateSubKey("SystemSupportedFile");
                            SSS = Registry.CurrentUser.OpenSubKey("Software\\SystemSupportedFile", writable: true);
                            SSS.CreateSubKey("Files");
                            SSS = Registry.CurrentUser.OpenSubKey("Software\\SystemSupportedFile\\Files", writable: true);
                            SSS.CreateSubKey("ActivFile");
                            SSS = Registry.CurrentUser.OpenSubKey("Software\\SystemSupportedFile\\Files\\ActivFile", writable: true);
                            SSS.SetValue("sFile", "0");
                            SSS.Close();
                        }
                    }
                }
            }
            catch
            {
            }
            try
            {
                RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
                if (hKey != null)
                {
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
                    long regval = long.Parse(hKey.GetValue("vActiv").ToString());
                    if (regval == 1)
                    {
                        Picture_SSS.Visible = false;
                    }
                    else
                    {
                        Picture_SSS.Visible = true;
                    }
                }
                else
                {
                    Picture_SSS.Visible = true;
                }
            }
            catch
            {
                Picture_SSS.Visible = true;
            }
            try
            {
                RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\MrdSoft\\Register", writable: true);
                long regval = long.Parse(hKey.GetValue("SSSActivationNo").ToString());
                string SerHrd = txtDiskSerNo.Text;
                txtRunNo.Text = regval.ToString();
                if (txtRunNo.Text == long.Parse(RetScrt1(SerHrd)).ToString())
                {
                    txtSerNo.Text = hKey.GetValue("vSr").ToString();
                    bubbleButton_Cancel.Visible = false;
                    checkBox1.Checked = true;
                }
                else
                {
                    txtSerNo.Text = "";
                    txtRunNo.Text = "";
                    checkBox1.Checked = false;
                }
            }
            catch
            {
                txtSerNo.Text = "";
                txtRunNo.Text = "";
            }
        }
        private void txtSerNo_Click(object sender, EventArgs e)
        {
            txtSerNo.SelectAll();
        }
        private void txtSerNo_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        private void txtRunNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }
        private void txtSerNo_TextChanged(object sender, EventArgs e)
        {
        }
        private void groupPanel1_Click(object sender, EventArgs e)
        {
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReg));
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bubbleBar_Cancel = new DevComponents.DotNetBar.BubbleBar();
            this.bubbleBarTab4 = new DevComponents.DotNetBar.BubbleBarTab(this.components);
            this.bubbleButton_Cancel = new DevComponents.DotNetBar.BubbleButton();
            this.bubbleBar_Ok = new DevComponents.DotNetBar.BubbleBar();
            this.bubbleBarTab1 = new DevComponents.DotNetBar.BubbleBarTab(this.components);
            this.bubbleButton_Ok = new DevComponents.DotNetBar.BubbleButton();
            this.bubbleBar_Leave = new DevComponents.DotNetBar.BubbleBar();
            this.bubbleBarTab2 = new DevComponents.DotNetBar.BubbleBarTab(this.components);
            this.bubbleButton_Print = new DevComponents.DotNetBar.BubbleButton();
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.Picture_SSS = new System.Windows.Forms.PictureBox();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDiskInfo = new System.Windows.Forms.TextBox();
            this.txtWindowsName = new System.Windows.Forms.TextBox();
            this.txtBIOSId = new System.Windows.Forms.TextBox();
            this.txtProcessorId = new System.Windows.Forms.TextBox();
            this.txtDiskSerNo = new System.Windows.Forms.TextBox();
            this.txtRunNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSerNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtProName = new System.Windows.Forms.TextBox();
            this.tabItem3 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label28 = new System.Windows.Forms.Label();
            this.txt_PaidInvDate = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.txt_PaidInv = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.txt_PaidFax = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.txt_PaidTel = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.txt_PaidCity = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.txt_PaidPlace = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label40 = new System.Windows.Forms.Label();
            this.textBox_Email = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.textBox_ActivatedCompany = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.textBox_City = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.txtPost = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.txtPOBOX = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.txtPrsName = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.txtCsutName = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.c1Button1 = new C1.Win.C1Input.C1Button();
            this.netResize1 = new Softgroup.NetResize.NetResize(this.components);
            this.netResize1.AfterControlResize += new Softgroup.NetResize.NetResize.AfterControlResizeEventHandler(this.netResize1_AfterControlResize);
            this.Shown += new System.EventHandler(this.FrmInvSale_Shown);
            this.SizeChanged += new System.EventHandler(this.FrmInvSale_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bubbleBar_Cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bubbleBar_Ok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bubbleBar_Leave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Picture_SSS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1Button1)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(323, 214);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 18);
            this.label9.TabIndex = 15;
            this.label9.Text = "مفتاح التشغيل";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(323, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(141, 18);
            this.label8.TabIndex = 13;
            this.label8.Text = "الرقم التسلسلي";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(323, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 18);
            this.label7.TabIndex = 11;
            this.label7.Text = "رقم المنتج";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(323, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "رقم القرص الصلب";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(323, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "رقم المعالج";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(323, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "رقم اللوحة الأم";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(323, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "نظام التشغيل";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(323, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "أسم المنتج";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.bubbleBar_Cancel);
            this.panel1.Controls.Add(this.bubbleBar_Ok);
            this.panel1.Controls.Add(this.bubbleBar_Leave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 396);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel1.Size = new System.Drawing.Size(559, 61);
            this.panel1.TabIndex = 862;
            // 
            // bubbleBar_Cancel
            // 
            this.bubbleBar_Cancel.Alignment = DevComponents.DotNetBar.eBubbleButtonAlignment.Top;
            this.bubbleBar_Cancel.AntiAlias = true;
            // 
            // 
            // 
            this.bubbleBar_Cancel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.bubbleBar_Cancel.ButtonBackAreaStyle.BorderBottomWidth = 1;
            this.bubbleBar_Cancel.ButtonBackAreaStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.bubbleBar_Cancel.ButtonBackAreaStyle.BorderLeftWidth = 1;
            this.bubbleBar_Cancel.ButtonBackAreaStyle.BorderRightWidth = 1;
            this.bubbleBar_Cancel.ButtonBackAreaStyle.BorderTopWidth = 1;
            this.bubbleBar_Cancel.ButtonBackAreaStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.bubbleBar_Cancel.ButtonBackAreaStyle.PaddingBottom = 3;
            this.bubbleBar_Cancel.ButtonBackAreaStyle.PaddingLeft = 3;
            this.bubbleBar_Cancel.ButtonBackAreaStyle.PaddingRight = 3;
            this.bubbleBar_Cancel.ButtonBackAreaStyle.PaddingTop = 3;
            this.bubbleBar_Cancel.ImageSizeLarge = new System.Drawing.Size(50, 50);
            this.bubbleBar_Cancel.ImageSizeNormal = new System.Drawing.Size(44, 44);
            this.bubbleBar_Cancel.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.bubbleBar_Cancel.Location = new System.Drawing.Point(70, 1);
            this.bubbleBar_Cancel.MouseOverTabColors.BorderColor = System.Drawing.SystemColors.Highlight;
            this.bubbleBar_Cancel.Name = "bubbleBar_Cancel";
            this.bubbleBar_Cancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bubbleBar_Cancel.SelectedTab = this.bubbleBarTab4;
            this.bubbleBar_Cancel.SelectedTabColors.BorderColor = System.Drawing.Color.Black;
            this.bubbleBar_Cancel.Size = new System.Drawing.Size(79, 55);
            this.bubbleBar_Cancel.TabIndex = 866;
            this.bubbleBar_Cancel.Tabs.Add(this.bubbleBarTab4);
            this.bubbleBar_Cancel.TabsVisible = false;
            this.bubbleBar_Cancel.Text = "bubbleBar5";
            // 
            // bubbleBarTab4
            // 
            this.bubbleBarTab4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(230)))), ((int)(((byte)(247)))));
            this.bubbleBarTab4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(228)))));
            this.bubbleBarTab4.Buttons.AddRange(new DevComponents.DotNetBar.BubbleButton[] {
            this.bubbleButton_Cancel});
            this.bubbleBarTab4.DarkBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bubbleBarTab4.LightBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bubbleBarTab4.Name = "bubbleBarTab4";
            this.bubbleBarTab4.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Blue;
            this.bubbleBarTab4.Text = "bubbleBarTab1";
            this.bubbleBarTab4.TextColor = System.Drawing.Color.Black;
            // 
            // bubbleButton_Cancel
            // 
            this.bubbleButton_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("bubbleButton_Cancel.Image")));
            this.bubbleButton_Cancel.ImageLarge = ((System.Drawing.Image)(resources.GetObject("bubbleButton_Cancel.ImageLarge")));
            this.bubbleButton_Cancel.Name = "bubbleButton_Cancel";
            this.bubbleButton_Cancel.TooltipText = "خروج";
            this.bubbleButton_Cancel.Click += new DevComponents.DotNetBar.ClickEventHandler(this.bubbleButton_Cancel_Click);
            // 
            // bubbleBar_Ok
            // 
            this.bubbleBar_Ok.Alignment = DevComponents.DotNetBar.eBubbleButtonAlignment.Top;
            this.bubbleBar_Ok.AntiAlias = true;
            // 
            // 
            // 
            this.bubbleBar_Ok.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.bubbleBar_Ok.ButtonBackAreaStyle.BorderBottomWidth = 1;
            this.bubbleBar_Ok.ButtonBackAreaStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.bubbleBar_Ok.ButtonBackAreaStyle.BorderLeftWidth = 1;
            this.bubbleBar_Ok.ButtonBackAreaStyle.BorderRightWidth = 1;
            this.bubbleBar_Ok.ButtonBackAreaStyle.BorderTopWidth = 1;
            this.bubbleBar_Ok.ButtonBackAreaStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.bubbleBar_Ok.ButtonBackAreaStyle.PaddingBottom = 3;
            this.bubbleBar_Ok.ButtonBackAreaStyle.PaddingLeft = 3;
            this.bubbleBar_Ok.ButtonBackAreaStyle.PaddingRight = 3;
            this.bubbleBar_Ok.ButtonBackAreaStyle.PaddingTop = 3;
            this.bubbleBar_Ok.ImageSizeLarge = new System.Drawing.Size(50, 50);
            this.bubbleBar_Ok.ImageSizeNormal = new System.Drawing.Size(44, 44);
            this.bubbleBar_Ok.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.bubbleBar_Ok.Location = new System.Drawing.Point(392, 1);
            this.bubbleBar_Ok.MouseOverTabColors.BorderColor = System.Drawing.SystemColors.Highlight;
            this.bubbleBar_Ok.Name = "bubbleBar_Ok";
            this.bubbleBar_Ok.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bubbleBar_Ok.SelectedTab = this.bubbleBarTab1;
            this.bubbleBar_Ok.SelectedTabColors.BorderColor = System.Drawing.Color.Black;
            this.bubbleBar_Ok.Size = new System.Drawing.Size(79, 55);
            this.bubbleBar_Ok.TabIndex = 861;
            this.bubbleBar_Ok.Tabs.Add(this.bubbleBarTab1);
            this.bubbleBar_Ok.TabsVisible = false;
            this.bubbleBar_Ok.Text = "bubbleBar2";
            // 
            // bubbleBarTab1
            // 
            this.bubbleBarTab1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(230)))), ((int)(((byte)(247)))));
            this.bubbleBarTab1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(228)))));
            this.bubbleBarTab1.Buttons.AddRange(new DevComponents.DotNetBar.BubbleButton[] {
            this.bubbleButton_Ok});
            this.bubbleBarTab1.DarkBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bubbleBarTab1.LightBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bubbleBarTab1.Name = "bubbleBarTab1";
            this.bubbleBarTab1.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Blue;
            this.bubbleBarTab1.Text = "bubbleBarTab1";
            this.bubbleBarTab1.TextColor = System.Drawing.Color.Black;
            // 
            // bubbleButton_Ok
            // 
            this.bubbleButton_Ok.Image = ((System.Drawing.Image)(resources.GetObject("bubbleButton_Ok.Image")));
            this.bubbleButton_Ok.ImageLarge = ((System.Drawing.Image)(resources.GetObject("bubbleButton_Ok.ImageLarge")));
            this.bubbleButton_Ok.Name = "bubbleButton_Ok";
            this.bubbleButton_Ok.TooltipText = "تفعيل";
            this.bubbleButton_Ok.Click += new DevComponents.DotNetBar.ClickEventHandler(this.bubbleButton_Ok_Click);
            // 
            // bubbleBar_Leave
            // 
            this.bubbleBar_Leave.Alignment = DevComponents.DotNetBar.eBubbleButtonAlignment.Top;
            this.bubbleBar_Leave.AntiAlias = true;
            // 
            // 
            // 
            this.bubbleBar_Leave.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.bubbleBar_Leave.ButtonBackAreaStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.bubbleBar_Leave.ImageSizeLarge = new System.Drawing.Size(50, 50);
            this.bubbleBar_Leave.ImageSizeNormal = new System.Drawing.Size(44, 44);
            this.bubbleBar_Leave.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.bubbleBar_Leave.Location = new System.Drawing.Point(231, 1);
            this.bubbleBar_Leave.MouseOverTabColors.BorderColor = System.Drawing.SystemColors.Highlight;
            this.bubbleBar_Leave.Name = "bubbleBar_Leave";
            this.bubbleBar_Leave.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bubbleBar_Leave.SelectedTab = this.bubbleBarTab2;
            this.bubbleBar_Leave.SelectedTabColors.BorderColor = System.Drawing.Color.Black;
            this.bubbleBar_Leave.Size = new System.Drawing.Size(79, 55);
            this.bubbleBar_Leave.TabIndex = 863;
            this.bubbleBar_Leave.Tabs.Add(this.bubbleBarTab2);
            this.bubbleBar_Leave.TabsVisible = false;
            this.bubbleBar_Leave.Text = "bubbleBar5";
            // 
            // bubbleBarTab2
            // 
            this.bubbleBarTab2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(230)))), ((int)(((byte)(247)))));
            this.bubbleBarTab2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(168)))), ((int)(((byte)(228)))));
            this.bubbleBarTab2.Buttons.AddRange(new DevComponents.DotNetBar.BubbleButton[] {
            this.bubbleButton_Print});
            this.bubbleBarTab2.DarkBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bubbleBarTab2.LightBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bubbleBarTab2.Name = "bubbleBarTab2";
            this.bubbleBarTab2.PredefinedColor = DevComponents.DotNetBar.eTabItemColor.Blue;
            this.bubbleBarTab2.Text = "bubbleBarTab1";
            this.bubbleBarTab2.TextColor = System.Drawing.Color.Black;
            // 
            // bubbleButton_Print
            // 
            this.bubbleButton_Print.Image = ((System.Drawing.Image)(resources.GetObject("bubbleButton_Print.Image")));
            this.bubbleButton_Print.ImageLarge = ((System.Drawing.Image)(resources.GetObject("bubbleButton_Print.ImageLarge")));
            this.bubbleButton_Print.Name = "bubbleButton_Print";
            this.bubbleButton_Print.TooltipText = "طباعة";
            this.bubbleButton_Print.Click += new DevComponents.DotNetBar.ClickEventHandler(this.bubbleButton_Print_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.BackColor = System.Drawing.Color.Transparent;
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.ColorScheme.TabBackground = System.Drawing.SystemColors.InactiveCaption;
            this.tabControl1.ColorScheme.TabBackground2 = System.Drawing.Color.White;
            this.tabControl1.ColorScheme.TabItemBackground = System.Drawing.Color.Transparent;
            this.tabControl1.ColorScheme.TabItemBackgroundColorBlend.AddRange(new DevComponents.DotNetBar.BackgroundColorBlend[] {
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(230)))), ((int)(((byte)(249))))), 0F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(220)))), ((int)(((byte)(248))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(208)))), ((int)(((byte)(245))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(229)))), ((int)(((byte)(247))))), 1F)});
            this.tabControl1.ColorScheme.TabItemHotBackgroundColorBlend.AddRange(new DevComponents.DotNetBar.BackgroundColorBlend[] {
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(237)))), ((int)(((byte)(255))))), 0F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(232)))), ((int)(((byte)(255))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(210)))), ((int)(((byte)(255))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(218)))), ((int)(((byte)(255))))), 1F)});
            this.tabControl1.ColorScheme.TabItemHotText = System.Drawing.Color.Black;
            this.tabControl1.ColorScheme.TabItemSelectedBackgroundColorBlend.AddRange(new DevComponents.DotNetBar.BackgroundColorBlend[] {
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(227)))), ((int)(((byte)(217))))), 0F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(189)))), ((int)(((byte)(116))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(180)))), ((int)(((byte)(89))))), 0.45F),
            new DevComponents.DotNetBar.BackgroundColorBlend(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), 1F)});
            this.tabControl1.ColorScheme.TabItemSelectedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(168)))), ((int)(((byte)(153)))));
            this.tabControl1.ColorScheme.TabItemSelectedBorderDark = System.Drawing.Color.Empty;
            this.tabControl1.ColorScheme.TabItemSelectedBorderLight = System.Drawing.Color.Empty;
            this.tabControl1.ColorScheme.TabItemSelectedText = System.Drawing.SystemColors.ActiveCaption;
            this.tabControl1.ColorScheme.TabItemSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tabControl1.ColorScheme.TabItemText = System.Drawing.Color.DarkGray;
            this.tabControl1.ColorScheme.TabPanelBackground = System.Drawing.Color.Empty;
            this.tabControl1.ColorScheme.TabPanelBackground2 = System.Drawing.Color.Empty;
            this.tabControl1.ColorScheme.TabPanelBorder = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(168)))), ((int)(((byte)(153)))));
            this.tabControl1.Controls.Add(this.tabControlPanel3);
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Controls.Add(this.c1Button1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.ForeColor = System.Drawing.Color.Black;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.ShowFocusRectangle = false;
            this.tabControl1.Size = new System.Drawing.Size(559, 397);
            this.tabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.SimulatedTheme;
            this.tabControl1.TabIndex = 863;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.MultilineNoNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItem1);
            this.tabControl1.Tabs.Add(this.tabItem3);
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Controls.Add(this.Picture_SSS);
            this.tabControlPanel3.Controls.Add(this.label21);
            this.tabControlPanel3.Controls.Add(this.groupBox1);
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel3.Size = new System.Drawing.Size(559, 371);
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(168)))), ((int)(((byte)(153)))));
            this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel3.Style.GradientAngle = 90;
            this.tabControlPanel3.TabIndex = 4;
            this.tabControlPanel3.TabItem = this.tabItem3;
            // 
            // Picture_SSS
            // 
            this.Picture_SSS.BackColor = System.Drawing.Color.Transparent;
            this.Picture_SSS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Picture_SSS.Image = global::InvAcc.Properties.Resources.Untitled_2_copy;
            this.Picture_SSS.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Picture_SSS.Location = new System.Drawing.Point(10, 179);
            this.Picture_SSS.Name = "Picture_SSS";
            this.Picture_SSS.Size = new System.Drawing.Size(545, 189);
            this.Picture_SSS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Picture_SSS.TabIndex = 970;
            this.Picture_SSS.TabStop = false;
            this.Picture_SSS.Visible = false;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Red;
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label21.Dock = System.Windows.Forms.DockStyle.Top;
            this.label21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label21.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(1, 1);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(557, 39);
            this.label21.TabIndex = 12;
            this.label21.Text = "تفعيل النسخة";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupPanel1);
            this.groupBox1.Controls.Add(this.txtDiskSerNo);
            this.groupBox1.Controls.Add(this.txtRunNo);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtSerNo);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtProName);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(535, 314);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(226, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 31;
            this.label1.Text = "Activation No";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.ColorTable = DevComponents.DotNetBar.Controls.ePanelColorTable.Yellow;
            this.groupPanel1.Controls.Add(this.label12);
            this.groupPanel1.Controls.Add(this.label13);
            this.groupPanel1.Controls.Add(this.label14);
            this.groupPanel1.Controls.Add(this.label15);
            this.groupPanel1.Controls.Add(this.txtDiskInfo);
            this.groupPanel1.Controls.Add(this.txtWindowsName);
            this.groupPanel1.Controls.Add(this.txtBIOSId);
            this.groupPanel1.Controls.Add(this.txtProcessorId);
            this.groupPanel1.Location = new System.Drawing.Point(10, 163);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(515, 144);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(178)))));
            this.groupPanel1.Style.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(217)))), ((int)(((byte)(69)))));
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(147)))), ((int)(((byte)(17)))));
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(0)))));
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 30;
            this.groupPanel1.Click += new System.EventHandler(this.groupPanel1_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(5, 79);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 16);
            this.label12.TabIndex = 26;
            this.label12.Text = "Hard Desc";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(19, 109);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 16);
            this.label13.TabIndex = 25;
            this.label13.Text = "Process";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(37, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 16);
            this.label14.TabIndex = 24;
            this.label14.Text = "Bord";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(41, 49);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 16);
            this.label15.TabIndex = 23;
            this.label15.Text = "Win";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDiskInfo
            // 
            this.txtDiskInfo.BackColor = System.Drawing.Color.White;
            this.txtDiskInfo.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtDiskInfo.Location = new System.Drawing.Point(74, 77);
            this.txtDiskInfo.Name = "txtDiskInfo";
            this.netResize1.SetResizeTextBoxMultiline(this.txtDiskInfo, false);
            this.txtDiskInfo.ReadOnly = true;
            this.txtDiskInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDiskInfo.Size = new System.Drawing.Size(417, 21);
            this.txtDiskInfo.TabIndex = 4;
            this.txtDiskInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtWindowsName
            // 
            this.txtWindowsName.BackColor = System.Drawing.Color.White;
            this.txtWindowsName.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtWindowsName.Location = new System.Drawing.Point(74, 47);
            this.txtWindowsName.Name = "txtWindowsName";
            this.netResize1.SetResizeTextBoxMultiline(this.txtWindowsName, false);
            this.txtWindowsName.ReadOnly = true;
            this.txtWindowsName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtWindowsName.Size = new System.Drawing.Size(417, 21);
            this.txtWindowsName.TabIndex = 1;
            this.txtWindowsName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBIOSId
            // 
            this.txtBIOSId.BackColor = System.Drawing.Color.White;
            this.txtBIOSId.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtBIOSId.Location = new System.Drawing.Point(74, 17);
            this.txtBIOSId.Name = "txtBIOSId";
            this.netResize1.SetResizeTextBoxMultiline(this.txtBIOSId, false);
            this.txtBIOSId.ReadOnly = true;
            this.txtBIOSId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBIOSId.Size = new System.Drawing.Size(417, 21);
            this.txtBIOSId.TabIndex = 3;
            this.txtBIOSId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtProcessorId
            // 
            this.txtProcessorId.BackColor = System.Drawing.Color.White;
            this.txtProcessorId.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtProcessorId.Location = new System.Drawing.Point(74, 107);
            this.txtProcessorId.Name = "txtProcessorId";
            this.netResize1.SetResizeTextBoxMultiline(this.txtProcessorId, false);
            this.txtProcessorId.ReadOnly = true;
            this.txtProcessorId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtProcessorId.Size = new System.Drawing.Size(417, 21);
            this.txtProcessorId.TabIndex = 2;
            this.txtProcessorId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDiskSerNo
            // 
            this.txtDiskSerNo.BackColor = System.Drawing.Color.White;
            this.txtDiskSerNo.Location = new System.Drawing.Point(10, 84);
            this.txtDiskSerNo.MaxLength = 10;
            this.txtDiskSerNo.Name = "txtDiskSerNo";
            this.netResize1.SetResizeTextBoxMultiline(this.txtDiskSerNo, false);
            this.txtDiskSerNo.ReadOnly = true;
            this.txtDiskSerNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDiskSerNo.Size = new System.Drawing.Size(515, 21);
            this.txtDiskSerNo.TabIndex = 5;
            this.txtDiskSerNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDiskSerNo.Click += new System.EventHandler(this.txtDiskSerNo_Click);
            // 
            // txtRunNo
            // 
            this.txtRunNo.BackColor = System.Drawing.Color.Lime;
            this.txtRunNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtRunNo.Location = new System.Drawing.Point(10, 132);
            this.txtRunNo.Name = "txtRunNo";
            this.netResize1.SetResizeTextBoxMultiline(this.txtRunNo, false);
            this.txtRunNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRunNo.Size = new System.Drawing.Size(515, 21);
            this.txtRunNo.TabIndex = 7;
            this.txtRunNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRunNo.Click += new System.EventHandler(this.txtRunNo_Click);
            this.txtRunNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRunNo_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(247, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 17);
            this.label10.TabIndex = 29;
            this.label10.Text = "Serial";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSerNo
            // 
            this.txtSerNo.BackColor = System.Drawing.Color.White;
            this.txtSerNo.Location = new System.Drawing.Point(10, 36);
            this.txtSerNo.Name = "txtSerNo";
            this.netResize1.SetResizeTextBoxMultiline(this.txtSerNo, false);
            this.txtSerNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSerNo.Size = new System.Drawing.Size(515, 21);
            this.txtSerNo.TabIndex = 6;
            this.txtSerNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSerNo.Click += new System.EventHandler(this.txtSerNo_Click);
            this.txtSerNo.TextChanged += new System.EventHandler(this.txtSerNo_TextChanged);
            this.txtSerNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerNo_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(220, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 17);
            this.label11.TabIndex = 27;
            this.label11.Text = "Prouduct Code ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(434, -96);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 16);
            this.label16.TabIndex = 22;
            this.label16.Text = "إسم المنتج :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label16.Visible = false;
            // 
            // txtProName
            // 
            this.txtProName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtProName.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtProName.Location = new System.Drawing.Point(14, -96);
            this.txtProName.Name = "txtProName";
            this.netResize1.SetResizeTextBoxMultiline(this.txtProName, false);
            this.txtProName.ReadOnly = true;
            this.txtProName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtProName.Size = new System.Drawing.Size(417, 21);
            this.txtProName.TabIndex = 0;
            this.txtProName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtProName.Visible = false;
            // 
            // tabItem3
            // 
            this.tabItem3.AttachedControl = this.tabControlPanel3;
            this.tabItem3.Name = "tabItem3";
            this.tabItem3.Text = "بيانات المنتــــج";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.checkBox1);
            this.tabControlPanel1.Controls.Add(this.textBox9);
            this.tabControlPanel1.Controls.Add(this.label20);
            this.tabControlPanel1.Controls.Add(this.panel3);
            this.tabControlPanel1.Controls.Add(this.panel4);
            this.tabControlPanel1.Controls.Add(this.label29);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 26);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(559, 371);
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(168)))), ((int)(((byte)(153)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 3;
            this.tabControlPanel1.TabItem = this.tabItem1;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.Black;
            this.checkBox1.Location = new System.Drawing.Point(335, 346);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(211, 17);
            this.checkBox1.TabIndex = 100;
            this.checkBox1.Text = "نعم , أوافق على جميع شروط المنتج";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.Color.SteelBlue;
            this.textBox9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBox9.ForeColor = System.Drawing.Color.White;
            this.textBox9.Location = new System.Drawing.Point(4, 222);
            this.textBox9.Multiline = true;
            this.textBox9.Name = "textBox9";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox9, false);
            this.textBox9.ReadOnly = true;
            this.textBox9.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox9.Size = new System.Drawing.Size(325, 141);
            this.textBox9.TabIndex = 101;
            this.textBox9.Text = resources.GetString("textBox9.Text");
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.SteelBlue;
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label20.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(0, 489);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(559, 37);
            this.label20.TabIndex = 99;
            this.label20.Text = "بيانات الشراء";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label20.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label28);
            this.panel3.Controls.Add(this.txt_PaidInvDate);
            this.panel3.Controls.Add(this.label31);
            this.panel3.Controls.Add(this.txt_PaidInv);
            this.panel3.Controls.Add(this.label32);
            this.panel3.Controls.Add(this.txt_PaidFax);
            this.panel3.Controls.Add(this.label33);
            this.panel3.Controls.Add(this.txt_PaidTel);
            this.panel3.Controls.Add(this.label34);
            this.panel3.Controls.Add(this.txt_PaidCity);
            this.panel3.Controls.Add(this.label35);
            this.panel3.Controls.Add(this.txt_PaidPlace);
            this.panel3.Location = new System.Drawing.Point(5, 531);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(549, 98);
            this.panel3.TabIndex = 98;
            this.panel3.Visible = false;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(186, 64);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(86, 16);
            this.label28.TabIndex = 45;
            this.label28.Text = "تاريخ الفاتورة :";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_PaidInvDate
            // 
            this.txt_PaidInvDate.BackColor = System.Drawing.Color.White;
            this.txt_PaidInvDate.Location = new System.Drawing.Point(11, 62);
            this.txt_PaidInvDate.Name = "txt_PaidInvDate";
            this.netResize1.SetResizeTextBoxMultiline(this.txt_PaidInvDate, false);
            this.txt_PaidInvDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_PaidInvDate.Size = new System.Drawing.Size(175, 20);
            this.txt_PaidInvDate.TabIndex = 16;
            this.txt_PaidInvDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(452, 64);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(79, 16);
            this.label31.TabIndex = 39;
            this.label31.Text = "رقم الفاتورة :";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_PaidInv
            // 
            this.txt_PaidInv.BackColor = System.Drawing.Color.White;
            this.txt_PaidInv.Location = new System.Drawing.Point(280, 62);
            this.txt_PaidInv.Name = "txt_PaidInv";
            this.netResize1.SetResizeTextBoxMultiline(this.txt_PaidInv, false);
            this.txt_PaidInv.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_PaidInv.Size = new System.Drawing.Size(170, 20);
            this.txt_PaidInv.TabIndex = 15;
            this.txt_PaidInv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(186, 38);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(49, 16);
            this.label32.TabIndex = 38;
            this.label32.Text = "فاكس :";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_PaidFax
            // 
            this.txt_PaidFax.BackColor = System.Drawing.Color.White;
            this.txt_PaidFax.Location = new System.Drawing.Point(10, 36);
            this.txt_PaidFax.Name = "txt_PaidFax";
            this.netResize1.SetResizeTextBoxMultiline(this.txt_PaidFax, false);
            this.txt_PaidFax.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_PaidFax.Size = new System.Drawing.Size(176, 20);
            this.txt_PaidFax.TabIndex = 14;
            this.txt_PaidFax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_PaidFax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTel_KeyPress);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(452, 38);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(57, 16);
            this.label33.TabIndex = 37;
            this.label33.Text = "تلفـــون :";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_PaidTel
            // 
            this.txt_PaidTel.BackColor = System.Drawing.Color.White;
            this.txt_PaidTel.Location = new System.Drawing.Point(280, 36);
            this.txt_PaidTel.Name = "txt_PaidTel";
            this.netResize1.SetResizeTextBoxMultiline(this.txt_PaidTel, false);
            this.txt_PaidTel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_PaidTel.Size = new System.Drawing.Size(170, 20);
            this.txt_PaidTel.TabIndex = 13;
            this.txt_PaidTel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_PaidTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTel_KeyPress);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(186, 12);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(55, 16);
            this.label34.TabIndex = 19;
            this.label34.Text = "المدينة :";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_PaidCity
            // 
            this.txt_PaidCity.BackColor = System.Drawing.Color.White;
            this.txt_PaidCity.Location = new System.Drawing.Point(10, 10);
            this.txt_PaidCity.Name = "txt_PaidCity";
            this.netResize1.SetResizeTextBoxMultiline(this.txt_PaidCity, false);
            this.txt_PaidCity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_PaidCity.Size = new System.Drawing.Size(176, 20);
            this.txt_PaidCity.TabIndex = 1;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(452, 12);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(80, 16);
            this.label35.TabIndex = 17;
            this.label35.Text = "محل الشراء :";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_PaidPlace
            // 
            this.txt_PaidPlace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txt_PaidPlace.Location = new System.Drawing.Point(280, 10);
            this.txt_PaidPlace.Name = "txt_PaidPlace";
            this.netResize1.SetResizeTextBoxMultiline(this.txt_PaidPlace, false);
            this.txt_PaidPlace.Size = new System.Drawing.Size(170, 20);
            this.txt_PaidPlace.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label40);
            this.panel4.Controls.Add(this.textBox_Email);
            this.panel4.Controls.Add(this.label41);
            this.panel4.Controls.Add(this.textBox_ActivatedCompany);
            this.panel4.Controls.Add(this.label43);
            this.panel4.Controls.Add(this.textBox_City);
            this.panel4.Controls.Add(this.label44);
            this.panel4.Controls.Add(this.txtPost);
            this.panel4.Controls.Add(this.label45);
            this.panel4.Controls.Add(this.txtPOBOX);
            this.panel4.Controls.Add(this.label46);
            this.panel4.Controls.Add(this.txtMobile);
            this.panel4.Controls.Add(this.label47);
            this.panel4.Controls.Add(this.txtFax);
            this.panel4.Controls.Add(this.label48);
            this.panel4.Controls.Add(this.txtTel);
            this.panel4.Controls.Add(this.label49);
            this.panel4.Controls.Add(this.txtPrsName);
            this.panel4.Controls.Add(this.label50);
            this.panel4.Controls.Add(this.txtCsutName);
            this.panel4.Location = new System.Drawing.Point(4, 43);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(550, 177);
            this.panel4.TabIndex = 97;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(449, 146);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(87, 16);
            this.label40.TabIndex = 51;
            this.label40.Text = "بريد إلكتروني :";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_Email
            // 
            this.textBox_Email.BackColor = System.Drawing.Color.White;
            this.textBox_Email.Location = new System.Drawing.Point(11, 144);
            this.textBox_Email.Name = "textBox_Email";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_Email, false);
            this.textBox_Email.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_Email.Size = new System.Drawing.Size(439, 20);
            this.textBox_Email.TabIndex = 10;
            this.textBox_Email.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(186, 38);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(94, 16);
            this.label41.TabIndex = 49;
            this.label41.Text = "اسم المسؤول :";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_ActivatedCompany
            // 
            this.textBox_ActivatedCompany.BackColor = System.Drawing.Color.White;
            this.textBox_ActivatedCompany.Location = new System.Drawing.Point(298, 36);
            this.textBox_ActivatedCompany.Name = "textBox_ActivatedCompany";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_ActivatedCompany, false);
            this.textBox_ActivatedCompany.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_ActivatedCompany.Size = new System.Drawing.Size(152, 20);
            this.textBox_ActivatedCompany.TabIndex = 2;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(186, 92);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(41, 16);
            this.label43.TabIndex = 45;
            this.label43.Text = "البلد :";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_City
            // 
            this.textBox_City.BackColor = System.Drawing.Color.White;
            this.textBox_City.Location = new System.Drawing.Point(11, 90);
            this.textBox_City.Name = "textBox_City";
            this.netResize1.SetResizeTextBoxMultiline(this.textBox_City, false);
            this.textBox_City.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_City.Size = new System.Drawing.Size(174, 20);
            this.textBox_City.TabIndex = 7;
            this.textBox_City.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(186, 119);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(84, 16);
            this.label44.TabIndex = 43;
            this.label44.Text = "الرمز البريدي :";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPost
            // 
            this.txtPost.BackColor = System.Drawing.Color.White;
            this.txtPost.Location = new System.Drawing.Point(11, 117);
            this.txtPost.Name = "txtPost";
            this.netResize1.SetResizeTextBoxMultiline(this.txtPost, false);
            this.txtPost.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPost.Size = new System.Drawing.Size(175, 20);
            this.txtPost.TabIndex = 9;
            this.txtPost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(449, 119);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(98, 16);
            this.label45.TabIndex = 42;
            this.label45.Text = "صندوق البريدي :";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPOBOX
            // 
            this.txtPOBOX.BackColor = System.Drawing.Color.White;
            this.txtPOBOX.Location = new System.Drawing.Point(326, 117);
            this.txtPOBOX.Name = "txtPOBOX";
            this.netResize1.SetResizeTextBoxMultiline(this.txtPOBOX, false);
            this.txtPOBOX.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPOBOX.Size = new System.Drawing.Size(124, 20);
            this.txtPOBOX.TabIndex = 8;
            this.txtPOBOX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(449, 92);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(63, 16);
            this.label46.TabIndex = 39;
            this.label46.Text = "موبايــــل :";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMobile
            // 
            this.txtMobile.BackColor = System.Drawing.Color.White;
            this.txtMobile.Location = new System.Drawing.Point(326, 90);
            this.txtMobile.Name = "txtMobile";
            this.netResize1.SetResizeTextBoxMultiline(this.txtMobile, false);
            this.txtMobile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMobile.Size = new System.Drawing.Size(124, 20);
            this.txtMobile.TabIndex = 6;
            this.txtMobile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTel_KeyPress);
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.Location = new System.Drawing.Point(186, 65);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(49, 16);
            this.label47.TabIndex = 38;
            this.label47.Text = "فاكس :";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFax
            // 
            this.txtFax.BackColor = System.Drawing.Color.White;
            this.txtFax.Location = new System.Drawing.Point(11, 63);
            this.txtFax.Name = "txtFax";
            this.netResize1.SetResizeTextBoxMultiline(this.txtFax, false);
            this.txtFax.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFax.Size = new System.Drawing.Size(175, 20);
            this.txtFax.TabIndex = 5;
            this.txtFax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTel_KeyPress);
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.Location = new System.Drawing.Point(449, 65);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(57, 16);
            this.label48.TabIndex = 37;
            this.label48.Text = "تلفـــون :";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTel
            // 
            this.txtTel.BackColor = System.Drawing.Color.White;
            this.txtTel.Location = new System.Drawing.Point(326, 63);
            this.txtTel.Name = "txtTel";
            this.netResize1.SetResizeTextBoxMultiline(this.txtTel, false);
            this.txtTel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTel.Size = new System.Drawing.Size(124, 20);
            this.txtTel.TabIndex = 4;
            this.txtTel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTel_KeyPress);
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.Location = new System.Drawing.Point(449, 38);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(96, 16);
            this.label49.TabIndex = 19;
            this.label49.Text = "نشاط المنشأة :";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPrsName
            // 
            this.txtPrsName.BackColor = System.Drawing.Color.White;
            this.txtPrsName.Location = new System.Drawing.Point(11, 36);
            this.txtPrsName.Name = "txtPrsName";
            this.netResize1.SetResizeTextBoxMultiline(this.txtPrsName, false);
            this.txtPrsName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrsName.Size = new System.Drawing.Size(175, 20);
            this.txtPrsName.TabIndex = 3;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.Location = new System.Drawing.Point(449, 11);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(90, 16);
            this.label50.TabIndex = 17;
            this.label50.Text = "إسم المنشأة :";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCsutName
            // 
            this.txtCsutName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txtCsutName.Location = new System.Drawing.Point(11, 9);
            this.txtCsutName.Name = "txtCsutName";
            this.netResize1.SetResizeTextBoxMultiline(this.txtCsutName, false);
            this.txtCsutName.Size = new System.Drawing.Size(439, 20);
            this.txtCsutName.TabIndex = 0;
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.SteelBlue;
            this.label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label29.Dock = System.Windows.Forms.DockStyle.Top;
            this.label29.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label29.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label29.ForeColor = System.Drawing.Color.White;
            this.label29.Location = new System.Drawing.Point(1, 1);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(557, 37);
            this.label29.TabIndex = 8;
            this.label29.Text = "بيانات العميل";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "بيانات عامــــة";
            // 
            // c1Button1
            // 
            this.c1Button1.Location = new System.Drawing.Point(3, 1);
            this.c1Button1.Name = "c1Button1";
            this.c1Button1.Size = new System.Drawing.Size(75, 23);
            this.c1Button1.TabIndex = 5;
            this.c1Button1.Text = "اغلاق";
            this.c1Button1.UseVisualStyleBackColor = true;
            this.c1Button1.Visible = false;
            this.c1Button1.Click += new System.EventHandler(this.c1Button1_Click);
            // 
            // FrmReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(559, 457);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = global::InvAcc.Properties.Resources.favicon;
            this.KeyPreview = true;
            this.Name = "FrmReg";
            this.netResize1.AutoSaveLayout = true;
            this.netResize1.ParentControl = this;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تفعيل النسخة";
            this.Load += new System.EventHandler(this.FrmReg_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Frm_KeyPress);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bubbleBar_Cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bubbleBar_Ok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bubbleBar_Leave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Picture_SSS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.tabControlPanel1.ResumeLayout(false);
            this.tabControlPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1Button1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.netResize1)).EndInit();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.ResumeLayout(false);
        }
        private void c1Button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
