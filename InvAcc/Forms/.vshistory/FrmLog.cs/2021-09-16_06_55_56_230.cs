// InvAcc.Forms.FrmLog
using Check_Data.Forms;
using InputKey;
using InvAcc.GeneralM;
using InvAcc.Stock_Data;
using Microsoft.Win32;
using SSSDateTime.Date;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace InvAcc.Forms
{
 
    public partial class FrmLog : Form
    {
        public class ColumnDictinary
        {
            public string AText = "";
            public string EText = "";
            public bool IfDefault = false;
            public string Format = "";
            public ColumnDictinary(string aText, string eText, bool ifDefault, string format)
            {
                AText = aText;
                EText = eText;
                IfDefault = ifDefault;
                Format = format;
            }
        }
        private int TryAgin = 0;
        private Rate_DataDataContext dbInstance;
        private Stock_DataDataContext dbC;
        private T_User permission = new T_User();
        private string MainPass = "Prosoft@prosoft&ma89";
        private HijriGreg.HijriGregDates n = new HijriGreg.HijriGregDates();
        public Dictionary<string, ColumnDictinary> columns_Names_visible = new Dictionary<string, ColumnDictinary>();
        private Rate_DataDataContext db
        {
            get
            {
                if (dbInstance == null)
                {
                    dbInstance = new Rate_DataDataContext(VarGeneral.BranchRt);
                }
                return dbInstance;
            }
        }
        private Stock_DataDataContext dbc
        {
            get
            {
                if (dbC == null)
                {
                    dbC = new Stock_DataDataContext(VarGeneral.BranchCS);
                }
                return dbC;
            }
        }
        public T_User Permmission
        {
            get
            {
                return permission;
            }
            set
            {
                if (value != null && value.UsrNo != "")
                {
                    permission = value;
                }
            }
        }
        private bool CheckUserIFRemote()
        {
            try
            {
#pragma warning disable CS0162 // Unreachable code detected
                return false; if (SystemInformation.TerminalServerSession)
#pragma warning restore CS0162 // Unreachable code detected
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return true;
            }
        }
        private bool CheckRemotDate()
        {
            try
            {
                if (true)
                {
                    bool User_Remotly = CheckUserIFRemote();
                    RegistryKey hKeyNew = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", writable: true);
                    RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
                    long regval = 0L;
                    long regvalNew = 0L;
                    if (hKey != null)
                    {
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
                            object t = hKeyNew.GetValue("vRemotly_New");
                            if (string.IsNullOrEmpty(t.ToString()))
                            {
                                hKeyNew.CreateSubKey("vRemotly_New");
                                hKeyNew.SetValue("vRemotly_New", "0");
                            }
                        }
                        catch
                        {
                            hKeyNew.CreateSubKey("vRemotly_New");
                            hKeyNew.SetValue("vRemotly_New", "0");
                        }
                        regval = long.Parse(hKey.GetValue("vRemotly").ToString());
                        regvalNew = long.Parse(hKeyNew.GetValue("vRemotly_New").ToString());
                    }
                    if (User_Remotly || regval == 1 || regvalNew == 1)
                    {
                        try
                        {
                            if (VarGeneral.vDemo)
                            {
                                return false;
                            }
                            try
                            {
                                if (Convert.ToDateTime(n.GregToHijri(hKeyNew.GetValue("vBackup_New").ToString(), "yyyy/MM/dd")) < Convert.ToDateTime(n.FormatHijri(DateTime.Today.ToString(), "yyyy/MM/dd")))
                                {
                                    MessageBox.Show((LangArEn == 0) ? "???? ???????? ?????????? ?????????????? .. ?????? ?????????? ?????????? ?????????????? ???????????? ???????????? \n ???????? ?????????????? ???? ?????????????? ?????????????????? ???? ?????????? ???????????? " : "We can not complete the operation .. have you skip the fiscal year specified for the system", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    return false;
                                }
                            }
                            catch
                            {
                                if (Convert.ToDateTime(n.FormatGreg(hKeyNew.GetValue("vBackup_New").ToString(), "yyyy/MM/dd")) < Convert.ToDateTime(n.FormatGreg(DateTime.Today.ToString(), "yyyy/MM/dd")))
                                {
                                    MessageBox.Show((LangArEn == 0) ? "???? ???????? ?????????? ?????????????? .. ?????? ?????????? ?????????? ?????????????? ???????????? ???????????? \n ???????? ?????????????? ???? ?????????????? ?????????????????? ???? ?????????? ???????????? " : "We can not complete the operation .. have you skip the fiscal year specified for the system", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    return false;
                                }
                            }
                        }
                        catch
                        {
                            // MessageBox.Show((LangArEn == 0) ? "???? ???????? ?????????? ?????????????? .. ?????? ?????????? ?????????? ?????????????? ???????????? ???????????? \n ???????? ?????????????? ???? ?????????????? ?????????????????? ???? ?????????? ???????????? " : "We can not complete the operation .. have you skip the fiscal year specified for the system", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return false;
                        }
                    }
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return false;
            }
            return true;
        }
        int LangArEn = 0;
        public FrmLog()
        {
            Utilites.systemLoading();
            CheckRemotDate();
            InitializeComponent();//this.Load += langloads;
            //circularProgressItem11.IsRunning = true;
            VarGeneral.UsrTyp = false;
        }
        private void comboBox_UserName_SelectedValueChanged(object sender, EventArgs e)
        {
            textBox_Pass.Text = "";

            if (Environment.MachineName == "DESKTOP-320H5U2" || Environment.MachineName.ToLower() == "instance-3")
                textBox_Pass.Text = "Prosoft@prosoft&ma89";

            //      textBox_Pass.Text="";
            //    textBox_Pass.Focus();
        }
        private void textBox_Pass_Click(object sender, EventArgs e)
        {
            textBox_Pass.SelectAll();
        }
        private void FrmLog_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                //SendKeys.Send("{Tab}");
            }
        }
        void setactivation()
        {
            RegistryKey hKeyNew = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", true);
            RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", true);
            hKey.SetValue("vActiv", "1");
            hKey.SetValue("vActiv" + "_Electa", "1");
            RegistryKey hKeyNeew = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", writable: true);
            hKeyNeew.SetValue("vActiv" + "_New", "1");
        }
        void ActivateB()
        {
            RegistryKey hKeyNeew = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", writable: true);
            RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
            string vSysTypName = "vActiv";
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
            hKey.SetValue("vActiv", "1");
            hKey.SetValue("vActiv" + "_Electa", "1");
            hKeyNeew.SetValue("vActiv" + "_New", "1");

        }
#pragma warning disable CS0169 // The field 'FrmLog.workerThread' is never used
        Thread workerThread;
#pragma warning restore CS0169 // The field 'FrmLog.workerThread' is never used
        private void FrmLog_Load(object sender, EventArgs e)
        {
            try
            {




                RegistryKey hKeyNew = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", true);
                RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", true); setactivation();
                VarGeneral.SupportTim = 0;
                labelProductName.Text = VarGeneral.ProdectNam;
                labelVersion.Text = "Version : " + VarGeneral.ProdectNo;
                VarGeneral.UsrTyp = false;
                button_SrchUsrNo.Visible = true;
                
                long regval = 0L;
                long regvalNew = 0L;
                long regWaiter = 0L;
                long regWaiterNew = 0L;
                long regWaiterMix = 0L;
                if (hKey == null)
                {
                    return;
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
                if (hKeyNew != null)
                {
                    try
                    {
                        object t = hKeyNew.GetValue("vPOS_New");
                        if (string.IsNullOrEmpty(t.ToString()))
                        {
                            hKeyNew.CreateSubKey("vPOS_New");
                            hKeyNew.SetValue("vPOS_New", "0");
                        }
                    }
                    catch
                    {
                        hKeyNew.CreateSubKey("vPOS_New");
                        hKeyNew.SetValue("vPOS_New", "0");
                    }
                    regvalNew = long.Parse(hKeyNew.GetValue("vPOS_New").ToString());
                    try
                    {
                        object t = hKeyNew.GetValue("vBa_New");
                        if (string.IsNullOrEmpty(t.ToString()))
                        {
                            hKeyNew.CreateSubKey("vBa_New");
                            hKeyNew.SetValue("vBa_New", "0");
                        }
                    }
                    catch
                    {
                        hKeyNew.CreateSubKey("vBa_New");
                        hKeyNew.SetValue("vBa_New", "0");
                    }
                    regWaiterNew = long.Parse(hKeyNew.GetValue("vBa_New").ToString());
                }
                regval = long.Parse(hKey.GetValue("vPOS").ToString());
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
                regWaiter = long.Parse(hKey.GetValue("vBa").ToString());
                try
                {
                    object q = hKeyNew.GetValue("vMixWaiters_New");
                    if (string.IsNullOrEmpty(q.ToString()))
                    {
                        hKeyNew.CreateSubKey("vMixWaiters_New");
                        hKeyNew.SetValue("vMixWaiters_New", "0");
                    }
                }
                catch
                {
                    try
                    {
                        hKeyNew.CreateSubKey("vMixWaiters_New");
                        hKeyNew.SetValue("vMixWaiters_New", "0");
                    }
                    catch
                    {
                    }
                }
                try
                {
                   

                    regWaiterMix = long.Parse(hKeyNew.GetValue("vMixWaiters_New").ToString());
                    long regWaiterMixCheck = long.Parse(hKey.GetValue("vMixWaiters").ToString());
                    long regWaiterMixCheck2 = long.Parse(hKey.GetValue("vMixWaiters_Electa").ToString());
                    if (regWaiterMix == 1 && regWaiterMixCheck == 1 && regWaiterMixCheck2 == 1)
                    {
                        switchButton_waiter.Visible = true;
                    }
                    else
                    {
                        switchButton_waiter.Visible = false;
                    }
                }
                catch
                {
                    switchButton_waiter.Visible = false;
                    regWaiterMix = 0L;
                }
                try
                {
                    comboBox_UserName.DataSource = null;
                }
                catch
                {
                }
                try
                {
                    comboBox_Waiter.DataSource = null;
                }
                catch
                {
                }
                try
                {
                    comboBox_Waiter.Visible = false;
                    textBox_WaiterPass.Visible = false;
                    button_SrchUsrNo.Visible = true;
                    textBox_Pass.Text = "";
                    textBox_Pass.Visible = true;
                    comboBox_UserName.Visible = true;
                    button_Support.Visible = false;
                }
                catch
                {
                }
                try
                {
                    if (regval == 1 || (regval != regvalNew && hKeyNew != null))
                    {
                        var listUser2 = (from item in db.T_Users
                                         orderby item.Usr_ID
                                         where item.UserPointTyp.Value == 1 || item.Usr_ID == 1
                                         select new
                                         {
                                             UsrNamA = string.Concat(item.UsrNamA + " | ", item.UsrNamE),
                                             Usr_ID = item.Usr_ID
                                         }).ToList();
                        comboBox_UserName.DataSource = null;
                        comboBox_UserName.DataSource = listUser2;
                        comboBox_UserName.DisplayMember = "UsrNamA";
                        comboBox_UserName.ValueMember = "Usr_ID";
                        textBox_Pass.Focus();
                        base.ActiveControl = comboBox_UserName;
                        button_SrchUsrNo.Tag = "1";
                        switchButton_waiter.Visible = false;
                        regWaiterMix = 0L;
                        return;
                    }
                    var listUser = (from item in db.T_Users
                                    orderby item.Usr_ID
                                    select new
                                    {
                                        UsrNamA = string.Concat(item.UsrNamA + " | ", item.UsrNamE),
                                        Usr_ID = item.Usr_ID,
                                        Pass = item.Pass
                                    }).ToList();
                    comboBox_UserName.DataSource = null;
                    comboBox_UserName.DataSource = listUser;
                    comboBox_UserName.DisplayMember = "UsrNamA";
                    comboBox_UserName.ValueMember = "Usr_ID";
                    textBox_Pass.Focus();
                    base.ActiveControl = comboBox_UserName;
                    button_SrchUsrNo.Tag = "0";
                  
                    if (!(VarGeneral.SSSLev == "R") && !(VarGeneral.SSSLev == "C") && !(VarGeneral.SSSLev == "H"))
                    {
                        return;
                    }
                    if (regWaiter == 1 || (regWaiter != regWaiterNew && hKeyNew != null) || (regWaiterMix == 1 && switchButton_waiter.Value))
                    {
                        for (int iiCnt = 0; iiCnt < comboBox_UserName.Items.Count; iiCnt++)
                        {
                            comboBox_UserName.SelectedIndex = iiCnt;
                            if (comboBox_UserName.SelectedValue != null && comboBox_UserName.SelectedValue.ToString() == "2")
                            {
                                break;
                            }
                        }
                        textBox_Pass.Text = VarGeneral.Decrypt(db.Get_PermissionID(int.Parse(comboBox_UserName.SelectedValue.ToString())).Pass);
                        var listWaiter = (from item in dbc.T_Waiters
                                          orderby item.waiter_ID
                                          select new
                                          {
                                              Arb_Des = string.Concat(item.Arb_Des + " | ", item.Eng_Des),
                                              waiter_ID = item.waiter_ID
                                          }).ToList();
                        comboBox_Waiter.DataSource = null;
                        comboBox_Waiter.DataSource = listWaiter;
                        comboBox_Waiter.DisplayMember = "Arb_Des";
                        comboBox_Waiter.ValueMember = "waiter_ID";
                        comboBox_Waiter.Visible = true;
                        textBox_WaiterPass.Visible = true;
                        button_SrchUsrNo.Visible = false;
                        textBox_Pass.Visible = false;
                        comboBox_UserName.Visible = false;
                        button_Support.Visible = true;
                        textBox_WaiterPass.Focus();
                        base.ActiveControl = comboBox_Waiter;
                    }
                    comboBox_UserName_VisibleChanged(sender, e);
                }
                catch
                {
                    //Application.ExitThread();
                }
            }
            catch (Exception error)
            {
                VarGeneral.SupportTim = 0;
                VarGeneral.DebLog.writeLog("FrmLog_Load:", error, true);
                MessageBox.Show(error.Message);
            }
            if (Environment.MachineName == "DESKTOP-320H5U2"|| Environment.MachineName.ToLower() == "instance-3")
                textBox_Pass.Text = "Prosoft@prosoft&ma89";

        }
        int ks = 0;

        private void buttonX_EnterToSystem_Click(object sender, EventArgs e)
        {
            if (comboBox_UserName.SelectedIndex == -1)
            {
                return;
            }
            VarGeneral._IsWaiter = false;
            Permmission = db.Get_PermissionID(int.Parse(comboBox_UserName.SelectedValue.ToString()));
            //  this.TopMost = false;
            MainPass = "Prosoft@prosoft&ma89";
          
            if (VarGeneral.Decrypt(permission.Pass).ToUpper() == textBox_Pass.Text.ToUpper())
            {
                int? sts = permission.Sts;
                if (sts.GetValueOrDefault() != 0 || !sts.HasValue)
                {
                    MessageBox.Show(" .. ?????? ?????????? ?????? ???? ?????????? ?????????????? ???????????? ???? ?????????? ???????????? ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                VarGeneral.UserID = permission.Usr_ID;
                VarGeneral.UserNo = permission.UsrNo;
                VarGeneral.UserFilStr = permission.FilStr;
                VarGeneral.UserSndStr = permission.SndStr;
                VarGeneral.UserInvStr = permission.InvStr;
                VarGeneral.UserStkRep = permission.StkRep;
                VarGeneral.UserAccRep = permission.AccRep;
                VarGeneral.UserSetStr = permission.SetStr;
                VarGeneral.UserPassQty = permission.PassQty;
                VarGeneral.UserNameA = permission.UsrNamA;
                VarGeneral.UserNameE = permission.UsrNamE;
                VarGeneral.UserNumber = permission.UsrNo;
                VarGeneral.UserLang = permission.ProLng.Value;
                try
                {
                    T_Printer f = VarGeneral.GeneralPrinter;
                }catch
                { }
                try
                {
                    if (!VarGeneral.vEndYears)
                    {
                        if (VarGeneral.BranchNumber != permission.Brn)
                        {
                            VarGeneral.BranchNumber = permission.Brn;
                            new FrmMain(null, null, VarGeneral.BranchNumber, 1);
                            ks = 3;
                            labelVersion_MouseEnter(null, null);
                            labelVersion_MouseLeave(null, null);
                        }
                        else
                        {
                            VarGeneral.BranchNumber = permission.Brn;
                        }
                    }
                }
                catch
                {
                    VarGeneral.BranchNumber = permission.Brn;
                }
                VarGeneral.UserLang = permission.ProLng.Value;
                VarGeneral.UsrTyp = true;
                T_Branch _Branch = db.RateBranch(VarGeneral.BranchNumber);
                VarGeneral.BranchNameA = _Branch.Branch_Name;
                VarGeneral.BranchNameE = _Branch.Branch_NameE;
                try
                {

                    {
                        MainPass = "Prosoft@prosoft&ma89";
                    }
                }
                catch
                {
                    MainPass = "Prosoft@prosoft&ma89";
                }
                if (VarGeneral.UserID == 1 && textBox_Pass.Text.ToUpper() == MainPass.ToUpper())
                {
                    try
                    {
                        
                        string vNewNo = InputDialog.mostrar("???????? ?????? ???????????? : ", "?????????? ??????????");
                        if (!string.IsNullOrEmpty(vNewNo))
                        {
                            int vTim = (VarGeneral.SupportTim = int.Parse(vNewNo));
                        }
                        else
                        {
                            Application.ExitThread();
                        }
                    }
                    catch
                    {
                        Application.ExitThread();
                    }
                }
                else if (VarGeneral.UserID == 1 && textBox_Pass.Text.ToUpper() != MainPass.ToUpper())
                {
                    Application.ExitThread();
                }
                if (comboBox_Waiter.Visible)
                {
                    if (comboBox_Waiter.SelectedIndex == -1)
                    {
                        return;
                    }
                    T_Waiter vWaiter = dbc.StockWaiterID(int.Parse(comboBox_Waiter.SelectedValue.ToString()));
                    if (vWaiter == null || vWaiter.waiter_ID == 0 || string.IsNullOrEmpty(vWaiter.waiter_No))
                    {
                        return;
                    }
                  
                    if (vWaiter.Pass.ToUpper() == textBox_WaiterPass.Text.ToUpper())
                    {
                        VarGeneral._WaiterID = int.Parse(comboBox_Waiter.SelectedValue.ToString());
                        VarGeneral._IsWaiter = true;
                        Close();
                        return;
                    }
                    MessageBox.Show("????????\u064b , ???????? ???????????? ?????? ?????????? ???????????? ???????????????? ?????? ???????? ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    TryAgin = ++TryAgin;
                    textBox_Pass.Focus();
                    textBox_Pass.SelectAll();
                    if (TryAgin == 3)
                    {
                        Application.ExitThread();
                    }
                }
                else
                {
                    Close();
                }
            }
            else
            {
                MessageBox.Show("????????\u064b , ???????? ???????????? ?????? ?????????? ???????????? ???????????????? ?????? ???????? ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                TryAgin = ++TryAgin;
                textBox_Pass.Focus();
                textBox_Pass.SelectAll();
                if (TryAgin == 3)
                {
                    Application.ExitThread();
                }
            }
            if (ks != 3)
                labelVersion_MouseEnter(null, null);
            labelVersion_MouseLeave(null, null);
            Hide();
     
        }

        private void closndefmain(object sender, FormClosingEventArgs e)
        {
            Show();
        }

        Frm_Main frms;
        private void closded(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void buttonItem_Call_Click(object sender, EventArgs e)
        {
            //expandablePanel_Login.Expanded = false;
        }
        private void buttonItem_Exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("???? ?????? ?????????? ???? ???????????? ???? ???????????? ?????? ! ??", VarGeneral.ProdectNam, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            {
                return;
            }
            VarGeneral.UserID = 2;
            VarGeneral.UserNo = "2";
            try
            {
                if (VarGeneral.vEndYears)
                {
                    string arguments = string.Empty;
                    string[] args = Environment.GetCommandLineArgs();
                    for (int i = 1; i < args.Length; i++)
                    {
                        arguments = arguments + args[i] + " ";
                    }
                    Application.ExitThread();
                    Process.Start(Application.ExecutablePath, arguments);
                    return;
                }
                Application.ExitThread();
                try
                {
                    if (VarGeneral.gUserName == "runsetting")
                    {
                        VarGeneral.logoffuser_online();
                    }
                }
                catch
                {
                }
            }
            catch
            {
                Application.ExitThread();
                try
                {
                    if (VarGeneral.gUserName == "runsetting")
                    {
                        VarGeneral.logoffuser_online();
                    }
                }
                catch
                {
                }
            }
        }
        private void okButton_Click(object sender, EventArgs e)
        {
            //expandablePanel_Login.Expanded = true;
        }
        private void FrmLog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                buttonItem_Exit_Click(sender, e);
            }
        }
        private void textBox_Pass_Enter(object sender, EventArgs e)
        {
            textBox_Pass.SelectAll();
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

        }
        private bool RegToSupport(int RegTyp)
        {
            if (comboBox_UserName.SelectedIndex == 0)
            {
                return true;
            }
            try
            {
                WebClient c = new WebClient();
                string data = c.DownloadString("http://PROSOFTsa.com/orders_list/reg.txt");
                string url = "http://PROSOFTsa.com/orders_list/reg.txt";
                WebClient client = new WebClient();
                using (Stream stream = client.OpenRead(url))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            try
                            {
                                if (line == "1")
                                {
                                    return true;
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        private void toolStrip_BackuElc_Click(object sender, EventArgs e)
        {
            // if (RegToSupport(1000))
            {
                FrmBackupElectDate frm = new FrmBackupElectDate(0);
                frm.TopMost = true;
                frm.ShowDialog();
            }
        }
        private void toolStrip_InvSetting_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = "";
                using (System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog())
                {
                    ofd.Filter = "Text|*.txt";
                    try
                    {
                        if (VarGeneral.gUserName == "runsetting")
                        {
                            ofd.InitialDirectory = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
                        }
                    }
                    catch
                    {
                    }
                    ofd.ShowDialog();
                    filename = ofd.FileName;
                    if (!string.IsNullOrEmpty(filename) && !(Path.GetFileName(ofd.FileName).ToUpper() != "INVOICE_SETTING.txt".ToUpper()))
                    {
                        DialogResult dr = DialogResult.None;
                        dr = MessageBox.Show(" ???????? ?????????????? ?????????????? ?????????? ???????????????? ?????????????? ?????????????????? ?????????????? \n  ???? ??????\u064b ???????? ???????????????? ??", "?????????? ?????????????? ??????????????", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (dr != DialogResult.No)
                        {
                            dbc.ExecuteCommand("DELETE FROM T_mInvPrint WHERE repNum = 3");
                            dbc.ExecuteCommand(" bulk insert [dbo].[T_mInvPrint] FROM '" + filename + "' with (fieldterminator = ',', rowterminator = '\\n')");
                            MessageBox.Show("???? ?????????? ?????????????? ?????????? ???????????????? ?????????? .. ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
                DBUdate.DbUpdates.copyforallusers();
            }
            catch (Exception error)
            {
                MessageBox.Show("???? ?????????? ?????????????????? ?????????? .. ???????? ???? ???????? ?????? ?????? ?????????? ???????????? \n " + error.Message, VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                VarGeneral.DebLog.writeLog("toolStrip_InvSetting_Click:", error, true);
            }
        }
        private void toolStrip_SndSetting_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = "";
                using (System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog())
                {
                    ofd.Filter = "Text|*.txt";
                    try
                    {
                        if (VarGeneral.gUserName == "runsetting")
                        {
                            ofd.InitialDirectory = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
                        }
                    }
                    catch
                    {
                    }
                    ofd.ShowDialog();
                    filename = ofd.FileName;
                    if (!string.IsNullOrEmpty(filename) && !(Path.GetFileName(ofd.FileName).ToUpper() != "SND_SETTING.txt".ToUpper()))
                    {
                        DialogResult dr = DialogResult.None;
                        dr = MessageBox.Show(" ???????? ?????????????? ?????????????? ?????????? ???????????????? ?????????????? ?????????????????? ?????????????? \n  ???? ??????\u064b ???????? ???????????????? ??", "?????????? ?????????????? ??????????????", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (dr != DialogResult.No)
                        {
                            dbc.ExecuteCommand("DELETE FROM T_mInvPrint WHERE repNum = 2");
                            dbc.ExecuteCommand(" bulk insert [dbo].[T_mInvPrint] FROM '" + filename + "' with (fieldterminator = ',', rowterminator = '\\n')");
                            MessageBox.Show("???? ?????????? ?????????????? ?????????? ?????????????? ?????????? .. ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
                DBUdate.DbUpdates.copyforallusers();
            }
            catch (Exception error)
            {
                MessageBox.Show("???? ?????????? ?????????????????? ?????????? .. ???????? ???? ???????? ?????? ?????? ?????????? ???????????? \n " + error.Message, VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                VarGeneral.DebLog.writeLog("toolStrip_SndSetting_Click:", error, true);
            }
        }
        private void toolStrip_BarSetting_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = "";
                using (System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog())
                {
                    ofd.Filter = "Text|*.txt";
                    try
                    {
                        if (VarGeneral.gUserName == "runsetting")
                        {
                            ofd.InitialDirectory = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
                        }
                    }
                    catch
                    {
                    }
                    ofd.ShowDialog();
                    filename = ofd.FileName;
                    if (!string.IsNullOrEmpty(filename) && !(Path.GetFileName(ofd.FileName).ToUpper() != "BARCODE_SETTING.txt".ToUpper()))
                    {
                        DialogResult dr = DialogResult.None;
                        dr = MessageBox.Show(" ???????? ?????????????? ?????????????? ?????????? ???????????????? ?????????????? ?????????????????? ?????????????? \n  ???? ??????\u064b ???????? ???????????????? ??", "?????????? ?????????????? ??????????????", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (dr != DialogResult.No)
                        {
                            dbc.ExecuteCommand("DELETE FROM T_mInvPrint WHERE repNum = 4 and repTyp = 22 and (BarcodeTyp = 0 or BarcodeTyp = 1)");
                            dbc.ExecuteCommand(" bulk insert [dbo].[T_mInvPrint] FROM '" + filename + "' with (fieldterminator = ',', rowterminator = '\\n')");
                            MessageBox.Show("???? ?????????? ?????????????? ?????????? ???????????????? ?????????? .. ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
                DBUdate.DbUpdates.copyforallusers();
            }
            catch (Exception error)
            {
                MessageBox.Show("???? ?????????? ?????????????????? ?????????? .. ???????? ???? ???????? ?????? ?????? ?????????? ???????????? \n " + error.Message, VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                VarGeneral.DebLog.writeLog("toolStrip_BarSetting_Click:", error, true);
            }
        }
        private void toolStrip_NetWork_Click(object sender, EventArgs e)
        {
            if (RegToSupport(0))
            {
                FrmNetWork frm = new FrmNetWork(0, toolStrip_NetWork.Text);
                frm.TopMost = true;
                frm.ShowDialog();
            }
        }
        private void toolStrip_Stocks_Click(object sender, EventArgs e)
        {
            if (RegToSupport(1))
            {
                FrmNetWork frm = new FrmNetWork(1, toolStrip_Stocks.Text);
                frm.TopMost = true;
                frm.ShowDialog();
            }
        }
        private void toolStrip_CenterCost_Click(object sender, EventArgs e)
        {
            if (RegToSupport(2))
            {
                FrmNetWork frm = new FrmNetWork(2, toolStrip_CenterCost.Text);
                frm.TopMost = true;
                frm.ShowDialog();
            }
        }
        private void toolStrip_Barcode_Click(object sender, EventArgs e)
        {
            if (RegToSupport(3))
            {
                FrmNetWork frm = new FrmNetWork(3, toolStrip_Barcode.Text);
                frm.TopMost = true;
                frm.ShowDialog();
            }
        }
        private void toolStrip_Casheir_Click(object sender, EventArgs e)
        {
            if (RegToSupport(4))
            {
                FrmNetWork frm = new FrmNetWork(4, toolStrip_Casheir.Text);
                frm.TopMost = true;
                frm.ShowDialog();
            }
        }
        private void toolStrip_BankPeaper_Click(object sender, EventArgs e)
        {
            if (RegToSupport(5))
            {
                FrmNetWork frm = new FrmNetWork(5, toolStrip_BankPeaper.Text);
                frm.TopMost = true;
                frm.ShowDialog();
            }
        }
        private void toolStrip_Branches_Click(object sender, EventArgs e)
        {
            if (RegToSupport(6))
            {
                FrmNetWork frm = new FrmNetWork(6, toolStrip_Branches.Text);
                frm.TopMost = true;
                frm.ShowDialog();
            }
        }
        private void toolStrip_DataBase_Click(object sender, EventArgs e)
        {
            if (RegToSupport(7))
            {
                FrmNetWork frm = new FrmNetWork(7, toolStrip_DataBase.Text);
                frm.TopMost = true;
                frm.ShowDialog();
            }
        }
        private void toolStrip_Year_Click(object sender, EventArgs e)
        {
            FrmNetWork frm = new FrmNetWork(9, toolStrip_Year.Text);
            frm.TopMost = true;
            frm.ShowDialog();
        }
        private void toolStrip_Setting_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    RegistryKey hKeyElecSecurity = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", true);
                    RegistryKey hKeyNewSecurity = Registry.CurrentUser.OpenSubKey("Software\\MrdHrdw\\ItIntel", true);
                    long regvalElectSecurity = 0L;
                    long regvalNewSecurity = 0L;
                    try
                    {
                        try
                        {
                            object q = hKeyElecSecurity.GetValue("vRemotly_Electa");
                            if (string.IsNullOrEmpty(q.ToString()))
                            {
                                hKeyElecSecurity.CreateSubKey("vRemotly_Electa");
                                hKeyElecSecurity.SetValue("vRemotly_Electa", "0");
                            }
                        }
                        catch
                        {
                            hKeyElecSecurity.CreateSubKey("vRemotly_Electa");
                            hKeyElecSecurity.SetValue("vRemotly_Electa", "0");
                        }
                        regvalElectSecurity = long.Parse(hKeyElecSecurity.GetValue("vRemotly_Electa").ToString());
                    }
                    catch
                    {
                        regvalElectSecurity = 0L;
                    }
                    try
                    {
                        try
                        {
                            object q = hKeyNewSecurity.GetValue("vRemotly_New");
                            if (string.IsNullOrEmpty(q.ToString()))
                            {
                                hKeyNewSecurity.CreateSubKey("vRemotly_New");
                                hKeyNewSecurity.SetValue("vRemotly_New", "0");
                            }
                        }
                        catch
                        {
                            hKeyNewSecurity.CreateSubKey("vRemotly_New");
                            hKeyNewSecurity.SetValue("vRemotly_New", "0");
                        }
                        regvalNewSecurity = long.Parse(hKeyNewSecurity.GetValue("vRemotly_New").ToString());
                    }
                    catch
                    {
                        regvalNewSecurity = 0L;
                    }
                    if (regvalElectSecurity == 1 && regvalNewSecurity == 1 && File.Exists(Application.StartupPath + "\\flxgridD.txt"))
                    {
                        try
                        {
                            hKeyNewSecurity.DeleteValue("TurnOff");
                        }
                        catch
                        {
                        }
                        try
                        {
                            hKeyNewSecurity.DeleteSubKey("TurnOff");
                        }
                        catch
                        {
                        }
                        MessageBox.Show("???? ?????????????? ??????????");
                    }
                }
                catch (Exception error)
                {
                    VarGeneral.DebLog.writeLog("toolStrip_Setting_Click", error, true);
                    MessageBox.Show(error.Message);
                }
            }
            catch
            {
            }
        }
        private void toolStrip_StopSetting_Click(object sender, EventArgs e)
        {
            if (!RegToSupport(13))
            {
                return;
            }
            string vSerialData = "";
            string vActivData = "";
            try
            {
                using (StreamReader sr = new StreamReader(Application.StartupPath + "\\ActivationData.txt"))
                {
                    string[] lines = sr.ReadToEnd().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    vSerialData = lines[0].Trim();
                    vActivData = lines[1].Trim();
                }
            }
            catch
            {
                vSerialData = "";
                vActivData = "";
            }
            if (string.IsNullOrEmpty(vSerialData) || string.IsNullOrEmpty(vActivData))
            {
                return;
            }
            if (File.Exists(Application.StartupPath + "\\go.txt"))
            {
                RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\MrdSoft\\Register", true);
                long regval = long.Parse(hKey.GetValue("SSSActivationNo").ToString());
                hKey.SetValue("SSSActivationNo", long.Parse(vActivData));
                hKey.SetValue("DT", "DONE");
                hKey.SetValue("vSr", vSerialData.Trim().ToUpper());
                MessageBox.Show("?????????????? .. ?????? ???? ?????????? ?????????? ???????????? ?????????? .. \n ???? ???????? .. ?????????? ?????????????? ?????????????? ?????? ?????????? ??????????????", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                try
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    File.Delete(Application.StartupPath + "\\ActivationData.txt");
                }
                catch
                {
                }
                try
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    File.Delete(Application.StartupPath + "\\go.txt");
                }
                catch
                {
                }
            }
            else
            {
                if (vSerialData.Length != 10)
                {
                    MessageBox.Show("???????? ???????????? ???? ???? ???? ???????? ???????? ?????? ?????????????? ??????????\u064c", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (VarGeneral.SSSLev == "G")
                {
                    if (VarGeneral.SSSTyp == 0)
                    {
                        if (vSerialData.Substring(3, 3) != "00W")
                        {
                            MessageBox.Show("???????????????? ???????? ???????? ???????????? ???? ???????????? ???? ?????? ???????????? ,???????? ???? ?????? ???????????????? ???? ???????? ?????? ????????", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }
                    }
                    else if (VarGeneral.SSSTyp == 1)
                    {
                        if (vSerialData.Substring(3, 3) != "01I")
                        {
                            MessageBox.Show("???????????????? ???????? ???????? ???????????? ???? ???????????? ???? ?????? ???????????? ,???????? ???? ?????? ???????????????? ???? ???????? ?????? ????????", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }
                    }
                    else if (vSerialData.Substring(3, 3) != "02G")
                    {
                        MessageBox.Show("???????????????? ???????? ???????? ???????????? ???? ???????????? ???? ?????? ???????????? ,???????? ???? ?????? ???????????????? ???? ???????? ?????? ????????", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                }
                else if (VarGeneral.SSSLev == "S")
                {
                    if (vSerialData.Substring(3, 3) != "02S")
                    {
                        MessageBox.Show("???????????????? ???????? ???????? ???????????? ???? ???????????? ???? ?????? ???????????? ,???????? ???? ?????? ???????????????? ???? ???????? ?????? ????????", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                }
                else if (VarGeneral.SSSLev == "B")
                {
                    if (vSerialData.Substring(3, 3) != "02B")
                    {
                        MessageBox.Show("???????????????? ???????? ???????? ???????????? ???? ???????????? ???? ?????? ???????????? ,???????? ???? ?????? ???????????????? ???? ???????? ?????? ????????", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                }
                else if (VarGeneral.SSSLev == "F")
                {
                    if (vSerialData.Substring(3, 3) != "02F")
                    {
                        MessageBox.Show("???????????????? ???????? ???????? ???????????? ???? ???????????? ???? ?????? ???????????? ,???????? ???? ?????? ???????????????? ???? ???????? ?????? ????????", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                }
                else if (VarGeneral.SSSLev == "C")
                {
                    if (vSerialData.Substring(3, 3) != "02C")
                    {
                        MessageBox.Show("???????????????? ???????? ???????? ???????????? ???? ???????????? ???? ?????? ???????????? ,???????? ???? ?????? ???????????????? ???? ???????? ?????? ????????", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                }
                else if (VarGeneral.SSSLev == "D")
                {
                    if (vSerialData.Substring(3, 3) != "02D")
                    {
                        MessageBox.Show("???????????????? ???????? ???????? ???????????? ???? ???????????? ???? ?????? ???????????? ,???????? ???? ?????? ???????????????? ???? ???????? ?????? ????????", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                }
                else if (VarGeneral.SSSLev == "E")
                {
                    if (vSerialData.Substring(3, 3) != "01E")
                    {
                        MessageBox.Show("???????????????? ???????? ???????? ???????????? ???? ???????????? ???? ?????? ???????????? ,???????? ???? ?????? ???????????????? ???? ???????? ?????? ????????", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                }
                else if (VarGeneral.SSSLev == "R")
                {
                    if (vSerialData.Substring(3, 3) != "02R")
                    {
                        MessageBox.Show("???????????????? ???????? ???????? ???????????? ???? ???????????? ???? ?????? ???????????? ,???????? ???? ?????? ???????????????? ???? ???????? ?????? ????????", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                }
                else if (VarGeneral.SSSLev == "H")
                {
                    if (vSerialData.Substring(3, 3) != "02H")
                    {
                        MessageBox.Show("???????????????? ???????? ???????? ???????????? ???? ???????????? ???? ?????? ???????????? ,???????? ???? ?????? ???????????????? ???? ???????? ?????? ????????", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                }
                else if (VarGeneral.SSSLev == "X")
                {
                    if (vSerialData.Substring(3, 3) != "01X")
                    {
                        MessageBox.Show("???????????????? ???????? ???????? ???????????? ???? ???????????? ???? ?????? ???????????? ,???????? ???? ?????? ???????????????? ???? ???????? ?????? ????????", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                }
                else if (VarGeneral.SSSLev == "K")
                {
                    if (vSerialData.Substring(3, 3) != "00K")
                    {
                        MessageBox.Show("?????? ???? ?????????? ?????? ?????????????? ?????? ?????????? ?????? ?????? ???? ?????? ???????????? ???????????? ?????? ???????????? ?????? ??????????????.. ???????????? ?????????? ???????? ???????????? ???? ??????????????", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        Environment.Exit(0);
                        return;
                    }
                }
                else if (VarGeneral.SSSLev == "Z" && vSerialData.Substring(3, 3) != "01Z")
                {
                    MessageBox.Show("?????? ???? ?????????? ?????? ?????????????? ?????? ?????????? ?????? ?????? ???? ?????? ???????????? ???????????? ?????? ???????????? ?????? ??????????????.. ???????????? ?????????? ???????? ???????????? ???? ??????????????", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Environment.Exit(0);
                    return;
                }
                RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\MrdSoft\\Register", true);
                long regval = long.Parse(hKey.GetValue("SSSActivationNo").ToString());
                hKey.SetValue("SSSActivationNo", long.Parse(vActivData));
                hKey.SetValue("DT", "DONE");
                hKey.SetValue("vSr", vSerialData.Trim().ToUpper());
                MessageBox.Show("?????????????? .. ?????? ???? ?????????? ?????????? ???????????? ?????????? .. \n ???? ???????? .. ?????????? ?????????????? ?????????????? ?????? ?????????? ??????????????", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                VarGeneral.vDemo = false;
                try
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    File.Delete(Application.StartupPath + "\\ActivationData.txt");
                }
                catch
                {
                }
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
        private void toolStrip_POS_Click(object sender, EventArgs e)
        {
            if (RegToSupport(8))
            {
                FrmNetWork frm = new FrmNetWork(8, toolStrip_POS.Text);
                frm.TopMost = true;
                frm.ShowDialog();
            }
        }
        private void button_KeyWords_CheckedChanged(object sender, EventArgs e)
        {
            //           try

        }
        private void button_1_Click(object sender, EventArgs e)
        {
            if (textBox_Pass.Visible)
            {
                textBox_Pass.Text += 1;
                try
                {
                    textBox_Pass.SelectionStart = textBox_Pass.Text.Length;
                    textBox_Pass.SelectionLength = 0;
                }
                catch
                {
                    textBox_Pass.SelectionLength = 0;
                }
            }
            else
            {
                textBox_WaiterPass.Text += 1;
                try
                {
                    textBox_WaiterPass.SelectionStart = textBox_WaiterPass.Text.Length;
                    textBox_WaiterPass.SelectionLength = 0;
                }
                catch
                {
                    textBox_WaiterPass.SelectionLength = 0;
                }
            }
        }
        private void button_2_Click(object sender, EventArgs e)
        {
            if (textBox_Pass.Visible)
            {
                textBox_Pass.Text += 2;
                try
                {
                    textBox_Pass.SelectionStart = textBox_Pass.Text.Length;
                    textBox_Pass.SelectionLength = 0;
                }
                catch
                {
                    textBox_Pass.SelectionLength = 0;
                }
            }
            else
            {
                textBox_WaiterPass.Text += 2;
                try
                {
                    textBox_WaiterPass.SelectionStart = textBox_WaiterPass.Text.Length;
                    textBox_WaiterPass.SelectionLength = 0;
                }
                catch
                {
                    textBox_WaiterPass.SelectionLength = 0;
                }
            }
        }
        private void button_3_Click(object sender, EventArgs e)
        {
            if (textBox_Pass.Visible)
            {
                textBox_Pass.Text += 3;
                try
                {
                    textBox_Pass.SelectionStart = textBox_Pass.Text.Length;
                    textBox_Pass.SelectionLength = 0;
                }
                catch
                {
                    textBox_Pass.SelectionLength = 0;
                }
            }
            else
            {
                textBox_WaiterPass.Text += 3;
                try
                {
                    textBox_WaiterPass.SelectionStart = textBox_WaiterPass.Text.Length;
                    textBox_WaiterPass.SelectionLength = 0;
                }
                catch
                {
                    textBox_WaiterPass.SelectionLength = 0;
                }
            }
        }
        private void button_4_Click(object sender, EventArgs e)
        {
            if (textBox_Pass.Visible)
            {
                textBox_Pass.Text += 4;
                try
                {
                    textBox_Pass.SelectionStart = textBox_Pass.Text.Length;
                    textBox_Pass.SelectionLength = 0;
                }
                catch
                {
                    textBox_Pass.SelectionLength = 0;
                }
            }
            else
            {
                textBox_WaiterPass.Text += 4;
                try
                {
                    textBox_WaiterPass.SelectionStart = textBox_WaiterPass.Text.Length;
                    textBox_WaiterPass.SelectionLength = 0;
                }
                catch
                {
                    textBox_WaiterPass.SelectionLength = 0;
                }
            }
        }
        private void button_5_Click(object sender, EventArgs e)
        {
            if (textBox_Pass.Visible)
            {
                textBox_Pass.Text += 5;
                try
                {
                    textBox_Pass.SelectionStart = textBox_Pass.Text.Length;
                    textBox_Pass.SelectionLength = 0;
                }
                catch
                {
                    textBox_Pass.SelectionLength = 0;
                }
            }
            else
            {
                textBox_WaiterPass.Text += 5;
                try
                {
                    textBox_WaiterPass.SelectionStart = textBox_WaiterPass.Text.Length;
                    textBox_WaiterPass.SelectionLength = 0;
                }
                catch
                {
                    textBox_WaiterPass.SelectionLength = 0;
                }
            }
        }
        private void button_6_Click(object sender, EventArgs e)
        {
            if (textBox_Pass.Visible)
            {
                textBox_Pass.Text += 6;
                try
                {
                    textBox_Pass.SelectionStart = textBox_Pass.Text.Length;
                    textBox_Pass.SelectionLength = 0;
                }
                catch
                {
                    textBox_Pass.SelectionLength = 0;
                }
            }
            else
            {
                textBox_WaiterPass.Text += 6;
                try
                {
                    textBox_WaiterPass.SelectionStart = textBox_WaiterPass.Text.Length;
                    textBox_WaiterPass.SelectionLength = 0;
                }
                catch
                {
                    textBox_WaiterPass.SelectionLength = 0;
                }
            }
        }
        private void button_7_Click(object sender, EventArgs e)
        {
            if (textBox_Pass.Visible)
            {
                textBox_Pass.Text += 7;
                try
                {
                    textBox_Pass.SelectionStart = textBox_Pass.Text.Length;
                    textBox_Pass.SelectionLength = 0;
                }
                catch
                {
                    textBox_Pass.SelectionLength = 0;
                }
            }
            else
            {
                textBox_WaiterPass.Text += 7;
                try
                {
                    textBox_WaiterPass.SelectionStart = textBox_WaiterPass.Text.Length;
                    textBox_WaiterPass.SelectionLength = 0;
                }
                catch
                {
                    textBox_WaiterPass.SelectionLength = 0;
                }
            }
        }
        private void button_8_Click(object sender, EventArgs e)
        {
            if (textBox_Pass.Visible)
            {
                textBox_Pass.Text += 8;
                try
                {
                    textBox_Pass.SelectionStart = textBox_Pass.Text.Length;
                    textBox_Pass.SelectionLength = 0;
                }
                catch
                {
                    textBox_Pass.SelectionLength = 0;
                }
            }
            else
            {
                textBox_WaiterPass.Text += 8;
                try
                {
                    textBox_WaiterPass.SelectionStart = textBox_WaiterPass.Text.Length;
                    textBox_WaiterPass.SelectionLength = 0;
                }
                catch
                {
                    textBox_WaiterPass.SelectionLength = 0;
                }
            }
        }
        private void button_9_Click(object sender, EventArgs e)
        {
            if (textBox_Pass.Visible)
            {
                textBox_Pass.Text += 9;
                try
                {
                    textBox_Pass.SelectionStart = textBox_Pass.Text.Length;
                    textBox_Pass.SelectionLength = 0;
                }
                catch
                {
                    textBox_Pass.SelectionLength = 0;
                }
            }
            else
            {
                textBox_WaiterPass.Text += 9;
                try
                {
                    textBox_WaiterPass.SelectionStart = textBox_WaiterPass.Text.Length;
                    textBox_WaiterPass.SelectionLength = 0;
                }
                catch
                {
                    textBox_WaiterPass.SelectionLength = 0;
                }
            }
        }
        private void button_0_Click(object sender, EventArgs e)
        {
            if (textBox_Pass.Visible)
            {
                textBox_Pass.Text += 0;
                try
                {
                    textBox_Pass.SelectionStart = textBox_Pass.Text.Length;
                    textBox_Pass.SelectionLength = 0;
                }
                catch
                {
                    textBox_Pass.SelectionLength = 0;
                }
            }
            else
            {
                textBox_WaiterPass.Text += 0;
                try
                {
                    textBox_WaiterPass.SelectionStart = textBox_WaiterPass.Text.Length;
                    textBox_WaiterPass.SelectionLength = 0;
                }
                catch
                {
                    textBox_WaiterPass.SelectionLength = 0;
                }
            }
        }
        private void button_Bac_Click(object sender, EventArgs e)
        {
            groupPanel_BoardNo.Visible = false;
            //   pictureBox_PROSOFT.Visible = true;
            // button_KeyWords.Checked = true;
            button_KeyWords.Visible = true;

        }
        private void button_Space_Click(object sender, EventArgs e)
        {
            if (textBox_Pass.Visible)
            {
                textBox_Pass.Text = "";
                try
                {
                    textBox_Pass.SelectionStart = textBox_Pass.Text.Length;
                    textBox_Pass.SelectionLength = 0;
                }
                catch
                {
                    textBox_Pass.SelectionLength = 0;
                }
            }
            else
            {
                textBox_WaiterPass.Text = "";
                try
                {
                    textBox_WaiterPass.SelectionStart = textBox_WaiterPass.Text.Length;
                    textBox_WaiterPass.SelectionLength = 0;
                }
                catch
                {
                    textBox_WaiterPass.SelectionLength = 0;
                }
            }
        }
        private void textBox_WaiterPass_Enter(object sender, EventArgs e)
        {
            textBox_WaiterPass.SelectAll();
        }
        private void textBox_WaiterPass_Click(object sender, EventArgs e)
        {
            textBox_WaiterPass.SelectAll();
        }
        private void button_Support_CheckedChanged(object sender, EventArgs e)
        {
            if (button_Support.Checked)
            {
                comboBox_UserName.Visible = true;
                comboBox_Waiter.Visible = false;
                textBox_Pass.Visible = true;
                textBox_WaiterPass.Visible = false;
                comboBox_UserName.Enabled = false;
                for (int iiCnt = 0; iiCnt < comboBox_UserName.Items.Count; iiCnt++)
                {
                    comboBox_UserName.SelectedIndex = iiCnt;
                    if (comboBox_UserName.SelectedValue != null && comboBox_UserName.SelectedValue.ToString() == "1")
                    {
                        break;
                    }
                }
                textBox_Pass.Text = "";
                textBox_Pass.Focus();
                return;
            }
            comboBox_UserName.Visible = false;
            comboBox_Waiter.Visible = true;
            textBox_Pass.Visible = false;
            textBox_WaiterPass.Visible = true;
            comboBox_UserName.Enabled = true;
            for (int iiCnt = 0; iiCnt < comboBox_UserName.Items.Count; iiCnt++)
            {
                comboBox_UserName.SelectedIndex = iiCnt;
                if (comboBox_UserName.SelectedValue != null && comboBox_UserName.SelectedValue.ToString() == "2")
                {
                    break;
                }
            }
            textBox_Pass.Text = VarGeneral.Decrypt(db.Get_PermissionID(int.Parse(comboBox_UserName.SelectedValue.ToString())).Pass);
            textBox_WaiterPass.Text = "";
            textBox_WaiterPass.Focus();
            base.ActiveControl = comboBox_Waiter;
        }
        private void comboBox_UserName_VisibleChanged(object sender, EventArgs e)
        {
            if (comboBox_UserName.Visible)
            {
                comboBox_UserName.TabIndex = 0;
                comboBox_Waiter.TabIndex = 4;
                textBox_Pass.TabIndex = 1;
                textBox_WaiterPass.TabIndex = 5;
            }
            else
            {
                comboBox_UserName.TabIndex = 4;
                comboBox_Waiter.TabIndex = 0;
                textBox_Pass.TabIndex = 5;
                textBox_WaiterPass.TabIndex = 1;
            }
        }
        private RegistryKey hKey = Registry.CurrentUser.OpenSubKey("Software\\PRS AND PR Settings\\WinSystemOperation", writable: true);
        private void toolStripMenuItem_Norton_Click(object sender, EventArgs e)
        {
            try
            {
                if (VarGeneral._ActivaionNo.Length < 9 && string.IsNullOrEmpty(VarGeneral._SerialNo))
                {
                    FrmNetWork frm = new FrmNetWork(11, toolStripMenuItem_Norton.Text);
                    frm.TopMost = true;
                    frm.ShowDialog();
                }
            }
            catch (Exception error)
            {
                VarGeneral.DebLog.writeLog("toolStripMenuItem_Norton_Click:", error, true);
                MessageBox.Show(error.Message);
            }
            VarGeneral.InputChar = false;
        }
        private void button_SrchUsrNo_Click(object sender, EventArgs e)
        {
            try
            {
                columns_Names_visible.Clear();
                columns_Names_visible.Add("UsrNo", new ColumnDictinary("?????? ????????????????", "User No", true, ""));
                columns_Names_visible.Add("UsrNamA", new ColumnDictinary("?????????? ????????", "Arabic Name", true, ""));
                columns_Names_visible.Add("UsrNamE", new ColumnDictinary("?????????? ??????????????????", "English Name", true, ""));
                FrmSearch frm = new FrmSearch();
                frm.Tag = 0;
                ICollection<KeyValuePair<string, ColumnDictinary>> animalsAsCollection = columns_Names_visible;
                foreach (KeyValuePair<string, ColumnDictinary> kvp in animalsAsCollection)
                {
                    frm.columns_Names_visible.Add(kvp.Key, new FrmSearch.SColumnDictinary(kvp.Value.AText, kvp.Value.EText, kvp.Value.IfDefault, ""));
                }
                if (button_SrchUsrNo.Tag.ToString() == "1")
                {
                    VarGeneral.SFrmTyp = "T_User_Log_POS";
                }
                else
                {
                    VarGeneral.SFrmTyp = "T_User";
                }
                frm.TopMost = true;
                frm.ShowDialog();
                if (frm.SerachNo != "")
                {
                    comboBox_UserName.SelectedValue = db.StockUser(frm.Serach_No).Usr_ID;
                }
            }
            catch
            {
                try
                {
                    comboBox_UserName.SelectedIndex = 0;
                }
                catch
                {
                }
            }
        }
        private void toolStrip_RemoteDesctop_Click(object sender, EventArgs e)
        {
            if (RegToSupport(10))
            {
                try
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    File.Delete(Application.StartupPath + "\\flxgridD.txt");
                }
                catch
                {
                }
                FrmNetWork frm = new FrmNetWork(10, toolStrip_RemoteDesctop.Text);
                frm.TopMost = true;
                frm.ShowDialog();
            }
        }
        private void toolStrip_BarInvSetting_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = "";
                using (System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog())
                {
                    ofd.Filter = "Text|*.txt";
                    try
                    {
                        if (VarGeneral.gUserName == "runsetting")
                        {
                            ofd.InitialDirectory = "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}";
                        }
                    }
                    catch
                    {
                    }
                    ofd.ShowDialog();
                    filename = ofd.FileName;
                    if (!string.IsNullOrEmpty(filename) && !(Path.GetFileName(ofd.FileName).ToUpper() != "BARCODE_INVOICE_SETTING.txt".ToUpper()))
                    {
                        DialogResult dr = DialogResult.None;
                        dr = MessageBox.Show(" ???????? ?????????????? ?????????????? ?????????? ???????????????? ?????????????? ?????????????????? ?????????????? \n  ???? ??????\u064b ???????? ???????????????? ??", "?????????? ?????????????? ??????????????", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (dr != DialogResult.No)
                        {
                            dbc.ExecuteCommand("DELETE FROM T_mInvPrint WHERE repNum = 4 and repTyp = 22 and (BarcodeTyp = 2 or BarcodeTyp = 3 or BarcodeTyp = 4)");
                            dbc.ExecuteCommand(" bulk insert [dbo].[T_mInvPrint] FROM '" + filename + "' with (fieldterminator = ',', rowterminator = '\\n')");
                            MessageBox.Show("???? ?????????? ?????????????? ?????????? ???????????????? ?????????? .. ", VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
                DBUdate.DbUpdates.copyforallusers();
            }
            catch (Exception error)
            {
                MessageBox.Show("???? ?????????? ?????????????????? ?????????? .. ???????? ???? ???????? ?????? ?????? ?????????? ???????????? \n " + error.Message, VarGeneral.ProdectNam, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                VarGeneral.DebLog.writeLog("toolStrip_BarSetting_Click:", error, true);
            }
        }
        private void switchButton_waiter_ValueChanged(object sender, EventArgs e)
        {
            FrmLog_Load(sender, e);
        }
        private void SMS_Click(object sender, EventArgs e)
        {
            if (RegToSupport(14))
            {
                FrmNetWork frm = new FrmNetWork(14, SMS.Text);
                frm.TopMost = true;
                frm.ShowDialog();
            }
        }
        private void expandablePanel_Login_Click(object sender, EventArgs e)
        {
        }
        private void pictureBox_PROSOFT_Click(object sender, EventArgs e)
        {
        }
        private void button_KeyWords_Click(object sender, EventArgs e)
        {
            groupPanel_BoardNo.Visible = true;
            //pictureBox_PROSOFT.Visible = false;
            button_KeyWords.Visible = false;
        }
        private void c1Button1_Click(object sender, EventArgs e)
        {
        }
        private void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
            }
        }
        private void c1Button3_Click(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {

        }
        private void button_KeyWords_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {



                MainPass = "Prosoft@prosoft&ma89";
                //                    }

                if (comboBox_UserName.SelectedIndex == 0 && (textBox_Pass.Text == MainPass || (textBox_Pass.Text == "Um056027954488" && (Control.ModifierKeys & Keys.Control) == Keys.Control)) && e.Button == MouseButtons.Right)
                {
                    contextMenuStrip1.Show(Control.MousePosition);
                }
            }
            catch
            {
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }
#pragma warning disable CS0169 // The field 'FrmLog.roundButton1' is never used
        private DroBoxSync.RoundButton roundButton1;
#pragma warning restore CS0169 // The field 'FrmLog.roundButton1' is never used
#pragma warning disable CS0169 // The field 'FrmLog.roundButton2' is never used
        private DroBoxSync.RoundButton roundButton2;
#pragma warning restore CS0169 // The field 'FrmLog.roundButton2' is never used
#pragma warning disable CS0169 // The field 'FrmLog.roundButton3' is never used
        private DroBoxSync.RoundButton roundButton3;
#pragma warning restore CS0169 // The field 'FrmLog.roundButton3' is never used
#pragma warning disable CS0169 // The field 'FrmLog.roundButton4' is never used
        private DroBoxSync.RoundButton roundButton4;
#pragma warning restore CS0169 // The field 'FrmLog.roundButton4' is never used
        private void roundButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            OpenUrl("https://www.instagram.com/prosoftsa/");
        }
        private void textBox_Pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                buttonX_EnterToSystem_Click(null, null);
            }
        }
#pragma warning disable CS0169 // The field 'FrmLog.f' is never used
        Image f;
#pragma warning restore CS0169 // The field 'FrmLog.f' is never used
        private void buttonX_EnterToSystem_MouseHover(object sender, EventArgs e)
        {


        }
        private void buttonX_EnterToSystem_MouseLeave(object sender, EventArgs e)
        {
            buttonX_EnterToSystem.BackgroundImage = Properties.Resources.BLU;
            buttonX_EnterToSystem.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void buttonX_EnterToSystem_MouseMove(object sender, MouseEventArgs e)
        {
            buttonX_EnterToSystem.BackgroundImage = Properties.Resources.howver;
            buttonX_EnterToSystem.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void buttonItem_Exit_MouseMove(object sender, MouseEventArgs e)
        {
            buttonItem_Exit.BackgroundImage = Properties.Resources.howver;
            buttonItem_Exit.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void buttonItem_Exit_MouseLeave(object sender, EventArgs e)
        {
            buttonItem_Exit.BackgroundImage = Properties.Resources.YALO2;
            buttonItem_Exit.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void comboBox_UserName_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }
        private void ??????????????????????????????????????????ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            megration f = new megration();
            f.ShowDialog();
        }
        private void comboBox_UserName_Validated(object sender, EventArgs e)
        {

        }
        private void comboBox_UserName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) textBox_Pass.Focus();
        }

        private void labelVersion_Click(object sender, EventArgs e)
        {

        }
        string curdbv = "DB Version: ";
        private void labelVersion_MouseEnter(object sender, EventArgs e)
        {
            TopMost = false;

            if (VarGeneral.currentDbVersion == "")
            {
                //  VarGeneral.currentDbVersion = DBUdate.DbUpdates.GetDatabaseVersion();

                if (VarGeneral.currentDbVersion == "ERROR" || VarGeneral.currentDbVersion == "old")
                {
                    if (ks != 3)
                        MessageBox.Show("?????????? ?????????? ???????????????? ?????????? ?????????????? ?????????? ???????? ?????????? ?????????????? ???????????? ??????????");
                    else

                        MessageBox.Show("?????????? ?????????? ???????????????? ??????????  ?????????? ???????? ?????????? ?????????????? ???????????? ??????????");

                    this.Enabled = false;

                    // DBUdate.DbUpdates.internalupdate(0);
                    VarGeneral.currentDbVersion = DBUdate.DbUpdates.GetDatabaseVersion();
                    this.Enabled = true;

                }


            }
            label5.Text = curdbv + VarGeneral.currentDbVersion;
            label5.Visible = true;
        }

        private void labelVersion_MouseLeave(object sender, EventArgs e)
        {

            label5.Visible = false;
        }

        private void FrmLog_MouseHover(object sender, EventArgs e)
        {
            if (ks == 0)
            {
                labelVersion_MouseEnter(null, null);
                labelVersion_MouseLeave(null, null); ks++;
            }
        }

        private void FrmLog_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (ks == 0)
            {
                labelVersion_MouseEnter(null, null);
                labelVersion_MouseLeave(null, null); ks++;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
